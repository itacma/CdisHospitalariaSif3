using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Ventas
{
    public partial class ImporteApartadoUser : DevComponents.DotNetBar.Metro.MetroForm
    {
        public decimal Importe;
        public ImporteApartadoUser()
        {
            InitializeComponent();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (ImporteTextBoxX.Text.IsFloat())
            {
                Decimal.TryParse(ImporteTextBoxX.Text,out Importe);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
               MessageBox.Show("El importe debe ser numerico");
                return;
            }

        }

        private void CancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}