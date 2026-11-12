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
    public partial class VentasPagoUserControl : Templates.ListaUserControl
    {
        public VentasPagoUserControl()
        {
            InitializeComponent();
            this.inicializaTabla();
        }

        SIFNegocio.Remision remsionL = new SIFNegocio.Remision();

        private void Back()
        {
            try
            {
                if (this.Mostrado && Owner.Owner.Owner.IsModalPanelDisplayed)
                {
                    //this.DesactivaComandos();
                    try
                    {
                        if (Owner.Owner.Owner.Contains(this))
                        {
                            Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
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


        private void ImprimeTicket()
        {
            SIFModelo.Remision remision = SelectedRemision();

            if (remision == null)
            {
                return;
            }

            //SIFNegocio.Remision logicaRemision = new SIFNegocio.Remision();

            //logicaRemision.CargaRemisionDetalles(remision);

            //REVISAR SI ES TAE, O NADRO ETC E IMPRIMIR SU TICKET CORRESPONDIENTE

            if (remision.Condiciones == "NADRO")
            {
                //buscar la sesion de NADRO
                SIFModelo.WebServices.Nadro control = new SIFNegocio.WebServices.NADRO().Control(remision);

                SIFModelo.WebServices.TarjetaNadro tarjeta = new SIFModelo.WebServices.TarjetaNadro();
                tarjeta.NumeroTarjeta = control.NumeroTarjeta;
                tarjeta.ClienteID = remision.ClienteID;
                tarjeta.NumeroConfirmacion = control.NumeroConfirmacion;
                tarjeta.SesionID = control.CotizacionID;

                List<SIFModelo.WebServices.NadroDetalle> detallesNadro = new SIFNegocio.WebServices.NADRO().ControlDetalles(control);

                remision.Detalles = logica.CargaRemisionDetalles(remision);

                foreach (SIFModelo.RemisionDetalle detalle in remision.Detalles)
                {
                    var vDetalleN = from n in detallesNadro where n.ArticuloID == detalle.ArticuloID && n.CantPagarNadro == detalle.CantidadRemision select n;

                    if (vDetalleN.Count() > 0)
                    {
                        SIFModelo.WebServices.NadroDetalle detalleNadro = vDetalleN.First();

                        detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                        detalle.MontoDescuento = detalleNadro.MontoDesctoNadro;
                        detalle.PiezasGratis = (int)detalleNadro.CantRegaloNadro;
                        detalle.PorcentajeDescuento = (int)detalleNadro.PorcenDesctoNadro;
                        detalle.MontoDescuento = detalleNadro.MontoDesctoNadro;
                        //detalle.Precio = detalleNadro.Precio;
                        if (detalle.PorcentajeDescuento > 0)
                        {
                            detalle.PrecioDescontado = detalle.Precio - (detalle.Precio * (detalle.PorcentajeDescuento / 100m));
                        }
                        if (detalle.MontoDescuento > 0)
                        {
                            detalle.PrecioDescontado = detalle.Precio - detalle.MontoDescuento;
                            if (detalle.PrecioDescontado < 0)
                            {
                                detalle.PrecioDescontado = 0;
                                detalle.MontoDescuento = 0;
                            }
                        }

                        detalle.PrecioProveedor = detalleNadro.PrecioFijo;
                    }
                }

                SIFNegocio.Remision.ImprimeTicket(remision, tarjeta);
                return;
            }

            if (remision.Condiciones == "TAE")
            {

                SIFModelo.Sucursal sucursal = new SIFNegocio.Sucursales().SucursalPorID(remision.SucursalID);
                SIFModelo.Usuario vendedor = new SIFNegocio.Usuarios().UsuarioPorId(remision.VendedorID);
                SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(remision.ClienteID);
                List<SIFModelo.RemisionDetalle> detalles = new SIFNegocio.Remision().CargaRemisionDetalles(remision);

                SIFModelo.WebServices.TAE control = new SIFNegocio.WebServices.TAE().Control(remision);

                SIFNegocio.Remision.ImprimeTicketTAE(remision, detalles, sucursal, vendedor, cliente, control, control.Respuesta);
                return;
            }


            if (remision.Condiciones == "PFIZER")
            {
                //buscar la sesion de NADRO
                SIFModelo.WebServices.PfizerControl control = new SIFNegocio.WebServices.PFIZER().Control(remision);

                SIFModelo.WebServices.TarjetaPfizer tarjeta = new SIFModelo.WebServices.TarjetaPfizer();
                tarjeta.TarjetaID = control.NO_TARJETA;
                tarjeta.ClienteID = remision.ClienteID;
                tarjeta.NumeroConfirmacion = control.NO_CONFIRMACION;
                tarjeta.SesionID = control.COTIZACION_ID;

                // List<SIFModelo.WebServices.DetallePfizer> detalles = new SIFNegocio.WebServices.PFIZER().ControlDetalles(control);

                remision.Detalles = logica.CargaRemisionDetalles(remision);

                //foreach (SIFModelo.RemisionDetalle detalle in remision.Detalles)
                //{
                //    var vDetalleN = from n in detallesNadro where n.ArticuloID == detalle.ArticuloID && n.CantPagarNadro == detalle.CantidadRemision select n;

                //    if (vDetalleN.Count() > 0)
                //    {
                //        SIFModelo.WebServices.NadroDetalle detalleNadro = vDetalleN.First();

                //        detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                //        detalle.MontoDescuento = detalleNadro.MontoDesctoNadro;
                //        detalle.PiezasGratis = (int)detalleNadro.CantRegaloNadro;
                //        detalle.PorcentajeDescuento = (int)detalleNadro.PorcenDesctoNadro;
                //        detalle.MontoDescuento = detalleNadro.MontoDesctoNadro;
                //        //detalle.Precio = detalleNadro.Precio;
                //        if (detalle.PorcentajeDescuento > 0)
                //        {
                //            detalle.PrecioDescontado = detalle.Precio - (detalle.Precio * (detalle.PorcentajeDescuento / 100m));
                //        }
                //        if (detalle.MontoDescuento > 0)
                //        {
                //            detalle.PrecioDescontado = detalle.Precio - detalle.MontoDescuento;
                //            if (detalle.PrecioDescontado < 0)
                //            {
                //                detalle.PrecioDescontado = 0;
                //                detalle.MontoDescuento = 0;
                //            }
                //        }

                //        detalle.PrecioProveedor = detalleNadro.PrecioFijo;
                //    }
                //}

                SIFNegocio.Remision.ImprimeTicket(remision, remision.Detalles, tarjeta);
                return;
            }

            SIFNegocio.Remision.ImprimeTicket(remision);

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
            SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { SucursalesID = SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID };
            SIFModelo.Remision remision = new SIFModelo.Remision();
            remision.NumeroRemision = this.buscarTextBoxX.Text;
            DsRemisiones = remsionL.BuscaRemisionesNoPagadas(sucursal, remision);

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

            if (panel.ActiveRow.GridPanel.DataMember != "Remisiones")
            {
               MessageBox.Show("Seleccione el encabezado de la remisión");
                return null;
            }

            var container = ((GridContainer)panel.ActiveRow);
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
            if (!datarow.IsNull("FECHA_PAGO"))
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

        private void AbonaRemision()
        {

            //VALIDAR LA CAJA

            SIFModelo.Caja vcaja = new SIFModelo.Caja() { ID = CajaId };
            vcaja = new SIFNegocio.Cajas().CajaPorID(Helpers.Sesion.Sucursal, vcaja);
            vcaja = new SIFNegocio.Cajas().ControlCaja(Helpers.Sesion.Sucursal, vcaja);

            if (vcaja == null)
            {
                MessageBox.Show("No se pudo comprobar la apertura de caja");
                return;
            }

#if !DEBUG
            if (SIFNegocio.Configuracion.Configuraciones.fechaServidor() > new DateTime(vcaja.FechaApertura.Year, vcaja.FechaApertura.Month, vcaja.FechaApertura.Day, 23, 59, 59))
            {
               MessageBox.Show("La fecha de cierre de su caja ha expirado, por favor haga el corte y vuelva a abrir la caja", "Corte de caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
#endif
            SIFModelo.Remision remision = SelectedRemision();

            if (remision == null)
            {
                return;
            }

            SIFModelo.Cliente clienteRemision = new SIFNegocio.Clientes().ClientePorID(remision.ClienteID);
            if (clienteRemision.Boletinado == SIFModelo.Tipos.SiNo.SI)
            {
                DialogResult dlgr =MessageBox.Show("El cliente está marcado como boletinado, ¿Permitir vender?", "Boletinado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgr == DialogResult.No)
                {
                    return;
                }
            }

            if (remision.Factura == SIFModelo.Tipos.SiNo.SI)
            {
                //VALIDAR LOS DATOS DEL CLIENTE
                clienteRemision.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                SIFModelo.DireccionCliente dirCliente = new SIFNegocio.Clientes().DireccionCliente(clienteRemision);


                if (!SIFNegocio.Helpers.Validadociones.ValidarRFC(dirCliente.RFC))
                {
                    //MessageBoxEx.Show("El RFC del cliente no es válido");
                    this.MuestraDireccionFiscal(clienteRemision);
                    return;
                }

                if (string.IsNullOrEmpty(clienteRemision.Nombre))
                {
                   MessageBox.Show("El nombre del cliente es obligatorio");
                    this.MuestraDireccionFiscal(clienteRemision);
                    return;
                }

                if (string.IsNullOrEmpty(dirCliente.Calle))
                {
                   MessageBox.Show("Debe ingresar la Calle de la dirección fiscal del cliente");
                    this.MuestraDireccionFiscal(clienteRemision);
                    return;
                }

                if (string.IsNullOrEmpty(dirCliente.NumeroExterior))
                {
                   MessageBox.Show("Especifique el número exterior de la dirección");
                    this.MuestraDireccionFiscal(clienteRemision);
                    return;
                }

                if (string.IsNullOrEmpty(dirCliente.Colonia))
                {
                   MessageBox.Show("La colonia es obligatoria para la facturación");
                    this.MuestraDireccionFiscal(clienteRemision);
                    return;
                }

                if (string.IsNullOrEmpty(dirCliente.Municipio))
                {
                   MessageBox.Show("El municipio es necesario");
                    this.MuestraDireccionFiscal(clienteRemision);
                    return;
                }

                if (string.IsNullOrEmpty(dirCliente.Ciudad))
                {
                   MessageBox.Show("Por favor seleccione el estado de la dirección fiscal del receptor");
                    this.MuestraDireccionFiscal(clienteRemision);
                    return;
                }
            }

            remision = new SIFNegocio.Remision().RemisionPorID(remision.NumeroRemision, remision.SucursalID);

            if (remision.Activo != SIFModelo.Tipos.StatusVenta.GENERADA)
            {
               MessageBox.Show("El status de la remisión seleccionada es " + remision.Activo.ToString());
                this.Buscar();
                return;
            }

            //VALIDAR SI EXISTE UN PAGO CON REFRENCIA A LA REMISION
            SIFNegocio.Pagos pagosL = new SIFNegocio.Pagos();
            SIFModelo.Pagos pago = pagosL.Pago(remision);

            if (pago != null)
            {
                //cambiar el status de la remision
               MessageBox.Show("Ya existe un pago referente a la remisión, el status de la remision cambiará automaticamente");
                SIFNegocio.Remision.ActualizaStatusPago(remision, pago);
                return;
            }
            remision.Detalles = new SIFNegocio.Remision().CargaRemisionDetalles(remision);
            if (this.VerificaInventario(remision.Detalles))
            {
                return;
            }

            if (remision.Condiciones == "TAE")
            {

                SIFNegocio.WebServices.TAE taeN = new SIFNegocio.WebServices.TAE();
                SIFModelo.WebServices.TAE control = taeN.Control(remision);

                string[] TAEGpo = SIFNegocio.Configuracion.Configuraciones.TAE.TAEGrupo.Split('|');
                control.Grupo = int.Parse(TAEGpo[0]);
                control.Cadena = int.Parse(TAEGpo[1]);
                control.Sucursal = int.Parse(TAEGpo[2]);
                control.RespuestaID = "";
                taeN.ActualizaTAE(control);

                SIFModelo.WebServices.Carrier carrier = new SIFNegocio.Extras.Carriers().CarrierPorID(control.Carrier);

                string mensaje = "Está a punto de enviar una recarga: \n" +
                 "Número: " + control.Telefono + "\n" +
                 "Compañía: " + carrier.Nombre + "\n" +
                 "Importe: " + control.Importe.ToString("C2") + "\n" +
                "Verifique que los datos sean correctos y cobre antes de presionar aceptar";

                if (MessageBoxEx.Show(mensaje, "TAE", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            SIFModelo.Caja caja = new SIFModelo.Caja();
            caja.ID = this.CajaId;
            SIFModelo.Cajero usuario = new SIFModelo.Cajero();
            usuario.CajeroID = this.UsuarioId.ToString();

            PagoForm frmPago = new PagoForm(remision, caja, usuario);
            if (frmPago.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (remision.Condiciones == "TAE")
            {
                string mensajeRecarga = "";

                SIFNegocio.WebServices.TAE taeN = new SIFNegocio.WebServices.TAE();
                SIFModelo.WebServices.TAE control = taeN.Control(remision);



                if (control.Referencia != "" && control.Referencia != null && control.Referencia != "-1" && control.Referencia != "0")
                {
                   MessageBox.Show("Ya se ha procesado la solicitud de TAE de la remision " + remision.NumeroRemision);
                    return;
                }

                //if (!taeN.Cerrar(control, remision, SIFNegocio.Configuracion.Configuraciones.TAE))
                //{
                //    return;
                //}

                if (control.Carrier == 1)
                {
                    mensajeRecarga = taeN.Recarga_TelCel(control.Carrier.ToString(), control.Articulo, control.Telefono, control.Importe, SIFNegocio.Configuracion.Configuraciones.TAE, control);
                }
                else
                {
                    mensajeRecarga = taeN.Recarga_MultiRecargas(control.Carrier.ToString(), control.Articulo, control.Telefono, control.Importe, SIFNegocio.Configuracion.Configuraciones.MultiRecargas, control);
                }

                if (mensajeRecarga == string.Empty)
                {
                    Application.UseWaitCursor = false;
                   MessageBox.Show("No se consiguió procesar la recarga, intente mas tarde", "Recarga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (control.RespuestaID != "0")
                {
                   MessageBox.Show(mensajeRecarga);
                    return;
                }

               MessageBox.Show(mensajeRecarga);
                //IMPRIMIMOS EL TICKET CON LA REFERENCIA DE TAE
                SIFModelo.Sucursal sucursal = new SIFNegocio.Sucursales().SucursalPorID(remision.SucursalID);
                SIFModelo.Usuario vendedor = new SIFNegocio.Usuarios().UsuarioPorId(remision.VendedorID);
                SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(remision.ClienteID);
                remision.Detalles = new SIFNegocio.Remision().CargaRemisionDetalles(remision);

                control.Respuesta = mensajeRecarga;

                SIFNegocio.WebServices.TAE ta = new SIFNegocio.WebServices.TAE();
                ta.ActualizaTAE(control);

                SIFNegocio.Remision.ImprimeTicketTAE(remision, remision.Detalles, sucursal, vendedor, cliente, control, mensajeRecarga);

                Application.UseWaitCursor = false;
                GridPanel grid = superGridControl1.PrimaryGrid;
                grid.Rows.Remove(grid.ActiveRow);

                //INSERTA EL PAGO Y ACTUALIZA EL CONTROL A CERRADO
            }


            //ABONAMOS A LA CUENTA
            SIFNegocio.Pagos pagosN = new SIFNegocio.Pagos();
            frmPago.pago.CajaID = this.CajaId;

            foreach (var pagoDetalle in frmPago.pagosDetalle)
            {
                pagoDetalle.REMISION_ID = frmPago.pago.RemisionID;
                pagoDetalle.NUM_PAGO = frmPago.pago.NumeroPago;
                //pagosN.PagoDetalle(pagoDetalle);
            }

            if (!pagosN.AbonaBulk(frmPago.pago, frmPago.pagosDetalle.ToList()))
            {
               MessageBox.Show("No se abonó el pago a la venta", "Pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.DialogResult == System.Windows.Forms.DialogResult.Cancel;
                return;
            }


            //foreach (var pagoDetalle in frmPago.pagosDetalle)
            //{
            //    pagoDetalle.REMISION_ID = frmPago.pago.RemisionID;
            //    pagoDetalle.NUM_PAGO = frmPago.pago.NumeroPago;
            //    pagosN.PagoDetalle(pagoDetalle);
            //}



            remision.Activo = SIFModelo.Tipos.StatusVenta.PAGADA;
            remision.FechaPago = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            SIFNegocio.Remision.ActualizaStatusPago(remision, frmPago.pago);

            foreach (SIFModelo.Devolucion vale in frmPago.valesUtilizados)
            {
                vale.Activo = SIFModelo.Tipos.ActivoDevolucion.CERRADA; //UTILIZADO
                vale.AutorizaID = this.UsuarioId;

                new SIFNegocio.ValesDevolucion().Modificar(vale);
            }



            //remision.Activo = SIFModelo.Tipos.StatusVenta.PAGADA;
            //remision.FechaPago = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            //new SIFNegocio.Remision().ActualizaRemision(remision);


            List<SIFModelo.RemisionDetalle> detalles = new List<SIFModelo.RemisionDetalle>();
            detalles = new SIFNegocio.Remision().CargaRemisionDetalles(remision);

            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();


            inventario.InventarioArticuloActualizaExistencia(detalles, Helpers.Sesion.Sucursal, usuario, remision);

            //foreach (SIFModelo.RemisionDetalle detalle in detalles)
            //{
            //    SIFModelo.Articulo articulo;
            //    //if (clienteRemision.SUBROGACION == SIFModelo.Tipos.SiNo.SI)
            //    //{
            //    //    articulo = new SIFNegocio.Articulo().BuscarPorClaveSub(detalle.ArticuloID, clienteRemision.ID.ToString());
            //    //    if (articulo == null)
            //    //        articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
            //    //    else
            //    //        articulo.ARTICULO_ID = articulo.CODIGO_CLI;
            //    //}
            //    //else
            //       articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);

            //   // inventario.InventarioArticuloApartaCancela(articulo, detalle.CantidadRemision);
            //    //!PASAR EN NEGATIVO
            //    inventario.InventarioArticuloDisminuye(articulo, detalle.CantidadRemision, remision.NumeroRemision, 1, short.Parse(detalle.NumeroPartida.ToString()), remision.VendedorID.ToString());
            //}

            //TERMINA REGISTRO DE PAGO


            if (remision.Factura == SIFModelo.Tipos.SiNo.SI)
            {
                bool facturaGenerada = true;

                //RESTAMOS EL IVA
                List<SIFModelo.Impuesto> impuestos = (List<SIFModelo.Impuesto>)new SIFNegocio.Impuestos().Buscar("", "").DataSource;
                List<SIFModelo.Descuento> descuentos = (List<SIFModelo.Descuento>)new SIFNegocio.Descuentos().Buscar("", "").DataSource;
                remision.SubTotal = 0;
                remision.Detalles = new SIFNegocio.Remision().CargaRemisionDetalles(remision);
                decimal descuentoAnterior = remision.Descuento;
                remision.Descuento = 0;
                foreach (var detalleRemision in remision.Detalles)
                {
                    var VimpuestoAsignado = from i in impuestos where i.ID == detalleRemision.ImpuestoID select i;
                    SIFModelo.Impuesto impuestoAsignado = VimpuestoAsignado.FirstOrDefault();

                    detalleRemision.Precio = decimal.Round( SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalleRemision.Precio / (1 + (impuestoAsignado.Porcentaje / 100m))),2);

                    detalleRemision.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalleRemision.Precio * detalleRemision.CantidadRemision);

                    var vDescuentoAsignado = from d in descuentos where d.ID == detalleRemision.DescuentoID select d;
                    SIFModelo.Descuento descuentoAsignado = vDescuentoAsignado.FirstOrDefault();

                    //DESCUENTO SIN IVA
                    if (descuentoAsignado != null)
                    {
                        detalleRemision.MontoDescuento = detalleRemision.Total * (descuentoAsignado.Porcentaje / 100);
                        remision.Descuento += detalleRemision.MontoDescuento;
                    }
                    else
                    {
                        detalleRemision.MontoDescuento = 0;
                    }

                    remision.SubTotal += detalleRemision.Total;
                }
                //

                if (remision.Descuento == 0)
                {
                    remision.Descuento = descuentoAnterior;
                }

                while (facturaGenerada)
                {
                    SIFNegocio.WebServices.FEL wsFel = new SIFNegocio.WebServices.FEL();

                    SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(remision.ClienteID);
                    SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal();
                    sucursal = new SIFNegocio.Sucursales().SucursalPorID(remision.SucursalID);
                    //sucursal = new SIFNegocio.Sucursales().Buscar("","");


                    SIFNegocio.Remision logicaF = new SIFNegocio.Remision();
                    SIFModelo.Remision remFacturar = logicaF.FacturaDeRemision(remision);
                    
                    wsFel.numeroU(usuario.CajeroID);

                    if (wsFel.Invocar(SIFNegocio.Configuracion.Configuraciones.Factura, SIFNegocio.Configuracion.Configuraciones.Aplicacion, cliente, remFacturar, sucursal))
                    {
                       MessageBox.Show("Se ha creado la factura de la remision " + remision.NumeroRemision);
                        GridPanel grid = superGridControl1.PrimaryGrid;
                        grid.Rows.Remove(grid.ActiveRow);
                        facturaGenerada = false;

                        //remision.Activo = SIFModelo.Tipos.StatusVenta.PAGADA;
                        remision.NumeroFactura = remFacturar.NumeroFactura;
                        //new SIFNegocio.Remision().ActualizaRemision(remision);
                    }
                    else
                    {
                        //MessageBox.Show("Ha ocurrido un error al crear la factura", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Catalogos.DireccionClienteForm frmClienteDir = new Catalogos.DireccionClienteForm(cliente);
                        if (frmClienteDir.ShowDialog() != DialogResult.OK)
                        {
                           MessageBox.Show("La factura no pudo crearse, puede intentarlo mas tarde en el módulo FACTURAS/Refacturar", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            facturaGenerada = false;
                        }
                        remision.Activo = SIFModelo.Tipos.StatusVenta.ERROR;
                        new SIFNegocio.Remision().ActualizaRemisionStatus(remision);
                    }
                }
                this.Buscar();
            }

            if (remision.BeneficioProveedor == SIFModelo.Tipos.SiNo.SI)
            {
                if (remision.Condiciones == "PFIZER")
                {
                    SIFNegocio.WebServices.PFIZER pfizerN = new SIFNegocio.WebServices.PFIZER();
                    SIFModelo.WebServices.PfizerControl control = pfizerN.Control(remision);
                    if (control == null)
                    {
                       MessageBox.Show("No se encontró una venta pendiente que cerrar en PFIZER");
                        return;
                    }
                    pfizerN.Cerrar(control, remision);

                    this.ImprimeTicket();

                    GridPanel grid = superGridControl1.PrimaryGrid;

                    grid.Rows.Remove(grid.ActiveRow);
                }
                if (remision.Condiciones == "NADRO")
                {
                    SIFNegocio.WebServices.NADRO nadroN = new SIFNegocio.WebServices.NADRO();
                    SIFModelo.WebServices.Nadro nadroG = nadroN.Control(remision);
                    List<SIFModelo.WebServices.NadroDetalle> detallesNadro = nadroN.ControlDetalles(nadroG);
                    SIFModelo.WebServices.TarjetaNadro tarjetaNadro = new SIFModelo.WebServices.TarjetaNadro();

                    SIFModelo.WebServices.TarjetaNadro tarjeta = new SIFModelo.WebServices.TarjetaNadro();
                    if (nadroG == null)
                    {
                       MessageBox.Show("No se logro la conexion con el sevicio NADRO");
                        return;
                    }
                    if ((tarjeta != null) & (nadroG != null))
                    {
                        tarjeta.SesionID = nadroG.CotizacionID;
                        tarjeta.NumeroTarjeta = nadroG.NumeroTarjeta;

                        string numeroConfirmacion = nadroN.Cerrar(remision, detallesNadro, tarjeta);

                        if (!string.IsNullOrEmpty(numeroConfirmacion))
                        {
                            tarjeta.NumeroConfirmacion = numeroConfirmacion;
                            nadroG.NumeroConfirmacion = numeroConfirmacion;
                            nadroG.FechaConfirmacion = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                            nadroG.Activo = SIFModelo.Tipos.SiNo.NO;
                            nadroN.Actualizar(nadroG);


                            //IMPRIMIMOS EL TICKET
                            this.ImprimeTicket();
                        }
                    }
                }

               MessageBox.Show("El pago ha sido registrado correctamente");
            }


            try
            {
                this.superGridControl1.PrimaryGrid.Rows.Remove(superGridControl1.PrimaryGrid.ActiveRow);
            }
            catch
            {
            }

        }

        private bool VerificaInventario(List<SIFModelo.RemisionDetalle> detalles)
        {
            SIFNegocio.Inventario.Inventario inventarioL = new SIFNegocio.Inventario.Inventario();
            foreach (var detalle in detalles)
            {
                SIFModelo.Articulo articulo;
                //if (ClienteSub == null)
                articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
                //else
                //    if (ClienteSub.PRECIO_FIJO == SIFModelo.Tipos.SiNo.SI)
                //        articulo = new SIFNegocio.Articulo().BuscarPorClaveSub(detalle.CODIGO_CLI, ClienteSub.ID.ToString());
                //    else
                //        articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.CODIGO_CLI);
                articulo.NOMBRE1 = detalle.Nombre1;
                int existencias = 0;
                if (inventarioL.InventarioArticuloSinApartado(articulo, detalle.CantidadRemision + detalle.PiezasGratis, out existencias))
                {
                    //MessageBoxEx.Show("Inventario insuficiente para el artículo "  + detalle.Nombre1 + " ["+detalle.ArticuloID+"]");
                    return false;
                }
            }

            return true;
        }

        private void PrecioArticulo(SIFModelo.RemisionDetalle detalle)
        {
            SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
            if (precios == null)
            {

               MessageBox.Show("No hay un precio activo para este producto");

            }
            else
            {
                detalle.Precio = precios.PRECIO_VENTA;
                detalle.Total = detalle.CantidadRemision * detalle.Precio;
                if (detalle.Precio == 0)
                {
                   MessageBox.Show("No hay un precio activo para este producto");
                    //return;
                }

                detalle.ImpuestoID = precios.IMP_VENTA;
                SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);
                decimal calculaImpuesto = (detalle.Total / ((impuesto.Porcentaje / 100m) + 1)) * (impuesto.Porcentaje / 100m);

                detalle.IVA = calculaImpuesto;
            }
        }


        SIFNegocio.Remision logica = new SIFNegocio.Remision();
        private void VentaTAE()
        {
            this.logica = new SIFNegocio.Remision();

            //validar si hicieron algun descuento
            if (!string.IsNullOrEmpty(this.logica.remision.TarjetaID))
            {
               MessageBox.Show("No puede agregar algun descuento o beneficio a este producto");
                return;
            }

            if (this.logica.RemisionDetalles.Count > 0)
            {
               MessageBox.Show("No puede combinar tiempo aire con otros artículos");
                return;
            }

            TiempoAireTelcelForm frmTiempoAire = new TiempoAireTelcelForm();
            if (frmTiempoAire.ShowDialog() != DialogResult.OK)
            {
                //return;
            }
            SIFModelo.RemisionDetalle detalle = new SIFModelo.RemisionDetalle();
            detalle.ArticuloID = frmTiempoAire.articulo.Articulo;
            detalle.Nombre1 = frmTiempoAire.articulo.Referencia + ": " + frmTiempoAire.articulo.Telefono;
            detalle.Nombre2 = frmTiempoAire.articulo.Telefono;
            detalle.Precio = frmTiempoAire.articulo.Importe;
            detalle.NumeroPartida = 1;
            detalle.CantidadRemision = 1;

            //iva
            this.PrecioArticulo(detalle);

           // detalle.Precio = detalle.Precio - detalle.IVA;


            //detalle
            this.logica.RemisionDetalles.Add(detalle);

            //tae
            SIFModelo.WebServices.TAE tae = new SIFModelo.WebServices.TAE();
            tae.Articulo = detalle.ArticuloID;
            tae.Telefono = frmTiempoAire.articulo.Telefono;
            tae.Carrier = frmTiempoAire.articulo.Carrier;
            tae.Importe = frmTiempoAire.articulo.Importe;
            tae.Fecha = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

            //GUARDAMOS TAE
            logica.remision.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
            logica.remision.Condiciones = "TAE";
            int numRemision;
            logica.remision.NumeroRemision = logica.FolioRemision(Helpers.Sesion.Sucursal.SucursalID, out numRemision);
            logica.InsertaFolioRemision(Helpers.Sesion.Sucursal.SucursalID, numRemision);
            tae.Remision = logica.remision.NumeroRemision;
            tae.Caja = this.CajaId;
            SIFNegocio.WebServices.TAE.Inserta(tae);

            //GENERAMOS LA REMISION
            logica.remision.SucursalID = Helpers.Sesion.Sucursal.SucursalID;
            logica.remision.SubTotal = detalle.Precio-detalle.IVA;
            logica.remision.Impuesto = detalle.IVA;
            logica.remision.Total = tae.Importe;
            logica.remision.VendedorID = this.UsuarioId;
            logica.remision.Activo = SIFModelo.Tipos.StatusVenta.GENERADA;
            logica.remision.TotalArticulosRemision = 1;
            logica.remision.ImporteLetra = global::sif_tools.NumberToLetters.NumToLetter((double)logica.remision.Total, "Double");
            logica.remision.ClienteID = 0;
            logica.remision.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
            logica.remision.FechaVenta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            logica.remision.NumeroPedido = "0";
            logica.remision.Comentarios = "-";
            logica.remision.Condiciones = "TAE";
            logica.remision.Receta = SIFModelo.Tipos.SiNo.NO;
            logica.remision.Factura = SIFModelo.Tipos.SiNo.NO;
            logica.remision.TipoClienteID = 6;
            if (!logica.GuardaRemision(logica.remision, logica.RemisionDetalles))
            {
               MessageBox.Show("Ha ocurrido un error al guardar la remision");
                return;
            }

            SIFModelo.Usuario vendedor = new SIFNegocio.Usuarios().UsuarioPorId(UsuarioId);
            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(logica.remision.ClienteID);
           MessageBox.Show("Se ha generado la remision " + logica.remision.NumeroRemision + " de tiempo aire");
            SIFNegocio.Remision.ImprimeTicket(logica.remision, logica.RemisionDetalles, Helpers.Sesion.Sucursal, vendedor, cliente);
            this.Buscar();

        }


        private void VentaMULTI()
        {
            this.logica = new SIFNegocio.Remision();

            //validar si hicieron algun descuento
            if (!string.IsNullOrEmpty(this.logica.remision.TarjetaID))
            {
               MessageBox.Show("No puede agregar algun descuento o beneficio a este producto");
                return;
            }

            if (this.logica.RemisionDetalles.Count > 0)
            {
               MessageBox.Show("No puede combinar tiempo aire con otros artículos");
                return;
            }

            TiempoAireForm frmTiempoAire = new TiempoAireForm();
            if (frmTiempoAire.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            SIFModelo.RemisionDetalle detalle = new SIFModelo.RemisionDetalle();
            detalle.ArticuloID = frmTiempoAire.articulo.Articulo;
            detalle.Nombre1 = frmTiempoAire.articulo.Referencia + ": " + frmTiempoAire.articulo.Telefono;
            detalle.Nombre2 = frmTiempoAire.articulo.Telefono;
            detalle.Precio = frmTiempoAire.articulo.Importe;
            detalle.NumeroPartida = 1;
            detalle.CantidadRemision = 1;

            //iva
            this.PrecioArticulo(detalle);

            //detalle.Precio = detalle.Precio - detalle.IVA;


            //detalle
            this.logica.RemisionDetalles.Add(detalle);

            //tae
            SIFModelo.WebServices.TAE tae = new SIFModelo.WebServices.TAE();
            tae.Articulo = detalle.ArticuloID;
            tae.Telefono = frmTiempoAire.articulo.Telefono;
            tae.Carrier = frmTiempoAire.articulo.Carrier;
            tae.Importe = frmTiempoAire.articulo.Importe;
            tae.Fecha = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

            //GUARDAMOS TAE
            logica.remision.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
            logica.remision.Condiciones = "TAE";
            int numRemision;
            logica.remision.NumeroRemision = logica.FolioRemision(Helpers.Sesion.Sucursal.SucursalID, out numRemision);
            logica.InsertaFolioRemision(Helpers.Sesion.Sucursal.SucursalID, numRemision);
            tae.Remision = logica.remision.NumeroRemision;
            tae.Caja = this.CajaId;
            SIFNegocio.WebServices.TAE.Inserta(tae);

            //GENERAMOS LA REMISION
            logica.remision.SucursalID = Helpers.Sesion.Sucursal.SucursalID;
            logica.remision.SubTotal = detalle.Precio;
            logica.remision.Impuesto = detalle.IVA;
            logica.remision.Total = tae.Importe;
            logica.remision.VendedorID = this.UsuarioId;
            logica.remision.Activo = SIFModelo.Tipos.StatusVenta.GENERADA;
            logica.remision.TotalArticulosRemision = 1;
            logica.remision.ImporteLetra = global::sif_tools.NumberToLetters.NumToLetter((double)logica.remision.Total, "Double");
            logica.remision.ClienteID = 0;
            logica.remision.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
            logica.remision.FechaVenta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            logica.remision.NumeroPedido = "0";
            logica.remision.Comentarios = "-";
            logica.remision.Condiciones = "TAE";
            logica.remision.Receta = SIFModelo.Tipos.SiNo.NO;
            logica.remision.Factura = SIFModelo.Tipos.SiNo.NO;
            logica.remision.TipoClienteID = 6;
            if (!logica.GuardaRemision(logica.remision, logica.RemisionDetalles))
            {
               MessageBox.Show("Ha ocurrido un error al guardar la remision");
                return;
            }

            SIFModelo.Usuario vendedor = new SIFNegocio.Usuarios().UsuarioPorId(UsuarioId);
            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(logica.remision.ClienteID);
           MessageBox.Show("Se ha generado la remision " + logica.remision.NumeroRemision + " de tiempo aire");
            SIFNegocio.Remision.ImprimeTicket(logica.remision, logica.RemisionDetalles, Helpers.Sesion.Sucursal, vendedor, cliente);
            this.Buscar();

        }

        public int CajaId;
        public int UsuarioId;
        private void VentasPagoUserControl_Load(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Focus();

            //conulstar recarga no exitosa
#if !DEBUG
            //consultaRecargaNoExitosa();
#endif
            // this.Buscar();
        }

        private void consultaRecargaNoExitosa()
        {
            SIFNegocio.WebServices.TAE tae = new SIFNegocio.WebServices.TAE();
            var control = tae.ConsultaRecargaNoExitosa("1", DateTime.Parse(SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("dd/MM/yyyy 00:00:00")), DateTime.Parse(SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("dd/MM/yyyy 23:59:59")));

            foreach (SIFModelo.Catalogo.CatalogoDataSet.CTL_TAERow ctl in control.Rows)
            {
                if (ctl != null)
                {
                    SIFModelo.WebServices.TAE taeC = new SIFModelo.WebServices.TAE();
                    SIFModelo.Remision REM = new SIFModelo.Remision();
                    REM.NumeroRemision = ctl.NUM_REMISION;
                    REM.SucursalID = Helpers.Sesion.Sucursal.SucursalesID;
                    taeC = tae.Control(REM, false);
                    //taeC.Archivo = control.NOM_ARCHIVO;
                    //taeC.Articulo = control.ARTICULO_ID;
                    //taeC.Cadena = control.CADENA;
                    //taeC.Caja = control.CAJA;
                    //taeC.Carrier = control.CARRIER_ID;
                    //taeC.Fecha = control.FECHA_ALTA;
                    //taeC.Grupo = control.GRUPO;
                    //taeC.Importe = control.IMPORTE;
                    //taeC.Referencia = control.REFERENCIA.ToString();
                    //taeC.Remision = control.NUM_REMISION;
                    //taeC.Respuesta = control.RESPUESTA_DESC.ToString();
                    //taeC.RespuestaID = control.RESPUESTA_ID.ToString();
                    //taeC.Sucursal = control.SUCURSAL;
                    //taeC.Telefono = control.NUM_TELEFONO;

                    if (string.IsNullOrEmpty(taeC.Respuesta))
                    {
                       MessageBox.Show("Se consultará la recarga " + taeC.Remision);

                        //if (taeC.Cadena == 0)
                        //{ 
                        //taeC.Cadena = SIFNegocio.Configuracion.Configuraciones.Aplicacion
                        //}
                        string respuesta = "";
                        if (taeC.Carrier == 1)
                        {

                            respuesta = tae.QueryTae(taeC, SIFNegocio.Configuracion.Configuraciones.TAE);
                        }
                        if (taeC.Carrier != 1)
                        {

                            respuesta = tae.QueryTae(taeC, SIFNegocio.Configuracion.Configuraciones.MultiRecargas);
                        }

                        taeC.Respuesta = respuesta;
                        if (string.IsNullOrEmpty(taeC.Referencia))
                        {
                            taeC.Referencia = "-1";
                        }

                        if (string.IsNullOrEmpty(taeC.RespuestaID))
                        {
                            taeC.RespuestaID = "-1";
                        }

                        if (string.IsNullOrEmpty(respuesta))
                        {
                            taeC.Referencia = "-2";
                        }

                        tae.ActualizaTAE(taeC);
                    }
                    else
                    {
                        string respuestaID = ctl.RESPUESTA_DESC[0].ToString();
                        if (respuestaID.IsInteger())
                        {
                            taeC.Referencia = respuestaID;
                            tae.ActualizaTAE(taeC);
                        }
                    }
                }

            }
        }

        public Menu.Ventas.CajaUserControl Owner { get; set; }

        internal void Muestra()
        {
            Owner.Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;
            Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.Buscar();
        }

        private void Cancelar()
        {
            SIFModelo.Remision remision = this.SelectedRemision();
            if (remision == null)
            {
               MessageBox.Show("Elija la remision a cancelar");
                return;
            }

            DialogResult res =MessageBox.Show("¿Cancelar la remisión " + remision.NumeroRemision + "?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res != DialogResult.Yes)
            {
                return;
            }

            DatosDerechohabiente motivo = new DatosDerechohabiente();
            motivo.ShowDialog();

            //remision.

            if (new SIFNegocio.Remision().Cancela(remision, Helpers.Sesion.Usuario.UsuariosID, Helpers.Sesion.Usuario.Nombre))
            {
                //EN EL DATAGRID PONER COMO CANCELADO
                GridPanel grid = superGridControl1.PrimaryGrid;
                grid.Rows.Remove(grid.ActiveRow);

                //CANCELAR EN NADRO PFIZER Y FEL

            }
        }


        SIFModelo.Remision remisionFacturar;
        private void Facturar()
        {
            remisionFacturar = SelectedRemision();

            if (remisionFacturar == null)
            {
                return;
            }
            //checamos si el cliente es subrogacion no se puede facturar en caja
            SIFNegocio.Clientes ClienteL = new SIFNegocio.Clientes();
            SIFModelo.Cliente Cliente = ClienteL.ClientePorID(remisionFacturar.ClienteID);
            if ((Cliente.SUBROGACION == SIFModelo.Tipos.SiNo.SI))
            {
               MessageBox.Show("no se puede facturar en caja cliente subrogacion", "Cliente Subrogacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((remisionFacturar.TipoCambio == 1) || (Cliente.Convenio == SIFModelo.Tipos.SiNo.SI))
            {
               MessageBox.Show("no se puede facturar en caja cliente convenio de credito", "Cliente convenio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (remisionFacturar.Factura == SIFModelo.Tipos.SiNo.SI)
            //{
            //   MessageBox.Show("Esta remisión ya ha solicitado factura");
            //    return;
            //}

            remisionFacturar.Factura = SIFModelo.Tipos.SiNo.SI;

            //if (remisionFacturar.ClienteID == 0 || remisionFacturar.ClienteID == 1)
            //{
            Catalogos.ClienteControl frmCliente = new Catalogos.ClienteControl();
            frmCliente.Owner = this;
            frmCliente.Muestra();
            //}
            //else
            //{
            //    SIFModelo.DireccionCliente dirFiscal = new SIFModelo.DireccionCliente();

            //    SIFModelo.Cliente cliente = new SIFModelo.Cliente();

            //    cliente.ID = this.logica.remision.ClienteID;
            //    cliente.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
            //    cliente = new SIFNegocio.Clientes().ClientePorID(remisionFacturar.ClienteID);
            //    dirFiscal = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);

            //    View.Catalogos.DireccionClienteForm frmCliente = new Catalogos.DireccionClienteForm(cliente);
            //    frmCliente.ShowDialog();
            //   // new SIFNegocio.Remision().ActualizaRemision(remisionFacturar);
            //}
            this.Buscar();

        }



        public void ActivaComandos()
        {
            this.buttonItem.Shortcuts.Add(eShortcut.F5);
            //this.cancelarButtonItem.Shortcuts.Add(eShortcut.F8);
            this.backButton.Shortcuts.Add(eShortcut.F12);
        }

        public void DesactivaCommandos()
        {
            this.buttonItem.Shortcuts.Clear();
            //this.cancelarButtonItem.Shortcuts.Clear();
            this.backButton.Shortcuts.Clear();
        }


        public bool Mostrado { get; set; }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            this.AbonaRemision();
        }

        private void cancelarButtonItem_Click(object sender, EventArgs e)
        {
            this.Cancelar();
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
                this.superGridControl1.Focus();
                return;
            }
            if (e.KeyCode == Keys.Down)
            {
                this.superGridControl1.Focus();
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
                this.Buscar();
            }
        }

        private void tiempoAireButtonItem_Click(object sender, EventArgs e)
        {
            this.VentaTAE();
        }

        private void imprimeTicketButtonItem_Click(object sender, EventArgs e)
        {
            ImprimeTicket();
        }

        private void superGridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.AbonaRemision();
        }

        private void taeButtonItem_Click(object sender, EventArgs e)
        {
            VentaTAE();
        }

        private void multiRecargasButtonItem_Click(object sender, EventArgs e)
        {
            VentaMULTI();
        }

        private void bar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void facturaButtonItem_Click(object sender, EventArgs e)
        {
            this.Facturar();
        }

        private void MuestraDireccionFiscal(SIFModelo.Cliente cliente)
        {
            cliente.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
            Catalogos.DireccionClienteForm frmCliente = new Catalogos.DireccionClienteForm(cliente);
            if (frmCliente.ShowDialog() != DialogResult.OK)
            {
                return;
            }
        }

        internal void AgregaCliente(SIFModelo.Cliente cliente)
        {
            if (remisionFacturar == null)
            {
                return;
            }

            Catalogos.DireccionClienteForm frmCliente = new Catalogos.DireccionClienteForm(cliente);
            if (frmCliente.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            cliente = new SIFNegocio.Clientes().ClientePorID(cliente.ID);
            SIFModelo.DireccionCliente dirFiscal = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);

            remisionFacturar.ClienteID = cliente.ID;
            remisionFacturar.Factura = SIFModelo.Tipos.SiNo.SI;
            logica.ActualizaRemisionEsFacturaCliente(remisionFacturar);
            this.Buscar();

        }

        private void buttonItem1_Click_1(object sender, EventArgs e)
        {
            SIF.View.Reportes.Venta.ConciliacionTAEForm frmConciliacion = new Reportes.Venta.ConciliacionTAEForm();
            frmConciliacion.ShowDialog();
        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }

            if (e.KeyCode == Keys.Enter)
            {
                this.AbonaRemision();
            }
        }

        private void VentasPagoUserControl_Leave(object sender, EventArgs e)
        {

        }
    }
}
