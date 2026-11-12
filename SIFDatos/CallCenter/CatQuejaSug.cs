using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace SIFDatos.CallCenter
{
    public class CatQuejaSug
    {
        /// <summary>
        /// Utiliza el SP_INS_CAT_QUEJA_SUG_TIPO para agregar la queja
        /// </summary>
        /// <param name="modelo">La instancia del Impuesto</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.QuejasSugTipo.CatQuejasSug modelo)
        {
            string sentencia = "SP_INS_CAT_QUEJA_SUGERENCIA";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS

                    cmd.Parameters.Add("queja_sugerencia_id", modelo.SugerenciaId);
                    cmd.Parameters.Add("nombre", modelo.Nombre);
                    cmd.Parameters.Add("tipo", (char)modelo.Tipo);
                    cmd.Parameters.Add("activo", (char)modelo.Activo);

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
                                throw new Exception("Ha ocurrido un error al insertar el registro" + id.ToString());
                            }

                            modelo.SugerenciaId = int.Parse(id.ToString());
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



        public static bool Elimina(SIFModelo.QuejasSugTipo.CatQuejasSug modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_QUEJASUGTIPO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("ID", modelo.SugerenciaId);

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

                        modelo.SugerenciaId = 10;

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

        public static bool Actualiza(SIFModelo.QuejasSugTipo.CatQuejasSug modelo)
        {
            string sentencia = "SP_UPD_CAT_QUEJA_SUGERENCIA";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("ecat_queja_sugerencia_id", modelo.SugerenciaId);
                    cmd.Parameters.Add("enombre", modelo.Nombre);
                    cmd.Parameters.Add("etipo", (char) modelo.Tipo);
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


        public static DataSet  Busca(string propiedad, string parametro)
        {
            DataSet ds = new DataSet("DSCatQuejasSug");
            ds.Tables.Add("CatQuejasSug");
            string sentencia = "SELECT * FROM CAT_QUEJA_SUGERENCIA "; //AND REF_REMISION_VTA IS NULL

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "CatQuejasSug");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }
            return ds;
        }

        public static SIFModelo.QuejasSugTipo.CatQuejasSug QuejaSugPorID(int p)
        {
            List<SIFModelo.QuejasSugTipo.CatQuejasSug> rows = new List<SIFModelo.QuejasSugTipo.CatQuejasSug>();

            string sentencia = "SELECT * FROM CAT_QUEJA_SUGERENCIA WHERE CAT_QUEJA_SUGERENCIA_ID = :QuejaSugID";

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
                            SIFModelo.QuejasSugTipo.CatQuejasSug registro = new SIFModelo.QuejasSugTipo.CatQuejasSug();

                            registro.SugerenciaId = int.Parse(oreader["CAT_QUEJA_SUGERENCIA_ID"].ToString());
                            registro.Tipo = (SIFModelo.Tipos.QuejaSug)oreader["TIPO"].ToString()[0];
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