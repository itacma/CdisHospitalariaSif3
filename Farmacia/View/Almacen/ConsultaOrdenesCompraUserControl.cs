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

namespace SIF.View.Almacen
{
    public partial class ConsultaOrdenesCompraUserControl : Templates.ListaUserControl
    {
        public ConsultaOrdenesCompraUserControl()
        {
            InitializeComponent();
            this.inicializaTabla();
            estadosOrdenesCompra();
            Privilegios();
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

        private void Back()
        {
            try
            {
                if (this.Mostrado && Owner.Owner.IsModalPanelDisplayed)
                {
                    //this.DesactivaComandos();
                    try
                    {
                        if (Owner.Owner.Contains(this))
                        {
                            Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        this.Owner.ActivaComandos();
                        this.Mostrado = false;
                        this.DesactivaComandos();
                    }
                    catch
                    {

                    }
                }
            }
            catch { }
        }

        public void inicializaTabla()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            superGridControl1.DataBindingComplete += SuperGridControl1DataBindingComplete;
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
            statusOC.Add("ASIGNACION DE CADUCIDADES", "AC");
            statusOC.Add("ASIGNACION DE CADUCIDADES FINALIZADA", "CC");
            statusOC.Add("AUTORIZADA LISTA PARA ASIGNACION DE PRECIOS", "E");
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

        private void Buscar()
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
            OrdenCompraL.dsOrdenesCompraDT = OrdenCompraL.BuscaOrdenCompra(this.buscarTextBoxX.Text, dateTimeInput1.Value, dateTimeInput2.Value, statusOc);

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

            foreach (GridRow folioProveedor in seleccionado.GridPanel.GetSelectedRows())
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow row = ((DataRowView)(folioProveedor.DataItem)).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
                row.ESTADO_OC = "XY";
                new SIFNegocio.OrdenCompra.OrdenCompra().ActualizaOrdenCompra(row);

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

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            oC.ESTADO_OC = oC.ESTADO_OC.Trim();

            if (oC.ESTADO_OC != "A")
            {
               MessageBox.Show("El estado de la orden de compra debe ser abierto");
                return;
            }

            View.Ventas.AccesoUsuarioForm frmAcceso = new Ventas.AccesoUsuarioForm();

            SIFModelo.Usuario usuario = new SIFModelo.Usuario();

            if (MessageBoxEx.Show("¿Cerrar la orden de compra " + oC.FOLIO_OC_ID + " ?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            if (frmAcceso.ShowDialog() == DialogResult.OK)
            {
                usuario = frmAcceso.Usuario;
            }
            else
            {
                return;
            }

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

            foreach (DataRow row in ordenCompraDS.V_ORDEN_COMPRA.Rows)
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OCrow = row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
                if (OCrow.SELECCIONADO == "True")
                {
                    ordenesSeleccionadas.Add(OCrow);
                }
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


                    SIFModelo.Articulo articuloM = new SIFNegocio.Articulo().BuscarPorClave(detalle.ARTICULO_ID);
                    detalle.IMPORTE = detalle.CANT_SOLICITADA * detalle.PRECIO_COSTO;
                    detalle.LABORATORIO_ID = articuloM.LABORATORIO_ID;
                    detalle.PROVEEDOR_ID = proveedorId;

                    detalle.TIPO_MEDICAMENTO_CVE = articuloM.TIPO_MEDICAMENTO_CVE;
                    //detalle.IMPORTE = vDetalle.IMPORTE;

                    DetallesNuevaOrden.AddORDEN_COMPRA_DETRow(detalle);
                }

                //LA CANCELAMOS
                seleccionadoRow.ESTADO_OC = "C";
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
            ordenCompraRow.USUARIO_ID = UsuarioId;
            ordenCompraRow.USUARIO_ID_AUTORIZA = "0";

            OrdenCompraL.GuardaOrdenCompra(Helpers.Sesion.Sucursal, usuario, ordenCompraRow, DetallesNuevaOrden, true);
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
            dateTimeInput1.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, 0, 0, 0);
            dateTimeInput2.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            loaded = true;
        }

        public SIF.View.Almacen.RecepcionUserControl Owner { get; set; }

        #region Funciones y Metodos

        internal void Muestra()
        {
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;


            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
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
        }

        public void DesactivaComandos()
        {
            this.backButton.Shortcuts.Clear();
        }

        public bool Mostrado { get; set; }

        private void Imprimir()
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Orden de Compra a Imprimir");
                return;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
            SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow ocRow = new SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRADataTable().NewORDEN_COMPRARow();
            ocRow.FOLIO_OC_ID = oC.FOLIO_OC_ID;

            //Reportes.OrdenCompra.OrdenCompraForm frmOrdenCompra = new Reportes.OrdenCompra.OrdenCompraForm(ocRow);
            //frmOrdenCompra.Show();
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



        private void superGridControl1_DoubleClick(object sender, EventArgs e)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow ordenCompra;
            ordenCompra = ((DataRowView)((GridRow)this.superGridControl1.PrimaryGrid.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;


            Owner.AgregaOrdenCompra(ordenCompra);
            this.Back();
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

        private void statusOrdenCompraComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }




    }
}
