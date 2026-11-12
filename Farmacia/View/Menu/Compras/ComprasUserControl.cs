using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Menu.Compras
{
    public partial class ComprasUserControl : Templates.MenuUserControl
    {
        public ComprasMenu Owner;
        public bool Mostrado = false;
        public ComprasUserControl()
        {
            InitializeComponent();
            Privilegios();
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            //vf.verificaOpc(LicitacionMetroTileItem, Helpers.Sesion.Usuario.UsuariosID.ToString(), 10);
            //vf.verificaOpc(LicitacionDirectaMetroTileItem, Helpers.Sesion.Usuario.UsuariosID.ToString(), 10);
            vf.verificaOpc(ArticulosMetroTileItem, Helpers.Sesion.Usuario.UsuariosID.ToString(), 10);
            vf.verificaOpc(FacturasMetroTileItem, Helpers.Sesion.Usuario.UsuariosID.ToString(),10);
            vf.verificaOpc(metroTileItem3, Helpers.Sesion.Usuario.UsuariosID.ToString(),10);
            vf.verificaOpc(metroTileItem5, Helpers.Sesion.Usuario.UsuariosID.ToString(),10);
            vf.verificaOpc(ActualizacionValesMetroTileItem, Helpers.Sesion.Usuario.UsuariosID.ToString(), 10);
        }

        private void licitacionMetroTileItem_Click(object sender, EventArgs e)
        {
            SIF.View.Subrogacion.LicitacionesUserControl Art = new Subrogacion.LicitacionesUserControl();
            Art.Cual = 0;
            Art.Owner = Owner.Owner;
            Art.Muestra();
            
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
            try{
            if (Owner.Owner.Contains(this))
            {
                Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            }
            this.Owner.Owner.ActivaComandos();
            Mostrado = false;
            }
            catch { }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void subrogacionMetroTileItem_Click(object sender, EventArgs e)
        {
            //Comentado por XFM para abrir nuevo módulo el 14/09/2026
            //SIF.View.Subrogacion.ArticulosSubrogacionUserControl Art = new Subrogacion.ArticulosSubrogacionUserControl();
            //Art.Owner = Owner.Owner;
            //Art.Muestra();
            SIF.View.Subrogacion.CatalogoSubrogacionUserControl Art = new Subrogacion.CatalogoSubrogacionUserControl();
            Art.Owner = Owner.Owner;
            Art.Muestra();

        }

        private void FacturasMetroTileItem_Click(object sender, EventArgs e)
        {
            SIF.View.Subrogacion.FacturasUserControl Art = new Subrogacion.FacturasUserControl();
            Art.Owner = Owner.Owner;
            Art.Muestra();
        }

        private void LicitacionMetroTileItem_Click_1(object sender, EventArgs e)
        {
            SIF.View.Subrogacion.LicitacionesUserControl Art = new Subrogacion.LicitacionesUserControl();
            Art.Cual = 1;
            Art.Owner = Owner.Owner;
            Art.Muestra();
        }

        private void metroTileItem3_Click(object sender, EventArgs e)
        {
            SIF.View.Subrogacion.PagoFacturasUserControl Art = new Subrogacion.PagoFacturasUserControl();
            Art.Owner = Owner.Owner;
            Art.Muestra();
        }

        private void metroTileItem5_Click(object sender, EventArgs e)
        {
            SIF.View.Subrogacion.TicketCreditoUserControl Art = new Subrogacion.TicketCreditoUserControl();
            Art.Owner = Owner.Owner;
            Art.Muestra();
        }

        private void ActualizacionValesMetroTileItem_Click(object sender, EventArgs e)
        {
            SIF.View.Subrogacion.ActualizacionValesUserControl Art = new Subrogacion.ActualizacionValesUserControl();
            Art.Owner = this;
            Art.Muestra();
        }


        internal void DesactivaComandos()
        {
            
           // throw new NotImplementedException();
        }
    }
}
