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
    public partial class AgregaArticuloInvFisForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public AgregaArticuloInvFisForm()
        {
            InitializeComponent();
        }

        private void cancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        public SIFModelo.Articulo Articulo { get; set; }
        public int Conteo { get; set; }

        private bool valida()
        {
            if (string.IsNullOrEmpty(this.codigoTextBoxX.Text))
            {
               MessageBox.Show("El código del artículo es obligatorio");
                codigoTextBoxX.Focus();
                return false;
            }

            if (!conteoTextBoxX.Text.IsInteger())
            {
               MessageBox.Show("Debe especificar un número para el conteo");
                conteoTextBoxX.SelectAll();
                conteoTextBoxX.Focus();
                return false;
            }

            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            this.Articulo = articuloL.BuscarPorClave(this.codigoTextBoxX.Text);

            if (Articulo == null)
            {
               MessageBox.Show("El artículo no fue encontrado en el catálogo");
                return false;
            }

            this.Conteo = System.Convert.ToInt32(conteoTextBoxX.Text);

            return true;
        }

        private void AceptarButtonX_Click(object sender, EventArgs e)
        {
            if (valida())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}