using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SIF.View.OrdenCompra
{
    public partial class AsignacionPreciosOrdenCompraDetallesUserControl : Templates.ListaUserControl
    {
        public AsignacionPreciosOrdenCompraDetallesUserControl Ownern;

        public AsignacionPreciosOrdenCompraDetallesUserControl()
        {
            InitializeComponent();
            this.EstableceOrdenCompra();
            this.desHabilita();
            this.superGridControl1.PrimaryGrid.AllowRowDelete = false;
            this.superGridControl1.PrimaryGrid.SelectionGranularity = SelectionGranularity.Cell;
        }


        public AsignacionPreciosOrdenCompraDetallesUserControl(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow ordenCompra)
        {
            this.OrdenCompra = ordenCompra;
            InitializeComponent();
            this.desHabilita();
            this.EstableceOrdenCompra();
            this.inicializaColoresFilas();
            this.superGridControl1.PrimaryGrid.AllowRowDelete = false;
            this.superGridControl1.PrimaryGrid.SelectionGranularity = SelectionGranularity.Cell;



            ////    recepcionMaximoPublicoTextBox.DataBindings.Add(new Binding("Text", preciosBindingSource, "PRECIO_MAXIMO", true, DataSourceUpdateMode.OnPropertyChanged,0,"0.00"));
            //recepcionFarmaciaTextBox.DataBindings.Add(new Binding("Text", preciosBindingSource, "PRECIO_FARMACIA", true, DataSourceUpdateMode.OnPropertyChanged, 0, "0.00"));
            ////recepcionDescuentoAdicionalTextBox.DataBindings.Add(new Binding("Text", preciosBindingSource, "PRECIO_FACTURA_MAX", true));
            //// ofertaFacturaTextBoxX.DataBindings.Add(new Binding("Text", preciosBindingSource, "PORC_OFERTA_FACTURA", true));

            //facturaMaximoPublicoTextBox.DataBindings.Add(new Binding("Text", preciosBindingSource, "PRECIO_FACTURA_MAX", true, DataSourceUpdateMode.OnPropertyChanged, 0, "0.00"));
            ////  recepcionMaximoPublicoTextBox.DataBindings.Add(new Binding("Text", preciosBindingSource, "PRECIO_FACTURA_MAX", true));

            //facturaFarmaciaTextBox.DataBindings.Add(new Binding("Text", preciosBindingSource, "PRECIO_FACTURA", true, DataSourceUpdateMode.OnPropertyChanged, 0, "0.00"));
            // recepcionFarmaciaTextBox.DataBindings.Add(new Binding("Text", preciosBindingSource, "PRECIO_FACTURA", true));
        }

        private void desHabilita()
        {
            if (OrdenCompra != null)
            {
                if (OrdenCompra.ESTADO_OC != "E")
                {
                    this.guardarButtonItem.Enabled = false;
                    //this.recibirButtonItem.Enabled = false;
                    preciosGroupBox.Enabled = false;
                }
            }
        }

        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle revisarRowStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyles revisarCellStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyles();//superGridControl1.DefaultVisualStyles.RowStyles;
        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle margenRowStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyles margenCellStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyles();//superGridControl1.DefaultVisualStyles.RowStyles;
        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle faltanteRowStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyles faltanteCellStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyles();//superGridControl1.DefaultVisualStyles.RowStyles;

        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle normalRowStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
        //DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyles normalCellStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyles();//superGridControl1.DefaultVisualStyles.RowStyles;
        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle WarningRowStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyles warningCellStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyles();//superGridControl1.DefaultVisualStyles.RowStyles;

        private SIFNegocio.OrdenCompra.OrdenCompra ordenCompraL = new SIFNegocio.OrdenCompra.OrdenCompra();
        private SIFNegocio.OrdenCompra.Compras compraL = new SIFNegocio.OrdenCompra.Compras();

        private SIFNegocio.OrdenCompra.OrdenCompraRecibe recibeL = new SIFNegocio.OrdenCompra.OrdenCompraRecibe();

        SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OrdenCompra;
        SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow Compra;

        private bool esPrimeraVez;

        private void inicializaColoresFilas()
        {
            revisarCellStyle.Default.Background.Color1 = Color.FromArgb(255, 35, 35);
            revisarCellStyle.Default.Background.Color2 = Color.FromArgb(255, 35, 35);

            warningCellStyle.Default.Background.Color1 = Color.FromArgb(253, 215, 0);
            warningCellStyle.Default.Background.Color2 = Color.FromArgb(253, 215, 0);

            margenCellStyle.Default.Background.Color1 = Color.FromArgb(200, 100, 100);
            margenCellStyle.Default.Background.Color2 = Color.FromArgb(200, 100, 100);

            faltanteCellStyle.Default.Background.Color1 = Color.FromArgb(0, 176, 80);
            faltanteCellStyle.Default.Background.Color2 = Color.FromArgb(0, 176, 80);

            //faltanteCellStyle.Default.Background.Color1 = Color.FromArgb(0, 176, 80);
            //faltanteCellStyle.Default.Background.Color2 = Color.FromArgb(0, 176, 80);

            //normalCellStyle.Default.Background.Color1 = this.superGridControl1.DefaultVisualStyles.CellStyles.Default.Background.Color1;
            //normalCellStyle.Default.Background.Color2 = this.superGridControl1.DefaultVisualStyles.CellStyles.Default.Background.Color2; // this.superGridControl1.DefaultVisualStyles.CellStyles.Default;

            revisarRowStyle.Background.Color1 = Color.FromArgb(255, 35, 35);
            revisarRowStyle.Background.Color2 = Color.FromArgb(255, 35, 35);

            WarningRowStyle.Background.Color1 = Color.FromArgb(253, 215, 0);
            WarningRowStyle.Background.Color2 = Color.FromArgb(253, 215, 0);

            margenRowStyle.Background.Color1 = Color.FromArgb(200, 100, 100);
            margenRowStyle.Background.Color2 = Color.FromArgb(200, 100, 100);

            faltanteRowStyle.Background.Color1 = Color.FromArgb(0, 176, 80);
            faltanteRowStyle.Background.Color2 = Color.FromArgb(0, 176, 80);

            //faltanteCellStyle.Default.Background.Color1 = Color.FromArgb(0, 176, 80);
            //faltanteCellStyle.Default.Background.Color2 = Color.FromArgb(0, 176, 80);

            normalRowStyle.Background.Color1 = this.superGridControl1.DefaultVisualStyles.CellStyles.Default.Background.Color1;
            normalRowStyle.Background.Color2 = this.superGridControl1.DefaultVisualStyles.CellStyles.Default.Background.Color2; // this.superGridControl1.DefaultVisualStyles.CellStyles.Default;

        }

        private void EstableceOrdenCompra()
        {
            //COMPRA
            this.Compra = SIFNegocio.OrdenCompra.Compras.OrdenCompraPorOCId(OrdenCompra);
            compraL.CompraDetalles = SIFNegocio.OrdenCompra.Compras.OrdenCompraDetallesPorCompraId(Compra);

            //  compraL.CompraDetalles.IEPS_MALColumn.ReadOnly = false;
            //FACTURA
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow factura = new SIFNegocio.OrdenCompra.OrdenCompra().FacturaPorNumero(OrdenCompra);// new SIFNegocio.OrdenCompra.OrdenCompra().BuscaCompras(this.OrdenCompra);
            if (factura != null)
            {
                
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETDataTable facturas = ordenCompraL.DetallesFacturaProveedor(factura).FACTURA_PROVEEDOR_DET;
                
                foreach (var detalle in compraL.CompraDetalles)
                {
                    var facturaEncontrada = from f in facturas where f.ARTICULO_ID.Trim() == detalle.ARTICULO_ID.Trim() select f;
                    
                    //if (detalle.ARTICULO_ID == "8400004277")
                    //{

                    //}FV

                    if (facturaEncontrada.Count() > 0)
                    {
                        SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETRow facturaDetalle = facturaEncontrada.First();

                        detalle.FacturaProveedorDetalle = facturaDetalle;
                        // detalle.CANT_FACTURADA = facturaDetalle.PZA_CCARGO;
                        detalle.PRECIO_FACTURA_MAX = (double)facturaDetalle.PRECIO_VENTA_MAX;
                        detalle.PRECIO_MAXIMO = detalle.PRECIO_FACTURA_MAX;
                        detalle.PRECIO_FACTURA = (double)facturaDetalle.PRECIO_VENTA_FAR;
                        detalle.PRECIO_FARMACIA = (double)facturaDetalle.PRECIO_VENTA_FAR;
                        detalle.PORC_OFERTA_FACTURA = (float)facturaDetalle.PORC_OFERTA;
                        detalle.PORC_OFERTA = (float)facturaDetalle.PORC_OFERTA;
                        detalle.PORC_DESCTO = (float)facturaDetalle.PORC_DESCTO;

                        if (facturaDetalle.IVA > 0)
                        {
                            detalle.PORC_IVA = 16;
                        }

                        SIFModelo.Articulo art = new SIFModelo.Articulo();
                        art.ARTICULO_ID = detalle.ARTICULO_ID;

                        if (detalle.PRECIO_FACTURA_MAX <= 0)
                        {
                            SIFModelo.Catalogo.ArticuloMayorista artMayorista = new SIFModelo.Catalogo.ArticuloMayorista();

                            if (OrdenCompra.PROVEEDOR_ID == 99035)
                            {
                                artMayorista = SIFNegocio.OrdenCompra.Compras.ArticuloProveedorDROG(art);
                            }
                            if (OrdenCompra.PROVEEDOR_ID == 99012)
                            {
                                artMayorista = SIFNegocio.OrdenCompra.Compras.ArticuloProveedorSABA(art);
                            }
                            if (OrdenCompra.PROVEEDOR_ID == 99064)
                            {
                                artMayorista = SIFNegocio.OrdenCompra.Compras.ArticuloProveedorNadro(art);
                            }


                            {
                                detalle.PRECIO_FACTURA_MAX = (double)(artMayorista.PrecioPublico);
                            }
                            if (artMayorista != null)
                            {
                                detalle.PORCENTAJE_IEPS = (float)artMayorista.PorcentajeIESPS;
                            }

                            if (detalle.PORCENTAJE_IEPS == 0) //REVISAR SI EN EL CATALOGO DE MAYORISTAS TIENE PORCENTAJE DE IEPS 
                            {
                                SIFModelo.OrdenCompra.InfromacionMayorista mayorista = new SIFNegocio.OrdenCompra.InformacionMayorista().InformacionMayoristaPorArticulo(art);
                                if (mayorista != null)
                                {
                                    detalle.PORCENTAJE_IEPS = mayorista.PORCENTAJE_IESPS;
                                }
                            }
                        }

                        if (detalle.PORCENTAJE_IEPS > 0)
                        {
                            double precioVenta = (detalle.PRECIO_FARMACIA / (1 + (detalle.PORCENTAJE_IEPS / 100)));
                            detalle.IMPORTE_IEPS = (precioVenta * detalle.CANT_FACTURADA) * (detalle.PORCENTAJE_IEPS / 100);
                        }
                        detalle.CODIGO_PROVEEDOR = facturaDetalle.CODIGO_PROVEEDOR;
                        detalle.IMPORTE_IVA = ((double)detalle.IMPORTE_NETO * (double)(detalle.PORC_IVA / 100));

                        //CALCULOS DE FACTURA
                        detalle.TOTAL_DESCTO_FACTURA = (double)(detalle.PRECIO_FACTURA * (double)(facturaDetalle.PORC_OFERTA / 100));
                        detalle.TOTAL_OFERTA_FACTURA = (double)(detalle.TOTAL_DESCTO_FACTURA * (double)(facturaDetalle.PORC_DESCTO / 100));

                    }
                    else
                    {
                        detalle.CANT_FACTURA = 0;
                        detalle.CANT_FACTURADA = 0;
                    }
                }
            }
            //END FACTURA
                                                    

            foreach (var row in compraL.CompraDetalles)
            {
                if (row.CANT_RECIBIDA < 1)
                    continue;

                SIFModelo.Inventarios.ListaPrecios precio = new SIFNegocio.Articulo().ArticuloPrecio(row.ARTICULO_ID);
                
                if (precio == null)
                    continue;

                row.ListaPrecios = precio;

                SIFModelo.Impuesto iva = new SIFNegocio.Impuestos().ImpuestoPorID(precio.IMP_COMPRA);

                if (iva != null)
                {
                    row.PORC_IVA = (double)iva.Porcentaje;
                }

                SIFModelo.Articulo art = new SIFModelo.Articulo();
                art.ARTICULO_ID = row.ARTICULO_ID;
                SIFModelo.OrdenCompra.InfromacionMayorista mayorista = new SIFNegocio.OrdenCompra.InformacionMayorista().InformacionMayoristaPorArticulo(art);
                if (mayorista != null)
                {
                    row.PORCENTAJE_IEPS = mayorista.PORCENTAJE_IESPS;
                }

                if (precio == null)
                {
                    continue;
                }

                if (row.PRECIO_MAXIMO == 0)
                {
                    row.PRECIO_MAXIMO = (double)precio.PRECIO_VENTA_MAX;
                }

                if (row.PRECIO_FARMACIA == 0)
                {
                    row.PRECIO_FARMACIA = (double)precio.PRECIO_VENTA_FARM;
                }

                if (row.PRECIO_VENTA == 0)
                {
                    row.PRECIO_VENTA = (double)precio.PRECIO_VENTA;
                }

                if (precio.PRECIO_VENTA > 0 && row.NUEVO_FLEMING == 0)
                {
                    row.NUEVO_FLEMING = (double)precio.PRECIO_VENTA;
                    row.EsDirecto = true;
                }
                else
                {
                    row.EsDirecto = true;
                }
                //row.PRECIO_FLEMING = precio.PRECIO_VENTA_MAX - (precio.PRECIO_VENTA_MAX * row.PORC_DESCTO / 100);
                row.COSTO_ULT_COMPRA = (double)precio.COSTO_ULT_COMPRA;

                //consultamos el descuento especial proveedor
                SIFModelo.Catalogo.CatalogoDataSet.OFERTAS_COMPRAS_MAYORISTARow oferta = compraL.OfertaPorArticuloProveedor(row);

                //if (oferta != null && oferta.DESCTO_ESPECIAL_PROVEE != 0)
                //{
                //    row.PORC_DESCTO_AD1 = (float)oferta.DESCTO_ESPECIAL_PROVEE;
                //}

                decimal porcentajeDescuento = ((precio.PRECIO_VENTA_MAX - (decimal)row.NUEVO_FLEMING) / precio.PRECIO_VENTA_MAX) * 100; //1 - (precio.PRECIO_VENTA / (decimal)precio.PRECIO_VENTA_MAX);
                porcentajeDescuento = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(porcentajeDescuento * 100);

                row.DESCUENTO_GENERAL = (float)porcentajeDescuento;

                SIFModelo.Articulo arti = new SIFModelo.Articulo();
                arti.ARTICULO_ID = row.ARTICULO_ID;

                var artMayorista = new SIFNegocio.OrdenCompra.InformacionMayorista().InformacionMayoristaPorArticulo(arti);
                if (artMayorista != null) { row.PORCENTAJE_IEPS = artMayorista.PORCENTAJE_IESPS; }


                if (artMayorista != null && (row.PORC_DESCTO == 0 || this.esPrimeraVez))
                {
                    if (OrdenCompra.PROVEEDOR_ID == 99035)
                    {
                        row.PORC_DESCTO = (float)artMayorista.DESCUENTO_DROGUEROS;
                    }
                    if (OrdenCompra.PROVEEDOR_ID == 99012)
                    {
                        row.PORC_DESCTO = (float)artMayorista.DESCUENTO_SABA;
                    }
                    if (OrdenCompra.PROVEEDOR_ID == 99064)
                    {
                        row.PORC_DESCTO = (float)artMayorista.DESCUENTO_NADRO;
                    }
                    if (OrdenCompra.PROVEEDOR_ID == 99169)
                    {
                        row.PORC_DESCTO = (float)artMayorista.DESCUENTO_MARZAM;
                    }
                }

                if (artMayorista != null && (row.PORC_DESCTO_AD1 == 0 || this.esPrimeraVez))
                {
                    if (OrdenCompra.PROVEEDOR_ID == 99035)
                    {
                        row.PORC_DESCTO_AD1 = (float)artMayorista.DESCTO_ADICIONAL_DROGUEROS;
                    }
                    if (OrdenCompra.PROVEEDOR_ID == 99012)
                    {   
                        row.PORC_DESCTO_AD1 = (float)artMayorista.DESCTO_ADICIONAL_SABA;
                    }
                    if (OrdenCompra.PROVEEDOR_ID == 99064)
                    {
                        row.PORC_DESCTO_AD1 = (float)artMayorista.DESCTO_ADICIONAL_NADRO;
                    }
                    if (OrdenCompra.PROVEEDOR_ID == 99169)
                    {
                        row.PORC_DESCTO_AD1 = (float)artMayorista.DESCTO_ADICIONAL_MARZAM;
                    }
                }

                this.calculaTotalDetalle(row);
                this.calculaUtilidad(row);
            }

            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row in compraL.CompraDetalles)
            {
                recibeL.SetRecepcionCompra(row);
            }



            /*******AVM Eimina del data table los registro que sean menor a 1 en la propiedad cat_recibida 27-05-2015*******/
            String indexRemove = "";
            int index = 0;
            foreach (var row in compraL.CompraDetalles)
            {
                if(row.CANT_RECIBIDA+row.CANT_DEV_FALTANTE+row.CANT_MALESTADO+ row.CANT_PROX_CADUCAR+row.CANT_DEV_PRECIO_ELEVADO+row.CANT_DEV_NO_PEDIDO < 1 )
                    indexRemove += index + ";";

                index++;
            }

            String [] removerDetalles = indexRemove.Split(';');
            int retroceder = 0;
            foreach (String item in removerDetalles)
            {
                if (item != "")
                {
                    if(retroceder >= 1)
                        compraL.CompraDetalles.Rows.RemoveAt(int.Parse(item) - retroceder);
                    else
                        compraL.CompraDetalles.Rows.RemoveAt(int.Parse(item));
                    
                    retroceder++;
                }
            }
            /***************************************************************************/

            this.superGridControl1.PrimaryGrid.DataSource = compraL.CompraDetalles;

            //DETALLES
            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(OrdenCompra.PROVEEDOR_ID);
            if (cliente != null)
            {
                this.ProveedorLabel.Text = cliente.ID + "[" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno + "]";
            }
            this.folioOrdencompraLabel.Text = Compra.FOLIO_OC;
            this.statusOrdencompraLabel.Text = OrdenCompra.ESTADO_OC;
        }

        //private void EstableceOrdenCompra()
        //{
        //    if (OrdenCompra == null)
        //    {
        //        OrdenCompra = new SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRADataTable().NewV_ORDEN_COMPRARow();
        //    }

        //    //COMPRA
        //    this.Compra = SIFNegocio.OrdenCompra.Compras.OrdenCompraPorOCId(OrdenCompra);

        //    if (Compra == null)
        //    {
        //        Compra = new SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASDataTable().NewCOMPRASRow();

        //        Compra.FOLIO_COMPRA = "";
        //        Compra.FOLIO_OC = OrdenCompra.FOLIO_OC_ID;
        //        Compra.PROVEEDOR_ID = OrdenCompra.PROVEEDOR_ID;
        //        Compra.FACTURA = "";
        //        Compra.FOLIO_FACTURA_SAT = "";
        //        Compra.TOT_IMPORTE_REC = 0;
        //        Compra.TOT_DESCTO_REC = 0;
        //        Compra.TOT_IVA_REC = 0;
        //        Compra.TOTAL_RECIBIDO = 0;
        //        Compra.TOTAL_NETO_RECIBIDO = 0;
        //        Compra.TOT_DESCTO_SINIVA_REC = 0;
        //        Compra.TOT_DESCTO_CONIVA_REC = 0;
        //        Compra.TOTAL_IVA_DESCTO_REC = 0;
        //        Compra.TOTAL_DESCTO_DESCUENTOS_REC = 0;
        //        Compra.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
        //        Compra.ACTIVO = "S";
        //        Compra.USUARIO_ID = UsuarioId;
        //        Compra.USUARIO_ID_ASIG_PRECIO = OrdenCompra.USUARIO_ID_AUTORIZA;
        //        Compra.IMP_FALTANTE = 0;
        //        Compra.IMP_DESC_FALTANTE = 0;
        //        Compra.IMP_IVA_MAL = 0;
        //    }
        //    else
        //    {
        //        compraL.CompraDetalles = SIFNegocio.OrdenCompra.Compras.OrdenCompraDetallesPorCompraId(Compra);
        //    }

        //    //PROVEEDOR
        //    SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(OrdenCompra.PROVEEDOR_ID);
        //    if (cliente != null)
        //    {
        //        this.ProveedorLabel.Text = cliente.ID + "[" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno + "]";
        //    }

        //    this.folioOrdencompraLabel.Text = Compra.FOLIO_OC;
        //    this.statusOrdencompraLabel.Text = Compra.ACTIVO;

        //    //DETALLES DE LA ORDEN DE COMPRA
        //    ordenCompraL.BuscaOrdenCompraDetalle(OrdenCompra);
        //    vDetalles = new DataView(ordenCompraL.OrdenCompraDetalles);

        //    if (compraL.CompraDetalles == null)
        //    {
        //        compraL.CompraDetalles = new SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable();


        //        foreach (var compraDet in ordenCompraL.OrdenCompraDetalles)
        //        {
        //            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow cd = compraL.CompraDetalles.NewCOMPRAS_DETRow();
        //            cd.FOLIO_COMPRA = Compra.FOLIO_COMPRA;
        //            cd.FOLIO_OC = Compra.FOLIO_OC;
        //            cd.PROVEEDOR_ID = Compra.PROVEEDOR_ID;
        //            cd.ARTICULO_ID = compraDet.ARTICULO_ID;
        //            cd.NOMBRE = compraDet.NOMBRE;
        //            cd.PRECIO_FARM_REC = (double)compraDet.PRECIO_COSTO;
        //            cd.CANT_RECIBIDA = compraDet.CANT_RECIBIDA;
        //            cd.CANT_PROX_CADUCAR = compraDet.CANT_DEVUELTA;
        //            cd.CANT_MALESTADO = compraDet.CANT_MALESTADO;
        //            cd.CANT_REPOSICION = compraDet.CANT_REPOSICION;
        //            cd.PORC_OFERTA = 0;
        //            cd.PORC_DESCTO = 0;
        //            cd.PORC_DESCTO_AD1 = 0;
        //            cd.PORC_DESCTO_AD2 = 0;
        //            cd.PORC_DESCTO_AD3 = 0;
        //            cd.PORC_DESCTO_AD4 = 0;
        //            cd.IMP_OFERTA_SINIVA = 0;
        //            cd.IMP_OFERTA_CONIVA = 0;
        //            cd.IMP_DESCTO_SINIVA = 0;
        //            cd.IMP_DESCTO_CONIVA = 0;
        //            cd.IMPORTE_IVA = 0;
        //            cd.IMPORTE_IEPS = 0;
        //            cd.IMP_DESCTO_CONIVA_MENOSIVA = 0;
        //            cd.IMP_RECEPCION_CONIVA = 0;
        //            cd.IMP_RECEPCION_SINIVA = 0;
        //            cd.IMP_CAL1_OFERTA_CONIVA = 0;
        //            cd.IMP_CAL1_OFERTA_SINIVA = 0;
        //            cd.RES_CAL1_DESCTO = 0;
        //            cd.RES_CAL2_OFERTA = 0;
        //            cd.RES_CAL3_DESCTOAD1 = 0;
        //            cd.RES_CAL4_DESCTOAD2 = 0;
        //            cd.RES_CAL5_DESCTOAD3 = 0;
        //            cd.RES_CAL6_DESCTOAD4 = 0;
        //            cd.COSTO_NETO_UNIT_REC = 0;
        //            cd.IMPORTE_NETO = 0;
        //            cd.DIF_DESCTO_IVA = 0;
        //            cd.FLAG_MAL_OFERTADO = "N";
        //            cd.DESCUENTO_GENERAL = 0;
        //            cd.PORCENTAJE_IEPS = 0;

        //            int cantRecibida = cd.CANT_FACTURADA;

        //            if (cantRecibida == 0)
        //            {
        //                cantRecibida = cd.CANT_SOLICITADA;
        //            }

        //            //      cd.CANT_RECIBIDA = cantRecibida - cd.CANT_DEV_FALTANTE - cd.CANT_DEV_NO_PEDIDO - cd.CANT_DEV_PRECIO_ELEVADO - cd.CANT_MALESTADO - cd.CANT_PROX_CADUCAR;


        //            // cd.CANT_RECIBIDA = cd.CANT_FACTURADA - cd.CANT_DEV_FALTANTE - cd.CANT_DEV_NO_PEDIDO - cd.CANT_DEV_PRECIO_ELEVADO - cd.CANT_MALESTADO - cd.CANT_PROX_CADUCAR;


        //            cd.COSTO = (double)compraDet.PRECIO_COSTO;
        //            cd.CANT_SOLICITADA = compraDet.CANT_SOLICITADA;
        //            compraL.CompraDetalles.AddCOMPRAS_DETRow(cd);
        //        }
        //    }
        //    //this.superGridControl1.PrimaryGrid.DataSource = ordenCompraL.OrdenCompraDetalles;
        //    //this.superGridControl1.PrimaryGrid.DataMember = "ORDEN_COMPRA_DET";
        //    //this.superGridControl1.Refresh();
        //    SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow factura = new SIFNegocio.OrdenCompra.OrdenCompra().FacturaPorNumero(OrdenCompra);// new SIFNegocio.OrdenCompra.OrdenCompra().BuscaCompras(this.OrdenCompra);
        //    if (factura != null)
        //    {
        //        SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETDataTable facturas = ordenCompraL.DetallesFacturaProveedor(factura).FACTURA_PROVEEDOR_DET;

        //        foreach (var detalle in compraL.CompraDetalles)
        //        {
        //            var facturaEncontrada = from f in facturas where f.ARTICULO_ID == detalle.ARTICULO_ID select f;

        //            if (facturaEncontrada.Count() > 0)
        //            {
        //                SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETRow facturaDetalle = facturaEncontrada.First();

        //                detalle.FacturaProveedorDetalle = facturaDetalle;
        //                detalle.CANT_FACTURADA = facturaDetalle.PZA_CCARGO;
        //                detalle.PRECIO_FACTURA_MAX = (double)facturaDetalle.PRECIO_VENTA_MAX;
        //                detalle.PRECIO_MAXIMO = detalle.PRECIO_FACTURA_MAX;
        //                detalle.PRECIO_FACTURA = (double)facturaDetalle.PRECIO_VENTA_FAR;
        //                detalle.PRECIO_FARMACIA = (double)facturaDetalle.PRECIO_VENTA_FAR;
        //                detalle.PORC_OFERTA_FACTURA = (float)facturaDetalle.PORC_OFERTA;
        //                //  detalle.PORC_OFERTA = // (float)facturaDetalle.PORC_OFERTA;
        //                // detalle.PORC_DESCTO = (float)facturaDetalle.PORC_DESCTO;

        //                SIFModelo.Articulo art = new SIFModelo.Articulo();
        //                art.ARTICULO_ID = detalle.ARTICULO_ID;

        //                //if (detalle.PRECIO_FACTURA_MAX <= 0)
        //                //{
        //                SIFModelo.Catalogo.ArticuloMayorista artMayorista = new SIFModelo.Catalogo.ArticuloMayorista();

        //                if (OrdenCompra.PROVEEDOR_ID == 99035)
        //                {
        //                    artMayorista = SIFNegocio.OrdenCompra.Compras.ArticuloProveedorDROG(art);
        //                }
        //                if (OrdenCompra.PROVEEDOR_ID == 99012)
        //                {
        //                    artMayorista = SIFNegocio.OrdenCompra.Compras.ArticuloProveedorSABA(art);
        //                }
        //                if (OrdenCompra.PROVEEDOR_ID == 99064)
        //                {
        //                    //   artMayorista = SIFNegocio.OrdenCompra.Compras.ArticuloProveedorNadro(art);
        //                }

        //                //
        //                //{
        //                //    detalle.PRECIO_FACTURA_MAX = (double)(artMayorista.PrecioPublico);
        //                //}
        //                if (artMayorista != null)
        //                {
        //                    detalle.PORCENTAJE_IEPS = (float)artMayorista.PorcentajeIESPS;
        //                }

        //                if (detalle.PORCENTAJE_IEPS == 0) //REVISAR SI EN EL CATALOGO DE MAYORISTAS TIENE PORCENTAJE DE IEPS 
        //                {
        //                    SIFModelo.OrdenCompra.InfromacionMayorista mayorista = new SIFNegocio.OrdenCompra.InformacionMayorista().InformacionMayoristaPorArticulo(art);
        //                    if (mayorista != null)
        //                    {
        //                        //detalle.PORCENTAJE_IEPS = mayorista.PORCENTAJE_IESPS;
        //                    }
        //                }
        //                //}

        //                if (detalle.PORCENTAJE_IEPS > 0)
        //                {
        //                    double precioVenta = (detalle.PRECIO_FARMACIA / (1 + (detalle.PORCENTAJE_IEPS / 100)));
        //                    detalle.IMPORTE_IEPS = (precioVenta * detalle.CANT_FACTURADA) * (detalle.PORCENTAJE_IEPS / 100);
        //                }
        //                detalle.CODIGO_PROVEEDOR = facturaDetalle.CODIGO_PROVEEDOR;
        //                detalle.IMPORTE_IVA = ((double)detalle.IMPORTE_NETO * (double)(detalle.PORC_IVA / 100));

        //                //CALCULOS DE FACTURA
        //                detalle.TOTAL_DESCTO_FACTURA = (double)(detalle.PRECIO_FACTURA * (double)(facturaDetalle.PORC_OFERTA / 100));
        //                detalle.TOTAL_OFERTA_FACTURA = (double)(detalle.TOTAL_DESCTO_FACTURA * (double)(facturaDetalle.PORC_DESCTO / 100));

        //            }

        //        }
        //    }

        //    foreach (var row in compraL.CompraDetalles)
        //    {
        //        SIFModelo.Inventarios.ListaPrecios precio = new SIFNegocio.Articulo().ArticuloPrecio(row.ARTICULO_ID);
        //        row.ListaPrecios = precio;

        //        if (precio == null)
        //        {
        //            continue;
        //        }

        //        if (row.PRECIO_MAXIMO == 0)
        //        {
        //            row.PRECIO_MAXIMO = (double)precio.PRECIO_VENTA_MAX;
        //        }

        //        if (row.PRECIO_FARMACIA == 0)
        //        {
        //            row.PRECIO_FARMACIA = (double)precio.PRECIO_VENTA_FARM;
        //        }

        //        if (row.PRECIO_VENTA == 0)
        //        {
        //            row.PRECIO_VENTA = (double)precio.PRECIO_VENTA;
        //        }

        //        if (precio.PRECIO_VENTA > 0 && row.NUEVO_FLEMING == 0)
        //        {
        //            row.NUEVO_FLEMING = (double)precio.PRECIO_VENTA;
        //            row.EsDirecto = true;
        //        }
        //        else
        //        {
        //            row.EsDirecto = true;
        //        }
        //        //row.PRECIO_FLEMING = precio.PRECIO_VENTA_MAX - (precio.PRECIO_VENTA_MAX * row.PORC_DESCTO / 100);
        //        row.COSTO_ULT_COMPRA = (double)precio.COSTO_ULT_COMPRA;

        //        //consultamos el descuento especial proveedor
        //        SIFModelo.Catalogo.CatalogoDataSet.OFERTAS_COMPRAS_MAYORISTARow oferta = compraL.OfertaPorArticuloProveedor(row);

        //        if (oferta != null)
        //        {
        //            row.PORC_DESCTO_AD1 = (float)oferta.DESCTO_ESPECIAL_PROVEE;
        //        }

        //        decimal porcentajeDescuento = 1 - (precio.PRECIO_VENTA / (decimal)precio.PRECIO_VENTA_MAX);
        //        porcentajeDescuento = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(porcentajeDescuento * 100);

        //        row.DESCUENTO_GENERAL = (float)porcentajeDescuento;

        //        SIFModelo.Articulo art = new SIFModelo.Articulo();
        //        art.ARTICULO_ID = row.ARTICULO_ID;

        //        var artMayorista = new SIFNegocio.OrdenCompra.InformacionMayorista().InformacionMayoristaPorArticulo(art);


        //        if (artMayorista != null && row.PORC_DESCTO_AD1 == 0)
        //        {
        //            if (OrdenCompra.PROVEEDOR_ID == 99035)
        //            {
        //                row.PORC_DESCTO_AD1 = (float)artMayorista.DESCTO_ADICIONAL_DROGUEROS;
        //            }
        //            if (OrdenCompra.PROVEEDOR_ID == 99012)
        //            {
        //                row.PORC_DESCTO_AD1 = (float)artMayorista.DESCTO_ADICIONAL_SABA;
        //            }
        //            if (OrdenCompra.PROVEEDOR_ID == 99064)
        //            {
        //                row.PORC_DESCTO_AD1 = (float)artMayorista.DESCTO_ADICIONAL_NADRO;
        //            }
        //        }

        //        this.calculaTotalDetalle(row);
        //        this.calculaUtilidad(row);
        //    }

        //    this.descuentoGeneralNumericUpDown.Value = -1; //= (decimal)compra.DESCUENTO_RECIBIDO;
        //    this.calculaTotal();

        //    //esPrimeraVez = false;

        //    preciosBindingSource.DataSource = compraL.CompraDetalles;

        //    //this.superGridControl1.PrimaryGrid.DataSource = compraL.CompraDetalles;

        //    superGridControl1.PrimaryGrid.DataSource = preciosBindingSource;

        //    this.superGridControl1.PrimaryGrid.DataMember = "COMPRAS_DET";


        //}

        private void calculaTotal()
        {
            decimal totalFactura = 0;
            decimal totalFacturado = 0;
            decimal totalRecibido = 0;
            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row in compraL.CompraDetalles.Rows)
            {
                if (row.FacturaProveedorDetalle != null)
                    totalFactura += row.FacturaProveedorDetalle.COSTO_NETO_UNITARIO * row.FacturaProveedorDetalle.PZA_CCARGO;
                totalFacturado += (decimal)(row.PRECIO_FACTURA * row.CANT_FACTURADA);
                totalRecibido += (decimal)row.PRECIO_FARM_REC * row.CANT_RECIBIDA;
            }

            this.totalFacturadoLabel.Text = totalFacturado.ToString("C2");
            this.totalRecibidoLabel.Text = totalRecibido.ToString("C2");
            this.totalFacturaLabel.Text = totalFactura.ToString("C2");
        }

        DataView vDetalles;
        private void buscarLocal()
        {
            //if (string.IsNullOrEmpty(propiedadBusqueda))
            //{
            //    SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow modelo = new SIFModelo.OrdenCompra.OrdenesCompraDataSet().ORDEN_COMPRA_DET.NewORDEN_COMPRA_DETRow();
            //    propiedadBusqueda = Helpers.Reflect.GetMember(() => modelo.ARTICULO_ID).Name;
            //}
            //vDetalles.RowFilter = propiedadBusqueda + " like '%" + this.buscarTextBoxX.Text.ToUpper() + "%'";
            //try
            //{
            //    this.superGridControl1.PrimaryGrid.DataSource = ordenCompraL.OrdenCompraDetalles.Select("Convert(" + propiedadBusqueda + ", 'System.String')  like '%" + this.buscarTextBoxX.Text + "%'");
            //}
            //catch
            //{
            //}
        }
        private bool ValidaOrdenCompra()
        {
            bool sinMargenUtilidad = false;
            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row in compraL.CompraDetalles.Rows)
            {
                if (row.MARGEN_UTILIDAD < 0)
                {
                    sinMargenUtilidad = true;
                }
            }

            if (sinMargenUtilidad)
            {
                if (MessageBoxEx.Show("Hay artículos cuyo margen de utilidad es menor a cero, ¿desea guardar la orden de compra?", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return false;
                }
            }

            return true;
        }

        private void RecibirOrdenCompra()
        {
            Actualiza();
            //AsignacionPreciosFinalizaForm frmAsignap = new AsignacionPreciosFinalizaForm(OrdenCompra, Compra.TOT_FACT_RECIBIDO, Compra.DESCUENTO_FACTURA, Compra.IVA_FACTURA, Compra.TOT_FACTURA, Compra.TOT_IMPORTE_REC, Compra.TOT_DESCTO_REC, Compra.TOT_IVA_REC, Compra.TOTAL_RECIBIDO, Compra.MAL_OFERTADO, Compra.SIN_OFERTA, Compra, TotalFaltante, TotalMalestado, TotalNoPedido, TotalPrioximoCaducar, TotalPrecioElevado, totalDescto2, totalDescto3, totalDescto4, TotalNoLlego, Compra.IMP_IVA_MAL);
            //if (frmAsignap.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}

            var ordenesCompra = from o in compraL.CompraDetalles where o.NUEVO_FLEMING == 0 select o;

            if (ordenesCompra.Count() > 0)
            {
               MessageBox.Show("Debe asignar todos los precios");
                return;
            }

            //OrdenCompra.ESTADO_OC = "L";

            //if (!ValidaOrdenCompra())
            //{
            //    return;
            //}
            //ordenCompraL.ActualizaOrdenCompra(this.OrdenCompra);

            //return;

            this.recepcionDescuentoTextBox_KeyUp(null, null);
            Compra.TOTAL_IVA_DESCTO_REC = 0;
            //totales de factura
            Compra.TOT_FACT_RECIBIDO = 0.0M;
            Compra.TOT_FACTURA = 0.0M;
            Compra.DESCUENTO_FACTURA = 0.0M;
            Compra.IVA_FACTURA = 0.0M;
            Compra.IEPS_FACTURA = 0.0M;
            Compra.TOT_DESCTO_CONIVA_REC = 0;
            Compra.TOT_DESCTO_SINIVA_REC = 0;
            Compra.IMP_DESC_FALTANTE = 0;
            Compra.IMP_IVA_MAL = 0;

            Compra.IMP_FALTANTE = 0;
            Compra.TOT_IMPORTE_REC = 0;
            Compra.TOT_DESCTO_REC = 0;
            //Compra.TOT_DESCTO_REC_sinofert
            Compra.TOT_IVA_REC = 0;
            Compra.MAL_OFERTADO = 0.0M;
            Compra.SIN_OFERTA = 0;
            Compra.TOTAL_NETO_RECIBIDO = 0;

            Compra.TOT_IEPS_REC = 0;
            Compra.TOTAL_IEPS_DESCTO_REC = 0;
            Compra.IMP_IEPS_MAL = 0;

            //
            decimal TotalFaltante = 0;
            decimal TotalMalestado = 0;
            decimal TotalNoPedido = 0;
            decimal TotalPrioximoCaducar = 0;
            decimal TotalPrecioElevado = 0;

            decimal totalDescto1 = 0;
            decimal totalDescto2 = 0;
            decimal totalDescto3 = 0;
            decimal totalDescto4 = 0;
            decimal totalDescto5 = 0;

            decimal TotalNoLlego = 0;

            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row in compraL.CompraDetalles.Rows)
            {
                decimal importeFacturaD = (decimal)(row.PRECIO_FACTURA * row.CANT_FACTURADA);

                if (double.IsInfinity(row.COSTO_NETO_UNIT_REC))
                {
                    row.COSTO_NETO_UNIT_REC = 0;
                }

                if (row.FacturaProveedorDetalle == null)
                {
                    importeFacturaD = (decimal)(row.PRECIO_FARMACIA * row.CANT_FACTURADA);
                }

                Compra.TOT_FACT_RECIBIDO += importeFacturaD;

                //   row.COSTO_NETO_UNIT_REC = (double)SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(row.PRECIO_FARMACIA * (1 - (double)((decimal)row.PORC_DESCTO / 100m))); //(double)(1 - ((decimal)row.PORC_OFERTA / 100m)) * 
                //   row.IMPORTE_NETO = row.COSTO_NETO_UNIT_REC * row.CANT_RECIBIDA;
                Compra.TOTAL_NETO_RECIBIDO += (decimal)row.IMPORTE_NETO;
                Compra.TOT_IMPORTE_REC += (decimal)row.PRECIO_FARMACIA * row.CANT_RECIBIDA;

                decimal importeIvaUnitario = 0;
                if (row.PORC_IVA > 0)
                {
                    importeIvaUnitario = (decimal)row.COSTO_NETO_UNIT_REC * ((decimal)row.PORC_IVA / 100m);
                }

                Compra.IVA_FACTURA += importeIvaUnitario * row.CANT_FACTURADA;

                Compra.MAL_OFERTADO = 0;


                //DESCUENTO RECIBIDO
                if (double.IsInfinity(row.COSTO_NETO_UNIT_REC))
                {
                    row.COSTO_NETO_UNIT_REC = 0;
                }
                decimal importeRecibidoD = (decimal)(row.COSTO_NETO_UNIT_REC);
                // Compra.TOT_IMPORTE_REC += importeRecibidoD;
                decimal dRecibido = 0;
                decimal dor = (importeRecibidoD * ((decimal)row.PORC_OFERTA / 100));
                dRecibido = importeRecibidoD - dor;
                decimal recibidoDevolucion = dRecibido;
                decimal importeIvaUnitarioRecepcion = 0;
                if (row.PORC_IVA > 0)
                {
                    importeIvaUnitarioRecepcion = (decimal)dRecibido * ((decimal)row.PORC_IVA / 100m);
                }

                Compra.TOTAL_RECIBIDO += (decimal)row.IMPORTE_NETO;
                Compra.TOT_IVA_REC += importeIvaUnitarioRecepcion * row.CANT_RECIBIDA;

                // dRecibido = (decimal) row.COSTO_NETO_UNIT_REC;

                decimal d1 = ((importeRecibidoD * row.CANT_RECIBIDA) * ((decimal)row.PORC_DESCTO / 100));
                //totalDescto1 += d1;

                dRecibido = d1;
                dRecibido -= importeIvaUnitarioRecepcion;
                decimal d2 = (dRecibido * ((decimal)row.PORC_DESCTO_AD1 / 100));
                totalDescto2 += (decimal)row.RES_CAL3_DESCTOAD1;
                dRecibido -= d2;
                decimal d3 = (dRecibido * ((decimal)row.PORC_DESCTO_AD2 / 100));
                totalDescto3 += (decimal)row.RES_CAL4_DESCTOAD2;
                dRecibido -= d3;
                decimal d4 = (dRecibido * ((decimal)row.PORC_DESCTO_AD3 / 100));
                totalDescto4 += (decimal)row.RES_CAL5_DESCTOAD3;
                dRecibido -= d4;
                decimal d5 = (dRecibido * ((decimal)row.PORC_DESCTO_AD4 / 100));
                totalDescto5 += (decimal)row.RES_CAL5_DESCTOAD3;
                dRecibido -= d5;

                decimal cantidadFaltante = row.CANT_PROX_CADUCAR + row.CANT_MALESTADO + row.CANT_REPOSICION;

                //if (row.CANT_FACTURADA > 0)
                //{
                Compra.IMP_FALTANTE += cantidadFaltante * (decimal)row.COSTO_NETO_UNIT_REC;
                //}
                //else
                //{
                //    TotalNoLlego += cantidadFaltante * (decimal)row.COSTO_NETO_UNIT_REC;
                //}
                if (row.CANT_FACTURADA > 0)
                {
                    TotalFaltante += row.CANT_DEV_FALTANTE * (decimal)row.COSTO_NETO_UNIT_REC;
                }
                else
                {
                    TotalNoLlego += row.CANT_DEV_FALTANTE * (decimal)row.COSTO_NETO_UNIT_REC;
                }

                decimal totalIvaDevolucion = (decimal)row.COSTO_NETO_UNIT_REC - recibidoDevolucion; //329.82

                decimal ivaRecepcion = 0;
                if (row.PORC_IVA > 0)
                {
                    ivaRecepcion = totalIvaDevolucion * ((decimal)row.PORC_IVA / 100m);
                }


                decimal ivaDevolucion = ivaRecepcion * row.CANT_RECIBIDA;

                Compra.TOTAL_IVA_DESCTO_REC += (importeIvaUnitario + ivaDevolucion);

                TotalMalestado += row.CANT_MALESTADO * (decimal)row.COSTO_NETO_UNIT_REC;
                TotalNoPedido += row.CANT_DEV_NO_PEDIDO * (decimal)row.COSTO_NETO_UNIT_REC;
                TotalPrioximoCaducar += row.CANT_PROX_CADUCAR * (decimal)row.COSTO_NETO_UNIT_REC;
                TotalPrecioElevado += row.CANT_DEV_PRECIO_ELEVADO * (decimal)row.COSTO_NETO_UNIT_REC;

                Compra.TOT_DESCTO_REC += (decimal)row.IMP_OFERTA_CONIVA + (decimal)row.IMP_DESCTO_CONIVA; //(dor + d2 + d3 + d4 + d5) * row.CANT_RECIBIDA; // + d1

                Compra.SIN_OFERTA += (decimal)row.SIN_OFERTA;
                Compra.MAL_OFERTADO += (decimal)row.MAL_OFERTADO;

                //Compra.DESCUENTO_FACTURA += (decimal)row.TOTAL_OFERTA_FACTURA + (decimal)row.TOTAL_DESCTO_FACTURA; // ((decimal)row.PRECIO_FARMACIA * (decimal)row.PORC_DESCTO / 100M) * row.CANT_FACTURADA;

                //if (row.FacturaProveedorDetalle != null)
                //{
                //    decimal dFactura = 0;
                //    decimal dof = (importeFacturaD * (row.FacturaProveedorDetalle.PORC_OFERTA / 100));
                //    dFactura = importeFacturaD - dof;
                //    decimal df1 = (dFactura * (row.FacturaProveedorDetalle.PORC_DESCTO / 100));
                //    dFactura -= df1;
                //    Compra.DESCUENTO_FACTURA += dof + df1;


                //    if (row.FacturaProveedorDetalle.IVA > 0)
                //    {
                //        //row.PORC_IVA = (row.FacturaProveedorDetalle.IVA / row.CANT_FACTURADA) / row.PRECIO_FACTURA;
                //        //row.PORC_IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(row.PORC_IVA * 100);

                //        row.PORC_IVA = 16;
                //        if (row.FacturaProveedorDetalle.IMPORTE_NETO == 0)
                //        {
                //            row.FacturaProveedorDetalle.IMPORTE_NETO = row.FacturaProveedorDetalle.COSTO_NETO_UNITARIO * row.CANT_FACTURADA;
                //        }
                //        Compra.IVA_FACTURA += (decimal)(row.FacturaProveedorDetalle.IMPORTE_NETO * (decimal)(row.PORC_IVA / 100));
                //        row.IMPORTE_IVA = ((double)row.IMPORTE_NETO * (double)(row.PORC_IVA / 100));
                //        Compra.TOT_IVA_REC += (decimal)row.IMPORTE_IVA;

                //        decimal cantidadDevolucion = cantidadFaltante;

                //        Compra.TOTAL_IVA_DESCTO_REC += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((cantidadDevolucion * (decimal)row.COSTO_NETO_UNIT_REC) * (decimal)(row.PORC_IVA / 100)));

                //        Compra.MAL_OFERTADO += ((dor + d1) - (dof + df1));

                //        row.IVA_MAL_OFERTADO = (double)Compra.MAL_OFERTADO * (double)(row.PORC_IVA / 100f);
                //        Compra.IMP_IVA_MAL += (decimal)row.IVA_MAL_OFERTADO;

                //    }

                //    //IESPS
                //    if (row.IMPORTE_IEPS > 0)
                //    {
                //        //row.PORC_IVA = (row.FacturaProveedorDetalle.IVA / row.CANT_FACTURADA) / row.PRECIO_FACTURA;
                //        //row.PORC_IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(row.PORC_IVA * 100);

                //        //row.PORCENTAJE_IEPS = 16;
                //        if (row.FacturaProveedorDetalle.IMPORTE_NETO == 0)
                //        {
                //            row.FacturaProveedorDetalle.IMPORTE_NETO = row.FacturaProveedorDetalle.COSTO_NETO_UNITARIO * row.CANT_FACTURADA;
                //        }
                //        //Compra.IEPS_FACTURA += (decimal)(row.FacturaProveedorDetalle.IMPORTE_NETO * (decimal)(row.PORCENTAJE_IEPS / 100));
                //        // row.IMPORTE_IEPS = ((double)row.IMPORTE_NETO * (double)(row.PORCENTAJE_IEPS / 100));

                //        double precioVenta = (row.PRECIO_FARMACIA / (1 + (row.PORCENTAJE_IEPS / 100)));
                //        row.IMPORTE_IEPS = (precioVenta * row.CANT_FACTURADA) * (row.PORCENTAJE_IEPS / 100);

                //        Compra.IEPS_FACTURA += (decimal)row.IMPORTE_IEPS;
                //        Compra.TOT_IEPS_REC += (decimal)(precioVenta * row.CANT_RECIBIDA * (row.PORCENTAJE_IEPS / 100));

                //        decimal cantidadDevolucion = cantidadFaltante;

                //        Compra.TOTAL_IEPS_DESCTO_REC += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((cantidadDevolucion * (decimal)precioVenta) * (decimal)(row.PORCENTAJE_IEPS / 100)));

                //        // Compra.MAL_OFERTADO += ((dor + d1) - (dof + df1));

                //        row.IEPS_MAL = (double)Compra.MAL_OFERTADO * (double)(row.PORCENTAJE_IEPS / 100f);
                //        Compra.IMP_IEPS_MAL += (decimal)row.IEPS_MAL;

                //    }
                //    //END IESPS

                //    //Compra.SIN_OFERTA += (dor - dof);
                //}
                //else
                //{
                //    importeFacturaD = (decimal)(row.PRECIO_FARMACIA * row.CANT_FACTURADA);
                //    decimal dFactura = 0;
                //    decimal dof = (importeFacturaD * ((decimal)row.PORC_OFERTA_FACTURA / 100));
                //    dFactura = importeFacturaD - dof;
                //    decimal df1 = (dFactura * ((decimal)row.PORC_DESCTO / 100));
                //    dFactura -= df1;
                //    Compra.DESCUENTO_FACTURA += dof + df1;


                //    if (row.PORC_IVA > 0)
                //    {
                //        //row.PORC_IVA = (row.FacturaProveedorDetalle.IVA / row.CANT_FACTURADA) / row.PRECIO_FACTURA;
                //        //row.PORC_IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(row.PORC_IVA * 100);

                //        row.PORC_IVA = 16;
                //        double impNetoFactura = 0;

                //        if (row.IMPORTE_NETO == 0)
                //        {
                //            row.IMPORTE_NETO = row.COSTO_NETO_UNIT_REC * row.CANT_FACTURADA;
                //        }

                //        impNetoFactura =  row.COSTO_NETO_UNIT_REC * row.CANT_FACTURADA;

                //        Compra.IVA_FACTURA += (decimal)((decimal)dFactura * (decimal)(row.PORC_IVA / 100));
                //        row.IMPORTE_IVA = ((double)(row.COSTO * row.CANT_RECIBIDA) * (double)(row.PORC_IVA / 100));
                //        Compra.TOT_IVA_REC += (decimal)row.IMPORTE_IVA;

                //        decimal cantidadDevolucion = cantidadFaltante;

                //        Compra.TOTAL_IVA_DESCTO_REC += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((cantidadDevolucion * (decimal)row.COSTO_NETO_UNIT_REC) * (decimal)(row.PORC_IVA / 100)));

                //        Compra.MAL_OFERTADO += ((dor + d1) - (dof + df1));

                //        row.IVA_MAL_OFERTADO = (row.SIN_OFERTA + row.MAL_OFERTADO) * (double)(row.PORC_IVA / 100f);
                //        Compra.IMP_IVA_MAL += (decimal)row.IVA_MAL_OFERTADO;

                //    }

                //    //IESPS
                //    if (row.IMPORTE_IEPS > 0)
                //    {
                //        //row.PORC_IVA = (row.FacturaProveedorDetalle.IVA / row.CANT_FACTURADA) / row.PRECIO_FACTURA;
                //        //row.PORC_IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(row.PORC_IVA * 100);

                //        //row.PORCENTAJE_IEPS = 16;
                //        if (row.IMPORTE_NETO == 0)
                //        {
                //            row.IMPORTE_NETO = row.COSTO_NETO_UNIT_REC * row.CANT_FACTURADA;
                //        }
                //        //Compra.IEPS_FACTURA += (decimal)(row.FacturaProveedorDetalle.IMPORTE_NETO * (decimal)(row.PORCENTAJE_IEPS / 100));
                //        // row.IMPORTE_IEPS = ((double)row.IMPORTE_NETO * (double)(row.PORCENTAJE_IEPS / 100));

                //        double precioVenta = (row.PRECIO_FARMACIA / (1 + (row.PORCENTAJE_IEPS / 100)));
                //        row.IMPORTE_IEPS = (precioVenta * row.CANT_FACTURADA) * (row.PORCENTAJE_IEPS / 100);

                //        Compra.IEPS_FACTURA += (decimal)row.IMPORTE_IEPS;
                //        Compra.TOT_IEPS_REC += (decimal)(precioVenta * row.CANT_RECIBIDA * (row.PORCENTAJE_IEPS / 100));

                //        decimal cantidadDevolucion = cantidadFaltante;

                //        Compra.TOTAL_IEPS_DESCTO_REC += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((cantidadDevolucion * (decimal)precioVenta) * (decimal)(row.PORCENTAJE_IEPS / 100)));

                //        // Compra.MAL_OFERTADO += ((dor + d1) - (dof + df1));

                //        row.IEPS_MAL = (double)Compra.MAL_OFERTADO * (double)(row.PORCENTAJE_IEPS / 100f);
                //        Compra.IMP_IEPS_MAL += (decimal)row.IEPS_MAL;

                //    }
                //}

                recibeL.SetRecepcionCompra(row);

                if (double.IsInfinity(row.COSTO_NETO_UNIT_REC))
                {
                    row.COSTO_NETO_UNIT_REC = 0;
                }
            }
            Compra.TOT_IMPORTE_REC = Compra.TOT_IMPORTE_REC;

            //foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row in compraL.CompraDetalles.Rows)
            //{
            //    decimal importeFacturaD = row.PRECIO_FACTURA * row.CANT_SOLICITADA;
            //    importeFactura += importeFacturaD;
            //    //descuentoFactura += importeFactura * (row.DESCTO_FACTURA / 100) * (row.DESCTO_FACTURA_AD1 / 100);

            //    decimal descuentoF = importeFacturaD * (row.DESCTO_FACTURA_AD1 / 100);
            //    importeFacturaD -= descuentoF;
            //    //decimal descuentoAd = (importeFacturaD - descuentoF) * (row.DESCTO_FACTURA / 100);
            //    decimal descuentoAd = (importeFacturaD) * (row.DESCTO_FACTURA / 100);
            //    importeFacturaD -= descuentoAd;

            //    if (row.DESCTO_FACTURA == 0 && row.DESCTO_RECIBIDO > 0)
            //    {
            //        sinOferta += importeFacturaD;
            //    }

            //    if (row.FacturaProveedorDetalle != null)
            //    {
            //        if (row.FacturaProveedorDetalle.IVA > 0)
            //        {
            //            decimal ivaUnitario = row.FacturaProveedorDetalle.IVA / row.CANT_FACTURADA;

            //            decimal ivaDescuento = descuentoAd * 1.16m;
            //            ivaDescuento = ivaDescuento - descuentoAd;
            //            ivaSinDescuento += row.FacturaProveedorDetalle.IVA;
            //            ivaFactura += ivaDescuento;
            //        }
            //    }
            //    descuentoFactura += descuentoF + descuentoAd;

            //    //TOTALES DE ORDEN DE COMPRA
            //    decimal importeOCD = row.PRECIO_FACTURA * row.CANT_RECIBIDA;


            //    //DESCUENTOS ADICIONALES
            //    decimal costoNetoUnitarioDescto = row.PRECIO_COSTO * (1 - row.DESCTO_RECIBIDO / 100);
            //    costoNetoUnitarioDescto = costoNetoUnitarioDescto * (1 - row.DESCTO_RECIBIDO_AD1 / 100);
            //    totalNetoRecibido += row.PRECIO_COSTO * row.CANT_RECIBIDA;

            //    //MAL OFERTADO
            //    decimal costoDescuentoFactura = row.PRECIO_COSTO * (row.DESCTO_FACTURA / 100);
            //    costoDescuentoFactura += (costoDescuentoFactura * (row.DESCTO_FACTURA_AD1 / 100));
            //    decimal costoDescuentoRecepcion = (row.PRECIO_COSTO * (row.DESCTO_RECIBIDO / 100));
            //    costoDescuentoRecepcion += (costoDescuentoRecepcion * (row.DESCTO_RECIBIDO_AD1 / 100));

            //    decimal malOfertadoUnitario = (costoDescuentoRecepcion - costoDescuentoFactura);
            //    malOfertado += malOfertadoUnitario * row.CANT_RECIBIDA;

            //    //decimal descto = (costoNetoUnitarioDescto * (row.DESCTO_RECIBIDO_AD1 / 100));
            //    //decimal descto1 = (descto * (row.DESCTO_RECIBIDO / 100));
            //    decimal descto2 = (costoNetoUnitarioDescto * (1 - row.DESCTO_RECIBIDO_AD2 / 100));
            //    decimal descto3 = (descto2 * (1 - row.DESCTO_RECIBIDO_AD3 / 100));
            //    decimal descto4 = (descto3 * (1 - row.DESCTO_RECIBIDO_AD4 / 100));

            //    descuentoRecibido += descto4 * row.CANT_RECIBIDA;
            //    //  malOfertado += descto - descuentoF; 

            //    decimal costoNetoUnitario = row.PRECIO_FACTURA * (1 - (row.DESCTO_RECIBIDO / 100)) * (1 - (row.DESCTO_RECIBIDO_AD1 / 100));
            //    importeOrdenCompra += costoNetoUnitario * row.CANT_RECIBIDA;


            //    if (row.FacturaProveedorDetalle != null)
            //    {
            //        if (row.FacturaProveedorDetalle.IVA > 0)
            //        {
            //            decimal ivaUnitario = row.FacturaProveedorDetalle.IVA / row.CANT_FACTURADA;
            //            ivaUnitario = ivaUnitario * row.CANT_RECIBIDA;
            //            decimal ivaDescuento = descuentoAd * 1.16m;
            //            ivaDescuento = ivaDescuento - descuentoAd;
            //            ivaSinDescuentoRecibido += row.FacturaProveedorDetalle.IVA;
            //            ivaRecibido += ivaDescuento;
            //        }
            //    }
            //    //descuentoRecibido += descto + descto1 + descto2 + descto3 + descto4;



            //    //ivaRecibido += importeOrdenCompra * row.coniva
            //}


            SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow factura = new SIFNegocio.OrdenCompra.OrdenCompra().FacturaPorNumero(OrdenCompra);// new SIFNegocio.OrdenCompra.OrdenCompra().BuscaCompras(this.OrdenCompra);
            //if (factura != null)
            //{
            //    ivaFactura = factura.TOTAL_IVA;
            //}


            //ivaFactura = ivaSinDescuento - ivaFactura;
            // Compra.TOT_IVA_REC  = ivaSinDescuentoRecibido - Compra.TOT_IVA_REC;
            Compra.TOT_FACTURA = Compra.TOT_FACT_RECIBIDO - Compra.DESCUENTO_FACTURA + Compra.IVA_FACTURA;
            Compra.TOTAL_RECIBIDO = Compra.TOT_IMPORTE_REC; // - Compra.TOT_DESCTO_REC + Compra.TOT_IVA_REC;
            //totalOrdenCompra = Compra.TOT_IMPORTE_REC - Compra.TOT_DESCTO_REC + Compra.TOT_IVA_REC;


            //ESTABLECER ORDEN DE COMPRA

            //END ESTABLECER ORDEN DE COMPRA

            recibeL.SetRecepcionCompraTot(Compra);
            Compra = recibeL.GetRecepcionCompraTot(Compra);

            Compra.IMP_DESC_AD1 = compraL.CompraDetalles.Sum(d => d.RES_CAL3_DESCTOAD1);
            Compra.IMP_DESC_AD2 = compraL.CompraDetalles.Sum(d => d.RES_CAL4_DESCTOAD2);
            Compra.IMP_DESC_AD3 = compraL.CompraDetalles.Sum(d => d.RES_CAL5_DESCTOAD3);
            Compra.IMP_DESC_AD4 = compraL.CompraDetalles.Sum(d => d.RES_CAL6_DESCTOAD4);

            //INCIDENCIAS&
            Compra.IMP_FALTANTE = (decimal)compraL.CompraDetalles.Sum(d => d.CANT_DEV_FALTANTE * d.COSTO_NETO_UNIT_REC);
            Compra.MAL_ESTADO = (decimal)compraL.CompraDetalles.Sum(d => d.CANT_MALESTADO * d.COSTO_NETO_UNIT_REC);
            Compra.NO_PEDIDO = (decimal)compraL.CompraDetalles.Sum(d => d.CANT_DEV_NO_PEDIDO * d.COSTO_NETO_UNIT_REC);
            Compra.PROX_CADUCAR = (decimal)compraL.CompraDetalles.Sum(d => d.CANT_PROX_CADUCAR * d.COSTO_NETO_UNIT_REC);
            Compra.PREC_ELEVADO = (decimal)compraL.CompraDetalles.Sum(d => d.CANT_DEV_PRECIO_ELEVADO * d.COSTO_NETO_UNIT_REC);
            Compra.MAL_OFERTADO = (decimal)compraL.CompraDetalles.Sum(d => d.IMP_DESCTO_SINIVA);


            //IMPUESTOS INCIDENCIAS
            Compra.TOTAL_IVA_DESCTO_REC = (decimal)compraL.CompraDetalles.Sum(d => d.DIF_DESCTO_IVA);

            // Compra. = (decimal)compraL.CompraDetalles.Sum(d => d.CANT_DEV_FALTANTE * d.PRECIO_FACTURA);


            bool actualizaPrecios=false, CostoPrecio=true;

            AsignacionPreciosFinalizaForm frmAsigna = new AsignacionPreciosFinalizaForm(OrdenCompra, Compra); //new AsignacionPreciosFinalizaForm(OrdenCompra, Compra.TOT_FACT_RECIBIDO, Compra.DESCUENTO_FACTURA, Compra.IVA_FACTURA, Compra.TOT_FACTURA, Compra.TOT_IMPORTE_REC, Compra.TOT_DESCTO_REC, Compra.TOT_IVA_REC, Compra.TOTAL_RECIBIDO, Compra.MAL_OFERTADO, Compra.SIN_OFERTA, Compra, TotalFaltante, TotalMalestado, TotalNoPedido, TotalPrioximoCaducar, TotalPrecioElevado, totalDescto2, totalDescto3, totalDescto4, TotalNoLlego, Compra.IMP_IVA_MAL);
            if (frmAsigna.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            try
            {
                foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row in compraL.CompraDetalles.Rows)
                {
                    row.NUEVO_FLEMING = Math.Round(row.NUEVO_FLEMING, 1);
                    row.FOLIO_COMPRA = Compra.FOLIO_COMPRA;

                    if (row.MAL_OFERTADO > 0)
                    {
                        row.FLAG_MAL_OFERTADO = "S";
                    }

                    //  SIFNegocio.OrdenCompra.Compras.GuardaDetalle(row);
                }

             

            }
            catch
            {
               MessageBox.Show("Ocurrió un error al realizar la compra", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //double costoComparar;
            //if (Double.TryParse(txt.Text, out costoComparar))
            this.UseWaitCursor = true;
            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row in compraL.CompraDetalles.Rows)
            {
                row.FOLIO_COMPRA = Compra.FOLIO_COMPRA;
               // double costoFinal = row.IMP_DESCTO_SINIVA + row.IMPORTE_IEPS + row.IMPORTE_IVA;

                double desc = 0, COSTO_NETO_UNIT_ORI = row.COSTO_NETO_UNIT_REC;
                if (row.PORC_DESCTO_AD1 > 0)
                { 
                    desc=100-row.PORC_DESCTO_AD1;
                    desc = desc / 100;
                    row.COSTO_NETO_UNIT_REC = row.COSTO_NETO_UNIT_REC * desc;
                }
                if (row.PORC_DESCTO_AD2 > 0)
                {
                    desc = 100 - row.PORC_DESCTO_AD2;
                    desc = desc / 100;
                    row.COSTO_NETO_UNIT_REC = row.COSTO_NETO_UNIT_REC * desc;
                }
                if (row.PORC_DESCTO_AD3 > 0)
                {
                    desc = 100 - row.PORC_DESCTO_AD3;
                    desc = desc / 100;
                    row.COSTO_NETO_UNIT_REC = row.COSTO_NETO_UNIT_REC * desc;
                }

                if (row.NUEVO_FLEMING < row.COSTO_NETO_UNIT_REC)//row.COSTO)
                {
                    row.COSTO_NETO_UNIT_REC = COSTO_NETO_UNIT_ORI;
                    this.UseWaitCursor = false;
                   MessageBox.Show("El nuevo precio fleming no puede ser menor al nuevo costo " + Environment.NewLine + "Codigo: " + row.ARTICULO_ID + " Nombre: " + row.NOMBRE + " " + Environment.NewLine + " Nuevo Precio Fleming: " + row.NUEVO_FLEMING + " Costo:" + double.Parse(this.costoIEPSTextBoxX.Text), "Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                foreach (var detalle in compraL.CompraDetalles)
                {
                    if (detalle.ARTICULO_ID == row.ARTICULO_ID)
                        detalle.COSTO_NETO_UNIT_REC = row.COSTO_NETO_UNIT_REC;
                }

                //  SIFNegocio.OrdenCompra.Compras.GuardaDetalle(row);
            }
            SIFNegocio.OrdenCompra.Compras.ActualizaDetalles(Compra, compraL.CompraDetalles);


            ///Se comenta estalinea por que no queremos que afecte la existencia hasta que capturen lote y caducidad
            ///itacma 27/09/2021 integracion para lote y caducidad
            //actualizaPrecios = SIFNegocio.OrdenCompra.Compras.ActualziarRecepcionPrecios(Compra);

            this.UseWaitCursor = false;
            actualizaPrecios = true;
              if (actualizaPrecios == true)
              {
                  OrdenCompra.ESTADO_OC = "AC";//itacma 27/09/2021 integracion para lote y caducidad //OrdenCompra.ESTADO_OC = "L";

                // compra.TOTAL_DESCTO_DESCUENTOS_REC = (double)descuentoGeneralNumericUpDown.Value;
                // ordenCompraL.ActualizaOrdenCompra(compra);

                ordenCompraL.ActualizaOrdenCompra(this.OrdenCompra);
                  //foreach (SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow row in ordenCompraL.OrdenCompraDetalles)
                  //{
                  //    if (!ordenCompraL.Recibe(row))
                  //    {
                  //       MessageBox.Show("Ocurrió un error al actualizar la orden de compra de " + row.ARTICULO_ID + " [" + row.NOMBRE + "]");
                  //        return;
                  //    }
                  //}

                // MessageBox.Show("Se han asignado los precios correctamente");


                  GridRow grow = superGridControl1.ActiveRow as GridRow;
                  if (grow.RowIndex < superGridControl1.PrimaryGrid.LastSelectableRow.RowIndex)
                  {
                      superGridControl1.PrimaryGrid.SetActiveRow(superGridControl1.PrimaryGrid.Rows[grow.RowIndex + 1] as GridContainer);
                  }



                  //  SIFModelo.OrdenCompra.OrdenesCompraDataSet.COMPRASRow compra = new SIFModelo.OrdenCompra.OrdenesCompraDataSet().COMPRAS.NewCOMPRASRow();
                  // Compra.FOLIO_COMPRA = SIFNegocio.OrdenCompra.Compras.FolioCompra(Helpers.Sesion.Sucursal);
                  Compra.FOLIO_OC = OrdenCompra.FOLIO_OC_ID;
                  Compra.PROVEEDOR_ID = OrdenCompra.PROVEEDOR_ID;
                  //compra.factura	          			    =  factura;
                  //compra.folio_factura_sat			        = faltante;
                  Compra.TOT_IMPORTE_REC = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(Compra.TOT_IMPORTE_REC);
                  Compra.TOT_DESCTO_REC = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(Compra.TOT_DESCTO_REC);
                  Compra.TOT_IVA_REC = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(Compra.TOT_IVA_REC);
                  Compra.TOTAL_RECIBIDO = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(Compra.TOTAL_RECIBIDO);
                  Compra.TOTAL_NETO_RECIBIDO = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(Compra.TOTAL_NETO_RECIBIDO);
                  Compra.TOT_DESCTO_SINIVA_REC = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((Compra.TOT_DESCTO_REC - Compra.TOT_IVA_REC));
                  Compra.TOT_DESCTO_CONIVA_REC = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((Compra.TOT_DESCTO_REC + Compra.TOT_IVA_REC));
                  Compra.TOTAL_IVA_DESCTO_REC = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(Compra.TOTAL_IVA_DESCTO_REC);
                  Compra.TOTAL_DESCTO_DESCUENTOS_REC = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((Compra.TOT_DESCTO_SINIVA_REC) + (Compra.TOT_DESCTO_CONIVA_REC) + (Compra.TOTAL_IVA_DESCTO_REC));
                  Compra.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                  Compra.ACTIVO = "S";
                  Compra.USUARIO_ID = int.Parse(OrdenCompra.USUARIO_ID);
                  Compra.USUARIO_ID_ASIG_PRECIO = this.UsuarioId.ToString();
                  Compra.IMP_FALTANTE = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(Compra.IMP_FALTANTE);
                  Compra.IMP_DESC_FALTANTE = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(Compra.IMP_DESC_FALTANTE);
                  Compra.IMP_IVA_MAL = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(Compra.IMP_IVA_MAL);

                  //SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow factura = new SIFNegocio.OrdenCompra.OrdenCompra().FacturaPorNumero(OrdenCompra);// new SIFNegocio.OrdenCompra.OrdenCompra().BuscaCompras(this.OrdenCompra);
                  if (factura != null)
                  {
                      Compra.FACTURA = factura.NUM_FACTURA;
                      Compra.FOLIO_FACTURA_SAT = factura.FOLIO_FACTURA_SAT;
                      Compra.TOT_FACTURA = factura.TOTAL_NETO_FACTURA;
                  }
                  else
                  {
                      Compra.FACTURA = frmAsigna.facturaTextBox.Text;
                      Compra.FOLIO_FACTURA_SAT = frmAsigna.uuidTextBoxX.Text;

                      if (string.IsNullOrEmpty(Compra.FACTURA))
                      {
                          Compra.FACTURA = "-";
                      }

                      if (string.IsNullOrEmpty(Compra.FOLIO_FACTURA_SAT))
                      {
                          Compra.FOLIO_FACTURA_SAT = "-";
                      }
                  }

                  try
                  {
                      SIFNegocio.OrdenCompra.Compras.Guardar(Compra, compraL.CompraDetalles);
                  }
                  catch(Exception e)
                  {
                     MessageBox.Show("Ocurrió un error al insertar la compra: "+e.ToString(), "Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                      return;
                  }
                //MessageBoxEx.Show("Se realizó la compra " + Compra.FOLIO_COMPRA, "Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
               MessageBox.Show("La orden de compra " + Compra.FOLIO_COMPRA+", esta lista para asignar caducidades", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Back();
              }
            else
                  this.Back();

            //        row.IMPORTE = row.CANT_RECIBIDA * row.PRECIO_COSTO;
            //        SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow detC = new SIFModelo.OrdenCompra.OrdenCompraDataSet().COMPRAS_DET.NewCOMPRAS_DETRow();
            //        row.FOLIO_OC_ID = compra.FOLIO_COMPRA;
            //        detC.FOLIO_COMPRA = compra.FOLIO_COMPRA;
            //        detC.FOLIO_OC = row.FOLIO_OC_ID;
            //        detC.PROVEEDOR_ID = row.PROVEEDOR_ID;
            //        detC.ARTICULO_ID = row.ARTICULO_ID;
            //        detC.NOMBRE = row.NOMBRE;
            //        detC.PRECIO_FARM_REC = row.PRECIO_FARMACIA;
            //        detC.CANT_RECIBIDA = row.CANT_RECIBIDA;
            //        detC.CANT_DEVUELTA = row.CANT_DEVUELTA;
            //        detC.CANT_MALESTADO = row.CANT_MALESTADO;
            //        detC.CANT_REPOSICION = row.CANT_REPOSICION;
            //        detC.PORC_OFERTA = row.DESCTO_RECIBIDO;
            //        detC.PORC_DESCTO = row.DESCTO_RECIBIDO_AD1;
            //        detC.PORC_DESCTO_AD1 = row.DESCTO_RECIBIDO_AD1;
            //        detC.PORC_DESCTO_AD2 = row.DESCTO_RECIBIDO_AD2;
            //        detC.PORC_DESCTO_AD3 = row.DESCTO_RECIBIDO_AD3;
            //        detC.PORC_DESCTO_AD4 = row.DESCTO_RECIBIDO_AD4;
            //        detC.IMP_OFERTA_SINIVA = row.DESCTO_RECIBIDO - row.FacturaProveedorDetalle.IVA;
            //        detC.IMP_OFERTA_CONIVA = row.PRECIO_COSTO;
            //        detC.IMP_DESCTO_SINIVA = row.DESCTO_RECIBIDO - row.FacturaProveedorDetalle.IVA;
            //        detC.IMP_DESCTO_CONIVA = row.PRECIO_COSTO;
            //        detC.IMPORTE_IVA = row.FacturaProveedorDetalle.IVA;
            //        detC.IMP_DESCTO_CONIVA_MENOSIVA = row.IMPORTE - row.DESCTO_RECIBIDO;
            //        detC.IMP_RECEPCION_CONIVA = row.IMPORTE;
            //        detC.IMP_RECEPCION_SINIVA = row.IMPORTE;
            //        detC.IMP_CAL1_OFERTA_CONIVA = row.IMPORTE;
            //        detC.IMP_CAL1_OFERTA_SINIVA = row.IMPORTE;
            //        detC.RES_CAL1_DESCTO = row.DESCTO_RECIBIDO;
            //        detC.RES_CAL2_OFERTA = row.DESCTO_RECIBIDO_AD1;
            //        detC.RES_CAL3_DESCTOAD1 = (double)row.DESCTO_RECIBIDO_AD1;
            //        detC.RES_CAL4_DESCTOAD2 = (double)row.DESCTO_RECIBIDO_AD2;
            //        detC.RES_CAL5_DESCTOAD3 = (double)row.DESCTO_RECIBIDO_AD3;
            //        detC.RES_CAL6_DESCTOAD4 = (double)row.DESCTO_RECIBIDO_AD4;
            //        detC.COSTO_NETO_UNIT_REC = (double)row.PRECIO_COSTO;
            //        detC.IMPORTE_NETO = (double)(row.PRECIO_COSTO * row.CANT_RECIBIDA);
            //        detC.DIF_DESCTO_IVA = (double)row.DESCTO_RECIBIDO_AD1;
            //        detC.FLAG_MAL_OFERTADO = "S";
            //        detC.DESCUENTO_GENERAL = (float)row.DESCUENTO_GENERAL;






            //        SIFNegocio.OrdenCompra.Compras.GuardaDetalle(detC);
            //    }

            //}
            //catch
            //{

            //}
        }

        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            //this.EstableceOrdenCompra();
        }

        public object Owner { get; set; }

        internal void Muestra()
        {
            if (Owner is View.OrdenCompra.AsignacionPreciosOrdenCompraUserControl)
            {
                View.OrdenCompra.AsignacionPreciosOrdenCompraUserControl propietario = Owner as View.OrdenCompra.AsignacionPreciosOrdenCompraUserControl;
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;
                this.Mostrado = true;

                propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            }

            if (Owner is View.OrdenCompra.OrdenesCompraUserControl)
            {
                View.OrdenCompra.OrdenesCompraUserControl propietario = Owner as View.OrdenCompra.OrdenesCompraUserControl;
                SIF.View.Menu.ComprasMenu propietarioOwner = propietario.Owner as SIF.View.Menu.ComprasMenu;
                propietarioOwner.DesactivaComandos();
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;
                this.Mostrado = true;

                propietarioOwner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            }
        }

        private void Back()
        {
            this.Actualiza();
            try
            {
                if (this.Owner is View.OrdenCompra.AsignacionPreciosOrdenCompraUserControl)
                {
                    View.OrdenCompra.AsignacionPreciosOrdenCompraUserControl propietario = Owner as View.OrdenCompra.AsignacionPreciosOrdenCompraUserControl;
                    if (this.Mostrado && propietario.Owner.Owner.IsModalPanelDisplayed)
                    {
                        if (propietario.Owner.Owner.Contains(this))
                        {
                            propietario.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        propietario.ActivaComandos();
                        this.Mostrado = false;
                        this.DesactivaComandos();
                    }
                }

                if (this.Owner is View.OrdenCompra.OrdenesCompraUserControl)
                {
                    View.OrdenCompra.OrdenesCompraUserControl propietario = Owner as View.OrdenCompra.OrdenesCompraUserControl;
                    SIF.View.Menu.ComprasMenu propietarioOwner = propietario.Owner as SIF.View.Menu.ComprasMenu;

                    if (propietarioOwner.Owner.Contains(this))
                    {
                        propietarioOwner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    propietario.ActivaComandos();
                    this.Mostrado = false;
                    this.DesactivaComandos();
                    propietario.Buscar();
                }

            }
            catch { }

        }

        public void ActivaComandos()
        {
            this.backButton.Shortcuts.Add(eShortcut.F12);
            this.recibirButtonItem.Shortcuts.Add(eShortcut.F8);
            this.guardarButtonItem.Shortcuts.Add(eShortcut.F5);
            this.agregaProductoButtonItem.Shortcuts.Add(eShortcut.F4);
        }

        public void DesactivaComandos()
        {
            this.backButton.Shortcuts.Clear();
            this.recibirButtonItem.Shortcuts.Clear();
            this.guardarButtonItem.Shortcuts.Clear();
            this.agregaProductoButtonItem.Shortcuts.Clear();
        }

        public bool Mostrado { get; set; }

        public int UsuarioId { get; set; }

        private void recibirButtonItem_Click(object sender, EventArgs e)
        {
            this.RecibirOrdenCompra();
        }

        private void buscarTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.buscarLocal();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.buscarLocal();
            }
        }



        private void superGridControl1_EndEdit(object sender, DevComponents.DotNetBar.SuperGrid.GridEditEventArgs e)
        {
            SuperGridControl grid = sender as SuperGridControl;
            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row = null;
            if (e.GridCell.GridRow.DataItem is SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow)
            {
                row = (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow)(e.GridCell.GridRow.DataItem);
            }
            if (e.GridCell.GridRow.DataItem is DataRowView)
            {
                row = (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow)((DataRowView)(e.GridCell.GridRow.DataItem)).Row;
            }
            if (e.GridCell.GridRow.DataItem is BindingSource)
            {
                row = (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow)(((DataRowView)((BindingSource)(e.GridCell.GridRow.DataItem)).Current).Row);
            }


            if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_FACTURADA).Name)
            {
                if (row.CANT_FACTURADA > row.CANT_SOLICITADA)
                {
                    MessageBox.Show("La cantidad de la factura es mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_RECIBIDA).Name)
            {
                if (row.CANT_RECIBIDA > row.CANT_SOLICITADA)
                {
                    MessageBox.Show("La cantidad recibida es mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_MALESTADO).Name)
            {
                if (row.CANT_MALESTADO > row.CANT_SOLICITADA)
                {
                    MessageBox.Show("La cantidad en mal estado es mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_PROX_CADUCAR).Name)
            {
                if (row.CANT_PROX_CADUCAR > row.CANT_SOLICITADA)
                {
                    MessageBox.Show("La cantidad devuelta es mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_REPOSICION).Name)
            {
                if (row.CANT_REPOSICION > row.CANT_SOLICITADA)
                {
                    MessageBox.Show("La cantidad repuesta es mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_REPOSICION).Name)
            {
                if (row.CANT_REPOSICION > row.CANT_SOLICITADA)
                {
                    MessageBox.Show("La cantidad repuesta es mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            //int cantRecibida = row.CANT_FACTURADA;

            //if (cantRecibida == 0)
            //{
            //    cantRecibida = row.CANT_SOLICITADA;
            //}

            //    row.CANT_RECIBIDA = cantRecibida - row.CANT_DEV_FALTANTE - row.CANT_DEV_NO_PEDIDO - row.CANT_DEV_PRECIO_ELEVADO - row.CANT_MALESTADO - row.CANT_PROX_CADUCAR;


            // row.CANT_RECIBIDA = row.CANT_FACTURADA - row.CANT_DEV_FALTANTE - row.CANT_DEV_NO_PEDIDO - row.CANT_DEV_PRECIO_ELEVADO - row.CANT_MALESTADO - row.CANT_PROX_CADUCAR;
            e.GridCell.GridRow.Cells["CANT_RECIBIDAColumn"].Value = row.CANT_RECIBIDA;
            this.calculaTotalDetalle(row);
            this.pintaFila(e.GridCell.GridRow);
        }

        private string propiedadBusqueda;
        private void superGridControl1_ColumnHeaderClick(object sender, GridColumnHeaderClickEventArgs e)
        {

            //this.buscarTextBoxX.WatermarkText = "BUSCAR POR " + e.GridColumn.HeaderText;
            //this.propiedadBusqueda = e.GridColumn.DataPropertyName;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ActualizaBack();
            this.Back();
        }

        private void AsignacionPreciosOrdenCompraDetallesUserControl_Load(object sender, EventArgs e)
        {

            desctoAnteriorTextBoxX.BackColor = Color.LightGray;
            margenUtilidadAnteriorTextBox.BackColor = Color.LightGray;
            utilidadAnteriorTextBoxX.BackColor = Color.LightGray;
            descuentoTextBoxX.BackColor = Color.LightGray;
            margenTextBox.BackColor = Color.LightGray;
            utilidadTextBox.BackColor = Color.LightGray;

            //DESACTIVAR MODIFICAR PMP
            //this.recepcionMaximoPublicoTextBox.ReadOnly = true;
            this.superGridControl1.PrimaryGrid.Columns["PMPColumn"].ReadOnly = true;

            this.descuentoGeneralNumericUpDown.Select();
            this.descuentoGeneralNumericUpDown.Focus();

            this.descuentoGeneralNumericUpDown.Value = -1;// (decimal)compra.NTO_RECIBIDO;



            List<string> skOc = new List<string>();
            foreach (GridRow GridRow in superGridControl1.PrimaryGrid.Rows)
            {
                pintaFila(GridRow);

                if (GridRow == null)
                {
                    continue;
                }
                else
                {
                    skOc.Add(GridRow.Cells["ARTICULOColumn"].Value.ToString());

                }

            }

            calculaTotal();
            GetListSkuOfertasMes( skOc);
            //desctoAnteriorTextBoxX.BackColor = Color.LightGray;
            //descuentoTextBoxX.BackColor = Color.LightGray;

        }

        private void superGridControl1_Enter(object sender, EventArgs e)
        {
            //  if(sender 
        }

        private void superGridControl1_SelectionChanged(object sender, GridEventArgs e)
        {
            //foreach (GridRow GridRow in superGridControl1.PrimaryGrid.Rows)
            //{
            pintaFila(e.GridPanel.ActiveRow as GridRow);
            //}

        }

        private void calculaTotalDetalle(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow ocdr)
        {
            this.articuloLabel.Text = ocdr.ARTICULO_ID;
            nombreDetalleLabel.Text = ocdr.NOMBRE;
            lineaLabel.Text = ocdr.LABORATORIO_ID.ToString();

            if (!ocdr.IsTIPO_MEDICAMENTONull())
                this.tipo3Label.Text = ocdr.TIPO_MEDICAMENTO;
            if (ocdr.ListaPrecios == null)
            {
                //MessageBoxEx.Show("No hay una lista de precios para el artículo " + articuloLabel.Text);
                ocdr.ListaPrecios = new SIFModelo.Inventarios.ListaPrecios();
                ocdr.ListaPrecios.PRECIO_VENTA_MAX = (decimal)ocdr.PRECIO_MAXIMO;
                ocdr.ListaPrecios.PRECIO_VENTA = (decimal)ocdr.PRECIO_VENTA;
                ocdr.ListaPrecios.COSTO_PROM = (decimal)ocdr.PRECIO_VENTA;
                // return;
            }

            if (ocdr.PRECIO_MAXIMO > 0 && ocdr.ListaPrecios.PRECIO_VENTA_MAX == 0)
            {
                ocdr.ListaPrecios.PRECIO_VENTA_MAX = (decimal)ocdr.PRECIO_MAXIMO;
            }

            int cantRecibida = ocdr.CANT_FACTURADA;

            if (cantRecibida == 0)
            {
                cantRecibida = ocdr.CANT_SOLICITADA;
            }

            //      ocdr.CANT_RECIBIDA = cantRecibida; // - ocdr.CANT_DEV_FALTANTE - ocdr.CANT_DEV_NO_PEDIDO - ocdr.CANT_DEV_PRECIO_ELEVADO - ocdr.CANT_MALESTADO - ocdr.CANT_PROX_CADUCAR;


            //ocdr.CANT_RECIBIDA = (int)ocdr.CANT_FACTURADA - (int)ocdr.CANT_MALESTADO - (int)ocdr.CANT_PROX_CADUCAR - (int)ocdr.CANT_REPOSICION;

            this.farmaciaActualTextBox.Text = ocdr.ListaPrecios.PRECIO_VENTA_FARM.ToString("C2");
            this.flemingActualTextBox.Text = ocdr.ListaPrecios.PRECIO_VENTA.ToString("C2");
            this.maximoPublicoActualTextBox.Text = ocdr.ListaPrecios.PRECIO_VENTA_MAX.ToString("C2");
            this.promedioActualTextBox.Text = ocdr.ListaPrecios.COSTO_PROM.ToString("C2");
            this.IVATextBox.Text = "0";
            this.iepsTextBoxX.Text = "0";

            //DESCUENTOS
            if (ocdr.FacturaProveedorDetalle != null)
            {
                if (ocdr.FacturaProveedorDetalle.IsPORC_OFERTANull())
                {
                    ocdr.FacturaProveedorDetalle.PORC_OFERTA = 0;
                }
                facturaDescuentoTextBox.Text = ocdr.FacturaProveedorDetalle.PORC_OFERTA.ToString("0.00");
            }

            this.recepcionOfertaRealTextBox.Text = ocdr.PORC_OFERTA.ToString("0.00");
            facturaDescuentoTextBox.Text = recepcionOfertaRealTextBox.Text;
            this.recepcionFinancieroTextBox.Text = ocdr.PORC_DESCTO.ToString("0.00");
            facturaFinancieroTextBox.Text = recepcionFinancieroTextBox.Text;
            this.recepcionDescuentoAdicional1TextBox.Text = ocdr.PORC_DESCTO_AD1.ToString("0.00");
            this.recepcionDescuentoAdicional2TextBox.Text = ocdr.PORC_DESCTO_AD2.ToString("0.00");
            this.recepcionDescuentoAdicional3TextBox.Text = ocdr.PORC_DESCTO_AD3.ToString("0.00");

            //CALCULAMOS TODO LO ANTERIOR
            decimal porcentajeDescuento = 0;
            if (ocdr.PRECIO_MAXIMO > 0)
                porcentajeDescuento = 1 - ((decimal)ocdr.NUEVO_FLEMING / (decimal)ocdr.PRECIO_MAXIMO);
            porcentajeDescuento = porcentajeDescuento * 100;
            desctoAnteriorTextBoxX.Text = porcentajeDescuento.ToString("0.00");

            decimal porcentajeUtilidadAnterior = 0;
            if (ocdr.ListaPrecios.PRECIO_COSTO > 0)
            {
                porcentajeUtilidadAnterior = (ocdr.ListaPrecios.PRECIO_VENTA / ocdr.ListaPrecios.PRECIO_COSTO) - 1;
            }


            porcentajeUtilidadAnterior = porcentajeUtilidadAnterior * 100;
            decimal montoUtilidad = ocdr.ListaPrecios.PRECIO_VENTA - ocdr.ListaPrecios.PRECIO_COSTO;

            this.margenUtilidadAnteriorTextBox.Text = porcentajeUtilidadAnterior.ToString("0.00");
            utilidadAnteriorTextBoxX.Text = montoUtilidad.ToString("C2");

            //

            if (ocdr.FacturaProveedorDetalle != null)
            {
                if (!ocdr.FacturaProveedorDetalle.IsIVANull())
                {
                    if (ocdr.FacturaProveedorDetalle.IVA > 0)
                    {
                        ocdr.PORC_IVA = (double)(ocdr.FacturaProveedorDetalle.IVA / ocdr.CANT_FACTURADA) / ocdr.PRECIO_FACTURA;
                        ocdr.PORC_IVA = (double)SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(ocdr.PORC_IVA * 100);
                        ocdr.PORC_IVA = 16;
                        //IVATextBox.Text = (ocdr.IMPORTE_IVA / ocdr.CANT_RECIBIDA).ToString("0.00");
                        //iepsTextBoxX.Text = (ocdr.IMPORTE_IEPS / ocdr.CANT_RECIBIDA).ToString("0.00");
                        //impuestoTextBoxX.Text = ((ocdr.IMPORTE_IVA / ocdr.CANT_RECIBIDA) + (ocdr.IMPORTE_IEPS / ocdr.CANT_RECIBIDA)).ToString("0.00");
                        //cantidadDevueltaTextBox.Text = ocdr.CANT_RECIBIDA.ToString("0");
                    }

                    ocdr.COSTO_NETO_UNIT_REC = (double)SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(ocdr.PRECIO_FARMACIA * (double)(1 - ((decimal)ocdr.PORC_OFERTA / 100m)) * (double)(1 - ((decimal)ocdr.PORC_DESCTO / 100m)));
                    ocdr.IMPORTE_NETO = ocdr.COSTO_NETO_UNIT_REC * ocdr.CANT_RECIBIDA;
                    ocdr.IMPORTE_IVA = ((double)ocdr.COSTO_NETO_UNIT_REC * (ocdr.PORC_IVA / 100));
                }
                else
                {
                    ocdr.PORC_IVA = 0;
                }


            }

            decimal totalIESPS = (decimal)compraL.CompraDetalles.Sum(d => d.IMPORTE_IEPS);

            iepsTextBoxX.Text = totalIESPS.ToString("0.00");

            //RECIBO DE LA ORDEN DE COMPRA
            //this.maximoPublicoRecepcionTextBox.Text = ocdr.PRECIO_VENTA_FARM.ToString("C2");

            descuentoTextBoxX.Text = ocdr.DESCUENTO_GENERAL.ToString("0.00");

            this.recepcionFarmaciaTextBox.Text = ocdr.PRECIO_FARMACIA.ToString("###,###.####");
            facturaFarmaciaTextBox.Text = recepcionFarmaciaTextBox.Text;

            this.recepcionMaximoPublicoTextBox.Text = ocdr.PRECIO_MAXIMO.ToString("0.00");

            //FACTURA
            this.OrdenCompra.FOLIO_OC_ID = ocdr.FOLIO_OC;
            bool facturaAsignada = false;

            facturaMaximoPublicoTextBox.BackColor = Color.White;

            if (ocdr.FacturaProveedorDetalle != null)
            {
                facturaAsignada = true;
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETRow facturaDetalle = ocdr.FacturaProveedorDetalle;

                // detalle.CANT_FACTURADA = facturaDetalle.PZA_CCARGO;

                this.facturaMaximoPublicoTextBox.Text = facturaDetalle.PRECIO_VENTA_MAX.ToString("0.00");

                if (facturaDetalle.IsPRECIO_VENTA_FARNull())
                {
                    facturaDetalle.PRECIO_VENTA_FAR = (decimal)ocdr.PRECIO_FARMACIA;
                }
                facturaDetalle.PRECIO_VENTA_FAR = (decimal)ocdr.PRECIO_FACTURA;
                ocdr.PRECIO_FACTURA = (double)facturaDetalle.PRECIO_VENTA_FAR;

                // Debug.Assert(ocdr.PRECIO_FACTURA > 0);

                //ocdr.DESCTO_FACTURA = (decimal)facturaDetalle.PORC_DESCTO;
                //if (ocdr.DESCTO_FACTURA_AD1 == 0)
                //{
                //    ocdr.DESCTO_FACTURA_AD1 = (decimal)facturaDetalle.PORC_OFERTA;
                //}
                //detalle.CANT_FACTURADA = facturaDetalle.C

                this.facturaFarmaciaTextBox.Text = facturaDetalle.PRECIO_VENTA_FAR.ToString("C2");
                this.facturaDescuentoTextBox.Text = facturaDetalle.PORC_OFERTA.ToString("0.00");

                facturaFinancieroTextBox.Text = facturaDetalle.PORC_DESCTO.ToString("0.00");


                ////decimal calcOferta = (decimal)facturaDetalle.PRECIO_VENTA_FAR - (decimal)facturaDetalle.PRECIO_VENTA_FAR * (facturaDetalle.PORC_DESCTO / 100M);

                ////if (ocdr.FacturaProveedorDetalle.PZA_CCARGO > 0)
                ////{
                ////    ocdr.IMP_OFERTA_CONIVA = (double)(ocdr.FacturaProveedorDetalle.IMP_CAL_OFERTA_CIVA / ocdr.FacturaProveedorDetalle.PZA_CCARGO) * ocdr.CANT_RECIBIDA;
                ////    ocdr.IMP_OFERTA_SINIVA = (double)(ocdr.FacturaProveedorDetalle.IMP_CAL_OFERTA_SIVA / ocdr.FacturaProveedorDetalle.PZA_CCARGO) * ocdr.CANT_RECIBIDA;
                ////    ocdr.IMP_DESCTO_SINIVA = (double)(ocdr.FacturaProveedorDetalle.IMP_DESCTO_SIVA / ocdr.FacturaProveedorDetalle.PZA_CCARGO) * ocdr.CANT_RECIBIDA;
                ////    ocdr.IMP_DESCTO_CONIVA = (double)(ocdr.FacturaProveedorDetalle.IMP_DESCTO_CIVA / ocdr.FacturaProveedorDetalle.PZA_CCARGO) * ocdr.CANT_RECIBIDA;
                ////    ocdr.IMPORTE_IVA = (ocdr.COSTO_NETO_UNIT_REC * (ocdr.PORC_IVA / 100)) * ocdr.CANT_RECIBIDA;
                ////    if (ocdr.PORC_IVA > 0)
                ////    {
                ////        ocdr.IMP_DESCTO_CONIVA_MENOSIVA = (ocdr.IMP_DESCTO_CONIVA / (ocdr.PORC_IVA / 100));
                ////    }
                ////    ocdr.IMP_FACTURA_CONIVA = (double)(ocdr.FacturaProveedorDetalle.IMP_FACTURA_CIVA / ocdr.FacturaProveedorDetalle.PZA_CCARGO) * ocdr.CANT_RECIBIDA;
                ////    ocdr.IMP_FACTURA_SINIVA = (double)(ocdr.FacturaProveedorDetalle.IMP_FACTURA_SIVA / ocdr.FacturaProveedorDetalle.PZA_CCARGO) * ocdr.CANT_RECIBIDA;

                ////    ocdr.IMP_CAL1_OFERTA_CONIVA = (ocdr.IMP_FACTURA_CONIVA) - (ocdr.IMP_OFERTA_SINIVA);
                ////    ocdr.IMP_CAL1_OFERTA_SINIVA = (ocdr.IMP_FACTURA_SINIVA) - (ocdr.IMP_OFERTA_SINIVA);
                ////    ocdr.COSTO_NETO_UNIT_REC = (double)(ocdr.PRECIO_FARMACIA * (double)(1 - (ocdr.PORC_OFERTA / 100)) * (double)(1 - (ocdr.PORC_DESCTO / 100)));
                ////    ocdr.IMPORTE_NETO = ocdr.COSTO_NETO_UNIT_REC * ocdr.CANT_RECIBIDA;
                ////    ocdr.DIF_DESCTO_IVA = (double)(ocdr.IMP_DESCTO_CONIVA - ocdr.IMP_DESCTO_CONIVA_MENOSIVA);
                ////}


                ////this.facturaResultadoTextBox.Text = calcOferta.ToString("C2");

                ////if (string.IsNullOrEmpty(facturaResultadoTextBox.Text))
                ////{
                ////    facturaResultadoTextBox.Text = "$0.00";
                ////}

                //this.facturaDescuentoAdicionalTextBox.Text = facturaDetalle.PORC_OFERTA.ToString();
                //decimal adicionalFactura = descuentoFactura - (descuentoFactura * facturaDetalle.PORC_OFERTA / 100M);
                //this.facturaCostoTextBox.Text = adicionalFactura.ToString("C2");

                //recepcion
                facturaAsignada = true;



                //ocdr.PRECIO_COSTO = facturaDetalle.PRECIO_VENTA_FAR;
                //if (esPrimeraVez)
                //{
                //    ocdr.DESCTO_RECIBIDO = facturaDetalle.PORC_DESCTO;
                //}

                //if (esPrimeraVez)
                //{
                //    ocdr.DESCTO_RECIBIDO_AD1 = facturaDetalle.PORC_OFERTA;
                //}
                //ocdr.DESCTO_RECIBIDO_AD2 = facturaDetalle.PORC_DESCTO;

                if (ocdr.FacturaProveedorDetalle != null)
                {
                    ofertaFacturaTextBoxX.Text = ocdr.FacturaProveedorDetalle.PORC_OFERTA.ToString("0.00");
                }

                this.recepcionMaximoPublicoTextBox.Text = ocdr.PRECIO_FACTURA_MAX.ToString("0.00");
                this.recepcionFarmaciaTextBox.Text = ocdr.PRECIO_FARMACIA.ToString("0.00"); // facturaDetalle.PRECIO_VENTA_FAR.ToString("0.0000");
                facturaFarmaciaTextBox.Text = recepcionFarmaciaTextBox.Text;
                this.recepcionOfertaRealTextBox.Text = ocdr.PORC_OFERTA.ToString("0.00");
                facturaDescuentoTextBox.Text = recepcionOfertaRealTextBox.Text;
                this.recepcionFinancieroTextBox.Text = ocdr.PORC_DESCTO.ToString("0.00");
                facturaFinancieroTextBox.Text = recepcionFinancieroTextBox.Text;
                this.recepcionDescuentoAdicional1TextBox.Text = ocdr.PORC_DESCTO_AD1.ToString("0.00");
                this.recepcionDescuentoAdicional2TextBox.Text = ocdr.PORC_DESCTO_AD2.ToString("0.00");
                this.recepcionDescuentoAdicional3TextBox.Text = ocdr.PORC_DESCTO_AD3.ToString("0.00");

                double resultado = ocdr.COSTO - (ocdr.COSTO * (double)((decimal)ocdr.PORC_OFERTA / 100m));
                resultado = resultado - (resultado * (double)((decimal)ocdr.PORC_DESCTO / 100m));
                this.recepcionResultadoTextBox.Text = resultado.ToString("0.00");

                ////double adicional = resultado - (resultado * (double)((decimal)ocdr.PORC_DESCTO_AD1 / 100m));
                ////ocdr.RES_CAL3_DESCTOAD1 = adicional;
                ////adicional = adicional - (double)(adicional * (double)((decimal)ocdr.PORC_DESCTO_AD2 / 100m));
                ////ocdr.RES_CAL4_DESCTOAD2 = ocdr.RES_CAL3_DESCTOAD1 - adicional;
                ////adicional = adicional - (double)(adicional * (double)((decimal)ocdr.PORC_DESCTO_AD3 / 100m));
                ////ocdr.RES_CAL5_DESCTOAD3 = ocdr.RES_CAL4_DESCTOAD2 - adicional;
                ////adicional = adicional - (double)(adicional * (double)((decimal)ocdr.PORC_DESCTO_AD4 / 100m));
                ////ocdr.RES_CAL6_DESCTOAD4 = ocdr.RES_CAL5_DESCTOAD3 - adicional;
                ////this.recepcionCostoTextBox.Text = adicional.ToString("0.00");
                ////decimal adicionalIVA = (decimal)(adicional + (adicional * (ocdr.PORC_IVA / 100)));
                ////costoIVATextBox.Text = Math.Round(adicionalIVA, 2).ToString("0.00");
                ////ocdr.COSTO = (double)adicional;
            }
            else
            {
                ocdr.PRECIO_FACTURA_MAX = ocdr.PRECIO_MAXIMO;
                this.facturaMaximoPublicoTextBox.Text = ocdr.PRECIO_FACTURA_MAX.ToString("0.00");
                ocdr.PRECIO_FACTURA = (double)ocdr.PRECIO_FARMACIA;
                //  ocdr.PRECIO_FACTURA_MAX = 
                ////ocdr.IMP_OFERTA_CONIVA = (double)(ocdr.IMP_CAL1_OFERTA_CONIVA / ocdr.CANT_FACTURADA) * ocdr.CANT_RECIBIDA;
                ////ocdr.IMP_OFERTA_SINIVA = (double)(ocdr.IMP_CAL1_OFERTA_SINIVA / ocdr.CANT_FACTURADA) * ocdr.CANT_RECIBIDA;
                ////ocdr.IMP_DESCTO_SINIVA = (double)(ocdr.IMP_DESCTO_SINIVA / ocdr.CANT_FACTURADA) * ocdr.CANT_RECIBIDA;
                ////ocdr.IMP_DESCTO_CONIVA = (double)(ocdr.IMP_DESCTO_CONIVA / ocdr.CANT_FACTURADA) * ocdr.CANT_RECIBIDA;
                ////ocdr.IMPORTE_IVA = (ocdr.COSTO_NETO_UNIT_REC * (ocdr.PORC_IVA / 100)) * ocdr.CANT_RECIBIDA;
                ////if (ocdr.PORC_IVA > 0)
                ////{
                ////    ocdr.IMP_DESCTO_CONIVA_MENOSIVA = (ocdr.IMP_DESCTO_CONIVA / (ocdr.PORC_IVA / 100));
                ////}
                ////ocdr.IMP_FACTURA_CONIVA = (double)(ocdr.IMP_FACTURA_CONIVA / ocdr.CANT_FACTURADA) * ocdr.CANT_RECIBIDA;
                ////ocdr.IMP_FACTURA_SINIVA = (double)(ocdr.IMP_FACTURA_SINIVA / ocdr.CANT_FACTURADA) * ocdr.CANT_RECIBIDA;

                ////ocdr.IMP_CAL1_OFERTA_CONIVA = (ocdr.IMP_FACTURA_CONIVA) - (ocdr.IMP_OFERTA_SINIVA);
                ////ocdr.IMP_CAL1_OFERTA_SINIVA = (ocdr.IMP_FACTURA_SINIVA) - (ocdr.IMP_OFERTA_SINIVA);
                ////ocdr.COSTO_NETO_UNIT_REC = (double)(ocdr.PRECIO_FARMACIA * (double)(1 - (ocdr.PORC_OFERTA / 100)) * (double)(1 - (ocdr.PORC_DESCTO / 100)));
                ////ocdr.IMPORTE_NETO = ocdr.COSTO_NETO_UNIT_REC * ocdr.CANT_RECIBIDA;
                ////ocdr.DIF_DESCTO_IVA = (double)(ocdr.IMP_DESCTO_CONIVA - ocdr.IMP_DESCTO_CONIVA_MENOSIVA);



                ////decimal calcOferta = (decimal)ocdr.PRECIO_FARMACIA - (decimal)ocdr.PRECIO_FARMACIA * ((decimal)ocdr.PORC_DESCTO / 100M);
                ////this.facturaResultadoTextBox.Text = calcOferta.ToString("C2");

                if (string.IsNullOrEmpty(facturaResultadoTextBox.Text))
                {
                    facturaResultadoTextBox.Text = "$0.00";
                }

                //this.facturaDescuentoAdicionalTextBox.Text = facturaDetalle.PORC_OFERTA.ToString();
                //decimal adicionalFactura = descuentoFactura - (descuentoFactura * facturaDetalle.PORC_OFERTA / 100M);
                //this.facturaCostoTextBox.Text = adicionalFactura.ToString("C2");

                //recepcion
                facturaAsignada = true;



                //ocdr.PRECIO_COSTO = facturaDetalle.PRECIO_VENTA_FAR;
                //if (esPrimeraVez)
                //{
                //    ocdr.DESCTO_RECIBIDO = facturaDetalle.PORC_DESCTO;
                //}

                //if (esPrimeraVez)
                //{
                //    ocdr.DESCTO_RECIBIDO_AD1 = facturaDetalle.PORC_OFERTA;
                //}
                //ocdr.DESCTO_RECIBIDO_AD2 = facturaDetalle.PORC_DESCTO;

                if (ocdr.FacturaProveedorDetalle != null)
                {
                    ofertaFacturaTextBoxX.Text = ocdr.FacturaProveedorDetalle.PORC_OFERTA.ToString("0.00");
                }
                else
                {
                    ofertaFacturaTextBoxX.Text = ocdr.PORC_OFERTA_FACTURA.ToString("0.00");
                }
                //else
                //{ 
                //ofertaFacturaTextBoxX.Text = ocdr.por
                //}

                //CALCULA DESDE LA BASE DE DATOS

                double resultadoRec = ocdr.COSTO - (ocdr.COSTO * (double)((decimal)ocdr.PORC_OFERTA / 100m));
                resultadoRec = resultadoRec - (resultadoRec * (double)((decimal)ocdr.PORC_DESCTO / 100m));
                this.recepcionResultadoTextBox.Text = resultadoRec.ToString("0.00");


                recibeL.SetRecepcionCompra(ocdr);

                this.recepcionMaximoPublicoTextBox.Text = ocdr.PRECIO_FACTURA_MAX.ToString("0.00");
                this.recepcionFarmaciaTextBox.Text = ocdr.PRECIO_FARMACIA.ToString("0.0000");
                facturaFarmaciaTextBox.Text = recepcionFarmaciaTextBox.Text;
                this.recepcionOfertaRealTextBox.Text = ocdr.PORC_OFERTA.ToString("0.00");
                facturaDescuentoTextBox.Text = recepcionOfertaRealTextBox.Text;
                this.recepcionFinancieroTextBox.Text = ocdr.PORC_DESCTO.ToString("0.00");
                facturaFinancieroTextBox.Text = recepcionFinancieroTextBox.Text;


                this.recepcionDescuentoAdicional1TextBox.Text = ocdr.PORC_DESCTO_AD1.ToString("0.00");
                this.recepcionDescuentoAdicional2TextBox.Text = ocdr.PORC_DESCTO_AD2.ToString("0.00");
                this.recepcionDescuentoAdicional3TextBox.Text = ocdr.PORC_DESCTO_AD3.ToString("0.00");

                //OFERTA
                double resultado = ocdr.COSTO - (ocdr.COSTO * (double)((decimal)ocdr.PORC_OFERTA / 100m));

                double importeBrutoFactura = (ocdr.PRECIO_FARMACIA * ocdr.CANT_FACTURA);
                double importeBrutoRecepcion = (ocdr.PRECIO_FARMACIA * ocdr.CANT_FACTURA);

                ocdr.TOTAL_OFERTA_FACTURA = importeBrutoFactura * (double)((decimal)ocdr.PORC_OFERTA / 100m);
                ocdr.IMP_OFERTA_CONIVA = importeBrutoRecepcion * (double)((decimal)ocdr.PORC_OFERTA / 100m);

                //DESCTO
                resultado = resultado - (resultado * (double)((decimal)ocdr.PORC_DESCTO / 100m));

                ocdr.TOTAL_DESCTO_FACTURA = (importeBrutoFactura - ocdr.TOTAL_OFERTA_FACTURA) * (double)((decimal)ocdr.PORC_DESCTO / 100m);
                ocdr.IMP_DESCTO_CONIVA = (importeBrutoRecepcion - ocdr.IMP_OFERTA_CONIVA) * (double)((decimal)ocdr.PORC_DESCTO / 100m);

                this.recepcionResultadoTextBox.Text = resultado.ToString("0.00");

                ////double adicional = resultado - (resultado * (double)((decimal)ocdr.PORC_DESCTO_AD1 / 100m));
                ////ocdr.RES_CAL3_DESCTOAD1 = adicional;
                ////adicional = adicional - (double)(adicional * (double)((decimal)ocdr.PORC_DESCTO_AD2 / 100m));
                ////ocdr.RES_CAL4_DESCTOAD2 = ocdr.RES_CAL3_DESCTOAD1 - adicional;
                ////adicional = adicional - (double)(adicional * (double)((decimal)ocdr.PORC_DESCTO_AD3 / 100m));
                ////ocdr.RES_CAL5_DESCTOAD3 = ocdr.RES_CAL4_DESCTOAD2 - adicional;
                ////adicional = adicional - (double)(adicional * (double)((decimal)ocdr.PORC_DESCTO_AD4 / 100m));
                ////ocdr.RES_CAL6_DESCTOAD4 = ocdr.RES_CAL5_DESCTOAD3 - adicional;
                ////this.recepcionCostoTextBox.Text = adicional.ToString("0.00");
                ////decimal adicionalIVA = (decimal)(adicional + (adicional * (ocdr.PORC_IVA / 100)));
                ////costoIVATextBox.Text = adicionalIVA.ToString();
                ////ocdr.COSTO = (double)adicional;

                //this.facturaMaximoPublicoTextBox.Text = ocdr.PRECIO_MAXIMO.ToString("0.00");
                //this.facturaFarmaciaTextBox.Text = "0.00";
                //this.facturaDescuentoTextBox.Text = "0.00";
                //this.facturaDescuentoAdicionalTextBox.Text = "0.00";
                //this.facturaResultadoTextBox.Text = "0.00";

                //this.facturaCostoTextBox.Text = "0.00";

                //ocdr.COSTO = (double)ocdr.ListaPrecios.COSTO_PROM;
            }

            if ((ocdr.ListaPrecios.PRECIO_VENTA_MAX != (decimal)ocdr.PRECIO_FACTURA_MAX) && (ocdr.PRECIO_FACTURA_MAX != 0))
            {
                facturaMaximoPublicoTextBox.BackColor = Color.Red;
            }
            //}

            //    if (ocdr.FacturaProveedorDetalle == null)
            //    {
            //        this.facturaMaximoPublicoTextBox.Text = ocdr.PRECIO_MAXIMO.ToString("C2");
            //        this.facturaFarmaciaTextBox.Text = ocdr.COSTO.ToString("0.00");
            //        this.facturaDescuentoTextBox.Text = ocdr..ToString("0.00");
            //       // this.facturaDescuentoAdicionalTextBox.Text = ocdr.DESCTO_FACTURA_AD1.ToString("0.00");
            //        this.facturaResultadoTextBox.Text = this.facturaMaximoPublicoTextBox.Text;

            //        this.facturaCostoTextBox.Text = this.facturaMaximoPublicoTextBox.Text;
            //}


            //}
            //if (!facturaAsignada)
            //{
            //    //recepcion
            //    this.recepcionMaximoPublicoTextBox.Text = precio.PRECIO_VENTA_MAX.ToString();
            //    this.recepcionFarmaciaTextBox.Text = ocdr.PRECIO_COSTO.ToString();
            //    this.recepcionDescuentoTextBox.Text = ocdr.DESCTO_RECIBIDO.ToString();
            //    this.recepcionDescuentoAdicionalTextBox.Text = ocdr.DESCTO_RECIBIDO_AD1.ToString();
            //    this.recepcionDescuentoAdicional2TextBox.Text = ocdr.DESCTO_RECIBIDO_AD2.ToString();
            //    this.recepcionDescuentoAdicional3TextBox.Text = ocdr.DESCTO_RECIBIDO_AD3.ToString();
            //    this.recepcionDescuentoAdicional4TextBox.Text = ocdr.DESCTO_RECIBIDO_AD4.ToString();
            //    decimal resultado = ocdr.PRECIO_COSTO - (ocdr.PRECIO_COSTO * (ocdr.DESCTO_RECIBIDO / 100m));
            //    this.recepcionResultadoTextBox.Text = resultado.ToString();
            //    decimal adicional = resultado - (resultado * (ocdr.DESCTO_RECIBIDO_AD1 / 100m));
            //    this.recepcionCostoTextBox.Text = adicional.ToString();
            //}



            decimal total = (decimal)(ocdr.COSTO * ocdr.CANT_RECIBIDA);
            //  Debug.Assert(ocdr.COSTO > 0);
            //this.totalLabel.Text = total.ToString("C2");

            decimal cantidadDevuelta = ocdr.CANT_FACTURADA - ocdr.CANT_RECIBIDA;
            cantidadDevueltaTextBox.Text = cantidadDevuelta.ToString();

            //decimal precioFacturaOferta1 = ocdr.PRECIO_FACTURA * (ocdr.DESCTO_FACTURA / 100);
            //precioFacturaOferta1 += precioFacturaOferta1 * (ocdr.DESCTO_FACTURA_AD1 / 100);
            //decimal precioRecepcionOferta1 = ocdr.PRECIO_COSTO * (ocdr.DESCTO_RECIBIDO / 100);
            //precioRecepcionOferta1 += precioRecepcionOferta1 * (ocdr.DESCTO_RECIBIDO_AD1 / 100);
            //decimal malOfertado = precioRecepcionOferta1 - precioFacturaOferta1;
            //malOfertadoTextBox.Text = malOfertado.ToString("C2");

            //SIFModelo.OrdenCompra.OrdenCompraDataSet.OFERTAS_COMPRAS_MAYORISTARow ofertaCompra = new SIFNegocio.OrdenCompra.OrdenCompra().OfertaPorId((int)ocdr.OFERTA_COMPRA_ID);

            //if (ofertaCompra != null)
            //{
            //    this.descuentoTextBox.Text = ofertaCompra.DESCTO_OFRECIDO.ToString();
            //}
            if (!ocdr.IsDESC1_DESCNull())
            {
                Desc1TextBoxX.Text = ocdr.DESC1_DESC;
            }
            else
            {
                Desc1TextBoxX.Text = "";
            }
            if (!ocdr.IsDESC2_DESCNull())
            {
                Desc2TextBoxX.Text = ocdr.DESC2_DESC;
            }
            else
            {
                Desc2TextBoxX.Text = "";
            }
            if (!ocdr.IsDESC3_DESCNull())
            {
                Desc3TextBoxX.Text = ocdr.DESC3_DESC;
            }
            else
            {
                Desc3TextBoxX.Text = "";
            }

            facturaFarmaciaTextBox_KeyUp(null, null);
            this.calculaUtilidad(ocdr);
            esPrimeraVez = false;
        }

        private void superGridControl1_RowActivated(object sender, GridRowActivatedEventArgs e)
        {
            GridRow row = ((GridRow)e.NewActiveRow);
            DataRowView rv = null;
            if (row.DataItem is DataRowView)
            {
                rv = row.DataItem as DataRowView;
            }
            else
            {
                rv = (DataRowView)((BindingSource)row.DataItem).Current;
            }
            if (rv.Row is SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow)
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow ocdr = null;

                if (row.DataItem is DataRowView)
                {
                    ocdr = ((DataRowView)(((GridRow)e.NewActiveRow).DataItem)).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow;
                }
                else
                {
                    ocdr = ((DataRowView)((BindingSource)(((GridRow)e.NewActiveRow).DataItem)).Current).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow;
                }

                calculaTotalDetalle(ocdr);
            }
        }

        private void calculaUtilidad(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow detalle, bool esDirecto = false, bool esDescuentoDirecto = false, bool esGeneral = false)
        {

            //if (this.descuentoGeneralNumericUpDown.Value >= 0)
            //{

            //    detalle.DESCUENTO_GENERAL = (float)descuentoGeneralNumericUpDown.Value;
            //    descuentoTextBoxX.Text = detalle.DESCUENTO_GENERAL.ToString("0.00");
            //    esDescuentoDirecto = true;
            //}

            if (detalle.PRECIO_MAXIMO == 0)
            {
                if (detalle.FacturaProveedorDetalle != null)
                {
                    detalle.PRECIO_MAXIMO = (double)detalle.FacturaProveedorDetalle.PRECIO_VENTA_MAX;
                }
                else
                {
                    detalle.PRECIO_MAXIMO = detalle.PRECIO_FARMACIA;
                }
            }

            double descuentoGeneral = (detalle.PRECIO_MAXIMO * (double)((decimal)detalle.DESCUENTO_GENERAL / 100m));
            double nuevoFlememing = detalle.PRECIO_MAXIMO - descuentoGeneral;
            nuevoFlememing = Math.Round(nuevoFlememing,1);
            //if (detalle.FacturaProveedorDetalle != null)
            //{

            //    if (detalle.FacturaProveedorDetalle.IVA > 0)
            //    {
            //        //detalle.PORC_IVA = (detalle.FacturaProveedorDetalle.IVA / detalle.CANT_FACTURADA) / detalle.PRECIO_FACTURA;
            //        //SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PORC_IVA * 100);

            //        detalle.PORC_IVA =  16; 
            //        decimal impuestoIVA = nuevoFlememing * (detalle.PORC_IVA / 100);
            //        this.impuestoTextBoxX.Text = impuestoIVA.ToString();
            //        nuevoFlememing += impuestoIVA;
            //    }
            //    else
            //    {
            //        this.impuestoTextBoxX.Text = "0";
            //    }
            //}

            //detalle.EsDirecto = esDirecto;
            //if (nuevoFlemingTextBox.Text.IsFloatPositive())
            //{
            //    esDirecto = true;
            //}

            if (!esDirecto)
            {
                //nuevoFlememing = decimal.Parse(nuevoFlemingTextBox.Text);


                if (detalle.EsDirecto)
                {
                    nuevoFlememing = Math.Round(detalle.NUEVO_FLEMING, 1);
                }

            }
            else
            {
                //


                detalle.EsDirecto = true;
                nuevoFlemingTextBox.Text = nuevoFlemingTextBox.Text.Trim('$');
                nuevoFlememing = Math.Round(double.Parse(nuevoFlemingTextBox.Text.ToString()), 1);
                detalle.NUEVO_FLEMING = nuevoFlememing;
                // this.nuevoFlemingTextBox.Text = detalle.NUEVO_FLEMING.ToString("C2");

            }



            double margenCantidad = detalle.PRECIO_MAXIMO - nuevoFlememing;
            double porcentajeDescuento = 0;
            if (!esDescuentoDirecto && detalle.PRECIO_MAXIMO > 0)
            {
                //if (detalle.ULT_PRECIO_COMPRA > 0)
                //{
                porcentajeDescuento = 1 - (double)(nuevoFlememing / (double)detalle.PRECIO_MAXIMO);
                porcentajeDescuento = porcentajeDescuento * 100;

                //}


                this.descuentoTextBoxX.Text = porcentajeDescuento.ToString("0.00");
                detalle.DESCUENTO_GENERAL = (float)SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(porcentajeDescuento);
            }
            else
            {
                if (esDirecto)
                {
                    porcentajeDescuento = 1 - (double)(nuevoFlememing / (double)detalle.PRECIO_MAXIMO);
                    porcentajeDescuento = porcentajeDescuento * 100;
                }
                else
                {
                    if (descuentoTextBoxX.Text.IsFloat())
                    {
                        if (esGeneral) // (!esDescuentoDirecto && esGeneral)
                        {
                            porcentajeDescuento = (double)this.descuentoGeneralNumericUpDown.Value;
                        }
                        else
                        {
                            porcentajeDescuento = double.Parse(descuentoTextBoxX.Text);
                        }
                        detalle.DESCUENTO_GENERAL = (float)porcentajeDescuento;
                        descuentoGeneral = (double)(detalle.PRECIO_MAXIMO * (double)((decimal)detalle.DESCUENTO_GENERAL / 100m));
                        nuevoFlememing = detalle.PRECIO_MAXIMO - descuentoGeneral;
                        detalle.NUEVO_FLEMING = nuevoFlememing;
                    }
                }
            }

            if (detalle.FacturaProveedorDetalle != null)
            {

                if (detalle.FacturaProveedorDetalle.IsIVANull())
                {
                    detalle.FacturaProveedorDetalle.IVA = 0;
                }

                if (detalle.FacturaProveedorDetalle.IVA > 0)
                {
                    //detalle.PORC_IVA = (detalle.FacturaProveedorDetalle.IVA / detalle.CANT_FACTURADA) / detalle.PRECIO_FACTURA;
                    //SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.PORC_IVA * 100);

                    detalle.PORC_IVA = 16;
                    double impuestoIVA = nuevoFlememing * (detalle.PORC_IVA / 100);
                    this.impuestoTextBoxX.Text = impuestoIVA.ToString();
                    //nuevoFlememing += impuestoIVA;//COMENTADO POR AVM 10/08/2015
                }
                else
                {
                    this.impuestoTextBoxX.Text = "0";
                }
            }
            else
            {
                //IVATextBox.Text = (detalle.IMPORTE_IVA / detalle.CANT_RECIBIDA).ToString("0.00");
                //iepsTextBoxX.Text = (detalle.IMPORTE_IEPS / detalle.CANT_RECIBIDA).ToString("0.00");
                //impuestoTextBoxX.Text = ((detalle.IMPORTE_IVA / detalle.CANT_RECIBIDA) + (detalle.IMPORTE_IEPS / detalle.CANT_RECIBIDA)).ToString("0.00");
                //cantidadDevueltaTextBox.Text = detalle.CANT_RECIBIDA.ToString("0");
                double impuestoIVA = nuevoFlememing * (detalle.PORC_IVA / 100);
                //this.impuestoTextBoxX.Text = impuestoIVA.ToString();
            }

            decimal porcentajeUtilidad = 0;

            //utilidad anterior
            // decimal margenCantidadAnterior = detalle.PRECIO_VENTA - (decimal)detalle.COSTO_ULT_COMPRA;
            //decimal porcentajeUtilidadAnterior = 0;
            //decimal descuentoAnterior = 0;
            //if (detalle.PRECIO_VENTA > 0)
            //{
            //    if (nuevoFlememing > 0)
            //    {
            //        if (detalle.COSTO_ULT_COMPRA > 0)
            //            porcentajeUtilidadAnterior = detalle.PRECIO_VENTA / (decimal)detalle.COSTO_ULT_COMPRA;
            //        if (detalle.PRECIO_VENTA > 0)
            //        {
            //            descuentoAnterior = detalle.PRECIO_FACTURA_MAX / detalle.PRECIO_VENTA - 1;
            //            descuentoAnterior = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(descuentoAnterior * 100);
            //        }
            //    }
            //}

            //desctoAnteriorTextBoxX.Text = descuentoAnterior.ToString("0.00") + "%";

            //anterior


            //  = detalle.PRECIO_COSTO - (detalle.PRECIO_COSTO * (detalle.DESCTO_RECIBIDO / 100m));
            //desctoMontoTextBoxX.Text = descuentoGeneral.ToString("C2");

            //if (detalle.CANT_RECIBIDA == 0)
            //{
            //    detalle.PRECIO_FARMACIA = (double)detalle.ListaPrecios.PRECIO_VENTA_FARM;
            //    detalle.PRECIO_FLEMING = (double)detalle.ListaPrecios.PRECIO_VENTA;
            //    detalle.DESCUENTO_GENERAL = (float)((1 - (detalle.ListaPrecios.PRECIO_VENTA / (decimal)detalle.ListaPrecios.PRECIO_VENTA_MAX)) * 100);
            //}


            double costo = detalle.PRECIO_FARMACIA;

            detalle.RES_CAL1_DESCTO = (double)(((decimal)costo * (decimal)detalle.PORC_DESCTO / 100M));//* detalle.CANT_RECIBIDA);
            costo -= detalle.RES_CAL1_DESCTO;

            detalle.RES_CAL2_OFERTA = (costo * (double)((decimal)detalle.PORC_OFERTA / 100m)); // * detalle.CANT_RECIBIDA;
            costo -= detalle.RES_CAL2_OFERTA;
            this.recepcionResultadoTextBox.Text = costo.ToString("0.00");
            facturaCostoTextBox.Text = costo.ToString("0.00");

            detalle.RES_CAL3_DESCTOAD1_PORC = (double)(((decimal)costo * ((decimal)detalle.PORC_DESCTO_AD1 / 100M))); // * detalle.CANT_RECIBIDA);
            costo -= detalle.RES_CAL3_DESCTOAD1_PORC;
            detalle.RES_CAL4_DESCTOAD2_PORC = (double)((decimal)costo * ((decimal)detalle.PORC_DESCTO_AD2 / 100M)); //*detalle.CANT_RECIBIDA);
            costo -= detalle.RES_CAL4_DESCTOAD2_PORC;
            detalle.RES_CAL5_DESCTOAD3_PORC = (double)((decimal)costo * ((decimal)detalle.PORC_DESCTO_AD3 / 100M)); //*detalle.CANT_RECIBIDA);
            costo -= detalle.RES_CAL5_DESCTOAD3_PORC;
            detalle.RES_CAL6_DESCTOAD4_PORC = (double)((decimal)costo * ((decimal)detalle.PORC_DESCTO_AD4 / 100M));// *detalle.CANT_RECIBIDA);
            costo -= detalle.RES_CAL6_DESCTOAD4_PORC;

            detalle.COSTO_NETO_UNIT_REC = costo;
            recepcionCostoTextBox.Text = costo.ToString("0.00");
            facturaCostoUnitarioTextBoxX.Text = costo.ToString("0.00");
            //detalle.COSTO_NETO_UNIT_REC = costo;

            //detalle.RES_CAL3_DESCTOAD1 = (double)(((decimal)costo * ((decimal)detalle.PORC_DESCTO_AD1 / 100M)) * detalle.CANT_RECIBIDA);
            //costo -= detalle.RES_CAL3_DESCTOAD1;
            //detalle.RES_CAL4_DESCTOAD2 = (double)((decimal)costo * ((decimal)detalle.PORC_DESCTO_AD2 / 100M)); //*detalle.CANT_RECIBIDA);
            //costo -= detalle.RES_CAL4_DESCTOAD2;
            //detalle.RES_CAL5_DESCTOAD3 = (double)((decimal)costo * ((decimal)detalle.PORC_DESCTO_AD3 / 100M)); //*detalle.CANT_RECIBIDA);
            //costo -= detalle.RES_CAL5_DESCTOAD3;
            //detalle.RES_CAL6_DESCTOAD4 = (double)((decimal)costo * ((decimal)detalle.PORC_DESCTO_AD4 / 100M));// *detalle.CANT_RECIBIDA);
            //costo -= detalle.RES_CAL6_DESCTOAD4;


            // decimal adicional = resultado - (resultado * (detalle.DESCTO_RECIBIDO_AD1 / 100m));

            //  detalle.COSTO = costo ;


            if (!detalle.EsDirecto)
            {
                // detalle.COSTO = (double)costo;
            }

            // detalle.COSTO_NETO_UNIT_REC = detalle.COSTO;
            //   recepcionResultadoTextBox.Text = detalle.COSTO_NETO_UNIT_REC.ToString("0.00");

            double costoNetoUnitRec = detalle.COSTO_NETO_UNIT_REC; // (detalle.COSTO_NETO_UNIT_REC - detalle.RES_CAL3_DESCTOAD1 - detalle.RES_CAL4_DESCTOAD2 - detalle.RES_CAL5_DESCTOAD3 - detalle.RES_CAL6_DESCTOAD4);

            this.recepcionCostoTextBox.Text = costoNetoUnitRec.ToString("0.00");
            decimal adicionalIVA = (decimal)(costoNetoUnitRec + (costoNetoUnitRec * (detalle.PORC_IVA / 100)));
            decimal calcIVA = (decimal)(costoNetoUnitRec * (detalle.PORC_IVA / 100));
            IVATextBox.Text = calcIVA.ToString("0.00");
            costoIVATextBox.Text = adicionalIVA.ToString("0.00");

            decimal montoIEPS = adicionalIVA + (adicionalIVA * ((decimal)detalle.PORCENTAJE_IEPS / 100));
            decimal calcIEPS = (adicionalIVA * (decimal)(detalle.PORCENTAJE_IEPS / 100));
            iepsTextBoxX.Text = calcIEPS.ToString("0.00");

            cantidadDevueltaTextBox.Text = detalle.CANT_RECIBIDA.ToString("0");
            
            if (montoIEPS == 0)
            {
                montoIEPS = adicionalIVA;
            }

            impuestoTextBoxX.Text = (calcIVA + calcIEPS).ToString("0.00");

            costoIEPSTextBoxX.Text = montoIEPS.ToString("0.00");
            adicionalIVA = (decimal)(costoNetoUnitRec + (costoNetoUnitRec * (detalle.PORC_IVA / 100))) + montoIEPS;

            //margenCantidad = nuevoFlememing - (double)adicionalIVA;//costoNetoUnitRec;// detalle.COSTO;


            this.nuevoFlemingTextBox.Text = Math.Round(nuevoFlememing, 1).ToString("0.00");
            precioFacturaFlemingTextBox.Text = Math.Round(nuevoFlememing, 1).ToString("0.00");
            //this.margenUtilidadAnteriorTextBox.Text = porcentajeUtilidadAnterior.ToString("0.00") + "%";
            //this.utilidadAnteriorTextBoxX.Text = margenCantidadAnterior.ToString("C2");

            porcentajeUtilidad = 0;
            if (adicionalIVA > 0 || montoIEPS > 0)
            {
                porcentajeUtilidad = (decimal)(((nuevoFlememing - (double)montoIEPS)) / (double)nuevoFlememing);
                //porcentajeUtilidad = (decimal)((nuevoFlememing - (double)adicionalIVA - (double)montoIEPS) / (double)nuevoFlememing); //COSTO CON IVA
                //porcentajeUtilidad = (decimal)((nuevoFlememing / detalle.COSTO) - 1);
            }
            //porcentajeUtilidadAnterior = (ocdr.ListaPrecios.PRECIO_VENTA / ocdr.ListaPrecios.PRECIO_COSTO) - 1;
            //porcentajeUtilidadAnterior = porcentajeUtilidadAnterior * 100;
            porcentajeUtilidad = porcentajeUtilidad * 100;
            porcentajeUtilidad = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(porcentajeUtilidad);
            margenCantidad = nuevoFlememing - (double)montoIEPS;//costoNetoUnitRec;// detalle.COSTO;

            this.utilidadTextBox.Text = margenCantidad.ToString("C2");
            this.margenTextBox.Text = porcentajeUtilidad.ToString("0.00");
            //detalle.MARGEN_UTILIDAD = (double)porcentajeUtilidad;

            detalle.MARGEN_UTILIDAD = (double)SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(porcentajeUtilidad);


            double precioDesctoFactura = 0;
            double porcOfertaFactura = 0;
            if (detalle.FacturaProveedorDetalle != null)
            {
                if (detalle.FacturaProveedorDetalle.IsPORC_OFERTANull())
                {
                    detalle.FacturaProveedorDetalle.PORC_OFERTA = 0;
                }

                if (detalle.FacturaProveedorDetalle.IsPORC_DESCTONull())
                {
                    detalle.FacturaProveedorDetalle.PORC_DESCTO = 0;
                }

                porcOfertaFactura = (double)detalle.FacturaProveedorDetalle.PORC_OFERTA;
                precioDesctoFactura = (double)detalle.FacturaProveedorDetalle.PORC_DESCTO;
            }


            porcOfertaFactura = detalle.PRECIO_FACTURA * (double)(porcOfertaFactura / 100);
            precioDesctoFactura = detalle.PRECIO_FACTURA * (double)(precioDesctoFactura / 100);


            double precioRecepcionOferta1 = detalle.PRECIO_FARMACIA * (double)(detalle.PORC_OFERTA / 100);
            double precioRecepcionDescto1 = detalle.PRECIO_FARMACIA * (double)(detalle.PORC_DESCTO_AD1 / 100);

            double malOfertado = 0; //(precioRecepcionOferta1 + precioRecepcionDescto1) - (precioDesctoFactura + porcOfertaFactura);
            if (detalle.FacturaProveedorDetalle != null)
            {
                detalle.SIN_OFERTA = 0;
                detalle.MAL_OFERTADO = 0;


                double porcOfertaFac = 0;

                if (detalle.FacturaProveedorDetalle != null)
                {
                    porcOfertaFac = (double)detalle.FacturaProveedorDetalle.PORC_OFERTA;
                }


                double descTotFinanciero = (double)detalle.PRECIO_FARMACIA - ((double)detalle.PORC_DESCTO / 100f) * ((double)detalle.PRECIO_FARMACIA);

                double oferta1 = (descTotFinanciero - (descTotFinanciero * (porcOfertaFac / 100f))) * detalle.CANT_RECIBIDA;
                double oferta2 = (descTotFinanciero - (descTotFinanciero * (detalle.PORC_OFERTA / 100f))) * detalle.CANT_RECIBIDA;

                malOfertado = oferta1 - oferta2;
                if (detalle.FacturaProveedorDetalle.PORC_OFERTA == 0)
                {
                    detalle.SIN_OFERTA = malOfertado * detalle.CANT_RECIBIDA;
                }
                else
                {
                    detalle.MAL_OFERTADO = malOfertado * detalle.CANT_RECIBIDA;
                }

            }
            else
            {
                detalle.SIN_OFERTA = 0;
                detalle.MAL_OFERTADO = 0;

                double porcOfertaFac = 0;

                porcOfertaFac = (double)detalle.PORC_OFERTA_FACTURA;

                double descTotFinanciero = (double)detalle.PRECIO_FARMACIA - ((double)detalle.PORC_DESCTO / 100f) * ((double)detalle.PRECIO_FARMACIA);

                double oferta1 = (descTotFinanciero - (descTotFinanciero * (porcOfertaFac / 100f))) * detalle.CANT_RECIBIDA;
                double oferta2 = (descTotFinanciero - (descTotFinanciero * (detalle.PORC_OFERTA / 100f))) * detalle.CANT_RECIBIDA;

                malOfertado = oferta1 - oferta2;
                if (detalle.PORC_OFERTA_FACTURA == 0)
                {
                    detalle.SIN_OFERTA = malOfertado * detalle.CANT_RECIBIDA;
                }
                else
                {
                    detalle.MAL_OFERTADO = malOfertado * detalle.CANT_RECIBIDA;
                }

                //    detalle.MAL_OFERTADO = malOfertado;
                //detalle.SIN_OFERTA = malOfertado;
            }
            //malOfertadoTextBox.Text = detalle.MAL_OFERTADO.ToString("C2");
            //textBoxX1.Text = detalle.SIN_OFERTA.ToString("C2");
            //  impuestoTextBoxX.Text = descuentoGeneral.ToString("C2");
            //if (detalle.FacturaProveedorDetalle != null)
            //{
            //    decimal iva = detalle.FacturaProveedorDetalle.IVA / detalle.FacturaProveedorDetalle.PZA_CCARGO;
            //    detalle.IMPORTE_IVA = iva * detalle.CANT_RECIBIDA;
            //    IVATextBox.Text = detalle.IMPORTE_IVA.ToString();
            //}

            if (detalle.ARTICULO_ID == "7501001147594") 
            { 
            
            }
            recibeL.SetRecepcionCompra(detalle);

            this.Update();
        }


        private void facturaCostoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.calculaTotal();
            }
        }

        private void calculaUtilidad(bool esDirecto = false)
        {
            if (superGridControl1.PrimaryGrid.ActiveRow == null)
            {
                return;
            }

            object row = null;

            if (((GridRow)superGridControl1.ActiveRow).DataItem is DataRowView)
            {
                row = ((DataRowView)((GridRow)superGridControl1.ActiveRow).DataItem).Row;
            }

            if (((GridRow)superGridControl1.ActiveRow).DataItem is BindingSource)
            {
                row = ((DataRowView)(((BindingSource)((GridRow)superGridControl1.ActiveRow).DataItem)).Current).Row;
            }

            if (row is SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow)
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow ocdr = row as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow;
                this.calculaUtilidad(ocdr, esDirecto);
            }
        }

        private void descuentoGeneralNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GridRow rowedit = this.superGridControl1.ActiveRow as GridRow;
            string articuloid = rowedit.Cells["ARTICULOColumn"].Value.ToString();
            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row in compraL.CompraDetalles)
            {
               
                bool esDirecto = false;
                row.EsDirecto = false;
                if (descuentoGeneralNumericUpDown.Value >= 0 && row.ARTICULO_ID==articuloid)
                {
                    row.DESCUENTO_GENERAL = (float)this.descuentoGeneralNumericUpDown.Value;
                    esDirecto = true;
                }

                this.calculaUtilidad(row, false, esDirecto, true);
            }

            this.superGridControl1.Invalidate();
            this.superGridControl1.Update();
            this.calculaUtilidad();

            foreach (GridRow GridRow in superGridControl1.PrimaryGrid.Rows)
            {
                pintaFila(GridRow);
            }

        }

        //private void superGridControl1_PostRenderRow(object sender, GridPostRenderRowEventArgs e)
        //{
        //    return;
        //    SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row = (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow)((DataRowView)((GridRow)(e.GridRow)).DataItem).Row;

        //    if (row == null)
        //    {
        //        return;
        //    }

        //    e.GridRow.CellStyles.Default = normalRowStyle;
        //    e.GridRow.RowStyles.Default.ApplyStyle(normalRowStyle);

        //    if (row.CANT_RECIBIDA < row.CANT_RECIBIDA)
        //    {
        //        e.GridRow.CellStyles.Default = faltanteRowStyle;
        //        e.GridRow.RowStyles.Default.ApplyStyle(faltanteRowStyle);
        //    }

        //    if (row.MARGEN_UTILIDAD <= 0)
        //    {
        //        e.GridRow.CellStyles.Default = WarningCellStyle;
        //        e.GridRow.RowStyles.Default.ApplyStyle(WarningCellStyle);
        //    }

        //    if (row.CANT_FACTURADA == 0)
        //    {
        //        e.GridRow.CellStyles.Default = revisarRowStyle;
        //        e.GridRow.RowStyles.Default.ApplyStyle(revisarRowStyle);
        //    }
        //}

        private void superGridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GridRow row = this.superGridControl1.ActiveRow as GridRow;
                int columna = superGridControl1.ActiveCell.ColumnIndex;
                if (row.RowIndex < superGridControl1.PrimaryGrid.LastSelectableRow.RowIndex)
                { row.GetCell(columna).BeginEdit(true); }
            }
        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                if (superGridControl1.PrimaryGrid.SelectedRowCount >= 1)
                {
                    superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
                }
                else
                {
                    superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(false, false);
                }
            }
        }

        private void facturaFarmaciaTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (superGridControl1.ActiveRow == null)
            {
                return;
            }

            if ((TextBox)sender == facturaFinancieroTextBox)
            {
                recepcionFinancieroTextBox.Text = facturaFinancieroTextBox.Text;
            }
            else
            {
                facturaFinancieroTextBox.Text = recepcionFinancieroTextBox.Text;
            }


            if ((TextBox)sender == facturaDescuentoTextBox)
            {
                recepcionOfertaRealTextBox.Text = facturaDescuentoTextBox.Text;
            }
            else
            {
                facturaDescuentoTextBox.Text = recepcionOfertaRealTextBox.Text;
            }

            //if (((DataRowView)(((BindingSource)((GridRow)superGridControl1.ActiveRow).DataItem).Current)).Row is SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow)
            //{

            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow ocdr = null;

            if (((GridRow)superGridControl1.ActiveRow).DataItem is BindingSource)
            {
                ocdr = ((DataRowView)((BindingSource)((GridRow)superGridControl1.ActiveRow).DataItem).Current).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow;
            }

            if (((GridRow)superGridControl1.ActiveRow).DataItem is DataRowView)
            {
                ocdr = ((DataRowView)((GridRow)superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow;
            }

            if (recepcionFarmaciaTextBox.Text.IsFloatPositive())
                ocdr.PRECIO_FARMACIA = double.Parse(recepcionFarmaciaTextBox.Text);
            if (recepcionOfertaRealTextBox.Text.IsFloatPositive())
                ocdr.PORC_OFERTA = float.Parse(recepcionOfertaRealTextBox.Text);
            if (recepcionFinancieroTextBox.Text.IsFloatPositive())
                ocdr.PORC_DESCTO = float.Parse(recepcionFinancieroTextBox.Text);
            if (recepcionDescuentoAdicional1TextBox.Text.IsFloatPositive())
                ocdr.PORC_DESCTO_AD1 = float.Parse(recepcionDescuentoAdicional1TextBox.Text);
            if (recepcionDescuentoAdicional2TextBox.Text.IsFloatPositive())
                ocdr.PORC_DESCTO_AD2 = float.Parse(recepcionDescuentoAdicional2TextBox.Text);
            if (recepcionDescuentoAdicional3TextBox.Text.IsFloatPositive())
                ocdr.PORC_DESCTO_AD3 = float.Parse(recepcionDescuentoAdicional3TextBox.Text);

            //SIFModelo.OrdenCompra.OrdenesCompraDataSet.COMPRASDataTable compras = SIFNegocio.OrdenCompra.Compras.OrdenesCompraPorOCId(this.OrdenCompra);
            //SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETDataTable facturas = ordenCompraL.DetallesFacturaProveedor(compras);

            //SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETRow facturaDetalle = null;

            //        var facturaEncontrada = from f in facturas where f.ARTICULO_ID == ocdr.ARTICULO_ID select f;

            //        if (facturaEncontrada.Count() > 0)
            //        {
            //           facturaDetalle  = facturaEncontrada.First();
            //        }


            if (facturaFarmaciaTextBox.Text.IsFloatPositive())
            {
                ocdr.PRECIO_FACTURA = double.Parse(facturaFarmaciaTextBox.Text);
                //if (facturaDetalle != null)
                //{
                //    facturaDetalle.PRECIO_VENTA_FAR = (double)ocdr.PRECIO_FACTURA;
                //}
            }
            //if (recepcionDescuentoTextBox.Text.IsFloatPositive())
            //{
            //    ocdr.PORC_OFERTA = decimal.Parse(recepcionDescuentoTextBox.Text);
            //    //if (facturaDetalle != null)
            //    //{
            //    //    facturaDetalle.DESCUENTO = (double)ocdr.DESCTO_FACTURA;
            //    //}

            //}
            if (recepcionFinancieroTextBox.Text.ToString().IsFloat())
            {
                ocdr.PORC_DESCTO = float.Parse(recepcionFinancieroTextBox.Text);
                //if (facturaDetalle != null)
                //{
                //    facturaDetalle.PORC_OFERTA  = (double)ocdr.DESCTO_FACTURA_AD1;
                //}
            }

            double resultado = ocdr.PRECIO_FARMACIA - (double)(ocdr.PRECIO_FARMACIA * (double)((decimal)ocdr.PORC_OFERTA / 100m));
            this.recepcionResultadoTextBox.Text = resultado.ToString("0.00");

            recibeL.SetRecepcionCompra(ocdr);

            double adicional = resultado - (resultado * (double)((decimal)ocdr.PORC_DESCTO / 100m));
            recepcionResultadoTextBox.Text = (ocdr.COSTO_NETO_UNIT_REC).ToString("0.00");
            this.recepcionCostoTextBox.Text = (ocdr.COSTO_NETO_UNIT_REC).ToString("0.00");
            decimal adicionalIVA = (decimal)(adicional + (adicional * (adicional / 100)));
            costoIVATextBox.Text = adicionalIVA.ToString("0.00");


            ocdr.COSTO = (double)adicional;

            //PRECIOS FACTURA
            double resultadoFactura = ocdr.PRECIO_FACTURA - (double)(ocdr.PRECIO_FACTURA * (double)((decimal)ocdr.PORC_OFERTA / 100m));

            this.facturaResultadoTextBox.Text = resultadoFactura.ToString("0.00");
            double adicionalFactura = resultadoFactura - (resultadoFactura * (double)((decimal)ocdr.PORC_DESCTO / 100m));
            this.facturaCostoTextBox.Text = adicionalFactura.ToString("0.00");
            costoUltimaCompraTextBoxX.Text = ocdr.COSTO_ULT_COMPRA.ToString("0.00");
            //decimal costoFactura = adicionalFactura;

            this.calculaUtilidad(ocdr);
            //}
        }

        private void recepcionDescuentoTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (superGridControl1.ActiveRow == null)
            {
                return;
            }

            if ((TextBox)sender == recepcionFinancieroTextBox)
            {
                facturaFinancieroTextBox.Text = recepcionFinancieroTextBox.Text;
            }

            if ((TextBox)sender == recepcionOfertaRealTextBox)
            {
                facturaDescuentoTextBox.Text = recepcionOfertaRealTextBox.Text;
            }

            object row = null;

            if (((GridRow)superGridControl1.ActiveRow).DataItem is DataRowView)
            {
                row = ((DataRowView)((GridRow)superGridControl1.ActiveRow).DataItem).Row;
            }

            if (((GridRow)superGridControl1.ActiveRow).DataItem is BindingSource)
            {
                row = ((DataRowView)(((BindingSource)((GridRow)superGridControl1.ActiveRow).DataItem)).Current).Row;
            }

            if (row is SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow)
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow ocdr = row as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow;

                if (recepcionFarmaciaTextBox.Text.IsFloatPositive())
                    ocdr.COSTO = double.Parse(recepcionFarmaciaTextBox.Text);
                if (recepcionOfertaRealTextBox.Text.IsFloatPositive())
                    ocdr.PORC_OFERTA = float.Parse(recepcionOfertaRealTextBox.Text);
                if (recepcionFinancieroTextBox.Text.IsFloatPositive())
                    ocdr.PORC_DESCTO = float.Parse(recepcionFinancieroTextBox.Text);
                if (recepcionDescuentoAdicional1TextBox.Text.IsFloatPositive())
                    ocdr.PORC_DESCTO_AD1 = float.Parse(recepcionDescuentoAdicional1TextBox.Text);
                if (recepcionDescuentoAdicional2TextBox.Text.IsFloatPositive())
                    ocdr.PORC_DESCTO_AD2 = float.Parse(recepcionDescuentoAdicional2TextBox.Text);
                if (recepcionDescuentoAdicional3TextBox.Text.IsFloatPositive())
                    ocdr.PORC_DESCTO_AD3 = float.Parse(recepcionDescuentoAdicional3TextBox.Text);


                //decimal resultado = ocdr.COSTO - (ocdr.COSTO * (ocdr.PORC_DESCTO / 100m));
                //ocdr.RES_CAL1_DESCTO = resultado;
                //resultado = resultado - (resultado * (ocdr.PORC_OFERTA / 100m));
                //ocdr.RES_CAL2_OFERTA = resultado;

                //this.recepcionResultadoTextBox.Text = resultado.ToString();
                //decimal adicional = resultado - (resultado * (ocdr.PORC_DESCTO_AD1 / 100m));
                //ocdr.RES_CAL3_DESCTOAD1 = (double)adicional;
                //adicional = adicional - (adicional * (ocdr.PORC_DESCTO_AD2 / 100m));
                //ocdr.RES_CAL4_DESCTOAD2 = (double)adicional;
                //adicional = adicional - (adicional * (ocdr.PORC_DESCTO_AD3 / 100m));
                //ocdr.RES_CAL5_DESCTOAD3 = (double)adicional;
                //adicional = adicional - (adicional * (ocdr.PORC_DESCTO_AD4 / 100m));
                //ocdr.RES_CAL6_DESCTOAD4 = (double)adicional;

                //this.recepcionCostoTextBox.Text = adicional.ToString();
                //ocdr.COSTO_ULT_COMPRA = (decimal)adicional;

                if (descuentoTextBoxX.Text.IsFloat())
                {
                    ocdr.DESCUENTO_GENERAL = float.Parse(descuentoTextBoxX.Text);
                    ocdr.EsDirecto = false;
                }

                this.calculaUtilidad(ocdr, false, true);
            }
            this.Update();
        }

        private void nuevoFlemingTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Leave(object sender, EventArgs e)
        {
            Update();
        }

        private void AsignacionPreciosOrdenCompraDetallesUserControl_Enter(object sender, EventArgs e)
        {
            this.Update();
        }

        private void calculadoraButtonItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("calc.exe");
            }
            catch
            {

            }
        }

        //private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        //{
        //    this.Update();
        //}

        private void tableLayoutPanel4_ParentChanged(object sender, EventArgs e)
        {
            this.Update();
        }

        private void groupBox3_LocationChanged(object sender, EventArgs e)
        {
            //groupBox3.Refresh();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            // this.Update();
        }

        private void tableLayoutPanel11_Scroll(object sender, ScrollEventArgs e)
        {
            //this.Update();
        }

        private void recepcionMaximoPublicoTextBox_KeyUp(object sender, KeyEventArgs e)
        {


        }

        private void groupBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                //e.Handled = true;
                SendKeys.Send("{TAB}");
            }

        }

        //private void superGridControl1_PreRenderRow(object sender, GridPreRenderRowEventArgs e)
        //{
        //return;
        //SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row = (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow)((DataRowView)((GridRow)(e.GridRow)).DataItem).Row;

        //if (row == null)
        //{
        //    return;
        //}

        //e.GridRow.CellStyles.Default = normalRowStyle;
        //e.GridRow.RowStyles.Default.ApplyStyle(normalRowStyle);

        //if (row.CANT_RECIBIDA < row.CANT_RECIBIDA)
        //{
        //    e.GridRow.CellStyles.Default = faltanteRowStyle;
        //    e.GridRow.RowStyles.Default.ApplyStyle(faltanteRowStyle);
        //}

        //if (row.MARGEN_UTILIDAD <= 0)
        //{
        //    e.GridRow.CellStyles.Default = WarningCellStyle;
        //    e.GridRow.RowStyles.Default.ApplyStyle(WarningCellStyle);
        //}

        //if (row.CANT_FACTURADA == 0)
        //{
        //    e.GridRow.CellStyles.Default = revisarRowStyle;
        //    e.GridRow.RowStyles.Default.ApplyStyle(revisarRowStyle);
        //}
        //}

        private void superGridControl1_SortChanged(object sender, GridEventArgs e)
        {
            if (e.GridPanel == superGridControl1.PrimaryGrid)
            {
                foreach (GridRow GridRow in superGridControl1.PrimaryGrid.Rows)
                {
                    pintaFila(GridRow);
                }
            }
        }

        private void pintaFila(GridRow GridRow)
        {
            if (GridRow == null)
            {
                return;
            }

            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row = null;

            if (GridRow.DataItem is System.Windows.Forms.BindingSource)
            {
                string art = GridRow.Cells["ARTICULOColumn"].Value.ToString();
                var vencontrado = from a in compraL.CompraDetalles where a.ARTICULO_ID == art select a;
                row = vencontrado.First();
            }

            if (GridRow.DataItem is DataRowView)
            {
                row = (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow)((DataRowView)(GridRow.DataItem)).Row;
            }


            if (row == null)
            {
                return;
            }

            //superGridControl1.PrimaryGrid.SetActiveRow(GridRow);

            //GridRow.Cells["ARTICULOColumn"].CellStyles = normalCellStyle;
            GridRow.CellStyles.Default = normalRowStyle;
            GridRow.RowStyles.Default.ApplyStyle(normalRowStyle);

            if (row.CANT_RECIBIDA < row.CANT_SOLICITADA)
            {
                GridRow.Cells["NOMBREColumn"].CellStyles = faltanteCellStyle;
                // GridRow.Cells["NOMBREColumn"].CellStyles.Default.Background = faltanteCellStyle.Default.Background;
                GridRow.Cells["NOMBREColumn"].CellStyles.Default = faltanteCellStyle.Default;
                GridRow.Cells["NOMBREColumn"].CellStyles.Default.ApplyStyle(faltanteCellStyle.Default);
                //GridRow.CellStyles.Default = faltanteRowStyle;
                //GridRow.RowStyles.Default.ApplyStyle(faltanteRowStyle);
            }

            if (!row.IsMARGEN_UTILIDADNull())
                if (row.MARGEN_UTILIDAD <= 0)
                {
                    GridRow.Cells["ARTICULOColumn"].CellStyles = warningCellStyle;
                    //GridRow.Cells["ARTICULOColumn"].CellStyles.Default.Background = warningCellStyle.Default.Background;
                    GridRow.Cells["ARTICULOColumn"].CellStyles.Default.ApplyStyle(warningCellStyle.Default);
                    //GridRow.CellStyles.Default = warningCellStyle;
                    //GridRow.RowStyles.Default.ApplyStyle(WarningCellStyle);
                }

            if (!row.IsCANT_FACTURADANull())
                if (row.CANT_RECIBIDA == 0)
                {
                    GridRow.Cells["NOMBREColumn"].CellStyles = revisarCellStyle;
                    //GridRow.Cells["NOMBREColumn"].CellStyles.Default.Background = revisarCellStyle.Default.Background;
                    GridRow.Cells["NOMBREColumn"].CellStyles.Default.ApplyStyle(revisarCellStyle.Default);
                    //GridRow.CellStyles.Default = revisarRowStyle;
                    //GridRow.RowStyles.Default.ApplyStyle(revisarRowStyle);
                }
        }

        private void superGridControl1_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            pintaFila(e.GridPanel.ActiveRow as GridRow);
        }

        private void superGridControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void recepcionMaximoPublicoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var control = GetNextControl(sender as Control, true);
                control.Focus();
                e.SuppressKeyPress = true;
                GridRow grow = (GridRow)this.superGridControl1.PrimaryGrid.ActiveRow;

                SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row = null;

                if (grow.DataItem is System.Windows.Forms.BindingSource)
                {
                    string art = grow.Cells["ARTICULOColumn"].Value.ToString();
                    var vencontrado = from a in compraL.CompraDetalles where a.ARTICULO_ID == art select a;
                    row = vencontrado.First();
                }

                if (grow.DataItem is DataRowView)
                {
                    row = (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow)((DataRowView)(grow.DataItem)).Row;
                }

                if ((TextBox)sender == recepcionFarmaciaTextBox)
                {
                    if (recepcionFarmaciaTextBox.Text.IsFloat())
                    {
                        row.PRECIO_FARMACIA = double.Parse(recepcionFarmaciaTextBox.Text);

                        if (row.FacturaProveedorDetalle != null)
                        {
                            row.FacturaProveedorDetalle.PRECIO_VENTA_FAR = (decimal)row.PRECIO_FARMACIA;
                        }
                    }
                }

                //if (row.FacturaProveedorDetalle == null)
                //{
                //    row.FacturaProveedorDetalle = new SIFModelo.OrdenCompra.OrdenesCompraDataSet().FACTURA_PROVEEDOR_DET.NewFACTURA_PROVEEDOR_DETRow();
                //    row.FacturaProveedorDetalle.ARTICULO_ID = row.ARTICULO_ID;
                //}
                if (row.FacturaProveedorDetalle != null)
                {
                    row.FacturaProveedorDetalle.PRECIO_VENTA_MAX = System.Convert.ToDecimal(recepcionMaximoPublicoTextBox.Text);
                }
                row.PRECIO_FACTURA_MAX = System.Convert.ToDouble(recepcionMaximoPublicoTextBox.Text);
                row.PRECIO_MAXIMO = System.Convert.ToDouble(recepcionMaximoPublicoTextBox.Text);
                row.PRECIO_FACTURA = System.Convert.ToDouble(recepcionFarmaciaTextBox.Text);

                //if (row.ListaPrecios != null)
                //{
                //    row.ListaPrecios.PRECIO_VENTA_MAX = System.Convert.ToDecimal(recepcionMaximoPublicoTextBox.Text);
                //}

                row.Table.AcceptChanges();
                this.superGridControl1.Refresh();

                //else
                //{
                //    row.FacturaProveedorDetalle.PRECIO_VENTA_MAX = decimal.Parse(recepcionMaximoPublicoTextBox.Text);
                //}
            }
        }

        private void agregaProductoButtonItem_Click(object sender, EventArgs e)
        {
            View.Catalogos.ArticuloUserControl ctlArticulos = new Catalogos.ArticuloUserControl();


            if (Owner is View.OrdenCompra.AsignacionPreciosOrdenCompraUserControl)
            {
                View.OrdenCompra.AsignacionPreciosOrdenCompraUserControl propietario = Owner as View.OrdenCompra.AsignacionPreciosOrdenCompraUserControl;
                ctlArticulos.Owner = propietario.Owner.Owner;
            }

            if (Owner is View.OrdenCompra.OrdenesCompraUserControl)
            {
                View.OrdenCompra.OrdenesCompraUserControl propietario = Owner as View.OrdenCompra.OrdenesCompraUserControl;
                ctlArticulos.Owner = propietario.Owner;
            }

            ctlArticulos.Muestra();
        }

        private void nuevoFlemingTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (nuevoFlemingTextBox.Text.IsFloatPositive())
                {
                    this.calculaUtilidad(true);
                }
            }




            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                //MOVER AL SIGUIENTE REGISTRO
                if (superGridControl1.PrimaryGrid.ActiveRow.Index != superGridControl1.PrimaryGrid.Rows.Count - 1)
                {
                    var rw = superGridControl1.PrimaryGrid.Rows[superGridControl1.PrimaryGrid.ActiveRow.Index + 1];
                    superGridControl1.PrimaryGrid.SetActiveRow(rw as GridContainer);
                }
                // this.preciosBindingSource.MoveNext();


                this.recepcionMaximoPublicoTextBox.Focus();

                e.Handled = true;
            }
        }

        private void ubicar()
        {


            var encontrado = from a in compraL.CompraDetalles where a.ARTICULO_ID.ToUpper().Contains(this.buscarTextBoxX.Text.ToUpper()) || a.NOMBRE.ToUpper().Contains(buscarTextBoxX.Text.ToUpper()) select a;

            if (encontrado.Count() > 0)
            {
                //this.superGridControl1.PrimaryGrid.SelectedRows = superGridControl1.PrimaryGrid
                //
                foreach (GridRow row in superGridControl1.PrimaryGrid.Rows)
                {
                    SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow dRow = null;
                    if (row.DataItem is System.Windows.Forms.BindingSource)
                    {
                        dRow = ((DataRowView)((BindingSource)row.DataItem).Current).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow;
                    }

                    if (row.DataItem is System.Data.DataRowView)
                    {
                        dRow = ((DataRowView)row.DataItem).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow;
                    }

                    foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow det in encontrado.ToList())
                    {
                        if (dRow.ARTICULO_ID == det.ARTICULO_ID)
                        {
                            superGridControl1.PrimaryGrid.Select(row);

                            this.superGridControl1.PrimaryGrid.SetActiveRow(row);
                            // this.superGridControl1.PrimaryGrid.EnsureVisible(true);
                            return;
                            //superGridControl1.PrimaryGrid.scr
                        }
                    }

                    if (row.DataItem is System.Windows.Forms.BindingSource)
                    {
                        System.Windows.Forms.BindingSource bs = row.DataItem as System.Windows.Forms.BindingSource;
                        bs.MoveNext();
                    }

                }
            }
        }

        private void ubicarButtonX_Click(object sender, EventArgs e)
        {
            this.ubicar();
        }

        private void guardarButtonItem_Click(object sender, EventArgs e)
        {
            Actualiza(true);
        }

        private void AsignarNCButtonItem_Click(object sender, EventArgs e)
        {
            AsignarNotaCredito();


        }

        private void AsignarNotaCredito() 
        {
            //View.OrdenCompra.NotasDeCreditoControl notaCredito = new View.OrdenCompra.NotasDeCreditoControl();
            //notaCredito.ModuloID = 9;
            //notaCredito.Ownern = this;
            //this.DesactivaComandos();
            //notaCredito.Muestra();
          
        }

        private void Actualiza(Boolean notificar = false)
        {
            int cantidad = 0;
            string mensaje = "";
            string estado_old = "";
            int cantTotal = Int32.Parse(compraL.CompraDetalles.Compute("SUM(CANT_RECIBIDA)", null).ToString());
            new SIFNegocio.OrdenCompra.OrdenCompra().Verificar_ctl_oc(Compra.FOLIO_OC, out mensaje, out cantidad, out estado_old);

            List<SIFModelo.OrdenCompra.ArticuloPrecio> articulosConPrecio = new List<SIFModelo.OrdenCompra.ArticuloPrecio>();
            List<string> vistaPrecios = new List<string>(); // Para mostrar los códigos con precios

            foreach (GridRow row in superGridControl1.PrimaryGrid.Rows)
            {
                if (row != null && row.Cells["ARTICULOColumn"].Value != null)
                {
                    string articuloId = row.Cells["ARTICULOColumn"].Value.ToString();
                    var detalle = compraL.CompraDetalles.FirstOrDefault(x => x.ARTICULO_ID == articuloId);

                    if (detalle != null && detalle.NUEVO_FLEMING > 0)
                    {
                        decimal precioNuevo = (decimal)detalle.NUEVO_FLEMING;

                        articulosConPrecio.Add(new SIFModelo.OrdenCompra.ArticuloPrecio
                        {
                            ArticuloId = articuloId,
                            Precio = precioNuevo
                        });

                        // Solo para mostrarlo en el MessageBox
                        //vistaPrecios.Add($"Código: {articuloId} - Precio CDIS: {precioNuevo:C}");
                    }
                }
            }

            //Agregar el parametro que Valida el precio con la UAMPH
            int param = new SIFNegocio.Extras.Parametros().ObtenParametro("COMPARAR_PRECIO_UAMPH");
            if (param > 0)
            {

                // Mostrar los códigos y precios en un mensaje
                //if (vistaPrecios.Any())
                //{
                //   MessageBox.Show(string.Join("\n", vistaPrecios), "Artículos a comparar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                // Llamar a la función que valida contra la base de datos
                SIFNegocio.OrdenCompra.Compras.CompararPrecioUAMPH(articulosConPrecio,
                                                               UsuarioId,
                                                               Compra.FOLIO_OC);
            }
            
            if (mensaje == "1" && notificar)
            {
                if (cantTotal == cantidad)
                {
                    SIFNegocio.OrdenCompra.Compras.ActualizaDetalles(Compra, compraL.CompraDetalles);
                    if (notificar)
                    {
                       MessageBox.Show("Se ha guardado correctamente, sólo se modificaron los precios.");
                    }
                }
                else
                   MessageBox.Show("Error, el total de piezas es diferente a las registradas en el kardex.", "Información");
            }
            else
            {
                SIFNegocio.OrdenCompra.Compras.ActualizaDetalles(Compra, compraL.CompraDetalles);
                if (notificar)
                {
                   MessageBox.Show("Se ha guardado correctamente");
                }
            }
           
        }

        private void ActualizaBack()
        {
            int cantidad = 0;
            string mensaje = "";
            string estado_old = "";
            new SIFNegocio.OrdenCompra.OrdenCompra().Verificar_ctl_oc(Compra.FOLIO_OC, out mensaje, out cantidad, out estado_old);

            if (OrdenCompra.ESTADO_OC != "L" && estado_old.Trim() != "L")
            {
                SIFNegocio.OrdenCompra.Compras.ActualizaDetalles(Compra, compraL.CompraDetalles);

               MessageBox.Show("Se ha guardado correctamente");               
            }

        }

        private void loteCaducidadButtonItem_Click(object sender, EventArgs e)
        {
            String Parm1 = "{CS_DEVOLUCION_COMPRAS.FOLIO_OC_ID} = '" + Compra.FOLIO_OC + "'";
            SIFNegocio.Usuarios Logusu = new SIFNegocio.Usuarios();
            SIFModelo.Usuario Vend = Helpers.Sesion.Usuario;
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_IncidenciasFactura.rpt", Parm1, Vend.Nombre + ' ' + Vend.Apellidos); //"RPT_ResumenCompra.rpt", Parm1, Vend.Nombre + ' ' + Vend.Apellidos);
            Impresion.ShowDialog();
        }

        private void margenTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GridRow grow = (GridRow)this.superGridControl1.PrimaryGrid.ActiveRow;

                SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row = null;

                if (grow.DataItem is System.Windows.Forms.BindingSource)
                {
                    string art = grow.Cells["ARTICULOColumn"].Value.ToString();
                    var vencontrado = from a in compraL.CompraDetalles where a.ARTICULO_ID == art select a;
                    row = vencontrado.First();
                }

                if (grow.DataItem is DataRowView)
                {
                    row = (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow)((DataRowView)(grow.DataItem)).Row;
                }

                decimal porcentajeUtilidad = 0;
                //if (row.FacturaProveedorDetalle != null)
                //{
                porcentajeUtilidad = System.Convert.ToDecimal(margenTextBox.Text);
                //}
                //else
                //{
                //    porcentajeUtilidad = decimal.Parse(margenTextBox.Text);
                //}

                row.NUEVO_FLEMING = (double)(row.COSTO_NETO_UNIT_REC * (double)(1 + (porcentajeUtilidad / 100m)));

                string stringDecimales = row.NUEVO_FLEMING.ToString("0.00");

                string[] decimales = stringDecimales.Split(new char[] { '.' });

                if (decimales.Length > 1)
                {
                    decimal flotante = decimal.Parse(decimales[1]);

                    if (flotante > 0m && flotante < 50m)
                    {
                        row.NUEVO_FLEMING = Math.Truncate(row.NUEVO_FLEMING);
                    }

                    if (flotante > 50m && flotante <= 99m)
                    {
                        row.NUEVO_FLEMING = Math.Truncate(row.NUEVO_FLEMING) + 0.5;
                    }
                }

                nuevoFlemingTextBox.Text = row.NUEVO_FLEMING.ToString("0.00");

                this.calculaUtilidad(true);
            }
        }

        private void Desc1TextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (superGridControl1.ActiveRow == null)
                {
                    return;
                }

                SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow ocdr = null;

                if (((GridRow)superGridControl1.ActiveRow).DataItem is BindingSource)
                {
                    ocdr = ((DataRowView)((BindingSource)((GridRow)superGridControl1.ActiveRow).DataItem).Current).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow;
                }

                if (((GridRow)superGridControl1.ActiveRow).DataItem is DataRowView)
                {
                    ocdr = ((DataRowView)((GridRow)superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow;
                }

                ocdr.DESC1_DESC = Desc1TextBoxX.Text;
            }
        }

        private void Desc2TextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (superGridControl1.ActiveRow == null)
                {
                    return;
                }

                SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow ocdr = null;

                if (((GridRow)superGridControl1.ActiveRow).DataItem is BindingSource)
                {
                    ocdr = ((DataRowView)((BindingSource)((GridRow)superGridControl1.ActiveRow).DataItem).Current).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow;
                }

                if (((GridRow)superGridControl1.ActiveRow).DataItem is DataRowView)
                {
                    ocdr = ((DataRowView)((GridRow)superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow;
                }

                ocdr.DESC2_DESC = Desc2TextBoxX.Text;
            }
        }

        private void Desc3TextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (superGridControl1.ActiveRow == null)
                {
                    return;
                }

                SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow ocdr = null;

                if (((GridRow)superGridControl1.ActiveRow).DataItem is BindingSource)
                {
                    ocdr = ((DataRowView)((BindingSource)((GridRow)superGridControl1.ActiveRow).DataItem).Current).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow;
                }

                if (((GridRow)superGridControl1.ActiveRow).DataItem is DataRowView)
                {
                    ocdr = ((DataRowView)((GridRow)superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow;
                }

                ocdr.DESC3_DESC = Desc3TextBoxX.Text;
            }
        }

        private void kardexButtonItem_Click(object sender, EventArgs e)
        {
            View.Inventario.KardexAlmacenUserControl frmkardex = new Inventario.KardexAlmacenUserControl();

            MainForm mf = null;
            if (this.Owner is SIF.View.OrdenCompra.OrdenesCompraUserControl)
            {
                mf = ((View.Menu.ComprasMenu)((SIF.View.OrdenCompra.OrdenesCompraUserControl)this.Owner).Owner).Owner;
            }

            frmkardex.Owner = mf;
            frmkardex.Muestra();
        }

        private void buscarTextBoxX_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ubicar();
            }
        }


        private void GetListSkuOfertasMes(List<string> skOc) {

            List<SIFModelo.Ofertas.ListaPromocionesActivas> data = new SIFNegocio.OrdenCompra.ManejoDescuentos().GetListSkuPromociones();

            if (data != null && data.Any())
            {
                // 1. Filtramos los objetos que coinciden con skOc y formateamos el string: "ArticuloID Nombre1"
                var coincidenciasFormateadas = data
                    .Where(p => skOc.Contains(p.ArticuloID))
                    .Select(p => $"{p.ArticuloID} {p.Nombre1}");

                // 2. Verificamos si encontramos alguna coincidencia
                if (coincidenciasFormateadas.Any())
                {
                    // 3. Unimos todas las líneas con un salto de línea
                    string result = string.Join(Environment.NewLine, coincidenciasFormateadas);

                    MessageBox.Show("Artículos en campaña:" + Environment.NewLine + result, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

    }
}
