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

namespace SIF.View.Ventas
{
    public partial class ControladosUserControl : Templates.ListaUserControl
    {
        public ControladosUserControl()
        {
            InitializeComponent();
            this.inicializaTabla();
        }

        SIFNegocio.Controlado controladoL = new SIFNegocio.Controlado();

        private void Back()
        {
            if (this.Mostrado && Owner.Owner.Owner.IsModalPanelDisplayed)
            {
                //this.DesactivaComandos();
                try
                {
                    if (Owner.Owner.Owner.Contains(this))
                    {
                        Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Owner.ActivaComandos();
                    this.Mostrado = false;
                    this.DesactivaCommandos();
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
        }

        void SuperGridControl1DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;

            if (panel.DataMember == "RemisionDetalles")
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

            GridColumn SucursalIDColumn = new GridColumn("SucursalIDColumn");
            SucursalIDColumn.HeaderText = "SUCURSAL_ID";
            SucursalIDColumn.DataPropertyName = "SUCURSAL_ID";
            SucursalIDColumn.Width = 70;
            SucursalIDColumn.Visible = false;
            panel.Columns.Add(SucursalIDColumn);

            GridColumn NumRemisionColumn = new GridColumn("NumRemisionColumn");
            NumRemisionColumn.HeaderText = "REMISION";
            NumRemisionColumn.DataPropertyName = "NUM_REMISION";
            NumRemisionColumn.Width = 100;
            NumRemisionColumn.Visible = false;
            panel.Columns.Add(NumRemisionColumn);

            GridColumn NumeroPartidaColumn = new GridColumn("NumeroPartidaColumn");
            NumeroPartidaColumn.HeaderText = "PARTIDA";
            NumeroPartidaColumn.DataPropertyName = "NUM_PARTIDA";
            NumeroPartidaColumn.Width = 100;
            panel.Columns.Add(NumeroPartidaColumn);

            GridColumn ArticuloColumn = new GridColumn("ArticuloColumn");
            ArticuloColumn.HeaderText = "CLAVE";
            ArticuloColumn.DataPropertyName = "ARTICULO_ID";
            ArticuloColumn.Width = 100;
            panel.Columns.Add(ArticuloColumn);

            GridColumn Nombre1Column = new GridColumn("Nombre1Column");
            Nombre1Column.HeaderText = "NOMBRE";
            Nombre1Column.DataPropertyName = "NOMBRE1";
            Nombre1Column.Width = 200;
            panel.Columns.Add(Nombre1Column);

            GridColumn Nombre2Column = new GridColumn("*Nombre2Column");
            Nombre2Column.HeaderText = "NOMBRE";
            Nombre2Column.DataPropertyName = "NOMBRE2";
            Nombre2Column.Width = 200;
            panel.Columns.Add(Nombre2Column);

            GridColumn FechaEntregaColumn = new GridColumn("FechaEntregaColumn");
            FechaEntregaColumn.HeaderText = "FECHA ENTREGA";
            FechaEntregaColumn.DataPropertyName = "FECHAENT";
            FechaEntregaColumn.Width = 100;
            panel.Columns.Add(FechaEntregaColumn);

            GridColumn CantidadRemisionColumn = new GridColumn("CantidadRemisionColumn");
            CantidadRemisionColumn.HeaderText = "CANTIDAD";
            CantidadRemisionColumn.DataPropertyName = "CANT_REMISION";
            CantidadRemisionColumn.Width = 80;
            panel.Columns.Add(CantidadRemisionColumn);

            GridColumn PrecioColumn = new GridColumn("PrecioColumn");
            PrecioColumn.HeaderText = "PRECIO";
            PrecioColumn.DataPropertyName = "PRECIO";
            PrecioColumn.Width = 100;
            panel.Columns.Add(PrecioColumn);

            GridColumn IVAColumn = new GridColumn("IVAColumn");
            IVAColumn.HeaderText = "IVA";
            IVAColumn.DataPropertyName = "IVA";
            IVAColumn.Width = 70;
            panel.Columns.Add(IVAColumn);

            GridColumn FolioControladoColumn = new GridColumn("FolioControladoColumn");
            FolioControladoColumn.HeaderText = "FOLIO CONTROLADO";
            FolioControladoColumn.DataPropertyName = "FOLIO_CONTROLADO";
            FolioControladoColumn.Width = 120;
            panel.Columns.Add(FolioControladoColumn);

            GridColumn LoteColumn = new GridColumn("LoteColumn");
            LoteColumn.HeaderText = "LOTE";
            LoteColumn.DataPropertyName = "LOTE";
            LoteColumn.Width = 100;
            panel.Columns.Add(LoteColumn);

            GridColumn CaducidadColumn = new GridColumn("CaducidadColumn");
            CaducidadColumn.HeaderText = "CADUCIDAD";
            CaducidadColumn.DataPropertyName = "CADUCIDAD";
            CaducidadColumn.Width = 100;
            panel.Columns.Add(CaducidadColumn);
        }

        DataSet DsControlados;

        private void Buscar()
        {
            //SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { SucursalID = SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID };
            SIFModelo.Controlado remision = new SIFModelo.Controlado();
            remision.Folio = this.buscarTextBoxX.Text;
            this.superGridControl1.PrimaryGrid.DataSource = controladoL.BuscaControlados(Helpers.Sesion.Sucursal, remision);

            //DsControlados.Relations.Add("1", DsControlados.Tables["Controlado"].Columns["FOLIO"],
            //                               DsControlados.Tables["ControladoDetalles"].Columns["FOLIO"], false);

            //this.bindingSource.DataSource = DsRemisiones;
            // this.superGridControl1.PrimaryGrid.DataSource = DsControlados;
            superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            superGridControl1.PrimaryGrid.DataMember = "CONTROLADOS";
        }

        private SIFModelo.Controlado SelectedControlado()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;

            if (panel.ActiveRow == null)
            {
                return null;
            }

            var container = ((GridContainer)panel.ActiveRow);

            if (!(container is GridRow))
            {
                return null;
            }

            var row = (GridRow)container;

            DataRow datarow = ((DataRowView)row.DataItem).Row;
            SIFModelo.Controlado registro = new SIFModelo.Controlado();
            registro.SucursalId = int.Parse(datarow["SUCURSAL_ID"].ToString());
            registro.Folio = datarow["FOLIO"].ToString();
            registro.MedicoID = int.Parse(datarow["MEDICO_ID"].ToString());
            var fechaEntrega = datarow["FECHA_ENTREGA"];
            if (fechaEntrega.ToString().IsDatetime())
            {
                registro.FechaEntrega = DateTime.Parse(fechaEntrega.ToString());
            }
            registro.UsuarioID = int.Parse(datarow["USUARIO_ID"].ToString());
            registro.RemisionID = datarow["REMISION_ID"].ToString();

            registro.Activo = (SIFModelo.Tipos.TipoActivoControlado)(datarow["ACTIVO"].ToString()[0]);
            registro.Receta = (SIFModelo.Tipos.SiNo)(datarow["RECETA"].ToString()[0]);
            registro.EntregaID = int.Parse(datarow["ENTREGA_ID"].ToString());
            registro.Retiene = (SIFModelo.Tipos.SiNo)(datarow["RETENCION_RECETA"].ToString()[0]);
            return registro;
        }



        public int CajaId;
        public int UsuarioId;
        private void VentasPagoUserControl_Load(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Focus();
            //this.Buscar();
        }

        public Menu.Ventas.ControladosUserControl Owner { get; set; }

        internal void Muestra()
        {
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;
            Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }

        private void Cancelar()
        {
            SIFModelo.Controlado remision = this.SelectedControlado();
            if (remision == null)
            {
               MessageBox.Show("Elija el registro a cancelar");
                return;
            }

            if (remision.Activo != SIFModelo.Tipos.TipoActivoControlado.GENERADA)
            {
               MessageBox.Show("El folio controlado ya no puede ser cancelado", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //if (remision.Activo == SIFModelo.Tipos.TipoActivoControlado.CANCELADA)
            //{
            //   MessageBox.Show("El folio controlado ya fue cancelado anteriormente", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //    return;
            //}

            //if (remision.Activo == SIFModelo.Tipos.TipoActivoControlado.ESCANEADA_EN_MOSTRADOR)
            //{
            //   MessageBox.Show("El folio ya fue escaneado en mostrador", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //    return;
            //}

            //if (remision.Activo == SIFModelo.Tipos.TipoActivoControlado.PAGADA)
            //{
            //   MessageBox.Show("El folio fue pagado", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //    return;
            //}

            DialogResult res =MessageBox.Show("¿Cancelar el folio " + remision.Folio + "?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res != DialogResult.Yes)
            {
                return;
            }

            //remision.
            remision.Activo = SIFModelo.Tipos.TipoActivoControlado.CANCELADA;
            if (new SIFNegocio.Controlado().ActualizaControlado(remision))
            {
                //EN EL DATAGRID PONER COMO CANCELADO
                //GridPanel grid = superGridControl1.PrimaryGrid;
                //grid.Rows.Remove(grid.ActiveRow);

                //SIFNegocio.Inventario.Inventario inventarioL = new SIFNegocio.Inventario.Inventario();
                //SIFNegocio.Controlado remisionL = new SIFNegocio.Controlado();
                //remision.Detalles = remisionL.DetallesControlado(remision);
                //foreach (var detalle in remision.Detalles)
                //{
                //    SIFModelo.Articulo articulo = new SIFModelo.Articulo();
                //    articulo.ARTICULO_ID = detalle.ArticuloID;
                //    inventarioL.InventarioArticuloApartaCancela(articulo, detalle.Cantidad);

                //}
                this.Buscar();
                //INSERTAMOS EN CANCELACIONES
                //SIFNegocio.CANCE


                //CANCELAR EN NADRO PFIZER
            }
            else
            {
               MessageBox.Show("No se consiguió cancelar el folio");
            }
        }

        private void ActivaComandos()
        {
            this.cancelarButtonItem.Shortcuts.Add(eShortcut.F8);
            this.backButton.Shortcuts.Add(eShortcut.F12);
        }

        private void DesactivaCommandos()
        {
            this.cancelarButtonItem.Shortcuts.Clear();
            this.backButton.Shortcuts.Clear();
        }


        public bool Mostrado { get; set; }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void cancelarButtonItem_Click(object sender, EventArgs e)
        {
            this.Cancelar();
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

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }
        }

        private void imprimeTicketControladoButtonItem_Click(object sender, EventArgs e)
        {
            SIFModelo.Ventas.ControladoDataSet.CONTROLADOSRow controladoRow = ((DataRowView)((GridRow)superGridControl1.PrimaryGrid.ActiveRow).DataItem).Row as SIFModelo.Ventas.ControladoDataSet.CONTROLADOSRow;
            SIFModelo.Controlado controlado = new SIFModelo.Controlado();
            controlado.Activo = (SIFModelo.Tipos.TipoActivoControlado) controladoRow.ACTIVO[0];
            controlado.EntregaID = int.Parse(controladoRow.ENTREGA_ID);
            controlado.FechaEntrega = controladoRow.FECHA_ENTREGA;
            controlado.Folio = controladoRow.FOLIO;
            controlado.MedicoID = controladoRow.MEDICO_ID;
            controlado.Receta = (SIFModelo.Tipos.SiNo) controladoRow.RECETA[0];
            if( !controladoRow.IsREMISION_IDNull())
                controlado.RemisionID = controladoRow.REMISION_ID;
            else
                controlado.RemisionID = "";
            controlado.Retiene = (SIFModelo.Tipos.SiNo)controladoRow.RETENCION_RECETA[0];
            controlado.SucursalId = controladoRow.SUCURSAL_ID;
            controlado.UsuarioID = int.Parse( controladoRow.USUARIO_ID);


            if (controlado == null)
            {
               MessageBox.Show("Seleccione el folio Controlado");
                return;
            }
            List<SIFModelo.ControladoDetalle> detalles = new SIFNegocio.Controlado().DetallesControlado(controlado);
            List<SIFModelo.RemisionDetalle> detallesRem = new List<SIFModelo.RemisionDetalle>();
            foreach (var detalle in detalles)
            {
                SIFModelo.RemisionDetalle detalleR = new SIFModelo.RemisionDetalle();
                detalleR.ArticuloID = detalle.ArticuloID;
                detalleR.CantidadRemision = detalle.Cantidad;
                detalleR.Nombre1 = detalle.Nombre1;
                detallesRem.Add(detalleR);
            }
            SIFModelo.Medico medico = new SIFNegocio.Medicos().BuscarPorID(controlado.MedicoID.ToString());
            SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(controlado.EntregaID);


            SIFNegocio.Remision.ImprimeTicketControlado(controlado, detallesRem, medico, usuario);
        }

        FechasFacturaGlobalForm frmFechas = new FechasFacturaGlobalForm();
        private void antibioticosButtonItem_Click(object sender, EventArgs e)
        {
            if (frmFechas.ShowDialog() == DialogResult.OK)
            {
                SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Venta_Antibioticos.rpt", " {CS_REP_ANTIBIOTICOS.FECHA_ENTREGA} >=DATE(" + frmFechas.dateTimeInput1.Value.ToString("yyyy,MM,dd") + ") AND {CS_REP_ANTIBIOTICOS.FECHA_ENTREGA} <=DATE(" + frmFechas.dateTimeInput2.Value.ToString("yyyy,MM,dd") + ") ", "");
                Impresion.ShowDialog();
            }
        }
    }
}
