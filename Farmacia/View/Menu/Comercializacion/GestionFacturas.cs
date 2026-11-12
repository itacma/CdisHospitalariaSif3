using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Menu.Comercializacion
{
    public partial class GestionFacturas  : Templates.ListaUserControl //Templates.MenuUserControl  Templates.CatalogoUserControl
    {
        public gestionAdministrativaMenu Owner;
        public bool Mostrado = false;
        public GestionFacturas()
        {
            InitializeComponent();
        }






        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void Back()
        {
            try
            {
                if (this.Mostrado && Owner.Owner.IsModalPanelDisplayed)
                {
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
        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }
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
