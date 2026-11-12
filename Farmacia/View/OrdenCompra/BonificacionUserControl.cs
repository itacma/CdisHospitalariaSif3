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
    public partial class BonificacionUserControl : Templates.ListaUserControl
    {
      
        SIFNegocio.Inventario.Bonificaciones bon = new SIFNegocio.Inventario.Bonificaciones();
        public string tipo_mov = "";
        public BonificacionUserControl()
        {
            InitializeComponent();
            this.inicializaTabla();
        }

        #region Formato Grid

        public void inicializaTabla()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            superGridControl1.DataBindingComplete += SuperGridControl1DataBindingComplete;
        }

        void SuperGridControl1DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            if (radioButtonBon.Checked == true)
            {
                //BONFICIACION();

                if (panel.DataMember == "BONIFICACION_DET")
                {
                    CustomizeDetailsPanel(panel);
                }
            }
            if (radioButtonDev.Checked == true)
            {

                if (panel.DataMember == "DevolucionDetalles")
                {
                    CustomizeDetailsPanelDe(panel);
                    CustomizeDetailsPanelDe(panel);
                    for (int i = 6; i < panel.Columns.Count; i++)
                    {
                       // panel.Columns[i].Visible = false;
                    }
                }
                if (panel.DataMember == "Devolucion")
                {
                    //CustomizeDetailsPanelDe(panel);
                    CustomizeDetailsPanelDe(panel);
                    for (int i = 0; i < panel.Columns.Count; i++)
                    {
                        panel.Columns[i].Visible = true;
                    }
                }
            }
        }
        private void CustomizeDetailsPanelDe(GridPanel panel)
        {
            panel.AutoGenerateColumns = true;
        }
        private void CustomizeDetailsPanel(GridPanel panel)
        {
            panel.AutoGenerateColumns = false;
            panel.Columns.Clear();

            GridColumn FolioColumn = new GridColumn("FolioColumn");
            FolioColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            FolioColumn.HeaderText = "FOLIO";
            FolioColumn.DataPropertyName = "FOLIO";
            FolioColumn.Width = 100;
            FolioColumn.Visible = false;
            panel.Columns.Add(FolioColumn);

            GridColumn LoteColumn = new GridColumn("LoteColumn");
            LoteColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            LoteColumn.HeaderText = "LOTE";
            LoteColumn.DataPropertyName = "LOTE";
            LoteColumn.Width = 100;
            LoteColumn.Visible = false;
            panel.Columns.Add(LoteColumn);

            GridColumn SucursalIDColumn = new GridColumn("SucursalIDColumn");
            SucursalIDColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            SucursalIDColumn.HeaderText = "SUCURSAL_ID";
            SucursalIDColumn.DataPropertyName = "SUCURSAL_ID";
            SucursalIDColumn.Width = 70;
            SucursalIDColumn.Visible = false;
            panel.Columns.Add(SucursalIDColumn);
            
            GridColumn NumeroPartidaColumn = new GridColumn("NumeroPartidaColumn");
            FolioColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            NumeroPartidaColumn.HeaderText = "PARTIDA";
            NumeroPartidaColumn.DataPropertyName = "NUM_PARTIDA";
            NumeroPartidaColumn.Width = 100;
            panel.Columns.Add(NumeroPartidaColumn);

            GridColumn ArticuloColumn = new GridColumn("ArticuloColumn");
            ArticuloColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            ArticuloColumn.HeaderText = "CLAVE";
            ArticuloColumn.DataPropertyName = "ARTICULO_ID";
            ArticuloColumn.Width = 100;
            panel.Columns.Add(ArticuloColumn);

            GridColumn CantidadColumn = new GridColumn("CantidadColumn");
            CantidadColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            CantidadColumn.HeaderText = "CANTIDAD";
            CantidadColumn.DataPropertyName = "CANTIDAD";
            CantidadColumn.Width = 80;
            panel.Columns.Add(CantidadColumn);

            GridColumn PrecioColumn = new GridColumn("PrecioColumn");
            PrecioColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            PrecioColumn.HeaderText = "PRECIO";
            PrecioColumn.DataPropertyName = "PRECIO";
            PrecioColumn.Width = 100;
            panel.Columns.Add(PrecioColumn);

            GridColumn Nombre1Column = new GridColumn("Nombre1Column");
            Nombre1Column.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            Nombre1Column.HeaderText = "NOMBRE";
            Nombre1Column.DataPropertyName = "NOMBRE1";
            Nombre1Column.Width = 200;
            //Nombre1Column.ReadOnly = false;
            panel.Columns.Add(Nombre1Column);

            GridColumn PrecioVentaColumn = new GridColumn("PrecioVentaColumn");
            PrecioVentaColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            PrecioVentaColumn.HeaderText = "PRECIO VTA";
            PrecioVentaColumn.DataPropertyName = "PRECIO_VTA";
            PrecioVentaColumn.Width = 100;
            panel.Columns.Add(PrecioVentaColumn);

            GridColumn ConceptoColumn = new GridColumn("ConceptoColumn");
            ConceptoColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            ConceptoColumn.HeaderText = "CONCEPTO";
            ConceptoColumn.DataPropertyName = "CONCEPTO";
            ConceptoColumn.Width = 200;
            panel.Columns.Add(ConceptoColumn);



            GridColumn Nombre2Column = new GridColumn("Nombre2Column");
            Nombre2Column.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            Nombre2Column.HeaderText = "NOMBRE";
            Nombre2Column.DataPropertyName = "NOMBRE2";
            Nombre2Column.Width = 200;
            //Nombre1Column.ReadOnly = false;
            panel.Columns.Add(Nombre2Column);



        }
        private void BONFICIACION()
        {/*
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BonificacionUserControl));
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            gridColumn1.DataPropertyName = "FOLIO";
            gridColumn1.DefaultNewRowCellValue = ((object)(resources.GetObject("gridColumn1.DefaultNewRowCellValue")));
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn1.HeaderText = "FOLIO";
            gridColumn1.Name = "FOLIOColumn";
            gridColumn1.Width = 130;
            gridColumn2.DataPropertyName = "LOTE";
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn2.HeaderText = "LOTE";
            gridColumn2.Name = "LOTEColumn";
            gridColumn2.Width = 80;
            gridColumn3.DataPropertyName = "CAT_SUCURSALES_NOMBRE";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn3.HeaderText = "SUCURSAL";
            gridColumn3.Name = "SUCURSALColumn";
            gridColumn3.Width = 120;
            gridColumn4.DataPropertyName = "FECHA_REG";
            gridColumn4.DefaultNewRowCellValue = ((object)(resources.GetObject("gridColumn4.DefaultNewRowCellValue")));
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn4.HeaderText = "REGISTRO";
            gridColumn4.Name = "FECHA_REGISTROColumn";
            gridColumn4.Width = 130;
            gridColumn5.DataPropertyName = "TOTAL";
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn5.HeaderText = "TOTAL";
            gridColumn5.Name = "TOTALColumn";
            gridColumn6.DataPropertyName = "CONCEPTO";
            gridColumn6.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn6.FillWeight = 140;
            gridColumn6.HeaderText = "CONCEPTO";
            gridColumn6.Name = "CONCEPTOColumn";
            gridColumn7.DataPropertyName = "DOC_REFERENCIA";
            gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn7.HeaderText = "REFERENCIA";
            gridColumn7.Name = "DOCUMENTO_REFERENCIAColumn";
            gridColumn8.DataPropertyName = "CAT_USUARIOS_NOMBRE";
            gridColumn8.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn8.HeaderText = "USUARIO";
            gridColumn8.Name = "USUARIO_NOMBREColumn";
            gridColumn9.DataPropertyName = "ACTIVO";
            gridColumn9.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn9.HeaderText = "ACTIVO";
            gridColumn9.Name = "ACTIVOColumn";
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn7);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn8);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn9);*/
        }

        private void reiniciaGrid()
        {
            superGridControl1.PrimaryGrid.Columns.Clear();
            inicializaTabla();
            /*
            splitContainer1.Panel2.Controls.Add(this.superGridControl1);
            
           superGridControl1.PrimaryGrid.Columns.Clear();*/
            /*
                superGridControl1 =  new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
                       this.superGridControl1.Location = new System.Drawing.Point(0, 0);
                       this.superGridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
                       this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
                       superGridControl1.PrimaryGrid.AutoGenerateColumns = true;
                       superGridControl1.BackColor = System.Drawing.Color.White;
                       superGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                       superGridControl1.ForeColor = System.Drawing.Color.Black;
                       superGridControl1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
                       superGridControl1.Name = "superGridControl1";
                       superGridControl1.TabIndex = 0;
                       superGridControl1.Text = "Artículos";
                       superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);*/


            // this.superGridControl1.Refresh();
            /*
            superGridControl1.PrimaryGrid.AutoGenerateColumns = true;
            superGridControl1.BackColor = System.Drawing.Color.White;
            superGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            superGridControl1.ForeColor = System.Drawing.Color.Black;
            superGridControl1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            superGridControl1.Location = new System.Drawing.Point(0, 0);
            superGridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            superGridControl1.Name = "superGridControl1";
            superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            superGridControl1.Size = new System.Drawing.Size(915, 489);
            superGridControl1.TabIndex = 0;
            superGridControl1.Text = "Artículos";
            superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);*/
            
            
        }

        #endregion

        private SIFNegocio.OrdenCompra.OrdenCompra ordenCompraL = new SIFNegocio.OrdenCompra.OrdenCompra();
        //List<SIFModelo.OrdenCompra.DevProveedor> detallesDev;
       // DataSet detallesDev;
        DataSet detallesDev;
        private void buscarCabeceras()
        {
            try
            {
                if (radioButtonBon.Checked == true)
                {
                      reiniciaGrid();
                   
                    //superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
                      DataSet bonificaiones = new DataSet();
                      bonificaiones = SIFNegocio.OrdenCompra.Compras.BuscaBonificacion(this.buscarTextBoxX.Text, inicioDateTimeInput.Value, finDateTimeInput.Value); 
                    //ordenCompraL.Bonificaciones(this.buscarTextBoxX.Text, inicioDateTimeInput.Value, finDateTimeInput.Value);
                      bonificaiones.Relations.Add("1", bonificaiones.Tables["BONIFICACION"].Columns["FOLIO"],
                                           bonificaiones.Tables["BONIFICACION_DET"].Columns["FOLIO"], false);
                    this.superGridControl1.PrimaryGrid.DataSource = bonificaiones;
                   // this.superGridControl1.PrimaryGrid.DataMember = "BONIFICACION";
                }
                else if (radioButtonDev.Checked == true)
                {
                    detallesDev = new DataSet();
                      reiniciaGrid();
                   
                    detallesDev = SIFNegocio.OrdenCompra.Compras.BuscaDevProveedor(this.buscarTextBoxX.Text, inicioDateTimeInput.Value, finDateTimeInput.Value);
                    //  this.superGridControl1.PrimaryGrid.DataSource = detallesDev;// ordenCompraL.Bonificaciones(this.buscarTextBoxX.Text, inicioDateTimeInput.Value, finDateTimeInput.Value);

                    detallesDev.Relations.Add("1", detallesDev.Tables["Devolucion"].Columns["devolucion_id"],
                                          detallesDev.Tables["DevolucionDetalles"].Columns["devolucion_id"], false);
                    /*detallesDev.Relations.Add("1", detallesDev.Tables["Devolucion"].Columns["articulo_id"],
                                             detallesDev.Tables["DevolucionDetalles"].Columns["articulo_id"], false);*/

                    //this.bindingSource.DataSource = DsRemisiones;

                    this.superGridControl1.PrimaryGrid.DataSource = detallesDev;
                    //superGridControl1.PrimaryGrid.AutoGenerateColumns = true;
                   // this.superGridControl1.PrimaryGrid.DataMember = "Devolucion";
                }
                else if (radioButtonRep.Checked == true)
                {
                     reiniciaGrid();
                   
                    detallesDev = SIFNegocio.OrdenCompra.Compras.BuscaRepProveedor(this.buscarTextBoxX.Text, inicioDateTimeInput.Value, finDateTimeInput.Value);

                     detallesDev.Relations.Add("1", detallesDev.Tables["Reposicion"].Columns["reposicion_id"],
                                           detallesDev.Tables["ReposicionDetalles"].Columns["reposicion_id"], false);
                     this.superGridControl1.PrimaryGrid.DataSource = detallesDev;
                }
                else
                    MessageBox.Show("Selecciona Un Tipo De Movimiento A Buscar (Devolucion - Bonificacion - Reposicion) ");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: "+e.ToString());
            }
           // this.superGridControl1.PrimaryGrid.DataMember = "BONIFICACION";
        }

        private void NuevaBonificacion()
        {
            BonificacionDetallesUserControl detalles = new BonificacionDetallesUserControl();
            detalles.Owner = this;
            detalles.UsuarioId = this.UsuarioId;
            detalles.Muestra();
        }


        private void buscarButtonX_Click(object sender, EventArgs e)
        {
                this.buscarCabeceras();
        }

        public Menu.ComprasMenu Owner { get; set; }

        internal void Muestra()
        {
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;

            SIF.View.Ventas.AccesoUsuarioForm frmUsuario = new SIF.View.Ventas.AccesoUsuarioForm();
            if (frmUsuario.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.UsuarioId = frmUsuario.Usuario.UsuariosID;

            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }

        private void Back()
        {
            try{
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

        public void ActivaComandos()
        {
            this.backButton.Shortcuts.Add(eShortcut.F12);
        }
        public void DesactivaComandos()
        {
            this.backButton.Shortcuts.Clear();
        }

        public bool Mostrado { get; set; }

        public int UsuarioId { get; set; }

        private void recibirButtonItem_Click(object sender, EventArgs e)
        {
            this.NuevaBonificacion();
        }

        private void buscarTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.buscarCabeceras();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
                this.buscarCabeceras();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void RecepcionOrdenCompraUserControl_Load(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Focus();
            this.inicioDateTimeInput.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, 1);
            this.finDateTimeInput.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, DateTime.DaysInMonth(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month) );
          //  this.buscarCabeceras();
        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }
        }

        private void imprimirButtonItem_Click(object sender, EventArgs e)
        {
            string movimiento = "Movimiento";
            if (radioButtonBon.Checked == true)
            {
                movimiento = "Bonificacion";
            }
            else if (radioButtonDev.Checked == true)
            {
                movimiento = "Devolucion";
            }
            else if (radioButtonRep.Checked == true)
            {
                movimiento = "Reposicion";
            }

            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la " + movimiento + " a Imprimir");
                return;
            }

            GridPanel panel = superGridControl1.PrimaryGrid;
            if (panel.ActiveRow == null)
            {
                return;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Seleccione la cabecera de la " + movimiento);
                return;
            }
            var row = (GridRow)container;

           // SIFModelo.OrdenCompra.OrdenesCompraDataSet.BONIFICACIONRow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.BONIFICACIONRow;
        //    SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow ocRow = new SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRADataTable().NewORDEN_COMPRARow();
        //    ocRow.FOLIO_OC_ID = oC.FOLIO_OC_ID;


            //Dictionary<string, object> dic = new Dictionary<string,object>();
            //dic.Add("FOLIO", oC.FOLIO);
            if (radioButtonDev.Checked == true)
            {
                Reportes.frmImpresion frmImp1 = new Reportes.frmImpresion("RPT_devolucion_de_articulos.rpt", " {CS_RPT_DEVOLUCION_CAD.DEVOLUCION_ID} = '" + row.Cells[0].Value.ToString() + "'");
                frmImp1.ShowDialog();
            }
            if (radioButtonRep.Checked == true)
            {
                Reportes.frmImpresion frmImp = new Reportes.frmImpresion("RPT_reposicion_de_articulos.rpt", " {RPT_REPOSICION_PROVEEDOR.REPOSICION_ID} = '" + row.Cells[0].Value.ToString() + "'");
                frmImp.ShowDialog();
            }
            if (radioButtonBon.Checked == true)
            {
                Reportes.frmImpresion frmImp = new Reportes.frmImpresion("RPT_Bonificacion_de_articulos.rpt", " {BONIFICACION.FOLIO} = '" + row.Cells[0].Value.ToString() + "'");
                frmImp.ShowDialog();
            }
        }
        private void cerrarButtonItem_Click(object sender, EventArgs e)
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Bonificación a Cerrar");
                return;
            }

            this.Cerrar();
           // SIFModelo.OrdenCompra.OrdenesCompraDataSet.BONIFICACIONRow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.BONIFICACIONRow;
            //    SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow ocRow = new SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRADataTable().NewORDEN_COMPRARow();
            //    ocRow.FOLIO_OC_ID = oC.FOLIO_OC_ID;


            //Dictionary<string, object> dic = new Dictionary<string,object>();
            //dic.Add("FOLIO", oC.FOLIO);
                       
        }
        private void cancelarButtonItem_Click(object sender, EventArgs e)
        {
            String ProductName = "Devolucion";
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);
            var row = (GridRow)container;
            if (radioButtonDev.Checked)
            {
                if (row.Cells["ACTIVO"].Value.ToString().Contains('S'))
                {
                    if (MessageBoxEx.Show("¿Cancelar la devolución " + row.Cells[0].Value.ToString() + "?",
                                      ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (Cancelar(row.Cells[0].Value.ToString()) > 0)
                            buscarCabeceras();


                }
                else
                {
                    MessageBox.Show("Solo se pueden cancelar devoluciones en estado S", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            if (radioButtonBon.Checked)
            { tipo_mov = "19";
                if (row.Cells["ACTIVO"].Value.ToString().Contains('S'))
                {
                    if (MessageBoxEx.Show("¿Cancelar la bonificacion " + row.Cells[0].Value.ToString() + "?",
                                      ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (CancelarMov(row.Cells[0].Value.ToString(),tipo_mov) > 0)
                            buscarCabeceras();


                }
                else
                {
                    MessageBox.Show("Solo se pueden cancelar movimientos en estado S", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            if (radioButtonRep.Checked)
            {
                tipo_mov = "20";
                if (row.Cells["ACTIVO"].Value.ToString().Contains('S'))
                {
                    if (MessageBoxEx.Show("¿Cancelar la reposición " + row.Cells[0].Value.ToString() + "?",
                                      ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (CancelarMov(row.Cells[0].Value.ToString(),tipo_mov) > 0)
                            buscarCabeceras();


                }
                else
                {
                    MessageBox.Show("Solo se pueden cancelar movimientos en estado S", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Movimiento no reconocido","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }


        }

        private int Cancelar(string NoFolio)
        {
            SIFNegocio.Inventario.Traspasos tRAS = new SIFNegocio.Inventario.Traspasos();
            return tRAS.Cancela_Devolucion(NoFolio);
        }
        private int CancelarMov(string NoFolio,string tipo_mov)
        {
            SIFNegocio.Inventario.Traspasos tRAS = new SIFNegocio.Inventario.Traspasos();
            return tRAS.CancelarMovimiento (NoFolio,tipo_mov);
        }

        private void buttonItemCc_Click(object sender, EventArgs e)
        {

            this.capturaCaducidad();
        }
        private void btn_ModificacionLotYCad_click(object sender, EventArgs e)
        {
            if (radioButtonDev.Checked == true)
            {
                string tipo_mov = "6";//devolucion
                GridPanel panel = superGridControl1.PrimaryGrid;
                if (panel.ActiveRow == null)
                {
                    return;
                }

                var container = ((GridContainer)panel.ActiveRow);
                if (!(container is GridRow))
                {
                   MessageBox.Show("Seleccione la cabecera del traspaso");
                    return;
                }
                var row = (GridRow)container;
                ModificacionLotesCaducidades frm_lotes = new ModificacionLotesCaducidades();

                if (frm_lotes.validParametro())
                {

                    if (row[7].Value.ToString() == "S")
                    {
                        frm_lotes._folio = row[0].Value.ToString();
                        frm_lotes._tipo_mov = tipo_mov;
                        frm_lotes._usuario = Helpers.Sesion.Usuario.UsuariosID.ToString();

                        frm_lotes.LlenadoDatos();

                        if(frm_lotes.muestra_form)
                        { 
                            if(frm_lotes.ShowDialog() == DialogResult.OK) { }
                       
                        }
                    }
                    else
                    {
                        MessageBox.Show("EL MOVIMIENTO SE ENCUENTRA CERRADO.\n" +
                            "NO SE PERMITE LA ACCION. ", "MODIFICACION LOTES Y CADUCIDADES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Esta funcion no esta activada", "MODIFICACION LOTES Y CADUCIDADES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("SOLO SE PERMITE REALIZAR LA MODIFICACION EN MOVIMIENTOS DE DEVOLUCIÓN. \n", "MODIFICACION LOTES Y CADUCIDADES", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void capturaCaducidad()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);
            var row = (GridRow)container;
            if (row == null)
                return;
            if (!row.Cells["ACTIVO"].Value.ToString().Contains('S') )//&& radioButtonBon.Checked)
            {
                MessageBox.Show("El movimiento ya esta cerrado");
                return;
            }
            //if (!row.Cells["ACTIVO"].Value.ToString().Contains('C') && radioButtonRep.Checked)
            //{
            //    MessageBox.Show("El movimiento tiene que estar cerrado");
            //    return;
            //}
            //SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(SIF.Helpers.Sesion.Usuario.UsuariosID);

            if (radioButtonBon.Checked)
            {
                //Inventario.frmCapturaCaducidades frm = new Inventario.frmCapturaCaducidades(usuario, row.Cells[0].Value.ToString()+"-"+ row.Cells[1].Value.ToString(), 19);
                //frm.ShowDialog();
                Inventario.controlCaducidadesSelectUserControl frmCc = new Inventario.controlCaducidadesSelectUserControl(row.Cells[0].Value.ToString() ,19, int.Parse( row.Cells[1].Value.ToString()));
                frmCc.Owner = this;
                frmCc.Muestra();
            }
            if (radioButtonRep.Checked) {

                Inventario.controlCaducidadesSelectUserControl frmCc = new Inventario.controlCaducidadesSelectUserControl(row.Cells[0].Value.ToString(), 20, int.Parse(row.Cells[1].Value.ToString()));
                frmCc.Owner = this;
                frmCc.Muestra();

            }
            if (radioButtonDev.Checked)
            {
                Inventario.ControlCaducidadesSalidasUserControl frmCc = new Inventario.ControlCaducidadesSalidasUserControl(row.Cells[0].Value.ToString(), 6, int.Parse(row.Cells[1].Value.ToString()));
                frmCc.Owner = this;
                frmCc.Muestra();

            }

        }
        private void Cerrar()
        {
            string valido;
            

            String ProductName = "Donaciones";
            GridPanel panel = superGridControl1.PrimaryGrid;
            if (panel.ActiveRow == null)
            {
                return;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Seleccione la cabecera del movimiento");
                return;
            }
            var row = (GridRow)container;
            
            if (radioButtonDev.Checked == true)
            {
                int mov = 6;
                List<SIFModelo.DevolucionProveedorDetalle> detalle = new List<SIFModelo.DevolucionProveedorDetalle>();

                if (row.Cells[7].Value.ToString().Contains('S'))
                {
                       valido = bon.ObtieneBonificacion(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), mov);
                        if (valido.Contains("-1"))
                        {
                            MessageBox.Show(valido, "Caducidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (MessageBoxEx.Show("¿Aplicar la Devolucion a Proveedor " + row.Cells[0].Value.ToString()
                                                               + " - "
                                                               + row.Cells[1].Value.ToString() + "?",
                                       ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        string folioBon = row.Cells[0].Value.ToString();
                        string lote = row.Cells[1].Value.ToString();
                        SIFNegocio.Inventario.Bonificaciones bon = new SIFNegocio.Inventario.Bonificaciones();
                        detalle=bon.cargaDevProv(row.Cells[0].Value.ToString());
                        bool exis = false;
                        SIFNegocio.Inventario.Inventario art = new SIFNegocio.Inventario.Inventario();
                        SIFNegocio.Inventario.Inventario inventarioL = new SIFNegocio.Inventario.Inventario();


                        SIFModelo.Inventarios.Inventario inv= new SIFModelo.Inventarios.Inventario();
                        SIFModelo.Articulo articulo= new SIFModelo.Articulo();
                        int existencias = 0;
                        //foreach (SIFModelo.DevolucionProveedorDetalle det in detalle)
                        //{
                        //    inv= new SIFModelo.Inventarios.Inventario();
                        //    articulo= new SIFModelo.Articulo();
                        //    articulo.ARTICULO_ID= det.ArticuloID;
                        //    if (!inventarioL.InventarioArticulo(articulo, Convert.ToInt32(det.Cantidad), out existencias, null))
                        //    {

                        //        //falso= no hay inventario sufieciente
                        //        exis = true;
                        //        return;
                        //    }

                        //}
                        //if (!exis)
                        //{

                            bon.AplicaDevolucionProv(folioBon, lote, Helpers.Sesion.Usuario.UsuariosID.ToString());

                            Reportes.frmImpresion frmImp = new Reportes.frmImpresion("RPT_devolucion_de_articulos.rpt", " {CS_RPT_DEVOLUCION_CAD.DEVOLUCION_ID} = '" + row.Cells[0].Value.ToString() + "'");
                            frmImp.ShowDialog();
                            buscarCabeceras();
                        //}
                    }
                    else
                    {
                        //MessageBoxEx.Show("Debe ser la misma sucursal destino verificar configuracion", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (radioButtonRep.Checked == true)
            {

                List<SIFModelo.ReposisionProveedorDetalle> detalle = new List<SIFModelo.ReposisionProveedorDetalle>();

                int mov = 20;
                string folioRep = row.Cells[0].Value.ToString();
                string lote = row.Cells[1].Value.ToString();
                
                valido = bon.ObtieneBonificacion(folioRep,lote, mov);
                if (row.Cells[7].Value.ToString().Contains('S'))
                {
                    if (valido.Contains("-1"))
                    {
                        MessageBox.Show(valido, "Caducidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (MessageBoxEx.Show("¿Aplicar la Reposicion " + row.Cells[0].Value.ToString()
                                                               + " - "
                                                               + row.Cells[1].Value.ToString() + "?",
                                       ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        //SIFNegocio.Inventario.Bonificaciones bon = new SIFNegocio.Inventario.Bonificaciones();
                        bon.AplicaReposicion(folioRep, Helpers.Sesion.Usuario.UsuariosID.ToString());


                        Reportes.frmImpresion frmImp = new Reportes.frmImpresion("RPT_reposicion_de_articulos.rpt", " {RPT_REPOSICION_PROVEEDOR.REPOSICION_ID} = '" + folioRep + "'");
                        frmImp.ShowDialog();
                        buscarCabeceras();

                    }
                }
                else
                    MessageBox.Show("La reposicion tiene que estar en Activo S ","INFORMACION");
            }
            if (radioButtonBon.Checked == true)//bonificacion
            {

                if (row.Cells[8].Value.ToString().Contains('S'))//valida
                {
                    string folioBon = row.Cells[0].Value.ToString();
                    int mov = 19;
                    string lote = row.Cells[1].Value.ToString();

                    valido = bon.ObtieneBonificacion(folioBon,lote, mov);

                    if (valido.Contains("-1"))
                    {
                        MessageBox.Show(valido, "Caducidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }



                    if (MessageBoxEx.Show("¿Aplicar la Bonificacion " + row.Cells[0].Value.ToString()
                                                               + " - "
                                                               + row.Cells[1].Value.ToString() + "?",
                                       ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        SIFNegocio.Inventario.Bonificaciones bon = new SIFNegocio.Inventario.Bonificaciones();
                        string respuesta=bon.AplicaBonificacion(folioBon, lote, Helpers.Sesion.Usuario.UsuariosID.ToString());
                        if (!respuesta.Contains("OK"))
                            MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show(respuesta, "Cierre Bonificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /*  DataRow[] results =SIFModelo.OrdenCompra.OrdenesCompraDataSet  DsDestrucciones.DESTRUCCIONES_DET.Select("Folio='" + row.Cells[0].Value.ToString() + "'", "lote, ARTICULO_ID");
                          // IN Ajuste Array's
                          String[] Articulo = new String[results.Length];
                          Double[] Costo = new Double[results.Length];
                          int[] Cant = new int[results.Length];
                          int ind = 0;

                          foreach (DataRow rows in results)
                          {
                              // Sec[ind] = row[""];
                              Articulo[ind] = rows["ARTICULO_ID"].ToString();
                              Costo[ind] = Convert.ToDouble(rows["PRECIO_COSTO"]);
                              Cant[ind] = Convert.ToInt16(rows["CANTIDAD"]);
                              ind++;
                          }
                          if (destruccionesAlmacen.AplicaAjuste(row.Cells[0].Value.ToString(),
                                           Convert.ToInt16(row.Cells[1].Value.ToString()),
                                           Convert.ToInt16(row.Cells[2].Value.ToString().Split('-')[0]), Articulo, Cant, Costo,
                                           row.Cells[4].Value.ToString(), Helpers.Sesion.Usuario.UsuariosID.ToString()) > 0)
                              this.Buscar();*/
                        Reportes.frmImpresion frmImp = new Reportes.frmImpresion("RPT_Bonificacion_de_articulos.rpt", " {BONIFICACION.FOLIO} = " + row.Cells[0].Value.ToString() + "");
                        frmImp.ShowDialog();
                        buscarCabeceras();
                    }
                    else
                    {
                        //MessageBoxEx.Show("Debe ser la misma sucursal destino verificar configuracion", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
            else 
            {
                if (radioButtonDev.Checked==true)
                MessageBox.Show("La devolucion a proveedor se encuentra Cerrada","Sin acciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                if (radioButtonBon.Checked == true)
                    MessageBox.Show("La bonificacion se encuentra Cerrada", "Sin acciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                if (radioButtonRep.Checked == true)
                    MessageBox.Show("La reposicion se encuentra Cerrada", "Sin acciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Movimiento desconocido", "Sin acciones", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
