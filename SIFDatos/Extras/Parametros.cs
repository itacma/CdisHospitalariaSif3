using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;


namespace SIFDatos.Extras
    {
    public class Parametros
        {
        public static int ObtenParametro(string parametro)
            {
            /* Author: LGS
             * Created:02/09/2016
             * Description:
             *    Verifica si el parametro dado está activo en la base de datos:
             *       Activo: Regresa 1
             *       Inactivo: Regresa 0
             *       Error: Regresa -1;
             */

            string sentencia = "SELECT COUNT(*) ACTIVO FROM CAT_PARAMETROS WHERE NOMBRE = :parametro and activo = 'S' AND SYSDATE BETWEEN FECHA_INICIAL  AND FECHA_FINAL";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                    cmd.Parameters.Add("parametro", parametro);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                        {
                        while (oreader.Read())
                            {
                            int activo; //Almacena 1 si el parametro esta activo o 0 si está inactivo

                            activo = int.Parse(oreader["ACTIVO"].ToString());

                            return activo;
                            }
                        }
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);

                }

                    

            }
            return -1;
            }
        }
    }
