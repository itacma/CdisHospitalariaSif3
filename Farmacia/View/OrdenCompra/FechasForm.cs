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
    public partial class FechasForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FechasForm()
        {
            InitializeComponent();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (this.dateTimeInput1.Value == null)
            {
                return;
            }

            if (this.dateTimeInput2.Value == null)
            {
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
