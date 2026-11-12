using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SIFDatos.WebServices
{
    public class ApiTL
    {
        public static SIFModelo.Configuracion.configApiTL Control(string nombre)
        {
            string sentencia = "SELECT * FROM CONFIGURACION_API_TIENDAL WHERE NOMBRE = :PNombre";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("pNOMBRE", nombre);

                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Configuracion.configApiTL registro = new SIFModelo.Configuracion.configApiTL();
                            if (registro != null)
                            {
                                registro.ID = oreader["ID"].ToString();
                                registro.NOMBRE = oreader["NOMBRE"].ToString();
                                registro.URI = oreader["URI"].ToString();
                                registro.USER = oreader["USER"].ToString();
                                registro.KEY = oreader["KEY"].ToString();

                            }
                            return registro;
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Dispose();
                    //OracleConnection.ClearPool(cmd.Connection);
                }

            }
            return null;
        }


    }
}
