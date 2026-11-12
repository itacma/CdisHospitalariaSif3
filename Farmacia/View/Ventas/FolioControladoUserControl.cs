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
    public partial class FoliocontroladoUserControl : Templates.ListaUserControl
    {
        public bool Mostrado = false;
        private bool Pasa = false;
        public Menu.Ventas.ControladosUserControl Owner;
        private SIFModelo.Usuario cajero;
        private SIFModelo.WebServices.TAE tae;
        public FoliocontroladoUserControl()
        {
            InitializeComponent();
            InicializaColumnas();
        }

        private SIFModelo.WebServices.TarjetaPfizer pfizer = new SIFModelo.WebServices.TarjetaPfizer();
        private SIFModelo.WebServices.TarjetaNadro nadro = new SIFModelo.WebServices.TarjetaNadro();

        private SIFNegocio.Remision logica = new SIFNegocio.Remision();


        private const string PROVEEDOR_PFIZER = "PFIZER";
        private const string PROVEEDOR_NADRO = "NADRO";

        public object convertidaDe;

        #region Funciones y Metodos

        private void InicializaColumnas()
        {
            if (dataGrid == null)
            {
                return;
            }

            GridIntegerInputEditControl CANTIDADColumn = this.dataGrid.Columns["CANTIDADColumn"].EditControl as GridIntegerInputEditControl;
            CANTIDADColumn.MinValue = 1;
            //GridTextBoxXEditControl BPColumn = dataGrid.Columns["BPColumn"].EditControl as GridTextBoxXEditControl;
            //BPColumn.ButtonCustom.Visible = true;
            //BPColumn.ButtonCustomClick += BPColumn_ButtonCustom_CLICK;
        }

        void BPColumn_ButtonCustom_CLICK(object sender, EventArgs e)
        {
            GridTextBoxXEditControl txt = sender as GridTextBoxXEditControl;
            if (txt.Text == "NO")
            { return; }

            //MUESTRA LA REGLA DE BENEFICIOS

        }

        private void Calculadora()
        {
            Templates.CalculadoraForm frmCalculadora = new Templates.CalculadoraForm();
            frmCalculadora.Show();
        }

        View.Catalogos.UsuarioUserControl frmUsuario;
        private bool SeleccionaUsuario()
        {
            View.Catalogos.UsuarioUserControl frmusuario = new View.Catalogos.UsuarioUserControl();
            frmusuario.Owner = this;
            frmusuario.Muestra();
            //frmusuario.ShowDialog();
            //if (frmusuario.Usuario == null)
            //{
            //    return false;
            //}
            //logica.remision.VendedorID = frmusuario.Usuario.UsuariosID;
            //this.UsuarioSeleccionado = frmusuario.Usuario.UsuariosID;
            //this.vendedorLabelX.Text = frmusuario.Usuario.Nombre + " " + frmusuario.Usuario.Apellidos;
            //if (frmUsuario == null)
            //{
            //    frmUsuario = new View.Catalogos.UsuarioUserControl();
            //    frmUsuario.Dock = DockStyle.Fill;
            //    frmUsuario.Owner = this;
            //}
            //frmUsuario.Muestra();
            return true;
        }


        private void SeleccionaArticulo()
        {
            View.Articulos.ArticuloUserControl frmArticulo = new Articulos.ArticuloUserControl();

            frmArticulo.Dock = DockStyle.Fill;
            frmArticulo.Owner = this;

            frmArticulo.Muestra();
            //frmArticulo.Owner = this;
            //this.Owner.Owner.ShowModalPanel(frmArticulo, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            //this.DesactivaComandos();
            //frmArticulo.ActivaComandos();
        }

        internal void AgregaArticulo(string claveArticulo)
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

        internal void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            SIFModelo.RemisionDetalle detalle = null;
            //if (logica.RemisionDetalles.Count == 22)
            //{
            //si ya lo contiene puede seguir
            //if (!logica.ContieneDetalle(articulo))
            //{
            //   MessageBox.Show("Se ha alcanzado el máximo numero de lineas");
            //    return;
            //}
            //else
            //{
            //    var vdetalle = from d in logica.RemisionDetalles where d.ArticuloID == articulo.ARTICULO_ID select d;
            //    detalle = vdetalle.First();
            //}

            //}

            SIFModelo.RemisionDetalle detalleAgregado = null;
            if (logica.ContieneDetalle(articulo))
            {
                var vdetalle = from d in logica.RemisionDetalles where d.ArticuloID == articulo.ARTICULO_ID select d;
                detalleAgregado = vdetalle.First();
            }

            if (!articulo.TIPO_MEDICAMENTO_CVE.Contains("F1"))
            {
               MessageBox.Show("El artículo a agregar no es un medicamento controlado");
                return;
            }



            // this.cantidadTextBoxX.Text = "1";
            bool agregado = false;
            if (detalle == null)
            {
                detalle = new SIFModelo.RemisionDetalle();
                agregado = true;
            }

            detalle.ArticuloID = articulo.ARTICULO_ID;
       

            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();

           // detalle.CantidadRemision = int.Parse(this.cantidadTextBoxX.Text);
     //detalle.CantidadRemision +=  int.Parse(this.cantidadTextBoxX.Text);
            int existencias = 0;

            if (detalleAgregado == null)
            {
                detalleAgregado = new SIFModelo.RemisionDetalle();
            }

            if (!inventario.InventarioArticuloSinApartado(articulo, detalleAgregado.CantidadRemision + int.Parse(this.cantidadTextBoxX.Text), out existencias))
            {
                detalleAgregado.CantidadRemision = existencias;
                //this.cantidadTextBoxX.Text = existencias.ToString();
                return;
            }

            if (agregado)
            {
                detalle.CantidadRemision = int.Parse(this.cantidadTextBoxX.Text);
            }

            if (!articulo.TIPO_MEDICAMENTO_CVE.Contains("U2"))
                this.conRecetaCheckBox.Checked = true;



            //detalle.FechaEntrega = 
            //detalle.ImpuestoID = 
            //detalle.IVA = 
            detalle.Nombre1 = articulo.NOMBRE1;
            detalle.Nombre2 = articulo.NOMBRE2;
            detalle.NumeroPartida = logica.RemisionDetalles.Count;
            //detalle.NumeroRemision = Border3DSide;
            //detalle.PaqueteID = articulo.Paquete;

            detalle.DescuentoID = 0;
            detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;

            SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(articulo.ARTICULO_ID);
            if (precios == null)
            {

               MessageBox.Show("No hay un precio activo para este producto");

            }
            else
            {
                detalle.Precio = precios.PRECIO_VENTA;

                if (detalle.Precio == 0)
                {
                   MessageBox.Show("No hay un precio activo para este producto");
                    //return;
                }
            }

            //detalle.PrecioControlado =
            if (precios == null)
            {
                detalle.PrecioCosto = 0;
            }
            else
            {
                detalle.PrecioCosto = precios.PRECIO_COSTO;
            }
            //detalle.ReferenciaNADRO = articulo.id;

            logica.AgregaDetalle(detalle, logica.remision);

            dataGrid.DataSource = logica.RemisionDetalles;
            superGridControl1.Refresh();

            this.CodigoTextBoxX.Text = articulo.ARTICULO_ID;
            this.descripcionTextBoxX.Text = articulo.NOMBRE1;

            this.CalculaTotal();
            this.cantidadTextBoxX.Text = "1";
            this.CodigoTextBoxX.Focus();
        }


        private void marcaFilasValidadas()
        {
            //DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle beneficioRowStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
            //beneficioRowStyle.Background.Color1 = Color.FromArgb(3, 95, 131);
            //beneficioRowStyle.Background.Color2 = Color.FromArgb(3, 95, 131);

            foreach (GridRow row in dataGrid.Rows)
            {
                SIFModelo.RemisionDetalle det = row.DataItem as SIFModelo.RemisionDetalle;

                if (det.Validado)
                {
                    row.ReadOnly = true;
                    //row.CellStyles.Default = beneficioRowStyle;
                    //row.RowStyles.Default.ApplyStyle(beneficioRowStyle);
                }
            }

            this.superGridControl1.Update();
        }

        private void ModificaCantidadArticulo(SIFModelo.RemisionDetalle controladoDetalle = null)
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

            string claveArticulo = this.CodigoTextBoxX.Text;
            int cantidad = 0;
            if (controladoDetalle == null)
            {
                cantidad = int.Parse(cantidadTextBoxX.Text);
            }
            else
            {
                cantidad = controladoDetalle.CantidadRemision;
                claveArticulo = controladoDetalle.ArticuloID;
            }
            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(claveArticulo);

            if (articulo == null)
            {
               MessageBox.Show("El artículo no existe en el catalogo");
                return;
            }
            SIFNegocio.Inventario.Inventario inventario;
            int existencias = 0;
            SIFModelo.RemisionDetalle detalle = null;
            if (!logica.ContieneDetalle(articulo))
            {
                this.AgregaArticulo(articulo);
                return;
            }
            else
            {
                var vdetalle = from d in logica.RemisionDetalles where d.ArticuloID == articulo.ARTICULO_ID select d;
                detalle = vdetalle.First();
            }

            detalle.CantidadRemision = cantidad;
            inventario = new SIFNegocio.Inventario.Inventario();
            if (!inventario.InventarioArticuloSinApartado(articulo, detalle.CantidadRemision, out existencias))
            {
                detalle.CantidadRemision = existencias;
                return;
            }

            logica.ModificaCantidad(articulo, cantidad);
            CalculaTotal();
            superGridControl1.Refresh();
        }

        private void ModificaCantidadArtículo(SIFModelo.RemisionDetalle detalle, int cantidad)
        {
            int existencias = 0;
            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
            SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
            if (!inventario.InventarioArticuloSinApartado(articulo, detalle.CantidadRemision + cantidad, out existencias))
            {
                detalle.CantidadRemision = existencias;
                return;
            }

            logica.ModificaCantidad(articulo, cantidad);
            superGridControl1.Refresh();
        }


        private void CalculaTotal()
        {
            logica.remision.TotalArticulosRemision = logica.RemisionDetalles.Sum(r => r.CantidadRemision);
            logica.remision.SubTotal = logica.RemisionDetalles.Sum(r => r.Precio * r.CantidadRemision);
            // logica.remision.Descuento 
            decimal descuento = logica.remision.SubTotal * (logica.remision.Descuento / (decimal)100.0);
            this.descuentoLabelX.Text = descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.subtotalLabelX.Text = logica.remision.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

            decimal iva = 0;
            this.IVAlabelX.Text = iva.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

            this.logica.remision.Total = logica.remision.SubTotal - descuento + iva;
            this.totalLabelX.Text = logica.remision.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            totalLetraLabelX.Text = sif_tools.NumberToLetters.NumToLetter((double)logica.remision.Total, logica.remision.Total.GetType().ToString());
        }


        private bool EliminaProducto()
        {
            if (this.dataGrid.ActiveRow == null)
            {
               MessageBox.Show("Seleccione el producto a eliminar", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            SIFModelo.RemisionDetalle seleccionado = ((GridRow)(dataGrid.ActiveRow)).DataItem as SIFModelo.RemisionDetalle;

            if (MessageBoxEx.Show("¿Eliminar el artículo " + seleccionado.Nombre1 + " [" + seleccionado.ArticuloID + "]?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return false;
            }

            this.logica.RemisionDetalles.Remove(seleccionado);
            CalculaTotal();
            return true;
        }

        private void CotizacionInstantanea()
        {
            MessageBox.Show("Se ha generado una cotización por un periodo de caducidad de 24 hrs", "Cotización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void DescuentoCredencial()
        {
            if (this.pfizer != null)
            {
               MessageBox.Show("Ya se ha asignado un beneficio de PFIZER");
                return;
            }

            if (this.nadro != null)
            {
               MessageBox.Show("Ya se ha asignado un beneficio de NADRO");
                return;
            }

            DescuentoForm frmDescuento = new DescuentoForm();
            if (frmDescuento.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.logica.remision.TarjetaID = frmDescuento.TarjetaID;
            this.logica.remision.ProveedorBeneficio = frmDescuento.BeneficioProveedor;
            this.logica.remision.Descuento = frmDescuento.DescuentoProveedor;


           MessageBox.Show("La tarjeta " + logica.remision.TarjetaID + " se utilizará  para la venta");
            this.statusLabel.Text = "DESCUENTO " + logica.remision.TarjetaID;

            this.CalculaTotal();
        }

        private void UtilizaPfizer()
        {
            if (!string.IsNullOrEmpty(logica.remision.ProveedorBeneficio) && logica.remision.ProveedorBeneficio != PROVEEDOR_PFIZER)
            {
               MessageBox.Show("Ya existe un beneficio asociado a la venta");
                return;
            }


            if (this.esClienteMostrador())
            {
               MessageBox.Show("Elija un cliente válido");
                return;
            }

            Ventas.PfizerForm frmPfizer = new PfizerForm();
            if (frmPfizer.ShowDialog() == DialogResult.OK)
            {
                this.pfizer = new SIFModelo.WebServices.TarjetaPfizer();
                this.pfizer.TarjetaID = frmPfizer.TarjetaID;
                this.logica.remision.TarjetaID = frmPfizer.TarjetaID;
                logica.remision.ProveedorBeneficio = PROVEEDOR_PFIZER;
                this.statusLabel.Text = "BENEFICIO PFIZER " + logica.remision.TarjetaID;
            }
        }

        private bool esClienteMostrador()
        {
            if (this.logica.remision.ClienteID == 0 || this.logica.remision.ClienteID == 1 || this.logica.remision.ClienteID == 0)
            {
                return true;
            }
            return false;
        }

        private void UtilizaNadro()
        {
            if (!string.IsNullOrEmpty(logica.remision.ProveedorBeneficio) && logica.remision.ProveedorBeneficio != PROVEEDOR_NADRO)
            {
               MessageBox.Show("Ya existe un beneficio asociado a la venta");
                return;
            }

            if (this.esClienteMostrador())
            {
               MessageBox.Show("Elija un cliente válido");
                return;
            }

            Ventas.NadroForm frmNadro = new NadroForm();
            if (frmNadro.ShowDialog() == DialogResult.OK)
            {
                this.nadro = new SIFModelo.WebServices.TarjetaNadro();
                this.nadro.NumeroTarjeta = frmNadro.TarjetaID;
                this.nadro.ClienteID = logica.remision.ClienteID;
                this.logica.remision.TarjetaID = frmNadro.TarjetaID;
                logica.remision.ProveedorBeneficio = PROVEEDOR_NADRO;
                this.statusLabel.Text = "BENEFICIO NADRO " + logica.remision.TarjetaID;

                //revisar si la tarjeta es valida
                SIFNegocio.WebServices.NADRO wsNadro = new SIFNegocio.WebServices.NADRO();
                this.nadro.SesionID = wsNadro.GetLogin(SIFNegocio.Configuracion.Configuraciones.Nadro);
                string respuesta = wsNadro.GetInfoCard(nadro.SesionID, nadro.NumeroTarjeta);
                if (string.IsNullOrEmpty(respuesta))
                {
                    //MessageBoxEx.Show("Tarjeta no válida o inactiva");

                    SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(logica.remision.ClienteID);

                    if (cliente == null)
                    {
                       MessageBox.Show("Cliente no válido, por favor elija un cliente");
                        return;
                    }

                    frmActiveCard frmActiva = new frmActiveCard(nadro.NumeroTarjeta, cliente, Helpers.Sesion.Usuario.Nombre);
                    frmActiva.ShowDialog();
                    this.nadro = null;
                }
            }
        }

        private int UsuarioSeleccionado;
        private void LimpiaVenta()
        {
            if (this.convertidaDe == null)
            {
                this.logica.remision = new SIFModelo.Remision();
                this.logica.RemisionDetalles.Clear();

                this.subtotalLabelX.Text = "$0.00";
                this.IVAlabelX.Text = "$0.00";
                this.totalLabelX.Text = "$0.00";
                this.totalLetraLabelX.Text = "CERO PESOS";
                this.vendedorLabelX.Text = "";
            }

            if (this.dataGrid == null)
            {
                return;
            }
            this.dataGrid.DataSource = logica.RemisionDetalles;
            //Ventas.VentaUsuarioForm frmUsuario = new VentaUsuarioForm();
            //if (frmUsuario.ShowDialog() != DialogResult.OK)
            //{
            //    this.Back();
            //    return;
            //}

            //logica.remision.VendedorID = frmUsuario.Usuario.UsuariosID;
            //this.cajero = frmUsuario.Usuario;
            int numRemision;
            //this.folioVentaLabelX.Text = logica.remision.NumeroRemision;
            //this.vendedorLabelX.Text = cajero.Nombre + " " + cajero.Apellidos;

            this.conRecetaCheckBox.Checked = false;
            this.CodigoTextBoxX.Text = "";

            this.pfizer = null;
            this.nadro = null;
            this.tae = null;
            this.beneficioNotifiado = false;

        }

        private Boolean beneficioNotifiado = false;
        private void Guardar()
        {
            if (logica.RemisionDetalles.Count <= 0)
            {
               MessageBox.Show("Agregue por lo menos un artículo");
                return;
            }
            //int numRemision = 0;

            foreach (SIFModelo.RemisionDetalle det in logica.RemisionDetalles)
            {
                int existencias = 0;

                SIFModelo.Articulo articulo = new SIFModelo.Articulo();
                articulo.ARTICULO_ID = det.ArticuloID;

                SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
                if (!inventario.InventarioArticuloSinApartado(articulo, det.CantidadRemision, out existencias))
                {
                    det.CantidadRemision = existencias;
                    this.cantidadTextBoxX.Text = existencias.ToString();
                    return;
                }
            }

            //logica.remision.VendedorID = this.UsuarioSeleccionado;
            if (logica.remision.VendedorID == 0)
            {
               MessageBox.Show("Ingrese el vendedor al que se le asigna");
                this.SeleccionaUsuario();
                return;
            }

            if (logica.remision.MedicoID == 0 && conRecetaCheckBox.Checked)
            {
               MessageBox.Show("Ingrese el medico al que se le asigna");
                this.SelecionaMedico();
                return;
            }

            logica.remision.SucursalID = SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID;
            logica.remision.Activo = SIFModelo.Tipos.StatusVenta.GENERADA;
            if (logica.remision.ClienteID == 0)
            {
                logica.remision.ClienteID = 1;
            }
            logica.remision.Comentarios = "";
            logica.remision.Condiciones = "";
            logica.remision.Descuento = 0;
            logica.remision.FechaVenta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            logica.remision.ImporteLetra = this.totalLetraLabelX.Text;
            logica.remision.Impuesto = 0;
            if (logica.remision.MedicoID == 0)
            { logica.remision.MedicoID = 1; }
            logica.remision.MonedaID = 1;
            logica.remision.NumeroFactura = " ";
            logica.remision.NumeroPedido = " ";
            logica.remision.Receta = this.conRecetaCheckBox.Checked ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO;
            logica.remision.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
            logica.remision.NumeroRemision = "";
            logica.remision.TarjetaID = logica.remision.TarjetaID;
            logica.remision.ReferenciaProveedor = logica.remision.ReferenciaProveedor;

            //CONTROLADO
            SIFNegocio.Controlado controladoL = new SIFNegocio.Controlado();
            SIFModelo.Controlado controlado = new SIFModelo.Controlado();
            controlado.SucursalId = logica.remision.SucursalID;
            controlado.Folio = controladoL.FolioControlado(Helpers.Sesion.Sucursal);
            controlado.MedicoID = logica.remision.MedicoID;
            controlado.FechaEntrega = logica.remision.FechaVenta;
            controlado.Receta = this.conRecetaCheckBox.Checked ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO;
            controlado.Retiene = this.ConRetieneReceta.Checked ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO;

            controlado.UsuarioID = this.logica.remision.VendedorID;
            controlado.RemisionID = logica.remision.NumeroRemision;
            controlado.Activo = SIFModelo.Tipos.TipoActivoControlado.GENERADA;
            controlado.Receta = logica.remision.Receta;
            controlado.EntregaID = this.cajero.UsuariosID;


            //logica.remision.NumeroRemision = logica.FolioRemision(Helpers.Sesion.Sucursal.SucursalID, out numRemision);
            //logica.InsertaFolioRemision(Helpers.Sesion.Sucursal.SucursalID, numRemision);

            //if (!controladoL.InsertaControlado(controlado))
            //{
            //    return;
            //}



            //logica.remision.VendedorID = Helpers.Sesion.UsuarioSeleccionadoVenta.UsuariosID;//colocar el vendedor que realiza la venta
            this.logica.remision.Detalles = this.logica.RemisionDetalles;
            List<SIFModelo.ControladoDetalle> detalles = new List<SIFModelo.ControladoDetalle>();
            foreach (var item in logica.remision.Detalles)
            {
                SIFModelo.ControladoDetalle detalle = new SIFModelo.ControladoDetalle();
                detalle.Activo = SIFModelo.Tipos.TipoActivoControlado.GENERADA;
                detalle.ArticuloID = item.ArticuloID;
                detalle.Cantidad = item.CantidadRemision;
                detalle.DescuentoID = item.DescuentoID;
                detalle.Folio = controlado.Folio;
                detalle.ImpuestoID = item.ImpuestoID;
                detalle.IVA = item.IVA;
                detalle.Nombre1 = item.Nombre1;
                detalle.Nombre2 = item.Nombre2;
                detalle.NumeroPartida = item.NumeroPartida;
                detalle.Precio = item.Precio;
                detalle.PrecioCosto = item.PrecioCosto;
                detalle.SucursalID = controlado.SucursalId;

                //controladoL.InsertaDetalle(detalle);
            }

            //SIFNegocio.Remision.Remisiones.Add(logica.remision);



            //foreach (var detalle in logica.RemisionDetalles)
            //{
            //    detalle.NumeroRemision = logica.remision.NumeroRemision;
            //    detalle.SucursalID = logica.remision.SucursalID;
            //    if (string.IsNullOrEmpty(detalle.ReferenciaNADRO))
            //    {
            //        detalle.ReferenciaNADRO = "";
            //    }
            //    if (string.IsNullOrEmpty(detalle.FolioControlado))
            //    {
            //        detalle.FolioControlado = "";
            //    }
            //}

            if (!controladoL.InsertaControladoBulk(controlado, logica.remision.Detalles))
            {
                return;
            }

            SIFNegocio.Remision.ImprimeTicketControlado(controlado, logica.remision.Detalles, this.medicoSeleccionado, usuarioRecibe);

           MessageBox.Show("El folio " + controlado.Folio + " fue registrado correctamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Pasa = true;
            this.Back();
        }

        private void Cancelar()
        {
            if (this.dataGrid.SelectedRowCount == 0)
            {
                DialogResult res =MessageBox.Show("¿Cancelar todos los cambios realizados?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res != DialogResult.Yes)
                {
                    return;
                }
                this.LimpiaVenta();
                return;
            }

            DialogResult resp =MessageBox.Show("¿Eliminar los productos seleccinados?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != DialogResult.Yes)
            {
                return;
            }

            var seleccionadas = this.dataGrid.SelectedRows;

            foreach (GridContainer detalle in seleccionadas)
            {
                GridRow fila = detalle as GridRow;
                logica.RemisionDetalles.Remove(fila.DataItem as SIFModelo.RemisionDetalle);
            }

            dataGrid.DataSource = logica.RemisionDetalles;
        }

        internal void AgregaUsuario(SIFModelo.Cliente cliente)
        {
            this.logica.remision.ClienteID = cliente.ID;

            this.nombreClienteLabelX.Text = cliente.ID.ToString();
            this.nombreClienteLabelX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;

            SIFModelo.DireccionCliente dirCliente = new SIFNegocio.Clientes().DireccionCliente(cliente);
        }


        #endregion

        #region Navegación de Ventana

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            agregaProductoButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            seleccionaClienteButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
            guardarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            cancelarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);

        }

        /// <summary>
        /// Activa los acesos cortos mediante el teclado
        /// </summary>
        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
            agregaProductoButtonItem.Shortcuts.Clear();
            seleccionaClienteButtonItem.Shortcuts.Clear();
            guardarButtonItem.Shortcuts.Clear();
            cancelarButtonItem.Shortcuts.Clear();
        }

        private void Back()
        {
            if (this.dataGrid != null)
            {
                if (this.dataGrid.Rows.Count > 0 && !Pasa)
                {
                    DialogResult res =MessageBox.Show("El folio esta en proceso, ¿desea cancelarla?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (res == DialogResult.No)
                    {
                        return;
                    }
                }
            }


            if (this.Mostrado && Owner.Owner.Owner.IsModalPanelDisplayed)
            {
                this.DesactivaComandos();
                if (Owner.Owner.Owner.Contains(this))
                {
                    Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }
                this.Owner.ActivaComandos();
                this.Mostrado = false;
            }
        }

        private void Salir()
        {
            DialogResult res = MessageBox.Show("¿Desea Salir de la venta?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Back();
            }
        }

        public void Muestra()
        {
            Ventas.ControladoUsuarioForm frmUsuario = new ControladoUsuarioForm();
            if (frmUsuario.ShowDialog() != DialogResult.OK)
            {
                this.Back();
                return;
            }

            this.cajero = frmUsuario.Usuario;

            View.Menu.Ventas.ControladosUserControl propietario = Owner as View.Menu.Ventas.ControladosUserControl;
            propietario.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.LimpiaVenta();
            this.Mostrado = true;
            propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }

        #endregion

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void seleccionaClienteButtonItem_Click(object sender, EventArgs e)
        {
            this.SeleccionaUsuario();
        }

        private void agregaProductoButtonItem_Click(object sender, EventArgs e)
        {
            this.SeleccionaArticulo();
        }

        private void eliminaProductoButtonItem_Click(object sender, EventArgs e)
        {
            this.EliminaProducto();
        }

        private void cotizacionInstantaneaButtonItem_Click(object sender, EventArgs e)
        {
            this.CotizacionInstantanea();
        }

        private void descuentoCredencialButtonItem_Click(object sender, EventArgs e)
        {
            this.DescuentoCredencial();
        }

        private void guardarButtonItem_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }

        private void cancelarButtonItem_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }


        private void salirButtonItem_Click(object sender, EventArgs e)
        {
            this.Salir();
        }

        private void calculadoraButtonItem_Click(object sender, EventArgs e)
        {
            this.Calculadora();
        }

        GridPanel dataGrid;
        private void VentaUserControl_Load(object sender, EventArgs e)
        {
            dataGrid = this.superGridControl1.PrimaryGrid;
            dataGrid.DataSource = logica.RemisionDetalles;
            this.CodigoTextBoxX.Focus();
            this.InicializaColumnas();

        }


        private void CodigoTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.agregaProductoButtonItem_Click(null, null);
        }
        private void CodigoTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            //BUSCAR EL ARTICULO QUE PERTENECE A LA CLAVE
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaArticulo(CodigoTextBoxX.Text);
            }

            if (e.KeyCode == Keys.F3)
            {
                this.SeleccionaArticulo();
            }
        }

        private void cantidadTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ModificaCantidadArticulo();
                this.CodigoTextBoxX.Focus();
            }
        }

        private void loteCaducidadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Boolean activo = loteCaducidadCheckBox.Checked;
            //GridTextBoxXEditControl LOTEColumn = dataGrid.Columns["LOTEColumn"].EditControl as GridTextBoxXEditControl;
            //LOTEColumn.ButtonCustom.Visible = activo;

            //GridTextBoxXEditControl CADUCIDADColumn = dataGrid.Columns["CADUCIDADColumn"].EditControl as GridTextBoxXEditControl;
            //LOTEColumn.ButtonCustom.Visible = activo;

            //superGridControl1.Update();
            //superGridControl1.Refresh();
        }

        SIFModelo.Usuario usuarioRecibe = new SIFModelo.Usuario();
        internal void AsignaUsuario(SIFModelo.Usuario usuario)
        {
            this.logica.remision.VendedorID = usuario.UsuariosID;
            this.vendedorLabelX.Text = usuario.Nombre + " " + usuario.Apellidos;
            this.usuarioRecibe = usuario;
        }

        private void superGridControl1_EndEdit(object sender, GridEditEventArgs e)
        {
            if (e.GridCell.GridColumn.HeaderText == "CANTIDAD")
            {
                GridIntegerInputEditControl integerInput = e.EditControl as GridIntegerInputEditControl;

                SIFModelo.RemisionDetalle detalle = (SIFModelo.RemisionDetalle)((GridRow)e.GridPanel.ActiveRow).DataItem;
                if (detalle.CantidadRemision <= 0)
                {
                    detalle.CantidadRemision = 1;
                }
                SIFModelo.Articulo articulo = new SIFModelo.Articulo() { ARTICULO_ID = detalle.ArticuloID };

                this.ModificaCantidadArticulo(detalle);
                //logica.ModificaCantidad(articulo, detalle.CantidadRemision);
                this.CalculaTotal();
            }
        }

        private void vendedorLabelX_ButtonCustom2Click(object sender, EventArgs e)
        {
            this.SeleccionaUsuario();
        }

        SIFModelo.Medico medicoSeleccionado = new SIFModelo.Medico();
        public void AgregaMedico(SIFModelo.Medico medico)
        {
            logica.remision.MedicoID = medico.ID;
            this.logica.remision.Receta = SIFModelo.Tipos.SiNo.SI;
            nombreClienteLabelX.Text = medico.Nombre;

            medicoSeleccionado = medico;
        }
        private void conRecetaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SelecionaMedico();
        }

        private void SelecionaMedico()
        {
            if (this.conRecetaCheckBox.Checked)
            {
                Catalogos.MedicosUserControl frmMedicos = new Catalogos.MedicosUserControl();
                frmMedicos.Owner = this;
                frmMedicos.Muestra();
            }
        }
        private void btnCliente_Click(object sender, EventArgs e)
        {
            this.SeleccionaUsuario();
        }

        private void ConRetieneReceta_CheckedChanged(object sender, EventArgs e)
        {
            this.conRecetaCheckBox.Checked = true;

        }

        private void superGridControl1_RowDeleting(object sender, GridRowDeletingEventArgs e)
        {
            if (!this.EliminaProducto())
            {
                e.Cancel = true;
            }
        }

        private void cantidadTextBoxX_Enter(object sender, EventArgs e)
        {
            this.cantidadTextBoxX.SelectAll();
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
