using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data;
using DevComponents.DotNetBar;

namespace SIFDatos.Seguridad
{
    public class Usuarios
    {
        public static SIFModelo.Seguridad.Seguridad Get(SIFModelo.Seguridad.Seguridad ds )
        {
            String sentencia = "SELECT * FROM CAT_USUARIOS "; //
        
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "CAT_USUARIOS");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }
            return ds;
           
        }

        public static SIFModelo.Seguridad.Seguridad Update(SIFModelo.Seguridad.Seguridad ds)
        {
            String sentencia = "Select * CAT_USUARIOS"; //

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.Seguridad.SeguridadTableAdapters.CAT_USUARIOSTableAdapter Tb = new SIFModelo.Seguridad.SeguridadTableAdapters.CAT_USUARIOSTableAdapter();
                
                
               Tb.Connection = cnx;
                Tb.Update(ds.CAT_USUARIOS);
                
            }
            return ds;

        }      

    }
}
