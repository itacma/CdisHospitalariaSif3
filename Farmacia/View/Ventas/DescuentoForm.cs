using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Ventas
{
    public partial class DescuentoForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public DescuentoForm()
        {
            InitializeComponent();
            this.cargaDescuentos();
        }

        public string BeneficioProveedor;
        public decimal DescuentoProveedor;
        public string TarjetaID;
        public int DescuentoID;

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargaDescuentos()
        {
            BindingSource src = new BindingSource();
            src.DataSource = new SIFNegocio.Descuentos().Buscar("", "").DataSource;

            this.beneficioComboBoxEx.DataSource = src;

            beneficioComboBoxEx.DisplayMember = "Nombre";
            beneficioComboBoxEx.ValueMember = "Porcentaje";
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(this.folioCredencialTextBoxX.Text))
            {
               MessageBox.Show("Ingrese el Numero de Credencial");
                this.folioCredencialTextBoxX.Focus();
                return;
            }

            SIFModelo.Descuento descuento = ((SIFModelo.Descuento)beneficioComboBoxEx.SelectedItem);
            this.BeneficioProveedor = descuento.Nombre.ToString();
            this.DescuentoID = descuento.ID;
            this.DescuentoProveedor = decimal.Parse(beneficioComboBoxEx.SelectedValue.ToString());
            this.TarjetaID = folioCredencialTextBoxX.Text;

            // throw new NotImplementedException("FALTA VALIDAR SI LA CREDENCIAL ES CORRECTA");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void DescuentoForm_Load(object sender, EventArgs e)
        {
            this.beneficioComboBoxEx.SelectedIndex = 0;
        }

        private void beneficioComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (beneficioComboBoxEx.SelectedItem == null)
            {
                return;
            }
            SIFModelo.Descuento descuento = beneficioComboBoxEx.SelectedItem as SIFModelo.Descuento;
            this.DescuentoProveedor = descuento.Porcentaje;
            this.BeneficioProveedor = descuento.Nombre;

            porcentajeLabelX.Text = descuento.Porcentaje.ToString("#.00");
            porcentajeLabelX.Text = "%" + porcentajeLabelX.Text;

        }

        private void folioCredencialTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.aceptarButtonX_Click(null, null);
            }
        }
    }
}
