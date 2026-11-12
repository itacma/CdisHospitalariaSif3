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
    public partial class ClienteControl : Templates.CatalogoUserControl
    {
        public ClienteControl()
        {
            InitializeComponent();
            this.InicializaColumnas();
        }

        public ClienteControl(string p)
            : this()
        {
            // TODO: Complete member initialization
            this.ListaProveedores = p;
            this.titleLabel.Text = "COMPRADORES/LISTA PROVEEDORRES";
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
                if (this.Owner is Subrogacion.FacturasUserControl)
                {
                    Subrogacion.FacturasUserControl propietario = (Subrogacion.FacturasUserControl)this.Owner;

                    MainForm frmMain = propietario.Owner as MainForm;
                    propietario.DesactivaComandos();
                    this.ActivaComandos();
                    this.Dock = DockStyle.Fill;

                    if (frmMain.Contains(this))
                    {
                        try
                        {
                            frmMain.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        catch
                        { }
                    }
                    this.Mostrado = false;

                }




                if (this.Owner is Ventas.CotizacionUserControl)
                {
                    Ventas.CotizacionUserControl propietario = (Ventas.CotizacionUserControl)this.Owner;

                    if (propietario.Owner is View.Menu.CatMenu)
                    {
                        MainForm frmMain = ((View.Menu.CatMenu)(propietario.Owner)).Owner as MainForm;
                        propietario.DesactivaComandos();
                        this.ActivaComandos();
                        this.Dock = DockStyle.Fill;

                        if (frmMain.Contains(this))
                        {
                            frmMain.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        this.Mostrado = false;
                    }
                }

                if (this.Owner is Ventas.CotizacionInmediataUserControl)
                {
                    Ventas.CotizacionInmediataUserControl propietario = (Ventas.CotizacionInmediataUserControl)this.Owner;

                    if (((SIF.View.Ventas.VentaUserControl)propietario.Owner).Owner.Owner is MainForm)
                    {
                        MainForm frmMain = ((SIF.View.Ventas.VentaUserControl)(propietario.Owner)).Owner.Owner as MainForm;
                        propietario.DesactivaComandos();
                        this.ActivaComandos();
                        this.Dock = DockStyle.Fill;

                        if (frmMain.Contains(this))
                        {
                            frmMain.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        this.Mostrado = false;
                    }
                }

                if (this.Owner is CallCenter.CotizacionUserControl)
                {
                    CallCenter.CotizacionUserControl propietario = (CallCenter.CotizacionUserControl)this.Owner;

                    if (propietario.Owner is MainForm)
                    {
                        MainForm frmMain = propietario.Owner as MainForm;
                        propietario.ActivaComandos();
                        this.DesactivaComandos();
                        this.Dock = DockStyle.Fill;

                        if (frmMain.Contains(this))
                        {
                            try
                            {
                                frmMain.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                            }
                            catch
                            {

                            }
                        }
                        this.Mostrado = false;
                    }
                }

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
                if (this.Owner is View.Subrogacion.ArticulosSubrogacionUserControl)
                {
                    View.Subrogacion.ArticulosSubrogacionUserControl propietario = this.Owner as View.Subrogacion.ArticulosSubrogacionUserControl;
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

                if (this.Owner is View.Subrogacion.CatalogoSubrogacionUserControl)
                {
                    View.Subrogacion.CatalogoSubrogacionUserControl propietario = this.Owner as View.Subrogacion.CatalogoSubrogacionUserControl;
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
                        try
                        {
                            frmMain.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        catch
                        {

                        }
                    }
                    this.Mostrado = true;
                }

                if (this.Owner is Ventas.VentasPagoUserControl)
                {
                    Ventas.VentasPagoUserControl propietario = (Ventas.VentasPagoUserControl)this.Owner;

                    MainForm frmMain = propietario.Owner.Owner.Owner as MainForm;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();
                    this.Dock = DockStyle.Fill;
                    if (frmMain.Contains(this))
                    {
                        frmMain.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Mostrado = true;
                }

                if (this.Owner is Ventas.VentaPedidoUserControl)
                {
                    Ventas.VentaPedidoUserControl propietario = (Ventas.VentaPedidoUserControl)this.Owner;

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

                if (this.Owner is View.OrdenCompra.FacturaDetallesUserControl)
                {
                    View.OrdenCompra.FacturaDetallesUserControl propietario = (View.OrdenCompra.FacturaDetallesUserControl)this.Owner;

                    propietario.ActivaComandos();
                    this.DesactivaComandos();

                    if (propietario.Owner.Owner.Owner.Contains(this))
                    {
                        propietario.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Mostrado = false;
                }

                if (this.Owner is View.CallCenter.QuejaSugerenciaUserControl)
                {
                    View.CallCenter.QuejaSugerenciaUserControl propietario = (View.CallCenter.QuejaSugerenciaUserControl)this.Owner;

                    propietario.ActivaComandos();
                    this.DesactivaComandos();

                    if (propietario.Owner.Owner.Owner.Contains(this))
                    {
                        propietario.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Mostrado = false;
                }

                if (this.Owner is View.CallCenter.ConsultasDermaForm)
                {
                    View.CallCenter.ConsultasDermaForm propietario = (View.CallCenter.ConsultasDermaForm)this.Owner;

                    propietario.ActivaComandos();
                    this.DesactivaComandos();

                    propietario.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = false;
                }

                if (this.Owner is View.OrdenCompra.OrdenCompraUserControl)
                {
                    View.OrdenCompra.OrdenCompraUserControl propietario = (View.OrdenCompra.OrdenCompraUserControl)this.Owner;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();
                    //this.Dock = DockStyle.Fill;

                    if (propietario.Owner is Menu.ComprasMenu)
                    {
                        Menu.ComprasMenu propietarioOwner = propietario.Owner as Menu.ComprasMenu;
                        if (propietarioOwner.Owner.Contains(this))
                            propietarioOwner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    else if (propietario.Owner is OrdenCompra.OrdenesCompraUserControl)
                    {
                        OrdenCompra.OrdenesCompraUserControl propietarioOwner = propietario.Owner as OrdenCompra.OrdenesCompraUserControl;
                        Menu.ComprasMenu propietarioOwnerOwner = propietario.Owner as Menu.ComprasMenu;
                        if (propietarioOwnerOwner.Owner.Contains(this))
                            propietarioOwnerOwner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }

                    this.Mostrado = false;
                }

                if (this.Owner is View.Seguridad.CompradorLaboratorioUserControl)
                {

                    View.Seguridad.CompradorLaboratorioUserControl propietario = (View.Seguridad.CompradorLaboratorioUserControl)this.Owner;

                    propietario.ActivaComandos();
                    this.DesactivaComandos();
                    propietario.AgregaProveedores(ListaProveedores);
                    if (propietario.Owner.Owner.Contains(this))
                    {
                        propietario.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Mostrado = false;
                }

                if (this.Owner is SIF.View.Catalogos.ClienteControl)
                {
                    SIF.View.Catalogos.ClienteControl propietario = Owner as SIF.View.Catalogos.ClienteControl;
                    if (propietario.Owner is View.Seguridad.CompradorLaboratorioUserControl)
                    {
                        View.Seguridad.CompradorLaboratorioUserControl propietarioOwner = (View.Seguridad.CompradorLaboratorioUserControl)propietario.Owner;

                        propietario.ActivaComandos();
                        this.DesactivaComandos();
                        if (propietarioOwner.Owner.Owner.Contains(this))
                        {
                            propietarioOwner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        this.Mostrado = false;
                    }
                }

                if (this.Owner is SIF.View.Ventas.CancelacionTicketUserControl)
                {
                    SIF.View.Ventas.CancelacionTicketUserControl propietario = Owner as SIF.View.Ventas.CancelacionTicketUserControl;
                    propietario.DesactivaComandos();
                    this.DesactivaComandos();
                    try
                    {
                        propietario.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    catch
                    {

                    }
                    this.Mostrado = true;
                }


                if (this.Owner is Menu.CatalogosUserControl)
                {
                    Menu.CatalogosUserControl propietario = Owner as Menu.CatalogosUserControl;
                    propietario.DesactivaComandos();
                    this.DesactivaComandos();
                    try
                    {
                        propietario.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    catch
                    {

                    }
                    this.Mostrado = true;
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
            if (this.Owner is View.Subrogacion.FacturasUserControl)
            {
                View.Subrogacion.FacturasUserControl propietario = (View.Subrogacion.FacturasUserControl)this.Owner;
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (this.Owner is Menu.ConfiguracionMenu)
            {
                Menu.ConfiguracionMenu propietario = (Menu.ConfiguracionMenu)this.Owner;
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (this.Owner is Menu.CatalogosSegUserControl)
            {
                Menu.ConfiguracionMenu propietario = (Menu.ConfiguracionMenu)this.Owner;
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (this.Owner is SIF.View.Subrogacion.ArticulosSubrogacionUserControl)
            {
                SIF.View.Subrogacion.ArticulosSubrogacionUserControl propietario = (SIF.View.Subrogacion.ArticulosSubrogacionUserControl)this.Owner;
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (this.Owner is SIF.View.Subrogacion.CatalogoSubrogacionUserControl)
            {
                SIF.View.Subrogacion.CatalogoSubrogacionUserControl propietario = (SIF.View.Subrogacion.CatalogoSubrogacionUserControl)this.Owner;
                propietario.Owner.DesactivaComandos();
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

            if (this.Owner is Ventas.VentasPagoUserControl)
            {
                Ventas.VentasPagoUserControl propietario = (Ventas.VentasPagoUserControl)this.Owner;

                MainForm frmMain = propietario.Owner.Owner.Owner as MainForm;
                propietario.DesactivaCommandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                frmMain.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;

            }

            if (this.Owner is Ventas.VentaPedidoUserControl)
            {
                Ventas.VentaPedidoUserControl propietario = (Ventas.VentaPedidoUserControl)this.Owner;

                MainForm frmMain = propietario.Owner.Owner as MainForm;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                frmMain.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;

            }

            if (this.Owner is Ventas.CotizacionUserControl)
            {
                Ventas.CotizacionUserControl propietario = (Ventas.CotizacionUserControl)this.Owner;

                if (propietario.Owner is MainForm)
                {
                    MainForm frmMain = propietario.Owner as MainForm;
                    propietario.DesactivaComandos();
                    this.ActivaComandos();
                    this.Dock = DockStyle.Fill;

                    frmMain.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = true;
                }
            }

            if (this.Owner is Ventas.CotizacionInmediataUserControl)
            {
                Ventas.CotizacionInmediataUserControl propietario = (Ventas.CotizacionInmediataUserControl)this.Owner;

                if (((SIF.View.Ventas.VentaUserControl)propietario.Owner).Owner.Owner is MainForm)
                {
                    MainForm frmMain = ((SIF.View.Ventas.VentaUserControl)propietario.Owner).Owner.Owner as MainForm ;
                    propietario.DesactivaComandos();
                    this.ActivaComandos();
                    this.Dock = DockStyle.Fill;

                    frmMain.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = true;
                }
            }

            if (this.Owner is CallCenter.CotizacionUserControl)
            {
                CallCenter.CotizacionUserControl propietario = (CallCenter.CotizacionUserControl)this.Owner;

                if (propietario.Owner is MainForm)
                {
                    MainForm frmMain = propietario.Owner as MainForm;
                    propietario.DesactivaComandos();
                    this.ActivaComandos();
                    this.Dock = DockStyle.Fill;

                    frmMain.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = true;
                }
            }

            if (this.Owner is View.OrdenCompra.FacturaDetallesUserControl)
            {
                View.OrdenCompra.FacturaDetallesUserControl propietario = (View.OrdenCompra.FacturaDetallesUserControl)this.Owner;

                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (this.Owner is View.CallCenter.QuejaSugerenciaUserControl)
            {
                View.CallCenter.QuejaSugerenciaUserControl propietario = (View.CallCenter.QuejaSugerenciaUserControl)this.Owner;

                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;
                propietario.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (this.Owner is View.CallCenter.ConsultasDermaForm)
            {
                View.CallCenter.ConsultasDermaForm propietario = (View.CallCenter.ConsultasDermaForm)this.Owner;

                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;
                propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (this.Owner is View.OrdenCompra.OrdenCompraUserControl)
            {
                View.OrdenCompra.OrdenCompraUserControl propietario = (View.OrdenCompra.OrdenCompraUserControl)this.Owner;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                if (propietario.Owner is Menu.ComprasMenu)
                {
                    Menu.ComprasMenu propietarioOwner = propietario.Owner as Menu.ComprasMenu;
                    propietarioOwner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }
                else if (propietario.Owner is OrdenCompra.OrdenesCompraUserControl)
                {
                    OrdenCompra.OrdenesCompraUserControl propietarioOwner = propietario.Owner as OrdenCompra.OrdenesCompraUserControl;
                    Menu.ComprasMenu propietarioOwnerOwner = propietario.Owner as Menu.ComprasMenu;
                    propietarioOwnerOwner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }

                this.Mostrado = true;
            }

            if (this.Owner is View.Seguridad.CompradorLaboratorioUserControl)
            {
                View.Seguridad.CompradorLaboratorioUserControl propietario = Owner as View.Seguridad.CompradorLaboratorioUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;
                propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;

            }

            if (this.Owner is SIF.View.Catalogos.ClienteControl)
            {
                SIF.View.Catalogos.ClienteControl propietario = Owner as SIF.View.Catalogos.ClienteControl;
                if (propietario.Owner is View.Seguridad.CompradorLaboratorioUserControl)
                {
                    View.Seguridad.CompradorLaboratorioUserControl propietarioOwner = propietario.Owner as View.Seguridad.CompradorLaboratorioUserControl;
                    propietario.DesactivaComandos();
                    this.ActivaComandos();
                    this.Dock = DockStyle.Fill;
                    propietarioOwner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = true;
                }
            }

            if (this.Owner is SIF.View.Ventas.CancelacionTicketUserControl)
            {
                SIF.View.Ventas.CancelacionTicketUserControl propietario = Owner as SIF.View.Ventas.CancelacionTicketUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;
                propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (this.Owner is Menu.CatalogosUserControl)
            {
                Menu.CatalogosUserControl propietario = Owner as Menu.CatalogosUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;
                propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
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

            SUBROGACIONColumn.DataSource = SiNoBindingSource;
            SUBROGACIONColumn.DisplayMember = "Key";
            SUBROGACIONColumn.ValueMember = "Value";

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



            //DataGridViewComboBoxExColumn SUBROGACIONColumn = this.dataGridViewX1.Columns["SUBROGACIONColumn"] as DataGridViewComboBoxExColumn;
            //SUBROGACIONColumn.Items.Add("S");
            //SUBROGACIONColumn.Items.Add("N");
            //SUBROGACIONColumn.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void TIPO_DIRECCIONColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (esNuevo)
            {
                Nuevo();
            }

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

            // dataGridViewX1.Cursor = Cursors.WaitCursor;
            if (!buscarBackgroundWorker.IsBusy)
            {
                this.buscarBackgroundWorker.RunWorkerAsync();
            }
            dataGridViewX1.DataSource = bindingSource;
            dataGridViewX1.Refresh();
        }

        private bool Nuevo()
        {

            if (!string.IsNullOrEmpty(ListaProveedores))
            {
                ClienteControl cliente = new ClienteControl();
                cliente.Owner = this;
                cliente.Muestra();
                return true;
            }


            this.dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);

            this.current = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.AddNew()).Object as SIFModelo.Cliente;
            this.current.Activo = SIFModelo.Tipos.SiNo.SI;
            this.current.ApellidoMaterno = "";
            this.current.ApellidoPaterno = "";
            this.current.Boletinado = SIFModelo.Tipos.SiNo.NO;
            this.current.Convenio = SIFModelo.Tipos.SiNo.NO;
            this.current.Descuento = 0;
            this.current.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            this.current.LaboratorioMayorista = SIFModelo.Tipos.LaboratorioMayorista.NINGUNO;
            this.current.LoteCaducidad = SIFModelo.Tipos.SiNo.NO;
            this.current.Nombre = "";
            this.current.Proveedor = SIFModelo.Tipos.SiNo.NO;
            this.current.TipoCliente = SIFModelo.Tipos.TipoCliente.FISICA;
            this.current.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
            this.current.ReferenciaBeneficio = "0";
           // SIFModelo.Usuario usu = SIF.Helpers.Sesion.UsuarioSeleccionadoVenta;
           // this.current.ReferenciaBeneficio = usu.UsuariosID.ToString();
            
             //Helpers.Sesion.UsuarioSeleccionadoVenta.Nombre;
            this.current.SUBROGACION = SIFModelo.Tipos.SiNo.NO;


            esNuevo = true;
            this.dataGridViewX1.CurrentCell = dataGridViewX1.CurrentRow.Cells["NOMBREColumn"];
            this.dataGridViewX1.BeginEdit(true);

            return true;
        }

        private bool Eliminar()
        {
            if (!string.IsNullOrEmpty(this.ListaProveedores))
            {
                DialogResult res =MessageBox.Show("¿Quitar de la lista de proveedores el proveedor selecionado?", "Quitar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (res == DialogResult.Yes)
                {
                    this.dataGridViewX1.Rows.Remove(dataGridViewX1.CurrentRow);

                    if (!string.IsNullOrEmpty(this.ListaProveedores) && logica.CatClientesList != null)
                    {
                        this.ListaProveedores = "";
                        foreach (SIFModelo.Cliente item in logica.CatClientesList.DataSource)
                        {
                            this.ListaProveedores += item.ID.ToString() + "|";
                        }
                    }

                    return true;
                }
                return false;
            }

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
            if (Cliente.ID == 90 || Cliente.ID == 24)
            {
               MessageBox.Show("El cliente se encuentra bloqueado");
                return false;
            }

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
            //if (string.IsNullOrEmpty(propiedadBusqueda))
            //{
            //    propiedadBusqueda = new SIFModelo.Cliente().GetType().GetProperties()[0].Name;
            //}

            //try
            //{
            //    if (logica.CatClientesList == null || logica.CatClientesList.Count == 0)
            //    {
            if (this.Owner is View.CallCenter.CotizacionUserControl)
            {
                CallCenter.CotizacionUserControl propietario = (CallCenter.CotizacionUserControl)this.Owner;
                if (propietario.Cual == 3)
                    logica.BuscarClientesC("", this.buscarTextBoxX.Text, "CONVENIO", 1);
                else
                    if (propietario.Cual == 4)
                        logica.BuscarClientesC("", this.buscarTextBoxX.Text, "SUBROGACION", 2);
                    else
                        logica.BuscarClientes("", this.buscarTextBoxX.Text);
            }
            else
                //    {
                if (this.Owner is View.Subrogacion.ArticulosSubrogacionUserControl)
                    logica.BuscarClientesS("", this.buscarTextBoxX.Text);
                else if (this.Owner is View.Subrogacion.CatalogoSubrogacionUserControl)
                    logica.BuscarClientesS("", this.buscarTextBoxX.Text);
                else
                    logica.BuscarClientes(propiedadBusqueda, this.buscarTextBoxX.Text);

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
        public bool CONVENIO;

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

            //if (grid.CurrentRow.Cells[e.ColumnIndex].Value != null)
            //    if ((grid.CurrentRow.Cells[e.ColumnIndex].Value.ToString() != "") & (grid.CurrentRow.Cells[e.ColumnIndex].Value.ToString() != "0"))
            //    {
            //        grid.Update();
            //        this.bindingSource.EndEdit();
            //        grid.EndEdit();
            //    }

        }


        private void SeleccionaCliente()
        {
            if (this.bindingSource.Current == null)
            {

                return;
            }
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

            if (this.Owner is View.Subrogacion.ArticulosSubrogacionUserControl)
            {
                View.Subrogacion.ArticulosSubrogacionUserControl propietario = (View.Subrogacion.ArticulosSubrogacionUserControl)this.Owner;
                SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.Current).Object as SIFModelo.Cliente;
                propietario.AgregarCliente(cliente);
                this.Back();
            }

            if (this.Owner is View.Subrogacion.CatalogoSubrogacionUserControl)
            {
                View.Subrogacion.CatalogoSubrogacionUserControl propietario = (View.Subrogacion.CatalogoSubrogacionUserControl)this.Owner;
                SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.Current).Object as SIFModelo.Cliente;
                propietario.AgregarCliente(cliente);
                this.Back();
            }

            if (this.Owner is View.Subrogacion.FacturasUserControl)
            {
                View.Subrogacion.FacturasUserControl propietario = (View.Subrogacion.FacturasUserControl)this.Owner;
                SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.Current).Object as SIFModelo.Cliente;
                propietario.AgregarCliente(cliente);
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

            if (this.Owner is Ventas.VentasPagoUserControl)
            {
                Ventas.VentasPagoUserControl propietario = (Ventas.VentasPagoUserControl)this.Owner;

                if (this.bindingSource.Current == null)
                {
                    return;
                }

                SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.Current).Object as SIFModelo.Cliente;

                propietario.ActivaComandos();
                propietario.AgregaCliente(cliente);
                this.Back();
            }

            if (this.Owner is Ventas.VentaPedidoUserControl)
            {
                Ventas.VentaPedidoUserControl propietario = (Ventas.VentaPedidoUserControl)this.Owner;

                if (this.bindingSource.Current == null)
                {
                    return;
                }

                SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.Current).Object as SIFModelo.Cliente;

                propietario.ActivaComandos();
                propietario.AgregaCliente(cliente);
                this.Back();
            }

            if (this.Owner is Ventas.CotizacionUserControl)
            {
                Ventas.CotizacionUserControl propietario = (Ventas.CotizacionUserControl)this.Owner;

                if (this.bindingSource.Current == null)
                {
                    return;
                }

                SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.Current).Object as SIFModelo.Cliente;

                propietario.ActivaComandos();
                propietario.AgregaCliente(cliente);
                this.Back();
            }

            if (this.Owner is Ventas.CotizacionInmediataUserControl)
            {
                Ventas.CotizacionInmediataUserControl propietario = (Ventas.CotizacionInmediataUserControl)this.Owner;

                if (this.bindingSource.Current == null)
                {
                    return;
                }

                SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.Current).Object as SIFModelo.Cliente;

                propietario.ActivaComandos();
                propietario.AgregaCliente(cliente);
                this.Back();
            }

            if (this.Owner is CallCenter.CotizacionUserControl)
            {
                CallCenter.CotizacionUserControl propietario = (CallCenter.CotizacionUserControl)this.Owner;

                if (this.bindingSource.Current == null)
                {
                    return;
                }

                SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.Current).Object as SIFModelo.Cliente;

                propietario.ActivaComandos();
                propietario.AgregaCliente(cliente);
                this.Back();
            }

            if (this.Owner is OrdenCompra.FacturaDetallesUserControl)
            {
                OrdenCompra.FacturaDetallesUserControl propietario = (OrdenCompra.FacturaDetallesUserControl)this.Owner;

                if (this.bindingSource.Current == null)
                {
                    return;
                }

                SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.Current).Object as SIFModelo.Cliente;

                propietario.ActivaComandos();
                propietario.AgregaCliente(cliente);
                this.Back();
            }

            if (this.Owner is SIF.View.CallCenter.QuejaSugerenciaUserControl)
            {
                SIF.View.CallCenter.QuejaSugerenciaUserControl propietario = (SIF.View.CallCenter.QuejaSugerenciaUserControl)this.Owner;

                if (this.bindingSource.Current == null)
                {
                    return;
                }

                SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.Current).Object as SIFModelo.Cliente;

                propietario.ActivaComandos();
                propietario.AgregaCliente(cliente);
                this.Back();
            }

            if (this.Owner is SIF.View.CallCenter.QuejaSugerenciaUserControl)
            {
                SIF.View.CallCenter.QuejaSugerenciaUserControl propietario = (SIF.View.CallCenter.QuejaSugerenciaUserControl)this.Owner;

                if (this.bindingSource.Current == null)
                {
                    return;
                }

                SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.Current).Object as SIFModelo.Cliente;

                propietario.ActivaComandos();
                propietario.AgregaCliente(cliente);
                this.Back();
            }

            if (this.Owner is SIF.View.CallCenter.ConsultasDermaForm)
            {
                SIF.View.CallCenter.ConsultasDermaForm propietario = (SIF.View.CallCenter.ConsultasDermaForm)this.Owner;

                if (this.bindingSource.Current == null)
                {
                    return;
                }

                SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.Current).Object as SIFModelo.Cliente;

                propietario.ActivaComandos();
                propietario.AgregaCliente(cliente);
                this.Back();
            }

            if (this.Owner is View.OrdenCompra.OrdenCompraUserControl)
            {
                View.OrdenCompra.OrdenCompraUserControl propietario = (View.OrdenCompra.OrdenCompraUserControl)this.Owner;

                if (this.bindingSource.Current == null)
                {
                    return;
                }

                SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.Current).Object as SIFModelo.Cliente;

                propietario.ActivaComandos();
                propietario.AgregaCliente(cliente);
                this.Back();
            }


            if (this.Owner is View.Catalogos.ClienteControl)
            {
                View.Catalogos.ClienteControl propietario = (View.Catalogos.ClienteControl)this.Owner;

                if (this.bindingSource.Current == null)
                {
                    return;
                }

                SIFModelo.Cliente cliente = ((ObjectView<SIFModelo.Cliente>)this.bindingSource.Current).Object as SIFModelo.Cliente;

                propietario.ActivaComandos();
                propietario.AgregaCliente(cliente);
                this.Back();
            }

            if (this.Owner is SIF.View.Ventas.CancelacionTicketUserControl)
            {
                View.Ventas.CancelacionTicketUserControl propietario = (View.Ventas.CancelacionTicketUserControl)this.Owner;

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

        public void AgregaCliente(SIFModelo.Cliente cliente)
        {
            logica.CatClientesList.DataSource.Add(cliente);

            if (!string.IsNullOrEmpty(this.ListaProveedores) && logica.CatClientesList != null)
            {
                this.ListaProveedores = "";
                foreach (SIFModelo.Cliente item in logica.CatClientesList.DataSource)
                {
                    this.ListaProveedores += item.ID.ToString() + "|";
                }
            }

            this.Buscar();
            //dataGridViewX1.DataMember = "";
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

            if (e.KeyData == Keys.Down)
            {
                dataGridViewX1.Focus();
                return;
            }
            Cursor = Cursors.WaitCursor;
            //if (logica.CatClientesList == null || this.buscarTextBoxX.Text.Length == 1 || logica.CatClientesList.Count == 0)
            //{
            this.Buscar();
            //}

            //this.buscarLocal();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            ////buscar los clientes
            NuevoButtonItem.Enabled = false;
            eliminarButtonItem.Enabled = false;
            if (!string.IsNullOrEmpty(this.ListaProveedores))
            {
                logica.BuscarClientesC("", this.buscarTextBoxX.Text, ListaProveedores);
                return;
            }

            if (this.Owner is Menu.CatalogosUserControl)
            {
                logica.BuscarClientesC("", this.buscarTextBoxX.Text, "CONVENIO", 1);
                return;
            }
            if (this.Owner is View.CallCenter.CotizacionUserControl)
            {
                CallCenter.CotizacionUserControl propietario = (CallCenter.CotizacionUserControl)this.Owner;
                if (propietario.Cual == 3)
                    logica.BuscarClientesC("", this.buscarTextBoxX.Text, "CONVENIO", 1);
                else
                    if (propietario.Cual == 4)
                        logica.BuscarClientesC("", this.buscarTextBoxX.Text, "SUBROGACION", 2);
                    else
                        logica.BuscarClientes("", this.buscarTextBoxX.Text);
            }
            else
                if ((this.Owner is View.Subrogacion.ArticulosSubrogacionUserControl))
                    logica.BuscarClientesS("", this.buscarTextBoxX.Text);
                else
                    if (this.Owner is View.Subrogacion.CatalogoSubrogacionUserControl)
                        logica.BuscarClientesSub("", this.buscarTextBoxX.Text);
                else
                    if (this.Owner is View.Subrogacion.FacturasUserControl)
                        logica.BuscarClientesSub("", this.buscarTextBoxX.Text);
                    else
                        logica.BuscarClientes(propiedadBusqueda, this.buscarTextBoxX.Text);

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            NuevoButtonItem.Enabled = true;
            eliminarButtonItem.Enabled = true;
            this.bindingSource.DataSource = logica.CatClientesList;
            this.dataGridViewX1.DataSource = bindingSource;
            dataGridViewX1.Refresh();
            Cursor = Cursors.Default;
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

                    if (iRowNew < 0)
                    {
                        iRowNew = 0;
                    }

                    grid.CurrentCell = grid[iColNew, iRowNew];
                }
            }
            celdaEditada = null;

        }

        private void dataGridViewX1_EndEdit(object sender, GridEditEventArgs e)
        {
            try
            {
                //VALIDAR LA COLUMNA Y EL VALOR
                GridPanel grid = (sender as SuperGridControl).PrimaryGrid;
                SIFModelo.Cliente Cliente = this.bindingSource.Current as SIFModelo.Cliente;

                //SI ES MODIFICADO
                if (Cliente.ID != 0)
                {
                    this.Modificar(Cliente);
                }
            }
            catch
            {

            }

            //celdaEditada = grid[e.ColumnIndex, e.RowIndex]; 
        }

        private void dataGridViewX1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (esNuevo)
            {
                return;
            }

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
            try
            {
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
                    dataGridViewX1_RowLeave(sender, null);
                    DireccionClienteForm frmDireccion = new DireccionClienteForm(cliente);
                    frmDireccion.ShowDialog();

                }
                if ((columna.DataPropertyName == "Convenio") & (celdaEditada.Value.ToString() == SIFModelo.Tipos.SiNo.SI.ToString()))
                {
                    ConvenioClienteForm frmConv = new ConvenioClienteForm(cliente);
                    if (frmConv.ShowDialog() ==  DialogResult.OK)
                    {
                        cliente.Descuento = frmConv.PorecentajeDescuentointegerInput.Value;
                        if (cliente.Descuento == 0)
                        {
                            cliente.Descuento = frmConv.PorcentajeCostointegerInput.Value;
                        }
                        logica.Modificar(cliente);
                    }
                }

                if ((columna.DataPropertyName == "SUBROGACION") & (celdaEditada.Value.ToString() == SIFModelo.Tipos.SiNo.SI.ToString()))
                {
                    SubRogacionClienteForm frmConv = new SubRogacionClienteForm(cliente);
                    if (frmConv.ShowDialog() == DialogResult.OK)
                    {
                        cliente.Descuento = frmConv.PorecentajeDescuentointegerInput.Value;

                        if (cliente.Descuento == 0)
                        {
                            cliente.Descuento = frmConv.PorcentajeCostointegerInput.Value;
                        }
                        logica.Modificar(cliente);
                    }
                }
            }
            catch
            {
            }
        }

        private void dataGridViewX1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewX grid = sender as DataGridViewX;
            DataGridViewRow row = grid.Rows[e.RowIndex];
            row.ReadOnly = false;
            if (row != null)
            {
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

                if (!(row.DataBoundItem is ObjectView<SIFModelo.Cliente>))
                {
                    return;
                }

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
            if (e.KeyCode == Keys.Enter)
            {
                this.SeleccionaCliente();
            }


            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                DataObject d = dataGridViewX1.GetClipboardContent();
                if (d == null) { return; }
                Clipboard.SetDataObject(d);
            }

            if (e.KeyCode == Keys.Escape)
            {
                if (esNuevo)
                {
                    esNuevo = false;
                    this.dataGridViewX1.Rows.Remove(this.dataGridViewX1.CurrentRow);
                }
            }
        }

        private bool esNuevo = false;
        public string ListaProveedores;
        private void dataGridViewX1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (esNuevo)
                {
                    if (this.logica.Nuevo(current).ID == 0)
                    {
                        logica.CatClientesList.CancelNew(logica.CatClientesList.Count - 1);
                        dataGridViewX1.CancelEdit();
                        dataGridViewX1.Refresh();
                    }
                    else
                    {
                        //  this.dataGridViewX1.BeginEdit(true);
                    }

                    esNuevo = false;
                }
            }
            catch
            {
            }
        }

        private void dataGridViewX1_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            if (esNuevo)
            {
                dataGridViewX1.Rows.Remove(dataGridViewX1.CurrentRow);
                esNuevo = false;
            }
        }

        private void dataGridViewX1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewX1.Rows[e.RowIndex].ErrorText = "";
            int newInteger;
            if (dataGridViewX1.Rows[e.RowIndex].IsNewRow) { return; }

        }

        private void dataGridViewX1_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            //MessageBox.Show("ocurrio un error " + anError.Context.ToString());

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }

        }

        private void dataGridViewX1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }


       /*
        internal void AgregaCliente(SIFModelo.Cliente cliente)
        {
            throw new NotImplementedException();
        }

        internal void DesactivaComandos()
        {
            throw new NotImplementedException();
        }*/
    }
}
