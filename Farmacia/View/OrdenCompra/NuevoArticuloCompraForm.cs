using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.OrdenCompra
{
    public partial class NuevoArticuloCompraForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public NuevoArticuloCompraForm()
        {
            InitializeComponent();
            articuloLabelX.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (this.Valida())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private bool Valida()
        {
            if (string.IsNullOrEmpty(this.nombreTextBoxX.Text))
            {
               MessageBox.Show("El nombre es obligatorio");
                nombreTextBoxX.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.costoTextBoxX.Text))
            {
               MessageBox.Show("Debe ingresar el costo del producto");
                costoTextBoxX.Focus();
                return false;
            }

            if (!costoTextBoxX.Text.IsFloat())
            {
               MessageBox.Show("El costo no es numérico");
                costoTextBoxX.SelectAll();
                costoTextBoxX.Focus();
                return false;
            }

            return true;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void nombreTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.costoTextBoxX.Focus();
            }

        }

        private void costoTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.aceptarButtonX.PerformClick();
            }
        }
    }
}
