using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using Equin.ApplicationFramework;

namespace SIF.View.Catalogos
{
    public partial class InventarioFisicoUserControl : Templates.CatalogoUserControl
    {
        private Boolean Diferencias = false;
        string filasDiferencia = string.Empty;
        DataGridViewRow rowArticulo;
        public InventarioFisicoUserControl()
        {
            InitializeComponent();
            this.InicializaColumnas();

            cargaPeriodos();
            inicializaColoresFilas();
        }

        public bool Mostrado;
        public object Owner;

        private SIFNegocio.Inventario.Inventario logica = new SIFNegocio.Inventario.Inventario();
        private string propiedadBusqueda = "";
        SIFModelo.Articulo current;

        #region Navegacion

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
        }

        /// <summary>
        /// Activa los acesos cortos mediante el teclado
        /// </summary>
        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
        }

        private void Back()
        {
            try
            {
                if (Owner is Menu.InventarioMenu)
                {
                    Menu.InventarioMenu propietario = Owner as Menu.InventarioMenu;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();
                    propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);

                    this.Mostrado = false;
                }
            }
            catch { }
        }

        private void Salir()
        {
            DialogResult res = MessageBox.Show("¿Desea salir del catálogo?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Back();
            }
        }

        public void Muestra()
        {
            if (Owner is View.Menu.InventarioMenu)
            {
                View.Menu.InventarioMenu propietario = Owner as View.Menu.InventarioMenu;
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }



            this.propiedadBusqueda = string.Empty;
            //this.buscarTextBoxX.Focus();
            //this.Buscar();
        }

        #endregion

        #region Funciones y Metodos Privados

        SIFNegocio.Inventario.InventarioFisico invFisicoL = new SIFNegocio.Inventario.InventarioFisico();
        private void InicializaColumnas()
        {
            SIFModelo.Articulo modelo = new SIFModelo.Articulo();
            this.propiedadBusqueda = string.Empty;// = Helpers.Reflect.GetMember(() => modelo.NOMBRE1).Name;

            dataGridViewX1.AutoGenerateColumns = true;

            //ubicacionColumn.Click += ubicacionColumn_CLICK;
            dataGridViewX1.AutoGenerateColumns = false;
        }

        private void cargaPeriodos()
        {
            periodoComboBoxEx.DataSource = invFisicoL.GetPeriodos();
            periodoComboBoxEx.DisplayMember = "periodo";
            periodoComboBoxEx.ValueMember = "periodo";
        }

        private void cargaAnaquel()
        {
            int periodo = 0;
            var itemper = ((DataRowView)periodoComboBoxEx.SelectedItem).Row["periodo"].ToString();
            periodo = int.Parse(itemper.ToString());

            this.anaquelComboBoxEx.DataSource = invFisicoL.GetAnaquel(periodo);
            anaquelComboBoxEx.DisplayMember = "fila";
            anaquelComboBoxEx.ValueMember = "fila";
        }

        private void cargaFila()
        {
            int periodo = 0;
            var itemper = ((DataRowView)periodoComboBoxEx.SelectedItem).Row["periodo"].ToString();
            periodo = int.Parse(itemper.ToString());

            this.filaComboBoxEx.DataSource = invFisicoL.GetFila(periodo);
            filaComboBoxEx.DisplayMember = "fila";
            filaComboBoxEx.ValueMember = "fila";
        }

        void ubicacionColumn_CLICK(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.PopupItem ddc =
                sender as DevComponents.DotNetBar.PopupItem;

            if (ddc != null)
            {
                string ubicacion = ddc.Text;
                SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow row = ((DataRowView)this.dataGridViewX1.CurrentRow.DataBoundItem).Row as SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow;
                SIF.View.Inventario.UbicacionForm ubicacionForm = new SIF.View.Inventario.UbicacionForm(ubicacion);
                if (ubicacionForm.ShowDialog() == DialogResult.OK)
                {
                    row.UBICACION = ubicacionForm.Ubicacion;

                    new SIFNegocio.Inventario.Inventario().ActualizaUbicacion(row);
                }
            }
        }

        private void Buscar()
        {
            this.statusLabel.Text = "Buscando elementos...";
            dataGridViewX1.Cursor = Cursors.WaitCursor;

            if (!buscarBackgroundWorker.IsBusy)
            {

                int periodo = 0;
                if (periodoComboBoxEx.SelectedItem == null)
                {
                   MessageBox.Show("Debe seleccionar un periodo");
                    return;
                }
                //var itemper = ((DataRowView)periodoComboBoxEx.SelectedItem).Row["periodo"].ToString();
                periodo = int.Parse(periodoComboBoxEx.Text);

                int fila = 0;
                //if (filaComboBoxEx.SelectedItem == null)
                //{
                //   MessageBox.Show("Debe seleccionar una fila");
                //    return;
                //}

                //var itemFila = ((DataRowView)filaComboBoxEx.SelectedItem).Row["fila"].ToString();
                fila = int.Parse(filaComboBoxEx.Text);

                int anaquel = 0;

                //if (anaquelComboBoxEx.SelectedItem == null)
                //{
                //   MessageBox.Show("Debe seleccionar el anaquel");
                //    return;
                //}
                //var filaAna = ((DataRowView)anaquelComboBoxEx.SelectedItem).Row["fila"].ToString();
                anaquel = int.Parse(anaquelComboBoxEx.Text.ToString());
                filasDiferencia = txtTbf.Text;
                int[] parametros = new int[3] { periodo, fila, anaquel };

                this.buscarBackgroundWorker.RunWorkerAsync(parametros);
            }
        }

        private bool Nuevo()
        {
            //this.dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);

            //ClaveArticuloForm frmClave = new ClaveArticuloForm();

            //if (frmClave.ShowDialog() != DialogResult.OK)
            //{
            //    return false;
            //}

            //this.current = ((ObjectView<SIFModelo.Articulo>)this.bindingSource.AddNew()).Object as SIFModelo.Articulo;
            //this.current.ARTICULO_ID = frmClave.Clave;
            //this.current.NOMBRE1 = "NOMBRE";
            //this.current.ACTIVO = SIFModelo.Tipos.SiNo.SI;
            //this.current.TIPO_MONEDA = 1;
            //this.current.NOMBRE2 = "NOMBRE 2";
            //this.current.TIPO_MEDICAMENTO_CVE = " ";
            //this.current.LABORATORIO_ID = 1;
            //this.current.PROVEEDOR_ID = 1;
            //this.current.U_COMPRA = "PIEZA";
            //this.current.U_VENTA = "PIEZA";
            //this.current.LISTA_SUCURSAL_VTA = "MATRIZ";
            //this.current.PAQUETE = SIFModelo.Tipos.SiNo.NO;

            //current.ACTIVO = SIFModelo.Tipos.SiNo.SI;

            //if (logica.Nuevo(current).ARTICULO_ID == "")
            //{
            //    logica.ListaArticulos.CancelNew(logica.ListaArticulos.Count - 1);
            //    dataGridViewX1.CancelEdit();
            //    dataGridViewX1.Refresh();

            //    return false;
            //}
            //else
            //{
            //    this.dataGridViewX1.CurrentCell = dataGridViewX1.CurrentRow.Cells[1];
            //    this.dataGridViewX1.BeginEdit(true);
            //    return true;
            //}
            return true;
        }


        private Boolean Modificar(SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow Articulo)
        {
            this.Cursor = Cursors.WaitCursor;
            this.statusLabel.Text = "Actualizando registro...";

            bool modificado = logica.Actualiza(Articulo, 1);

            if (!modificado)
            {
                if (dataGridViewX1.IsCurrentCellInEditMode)
                {
                    dataGridViewX1.CancelEdit();
                }
                dataGridViewX1.Refresh();
            }

            this.Cursor = Cursors.Default;

            this.statusLabel.Text = "";
            return true;
            //return modificado;
        }

        private void buscarLocal()
        {
            if (string.IsNullOrEmpty(propiedadBusqueda))
            {
                propiedadBusqueda = new SIFModelo.Articulo().GetType().GetProperties()[0].Name;
            }

            try
            {
                this.Buscar();
                // logica.ListaArticulos.dataview (delegate(SIFModelo.Articulo customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
            }
            catch
            {
            }
        }

        private void seleccionaArticulo()
        {
            if (Owner is View.Menu.InventarioMenu)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        DataGridViewRow rowArticulo = dataGridViewX1.CurrentRow;


                        celdaEditada = dataGridViewX1.CurrentRow.Cells[7];
                        var valor = celdaEditada.Value;

                        if (!valor.ToString().IsIntegerPositive())
                        {
                           MessageBox.Show("El valor debe ser numérico");
                            celdaEditada.Value = 0;
                            return;
                        }


                        //CALCULAR EL TOTA
                        var datagridRow = dataGridViewX1.Rows[rowArticulo.Index].DataBoundItem;

                        if (!(datagridRow is DataRowView))
                        {
                            return;
                        }

                        //Ventas.VentaUserControl frmVenta = this.Owner as Ventas.VentaUserControl;
                        //frmVenta.AgregaArticulo(articulo);
                        //this.Back();
                        DataRow dgRow = ((DataRowView)((dataGridViewX1.Rows[rowArticulo.Index].DataBoundItem))).Row;
                        decimal conteo = decimal.Parse(dgRow["Conteo1"].ToString());
                        decimal existencia = decimal.Parse(dgRow["Existencia"].ToString());
                        decimal diferencia = conteo - existencia;
                        dgRow["Dif1"] = diferencia;
                       
                        var itemper = ((DataRowView)periodoComboBoxEx.SelectedItem).Row["periodo"].ToString();
                        int periodo = int.Parse(itemper.ToString());


                        Complementos.LoteYCaducidadUbicaciones frm = new Complementos.LoteYCaducidadUbicaciones(dgRow["articulo_id"].ToString(), dgRow["Descripcion"].ToString(), Convert.ToInt32(conteo), periodo);
                        if (frm.ShowDialog() != DialogResult.OK)
                        {
                            celdaEditada.Value = 0;
                        }


                    }
                }
            }
            if (Owner is Ventas.VentaUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);
                        Ventas.VentaUserControl frmVenta = this.Owner as Ventas.VentaUserControl;
                        frmVenta.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }

            if (Owner is View.Ventas.FoliocontroladoUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);
                        View.Ventas.FoliocontroladoUserControl frmVenta = this.Owner as View.Ventas.FoliocontroladoUserControl;
                        frmVenta.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }

            if (Owner is View.OrdenCompra.BonificacionDetallesUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);
                        View.OrdenCompra.BonificacionDetallesUserControl frmVenta = Owner as View.OrdenCompra.BonificacionDetallesUserControl;
                        frmVenta.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }

            if (Owner is View.OrdenCompra.AjusteInventarioDetallesUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);
                        View.OrdenCompra.AjusteInventarioDetallesUserControl frmVenta = Owner as View.OrdenCompra.AjusteInventarioDetallesUserControl;
                        frmVenta.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }

            if (Owner is View.Ventas.CotizacionUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);
                        View.Ventas.CotizacionUserControl frmCotizacion = Owner as View.Ventas.CotizacionUserControl;
                        frmCotizacion.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }

            if (Owner is View.OrdenCompra.ManejoDescuentosDetalleUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);
                        View.OrdenCompra.ManejoDescuentosDetalleUserControl frmOwner = Owner as View.OrdenCompra.ManejoDescuentosDetalleUserControl;
                        frmOwner.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }
        }

        #endregion

        //BARRA DE MENU
        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void NuevoButtonItem_Click(object sender, EventArgs e)
        {
            this.Nuevo();
        }

        private void modificarButtonItem_Click(object sender, EventArgs e)
        {
            this.current = this.bindingSource.Current as SIFModelo.Articulo;
        }

        private void CatArticulosUserControl_Load(object sender, EventArgs e)
        {
            this.bindingSource.DataSource = this.logica.ListaArticulos;
            this.dataGridViewX1.DataSource = bindingSource;
            //this.buscarTextBoxX.Focus();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        DataGridViewCell celdaEditada;
        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            celdaEditada = dataGridViewX1.CurrentRow.Cells[e.ColumnIndex];
            var valor = celdaEditada.Value;

            if (!valor.ToString().IsIntegerPositive())
            {
               MessageBox.Show("El valor debe ser numérico");
                celdaEditada.Value = 0;
                return;
            }


            //CALCULAR EL TOTAL
            var datagridRow = dataGridViewX1.Rows[e.RowIndex].DataBoundItem;

            if (!(datagridRow is DataRowView))
            {
                return;
            }

            DataRow dgRow = ((DataRowView)((dataGridViewX1.Rows[e.RowIndex].DataBoundItem))).Row;
            decimal conteo = decimal.Parse(dgRow["Conteo1"].ToString());
            decimal existencia = decimal.Parse(dgRow["Existencia"].ToString());
            decimal diferencia = conteo - existencia;
            dgRow["Dif1"] = diferencia;
            //CALCULAR


            DataGridViewX grid = sender as DataGridViewX;
            DataRow row = ((DataRowView)grid.CurrentRow.DataBoundItem).Row;
            row["modificada"] = 1;

            //int lastRow = grid.Rows.GetLastRow(DataGridViewElementStates.None);
            //if (grid.CurrentRow.Index != lastRow)
            //{
            //    grid.CurrentCell = grid.Rows [e.RowIndex + 1].Cells[e.ColumnIndex];
            //}
            var itemper = ((DataRowView)periodoComboBoxEx.SelectedItem).Row["periodo"].ToString();
            int periodo = int.Parse(itemper.ToString());

            if (conteo == 0 || conteo != existencia)
            {
                int param = new SIFNegocio.Extras.Parametros().ObtenParametro("INVFISICO_1ERCONTEO_SINLOTE");
                if (param <= 0)
                {
                    Complementos.LoteYCaducidadUbicaciones frm = new Complementos.LoteYCaducidadUbicaciones(dgRow["articulo_id"].ToString(), dgRow["Descripcion"].ToString(), Convert.ToInt32(conteo), periodo);
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        celdaEditada.Value = 0;
                    }
                }
            }
            else { 
            
            }
            

        }

        private void dataGridViewX1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DevComponents.DotNetBar.Controls.DataGridViewX grid = sender as DevComponents.DotNetBar.Controls.DataGridViewX;
            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];
            //this.buscarTextBoxX.WatermarkText = "BUSCAR POR " + columna.HeaderText;
            this.propiedadBusqueda = columna.DataPropertyName;
        }

        private void dataGridViewX1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //VALIDAR LA COLUMNA Y EL VALOR
            DevComponents.DotNetBar.Controls.DataGridViewX grid = sender as DevComponents.DotNetBar.Controls.DataGridViewX;
            SIFModelo.Articulo Articulo = grid.CurrentRow.DataBoundItem as SIFModelo.Articulo;

            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];

            //RECUPERA EL NOMBRE DE LA PROPIEDAD Y LA COMPARA CON LA PROPIEDA DESEADA
            if (columna.DataPropertyName == Helpers.Reflect.GetMember(() => Articulo.NOMBRE1).Name)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue as string) || e.FormattedValue as string == "NOMBRE" || string.IsNullOrEmpty(e.FormattedValue as string))
                {
                   MessageBox.Show("El nombre es obligatorio, verifique la información");
                    e.Cancel = true;
                    return;
                }
                if ((e.FormattedValue as string).Length > 100)
                {
                   MessageBox.Show("El nombre es muy largo, verifique la información");
                }
            }

        }

        private void dataGridViewX1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                //this.buscarTextBoxX.SelectAll();
                //this.buscarTextBoxX.Focus();
            }
        }

        private void buscarTextBoxX_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                //this.buscarTextBoxX.Clear();
                return;
            }
            if (e.KeyData == Keys.F5)
            {
                this.seleccionaArticulo();
                return;
            }

            this.Buscar();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //if (string.IsNullOrEmpty(this.propiedadBusqueda))
            //{
            int[] periodo = e.Argument as int[];



            //this.invFisicoL.TaInventario = this.invFisicoL.sp_Get_Articulos_InvFis(periodo[0], periodo[1], periodo[2]);
            if (!Diferencias)
            {
                this.invFisicoL.TaInventario = this.invFisicoL.sp_Get_Articulos_InvFis(periodo[0], periodo[1], periodo[2]);
            }
            else
            {
                int j = (filasDiferencia.Length > 0) ? 1 : 0;
                this.invFisicoL.TaInventario = this.invFisicoL.sp_Get_Articulos_InvFis(periodo[0], periodo[1], filasDiferencia, j);
            }


            //}
            //else
            //{
            //    invFisicoL.sp_Get_Articulos_InvFis(propiedadBusqueda, "%");
            //}
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.bindingSource.DataSource = logica.ListaArticulos;
            this.dataGridViewX1.DataSource = this.invFisicoL.TaInventario;

            foreach (DataGridViewRow grow in dataGridViewX1.Rows)
            {
                PintaFila(grow);
            }

            this.dataGridViewX1.Cursor = Cursors.Default;
        }

        private void buscarTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            //this.buscarTextBoxX.Clear();
            this.buscarLocal();
        }

        private void dataGridViewX1_DoubleClick(object sender, EventArgs e)
        {          
            this.seleccionaArticulo();
        }

        private void dataGridViewX1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewX grid = sender as DataGridViewX;

            //DataGridViewRow row = grid.Rows[e.RowIndex];
            //row.ReadOnly = false;
            //if (row != null)
            //{
            //    SIFModelo.Articulo modelo = ((ObjectView<SIFModelo.Articulo>)row.DataBoundItem).Object as SIFModelo.Articulo;

            //    //los permisos para modificar son activos
            //    if (false)
            //    {
            //        if (modelo == this.current)
            //        {
            //            row.ReadOnly = false;
            //            return;
            //        }
            //        row.ReadOnly = true;
            //        return;
            //    }

            //    if (modelo.ACTIVO == SIFModelo.Tipos.SiNo.NO)
            //    {
            //        row.ReadOnly = true;
            //        return;
            //    }
            //    else
            //    {
            //        List<DataGridViewCell> celdas = new List<DataGridViewCell>();
            //        foreach (DataGridViewCell celda in row.Cells)
            //        {
            //            if (celda.ReadOnly)
            //            {
            //                celdas.Add(celda);
            //            }
            //        }

            //        row.ReadOnly = false;

            //        foreach (DataGridViewCell celda in celdas)
            //        {
            //            celda.ReadOnly = true;
            //        }
            //    }
            //}
        }

        private void dataGridViewX1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {

            if (MouseButtons != 0) return;

            DevComponents.DotNetBar.Controls.DataGridViewX grid = sender as DevComponents.DotNetBar.Controls.DataGridViewX;
            if (celdaEditada != null && grid.CurrentCell != null)
            {
                // if we are currently in the next line of last edit cell 
                if (grid.CurrentCell.RowIndex == celdaEditada.RowIndex + 1 &&
                     grid.CurrentCell.ColumnIndex == celdaEditada.ColumnIndex)
                {
                    int iColNew;
                    int iRowNew = 0;
                    if (celdaEditada.ColumnIndex >= grid.ColumnCount - 1)
                    {
                        iColNew = 0;
                        iRowNew = grid.CurrentCell.RowIndex;
                    }
                    else
                    {
                        iColNew = celdaEditada.ColumnIndex;
                        iRowNew = celdaEditada.RowIndex;
                    }
                    if (celdaEditada.RowIndex < grid.Rows.GetLastRow(DataGridViewElementStates.None))
                    {
                        iRowNew += 1;
                    }

                    grid.CurrentCell = grid[iColNew, iRowNew];

                }
            }
            //grid.BeginEdit(true);
            celdaEditada = null;
        }

        private void dataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.seleccionaArticulo();
            }

            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                DataObject d = dataGridViewX1.GetClipboardContent();
                if (d == null) { return; }
                Clipboard.SetDataObject(d);
            }
        }
        private void Imprimir()
        {
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Ubicaciones.rpt", "");
            Impresion.ShowDialog();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_ARTICULOS_EXISTENCIAS.rpt", "");
            Impresion.ShowDialog();
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_ARTICULOS_PRECIOS.rpt", "");
            Impresion.ShowDialog();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {

        }

        private void periodoComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargaFila();
            this.cargaAnaquel();
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("¿Crear el inventario físico?", "Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.invFisicoL.CreaInvFisico();
                this.cargaPeriodos();
            }
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            int periodo = 0;
            var itemper = ((DataRowView)periodoComboBoxEx.SelectedItem).Row["periodo"].ToString();
            periodo = int.Parse(itemper.ToString());

            if (
            invFisicoL.ActualizaInventarioFisico(dataGridViewX1.DataSource as DataTable, periodo, Helpers.Sesion.Sucursal))
               MessageBox.Show("El inventario físico se ha actualizado correctamente");
            else
               MessageBox.Show("Ha ocurrido un error al guardar los cambios");

            this.Buscar();
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("¿Desea realizar el ajuste de inventario?", "Ajuste", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int periodo = 0;
                var itemper = ((DataRowView)periodoComboBoxEx.SelectedItem).Row["periodo"].ToString();
                periodo = int.Parse(itemper.ToString());

                string res = this.invFisicoL.AjusteInventarioFisico(periodo, Helpers.Sesion.Sucursal);
               MessageBox.Show(res);
            }
        }

        private void reporte1buttonItem_Click(object sender, EventArgs e)
        {
            int periodo = 0;
            periodo = int.Parse(periodoComboBoxEx.Text);

            int fila = 0;
            fila = int.Parse(filaComboBoxEx.Text);

            int anaquel = 0;
            anaquel = int.Parse(anaquelComboBoxEx.Text);
            //L 18/12/2013 PARA QUE EL REPORTE MUESTRE LAS DIFERENCIAS DE TODAS LAS FILAS
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Resultado_Inventario.rpt", "{INV_FISICO.PERIODO} = " + periodo + /*"AND {INV_FISICO.FILA} = " + fila + " and {INV_FISICO.ANAQUEL} = " + anaquel +*/ " AND {@CALC_INCID} <> 0.00", "");
            Impresion.ShowDialog();

        }

        private void reporte2buttonItem_Click(object sender, EventArgs e)
        {
            int periodo = 0;
            periodo = int.Parse(periodoComboBoxEx.Text);

            int fila = 0;
            fila = int.Parse(filaComboBoxEx.Text);

            int anaquel = 0;
            anaquel = int.Parse(anaquelComboBoxEx.Text);

            int param = new SIFNegocio.Extras.Parametros().ObtenParametro("INVFISICO_1ERCONTEO_SINLOTE");
            if (param > 0)
            {
                SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_toma_Inventario.rpt", "{INV_FISICO.PERIODO} = " + periodo, "");
                Impresion.ShowDialog();
            }
            else {
                SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_toma_Inventario_caducidades.rpt", "{INV_FISICO.PERIODO} = " + periodo, "");
                Impresion.ShowDialog();

            }
        }


        private void inicializaColoresFilas()
        {
            revisarRowStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            revisarRowStyle.BackColor = Color.FromArgb(255, 35, 35);
            //revisarRowStyle.BackColor.Color2 = Color.FromArgb(255, 35, 35);

            WarningCellStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            WarningCellStyle.BackColor = Color.FromArgb(253, 215, 0);
            //WarningCellStyle.BackColor.Color2 = Color.FromArgb(253, 215, 0);

            margenRowStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            margenRowStyle.BackColor = Color.FromArgb(200, 100, 100);
            //margenRowStyle.BackColor.Color2 = Color.FromArgb(200, 100, 100);

            faltanteRowStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            faltanteRowStyle.BackColor = Color.FromArgb(0, 176, 80);
            //faltanteRowStyle.Background.Color2 = Color.FromArgb(0, 176, 80);

            normalRowStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            normalRowStyle = this.dataGridViewX1.DefaultCellStyle;
        }

        DataGridViewCellStyle revisarRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle margenRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle faltanteRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle normalRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle WarningCellStyle = new DataGridViewCellStyle();



        private void filaComboBoxEx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Buscar();
            }
        }

        private void anaquelComboBoxEx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Buscar();
            }
        }

        private void PintaFila(DataGridViewRow dgrow)
        {
            if (dgrow == null)
            {
                return;
            }
            var datagridRow = dgrow.DataBoundItem;

            if (!(datagridRow is DataRowView))
            {
                return;
            }

            DataRow row = ((DataRowView)((dataGridViewX1.Rows[dgrow.Index].DataBoundItem))).Row;
            decimal conteo = 0;
            decimal existencia = 0;
            decimal diferencia = 0;

            var vconteo = row["Conteo1"];

            if (!vconteo.ToString().IsIntegerPositive())
            {
                return;
            }

            conteo = decimal.Parse(row["Conteo1"].ToString());
            existencia = decimal.Parse(row["Existencia"].ToString());
            diferencia = conteo - existencia;
            if (row == null)
            {
                return;
            }

            DataGridViewRow GridRow = this.dataGridViewX1.Rows[dgrow.Index];

            GridRow.DefaultCellStyle = normalRowStyle;
            GridRow.DefaultCellStyle.ApplyStyle(normalRowStyle);

            if (diferencia > 0)
            {
                GridRow.DefaultCellStyle = faltanteRowStyle;
                GridRow.DefaultCellStyle.ApplyStyle(faltanteRowStyle);
            }

            if (diferencia < 0)
            {
                GridRow.DefaultCellStyle = revisarRowStyle;
                GridRow.DefaultCellStyle.ApplyStyle(revisarRowStyle);
            }

            //if (diferencia == 0)
            //{
            //    GridRow.DefaultCellStyle = revisarRowStyle;
            //    GridRow.DefaultCellStyle.ApplyStyle(revisarRowStyle);
            //}
        }

        private void dataGridViewX1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            PintaFila(((DataGridViewX)sender).CurrentRow as DataGridViewRow);
        }

        private void buttonItem2_Click_1(object sender, EventArgs e)
        {

            if (this.invFisicoL.TaInventario == null)
            {
               MessageBox.Show("Realize la busqueda del artículo que desea agregar");
                return;
            }

            if (string.IsNullOrEmpty(this.periodoComboBoxEx.Text))
            {
               MessageBox.Show("Debe especificar el periodo al cual se agregará el artículo");
                return;
            }

            AgregaArticuloInvFisForm frm = new AgregaArticuloInvFisForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                SIFNegocio.Inventario.InventarioFisico inventarioFL = new SIFNegocio.Inventario.InventarioFisico();
                SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow rowInventario = inventarioFL.sp_Get_Articulos_InvFis(periodoComboBoxEx.Text, filaComboBoxEx.Text, anaquelComboBoxEx.Text, frm.Articulo);

                if (rowInventario != null)
                {
                   MessageBox.Show("El artículo " + rowInventario.ARTICULO_ID + " ya se encuentra en " + rowInventario.UBICACION);
                    return;
                }

                var row = this.invFisicoL.TaInventario.NewRow();
                row["articulo_id"] = frm.Articulo.ARTICULO_ID;
                //row["perido"] = periodoComboBoxEx.Text;
                //row["sucursal"] = Helpers.Sesion.Sucursal.SucursalesID;
                row["Descripcion"] = frm.Articulo.NOMBRE1;
                row["nombre2"] = frm.Articulo.NOMBRE2;

                SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow inv = new SIFNegocio.Inventario.Inventario().InventarioArticulo(frm.Articulo, Helpers.Sesion.Sucursal);

                string[] ubicacion = inv.UBICACION.Split('|');

                if (ubicacion.Length > 0)
                    row["Fila"] = ubicacion[0];
                else
                    row["Fila"] = "";

                if (ubicacion.Length > 1)
                    row["Anaquel"] = ubicacion[1];
                else
                    row["Anaquel"] = "";

                if (ubicacion.Length > 2)
                    row["Nivel"] = ubicacion[2];
                else
                    row["Nivel"] = "";

                row["Conteo1"] = frm.Conteo;
                row["Conteo2"] = 0;
                row["Dif1"] = 0;
                row["Dif2"] = 0;


                row["Existencia"] = inv.EXISTENCIAS;
                row["Costo_Prom"] = inv.COSTO_PROM;
                row["Modificada"] = 0;

                if (new SIFNegocio.Inventario.InventarioFisico().CreaInvFisico(row, periodoComboBoxEx.Text, Helpers.Sesion.Sucursal.SucursalesID))
                {
                    this.invFisicoL.TaInventario.Rows.Add(row);
                }
                else
                {
                   MessageBox.Show("Hubo un error al generar el artículo: " + row["ARTICULO_ID"].ToString() + ", por favor revise que no se encuentre en otra fila o anaquel");
                }

            }
        }

        private void switch_Captura_ValueChanged_1(object sender, EventArgs e)
        {
            if (switch_Captura.Value)
            {
                Diferencias = true;
            }
            else
            {
                Diferencias = false;
            }
            this.Buscar();

        }

        private void TxtTbf_KeyDown(object sender, KeyEventArgs e)
        {
            if (Diferencias && txtTbf.TextLength > 0 && e.KeyCode == Keys.Enter)
            {

                this.Buscar();
            }
        }
    }
}
