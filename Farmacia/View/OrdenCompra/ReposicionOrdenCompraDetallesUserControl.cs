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
using System.Globalization;

namespace SIF.View.OrdenCompra
{
    public partial class ReposicionOrdenCompraDetallesUserControl: Templates.ListaUserControl
    {
        SIFNegocio.Clientes proveedororden = new SIFNegocio.Clientes();
        SIFModelo.Cliente proveedorDev = new SIFModelo.Cliente();
        SIFModelo.Usuario userDEv = new SIFModelo.Usuario();
        SIFNegocio.Articulo articulo = new SIFNegocio.Articulo();
        decimal dev = 0, totalDev = 0, totalRec = 0, rec = 0;
        decimal ivaa = 0, piva = 0, montoIva = 0;
        public ReposicionOrdenCompraDetallesUserControl(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow ordenCompra, SIFModelo.Usuario usuario)
        {

            InitializeComponent();
            this.OrdenCompra = ordenCompra;
            userDEv = usuario;
            //this.EstableceOrdenCompra();
            //CargaRecepcionistas();

            EstableceCompra();
            this.inicializaColoresFilas();

            //this.buscarTextBoxX.Focus();
            this.superGridControl1.PrimaryGrid.AllowRowDelete = false;
        }

        /*private void CargaRecepcionistas()
        {
            List<string> recepcionistas = ordenCompraL.ListaRecepcionistas();

            foreach (string recepcionista in recepcionistas)
            {
                this.recibeComboBoxEx.Items.Add(recepcionista);
            }
        }*/
        bool esNueva = false;
        private void EstableceCompra()
        {
            
            compra = SIFNegocio.OrdenCompra.Compras.OrdenCompraPorOCId(OrdenCompra);
            if (compra != null)
            {
                detalles = SIFNegocio.OrdenCompra.Compras.OrdenCompraDetallesPorCompraId(compra);

                detallesDev = SIFNegocio.OrdenCompra.Compras.DetallesRepPorCompraId(compra.FOLIO_COMPRA.ToString());
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow facturaRow = new SIFNegocio.OrdenCompra.OrdenCompra().FacturaPorNumero(OrdenCompra);

            if (facturaRow != null)
            {
                compra.FACTURA = facturaRow.NUM_FACTURA;
                compra.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                //compra.FOLIO_COMPRA = "";
                compra.FOLIO_FACTURA_SAT = facturaRow.FOLIO_FACTURA_SAT;
                compra.FOLIO_OC = OrdenCompra.FOLIO_OC_ID;
                compra.IMP_DESC_FALTANTE = 0;
                compra.IMP_FALTANTE = 0;

                SIFModelo.OrdenCompra.OrdenesCompraDataSet facturasDS = ordenCompraL.DetallesFacturaProveedor(facturaRow);
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETDataTable facturas = facturasDS.FACTURA_PROVEEDOR_DET;
                if (facturas.Count == 0)
                {
                   MessageBox.Show("No hay artículos asociados a una factura", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                foreach (var detalle in detalles)
                {
                    var facturaEncontrada = from f in facturas where f.ARTICULO_ID.Trim() == detalle.ARTICULO_ID.Trim() select f;

                    if (facturaEncontrada.Count() > 0)
                    {
                        SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETRow facturaDetalle = facturaEncontrada.First();


                        detalle.FacturaProveedorDetalle = facturaDetalle;
                        if (!esNueva)
                        {

                            //  if (detalle.CANT_FACTURADA == 0)
                            //detalle.CANT_FACTURADA = facturaDetalle.PZA_CCARGO;
                            //    if (detalle.CANT_RECIBIDA == 0)
                            
                            //-facturaDetalle.PZA_CCARGO
                            detalle.CANT_RECIBIDA = detalle.CANT_FACTURADA - detalle.CANT_DEV_FALTANTE - detalle.CANT_DEV_NO_PEDIDO - detalle.CANT_DEV_PRECIO_ELEVADO - detalle.CANT_MALESTADO - detalle.CANT_PROX_CADUCAR;
                        }
                        else
                        {
                            detalle.CANT_FACTURADA = facturaDetalle.PZA_CCARGO;
                            detalle.CANT_RECIBIDA = facturaDetalle.PZA_CCARGO;
                        }
                    }
                    else
                    {
                        detalle.CANT_RECIBIDA = 0;
                        detalle.CANT_FACTURADA = 0;
                    }
                    //else
                    //{
                    //    if (detalle.CANT_FACTURADA == 0)
                    //    detalle.CANT_RECIBIDA = 0;
                    //    if (detalle.CANT_RECIBIDA == 0)
                    //    detalle.CANT_FACTURADA = 0;
                    //}
                    //if (detalles.Count < facturas.Count)
                    //{
                    //    var noEcontradas = from f in facturas where f.ARTICULO_ID != detalles.ToList().Rows["ARTICULO_ID"].ToString() select f;

                    //    if (noEcontradas.Count() > 0)
                    //    {
                    //        foreach (var factura in noEcontradas)
                    //        { 
                    //            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow artRow = detalles.NewCOMPRAS_DETRow();
                    //            artRow.ARTICULO_ID = factura.ARTICULO_ID;
                    //            artRow.NOMBRE = "NO PEDIDO";

                    //        }
                    //    }
                    //}




                }

                //foreach (var facN in facturas)
                // {
                //     var facturaNoEncontrada = from d in detalles where d.ARTICULO_ID.Trim() == facN.ARTICULO_ID.Trim() select d;

                //     if (facturaNoEncontrada.Count() == 0)
                //     {
                //         SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow artRow = detalles.NewCOMPRAS_DETRow();
                //         artRow.ARTICULO_ID = facN.ARTICULO_ID;
                //         artRow.NOMBRE = "NO PEDIDO";
                //         artRow.FOLIO_COMPRA = compra.FOLIO_COMPRA;
                //         artRow.FOLIO_OC = compra.FOLIO_OC;
                //         artRow.OBSERVACIONES = "NO PEDIDO";
                //         artRow.PROVEEDOR_ID = compra.PROVEEDOR_ID;
                //         artRow.CANT_FACTURADA = facN.
                //     }

                // }

                //BUSCAR LAS FACTURAS QUE NO ESTAN EN LA ORDEN DE COMPRA

                lineasFacturaLabel.Text = "0";
                /*
                foreach (SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETRow detalleFactura in facturas.Rows)
                {
                    //var detalleEncontrada = from f in facturas where f.ARTICULO_ID.Trim() == detalleFactura.ARTICULO_ID.Trim() select f;
                    var detalleEncontrada = from d in detalles where d.ARTICULO_ID.Trim() == detalleFactura.ARTICULO_ID.Trim() select d;

                    //SI NO ENCONTRAMOS LA FACTURA ENTONCES AGREGAR EL DETALLE A DETALLES
                    if (detalleEncontrada.Count() == 0)
                    {
                        SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow detalle = this.detalles.NewCOMPRAS_DETRow();

                        detalle.ARTICULO_ID = detalleFactura.ARTICULO_ID;
                        // det.CADUCIDAD = ocd.;
                        detalle.CANT_PROX_CADUCAR = 0;
                        detalle.CANT_FACTURADA = detalleFactura.PZA_CCARGO;
                        detalle.CANT_MALESTADO = 0;
                        detalle.CANT_RECIBIDA = 0;
                        detalle.CANT_REPOSICION = 0;
                        detalle.CANT_SOLICITADA = 0;
                        detalle.CODIGO_PROVEEDOR = detalleFactura.CODIGO_PROVEEDOR;
                        detalle.COSTO = (double)detalleFactura.COSTO_NETO_UNITARIO;
                        detalle.COSTO_NETO_UNIT_REC = (double)detalleFactura.COSTO_NETO_UNITARIO;
                        detalle.COSTO_ULT_COMPRA = 0;
                        detalle.DESCUENTO_GENERAL = 0;
                        detalle.DIF_DESCTO_IVA = 0;
                        //det.FacturaProveedorDetalle = 
                        //det.FLAG_MAL_OFERTADO = ocd.
                        detalle.FOLIO_COMPRA = compra.FOLIO_COMPRA;
                        detalle.FOLIO_OC = compra.FOLIO_OC;
                        detalle.IMP_CAL1_OFERTA_CONIVA = 0;
                        detalle.IMP_CAL1_OFERTA_SINIVA = 0;
                        detalle.IMP_DESCTO_CONIVA = 0;
                        detalle.IMP_DESCTO_CONIVA_MENOSIVA = 0;
                        detalle.IMP_DESCTO_SINIVA = 0;
                        detalle.IMP_FACTURA_CONIVA = 0;
                        detalle.IMP_FACTURA_SINIVA = 0;
                        detalle.IMP_OFERTA_CONIVA = 0;
                        detalle.IMP_OFERTA_SINIVA = 0;
                        detalle.IMP_RECEPCION_CONIVA = 0;
                        detalle.IMP_RECEPCION_SINIVA = 0;
                        detalle.IMPORTE_IVA = 0;
                        detalle.IMPORTE_NETO = 0;
                        detalle.IVA_MAL_OFERTADO = 0;
                        detalle.LOTE = "";
                        detalle.MAL_OFERTADO = 0;
                        detalle.MARGEN_UTILIDAD = 0;

                        SIFModelo.Articulo art = new SIFNegocio.Articulo().BuscarPorClave(detalle.ARTICULO_ID);

                        if (art == null)
                        {
                            detalle.NOMBRE = "NO PEDIDO"; // detalleFactura.NOMBRE1;
                        }
                        else
                        {
                            detalle.NOMBRE = art.NOMBRE1;
                        }

                        detalle.NUEVO_FLEMING = 0;
                        detalle.PORC_DESCTO = 0;
                        detalle.PORC_DESCTO_AD1 = 0;
                        detalle.PORC_DESCTO_AD2 = 0;
                        detalle.PORC_DESCTO_AD3 = 0;
                        detalle.PORC_DESCTO_AD4 = 0;
                        detalle.PORC_IVA = 0;
                        detalle.PORC_OFERTA = 0;
                        detalle.PRECIO_FACTURA = 0;
                        detalle.PRECIO_FACTURA_MAX = 0;
                        detalle.PRECIO_FARM_REC = 0;
                        detalle.PRECIO_FARMACIA = 0;
                        detalle.PRECIO_FLEMING = 0;
                        detalle.PRECIO_MAXIMO = 0;
                        detalle.PRECIO_VENTA = 0;
                        detalle.PROVEEDOR_ID = compra.PROVEEDOR_ID;
                        detalle.RES_CAL1_DESCTO = 0;
                        detalle.RES_CAL2_OFERTA = 0;
                        detalle.RES_CAL3_DESCTOAD1 = 0;
                        detalle.RES_CAL4_DESCTOAD2 = 0;
                        detalle.RES_CAL5_DESCTOAD3 = 0;
                        detalle.RES_CAL6_DESCTOAD4 = 0;
                        detalle.SIN_OFERTA = 0;
                        detalle.TOTAL_DESCTO_FACTURA = 0;
                        detalle.TOTAL_OFERTA_FACTURA = 0;

                        detalles.AddCOMPRAS_DETRow(detalle);
                    }

                    //else //ASIGNAR EL MONTO DE LA FACTURA
                    //{
                    //   // detalleEncontrada
                    //}
                    lineasFacturaLabel.Text = facturas.Rows.Count.ToString();
                }*/

            }

            this.superGridControl1.PrimaryGrid.DataSource = detalles;
            this.superGridControl1.PrimaryGrid.DataSource = detallesDev;
            //this.superGridControl1.PrimaryGrid.DataMember = "COMPRAS_DET";

            this.lineasLabel.Text = detalles.Rows.Count.ToString();
            this.observacionesGeneralesTextBox.Text = compra.OBSERVACIONES;
            /*this.recibeComboBoxEx.Text = compra.RECEPCIONISTA;*/
            this.folioLabel.Text = compra.FOLIO_COMPRA;
            proveedorDev = proveedororden.ClientePorID(compra.PROVEEDOR_ID);
            this.proveedorLabel.Text = compra.PROVEEDOR_ID.ToString() + ": " + proveedorDev.Nombre + " " + proveedorDev.ApellidoPaterno + " " + proveedorDev.ApellidoMaterno;
            this.direccionalmacenLabel.Text = compra.FOLIO_OC;
            this.statusOClabel.Text = compra.ACTIVO;
            this.fechaElaboracionLabel.Text = compra.FECHA.ToShortDateString();
            this.facturaLabel.Text = compra.FACTURA;

            CalculaTotal();
        }

        SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OrdenCompra;
        private SIFNegocio.OrdenCompra.OrdenCompra ordenCompraL = new SIFNegocio.OrdenCompra.OrdenCompra();

        SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow compra;
        SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable detalles;
        List<SIFModelo.OrdenCompra.RepoProveedor> detallesDev;

        
        private void AgregaArticulo()
        {
            View.Articulos.ArticuloUserControl frmArticulos = new View.Articulos.ArticuloUserControl();
            frmArticulos.Owner = this;
            frmArticulos.Muestra();
        }

        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            if (articulo == null)
            {
               MessageBox.Show("Debe elgir un producto para la orden de compra");
                return;
            }

            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row = detalles.NewCOMPRAS_DETRow();
            row.ARTICULO_ID = articulo.ARTICULO_ID;
            row.NOMBRE = articulo.NOMBRE1;
            row.CANT_SOLICITADA = 0;
            row.FOLIO_COMPRA = compra.FOLIO_COMPRA;
            row.FOLIO_OC = compra.FOLIO_OC;
            row.PROVEEDOR_ID = compra.PROVEEDOR_ID;
            detalles.AddCOMPRAS_DETRow(row);

            this.lineasLabel.Text = detalles.Rows.Count.ToString();

        }

        private void EstableceOrdenCompra()
        {
            //
            //vDetalles = new DataView(ordenCompraL.OrdenCompraDetalles);

            compra = SIFNegocio.OrdenCompra.Compras.OrdenCompraPorOCId(OrdenCompra);
            if (compra != null)
            {
                detalles = SIFNegocio.OrdenCompra.Compras.OrdenCompraDetallesPorCompraId(compra);
            }
            else
            {
                ordenCompraL.BuscaOrdenCompraDetalle(OrdenCompra);

                compra = new SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASDataTable().NewCOMPRASRow();
                detalles = new SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable();

                SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow facturaRow = new SIFNegocio.OrdenCompra.OrdenCompra().FacturaPorNumero(OrdenCompra);

                if (facturaRow != null)
                {
                    compra.FACTURA = facturaRow.NUM_FACTURA;
                    compra.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                    compra.FOLIO_COMPRA = "";
                    compra.FOLIO_FACTURA_SAT = facturaRow.FOLIO_FACTURA_SAT;
                    compra.FOLIO_OC = OrdenCompra.FOLIO_OC_ID;
                    compra.IMP_DESC_FALTANTE = 0;
                    compra.IMP_FALTANTE = 0;

                    SIFModelo.OrdenCompra.OrdenesCompraDataSet facturasDS = ordenCompraL.DetallesFacturaProveedor(facturaRow);
                    SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETDataTable facturas = facturasDS.FACTURA_PROVEEDOR_DET;
                    if (facturas.Count == 0)
                    {
                       MessageBox.Show("No hay artículos asociados a una factura", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    foreach (var detalle in ordenCompraL.OrdenCompraDetalles)
                    {
                        var facturaEncontrada = from f in facturas where f.ARTICULO_ID.Trim() == detalle.ARTICULO_ID.Trim() select f;

                        if (facturaEncontrada.Count() > 0)
                        {
                            SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETRow facturaDetalle = facturaEncontrada.First();

                            if (detalle.CANT_FACTURADA == 0)
                                detalle.CANT_FACTURADA = facturaDetalle.PZA_CCARGO;
                            if (detalle.CANT_RECIBIDA == 0)
                                detalle.CANT_RECIBIDA = facturaDetalle.PZA_CCARGO;
                        }
                        //else
                        //{
                        //    if (detalle.CANT_FACTURADA == 0)
                        //    detalle.CANT_RECIBIDA = 0;
                        //    if (detalle.CANT_RECIBIDA == 0)
                        //    detalle.CANT_FACTURADA = 0;
                        //}
                    }

                    //BUSCAR LAS FACTURAS QUE NO ESTAN EN LA ORDEN DE COMPRA
                    foreach (SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETRow detalleFactura in facturas.Rows)
                    {
                        var detalleEncontrada = from f in facturas where f.ARTICULO_ID.Trim() == detalleFactura.ARTICULO_ID.Trim() select f;

                        //SI NO ENCONTRAMOS LA FACTURA ENTONCES AGREGAR EL DETALLE A DETALLES
                        if (detalleEncontrada.Count() == 0)
                        {
                            SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow detalle = ordenCompraL.OrdenCompraDetalles.NewORDEN_COMPRA_DETRow();
                            detalle.CANT_SOLICITADA = 0;
                            detalle.CANT_FACTURADA = detalleFactura.PZA_CCARGO;
                            detalle.ARTICULO_ID = detalleFactura.ARTICULO_ID;
                            detalle.CANT_DEVUELTA = 0;
                            detalle.CANT_MALESTADO = 0;
                            detalle.CANT_RECIBIDA = 0;
                            detalle.CANT_REPOSICION = 0;
                            detalle.DESCRIP_OFERTA = "";
                            detalle.DESCTO_FACTURA = (decimal)detalleFactura.PORC_DESCTO;
                            detalle.DESCTO_FACTURA_AD1 = (decimal)detalleFactura.PORC_OFERTA;
                            detalle.DESCTO_RECIBIDO = 0;
                            detalle.DESCTO_RECIBIDO_AD1 = 0;
                            detalle.DESCTO_RECIBIDO_AD2 = 0;
                            detalle.EXISTENCIAS = 0;
                            detalle.FOLIO_OC_ID = OrdenCompra.FOLIO_OC_ID;
                            detalle.IMPORTE = 0;

                            SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ARTICULO_ID);
                            detalle.LABORATORIO_ID = articulo.LABORATORIO_ID;
                            detalle.NOMBRE = articulo.NOMBRE1;
                            detalle.NUM_PARTIDA = ordenCompraL.OrdenCompraDetalles.Rows.Count + 1;
                            detalle.OFERTA_COMPRA_ID = 0;
                            detalle.PRECIO_COSTO = (decimal)detalleFactura.PRECIO_VENTA_FAR;
                            detalle.PRECIO_FACTURA = detalle.PRECIO_FACTURA;
                            detalle.PROVEEDOR_ID = OrdenCompra.PROVEEDOR_ID;
                            detalle.PUNTO_DE_REORDEN = 0;
                            detalle.TIPO_MEDICAMENTO_CVE = articulo.TIPO_MEDICAMENTO_CVE;
                            detalle.ULT_PRECIO_COMPRA = 0;
                            detalle.USUARIO_ID = int.Parse(OrdenCompra.USUARIO_ID);
                        }

                    }

                }

                foreach (var detalle in ordenCompraL.OrdenCompraDetalles)
                {
                    SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow detalleC = detalles.NewCOMPRAS_DETRow();
                    detalleC.ARTICULO_ID = detalle.ARTICULO_ID;
                    detalleC.CANT_PROX_CADUCAR = detalle.CANT_DEVUELTA;
                    detalleC.CANT_FACTURADA = detalle.CANT_FACTURADA;
                    detalleC.CANT_MALESTADO = detalle.CANT_MALESTADO;
                    detalleC.CANT_RECIBIDA = detalle.CANT_RECIBIDA;
                    detalleC.CANT_SOLICITADA = detalle.CANT_SOLICITADA;
                    //detalleC.CODIGO_PROVEEDOR = "0";
                    detalleC.PORC_OFERTA = (float)detalle.DESCTO_RECIBIDO;
                    detalleC.COSTO = (double)detalle.PRECIO_COSTO;
                    detalleC.COSTO_NETO_UNIT_REC = 0;
                    detalleC.PROVEEDOR_ID = OrdenCompra.PROVEEDOR_ID;
                    detalleC.RES_CAL1_DESCTO = 0;
                    detalleC.RES_CAL2_OFERTA = 0;
                    detalleC.RES_CAL3_DESCTOAD1 = 0;
                    detalleC.RES_CAL4_DESCTOAD2 = 0;
                    detalleC.RES_CAL5_DESCTOAD3 = 0;
                    detalleC.RES_CAL6_DESCTOAD4 = 0;
                    detalleC.SIN_OFERTA = 0;
                    detalleC.TOTAL_DESCTO_FACTURA = 0;
                    detalleC.TOTAL_OFERTA_FACTURA = 0;
                    detalleC.PRECIO_FACTURA = (double)detalle.PRECIO_FACTURA;
                    detalleC.PRECIO_FARMACIA = (double)detalle.PRECIO_FARMACIA;
                    detalleC.FOLIO_COMPRA = "";


                    detalleC.NOMBRE = detalle.NOMBRE;
                    //detalleC.CADUCIDAD = DBNull.Value;

                    detalleC.FOLIO_COMPRA = "";
                    detalleC.FOLIO_OC = detalle.FOLIO_OC_ID;
                    detalleC.IVA_MAL_OFERTADO = 0;

                    detalleC.LOTE = "";
                    detalleC.NOMBRE = detalle.NOMBRE;


                    if (detalleC.IsCANT_FACTURANull())
                        detalleC.CANT_FACTURA = 0;



                    detalleC.CANT_DEV_FILLER1 = 0;
                    detalleC.CANT_DEV_FILLER2 = 0;

                    detalleC.CANT_PROX_CADUCAR = 0;
                    //detalleC.CADUCIDAD = null;

                    //  detalles.AddCOMPRAS_DETRow(detalleC);
                }


            }//TERMINA COMPRA DETALLES


            //this.superGridControl1.PrimaryGrid.DataSource = ordenCompraL.OrdenCompraDetalles;
            this.superGridControl1.PrimaryGrid.DataSource = detalles;
            this.superGridControl1.PrimaryGrid.DataMember = "COMPRAS_DET";
            //this.superGridControl1.PrimaryGrid.DataSource = vDetalles;

            this.folioLabel.Text = OrdenCompra.FOLIO_OC_ID;
            statusOClabel.Text = OrdenCompra.ESTADO_OC;
            fechaElaboracionLabel.Text = OrdenCompra.FECHA_ALTA.ToShortDateString();
            //if (!OrdenCompra.IsFECHA_RECEPCIONNull())
            //{
            //    fechaRecepcionlabel.Text = OrdenCompra.FECHA_RECEPCION.ToString();
            //}
            //else
            //{
            //    fechaRecepcionlabel.Text = string.Empty;
            //}

            proveedorLabel.Text = OrdenCompra.PROVEEDOR_ID + " " + OrdenCompra.CAT_CLIENTES_NOMBRE;

            SIFModelo.Sucursal sucursalC = new SIFNegocio.Sucursales().SucursalPorID(OrdenCompra.SUCURSAL_ID);

            if (sucursalC != null)
            {
                almacenLabel.Text = OrdenCompra.CAT_SUCURSALES_NOMBRE;
                direccionalmacenLabel.Text = sucursalC.Calle + sucursalC.NumeroExterior + " COL. " + sucursalC.Colonia + "  " + sucursalC.Ciudad;
            }

            //if (!OrdenCompra.IsOBSERVACION_OCNull())
            //{
            //    observacionesGeneralesLabel.Text = OrdenCompra.OBSERVACION_OC;
            //}

            this.CalculaTotal();

            if (OrdenCompra.ESTADO_OC.Trim() != "C" && OrdenCompra.ESTADO_OC.Trim() != "E")
            {
                GridColumn CANTIDAD_RECIBIDAColumn = this.superGridControl1.PrimaryGrid.Columns["CANTIDAD_RECIBIDAColumn"];
                CANTIDAD_RECIBIDAColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
                GridColumn CANTIDAD_FACTURADAColumn = this.superGridControl1.PrimaryGrid.Columns["CANTIDAD_FACTURADAColumn"];
                CANTIDAD_FACTURADAColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);

                this.recibirYAfectarButtonItem.Enabled = false;
                this.recibirButtonItem.Enabled = false;
            }

            compra.ACTIVO = "S";
            compra.DESCUENTO_FACTURA = 0;
            compra.IMP_DESC_FALTANTE = 0;
            compra.IMP_FALTANTE = 0;
            compra.IMP_IVA_MAL = 0;
            compra.IVA_FACTURA = 0;
            compra.MAL_OFERTADO = 0;
            compra.SIN_OFERTA = 0;
            compra.TOT_DESCTO_CONIVA_REC = 0;
            compra.TOT_DESCTO_REC = 0;
            compra.TOT_DESCTO_SINIVA_REC = 0;
            compra.TOT_FACT_RECIBIDO = 0;
            compra.TOT_FACTURA = 0;
            compra.TOT_IMPORTE_REC = 0;
            compra.TOT_IVA_REC = 0;
            compra.TOTAL_DESCTO_DESCUENTOS_REC = 0;
            compra.TOTAL_IVA_DESCTO_REC = 0;
            compra.TOTAL_NETO_RECIBIDO = 0;
            compra.TOTAL_RECIBIDO = 0;
            compra.USUARIO_ID = UsuarioId;
            compra.USUARIO_ID_ASIG_PRECIO = "0";

           /* this.recibeComboBoxEx.Text = compra.RECEPCIONISTA;*/
            observacionesGeneralesTextBox.Text = compra.OBSERVACIONES;
        }

        DataView vDetalles;
       /* private void buscarLocal()
        {
            //if (string.IsNullOrEmpty(propiedadBusqueda))
            //{
            //    SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow modelo = new SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETDataTable().NewORDEN_COMPRA_DETRow();
            //    propiedadBusqueda = Helpers.Reflect.GetMember(() => modelo.ARTICULO_ID).Name;
            //}
            ////vDetalles.RowFilter = propiedadBusqueda + " like '%" + this.buscarTextBoxX.Text.ToUpper() + "%'";
            //try
            //{
            //    ((DataTable)this.superGridControl1.PrimaryGrid.DataSource).Select(propiedadBusqueda + " like '%" + this.buscarTextBoxX.Text + "%'");
            //}
            //catch
            //{
            //}

            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable table = this.superGridControl1.PrimaryGrid.DataSource as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable;


            var encontrado = from e in table where (e.ARTICULO_ID == this.buscarTextBoxX.Text) || (e.NOMBRE.Contains(buscarTextBoxX.Text)) select e;


            if (encontrado.Count() > 0)
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow modelo = encontrado.First();


                var res =MessageBox.Show("¿Ya existe el medicamento en la lista de recepción, ¿desea agregar otro registro?", "Guardar", MessageBoxButtons.YesNo);

                if (res == DialogResult.Yes)
                {
                    SIFModelo.Articulo articulo = new SIFModelo.Articulo();
                    articulo.ARTICULO_ID = buscarTextBoxX.Text;

                    articulo = new SIFNegocio.Articulo().BuscarPorClave(articulo.ARTICULO_ID);

                    if (articulo == null)
                    {
                        return;
                    }
                    this.AgregaArticulo(articulo);
                }
                //scroll into view
                //this.superGridControl1.PrimaryGrid.SetActiveRow( = modelo;
                return;

            }
            else
            {

                SIFModelo.Articulo articulo = new SIFModelo.Articulo();
                articulo.ARTICULO_ID = buscarTextBoxX.Text;

                articulo = new SIFNegocio.Articulo().BuscarPorClave(articulo.ARTICULO_ID);

                if (articulo == null)
                {
                    return;
                }

                var res =MessageBox.Show("El artículo no se encontró en la lista de recepción, ¿desea agregarlo?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    return;
                }

                this.AgregaArticulo(articulo);
            }

        }*/

        private void Recibir()
        {
            //validar que llene las piezas correspondientes

            Boolean errorCero = false;
            //foreach (SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow row in )
            foreach (DataRow row in detalles)
            {
                if (System.Convert.ToInt32(row["CANT_RECIBIDA"]) == 0)
                //if(row.CANT_RECIBIDA == 0)
                {

                    errorCero = true;
                }

                var vs = from s in detalles where s.ARTICULO_ID == row["ARTICULO_ID"].ToString() select s;

                // SIFModelo.OrdenCompra.OrdenesCompraDataSet.COMPRAS_DETRow dRow = vs.FirstOrDefault();

                //if (dRow != null)
                //{
                //    dRow.CANT_RECIBIDA = System.Convert.ToInt32(row["CANT_RECIBIDA"]);
                //    dRow.CANT_FACTURADA = System.Convert.ToInt32(row["CANT_FACTURADA"]);
                //}
            }

            if (errorCero)
            {
                DialogResult dlg =MessageBox.Show("Hay artículos sin recibir, ¿Seguir con la recepción?", "Recibir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dlg == DialogResult.No)
                {


                    return;
                }
            }

            this.OrdenCompra.ESTADO_OC = "E";
            OrdenCompra.FECHA_AUTORIZA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            if (OrdenCompra.IsFECHA_CIERRENull())
                OrdenCompra.FECHA_CIERRE = new DateTime();
            if (OrdenCompra.IsFECHA_RECEPCIONNull())
                OrdenCompra.FECHA_RECEPCION = new DateTime();

            this.ordenCompraL.ActualizaOrdenCompra(OrdenCompra);
            this.RecibirOrdenCompra();
            this.Back();
        }

        private void CalculaTotal()
        {

            var v_cantidadSolicitada = detalles.Compute("SUM(cant_solicitada)", "");
            var v_cantidadFactura = detalles.Compute("SUM(cant_facturada)", "");
            var v_cantidadRecibida = detalles.Compute("SUM(cant_recibida)", "");

            if (v_cantidadSolicitada.ToString().IsInteger())
            {
                this.pedidoLabel.Text = v_cantidadSolicitada.ToString();
            }

            if (v_cantidadFactura.ToString().IsInteger())
            {
                this.facturadoLabel.Text = v_cantidadFactura.ToString();
            }

            if (v_cantidadRecibida.ToString().IsInteger())
            {
                this.recibidoLabel.Text = v_cantidadRecibida.ToString();
            }

           
            
          
           

        }

        private void RecibirOrdenCompra()
        {
            int i = 0;
            foreach (GridRow roww in superGridControl1.PrimaryGrid.Rows)
            {

                if (Convert.ToInt64(roww.Cells["CANT_AREPONERColumn"].Value) > 0)
                {
                    i++;
                }
                

            }
            if (i == 0)
            {
                MessageBox.Show("No Existe Prodcuto a devolver");
                return;
            }
            SIFModelo.ReposisionProveedor devProv = new SIFModelo.ReposisionProveedor();
            List<SIFModelo.ReposisionProveedorDetalle> devProvDet = new List<SIFModelo.ReposisionProveedorDetalle>();
           /* compra.RECEPCIONISTA = this.recibeComboBoxEx.Text;*/
            //compra.OBSERVACIONES = observacionesGeneralesTextBox.Text;
           // SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable table = this.superGridControl1.PrimaryGrid.DataSource as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable;
            //double dev = 0, totalDev = 0, totalRec = 0, rec = 0;

            if (string.IsNullOrEmpty( this.observacionesGeneralesTextBox.Text ))
                devProv.Comentario = " ";
            else
                devProv.Comentario = this.observacionesGeneralesTextBox.Text;
            devProv.RDM = compra.FOLIO_COMPRA;
            devProv.UsuarioID = userDEv.UsuariosID;
            devProv.SucursalID = Helpers.Sesion.Sucursal.SucursalID;
            devProv.ProveedorID = compra.PROVEEDOR_ID;
            devProv.Impuesto = ivaa;
           // decimal total = 0;
            SIFModelo.Inventarios.ListaPrecios precioarticulo;
            SIFModelo.Articulo articuloArt;
           // devProv.UsuarioID=
            foreach (GridRow roww in superGridControl1.PrimaryGrid.Rows)
            {
                SIFModelo.ReposisionProveedorDetalle devdetalle = new SIFModelo.ReposisionProveedorDetalle();
                precioarticulo = new SIFModelo.Inventarios.ListaPrecios();
                 articuloArt = new SIFModelo.Articulo();
                 if (Convert.ToInt64(roww.Cells["CANT_AREPONERColumn"].Value) > 0)
                {
                   // total += (Convert.ToInt64(roww.Cells["CANT_DEVOLVERColumn"].Value)) * (Convert.ToDecimal(roww.Cells["COSTO_NETOColumn"].Value));
                    devdetalle.ArticuloID = roww.Cells["ARTICULO_IDColumn"].Value.ToString();
                    devdetalle.Cantidad = Convert.ToInt64(roww.Cells["CANT_AREPONERColumn"].Value);
                   // string comenrow = roww.Cells["OBSERVACIONESColumn"].Value.ToString();
                    if (roww.Cells["OBSERVACIONESColumn"].Value==null)
                    devdetalle.Comentario = " ";
                    else
                        devdetalle.Comentario = roww.Cells["OBSERVACIONESColumn"].Value.ToString();
                    devdetalle.Costo = Convert.ToDecimal(roww.Cells["COSTO_NETOColumn"].Value);
                    devdetalle.SucursalID = Helpers.Sesion.Sucursal.SucursalID;
                    devdetalle.IVA = precioarticulo.IMP_VENTA;
                    precioarticulo = articulo.ArticuloPrecio(devdetalle.ArticuloID);
                    articuloArt = articulo.BuscarPorClave(devdetalle.ArticuloID);
                    devdetalle.Precio = precioarticulo.PRECIO_VENTA;
                    devdetalle.Nombre1 = articuloArt.NOMBRE1;
                    devProvDet.Add(devdetalle);
                }


            }
            devProv.Total = totalDev;
            SIFNegocio.Inventario.Bonificaciones guardarDevPRov = new SIFNegocio.Inventario.Bonificaciones();

            //guardarDevPRov.AplicaDevolucionProveedor(devProv, devProvDet);

            if (guardarDevPRov.AplicaReposicionProveedor(devProv, devProvDet) > 0)
            {
               // MessageBox.Show("Se ha generado la dev a prov " + compra.FOLIO_COMPRA);
                this.Back();
            }


        }

        /*private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.buscarLocal();
        }*/

        public object Owner { get; set; }

        internal void Muestra()
        {
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;

            if (Owner is View.OrdenCompra.RecepcionOrdenCompraUserControl)
            {
                View.OrdenCompra.RecepcionOrdenCompraUserControl propietario = Owner as View.OrdenCompra.RecepcionOrdenCompraUserControl;
                propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
            }

            if (Owner is View.OrdenCompra.OrdenesCompraUserControl)
            {
                View.OrdenCompra.OrdenesCompraUserControl propietario = Owner as View.OrdenCompra.OrdenesCompraUserControl;
                View.Menu.ComprasMenu propietarioOwner = propietario.Owner as View.Menu.ComprasMenu;
                propietarioOwner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                propietario.DesactivaComandos();
            }
        }

        private void Back()
        {
            try
            {
                if (Owner is View.OrdenCompra.RecepcionOrdenCompraUserControl)
                {
                    View.OrdenCompra.RecepcionOrdenCompraUserControl propietario = Owner as View.OrdenCompra.RecepcionOrdenCompraUserControl;
                    if (propietario.Owner.Owner.Contains(this))
                    {
                        propietario.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    propietario.ActivaComandos();
                    this.Mostrado = false;
                    this.DesactivaComandos();
                }

                if (Owner is View.OrdenCompra.OrdenesCompraUserControl)
                {
                    View.OrdenCompra.OrdenesCompraUserControl propietario = Owner as View.OrdenCompra.OrdenesCompraUserControl;
                    View.Menu.ComprasMenu propietarioOwner = propietario.Owner as View.Menu.ComprasMenu;
                    if (propietarioOwner.Owner.Contains(this))
                    {
                        propietarioOwner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    propietario.ActivaComandos();
                    this.Mostrado = false;
                    this.DesactivaComandos();
                }
            }
            catch { }
        }

        public void ActivaComandos()
        {
            this.backButton.Shortcuts.Add(eShortcut.F12);
            this.agregaProductoButtonItem.Shortcuts.Add(eShortcut.F4);
            this.recibirButtonItem.Shortcuts.Add(eShortcut.F5);
            // this.recibirYAfectarButtonItem.Shortcuts.Add(eShortcut.);
        }
        public void DesactivaComandos()
        {
            this.backButton.Shortcuts.Clear();
            this.agregaProductoButtonItem.Shortcuts.Clear();
            this.recibirButtonItem.Shortcuts.Clear();
            this.recibirYAfectarButtonItem.Shortcuts.Clear();
        }

        public bool Mostrado { get; set; }

        public int UsuarioId { get; set; }

        private void recibirButtonItem_Click(object sender, EventArgs e)
        {
            this.RecibirOrdenCompra();
        }

        private void inicializaColoresFilas()
        {
            revisarRowStyle.Background.Color1 = Color.FromArgb(255, 35, 35);
            revisarRowStyle.Background.Color2 = Color.FromArgb(255, 35, 35);

            WarningCellStyle.Background.Color1 = Color.FromArgb(253, 215, 0);
            WarningCellStyle.Background.Color2 = Color.FromArgb(253, 215, 0);

            normalRowStyle = this.superGridControl1.DefaultVisualStyles.CellStyles.Default;
        }

       /* private void buscarTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.buscarLocal();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
                this.buscarLocal();
            }
        }*/

        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle revisarRowStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle normalRowStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle WarningCellStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;

        private void superGridControl1_EndEdit(object sender, DevComponents.DotNetBar.SuperGrid.GridEditEventArgs e)
        {
            if (superGridControl1.EditorColumn == superGridControl1.PrimaryGrid.Columns["OBSERVACIONESColumn"])
            {
                return;
            }

            if (superGridControl1.EditorColumn != superGridControl1.PrimaryGrid.Columns["CADUCIDADColumn"] && superGridControl1.EditorColumn != superGridControl1.PrimaryGrid.Columns["LOTEColumn"])
            {
                if (!e.EditControl.EditorFormattedValue.ToString().IsIntegerPositive())
                {
                    e.EditControl.EndEdit();
                    MessageBox.Show("El formato de número no es válido");
                    e.Cancel = true;
                    return;
                }
            }
            // int nuevoValor = int.Parse(e.EditControl.EditorFormattedValue.ToString());
            double cantDEv = Convert.ToInt64(e.GridCell.GridRow.Cells["CANT_AREPONERColumn"].Value);
            double cantYaDev = Convert.ToInt64(e.GridCell.GridRow.Cells["CANT_REPOSICIONColumn"].Value);
            double cat_recibida = Convert.ToInt64(e.GridCell.GridRow.Cells["CANTIDAD_RECIBIDAColumn"].Value);
            double iva = Convert.ToInt64(e.GridCell.GridRow.Cells["PORC_IVAColumn"].Value) ;
            double cantFact = Convert.ToInt64(e.GridCell.GridRow.Cells["CANTIDAD_FACTURADAColumn"].Value);
            double cantDisDEv = cantFact-(cat_recibida + cantYaDev);

            if (cantDEv > cantDisDEv)
            {
               
                MessageBox.Show("La cantidad a REPONER es mayor a la disponible para reposicion. " + Environment.NewLine + "Cantidad disponible para Reposicion: " + (cantDisDEv).ToString(), "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.EditControl.EndEdit();
                e.GridCell.GridRow.Cells["CANT_AREPONERColumn"].Value = 0;
            }

            SuperGridControl grid = sender as SuperGridControl;
            /*SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row = (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow)((DataRowView)(e.GridCell.GridRow.DataItem)).Row;
            if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_FACTURADA).Name)
            {
                //row.CANT_FACTURADA = nuevoValor;
                if (row.CANT_FACTURADA > row.CANT_SOLICITADA)
                {
                    e.EditControl.EndEdit();
                    MessageBox.Show("La cantidad de la factura es mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (superGridControl1.EditorColumn != superGridControl1.PrimaryGrid.Columns["DEVOLUCION"] )
            {
                if (cantDEv > row.CANT_RECIBIDA)
                {
                    MessageBox.Show("La cantidad ha devolver es mayor a la recibida", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.EditControl.EndEdit();
                }

            }
          

            if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_RECIBIDA).Name)
            {
                // row.CANT_RECIBIDA = nuevoValor;
                if (row.CANT_RECIBIDA > row.CANT_SOLICITADA)
                {
                    e.EditControl.EndEdit();
                    MessageBox.Show("La cantidad recibida es mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (row.CANT_RECIBIDA == row.CANT_SOLICITADA)
                {
                    //e.GridCell.GridRow.CellStyles.Default = normalRowStyle;
                    //e.GridCell.GridRow.RowStyles.Default.ApplyStyle(normalRowStyle);
                }
            }

              */
                
               // Double.TryParse(superGridControl1.PrimaryGrid.SuperGrid.Value.ToString(), out d);
               // superGridControl1.PrimaryGrid.GridPanel.Rows[i].
                //sum += d;
            


           /* if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_DEV_FALTANTE).Name)
            {
                // row.CANT_RECIBIDA = nuevoValor;
                if (row.CANT_DEV_FALTANTE > row.CANT_SOLICITADA)
                {
                    e.EditControl.EndEdit();
                    MessageBox.Show("La cantidad faltante no puede ser mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }*/

            dev = 0;
            totalDev = 0;
            totalRec = 0;
            rec = 0;
            ivaa = 0;
            piva = 0;
            montoIva = 0;
            foreach (GridRow roww in superGridControl1.PrimaryGrid.Rows)
            {
                piva=Convert.ToInt64(roww.Cells["PORC_IVAColumn"].Value);
                if (Convert.ToInt64(roww.Cells["PORC_IVAColumn"].Value) > 0 && Convert.ToInt64(roww.Cells["CANT_AREPONERColumn"].Value) > 0)
                {
                    dev = Convert.ToInt64(roww.Cells["CANT_AREPONERColumn"].Value);
                    montoIva = ((Convert.ToDecimal(roww.Cells["COSTO_NETOColumn"].Value))) * ((piva/ 100) + 1);
                    ivaa += (montoIva / ((piva / 100) + 1)) * (piva / 100);
                }

                if (Convert.ToInt64(roww.Cells["CANT_AREPONERColumn"].Value) > 0)
                {
                    dev = Convert.ToInt64(roww.Cells["CANT_AREPONERColumn"].Value);
                    totalDev += (dev * (Convert.ToDecimal(roww.Cells["COSTO_NETOColumn"].Value))) * ((Convert.ToDecimal(e.GridCell.GridRow.Cells["PORC_IVAColumn"].Value) / 100) + 1);
                    
                }

                if (Convert.ToInt64(roww.Cells["CANTIDAD_RECIBIDAColumn"].Value) > 0)
                {
                    rec = Convert.ToInt64(roww.Cells["CANTIDAD_RECIBIDAColumn"].Value);
                    totalRec += (rec * (Convert.ToDecimal(roww.Cells["COSTO_NETOColumn"].Value))) * ((Convert.ToDecimal(e.GridCell.GridRow.Cells["PORC_IVAColumn"].Value) / 100) + 1);
                }

            }
            this.totalDevLabel.Text = totalDev.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.totalRecepLabel.Text = totalRec.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.almacenLabel.Text = ivaa.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

            //if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_MALESTADO).Name || grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_DEV_FALTANTE).Name || grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_PROX_CADUCAR).Name || grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_DEV_NO_PEDIDO).Name || grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_DEV_PRECIO_ELEVADO ).Name)
            //{
            //    if (( row.CANT_MALESTADO + row.CANT_DEV_FALTANTE + row.CANT_PROX_CADUCAR +  row.CANT_DEV_NO_PEDIDO +  row.CANT_DEV_PRECIO_ELEVADO) > row.CANT_RECIBIDA)
            //    {
            //        e.EditControl.EndEdit();
            //        MessageBox.Show("La cantidad a devolver es mayor a la recibida", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}

            //if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_PROX_CADUCAR).Name)
            //{
            //    if (row.CANT_PROX_CADUCAR > row.CANT_SOLICITADA)
            //    {
            //        e.EditControl.EndEdit();
            //        MessageBox.Show("La cantidad devuelta es mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}

            //if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_REPOSICION).Name)
            //{
            //    if (row.CANT_REPOSICION > row.CANT_SOLICITADA)
            //    {
            //        e.EditControl.EndEdit();
            //        MessageBox.Show("La cantidad repuesta es mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}

            //if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_REPOSICION).Name)
            //{
            //    if (row.CANT_REPOSICION > row.CANT_SOLICITADA)
            //    {
            //        MessageBox.Show("La cantidad repuesta es mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    }
            //}

            //calcula totales
            /*int cantRecibida = row.CANT_FACTURADA;

            if (cantRecibida == 0 && row.FacturaProveedorDetalle == null)
            {
                cantRecibida = row.CANT_FACTURADA;
            }

            row.CANT_RECIBIDA = cantRecibida - row.CANT_DEV_FALTANTE - row.CANT_DEV_NO_PEDIDO - row.CANT_DEV_PRECIO_ELEVADO - row.CANT_MALESTADO - row.CANT_PROX_CADUCAR;
            e.GridCell.GridRow.Cells["CANTIDAD_RECIBIDAColumn"].Value = row.CANT_RECIBIDA;*/
            //

            this.CalculaTotal();
        }



        private string propiedadBusqueda;
        private void superGridControl1_ColumnHeaderClick(object sender, GridColumnHeaderClickEventArgs e)
        {

            /*this.buscarTextBoxX.WatermarkText = "BUSCAR POR " + e.GridColumn.HeaderText;*/
           /* this.propiedadBusqueda = e.GridColumn.DataPropertyName;*/
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void RecepcionOrdenCompraDetallesUserControl_Load(object sender, EventArgs e)
        {
            /*this.buscarTextBoxX.Focus();*/
            this.superGridControl1.PrimaryGrid.SelectionGranularity = SelectionGranularity.Cell;
        }

        private void superGridControl1_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {

        }

        private void recibirYAfectarButtonItem_Click(object sender, EventArgs e)
        {
            this.Recibir();
        }

        private void superGridControl1_PostRenderRow(object sender, GridPostRenderRowEventArgs e)
        {
            //return;
           /* SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row = (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow)((DataRowView)((GridRow)(e.GridRow)).DataItem).Row;
            SIFModelo.OrdenCompra.DevProveedor row2 = e.GridRow.Rows[e.GridRow.RowIndex];// (SIFModelo.OrdenCompra.DevProveedor)((GridRow)(e.GridRow));

            if (row.CANT_RECIBIDA == 0)
            {
                e.GridRow.CellStyles.Default = WarningCellStyle;
                e.GridRow.RowStyles.Default.ApplyStyle(WarningCellStyle);
            }
            else if (row.CANT_FACTURADA > row.CANT_SOLICITADA)
            {
                e.GridRow.CellStyles.Default = revisarRowStyle;
                e.GridRow.RowStyles.Default.ApplyStyle(revisarRowStyle);
            }
            else if (row.CANT_RECIBIDA > row.CANT_SOLICITADA)
            {
                e.GridRow.CellStyles.Default = revisarRowStyle;
                e.GridRow.RowStyles.Default.ApplyStyle(revisarRowStyle);
            }
            else
            {
                e.GridRow.CellStyles.Default = normalRowStyle;
                e.GridRow.RowStyles.Default.ApplyStyle(normalRowStyle);
            }*/


            //else if (row.CANT_MALESTADO > row.CANT_SOLICITADA)
            //{
            //    e.GridRow.CellStyles.Default = revisarRowStyle;
            //    e.GridRow.RowStyles.Default.ApplyStyle(revisarRowStyle);
            //}
            //else if (row.CANT_DEVUELTA > row.CANT_SOLICITADA)
            //{
            //    e.GridRow.CellStyles.Default = revisarRowStyle;
            //    e.GridRow.RowStyles.Default.ApplyStyle(revisarRowStyle);
            //}
            //else if (row.CANT_REPOSICION > row.CANT_SOLICITADA)
            //{
            //    e.GridRow.CellStyles.Default = revisarRowStyle;
            //    e.GridRow.RowStyles.Default.ApplyStyle(revisarRowStyle);
            //}
            //else
            //{
            //    e.GridRow.CellStyles.Default = normalRowStyle;
            //    e.GridRow.RowStyles.Default.ApplyStyle(normalRowStyle);
            //}
        }

        private void superGridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            //GridRow row = this.superGridControl1.ActiveRow as GridRow;

            //if (row == null)
            //{
            //    return;
            //}

            //if (e.KeyCode == Keys.Down)
            //{

            //    int columna = superGridControl1.ActiveCell.ColumnIndex;
            //    if (row.RowIndex < superGridControl1.PrimaryGrid.LastSelectableRow.RowIndex)
            //    { row.GetCell(columna).BeginEdit(true); }

            //    //GridCell celda = this.superGridControl1.;
            //    //celda = superGridControl1.cell 
            //    //var s = superGridControl1.PrimaryGrid.SetActiveCell( superGridControl1.PrimaryGrid.ActiveRow.rowi;
            //    // //superGridControl1.PrimaryGrid.SetActiveCell();
            //    // //this.superGridControl1.PrimaryGrid.SetActiveCell(celda);
            //    // celda.BeginEdit(true);
            //}
            //if (e.KeyCode == Keys.Right)
            //{
            //    int columna = superGridControl1.ActiveCell.ColumnIndex;
            //    if (columna <= superGridControl1.PrimaryGrid.Columns.Count - 1)
            //    {
            //        columna++;
            //        try
            //        {
            //            row.GetCell(columna).BeginEdit(true);
            //        }
            //        catch
            //        {
            //            superGridControl1.CancelCapture();
            //        }
            //    }
            //}
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

        private void agregaProductoButtonItem_Click(object sender, EventArgs e)
        {
            this.AgregaArticulo();
        }

        private void superGridControl1_SelectionChanged(object sender, GridEventArgs e)
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow != null)
            {
                var detalle = ((((GridRow)this.superGridControl1.PrimaryGrid.ActiveRow).DataItem as SIFModelo.OrdenCompra.DevProveedor )) as SIFModelo.OrdenCompra.DevProveedor ;// SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow;



                try
                {
                   /* CultureInfo provider = CultureInfo.InvariantCulture;
                    var date = DateTime.ParseExact(detalle.ARTICULO_ID, "yyyyMMddHHmmss", provider);

                    if (date.ToString().IsDatetime())
                    {
                        this.actualizaArticuloButtonItem.Enabled = true;
                    }
                    else
                    {
                        this.actualizaArticuloButtonItem.Enabled = false;
                    }*/
                }
                catch
                {
                    /*this.actualizaArticuloButtonItem.Enabled = false;*/
                }
            }
        }

        private void actualizaArticuloButtonItem_Click(object sender, EventArgs e)
        {
            View.Articulos.ArticuloUserControl frmArticulos = new View.Articulos.ArticuloUserControl();
            frmArticulos.Owner = this;
            frmArticulos.Funcion = "Actualiza";
            frmArticulos.Muestra();
        }

        public void actualizaArticulo(SIFModelo.Articulo articulo)
        {
            Catalogos.ClaveArticuloForm frmArticulo = new Catalogos.ClaveArticuloForm();

            var detalle = ((((GridRow)this.superGridControl1.PrimaryGrid.ActiveRow).DataItem as DataRowView).Row) as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow;

            String codigoAnterior = detalle.ARTICULO_ID;

            detalle.ARTICULO_ID = articulo.ARTICULO_ID;
            detalle.NOMBRE = articulo.NOMBRE1;
            ordenCompraL.ActualizaCodigo(detalle, codigoAnterior);

            //si existe orden de compra tambien actualizar
            //if (compra == null)
            //{
            SIFNegocio.OrdenCompra.Compras.ActualizaCodigo(detalle.ARTICULO_ID, articulo.NOMBRE1, codigoAnterior);

            detalle.ARTICULO_ID = articulo.ARTICULO_ID;

            this.superGridControl1.PrimaryGrid.DataSource = detalles;
            //}
        }

        private void nuevoButtonItem_Click(object sender, EventArgs e)
        {
            SIFModelo.Articulo Articulo = new SIFModelo.Articulo();
            Articulo.ARTICULO_ID = DateTime.Now.ToString("yyyyMMddHHmmss");
            Articulo.TIPO_MEDICAMENTO_CVE = "";
            Articulo.ACTIVO = SIFModelo.Tipos.SiNo.SI;


            Articulo.LABORATORIO_ID = OrdenCompra.PROVEEDOR_ID;


            //View.Catalogos.ArticuloEditarForm frmEditar = new Catalogos.ArticuloEditarForm(Articulo);
            //if (frmEditar.ShowDialog() == DialogResult.OK)
            //{
            //    SIFModelo.Articulo articuloExistente = new SIFNegocio.Articulo().BuscarPorClave(Articulo.ARTICULO_ID);

            //    this.AgregaArticulo(articuloExistente);
            //    this.CodigoTextBoxX.Text = articuloExistente.ARTICULO_ID;
            //}

            NuevoArticuloCompraForm frmArticulo = new NuevoArticuloCompraForm();
            if (frmArticulo.ShowDialog() == DialogResult.OK)
            {
                Articulo.NOMBRE1 = frmArticulo.nombreTextBoxX.Text;


                Articulo.PROVEEDOR_ID = OrdenCompra.PROVEEDOR_ID;

                //this.AgregaArticulo(Articulo);.

                SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow det = detalles.NewCOMPRAS_DETRow();
                det.ARTICULO_ID = Articulo.ARTICULO_ID;
                det.PROVEEDOR_ID = Articulo.PROVEEDOR_ID;
                det.NOMBRE = Articulo.NOMBRE1;
                //if (!ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Contains("NOMBRE1"))
                //{ ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Add("NOMBRE1"); }
               // det["NOMBRE1"] = Articulo.NOMBRE1;
               // ocdRow.OC_SEGMENTA = 0;
                det.PRECIO_FARMACIA = double.Parse(frmArticulo.costoTextBoxX.Text);
                det.FOLIO_OC = compra.FOLIO_OC;

                if (frmArticulo.cantidadTextBoxX.Text.IsInteger())
                {
                    det.CANT_SOLICITADA = System.Convert.ToInt32(frmArticulo.cantidadTextBoxX.Text);
                }
                else
                {
                    det.CANT_SOLICITADA = 1;
                }

                det.CANT_PROX_CADUCAR = 0;
                det.CANT_RECIBIDA = det.CANT_SOLICITADA;
                //det.CANT_FACTURADA = ocd.CANT_FACTURADA;
                det.CANT_FACTURA = det.CANT_SOLICITADA;
                det.CANT_FACTURADA = det.CANT_SOLICITADA;
                det.CANT_MALESTADO = 0;
                det.CANT_RECIBIDA = 0;
                det.CANT_REPOSICION = 0;
                det.CANT_SOLICITADA = 0;
                det.CANT_RECIBIDA = det.CANT_FACTURA;
                //det.CODIGO_PROVEEDOR = ocd.CODIGO_PROVEEDOR;
                det.COSTO = System.Convert.ToDouble(frmArticulo.costoTextBoxX.Text);
                det.COSTO_NETO_UNIT_REC = 0;

                    det.COSTO_ULT_COMPRA = 0;


                det.DESCUENTO_GENERAL = 0;
                det.DIF_DESCTO_IVA = 0;
                //det.FacturaProveedorDetalle = 
                //det.FLAG_MAL_OFERTADO = ocd.
                det.FOLIO_COMPRA = compra.FOLIO_COMPRA;
                det.FOLIO_OC = compra.FOLIO_OC;
                det.IMP_CAL1_OFERTA_CONIVA = 0;
                det.IMP_CAL1_OFERTA_SINIVA = 0;
                det.IMP_DESCTO_CONIVA = 0;
                det.IMP_DESCTO_CONIVA_MENOSIVA = 0;
                det.IMP_DESCTO_SINIVA = 0;
                det.IMP_FACTURA_CONIVA = 0;
                det.IMP_FACTURA_SINIVA = 0;
                det.IMP_OFERTA_CONIVA = 0;
                det.IMP_OFERTA_SINIVA = 0;
                det.IMP_RECEPCION_CONIVA = 0;
                det.IMP_RECEPCION_SINIVA = 0;
                det.IMPORTE_IVA = 0;
                det.IMPORTE_NETO = 0;
                det.IVA_MAL_OFERTADO = 0;
                det.LOTE = "";
                det.MAL_OFERTADO = 0;
                det.MARGEN_UTILIDAD = 0;
                det.NOMBRE = frmArticulo.nombreTextBoxX.Text;
                det.NUEVO_FLEMING = 0;
                det.PORC_DESCTO = 0; // (float)ocd.DESCTO_RECIBIDO_AD1;
                det.PORC_DESCTO_AD1 = 0; //(float)ocd.DESCTO_RECIBIDO_AD1;
                det.PORC_DESCTO_AD2 = 0; //(float)ocd.DESCTO_RECIBIDO_AD2;
                det.PORC_DESCTO_AD3 = 0; //(float)ocd.DESCTO_RECIBIDO_AD3;
                det.PORC_DESCTO_AD4 = 0; //(float)ocd.DESCTO_RECIBIDO_AD4;
                det.PORC_IVA = 0;
                det.PORC_OFERTA = 0;
                det.PRECIO_FACTURA = 0;
                det.PRECIO_FACTURA_MAX = 0;
                det.PRECIO_FARM_REC = 0;
                det.PRECIO_FARMACIA = 0;
                det.PRECIO_FLEMING = 0;
                det.PRECIO_MAXIMO = 0;
                det.PRECIO_VENTA = 0;
                det.PROVEEDOR_ID = compra.PROVEEDOR_ID;
                det.RES_CAL1_DESCTO = 0;
                det.RES_CAL2_OFERTA = 0;
                det.RES_CAL3_DESCTOAD1 = 0;
                det.RES_CAL4_DESCTOAD2 = 0;
                det.RES_CAL5_DESCTOAD3 = 0;
                det.RES_CAL6_DESCTOAD4 = 0;
                det.SIN_OFERTA = 0;
                det.TOTAL_DESCTO_FACTURA = 0;
                det.TOTAL_OFERTA_FACTURA = 0;

                detalles.AddCOMPRAS_DETRow(det);

            }

        }
    }
}
