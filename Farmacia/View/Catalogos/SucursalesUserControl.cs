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
    public partial class SucursalesUserControl : Templates.CatalogoUserControl
    {
        public SucursalesUserControl()
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
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 40, int.Parse(Xbtn.Tag.ToString()));

            }
            dataGridViewX1.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 40, 2);
        }

        public bool Mostrado;
        public Menu.ConfiguracionMenu Owner;

        private SIFNegocio.Sucursales logica = new SIFNegocio.Sucursales();
        private string propiedadBusqueda = "";
        SIFModelo.Sucursal current;

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
            //BUSQUEDA LOCAL
            SIFModelo.Usuario modelo = new SIFModelo.Usuario();
            this.propiedadBusqueda = Helpers.Reflect.GetMember(() => modelo.UsuariosID).Name;

            //
            this.bindingSource.DataSource = logica.SucursalesList;

            this.RESPONSABLEColumn.ButtonCustom.Image = global::SIF.Properties.Resources.User16;
            RESPONSABLEColumn.ButtonCustom.Visible = true;
            RESPONSABLEColumn.ButtonCustomClick += RESPONSABLEColumn_ButtonCustom_CLICK;

            //this.usuarioBindingSource.DataSource =  new SIFNegocio.Usuarios().Buscar("", "");
            //RESPONSABLEColumn.DisplayMember = "AccesoID";
            //RESPONSABLEColumn.ValueMember = "UsuariosID";

            //ESTADOS
            //AutoCompleteStringCollection strEstados = new AutoCompleteStringCollection();

            //foreach(SIFModelo.Extras.Estado estado in new SIFNegocio.Extras.Estado().CargaEstados())
            //{
            //strEstados.Add(estado.Nombre);
            //}

            //this.CIUDADColumn.DataSource = new SIFNegocio.Extras.Estado().CargaEstados();
            //this.CIUDADColumn.DisplayMember = "Nombre";
            //this.CIUDADColumn.ValueMember = "Nombre";
            ////this.CIUDADColumn.STYL = ComboBoxStyle.Simple;
            //this.CIUDADColumn.AutoComplete = true;// AutoCompleteMode.SuggestAppend;

            //MUNICIPIOS


            //COLONIAS
        }

        void RESPONSABLEColumn_ButtonCustom_CLICK(object sender, EventArgs e)
        {
            //GridTextBoxDropDownEditControl ddc =
            //    sender as GridTextBoxDropDownEditControl;

            //if (ddc != null)
            //{
            this.current = this.bindingSource.Current as SIFModelo.Sucursal;
            Catalogos.UsuarioUserControl ClientesForm = new UsuarioUserControl();
            ClientesForm.Owner = this;
            ClientesForm.Muestra();
            //}
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

            this.current = ((ObjectView<SIFModelo.Sucursal>)this.bindingSource.AddNew()).Object as SIFModelo.Sucursal;

            this.current.Nombre = "NOMBRE";
            this.current.Calle = "CALLE";
            this.current.Colonia = "COLONIA";
            this.current.CodigoPostal = "0";
            this.current.Ciudad = "PUEBLA";
            this.current.NumeroExterior = "0";
            this.current.NumeroInterior = "0";
            this.current.Municipio = "0";
            this.current.ResponsableID = 0;
            this.current.Telefono = "TEL";
            this.current.SucursalID = 1;
            this.current.SucursalUsuario = "SUC_USR";
            this.current.SucursalClave = "SUC_CVE";
            this.current.NadroID = 0;
            this.current.PfizerID = 0;

            if (!this.logica.Nuevo(current))
            {
               MessageBox.Show("Ha ocurrido un error al agregar el Sucursal, verifique que su información sea correcta");
                logica.SucursalesList.CancelNew(logica.SucursalesList.Count - 1);
                this.dataGridViewX1.CancelEdit();
                this.dataGridViewX1.Refresh();
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
            //        SIFModelo.Sucursal sucursal = ((ObjectView<SIFModelo.Sucursal>)registro.DataBoundItem).Object as SIFModelo.Sucursal;
            //        //if (sucursal.Activo == SIFModelo.Tipos.SiNo.NO)
            //        //{
            //        //    continue;
            //        //}

            //        //sucursal.Activo = SIFModelo.Tipos.SiNo.NO;
            //        //sucursal.FechaBaja = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

            //        //if (!logica.Modificar(sucursal))

            //        //SIFModelo.Sucursal Sucursal = registro.DataBoundItem as SIFModelo.Sucursal;
            //        if (!logica.Modificar(sucursal))
            //        {
            //           MessageBox.Show("No se eliminó el registro " + sucursal.Nombre);
            //        }

            //    }
            //}

            //SIFModelo.Sucursal modelo = ((ObjectView<SIFModelo.Sucursal>)dataGridViewX1.CurrentRow.DataBoundItem).Object as SIFModelo.Sucursal;

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
            SIFModelo.Sucursal Sucursal = ((ObjectView<SIFModelo.Sucursal>)dataGridViewX1.CurrentRow.DataBoundItem).Object as SIFModelo.Sucursal;

            //if (Sucursal.Activo == SIFModelo.Tipos.SiNo.NO)
            //{
            //   MessageBox.Show("El usuario ya ha sido desactivado anteriormente");
            //    return false;
            //}


            DialogResult res =MessageBox.Show("¿Eliminar el registro " + Sucursal.Nombre + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return false;
            }

            //Sucursal.Activo = SIFModelo.Tipos.SiNo.NO;
            //Sucursal.FechaBaja = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

            if (!logica.Modificar(Sucursal))
            {
               MessageBox.Show("No se eliminó el registro " + Sucursal.Nombre);
            }
            //}

            dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dataGridViewX1.Refresh();

            return true;
        }

        private Boolean Modificar(SIFModelo.Sucursal Sucursal)
        {
            this.Cursor = Cursors.WaitCursor;
            this.statusLabel.Text = "Actualizando registro...";

            bool modificado = logica.Modificar(Sucursal);

            if (!modificado)
            {
                this.dataGridViewX1.CancelEdit();
                this.dataGridViewX1.Refresh();
            }

            this.Cursor = Cursors.Default;

            this.statusLabel.Text = "";
            return modificado;
        }

        private void buscarLocal()
        {
            if (string.IsNullOrEmpty(propiedadBusqueda))
            {
                propiedadBusqueda = new SIFModelo.Sucursal().GetType().GetProperties()[0].Name;
            }

            try
            {
                logica.SucursalesList.ApplyFilter(delegate(SIFModelo.Sucursal customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
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
            this.current = this.bindingSource.Current as SIFModelo.Sucursal;
        }

        private void eliminarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        private void CatSucursalsUserControl_Load(object sender, EventArgs e)
        {
            this.bindingSource.DataSource = logica.SucursalesList;
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
            SIFModelo.Sucursal Sucursal = ((ObjectView<SIFModelo.Sucursal>)grid.CurrentRow.DataBoundItem).Object as SIFModelo.Sucursal;

            //SI ES MODIFICADO
            if (Sucursal.SucursalesID != 0)
            {
                this.Modificar(Sucursal);
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
            SIFModelo.Sucursal Sucursal = ((ObjectView<SIFModelo.Sucursal>)grid.CurrentRow.DataBoundItem).Object as SIFModelo.Sucursal;

            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];

            //RECUPERA EL NOMBRE DE LA PROPIEDAD Y LA COMPARA CON LA PROPIEDA DESEADA
            if (columna.DataPropertyName == Helpers.Reflect.GetMember(() => Sucursal.Nombre).Name)
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
            this.bindingSource.DataSource = logica.SucursalesList;
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

        public void AsignaUsuario(SIFModelo.Usuario usuario)
        {
            this.current = ((ObjectView<SIFModelo.Sucursal>)bindingSource.Current).Object as SIFModelo.Sucursal;

            current.ResponsableID = usuario.UsuariosID;
            current.ResponsableNombre = usuario.Nombre;
            this.Modificar(current);
        }

        private void buscarTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Clear();
            this.buscarLocal();
        }

        private void dataGridViewX1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewX grid = sender as DataGridViewX;

            DataGridViewRow row = grid.Rows[e.RowIndex];
            row.ReadOnly = false;
            if (row != null)
            {
                SIFModelo.Sucursal modelo = ((ObjectView<SIFModelo.Sucursal>)row.DataBoundItem).Object as SIFModelo.Sucursal;

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

                //if (modelo.Activo == SIFModelo.Tipos.SiNo.NO)
                //{
                //    row.ReadOnly = true;
                //    return;
                //}
                //else
                //{
                //List<DataGridViewCell> celdas = new List<DataGridViewCell>();
                //foreach (DataGridViewCell celda in row.Cells)
                //{
                //    if (celda.ReadOnly)
                //    {
                //        celdas.Add(celda);
                //    }
                //}

                //row.ReadOnly = false;

                //foreach (DataGridViewCell celda in celdas)
                //{
                //    celda.ReadOnly = true;
                //}
                //}
            }
        }

        private void dataGridViewX1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DevComponents.DotNetBar.Controls.DataGridViewX grid = sender as DevComponents.DotNetBar.Controls.DataGridViewX;

            SIFModelo.Sucursal sucursal = ((ObjectView<SIFModelo.Sucursal>)grid.CurrentRow.DataBoundItem).Object as SIFModelo.Sucursal;

            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];

            //RECUPERA EL NOMBRE DE LA PROPIEDAD Y LA COMPARA CON LA PROPIEDA DESEADA
            if (columna.DataPropertyName == Helpers.Reflect.GetMember(() => sucursal.Municipio).Name)
            {
                SIFModelo.Extras.Estado estado = new SIFModelo.Extras.Estado();
                estado.Nombre = sucursal.Ciudad;
                this.MUNICIPIOColumn.DataSource = new SIFNegocio.Extras.Estado().CargaMunicipios(estado);
                this.MUNICIPIOColumn.DisplayMember = "Nombre";
                this.MUNICIPIOColumn.ValueMember = "Nombre";
            }

            if (columna.DataPropertyName == Helpers.Reflect.GetMember(() => sucursal.Colonia).Name)
            {
                SIFModelo.Extras.Municipio municipio = new SIFModelo.Extras.Municipio();
                municipio.Nombre = sucursal.Municipio;
                this.COLONIAColumn.DataSource = new SIFNegocio.Extras.Estado().CargaColonias(municipio);
                this.COLONIAColumn.DisplayMember = "Nombre";
                this.COLONIAColumn.ValueMember = "Nombre";
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
