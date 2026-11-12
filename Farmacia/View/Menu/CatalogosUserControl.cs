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
    public partial class CatalogosUserControl : Templates.MenuUserControl
    {
        public CatalogosUserControl()
        {
            InitializeComponent();
            Privilegios();
        }
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            vf.verificaOpc(this.itemContainer3, Helpers.Sesion.Usuario.UsuariosID.ToString(), 6);
            vf.verifica(this.catalogosMetroTileItem, Helpers.Sesion.Usuario.UsuariosID.ToString());
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
        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
        }

        private void Back()
        {
            try{
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


       

        private void bancosMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.BancosUserControl menu = new Catalogos.BancosUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner;
            menu.Muestra(); 
        }

        private void tipoMovInventarioMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.TipoMovimientoUserControl menu = new Catalogos.TipoMovimientoUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner;
            menu.Muestra(); 
        }

        private void descuentosMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.CatalogoDescuentosUserControl menu = new Catalogos.CatalogoDescuentosUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner;
            menu.Muestra(); 
        }

        private void claSSAMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.SSAControl menu = new Catalogos.SSAControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner;
            menu.Muestra(); 
        }

        private void catValesDevMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.ValesDevolucionUserControl menu = new Catalogos.ValesDevolucionUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner;
            menu.Muestra(); 
        }

        private void especialidadMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.EspecialidadUserControl menu = new Catalogos.EspecialidadUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner;
            menu.Muestra(); 
        }

        

        private void monedasMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.MonedasUserControl menu = new Catalogos.MonedasUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner;
            menu.Muestra(); 
        }

        private void tipoDevolucionMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.TipoDevolucionUserControl menu = new Catalogos.TipoDevolucionUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner;
            menu.Muestra(); 
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void impuestosMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.ImpuestoUserControl menu = new Catalogos.ImpuestoUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner;
            menu.Muestra(); 
        }

        private void tipoCambioMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.TipoCambioUserControl menu = new Catalogos.TipoCambioUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner;
            menu.Muestra(); 
        }

        private void tipoClienteMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.TipoClienteUserControl menu = new Catalogos.TipoClienteUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner;
            menu.Muestra(); 
        }

        private void proveedorMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.ProveedoresControl menu = new Catalogos.ProveedoresControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner;
            menu.Muestra(); 
        }

        private void catalogosMetroTileItem_Click(object sender, EventArgs e)
        {
            CatalogosSegUserControl menu = new CatalogosSegUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner;
            menu.Muestra(); 
        }

        private void ClientesConvenio_Click(object sender, EventArgs e)
        {
            Catalogos.ClienteControl menu = new Catalogos.ClienteControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = this;
            menu.titleLabel.Text = "CATALOGOS\\CLIENTE CONVENIO";
            menu.Muestra(); 
        }

        

 

 
    }
}
