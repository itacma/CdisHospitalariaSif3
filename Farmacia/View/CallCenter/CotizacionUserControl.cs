using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using SIF.View.Ventas;

namespace SIF.View.CallCenter
{
    public partial class CotizacionUserControl : Templates.ListaUserControl
    {
        public object Owner;
        public object Owner1;
        public int Cual = 1;
        public SIFModelo.Cotizacion PCotiza;
        public SIFModelo.ClienteSubrogaccion ClienteSub;
        private decimal fTotal;
        private bool Pasa = false;
        private bool BPedidoE = false;
        private SIFModelo.WebServices.TarjetaPfizer pfizer = new SIFModelo.WebServices.TarjetaPfizer();
        private SIFModelo.WebServices.TarjetaNadro nadro = new SIFModelo.WebServices.TarjetaNadro();
        private decimal Descuento;
        private decimal PorScosto;
        private int UsuarioID = 0;
        SIFModelo.ClienteConvenio ConvenioCliente;
        SIFNegocio.ClienteConvenios clienteN = new SIFNegocio.ClienteConvenios();
        SIFNegocio.ClienteSubrogacion ClienteSubN = new SIFNegocio.ClienteSubrogacion();
        public CotizacionUserControl(bool ocultarCliente = false)
        {
            InitializeComponent();
            InicializaColumnas();
            if (ocultarCliente)
            {
                switch (Cual)
                {
                    case 0:
                    case 3:
                    case 4:
                        this.LogicaCotiza.CotizacionM = new SIFModelo.Cotizacion();
                        this.LogicaCotiza.CotizacionM.ClienteID = 1;
                        this.conCliente = ocultarCliente;
                        this.seleccionaClienteButtonItem.Visible = false;
                        this.seleccionaClienteButtonItem.Enabled = false;

                        break;

                }
            }

            CargaTipoPago();
            cargaSucursales();
            Privilegios();
            InicializaColumnasMedicamento();
        }

        private void InicializaColumnasMedicamento()
        {
            dataGrid = this.superGridControl1.PrimaryGrid;
            superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            GridIntegerInputEditControl cantidadColumn = superGridControl1.PrimaryGrid.Columns["CANTIDADColumn"].EditControl as GridIntegerInputEditControl;
            cantidadColumn.MinValue = 1;

            TIPO_MEDICAMENTOColumn.Click += LISTA_TIPO_MEDICAMENTO_Column_ButtonCustom_CLICK;

        }
        SIFModelo.Articulo current;
        void LISTA_TIPO_MEDICAMENTO_Column_ButtonCustom_CLICK(object sender, EventArgs e)
        {
            //DataGridViewTextBoxColumn ddc =
            //    sender as DataGridViewTextBoxColumn;

            DevComponents.DotNetBar.ImageItem ddc =
            sender as DevComponents.DotNetBar.ImageItem;

            if (ddc != null)
            {
                SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow row = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)this.dataGridViewX1.CurrentRow.DataBoundItem).Row; //((ObjectView<SIFModelo.Articulo>)this.bindingSource.Current).Object as SIFModelo.Articulo;

                current = new SIFNegocio.Articulo().BuscarPorClave(row.ARTICULO_ID);

                if (current == null)
                {
                    return;
                }

