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

    public partial class GeneraFacturasUserControl : Templates.ListaUserControl
    {
        public String ClienteID = "";
        BindingList<SIFModelo.TipoPago> bsTiposPago = new BindingList<SIFModelo.TipoPago>();
        private SIFNegocio.Subrogacion.Factura Logica = new SIFNegocio.Subrogacion.Factura();
        private String Remisiones = "";
        public bool PrecioFijo;
        public GeneraFacturasUserControl()
        {
            InitializeComponent();
            this.inicializaTabla();
        }


        private void Back()
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
                    this.Owner.Owner.ActivaComandos();
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

            if (panel.DataMember == "FACTURA")
            {
                CustomizeDetailsPanel(panel);
            }
        }

        private void CustomizeDetailsPanel(GridPanel panel)
        {

        }



        private void Buscar()
        {
            if (SeparaTextBoxX.Tag != null)
            {
            }
            else
            {
               MessageBox.Show("Debe seleccionar un cliente.");
            }
        }






        public FacturasUserControl Owner { get; set; }

        internal void Muestra()
        {
            Owner.Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;
            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);

            SIFModelo.SubRogacion.Sobrogacion.CAMPOSCLIENTEFACTRow Campos = Logica.GetCampos(ClienteID);
            if (Campos != null)
            {
                SeparaTextBoxX.Text = Campos.SEPARAR;
                TxtConcepto.Text = Campos.CONCEPTO;
                TxtClave.Text = Campos.CLAVE;
                Chkcincomillar.CheckValue = Campos.CINCOMILLAR;
                chkLoteSerie.CheckValue = Campos.LOTESERIE;
                chkDetalle.CheckValue = Campos.RESUMEN;

            }
            //obtenemos los datos de cliente 
            SIFNegocio.ClienteConvenios LogicaCli = new SIFNegocio.ClienteConvenios();
            SIFModelo.ClienteConvenio ClienteConv = LogicaCli.ClientePorID(int.Parse(ClienteID));
            if (ClienteConv != null)
            {

                SIFModelo.TipoPago CREDITO = new SIFModelo.TipoPago();
                var vCREDITO = from t in bsTiposPago where t.ID == ClienteConv.TipoPagoID select t;
                if (vCREDITO.Count() > 0)
                {
                    CREDITO = vCREDITO.First();
                }
                tipoPagoComboBoxEx.Text = CREDITO.Nombre;
                TxtNumCta.Text = ClienteConv.numCta;
            }

            ObtenRemisiones();
            GeneraDetalle();

        }




        SIFModelo.Remision remisionFacturar;
        private void Facturar()
        {


            this.Buscar();

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
            this.GeneraDetalle();
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
            SeparaTextBoxX.Tag = cliente.ID;
            SeparaTextBoxX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
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

        private void ClienteTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            CamposForm Frm = new CamposForm(PrecioFijo);
            if (Frm.ShowDialog() == DialogResult.OK)
            {
                SeparaTextBoxX.Text = Frm.ListaArg;
                GeneraDetalle();
            }

        }

        private void textBoxX1_ButtonCustomClick(object sender, EventArgs e)
        {
            CamposForm Frm = new CamposForm(PrecioFijo);
            if (Frm.ShowDialog() == DialogResult.OK)
            {
                TxtConcepto.Text = Frm.ListaArg;
                GeneraDetalle();
            }
        }

        private void textBoxX2_ButtonCustomClick(object sender, EventArgs e)
        {

            CamposForm Frm = new CamposForm(PrecioFijo);
            if (Frm.ShowDialog() == DialogResult.OK)
            {
                TxtClave.Text = Frm.ListaArg;
                GeneraDetalle();
            }
        }

        private void ObtenRemisiones()
        {
            GridPanel Grid = Owner.superGridControl1.PrimaryGrid;
           // Remisiones = "";
            int numRow = 1;
            foreach (GridElement Rows in Grid.Rows)
            {
                if ((Rows is GridRow))
                {
                    var row = (GridRow)Rows;
                    if (row.Cells[0].Value != null)
                        if (bool.Parse(row.Cells[0].Value.ToString()) == true)
                        {
                            //jalamos el detalle de la remision
                            if ((numRow % 50) == 0)
                            {
                                Remisiones += ") OR REMISION_DET.NUM_REMISION IN ('" + row.Cells[1].Value.ToString() + "'";
                                numRow++;
                                continue;
                            }
                            numRow++;
                            Remisiones = Remisiones + ",'" + row.Cells[1].Value.ToString() + "'";
                        }
                }

            }
           
            

            if (Logica.Ds.FACTURA.Columns.Contains("LISTAREMISION"))
                foreach (SIFModelo.SubRogacion.Sobrogacion.FACTURARow Factura in Logica.Ds.FACTURA)
                {
                    if (Factura["LISTAREMISION"] != null)
                        Remisiones = Remisiones + ",'" + Factura["LISTAREMISION"].ToString() + "'";
                }
        }

      /*  private void ObtenRemisionesF()
        {
            GridPanel Grid = Owner.superGridControl1.PrimaryGrid;
            Remisiones = "";
            int numRow = 1;
            foreach (GridElement Rows in Grid.Rows)
            {
                if ((Rows is GridRow))
                {
                    var row = (GridRow)Rows;
                    if (row.Cells[0].Value != null)
                        if (bool.Parse(row.Cells[0].Value.ToString()) == true)
                        {
                            //jalamos el detalle de la remision
                            if ((numRow % 50) == 0)
                            {
                                Remisiones += ") OR REMISION_DET.NUM_REMISION IN ('" + row.Cells[1].Value.ToString() + "'";
                                numRow++;
                                continue;
                            }
                            numRow++;
                            Remisiones = Remisiones + ",'" + row.Cells[1].Value.ToString() + "'";
                        }
                }

            }



            if (Logica.Ds.FACTURA.Columns.Contains("LISTAREMISION"))
                foreach (SIFModelo.SubRogacion.Sobrogacion.FACTURARow Factura in Logica.Ds.FACTURA)
                {
                    if (Factura["LISTAREMISION"] != null)
                        Remisiones = Remisiones + ",'" + Factura["LISTAREMISION"].ToString() + "'";
                }
        }*/
       public DateTime? fechaInicio = null;
        public DateTime? fechaFin = null;
        private void GeneraDetalle()
        {

            // generamos el detalle apartir de las facturas seleccionadas

            if (Remisiones.Length > 1)
            {
                Logica.Ds.Clear();

                bool esIsstep = false;

                SIFModelo.ClienteSubrogaccion sub = new SIFNegocio.ClienteSubrogacion().ClientePorID(System.Convert.ToInt32(ClienteID));
                if (ClienteID == "90" || ClienteID == "92") // ROMA 02SEP2013
                {
                    esIsstep = true;
                }
                
                superGridControl1.PrimaryGrid.DataSource = Logica.GetFacturas(Logica.Ds, SeparaTextBoxX.Text, TxtConcepto.Text, TxtClave.Text, Remisiones.Substring(1), PrecioFijo, chkLoteSerie.Checked, esIsstep, sub, fechaInicio, fechaFin);
                superGridControl1.PrimaryGrid.DataMember = "FACTURA";
            }
        }

        private void GeneraFactura()
        {
            String ClienteID = "";
            // VERIFICAMOS SI EL CLIENTE TIENE LOS DATOS DE FACTURA

            //guardamos los datos de los campos que conforman la factura
            if (tipoPagoComboBoxEx.SelectedItem == null)
            {
               MessageBox.Show("Debe seleccionar un tipo de pago.");
                return;
            }

            if (TxtConcepto.Text == "")
            {
               MessageBox.Show("Debe seleccionar un concepto para la factura.");
                return;
            }

            if (TxtClave.Text == "")
            {
               MessageBox.Show("Debe seleccionar una clave para la factura.");
                return;
            }
            // guardamos las facturas y las timbramos

            List<SIFModelo.SubRogacion.Sobrogacion.FACTURARow> dtFacturas = new List<SIFModelo.SubRogacion.Sobrogacion.FACTURARow>();
            if (!Logica.Ds.FACTURA.Columns.Contains("FACTURAR"))
                Logica.Ds.FACTURA.Columns.Add("FACTURAR", Type.GetType("System.Boolean"));
            foreach (DataRow dr in Logica.Ds.FACTURA.Rows)
            {
                dr["FACTURAR"] = false;
            }
            foreach (SIFModelo.SubRogacion.Sobrogacion.FACTURARow Factura in Logica.Ds.FACTURA)
            {
                
                if (System.Convert.ToBoolean(Factura["FACTURAR"]) == false)
                {
                    dtFacturas.Add(Factura);
                    continue;
                }
            }
/*LGS 24/03/2014 COMENTADO TEMPORALMENTE
            foreach (var row in dtFacturas)
            {
                Logica.Ds.FACTURA.RemoveFACTURARow(row);
            }
*/
            ObtenRemisiones();//Obtiene solo las remisiones seleccionadas en grid LGS 31/03/2014, guarda el resultado en la variable Remisiones
            foreach (SIFModelo.SubRogacion.Sobrogacion.FACTURARow Factura in Logica.Ds.FACTURA)
            {
                Factura.TIPO_PAGO_ID = (tipoPagoComboBoxEx.SelectedItem as SIFModelo.TipoPago).ID;
                ClienteID = Factura.CLIENTE_ID.ToString();
                Factura.IMPORTE_LETRA = sif_tools.NumberToLetters.NumToLetter((double)Factura.TOTAL, Factura.TOTAL.GetType().ToString());
                Factura.REFERENCIA = "";
                Factura.NUM_CUENTA = TxtNumCta.Text;
                Factura.TIPO_PAGO_ID = (tipoPagoComboBoxEx.SelectedItem as SIFModelo.TipoPago).ID;
            }
            if (ClienteID == "")
                ClienteID = this.ClienteID;

            SIFNegocio.Clientes ClienteLog = new SIFNegocio.Clientes();
            SIFModelo.Cliente cliente = ClienteLog.ClientePorID(int.Parse(ClienteID));
            SIFModelo.DireccionCliente DirFact = ClienteLog.DireccionCliente(cliente, SIFModelo.Tipos.TipoDireccion.fiscal);
            if (DirFact == null)
            {
                Catalogos.DireccionClienteForm frmCliente = new Catalogos.DireccionClienteForm(cliente);
                if (frmCliente.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            Logica.ActualizaDatosFijos(SeparaTextBoxX.Text, TxtConcepto.Text, TxtClave.Text,
                (tipoPagoComboBoxEx.SelectedItem as SIFModelo.TipoPago).ID.ToString(),
                TxtNumCta.Text, Chkcincomillar.CheckValue.ToString(), chkLoteSerie.CheckValue.ToString(),
                chkDetalle.CheckValue.ToString(), ClienteID);


            if (Logica.InsertaFacturas(Logica.Ds))
            {
                //mandamos a timbrar las facturas
            }
            if (TimbrarFacturas())
            {
                //actualizamos las remisiones
                foreach (SIFModelo.SubRogacion.Sobrogacion.FACTURARow Factura in Logica.Ds.FACTURA)
                {
                    Logica.ActualizaRemisiones(Remisiones, Factura.NUM_FACTURA, Factura.REFERENCIA);//update remision set FACTURA='S',NUM_FACTURA='" + UccID + "' WHERE NUM_REMISION in (''" + remisionesRemision + ")";
                }
                this.Back();
            }
        }

        private void GeneraFacturaISSTEP()
        {
            String ClienteID = "";
            // VERIFICAMOS SI EL CLIENTE TIENE LOS DATOS DE FACTURA

            ////guardamos los datos de los campos que conforman la factura
            //if (tipoPagoComboBoxEx.SelectedItem == null)
            //{
            //   MessageBox.Show("Debe seleccionar un tipo de pago.");
            //    return;
            //}

            //if (TxtConcepto.Text == "")
            //{
            //   MessageBox.Show("Debe seleccionar un concepto para la factura.");
            //    return;
            //}

            //if (TxtClave.Text == "")
            //{
            //   MessageBox.Show("Debe seleccionar una clave para la factura.");
            //    return;
            //}
            //// guardamos las facturas y las timbramos

            //List<SIFModelo.SubRogacion.Sobrogacion.FACTURARow> dtFacturas = new List<SIFModelo.SubRogacion.Sobrogacion.FACTURARow>();

            //foreach (SIFModelo.SubRogacion.Sobrogacion.FACTURARow Factura in Logica.Ds.FACTURA)
            //{
            //    if (System.Convert.ToBoolean(Factura["FACTURAR"]) == false)
            //    {
            //        dtFacturas.Add(Factura);
            //        continue;
            //    }
            //}

            //foreach (var row in dtFacturas)
            //{
            //    Logica.Ds.FACTURA.RemoveFACTURARow(row);
            //}

            //foreach (SIFModelo.SubRogacion.Sobrogacion.FACTURARow Factura in Logica.Ds.FACTURA)
            //{
            //    Factura.TIPO_PAGO_ID = (tipoPagoComboBoxEx.SelectedItem as SIFModelo.TipoPago).ID;
            //    ClienteID = Factura.CLIENTE_ID.ToString();
            //    Factura.IMPORTE_LETRA = sif_tools.NumberToLetters.NumToLetter((double)Factura.TOTAL, Factura.TOTAL.GetType().ToString());
            //    Factura.REFERENCIA = "";
            //    Factura.NUM_CUENTA = TxtNumCta.Text;
            //    Factura.TIPO_PAGO_ID = (tipoPagoComboBoxEx.SelectedItem as SIFModelo.TipoPago).ID;
            //}


            //SIFNegocio.Clientes ClienteLog = new SIFNegocio.Clientes();
            //SIFModelo.Cliente cliente = ClienteLog.ClientePorID(int.Parse(ClienteID));
            //SIFModelo.DireccionCliente DirFact = ClienteLog.DireccionCliente(cliente, SIFModelo.Tipos.TipoDireccion.fiscal);
            //if (DirFact == null)
            //{
            //    Catalogos.DireccionClienteForm frmCliente = new Catalogos.DireccionClienteForm(cliente);
            //    if (frmCliente.ShowDialog() != DialogResult.OK)
            //    {
            //        return;
            //    }
            //}

            //Logica.ActualizaDatosFijos(SeparaTextBoxX.Text, TxtConcepto.Text, TxtClave.Text,
            //    (tipoPagoComboBoxEx.SelectedItem as SIFModelo.TipoPago).ID.ToString(),
            //    TxtNumCta.Text, Chkcincomillar.CheckValue.ToString(), chkLoteSerie.CheckValue.ToString(),
            //    chkDetalle.CheckValue.ToString(), ClienteID);


            //if (Logica.InsertaFacturas(Logica.Ds))
            //{
            //    //mandamos a timbrar las facturas
            //}

            AnexoTipoValeForm frmAnexo = new AnexoTipoValeForm();

            if (frmAnexo.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            
            anexo = frmAnexo.Anexo;
            TipoVale = frmAnexo.TipoVale;

            if (TimbrarFacturas(anexo,TipoVale))
            {
                //actualizamos las remisiones
                foreach (SIFModelo.SubRogacion.Sobrogacion.FACTURARow Factura in Logica.Ds.FACTURA)
                {
                    Logica.ActualizaRemisiones(Remisiones, Factura.NUM_FACTURA, Factura.REFERENCIA);
                }
                this.Back();

            }
        }

        private void cancelarButtonItem_Click(object sender, EventArgs e)
        {
            GeneraFactura();
        }

        private void cargaTipoPago()
        {
            SIFNegocio.TipoPagos LtipoPago = new SIFNegocio.TipoPagos();

            bsTiposPago = new BindingList<SIFModelo.TipoPago>(LtipoPago.Buscar("ACTIVO", "S").DataSource as List<SIFModelo.TipoPago>);

            //AGREGAR LOS TIPOS DE PAGO
            this.tipoPagoComboBoxEx.DataSource = bsTiposPago;
            tipoPagoComboBoxEx.DisplayMember = "Nombre";
            tipoPagoComboBoxEx.ValueMember = "Id";

        }
        private void GeneraFacturasUserControl_Load(object sender, EventArgs e)
        {
            cargaTipoPago();
        }

        public bool TimbrarFacturas()
        {
            SIFNegocio.Clientes ClienteLog = new SIFNegocio.Clientes();
            SIFModelo.Cliente cliente = ClienteLog.ClientePorID(int.Parse(ClienteID));

            bool ret5Mill = Chkcincomillar.Checked;

            bool generada = false;
            this.ObtenRemisiones();    

            if (Logica.TimbraFacturas(Logica.Ds, cliente, Helpers.Sesion.Sucursal, this.fechaInicio.Value, this.fechaFin.Value, Periodo,Remisiones, ret5Mill))
            {
                generada = true;
            }

            return generada;
        }

        public bool TimbrarFacturas(string Anexo, string TipoVale)
        {
            SIFNegocio.Clientes ClienteLog = new SIFNegocio.Clientes();
            SIFModelo.Cliente cliente = ClienteLog.ClientePorID(int.Parse(ClienteID));

            bool ret5Mill = Chkcincomillar.Checked;

            bool generada = false;

            // ROMA 02SEP2013 ????

            if (Logica.TimbraFacturasISSTEP(Logica.Ds, cliente, Helpers.Sesion.Sucursal, this.fechaInicio.Value, this.fechaFin.Value, Periodo, Anexo, TipoVale, ClienteID, ret5Mill))
            {
                generada = true;
            }

            return generada;
        }

        private void TxtConcepto_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkLoteSerie_CheckedChanged(object sender, EventArgs e)
        {
            //   GeneraDetalle();
        }


        public DateTime Periodo { get; set; }

        private void superGridControl1_Click(object sender, EventArgs e)
        {

        }

        public string TipoVale { get; set; }

        public string anexo { get; set; }
    }
}
