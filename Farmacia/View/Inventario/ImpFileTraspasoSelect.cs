using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Inventario
{
    public partial class ImpFileTraspasoSelect : DevComponents.DotNetBar.Metro.MetroForm
    {
        public static string sucursalD = string.Empty;
        public static int  motivoPedido ;
        public ImpFileTraspasoSelect()
        {
            InitializeComponent();
        }

        private void ImpFileTraspasoSelect_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cargaSucursales();
            this.cargaTipoPedido();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ALMACEN GENERAL")
            {
                MessageBox.Show("Seleccione una sucursal diferente  ");
                
            }
            if (cbxTipoPedido.SelectedIndex <= 0)
            {
                MessageBox.Show("Seleccione un tipo de Pedido");
                
            }
            else
            {
                System.Reflection.PropertyInfo pi = cbxTipoPedido.SelectedItem.GetType().GetProperty("ID");
                Int32 idMotivoT = (Int32)(pi.GetValue(cbxTipoPedido.SelectedItem, null));
                motivoPedido = idMotivoT;
                sucursalD = comboBox1.SelectedValue.ToString();

                this.DialogResult = DialogResult.OK;

            }
            
        }
        private Boolean seleccionSuc() {
            this.cargaSucursales();
            return false;

        }

        private void cargaSucursales() {
         
            SIFNegocio.Sucursales sucursales = new SIFNegocio.Sucursales();
            //List<SIFModelo.Sucursal> sucursalesList = sucursales.Buscar("", "").DataSource as List<SIFModelo.Sucursal>;
            List<SIFModelo.Sucursal> sucursalesList = sucursales.BuscarAlmacenesNoVirtuales().DataSource as List<SIFModelo.Sucursal>;

            if (sucursalesList == null)
            {
                sucursalesList = new List<SIFModelo.Sucursal>();
            }

            if (sucursalesList.Count > 0)
            {
                this.comboBox1.DataSource = sucursalesList;

                comboBox1.ValueMember = "SucursalesID";
                comboBox1.DisplayMember = "Nombre";
            }
        
        }
        private void cargaTipoPedido()
        {
            
            SIFNegocio.Inventario.Traspasos Bt = new SIFNegocio.Inventario.Traspasos();
            BindingSource catTipoPedido = new BindingSource();
            catTipoPedido.DataSource = Bt.buscarTipoPedido().DataSource;
            cbxTipoPedido.DataSource = catTipoPedido;
            cbxTipoPedido.DisplayMember = "NOMBRE";
            cbxTipoPedido.SelectedIndex = 0;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private static bool validaSelect() {
            
            

            return  true;
        }
        
    }
}
