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

namespace SIF.View.OrdenCompra
{
    public partial class FacturaDetallesUserControl : Templates.ListaUserControl
    {
        public FacturaDetallesUserControl()
        {
            InitializeComponent();
            this.inicializaColumnas();
            this.InicializaEstilosFilas();
            //this.fechaLabel.Text = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToShortDateString();
        }

        private const decimal PorcIVA = 16;

        public FacturaDetallesUserControl(SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow factura, SIFModelo.Usuario usuario, bool esDividir = false)
        {
            InitializeComponent();
            this.usuarioLabel.Text = usuario.Nombre + " " + usuario.Apellidos;
            this.usuario = usuario;
            this.folioLabel.Text = OrdenCompraFolio;
            proveedorLabel.Text = "";
            this.factura = factura;
            this.cargaFacturaDetalle();
            this.esDividir = esDividir;

            this.inicializaColumnas();


            //this.InicializaEstilosFilas();
        }

        private bool esDividir = false;

        private void cargaAlmacenes()
        {

        }

        private void cargaFacturaDetalle()
        {

            this.ocl.dsOrdenesCompraDT = ocl.DetallesFacturaProveedor(factura);

            this.superGridControl1.PrimaryGrid.DataSource = this.ocl.dsOrdenesCompraDT.FACTURA_PROVEEDOR_DET;
            //this.superGridControl1.PrimaryGrid.DataMember = this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.TableName;
            this.calculaTotal();

            //ASIGNAMOS EL PROVEEDOR
            SIFModelo.Cliente proveedor = new SIFNegocio.Clientes().ClientePorID(factura.PROVEEDOR_ID);
            proveedorLabel.Text = proveedor.Nombre + " " + proveedor.ApellidoPaterno + " " + proveedor.ApellidoMaterno;
            this.statusOClabel.Text = factura.ESTADO;
            //this.fechaLabel.Text = factura.FECHA_ALTA.ToShortDateString();
            //if (factura.IsOBSERVACION_OCNull())
            //{
            //    factura.OBSERVACION_OC = "";
            //}
            //this.observacionesTextBoxX.Text = factura.OBSERVACION_OC;
        }

        View.Catalogos.ArticuloUserControl frmArticulos = new View.Catalogos.ArticuloUserControl();

        private void AgregaArticulo()
        {
            View.Articulos.ArticuloUserControl frmArticulos = new View.Articulos.ArticuloUserControl();
            frmArticulos.Owner = this;
            frmArticulos.Muestra();
        }

        private void AgregaArticulo(string articuloClave)
        {
            if (string.IsNullOrEmpty(articuloClave))
            {
                return;
            }

            SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(articuloClave);

            if (articulo == null)
            {
               MessageBox.Show("El artículo no se ha encontrado en el catálogo");
                return;
            }

            this.AgregaArticulo(articulo);
        }

        private void agregaArticuloButtonItem_Click(object sender, EventArgs e)
        {
            this.AgregaArticulo();
        }

        private void inicializaColumnas()
        {
            //DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl CANT_SOLICITADAColumn = this.superGridControl1.PrimaryGrid.Columns["CANT_SOLICITADAColumn"].EditControl as DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl;
            //CANT_SOLICITADAColumn.MinValue = 1;

            //DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl PRECIO_COSTOColumn = this.superGridControl1.PrimaryGrid.Columns["PRECIO_COSTOColumn"].EditControl as DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl;
            //try
            //{
            //    PRECIO_COSTOColumn.MinValue = 0.01;
            //}
            //catch
            //{
            //}

            //DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl DESCRIP_OFERTAColumn = this.superGridControl1.PrimaryGrid.Columns["DESCRIP_OFERTAColumn"].EditControl as DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl;
            //DESCRIP_OFERTAColumn.MaxLength = 30;

            //DevComponents.DotNetBar.SuperGrid.GridTextBoxDropDownEditControl OFERTASColumn = this.superGridControl1.PrimaryGrid.Columns["OFERTASColumn"].EditControl as DevComponents.DotNetBar.SuperGrid.GridTextBoxDropDownEditControl;
            //OFERTASColumn.ButtonCustom.Visible = true;
            ////OFERTASColumn.ButtonCustom.Text = "0";
            //OFERTASColumn.ButtonCustomClick += OFERTASColumn_ButtonCustom_CLICK;

            //DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl PROVEEDOR_IDColumn = this.superGridControl1.PrimaryGrid.Columns["PROVEEDOR_IDColumn"].EditControl as DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl;
            //PROVEEDOR_IDColumn.ButtonCustom.Visible = true;
            //PROVEEDOR_IDColumn.ButtonCustomClick += PROVEEDOR_IDColumn_ButtonCustom_CLICK;
        }

