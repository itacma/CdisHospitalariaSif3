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
    public partial class gestionAdministrativaGeneral : Templates.MenuUserControl
    {


        public gestionAdministrativaMenu Owner;
        public bool Mostrado = false;
        public gestionAdministrativaGeneral()
        {
            InitializeComponent();
        }

        private void ReportesAdminMetroTileItem_Click(object sender, EventArgs e)
        {
            View.Reportes.ReportesAdmin nvf = new View.Reportes.ReportesAdmin();
            nvf.ShowDialog();
        }
        private void expedienteProveedoresMetroTileItem_Click(object sender, EventArgs e)
        {
            View.Documentacion.Documentacion frm = new View.Documentacion.Documentacion();
            frm.ShowDialog();
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
         //   this.Owner.Salir();
        }
        public void Muestra()
        {
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.Dock = DockStyle.Fill;
            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.Mostrado = true;
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


        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();

          

            this.Mostrado = false;
        }

    }
}
