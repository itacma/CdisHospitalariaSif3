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
    public partial class TiempoAireTelcelForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public TiempoAireTelcelForm()
        {
            InitializeComponent();
            this.inicializaTabs();
        }

        public SIFModelo.WebServices.TAE articulo;

        private void inicializaTabs()
        {
            this.telcelTabItem.Tag = 1;
        }

        private bool AgregaArticulo()
        {
            if (this.maskedTextBoxAdv1.Text == "   -   -")
            {
               MessageBox.Show("Ingrese el numero celular", "Tiempo Aire", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                maskedTextBoxAdv1.Focus();
                return false;
            }

            if (maskedTextBoxAdv1.Text.Length > 10)
            {
               MessageBox.Show("Debe ingresar los 10 digitos");
                maskedTextBoxAdv1.Focus();
                return false;
            }

            if (this.maskedTextBoxAdv1.Text != this.maskedTextBoxAdv2.Text)
            {
                maskedTextBoxAdv2.Focus();
               MessageBox.Show("Confirme correctamente el numero celular", "Tiempo Aire", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (this.recargaComboBoxEx.SelectedItem == null)
            {
               MessageBox.Show("Elija el monto del tiempo aire", "Tiempo Aire", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            articulo = new SIFModelo.WebServices.TAE();
            var diccionario = recargaComboBoxEx.SelectedItem.GetType();
            SIFModelo.RemisionDetalle articuloSelecionado = ((KeyValuePair<string, SIFModelo.RemisionDetalle>)recargaComboBoxEx.SelectedItem).Value as SIFModelo.RemisionDetalle;

            articulo.Articulo = articuloSelecionado.ArticuloID;
            articulo.Carrier = int.Parse(articuloSelecionado.Nombre2);
            articulo.Referencia = articuloSelecionado.Nombre1;
            articulo.Telefono = this.maskedTextBoxAdv1.Text;
            articulo.Importe = articuloSelecionado.Precio;
            articulo.Fecha = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            return true;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {

            if (!this.AgregaArticulo())
            {
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        List<SIFModelo.RemisionDetalle> productos = new List<SIFModelo.RemisionDetalle>();
        private void seleccionaProductos()
        {
            SIFModelo.WebServices.Carrier Carrier = new SIFModelo.WebServices.Carrier();
            Carrier.CarrierID = int.Parse(carriersTabControl.SelectedTab.Tag.ToString());
            Carrier.Nombre = carriersTabControl.SelectedTab.Text;
            productos = SIFNegocio.WebServices.TAE.Productos(Carrier, SIFNegocio.Configuracion.Configuraciones.TAE);

            Dictionary<string, SIFModelo.RemisionDetalle> articulos = new Dictionary<string, SIFModelo.RemisionDetalle>();

            foreach (var producto in productos)
            {
                articulos.Add(producto.Nombre1, producto);
            }

            BindingSource tiempoAireBindingSource = new BindingSource();
            tiempoAireBindingSource.DataSource = articulos;
            this.recargaComboBoxEx.DataSource = tiempoAireBindingSource;
            this.recargaComboBoxEx.DisplayMember = "Key";
            this.recargaComboBoxEx.ValueMember = "Value";
        }

        private void TiempoAireForm_Load(object sender, EventArgs e)
        {
            this.seleccionaProductos();
            this.recargaComboBoxEx.SelectedIndex = 0;
            recargaComboBoxEx.Focus();
        }

        private void carriersTabControl_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {
            this.seleccionaProductos();
        }

        private void maskedTextBoxAdv1_Leave(object sender, EventArgs e)
        {
            maskedTextBoxAdv1.PasswordChar = '•';
        }

        private void maskedTextBoxAdv1_Enter(object sender, EventArgs e)
        {
            maskedTextBoxAdv1.PasswordChar = '\0';
        }

        private void TiempoAireTelcelForm_Activated(object sender, EventArgs e)
        
       {
            this.recargaComboBoxEx.Focus();
        }

        private void maskedTextBoxAdv2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.aceptarButtonX_Click(null, null);
            }
        }

        private void maskedTextBoxAdv2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
