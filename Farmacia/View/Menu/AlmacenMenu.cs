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
    public partial class AlmacenMenu : Templates.MenuUserControl
    {
        public AlmacenMenu()
        {
            InitializeComponent();
            Privilegios();
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            vf.verificaOpc(this.itemContainer1, Helpers.Sesion.Usuario.UsuariosID.ToString(), 3);
        }

        public MainForm Owner;

        #region  Navegación de Ventana

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);

            recepcionBultosMetroTileItem.Focus();
            this.ActiveControl = metroTilePanel1;
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

        private void metroTileItem3_Click(object sender, EventArgs e)
        {
            View.Inventario.AjustesAlmacenUserControl Ajuste = new Inventario.AjustesAlmacenUserControl();
            Ajuste.ModuloID = 3;
            Ajuste.Owner = Owner;
            this.DesactivaComandos();
            Ajuste.Muestra();
        }
        
        private void metroTileItem10_Click(object sender, EventArgs e)
        {
            View.Inventario.TraspasosAlmacenUserControl frmTraspasosAlmacen = new Inventario.TraspasosAlmacenUserControl();
            frmTraspasosAlmacen.ModuloID = 3;
            if (!frmTraspasosAlmacen.Mostrado)
            {
                frmTraspasosAlmacen.Owner = this.Owner;
                frmTraspasosAlmacen.Muestra();
            }
        }

        private void metroTileItem9_Click(object sender, EventArgs e)
        {
            View.Almacen.IncidenciasAlmacenUserControl Incidencias = new Almacen.IncidenciasAlmacenUserControl();
            Incidencias.Owner = this.Owner;
            this.DesactivaComandos();
            Incidencias.Muestra();
        }

        private void recepcionBultosMetroTileItem_Click(object sender, EventArgs e)
        {
            View.Almacen.RecepcionUserControl Recep=new Almacen.RecepcionUserControl();
            Recep.Owner = this.Owner;
            this.DesactivaComandos();
            Recep.Muestra();
            
        }

    }
}
