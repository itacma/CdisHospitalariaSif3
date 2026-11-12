using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace SIFDatos.CallCenter
{
    public static class Horarios
    {
        public static SIFModelo.CallCenter.CallCenterDataSet CargaHorarios()
        {
            SIFModelo.CallCenter.CallCenterDataSet ds = new SIFModelo.CallCenter.CallCenterDataSet();

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.CallCenter.CallCenterDataSetTableAdapters.HORARIOSTableAdapter ta = new SIFModelo.CallCenter.CallCenterDataSetTableAdapters.HORARIOSTableAdapter();
                ta.Connection = cnx;

                ta.FillByActivo(ds.HORARIOS);
            }
            return ds;
        }

    }
}
