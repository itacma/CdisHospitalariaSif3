using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar;

namespace SIF.View.Ventas
{
    public partial class PedidosUserControl : Templates.ListaUserControl
    {
        public Menu.VentasMenu Owner;
        public Boolean Mostrado = false;
        public PedidosUserControl()
        {
            InitializeComponent();

            this.inicializaTabla();
            Privilegios();
        }
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 3, int.Parse(Xbtn.Tag.ToString()));
            }

        }

        public void inicializaTabla()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            superGridControl1.DataBindingComplete += SuperGridControl1DataBindingComplete;
        }

        void SuperGridControl1DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;

            if (panel.DataMember == "PedidoDetalles")
            {
                CustomizeDetailsPanel(panel);
                for (int i = 6; i < panel.Columns.Count; i++)
                {
                    panel.Columns[i].Visible = false;
                }
            }
            if (panel.DataMember == "Pedidos")
            {
                CustomizeDetailsPanel(panel);
                for (int i = 17; i < panel.Columns.Count; i++)
                {
                    /*if (i == 22 ||  i == 23 )
                        panel.Columns[i].Visible = true;
                    else*/
                        panel.Columns[i].Visible = false;
                }
            }
        }

        private void Cancelar()
        {
            SIFModelo.Pedido Pedido = this.SelectPedido();

            if (Pedido == null)
            {
               MessageBox.Show("Seleccione el Pedido a cancelar");
                return;
            }

            if (Pedido.Activo == SIFModelo.Tipos.SiNo.NO)
            {
               MessageBox.Show("El Pedido fue cancelado anteriormente");
                return;
            }

            //if (!string.IsNullOrEmpty(Pedido.ReferenciaRemisionVenta))
            //{
            //   MessageBox.Show("El Pedido no puede ser cancelado porque fue convertido en remision");
            //    return;
            //}

            if (MessageBoxEx.Show("¿Eliminar el Pedido " + Pedido.NumeroPedido + " ?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            SIFNegocio.Pedidos PedidoL = new SIFNegocio.Pedidos();

           // DatosDerechohabiente motivo = new DatosDerechohabiente();
           // motivo.ShowDialog();

            Pedido.Activo = SIFModelo.Tipos.SiNo.NO;

            if (PedidoL.ActualizaPedido(Pedido))
            {
                SIFNegocio.Inventario.Inventario inventarioL = new SIFNegocio.Inventario.Inventario();
                SIFNegocio.Pedidos remisionL = new SIFNegocio.Pedidos();
                Pedido.Detalles = remisionL.CargaDetalles(Pedido);
                foreach (var detalle in Pedido.Detalles)
                {
                    SIFModelo.Articulo articulo = new SIFModelo.Articulo();
                    articulo.ARTICULO_ID = detalle.ArticuloID;
                    inventarioL.InventarioArticuloApartaCancela(articulo, detalle.CantidadPedido);
                }

                //EN EL DATAGRID PONER COMO CANCELADO
                GridPanel grid = superGridControl1.PrimaryGrid;
                grid.Rows.Remove(grid.ActiveRow);
            }
            else
            {
               MessageBox.Show("No se consiguió cancelar el Pedido");
            }
        }

        private void CustomizeDetailsPanel(GridPanel panel)
        {
            //panel.AutoGenerateColumns = false;
        }

        DataSet DsPedidoes;
        SIFNegocio.Pedidos pedidosL = new SIFNegocio.Pedidos();
        public void Buscar()
        {
            SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { SucursalesID = SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID };
            SIFModelo.Pedido pedido = new SIFModelo.Pedido();
            pedido.NumeroPedido = this.buscarTextBoxX.Text;
            if (creditoRadioButton.Checked)
                DsPedidoes = pedidosL.BuscaPedidosNoGenerados(sucursal, pedido, false, dateTimeInput1.Value, dateTimeInput2.Value);
            else
                DsPedidoes = pedidosL.BuscaPedidosNoGenerados(sucursal, pedido, true, dateTimeInput1.Value, dateTimeInput2.Value);

            DsPedidoes.Relations.Add("1", DsPedidoes.Tables["Pedidos"].Columns["FOLIO"],
                                           DsPedidoes.Tables["PedidoDetalles"].Columns["FOLIO"], false);
            this.superGridControl1.PrimaryGrid.ClearAll();


            this.superGridControl1.PrimaryGrid.DataSource = DsPedidoes;

            superGridControl1.PrimaryGrid.DataMember = "Pedidos";
          
          /*  for (int i = 14; i < this.superGridControl1.PrimaryGrid.Columns.Count; i++)
            {
                if (i == 22 || 1 == 32)
                    this.superGridControl1.PrimaryGrid.Columns[i].Visible = true;
                else
                    this.superGridControl1.PrimaryGrid.Columns[i].Visible = false;
            }*/
           /* for (int i = 0; i < this.superGridControl1.PrimaryGrid.Columns.Count; i++)
            {
                if (i == 22 || 1 == 32)
                    this.superGridControl1.PrimaryGrid.Columns[i].Visible = true;
                else
                    this.superGridControl1.PrimaryGrid. Columns[i].Visible = false;
            }*/
        }

        private SIFModelo.Pedido SelectPedido()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;

            if (panel.ActiveRow == null)
            {
                return null;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Seleccione la cabecera de la Pedido");
                return null;
            }

            var row = (GridRow)container;

            DataRow datarow = ((DataRowView)row.DataItem).Row;
            SIFModelo.Pedido pedido = new SIFModelo.Pedido();
            if (datarow["REF_REMISION_VTA"].ToString().IsFloat())
            {
               MessageBox.Show("ya se realizo la venta");
                return null;
            }
            pedido.SucursalID = int.Parse(datarow["SUCURSAL_ID"].ToString());
            pedido.NumeroPedido = datarow["NUM_PEDIDO"].ToString();
            pedido.TipoClienteID = int.Parse(datarow["TIPO_CLIENTE_ID"].ToString());
            pedido.ClienteID = int.Parse(datarow["CLIENTE_ID"].ToString());
            pedido.FechaPedido = DateTime.Parse(datarow["FECHA_Pedido"].ToString());
            pedido.Receta = (SIFModelo.Tipos.SiNo)(datarow["RECETA"].ToString()[0]);
            pedido.ReferenciaRemisionVenta = datarow["REF_REMISION_VTA"].ToString();
            //Pedido.MedicoID = int.Parse(datarow["ID_MEDICO"].ToString());
            //Pedido.FechaPago = DateTime.Parse(datarow["FECHA_PAGO"].ToString());
            pedido.VendedorID = int.Parse(datarow["VENDEDOR_ID"].ToString());
            pedido.MonedaID = int.Parse(datarow["MONEDA_ID"].ToString());
            pedido.TipoCambioID = int.Parse(datarow["TIPO_CAMBIO_ID"].ToString());
            pedido.NumeroCredencial = datarow["NUM_CREDENCIAL"].ToString();
            //Pedido.Condiciones = (datarow["CONDICIONES"].ToString());
            pedido.SubTotal = decimal.Parse(datarow["SUBTOTAL"].ToString());
            //Pedido.Impuesto = int.Parse(datarow["IMPUESTO_IVA"].ToString());
            pedido.Descuento = decimal.Parse(datarow["DESCUENTO"].ToString());
            pedido.Total = decimal.Parse(datarow["TOTAL"].ToString());
            //Pedido.TotalArticulosRemision = decimal.Parse(datarow["TOTAL_ARTICULOS_REM"].ToString());
            //Pedido.NumeroFactura = (datarow["NUM_FACTURA"].ToString());
            // pedido.TipoPedido = (SIFModelo.Tipos.TipoPedido)(datarow["TIPO_Pedido"].ToString()[0]);
            pedido.Activo = (SIFModelo.Tipos.SiNo)(datarow["ACTIVO"].ToString()[0]);
            pedido.ImporteLetra = datarow["IMPORTE_LETRA"].ToString();
            pedido.Factura = (SIFModelo.Tipos.SiNo)(datarow["FACTURA"].ToString()[0]);
            pedido.TipoPagoID = int.Parse(datarow["TIPO_PAGO_ID"].ToString());
            pedido.TotalPago = decimal.Parse(datarow["TOTAL_PAGO"].ToString());
            pedido.Comentario = datarow["comentario"].ToString();
            //Pedido.Comentarios = datarow["COMENTARIOS"].ToString();
            ////Pedido.NumeroPedido = datarow["NUM_Pedido"].ToString();
            //Pedido.BeneficioProveedor = (SIFModelo.Tipos.SiNo)datarow["BENEFICIO_PROV"].ToString()[0];
            //Pedido.ImpuestoIVA = decimal.Parse( datarow["IMPUESTO_IVA"].ToString());
            return pedido;


        }

        #region Navegacion
        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);

        }

        /// <summary>
        /// Activa los acesos cortos mediante el teclado
        /// </summary>
        private void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
        }

        public void Back()
        {
            try
            {
                if (this.Mostrado && Owner.Owner.IsModalPanelDisplayed)
                {
                    this.DesactivaComandos();
                    this.Owner.ActivaComandos();
                    this.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = false;
                }
            }
            catch { }
        }

        public void Navega()
        {
            this.Owner.Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.Mostrado = true;
            this.dateTimeInput1.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, 0, 0, 0);
            this.dateTimeInput2.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, 23, 59, 59);
            this.Buscar();
        }

        #endregion


        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            View.Ventas.CotizacionUserControl frmcotizacion = new CotizacionUserControl();
            frmcotizacion.Dock = DockStyle.Fill;
            frmcotizacion.Owner = this.Owner;

            frmcotizacion.Cual = 1;
            this.DesactivaComandos();
            this.Owner.Owner.ShowModalPanel(frmcotizacion, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }

        private void cotizacionsUserControl_Load(object sender, EventArgs e)
        {
            //this.Buscar();
        }

        private void salirButtonItem_Click(object sender, EventArgs e)
        {
            SIFModelo.Pedido pedido = this.SelectPedido();

            if (pedido == null)
            {
               MessageBox.Show("Seleccione un Pedido");
                return;
            }

            if (pedido.Activo == SIFModelo.Tipos.SiNo.NO)
            {
               MessageBox.Show("El Pedido ya no esta activo");
                return;
            }
            if (pedido.ReferenciaRemisionVenta != "")
            {
               MessageBox.Show("El Pedido ya fue remisionado");
                return;
            }


            if (pedido.FechaPedido.AddHours(-24) > SIFNegocio.Configuracion.Configuraciones.fechaServidor())
            {
               MessageBox.Show("El pedido ha caducado 24 horas");
                return;
            }


            if(pedido.SucursalID != SIFNegocio.Helpers.Sesion.Sucursal.SucursalID)
            {
               MessageBox.Show("No puedes convertir en venta un Pedido de otra sucursal");
                return;
            }

            pedido.Detalles = pedidosL.CargaDetalles(pedido);

            Ventas.VentaPedidoUserControl frmVenta = new VentaPedidoUserControl();
            frmVenta.convertidaDe = pedido;
            frmVenta.Owner1 = this;
            frmVenta.Owner = this.Owner.Owner;
            frmVenta.Muestra();


        }

        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void buscarTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Buscar();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
            }
        }

        private void cancelarButtonItem_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void PedidosUserControl_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void creditoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void contadoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }
        }

    }
}
