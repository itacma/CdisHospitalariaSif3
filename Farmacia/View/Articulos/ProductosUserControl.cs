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

namespace SIF.View.Articulos
{
    public partial class ProductosUserControl : SIF.Templates.CatalogoUserControl
    {
        public ProductosUserControl()
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
            //NuevoButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            //eliminarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
        }

        /// <summary>
        /// Activa los acesos cortos mediante el teclado
        /// </summary>
        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
            //NuevoButtonItem.Shortcuts.Clear();
            //eliminarButtonItem.Shortcuts.Clear();
        }

        private void Back()
        {
            try
            {
                if (Owner is View.Inventario.PNCNuevoUserControl)
                {
                    View.Inventario.PNCNuevoUserControl propietario = Owner as View.Inventario.PNCNuevoUserControl;
                    //propietario.ActivaComandos();
                    this.DesactivaComandos();

                    propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = false;
                }

                if (Owner is View.Inventario.PNCEditarUserControl)
                {
                    View.Inventario.PNCEditarUserControl propietario = Owner as View.Inventario.PNCEditarUserControl;
                    //propietario.ActivaComandos();
                    this.DesactivaComandos();

                    propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = false;
                }

            }
            catch
            {

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
            if (Owner is View.Inventario.ProductoNoConformeUserControl)
            {
                View.Inventario.ProductoNoConformeUserControl propietario = Owner as View.Inventario.ProductoNoConformeUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                //propietario.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
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

            dataGridViewX1.AutoGenerateColumns = false;

            //PROVEEDOR
            PROVEEDOR_NOMBREColumn.ButtonCustom.Image = global::SIF.Properties.Resources.User16;
            PROVEEDOR_NOMBREColumn.ButtonCustom.Visible = true;
            PROVEEDOR_NOMBREColumn.ButtonCustomClick += PROVEEDORColumn_ButtonCustom_CLICK;

            //LABORATORIO
            LABORATORIO_NOMBREColumn.ButtonCustom.Image = global::SIF.Properties.Resources.User16;
            LABORATORIO_NOMBREColumn.ButtonCustom.Visible = true;
            LABORATORIO_NOMBREColumn.ButtonCustomClick += LABORATORIOColumn_ButtonCustom_CLICK;
            //
            Dictionary<string, SIFModelo.Tipos.SiNo> SiNo = new Dictionary<string, SIFModelo.Tipos.SiNo>();

            SiNo.Add(Enum.GetName(typeof(SIFModelo.Tipos.SiNo), SIFModelo.Tipos.SiNo.SI), SIFModelo.Tipos.SiNo.SI);
            SiNo.Add(Enum.GetName(typeof(SIFModelo.Tipos.SiNo), SIFModelo.Tipos.SiNo.NO), SIFModelo.Tipos.SiNo.NO);

            this.SiNoBindingSource.DataSource = SiNo;

            ////TIPO MEDICAMENTO
            //SIFNegocio.TipoMedicamento tipoMedicamento = new SIFNegocio.TipoMedicamento();
            //TIPO_MEDICAMENTOColumn.DataSource = tipoMedicamento.Buscar("", "").DataSource;
            //TIPO_MEDICAMENTOColumn.DisplayMember = "Clave";
            //TIPO_MEDICAMENTOColumn.ValueMember = "Clave";

            //TIPO MONDEDA

            //TIPO MEDICAMENTO
            //TIPO_MEDICAMENTOColumn.ButtonCustom.Image = global::SIF.Properties.Resources.Especialidad16;
            //TIPO_MEDICAMENTOColumn.ButtonCustom.Visible = true;
            //TIPO_MEDICAMENTOColumn.ButtonCustomClick += LISTA_TIPO_MEDICAMENTO_Column_ButtonCustom_CLICK;

            //TIPO_MEDICAMENTOColumn.ButtonCustom.Image = global::SIF.Properties.Resources.Especialidad16;
            //TIPO_MEDICAMENTOColumn.ButtonCustom.Visible = true;
            //TIPO_MEDICAMENTOColumn.ReadOnly = false;
            EXISTENCIASColumn.Click += new EventHandler<EventArgs>(EXISTENCIASColumn_Click);
            TIPO_MEDICAMENTOColumn.Click += LISTA_TIPO_MEDICAMENTO_Column_ButtonCustom_CLICK;

            //SUCURSAL VENTA
            LISTA_SUCURSAL_VENTAColumn.ButtonCustom.Image = global::SIF.Properties.Resources.Especialidad16;
            LISTA_SUCURSAL_VENTAColumn.ButtonCustom.Visible = true;
            LISTA_SUCURSAL_VENTAColumn.ButtonCustomClick += LISTA_SUCURSAL_VENTAColumn_ButtonCustom_CLICK;

        }

        void EXISTENCIASColumn_Click(object sender, EventArgs e)
        {

        }

        void LISTA_SUCURSAL_VENTAColumn_ButtonCustom_CLICK(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn ddc =
                sender as DataGridViewTextBoxColumn;

            if (ddc != null)
            {
                this.current = ((ObjectView<SIFModelo.Articulo>)this.bindingSource.Current).Object as SIFModelo.Articulo;
                Catalogos.ListaSucursalVentaForm sucursalesForm = new Catalogos.ListaSucursalVentaForm(current);
                if (sucursalesForm.ShowDialog() == DialogResult.OK)
                {
                    current.LISTA_SUCURSAL_VTA = sucursalesForm.ListaSucursales;
                    dataGridViewX1.EndEdit();
                    this.Modificar(current);
                }
            }
        }

        void LISTA_TIPO_MEDICAMENTO_Column_ButtonCustom_CLICK(object sender, EventArgs e)
        {
            //DataGridViewTextBoxColumn ddc =
            //    sender as DataGridViewTextBoxColumn;

            DevComponents.DotNetBar.ImageItem ddc =
            sender as DevComponents.DotNetBar.ImageItem;

            if (ddc != null)
            {
                SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow row = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)this.dataGridViewX1.CurrentRow.DataBoundItem).Row; //((ObjectView<SIFModelo.Articulo>)this.bindingSource.Current).Object as SIFModelo.Articulo;

                current = new SIFNegocio.Articulo().BuscarPorClave(row.ARTICULO_ID);

                if (current == null)
                {
                    return;
                }

                Catalogos.ListaTipoMedicamentoForm tipoMedicamentoForm = new Catalogos.ListaTipoMedicamentoForm(current);
                tipoMedicamentoForm.aceptarButtonX.Enabled = false;
                tipoMedicamentoForm.notaLabel.Text = "En esta ventana no se puede realizar cambios";
                //tipoMedicamentoForm.listaTipoMedicamentoCheckedListBox. = false;
                if (tipoMedicamentoForm.ShowDialog() == DialogResult.OK)
                {
                    current.TIPO_MEDICAMENTO_CVE = tipoMedicamentoForm.ListaTipoMedicamento;
                    dataGridViewX1.EndEdit();
                    this.Modificar(current);
                }
            }
        }

        void PROVEEDORColumn_ButtonCustom_CLICK(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn ddc =
                sender as DataGridViewTextBoxColumn;

            if (ddc != null)
            {
                this.current = ((ObjectView<SIFModelo.Articulo>)this.bindingSource.Current).Object as SIFModelo.Articulo;
                Catalogos.ClienteControl ClientesForm = new Catalogos.ClienteControl();
                ClientesForm.Owner = this;
                ClientesForm.PROVEEDOR = true;
                ClientesForm.Muestra();
            }
        }

        void LABORATORIOColumn_ButtonCustom_CLICK(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn ddc =
                sender as DataGridViewTextBoxColumn;

            if (ddc != null)
            {
                this.current = ((ObjectView<SIFModelo.Articulo>)this.bindingSource.Current).Object as SIFModelo.Articulo;
                Catalogos.ClienteControl ClientesForm = new Catalogos.ClienteControl();
                ClientesForm.Owner = this;
                ClientesForm.LAB_MAYORISTA = true;
                ClientesForm.Muestra();
            }
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


            //if (this.logica.ListaArticulos.Count == 0 || this.buscarTextBoxX.Text.Length <= 1)
            //{
            if (!buscarBackgroundWorker.IsBusy)
            {
                this.buscarBackgroundWorker.RunWorkerAsync();
            }
            //}

            //if (this.buscarTextBoxX.Text.Length > 1)
            //{
            //    this.buscarLocal();
            //    this.dataGridViewX1.Cursor = Cursors.Default;
            //    return;
            //}


        }

        private bool Nuevo()
        {
            //this.dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);

            View.Catalogos.ClaveArticuloForm frmClave = new View.Catalogos.ClaveArticuloForm();

            if (frmClave.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            this.current = ((ObjectView<SIFModelo.Articulo>)this.bindingSource.AddNew()).Object as SIFModelo.Articulo;
            this.current.ARTICULO_ID = frmClave.Clave;
            this.current.NOMBRE1 = "NOMBRE";
            this.current.ACTIVO = SIFModelo.Tipos.SiNo.SI;
            this.current.TIPO_MONEDA = 1;
            this.current.NOMBRE2 = "NOMBRE 2";
            this.current.TIPO_MEDICAMENTO_CVE = " ";
            this.current.LABORATORIO_ID = 1;
            this.current.PROVEEDOR_ID = 1;
            this.current.U_COMPRA = "PIEZA";
            this.current.U_VENTA = "PIEZA";
            this.current.LISTA_SUCURSAL_VTA = "MATRIZ";
            this.current.PAQUETE = SIFModelo.Tipos.SiNo.NO;

            current.ACTIVO = SIFModelo.Tipos.SiNo.SI;

            if (logica.Nuevo(current).ARTICULO_ID == "")
            {
                logica.ListaArticulos.CancelNew(logica.ListaArticulos.Count - 1);
                dataGridViewX1.CancelEdit();
                dataGridViewX1.Refresh();

                return false;
            }
            else
            {
                this.dataGridViewX1.CurrentCell = dataGridViewX1.CurrentRow.Cells[1];
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
            this.Buscar();

            if (string.IsNullOrEmpty(propiedadBusqueda))
            {
                SIFModelo.Articulo articulo = new SIFModelo.Articulo();
                propiedadBusqueda = Helpers.Reflect.GetMember(() => articulo.NOMBRE1).Name;
            }

            try
            {
                logica.ListaArticulos.ApplyFilter(delegate (SIFModelo.Articulo customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
            }
            catch
            {
            }
        }

        private void seleccionaArticulo()
        {
            if (Owner is View.Inventario.PNCNuevoUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null) 
                    {
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;                     
                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                        View.Inventario.PNCNuevoUserControl frmOwner = Owner as View.Inventario.PNCNuevoUserControl;
                        
                        if (rowArticulo.DISPONIBLE > 0)
                        {
                            frmOwner.AgregaArticulo(articulo);
                            this.Back();
                        } else
                        {
                           MessageBox.Show("Los productos disponibles deben ser mayor a cero", "Producto no conforme");
                        }                        
                    }
                }
            }

            if (Owner is View.Inventario.PNCEditarUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;
                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                        View.Inventario.PNCEditarUserControl frmOwner = Owner as View.Inventario.PNCEditarUserControl;

                        if (rowArticulo.DISPONIBLE > 0)
                        {
                            frmOwner.AgregaArticulo(articulo);
                            this.Back();
                        }
                        else
                        {
                           MessageBox.Show("Los disponibles deben ser mayor a cero", "Producto no conforme");
                        }
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

        private void eliminarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        private void CatArticulosUserControl_Load(object sender, EventArgs e)
        {
            this.bindingSource.DataSource = this.logica.ListaArticulos;
            this.dataGridViewX1.DataSource = bindingSource;
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
            if (e.KeyData == Keys.Down)
            {
                this.dataGridViewX1.Focus();
                return;
            }
            this.Buscar();
        }

        public bool soloActivos = true;
        public SIFModelo.Usuario usuario;
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string parametroBusqueda = "%" + this.buscarTextBoxX.Text.Replace(' ', '%') + "%";

            //if (string.IsNullOrEmpty(this.propiedadBusqueda))
            //{
            //if (this.buscarTextBoxX.Text.Length > 3)
            //{

            //if (Owner is OrdenCompra.OrdenCompraUserControl)
            //{
            //    //BUSCAR SOLO LOS QUE PUEDE COMPRAR
            //    logica.BuscarPorComprador(usuario);

            //    return;
            //}

            if (Owner is SIF.View.Ventas.VentaUserControl)
            {
                SIF.View.Ventas.VentaUserControl Padre = Owner as SIF.View.Ventas.VentaUserControl;
                if (Padre.ClienteSub == null)
                    logica.BuscarConInventario(parametroBusqueda, Helpers.Sesion.Sucursal, propiedadBusqueda);
                else
                    if (Padre.ClienteSub.PRECIO_FIJO == SIFModelo.Tipos.SiNo.SI)
                    logica.BuscarConInventarioSub(parametroBusqueda, Helpers.Sesion.Sucursal, propiedadBusqueda);
                else
                    logica.BuscarConInventario(parametroBusqueda, Helpers.Sesion.Sucursal, propiedadBusqueda);
            }
            else
            {
                //if (Owner is SIF.View.OrdenCompra.OrdenCompraUserControl)
                //{
                //    logica.Buscar(propiedadBusqueda, parametroBusqueda);
                //    return;
                //}

                if (soloActivos)
                {
                    logica.BuscarConInventarioActivo(parametroBusqueda, Helpers.Sesion.Sucursal, propiedadBusqueda);
                }
                else
                {
                    logica.BuscarConInventario(parametroBusqueda, Helpers.Sesion.Sucursal, propiedadBusqueda);
                }
            }
            //}
            //}
            //else
            //{
            //    logica.BuscarConInventario(parametroBusqueda, Helpers.Sesion.Sucursal, propiedadBusqueda);
            //}
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.dataGridViewX1.DataSource = logica.InventarioDataSet.ARTICULO_INVENTARIO;
            this.dataGridViewX1.Cursor = Cursors.Default;

            this.Cursor = Cursors.Default;
            this.buscarTextBoxX.Focus();
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

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public string Funcion { get; set; }


    }
}
