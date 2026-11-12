using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Catalogos
{
    public partial class UsuarioIDForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public UsuarioIDForm()
        {
            InitializeComponent();
        }

        private bool Aceptar()
        {
            if (string.IsNullOrEmpty(this.textBoxX1.Text) || string.IsNullOrWhiteSpace(this.textBoxX1.Text))
            {
               MessageBox.Show("El Usuario ID es obligatorio");
                return false;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();


            return true;
        }

        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Aceptar();
            }
        }

        private void cancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void AceptarButtonX_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void textBoxX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Aceptar();
            }
        }

        private void UsuarioIDForm_Load(object sender, EventArgs e)
        {
            this.textBoxX1.Focus();
        }
    }
}
