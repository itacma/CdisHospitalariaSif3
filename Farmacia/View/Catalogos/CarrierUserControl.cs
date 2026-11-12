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
    public partial class CarrierUserControl : Templates.CatalogoUserControl
    {
        public CarrierUserControl()
        {
            InitializeComponent();
            this.InicializaColumnas();
        }

        public bool Mostrado;
        public Menu.ConfiguracionMenu Owner;

        private SIFNegocio.Extras.Carriers logica = new SIFNegocio.Extras.Carriers();
        private string propiedadBusqueda = "";
        SIFModelo.Extras.Carrier current;

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
            //this.bindingSource.DataSource = logica.CatCarriersList;
            //BUSQUEDA LOCAL
            SIFModelo.Extras.Carrier modelo = new SIFModelo.Extras.Carrier();
            this.propiedadBusqueda = Helpers.Reflect.GetMember(() => modelo.Nombre).Name;


            Dictionary<string, SIFModelo.Tipos.SiNo> SiNo = new Dictionary<string, SIFModelo.Tipos.SiNo>();

            SiNo.Add(Enum.GetName(typeof(SIFModelo.Tipos.SiNo), SIFModelo.Tipos.SiNo.SI), SIFModelo.Tipos.SiNo.SI);
            SiNo.Add(Enum.GetName(typeof(SIFModelo.Tipos.SiNo), SIFModelo.Tipos.SiNo.NO), SIFModelo.Tipos.SiNo.NO);

            this.SiNoBindingSource.DataSource = SiNo;

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

            this.current = ((ObjectView<SIFModelo.Extras.Carrier>)this.bindingSource.AddNew()).Object as SIFModelo.Extras.Carrier;
            this.current.Nombre = "NOMBRE";
            current.Activo = SIFModelo.Tipos.SiNo.SI;


            if (this.logica.Nuevo(current).CarrierID == 0)
            {
                MessageBox.Show("Ha ocurrido un error al agregar el Carrier, verifique que su información sea correcta");
                logica.CatCarriersList.CancelNew(logica.CatCarriersList.Count - 1);
                dataGridViewX1.CancelEdit();
                dataGridViewX1.Refresh();
                return false;
            }
            else
            {
                this.dataGridViewX1.BeginEdit(true);
                return true;
            }
        }

        private void habilitaGrid(Boolean habilitado)
        {
            foreach (var row in dataGridViewX1.Rows)
            {
                // row.ReadOnly = habilitado;
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
            //        SIFModelo.Carrier Carrier = ((ObjectView<SIFModelo.Carrier>)registro.DataBoundItem).Object as SIFModelo.Carrier as SIFModelo.Carrier;

            //        if (Carrier.Activo == SIFModelo.Tipos.SiNo.NO)
            //        {
            //            continue;
            //        }

            //        Carrier.Activo = SIFModelo.Tipos.SiNo.NO;

            //        if (!logica.Modificar(Carrier))
            //        {
            //           MessageBox.Show("No se eliminó el registro " + Carrier.Nombre);
            //        }

            //    }
            //}

            SIFModelo.Extras.Carrier Carrier = ((ObjectView<SIFModelo.Extras.Carrier>)dataGridViewX1.CurrentRow.DataBoundItem).Object as SIFModelo.Extras.Carrier;
            if (Carrier.Activo == SIFModelo.Tipos.SiNo.NO)
            {
                DialogResult res =MessageBox.Show("¿Activar el elemento seleccionado?", "Activar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (res == DialogResult.Yes)
                {
                    Carrier.Activo = SIFModelo.Tipos.SiNo.SI;

                    if (!logica.Modificar(Carrier))
                    {
                       MessageBox.Show("El elemento no pudo ser activado " + Carrier.Nombre);
                        return false;
                    }
                }
            }
            else
            {
                if (Carrier.Activo == SIFModelo.Tipos.SiNo.NO)
                {
                   MessageBox.Show("El usuario ya ha sido desactivado anteriormente");
                    return false;
                }
                DialogResult res =MessageBox.Show("¿Eliminar el registro " + Carrier.Nombre + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    return false;
                }

                Carrier.Activo = SIFModelo.Tipos.SiNo.NO;

                if (!logica.Modificar(Carrier))
                {
                   MessageBox.Show("No se eliminó el registro " + Carrier.Nombre);
                }
            }

            this.dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dataGridViewX1.Refresh();
            return true;
        }

        private Boolean Modificar(SIFModelo.Extras.Carrier Carrier)
        {
            this.Cursor = Cursors.WaitCursor;
            this.statusLabel.Text = "Actualizando registro...";

            bool modificado = logica.Modificar(Carrier);
            if (!modificado)
            {
                if (dataGridViewX1.IsCurrentCellInEditMode)
                {
                    dataGridViewX1.CancelEdit();
                }


                dataGridViewX1.CancelEdit();
                dataGridViewX1.Update();
            }
            this.Cursor = Cursors.Default;

            this.statusLabel.Text = "";
            return modificado;
        }

        private void buscarLocal()
        {
            if (string.IsNullOrEmpty(propiedadBusqueda))
            {
                propiedadBusqueda = new SIFModelo.Extras.Carrier().GetType().GetProperties()[0].Name;
            }

            try
            {
                logica.CatCarriersList.ApplyFilter(delegate(SIFModelo.Extras.Carrier customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
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
            this.current = this.bindingSource.Current as SIFModelo.Extras.Carrier;
        }

        private void eliminarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        private void CatCarriersUserControl_Load(object sender, EventArgs e)
        {
            //this.bindingSource.DataSource = logica.CatCarriersList;
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
            SIFModelo.Extras.Carrier Carrier = ((ObjectView<SIFModelo.Extras.Carrier>)grid.CurrentRow.DataBoundItem).Object as SIFModelo.Extras.Carrier;

            //SI ES MODIFICADO
            if (Carrier.CarrierID != 0)
            {
                this.Modificar(Carrier);
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
            SIFModelo.Extras.Carrier Carrier = ((ObjectView<SIFModelo.Extras.Carrier>)grid.CurrentRow.DataBoundItem).Object as SIFModelo.Extras.Carrier;

            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];

            //RECUPERA EL NOMBRE DE LA PROPIEDAD Y LA COMPARA CON LA PROPIEDA DESEADA
            if (columna.DataPropertyName == Helpers.Reflect.GetMember(() => Carrier.Nombre).Name)
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
            this.bindingSource.DataSource = logica.CatCarriersList;
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
            //grid.BeginEdit(true);
            celdaEditada = null;

        }

        private void dataGridViewX1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewX grid = sender as DataGridViewX;

            DataGridViewRow row = grid.Rows[e.RowIndex];
            row.ReadOnly = false;
            if (row != null)
            {
                SIFModelo.Extras.Carrier modelo = ((ObjectView<SIFModelo.Extras.Carrier>)row.DataBoundItem).Object as SIFModelo.Extras.Carrier;

                //los permisos para modificar son activos
                if (false)
                {
                    if (modelo != this.current)
                    {
                        row.ReadOnly = true;
                        return;
                    }
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

        private void buscarTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Clear();
            this.buscarLocal();
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
