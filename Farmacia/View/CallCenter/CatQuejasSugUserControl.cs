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
using SIF.View.Catalogos;
using DevComponents.DotNetBar.SuperGrid;
namespace SIF.View.CallCenter
{
    public partial class CatQuejasSugUserControl : Templates.CatalogoUserControl
    {
        public CatQuejasSugUserControl()
        {
            InitializeComponent();
            //this.InicializaColumnas();
            Privilegios();
        }
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 28, int.Parse(Xbtn.Tag.ToString()));
            }
            dataGridViewX1.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 28, 2);

        }
        public bool Mostrado;
        public Menu.CatMenu Owner;

        private SIFNegocio.QuejasSug.CatQuejasSug logica = new SIFNegocio.QuejasSug.CatQuejasSug();
        private string propiedadBusqueda = "";
        SIFModelo.QuejasSugTipo.CatQuejasSug current;

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
        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
            NuevoButtonItem.Shortcuts.Clear();
            eliminarButtonItem.Shortcuts.Clear();
        }

        private void Back()
        {
            try
            {
                if (Owner is Menu.CatMenu)
                {
                    Menu.CatMenu propietario = Owner as Menu.CatMenu;
                    if (this.Mostrado && propietario.Owner.IsModalPanelDisplayed)
                    {
                        this.DesactivaComandos();
                        propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        propietario.ActivaComandos();
                        propietario.Owner.ActivaComandos();
                        this.Mostrado = false;
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
            if (Owner is Menu.CatMenu)
            {
                Menu.CatMenu Propietario = Owner as Menu.CatMenu;
                Propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                Propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

        }


        #endregion

        #region Funciones y Metodos Privados

        DataSet DsCatQuejas;
        SIFNegocio.QuejasSug.CatQuejasSug QuejaSug = new SIFNegocio.QuejasSug.CatQuejasSug();
        private void Buscar()
        {
            DsCatQuejas = QuejaSug.Buscar("", "");
            dataGridViewX1.DataSource = DsCatQuejas;
            dataGridViewX1.DataMember = "CatQuejasSug";
        }

        private bool Nuevo()
        {
            this.dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            current = new SIFModelo.QuejasSugTipo.CatQuejasSug();
            this.current.Nombre = "NUEVO";
            this.current.Activo = SIFModelo.Tipos.SiNo.SI;
            this.current.Tipo = SIFModelo.Tipos.QuejaSug.Queja;

            if (this.logica.Nuevo(current).SugerenciaId < 0)
            {
                MessageBox.Show("Ha ocurrido un error al agregar el redigistro, verifique que su información sea correcta");

                return false;
            }
            else
            {
                this.Buscar();
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


            SIFModelo.QuejasSugTipo.CatQuejasSug QuejaSug = new SIFModelo.QuejasSugTipo.CatQuejasSug();

            QuejaSug.SugerenciaId = int.Parse(dataGridViewX1.CurrentRow.Cells["CAT_QUEJA_SUGERENCIA_ID"].Value.ToString());
            QuejaSug.Nombre = dataGridViewX1.CurrentRow.Cells["NOMBRE"].Value.ToString();
            QuejaSug.Tipo = (SIFModelo.Tipos.QuejaSug)dataGridViewX1.CurrentRow.Cells["TIPO"].Value.ToString()[0];
            QuejaSug.Activo = (SIFModelo.Tipos.SiNo)dataGridViewX1.CurrentRow.Cells["ACTIVO"].Value.ToString()[0];



            if (QuejaSug.Activo == SIFModelo.Tipos.SiNo.NO)
            {
                DialogResult res =MessageBox.Show("¿Activar el elemento seleccionado?", "Activar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (res == DialogResult.Yes)
                {
                    QuejaSug.Activo = SIFModelo.Tipos.SiNo.SI;

                    if (!logica.Modificar(QuejaSug))
                    {
                       MessageBox.Show("El elemento no pudo ser activado " + QuejaSug.Nombre);
                        return false;
                    }
                }
            }
            else
            {
                if (QuejaSug.Activo == SIFModelo.Tipos.SiNo.NO)
                {
                   MessageBox.Show("El Registro ya ha sido desactivada anteriormente");
                    return false;
                }

                DialogResult res =MessageBox.Show("¿Eliminar el registro " + QuejaSug.Nombre + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    return false;
                }

                QuejaSug.Activo = SIFModelo.Tipos.SiNo.NO;

                if (!logica.Modificar(QuejaSug))
                {
                   MessageBox.Show("No se eliminó el registro " + QuejaSug.Nombre);
                }
            }

            dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dataGridViewX1.Refresh();
            this.Buscar();
            return true;
        }

        private Boolean Modificar(SIFModelo.QuejasSugTipo.CatQuejasSug QuejaSug)
        {
            this.Cursor = Cursors.WaitCursor;
            this.statusLabel.Text = "Actualizando registro...";

            bool modificado = logica.Modificar(QuejaSug);
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
                propiedadBusqueda = new SIFModelo.QuejasSugTipo.CatQuejasSug().GetType().GetProperties()[0].Name;
            }

            try
            {
                logica.CatQuejasSugList.ApplyFilter(delegate(SIFModelo.QuejasSugTipo.CatQuejasSug customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
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
            this.current = this.bindingSource.Current as SIFModelo.QuejasSugTipo.CatQuejasSug;
        }

        private void eliminarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        private void CatEspecialidadsUserControl_Load(object sender, EventArgs e)
        {
            this.bindingSource.DataSource = logica.CatQuejasSugList;
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

            SIFModelo.QuejasSugTipo.CatQuejasSug QuejaSug = new SIFModelo.QuejasSugTipo.CatQuejasSug();





            QuejaSug.SugerenciaId = int.Parse(grid.CurrentRow.Cells["CAT_QUEJA_SUGERENCIA_ID"].Value.ToString());
            QuejaSug.Nombre = grid.CurrentRow.Cells["NOMBRE"].Value.ToString();
            QuejaSug.Tipo = (SIFModelo.Tipos.QuejaSug)grid.CurrentRow.Cells["TIPO"].Value.ToString()[0];
            QuejaSug.Activo = (SIFModelo.Tipos.SiNo)grid.CurrentRow.Cells["ACTIVO"].Value.ToString()[0];
            //SI ES MODIFICADO
            if (QuejaSug.SugerenciaId != 0)
            {
                this.Modificar(QuejaSug);
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
            this.bindingSource.DataSource = logica.CatQuejasSugList;
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
                    SIFModelo.QuejasSugTipo.CatQuejasSug QuejaSug = ((ObjectView<SIFModelo.QuejasSugTipo.CatQuejasSug>)bindingSource.Current).Object as SIFModelo.QuejasSugTipo.CatQuejasSug;


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

        }

        private void SubTipoButtonItem_Click(object sender, EventArgs e)
        {
            View.CallCenter.CatQuejasSugTipoUserControl frm = new View.CallCenter.CatQuejasSugTipoUserControl();
            frm.SugerenciaID = int.Parse(dataGridViewX1.CurrentRow.Cells["CAT_QUEJA_SUGERENCIA_ID"].Value.ToString());
            frm.Owner = this;
            frm.Muestra();
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
