using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Reportes.Venta
{
    public partial class CorteCajaForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public CorteCajaForm(SIFModelo.Ventas.CorteCajaDataSet dsCorteCaja)
        {
            this.dsCorteCaja = dsCorteCaja;
            InitializeComponent();
        }

        SIFModelo.Ventas.CorteCajaDataSet dsCorteCaja;
        private void CorteCajaCrystalReport1_InitReport(object sender, EventArgs e)
        {
            SIFModelo.Configuracion.Aplicacion configuracion = new SIFModelo.Configuracion.Aplicacion();
            configuracion.DirectorioReportes = SIFNegocio.Configuracion.Configuraciones.Aplicacion.DirectorioReportes;
            try
            {
                this.reportDocument1.Load(configuracion.DirectorioReportes + @"\CorteDeCaja.rpt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.crystalReportViewer1.ReportSource = reportDocument1;
            //this.reportDocument1.SetDataSource(dsCorteCaja);
            //crystalReportViewer1.ReportSource = pedidoAlmacenCrystalReport1;
            //dsCorteCaja.RECOLECCION_NOMBREColumn.ColumnName = "RECOLECCION";
            //dsCorteCaja.DENOMINACIONColumn.ColumnName = "BILLETE";
            //dsCorteCaja.ACTIVOColumn.ColumnName = "STATUS";

            this.reportDocument1.SetDataSource(dsCorteCaja);
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            CorteCajaCrystalReport1_InitReport(null, null);
        }
    }
}
