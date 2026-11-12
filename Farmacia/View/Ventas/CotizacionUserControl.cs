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

namespace SIF.View.Ventas
{
    public partial class CotizacionUserControl : Templates.ListaUserControl
    {
        public object Owner;
        public int Cual;
        private bool Pasa = false;
        private bool BPedidoE = false;
        private SIFModelo.WebServices.TarjetaPfizer pfizer = new SIFModelo.WebServices.TarjetaPfizer();
        private SIFModelo.WebServices.TarjetaNadro nadro = new SIFModelo.WebServices.TarjetaNadro();
        private decimal Descuento;
        SIFModelo.Cliente cliente;
        int PorScosto = 0;

        private const string PROVEEDOR_PFIZER = "PFIZER";
        private const string PROVEEDOR_NADRO = "NADRO";

        public CotizacionUserControl(bool ocultarCliente = false)
        {
            InitializeComponent();
            InicializaColumnas();
            if (ocultarCliente)
            {
                //switch (Cual)
                //{
                //    case 0:
                this.LogicaCotiza.CotizacionM = new SIFModelo.Cotizacion();
                this.LogicaCotiza.CotizacionM.ClienteID = 1;
                this.conCliente = ocultarCliente;
                this.seleccionaClienteButtonItem.Visible = false;
                this.seleccionaClienteButtonItem.Enabled = false;

                //}
            }


            //if (dirCliente != null)
            //{
            //    this.direccionLabelX.Text = dirCliente.Calle + " No. " + dirCliente.NumeroExterior;
            //    this.RFClabelX.Text = dirCliente.RFC;
            //}
            //else
            //{
            //    this.direccionLabelX.Text = "";
            //    this.RFClabelX.Text = "";
            //}

            //if (cliente.LoteCaducidad == SIFModelo.Tipos.SiNo.SI)
            //{
            //    this.loteCaducidadCheckBox.Checked = true;
            //}
            //break;

            cargaSucursales();
        }

