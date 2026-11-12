using DevComponents.DotNetBar.Controls;
using System;
using System.Windows.Forms;

namespace SIF.View.Menu
{
    public partial class AdminComercializacion : Templates.MenuUserControl
    {
        public gestionAdministrativaMenu Owner;
        public bool Mostrado = false;

        public AdminComercializacion()
        {
            InitializeComponent();
        }

        private void SaldosTileItem_Click(object sender, EventArgs e)
        {

        }

        private void FacturasMetroTileItem_Click(object sender, EventArgs e)
        {
            View.Menu.Comercializacion.GestionFacturas fac = new View.Menu.Comercializacion.GestionFacturas();
            fac.Muestra();
        }

        public void Muestra()
        {
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.Dock = DockStyle.Fill;
            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.Mostrado = true;
        }
                
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void salirButton_Click(object sender, EventArgs e)
        {
            this.Salir();
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
            //   this.Owner.Salir();
        }

        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
            this.Mostrado = false;
        }
    }
}
