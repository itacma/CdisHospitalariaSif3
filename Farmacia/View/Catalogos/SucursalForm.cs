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
    public partial class SucursalForm : DevComponents.DotNetBar.Metro.MetroForm 
    {
        public SucursalForm()
        {
            InitializeComponent();
            this.CargaSucursales();
        }

        private void CargaSucursales()
        {
            SIFNegocio.Sucursales sucursalN = new SIFNegocio.Sucursales();
            BindingSource src = new BindingSource();
            src.DataSource = sucursalN.Buscar("","").DataSource;
            this.sucursalComboBoxEx.DataSource = src;
            sucursalComboBoxEx.DisplayMember = "Nombre";
            sucursalComboBoxEx.ValueMember = "SucursalesID";

        }

        private bool validaSucursal()
        {
            if (this.sucursalComboBoxEx.SelectedItem == null)
            {
               MessageBox.Show("Elija una sucursal");
                this.sucursalComboBoxEx.Focus();

                return false;
            }

            this.sucursal = sucursalComboBoxEx.SelectedItem as SIFModelo.Sucursal;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

            return true;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }



        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            this.validaSucursal();
        }

        private void SucursalForm_Load(object sender, EventArgs e)
        {
            this.sucursalComboBoxEx.Focus();
        }

        private SIFModelo.Sucursal sucursal;
        public SIFModelo.Sucursal Sucursal { get{return sucursal;}}
    }
}
