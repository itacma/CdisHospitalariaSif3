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
    public partial class ComprasMenu : Templates.MenuUserControl
    {
        public ComprasMenu()
        {
            InitializeComponent();
            Privilegios();
            ReportesAdminMetroTileItem.Visible = false;
        }
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            vf.verificaOpc(this.itemContainer1, Helpers.Sesion.Usuario.UsuariosID.ToString(), 2);
            vf.verificaOpc(this.itemContainer2, Helpers.Sesion.Usuario.UsuariosID.ToString(), 2);
            vf.verificaOpc(this.itemContainer3, Helpers.Sesion.Usuario.UsuariosID.ToString(), 2);
        }
        public MainForm Owner;

        #region  Navegación de Ventana

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);

            this.recepcionComprasMetroTileItem.Focus();
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

        private void metroTileItem2_Click(object sender, EventArgs e)
        {

        }

        private void generaOrdenCompraMetroTileItem_Click(object sender, EventArgs e)
        {
            OrdenCompra.OrdenCompraUserControl modulo = new OrdenCompra.OrdenCompraUserControl();
            modulo.Owner = this;

            //SIF.View.Ventas.AccesoUsuarioForm frmUsuario = new SIF.View.Ventas.AccesoUsuarioForm();
            //if (frmUsuario.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}
            modulo.usuario = Helpers.Sesion.Usuario;
            modulo.Muestra();
        }

        private void recepcionComprasMetroTileItem_Click(object sender, EventArgs e)
        {
            OrdenCompra.RecepcionOrdenCompraUserControl modulo = new OrdenCompra.RecepcionOrdenCompraUserControl();
            modulo.Owner = this;
            modulo.Muestra();
        }

        private void metroTileItem1_Click(object sender, EventArgs e)
        {
            OrdenCompra.AsignacionPreciosOrdenCompraUserControl modulo = new OrdenCompra.AsignacionPreciosOrdenCompraUserControl();
            modulo.Owner = this;
            modulo.Muestra();
        }

        private void metroTileItem31_Click(object sender, EventArgs e)
        {
            OrdenCompra.BonificacionUserControl modulo = new OrdenCompra.BonificacionUserControl();
            modulo.Owner = this;
            modulo.Muestra();
        }

        private void ajusteInventarioMetroTileItem_Click(object sender, EventArgs e)
        {
            //OrdenCompra.AjusteInventarioUserControl modulo = new OrdenCompra.AjusteInventarioUserControl();
            //modulo.Owner = this;
            //modulo.Muestra();

            Inventario.AjustesAlmacenComprasUserControl frmAjustes = new Inventario.AjustesAlmacenComprasUserControl();
            frmAjustes.Owner = this.Owner;
            frmAjustes.Muestra();
        }

        private void manejoDescuentosMetroTileItem_Click(object sender, EventArgs e)
        {
            OrdenCompra.ManejoDescuentosUserControl modulo = new OrdenCompra.ManejoDescuentosUserControl();
           // OrdenCompra.ManejoDescuentosDetalleUserControlV2 modulo = new OrdenCompra.ManejoDescuentosDetalleUserControlV2();
            modulo.Owner = this;
            modulo.Muestra();
        }

        private void consultaOCMetroTileItem_Click(object sender, EventArgs e)
        {
            OrdenCompra.OrdenesCompraUserControl modulo = new OrdenCompra.OrdenesCompraUserControl();
            modulo.Owner = this;
            modulo.Muestra();
        }

        private void reposicionDevolucionnMetroTileItem_Click(object sender, EventArgs e)
        {
            OrdenCompra.DevolucionReposicionControl modulo = new OrdenCompra.DevolucionReposicionControl();
            modulo.Owner = this;
            modulo.Muestra();
        }

        private void facturasMetroTileItem_Click(object sender, EventArgs e)
        {
            OrdenCompra.AplicarOfertaUserControl modulo = new OrdenCompra.AplicarOfertaUserControl(true);
            modulo.Owner = this;
            modulo.Muestra();

            //OrdenCompra.FacturasUserControl modulo = new OrdenCompra.FacturasUserControl();
            //modulo.Owner = this;
            //modulo.Muestra();
        }

        public bool Mostrado = false;



        private void ofertasMetroTileItem_Click(object sender, EventArgs e)
        {
            OrdenCompra.AplicarOfertaUserControl modulo = new OrdenCompra.AplicarOfertaUserControl();
            modulo.Owner = this;
            modulo.Muestra();
        }

        private void subrogacionMetroTileItem_Click(object sender, EventArgs e)
        {
            SIF.View.Menu.Compras.ComprasUserControl modulo = new Compras.ComprasUserControl();
            modulo.Owner = this;
            modulo.Muestra();
        }

        private void NotasCreditoMetroTileItem_Click(object sender, EventArgs e)
        {
            View.OrdenCompra.NotasDeCreditoControl notaCredito = new View.OrdenCompra.NotasDeCreditoControl();
            notaCredito.ModuloID = 9;
            notaCredito.Owner = Owner;
            this.DesactivaComandos();
            notaCredito.Muestra();

        }

        private void ReportesAdminMetroTileItem_Click(object sender, EventArgs e)
        {

            Reportes.ReportesAdmin nvf = new Reportes.ReportesAdmin();
            nvf.ShowDialog();
        }

        private void tipoMedicamentoComprasMetroTileItem_Click(object sender, EventArgs e)
        {
            Catalogos.TipoMedicamentoComprasUserControl modulo = new Catalogos.TipoMedicamentoComprasUserControl();
            modulo.Owner = this.Owner;
            modulo.Muestra();
        }

        private void ofertasProveedorMetroTileItem_Click(object sender, EventArgs e)
        {
            OrdenCompra.OfertasMayoristasUserControl modulo = new OrdenCompra.OfertasMayoristasUserControl();
            modulo.Owner = this;
            modulo.Muestra();
        }

        //private void ofertasComprasMetroTileItem_Click(object sender, EventArgs e)
        //{
        //    Compras modulo = new Articulos.OfertasMayoristaUserControl();
        //    modulo.Owner = this;
        //    modulo.Muestra();
        //}

      
    }
}
