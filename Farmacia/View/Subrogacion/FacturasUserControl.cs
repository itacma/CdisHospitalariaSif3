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
using System.IO;
using System.Text.RegularExpressions;

namespace SIF.View.Subrogacion
{
    public partial class FacturasUserControl : Templates.ListaUserControl
    {
        public FacturasUserControl()
        {
            InitializeComponent();
            this.inicializaTabla();
            Privilegios();
        }
        SIFModelo.Cliente _cliente = new SIFModelo.Cliente();//PARA LA FACTURACION DE COMERCIALIZACION
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 86, int.Parse(Xbtn.Tag.ToString()));
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
            SucursalIDColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            SucursalIDColumn.HeaderText = "SUCURSAL_ID";
            SucursalIDColumn.DataPropertyName = "SUCURSAL_ID";
            SucursalIDColumn.Width = 70;
            SucursalIDColumn.Visible = false;
            panel.Columns.Add(SucursalIDColumn);

            GridColumn NumRemisionColumn = new GridColumn("NumRemisionColumn");
            NumRemisionColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            NumRemisionColumn.HeaderText = "REMISION";
            NumRemisionColumn.DataPropertyName = "NUM_REMISION";
            NumRemisionColumn.Width = 100;
            NumRemisionColumn.Visible = false;
            panel.Columns.Add(NumRemisionColumn);

            GridColumn NumeroPartidaColumn = new GridColumn("NumeroPartidaColumn");
            NumeroPartidaColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            NumeroPartidaColumn.HeaderText = "PARTIDA";
            NumeroPartidaColumn.DataPropertyName = "NUM_PARTIDA";
            NumeroPartidaColumn.Width = 100;
            panel.Columns.Add(NumeroPartidaColumn);

            GridColumn ArticuloColumn = new GridColumn("ArticuloColumn");
            ArticuloColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            ArticuloColumn.HeaderText = "CLAVE";
            ArticuloColumn.DataPropertyName = "ARTICULO_ID";
            ArticuloColumn.Width = 100;
            panel.Columns.Add(ArticuloColumn);

            GridColumn Nombre1Column = new GridColumn("Nombre1Column");
            Nombre1Column.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            Nombre1Column.HeaderText = "NOMBRE";
            Nombre1Column.DataPropertyName = "NOMBRE1";
            Nombre1Column.Width = 200;
            panel.Columns.Add(Nombre1Column);

            GridColumn Nombre2Column = new GridColumn("*Nombre2Column");
            Nombre2Column.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            Nombre2Column.HeaderText = "NOMBRE";
            Nombre2Column.DataPropertyName = "NOMBRE2";
            Nombre2Column.Width = 200;
            panel.Columns.Add(Nombre2Column);

            GridColumn FechaEntregaColumn = new GridColumn("FechaEntregaColumn");
            FechaEntregaColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            FechaEntregaColumn.HeaderText = "FECHA ENTREGA";
            FechaEntregaColumn.DataPropertyName = "FECHAENT";
            FechaEntregaColumn.Width = 100;
            panel.Columns.Add(FechaEntregaColumn);

            GridColumn CantidadRemisionColumn = new GridColumn("CantidadRemisionColumn");
            CantidadRemisionColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            CantidadRemisionColumn.HeaderText = "CANTIDAD";
            CantidadRemisionColumn.DataPropertyName = "CANT_REMISION";
            CantidadRemisionColumn.Width = 80;
            panel.Columns.Add(CantidadRemisionColumn);

            GridColumn PrecioColumn = new GridColumn("PrecioColumn");
            PrecioColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            PrecioColumn.HeaderText = "PRECIO";
            PrecioColumn.DataPropertyName = "PRECIO";
            PrecioColumn.Width = 100;
            panel.Columns.Add(PrecioColumn);

            GridColumn IVAColumn = new GridColumn("IVAColumn");
            IVAColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            IVAColumn.HeaderText = "IVA";
            IVAColumn.DataPropertyName = "IVA";
            IVAColumn.Width = 70;
            panel.Columns.Add(IVAColumn);

