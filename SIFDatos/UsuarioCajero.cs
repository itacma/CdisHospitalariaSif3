using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
namespace SIFDatos
{
    public static class UsuarioCajero
    {
        /// <summary>
        /// Utiliza el SP_INS_UsuarioCajero para agregar un UsuarioCajero
        /// </summary>
        /// <param name="modelo">La instancia del UsuarioCajero</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.UsuarioCajero modelo)
        {
            string sentencia = "sp_ins_cat_usr_cajero";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("cajero_id", modelo.CajeroID);
                    cmd.Parameters.Add("supervisor_id", modelo.UsuarioID);
                    cmd.Parameters.Add("turno", (char)modelo.Turno);
                    cmd.Parameters.Add("hora_entrada", modelo.HoraEntrada);
                    cmd.Parameters.Add("hora_salida", modelo.HoraSalida);

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

                            return true;
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

        public static bool Elimina(SIFModelo.UsuarioCajero modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_UsuarioCajero";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("ID", modelo.CajeroID);

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

                        modelo.CajeroID = 10;

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

        public static bool Actualiza(SIFModelo.UsuarioCajero modelo)
        {
            string sentencia = "sp_upd_cat_usr_cajero";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("eusr_id", modelo.UsuarioID);
                    cmd.Parameters.Add("esupervisor_id", modelo.UsuarioID);
                    cmd.Parameters.Add("eturno", (char)modelo.Turno);
                    cmd.Parameters.Add("ehora_entra", modelo.HoraEntrada);
                    cmd.Parameters.Add("ehora_sale", modelo.HoraSalida);

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

        public static List<SIFModelo.UsuarioCajero> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.UsuarioCajero> rows = new List<SIFModelo.UsuarioCajero>();

            string sentencia = "SELECT * FROM cat_usr_cajero";

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
                            SIFModelo.UsuarioCajero registro = new SIFModelo.UsuarioCajero();

                            registro.CajeroID = int.Parse(oreader["USR_CAJERO_ID"].ToString());
                            registro.UsuarioID = int.Parse(oreader["SUPERVISOR_ID"].ToString());
                            registro.Turno = (SIFModelo.Tipos.Turno)(oreader["TURNO"].ToString()[0]);
                            registro.HoraEntrada = System.Convert.ToDateTime(oreader["HORA_ENTRADA"]);
                            registro.HoraEntrada = System.Convert.ToDateTime(oreader["HORA_SALIDA"]);
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
