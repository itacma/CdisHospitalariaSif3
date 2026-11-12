using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Menu.Ventas
{
    public partial class ControladosUserControl : Templates.MenuUserControl
    {
        public VentasMenu Owner;
        public ControladosUserControl()
        {
            InitializeComponent();
            Privilegios();
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            vf.verificaOpc(this.itemContainer1, Helpers.Sesion.Usuario.UsuariosID.ToString(), 8);
        }
        #region  Navegación de Ventana

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.ActiveControl = metroTilePanel1;
            generaFolioControladoMetroTileItem.Focus();
        }

        /// <summary>
        /// Activa los acesos cortos mediante el teclado
        /// </summary>
        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
        }

        public void Back()
        {
            try{
            if (Mostrado)
            {
                if (Owner.Owner.Contains(this))
                {
                    this.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }
                this.Owner.ActivaComandos();
                this.DesactivaComandos();
                this.Mostrado = false;
            }
            }
            catch { }
        }

        private void Salir()
        {
            this.Owner.Owner.Salir();
        }

        internal void Navega()
        {
            //this.Owner.DesactivaComandos();
            //this.Owner.Owner.DesactivaComandos();
            if (!Mostrado)
            {
                this.ActivaComandos();
                this.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }
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

        private void generaFolioControladoMetroTileItem_Click(object sender, EventArgs e)
        {
            View.Ventas.FoliocontroladoUserControl frmControlados = new View.Ventas.FoliocontroladoUserControl();
            frmControlados.Owner = this;
            frmControlados.Muestra();
          
        }

        private void foliosControladosMetroTileItem_Click(object sender, EventArgs e)
        {
            View.Ventas.ControladosUserControl frmControlados = new View.Ventas.ControladosUserControl();
            frmControlados.Owner = this;
            frmControlados.Muestra();
        }


        public bool Mostrado;
    }
}
