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
using System.Globalization;

namespace SIF.View.Ventas
{
    public partial class FacturasUserControl : Templates.ListaUserControl
    {

        string usuarioInvoca = "";
        public FacturasUserControl()
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
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 7, int.Parse(Xbtn.Tag.ToString()));
                usuarioInvoca = Helpers.Sesion.Usuario.UsuariosID.ToString();
            }

        }

        SIFNegocio.Remision remsionL = new SIFNegocio.Remision();

        private void Back()
        {
            try
            {
                if (this.Mostrado && Owner.Owner.IsModalPanelDisplayed)
                {
                    //this.DesactivaComandos();
                    try
                    {
                        if (Owner.Owner.Contains(this))
                        {
                            Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
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
            catch { }
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
            //switch (panel.DataMember)
            //{
            //    case "Customers":
            //        CustomizeCustomerPanel(panel);
            //        break;

            //    case "Orders":
            //        CustomizeOrdersPanel(panel);
            //        break;

            //    case "Order Details":
            //        CustomizeDetailsPanel(panel);
            //        break;
            //}
        }

        private void CustomizeDetailsPanel(GridPanel panel)
        {
            //panel.ColumnHeader.RowHeight = 30;

            //panel.Columns[0].CellStyles.Default.Background =
            //    new Background(Color.LavenderBlush);

            //panel.Columns["OrderID"].CellStyles.Default.Alignment = Alignment.MiddleLeft;

            //panel.DefaultVisualStyles.CaptionStyles.Default.Alignment = Alignment.MiddleLeft;
            //panel.DefaultVisualStyles.CellStyles.Default.Alignment = Alignment.MiddleRight;

            //UpdateDetailsFooter(panel);

            panel.AutoGenerateColumns = false;
            panel.Columns.Clear();

            GridColumn SucursalIDColumn = new GridColumn("SucursalIDColumn");
            SucursalIDColumn.HeaderText = "SUCURSAL_ID";
            SucursalIDColumn.DataPropertyName = "SUCURSAL_ID";
            SucursalIDColumn.Width = 70;
            SucursalIDColumn.Visible = false;
            panel.Columns.Add(SucursalIDColumn);

            GridColumn NumRemisionColumn = new GridColumn("NumRemisionColumn");
            NumRemisionColumn.HeaderText = "REMISION";
            NumRemisionColumn.DataPropertyName = "NUM_REMISION";
            NumRemisionColumn.Width = 100;
            NumRemisionColumn.Visible = false;
            panel.Columns.Add(NumRemisionColumn);

            GridColumn NumeroPartidaColumn = new GridColumn("NumeroPartidaColumn");
            NumeroPartidaColumn.HeaderText = "PARTIDA";
            NumeroPartidaColumn.DataPropertyName = "NUM_PARTIDA";
            NumeroPartidaColumn.Width = 100;
            panel.Columns.Add(NumeroPartidaColumn);

            GridColumn ArticuloColumn = new GridColumn("ArticuloColumn");
            ArticuloColumn.HeaderText = "CLAVE";
            ArticuloColumn.DataPropertyName = "ARTICULO_ID";
            ArticuloColumn.Width = 100;
            panel.Columns.Add(ArticuloColumn);

            GridColumn Nombre1Column = new GridColumn("Nombre1Column");
            Nombre1Column.HeaderText = "NOMBRE";
            Nombre1Column.DataPropertyName = "NOMBRE1";
            Nombre1Column.Width = 200;
            panel.Columns.Add(Nombre1Column);

            GridColumn Nombre2Column = new GridColumn("*Nombre2Column");
            Nombre2Column.HeaderText = "NOMBRE";
            Nombre2Column.DataPropertyName = "NOMBRE2";
            Nombre2Column.Width = 200;
            panel.Columns.Add(Nombre2Column);

            GridColumn FechaEntregaColumn = new GridColumn("FechaEntregaColumn");
            FechaEntregaColumn.HeaderText = "FECHA ENTREGA";
            FechaEntregaColumn.DataPropertyName = "FECHAENT";
            FechaEntregaColumn.Width = 100;
            panel.Columns.Add(FechaEntregaColumn);

            GridColumn CantidadRemisionColumn = new GridColumn("CantidadRemisionColumn");
            CantidadRemisionColumn.HeaderText = "CANTIDAD";
            CantidadRemisionColumn.DataPropertyName = "CANT_REMISION";
            CantidadRemisionColumn.Width = 80;
            panel.Columns.Add(CantidadRemisionColumn);

            GridColumn PrecioColumn = new GridColumn("PrecioColumn");
            PrecioColumn.HeaderText = "PRECIO";
            PrecioColumn.DataPropertyName = "PRECIO";
            PrecioColumn.Width = 100;
            panel.Columns.Add(PrecioColumn);

            GridColumn IVAColumn = new GridColumn("IVAColumn");
            IVAColumn.HeaderText = "IVA";
            IVAColumn.DataPropertyName = "IVA";
            IVAColumn.Width = 70;
            panel.Columns.Add(IVAColumn);

            GridColumn FolioControladoColumn = new GridColumn("FolioControladoColumn");
            FolioControladoColumn.HeaderText = "FOLIO CONTROLADO";
            FolioControladoColumn.DataPropertyName = "FOLIO_CONTROLADO";
            FolioControladoColumn.Width = 120;
            panel.Columns.Add(FolioControladoColumn);

            GridColumn LoteColumn = new GridColumn("LoteColumn");
            LoteColumn.HeaderText = "LOTE";
            LoteColumn.DataPropertyName = "LOTE";
            LoteColumn.Width = 100;
            panel.Columns.Add(LoteColumn);

            GridColumn CaducidadColumn = new GridColumn("CaducidadColumn");
            CaducidadColumn.HeaderText = "CADUCIDAD";
            CaducidadColumn.DataPropertyName = "CADUCIDAD";
            CaducidadColumn.Width = 100;
            panel.Columns.Add(CaducidadColumn);
        }

        DataSet DsRemisiones;

        private void Buscar()
        {
            //SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { SucursalID = SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID };
            SIFModelo.Remision remision = new SIFModelo.Remision();
            remision.NumeroRemision = this.buscarTextBoxX.Text;
            DsRemisiones = remsionL.BuscaRemisionesFacturadas(Helpers.Sesion.Sucursal, remision);

            DsRemisiones.Relations.Add("1", DsRemisiones.Tables["Remisiones"].Columns["NUM_REMISION"],
                                           DsRemisiones.Tables["RemisionDetalles"].Columns["NUM_REMISION"], false);

            //this.bindingSource.DataSource = DsRemisiones;
            this.superGridControl1.PrimaryGrid.DataSource = DsRemisiones;
            //superGridControl1.PrimaryGrid.AutoGenerateColumnsd = true;
            superGridControl1.PrimaryGrid.DataMember = "Remisiones";

            this.totalesFlowLayoutPanel.Controls.Clear();
        }

        private void facturaGlobal()
        {
            Ventas.FechasFacturaGlobalForm frmFechas = new FechasFacturaGlobalForm();
            if (frmFechas.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            DateTime fecha1 = frmFechas.dateTimeInput1.Value;
            DateTime fecha2 = frmFechas.dateTimeInput2.Value;


            //SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { SucursalID = SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID };
            SIFModelo.Remision remision = new SIFModelo.Remision();
            remision.NumeroRemision = this.buscarTextBoxX.Text;
            String[] facturadas = new String[5];
            Double aFacturar;
            facturadas = remsionL.BuscaRemisionesSiFacturadas(Helpers.Sesion.Sucursal, fecha1, fecha2);
            /*
             * total, "+
              "SUM(impuesto_iva) iva, "+
              "SUM(CASE WHEN LENGTH(num_factura) >= 36 THEN importe_total ELSE 0 END) total_fact, "+
              "SUM(CASE WHEN LENGTH(num_factura) >= 36 THEN impuesto_iva  ELSE 0 END) iva_fact, "+
              "SUM(CASE WHEN LENGTH(num_factura) <  36 THEN importe_total ELSE 0 END) total_sinfact, "+
              "SUM(CASE WHEN LENGTH(num_factura) <  36 THEN impuesto_iva  ELSE 0 END) iva_sinfact "+  
             * */
            aFacturar = Convert.ToDouble(facturadas[1]) - Convert.ToDouble(facturadas[2]);
            this.label2.Text = "$"+String.Format(CultureInfo.InvariantCulture, 
                                 "{0:0,0}",facturadas[2]);
            this.label4.Text = "$"+String.Format(CultureInfo.InvariantCulture, 
                                 "{0:0,0}",facturadas[5]);
            DsRemisiones = remsionL.BuscaRemisionesNoFacturadas(Helpers.Sesion.Sucursal, fecha1, fecha2);

            DsRemisiones.Relations.Add("1", DsRemisiones.Tables["Remisiones"].Columns["NUM_REMISION"],
                                           DsRemisiones.Tables["RemisionDetalles"].Columns["NUM_REMISION"], false);

            //this.bindingSource.DataSource = DsRemisiones;
            this.superGridControl1.PrimaryGrid.DataSource = DsRemisiones;
            //superGridControl1.PrimaryGrid.AutoGenerateColumns = true;
            superGridControl1.PrimaryGrid.DataMember = "Remisiones";

            var vtotalRemisiones = DsRemisiones.Tables["Remisiones"].Compute("SUM(IMPORTE_TOTAL)", "");
            decimal totalRemisiones = 0;
            if (vtotalRemisiones.ToString().IsFloatPositive())
            {
                totalRemisiones = decimal.Parse(vtotalRemisiones.ToString());
            }

            var vtotalImpuesto = DsRemisiones.Tables["Remisiones"].Compute("SUM(IMPORTE_TOTAL)", "impuesto_iva > 0");
            var vtotalExento = DsRemisiones.Tables["Remisiones"].Compute("SUM(IMPORTE_TOTAL)", "impuesto_iva = 0");
            var vimpuesto = DsRemisiones.Tables["Remisiones"].Compute("SUM(impuesto_iva)", "impuesto_iva > 0");

            decimal totalImpuesto = 0;
            if (vtotalImpuesto.ToString().IsFloat())
                totalImpuesto = decimal.Parse(vtotalImpuesto.ToString());

            decimal totalExento = 0;
            if (vtotalExento.ToString().IsFloat())
                totalExento = decimal.Parse(vtotalExento.ToString());


            decimal impuesto = 0;
            if (vimpuesto.ToString().ToString().IsFloat())
                impuesto = decimal.Parse(vimpuesto.ToString());

            remision.Total = totalRemisiones;
            remision.SubTotal = totalExento + (totalImpuesto - impuesto);

            SIFNegocio.Impuestos impuestosL = new SIFNegocio.Impuestos();
            impuestosL.Buscar("Activo", "S");
            List<SIFModelo.Impuesto> impuestos = (List<SIFModelo.Impuesto>)impuestosL.CatImpuestosList.DataSource;


            this.totalLabelX.Text = remision.Total.ToString("C2");
            remision.SubTotal = remision.Total - impuesto;
            remision.Impuesto = impuesto;
            remision.MonedaID = 1;

            //DETALLES
            remision.Detalles = new List<SIFModelo.RemisionDetalle>();
            foreach (var imp in impuestos)
            {
                SIFModelo.RemisionDetalle detalleRemision = new SIFModelo.RemisionDetalle();
                detalleRemision.Nombre1 = "GRAVADOS AL %" + imp.Porcentaje.ToString();
                detalleRemision.CantidadRemision = 1;

                if (imp.Porcentaje > 0)
                {
                    detalleRemision.Total = totalImpuesto - impuesto;
                    detalleRemision.IVA = impuesto;
                }
                else
                {
                    detalleRemision.Total = totalExento;
                    detalleRemision.IVA = 0;
                }

                detalleRemision.ArticuloID = "";
                detalleRemision.ImpuestoID = imp.ID;

                remision.Detalles.Add(detalleRemision);
            }

            totalesFlowLayoutPanel.Controls.Clear();
            foreach (SIFModelo.RemisionDetalle detalle in remision.Detalles)
            {
                LabelX label = new LabelX();

                label.ForeColor = totalLabelX.ForeColor;
                label.BackColor = totalLabelX.BackColor;
                //label.Font = totalLabelX.Font;
                label.AutoSize = true;
                label.Text = detalle.Nombre1;

                LabelX label2 = new LabelX();
                label2.ForeColor = totalLabelX.ForeColor;
                label2.BackColor = totalLabelX.BackColor;
                label2.Font = totalLabelX.Font;
                label2.AutoSize = true;
                label2.Text = (detalle.Total + detalle.IVA).ToString("C2");
                
                this.totalesFlowLayoutPanel.Controls.Add(label);
                this.totalesFlowLayoutPanel.Controls.Add(label2);
            }





            if (MessageBoxEx.Show("¿Desea realizar la factura global comprendida desde " + fecha1.ToShortDateString() + " hasta " + fecha2.ToShortDateString() + "?", "Factura Global", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            SIFModelo.Cliente cliente = new SIFModelo.Cliente();
            cliente = new SIFNegocio.Clientes().ClientePorID(0);

            //if (cliente == null)
            //{
            //CREAR EL CLIENTE GENERICO
            cliente = new SIFModelo.Cliente();
            cliente.Nombre = "PUBLICO EN GENERAL";
            cliente.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
            //}

            SIFModelo.DireccionCliente dirCliente = new SIFModelo.DireccionCliente();
            //dirCliente = new SIFNegocio.Clientes().DireccionCliente(cliente);
            //if (dirCliente == null)
            //{
            dirCliente = new SIFModelo.DireccionCliente();
            dirCliente.RFC = "XAXX010101000";
            dirCliente.Calle = "13 SUR";
            dirCliente.CodigoPostal = "72410";
            dirCliente.Ciudad = "PUEBLA";
            dirCliente.Municipio = "PUEBLA";
            dirCliente.Telefono = "-";
            dirCliente.Email = "";
            dirCliente.NumeroExterior = "2701";
            dirCliente.NumeroInterior = "-";
            dirCliente.Colonia = "VOLCANES";
            //}
            remision.ImporteLetra = sif_tools.NumberToLetters.NumToLetter((double)remision.Total, "Decimal");
            remision.NumeroRemision = fecha1.ToString("ddMMyyyy") + "-" + fecha1.ToString("ddMMyyyy");
            SIFNegocio.WebServices.FEL wsFel = new SIFNegocio.WebServices.FEL();
            bool generada = wsFel.Invocar(SIFNegocio.Configuracion.Configuraciones.Factura, SIFNegocio.Configuracion.Configuraciones.Aplicacion, cliente, remision, Helpers.Sesion.Sucursal, dirCliente, true);

            if (generada)
            {
                SIFNegocio.Remision remisionL = new SIFNegocio.Remision();
                List<SIFModelo.Remision> remisionFacturar = new List<SIFModelo.Remision>();
                foreach (DataRow row in DsRemisiones.Tables["Remisiones"].Rows)
                {
                    SIFModelo.Remision r = new SIFModelo.Remision();

                    r.NumeroRemision = row["NUM_REMISION"].ToString();
                    r.Factura = SIFModelo.Tipos.SiNo.SI;
                    r.NumeroFactura = remision.NumeroFactura;

                    remisionFacturar.Add(r);
                }

                remisionL.ActualizaRemisionesFactura(remisionFacturar, remision.NumeroFactura);

               MessageBox.Show("Se ha creado la factura para " + remisionFacturar.Count + " remisiones");
            }
            else
            {
               MessageBox.Show("Ha ocurrido un error al generar la factura " + DsRemisiones.Tables["Remisiones"].Rows.Count + " remisiones", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarGlobal(DateTime fecha1, DateTime fecha2)
        {
            //SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { SucursalID = SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID };
            SIFModelo.Remision remision = new SIFModelo.Remision();
            remision.NumeroRemision = this.buscarTextBoxX.Text;
            DsRemisiones = remsionL.BuscaRemisionesNoFacturadas(Helpers.Sesion.Sucursal, fecha1, fecha2);

            DsRemisiones.Relations.Add("1", DsRemisiones.Tables["Remisiones"].Columns["NUM_REMISION"],
                                           DsRemisiones.Tables["RemisionDetalles"].Columns["NUM_REMISION"], false);

            //this.bindingSource.DataSource = DsRemisiones;
            this.superGridControl1.PrimaryGrid.DataSource = DsRemisiones;
            //superGridControl1.PrimaryGrid.AutoGenerateColumns = true;
            superGridControl1.PrimaryGrid.DataMember = "Remisiones";

            var totalRemisiones = DsRemisiones.Tables["Remisiones"].Compute("SUM(IMPORTE)", "");
            if (totalRemisiones.ToString().IsFloatPositive())
            {
                this.totalLabelX.Text = "TOTAL: " + decimal.Parse(totalRemisiones.ToString()).ToString("C2");
            }
            else
            {
                this.totalLabelX.Text = "TOTAL: $0.00";
            }

        }

        private SIFModelo.Remision SelectedRemision()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;

            if (panel.ActiveRow == null)
            {
                return null;
            }

            var container = ((GridContainer)panel.ActiveRow);

            if (!(container is GridRow))
            {
               MessageBox.Show("Debe seleccionar la fila de la remisión");
                return null;
            }

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
            var fechaPago = datarow["FECHA_PAGO"];
            if (fechaPago.ToString().IsDatetime())
            {
                remision.FechaPago = DateTime.Parse(datarow["FECHA_PAGO"].ToString());
            }
            remision.VendedorID = int.Parse(datarow["VENDEDOR_ID"].ToString());
            remision.MonedaID = int.Parse(datarow["MONEDA_ID"].ToString());
            remision.TipoCambio = int.Parse(datarow["TIPO_CAMBIO_ID"].ToString());
            remision.Condiciones = (datarow["CONDICIONES"].ToString());
            remision.SubTotal = decimal.Parse(datarow["SUBTOTAL"].ToString());

            if (datarow["IMPUESTO_IVA"].ToString().IsFloatPositive())
            {
                remision.Impuesto = decimal.Parse(datarow["IMPUESTO_IVA"].ToString());
            }
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

        SIFNegocio.Remision logica = new SIFNegocio.Remision();

        

        private void VentasPagoUserControl_Load(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Focus();
            //this.Buscar();
        }

        public Menu.VentasMenu Owner { get; set; }

        internal void Muestra()
        {
            if (Mostrado)
            {
                return;
            }

            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;
            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }

        private void Cancelar()
        {
            SIFModelo.Remision remision = this.SelectedRemision();
            if (remision == null)
            {
               MessageBox.Show("Elija la remision a cancelar");
                return;
            }

            if (remision.Activo == SIFModelo.Tipos.StatusVenta.PAGADA)
            {
               MessageBox.Show("La remision " + remision.NumeroRemision + " ha sido pagada, para cancelarla debe realizar su devolución", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (remision.Activo == SIFModelo.Tipos.StatusVenta.CANCELADA)
            {
               MessageBox.Show("La remision " + remision.NumeroRemision + " ya fue cancelada anteriormente", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult res =MessageBox.Show("¿Cancelar la remisión " + remision.NumeroRemision + "?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res != DialogResult.Yes)
            {
                return;
            }

            DatosDerechohabiente motivo = new DatosDerechohabiente();
            motivo.ShowDialog();

            //remision.
            //RESTAMOS EL IVA
            List<SIFModelo.Impuesto> impuestos = (List<SIFModelo.Impuesto>)new SIFNegocio.Impuestos().Buscar("", "").DataSource;
            List<SIFModelo.Descuento> descuentos = (List<SIFModelo.Descuento>)new SIFNegocio.Descuentos().Buscar("", "").DataSource;
            remision.SubTotal = 0;
            remision.Detalles = new SIFNegocio.Remision().CargaRemisionDetalles(remision);
            remision.Descuento = 0;
            foreach (var detalleRemision in remision.Detalles)
            {
                var VimpuestoAsignado = from i in impuestos where i.ID == detalleRemision.ImpuestoID select i;
                SIFModelo.Impuesto impuestoAsignado = VimpuestoAsignado.FirstOrDefault();

                detalleRemision.Precio = detalleRemision.Precio / (1 + (impuestoAsignado.Porcentaje / 100m));

                detalleRemision.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalleRemision.Precio) * detalleRemision.CantidadRemision;

                var vDescuentoAsignado = from d in descuentos where d.ID == detalleRemision.DescuentoID select d;
                SIFModelo.Descuento descuentoAsignado = vDescuentoAsignado.FirstOrDefault();

                //DESCUENTO SIN IVA
                if (descuentoAsignado != null)
                {
                    detalleRemision.MontoDescuento = detalleRemision.Total * (descuentoAsignado.Porcentaje / 100);
                    remision.Descuento += detalleRemision.MontoDescuento;
                }
                else
                {
                    detalleRemision.MontoDescuento = 0;
                }

                remision.SubTotal += detalleRemision.Total;
            }
            //


            if (new SIFNegocio.Remision().Cancela(remision, Helpers.Sesion.Usuario.UsuariosID, Helpers.Sesion.Usuario.Nombre))
            {
                SIFNegocio.WebServices.FEL wsFel = new SIFNegocio.WebServices.FEL();
                //wsFel.Cancelar(remision, SIFNegocio.Configuracion.Configuraciones.Factura);

                //EN EL DATAGRID PONER COMO CANCELADO
                GridPanel grid = superGridControl1.PrimaryGrid;
                grid.Rows.Remove(grid.ActiveRow);

                //INSERTAMOS EN CANCELACIONES
                //SIFNegocio.CANCE


                //CANCELAR EN NADRO PFIZER
            }
            else
            {
               MessageBox.Show("No se consiguió cancelar la remisión");
            }
        }

        public void FacturaBulk()
        {
            SIFModelo.Remision remision = this.SelectedRemision();
            if (remision == null)
            {
               MessageBox.Show("Elija la remision a cancelar");
                return;
            }
            if (remision.Activo == SIFModelo.Tipos.StatusVenta.CANCELADA)
            {
               MessageBox.Show("NO se puede Facturar una remisión cancelada");
                return;
            }
            string factur=remision.Factura.ToString();
            bool result = factur.Equals("G", StringComparison.CurrentCultureIgnoreCase);
            if (result)
            {
               MessageBox.Show("NO se puede Facturar una remisión incluida en la Factura Global");
                return;

            }
            if (remision.Activo == SIFModelo.Tipos.StatusVenta.DEVUELTA)
            {
               MessageBox.Show("NO se puede Facturar una remisión devuelta");
                return;
            }
            if (!string.IsNullOrEmpty(remision.NumeroFactura) && remision.NumeroFactura != "S" && remision.NumeroFactura != "N")
            {
                var res =MessageBox.Show("La remisión " + remision.NumeroRemision + " ya está asociada a la factura " + remision.NumeroFactura + ". ¿Desea refacturarla? ", "Refactuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                    return;
            }

            if (remision.Activo != SIFModelo.Tipos.StatusVenta.PAGADA && remision.Activo != SIFModelo.Tipos.StatusVenta.DEVUELTA)
            {
                if (remision.Activo != SIFModelo.Tipos.StatusVenta.CANCELADA)
                {
                   MessageBox.Show("La remision " + remision.NumeroRemision + " no ha sido pagada", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            //if (remision.Activo == SIFModelo.Tipos.StatusVenta.CANCELADA)
            //{
            //   MessageBox.Show("La remision " + remision.NumeroRemision + " ya fue cancelada anteriormente", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            SIFNegocio.WebServices.FEL wsFel = new SIFNegocio.WebServices.FEL();

            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(remision.ClienteID);
            SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal();
            sucursal = new SIFNegocio.Sucursales().SucursalPorID(remision.SucursalID);
            //sucursal = new SIFNegocio.Sucursales().Buscar("","");
            SIFModelo.DireccionCliente dirFiscal = new SIFModelo.DireccionCliente();
            dirFiscal = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);

            View.Catalogos.DireccionClienteForm frmCliente = new Catalogos.DireccionClienteForm(cliente);
            if (frmCliente.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //QUITAR EL IVA DE TODOS LOS DETALLES
            //RESTAMOS EL IVA
           // remision.SubTotal = 0;

            //remision.Descuento = 0;

            
            wsFel.numeroU(usuarioInvoca);
          
            if (wsFel.Invocar(SIFNegocio.Configuracion.Configuraciones.Factura, SIFNegocio.Configuracion.Configuraciones.Aplicacion, cliente, remision, sucursal))
            {
               MessageBox.Show("Se ha creado la factura de la remision " + remision.NumeroRemision);
                GridPanel grid = superGridControl1.PrimaryGrid;
                grid.Rows.Remove(grid.ActiveRow);
            }
            else
            {
               MessageBox.Show("Ha ocurrido un error al crear la factura", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Catalogos.DireccionClienteForm frmClienteDir = new Catalogos.DireccionClienteForm(cliente);
                if (frmClienteDir.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                this.Buscar();
                return;
            }

        }




        private void nuevaFactura()
        {
            SIFModelo.Remision remision = this.SelectedRemision();
            if (remision == null)
            {
               MessageBox.Show("Elija la remision a cancelar");
                return;
            }

            if (!string.IsNullOrEmpty(remision.NumeroFactura) && remision.NumeroFactura != "S" && remision.NumeroFactura != "N")
            {
                var res =MessageBox.Show("La remisión " + remision.NumeroRemision + " ya está asociada a la factura " + remision.NumeroFactura + ". ¿Desea refacturarla? ", "Refactuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                    return;
            }

            if (remision.Activo != SIFModelo.Tipos.StatusVenta.PAGADA && remision.Activo != SIFModelo.Tipos.StatusVenta.DEVUELTA)
            {
               MessageBox.Show("La remision " + remision.NumeroRemision + " no ha sido pagada", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (remision.Activo == SIFModelo.Tipos.StatusVenta.CANCELADA)
            {
               MessageBox.Show("La remision " + remision.NumeroRemision + " ya fue cancelada anteriormente", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SIFNegocio.WebServices.FEL wsFel = new SIFNegocio.WebServices.FEL();

            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(remision.ClienteID);
            SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal();
            sucursal = new SIFNegocio.Sucursales().SucursalPorID(remision.SucursalID);
            //sucursal = new SIFNegocio.Sucursales().Buscar("","");
            SIFModelo.DireccionCliente dirFiscal = new SIFModelo.DireccionCliente();
            dirFiscal = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);

            View.Catalogos.DireccionClienteForm frmCliente = new Catalogos.DireccionClienteForm(cliente);
            if (frmCliente.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //QUITAR EL IVA DE TODOS LOS DETALLES
            //RESTAMOS EL IVA
            List<SIFModelo.Impuesto> impuestos = (List<SIFModelo.Impuesto>)new SIFNegocio.Impuestos().Buscar("", "").DataSource;
            List<SIFModelo.Descuento> descuentos = (List<SIFModelo.Descuento>)new SIFNegocio.Descuentos().Buscar("", "").DataSource;
            remision.SubTotal = 0;
            remision.Detalles = new SIFNegocio.Remision().CargaRemisionDetalles(remision);
            decimal DescuentoAnterior = remision.Descuento;
            remision.Descuento = 0;
            foreach (var detalleRemision in remision.Detalles)
            {
                var VimpuestoAsignado = from i in impuestos where i.ID == detalleRemision.ImpuestoID select i;
                SIFModelo.Impuesto impuestoAsignado = VimpuestoAsignado.FirstOrDefault();

                detalleRemision.Precio = detalleRemision.Precio / (1 + (impuestoAsignado.Porcentaje / 100m));

                detalleRemision.Total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalleRemision.Precio) * detalleRemision.CantidadRemision;

                var vDescuentoAsignado = from d in descuentos where d.ID == detalleRemision.DescuentoID select d;
                SIFModelo.Descuento descuentoAsignado = vDescuentoAsignado.FirstOrDefault();

                //DESCUENTO SIN IVA
                if (descuentoAsignado != null)
                {
                    detalleRemision.MontoDescuento = (detalleRemision.Total * (descuentoAsignado.Porcentaje / 100)/(impuestoAsignado.Porcentaje/100)+1);
                    remision.Descuento += detalleRemision.MontoDescuento;
                }
                else
                {
                    detalleRemision.MontoDescuento = 0;
                }

                remision.SubTotal += detalleRemision.Total;
            }
            //
            if (remision.Descuento == 0 && DescuentoAnterior > 0)
            {
                remision.Descuento = DescuentoAnterior;
            }

            if (wsFel.Invocar(SIFNegocio.Configuracion.Configuraciones.Factura, SIFNegocio.Configuracion.Configuraciones.Aplicacion, cliente, remision, sucursal))
            {
               MessageBox.Show("Se ha creado la factura de la remision " + remision.NumeroRemision);
                GridPanel grid = superGridControl1.PrimaryGrid;
                grid.Rows.Remove(grid.ActiveRow);
            }
            else
            {
               MessageBox.Show("Ha ocurrido un error al crear la factura", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Catalogos.DireccionClienteForm frmClienteDir = new Catalogos.DireccionClienteForm(cliente);
                if (frmClienteDir.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                this.Buscar();
                return;
            }


        }

        private void facturaRemisionesDia()
        {
            Ventas.FechasFacturaGlobalForm frmFechas = new FechasFacturaGlobalForm();
            if (frmFechas.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            DateTime fecha1 = frmFechas.dateTimeInput1.Value;
            DateTime fecha2 = frmFechas.dateTimeInput2.Value;

            this.BuscarGlobal(fecha1, fecha2);
            //return;
            bool facturar = false;

            SIFModelo.Remision remision = new SIFNegocio.Remision().FacturarRemisionesNoFacturadasTotalRemision(Helpers.Sesion.Sucursal, fecha1, fecha2, facturar);

            if (remision == null)
            {
                return;
            }

            totalesFlowLayoutPanel.Controls.Clear();
            foreach (SIFModelo.RemisionDetalle detalle in remision.Detalles)
            {
                LabelX label = new LabelX();

                label.ForeColor = totalLabelX.ForeColor;
                label.BackColor = totalLabelX.BackColor;
                //label.Font = totalLabelX.Font;
                label.AutoSize = true;
                label.Text = detalle.Nombre1;

                LabelX label2 = new LabelX();
                label2.ForeColor = totalLabelX.ForeColor;
                label2.BackColor = totalLabelX.BackColor;
                label2.Font = totalLabelX.Font;
                label2.AutoSize = true;
                label2.Text = detalle.Total.ToString("C2");

                this.totalesFlowLayoutPanel.Controls.Add(label);
                this.totalesFlowLayoutPanel.Controls.Add(label2);
            }


            DialogResult res =MessageBox.Show("¿Crear la factura de todas las remisiones encontradas?", "Facturar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            facturar = true;
            if (res == DialogResult.No)
            {
                facturar = false;
            }

            new SIFNegocio.Remision().FacturarRemisionesNoFacturadas(Helpers.Sesion.Sucursal, fecha1, fecha2, facturar);

        }


        private void ActivaComandos()
        {
            cancelarButtonItem.Shortcuts.Add(eShortcut.F8);
            this.backButton.Shortcuts.Add(eShortcut.F12);
        }

        private void DesactivaCommandos()
        {
            cancelarButtonItem.Shortcuts.Clear();
            this.backButton.Shortcuts.Clear();
        }

        public bool Mostrado { get; set; }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }


        private void cancelarButtonItem_Click(object sender, EventArgs e)
        {
            this.Cancelar();
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



        private void cancelacionAutomaticaBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            new SIFNegocio.Remision().CancelaPedidosyApartados24HRS(Helpers.Sesion.Sucursal);
        }

        private void cancelacionAutomaticaBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           MessageBox.Show("Se han cancelado todas las remisiones sin completar anteriores a 24 horas");
        }

        private void facturarRemisionesDiaButtonItem_Click(object sender, EventArgs e)
        {
            //facturaRemisionesDia();
            facturaGlobal();
        }

        private void NuevoButtonItem_Click(object sender, EventArgs e)
        {
            FacturaBulk();
        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }
        }

        private void vistaPreviaButtonItem_Click(object sender, EventArgs e)
        {
            SIFModelo.Remision remision = this.SelectedRemision();
            if (remision == null)
            {
               MessageBox.Show("Elija la remision a cancelar");
                return;
            }

            FacturaVistaPreviaForm frmFactura = new FacturaVistaPreviaForm(remision);
            frmFactura.ShowDialog();
        }

        private void porReferenciaButtonItem_Click(object sender, EventArgs e)
        {
            SIFModelo.Remision remision = this.SelectedRemision();
            if (remision == null)
            {
               MessageBox.Show("Debe seleccionar una remision");
            }

            SIFNegocio.WebServices.FEL wsF = new SIFNegocio.WebServices.FEL();
            if (wsF.FacturaPorReferencia(remision, SIFNegocio.Configuracion.Configuraciones.Factura))
            {
               MessageBox.Show("Se ha descargado la factura correctamente");
            }
        }


    }
}
