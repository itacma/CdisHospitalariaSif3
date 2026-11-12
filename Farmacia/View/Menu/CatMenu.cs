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
    public partial class CatMenu : Templates.MenuUserControl
    {
        public CatMenu()
        {
            InitializeComponent();
            Privilegios();
        }
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            vf.verificaOpc(this.itemContainer1, Helpers.Sesion.Usuario.UsuariosID.ToString(), 4);
        }
        public MainForm Owner;

        #region  Navegación de Ventana

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        { 
        backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);

        generaCotizacionMetroTileItem.Focus();
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
            Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.DesactivaComandos();
            this.Owner.ActivaComandos();
            this.Mostrado = false;
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

        private void citasDermaMetroTileItem_Click(object sender, EventArgs e)
        {
            View.CallCenter.ConsultasDermaForm frmConsultas = new CallCenter.ConsultasDermaForm();
            frmConsultas.Owner = this;
            frmConsultas.Mostrar();
        }

        private void generaCotizacionMetroTileItem_Click(object sender, EventArgs e)
        {
            View.CallCenter.CotizacionUserControl frmConsultas = new View.CallCenter.CotizacionUserControl();
            //frmConsultas.Cual = 0;
            frmConsultas.Owner = this.Owner;
            frmConsultas.Muestra();
        }

        private void quejaSugerenciaMetroTileItem_Click(object sender, EventArgs e)
        {
            View.CallCenter.QuejasSugerenciasUserControl frm = new View.CallCenter.QuejasSugerenciasUserControl();
            frm.Owner = this;
            frm.Muestra();
        }

        public bool Mostrado = false;

        private void generaPedidoMetroTileItem_Click(object sender, EventArgs e)
        {
            View.CallCenter.CotizacionUserControl frm = new View.CallCenter.CotizacionUserControl();
            frm.Cual = 1;
            frm.Owner = this;
            frm.Muestra();

        }

        private void apartadoEspecialMetroTileItem_Click(object sender, EventArgs e)
        {
            View.CallCenter.CotizacionUserControl frm = new View.CallCenter.CotizacionUserControl();
            frm.Cual = 2;
            frm.Owner = this;
            frm.Muestra();
        }

        private void metroTileItem1_Click(object sender, EventArgs e)
        {
           View.CallCenter.CatQuejasSugUserControl frm = new View.CallCenter.CatQuejasSugUserControl();
           frm.Owner = this;
           frm.Muestra();
        }

        private void metroTileItem2_Click(object sender, EventArgs e)
        {
            View.CallCenter.CotizacionesUserControl frm = new View.CallCenter.CotizacionesUserControl();
            frm.Owner = this.Owner;
            frm.Dock = DockStyle.Fill;
             if (!frm.Mostrado)
            {
                this.DesactivaComandos();
                frm.Navega();
            }
        }

        private void metroTileItem6_Click(object sender, EventArgs e)
        {
            View.CallCenter.CotizacionesClienteMayoreoUserControl frm = new View.CallCenter.CotizacionesClienteMayoreoUserControl();
            frm.Owner = this.Owner;
            frm.Dock = DockStyle.Fill;
            if (!frm.Mostrado)
            {
                this.DesactivaComandos();
                frm.Navega();
            }
        }
        public void Navega()
        {
            this.Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.Mostrado = true;
            this.Buscar();
        }
        public void Buscar()
        {
            SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { SucursalesID = SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID };
            SIFModelo.Cotizacion cotizacion = new SIFModelo.Cotizacion();
           /* cotizacion.NumeroCotizacion = this.buscarTextBoxX.Text;
            if (contadoRadioButton.Checked)
                DsCotizaciones = cotizacionesL.BuscaCotizaciones(sucursal, cotizacion, "W");
            else
                DsCotizaciones = cotizacionesL.BuscaCotizaciones(sucursal, cotizacion, "W");

            DsCotizaciones.Relations.Add("1", DsCotizaciones.Tables["Cotizaciones"].Columns["FOLIO"],
                                           DsCotizaciones.Tables["CotizacionDetalles"].Columns["FOLIO"], false);

            //this.bindingSource.DataSource = DsRemisiones;
            this.superGridControl1.PrimaryGrid.DataSource = DsCotizaciones;
            //superGridControl1.PrimaryGrid.AutoGenerateColumns = true;
            superGridControl1.PrimaryGrid.DataMember = "Cotizaciones";*/
        }
        private void EnvioMarketingMetroTileItem_Click(object sender, EventArgs e)
        {
            //View.CallCenter.ConsultasDermaForm frmConsultas = new CallCenter.ConsultasDermaForm();
            //frmConsultas.Owner = this;
            //frmConsultas.Mostrar();

            Marketing.SenEmailClientsAndCollaborators frm = new Marketing.SenEmailClientsAndCollaborators();
            frm.ShowDialog();


        }
    }
}
