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
    public partial class CatalogosSegUserControl : Templates.MenuUserControl
    {
        public CatalogosSegUserControl()
        {
            InitializeComponent();
            Privilegios();
        }
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            vf.verificaOpc(this.itemContainer3, Helpers.Sesion.Usuario.UsuariosID.ToString(), 9);
            
        }
        public ConfiguracionMenu Owner;
        public bool Mostrado = false;

        #region Navegacion

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
        }

        /// <summary>
        /// Activa los acesos cortos mediante el teclado
        /// </summary>
        private void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
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
            DialogResult res = MessageBox.Show("¿Desea salir del catálogo?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Back();
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


        #endregion

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

       
        private void metroTileItem2_Click(object sender, EventArgs e)
        {

            Catalogos.UsuarioUserControl menu = new Catalogos.UsuarioUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = this.Owner;
            menu.Muestra();
        }

        private void perfilesMetroTileItem_Click(object sender, EventArgs e)
        {
            View.Seguridad.TiposUsuarioUserControl menu = new Seguridad.TiposUsuarioUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner.Owner;
            menu.Muestra(); 
        }

        private void metroTileItem46_Click(object sender, EventArgs e)
        {
            View.Seguridad.PerfilesUserControl menu = new Seguridad.PerfilesUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner.Owner;
            menu.Muestra();
        }

        private void compradoresMetroTileItem_Click(object sender, EventArgs e)
        {
            View.Seguridad.CompradorLaboratorioUserControl menu = new View.Seguridad.CompradorLaboratorioUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner;
            menu.Muestra(); 
        }

        private void impuestosMetroTileItem_Click(object sender, EventArgs e)
        {
            View.Seguridad.BitacoraUserControl menu = new Seguridad.BitacoraUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner.Owner;
            menu.Muestra();
        }

 
    }
}