        private void cargaSucursales()
        {
            SIFNegocio.Sucursales sucursalL = new SIFNegocio.Sucursales();
            this.sucursalesComboBoxEx.DataSource = sucursalL.Buscar("", "");
            sucursalesComboBoxEx.DisplayMember = "Nombre";
            sucursalesComboBoxEx.ValueMember = "SucursalesID";
            sucursalesComboBoxEx.Text = Helpers.Sesion.Sucursal.Nombre;
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

        public CotizacionUserControl(bool OcultarCliente, int ClienteID): this(OcultarCliente)
        {
            LogicaCotiza.CotizacionDetalles = new List<SIFModelo.CotizacionDetalle>();
            this.ClienteID = ClienteID;
            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(ClienteID);

            if (cliente != null)
            {
                this.clienteLabelX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
            }


            if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
            {
                LogicaCotiza.CotizacionM.ProveedorBeneficio = "CONVENIO";

                ConvenioCliente = clienteN.ClientePorID(cliente.ID);

                Descuento = ConvenioCliente.PorDesc;
                PorScosto = ConvenioCliente.PorScosto;

                this.statusLabel.Text = "DESCUENTO CONVENIO " + Descuento + "%";
            }
            // checamos si el cliente es subrogacion

            if (cliente.SUBROGACION == SIFModelo.Tipos.SiNo.SI)
            {
                LogicaCotiza.CotizacionM.ProveedorBeneficio = "SUBROGACION";

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
                    LogicaCotiza.CotizacionDetalles.Clear();
                }
                else
                {
                    Descuento = ClienteSub.PorDesc;
                    PorScosto = ClienteSub.PorScosto;
                }

                descuentoCredencialButtonItem.Visible = false;
                //tiempoAireButtonItem.Visible = false;
                //pfizerButtonItem.Visible = false;
                //nadroButtonItem.Visible = false;
                //buttonvale.Visible = true;
                //if (ClienteSub.REQ_LOTE == SIFModelo.Tipos.SiNo.SI)
                //    loteCaducidadCheckBox.Checked = true;


                this.statusLabel.Text = "CLIENTE SUBROGACION " + Descuento + "%";

                this.dataGrid.Columns["CODIGO_CLIColumn"].Visible = true;
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
                LogicaCotiza.CotizacionM.ProveedorBeneficio = "CONVENIO";

                ConvenioCliente = clienteN.ClientePorID(cliente.ID);

                Descuento = ConvenioCliente.PorDesc;
                PorScosto = ConvenioCliente.PorScosto;

                this.statusLabel.Text = "DESCUENTO CONVENIO " + Descuento + "%";


            }
            this.clienteLabelX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;

            SIFModelo.DireccionCliente dirCliente = new SIFNegocio.Clientes().DireccionCliente(cliente);

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
            this.agregaProductoButtonItem.Shortcuts.Clear();
        }
        GridPanel dataGrid;
        public void Back()
        {

            if (this.dataGrid.Rows.Count > 0 && !Pasa)
            {
                DialogResult res = 0;
                switch (Cual)
                {
                    case 0:
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
            if (Owner is View.Ventas.VentaUserControl)
            {
                View.Ventas.VentaUserControl propietario = Owner as View.Ventas.VentaUserControl;
                this.DesactivaComandos();
                propietario.ActivaComandos();
                if (propietario.Owner.Owner.Contains(this))
                {
                    propietario.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }
                this.Mostrado = true;
            }

            if (Owner is View.Menu.CatMenu)
            {
                View.Menu.CatMenu propietario = Owner as View.Menu.CatMenu;
                propietario.Owner.ActivaComandos();
                this.DesactivaComandos();
                this.Dock = DockStyle.Fill;
                if (propietario.Owner.Contains(this))
                {
                    propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }

                this.Mostrado = false;
            }
        }

        public void Muestra()
        {

            if (Owner is View.Ventas.VentaUserControl)
            {

                View.Ventas.VentaUserControl propietario = Owner as View.Ventas.VentaUserControl;
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;
                propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                Mostrado = true;

                LogicaCotiza.CotizacionM.SucursalID = Helpers.Sesion.Sucursal.SucursalesID;

            }

            if (Owner is View.Menu.CatMenu)
            {

                View.Menu.CatMenu propietario = Owner as View.Menu.CatMenu;
                propietario.Owner.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;
                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                Mostrado = true;
                // cambiamos letreros
                switch (Cual)
                {
                    case 0:
                        titleLabel.Text = "SIF\\Cotización";
                        if (LogicaCotiza.CotizacionM.VendedorID == 0)
                        {
                            View.Ventas.AccesoUsuarioForm frmAcesoUsuario = new AccesoUsuarioForm();
                            if (frmAcesoUsuario.ShowDialog() != DialogResult.OK)
                            {
                                this.Back();
                                return;
                            }

                            this.LogicaCotiza.CotizacionM.VendedorID = frmAcesoUsuario.Usuario.UsuariosID;
                        }
                        break;
                    case 1:
                        titleLabel.Text = "SIF\\Genera Pedido";
                        if (LogicaPedidos.Pedido.VendedorID == 0)
                        {
                            View.Ventas.AccesoUsuarioForm frmAcesoUsuario = new AccesoUsuarioForm();
                            if (frmAcesoUsuario.ShowDialog() != DialogResult.OK)
                            {
                                this.Back();
                                return;
                            }

                            this.LogicaPedidos.Pedido.VendedorID = frmAcesoUsuario.Usuario.UsuariosID;
                        }
                        break;
                    case 2:
                        titleLabel.Text = "SIF\\Apartado/Reserva";
                        if (LogicaApartados.ApartadoM.VendedorID == 0)
                        {
                            View.Ventas.AccesoUsuarioForm frmAcesoUsuario = new AccesoUsuarioForm();
                            if (frmAcesoUsuario.ShowDialog() != DialogResult.OK)
                            {
                                this.Back();
                                return;
                            }

                            this.LogicaApartados.ApartadoM.VendedorID = frmAcesoUsuario.Usuario.UsuariosID;
                        }
                        break;
                }
                if (Cual == 0) descuentoCredencialButtonItem.Visible = false; else descuentoCredencialButtonItem.Visible = true;

            }
        }

        #endregion

        #region Funciones y Metodos

        private void InicializaColumnas()
        {
            dataGrid = this.superGridControl1.PrimaryGrid;
            superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            GridIntegerInputEditControl cantidadColumn = superGridControl1.PrimaryGrid.Columns["CANTIDADColumn"].EditControl as GridIntegerInputEditControl;
            cantidadColumn.MinValue = 1;

        }

        public void AgregaArticulo(string claveArticulo)
        {
            if (string.IsNullOrEmpty(claveArticulo))
            {
                return;
            }

            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(claveArticulo);

            if (articulo == null)
            {
               MessageBox.Show("El artículo no existe en el catalogo");
                return;
            }

            this.AgregaArticulo(articulo);
        }


        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {
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
                    SIFModelo.CotizacionDetalle detalle = new SIFModelo.CotizacionDetalle();
                    detalle.ArticuloID = articulo.ARTICULO_ID;
                    detalle.Nombre1 = articulo.NOMBRE1;
                    detalle.Nombre2 = articulo.NOMBRE2;
                    detalle.CantidadCotizacion = int.Parse(this.cantidadTextBoxX.Text);
                    int existenciaArticulo = 0;
                    if (!(new SIFNegocio.Inventario.Inventario().InventarioArticulo(articulo, detalle.CantidadCotizacion, out existenciaArticulo)))
                    {
                        if (this.Owner is View.Ventas.VentaUserControl)
                        {

                            if (MessageBoxEx.Show("¿Agregar a la lista de artículos faltantes el artículo " + articulo.ARTICULO_ID + " [" + articulo.NOMBRE1 + "] ?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                View.Ventas.VentaUserControl propietario = this.Owner as View.Ventas.VentaUserControl;
                                articulo.TIPO_MONEDA = int.Parse(cantidadTextBoxX.Text) - existenciaArticulo;
                                propietario.articulosFaltantes.Add(articulo);
                            }
                        }
                    }
                    this.PrecioArticulo(detalle);
                    LogicaCotiza.AgregaDetalle(detalle);
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaCotiza.CotizacionDetalles;
                    break;
                case 1:
                    if (articulo.TIPO_MEDICAMENTO_CVE.Contains("F1") && articulo.TIPO_MEDICAMENTO_CVE.Contains("T3"))
                    {
                        //pedimos el folio de la receta
                        if (LogicaPedidos.Pedido.Receta != SIFModelo.Tipos.SiNo.NO)
                        {
                            View.Ventas.RecetaMedicoForm frmrec = new View.Ventas.RecetaMedicoForm();
                            frmrec.ShowDialog();
                            LogicaPedidos.Pedido.Receta = SIFModelo.Tipos.SiNo.SI;
                        }
                    }
                    else
                        if (articulo.TIPO_MEDICAMENTO_CVE.Contains("F1"))
                        {
                           MessageBox.Show("El medicamento no puede ser vendido");
                            return;
                        }



                    SIFModelo.PedidoDetalle detallePed = new SIFModelo.PedidoDetalle();
                    detallePed.ArticuloID = articulo.ARTICULO_ID;
                    detallePed.Nombre1 = articulo.NOMBRE1;
                    detallePed.Nombre2 = articulo.NOMBRE2;
                    detallePed.CantidadPedido = int.Parse(this.cantidadTextBoxX.Text);


                    this.PrecioArticulo(detallePed);

                    LogicaPedidos.AgregaDetalle(ref detallePed, articulo, ref LogicaPedidos);
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaPedidos.PedidoDetalles;
                    superGridControl1.PrimaryGrid.Columns["CANTIDADColumn"].DataPropertyName = "CantidadPedido";
                    break;
                case 2:

                    if (articulo.TIPO_MEDICAMENTO_CVE.Contains("F1"))
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
                    detalleApa.CantidadApartado = int.Parse(this.cantidadTextBoxX.Text);
                    this.PrecioArticulo(detalleApa);
                    // verificamos el inventario
                    SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
                    int existencias = 0;
                    BPedidoE = LogicaApartados.AgregaDetalle(detalleApa, articulo, BPedidoE);
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaApartados.ApartadoDetalles;
                    superGridControl1.PrimaryGrid.Columns["CANTIDADColumn"].DataPropertyName = "CantidadApartado";
                    break;
            }


            this.CalculaTotal();
            this.CodigoTextBoxX.SelectAll();
            this.cantidadTextBoxX.Text = "1";
            CodigoTextBoxX.Focus();
        }

        //private bool PrecioArticulo(SIFModelo.CotizacionDetalle detalle)
        //{
        //    SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
        //    if (precios == null)
        //    {
        //       MessageBox.Show("No hay un precio activo para este producto");
        //        return false;
        //    }
        //    else
        //    {
        //        detalle.Precio = precios.PRECIO_VENTA;
        //        detalle.Total = detalle.CantidadCotizacion * detalle.Precio;
        //        if (detalle.Precio == 0)
        //        {
        //           MessageBox.Show("El precio del producto es cero", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            //return false;
        //        }

        //        detalle.ImpuestoID = precios.IMP_VENTA;
        //        SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);
        //        if (impuesto != null)
        //        {
        //            decimal calculaImpuesto = detalle.Total * (impuesto.Porcentaje / 100m);

        //            detalle.IVA = calculaImpuesto;
        //        }
        //    }
        //    return true;
        //}


        private bool PrecioArticulo(SIFModelo.PedidoDetalle detalle)
        {
            SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
            if (precios == null)
            {
               MessageBox.Show("No hay un precio activo para este producto");
                return false;
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
            return true;
        }

        private bool PrecioArticulo(SIFModelo.ApartadoDetalle detalle)
        {
            SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
            if (precios == null)
            {
               MessageBox.Show("No hay un precio activo para este producto");
                return false;
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

        private bool PrecioArticulo(SIFModelo.CotizacionDetalle detalle)
        {
            //if (ClienteSub != null)
            //    if (ClienteSub.PRECIO_FIJO == SIFModelo.Tipos.SiNo.SI)
            //    { //obtenemos el precio de la lista de precios del cliente y marcamos como credito la venta sin opcion a cambiarla

            //        //CHECAMOS SI ES CLIENTE SUBROGACION

            //        SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow ArticuloSubP;
            //        SIFNegocio.Subrogacion.Articulos ArticulosubL = new SIFNegocio.Subrogacion.Articulos();
            //        ArticuloSubP = ArticulosubL.GetArticulo(detalle.ArticuloID, ClienteSub.ID);
            //        if (ArticuloSubP != null)
            //        {
            //            detalle.Precio = decimal.Parse(ArticuloSubP.PRECIO.ToString());
            //            return true;
            //        }
            //        else
            //        {
            //            detalle.Precio = 0;
            //           MessageBox.Show("El precio del producto es cero", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //    }


            SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
            if (precios == null)
            {
               MessageBox.Show("No hay un precio activo para este producto");
                return false;
            }
            else
            {

                if (PorScosto > 0)
                    detalle.Precio = precios.PRECIO_COSTO + (precios.PRECIO_COSTO * PorScosto / 100);
                else
                    detalle.Precio = precios.PRECIO_VENTA;
                detalle.Total = detalle.CantidadCotizacion * detalle.Precio;
                if (detalle.Precio == 0)
                {
                   MessageBox.Show("El precio del producto es cero", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return false;
                }

                //detalle.ImpuestoID = precios.IMP_VENTA;
                //SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);
                //if (impuesto != null)
                //{
                //    detalle.Precio = detalle.Precio / (1 + (impuesto.Porcentaje / 100m));
                //    detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                //    detalle.Total = detalle.Precio * detalle.CantidadRemision;
                //    decimal calculaImpuesto = detalle.Total * (impuesto.Porcentaje / 100m);

                //    detalle.IVA = calculaImpuesto;
                //}
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
        }

        private void Guardar()
        {

            int G = 0;
            int sucursalID = (int)sucursalesComboBoxEx.SelectedValue;
            switch (Cual)
            {
                case 0:
                    this.CalculaTotal();

                    LogicaCotiza.CotizacionM.NumeroCotizacion = LogicaCotiza.NumeroCotizacion(sucursalID);
                    LogicaCotiza.CotizacionM.SucursalID = sucursalID;
                    if (this.Owner is View.Ventas.VentaUserControl)
                    {
                        sucursalID = Helpers.Sesion.Sucursal.SucursalesID;
                        LogicaCotiza.CotizacionM.NumeroCotizacion = LogicaCotiza.NumeroCotizacion(sucursalID);
                        LogicaCotiza.CotizacionM.SucursalID = sucursalID;

                        LogicaCotiza.CotizacionM.Activo = SIFModelo.Tipos.SiNo.SI;
                        LogicaCotiza.CotizacionM.Factura = SIFModelo.Tipos.SiNo.NO;
                        LogicaCotiza.CotizacionM.FechaCotizacion = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                        //LogicaCotiza.CotizacionM.NumeroCredencial = "0";
                        LogicaCotiza.CotizacionM.Receta = SIFModelo.Tipos.SiNo.NO;
                        LogicaCotiza.CotizacionM.TipoCotizacion = SIFModelo.Tipos.TipoCotizacion.VENTA;
                        // LogicaCotiza.CotizacionM.TotalArticulos
                        LogicaCotiza.Inserta(LogicaCotiza.CotizacionM);
                        int numPartida = 1;
                        foreach (var i in LogicaCotiza.CotizacionDetalles)
                        {
                            i.NumeroCotizacion = LogicaCotiza.CotizacionM.NumeroCotizacion;
                            i.NumeroPartida = numPartida; numPartida++;
                            i.SucursalID = LogicaCotiza.CotizacionM.SucursalID;

                            LogicaCotiza.InsertaDetalle(i);
                        }
                    }
                    else
                    {
                        G = LogicaCotiza.GuardaDatos(LogicaCotiza);
                    }
                    break;
                case 1:
                    this.CalculaTotal();
                    sucursalID = (int)sucursalesComboBoxEx.SelectedValue;
                    LogicaPedidos.Pedido.NumeroPedido = LogicaPedidos.NumeroPedido(sucursalID);
                    LogicaPedidos.Pedido.SucursalID = sucursalID;
                    G = LogicaPedidos.GuardaDatos(LogicaPedidos);
                    break;
                case 2:
                    this.CalculaTotal();
                    LogicaApartados.ApartadoM.NumeroApartado = LogicaApartados.NumeroApartado(sucursalID);
                    LogicaApartados.ApartadoM.SucursalID = sucursalID;
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

                    G = LogicaApartados.GuardaDatos(LogicaApartados);
                    break;
            }

            if (G == 0)
            {
                switch (Cual)
                {
                    case 0:
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
                this.Back();
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
                       MessageBox.Show("Hubo un error al insertar Los datos");
                        break;
                }


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
            this.superGridControl1.Refresh();
            this.superGridControl1.Invalidate();
            DialogResult resp =MessageBox.Show("¿Eliminar los productos seleccinados?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != DialogResult.Yes)
            {
                return false;
            }

            var seleccionadas = this.superGridControl1.PrimaryGrid.SelectedRows;

            foreach (GridContainer detalle in seleccionadas)
            {
                GridRow fila = detalle as GridRow;

                if (fila == null)
                {
                    continue;
                }

                LogicaCotiza.CotizacionDetalles.Remove(fila.DataItem as SIFModelo.CotizacionDetalle);
            }
            this.reordenaPartida();

            superGridControl1.PrimaryGrid.DataSource = LogicaCotiza.CotizacionDetalles;
            this.CalculaTotal();

            return true;
        }

        private void reordenaPartida()
        {
            for (int p = 0; p < LogicaCotiza.CotizacionDetalles.Count; p++)
            {
                LogicaCotiza.CotizacionDetalles[p].NumeroPartida = p + 1;
                // p++;
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

            string claveArticulo = "";
            if (this.superGridControl1.PrimaryGrid.ActiveRow != null)
            {
                switch (Cual)
                {
                    case 0:
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
            }
            else
            {
                claveArticulo = CodigoTextBoxX.Text;
            }

            if (!string.IsNullOrEmpty(this.CodigoTextBoxX.Text))
            {
                claveArticulo = this.CodigoTextBoxX.Text;
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

                if (Cual == 0)
                    frmCliente.LAB_MAYORISTA = true;
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
                    this.LogicaCotiza.CotizacionM.ClienteID = cliente.ID;
                    this.LogicaCotiza.CotizacionM.PorcentajeDescuento = cliente.Descuento;
                    foreach (SIFModelo.CotizacionDetalle detalle in LogicaCotiza.CotizacionDetalles)
                        LogicaCotiza.RecalculaDetalle(detalle, LogicaCotiza.CotizacionM);
                    this.CalculaTotal();
                    break;
                case 1:
                    {
                        this.LogicaPedidos.Pedido.ClienteID = cliente.ID;
                        // mostramos la direccion del cliente para que la cambie en caso de que la neseciten cambiar

                        SIFModelo.DireccionCliente dirCasa = new SIFModelo.DireccionCliente();
                        cliente.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                        dirCasa = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);
                        Catalogos.DireccionClienteForm frmCliente = new Catalogos.DireccionClienteForm(cliente);
                        if (frmCliente.ShowDialog() != DialogResult.OK)
                            return;
                        cliente = new SIFNegocio.Clientes().ClientePorID(cliente.ID);
                        dirCasa = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);
                    }
                    break;
                case 2:
                    this.LogicaApartados.ApartadoM.ClienteID = cliente.ID;
                    break;
            }
            this.clienteLabelX.Text = cliente.ID.ToString();
            this.clienteLabelX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;

        }

        #endregion


        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void CotizacionUserControl_Load(object sender, EventArgs e)
        {
            switch (Cual)
            {
                case 0:
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaCotiza.CotizacionDetalles;
                    folioCotizacionLabelX.Text = LogicaCotiza.NumeroCotizacion(Helpers.Sesion.Sucursal.SucursalID).ToString();
                    conFacturaCheckBox.Visible = false;
                    this.CodigoTextBoxX.Focus();
                    break;
                case 1:
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaPedidos.PedidoDetalles;
                    folioCotizacionLabelX.Text = LogicaPedidos.NumeroPedido(Helpers.Sesion.Sucursal.SucursalID).ToString();
                    this.CodigoTextBoxX.Focus();
                    break;
                case 2:
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaApartados.ApartadoDetalles;
                    folioCotizacionLabelX.Text = LogicaApartados.NumeroApartado(Helpers.Sesion.Sucursal.SucursalID).ToString();
                    this.CodigoTextBoxX.Focus();
                    break;
            }
        }

        private void superGridControl1_EndEdit(object sender, DevComponents.DotNetBar.SuperGrid.GridEditEventArgs e)
        {
            if (e.GridCell.GridColumn.HeaderText == "CANTIDAD")
            {

                GridIntegerInputEditControl integerInput = e.EditControl as GridIntegerInputEditControl;
                switch (Cual)
                {
                    case 0:
                        SIFModelo.CotizacionDetalle detalle = (SIFModelo.CotizacionDetalle)((GridRow)e.GridPanel.ActiveRow).DataItem;
                        SIFModelo.Articulo articulo = new SIFModelo.Articulo() { ARTICULO_ID = detalle.ArticuloID };
                        LogicaCotiza.ModificaCantidad(articulo, detalle.CantidadCotizacion);
                        break;
                    case 1:
                        SIFModelo.PedidoDetalle detallepedido = (SIFModelo.PedidoDetalle)((GridRow)e.GridPanel.ActiveRow).DataItem;
                        SIFModelo.Articulo articulop = new SIFModelo.Articulo() { ARTICULO_ID = detallepedido.ArticuloID };
                        LogicaPedidos.ModificaCantidad(articulop, detallepedido.CantidadPedido);
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

        public SIFModelo.ClienteSubrogaccion ClienteSub;
        SIFModelo.ClienteConvenio ConvenioCliente;
        SIFNegocio.ClienteSubrogacion ClienteSubN = new SIFNegocio.ClienteSubrogacion();
        SIFNegocio.ClienteConvenios clienteN = new SIFNegocio.ClienteConvenios();

        private void CalculaTotal()
        {
            //switch (Cual)
            //{
            //    case 0:
            //        LogicaCotiza.CotizacionM.TotalArticulos = LogicaCotiza.CotizacionDetalles.Sum(r => r.CantidadCotizacion);
            //        LogicaCotiza.CotizacionM.SubTotal = LogicaCotiza.CotizacionDetalles.Sum(r => r.Precio * r.CantidadCotizacion);
            //        // LogicaCotiza.CotizacionM.Descuento 
            //        LogicaCotiza.CotizacionM.Descuento = LogicaCotiza.CotizacionM.SubTotal * (Descuento / (decimal)100.0);
            //        this.LblDescuento.Text = LogicaCotiza.CotizacionM.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            //        this.subtotalLabelX.Text = LogicaCotiza.CotizacionM.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

            //        // descuento;
            //        LogicaCotiza.CotizacionM.Total = LogicaCotiza.CotizacionM.SubTotal - LogicaCotiza.CotizacionM.Descuento;
            //        LogicaCotiza.CotizacionM.ImpuestoVentaVenta = LogicaCotiza.CotizacionDetalles.Sum(r => r.IVA);
            //        this.IVAlabelX.Text = LogicaCotiza.CotizacionM.ImpuestoVentaVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

            //        this.LogicaCotiza.CotizacionM.Total = LogicaCotiza.CotizacionM.SubTotal - LogicaCotiza.CotizacionM.Descuento;// + LogicaCotiza.CotizacionM.ImpuestoVentaVenta;
            //        this.totalLabelX.Text = LogicaCotiza.CotizacionM.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            //        this.LogicaCotiza.CotizacionM.ImpuestoVentaVenta = LogicaCotiza.CotizacionDetalles.Sum(r => r.IVA);
            //        this.IVAlabelX.Text = LogicaCotiza.CotizacionM.ImpuestoVentaVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            //        this.LogicaCotiza.CotizacionM.ImporteLetra = sif_tools.NumberToLetters.NumToLetter((double)LogicaCotiza.CotizacionM.Total, LogicaCotiza.CotizacionM.Total.GetType().ToString());
            //        totalLetraLabelX.Text = this.LogicaCotiza.CotizacionM.ImporteLetra;
            //        LblDescuento.Text = LogicaCotiza.CotizacionM.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            //        break;
            //    case 1:
            //        LogicaPedidos.Pedido.TotalArticulosPedido = LogicaPedidos.PedidoDetalles.Sum(r => r.CantidadPedido);
            //        LogicaPedidos.Pedido.SubTotal = LogicaPedidos.PedidoDetalles.Sum(r => r.Precio * r.CantidadPedido);
            //        // LogicaCotiza.CotizacionM.Descuento 
            //        //logica.Pedido.Descuento = logica.Pedido.SubTotal * (Descuento / (decimal)100.0);
            //        //this.LblDescuento.Text = logica.Pedido.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            //        this.subtotalLabelX.Text = LogicaPedidos.Pedido.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));


            //        // descuento;
            //        LogicaPedidos.Pedido.Total = LogicaPedidos.Pedido.SubTotal - LogicaPedidos.Pedido.Descuento;
            //        LogicaPedidos.Pedido.ImpuestoVenta = LogicaPedidos.PedidoDetalles.Sum(r => r.IVA);
            //        this.IVAlabelX.Text = LogicaPedidos.Pedido.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

            //        this.LogicaPedidos.Pedido.Total = LogicaPedidos.Pedido.SubTotal - LogicaPedidos.Pedido.Descuento + LogicaPedidos.Pedido.ImpuestoVenta;
            //        this.totalLabelX.Text = LogicaPedidos.Pedido.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            //        this.LogicaPedidos.Pedido.ImpuestoVenta = LogicaPedidos.PedidoDetalles.Sum(r => r.IVA);
            //        this.IVAlabelX.Text = LogicaPedidos.Pedido.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            //        this.LogicaPedidos.Pedido.ImporteLetra = sif_tools.NumberToLetters.NumToLetter((double)LogicaPedidos.Pedido.Total, LogicaPedidos.Pedido.Total.GetType().ToString());
            //        totalLetraLabelX.Text = this.LogicaPedidos.Pedido.ImporteLetra;
            //        LblDescuento.Text = LogicaPedidos.Pedido.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            //        break;
            //    case 2:
            //        LogicaApartados.ApartadoM.TotalArticulos = LogicaApartados.ApartadoDetalles.Sum(r => r.CantidadApartado);
            //        LogicaApartados.ApartadoM.SubTotal = LogicaApartados.ApartadoDetalles.Sum(r => r.Precio * r.CantidadApartado);
            //        this.subtotalLabelX.Text = LogicaApartados.ApartadoM.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

            //        // descuento;
            //        LogicaApartados.ApartadoM.Total = LogicaApartados.ApartadoM.SubTotal - LogicaApartados.ApartadoM.Descuento;
            //        LogicaApartados.ApartadoM.ImpuestoVenta = LogicaApartados.ApartadoDetalles.Sum(r => r.IVA);
            //        this.IVAlabelX.Text = LogicaApartados.ApartadoM.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

            //        this.LogicaApartados.ApartadoM.Total = LogicaApartados.ApartadoM.SubTotal - LogicaApartados.ApartadoM.Descuento + LogicaApartados.ApartadoM.ImpuestoVenta;
            //        this.totalLabelX.Text = LogicaApartados.ApartadoM.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            //        this.LogicaApartados.ApartadoM.ImpuestoVenta = LogicaApartados.ApartadoDetalles.Sum(r => r.IVA);
            //        this.IVAlabelX.Text = LogicaApartados.ApartadoM.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            //        this.LogicaApartados.ApartadoM.ImporteLetra = sif_tools.NumberToLetters.NumToLetter((double)LogicaApartados.ApartadoM.Total, LogicaApartados.ApartadoM.Total.GetType().ToString());
            //        totalLetraLabelX.Text = this.LogicaApartados.ApartadoM.ImporteLetra;
            //        LblDescuento.Text = LogicaApartados.ApartadoM.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            //        break;
            //}



            this.LogicaCotiza.CotizacionM.TotalArticulos = LogicaCotiza.CotizacionDetalles.Sum(r => r.CantidadCotizacion);

            // logica.remision.Descuento 

            LogicaCotiza.CotizacionM.Descuento = 0; // logica.remision.SubTotal * (Descuento / (decimal)100.0);


            foreach (SIFModelo.CotizacionDetalle detalle in LogicaCotiza.CotizacionDetalles)
            {
                if (LogicaCotiza.CotizacionM.BeneficioProveedor == SIFModelo.Tipos.SiNo.NO || LogicaCotiza.CotizacionM.BeneficioProveedor == 0)
                {
                    SIFNegocio.OrdenCompra.ManejoDescuentos descuentosL = new SIFNegocio.OrdenCompra.ManejoDescuentos();
                    //buscar ofertas
                    SIFModelo.Articulo articulo = new SIFModelo.Articulo();
                    articulo.ARTICULO_ID = detalle.ArticuloID;
                    var listaOfertaVenta = descuentosL.DescuentoActivo(articulo);

                    if (listaOfertaVenta != null)
                    {
                        SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
                        detalle.PrecioCosto = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_COSTO);
                        if (listaOfertaVenta.APLICADO_A == "P")
                        {
                            detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_VENTA_MAX);
                            //detalle.PrecioDescontado = precios.PRECIO_VENTA_MAX - (precios.PRECIO_VENTA_MAX * ((decimal)listaOfertaVenta.DESCUENTO / 100m));
                            detalle.PorcentajeDescuento = System.Convert.ToInt32(listaOfertaVenta.DESCUENTO);
                            Descuento = detalle.PorcentajeDescuento;
                            detalle.RefOferta = listaOfertaVenta.LISTA_OFERTAS_ID;

                            // detalle.MontoDescuento = detalle.Precio - detalle.PrecioDescontado;
                        }


                        if (listaOfertaVenta.APLICADO_A == "F")
                        {
                            detalle.PrecioDescontado = precios.PRECIO_VENTA - (precios.PRECIO_VENTA * ((decimal)listaOfertaVenta.DESCUENTO / 100m));
                            detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioDescontado);
                            detalle.RefOferta = listaOfertaVenta.LISTA_OFERTAS_ID;
                        }
                    }

                }

                SIFNegocio.Articulo LogArt = new SIFNegocio.Articulo();
                SIFModelo.Articulo Articulo = LogArt.BuscarPorClave(detalle.ArticuloID);
                if (ClienteSub == null)
                {
                    if (ConvenioCliente != null)
                    {
                        if (ConvenioCliente.ID == 24)
                        {
                            if ((!Articulo.TIPO_MEDICAMENTO_CVE.Contains("SD") & !Articulo.TIPO_MEDICAMENTO_CVE.Contains("F1")))
                            {
                                decimal impDescuento = (SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio) * detalle.CantidadCotizacion) * (Descuento / 100);
                                detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio) - (SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio) * (Descuento / 100));

                                //detalle.Total = (detalle.CantidadCotizacion * detalle.Precio) - impDescuento;

                                //if (this.logica.remision.ProveedorBeneficio == PROVEEDOR_PFIZER)
                                //{
                                detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((detalle.CantidadCotizacion - detalle.PiezasGratis) * SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio)) - SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(impDescuento));
                                //}

                                detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
                                // detalle.Total = (detalle.Precio * detalle.CantidadCotizacion) - descuentoPorcentaje;

                                //detalle.Total = detalle.PrecioDescontado * detalle.CantidadCotizacion;

                                LogicaCotiza.CotizacionM.Descuento += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(impDescuento);
                            }
                            else
                            {
                                detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                                detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((detalle.CantidadCotizacion - detalle.PiezasGratis) * SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio)));
                            }
                        }
                        else if (ConvenioCliente.PorDesc > 0)
                        {
                            decimal impDescuento = (SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio) * detalle.CantidadCotizacion) * (Descuento / 100);
                            detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio) - (SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio) * (Descuento / 100));

                            detalle.Total = ((detalle.CantidadCotizacion - detalle.PiezasGratis) * SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio)) - SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(impDescuento);
                            detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
                            LogicaCotiza.CotizacionM.Descuento += impDescuento;
                        }
                        else
                        {
                            detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                            detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                            detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((detalle.CantidadCotizacion - detalle.PiezasGratis) * SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio)));
                        }
                    }
                    else
                        if (!Articulo.TIPO_MEDICAMENTO_CVE.Contains("SD"))
                        {
                            detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);

