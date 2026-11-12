using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.OrdenCompra
{
    public partial class SucursalVirtual : DevComponents.DotNetBar.Metro.MetroForm
    {
        public SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal();
        public SucursalVirtual()
        {
            InitializeComponent();
            CargaSucursalDestino();
        }
       
        //public string sucursal_n { get { return sucursal_n; } }
       
        private void aceptarButtonX_Click(object sender, EventArgs e)
        {

            sucursal = SucursalDestinoComboBox.SelectedItem as SIFModelo.Sucursal;
            if (sucursal.Nombre.Contains("SELECCIONE")) {
                MessageBox.Show("Seleccione la sucursal de destino","Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }
        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }
        private void CargaSucursalDestino()
        {
            BindingList<SIFModelo.Sucursal> sucursales = new BindingList<SIFModelo.Sucursal>();
            //SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { Nombre = "[TODAS]", SucursalesID = 0 };
            //sucursales.Add(sucursal);
            //sucursales.ToList();d
            List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().BuscarAlmacenesMandato("", "S").DataSource as List<SIFModelo.Sucursal>;//L 03/01/2013 PARA QUE SOLO SE MUESTREN LOS ALMACENES ACTIVOS EN SUCURSAL DESTINO

            /// AVM 21-04-2015
            SIFModelo.Sucursal modelSeleccione = new SIFModelo.Sucursal();
            modelSeleccione.Nombre = "SELECCIONE...";
            modelSeleccione.SucursalesID = -1;
            modelSeleccione.SucursalID = -1;

            sucursales.Add(modelSeleccione);
            /// AVM 21-04-2015

            foreach (SIFModelo.Sucursal sucursalBd in sucursalesBD)
            {
                sucursales.Add(sucursalBd);
            }

            SucursalDestinoComboBox.DataSource = sucursales;
            SucursalDestinoComboBox.DisplayMember = "NOMBRE";
            SucursalDestinoComboBox.ValueMember = "SUCURSALESID";
        }

        //private void SucursalDestinoComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        //{
        //    try
        //    {
        //        if (IsType.IsIntegerPositive(SucursalDestinoComboBox.SelectedValue.ToString()))// && !foliotextBoxX.Text.Equals("Nuevo"))
        //            SIFNegocio.Inventario.Traspasos.ActualizarTraspaso(int.Parse(SucursalDestinoComboBox.SelectedValue.ToString()), foliotextBoxX.Text);
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
    }
}
