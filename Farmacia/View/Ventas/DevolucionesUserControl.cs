using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Equin.ApplicationFramework;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;

namespace SIF.View.Ventas
{
    public partial class DevolucionesUserControl : Templates.ListaUserControl
    {
        public DevolucionesUserControl()
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
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 5, int.Parse(Xbtn.Tag.ToString()));
            }

        }

        SIFNegocio.Remision remsionL = new SIFNegocio.Remision();

        private void Back()
        {
            try
            {
                if (this.Mostrado && Owner.Owner.IsModalPanelDisplayed)
                {
                    //this.DesactivaComandos();
                    try
                    {
                        if (Owner.Owner.Contains(this))
                        {
                            Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        this.Owner.ActivaComandos();
                        this.Mostrado = false;
                        this.DesactivaCommandos();
                    }
                    catch
                    {

                    }
                }
            }
            catch { }
        }

        public void inicializaTabla()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            superGridControl1.DataBindingComplete += SuperGridControl1DataBindingComplete;
        }

        void SuperGridControl1DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;

            if (panel.DataMember == "RemisionDetalles")
            {
                CustomizeDetailsPanel(panel);
            }
            //switch (panel.DataMember)
            //{
            //    case "Customers":
            //        CustomizeCustomerPanel(panel);
            //        break;

            //    case "Orders":
            //        CustomizeOrdersPanel(panel);
            //        break;

            //    case "Order Details":
            //        CustomizeDetailsPanel(panel);
            //        break;
            //}
        }

        private void CustomizeDetailsPanel(GridPanel panel)
        {
            //panel.ColumnHeader.RowHeight = 30;

            //panel.Columns[0].CellStyles.Default.Background =
            //    new Background(Color.LavenderBlush);

            //panel.Columns["OrderID"].CellStyles.Default.Alignment = Alignment.MiddleLeft;

            //panel.DefaultVisualStyles.CaptionStyles.Default.Alignment = Alignment.MiddleLeft;
            //panel.DefaultVisualStyles.CellStyles.Default.Alignment = Alignment.MiddleRight;

            //UpdateDetailsFooter(panel);

            panel.AutoGenerateColumns = false;
            panel.Columns.Clear();

            GridColumn SucursalIDColumn = new GridColumn("SucursalIDColumn");
            SucursalIDColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            SucursalIDColumn.HeaderText = "SUCURSAL_ID";
            SucursalIDColumn.DataPropertyName = "SUCURSAL_ID";
            SucursalIDColumn.Width = 70;
            SucursalIDColumn.Visible = false;
            panel.Columns.Add(SucursalIDColumn);

            GridColumn NumRemisionColumn = new GridColumn("NumRemisionColumn");
            NumRemisionColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            NumRemisionColumn.HeaderText = "REMISION";
            NumRemisionColumn.DataPropertyName = "NUM_REMISION";
            NumRemisionColumn.Width = 100;
            NumRemisionColumn.Visible = false;
            panel.Columns.Add(NumRemisionColumn);

            GridColumn NumeroPartidaColumn = new GridColumn("NumeroPartidaColumn");
            NumeroPartidaColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            NumeroPartidaColumn.HeaderText = "PARTIDA";
            NumeroPartidaColumn.DataPropertyName = "NUM_PARTIDA";
            NumeroPartidaColumn.Width = 100;
            panel.Columns.Add(NumeroPartidaColumn);

            GridColumn ArticuloColumn = new GridColumn("ArticuloColumn");
            ArticuloColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            ArticuloColumn.HeaderText = "CLAVE";
            ArticuloColumn.DataPropertyName = "ARTICULO_ID";
            ArticuloColumn.Width = 100;
            panel.Columns.Add(ArticuloColumn);

            GridColumn Nombre1Column = new GridColumn("Nombre1Column");
            Nombre1Column.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            Nombre1Column.HeaderText = "NOMBRE";
            Nombre1Column.DataPropertyName = "NOMBRE1";
            Nombre1Column.Width = 200;
            panel.Columns.Add(Nombre1Column);

            GridColumn Nombre2Column = new GridColumn("*Nombre2Column");
            Nombre2Column.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            Nombre2Column.HeaderText = "NOMBRE";
            Nombre2Column.DataPropertyName = "NOMBRE2";
            Nombre2Column.Width = 200;
            panel.Columns.Add(Nombre2Column);

            GridColumn FechaEntregaColumn = new GridColumn("FechaEntregaColumn");
            FechaEntregaColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            FechaEntregaColumn.HeaderText = "FECHA ENTREGA";
            FechaEntregaColumn.DataPropertyName = "FECHAENT";
            FechaEntregaColumn.Width = 100;
            panel.Columns.Add(FechaEntregaColumn);

            GridColumn CantidadRemisionColumn = new GridColumn("CantidadRemisionColumn");
            CantidadRemisionColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            CantidadRemisionColumn.HeaderText = "CANTIDAD";
            CantidadRemisionColumn.DataPropertyName = "CANT_REMISION";
            CantidadRemisionColumn.Width = 80;
            panel.Columns.Add(CantidadRemisionColumn);

            GridColumn PrecioColumn = new GridColumn("PrecioColumn");
            PrecioColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            PrecioColumn.HeaderText = "PRECIO";
            PrecioColumn.DataPropertyName = "PRECIO";
            PrecioColumn.Width = 100;
            panel.Columns.Add(PrecioColumn);

            GridColumn IVAColumn = new GridColumn("IVAColumn");
            IVAColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            IVAColumn.HeaderText = "IVA";
            IVAColumn.DataPropertyName = "IVA";
            IVAColumn.Width = 70;
            panel.Columns.Add(IVAColumn);

            GridColumn FolioControladoColumn = new GridColumn("FolioControladoColumn");
            FolioControladoColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            FolioControladoColumn.HeaderText = "FOLIO CONTROLADO";
            FolioControladoColumn.DataPropertyName = "FOLIO_CONTROLADO";
            FolioControladoColumn.Width = 120;
            panel.Columns.Add(FolioControladoColumn);

            GridColumn LoteColumn = new GridColumn("LoteColumn");
            LoteColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            LoteColumn.HeaderText = "LOTE";
            LoteColumn.DataPropertyName = "LOTE";
            LoteColumn.Width = 100;
            panel.Columns.Add(LoteColumn);

            GridColumn CaducidadColumn = new GridColumn("CaducidadColumn");
            CaducidadColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            CaducidadColumn.HeaderText = "CADUCIDAD";
            CaducidadColumn.DataPropertyName = "CADUCIDAD";
            CaducidadColumn.Width = 100;
            panel.Columns.Add(CaducidadColumn);
        }

        DataSet DsRemisiones;

        private void Buscar()
        {
            SIFModelo.Remision remision = new SIFModelo.Remision();
            remision.NumeroRemision = this.buscarTextBoxX.Text;
            DsRemisiones = remsionL.BuscaRemisiones(Helpers.Sesion.Sucursal, remision, dateTimeInput1.Value, dateTimeInput2.Value);

            DsRemisiones.Relations.Add("1", DsRemisiones.Tables["Remisiones"].Columns["NUM_REMISION"],
                                           DsRemisiones.Tables["RemisionDetalles"].Columns["NUM_REMISION"], false);

            //this.bindingSource.DataSource = DsRemisiones;
            this.superGridControl1.PrimaryGrid.DataSource = DsRemisiones;
            //superGridControl1.PrimaryGrid.AutoGenerateColumns = true;
            superGridControl1.PrimaryGrid.DataMember = "Remisiones";
        }

        private SIFModelo.Remision SelectedRemision()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;

            if (panel.ActiveRow == null)
            {
                return null;
            }

            var container = ((GridContainer)panel.ActiveRow);

            if (!(container is GridRow))
            {
                //MessageBox.Show("Debe seleccionar una remision");
                return null;
            }

            if (panel.ActiveRow.GridPanel.DataMember != "Remisiones")
            {
               MessageBox.Show("Debe seleccionar una remision");
                return null;
            }

            var row = (GridRow)container;

            DataRow datarow = ((DataRowView)row.DataItem).Row;
            SIFModelo.Remision remision = new SIFModelo.Remision();
            remision.SucursalID = int.Parse(datarow["SUCURSAL_ID"].ToString());
            remision.NumeroRemision = datarow["NUM_REMISION"].ToString();
            remision.TipoClienteID = int.Parse(datarow["TIPO_CLIENTE_ID"].ToString());
            remision.ClienteID = int.Parse(datarow["CLIENTE_ID"].ToString());
            remision.FechaVenta = DateTime.Parse(datarow["FECHA_VTA"].ToString());
            remision.Receta = (SIFModelo.Tipos.SiNo)(datarow["RECETA"].ToString()[0]);
            remision.MedicoID = int.Parse(datarow["ID_MEDICO"].ToString());
            var fecha = datarow["FECHA_PAGO"];
            if (fecha.ToString().IsDatetime())
            {
                remision.FechaPago = DateTime.Parse(datarow["FECHA_PAGO"].ToString());
            }
            remision.VendedorID = int.Parse(datarow["VENDEDOR_ID"].ToString());
            remision.MonedaID = int.Parse(datarow["MONEDA_ID"].ToString());
            remision.TipoCambio = int.Parse(datarow["TIPO_CAMBIO_ID"].ToString());
            remision.Condiciones = (datarow["CONDICIONES"].ToString());
            remision.SubTotal = decimal.Parse(datarow["SUBTOTAL"].ToString());
            remision.Impuesto = decimal.Parse(datarow["IMPUESTO_IVA"].ToString());
            remision.Descuento = decimal.Parse(datarow["DESCUENTO"].ToString());
            remision.Total = decimal.Parse(datarow["TOTAL"].ToString());
            remision.TotalArticulosRemision = decimal.Parse(datarow["TOTAL_ARTICULOS_REM"].ToString());
            remision.NumeroFactura = (datarow["NUM_FACTURA"].ToString());
            remision.Activo = (SIFModelo.Tipos.StatusVenta)(datarow["ACTIVO"].ToString()[0]);
            remision.ImporteLetra = datarow["IMPORTE_LETRA"].ToString();
            remision.Factura = (SIFModelo.Tipos.SiNo)(datarow["FACTURA"].ToString()[0]);
            remision.Comentarios = datarow["COMENTARIOS"].ToString();
            remision.NumeroPedido = datarow["NUM_PEDIDO"].ToString();
            remision.BeneficioProveedor = (SIFModelo.Tipos.SiNo)datarow["BENEFICIO_PROV"].ToString()[0];

            return remision;
        }

        private SIFModelo.RemisionDetalle SelectedRemisionDetalle()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;

            if (panel.ActiveRow == null)
            {
                return null;
            }

            var container = ((GridContainer)panel.ActiveRow);

            if (!(container is GridPanel))
            {
                //MessageBox.Show("Debe seleccionar una remision");
                return null;
            }

            if (panel.ActiveRow.GridPanel.DataMember != "RemisionDetalles")
            {
               MessageBox.Show("Debe seleccionar una remision");
                return null;
            }

            GridPanel detallesPanel = (GridPanel)container;

            var row = detallesPanel.ActiveRow;

            DataRow datarow = ((DataRowView)((GridRow)row).DataItem).Row;


            SIFModelo.RemisionDetalle remision = new SIFModelo.RemisionDetalle();
            remision.SucursalID = int.Parse(datarow["SUCURSAL_ID"].ToString());
            remision.NumeroRemision = datarow["NUM_REMISION"].ToString();
            remision.ArticuloID = datarow["ARTICULO_ID"].ToString();
            // remision.BeneficioProveedor = (SIFModelo.Tipos.SiNo)datarow[""].ToString()[0];
            if (datarow["CADUCIDAD"].ToString().IsDatetime())
                remision.Caducidad = DateTime.Parse(datarow["CADUCIDAD"].ToString());


            remision.CantidadRemision = int.Parse(datarow["CANT_REMISION"].ToString());
            remision.DescuentoID = int.Parse(datarow["DESCUENTO_ID"].ToString());
            //remision.FechaEntrega = datarow["FECHA_ENTREGA"].ToString();
            remision.FolioControlado = datarow["FOLIO_CONTROLADO"].ToString();
            remision.ImpuestoID = int.Parse(datarow["IMPUESTO_ID"].ToString());
            remision.IVA = decimal.Parse(datarow["IVA"].ToString());
            remision.Lote = datarow["LOTE"].ToString();
            //remision.Mensaje = datarow["MENSAJE"].ToString();
            //remision.MontoDescuento = decimal.Parse( datarow["MONTO_DESCUENTO"].ToString());
            remision.Nombre1 = datarow["NOMBRE1"].ToString();
            remision.Nombre2 = datarow["NOMBRE2"].ToString();
            remision.NumeroPartida = int.Parse(datarow["NUM_PARTIDA"].ToString());
            remision.NumeroRemision = datarow["NUM_REMISION"].ToString();
            remision.PaqueteID = int.Parse(datarow["PAQUETE_ID"].ToString());
            remision.Precio = decimal.Parse(datarow["PRECIO"].ToString());
            remision.PrecioCosto = decimal.Parse(datarow["PRECIO_COSTO"].ToString());
            //remision.Total = decimal.Parse(datarow["TOTAL"].ToString());



            //remision.TipoClienteID = int.Parse(datarow["TIPO_CLIENTE_ID"].ToString());
            //remision.ClienteID = int.Parse(datarow["CLIENTE_ID"].ToString());
            //remision.FechaVenta = DateTime.Parse(datarow["FECHA_VTA"].ToString());
            //remision.Receta = (SIFModelo.Tipos.SiNo)(datarow["RECETA"].ToString()[0]);
            //remision.MedicoID = int.Parse(datarow["ID_MEDICO"].ToString());
            //remision.FechaPago = DateTime.Parse(datarow["FECHA_PAGO"].ToString());
            //remision.VendedorID = int.Parse(datarow["VENDEDOR_ID"].ToString());
            //remision.MonedaID = int.Parse(datarow["MONEDA_ID"].ToString());
            //remision.TipoCambio = int.Parse(datarow["TIPO_CAMBIO_ID"].ToString());
            //remision.Condiciones = (datarow["CONDICIONES"].ToString());
            //remision.SubTotal = decimal.Parse(datarow["SUBTOTAL"].ToString());
            //remision.Impuesto = decimal.Parse(datarow["IMPUESTO_IVA"].ToString());
            //remision.Descuento = decimal.Parse(datarow["DESCUENTO"].ToString());
            //remision.Total = decimal.Parse(datarow["TOTAL"].ToString());
            //remision.TotalArticulosRemision = decimal.Parse(datarow["TOTAL_ARTICULOS_REM"].ToString());
            //remision.NumeroFactura = (datarow["NUM_FACTURA"].ToString());
            //remision.Activo = (SIFModelo.Tipos.StatusVenta)(datarow["ACTIVO"].ToString()[0]);
            //remision.ImporteLetra = datarow["IMPORTE_LETRA"].ToString();
            //remision.Factura = (SIFModelo.Tipos.SiNo)(datarow["FACTURA"].ToString()[0]);
            //remision.Comentarios = datarow["COMENTARIOS"].ToString();
            //remision.NumeroPedido = datarow["NUM_PEDIDO"].ToString();
            //remision.BeneficioProveedor = (SIFModelo.Tipos.SiNo)datarow["BENEFICIO_PROV"].ToString()[0];

            return remision;
        }


        private List<SIFModelo.RemisionDetalle> SelectedRemisionDetalles()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;

            List<SIFModelo.RemisionDetalle> detallesSeleccionados = new List<SIFModelo.RemisionDetalle>();

            if (panel.ActiveRow == null)
            {
                return null;
            }

            var container = ((GridContainer)panel.ActiveRow);

            if (!(container is GridPanel))
            {
                //MessageBox.Show("Debe seleccionar una remision");
                return null;
            }

            if (panel.ActiveRow.GridPanel.DataMember != "RemisionDetalles")
            {
               MessageBox.Show("Debe seleccionar una remision");
                return null;
            }

            GridPanel detallesPanel = (GridPanel)container;

            foreach (var panelRow in detallesPanel.SelectedRows)
            {
                var row = panelRow;

                DataRow datarow = ((DataRowView)((GridRow)row).DataItem).Row;

                SIFModelo.RemisionDetalle remision = new SIFModelo.RemisionDetalle();
                remision.SucursalID = int.Parse(datarow["SUCURSAL_ID"].ToString());
                remision.NumeroRemision = datarow["NUM_REMISION"].ToString();
                remision.ArticuloID = datarow["ARTICULO_ID"].ToString();
                // remision.BeneficioProveedor = (SIFModelo.Tipos.SiNo)datarow[""].ToString()[0];
                if (datarow["CADUCIDAD"].ToString().IsDatetime())
                    remision.Caducidad = DateTime.Parse(datarow["CADUCIDAD"].ToString());


                remision.CantidadRemision = int.Parse(datarow["CANT_REMISION"].ToString());
                remision.DescuentoID = int.Parse(datarow["DESCUENTO_ID"].ToString());
                //remision.FechaEntrega = datarow["FECHA_ENTREGA"].ToString();
                remision.FolioControlado = datarow["FOLIO_CONTROLADO"].ToString();
                remision.ImpuestoID = int.Parse(datarow["IMPUESTO_ID"].ToString());
                remision.IVA = decimal.Parse(datarow["IVA"].ToString());
                remision.Lote = datarow["LOTE"].ToString();
                //remision.Mensaje = datarow["MENSAJE"].ToString();
                //remision.MontoDescuento = decimal.Parse( datarow["MONTO_DESCUENTO"].ToString());
                remision.Nombre1 = datarow["NOMBRE1"].ToString();
                remision.Nombre2 = datarow["NOMBRE2"].ToString();
                remision.NumeroPartida = int.Parse(datarow["NUM_PARTIDA"].ToString());
                remision.NumeroRemision = datarow["NUM_REMISION"].ToString();
                remision.PaqueteID = int.Parse(datarow["PAQUETE_ID"].ToString());
                remision.Precio = decimal.Parse(datarow["PRECIO"].ToString());
                remision.PrecioCosto = decimal.Parse(datarow["PRECIO_COSTO"].ToString());
                var refe = datarow["REF_OFERTA"];
                if (refe != null)
                {
                    remision.RefOferta = int.Parse(datarow["REF_OFERTA"].ToString());
                }
                else
                {
                    remision.RefOferta = 0;
                }

                detallesSeleccionados.Add(remision);
            }

            return detallesSeleccionados;
        }


        SIFNegocio.Remision logica = new SIFNegocio.Remision();

        public int UsuarioId;
        private void VentasPagoUserControl_Load(object sender, EventArgs e)
        {
            this.dateTimeInput1.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, 0, 0, 1);
            dateTimeInput2.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, 23, 59, 59);
            this.buscarTextBoxX.Focus();
            //this.Buscar();
        }

        public Menu.VentasMenu Owner { get; set; }

        internal void Muestra()
        {
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;

            AccesoUsuarioForm frmUsuario = new AccesoUsuarioForm();
            if (frmUsuario.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.UsuarioId = frmUsuario.Usuario.UsuariosID;
            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);

            this.Buscar();
        }

        private void Devolucion()
        {
            SIFModelo.Remision remision = this.SelectedRemision();

            if (remision == null)
            {
                SIFModelo.RemisionDetalle detalle = this.SelectedRemisionDetalle();

                if (detalle == null)
                {
                   MessageBox.Show("Elija la remision o el detalle a devolver");
                    return;
                }

                if (MessageBoxEx.Show("¿Devolver el artículo " + detalle.ArticuloID + " [" + detalle.Nombre1 + "]?", "Devolver", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                SIFNegocio.Remision remisionL = new SIFNegocio.Remision();
                remision = remisionL.RemisionPorID(detalle.NumeroRemision, detalle.SucursalID);

                if (remision.Condiciones == "NADRO")
                {
                   MessageBox.Show("No hay devoluciones parciales en beneficios de TARJETAS circulo de la salud");
                    return;
                }

                if (remision.Activo != SIFModelo.Tipos.StatusVenta.PAGADA && remision.Activo != SIFModelo.Tipos.StatusVenta.DEVUELTA)
                {
                   MessageBox.Show("La remisión no ha sido pagada", "Devolución", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                SIFModelo.Usuario supervisor = new SIFModelo.Usuario();

                if (remision.Activo == SIFModelo.Tipos.StatusVenta.DEVUELTA)
                {
                   MessageBox.Show("Ingrese el usuario que autoriza la devolución");

                    Ventas.AccesoUsuarioForm frmAcceso = new AccesoUsuarioForm();
                    if (frmAcceso.ShowDialog() != DialogResult.OK)
                    {
                        //MessageBoxEx.Show("El usuario o contraseña no es correcto");
                        return;
                    }

                    supervisor = frmAcceso.Usuario;

                    if (supervisor.TipoUsuario != SIFModelo.Tipos.TipoUsuario.ADMINISTRATIVO)
                    {
                       MessageBox.Show("El supervisor debe ser un usuario Administrativo");
                        return;
                    }
                }

                if (remision.Condiciones.Contains("TAE"))
                {
                   MessageBox.Show("No hay devoluciones en recargas de tiempo aire");
                    return;
                }

                //DEVUELVE REMISION DETALLE
                SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(UsuarioId);

                // remisionL.CancelaDetalle(detalle, cantidadDevolver, usuario, tipoDevolucion);

                SIFNegocio.Devoluciones devolucionL = new SIFNegocio.Devoluciones();
                SIFModelo.Devolucion devolucion = new SIFModelo.Devolucion();
                devolucion.DevolucionID = devolucionL.NumeroDevolucion(Helpers.Sesion.Sucursal);
                devolucion.Activo = SIFModelo.Tipos.ActivoDevolucion.ABIERTA;
                devolucion.AutorizaID = supervisor.UsuariosID;
                devolucion.ClienteID = remision.ClienteID;
                //devolucion.Comentario = motivo.TipoDevolucion.Observaciones;
                devolucion.SucursalID = Helpers.Sesion.Sucursal.SucursalesID;
                devolucion.ReferenciaVenta = remision.NumeroRemision;
                devolucion.UsuarioID = UsuarioId;
                devolucion.FechaDevolucion = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

                devolucion.Detalles = new List<SIFModelo.DevolucionDetalle>();

                List<SIFModelo.RemisionDetalle> detalles = SelectedRemisionDetalles();

                remision.SubTotal = 0;
                remision.Descuento = 0;
                remision.Impuesto = 0;
                remision.Total = 0;

                devolucion.SubTotal = 0;
                devolucion.Descuento = 0;
                devolucion.Impuesto = 0;
                devolucion.TotalDevolucion = 0;

                //TICKET DEVOLUCION
                //NOTA CREDITO REMISION
                remision.Detalles = new List<SIFModelo.RemisionDetalle>();
                SIFNegocio.ClienteSubrogacion ClienteSubN = new SIFNegocio.ClienteSubrogacion();
                SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(remision.ClienteID);

                SIFModelo.ClienteSubrogaccion ClienteSub = ClienteSubN.ClientePorID(remision.ClienteID);
                SIFNegocio.ClienteConvenios clienteN = new SIFNegocio.ClienteConvenios();
                SIFModelo.ClienteConvenio ConvenioCliente = clienteN.ClientePorID(remision.ClienteID);

                if (cliente.Convenio == SIFModelo.Tipos.SiNo.NO)
                {
                    ConvenioCliente = null;
                }

                if (cliente.SUBROGACION == SIFModelo.Tipos.SiNo.NO)
                {
                    ClienteSub = null;
                }


                foreach (SIFModelo.RemisionDetalle rdetalle in detalles)
                {
                    detalle = rdetalle;
                    MotivoCancelacionCantidadForm motivo = new MotivoCancelacionCantidadForm(detalle);
                    if (motivo.ShowDialog() != DialogResult.OK)
                    {
                        continue;
                    }

                    SIFModelo.TipoDevolucion tipoDevolucion = new SIFModelo.TipoDevolucion();
                    tipoDevolucion.TipoDevolucionID = motivo.TipoDevolucion.TipoDevolucionID;
                    tipoDevolucion.Observaciones = motivo.TipoDevolucion.Observaciones;
                    int cantidadDevolver = motivo.CantidadADevolver;

                    SIFModelo.DevolucionDetalle detalleD = new SIFModelo.DevolucionDetalle();
                    detalleD.ArticuloID = detalle.ArticuloID;
                    detalleD.Cantidad = cantidadDevolver;
                    detalleD.Descuento = detalle.DescuentoID;
                    detalleD.DevolucionID = devolucion.DevolucionID;
                    detalleD.Nombre1 = detalle.Nombre1;
                    detalleD.Nombre2 = detalle.Nombre2;
                    detalleD.NumeroPartida = detalle.NumeroPartida;
                    detalleD.Precio = detalle.Precio;
                    detalleD.PrecioCosto = detalle.PrecioCosto;
                    detalleD.Total = (detalleD.Precio * detalleD.Cantidad);
                    detalleD.ImpuestoID = detalle.ImpuestoID;
                    SIFModelo.Descuento descuento = new SIFNegocio.Descuentos().DescuentoPorID(detalle.DescuentoID);
                    if (descuento != null)
                    {
                        detalleD.Descuento = (detalleD.Total * (descuento.Porcentaje / 100m));
                    }

                    if (detalle.RefOferta != 0)
                    {
                        SIFNegocio.OrdenCompra.ManejoDescuentos manejoL = new SIFNegocio.OrdenCompra.ManejoDescuentos();
                        SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow oferta = manejoL.OfertaPorArticuloOfertaID(detalle.ArticuloID, detalle.RefOferta);
                        detalleD.Descuento = (detalleD.Total * ((decimal)oferta.DESCUENTO / 100m));

                    }

                    if (ClienteSub != null && ClienteSub.PorDesc > 0)
                    {
                        decimal descuentoSub = detalleD.Total * (ClienteSub.PorDesc / 100m);
                        detalleD.Descuento = detalleD.Total * descuentoSub;
                    }
                    else if (ConvenioCliente != null && ConvenioCliente.PorDesc > 0)
                    {
                        decimal descuentoConvenio = (ConvenioCliente.PorDesc / 100m);
                        detalleD.Descuento = detalleD.Total * descuentoConvenio;
                    }

                    devolucion.Descuento += detalleD.Descuento;

                    SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(detalle.ImpuestoID);
                    detalleD.IVA = 0;
                    if (impuesto != null)
                    {
                        decimal porcentajeImpuesto = impuesto.Porcentaje / 100m;
                        //detalle.Precio = detalle.Precio - ((detalle.Precio / (1 + porcentajeImpuesto)) * porcentajeImpuesto);

                        detalleD.IVA = ((detalleD.Total - detalleD.Descuento) / (1 + porcentajeImpuesto)) * porcentajeImpuesto;
                        //detalle.Total += detalle.IVA;
                    }
                    devolucion.SubTotal += detalle.Precio * detalleD.Cantidad;
                    devolucion.Impuesto += detalleD.IVA;

                    detalleD.SucursalID = detalle.SucursalID;
                    detalleD.TipoDevolucionID = tipoDevolucion.TipoDevolucionID;
                    devolucion.Detalles.Add(detalleD);
                    devolucion.TotalDevolucion += detalleD.Total - detalleD.Descuento;

                    //CANTIDAD REMISION
                    decimal porcentajeImpuestoR = 0;
                    rdetalle.CantidadRemision = cantidadDevolver;
                    if (impuesto != null)
                    {
                        rdetalle.PorcentajeIVA = impuesto.Porcentaje;
                        porcentajeImpuestoR = impuesto.Porcentaje / 100m;

                    }
                    rdetalle.Precio = rdetalle.Precio / (1 + porcentajeImpuestoR);
                    rdetalle.Total = detalle.Precio * rdetalle.CantidadRemision;
                    remision.SubTotal += detalle.Total;

                    if (descuento != null)
                    {
                        rdetalle.MontoDescuento = (rdetalle.Total * (descuento.Porcentaje / 100m));
                    }
                    if (rdetalle.RefOferta != 0)
                    {
                        SIFNegocio.OrdenCompra.ManejoDescuentos manejoL = new SIFNegocio.OrdenCompra.ManejoDescuentos();
                        SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow oferta = manejoL.OfertaPorArticuloOfertaID(detalle.ArticuloID, detalle.RefOferta);
                        rdetalle.MontoDescuento = (detalleD.Total * ((decimal)oferta.DESCUENTO / 100m));
                    }
                    if (ClienteSub != null)
                    {
                        decimal descuentoSub = rdetalle.Total * (ClienteSub.PorDesc / 100m);
                        rdetalle.MontoDescuento = rdetalle.Total * descuentoSub;
                    }
                    else if (ConvenioCliente != null)
                    {
                        decimal descuentoConvenio = (ConvenioCliente.PorDesc / 100m);
                        rdetalle.MontoDescuento = rdetalle.Total * descuentoConvenio;
                    }
                    //if (rdetalle.PorcentajeIVA > 0)
                    //    rdetalle.MontoDescuento = rdetalle.MontoDescuento / (rdetalle.PorcentajeIVA / 100m);
                    remision.Descuento += rdetalle.MontoDescuento;
                    //remision.Descuento += rdetalle.MontoDescuento / (1 + (rdetalle.PorcentajeIVA / 100m));
                    rdetalle.IVA = (rdetalle.Total - rdetalle.MontoDescuento) * (rdetalle.PorcentajeIVA / 100m);
                    remision.Impuesto += rdetalle.IVA;
                    remision.Total += rdetalle.Total - rdetalle.MontoDescuento + rdetalle.IVA;
                    
                    
                    
                    remision.Detalles.Add(rdetalle);
                }
                decimal restad = Math.Round(remision.Total - devolucion.TotalDevolucion, 2);
                if (remision.Total > devolucion.TotalDevolucion)
                {
                    remision.Descuento = remision.Descuento - restad;
                    remision.Total = Math.Round(remision.SubTotal - remision.Descuento + remision.Impuesto, 2);
                }
                else if (remision.Total < devolucion.TotalDevolucion)
                {
                    remision.Descuento = remision.Descuento + restad;
                    remision.Total = Math.Round(remision.SubTotal - remision.Descuento + remision.Impuesto, 2);
                }

                if (devolucion.Detalles.Count == 0)
                {
                    return;
                }

                cliente = null;

                if (remision.NumeroFactura != "S" && remision.NumeroFactura != "N")
                {
                    cliente = new SIFNegocio.Clientes().ClientePorID(remision.ClienteID);
                }
                else
                {
                    cliente = new SIFNegocio.Clientes().ClientePorID(0);
                }

                devolucion.Comentario = "";
                SIFNegocio.WebServices.FEL fel = new SIFNegocio.WebServices.FEL();

                // remision.Total = (remision.SubTotal - remision.Descuento) + remision.Impuesto;

                SIFModelo.WebServices.FelControl fc = new SIFModelo.WebServices.FelControl();
                fel.numeroU(Helpers.Sesion.Usuario.UsuariosID.ToString());
                if (fel.NotaCredito(out fc, SIFNegocio.Configuracion.Configuraciones.Factura, SIFNegocio.Configuracion.Configuraciones.Aplicacion, cliente, remision, Helpers.Sesion.Sucursal))
                {
                    if (new SIFNegocio.Remision().Cancela(remision, Helpers.Sesion.Usuario.UsuariosID, Helpers.Sesion.Usuario.Nombre, true, false, true))
                    {
                        //EN EL DATAGRID PONER COMO CANCELADO
                        GridPanel grid = superGridControl1.PrimaryGrid;
                        grid.Rows.Remove(grid.ActiveRow);

                        devolucionL.AgregaDevolucion(devolucion, devolucion.Detalles, fc, usuario);
                       MessageBox.Show("Se creó la nota de crédito con número " + devolucion.DevolucionID);
                        remision.NumeroFactura = fc.UUID;
                        SIFNegocio.Remision.ImprimeTicketDevolucion(remision, devolucion, devolucion.Detalles, Helpers.Sesion.Sucursal, usuario, cliente);
                    }
                    else
                    {
                       MessageBox.Show("Ocurrio un error al cancelar la remisión: " + remision.NumeroRemision, "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return;

                //TERMINA DEVOLUCION DETALLE
            }

            //DEVOLUCION DE REMISION 
            remision = new SIFNegocio.Remision().RemisionPorID(remision.NumeroRemision, remision.SucursalID);

            if (remision.Activo == SIFModelo.Tipos.StatusVenta.CANCELADA || remision.Activo == SIFModelo.Tipos.StatusVenta.DEVUELTA)
            {
               MessageBox.Show("La remision " + remision.NumeroRemision + " ya fue cancelada anteriormente", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (remision.Activo != SIFModelo.Tipos.StatusVenta.PAGADA)
            {
               MessageBox.Show("La remisión no ha sido pagada", "Devolución", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (remision.Condiciones.Contains("TAE"))
            {
               MessageBox.Show("No hay devoluciones en recargas de tiempo aire");
                return;
            }
            if (remision.Condiciones.Contains("NADRO"))
            {
               MessageBox.Show("No hay devoluciones en Circulo de la Salud");
                return;
            }
            DialogResult res =MessageBox.Show("¿Devolver la remisión " + remision.NumeroRemision + "?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res != DialogResult.Yes)
            {
                return;
            }
            MotivoCancelacion motivoCancelacion = new MotivoCancelacion();
            //DatosDerechohabiente motivoCancelacion = new DatosDerechohabiente();
            //MessageBox.Show(motivoCancelacion.ShowDialog().ToString());
            if (motivoCancelacion.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            
            SIFModelo.TipoDevolucion tipoDevolucionCancelacion = new SIFModelo.TipoDevolucion();
            tipoDevolucionCancelacion.TipoDevolucionID = motivoCancelacion.TipoDevolucion.TipoDevolucionID;
            tipoDevolucionCancelacion.Observaciones = motivoCancelacion.TipoDevolucion.Observaciones;
            remision.Detalles = new SIFNegocio.Remision().CargaRemisionDetalles(remision);

            //EN EL DATAGRID PONER COMO CANCELADO
            GridPanel gridC = superGridControl1.PrimaryGrid;
            gridC.Rows.Remove(gridC.ActiveRow);

            //INSERTAMOS EN DEVOLUCIONES
            SIFNegocio.Devoluciones devolucionLC = new SIFNegocio.Devoluciones();
            SIFModelo.Devolucion devolucionC = new SIFModelo.Devolucion();
            devolucionC.DevolucionID = devolucionLC.NumeroDevolucion(Helpers.Sesion.Sucursal);
            devolucionC.Activo = SIFModelo.Tipos.ActivoDevolucion.ABIERTA;
            devolucionC.AutorizaID = UsuarioId;
            devolucionC.ClienteID = remision.ClienteID;
            devolucionC.Comentario = motivoCancelacion.TipoDevolucion.Observaciones;
            devolucionC.SucursalID = Helpers.Sesion.Sucursal.SucursalesID;
            devolucionC.TotalDevolucion = remision.Total;
            devolucionC.ReferenciaVenta = remision.NumeroRemision;
            devolucionC.UsuarioID = UsuarioId;
            devolucionC.FechaDevolucion = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            devolucionC.Descuento = remision.Descuento;

            devolucionC.Detalles = new List<SIFModelo.DevolucionDetalle>();
            foreach (SIFModelo.RemisionDetalle rdetalle in remision.Detalles)
            {
                SIFModelo.DevolucionDetalle detalle = new SIFModelo.DevolucionDetalle();
                detalle.ArticuloID = rdetalle.ArticuloID;
                detalle.Cantidad = rdetalle.CantidadRemision;
                detalle.Descuento = rdetalle.MontoDescuento;
                detalle.DevolucionID = devolucionC.DevolucionID;
                detalle.IVA = rdetalle.IVA;
                detalle.Nombre1 = rdetalle.Nombre1;
                detalle.Nombre2 = rdetalle.Nombre2;
                detalle.NumeroPartida = rdetalle.NumeroPartida;
                detalle.Precio = rdetalle.Precio;
                detalle.PrecioCosto = rdetalle.PrecioCosto;
                detalle.SucursalID = rdetalle.SucursalID;
                detalle.TipoDevolucionID = tipoDevolucionCancelacion.TipoDevolucionID;
                detalle.ImpuestoID = rdetalle.ImpuestoID;
                detalle.DescuentoID = rdetalle.DescuentoID;
                detalle.RefOferta = rdetalle.RefOferta;
                devolucionC.Detalles.Add(detalle);
            }

            //realizamos la devolucion
            SIFModelo.Cliente clienteC = null;
            SIFModelo.DireccionCliente dirCliente = null;
            if (remision.Factura == SIFModelo.Tipos.SiNo.SI)
            {
                clienteC = new SIFNegocio.Clientes().ClientePorID(devolucionC.ClienteID);
            }
            else
            {
                clienteC = new SIFModelo.Cliente();
                clienteC.Nombre = "PUBLICO EN GENERAL";
                clienteC.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                //}

                dirCliente = new SIFModelo.DireccionCliente();
                //dirCliente = new SIFNegocio.Clientes().DireccionCliente(cliente);
                //if (dirCliente == null)
                //{
                dirCliente = new SIFModelo.DireccionCliente();
                dirCliente.RFC = "XAXX010101000";
                dirCliente.Calle = "13 SUR";
                dirCliente.CodigoPostal = "72410";
                dirCliente.Ciudad = "PUEBLA";
                dirCliente.Municipio = "PUEBLA";
                dirCliente.Telefono = "-";
                dirCliente.Email = "";
                dirCliente.NumeroExterior = "2701";
                dirCliente.NumeroInterior = "-";
                dirCliente.Colonia = "VOLCANES";
            }


            SIFModelo.Usuario usuarioC = new SIFNegocio.Usuarios().UsuarioPorId(devolucionC.AutorizaID);


            //REVISAR PRIMERO SI SE PUEDE CANCELAR O HACER LA NOTA
            //RESTAMOS EL IVA
            List<SIFModelo.Impuesto> impuestos = (List<SIFModelo.Impuesto>)new SIFNegocio.Impuestos().Buscar("", "").DataSource;
            List<SIFModelo.Descuento> descuentos = (List<SIFModelo.Descuento>)new SIFNegocio.Descuentos().Buscar("", "").DataSource;
            remision.SubTotal = 0;
            //devolucionC.Detalles = new SIFNegocio.Remision().CargaRemisionDetalles(remision);
            decimal descuentoAnterior = remision.Descuento;
            decimal imp=remision.Impuesto;
            remision.Descuento = 0;
            //remision.Impuesto = 0;
            decimal total2 = remision.Total;
            remision.Total = 0;

            //PASAR A DEVOLUCION

            devolucionC.SubTotal = 0;
            devolucionC.Descuento = 0;
            devolucionC.Impuesto = 0;
            devolucionC.TotalDevolucion = 0;

            SIFNegocio.ClienteSubrogacion ClienteSubND = new SIFNegocio.ClienteSubrogacion();
            SIFModelo.ClienteSubrogaccion ClienteSubD = ClienteSubND.ClientePorID(remision.ClienteID);
            SIFNegocio.ClienteConvenios clienteND = new SIFNegocio.ClienteConvenios();
            SIFModelo.ClienteConvenio ConvenioClienteD = clienteND.ClientePorID(remision.ClienteID);

            foreach (var detalleRemision in devolucionC.Detalles)
            {
                //decimal precioInicial = detalleRemision.Precio;
                //detalleRemision.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalleRemision.Precio, 2) * detalleRemision.CantidadRemision;
                // remision.SubTotal += detalleRemision.Total;
                 var VimpuestoAsignado = from i in impuestos where i.ID == detalleRemision.ImpuestoID select i;
                SIFModelo.Impuesto impuestoAsignado = VimpuestoAsignado.FirstOrDefault();
                //detalleRemision.Precio = Math.Round(detalleRemision.Precio / (1 + (impuestoAsignado.Porcentaje / 100m)),2);
                detalleRemision.Total = detalleRemision.Precio * detalleRemision.Cantidad;
                var vDescuentoAsignado = from d in descuentos where d.ID == detalleRemision.DescuentoID select d;
                SIFModelo.Descuento descuentoAsignado = vDescuentoAsignado.FirstOrDefault();
                
                //DESCUENTO SIN IVA
                //LGS 04/03/2014 && REMISION.DESCUENTO>0, SE AGREGA PARA IMPEDIR QUE LA DEVOLUCION SE GENERE CON DESCUENTO 
                //if (descuentoAsignado != null && remision.Descuento>0 && detalleRemision.DescuentoID != 0)
                if (descuentoAsignado != null && detalleRemision.DescuentoID != 0)
                {
                    detalleRemision.Descuento = detalleRemision.Total * (descuentoAsignado.Porcentaje / 100m);
                }
                else
                {
                    detalleRemision.Descuento = 0;
                }

                if (ClienteSubD != null && ClienteSubD.PorDesc > 0)
                {
                    decimal descuentoSub = (ClienteSubD.PorDesc / 100m);
                    detalleRemision.Descuento = detalleRemision.Total * descuentoSub;
                }
                else if (ConvenioClienteD != null && ConvenioClienteD.PorDesc > 0)
                {
                    decimal descuentoConvenio = (ConvenioClienteD.PorDesc / 100m);
                    detalleRemision.Descuento = detalleRemision.Total * descuentoConvenio;
                }
                if (detalleRemision.RefOferta != 0)
                {
                    SIFNegocio.OrdenCompra.ManejoDescuentos manejoL = new SIFNegocio.OrdenCompra.ManejoDescuentos();
                    SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow oferta = manejoL.OfertaPorArticuloOfertaID(detalleRemision.ArticuloID, detalleRemision.RefOferta);
                    detalleRemision.Descuento = (detalleRemision.Total * ((decimal)oferta.DESCUENTO / 100m));
                }

                

               

                detalleRemision.IVA = ((detalleRemision.Total - detalleRemision.Descuento) / (1 + (impuestoAsignado.Porcentaje / 100m))) * (impuestoAsignado.Porcentaje / 100m);
                remision.Impuesto=detalleRemision.IVA;
                
                //detalleRemision.Precio = detalleRemision.Precio - detalleRemision.IVA;
                devolucionC.SubTotal += detalleRemision.Total;


                devolucionC.TotalDevolucion += Math.Round(detalleRemision.Total - detalleRemision.Descuento + detalleRemision.IVA, 2);
                devolucionC.TotalDevolucion = total2;
                devolucionC.Descuento = descuentoAnterior;
                
               
            }
            /*
            decimal resta0 = Math.Round(devolucionC.TotalDevolucion - total2, 2);
            if (devolucionC.TotalDevolucion > total2)
            {
                devolucionC.Descuento = devolucionC.Descuento + resta0;
                devolucionC.TotalDevolucion = Math.Round(devolucionC.SubTotal - devolucionC.Descuento + imp, 2);
            }
            else if (devolucionC.TotalDevolucion < total2)
            {
                devolucionC.Descuento = devolucionC.Descuento - resta0;
                devolucionC.TotalDevolucion = Math.Round(devolucionC.SubTotal - devolucionC.Descuento + imp, 2);
            }*/

            remision.SubTotal=0;// += devolucionC.SubTotal;
            //remision.Descuento += devolucionC.Descuento;
            //remision.Total += devolucionC.TotalDevolucion;
            remision.Total = 0;
            decimal IVASINO = 0;
            //CALCULAR REMISION SIN IVA 
            foreach (var detalleRemision in remision.Detalles)
            {
                //decimal precioInicial = detalleRemision.Precio;
                //detalleRemision.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalleRemision.Precio, 2) * detalleRemision.CantidadRemision;
                // remision.SubTotal += detalleRemision.Total;

                var vDescuentoAsignado = from d in descuentos where d.ID == detalleRemision.DescuentoID select d;
                SIFModelo.Descuento descuentoAsignado = vDescuentoAsignado.FirstOrDefault();

                var VimpuestoAsignado = from i in impuestos where i.ID == detalleRemision.ImpuestoID select i;
                SIFModelo.Impuesto impuestoAsignado = VimpuestoAsignado.FirstOrDefault();

                IVASINO = impuestoAsignado.Porcentaje;

                detalleRemision.Precio = Math.Round(detalleRemision.Precio / (1 + (impuestoAsignado.Porcentaje / 100m)),2);
                //detalleRemision.Precio = detalleRemision.Precio / (1 + (impuestoAsignado.Porcentaje / 100m));
                detalleRemision.Total = detalleRemision.Precio * detalleRemision.CantidadRemision;
                remision.Impuesto=imp;
               
                remision.SubTotal += detalleRemision.Total;

                //DESCUENTO
                //LGS 04/03/2014 &&detalleRemision.DescuentoID != 0 SE AGREGA PARA EVITAR QUE LA DEVOLUCION SE GENERE CON DESCUENTO INECESARIO
                if (descuentoAsignado != null && detalleRemision.DescuentoID != 0)
                {
                    detalleRemision.MontoDescuento = detalleRemision.Total * (descuentoAsignado.Porcentaje / 100m);
                   // remision.Descuento += detalleRemision.MontoDescuento;
                    remision.Descuento = descuentoAnterior;
                }
                else
                {
                    detalleRemision.MontoDescuento = 0;
                }

                if (detalleRemision.RefOferta != 0)
                {
                    SIFNegocio.OrdenCompra.ManejoDescuentos manejoL = new SIFNegocio.OrdenCompra.ManejoDescuentos();
                    SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow oferta = manejoL.OfertaPorArticuloOfertaID(detalleRemision.ArticuloID, detalleRemision.RefOferta);
                    detalleRemision.MontoDescuento = (detalleRemision.Total * ((decimal)oferta.DESCUENTO / 100m));
                }

                if (ClienteSubD != null && ClienteSubD.PorDesc > 0)
                {
                    decimal descuentoSub = (ClienteSubD.PorDesc / 100m);
                    detalleRemision.MontoDescuento = detalleRemision.Total * descuentoSub;
                }
                else if (ConvenioClienteD != null && ConvenioClienteD.PorDesc > 0)
                {
                    decimal descuentoConvenio = (ConvenioClienteD.PorDesc / 100m);
                    detalleRemision.MontoDescuento = detalleRemision.Total * descuentoConvenio;
                }

                if (impuestoAsignado.Porcentaje > 0)
                   detalleRemision.MontoDescuento = detalleRemision.MontoDescuento / (impuestoAsignado.Porcentaje / 100m);

                //IVA
               // detalleRemision.IVA = (detalleRemision.Total - detalleRemision.MontoDescuento) * (impuestoAsignado.Porcentaje / 100m);
                

                //

               // remision.Total += detalleRemision.Total - detalleRemision.MontoDescuento + detalleRemision.IVA;
                
               
            }
            remision.Descuento = ((remision.Descuento) / (1 + (IVASINO / 100m)));
            remision.Total = remision.SubTotal - remision.Descuento + imp;
            decimal resta = Math.Round(remision.Total - total2, 2);
           // decimal resta = remision.Total - total2;
            if (remision.Total > total2)
            {
                remision.Descuento = remision.Descuento + resta;
                remision.Total = Math.Round(remision.SubTotal - remision.Descuento + imp, 2);
            }
            else if (remision.Total < total2)
            {
                resta = resta * -1;
                remision.Descuento = (remision.Descuento - resta);
                remision.Total = Math.Round(remision.SubTotal - remision.Descuento + imp, 2);
            }

            if (remision.Descuento == 0 && descuentoAnterior > 0)
            {
                remision.Descuento = descuentoAnterior;
            }

            //if (remision.Factura == SIFModelo.Tipos.SiNo.SI)
            //{
            //    SIFNegocio.WebServices.FEL fel = new SIFNegocio.WebServices.FEL();
            //    if (fel.Cancelar(remision, SIFNegocio.Configuracion.Configuraciones.Factura))
            //    {
            //       MessageBox.Show("Se ha cancelado la factura correspondiente a la remisión " + remision.NumeroRemision);
            //    }
            //    else
            //    {
            //       MessageBox.Show("No se canceló la factura, revise la configuración e intente mas tarde", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            //else //CREAMOS LA NOTA DE CREDITO
            //{
            SIFModelo.WebServices.FelControl fcontrol = new SIFModelo.WebServices.FelControl();
            SIFNegocio.WebServices.FEL felWS = new SIFNegocio.WebServices.FEL();
            felWS.numeroU(Convert.ToString(devolucionC.AutorizaID));
            if (felWS.NotaCredito(out fcontrol, SIFNegocio.Configuracion.Configuraciones.Factura, SIFNegocio.Configuracion.Configuraciones.Aplicacion, clienteC, remision, Helpers.Sesion.Sucursal, dirCliente))
            {
                if (new SIFNegocio.Remision().Cancela(remision, Helpers.Sesion.Usuario.UsuariosID, Helpers.Sesion.Usuario.Nombre, true, false, true))
                {
                    if (!devolucionLC.AgregaDevolucion(devolucionC, devolucionC.Detalles, fcontrol, usuarioC))
                    {

                       MessageBox.Show("No se logró crear la nota de crédito, revise la configuración e intente mas tarde");
                        return;
                    }
                }
                //}
                remision.NumeroFactura = fcontrol.UUID;
                SIFNegocio.Remision.ImprimeTicketDevolucion(remision, devolucionC, devolucionC.Detalles, Helpers.Sesion.Sucursal, usuarioC, clienteC);

               MessageBox.Show("Se creó la nota de crédito con número " + devolucionC.DevolucionID);
                //CANCELAR EN NADRO PFIZER
            }
            else
            {
               MessageBox.Show("No se consiguió crear la nota de crédito");
            }
        }

        private void CancelacionAutomatica()
        {
            if (MessageBoxEx.Show("¿Cancelar todos los pedidos que no han sido finalizados en las ultimas 24 horas?", "Cancelación Automatica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            //CANCELAR TODAS LAS REMISIONES QUE NO HAN SIDO PROCESADAS
            if (this.cancelacionAutomaticaBackgroundWorker.IsBusy)
            {
               MessageBox.Show("La cancelación aun se esta procesando");
                return;
            }

            cancelacionAutomaticaBackgroundWorker.RunWorkerAsync();
        }

        private void ActivaComandos()
        {
            this.cancelarButtonItem.Shortcuts.Add(eShortcut.F8);
            this.backButton.Shortcuts.Add(eShortcut.F12);
        }

        private void DesactivaCommandos()
        {
            this.cancelarButtonItem.Shortcuts.Clear();
            this.backButton.Shortcuts.Clear();
        }


        public bool Mostrado { get; set; }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void cancelarButtonItem_Click(object sender, EventArgs e)
        {
            this.Devolucion();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Buscar();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
                this.Buscar();
            }
        }

        private void cancelacionAutomaticaButtonItem_Click(object sender, EventArgs e)
        {
            this.CancelacionAutomatica();
        }

        private void cancelacionAutomaticaBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            new SIFNegocio.Remision().CancelaPedidosyApartados24HRS(Helpers.Sesion.Sucursal);
        }

        private void cancelacionAutomaticaBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           MessageBox.Show("Se han cancelado todas las remisiones sin completar anteriores a 24 horas");
        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            SIFModelo.Remision remision = this.SelectedRemision();
            if (remision != null)
            {
                SIFNegocio.Devoluciones devolucionLC = new SIFNegocio.Devoluciones();
                SIFModelo.Devolucion devolucionC = devolucionLC.DevolucionPorRemision(remision.NumeroRemision, Helpers.Sesion.Sucursal);

                if (devolucionC == null)
                {
                   MessageBox.Show("No se ha encontrado la devolución correspondiente a la remisión " + remision.NumeroRemision);
                    return;
                }

                devolucionC.Detalles = devolucionLC.DevolucionDetalle(devolucionC.DevolucionID, Helpers.Sesion.Sucursal);
                SIFNegocio.Clientes ClienteL = new SIFNegocio.Clientes();
                SIFModelo.Cliente clienteC = ClienteL.ClientePorID(remision.ClienteID);
                devolucionC = devolucionLC.ReestructuraDevolucion(devolucionC);
                //AGREGAR EL UUID DE LA NOTA DE DEVOLUCION
                SIFModelo.WebServices.FelControl fc = new SIFModelo.WebServices.FelControl();

                remision.Activo = SIFModelo.Tipos.StatusVenta.DEVUELTA;
                fc = new SIFNegocio.WebServices.FEL().DevolucionPorRemision(remision);

                if (fc != null)
                    remision.NumeroFactura = fc.UUID;
                else
                    remision.NumeroFactura = "";

                SIFNegocio.Remision.RImprimeTicketDevolucion(remision, devolucionC, devolucionC.Detalles, Helpers.Sesion.Sucursal, Helpers.Sesion.Usuario, clienteC);
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            String Parm1 = "{DEVOLUCION.FECHA_DEV}>=DATE(" + dateTimeInput1.Value.ToString("yyyy,MM,dd") + ") AND {DEVOLUCION.FECHA_DEV}<=DATE(" + dateTimeInput2.Value.ToString("yyyy,MM,dd") + ")";
            if (buscarTextBoxX.Text != "")
                Parm1 = Parm1 + " AND {DEVOLUCION.REF_VENTA}='" + buscarTextBoxX.Text + "'";
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Devoluciones.rpt", Parm1);
            Impresion.ShowDialog();
        }
    }
}
