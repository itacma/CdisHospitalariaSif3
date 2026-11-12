using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Catalogos
{
    public partial class ClaveArticuloForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ClaveArticuloForm()
        {
            InitializeComponent();
        }

        private bool Aceptar()
        {
            if (string.IsNullOrEmpty(this.claveTextBoxX.Text) || string.IsNullOrWhiteSpace(claveTextBoxX.Text))
            {
               MessageBox.Show("Ingrese la clave del producto");
                this.claveTextBoxX.SelectAll();
                this.claveTextBoxX.Focus();
                return false;
            }
            this.clave = claveTextBoxX.Text;
            
            this.DialogResult = System.Windows.Forms.DialogResult.OK; 
                 this.Close();
            return true;
        }

        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (this.Aceptar())
                {
                    this.clave = claveTextBoxX.Text;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        private string clave;
        public string Clave { get { return clave.ToUpper(); } }

        private void AceptarButtonX_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void cancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void ClaveArticuloForm_Load(object sender, EventArgs e)
        {

        }
    }
}