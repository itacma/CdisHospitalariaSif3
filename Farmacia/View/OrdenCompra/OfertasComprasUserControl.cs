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

namespace SIF.View.OrdenCompra
{
    public partial class OfertasComprasUserControl : Templates.CatalogoUserControl
    {
        public OfertasComprasUserControl()
        {
            InitializeComponent();
            this.InicializaColumnas();
        }

        public bool Mostrado;
        public object Owner;

        private SIFNegocio.Articulo logica = new SIFNegocio.Articulo();
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
            if (Owner is Menu.ConfiguracionMenu)
            {
                Menu.ConfiguracionMenu propietario = Owner as Menu.ConfiguracionMenu;
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

            if (Owner is View.OrdenCompra.OrdenCompraUserControl)
            {
                View.OrdenCompra.OrdenCompraUserControl propietario = Owner as View.OrdenCompra.OrdenCompraUserControl;

                if (propietario.Owner is View.Menu.ComprasMenu)
                {
                    View.Menu.ComprasMenu propietarioOwner = propietario.Owner as View.Menu.ComprasMenu;
                    if (this.Mostrado && propietarioOwner.Owner.IsModalPanelDisplayed)
                    {
                        this.DesactivaComandos();
                        if (propietarioOwner.Owner.Contains(this))
                        {
                            propietarioOwner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        propietario.ActivaComandos();
                        this.Mostrado = false;
                    }
                }
            }
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
            if (Owner is Menu.ConfiguracionMenu)
            {
                Menu.ConfiguracionMenu propietario = Owner as Menu.ConfiguracionMenu;
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

            if (Owner is View.OrdenCompra.OrdenCompraUserControl)
            {
                View.OrdenCompra.OrdenCompraUserControl propietario = Owner as View.OrdenCompra.OrdenCompraUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                if (this.Owner is Menu.ComprasMenu)
                {
                    Menu.ComprasMenu menuCompras = new Menu.ComprasMenu();
                    menuCompras.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);

                }

                this.Mostrado = true;
            }

            this.buscarTextBoxX.Focus();
        }


        #endregion

        #region Funciones y Metodos Privados


        private void InicializaColumnas()
        {
            SIFModelo.Articulo modelo = new SIFModelo.Articulo();
            this.propiedadBusqueda = Helpers.Reflect.GetMember(() => modelo.ARTICULO_ID).Name;

            dataGridViewX1.AutoGenerateColumns = false;

            //PROVEEDOR
            List<SIFModelo.Cliente> proveedores = new SIFNegocio.Clientes().BuscarProveedores("", "").DataSource as List<SIFModelo.Cliente>;
            PROVEEDOR_NOMBREColumn.DataSource = proveedores;
            //LABORATORIO
            // List<SIFModelo.Cliente> laboratorios = new SIFNegocio.Clientes().buscala("", "").DataSource as List<SIFModelo.Cliente>;

        }



        public void AgregarCliente(SIFModelo.Cliente cliente)
        {
            this.current = ((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object as SIFModelo.Articulo;
            current.PROVEEDOR_ID = cliente.ID;
            current.PROVEEDOR_NOMBRE = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
            this.Modificar(current);
            dataGridViewX1.Update();
        }

        public void AgregarLaboratorio(SIFModelo.Cliente cliente)
        {
            this.current = ((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object as SIFModelo.Articulo;
            current.LABORATORIO_ID = cliente.ID;
            current.LABORATORIO_NOMBRE = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
            this.Modificar(current);
            dataGridViewX1.Update();
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


        private bool Eliminar()
        {
            int registros = dataGridViewX1.SelectedRows.Count;
            if (registros <= 0 && dataGridViewX1.CurrentRow == null)
            {
               MessageBox.Show("Seleccione el registro a eliminar");
                return false;
            }

            //if (registros > 1)
            //{
            //    DialogResult res =MessageBox.Show("¿Eliminar " + registros + " registros?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //    if (res == DialogResult.No)
            //    {
            //        return false;
            //    }

            //    foreach (DataGridViewRow registro in dataGridViewX1.SelectedRows)
            //    {
            //        SIFModelo.Articulo articulo = ((ObjectView<SIFModelo.Articulo>)registro.DataBoundItem).Object as SIFModelo.Articulo;


            //        if (articulo.ACTIVO == SIFModelo.Tipos.SiNo.NO)
            //        {
            //            continue;
            //        }

            //        articulo.ACTIVO = SIFModelo.Tipos.SiNo.NO;

            //        if (!logica.Modificar(articulo))
            //        {
            //           MessageBox.Show("No se eliminó el registro " + articulo.NOMBRE1);

            //        }

            //    }
            //}
            SIFModelo.Articulo articulo = ((ObjectView<SIFModelo.Articulo>)dataGridViewX1.CurrentRow.DataBoundItem).Object as SIFModelo.Articulo;
            if (articulo.ACTIVO == SIFModelo.Tipos.SiNo.NO)
            {
                DialogResult res =MessageBox.Show("¿Activar el elemento seleccionado?", "Activar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (res == DialogResult.Yes)
                {
                    articulo.ACTIVO = SIFModelo.Tipos.SiNo.SI;

                    if (!logica.Modificar(articulo))
                    {
                       MessageBox.Show("El elemento no pudo ser activado " + articulo.NOMBRE1);

                    }
                }
            }
            else
            {



                if (articulo.ACTIVO == SIFModelo.Tipos.SiNo.NO)
                {
                   MessageBox.Show("El articulo ya ha sido desactivado anteriormente");
                    return false;
                }

                DialogResult res =MessageBox.Show("¿Eliminar el registro " + articulo.NOMBRE1 + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    return false;
                }

                articulo.ACTIVO = SIFModelo.Tipos.SiNo.NO;

                if (!logica.Modificar(articulo))
                {
                   MessageBox.Show("No se eliminó el registro " + articulo.NOMBRE1);

                }
            }
            dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dataGridViewX1.Refresh();

            return true;
        }

        private Boolean Modificar(SIFModelo.Articulo Articulo)
        {
            this.Cursor = Cursors.WaitCursor;
            this.statusLabel.Text = "Actualizando registro...";

            bool modificado = logica.Modificar(Articulo);

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
                logica.ListaArticulos.ApplyFilter(delegate(SIFModelo.Articulo customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
            }
            catch
            {
            }
        }

        private void seleccionaArticulo()
        {
            if (Owner is OrdenCompra.OrdenCompraUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);
                        OrdenCompra.OrdenCompraUserControl frmVenta = this.Owner as OrdenCompra.OrdenCompraUserControl;
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
        }

        #endregion

        //BARRA DE MENU
        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void modificarButtonItem_Click(object sender, EventArgs e)
        {
            this.current = this.bindingSource.Current as SIFModelo.Articulo;
        }

        private void eliminarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
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
            SIFModelo.Articulo Articulo = ((ObjectView<SIFModelo.Articulo>)grid.CurrentRow.DataBoundItem).Object as SIFModelo.Articulo;

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
            if (e.KeyCode == Keys.Delete)
            {
                this.Eliminar();
            }
            if (e.KeyCode == Keys.F4)
            {
                this.buscarTextBoxX.SelectAll();
                this.buscarTextBoxX.Focus();
            }
        }

        private void buscarTextBoxX_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.buscarButtonX.PerformClick();
            }
            if (e.KeyData == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
            }
            if (e.KeyData == Keys.F5)
            {
                this.seleccionaArticulo();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            logica.Buscar(propiedadBusqueda, this.buscarTextBoxX.Text);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.bindingSource.DataSource = logica.ListaArticulos;
            this.dataGridViewX1.DataSource = bindingSource;
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
            DataGridViewX grid = sender as DataGridViewX;

            DataGridViewRow row = grid.Rows[e.RowIndex];
            row.ReadOnly = false;
            if (row != null)
            {
                SIFModelo.Articulo modelo = ((ObjectView<SIFModelo.Articulo>)row.DataBoundItem).Object as SIFModelo.Articulo;

                //los permisos para modificar son activos
                if (false)
                {
                    if (modelo == this.current)
                    {
                        row.ReadOnly = false;
                        return;
                    }
                    row.ReadOnly = true;
                    return;
                }

                if (modelo.ACTIVO == SIFModelo.Tipos.SiNo.NO)
                {
                    row.ReadOnly = true;
                    return;
                }
                else
                {
                    List<DataGridViewCell> celdas = new List<DataGridViewCell>();
                    foreach (DataGridViewCell celda in row.Cells)
                    {
                        if (celda.ReadOnly)
                        {
                            celdas.Add(celda);
                        }
                    }

                    row.ReadOnly = false;

                    foreach (DataGridViewCell celda in celdas)
                    {
                        celda.ReadOnly = true;
                    }
                }
            }
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
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                DataObject d = dataGridViewX1.GetClipboardContent();
                if (d == null) { return; }
                Clipboard.SetDataObject(d);
            }
        }
    }
}