                            decimal impDescuento = (detalle.Precio * detalle.CantidadCotizacion) * (Descuento / 100);
                            detalle.PrecioDescontado = detalle.Precio - (detalle.Precio * (Descuento / 100));

                            //detalle.Total = (detalle.CantidadCotizacion * detalle.Precio) - impDescuento;

                            //if (this.logica.remision.ProveedorBeneficio == PROVEEDOR_PFIZER)
                            //{
                            detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((detalle.CantidadCotizacion - detalle.PiezasGratis) * detalle.Precio) - impDescuento);
                            //}

                            detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
                            // detalle.Total = (detalle.Precio * detalle.CantidadCotizacion) - descuentoPorcentaje;

                            //detalle.Total = detalle.PrecioDescontado * detalle.CantidadCotizacion;

                            LogicaCotiza.CotizacionM.Descuento += impDescuento;
                        }
                        else
                        {
                            detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                            detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((detalle.CantidadCotizacion - detalle.PiezasGratis) * detalle.Precio));
                        }

                }
                else
                {
                    //SIFModelo.Inventarios.ListaPrecios preciosSub = new SIFNegocio.Articulo().ArticuloPrecioSub(detalle.ArticuloID);
                    //detalle.Precio = preciosSub.PRECIO_VENTA;
                    detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                    detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((detalle.CantidadCotizacion - detalle.PiezasGratis) * detalle.Precio));

                }

                SIFModelo.Inventarios.ListaPrecios preciosd = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
                detalle.PrecioCosto = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(preciosd.PRECIO_COSTO);
            }

            LogicaCotiza.CotizacionM.SubTotal = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(LogicaCotiza.CotizacionDetalles.Sum(r => r.Precio * (r.CantidadCotizacion - r.PiezasGratis)));

            //descuentos de la tarjeta
            //var descuentoTarjeta = logica.RemisionDetalles.Sum(r => r.MontoDescuento * r.CantidadCotizacion);
            //logica.remision.Descuento += decimal.Parse(descuentoTarjeta.ToString());



            decimal descuentoProveedor = 0;
            if (LogicaCotiza.CotizacionM.ProveedorBeneficio == PROVEEDOR_NADRO)
            {
                LogicaCotiza.CotizacionM.SubTotal = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(LogicaCotiza.CotizacionDetalles.Sum(r => r.Precio * (r.CantidadCotizacion)));

                foreach (SIFModelo.CotizacionDetalle detalle in LogicaCotiza.CotizacionDetalles)
                {
                    SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);

                    if (detalle.ImpuestoID == 1)
                    {
                        //ASIGNAR EL PRECIO Y RECALCULAR
                        detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_VENTA_MAX);
                        LogicaCotiza.CotizacionM.SubTotal = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(LogicaCotiza.CotizacionDetalles.Sum(r => r.Precio * (r.CantidadCotizacion)));
                        this.subtotalLabelX.Text = LogicaCotiza.CotizacionM.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

                        if (detalle.Descto > 0)
                        {
                            detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_VENTA_MAX - detalle.Descto);
                            detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioDescontado * detalle.CantidadCotizacion);
                            descuentoProveedor += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((precios.PRECIO_VENTA_MAX - detalle.PrecioDescontado) * (detalle.CantidadCotizacion));
                        }
                        else
                        {
                            detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_VENTA_MAX - (precios.PRECIO_VENTA_MAX * (detalle.PorcentajeDescuento / 100)));
                            detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioDescontado * detalle.CantidadCotizacion);
                            descuentoProveedor += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((precios.PRECIO_VENTA_MAX - detalle.PrecioDescontado) * (detalle.CantidadCotizacion));
                        }

                        detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                    }

                    if (detalle.TipoPrecioDescuento == 2)
                    {
                        if (detalle.Descto > 0)
                        {
                            detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_VENTA - detalle.Descto);
                            detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioDescontado * detalle.CantidadCotizacion);
                            descuentoProveedor += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((precios.PRECIO_VENTA - detalle.PrecioDescontado) * (detalle.CantidadCotizacion));
                        }
                        else
                        {

                            detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_VENTA - (precios.PRECIO_VENTA * (detalle.PorcentajeDescuento / 100)));
                            detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioDescontado * detalle.CantidadCotizacion);
                            descuentoProveedor += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((precios.PRECIO_VENTA - detalle.PrecioDescontado) * (detalle.CantidadCotizacion));
                        }

                        detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                    }

                    if (detalle.PrecioProveedor > 0)
                    {
                        //detalle.Precio = detalle.PrecioProveedor;
                        detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioProveedor);
                        detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioDescontado * detalle.CantidadCotizacion);
                        descuentoProveedor += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((precios.PRECIO_VENTA - detalle.PrecioDescontado) * detalle.CantidadCotizacion);

                        //LogicaCotiza.remision.SubTotal = LogicaCotiza.RemisionDetalles.Sum(r => r.Precio * (r.CantidadCotizacion));
                        //this.subtotalLabelX.Text = LogicaCotiza.remision.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

                        detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                    }

                    //descuentoProveedorLabelX.Text = descuentoProveedor.ToString("C2");
                }
            }


            // descuento;
            // LogicaCotiza.remision.Total = LogicaCotiza.remision.SubTotal - LogicaCotiza.remision.Descuento - descuentoProveedor;

            foreach (SIFModelo.CotizacionDetalle detalle in LogicaCotiza.CotizacionDetalles)
            {
                //decimal descuentoPorcentaje = (detalle.Precio * detalle.CantidadCotizacion) * (detalle.PorcentajeDescuento / 100);
                //detalle.PrecioDescontado = detalle.Precio;

                //detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
                // detalle.Total = (detalle.Precio * detalle.CantidadCotizacion) - descuentoPorcentaje;

                SIFModelo.Inventarios.ListaPrecios precios = null;
                //CALCULAR IVA
                if (ClienteSub != null)
                {
                    if (ClienteSub.PRECIO_FIJO == SIFModelo.Tipos.SiNo.SI)
                    {
                        precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
                    }
                    else
                    {
                        precios = new SIFNegocio.Articulo().ArticuloPrecioSub(detalle.CODIGO_CLI);
                    }
                }
                else
                {
                    precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
                }
                if (precios != null)
                {
                    SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);
                    if (impuesto != null)
                    {
                        decimal porcentaje = impuesto.Porcentaje / 100;

                        detalle.IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((detalle.Total / (1 + porcentaje)) * porcentaje);
                        detalle.PorcentajeIVA = porcentaje;
                        detalle.ImpuestoID = impuesto.ID;
                    }
                }

                detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioDescontado * detalle.CantidadCotizacion);


                if (this.LogicaCotiza.CotizacionM.ProveedorBeneficio == PROVEEDOR_PFIZER)
                {
                    detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioDescontado * (detalle.CantidadCotizacion - detalle.PiezasGratis));
                }

            }

            this.LblDescuento.Text = (LogicaCotiza.CotizacionM.Descuento + descuentoProveedor).ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

            LogicaCotiza.CotizacionM.ImpuestoVenta = LogicaCotiza.CotizacionDetalles.Sum(r => r.IVA);
            this.IVAlabelX.Text = LogicaCotiza.CotizacionM.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.LogicaCotiza.CotizacionM.SubTotal = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(LogicaCotiza.CotizacionM.SubTotal - LogicaCotiza.CotizacionM.ImpuestoVenta);
            this.subtotalLabelX.Text = LogicaCotiza.CotizacionM.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            
            this.LogicaCotiza.CotizacionM.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(LogicaCotiza.CotizacionM.SubTotal - LogicaCotiza.CotizacionM.Descuento - descuentoProveedor + LogicaCotiza.CotizacionM.ImpuestoVenta);
            this.totalLabelX.Text = LogicaCotiza.CotizacionM.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.LogicaCotiza.CotizacionM.ImpuestoVenta = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(LogicaCotiza.CotizacionDetalles.Sum(r => r.IVA));
            this.IVAlabelX.Text = LogicaCotiza.CotizacionM.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.LogicaCotiza.CotizacionM.ImporteLetra = sif_tools.NumberToLetters.NumToLetter((double)LogicaCotiza.CotizacionM.Total, LogicaCotiza.CotizacionM.Total.GetType().ToString());
            totalLetraLabelX.Text = this.LogicaCotiza.CotizacionM.ImporteLetra;
            LogicaCotiza.CotizacionM.Descuento = LogicaCotiza.CotizacionM.Descuento + descuentoProveedor;

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
                this.ModificaCantidadArticulo();
            }
        }

        private void agregaProductoButtonItem_Click(object sender, EventArgs e)
        {
            this.SeleccionaArticulo();
        }

        private void superGridControl1_RowDeleting(object sender, GridRowDeletingEventArgs e)
        {
            //if (!this.Eliminar())
            //{
            //    e.Cancel = true;
            //}
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

        private void descuentoCredencialButtonItem_Click(object sender, EventArgs e)
        {


            DescuentoForm frmDescuento = new DescuentoForm();
            if (frmDescuento.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            switch (Cual)
            {
                case 0:
                    Descuento = frmDescuento.DescuentoProveedor;
                    //LogicaCotiza.CotizacionM.Descuento = frmDescuento.DescuentoProveedor;
                    LogicaCotiza.CotizacionM.NumeroCredencial = frmDescuento.TarjetaID;
                    foreach (SIFModelo.CotizacionDetalle detalle in LogicaCotiza.CotizacionDetalles)
                        LogicaCotiza.RecalculaDetalle(detalle, LogicaCotiza.CotizacionM);
                    break;
                case 1:
                    LogicaPedidos.Pedido.NumeroCredencial = frmDescuento.TarjetaID;
                    LogicaPedidos.Pedido.PorcentajeDescuento = frmDescuento.DescuentoProveedor;
                    LogicaPedidos.Pedido.Descuento = 0;
                    foreach (SIFModelo.PedidoDetalle detalle in LogicaPedidos.PedidoDetalles)
                        LogicaPedidos.RecalculaDetalle(detalle, LogicaPedidos.Pedido);
                    break;
                case 2:
                    LogicaApartados.ApartadoM.NumeroCredencial = frmDescuento.TarjetaID;
                    LogicaApartados.ApartadoM.Descuento = 0;
                    LogicaApartados.ApartadoM.PorcentajeDescuento = frmDescuento.DescuentoProveedor;
                    foreach (SIFModelo.ApartadoDetalle detalle in LogicaApartados.ApartadoDetalles)
                        LogicaApartados.RecalculaDetalle(detalle, LogicaApartados.ApartadoM);

                    break;
            }


           MessageBox.Show("La tarjeta " + frmDescuento.TarjetaID + " se utilizará  para la venta");
            this.statusLabel.Text = "DESCUENTO " + frmDescuento.TarjetaID;


            /*
            {
                logica.RecalculaDetalle(detalle, LogicaCotiza.CotizacionM);
            }*/

            this.CalculaTotal();

        }

        private void sucursalesComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cual > 0)
            {
                int sucursalID = (int)sucursalesComboBoxEx.SelectedValue;
                switch (Cual)
                {

                    case 1:
                        LogicaPedidos.Pedido.NumeroPedido = LogicaPedidos.NumeroPedido(sucursalID);
                        folioCotizacionLabelX.Text = LogicaPedidos.Pedido.NumeroPedido;
                        break;
                    case 2:
                        LogicaApartados.ApartadoM.NumeroApartado = LogicaApartados.NumeroApartado(sucursalID);
                        folioCotizacionLabelX.Text = LogicaApartados.ApartadoM.NumeroApartado;
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

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (!this.Eliminar())
                {
                    e.Handled = true;
                }
            }

            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }
        }

    }
}
