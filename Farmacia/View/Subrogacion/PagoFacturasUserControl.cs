using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Equin.ApplicationFramework;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;

namespace SIF.View.Subrogacion
{
    public partial class PagoFacturasUserControl : Templates.ListaUserControl
    {
        public PagoFacturasUserControl()
        {
            InitializeComponent();
            this.inicializaTabla();
            Privilegios();

        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 87, int.Parse(Xbtn.Tag.ToString()));
            }
        }

        SIFNegocio.Remision remsionL = new SIFNegocio.Remision();

        private void Back()
        {
            if (this.Mostrado && Owner.IsModalPanelDisplayed)
            {
                //this.DesactivaComandos();
                try
                {
                    if (Owner.Contains(this))
                    {
                        Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Owner.ActivaComandos();
                    this.Mostrado = false;
                    this.DesactivaCommandos();
                }
                catch
                {

                }
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

            if (panel.DataMember == "RemisionDetalles")
            {
                CustomizeDetailsPanel(panel);
            }
           
        }

        private void CustomizeDetailsPanel(GridPanel panel)
        {
        }

        DataSet DsRemisiones;

        private void Buscar()
        {
            
        }

        private SIFModelo.Remision SelectedRemision()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;

            if (panel.ActiveRow == null)
            {
                return null;
            }

            if (panel.ActiveRow.GridPanel.DataMember != "Remisiones")
            {
               MessageBox.Show("Seleccione el encabezado de la remisión");
                return null;
            }

            var container = ((GridContainer)panel.ActiveRow);
            var row = (GridRow)container;

            DataRow datarow = ((DataRowView)row.DataItem).Row;
            SIFModelo.Remision remision = new SIFModelo.Remision();
            remision.SucursalID = int.Parse(datarow["SUCURSAL_ID"].ToString());
            remision.NumeroRemision = datarow["NUM_REMISION"].ToString();
            remision.TipoClienteID = int.Parse(datarow["TIPO_CLIENTE_ID"].ToString());
            remision.ClienteID = int.Parse(datarow["CLIENTE_ID"].ToString());
            remision.FechaVenta = DateTime.Parse(datarow["FECHA_VTA"].ToString());
            remision.Receta = (SIFModelo.Tipos.SiNo)(datarow["RECETA"].ToString()[0]);
            remision.MedicoID = int.Parse(datarow["ID_MEDICO"].ToString());
            if (!datarow.IsNull("FECHA_PAGO"))
            {
                remision.FechaPago = DateTime.Parse(datarow["FECHA_PAGO"].ToString());
            }
            remision.VendedorID = int.Parse(datarow["VENDEDOR_ID"].ToString());
            remision.MonedaID = int.Parse(datarow["MONEDA_ID"].ToString());
            remision.TipoCambio = int.Parse(datarow["TIPO_CAMBIO_ID"].ToString());
            remision.Condiciones = (datarow["CONDICIONES"].ToString());
            remision.SubTotal = decimal.Parse(datarow["SUBTOTAL"].ToString());
            remision.Impuesto = decimal.Parse(datarow["IMPUESTO_IVA"].ToString());
            remision.Descuento = decimal.Parse(datarow["DESCUENTO"].ToString());
            remision.Total = decimal.Parse(datarow["TOTAL"].ToString());
            remision.TotalArticulosRemision = decimal.Parse(datarow["TOTAL_ARTICULOS_REM"].ToString());
            remision.NumeroFactura = (datarow["NUM_FACTURA"].ToString());
            remision.Activo = (SIFModelo.Tipos.StatusVenta)(datarow["ACTIVO"].ToString()[0]);
            remision.ImporteLetra = datarow["IMPORTE_LETRA"].ToString();
            remision.Factura = (SIFModelo.Tipos.SiNo)(datarow["FACTURA"].ToString()[0]);
            remision.Comentarios = datarow["COMENTARIOS"].ToString();
            remision.NumeroPedido = datarow["NUM_PEDIDO"].ToString();
            remision.BeneficioProveedor = (SIFModelo.Tipos.SiNo)datarow["BENEFICIO_PROV"].ToString()[0];

            return remision;
        }

      

        private void PrecioArticulo(SIFModelo.RemisionDetalle detalle)
        {
            SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
            if (precios == null)
            {

               MessageBox.Show("No hay un precio activo para este producto");

            }
            else
            {
                detalle.Precio = precios.PRECIO_VENTA;
                detalle.Total = detalle.CantidadRemision * detalle.Precio;
                if (detalle.Precio == 0)
                {
                   MessageBox.Show("No hay un precio activo para este producto");
                    //return;
                }

                detalle.ImpuestoID = precios.IMP_VENTA;
                SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);
                decimal calculaImpuesto = detalle.Total * (impuesto.Porcentaje / 100m);

                detalle.IVA = calculaImpuesto;
            }
        }


        SIFNegocio.Remision logica = new SIFNegocio.Remision();
      


  

        public int CajaId;
        public int UsuarioId;
        private void VentasPagoUserControl_Load(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Focus();

            //conulstar recarga no exitosa
            consultaRecargaNoExitosa();
            // this.Buscar();
        }

        private void consultaRecargaNoExitosa()
        {
            SIFNegocio.WebServices.TAE tae = new SIFNegocio.WebServices.TAE();
            var control = tae.ConsultaRecargaNoExitosa("1", DateTime.Parse(SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("dd/MM/yyyy 00:00:00")), DateTime.Parse(SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("dd/MM/yyyy 23:59:59")));

            foreach (SIFModelo.Catalogo.CatalogoDataSet.CTL_TAERow ctl in control.Rows)
            {
                if (ctl != null)
                {
                    SIFModelo.WebServices.TAE taeC = new SIFModelo.WebServices.TAE();
                    SIFModelo.Remision REM = new SIFModelo.Remision();
                    REM.NumeroRemision = ctl.NUM_REMISION;
                    REM.SucursalID = Helpers.Sesion.Sucursal.SucursalesID;
                    taeC = tae.Control(REM, false);
                    //taeC.Archivo = control.NOM_ARCHIVO;
                    //taeC.Articulo = control.ARTICULO_ID;
                    //taeC.Cadena = control.CADENA;
                    //taeC.Caja = control.CAJA;
                    //taeC.Carrier = control.CARRIER_ID;
                    //taeC.Fecha = control.FECHA_ALTA;
                    //taeC.Grupo = control.GRUPO;
                    //taeC.Importe = control.IMPORTE;
                    //taeC.Referencia = control.REFERENCIA.ToString();
                    //taeC.Remision = control.NUM_REMISION;
                    //taeC.Respuesta = control.RESPUESTA_DESC.ToString();
                    //taeC.RespuestaID = control.RESPUESTA_ID.ToString();
                    //taeC.Sucursal = control.SUCURSAL;
                    //taeC.Telefono = control.NUM_TELEFONO;

                    if (string.IsNullOrEmpty(taeC.Respuesta))
                    {
                       MessageBox.Show("Se consultará la recarga " + taeC.Remision);
                        string respuesta = "";
                        if (taeC.Carrier == 1)
                        {

                            respuesta = tae.QueryTae(taeC, SIFNegocio.Configuracion.Configuraciones.TAE);
                        }
                        if (taeC.Carrier != 1)
                        {

                            respuesta = tae.QueryTae(taeC, SIFNegocio.Configuracion.Configuraciones.MultiRecargas);
                        }

                        taeC.Respuesta = respuesta;
                        if (string.IsNullOrEmpty(taeC.Referencia))
                        {
                            taeC.Referencia = "-1";
                        }

                        if (string.IsNullOrEmpty(taeC.RespuestaID))
                        {
                            taeC.RespuestaID = "-1";
                        }

                        tae.ActualizaTAE(taeC);
                    }
                }
            }
        }

        public SIF.MainForm Owner { get; set; }

        internal void Muestra()
        {
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;
            Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }

       


       
        private void Facturar()
        {

            

        }



        public void ActivaComandos()
        {
            this.buttonItem.Shortcuts.Add(eShortcut.F5);
            //this.cancelarButtonItem.Shortcuts.Add(eShortcut.F8);
            this.backButton.Shortcuts.Add(eShortcut.F12);
        }

        public void DesactivaCommandos()
        {
            this.buttonItem.Shortcuts.Clear();
            //this.cancelarButtonItem.Shortcuts.Clear();
            this.backButton.Shortcuts.Clear();
        }


        public bool Mostrado { get; set; }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

       

       
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Buscar();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
                this.Buscar();
            }
        }

        
       

        
        private void facturaButtonItem_Click(object sender, EventArgs e)
        {
            this.Facturar();
        }

        private void MuestraDireccionFiscal(SIFModelo.Cliente cliente)
        {
            Catalogos.DireccionClienteForm frmCliente = new Catalogos.DireccionClienteForm(cliente);
            if (frmCliente.ShowDialog() != DialogResult.OK)
            {
                return;
            }
        }


        private void buttonItem1_Click_1(object sender, EventArgs e)
        {
            SIF.View.Reportes.Venta.ConciliacionTAEForm frmConciliacion = new Reportes.Venta.ConciliacionTAEForm();
            frmConciliacion.ShowDialog();
        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }

            
        }
        public void AgregarCliente(SIFModelo.Cliente cliente)
        {
            ClienteTextBoxX.Tag = cliente.ID;
            ClienteTextBoxX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
            this.Buscar();
           // buscar();
        }
        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
        }
        View.Catalogos.ClienteControl frmCliente;
        private void SeleccionaCliente()
        {


            if (frmCliente == null)
            {
                frmCliente = new View.Catalogos.ClienteControl();
                frmCliente.Dock = DockStyle.Fill;
                frmCliente.Owner = this;
            }
            frmCliente.Muestra();


        }


        private void seleccionaClienteButtonItem_Click(object sender, EventArgs e)
        {
            this.SeleccionaCliente();
        }

        private void CodigoTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.SeleccionaCliente();
        }

        private void imprimeTicketButtonItem_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked)
            {
                
                foreach(GridElement Rows in superGridControl1.PrimaryGrid.Rows)
                {
                    if ((Rows is GridRow))
                    {
                        var row = (GridRow)Rows;
                        row.Cells[0].Value = true;
                    }
                }
            }
        }

        private void ClienteTextBoxX_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
