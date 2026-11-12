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
    public partial class NumeroValeDevolucionForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public NumeroValeDevolucionForm()
        {
            InitializeComponent();
            CargaSucursales();
        }

        private bool valida()
        {
            if (string.IsNullOrEmpty(numeroValeTextBoxX.Text))
            {
               MessageBox.Show("Debe ingresar el numero de vale de devolución");
                
                this.numeroValeTextBoxX.Focus();
                return false;
            }

            if (this.sucursalComboBoxEx.SelectedItem == null)
            {
               MessageBox.Show("Indique la sucursal donde se realizó la venta");
                sucursalComboBoxEx.Focus();
                sucursalComboBoxEx.DroppedDown = true;
                return false;
            }

            return true;
        }

        private void CargaSucursales()
        {
            SIFNegocio.Sucursales sucursalL = new SIFNegocio.Sucursales();
            this.sucursalComboBoxEx.DataSource = sucursalL.Buscar("", "").DataSource;
            sucursalComboBoxEx.DisplayMember = "Nombre";
            sucursalComboBoxEx.ValueMember = "SucursalesID";
            sucursalComboBoxEx.SelectedIndex = 0;
        }


        public string ValeDevolucion;
        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (this.valida())
            {
                ValeDevolucion = numeroValeTextBoxX.Text;
                this._sucursal = sucursalComboBoxEx.SelectedItem as SIFModelo.Sucursal;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void NumeroValeDevolucionForm_Load(object sender, EventArgs e)
        {
            this.numeroValeTextBoxX.Focus();
        }


        private SIFModelo.Sucursal _sucursal;
        public SIFModelo.Sucursal Sucursal { get{return _sucursal;} }

        private void sucursalComboBoxEx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.aceptarButtonX_Click(null, null);
            }
        }

        private void numeroValeTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sucursalComboBoxEx.Focus();
            }
        }

        private void cancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
