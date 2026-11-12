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
    public partial class ArticuloUserControl : Templates.CatalogoUserControl
    {
        public ArticuloUserControl()
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
                if (Owner is View.OrdenCompra.LoteCaducidadDetallesUserControl)
                {
                    View.OrdenCompra.LoteCaducidadDetallesUserControl propietario = Owner as View.OrdenCompra.LoteCaducidadDetallesUserControl;
                    SIF.View.Menu.ComprasMenu propieatarioOwnerOwner = null;

                    if (propietario.Owner is SIF.View.OrdenCompra.OrdenesCompraUserControl)
                    {
                        SIF.View.OrdenCompra.OrdenesCompraUserControl propietarioOwner = propietario.Owner as SIF.View.OrdenCompra.OrdenesCompraUserControl;

                        propieatarioOwnerOwner = propietarioOwner.Owner as SIF.View.Menu.ComprasMenu;
                    }

                    if (propietario.Owner is View.OrdenCompra.RecepcionOrdenCompraUserControl)
                    {
                        View.OrdenCompra.RecepcionOrdenCompraUserControl propietarioOwner = propietario.Owner as View.OrdenCompra.RecepcionOrdenCompraUserControl;

                        propieatarioOwnerOwner = propietarioOwner.Owner as SIF.View.Menu.ComprasMenu;
                    }



                    if (propieatarioOwnerOwner.Owner.Contains(this))
                    {
                        propieatarioOwnerOwner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Mostrado = false;

                    if (Owner is SIF.View.OrdenCompra.LoteCaducidadDetallesUserControl)
                    {
                        ((View.OrdenCompra.LoteCaducidadDetallesUserControl)(Owner)).ActivaComandos();
                    }

                }

                if (Owner is View.Subrogacion.ArticulosSubrogacionUserControl)
                {
                    View.Subrogacion.ArticulosSubrogacionUserControl propietario = Owner as View.Subrogacion.ArticulosSubrogacionUserControl;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();
                    this.Dock = DockStyle.Fill;
                    if (propietario.Owner.Contains(this))
                    {
                        propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Mostrado = false;
                }

                if (Owner is View.Inventario.CatEquivalenciasUserControl)
                {
                    View.Inventario.CatEquivalenciasUserControl propietario = Owner as View.Inventario.CatEquivalenciasUserControl;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();
                    this.Dock = DockStyle.Fill;
                    if (propietario.Owner.Contains(this))
                    {
                        propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Mostrado = false;
                }

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
                if (Owner is View.Inventario.DestruccionAlmacenUserControl)
                {
                    View.Inventario.DestruccionAlmacenUserControl propietario = Owner as View.Inventario.DestruccionAlmacenUserControl;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();

                    propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = false;
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
                            propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
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
                            this.DesactivaComandos();
                            propietario.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                            propietario.ActivaComandos();
                            this.Mostrado = false;
                        }
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

                if (Owner is Ventas.VentaPedidoUserControl)
                {
                    Ventas.VentaPedidoUserControl propietario = Owner as Ventas.VentaPedidoUserControl;
                    if (this.Mostrado && propietario.Owner.IsModalPanelDisplayed)
                    {
                        this.DesactivaComandos();
                        if (propietario.Owner.Contains(this))
                        {
                            propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
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
                        propietario.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
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
                }
                   
                 

                if (Owner is CallCenter.CotizacionUserControl)
                {
                    CallCenter.CotizacionUserControl propietario = Owner as CallCenter.CotizacionUserControl;
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

                    if (propietario.Owner is MainForm)
                    {
                        MainForm propietarioOwner = propietario.Owner as MainForm;
                        propietarioOwner.ActivaComandos();
                        this.DesactivaComandos();
                        if (propietarioOwner.Contains(this))
                        {
                            propietarioOwner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        }
                        this.Mostrado = false;
                    }

                    this.Mostrado = false;
                }

                //if (Owner is Ventas.CotizacionUserControl)
                //{
                //    CallCenter.CotizacionUserControl propietario = Owner as CallCenter.CotizacionUserControl;
                //    //propietario.ActivaComandos();
                //    //this.DesactivaComandos();
                //    this.Dock = DockStyle.Fill;

                //    if (propietario.Owner is Ventas.VentaUserControl)
                //    {
                //        Ventas.VentaUserControl propietarioOwner = propietario.Owner as Ventas.VentaUserControl;
                //        this.DesactivaComandos();
                //        propietarioOwner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                //        propietario.ActivaComandos();

                //        this.Mostrado = false;
                //    }

                //    if (propietario.Owner is View.Menu.CatMenu)
                //    {
                //        View.Menu.CatMenu propietarioOwner = propietario.Owner as View.Menu.CatMenu;
                //        propietarioOwner.ActivaComandos();
                //        this.DesactivaComandos();
                //        propietarioOwner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                //        this.Mostrado = false;
                //    }

                //    this.Mostrado = false;
                //}

                if (Owner is View.OrdenCompra.ManejoDescuentosDetalleUserControl)
                {
                    View.OrdenCompra.ManejoDescuentosDetalleUserControl propietario = Owner as View.OrdenCompra.ManejoDescuentosDetalleUserControl;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();
                    if (propietario.Owner.Owner.Owner.Contains(this))
                    {
                        propietario.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Mostrado = false;
                }

                if (Owner is View.Inventario.PedidoAlmacenUserControl)
                {
                    View.Inventario.PedidoAlmacenUserControl propietario = Owner as View.Inventario.PedidoAlmacenUserControl;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();
                    if (propietario.Owner.Owner.Owner.Contains(this))
                    {
                        propietario.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Mostrado = false;
                }

                if (Owner is View.Inventario.TraspasoAlmacenUserControl)
                {
                    View.Inventario.TraspasoAlmacenUserControl propietario = Owner as View.Inventario.TraspasoAlmacenUserControl;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();

                    propietario.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = false;
                }

                if (Owner is View.Inventario.RecepcionTrapasoAlmacenUserControl)
                {
                    View.Inventario.RecepcionTrapasoAlmacenUserControl propietario = Owner as View.Inventario.RecepcionTrapasoAlmacenUserControl;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();

                    propietario.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = false;
                }

                if (Owner is View.Inventario.frmRecepcionControl)
                {
                    View.Inventario.frmRecepcionControl propietario = Owner as View.Inventario.frmRecepcionControl;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();

                    propietario.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = false;
                }

                if (Owner is View.Inventario.KardexAlmacenUserControl)
                {
                    View.Inventario.KardexAlmacenUserControl propietario = Owner as View.Inventario.KardexAlmacenUserControl;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();

                    propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = false;
                }

                if (Owner is View.Inventario.AjusteAlmacenUserControl)
                {
                    View.Inventario.AjusteAlmacenUserControl propietario = Owner as View.Inventario.AjusteAlmacenUserControl;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();

                    propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = false;
                }

                if (Owner is View.Inventario.AjusteAlmacenComprasUserControl)
                {
                    View.Inventario.AjusteAlmacenComprasUserControl propietario = Owner as View.Inventario.AjusteAlmacenComprasUserControl;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();

                    propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = false;
                }

                if (Owner is OrdenCompra.RecepcionOrdenCompraDetallesUserControl)
                {
                    OrdenCompra.RecepcionOrdenCompraDetallesUserControl propietario = Owner as OrdenCompra.RecepcionOrdenCompraDetallesUserControl;
                    propietario.DesactivaComandos();
                    this.ActivaComandos();
                    this.Dock = DockStyle.Fill;

                    if (propietario.Owner is SIF.View.OrdenCompra.OrdenesCompraUserControl)
                    {
                        SIF.View.OrdenCompra.OrdenesCompraUserControl propietarioOwne = propietario.Owner as SIF.View.OrdenCompra.OrdenesCompraUserControl;
                        if (propietarioOwne.Owner is Menu.ComprasMenu)
                        {
                            Menu.ComprasMenu propietarioOwnerOwner = propietarioOwne.Owner as Menu.ComprasMenu;
                            if (propietarioOwnerOwner.Owner.Contains(this))
                            {
                                propietarioOwnerOwner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                            }
                        }
                    } this.Mostrado = false;
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
            if (Owner is View.OrdenCompra.LoteCaducidadDetallesUserControl)
            {
                View.OrdenCompra.LoteCaducidadDetallesUserControl propietario = Owner as View.OrdenCompra.LoteCaducidadDetallesUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                SIF.View.Menu.ComprasMenu propieatarioOwnerOwner = null;

                if (propietario.Owner is OrdenCompra.RecepcionOrdenCompraUserControl)
                {
                    OrdenCompra.RecepcionOrdenCompraUserControl propietarioOwner = propietario.Owner as OrdenCompra.RecepcionOrdenCompraUserControl;

                    propieatarioOwnerOwner = propietarioOwner.Owner as SIF.View.Menu.ComprasMenu;
                }

                if (propietario.Owner is OrdenCompra.OrdenesCompraUserControl)
                {
                    OrdenCompra.OrdenesCompraUserControl propietarioOwner = propietario.Owner as OrdenCompra.OrdenesCompraUserControl;

                    propieatarioOwnerOwner = propietarioOwner.Owner as SIF.View.Menu.ComprasMenu;
                }

                propieatarioOwnerOwner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (Owner is View.Subrogacion.ArticulosSubrogacionUserControl)
            {
                View.Subrogacion.ArticulosSubrogacionUserControl propietario = Owner as View.Subrogacion.ArticulosSubrogacionUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (Owner is View.Inventario.CatEquivalenciasUserControl)
            {
                View.Inventario.CatEquivalenciasUserControl propietario = Owner as View.Inventario.CatEquivalenciasUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
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
            if (Owner is Ventas.VentaPedidoUserControl)
            {
                Ventas.VentaPedidoUserControl propietario = Owner as Ventas.VentaPedidoUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
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

                if (propietario.Owner is MainForm)
                {
                    MainForm propietarioOwner = propietario.Owner as MainForm;
                    propietarioOwner.DesactivaComandos();
                    propietarioOwner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }

                this.Mostrado = true;
            }

            if (Owner is CallCenter.CotizacionUserControl)
            {
                CallCenter.CotizacionUserControl propietario = Owner as CallCenter.CotizacionUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                if (propietario.Owner is Ventas.VentaUserControl)
                {
                    Ventas.VentaUserControl propietarioOwner = propietario.Owner as Ventas.VentaUserControl;
                    propietarioOwner.DesactivaComandos();
                    propietarioOwner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }

                if (propietario.Owner is MainForm)
                {
                    MainForm propietarioOwner = propietario.Owner as MainForm;
                    propietarioOwner.DesactivaComandos();
                    propietarioOwner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
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

            if (Owner is View.Inventario.PedidoAlmacenUserControl)
            {
                View.Inventario.PedidoAlmacenUserControl propietario = Owner as View.Inventario.PedidoAlmacenUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }
            if (Owner is View.Inventario.TraspasoAlmacenUserControl)
            {
                View.Inventario.TraspasoAlmacenUserControl propietario = Owner as View.Inventario.TraspasoAlmacenUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }
            if (Owner is View.Inventario.RecepcionTrapasoAlmacenUserControl)
            {
                View.Inventario.RecepcionTrapasoAlmacenUserControl propietario = Owner as View.Inventario.RecepcionTrapasoAlmacenUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (Owner is View.Inventario.frmRecepcionControl)
            {
                View.Inventario.frmRecepcionControl propietario = Owner as View.Inventario.frmRecepcionControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            if (Owner is OrdenCompra.RecepcionOrdenCompraDetallesUserControl)
            {
                OrdenCompra.RecepcionOrdenCompraDetallesUserControl propietario = Owner as OrdenCompra.RecepcionOrdenCompraDetallesUserControl;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                if (propietario.Owner is SIF.View.OrdenCompra.OrdenesCompraUserControl)
                {
                    SIF.View.OrdenCompra.OrdenesCompraUserControl propietarioOwne = propietario.Owner as SIF.View.OrdenCompra.OrdenesCompraUserControl;
                    if (propietarioOwne.Owner is Menu.ComprasMenu)
                    {
                        Menu.ComprasMenu propietarioOwnerOwner = propietarioOwne.Owner as Menu.ComprasMenu;
                        propietarioOwnerOwner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                }
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
                logica.ListaArticulos.ApplyFilter(delegate(SIFModelo.Articulo customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
            }
            catch
            {
            }
        }

        private void seleccionaArticulo()
        {

            if (Owner is View.OrdenCompra.LoteCaducidadDetallesUserControl)
            {
                if (this.dataGridViewX1.CurrentRow != null)
                {
                    View.OrdenCompra.LoteCaducidadDetallesUserControl propietario = Owner as View.OrdenCompra.LoteCaducidadDetallesUserControl;
                    SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;
                    SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);

                    if (Funcion == "Actualiza")
                    {
                        propietario.actualizaArticulo(articulo);
                    }
                    else
                    {
                        propietario.AgregaArticulo(articulo);
                    }
                    this.Back();
                }

            }

            if (Owner is View.Inventario.CatEquivalenciasUserControl)
            {
                if (this.dataGridViewX1.CurrentRow != null)
                {

                    View.Inventario.CatEquivalenciasUserControl frmVenta = this.Owner as View.Inventario.CatEquivalenciasUserControl;
                    SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;
                    SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                    frmVenta.AgregaArticulo(articulo);
                    this.Back();
                }

            }

            if (Owner is View.Subrogacion.ArticulosSubrogacionUserControl)
            {
                if (this.dataGridViewX1.CurrentRow != null)
                {

                    View.Subrogacion.ArticulosSubrogacionUserControl frmVenta = this.Owner as View.Subrogacion.ArticulosSubrogacionUserControl;
                    SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;
                    SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                    frmVenta.AgregaArticulo(articulo);
                    this.Back();
                }

            }
            if (Owner is OrdenCompra.FacturaDetallesUserControl)
            {
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;

                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
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
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;

                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
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
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;


                        Ventas.VentaUserControl frmVenta = this.Owner as Ventas.VentaUserControl;
                        SIFModelo.Articulo articulo;
                        if (frmVenta.ClienteSub == null)
                            articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                        else
                            if (frmVenta.ClienteSub.PRECIO_FIJO == SIFModelo.Tipos.SiNo.SI)
                                articulo = new SIFNegocio.Articulo().BuscarPorClaveSub(rowArticulo.ARTICULO_ID, frmVenta.ClienteSub.ID.ToString());
                            else
                                articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                        frmVenta.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }

            if (Owner is Ventas.VentaPedidoUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;

                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                        Ventas.VentaPedidoUserControl frmVenta = this.Owner as Ventas.VentaPedidoUserControl;
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
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;

                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
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
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;

                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
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
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;

                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
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
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;

                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                        View.Ventas.CotizacionUserControl frmCotizacion = Owner as View.Ventas.CotizacionUserControl;
                        frmCotizacion.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }

            if (Owner is View.CallCenter.CotizacionUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;

                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                        View.CallCenter.CotizacionUserControl frmCotizacion = Owner as View.CallCenter.CotizacionUserControl;
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
                        foreach (DataGridViewRow row in this.dataGridViewX1.SelectedRows)
                        {
                            SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(row.DataBoundItem)).Row;

                            SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                            View.OrdenCompra.ManejoDescuentosDetalleUserControl frmOwner = Owner as View.OrdenCompra.ManejoDescuentosDetalleUserControl;
                            frmOwner.AgregaArticulo(articulo);
                        }
                        this.Back();
                    }
                }
            }

            if (Owner is View.Inventario.PedidoAlmacenUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;

                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                        View.Inventario.PedidoAlmacenUserControl frmOwner = Owner as View.Inventario.PedidoAlmacenUserControl;
                        frmOwner.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }
            if (Owner is View.Inventario.TraspasoAlmacenUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;

                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                        View.Inventario.TraspasoAlmacenUserControl frmOwner = Owner as View.Inventario.TraspasoAlmacenUserControl;
                        frmOwner.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }

            if (Owner is View.Inventario.RecepcionTrapasoAlmacenUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;

                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                        View.Inventario.RecepcionTrapasoAlmacenUserControl frmOwner = Owner as View.Inventario.RecepcionTrapasoAlmacenUserControl;
                        frmOwner.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }

            if (Owner is View.Inventario.frmRecepcionControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;

                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                        View.Inventario.frmRecepcionControl frmOwner = Owner as View.Inventario.frmRecepcionControl;
                        frmOwner.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }

            if (Owner is View.Inventario.AjusteAlmacenUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;

                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                        View.Inventario.AjusteAlmacenUserControl frmOwner = Owner as View.Inventario.AjusteAlmacenUserControl;
                        frmOwner.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }

            if (Owner is View.Inventario.AjusteAlmacenComprasUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;

                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                        View.Inventario.AjusteAlmacenComprasUserControl frmOwner = Owner as View.Inventario.AjusteAlmacenComprasUserControl;
                        frmOwner.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }

            if (Owner is View.Inventario.KardexAlmacenUserControl)
            {
                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;

                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                        View.Inventario.KardexAlmacenUserControl frmOwner = Owner as View.Inventario.KardexAlmacenUserControl;
                        frmOwner.AgregaArticulo(articulo);
                        this.Back();
                    }
                }
            }


            if (Owner is OrdenCompra.RecepcionOrdenCompraDetallesUserControl)
            {
                OrdenCompra.RecepcionOrdenCompraDetallesUserControl propietario = Owner as OrdenCompra.RecepcionOrdenCompraDetallesUserControl;
                //propietario.DesactivaComandos();

                if (this.dataGridViewX1.SelectedRows.Count > 0)
                {
                    if (this.dataGridViewX1.CurrentRow != null)
                    {
                        SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow rowArticulo = (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow)((DataRowView)(this.dataGridViewX1.CurrentRow.DataBoundItem)).Row;

                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(rowArticulo.ARTICULO_ID);
                        OrdenCompra.RecepcionOrdenCompraDetallesUserControl frmOwner = Owner as OrdenCompra.RecepcionOrdenCompraDetallesUserControl;
                        frmOwner.actualizaArticulo(articulo);
                        this.Back();
                    }
                }

                //this.ActivaComandos();
                //this.Dock = DockStyle.Fill;

                //if (propietario.Owner is SIF.View.OrdenCompra.OrdenesCompraUserControl)
                //{
                //    SIF.View.OrdenCompra.OrdenesCompraUserControl propietarioOwne = propietario.Owner as SIF.View.OrdenCompra.OrdenesCompraUserControl;
                //    if (propietarioOwne.Owner is Menu.ComprasMenu)
                //    {
                //        Menu.ComprasMenu propietarioOwnerOwner = propietarioOwne.Owner as Menu.ComprasMenu;
                //        propietarioOwnerOwner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                //    }
                //}
                //this.Mostrado = true;
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
