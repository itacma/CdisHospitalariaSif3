using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace SIFDatos
{
    public class Configuracion
    {
        public static DateTime FechaServidor()
        {
            List<SIFModelo.Banco> rows = new List<SIFModelo.Banco>();

            string sentencia = "SELECT f_sysdate() FROM dual";
            DateTime fechaS = DateTime.Now;
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //

                    try
                    {
                        cmd.Connection.Open();
                        var fecha = cmd.ExecuteScalar();
                        if (fecha.ToString().IsDatetime())
                        {
                            fechaS = System.Convert.ToDateTime(fecha);
                        }

                    }
                    catch
                    {
                        fechaS = DateTime.Now;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        
                      //  cmd.Connection.Dispose();
                       ////OracleConnection.ClearPool(cnx);
                    }

                }

            }
            return fechaS;
        }

        public static bool Actualiza(string clave, string valor)
        {
            string sentencia = "UPDATE CONFIGURACION SET " + clave + " = '" + valor + "' WHERE CONFIGURACION_ID = 1 ";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
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
                        
                     //   cmd.Connection.Dispose();
                      // //OracleConnection.ClearPool(cnx);
                    }
                }
            }

            return true;
        }

        public static string Leer(string clave)
        {
            string sentencia = "SELECT " + clave + " FROM CONFIGURACION WHERE CONFIGURACION_ID = 1";
            string valor = string.Empty;
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    try
                    {
                        cmd.Connection.Open();
                        valor = cmd.ExecuteScalar().ToString();
                    }
                    catch (Exception)
                    {
                        return "0";
                    }
                    finally
                    {
                        cmd.Connection.Close();                        
                        //cmd.Connection.Dispose();
                       ////OracleConnection.ClearPool(cmd.Connection);
                    }
                }
            }

            return valor;
        }

    }
}

