using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View
{
    public partial class ImportarPedidoMotivoSelect : Form
    {
        public ImportarPedidoMotivoSelect()
        {
            InitializeComponent();
            cargarMotivoPedido();
            validaSiEsAlmacen50();
        }

        //motivo del pedido
        public SIFModelo.MotivoPedido MotivoPedidoModel = new SIFModelo.MotivoPedido();
        public String Referencia = "";

        private void validaSiEsAlmacen50()
        {
            //throw new NotImplementedException();
        }

        private void cargarMotivoPedido()
        {
            List<SIFModelo.MotivoPedido> MotivoPedido_List = new List<SIFModelo.MotivoPedido>();

            SIFNegocio.MotivoPedido MotivoPedidoN = new SIFNegocio.MotivoPedido();
            SIFModelo.MotivoPedido MotivoPedidoM = new SIFModelo.MotivoPedido();
            MotivoPedidoM.ID = 0;
            MotivoPedidoM.NOMBRE = "SELECCIONE...";

            foreach (var item in MotivoPedidoN.Buscar())
            {
                if (MotivoPedido_List.Count == 0)
                    MotivoPedido_List.Add(MotivoPedidoM);

                MotivoPedido_List.Add(item);
            }

            cmbTipoPedido.DataSource = MotivoPedido_List;
            cmbTipoPedido.DisplayMember = "NOMBRE";
            cmbTipoPedido.ValueMember = "ID";
            
        }

        private void ImportarPedidoMotivoSelect_Load(object sender, EventArgs e)
        {
            if (Helpers.Sesion.Sucursal.SucursalesID == 13)
            {
                //almacen50 = true;
                lblReferencia.Visible = true;
                cmbTipoPedido.Visible = true;
                cmbTipoPedido.Enabled = true;
                this.Width = 340;
                this.Height = 189;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbTipoPedido.SelectedIndex > 0)
            {
                //return true;
                this.MotivoPedidoModel = cmbTipoPedido.SelectedItem as SIFModelo.MotivoPedido;
                this.Referencia = txtReferencia.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cmbTipoPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            SIFModelo.MotivoPedido MotivoPedidoModel = cmbTipoPedido.SelectedItem as SIFModelo.MotivoPedido;

            DateTime toDay = DateTime.Now;
            if (SIFNegocio.Pedidos.PedidosLimiteHoy(toDay.ToString("dd/MM/yy"), MotivoPedidoModel))
            {
                    MessageBox.Show("Se ha alcanzado el número máximo de pedidos (" + MotivoPedidoModel.CANTIDAD_PEDIDO_MAX_DIA +
                                    "). Segun el tipo de pedido: " + MotivoPedidoModel.NOMBRE);
                    cmbTipoPedido.SelectedIndex = 0;
            }  
        }
    }
}
