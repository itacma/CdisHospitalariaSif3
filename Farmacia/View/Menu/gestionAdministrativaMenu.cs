using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Menu
{
    public partial class gestionAdministrativaMenu : Templates.MenuUserControl
    {
        public bool Mostrado = false;
        public MainForm Owner;
        public gestionAdministrativaMenu()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);

            //this.recepcionComprasMetroTileItem.Focus();
            this.ActiveControl = metroTilePanel1;
        }


        private void salirButton_Click(object sender, EventArgs e)
        {
            this.Salir();
        }
        private void Salir()
        {
            this.Owner.Salir();
        }

        private void Back()
        {
            try
            {
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


        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();

            /*this.ventaMostradorMetroTileItem.Shortcuts.Clear();

            this.ventaCotizacionesMetroTileItem.Shortcuts.Clear();

            this.ventaPedidosMetroTileItem.Shortcuts.Clear();

            this.ventaApartadoEspecialMetroTileItem.Shortcuts.Clear();

            this.ventaDevolucionesMetroTileItem.Shortcuts.Clear();

            this.ventaCancelacionMetroTileItem.Shortcuts.Clear();

            this.ventasFacturaMetroTileItem.Shortcuts.Clear();

            this.ventaCajaMetroTileItem.Shortcuts.Clear();

            this.ventaControladosMetroTileItem.Shortcuts.Clear();*/

            this.Mostrado = false;
        }




        private void ReportesMetroTileItem_Click(object sender, EventArgs e)
        {
            this.NavegaVenta();
        }

        private void NavegaVenta()
        {
            //this.DesactivaComandos();
            //View.Ventas.VentaUserControl frmUsuario = new View.Ventas.VentaUserControl();
            //frmUsuario.Owner = this;
            //frmUsuario.Muestra();
        }

        private void comercializacionMetroTileItem_Click(object sender, EventArgs e)
        {
            SIF.View.Comercializacion.Comercializacion  comer = new SIF.View.Comercializacion.Comercializacion();
            //comer.Dock = DockStyle.Fill;
            comer.Owner = this;
            comer.Muestra();
        }

        private void GeneralesMetroTileItem_Click(object sender, EventArgs e)
        {
            gestionAdministrativaGeneral menu = new gestionAdministrativaGeneral();
            menu.Dock = DockStyle.Fill;
            menu.Owner = this;
            menu.Muestra();

        }

        private void finanzasMetroTileItem_Click(object sender, EventArgs e)
        {
           
        }
        private void recursosHumanosMetroTileItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
