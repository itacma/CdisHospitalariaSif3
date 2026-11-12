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
    public partial class ArticuloUserControl : Templates.CatalogoUserControl
    {
        public int cualmenu;
        public ArticuloUserControl()
        {
            InitializeComponent();
            OcultaBoton();
            this.InicializaColumnas();
            Privilegios();
        }
        private void OcultaBoton()
        {
            if (Helpers.Sesion.Usuario.TipoUsuario != SIFModelo.Tipos.TipoUsuario.ADMINISTRATIVO && Helpers.Sesion.Usuario.TipoUsuario != SIFModelo.Tipos.TipoUsuario.VENDENDOR)
            {
                  transferButtonItem.Visible=false;
                  editarButtonItem.Visible = false;
                  preciosButtonItem.Visible = false;
                  existenciasButtonItem.Visible = false;
                  mayoristasButtonItem.Visible = false;
                  NuevoButtonItem.Visible = false;
                  eliminarButtonItem.Visible = false;
                  catArticulosBajaButtonItem.Visible = false;
            }

        }
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    //if (cualmenu == 0)
                    //{
                    //    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 34, int.Parse(Xbtn.Tag.ToString()));
                    //    dataGridViewX1.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 34, 2);
                    //}

                    //else
                    //{
                        Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 41, int.Parse(Xbtn.Tag.ToString()));
                        dataGridViewX1.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 41, 2);
                    //}

            }

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
                if (Owner is OrdenCompra.FacturaDetallesUserControl)
                {
                    View.OrdenCompra.FacturaDetallesUserControl propietario = Owner as View.OrdenCompra.FacturaDetallesUserControl;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();
                    this.Dock = DockStyle.Fill;

                    if (propietario.Owner.Owner.Owner.Contains(this))
                    {
                        propietario.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Mostrado = true;
                }

                if (Owner is OrdenCompra.OrdenCompraUserControl)
                {
                    View.OrdenCompra.OrdenCompraUserControl propietario = Owner as View.OrdenCompra.OrdenCompraUserControl;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();

                    if (propietario.Owner is Menu.ComprasMenu)
                    {

                        Menu.ComprasMenu propietarioOwner = propietario.Owner as Menu.ComprasMenu;
                        if (propietarioOwner.Owner.Contains(this))
                        {
                            propietarioOwner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                    }

                    if (propietario.Owner is SIF.View.OrdenCompra.OrdenesCompraUserControl)
                    {
                        SIF.View.OrdenCompra.OrdenesCompraUserControl propietarioOwner = propietario.Owner as SIF.View.OrdenCompra.OrdenesCompraUserControl;
                        if (propietarioOwner.Owner is Menu.ComprasMenu)
                        {
                            Menu.ComprasMenu propietarioOwnerOwner = propietarioOwner.Owner as Menu.ComprasMenu;
                            if (propietarioOwnerOwner.Owner.Contains(this))
                            {
                                propietarioOwnerOwner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                            }
                        }
                    }

                    this.Mostrado = false;
                }

                if (Owner is Menu.ConfiguracionMenu)
                {
                    Menu.ConfiguracionMenu propietario = Owner as Menu.ConfiguracionMenu;
                    if (this.Mostrado && propietario.Owner.IsModalPanelDisplayed)
                    {
                        this.DesactivaComandos();
                        if (propietario.Owner.Contains(this))
                        {
                            if (propietario.Owner.Contains(this))
                            {
                                propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                            }
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
                if (Owner is View.OrdenCompra.BonificacionDetallesUserControl)
                {
                    View.OrdenCompra.BonificacionDetallesUserControl propietario = Owner as View.OrdenCompra.BonificacionDetallesUserControl;
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

                if (Owner is View.OrdenCompra.AjusteInventarioDetallesUserControl)
                {
                    View.OrdenCompra.AjusteInventarioDetallesUserControl propietario = Owner as View.OrdenCompra.AjusteInventarioDetallesUserControl;
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

                if (Owner is Ventas.CotizacionUserControl)
                {
                    Ventas.CotizacionUserControl propietario = Owner as Ventas.CotizacionUserControl;
                    //propietario.ActivaComandos();
                    //this.DesactivaComandos();
                    this.Dock = DockStyle.Fill;

                    if (propietario.Owner is Ventas.VentaUserControl)
                    {
                        Ventas.VentaUserControl propietarioOwner = propietario.Owner as Ventas.VentaUserControl;
                        this.DesactivaComandos();
                        if (propietarioOwner.Owner.Owner.Contains(this))
                        {
                            propietarioOwner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        propietario.ActivaComandos();

                        this.Mostrado = false;
                    }

                    if (propietario.Owner is View.Menu.CatMenu)
                    {
                        View.Menu.CatMenu propietarioOwner = propietario.Owner as View.Menu.CatMenu;
                        propietarioOwner.ActivaComandos();
                        this.DesactivaComandos();
                        if (propietarioOwner.Owner.Contains(this))
                        {
                            propietarioOwner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        this.Mostrado = false;
                    }

                    this.Mostrado = false;
                }

                if (Owner is View.OrdenCompra.ManejoDescuentosDetalleUserControl)
                {
                    View.OrdenCompra.ManejoDescuentosDetalleUserControl propietario = Owner as View.OrdenCompra.ManejoDescuentosDetalleUserControl;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();

                    propietario.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = false;
                }

                if (Owner is Menu.InventarioMenu)
                {
                    Menu.InventarioMenu propietario = Owner as Menu.InventarioMenu;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();
                    if (propietario.Owner.Contains(this))
                    {
                        propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Mostrado = false;
                }

                if (Owner is OrdenCompra.DevolucionReposicionDetallesUserControl)
                {
                    OrdenCompra.DevolucionReposicionDetallesUserControl propietario = Owner as OrdenCompra.DevolucionReposicionDetallesUserControl;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();
                    this.Dock = DockStyle.Fill;

                    if (propietario.Owner.Owner.Owner.Contains(this))
                    {
                        propietario.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
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
            if (Owner is OrdenCompra.DevolucionReposicionDetallesUserControl)
            {
                OrdenCompra.DevolucionReposicionDetallesUserControl propietario = Owner as OrdenCompra.DevolucionReposicionDetallesUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }


            if (Owner is OrdenCompra.FacturaDetallesUserControl)
            {
                View.OrdenCompra.FacturaDetallesUserControl propietario = Owner as View.OrdenCompra.FacturaDetallesUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (Owner is OrdenCompra.OrdenCompraUserControl)
            {
                View.OrdenCompra.OrdenCompraUserControl propietario = Owner as View.OrdenCompra.OrdenCompraUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;


                if (propietario.Owner is Menu.ComprasMenu)
                {
                    Menu.ComprasMenu propietarioOwner = propietario.Owner as Menu.ComprasMenu;
                    propietarioOwner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }
                if (propietario.Owner is SIF.View.OrdenCompra.OrdenesCompraUserControl)
                {
                    SIF.View.OrdenCompra.OrdenesCompraUserControl propietarioOwner = propietario.Owner as SIF.View.OrdenCompra.OrdenesCompraUserControl;
                    if (propietarioOwner.Owner is Menu.ComprasMenu)
                    {
                        Menu.ComprasMenu propietarioOwnerOwner = propietarioOwner.Owner as Menu.ComprasMenu;
                        propietarioOwnerOwner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                }

                this.Mostrado = true;
            }


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
            if (Owner is View.Catalogos.ArticuloUserControl)
            {
                /*View.Catalogos.ArticuloUserControl propietario = Owner as View.Catalogos.ArticuloUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;*/
            }

            if (Owner is View.OrdenCompra.BonificacionDetallesUserControl)
            {
                View.OrdenCompra.BonificacionDetallesUserControl propietario = Owner as View.OrdenCompra.BonificacionDetallesUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (Owner is View.OrdenCompra.AjusteInventarioDetallesUserControl)
            {
                View.OrdenCompra.AjusteInventarioDetallesUserControl propietario = Owner as View.OrdenCompra.AjusteInventarioDetallesUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (Owner is Ventas.CotizacionUserControl)
            {
                Ventas.CotizacionUserControl propietario = Owner as Ventas.CotizacionUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                if (propietario.Owner is Ventas.VentaUserControl)
                {
                    Ventas.VentaUserControl propietarioOwner = propietario.Owner as Ventas.VentaUserControl;
                    propietarioOwner.DesactivaComandos();
                    propietarioOwner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }

                if (propietario.Owner is View.Menu.CatMenu)
                {
                    View.Menu.CatMenu propietarioOwner = propietario.Owner as View.Menu.CatMenu;
                    propietarioOwner.DesactivaComandos();
                    propietarioOwner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }

                this.Mostrado = true;
            }

            if (Owner is View.OrdenCompra.ManejoDescuentosDetalleUserControl)
            {
                View.OrdenCompra.ManejoDescuentosDetalleUserControl propietario = Owner as View.OrdenCompra.ManejoDescuentosDetalleUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (Owner is Menu.InventarioMenu)
            {
                Menu.InventarioMenu propietario = Owner as Menu.InventarioMenu;
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
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
            SIFNegocio.Monedas monedaL = new SIFNegocio.Monedas();
            BindingSource bs = new BindingSource();
            bs.DataSource = monedaL.Buscar("", "");

            TIPO_MONEDAColumn.DataSource = bs;
            TIPO_MONEDAColumn.DisplayMember = "Nombre";
            TIPO_MONEDAColumn.ValueMember = "ID";

            //TIPO MEDICAMENTO
            TIPO_MEDICAMENTOColumn.ButtonCustom.Image = global::SIF.Properties.Resources.Especialidad16;
            TIPO_MEDICAMENTOColumn.ButtonCustom.Visible = true;
            TIPO_MEDICAMENTOColumn.ButtonCustomClick += LISTA_TIPO_MEDICAMENTO_Column_ButtonCustom_CLICK;

            //SUCURSAL VENTA
            LISTA_SUCURSAL_VENTAColumn.ButtonCustom.Image = global::SIF.Properties.Resources.Especialidad16;
            LISTA_SUCURSAL_VENTAColumn.ButtonCustom.Visible = true;
            LISTA_SUCURSAL_VENTAColumn.ButtonCustomClick += LISTA_SUCURSAL_VENTAColumn_ButtonCustom_CLICK;

        }

        void LISTA_SUCURSAL_VENTAColumn_ButtonCustom_CLICK(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn ddc =
                sender as DataGridViewTextBoxColumn;

            if (ddc != null)
            {
                this.current = ((ObjectView<SIFModelo.Articulo>)this.bindingSource.Current).Object as SIFModelo.Articulo;
                Catalogos.ListaSucursalVentaForm sucursalesForm = new ListaSucursalVentaForm(current);
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
            DataGridViewTextBoxColumn ddc =
                sender as DataGridViewTextBoxColumn;

            if (ddc != null)
            {
                this.current = ((ObjectView<SIFModelo.Articulo>)this.bindingSource.Current).Object as SIFModelo.Articulo;
                Catalogos.ListaTipoMedicamentoForm tipoMedicamentoForm = new ListaTipoMedicamentoForm(current);
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
                Catalogos.ClienteControl ClientesForm = new ClienteControl();
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
                Catalogos.ClienteControl ClientesForm = new ClienteControl();
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

            this.Cursor = Cursors.WaitCursor;
            //if (this.logica.ListaArticulos.Count == 0 || this.buscarTextBoxX.Text.Length <= 1)
            //{
            if (!buscarBackgroundWorker.IsBusy)
            {
                this.buscarBackgroundWorker.RunWorkerAsync(this.buscarTextBoxX.Text);
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
             SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
             SIFModelo.Articulo articulo = new SIFModelo.Articulo(); ;
            //this.dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);

            ClaveArticuloForm frmClave = new ClaveArticuloForm();

            if (frmClave.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            else
            {
                articulo = articuloL.BuscarPorClave(frmClave.Clave);
                if(articulo==null)
                {

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

                string listaSuc = "";

                List<SIFModelo.Sucursal> sucursales = new SIFNegocio.Sucursales().Buscar("", "").DataSource as List<SIFModelo.Sucursal>;

                foreach (SIFModelo.Sucursal suc in sucursales)
                {
                    listaSuc += suc.SucursalesID + "|";
                }
                listaSuc = listaSuc.Trim('|');
                this.current.LISTA_SUCURSAL_VTA = listaSuc;


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
                    ArticuloEditarForm frmArticulo = new ArticuloEditarForm(current);
                    frmArticulo.ShowDialog();

                    //lista precios

                    SIFModelo.Inventarios.ListaPrecios precio = new SIFModelo.Inventarios.ListaPrecios();

                    precio.ACTIVO = SIFModelo.Tipos.SiNo.SI;
                    precio.ARTICULO_ID = current.ARTICULO_ID;
                    precio.COSTO_PROM = 0;
                    precio.COSTO_ULT_COMPRA = 0;
                    precio.FECHA_ALTA = DateTime.Now;
                    //precio.FECHA_BAJA = null;
                    precio.IMP_COMPRA = 0;
                    precio.IMP_VENTA = 0;
                    precio.PRECIO_COSTO = 0;
                    precio.PRECIO_VENTA = 0;
                    precio.PRECIO_VENTA_FARM = 0;
                    precio.PRECIO_VENTA_MAX = 0;
                    precio.SUCURSAL_ID = SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID;


                    SIFNegocio.Articulo.InsertaListaPrecios(precio);

                    // Modificar(current);
                    //this.dataGridViewX1.CurrentCell = dataGridViewX1.CurrentRow.Cells[1];
                    //this.dataGridViewX1.BeginEdit(true);
                    return true;
                }
                    
                }
                else
                {
                    MessageBox.Show("El Codigo ya existen en el catalogo: " + Environment.NewLine + "Codigo: " + articulo.ARTICULO_ID + Environment.NewLine + "Nombre: " + articulo.NOMBRE1 + Environment.NewLine + "Nombre2: " + articulo.NOMBRE2+Environment.NewLine+"Activo:"+articulo.ACTIVO);
                    return false;
                }
            }
        }

        private bool Eliminar()
        {
            int registros = dataGridViewX1.SelectedCells.Count;
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
                logica.ListaArticulos.ApplyFilter(delegate(SIFModelo.Articulo customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
            }
            catch
            {
            }
        }

        private void seleccionaArticulo()
        {
            if (Owner is OrdenCompra.FacturaDetallesUserControl)
            {
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);
                        OrdenCompra.FacturaDetallesUserControl frmVenta = this.Owner as OrdenCompra.FacturaDetallesUserControl;
                        frmVenta.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }

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

            if (Owner is Ventas.VentaUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);
                        Ventas.VentaUserControl frmVenta = this.Owner as Ventas.VentaUserControl;
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

            if (Owner is View.OrdenCompra.BonificacionDetallesUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);
                        View.OrdenCompra.BonificacionDetallesUserControl frmVenta = Owner as View.OrdenCompra.BonificacionDetallesUserControl;
                        frmVenta.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }

            if (Owner is View.OrdenCompra.AjusteInventarioDetallesUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);
                        View.OrdenCompra.AjusteInventarioDetallesUserControl frmVenta = Owner as View.OrdenCompra.AjusteInventarioDetallesUserControl;
                        frmVenta.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }

            if (Owner is View.Ventas.CotizacionUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);
                        View.Ventas.CotizacionUserControl frmCotizacion = Owner as View.Ventas.CotizacionUserControl;
                        frmCotizacion.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }

            if (Owner is View.OrdenCompra.ManejoDescuentosDetalleUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);
                        View.OrdenCompra.ManejoDescuentosDetalleUserControl frmOwner = Owner as View.OrdenCompra.ManejoDescuentosDetalleUserControl;
                        frmOwner.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }

            if (Owner is OrdenCompra.DevolucionReposicionDetallesUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);
                        OrdenCompra.DevolucionReposicionDetallesUserControl frmOwner = Owner as OrdenCompra.DevolucionReposicionDetallesUserControl;
                        frmOwner.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }
        }

        #endregion

        private void transfer()
        {
            SIFModelo.Articulo art = null;
            if (this.dataGridViewX1.CurrentRow != null)
            {
                art = (SIFModelo.Articulo)((Equin.ApplicationFramework.ObjectView<SIFModelo.Articulo>)this.dataGridViewX1.CurrentRow.DataBoundItem).Object;
            }

            View.Articulos.TransferMayoristasForm frmTransfer = new Articulos.TransferMayoristasForm(art);
            frmTransfer.ShowDialog();
        }

        private void editar()
        {
            //this.dataGridViewX1.SelectedCells.Count;
            if (this.dataGridViewX1.SelectedCells.Count == 0)
            {
               MessageBox.Show("Debe seleccionar el artículo a editar");
                return;
            }

            SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);

            ArticuloEditarForm frmArticulo = new ArticuloEditarForm(articulo);
            frmArticulo.ShowDialog(this);
           // this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
        }

        private void precios()
        {
            if (this.dataGridViewX1.SelectedCells.Count == 0)
            {
               MessageBox.Show("Debe seleccionar el artículo a modificar");
                return;
            }

            SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);

            ArticuloPreciosForm frmArticulo = new ArticuloPreciosForm(articulo);
            frmArticulo.ShowDialog();
        }

        private void existencias()
        {
            if (this.dataGridViewX1.SelectedCells.Count == 0)
            {
               MessageBox.Show("Debe seleccionar el artículo a modificar");
                return;
            }

            SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);

            ArticuloExistenciasForm frmArticulo = new ArticuloExistenciasForm(articulo);
            frmArticulo.ShowDialog();
        }

        private void mayoristas()
        {
            if (this.dataGridViewX1.SelectedCells.Count == 0)
            {
               MessageBox.Show("Debe seleccionar el artículo a modificar");
                return;
            }

            SIFModelo.Articulo articulo = (((ObjectView<SIFModelo.Articulo>)bindingSource.Current).Object);

            ArticuloMayoristasForm frmArticulo = new ArticuloMayoristasForm(articulo);
            frmArticulo.ShowDialog();
        }
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

            SIFModelo.Articulo Articulo = ((ObjectView<SIFModelo.Articulo>)grid.CurrentRow.DataBoundItem).Object as SIFModelo.Articulo;

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

            this.Buscar();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string parametroBusqueda = e.Argument.ToString();

            if (string.IsNullOrEmpty(this.propiedadBusqueda))
            {
                //if (this.buscarTextBoxX.Text.Length > 3)
                //{
                if (Owner is Menu.ConfiguracionMenu)
                {

                    logica.Buscar(propiedadBusqueda, this.buscarTextBoxX.Text);
                }
                else
                {
                    logica.BuscarConInventarioActivo("%" + parametroBusqueda + "%", Helpers.Sesion.Sucursal, propiedadBusqueda);
                }
                //}
            }
            else
            {
                if (Owner is Menu.ConfiguracionMenu)
                {
                    logica.Buscar(propiedadBusqueda, this.buscarTextBoxX.Text);
                }
                else
                {
                    logica.BuscarConInventarioActivo("%" + parametroBusqueda + "%", Helpers.Sesion.Sucursal, propiedadBusqueda);
                }
            }

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.bindingSource.DataSource = logica.ListaArticulos;
            this.dataGridViewX1.DataSource = bindingSource;
            this.dataGridViewX1.Cursor = Cursors.Default;
            this.Cursor = Cursors.Default;
            this.statusLabel.Text = "";
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

        private void dataGridViewX1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridViewX1.Rows[e.RowIndex] == null)
            {
                return;
            }
            var row = this.dataGridViewX1.Rows[e.RowIndex];
            try
            {
                if (row.DataBoundItem == null)
                {
                    return;
                }
            }
            catch
            {
                return;
            }

            SIFModelo.Articulo Articulo = ((ObjectView<SIFModelo.Articulo>)this.dataGridViewX1.Rows[e.RowIndex].DataBoundItem).Object;
            //VALIDAR EL TIPO DE MEDICAMENTO
            if (string.IsNullOrEmpty(Articulo.TIPO_MEDICAMENTO_CVE) || string.IsNullOrWhiteSpace(Articulo.TIPO_MEDICAMENTO_CVE))
            {
               MessageBox.Show("Debe seleccionar el tipo de medicamento para el artículo");

                Catalogos.ListaTipoMedicamentoForm tipoMedicamentoForm = new ListaTipoMedicamentoForm(Articulo);
                if (tipoMedicamentoForm.ShowDialog() == DialogResult.OK)
                {
                    Articulo.TIPO_MEDICAMENTO_CVE = tipoMedicamentoForm.ListaTipoMedicamento;
                    dataGridViewX1.EndEdit();
                    this.Modificar(Articulo);
                }

                return;
            }
        }

        private void editarButtonItem_Click(object sender, EventArgs e)
        {
           // this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.editar();
        }

        private void preciosButtonItem_Click(object sender, EventArgs e)
        {
            this.precios();
        }
        
         private void ImportarPreciosVentaButtonItem_Click(object sender, EventArgs e)
        {
         //   this.precios();
        }

        private void existenciasButtonItem_Click(object sender, EventArgs e)
        {
            existencias();
        }

        private void mayoristasButtonItem_Click(object sender, EventArgs e)
        {
            mayoristas();
        }

        private void transferButtonItem_Click(object sender, EventArgs e)
        {
            transfer();
        }

        private void catArticulosBajaButtonItem_Click(object sender, EventArgs e)
        {
            CatArticulosBaja baja = new CatArticulosBaja();
            baja.ShowDialog();
        }

        private void dbtn_AsignarCompradorButtonItem_Click(object sender, EventArgs e)
        {
            AsignarArtComp c = new  AsignarArtComp();
            c.ShowDialog();
        }

        private void catProductosButtonItem_Click(object sender, EventArgs e)
        {
            String Parm1 = "{Comando.ACTIVO} = 'S'";

            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_CatalogoArticulos.rpt", Parm1);
            Impresion.ShowDialog();
        }

        private void catProductosBajaButtonItem_Click(object sender, EventArgs e)
        {
            String Parm1 = "{Comando.ACTIVO} = 'N'";

            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_CatalogoArticulos.rpt", Parm1);
            Impresion.ShowDialog();
        }
        private void Actualiza_sif3(object sender, EventArgs e)
        {



            string respuesta = new SIFNegocio.Articulo().Actualiza_Sif3(Helpers.Sesion.Usuario.UsuariosID.ToString());
            MessageBox.Show(respuesta, "Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnConsumir_TL(object sender, EventArgs e)
        {
            try
            {
                bnt_Actualizacion.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                string resultado = new SIFNegocio.Articulo().ConsumirApi();
                if (resultado.Contains("SUCCESS"))
                    MessageBox.Show("Se actualizo correctamente..");

                else
                    MessageBox.Show("Respuesta del servidor: " + resultado);

                bnt_Actualizacion.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }

        }



    }
}
