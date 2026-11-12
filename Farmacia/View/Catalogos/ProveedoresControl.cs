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
    public partial class ProveedoresControl : Templates.CatalogoUserControl
    {
        public ProveedoresControl()
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
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 43, int.Parse(Xbtn.Tag.ToString()));

            }
            dataGridViewX1.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 43, 2);
        }

        public bool Mostrado;
        public object Owner;

        private SIFNegocio.Clientes logica = new SIFNegocio.Clientes();
        private string propiedadBusqueda = "";
        SIFModelo.Cliente current;

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


                if (this.Owner is Menu.ConfiguracionMenu)
                {
                    Menu.ConfiguracionMenu propietario = this.Owner as Menu.ConfiguracionMenu;
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
                if (this.Owner is Catalogos.ArticuloUserControl)
                {
                    Catalogos.ArticuloUserControl propietario = this.Owner as Catalogos.ArticuloUserControl;
                    if (propietario.Owner is Menu.CatalogosUserControl)
                    {
                        Menu.CatalogosUserControl catalogoOwner = propietario.Owner as Menu.CatalogosUserControl;
                        if (this.Mostrado && catalogoOwner.Owner.Owner.IsModalPanelDisplayed)
                        {
                            this.DesactivaComandos();
                            if (catalogoOwner.Owner.Owner.Contains(this))
                            {
                                catalogoOwner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                            }
                            catalogoOwner.ActivaComandos();
                            this.Mostrado = false;
                        }
                    }

                    if (propietario.Owner is Menu.ConfiguracionMenu)
                    {
                        Menu.ConfiguracionMenu catalogoOwner = propietario.Owner as Menu.ConfiguracionMenu;
                        if (this.Mostrado && catalogoOwner.Owner.IsModalPanelDisplayed)
                        {
                            this.DesactivaComandos();
                            if (catalogoOwner.Owner.Contains(this))
                            {
                                catalogoOwner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                            }
                            propietario.ActivaComandos();
                            this.Mostrado = false;
                        }
                    }


                }

                if (this.Owner is Ventas.VentaUserControl)
                {
                    Ventas.VentaUserControl propietario = (Ventas.VentaUserControl)this.Owner;

                    MainForm frmMain = propietario.Owner.Owner as MainForm;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();
                    this.Dock = DockStyle.Fill;
                    if (frmMain.Contains(this))
                    {
                        frmMain.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Mostrado = true;
                }

                if (this.Owner is MainForm)
                {
                    MainForm catalogoOwner = this.Owner as MainForm;
                    if (this.Mostrado && catalogoOwner.IsModalPanelDisplayed)
                    {
                        this.DesactivaComandos();
                        if (catalogoOwner.Contains(this))
                        {
                            catalogoOwner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        catalogoOwner.ActivaComandos();
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
            if (this.Owner is MainForm)
            {
                MainForm propietario = (MainForm)this.Owner;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (this.Owner is SIF.View.Menu.ConfiguracionMenu)
            {
                SIF.View.Menu.ConfiguracionMenu propietario = (SIF.View.Menu.ConfiguracionMenu)this.Owner;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (this.Owner is Catalogos.ArticuloUserControl)
            {
                Catalogos.ArticuloUserControl propietario = (Catalogos.ArticuloUserControl)this.Owner;

                if (propietario.Owner is Menu.ConfiguracionMenu)
                {
                    Menu.ConfiguracionMenu propietarioMenu = propietario.Owner as Menu.ConfiguracionMenu;

                    propietarioMenu.Owner.DesactivaComandos();
                    propietarioMenu.DesactivaComandos();
                    propietario.DesactivaComandos();
                    this.ActivaComandos();
                    this.Dock = DockStyle.Fill;

                    propietarioMenu.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = true;
                }
            }

            if (this.Owner is Ventas.VentaUserControl)
            {
                Ventas.VentaUserControl propietario = (Ventas.VentaUserControl)this.Owner;

                MainForm frmMain = propietario.Owner.Owner as MainForm;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                frmMain.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;

            }

            this.Buscar();
            this.buscarTextBoxX.Focus();
        }


        #endregion

        #region Funciones y Metodos Privados

        private void InicializaColumnas()
        {
            this.dataGridViewX1.AutoGenerateColumns = false;
            //BUSQUEDA LOCAL
            SIFModelo.Cliente modelo = new SIFModelo.Cliente();
            this.propiedadBusqueda = Helpers.Reflect.GetMember(() => modelo.Nombre).Name;

            //
            Dictionary<string, SIFModelo.Tipos.SiNo> SiNo = new Dictionary<string, SIFModelo.Tipos.SiNo>();
            SiNo.Add(Enum.GetName(typeof(SIFModelo.Tipos.SiNo), SIFModelo.Tipos.SiNo.SI), SIFModelo.Tipos.SiNo.SI);
            SiNo.Add(Enum.GetName(typeof(SIFModelo.Tipos.SiNo), SIFModelo.Tipos.SiNo.NO), SIFModelo.Tipos.SiNo.NO);

            this.SiNoBindingSource.DataSource = SiNo;

            //TIPO CLIENTE
            Dictionary<string, SIFModelo.Tipos.TipoCliente> TiposCliente = new Dictionary<string, SIFModelo.Tipos.TipoCliente>();
            TiposCliente.Add(Enum.GetName(typeof(SIFModelo.Tipos.TipoCliente), SIFModelo.Tipos.TipoCliente.FISICA), SIFModelo.Tipos.TipoCliente.FISICA);
            TiposCliente.Add(Enum.GetName(typeof(SIFModelo.Tipos.TipoCliente), SIFModelo.Tipos.TipoCliente.MORAL), SIFModelo.Tipos.TipoCliente.MORAL);
            TIPO_CLIENTEbindingSource.DataSource = TiposCliente;

            TIPOColumn.DataSource = TIPO_CLIENTEbindingSource;
            TIPOColumn.DisplayMember = "Key";
            TIPOColumn.ValueMember = "Value";

            //SINO
            BOLETINADOColumn.DataSource = SiNoBindingSource;
            BOLETINADOColumn.DisplayMember = "Key";
            BOLETINADOColumn.ValueMember = "Value";

            CONVENIOColumn.DataSource = SiNoBindingSource;
            CONVENIOColumn.DisplayMember = "Key";
            CONVENIOColumn.ValueMember = "Value";

            LOTE_CADUCIDADColumn.DataSource = SiNoBindingSource;
            LOTE_CADUCIDADColumn.DisplayMember = "Key";
            LOTE_CADUCIDADColumn.ValueMember = "Value";


            //LABORATORIO MAYORISTA
            Dictionary<string, SIFModelo.Tipos.LaboratorioMayorista> LaboratorioMayorista = new Dictionary<string, SIFModelo.Tipos.LaboratorioMayorista>();
            LaboratorioMayorista.Add(Enum.GetName(typeof(SIFModelo.Tipos.LaboratorioMayorista), SIFModelo.Tipos.LaboratorioMayorista.NINGUNO), SIFModelo.Tipos.LaboratorioMayorista.NINGUNO);
            LaboratorioMayorista.Add(Enum.GetName(typeof(SIFModelo.Tipos.LaboratorioMayorista), SIFModelo.Tipos.LaboratorioMayorista.LABORATORIO), SIFModelo.Tipos.LaboratorioMayorista.LABORATORIO);
            LaboratorioMayorista.Add(Enum.GetName(typeof(SIFModelo.Tipos.LaboratorioMayorista), SIFModelo.Tipos.LaboratorioMayorista.MAYORISTA), SIFModelo.Tipos.LaboratorioMayorista.MAYORISTA);

            LABORATORIO_MAYORISTAbindingSource.DataSource = LaboratorioMayorista;

            LAB_MAYORISTAColumn.DataSource = LABORATORIO_MAYORISTAbindingSource;
            LAB_MAYORISTAColumn.DisplayMember = "Key";
            LAB_MAYORISTAColumn.ValueMember = "Value";

            //TIPO DE DIRECCION
            Dictionary<string, SIFModelo.Tipos.TipoDireccion> TiposDireccion = new Dictionary<string, SIFModelo.Tipos.TipoDireccion>();

            foreach (var direccion in new SIFNegocio.Clientes().Direcciones())
            {
                TiposDireccion.Add(direccion.Tipo, direccion);
            }

            this.TIPO_DIRECCIONbindingSource.DataSource = TiposDireccion;
            this.TIPO_DIRColumn.DataSource = TIPO_DIRECCIONbindingSource;
            TIPO_DIRColumn.DisplayMember = "Key";
            TIPO_DIRColumn.ValueMember = "Value";
        }

        private void TIPO_DIRECCIONColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridComboBoxExEditControl tipo_dir = sender as GridComboBoxExEditControl;
            SIFModelo.Cliente cliente = this.bindingSource.Current as SIFModelo.Cliente;

            if (tipo_dir.SelectedValue == null)
            {
                return;
            }

            cliente.TipoDireccion = tipo_dir.SelectedValue as SIFModelo.Tipos.TipoDireccion;

            DireccionClienteForm frmDirCliente = new DireccionClienteForm(cliente);
            frmDirCliente.ShowDialog();
        }

        private void Buscar()
        {
            //this.dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            this.statusLabel.Text = "Buscando elementos...";
            dataGridViewX1.Cursor = Cursors.WaitCursor;
            if (!buscarBackgroundWorker.IsBusy)
            {
                this.buscarBackgroundWorker.RunWorkerAsync();
            }
            dataGridViewX1.DataSource = bindingSource;
            dataGridViewX1.Refresh();
        }

        private bool Nuevo()
        {
            this.dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);

            this.current = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.AddNew()).Object as SIFModelo.Cliente;
            this.current.Activo = SIFModelo.Tipos.SiNo.SI;
            this.current.ApellidoMaterno = "APELLIDO MATERNO";
            this.current.ApellidoPaterno = "APELLIDO PATERNO";
            this.current.Boletinado = SIFModelo.Tipos.SiNo.NO;
            this.current.Convenio = SIFModelo.Tipos.SiNo.NO;
            this.current.Descuento = 0;
            this.current.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            this.current.LaboratorioMayorista = SIFModelo.Tipos.LaboratorioMayorista.NINGUNO;
            this.current.LoteCaducidad = SIFModelo.Tipos.SiNo.NO;
            this.current.Nombre = "NOMBRE";
            this.current.Proveedor = SIFModelo.Tipos.SiNo.SI;
            this.current.TipoCliente = SIFModelo.Tipos.TipoCliente.FISICA;
            this.current.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
            this.current.ReferenciaBeneficio = "0";
            //SIFModelo.Usuario usu = SIF.Helpers.Sesion.UsuarioSeleccionadoVenta;
          //  this.current.ReferenciaBeneficio = usu.UsuariosID.ToString();
            if (this.logica.Nuevo(current).ID == 0)
            {
                MessageBox.Show("Ha ocurrido un error al agregar el Cliente, verifique que su información sea correcta");
                logica.CatClientesList.CancelNew(logica.CatClientesList.Count - 1);
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
            //        SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)registro.DataBoundItem).Object as SIFModelo.Cliente;

            //        if (cliente.Activo == SIFModelo.Tipos.SiNo.NO)
            //        {
            //            continue;
            //        }

            //        cliente.Activo = SIFModelo.Tipos.SiNo.NO;
            //        cliente.FechaBaja = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

            //        if (!logica.Modificar(cliente))
            //        {
            //           MessageBox.Show("No se eliminó el registro " + cliente.Nombre);
            //        }

            //    }
            //}


            SIFModelo.Cliente modelo = ((ObjectView<SIFModelo.Cliente>)dataGridViewX1.CurrentRow.DataBoundItem).Object as SIFModelo.Cliente;

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

        private Boolean Modificar(SIFModelo.Cliente Cliente)
        {
            this.Cursor = Cursors.WaitCursor;
            this.statusLabel.Text = "Actualizando registro...";

            bool modificado = logica.Modificar(Cliente);

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
                propiedadBusqueda = new SIFModelo.Cliente().GetType().GetProperties()[0].Name;
            }

            if (logica.CatClientesList == null || logica.CatClientesList.Count == 0)
            {
                Buscar();
            }

            try
            {
                logica.CatClientesList.ApplyFilter(delegate(SIFModelo.Cliente customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
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
            this.current = this.bindingSource.Current as SIFModelo.Cliente;
        }

        private void eliminarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        private void CatClientesUserControl_Load(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Focus();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        DataGridViewCell celdaEditada;
        public bool PROVEEDOR;
        public bool LAB_MAYORISTA;

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
            SIFModelo.Cliente Cliente = ((ObjectView<SIFModelo.Cliente>)grid.CurrentRow.DataBoundItem).Object as SIFModelo.Cliente;

            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];

            //RECUPERA EL NOMBRE DE LA PROPIEDAD Y LA COMPARA CON LA PROPIEDA DESEADA
            if (columna.DataPropertyName == Helpers.Reflect.GetMember(() => Cliente.Nombre).Name)
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
            //if (columna.DataPropertyName == Helpers.Reflect.GetMember(() => Cliente.Comision).Name)
            //{
            //    if ((e.FormattedValue as string).IsFloatPositive())
            //    {
            //        decimal comision = System.Convert.ToDecimal(e.FormattedValue);
            //        if (comision > 100 || comision < 0)
            //        {
            //           MessageBox.Show("El valor no está dentro del rango válido, verifique la información");
            //            e.Cancel = true;
            //            return;
            //        }
            //    }
            //    else
            //    {
            //       MessageBox.Show("Ingrese un número válido dentro del rango, verifique la información");
            //        e.Cancel = true;
            //        return;
            //    }
            //}
        }


        private void SeleccionaCliente()
        {
            if (this.Owner is Catalogos.ArticuloUserControl)
            {
                Catalogos.ArticuloUserControl propietario = (Catalogos.ArticuloUserControl)this.Owner;
                SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.Current).Object as SIFModelo.Cliente;
                if (this.PROVEEDOR)
                {
                    propietario.AgregarCliente(cliente);
                }
                if (LAB_MAYORISTA)
                {
                    propietario.AgregarLaboratorio(cliente);
                }
                this.Back();
            }

            if (this.Owner is Ventas.VentaUserControl)
            {
                Ventas.VentaUserControl propietario = (Ventas.VentaUserControl)this.Owner;

                if (this.bindingSource.Current == null)
                {
                    return;
                }

                SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.Current).Object as SIFModelo.Cliente;

                propietario.ActivaComandos();
                propietario.AgregaCliente(cliente);
                this.Back();
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

            buscarLocal();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //buscar en general
            if (this.Owner is Menu.ConfiguracionMenu || this.Owner is MainForm)
            {
                logica.BuscarProveedores(Helpers.Reflect.GetMember(() => PROVEEDOR).Name, "");
            }

            //buscar los proveedores
            if (this.Owner is Catalogos.ArticuloUserControl)
            {
                if (this.PROVEEDOR)
                {
                    logica.BuscarProveedores(Helpers.Reflect.GetMember(() => PROVEEDOR).Name, "");
                }
                if (this.LAB_MAYORISTA)
                {
                    logica.BuscarProveedores(Helpers.Reflect.GetMember(() => LAB_MAYORISTA).Name, "");
                }
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.bindingSource.DataSource = logica.CatClientesList;
            this.dataGridViewX1.DataSource = bindingSource;
            dataGridViewX1.Refresh();
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

        private void dataGridViewX1_EndEdit(object sender, GridEditEventArgs e)
        {
            //VALIDAR LA COLUMNA Y EL VALOR
            GridPanel grid = (sender as SuperGridControl).PrimaryGrid;
            SIFModelo.Cliente Cliente = this.bindingSource.Current as SIFModelo.Cliente;

            //SI ES MODIFICADO
            if (Cliente.ID != 0)
            {
                this.Modificar(Cliente);
            }

            //celdaEditada = grid[e.ColumnIndex, e.RowIndex]; 
        }

        private void dataGridViewX1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.SeleccionaCliente();
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
            SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)grid.CurrentRow.DataBoundItem).Object as SIFModelo.Cliente;


            //SI ES MODIFICADO
            if (cliente != null && cliente.ID != 0)
            {
                this.Modificar(cliente);
            }


            celdaEditada = grid[e.ColumnIndex, e.RowIndex];

            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];
            if (columna.DataPropertyName == Helpers.Reflect.GetMember(() => cliente.TipoDireccion).Name)
            {
                DireccionClienteForm frmDireccion = new DireccionClienteForm(cliente);

                frmDireccion.ShowDialog();
            }
        }

        private void dataGridViewX1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewX grid = sender as DataGridViewX;

            DataGridViewRow row = grid.Rows[e.RowIndex];
            row.ReadOnly = false;
            if (row != null)
            {
                SIFModelo.Cliente modelo = ((ObjectView<SIFModelo.Cliente>)row.DataBoundItem).Object as SIFModelo.Cliente;

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
