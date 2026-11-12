using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
namespace SIFDatos
{
    public static class Bancos
    {
        /// <summary>
        /// Utiliza el SP_INS_BANCO para agregar un banco
        /// </summary>
        /// <param name="modelo">La instancia del banco</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.Banco modelo)
        {
            string sentencia = "sp_ins_cat_bancos";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nombre", modelo.Nombre);
                    cmd.Parameters.Add("credito",System.Convert.ToChar(modelo.Credito));
                    cmd.Parameters.Add("debito", System.Convert.ToChar(modelo.Debito));
                    cmd.Parameters.Add("comision", modelo.Comision);

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
                            
                            modelo.ID = int.Parse(id.ToString());
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

        public static bool Elimina(SIFModelo.Banco modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_BANCO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("ID", modelo.ID);

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

                        modelo.ID = 10;

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

        public static bool Actualiza(SIFModelo.Banco modelo)
        {
            string sentencia = "sp_upd_cat_bancos";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("ban_id", modelo.ID);
                    cmd.Parameters.Add("enom", modelo.Nombre);
                    cmd.Parameters.Add("ecredito", System.Convert.ToChar(modelo.Credito));
                    cmd.Parameters.Add("edebito", System.Convert.ToChar(modelo.Debito));
                    cmd.Parameters.Add("eactivo", System.Convert.ToChar(modelo.Activo));
                    cmd.Parameters.Add("ecomision", modelo.Comision);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Int32);
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

        public static List<SIFModelo.Banco> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.Banco> rows = new List<SIFModelo.Banco>();

            string sentencia = "SELECT * FROM cat_bancos";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Banco registro = new SIFModelo.Banco();

                            registro.ID = int.Parse(oreader["BANCOS_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();
                                registro.Credito = (SIFModelo.Tipos.SiNo)(oreader["CREDITO"].ToString()[0]);
                                registro.Debito =(SIFModelo.Tipos.SiNo)(oreader["DEBITO"].ToString()[0]);
                                registro.Comision = System.Convert.ToDecimal(oreader["COMISION"]);
                                registro.Activo = (SIFModelo.Tipos.SiNo)(oreader["DEBITO"].ToString()[0]);
                            rows.Add(registro);
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }
            return rows;
        }

    }
}
