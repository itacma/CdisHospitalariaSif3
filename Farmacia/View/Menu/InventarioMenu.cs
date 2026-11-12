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
    public partial class InventarioMenu : Templates.MenuUserControl
    {
        public InventarioMenu()
        {
            InitializeComponent();
            Privilegios();
        }
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            vf.verificaOpc(this.itemContainer1, Helpers.Sesion.Usuario.UsuariosID.ToString(), 5);

            vf.verificaOpc(this.itemContainer2, Helpers.Sesion.Usuario.UsuariosID.ToString(), 5);//ITACMA 21/07/2021 Validacion de Punto de Venta
            vf.verificaOpc(this.itemContainer3, Helpers.Sesion.Usuario.UsuariosID.ToString(), 5);//ITACMA 21/07/2021 Validacion de Punto de Venta

            
            if (Helpers.Sesion.Usuario.TipoUsuario == SIFModelo.Tipos.TipoUsuario.ADMINISTRATIVO)
            {
                this.metroTileItem20.Enabled = true;
            }
            else
            {
                this.metroTileItem20.Enabled = false;
            }

        }
                
        public MainForm Owner;

        #region  Navegación de Ventana

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.ActiveControl = metroTilePanel1;
            this.pedidoAlmacenMetroTileItem.Focus();
           
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
                Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.DesactivaComandos();
                this.Owner.ActivaComandos();
                Mostrado = false;
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

        private void consultaProductosMetroTileItem_Click(object sender, EventArgs e)
        {
            View.Inventario.ConsultaArticuloUserControl menu = new Inventario.ConsultaArticuloUserControl();
            menu.Owner = this;
            menu.Muestra();
        }

        public bool Mostrado = false;

        private void generaEOQmetroTileItem_Click(object sender, EventArgs e)
        {
            View.Inventario.CalculoEOQUserControl menu = new Inventario.CalculoEOQUserControl();
            menu.Owner = this;
            menu.Muestra();
        }


        
        private void pedidoAlmacenMetroTileItem_Click(object sender, EventArgs e)
        {
            View.Inventario.PedidosAlmacenUserControl frmPedidosAlmacen = new Inventario.PedidosAlmacenUserControl();
            if (!frmPedidosAlmacen.Mostrado)
            {
                frmPedidosAlmacen.Owner = this;
                frmPedidosAlmacen.Muestra();
            }
        }

        
        private void metroTileItem13_Click(object sender, EventArgs e)
        {
            View.Inventario.TraspasosAlmacenUserControl frmTraspasosAlmacen = new Inventario.TraspasosAlmacenUserControl();
            if (!frmTraspasosAlmacen.Mostrado)
            {
                frmTraspasosAlmacen.Owner = Owner;
                frmTraspasosAlmacen.Muestra();
            }
        }
       
        private void metroTileItem14_Click(object sender, EventArgs e)

        {
            View.Inventario.RecepcionTraspasosAlmacenUserControl frmRecepTrasp = new Inventario.RecepcionTraspasosAlmacenUserControl();
            if (!frmRecepTrasp.Mostrado)
            {
                frmRecepTrasp.Owner = this;
                frmRecepTrasp.Muestra();
            }
        }

        private void metroTileItem1_Click(object sender, EventArgs e)
        {
            View.Inventario.DevolucionesAlmacenUserControl menu = new Inventario.DevolucionesAlmacenUserControl();
            menu.Owner = this;
            menu.Muestra();
        }

        private void metroTileItem16_Click(object sender, EventArgs e)
        {
            Catalogos.ArticuloUserControl menu = new Catalogos.ArticuloUserControl();
            menu.Dock = DockStyle.Fill;
            menu.Owner = this;
            menu.Muestra();
        }

        private void metroTileItem20_Click(object sender, EventArgs e)
        {

            View.Inventario.AjustesAlmacenUserControl Ajuste = new Inventario.AjustesAlmacenUserControl();
            Ajuste.Owner = Owner;
            this.DesactivaComandos();
           

            Ajuste.Muestra();
        }
        private void metroTileItem21_Click(object sender, EventArgs e)
        {

            View.Inventario.DestruccionesAlmacenUserControl Destruccion = new Inventario.DestruccionesAlmacenUserControl();
            Destruccion.Owner = Owner;
            this.DesactivaComandos();
            Destruccion.Muestra();
        }

        private void metroTileItem17_Click(object sender, EventArgs e)
        {
             View.Inventario.KardexAlmacenUserControl Kardex = new Inventario.KardexAlmacenUserControl();
            Kardex.Owner = Owner;
            this.DesactivaComandos();
            Kardex.Muestra();
        }

        private void metroTileItem18_Click(object sender, EventArgs e)
        {
            View.Inventario.ConversionAlmacenUserControl Conversion = new Inventario.ConversionAlmacenUserControl();
            Conversion.Owner = Owner;
            this.DesactivaComandos();
            Conversion.Muestra();

        }

        private void metroTileItem2_Click(object sender, EventArgs e)
        {
            View.Inventario.CatEquivalenciasUserControl Conversion = new Inventario.CatEquivalenciasUserControl();
            Conversion.Owner = Owner;
            this.DesactivaComandos();
            Conversion.Muestra();
        }

        private void metroTileItem3_Click(object sender, EventArgs e)
        {
            View.Catalogos.InventarioFisicoUserControl inventario = new Catalogos.InventarioFisicoUserControl();
            inventario.Owner = this;
            inventario.DesactivaComandos();
            inventario.Muestra();
        }

        private void pncTileItem_Click(object sender, EventArgs e)
        {
            View.Inventario.ProductoNoConformeUserControl pnc = new Inventario.ProductoNoConformeUserControl();
            pnc.Owner = Owner;
            this.DesactivaComandos();
            pnc.Muestra();
        }

        private void InventarioMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
