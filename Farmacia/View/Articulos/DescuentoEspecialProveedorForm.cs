using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Articulos
{
    public partial class DescuentoEspecialProveedorForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public DescuentoEspecialProveedorForm()
        {
            InitializeComponent();
        }

        public double descuento = 0;

        private void Aceptar()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.descuento = descuentoDoubleInput.Value;
            this.Close();
        }

        private void DescuentoEspecialProveedorForm_Load(object sender, EventArgs e)
        {
            descuentoDoubleInput.Focus();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void descuentoDoubleInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Aceptar();
            }
        }
    }
}
