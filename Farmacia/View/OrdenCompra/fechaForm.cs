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
    public partial class fechaForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public fechaForm()
        {
            InitializeComponent();
            dateTimeInput1.Value = DateTime.Now;
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (dateTimeInput1.Value == null)
            {
                MessageBox.Show("Ingrese la fecha por favor");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }



    }
}
