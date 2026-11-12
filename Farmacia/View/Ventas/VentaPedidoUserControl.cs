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

    public partial class VentaPedidoUserControl : Templates.ListaUserControl
    {
        private bool sal = false;
        private bool Carga = false;
        public bool Mostrado = false;
        public MainForm Owner;
        public object Owner1;
        private decimal PorScosto;
        private SIFModelo.Usuario cajero;
        private SIFModelo.WebServices.TAE tae;
        SIFModelo.ClienteConvenio ConvenioCliente;
        SIFNegocio.ClienteConvenios clienteN = new SIFNegocio.ClienteConvenios();
        public VentaPedidoUserControl()
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
            cantidadColumn.MinValue = 0;
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

        private bool VerificaArtPed(SIFModelo.Articulo articulo)
        {
            if (this.convertidaDe is SIFModelo.Pedido)
            {
                //buscamos el articulo en el detallede del pedido
                SIFModelo.Pedido pedido = convertidaDe as SIFModelo.Pedido;
                var vpedido = from r in pedido.Detalles where r.ArticuloID == articulo.ARTICULO_ID select r;
                if (vpedido.Count() > 0)
                {
                    return true;
                }
                else
                {
                   MessageBox.Show("El articulo no se encuentra en el pedido");
                    return false;
                }

            }
            return false;
        }
        private bool VerificaArtCot(SIFModelo.Articulo articulo)
        {
            if (this.convertidaDe is SIFModelo.Cotizacion)
            {
                //buscamos el articulo en el detallede del pedido

                var vpedido = from r in logica.RemisionDetalles where r.ArticuloID == articulo.ARTICULO_ID select r;
                if (vpedido.Count() > 0)
                {
                    return true;
                }
                else
                {
                   MessageBox.Show("El articulo no se encuentra en la cotización");
                    return false;
                }

            }
            return false;
        }

        private bool VerificaArtApartado(SIFModelo.Articulo articulo)
        {
            if (this.convertidaDe is SIFModelo.Apartado)
            {
                //buscamos el articulo en el detallede del pedido
                SIFModelo.Apartado pedido = convertidaDe as SIFModelo.Apartado;
                var vpedido = from r in pedido.Detalles where r.ArticuloID == articulo.ARTICULO_ID select r;
                if (vpedido.Count() > 0)
                {
                    return true;
                }
                else
                {
                   MessageBox.Show("El articulo no se encuentra en el Apartado");
                    return false;
                }

            }
            return false;
        }
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
            //    if (convertidaDe is SIFModelo.Pedido)
            //    {
            //        if (!VerificaArtPed(articulo))
            //            return;
            //    }
            //    if (convertidaDe is SIFModelo.Apartado)
            //    {
            //        if (!VerificaArtPed(articulo))
            //            return;
            //        SIFModelo.Apartado Apartado = convertidaDe as SIFModelo.Apartado;
            //        if (Apartado.Anticipo > 0)
            //            if (!inventario.InventarioArticulo(articulo, rdetalle.CantidadRemision + int.Parse(cantidadTextBoxX.Text), out existencias))
            //                return;
            //    }
            //    if (convertidaDe is SIFModelo.Cotizacion)
            //    {
            //        if (!VerificaArtCot(articulo))
            //            return;
            //        if (!inventario.InventarioArticulo(articulo, rdetalle.CantidadRemision + int.Parse(cantidadTextBoxX.Text), out existencias))
            //            return;
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
                if (convertidaDe is SIFModelo.Pedido)
                {
                    if (!VerificaArtPed(articulo))
                        return;
                    if (!VerificaCantPedart(articulo, rdetalle.CantidadRemision + 1))
                        return;
                }
                if (convertidaDe is SIFModelo.Apartado)
                {
                    if (!VerificaArtApartado(articulo))
                        return;
                    if (!VerificaCantApaart(articulo, rdetalle.CantidadRemision + 1))
                        return;

                    SIFModelo.Apartado Apartado = convertidaDe as SIFModelo.Apartado;
                    if (Apartado.Anticipo > 0)
                        if (!inventario.InventarioArticuloSinApartado(articulo, int.Parse(cantidadTextBoxX.Text) + rdetalle.CantidadRemision, out existencias1))
                        {
                            rdetalle.CantidadRemision = existencias1;
                            return;
                        }
                }
                if (convertidaDe is SIFModelo.Cotizacion)
                {
                    if (!VerificaArtCot(articulo))
                        return;
                    if (!inventario.InventarioArticuloSinApartado(articulo, int.Parse(cantidadTextBoxX.Text) + rdetalle.CantidadRemision, out existencias1))
                    {
                        rdetalle.CantidadRemision = existencias1;
                        return;
                    }
                }
            }
            else
            {
                if (convertidaDe is SIFModelo.Pedido)
                {
                    if (!VerificaArtPed(articulo))
                        return;
                    if (!VerificaCantPedart(articulo, 1))
                        return;
                }
                if (convertidaDe is SIFModelo.Apartado)
                {
                    if (!VerificaArtApartado(articulo))
                        return;
                    if (!VerificaCantApaart(articulo, 1))
                        return;
                    SIFModelo.Apartado Apartado = convertidaDe as SIFModelo.Apartado;
                    if (Apartado.Anticipo > 0)
                        if (!inventario.InventarioArticuloSinApartado(articulo, int.Parse(cantidadTextBoxX.Text), out existencias1))
                            return;

                }
                if (convertidaDe is SIFModelo.Cotizacion)
                {
                    if (!VerificaArtCot(articulo))
                        return;
                    if (!inventario.InventarioArticuloSinApartado(articulo, int.Parse(cantidadTextBoxX.Text), out existencias1))
                        return;
                }
            }

            SIFModelo.RemisionDetalle detalle = new SIFModelo.RemisionDetalle();



            detalle.ArticuloID = articulo.ARTICULO_ID;
            detalle.TIPO_MEDICAMENTO_CVE = articulo.TIPO_MEDICAMENTO_CVE;
            cantidadTextBoxX.Text = "1";
            detalle.CantidadRemision = int.Parse(this.cantidadTextBoxX.Text);
            //detalle.FechaEntrega = 
            //detalle.ImpuestoID = 
            //detalle.IVA = precio
            detalle.Nombre1 = articulo.NOMBRE1;
            detalle.Nombre2 = articulo.NOMBRE2;
            detalle.NumeroPartida = logica.RemisionDetalles.Count;
            detalle.TIPO_MEDICAMENTO_CVE = articulo.TIPO_MEDICAMENTO_CVE;
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
                    frmIngresa.usuarioID = logica.remision.VendedorID;
                    if (frmIngresa.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    detalle.OFolioControlado = frmIngresa.FolioControlado;
                    logica.remision.Receta = frmIngresa.FolioControlado.Receta;
                    logica.remision.MedicoID = frmIngresa.FolioControlado.MedicoID;
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
            //if (this.convertidaDe != null)
            //{
            //    if (!logica.ContieneDetalle(articulo))
            //    {
            //       MessageBox.Show("El producto no se encuentra en el pedido");
            //        return;
            //    }
            //    else
            //    {
            //        logica.ValidaDetallePedido(articulo);
            //        //cambiamos el color del gridasdf
            //        this.marcaFilasValidadas();
            //    }
            //}
            //else
            //{

            if (convertidaDe != null)
            {
                detalle.FolioControlado = "";
            }

            logica.AgregaDetalle(detalle, logica.remision);
            //}

            dataGrid.DataSource = logica.RemisionDetalles;
            superGridControl1.Refresh();
            this.CodigoTextBoxX.Text = articulo.ARTICULO_ID;
            this.descripcionTextBoxX.Text = articulo.NOMBRE1;

            this.CalculaTotal();
            this.cantidadTextBoxX.Text = "1";

            this.CodigoTextBoxX.SelectAll();
            this.CodigoTextBoxX.Focus();
        }


        private bool VerificaCantPedart(SIFModelo.Articulo articulo, int Cantidad)
        {
            if (convertidaDe is SIFModelo.Pedido)
            {

                SIFModelo.Pedido pedido = convertidaDe as SIFModelo.Pedido;
                var encontrado = from r in pedido.Detalles where r.ArticuloID == articulo.ARTICULO_ID select r;

                if (encontrado.Count() > 0)
                {
                    SIFModelo.PedidoDetalle contenido = encontrado.FirstOrDefault<SIFModelo.PedidoDetalle>();
                    if (contenido.CantidadPedido < Cantidad)
                    {
                        MessageBox.Show("El pedido solo contiene" + contenido.CantidadPedido);

                        return false;
                    }
                    else
                        return true;
                }

            }

            if (convertidaDe is SIFModelo.Apartado)
            {
                SIFModelo.Apartado pedido = convertidaDe as SIFModelo.Apartado;
                var encontrado = from r in pedido.Detalles where r.ArticuloID == articulo.ARTICULO_ID select r;

                if (encontrado.Count() > 0)
                {
                    SIFModelo.ApartadoDetalle contenido = encontrado.FirstOrDefault<SIFModelo.ApartadoDetalle>();
                    if (contenido.CantidadApartado < Cantidad)
                    {
                        MessageBox.Show("El apartado solo contiene" + contenido.CantidadApartado);

                        return false;
                    }
                    else
                        return true;
                }
            }

            return false;
        }

        private bool VerificaCantApaart(SIFModelo.Articulo articulo, int Cantidad)
        {
            SIFModelo.Apartado pedido = convertidaDe as SIFModelo.Apartado;
            var encontrado = from r in pedido.Detalles where r.ArticuloID == articulo.ARTICULO_ID select r;

            if (encontrado.Count() > 0)
            {
                SIFModelo.ApartadoDetalle contenido = encontrado.FirstOrDefault<SIFModelo.ApartadoDetalle>();
                if (contenido.CantidadApartado < Cantidad)
                {
                    MessageBox.Show("El Apartado solo contiene" + contenido.CantidadApartado);

                    return false;
                }
                else
                    return true;
            }

            return false;
        }

        private bool VerificaPedArt(String articuloID, int Cantidad)
        {
            SIFModelo.Pedido pedido = convertidaDe as SIFModelo.Pedido;
            var encontrado = from r in pedido.Detalles where r.ArticuloID == articuloID select r;

            if (encontrado.Count() > 0)
            {
                SIFModelo.PedidoDetalle contenido = encontrado.FirstOrDefault<SIFModelo.PedidoDetalle>();
                if (contenido.CantidadPedido != Cantidad)
                {
                   MessageBox.Show("El pedido  contiene" + contenido.CantidadPedido + " favor de corregir");

                    return false;
                }
                else
                    return true;
            }

            return false;
        }

        private bool VerificaApartArt(String articuloID, int Cantidad)
        {
            SIFModelo.Apartado pedido = convertidaDe as SIFModelo.Apartado;
            var encontrado = from r in pedido.Detalles where r.ArticuloID == articuloID select r;

            if (encontrado.Count() > 0)
            {
                SIFModelo.ApartadoDetalle contenido = encontrado.FirstOrDefault<SIFModelo.ApartadoDetalle>();
                if (contenido.CantidadApartado != Cantidad)
                {
                   MessageBox.Show("El apartado  contiene" + contenido.CantidadApartado + " favor de corregir");

                    return false;
                }
                else
                    return true;
            }

            return false;
        }

        private bool VerificaApartCotizacion(String articuloID, int Cantidad)
        {
            //SIFModelo.Cotizacion pedido = convertidaDe as SIFModelo.Cotizacion;
            //var encontrado = from r in pedido.Detalles where r.ArticuloID == articuloID select r;

            //if (encontrado.Count() > 0)
            //{
            //SIFModelo.CotizacionDetalle contenido = encontrado.FirstOrDefault<SIFModelo.CotizacionDetalle>();
            if (Cantidad <= 0)
            {
               MessageBox.Show("Debe ingresar la cantidad de artículos");
                return false;
            }
            else
                return true;
            //}

            //return false;
        }


        private bool VerificaApartCotizacion2(String articuloID, int Cantidad)
        {
            //SIFModelo.Cotizacion pedido = convertidaDe as SIFModelo.Cotizacion;
            //var encontrado = from r in pedido.Detalles where r.ArticuloID == articuloID select r;

            //if (encontrado.Count() > 0)
            //{
            //SIFModelo.CotizacionDetalle contenido = encontrado.FirstOrDefault<SIFModelo.CotizacionDetalle>();
            if (Cantidad <= 0)
            {
               //MessageBox.Show("Debe ingresar la cantidad de artículos");
                return false;
            }
            else
                return true;
            //}

            //return false;
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
                if (convertidaDe is SIFModelo.Cotizacion)
                {
                    var encontrado = from r in logica.RemisionDetalles where r.ArticuloID == detalle.ArticuloID select r;
                    if (encontrado.Count() > 0)
                        detalle.Precio = encontrado.First().Precio;
                    else
                    {
                        if (PorScosto > 0)
                            detalle.Precio = precios.PRECIO_COSTO + (precios.PRECIO_COSTO * PorScosto / 100);
                        else
                            detalle.Precio = precios.PRECIO_VENTA;
                    }

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
                //int existencias = 0;
                //if (!inventario.InventarioArticulo(articulo, cantidad, out existencias))
                //{
                //    return;
                //}


                this.AgregaArticulo(articulo);
                //return;
            }
            else
            {
                var vdetalle = from d in logica.RemisionDetalles where d.ArticuloID == articulo.ARTICULO_ID select d;


                SIFModelo.RemisionDetalle rdetalle = vdetalle.First();
                int existencias = 0;
                //if (!inventario.InventarioArticulo(articulo, cantidad, out existencias))
                //{
                //    cantidadTextBoxX.Text = existencias.ToString();
                //    rdetalle.CantidadRemision = existencias;
                //    return;

                //}
                if (VerificaCantPedart(articulo, cantidad))
                    rdetalle.CantidadRemision = cantidad;
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
            // checamos si es credito que el total mas el articulo que estamos sumando no exceda su limite de credito si no lo indicamos
            if (creditoRadioButton.Checked)
            {
                SIFModelo.Cliente clienteCredito = new SIFNegocio.Clientes().ClientePorID(this.logica.remision.ClienteID);

                if ((clienteCredito.Convenio == SIFModelo.Tipos.SiNo.NO))
                {
                   MessageBox.Show("El cliente no puede tener crédito");
                    return;
                }
                else
                {

                    if (ConvenioCliente.LimiteCredito > 0)
                    {//checamos su limite de credito
                        if (ConvenioCliente.LimiteCredito < (ConvenioCliente.Saldo + logica.remision.Total + (detalle.CantidadRemision * detalle.Precio)))
                        {
                           MessageBox.Show("Se excede su limite de credito ");
                            return;
                        }
                    }
                }
            }

            if (detalle.TIPO_MEDICAMENTO_CVE.Contains("F1"))
            {
                detalle.FolioControlado = "SI";
            }
            //detalle.NumeroRemision = Border3DSide;
            //detalle.PaqueteID = articulo.Paquete;

            //detalle.DescuentoID = 0;
            //detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;


            //detalle.PrecioControlado = 
            //detalle.PrecioCosto = 
            //detalle.ReferenciaNADRO = articulo.id;

            //PEDIR EL FOLIO DEL ARTÍCULO CONTROLADO
            if (detalle.TIPO_MEDICAMENTO_CVE.Contains("F1"))
            {
                if (detalle.OFolioControlado == null)
                {
                   MessageBox.Show("Debe agregar un folio controlado");
                    IngresaFolioControladoForm frmIngresa = new IngresaFolioControladoForm();
                    frmIngresa.usuarioID = logica.remision.VendedorID;
                    if (frmIngresa.ShowDialog() != DialogResult.OK)
                    {
                        detalle.CantidadRemision = 0;
                        return;
                    }

                    detalle.OFolioControlado = frmIngresa.FolioControlado;
                    logica.remision.Receta = frmIngresa.FolioControlado.Receta;
                    logica.remision.MedicoID = frmIngresa.FolioControlado.MedicoID;
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

            if (convertidaDe is SIFModelo.Pedido)
                if (!VerificaCantPedart(articulo, detalle.CantidadRemision - detalle.PiezasPedidas))
                    return;

            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();


            int existencias = 0;
            if (!inventario.InventarioArticuloSinApartado(articulo, detalle.CantidadRemision, out existencias))
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
            System.GC.Collect();
            logica.remision.TotalArticulosRemision = logica.RemisionDetalles.Sum(r => r.CantidadRemision);

            // logica.remision.Descuento 
            SIFModelo.Descuento descModelo = new SIFNegocio.Descuentos().DescuentoPorID(logica.remision.DescuentoID);
            logica.remision.Descuento = 0; // logica.remision.SubTotal * (Descuento / (decimal)100.0);

            if (ConvenioCliente != null)
            {
                Descuento = ConvenioCliente.PorDesc;
            }
            else if (descModelo!=null)
            {
                Descuento = descModelo.Porcentaje;
            }
            else
                Descuento = 0;

            

            decimal SUBTOTAL=0;
            foreach (SIFModelo.RemisionDetalle detalle in logica.RemisionDetalles)
            {

                //SIFNegocio.Articulo LogArt = new SIFNegocio.Articulo();
                //SIFModelo.Articulo Articulo = LogArt.BuscarPorClave(detalle.ArticuloID);

                if (!detalle.TIPO_MEDICAMENTO_CVE.Contains("SD")) //CAMBIAR POR REMISION_DETALLE
                {

                    if (detalle.BeneficioProveedor == SIFModelo.Tipos.SiNo.NO && logica.remision.BeneficioProveedor == 0)
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
                               // Descuento = detalle.PorcentajeDescuento;
                                logica.remision.Descuento += (precios.PRECIO_VENTA_MAX * ((decimal)listaOfertaVenta.DESCUENTO / 100m));
                                detalle.RefOferta = listaOfertaVenta.LISTA_OFERTAS_ID;

                                // detalle.MontoDescuento = detalle.Precio - detalle.PrecioDescontado;
                                
                                
                            }


                            if (listaOfertaVenta.APLICADO_A == "F")
                            {
                                detalle.PrecioDescontado = precios.PRECIO_VENTA - (precios.PRECIO_VENTA * ((decimal)listaOfertaVenta.DESCUENTO / 100m));
                                detalle.PorcentajeDescuento = (decimal)listaOfertaVenta.DESCUENTO;
                                detalle.MontoDescuento = ((precios.PRECIO_VENTA * detalle.CantidadRemision)*((decimal)listaOfertaVenta.DESCUENTO / 100m));
                                logica.remision.Descuento += detalle.MontoDescuento;
                                detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioDescontado);
                                detalle.Precio = precios.PRECIO_VENTA;
                                detalle.RefOferta = listaOfertaVenta.LISTA_OFERTAS_ID;
                                
                               
                            }
                        }
                    }
                        else 
                        {
                            decimal impDescuento = (detalle.Precio * detalle.CantidadRemision) * (Descuento / 100);
                            detalle.PrecioDescontado = detalle.Precio - (detalle.Precio * (Descuento / 100));
                            detalle.MontoDescuento = (detalle.Precio * detalle.CantidadRemision) * (Descuento / 100);

                            detalle.Total = (detalle.CantidadRemision * detalle.Precio) - impDescuento;
                            detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
                          
                            
                        }

                    

                
                  /*  decimal impDescuento = (detalle.Precio * detalle.CantidadRemision) * (Descuento / 100);
                    detalle.PrecioDescontado = detalle.Precio - (detalle.Precio * (Descuento / 100));

                    detalle.Total = (detalle.CantidadRemision * detalle.Precio) - impDescuento;
                    logica.remision.Descuento += impDescuento;
                    detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;*/
                }
                else
                {
                    detalle.PrecioDescontado = detalle.Precio;
                    detalle.Total = (detalle.CantidadRemision * detalle.Precio);
                }

                // detalle.Total = (detalle.Precio * detalle.CantidadRemision) - descuentoPorcentaje;

                //detalle.Total = detalle.PrecioDescontado * detalle.CantidadRemision;


            }
           //  logica.remision.Impuesto = logica.RemisionDetalles.Sum(r => r.IVA * (r.CantidadRemision));
         //   logica.remision.SubTotal = (logica.RemisionDetalles.Sum(r => r.Precio * (r.CantidadRemision)))-logica.remision.Impuesto;
         //   logica.remision.Descuento = logica.RemisionDetalles.Sum(r => r.MontoDescuento * (r.CantidadRemision));
            //descuentos de la tarjeta
            
            //var descuentoTarjeta = logica.RemisionDetalles.Sum(r => r.MontoDescuento * r.CantidadRemision);
            //logica.remision.Descuento += decimal.Parse(descuentoTarjeta.ToString());

            //logica.remision.Total = (logica.remision.SubTotal - logica.remision.Descuento);



            decimal descuentoProveedor = 0;
            if (logica.remision.ProveedorBeneficio == PROVEEDOR_NADRO)
            {
                foreach (SIFModelo.RemisionDetalle detalle in logica.RemisionDetalles)
                {
                    SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);

                    if (detalle.TipoPrecioDescuento == 1)
                    {
                        //ASIGNAR EL PRECIO Y RECALCULAR
                        detalle.Precio = precios.PRECIO_VENTA_MAX;
                        logica.remision.SubTotal = logica.RemisionDetalles.Sum(r => r.Precio * (r.CantidadRemision));
                        this.subtotalLabelX.Text = logica.remision.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

                        if (detalle.MontoDescuento > 0)
                        {
                            detalle.PrecioDescontado = precios.PRECIO_VENTA_MAX - detalle.MontoDescuento;
                            detalle.Total = detalle.PrecioDescontado * detalle.CantidadRemision;
                            descuentoProveedor += (precios.PRECIO_VENTA_MAX - detalle.PrecioDescontado) * (detalle.CantidadRemision);
                        }
                        else
                        {
                            detalle.PrecioDescontado = precios.PRECIO_VENTA_MAX - (precios.PRECIO_VENTA_MAX * (detalle.PorcentajeDescuento / 100));
                            detalle.Total = detalle.PrecioDescontado * detalle.CantidadRemision;
                            descuentoProveedor += (precios.PRECIO_VENTA_MAX - detalle.PrecioDescontado) * (detalle.CantidadRemision);
                        }

                        detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                    }
                    if (detalle.TipoPrecioDescuento == 2)
                    {
                        if (detalle.MontoDescuento > 0)
                        {
                            detalle.PrecioDescontado = precios.PRECIO_VENTA - detalle.MontoDescuento;
                            detalle.Total = detalle.PrecioDescontado * detalle.CantidadRemision;
                            descuentoProveedor += (precios.PRECIO_VENTA - detalle.PrecioDescontado) * (detalle.CantidadRemision);
                        }
                        else
                        {

                            detalle.PrecioDescontado = precios.PRECIO_VENTA - (precios.PRECIO_VENTA * (detalle.PorcentajeDescuento / 100));
                            detalle.Total = detalle.PrecioDescontado * detalle.CantidadRemision;
                            descuentoProveedor += (precios.PRECIO_VENTA - detalle.PrecioDescontado) * (detalle.CantidadRemision);
                        }

                        detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                    }

                    if (detalle.PrecioProveedor > 0)
                    {
                        //detalle.Precio = detalle.PrecioProveedor;
                        detalle.PrecioDescontado = detalle.PrecioProveedor;
                        detalle.Total = detalle.PrecioDescontado * detalle.CantidadRemision;
                        descuentoProveedor += (precios.PRECIO_VENTA - detalle.PrecioDescontado) * detalle.CantidadRemision;

                        //logica.remision.SubTotal = logica.RemisionDetalles.Sum(r => r.Precio * (r.CantidadRemision));
                        //this.subtotalLabelX.Text = logica.remision.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

                        detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                    }

                    //descuentoProveedorLabelX.Text = descuentoProveedor.ToString("C2");
                }
            }

            // descuento;
            // logica.remision.Total = logica.remision.SubTotal - logica.remision.Descuento - descuentoProveedor;

            foreach (SIFModelo.RemisionDetalle detalle in logica.RemisionDetalles)
            {
                //decimal descuentoPorcentaje = (detalle.Precio * detalle.CantidadRemision) * (detalle.PorcentajeDescuento / 100);
                //detalle.PrecioDescontado = detalle.Precio;

                //detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
                // detalle.Total = (detalle.Precio * detalle.CantidadRemision) - descuentoPorcentaje;


                //CALCULAR IVA
                SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
                if (precios != null)
                {
                    SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);
                    if (impuesto != null)
                    {
                        decimal porcentaje = impuesto.Porcentaje / 100;
                        
                        if (detalle.TIPO_MEDICAMENTO_CVE.Contains("SD"))
                            detalle.MontoDescuento = 0 ; 
                        else if (detalle.RefOferta == 0)
                            detalle.MontoDescuento = ((detalle.Precio * detalle.CantidadRemision) * (Descuento / 100)); 

                        detalle.IVA = (((detalle.Total - detalle.MontoDescuento) / ((impuesto.Porcentaje / 100) + 1)) * impuesto.Porcentaje / 100);
                        
                        detalle.PorcentajeIVA = porcentaje;
                        detalle.ImpuestoID = impuesto.ID;
                        
                    }
                }

                detalle.Total = (detalle.Precio * detalle.CantidadRemision) - detalle.MontoDescuento;
               // detalle.MontoDescuento = (detalle.Precio * detalle.CantidadRemision) * (Descuento / 100);
                //SUBTOTAL += detalle.Total;
            }
        /*    logica.remision.Descuento = DESCUENTO;
            logica.remision.Impuesto = IVA;
            logica.remision.SubTotal = SUBTOTAL;*/
            
            logica.remision.SubTotal = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(logica.RemisionDetalles.Sum(r => r.Total + r.MontoDescuento));
            logica.remision.Descuento = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(logica.RemisionDetalles.Sum(r => r.MontoDescuento));
            logica.remision.Impuesto = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(logica.RemisionDetalles.Sum(r => r.IVA));
            this.descuentoLabelX.Text = (logica.remision.Descuento + descuentoProveedor).ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            //logica.remision.SubTotal = logica.remision.SubTotal - logica.remision.Descuento + logica.remision.Impuesto;
            logica.remision.Impuesto = logica.RemisionDetalles.Sum(r => r.IVA);
            this.IVAlabelX.Text = logica.remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.logica.remision.SubTotal = logica.remision.SubTotal - logica.remision.Impuesto;
            this.subtotalLabelX.Text = logica.remision.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

            this.logica.remision.Total = ((logica.remision.SubTotal + logica.remision.Impuesto) - logica.remision.Descuento) - descuentoProveedor;
            this.totalLabelX.Text = logica.remision.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.logica.remision.Impuesto = logica.RemisionDetalles.Sum(r => r.IVA);
            this.IVAlabelX.Text = logica.remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.logica.remision.ImporteLetra = sif_tools.NumberToLetters.NumToLetter((double)logica.remision.Total, logica.remision.Total.GetType().ToString());
            totalLetraLabelX.Text = this.logica.remision.ImporteLetra;
            logica.remision.Descuento = logica.remision.Descuento + descuentoProveedor;
            System.GC.Collect();
        }


        private void EliminaProducto()
        {
            MessageBox.Show("Seleccione el producto a eliminar", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CotizacionInstantanea()
        {


            SIFNegocio.Cotizacion cotizacionL = new SIFNegocio.Cotizacion();

            SIFModelo.Cotizacion cotizacion = new SIFModelo.Cotizacion();


            Ventas.CotizacionUserControl frmCotizacion = new CotizacionUserControl(true, this.logica.remision.ClienteID);
            frmCotizacion.Owner = this;
            frmCotizacion.Muestra();


        }

        private void DescuentoCredencial()
        {

            if (this.logica.remision.TarjetaID != null)
            {
               MessageBox.Show("Ya se ha asignado un beneficio ");
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
                    frmActiva.ShowDialog();
                    this.nadro = null;
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

                dataGrid.Rows.Clear();
            }

            creditoRadioButton.Checked = false;
            creditoRadioButton.Enabled = true;
            descuentoCredencialButtonItem.Visible = true;
            tiempoAireButtonItem.Visible = true;
            pfizerButtonItem.Visible = true;
            nadroButtonItem.Visible = true;
            int numRemision;
            logica.remision.NumeroRemision = logica.FolioRemision(Helpers.Sesion.Sucursal.SucursalID, out numRemision);
            this.folioVentaLabelX.Text = "Nuevo";

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
            this.nombreClienteLabelX.Text = "PUBLICO EN GENERAL";
            this.vendedorLabelX.Text = "";

            this.dataGrid.DataSource = logica.RemisionDetalles;

            controladoButtonItem.Enabled = false;

            Ventas.VentaUsuarioForm frmUsuario = new VentaUsuarioForm();
            if (frmUsuario.ShowDialog() != DialogResult.OK)
            {
                this.Back();
                return;
            }
            logica.remision.VendedorID = frmUsuario.Usuario.UsuariosID;
            this.cajero = frmUsuario.Usuario;
            this.vendedorLabelX.Text = cajero.Nombre + " " + cajero.Apellidos;
            this.contadoRadioButton.Checked = true;
            //this.dataGrid.Columns["CODIGO_CLIColumn"].Visible = false;

            this.dataGrid.DataSource = logica.RemisionDetalles;
            this.Descuento = 0;
            //logica.remision.NumeroRemision = logica.FolioRemision(Helpers.Sesion.Sucursal.SucursalID, out numRemision);
            //this.folioVentaLabelX.Text = logica.remision.NumeroRemision;
            controladoButtonItem.Enabled = false;

        }

        private Boolean beneficioNotifiado = false;
        private void Guardar()
        {
            

            if (ConvenioCliente != null)
            {
                if (ConvenioCliente.LimiteCredito > 0)
                {//checamos su limite de credito
                    if (ConvenioCliente.LimiteCredito < (ConvenioCliente.Saldo + logica.remision.Total))
                    {
                       MessageBox.Show("Se excede su limite de credito ");
                        return;
                    }
                }
            }

            if (!this.VerificaInventario())
            {
                return;
            }

            if (logica.RemisionDetalles.Count <= 0)
            {

               MessageBox.Show("Agregue por lo menos un artículo");
                return;
            }
            //VERIFICAMOS CANTIDAD


            int numRemision = 0;

            if (creditoRadioButton.Checked)
            {
                SIFModelo.Cliente clienteCredito = new SIFNegocio.Clientes().ClientePorID(this.logica.remision.ClienteID);

                if ((clienteCredito.Convenio == SIFModelo.Tipos.SiNo.NO) & (clienteCredito.SUBROGACION == SIFModelo.Tipos.SiNo.NO))
                {
                   MessageBox.Show("El cliente no puede tener crédito");
                    return;
                }
            }


            Boolean conReceta = false;
            //REVISAMOS QUE EL DETALLE NO TENGA UN FOLIO CONTROLADO
            if (convertidaDe is SIFModelo.Pedido)
            {
                SIFModelo.Pedido pedido = convertidaDe as SIFModelo.Pedido;
                if (pedido.Detalles.Count() > this.logica.RemisionDetalles.Count())
                {
                   MessageBox.Show("Faltan agregar articulos.");
                    return;
                }
                //OBTENEMOS NUEVAMENTE EL PEDIDO PARA VERIFICAR QUE NO SE HAYA REMISIONADO
                SIFNegocio.Pedidos LogPedido = new SIFNegocio.Pedidos();
                DataSet DsPedidoes = LogPedido.BuscaPedidosNoGenerados(Helpers.Sesion.Sucursal, pedido, true);
                DataTable PedidoTable;
                PedidoTable = DsPedidoes.Tables["pedidos"];
                DataRow[] PedidoRow = PedidoTable.Select("num_pedido='" + pedido.NumeroPedido + "'");
                if (PedidoRow.Count() > 0)
                    if (PedidoRow[0]["ref_remision_vta"].ToString() != "")
                    {
                       MessageBox.Show("EL PEDIDO YA FUE REMISIONADO.");
                        return;
                    }
            }

            int indx = 0;
            foreach (SIFModelo.RemisionDetalle detalle in this.logica.RemisionDetalles)
            {
                
                //revisamos que se tenga  las mismas cantidades del pedido
                if (convertidaDe is SIFModelo.Pedido)
                    if (!VerificaPedArt(detalle.ArticuloID, detalle.CantidadRemision))
                        return;

                if (convertidaDe is SIFModelo.Apartado)
                    if (!VerificaApartArt(detalle.ArticuloID, detalle.CantidadRemision))
                        return;
                if (convertidaDe is SIFModelo.Cotizacion)
                {
                    if (!VerificaApartCotizacion2(detalle.ArticuloID, detalle.CantidadRemision))
                    {
                        //logica.RemisionDetalles[indx].
                        //remision.RemisionDetalles.RemoveAt[indx];
                        this.logica.RemisionDetalles.RemoveAt(indx);
                        this.Guardar();
                    }  

 
                }
                indx++;

                if (detalle.FolioControlado == "SI")
                {
                    conReceta = true;

                    //        if (detalle.TIPO_MEDICAMENTO_CVE.Contains("F1"))
                    if (detalle.OFolioControlado == null)
                    {
                       MessageBox.Show("Debe agregar un folio controlado");
                        IngresaFolioControladoForm frmIngresa = new IngresaFolioControladoForm();
                        frmIngresa.usuarioID = logica.remision.VendedorID;
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
            this.CalculaTotal();
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
                        frmControlado.usuarioID = logica.remision.VendedorID;
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
            //if (convertidaDe != null)
            //{
            //    foreach (SIFModelo.RemisionDetalle detalle in logica.RemisionDetalles)
            //    {
            //        if (!detalle.Validado)
            //        {
            //           MessageBox.Show("Debe registrar el artículo " + detalle.ArticuloID + " (" + detalle.Nombre1 + ")" + " ");
            //            return;
            //        }
            //    }
            //}

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
                if (descuentoLabelX.Text.IsFloat())
                    logica.remision.Descuento = decimal.Parse(descuentoLabelX.Text);
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

                    if (logica.RemisionDetalles.Sum(r => r.PiezasGratis) > 0 || logica.RemisionDetalles.Sum(r => r.PiezasAcumuladas) > 0 || logica.RemisionDetalles.Sum(r => r.MontoDescuento) > 0)
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
            if (convertidaDe is SIFModelo.Pedido)
                logica.remision.TipoClienteID = 4;
            else
            {
                if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
                    logica.remision.TipoClienteID = 2;
                else
                    logica.remision.TipoClienteID = 3;
            }
            if (creditoRadioButton.Checked)
                logica.remision.TipoCambio = 1;
            else
                logica.remision.TipoCambio = 0;

            if (!logica.GuardaRemision(logica.remision, logica.RemisionDetalles, convertidaDe))
            {
                //GUARDAMOS LOS BENEFICIOS DE LA VENTA
                if (logica.remision.Condiciones == PROVEEDOR_PFIZER)
                {
                    //GUARDAMOS EN CTL PFIZER
                }
               MessageBox.Show("Ha ocurrido un error al generar la venta");
                return;
            }

            foreach (SIFModelo.RemisionDetalle detalle in logica.RemisionDetalles)
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
                    pedido.FechaRemisionVenta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                    pedidoL.ActualizaPedido(pedido);
                }

                if (convertidaDe is SIFModelo.Cotizacion)
                {
                    SIFModelo.Cotizacion cotizacion = convertidaDe as SIFModelo.Cotizacion;
                    // actualizamos la cantidad de piezas que se han vendido en la cotizacion por cada articulo.
                    foreach (SIFModelo.RemisionDetalle dt in logica.RemisionDetalles)
                    {
                        var encontrado = from r in cotizacion.Detalles where r.ArticuloID == dt.ArticuloID select r;
                        if (encontrado.Count() > 0)
                        {
                            encontrado.First().CantRem = encontrado.First().CantRem + dt.CantidadRemision;
                            if (dt.CantidadRemision > 0)
                                encontrado.First().NumRemision = dt.NumeroRemision;
                        }

                    }
                    var faltan = from r in cotizacion.Detalles where r.CantRem < r.CantidadCotizacion select r;
                    if (faltan.Count() == 0)
                    {// cerramos la cotizacion
                        cotizacion.Activo = SIFModelo.Tipos.SiNo.NO;
                    }
                    SIFNegocio.Cotizacion cotizacionL = new SIFNegocio.Cotizacion();

                    cotizacionL.Elimina(cotizacion);

                    //
                    cotizacionL.CotizacionM = cotizacion;
                    cotizacionL.CotizacionDetalles = cotizacion.Detalles;
                    cotizacionL.GuardaDatos(cotizacionL);

                    cotizacionL.CotizacionVentaInserta(cotizacion, logica.remision);

                }

                if (convertidaDe is SIFModelo.Apartado)
                {
                    SIFModelo.Apartado pedido = convertidaDe as SIFModelo.Apartado;
                    pedido.ReferenciaRemisionVenta = logica.remision.NumeroRemision;
                    //ACTUALIZAMOS EL PEDIDO
                    SIFNegocio.Apartado pedidoL = new SIFNegocio.Apartado();
                    pedido.ReferenciaRemisionVenta = logica.remision.NumeroRemision;
                    pedido.FechaRemisionVenta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                    pedido.FechaConfirmaApartado = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                    pedido.Activo = SIFModelo.Tipos.SiNo.NO;
                    pedidoL.ActualizaApartado(pedido);

                    //List<SIFModelo.Articulo> articulosApartado = new List<SIFModelo.Articulo>();
                    //foreach (var apartado in pedido.Detalles)
                    //{
                    //    SIFModelo.Articulo artAp = new SIFModelo.Articulo();
                    //    artAp.ARTICULO_ID = apartado.ArticuloID;
                    //    artAp.TIPO_MONEDA = apartado.CantidadApartado;

                    //    articulosApartado.Add(artAp);
                    //}
                    //foreach (var art in articulosApartado)
                    //{
                    //    new SIFNegocio.Inventario.Inventario().InventarioArticuloApartaCancela(art, art.TIPO_MONEDA);
                    //}
                }

            }


           MessageBox.Show("La venta fue registrada correctamente con el folio " + logica.remision.NumeroRemision, "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (convertidaDe is SIFModelo.Pedido)
            {
                SIFModelo.Pedido pedido = convertidaDe as SIFModelo.Pedido;
                SIFNegocio.Remision.ImprimeTicketPedido(logica.remision, logica.RemisionDetalles, Helpers.Sesion.Sucursal, Helpers.Sesion.UsuarioSeleccionadoVenta, cliente, pedido);
            }
            else if (convertidaDe is SIFModelo.Apartado)
            {
                SIFModelo.Apartado apartado = convertidaDe as SIFModelo.Apartado;
                SIFNegocio.Remision.ImprimeTicketApartadoEPedido(apartado, logica.RemisionDetalles, Helpers.Sesion.Sucursal, Helpers.Sesion.UsuarioSeleccionadoVenta, cliente);
            }
            else
                if (convertidaDe is SIFModelo.Cotizacion)
                {
                    String Parm1 = "{REMISION_DET.NUM_REMISION}='" + logica.remision.NumeroRemision.ToString() + "'";
                    SIFNegocio.Usuarios Logusu = new SIFNegocio.Usuarios();
                    SIFModelo.Usuario Vend = Logusu.UsuarioPorId(logica.remision.VendedorID);
                    SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Remision.rpt", Parm1, Vend.Nombre + ' ' + Vend.Apellidos);
                    Impresion.ShowDialog();
                }

                else
                    SIFNegocio.Remision.ImprimeTicket(logica.remision, logica.RemisionDetalles, Helpers.Sesion.Sucursal, Helpers.Sesion.UsuarioSeleccionadoVenta, cliente);
            this.convertidaDe = null;
            this.LimpiaVenta();

            sal = true;
            this.Back();

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
            if (this.convertidaDe is SIFModelo.Pedido)
            {
               MessageBox.Show("No se pueden eliminar filas de un pedido", "Folio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGrid.DataSource = logica.RemisionDetalles;
            }
            else
            {
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
               // this.CalculaTotal();
            }
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

            SIFModelo.DireccionCliente dirCliente = new SIFNegocio.Clientes().DireccionCliente(cliente, SIFModelo.Tipos.TipoDireccion.fiscal);

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


            if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
            {
                this.ConvenioCliente = new SIFNegocio.ClienteConvenios().ClientePorID(cliente.ID);
                if (ConvenioCliente != null)
                {
                    if (ConvenioCliente.CondicionVenta == SIFModelo.Tipos.CondicionVenta.CREDITO)
                    {
                        this.creditoRadioButton.Checked = true;
                    }
                }
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
            try
            {
                if (this.Mostrado && Owner.IsModalPanelDisplayed)
                {
                    if (this.dataGrid.Rows.Count > 0 && !sal)
                    {
                        DialogResult res =MessageBox.Show("La venta esta en proceso, ¿desea cancelarla?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (res == DialogResult.No)
                        {
                            return;
                        }
                    }

                    if (this.Owner1 is Ventas.PedidosUserControl)
                    {
                        Ventas.PedidosUserControl propietario = (Ventas.PedidosUserControl)this.Owner1;
                        propietario.Buscar();
                    }

                    if (this.Owner1 is Ventas.ApartadosUserControl)
                    {
                        Ventas.ApartadosUserControl propietario = (Ventas.ApartadosUserControl)this.Owner1;
                        propietario.Buscar();
                    }

                    if (this.Owner1 is Ventas.CotizacionesUserControl)
                    {
                        Ventas.CotizacionesUserControl propietario = (Ventas.CotizacionesUserControl)this.Owner1;
                        propietario.Buscar();
                    }
                    this.DesactivaComandos();
                    Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Owner.ActivaComandos();
                    this.Mostrado = false;
                }
            }
            catch { }
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
            MainForm propietario = Owner as MainForm;
            propietario.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            propietario.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.Mostrado = true;
            if (convertidaDe == null)
                this.LimpiaVenta();
            Ventas.VentaUsuarioForm frmUsuario = new VentaUsuarioForm();
            if (frmUsuario.ShowDialog() != DialogResult.OK)
            {
                this.Back();
                return;
            }
            logica.remision.VendedorID = frmUsuario.Usuario.UsuariosID;
            this.cajero = frmUsuario.Usuario;
            this.vendedorLabelX.Text = cajero.Nombre + " " + cajero.Apellidos;
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


                if (this.convertidaDe is SIFModelo.Apartado)
                {
                    SIFModelo.Apartado Apartado = convertidaDe as SIFModelo.Apartado;
                    this.logica.remision = new SIFModelo.Remision();
                    titleLabel.Text = "SIF\\Venta\\Nota Apartado";
                    logica.remision = new SIFModelo.Remision();
                    logica.remision.Activo = SIFModelo.Tipos.StatusVenta.GENERADA;
                    //logica.remision.BeneficioProveedor = pedido.bene
                    logica.remision.ClienteID = Apartado.ClienteID;
                    SIFNegocio.Clientes cli = new SIFNegocio.Clientes();
                    SIFModelo.Cliente cliente = cli.ClientePorID(Apartado.ClienteID);

                    if (cliente != null)
                    {
                        this.AgregaCliente(cliente);
                    }

                    nombreClienteLabelX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
                    labelX1.Text = Apartado.NumeroApartado;
                    textBoxX1.Text = Apartado.Comentario;
                    cliente.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                    SIFModelo.DireccionCliente dirFiscal = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);
                    if (dirFiscal != null)
                        RFClabelX.Text = dirFiscal.RFC;
                    clienteLabelX.Text = Apartado.ClienteID.ToString();
                    if (Apartado.Factura == SIFModelo.Tipos.SiNo.SI)
                        conFacturaCheckBox.Checked = true;
                    //logica.remision.Comentarios = pedido.com
                    //logica.remision.Condiciones = pedido.condi;
                    logica.remision.Descuento = Apartado.Descuento;
                    //logica.remision.PorcentajeDescuento = pedido.Descuento;
                    logica.remision.Factura = Apartado.Factura;
                    //logica.remision.FechaPago = pedido.fecha
                    logica.remision.FechaVenta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                    logica.remision.ImporteLetra = Apartado.ImporteLetra;
                    //logica.remision.Impuesto = pedido.iva;
                    logica.remision.MedicoID = Apartado.MedicoID;
                    logica.remision.MonedaID = Apartado.MonedaID;
                    //logica.remision.NumeroFactura = pedido.numero
                    logica.remision.NumeroPedido = Apartado.NumeroApartado;
                    //logica.remision.NumeroRemision = pedido.NumeroPedido 
                    //logica.remision.ProveedorBeneficio = pedido.benefi
                    logica.remision.Receta = Apartado.Receta;
                    //logica.remision.ReferenciaProveedor = pedido.ReferenciaRemisionVenta
                    logica.remision.SubTotal = Apartado.SubTotal;
                    logica.remision.SucursalID = Apartado.SucursalID;
                    //logica.remision.TarjetaID = pedido.tarjet 
                    logica.remision.TipoCambio = Apartado.TipoCambioID;
                    logica.remision.TipoClienteID = Apartado.TipoClienteID;
                    logica.remision.Total = Apartado.Total;
                    logica.remision.TotalArticulosRemision = Apartado.TotalArticulos;
                    // logica.remision.VendedorID = Helpers.Sesion.UsuarioSeleccionadoVenta.UsuariosID;

                    logica.remision.TarjetaID = Apartado.NumeroCredencial;
                    logica.remision.DescuentoID = Apartado.TipoCambioID;
                    // logica.remision.VendedorID = Helpers.Sesion.UsuarioSeleccionadoVenta.UsuariosID;
                    if (!string.IsNullOrEmpty(logica.remision.TarjetaID) && logica.remision.TarjetaID != "0")
                    {

                        SIFModelo.Descuento desc = new SIFNegocio.Descuentos().DescuentoPorID(logica.remision.DescuentoID);
                        logica.remision.ProveedorBeneficio = desc.Nombre;
                        this.Descuento = desc.Porcentaje;
                        logica.remision.PorcentajeDescuento = Descuento;

                       MessageBox.Show("La tarjeta " + logica.remision.TarjetaID + " se utilizará  para la venta");
                        this.statusLabel.Text = "DESCUENTO " + logica.remision.TarjetaID + " [" + logica.remision.ProveedorBeneficio + "]";
                    }

                    foreach (SIFModelo.ApartadoDetalle detalle in Apartado.Detalles)
                    {

                        SIFModelo.RemisionDetalle vdetalle = new SIFModelo.RemisionDetalle();
                        vdetalle.ArticuloID = detalle.ArticuloID;
                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
                        vdetalle.TIPO_MEDICAMENTO_CVE = articulo.TIPO_MEDICAMENTO_CVE;
                        vdetalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
                        vdetalle.PiezasPedidas = detalle.CantidadApartado;
                        vdetalle.DescuentoID = detalle.DescuentoID;
                        vdetalle.ImpuestoID = detalle.ImpuestoID;
                        vdetalle.IVA = detalle.IVA;
                        vdetalle.Nombre1 = detalle.Nombre1;
                        vdetalle.Nombre2 = detalle.Nombre2;
                        vdetalle.NumeroPartida = detalle.NumeroPartida;
                        vdetalle.PaqueteID = detalle.PaqueteID;

                        vdetalle.Precio = detalle.Precio;
                        vdetalle.PrecioCosto = detalle.PrecioCosto;
                        vdetalle.SucursalID = detalle.SucursalID;
                        vdetalle.Total = detalle.Total;

                        if (vdetalle.Total == 0)
                        {
                            vdetalle.Total = vdetalle.Precio * vdetalle.CantidadRemision;
                        }

                        logica.RemisionDetalles.Add(vdetalle);
                    }

                    if (Apartado.Factura == SIFModelo.Tipos.SiNo.SI)
                    {
                        conFacturaCheckBox.Checked = true;
                    }
                }





                if (this.convertidaDe is SIFModelo.Pedido)
                {
                    SIFModelo.Pedido pedido = convertidaDe as SIFModelo.Pedido;
                    this.logica.remision = new SIFModelo.Remision();

                    logica.remision = new SIFModelo.Remision();
                    logica.remision.Activo = SIFModelo.Tipos.StatusVenta.GENERADA;


                    //logica.remision.BeneficioProveedor = pedido.bene
                    logica.remision.ClienteID = pedido.ClienteID;




                    SIFNegocio.Clientes cli = new SIFNegocio.Clientes();
                    SIFModelo.Cliente cliente = cli.ClientePorID(pedido.ClienteID);
                    if (cliente != null)
                    {
                        if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
                        {
                            ConvenioCliente = clienteN.ClientePorID(cliente.ID);
                            if (ConvenioCliente != null)
                            {
                                logica.remision.PorcentajeDescuento = ConvenioCliente.PorDesc;
                                PorScosto = ConvenioCliente.PorScosto;
                                Descuento = ConvenioCliente.PorDesc;
                                //verificamos si tiene venta con credito o no
                                if (ConvenioCliente.CondicionVenta == SIFModelo.Tipos.CondicionVenta.EFECTIVO)
                                    creditoRadioButton.Enabled = false;
                                else
                                    if (ConvenioCliente.CondicionVenta == SIFModelo.Tipos.CondicionVenta.CREDITO)
                                    {
                                        creditoRadioButton.Enabled = false;
                                        creditoRadioButton.Checked = true;
                                        contadoRadioButton.Enabled = false;
                                    }
                            }
                        }
                        this.AgregaCliente(cliente);
                    }
                    else
                    {
                        MessageBox.Show("Cliente " + pedido.ClienteID + "  no encontrado");
                        cliente = new SIFModelo.Cliente();
                    }
                    cliente.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                    SIFModelo.DireccionCliente dirFiscal = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);
                    if (dirFiscal != null)
                        RFClabelX.Text = dirFiscal.RFC;

                    nombreClienteLabelX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
                    labelX1.Text = pedido.NumeroPedido;
                    textBoxX1.Text = pedido.Comentario;
                    clienteLabelX.Text = pedido.ClienteID.ToString();

                    descuentoCredencialButtonItem.Enabled = false;
                    descuentoCredencialButtonItem.Visible = false;
                    if (pedido.Factura == SIFModelo.Tipos.SiNo.SI)
                        conFacturaCheckBox.Checked = true;
                    if (pedido.TipoPagoID == 6)
                    {
                        creditoRadioButton.Enabled = false;
                        creditoRadioButton.Checked = true;
                        contadoRadioButton.Enabled = false;
                    }
                    //logica.remision.Comentarios = pedido.com
                    //logica.remision.Condiciones = pedido.condi;
                    logica.remision.TarjetaID = pedido.NumeroCredencial;

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

                    logica.remision.TarjetaID = pedido.NumeroCredencial;
                    logica.remision.DescuentoID = pedido.TipoCambioID;
                    // logica.remision.VendedorID = Helpers.Sesion.UsuarioSeleccionadoVenta.UsuariosID;
                    if (!string.IsNullOrEmpty(logica.remision.TarjetaID) && logica.remision.TarjetaID != "0" && logica.remision.TarjetaID != " ")
                    {

                        SIFModelo.Descuento desc = new SIFNegocio.Descuentos().DescuentoPorID(logica.remision.DescuentoID);
                        logica.remision.ProveedorBeneficio = desc.Nombre;
                        this.Descuento = desc.Porcentaje;
                        logica.remision.PorcentajeDescuento = Descuento;

                       MessageBox.Show("La tarjeta " + logica.remision.TarjetaID + " se utilizará  para la venta");
                        this.statusLabel.Text = "DESCUENTO " + logica.remision.TarjetaID + " [" + logica.remision.ProveedorBeneficio + "]";
                    }

                    foreach (SIFModelo.PedidoDetalle detalle in pedido.Detalles)
                    {

                        SIFModelo.RemisionDetalle vdetalle = new SIFModelo.RemisionDetalle();
                        vdetalle.ArticuloID = detalle.ArticuloID;
                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
                        vdetalle.TIPO_MEDICAMENTO_CVE = articulo.TIPO_MEDICAMENTO_CVE;

                        vdetalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
                        //vdetalle.Caducidad = 
                        vdetalle.PiezasPedidas = detalle.CantidadPedido;
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

                    if (pedido.Factura == SIFModelo.Tipos.SiNo.SI)
                    {
                        this.conFacturaCheckBox.Checked = true;
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
                    SIFNegocio.Clientes cli = new SIFNegocio.Clientes();
                    SIFModelo.Cliente cliente = cli.ClientePorID(cotizacion.ClienteID);

                    if (cliente != null)
                    {
                        this.AgregaCliente(cliente);
                    }
                    //CHECAMOS SI EL CLIENTE ES CLIENTE CONVENIO Y PONEMOS EL DSCTO OTORGADO
                    clienteLabelX.Text = cliente.ID.ToString();
                    if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
                    {
                        ConvenioCliente = clienteN.ClientePorID(cliente.ID);
                        if (ConvenioCliente != null)
                        {
                            logica.remision.PorcentajeDescuento = ConvenioCliente.PorDesc;
                            PorScosto = ConvenioCliente.PorScosto;
                            Descuento = ConvenioCliente.PorDesc;
                            //verificamos si tiene venta con credito o no
                            if (ConvenioCliente.CondicionVenta == SIFModelo.Tipos.CondicionVenta.EFECTIVO)
                                creditoRadioButton.Enabled = false;
                            else
                                if (ConvenioCliente.CondicionVenta == SIFModelo.Tipos.CondicionVenta.CREDITO)
                                {
                                    creditoRadioButton.Checked = true;
                                }
                        }
                    }


                    cliente.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                    SIFModelo.DireccionCliente dirFiscal = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);
                    if (dirFiscal != null)
                        RFClabelX.Text = dirFiscal.RFC;

                    nombreClienteLabelX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
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
                    textBoxX1.Text = cotizacion.Comentario;
                    logica.remision.TotalArticulosRemision = cotizacion.TotalArticulos;
                    logica.remision.TarjetaID = cotizacion.NumeroCredencial;
                    logica.remision.DescuentoID = cotizacion.TipoCambioID;
                    // logica.remision.VendedorID = Helpers.Sesion.UsuarioSeleccionadoVenta.UsuariosID;
                    if (!string.IsNullOrEmpty(logica.remision.TarjetaID) && logica.remision.TarjetaID != "0" && logica.remision.TarjetaID != " ")
                    {

                        SIFModelo.Descuento desc = new SIFNegocio.Descuentos().DescuentoPorID(logica.remision.DescuentoID);
                        logica.remision.ProveedorBeneficio = desc.Nombre;
                        this.Descuento = desc.Porcentaje;
                        logica.remision.PorcentajeDescuento = Descuento;

                       MessageBox.Show("La tarjeta " + logica.remision.TarjetaID + " se utilizará  para la venta");
                        this.statusLabel.Text = "DESCUENTO " + logica.remision.TarjetaID + " [" + logica.remision.ProveedorBeneficio + "]";
                    }

                    foreach (SIFModelo.CotizacionDetalle detalle in cotizacion.Detalles)
                    {
                        if (detalle.CantRem <= detalle.CantidadCotizacion)
                        {
                            SIFModelo.RemisionDetalle vdetalle = new SIFModelo.RemisionDetalle();
                            vdetalle.ArticuloID = detalle.ArticuloID;
                            SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
                            vdetalle.TIPO_MEDICAMENTO_CVE = articulo.TIPO_MEDICAMENTO_CVE;
                            //vdetalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
                            //vdetalle.Caducidad = 
                            vdetalle.PiezasPedidas = detalle.CantidadCotizacion - int.Parse(detalle.CantRem.ToString());
                            vdetalle.DescuentoID = detalle.DescuentoID;
                            //vdetalle.FechaEntrega = detalle.fe
                            //vdetalle.FolioControlado = detalle.folio
                            vdetalle.ImpuestoID = detalle.ImpuestoID;
                            vdetalle.IVA = detalle.IVA;
                            //vdetalle.Lote = detalle.lote
                            //vdetalle.Mensaje = detalle.mens
                            vdetalle.MontoDescuento = detalle.Descto;
                            vdetalle.Nombre1 = detalle.Nombre1;
                            vdetalle.Nombre2 = detalle.Nombre2;
                            vdetalle.NumeroPartida = detalle.NumeroPartida;
                            //vdetalle.NumeroRemision = detalle.
                            vdetalle.PaqueteID = detalle.PaqueteID;
                            //vdetalle.PiezasAcumuladas = detalle.acu
                            //vdetalle.PiezasGratis = detalle.pie
                            //vdetalle.PiezasPagadas = detalle.pieza
                            //vdetalle.CantidadRemision = detalle.CantidadCotizacion;
                            //vdetalle.PorcentajeDescuento = detalle.porc
                            vdetalle.Precio = detalle.Precio;
                            vdetalle.MontoDescuento = detalle.Descto;
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
                    if (cotizacion.Factura == SIFModelo.Tipos.SiNo.SI)
                    {
                        this.conFacturaCheckBox.Checked = true;
                    }
                }
            }



            this.VerificaInventario();

            Carga = true;
            if (conFacturaCheckBox.Checked)
            {
                this.conFacturaCheckBox_CheckedChanged(conFacturaCheckBox.Checked, null);
            }
        }


        private bool VerificaInventario()
        {
            SIFNegocio.Inventario.Inventario inventarioL = new SIFNegocio.Inventario.Inventario();
            foreach (var detalle in logica.RemisionDetalles)
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
                if (!inventarioL.InventarioArticuloSinApartado(articulo, detalle.CantidadRemision + detalle.PiezasGratis, out existencias))
                {
                    //MessageBoxEx.Show("Inventario insuficiente para el artículo "  + detalle.Nombre1 + " ["+detalle.ArticuloID+"]");
                    detalle.CantidadRemision = existencias;
                    return false;
                }

            }

            return true;
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
                CodigoTextBoxX.Text = "";
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
            }
        }

        private void loteCaducidadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
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
                if (e.GridPanel.ActiveRow == null)
                {
                    return;
                }
                GridIntegerInputEditControl integerInput = e.EditControl as GridIntegerInputEditControl;

                SIFModelo.RemisionDetalle detalle = (SIFModelo.RemisionDetalle)((GridRow)e.GridPanel.ActiveRow).DataItem;
                SIFModelo.Articulo articulo = new SIFModelo.Articulo() { ARTICULO_ID = detalle.ArticuloID };


                this.ModificaCantidadArtículo(articulo, detalle);
                this.CalculaTotal();
                //VALIDAMOS QUE EL LOTE SEA CORRECTO
                //txt.Text;

            }

            //if (dataGrid.ActiveRow != this.dataGrid.LastSelectableRow)
            //{
            //    GridCell cell = superGridControl1.ActiveCell;
            //    dataGrid.SetSelectedCells(cell.GridRow.Index + 1, cell.ColumnIndex, 1, 1, false);
            //    dataGrid.SetActiveCell(dataGrid.);
            //    superGridControl1.ActiveCell.BeginEdit(true);
            //}
        }

        private void conFacturaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.conFacturaCheckBox.Checked & Carga)
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

            if (dataGrid.ActiveRow != this.dataGrid.LastSelectableRow)
            {
                GridCell cell = superGridControl1.ActiveCell;
                dataGrid.SetSelectedCells(cell.GridRow.Index + 1, cell.ColumnIndex, 1, 1, false);
                superGridControl1.ActiveCell.BeginEdit(true);
            }
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

        private void cantidadTextBoxX_TextChanged(object sender, EventArgs e)
        {

        }

        private void CodigoTextBoxX_TextChanged(object sender, EventArgs e)
        {

        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }
        }

        private void superGridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            GridRow row = this.superGridControl1.ActiveRow as GridRow;

            if (row == null)
            {
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {

                int columna = superGridControl1.ActiveCell.ColumnIndex;
                if (row.RowIndex <= superGridControl1.PrimaryGrid.LastSelectableRow.RowIndex)
                { row.GetCell(columna).BeginEdit(true); }

                //GridCell celda = this.superGridControl1.;
                //celda = superGridControl1.cell 
                //var s = superGridControl1.PrimaryGrid.SetActiveCell( superGridControl1.PrimaryGrid.ActiveRow.rowi;
                // //superGridControl1.PrimaryGrid.SetActiveCell();
                // //this.superGridControl1.PrimaryGrid.SetActiveCell(celda);
                // celda.BeginEdit(true);
            }
            if (e.KeyCode == Keys.Tab)
            {
                int columna = superGridControl1.ActiveCell.ColumnIndex;
                if (columna <= superGridControl1.PrimaryGrid.Columns.Count - 1)
                {
                    columna++;
                    try
                    {
                        row.GetCell(columna).BeginEdit(true);
                    }
                    catch
                    {
                        superGridControl1.CancelCapture();
                    }
                }
            }

        }

    }
}
