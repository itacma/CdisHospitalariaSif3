using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Comercializacion
{
    public partial class Comercializacion : Templates.MenuUserControl
    {
        public SIF.View.Menu.gestionAdministrativaMenu Owner;
        public bool Mostrado = false;


        public Comercializacion()
        {
            InitializeComponent();
        }

        private void SaldosMetroTileItem_Click(object sender, EventArgs e)
        {
            AdminSaldos saldos = new AdminSaldos();
            saldos.Owner = Owner.Owner;
            this.DesactivaComandos();
            saldos.Muestra();
        }

        private void FacturasMetroTileItem_Click(object sender, EventArgs e)
        {
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void Back()
        {
            try
            {
                if (Owner.Owner.Contains(this))
                {
                    Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }
                this.Owner.Owner.ActivaComandos();
                Mostrado = false;
            }
            catch { }
        }

        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
            this.Mostrado = false;
        }

        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.ActiveControl = metroTilePanel1;
        }

        private void salirButton_Click(object sender, EventArgs e)
        {
            this.Salir();
        }
        private void Salir()
        {
            //this.Owner.Salir();
        }
        public void Muestra()
        {
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.Dock = DockStyle.Fill;
            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.Mostrado = true;
        }
    }
}
