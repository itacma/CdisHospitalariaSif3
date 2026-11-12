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
    public partial class ApartadosUserControl : Templates.ListaUserControl
    {
        public Menu.VentasMenu Owner;
        public Boolean Mostrado = false;
        public ApartadosUserControl()
        {
            InitializeComponent();
            this.inicializaTabla();
            Privilegios();
            dateTimeInput1.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, 0, 0, 0);
            dateTimeInput2.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, 23, 59, 59);
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 4, int.Parse(Xbtn.Tag.ToString()));
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

            if (panel.DataMember == "ApartadoDetalle")
            {
                CustomizeDetailsPanel(panel);
                for (int i = 6; i < panel.Columns.Count; i++)
                {
                    panel.Columns[i].Visible = false;
                }
            }
            if (panel.DataMember == "Apartado")
            {
                CustomizeDetailsPanel(panel);
                for (int i = 11; i < panel.Columns.Count; i++)
                {
                    panel.Columns[i].Visible = false;
                }
            }
        }

        private void Cancelar()
        {
            SIFModelo.Apartado apartado = this.SelectedApartado();

            if (apartado == null)
            {
               MessageBox.Show("Seleccione el apartado a cancelar");
                return;
            }

            if (apartado.Activo == SIFModelo.Tipos.SiNo.NO)
            {
               MessageBox.Show("El apartado fue cancelado anteriormente");
                return;
            }

            //if (!string.IsNullOrEmpty(cotizacion.ReferenciaRemisionVenta))
            //{
            //   MessageBox.Show("El cotizacion no puede ser cancelado porque fue convertido en remision");
            //    return;
            //}

            if (MessageBoxEx.Show("¿Eliminar el apartado " + apartado.NumeroApartado + " ?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            SIFNegocio.Apartado Apartado = new SIFNegocio.Apartado();

            //DatosDerechohabiente motivo = new DatosDerechohabiente();
            //motivo.ShowDialog();

            apartado.Activo = SIFModelo.Tipos.SiNo.NO;

            if (Apartado.ActualizaApartado(apartado))
            {
                if (apartado.Anticipo == 0)
                {
                    SIFNegocio.Inventario.Inventario inventarioL = new SIFNegocio.Inventario.Inventario();
                    SIFNegocio.Apartado remisionL = new SIFNegocio.Apartado();
                    apartado.Detalles = remisionL.CargaDetalles(apartado);
                    foreach (var detalle in apartado.Detalles)
                    {
                        SIFModelo.Articulo articulo = new SIFModelo.Articulo();
                        articulo.ARTICULO_ID = detalle.ArticuloID;
                        inventarioL.InventarioArticuloApartaCancela(articulo, detalle.CantidadApartado);
                    }
                }
                //EN EL DATAGRID PONER COMO CANCELADO
                GridPanel grid = superGridControl1.PrimaryGrid;
                grid.Rows.Remove(grid.ActiveRow);
            }
            else
            {
               MessageBox.Show("No se consiguió cancelar el apartado");
            }
        }

        private void CustomizeDetailsPanel(GridPanel panel)
        {
            panel.AutoGenerateColumns = true;


        }

        DataSet DsApartados;
        SIFNegocio.Apartado ApartadosL = new SIFNegocio.Apartado();
        public void Buscar()
        {
            SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { SucursalesID = SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID };
            SIFModelo.Apartado Apartado = new SIFModelo.Apartado();
            Apartado.NumeroApartado = this.buscarTextBoxX.Text;
            //if (contadoRadioButton.Checked)
            DsApartados = ApartadosL.BuscaApartado(sucursal, Apartado, contadoRadioButton.Checked, dateTimeInput1.Value, dateTimeInput2.Value);
            //else
            //    DsApartados = ApartadosL.BuscaApartado(sucursal, Apartado,false);

            DsApartados.Relations.Add("1", DsApartados.Tables["Apartado"].Columns["FOLIO"],
                                           DsApartados.Tables["ApartadoDetalle"].Columns["FOLIO"], false);

            //this.bindingSource.DataSource = DsRemisiones;
            this.superGridControl1.PrimaryGrid.DataSource = DsApartados;
            superGridControl1.PrimaryGrid.DataMember = "Apartado";
        }

        private SIFModelo.Apartado SelectedApartado()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;

            if (panel.ActiveRow == null)
            {
                return null;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
                //MessageBox.Show("Seleccione la cabecera de la cotizacion");
                return null;
            }
            var row = (GridRow)container;

            DataRow datarow = ((DataRowView)row.DataItem).Row;
            SIFModelo.Apartado Apartado = new SIFModelo.Apartado();
            Apartado.SucursalID = int.Parse(datarow["SUCURSAL_ID"].ToString());
            Apartado.NumeroApartado = datarow["NUM_APARTADO"].ToString();
            Apartado.TipoClienteID = int.Parse(datarow["TIPO_CLIENTE_ID"].ToString());
            Apartado.ClienteID = int.Parse(datarow["CLIENTE_ID"].ToString());
            Apartado.FechaApartado = DateTime.Parse(datarow["FECHA_APARTADO"].ToString());
            Apartado.Receta = (SIFModelo.Tipos.SiNo)(datarow["RECETA"].ToString()[0]);
            Apartado.MedicoID = int.Parse(datarow["ID_MEDICO"].ToString());
            //cotizacion.FechaPago = DateTime.Parse(datarow["FECHA_PAGO"].ToString());
            Apartado.VendedorID = int.Parse(datarow["VENDEDOR_ID"].ToString());
            Apartado.MonedaID = int.Parse(datarow["MONEDA_ID"].ToString());
            Apartado.TipoCambioID = int.Parse(datarow["TIPO_CAMBIO_ID"].ToString());
            Apartado.NumeroCredencial = datarow["NUM_CREDENCIAL"].ToString();
            //cotizacion.Condiciones = (datarow["CONDICIONES"].ToString());
            Apartado.SubTotal = decimal.Parse(datarow["SUBTOTAL"].ToString());
            Apartado.ImpuestoIVA = decimal.Parse(datarow["IMPUESTO_IVA"].ToString());
            Apartado.Descuento = decimal.Parse(datarow["DESCUENTO"].ToString());
            Apartado.Total = decimal.Parse(datarow["TOTAL"].ToString());
            //Apartado.PorcentajeDescuento = decimal.Parse(datarow["DESCUENTO"].ToString());
            //cotizacion.TotalArticulosRemision = decimal.Parse(datarow["TOTAL_ARTICULOS_REM"].ToString());
            //cotizacion.NumeroFactura = (datarow["NUM_FACTURA"].ToString());
            //Apartado.TipoCotizacion = (SIFModelo.Tipos.TipoCotizacion)(datarow["TIPO_COTIZACION"].ToString()[0]);
            Apartado.Activo = (SIFModelo.Tipos.SiNo)(datarow["ACTIVO"].ToString()[0]);
            Apartado.ImporteLetra = datarow["IMPORTE_LETRA"].ToString();
            Apartado.Factura = (SIFModelo.Tipos.SiNo)(datarow["FACTURA"].ToString()[0]);
            Apartado.Anticipo = decimal.Parse(datarow["ANTICIPO_APART"].ToString());
            Apartado.Comentario = datarow["comentario"].ToString();
            //cotizacion.Comentarios = datarow["COMENTARIOS"].ToString();
            ////cotizacion.Numerocotizacion = datarow["NUM_cotizacion"].ToString();
            //cotizacion.BeneficioProveedor = (SIFModelo.Tipos.SiNo)datarow["BENEFICIO_PROV"].ToString()[0];
            return Apartado;


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
            if (this.Mostrado && Owner.Owner.IsModalPanelDisplayed)
            {
                this.DesactivaComandos();
                this.Owner.ActivaComandos();
                this.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = false;
            }
        }

        public void Navega()
        {
            this.Owner.Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.Mostrado = true;
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
            this.DesactivaComandos();
            if (Owner.Owner.Contains(this))
            {
                this.Owner.Owner.ShowModalPanel(frmcotizacion, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            }
        }

        private void cotizacionsUserControl_Load(object sender, EventArgs e)
        {
            //this.Buscar();
        }

        private void salirButtonItem_Click(object sender, EventArgs e)
        {
            SIFModelo.Apartado Apartado = this.SelectedApartado();

            if (Apartado == null)
            {
               MessageBox.Show("Seleccione un apartado");
                return;
            }

            if (Apartado.Activo == SIFModelo.Tipos.SiNo.NO)
            {
               MessageBox.Show("El apartado ya no esta activo");
                return;
            }

            //if (Apartado.TipoCotizacion == SIFModelo.Tipos.TipoCotizacion.VENTA)
            //{
            //    if (Apartado.FechaApartado.AddHours(-24) > SIFNegocio.Configuracion.Configuraciones.fechaServidor())
            //    {
            //       MessageBox.Show("El Apartado ha caducado 24 horas");
            //        return;
            //    }
            //}
            //if (Apartado.TipoCotizacion == SIFModelo.Tipos.TipoCotizacion.CONVENIO)
            //{
            //    if (Apartado.FechaApartado.AddDays(-30) > SIFNegocio.Configuracion.Configuraciones.fechaServidor())
            //    {
            //       MessageBox.Show("El Apartado ha caducado 30 días");
            //        return;
            //    }
            //}

            Apartado.Detalles = ApartadosL.CargaDetalles(Apartado);

            Ventas.VentaPedidoUserControl frmVenta = new VentaPedidoUserControl();
            frmVenta.convertidaDe = Apartado;

            frmVenta.Owner = this.Owner.Owner;
            frmVenta.Owner1 = this;

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

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }
        }

        private void imprimirButtonItem_Click(object sender, EventArgs e)
        {
            SIFModelo.Apartado Apartado = this.SelectedApartado();

            if (Apartado == null)
            {
               MessageBox.Show("Seleccione un apartado");
                return;
            }

            List<SIFModelo.ApartadoDetalle> detalles = ApartadosL.CargaApartadosDetalles(Apartado);
            SIFModelo.Usuario vendedor = new SIFNegocio.Usuarios().UsuarioPorId(Apartado.VendedorID);
            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(Apartado.ClienteID);
            SIFNegocio.Remision.ImprimeTicketApartadoEPedido(Apartado, detalles, Helpers.Sesion.Sucursal, vendedor, cliente);
        }

    }
}
