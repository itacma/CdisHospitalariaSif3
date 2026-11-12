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

namespace SIF.View.Inventario
{
    public partial class ConsultaArticuloUserControl : Templates.CatalogoUserControl
    {
        public ConsultaArticuloUserControl()
        {
            InitializeComponent();
            this.InicializaColumnas();
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
                if (this.Mostrado && propietario.Owner.IsModalPanelDisplayed)
                {
                    this.DesactivaComandos();
                    if (propietario.Owner.Contains(this))
                    {
                        propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    propietario.ActivaComandos();
                    this.Mostrado = false;
                }
            }
            if (Owner is Ventas.VentaUserControl)
            {
                Ventas.VentaUserControl propietario = Owner as Ventas.VentaUserControl;
                if (this.Mostrado && propietario.Owner.Owner.IsModalPanelDisplayed)
                {
                    this.DesactivaComandos();
                    if (propietario.Owner.Owner.Contains(this))
                    {
                        propietario.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    propietario.ActivaComandos();
                    this.Mostrado = false;
                }
            }


            if (Owner is View.Ventas.FoliocontroladoUserControl)
            {
                View.Ventas.FoliocontroladoUserControl propietario = Owner as View.Ventas.FoliocontroladoUserControl;
                if (this.Mostrado && propietario.Owner.Owner.Owner.IsModalPanelDisplayed)
                {
                    this.DesactivaComandos();
                    if (propietario.Owner.Owner.Owner.Contains(this))
                    {
                        propietario.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    propietario.ActivaComandos();
                    this.Mostrado = false;
                }
            }
            if (Owner is View.OrdenCompra.BonificacionDetallesUserControl)
            {
                View.OrdenCompra.BonificacionDetallesUserControl propietario = Owner as View.OrdenCompra.BonificacionDetallesUserControl;
                if (this.Mostrado && propietario.Owner.Owner.Owner.IsModalPanelDisplayed)
                {
                    this.DesactivaComandos();
                    if (propietario.Owner.Owner.Owner.Contains(this))
                    {
                        propietario.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    propietario.ActivaComandos();
                    this.Mostrado = false;
                }
            }

            if (Owner is View.OrdenCompra.AjusteInventarioDetallesUserControl)
            {
                View.OrdenCompra.AjusteInventarioDetallesUserControl propietario = Owner as View.OrdenCompra.AjusteInventarioDetallesUserControl;
                if (this.Mostrado && propietario.Owner.Owner.Owner.IsModalPanelDisplayed)
                {
                    this.DesactivaComandos();
                    if (propietario.Owner.Owner.Owner.Contains(this))
                    {
                        propietario.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    propietario.ActivaComandos();
                    this.Mostrado = false;
                }
            }

            if (Owner is Ventas.CotizacionUserControl)
            {
                Ventas.CotizacionUserControl propietario = Owner as Ventas.CotizacionUserControl;
                //propietario.ActivaComandos();
                //this.DesactivaComandos();
                this.Dock = DockStyle.Fill;

                if (propietario.Owner is Ventas.VentaUserControl)
                {
                    Ventas.VentaUserControl propietarioOwner = propietario.Owner as Ventas.VentaUserControl;
                    this.DesactivaComandos();
                    if (propietarioOwner.Owner.Owner.Contains(this))
                    {
                        propietarioOwner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    propietario.ActivaComandos();
                    this.Mostrado = false;
                }

                this.Mostrado = false;
            }

            if (Owner is View.OrdenCompra.ManejoDescuentosDetalleUserControl)
            {
                View.OrdenCompra.ManejoDescuentosDetalleUserControl propietario = Owner as View.OrdenCompra.ManejoDescuentosDetalleUserControl;
                propietario.ActivaComandos();
                this.DesactivaComandos();

                if (propietario.Owner.Owner.Owner.Contains(this))
                {
                    propietario.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }
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
            if (Owner is Menu.InventarioMenu)
            {
                Menu.InventarioMenu propietario = Owner as Menu.InventarioMenu;
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }
            if (Owner is Ventas.VentaUserControl)
            {
                Ventas.VentaUserControl propietario = Owner as Ventas.VentaUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (Owner is View.Ventas.FoliocontroladoUserControl)
            {
                View.Ventas.FoliocontroladoUserControl propietario = Owner as View.Ventas.FoliocontroladoUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (Owner is View.OrdenCompra.BonificacionDetallesUserControl)
            {
                View.OrdenCompra.BonificacionDetallesUserControl propietario = Owner as View.OrdenCompra.BonificacionDetallesUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (Owner is View.OrdenCompra.AjusteInventarioDetallesUserControl)
            {
                View.OrdenCompra.AjusteInventarioDetallesUserControl propietario = Owner as View.OrdenCompra.AjusteInventarioDetallesUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (Owner is Ventas.CotizacionUserControl)
            {
                Ventas.CotizacionUserControl propietario = Owner as Ventas.CotizacionUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                if (propietario.Owner is Ventas.VentaUserControl)
                {
                    Ventas.VentaUserControl propietarioOwner = propietario.Owner as Ventas.VentaUserControl;
                    propietarioOwner.DesactivaComandos();
                    propietarioOwner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }


                this.Mostrado = true;
            }

            if (Owner is View.OrdenCompra.ManejoDescuentosDetalleUserControl)
            {
                View.OrdenCompra.ManejoDescuentosDetalleUserControl propietario = Owner as View.OrdenCompra.ManejoDescuentosDetalleUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            this.propiedadBusqueda = string.Empty;
            this.buscarTextBoxX.Focus();
        }

        #endregion

        #region Funciones y Metodos Privados


        private void InicializaColumnas()
        {
            SIFModelo.Articulo modelo = new SIFModelo.Articulo();
            this.propiedadBusqueda = string.Empty;// = Helpers.Reflect.GetMember(() => modelo.NOMBRE1).Name;

            dataGridViewX1.AutoGenerateColumns = true;

        }

        private void Buscar()
        {
            this.statusLabel.Text = "Buscando elementos...";
            dataGridViewX1.Cursor = Cursors.WaitCursor;
            if (!buscarBackgroundWorker.IsBusy)
            {
                this.buscarBackgroundWorker.RunWorkerAsync();
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

            bool modificado = logica.Actualiza(Articulo,1);

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
            this.buscarTextBoxX.Focus();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        DataGridViewCell celdaEditada;
        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //VALIDAR LA COLUMNA Y EL VALOR
            DataGridViewX grid = sender as DataGridViewX;
            SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow Articulo = ((DataRowView)grid.CurrentRow.DataBoundItem).Row as SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow;

            //SI ES MODIFICADO
            if (!string.IsNullOrEmpty(Articulo.ARTICULO_ID))
            {
                this.Modificar(Articulo);
            }

            celdaEditada = grid[e.ColumnIndex, e.RowIndex];

        }

        private void dataGridViewX1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DevComponents.DotNetBar.Controls.DataGridViewX grid = sender as DevComponents.DotNetBar.Controls.DataGridViewX;
            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];
            this.buscarTextBoxX.WatermarkText = "BUSCAR POR " + columna.HeaderText;
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
                this.buscarTextBoxX.SelectAll();
                this.buscarTextBoxX.Focus();
            }
        }

        private void buscarTextBoxX_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
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
            if (string.IsNullOrEmpty(this.propiedadBusqueda))
            {

                    logica.buscaInventario(propiedadBusqueda, this.buscarTextBoxX.Text);

            }
            else
            {
                logica.buscaInventario(propiedadBusqueda, this.buscarTextBoxX.Text);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.bindingSource.DataSource = logica.ListaArticulos;
            this.dataGridViewX1.DataSource = logica.ListaArticulos.INVENTARIO;
            this.dataGridViewX1.Cursor = Cursors.Default;
        }

        private void buscarTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Clear();
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
                        iColNew = celdaEditada.ColumnIndex + 1;
                        iRowNew = celdaEditada.RowIndex;
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
    }
}
