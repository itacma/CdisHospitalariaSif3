using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace SIFDatos.CallCenter
{
    public class CatQuejaSugTipo
    {
        /// <summary>
        /// Utiliza el SP_INS_CAT_QUEJA_SUG_TIPO para agregar la queja
        /// </summary>
        /// <param name="modelo">La instancia del Impuesto</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.QuejasSugTipo.CatQuejaSugSubTipo modelo)
        {
            string sentencia = "SP_INS_CAT_QUEJA_SUG_TIPO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS

                    cmd.Parameters.Add("queja_sugerencia_id", modelo.SugerenciaId);
                    cmd.Parameters.Add("queja_sugerencia_tipo_id", modelo.SugerenciaTipoId);
                    cmd.Parameters.Add("nombre", modelo.Nombre);
                    cmd.Parameters.Add("Activo", (char) modelo.Activo);
                    
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();

                        var id = cmd.ExecuteScalar();
                        if (id.ToString().IsInteger())
                        {
                            if (int.Parse(id.ToString()) < 0)
                            {
                                throw new Exception("Ha ocurrido un error al insetrar el registro" + id.ToString());
                            }

                            modelo.SugerenciaTipoId = int.Parse(id.ToString());
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            return true;
        }

        public static bool Elimina(SIFModelo.QuejasSugTipo.CatQuejaSugSubTipo modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_IMPUESTO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("ID", modelo.SugerenciaTipoId);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteReader();

                        modelo.SugerenciaTipoId = 10;

                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            return true;
        }

        public static bool Actualiza(SIFModelo.QuejasSugTipo.CatQuejaSugSubTipo modelo)
        {
            string sentencia = "SP_UPD_CAT_QUEJA_SUG_TIPO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("ecat_queja_sugerencia_id", modelo.SugerenciaId);
                    cmd.Parameters.Add("ecat_queja_sug_tipo_id", modelo.SugerenciaTipoId);
                    cmd.Parameters.Add("enombre", modelo.Nombre);
                    cmd.Parameters.Add("eactivo",(char) modelo.Activo);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            return true;
        }

        public static DataSet Busca(string propiedad, string parametro, int SugerenciaID)
        {
            DataSet ds = new DataSet("DSCatQuejasSugTipo");
            ds.Tables.Add("CatQuejasSugTipo");
            string sentencia = "SELECT * FROM CAT_QUEJA_SUG_TIPO where CAT_QUEJA_SUGERENCIA_ID= :SugerenciaID"; //AND REF_REMISION_VTA IS NULL

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                     cmd.Parameters.Add("SugerenciaID", SugerenciaID);
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "CatQuejasSugTipo");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }
            return ds;
        }

        public static SIFModelo.QuejasSugTipo.CatQuejaSugSubTipo QuejaSugTipoPorID(int p)
        {
            List<SIFModelo.QuejasSugTipo.CatQuejaSugSubTipo> rows = new List<SIFModelo.QuejasSugTipo.CatQuejaSugSubTipo>();

            string sentencia = "SELECT * FROM CAT_QUEJA_SUG_TIPO WHERE CAT_QUEJA_SUGERENCIA_TIPO_ID = :QuejaSugID";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //
                    cmd.Parameters.Add(":QuejaSugID", p);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.QuejasSugTipo.CatQuejaSugSubTipo registro = new SIFModelo.QuejasSugTipo.CatQuejaSugSubTipo();

                            registro.SugerenciaId = int.Parse(oreader["CAT_QUEJA_SUGERENCIA_ID"].ToString());
                            registro.SugerenciaTipoId = int.Parse(oreader["CAT_QUEJA_SUGERENCIA_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Activo = (SIFModelo.Tipos.SiNo)oreader["ACTIVO"].ToString()[0];
                            return registro;
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);

                }

            }
            return null;
        }


    }
}
