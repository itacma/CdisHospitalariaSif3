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
    public partial class PedidoCATUserControl : Templates.ListaUserControl
    {
        public bool Mostrado = false;
        public Menu.VentasMenu Owner;
        private SIFModelo.Usuario cajero;
        private SIFModelo.WebServices.TAE tae;
        public PedidoCATUserControl()
        {
            InitializeComponent();
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
            GridIntegerInputEditControl cantidadColumn = dataGrid.Columns["CANTIDADColumn"].EditControl as GridIntegerInputEditControl;
            cantidadColumn.MinValue = 1;
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

        View.Catalogos.ClienteControl frmCliente;
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


        private void SeleccionaArticulo()
        {
            View.Articulos.ArticuloUserControl frmArticulo = new Articulos.ArticuloUserControl();

            //if (frmArticulo == null)
            //{
            // frmArticulo = new Articulos.ArticuloUserControl();
            frmArticulo.Dock = DockStyle.Fill;
            frmArticulo.Owner = this;

            //}
            this.cantidadTextBoxX.Text = "1";
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


        List<SIFModelo.Articulo> articulosFaltantes = new List<SIFModelo.Articulo>();
        internal void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            if (!articulo.LISTA_SUCURSAL_VTA.Contains(this.logica.remision.SucursalID.ToString()))
            {
               MessageBox.Show("El artículo no está permitido en esta sucursal");
                return;
            }

            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();


            if (!cantidadTextBoxX.Text.IsInteger())
            {
                cantidadTextBoxX.Text = "1";
            }


            //if (logica.RemisionDetalles.Count == 22)
            //{
                //si ya lo contiene puede seguir
                //if (!logica.ContieneDetalle(articulo))
                //{
                //    var vdetalle = from d in logica.RemisionDetalles where d.ArticuloID == articulo.ARTICULO_ID select d;


                //    SIFModelo.RemisionDetalle rdetalle = vdetalle.First();
                //    int existencias = 0;
                //    if (!inventario.InventarioArticulo(articulo, rdetalle.CantidadRemision + int.Parse(cantidadTextBoxX.Text), out existencias))
                //    {

                //        if (MessageBoxEx.Show("¿Agregar a la lista de artículos faltantes el artículo " + articulo.ARTICULO_ID + " [" + articulo.NOMBRE1 + "] ?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //        {
                //            articulo.TIPO_MONEDA = int.Parse(cantidadTextBoxX.Text);
                //            this.articulosFaltantes.Add(articulo);
                //        }

                //        return;
                //    }
                //}
                //else
                //{
                //   MessageBox.Show("Se ha alcanzado el máximo numero de lineas");
                //    return;
                //}
            //}

            int existencias1 = 0;

            if (logica.ContieneDetalle(articulo))
            {
                var vdetalle = from d in logica.RemisionDetalles where d.ArticuloID == articulo.ARTICULO_ID select d;
                SIFModelo.RemisionDetalle rdetalle = vdetalle.First();

                if (!inventario.InventarioArticulo(articulo, int.Parse(cantidadTextBoxX.Text) + rdetalle.CantidadRemision, out existencias1))
                {
                    if (MessageBoxEx.Show("¿Agregar a la lista de artículos faltantes el artículo " + articulo.ARTICULO_ID + " [" + articulo.NOMBRE1 + "] ?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        articulo.TIPO_MONEDA = int.Parse(cantidadTextBoxX.Text);
                        this.articulosFaltantes.Add(articulo);
                    }

                    rdetalle.CantidadRemision = existencias1;
                    return;
                }
            }
            else
            {

                if (!inventario.InventarioArticulo(articulo, int.Parse(cantidadTextBoxX.Text), out existencias1))
                {
                    if (MessageBoxEx.Show("¿Agregar a la lista de artículos faltantes el artículo " + articulo.ARTICULO_ID + " [" + articulo.NOMBRE1 + "] ?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        articulo.TIPO_MONEDA = int.Parse(cantidadTextBoxX.Text);
                        this.articulosFaltantes.Add(articulo);
                    }
                    return;
                }
            }

            SIFModelo.RemisionDetalle detalle = new SIFModelo.RemisionDetalle();
            //SI SOLICITA LOTE Y CADUCIDAD QUE LA INGRESE DESDE AQUI
            //if (loteCaducidadCheckBox.Checked)
            //{
            //    LoteCaducidadForm frmLoteCaducidad = new LoteCaducidadForm();
            //    if (frmLoteCaducidad.ShowDialog() != DialogResult.OK)
            //    {
            //       MessageBox.Show("El lote y la caducidad han sido solicitadas por el cliente", "Lote Caducidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    else
            //    {
            //        detalle.Lote = frmLoteCaducidad.Lote;
            //        detalle.Caducidad = frmLoteCaducidad.Caducidad;
            //    }
            //}


            detalle.ArticuloID = articulo.ARTICULO_ID;

            cantidadTextBoxX.Text = "1";
            detalle.CantidadRemision = int.Parse(this.cantidadTextBoxX.Text);
            //detalle.FechaEntrega = 
            //detalle.ImpuestoID = 
            //detalle.IVA = precio
            detalle.Nombre1 = articulo.NOMBRE1;
            detalle.Nombre2 = articulo.NOMBRE2;
            detalle.NumeroPartida = logica.RemisionDetalles.Count;

            if (articulo.TIPO_MEDICAMENTO_CVE.Contains("F1"))
            {
                detalle.FolioControlado = "SI";
            }
            //detalle.NumeroRemision = Border3DSide;
            //detalle.PaqueteID = articulo.Paquete;

            //detalle.DescuentoID = 0;
            detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;


            //detalle.PrecioControlado = 
            //detalle.PrecioCosto = 
            //detalle.ReferenciaNADRO = articulo.id;

            //PEDIR EL FOLIO DEL ARTÍCULO CONTROLADO
            if (articulo.TIPO_MEDICAMENTO_CVE.Contains("F1"))
            {
                if (detalle.OFolioControlado == null)
                {
                   MessageBox.Show("Debe agregar un folio controlado");
                    IngresaFolioControladoForm frmIngresa = new IngresaFolioControladoForm();
                    if (frmIngresa.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    detalle.OFolioControlado = frmIngresa.FolioControlado;
                    this.controladoButtonItem.Enabled = true;
                }

                //REVISAR SI EL FOLIO CONTROLADO CONTIENE EL DETALLE Y LA CANTIDAD ESPECIFICADA

                var folioControlado = from c in detalle.OFolioControlado.Detalles where c.ArticuloID == articulo.ARTICULO_ID select c;

                if (folioControlado.Count() == 0)
                {
                   MessageBox.Show("El artículo no esta dado de alta en el folio controlado");
                    return;
                }

                SIFModelo.ControladoDetalle controladoDetalle = folioControlado.First();

                detalle.CantidadRemision = controladoDetalle.Cantidad;
            }

            if (!this.PrecioArticulo(detalle))
            {
                return;
            }

            //REVISAR SI YA SE CONTIENE EL DETALLE EN LA VENTA DESDE PEDIDO
            if (this.convertidaDe != null)
            {
                if (!logica.ContieneDetalle(articulo))
                {
                   MessageBox.Show("El producto no se encuentra en el pedido");
                    return;
                }
                else
                {
                    logica.ValidaDetallePedido(articulo);
                    //cambiamos el color del gridasdf
                    this.marcaFilasValidadas();
                }
            }
            else
            {
                logica.AgregaDetalle(detalle, logica.remision);
            }

            dataGrid.DataSource = logica.RemisionDetalles;
            superGridControl1.Refresh();
            this.CodigoTextBoxX.Text = articulo.ARTICULO_ID;
            this.descripcionTextBoxX.Text = articulo.NOMBRE1;

            this.CalculaTotal();
            this.cantidadTextBoxX.Text = "1";

            this.CodigoTextBoxX.SelectAll();
            this.CodigoTextBoxX.Focus();
        }

        private bool PrecioArticulo(SIFModelo.RemisionDetalle detalle)
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
                detalle.Total = detalle.CantidadRemision * detalle.Precio;
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

        private void ModificaCantidadArtículo()
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
            int cantidad = int.Parse(cantidadTextBoxX.Text);
            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(claveArticulo);

            if (articulo == null)
            {
               MessageBox.Show("El artículo no existe en el catalogo");
                return;
            }

            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();

            if (!logica.ContieneDetalle(articulo))
            {
                int existencias = 0;
                if (!inventario.InventarioArticulo(articulo, cantidad, out existencias))
                {
                    if (MessageBoxEx.Show("¿Agregar a la lista de artículos faltantes el artículo " + articulo.ARTICULO_ID + " [" + articulo.NOMBRE1 + "] ?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        articulo.TIPO_MONEDA = int.Parse(cantidadTextBoxX.Text);
                        this.articulosFaltantes.Add(articulo);
                    }

                    return;
                }

                this.AgregaArticulo(articulo);
                //return;
            }
            else
            {
                var vdetalle = from d in logica.RemisionDetalles where d.ArticuloID == articulo.ARTICULO_ID select d;


                SIFModelo.RemisionDetalle rdetalle = vdetalle.First();
                int existencias = 0;
                if (!inventario.InventarioArticulo(articulo, cantidad, out existencias))
                {
                    cantidadTextBoxX.Text = existencias.ToString();
                    rdetalle.CantidadRemision = existencias;
                    return;
                }
            }

            logica.ModificaCantidad(articulo, cantidad);
            this.CalculaTotal();
            superGridControl1.Refresh();
        }

        private void ModificaCantidadArtículo(SIFModelo.Articulo articulo, SIFModelo.RemisionDetalle detalle)
        {
            if (articulo == null)
            {
               MessageBox.Show("El artículo no existe en el catalogo");
                return;
            }

            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();


            int existencias = 0;
            if (!inventario.InventarioArticulo(articulo, detalle.CantidadRemision, out existencias))
            {
                cantidadTextBoxX.Text = existencias.ToString();
                detalle.CantidadRemision = existencias;

            }

            this.CalculaTotal();
            superGridControl1.Refresh();
        }

        private decimal Descuento;
        private void CalculaTotal()
        {
            logica.remision.TotalArticulosRemision = logica.RemisionDetalles.Sum(r => r.CantidadRemision);
            logica.remision.SubTotal = logica.RemisionDetalles.Sum(r => r.Precio * r.CantidadRemision);
            // logica.remision.Descuento 

            logica.remision.Descuento = logica.remision.SubTotal * (Descuento / (decimal)100.0);
            decimal descuentoWS = 0;

            foreach (SIFModelo.RemisionDetalle detalle in logica.RemisionDetalles)
            {
                decimal descuentoPorcentaje = (detalle.Precio * detalle.CantidadRemision) * (detalle.PorcentajeDescuento / 100);
                // detalle.Total = (detalle.Precio * detalle.CantidadRemision) - descuentoPorcentaje;
                descuentoWS += descuentoPorcentaje;
            }

            //descuentos de la tarjeta
            var descuentoTarjeta = logica.RemisionDetalles.Sum(r => r.MontoDescuento * r.CantidadRemision);
            logica.remision.Descuento += decimal.Parse(descuentoTarjeta.ToString()) + descuentoWS;


            this.descuentoLabelX.Text = (logica.remision.Descuento).ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.subtotalLabelX.Text = logica.remision.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));


            // descuento;
            logica.remision.Total = logica.remision.SubTotal - logica.remision.Descuento;
            logica.remision.Impuesto = logica.RemisionDetalles.Sum(r => r.IVA);
            this.IVAlabelX.Text = logica.remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

            this.logica.remision.Total = logica.remision.SubTotal - logica.remision.Descuento + logica.remision.Impuesto;
            this.totalLabelX.Text = logica.remision.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.logica.remision.Impuesto = logica.RemisionDetalles.Sum(r => r.IVA);
            this.IVAlabelX.Text = logica.remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.logica.remision.ImporteLetra = sif_tools.NumberToLetters.NumToLetter((double)logica.remision.Total, logica.remision.Total.GetType().ToString());
            totalLetraLabelX.Text = this.logica.remision.ImporteLetra;
        }


        private void EliminaProducto()
        {
            MessageBox.Show("Seleccione el producto a eliminar", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CotizacionInstantanea()
        {
            //if (this.logica.RemisionDetalles.Count == 0)
            //{
            //   MessageBox.Show("Agregue elementos a la cotización");
            //    return;
            //}

            //if (this.esClienteMostrador())
            //{
            //   MessageBox.Show("Debe elegir un cliente para la cotización");
            //    return;
            //}

            SIFNegocio.Cotizacion cotizacionL = new SIFNegocio.Cotizacion();

            SIFModelo.Cotizacion cotizacion = new SIFModelo.Cotizacion();

            //cotizacion.Activo = SIFModelo.Tipos.SiNo.SI;
            //cotizacion.ClienteID = this.logica.remision.ClienteID;
            //cotizacion.Descuento = this.logica.remision.Descuento;
            //cotizacion.Factura = this.logica.remision.Factura;
            //cotizacion.FechaCotizacion = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            //cotizacion.ImporteLetra = logica.remision.ImporteLetra;
            //cotizacion.ImpuestoVenta = logica.remision.Impuesto;
            //cotizacion.MedicoID = this.logica.remision.MedicoID;
            //cotizacion.MonedaID = logica.remision.MonedaID;
            //cotizacion.NumeroCotizacion = cotizacionL.NumeroCotizacion(Helpers.Sesion.Sucursal);// logica.remision.NumeroRemision;
            //cotizacion.NumeroCredencial = logica.remision.ReferenciaProveedor;
            //cotizacion.Receta = logica.remision.Receta;
            //cotizacion.SubTotal = logica.remision.SubTotal;
            //cotizacion.SucursalID = logica.remision.SucursalID;
            //cotizacion.TipoCambioID = logica.remision.TipoCambio;
            //cotizacion.TipoClienteID = logica.remision.TipoClienteID;
            //cotizacion.Total = logica.remision.Total;
            //cotizacion.TotalArticulos = logica.remision.TotalArticulosRemision;
            //cotizacion.VendedorID = logica.remision.VendedorID;

            //if (cotizacion.ClienteID == 0)
            //{
            //    cotizacion.ClienteID = 1;
            //}

            //SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(cotizacion.ClienteID);
            //if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
            //{
            //    cotizacion.TipoCotizacion = SIFModelo.Tipos.TipoCotizacion.CONVENIO;
            //}
            //else
            //{
            //    cotizacion.TipoCotizacion = SIFModelo.Tipos.TipoCotizacion.VENTA;
            //}
            //cotizacion.Total = logica.remision.Total;

            //// cotizacionL.Inserta(cotizacion);
            //List<SIFModelo.CotizacionDetalle> detalles = new List<SIFModelo.CotizacionDetalle>();
            //foreach (SIFModelo.RemisionDetalle detalle in logica.RemisionDetalles)
            //{
            //    SIFModelo.CotizacionDetalle cotizacionDetalle = new SIFModelo.CotizacionDetalle();
            //    cotizacionDetalle.SucursalID = cotizacion.SucursalID;
            //    cotizacionDetalle.ArticuloID = detalle.ArticuloID;
            //    cotizacionDetalle.CantidadCotizacion = detalle.CantidadRemision;
            //    cotizacionDetalle.DescuentoID = detalle.DescuentoID;
            //    cotizacionDetalle.ImpuestoID = detalle.ImpuestoID;
            //    cotizacionDetalle.IVA = detalle.IVA;
            //    cotizacionDetalle.Nombre1 = detalle.Nombre1;
            //    cotizacionDetalle.Nombre2 = detalle.Nombre2;
            //    cotizacionDetalle.NumeroCotizacion = cotizacion.NumeroCotizacion;
            //    cotizacionDetalle.NumeroPartida = detalle.NumeroPartida;
            //    cotizacionDetalle.PaqueteID = detalle.PaqueteID;
            //    cotizacionDetalle.Precio = detalle.Precio;
            //    cotizacionDetalle.PrecioCosto = detalle.PrecioCosto;
            //    // cotizacionDetalle.SucursalID = detalle.SucursalID;
            //    cotizacionDetalle.Total = detalle.Total;

            //    detalles.Add(cotizacionDetalle);
            //    //cotizacionL.InsertaDetalle(cotizacionDetalle);
            //}

            Ventas.CotizacionUserControl frmCotizacion = new CotizacionUserControl(true, this.logica.remision.ClienteID);
            frmCotizacion.Owner = this;
            frmCotizacion.Muestra();

            //if (cotizacion.TipoCotizacion == SIFModelo.Tipos.TipoCotizacion.CONVENIO)
            //{
            //   MessageBox.Show("Se ha generado la cotizacion " + cotizacion.NumeroCotizacion + "  por un periodo de caducidad de 30 días", "Cotización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            //else
            //{
            //   MessageBox.Show("Se ha generado la cotizacion " + cotizacion.NumeroCotizacion + "  por un periodo de caducidad de 24 hrs", "Cotización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}



            // this.LimpiaVenta();
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
            this.Descuento = frmDescuento.DescuentoProveedor;
            logica.remision.PorcentajeDescuento = Descuento;

           MessageBox.Show("La tarjeta " + logica.remision.TarjetaID + " se utilizará  para la venta");
            this.statusLabel.Text = "DESCUENTO " + logica.remision.TarjetaID + " [" + logica.remision.ProveedorBeneficio + "]";

            foreach (SIFModelo.RemisionDetalle detalle in logica.RemisionDetalles)
            {
                logica.RecalculaDetalle(detalle, logica.remision);
            }

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

            //if (this.esClienteMostrador())
            //{
            //   MessageBox.Show("Elija un cliente válido");
            //    return;
            //}

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

                    SIFModelo.Cliente cliente = new SIFModelo.Cliente(); //new SIFNegocio.Clientes().ClientePorID(logica.remision.ClienteID);

                    //if (cliente == null)
                    //{
                    //   MessageBox.Show("Cliente no válido, por favor elija un cliente");
                    //    return;
                    //}

                    frmActiveCard frmActiva = new frmActiveCard(nadro.NumeroTarjeta, cliente, Helpers.Sesion.Usuario.Nombre);
                    if (frmActiva.ShowDialog() == DialogResult.OK)
                    {
                        this.logica.remision.TarjetaID = nadro.NumeroTarjeta;
                        this.logica.remision.ProveedorBeneficio = PROVEEDOR_NADRO;
                        // this.Descuento = frmDescuento.DescuentoProveedor;
                        logica.remision.PorcentajeDescuento = Descuento;

                       MessageBox.Show("La tarjeta " + logica.remision.TarjetaID + " se utilizará  para la venta");
                        this.statusLabel.Text = "DESCUENTO " + logica.remision.TarjetaID + " [" + logica.remision.ProveedorBeneficio + "]";
                    }
                    else
                    {
                        this.nadro = null;
                        this.statusLabel.Text = "";
                    }
                }
            }
        }

        private void LimpiaVenta()
        {
            if (this.convertidaDe == null)
            {
                this.logica.remision = new SIFModelo.Remision();
                this.logica.RemisionDetalles.Clear();
                logica.remision.Factura = SIFModelo.Tipos.SiNo.NO;
                this.conFacturaCheckBox.Checked = false;
                logica.remision.Receta = SIFModelo.Tipos.SiNo.NO;
                //this.conRecetaCheckBox.Checked = false;
                this.logica.remision.SucursalID = Helpers.Sesion.Sucursal.SucursalID;
                logica.remision.TarjetaID = "";

                this.clienteLabelX.Text = "1";
                this.nombreClienteLabelX.Text = "MOSTRADOR";
                this.RFClabelX.Text = "";
                this.direccionLabelX.Text = "";
                this.subtotalLabelX.Text = "$0.00";
                this.IVAlabelX.Text = "$0.00";
                this.totalLabelX.Text = "$0.00";
                this.totalLetraLabelX.Text = "CERO PESOS";
                this.vendedorLabelX.Text = "";
                // controlado = null;
                this.folioVentaLabelX.Text = "";
            }

            int numRemision;
            logica.remision.NumeroRemision = logica.FolioRemision(Helpers.Sesion.Sucursal.SucursalID, out numRemision);
            this.folioVentaLabelX.Text = logica.remision.NumeroRemision;

            this.Descuento = 0;
            this.descuentoLabelX.Text = "$0.00";
            this.cantidadTextBoxX.Text = "1";
            this.loteCaducidadCheckBox.Checked = false;
            this.conFacturaCheckBox.Checked = false;
            //this.conRecetaCheckBox.Checked = false;
            this.CodigoTextBoxX.Text = "";
            this.statusLabel.Text = "";
            this.pfizer = null;
            this.nadro = null;
            this.tae = null;
            this.beneficioNotifiado = false;
            this.descripcionTextBoxX.Text = "";
            this.clienteLabelX.Text = "1";
            this.nombreClienteLabelX.Text = "MOSTRADOR";
            this.vendedorLabelX.Text = "";

            this.dataGrid.DataSource = logica.RemisionDetalles;
            Ventas.VentaUsuarioForm frmUsuario = new VentaUsuarioForm();
            if (frmUsuario.ShowDialog() != DialogResult.OK)
            {
                this.Back();
                return;
            }
            controladoButtonItem.Enabled = false;
            logica.remision.VendedorID = frmUsuario.Usuario.UsuariosID;
            this.cajero = frmUsuario.Usuario;
            this.vendedorLabelX.Text = cajero.Nombre + " " + cajero.Apellidos;

        }

        private Boolean beneficioNotifiado = false;
        private void Guardar()
        {
            this.CalculaTotal();

            if (logica.RemisionDetalles.Count <= 0)
            {
               MessageBox.Show("Agregue por lo menos un artículo");
                return;
            }
            int numRemision = 0;


            Boolean conReceta = false;
            //REVISAMOS QUE EL DETALLE NO TENGA UN FOLIO CONTROLADO
            foreach (SIFModelo.RemisionDetalle detalle in this.logica.RemisionDetalles)
            {
                if (detalle.FolioControlado == "SI")
                {
                    conReceta = true;

                    //        if (detalle.TIPO_MEDICAMENTO_CVE.Contains("F1"))
                    if (detalle.OFolioControlado == null)
                    {
                       MessageBox.Show("Debe agregar un folio controlado");
                        IngresaFolioControladoForm frmIngresa = new IngresaFolioControladoForm();
                        if (frmIngresa.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }

                        detalle.OFolioControlado = frmIngresa.FolioControlado;
                        this.controladoButtonItem.Enabled = true;
                    }

                    //REVISAR SI EL FOLIO CONTROLADO CONTIENE EL DETALLE Y LA CANTIDAD ESPECIFICADA

                    var folioControlado = from c in detalle.OFolioControlado.Detalles where c.ArticuloID == detalle.ArticuloID select c;

                    if (folioControlado.Count() == 0)
                    {
                       MessageBox.Show("El artículo no esta dado de alta en el folio controlado");
                        return;
                    }

                    SIFModelo.ControladoDetalle controladoDetalle = folioControlado.First();

                    detalle.CantidadRemision = controladoDetalle.Cantidad;
                }
            }

            //COMO ES CONTROLADO 
            if (conReceta)
            {
                if (this.receta == null)
                {
                   MessageBox.Show("Debe seleccionar el Médico que expide la receta");
                    receta = new SIFModelo.Receta();
                    Catalogos.MedicosUserControl frmMedicos = new Catalogos.MedicosUserControl();
                    logica.remision.Receta = SIFModelo.Tipos.SiNo.SI;
                    frmMedicos.Owner = this;
                    frmMedicos.Muestra();
                    return;
                }
            }
            else
            {
                logica.remision.MedicoID = 0;
                this.logica.remision.Receta = SIFModelo.Tipos.SiNo.NO;
            }

            //REVISAMOS LOTE Y CADUCIDAD SI SE REQUIERE
            if (this.loteCaducidadCheckBox.Checked)
            {
                foreach (SIFModelo.RemisionDetalle detalle in this.logica.RemisionDetalles)
                {

                    if (string.IsNullOrEmpty(detalle.Lote) || string.IsNullOrWhiteSpace(detalle.Lote))
                    {
                       MessageBox.Show("El cliente ha solicitado lote y caducidad del producto " + detalle.Nombre1);
                        return;
                    }

                    if (detalle.Caducidad == null || !detalle.Caducidad.ToString().IsDatetime())
                    {
                       MessageBox.Show("Debe ingresar la fecha de caducidad del producto " + detalle.Nombre1);
                        return;
                    }
                    else if (detalle.Caducidad < DateTime.Parse(SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("dd/MM/yyyy 00:00:01")))
                    {
                       MessageBox.Show("El producto " + detalle.Nombre1 + " tiene fecha caducada");
                        return;
                    }
                }
            }

            //VALIDAR SI ALGUNO ES CONTROLADO
            var contolados = from d in logica.RemisionDetalles where d.FolioControlado == "SI" select d;
            if (contolados.Count() > 0)
            {
                foreach (SIFModelo.RemisionDetalle detalle in contolados)
                {

                    if (detalle.OFolioControlado == null)
                    {
                        View.Ventas.IngresaFolioControladoForm frmControlado = new IngresaFolioControladoForm();
                        if (frmControlado.ShowDialog() != DialogResult.OK)
                        {
                           MessageBox.Show("Debe ingresar un folio controlado para finalizar la venta");
                            return;
                        }

                        detalle.OFolioControlado = frmControlado.FolioControlado;
                        //VERIFICAMOS QUE LOS DETALLES ESTEN EN ESTE FOLIO CONTROLADO
                    }

                }

                foreach (SIFModelo.RemisionDetalle detalle in this.logica.RemisionDetalles)
                {
                    if (detalle.FolioControlado == "SI")
                    {
                        var controladoDetalleEncontrado = from d in detalle.OFolioControlado.Detalles where d.ArticuloID == detalle.ArticuloID select d;

                        if (controladoDetalleEncontrado.Count() == 0)
                        {
                           MessageBox.Show("El producto " + detalle.ArticuloID + " (" + detalle.Nombre1 + ") no esta dado de alta en el folio controlado", "Controlado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        SIFModelo.ControladoDetalle controladoDetalle = controladoDetalleEncontrado.First();

                        if (controladoDetalle.Cantidad != detalle.CantidadRemision)
                        {
                           MessageBox.Show("La cantidad a vender no corresponde a la cantidad dada de alta en el folio controlado para el artículo " + detalle.ArticuloID + " (" + detalle.Nombre1 + ")");
                            return;
                        }

                    }
                }

            }

            SIFModelo.Cliente cliente = new SIFModelo.Cliente();
            cliente.Nombre = "MOSTRADOR";
            cliente.ID = 1;
            cliente.ApellidoMaterno = "";
            cliente.ApellidoPaterno = "";

            if (!this.esClienteMostrador())
            {
                cliente.ID = this.logica.remision.ClienteID;
                cliente = new SIFNegocio.Clientes().ClientePorID(logica.remision.ClienteID);
            }
            if (this.conFacturaCheckBox.Checked)
            {
                SIFModelo.DireccionCliente dirFiscal = new SIFModelo.DireccionCliente();

                if (this.esClienteMostrador())
                {
                   MessageBox.Show("Elija un cliente válido");
                    return;
                }
                else
                {

                }

                cliente.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                dirFiscal = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);

                if (dirFiscal == null)
                {
                    Catalogos.DireccionClienteForm frmCliente = new Catalogos.DireccionClienteForm(cliente);
                    if (frmCliente.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }
            }

            //VALIDAR SI YA SE VALIDARON TODOS LOS DETALLES DEL PEDIDO O LA REMISION
            if (convertidaDe != null)
            {
                foreach (SIFModelo.RemisionDetalle detalle in logica.RemisionDetalles)
                {
                    if (!detalle.Validado)
                    {
                       MessageBox.Show("Debe registrar el artículo " + detalle.ArticuloID + " (" + detalle.Nombre1 + ")" + " ");
                        return;
                    }
                }
            }

            if (beneficioNotifiado == false)
            {
                //SIFModelo.Remision remision = new SIFModelo.Remision();
                logica.remision.SucursalID = SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID;
                logica.remision.Activo = SIFModelo.Tipos.StatusVenta.GENERADA;
                if (logica.remision.ClienteID == 0)
                {
                    logica.remision.ClienteID = 1;
                }
                logica.remision.Comentarios = "";
                logica.remision.Condiciones = "";
                //logica.remision.Descuento = 0;
                logica.remision.Factura = this.conFacturaCheckBox.Checked ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO;
                logica.remision.FechaVenta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                logica.remision.ImporteLetra = this.totalLetraLabelX.Text;
                //logica.remision.Impuesto = 0;
                //logica.remision.MedicoID = 1;
                logica.remision.MonedaID = 1;
                logica.remision.NumeroFactura = " ";
                logica.remision.NumeroPedido = " ";
                //logica.remision.Receta = this.conRecetaCheckBox.Checked ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO;
                logica.remision.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;

                logica.remision.TarjetaID = logica.remision.TarjetaID;
                logica.remision.ReferenciaProveedor = logica.remision.ReferenciaProveedor;

                //logica.remision.Total = logica.remision.Total;

                //AGREGAMOS EL FOLIO DE LA VENTA SI ES LA PRIMERA VEZ QUE CONSULTAN LOS BENEFICIOS
                if (!beneficioNotifiado)
                {
                    logica.remision.NumeroRemision = logica.FolioRemision(Helpers.Sesion.Sucursal.SucursalID, out numRemision);
                    logica.InsertaFolioRemision(Helpers.Sesion.Sucursal.SucursalID, numRemision);
                }

                logica.remision.VendedorID = Helpers.Sesion.UsuarioSeleccionadoVenta.UsuariosID;//colocar el vendedor que realiza la venta
                this.logica.remision.Detalles = this.logica.RemisionDetalles;
                SIFNegocio.Remision.Remisiones.Add(logica.remision);


                //estilos de las filas con beneficios
                DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle beneficioRowStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
                beneficioRowStyle.Background.Color1 = Color.FromArgb(175, 45, 59);
                beneficioRowStyle.Background.Color2 = Color.FromArgb(175, 45, 59);

                DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle descuentoRowStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
                descuentoRowStyle.Background.Color1 = Color.FromArgb(200, 100, 100);
                descuentoRowStyle.Background.Color2 = Color.FromArgb(200, 100, 100);

                //VALIDAR SI HAY BENEFICIOS PFIZER
                if (this.logica.remision.ProveedorBeneficio == PROVEEDOR_PFIZER)
                {
                    SIFNegocio.WebServices.PFIZER pf = new SIFNegocio.WebServices.PFIZER();
                    logica.RemisionDetalles = pf.ProcesaVenta(pfizer, logica.RemisionDetalles, logica.remision);
                    logica.remision.Condiciones = "PFIZER";
                    logica.remision.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                    if (logica.RemisionDetalles.Sum(r => r.PiezasGratis) > 0 || logica.RemisionDetalles.Sum(r => r.PiezasAcumuladas) > 0)
                    {
                       MessageBox.Show("Se encontraron beneficios para el cliente");

                        foreach (GridRow row in dataGrid.Rows)
                        {
                            SIFModelo.RemisionDetalle det = row.DataItem as SIFModelo.RemisionDetalle;

                            if (det.MontoDescuento > 0)
                            {
                                row.CellStyles.Default = descuentoRowStyle;
                                row.RowStyles.Default.ApplyStyle(descuentoRowStyle);
                            }

                            //SI SUGERIDO
                            if (det.PiezasAcumuladas > 0)
                            {

                            }
                            //SI BENEFICIO
                            if (det.PiezasGratis > 0)
                            {
                                row.CellStyles.Default = beneficioRowStyle;
                                row.RowStyles.Default.ApplyStyle(beneficioRowStyle);
                                //row.RowStyles.Empty = beneficioRowStyle;
                                //row.RowStyles.MouseOver = beneficioRowStyle;
                                //row.RowStyles.NotSelectable = beneficioRowStyle;
                                //row.RowStyles.ReadOnly = beneficioRowStyle;
                                //row.RowStyles.ReadOnlyMouseOver = beneficioRowStyle;
                                //row.RowStyles.ReadOnlySelected = beneficioRowStyle;
                                //row.RowStyles.ReadOnlySelectedMouseOver = beneficioRowStyle;
                                //row.RowStyles.Selected = beneficioRowStyle;
                                //row.RowStyles.SelectedMouseOver = beneficioRowStyle;
                            }

                        }

                        logica.remision.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                        logica.remision.ReferenciaProveedor = pfizer.SesionID;
                        this.superGridControl1.Update();

                        if (!beneficioNotifiado)
                        {
                            beneficioNotifiado = true;
                            return;
                        }

                    }



                    //SI EL BENEFICIO YA FUE NOTIFICADO, ENTONCES REGISTRAR LA VENTA
                    //genera la lista de remisiones con costo cero




                }

                #region NADRO
                if (this.logica.remision.ProveedorBeneficio == PROVEEDOR_NADRO)
                {
                    if (logica.remision.ClienteID == 0)
                    {
                        logica.remision.ClienteID = 1;
                    }
                    this.nadro.ClienteID = logica.remision.ClienteID;

                    SIFNegocio.WebServices.NADRO nadro = new SIFNegocio.WebServices.NADRO();
                    nadro.ProcesaVenta(logica.remision, logica.RemisionDetalles, SIFNegocio.Configuracion.Configuraciones.Nadro, this.nadro);

                    if (logica.RemisionDetalles.Sum(r => r.PiezasGratis) > 0 || logica.RemisionDetalles.Sum(r => r.PiezasAcumuladas) > 0 || logica.RemisionDetalles.Sum(r => r.MontoDescuento) > 0 || logica.RemisionDetalles.Sum(r => r.PorcentajeDescuento) > 0)
                    {
                       MessageBox.Show("Se encontraron beneficios para el cliente");


                        foreach (GridRow row in dataGrid.Rows)
                        {
                            SIFModelo.RemisionDetalle det = row.DataItem as SIFModelo.RemisionDetalle;

                            if (det.MontoDescuento > 0)
                            {
                                row.CellStyles.Default = descuentoRowStyle;
                                row.RowStyles.Default.ApplyStyle(descuentoRowStyle);
                            }

                            //SI SUGERIDO
                            if (det.PiezasAcumuladas > 0)
                            {

                            }
                            //SI BENEFICIO
                            if (det.PiezasGratis > 0)
                            {
                                row.CellStyles.Default = beneficioRowStyle;
                                row.RowStyles.Default.ApplyStyle(beneficioRowStyle);

                            }
                        }

                        this.CalculaTotal();

                        if (!beneficioNotifiado)
                        {
                            beneficioNotifiado = true;
                            return;
                        }
                    }

                }

                if (this.tae != null)
                {
                    logica.remision.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                    logica.remision.Condiciones = "TAE";
                    tae.Remision = logica.remision.NumeroRemision;
                    SIFNegocio.WebServices.TAE.Inserta(tae);
                }
            }

                #endregion
            int numeroPartida = 1;
            foreach (var detalle in logica.RemisionDetalles)
            {
                detalle.NumeroRemision = logica.remision.NumeroRemision;
                detalle.SucursalID = logica.remision.SucursalID;
                if (string.IsNullOrEmpty(detalle.ReferenciaNADRO))
                {
                    detalle.ReferenciaNADRO = "";
                }

                if (detalle.OFolioControlado != null)
                {
                    detalle.FolioControlado = detalle.OFolioControlado.Folio;
                }
                else
                {
                    detalle.FolioControlado = "0";
                }
                detalle.NumeroPartida = numeroPartida;
                numeroPartida++;
            }

            var detalleGratis = from d in logica.RemisionDetalles where d.PiezasGratis > 0 select d;

            foreach (var detalle in detalleGratis.ToList())
            {
                SIFModelo.RemisionDetalle detalleg = new SIFModelo.RemisionDetalle();
                detalleg.ArticuloID = detalle.ArticuloID;
                detalleg.BeneficioProveedor = detalle.BeneficioProveedor;
                detalleg.Caducidad = detalle.Caducidad;
                detalleg.CantidadRemision = detalle.PiezasGratis;
                detalleg.PiezasPagadas = 0;
                detalleg.Precio = 0;
                detalleg.PrecioCosto = detalle.PrecioCosto;
                detalleg.PrecioProveedor = detalle.PrecioProveedor;
                detalleg.ReferenciaNADRO = detalle.ReferenciaNADRO;
                detalleg.SucursalID = detalle.SucursalID;
                detalleg.TipoPrecioDescuento = detalle.TipoPrecioDescuento;
                detalleg.Validado = detalle.Validado;
                detalleg.FolioControlado = detalle.FolioControlado;
                detalleg.ImpuestoID = detalle.ImpuestoID;
                detalleg.IVA = 0;
                detalleg.Lote = detalle.Lote;
                detalleg.Mensaje = detalle.Mensaje;
                detalleg.MontoDescuento = 0;
                detalleg.Nombre1 = detalle.Nombre1;
                detalleg.Nombre2 = detalle.Nombre2;
                detalleg.NumeroRemision = detalle.NumeroRemision;
                detalleg.PaqueteID = detalle.PaqueteID;
                detalleg.PiezasAcumuladas = 0;
                detalleg.PiezasGratis = 0;
                detalleg.PorcentajeDescuento = 0;
                detalleg.Total = 0;

                detalleg.NumeroPartida = numeroPartida;
                numeroPartida++;

                logica.RemisionDetalles.Add(detalleg);
            }


            if (!logica.GuardaRemision(logica.remision, logica.RemisionDetalles))
            {
                //GUARDAMOS LOS BENEFICIOS DE LA VENTA
                if (logica.remision.Condiciones == PROVEEDOR_PFIZER)
                {
                    //GUARDAMOS EN CTL PFIZER
                }
               MessageBox.Show("Ha ocurrido un error al generar la venta");
                return;
            }

            foreach (SIFModelo.RemisionDetalle detalle in logica.remision.Detalles)
            {
                if (detalle.OFolioControlado != null)
                {
                    detalle.OFolioControlado.RemisionID = logica.remision.NumeroRemision;
                    detalle.OFolioControlado.Activo = SIFModelo.Tipos.TipoActivoControlado.ESCANEADA_EN_MOSTRADOR;
                    new SIFNegocio.Controlado().ActualizaControlado(detalle.OFolioControlado);
                }

            }

            if (convertidaDe != null)
            {
                //GUARDAR EL PEDIDO O LA VENTA DE ACUERDO AL TIPO DE NOTIFICACION

                if (convertidaDe is SIFModelo.Pedido)
                {
                    SIFModelo.Pedido pedido = convertidaDe as SIFModelo.Pedido;
                    pedido.ReferenciaRemisionVenta = logica.remision.NumeroRemision;
                    //ACTUALIZAMOS EL PEDIDO
                    SIFNegocio.Pedidos pedidoL = new SIFNegocio.Pedidos();
                    pedido.ReferenciaRemisionVenta = logica.remision.NumeroRemision;
                    pedidoL.ActualizaPedido(pedido);
                }

                if (convertidaDe is SIFModelo.Cotizacion)
                {
                    SIFModelo.Cotizacion cotizacion = convertidaDe as SIFModelo.Cotizacion;
                    //cotizacion. ReferenciaRemisionVenta = logica.remision.NumeroRemision;
                    //ACTUALIZAMOS EL PEDIDO
                    SIFNegocio.Cotizacion cotizacionL = new SIFNegocio.Cotizacion();
                    //pedido.ReferenciaRemisionVenta = logica.remision.NumeroRemision;
                    cotizacion.Activo = SIFModelo.Tipos.SiNo.NO;
                    cotizacionL.ActualizaCotizacion(cotizacion);
                }


                this.convertidaDe = null;
            }


           MessageBox.Show("La venta fue registrada correctamente con el folio " + logica.remision.NumeroRemision, "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SIFNegocio.Remision.ImprimeTicket(logica.remision, logica.RemisionDetalles, Helpers.Sesion.Sucursal, Helpers.Sesion.UsuarioSeleccionadoVenta, cliente);

            if (this.articulosFaltantes.Count > 0)
            {
                SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(this.logica.remision.VendedorID);
                View.Ventas.FaltantesForm frmFaltantes = new FaltantesForm(usuario, this.articulosFaltantes);
                frmFaltantes.ShowDialog();
            }

            this.LimpiaVenta();



        }



        private bool Cancelar()
        {
            if (this.dataGrid.SelectedRowCount == 0)
            {
                DialogResult res =MessageBox.Show("¿Cancelar todos los cambios realizados en la venta?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res != DialogResult.Yes)
                {
                    return false;
                }
                this.LimpiaVenta();
                return true;
            }

            DialogResult resp =MessageBox.Show("¿Eliminar los productos seleccinados?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != DialogResult.Yes)
            {
                return false;
            }

            var seleccionadas = this.dataGrid.SelectedRows;

            foreach (GridContainer detalle in seleccionadas)
            {
                GridRow fila = detalle as GridRow;
                logica.RemisionDetalles.Remove(fila.DataItem as SIFModelo.RemisionDetalle);
            }

            dataGrid.DataSource = logica.RemisionDetalles;
            this.CalculaTotal();

            return true;
        }

        private void TiempoAire()
        {
            if (convertidaDe != null)
            {
               MessageBox.Show("No puede generar tiempo aire desde un pedido o cotización", "Tiempo aire", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


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
            detalle.Nombre1 = frmTiempoAire.articulo.Referencia;
            detalle.Nombre2 = frmTiempoAire.articulo.Telefono;
            detalle.Precio = frmTiempoAire.articulo.Importe;
            detalle.NumeroPartida = 1;
            detalle.CantidadRemision = 1;
            //detalle

            this.PrecioArticulo(detalle);

            detalle.Precio = detalle.Precio - detalle.IVA;

            this.logica.RemisionDetalles.Add(detalle);
            this.dataGrid.DataSource = this.logica.RemisionDetalles;

            //tae
            this.tae = new SIFModelo.WebServices.TAE();
            tae.Articulo = detalle.ArticuloID;
            tae.Telefono = frmTiempoAire.articulo.Telefono;
            tae.Carrier = frmTiempoAire.articulo.Carrier;
            tae.Importe = frmTiempoAire.articulo.Importe;
            tae.Fecha = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

            //tae.Cadena = SIFNegocio.Configuracion.Configuraciones.TAE.
            this.CalculaTotal();

            this.Guardar();


        }

        internal void AgregaCliente(SIFModelo.Cliente cliente)
        {
            this.logica.remision.ClienteID = cliente.ID;

            this.clienteLabelX.Text = cliente.ID.ToString();
            this.nombreClienteLabelX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;

            SIFModelo.DireccionCliente dirCliente = new SIFNegocio.Clientes().DireccionCliente(cliente);

            if (dirCliente != null)
            {
                this.direccionLabelX.Text = dirCliente.Calle + " No. " + dirCliente.NumeroExterior;
                this.RFClabelX.Text = dirCliente.RFC;
            }
            else
            {
                this.direccionLabelX.Text = "";
                this.RFClabelX.Text = "";
            }

            if (cliente.LoteCaducidad == SIFModelo.Tipos.SiNo.SI)
            {
                this.loteCaducidadCheckBox.Checked = true;
            }
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
            if (this.Mostrado && Owner.Owner.IsModalPanelDisplayed)
            {
                if (this.dataGrid.Rows.Count > 0)
                {
                    DialogResult res =MessageBox.Show("La venta esta en proceso, ¿desea cancelarla?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (res == DialogResult.No)
                    {
                        return;
                    }
                }

                this.DesactivaComandos();
                if (Owner.Owner.Contains(this))
                {
                    Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
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
            Menu.VentasMenu propietario = Owner as Menu.VentasMenu;
            propietario.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.Mostrado = true;
            this.LimpiaVenta();

        }

        #endregion

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void seleccionaClienteButtonItem_Click(object sender, EventArgs e)
        {
            this.SeleccionaCliente();
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

        private void tiempoAireButtonItem_Click(object sender, EventArgs e)
        {
            this.TiempoAire();
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

            if (this.convertidaDe != null)
            {
                if (this.convertidaDe is SIFModelo.Pedido)
                {
                    SIFModelo.Pedido pedido = convertidaDe as SIFModelo.Pedido;
                    this.logica.remision = new SIFModelo.Remision();

                    logica.remision = new SIFModelo.Remision();
                    logica.remision.Activo = SIFModelo.Tipos.StatusVenta.GENERADA;
                    //logica.remision.BeneficioProveedor = pedido.bene
                    logica.remision.ClienteID = pedido.ClienteID;
                    //logica.remision.Comentarios = pedido.com
                    //logica.remision.Condiciones = pedido.condi;
                    logica.remision.Descuento = pedido.Descuento;
                    //logica.remision.PorcentajeDescuento = pedido.Descuento;
                    logica.remision.Factura = pedido.Factura;
                    //logica.remision.FechaPago = pedido.fecha
                    logica.remision.FechaVenta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                    logica.remision.ImporteLetra = pedido.ImporteLetra;
                    //logica.remision.Impuesto = pedido.iva;
                    logica.remision.MedicoID = pedido.MedicoID;
                    logica.remision.MonedaID = pedido.MonedaID;
                    //logica.remision.NumeroFactura = pedido.numero
                    logica.remision.NumeroPedido = pedido.NumeroPedido;
                    //logica.remision.NumeroRemision = pedido.NumeroPedido 
                    //logica.remision.ProveedorBeneficio = pedido.benefi
                    logica.remision.Receta = pedido.Receta;
                    //logica.remision.ReferenciaProveedor = pedido.ReferenciaRemisionVenta
                    logica.remision.SubTotal = pedido.SubTotal;
                    logica.remision.SucursalID = pedido.SucursalID;
                    //logica.remision.TarjetaID = pedido.tarjet 
                    logica.remision.TipoCambio = pedido.TipoCambioID;
                    logica.remision.TipoClienteID = pedido.TipoClienteID;
                    logica.remision.Total = pedido.Total;
                    logica.remision.TotalArticulosRemision = pedido.TotalArticulosPedido;
                    // logica.remision.VendedorID = Helpers.Sesion.UsuarioSeleccionadoVenta.UsuariosID;

                    foreach (SIFModelo.PedidoDetalle detalle in pedido.Detalles)
                    {

                        SIFModelo.RemisionDetalle vdetalle = new SIFModelo.RemisionDetalle();
                        vdetalle.ArticuloID = detalle.ArticuloID;
                        vdetalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
                        //vdetalle.Caducidad = 
                        vdetalle.CantidadRemision = detalle.CantidadPedido;
                        vdetalle.DescuentoID = detalle.DescuentoID;
                        //vdetalle.FechaEntrega = detalle.fe
                        //vdetalle.FolioControlado = detalle.folio
                        vdetalle.ImpuestoID = detalle.ImpuestoID;
                        vdetalle.IVA = detalle.IVA;
                        //vdetalle.Lote = detalle.lote
                        //vdetalle.Mensaje = detalle.mens
                        //vdetalle.MontoDescuento = detalle.monto
                        vdetalle.Nombre1 = detalle.Nombre1;
                        vdetalle.Nombre2 = detalle.Nombre2;
                        vdetalle.NumeroPartida = detalle.NumeroPartida;
                        //vdetalle.NumeroRemision = detalle.
                        vdetalle.PaqueteID = detalle.PaqueteID;
                        //vdetalle.PiezasAcumuladas = detalle.acu
                        //vdetalle.PiezasGratis = detalle.pie
                        //vdetalle.PiezasPagadas = detalle.pieza

                        //vdetalle.PorcentajeDescuento = detalle.porc
                        vdetalle.Precio = detalle.Precio;
                        vdetalle.PrecioCosto = detalle.PrecioCosto;
                        //vdetalle.PrecioProveedor = detalle.preciopr
                        //vdetalle.ReferenciaNADRO = detalle.refe
                        vdetalle.SucursalID = detalle.SucursalID;
                        //vdetalle.TipoPrecioDescuento = detalle.tipopre
                        vdetalle.Total = detalle.Total;

                        if (vdetalle.Total == 0)
                        {
                            vdetalle.Total = vdetalle.Precio * vdetalle.CantidadRemision;
                        }

                        logica.RemisionDetalles.Add(vdetalle);
                    }
                }

                if (this.convertidaDe is SIFModelo.Cotizacion)
                {
                    SIFModelo.Cotizacion cotizacion = convertidaDe as SIFModelo.Cotizacion;
                    this.logica.remision = new SIFModelo.Remision();

                    logica.remision = new SIFModelo.Remision();
                    logica.remision.Activo = SIFModelo.Tipos.StatusVenta.GENERADA;
                    //logica.remision.BeneficioProveedor = pedido.bene
                    logica.remision.ClienteID = cotizacion.ClienteID;
                    //logica.remision.Comentarios = pedido.com
                    //logica.remision.Condiciones = pedido.condi;
                    logica.remision.Descuento = cotizacion.Descuento;
                    logica.remision.Factura = cotizacion.Factura;
                    //logica.remision.FechaPago = pedido.fecha
                    logica.remision.FechaVenta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                    logica.remision.ImporteLetra = cotizacion.ImporteLetra;
                    //logica.remision.Impuesto = pedido.iva;
                    logica.remision.MedicoID = cotizacion.MedicoID;
                    logica.remision.MonedaID = cotizacion.MonedaID;
                    //logica.remision.NumeroFactura = pedido.numero
                    logica.remision.NumeroPedido = cotizacion.NumeroCotizacion;
                    //logica.remision.NumeroRemision = pedido.NumeroPedido 
                    //logica.remision.ProveedorBeneficio = pedido.benefi
                    logica.remision.Receta = cotizacion.Receta;
                    //logica.remision.ReferenciaProveedor = pedido.ReferenciaRemisionVenta
                    logica.remision.SubTotal = cotizacion.SubTotal;
                    logica.remision.SucursalID = cotizacion.SucursalID;
                    //logica.remision.TarjetaID = pedido.tarjet 
                    logica.remision.TipoCambio = cotizacion.TipoCambioID;
                    logica.remision.TipoClienteID = cotizacion.TipoClienteID;
                    logica.remision.Total = cotizacion.Total;
                    logica.remision.TotalArticulosRemision = cotizacion.TotalArticulos;
                    // logica.remision.VendedorID = Helpers.Sesion.UsuarioSeleccionadoVenta.UsuariosID;

                    foreach (SIFModelo.CotizacionDetalle detalle in cotizacion.Detalles)
                    {

                        SIFModelo.RemisionDetalle vdetalle = new SIFModelo.RemisionDetalle();
                        vdetalle.ArticuloID = detalle.ArticuloID;
                        //vdetalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
                        //vdetalle.Caducidad = 
                        vdetalle.CantidadRemision = detalle.CantidadCotizacion;
                        vdetalle.DescuentoID = detalle.DescuentoID;
                        //vdetalle.FechaEntrega = detalle.fe
                        //vdetalle.FolioControlado = detalle.folio
                        vdetalle.ImpuestoID = detalle.ImpuestoID;
                        vdetalle.IVA = detalle.IVA;
                        //vdetalle.Lote = detalle.lote
                        //vdetalle.Mensaje = detalle.mens
                        //vdetalle.MontoDescuento = detalle.monto
                        vdetalle.Nombre1 = detalle.Nombre1;
                        vdetalle.Nombre2 = detalle.Nombre2;
                        vdetalle.NumeroPartida = detalle.NumeroPartida;
                        //vdetalle.NumeroRemision = detalle.
                        vdetalle.PaqueteID = detalle.PaqueteID;
                        //vdetalle.PiezasAcumuladas = detalle.acu
                        //vdetalle.PiezasGratis = detalle.pie
                        //vdetalle.PiezasPagadas = detalle.pieza

                        //vdetalle.PorcentajeDescuento = detalle.porc
                        vdetalle.Precio = detalle.Precio;
                        vdetalle.PrecioCosto = detalle.PrecioCosto;
                        //vdetalle.PrecioProveedor = detalle.preciopr
                        //vdetalle.ReferenciaNADRO = detalle.refe
                        vdetalle.SucursalID = detalle.SucursalID;
                        //vdetalle.TipoPrecioDescuento = detalle.tipopre
                        vdetalle.Total = detalle.Total;

                        if (vdetalle.Total == 0)
                        {
                            vdetalle.Total = vdetalle.Precio * vdetalle.CantidadRemision;
                        }

                        logica.RemisionDetalles.Add(vdetalle);
                    }

                }
            }
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
                this.ModificaCantidadArtículo();
                this.CodigoTextBoxX.SelectAll();
                this.CodigoTextBoxX.Focus();
                cantidadTextBoxX.Text = "1";
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

        private void pfizerButtonItem_Click(object sender, EventArgs e)
        {
            this.UtilizaPfizer();
        }

        private void nadroButtonItem_Click(object sender, EventArgs e)
        {
            this.UtilizaNadro();
        }

        private void superGridControl1_EndEdit(object sender, GridEditEventArgs e)
        {
            if (e.GridCell.GridColumn.HeaderText == "LOTE")
            {
                if (this.loteCaducidadCheckBox.Checked)
                {
                    GridTextBoxXEditControl txt = e.EditControl as GridTextBoxXEditControl;
                    //VALIDAMOS QUE EL LOTE SEA CORRECTO
                    //txt.Text;
                }
            }

            if (e.GridCell.GridColumn.HeaderText == "CADUCIDAD")
            {
                if (this.loteCaducidadCheckBox.Checked)
                {
                    GridDateTimeInputEditControl selectDate = e.EditControl as GridDateTimeInputEditControl;
                    if (selectDate.Value < SIFNegocio.Configuracion.Configuraciones.fechaServidor())
                    {
                        MessageBox.Show("La fecha ingresada es caduca o inválida");
                        e.Cancel = true;
                        return;
                    }
                }
            }

            //VALIDAMOS LA CANTIAD
            if (e.GridCell.GridColumn.HeaderText == "CANTIDAD")
            {

                GridIntegerInputEditControl integerInput = e.EditControl as GridIntegerInputEditControl;

                SIFModelo.RemisionDetalle detalle = (SIFModelo.RemisionDetalle)((GridRow)e.GridPanel.ActiveRow).DataItem;
                SIFModelo.Articulo articulo = new SIFModelo.Articulo() { ARTICULO_ID = detalle.ArticuloID };


                this.ModificaCantidadArtículo(articulo, detalle);
                this.CalculaTotal();
                //VALIDAMOS QUE EL LOTE SEA CORRECTO
                //txt.Text;

            }
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


                cliente.ID = this.logica.remision.ClienteID;
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
                //}
            }
        }

        SIFModelo.Receta receta;
        //private void conRecetaCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    //if (conRecetaCheckBox.Checked)
        //    //{
        //    //    receta = new SIFModelo.Receta();
        //    //    Catalogos.MedicosUserControl frmMedicos = new Catalogos.MedicosUserControl();
        //    //    frmMedicos.Owner = this;
        //    //    frmMedicos.Muestra();
        //    //}
        //    //else
        //    //{
        //    //    logica.remision.MedicoID = 0;
        //    //    this.logica.remision.Receta = SIFModelo.Tipos.SiNo.NO;
        //    //}

        //}

        public void AgregaMedico(SIFModelo.Medico medico)
        {
            logica.remision.MedicoID = medico.ID;
            this.logica.remision.Receta = SIFModelo.Tipos.SiNo.SI;
        }

        private void controladoButtonItem_Click(object sender, EventArgs e)
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
                return;
            }

            DialogResult res =MessageBox.Show("¿Se reiniciará la cantidad del artículo agregado?", "Folio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.No)
            {
                return;
            }

            //this.logica.RemisionDetalles.Clear();
            //this.superGridControl1.PrimaryGrid.DataSource = this.logica.RemisionDetalles;

            SIFModelo.RemisionDetalle detalle = ((GridRow)this.superGridControl1.PrimaryGrid.ActiveRow).DataItem as SIFModelo.RemisionDetalle;

            IngresaFolioControladoForm frmIngresa = new IngresaFolioControladoForm();
            frmIngresa.usuarioID = logica.remision.VendedorID;
            if (frmIngresa.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (frmIngresa.FolioControlado.Activo != SIFModelo.Tipos.TipoActivoControlado.GENERADA)
            {
               MessageBox.Show("El folio no esta activo, por favor revise el número", "Controlado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            detalle.OFolioControlado = frmIngresa.FolioControlado;
        }

        private void superGridControl1_RowDeleted(object sender, GridRowDeletedEventArgs e)
        {

        }

        private void superGridControl1_RowDeleting(object sender, GridRowDeletingEventArgs e)
        {
            if (!this.Cancelar())
            {
                e.Cancel = true;
            }
            //e.SelectedRows.
        }

        private void cantidadTextBoxX_Enter(object sender, EventArgs e)
        {
            this.cantidadTextBoxX.SelectAll();
        }

        private void CodigoTextBoxX_Enter(object sender, EventArgs e)
        {
            this.CodigoTextBoxX.SelectAll();
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