            GridColumn FolioControladoColumn = new GridColumn("FolioControladoColumn");
            FolioControladoColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            FolioControladoColumn.HeaderText = "FOLIO CONTROLADO";
            FolioControladoColumn.DataPropertyName = "FOLIO_CONTROLADO";
            FolioControladoColumn.Width = 120;
            panel.Columns.Add(FolioControladoColumn);

            GridColumn LoteColumn = new GridColumn("LoteColumn");
            LoteColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            LoteColumn.HeaderText = "LOTE";
            LoteColumn.DataPropertyName = "LOTE";
            LoteColumn.Width = 100;
            panel.Columns.Add(LoteColumn);

            GridColumn CaducidadColumn = new GridColumn("CaducidadColumn");
            CaducidadColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            CaducidadColumn.HeaderText = "CADUCIDAD";
            CaducidadColumn.DataPropertyName = "CADUCIDAD";
            CaducidadColumn.Width = 100;
            panel.Columns.Add(CaducidadColumn);
        }

        DataSet DsRemisiones;

        private void Buscar()
        {
            if (ClienteTextBoxX.Tag != null)
            {
                SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { SucursalesID = SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID };
                SIFModelo.Remision remision = new SIFModelo.Remision();
                remision.NumeroRemision = this.buscarTextBoxX.Text;
                
                DsRemisiones = remsionL.BuscaRemisionesNoPagadas(sucursal, remision, dateTimeInput1.Value, dateTimeInput2.Value, "P", ClienteTextBoxX.Tag.ToString(),radioButton1.Checked);

                //DsRemisiones.Relations.Add("1", DsRemisiones.Tables["Remisiones"].Columns["NUM_REMISION"],
                //                               DsRemisiones.Tables["RemisionDetalles"].Columns["NUM_REMISION"], false);

                //this.bindingSource.DataSource = DsRemisiones;
               

                this.superGridControl1.PrimaryGrid.DataSource = DsRemisiones;
                //superGridControl1.PrimaryGrid.AutoGenerateColumns = true;
                superGridControl1.PrimaryGrid.DataMember = "Remisiones";

                checkBoxX1.Checked = false;
            }
            else
            {
               MessageBox.Show("Debe seleccionar un cliente.");
            }
        }

        private void buscarISSTEP()
        {
            //SIFModelo.SubRogacion.Sobrogacion fSubDS = new SIFModelo.SubRogacion.Sobrogacion();
            //SIFModelo.ClienteSubrogaccion sub = new SIFNegocio.ClienteSubrogacion().ClientePorID(System.Convert.ToInt32(cliente.ID));
            //this.GetFacturasNumber(fSubDS, "", "", "", "", false, false, 1, 999999, anexo, tipo, sub, fechaInicio, fechaFin);
        
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







        public int CajaId;
        public int UsuarioId;
        private void VentasPagoUserControl_Load(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Focus();


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
        String Remisiones = "";
        private void ObtenRemisiones()
        {
            Remisiones = "";
            GridPanel Grid = superGridControl1.PrimaryGrid;
            int numRow = 1;
            foreach (GridElement Rows in Grid.Rows)//REVISA TODOS LSO ELEMENTOS DEL GRID SIN IMPORTAR SI ESTÁ PALOMEADO O NO
            {
                if ((Rows is GridRow))
                {
                    var row = (GridRow)Rows;
                    if (row.Cells[0].Value != null)
                        if (bool.Parse(row.Cells[0].Value.ToString()) == true)
                        {

                            if ((numRow % 50) == 0)
                            {
                                Remisiones += ") OR REMISION_DET.NUM_REMISION IN ('" + row.Cells[1].Value.ToString() + "'";
                                numRow++;
                                continue;
                            }

                            //jalamos el detalle de la remision
                            numRow++;
                            Remisiones = Remisiones + ",'" + row.Cells[1].Value.ToString() + "'";
                        }
                }
            }
        }



        private void Facturar()
        {
            this.ObtenRemisiones();
            //if (Remisiones != "")
            //{
                GeneraFacturasUserControl GeneaFac = new GeneraFacturasUserControl();
                GeneaFac.fechaInicio = this.dateTimeInput1.Value;
                GeneaFac.fechaFin = this.dateTimeInput2.Value;
                GeneaFac.ClienteID = ClienteTextBoxX.Tag.ToString();
                GeneaFac.PrecioFijo = radioButton1.Checked;
                GeneaFac.Periodo = dateTimeInput1.Value;
                GeneaFac.Owner = this;
                GeneaFac.Muestra();
                this.Buscar();
            //}
            //else
            //{
            //   MessageBox.Show("Debe seleccionar al menos una remisión");
            //}

        }



        public void ActivaComandos()
        {
            this.buttonItem.Shortcuts.Add(eShortcut.F5);
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
            if (ClienteTextBoxX.Tag != null)
            {
                //VERIFICAMOS QUE ALMENOS EXISTA UNA  REMISION SELECCIONADA


                this.Facturar();

            }
            else
            {
               MessageBox.Show("Debe seleccionar un cliente.");
            }
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
            _cliente = cliente;
            ClienteTextBoxX.Tag = cliente.ID;
            ClienteTextBoxX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;

            SIFNegocio.ClienteSubrogacion ClienteLog = new SIFNegocio.ClienteSubrogacion();
            SIFModelo.ClienteSubrogaccion ClienteSub = ClienteLog.ClientePorID(cliente.ID);
            if (ClienteSub != null)
            {
                if (ClienteSub.PRECIO_FIJO == SIFModelo.Tipos.SiNo.SI)
                    radioButton1.Checked = true;
            }
            this.Buscar();
        }
        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
        }
        View.Catalogos.ClienteControl frmCliente;
        private void SeleccionaCliente()
        {
            if (this.dateTimeInput1.Value == new DateTime() || this.dateTimeInput2.Value == new DateTime())
            {
               MessageBox.Show("Elija primero las fechas de corte");
                return;
            }


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

                foreach (GridElement Rows in superGridControl1.PrimaryGrid.Rows)
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
       

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (ClienteTextBoxX.Tag != null)
                this.Buscar();//precio fijo
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (ClienteTextBoxX.Tag != null)
                this.Buscar();
        }


        private void ingresaCmpGenTraspButtonItem_Click(object sender, EventArgs e)
        {
            if (ClienteTextBoxX.Tag == null)
            {
                MessageBox.Show("debes de seleccionar un cliente", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

                if (MessageBox.Show("Esta accion va a realizar varias modificaciones a su sistema recalcando los puntos:" +
               Environment.NewLine + "1.- Generacion y recepcion  de ordenes de compra de un cliente en especial(Salud)  " +
               Environment.NewLine + "2.- Creacion de traspasos" +
               Environment.NewLine + "Nota esto solo esta diseñado para loc proveedores  de salud  Marcados por comercializacion  ", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning

               ) == DialogResult.Cancel)
                return;


            MessageBox.Show("El archivo  tiene que contener las columnas:" + Environment.NewLine +
                            "Clave del Producto" + Environment.NewLine +
                            "Piezsas" + Environment.NewLine +
                            "Descripcion" + Environment.NewLine +
                            "Costo unitario" + Environment.NewLine +
                            "Iva" + Environment.NewLine +
                            "Precio Venta Unitario.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string rAplicar = this.impFileForFac();
            if (string.IsNullOrEmpty(rAplicar))
            {
                MessageBox.Show("No se insertaron datos respuesta vacia");
                return;
            }

            if (MessageBox.Show(rAplicar+Environment.NewLine+"Desea continuar", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) 
                return;
            Cursor.Current = Cursors.WaitCursor;
            string r_procesa= procesaGenCompratrasp();
            Cursor.Current = Cursors.Default;
            MessageBox.Show(r_procesa, "informacion ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private string procesaGenCompratrasp() {
            SIFNegocio.Subrogacion.Factura insr = new SIFNegocio.Subrogacion.Factura();
            return insr.procesaGenCompratrasp_c(_cliente.ID, SIF.Helpers.Sesion.Usuario.UsuariosID.ToString());
        }

        private string impFileForFac()
        {
            string resul = string.Empty;
            SIFNegocio.Articulo art = new SIFNegocio.Articulo();
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Seleccione el archivo a Procesar";
            fdlg.Filter = "CSV files (*.TXT)|*.txt";
            fdlg.RestoreDirectory = true;
            bool FmtValid = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                SIFNegocio.Subrogacion.Factura insr = new SIFNegocio.Subrogacion.Factura();
                DataTable dtPedido = new DataTable();
                dtPedido.Columns.Add("clavedelproducto", typeof(string));
                dtPedido.Columns.Add("piezas", typeof(Decimal));
                dtPedido.Columns.Add("descripcion", typeof(string));
                dtPedido.Columns.Add("costounitario", typeof(Decimal));
                dtPedido.Columns.Add("iva", typeof(Decimal));
               dtPedido.Columns.Add("precio_vta_unitario", typeof(Decimal));

                StreamReader reader = StreamReader.Null;
                string str = null;
                int Regs = 0;
                string FName = fdlg.SafeFileName;
                string FPath = Path.GetDirectoryName(fdlg.FileName);
                string FExt = Path.GetExtension(FName);
                Regex objNotNumPattern = new Regex(@"[^0-9]([.][0-9]{1,3})");
                Regex objNotAlphaPattern = new Regex(@"[^a-zA-Z0-9\s]");
                try
                {
                    // Valida formato de archivo
                    reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
                  //  List<String> listaInex = new List<string>();
                    while ((str = reader.ReadLine()) != null)
                    {
                        int x = str.Split('\t').Count();
                        if (x != 6)
                        {
                            FmtValid = false;
                           MessageBox.Show("El formato de Archivo " + FName + " es Invalido");
                            break;
                        }

                        if (objNotNumPattern.IsMatch(str.Split('\t')[3]))
                        {
                            FmtValid = false;
                            MessageBox.Show("El precio " + str.Split('\t')[3].ToString() + " es Invalido");
                            break;
                        }
                        if (objNotNumPattern.IsMatch(str.Split('\t')[5]))
                        {
                            FmtValid = false;
                            MessageBox.Show("El precio " + str.Split('\t')[5].ToString() + " es Invalido");
                            break;
                        }
                    }               
                    string Result = "";
                    if (FmtValid)
                    {
                        reader.Close();
                        reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
                        while ((str = reader.ReadLine()) != null)
                        {

                            dtPedido.Rows.Add(str.Split('\t')[0],
                                              str.Split('\t')[1],
                                              str.Split('\t')[2],
                                              str.Split('\t')[3],
                                              str.Split('\t')[4],
                                              str.Split('\t')[5]                                                                                      
                                              );

                            Regs++;
                        }

                        DataRow[] results = dtPedido.Select(null, "clavedelproducto");

                        String[] Clavedelproducto = new String[results.Length];
                        Decimal[] Piezas = new Decimal[results.Length];
                        String[] Descripcion = new String[results.Length];
                        Decimal[] Costounitario=new  Decimal[results.Length];
                        Decimal[] Iva = new Decimal[results.Length];                       
                        Decimal[] Precio_vta_unitario = new Decimal[results.Length];

                        int ind = 0;

                        foreach (DataRow rows in dtPedido.Rows)
                        {                                                        
                            Clavedelproducto[ind] = rows["clavedelproducto"].ToString().Trim();
                            Piezas[ind] = Convert.ToDecimal(rows["piezas"]);
                            Descripcion[ind] = rows["descripcion"].ToString().Trim();
                            Costounitario[ind] = Convert.ToDecimal(rows["costounitario"]);
                            Iva[ind] = Convert.ToDecimal(rows["iva"]);                            
                            Precio_vta_unitario[ind] = Convert.ToDecimal(rows["precio_vta_unitario"]);
                            ind++;
                        }

                        resul = insr.insertaDatosParaFactura(
                           // 92,
                            Clavedelproducto ,
                            Piezas ,
                            Descripcion ,
                            Costounitario ,
                            Iva ,
                            Precio_vta_unitario 
                            );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    return ex.ToString();
                }
                finally
                {
                    reader.Close();
                }

            }
            return resul;
        }


    }
}
