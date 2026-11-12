using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data;
using DevComponents.DotNetBar;

namespace SIFDatos.Almacen
{
    public class Bultos
    {
        public static SIFModelo.Inventarios.InventarioDataSet Get(SIFModelo.Inventarios.InventarioDataSet ds )
        {
            String sentencia = "SELECT * FROM BULTOS "; //
        
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "BULTOS");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }
            return ds;
           
        }

        public static SIFModelo.Inventarios.InventarioDataSet Update(SIFModelo.Inventarios.InventarioDataSet ds)
        {
            
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.Inventarios.InventarioDataSetTableAdapters.BULTOSTableAdapter Tb = new SIFModelo.Inventarios.InventarioDataSetTableAdapters.BULTOSTableAdapter();

                Tb.Connection.ConnectionString = cnx.ConnectionString;
                Tb.Update(ds.BULTOS);
                
            }
            return ds;

        }

        

        

    }
}
