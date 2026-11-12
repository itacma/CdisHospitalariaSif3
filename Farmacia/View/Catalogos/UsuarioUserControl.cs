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
    public partial class UsuarioUserControl : Templates.CatalogoUserControl
    {
        public UsuarioUserControl()
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
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 67, int.Parse(Xbtn.Tag.ToString()));

            }
            dataGridViewX1.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 67, 2);
        }

        public bool Mostrado;
        public object Owner;

        private SIFNegocio.Usuarios logica = new SIFNegocio.Usuarios();
        private string propiedadBusqueda = "";
        SIFModelo.Usuario current;

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
                        this.DesactivaComandos();
                        this.Mostrado = false;
                    }
                }
                if (Owner is SucursalesUserControl)
                {
                    SucursalesUserControl propietario = Owner as SucursalesUserControl;

                    if (this.Mostrado)
                    {
                        this.DesactivaComandos();
                        if (propietario.Owner.Owner.Contains(this))
                        {
                            propietario.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        propietario.ActivaComandos();
                        this.DesactivaComandos();
                        this.Mostrado = false;
                    }
                }

                if (Owner is View.Ventas.FoliocontroladoUserControl)
                {
                    View.Ventas.FoliocontroladoUserControl propietario = Owner as View.Ventas.FoliocontroladoUserControl;

                    if (this.Mostrado)
                    {
                        this.DesactivaComandos();
                        if (propietario.Owner.Owner.Owner.Contains(this))
                        {
                            propietario.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        propietario.ActivaComandos();
                        this.DesactivaComandos();
                        this.Mostrado = false;
                    }
                }

                if (Owner is View.Seguridad.PerfilesUserControl)
                {
                    View.Seguridad.PerfilesUserControl propietario = Owner as View.Seguridad.PerfilesUserControl;

                    if (this.Mostrado)
                    {
                        this.DesactivaComandos();
                        if (propietario.Owner.Contains(this))
                        {
                            propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        propietario.ActivaComandos();
                        this.DesactivaComandos();
                        this.Mostrado = false;
                    }
                }

                if (Owner is View.Seguridad.BitacoraUserControl)
                {
                    View.Seguridad.BitacoraUserControl propietario = Owner as View.Seguridad.BitacoraUserControl;

                    if (this.Mostrado)
                    {
                        this.DesactivaComandos();
                        if (propietario.Owner.Contains(this))
                        {
                            propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        propietario.ActivaComandos();
                        this.DesactivaComandos();
                        this.Mostrado = false;
                    }
                }

                if (Owner is Seguridad.CompradorLaboratorioUserControl)
                {
                    Seguridad.CompradorLaboratorioUserControl propietario = Owner as Seguridad.CompradorLaboratorioUserControl;

                    if (this.Mostrado)
                    {
                        this.DesactivaComandos();
                        if (propietario.Owner.Owner.Contains(this))
                        {
                            propietario.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        propietario.ActivaComandos();
                        this.DesactivaComandos();
                        this.Mostrado = false;
                    }
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            CONTRASENAColumn.Visible = false;

            if (Owner is Menu.ConfiguracionMenu)
            {
                CONTRASENAColumn.Visible = true;
                CONTRASENAColumn.PasswordChar = Convert.ToChar('●');
                CONTRASENAColumn.Visible = false;//L 29/11/2013 NO MOSTRAR CONTRASEÑA DE USUARIO
                Menu.ConfiguracionMenu propietario = Owner as Menu.ConfiguracionMenu;
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }
            if (Owner is SucursalesUserControl)
            {
                SucursalesUserControl propietario = Owner as SucursalesUserControl;
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (Owner is View.Ventas.FoliocontroladoUserControl)
            {
                View.Ventas.FoliocontroladoUserControl propietario = Owner as View.Ventas.FoliocontroladoUserControl;
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (Owner is View.Seguridad.PerfilesUserControl)
            {
                View.Seguridad.PerfilesUserControl propietario = Owner as View.Seguridad.PerfilesUserControl;
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (Owner is View.Seguridad.BitacoraUserControl)
            {
                View.Seguridad.BitacoraUserControl propietario = Owner as View.Seguridad.BitacoraUserControl;
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (Owner is Seguridad.CompradorLaboratorioUserControl)
            {
                Seguridad.CompradorLaboratorioUserControl propietario = Owner as Seguridad.CompradorLaboratorioUserControl;
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }
            this.Buscar();

        }


        #endregion

        #region Funciones y Metodos Privados

        private void InicializaColumnas()
        {
            //BUSQUEDA LOCAL
            SIFModelo.Usuario modelo = new SIFModelo.Usuario();
            this.propiedadBusqueda = Helpers.Reflect.GetMember(() => modelo.AccesoID).Name;

            //ACTIVO
            Dictionary<string, SIFModelo.Tipos.SiNo> SiNo = new Dictionary<string, SIFModelo.Tipos.SiNo>();
            SiNo.Add(Enum.GetName(typeof(SIFModelo.Tipos.SiNo), SIFModelo.Tipos.SiNo.SI), SIFModelo.Tipos.SiNo.SI);
            SiNo.Add(Enum.GetName(typeof(SIFModelo.Tipos.SiNo), SIFModelo.Tipos.SiNo.NO), SIFModelo.Tipos.SiNo.NO);

            this.SiNoBindingSource.DataSource = SiNo;

            //TIPO USUARIO
            Dictionary<string, SIFModelo.Tipos.TipoUsuario> TipoUsuario = new Dictionary<string, SIFModelo.Tipos.TipoUsuario>();
            TipoUsuario.Add(Enum.GetName(typeof(SIFModelo.Tipos.TipoUsuario), SIFModelo.Tipos.TipoUsuario.ADMINISTRATIVO), SIFModelo.Tipos.TipoUsuario.ADMINISTRATIVO);
            TipoUsuario.Add(Enum.GetName(typeof(SIFModelo.Tipos.TipoUsuario), SIFModelo.Tipos.TipoUsuario.CAJERO), SIFModelo.Tipos.TipoUsuario.CAJERO);
            TipoUsuario.Add(Enum.GetName(typeof(SIFModelo.Tipos.TipoUsuario), SIFModelo.Tipos.TipoUsuario.SUPERVISOR), SIFModelo.Tipos.TipoUsuario.SUPERVISOR);
            TipoUsuario.Add(Enum.GetName(typeof(SIFModelo.Tipos.TipoUsuario), SIFModelo.Tipos.TipoUsuario.VENDENDOR), SIFModelo.Tipos.TipoUsuario.VENDENDOR);
            TipoUsuario.Add(Enum.GetName(typeof(SIFModelo.Tipos.TipoUsuario), SIFModelo.Tipos.TipoUsuario.ALMACENISTA), SIFModelo.Tipos.TipoUsuario.ALMACENISTA);
            TipousuarioBindingSource.DataSource = TipoUsuario;
            TIPO_USUARIOColumn.DisplayMember = "Key";
            TIPO_USUARIOColumn.ValueMember = "Value";

            //GENERO
            Dictionary<string, SIFModelo.Tipos.Genero> Genero = new Dictionary<string, SIFModelo.Tipos.Genero>();
            Genero.Add(Enum.GetName(typeof(SIFModelo.Tipos.Genero), SIFModelo.Tipos.Genero.MASCULINO), SIFModelo.Tipos.Genero.MASCULINO);
            Genero.Add(Enum.GetName(typeof(SIFModelo.Tipos.Genero), SIFModelo.Tipos.Genero.FEMENIMO), SIFModelo.Tipos.Genero.FEMENIMO);
            GeneroBindingSource.DataSource = Genero;
            GENEROColumn.DisplayMember = "Key";
            GENEROColumn.ValueMember = "Value";

            //SUCURSAL
            Dictionary<string, int> Sucursales = new Dictionary<string, int>();
            foreach (var item in new SIFNegocio.Sucursales().Buscar("", "").DataSource)
            {
                SIFModelo.Sucursal sucursal = ((SIFModelo.Sucursal)item);
                Sucursales.Add(sucursal.Nombre, sucursal.SucursalesID);
            }
            SucursalBindingSource.DataSource = Sucursales;
            SUCURSALColumn.DisplayMember = "Key";
            SUCURSALColumn.ValueMember = "Value";



            //
            // ((TextBox)(CONTRASENAColumn.DataGridView.EditingControl)).PasswordChar = '•';

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

            Catalogos.UsuarioIDForm frmUsuario = new UsuarioIDForm();
            DialogResult res = frmUsuario.ShowDialog();
            if (res != DialogResult.OK)
            {
                return false;
            }

            SIFModelo.Usuario nuevousuario = new SIFModelo.Usuario();
            nuevousuario.AccesoID = frmUsuario.textBoxX1.Text;
            SIFModelo.Usuario usuarioEncontrado = new SIFNegocio.Usuarios().UsuarioPorAccesoID(nuevousuario);

            if (usuarioEncontrado != null && usuarioEncontrado.UsuariosID != nuevousuario.UsuariosID)
            {
               MessageBox.Show("Ya existe un usuario con ese nombre, por favor verifique");

                return false;
            }

            var objeto = this.bindingSource.AddNew();
            this.current = ((ObjectView<SIFModelo.Usuario>)objeto).Object as SIFModelo.Usuario;
            this.current.UsuariosID = 0;
            this.current.Nombre = "NOMBRE";
            this.current.Apellidos = "APELLIDOS";
            this.current.Genero = SIFModelo.Tipos.Genero.MASCULINO;
            this.current.TipoUsuario = SIFModelo.Tipos.TipoUsuario.VENDENDOR;
            this.current.AccesoID = frmUsuario.textBoxX1.Text;
            this.current.Contrasena = "PASS";
            this.current.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

            this.current.Activo = SIFModelo.Tipos.SiNo.SI;
            this.current.SucursalID = SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID;

            if (this.logica.Nuevo(current).UsuariosID == 0)
            {
                logica.ListaUsuarios.CancelNew(logica.ListaUsuarios.Count - 1);
                // this.bindingSource.Remove(objeto);
                dataGridViewX1.CancelEdit();
                dataGridViewX1.Refresh();
                return false;
            }
            else
            {
                try
                {
                    this.dataGridViewX1.CurrentCell = dataGridViewX1.CurrentRow.Cells[1];
                }
                catch{
                    dataGridViewX1.CancelEdit();
                }
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
            //        SIFModelo.Usuario Usuario = ((ObjectView<SIFModelo.Usuario>)registro.DataBoundItem).Object as SIFModelo.Usuario;
            //        if (Usuario.Activo == SIFModelo.Tipos.SiNo.NO)
            //        {
            //            continue;
            //        }

            //        Usuario.Activo = SIFModelo.Tipos.SiNo.NO;
            //        Usuario.FechaBaja = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

            //        if (!logica.Modificar(Usuario))
            //        {
            //           MessageBox.Show("No se eliminó el registro " + Usuario.Nombre);
            //        }

            //    }
            //}

            SIFModelo.Usuario modelo = ((ObjectView<SIFModelo.Usuario>)dataGridViewX1.CurrentRow.DataBoundItem).Object as SIFModelo.Usuario;

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
                   MessageBox.Show("El usuario ya ha sido desactivado anteriormente");
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

        private Boolean Modificar(SIFModelo.Usuario Usuario)
        {
            this.Cursor = Cursors.WaitCursor;
            this.statusLabel.Text = "Actualizando registro...";

            bool modificado = logica.Modificar(Usuario);
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
            if (string.IsNullOrEmpty(buscarTextBoxX.Text))
            {
                this.Buscar();
                return;
            }
            if (string.IsNullOrEmpty(propiedadBusqueda))
            {
                propiedadBusqueda = new SIFModelo.Usuario().GetType().GetProperties()[0].Name;
            }

            try
            {
                logica.ListaUsuarios.ApplyFilter(delegate(SIFModelo.Usuario customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
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

        private void eliminarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        private void CatUsuariosUserControl_Load(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Focus();
            this.Buscar();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        DataGridViewCell celdaEditada;
        Boolean EditCancel = false;
        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //VALIDAR LA COLUMNA Y EL VALOR
            DataGridViewX grid = sender as DataGridViewX;
            SIFModelo.Usuario Usuario = ((ObjectView<SIFModelo.Usuario>)grid.CurrentRow.DataBoundItem).Object as SIFModelo.Usuario;

            //SIFModelo.Usuario usuarioEncontrado = new SIFNegocio.Usuarios().UsuarioPorAccesoID(Usuario);

            //if (usuarioEncontrado != null && usuarioEncontrado.UsuariosID != Usuario.UsuariosID)
            //{
            //    MessageBox.Show("Ya existe un usuario con ese nombre, por favor verifique");
            //    grid.CancelEdit();
            //    return;
            //}

            //SI ES MODIFICADO
            if (e.ColumnIndex == 6)
            {
                if (!Helpers.Sesion.Usuario.TipoUsuario.ToString().ToUpper().Contains("ADMINISTRATIVO"))
                {
                    if (Usuario.TipoUsuario.ToString().ToUpper().Contains("ADMINISTRATIVO"))
                    {

                        MessageBox.Show("No puede cambiar un usuario a tipo Administrativo, no tiene permisos suficientes, seleccione otro valor", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        EditCancel = true;
                        grid.CancelEdit();
                        return;
                    }
                }
            }
            if (Usuario.UsuariosID != 0)
            {
                this.Modificar(Usuario);
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
            SIFModelo.Usuario Usuario = ((ObjectView<SIFModelo.Usuario>)grid.CurrentRow.DataBoundItem).Object as SIFModelo.Usuario;

            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];

            if (e.ColumnIndex == 0)
            {
                SIFModelo.Usuario usuarioEncontrado = new SIFModelo.Usuario() { AccesoID = e.FormattedValue.ToString() };
                usuarioEncontrado = new SIFNegocio.Usuarios().UsuarioPorAccesoID(usuarioEncontrado);

                if (usuarioEncontrado != null && usuarioEncontrado.UsuariosID != Usuario.UsuariosID)
                {
                   MessageBox.Show("Ya existe un usuario con ese nombre, por favor verifique");
                    e.Cancel = true;
                    return;
                }
            }
            //RECUPERA EL NOMBRE DE LA PROPIEDAD Y LA COMPARA CON LA PROPIEDA DESEADA
            if (columna.DataPropertyName == Helpers.Reflect.GetMember(() => Usuario.Nombre).Name)
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

            if (columna.DataPropertyName == Helpers.Reflect.GetMember(() => Usuario.AccesoID).Name)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue as string) || e.FormattedValue as string == "ACCESO" || string.IsNullOrEmpty(e.FormattedValue as string))
                {
                   MessageBox.Show("El campo Acceso es obligatorio, verifique la información");
                    e.Cancel = true;
                    return;
                }
                if ((e.FormattedValue as string).Length > 10)
                {
                   MessageBox.Show("El campo Acceso es muy largo, verifique la información");
                }
            }

            /*********AVM 28-04-2015*********/
            /***SI EL ESTATUS ES TRUE, EN EL  METODO ENDEDIT SE VALIDO LOS PERMISOS PARA QUE NO PUDIERA MODIFICAR Y ESTABLECIO LA BANDERA ENTRUE*******/
            if (EditCancel == true)
            {
                e.Cancel = true;
                EditCancel = false;
                try
                {
                    if (propiedadBusqueda.Equals("AccesoID"))
                        logica.Buscar("ACCESO_ID", buscarTextBoxX.Text);
                    else
                        logica.Buscar("NOMBRE", buscarTextBoxX.Text);

                    dataGridViewX1.DataSource = logica.ListaUsuarios;
                }
                catch
                {
                }

                return;
            }
            /**************************************************/
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
            this.bindingSource.DataSource = logica.ListaUsuarios;
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
                    };
                    try
                    {
                        grid.CurrentCell = grid[iColNew, iRowNew];
                    }
                    catch
                    {
                        grid.CancelEdit();
                    }


                }
                grid.BeginEdit(true);
            }
            celdaEditada = null;

        }

        private void dataGridViewX1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        Boolean Action = false;
        private void dataGridViewX1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!Action)
            {
                Action = true;
                if (Owner is SucursalesUserControl)
                {
                    if (bindingSource.Current == null)
                    {
                        return;
                    }

                    ((SucursalesUserControl)this.Owner).AsignaUsuario(((ObjectView<SIFModelo.Usuario>)bindingSource.Current).Object as SIFModelo.Usuario);
                    this.Back();
                }

                if (Owner is View.Ventas.FoliocontroladoUserControl)
                {
                    if (bindingSource.Current == null)
                    {
                        return;
                    }

                    ((View.Ventas.FoliocontroladoUserControl)this.Owner).AsignaUsuario(((ObjectView<SIFModelo.Usuario>)bindingSource.Current).Object as SIFModelo.Usuario);
                    this.Back();
                }
                if (Owner is View.Seguridad.PerfilesUserControl)
                {
                    if (bindingSource.Current == null)
                    {
                        return;
                    }

                    ((View.Seguridad.PerfilesUserControl)this.Owner).AsignaUsuario(((ObjectView<SIFModelo.Usuario>)bindingSource.Current).Object as SIFModelo.Usuario);
                    this.Back();
                }
                if (Owner is View.Seguridad.BitacoraUserControl)
                {
                    if (bindingSource.Current == null)
                    {
                        return;
                    }

                    ((View.Seguridad.BitacoraUserControl)this.Owner).AsignaUsuario(((ObjectView<SIFModelo.Usuario>)bindingSource.Current).Object as SIFModelo.Usuario);
                    this.Back();
                }

                if (Owner is View.Seguridad.CompradorLaboratorioUserControl)
                {
                    if (bindingSource.Current == null)
                    {
                        return;
                    }

                    ((View.Seguridad.CompradorLaboratorioUserControl)this.Owner).AgregaUsuario(((ObjectView<SIFModelo.Usuario>)bindingSource.Current).Object as SIFModelo.Usuario);
                    this.Back();
                }
                Action = false;
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

            DataGridViewRow row = grid.Rows[e.RowIndex];
            try
            {
                row.ReadOnly = false;
            }
            catch
            {
                return;
            }
            if (row != null)
            {
                SIFModelo.Usuario modelo = ((ObjectView<SIFModelo.Usuario>)row.DataBoundItem).Object as SIFModelo.Usuario;

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

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if(dataGridViewX1.CurrentRow !=null)
                {
                SIFModelo.Usuario usuarioSeleccionado = ((ObjectView<SIFModelo.Usuario>)dataGridViewX1.CurrentRow.DataBoundItem).Object as SIFModelo.Usuario;
                if (usuarioSeleccionado.Activo.Equals(SIFModelo.Tipos.SiNo.NO))
                {
                   MessageBox.Show("No puede cambiar la contraseña a un usuario inactivo, debe activarlo antes.", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                SIF.View.Ventas.CambiarContrasenhaUsuarioLogin frmCambiarPassConfirm = new Ventas.CambiarContrasenhaUsuarioLogin(usuarioSeleccionado);
                if (frmCambiarPassConfirm.ShowDialog() == DialogResult.OK)
                {
                    SIF.View.Ventas.CambiarContrasenhaUsuario frmCambiarContraseña = new Ventas.CambiarContrasenhaUsuario(usuarioSeleccionado);
                    if(frmCambiarContraseña.ShowDialog() == DialogResult.OK)
                    {
                       MessageBox.Show("Acción realizada correctamente.", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.buscarLocal();
                    }
                }
            }
            }
        }
    }
}
