using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Menu
{
    public partial class VentasMenu : Templates.MenuUserControl
    {
        public bool Mostrado = false;
        public MainForm Owner;
        public VentasMenu()
        {
            InitializeComponent();
            Privilegios();
        }
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            vf.verificaOpc(this.itemContainer1, Helpers.Sesion.Usuario.UsuariosID.ToString(),1);
            vf.verificaOpc(this.itemContainer2, Helpers.Sesion.Usuario.UsuariosID.ToString(), 1);
            vf.verificaOpc(this.itemContainer3, Helpers.Sesion.Usuario.UsuariosID.ToString(), 1);
            vf.verifica(ventaCajaMetroTileItem, Helpers.Sesion.Usuario.UsuariosID.ToString());
            vf.verifica(ventaControladosMetroTileItem, Helpers.Sesion.Usuario.UsuariosID.ToString());
        }

        #region Metodos


        private void NavegaVenta()
        {
            this.DesactivaComandos();
            View.Ventas.VentaUserControl frmUsuario = new View.Ventas.VentaUserControl();
            frmUsuario.Owner = this;
            frmUsuario.Muestra();
        }

        Ventas.CajaUserControl cajaUser;
        private void NavegaCaja()
        {
            if (cajaUser == null)
            {
                cajaUser = new Ventas.CajaUserControl();
                cajaUser.Owner = this;
                cajaUser.Dock = DockStyle.Fill;
            }

            this.DesactivaComandos();
            cajaUser.Navega();
        }

        Ventas.ControladosUserControl controladosUser;
        private void NavegaControlados()
        {
            if (controladosUser == null)
            {
                controladosUser = new Ventas.ControladosUserControl();
                controladosUser.Owner = this;
                controladosUser.Dock = DockStyle.Fill;
            }
            if (!controladosUser.Mostrado)
            {
                this.DesactivaComandos();
                controladosUser.Navega();
            }
        }

        View.Ventas.CotizacionesUserControl cotizacionesUser;
        private void NavegaCotizaciones()
        {
            if (cotizacionesUser == null)
            {
                cotizacionesUser = new View.Ventas.CotizacionesUserControl();
                cotizacionesUser.Owner = this.Owner;
                cotizacionesUser.Dock = DockStyle.Fill;
            }
            if (!cotizacionesUser.Mostrado)
            {
                this.DesactivaComandos();
                cotizacionesUser.Navega();
            }
        }

        View.Ventas.PedidosUserControl pedidosUser;
        private void NavegaPedidos()
        {
            if (pedidosUser == null)
            {
                pedidosUser = new View.Ventas.PedidosUserControl();
                pedidosUser.Owner = this;
                pedidosUser.Dock = DockStyle.Fill;
            }
            if (!pedidosUser.Mostrado)
            {
                this.DesactivaComandos();
                pedidosUser.Navega();
            }
        }

        View.Ventas.ApartadosUserControl apartadosUser;
        private void NavegaApartados()
        {
            if (apartadosUser == null)
            {
                apartadosUser = new View.Ventas.ApartadosUserControl();
                apartadosUser.Owner = this;
                apartadosUser.Dock = DockStyle.Fill;
            }
            this.DesactivaComandos();
            apartadosUser.Navega();
        }

        View.Ventas.CancelacionTicketUserControl cancelacionUser;
        private void NavegaCancelacion()
        {
            if (cancelacionUser == null)
            {
                cancelacionUser = new View.Ventas.CancelacionTicketUserControl();
                cancelacionUser.Owner = this;
                cancelacionUser.Dock = DockStyle.Fill;
            }

            if (!cancelacionUser.Mostrado)
            {
                this.DesactivaComandos();
                cancelacionUser.Muestra();
            }
        }

        View.Ventas.DevolucionesUserControl devolucionUser;
        private void NavegaDevolucion()
        {
            if (devolucionUser == null)
            {
                devolucionUser = new View.Ventas.DevolucionesUserControl();
                devolucionUser.Owner = this;
                devolucionUser.Dock = DockStyle.Fill;
            }
            this.DesactivaComandos();
            devolucionUser.Muestra();
        }

        View.Ventas.FacturasUserControl facturasUser;
        private void NavegaFacturas()
        {
            if (facturasUser == null)
            {
                facturasUser = new View.Ventas.FacturasUserControl();
                facturasUser.Owner = this;
                facturasUser.Dock = DockStyle.Fill;
            }
            this.DesactivaComandos();
            facturasUser.Muestra();
        }

        #endregion


        #region Navegación de Ventana

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);

            this.ventaMostradorMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftV);
            this.ventaMostradorMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl1);

            this.ventaCotizacionesMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftC);
            this.ventaCotizacionesMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl2);

            this.ventaPedidosMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftP);
            this.ventaPedidosMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl3);

            this.ventaApartadoEspecialMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftR);
            this.ventaApartadoEspecialMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl4);

            this.ventaDevolucionesMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftD);
            this.ventaDevolucionesMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl5);

            this.ventaCancelacionMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftK);
            this.ventaCancelacionMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl6);

            this.ventasFacturaMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftT);
            this.ventasFacturaMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl7);

            this.ventaCajaMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftJ);
            this.ventaCajaMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl8);

            this.ventaControladosMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftO);
            this.ventaControladosMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl9);

            this.ventaMostradorMetroTileItem.Focus();
            this.ActiveControl = metroTilePanel1;

            this.Mostrado = true;
        }

        /// <summary>
        /// Activa los acesos cortos mediante el teclado
        /// </summary>
        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();

            this.ventaMostradorMetroTileItem.Shortcuts.Clear();

            this.ventaCotizacionesMetroTileItem.Shortcuts.Clear();

            this.ventaPedidosMetroTileItem.Shortcuts.Clear();

            this.ventaApartadoEspecialMetroTileItem.Shortcuts.Clear();

            this.ventaDevolucionesMetroTileItem.Shortcuts.Clear();

            this.ventaCancelacionMetroTileItem.Shortcuts.Clear();

            this.ventasFacturaMetroTileItem.Shortcuts.Clear();

            this.ventaCajaMetroTileItem.Shortcuts.Clear();

            this.ventaControladosMetroTileItem.Shortcuts.Clear();

            this.Mostrado = false;
        }

        private void Back()
        {
            try{
            //if (this.Mostrado)
            //{
                if (Owner.IsModalPanelDisplayed)
                {
                    this.DesactivaComandos();
                    if (Owner.Contains(this))
                    {
                        Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Owner.ActivaComandos();
                    this.Mostrado = false;
                }
            //}
            }
            catch { }
        }

        private void Salir()
        {
            this.Owner.Salir();
        }
        #endregion

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void ventaMostradorMetroTileItem_Click(object sender, EventArgs e)
        {
            this.NavegaVenta();
        }

        private void salirButton_Click(object sender, EventArgs e)
        {
            this.Salir();
        }

        private void cajaMetroTileItem_Click(object sender, EventArgs e)
        {
            this.NavegaCaja();
        }

        private void controladosMetroTileItem_Click(object sender, EventArgs e)
        {
            this.NavegaControlados();
        }

        private void ventaCotizacionesMetroTileItem_Click(object sender, EventArgs e)
        {
            this.NavegaCotizaciones();
        }

        private void pedidosMetroTileItem_Click(object sender, EventArgs e)
        {
            this.NavegaPedidos();
        }

        private void ventaApartadoEspecialMetroTileItem_Click(object sender, EventArgs e)
        {
            this.NavegaApartados();
        }

        private void metroTileItem1_Click(object sender, EventArgs e)
        {
           /* Reportes.ReportesAdmin nvf = new Reportes.ReportesAdmin();
            nvf.ShowDialog();*/
        }

        private void ventaCancelacionMetroTileItem_Click(object sender, EventArgs e)
        {
            this.NavegaCancelacion();
        }

        private void ventaDevolucionesMetroTileItem_Click(object sender, EventArgs e)
        {
            this.NavegaDevolucion();
        }

        private void ventasFacturaMetroTileItem_Click(object sender, EventArgs e)
        {
            this.NavegaFacturas();
        }

        private void metroTileItem4_Click(object sender, EventArgs e)
        {

        }

    }
}
