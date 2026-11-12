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
    public partial class CancelacionTicketUserControl : Templates.ListaUserControl
    {
        public CancelacionTicketUserControl()
        {
            InitializeComponent();
            this.inicializaTabla();
            this.CargaStatusOrdenCompra();
            Privilegios();
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 6, int.Parse(Xbtn.Tag.ToString()));
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

        private void CargaStatusOrdenCompra()
        {
            BindingList<SIFModelo.Tipos.StatusVenta> status = new BindingList<SIFModelo.Tipos.StatusVenta>();
            status.Add(SIFModelo.Tipos.StatusVenta.TODAS);
            status.Add(SIFModelo.Tipos.StatusVenta.CANCELADA);
            status.Add(SIFModelo.Tipos.StatusVenta.GENERADA);
            status.Add(SIFModelo.Tipos.StatusVenta.PAGADA);

            this.statusComboBoxEx.DataSource = status;
            statusComboBoxEx.DisplayMember = "";
            statusComboBoxEx.ValueMember = "";

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

            GridColumn IMPUESTOColumn = new GridColumn("IMPUESTOColumn");
            IMPUESTOColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            IMPUESTOColumn.HeaderText = "IMPUESTO_ID";
            IMPUESTOColumn.DataPropertyName = "IMPUESTO_ID";
            IMPUESTOColumn.Width = 70;
            IMPUESTOColumn.Visible = false;
            panel.Columns.Add(IMPUESTOColumn);

            GridColumn DESCUENTO_IDColumn = new GridColumn("DESCUENTO_IDColumn");
            DESCUENTO_IDColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            DESCUENTO_IDColumn.HeaderText = "DESCUENTO_ID";
            DESCUENTO_IDColumn.DataPropertyName = "DESCUENTO_ID";
            DESCUENTO_IDColumn.Width = 70;
            DESCUENTO_IDColumn.Visible = false;
            panel.Columns.Add(DESCUENTO_IDColumn);

            GridColumn PRECIO_COSTOColumn = new GridColumn("PRECIO_COSTOColumn");
            PRECIO_COSTOColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            PRECIO_COSTOColumn.HeaderText = "PRECIO_COSTO";
            PRECIO_COSTOColumn.DataPropertyName = "PRECIO_COSTO";
            PRECIO_COSTOColumn.Width = 70;
            PRECIO_COSTOColumn.Visible = false;
            panel.Columns.Add(PRECIO_COSTOColumn);

            GridColumn FolioControladoColumn = new GridColumn("FolioControladoColumn");
            FolioControladoColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            FolioControladoColumn.HeaderText = "FOLIO CONTROLADO";
            FolioControladoColumn.DataPropertyName = "FOLIO_CONTROLADO";
            FolioControladoColumn.Width = 120;
            panel.Columns.Add(FolioControladoColumn);

            GridColumn PAQUETE_IDColumn = new GridColumn("PAQUETE_IDColumn");
            PAQUETE_IDColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            PAQUETE_IDColumn.HeaderText = "PAQUETE_ID";
            PAQUETE_IDColumn.DataPropertyName = "PAQUETE_ID";
            PAQUETE_IDColumn.Width = 70;
            PAQUETE_IDColumn.Visible = false;
            panel.Columns.Add(PAQUETE_IDColumn);

            GridColumn REF_NADROColumn = new GridColumn("REF_NADROColumn");
            REF_NADROColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            REF_NADROColumn.HeaderText = "REF_NADRO";
            REF_NADROColumn.DataPropertyName = "REF_NADRO";
            REF_NADROColumn.Width = 70;
            REF_NADROColumn.Visible = false;
            panel.Columns.Add(REF_NADROColumn);

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
            if (!Loaded)
            {
                return;
            }
            this.superGridControl1.DataBindings.Clear();

            SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { SucursalID = SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID };
            SIFModelo.Remision remision = new SIFModelo.Remision();
            remision.NumeroRemision = this.buscarTextBoxX.Text;

            SIFModelo.Tipos.StatusVenta status = (SIFModelo.Tipos.StatusVenta)System.Convert.ToChar(this.statusComboBoxEx.SelectedValue);

            string estado = "%";
            if (status.ToString() == "TODAS")
            {
                estado = "%";
            }
            else
            {
                estado = ((char)status).ToString();
            }


            DsRemisiones = remsionL.BuscaRemisionesNoPagadas(sucursal, remision, dateTimeInput1.Value, dateTimeInput2.Value, estado);

            if (DsRemisiones.Tables["RemisionDetalles"].Columns.Count == 0)
            {
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("SUCURSAL_ID");
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("NUM_REMISION");
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("NUM_PARTIDA");
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("ARTICULO_ID");
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("NOMBRE1");
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("NOMBRE2");
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("FECHAENT");
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("CANT_REMISION");
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("PRECIO");
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("IVA");
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("IMPUESTO_ID");
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("DESCUENTO_ID");
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("PRECIO_COSTO");
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("FOLIO_CONTROLADO");
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("PAQUETE_ID");
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("REF_NADRO");
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("LOTE");
                DsRemisiones.Tables["RemisionDetalles"].Columns.Add("CADUCIDAD");

            }

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

            if (container is GridPanel)
            {
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
            if (datarow["FECHA_PAGO"].ToString().IsDatetime())
                remision.FechaPago = DateTime.Parse(datarow["FECHA_PAGO"].ToString());
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



        SIFNegocio.Remision logica = new SIFNegocio.Remision();


        public int UsuarioId;
        private bool Loaded = false;
        private void VentasPagoUserControl_Load(object sender, EventArgs e)
        {
            this.dateTimeInput1.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, 0, 0, 1);
            dateTimeInput2.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            this.buscarTextBoxX.Focus();
            //this.Buscar();
            this.Loaded = true;
        }

        public Menu.VentasMenu Owner { get; set; }

        internal void Muestra()
        {
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;
            /*LGS 08/04/2014 PARA QUE PIDA USUARIO Y CONTRASEÑA ANTES DE CANCELAR*/
            AccesoUsuarioForm frmUsuario = new AccesoUsuarioForm();
            if (frmUsuario.ShowDialog() != DialogResult.OK)
            {
                
                return;
            }

            this.UsuarioId = frmUsuario.Usuario.UsuariosID;

            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.buscarTextBoxX.Focus();
        }

        private void Cancelar()
        {
            SIFModelo.Remision remision = this.SelectedRemision();
            if (remision == null)
            {
               MessageBox.Show("Elija la remision a cancelar");
                return;
            }



            remision = new SIFNegocio.Remision().RemisionPorID(remision.NumeroRemision, remision.SucursalID);
            if (remision.Activo == SIFModelo.Tipos.StatusVenta.PAGADA)
            {
               MessageBox.Show("La remision " + remision.NumeroRemision + " ha sido pagada, para cancelarla debe realizar su devolución", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (remision.Activo == SIFModelo.Tipos.StatusVenta.CANCELADA)
            {
               MessageBox.Show("La remision " + remision.NumeroRemision + " ya fue cancelada anteriormente", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult res =MessageBox.Show("¿Cancelar la remisión " + remision.NumeroRemision + "?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res != DialogResult.Yes)
            {
                return;
            }
            MotivoCancelacion motivo = new MotivoCancelacion();
            //motivo motivo = new DatosDerechohabiente();
            motivo.ShowDialog();
            remision.Comentarios += motivo.TipoDevolucion.Observaciones;
            
            SIFModelo.Usuario cancelador = new SIFNegocio.Usuarios().UsuarioPorId(this.UsuarioId);//LGS 09/04/2014 Obtenemos información del usuario que está cancelando


            //if (new SIFNegocio.Remision().Cancela(remision,Helpers.Sesion.Usuario.UsuariosID,Helpers.Sesion.Usuario.Nombre))
            if (new SIFNegocio.Remision().Cancela(remision, cancelador.UsuariosID, cancelador.Nombre))//LGS 09/04/2014 Se modifica para que guarde el usuario que cancela y no el usuario que inició sesión
            {

                if (remision.Condiciones == "PFIZER")
                {
                    //if (remision.Condiciones == "PFIZER")
                    //{
                    //    SIFNegocio.WebServices.PFIZER pfizerN = new SIFNegocio.WebServices.PFIZER();
                    //    SIFModelo.WebServices.PfizerControl control = pfizerN.Control(remision);
                    //    if (control == null)
                    //    {
                    //       MessageBox.Show("No se encontró una venta pendiente que cerrar en PFIZER");
                    //        return;
                    //    }
                    //    pfizerN.Cancela(control);
                    //}

                    SIFNegocio.WebServices.PFIZER pfizer = new SIFNegocio.WebServices.PFIZER();
                    SIFModelo.WebServices.PfizerControl pc = pfizer.Control(remision);
                    pfizer.Cancela(pc);
                }

                //EN EL DATAGRID PONER COMO CANCELADO
                GridPanel grid = superGridControl1.PrimaryGrid;
                //grid.Rows.Remove(grid.ActiveRow);
                (grid.DataSource as DataSet).Tables["Remisiones"].AcceptChanges();
                //INSERTAMOS EN CANCELACIONES
                //SIFNegocio.CANCE

                this.Buscar();
                //CANCELAR EN NADRO PFIZER
            }
            else
            {
               MessageBox.Show("No se consiguió cancelar la remisión" + remision.NumeroRemision);
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

            if (remisionFacturar.Activo == SIFModelo.Tipos.StatusVenta.DEVUELTA && remisionFacturar.Factura == SIFModelo.Tipos.SiNo.SI)
            {
                DialogResult rs =MessageBox.Show("¿La remision ha sido marcada como devuelta, desea cambiar el status de factura?", "Facturar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rs == DialogResult.Yes)
                {
                    remisionFacturar.Factura = SIFModelo.Tipos.SiNo.NO;
                    remisionFacturar.NumeroFactura = "N";
                    SIF.funciones.Bitacora("factura remision devuelta (status):" + remisionFacturar.NumeroRemision.ToString(), 6, 17);
                    logica.ActualizaUUIDRemision(remisionFacturar);
                }
            }

            if (remisionFacturar.Activo != SIFModelo.Tipos.StatusVenta.PAGADA && remisionFacturar.Activo != SIFModelo.Tipos.StatusVenta.DEVUELTA)
            {
               MessageBox.Show("La remisión debe estar pagada para poder marcarla como factura");
                return;
            }

            if (remisionFacturar.Factura == SIFModelo.Tipos.SiNo.SI)
            {
                var res =MessageBox.Show("La remisión ya está marcada como factura , ¿Crear una nueva factura?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                    return;
            }
            string factur = remisionFacturar.Factura.ToString();
            bool result = factur.Equals("GLOBAL", StringComparison.CurrentCultureIgnoreCase);
            if (result)
            {
               MessageBox.Show("NO se puede Facturar una remisión incluida en la Factura Global");
                return;

            }

            //checamos si el cliente es subrogacion no se puede facturar en caja
            SIFNegocio.Clientes ClienteL = new SIFNegocio.Clientes();
            SIFModelo.Cliente Cliente = ClienteL.ClientePorID(remisionFacturar.ClienteID);
            if ((Cliente.SUBROGACION == SIFModelo.Tipos.SiNo.SI))
            {
               MessageBox.Show("no se puede facturar a cliente SUBROGACION desde esta opción", "Cliente Subrogacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((remisionFacturar.TipoCambio == 1) || (Cliente.Convenio == SIFModelo.Tipos.SiNo.SI))
            {
                if (string.IsNullOrEmpty(remisionFacturar.NumeroFactura) || remisionFacturar.NumeroFactura == "N")
                {
                    var res =
                       MessageBox.Show("¿Desea asociar una factura a este cliente?", "Cliente convenio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                    {
                        SIF.funciones.Bitacora("Facturar cliente subrogacion (status):" + remisionFacturar.NumeroRemision.ToString(), 6, 17);

                        remisionFacturar.Factura = SIFModelo.Tipos.SiNo.SI;
                        logica.ActualizaRemisionEsFactura(remisionFacturar);
                    }
                }
                else
                {
                    var rep = MessageBox.Show("La remisión tiene asociada una factura con folio: " + remisionFacturar.NumeroFactura + ", ¿Quitar esta asociación?", "Cliente Subrogacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rep == DialogResult.Yes)
                    {
                        SIF.funciones.Bitacora("Facturar cliente subrogacion (quita referencia):" + remisionFacturar.NumeroRemision.ToString() + " UUID ANTERIOR: " + remisionFacturar.NumeroFactura, 6, 17);

                        remisionFacturar.NumeroFactura = "N";
                        remisionFacturar.Factura = SIFModelo.Tipos.SiNo.SI;
                        logica.ActualizaRemisionEsFactura(remisionFacturar);
                        logica.ActualizaUUIDRemision(remisionFacturar);
                    }
                }
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

        public void ActivaComandos()
        {
            this.cancelacionAutomaticaButtonItem.Shortcuts.Add(eShortcut.F9);
            this.cancelarButtonItem.Shortcuts.Add(eShortcut.F8);
            this.backButton.Shortcuts.Add(eShortcut.F12);
        }

        private void DesactivaCommandos()
        {
            this.cancelacionAutomaticaButtonItem.Shortcuts.Clear();
            this.cancelarButtonItem.Shortcuts.Clear();
            this.backButton.Shortcuts.Clear();
        }


        public bool Mostrado;

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Buscar();
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

        private void imprimeTicketButtonItem_Click(object sender, EventArgs e)
        {
            SIFModelo.Remision remision = SelectedRemision();

            if (remision == null)
            {
                return;
            }

            //CHECAMOS SI ES CLIENTE CONVENIO

            SIFNegocio.ClienteConvenios ClienteConL = new SIFNegocio.ClienteConvenios();
            SIFModelo.ClienteConvenio Clientecon = ClienteConL.ClientePorID(remision.ClienteID);
            if (Clientecon != null)
            {
                if (MessageBoxEx.Show("¿Imprimir en remision formato carta?", "Reimpresion de ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    String Parm1 = "{REMISION_DET.NUM_REMISION}='" + remision.NumeroRemision.ToString() + "'";
                    SIFNegocio.Usuarios Logusu = new SIFNegocio.Usuarios();
                    SIFModelo.Usuario Vend = Logusu.UsuarioPorId(remision.VendedorID);
                    SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Remision.rpt", Parm1, Vend.Nombre + ' ' + Vend.Apellidos);
                    Impresion.ShowDialog();
                    return;
                }
            }
            if (remision.TipoClienteID == 4)
            {
                SIFNegocio.Clientes ClientesLog = new SIFNegocio.Clientes();
                SIFModelo.Cliente cliente = ClientesLog.ClientePorID(remision.ClienteID);

                SIFNegocio.Pedidos PedidoLog = new SIFNegocio.Pedidos();
                SIFModelo.Pedido pedido = PedidoLog.ObtenPedidoVenta(remision.NumeroRemision);
                SIFNegocio.Usuarios Usuariol = new SIFNegocio.Usuarios();
                SIFModelo.Usuario usuario = Usuariol.UsuarioPorId(remision.VendedorID);
                SIFNegocio.Remision logica = new SIFNegocio.Remision();

                if (remision.Detalles == null)
                {
                    remision.Detalles = logica.CargaRemisionDetalles(remision);
                }
                SIFNegocio.Remision.RImprimeTicketPedido(remision, remision.Detalles, Helpers.Sesion.Sucursal, usuario, cliente, pedido);
                return;
            }

            //SIFNegocio.Remision logicaRemision = new SIFNegocio.Remision();

            //logicaRemision.CargaRemisionDetalles(remision);

            //REVISAR SI ES TAE, O NADRO ETC E IMPRIMIR SU TICKET CORRESPONDIENTE


            if (remision.Condiciones == "NADRO")
            {
                //buscar la sesion de NADRO
                SIFModelo.WebServices.Nadro control = new SIFNegocio.WebServices.NADRO().Control(remision);

                if (control != null)
                {
                    SIFModelo.WebServices.TarjetaNadro tarjeta = new SIFModelo.WebServices.TarjetaNadro();
                    tarjeta.NumeroTarjeta = control.NumeroTarjeta;
                    tarjeta.ClienteID = remision.ClienteID;
                    tarjeta.NumeroConfirmacion = control.NumeroConfirmacion;
                    tarjeta.SesionID = control.CotizacionID;

                    SIFNegocio.Remision.ImprimeTicket(remision, tarjeta);
                }
                else
                {
                    SIFModelo.WebServices.TarjetaNadro tarjeta = new SIFModelo.WebServices.TarjetaNadro();
                    tarjeta.NumeroTarjeta = "";
                    tarjeta.ClienteID = remision.ClienteID;
                    tarjeta.NumeroConfirmacion = "";
                    tarjeta.SesionID = "";

                    SIFNegocio.Remision.ImprimeTicket(remision, tarjeta);
                }
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
       
            SIFNegocio.Remision.RImprimeTicket(remision);
        }

        private void statusComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
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

        private void facturaButtonItem_Click(object sender, EventArgs e)
        {
            Facturar();
        }

        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
            cancelacionAutomaticaButtonItem.Shortcuts.Clear();
            cancelarButtonItem.Shortcuts.Clear();
        }

        private void Imprimir(String StrCual, String StrTipo)
        {
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_NOTAS_GENERADAS.rpt", " {REMISION.ACTIVO}='" + StrCual + "' and {REMISION.FECHA_VTA} >=DATE(" + dateTimeInput1.Value.ToString("yyyy,MM,dd") + ") AND {REMISION.FECHA_VTA} <=DATE(" + dateTimeInput2.Value.ToString("yyyy,MM,dd") + ") ", StrTipo);
            Impresion.ShowDialog();
        }

        private void ImprimirF(String StrCual, String StrTipo)
        {
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_NOTAS_Pagadas.rpt", "CDATE({CS_NOTAS_GENFACT.FECHA})  >=DATE(" + dateTimeInput1.Value.ToString("yyyy,MM,dd") + ") AND CDATE({CS_NOTAS_GENFACT.FECHA})  <=DATE(" + dateTimeInput2.Value.ToString("yyyy,MM,dd") + ") AND Length({CS_NOTAS_GENFACT.NUM_FACTURA}) = 36 AND {CS_NOTAS_GENFACT.FACTURA} = 'S'", StrTipo); //" {PAGOS.CAJERO_ID}<>'1' and {PAGOS.ACTIVO}='S' AND {REMISION.ACTIVO}='P' AND {REMISION.FACTURA}='" + StrCual + "' and {PAGOS.FECHA} >=DATE(" + dateTimeInput1.Value.ToString("yyyy,MM,dd") + ") AND {PAGOS.FECHA} <=DATE(" + dateTimeInput2.Value.ToString("yyyy,MM,dd") + ") ", StrTipo);
            Impresion.ShowDialog();
        }

        private void ImprimirNF(String StrCual, String StrTipo)
        {
            string Condicion2 = "CDATE({CS_NOTAS_GENFACT.FECHA})  >=DATE(" + dateTimeInput1.Value.ToString("yyyy,MM,dd") + ") AND CDATE({CS_NOTAS_GENFACT.FECHA})  <=DATE(" + dateTimeInput2.Value.ToString("yyyy,MM,dd") + ") AND Length({CS_NOTAS_GENFACT.NUM_FACTURA}) < 36 AND {CS_NOTAS_GENFACT.FACTURA} = 'S' ";
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_NOTAS_Pagadas.rpt", "CDATE({CS_NOTAS_GENFACT.FECHA})  >=DATE(" + dateTimeInput1.Value.ToString("yyyy,MM,dd") + ") AND CDATE({CS_NOTAS_GENFACT.FECHA})  <=DATE(" + dateTimeInput2.Value.ToString("yyyy,MM,dd") + ") AND Length({CS_NOTAS_GENFACT.NUM_FACTURA}) <= 36 AND {CS_NOTAS_GENFACT.FACTURA} = 'N' OR " + Condicion2, StrTipo);// AND  {CS_NOTAS_GENFACT.FACTURA} = 'S'", StrTipo); //" {PAGOS.CAJERO_ID}<>'1' and {PAGOS.ACTIVO}='S' AND {REMISION.ACTIVO}='P' AND {REMISION.FACTURA}='" + StrCual + "' and {PAGOS.FECHA} >=DATE(" + dateTimeInput1.Value.ToString("yyyy,MM,dd") + ") AND {PAGOS.FECHA} <=DATE(" + dateTimeInput2.Value.ToString("yyyy,MM,dd") + ") ", StrTipo);
            Impresion.ShowDialog();
        }

        private void ImprimirD(String StrCual, String StrTipo)
        {
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_TICKETS_FORMA_PAGO.rpt", " {PAGOS.CAJERO_ID}<>'1' and {PAGOS.ACTIVO}='" + StrCual + "' and {PAGOS.FECHA} >=DATE(" + dateTimeInput1.Value.ToString("yyyy,MM,dd") + ") AND {PAGOS.FECHA} <=DATE(" + dateTimeInput2.Value.ToString("yyyy,MM,dd") + ") ", StrTipo);
            Impresion.ShowDialog();
            SIF.View.Reportes.frmImpresion Impresion2 = new Reportes.frmImpresion("RPT_TICKETS_FORMA_PAGO_SABA.rpt", " {SABA.CAJERO_ID}<>'1' and {SABA.ACTIVO}='" + StrCual + "' and {SABA.FECHA} >=DATE(" + dateTimeInput1.Value.ToString("yyyy,MM,dd") + ") AND {SABA.FECHA} <=DATE(" + dateTimeInput2.Value.ToString("yyyy,MM,dd") + ") ", StrTipo);
            Impresion2.ShowDialog();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Imprimir("G", "Notas Generadas");

        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            Imprimir("P", "Notas Pagadas");
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            Imprimir("C", "Notas Canceladas");
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            ImprimirF("S", "Notas Facturadas");
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            ImprimirNF("N", "Notas No Facturadas");
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            ImprimirD("S", "Notas Pagadas x Forma de Pago");
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Faltantes.rpt", " {FALTANTE.FECHA_FALTANTE} >= DATE(" + dateTimeInput1.Value.ToString("yyyy,MM,dd") + ") AND {FALTANTE.FECHA_FALTANTE} <=DATE(" + dateTimeInput2.Value.ToString("yyyy,MM,dd") + ")");
            Impresion.ShowDialog();
        }

    }
}
