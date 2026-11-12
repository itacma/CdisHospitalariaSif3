using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
namespace SIFDatos
{
    public static class Cajeros
    {
        /// <summary>
        /// Utiliza el SP_INS_Cajero para agregar un Cajero
        /// </summary>
        /// <param name="modelo">La instancia del Cajero</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.Cajero modelo)
        {
            string sentencia = "SP_INS_CAJERO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("supervisor_id", modelo.SupervisorID);
                    cmd.Parameters.Add("turno",System.Convert.ToChar(modelo.Turno));
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

        public static bool Elimina(SIFModelo.Cajero modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_Cajero";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("CAJERO_ID", modelo.CajeroID);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
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

        public static bool Actualiza(SIFModelo.Cajero modelo)
        {
            string sentencia = "SP_UPD_CAJEROS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("ban_id", modelo.CajeroID);
                    cmd.Parameters.Add("supervisor_id", modelo.SupervisorID);
                    cmd.Parameters.Add("turno", System.Convert.ToChar(modelo.Turno));
                    cmd.Parameters.Add("hora_entrada", modelo.HoraEntrada);
                    cmd.Parameters.Add("hora_salida", modelo.HoraSalida);

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

        public static List<SIFModelo.Cajero> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.Cajero> rows = new List<SIFModelo.Cajero>();

            string sentencia = "SP_GET_CAJEROS";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //TIPO DE COMANDO
                    cmd.CommandType = CommandType.StoredProcedure;
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("REFCUR", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Cajero registro = new SIFModelo.Cajero()
                            {
                                SupervisorID = oreader["SUPERVISOR_ID"].ToString(),
                                Turno = (SIFModelo.Tipos.Turno)System.Convert.ToSByte(oreader["TURNO"]),
                                HoraEntrada = System.Convert.ToDateTime(oreader["HORA_ENTRADA"]),
                                HoraSalida = System.Convert.ToDateTime(oreader["HORA_SALIDA"])
                            };
                            rows.Add(registro)  ;
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
