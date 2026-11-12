using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Reportes.OrdenCompra
{
    public partial class OrdenCompraForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public OrdenCompraForm(SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow ordenCompra)
        {
            InitializeComponent();
            this.ordenCompra = ordenCompra;
            this.CargaReporte();
        }

        SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow ordenCompra;

        private void CargaReporte()
        {
            SIFModelo.Configuracion.Aplicacion configuracion = new SIFModelo.Configuracion.Aplicacion();
            SIFModelo.Configuracion.ServidorOracle servidor = new SIFModelo.Configuracion.ServidorOracle();

            string OraGAC = SIFNegocio.Configuracion.Configuraciones.ServidorOracle.CadenaConexion;
            string Srv = OraGAC.Split(';')[0].Replace("Data Source =", string.Empty); // .Split('=')[1]; 
            string User = OraGAC.Split(';')[1].Split('=')[1];
            string Pwd = OraGAC.Split(';')[2].Split('=')[1];
            string BD = "FARMACIA";

            string Param1 = "{V_ORDENES_COMPRA.FOLIO_OC_ID} = '" +  ordenCompra.FOLIO_OC_ID + "'";

            configuracion.DirectorioReportes = SIFNegocio.Configuracion.Configuraciones.Aplicacion.DirectorioReportes;
            
            // Set Report
            reportDocument1.Load(configuracion.DirectorioReportes + @"\RPT_OrdenCompra.rpt");
            //Set the actual database location, assumes that you are using only one database in the report
             
            reportDocument1.DataSourceConnections[0].SetConnection(Srv, BD, User, Pwd);

            

            // Set Report Titles
            reportDocument1.SummaryInfo.ReportAuthor = Helpers.Sesion.Usuario.Nombre + " " + Helpers.Sesion.Usuario.Apellidos; //"Operadora de farmacias A.F. del centro S. de R.L.";
            reportDocument1.SummaryInfo.ReportComments = "Alexander Fleming";
            reportDocument1.SummaryInfo.ReportTitle = "Orden Compra";

            //parametros
             // Set Crystal Report Viewer Properties
            crystalReportViewer1.ShowCloseButton = false;
            //crViewer.ShowCopyButton = false;
            crystalReportViewer1.ShowExportButton = false;
            crystalReportViewer1.ShowLogo = false;
            crystalReportViewer1.ShowParameterPanelButton = false;
            crystalReportViewer1.ShowPrintButton = true;
            crystalReportViewer1.SelectionFormula = Param1;
            crystalReportViewer1.ReportSource = reportDocument1;

        
        }
    }
}
