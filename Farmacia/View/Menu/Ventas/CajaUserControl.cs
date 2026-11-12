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
    public partial class CajaUserControl : Templates.MenuUserControl
    {
        public VentasMenu Owner;
        public CajaUserControl()
        {
            InitializeComponent();
            Privilegios();
        }
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            vf.verificaOpc(this.itemContainer1, Helpers.Sesion.Usuario.UsuariosID.ToString(), 7);
        }


        #region  Navegación de Ventana

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);

            pagoCajaMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftP);
            pagoCajaMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl1);

            ingresoCajaMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftI);
            ingresoCajaMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl2);

            mantenimientoACajasMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftM);
            mantenimientoACajasMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl3);

            ingresoCajaMetroTileItem.Focus();
            this.ActiveControl = metroTilePanel1;
        }

        /// <summary>
        /// Activa los acesos cortos mediante el teclado
        /// </summary>
        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
            pagoCajaMetroTileItem.Shortcuts.Clear();
            ingresoCajaMetroTileItem.Shortcuts.Clear();
            mantenimientoACajasMetroTileItem.Shortcuts.Clear();
        }

        public void Back()
        {
            try{
            this.DesactivaComandos();
            this.Owner.ActivaComandos();
            if (Owner.Owner.Contains(this))
            {
                try
                {
                    this.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }
                catch
                { 
                }
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
            this.Owner.Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
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


        private void pagoCajaMetroTileItem_Click(object sender, EventArgs e)
        {
            View.Ventas.VentasPagoUserControl menu = new View.Ventas.VentasPagoUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = this;

            View.Ventas.CajaUsuarioForm frmCaja = new View.Ventas.CajaUsuarioForm();
            //DialogResult res = frmCaja.ShowDialog();
            if (frmCaja.ShowDialog() != DialogResult.OK)
            {
                //this.Back();
                return;
            }

            menu.CajaId = frmCaja.CajaID;
            menu.UsuarioId = frmCaja.Usuario.UsuariosID;

            menu.Muestra();
        }

        private void ingresoCajaMetroTileItem_Click(object sender, EventArgs e)
        {
            View.Ventas.AltaTurnoCajeraForm altaTurno = new View.Ventas.AltaTurnoCajeraForm();
            altaTurno.ShowDialog();
        }

        private void mantenimientoACajasMetroTileItem_Click(object sender, EventArgs e)
        {
            View.Ventas.ControlCajasUserControl altaTurno = new View.Ventas.ControlCajasUserControl();
            altaTurno.Owner = this;
            altaTurno.Muestra();
        }

    }
}
