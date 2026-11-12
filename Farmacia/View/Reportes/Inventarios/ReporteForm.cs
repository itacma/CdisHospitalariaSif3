using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Reportes.Inventarios
{
    public partial class ReporteForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        
        public ReporteForm(SIFModelo.Inventarios.InventarioDataSet Datos, int Cual)
        {
            InitializeComponent();
            this.CargaReporte(Datos,Cual);
        }



        private void CargaReporte(SIFModelo.Inventarios.InventarioDataSet Datos, int Cual)
        {   switch (Cual)
            { 
                case 0:
                    crystalReportViewer1.ReportSource=pedidoAlmacenCrystalReport1;
                    pedidoAlmacenCrystalReport1.SetDataSource(Datos);
                    break;
                case 1:
                    crystalReportViewer1.ReportSource = recepcionAlmacenCrystalReport1;
                    recepcionAlmacenCrystalReport1.SetDataSource(Datos);
                    break;
            }
            

        }
    }
}
