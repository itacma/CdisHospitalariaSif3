using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIFNegocio.ReportesAdmin
{
    public class ReportesV1
    {

        public  List<SIFModelo.ReportesAdmin.reportesUsuarios> GetReportesCmb(string tipoUsuario) {

            return SIFDatos.ReportesArdmin.reportesAdmin.GetReportesCmb(tipoUsuario);

        }
        public List<string> GetReportesResult(string pentrada)
        {

            return SIFDatos.ReportesArdmin.reportesAdmin.GetReportesResult(pentrada);

        }

     
        public List<string> GetReportesResultQuery(string pQuery, string param1="")
        {

            return SIFDatos.ReportesArdmin.reportesAdmin.GetReportesResultQuery(pQuery, param1);

        }
        public string spInsSif3BitacoraSucesos(SIFModelo.Sif3BitacoraSucesos Model)
        {
            return SIFDatos.ReportesArdmin.reportesAdmin.spInsSif3BitacoraSucesos(Model);
        }

        public  DataTable GetDataTable(SIFModelo.ReportesAdmin.reportesUsuarios Model)
        {
            return SIFDatos.ReportesArdmin.reportesAdmin.GetDataTable(Model);
        }

   }
}
