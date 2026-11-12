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

namespace SIF.View.Catalogos
{
    public partial class SSAControl : Templates.CatalogoUserControl
    {
        public SSAControl()
        {
            InitializeComponent();
            this.InicializaColumnas();
        }

        public bool Mostrado;
        public Menu.ConfiguracionMenu Owner;

        private SIFNegocio.ClasificacionSSAs logica = new SIFNegocio.ClasificacionSSAs();
        private string propiedadBusqueda = "";
        SIFModelo.ClasificacionSSA current;

        #region Navegacion

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            NuevoButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            eliminarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
        }

        /// <summary>
        /// Activa los acesos cortos mediante el teclado
        /// </summary>
        private void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
            NuevoButtonItem.Shortcuts.Clear();
            eliminarButtonItem.Shortcuts.Clear();
        }

        private void Back()
        {
            try
            {
                if (this.Mostrado && Owner.Owner.IsModalPanelDisplayed)
                {
                    this.DesactivaComandos();
                    if (Owner.Owner.Contains(this))
                    {
                        Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Owner.ActivaComandos();
                    this.Owner.Owner.ActivaComandos();
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
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;

            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.Mostrado = true;
        }


        #endregion

        #region Funciones y Metodos Privados

        private void InicializaColumnas()
        {
            //Dictionary<string, SIFModelo.Tipos.SiNo> SiNo = new Dictionary<string, SIFModelo.Tipos.SiNo>();

            //SiNo.Add(Enum.GetName(typeof(SIFModelo.Tipos.SiNo), SIFModelo.Tipos.SiNo.SI), SIFModelo.Tipos.SiNo.SI);
            //SiNo.Add(Enum.GetName(typeof(SIFModelo.Tipos.SiNo), SIFModelo.Tipos.SiNo.NO), SIFModelo.Tipos.SiNo.NO);

            //this.SiNoBindingSource.DataSource = SiNo;

            //CreditoColumn.DisplayMember = "Key";
            //CreditoColumn.ValueMember = "Value";

            //DebitoColumn.DisplayMember = "Key";
            //DebitoColumn.ValueMember = "Value";

        }

        private void Buscar()
        {
            this.dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            this.statusLabel.Text = "Buscando elementos...";
            SIFModelo.ClasificacionSSA ClasificacionSSA = new SIFModelo.ClasificacionSSA();
            dataGridViewX1.Cursor = Cursors.WaitCursor;
            this.bindingSource.DataSource = logica.Buscar("", "");
            if (!buscarBackgroundWorker.IsBusy)
            {
                this.buscarBackgroundWorker.RunWorkerAsync();
            }
        }

        private bool Nuevo()
        {
            this.dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);

            this.current = this.bindingSource.AddNew() as SIFModelo.ClasificacionSSA;
            this.current.Nombre = "NOMBRE";
            current.Receta = SIFModelo.Tipos.SiNo.SI;

            if (this.logica.Nuevo(current).ID == 0)
            {
                MessageBox.Show("Ha ocurrido un error al agregar el ClasificacionSSA, verifique que su información sea correcta");
                this.bindingSource.Remove(current);
                return false;
            }
            else
            {
                this.dataGridViewX1.BeginEdit(true);
                return true;
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
            //        SIFModelo.ClasificacionSSA ClasificacionSSA = registro.DataBoundItem as SIFModelo.ClasificacionSSA;
            //        if (!logica.Eliminar(ClasificacionSSA))
            //        {
            //           MessageBox.Show("No se eliminó el registro " + ClasificacionSSA.Nombre);
            //        }

            //    }
            //}

            //if (modelo.Activo == SIFModelo.Tipos.SiNo.NO)
            //{
            //    DialogResult res =MessageBox.Show("¿Activar el elemento seleccionado?", "Activar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            //    if (res == DialogResult.OK)
            //    {
            //        modelo.Activo = SIFModelo.Tipos.SiNo.SI;

            //        if (!logica.Modificar(modelo))
            //        {
            //           MessageBox.Show("El elemento no pudo ser activado " + modelo.Nombre);
            //            return false;
            //        }
            //    }
            //}
            //else
            //{
            SIFModelo.ClasificacionSSA ClasificacionSSA = dataGridViewX1.CurrentRow.DataBoundItem as SIFModelo.ClasificacionSSA;
            DialogResult res =MessageBox.Show("¿Eliminar el registro " + ClasificacionSSA.Nombre + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return false;
            }

            if (!logica.Eliminar(ClasificacionSSA))
            {
               MessageBox.Show("No se eliminó el registro " + ClasificacionSSA.Nombre);
            }
            //}

            return true;
        }

        private Boolean Modificar(SIFModelo.ClasificacionSSA ClasificacionSSA)
        {
            this.Cursor = Cursors.WaitCursor;
            this.statusLabel.Text = "Actualizando registro...";

            bool modificado = logica.Modificar(ClasificacionSSA);
            this.Cursor = Cursors.Default;

            this.statusLabel.Text = "";
            return modificado;
        }

        private void buscarLocal()
        {
            if (string.IsNullOrEmpty(propiedadBusqueda))
            {
                propiedadBusqueda = new SIFModelo.ClasificacionSSA().GetType().GetProperties()[0].Name;
            }

            try
            {
                logica.CatClasificacionSSAsList.ApplyFilter(delegate(SIFModelo.ClasificacionSSA customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
            }
            catch
            {
            }
        }

        #endregion

        //BARRA DE MENU
        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.buscarLocal();
        }

        private void NuevoButtonItem_Click(object sender, EventArgs e)
        {
            this.Nuevo();
        }

        private void modificarButtonItem_Click(object sender, EventArgs e)
        {
            this.current = this.bindingSource.Current as SIFModelo.ClasificacionSSA;
        }

        private void eliminarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        private void CatClasificacionSSaUserControl_Load(object sender, EventArgs e)
        {
            this.bindingSource.DataSource = logica.CatClasificacionSSAsList;
            this.buscarTextBoxX.Focus();
            this.Buscar();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void superGridControl1_CellValidating(object sender, DevComponents.DotNetBar.SuperGrid.GridCellValidatingEventArgs e)
        {
            DevComponents.DotNetBar.SuperGrid.SuperGridControl grid = sender as DevComponents.DotNetBar.SuperGrid.SuperGridControl;

            if (grid.EditorColumn.DataPropertyName == "NOMBRE")
            {
                if (string.IsNullOrEmpty(e.Value as string))
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("El nombre del ClasificacionSSA es obligatorio");
                    e.Cancel = true;
                    return;
                }
            }
        }


        DataGridViewCell celdaEditada;
        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //VALIDAR LA COLUMNA Y EL VALOR
            DataGridViewX grid = sender as DataGridViewX;
            SIFModelo.ClasificacionSSA ClasificacionSSA = grid.CurrentRow.DataBoundItem as SIFModelo.ClasificacionSSA;

            //SI ES MODIFICADO
            if (ClasificacionSSA.ID != 0)
            {
                this.Modificar(ClasificacionSSA);
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
            SIFModelo.ClasificacionSSA ClasificacionSSA = grid.CurrentRow.DataBoundItem as SIFModelo.ClasificacionSSA;

            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];

            //RECUPERA EL NOMBRE DE LA PROPIEDAD Y LA COMPARA CON LA PROPIEDA DESEADA
            if (columna.DataPropertyName == Helpers.Reflect.GetMember(() => ClasificacionSSA.Nombre).Name)
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

        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            logica.Buscar(propiedadBusqueda, this.buscarTextBoxX.Text);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.bindingSource.DataSource = logica.CatClasificacionSSAsList;
            this.dataGridViewX1.Cursor = Cursors.Default;
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