        void PROVEEDOR_IDColumn_ButtonCustom_CLICK(object sender, EventArgs e)
        {
            GridTextBoxXEditControl ddc =
                sender as GridTextBoxXEditControl;

            if (ddc != null)
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow row = ((DataRowView)((GridRow)superGridControl1.PrimaryGrid.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow;
                new SIFNegocio.Usuarios().ListaProveedores(usuario);

                ClienteCompraForm frmCliente = new ClienteCompraForm(row, usuario);
                if (frmCliente.ShowDialog() == DialogResult.OK)
                {
                    if (frmCliente.cliente == 0)
                    {
                       MessageBox.Show("Debe elegir un proveedor de la orden de compra");
                        return;
                    }

                    if (row.PROVEEDOR_ID == frmCliente.cliente)
                    {
                        return;
                    }

                    //limpiamos la oferta si hay y asignamos el nuevo proveedor
                    SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(row.ARTICULO_ID);
                    SIFNegocio.Inventario.Inventario InventarioL = new SIFNegocio.Inventario.Inventario();
                    var inventario = InventarioL.InventarioArticulo(articulo);

                    if (inventario == null)
                    {
                        inventario = new SIFModelo.Inventarios.InventarioDataSet.INVENTARIODataTable().NewINVENTARIORow();
                    }

                    row.PROVEEDOR_ID = frmCliente.cliente;
                    //row.PROVEEDOR_ID = articulo.PROVEEDOR_ID;
                    row.PRECIO_COSTO = (decimal)inventario.COSTO_PROM;
                    row.IMPORTE = row.PRECIO_COSTO * row.CANT_SOLICITADA;


                }

            }
        }

        void OFERTASColumn_ButtonCustom_CLICK(object sender, EventArgs e)
        {
            GridTextBoxDropDownEditControl ddc =
                sender as GridTextBoxDropDownEditControl;

            if (ddc != null)
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow row = ((DataRowView)((GridRow)superGridControl1.PrimaryGrid.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow;
                OfertasCompraForm frmOfertas = new OfertasCompraForm(row);

                if (frmOfertas.ShowDialog() == DialogResult.OK)
                {
                    SIFModelo.OrdenCompra.OfertasCompra oferta = frmOfertas.Oferta;

                    if (oferta == null)
                    {
                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(row.ARTICULO_ID);
                        SIFNegocio.Inventario.Inventario InventarioL = new SIFNegocio.Inventario.Inventario();
                        var inventario = InventarioL.InventarioArticulo(articulo);

                        if (inventario == null)
                        {
                            inventario = new SIFModelo.Inventarios.InventarioDataSet.INVENTARIODataTable().NewINVENTARIORow();
                        }

                        row.PROVEEDOR_ID = articulo.PROVEEDOR_ID;
                        row.PRECIO_COSTO = (decimal)inventario.COSTO_PROM;
                        row.IMPORTE = row.PRECIO_COSTO * row.CANT_SOLICITADA;

                        return;
                    }


                    //asignamos la oferta a la orden de compra
                    //string[] valores = frmOfertas.Oferta.Split(new char[] { ('|') });
                    row.PROVEEDOR_ID = oferta.ProveedorID;
                    row.PRECIO_COSTO = oferta.PrecioCosto;
                    row.IMPORTE = row.PRECIO_COSTO * row.CANT_SOLICITADA;
                }
            }
        }

        public bool Mostrado = false;
        public OrdenCompra.FacturasUserControl Owner;

        #region Funciones y  Metodos


        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            if (articulo == null)
            {
               MessageBox.Show("Debe elgir un producto para la orden de compra");
                return;
            }

            if (this.ocl.dsOrdenesCompraDT.FACTURA_PROVEEDOR_DET.Select("ARTICULO_ID = '" + articulo.ARTICULO_ID + "'", "").Count() > 0)
            {
                if (MessageBoxEx.Show("El artículo ya esta agregado a la factura, ¿Volver a agregarlo?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }


            SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETRow ocdRow = this.ocl.dsOrdenesCompraDT.FACTURA_PROVEEDOR_DET.NewFACTURA_PROVEEDOR_DETRow();
            ocdRow.ARTICULO_ID = articulo.ARTICULO_ID;
            ocdRow.NUM_FACTURA = "0";
            ocdRow.PARTIDA = (short)(ocl.dsOrdenesCompraDT.FACTURA_PROVEEDOR_DET.Rows.Count + 1);
            ocdRow.PRECIO_VENTA_FAR = 0;
            ocdRow.PORC_DESCTO = 0;
            ocdRow.PORC_OFERTA = 0;
            ocdRow.PZA_CCARGO = 1;
            ocdRow.PZA_SCARGO = 0;
            ocdRow.TIPO_MEDICAMENTO_CVE = articulo.TIPO_MEDICAMENTO_CVE;
            ocdRow.NOMBRE1 = articulo.NOMBRE1;
            //ocdRow.PORC_DESCTO = 0;
            //ocdRow.PORC_OFERTA = 0;
            ocdRow.PRECIO_VENTA_MAX = 0;
            ocdRow.PRECIO_VENTA_FAR = 0;


            ocdRow.IMP_OFERTA_SIVA = 0;
            ocdRow.IMP_OFERTA_CIVA = 0;
            ocdRow.IMP_DESCTO_SIVA = 0;
            ocdRow.IMP_DESCTO_CIVA = 0;
            ocdRow.IMP_IVA = 0;
            ocdRow.IMP_DESCTO_CIVA_MIVA = 0;
            ocdRow.IMP_FACTURA_CIVA = 0;
            ocdRow.IMP_FACTURA_SIVA = 0;
            ocdRow.PORC_OFERTA = 0;
            ocdRow.PORC_DESCTO = 0;
            ocdRow.IMP_CAL_OFERTA_CIVA = 0;
            ocdRow.IMP_CAL_OFERTA_SIVA = 0;
            ocdRow.COSTO_NETO_UNITARIO = 0;
            ocdRow.IMPORTE_NETO = 0;
            ocdRow.DIF_DESCTO_IVA = 0;


            this.ocl.dsOrdenesCompraDT.FACTURA_PROVEEDOR_DET.Rows.Add(ocdRow);
            this.superGridControl1.PrimaryGrid.DataSource = ocl.dsOrdenesCompraDT.FACTURA_PROVEEDOR_DET;

            this.calculaTotal();

            #region anterior
            //SIFNegocio.Inventario.Inventario InventarioL = new SIFNegocio.Inventario.Inventario();
            //var inventario = InventarioL.InventarioArticulo(articulo);

            //if (inventario == null)
            //{

            //    inventario = new SIFModelo.Inventarios.InventarioDataSet.INVENTARIODataTable().NewINVENTARIORow();
            //}

            //ocdRow.ARTICULO_ID = articulo.ARTICULO_ID;
            //ocdRow.CANT_DEVUELTA = 0;
            //ocdRow.CANT_FACTURADA = 0;
            //ocdRow.CANT_MALESTADO = 0;
            //ocdRow.CANT_RECIBIDA = 0;
            //ocdRow.CANT_REPOSICION = 0;
            //ocdRow.PRECIO_COSTO = ocl.PrecioFarmacia(articulo.ARTICULO_ID, articulo.PROVEEDOR_ID, Helpers.Sesion.Sucursal);
            //ocdRow.PRECIO_FARMACIA = ocdRow.PRECIO_COSTO;
            //if (this.cantidadTextBoxX.Text.IsInteger())
            //{
            //    ocdRow.CANT_SOLICITADA = short.Parse(cantidadTextBoxX.Text);
            //}
            //else
            //{
            //    ocdRow.CANT_SOLICITADA = inventario.PUNTO_DE_REORDEN;
            //}

            //ocdRow.DESCRIP_OFERTA = "";
            //ocdRow.DESCTO_FACTURA = 0;
            //ocdRow.DESCTO_FACTURA_AD1 = 0;
            //ocdRow.DESCTO_RECIBIDO = 0;
            //ocdRow.DESCTO_RECIBIDO_AD1 = 0;
            //ocdRow.DESCTO_RECIBIDO_AD2 = 0;
            //ocdRow.EXISTENCIAS = inventario.EXISTENCIAS;
            //ocdRow.FOLIO_OC_ID = this.OrdenCompraFolio;
            //ocdRow.LABORATORIO_ID = articulo.LABORATORIO_ID;
            //ocdRow.NOMBRE = articulo.NOMBRE1;
            //ocdRow.NUM_PARTIDA = ocdRow.Table.Rows.Count + 1;
            //ocdRow.OFERTA_COMPRA_ID = 0;
            //ocdRow.PRECIO_FACTURA = 0;
            //ocdRow.PROVEEDOR_ID = articulo.PROVEEDOR_ID;
            //ocdRow.PUNTO_DE_REORDEN = inventario.PUNTO_DE_REORDEN;
            //ocdRow.TIPO_MEDICAMENTO_CVE = articulo.TIPO_MEDICAMENTO_CVE;
            //ocdRow.ULT_PRECIO_COMPRA = inventario.ULT_COSTO;
            //ocdRow.USUARIO_ID = usuario.UsuariosID;


            //if (ocdRow.CANT_SOLICITADA == 0)
            //{
            //    ocdRow.CANT_SOLICITADA = 1;
            //}

            //if (inventario.ULT_COSTO == 0)
            //{
            //    ocdRow.PRECIO_COSTO = (decimal)inventario.COSTO_PROM;
            //}
            //else
            //{
            //    ocdRow.PRECIO_COSTO = (decimal)inventario.ULT_COSTO;
            //}

            //ocdRow.IMPORTE = ocdRow.CANT_SOLICITADA * ocdRow.PRECIO_COSTO;


            //List<string> ofertas = ocl.Ofertas(articulo.ARTICULO_ID, Helpers.Sesion.Sucursal.SucursalesID.ToString());
            //ocdRow.OFERTAS = ofertas.Count - 1;

            //if (ocdRow.OFERTAS >= 1)
            //{
            //    SIFModelo.OrdenCompra.OfertasCompra ocM = new SIFModelo.OrdenCompra.OfertasCompra();

            //    string[] data = ofertas[1].Split(new char[] { '|' });

            //    if (data.Length <= 1)
            //    {
            //        //continue;
            //    }
            //    else
            //    {
            //        ocM.ProveedorID = int.Parse(data[0]);
            //        ocM.Nombre = data[1];
            //        ocM.DescuentoOfrecido = decimal.Parse(data[2]);
            //        ocM.DescuentoEspecialProveedor = decimal.Parse(data[3]);
            //        ocM.PiezasConCargo = int.Parse(data[4]);
            //        ocM.PiezasSinCargo = int.Parse(data[5]);

            //        // ocM.PrecioCosto = decimal.Parse(data[6]);
            //        ocM.PrecioCosto = decimal.Parse(data[7]);
            //        if (ocdRow.IsPRECIO_FARMACIANull())
            //        {
            //            ocdRow.PRECIO_FARMACIA = ocM.PrecioCosto;
            //        }

            //        ocM.PrecioCosto = ocdRow.PRECIO_FARMACIA;

            //        decimal descuentoOfrecido = (ocM.PrecioCosto * (ocM.DescuentoOfrecido / 100m));
            //        decimal descuentoAdicional = (descuentoOfrecido * (ocM.DescuentoEspecialProveedor / 100m));
            //        ocM.PrecioCosto = ocM.PrecioCosto - descuentoOfrecido - descuentoAdicional;

            //        ocdRow.PRECIO_COSTO = ocM.PrecioCosto;
            //        ocdRow.PROVEEDOR_ID = ocM.ProveedorID;
            //        ocdRow.IMPORTE = ocdRow.PRECIO_COSTO * ocdRow.CANT_SOLICITADA;

            //        ocdRow.MEJOR_OFERTA_COSTO = ocM.PrecioCosto;
            //    }
            //}
            //else // debe ser igual a                          7501188802866
            //{
            //    if (!ocdRow.IsPRECIO_FARMACIANull())
            //    {
            //        ocdRow.PRECIO_COSTO = ocdRow.PRECIO_FARMACIA;
            //        ocdRow.IMPORTE = ocdRow.PRECIO_COSTO * ocdRow.CANT_SOLICITADA;

            //        ocdRow.MEJOR_OFERTA_COSTO = ocdRow.PRECIO_COSTO;
            //    }
            //}

            #endregion



        }

        SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow factura;
        private void calculaTotal()
        {
            //var totalv = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Compute("SUM(IMPORTE)", null);
            //if (totalv.ToString().IsFloatPositive())
            //{
            //    //this.totalLabel.Text = decimal.Parse(totalv.ToString()).ToString("C2");
            //}

            //var cantidadV = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Compute("SUM(CANT_SOLICITADA)", null);
            //int cantidad = 0;
            //if (cantidadV.ToString().IsIntegerPositive())
            //{
            //    cantidad = int.Parse(cantidadV.ToString());
            //}

            //var descuentov = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Compute("SUM(IMPORTE)", null);

            //this.productosLabel.Text = cantidad.ToString();

            //
            var tSum7 = ocl.dsOrdenesCompraDT.FACTURA_PROVEEDOR_DET.Compute("SUM(importe_factura_coniva)", "");
            var tSum8 = ocl.dsOrdenesCompraDT.FACTURA_PROVEEDOR_DET.Compute("SUM(importe_factura_siniva)", "");
            var tSum1 = ocl.dsOrdenesCompraDT.FACTURA_PROVEEDOR_DET.Compute("SUM(imp_oferta_siniva)", "");
            var tSum2 = ocl.dsOrdenesCompraDT.FACTURA_PROVEEDOR_DET.Compute("SUM(imp_oferta_coniva)", "");
            var tSum3 = ocl.dsOrdenesCompraDT.FACTURA_PROVEEDOR_DET.Compute("SUM(imp_descto_siniva)", "");
            var tSum6 = ocl.dsOrdenesCompraDT.FACTURA_PROVEEDOR_DET.Compute("SUM(imp_descto_coniva_menosiva)", "");
            var tSum5 = ocl.dsOrdenesCompraDT.FACTURA_PROVEEDOR_DET.Compute("SUM(IMP_IVA)", "");
            var tSum11 = ocl.dsOrdenesCompraDT.FACTURA_PROVEEDOR_DET.Compute("SUM(dif_descto_iva)", "");
            var tSum10 = ocl.dsOrdenesCompraDT.FACTURA_PROVEEDOR_DET.Compute("SUM(importe_neto)", "");


            decimal Sum7 = 0;
            decimal Sum8 = 0;
            decimal Sum1 = 0;
            decimal Sum2 = 0;
            decimal Sum3 = 0;
            decimal Sum6 = 0;
            decimal Sum5 = 0;
            decimal Sum11 = 0;
            decimal Sum10 = 0;


            if (tSum7.ToString().IsFloatPositive())
                Sum7 = decimal.Parse(tSum7.ToString());
            if (tSum8.ToString().IsFloatPositive())
                Sum8 = decimal.Parse(tSum8.ToString());
            if (tSum1.ToString().IsFloatPositive())
                Sum1 = decimal.Parse(tSum1.ToString());
            if (tSum2.ToString().IsFloatPositive())
                Sum2 = decimal.Parse(tSum2.ToString());
            if (tSum3.ToString().IsFloatPositive())
                Sum3 = decimal.Parse(tSum3.ToString());
            if (tSum6.ToString().IsFloatPositive())
                Sum6 = decimal.Parse(tSum6.ToString());
            if (tSum5.ToString().IsFloatPositive())
                Sum5 = decimal.Parse(tSum5.ToString());
            if (tSum11.ToString().IsFloatPositive())
                Sum11 = decimal.Parse(tSum11.ToString());
            if (tSum10.ToString().IsFloatPositive())
                Sum10 = decimal.Parse(tSum10.ToString());


            decimal Tot_importe_factura = 0;
            if (tSum7.ToString().IsFloatPositive())
            {

                Tot_importe_factura = decimal.Parse(tSum7.ToString()) + decimal.Parse(tSum8.ToString());
            }

            decimal Tot_descto = Sum1 + Sum2 + Sum3 + Sum6;
            decimal Tot_iva = Sum5 - Sum11;
            decimal Total_facturado = Tot_importe_factura - Tot_descto + Tot_iva;
            decimal total_neto_fact = Sum10;
            decimal Tot_descuento_siniva = Sum3;
            decimal Tot_descuento_coniva = Sum6;
            decimal Total_iva_descto = Sum11;

            Tot_desctolabelX.Text = Tot_descto.ToString("C2");
            Tot_desctolabelX.Text = Tot_descto.ToString("C2");
            Tot_ivaLabelX.Text = Tot_iva.ToString("C2");
            Total_facturadoLabelX.Text = Total_facturado.ToString("C2");
            total_neto_factLabelX.Text = total_neto_fact.ToString("C2");
            Tot_descuento_sinivaLabelX.Text = Tot_descuento_siniva.ToString("C2");
            Tot_descuento_conivaLabelX.Text = Tot_descuento_coniva.ToString("C2");
            Total_iva_desctoLabelX.Text = Total_iva_descto.ToString();

        }

        private void calculaDetalle(SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETRow detalle)
        {
            decimal porcentajeIVa = 0;

            detalle.COSTO_NETO_UNITARIO = detalle.PRECIO_VENTA_FAR * (1 - (detalle.PORC_OFERTA / 100)) * (1 - (detalle.PORC_DESCTO / 100));
            detalle.IMPORTE_NETO = detalle.PZA_CCARGO * detalle.COSTO_NETO_UNITARIO;

            detalle.IMP_OFERTA_SIVA = detalle.PRECIO_VENTA_FAR * (detalle.PORC_OFERTA / 100) * detalle.PZA_CCARGO;

            if (detalle.IMP_IVA > 0)
            {
                decimal importe = detalle.PRECIO_VENTA_FAR * detalle.PZA_CCARGO;
                decimal importe1 = importe - detalle.IMP_OFERTA_SIVA;

                porcentajeIVa = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.IMP_IVA / importe1);
            }

            detalle.IMP_OFERTA_CIVA = detalle.IMP_OFERTA_SIVA + (detalle.IMP_OFERTA_SIVA * (PorcIVA / 100));

            detalle.IMP_DESCTO_SIVA = (detalle.IMP_OFERTA_SIVA * (detalle.PORC_DESCTO / 100)) * detalle.PZA_CCARGO;
            detalle.IMP_DESCTO_CIVA = detalle.IMP_DESCTO_SIVA * (1 + (PorcIVA / 100));

            detalle.IMP_DESCTO_CIVA_MIVA = (detalle.IMP_DESCTO_CIVA) / (1 + (PorcIVA / 100));


            detalle.IMP_IVA = detalle.IMPORTE_NETO * (PorcIVA / 100);
            if (detalle.IMP_IVA == 0)
            {
                detalle.IMP_FACTURA_CIVA = detalle.PRECIO_VENTA_FAR * detalle.PZA_CCARGO;
            }
            else
            {
                detalle.IMP_FACTURA_SIVA = detalle.PRECIO_VENTA_FAR * detalle.PZA_CCARGO;
            }
            detalle.IMP_CAL_OFERTA_CIVA = (detalle.IMP_FACTURA_CIVA) - (detalle.IMP_OFERTA_CIVA);
            detalle.IMP_CAL_OFERTA_SIVA = ((detalle.IMP_FACTURA_SIVA)) - (detalle.IMP_OFERTA_SIVA);

            var totalS4 = detalle.Table.Compute("SUM(imp_descto_coniva)", "");
            var totalS6 = detalle.Table.Compute("SUM(imp_descto_coniva_menosiva)", "");


            decimal sum4 = 0;
            decimal sum6 = 0;
            if (totalS4.ToString().IsFloatPositive())
            {
                sum4 = decimal.Parse(totalS4.ToString());
            }

            if (totalS6.ToString().IsFloatPositive())
            {
                sum6 = decimal.Parse(totalS6.ToString());
            }

            detalle.DIF_DESCTO_IVA = sum4 - sum6;

            ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.AcceptChanges();
            this.superGridControl1.Update();
        }

        private void Eliminar(Boolean confirmar = true)
        {

            if (confirmar)
            {
                if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
                {
                   MessageBox.Show("Elija el artículo a eliminar de la orden de compra");
                    return;
                }

                if (MessageBoxEx.Show("¿Desea eliminar los artículos seleccionados?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            List<GridRow> filasEliminadas = new List<GridRow>();
            foreach (GridRow row in superGridControl1.PrimaryGrid.Rows)
            {
                if (row.Checked)
                {
                    filasEliminadas.Add(row);
                }
            }

            foreach (GridRow row in filasEliminadas)
            {
                if (row.DataItem == null)
                {
                    continue;
                }
                SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow dtRow = ((DataRowView)row.DataItem).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow;


                //if (factura != null && !this.factura.IsFOLIO_OC_IDNull())
                //{
                //    ocl.EliminaDetalle(dtRow);
                //}

                this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.RemoveORDEN_COMPRA_DETRow(dtRow);
            }

            //for (int i = 0; i < filasEliminadas.Count; i++)
            //{
            //    try
            //    {
            //        this.superGridControl1.PrimaryGrid.Rows.Remove(filasEliminadas[i]);
            //    }
            //    catch { }
            //}


            this.calculaTotal();
        }

        private void AgregaOfertas()
        {
            foreach (GridRow row in this.superGridControl1.PrimaryGrid.Rows)
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow oc = ((DataRowView)row.DataItem).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow;
                List<string> ofertas = ocl.Ofertas(oc.ARTICULO_ID, Helpers.Sesion.Sucursal.SucursalesID.ToString());

                var obs = row.Cells["OFERTASColumn"].RenderControl;// as DevComponents.DotNetBar.SuperGrid.GridComboBoxExEditControl;

                DevComponents.DotNetBar.SuperGrid.GridTextBoxDropDownEditControl PROVEEDOR_IDColumn = row.Cells["OFERTASColumn"].RenderControl as DevComponents.DotNetBar.SuperGrid.GridTextBoxDropDownEditControl;


                PROVEEDOR_IDColumn.ButtonCustom.Text = ofertas.Count.ToString();

            }
        }

        private void guardar()
        {
            if (factura.PROVEEDOR_ID == 0)
            {
               MessageBox.Show("Debe elegir un proveedor de la factura");
                return;
            }

            //if (factura == null)
            //{
            //    factura = .FACTURA_PROVEEDOR.AddFACTURA_PROVEEDORRow();
            //    // return;
            //}
            if (this.factura.IsNUM_FACTURANull())
            {
                //factura.USUARIO_ID = usuario.UsuariosID.ToString();
                factura.FECHA_CARGA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                factura.ESTADO = "A";
                //factura.OBSERVACION_OC = this.observacionesTextBoxX.Text;
                //GENERAMOS LA ORDEN DE COMPRA POR PRIMERA VEZ
                //ocl.GuardaOrdenCompra(Helpers.Sesion.Sucursal, usuario, factura, ocl.dsOrdenesCompra.ORDEN_COMPRA_DET);
            }
            else
            {
                //ACTUALIZAMOS LOS DETALLES Y ELIMINAMOS LOS QUE YA NO SE AGREGARON TAMBIEN EL TOTAL DE LA ORDEN DE COMPRA
                //factura.OBSERVACION_OC = this.observacionesTextBoxX.Text;
                //ocl.ActualizaOrdenCompra.(factura);
                //this.OrdenCompra

                foreach (DataRow detalle in (((DataTable)this.superGridControl1.PrimaryGrid.DataSource).Rows))
                {
                    if (detalle.RowState == DataRowState.Deleted)
                    {
                        ocl.EliminaDetalle(detalle as SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow);
                        continue;
                    }

                    if (detalle.RowState == DataRowState.Modified)
                    {
                        ocl.ActualizaOrdenCompraDetalle(detalle as SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow);
                        continue;
                    }

                    if (detalle.RowState == DataRowState.Added)
                    {
                        ocl.GuardaOrdenCompraDetalle(detalle as SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow);
                        continue;
                    }

                }

            }
        }

        #endregion


        public SIFModelo.Usuario usuario;

        internal void ActivaComandos()
        {
            this.backButton.Shortcuts.Add(eShortcut.F12);
        }

        internal void DesactivaComandos()
        {
            this.backButton.Shortcuts.Clear();
        }

        SIFNegocio.OrdenCompra.OrdenCompra ocl = new SIFNegocio.OrdenCompra.OrdenCompra();
        private string OrdenCompraFolio;

        public void Muestra()
        {
            if (Owner is View.OrdenCompra.FacturasUserControl)
            {
                View.OrdenCompra.FacturasUserControl propietario = Owner as View.OrdenCompra.FacturasUserControl;
                propietario.DesactivaComandos();
                propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;
                this.Mostrado = true;
            }


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

        internal void AgregaCliente(SIFModelo.Cliente cliente)
        {


            factura.PROVEEDOR_ID = cliente.ID;
            this.proveedorLabel.Text = "[" + cliente.ID + "]" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
        }

        private void Back()
        {
            try{
            if (Owner is View.OrdenCompra.FacturasUserControl)
            {
                View.OrdenCompra.FacturasUserControl propietario = Owner as View.OrdenCompra.FacturasUserControl;
                propietario.ActivaComandos();
                if (propietario.Owner.Owner.Contains(this))
                {
                    propietario.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }
                this.DesactivaComandos();
                this.Mostrado = false;
            }}catch { }
        }

        private void Dividir()
        {
            List<GridRow> filasANueva = new List<GridRow>();
            foreach (GridRow row in superGridControl1.PrimaryGrid.Rows)
            {
                if (row.Checked)
                {
                    filasANueva.Add(row);
                }
            }

            if (filasANueva.Count == 0)
            {
               MessageBox.Show("Elija los detalles de la Orden de Compra a pasar a una nueva Orden");
                return;
            }


            DialogResult dlg =MessageBox.Show("¿Generar una nueva Orden de Compra y eliminar los artículos seleccionados de la actual?", "Dividir", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (dlg == DialogResult.Cancel)
            {
                return;
            }

            Boolean eliminar = true;
            if (dlg == DialogResult.No)
            {
                eliminar = false;
            }


            SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETDataTable dtOC = new SIFModelo.OrdenCompra.OrdenCompraDataSet().ORDEN_COMPRA_DET;
            int numPartida = 0;
            foreach (GridRow row in superGridControl1.PrimaryGrid.Rows)
            {
                if (!row.Checked)
                {
                    continue;
                }

                SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow detalleR = ((DataRowView)row.DataItem).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow;


                SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow detalleN = dtOC.NewORDEN_COMPRA_DETRow();
                detalleN.ARTICULO_ID = detalleR.ARTICULO_ID;
                detalleN.CANT_DEVUELTA = detalleR.CANT_DEVUELTA;
                detalleN.CANT_FACTURADA = detalleR.CANT_FACTURADA;
                detalleN.CANT_MALESTADO = detalleR.CANT_MALESTADO;
                detalleN.CANT_RECIBIDA = detalleR.CANT_RECIBIDA;
                detalleN.CANT_REPOSICION = detalleR.CANT_REPOSICION;
                detalleN.CANT_SOLICITADA = detalleR.CANT_SOLICITADA;
                detalleN.DESCRIP_OFERTA = detalleR.DESCRIP_OFERTA;
                detalleN.DESCTO_FACTURA = detalleR.DESCTO_FACTURA;
                detalleN.DESCTO_FACTURA_AD1 = detalleR.DESCTO_FACTURA_AD1;
                detalleN.DESCTO_RECIBIDO = detalleR.DESCTO_RECIBIDO;
                detalleN.DESCTO_RECIBIDO_AD1 = detalleR.DESCTO_RECIBIDO_AD1;
                detalleN.DESCTO_RECIBIDO_AD2 = detalleR.DESCTO_RECIBIDO_AD2;
                detalleN.EXISTENCIAS = detalleR.EXISTENCIAS;
                detalleN.FOLIO_OC_ID = detalleR.FOLIO_OC_ID;
                detalleN.IMPORTE = detalleR.IMPORTE;
                detalleN.LABORATORIO_ID = detalleR.LABORATORIO_ID;
                detalleN.NOMBRE = detalleR.NOMBRE;
                detalleN.NUM_PARTIDA = numPartida; numPartida++;
                detalleN.OFERTA_COMPRA_ID = detalleR.OFERTA_COMPRA_ID;
                detalleN.OFERTAS = detalleR.OFERTAS;
                detalleN.PRECIO_COSTO = detalleR.PRECIO_COSTO;
                detalleN.PRECIO_FACTURA = detalleR.PRECIO_FACTURA;
                //detalleN.PRECIO_FARMACIA = detalleR.PRECIO_FARMACIA;
                detalleN.PROVEEDOR_ID = detalleR.PROVEEDOR_ID;
                detalleN.PUNTO_DE_REORDEN = detalleR.PUNTO_DE_REORDEN;
                detalleN.TIPO_MEDICAMENTO_CVE = detalleR.TIPO_MEDICAMENTO_CVE;
                detalleN.ULT_PRECIO_COMPRA = detalleR.ULT_PRECIO_COMPRA;
                detalleN.USUARIO_ID = this.usuario.UsuariosID;

                dtOC.AddORDEN_COMPRA_DETRow(detalleN);
            }


            SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow ocr = new SIFModelo.OrdenCompra.OrdenCompraDataSet().ORDEN_COMPRA.NewORDEN_COMPRARow();

            ocr.USUARIO_ID = usuario.UsuariosID;
            ocr.FECHA_ALTA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            ocr.ESTADO_OC = "A";
            //GENERAMOS LA ORDEN DE COMPRA POR PRIMERA VEZ

            ocl.GuardaOrdenCompra(Helpers.Sesion.Sucursal, usuario, ocr, dtOC, true);
            if (eliminar)
            {
                this.Eliminar(false);
            }
        }

        private void CodigoTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.AgregaArticulo();
        }

        private void CodigoTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaArticulo(this.CodigoTextBoxX.Text);
            }
        }

        private void superGridControl1_EndEdit(object sender, DevComponents.DotNetBar.SuperGrid.GridEditEventArgs e)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETRow oc = ((DataRowView)e.GridCell.GridRow.DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETRow;

            //if (e.GridCell.GridColumn.DataPropertyName == "CANT_SOLICITADA")
            //{

            //}

            //if (oc.IsCANT_SOLICITADANull())
            //{
            //    oc.IMPORTE = 0;
            //}
            //else
            //{
            //    oc.IMPORTE = (decimal)((decimal)oc.CANT_SOLICITADA * oc.PRECIO_COSTO);
            //}
            //oc.costo_neto_unit = (decimal)oc.PRECIO_VENTA_FAR * (1 - (oc.porc_oferta / 100)) * (1 - (oc.porc_descto / 100));
            //oc.importe_neto = oc.PZA_CCARGO * oc.costo_neto_unit;

            this.calculaDetalle(oc);
            this.calculaTotal();
            //this.superGridControl1.PrimaryGrid.InvalidateRender();
        }

        private void superGridControl1_RowDeleting(object sender, DevComponents.DotNetBar.SuperGrid.GridRowDeletingEventArgs e)
        {
            if (e.GridPanel.ActiveRow == null)
            {
                return;
            }

            this.Eliminar();

            e.Cancel = true;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void guardarButtonItem_Click(object sender, EventArgs e)
        {
            this.guardar();
            // this.Back();
        }

        private void cantidadTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaArticulo(this.CodigoTextBoxX.Text);
                this.CodigoTextBoxX.SelectAll();
                this.CodigoTextBoxX.Focus();
                this.cantidadTextBoxX.Text = "1";
            }
        }

        private void cantidadTextBoxX_Enter(object sender, EventArgs e)
        {
            this.cantidadTextBoxX.SelectAll();
        }

        private void superGridControl1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void superGridControl1_SelectionChanged(object sender, GridEventArgs e)
        {

        }

        private void dividirButtonItem_Click(object sender, EventArgs e)
        {
            this.Dividir();
        }

        private void eliminarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        private void InicializaEstilosFilas()
        {
            WarningCellStyle.Background.Color1 = Color.FromArgb(253, 215, 0);
            WarningCellStyle.Background.Color2 = Color.FromArgb(253, 215, 0);
            //WarningCellStyle.BorderColor.se
        }

        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle WarningCellStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle NormalCellStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;


        private void superGridControl1_PostRenderRow(object sender, GridPostRenderRowEventArgs e)
        {
            //SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow row = ((DataRowView)(((GridRow)e.GridRow).DataItem)).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow;

            ////COLOCAR LA FILA EN COLOR AMARILLO
            //if (row.IsMEJOR_OFERTA_COSTONull())
            //{
            //    return;
            //}
            //if (row.PRECIO_COSTO > row.MEJOR_OFERTA_COSTO)
            //{
            //    e.GridRow.CellStyles.Default = WarningCellStyle;
            //    e.GridRow.RowStyles.Default.ApplyStyle(WarningCellStyle);
            //}
            //else
            //{
            //    e.GridRow.CellStyles.Default = NormalCellStyle;
            //    e.GridRow.RowStyles.Default.ApplyStyle(NormalCellStyle);
            //}
        }

        private void FacturaDetallesUserControl_Load(object sender, EventArgs e)
        {

            if (this.factura == null)
            {
                this.factura = this.ocl.dsOrdenesCompraDT.FACTURA_PROVEEDOR.NewFACTURA_PROVEEDORRow();
                factura.PROVEEDOR_ID = 0;
            }
            this.usuarioLabel.Text = usuario.Nombre + " " + usuario.Apellidos;
        }

        private void seleccionaClienteButtonItem_Click(object sender, EventArgs e)
        {
            this.SeleccionaCliente();
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
