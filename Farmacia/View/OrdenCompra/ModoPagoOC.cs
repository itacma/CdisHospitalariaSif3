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
    public partial class ModoPagoOC : DevComponents.DotNetBar.Metro.MetroForm
    {
        public SIFModelo.OrdenCompra.ModoPago MP = new SIFModelo.OrdenCompra.ModoPago();
        public ModoPagoOC()
        {
            InitializeComponent();
            CargaObetenerModosdePago();
        }
       
        //public string sucursal_n { get { return sucursal_n; } }
       
        private void aceptarButtonX_Click(object sender, EventArgs e)
        {

            MP = ModosdePagoOCComboBox.SelectedItem as SIFModelo.OrdenCompra.ModoPago;
            if (MP.nombre.Contains("Seleccione la opción...")) {
                MessageBox.Show("Seleccione el modo de pago","Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void CargaObetenerModosdePago()
        {
            BindingList<SIFModelo.OrdenCompra.ModoPago> Pagos = new BindingList<SIFModelo.OrdenCompra.ModoPago>();
            List<SIFModelo.OrdenCompra.ModoPago> modoBD = new SIFNegocio.OrdenCompra.Compras().ObtenerModosdePago().DataSource as List<SIFModelo.OrdenCompra.ModoPago>;

            SIFModelo.OrdenCompra.ModoPago modelSeleccione = new SIFModelo.OrdenCompra.ModoPago();
            modelSeleccione.nombre = "Seleccione la opción...";
            modelSeleccione.modo_pago_id = -1;
            modelSeleccione.estado = "S";

            Pagos.Add(modelSeleccione);
            /// AVM 21-04-2015

            foreach (SIFModelo.OrdenCompra.ModoPago modo in modoBD)
            {
                Pagos.Add(modo);
            }

            ModosdePagoOCComboBox.DataSource = Pagos;
            ModosdePagoOCComboBox.DisplayMember = "NOMBRE";
            ModosdePagoOCComboBox.ValueMember = "MODO_PAGO_ID";
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
