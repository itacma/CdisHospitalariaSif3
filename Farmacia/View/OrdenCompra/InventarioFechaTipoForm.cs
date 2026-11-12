using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.OrdenCompra
{
    public partial class InventarioFechaTipoForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public InventarioFechaTipoForm()
        {
            InitializeComponent();
            this.dateTimeInput1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.dateTimeInput2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            llenaConceptoAjuste();
        }

        private void llenaConceptoAjuste()
        {
            this.tb_DescConceptoAjuste.DataSource = new SIFNegocio.TipoDevolucions().BuscarCompras();
            tb_DescConceptoAjuste.ValueMember = "TipoDevolucionID";
            tb_DescConceptoAjuste.DisplayMember = "Nombre";
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult =
                 System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
