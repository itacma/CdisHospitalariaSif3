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
    public partial class OfertasMayoristasUserControl : Templates.ListaUserControl
    {
        public OfertasMayoristasUserControl()
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

            if (panel.DataMember == "BONIFICACION_DET")
            {
                CustomizeDetailsPanel(panel);
            }
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


        #endregion

        private SIFNegocio.OrdenCompra.OrdenCompra ordenCompraL = new SIFNegocio.OrdenCompra.OrdenCompra();
        private void buscarOfertas()
        {
            this.superGridControl1.PrimaryGrid.DataSource = ordenCompraL.OfertasProveedor(this.buscarTextBoxX.Text);

            // this.superGridControl1.PrimaryGrid.DataMember = "BONIFICACION";
        }

        private void NuevaBonificacion()
        {
            BonificacionDetallesUserControl detalles = new BonificacionDetallesUserControl();
            // detalles.Owner = this;
            detalles.UsuarioId = this.UsuarioId;
            detalles.Muestra();
        }


        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.buscarOfertas();
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
                this.buscarOfertas();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
                this.buscarOfertas();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void RecepcionOrdenCompraUserControl_Load(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Focus();
            this.buscarOfertas();
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

            SeleccionaMayoristaForm frmMayorista = new SeleccionaMayoristaForm();
            if (frmMayorista.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Bonificación a Imprimir");
                return;
            }

            //     DataRow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row;
            //    SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow ocRow = new SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRADataTable().NewORDEN_COMPRARow();
            //    ocRow.FOLIO_OC_ID = oC.FOLIO_OC_ID;


            //Dictionary<string, object> dic = new Dictionary<string,object>();
            //dic.Add("FOLIO", oC.FOLIO);

            Reportes.frmImpresion frmImp = null;

            if (frmMayorista.clienteSeleccionado.ID == 0)
            {
                frmImp = new Reportes.frmImpresion("RPT_OfertasMayoristas.rpt", "");
            }

            if (frmMayorista.clienteSeleccionado.ID == 99064)
            {
                frmImp = new Reportes.frmImpresion("RPT_OfertasMayoristasNadro.rpt", "{Comando.NADRO_OFERTA} > 0 AND(Not Isnull({Comando.NADRO_OFERTA}))");
            }

            if (frmMayorista.clienteSeleccionado.ID == 99012)
            {
                frmImp = new Reportes.frmImpresion("RPT_OfertasMayoristasSABA.rpt", "{Comando.SABA_OFERTA} > 0 AND(Not Isnull({Comando.SABA_OFERTA}))");
            }

            if (frmMayorista.clienteSeleccionado.ID == 99169)
            {
                frmImp = new Reportes.frmImpresion("RPT_OfertasMayoristasMARZAM.rpt", "{Comando.MARZAM_OFERTA} > 0 AND(Not Isnull({Comando.MARZAM_OFERTA}))");
            }

            if (frmMayorista.clienteSeleccionado.ID == 99035)
            {
                frmImp = new Reportes.frmImpresion("RPT_OfertasMayoristasDROGUEROS.rpt", "{Comando.DROGUEROS_OFERTA} > 0 AND(Not Isnull({Comando.DROGUEROS_OFERTA}))");
            }



            frmImp.ShowDialog();
        }

        private void exportarButtonItem_Click(object sender, EventArgs e)
        {
            SeleccionaMayoristaForm frmMayorista = new SeleccionaMayoristaForm();
            if (frmMayorista.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

                this.ordenCompraL.ExportaCatalogoMayoristas(frmMayorista.clienteSeleccionado.ID);
        }

        private void incidenciasButtonItem_Click(object sender, EventArgs e)
        {
            //AGREGAR FILTRO POR PROVEEDOR  UTILIZA CS_FACTURAS_RECEPCION
            fechaForm frmFecha = new fechaForm();
            if (frmFecha.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string fecha = "'" + frmFecha.dateTimeInput1.Value.ToString("yyyy-MM-dd") + "'";
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("p_fecha", fecha);
            Reportes.frmImpresion frmImp = new Reportes.frmImpresion("RPT_IncidenciasCont.rpt", "p_fecha", parametros);
            frmImp.ShowDialog();
        }
    }
}
