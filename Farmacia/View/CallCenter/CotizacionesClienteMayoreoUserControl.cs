using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.CallCenter
{
    public partial class CotizacionesClienteMayoreoUserControl : Templates.CatalogoUserControl
    {
        SIFNegocio.cotizacionesClienteMayoristaNg cotizacionesM = new SIFNegocio.cotizacionesClienteMayoristaNg();
        public MainForm Owner;
        public Boolean Mostrado = false;
        private string estadoC = string.Empty;
        DataSet DsCotizaciones;
        public CotizacionesClienteMayoreoUserControl()
        {
            InitializeComponent();
            rbTodo.Checked = true;
            this.seleccionaEstado();
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
            this.seleccionaEstado();
            SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { SucursalesID = SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID };
            SIFModelo.Cotizacion cotizacion = new SIFModelo.Cotizacion();
             cotizacion.NumeroCotizacion = this.buscarTextBoxX.Text;

            DsCotizaciones = cotizacionesM.BuscaCotizaciones(sucursal, cotizacion, "W");
             
             DsCotizaciones.Relations.Add("1", DsCotizaciones.Tables["Cotizaciones"].Columns["FOLIO"],
                                            DsCotizaciones.Tables["CotizacionDetalles"].Columns["FOLIO"], false);

             //this.bindingSource.DataSource = DsRemisiones;
             this.dataGridViewX1.DataSource = DsCotizaciones;
             //superGridControl1.PrimaryGrid.AutoGenerateColumns = true;
             //superGridControl1.PrimaryGrid.DataMember = "Cotizaciones";*/
        }

        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }
        public void Back()
        {
            try
            {
                if (this.Mostrado && Owner.IsModalPanelDisplayed)
                {
                    this.DesactivaComandos();
                    this.Owner.ActivaComandos();
                    this.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = false;
                }
            }
            catch { }
        }
        public void DesactivaComandos()
        {

            backButton.Shortcuts.Clear();
        }


        private void buttonItem1_Click(object sender, EventArgs e)
        {

         /*
            SIFModelo.Cotizacion cotizacion = this.SelectedCotizacion();

            if (cotizacion == null)
            {
               MessageBox.Show("Seleccione un cotizacion");
                return;
            }

            if (cotizacion.Activo == SIFModelo.Tipos.SiNo.NO)
            {
               MessageBox.Show("La cotización ya no esta activa");
                return;
            }

            if (cotizacion.TipoCotizacion == SIFModelo.Tipos.TipoCotizacion.VENTA)
            {
                if (cotizacion.FechaCotizacion.AddHours(-24) > SIFNegocio.Configuracion.Configuraciones.fechaServidor())
                {
                   MessageBox.Show("La cotización ha caducado 24 horas");
                    return;
                }
            }
            if (cotizacion.TipoCotizacion == SIFModelo.Tipos.TipoCotizacion.CONVENIO)
            {
                if (cotizacion.FechaCotizacion.AddDays(-30) > SIFNegocio.Configuracion.Configuraciones.fechaServidor())
                {
                   MessageBox.Show("La cotización ha caducado 30 días");
                    return;
                }
            }
            cotizacion.Detalles = cotizacionesL.CargaDetallesF(cotizacion);

            View.CallCenter.CotizacionComercializacionUserControl frmConsultas = new View.CallCenter.CotizacionComercializacionUserControl();
            frmConsultas.PCotiza = cotizacion;
            // frmConsultas.Cual = 3;
            frmConsultas.Owner = this;
            //frmConsultas.Owner1 = this;
            frmConsultas.Muestra();
            SIF.funciones.Bitacora("modifico cotización:" + cotizacion.NumeroCotizacion.ToString(), 82, 2);

        */
        }


        private void nuevoPedidoButtonItem_Click(object sender, EventArgs e)
        {
            View.CallCenter.CotizacionClienteMayoreoUserControl frmConsultas = new View.CallCenter.CotizacionClienteMayoreoUserControl();
            //frmConsultas.Cual = 3;
            //frmConsultas.Owner = this.Owner;
            frmConsultas.Owner = this;
            //frmConsultas.Owner1 = this;
            frmConsultas.Muestra();

        }


        private void buscarTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Buscar();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
            }
        }



        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }
        private void seleccionaEstado() {
            estadoC = "#";
            if (rbTodo.Checked)
                estadoC = "TODO";
            if(rbAbiertas.Checked)
                estadoC = "ABIERTA";
            if (rbTerminadas.Checked)
                estadoC = "TERMINADA";
            if(rbConverRemision.Checked)
                estadoC = "CONREMISION";
            if(rbCancelados.Checked)
                estadoC = "CANCELADAS";
            if (rbLiberados.Checked)
                estadoC = "LIBERADA";






        }




    }
}
