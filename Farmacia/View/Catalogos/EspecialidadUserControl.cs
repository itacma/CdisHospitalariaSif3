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

using Equin.ApplicationFramework;
namespace SIF.View.Catalogos
{
    public partial class EspecialidadUserControl : Templates.CatalogoUserControl
    {
        public EspecialidadUserControl()
        {
            InitializeComponent();
            this.InicializaColumnas();
            Privilegios();
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 59, int.Parse(Xbtn.Tag.ToString()));

            }
            dataGridViewX1.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 59, 2);
        }

        public bool Mostrado;
        public object Owner;

        private SIFNegocio.Especialidads logica = new SIFNegocio.Especialidads();
        private string propiedadBusqueda = "";
        SIFModelo.Especialidad current;

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
                        propietario.Owner.ActivaComandos();
                        this.Mostrado = false;
                    }
                }
                if (Owner is MedicosUserControl)
                {
                    MedicosUserControl propietario = Owner as MedicosUserControl;

                    if (propietario.Owner is Ventas.VentaUserControl)
                    {
                        Ventas.VentaUserControl propietarioOwner = propietario.Owner as Ventas.VentaUserControl;
                        if (this.Mostrado && propietarioOwner.Owner.Owner.IsModalPanelDisplayed)
                        {
                            this.DesactivaComandos();
                            if (propietarioOwner.Owner.Owner.Contains(this))
                            {
                                propietarioOwner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                            }
                            propietario.ActivaComandos();
                            propietarioOwner.Owner.ActivaComandos();
                            this.Mostrado = false;
                        }
                    }

                    if (propietario.Owner is Menu.ConfiguracionMenu)
                    {
                        Menu.ConfiguracionMenu propietarioOwner = propietario.Owner as Menu.ConfiguracionMenu;
                        if (this.Mostrado && propietarioOwner.Owner.IsModalPanelDisplayed)
                        {
                            this.DesactivaComandos();
                            if (propietarioOwner.Owner.Contains(this))
                            {
                                propietarioOwner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                            }
                            propietario.ActivaComandos();
                            propietarioOwner.Owner.ActivaComandos();
                            this.Mostrado = false;
                        }
                    }
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
            if (Owner is Menu.ConfiguracionMenu)
            {
                Menu.ConfiguracionMenu Propietario = Owner as Menu.ConfiguracionMenu;
                Propietario.Owner.DesactivaComandos();
                Propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                Propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (Owner is MedicosUserControl)
            {
                MedicosUserControl Propietario = Owner as MedicosUserControl;
                //Propietario.Owner.DesactivaComandos();
                Propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;
               

                if (Owner is Menu.ConfiguracionMenu)
                {
                    Menu.ConfiguracionMenu propietarioModal = Owner as Menu.ConfiguracionMenu;
                    propietarioModal.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }

                if (Owner is Ventas.VentaUserControl)
                {
                    Ventas.VentaUserControl propietarioModal = Owner as Ventas.VentaUserControl;
                    propietarioModal.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }
                this.Mostrado = true;
            }
        }


        #endregion

        #region Funciones y Metodos Privados

        private void InicializaColumnas()
        {
            //BUSQUEDA LOCAL
            SIFModelo.Especialidad modelo = new SIFModelo.Especialidad();
            this.propiedadBusqueda = Helpers.Reflect.GetMember(() => modelo.Nombre).Name;
        }

        private void Buscar()
        {
            this.dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            this.statusLabel.Text = "Buscando elementos...";
            dataGridViewX1.Cursor = Cursors.WaitCursor;
            if (!buscarBackgroundWorker.IsBusy)
            {
                this.buscarBackgroundWorker.RunWorkerAsync();
            }
        }

        private bool Nuevo()
        {
            this.dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);

            this.current = ((ObjectView<SIFModelo.Especialidad>)this.bindingSource.AddNew()).Object as SIFModelo.Especialidad;
            this.current.Nombre = "NOMBRE";
            this.current.Activo = SIFModelo.Tipos.SiNo.SI;

            if (this.logica.Nuevo(current).ID == 0)
            {
                MessageBox.Show("Ha ocurrido un error al agregar el Especialidad, verifique que su información sea correcta");
                logica.CatEspecialidadsList.CancelNew(logica.CatEspecialidadsList.Count - 1);
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
            //        SIFModelo.Especialidad especialidad = ((ObjectView<SIFModelo.Especialidad>)registro.DataBoundItem).Object as SIFModelo.Especialidad;
            //        if (especialidad.Activo == SIFModelo.Tipos.SiNo.NO)
            //        {
            //            continue;
            //        }

            //        especialidad.Activo = SIFModelo.Tipos.SiNo.NO;

            //        if (!logica.Modificar(especialidad))
            //        {
            //           MessageBox.Show("No se eliminó el registro " + especialidad.Nombre);
            //        }

            //    }
            //}


            SIFModelo.Especialidad modelo = ((ObjectView<SIFModelo.Especialidad>)dataGridViewX1.CurrentRow.DataBoundItem).Object as SIFModelo.Especialidad;

            if (modelo.Activo == SIFModelo.Tipos.SiNo.NO)
            {
                DialogResult res =MessageBox.Show("¿Activar el elemento seleccionado?", "Activar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (res == DialogResult.Yes)
                {
                    modelo.Activo = SIFModelo.Tipos.SiNo.SI;

                    if (!logica.Modificar(modelo))
                    {
                       MessageBox.Show("El elemento no pudo ser activado " + modelo.Nombre);
                        return false;
                    }
                }
            }
            else
            {
                if (modelo.Activo == SIFModelo.Tipos.SiNo.NO)
                {
                   MessageBox.Show("La especialidad ya ha sido desactivada anteriormente");
                    return false;
                }

                DialogResult res =MessageBox.Show("¿Eliminar el registro " + modelo.Nombre + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    return false;
                }

                modelo.Activo = SIFModelo.Tipos.SiNo.NO;

                if (!logica.Modificar(modelo))
                {
                   MessageBox.Show("No se eliminó el registro " + modelo.Nombre);
                }
            }

            dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dataGridViewX1.Refresh();

            return true;
        }

        private Boolean Modificar(SIFModelo.Especialidad Especialidad)
        {
            this.Cursor = Cursors.WaitCursor;
            this.statusLabel.Text = "Actualizando registro...";

            bool modificado = logica.Modificar(Especialidad);
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
            return modificado;
        }

        private void buscarLocal()
        {
            if (string.IsNullOrEmpty(propiedadBusqueda))
            {
                propiedadBusqueda = new SIFModelo.Especialidad().GetType().GetProperties()[0].Name;
            }

            try
            {
                logica.CatEspecialidadsList.ApplyFilter(delegate(SIFModelo.Especialidad customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
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
            this.current = this.bindingSource.Current as SIFModelo.Especialidad;
        }

        private void eliminarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        private void CatEspecialidadsUserControl_Load(object sender, EventArgs e)
        {
            this.bindingSource.DataSource = logica.CatEspecialidadsList;
            this.buscarTextBoxX.Focus();
            this.Buscar();
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
            SIFModelo.Especialidad Especialidad = ((ObjectView<SIFModelo.Especialidad>)grid.CurrentRow.DataBoundItem).Object as SIFModelo.Especialidad;

            //SI ES MODIFICADO
            if (Especialidad.ID != 0)
            {
                this.Modificar(Especialidad);
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
            SIFModelo.Especialidad Especialidad = ((ObjectView<SIFModelo.Especialidad>)grid.CurrentRow.DataBoundItem).Object as SIFModelo.Especialidad;

            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];

            //RECUPERA EL NOMBRE DE LA PROPIEDAD Y LA COMPARA CON LA PROPIEDA DESEADA
            if (columna.DataPropertyName == Helpers.Reflect.GetMember(() => Especialidad.Nombre).Name)
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
            this.buscarLocal();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            logica.Buscar("", "");
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.bindingSource.DataSource = logica.CatEspecialidadsList;
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
                // grid.BeginEdit(true);
            }
            celdaEditada = null;

        }

        private void dataGridViewX1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Owner is MedicosUserControl)
            {
                if (bindingSource.Current != null)
                {
                    SIFModelo.Especialidad especialidad = ((ObjectView<SIFModelo.Especialidad>)bindingSource.Current).Object as SIFModelo.Especialidad;
                    ((MedicosUserControl)Owner).AsignaEspecialidad(especialidad);
                    //((MedicosUserControl)Owner).AsignaEspecialidad(this.current.)
                    this.Back();
                }
            }
        }

        private void buscarTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Clear();
            this.buscarLocal();
        }

        private void dataGridViewX1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewX grid = sender as DataGridViewX;
            if (grid.IsCurrentCellInEditMode)
            {
                return;
            }
            DataGridViewRow row = grid.Rows[e.RowIndex];
            row.ReadOnly = false;
            if (row != null)
            {
                SIFModelo.Especialidad modelo = ((ObjectView<SIFModelo.Especialidad>)row.DataBoundItem).Object as SIFModelo.Especialidad;

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

                if (modelo.Activo == SIFModelo.Tipos.SiNo.NO)
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
