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
    public partial class MedicosUserControl : Templates.CatalogoUserControl
    {
        public MedicosUserControl()
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
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 46, int.Parse(Xbtn.Tag.ToString()));

            }
            dataGridViewX1.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 46, 2);
        }

        public bool Mostrado;
        public object Owner;

        private SIFNegocio.Medicos logica = new SIFNegocio.Medicos();
        private string propiedadBusqueda = "";
        public SIFModelo.Medico current;

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

        private void SeleccionaMedico()
        {
            if (this.Owner is Ventas.VentaUserControl)
            {
                Ventas.VentaUserControl propietario = this.Owner as Ventas.VentaUserControl;

                if (this.dataGridViewX1.CurrentRow == null)
                {
                    return;
                }

                this.current = ((ObjectView<SIFModelo.Medico>)this.dataGridViewX1.CurrentRow.DataBoundItem).Object as SIFModelo.Medico;
                propietario.AgregaMedico(current);
                this.Back();
            }

            if (this.Owner is Ventas.FoliocontroladoUserControl)
            {
                Ventas.FoliocontroladoUserControl propietario = this.Owner as Ventas.FoliocontroladoUserControl;

                if (this.dataGridViewX1.CurrentRow == null)
                {
                    return;
                }

                this.current = ((ObjectView<SIFModelo.Medico>)this.dataGridViewX1.CurrentRow.DataBoundItem).Object as SIFModelo.Medico;
                propietario.AgregaMedico(current);
                this.Back();
            }

            if (this.Owner is CallCenter.ConsultasDermaForm)
            {
                CallCenter.ConsultasDermaForm propietario = this.Owner as CallCenter.ConsultasDermaForm;

                if (this.dataGridViewX1.CurrentRow == null)
                {
                    return;
                }

                this.current = ((ObjectView<SIFModelo.Medico>)this.dataGridViewX1.CurrentRow.DataBoundItem).Object as SIFModelo.Medico;
                propietario.AgregaMedico(current);
                this.Back();
            }
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

                        if (Owner is Menu.ConfiguracionMenu)
                        {
                            if (propietario.Owner.Contains(this))
                            {
                                propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                            }
                            propietario.ActivaComandos();
                            propietario.Owner.ActivaComandos();
                            this.Mostrado = false;
                        }
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
                        propietario.Owner.ActivaComandos();
                        this.Mostrado = false;

                    }
                }

                if (Owner is Ventas.FoliocontroladoUserControl)
                {
                    Ventas.FoliocontroladoUserControl propietario = Owner as Ventas.FoliocontroladoUserControl;

                    if (this.Mostrado && propietario.Owner.Owner.Owner.IsModalPanelDisplayed)
                    {
                        this.DesactivaComandos();
                        try
                        {
                            if (propietario.Owner.Owner.Owner.Contains(this))
                            {
                                propietario.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                            }
                        }
                        catch { }
                        propietario.ActivaComandos();
                        propietario.Owner.ActivaComandos();
                        this.Mostrado = false;

                    }
                }

                if (Owner is CallCenter.ConsultasDermaForm)
                {
                    CallCenter.ConsultasDermaForm propietario = Owner as CallCenter.ConsultasDermaForm;

                    if (this.Mostrado && propietario.Owner.Owner.IsModalPanelDisplayed)
                    {
                        this.DesactivaComandos();

                        if (propietario.Owner.Owner.Contains(this))
                        {
                            propietario.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        propietario.ActivaComandos();
                        propietario.Owner.ActivaComandos();
                        this.Mostrado = false;

                    }
                }


                //if (Owner is Catalogos.ArticuloUserControl)
                //{
                //    Catalogos.ArticuloUserControl propietario = Owner as Catalogos.ArticuloUserControl;
                //    propietario.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                //    propietario.ActivaComandos();
                //    propietario.Owner.ActivaComandos();
                //    this.Mostrado = false;
                //}
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
            if (Owner is View.Menu.ConfiguracionMenu)
            {
                View.Menu.ConfiguracionMenu propietario = Owner as View.Menu.ConfiguracionMenu;
                propietario.Owner.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            }

            if (Owner is Ventas.VentaUserControl)
            {
                Ventas.VentaUserControl propietario = Owner as Ventas.VentaUserControl;
                propietario.Owner.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            }

            if (Owner is Ventas.FoliocontroladoUserControl)
            {
                Ventas.FoliocontroladoUserControl propietario = Owner as Ventas.FoliocontroladoUserControl;
                propietario.Owner.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            }

            if (Owner is CallCenter.ConsultasDermaForm)
            {
                CallCenter.ConsultasDermaForm propietario = Owner as CallCenter.ConsultasDermaForm;
                propietario.Owner.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            }

            this.Mostrado = true;

        }


        #endregion

        #region Funciones y Metodos Privados

        private void InicializaColumnas()
        {

            //BUSQUEDA LOCAL
            SIFModelo.Medico modelo = new SIFModelo.Medico();
            this.propiedadBusqueda = Helpers.Reflect.GetMember(() => modelo.Nombre).Name;

            Dictionary<string, SIFModelo.Tipos.SiNo> SiNo = new Dictionary<string, SIFModelo.Tipos.SiNo>();

            SiNo.Add(Enum.GetName(typeof(SIFModelo.Tipos.SiNo), SIFModelo.Tipos.SiNo.SI), SIFModelo.Tipos.SiNo.SI);
            SiNo.Add(Enum.GetName(typeof(SIFModelo.Tipos.SiNo), SIFModelo.Tipos.SiNo.NO), SIFModelo.Tipos.SiNo.NO);
            BindingSource sinoBindingSource = new BindingSource();
            sinoBindingSource.DataSource = SiNo;

            //ESPECIALIDAD
            ESPECIALIDADColumn.ButtonCustom.Image = global::SIF.Properties.Resources.Especialidad16;
            ESPECIALIDADColumn.ButtonCustom.Visible = true;
            ESPECIALIDADColumn.ButtonCustomClick += ESPECIALIDADColumn_ButtonCustom_CLICK;

            //CONSULTA
            Dictionary<string, SIFModelo.Tipos.TipoConsulta> Consultas = new Dictionary<string, SIFModelo.Tipos.TipoConsulta>();
            SIFModelo.Tipos.TipoConsulta Casa = SIFModelo.Tipos.TipoConsulta.CASA;
            SIFModelo.Tipos.TipoConsulta Oficina = SIFModelo.Tipos.TipoConsulta.OFICINA;
            SIFModelo.Tipos.TipoConsulta Hospital = SIFModelo.Tipos.TipoConsulta.HOSPITAL;
            SIFModelo.Tipos.TipoConsulta Celular = SIFModelo.Tipos.TipoConsulta.CELULAR;
            SIFModelo.Tipos.TipoConsulta Nextel = SIFModelo.Tipos.TipoConsulta.NEXTEL;

            Consultas.Add(Casa.Tipo, Casa);
            Consultas.Add(Oficina.Tipo, Oficina);
           Consultas.Add(Hospital.Tipo, Hospital);
            Consultas.Add(Celular.Tipo, Celular);
            Consultas.Add(Nextel.Tipo, Nextel);

            BindingSource consultasBindingSource = new BindingSource();
            consultasBindingSource.DataSource = Consultas;
            this.TIPO_DIRColumn.DataSource = consultasBindingSource;
            TIPO_DIRColumn.DisplayMember = "Key";
            TIPO_DIRColumn.ValueMember = "Value";


            //CONSULTA FARMACIA
            CONSULTA_FARMACIAColumn.DataSource = sinoBindingSource;
            CONSULTA_FARMACIAColumn.DisplayMember = "Key";
            CONSULTA_FARMACIAColumn.ValueMember = "Value";

        }

        //private void CONSULTAColumn_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridComboBoxExEditControl tipo_dir = sender as GridComboBoxExEditControl;
        //    SIFModelo.Medico medico = this.bindingSource.Current as SIFModelo.Medico;

        //    if (tipo_dir.SelectedValue == null)
        //    {
        //        return;
        //    }

        //    medico.TipoConsulta = tipo_dir.SelectedValue as SIFModelo.Tipos.TipoConsulta;

        //    DireccionMedicoForm frmDirMedico = new DireccionMedicoForm(medico);
        //    frmDirMedico.ShowDialog();
        //}

        void ESPECIALIDADColumn_ButtonCustom_CLICK(object sender, EventArgs e)
        {
            this.current = ((ObjectView<SIFModelo.Medico>)this.bindingSource.Current).Object as SIFModelo.Medico;
            Catalogos.EspecialidadUserControl ClientesForm = new EspecialidadUserControl();
            ClientesForm.Owner = this;
            ClientesForm.Muestra();
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
            dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);

            this.current = ((ObjectView<SIFModelo.Medico>)this.bindingSource.AddNew()).Object as SIFModelo.Medico;
            this.current.Nombre = "NOMBRE";
            current.CedulaProfesional = "CEDULA";
            current.ConsultaFarmacia = SIFModelo.Tipos.SiNo.SI;
            current.Email = "email";
            current.EspecialidadNombre = "ESPECIALIDAD";
            current.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            current.RegistroSSA = "ssa";
            current.Activo = SIFModelo.Tipos.SiNo.SI;
            current.TipoConsulta = SIFModelo.Tipos.TipoConsulta.CASA;


            if (this.logica.Nuevo(current).ID == 0)
            {
                logica.CatMedicosList.CancelNew(logica.CatMedicosList.Count - 1);
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
            //        SIFModelo.Medico medico = ((ObjectView<SIFModelo.Medico>)registro.DataBoundItem).Object as SIFModelo.Medico;

            //        if (medico.Activo == SIFModelo.Tipos.SiNo.NO)
            //        {
            //            continue;
            //        }

            //        medico.Activo = SIFModelo.Tipos.SiNo.NO;
            //        medico.FechaBaja = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

            //        if (!logica.Modificar(medico))
            //        {
            //           MessageBox.Show("No se eliminó el registro " + medico.Nombre);
            //        }

            //    }
            //}

            SIFModelo.Medico modelo = ((ObjectView<SIFModelo.Medico>)dataGridViewX1.CurrentRow.DataBoundItem).Object as SIFModelo.Medico;

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
                   MessageBox.Show("El médico ya ha sido desactivado anteriormente");
                    return false;
                }


                DialogResult res =MessageBox.Show("¿Eliminar el registro " + modelo.Nombre + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {

                    return false;
                }

                modelo.Activo = SIFModelo.Tipos.SiNo.NO;
                modelo.FechaBaja = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

                if (!logica.Modificar(modelo))
                {
                   MessageBox.Show("No se eliminó el registro " + modelo.Nombre);
                }

            }
            dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dataGridViewX1.Refresh();

            return true;
        }

        private Boolean Modificar(SIFModelo.Medico Medico)
        {
            this.Cursor = Cursors.WaitCursor;
            this.statusLabel.Text = "Actualizando registro...";

            bool modificado = logica.Modificar(Medico);
            this.Cursor = Cursors.Default;

            this.statusLabel.Text = "";
            return modificado;
        }

        private void buscarLocal()
        {
            if (string.IsNullOrEmpty(propiedadBusqueda))
            {
                propiedadBusqueda = new SIFModelo.Medico().GetType().GetProperties()[0].Name;
            }

            try
            {
                logica.CatMedicosList.ApplyFilter(delegate(SIFModelo.Medico customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
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
            this.current = this.bindingSource.Current as SIFModelo.Medico;
        }

        private void eliminarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        private void CatMedicoUserControl_Load(object sender, EventArgs e)
        {
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
                    DevComponents.DotNetBar.MessageBoxEx.Show("El nombre del Medico es obligatorio");
                    e.Cancel = true;
                    return;
                }
            }
        }


        DataGridViewCell celdaEditada;

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
            SIFModelo.Medico Medico = grid.CurrentRow.DataBoundItem as SIFModelo.Medico;

            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];

            //RECUPERA EL NOMBRE DE LA PROPIEDAD Y LA COMPARA CON LA PROPIEDA DESEADA
            if (columna.DataPropertyName == Helpers.Reflect.GetMember(() => Medico.Nombre).Name)
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
            this.bindingSource.DataSource = logica.CatMedicosList;
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

        internal void AsignaEspecialidad(SIFModelo.Especialidad especialidad)
        {
            if (especialidad == null)
            {
                return;
            }
            //this.current.EspecialidadID = especialidad.ID;
            this.current.EspecialidadNombre = current.EspecialidadNombre;
            this.Modificar(this.current);
        }

        private void buscarTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Clear();
            this.buscarLocal();
        }

        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //VALIDAR LA COLUMNA Y EL VALOR
            DataGridViewX grid = sender as DataGridViewX;
            SIFModelo.Medico medico = ((ObjectView<SIFModelo.Medico>)grid.CurrentRow.DataBoundItem).Object as SIFModelo.Medico;

            //SI ES MODIFICADO
            if (medico.ID != 0)
            {
                this.Modificar(medico);
            }

            celdaEditada = grid[e.ColumnIndex, e.RowIndex];

            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];
            if (columna.DataPropertyName == Helpers.Reflect.GetMember(() => medico.TipoConsulta).Name)
            {
                DireccionMedicoForm frmDireccion = new DireccionMedicoForm(medico);

                frmDireccion.ShowDialog();


            }
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
                SIFModelo.Medico modelo = ((ObjectView<SIFModelo.Medico>)row.DataBoundItem).Object as SIFModelo.Medico;

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

        private void dataGridViewX1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dataGridViewX1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.SeleccionaMedico();
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
