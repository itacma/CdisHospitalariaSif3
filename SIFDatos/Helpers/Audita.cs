using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace SIFDatos.Helpers
{
    public static class Audita
    {
        public static void InsertaAudit(string usuario, string procedimiento, string parametros, string modulo, string error)
        {
            try
            {

                string maquina = System.Environment.MachineName;

                string sentencia = "INSERT INTO FARMACIA.AUDITA ( " +
      " USUARIO, PROCEDIMIENTO, PARAMETROS,    " +
      " MODULO, MAQUINA, FECHA,                " +
      " ERROR, AUDIT_ID)                       " +
    "VALUES (  " + usuario + ", '" +
     procedimiento + "', '" +
     parametros + "', '" +
     modulo + "', '" +
     maquina + "', " +
     "TO_DATE('" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "','YYYY/MM/DD HH24:MI:SS') , '" +
     error + "', " +
     " SEC_AUDITA.NEXTVAL )";



                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();

                        
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }
            catch (Exception EX)
            {

            }

        }
    }
}
