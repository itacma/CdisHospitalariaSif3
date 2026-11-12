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
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace SIF.View.OrdenCompra
{
    public partial class OrdenCompraUserControl : Templates.ListaUserControl
    {
        public OrdenCompraUserControl()
        {
            InitializeComponent();
            this.inicializaColumnas();
            this.InicializaEstilosFilas();
            this.fechaLabel.Text = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToShortDateString();
            superGridControl1.PrimaryGrid.MultiSelect = true;
            cargaAlmacenes();
            Privilegios();
            
        }

        private bool esDirecto = true;
        private bool fileImp = false;
        private bool _pintarow = false;
        List<String> clavesNoValidas = productosNoValidos();//PIT 10/03/2022 Claves no validas en Orden de Compra

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 10, int.Parse(Xbtn.Tag.ToString()));
            }
            
        }
        SIFNegocio.Articulo _Sna = new SIFNegocio.Articulo();
        public OrdenCompraUserControl(string OrdenCompraFolio, SIFModelo.Usuario usuario, bool esDividir = false)
        {
            InitializeComponent();

            this.usuarioLabel.Text = usuario.Nombre + " " + usuario.Apellidos;
            this.usuario = usuario;
            this.folioLabel.Text = OrdenCompraFolio;
            proveedorLabel.Text = "";
            this.OrdenCompraFolio = OrdenCompraFolio;
            cargaAlmacenes();
            this.cargaOrdenCompra();
            this.esDividir = esDividir;

            this.inicializaColumnas();
            if (this.esDividir)
            {
                this.dividirButtonItem.Visible = true;
            }

            int transfers = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Count(p => p.PROVEEDOR_ID == 99000);

            this.lineasLabel.Text = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Rows.Count.ToString() + "/T " + transfers.ToString();
            this.InicializaEstilosFilas();
        }

        public OrdenCompraUserControl(SIFModelo.Usuario usuario, SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC)
        {

            InitializeComponent();

            this.usuarioLabel.Text = usuario.Nombre + " " + usuario.Apellidos;
            this.usuario = usuario;
            this.folioLabel.Text = OrdenCompraFolio;
            proveedorLabel.Text = "";
            this.OrdenCompraFolio = "";
            cargaAlmacenes();
            this.inicializaColumnas();
            //END

            this.usuario = usuario;

            this.OrdenCompra = new SIFModelo.OrdenCompra.OrdenCompraDataSet().ORDEN_COMPRA.NewORDEN_COMPRARow();

            SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETDataTable tabla = new SIFNegocio.OrdenCompra.OrdenCompra().OrdenCompraDetallesPorFolio(oC).ORDEN_COMPRA_DET;

            if (!this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Contains("NOMBRE1"))
            {
                this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Add("NOMBRE1");
            }
            if (!this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Contains("COMPRADOR"))
            {
                this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Add("COMPRADOR");
            }
            if (!this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Contains("CATEGORIA_INTERNA"))
            {
                this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Add("CATEGORIA_INTERNA");
            }
            if (!this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Contains("PORCENTAJE_EOQ"))
            {
                this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Add("PORCENTAJE_EOQ");
            }
            if (!this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Contains("USUARIO_ID"))
            {
                this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Add("USUARIO_ID");
            }

            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow row in tabla)
            {
                if (row != null)
                {
                    SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocdRow = this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.NewORDEN_COMPRA_DETRow();

                    ocdRow.FOLIO_OC_ID = "";
                    ocdRow["USUARIO_ID"] = row["USUARIO_ID"];
                    ocdRow["PORCENTAJE_EOQ"] = row["PORCENTAJE_EOQ"];
                    ocdRow["CATEGORIA_INTERNA"] = row["CATEGORIA_INTERNA"];
                    ocdRow["COMPRADOR"] = row["COMPRADOR"];
                    ocdRow.ARTICULO_ID = row.ARTICULO_ID;
                    ocdRow.CANT_DEVUELTA = row.CANT_DEVUELTA;
                    ocdRow.CANT_FACTURADA = row.CANT_FACTURADA;
                    ocdRow.CANT_MALESTADO = row.CANT_MALESTADO;
                    ocdRow.CANT_RECIBIDA = row.CANT_RECIBIDA;
                    ocdRow.CANT_REPOSICION = row.CANT_REPOSICION;
                    ocdRow.CANT_SOLICITADA = row.CANT_SOLICITADA;
                    if (row.IsCODIGO_PROVEEDORNull())
                    {
                        ocdRow.CODIGO_PROVEEDOR = "";
                    }
                    else
                    {
                        ocdRow.CODIGO_PROVEEDOR = row.CODIGO_PROVEEDOR;
                    }
                    ocdRow.DESCRIP_OFERTA = row.DESCRIP_OFERTA;
                    ocdRow.DESCTO_FACTURA = row.DESCTO_FACTURA;
                    ocdRow.DESCTO_FACTURA_AD1 = row.DESCTO_FACTURA_AD1;
                    ocdRow.DESCTO_RECIBIDO = row.DESCTO_RECIBIDO;
                    ocdRow.DESCTO_RECIBIDO_AD1 = row.DESCTO_RECIBIDO_AD1;
                    ocdRow.DESCTO_RECIBIDO_AD2 = row.DESCTO_RECIBIDO_AD2;
                    ocdRow.EXISTENCIA_GENERAL = row.EXISTENCIA_GENERAL;
                    ocdRow.EXISTENCIAS = row.EXISTENCIAS;

                    //ocdRow.FOLIO_OC_ID = row.FOLIO_OC_ID;
                    ocdRow.IMPORTE = row.IMPORTE;
                    ocdRow.LABORATORIO_ID = row.LABORATORIO_ID;
                    if (row.IsMEJOR_OFERTA_COSTONull())
                    {
                        ocdRow.MEJOR_OFERTA_COSTO = row.PRECIO_COSTO;
                    }
                    else
                    {
                        ocdRow.MEJOR_OFERTA_COSTO = row.MEJOR_OFERTA_COSTO;
                    }

                    ocdRow["NOMBRE1"] = row["NOMBRE1"].ToString();
                    ocdRow.NOMBRE = row.NOMBRE;
                    ocdRow.NUM_PARTIDA = row.NUM_PARTIDA;
                    if (row.IsOBSERVACION_OC_DETNull())
                    {
                        ocdRow.OBSERVACION_OC_DET = "";
                    }
                    else
                    {
                        ocdRow.OBSERVACION_OC_DET = row.OBSERVACION_OC_DET;
                    }
                    if (row.IsOC_SEGMENTANull())
                    {
                        ocdRow.OC_SEGMENTA = 0;
                    }
                    else
                    {
                        ocdRow.OC_SEGMENTA = row.OC_SEGMENTA;
                    }
                    ocdRow.OFERTA_COMPRA_ID = row.OFERTA_COMPRA_ID;
                    ocdRow.OFERTAS = row.OFERTAS;
                    ocdRow.PRECIO_COSTO = row.PRECIO_COSTO;
                    if (row.IsPRECIO_FACTURANull())
                    {
                        ocdRow.PRECIO_FACTURA = 0;
                    }
                    else
                    {
                        ocdRow.PRECIO_FACTURA = row.PRECIO_FACTURA;
                    }

                    if (row.IsPRECIO_FARMACIANull())
                    {
                        ocdRow.PRECIO_FARMACIA = 0;
                    }
                    else
                    {
                        ocdRow.PRECIO_FARMACIA = row.PRECIO_FARMACIA;
                    }
                    ocdRow.PROVEEDOR_ID = row.PROVEEDOR_ID;
                    ocdRow.PUNTO_DE_REORDEN = row.PUNTO_DE_REORDEN;
                    ocdRow.TIPO_MEDICAMENTO_CVE = row.TIPO_MEDICAMENTO_CVE;
                    ocdRow.ULT_PRECIO_COMPRA = row.ULT_PRECIO_COMPRA;
                    ocdRow.USUARIO_ID = row.USUARIO_ID;

                    this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.AddORDEN_COMPRA_DETRow(ocdRow);
                }
            }



            this.superGridControl1.PrimaryGrid.DataSource = this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET;

            this.esDividir = false;


            if (this.esDividir)
            {
                this.dividirButtonItem.Visible = true;
            }

            int transfers = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Count(p => p.PROVEEDOR_ID == 99000);

            this.lineasLabel.Text = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Rows.Count.ToString() + "/T " + transfers.ToString();
            calculaTotal();
        }

        private bool esDividir = false;

        private void cargaAlmacenes()
        {
            SIFNegocio.Sucursales sucursalL = new SIFNegocio.Sucursales();
            //this.almacenComboBoxEx.DataSource = sucursalL.Buscar("", "").DataSource;
            //almacenComboBoxEx.DisplayMember = "Nombre";
            //almacenComboBoxEx.ValueMember = "SucursalesID";

            //almacenComboBoxEx.SelectedValue = 
            sucursalElegidaLabel.Text = Helpers.Sesion.Sucursal.Nombre;

        }

        private void cargaOrdenCompra()
        {
            this.OrdenCompra = ocl.OrdenCompraPoFolio(OrdenCompraFolio);
            // OrdenCompra.USUARIO_ID = this.usuario.UsuariosID;
            this.ocl.dsOrdenesCompra = ocl.OrdenCompraDetallesPorFolio(OrdenCompra);

            this.superGridControl1.PrimaryGrid.DataSource = this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET;
            //this.superGridControl1.PrimaryGrid.DataMember = this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.TableName;


            //ASIGNAMOS EL PROVEEDOR
            SIFModelo.Cliente proveedor = new SIFNegocio.Clientes().ClientePorID(OrdenCompra.PROVEEDOR_ID);
            this.proveedorSeleccionado = proveedor;
            proveedorLabel.Text = proveedor.Nombre + " " + proveedor.ApellidoPaterno + " " + proveedor.ApellidoMaterno;
            this.statusOClabel.Text = OrdenCompra.ESTADO_OC;
            this.fechaLabel.Text = OrdenCompra.FECHA_ALTA.ToShortDateString();
            if (OrdenCompra.IsOBSERVACION_OCNull())
            {
                OrdenCompra.OBSERVACION_OC = "";
            }
            this.observacionesTextBoxX.Text = OrdenCompra.OBSERVACION_OC;

            if (OrdenCompra.ESTADO_OC.Trim() != "A")
            {
                this.eliminarButtonItem.Shortcuts.Clear();
                this.eliminarButtonItem.Enabled = false;
                this.generacionAutomaticaButton.Shortcuts.Clear();
                this.generacionAutomaticaButton.Enabled = false;
                this.guardarButtonItem.Shortcuts.Clear();
                this.guardarButtonItem.Enabled = false;
                this.agregarArticuloButtonItem.Shortcuts.Clear();
                this.agregarArticuloButtonItem.Enabled = false;
                this.seleccionaClienteButtonItem.Shortcuts.Clear();
                this.seleccionaClienteButtonItem.Enabled = false;
                this.superGridControl1.PrimaryGrid.AllowSelection = false;
                this.cantidadTextBoxX.Enabled = false;
                this.CodigoTextBoxX.Enabled = false;
                this.generalButtonItem.Enabled = false;
                lineaButtonItem.Enabled = false;
                this.nuevoButtonItem.Enabled = false;
                this.superGridControl1.PrimaryGrid.AllowRowDelete = false;
            }

            foreach (var detalle in ocl.dsOrdenesCompra.ORDEN_COMPRA_DET)
            {
                if (detalle.PRECIO_COSTO > 0)
                {
                    continue;
                }

                decimal descuentoOfrecido = (detalle.PRECIO_FARMACIA * (detalle.DESCTO_RECIBIDO / 100m));
                decimal descuentoAdicional = (descuentoOfrecido * (detalle.DESCTO_RECIBIDO_AD1 / 100m));

                detalle.PRECIO_COSTO = detalle.PRECIO_FARMACIA - descuentoOfrecido - descuentoAdicional;
                detalle.IMPORTE = detalle.PRECIO_COSTO * detalle.CANT_SOLICITADA;
            }
            this.calculaTotal();
        }



        private void AgregaArticulo()
        {
            View.Articulos.ArticuloUserControl frmArticulos = new View.Articulos.ArticuloUserControl();
            frmArticulos.usuario = this.usuario;
            frmArticulos.Owner = this;
            frmArticulos.Muestra();
        }

        private void AgregaArticulo(string articuloClave,bool EsImportado=false)
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
            if (articulo.ACTIVO == SIFModelo.Tipos.SiNo.NO) {
               MessageBox.Show("El codigo esta inactivo!!! ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            this.AgregaArticulo(articulo,EsImportado);
            
        }

        private void AgregaArticuloAjusteCodigo(string articuloClave,int cantidad,decimal precio,string nombre)
        {
            if (string.IsNullOrEmpty(articuloClave))
            {
                return;
            }

            SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(articuloClave);

            if (articulo == null)
            {
               MessageBox.Show("El artículo "+ articuloClave + " - " + nombre+" no se ha encontrado en el catálogo \n Favor de dar de alta y volver a intentar. ");
                Back();
                return;
            }
            if (articulo.ACTIVO == SIFModelo.Tipos.SiNo.NO)
            {
               MessageBox.Show("El codigo esta inactivo!!! ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            this.AgregaArticuloAjusteDet(articulo,cantidad,precio);

        }

        private void agregaArticuloButtonItem_Click(object sender, EventArgs e)
        {
            this.AgregaArticulo();
        }

        private void inicializaColumnas()
        {
            DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl CANT_SOLICITADAColumn = this.superGridControl1.PrimaryGrid.Columns["CANT_SOLICITADAColumn"].EditControl as DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl;
            CANT_SOLICITADAColumn.MinValue = 0;

            DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl PRECIO_COSTOColumn = this.superGridControl1.PrimaryGrid.Columns["PRECIO_COSTOColumn"].EditControl as DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl;
            try
            {
                PRECIO_COSTOColumn.MinValue = 0.01;
            }
            catch
            {
            }

            DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl DESCRIP_OFERTAColumn = this.superGridControl1.PrimaryGrid.Columns["DESCRIP_OFERTAColumn"].EditControl as DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl;
            DESCRIP_OFERTAColumn.MaxLength = 30;

            DevComponents.DotNetBar.SuperGrid.GridTextBoxDropDownEditControl OFERTASColumn = this.superGridControl1.PrimaryGrid.Columns["OFERTASColumn"].EditControl as DevComponents.DotNetBar.SuperGrid.GridTextBoxDropDownEditControl;
            OFERTASColumn.ButtonCustom.Visible = true;
            //OFERTASColumn.ButtonCustom.Text = "0";
            OFERTASColumn.ButtonCustomClick += OFERTASColumn_ButtonCustom_CLICK;

            DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl PROVEEDOR_IDColumn = this.superGridControl1.PrimaryGrid.Columns["PROVEEDOR_IDColumn"].EditControl as DevComponents.DotNetBar.SuperGrid.GridTextBoxXEditControl;
            PROVEEDOR_IDColumn.ButtonCustom.Visible = true;

            PROVEEDOR_IDColumn.ButtonCustomClick += PROVEEDOR_IDColumn_ButtonCustom_CLICK;
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

                row.USUARIO_ID = this.usuario.UsuariosID;
                OfertasCompraForm frmOfertas = new OfertasCompraForm(row);

                if (frmOfertas.ShowDialog() == DialogResult.OK)
                {

                    if (row.Bloqueado)
                    {
                        return;
                    }

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

                        row.DESCTO_RECIBIDO = 0;
                        row.DESCTO_RECIBIDO_AD1 = 0;

                        return;
                    }

                    //Revisamos si existe TRANSFER
                    SIFModelo.Articulo articuloC = new SIFModelo.Articulo();
                    articuloC = new SIFModelo.Articulo();
                    articuloC.ARTICULO_ID = row.ARTICULO_ID;
                    SIFModelo.OrdenCompra.InfromacionMayorista mayorista = new SIFNegocio.OrdenCompra.InformacionMayorista().InformacionMayoristaPorArticulo(articuloC);


                    if (mayorista != null)
                    {
                        if (mayorista.PROVEEDOR_ID != 0 && mayorista.PERIODO_COMPRA_INICIO != null && mayorista.PERIODO_COMPRA_FIN != null)
                        {
                            if (mayorista.PERIODO_COMPRA_INICIO.Value <= DateTime.Now && mayorista.PERIODO_COMPRA_FIN >= DateTime.Now)
                            {
                                row.PROVEEDOR_ID = mayorista.PROVEEDOR_ID;

                                if (mayorista.Bloqueado == SIFModelo.Tipos.SiNo.SI)
                                {
                                    row.Bloqueado = true;
                                }
                                else
                                {
                                    row.OC_SEGMENTA = -1;
                                    // row.USUARIO_ID = 0;
                                }
                            }
                        }
                    }


                    if (mayorista != null)
                    {

                        if (mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR)
                        {
                            row.PROVEEDOR_ID = 99012;
                            row.DESCTO_RECIBIDO_AD1 = mayorista.DESCTO_ADICIONAL_SABA;

                        }
                        else if (mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR)
                        {
                            row.PROVEEDOR_ID = 99064;
                            row.DESCTO_RECIBIDO_AD1 = mayorista.DESCTO_ADICIONAL_NADRO;
                            // break;
                        }
                        else if (mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR)
                        {
                            row.PROVEEDOR_ID = 99035;
                            row.DESCTO_RECIBIDO_AD1 = mayorista.DESCTO_ADICIONAL_DROGUEROS;
                            // break;
                        }
                    }
                    else
                    {
                        row.DESCTO_RECIBIDO_AD1 = 0;
                    }


                    //asignamos la oferta a la orden de compra
                    //string[] valores = frmOfertas.Oferta.Split(new char[] { ('|') });
                    row.DESCTO_RECIBIDO = oferta.DescuentoOfrecido;
                    row.PROVEEDOR_ID = oferta.ProveedorID;
                    row.PRECIO_COSTO = oferta.PrecioCosto;
                    row.DESCRIP_OFERTA = oferta.DescuentoOfrecido.ToString();
                    row.IMPORTE = row.PRECIO_COSTO * row.CANT_SOLICITADA;




                }
            }
        }

        public bool Mostrado = false;
        public object Owner;

        #region Funciones y  Metodos


        public void AgregaArticulo(SIFModelo.Articulo articulo, bool esImportado=false)
        {
                if (articulo == null)
                {
                   MessageBox.Show("Debe elgir un producto para la orden de compra");
                    return;
                }
            bool validaHup = true;
            if (articulo.ARTICULO_ID.Length >= 3)
            {
                if (clavesNoValidas.Any(x => x == articulo.ARTICULO_ID.Substring(0, 3)))
                    validaHup = false;
            }

            if (validaHup)//valida si la clave exista
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow existente = null;
                if (this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Select("ARTICULO_ID = '" + articulo.ARTICULO_ID + "'", "").Count() > 0)
                {
                    existente = (SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow)
                    ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Select("ARTICULO_ID = '" + articulo.ARTICULO_ID + "'", "").First();

                    //if (MessageBoxEx.Show("El artículo ya esta agregado a la orden de compra, ¿Volver a agregarlo?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    //{
                    //    return;
                    //}

                }

                //Validar si ya existe y solo modificar la cantidad
                if (existente != null)
                {
                    existente.CANT_SOLICITADA = int.Parse(cantidadTextBoxX.Text);
                    //existente.ULT_PRECIO_COMPRA=
                    this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.AcceptChanges();
                    calculaTotal();
                    return;
                }

                if (proveedorSeleccionado != null)
                {
                    //MessageBox.Show("Seleccione el proveedor de la orden de compra");
                    //  proveedorSeleccionado = new SIFNegocio.Clientes().ClientePorID(articulo.PROVEEDOR_ID);
                    // return;

                    //if (OrdenCompra == null)
                    //{
                    //    OrdenCompra = this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.NewORDEN_COMPRA_DETRow();
                    //   MessageBox.Show("Inicialize la orden de compra");
                    //    return;
                    //}

                    //articulo.PROVEEDOR_ID = OrdenCompra.PROVEEDOR_ID;
                    //if (!new SIFNegocio.Usuarios().ListaProveedores(usuario).Contains(articulo.PROVEEDOR_ID.ToString()))
                    //{
                    //   MessageBox.Show("El usuario no puede agregar artículos de este proveedor");
                    //    return;
                    //}

                    //}
                    //else
                    //{
                    articulo.PROVEEDOR_ID = proveedorSeleccionado.ID;

                    articulo.PROVEEDOR_NOMBRE = proveedorSeleccionado.Nombre + " " + proveedorSeleccionado.ApellidoPaterno + " " + proveedorSeleccionado.ApellidoMaterno;
                }
                else
                {
                    SIFModelo.Cliente proveedorArticulo = new SIFNegocio.Clientes().ClientePorID(articulo.PROVEEDOR_ID);
                    articulo.PROVEEDOR_NOMBRE = proveedorArticulo.Nombre + " " + proveedorArticulo.ApellidoPaterno + " " + proveedorArticulo.ApellidoMaterno;

                }


                SIFModelo.Sucursal sucursal = Helpers.Sesion.Sucursal;
                if (sucursal == null)
                {
                    sucursal = Helpers.Sesion.Sucursal;
                }

                SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocdRow = this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.NewORDEN_COMPRA_DETRow();

                if (existente != null)
                {
                    ocdRow = existente;
                }
                else
                {
                    SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow row = ocl.GeneraDeEOQArticulo(sucursal, usuario, articulo.ARTICULO_ID);

                    if (row != null)
                    {
                        if (!ocdRow.Table.Columns.Contains("NOMBRE1"))
                        {
                            ocdRow.Table.Columns.Add("NOMBRE1");
                        }
                        if (!ocdRow.Table.Columns.Contains("COMPRADOR"))
                        {
                            ocdRow.Table.Columns.Add("COMPRADOR");
                        }
                        if (!ocdRow.Table.Columns.Contains("CATEGORIA_INTERNA"))
                        {
                            ocdRow.Table.Columns.Add("CATEGORIA_INTERNA");
                        }
                        if (!ocdRow.Table.Columns.Contains("PORCENTAJE_EOQ"))
                        {
                            ocdRow.Table.Columns.Add("PORCENTAJE_EOQ");
                        }
                        if (!ocdRow.Table.Columns.Contains("USUARIO_ID"))
                        {
                            ocdRow.Table.Columns.Add("USUARIO_ID");
                        }

                        ocdRow["USUARIO_ID"] = row["USUARIO_ID"];
                        ocdRow["PORCENTAJE_EOQ"] = row["PORCENTAJE_EOQ"];
                        ocdRow["CATEGORIA_INTERNA"] = row["CATEGORIA_INTERNA"];
                        ocdRow["COMPRADOR"] = row["COMPRADOR"];
                        ocdRow.ARTICULO_ID = row.ARTICULO_ID;
                        ocdRow.CANT_DEVUELTA = row.CANT_DEVUELTA;
                        ocdRow.CANT_FACTURADA = row.CANT_FACTURADA;
                        ocdRow.CANT_MALESTADO = row.CANT_MALESTADO;
                        ocdRow.CANT_RECIBIDA = row.CANT_RECIBIDA;
                        ocdRow.CANT_REPOSICION = row.CANT_REPOSICION;
                        if (fileImp)// define si se esta importando un archivo, de ser asi tomara la cantidad que dice el archivo
                            ocdRow.CANT_SOLICITADA = Convert.ToInt32(cantidadTextBoxX.Text);
                        else
                            ocdRow.CANT_SOLICITADA = row.CANT_SOLICITADA;
                        ocdRow.CODIGO_PROVEEDOR = row.CODIGO_PROVEEDOR;
                        ocdRow.DESCRIP_OFERTA = row.DESCRIP_OFERTA;
                        ocdRow.DESCTO_FACTURA = row.DESCTO_FACTURA;
                        ocdRow.DESCTO_FACTURA_AD1 = row.DESCTO_FACTURA_AD1;
                        ocdRow.DESCTO_RECIBIDO = row.DESCTO_RECIBIDO;
                        ocdRow.DESCTO_RECIBIDO_AD1 = row.DESCTO_RECIBIDO_AD1;
                        ocdRow.DESCTO_RECIBIDO_AD2 = row.DESCTO_RECIBIDO_AD2;
                        ocdRow.EXISTENCIA_GENERAL = row.EXISTENCIA_GENERAL;
                        ocdRow.EXISTENCIAS = row.EXISTENCIAS;

                        //ocdRow.FOLIO_OC_ID = row.FOLIO_OC_ID;
                        ocdRow.IMPORTE = row.IMPORTE;
                        ocdRow.LABORATORIO_ID = row.LABORATORIO_ID;
                        ocdRow.MEJOR_OFERTA_COSTO = row.MEJOR_OFERTA_COSTO;


                        ocdRow["NOMBRE1"] = row["NOMBRE1"].ToString();
                        ocdRow.NOMBRE = row.NOMBRE;
                        ocdRow.NUM_PARTIDA = row.NUM_PARTIDA;
                        ocdRow.OBSERVACION_OC_DET = row.OBSERVACION_OC_DET;
                        ocdRow.OC_SEGMENTA = row.OC_SEGMENTA;
                        ocdRow.OFERTA_COMPRA_ID = row.OFERTA_COMPRA_ID;
                        ocdRow.OFERTAS = row.OFERTAS;
                        ocdRow.PRECIO_COSTO = row.PRECIO_COSTO;
                        if (row.IsPRECIO_FACTURANull())
                        {
                            row.PRECIO_FACTURA = 0;
                        }
                        ocdRow.PRECIO_FACTURA = row.PRECIO_FACTURA;
                        ocdRow.PRECIO_FARMACIA = row.PRECIO_FARMACIA;
                        ocdRow.PROVEEDOR_ID = row.PROVEEDOR_ID;
                        ocdRow.PUNTO_DE_REORDEN = row.PUNTO_DE_REORDEN;
                        ocdRow.TIPO_MEDICAMENTO_CVE = row.TIPO_MEDICAMENTO_CVE;
                        ocdRow.ULT_PRECIO_COMPRA = row.ULT_PRECIO_COMPRA;
                        ocdRow.USUARIO_ID = row.USUARIO_ID;

                        if (this.proveedorSeleccionado != null)
                        {
                            articulo.PROVEEDOR_ID = proveedorSeleccionado.ID;

                            articulo.PROVEEDOR_NOMBRE = proveedorSeleccionado.Nombre + " " + proveedorSeleccionado.ApellidoPaterno + " " + proveedorSeleccionado.ApellidoMaterno;
                            ocdRow.PROVEEDOR_ID = articulo.PROVEEDOR_ID;
                        }

                    }
                }

                if (this.OrdenCompra != null && !this.OrdenCompra.IsFOLIO_OC_IDNull())
                {
                    ocdRow.FOLIO_OC_ID = this.OrdenCompra.FOLIO_OC_ID;
                }



                string provID = null;
                if (this.clienteSeleccionado != null)
                {
                    provID = clienteSeleccionado.ID.ToString();
                }

                decimal porcentaje_eoq = porcentajeEOQintegerInput.Value;

                if (porcentaje_eoq == 100)
                {
                    porcentaje_eoq = 9999999;
                }

                string tipoCompra = esDirecto == true ? "D" : "M";

                int? proveedorID = null;

                if (proveedorSeleccionado != null)
                {
                    proveedorID = proveedorSeleccionado.ID;
                }

                // SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow row



                //if (ds.ORDEN_COMPRA_DET.Count == 0)
                //{
                //    return;
                //}

                //ocdRow = ds.ORDEN_COMPRA_DET.First();


                //SIFNegocio.Inventario.Inventario InventarioL = new SIFNegocio.Inventario.Inventario();

                //SIFModelo.Sucursal suc = Helpers.Sesion.Sucursal;


                //var inventario = InventarioL.InventarioArticulo(articulo, suc);

                //if (inventario == null)
                //{

                //    inventario = new SIFModelo.Inventarios.InventarioDataSet.INVENTARIODataTable().NewINVENTARIORow();
                //    inventario.EXISTENCIAS = 0;
                //    inventario.PUNTO_DE_REORDEN = 1;
                //    inventario.ULT_COSTO = 0;
                //    inventario.COSTO_PROM = 0;
                //    inventario.EXISTENCIA_GENERAL = 0;
                //}



                //ocdRow.ARTICULO_ID = articulo.ARTICULO_ID;
                //ocdRow.CANT_DEVUELTA = 0;
                //ocdRow.CANT_FACTURADA = 0;
                //ocdRow.CANT_MALESTADO = 0;
                //ocdRow.CANT_RECIBIDA = 0;
                //ocdRow.CANT_REPOSICION = 0;
                //ocdRow.PRECIO_COSTO = ocl.PrecioFarmacia(articulo.ARTICULO_ID, articulo.PROVEEDOR_ID, Helpers.Sesion.Sucursal);
                //ocdRow.PRECIO_FARMACIA = ocdRow.PRECIO_COSTO;

                ////if (proveedorSeleccionado != null)
                ////{
                ////    ocdRow.PROVEEDOR_ID = this.proveedorSeleccionado.ID;

                ////    //SACAMOS EL PRECIO FARMACIA DE LA LISTA DE RECMERC
                ////    if (this.proveedorSeleccionado.ID == 12)
                ////    {
                ////        var precioFarmacia = ocl.PrecioFarmaciaSaba(ocdRow);

                ////        if (precioFarmacia.ToString().IsFloat())
                ////        {
                ////            ocdRow.PRECIO_FARMACIA = decimal.Parse(precioFarmacia.ToString());
                ////        }
                ////    }

                ////}

                //ocdRow.EXISTENCIA_GENERAL = inventario.EXISTENCIA_GENERAL;
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
                //if (OrdenCompraFolio != null)
                //    ocdRow.FOLIO_OC_ID = this.OrdenCompraFolio;
                //else
                //    ocdRow.FOLIO_OC_ID = "";

                //ocdRow.LABORATORIO_ID = articulo.LABORATORIO_ID;
                //ocdRow.NOMBRE = articulo.NOMBRE1;
                //ocdRow.NUM_PARTIDA = ocdRow.Table.Rows.Count + 1;
                //ocdRow.OFERTA_COMPRA_ID = 0;
                //ocdRow.PRECIO_FACTURA = 0;
                //ocdRow.PROVEEDOR_ID = articulo.PROVEEDOR_ID;
                //ocdRow.PUNTO_DE_REORDEN = inventario.PUNTO_DE_REORDEN;

                //SIFNegocio.OrdenCompra.InformacionMayorista mayoristaL = new SIFNegocio.OrdenCompra.InformacionMayorista();
                //SIFModelo.OrdenCompra.InfromacionMayorista mayorista = mayoristaL.InformacionMayoristaPorArticulo(articulo);

                ////Revisamos si existe TRANSFER
                //if (mayorista != null)
                //{
                //    ocdRow.TIPO_MEDICAMENTO_CVE = mayoristaL.TipoMedicamentoMayorista(mayorista);
                //}
                //else
                //{
                //    ocdRow.TIPO_MEDICAMENTO_CVE = "POR ASIGNAR";
                //}
                //ocdRow.ULT_PRECIO_COMPRA = (double)inventario.ULT_COSTO;
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

                //if (ocdRow.PRECIO_FARMACIA == 0)
                //{
                //    if (ocdRow.ULT_PRECIO_COMPRA.ToString().IsFloatPositive())
                //        ocdRow.PRECIO_FARMACIA = decimal.Parse(ocdRow.ULT_PRECIO_COMPRA.ToString());
                //}

                if (ocdRow.IsCANT_SOLICITADANull())
                {
                    ocdRow.CANT_SOLICITADA = 1;
                }

                ocdRow.IMPORTE = ocdRow.CANT_SOLICITADA * ocdRow.PRECIO_FARMACIA;

                SIFModelo.OrdenCompra.InfromacionMayorista mayorista = new SIFNegocio.OrdenCompra.InformacionMayorista().InformacionMayoristaPorArticulo(articulo);

                //Revisamos si existe TRANSFER
                if (mayorista != null)
                {
                    if (mayorista.PROVEEDOR_ID != 0 && mayorista.PERIODO_COMPRA_INICIO != null && mayorista.PERIODO_COMPRA_FIN != null)
                    {
                        if (mayorista.PERIODO_COMPRA_INICIO.Value <= DateTime.Now && mayorista.PERIODO_COMPRA_FIN >= DateTime.Now)
                        {
                            ocdRow.PROVEEDOR_ID = mayorista.PROVEEDOR_ID;


                            if (mayorista.Bloqueado == SIFModelo.Tipos.SiNo.SI)
                            {
                                ocdRow.Bloqueado = true;
                            }
                            else
                            {
                                ocdRow.OC_SEGMENTA = -1;
                                ocdRow.ES_TRANSFER = "s";
                                // ocdRow.USUARIO_ID = 0;
                            }
                        }
                    }
                }


                if (mayorista != null && mayorista.Bloqueado != SIFModelo.Tipos.SiNo.SI)
                {

                    if (mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR)
                    {
                        ocdRow.PROVEEDOR_ID = 99012;
                        ocdRow.DESCTO_RECIBIDO_AD1 = mayorista.DESCTO_ADICIONAL_SABA;

                    }
                    else if (mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR)
                    {
                        ocdRow.PROVEEDOR_ID = 99064;
                        ocdRow.DESCTO_RECIBIDO_AD1 = mayorista.DESCTO_ADICIONAL_NADRO;
                        // break;
                    }
                    else if (mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR)
                    {
                        ocdRow.PROVEEDOR_ID = 99035;
                        ocdRow.DESCTO_RECIBIDO_AD1 = mayorista.DESCTO_ADICIONAL_DROGUEROS;
                        // break;
                    }
                }
                else
                {
                    ocdRow.DESCTO_RECIBIDO_AD1 = 0;
                }


                if (!esImportado)
                {
                    if (mayorista.alertaAlComprar > 0)
                    {

                        if (DialogResult.OK == MessageBox.Show($"Considerar la compra del siguiente producto {articulo.ARTICULO_ID}-{articulo.NOMBRE1}", "Informacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Information))
                        {
                            if (DialogResult.Yes == MessageBox.Show("¿Desea seguir con el proceso de compra del producto?", "Informacion",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {

                            }
                            else { return; }

                        }
                        else { return; }
                    }
                }
                    
            


                    if (ocdRow.IsNull("PROVEEDOR_ID"))
                    {
                        ocdRow.PROVEEDOR_ID = 0;
                    }

                    if (this.proveedorSeleccionado != null)
                    {
                        articulo.PROVEEDOR_ID = proveedorSeleccionado.ID;

                        articulo.PROVEEDOR_NOMBRE = proveedorSeleccionado.Nombre + " " + proveedorSeleccionado.ApellidoPaterno + " " + proveedorSeleccionado.ApellidoMaterno;
                        ocdRow.PROVEEDOR_ID = articulo.PROVEEDOR_ID;
                    }

                    List<string> ofertas = ocl.Ofertas(articulo.ARTICULO_ID, Helpers.Sesion.Sucursal.SucursalesID.ToString(), ocdRow.PROVEEDOR_ID);

                    //SI EL PROVEEDOR ES IGUAL A 99012 AGREGAR LA OFERTA ESPECIAL


                    ocdRow.OFERTAS = ofertas.Count;

                    if (ocdRow.OFERTAS >= 1)
                    {
                        SIFModelo.OrdenCompra.OfertasCompra ocM = new SIFModelo.OrdenCompra.OfertasCompra();

                        string[] data = ofertas[0].Split(new char[] { '|' });

                        if (data.Length <= 1)
                        {
                            //continue;
                        }
                        else
                        {
                            ocM.ProveedorID = int.Parse(data[0]);

                            if (proveedorSeleccionado != null && ocM.ProveedorID == ocdRow.PROVEEDOR_ID)
                            {

                            }

                            //{

                            ocM.Nombre = data[1];
                            ocM.DescuentoOfrecido = decimal.Parse(data[2]);
                            ocM.DescuentoEspecialProveedor = decimal.Parse(data[3]);
                            ocM.PiezasConCargo = int.Parse(data[4]);
                            ocM.PiezasSinCargo = int.Parse(data[5]);

                            // ocM.PrecioCosto = decimal.Parse(data[6]);
                            ocM.PrecioCosto = decimal.Parse(data[7]);
                            if (ocdRow.IsPRECIO_FARMACIANull())
                            {
                                ocdRow.PRECIO_FARMACIA = ocM.PrecioCosto;
                            }

                            ocM.PrecioCosto = ocdRow.PRECIO_FARMACIA;



                            decimal descuentoOfrecido = (ocM.PrecioCosto * (ocM.DescuentoOfrecido / 100m));
                            decimal descuentoAdicional = (descuentoOfrecido * (ocM.DescuentoEspecialProveedor / 100m));

                            ocdRow.DESCTO_RECIBIDO = ocM.DescuentoOfrecido;
                            ocdRow.DESCTO_RECIBIDO_AD1 = ocM.DescuentoEspecialProveedor;
                            ocM.PrecioCosto = ocM.PrecioCosto - descuentoOfrecido - descuentoAdicional;


                            //ocdRow.DESCTO_RECIBIDO_AD2 = 0;

                            ocdRow.IMPORTE = ocdRow.PRECIO_COSTO * ocdRow.CANT_SOLICITADA;
                            ocdRow.MEJOR_OFERTA_COSTO = ocM.PrecioCosto;

                            ocdRow.PRECIO_COSTO = ocM.PrecioCosto;
                            ocdRow.PROVEEDOR_ID = ocM.ProveedorID;

                            if (proveedorSeleccionado != null && ocM.ProveedorID != proveedorSeleccionado.ID)
                            {
                                ocdRow.PROVEEDOR_ID = proveedorSeleccionado.ID;
                            }
                            else
                            {
                                ocdRow.PROVEEDOR_ID = ocM.ProveedorID;
                            }


                            //} 
                        }
                    }
                    else // debe ser igual a                          7501188802866
                    {
                        if (!ocdRow.IsPRECIO_FARMACIANull())
                        {
                            ocdRow.PRECIO_COSTO = ocdRow.PRECIO_FARMACIA;
                            ocdRow.IMPORTE = ocdRow.PRECIO_COSTO * ocdRow.CANT_SOLICITADA;

                            ocdRow.MEJOR_OFERTA_COSTO = ocdRow.PRECIO_COSTO;
                        }
                    }

                    if (existente == null)
                    {
                        try
                        {
                            if (ocdRow.FOLIO_OC_ID == null)
                            {
                                ocdRow.FOLIO_OC_ID = "";
                            }
                        }
                        catch
                        {
                            ocdRow.FOLIO_OC_ID = "";
                        }

                        if (ocdRow.IsNull("ARTICULO_ID"))
                        {
                            ocdRow.ARTICULO_ID = articulo.ARTICULO_ID;
                            ocdRow.CANT_DEVUELTA = 0;
                            ocdRow.CANT_FACTURADA = 0;
                            ocdRow.CANT_MALESTADO = 0;
                            ocdRow.CANT_RECIBIDA = 0;
                            ocdRow.CANT_REPOSICION = 0;
                            ocdRow.PROVEEDOR_ID = articulo.PROVEEDOR_ID;
                            ocdRow.PUNTO_DE_REORDEN = 0;
                            ocdRow.TIPO_MEDICAMENTO_CVE = "";
                            ocdRow.ULT_PRECIO_COMPRA = 0;
                            ocdRow.USUARIO_ID = this.usuario.UsuariosID;
                            ocdRow.DESCRIP_OFERTA = "";
                            ocdRow.DESCTO_RECIBIDO = 0;
                            ocdRow.DESCTO_FACTURA = 0;
                            ocdRow.DESCTO_FACTURA_AD1 = 0;
                            ocdRow.DESCTO_RECIBIDO = 0;
                            ocdRow.DESCTO_RECIBIDO_AD1 = 0;
                            ocdRow.DESCTO_RECIBIDO_AD2 = 0;

                            if (!ocdRow.Table.Columns.Contains("NOMBRE1"))
                            {
                                ocdRow.Table.Columns.Add("NOMBRE1");
                            }
                            ocdRow["NOMBRE1"] = articulo.NOMBRE1;
                            ocdRow.OC_SEGMENTA = 0;

                            if (!ocdRow.Table.Columns.Contains("COMPRADOR"))
                            {
                                ocdRow.Table.Columns.Add("COMPRADOR");
                            }

                            ocdRow["COMPRADOR"] = "POR ASIGNAR";
                            ocdRow.USUARIO_ID = 0;
                            ocdRow.LABORATORIO_ID = articulo.PROVEEDOR_ID;
                            //ocdRow.
                        }


                        this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Rows.Add(ocdRow);
                    }
                    this.superGridControl1.PrimaryGrid.DataSource = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET;


                    //if (ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Rows.Count > 0)
                    //{
                    //    this.almacenComboBoxEx.Enabled = false;
                    //}

                    decimal descuentoOfrecido2 = (ocdRow.PRECIO_FARMACIA * (ocdRow.DESCTO_RECIBIDO / 100m));
                    decimal descuentoAdicional2 = (descuentoOfrecido2 * (ocdRow.DESCTO_RECIBIDO_AD1 / 100m));

                    ocdRow.PRECIO_COSTO = ocdRow.PRECIO_FARMACIA - descuentoOfrecido2 - descuentoAdicional2;
                    ocdRow.IMPORTE = ocdRow.PRECIO_COSTO * ocdRow.CANT_SOLICITADA;

                    if (superGridControl1.PrimaryGrid.LastSelectableRow != null)
                    {
                        this.superGridControl1.PrimaryGrid.SetActiveRow(superGridControl1.PrimaryGrid.LastSelectableRow);
                    }


                    //validamos el codigo del proveedor
                    SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(ocdRow.PROVEEDOR_ID);
                    /*
                    if (this.esDirecto)
                    {
                        if (cliente != null)
                        {
                            if (cliente.Nombre.Contains("SABA"))
                            {//sacar el codigo de la lista de saba 
                                ocdRow.CODIGO_PROVEEDOR = SIFNegocio.OrdenCompra.Compras.CodigoProveedorSABA(ocdRow);
                            }
                            else
                                if (cliente.Nombre.Contains("NADRO"))
                                {//sacar el codigo de la lista de NADRO 
                                    ocdRow.CODIGO_PROVEEDOR = SIFNegocio.OrdenCompra.Compras.CodigoProveedorNADRO(ocdRow);
                                }
                                else
                                {
                                    ocdRow.CODIGO_PROVEEDOR = SIFNegocio.OrdenCompra.Compras.CodigoProveedorDROG(ocdRow);
                                }

                        }
                        else
                        {
                            ocdRow.CODIGO_PROVEEDOR = "";
                        }
                    }
                    */
                    this.calculaTotal();
                    this.CodigoTextBoxX.SelectAll();
                    CodigoTextBoxX.Text = articulo.ARTICULO_ID;
                    this.cantidadTextBoxX.SelectAll();
                    this.cantidadTextBoxX.Focus();

                    int transfers = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Count(p => p.PROVEEDOR_ID == 99000);

                    this.lineasLabel.Text = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Rows.Count.ToString() + "/T " + transfers.ToString();
                }
                else
                {
                    MessageBox.Show("NO ES POSIBLE AGREGAR ESTOS ARTICULOS: \n" + articulo.ARTICULO_ID + " - " + articulo.NOMBRE1);
                }
            
        }

        public void AgregaArticuloAjusteDet(SIFModelo.Articulo articulo,int cantidad,decimal precio)
        {
           
            SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow existente = null;
            if (this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Select("ARTICULO_ID = '" + articulo.ARTICULO_ID + "'", "").Count() > 0)
            {
                existente = (SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow)
                ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Select("ARTICULO_ID = '" + articulo.ARTICULO_ID + "'", "").First();

                //if (MessageBoxEx.Show("El artículo ya esta agregado a la orden de compra, ¿Volver a agregarlo?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                //{
                //    return;
                //}

            }

            //Validar si ya existe y solo modificar la cantidad
            if (existente != null)
            {
                existente.CANT_SOLICITADA = int.Parse(cantidadTextBoxX.Text);
                //existente.ULT_PRECIO_COMPRA=
                this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.AcceptChanges();
                calculaTotal();
                return;
            }

            if (proveedorSeleccionado != null)
            {
                //MessageBox.Show("Seleccione el proveedor de la orden de compra");
                //  proveedorSeleccionado = new SIFNegocio.Clientes().ClientePorID(articulo.PROVEEDOR_ID);
                // return;

                //if (OrdenCompra == null)
                //{
                //    OrdenCompra = this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.NewORDEN_COMPRA_DETRow();
                //   MessageBox.Show("Inicialize la orden de compra");
                //    return;
                //}

                //articulo.PROVEEDOR_ID = OrdenCompra.PROVEEDOR_ID;
                //if (!new SIFNegocio.Usuarios().ListaProveedores(usuario).Contains(articulo.PROVEEDOR_ID.ToString()))
                //{
                //   MessageBox.Show("El usuario no puede agregar artículos de este proveedor");
                //    return;
                //}

                //}
                //else
                //{
                articulo.PROVEEDOR_ID = proveedorSeleccionado.ID;

                articulo.PROVEEDOR_NOMBRE = proveedorSeleccionado.Nombre + " " + proveedorSeleccionado.ApellidoPaterno + " " + proveedorSeleccionado.ApellidoMaterno;
            }
            else
            {
                SIFModelo.Cliente proveedorArticulo = new SIFNegocio.Clientes().ClientePorID(articulo.PROVEEDOR_ID);
                articulo.PROVEEDOR_NOMBRE = proveedorArticulo.Nombre + " " + proveedorArticulo.ApellidoPaterno + " " + proveedorArticulo.ApellidoMaterno;

            }


            SIFModelo.Sucursal sucursal = Helpers.Sesion.Sucursal;
            if (sucursal == null)
            {
                sucursal = Helpers.Sesion.Sucursal;
            }

            SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocdRow = this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.NewORDEN_COMPRA_DETRow();

            if (existente != null)
            {
                ocdRow = existente;
            }
            else
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow row = ocl.GeneraDeEOQArticulo(sucursal, usuario, articulo.ARTICULO_ID);

                if (row != null)
                {
                    if (!ocdRow.Table.Columns.Contains("NOMBRE1"))
                    {
                        ocdRow.Table.Columns.Add("NOMBRE1");
                    }
                    if (!ocdRow.Table.Columns.Contains("COMPRADOR"))
                    {
                        ocdRow.Table.Columns.Add("COMPRADOR");
                    }
                    if (!ocdRow.Table.Columns.Contains("CATEGORIA_INTERNA"))
                    {
                        ocdRow.Table.Columns.Add("CATEGORIA_INTERNA");
                    }
                    if (!ocdRow.Table.Columns.Contains("PORCENTAJE_EOQ"))
                    {
                        ocdRow.Table.Columns.Add("PORCENTAJE_EOQ");
                    }
                    if (!ocdRow.Table.Columns.Contains("USUARIO_ID"))
                    {
                        ocdRow.Table.Columns.Add("USUARIO_ID");
                    }

                    ocdRow["USUARIO_ID"] = row["USUARIO_ID"];
                    ocdRow["PORCENTAJE_EOQ"] = row["PORCENTAJE_EOQ"];
                    ocdRow["CATEGORIA_INTERNA"] = row["CATEGORIA_INTERNA"];
                    ocdRow["COMPRADOR"] = row["COMPRADOR"];
                    ocdRow.ARTICULO_ID = row.ARTICULO_ID;
                    ocdRow.CANT_DEVUELTA = row.CANT_DEVUELTA;
                    ocdRow.CANT_FACTURADA = row.CANT_FACTURADA;
                    ocdRow.CANT_MALESTADO = row.CANT_MALESTADO;
                    ocdRow.CANT_RECIBIDA = row.CANT_RECIBIDA;
                    ocdRow.CANT_REPOSICION = row.CANT_REPOSICION;
                    //cantidad desde el metodo
                    ocdRow.CANT_SOLICITADA = cantidad;
                    ocdRow.CODIGO_PROVEEDOR = row.CODIGO_PROVEEDOR;
                    ocdRow.DESCRIP_OFERTA = row.DESCRIP_OFERTA;
                    ocdRow.DESCTO_FACTURA = row.DESCTO_FACTURA;
                    ocdRow.DESCTO_FACTURA_AD1 = row.DESCTO_FACTURA_AD1;
                    ocdRow.DESCTO_RECIBIDO = row.DESCTO_RECIBIDO;
                    ocdRow.DESCTO_RECIBIDO_AD1 = row.DESCTO_RECIBIDO_AD1;
                    ocdRow.DESCTO_RECIBIDO_AD2 = row.DESCTO_RECIBIDO_AD2;
                    ocdRow.EXISTENCIA_GENERAL = row.EXISTENCIA_GENERAL;
                    ocdRow.EXISTENCIAS = row.EXISTENCIAS;

                    //ocdRow.FOLIO_OC_ID = row.FOLIO_OC_ID;
                    ocdRow.IMPORTE = row.IMPORTE;
                    ocdRow.LABORATORIO_ID = row.LABORATORIO_ID;
                    ocdRow.MEJOR_OFERTA_COSTO = row.MEJOR_OFERTA_COSTO;


                    ocdRow["NOMBRE1"] = row["NOMBRE1"].ToString();
                    ocdRow.NOMBRE = row.NOMBRE;
                    ocdRow.NUM_PARTIDA = row.NUM_PARTIDA;
                    ocdRow.OBSERVACION_OC_DET = row.OBSERVACION_OC_DET;
                    ocdRow.OC_SEGMENTA = row.OC_SEGMENTA;
                    ocdRow.OFERTA_COMPRA_ID = row.OFERTA_COMPRA_ID;
                    ocdRow.OFERTAS = row.OFERTAS;
                    ocdRow.PRECIO_COSTO = row.PRECIO_COSTO;
                    if (row.IsPRECIO_FACTURANull())
                    {
                        row.PRECIO_FACTURA = 0;
                    }
                    ocdRow.PRECIO_FACTURA = row.PRECIO_FACTURA;
                    //precio desde el metodo
                    ocdRow.PRECIO_FARMACIA = precio;
                    ocdRow.PROVEEDOR_ID = row.PROVEEDOR_ID;
                    ocdRow.PUNTO_DE_REORDEN = row.PUNTO_DE_REORDEN;
                    ocdRow.TIPO_MEDICAMENTO_CVE = row.TIPO_MEDICAMENTO_CVE;
                    ocdRow.ULT_PRECIO_COMPRA = row.ULT_PRECIO_COMPRA;
                    ocdRow.USUARIO_ID = row.USUARIO_ID;

                    if (this.proveedorSeleccionado != null)
                    {
                        articulo.PROVEEDOR_ID = proveedorSeleccionado.ID;

                        articulo.PROVEEDOR_NOMBRE = proveedorSeleccionado.Nombre + " " + proveedorSeleccionado.ApellidoPaterno + " " + proveedorSeleccionado.ApellidoMaterno;
                        ocdRow.PROVEEDOR_ID = articulo.PROVEEDOR_ID;
                    }

                }
            }

            if (this.OrdenCompra != null && !this.OrdenCompra.IsFOLIO_OC_IDNull())
            {
                ocdRow.FOLIO_OC_ID = this.OrdenCompra.FOLIO_OC_ID;
            }



            string provID = null;
            if (this.clienteSeleccionado != null)
            {
                provID = clienteSeleccionado.ID.ToString();
            }

            decimal porcentaje_eoq = porcentajeEOQintegerInput.Value;

            if (porcentaje_eoq == 100)
            {
                porcentaje_eoq = 9999999;
            }

            string tipoCompra = esDirecto == true ? "D" : "M";

            int? proveedorID = null;

            if (proveedorSeleccionado != null)
            {
                proveedorID = proveedorSeleccionado.ID;
            }

           

            if (ocdRow.IsCANT_SOLICITADANull())
            {
                ocdRow.CANT_SOLICITADA = 1;
            }

            ocdRow.IMPORTE = ocdRow.CANT_SOLICITADA * ocdRow.PRECIO_FARMACIA;

            SIFModelo.OrdenCompra.InfromacionMayorista mayorista = new SIFNegocio.OrdenCompra.InformacionMayorista().InformacionMayoristaPorArticulo(articulo);

            //Revisamos si existe TRANSFER
            if (mayorista != null)
            {
                if (mayorista.PROVEEDOR_ID != 0 && mayorista.PERIODO_COMPRA_INICIO != null && mayorista.PERIODO_COMPRA_FIN != null)
                {
                    if (mayorista.PERIODO_COMPRA_INICIO.Value <= DateTime.Now && mayorista.PERIODO_COMPRA_FIN >= DateTime.Now)
                    {
                        ocdRow.PROVEEDOR_ID = mayorista.PROVEEDOR_ID;


                        if (mayorista.Bloqueado == SIFModelo.Tipos.SiNo.SI)
                        {
                            ocdRow.Bloqueado = true;
                        }
                        else
                        {
                            ocdRow.OC_SEGMENTA = -1;
                            ocdRow.ES_TRANSFER = "s";
                            // ocdRow.USUARIO_ID = 0;
                        }
                    }
                }
            }

            
            if (mayorista != null && mayorista.Bloqueado != SIFModelo.Tipos.SiNo.SI)
            {

                if (mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR)
                {
                    ocdRow.PROVEEDOR_ID = 99012;
                    ocdRow.DESCTO_RECIBIDO_AD1 = mayorista.DESCTO_ADICIONAL_SABA;

                }
                else if (mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR)
                {
                    ocdRow.PROVEEDOR_ID = 99064;
                    ocdRow.DESCTO_RECIBIDO_AD1 = mayorista.DESCTO_ADICIONAL_NADRO;
                    // break;
                }
                else if (mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR)
                {
                    ocdRow.PROVEEDOR_ID = 99035;
                    ocdRow.DESCTO_RECIBIDO_AD1 = mayorista.DESCTO_ADICIONAL_DROGUEROS;
                    // break;
                }
            }
            else
            {

            //se elimina la parte de descuentos
                ocdRow.DESCTO_RECIBIDO_AD1 = 0;
            }


            if (ocdRow.IsNull("PROVEEDOR_ID"))
            {
                ocdRow.PROVEEDOR_ID = 0;
            }

            if (this.proveedorSeleccionado != null)
            {
                articulo.PROVEEDOR_ID = proveedorSeleccionado.ID;

                articulo.PROVEEDOR_NOMBRE = proveedorSeleccionado.Nombre + " " + proveedorSeleccionado.ApellidoPaterno + " " + proveedorSeleccionado.ApellidoMaterno;
                ocdRow.PROVEEDOR_ID = articulo.PROVEEDOR_ID;
            }
            /*
            List<string> ofertas = ocl.Ofertas(articulo.ARTICULO_ID, Helpers.Sesion.Sucursal.SucursalesID.ToString(), ocdRow.PROVEEDOR_ID);

            //SI EL PROVEEDOR ES IGUAL A 99012 AGREGAR LA OFERTA ESPECIAL


            ocdRow.OFERTAS = ofertas.Count;

            if (ocdRow.OFERTAS >= 1)
            {
                SIFModelo.OrdenCompra.OfertasCompra ocM = new SIFModelo.OrdenCompra.OfertasCompra();

                string[] data = ofertas[0].Split(new char[] { '|' });

                if (data.Length <= 1)
                {
                    //continue;
                }
                else
                {
                    ocM.ProveedorID = int.Parse(data[0]);

                    if (proveedorSeleccionado != null && ocM.ProveedorID == ocdRow.PROVEEDOR_ID)
                    {

                    }

                    //{

                    ocM.Nombre = data[1];
                    ocM.DescuentoOfrecido = decimal.Parse(data[2]);
                    ocM.DescuentoEspecialProveedor = decimal.Parse(data[3]);
                    ocM.PiezasConCargo = int.Parse(data[4]);
                    ocM.PiezasSinCargo = int.Parse(data[5]);

                    // ocM.PrecioCosto = decimal.Parse(data[6]);
                    ocM.PrecioCosto = decimal.Parse(data[7]);
                    if (ocdRow.IsPRECIO_FARMACIANull())
                    {
                        ocdRow.PRECIO_FARMACIA = ocM.PrecioCosto;
                    }

                    ocM.PrecioCosto = ocdRow.PRECIO_FARMACIA;



                    decimal descuentoOfrecido = (ocM.PrecioCosto * (ocM.DescuentoOfrecido / 100m));
                    decimal descuentoAdicional = (descuentoOfrecido * (ocM.DescuentoEspecialProveedor / 100m));

                    ocdRow.DESCTO_RECIBIDO = ocM.DescuentoOfrecido;
                    ocdRow.DESCTO_RECIBIDO_AD1 = ocM.DescuentoEspecialProveedor;
                    ocM.PrecioCosto = ocM.PrecioCosto - descuentoOfrecido - descuentoAdicional;


                    //ocdRow.DESCTO_RECIBIDO_AD2 = 0;

                    ocdRow.IMPORTE = ocdRow.PRECIO_COSTO * ocdRow.CANT_SOLICITADA;
                    ocdRow.MEJOR_OFERTA_COSTO = ocM.PrecioCosto;

                    ocdRow.PRECIO_COSTO = ocM.PrecioCosto;
                    ocdRow.PROVEEDOR_ID = ocM.ProveedorID;

                    if (proveedorSeleccionado != null && ocM.ProveedorID != proveedorSeleccionado.ID)
                    {
                        ocdRow.PROVEEDOR_ID = proveedorSeleccionado.ID;
                    }
                    else
                    {
                        ocdRow.PROVEEDOR_ID = ocM.ProveedorID;
                    }


                    //} 
                }
            }
            else // debe ser igual a                          7501188802866
            {*/
                if (!ocdRow.IsPRECIO_FARMACIANull())
                {
                    ocdRow.PRECIO_COSTO = ocdRow.PRECIO_FARMACIA;
                    ocdRow.IMPORTE = ocdRow.PRECIO_COSTO * ocdRow.CANT_SOLICITADA;

                    ocdRow.MEJOR_OFERTA_COSTO = ocdRow.PRECIO_COSTO;
                }
           // }

            if (existente == null)
            {
                try
                {
                    if (ocdRow.FOLIO_OC_ID == null)
                    {
                        ocdRow.FOLIO_OC_ID = "";
                    }
                }
                catch
                {
                    ocdRow.FOLIO_OC_ID = "";
                }

                if (ocdRow.IsNull("ARTICULO_ID"))
                {
                    ocdRow.ARTICULO_ID = articulo.ARTICULO_ID;
                    ocdRow.CANT_DEVUELTA = 0;
                    ocdRow.CANT_FACTURADA = 0;
                    ocdRow.CANT_MALESTADO = 0;
                    ocdRow.CANT_RECIBIDA = 0;
                    ocdRow.CANT_REPOSICION = 0;
                    ocdRow.PROVEEDOR_ID = articulo.PROVEEDOR_ID;
                    ocdRow.PUNTO_DE_REORDEN = 0;
                    ocdRow.TIPO_MEDICAMENTO_CVE = "";
                    ocdRow.ULT_PRECIO_COMPRA = 0;
                    ocdRow.USUARIO_ID = this.usuario.UsuariosID;
                    ocdRow.DESCRIP_OFERTA = "";
                    ocdRow.DESCTO_RECIBIDO = 0;
                    ocdRow.DESCTO_FACTURA = 0;
                    ocdRow.DESCTO_FACTURA_AD1 = 0;
                    ocdRow.DESCTO_RECIBIDO = 0;
                    ocdRow.DESCTO_RECIBIDO_AD1 = 0;
                    ocdRow.DESCTO_RECIBIDO_AD2 = 0;

                    if (!ocdRow.Table.Columns.Contains("NOMBRE1"))
                    {
                        ocdRow.Table.Columns.Add("NOMBRE1");
                    }
                    ocdRow["NOMBRE1"] = articulo.NOMBRE1;
                    ocdRow.OC_SEGMENTA = 0;

                    if (!ocdRow.Table.Columns.Contains("COMPRADOR"))
                    {
                        ocdRow.Table.Columns.Add("COMPRADOR");
                    }

                    ocdRow["COMPRADOR"] = "POR ASIGNAR";
                    //ocdRow.USUARIO_ID = 0;
                    ocdRow.LABORATORIO_ID = articulo.PROVEEDOR_ID;
                    //ocdRow.
                }


                this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Rows.Add(ocdRow);
            }
            this.superGridControl1.PrimaryGrid.DataSource = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET;


            //if (ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Rows.Count > 0)
            //{
            //    this.almacenComboBoxEx.Enabled = false;
            //}

            decimal descuentoOfrecido2 = (ocdRow.PRECIO_FARMACIA * (ocdRow.DESCTO_RECIBIDO / 100m));
            decimal descuentoAdicional2 = (descuentoOfrecido2 * (ocdRow.DESCTO_RECIBIDO_AD1 / 100m));

            ocdRow.PRECIO_COSTO = ocdRow.PRECIO_FARMACIA - descuentoOfrecido2 - descuentoAdicional2;
            ocdRow.IMPORTE = ocdRow.PRECIO_COSTO * ocdRow.CANT_SOLICITADA;

            if (superGridControl1.PrimaryGrid.LastSelectableRow != null)
            {
                this.superGridControl1.PrimaryGrid.SetActiveRow(superGridControl1.PrimaryGrid.LastSelectableRow);
            }


            //validamos el codigo del proveedor
            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(ocdRow.PROVEEDOR_ID);
            /*
            if (this.esDirecto)
            {
                if (cliente != null)
                {
                    if (cliente.Nombre.Contains("SABA"))
                    {//sacar el codigo de la lista de saba 
                        ocdRow.CODIGO_PROVEEDOR = SIFNegocio.OrdenCompra.Compras.CodigoProveedorSABA(ocdRow);
                    }
                    else
                        if (cliente.Nombre.Contains("NADRO"))
                        {//sacar el codigo de la lista de NADRO 
                            ocdRow.CODIGO_PROVEEDOR = SIFNegocio.OrdenCompra.Compras.CodigoProveedorNADRO(ocdRow);
                        }
                        else
                        {
                            ocdRow.CODIGO_PROVEEDOR = SIFNegocio.OrdenCompra.Compras.CodigoProveedorDROG(ocdRow);
                        }

                }
                else
                {
                    ocdRow.CODIGO_PROVEEDOR = "";
                }
            }
            */
            this.calculaTotal();
            this.CodigoTextBoxX.SelectAll();
            CodigoTextBoxX.Text = articulo.ARTICULO_ID;
            this.cantidadTextBoxX.SelectAll();
            this.cantidadTextBoxX.Focus();

            int transfers = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Count(p => p.PROVEEDOR_ID == 99000);

            this.lineasLabel.Text = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Rows.Count.ToString() + "/T " + transfers.ToString();
        }

        SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow OrdenCompra;

        public void BloqueaCheckbox()
        {
            //bloquea el checkbox para realizar una sola orden de compra
            this.unaSolaCheckBoxX.Checked = true;
            this.unaSolaCheckBoxX.Enabled = false;
        }

        public void TerminaOrdenConAjuste(string folio, string oficio)
        {
            this.CodigoTextBoxX.Clear();
            this.cantidadTextBoxX.Clear();
            this.cantidadTextBoxX.Enabled = false;
            this.CodigoTextBoxX.Enabled = false;
            string comentario = "Folio de ajuste: " + folio + " DOCUMENTO: " + oficio;
            this.observacionesTextBoxX.Text = comentario;
            this.observacionesTextBoxX.Enabled = false;
            this.eliminarButtonItem.Enabled = false;
            this.seleccionaClienteButtonItem.Enabled = false;
            this.nuevoButtonItem.Enabled = false;
            this.agregarArticuloButtonItem.Enabled = false;
            this.directoButtonItem.Enabled = false;
            this.lineaButtonItem.Enabled = false;
            this.importarButtonItem.Enabled = false;
            this.mayoristaButtonItem.Enabled = false;
        }



        public void calculaTotal()
        {
            var vTotalSinDescuento = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Sum(a => (a.IsPRECIO_FARMACIANull() ? 0 : a.PRECIO_FARMACIA) * a.CANT_SOLICITADA);
            if (vTotalSinDescuento.ToString().IsFloat())
            {
                this.totSDlabel.Text = decimal.Parse(vTotalSinDescuento.ToString()).ToString("C2");
            }


            var totalv = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Compute("SUM(IMPORTE)", null);
            if (totalv.ToString().IsFloatPositive())
            {
                this.totalLabel.Text = decimal.Parse(totalv.ToString()).ToString("C2");
            }

            var cantidadV = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Compute("SUM(CANT_SOLICITADA)", null);
            int cantidad = 0;
            if (cantidadV.ToString().IsIntegerPositive())
            {
                cantidad = int.Parse(cantidadV.ToString());
            }

            var descuentov = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Compute("SUM(IMPORTE)", null);

            this.productosLabel.Text = cantidad.ToString();
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
                if (row.Checked || row.IsSelected)
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


                if (OrdenCompra != null && !this.OrdenCompra.IsFOLIO_OC_IDNull())
                {
                    ocl.EliminaDetalle(dtRow);
                }

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

            //if (ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Rows.Count == 0)
            //{
            //    this.almacenComboBoxEx.Enabled = true;
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
            if (OrdenCompra == null)
                OrdenCompra = new SIFModelo.OrdenCompra.OrdenCompraDataSet().ORDEN_COMPRA.NewORDEN_COMPRARow();

            OrdenCompra.USUARIO_ID = usuario.UsuariosID;
            // return;


            if (this.OrdenCompra.IsFOLIO_OC_IDNull())
            {
                //if (proveedorSeleccionado != null)
                //{
                //    //OrdenCompra.PROVEEDOR_ID = this.proveedorSeleccionado.ID;

                //    //foreach (var row in ocl.dsOrdenesCompra.ORDEN_COMPRA_DET)
                //    //{
                //    //    row.PROVEEDOR_ID = OrdenCompra.PROVEEDOR_ID;
                //    //}
                //}
                //else
                //{
                //    foreach (var row in ocl.dsOrdenesCompra.ORDEN_COMPRA_DET)
                //    {
                //        //VALIDAR SI ESTA EN LA LISTA DE PROVEEDORES
                //        //if (!new SIFNegocio.Usuarios().ListaProveedores(usuario).Contains(ORDEN_COMPRA_DET.ID.ToString()))
                //        //{
                //        //   MessageBox.Show("El usuario no puede agregar artículos de este proveedor");
                //        //    return;
                //        //}
                //    }
                //}
               // ocl2.dsOrdenesCompra = ocl.dsOrdenesCompra;
                ocl2 = new SIFNegocio.OrdenCompra.OrdenCompra();
                foreach (var row in ocl.dsOrdenesCompra.ORDEN_COMPRA_DET)
                {
                   
                    SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocdRow = this.ocl2.dsOrdenesCompra.ORDEN_COMPRA_DET.NewORDEN_COMPRA_DETRow();

                    row.FOLIO_OC_ID = "1";
                    if (row.CANT_SOLICITADA > 0)
                    {
                      //  MessageBox.Show("algo algo");
                        ocdRow = row;
                        ocdRow.FOLIO_OC_ID = "1";
                        try
                        {
                            ocl2.dsOrdenesCompra.ORDEN_COMPRA.FOLIO_OC_IDColumn.AllowDBNull = true;
                            ocl2.dsOrdenesCompra.ORDEN_COMPRA_DET.FOLIO_OC_IDColumn.AllowDBNull = true;
                            ocl2.dsOrdenesCompra.ORDEN_COMPRA_DET.ImportRow(ocdRow);
                        }
                        catch(Exception e) {
                            MessageBox.Show("Error: "+ e.ToString());
                            return; }
                       // return;
                    }

                    

                }
                ocl.dsOrdenesCompra = ocl2.dsOrdenesCompra;
                this.calculaTotal();

                foreach (var row in ocl.dsOrdenesCompra.ORDEN_COMPRA_DET)
                {
                    
                    if (row.IsOBSERVACION_OC_DETNull())
                    {
                        row.OBSERVACION_OC_DET = " ";
                    }

                    if (row.IsNull("NOMBRE") || string.IsNullOrEmpty(row.NOMBRE))
                    {
                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(row.ARTICULO_ID);
                        row.NOMBRE = articulo.NOMBRE1;// row["NOMBRE1"].ToString();
                    }

                    if (this.unaSolaCheckBoxX.Checked)
                    {
                        row.USUARIO_ID = this.usuario.UsuariosID;
                    }
                }


                //OrdenCompra.USUARIO_ID = usuario.UsuariosID;
                OrdenCompra.FECHA_ALTA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                OrdenCompra.ESTADO_OC = "A";
                OrdenCompra.OBSERVACION_OC = this.observacionesTextBoxX.Text;

                //GENERAMOS LA ORDEN DE COMPRA POR PRIMERA VEZ
                string folios = ocl.GuardaOrdenCompra(Helpers.Sesion.Sucursal, usuario, OrdenCompra, ocl.dsOrdenesCompra.ORDEN_COMPRA_DET, false, this.unaSolaCheckBoxX.Checked);

                if (!string.IsNullOrEmpty(folios))
                {
                    FoliosGeneradosForm frmFolios = new FoliosGeneradosForm();
                    frmFolios.foliosLabelX.Text = folios;
                    int numfolios = folios.Split(new char[] { '\n' }).Length;
                    frmFolios.foliosGeneradosLabelX.Text = "Folios: " + (numfolios - 1);
                    frmFolios.ShowDialog();
                }
                Back();
            }
            else
            {
                //ACTUALIZAMOS LOS DETALLES Y ELIMINAMOS LOS QUE YA NO SE AGREGARON TAMBIEN EL TOTAL DE LA ORDEN DE COMPRA
                OrdenCompra.OBSERVACION_OC = this.observacionesTextBoxX.Text;
                ocl.ActualizaOrdenCompra(OrdenCompra);
                //this.OrdenCompra

                foreach (DataRow detalle in (((DataTable)this.superGridControl1.PrimaryGrid.DataSource).Rows))
                {
                    if (detalle.RowState == DataRowState.Deleted)
                    {
                        ocl.EliminaDetalle(detalle as SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow);
                        continue;
                    }

                    //if (detalle["OBSERVACION_OC_DET"].ToString().Contains("TRANSFER"))
                    //{
                    //    ocl.EliminaDetalle(detalle as SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow);
                    //    continue;
                    //}

                    if (detalle["ES_TRANSFER"].ToString().Contains("s"))
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

               MessageBox.Show("Se han guardado los datos correctamente");

            }
        }


        public void guardarOrdenAjuste()
        {
           
            if (this.OrdenCompra.IsFOLIO_OC_IDNull())
            {
                
                ocl2 = new SIFNegocio.OrdenCompra.OrdenCompra();
                foreach (var row in ocl.dsOrdenesCompra.ORDEN_COMPRA_DET)
                {

                    SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocdRow = this.ocl2.dsOrdenesCompra.ORDEN_COMPRA_DET.NewORDEN_COMPRA_DETRow();

                    row.FOLIO_OC_ID = "1";
                    if (row.CANT_SOLICITADA > 0)
                    {
                        //  MessageBox.Show("algo algo");
                        ocdRow = row;
                        ocdRow.FOLIO_OC_ID = "1";
                        try
                        {
                            ocl2.dsOrdenesCompra.ORDEN_COMPRA.FOLIO_OC_IDColumn.AllowDBNull = true;
                            ocl2.dsOrdenesCompra.ORDEN_COMPRA_DET.FOLIO_OC_IDColumn.AllowDBNull = true;
                            ocl2.dsOrdenesCompra.ORDEN_COMPRA_DET.ImportRow(ocdRow);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Error: " + e.ToString());
                            return;
                        }
                        // return;
                    }



                }
                ocl.dsOrdenesCompra = ocl2.dsOrdenesCompra;
                this.calculaTotal();

                foreach (var row in ocl.dsOrdenesCompra.ORDEN_COMPRA_DET)
                {

                    if (row.IsOBSERVACION_OC_DETNull())
                    {
                        row.OBSERVACION_OC_DET = " ";
                    }

                    if (row.IsNull("NOMBRE") || string.IsNullOrEmpty(row.NOMBRE))
                    {
                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(row.ARTICULO_ID);
                        row.NOMBRE = articulo.NOMBRE1;// row["NOMBRE1"].ToString();
                    }

                    if (this.unaSolaCheckBoxX.Checked)
                    {
                        row.USUARIO_ID = this.usuario.UsuariosID;
                    }
                }


                //OrdenCompra.USUARIO_ID = usuario.UsuariosID;
                OrdenCompra.FECHA_ALTA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                OrdenCompra.ESTADO_OC = "A";
                OrdenCompra.OBSERVACION_OC = this.observacionesTextBoxX.Text;
                OrdenCompra.FECHA_CIERRE= SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                OrdenCompra.USUARIO_ID_AUTORIZA= this.usuario.UsuariosID.ToString();


                //GENERAMOS LA ORDEN DE COMPRA POR PRIMERA VEZ
                string folios = ocl.GuardaOrdenCompraAjuste(Helpers.Sesion.Sucursal, usuario, OrdenCompra, ocl.dsOrdenesCompra.ORDEN_COMPRA_DET, false, this.unaSolaCheckBoxX.Checked);

                if (!string.IsNullOrEmpty(folios))
                {
                    FoliosGeneradosForm frmFolios = new FoliosGeneradosForm();
                    frmFolios.foliosLabelX.Text = folios;
                    string folio_cerrar = folios;
                    int numfolios = folios.Split(new char[] { '\n' }).Length;
                    frmFolios.foliosGeneradosLabelX.Text = "Folios: " + (numfolios - 1);
                    frmFolios.ShowDialog();
                    SIF.View.OrdenCompra.OrdenesCompraUserControl orden = new SIF.View.OrdenCompra.OrdenesCompraUserControl();
                    //orden.GuardarOrdenCompraAjusteHUP(folio_cerrar);

                    
                    SIFNegocio.OrdenCompra.OrdenCompra OrdenCompraL = new SIFNegocio.OrdenCompra.OrdenCompra();

                    SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow oC =OrdenCompraL.OrdenCompraPoFolio(folios.Replace("\n",""));
                    if (oC.PROVEEDOR_ID.ToString() == "99091")
                    {
                        oC.USUARIO_ID_AUTORIZA = usuario.UsuariosID.ToString();

                        if (oC.ESTADO_OC.Trim() != "A")
                        {
                           MessageBox.Show("La orden de compra debe estar abierta");
                            return;
                        }

                        oC.ESTADO_OC = "C";
                        oC.FECHA_CIERRE = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                        OrdenCompraL.ActualizaOrdenCompra(oC);
                       MessageBox.Show("La orden de compra ha sido cerrada");
                    }


                }
                Back();
                
            

                
               MessageBox.Show("Se han guardado los datos correctamente");

            }

           
        }
        #endregion


        public SIFModelo.Usuario usuario;

        internal void ActivaComandos()
        {
            this.backButton.Shortcuts.Add(eShortcut.F12);
            this.agregarArticuloButtonItem.Shortcuts.Add(eShortcut.F4);
            this.generacionAutomaticaButton.Shortcuts.Add(eShortcut.F9);
            this.eliminarButtonItem.Shortcuts.Add(eShortcut.F8);
            this.guardarButtonItem.Shortcuts.Add(eShortcut.F5);
        }

        internal void DesactivaComandos()
        {
            this.backButton.Shortcuts.Clear();
            this.backButton.Shortcuts.Clear();
            this.agregarArticuloButtonItem.Shortcuts.Clear();
            this.generacionAutomaticaButton.Shortcuts.Clear();
            this.eliminarButtonItem.Shortcuts.Clear();
            this.guardarButtonItem.Shortcuts.Clear();
        }

        SIFNegocio.OrdenCompra.OrdenCompra ocl = new SIFNegocio.OrdenCompra.OrdenCompra();
        SIFNegocio.OrdenCompra.OrdenCompra ocl2 = new SIFNegocio.OrdenCompra.OrdenCompra();
        private string OrdenCompraFolio;
        public void GeneracionAutomatica(bool esGeneral = false)
        {
            if (this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Rows.Count > 0)
            {
                if (MessageBoxEx.Show("¿Se borrarán todas los artículos de la orden de compra, desea continuar?", "Automatica", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            this.superGridControl1.PrimaryGrid.DataSource = null;
            //Boolean conEOQ = false;

            DialogResult res =MessageBox.Show("¿Desea filtrar por EOQ?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);



            this.Cursor = Cursors.WaitCursor;
            SIFModelo.Sucursal sucursal = Helpers.Sesion.Sucursal;
            if (sucursal == null)
            {
                sucursal = Helpers.Sesion.Sucursal;
            }

            string provID = null;
            if (this.clienteSeleccionado != null)
            {
                provID = clienteSeleccionado.ID.ToString();
            }

            decimal porcentaje_eoq = porcentajeEOQintegerInput.Value;

            if (res == DialogResult.No)
            {
                //if (porcentaje_eoq == 100)
                //{
                    porcentaje_eoq = 9999999;
                //}
            }

            string tipoCompra = esDirecto == true ? "D" : "M";

            int? proveedorID = null;

            if (proveedorSeleccionado != null)
            {
                proveedorID = proveedorSeleccionado.ID;
            }
            //se agrega validacion para alerta de compra en productos al crear una orden mayorista CYCM 16/06/2026
            SIFModelo.OrdenCompra.OrdenCompraDataSet dsPedido = ocl.GeneraDeEOQ(sucursal, usuario, porcentaje_eoq, tipoCompra, provID, proveedorID);
            DataTable dtPedidoNuevo = dsPedido.ORDEN_COMPRA_DET;
          
            SIFModelo.OrdenCompra.InfromacionMayorista mayoristaNuevo = new SIFModelo.OrdenCompra.InfromacionMayorista();
            SIFNegocio.OrdenCompra.InformacionMayorista ofLNuevo = new SIFNegocio.OrdenCompra.InformacionMayorista();
            List<SIFModelo.Articulo> ListaAlerta = new List<SIFModelo.Articulo>();

            foreach (DataRow rows in dtPedidoNuevo.Rows)
            {
                SIFModelo.Articulo articuloExistente = new SIFNegocio.Articulo().BuscarPorClave(rows["ARTICULO_ID"].ToString().Trim());
                mayoristaNuevo = ofLNuevo.InformacionMayoristaPorArticulo(articuloExistente);

                if (mayoristaNuevo != null && mayoristaNuevo.alertaAlComprar > 0)
                {
                    ListaAlerta.Add(articuloExistente);
                }
            }

            
            if (ListaAlerta.Count > 0)
            {
                var textoLineas = ListaAlerta.Take(2).Select(p => $"* {p.ARTICULO_ID} -: {p.NOMBRE1}");
                string mensajeFinal = string.Join("\n", textoLineas);

                string pregunta = $"Estos son los productos que tienen alerta de compra:\n\n{mensajeFinal}\n\n¿Desea agregarlos a la compra?";

                DialogResult result = MessageBox.Show(pregunta, "Alerta de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    for (int i = dtPedidoNuevo.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow rows = dtPedidoNuevo.Rows[i];
                        string codigoFila = rows["ARTICULO_ID"].ToString().Trim();

                        bool existeEnListaBorrar = ListaAlerta.Any(m => m.ARTICULO_ID == codigoFila);

                        if (existeEnListaBorrar)
                        {
                            dtPedidoNuevo.Rows.Remove(rows);
                        }
                    }
                }
            }
            this.superGridControl1.PrimaryGrid.DataSource = dtPedidoNuevo;
           //this.superGridControl1.PrimaryGrid.DataSource = ocl.GeneraDeEOQ(sucursal, usuario, porcentaje_eoq, tipoCompra, provID, proveedorID);
            this.superGridControl1.PrimaryGrid.DataMember = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.TableName;

            if (ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Rows.Count == 0)
            {
               MessageBox.Show("No se encontraron artículos por debajo del EOQ");
            }
            
            this.Cursor = DefaultCursor;
            this.calculaTotal();

            int transfers = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Count(p => p.PROVEEDOR_ID == 99000);

            this.lineasLabel.Text = ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Rows.Count.ToString() + "/T " + transfers.ToString();

            // this.AgregaOfertas();
           
        }

        internal void Muestra()
        {
            if (Owner is SIF.View.OrdenCompra.OrdenesCompraUserControl)
            {
                //MessageBox.Show("Entro a la condicion");
                OrdenesCompraUserControl propietario = Owner as OrdenesCompraUserControl;
                propietario.DesactivaComandos();

                if (propietario.Owner is Menu.ComprasMenu)
                {
                    Menu.ComprasMenu propietarioOwnerOwner = propietario.Owner as Menu.ComprasMenu;
                    ((Menu.ComprasMenu)propietario.Owner).Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }

                if (propietario.Owner is SIF.View.OrdenCompra.OrdenesCompraUserControl)
                {
                    SIF.View.OrdenCompra.OrdenesCompraUserControl propietarioOwner = propietario.Owner as SIF.View.OrdenCompra.OrdenesCompraUserControl;
                    Menu.ComprasMenu propietarioOwnerOwner = propietarioOwner.Owner as Menu.ComprasMenu;
                    ((Menu.ComprasMenu)propietario.Owner).Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }

                this.ActivaComandos();
                this.Dock = DockStyle.Fill;
                this.Mostrado = true;
            }

            else
            {
                if (MessageBox.Show("Desea visualizar colores", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    _pintarow = true;
                }
                if (Owner is View.Menu.ComprasMenu)
                {
                    View.Menu.ComprasMenu propietario = Owner as View.Menu.ComprasMenu;
                    propietario.DesactivaComandos();
                    propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.ActivaComandos();
                    this.Dock = DockStyle.Fill;
                    this.Mostrado = true;
                }

                if (Owner is View.OrdenCompra.OrdenesCompraUserControl)
                {
                    OrdenesCompraUserControl propietario = Owner as OrdenesCompraUserControl;
                    propietario.DesactivaComandos();

                    if (propietario.Owner is Menu.ComprasMenu)
                    {
                        Menu.ComprasMenu propietarioOwnerOwner = propietario.Owner as Menu.ComprasMenu;
                        ((Menu.ComprasMenu)propietario.Owner).Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }

                    if (propietario.Owner is SIF.View.OrdenCompra.OrdenesCompraUserControl)
                    {
                        SIF.View.OrdenCompra.OrdenesCompraUserControl propietarioOwner = propietario.Owner as SIF.View.OrdenCompra.OrdenesCompraUserControl;
                        Menu.ComprasMenu propietarioOwnerOwner = propietarioOwner.Owner as Menu.ComprasMenu;
                        ((Menu.ComprasMenu)propietario.Owner).Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }

                    this.ActivaComandos();
                    this.Dock = DockStyle.Fill;
                    this.Mostrado = true;
                }

                if (Owner is View.OrdenCompra.RecepcionOrdenCompraUserControl)
                {
                    View.OrdenCompra.RecepcionOrdenCompraUserControl propietario = Owner as View.OrdenCompra.RecepcionOrdenCompraUserControl;
                    propietario.DesactivaComandos();
                    propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.ActivaComandos();
                    this.Dock = DockStyle.Fill;
                    this.Mostrado = true;
                }

                this.CodigoTextBoxX.Focus();
                if (string.IsNullOrEmpty(OrdenCompraFolio))
                {
                    DialogResult res =MessageBox.Show("¿Desea elegir a una linea para toda la orden de compra?", "Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        this.SeleccionaCliente();
                    }
                }
            }
        }

        private void Back()
        {
            try
            {
                _pintarow = false;
                if (Owner is View.Menu.ComprasMenu)
                {
                    View.Menu.ComprasMenu propietario = Owner as View.Menu.ComprasMenu;
                    if (propietario.Owner.IsModalPanelDisplayed)
                    {
                        if (propietario.Owner.Contains(this))
                        {
                            propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        propietario.ActivaComandos();
                        this.Mostrado = false;
                        this.DesactivaComandos();
                    }
                }

                if (Owner is View.OrdenCompra.OrdenesCompraUserControl)
                {
                    OrdenesCompraUserControl propietario = Owner as OrdenesCompraUserControl;

                    if (propietario.Owner is Menu.ComprasMenu)
                    {
                        Menu.ComprasMenu propietarioOwnerOwner = propietario.Owner as Menu.ComprasMenu;

                        if (propietarioOwnerOwner.Owner.IsModalPanelDisplayed)
                        {
                            if (propietarioOwnerOwner.Owner.Contains(this))
                            {
                                propietarioOwnerOwner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                            }

                            propietario.ActivaComandos();
                            propietario.Buscar();
                            this.Mostrado = false;
                            this.DesactivaComandos();
                        }
                    }
                }

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

            }
            catch { }
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
                detalleN.USUARIO_ID = OrdenCompra.USUARIO_ID;

                dtOC.AddORDEN_COMPRA_DETRow(detalleN);
            }


            SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow ocr = new SIFModelo.OrdenCompra.OrdenCompraDataSet().ORDEN_COMPRA.NewORDEN_COMPRARow();

            ocr.USUARIO_ID = OrdenCompra.USUARIO_ID;
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
                if (this.CodigoTextBoxX.Text.ToUpper() == "NUEVO")
                {
                    this.nuevoButtonItem_Click(null, null);
                    return;
                }
                this.AgregaArticulo(this.CodigoTextBoxX.Text);
            }
        }

        public void AgregaArticulosAjuste(string articuloClave, int cantidad, decimal precio,string nombre)
        {
            //se realiza la validacion del codigo y se inserte en el grid
            //this.cantidadTextBoxX.Text = cantidad.ToString();
            this.AgregaArticuloAjusteCodigo(articuloClave,cantidad,precio,nombre);
          
        }

        private void superGridControl1_EndEdit(object sender, DevComponents.DotNetBar.SuperGrid.GridEditEventArgs e)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow oc = ((DataRowView)e.GridCell.GridRow.DataItem).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow;
            
            GridRow row = e.GridCell.GridRow;
            //if (e.GridCell.GridColumn.DataPropertyName == "CANT_SOLICITADA")
            //{

            //}

            if (oc.IsCANT_SOLICITADANull())
            {
                oc.IMPORTE = 0;
            }
            else
            {
                oc.IMPORTE = (decimal)((decimal)oc.CANT_SOLICITADA * oc.PRECIO_COSTO);
                row.Cells["IMPORTEColumn"].Value = oc.IMPORTE;
            }


            if (e.GridCell.GridColumn.DataPropertyName == "PRECIO_FARMACIA" || e.GridCell.GridColumn.DataPropertyName == "DESCTO_RECIBIDO" || e.GridCell.GridColumn.DataPropertyName == "DESCTO_RECIBIDO_AD1")
            {

                decimal descuentoOfrecido = (oc.PRECIO_FARMACIA * (oc.DESCTO_RECIBIDO / 100m));
                decimal descuentoAdicional = (descuentoOfrecido * (oc.DESCTO_RECIBIDO_AD1 / 100m));

                oc.PRECIO_COSTO = oc.PRECIO_FARMACIA - descuentoOfrecido - descuentoAdicional;
                row.Cells["PRECIO_COSTOColumn"].Value = oc.PRECIO_COSTO;
                oc.IMPORTE = oc.PRECIO_COSTO * oc.CANT_SOLICITADA;
                row.Cells["IMPORTEColumn"].Value = oc.IMPORTE;
            }



            this.calculaTotal();
            //this.superGridControl1.PrimaryGrid.InvalidateRender();


        }

        View.OrdenCompra.ProveedoresControl frmProveedor;
        private void SeleccionaProveedor()
        {
            if (frmProveedor == null)
            {
                frmProveedor = new View.OrdenCompra.ProveedoresControl();
                frmProveedor.Dock = DockStyle.Fill;
                frmProveedor.Owner = this;
            }
            string listaProveedores = new SIFNegocio.Usuarios().ListaProveedores(usuario);


            //string listaLineas = new SIFNegocio.Compradores()
            frmProveedor.ListaProveedores = listaProveedores.Trim('|');
            frmProveedor.Muestra();
        }

        View.OrdenCompra.LaboratoriosControl frmCliente;
        private void SeleccionaCliente()
        {
            if (frmCliente == null)
            {
                frmCliente = new View.OrdenCompra.LaboratoriosControl();
                frmCliente.Dock = DockStyle.Fill;
                frmCliente.Owner = this;
            }

            SIFModelo.Seguridad.Seguridad seguridad = new SIFModelo.Seguridad.Seguridad();
            SIFModelo.Seguridad.SeguridadTableAdapters.COMPRADOR_LINEATableAdapter cOMPRADOR_LINEATableAdapter = new SIFModelo.Seguridad.SeguridadTableAdapters.COMPRADOR_LINEATableAdapter();

            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(SIFNegocio.Configuracion.Configuraciones.ReadDataBase());
          //  cOMPRADOR_LINEATableAdapter.Connection = new Oracle.DataAccess.Client.OracleConnection(SIFNegocio.Configuracion.Configuraciones.ReadDataBase());
            cOMPRADOR_LINEATableAdapter.Connection = conn;
            cOMPRADOR_LINEATableAdapter.FillByComprador(seguridad.COMPRADOR_LINEA,usuario.UsuariosID.ToString());

            string listaProveedores = "";
            foreach (var linea in seguridad.COMPRADOR_LINEA)
            {
                listaProveedores += linea.LINEA + "|";
            }

            //string listaLineas = new SIFNegocio.Compradores()
            frmCliente.ListaProveedores = listaProveedores.Trim('|');
            frmCliente.Muestra();
        }

        SIFModelo.Cliente proveedorSeleccionado = null;
        internal void AgregaProveedor(SIFModelo.Cliente cliente)
        {
            if (cliente.Activo == SIFModelo.Tipos.SiNo.NO)
            {
               MessageBox.Show("El proveedor ya no está activo");
                return;
            }
            if (cliente.Boletinado == SIFModelo.Tipos.SiNo.SI)
            {
               MessageBox.Show("El proveedor está boletinado");
                return;
            }

            //SIFModelo.Seguridad.Seguridad seguridad = new SIFModelo.Seguridad.Seguridad();
            //SIFModelo.Seguridad.SeguridadTableAdapters.COMPRADOR_LINEATableAdapter cOMPRADOR_LINEATableAdapter = new SIFModelo.Seguridad.SeguridadTableAdapters.COMPRADOR_LINEATableAdapter();

            //cOMPRADOR_LINEATableAdapter.Connection = new Oracle.DataAccess.Client.OracleConnection(SIFNegocio.Configuracion.Configuraciones.ReadDataBase());
            //cOMPRADOR_LINEATableAdapter.FillByComprador(seguridad.COMPRADOR_LINEA, usuario.UsuariosID.ToString());

            SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow comprador = new SIFModelo.Catalogo.CatalogoDataSet().COMPRADOR.NewCOMPRADORRow();
            comprador.USUARIO_ID = usuario.UsuariosID.ToString();

            comprador = new SIFNegocio.Compradores().CompradorPorID(comprador);

            if (!comprador.LISTA_PROVEEDOR_ID.Contains(cliente.ID.ToString()))
            {
               MessageBox.Show("El usuario no puede comprar a de este proveedor");
                return;
            }

            proveedorSeleccionado = cliente;

            this.proveedorLabel.Text = proveedorSeleccionado.ID.ToString() + " - " + proveedorSeleccionado.Nombre + " " + proveedorSeleccionado.ApellidoPaterno + " " + proveedorSeleccionado.ApellidoMaterno;

            foreach (var item in this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET)
            {
                item.PROVEEDOR_ID = proveedorSeleccionado.ID;
            }

            if (OrdenCompra == null)
            {
                this.OrdenCompra = new SIFModelo.OrdenCompra.OrdenCompraDataSet().ORDEN_COMPRA.NewORDEN_COMPRARow();

                // SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETDataTable tabla = new SIFNegocio.OrdenCompra.OrdenCompra().OrdenCompraDetallesPorFolio(ocl).ORDEN_COMPRA_DET;

                if (!this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Contains("NOMBRE1"))
                {
                    this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Add("NOMBRE1");
                }
                if (!this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Contains("COMPRADOR"))
                {
                    this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Add("COMPRADOR");
                }
                if (!this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Contains("CATEGORIA_INTERNA"))
                {
                    this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Add("CATEGORIA_INTERNA");
                }
                if (!this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Contains("PORCENTAJE_EOQ"))
                {
                    this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Add("PORCENTAJE_EOQ");
                }
                if (!this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Contains("USUARIO_ID"))
                {
                    this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Add("USUARIO_ID");
                }

            }

            this.OrdenCompra.PROVEEDOR_ID = proveedorSeleccionado.ID;

            SIFModelo.DireccionCliente dirCliente = new SIFNegocio.Clientes().DireccionCliente(proveedorSeleccionado);
            this.CodigoTextBoxX.Focus();
        }

        SIFModelo.Cliente clienteSeleccionado = null;
        internal void AgregaCliente(SIFModelo.Cliente cliente)
        {
            if (cliente.Activo == SIFModelo.Tipos.SiNo.NO)
            {
               MessageBox.Show("El proveedor ya no está activo");
                return;
            }
            if (cliente.Boletinado == SIFModelo.Tipos.SiNo.SI)
            {
               MessageBox.Show("El proveedor está boletinado");
                return;
            }

            SIFModelo.Seguridad.Seguridad seguridad = new SIFModelo.Seguridad.Seguridad();
            SIFModelo.Seguridad.SeguridadTableAdapters.COMPRADOR_LINEATableAdapter cOMPRADOR_LINEATableAdapter = new SIFModelo.Seguridad.SeguridadTableAdapters.COMPRADOR_LINEATableAdapter();

            cOMPRADOR_LINEATableAdapter.Connection = new Oracle.DataAccess.Client.OracleConnection(SIFNegocio.Configuracion.Configuraciones.ReadDataBase());
            cOMPRADOR_LINEATableAdapter.FillByComprador(seguridad.COMPRADOR_LINEA, usuario.UsuariosID.ToString());

            string listaProveedores = "";
            foreach (var linea in seguridad.COMPRADOR_LINEA)
            {
                listaProveedores += linea.LINEA + "|";
            }

            //if (!listaProveedores.Contains(cliente.ID.ToString()))
            //{
            //   MessageBox.Show("El usuario no puede comprar a de este proveedor");
            //    return;
            //}



            clienteSeleccionado = cliente;




            this.lineaLabel.Text = cliente.ID.ToString() + " - " + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;

            SIFModelo.DireccionCliente dirCliente = new SIFNegocio.Clientes().DireccionCliente(cliente);
            this.CodigoTextBoxX.Focus();
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

        private void generacionAutomaticaButton_Click(object sender, EventArgs e)
        {
            if (!this.mayoristaButtonItem.ShowSubItems)
            {
                this.mayoristaButtonItem.ShowSubItems = true;
            }
        }

        private void InicializaEstilosFilas()
        {
            WarningCellStyle.Background.Color1 = Color.FromArgb(255, 221, 227);
            WarningCellStyle.Background.Color2 = Color.FromArgb(255, 221, 227);

            TransferBloqueadoCellStyle.Background.Color1 = Color.FromArgb(141, 179, 226);
            TransferBloqueadoCellStyle.Background.Color2 = Color.FromArgb(141, 179, 226);
            //WarningCellStyle.BorderColor.se

            TransferCellStyle.Background.Color1 = Color.FromArgb(200, 100, 100);
            TransferCellStyle.Background.Color2 = Color.FromArgb(200, 100, 100);

            hUPCellStyle.Background.Color1 = Color.FromArgb(93, 173, 226);
            hUPCellStyle.Background.Color2 = Color.FromArgb(93, 173, 226);
        }

        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle WarningCellStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle NormalCellStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle TransferBloqueadoCellStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle TransferCellStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle hUPCellStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;

        private void superGridControl1_PostRenderRow(object sender, GridPostRenderRowEventArgs e)
        {
            if (!_pintarow)
                return;
            SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow row = ((DataRowView)(((GridRow)e.GridRow).DataItem)).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow;
            GridRow gr = (GridRow)e.GridRow;
            if (row.OC_SEGMENTA == -1 || row.PROVEEDOR_ID == 99000)
            {

                //Debug.Assert(row.ES_TRANSFER == "s");

                if (!row.Bloqueado)
                {
                    e.GridRow.CellStyles.Default = TransferCellStyle;
                    e.GridRow.RowStyles.Default.ApplyStyle(TransferCellStyle);

                    // GridRow gr = (GridRow)e.GridRow;
                    // gr.Cells["PROVEEDOR_IDColumn"].ReadOnly = true;
                    //color rojo
                    return;
                }

            }

            if (row.Bloqueado)
            {

                gr.Cells["PROVEEDOR_IDColumn"].ReadOnly = true;

                //color azul
                e.GridRow.CellStyles.Default = TransferBloqueadoCellStyle;
                e.GridRow.RowStyles.Default.ApplyStyle(TransferBloqueadoCellStyle);

                return;
            }

            gr.Cells["PROVEEDOR_IDColumn"].ReadOnly = false;
            //COLOCAR LA FILA EN COLOR AMARILLO
            if (row.IsMEJOR_OFERTA_COSTONull())
            {
                return;
            }
            if (row.PRECIO_COSTO > row.MEJOR_OFERTA_COSTO)
            {
                e.GridRow.CellStyles.Default = WarningCellStyle;
                e.GridRow.RowStyles.Default.ApplyStyle(WarningCellStyle);

            }
            else
            {
                e.GridRow.CellStyles.Default = NormalCellStyle;
                e.GridRow.RowStyles.Default.ApplyStyle(NormalCellStyle);
            }
            //if (_Sna.bucaSiEsArticuloHup(gr.Cells["ARTICULO_IDColumn"].Value.ToString())) {

            if (row.CODIGO_PROVEEDOR != "0") {
                e.GridRow.CellStyles.Default = hUPCellStyle;
                e.GridRow.RowStyles.Default.ApplyStyle(hUPCellStyle);
            }

            if (superGridControl1.ActiveRow.Index == e.GridRow.Index)
            {
                return;
            }

        }

        private void OrdenCompraUserControl_Load(object sender, EventArgs e)
        {
            usuarioLabel.Text = usuario.Nombre + " " + usuario.Apellidos;
            this.superGridControl1.PrimaryGrid.SelectionGranularity = SelectionGranularity.Cell;
        }

        private void almacenComboBoxEx_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (almacenComboBoxEx.SelectedValue != null)
            //{
            SIFModelo.Sucursal sucursal = Helpers.Sesion.Sucursal;
            //this.direccionalmacenLabel.Text = sucursal.Calle + " " + sucursal.NumeroExterior + " " + sucursal.NumeroInterior + " " + sucursal.Colonia + " " + sucursal.Ciudad;
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

            if (OrdenCompra == null)
            {
                return;
            }
            if (OrdenCompra.IsNull("ESTADO_OC"))
            {
                OrdenCompra.ESTADO_OC = "A";
            }
            if (OrdenCompra.ESTADO_OC.Trim() != "A")
            {
                return;
            }
            if (e.KeyCode == Keys.Delete)
            {
                this.Eliminar();
                e.Handled = true;
            }

  
        }

        private void seleccionaClienteButtonItem_Click(object sender, EventArgs e)
        {
            SeleccionaProveedor();
        }

        private void superGridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            GridRow row = this.superGridControl1.ActiveRow as GridRow;

            if (row == null)
            { return; }

            if (e.KeyCode == Keys.Enter)
            {

                int columna = superGridControl1.ActiveCell.ColumnIndex;
                if (superGridControl1.PrimaryGrid.LastSelectableRow == null)
                {
                    return;
                }

                if (row.RowIndex < superGridControl1.PrimaryGrid.LastSelectableRow.RowIndex)
                {
                    //var celda = row.GetCell(columna);
                    //if (celda.GridRow == (superGridControl1.ActiveRow))
                    //{
                    //    return;
                    //}
                    row.GetCell(columna).BeginEdit(true);
                }



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
                    row.GetCell(columna).BeginEdit(true);
                }
            }
        }

        private void generalButtonItem_Click(object sender, EventArgs e)
        {
            GeneracionAutomatica(true);
        }

        private void lineaButtonItem_Click(object sender, EventArgs e)
        {
            SeleccionaCliente();
        }

        private void mayoristaButtonItem_Click(object sender, EventArgs e)
        {
            esDirecto = false;
            this.GeneracionAutomatica();
            
        }

        private void directoButtonItem_Click(object sender, EventArgs e)
        {
            esDirecto = true;
            this.GeneracionAutomatica();
        }

        public void nuevoButtonItem_Click(object sender, EventArgs e)
        {
            SIFModelo.Articulo Articulo = new SIFModelo.Articulo();
            Articulo.ARTICULO_ID = DateTime.Now.ToString("yyyyMMddHHmmss");
            Articulo.TIPO_MEDICAMENTO_CVE = "";
            Articulo.ACTIVO = SIFModelo.Tipos.SiNo.SI;

            if (this.clienteSeleccionado != null)
            {
                Articulo.LABORATORIO_ID = clienteSeleccionado.ID;
            }

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

                if (proveedorSeleccionado != null)
                {
                    Articulo.PROVEEDOR_ID = this.proveedorSeleccionado.ID;
                }
                else
                {
                    Articulo.PROVEEDOR_ID = 99012;
                }

                //this.AgregaArticulo(Articulo);.

                SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocdRow = this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.NewORDEN_COMPRA_DETRow();
                ocdRow.ARTICULO_ID = Articulo.ARTICULO_ID;
                ocdRow.PROVEEDOR_ID = Articulo.PROVEEDOR_ID;
                ocdRow.NOMBRE = Articulo.NOMBRE1;
                if (!ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Contains("NOMBRE1"))
                { ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.Columns.Add("NOMBRE1"); }
                ocdRow["NOMBRE1"] = Articulo.NOMBRE1;
                ocdRow.OC_SEGMENTA = 0;
                ocdRow.PRECIO_FARMACIA = decimal.Parse(frmArticulo.costoTextBoxX.Text);
                ocdRow.FOLIO_OC_ID = "";
                ocdRow.DESCRIP_OFERTA = "";
                ocdRow.ULT_PRECIO_COMPRA = 0;
                ocdRow.CANT_DEVUELTA = 0;
                ocdRow.USUARIO_ID = this.usuario.UsuariosID;

                ocdRow.PRECIO_COSTO = ocdRow.PRECIO_FARMACIA;
                if (this.clienteSeleccionado != null)
                {
                    ocdRow.LABORATORIO_ID = clienteSeleccionado.ID;
                }
                else
                {
                    ocdRow.LABORATORIO_ID = 0;
                }

                ocdRow.CANT_FACTURADA = 0;
                ocdRow.CANT_MALESTADO = 0;
                ocdRow.CANT_RECIBIDA = 0;
                ocdRow.CANT_REPOSICION = 0;
                ocdRow.CANT_SOLICITADA = Convert.ToInt32(this.cantidadTextBoxX.Text);
                ocdRow.DESCTO_RECIBIDO = 0;
                ocdRow.CODIGO_PROVEEDOR = "";
                ocdRow.DESCTO_FACTURA = 0;
                ocdRow.DESCTO_FACTURA_AD1 = 0;
                ocdRow.DESCTO_RECIBIDO = 0;
                ocdRow.DESCTO_RECIBIDO_AD1 = 0;
                ocdRow.DESCTO_RECIBIDO_AD2 = 0;
                ocdRow.EXISTENCIA_GENERAL = 0;
                ocdRow.EXISTENCIAS = 0;
                ocdRow.FOLIO_OC_ID = "";
                ocdRow.IMPORTE = 0;
                ocdRow.MEJOR_OFERTA_COSTO = ocdRow.PRECIO_FARMACIA;
                ocdRow.OBSERVACION_OC_DET = "";
                ocdRow.OC_SEGMENTA = 0;
                ocdRow.OFERTA_COMPRA_ID = 0;
                ocdRow.OFERTAS = 0;
                ocdRow.PUNTO_DE_REORDEN = 0;
                ocdRow.ULT_PRECIO_COMPRA = 0;
                ocdRow.TIPO_MEDICAMENTO_CVE = "";



                ocl.dsOrdenesCompra.ORDEN_COMPRA_DET.AddORDEN_COMPRA_DETRow(ocdRow);

                superGridControl1.PrimaryGrid.DataSource = this.ocl.dsOrdenesCompra.ORDEN_COMPRA_DET;
            }
        }

        
        private void importarButtonItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La opcion importar te permite agreagar articulos desde un archivo delimitado por Por comas con Extencion Csv." +
                Environment.NewLine + "El archivo esta basado en 2 columnas" +
                Environment.NewLine + "Codigo > correcponde al codigo del producto este codigo tiene que estar dado de alta en el Cdis" +
                Environment.NewLine + "Cantidad > corresponde a la cantidad que se incluira en el pedido",
                "Informacion",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.importarFile();
        }

        private void importarFile() {
            SIFNegocio.Articulo art = new SIFNegocio.Articulo();
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Seleccione el archivo a Procesar";
            fdlg.Filter = "CSV files (*.CSV)|*.csv";
            fdlg.RestoreDirectory = true;
            bool FmtValid = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                SIFNegocio.Subrogacion.Factura insr = new SIFNegocio.Subrogacion.Factura();
                DataTable dtPedido = new DataTable();
                dtPedido.Columns.Add("clave", typeof(string));         //Corresponde al codigo del Articulo
                dtPedido.Columns.Add("cantidad", typeof(Decimal));      //Corresponde a la Catnidad a pedir
                
                StreamReader reader = StreamReader.Null;
                string str = null;
                int Regs = 0;
                string FName = fdlg.SafeFileName;
                string FPath = Path.GetDirectoryName(fdlg.FileName);
                string FExt = Path.GetExtension(FName);
                Regex objNotNumPattern = new Regex(@"[^\d+$]");
                Regex objNotAlphaPattern = new Regex(@"[^a-zA-Z0-9\s]");
                try
                {
                    // Valida formato de archivo
                    reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
                    List<String> listaInex = new List<string>();
                    while ((str = reader.ReadLine()) != null)
                    {
                        int x = str.Split(',').Count();
                        if (x != 2)
                        {
                            FmtValid = false;
                           MessageBox.Show("El formato de Archivo " + FName + " es Invalido");
                            break;
                        }
                        string codigo = str.Split(',')[0];

                        SIFModelo.Articulo Exs = art.BuscarPorClave(codigo);
                        if (Exs == null)
                        {
                            listaInex.Add(codigo);
                        }
                        // Valida cantidad
                        if (objNotNumPattern.IsMatch(str.Split(',')[1]))
                        {
                            FmtValid = false;
                            MessageBox.Show("La cantidad  \"" + str.Split(',')[1].ToString() + "\" del codigo: "+ str.Split(',')[0].ToString() + " a pedir no es Valida");
                            break;
                        }
                        if (Convert.ToInt32(str.Split(',')[1])<= 0){
                            MessageBox.Show("La cantidad a pedir del codigo "+ str.Split(',')[0].ToString() + " debe de ser mayor a 1 ");
                            break;
                        }

                    }

                    if (listaInex.Count > 0)
                    {
                        string msg = string.Empty;
                        msg += "No existen los codigos:" + Environment.NewLine;
                        foreach (string s in listaInex)
                        {
                            msg += s.ToString() + Environment.NewLine;
                        }
                        MessageBox.Show(msg);
                        return;
                    }
                    
                    foreach (string item in listaInex)
                    {
                        Console.WriteLine(item);
                    }

                    // Lee archivo
                    string Result = "";
                    if (FmtValid)
                    {
                        reader.Close();
                        reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
                        while ((str = reader.ReadLine()) != null)
                        {

                            dtPedido.Rows.Add(str.Split(',')[0],
                                              str.Split(',')[1]
                                              );

                            Regs++;
                        }

                        DataRow[] results = dtPedido.Select(null, "clave");



                        //recorre cada articulo y valida las reglas;
                        foreach (DataRow rows in results)
                        {
                            String articulo = rows["clave"].ToString().Trim();
                            SIFNegocio.Articulo ArtNegocio = new SIFNegocio.Articulo();
                            SIFModelo.Articulo articuloM = new SIFModelo.Articulo();
                            articuloM.ARTICULO_ID = articulo;
                            SIFModelo.Inventarios.Inventario InventarioArt = ArtNegocio.InventarioPorArticulo(articuloM);
                            if (InventarioArt == null)
                            {
                                MessageBox.Show("EL ARTICULO NO EXISTE EN EL CATÁLOGO: " +
                                       articulo + ", VERIFIQUE EL ARCHIVO.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                return;
                            }

                        }
                        ///


                       /* String[] Clave = new String[results.Length];
                        String[] Cantidad = new String[results.Length];
                        int ind = 0;

                        foreach (DataRow rows in dtPedido.Rows)
                        {
                            Clave[ind] = rows["clave"].ToString().Trim();
                            Cantidad[ind] = rows["cantidad"].ToString().Trim();                           
                            ind++;
                        }*/

                        
                        fileImp = true;
                        //se agrega validacion para alerta de productos al cargar un achivo csv CYCM 16/06/2026
                        SIFModelo.OrdenCompra.InfromacionMayorista mayorista = new SIFModelo.OrdenCompra.InfromacionMayorista();
                        SIFNegocio.OrdenCompra.InformacionMayorista ofL = new SIFNegocio.OrdenCompra.InformacionMayorista();
                        List<SIFModelo.Articulo> ListaAlerta  = new List<SIFModelo.Articulo>();
                        foreach (DataRow rows in dtPedido.Rows)
                        {
                            //SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
                            SIFModelo.Articulo articuloExistente = new SIFNegocio.Articulo().BuscarPorClave(rows["clave"].ToString().Trim());
                            mayorista = ofL.InformacionMayoristaPorArticulo(articuloExistente);
                            if (mayorista.alertaAlComprar > 0)
                            {
                                ListaAlerta.Add(articuloExistente);
                            }

                        }
                        if (ListaAlerta.Count > 0)
                        {
                            var textoLineas = ListaAlerta.Take(2).Select(p => $"* {p.ARTICULO_ID} -: {p.NOMBRE1}");
                            string mensajeFinal = string.Join("\n", textoLineas);
                            string pregunta = $"Estos son los productos que tienen alerta de compra:\n\n{mensajeFinal}\n\n¿Desea agregarlos a la compra?";
                            DialogResult result = MessageBox.Show(pregunta, "Alerta de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.No)
                            {
                                for (int i = dtPedido.Rows.Count - 1; i >= 0; i--)
                                {
                                    DataRow rows = dtPedido.Rows[i];
                                    string codigoFila = rows["clave"].ToString().Trim();

                                    // Verificamos si esta fila está en la lista de alertas
                                    bool existeEnListaBorrar = ListaAlerta.Any(m => m.ARTICULO_ID == codigoFila);

                                    if (existeEnListaBorrar)
                                    {
                                        // Eliminamos la fila de forma 100% segura
                                        dtPedido.Rows.Remove(rows);
                                    }
                                }

                                //foreach (DataRow rows in dtPedido.Rows)
                                //{
                                //    string codigoFila = rows["clave"].ToString().Trim();

                                //    bool existeEnListaBorrar = ListaAlerta.Any(m => m.ARTICULO_ID == codigoFila);
                                //    if (existeEnListaBorrar)
                                //    {
                                //        rows.Table.Rows.Remove(rows);
                                //    }
                                //}
                            }
                            
                        }
                        
                        foreach (DataRow rows in dtPedido.Rows)
                        {
                            this.cantidadTextBoxX.Text = rows["cantidad"].ToString().Trim(); 
                            this.AgregaArticulo(rows["clave"].ToString().Trim(),true);
                            
                            
                        }
                        MessageBox.Show("oK");                        
                        fileImp = false;



                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    fileImp = false;
                }
                finally
                {
                    reader.Close();
                }

            }

        }

        private static List<String> productosNoValidos()
        {
            List<String> claves = new SIFNegocio.Articulo().clavesNoValidas();

            return claves;
        }



    }
}
