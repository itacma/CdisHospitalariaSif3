using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar;

namespace SIF.View.Subrogacion

{
    public partial class LicitacionesUserControl : Templates.ListaUserControl
    {
        public MainForm Owner;
        public int Cual;
        public Boolean Mostrado = false;
        public LicitacionesUserControl()
        {
            InitializeComponent();
            this.inicializaTabla();
            Privilegios();
        }

        internal void Muestra()
        {
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;
            Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                int opcion = 84;
                if (Cual == 1)
                {
                    opcion = 83;
                }

                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), opcion, int.Parse(Xbtn.Tag.ToString()));
            }

        }
        public void inicializaTabla()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            superGridControl1.DataBindingComplete += SuperGridControl1DataBindingComplete;
        }

        void SuperGridControl1DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;

            if (panel.DataMember == "CotizacionDetalles")
            {
                CustomizeDetailsPanel(panel);
                CustomizeDetailsPanel(panel);
                for (int i = 6; i < panel.Columns.Count; i++)
                {
                    panel.Columns[i].Visible = false;
                }
            }
            if (panel.DataMember == "Cotizaciones")
            {
                CustomizeDetailsPanel(panel);
                CustomizeDetailsPanel(panel);
                for (int i = 10; i < panel.Columns.Count; i++)
                {
                    panel.Columns[i].Visible = false;
                }
            }

        }

        private void Cancelar()
        {
            SIFModelo.Cotizacion cotizacion = this.SelectedCotizacion();

            if (cotizacion == null)
            {
               MessageBox.Show("Seleccione el cotizacion a cancelar");
                return;
            }

            if (cotizacion.Activo == SIFModelo.Tipos.SiNo.NO)
            {
               MessageBox.Show("El cotizacion fue cancelado anteriormente");
                return;
            }

            //if (!string.IsNullOrEmpty(cotizacion.ReferenciaRemisionVenta))
            //{
            //   MessageBox.Show("El cotizacion no puede ser cancelado porque fue convertido en remision");
            //    return;
            //}

            if (MessageBoxEx.Show("¿Eliminar el cotizacion " + cotizacion.NumeroCotizacion + " ?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            SIFNegocio.Cotizacion cotizacionL = new SIFNegocio.Cotizacion();

            Ventas.DatosDerechohabiente motivo = new Ventas.DatosDerechohabiente();
            motivo.ShowDialog();

            cotizacion.Activo = SIFModelo.Tipos.SiNo.NO;

            if (cotizacionL.ActualizaCotizacion(cotizacion))
            {
                //EN EL DATAGRID PONER COMO CANCELADO
                GridPanel grid = superGridControl1.PrimaryGrid;
                grid.Rows.Remove(grid.ActiveRow);
                SIF.funciones.Bitacora("Cancelo Cotización:" + cotizacion.NumeroCotizacion.ToString(), 2, 4);
            }
            else
            {
               MessageBox.Show("No se consiguió cancelar el cotizacion");
            }
        }

        private void CustomizeDetailsPanel(GridPanel panel)
        {
            panel.AutoGenerateColumns = true;
        }

        DataSet DsCotizaciones;
        SIFNegocio.Cotizacion cotizacionesL = new SIFNegocio.Cotizacion();
        public void Buscar()
        {
            SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { SucursalesID = SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID };
            SIFModelo.Cotizacion cotizacion = new SIFModelo.Cotizacion();
            cotizacion.NumeroCotizacion = this.buscarTextBoxX.Text;
            if (contadoRadioButton.Checked)
              DsCotizaciones = cotizacionesL.BuscaCotizaciones(sucursal, cotizacion,"");
            else
              DsCotizaciones = cotizacionesL.BuscaCotizaciones(sucursal, cotizacion,"S");

            DsCotizaciones.Relations.Add("1", DsCotizaciones.Tables["Cotizaciones"].Columns["FOLIO"],
                                           DsCotizaciones.Tables["CotizacionDetalles"].Columns["FOLIO"], false);

            //this.bindingSource.DataSource = DsRemisiones;
            this.superGridControl1.PrimaryGrid.DataSource = DsCotizaciones;
            //superGridControl1.PrimaryGrid.AutoGenerateColumns = true;
            superGridControl1.PrimaryGrid.DataMember = "Cotizaciones";
        }

        private SIFModelo.Cotizacion SelectedCotizacion()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;

            if (panel.ActiveRow == null)
            {
                return null;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               //MessageBox.Show("Seleccione la cabecera de la cotizacion");
                return null;
            }
            var row = (GridRow)container;

            DataRow datarow = ((DataRowView)row.DataItem).Row;
            SIFModelo.Cotizacion cotizacion = new SIFModelo.Cotizacion();
            cotizacion.SucursalID = int.Parse(datarow["SUCURSAL_ID"].ToString());
            cotizacion.NumeroCotizacion = datarow["NUM_COTIZACION"].ToString();
            cotizacion.TipoClienteID = int.Parse(datarow["TIPO_CLIENTE_ID"].ToString());
            cotizacion.ClienteID = int.Parse(datarow["CLIENTE_ID"].ToString());
            cotizacion.FechaCotizacion = DateTime.Parse(datarow["FECHA_COTIZACION"].ToString());
            cotizacion.Receta = (SIFModelo.Tipos.SiNo)(datarow["RECETA"].ToString()[0]);
            //cotizacion.MedicoID = int.Parse(datarow["ID_MEDICO"].ToString());
            //cotizacion.FechaPago = DateTime.Parse(datarow["FECHA_PAGO"].ToString());
            cotizacion.VendedorID = int.Parse(datarow["VENDEDOR_ID"].ToString());
            cotizacion.MonedaID = int.Parse(datarow["MONEDA_ID"].ToString());
            //cotizacion.TipoCambio = int.Parse(datarow["TIPO_CAMBIO_ID"].ToString());
            //cotizacion.Condiciones = (datarow["CONDICIONES"].ToString());
            cotizacion.SubTotal = decimal.Parse(datarow["SUBTOTAL"].ToString());
            //cotizacion.Impuesto = int.Parse(datarow["IMPUESTO_IVA"].ToString());
            cotizacion.Descuento = decimal.Parse(datarow["DESCUENTO"].ToString());
            cotizacion.Total = decimal.Parse(datarow["TOTAL"].ToString());
            //cotizacion.TotalArticulosRemision = decimal.Parse(datarow["TOTAL_ARTICULOS_REM"].ToString());
            //cotizacion.NumeroFactura = (datarow["NUM_FACTURA"].ToString());
            cotizacion.TipoCotizacion = (SIFModelo.Tipos.TipoCotizacion)(datarow["TIPO_COTIZACION"].ToString()[0]);
            cotizacion.Activo = (SIFModelo.Tipos.SiNo)(datarow["ACTIVO"].ToString()[0]);
            cotizacion.ImporteLetra = datarow["IMPORTE_LETRA"].ToString();
            cotizacion.Factura = (SIFModelo.Tipos.SiNo)(datarow["FACTURA"].ToString()[0]);
            cotizacion.Comentario = datarow["comentario"].ToString();
            //cotizacion.Comentarios = datarow["COMENTARIOS"].ToString();
            ////cotizacion.Numerocotizacion = datarow["NUM_cotizacion"].ToString();
            //cotizacion.BeneficioProveedor = (SIFModelo.Tipos.SiNo)datarow["BENEFICIO_PROV"].ToString()[0];
            //cotizacion.ImpuestoIVA = decimal.Parse( datarow["IMPUESTO_IVA"].ToString());
            return cotizacion;


        }

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
        private void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
        }

        public void Back()
        {
            if (this.Mostrado && Owner.IsModalPanelDisplayed)
            {
                this.DesactivaComandos();
                this.Owner.ActivaComandos();
                this.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = false;
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

        #endregion


        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //View.CallCenter.CotizacionUserControl frmcotizacion = new CotizacionUserControl();
            //frmcotizacion.Dock = DockStyle.Fill;
            //frmcotizacion.Owner = this.Owner;
            //this.DesactivaComandos();
            //this.Owner.ShowModalPanel(frmcotizacion, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }

        private void cotizacionsUserControl_Load(object sender, EventArgs e)
        {
            //this.Buscar();
        }

        private void salirButtonItem_Click(object sender, EventArgs e)
        {
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

            cotizacion.Detalles = cotizacionesL.CargaDetalles(cotizacion);

            Ventas.VentaPedidoUserControl frmVenta = new Ventas.VentaPedidoUserControl();
            frmVenta.convertidaDe = cotizacion;

            frmVenta.Owner = this.Owner;
            frmVenta.Owner1 = this;
            frmVenta.Muestra();
            SIF.funciones.Bitacora("Convierte Cotización:" + cotizacion.NumeroCotizacion.ToString(), 82, 12);

            try
            {
                this.superGridControl1.PrimaryGrid.Rows.Remove(superGridControl1.PrimaryGrid.ActiveRow);
            }
            catch
            {
            }
        }

        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.Buscar();
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

        private void cancelarButtonItem_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
             if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true,true);
            }
        }

        private void nuevoPedidoButtonItem_Click(object sender, EventArgs e)
        {
            if (Cual == 0)
            {
                View.Subrogacion.CotizacionUserControl frmConsultas = new View.Subrogacion.CotizacionUserControl();
                frmConsultas.Cual = 4;
                frmConsultas.Owner = this.Owner;
                frmConsultas.Owner1 = this;
                frmConsultas.Muestra();
            }
            else
            {
                View.Subrogacion.CotizacionUserControl frmConsultas = new View.Subrogacion.CotizacionUserControl();
                frmConsultas.Cual = 4;
                frmConsultas.Owner = this.Owner;
                frmConsultas.Owner1 = this;
                frmConsultas.Muestra();
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {


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
            cotizacion.Detalles = cotizacionesL.CargaDetalles(cotizacion);

            View.CallCenter.CotizacionUserControl frmConsultas = new View.CallCenter.CotizacionUserControl();
            frmConsultas.PCotiza = cotizacion;
            frmConsultas.Cual = 3;
            frmConsultas.Owner = this.Owner;
            frmConsultas.Owner1 = this;
            frmConsultas.Muestra();
            SIF.funciones.Bitacora("modifico cotización:" + cotizacion.NumeroCotizacion.ToString(), 82, 2);

        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            SIFModelo.Cotizacion cotizacion = this.SelectedCotizacion();
            String Parm1 = "{COTIZACION.NUM_COTIZACION}='" + cotizacion.NumeroCotizacion +"'";
            SIFNegocio.Usuarios Logusu=new SIFNegocio.Usuarios();
            SIFModelo.Usuario Vend = Logusu.UsuarioPorId(cotizacion.VendedorID);
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Cotizaciones.rpt", Parm1,Vend.Nombre + ' ' + Vend.Apellidos);
            Impresion.ShowDialog();
        }

    }
}
