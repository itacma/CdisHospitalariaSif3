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
    public partial class ConfiguracionMenu : Templates.MenuUserControl
    {
        public MainForm Owner;
        public ConfiguracionMenu()
        {
            InitializeComponent();
            Privilegios();
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            vf.verificaOpc(this.itemContainer1, Helpers.Sesion.Usuario.UsuariosID.ToString(), 6);
        }
        private void Bancos()
        {
            Catalogos.BancosUserControl bancos = new Catalogos.BancosUserControl();
            bancos.Owner = this;
            bancos.Muestra();
        }

        #region  Navegación de Ventana

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);

            this.ActiveControl = metroTilePanel1;
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
            if (Owner.Contains(this))
            {
                Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            }
            this.DesactivaComandos();
            this.Owner.ActivaComandos();
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

        private void salirButton_Click(object sender, EventArgs e)
        {
            this.Salir();
        }

        private void bancosMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.BancosUserControl menu = new Catalogos.BancosUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = this;
            menu.Muestra();
        }

        private void productosMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.ArticuloUserControl menu = new Catalogos.ArticuloUserControl();
            menu.cualmenu = 3;
            menu.Dock = DockStyle.Fill;
            menu.Owner = this;
            menu.Muestra();
        }

        private void catalogosMetroTileItem_Click(object sender, EventArgs e)
        {
            CatalogosUserControl menu = new CatalogosUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = this;
            menu.Muestra(); 
        }

        private void cajasMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.CajasUserControl menu = new Catalogos.CajasUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = this;
            menu.Muestra(); 
        }

        private void usuariosMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.UsuarioUserControl menu = new Catalogos.UsuarioUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = this;
            menu.Muestra();
        }

        private void clientesMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.ClienteControl menu = new Catalogos.ClienteControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = this;
            menu.Muestra();
        }

        private void tipoPagoMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.TipoPagoUserControl menu = new Catalogos.TipoPagoUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = this;
            menu.Muestra();
        }

        private void medicosMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.MedicosUserControl menu = new Catalogos.MedicosUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = this;
            menu.Muestra();
        }

        private void sucursalesMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.SucursalesUserControl menu = new Catalogos.SucursalesUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = this;
            menu.Muestra();
        }

        private void tipoMedicamentoMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.TipoMedicamentoUserControl menu = new Catalogos.TipoMedicamentoUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner;
            menu.Muestra(); 
        }

        private void metroTileItem44_Click(object sender, EventArgs e)
        {
            Catalogos.LocalizacionesUserControl menu = new Catalogos.LocalizacionesUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = Owner;
            menu.Muestra(); 

        }

        private void proveedorMetroTileItem_Click(object sender, EventArgs e)
        {
            OrdenCompra.ProveedoresControl menu = new OrdenCompra.ProveedoresControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = this;
            menu.Muestra();
        }

        private void laboratoriosMetroTileItem_Click(object sender, EventArgs e)
        {
            OrdenCompra.LaboratoriosControl menu = new OrdenCompra.LaboratoriosControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = this;
            menu.Muestra(); 
        }

        //private void fabricantesTileItem_Click(object sender, EventArgs e)
        //{
        //    OrdenCompra.FabricantesControl menu = new OrdenCompra.FabricantesControl();
        //    menu.Dock = DockStyle.Fill;
        //    menu.Owner = this;
        //    menu.Muestra(); 
        //}

        private void ConfiguracionMenu_Load(object sender, EventArgs e)
        {

        }


        


    }
}
