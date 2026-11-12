using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Equin.ApplicationFramework;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace SIF.View.OrdenCompra
{
    public partial class OrdenesCompraUserControl : Templates.ListaUserControl
    {
        SIFModelo.Usuario Usermod;
        BindingList<SIFModelo.Sucursal> sucursales = new BindingList<SIFModelo.Sucursal>();
        public OrdenesCompraUserControl()
        {
            InitializeComponent();
            this.inicializaTabla();
            OcultaBoton();
            estadosOrdenesCompra();
            Privilegios();
            CargaSucursalDestino();
            //Buscar();
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 13, int.Parse(Xbtn.Tag.ToString()));
            }

        }
        private void OcultaBoton()
        {
            if (Helpers.Sesion.Usuario.TipoUsuario != SIFModelo.Tipos.TipoUsuario.ADMINISTRATIVO && Helpers.Sesion.Usuario.TipoUsuario != SIFModelo.Tipos.TipoUsuario.VENDENDOR)
            {
                devolucionProveButtonItem.Visible = false;
                reposicionProveButtonItem.Visible = false;
                cambiarProveButtonItem.Visible = false;
                eliminarButtonItem.Visible = false;
                editarButtonItem.Visible = false;
                cerrarButtonItem.Visible = false;
                facturaButtonItem.Visible = false;
                unirButtonItem.Visible = false;
                dividirButtonItem.Visible = false;
                cuentasPorPagarbuttonItem.Visible = false;
                recibirButtonItem.Visible = false;
                preciosButtonItem.Visible = false;
                facturaAutomaticaButtonItem.Visible = false;
                reutilizarButtonItem.Visible = false;
                loteCaducidadButtonItem.Visible = false;
                asociarFacturasButtonItem.Visible = false;
                compraProveedorButtonItem.Visible = false;
                IncidenciasButtonItem.Visible = false;
                CompraConAjusteButtonItem.Visible = false;
            }

        }
        private void Back()
        {

            if (Owner is Menu.ComprasMenu)
            {
                Menu.ComprasMenu propietario = Owner as Menu.ComprasMenu;

                if (this.Mostrado && propietario.Owner.IsModalPanelDisplayed)
                {
                    //this.DesactivaComandos();
                    try
                    {
                        if (propietario.Owner.Contains(this))
                        {
                            propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        propietario.ActivaComandos();
                        this.Mostrado = false;
                        this.DesactivaComandos();
                    }
                    catch
                    {

                    }
                }
            }

            if (Owner is Inventario.AjusteAlmacenUserControl)
            {
                Inventario.AjusteAlmacenUserControl propietario = Owner as Inventario.AjusteAlmacenUserControl;
                try
                {
                    if (propietario.Owner.Contains(this))
                    {
                        propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    propietario.ActivaComandos();
                    this.Mostrado = false;
                    this.DesactivaComandos();
                }
                catch
                {

                }
            }

        }

        public void inicializaTabla()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            superGridControl1.DataBindingComplete += SuperGridControl1DataBindingComplete;
            panel.SortColumns.Clear();
            foreach (GridColumn col in panel.Columns)
            {
                panel.SortColumns.Add(col);
            }
        }

        public void AgregaArticulo()
        {
            View.Catalogos.ArticuloUserControl articulo = new Catalogos.ArticuloUserControl();
            articulo.Owner = this;
            articulo.Muestra();
            //View.OrdenCompra.OfertasComprasUserControl ofertas = new OfertasComprasUserControl();
            //ofertas.Owner = this;
            //ofertas.Muestra();
        }

        public void estadosOrdenesCompra()
        {
            Dictionary<string, string> statusOC = new Dictionary<string, string>();
            statusOC.Add("[TODOS]", "%");
            statusOC.Add("ABIERTA", "A");
            statusOC.Add("CERRADA", "C");
            statusOC.Add("PROCESADA", "P");
            statusOC.Add("AUTORIZADA LISTA PARA ASIGNACION DE PRECIOS", "E");
            statusOC.Add("EN ASIGNACION DE CADUCIDADES", "AC");
            statusOC.Add("ASIGNACION DE CADUCIDADES FINALIZADA", "CC");
            statusOC.Add("EN ASIGNACION DE PRECIOS", "L");
            statusOC.Add("CANCELADAS", "XY");

            BindingSource bs = new BindingSource();
            bs.DataSource = statusOC;
            this.statusOrdenCompraComboBoxEx.DataSource = bs;
            statusOrdenCompraComboBoxEx.DisplayMember = "Key";
            statusOrdenCompraComboBoxEx.ValueMember = "Value";
        }

        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            if (articulo == null)
            {
               MessageBox.Show("Debe elegir una artículo");
                return;
            }

            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(articulo.PROVEEDOR_ID);

            SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(UsuarioId);
            string listaProveedores = new SIFNegocio.Usuarios().ListaProveedores(usuario);

            if (string.IsNullOrEmpty(listaProveedores))
            {
               MessageBox.Show("El usuario no tiene una lista de proveedores asignada");
                return;
            }

            if (!listaProveedores.Contains(articulo.PROVEEDOR_ID.ToString()))
            {
               MessageBox.Show("Solo puede agregar artículos del proveedor asociado con el comprador");
                return;
            }

            DataRow rowCabecera = null;
            if (OrdenCompraL.dsOrdenesCompra.Tables.Count != 0)
            {
                var cabeceras = OrdenCompraL.dsOrdenesCompra.Tables["OrdenCompraCabecera"].Select("PROVEEDOR_ID = " + articulo.PROVEEDOR_ID);
                if (cabeceras.Count() > 0)
                {
                    rowCabecera = cabeceras.First();
                }
                else
                {
                    rowCabecera = OrdenCompraL.dsOrdenesCompra.Tables["OrdenCompraCabecera"].NewRow();
                    rowCabecera["PROVEEDOR_ID"] = articulo.PROVEEDOR_ID;



                    rowCabecera["NOMBRE"] = cliente.Nombre;
                    rowCabecera["APE_PATERNO"] = cliente.ApellidoPaterno;
                    rowCabecera["APE_MATERNO"] = cliente.ApellidoMaterno;



                    OrdenCompraL.dsOrdenesCompra.Tables["OrdenCompraCabecera"].Rows.Add(rowCabecera);
                }
            }
            else
            {
                //GENERAMOS LAS COLUMNAS DE LA TABLA

                //AGREGAMOS CABECERA
                DataTable dtCabecera = new DataTable("OrdenCompraCabecera");

                dtCabecera.Columns.Add("proveedor_id");
                dtCabecera.Columns.Add("nombre");
                dtCabecera.Columns.Add("ape_paterno");
                dtCabecera.Columns.Add("ape_materno");

                this.OrdenCompraL.dsOrdenesCompra.Tables.Add(dtCabecera);

                //AGREGAMOS LA TABLA FOLIOS 
                DataTable dtFolios = new DataTable("Folios");
                dtFolios.Columns.Add("FOLIO_OC_ID");
                dtFolios.Columns.Add("PROVEEDOR_ID");
                dtFolios.Columns.Add("USUARIO_ID");
                dtFolios.Columns.Add("SUCURSAL_ID");
                dtFolios.Columns.Add("FECHA_ALTA");
                dtFolios.Columns.Add("FECHA_RECEPCION");
                dtFolios.Columns.Add("FECHA_CIERRE");
                dtFolios.Columns.Add("USUARIO_ID_AUTORIZA");
                dtFolios.Columns.Add("ESTADO_OC");

                this.OrdenCompraL.dsOrdenesCompra.Tables.Add(dtFolios);

                //ORDENES DE COMPRA
                DataTable dtOrdenCompra = new DataTable("OrdenCompra");

                dtOrdenCompra.Columns.Add("FOLIO_OC_ID");
                dtOrdenCompra.Columns.Add("NUM_PARTIDA");
                dtOrdenCompra.Columns.Add("USUARIO_ID");
                dtOrdenCompra.Columns.Add("PROVEEDOR_ID");
                dtOrdenCompra.Columns.Add("ARTICULO_ID");
                dtOrdenCompra.Columns.Add("NOMBRE");
                dtOrdenCompra.Columns.Add("CANT_SOLICITADA");
                dtOrdenCompra.Columns.Add("OFERTA_COMPRA_ID");
                dtOrdenCompra.Columns.Add("DESCRIP_OFERTA");
                dtOrdenCompra.Columns.Add("PRECIO_COSTO");
                dtOrdenCompra.Columns.Add("ULT_PRECIO_COMPRA");
                dtOrdenCompra.Columns.Add("CANT_FACTURADA");
                dtOrdenCompra.Columns.Add("CANT_RECIBIDA");
                dtOrdenCompra.Columns.Add("CANT_DEVUELTA");
                dtOrdenCompra.Columns.Add("CANT_MALESTADO");
                dtOrdenCompra.Columns.Add("CANT_REPOSICION");
                dtOrdenCompra.Columns.Add("PRECIO_FACTURA");
                dtOrdenCompra.Columns.Add("DESCTO_FACTURA");
                dtOrdenCompra.Columns.Add("DESCTO_FACTURA_AD1");
                dtOrdenCompra.Columns.Add("DESCTO_RECIBIDO");
                dtOrdenCompra.Columns.Add("DESCTO_RECIBIDO_AD1");
                dtOrdenCompra.Columns.Add("DESCTO_RECIBIDO_AD2");
                dtOrdenCompra.Columns.Add("PUNTO_DE_REORDEN");
                dtOrdenCompra.Columns.Add("EXISTENCIAS");
                dtOrdenCompra.Columns.Add("IMPORTE");
                dtOrdenCompra.Columns.Add("LABORATORIO_ID");
                dtOrdenCompra.Columns.Add("TIPO_MEDICAMENTO_CVE");

                this.OrdenCompraL.dsOrdenesCompra.Tables.Add(dtOrdenCompra);


                //OFERTAS

                DataTable dtOfertas = new DataTable("OFERTAS_COMPRAS_MAYORISTA");
                dtOfertas.Columns.Add("ARTICULO_ID");
                dtOfertas.Columns.Add("PROVEEDOR_ID");
                dtOfertas.Columns.Add("FECHA_ALTA");
                dtOfertas.Columns.Add("NOMBRE1");
                dtOfertas.Columns.Add("LABORATORIO_ID");
                dtOfertas.Columns.Add("PRECIO_FARMACIA");
                dtOfertas.Columns.Add("PRECIO_PUBLICO");
                dtOfertas.Columns.Add("TIPO_OFERTA");
                dtOfertas.Columns.Add("DESCTO_OFRECIDO");
                dtOfertas.Columns.Add("DESCRIP_DESCTO");
                dtOfertas.Columns.Add("MINIMO_PIEZAS");
                dtOfertas.Columns.Add("CANTIDAD_ACOMPRAR");
                dtOfertas.Columns.Add("PIEZAS_CON_CARGO");
                dtOfertas.Columns.Add("PIEZAS_SIN_CARGO");
                dtOfertas.Columns.Add("ESTADO_ART_PROVEE");
                dtOfertas.Columns.Add("ESTADO_ART_FLEMING");
                dtOfertas.Columns.Add("DESCTO_ADICIONAL_PROVEE");
                dtOfertas.Columns.Add("DESCTO_ESPECIAL_PROVEE");
                dtOfertas.Columns.Add("FECHA_BAJA");
                dtOfertas.Columns.Add("CODIGO_PROVEEDOR");
                dtOfertas.Columns.Add("ESCALA");

                this.OrdenCompraL.dsOrdenesCompra.Tables.Add(dtOfertas);

                //RELACIONES
                OrdenCompraL.dsOrdenesCompra.Relations.Clear();
                OrdenCompraL.dsOrdenesCompra.Relations.Add("1", OrdenCompraL.dsOrdenesCompra.Tables["OrdenCompraCabecera"].Columns["PROVEEDOR_ID"],
                                            OrdenCompraL.dsOrdenesCompra.Tables["Folios"].Columns["PROVEEDOR_ID"], false);

                OrdenCompraL.dsOrdenesCompra.Relations.Add("2", OrdenCompraL.dsOrdenesCompra.Tables["Folios"].Columns["FOLIO_OC_ID"],
                                            OrdenCompraL.dsOrdenesCompra.Tables["OrdenCompra"].Columns["FOLIO_OC_ID"], false);

                OrdenCompraL.dsOrdenesCompra.Relations.Add("3", OrdenCompraL.dsOrdenesCompra.Tables["OrdenCompra"].Columns["ARTICULO_ID"],
                                            OrdenCompraL.dsOrdenesCompra.Tables["Ofertas"].Columns["ARTICULO_ID"], false);

            }


            //RECUPERAMOS EL FOLIO O LA ORDEN DE COMPRA

            DataRow folioRow = null;

            if (superGridControl1.ActiveRow != null)
            {
                DataRow rowActive = ((DataRowView)((GridRow)superGridControl1.ActiveRow).DataItem).Row;
                if (rowActive.Table.TableName == "Folios")
                {
                    //asignamos el folio
                    folioRow = rowActive;
                }
                else
                {
                    folioRow = OrdenCompraL.dsOrdenesCompra.Tables["Folios"].NewRow();
                    folioRow["FOLIO_OC_ID"] = OrdenCompraL.GeneraFolio(Helpers.Sesion.Sucursal, articulo.PROVEEDOR_ID.ToString());
                    folioRow["PROVEEDOR_ID"] = articulo.PROVEEDOR_ID;
                    folioRow["USUARIO_ID"] = UsuarioId;
                    folioRow["SUCURSAL_ID"] = Helpers.Sesion.Sucursal.SucursalesID;
                    folioRow["FECHA_ALTA"] = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                    folioRow["FECHA_RECEPCION"] = DBNull.Value;
                    folioRow["FECHA_CIERRE"] = DBNull.Value;
                    folioRow["USUARIO_ID_AUTORIZA"] = DBNull.Value;
                    folioRow["ESTADO_OC"] = "A";

                    OrdenCompraL.dsOrdenesCompra.Tables["Folios"].Rows.Add(folioRow);
                }

            }

            DataRow OrdenCompra = OrdenCompraL.dsOrdenesCompra.Tables["OrdenCompra"].NewRow();

            if (folioRow == null)
            {
                folioRow = OrdenCompraL.dsOrdenesCompra.Tables["Folios"].NewRow();

                folioRow["FOLIO_OC_ID"] = OrdenCompraL.GeneraFolio(Helpers.Sesion.Sucursal, articulo.PROVEEDOR_ID.ToString());
            }

            OrdenCompra["FOLIO_OC_ID"] = folioRow["FOLIO_OC_ID"];
            OrdenCompra["NUM_PARTIDA"] = OrdenCompraL.dsOrdenesCompra.Tables["OrdenCompra"].Rows.Count + 1;
            OrdenCompra["USUARIO_ID"] = UsuarioId;
            OrdenCompra["PROVEEDOR_ID"] = cliente.ID;
            OrdenCompra["ARTICULO_ID"] = articulo.ARTICULO_ID;
            OrdenCompra["NOMBRE"] = articulo.NOMBRE1;
            OrdenCompra["CANT_SOLICITADA"] = 1;
            OrdenCompra["OFERTA_COMPRA_ID"] = 0;
            OrdenCompra["DESCRIP_OFERTA"] = "";
            OrdenCompra["PRECIO_COSTO"] = 0;
            OrdenCompra["ULT_PRECIO_COMPRA"] = 0;
            OrdenCompra["CANT_FACTURADA"] = 0;
            OrdenCompra["CANT_RECIBIDA"] = 0;
            OrdenCompra["CANT_DEVUELTA"] = 0;
            OrdenCompra["CANT_MALESTADO"] = 0;
            OrdenCompra["CANT_REPOSICION"] = 0;
            OrdenCompra["PRECIO_FACTURA"] = 0;
            OrdenCompra["DESCTO_FACTURA"] = 0;
            OrdenCompra["DESCTO_FACTURA_AD1"] = 0;
            OrdenCompra["DESCTO_RECIBIDO"] = 0;
            OrdenCompra["DESCTO_RECIBIDO_AD1"] = 0;
            OrdenCompra["DESCTO_RECIBIDO_AD2"] = 0;
            OrdenCompra["PUNTO_DE_REORDEN"] = 0;
            OrdenCompra["EXISTENCIAS"] = 0;
            OrdenCompra["IMPORTE"] = 0;
            OrdenCompra["LABORATORIO_ID"] = articulo.LABORATORIO_ID;
            OrdenCompra["TIPO_MEDICAMENTO_CVE"] = articulo.TIPO_MEDICAMENTO_CVE;

            OrdenCompraL.dsOrdenesCompra.Tables["OrdenCompra"].Rows.Add(OrdenCompra);

            DataTable ordenesCompraNueva = new DataTable();
            ordenesCompraNueva.Columns.Add("ARTICULO_ID");
            DataRow rowArticulos = ordenesCompraNueva.NewRow();
            rowArticulos["ARTICULO_ID"] = articulo.ARTICULO_ID;
            ordenesCompraNueva.Rows.Add(rowArticulos);

            OrdenCompraL.dsOrdenesCompra.Tables["Ofertas"].Rows.Add(OrdenCompraL.Ofertas(ordenesCompraNueva).OFERTAS_COMPRAS_MAYORISTA.Rows);

            this.superGridControl1.PrimaryGrid.DataSource = OrdenCompraL.dsOrdenesCompra;
            superGridControl1.PrimaryGrid.AutoGenerateColumns = true;
            superGridControl1.PrimaryGrid.DataMember = "OrdenCompraCabecera";
        }

        void SuperGridControl1DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;

            if (panel.DataMember == "V_ORDEN_COMPRA")
            {
                CustomizeHeaderPanel(panel);
            }

            if (panel.DataMember == "OrdenCompra")
            {
                CustomizeDetailsPanel(panel);
            }
            //switch (panel.DataMember)
            //{
            //    case "Customers":
            //        CustomizeCustomerPanel(panel);
            //        break;

            //    case "Orders":
            //        CustomizeOrdersPanel(panel);
            //        break;

            //    case "Order Details":
            //        CustomizeDetailsPanel(panel);
            //        break;
            //}
            superGridControl1.Update();
            superGridControl1.Refresh();
            panel.InvalidateLayout();
        }

        private void CustomizeHeaderPanel(GridPanel panel)
        {
            return;
            panel.AutoGenerateColumns = false;
            panel.Columns.Clear();

            GridColumn FOLIO_OC_IDColumn = new GridColumn("FOLIO_OC_IDColumn");
            FOLIO_OC_IDColumn.HeaderText = "FOLIO";
            FOLIO_OC_IDColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            FOLIO_OC_IDColumn.DataPropertyName = "FOLIO_OC_ID";
            FOLIO_OC_IDColumn.Width = 120;
            FOLIO_OC_IDColumn.Visible = true;
            panel.Columns.Add(FOLIO_OC_IDColumn);

            //GridColumn USUARIO_IDColumn = new GridColumn("USUARIO_IDColumn");
            //USUARIO_IDColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            //USUARIO_IDColumn.HeaderText = "USUARIO";
            //USUARIO_IDColumn.DataPropertyName = "USUARIO_ID";
            //USUARIO_IDColumn.Width = 100;
            //USUARIO_IDColumn.Visible = false;
            //panel.Columns.Add(USUARIO_IDColumn);

            GridColumn PROVEEDOR_IDColumn = new GridColumn("PROVEEDOR_IDColumn");
            PROVEEDOR_IDColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            PROVEEDOR_IDColumn.HeaderText = "PROVEEDOR ID";
            PROVEEDOR_IDColumn.DataPropertyName = "PROVEEDOR_ID";
            PROVEEDOR_IDColumn.Width = 100;
            panel.Columns.Add(PROVEEDOR_IDColumn);

            GridColumn PROVEEDOR_NOMBREColumn = new GridColumn("PROVEEDOR_NOMBREColumn");
            PROVEEDOR_NOMBREColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            PROVEEDOR_NOMBREColumn.HeaderText = "PROVEEDOR";
            PROVEEDOR_NOMBREColumn.DataPropertyName = "CAT_CLIENTES_NOMBRE";
            PROVEEDOR_NOMBREColumn.Width = 200;
            panel.Columns.Add(PROVEEDOR_NOMBREColumn);

            GridColumn SUCURSAL_IDColumn = new GridColumn("SUCURSAL_IDColumn");
            SUCURSAL_IDColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            SUCURSAL_IDColumn.HeaderText = "SUCURSAL";
            SUCURSAL_IDColumn.DataPropertyName = "SUCURSAL_ID";
            SUCURSAL_IDColumn.Width = 200;
            SUCURSAL_IDColumn.Visible = false;
            panel.Columns.Add(SUCURSAL_IDColumn);

            GridColumn FECHA_ALTAColumn = new GridColumn("FECHA_ALTAColumn");
            FECHA_ALTAColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            FECHA_ALTAColumn.HeaderText = "ALTA";
            FECHA_ALTAColumn.DataPropertyName = "FECHA_ALTA";
            FECHA_ALTAColumn.Width = 150;
            panel.Columns.Add(FECHA_ALTAColumn);

            GridColumn FECHA_RECEPCIONColumn = new GridColumn("FECHA_RECEPCIONColumn");
            FECHA_RECEPCIONColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            FECHA_RECEPCIONColumn.HeaderText = "RECEPCION";
            FECHA_RECEPCIONColumn.DataPropertyName = "FECHA_RECEPCION";
            FECHA_RECEPCIONColumn.Width = 150;
            panel.Columns.Add(FECHA_RECEPCIONColumn);

            GridColumn FECHA_CIERREColumn = new GridColumn("FECHA_CIERREColumn");
            FECHA_CIERREColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            FECHA_CIERREColumn.HeaderText = "FECHA_CIERRE";
            FECHA_CIERREColumn.DataPropertyName = "FECHA_CIERRE";
            FECHA_CIERREColumn.Width = 150;
            panel.Columns.Add(FECHA_CIERREColumn);

            //GridColumn USUARIO_AUTORIZA_IDColumn = new GridColumn("USUARIO_AUTORIZA_IDColumn");
            //USUARIO_AUTORIZA_IDColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            //USUARIO_AUTORIZA_IDColumn.HeaderText = "AUTORIZA";
            //USUARIO_AUTORIZA_IDColumn.DataPropertyName = "USUARIO_AURTORIZA_ID";
            //USUARIO_AUTORIZA_IDColumn.Width = 100;
            //panel.Columns.Add(USUARIO_AUTORIZA_IDColumn);

            //GridColumn FECHA_ARUTORIZA_IDColumn = new GridColumn("FECHA_ARUTORIZAColumn");
            //FECHA_ARUTORIZA_IDColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            //FECHA_ARUTORIZA_IDColumn.HeaderText = "FECHA AUTORIZA";
            //FECHA_ARUTORIZA_IDColumn.DataPropertyName = "FECHA_AUTORIZA";
            //FECHA_ARUTORIZA_IDColumn.Width = 100;
            //panel.Columns.Add(FECHA_ARUTORIZA_IDColumn);

            GridColumn ESTADO_OCColumn = new GridColumn("ESTADO_OCColumn");
            ESTADO_OCColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            ESTADO_OCColumn.HeaderText = "ESTADO OC";
            ESTADO_OCColumn.DataPropertyName = "ESTADO_OC";
            ESTADO_OCColumn.Width = 100;
            panel.Columns.Add(ESTADO_OCColumn);

            //GridColumn CAT_CLIETNES_NOMBREColumn = new GridColumn("CAT_CLIETNES_NOMBREColumn");
            //CAT_CLIETNES_NOMBREColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            //CAT_CLIETNES_NOMBREColumn.HeaderText = "CLIENTE";
            //CAT_CLIETNES_NOMBREColumn.DataPropertyName = "CAT_CLIETNES_NOMBRE";
            //CAT_CLIETNES_NOMBREColumn.Width = 100;
            //panel.Columns.Add(CAT_CLIETNES_NOMBREColumn);

            GridColumn CAT_USUARIOS_NOMBREColumn = new GridColumn("CAT_USUARIOS_NOMBREColumn");
            CAT_USUARIOS_NOMBREColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            CAT_USUARIOS_NOMBREColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            CAT_USUARIOS_NOMBREColumn.HeaderText = "USUARIO";
            CAT_USUARIOS_NOMBREColumn.DataPropertyName = "CAT_USUARIOS_NOMBRE";
            CAT_USUARIOS_NOMBREColumn.Width = 100;
            panel.Columns.Add(CAT_USUARIOS_NOMBREColumn);

            //GridColumn CAT_SUCURSALESColumn = new GridColumn("CAT_SUCURSALESColumn");
            //CAT_SUCURSALESColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            //CAT_SUCURSALESColumn.HeaderText = "SUCURSALES";
            //CAT_SUCURSALESColumn.DataPropertyName = "CAT_SUCURSALES";
            //CAT_SUCURSALESColumn.Width = 100;
            //panel.Columns.Add(CAT_SUCURSALESColumn);

        }

        private void CustomizeDetailsPanel(GridPanel panel)
        {
            //panel.ColumnHeader.RowHeight = 30;

            //panel.Columns[0].CellStyles.Default.Background =
            //    new Background(Color.LavenderBlush);

            //panel.Columns["OrderID"].CellStyles.Default.Alignment = Alignment.MiddleLeft;

            //panel.DefaultVisualStyles.CaptionStyles.Default.Alignment = Alignment.MiddleLeft;
            //panel.DefaultVisualStyles.CellStyles.Default.Alignment = Alignment.MiddleRight;

            //UpdateDetailsFooter(panel);

            panel.AutoGenerateColumns = false;
            panel.Columns.Clear();

            GridColumn FOLIO_OC_IDColumn = new GridColumn("FOLIO_OC_IDColumn");
            FOLIO_OC_IDColumn.HeaderText = "FOLIO";
            FOLIO_OC_IDColumn.DataPropertyName = "FOLIO_OC_ID";
            FOLIO_OC_IDColumn.Width = 70;
            FOLIO_OC_IDColumn.Visible = false;
            panel.Columns.Add(FOLIO_OC_IDColumn);

            GridColumn NUM_PARTIDAColumn = new GridColumn("NUM_PARTIDAColumn");
            NUM_PARTIDAColumn.HeaderText = "NUM_PARTIDA";
            NUM_PARTIDAColumn.DataPropertyName = "NUM_PARTIDA";
            NUM_PARTIDAColumn.Width = 100;
            NUM_PARTIDAColumn.Visible = true;
            panel.Columns.Add(NUM_PARTIDAColumn);

            GridColumn USUARIO_IDColumn = new GridColumn("USUARIO_IDColumn");
            USUARIO_IDColumn.HeaderText = "USUARIO";
            USUARIO_IDColumn.DataPropertyName = "USUARIO_ID";
            USUARIO_IDColumn.Width = 100;
            USUARIO_IDColumn.Visible = false;
            panel.Columns.Add(USUARIO_IDColumn);

            GridColumn PROVEEDOR_IDColumn = new GridColumn("PROVEEDOR_IDColumn");
            PROVEEDOR_IDColumn.HeaderText = "PROVEEDOR";
            PROVEEDOR_IDColumn.DataPropertyName = "PROVEEDOR_ID";
            PROVEEDOR_IDColumn.Width = 200;
            PROVEEDOR_IDColumn.Visible = false;
            panel.Columns.Add(PROVEEDOR_IDColumn);

            GridColumn ARTICULO_IDColumn = new GridColumn("ARTICULO_IDColumn");
            ARTICULO_IDColumn.HeaderText = "CLAVE";
            ARTICULO_IDColumn.DataPropertyName = "ARTICULO_ID";
            ARTICULO_IDColumn.Width = 120;
            panel.Columns.Add(ARTICULO_IDColumn);

            GridColumn NOMBREColumn = new GridColumn("NOMBREColumn");
            NOMBREColumn.HeaderText = "NOMBRE";
            NOMBREColumn.DataPropertyName = "NOMBRE";
            NOMBREColumn.Width = 200;
            panel.Columns.Add(NOMBREColumn);

            GridColumn CANT_SOLICITADAColumn = new GridColumn("CANT_SOLICITADAColumn");
            CANT_SOLICITADAColumn.HeaderText = "SOLICITADA";
            CANT_SOLICITADAColumn.DataPropertyName = "CANT_SOLICITADA";
            CANT_SOLICITADAColumn.Width = 80;
            panel.Columns.Add(CANT_SOLICITADAColumn);

            GridColumn OFERTA_COMPRA_IDColumn = new GridColumn("OFERTA_COMPRA_IDColumn");
            OFERTA_COMPRA_IDColumn.HeaderText = "OFERTA";
            OFERTA_COMPRA_IDColumn.DataPropertyName = "OFERTA_COMPRA_ID";
            OFERTA_COMPRA_IDColumn.Width = 100;
            OFERTA_COMPRA_IDColumn.Visible = false;
            panel.Columns.Add(OFERTA_COMPRA_IDColumn);


            GridColumn DESCRIP_OFERTAColumn = new GridColumn("DESCRIP_OFERTAColumn");
            DESCRIP_OFERTAColumn.HeaderText = "DESCIPCION";
            DESCRIP_OFERTAColumn.DataPropertyName = "DESCRIP_OFERTA";
            DESCRIP_OFERTAColumn.Width = 200;
            DESCRIP_OFERTAColumn.Visible = true;
            panel.Columns.Add(DESCRIP_OFERTAColumn);

            GridColumn PRECIO_COSTOColumn = new GridColumn("PRECIO_COSTOColumn");
            PRECIO_COSTOColumn.HeaderText = "COSTO PROM";
            PRECIO_COSTOColumn.DataPropertyName = "PRECIO_COSTO";
            PRECIO_COSTOColumn.Width = 100;
            PRECIO_COSTOColumn.Visible = true;
            panel.Columns.Add(PRECIO_COSTOColumn);


            GridColumn ULT_PRECIO_COMPRAColumn = new GridColumn("ULT_PRECIO_COMPRAColumn");
            ULT_PRECIO_COMPRAColumn.HeaderText = "ULTIMO COSTO";
            ULT_PRECIO_COMPRAColumn.DataPropertyName = "ULT_PRECIO_COMPRA";
            ULT_PRECIO_COMPRAColumn.Width = 100;
            ULT_PRECIO_COMPRAColumn.Visible = true;
            panel.Columns.Add(ULT_PRECIO_COMPRAColumn);

            GridColumn CANT_FACTURADAColumn = new GridColumn("CANT_FACTURADAColumn");
            CANT_FACTURADAColumn.HeaderText = "COSTO";
            CANT_FACTURADAColumn.DataPropertyName = "CANT_FACTURADA";
            CANT_FACTURADAColumn.Width = 100;
            CANT_FACTURADAColumn.Visible = false;
            panel.Columns.Add(CANT_FACTURADAColumn);

            GridColumn CANT_RECIBIDAColumn = new GridColumn("CANT_RECIBIDAColumn");
            CANT_RECIBIDAColumn.HeaderText = "COSTO";
            CANT_RECIBIDAColumn.DataPropertyName = "CANT_RECIBIDA";
            CANT_RECIBIDAColumn.Width = 100;
            CANT_RECIBIDAColumn.Visible = false;
            panel.Columns.Add(CANT_RECIBIDAColumn);


            GridColumn CANT_DEVUELTAColumn = new GridColumn("CANT_DEVUELTAColumn");
            CANT_DEVUELTAColumn.HeaderText = "COSTO";
            CANT_DEVUELTAColumn.DataPropertyName = "CANT_DEVUELTA";
            CANT_DEVUELTAColumn.Width = 100;
            CANT_DEVUELTAColumn.Visible = false;
            panel.Columns.Add(CANT_DEVUELTAColumn);

            GridColumn CANT_MALESTADOColumn = new GridColumn("CANT_MALESTADOColumn");
            CANT_MALESTADOColumn.HeaderText = "COSTO";
            CANT_MALESTADOColumn.DataPropertyName = "CANT_MALESTADO";
            CANT_MALESTADOColumn.Width = 100;
            CANT_MALESTADOColumn.Visible = false;
            panel.Columns.Add(CANT_MALESTADOColumn);


            GridColumn CANT_REPOSICIONColumn = new GridColumn("CANT_REPOSICIONColumn");
            CANT_REPOSICIONColumn.HeaderText = "COSTO";
            CANT_REPOSICIONColumn.DataPropertyName = "CANT_REPOSICION";
            CANT_REPOSICIONColumn.Width = 100;
            CANT_REPOSICIONColumn.Visible = false;
            panel.Columns.Add(CANT_REPOSICIONColumn);

            GridColumn PRECIO_FACTURAColumn = new GridColumn("PRECIO_FACTURAColumn");
            PRECIO_FACTURAColumn.HeaderText = "COSTO";
            PRECIO_FACTURAColumn.DataPropertyName = "PRECIO_FACTURA";
            PRECIO_FACTURAColumn.Width = 100;
            PRECIO_FACTURAColumn.Visible = false;
            panel.Columns.Add(PRECIO_FACTURAColumn);

            GridColumn DESCTO_FACTURAColumn = new GridColumn("DESCTO_FACTURAColumn");
            DESCTO_FACTURAColumn.HeaderText = "COSTO";
            DESCTO_FACTURAColumn.DataPropertyName = "DESCTO_FACTURA";
            DESCTO_FACTURAColumn.Width = 100;
            DESCTO_FACTURAColumn.Visible = false;
            panel.Columns.Add(DESCTO_FACTURAColumn);

            GridColumn DESCTO_FACTURA_AD1Column = new GridColumn("DESCTO_FACTURA_AD1Column");
            DESCTO_FACTURA_AD1Column.HeaderText = "COSTO";
            DESCTO_FACTURA_AD1Column.DataPropertyName = "DESCTO_FACTURA_AD1";
            DESCTO_FACTURA_AD1Column.Width = 100;
            DESCTO_FACTURA_AD1Column.Visible = false;
            panel.Columns.Add(DESCTO_FACTURA_AD1Column);

            GridColumn DESCTO_RECIBIDOColumn = new GridColumn("DESCTO_RECIBIDOColumn");
            DESCTO_RECIBIDOColumn.HeaderText = "COSTO";
            DESCTO_RECIBIDOColumn.DataPropertyName = "DESCTO_RECIBIDO";
            DESCTO_RECIBIDOColumn.Width = 100;
            DESCTO_RECIBIDOColumn.Visible = false;
            panel.Columns.Add(DESCTO_RECIBIDOColumn);

            GridColumn DESCTO_RECIBIDO_AD1Column = new GridColumn("DESCTO_RECIBIDO_AD1Column");
            DESCTO_RECIBIDO_AD1Column.HeaderText = "COSTO";
            DESCTO_RECIBIDO_AD1Column.DataPropertyName = "DESCTO_RECIBIDO_AD1";
            DESCTO_RECIBIDO_AD1Column.Width = 100;
            DESCTO_RECIBIDO_AD1Column.Visible = false;
            panel.Columns.Add(DESCTO_RECIBIDO_AD1Column);

            GridColumn DESCTO_RECIBIDO_AD2Column = new GridColumn("DESCTO_RECIBIDO_AD2Column");
            DESCTO_RECIBIDO_AD2Column.HeaderText = "COSTO";
            DESCTO_RECIBIDO_AD2Column.DataPropertyName = "DESCTO_RECIBIDO_AD2Column";
            DESCTO_RECIBIDO_AD2Column.Width = 100;
            DESCTO_RECIBIDO_AD2Column.Visible = false;
            panel.Columns.Add(DESCTO_RECIBIDO_AD2Column);


            GridColumn PUNTO_DE_REORDENColumn = new GridColumn("PUNTO_DE_REORDENColumn");
            PUNTO_DE_REORDENColumn.HeaderText = "EOQ";
            PUNTO_DE_REORDENColumn.DataPropertyName = "PUNTO_DE_REORDEN";
            PUNTO_DE_REORDENColumn.Width = 100;
            panel.Columns.Add(PUNTO_DE_REORDENColumn);

            GridColumn EXISTENCIASColumn = new GridColumn("EXISTENCIASColumn");
            EXISTENCIASColumn.HeaderText = "EXISTENCIAS";
            EXISTENCIASColumn.DataPropertyName = "EXISTENCIAS";
            EXISTENCIASColumn.Width = 100;
            panel.Columns.Add(EXISTENCIASColumn);

            GridColumn IMPORTEColumn = new GridColumn("IMPORTEColumn");
            IMPORTEColumn.HeaderText = "IMPORTE";
            IMPORTEColumn.DataPropertyName = "IMPORTE";
            IMPORTEColumn.Width = 100;
            IMPORTEColumn.Visible = true;
            panel.Columns.Add(IMPORTEColumn);

            // GridColumn OFERTASColumn = new GridColumn("OFERTASColumn");
            //// OFERTASColumn.EditControl = 
            // OFERTASColumn.HeaderText = "OFERTA";
            // OFERTASColumn.DataPropertyName = "OFERTA_COMPRA_ID";
            // OFERTASColumn.Width = 200;
            // panel.Columns.Add(EXISTENCIASColumn);

            GridColumn LABORATORIO_IDColumn = new GridColumn("LABORATORIO_IDColumn");
            // OFERTASColumn.EditControl = 
            LABORATORIO_IDColumn.HeaderText = "LABORATORIO";
            LABORATORIO_IDColumn.DataPropertyName = "LABORATORIO_ID";
            LABORATORIO_IDColumn.Width = 100;
            panel.Columns.Add(LABORATORIO_IDColumn);

            GridColumn TIPO_MEDICAMENTOColumn = new GridColumn("TIPO_MEDICAMENTOColumn");
            // OFERTASColumn.EditControl = 
            TIPO_MEDICAMENTOColumn.HeaderText = "TIPO MEDICAMENTO";
            TIPO_MEDICAMENTOColumn.DataPropertyName = "TIPO_MEDICAMENTO_CVE";
            TIPO_MEDICAMENTOColumn.Width = 100;
            panel.Columns.Add(TIPO_MEDICAMENTOColumn);

            superGridControl1.Refresh();
        }

        public void Buscar()
        {
            if (!loaded)
            {
                return;
            }

            string statusOc = "%";
            if (!string.IsNullOrEmpty(this.statusOrdenCompraComboBoxEx.SelectedValue.ToString()))
            {
                statusOc = this.statusOrdenCompraComboBoxEx.SelectedValue.ToString();
                if (statusOc.Length == 1 && statusOc != "%")
                {
                    statusOc += " ";
                }
            }
            OrdenCompraL.dsOrdenesCompraDT = OrdenCompraL.BuscaOrdenCompra(this.buscarTextBoxX.Text, dateTimeInput1.Value, dateTimeInput2.Value, statusOc, UsuarioId);

            this.superGridControl1.PrimaryGrid.DataSource = OrdenCompraL.dsOrdenesCompraDT;
            superGridControl1.Refresh();
            superGridControl1.Invalidate();
            superGridControl1.PrimaryGrid.DataMember = "V_ORDEN_COMPRA";
            //superGridControl1.Refresh();
            //SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { SucursalID = SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID };
            //SIFModelo.Remision remision = new SIFModelo.Remision();
            //remision.NumeroRemision = this.buscarTextBoxX.Text;
            //DsRemisiones = remsionL.BuscaRemisiones(sucursal, remision);

            //DsRemisiones.Relations.Add("1", DsRemisiones.Tables["Remisiones"].Columns["NUM_REMISION"],
            //                               DsRemisiones.Tables["RemisionDetalles"].Columns["NUM_REMISION"], false);

            ////this.bindingSource.DataSource = DsRemisiones;
            //this.superGridControl1.PrimaryGrid.DataSource = DsRemisiones;
            ////superGridControl1.PrimaryGrid.AutoGenerateColumns = true;
            //superGridControl1.PrimaryGrid.DataMember = "Remisiones";
        }

        private void Eliminar()
        {
            var seleccionado = superGridControl1.ActiveRow;

            if (seleccionado == null)
            {
                return;
            }

            if (MessageBoxEx.Show("¿Cancelar las ordenes de compra seleccionadas?", "Cancelar", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            foreach (GridRow folioProveedor in seleccionado.GridPanel.Rows)
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow row = ((DataRowView)(folioProveedor.DataItem)).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;

                if (row.SELECCIONADO == "True")
                {
                    if (row.ESTADO_OC.Contains("L"))
                    {
                       MessageBox.Show("NO puedes Cancelar una orden de compra ya PROCESADA", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        row.ESTADO_OC = "XY";
                        new SIFNegocio.OrdenCompra.OrdenCompra().ActualizaOrdenCompra(row);
                    }
                }

            }

            this.Buscar();
            return;


            foreach (GridRow folioProveedor in seleccionado.GridPanel.GetSelectedRows())
            {
                if (folioProveedor.GridPanel.DataMember == "OrdenCompraCabecera")
                {
                    SIFModelo.Cliente proveedor = new SIFModelo.Cliente();


                    DataRow proveedorRow = ((DataRowView)((GridRow)folioProveedor).DataItem).Row;

                    proveedor.ID = int.Parse(proveedorRow["PROVEEDOR_ID"].ToString());
                    proveedor.Nombre = proveedorRow["NOMBRE"].ToString();
                    proveedor.ApellidoMaterno = proveedorRow["APE_PATERNO"].ToString();
                    proveedor.ApellidoPaterno = proveedorRow["APE_MATERNO"].ToString();

                    DialogResult res =MessageBox.Show("Eliminar todas los artículos del proveedor " + proveedor.Nombre + " " + proveedor.ApellidoPaterno + " " + proveedor.ApellidoMaterno, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (res == DialogResult.No)
                    {
                        return;
                    }

                    //ELIMINAR TODAS LA OC Y LOS DETALLES DE ARTÍCULO PROVEEDOR
                    DataView viewFolios = new DataView(OrdenCompraL.dsOrdenesCompra.Tables["Folios"]);
                    viewFolios.RowFilter = "PROVEEDOR_ID = '" + proveedor.ID + "'";
                    DataTable dtFolios = OrdenCompraL.dsOrdenesCompra.Tables["Folios"];
                    foreach (DataRowView folioItem in viewFolios)
                    {

                        DataRow rwSelecionada = folioItem.Row;

                        if (rwSelecionada.Table.TableName != "Folios")
                        {
                            continue;
                        }

                        string folio = rwSelecionada["FOLIO_OC_ID"].ToString();

                        DataView vistaOrdenesCompra = new DataView(this.OrdenCompraL.dsOrdenesCompra.Tables["OrdenCompra"]);

                        vistaOrdenesCompra.RowFilter = "FOLIO_OC_ID = '" + folio + "'";

                        DataTable dtOrdenCompra = OrdenCompraL.dsOrdenesCompra.Tables["OrdenCompra"];
                        foreach (var vitem in vistaOrdenesCompra)
                        {
                            DataRow rowOrdenCompra = ((DataRowView)vitem).Row;
                            dtOrdenCompra.Rows.Remove(rowOrdenCompra);
                        }

                        //ELIMINAR EL FOLIO

                        dtFolios.Rows.Remove(rwSelecionada);

                    }

                    DataTable dtOrdenCompraCabecera = OrdenCompraL.dsOrdenesCompra.Tables["OrdenCompraCabecera"];

                    dtOrdenCompraCabecera.Rows.Remove(proveedorRow);
                }
            }

            //ELIMINAR TODAS LAS OC SELECCIONADAS
            var seleccionadas = superGridControl1.GetSelectedRows();

            if (seleccionado.GridPanel.DataMember == "Folios")
            {
                DialogResult res =MessageBox.Show("¿Eliminar las ordenes de compra seleccionadas?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    return;
                }

                DataTable dtFolios = OrdenCompraL.dsOrdenesCompra.Tables["Folios"];
                foreach (var item in seleccionadas)
                {
                    if (!(item is GridRow))
                    {
                        continue;
                    }


                    DataRow rwSelecionada = ((DataRowView)((GridRow)item).DataItem).Row;

                    if (rwSelecionada.Table.TableName != "Folios")
                    {
                        continue;
                    }

                    string folio = rwSelecionada["FOLIO_OC_ID"].ToString();

                    DataView vistaOrdenesCompra = new DataView(this.OrdenCompraL.dsOrdenesCompra.Tables["OrdenCompra"]);

                    vistaOrdenesCompra.RowFilter = "FOLIO_OC_ID = '" + folio + "'";

                    DataTable dtOrdenCompra = OrdenCompraL.dsOrdenesCompra.Tables["OrdenCompra"];
                    foreach (var vitem in vistaOrdenesCompra)
                    {
                        DataRow rowOrdenCompra = ((DataRowView)vitem).Row;
                        dtOrdenCompra.Rows.Remove(rowOrdenCompra);
                    }

                    //ELIMINAR EL FOLIO

                    dtFolios.Rows.Remove(rwSelecionada);
                }
            }


            //ELIMINAR TODOS LOS DETALLES SELECCIONADOS
            if (seleccionado.GridPanel.DataMember == "OrdenCompra")
            {
                DialogResult res =MessageBox.Show("¿Eliminar los artículos seleccionados?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    return;
                }

                foreach (var item in seleccionadas)
                {
                    if (!(item is GridRow))
                    {
                        continue;
                    }

                    if (((GridRow)item).DataItem == null)
                    {
                        continue;
                    }


                    DataRow rwSelecionada = ((DataRowView)((GridRow)item).DataItem).Row;

                    if (rwSelecionada.Table.TableName != "OrdenCompra")
                    {
                        continue;
                    }


                    rwSelecionada.Table.Rows.Remove(rwSelecionada);

                }

            }
            superGridControl1.PrimaryGrid.DataSource = OrdenCompraL.dsOrdenesCompra;
        }

        private void Cerrar()
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Orden de Compra a cerrar");
                return;
            }

            List<SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow> ordenesSeleccionadas = new List<SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow>();
            SIFModelo.OrdenCompra.OrdenesCompraDataSet ordenCompraDS = this.superGridControl1.PrimaryGrid.DataSource as SIFModelo.OrdenCompra.OrdenesCompraDataSet;
            foreach (DataRow row in ordenCompraDS.V_ORDEN_COMPRA.Rows)
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OCrow = row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
                if (OCrow.SELECCIONADO == "True")
                {
                    ordenesSeleccionadas.Add(OCrow);
                }
            }

            if (ordenesSeleccionadas.Count() > 1)
            {
                if (MessageBoxEx.Show("¿Se cerrarán " + ordenesSeleccionadas.Count + " ordenes de compra?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                foreach (SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oCd in ordenesSeleccionadas)
                {
                    if (oCd.ESTADO_OC.Trim() != "A")
                    {
                        continue;
                    }

                    oCd.ESTADO_OC = "C";
                    oCd.FECHA_CIERRE = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                    OrdenCompraL.ActualizaOrdenCompra(oCd);
                }
                Buscar();
                return;
            }


            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            oC.ESTADO_OC = oC.ESTADO_OC.Trim();

            if (oC.ESTADO_OC != "A")
            {
               MessageBox.Show("El estado de la orden de compra debe ser abierto");
                return;
            }

            // View.Ventas.AccesoUsuarioForm frmAcceso = new Ventas.AccesoUsuarioForm();

            SIFModelo.Usuario usuario = Helpers.Sesion.Usuario;

            if (MessageBoxEx.Show("¿Cerrar la orden de compra " + oC.FOLIO_OC_ID + " ?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            //if (frmAcceso.ShowDialog() == DialogResult.OK)
            //{
            //    usuario = frmAcceso.Usuario;
            //}
            //else
            //{
            //    return;
            //}

            oC.USUARIO_ID_AUTORIZA = usuario.UsuariosID.ToString();

            if (oC.ESTADO_OC != "A")
            {
               MessageBox.Show("La orden de compra debe estar abierta");
                return;
            }

            oC.ESTADO_OC = "C";
            oC.FECHA_CIERRE = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            OrdenCompraL.ActualizaOrdenCompra(oC);
           MessageBox.Show("La orden de compra ha sido cerrada");
        }


        /*
        public void GuardarOrdenCompraAjusteHUP(string folio)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
           

            oC.ESTADO_OC = oC.ESTADO_OC.Trim(); 

            oC.ESTADO_OC = "C";
            oC.FECHA_CIERRE = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            OrdenCompraL.ActualizaOrdenCompra(oC);
           MessageBox.Show("La orden de compra ha sido cerrada");
        }
        */

        private void Guardar()
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRADataTable ordenCompraDT = new SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRADataTable();
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETDataTable ordenCompraDetalleDT = new SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETDataTable();

            if (OrdenCompraL.dsOrdenesCompra.Tables["Folios"] == null)
            {
                return;
            }

            foreach (DataRow folio in OrdenCompraL.dsOrdenesCompra.Tables["Folios"].Rows)
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRARow oc = ordenCompraDT.NewORDEN_COMPRARow();
                oc.FOLIO_OC_ID = folio["FOLIO_OC_ID"].ToString();
                oc.USUARIO_ID = UsuarioId.ToString();
                oc.PROVEEDOR_ID = int.Parse(folio["PROVEEDOR_ID"].ToString());
                oc.SUCURSAL_ID = short.Parse(folio["SUCURSAL_ID"].ToString());
                oc.FECHA_ALTA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                oc.FECHA_RECEPCION = new DateTime();
                oc.FECHA_CIERRE = new DateTime();
                oc.USUARIO_ID_AUTORIZA = "0";
                oc.FECHA_AUTORIZA = new DateTime();
                oc.ESTADO_OC = SIFModelo.EstadosOrdenCompra.ABIERTA.Clave;

                //VALIDAMOS SI GUARDAMOS O ACTUALIZAMOS
                if (OrdenCompraL.OrdenCompraPoFolio(oc.FOLIO_OC_ID) == null)
                {
                    OrdenCompraL.GuardaOrdenCompra(oc);
                }
                else
                {
                    OrdenCompraL.ActualizaOrdenCompra(oc);
                }

                //AGREGAMOS TODOS LOS DETALLES

                short numPartida = 1;
                foreach (SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow rowOrdenCompra in OrdenCompraL.dsOrdenesCompra.ORDEN_COMPRA_DET.Select("PROVEEDOR_ID = " + oc.PROVEEDOR_ID))
                {
                    SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow ocd = ordenCompraDetalleDT.NewORDEN_COMPRA_DETRow();
                    ocd.FOLIO_OC_ID = rowOrdenCompra.FOLIO_OC_ID.ToString();
                    ocd.NUM_PARTIDA = numPartida;
                    ocd.USUARIO_ID = UsuarioId;
                    ocd.PROVEEDOR_ID = rowOrdenCompra.PROVEEDOR_ID;
                    ocd.ARTICULO_ID = rowOrdenCompra.ARTICULO_ID;
                    ocd.NOMBRE = rowOrdenCompra.NOMBRE;

                    ocd.CANT_SOLICITADA = rowOrdenCompra.CANT_SOLICITADA;
                    if (ocd.IsOFERTA_COMPRA_IDNull())
                        ocd.OFERTA_COMPRA_ID = 0;//short.Parse( rowOrdenCompra["OFERTA_COMPRA_ID"].ToString());


                    if (ocd.IsDESCRIP_OFERTANull())
                        ocd.DESCRIP_OFERTA = "-";//rowOrdenCompra["DESCRIP_OFERTA"].ToString();

                    ocd.DESCRIP_OFERTA = rowOrdenCompra.DESCRIP_OFERTA;

                    ocd.PRECIO_COSTO = decimal.Parse(rowOrdenCompra["PRECIO_COSTO"].ToString());
                    ocd.ULT_PRECIO_COMPRA = double.Parse(rowOrdenCompra["ULT_PRECIO_COMPRA"].ToString());
                    ocd.CANT_FACTURADA = 0;//short.Parse( rowOrdenCompra["CANT_FACTURADA"].ToString());
                    ocd.CANT_RECIBIDA = 0;// short.Parse(rowOrdenCompra["CANT_RECIBIDA"].ToString());
                    ocd.CANT_DEVUELTA = 0;// int.Parse(rowOrdenCompra["CANT_DEVUELTA"].ToString());
                    ocd.CANT_MALESTADO = 0;// int.Parse(rowOrdenCompra["CANT_MALESTADO"].ToString());
                    ocd.CANT_REPOSICION = 0;// int.Parse(rowOrdenCompra["CANT_REPOSICION"].ToString());
                    ocd.PRECIO_FACTURA = 0;//double.Parse( rowOrdenCompra["PRECIO_FACTURA"].ToString());
                    ocd.DESCTO_FACTURA = 0;//double.Parse(rowOrdenCompra["DESCTO_FACTURA"].ToString());
                    ocd.DESCTO_FACTURA_AD1 = 0;// double.Parse(rowOrdenCompra["DESCTO_FACTURA_AD1"].ToString());
                    ocd.DESCTO_RECIBIDO = 0;// double.Parse(rowOrdenCompra["DESCTO_RECIBIDO"].ToString());
                    ocd.DESCTO_RECIBIDO_AD1 = 0;//double.Parse(rowOrdenCompra["DESCTO_RECIBIDO_AD1"].ToString());
                    ocd.DESCTO_RECIBIDO_AD2 = 0;//double.Parse(rowOrdenCompra["DESCTO_RECIBIDO_AD2"].ToString());

                    if (OrdenCompraL.OrdenCompraDetallePoFolio(ocd) == null)
                    {
                        OrdenCompraL.GuardaOrdenCompraDetalle(ocd);
                    }
                    else
                    {
                        OrdenCompraL.ActualizaOrdenCompraDetalle(ocd);
                    }

                    numPartida++;
                }

            }

           MessageBox.Show("Se crearon las ordenes de compra correctamente");

        }

        private void Unir()
        {
            //mostramos la columna para seleccion
            DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl SELECTColumn = this.superGridControl1.PrimaryGrid.Columns["SELECTColumn"].EditControl as DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl;

            SIFModelo.OrdenCompra.OrdenesCompraDataSet ordenCompraDS = this.superGridControl1.PrimaryGrid.DataSource as SIFModelo.OrdenCompra.OrdenesCompraDataSet;
            SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETDataTable DetallesNuevaOrden = new SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETDataTable();

            List<DataRow> ordenesSeleccionadas = new List<DataRow>();

            List<int> compradores = new List<int>();

            foreach (DataRow row in ordenCompraDS.V_ORDEN_COMPRA.Rows)
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OCrow = row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
                if (OCrow.SELECCIONADO == "True")
                {
                    ordenesSeleccionadas.Add(OCrow);

                    if (!compradores.Contains(int.Parse(OCrow.USUARIO_ID)))
                    {
                        compradores.Add(int.Parse(OCrow.USUARIO_ID));
                    }
                }


            }

            if (compradores.Count > 1)
            {
               MessageBox.Show("Solo puede unir ordenes de compra del mismo comprador");
                return;
            }

            if (ordenesSeleccionadas.Count() <= 1)
            {
               MessageBox.Show("Debe elegir al menos dos ordenes de compra");
                return;
            }

            int proveedorId = 0;
            foreach (DataRow row in ordenesSeleccionadas)
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow seleccionadoRow = row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;

                if (proveedorId != 0)
                {
                    if (seleccionadoRow.PROVEEDOR_ID != proveedorId)
                    {
                       MessageBox.Show("Solo puede unir ordenes de compra del mismo proveedor");
                        return;
                    }
                }
                else
                {
                    proveedorId = seleccionadoRow.PROVEEDOR_ID;
                }

                if (seleccionadoRow.ESTADO_OC.Trim() != "A")
                {
                   MessageBox.Show("La orden de compra " + seleccionadoRow.FOLIO_OC_ID + " no está activa, solo puede unir ordenes de compra Activas");
                    return;
                }
            }

            foreach (DataRow row in ordenesSeleccionadas)
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow seleccionadoRow = row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;

                foreach (SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow vDetalle in new SIFNegocio.OrdenCompra.OrdenCompra().BuscaOrdenCompraDetalle(seleccionadoRow))
                {

                    SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow detalle = DetallesNuevaOrden.NewORDEN_COMPRA_DETRow();
                    detalle.ARTICULO_ID = vDetalle.ARTICULO_ID;
                    detalle.CANT_DEVUELTA = vDetalle.CANT_DEVUELTA;
                    detalle.CANT_FACTURADA = vDetalle.CANT_FACTURADA;
                    detalle.CANT_MALESTADO = vDetalle.CANT_MALESTADO;
                    detalle.CANT_RECIBIDA = vDetalle.CANT_RECIBIDA;
                    detalle.CANT_REPOSICION = vDetalle.CANT_REPOSICION;
                    detalle.CANT_SOLICITADA = vDetalle.CANT_SOLICITADA;
                    detalle.DESCRIP_OFERTA = vDetalle.DESCRIP_OFERTA;
                    detalle.DESCTO_FACTURA = vDetalle.DESCTO_FACTURA;
                    detalle.DESCTO_FACTURA_AD1 = vDetalle.DESCTO_FACTURA_AD1;
                    detalle.DESCTO_RECIBIDO = vDetalle.DESCTO_RECIBIDO;
                    detalle.DESCTO_RECIBIDO_AD1 = vDetalle.DESCTO_RECIBIDO_AD1;
                    detalle.DESCTO_RECIBIDO_AD2 = vDetalle.DESCTO_RECIBIDO_AD2;
                    detalle.PRECIO_COSTO = vDetalle.PRECIO_COSTO;
                    detalle.PRECIO_FACTURA = vDetalle.PRECIO_FACTURA;
                    detalle.PRECIO_FARMACIA = vDetalle.PRECIO_FARMACIA;
                    //detalle.PUNTO_DE_REORDEN = vDetalle.PUNTO_DE_REORDEN;
                    detalle.ULT_PRECIO_COMPRA = (double)vDetalle.ULT_PRECIO_COMPRA;
                    //detalle.EXISTENCIAS = vDetalle.EXISTENCIAS;
                    detalle.FOLIO_OC_ID = "";
                    detalle.USUARIO_ID = int.Parse(((SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow)row).USUARIO_ID);

                    SIFModelo.Articulo articuloM = new SIFNegocio.Articulo().BuscarPorClave(detalle.ARTICULO_ID);
                    detalle.IMPORTE = detalle.CANT_SOLICITADA * detalle.PRECIO_COSTO;
                    detalle.LABORATORIO_ID = articuloM.LABORATORIO_ID;
                    detalle.PROVEEDOR_ID = proveedorId;

                    detalle.TIPO_MEDICAMENTO_CVE = articuloM.TIPO_MEDICAMENTO_CVE;
                    //detalle.IMPORTE = vDetalle.IMPORTE;

                    DetallesNuevaOrden.AddORDEN_COMPRA_DETRow(detalle);
                }

                //LA CANCELAMOS
                seleccionadoRow.ESTADO_OC = "XY";
                OrdenCompraL.ActualizaOrdenCompra(seleccionadoRow);
            }
            SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(UsuarioId);
            SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow ordenCompraRow = new SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRADataTable().NewORDEN_COMPRARow();

            ordenCompraRow.ESTADO_OC = "A";
            ordenCompraRow.FECHA_ALTA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            ordenCompraRow.FECHA_AUTORIZA = new DateTime();
            ordenCompraRow.FECHA_CIERRE = new DateTime();
            ordenCompraRow.FECHA_RECEPCION = new DateTime();
            ordenCompraRow.FOLIO_OC_ID = "";
            ordenCompraRow.PROVEEDOR_ID = proveedorId;
            ordenCompraRow.SUCURSAL_ID = (short)Helpers.Sesion.Sucursal.SucursalesID;
            ordenCompraRow.USUARIO_ID = usuario.UsuariosID;
            ordenCompraRow.USUARIO_ID_AUTORIZA = "0";

            OrdenCompraL.GuardaOrdenCompra(Helpers.Sesion.Sucursal, usuario, ordenCompraRow, DetallesNuevaOrden, true);
            Buscar();
        }

        private void dividirOrdenCompra()
        {
            if (superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Orden de Compra a dividir");
                return;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow ordenCompra;
            ordenCompra = ((DataRowView)((GridRow)this.superGridControl1.PrimaryGrid.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;

            SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(this.UsuarioId);


            View.OrdenCompra.OrdenCompraUserControl ocu = new View.OrdenCompra.OrdenCompraUserControl(ordenCompra.FOLIO_OC_ID, usuario, true);
            ocu.Owner = this;
            ocu.Muestra();

            //control;

        }

        public int CajaId;
        public int UsuarioId;
        bool loaded = false;
        private void VentasPagoUserControl_Load(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Focus();
            dateTimeInput1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dateTimeInput2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            loaded = true;
            this.Buscar();
        }

        public object Owner { get; set; }

        #region Funciones y Metodos
        private void Editar()
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Orden de Compra a editar");
                return;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            oC.ESTADO_OC = oC.ESTADO_OC.Trim();
            if (oC.ESTADO_OC == "XY")
            {
               MessageBox.Show("La orden de compra seleccionada esta cancelada");
                //return;
            }

            if (oC.ESTADO_OC == "C")
            {
               MessageBox.Show("No puede editar una orden de compra cerrada");
                //return;
            }

            if (oC.ESTADO_OC == "P")
            {
               MessageBox.Show("Esta orden de compra ya fue procesada");
                //return;
            }

            //if (oC.ESTADO_OC.Trim() != "A")
            //{
            //   MessageBox.Show("La orden de compra debe estar abierta para su edición");
            //    //return;
            //}

            SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(this.UsuarioId);
            View.OrdenCompra.OrdenCompraUserControl ocu = new OrdenCompraUserControl(oC.FOLIO_OC_ID, usuario);
            ocu.Owner = this;
            ocu.Muestra();

        }

        internal void Muestra()
        {
            if (Owner is Menu.ComprasMenu)
            {
                Menu.ComprasMenu propietario = Owner as Menu.ComprasMenu;
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;
                this.Mostrado = true;

                //SIF.View.Ventas.AccesoUsuarioForm frmUsuario = new SIF.View.Ventas.AccesoUsuarioForm();
                //if (frmUsuario.ShowDialog() != DialogResult.OK)
                //{
                //    return;
                //}

                this.UsuarioId = Helpers.Sesion.Usuario.UsuariosID;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            }

            if (Owner is Inventario.AjusteAlmacenUserControl)
            {
                Inventario.AjusteAlmacenUserControl propietario = Owner as Inventario.AjusteAlmacenUserControl;
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;
                this.Mostrado = true;

                //SIF.View.Ventas.AccesoUsuarioForm frmUsuario = new SIF.View.Ventas.AccesoUsuarioForm();
                //if (frmUsuario.ShowDialog() != DialogResult.OK)
                //{
                //    return;
                //}

                this.UsuarioId = Helpers.Sesion.Usuario.UsuariosID;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            }
        }


        private void EOQAutomatica()
        {
            if (MessageBoxEx.Show("¿Generar las ordenes de compra a partir del estado del EOQ?", "Generación Automatica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            //CANCELAR TODAS LAS REMISIONES QUE NO HAN SIDO PROCESADAS
            if (this.porEOQAutomaticaBackgroundWorker.IsBusy)
            {
               MessageBox.Show("La Orden de Compra aun se esta procesando");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            porEOQAutomaticaBackgroundWorker.RunWorkerAsync();
        }

        public void ActivaComandos()
        {
            this.backButton.Shortcuts.Add(eShortcut.F12);

            this.editarButtonItem.Shortcuts.Add(eShortcut.F5);
            this.eliminarButtonItem.Shortcuts.Add(eShortcut.F8);
            this.superGridControl1.Focus();

        }

        public void DesactivaComandos()
        {
            this.backButton.Shortcuts.Clear();
            this.editarButtonItem.Shortcuts.Clear();
            this.eliminarButtonItem.Shortcuts.Clear();
        }

        public bool Mostrado { get; set; }

        private void Imprimir()
        {


            var seleccionado = superGridControl1.ActiveRow;

            if (seleccionado == null)
            {
                return;
            }

            string ordenesImpresion = string.Empty;

            foreach (GridRow folioProveedor in seleccionado.GridPanel.Rows)
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow row = ((DataRowView)(folioProveedor.DataItem)).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;

                if (row.SELECCIONADO == "True")
                {
                    ordenesImpresion = ordenesImpresion + "','" + row.FOLIO_OC_ID + "";
                }
            }


            if (string.IsNullOrEmpty(ordenesImpresion))
            {
                if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
                {
                   MessageBox.Show("Elija la Orden de Compra a Imprimir");
                    return;
                }

                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
                SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow ocRow = new SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRADataTable().NewORDEN_COMPRARow();
                ocRow.FOLIO_OC_ID = oC.FOLIO_OC_ID;

                String Parm1 = "{V_ORDENES_COMPRA.FOLIO_OC_ID} = '" + ocRow.FOLIO_OC_ID + "'";
                //string parm2 = "segundo parametro";
                //string parm3 = "tercer parametro";


                SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_OrdenCompra.rpt", Parm1);
                Impresion.ShowDialog();
            }
            else
            {
                //ordenesImpresion = ordenesImpresion.ReplaceAt(7, ' ');
                ordenesImpresion = ordenesImpresion.Remove(0, 2);
                ordenesImpresion = ordenesImpresion + "'";
                String Parm1 = "({V_ORDENES_COMPRA.FOLIO_OC_ID} in [" + ordenesImpresion + "])";

                SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_OrdenCompra.rpt", Parm1);
                Impresion.ShowDialog();
                ordenesImpresion = string.Empty;
            }
        }
        private void ImprimirRptRecepCompra()
        {


            var seleccionado = superGridControl1.ActiveRow;

            if (seleccionado == null)
            {
                return;
            }

            string ordenesImpresion = string.Empty;

            foreach (GridRow folioProveedor in seleccionado.GridPanel.Rows)
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow row = ((DataRowView)(folioProveedor.DataItem)).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;

                if (row.SELECCIONADO == "True")
                {
                    ordenesImpresion = ordenesImpresion + "','" + row.FOLIO_OC_ID + "";
                }
            }

            if (string.IsNullOrEmpty(ordenesImpresion))
            {
                if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
                {
                   MessageBox.Show("Elija la Orden de Compra a Imprimir");
                    return;
                }

                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
                SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow ocRow = new SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRADataTable().NewORDEN_COMPRARow();
                ocRow.FOLIO_OC_ID = oC.FOLIO_OC_ID;

                String Parm1 = "{CS_INCIDENCIAS_RECEPCION_RPT.FOLIO_OC}= '" + ocRow.FOLIO_OC_ID + "'";

                SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Incidencias_Recepcion_Oc.rpt", Parm1);
                Impresion.ShowDialog();
            }

        }
        #endregion

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Buscar();
            // this.Buscar();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Buscar();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
                this.Buscar();
            }
        }

        private void cancelacionAutomaticaButtonItem_Click(object sender, EventArgs e)
        {
            this.EOQAutomatica();
        }

        SIFNegocio.OrdenCompra.OrdenCompra OrdenCompraL = new SIFNegocio.OrdenCompra.OrdenCompra();
        SIFModelo.Cliente Proveedor;

        private void cancelarButtonItem_Click(object sender, EventArgs e)
        {
            this.AgregaArticulo();
        }

        private void eliminarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        private void guardarButtonItem_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }

        private void imprimirButtonItem_Click(object sender, EventArgs e)
        {
            this.Imprimir();
        }

        private void superGridControl1_EndEdit(object sender, GridEditEventArgs e)
        {
            if (e.GridPanel.DataMember == "OrdenCompra")
            {
                if (e.GridCell.GridColumn.DataPropertyName == "CANT_SOLICITADA")
                {
                    SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow rowOrdenCompra = ((DataRowView)((GridRow)e.GridPanel.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow;
                    int cantidad = rowOrdenCompra.CANT_SOLICITADA;
                    decimal precio = (decimal)rowOrdenCompra.ULT_PRECIO_COMPRA;
                    decimal importe = cantidad * precio;
                    rowOrdenCompra.IMPORTE = importe;
                    
                }
            }            

        }

        private void editarButtonItem_Click(object sender, EventArgs e)
        {
            this.Editar();
        }

        private void LiberarButtonItem_Click(object sender, EventArgs e)
        {
            string respuestaLiberada = string.Empty;
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Orden de Compra a para reutilizar");
                return;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            //oC.ESTADO_OC = oC.ESTADO_OC.Trim();
            
            if (oC.ESTADO_OC.ToString() != "CC")
            {
                MessageBox.Show(
                    "La orden de compra debe estar en estado [CC] para hacer la liberacion",
                    "Informacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (!oC.OBSERVACION_OC.Contains("MANDATO"))
            {
                if (DialogResult.Yes
                       ==MessageBox.Show("¿Desea relacionar una nota de credito?", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                       )
                {

                    try
                    {
                        string saldoRQ = new SIFNegocio.OrdenCompra.NotasDecredito().GetSaldoRequeridoOC(oC[16].ToString());

                        frmSelectNotaDeCredito frm = new frmSelectNotaDeCredito(oC[16].ToString(), Convert.ToDecimal(saldoRQ));
                        if (frm.ShowDialog() != DialogResult.OK)
                        {
                            return;

                        }
                    }
                    catch (Exception ex) {
                       MessageBox.Show(ex.ToString(), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                }
                
            }

                bool respuesta = SIFNegocio.OrdenCompra.Compras.ActualziarRecepcionPreciosFolioCompra(oC[16].ToString());

            if (respuesta)
            {
                respuestaLiberada = SIFNegocio.OrdenCompra.Compras.spLiberaOrdenCompra(oC[16].ToString());
                MessageBox.Show(
                    respuestaLiberada,
                    "Informacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                //new SIFNegocio.Sucursales().Buscar("", "S").DataSource as List<SIFModelo.Sucursal>

                //respuestaLiberada = "No se digito la sucursal. Se cancela liberacion";
                //MessageBox.Show(
                //        respuestaLiberada,
                //        "Informacion",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Information);
            }
            if (oC.OBSERVACION_OC.Contains("MANDATO"))
            {
                OrdenCompra.SucursalVirtual frmVirtual = new SucursalVirtual();
                if (frmVirtual.ShowDialog() == DialogResult.OK)
                {
                    
                    DialogResult result = MessageBox.Show(" La sucursal destino es:" + frmVirtual.sucursal.Nombre + " ?. Esta confirmacion liberará la OC y \n creará el traspaso hacia la sucursal\n ,¿Desea continuar?", "Salir", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        string respuestaTraspaso = SIFNegocio.OrdenCompra.Compras.spCreaTraspasos(oC[16].ToString(), frmVirtual.sucursal.SucursalesID.ToString());
                        MessageBox.Show(respuestaTraspaso);

                    }
                }
                else
                {
                    MessageBox.Show("CAncelacion en progreso....la OC no se liberará ni se creará nigún traspaso", MessageBoxIcon.Information.ToString(), MessageBoxButtons.OK);
                }
            }
            this.Buscar();



        }                
        private void CargaSucursalDestino()
        {
            
            //SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { Nombre = "[TODAS]", SucursalesID = 0 };
            //sucursales.Add(sucursal);
            //sucursales.ToList();d
            List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().Buscar("", "S").DataSource as List<SIFModelo.Sucursal>;//L 03/01/2013 PARA QUE SOLO SE MUESTREN LOS ALMACENES ACTIVOS EN SUCURSAL DESTINO

            /// AVM 21-04-2015
            SIFModelo.Sucursal modelSeleccione = new SIFModelo.Sucursal();
            modelSeleccione.Nombre = "SELECCIONE...";
            modelSeleccione.SucursalesID = -1;
            modelSeleccione.SucursalID = -1;

            sucursales.Add(modelSeleccione);
            /// AVM 21-04-2015

            foreach (SIFModelo.Sucursal sucursalBd in sucursalesBD)
            {
                sucursales.Add(sucursalBd);
            }

            //SucursalDestinoComboBox.DataSource = sucursales;
            //SucursalDestinoComboBox.DisplayMember = "NOMBRE";
            //SucursalDestinoComboBox.ValueMember = "SUCURSALESID";
        }
        private void superGridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (Owner is Inventario.AjusteAlmacenUserControl)
            {
                Inventario.AjusteAlmacenUserControl propietario = Owner as Inventario.AjusteAlmacenUserControl;
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow row = ((DataRowView)((GridRow)this.superGridControl1.PrimaryGrid.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
                propietario.DevolucionCompra(row);
                Back();
                return;
            }

            this.Editar();
        }

        private void cerrarButtonItem_Click(object sender, EventArgs e)
        {
            this.Cerrar();
        }


        private void cambiarProveButtonItem_Click(object sender, EventArgs e)
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Orden de Compra a cambiar de proveedor");
                return;
            }
            Usermod = new SIFModelo.Usuario();
            SIF.View.Ventas.AccesoUsuarioForm frmUsuario = new SIF.View.Ventas.AccesoUsuarioForm();
            if (frmUsuario.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Usermod = frmUsuario.Usuario;
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            oC.ESTADO_OC = oC.ESTADO_OC.Trim();
            if (oC.ESTADO_OC == "A" && (Usermod.TipoUsuario == SIFModelo.Tipos.TipoUsuario.ADMINISTRATIVO || Usermod.TipoUsuario == SIFModelo.Tipos.TipoUsuario.VENDENDOR))
            {
                SeleccionaProveedor();
            }
            else
            {
               MessageBox.Show("El cambio de proveedor solo esta permitido en Ordenes de Compra ABIERTAS ( A )y usuarios especificos");
                return;
            }

        }

        private void AsignarModoPagoItem_Click(object sender, EventArgs e)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;

            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija una orden de compra", "Información");
                return;
            }
            OrdenCompra.ModoPagoOC ListMP = new ModoPagoOC();
            if (ListMP.ShowDialog() == DialogResult.OK)
            {

                DialogResult result = MessageBox.Show(" Modo de pago : " + ListMP.MP.nombre + " , \n ¿Desea continuar?", "Salir", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    string respuesta = SIFNegocio.OrdenCompra.Compras.UpdOCModoPago(oC[0].ToString(), ListMP.MP.modo_pago_id.ToString());
                    MessageBox.Show(respuesta);

                }
                else
                {
                    MessageBox.Show("Cancelando asignacion de modo de pago en orden de compra", "Saliendo de Asignacion de modo pago", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else {
                MessageBox.Show("Cancelando asignacion de modo de pago en orden de compra", "Saliendo de Asignacion de modo pago",MessageBoxButtons.OK);
            }



        }

        private void cambiarEstButtonItem_Click(object sender, EventArgs e)
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija una orden de compra", "Información");
                return;
            }

            if (Helpers.Sesion.Usuario.TipoUsuario.ToString() == "ADMINISTRATIVO")
            {
                bool resp = false;
                bool resp2 = false;
                int cantidad = 0;
                string mensaje = "";
                string estado_old = "";
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;

                switch (oC.ESTADO_OC.ToString())
                {
                    case "AC":
                    case "CC":
                    case "L ":
                        resp = new SIFNegocio.OrdenCompra.OrdenCompra().Insertar_ctl_oc(oC.FOLIO_OC_ID.Trim(), Helpers.Sesion.Usuario.UsuariosID.ToString(), Environment.MachineName.ToString(), oC.ESTADO_OC, "E");
                        resp2 = new SIFNegocio.OrdenCompra.OrdenCompra().Actualizar_oc(oC.FOLIO_OC_ID.Trim(), "E");

                        if (resp2)
                           MessageBox.Show("La orden " + oC.FOLIO_OC_ID + " se actualizó a estado E", "Información");
                        else
                           MessageBox.Show("Error, no se actualizó el estado comunicarse con sistemas por favor.", "Información");

                        this.Buscar();
                        break;

                    case "E ":
                        new SIFNegocio.OrdenCompra.OrdenCompra().Verificar_ctl_oc(oC.FOLIO_OC_ID, out mensaje, out cantidad, out estado_old);

                        if (mensaje == "1" && estado_old.Trim() == "L")
                        {
                            new SIFNegocio.OrdenCompra.OrdenCompra().Insertar_ctl_oc(oC.FOLIO_OC_ID.Trim(), Helpers.Sesion.Usuario.UsuariosID.ToString(), Environment.MachineName.ToString(), oC.ESTADO_OC, "L");
                            resp2 = new SIFNegocio.OrdenCompra.OrdenCompra().Actualizar_oc(oC.FOLIO_OC_ID.Trim(), "L");
                            if (resp2)
                               MessageBox.Show("La orden " + oC.FOLIO_OC_ID + " se actualizó a estado L", "Información");

                            this.Buscar();
                        }
                        else
                        {
                            cambiarEstadoButtonItem.Enabled = false;
                            //MessageBoxEx.Show("La orden " + oC.FOLIO_OC_ID + " no se puede regresar a L porque no ha sido liberada.", "Información");
                        }
                        break;

                    default:
                       MessageBox.Show("El estado " + oC.ESTADO_OC + " no se puede cambiar al estado E", "Información");
                        break;
                }

            } 
            else
            {
               MessageBox.Show("Sólo usuarios administrativos pueden cambiar el estado", "Información");
                return;
            }

        }

        private void superGridControl1_click(object sender, EventArgs e)
        {
            int cantidad = 0;
            string mensaje = String.Empty;
            string estado_old = String.Empty;

            try
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
                new SIFNegocio.OrdenCompra.OrdenCompra().Verificar_ctl_oc(oC.FOLIO_OC_ID, out mensaje, out cantidad, out estado_old);

                switch (oC.ESTADO_OC)
                {
                    case "AC":
                    case "CC":
                        if (mensaje == "1" && (estado_old.Trim() == "AC" || estado_old.Trim() == "CC"))
                        {
                            editarButtonItem.Enabled = true;
                            eliminarButtonItem.Enabled = true;
                            unirButtonItem.Enabled = true;
                            dividirButtonItem.Enabled = true;
                            reutilizarButtonItem.Enabled = true;
                            cambiarProveButtonItem.Enabled = true;
                            cambiarEstadoButtonItem.Enabled = false;
                            cambiarEstadoButtonItem.Text = "Cambiar a \r\nEstado Liberada ";
                            cerrarButtonItem.Enabled = true;
                            imprimirButtonItem.Enabled = true;
                            recibirButtonItem.Enabled = true;
                            asociarFacturasButtonItem.Enabled = true;
                            HerramientasButtonItem.Enabled = true;
                            CaducidadesButtonItem.Enabled = true;
                            ModificacionDeLotesYCaducidadItem.Enabled = true;
                            LiberarButtonItem.Enabled = true;
                            ImportarButtonItem.Enabled = true;
                        }
                        else
                        {
                            editarButtonItem.Enabled = true;
                            eliminarButtonItem.Enabled = true;
                            unirButtonItem.Enabled = true;
                            dividirButtonItem.Enabled = true;
                            reutilizarButtonItem.Enabled = true;
                            cambiarProveButtonItem.Enabled = true;
                            cambiarEstadoButtonItem.Enabled = true;
                            cambiarEstadoButtonItem.Text = "Cambiar a \r\nEstado E ";
                            cerrarButtonItem.Enabled = true;
                            imprimirButtonItem.Enabled = true;
                            recibirButtonItem.Enabled = true;
                            asociarFacturasButtonItem.Enabled = true;
                            HerramientasButtonItem.Enabled = true;
                            CaducidadesButtonItem.Enabled = true;
                            ModificacionDeLotesYCaducidadItem.Enabled = true;
                            LiberarButtonItem.Enabled = true;
                            ImportarButtonItem.Enabled = true;
                        }
                        break;

                    case "L ":
                        if (mensaje == "Existe más de una línea")
                        {
                            editarButtonItem.Enabled = true;
                            eliminarButtonItem.Enabled = true;
                            unirButtonItem.Enabled = true;
                            dividirButtonItem.Enabled = true;
                            reutilizarButtonItem.Enabled = true;
                            cambiarProveButtonItem.Enabled = true;
                            cambiarEstadoButtonItem.Enabled = false;
                            cambiarEstadoButtonItem.Text = "Cambiar a \r\nEstado E ";
                            cerrarButtonItem.Enabled = true;
                            imprimirButtonItem.Enabled = true;
                            recibirButtonItem.Enabled = true;
                            asociarFacturasButtonItem.Enabled = true;
                            HerramientasButtonItem.Enabled = true;
                            CaducidadesButtonItem.Enabled = true;
                            ModificacionDeLotesYCaducidadItem.Enabled = true;
                            LiberarButtonItem.Enabled = true;
                            ImportarButtonItem.Enabled = true;
                        }
                        else
                        {
                            editarButtonItem.Enabled = true;
                            eliminarButtonItem.Enabled = true;
                            unirButtonItem.Enabled = true;
                            dividirButtonItem.Enabled = true;
                            reutilizarButtonItem.Enabled = true;
                            cambiarProveButtonItem.Enabled = true;
                            cambiarEstadoButtonItem.Enabled = true;
                            cambiarEstadoButtonItem.Text = "Cambiar a \r\nEstado E ";
                            cerrarButtonItem.Enabled = true;
                            imprimirButtonItem.Enabled = true;
                            recibirButtonItem.Enabled = true;
                            asociarFacturasButtonItem.Enabled = true;
                            HerramientasButtonItem.Enabled = true;
                            CaducidadesButtonItem.Enabled = true;
                            ModificacionDeLotesYCaducidadItem.Enabled = true;
                            LiberarButtonItem.Enabled = true;
                            ImportarButtonItem.Enabled = true;
                        }
                        break;

                    case "E ":
                        if (mensaje == "1" && estado_old.Trim() == "L")
                        {
                            editarButtonItem.Enabled = false;
                            eliminarButtonItem.Enabled = false;
                            unirButtonItem.Enabled = false;
                            dividirButtonItem.Enabled = false;
                            reutilizarButtonItem.Enabled = false;
                            cambiarProveButtonItem.Enabled = false;
                            cambiarEstadoButtonItem.Enabled = true;
                            cambiarEstadoButtonItem.Text = "Cambiar a \r\nEstado Liberada ";
                            cerrarButtonItem.Enabled = false;
                            imprimirButtonItem.Enabled = false;
                            recibirButtonItem.Enabled = false;
                            asociarFacturasButtonItem.Enabled = false;
                            HerramientasButtonItem.Enabled = false;
                            CaducidadesButtonItem.Enabled = false;
                            ModificacionDeLotesYCaducidadItem.Enabled = false;
                            LiberarButtonItem.Enabled = false;
                            ImportarButtonItem.Enabled = false;
                        }
                        else if (mensaje == "1" && (estado_old.Trim() == "AC" || estado_old.Trim() == "CC"))
                        {
                            editarButtonItem.Enabled = true;
                            eliminarButtonItem.Enabled = true;
                            unirButtonItem.Enabled = true;
                            dividirButtonItem.Enabled = true;
                            reutilizarButtonItem.Enabled = true;
                            cambiarProveButtonItem.Enabled = true;
                            cambiarEstadoButtonItem.Enabled = false;
                            cambiarEstadoButtonItem.Text = "Cambiar a \r\nEstado E ";
                            cerrarButtonItem.Enabled = true;
                            imprimirButtonItem.Enabled = true;
                            recibirButtonItem.Enabled = true;
                            asociarFacturasButtonItem.Enabled = true;
                            HerramientasButtonItem.Enabled = true;
                            CaducidadesButtonItem.Enabled = true;
                            ModificacionDeLotesYCaducidadItem.Enabled = true;
                            LiberarButtonItem.Enabled = true;
                            ImportarButtonItem.Enabled = true;
                        }
                        else
                        {
                            editarButtonItem.Enabled = true;
                            eliminarButtonItem.Enabled = true;
                            unirButtonItem.Enabled = true;
                            dividirButtonItem.Enabled = true;
                            reutilizarButtonItem.Enabled = true;
                            cambiarProveButtonItem.Enabled = true;
                            cambiarEstadoButtonItem.Enabled = false;
                            cambiarEstadoButtonItem.Text = "Cambiar a \r\nEstado E ";
                            cerrarButtonItem.Enabled = true;
                            imprimirButtonItem.Enabled = true;
                            recibirButtonItem.Enabled = true;
                            asociarFacturasButtonItem.Enabled = true;
                            HerramientasButtonItem.Enabled = true;
                            CaducidadesButtonItem.Enabled = true;
                            ModificacionDeLotesYCaducidadItem.Enabled = true;
                            LiberarButtonItem.Enabled = true;
                            ImportarButtonItem.Enabled = true;
                        }
                        break;                    

                    default:
                        editarButtonItem.Enabled = true;
                        eliminarButtonItem.Enabled = true;
                        unirButtonItem.Enabled = true;
                        dividirButtonItem.Enabled = true;
                        reutilizarButtonItem.Enabled = true;
                        cambiarProveButtonItem.Enabled = true;
                        cambiarEstadoButtonItem.Enabled = false;
                        cambiarEstadoButtonItem.Text = "Cambiar a \r\nEstado E ";
                        cerrarButtonItem.Enabled = true;
                        imprimirButtonItem.Enabled = true;
                        recibirButtonItem.Enabled = true;
                        asociarFacturasButtonItem.Enabled = true;
                        HerramientasButtonItem.Enabled = true;
                        CaducidadesButtonItem.Enabled = true;
                        ModificacionDeLotesYCaducidadItem.Enabled = true;
                        LiberarButtonItem.Enabled = true;
                        ImportarButtonItem.Enabled = true;
                        break;
                }                

            }
            catch (Exception ex)
            {
               MessageBox.Show("Elija una orden de compra", "Información");
            }
           

        }

        private void reposicionProveButtonItem_Click(object sender, EventArgs e)
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Orden de Compra a aplicar reposicion");
                return;
            }
            Usermod = new SIFModelo.Usuario();
            SIF.View.Ventas.AccesoUsuarioForm frmUsuario = new SIF.View.Ventas.AccesoUsuarioForm();
            if (frmUsuario.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Usermod = frmUsuario.Usuario;

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            oC.ESTADO_OC = oC.ESTADO_OC.Trim();
            if (oC.ESTADO_OC == "L" && (Usermod.TipoUsuario == SIFModelo.Tipos.TipoUsuario.ADMINISTRATIVO || Usermod.TipoUsuario == SIFModelo.Tipos.TipoUsuario.VENDENDOR))
            {


                View.OrdenCompra.ReposicionOrdenCompraDetallesUserControl frmRecepcionl = new ReposicionOrdenCompraDetallesUserControl(oC, Usermod);
                frmRecepcionl.UsuarioId = this.UsuarioId;
                frmRecepcionl.Owner = this;

                //frmRecepcionl.superGridControl1.PrimaryGrid.ReadOnly = true;
                frmRecepcionl.Muestra();
                return;
            }
            else
            {
               MessageBox.Show("La reposicion de proveedor solo esta permitida en Ordenes de Compra PROCESADAS (L) y usuarios especificos");
                return;
            }
        }
        private void devolucionProveButtonItem_Click(object sender, EventArgs e)
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Orden de Compra a devolver");
                return;
            }
            Usermod = new SIFModelo.Usuario();
            SIF.View.Ventas.AccesoUsuarioForm frmUsuario = new SIF.View.Ventas.AccesoUsuarioForm();
            if (frmUsuario.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Usermod = frmUsuario.Usuario;

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            oC.ESTADO_OC = oC.ESTADO_OC.Trim();
            if (oC.ESTADO_OC == "L" && (Usermod.TipoUsuario == SIFModelo.Tipos.TipoUsuario.ADMINISTRATIVO || Usermod.TipoUsuario == SIFModelo.Tipos.TipoUsuario.VENDENDOR))
            {

                //  MessageBox.Show("QUE CHINGA TE POASA");
                View.OrdenCompra.DevolucionOrdenCompraDetallesUserControl frmRecepcionl = new DevolucionOrdenCompraDetallesUserControl(oC, Usermod);
                frmRecepcionl.UsuarioId = this.UsuarioId;
                frmRecepcionl.Owner = this;

                //frmRecepcionl.superGridControl1.PrimaryGrid.ReadOnly = true;
                frmRecepcionl.Muestra();
                return;
            }
            else
            {
               MessageBox.Show("La devolucion a proveedor solo esta permitida en Ordenes de Compra PROCESADAS (L) y usuarios especificos");
                return;
            }
        }


        private void dateTimeInput2_ValueChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void dateTimeInput1_ValueChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void buscarTextBoxX_TextChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void unirButtonItem_Click(object sender, EventArgs e)
        {
            this.Unir();
        }

        private void dividirButtonItem_Click(object sender, EventArgs e)
        {
            dividirOrdenCompra();
        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
            catch { }
        }

        private void statusOrdenCompraComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void cuentasPorPagarbuttonItem_Click(object sender, EventArgs e)
        {
            string folios = "";

            foreach (GridRow row in this.superGridControl1.PrimaryGrid.Rows)
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oc = ((DataRowView)row.DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
                folios += "'" + oc.FOLIO_OC_ID + "',";
            }

            folios = folios.Trim(',');

            if (string.IsNullOrEmpty(folios))
            {
                folios = "'0'";
            }

            string filtro = " {COMPRAS.FOLIO_OC} in [" + folios + "]";
            View.Reportes.frmImpresion frmimp = new Reportes.frmImpresion("RPT_Facturas_Dia_cuentas_por_pagar.rpt", filtro);
            frmimp.ShowDialog();
        }

        private void recibir()
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Orden de Compra a recibir");
                return;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            oC.ESTADO_OC = oC.ESTADO_OC.Trim();

            if (oC.ESTADO_OC != "C" && oC.ESTADO_OC.Trim() != "E")
            {
                string estado_orden = oC.ESTADO_OC;
               MessageBox.Show("Esta orden de compra se encuentra en estado " + estado_orden + " \n Solo se pueden recibir en ordenes de compra en estado C ó E");
                //View.OrdenCompra.RecepcionOrdenCompraDetallesUserControl frmRecepcionl = new RecepcionOrdenCompraDetallesUserControl(oC);
                //frmRecepcionl.UsuarioId = this.UsuarioId;
                //frmRecepcionl.Owner = this;

                //frmRecepcionl.superGridControl1.PrimaryGrid.ReadOnly = true;
                //frmRecepcionl.Muestra();
                return;
            }

            //if (MessageBoxEx.Show("¿Cerrar la orden de compra " + oC.FOLIO_OC_ID + " ?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    return;
            //}

            View.OrdenCompra.RecepcionOrdenCompraDetallesUserControl frmRecepcion = new RecepcionOrdenCompraDetallesUserControl(oC);
            frmRecepcion.UsuarioId = this.UsuarioId;
            frmRecepcion.Owner = this;
            frmRecepcion.Muestra();
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
            string listaProveedores = new SIFNegocio.Usuarios().ListaProveedores(Helpers.Sesion.Usuario);


            //string listaLineas = new SIFNegocio.Compradores()
            frmProveedor.ListaProveedores = listaProveedores.Trim('|');
            frmProveedor.Muestra();
        }

        public void cambiaProveedor(SIFModelo.Cliente newprove)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            oC.ESTADO_OC = oC.ESTADO_OC.Trim();

            new SIFNegocio.OrdenCompra.OrdenCompra().CambiarProveedorOrden(oC.FOLIO_OC_ID.ToString(), newprove);

        }
        private void loteCaducidad()
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Orden de Compra a recibir");
                return;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            oC.ESTADO_OC = oC.ESTADO_OC.Trim();

            if (oC.ESTADO_OC != "C" && oC.ESTADO_OC.Trim() != "E")
            {
               MessageBox.Show("El estado de la orden de compra debe ser cerrada");
                return;
            }

            //if (MessageBoxEx.Show("¿Cerrar la orden de compra " + oC.FOLIO_OC_ID + " ?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    return;
            //}

            View.OrdenCompra.LoteCaducidadDetallesUserControl frmRecepcion = new LoteCaducidadDetallesUserControl(oC);
            frmRecepcion.UsuarioId = this.UsuarioId;
            frmRecepcion.Owner = this;
            frmRecepcion.Muestra();
        }

        private void precios()
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Orden de Compra para asignar precios");
                return;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            oC.ESTADO_OC = oC.ESTADO_OC.Trim();

            if (oC.ESTADO_OC != "E" && oC.ESTADO_OC != "L")
            {
               MessageBox.Show("El estado de la orden de compra debe ser recibido");
                return;
            }

            View.OrdenCompra.AsignacionPreciosOrdenCompraDetallesUserControl frmPrecios = new AsignacionPreciosOrdenCompraDetallesUserControl(oC);
            frmPrecios.UsuarioId = this.UsuarioId;
            frmPrecios.Owner = this;
            frmPrecios.Muestra();
        }

        private void recibirButtonItem_Click(object sender, EventArgs e)
        {
            recibir();
        }

        private void preciosButtonItem_Click(object sender, EventArgs e)
        {
            precios();
        }

        private void asociarFacturasButtonItem_Click(object sender, EventArgs e)
        {
            this.asociaFactura();
        }

        private bool asociaFactura()
        {

            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Orden de Compra a editar");
                return false;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;

            if (oC.ESTADO_OC.Trim() != "C")
            {
               MessageBox.Show("La orden de compra debe estar cerrada");
                return false;
            }

            View.OrdenCompra.NumeroFacturaForm frmFactura = new NumeroFacturaForm(oC);
            if (frmFactura.ShowDialog() == DialogResult.Cancel)
            {
                return false;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow factura = new SIFNegocio.OrdenCompra.OrdenCompra().FacturaPorNumero(frmFactura.NumeroFactura);

            if (factura == null)
            {
               MessageBox.Show("La factura ingresada no existe");
                return false;
            }

            if (factura.ESTADO != "A")
            {
               MessageBox.Show("La factura ingresada no esta activa");
                return false;
            }

            if (oC.PROVEEDOR_ID != factura.PROVEEDOR_ID)
            {
               MessageBox.Show("El proveedor de la factura no coincide con el de la orden de compra");
                return false;
            }

            //SIFModelo.OrdenCompra.OrdenesCompraDataSet.COMPRASRow rowCompras = new SIFModelo.OrdenCompra.OrdenesCompraDataSet().COMPRAS.NewCOMPRASRow();

            //rowCompras.FOLIO_OC = oC.FOLIO_OC_ID;
            //rowCompras.FACTURA = factura.NUM_FACTURA.ToString();
            //rowCompras.DESCUENTO_FACTURADO = 0;
            //rowCompras.DESCUENTO_RECIBIDO = 0;
            //rowCompras.ESTADO = "C";
            //rowCompras.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            //rowCompras.FOLIO_COMPRA = SIFNegocio.OrdenCompra.Compras.FolioCompra(Helpers.Sesion.Sucursal);
            //rowCompras.IMP_DESC_FALTANTE = 0;
            //rowCompras.IMP_FALTANTE = 0;
            //rowCompras.IMPUESTO_FACTURADO = (double)factura.TOTAL_IVA;
            //rowCompras.IMPUESTO_RECIBIDO = 0;
            //rowCompras.PROVEEDOR_ID = factura.PROVEEDOR_ID;
            //rowCompras.SUBTOTAL_FACTURADO = 0;
            //rowCompras.SUBTOTAL_RECIBIDO = 0;
            //rowCompras.TOTAL_FACTURADO = (double)factura.TOTAL_FACTURADO;
            //rowCompras.TOTAL_RECIBIDO = 0;
            //rowCompras.USUARIO_ID = this.UsuarioId.ToString();
            //rowCompras.USUARIO_ID_ASIG_PRECIO = "0";

            //SIFNegocio.OrdenCompra.Compras.Guardar(rowCompras);

            factura.FOLIO_OC = oC.FOLIO_OC_ID;
            new SIFNegocio.OrdenCompra.OrdenCompra().AsociaFactura(factura);

           MessageBox.Show("Factura " + factura.NUM_FACTURA + " se asoció a la orden de compra  " + oC.FOLIO_OC_ID + " correctamente");
            return true;
        }

        private bool desasociaFactura()
        {

            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Orden de Compra a editar");
                return false;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;


            SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow factura = new SIFNegocio.OrdenCompra.OrdenCompra().FacturaPorNumero(oC);

            if (factura == null)
            {
               MessageBox.Show("No se encontó la factura asociada");
                return false;
            }

            //factura.FOLIO_OC = oC.FOLIO_OC_ID;
            new SIFNegocio.OrdenCompra.OrdenCompra().AsociaFactura(oC, factura, factura.ESTADO);

           MessageBox.Show("Factura " + factura.NUM_FACTURA + " ha quedado sin asociación");
            Buscar();
            return true;
        }

        private void facturaAutomaticaButtonItem_Click(object sender, EventArgs e)
        {

            if (this.superGridControl1.PrimaryGrid.Rows.Count == 0)
            {
               MessageBox.Show("No hay ordenes de compra seleccionadas");
                return;
            }

            SIFNegocio.OrdenCompra.OrdenCompra ocL = new SIFNegocio.OrdenCompra.OrdenCompra();
            string mensaje = "";

            ocL.FacturaCoincidenteAutomatica();


            //if (this.superGridControl1.PrimaryGrid.Rows.Count == 0)
            //{
            //   MessageBox.Show("No hay ordenes de compra seleccionadas");
            //    return;
            //}

            //SIFNegocio.OrdenCompra.OrdenCompra ocL = new SIFNegocio.OrdenCompra.OrdenCompra();
            //string mensaje = "";
            //foreach (GridRow grow in this.superGridControl1.PrimaryGrid.Rows)
            //{
            //    SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)(grow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            //    var fac = ocL.FacturaCoincidente(oC);
            //    if (fac == null)
            //    {
            //        if (string.IsNullOrEmpty(mensaje))
            //        {
            //            mensaje = "Las siguientes ordenes de compra no pudieron asociarse: \n";

            //        }

            //        mensaje += " " + oC.FOLIO_OC_ID;
            //        continue;
            //    }


            //    fac.FOLIO_OC = oC.FOLIO_OC_ID;
            //    new SIFNegocio.OrdenCompra.OrdenCompra().AsociaFactura(fac);
            //}

            //if (!string.IsNullOrEmpty(mensaje))
            //{
            //   MessageBox.Show(mensaje);
            //}
            //else
            //{
           MessageBox.Show("Se han asociado las ordenes de compra con la facturas coincidentess");
            //}
        }

        private void loteCaducidadButtonItem_Click(object sender, EventArgs e)
        {
            loteCaducidad();
        }

        private void reutilizarButtonItem_Click(object sender, EventArgs e)
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Orden de Compra a para reutilizar");
                return;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            oC.ESTADO_OC = oC.ESTADO_OC.Trim();


            SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(this.UsuarioId);
            View.OrdenCompra.OrdenCompraUserControl ocu = new View.OrdenCompra.OrdenCompraUserControl(usuario, oC);
            ocu.Owner = this;
            ocu.Muestra();
        }

        private void desAsociarButtonItem_Click(object sender, EventArgs e)
        {
            this.desasociaFactura();
        }

        private void compraProveedorButtonItem_Click(object sender, EventArgs e)
        {

            View.OrdenCompra.CuentasPagarControl ocu = new CuentasPagarControl();
            ocu.Owner = this;
            ocu.Muestra();

            // String Parm1 = "{COMPRAS.FOLIO_COMPRA} = '" + Compra.FOLIO_COMPRA + "'";

            //FechasForm frmFechas = new FechasForm();
            //if (frmFechas.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}

            //string f1 = frmFechas.dateTimeInput1.Value.ToString("yyyy,MM,dd");
            //string f2 = frmFechas.dateTimeInput2.Value.ToString("yyyy,MM,dd");

            //SIFNegocio.Usuarios Logusu = new SIFNegocio.Usuarios();
            //SIFModelo.Usuario Vend = Helpers.Sesion.Usuario;
            //SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Pagos_mayoristas.rpt", "  DATE({CS_FACTURAS_COMPRAS.FECHA}) >= DATE('" + f1 + "')  AND  DATE({CS_FACTURAS_COMPRAS.FECHA}) <=  DATE('" + f2 + "') ");
            //Impresion.ShowDialog();
        }
        private void IncidenciasButtonItem_Click(object sender, EventArgs e)
        {
            View.OrdenCompra.IncidenciasCompras ocu = new IncidenciasCompras();
            ocu.Owner = this;
            ocu.Muestra();

        }

        //Se comentan las lineas por Reporte Obsoleto, solicitud de IVAN 20/Jun/2025
        //private void talonDePagoButtonItem_Click(object sender, EventArgs e)
        //{
        //    if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
        //    {

        //       MessageBox.Show("Elija la Orden de Compra procesada");
        //        return;
        //    }

        //    var select = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
        //    Imprimir(select.FOLIO_OC_ID, "Talón de pago");
        //}

        private void OrdenCompraCaducidadesItem_Click(object sender, EventArgs e)//Agregarle Leyenda
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {

               MessageBox.Show("Elija la Orden de Compra procesada");
                return;
            }

            var select = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            Imprimir2(select.FOLIO_OC_ID, "ORDEN DE COMPRA CON CADUCIDADES");
        }

        private void Imprimir(String StrCual, String StrTipo)
        {
            ///oBTENER EL ELEMENTO SELECCIONADO DEL GRID 
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_TalonCDIS.rpt", " {CS_TALON_CDIS.FOLIO_OC}='" + StrCual + "'", StrTipo);
            Impresion.ShowDialog();
        }

        private void Imprimir2(String StrCual, String StrTipo)
        {
            ///oBTENER EL ELEMENTO SELECCIONADO DEL GRID 
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_OrdenCompraCaducidades.rpt", " {V_ORDENES_COMPRACADU.FOLIO_OC_id}='" + StrCual + "'", StrTipo);
            Impresion.ShowDialog();
        }
        private void IncidenciasRecepcionButtonItem_Click(object sender, EventArgs e)
        {

            this.ImprimirRptRecepCompra();
        }
        private void ControlCaducidadesButtonItem_Click(object sender, EventArgs e)
        {
            this.controlCaducidades();
        }
        private void controlCaducidades()
        {

            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Orden de Compra a para reutilizar");
                return;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            //oC.ESTADO_OC = oC.ESTADO_OC.Trim();



            SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(this.UsuarioId);

/*#if !DEBUG
            if (oC.ESTADO_OC.ToString() != "L ")
                {
                    MessageBox.Show("La orden de compra tiene que estar liberada [L]");
                    return;
                }
             //controlCaducidadesUserControl frmCc = new controlCaducidadesUserControl(usuario, oC[16].ToString());

             //controlCaducidadesUserControl frmCc = new controlCaducidadesUserControl();
             //frmCc.Owner = this;
             //frmCc.Muestra();
            Inventario.frmCapturaCaducidades frm = new Inventario.frmCapturaCaducidades(usuario, oC[16].ToString(),11);
            frm.ShowDialog();

#else*/
            if (oC.ESTADO_OC.ToString() != "AC")
            {
                MessageBox.Show(
                    "La orden de compra tiene que estar en Asignacion de Caducidades  [AC]",
                    "Informacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            controlCaducidadesUserControl frmCc = new controlCaducidadesUserControl(usuario, oC[16].ToString());
            frmCc.Owner = this;
            frmCc.Muestra();

            
//#endif



        }

        private void CompraConAjusteButtonItem_Click(object sender, EventArgs e)
        {
            frmAjustesJHup frm = new frmAjustesJHup();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                /*
                if (frm.dt.Rows.Count > 0)
                {

                    OrdenCompra.OrdenCompraUserControl modulo = new OrdenCompra.OrdenCompraUserControl();
                    SIFModelo.Cliente cliente = new SIFModelo.Cliente();
                    SIFModelo.Articulo articulo = new SIFModelo.Articulo();
                    SIFNegocio.OrdenCompra.OrdenCompra ocl = new SIFNegocio.OrdenCompra.OrdenCompra();

                    //SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow existente = null;

                    //PIT 13/09/2021 SE ASIGNA EL PROVEEDOR 99091 A TODAS LAS ORDENES DE COMPRA POR AJUSTE DE HUP
                    cliente.ID = 99091;
                    cliente.Nombre = "UNIVERSIDAD AUTONOMA DE PUEBLA (P)";
                    modulo.Owner = this;
                    modulo.usuario = Helpers.Sesion.Usuario;
                    modulo.Muestra();
                    modulo.AgregaProveedor(cliente);

                    DataTable _dt = frm.dt;
                    int cant = 0;
                    string art = "";
                    decimal precio = 0;
                    string folio = "", nombre = "";
                    string oficio = "";

                    modulo.BloqueaCheckbox();

                    foreach (DataRow r in frm.dt.Rows)
                    {
                        articulo.ARTICULO_ID = r["ARTICULO_ID"].ToString();
                        art = articulo.ARTICULO_ID;
                        cant = Convert.ToInt32(r["CANTIDAD"]);
                        precio = Convert.ToDecimal(r["PRECIO"]);
                        nombre = r["DESC_1"].ToString();
                        //modulo.AgregaArticulo(articulo);
                        folio = r["FOLIO"].ToString();
                        oficio = r["REFERENCIA"].ToString();

                        modulo.AgregaArticulosAjuste(art, cant, precio, nombre);
                    }

                    modulo.TerminaOrdenConAjuste(folio, oficio);



                    modulo.guardarOrdenAjuste();


                    







                }
                */
            }
        }
        private void ModificacionDeLotesYCaducidad_Click(object sender, EventArgs e)
        {
            string tipo_mov = "11";//desde la ventana orden de compra
            //selecciona una linea del grid

            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija una Orden de Compra");
                return;
            }

            //obtiene los datos restantes del grid
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row 
            as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            //oC.ESTADO_OC = oC.ESTADO_OC.Trim();

        
            ModificacionLotesCaducidades frm_lotes = new ModificacionLotesCaducidades();
            frm_lotes._folio = oC.FOLIO_OC_ID;
            frm_lotes._tipo_mov = tipo_mov;
            frm_lotes._usuario = Helpers.Sesion.Usuario.UsuariosID.ToString();
            


            if (frm_lotes.validParametro())
            {
                if (oC.ESTADO_OC.Trim() == "L")
                {
                    frm_lotes.LlenadoDatos(); //llena los datos en el form

                    if (frm_lotes.ShowDialog() == DialogResult.OK)
                    {
                        
                        //MessageBoxEx.Show("Entro a la condicion");
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Solo esta permitido en Ordenes de compra Liberadas (L)",
                        "Informacion",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show(
                    "Esta funcion no esta activada",
                    "Informacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
            }
        }

        private void ImportarButtonItem_Click(object sender, EventArgs e)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            
            if (oC.ESTADO_OC.Trim() != "E")
            {
                MessageBox.Show(
                    "La orden de compra debe estar en estado [E] para hacer la importación",
                    "Informacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string numOrden = oC.FOLIO_OC_ID;
            if (SIFNegocio.OrdenCompra.Compras.ExisteOrden(numOrden))
            {
                MessageBox.Show(
                    $"La orden {numOrden} ya fue importada previamente y no puede volver a importarse.",
                    "Orden ya importada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(
                 "El archivo CSV debe contener exactamente 4 columnas en este orden:\n\n" +
                 "1. ARTICULO\n" +
                 "2. CANTIDAD\n" +
                 "3. PRECIO_FACTURA\n" +
                 "4. NUM_FACTURA",
                 "Formato requerido",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
             );

             OpenFileDialog openFileDialog = new OpenFileDialog();
             openFileDialog.Filter = "CSV files (*.csv)|*.csv";
             openFileDialog.Title = "Seleccionar archivo CSV";

             if (openFileDialog.ShowDialog() == DialogResult.OK)
             {
                string filePath = openFileDialog.FileName;

                DataTable dataTable = CargarCSV(filePath);
                if (dataTable == null)
                    return;

                string rutaArchivo = openFileDialog.FileName;
                int totalFilas = dataTable.Rows.Count;

                try
                {
                     string userId = Helpers.Sesion.Usuario.UsuariosID.ToString();
                     string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                     string resultado =  SIFNegocio.OrdenCompra.Compras.InsertarAuditoria(userId, fecha, numOrden, totalFilas.ToString(), rutaArchivo);
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Error al registrar en TBL_IMPORTA_CSV_OC: " + ex.Message);
                 }

                try
                {
                    List<string> articulos = new List<string>();
                    List<decimal> cantidades = new List<decimal>();
                    List<decimal> precios = new List<decimal>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        articulos.Add(row["ARTICULO"].ToString());
                        cantidades.Add(Convert.ToDecimal(row["CANTIDAD"]));
                        precios.Add(Convert.ToDecimal(row["PRECIO_FACTURA"]));
                    }

                    string numCompra = oC.FOLIO_OC_ID;

                    string resultado = SIFNegocio.OrdenCompra.Compras.ValidarComprasDet(numCompra, articulos);
                    if (resultado.Contains("no están"))
                    {
                        MessageBox.Show(resultado, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(resultado, "Validación Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    string numFactura = dataTable.Rows[0][3].ToString();
                    SIFNegocio.OrdenCompra.Compras.ActualizarComprasDetMasivo(articulos,cantidades,precios, numCompra, numFactura);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al importar y actualizar: " + ex.Message,
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
             }
            
        }

        private DataTable CargarCSV(string filePath)
        {
            
            SIFNegocio.Articulo art = new SIFNegocio.Articulo();

            DataTable dtPedido = new DataTable();

            // Crear columnas fijas
            dtPedido.Columns.Add("ARTICULO");
            dtPedido.Columns.Add("CANTIDAD");
            dtPedido.Columns.Add("PRECIO_FACTURA");
            dtPedido.Columns.Add("NUM_FACTURA");

            StreamReader reader = null;
            try
            {
                reader = new StreamReader(filePath, System.Text.Encoding.GetEncoding("iso-8859-1"));
                string str;
                List<string> listaInexistentes = new List<string>();
                HashSet<string> seen = new HashSet<string>();
                HashSet<string> listaDuplicados = new HashSet<string>();

                int lineNumber = 0;
                while ((str = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    string[] cols = str.Split(',');

                    // Validar que tenga 4 columnas
                    if (cols.Length != 4)
                    {
                        MessageBox.Show("El archivo no cuenta con el formato correcto.",
                                        "Formato incorrecto",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return null; // Detener procesamiento
                    }

                    string codigo = cols[0].Trim();

                    // Validar existencia del artículo en catálogo
                    SIFModelo.Articulo exs = art.BuscarPorClave(codigo);
                    if (exs == null)
                    {
                        listaInexistentes.Add(codigo);
                    }

                    // Validar duplicados dentro del archivo
                    if (seen.Contains(codigo))
                    {
                        listaDuplicados.Add(codigo);
                    }
                    else
                    {
                        seen.Add(codigo);
                    }

                    // Validar que PRECIO_FACTURA sea numérico
                    if (!decimal.TryParse(cols[2], out decimal precio))
                    {
                        MessageBox.Show($"El precio '{cols[2]}' no es válido en la línea {lineNumber}.",
                                        "Formato incorrecto",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return null;
                    }

                    // Agregar fila al DataTable
                    dtPedido.Rows.Add(codigo, cols[1].Trim(), precio, cols[3].Trim());
                }

                reader.Close();

                // Mostrar artículos inexistentes
                if (listaInexistentes.Count > 0)
                {
                    string msg = "No existen los códigos:\n" + string.Join(Environment.NewLine, listaInexistentes);
                    MessageBox.Show(msg, "Artículos no encontrados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                // Mostrar duplicados
                if (listaDuplicados.Count > 0)
                {
                    string msg = "Se encontraron códigos duplicados:\n" + string.Join(Environment.NewLine, listaDuplicados);
                    MessageBox.Show(msg, "Duplicados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                return dtPedido; // Todo válido, retornar DataTable
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                reader?.Close();
            }
        }
    }
}