                Catalogos.ListaTipoMedicamentoForm tipoMedicamentoForm = new Catalogos.ListaTipoMedicamentoForm(current);
                tipoMedicamentoForm.aceptarButtonX.Enabled = false;
                tipoMedicamentoForm.notaLabel.Text = "En esta ventana no se puede realizar cambios";
                //tipoMedicamentoForm.listaTipoMedicamentoCheckedListBox. = false;
                if (tipoMedicamentoForm.ShowDialog() == DialogResult.OK)
                {
                    current.TIPO_MEDICAMENTO_CVE = tipoMedicamentoForm.ListaTipoMedicamento;
                    dataGridViewX1.EndEdit();
                    //this.Modificar(current);
                }
            }
        }


        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 25, int.Parse(Xbtn.Tag.ToString()));
            }

        }
        private void cargaSucursales()
        {
            SIFNegocio.Sucursales sucursalL = new SIFNegocio.Sucursales();
            this.sucursalesComboBoxEx.DataSource = sucursalL.Buscar("", "");
            sucursalesComboBoxEx.DisplayMember = "Nombre";
            sucursalesComboBoxEx.ValueMember = "SucursalesID";
            sucursalesComboBoxEx.Text = Helpers.Sesion.Sucursal.Nombre;
        }
        private void CargaTipoPago()
        {
            SIFNegocio.TipoPagos Pagos = new SIFNegocio.TipoPagos();
            this.cmbTipopago.DataSource = Pagos.Buscar("", "");
            cmbTipopago.DisplayMember = "Nombre";
            cmbTipopago.ValueMember = "ID";

        }

        private bool conCliente = false;

        public CotizacionUserControl(SIFModelo.Cotizacion cotizacion, List<SIFModelo.CotizacionDetalle> detalles)
        {
            this.LogicaCotiza.CotizacionM = cotizacion;
            this.LogicaCotiza.CotizacionDetalles = detalles;

            InitializeComponent();
            InicializaColumnas();
            this.estableceCotizacion();
        }

        public CotizacionUserControl(bool OcultarCliente, int ClienteID)
            : this(OcultarCliente)
        {
            this.ClienteID = ClienteID;
            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(ClienteID);

            if (cliente != null)
            {
                this.clienteLabelX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
            }
        }

        private void estableceCotizacion()
        {
            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(LogicaCotiza.CotizacionM.ClienteID);
            this.clienteLabelX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
        }

        SIFNegocio.Cotizacion LogicaCotiza = new SIFNegocio.Cotizacion();
        SIFNegocio.Pedidos LogicaPedidos = new SIFNegocio.Pedidos();
        SIFNegocio.Apartado LogicaApartados = new SIFNegocio.Apartado();

        #region Navegacion
        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.guardarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.cancelarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.agregaProductoButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.seleccionaClienteButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);

            CodigoTextBoxX.Focus();
        }

        /// <summary>
        /// Activa los acesos cortos mediante el teclado
        /// </summary>
        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
            this.guardarButtonItem.Shortcuts.Clear();
            this.cancelarButtonItem.Shortcuts.Clear();
            this.seleccionaClienteButtonItem.Shortcuts.Clear();
            this.agregaProductoButtonItem.Shortcuts.Clear();
        }

        GridPanel dataGrid;

        private void reportarFaltantes()
        {
            if (this.LogicaPedidos.articulosFaltantes.Count > 0)
            {
                //SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(this.LogicaPedidos.Pedido.VendedorID);
                SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(this.UsuarioID);
                
                View.Ventas.FaltantesForm frmFaltantes = new FaltantesForm(usuario, this.LogicaPedidos.articulosFaltantes);
                //frmFaltantes.ShowDialog();
                this.LogicaPedidos.articulosFaltantes.Clear();
            }
        }

        public void Back()
        {
            try
            {
                if (this.dataGrid.Rows.Count > 0 && !Pasa)
                {
                    DialogResult res = 0;
                    switch (Cual)
                    {
                        case 0:
                        case 3:
                        case 4:
                            res =MessageBox.Show("La Cotización esta en proceso, ¿desea cancelarla?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            break;

                        case 1:

                            res =MessageBox.Show("El pedido esta en proceso, ¿desea cancelarlo?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            break;
                        case 2:
                            res =MessageBox.Show("El apartado esta en proceso, ¿desea cancelarlo?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            break;
                    }

                    if (res == DialogResult.No)
                    {
                        return;
                    }
                }

                if (Cual == 1)
                    /*if (this.LogicaPedidos.articulosFaltantes.Count > 0)
                    {
                        DialogResult dres =MessageBox.Show("Hay faltantes a reportar, ¿desea reportarlos?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dres == DialogResult.Yes)
                        {
                            this.reportarFaltantes();
                        }
                    }*/
                if (Owner is View.Ventas.VentaUserControl)
                {
                    View.Ventas.VentaUserControl propietario = Owner as View.Ventas.VentaUserControl;
                    this.DesactivaComandos();
                    propietario.ActivaComandos();
                    propietario.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = true;
                }

                if (Owner is MainForm)
                {
                    MainForm propietario = Owner as MainForm;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();
                    this.Dock = DockStyle.Fill;
                    if (Owner1 is CotizacionesUserControl)
                    {
                        CotizacionesUserControl p = Owner1 as CotizacionesUserControl;
                        p.Buscar();
                    }
                    if (this.Mostrado)
                    {
                        if (propietario.Contains(this))
                            propietario.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Mostrado = false;
                }
            }
            catch { }
        }

        public void Muestra()
        {
            ActivaComandos();
            if (Owner is View.Ventas.VentaUserControl)
            {

                View.Ventas.VentaUserControl propietario = Owner as View.Ventas.VentaUserControl;
                propietario.Owner.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;
                propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                Mostrado = true;


            }

            if (Owner is MainForm)
            {

                MainForm propietario = Owner as MainForm;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;
                propietario.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                Mostrado = true;
                Opciones();
                View.Ventas.AccesoUsuarioForm frmAcesoUsuario = new AccesoUsuarioForm();
                if (frmAcesoUsuario.ShowDialog() != DialogResult.OK)
                {
                    this.Back();
                    return;
                }
                UsuarioID = frmAcesoUsuario.Usuario.UsuariosID;
            }
        }

        private void Opciones()
        {

            // cambiamos letreros


            switch (Cual)
            {
                case 0:
                case 3:
                case 4:
                    if (Cual == 3)
                        tableLayoutPanel4.Visible = false;

                    //asigna cliente mostrador
                    if (PCotiza != null)
                    {
                        LogicaCotiza.CotizacionM = PCotiza;
                        //folioCotizacionLabelX.Text = PCotiza.NumeroCotizacion.ToString();

                        SIFNegocio.Clientes ClienteL = new SIFNegocio.Clientes();
                        SIFModelo.Cliente cliente = ClienteL.ClientePorID(PCotiza.ClienteID);
                        clienteLabelX.Text = cliente.Nombre + ' ' + cliente.ApellidoPaterno + ' ' + cliente.ApellidoMaterno;

                        if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
                        {
                            ConvenioCliente = clienteN.ClientePorID(cliente.ID);
                            if (ConvenioCliente != null)
                            {
                                Descuento = ConvenioCliente.PorDesc;
                                PorScosto = ConvenioCliente.PorScosto;
                            }
                        }
                    }
                    else
                    {
                        LogicaCotiza.CotizacionM = new SIFModelo.Cotizacion();
                    }
                    if (descuentoCredencial != null)
                    {
                        LogicaCotiza.CotizacionM.TipoCambioID = descuentoCredencial.ID;
                        LogicaCotiza.CotizacionM.PorcentajeDescuento = descuentoCredencial.Porcentaje;
                        LogicaCotiza.CotizacionM.NumeroCredencial = descuentoCredencial.NumeroCredencial;
                        Descuento = descuentoCredencial.Porcentaje;
                    }

                    titleLabel.Text = "SIF\\Cotización";
                    LogicaCotiza.CotizacionM.PorcentajeDescuento = Descuento;
                    //descuentoCredencialButtonItem.Visible = false;
                    if (LogicaCotiza.CotizacionM.VendedorID == 0)
                        this.LogicaCotiza.CotizacionM.VendedorID = UsuarioID;
                    labelX7.Visible = false;
                    cmbTipopago.Visible = false;
                    labelX13.Visible = false;
                    txtimporte.Visible = false;
                    labelX8.Visible = false;
                    lblCambio.Visible = false;
                    //agregamos los articulos si es que existen
                    if (this.LogicaCotiza.CotizacionDetalles != null)
                        this.LogicaCotiza.CotizacionDetalles.Clear();
                    foreach (GridContainer detalle in this.superGridControl1.PrimaryGrid.Rows)
                    {
                        GridRow fila = detalle as GridRow;

                        SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
                        SIFModelo.Articulo articulo = articuloL.BuscarPorClave(fila.Cells[0].Value.ToString());
                        SIFModelo.CotizacionDetalle Cdetalle = new SIFModelo.CotizacionDetalle();
                        Cdetalle.ArticuloID = articulo.ARTICULO_ID;
                        Cdetalle.Nombre1 = articulo.NOMBRE1;
                        Cdetalle.Nombre2 = articulo.NOMBRE2;
                        if (fila.Cells[3].Value != null)
                            Cdetalle.CantidadCotizacion = int.Parse(fila.Cells[3].Value.ToString());
                        else
                            Cdetalle.CantidadCotizacion = 1;
                        this.PrecioArticulo(Cdetalle, PorScosto);

                        LogicaCotiza.CotizacionDetalles.Add(Cdetalle);
                    }
                    if (PCotiza == null)
                    {
                        //this.estableceCotizacion();
                        //PCotiza = new SIFModelo.Cotizacion();
                        //PCotiza.ClienteID = ClienteID;
                        //PCotiza.Detalles = new List<SIFModelo.CotizacionDetalle>();
                    }
                    if (PCotiza != null)
                    {
                        foreach (SIFModelo.CotizacionDetalle Cdetalle in PCotiza.Detalles)
                        {
                            //this.PrecioArticulo(Cdetalle, PorScosto);
                            LogicaCotiza.AgregaDetalle(Cdetalle);
                        }
                    }
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaCotiza.CotizacionDetalles;
                    superGridControl1.PrimaryGrid.Columns["CANTIDADColumn"].DataPropertyName = "CantidadCotizacion";
                    superGridControl1.PrimaryGrid.Columns["COMENTARIOColumn"].DataPropertyName = "COMENTARIO";

                    foreach (SIFModelo.CotizacionDetalle detalle in LogicaCotiza.CotizacionDetalles)
                        LogicaCotiza.RecalculaDetalle(detalle, LogicaCotiza.CotizacionM);

                    //LogicaCotiza.RecalculaDetalle(LogicaCotiza.CotizacionDetalles, LogicaCotiza.CotizacionM);

                    CalculaTotal();
                    break;
                case 1:
                    titleLabel.Text = "SIF\\Genera Pedido";
                    LogicaPedidos.Pedido.PorcentajeDescuento = Descuento;

                    

                    if (descuentoCredencial != null)
                    {
                        LogicaPedidos.Pedido.TipoCambioID = descuentoCredencial.ID;
                        LogicaPedidos.Pedido.PorcentajeDescuento = descuentoCredencial.Porcentaje;
                        LogicaPedidos.Pedido.NumeroCredencial = descuentoCredencial.NumeroCredencial;
                        Descuento = descuentoCredencial.Porcentaje;
                    }


                     SIFModelo.ClienteConvenio ClienteC;
                     SIFNegocio.ClienteConvenios ClienteCon = new SIFNegocio.ClienteConvenios();
                     ClienteC = ClienteCon.ClientePorID(LogicaPedidos.Pedido.ClienteID);
                     if (ClienteC != null  )
                     LogicaPedidos.Pedido.PorcentajeDescuento = ClienteC.PorDesc;

                    if (LogicaPedidos.Pedido.VendedorID == 0)
                        this.LogicaPedidos.Pedido.VendedorID = UsuarioID;
                    labelX7.Visible = true;
                    cmbTipopago.Visible = true;
                    labelX13.Visible = true;
                    txtimporte.Visible = true;
                    labelX8.Visible = true;
                    lblCambio.Visible = true;
                    if (this.LogicaPedidos.PedidoDetalles != null)
                        this.LogicaPedidos.PedidoDetalles.Clear();

                   // if (LogicaPedidos.Pedido.Receta != SIFModelo.Tipos.SiNo.SI)
                        foreach (GridContainer detalle in this.superGridControl1.PrimaryGrid.Rows)
                        {
                            GridRow fila = detalle as GridRow;

                            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
                            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(fila.Cells[0].Value.ToString());
                            if (articulo.TIPO_MEDICAMENTO_CVE.Contains("T3") || articulo.TIPO_MEDICAMENTO_CVE.Contains("S1") || articulo.TIPO_MEDICAMENTO_CVE.Contains("S2") || articulo.TIPO_MEDICAMENTO_CVE.Contains("S3") || articulo.TIPO_MEDICAMENTO_CVE.Contains("S4")) //articulo.TIPO_MEDICAMENTO_CVE.Contains("F1") ||
                            {
                                View.Ventas.RecetaMedicoForm frmrec = new View.Ventas.RecetaMedicoForm();
                                //pedimos el folio de la receta
                               /* if (LogicaPedidos.Pedido.Receta != SIFModelo.Tipos.SiNo.NO)
                                {
                                    View.Ventas.RecetaMedicoForm frmrec = new View.Ventas.RecetaMedicoForm();

                                    if (articulo.TIPO_MEDICAMENTO_CVE.Contains("S4"))
                                    {
                                        frmrec.causaLabelX.Text = "ANTIBIOTICO";
                                    }

                                    if (articulo.TIPO_MEDICAMENTO_CVE.Contains("S1") || articulo.TIPO_MEDICAMENTO_CVE.Contains("S2") || articulo.TIPO_MEDICAMENTO_CVE.Contains("S3"))
                                    {
                                        frmrec.causaLabelX.Text = "MEDICAMENTO CONTROLADO";
                                    }


                                */
                                    frmrec.ShowDialog();
                                    LogicaPedidos.Pedido.Receta = SIFModelo.Tipos.SiNo.SI;
                               // } VMJA
                            }
                            //else
                           /* if (articulo.TIPO_MEDICAMENTO_CVE.Contains("F1"))
                            {
                               MessageBox.Show("El medicamento " + articulo.ARTICULO_ID +" " +articulo.NOMBRE1 + " no puede ser vendido");
                                return;
                            }*/
                            SIFModelo.PedidoDetalle detallePed = new SIFModelo.PedidoDetalle();
                            detallePed.ArticuloID = articulo.ARTICULO_ID;
                            detallePed.Nombre1 = articulo.NOMBRE1;
                            detallePed.Nombre2 = articulo.NOMBRE2;
                            if (fila.Cells[3].Value == null)
                                detallePed.CantidadPedido = 1;
                            else
                                detallePed.CantidadPedido = int.Parse(fila.Cells[3].Value.ToString());
                            this.PrecioArticulo(detallePed, PorScosto);
                            LogicaPedidos.AgregaDetalle(ref detallePed, articulo, ref LogicaPedidos);
                        }

                    this.superGridControl1.PrimaryGrid.DataSource = LogicaPedidos.PedidoDetalles;
                    superGridControl1.PrimaryGrid.Columns["CANTIDADColumn"].DataPropertyName = "CantidadPedido";
                    LogicaPedidos.RecalculaDetalle(LogicaPedidos.PedidoDetalles, LogicaPedidos.Pedido);
                    break;
                case 2:
                    LogicaApartados.ApartadoM.PorcentajeDescuento = Descuento;

                    if (descuentoCredencial != null)
                    {
                        LogicaApartados.ApartadoM.TipoCambioID = descuentoCredencial.ID;
                        LogicaApartados.ApartadoM.PorcentajeDescuento = descuentoCredencial.Porcentaje;
                        LogicaApartados.ApartadoM.NumeroCredencial = descuentoCredencial.NumeroCredencial;
                    }

                    titleLabel.Text = "SIF\\Apartado/Reserva";
                    if (LogicaApartados.ApartadoM.VendedorID == 0)
                        this.LogicaApartados.ApartadoM.VendedorID = UsuarioID;
                    labelX7.Visible = false;
                    cmbTipopago.Visible = false;
                    labelX13.Visible = false;
                    txtimporte.Visible = false;
                    labelX8.Visible = false;
                    lblCambio.Visible = false;
                    if (this.LogicaApartados.ApartadoDetalles != null)
                        this.LogicaApartados.ApartadoDetalles.Clear();
                    foreach (GridContainer detalle in this.superGridControl1.PrimaryGrid.Rows)
                    {
                        GridRow fila = detalle as GridRow;

                        SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
                        SIFModelo.Articulo articulo = articuloL.BuscarPorClave(fila.Cells[0].Value.ToString());
                        if (articulo.TIPO_MEDICAMENTO_CVE.Contains("T3") || articulo.TIPO_MEDICAMENTO_CVE.Contains("S1") || articulo.TIPO_MEDICAMENTO_CVE.Contains("S2") || articulo.TIPO_MEDICAMENTO_CVE.Contains("S3") || articulo.TIPO_MEDICAMENTO_CVE.Contains("S4")) //articulo.TIPO_MEDICAMENTO_CVE.Contains("F1")
                        {
                            if (LogicaApartados.ApartadoM.Receta != SIFModelo.Tipos.SiNo.NO)
                            {
                               MessageBox.Show("informar que se requiere receta medica");
                                LogicaApartados.ApartadoM.Receta = SIFModelo.Tipos.SiNo.SI;
                            }

                        }

                        SIFModelo.ApartadoDetalle detalleApa = new SIFModelo.ApartadoDetalle();
                        detalleApa.ArticuloID = articulo.ARTICULO_ID;
                        detalleApa.Nombre1 = articulo.NOMBRE1;
                        detalleApa.Nombre2 = articulo.NOMBRE2;
                        if (fila.Cells[3].Value != null)
                            detalleApa.CantidadApartado = int.Parse(fila.Cells[3].Value.ToString());
                        else
                            detalleApa.CantidadApartado = 1;
                        this.PrecioArticulo(detalleApa, PorScosto);
                        // verificamos el inventario
                        SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
                        int existencias = 0;
                        BPedidoE = LogicaApartados.AgregaDetalle(detalleApa, articulo, BPedidoE);
                        LogicaApartados.RecalculaDetalle(LogicaApartados.ApartadoDetalles, LogicaApartados.ApartadoM);


                    }

                    this.superGridControl1.PrimaryGrid.DataSource = LogicaApartados.ApartadoDetalles;
                    superGridControl1.PrimaryGrid.Columns["CANTIDADColumn"].DataPropertyName = "CantidadApartado";
                    break;


            }
            // if (Cual == 0 || Cual == 3) descuentoCredencialButtonItem.Visible = false; else descuentoCredencialButtonItem.Visible = true;
            // bar1.Refresh();
            CalculaTotal();
        }
        #endregion

        #region Funciones y Metodos

        private bool validaExistencia()
        {
            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFNegocio.Inventario.Inventario inventarioL = new SIFNegocio.Inventario.Inventario();

            int sucursalID = (int)sucursalesComboBoxEx.SelectedValue;
            switch (Cual)
            {
                case 1:

                    foreach (var det in LogicaPedidos.PedidoDetalles)
                    {
                        SIFModelo.Articulo art = articuloL.BuscarPorClave(det.ArticuloID);
                        int existencias = 0;
                        if (LogicaPedidos.Pedido.SucursalID == Helpers.Sesion.Sucursal.SucursalID)
                        {
                            bool noSuficiente = inventarioL.InventarioArticulo(art, det.CantidadPedido, out existencias);
                            if (!noSuficiente)
                            {
                                return false;

                            }
                        }
                    }

                    break;

                case 2:
                    foreach (var det in LogicaApartados.ApartadoDetalles)
                    {
                        SIFModelo.Articulo art = articuloL.BuscarPorClave(det.ArticuloID);
                        int existencias = 0;
                        bool noSuficiente = inventarioL.InventarioArticulo(art, det.CantidadApartado, out existencias);
                        if (!noSuficiente)
                        {
                            return false;
                        }
                    }
                    break;
            }
            return true;
        }

        private void InicializaColumnas()
        {
            dataGrid = this.superGridControl1.PrimaryGrid;
            superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            GridIntegerInputEditControl cantidadColumn = superGridControl1.PrimaryGrid.Columns["CANTIDADColumn"].EditControl as GridIntegerInputEditControl;
            cantidadColumn.MinValue = 1;
            LogicaCotiza.CotizacionM.ClienteID = 0;

        }

        public void AgregaArticulo(string claveArticulo)
        {
            if (string.IsNullOrEmpty(claveArticulo))
            {
                return;
            }

            /*SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(claveArticulo);
            */
            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = null;
            if (ClienteSub == null)
                articulo = articuloL.BuscarPorClave(claveArticulo);
            else
            {

                if (articuloL.MasDeUnoPorClaveSub(claveArticulo, ClienteSub.ID.ToString()))
                {
                    //this.SeleccionaArticuloSubrogacion();
                    //return;
                    articulo = articuloL.BuscarPorClaveSub(claveArticulo, claveArticulo, ClienteSub.ID.ToString());
                }
                else
                {
                    if (articuloL.MasDeUnoPorArticuloSub(claveArticulo, ClienteSub.ID.ToString()))
                    {
                        //this.SeleccionaArticuloSubrogacion(true);
                        //return;
                        articulo = articuloL.BuscarPorClaveSub(claveArticulo, claveArticulo, ClienteSub.ID.ToString());
                    }
                    else
                    {
                        articulo = articuloL.BuscarPorClaveSub(claveArticulo, claveArticulo, ClienteSub.ID.ToString());
                    }
                }
            }

         
            if (articulo == null)
            {
               MessageBox.Show("El artículo no existe en el catalogo");
                return;
            }

            this.AgregaArticulo(articulo);
        }


        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            if (LogicaCotiza.CotizacionM.SucursalID == 0)
            {
                int sucursalID = (int)sucursalesComboBoxEx.SelectedValue;
                LogicaCotiza.CotizacionM.SucursalID = sucursalID;
            }

            if (!articulo.LISTA_SUCURSAL_VTA.Contains(this.LogicaCotiza.CotizacionM.SucursalID.ToString()))
            {
               MessageBox.Show("El artículo no está permitido en esta sucursal");
                return;
            }

            if (articulo == null)
            {
                return;
            }

            if (!this.cantidadTextBoxX.Text.ToString().IsIntegerPositive())
            {
                cantidadTextBoxX.Text = "1";
            }

            this.CodigoTextBoxX.Text = articulo.ARTICULO_ID;
            switch (Cual)
            {
                case 0:
                case 3:
                case 4:
                    SIFModelo.CotizacionDetalle detalle = new SIFModelo.CotizacionDetalle();
                    detalle.ArticuloID = articulo.ARTICULO_ID;
                    detalle.Nombre1 = articulo.NOMBRE1;
                    detalle.Nombre2 = articulo.NOMBRE2;
                    detalle.CantidadCotizacion = detalle.CantidadCotizacion + int.Parse(this.cantidadTextBoxX.Text);
                    this.PrecioArticulo(detalle, PorScosto);
                    LogicaCotiza.AgregaDetalle(detalle);
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaCotiza.CotizacionDetalles;
                    break;
                case 1:
                    if (articulo.TIPO_MEDICAMENTO_CVE.Contains("F1") || articulo.TIPO_MEDICAMENTO_CVE.Contains("F1") || articulo.TIPO_MEDICAMENTO_CVE.Contains("F1") || articulo.TIPO_MEDICAMENTO_CVE.Contains("F1") || articulo.TIPO_MEDICAMENTO_CVE.Contains("S4"))
                    {
                        View.Ventas.RecetaMedicoForm frmrec = new View.Ventas.RecetaMedicoForm();
                        //pedimos el folio de la receta
                       /* if (LogicaPedidos.Pedido.Receta != SIFModelo.Tipos.SiNo.NO)
                        {
                            

                            if (articulo.TIPO_MEDICAMENTO_CVE.Contains("S4"))
                            {
                                frmrec.causaLabelX.Text = "ANTIBIOTICO";
                            }

                            if (articulo.TIPO_MEDICAMENTO_CVE.Contains("S1") || articulo.TIPO_MEDICAMENTO_CVE.Contains("S2") || articulo.TIPO_MEDICAMENTO_CVE.Contains("S3"))
                            {
                                frmrec.causaLabelX.Text = "MEDICAMENTO CONTROLADO";
                            }*/
                            frmrec.ShowDialog();
                            
                        LogicaPedidos.Pedido.Receta = SIFModelo.Tipos.SiNo.SI;
                     //   }/// VMJA  DES
                    }

                  //  if (articulo.TIPO_MEDICAMENTO_CVE.Contains("SD"))//Esta linea se escribió en otra parte del código
                      ///  MessageBox.Show("Este producto no aplica descuento");

                    SIFModelo.PedidoDetalle detallePed = new SIFModelo.PedidoDetalle();
                    detallePed.ArticuloID = articulo.ARTICULO_ID;
                    detallePed.Nombre1 = articulo.NOMBRE1;
                    detallePed.Nombre2 = articulo.NOMBRE2;
                    detallePed.CantidadPedido = int.Parse(this.cantidadTextBoxX.Text);
                    this.PrecioArticulo(detallePed, PorScosto);
                    int sucursalID2 = (int)sucursalesComboBoxEx.SelectedValue;
                    if (sucursalID2 != Helpers.Sesion.Sucursal.SucursalID)
                    {
                        articulo.VTA_SIN_EXISTENCIA = SIFModelo.Tipos.SiNo.SI;
                    }
                    LogicaPedidos.AgregaDetalle(ref detallePed, articulo, ref LogicaPedidos);
                    LogicaPedidos.RecalculaDetalle(detallePed, LogicaPedidos.Pedido);
                    this.reportarFaltantes();
                    this.CalculaTotal();
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaPedidos.PedidoDetalles;
                    superGridControl1.PrimaryGrid.Columns["CANTIDADColumn"].DataPropertyName = "CantidadPedido";
                    break;
                case 2:

                    if (articulo.TIPO_MEDICAMENTO_CVE.Contains("T3") || articulo.TIPO_MEDICAMENTO_CVE.Contains("S1") || articulo.TIPO_MEDICAMENTO_CVE.Contains("S2") || articulo.TIPO_MEDICAMENTO_CVE.Contains("S3") || articulo.TIPO_MEDICAMENTO_CVE.Contains("S4"))
                    {
                        if (LogicaApartados.ApartadoM.Receta != SIFModelo.Tipos.SiNo.NO)
                        {
                           MessageBox.Show("informar que se requiere receta medica");
                            LogicaApartados.ApartadoM.Receta = SIFModelo.Tipos.SiNo.SI;
                        }
                    }
                    if (articulo.TIPO_MEDICAMENTO_CVE.Contains("SD"))
                        MessageBox.Show("Este producto no aplica descuento");
                    SIFModelo.ApartadoDetalle detalleApa = new SIFModelo.ApartadoDetalle();
                    detalleApa.ArticuloID = articulo.ARTICULO_ID;
                    detalleApa.Nombre1 = articulo.NOMBRE1;
                    detalleApa.Nombre2 = articulo.NOMBRE2;
                    detalleApa.CantidadApartado = int.Parse(this.cantidadTextBoxX.Text);
                    this.PrecioArticulo(detalleApa, PorScosto);
                    // verificamos el inventario
                    SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
                    int existencias = 0;

                    BPedidoE = LogicaApartados.AgregaDetalle(detalleApa, articulo, BPedidoE);
                    LogicaApartados.RecalculaDetalle(detalleApa, LogicaApartados.ApartadoM);
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaApartados.ApartadoDetalles;
                    superGridControl1.PrimaryGrid.Columns["CANTIDADColumn"].DataPropertyName = "CantidadApartado";
                    break;
            }


            this.CalculaTotal();
            this.CodigoTextBoxX.SelectAll();
            this.cantidadTextBoxX.Text = "1";
            CodigoTextBoxX.Focus();
        }

        private bool PrecioArticulo(SIFModelo.CotizacionDetalle detalle, Decimal PorSCosto)
        {
            SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
            if (precios == null)
            {
               MessageBox.Show("No hay un precio activo para este producto");
                return false;
            }
            else
            {
                SIFModelo.Articulo articulop = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
                //MessageBox.Show("Controlando descuento SD sobre costo APARTADO");
                if (PorScosto > 0 && !articulop.TIPO_MEDICAMENTO_CVE.ToString().Contains("SD"))//L 20/12/2013 No aplicar porcentaje sobre costo si es SD
                {

                    detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_COSTO + (precios.PRECIO_COSTO * PorScosto / 100));
                    detalle.Total = detalle.CantidadCotizacion * detalle.Precio;
                    detalle.PrecioCosto = precios.PRECIO_COSTO;
                    detalle.PrecioVta = precios.PRECIO_VENTA;
                    if (detalle.Precio == 0)
                    {
                       MessageBox.Show("El precio del producto es cero", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //return false;
                    }

                    detalle.ImpuestoID = precios.IMP_VENTA;
                    SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);
                    if (impuesto != null)
                    {
                        decimal calculaImpuesto = detalle.Total * (impuesto.Porcentaje / 100m);

                        detalle.IVA = calculaImpuesto;
                    }
                }
                else 
                {
                    
               // }
               // else
                //{
                    if (PorScosto > 0 && articulop.TIPO_MEDICAMENTO_CVE.ToString().Contains("SD"))
                    { 
                        MessageBox.Show("Este producto no aplica descuento: " + articulop.ARTICULO_ID + " " + articulop.NOMBRE1); 
                    }

                    detalle.Precio = precios.PRECIO_VENTA;
                    detalle.Total = detalle.CantidadCotizacion * detalle.Precio;
                    detalle.PrecioCosto = precios.PRECIO_COSTO;
                    detalle.PrecioVta = precios.PRECIO_VENTA;
                    if (detalle.Precio == 0)
                    {
                       MessageBox.Show("El precio del producto es cero", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //return false;
                    }

                    detalle.ImpuestoID = precios.IMP_VENTA;
                    SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);
                    if (impuesto != null)
                    {
                        decimal calculaImpuesto = detalle.Total * (impuesto.Porcentaje / 100m);

                        detalle.IVA = calculaImpuesto;
                    }
                }
            }
            return true;
        }


        private bool PrecioArticulo(SIFModelo.PedidoDetalle detalle, Decimal PorSCosto)
        {
            if (ClienteSub == null)
            {
                SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
                if (precios == null)
                {
                   MessageBox.Show("No hay un precio activo para este producto");
                    return false;
                }
                SIFModelo.Articulo articulop = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
                //MessageBox.Show("Controlando descuento SD sobre costo PEDIDO");
                if (PorScosto > 0 && !articulop.TIPO_MEDICAMENTO_CVE.ToString().Contains("SD"))//L 20/12/2013 No aplicar porcentaje sobre costo si es SD
                {

                    detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_COSTO + (precios.PRECIO_COSTO * PorScosto / 100));
                    detalle.Total = detalle.CantidadPedido * detalle.Precio;
                    detalle.PrecioCosto = precios.PRECIO_COSTO;
                    //detalle.Precio = precios.PRECIO_VENTA;
                    if (detalle.Precio == 0)
                    {
                       MessageBox.Show("El precio del producto es cero", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //return false;
                    }

                    detalle.ImpuestoID = precios.IMP_VENTA;
                    SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);
                    if (impuesto != null)
                    {
                        decimal calculaImpuesto = detalle.Total * (impuesto.Porcentaje / 100m);

                        detalle.IVA = calculaImpuesto;
                    }
                }
                else
                {
                    detalle.Precio = precios.PRECIO_VENTA;
                    detalle.Total = detalle.CantidadPedido * detalle.Precio;
                    if (detalle.Precio == 0)
                    {
                       MessageBox.Show("El precio del producto es cero", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //return false;
                    }

                    detalle.ImpuestoID = precios.IMP_VENTA;
                    SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);
                    if (impuesto != null)
                    {
                        decimal calculaImpuesto = detalle.Total * (impuesto.Porcentaje / 100m);

                        detalle.IVA = calculaImpuesto;
                    }
                }
            }
            else
            {
                decimal precio = new SIFNegocio.Articulo().ArticuloPorClaveSubPrecio(detalle.ArticuloID, ClienteSub.ID.ToString());
                SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecioSub(detalle.ArticuloID);
                precios.PRECIO_VENTA = precio;
                detalle.Precio = precios.PRECIO_VENTA;
                //if (detalle.Precio == 0)
                //    detalle.Precio = precios.PRECIO_VENTA;
                decimal importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.CantidadPedido * detalle.Precio);


                if (precios != null)
                {
                    SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);

                    if (impuesto != null)
                    {
                        // detalle.Precio = detalle.Precio / (1 + (impuesto.Porcentaje / 100m));
                        //detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                        importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.CantidadPedido * detalle.Precio);

                        //detalle.Precio = detalle.Precio / (1 + (impuesto.Porcentaje / 100m));
                        detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                        decimal descuento = 0;
                        // decimal importeSIva = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((importe - descuento) / (1 + (impuesto.Porcentaje / 100m)));
                        decimal ImpAntesIva = importe / (1 + (impuesto.Porcentaje / 100m));

                        ImpAntesIva = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(ImpAntesIva);

                        decimal calculaImpuesto = importe - ImpAntesIva;
                        detalle.IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(calculaImpuesto);


                    }
                    else
                    {
                       MessageBox.Show("No se ha especificado el tipo de impuesto para el artículo " + detalle.ArticuloID + " [" + detalle.Nombre1 + "]");
                    }
                }

                //SIFModelo.Descuento descuento = 
                detalle.Total = importe;
            }
            return true;
        }

        private bool PrecioArticulo(SIFModelo.ApartadoDetalle detalle, Decimal PorSCosto)
        {
            SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
            if (precios == null)
            {
               MessageBox.Show("No hay un precio activo para este producto");
                return false;
            }
            SIFModelo.Articulo articulop = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
            //MessageBox.Show("Controlando descuento SD sobre costo APARTADO");
            if (PorScosto > 0 && !articulop.TIPO_MEDICAMENTO_CVE.ToString().Contains("SD"))//L 20/12/2013 no aplicar porcentaje sobre costo en caso de que el producto sea SD
            {

                detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_COSTO + (precios.PRECIO_COSTO * PorScosto / 100));
                detalle.Total = detalle.CantidadApartado * detalle.Precio;
                detalle.PrecioCosto = precios.PRECIO_COSTO;
                //detalle.Precio = precios.PRECIO_VENTA;
                if (detalle.Precio == 0)
                {
                   MessageBox.Show("El precio del producto es cero", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return false;
                }

                detalle.ImpuestoID = precios.IMP_VENTA;
                SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);
                if (impuesto != null)
                {
                    decimal calculaImpuesto = detalle.Total * (impuesto.Porcentaje / 100m);

                    detalle.IVA = calculaImpuesto;
                }
            }
            else
            {
                detalle.Precio = precios.PRECIO_VENTA;
                detalle.Total = detalle.CantidadApartado * detalle.Precio;
                if (detalle.Precio == 0)
                {
                   MessageBox.Show("El precio del producto es cero", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return false;
                }

                detalle.ImpuestoID = precios.IMP_VENTA;
                SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);
                if (impuesto != null)
                {
                    decimal calculaImpuesto = detalle.Total * (impuesto.Porcentaje / 100m);

                    detalle.IVA = calculaImpuesto;
                }
            }
            return true;
        }

        private void SeleccionaArticulo()
        {

            View.Articulos.ArticuloUserControl frmArticulo = new Articulos.ArticuloUserControl();
            frmArticulo.Dock = DockStyle.Fill;
            frmArticulo.Owner = this;
            this.DesactivaComandos();
            frmArticulo.Muestra();
            //this.ActivaComandos();

        }

        private void Guardar()
        {
            int G = 0;
            int sucursalID = (int)sucursalesComboBoxEx.SelectedValue;
            switch (Cual)
            {
                case 0:
                case 3:
                case 4:
                    if (Cual == 3 || Cual == 4)
                        if (LogicaCotiza.CotizacionM.ClienteID == 0 || LogicaCotiza.CotizacionM.ClienteID == 1 || LogicaCotiza.CotizacionM.ClienteID == 0)
                        {
                            this.SeleccionaCliente();
                            return;
                        }
                        else
                        {
                            SIFModelo.Cliente clienteSeleccionado = new SIFNegocio.Clientes().ClientePorID(LogicaCotiza.CotizacionM.ClienteID);
                            SIFModelo.DireccionCliente dirCasa = new SIFNegocio.Clientes().DireccionCliente(clienteSeleccionado, SIFModelo.Tipos.TipoDireccion.casa);

                            if (dirCasa == null)
                            {
                               MessageBox.Show("Debe agregar la dirección de casa para la entrega de pedido");

                                clienteSeleccionado.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                                Catalogos.DireccionClienteForm frmDir = new Catalogos.DireccionClienteForm(clienteSeleccionado);
                                frmDir.ShowDialog();
                                return;
                            }

                            // return;
                        }
                    this.CalculaTotal();
                    LogicaCotiza.CotizacionM.VendedorID = Helpers.Sesion.Usuario.UsuariosID;
                    if (PCotiza == null)
                        LogicaCotiza.CotizacionM.NumeroCotizacion = LogicaCotiza.NumeroCotizacion(sucursalID);
                    else
                        LogicaCotiza.Elimina(LogicaCotiza.CotizacionM);
                    LogicaCotiza.CotizacionM.SucursalID = sucursalID;
                    LogicaCotiza.CotizacionM.VendedorID = UsuarioID;
                    LogicaCotiza.CotizacionM.Comentario = textBoxX1.Text;
                    if (Cual == 3)
                        LogicaCotiza.CotizacionM.TipoCotizacion = SIFModelo.Tipos.TipoCotizacion.CONVENIO;
                    else
                        if (Cual == 4)
                            LogicaCotiza.CotizacionM.TipoCotizacion = SIFModelo.Tipos.TipoCotizacion.SUBRROGACION;
                        else
                            LogicaCotiza.CotizacionM.TipoCotizacion = SIFModelo.Tipos.TipoCotizacion.CALLCENTER;
                    LogicaCotiza.CotizacionM.Activo = SIFModelo.Tipos.SiNo.SI;
                    G = LogicaCotiza.GuardaDatos(LogicaCotiza);

                    break;
                case 1:
                    if (LogicaPedidos.Pedido.ClienteID == 0 || LogicaPedidos.Pedido.ClienteID == 1 || LogicaPedidos.Pedido.ClienteID == 0)
                    {
                        this.SeleccionaCliente();
                        return;
                    }
                    else
                    {
                        SIFModelo.Cliente clienteSeleccionado = new SIFNegocio.Clientes().ClientePorID(LogicaPedidos.Pedido.ClienteID);
                        SIFModelo.DireccionCliente dirCasa = new SIFNegocio.Clientes().DireccionCliente(clienteSeleccionado, SIFModelo.Tipos.TipoDireccion.casa);

                        if (dirCasa == null)
                        {
                           MessageBox.Show("Debe agregar la dirección de casa para la entrega de pedido");

                            clienteSeleccionado.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                            Catalogos.DireccionClienteForm frmDir = new Catalogos.DireccionClienteForm(clienteSeleccionado);
                            frmDir.ShowDialog();
                            return;
                        }

                        // return;
                    }

                    //   Opciones();

                    if (txtimporte.Text.IsFloat())
                    {
                        //this.CalculaTotal(); L 23/12/2013 ?! PARA NO MODIFICAR EL IMPORTE PAGA CON 
                        if (decimal.Parse(txtimporte.Text) < LogicaPedidos.Pedido.Total)
                        {
                           MessageBox.Show("Debe ser mayor el importe de pago");
                            return;
                        }
                        else
                        {
                            sucursalID = (int)sucursalesComboBoxEx.SelectedValue;
                            LogicaPedidos.Pedido.NumeroPedido = LogicaPedidos.NumeroPedido(sucursalID);
                            LogicaPedidos.Pedido.SucursalID = int.Parse(sucursalesComboBoxEx.SelectedValue.ToString());
                            LogicaPedidos.Pedido.TipoPagoID = int.Parse(cmbTipopago.SelectedValue.ToString());
                            LogicaPedidos.Pedido.TotalPago = decimal.Parse(txtimporte.Text);
                            LogicaPedidos.Pedido.VendedorID = this.UsuarioID;
                            LogicaPedidos.Pedido.Comentario = textBoxX1.Text;
                            if (!validaExistencia())
                            {
                                return;
                            }
                            G = LogicaPedidos.GuardaDatos(LogicaPedidos);
                        }
                    }
                    else
                    {
                       MessageBox.Show("Debe dar un importe de pago");
                        return;
                    }
                    break;
                case 2:
                    if (LogicaApartados.ApartadoM.ClienteID == 0 || LogicaApartados.ApartadoM.ClienteID == 1 || LogicaApartados.ApartadoM.ClienteID == 0)
                    {
                        this.SeleccionaCliente();
                        return;
                    }

                    this.CalculaTotal();
                    LogicaApartados.ApartadoM.NumeroApartado = LogicaApartados.NumeroApartado(sucursalID);
                    LogicaApartados.ApartadoM.SucursalID = sucursalID;
                    LogicaApartados.ApartadoM.VendedorID = UsuarioID;
                    LogicaApartados.ApartadoM.Comentario = textBoxX1.Text;

                    if (BPedidoE)
                    {
                        //pedidomos el importe a apartar he ingresamos la cantidad al apartado
                        View.Ventas.ImporteApartadoUser frmImporte = new ImporteApartadoUser();
                        if (frmImporte.ShowDialog() != DialogResult.OK)
                            return;
                        else
                        {
                            if (frmImporte.Importe > 0)
                                LogicaApartados.ApartadoM.Anticipo = frmImporte.Importe;
                            else
                                LogicaApartados.ApartadoM.Anticipo = 1;
                        }
                    }
                    else
                        LogicaApartados.ApartadoM.Anticipo = 0;
                    if (!validaExistencia() && (LogicaApartados.ApartadoM.Anticipo == 0))
                    {
                        return;
                    }
                    G = LogicaApartados.GuardaDatos(LogicaApartados);
                    break;
            }

            if (G == 0)
            {
                switch (Cual)
                {
                    case 0:
                    case 3:
                    case 4:
                       MessageBox.Show("La cotización " + LogicaCotiza.CotizacionM.NumeroCotizacion + " se ha creado");
                        break;
                    case 1:
                       MessageBox.Show("El Pedido " + LogicaPedidos.Pedido.NumeroPedido + " se ha creado");
                        break;
                    case 2:
                       MessageBox.Show("El Apartado " + LogicaApartados.ApartadoM.NumeroApartado + " se ha creado");
                        break;
                }
                Pasa = true;
                this.Limpiar();
            }
            else
            {
                switch (G)
                {
                    case 1:
                       MessageBox.Show("Agregue elementos al detalle");
                        break;
                    case 2:
                       MessageBox.Show("Debe elegir un cliente");
                        break;
                    case 3:
                    case 4:
                       MessageBox.Show("Hubo un error al insertar Los datos");
                        break;
                }


            }

            descuentoCredencial = null;
        }

        private void Limpiar()
        {
            this.LogicaCotiza = new SIFNegocio.Cotizacion();
            this.LogicaPedidos = new SIFNegocio.Pedidos();
            this.LogicaApartados = new SIFNegocio.Apartado();

            this.ClienteID = 0;
            this.fTotal = 0;
            Descuento = 0;

            this.clienteLabelX.Text = "";
            this.clienteN = new SIFNegocio.ClienteConvenios();
            this.CodigoTextBoxX.Text = "";
            this.cmbTipopago.SelectedIndex = 0;
            this.conFacturaCheckBox.Checked = false;
            this.RFClabelX.Text = "XX001001XX";
            this.CodigoTextBoxX.Clear();
            radioButton2.Checked = true;
            cantidadTextBoxX.Text = "1";
            this.sucursalesComboBoxEx.Text=  SIF.Helpers.Sesion.Sucursal.Nombre;
            

            this.totalLetraLabelX.Text = "";
            descuentoCredencial = null;


            LogicaPedidos.Pedido.Descuento = 0;
            LogicaCotiza.CotizacionM.Descuento = 0;
            LogicaApartados.ApartadoM.Descuento = 0;
            LblDescuento.Text = "";
            //folioCotizacionLabelX.Text = "";
            dataGrid.DataSource = null;
            LogicaPedidos.PedidoDetalles.Clear();
            LogicaApartados.ApartadoDetalles.Clear();
            LogicaCotiza.CotizacionDetalles.Clear();

            dataGrid.DataSource = LogicaPedidos.PedidoDetalles;
            superGridControl1.PrimaryGrid.DataSource = null;
            superGridControl1.PrimaryGrid.DataSource = LogicaPedidos.PedidoDetalles;
            superGridControl1.Update();
            lblCambio.Text = "0.00";
           // Opciones();
            buscarTextBoxX.Focus();

            statusLabel.Text = "";
        }

        private void MuestraGenerado(object sender)
        {
            CofirmacionForm frmConfirmacion = new CofirmacionForm();
            SIFModelo.Cliente cliente = new SIFModelo.Cliente();
            SIFModelo.DireccionCliente direccion = new SIFModelo.DireccionCliente();

            if (sender is SIFModelo.Cotizacion)
            {
                SIFModelo.Cotizacion cotizacion = new SIFNegocio.Cotizacion().CargaCotizacion((SIFModelo.Cotizacion)sender, Helpers.Sesion.Sucursal);
                cliente = new SIFNegocio.Clientes().ClientePorID(cotizacion.ClienteID);
                direccion = new SIFNegocio.Clientes().DireccionCliente(cliente, SIFModelo.Tipos.TipoDireccion.casa);

                frmConfirmacion.tipoLabelX.Text = "COTIZACIÓN";
                frmConfirmacion.folioLabelX.Text = cotizacion.NumeroCotizacion;
                frmConfirmacion.clienteLabelX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
                frmConfirmacion.direccionLabelX.Text = direccion.Calle + " " + direccion.NumeroExterior + " " + direccion.NumeroInterior + " Col. : " + direccion.Colonia + " Tel. " + direccion.Telefono;
            }


        }

        private bool esClienteMostrador()
        {
            if (conCliente)
            {
                return false;
            }
            switch (Cual)
            {
                case 0:
                case 3:
                case 4:
                    if (this.LogicaCotiza.CotizacionM.ClienteID == 0 || this.LogicaCotiza.CotizacionM.ClienteID == 1 || this.LogicaCotiza.CotizacionM.ClienteID == 0)
                        return true;
                    break;
                case 1:
                    if (LogicaPedidos.Pedido.ClienteID == 0 || LogicaPedidos.Pedido.ClienteID == 1)
                        return true;
                    break;
                case 2:
                    if (LogicaApartados.ApartadoM.ClienteID == 0 || LogicaApartados.ApartadoM.ClienteID == 1)
                        return true;
                    break;

            }
            return false;
        }

        private bool Eliminar()
        {


            DialogResult resp = DialogResult.No;


            if (this.superGridControl1.PrimaryGrid.GetSelectedRows().Count > 0)
            {
               resp =MessageBox.Show("¿Eliminar los productos seleccinados?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            
            if (this.superGridControl1.PrimaryGrid.GetSelectedRows().Count == 0)
            {
               resp =MessageBox.Show("¿Cancelar toda la transacción?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (resp != DialogResult.Yes)
            {
                return false;
            }

            if (this.superGridControl1.PrimaryGrid.GetSelectedRows().Count == 0)
            {
                switch (Cual)
                {
                    case 0:
                    case 3:
                    case 4:
                        LogicaCotiza.CotizacionM.Descuento = 0;
                        LogicaCotiza.CotizacionDetalles.Clear();
                        LogicaCotiza.RecalculaDetalle(LogicaCotiza.CotizacionDetalles, LogicaCotiza.CotizacionM);
                        break;
                    case 1:
                        LogicaPedidos.Pedido.Descuento = 0;
                        LogicaPedidos.PedidoDetalles.Clear();
                        LogicaPedidos.RecalculaDetalle(LogicaPedidos.PedidoDetalles, LogicaPedidos.Pedido);
                        break;
                    case 2:
                        LogicaApartados.ApartadoM.Descuento = 0;
                        LogicaApartados.ApartadoDetalles.Clear();
                        LogicaApartados.RecalculaDetalle(LogicaApartados.ApartadoDetalles, LogicaApartados.ApartadoM);
                        break;
                }
                //return true;

                Limpiar();
            }
            else
            {
                var seleccionadas = this.superGridControl1.PrimaryGrid.SelectedRows;


                //List<SIFModelo.CotizacionDetalle> detalles = new List<SIFModelo.CotizacionDetalle>();
                //forreach (GridRow fila in seleccionadas)
                //{
                //    if (fila == null)
                //    {
                //        continue;
                //    }
                //  detalles.Add(  fila.DataItem as SIFModelo.CotizacionDetalle);
                //}

                foreach (GridContainer detalle in seleccionadas)
                {
                    GridRow fila = detalle as GridRow;
                    if (fila == null)
                    {
                        continue;
                    }

                    switch (Cual)
                    {
                        case 0:
                        case 3:
                        case 4:
                            LogicaCotiza.CotizacionM.Descuento = 0;
                            LogicaCotiza.CotizacionDetalles.Remove(fila.DataItem as SIFModelo.CotizacionDetalle);
                            LogicaCotiza.RecalculaDetalle(LogicaCotiza.CotizacionDetalles, LogicaCotiza.CotizacionM);
                            break;
                        case 1:
                            LogicaPedidos.Pedido.Descuento = 0;
                            LogicaPedidos.PedidoDetalles.Remove(fila.DataItem as SIFModelo.PedidoDetalle);
                            LogicaPedidos.RecalculaDetalle(LogicaPedidos.PedidoDetalles, LogicaPedidos.Pedido);
                            break;
                        case 2:
                            LogicaApartados.ApartadoM.Descuento = 0;
                            LogicaApartados.ApartadoDetalles.Remove(fila.DataItem as SIFModelo.ApartadoDetalle);
                            LogicaApartados.RecalculaDetalle(LogicaApartados.ApartadoDetalles, LogicaApartados.ApartadoM);
                            break;
                    }
                }

                this.reordenaPartida();
            }
            switch (Cual)
            {
                case 0:
                case 3:
                case 4:
                    superGridControl1.PrimaryGrid.DataSource = LogicaCotiza.CotizacionDetalles;
                    break;
                case 1:
                    superGridControl1.PrimaryGrid.DataSource = LogicaPedidos.PedidoDetalles;
                    break;
                case 2:
                    superGridControl1.PrimaryGrid.DataSource = LogicaApartados.ApartadoDetalles;
                    break;
            }
            this.CalculaTotal();


            
            return true;
        }

        private void reordenaPartida()
        {
            switch (Cual)
            {
                case 0:
                case 3:
                case 4:
                    for (int p = 0; p < LogicaCotiza.CotizacionDetalles.Count; p++)

                        LogicaCotiza.CotizacionDetalles[p].NumeroPartida = p + 1;
                    break;
                case 1:
                    for (int p = 0; p < LogicaPedidos.PedidoDetalles.Count; p++)
                        LogicaPedidos.PedidoDetalles[p].NumeroPartida = p + 1;
                    break;
                case 2:
                    for (int p = 0; p < LogicaApartados.ApartadoDetalles.Count; p++)
                        LogicaApartados.ApartadoDetalles[p].NumeroPartida = p + 1;
                    break;
            }
        }

        private void ModificaCantidadArticulo()
        {
            if (string.IsNullOrEmpty(this.CodigoTextBoxX.Text))
            {
               MessageBox.Show("Ingrese la clave del producto");
                this.CodigoTextBoxX.Focus();
                return;
            }

            if (!cantidadTextBoxX.Text.IsInteger())
            {
               MessageBox.Show("La cantidad no es válida");
                this.cantidadTextBoxX.SelectAll();
                this.cantidadTextBoxX.Focus();
                return;
            }


            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Debe seleccionar el artículo a modificar");
                return;
            }
            string claveArticulo = "";
            switch (Cual)
            {
                case 0:
                case 3:
                case 4:
                    SIFModelo.CotizacionDetalle detalle = ((GridRow)this.superGridControl1.PrimaryGrid.ActiveRow).DataItem as SIFModelo.CotizacionDetalle;
                    claveArticulo = detalle.ArticuloID;
                    break;
                case 1:
                    SIFModelo.PedidoDetalle detallePed = ((GridRow)this.superGridControl1.PrimaryGrid.ActiveRow).DataItem as SIFModelo.PedidoDetalle;
                    claveArticulo = detallePed.ArticuloID;
                    break;
                case 2:
                    SIFModelo.ApartadoDetalle detallApart = ((GridRow)this.superGridControl1.PrimaryGrid.ActiveRow).DataItem as SIFModelo.ApartadoDetalle;
                    claveArticulo = detallApart.ArticuloID;
                    break;
            }

            int cantidad = int.Parse(cantidadTextBoxX.Text);
            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(claveArticulo);

            if (articulo == null)
            {
               MessageBox.Show("El artículo no existe en el catalogo");
                return;
            }

            switch (Cual)
            {
                case 0:
                case 3:
                case 4:
                    if (!LogicaCotiza.ContieneDetalle(articulo))
                    {
                        this.AgregaArticulo(articulo);
                        //return;
                    }

                    LogicaCotiza.ModificaCantidad(articulo, cantidad);
                    break;
                case 1:
                    if (LogicaPedidos.ContieneDetalle(articulo))
                        this.AgregaArticulo(articulo);
                    //LogicaPedidos.ModificaCantidad(articulo, cantidad);

                    break;
                case 2:
                    if (LogicaApartados.ContieneDetalle(articulo))
                        this.AgregaArticulo(articulo);
                    //LogicaApartados.ModificaCantidad(articulo, cantidad);
                    break;


            }

            this.CalculaTotal();
            superGridControl1.Refresh();

            this.cantidadTextBoxX.Text = "1";
            this.CodigoTextBoxX.Focus();
        }



        View.Catalogos.ClienteControl frmCliente;
        private bool Mostrado;
        private bool p;
        private int ClienteID;
        private void SeleccionaCliente()
        {


            if (frmCliente == null)
            {
                frmCliente = new View.Catalogos.ClienteControl();
                frmCliente.Dock = DockStyle.Fill;
                frmCliente.Owner = this;
            }
            frmCliente.Muestra();


        }

        internal void AgregaCliente(SIFModelo.Cliente cliente)
        {
            
            switch (Cual)
            {
                case 0:
                case 3:
                case 4:
                    this.LogicaCotiza.CotizacionM.ClienteID = cliente.ID;
                    SIFModelo.DireccionCliente dirCliente = new SIFNegocio.Clientes().DireccionCliente(cliente, SIFModelo.Tipos.TipoDireccion.fiscal);

                    if (dirCliente != null)
                        this.RFClabelX.Text = dirCliente.RFC;
                    else
                        this.RFClabelX.Text = "";

                    //verificamos si es cliente convenio y obtenemos el descuento de la tabla
                    if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
                    {
                        LogicaCotiza.CotizacionM.Descuento = 0;

                        this.conFacturaCheckBox.Checked = true;
                        this.conFacturaCheckBox_CheckedChanged(conFacturaCheckBox, null);
                        ConvenioCliente = clienteN.ClientePorID(cliente.ID);
                        if (ConvenioCliente != null)
                        {
                            Descuento = ConvenioCliente.PorDesc;
                            PorScosto = ConvenioCliente.PorScosto;
                            this.LogicaCotiza.CotizacionM.PorcentajeDescuento = ConvenioCliente.PorDesc;

                            foreach (SIFModelo.CotizacionDetalle articulo in this.LogicaCotiza.CotizacionDetalles)
                            {
                                this.PrecioArticulo(articulo, PorScosto);
                            }

                            CalculaTotal();
                        }
                        else
                           MessageBox.Show("El Cliente Convenio no tiene datos favor de verificar", "Convenio", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    if (Cual == 4)
                        if (cliente.SUBROGACION == SIFModelo.Tipos.SiNo.SI)
                        {
                            ConvenioCliente = clienteN.ClientePorID(cliente.ID);
                            if (ConvenioCliente != null)
                            {
                                Descuento = ConvenioCliente.PorDesc;
                                PorScosto = ConvenioCliente.PorScosto;
                                this.LogicaCotiza.CotizacionM.PorcentajeDescuento = ConvenioCliente.PorDesc;
                            }
                            else
                               MessageBox.Show("El Cliente Convenio no tiene datos favor de verificar", "Convenio", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    foreach (SIFModelo.CotizacionDetalle detalle in LogicaCotiza.CotizacionDetalles)
                    {
                        this.PrecioArticulo(detalle, PorScosto);
                        LogicaCotiza.RecalculaDetalle(detalle, LogicaCotiza.CotizacionM);
                    }
                    this.CalculaTotal();
                    break;
                case 1:
                    {
                        //L 20/12/2013 AL SELECCIONAR UN NUEVO CLIENTE SE REESTABLECEN LOS DECUENTOS
                        //MessageBox.Show(LogicaPedidos.Pedido.Descuento.ToString());
                        if (LogicaPedidos.Pedido.PorcentajeDescuento > 0)
                        {
                            LogicaPedidos.Pedido.Descuento = 0;
                            LogicaPedidos.Pedido.PorcentajeDescuento = 0;
                            this.statusLabel.Text = "";
                            MessageBox.Show("Se reestablecerá el descuento");
                        }
                        //MessageBox.Show(LogicaPedidos.Pedido.Descuento.ToString());
                        this.statusLabel.Text = "";

                        this.LogicaPedidos.Pedido.ClienteID = cliente.ID;
                        // mostramos la direccion del cliente para que la cambie en caso de que la neseciten cambiar

                        SIFModelo.DireccionCliente dirCasa = new SIFModelo.DireccionCliente();
                        SIFModelo.DireccionCliente dirFiscal = new SIFModelo.DireccionCliente();
                        cliente.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                        // dirCasa  = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);
                        Catalogos.DireccionClienteForm frmCliente = new Catalogos.DireccionClienteForm(cliente);
                        if (frmCliente.ShowDialog() != DialogResult.OK)
                            return;
                        //LogicaPedidos.Pedido.Descuento = 0;//L 15/12/2013
                        //MessageBox.Show("Se reestablecerá el descuento");
                        Descuento = PorScosto = 0;//L 16/12/2013 para evitar que al cambiar de cliente siga tomando precio convenio
                        //MessageBox.Show(LogicaPedidos.Pedido.Descuento.ToString());
                        //LogicaPedidos.Pedido.Descuento = 0;
                        //MessageBox.Show(LogicaPedidos.Pedido.Descuento.ToString());
                        cliente = new SIFNegocio.Clientes().ClientePorID(cliente.ID);
                        if (cliente.SUBROGACION == SIFModelo.Tipos.SiNo.SI)
                        {
                            //LogicaPedidos.ProveedorBeneficio = "SUBROGACION";

                            ClienteSub = ClienteSubN.ClientePorID(cliente.ID);
                            if (ClienteSub == null)
                            {
                               MessageBox.Show("El cliente fue marcado como SUBROGACION, sin embargo no se encontraron datos de subrogación en la base de datos");
                                return;
                            }


                            if (ClienteSub.PRECIO_FIJO == SIFModelo.Tipos.SiNo.SI)
                            {
                                Descuento = 0;
                                PorScosto = 0;
                                //this.logica.RemisionDetalles.Clear();
                                this.LogicaPedidos.PedidoDetalles.Clear();
                            }
                            else
                            {
                                Descuento = ClienteSub.PorDesc;
                                PorScosto = ClienteSub.PorScosto;
                            }

                            if (ClienteSub.CondicionVenta == SIFModelo.Tipos.CondicionVenta.CREDITO)
                            {

                                //creditoRadioButton.Enabled = false;
                                //creditoRadioButton.Checked = true;
                                //contadoRadioButton.Enabled = false;

                                //conFacturaCheckBox.Checked = true;
                            }


                            descuentoCredencialButtonItem.Visible = false;
                            //tiempoAireButtonItem.Visible = false;
                            //pfizerButtonItem.Visible = false;
                            //nadroButtonItem.Visible = false;
                            //buttonvale.Visible = true;
                            //if (ClienteSub.REQ_LOTE == SIFModelo.Tipos.SiNo.SI)
                                //loteCaducidadCheckBox.Checked = true;


                            this.statusLabel.Text = "CLIENTE SUBROGACION " + Descuento + "%";

                            //this.dataGrid.Columns["CODIGO_CLIColumn"].Visible = true;
                        }
                        else
                        {
                            //creditoRadioButton.Checked = false;
                            //creditoRadioButton.Enabled = true;
                            //contadoRadioButton.Enabled = true;
                            descuentoCredencialButtonItem.Visible = true;
                            //tiempoAireButtonItem.Visible = true;
                            //pfizerButtonItem.Visible = true;
                            //nadroButtonItem.Visible = true;
                        }



                        if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
                        {
                            LogicaPedidos.Pedido.Descuento = 0;

                            this.descuentoCredencial = null;
                            this.Descuento = 0;
                            ConvenioCliente = clienteN.ClientePorID(cliente.ID);
                            Descuento = ConvenioCliente.PorDesc;
                            if (Descuento > 0)
                                MessageBox.Show("Cliente convenio. Aplicando descuento del " + Descuento + "%");
                            PorScosto = ConvenioCliente.PorScosto;
                            if (PorScosto > 0)
                                MessageBox.Show("Cliente Convenio. Aplicando porcentaje sobre costo: "+PorScosto+"%");
                            LogicaPedidos.Pedido.PorcentajeDescuento = ConvenioCliente.PorDesc;

                            SIFModelo.TipoPago catipoPago = new SIFNegocio.TipoPagos().TipoPagoPorID(ConvenioCliente.TipoPagoID);

                            this.cmbTipopago.SelectedValue = ConvenioCliente.TipoPagoID;
                            this.cmbTipopago.Text = catipoPago.Nombre;

                            this.statusLabel.Text = "DESCUENTO CLIENTE CONVENIO";
                            this.LblDescuento.Text = ConvenioCliente.PorScosto+ConvenioCliente.PorDesc+"% SOBRE COSTO";
                        }

                        dirCasa = new SIFNegocio.Clientes().DireccionCliente(cliente, SIFModelo.Tipos.TipoDireccion.casa);
                        dirFiscal = new SIFNegocio.Clientes().DireccionCliente(cliente, SIFModelo.Tipos.TipoDireccion.fiscal);
                        if (dirFiscal != null)
                        {
                            RFClabelX.Text = dirFiscal.RFC;
                        }
                        else
                        {
                            RFClabelX.Text = "";
                        }

                        foreach (SIFModelo.PedidoDetalle detalle in LogicaPedidos.PedidoDetalles)
                        {
                            this.PrecioArticulo(detalle, PorScosto);
                            LogicaPedidos.RecalculaDetalle(detalle, LogicaPedidos.Pedido);
                        }
                        this.CalculaTotal();
                    }
                    break;
                case 2:
                    this.LogicaApartados.ApartadoM.ClienteID = cliente.ID;
                    if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
                    {
                        LogicaApartados.ApartadoM.Descuento = 0;

                        ConvenioCliente = clienteN.ClientePorID(cliente.ID);
                        Descuento = ConvenioCliente.PorDesc;
                        PorScosto = ConvenioCliente.PorScosto;

                        if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
                        {
                            ConvenioCliente = clienteN.ClientePorID(cliente.ID);
                            Descuento = ConvenioCliente.PorDesc;
                            PorScosto = ConvenioCliente.PorScosto;
                            cliente.Descuento = ConvenioCliente.PorDesc;


                        }

                    }
                    LogicaApartados.ApartadoM.PorcentajeDescuento = cliente.Descuento;

                    foreach (SIFModelo.ApartadoDetalle detalle in LogicaApartados.ApartadoDetalles)
                    {
                        this.PrecioArticulo(detalle, PorScosto);
                        LogicaApartados.RecalculaDetalle(detalle, LogicaApartados.ApartadoM);
                    }

                    break;
            }

            this.clienteLabelX.Text = cliente.ID.ToString();
            this.clienteLabelX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;

            CalculaTotal();
        }

        #endregion


        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void CotizacionUserControl_Load(object sender, EventArgs e)
        {
            dataGridViewX1.AutoGenerateColumns = false;
            switch (Cual)
            {
                case 0:
                case 3:
                case 4:
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaCotiza.CotizacionDetalles;
                    //folioCotizacionLabelX.Text = LogicaCotiza.NumeroCotizacion(Helpers.Sesion.Sucursal.SucursalID).ToString();
                    this.buscarTextBoxX.Focus();
                    break;
                case 1:
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaPedidos.PedidoDetalles;
                    //folioCotizacionLabelX.Text = LogicaPedidos.NumeroPedido(Helpers.Sesion.Sucursal.SucursalID).ToString();
                    this.buscarTextBoxX.Focus();
                    tableLayoutPanel2.Visible = true;
                    break;
                case 2:
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaApartados.ApartadoDetalles;
                    //folioCotizacionLabelX.Text = LogicaApartados.NumeroApartado(Helpers.Sesion.Sucursal.SucursalID).ToString();
                    this.buscarTextBoxX.Focus();
                    break;
            }

            Opciones();
        }

        private void superGridControl1_EndEdit(object sender, DevComponents.DotNetBar.SuperGrid.GridEditEventArgs e)
        {
            if (e.GridCell.GridColumn.HeaderText == "CANTIDAD" || e.GridCell.GridColumn.HeaderText == "COMENTARIO")
            {

                GridIntegerInputEditControl integerInput = e.EditControl as GridIntegerInputEditControl;
                //LogicaPedidos.Pedido.Descuento = 0;//L 16/12/2013
                //MessageBox.Show("Se reestablecerá el descuento");
                //statusLabel.Text = "";
                switch (Cual)
                {
                    case 0:
                    case 3:
                    case 4:
                        SIFModelo.CotizacionDetalle detalle = (SIFModelo.CotizacionDetalle)((GridRow)e.GridPanel.ActiveRow).DataItem;
                        SIFModelo.Articulo articulo = new SIFModelo.Articulo() { ARTICULO_ID = detalle.ArticuloID };
                        LogicaCotiza.ModificaCantidad(articulo, detalle.CantidadCotizacion);
                        detalle.COMENTARIO = e.GridCell.GridColumn.EditControl.EditorValue.ToString();
                        
                        break;
                    case 1:
                        SIFModelo.PedidoDetalle detallepedido = (SIFModelo.PedidoDetalle)((GridRow)e.GridPanel.ActiveRow).DataItem;
                        SIFModelo.Articulo articulop = new SIFModelo.Articulo() { ARTICULO_ID = detallepedido.ArticuloID };
                        int sucursalID = (int)sucursalesComboBoxEx.SelectedValue;
                        if (sucursalID == SIFNegocio.Helpers.Sesion.Sucursal.SucursalesID)
                        {
                            LogicaPedidos.ModificaCantidad(articulop, detallepedido.CantidadPedido);
                        }
                        LogicaPedidos.RecalculaDetalle(detallepedido, LogicaPedidos.Pedido);
                        SIFModelo.PedidoDetalle detallePed = new SIFModelo.PedidoDetalle();
                        this.CalculaTotal();

                        //L 19/12/2013 para actualizar en el detalle los importes luego de modificar cantidad
                        LogicaPedidos.RecalculaDetalle(detallePed, LogicaPedidos.Pedido);
                        LogicaPedidos.RecalculaDetalle(detallePed, LogicaPedidos.Pedido);
                        break;
                    case 2:
                        SIFModelo.ApartadoDetalle detalleapart = (SIFModelo.ApartadoDetalle)((GridRow)e.GridPanel.ActiveRow).DataItem;
                        SIFModelo.Articulo articuloa = new SIFModelo.Articulo() { ARTICULO_ID = detalleapart.ArticuloID };
                        LogicaApartados.ModificaCantidad(articuloa, detalleapart.CantidadApartado);
                        break;
                }
                //VALIDAMOS QUE EL LOTE SEA CORRECTO
                this.CalculaTotal();         //txt.Text;

            }
            
        }


        private void CalculaTotal()
        {
            switch (Cual)
            {
                case 0:
                case 3:
                case 4:
                    LogicaCotiza.CotizacionM.TotalArticulos = LogicaCotiza.CotizacionDetalles.Sum(r => r.CantidadCotizacion);
                    LogicaCotiza.CotizacionM.SubTotal = LogicaCotiza.CotizacionDetalles.Sum(r => r.Precio * r.CantidadCotizacion);
                    // logica.remision.Descuento 
                    // CHECAMOS LOS DESCUENTOS EN EL DETALLE
                    LogicaCotiza.CotizacionM.Descuento = LogicaCotiza.CotizacionDetalles.Sum(r => r.Descto);
                    //LogicaCotiza.CotizacionM.SubTotal * (Descuento / (decimal)100.0);
                    this.LblDescuento.Text = LogicaCotiza.CotizacionM.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                    LogicaCotiza.CotizacionM.Total = LogicaCotiza.CotizacionM.SubTotal - LogicaCotiza.CotizacionM.Descuento;
                    LogicaCotiza.CotizacionM.ImpuestoVenta = LogicaCotiza.CotizacionDetalles.Sum(r => r.IVA);
                    LogicaCotiza.CotizacionM.SubTotal = LogicaCotiza.CotizacionM.SubTotal - LogicaCotiza.CotizacionM.ImpuestoVenta;
                    this.subtotalLabelX.Text = LogicaCotiza.CotizacionM.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                    this.IVAlabelX.Text = LogicaCotiza.CotizacionM.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

                    this.LogicaCotiza.CotizacionM.Total = LogicaCotiza.CotizacionM.SubTotal - LogicaCotiza.CotizacionM.Descuento + LogicaCotiza.CotizacionM.ImpuestoVenta;
                    fTotal = LogicaCotiza.CotizacionM.Total;
                    this.totalLabelX.Text = LogicaCotiza.CotizacionM.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                    txtimporte.Text = LogicaCotiza.CotizacionM.Total.ToString("#,###.00");
                    this.LogicaCotiza.CotizacionM.ImpuestoVenta = LogicaCotiza.CotizacionDetalles.Sum(r => r.IVA);
                    //this.IVAlabelX.Text = LogicaCotiza.CotizacionM.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                    //this.IVAlabelX.Text = LogicaCotiza.CotizacionDetalles.Sum(r => r.IVA * r.CantidadCotizacion).ToString("C2", new System.Globalization.CultureInfo("ES-mx"));;
                    this.IVAlabelX.Text = LogicaCotiza.CotizacionDetalles.Sum(r => r.IVA).ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                    this.LogicaCotiza.CotizacionM.ImporteLetra = sif_tools.NumberToLetters.NumToLetter((double)LogicaCotiza.CotizacionM.Total, LogicaCotiza.CotizacionM.Total.GetType().ToString());
                    totalLetraLabelX.Text = this.LogicaCotiza.CotizacionM.ImporteLetra;
                    LblDescuento.Text = LogicaCotiza.CotizacionM.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                    break;
                case 1:
                    LogicaPedidos.Pedido.TotalArticulosPedido = LogicaPedidos.PedidoDetalles.Sum(r => r.CantidadPedido);
                    LogicaPedidos.Pedido.SubTotal = LogicaPedidos.PedidoDetalles.Sum(r => r.Precio * r.CantidadPedido);
                    LogicaPedidos.Pedido.Descuento = LogicaPedidos.PedidoDetalles.Sum(r=> r.MontoDescuento);
                    
                    if (descuentoCredencial == null)
                    {
                        descuentoCredencial = new SIFModelo.Descuento();
                        descuentoCredencial.Porcentaje = 0;
                    }
                    if (descuentoCredencial.Porcentaje > 0 && cliente.Descuento == 0 && cliente.Convenio.ToString() == "NO")
                    {
                        MessageBox.Show("El cliente no tiene descuento, se aplicará descuento tarjeta " +descuentoCredencial.NumeroCredencial);
                        cliente.Descuento = descuentoCredencial.Porcentaje;
                        LogicaPedidos.Pedido.PorcentajeDescuento = descuentoCredencial.Porcentaje;
                    }
                   /* if (SIFNegocio.Pedidos.campanaD!=0F)
                    {
                        MessageBox.Show(" Revise Descuentos de Campaña Activa, Descuento: " + SIFNegocio.Pedidos.campanaD + "%");
                    }*/
                    /*
                    MessageBox.Show(LogicaPedidos.Pedido.Descuento.ToString()+"%");
                    //Descuento contiene el descuento asociado al cliente
                    if (Descuento == 0 && descuentoCredencial.Porcentaje > 0 && cliente.Convenio.ToString() == "NO")//En caso de que haya un descuento credencial 
                        Descuento = descuentoCredencial.Porcentaje;
                    //if (LogicaPedidos.Pedido.Descuento == 0 )
                        LogicaPedidos.Pedido.Descuento = LogicaPedidos.Pedido.SubTotal * (Descuento / (decimal)100.0);//L 19/12/2013 PARA ACTUALIZAR EL DESCUENTO EN TOTALES
                    MessageBox.Show(LogicaPedidos.Pedido.Descuento.ToString()+"");
                    MessageBox.Show((LogicaPedidos.Pedido.SubTotal * (Descuento / (decimal)100.0)).ToString());
                     * 
                    cliente = new SIFNegocio.Clientes().ClientePorID(LogicaPedidos.Pedido.ClienteID);
                    
                    if (cliente.Descuento == 0 && LogicaPedidos.Pedido.Descuento > 0 && (descuentoCredencial.Porcentaje == 0 && cliente.Convenio.ToString() == "NO") )//En caso de que el nuevo cliente seleccionado no tenga descuento
                    {
                        LogicaPedidos.Pedido.Descuento = 0;
                        LogicaPedidos.Pedido.PorcentajeDescuento = 0;
                        MessageBox.Show("Se reestablecerá el descuento");
                    }
                    else if (cliente.Descuento == 0 && descuentoCredencial.Porcentaje > 0 && cliente.Convenio.ToString() == "NO")//EN CASO DE QUE HAYA UN DESCUENTO CREDENCIAL, SE APLICA
                    {
                        LogicaPedidos.Pedido.PorcentajeDescuento = descuentoCredencial.Porcentaje;
                        MessageBox.Show("Se aplicará descuento credencial "+ descuentoCredencial.Porcentaje+ "%");
                    }
                     */
                    //this.LblDescuento.Text = LogicaPedidos.Pedido.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                    // descuento;
                    //if (LblDescuento.Text == "$0.00")//L 16/12/2013 PARA QUE NO DUPLIQUE DESCUENTO
                    //LogicaPedidos.Pedido.Total = LogicaPedidos.Pedido.SubTotal - LogicaPedidos.Pedido.Descuento;
                    //L 16/12/2013
                    //Las siguientes 3 líneas funcionarían para actualizar el descuento en caso de modificar la cantidad del grid
                    //if (descuentoCredencial != null)
                    //if (descuentoCredencial.Porcentaje > 0)
                        //LogicaPedidos.Pedido.Total = Math.Round(((LogicaPedidos.Pedido.SubTotal + LogicaPedidos.Pedido.ImpuestoVenta) * ((100 - descuentoCredencial.Porcentaje) / 100)),2);
                    //else
                    //{
                        //MessageBox.Show("El descuento anterior será invalidado");
                        //LblDescuento.Text = "$0.00";
                        //LogicaPedidos.Pedido.Descuento = 0;
                    //}
                    LogicaPedidos.Pedido.ImpuestoVenta = LogicaPedidos.PedidoDetalles.Sum(r => r.IVA);                    
                    LogicaPedidos.Pedido.SubTotal = LogicaPedidos.Pedido.SubTotal - LogicaPedidos.Pedido.ImpuestoVenta;
                    //this.IVAlabelX.Text = LogicaPedidos.Pedido.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                    //this.IVAlabelX.Text = LogicaCotiza.CotizacionDetalles.Sum(r => r.IVA * r.CantidadCotizacion).ToString("C2", new System.Globalization.CultureInfo("ES-mx"));;
                    this.subtotalLabelX.Text = LogicaPedidos.Pedido.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                    //this.LogicaPedidos.Pedido.Total = LogicaPedidos.Pedido.SubTotal - LogicaPedidos.Pedido.Descuento + LogicaPedidos.Pedido.ImpuestoVenta;
                    this.LogicaPedidos.Pedido.Total = LogicaPedidos.Pedido.SubTotal + LogicaPedidos.Pedido.ImpuestoVenta - LogicaPedidos.Pedido.Descuento;
                    fTotal = LogicaPedidos.Pedido.Total;
                    this.totalLabelX.Text = LogicaPedidos.Pedido.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                    txtimporte.Text = LogicaPedidos.Pedido.Total.ToString("#,###.00");
                    this.LogicaPedidos.Pedido.ImpuestoVenta = LogicaPedidos.PedidoDetalles.Sum(r => r.IVA);
                    //this.IVAlabelX.Text = LogicaPedidos.Pedido.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                    this.IVAlabelX.Text = LogicaPedidos.PedidoDetalles.Sum(r => r.IVA ).ToString("C2", new System.Globalization.CultureInfo("ES-mx"));;
                    this.LogicaPedidos.Pedido.ImporteLetra = sif_tools.NumberToLetters.NumToLetter((double)LogicaPedidos.Pedido.Total, LogicaPedidos.Pedido.Total.GetType().ToString());
                    totalLetraLabelX.Text = this.LogicaPedidos.Pedido.ImporteLetra;
                    LblDescuento.Text = LogicaPedidos.Pedido.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                    break;
                case 2:
                    LogicaApartados.ApartadoM.TotalArticulos = LogicaApartados.ApartadoDetalles.Sum(r => r.CantidadApartado);
                    LogicaApartados.ApartadoM.SubTotal = LogicaApartados.ApartadoDetalles.Sum(r => r.Precio * r.CantidadApartado);

//LogicaApartados.ApartadoM.Descuento = LogicaApartados.ApartadoM.SubTotal * (LogicaApartados.ApartadoM.PorcentajeDescuento /100);
                    // descuento;
                    LogicaApartados.ApartadoM.Total = LogicaApartados.ApartadoM.SubTotal - LogicaApartados.ApartadoM.Descuento;
                    LogicaApartados.ApartadoM.ImpuestoVenta = LogicaApartados.ApartadoDetalles.Sum(r => r.IVA);
                    LogicaApartados.ApartadoM.SubTotal = LogicaApartados.ApartadoM.SubTotal - LogicaApartados.ApartadoM.ImpuestoVenta;
                    this.IVAlabelX.Text = LogicaApartados.ApartadoM.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                    this.subtotalLabelX.Text = LogicaApartados.ApartadoM.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                    this.LogicaApartados.ApartadoM.Total = LogicaApartados.ApartadoM.SubTotal - LogicaApartados.ApartadoM.Descuento + LogicaApartados.ApartadoM.ImpuestoVenta;
                    fTotal = LogicaApartados.ApartadoM.Total;
                    this.totalLabelX.Text = LogicaApartados.ApartadoM.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                    txtimporte.Text = LogicaApartados.ApartadoM.Total.ToString("#,###.00");
                    this.LogicaApartados.ApartadoM.ImpuestoVenta = LogicaApartados.ApartadoDetalles.Sum(r => r.IVA);
                    this.IVAlabelX.Text = LogicaApartados.ApartadoM.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                    this.LogicaApartados.ApartadoM.ImporteLetra = sif_tools.NumberToLetters.NumToLetter((double)LogicaApartados.ApartadoM.Total, LogicaApartados.ApartadoM.Total.GetType().ToString());
                    totalLetraLabelX.Text = this.LogicaApartados.ApartadoM.ImporteLetra;
                    LblDescuento.Text = LogicaApartados.ApartadoM.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                    break;
            }

            if (!txtimporte.Text.IsFloatPositive())
            {
                txtimporte.Text = fTotal.ToString();
            }

            if (decimal.Parse(txtimporte.Text) < fTotal)
                this.txtimporte.Text = fTotal.ToString("##,##0.00");
        }

        private void CodigoTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            //BUSCAR EL ARTICULO QUE PERTENECE A LA CLAVE
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaArticulo(CodigoTextBoxX.Text);
            }

            if (e.KeyCode == Keys.F4)
            {
                this.SeleccionaArticulo();
            }
            if (e.KeyCode == Keys.F5)
            {
                this.Guardar();
            }
        }

        private void guardarButtonItem_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }

        private void CodigoTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.SeleccionaArticulo();
        }

        private void cancelarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        private void cantidadTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaArticulo(CodigoTextBoxX.Text);
            }
        }

        private void agregaProductoButtonItem_Click(object sender, EventArgs e)
        {
            agregaProductoButtonItem.Enabled = false;
            this.SeleccionaArticulo();
            agregaProductoButtonItem.Enabled = true;
        }

        private void seleccionaClienteButtonItem_Click(object sender, EventArgs e)
        {
            this.SeleccionaCliente();
        }

        private void cantidadTextBoxX_Enter(object sender, EventArgs e)
        {
            this.cantidadTextBoxX.SelectAll();
        }

        private void CodigoTextBoxX_Enter(object sender, EventArgs e)
        {
            this.CodigoTextBoxX.SelectAll();
        }

        private void CodigoTextBoxX_TextChanged(object sender, EventArgs e)
        {

        }

        private void bar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void conFacturaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.conFacturaCheckBox.Checked)
            {
                SIFModelo.DireccionCliente dirFiscal = new SIFModelo.DireccionCliente();
                if (LogicaCotiza.CotizacionM.ClienteID != 0)
                {
                    LogicaPedidos.Pedido.ClienteID = LogicaCotiza.CotizacionM.ClienteID;
                }
                if (this.esClienteMostrador())
                {
                   MessageBox.Show("Elija un cliente válido");
                    this.conFacturaCheckBox.Checked = false;
                    return;
                }

                SIFModelo.Cliente cliente = new SIFModelo.Cliente();

                switch (Cual)
                {
                    case 0:
                    case 3:
                    case 4:
                        cliente.ID = this.LogicaCotiza.CotizacionM.ClienteID;
                        break;
                    case 1:
                        cliente.ID = this.LogicaPedidos.Pedido.ClienteID;
                        break;
                    case 2:
                        cliente.ID = this.LogicaApartados.ApartadoM.ClienteID;
                        break;

                }
                cliente.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                cliente = new SIFNegocio.Clientes().ClientePorID(cliente.ID);
                dirFiscal = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);

                //if (dirFiscal == null)
                //{
                cliente.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                Catalogos.DireccionClienteForm frmCliente = new Catalogos.DireccionClienteForm(cliente);
                if (frmCliente.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                cliente = new SIFNegocio.Clientes().ClientePorID(cliente.ID);
                dirFiscal = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);
                RFClabelX.Text = dirFiscal.RFC;
                switch (Cual)
                {
                    case 0:
                    case 3:
                    case 4:
                        LogicaCotiza.CotizacionM.Factura = SIFModelo.Tipos.SiNo.SI;
                        break;
                    case 1:
                        LogicaPedidos.Pedido.Factura = SIFModelo.Tipos.SiNo.SI;
                        break;
                    case 2:
                        LogicaApartados.ApartadoM.Factura = SIFModelo.Tipos.SiNo.SI;
                        break;
                }
                //}
            }
        }

        private void cantidadTextBoxX_TextChanged(object sender, EventArgs e)
        {

        }


        SIFModelo.Descuento descuentoCredencial = null;
        private void descuentoCredencialButtonItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show( LogicaPedidos.Pedido.ClienteID.ToString()); //L 16/12/2013 Para verificar si al cliente se le puede aplicar descuento credencial
            cliente = new SIFNegocio.Clientes().ClientePorID(LogicaPedidos.Pedido.ClienteID);
            if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI) //L 16/12/2013 Para verificar si al cliente se le puede aplicar descuento credencial
            {
                MessageBox.Show("Un cliente convenio no puede tener descuento credencial. Aplique el descuento en la configuración del cliente");
                return;
            }
            DescuentoForm frmDescuento = new DescuentoForm();
            if (frmDescuento.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                descuentoCredencial = new SIFModelo.Descuento();
                descuentoCredencial.ID = frmDescuento.DescuentoID;
                descuentoCredencial.Porcentaje = frmDescuento.DescuentoProveedor;
                descuentoCredencial.NumeroCredencial = frmDescuento.TarjetaID;
            }
            switch (Cual)
            {
                case 0:
                    LogicaCotiza.CotizacionM.NumeroCredencial = frmDescuento.TarjetaID;
                    LogicaCotiza.CotizacionM.Descuento = 0;
                    LogicaCotiza.CotizacionM.TipoCambioID = frmDescuento.DescuentoID;
                    LogicaCotiza.CotizacionM.PorcentajeDescuento = frmDescuento.DescuentoProveedor;
                    foreach (SIFModelo.CotizacionDetalle detalle in LogicaCotiza.CotizacionDetalles)
                        LogicaCotiza.RecalculaDetalle(detalle, LogicaCotiza.CotizacionM);
                    break;
                case 1:
                    LogicaPedidos.Pedido.NumeroCredencial = frmDescuento.TarjetaID;
                    LogicaPedidos.Pedido.PorcentajeDescuento = frmDescuento.DescuentoProveedor;
                    LogicaPedidos.Pedido.Descuento = 0;
                    LogicaPedidos.Pedido.TipoCambioID = frmDescuento.DescuentoID;
                    foreach (SIFModelo.PedidoDetalle detalle in LogicaPedidos.PedidoDetalles)
                        LogicaPedidos.RecalculaDetalle(detalle, LogicaPedidos.Pedido);
                    break;
                case 2:
                    LogicaApartados.ApartadoM.NumeroCredencial = frmDescuento.TarjetaID;
                    LogicaApartados.ApartadoM.Descuento = 0;
                    LogicaApartados.ApartadoM.TipoCambioID = frmDescuento.DescuentoID;
                    LogicaApartados.ApartadoM.PorcentajeDescuento = frmDescuento.DescuentoProveedor;
                    foreach (SIFModelo.ApartadoDetalle detalle in LogicaApartados.ApartadoDetalles)
                        LogicaApartados.RecalculaDetalle(detalle, LogicaApartados.ApartadoM);

                    break;
            }


           MessageBox.Show("La tarjeta " + frmDescuento.TarjetaID + " se utilizará  para la venta");
            this.statusLabel.Text = "DESCUENTO " + frmDescuento.TarjetaID;


            /*
            {
                logica.RecalculaDetalle(detalle, logica.remision);
            }*/

            this.CalculaTotal();

        }

        private void sucursalesComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (Cual > 0)
            {
                // if(sucursalesComboBoxEx.SelectedValue

                int sucursalID = 0;

                if (sucursalesComboBoxEx.SelectedValue is int)
                {
                    sucursalID = (int)sucursalesComboBoxEx.SelectedValue;
                }
                else
                {
                    sucursalID = ((Equin.ApplicationFramework.ObjectView<SIFModelo.Sucursal>)sucursalesComboBoxEx.SelectedValue).Object.SucursalID;
                }
                switch (Cual)
                {

                    case 1:
                        LogicaPedidos.Pedido.NumeroPedido = LogicaPedidos.NumeroPedido(sucursalID);
                        //folioCotizacionLabelX.Text = LogicaPedidos.Pedido.NumeroPedido;
                        break;
                    case 2:
                        LogicaApartados.ApartadoM.NumeroApartado = LogicaApartados.NumeroApartado(sucursalID);
                        //folioCotizacionLabelX.Text = LogicaApartados.ApartadoM.NumeroApartado;
                        break;
                }
            }
        }

        private void CodigoTextBoxX_ButtonCustomClick_1(object sender, EventArgs e)
        {
            SeleccionaArticulo();
        }

        private void superGridControl1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CodigoTextBoxX_KeyDown_1(object sender, KeyEventArgs e)
        {
            //BUSCAR EL ARTICULO QUE PERTENECE A LA CLAVE
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaArticulo(CodigoTextBoxX.Text);
            }

            if (e.KeyCode == Keys.F4)
            {
                this.SeleccionaArticulo();
            }

            if (e.KeyCode == Keys.F3)
            {
                this.SeleccionaCliente();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Cual = 0;
                Opciones();
            }

            //verificamos datos del pedido y detalle para que se integren.

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Cual = 1;
                Opciones();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                Cual = 2;
                Opciones();
            }
        }

        private void txtimporte_TextChanged(object sender, EventArgs e)
        {
            if (txtimporte.Text.IsFloat())
            {
                decimal fCambio = decimal.Parse(txtimporte.Text);
                fCambio = fCambio - fTotal;
                lblCambio.Text = fCambio.ToString("##,##0.00");
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }

            if (e.KeyCode == Keys.Delete)
            {
                if (!this.Eliminar())
                {
                    e.Handled = true;
                }
            }

        }

        private void CodigoTextBoxX_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.buscaArticulos();
        }

        private SIFNegocio.Articulo logica = new SIFNegocio.Articulo();
        private string propiedadBusqueda = "";
        string ultimaBusqueda = "";
        private void buscaArticulos()
        {
            ultimaBusqueda = buscarTextBoxX.Text;
            string parametroBusqueda = "%" + this.buscarTextBoxX.Text.Replace(' ', '%') + "%";

            //if (string.IsNullOrEmpty(this.propiedadBusqueda))
            //{
            //if (this.buscarTextBoxX.Text.Length > 3)
            //{
            if (Owner is SIF.View.Ventas.VentaUserControl)
            {
                SIF.View.Ventas.VentaUserControl Padre = Owner as SIF.View.Ventas.VentaUserControl;
                if (Padre.ClienteSub == null)
                    logica.BuscarConInventarioActivo(parametroBusqueda, Helpers.Sesion.Sucursal, propiedadBusqueda);
                else
                    if (Padre.ClienteSub.PRECIO_FIJO == SIFModelo.Tipos.SiNo.SI)
                        logica.BuscarConInventarioSub(parametroBusqueda, Helpers.Sesion.Sucursal, propiedadBusqueda);
                    else
                        logica.BuscarConInventario(parametroBusqueda, Helpers.Sesion.Sucursal, propiedadBusqueda);
            }
            else
            {
                logica.BuscarConInventarioActivo(parametroBusqueda, Helpers.Sesion.Sucursal, propiedadBusqueda);
            }

            this.dataGridViewX1.DataSource = logica.InventarioDataSet.ARTICULO_INVENTARIO;
        }

        private void dataGridViewX1_DoubleClick(object sender, EventArgs e)
        {
            this.AgregaArticuloGrid();
        }

        private void AgregaArticuloGrid(bool selected = true)
        {
            if (selected)
            {
                if (dataGridViewX1.SelectedRows.Count <= 0)
                {
                   MessageBox.Show("¿Debe seleccionar un artículo de la tabla?");
                    return;
                }
            }
            else
            {
                if (dataGridViewX1.Rows.Count <= 0)
                {
                   MessageBox.Show("¿Debe seleccionar un artículo de la tabla?");
                    return;
                }
            }

            SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow articulo = null;
            if (selected)
            {
                articulo = ((DataRowView)dataGridViewX1.SelectedRows[0].DataBoundItem).Row as SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow;
            }
            else
            {
                articulo = ((DataRowView)dataGridViewX1.Rows[0].DataBoundItem).Row as SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow;
            }

            this.CodigoTextBoxX.Text = articulo.ARTICULO_ID;
            this.AgregaArticulo(articulo.ARTICULO_ID);
            this.cantidadTextBoxX.Text = "1";
            this.buscarTextBoxX.SelectAll();
            this.buscarTextBoxX.Focus();
        }

        private void dataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaArticuloGrid();
            }

            if (e.KeyCode == Keys.F10)
            {
                this.buscarTextBoxX.Focus();
                this.buscarTextBoxX.SelectAll();
            }

        }

        private void buscarTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ultimaBusqueda == buscarTextBoxX.Text)
                {
                    AgregaArticuloGrid(true);
                    return;
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                buscarTextBoxX.Clear();
            }
            if (e.KeyCode == Keys.Down)
            {
                this.dataGridViewX1.Focus();
                return;
            }

        }

        private void buscarTextBoxX_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Down && e.KeyCode != Keys.Escape)
                this.buscaArticulos();
            //this.buscarTextBoxX.SelectAll();
        }

        private void buscarTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            buscarTextBoxX.Clear();
        }

        public SIFModelo.Cliente cliente { get; set; }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
