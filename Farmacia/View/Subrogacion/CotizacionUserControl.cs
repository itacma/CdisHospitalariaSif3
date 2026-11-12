using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using SIF.View.Ventas;
using Excel;
using System.IO;
using System.Text.RegularExpressions;

namespace SIF.View.Subrogacion
{
    public partial class CotizacionUserControl : Templates.ListaUserControl
    {
        public object Owner;
        public object Owner1;
        private DataTable dtLicitacion = new DataTable();
        public int Cual;
        public SIFModelo.Cotizacion PCotiza;
        private decimal fTotal;
        private bool Pasa = false;
        private bool BPedidoE = false;
        private SIFModelo.WebServices.TarjetaPfizer pfizer = new SIFModelo.WebServices.TarjetaPfizer();
        private SIFModelo.WebServices.TarjetaNadro nadro = new SIFModelo.WebServices.TarjetaNadro();
        private decimal Descuento;
        private decimal PorScosto;
        private int UsuarioID=0;
        SIFModelo.ClienteConvenio ConvenioCliente;
        SIFNegocio.ClienteConvenios clienteN = new SIFNegocio.ClienteConvenios();
        public CotizacionUserControl(bool ocultarCliente = false)
        {
            InitializeComponent();
            InicializaColumnas();
            if (ocultarCliente)
            {switch (Cual)
            {case 0:
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

            cargaSucursales();
            Privilegios();
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
            this.agregaProductoButtonItem.Shortcuts.Clear();
        }
        GridPanel dataGrid;

        private void reportarFaltantes()
        {
            if (this.LogicaPedidos.articulosFaltantes.Count > 0)
            {
                SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(this.LogicaPedidos.Pedido.VendedorID);
                View.Ventas.FaltantesForm frmFaltantes = new FaltantesForm(usuario, this.LogicaPedidos.articulosFaltantes);
                frmFaltantes.ShowDialog();
            }
        }

        public void Back()
        {

            if (this.dataGrid.Rows.Count > 0 && !Pasa)
            {
                DialogResult res=0;
                switch (Cual)
                {
                    case 0:
                    case 3:
                    case 4:
                           res =MessageBox.Show("La Cotización esta en proceso, ¿desea cancelarla?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                           break;

                   
               }

                

                if (res == DialogResult.No)
                {
                    return;
                }
            }

            if (Cual == 1)
                if (this.LogicaPedidos.articulosFaltantes.Count > 0)
                {
                    DialogResult dres =MessageBox.Show("Hay faltantes a reportar, ¿desea reportarlos?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dres == DialogResult.Yes)
                    {
                        this.reportarFaltantes();
                    }
                }
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
                    propietario.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }
                this.Mostrado = false;
            }
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

                    //asigna cliente mostrador
                    if (PCotiza != null)
                    { LogicaCotiza.CotizacionM = PCotiza;
                    folioCotizacionLabelX.Text = PCotiza.NumeroCotizacion.ToString();
                    
                        
                        SIFNegocio.Clientes ClienteL = new SIFNegocio.Clientes();
                        SIFModelo.Cliente cliente = ClienteL.ClientePorID(PCotiza.ClienteID);
                        clienteLabelX.Text = cliente.Nombre+' '+cliente.ApellidoPaterno+' '+cliente.ApellidoMaterno;

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
                    titleLabel.Text = "SIF\\Cotización";
                    LogicaCotiza.CotizacionM.PorcentajeDescuento = Descuento;
                    if (LogicaCotiza.CotizacionM.VendedorID == 0)
                         this.LogicaCotiza.CotizacionM.VendedorID = UsuarioID;
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
                     

                    }
                   if (PCotiza != null)
                   {   
                       foreach (SIFModelo.CotizacionDetalle Cdetalle in PCotiza.Detalles)
                       {
                           this.PrecioArticulo(Cdetalle, PorScosto);
                           LogicaCotiza.AgregaDetalle(Cdetalle);
                       }
                   }
                   this.superGridControl1.PrimaryGrid.DataSource = LogicaCotiza.CotizacionDetalles;
                   superGridControl1.PrimaryGrid.Columns["CANTIDADColumn"].DataPropertyName = "CantidadCotizacion";
                   LogicaCotiza.RecalculaDetalle(LogicaCotiza.CotizacionDetalles, LogicaCotiza.CotizacionM);
                   CalculaTotal();
                    break;
                case 1:
                    break;
                    
                    CalculaTotal();
            }
            bar1.Refresh();
        }
        #endregion

        #region Funciones y Metodos

        private void InicializaColumnas()
        {
            dtLicitacion.Columns.Add("Sec", typeof(int));
            dtLicitacion.Columns.Add("Clave", typeof(string));
            dtLicitacion.Columns.Add("Descripcion", typeof(string));
            dtLicitacion.Columns.Add("UMedida", typeof(string));
            dtLicitacion.Columns.Add("Presentacion", typeof(string));
            dtLicitacion.Columns.Add("Cantidad", typeof(int));
            dtLicitacion.Columns.Add("PSinIva", typeof(double));
            dtLicitacion.Columns.Add("Importe", typeof(double));
            dtLicitacion.Columns.Add("Proveedor", typeof(string));
            dtLicitacion.Columns.Add("Marca", typeof(string));
            dtLicitacion.Columns.Add("Porc_Farm", typeof(double));
            dtLicitacion.Columns.Add("Precio_Farm", typeof(double), "PSinIva + ( PSinIva * (Porc_Farm / 100))");
            dtLicitacion.Columns.Add("Importe_Farm", typeof(double), "Cantidad * Precio_Farm");
            dtLicitacion.Columns.Add("Proveedor_Farm", typeof(string));

            dtLicitacion.PrimaryKey = new DataColumn[] { dtLicitacion.Columns["Sec"],
                                                           dtLicitacion.Columns["Clave"] };

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
                    detalle.CantidadCotizacion = detalle.CantidadCotizacion+int.Parse(this.cantidadTextBoxX.Text);
                    this.PrecioArticulo(detalle, PorScosto);
                    LogicaCotiza.AgregaDetalle(detalle);
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaCotiza.CotizacionDetalles;
                    break;
                case 1:
                    if (articulo.TIPO_MEDICAMENTO_CVE.Contains("F1") && articulo.TIPO_MEDICAMENTO_CVE.Contains("T3"))
                    {
                        //pedimos el folio de la receta
                        if (LogicaPedidos.Pedido.Receta!=SIFModelo.Tipos.SiNo.NO)
                        {
                            View.Ventas.RecetaMedicoForm frmrec =new View.Ventas.RecetaMedicoForm();
                            frmrec.ShowDialog();
                            LogicaPedidos.Pedido.Receta=SIFModelo.Tipos.SiNo.SI;
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
                    detallePed.CantidadPedido =int.Parse(this.cantidadTextBoxX.Text);
                    this.PrecioArticulo(detallePed);
                    
                    LogicaPedidos.AgregaDetalle(ref detallePed,articulo ,ref LogicaPedidos);
                    LogicaPedidos.RecalculaDetalle(detallePed, LogicaPedidos.Pedido);
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaPedidos.PedidoDetalles;
                    superGridControl1.PrimaryGrid.Columns["CANTIDADColumn"].DataPropertyName = "CantidadPedido";
                    break;
                case 2:

                    if (articulo.TIPO_MEDICAMENTO_CVE.Contains("F1") )
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
                    detalleApa.CantidadApartado =int.Parse(this.cantidadTextBoxX.Text);
                    this.PrecioArticulo(detalleApa);
                    // verificamos el inventario
                    SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
                    int existencias = 0;
                    
                    BPedidoE=LogicaApartados.AgregaDetalle(detalleApa, articulo,BPedidoE);
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

        private bool PrecioArticulo(SIFModelo.CotizacionDetalle detalle,Decimal PorSCosto)
        {
            SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
            if (precios == null)
            {
               MessageBox.Show("No hay un precio activo para este producto");
                return false;
            }
            else
            {
                if (PorScosto > 0)
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
            
            int G=0;
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
                     this.CalculaTotal();
                     LogicaCotiza.CotizacionM.VendedorID = Helpers.Sesion.Usuario.UsuariosID;
                     if (PCotiza == null)
                         LogicaCotiza.CotizacionM.NumeroCotizacion = LogicaCotiza.NumeroCotizacion(sucursalID);
                     else
                         LogicaCotiza.Elimina(LogicaCotiza.CotizacionM);
                     LogicaCotiza.CotizacionM.SucursalID = sucursalID;
                     LogicaCotiza.CotizacionM.Comentario = textBoxX1.Text;
                    if (Cual==3)
                        LogicaCotiza.CotizacionM.TipoCotizacion = SIFModelo.Tipos.TipoCotizacion.CONVENIO;
                    else
                        if(Cual==4)
                          LogicaCotiza.CotizacionM.TipoCotizacion = SIFModelo.Tipos.TipoCotizacion.SUBRROGACION;
                        else
                            LogicaCotiza.CotizacionM.TipoCotizacion = SIFModelo.Tipos.TipoCotizacion.CALLCENTER;
                    LogicaCotiza.CotizacionM.Activo = SIFModelo.Tipos.SiNo.SI;
                     G= LogicaCotiza.GuardaDatos(LogicaCotiza);
                    
                     break;
                case 1:
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
                    LogicaApartados.ApartadoM.Comentario=textBoxX1.Text;

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
                 this.Back(); 
            }
            else
            {switch (G)
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
            

        }

        private bool esClienteMostrador()
        {
            if (conCliente)
            {
                return false;
            }
            switch  (Cual)
                {   case 0:
                case 3:
                case 4:
                     if (this.LogicaCotiza.CotizacionM.ClienteID == 0 || this.LogicaCotiza.CotizacionM.ClienteID == 1 || this.LogicaCotiza.CotizacionM.ClienteID == 0)
                         return true;
                       break;
                    case 1:
                    if (LogicaPedidos.Pedido.ClienteID==0 || LogicaPedidos.Pedido.ClienteID==1)
                        return true;
                    break;
                    case 2:
                    if (LogicaApartados.ApartadoM.ClienteID==0 || LogicaApartados.ApartadoM.ClienteID==1)
                        return true;
                    break;

                }
            return false;
        }

        private bool Eliminar()
        {

            DialogResult resp =MessageBox.Show("¿Eliminar los productos seleccinados?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != DialogResult.Yes)
            {
                return false;
            }

            var seleccionadas = this.superGridControl1.PrimaryGrid.SelectedRows;

            foreach (GridContainer detalle in seleccionadas)
            {
                GridRow fila = detalle as GridRow;
                switch (Cual)
                { case 0:
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
        { switch (Cual)
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
            string claveArticulo="";
            switch (Cual)
            {  case 0:
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
                     
                    //verificamos si es cliente convenio y obtenemos el descuento de la tabla
                     if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
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
                    if (Cual==4)
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
                    {  this.LogicaPedidos.Pedido.ClienteID = cliente.ID;
                    // mostramos la direccion del cliente para que la cambie en caso de que la neseciten cambiar

                    SIFModelo.DireccionCliente dirCasa = new SIFModelo.DireccionCliente();
                    SIFModelo.DireccionCliente dirFiscal = new SIFModelo.DireccionCliente();
                    cliente.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                   // dirCasa  = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);
                    Catalogos.DireccionClienteForm frmCliente = new Catalogos.DireccionClienteForm(cliente);
                    if (frmCliente.ShowDialog() != DialogResult.OK)
                     return;
                    cliente = new SIFNegocio.Clientes().ClientePorID(cliente.ID);
                    if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
                    {
                        ConvenioCliente = clienteN.ClientePorID(cliente.ID);
                        Descuento = ConvenioCliente.PorDesc;
                        PorScosto = ConvenioCliente.PorScosto;
                        LogicaPedidos.Pedido.PorcentajeDescuento = ConvenioCliente.PorDesc;
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

                   }
                     break;
                case 2:
                     this.LogicaApartados.ApartadoM.ClienteID=cliente.ID;
                     if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
                     {
                         ConvenioCliente = clienteN.ClientePorID(cliente.ID);
                         Descuento = ConvenioCliente.PorDesc;
                         PorScosto = ConvenioCliente.PorScosto;
                     }
                     LogicaApartados.ApartadoM.PorcentajeDescuento = cliente.Descuento;
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
                case 3:
                case 4:
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaCotiza.CotizacionDetalles;
                    folioCotizacionLabelX.Text = LogicaCotiza.NumeroCotizacion(Helpers.Sesion.Sucursal.SucursalID).ToString();
                    this.CodigoTextBoxX.Focus();
                    break;
                case 1:
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaPedidos.PedidoDetalles;
                    folioCotizacionLabelX.Text =LogicaPedidos.NumeroPedido(Helpers.Sesion.Sucursal.SucursalID).ToString();
                    this.CodigoTextBoxX.Focus();
                    tableLayoutPanel2.Visible = true;
                    break;
                case 2:
                    this.superGridControl1.PrimaryGrid.DataSource = LogicaApartados.ApartadoDetalles;
                    folioCotizacionLabelX.Text =LogicaApartados.NumeroApartado(Helpers.Sesion.Sucursal.SucursalID).ToString();
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
                   case 3:
                   case 4:
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

        private void CalculaTotal()
        {
            switch (Cual)
            {case 0:
                case 3:
                case 4:
                LogicaCotiza.CotizacionM.TotalArticulos = LogicaCotiza.CotizacionDetalles.Sum(r => r.CantidadCotizacion);
                LogicaCotiza.CotizacionM.SubTotal = LogicaCotiza.CotizacionDetalles.Sum(r => r.Precio * r.CantidadCotizacion);
                // logica.remision.Descuento 
                LogicaCotiza.CotizacionM.Descuento = LogicaCotiza.CotizacionM.SubTotal * (Descuento / (decimal)100.0);
                this.LblDescuento.Text = LogicaCotiza.CotizacionM.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                LogicaCotiza.CotizacionM.Total = LogicaCotiza.CotizacionM.SubTotal - LogicaCotiza.CotizacionM.Descuento;
                LogicaCotiza.CotizacionM.ImpuestoVenta = LogicaCotiza.CotizacionDetalles.Sum(r => r.IVA);
                LogicaCotiza.CotizacionM.SubTotal = LogicaCotiza.CotizacionM.SubTotal - LogicaCotiza.CotizacionM.ImpuestoVenta;
                this.tb_SubTotalClt.Text = LogicaCotiza.CotizacionM.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                this.tb_IvaClt.Text = LogicaCotiza.CotizacionM.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

                this.LogicaCotiza.CotizacionM.Total = LogicaCotiza.CotizacionM.SubTotal - LogicaCotiza.CotizacionM.Descuento + LogicaCotiza.CotizacionM.ImpuestoVenta;
                fTotal = LogicaCotiza.CotizacionM.Total;
                this.tb_TotalClt.Text = LogicaCotiza.CotizacionM.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                this.LogicaCotiza.CotizacionM.ImpuestoVenta = LogicaCotiza.CotizacionDetalles.Sum(r => r.IVA);
                this.tb_IvaClt.Text = LogicaCotiza.CotizacionM.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                this.LogicaCotiza.CotizacionM.ImporteLetra = sif_tools.NumberToLetters.NumToLetter((double)LogicaCotiza.CotizacionM.Total, LogicaCotiza.CotizacionM.Total.GetType().ToString());
                totalLetraLabelX.Text = this.LogicaCotiza.CotizacionM.ImporteLetra;
                LblDescuento.Text = LogicaCotiza.CotizacionM.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            break;
                case 1:
                LogicaPedidos.Pedido.TotalArticulosPedido = LogicaPedidos.PedidoDetalles.Sum(r => r.CantidadPedido);
                LogicaPedidos.Pedido.SubTotal = LogicaPedidos.PedidoDetalles.Sum(r => r.Precio * r.CantidadPedido);

                //LogicaPedidos.Pedido.Descuento = LogicaPedidos.Pedido.SubTotal * (Descuento / (decimal)100.0);
                //this.LblDescuento.Text = LogicaPedidos.Pedido.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                 // descuento;
                LogicaPedidos.Pedido.Total = LogicaPedidos.Pedido.SubTotal - LogicaPedidos.Pedido.Descuento;
                LogicaPedidos.Pedido.ImpuestoVenta = LogicaPedidos.PedidoDetalles.Sum(r => r.IVA);
                LogicaPedidos.Pedido.SubTotal = LogicaPedidos.Pedido.SubTotal - LogicaPedidos.Pedido.ImpuestoVenta;
                this.tb_IvaClt.Text = LogicaPedidos.Pedido.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                this.tb_SubTotalClt.Text = LogicaPedidos.Pedido.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                this.LogicaPedidos.Pedido.Total = LogicaPedidos.Pedido.SubTotal - LogicaPedidos.Pedido.Descuento + LogicaPedidos.Pedido.ImpuestoVenta;
                fTotal = LogicaPedidos.Pedido.Total;
                this.tb_TotalClt.Text = LogicaPedidos.Pedido.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                this.LogicaPedidos.Pedido.ImpuestoVenta = LogicaPedidos.PedidoDetalles.Sum(r => r.IVA);
                this.tb_IvaClt.Text = LogicaPedidos.Pedido.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                this.LogicaPedidos.Pedido.ImporteLetra = sif_tools.NumberToLetters.NumToLetter((double)LogicaPedidos.Pedido.Total, LogicaPedidos.Pedido.Total.GetType().ToString());
                totalLetraLabelX.Text = this.LogicaPedidos.Pedido.ImporteLetra;
                LblDescuento.Text = LogicaPedidos.Pedido.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                break;
            case 2 :
                LogicaApartados.ApartadoM.TotalArticulos = LogicaApartados.ApartadoDetalles.Sum(r => r.CantidadApartado);
                LogicaApartados.ApartadoM.SubTotal = LogicaApartados.ApartadoDetalles.Sum(r => r.Precio * r.CantidadApartado);
                

                // descuento;
                LogicaApartados.ApartadoM.Total = LogicaApartados.ApartadoM.SubTotal - LogicaApartados.ApartadoM.Descuento;
                LogicaApartados.ApartadoM.ImpuestoVenta = LogicaApartados.ApartadoDetalles.Sum(r => r.IVA);
                LogicaApartados.ApartadoM.SubTotal = LogicaApartados.ApartadoM.SubTotal - LogicaApartados.ApartadoM.ImpuestoVenta;
                this.tb_IvaClt.Text = LogicaApartados.ApartadoM.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                this.tb_SubTotalClt.Text = LogicaApartados.ApartadoM.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                this.LogicaApartados.ApartadoM.Total = LogicaApartados.ApartadoM.SubTotal - LogicaApartados.ApartadoM.Descuento + LogicaApartados.ApartadoM.ImpuestoVenta;
                fTotal = LogicaApartados.ApartadoM.Total;
                this.tb_TotalClt.Text = LogicaApartados.ApartadoM.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                this.LogicaApartados.ApartadoM.ImpuestoVenta = LogicaApartados.ApartadoDetalles.Sum(r => r.IVA);
                this.tb_IvaClt.Text = LogicaApartados.ApartadoM.ImpuestoVenta.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                this.LogicaApartados.ApartadoM.ImporteLetra = sif_tools.NumberToLetters.NumToLetter((double)LogicaApartados.ApartadoM.Total, LogicaApartados.ApartadoM.Total.GetType().ToString());
                totalLetraLabelX.Text = this.LogicaApartados.ApartadoM.ImporteLetra;
                LblDescuento.Text = LogicaApartados.ApartadoM.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                break;
        }
            
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

        private void superGridControl1_RowDeleting(object sender, GridRowDeletingEventArgs e)
        {
            if (!this.Eliminar())
            {
                e.Cancel = true;
            }
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
                        LogicaPedidos.Pedido.Factura=SIFModelo.Tipos.SiNo.SI;
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
            { case 1:
                    LogicaPedidos.Pedido.NumeroCredencial = frmDescuento.TarjetaID;
                    LogicaPedidos.Pedido.PorcentajeDescuento = frmDescuento.DescuentoProveedor;
                    LogicaPedidos.Pedido.Descuento = 0;
                    foreach (SIFModelo.PedidoDetalle detalle in LogicaPedidos.PedidoDetalles)
                        LogicaPedidos.RecalculaDetalle(detalle, LogicaPedidos.Pedido);
               break;
               case 2:
                    LogicaApartados.ApartadoM.NumeroCredencial = frmDescuento.TarjetaID;
                    LogicaApartados.ApartadoM.Descuento = 0;
                    LogicaApartados.ApartadoM.PorcentajeDescuento=frmDescuento.DescuentoProveedor;
                    foreach (SIFModelo.ApartadoDetalle detalle in LogicaApartados.ApartadoDetalles)
                        LogicaApartados.RecalculaDetalle(detalle, LogicaApartados.ApartadoM);

               break;
            }

            
           MessageBox.Show("La tarjeta " + frmDescuento.TarjetaID + " se utilizará  para la venta");
            this.statusLabel.Text = "DESCUENTO " + frmDescuento.TarjetaID ;

            
            /*
            {
                logica.RecalculaDetalle(detalle, logica.remision);
            }*/

            this.CalculaTotal();
        
        }

        private void sucursalesComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (Cual>0)
            {
                int sucursalID = (int) sucursalesComboBoxEx.SelectedValue;
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

        

        

        
       
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true,true);
            }
        }

        private void CodigoTextBoxX_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btn_SelectFileXls_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Seleccione el archivo Excel a Procesar";
            ////fdlg.InitialDirectory = ConfigSettings.ReadSetting("PathPSEntrada"); //@"D:\";
            fdlg.Filter = "Excel files (*.xls;*xlsx)|*.xls;*.xlsx";
            //fdlg.FilterIndex = 2 ;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                tb_FileXlsClt.Text = fdlg.FileName;
                string FName = fdlg.SafeFileName;
                string FPath = Path.GetDirectoryName(tb_FileXlsClt.Text);
                string FExt = Path.GetExtension(tb_FileXlsClt.Text);
                try
                {
                    // Lee archivo
                    FileStream stream = File.Open(Path.Combine(FPath, FName), FileMode.Open, FileAccess.Read);
                    IExcelDataReader excelReader;
                    if (Regex.IsMatch(FExt, "xlsx", RegexOptions.IgnoreCase))
                        // Reading from a OpenXml Excel file (2007 format; *.xlsx)
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    else
                        // Reading from a binary Excel file ('97-2003 format; *.xls)
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

                    DataSet result = excelReader.AsDataSet();
                    excelReader.IsFirstRowAsColumnNames = true;
                    int row_no = 1, ind = 0;
                    // Crea Pedido
                    ////result.Tables[0].DefaultView.ToTable(true, "NO.");
                    LogicaCotiza.CotizacionDetalles.Clear();
                    dtLicitacion.Rows.Clear();
                    object[] Keys = new object[2];
                    DataRow FacRow;
                    int value;
                    if (result.Tables.Count > 0)
                    {
                        while (row_no < result.Tables[ind].Rows.Count) // ind is the index of table (sheet name) which you want to convert to csv
                        {
                            if (int.TryParse(result.Tables[ind].Rows[row_no][0].ToString(), out value))
                            {
                                Keys[0] = result.Tables[ind].Rows[row_no][0].ToString(); // Sec
                                Keys[1] = result.Tables[ind].Rows[row_no][1].ToString(); // Clave

                                FacRow = dtLicitacion.Rows.Find(Keys);
                                if (FacRow == null)
                                    dtLicitacion.Rows.Add(result.Tables[ind].Rows[row_no][0].ToString(),
                                                          result.Tables[ind].Rows[row_no][1].ToString(),
                                                          result.Tables[ind].Rows[row_no][2].ToString(),
                                                          result.Tables[ind].Rows[row_no][3].ToString(),
                                                          result.Tables[ind].Rows[row_no][4].ToString(),
                                                          result.Tables[ind].Rows[row_no][5].ToString(),
                                                          result.Tables[ind].Rows[row_no][6].ToString(),
                                                          result.Tables[ind].Rows[row_no][7].ToString(),
                                                          result.Tables[ind].Rows[row_no][8].ToString(),
                                                          result.Tables[ind].Rows[row_no][9].ToString(),
                                                          dbl_Porcentaje.Value
                                                        );
                            }

                            row_no++;
                        }
                        excelReader.Close();
                        superGridControl1.PrimaryGrid.DataSource = dtLicitacion;
                        Totales();
                    }
                    else
                       MessageBox.Show("Error al leer el archivo " + FName, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }

        }

        private void Totales()
        {
            //Utils.InitializeDataGridViewCotiza(dtGridCotiza, dtProveedor);
            object objSum = dtLicitacion.Compute("Sum(importe)", null);
            tb_SubTotalClt.Text = double.Parse(objSum.ToString()).ToString("##,###,##0.00");
            tb_IvaClt.Text = (double.Parse(tb_SubTotalClt.Text) * 0.16).ToString("##,###,##0.00");
            tb_TotalClt.Text = (double.Parse(tb_SubTotalClt.Text) + double.Parse(tb_IvaClt.Text)).ToString("##,###,##0.00");

            objSum = dtLicitacion.Compute("Sum(Importe_Farm)", null);
            tb_SubTotalFarm.Text = double.Parse(objSum.ToString()).ToString("##,###,##0.00"); 
            tb_IvaFarm.Text = (double.Parse(tb_SubTotalFarm.Text) * 0.16).ToString("##,###,##0.00");
            tb_TotalFarm.Text = (double.Parse(tb_SubTotalFarm.Text) + double.Parse(tb_IvaFarm.Text)).ToString("##,###,##0.00");
            objSum = dtLicitacion.Compute("Sum(Cantidad)", null);
            int TotArt = 0;
            if (int.TryParse(objSum.ToString(), out TotArt))
                lbl_TotArticulos.Text = TotArt.ToString("N0");
            else
                lbl_TotArticulos.Text = TotArt.ToString("##,###,###");
            ////SIFUtils.AutoNumberRowsForGridView(Grd_PedidoDet);
        }
        private void dbl_Porcentaje_ValueChanged(object sender, EventArgs e)
        {
            foreach (DataRow reg in dtLicitacion.Rows)
            {
                reg["Porc_Farm"] = dbl_Porcentaje.Value;
            }
            Totales();
        }

       
        

    }
}
