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
    public partial class NadroForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public NadroForm()
        {
            InitializeComponent();
        }

        private bool Valida()
        {
            if (string.IsNullOrWhiteSpace(this.numeroTarjetaTextBoxX.Text))
            {
               MessageBox.Show("Ingrese el número de tarjeta");
                this.numeroTarjetaTextBoxX.Focus();
                return false;
            }
            return true;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void PfizerForm_Load(object sender, EventArgs e)
        {
            this.numeroTarjetaTextBoxX.Focus();
#if DEBUG
            this.numeroTarjetaTextBoxX.Text = "9981213621415";
#endif
        }

        private string tarjetaID;
        public string TarjetaID { get { return tarjetaID; } }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (this.Valida())
            {
                this.tarjetaID = numeroTarjetaTextBoxX.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}