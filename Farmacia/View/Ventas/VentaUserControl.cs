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
    public partial class VentaUserControl : Templates.ListaUserControl
    {
        public bool Mostrado = false;
        public Menu.VentasMenu Owner;
        private SIFModelo.Usuario cajero;
        private SIFModelo.WebServices.TAE tae;
        SIFModelo.ClienteConvenio ConvenioCliente;
        public SIFModelo.ClienteSubrogaccion ClienteSub;
        private SIFModelo.Valesubrogacion pVale;
        SIFNegocio.ClienteSubrogacion ClienteSubN = new SIFNegocio.ClienteSubrogacion();
        SIFNegocio.ClienteConvenios clienteN = new SIFNegocio.ClienteConvenios();

        SIF.View.Ventas.RecetaForm recetaa = new SIF.View.Ventas.RecetaForm();
        SIF.View.Ventas.DatosDerechohabiente DDerechoh = new SIF.View.Ventas.DatosDerechohabiente();
        SIF.View.Ventas.DatosMedico DMedicos = new SIF.View.Ventas.DatosMedico();
        SIFNegocio.clienteHUP hup = new SIFNegocio.clienteHUP();
        SIFModelo.cliente_Hup hup2 = new SIFModelo.cliente_Hup();

        public decimal porcentaje;
        public VentaUserControl()
        {
            InitializeComponent();
            Privilegios();
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 1, int.Parse(Xbtn.Tag.ToString()));
            }

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
            this.cantidadTextBoxX.Text = "1";

            frmArticulo.Muestra();
            //frmArticulo.Owner = this;
            //this.Owner.Owner.ShowModalPanel(frmArticulo, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            //this.DesactivaComandos();
            //frmArticulo.ActivaComandos();
        }

        private void SeleccionaArticuloSubrogacion(bool porClaveArticulo = false)
        {
            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(logica.remision.ClienteID);
            ArticulosIsstepForm frmArticulo = new ArticulosIsstepForm(cliente, CodigoTextBoxX.Text, porClaveArticulo);

            if (frmArticulo.ShowDialog() == DialogResult.OK)
            {
                this.AgregaArticulo(frmArticulo.articuloSeleccionado);
                this.cantidadTextBoxX.Text = "1";
            }

            //if (frmArticulo == null)
            //{
            // frmArticulo = new Articulos.ArticuloUserControl();
            //frmArticulo.Dock = DockStyle.Fill;
            //frmArticulo.Owner = this;

            //}


            //frmArticulo.Muestra();
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
            SIFModelo.Articulo articulo = null;
            if (ClienteSub == null)
                articulo = articuloL.BuscarPorClave(claveArticulo);
            else
            {

                if (articuloL.MasDeUnoPorClaveSub(claveArticulo, ClienteSub.ID.ToString()))
                {
                    this.SeleccionaArticuloSubrogacion();
                    return;
                }
                else
                {
                    if (articuloL.MasDeUnoPorArticuloSub(claveArticulo, ClienteSub.ID.ToString()))
                    {
                        this.SeleccionaArticuloSubrogacion(true);
                        return;
                    }
                    else
                    {
                        articulo = articuloL.BuscarPorClaveSub(claveArticulo, null, ClienteSub.ID.ToString());
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


        public List<SIFModelo.Articulo> articulosFaltantes = new List<SIFModelo.Articulo>();
        internal void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            if (!articulo.LISTA_SUCURSAL_VTA.Contains(this.logica.remision.SucursalID.ToString()))
            {
               MessageBox.Show("El artículo no está permitido en esta sucursal");
                return;
            }

            if (articulo.TIPO_MEDICAMENTO_CVE.Contains("TAE"))
            {
               MessageBox.Show("El artículo no puede ser vendido directamente, por favor ocupe el módulo para TAE", "Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //if (logica.ContieneDetalle(articulo))
            //{
            //    var vdetalle = from d in logica.RemisionDetalles where d.ArticuloID == articulo.ARTICULO_ID select d;


            //    SIFModelo.RemisionDetalle rdetalle = vdetalle.First();
            //    int existencias = 0;
            //    if (!inventario.InventarioArticulo(articulo, rdetalle.CantidadRemision + int.Parse(cantidadTextBoxX.Text), out existencias, ClienteSub))
            //    {

            //        if (MessageBoxEx.Show("¿Agregar a la lista de artículos faltantes el artículo " + articulo.ARTICULO_ID + " [" + articulo.NOMBRE1 + "] ?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            articulo.TIPO_MONEDA = int.Parse(cantidadTextBoxX.Text) - existencias;
            //            this.agregaArticuloFaltante(articulo);
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

            bool agregar = true;

            if (ClienteSub != null)
            {
                if (!logica.ContieneDetalleSub(articulo))
                {
                    agregar = false;
                }
            }

            if (logica.ContieneDetalle(articulo) && ((!this.loteCaducidadCheckBox.Checked && !articulo.TIPO_MEDICAMENTO_CVE.Contains("F1") && agregar) || (logica.remision.ProveedorBeneficio == PROVEEDOR_NADRO || logica.remision.ProveedorBeneficio == PROVEEDOR_PFIZER)))
            {

                if (articulo.TIPO_MEDICAMENTO_CVE.Contains("F1"))
                {
                   MessageBox.Show("El medicamento ya fue agregado por medio de un folio controlado");
                    return;
                }

                var vdetalle = from d in logica.RemisionDetalles where d.ArticuloID == articulo.ARTICULO_ID select d;
                SIFModelo.RemisionDetalle rdetalle = vdetalle.First();

                if (!inventario.InventarioArticulo(articulo, int.Parse(cantidadTextBoxX.Text) + rdetalle.CantidadRemision, out existencias1, ClienteSub))
                {
                    if (MessageBoxEx.Show("¿Agregar a la lista de artículos faltantes el artículo " + articulo.ARTICULO_ID + " [" + articulo.NOMBRE1 + "] ?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        articulo.TIPO_MONEDA = int.Parse(cantidadTextBoxX.Text) - existencias1;
                        this.agregaArticuloFaltante(articulo);
                    }

                    if (ClienteSub != null)
                    {
                        var vdetalleCli = from d in logica.RemisionDetalles where d.ArticuloID == articulo.ARTICULO_ID && d.CODIGO_CLI == articulo.CODIGO_CLI select d;

                        if (vdetalleCli.Count() > 0)
                        {
                            rdetalle = vdetalleCli.First();
                        }
                    }

                    rdetalle.CantidadRemision = existencias1;
                    beneficiosConsultado = false;
                    CalculaTotal();
                    return;
                }

            }
            else
            {
                int cantidadPedida = int.Parse(cantidadTextBoxX.Text);

                if (!inventario.InventarioArticulo(articulo, int.Parse(cantidadTextBoxX.Text), out existencias1, ClienteSub))
                {
                    if (MessageBoxEx.Show("¿Agregar a la lista de artículos faltantes el artículo " + articulo.ARTICULO_ID + " [" + articulo.NOMBRE1 + "] ?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        articulo.TIPO_MONEDA = int.Parse(cantidadTextBoxX.Text) - existencias1;
                        this.agregaArticuloFaltante(articulo);
                    }
                    return;
                }

                //SELECCINAR LOS ARTICULOS AGREGADOS Y CALCULAR LAS EXISTENCIAS
                var articuloExistente = from d in logica.RemisionDetalles where d.ArticuloID == articulo.ARTICULO_ID select d;

                int agregados = 0;
                if (articuloExistente.Count() > 0)
                {

                    agregados = articuloExistente.ToList().Sum(e => e.CantidadRemision);
                }

                if (agregados.ToString().IsInteger())
                {
                    if ((agregados + cantidadPedida) > existencias1)
                    {
                        if (MessageBoxEx.Show("¿Agregar a la lista de artículos faltantes el artículo " + articulo.ARTICULO_ID + " [" + articulo.NOMBRE1 + "] ?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            articulo.TIPO_MONEDA = (agregados + cantidadPedida) - existencias1;
                            this.agregaArticuloFaltante(articulo);
                        }

                        cantidadPedida = existencias1 - agregados; // (agregados - cantidadPedida);

                        if (cantidadPedida <= 0)
                        {
                            return;
                        }

                        this.cantidadTextBoxX.Text = cantidadPedida.ToString();
                        return;
                    }
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
            detalle.CODIGO_CLI = articulo.CODIGO_CLI;
            detalle.CODIGO_CLI_ID = articulo.CODIGO_CLI_ID;
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
                    frmIngresa.usuarioID = logica.remision.VendedorID;
                    if (frmIngresa.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    detalle.OFolioControlado = frmIngresa.FolioControlado;
                    logica.remision.MedicoID = frmIngresa.FolioControlado.MedicoID;

                    this.controladoButtonItem.Enabled = true;
                }

                //REVISAR SI EL FOLIO CONTROLADO CONTIENE EL DETALLE Y LA CANTIDAD ESPECIFICADA
                //string CveClisub = "";
                //if (ClienteSub != null)
                //{
                //    CveClisub = articulo.ARTICULO_ID;
                //    articulo.ARTICULO_ID = articulo.CODIGO_CLI;

                //}
                var folioControlado = from c in detalle.OFolioControlado.Detalles where c.ArticuloID == articulo.ARTICULO_ID select c;

                if (folioControlado.Count() == 0)
                {
                   MessageBox.Show("El artículo no esta dado de alta en el folio controlado");
                    return;
                }

                SIFModelo.ControladoDetalle controladoDetalle = folioControlado.First();

                //VALIDAR SI YA FUE INGRESADO
                if (logica.ContieneDetalle(articulo))
                {
                    var vdetalle = from d in logica.RemisionDetalles where d.ArticuloID == articulo.ARTICULO_ID && d.OFolioControlado.Folio == controladoDetalle.Folio select d;
                    SIFModelo.RemisionDetalle rdetalle = vdetalle.FirstOrDefault();

                    if (rdetalle != null)
                    {
                        //if (rdetalle.CantidadRemision + detalle.CantidadRemision > controladoDetalle.Cantidad)
                        //{
                       MessageBox.Show("El artículo ya fue agregado con el folio controlado, por favor modifique la cantidad");
                        return;
                        //}
                    }
                }

                detalle.CantidadRemision = controladoDetalle.Cantidad;


                //if (ClienteSub != null)
                //    articulo.ARTICULO_ID = CveClisub;

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
                logica.AgregaDetalle(detalle, logica.remision, this.loteCaducidadCheckBox.Checked, ClienteSub, agregar);
                beneficiosConsultado = false;
            }

            dataGrid.DataSource = logica.RemisionDetalles;
            superGridControl1.Refresh();
            //if (ClienteSub != null)
            //    this.CodigoTextBoxX.Text = articulo.CODIGO_CLI;
            //else
            //    this.CodigoTextBoxX.Text = articulo.ARTICULO_ID;

            this.descripcionTextBoxX.Text = articulo.NOMBRE1;

            this.CalculaTotal();
            this.cantidadTextBoxX.Text = "1";

            this.CodigoTextBoxX.SelectAll();
            this.CodigoTextBoxX.Focus();
        }

        private bool PrecioArticulo(SIFModelo.RemisionDetalle detalle)
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
                SIFModelo.Articulo articulop = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
                if (PorScosto > 0 && !articulop.TIPO_MEDICAMENTO_CVE.ToString().Contains("SD"))//L 23/12/2013 PARA EVITAR QUE SE APLIQUE PORCENTAJE SOBRE COSTO A SD
                    //L 20/11/2013 : *(1+precios.PORCENTAJE_IMP/100)
                    detalle.Precio = (precios.PRECIO_COSTO + (precios.PRECIO_COSTO * (PorScosto / 100)))/**(1+precios.PORCENTAJE_IMP/100)*/;
                else
                    detalle.Precio = precios.PRECIO_VENTA;
                detalle.Total = detalle.CantidadRemision * detalle.Precio;
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

            string claveArticulo = this.CodigoTextBoxX.Text;
            int cantidad = int.Parse(cantidadTextBoxX.Text);
            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = null;
            if (ClienteSub == null)
                articulo = articuloL.BuscarPorClave(claveArticulo);
            else
            {
                if (articuloL.MasDeUnoPorClaveSub(claveArticulo, ClienteSub.ID.ToString()))
                {
                    this.SeleccionaArticuloSubrogacion();
                    return;
                }
                else
                {
                    if (articuloL.MasDeUnoPorArticuloSub(claveArticulo, ClienteSub.ID.ToString()))
                    {
                        this.SeleccionaArticuloSubrogacion(true);
                        return;
                    }
                    else
                    {
                        articulo = articuloL.BuscarPorClaveSub(claveArticulo, null, ClienteSub.ID.ToString());
                    }
                }
            }

            if (articulo == null)
            {
               MessageBox.Show("El artículo no existe en el catalogo");
                return;
            }

            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();

            if (!logica.ContieneDetalle(articulo))
            {
                int existencias = 0;
                if (!inventario.InventarioArticulo(articulo, cantidad, out existencias, ClienteSub))
                {
                    if (MessageBoxEx.Show("¿Agregar a la lista de artículos faltantes el artículo " + articulo.ARTICULO_ID + " [" + articulo.NOMBRE1 + "] ?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        articulo.TIPO_MONEDA = int.Parse(cantidadTextBoxX.Text) - existencias;
                        this.agregaArticuloFaltante(articulo);
                        this.beneficiosConsultado = false;
                        this.reportarFaltantes();
                        
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
                if (!inventario.InventarioArticulo(articulo, cantidad, out existencias, ClienteSub))
                {

                    if (MessageBoxEx.Show("¿Agregar a la lista de artículos faltantes el artículo " + articulo.ARTICULO_ID + " [" + articulo.NOMBRE1 + "] ?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        articulo.TIPO_MONEDA = int.Parse(cantidadTextBoxX.Text) - existencias;
                        agregaArticuloFaltante(articulo);
                        this.cantidadTextBoxX.Text = " ";

                    }

                    cantidadTextBoxX.Text = existencias.ToString();
                    rdetalle.CantidadRemision = existencias;
                    return;
                }
            }

            logica.ModificaCantidad(articulo, cantidad);
            beneficiosConsultado = false;
            this.CalculaTotal();
            superGridControl1.Refresh();
        }

        private void agregaArticuloFaltante(SIFModelo.Articulo articulo)
        {
            var v_articuloFaltante = from f in articulosFaltantes where f.ARTICULO_ID == articulo.ARTICULO_ID select f;

            /*if (v_articuloFaltante.Count() > 0)
            {
                articulosFaltantes.Add(articulo);
                SIFModelo.Articulo faltante = v_articuloFaltante.First();
                faltante.TIPO_MONEDA += articulo.TIPO_MONEDA;
            }
            else
            {*/
            articulosFaltantes.Add(articulo);
            //this.reportarFaltantes();
            //}
        }

        private void ModificaCantidadArtículo(SIFModelo.Articulo articulo, SIFModelo.RemisionDetalle detalle)
        {
            if (articulo == null)
            {
               MessageBox.Show("El artículo no existe en el catalogo");
                return;
            }

            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();

            if (detalle.FolioControlado == "SI")
            {
                List<SIFModelo.ControladoDetalle> detallesControlado = new SIFNegocio.Controlado().DetallesControlado(detalle.OFolioControlado);

                var controladoEncontrado = from d in detallesControlado where d.ArticuloID == detalle.ArticuloID select d;

                if (controladoEncontrado.Count() > 0)
                {
                    SIFModelo.ControladoDetalle detalleControlado = controladoEncontrado.First();

                    if (detalle.CantidadRemision != detalleControlado.Cantidad)
                    {
                       MessageBox.Show("La cantidad de remsión debe ser igual a la del folio controlado");
                        detalle.CantidadRemision = detalleControlado.Cantidad;
                    }
                }
            }

            int existencias = 0;
            if (!inventario.InventarioArticulo(articulo, detalle.CantidadRemision, out existencias, ClienteSub))
            {
                if (MessageBoxEx.Show("¿Agregar a la lista de artículos faltantes el artículo " + articulo.ARTICULO_ID + " [" + detalle.Nombre1 + "] ?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    articulo.TIPO_MONEDA = int.Parse(cantidadTextBoxX.Text) - existencias;
                    this.agregaArticuloFaltante(articulo);
                }

                cantidadTextBoxX.Text = existencias.ToString();
                detalle.CantidadRemision = existencias;

            }

            //REVISAR LA CANTIDAD DE TODOS LOS MEDICAMENTOS REPETIDOS
            if (this.loteCaducidadCheckBox.Checked)
            {
                var agregados = logica.RemisionDetalles.Sum(p => p.CantidadRemision);

                if (agregados.ToString().IsInteger())
                {
                    if (agregados > existencias)
                    {
                        if (MessageBoxEx.Show("¿Agregar a la lista de artículos faltantes el artículo " + articulo.ARTICULO_ID + " [" + detalle.Nombre1 + "] ?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            articulo.TIPO_MONEDA = agregados - existencias;
                            this.agregaArticuloFaltante(articulo);
                        }

                        detalle.CantidadRemision = existencias - (agregados - detalle.CantidadRemision);
                        return;
                    }
                }
            }
            this.CalculaTotal();
            superGridControl1.Refresh();
        }

        private decimal Descuento;
        private decimal PorScosto;

        private void CalculaTotal()
        {
            if (logica.remision.ProveedorBeneficio == PROVEEDOR_NADRO)
            { //logica.remision.TotalArticulosRemision = logica.RemisionDetalles.Sum(r => r.CantidadRemision + r.PiezasGratis);
            logica.remision.TotalArticulosRemision = logica.RemisionDetalles.Sum(r => r.PiezasPagadas + r.PiezasGratis);
            }
            else
                logica.remision.TotalArticulosRemision = logica.RemisionDetalles.Sum(r => r.CantidadRemision);
            // logica.remision.Descuento 

            logica.remision.Descuento = 0; // logica.remision.SubTotal * (Descuento / (decimal)100.0);


            foreach (SIFModelo.RemisionDetalle detalle in logica.RemisionDetalles)
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
                            detalle.RefOferta = listaOfertaVenta.LISTA_OFERTAS_ID;

                            // detalle.MontoDescuento = detalle.Precio - detalle.PrecioDescontado;
                        }


                        if (listaOfertaVenta.APLICADO_A == "F")
                        {
                            detalle.PrecioDescontado = precios.PRECIO_VENTA - (precios.PRECIO_VENTA * ((decimal)listaOfertaVenta.DESCUENTO / 100m));
                            detalle.PorcentajeDescuento = (decimal)listaOfertaVenta.DESCUENTO;
                            detalle.MontoDescuento = (precios.PRECIO_VENTA * ((decimal)listaOfertaVenta.DESCUENTO / 100m));

                            detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioDescontado);
                            detalle.Precio = precios.PRECIO_VENTA;
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
                                decimal impDescuento = (SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio) * detalle.CantidadRemision) * (Descuento / 100);
                                detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio) - (SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio) * (Descuento / 100));

                                //detalle.Total = (detalle.CantidadRemision * detalle.Precio) - impDescuento;

                                //if (this.logica.remision.ProveedorBeneficio == PROVEEDOR_PFIZER)
                                //{
                                detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((detalle.CantidadRemision - detalle.PiezasGratis) * SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio)) - SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(impDescuento));
                                //}

                                detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
                                // detalle.Total = (detalle.Precio * detalle.CantidadRemision) - descuentoPorcentaje;

                                //detalle.Total = detalle.PrecioDescontado * detalle.CantidadRemision;

                                logica.remision.Descuento += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(impDescuento);
                            }
                            else
                            {
                                detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                                detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((detalle.CantidadRemision - detalle.PiezasGratis) * SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio)));
                            }
                        }
                        else if (ConvenioCliente.PorDesc > 0 && !Articulo.TIPO_MEDICAMENTO_CVE.Contains("SD"))//L 23/12/2013 Para que no aplique porcentaje sobre costo a SD's
                        {
                            decimal impDescuento = (SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio) * detalle.CantidadRemision) * (Descuento / 100);
                            detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio) - (SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio) * (Descuento / 100));

                            detalle.Total = ((detalle.CantidadRemision - detalle.PiezasGratis) * SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio)); //- SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(impDescuento);
                            detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
                            logica.remision.Descuento += impDescuento;
                        }
                        else
                        {
                            detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                            detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                            detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((detalle.CantidadRemision - detalle.PiezasGratis) * SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio)));
                        }
                    }
                    else
                        if (!Articulo.TIPO_MEDICAMENTO_CVE.Contains("SD"))
                        {
                            if (detalle.BeneficioProveedor == SIFModelo.Tipos.SiNo.NO)
                            {
                                detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);

                                decimal impDescuento = (detalle.Precio * detalle.CantidadRemision) * (Descuento / 100);
                                //AVM -- ASIGNA EL DESCUENTO A LA PROPIEDAD CORRESPONDIENTE
                                detalle.MontoDescuento = impDescuento;
                                detalle.PrecioDescontado = detalle.Precio - (detalle.Precio * (Descuento / 100));

                                if (Descuento == 0)
                                {
                                    impDescuento = (detalle.Precio * detalle.CantidadRemision) * (detalle.PorcentajeDescuento / 100);
                                    detalle.PrecioDescontado = detalle.Precio - (detalle.Precio * (detalle.PorcentajeDescuento / 100));
                                }

                                detalle.Total = (detalle.CantidadRemision * detalle.Precio);// - impDescuento;

                                //if (this.logica.remision.ProveedorBeneficio == PROVEEDOR_PFIZER)    
                                //{
                                //detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((((detalle.CantidadRemision - detalle.PiezasGratis) * detalle.Precio) - ((detalle.Precio * detalle.CantidadRemision) * (Descuento / 100)))); // - impDescuento);
                                //}

                                detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
                                // detalle.Total = (detalle.Precio * detalle.CantidadRemision) - descuentoPorcentaje;

                                //detalle.Total = detalle.PrecioDescontado * detalle.CantidadRemision;

                                logica.remision.Descuento += impDescuento;
                            }
                        }
                        else
                        {
                            detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                            detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((detalle.CantidadRemision - detalle.PiezasGratis) * detalle.Precio));
                        }

                }
                else
                {
                    //SIFModelo.Inventarios.ListaPrecios preciosSub = new SIFNegocio.Articulo().ArticuloPrecioSub(detalle.ArticuloID);
                    //detalle.Precio = preciosSub.PRECIO_VENTA;
                    detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                    detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((detalle.CantidadRemision - detalle.PiezasGratis) * detalle.Precio));

                }

                SIFModelo.Inventarios.ListaPrecios preciosd = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
                detalle.PrecioCosto = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(preciosd.PRECIO_COSTO);
            }

            //logica.remision.SubTotal = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(logica.RemisionDetalles.Sum(r => r.Precio * (r.CantidadRemision - r.PiezasGratis)));
            //logica.remision.SubTotal = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(logica.RemisionDetalles.Sum(r => r.Total ));


            //descuentos de la tarjeta
            //var descuentoTarjeta = logica.RemisionDetalles.Sum(r => r.MontoDescuento * r.CantidadRemision);
            //logica.remision.Descuento += decimal.Parse(descuentoTarjeta.ToString());



            decimal descuentoProveedor = 0;
            if (logica.remision.ProveedorBeneficio == PROVEEDOR_NADRO)
            {


                logica.remision.SubTotal = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(logica.RemisionDetalles.Sum(r => r.Precio * (r.PiezasPagadas)));

                foreach (SIFModelo.RemisionDetalle detalle in logica.RemisionDetalles)
                {

                    if (detalle.PiezasPagadas == 0 && detalle.PiezasGratis==0 )
                    {
                        detalle.PiezasPagadas = detalle.CantidadRemision;
                    }

                    SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
                    detalle.Total = detalle.PiezasPagadas * detalle.Precio;

                    if (detalle.TipoPrecioDescuento == 1)
                    {
                        //ASIGNAR EL PRECIO Y RECALCULAR
                        detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_VENTA_MAX);
                        //  detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_VENTA_MAX - detalle.MontoDescuento);
                        logica.remision.SubTotal = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(logica.RemisionDetalles.Sum(r => r.Precio * (r.CantidadRemision)));
                        this.subtotalLabelX.Text = logica.remision.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));


                        if (detalle.MontoDescuento > 0)
                        {
                            detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_VENTA_MAX - detalle.MontoDescuento);
                            detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioDescontado * detalle.CantidadRemision); // * detalle.CantidadRemision);
                            descuentoProveedor += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((precios.PRECIO_VENTA_MAX - detalle.PrecioDescontado) * (detalle.CantidadRemision));
                            detalle.IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((detalle.PrecioDescontado * detalle.CantidadRemision) / (1 + porcentaje)) * porcentaje);
                        }
                        else
                        {
                            detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_VENTA_MAX - (precios.PRECIO_VENTA_MAX * (detalle.PorcentajeDescuento / 100)));
                            detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioDescontado * detalle.CantidadRemision);
                            descuentoProveedor += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((precios.PRECIO_VENTA_MAX - detalle.PrecioDescontado) * (detalle.CantidadRemision));
                            detalle.IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((detalle.PrecioDescontado * detalle.CantidadRemision) / (1 + porcentaje)) * porcentaje);
                        }

                        detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                    }
                    if (detalle.TipoPrecioDescuento == 2)
                    {
                        if (detalle.MontoDescuento > 0)
                        {
                            detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_VENTA - detalle.MontoDescuento);
                            detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio * detalle.CantidadRemision);
                            descuentoProveedor += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((precios.PRECIO_VENTA - detalle.PrecioDescontado) * (detalle.CantidadRemision));
                            detalle.IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((detalle.PrecioDescontado * detalle.CantidadRemision) / (1 + porcentaje)) * porcentaje);
                        }
                        else
                        {
                            detalle.MontoDescuento = (precios.PRECIO_VENTA * (detalle.PorcentajeDescuento / 100));
                            detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_VENTA - (precios.PRECIO_VENTA * (detalle.PorcentajeDescuento / 100)));
                            detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio * detalle.CantidadRemision);
                            descuentoProveedor += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((precios.PRECIO_VENTA - detalle.PrecioDescontado) * (detalle.CantidadRemision));
                            detalle.IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((detalle.PrecioDescontado * detalle.CantidadRemision) / (1 + porcentaje)) * porcentaje);
                        }

                        detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                    }

                    if (detalle.PrecioProveedor > 0)
                    {
                        //detalle.Precio = detalle.PrecioProveedor;
                        detalle.PrecioDescontado = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioProveedor);
                        detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioDescontado * detalle.CantidadRemision);
                        descuentoProveedor += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((precios.PRECIO_VENTA - detalle.PrecioDescontado) * detalle.CantidadRemision);
                        detalle.IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((detalle.PrecioDescontado * detalle.CantidadRemision) / (1 + porcentaje)) * porcentaje);

                        //logica.remision.SubTotal = logica.RemisionDetalles.Sum(r => r.Precio * (r.CantidadRemision));
                        //this.subtotalLabelX.Text = logica.remision.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

                        detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                    }

                    //descuentoProveedorLabelX.Text = descuentoProveedor.ToString("C2");
                }
            }
            else
            {
                foreach (SIFModelo.RemisionDetalle detalle in logica.RemisionDetalles)
                {
                    //decimal descuentoPorcentaje = (detalle.Precio * detalle.CantidadRemision) * (detalle.PorcentajeDescuento / 100);
                    //detalle.PrecioDescontado = detalle.Precio;

                    //detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
                    // detalle.Total = (detalle.Precio * detalle.CantidadRemision) - descuentoPorcentaje;

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
                            //decimal 

                            porcentaje = impuesto.Porcentaje / 100;



                            //IVA ANTES DESCUENTO   detalle.IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((detalle.Total / (1 + porcentaje)) * porcentaje);
                            detalle.Precio = detalle.Precio;
                            //LGS 07/10/2014 PARA QUE CALCULE EL IVA CORRECTAMENTE EN VENTA PFIZER
                            detalle.CantidadRemision = detalle.CantidadRemision - detalle.PiezasGratis;
                            detalle.IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((detalle.PrecioDescontado * detalle.CantidadRemision) / (1 + porcentaje)) * porcentaje);
                            detalle.CantidadRemision = detalle.CantidadRemision + detalle.PiezasGratis;
                            detalle.PorcentajeIVA = porcentaje;
                            detalle.ImpuestoID = impuesto.ID;
                        }
                    }

                    //detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioDescontado * detalle.CantidadRemision);

                    if (detalle.PiezasPagadas > 0)
                    {
                        detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioDescontado * detalle.PiezasPagadas);
                    }

                    if (this.logica.remision.ProveedorBeneficio == PROVEEDOR_PFIZER)
                    {
                        detalle.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PrecioDescontado * (detalle.CantidadRemision - detalle.PiezasGratis));
                        if (detalle.PiezasPagadas > 0)
                            detalle.PiezasPagadas = detalle.CantidadRemision - detalle.PiezasGratis;
                    }

                }
            }



            logica.remision.SubTotal = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(logica.RemisionDetalles.Sum(r => r.Total)); ///+ r.MontoDescuento AVM 23-04-2015 (MODIFICACION MIA)


            this.descuentoLabelX.Text = (logica.remision.Descuento + descuentoProveedor).ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

            logica.remision.Impuesto = logica.RemisionDetalles.Sum(r => r.IVA);
            this.IVAlabelX.Text = logica.remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.logica.remision.SubTotal = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(logica.remision.SubTotal - logica.remision.Impuesto);
            this.subtotalLabelX.Text = logica.remision.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

            //if (logica.remision.ProveedorBeneficio == PROVEEDOR_NADRO)
            //{
            //    this.logica.remision.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(logica.remision.SubTotal - logica.remision.Descuento + logica.remision.Impuesto);
            //}
            //else
            //{
            this.logica.remision.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(logica.remision.SubTotal - logica.remision.Descuento - descuentoProveedor + logica.remision.Impuesto);
            //}
            this.totalLabelX.Text = logica.remision.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.logica.remision.Impuesto = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(logica.RemisionDetalles.Sum(r => r.IVA));
            this.IVAlabelX.Text = logica.remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.logica.remision.ImporteLetra = sif_tools.NumberToLetters.NumToLetter((double)logica.remision.Total, logica.remision.Total.GetType().ToString());
            totalLetraLabelX.Text = this.logica.remision.ImporteLetra;
            logica.remision.Descuento = logica.remision.Descuento + descuentoProveedor;
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

            //Ventas.CotizacionUserControl frmCotizacion = new CotizacionUserControl(true, this.logica.remision.ClienteID);
            //frmCotizacion.Owner = this;
            //frmCotizacion.Muestra();

            Ventas.CotizacionInmediataUserControl frmCotizacion = new CotizacionInmediataUserControl(true, this.logica.remision.ClienteID);
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

            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(logica.remision.ClienteID);

            if (cliente != null)
            {
                if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
                {
                   MessageBox.Show("No puede aplicar descuentos a clientes convenio");
                    return;
                }
            }

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

            String descuentosAplicados = "";
            foreach (var item in logica.RemisionDetalles)
            {
                if (item.PorcentajeDescuento != 0)
                {
                    //if(porcentajeDesAplicado < item.PorcentajeDescuento)
                    descuentosAplicados += item.Nombre1 + ": " + item.PorcentajeDescuento.ToString()+ "%" + "\n";
                }
            }

            if (descuentosAplicados != "")
                if (System.Windows.Forms.DialogResult.No == MessageBox.Show("Existen productos con descuento, al aplicar este descuento " +
                                                            "se perderán los siguientes:" + "\n \n" + descuentosAplicados + "\n \n" + "¿Desea continuar?",
                                                            "Descuento aplicado", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    return;

            this.logica.remision.TarjetaID = frmDescuento.TarjetaID;
            this.logica.remision.ProveedorBeneficio = frmDescuento.BeneficioProveedor;
            logica.remision.DescuentoID = frmDescuento.DescuentoID;
            logica.remision.PorcentajeDescuento = frmDescuento.DescuentoProveedor;
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


            //if (this.esClienteMostrador())
            //{
            //   MessageBox.Show("Elija un cliente válido");
            //    return;
            //}

            Ventas.PfizerForm frmPfizer = new PfizerForm();
            if (frmPfizer.ShowDialog() == DialogResult.OK)
            {
                this.pfizer = new SIFModelo.WebServices.TarjetaPfizer();
                this.pfizer.TarjetaID = frmPfizer.TarjetaID;
                this.logica.remision.TarjetaID = frmPfizer.TarjetaID;
                logica.remision.ProveedorBeneficio = PROVEEDOR_PFIZER;
                this.statusLabel.Text = "BENEFICIO PFIZER " + logica.remision.TarjetaID;
                this.ConsultarWebServiceButtonX.Visible = true;
            }
        }

        private bool esClienteMostrador()
        {
            if (this.logica.remision.ClienteID == 0)
            {
                return true;
            }
            return false;
        }

        private void UtilizaNadro()
        {

            SIFModelo.Cliente clienteConvenio = new SIFNegocio.Clientes().ClientePorID(logica.remision.ClienteID);

            if (clienteConvenio != null)
            {
                if (clienteConvenio.Convenio == SIFModelo.Tipos.SiNo.SI)
                {
                   MessageBox.Show("No puede aplicar descuentos a clientes convenio");
                    return;
                }
            }


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
                String descuentosAplicados = "";
                foreach (var item in logica.RemisionDetalles)
                {
                    if (item.PorcentajeDescuento != 0)
                    {
                        //if(porcentajeDesAplicado < item.PorcentajeDescuento)
                        descuentosAplicados += item.Nombre1 + ": " + item.PorcentajeDescuento.ToString() + "%" + "\n";
                    }
                }
                if (descuentosAplicados != "")
                    if (System.Windows.Forms.DialogResult.No == MessageBox.Show("Existen productos con descuento, al aplicar los beneficios del Circulo de la Salud " +
                                                               "se perderán los siguientes:" + "\n \n" + descuentosAplicados + "\n \n" + "¿Desea continuar?",
                                                               "Descuento aplicado", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        return;

                this.nadro = new SIFModelo.WebServices.TarjetaNadro();
                this.nadro.NumeroTarjeta = frmNadro.TarjetaID;
                this.nadro.ClienteID = logica.remision.ClienteID;

                //revisar si la tarjeta es valida
                SIFNegocio.WebServices.NADRO wsNadro = new SIFNegocio.WebServices.NADRO();
                this.nadro.SesionID = wsNadro.GetLogin(SIFNegocio.Configuracion.Configuraciones.Nadro);
                if (string.IsNullOrEmpty(this.nadro.SesionID))
                {
                    this.pictureBox1.Image = imageList1.Images[1];
                    return;
                }

                string respuesta = wsNadro.GetInfoCard(nadro.SesionID, nadro.NumeroTarjeta);
                nadro.Respuesta = respuesta;
                if (string.IsNullOrEmpty(respuesta))
                {
                    this.pictureBox1.Image = imageList1.Images[1];
                    //MessageBoxEx.Show("Tarjeta no válida o inactiva");

                    SIFModelo.Cliente cliente = new SIFModelo.Cliente(); //new SIFNegocio.Clientes().ClientePorID(logica.remision.ClienteID);
                    SIFModelo.DireccionCliente dircliente = new SIFModelo.DireccionCliente();
                    //dircliente.
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

                        respuesta = wsNadro.GetInfoCard(nadro.SesionID, nadro.NumeroTarjeta);
                        nadro.Respuesta = respuesta;

                        this.logica.remision.TarjetaID = frmNadro.TarjetaID;
                        logica.remision.ProveedorBeneficio = PROVEEDOR_NADRO;

                        this.statusLabel.Text = "BENEFICIO CIRCULO SALUD: " + respuesta + " [" + logica.remision.TarjetaID + "]";
                        this.pictureBox1.Image = imageList1.Images[0];
                        ConsultarWebServiceButtonX.Visible = true;
                    }
                    else
                    {
                        this.nadro = null;
                        this.statusLabel.Text = "";
                        this.pictureBox1.Image = imageList1.Images[1];
                    }
                }
                else
                {
                    this.logica.remision.TarjetaID = frmNadro.TarjetaID;
                    logica.remision.ProveedorBeneficio = PROVEEDOR_NADRO;

                    this.statusLabel.Text = "BENEFICIO CIRCULO SALUD: " + respuesta + " [" + logica.remision.TarjetaID + "]";
                    this.pictureBox1.Image = imageList1.Images[0];
                    ConsultarWebServiceButtonX.Visible = true;
                }
            }
        }

        private void LimpiaVenta()
        {
            if (this.convertidaDe == null)
            {
                this.logica.remision = new SIFModelo.Remision();
                logica.remision.DescuentoID = 0;
                this.logica.RemisionDetalles.Clear();
                logica.remision.Factura = SIFModelo.Tipos.SiNo.NO;
                this.conFacturaCheckBox.Checked = false;
                logica.remision.TipoClienteID = 3;
                logica.remision.Receta = SIFModelo.Tipos.SiNo.NO;
                //this.conRecetaCheckBox.Checked = false;
                this.logica.remision.SucursalID = Helpers.Sesion.Sucursal.SucursalID;
                logica.remision.TarjetaID = "";

                this.clienteLabelX.Text = "0";
                this.nombreClienteLabelX.Text = "PUBLIC EN GENERAL";
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
            ClienteSub = null;
            pVale = null;
            buttonvale.Visible = false;
            creditoRadioButton.Checked = false;
            creditoRadioButton.Enabled = true;

            descuentoCredencialButtonItem.Visible = true;
            tiempoAireButtonItem.Visible = true;
            pfizerButtonItem.Visible = true;
            nadroButtonItem.Visible = true;
            ConsultarWebServiceButtonX.Visible = false;
            beneficiosConsultado = false;
            int numRemision;
            logica.remision.NumeroRemision = logica.FolioRemision(Helpers.Sesion.Sucursal.SucursalID, out numRemision);
            this.folioVentaLabelX.Text = "Nuevo";

            this.pictureBox1.Visible = false;
            if (this.nadro != null)
            {
                nadro = null;
            }
            if (pfizer == null)
            {
                pfizer = null;
            }
            this.beneficioNotifiado = false;
            this.beneficiosConsultado = false;

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
            pVale = null;
            this.dataGrid.DataSource = logica.RemisionDetalles;

            controladoButtonItem.Enabled = false;

            this.articulosFaltantes.Clear();

            Ventas.VentaUsuarioForm frmUsuario = new VentaUsuarioForm();
            if (frmUsuario.ShowDialog() != DialogResult.OK)
            {
                this.Back();
                return;
            }
            logica.remision.VendedorID = frmUsuario.Usuario.UsuariosID;
            this.cajero = frmUsuario.Usuario;
            //this.vendedorLabelX.Text = cajero.Nombre + " " + cajero.Apellidos;
            this.vendedorLabelX.Text = Helpers.Sesion.UsuarioSeleccionadoVenta.Nombre;
            this.contadoRadioButton.Checked = true;
            this.dataGrid.Columns["CODIGO_CLIColumn"].Visible = false;
            this.recetaa = new SIF.View.Ventas.RecetaForm();
            this.DDerechoh = new SIF.View.Ventas.DatosDerechohabiente();
            this.DMedicos = new SIF.View.Ventas.DatosMedico();
            this.hup = new SIFNegocio.clienteHUP();
            this.hup2 = new SIFModelo.cliente_Hup();
        }

        private Boolean beneficioNotifiado = false;
        private void Guardar()
        {
            logica.remision.FechaVenta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            if ((ClienteSub != null) & (pVale == null))
            {
               MessageBox.Show("Agregue vale del cliente");
                Vale();
                if (pVale == null)
                    return;
            }

            if (logica.remision.ClienteID == 18)
            {
               MessageBox.Show("Agregue datos de la poliza");
                clienteEspecial(logica.remision.NumeroRemision, logica.remision.ClienteID, logica.remision.FechaVenta);
            }




            if (logica.remision.ProveedorBeneficio == PROVEEDOR_NADRO)
            {
                if (!this.beneficiosConsultado)
                {
                    DialogResult res =MessageBox.Show("¿Consultar los beneficios del proveedor CIRCULO DE LA SALUD?", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Question);

                    //if (res == DialogResult.Yes)
                    //{
                    this.ConsultaBeneficiosProveedor();
                    return;
                    //}
                }
            }


            if (logica.remision.ProveedorBeneficio == PROVEEDOR_PFIZER)
            {
                if (!this.beneficiosConsultado)
                {
                    DialogResult res =MessageBox.Show("¿Consultar los beneficios del proveedor PFIZER?", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Question);

                    //if (res == DialogResult.Yes)
                    //{
                    this.ConsultaBeneficiosProveedor();
                    return;
                    //}
                }
            }

            if (creditoRadioButton.Checked)
            {
                SIFModelo.Cliente clienteCredito = new SIFNegocio.Clientes().ClientePorID(this.logica.remision.ClienteID);

                if ((clienteCredito.Convenio == SIFModelo.Tipos.SiNo.NO) & (clienteCredito.SUBROGACION == SIFModelo.Tipos.SiNo.NO))
                {
                   MessageBox.Show("El cliente no puede tener crédito");
                    return;
                }
            }


            this.CalculaTotal();

            if (this.VerificaInventario())
            {
                return;
            }

            if (logica.RemisionDetalles.Count <= 0)
            {
               MessageBox.Show("Agregue por lo menos un artículo");
                return;
            }
            int numRemision = 0;

            if (this.creditoRadioButton.Checked)
            {
                if (this.esClienteMostrador())
                {
                   MessageBox.Show("Debe elegir el cliente de crédito");
                    return;
                }
            }

            //logica.remision.FechaVenta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            logica.remision.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
            logica.remision.MonedaID = 1;
            logica.remision.TipoCambio = 1;
            logica.remision.NumeroRemision = logica.FolioRemision(Helpers.Sesion.Sucursal.SucursalID, out numRemision);
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
                        frmIngresa.usuarioID = logica.remision.VendedorID;
                        if (frmIngresa.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }

                        detalle.OFolioControlado = frmIngresa.FolioControlado;
                        this.controladoButtonItem.Enabled = true;
                    }

                    //REVISAR SI EL FOLIO CONTROLADO CONTIENE EL DETALLE Y LA CANTIDAD ESPECIFICADA
                    //string CveClisub = detalle.ArticuloID;

                    //if (ClienteSub != null)
                    //{
                    //    SIFModelo.Articulo art = new SIFNegocio.Articulo().BuscarPorClaveSub(detalle.ArticuloID, ClienteSub.ID.ToString());
                    //    CveClisub = art.ARTICULO_ID;
                    //    detalle.ArticuloID = art.CODIGO_CLI;
                    //}

                    var folioControlado = from c in detalle.OFolioControlado.Detalles where c.ArticuloID == detalle.ArticuloID select c;



                    if (folioControlado.Count() == 0)
                    {

                       MessageBox.Show("El artículo no esta dado de alta en el folio controlado");
                        return;
                    }

                    SIFModelo.ControladoDetalle controladoDetalle = folioControlado.First();

                    detalle.CantidadRemision = controladoDetalle.Cantidad;

                    //if (ClienteSub != null)
                    //{
                    //    detalle.ArticuloID = CveClisub;
                    //}
                }
            }

            //COMO ES CONTROLADO 
            if (conReceta)
            {
                //if (this.receta == null)
                //{
                //   MessageBox.Show("Debe seleccionar el Médico que expide la receta");
                //    receta = new SIFModelo.Receta();
                //    Catalogos.MedicosUserControl frmMedicos = new Catalogos.MedicosUserControl();
                //    logica.remision.Receta = SIFModelo.Tipos.SiNo.SI;
                //    frmMedicos.Owner = this;
                //    frmMedicos.Muestra();
                //    return;
                //}
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
                foreach (SIFModelo.RemisionDetalle detalleC in contolados.ToList())
                {

                    if (detalleC.OFolioControlado == null)
                    {
                        View.Ventas.IngresaFolioControladoForm frmControlado = new IngresaFolioControladoForm();
                        frmControlado.usuarioID = logica.remision.VendedorID;
                        if (frmControlado.ShowDialog() != DialogResult.OK)
                        {
                           MessageBox.Show("Debe ingresar un folio controlado para finalizar la venta");
                            return;
                        }

                        detalleC.OFolioControlado = frmControlado.FolioControlado;
                        //VERIFICAMOS QUE LOS DETALLES ESTEN EN ESTE FOLIO CONTROLADO
                    }
                }

                //    foreach (SIFModelo.RemisionDetalle detalle in this.logica.RemisionDetalles)
                //    {
                //        if (detalle.FolioControlado == "SI")
                //        {
                //            var controladoDetalleEncontrado = from d in detalle.OFolioControlado.Detalles where d.ArticuloID == detalle.ArticuloID select d;

                //            if (controladoDetalleEncontrado.Count() == 0)
                //            {
                //               MessageBox.Show("El producto " + detalle.ArticuloID + " (" + detalle.Nombre1 + ") no esta dado de alta en el folio controlado", "Controlado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //                return;
                //            }

                //            SIFModelo.ControladoDetalle controladoDetalle = controladoDetalleEncontrado.First();

                //            if (controladoDetalle.Cantidad != detalle.CantidadRemision)
                //            {
                //               MessageBox.Show("La cantidad a vender no corresponde a la cantidad dada de alta en el folio controlado para el artículo " + detalle.ArticuloID + " (" + detalle.Nombre1 + ")");
                //                return;
                //            }

                //        }
                //    }

            }

            SIFModelo.Cliente cliente = new SIFModelo.Cliente();
            cliente.Nombre = "PUBLICO EN GENERAL";
            cliente.ID = 0;
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
                logica.remision.Factura = SIFModelo.Tipos.SiNo.SI;
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
                    logica.remision.ClienteID = 0;
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
                //if (!beneficioNotifiado)
                //{

                //}

                // logica.remision.VendedorID = Helpers.Sesion.UsuarioSeleccionadoVenta.UsuariosID;//colocar el vendedor que realiza la venta


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

                    pf.InsertaPfizer(pfizer, logica.RemisionDetalles, logica.remision);
                    logica.remision.Condiciones = "PFIZER";
                    logica.remision.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                    if (logica.RemisionDetalles.Sum(r => r.PiezasGratis) > 0 || logica.RemisionDetalles.Sum(r => r.PiezasAcumuladas) > 0)
                    {
                        // MessageBox.Show("Se encontraron beneficios para el cliente");

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

                        //if (!beneficioNotifiado)
                        //{
                        //    beneficioNotifiado = true;
                        //    return;
                        //}

                    }

                    //SI EL BENEFICIO YA FUE NOTIFICADO, ENTONCES REGISTRAR LA VENTA
                    //genera la lista de remisiones con costo cero

                }

            }

            if (this.tae != null)
            {
                logica.remision.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                logica.remision.Condiciones = "TAE";
                logica.remision.TipoClienteID = 6;
                logica.remision.ClienteID = 0;
                tae.Remision = logica.remision.NumeroRemision;
                tae.Fecha = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                string remision = tae.Remision.Substring(4);
                tae.Remision = remision;
                SIFNegocio.WebServices.TAE.Inserta(tae);
            }

            if (logica.remision.ProveedorBeneficio == PROVEEDOR_NADRO)
            { //GUARDAR EN LA TABLA CTL_NADRO Y NADRO_DET
                logica.remision.Condiciones = PROVEEDOR_NADRO;
                logica.remision.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                SIFNegocio.WebServices.NADRO nadrol = new SIFNegocio.WebServices.NADRO();

                SIFModelo.WebServices.Nadro modeloNadro = new SIFModelo.WebServices.Nadro();
                modeloNadro.Activo = SIFModelo.Tipos.SiNo.SI;
                modeloNadro.CadenaID = int.Parse(SIFNegocio.Configuracion.Configuraciones.Nadro.Cadena);
                modeloNadro.CedulaProfesionalMedico = "";
                modeloNadro.CotizacionID = nadro.SesionID;
                modeloNadro.FechaCompra = logica.remision.FechaVenta;
                modeloNadro.FechaConfirmacion = new DateTime();
                modeloNadro.NumeroConfirmacion = "0";
                modeloNadro.NumeroRemision = logica.remision.NumeroRemision;
                modeloNadro.NumeroTarjeta = nadro.NumeroTarjeta;
                modeloNadro.SucursalID = Helpers.Sesion.Sucursal.SucursalesID;
                modeloNadro.UsuarioID = logica.remision.VendedorID;
                modeloNadro.FechaCompra = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

                List<SIFModelo.WebServices.NadroDetalle> detallesNadro = new List<SIFModelo.WebServices.NadroDetalle>();
                foreach (var detalle in logica.RemisionDetalles)
                {

                    //if (detalle.BeneficioProveedor == SIFModelo.Tipos.SiNo.SI)
                    //{
                    if (detalle.PiezasGratis > 0 || detalle.PrecioDescontado != detalle.Precio)
                    {
                        SIFModelo.WebServices.NadroDetalle nadroD = new SIFModelo.WebServices.NadroDetalle();

                        SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);

                        nadroD.ArticuloID = detalle.ArticuloID;
                        nadroD.CantAcumNadro = detalle.PiezasAcumuladas;
                        nadroD.CantPagarNadro = detalle.PiezasPagadas;
                        nadroD.CantRegaloNadro = detalle.PiezasGratis;
                        nadroD.CotizacionID = modeloNadro.CotizacionID;
                        nadroD.IVA = detalle.IVA;
                        nadroD.PorcentajeIVA = detalle.PorcentajeIVA;
                        nadroD.MontoDesctoNadro = detalle.MontoDescuento;
                        nadroD.NumeroRemision = modeloNadro.NumeroRemision;
                        nadroD.Partida = detalle.NumeroPartida;
                        nadroD.PorcenDesctoNadro = (double)detalle.PorcentajeDescuento;
                        nadroD.PrecDesctoNadro = detalle.TipoPrecioDescuento;
                        nadroD.Precio = precios.PRECIO_VENTA; //precio pos
                        nadroD.PrecioFijo = detalle.PrecioProveedor; //precio fijo regresado por el service
                        nadroD.PrecioMaximo = precios.PRECIO_VENTA_MAX;
                        //nadroD.REFERENCIA = ;

                        detallesNadro.Add(nadroD);

                        detalle.ReferenciaNADRO = nadro.SesionID;
                    }
                    //}
                }
                nadrol.InsertaControl(modeloNadro, detallesNadro);
            }

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
                detalle.DescuentoID = logica.remision.DescuentoID;
                detalle.NumeroPartida = numeroPartida;

                if (this.logica.remision.ProveedorBeneficio == PROVEEDOR_PFIZER)
                {
                    detalle.CantidadRemision = detalle.PiezasPagadas + detalle.PiezasGratis; // - detalle.PiezasGratis;
                }


                if (this.logica.remision.ProveedorBeneficio == PROVEEDOR_NADRO)
                {
                    detalle.CantidadRemision = detalle.PiezasPagadas; // - detalle.PiezasGratis;
                }

                //detalle.ImpuestoID = 
                numeroPartida++;
            }

            var detalleGratis = from d in logica.RemisionDetalles where d.PiezasGratis > 0 | d.PiezasAcumuladas > 0 select d;

            foreach (var detalle in detalleGratis.ToList())
            {
                SIFModelo.RemisionDetalle detalleg = new SIFModelo.RemisionDetalle();
                detalleg.ArticuloID = detalle.ArticuloID;
                detalleg.BeneficioProveedor = detalle.BeneficioProveedor;
                detalleg.Caducidad = detalle.Caducidad;
                detalleg.CantidadRemision = detalle.PiezasGratis;
                
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

                if (logica.remision.ProveedorBeneficio == PROVEEDOR_NADRO)
                {
                    detalleg.Nombre1 = "REGALO C.S. " + detalle.Nombre1;

                }

                if (logica.remision.ProveedorBeneficio == PROVEEDOR_PFIZER)
                {
                    detalleg.Nombre1 = "REGALO PFIZER " + detalle.Nombre1;

                }

                detalleg.Nombre2 = detalle.Nombre2;
                detalleg.NumeroRemision = detalle.NumeroRemision;
                detalleg.PaqueteID = detalle.PaqueteID;
                detalleg.PiezasAcumuladas = 0;
                detalleg.PiezasGratis = 0;
                detalleg.PorcentajeDescuento = 0;
                detalleg.Total = 0;
                detalleg.PiezasPagadas = 0;
                detalleg.NumeroPartida = numeroPartida;
                numeroPartida++;
                string sku = detalleg.ArticuloID;
                bool encontrado = false;
                foreach (var row in detalleGratis)
                {
                    if (sku == row.ArticuloID && row.PiezasPagadas == 0)
                    { 
                        encontrado = true;
                        detalle.Nombre1 = "REGALO C.S. " + detalle.Nombre1;
                        detalle.CantidadRemision = detalle.PiezasGratis;
                    }
                }
                if (encontrado == false)
                {
                    
                    logica.RemisionDetalles.Add(detalleg);
                }
                
            }

            logica.remision.NumeroRemision = logica.FolioRemision(Helpers.Sesion.Sucursal.SucursalID, out numRemision);
            logica.InsertaFolioRemision(Helpers.Sesion.Sucursal.SucursalID, numRemision);

            logica.remision.TipoCambio = this.contadoRadioButton.Checked ? 0 : 1;

            if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
            {
                if (cliente.SUBROGACION == SIFModelo.Tipos.SiNo.SI)
                    logica.remision.TipoClienteID = 5;
                else
                    logica.remision.TipoClienteID = 2;
            }
            else
            {
                if (cliente.SUBROGACION == SIFModelo.Tipos.SiNo.SI)
                    logica.remision.TipoClienteID = 5;
                else
                    logica.remision.TipoClienteID = 3;
            }


            if (tae != null)
            {
                logica.remision.TipoClienteID = 6;
            }

            //LGS 10/02/2014 Para guardar las notas que aplican descuento de lista {INSEN,LOGO FLEMING, TRABAJADOR, ...}
            if (logica.remision.ProveedorBeneficio != PROVEEDOR_NADRO && logica.remision.ProveedorBeneficio != PROVEEDOR_PFIZER && this.tae == null)//Solo aplicamos a aquellas que no son NADRO,TAE,PFIZER
            {
                logica.remision.Condiciones = logica.remision.Condiciones + " " + logica.remision.ProveedorBeneficio + " " + logica.remision.PorcentajeDescuento;
                logica.remision.Condiciones = logica.remision.Condiciones.Trim();
                if (logica.remision.Condiciones == "0")
                    logica.remision.Condiciones = "";
                if (logica.remision.Condiciones.Length > 19)
                    logica.remision.Condiciones = logica.remision.Condiciones.Substring(0, 19);
            }

            if (logica.remision.ProveedorBeneficio == PROVEEDOR_PFIZER)
                foreach (var detalle in logica.RemisionDetalles.ToList())
                    detalle.CantidadRemision = detalle.CantidadRemision - detalle.PiezasGratis;

            if (!logica.GuardaRemision(logica.remision, logica.RemisionDetalles, ClienteSub))
            {
                //GUARDAMOS LOS BENEFICIOS DE LA VENTA
                if (logica.remision.Condiciones == PROVEEDOR_PFIZER)
                {
                    //GUARDAMOS EN CTL PFIZER
                    SIFNegocio.WebServices.PFIZER pfL = new SIFNegocio.WebServices.PFIZER();

                }
               MessageBox.Show("Ha ocurrido un error al generar la venta");
                return;
            }
            if (ClienteSub != null || pVale != null)
            {
                //guardamos el vale
                pVale.NoRemision = logica.remision.NumeroRemision;
                SIFNegocio.ValeSubrogacion ValeL = new SIFNegocio.ValeSubrogacion();
                pVale = ValeL.Nuevo(pVale);
                if (pVale.ID == 0)
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

            hup2 = hup.Buscar(logica.remision.ClienteID.ToString());
            if (hup2 != null)
            {
                if (logica.remision.ClienteID == hup2.cliente_id)
                {

                    //clienteEspecial(logica.remision.NumeroRemision, logica.remision.ClienteID, logica.remision.FechaVenta);
                    clienteHospital(logica.remision.NumeroRemision, logica.remision.FechaVenta);

                    /* recetaa = new SIF.View.Ventas.RecetaForm();
                     DDerechoh = new SIF.View.Ventas.DatosDerechohabiente();
                     DMedicos = new SIF.View.Ventas.DatosMedico();
                     hup = new SIFNegocio.clienteHUP();
                     hup2 = new SIFModelo.cliente_Hup();*/
                }
            }
            SIFNegocio.Remision.ImprimeTicket(logica.remision, logica.RemisionDetalles, Helpers.Sesion.Sucursal, Helpers.Sesion.UsuarioSeleccionadoVenta, cliente, nadro);

            SIF.funciones.Bitacora("Guardo nota:" + logica.remision.NumeroRemision.ToString(), 1, 5);
            ////this.reportarFaltantes();

            this.LimpiaVenta();
        }

        private bool VerificaInventario()
        {
            SIFNegocio.Inventario.Inventario inventarioL = new SIFNegocio.Inventario.Inventario();
            foreach (var detalle in logica.RemisionDetalles)
            {
                SIFModelo.Articulo articulo;
                if (ClienteSub == null)
                    articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
                else
                    if (ClienteSub.PRECIO_FIJO == SIFModelo.Tipos.SiNo.SI)
                        articulo = new SIFNegocio.Articulo().BuscarPorClaveSub(detalle.CODIGO_CLI, detalle.ArticuloID, ClienteSub.ID.ToString());
                    else
                        articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.CODIGO_CLI);
                articulo.NOMBRE1 = detalle.Nombre1;
                int existencias = 0;

                if (logica.remision.ProveedorBeneficio == PROVEEDOR_PFIZER || logica.remision.ProveedorBeneficio == PROVEEDOR_NADRO)
                {
                    if (inventarioL.InventarioArticulo(articulo, detalle.PiezasPagadas + detalle.PiezasGratis, out existencias, ClienteSub))
                    {
                        //MessageBoxEx.Show("Inventario insuficiente para el artículo "  + detalle.Nombre1 + " ["+detalle.ArticuloID+"]");
                        return false;
                    }
                    return true;
                }
                else
                {
                    if (inventarioL.InventarioArticulo(articulo, detalle.CantidadRemision, out existencias, ClienteSub))
                    {
                        //MessageBoxEx.Show("Inventario insuficiente para el artículo "  + detalle.Nombre1 + " ["+detalle.ArticuloID+"]");
                        return false;
                    }
                }
            }

            return true;
        }

        private void ConsultaBeneficiosProveedor()
        {
            if (!quitaDuplicados())
            {
                return;
            }

            DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle beneficioRowStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
            beneficioRowStyle.Background.Color1 = Color.FromArgb(255, 221, 227);
            beneficioRowStyle.Background.Color2 = Color.FromArgb(255, 221, 227);

            DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle descuentoRowStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
            descuentoRowStyle.Background.Color1 = Color.FromArgb(200, 100, 100);
            descuentoRowStyle.Background.Color2 = Color.FromArgb(200, 100, 100);


            #region NADRO
            if (this.logica.remision.ProveedorBeneficio == PROVEEDOR_NADRO)
            {
                //if (logica.remision.ClienteID == 0)
                //{
                //    logica.remision.ClienteID = 0;
                //}
                this.nadro.ClienteID = logica.remision.ClienteID;

                SIFNegocio.WebServices.NADRO nadro = new SIFNegocio.WebServices.NADRO();
                nadro.ProcesaVenta(logica.remision, logica.RemisionDetalles, SIFNegocio.Configuracion.Configuraciones.Nadro, this.nadro);

                //if (logica.RemisionDetalles.Sum(r => r.PiezasGratis) > 0 || logica.RemisionDetalles.Sum(r => r.PiezasAcumuladas) > 0 || logica.RemisionDetalles.Sum(r => r.MontoDescuento) > 0 || logica.RemisionDetalles.Sum(r => r.PorcentajeDescuento) > 0)
                //{
               MessageBox.Show("Revise los beneficios para el cliente");
                this.beneficiosConsultado = true;
                this.quitaDuplicados();
                dataGrid.DataSource = logica.RemisionDetalles;
                superGridControl1.Refresh();
                foreach (GridRow row in dataGrid.Rows)
                {
                    SIFModelo.RemisionDetalle det = row.DataItem as SIFModelo.RemisionDetalle;

                    //if (det.MontoDescuento > 0)
                    //{
                    //    row.CellStyles.Default = descuentoRowStyle;
                    //    row.RowStyles.Default.ApplyStyle(descuentoRowStyle);
                    //}

                    //SI SUGERIDO
                    if (det.PiezasAcumuladas > 0)
                    {

                    }
                   
                    //SI BENEFICIO
                    if (det.PiezasGratis > 0)
                    {
                        row.CellStyles.Default = beneficioRowStyle;
                        row.RowStyles.Default.ApplyStyle(beneficioRowStyle);
                        det.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                    }

                    if (det.PrecioDescontado != det.Precio || det.PorcentajeDescuento > 0)
                    {
                        row.CellStyles.Default = beneficioRowStyle;
                        row.RowStyles.Default.ApplyStyle(beneficioRowStyle);
                        det.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                    }
                   
                }
                
                this.CalculaTotal();

                if (!beneficioNotifiado)
                {
                    beneficioNotifiado = true;
                    return;
                }


                //}

            }
            #endregion



            #region Pfizer
            if (this.logica.remision.ProveedorBeneficio == PROVEEDOR_PFIZER)
            {
                //if (logica.remision.ClienteID == 0)
                //{
                //    logica.remision.ClienteID = 0;
                //}
                this.pfizer.ClienteID = logica.remision.ClienteID;

                SIFNegocio.WebServices.PFIZER pfizer = new SIFNegocio.WebServices.PFIZER();
                SIFModelo.WebServices.TarjetaPfizer tarjeta = new SIFModelo.WebServices.TarjetaPfizer();
                tarjeta.TarjetaID = logica.remision.TarjetaID;
                List<SIFModelo.RemisionDetalle> beneficiosPfizer = pfizer.ProcesaVenta(tarjeta, logica.RemisionDetalles, logica.remision);
                this.statusLabel.Text = "SESION: " + tarjeta.SesionID;
                if (beneficiosPfizer == null)
                {
                    this.beneficiosConsultado = false;
                    return;
                }

                if (beneficiosPfizer.Count <= 0)
                {
                    return;
                }
               MessageBox.Show("Revise los beneficios para el cliente");
                this.beneficiosConsultado = true;

                foreach (GridRow row in dataGrid.Rows)
                {
                    SIFModelo.RemisionDetalle det = row.DataItem as SIFModelo.RemisionDetalle;

                    //if (det.MontoDescuento > 0)
                    //{
                    //    row.CellStyles.Default = descuentoRowStyle;
                    //    row.RowStyles.Default.ApplyStyle(descuentoRowStyle);
                    //}

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
                    CalculaTotal();
                }
            }

            #endregion
        }


        public void reportarFaltantes()
        {
            if (this.articulosFaltantes.Count > 0)
            {
                SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(this.logica.remision.VendedorID);



                View.Ventas.FaltantesForm frmFaltantes = new FaltantesForm(usuario, this.articulosFaltantes);
                this.articulosFaltantes.Clear();
                // frmFaltantes.ShowDialog();
            }
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

                /*  if (this.articulosFaltantes.Count > 0)
                  {
                      DialogResult dres =MessageBox.Show("Hay faltantes a reportar, ¿desea reportarlos?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                      if (dres == DialogResult.Yes)
                      {
                          this.reportarFaltantes();
                      }
                  }*/

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

            TiempoAireTelcelForm frmTiempoAire = new TiempoAireTelcelForm();
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
            logica.remision.TipoClienteID = 3;
            this.Guardar();


        }

        private void TiempoAireMultiRecargas()
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
            detalle.Nombre1 = frmTiempoAire.articulo.Referencia + ": " + frmTiempoAire.articulo.Telefono;
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


            if (cliente.Activo == SIFModelo.Tipos.SiNo.NO)
            {
               MessageBox.Show("El cliente ya no está activo");
                return;
            }
            if (cliente.Boletinado == SIFModelo.Tipos.SiNo.SI)
            {
               MessageBox.Show("El cliente está boletinado");
                return;
            }

            ClienteSub = null;
            ConvenioCliente = null;
            statusLabel.Text = "";

            this.logica.remision.ClienteID = cliente.ID;

            this.clienteLabelX.Text = cliente.ID.ToString();

            hup2 = hup.Buscar(cliente.ID.ToString());
            if (hup2 != null)
            {
                //SIF.View.Ventas.RecetaForm receta = new SIF.View.Ventas.RecetaForm();
                //Cliente18Form cliente = new Cliente18Form(NUMREMISION, ClienteE, FECHA);
                //receta.ShowDialog()
                if (recetaa.ShowDialog() == DialogResult.OK)
                {
                    //     SIF.View.Ventas.DatosDerechohabiente DDerechoh = new SIF.View.Ventas.DatosDerechohabiente();
                    if (DDerechoh.ShowDialog() == DialogResult.OK)
                    {
                        string a = DDerechoh.IDDR.IDBnf;
                        string b = recetaa.tipo;
                        // DatosMedico
                        if (DMedicos.ShowDialog() == DialogResult.OK)
                        {
                            //string a = DDerechoh.IDDR.IDBnf;
                            //  string b = recetaa.tipo;
                            // DatosMedico
                            // MessageBox.Show("Dijiste ok");
                        }
                        else
                            return;
                    }
                    else
                        return;
                    //MessageBoxEx.Show("Debes proporcionar los datos solicitados.", "Axa Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //clienteEspecial(NUMREMISION, ClienteE, FECHA);
                    //return;
                }
                else
                    return;
                // this.Back();

            }


            if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
            {
                logica.remision.ProveedorBeneficio = "CONVENIO";

                ConvenioCliente = clienteN.ClientePorID(cliente.ID);

                if (ConvenioCliente == null)
                {
                   MessageBox.Show("No hay datos de cliente convenio");
                    return;
                }

                Descuento = ConvenioCliente.PorDesc;
                PorScosto = ConvenioCliente.PorScosto;

                foreach (SIFModelo.RemisionDetalle articulo in this.logica.RemisionDetalles)
                {
                    this.PrecioArticulo(articulo);
                }


                if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI && cliente.SUBROGACION == SIFModelo.Tipos.SiNo.NO)
                {
                    conFacturaCheckBox.Checked = true;
                }

                // CalculaTotal();

                this.statusLabel.Text = "DESCUENTO CONVENIO " + Descuento + "%";
            }
            // checamos si el cliente es subrogacion

            if (cliente.SUBROGACION == SIFModelo.Tipos.SiNo.SI)
            {
                logica.remision.ProveedorBeneficio = "SUBROGACION";

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
                    this.logica.RemisionDetalles.Clear();
                }
                else
                {
                    Descuento = ClienteSub.PorDesc;
                    PorScosto = ClienteSub.PorScosto;
                }

                if (ClienteSub.CondicionVenta == SIFModelo.Tipos.CondicionVenta.CREDITO)
                {

                    creditoRadioButton.Enabled = false;
                    creditoRadioButton.Checked = true;
                    contadoRadioButton.Enabled = false;

                    //conFacturaCheckBox.Checked = true;
                }


                descuentoCredencialButtonItem.Visible = false;
                tiempoAireButtonItem.Visible = false;
                pfizerButtonItem.Visible = false;
                nadroButtonItem.Visible = false;
                buttonvale.Visible = true;
                if (ClienteSub.REQ_LOTE == SIFModelo.Tipos.SiNo.SI)
                    loteCaducidadCheckBox.Checked = true;


                this.statusLabel.Text = "CLIENTE SUBROGACION " + Descuento + "%";

                this.dataGrid.Columns["CODIGO_CLIColumn"].Visible = true;
            }
            else
            {
                creditoRadioButton.Checked = false;
                creditoRadioButton.Enabled = true;
                contadoRadioButton.Enabled = true;
                descuentoCredencialButtonItem.Visible = true;
                tiempoAireButtonItem.Visible = true;
                pfizerButtonItem.Visible = true;
                nadroButtonItem.Visible = true;
            }

            if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
            {
                logica.remision.ProveedorBeneficio = "CONVENIO";

                ConvenioCliente = clienteN.ClientePorID(cliente.ID);

                Descuento = ConvenioCliente.PorDesc;
                PorScosto = ConvenioCliente.PorScosto;

                this.statusLabel.Text = "DESCUENTO CONVENIO " + Descuento + "%";
                if (ConvenioCliente.CondicionVenta == SIFModelo.Tipos.CondicionVenta.CREDITO)
                {
                    creditoRadioButton.Enabled = false;
                    creditoRadioButton.Checked = true;
                    contadoRadioButton.Enabled = false;
                }

                if (ConvenioCliente.CondicionVenta == SIFModelo.Tipos.CondicionVenta.EFECTIVO)
                {
                    creditoRadioButton.Enabled = false;
                    contadoRadioButton.Checked = true;
                    contadoRadioButton.Enabled = false;
                }

            }
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
            this.CalculaTotal();
        }


        #endregion

        #region Navegación de Ventana

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            cotizacionInstantaneaButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
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
            cotizacionInstantaneaButtonItem.Shortcuts.Clear();
            seleccionaClienteButtonItem.Shortcuts.Clear();
            guardarButtonItem.Shortcuts.Clear();
            cancelarButtonItem.Shortcuts.Clear();
        }

        private void Back()
        {
            try
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

                    if (this.articulosFaltantes.Count > 0)
                    {
                        //DialogResult dres =MessageBox.Show("Hay faltantes a reportar, ¿desea reportarlos?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //if (dres == DialogResult.Yes)
                        //{
                        this.reportarFaltantes();
                        //}
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
        {//que muestre los items al darle click
            //tiempoAireButtonItems = true;
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

            logica.remision.DescuentoID = 0;
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
                this.beneficiosConsultado = false;
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
                this.CodigoTextBoxX.SelectAll();
                this.CodigoTextBoxX.Focus();
                cantidadTextBoxX.Text = "1";
                this.beneficiosConsultado = false;
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
            if (quitaDuplicados())
                this.UtilizaPfizer();
        }

        private void nadroButtonItem_Click(object sender, EventArgs e)
        {
            if (quitaDuplicados())
                this.UtilizaNadro();
        }

        private bool quitaDuplicados()
        {
            List<SIFModelo.RemisionDetalle> detallesRepetidos = new List<SIFModelo.RemisionDetalle>();

            bool existenRepetidos = false;

            foreach (SIFModelo.RemisionDetalle detalle in logica.RemisionDetalles)
            {
                var encontrado = from d in detallesRepetidos where d.ArticuloID == detalle.ArticuloID select d;
                if (encontrado.Count() > 0)
                {
                    existenRepetidos = true;

                    continue;
                }

                detallesRepetidos.Add(detalle);
            }

            if (existenRepetidos)
            {
                var msgBox =MessageBox.Show("Se quitarán los artículos duplicados", "Benficio proveedor", MessageBoxButtons.YesNo);

                if (msgBox == DialogResult.No)
                {
                    return false;
                }


                detallesRepetidos = new List<SIFModelo.RemisionDetalle>();
                List<SIFModelo.RemisionDetalle> noRepetidos = new List<SIFModelo.RemisionDetalle>();
                foreach (SIFModelo.RemisionDetalle detalle in logica.RemisionDetalles)
                {
                    var encontrado = from d in noRepetidos where d.ArticuloID == detalle.ArticuloID select d;
                    if (encontrado.Count() > 0)
                    {
                        detallesRepetidos.Add(detalle);
                        continue;
                    }
                    noRepetidos.Add(detalle);
                }

                foreach (SIFModelo.RemisionDetalle detalle in detallesRepetidos)
                {
                    logica.RemisionDetalles.Remove(detalle);
                }

                this.dataGrid.DataSource = logica.RemisionDetalles;
                CalculaTotal();
            }

            return true;
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
                this.beneficiosConsultado = false;
                if (e.GridPanel.ActiveRow == null)
                {
                    return;
                }

                GridIntegerInputEditControl integerInput = e.EditControl as GridIntegerInputEditControl;

                SIFModelo.RemisionDetalle detalle = (SIFModelo.RemisionDetalle)((GridRow)e.GridPanel.ActiveRow).DataItem;

                SIFModelo.Articulo articulo = new SIFModelo.Articulo() { ARTICULO_ID = detalle.ArticuloID };
                if (ClienteSub != null)
                {
                    SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
                    articulo = articuloL.BuscarPorClaveSub(detalle.ArticuloID, null, ClienteSub.ID.ToString());
                }

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

        // SIFModelo.Receta receta;
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

        private void cantidadTextBoxX_Enter(object sender, EventArgs e)
        {
            this.cantidadTextBoxX.SelectAll();
        }

        private void CodigoTextBoxX_Enter(object sender, EventArgs e)
        {
            this.CodigoTextBoxX.SelectAll();
        }

        private bool beneficiosConsultado = false;
        private void ConsultarWebServiceButtonX_Click(object sender, EventArgs e)
        {
            this.ConsultaBeneficiosProveedor();
        }

        private void taeButtonItem_Click(object sender, EventArgs e)
        {
            this.TiempoAire();
        }

        private void multiRecargasButtonItem_Click(object sender, EventArgs e)
        {
            this.TiempoAireMultiRecargas();
        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (!this.Cancelar())
                {
                    e.Handled = true;
                }
            }

            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }
        }

        private void Vale()
        {
            ValeSubrogacionForm Vale = new ValeSubrogacionForm();

            if (Vale.ShowDialog() != DialogResult.OK)
            {
               MessageBox.Show("Debe dar un vale del cliente", "Vale Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                pVale = Vale.Vale;
            }

        }
        private void clienteEspecial(string NUMREMISION, int ClienteE, DateTime FECHA)
        {
            Cliente18Form cliente = new Cliente18Form(NUMREMISION, ClienteE, FECHA);

            if (cliente.ShowDialog() != DialogResult.OK)
            {
               MessageBox.Show("Debes proporcionar los datos solicitados.", "Axa Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clienteEspecial(NUMREMISION, ClienteE, FECHA);
            }
            // else
            // {
            //     return;
            // }

        }

        private void clienteHospital(string NUMREMISION, DateTime FECHA)
        {
            // Cliente18Form cliente = new Cliente18Form(NUMREMISION, ClienteE, FECHA);

            SIFModelo.hupDReceta DatosReceta = new SIFModelo.hupDReceta();

            DatosReceta.Num_remision = NUMREMISION;
            DatosReceta.Receta = recetaa.Noreceta;
            DatosReceta.FechaS = FECHA.ToString();
            DatosReceta.FechaR = recetaa.fechaReceta.ToString();
            DatosReceta.Id_med = DMedicos.IDMD.IDmed.ToString();
            DatosReceta.Id_pac = DDerechoh.IDDR.IDBnf.ToString();
            DatosReceta.meses = (DDerechoh.ttrat.ToString() + " " + DDerechoh.lapso);
            DatosReceta.Tipo = recetaa.tipo;
            SIFNegocio.ListDerechohabientes guardaReceta = new SIFNegocio.ListDerechohabientes();
            guardaReceta.guardaR(DatosReceta);
        }
        private void buttonvale_Click(object sender, EventArgs e)
        {
            Vale();
        }

        private void creditoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (creditoRadioButton.Checked)
            {
                if (esClienteMostrador())
                {
                   MessageBox.Show("El cliente mostrador no puede tener crédito");

                    contadoRadioButton.Checked = true;
                    creditoRadioButton.Checked = false;
                }
            }
        }

    }
}
