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

namespace SIF.View.Inventario
{
    public partial class RecepcionTraspasosAlmacenUserControl : Templates.ListaUserControl
    {
        private int Cual = 0;
        SIFNegocio.Inventario.Traspasos TraspasoAlmacen = new SIFNegocio.Inventario.Traspasos();
        SIFModelo.Inventarios.InventarioDataSet DsPedidosTrasp;
        public RecepcionTraspasosAlmacenUserControl()
        {
            InitializeComponent();
            this.dateTimeInput1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            this.dateTimeInput2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            Privilegios();
        }
          
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 31, int.Parse(Xbtn.Tag.ToString()));
            }

        }
        void deshabilitar()
        {
            this.buttonItem2.Enabled = false;
        }
        RecepcionTrapasoAlmacenUserControl frmTraspaso = new RecepcionTrapasoAlmacenUserControl();
        frmRecepcionControl frmRecepcion = new frmRecepcionControl();
        RecepcionDevolucionTrapasoAlmacenUserControl frmDevTraspaso = new RecepcionDevolucionTrapasoAlmacenUserControl();
        private void Nuevo()
        {
            if (!frmTraspaso.Mostrado)
            {
                frmTraspaso = new RecepcionTrapasoAlmacenUserControl();
                frmTraspaso.Owner = this;
                frmTraspaso.Muestra();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        public bool Mostrado { get; set; }

        public Menu.InventarioMenu Owner { get; set; }

        public void Muestra()
        {
            if (Mostrado)
            {
                return;
            }

            this.Dock = DockStyle.Fill;
            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.ActivaComandos();
            this.Owner.DesactivaComandos();
            Mostrado = true;
            this.Buscar();
        }

        public void ActivaComandos()
        {

        }

        public void Back()
        {
            try{
            Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.DesactivaComandos();
            this.Owner.ActivaComandos();
            Mostrado = false;
            }
            catch { }
        }

        public void DesactivaComandos()
        {

        }

        //DataSet DsPedidosTrasp;
        SIFNegocio.Inventario.Traspasos traspasoAlmacen = new SIFNegocio.Inventario.Traspasos();
        public void Buscar()
        {
            DsPedidosTrasp = new SIFModelo.Inventarios.InventarioDataSet();
            switch (Cual)
            {
                case 0:
                    DsPedidosTrasp = traspasoAlmacen.GetTraspasos(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "S", foliotextBoxX.Text, Helpers.Sesion.Sucursal.SucursalesID, "E");
                    break;
                case 1:
                    DsPedidosTrasp = traspasoAlmacen.GetTraspasos(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "C", foliotextBoxX.Text, Helpers.Sesion.Sucursal.SucursalesID, "E");
                    break;
                case 2:
                    DsPedidosTrasp = traspasoAlmacen.GetTraspasos(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "X", foliotextBoxX.Text, Helpers.Sesion.Sucursal.SucursalesID, "E");
                    break;
                case 3:
                    DsPedidosTrasp = traspasoAlmacen.GetTraspasos(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "", foliotextBoxX.Text, Helpers.Sesion.Sucursal.SucursalesID, "E");
                    break;
                case 4: //Devolucion-Traspaso
                    DsPedidosTrasp = traspasoAlmacen.GetTraspasos(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "R", foliotextBoxX.Text, Helpers.Sesion.Sucursal.SucursalesID, "E");
                    break;

            }


            DsPedidosTrasp.Relations.Add("1", DsPedidosTrasp.Tables["TRASPASO"].Columns["FOLIO"],
                                              DsPedidosTrasp.Tables["TRASPASO_DET"].Columns["FOLIO"], false);
            //ROMA 17AGO2013

           // MessageBox.Show(DsPedidosTrasp.Tables["TRASPASO"].Rows[0]["SUCURSAL_ORIGEN"].ToString());
            
            DsPedidosTrasp.TRASPASO.Columns.Remove("SUCURSAL_ORIGEN");
            DsPedidosTrasp.TRASPASO.Columns.Remove("SUCURSAL_DESTINO");
            //ROMA 17AGO2013
            DsPedidosTrasp.TRASPASO_DET.Columns.Remove("CANTIDAD_SOLICITADA");
            //DsPedidosTrasp.TRASPASO_DET.Columns.Remove("CANTIDAD_ENVIADA");
            DsPedidosTrasp.TRASPASO.DefaultView.Sort = "fecha desc";
            
            //DataSet1.Tables["Tu_Tabla"].Rows[0]["Nombre_Columna_1"].ToString()
            

            this.superGridControl1.PrimaryGrid.DataSource = DsPedidosTrasp;
            this.superGridControl1.PrimaryGrid.DataMember = "TRASPASO";
        }

        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void PedidosAlmacenUserControl_Load(object sender, EventArgs e)
        {
            this.dateTimeInput1.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            this.dateTimeInput2.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
        }

        private void nuevoPedidoButtonItem_Click(object sender, EventArgs e)
        {
            this.Nuevo();
        }

        private bool ValidaOrigenDestinoExistente(GridRow row)
        {
            string origen = row.Cells[4].Value.ToString();
            string destino = row.Cells[5].Value.ToString();

            if (origen.Contains("NO EXISTE"))
            {
               MessageBox.Show("El origen no existe");
                //return false;//L 04/12/2013 Para que puedan cerrar traspasos de amalucan, acatzingo, 50, 92, etc
            }

            if (destino.Contains("NO EXISTE"))
            {
               MessageBox.Show("El destino no existe");
                return false;
            }

            return true;
        }

        private void Envia()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);

            if (container == null)
            {
                MessageBox.Show("Elija el traspaso a recibir");
                return;
            }

            if (!(container is GridRow))
            {
                return;
            }

            var row = (GridRow)container;

            if (!ValidaOrigenDestinoExistente(row))
            {
                return;
            }

            if (!frmTraspaso.Mostrado)
            {
                frmTraspaso = new RecepcionTrapasoAlmacenUserControl();
                frmTraspaso.TraspasoID = row.Cells[1].Value.ToString();
                frmTraspaso.lote = int.Parse(row.Cells[2].Value.ToString());
                frmTraspaso.SucursalO = row.Cells[4].Value.ToString();
                frmTraspaso.SucursalD = row.Cells[5].Value.ToString();
                frmTraspaso.Usr_Envia = row.Cells[6].Value.ToString();
                frmTraspaso.Owner = this;
                frmTraspaso.Muestra();
            }

        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            //this.Envia();
            //this.AbrirArchivo();
            importarTraspaso();
        }


        // ROMA 14AGO2013
        private void Recibe()
        {
            string sucursal_id = SIFNegocio.Helpers.Sesion.Sucursal.SucursalesID.ToString() +
                                    " - " +
                                    SIFNegocio.Helpers.Sesion.Sucursal.Nombre.ToString();
            String ProductName = "Recepción Traspasos";

            GridPanel panel = superGridControl1.PrimaryGrid;
            if (panel.ActiveRow == null)
            {
                return;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Seleccione la cabecera del Traspaso");
                return;
            }
            var row = (GridRow)container;
            string sucursal = row.Cells[4].Value.ToString();
            switch (row.Cells["ACTIVO"].Value.ToString())
            {
                case "S":
                    ////if (!frmTraspaso.Mostrado)
                    ////{
                    ////    frmTraspaso = new RecepcionTrapasoAlmacenUserControl();
                    ////    frmTraspaso.TraspasoID = row.Cells[1].Value.ToString();
                    ////    frmTraspaso.lote = int.Parse(row.Cells[2].Value.ToString());
                    ////    frmTraspaso.SucursalO = row.Cells[4].Value.ToString();
                    ////    frmTraspaso.SucursalD = row.Cells[5].Value.ToString();
                    ////    frmTraspaso.Usr_Envia = row.Cells[6].Value.ToString();
                    ////    frmTraspaso.Owner = this;
                    ////    frmTraspaso.Muestra();
                    ////}
                    if (sucursal_id == sucursal)
                    {
                       MessageBox.Show("NO SE PUEDEN RECIBIR TRASPASOS GENERADOS POR ESTA SUCURSAL  ");
                        return;
                    }
                    if (!frmRecepcion.Mostrado)
                    {
                        frmRecepcion = new frmRecepcionControl();
                        frmRecepcion.TraspasoID = row.Cells[1].Value.ToString();
                        frmRecepcion.lote = int.Parse(row.Cells[2].Value.ToString());
                        frmRecepcion.SucursalO = row.Cells[4].Value.ToString();
                        frmRecepcion.SucursalD = row.Cells[5].Value.ToString();
                        frmRecepcion.Usr_Envia = row.Cells[6].Value.ToString();
                        frmRecepcion.Owner = this;
                        frmRecepcion.Muestra();
                        
                    }
                    break;
                case "C":
                   MessageBox.Show("El traspaso ya se cerro", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "X":
                   MessageBox.Show("El traspaso esta cancelado", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "R":
                    //MessageBoxEx.Show("El traspaso es una devolución", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!frmDevTraspaso.Mostrado)
                    {
                        frmDevTraspaso = new RecepcionDevolucionTrapasoAlmacenUserControl();
                        frmDevTraspaso.TraspasoID = row.Cells[1].Value.ToString();
                        frmDevTraspaso.lote = int.Parse(row.Cells[2].Value.ToString());
                        frmDevTraspaso.SucursalO = row.Cells[4].Value.ToString();
                        frmDevTraspaso.SucursalD = row.Cells[5].Value.ToString();
                        frmDevTraspaso.Usr_Envia = row.Cells[6].Value.ToString();
                        frmDevTraspaso.Owner = this;
                        frmDevTraspaso.Muestra();                            
                    }
                    break;
                default:
                    break;
            }
        }
        // ROMA 14AGO2013

        private int CancelTraspaso(string NoFolio, string NoLote)
        {
            SIFNegocio.Inventario.Traspasos tRAS = new SIFNegocio.Inventario.Traspasos();
            return tRAS.CancelTraspaso(NoFolio, NoLote);
        }

        private int CierraTraspaso(string NoFolio, string NoLote)
        {
            SIFNegocio.Inventario.Traspasos tRAS = new SIFNegocio.Inventario.Traspasos();
            return tRAS.CierraTraspaso(Helpers.Sesion.Usuario.UsuariosID.ToString(), NoFolio, NoLote);
        }

        private void cancela()
        {
            String ProductName = "Traspasos";
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);
            var row = (GridRow)container;
            if (row.Cells["ACTIVO"].Value.ToString().Contains('S'))
            {
                if (MessageBoxEx.Show("¿Cancelar el Traspaso " + row.Cells[1].Value.ToString()
                                                           + " - "
                                                           + row.Cells[2].Value.ToString() + "?",
                                  ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (CancelTraspaso(row.Cells[1].Value.ToString(),
                                      row.Cells[2].Value.ToString()) > 0)
                        row.Cells["ACTIVO"].Value = "X";

            }
            else
            {
                switch (row.Cells["ACTIVO"].Value.ToString())
                {
                    case "C":
                       MessageBox.Show("El traspaso ya se cerro", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "X":
                       MessageBox.Show("El traspaso esta cancelado", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "R":
                       MessageBox.Show("El traspaso es una devolución", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }

                //if (row.Cells["ACTIVO"].Value.ToString().Contains('C'))
                //   MessageBox.Show("El traspaso ya se cerro", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //else
                //   MessageBox.Show("El traspaso esta cancelado", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            if (panel.ActiveRow == null)
            {
                return;
            }
            else
            {
                this.cancela();
                this.Buscar();
            }
        }
        private void buttonItemCc_Click(object sender, EventArgs e)
        {

            this.capturaCaducidad();
        }

        private void capturaCaducidad()
        {
            
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);
            var row = (GridRow)container;
            if (row == null)
                return;
            if (!row.Cells["ACTIVO"].Value.ToString().Contains('S') && radioButton1.Checked)
            {
                MessageBox.Show("El movimiento tiene que estar cerrado");
                return;
            }           
            SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(SIF.Helpers.Sesion.Usuario.UsuariosID);

            if (porsurtirRadioButton.Checked)
            {
                //Inventario.frmCapturaCaducidades frm = new Inventario.frmCapturaCaducidades(usuario, row.Cells["FOLIO"].Value.ToString() + "-" + row.Cells["LOTE"].Value.ToString(), 12);
                //frm.ShowDialog();
                Inventario.controlCaducidadesSelectUserControl frmCc = new Inventario.controlCaducidadesSelectUserControl(row.Cells[1].Value.ToString(), 12, int.Parse(row.Cells[2].Value.ToString()));
                frmCc.Owner = this;
                frmCc.Muestra();
            }
          

        }
        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            //this.Envia();
            this.Recibe();
        }

        private void imprimir()
        {
            String ProductName = "Traspasos";
            //GridPanel panel = superGridControl1.PrimaryGrid;
            //var container = ((GridContainer)panel.ActiveRow);
            // var row = (GridRow)container;

            GridPanel panel = superGridControl1.PrimaryGrid;
            if (panel.ActiveRow == null)
            {
                return;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Seleccione la cabecera del traspaso");
                return;
            }
            var row = (GridRow)container;
            SIFModelo.Inventarios.InventarioDataSet.TRASPASORow TraspasoRow = ((DataRowView)row.DataItem).Row as SIFModelo.Inventarios.InventarioDataSet.TRASPASORow;
            if (!row.Cells["ACTIVO"].Value.ToString().Contains('X') & !row.Cells["ACTIVO"].Value.ToString().Contains('R'))
            {
                string[] destinoL = TraspasoRow.ORIGEN.Split(new char[] { '-' });
                string destino = destinoL[0].Trim();

                SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Recepcion_traspaso_caducidades.rpt", "{cs_rpt_traspaso_cad.FOLIO}='" + row.Cells[1].Value.ToString() + "' AND {cs_rpt_traspaso_cad.LOTE}=" + TraspasoRow.LOTE);
                Impresion.ShowDialog();
            }
            else
                if (row.Cells["ACTIVO"].Value.ToString().Contains('R'))
                   MessageBox.Show("El Traspaso no se a recibido", "Traspasos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                   MessageBox.Show("El Traspaso esta cancelado", "Traspasos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void porsurtirRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (porsurtirRadioButton.Checked)
            {
                Cual = 0;
                this.Buscar();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Cual = 1;
                this.Buscar();

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Cual = 2;
                this.Buscar();
            }
        }

        private void creditoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (creditoRadioButton.Checked)
            {
                Cual = 3;
                this.Buscar();
            }
        }

        private void Cerrar()
        {

            String ProductName = "Traspasos";
            GridPanel panel = superGridControl1.PrimaryGrid;
            if (panel.ActiveRow == null)
            {
                return;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Seleccione la cabecera del traspaso");
                return;
            }
            var row = (GridRow)container;

            if (!ValidaOrigenDestinoExistente(row))
            {
                return;
            }

            if (row.Cells["ACTIVO"].Value.ToString().Contains('S'))
            {
                int SucPed = int.Parse(row.Cells[5].Value.ToString().Split('-')[0]);
                if (SucPed == Helpers.Sesion.Sucursal.SucursalID)
                {
                    if (MessageBoxEx.Show("¿Cerrar el Traspaso " + row.Cells[1].Value.ToString()
                                                            + " - "
                                                            + row.Cells[2].Value.ToString() + "?",
                                    ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (CierraTraspaso(row.Cells[1].Value.ToString(),
                                          row.Cells[2].Value.ToString()) > 0)
                            row.Cells["ACTIVO"].Value = "C";
                    string folio = row.Cells[1].Value.ToString();
                    //SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Incidencia_Recepcion_Almacen.rpt", "{TRASPASO.FOLIO}='" + row.Cells[1].Value.ToString() + "'");
                    //Impresion.ShowDialog();
                    imprimir();
                    this.Buscar();
                }
                else
                {
                   MessageBox.Show("Debe ser la misma sucursal destino verificar configuracion", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                switch (row.Cells["ACTIVO"].Value.ToString())
                {
                    case "C":
                       MessageBox.Show("El traspaso ya se cerro", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "X":
                       MessageBox.Show("El traspaso esta cancelado", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "R":
                       MessageBox.Show("El traspaso es una devolución", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
                //if (row.Cells["ACTIVO"].Value.ToString().Contains('C'))
                //   MessageBox.Show("El traspaso ya se cerro", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //else
                //   MessageBox.Show("El traspaso esta cancelado", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void buttonItem2_Click(object sender, EventArgs e)
        {
            
            this.Cerrar();
          /* MessageBox.Show("Para Cerrar el traspaso debes de estar en el modulo de recepcion");
            this.buttonItem2.Enabled = false;*/
        }

        private void AbrirArchivo()
        {
            openFileDialog1.Title = "Selecciona el archivo de traspaso";
            openFileDialog1.Filter = "Archvio de traspaso (*.traspaso)|*.traspaso";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                // procesamos el archivo
                try
                {
                    SIFModelo.Inventarios.InventarioDataSet PedidosTrasp = new SIFModelo.Inventarios.InventarioDataSet();
                    PedidosTrasp.ReadXml(openFileDialog1.FileName);
                    //guardamos el traspaso y le asignamos nuevo folio

                    DataRow[] results = PedidosTrasp.TRASPASO_DET.Select(null, "lote,partida");
                    // IN Pedido Array's
                    int[] Sec = new int[results.Length];
                    int[] Lotes = new int[results.Length];
                    String[] Articulo = new String[results.Length];
                    String[] Concepto = new String[results.Length];
                    int[] CantS = new int[results.Length];
                    int[] CantE = new int[results.Length];
                    int[] CantR = new int[results.Length];
                    Double[] PrecioE = new Double[results.Length];
                    int[] Caja = new int[results.Length];
                    String[] Pedido = new String[results.Length];
                    Decimal[] TotLote = new Decimal[results.Length];
                    String[] NoLote = new String[results.Length];
                    String[] FecCad = new String[results.Length];


                    Double Total = 0;
                    Decimal DTotal = 0;
                    int sec = 0;
                    DataRow Pedidos = PedidosTrasp.PEDIDO_TRASP.Rows[0];
                    string CtlFolio = Pedidos["FOLIO"].ToString();
                    string CtlLote = Pedidos["Lote"].ToString();

                    ///AVM 13-04-2015
                    ///DEBE OBTENERSE EL MOTIVO DESL ARCHIVO DE EXCEL
                    int ID_MOTIVO_PEDIDO = 0;

                    object objSum = PedidosTrasp.TRASPASO_DET.Compute("Sum(CANTIDAD_ENVIADA)", "lote = " + CtlLote);
                    if (objSum.ToString() != "")
                        Total = Convert.ToDouble(objSum.ToString());

                    foreach (DataRow rowdet in results)
                    {
                        Sec[sec] = sec + 1;
                        Articulo[sec] = rowdet["ARTICULO_ID"].ToString();
                        Concepto[sec] = rowdet["CONCEPTO"].ToString();
                        CantS[sec] = Convert.ToInt16(rowdet["CANTIDAD_SOLICITADA"]);
                        CantE[sec] = Convert.ToInt16(rowdet["CANTIDAD_ENVIADA"]);
                        CantR[sec] = 0;
                        PrecioE[sec] = Convert.ToDouble(rowdet["PRECIO_ENVIA"]);
                        Caja[sec] = Convert.ToInt16(rowdet["CAJA"]);
                        Pedido[sec] = rowdet["CANTIDAD_SOLICITADA"].ToString();
                        NoLote[sec] = rowdet["REFLOTE"].ToString();
                        FecCad[sec] = rowdet["CADUCIDAD"].ToString();
                        sec++;
                    }
                    TraspasoAlmacen.InsertaTraspasoAlmacen(Helpers.Sesion.Usuario.UsuariosID.ToString(), int.Parse(Pedidos["Origen"].ToString().Split('-')[0]), int.Parse(Pedidos["Destino"].ToString().Split('-')[0]), DTotal, Lotes, Sec, Articulo, Concepto, CantS, CantE, CantR, TotLote, PrecioE, Caja, NoLote, FecCad, ID_MOTIVO_PEDIDO);
                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message, "Traspasos obtener archivo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally
                {

                }
            }
        }

        private void importarTraspaso()
        {
            openFileDialog1.Title = "Selecciona el archivo de traspaso";
            openFileDialog1.Filter = "Archvio de traspaso (*.traspaso)|*.traspaso";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();


            if (openFileDialog1.FileName != "")
            {
                // procesamos el archivo
                try
                {
                    if (!openFileDialog1.CheckFileExists)
                    {
                       MessageBox.Show("El archivo especificado no existe, por favor verifique");
                        return;
                    }




                    string[] lineas = System.IO.File.ReadAllLines(openFileDialog1.FileName);
                    if (lineas.Count() <= 0)
                    {
                       MessageBox.Show("El archivo no tiene información");
                        return;
                    }


                    SIFModelo.Inventarios.InventarioDataSet dtsInventario = new SIFModelo.Inventarios.InventarioDataSet();
                    SIFModelo.Inventarios.InventarioDataSet.TRASPASORow traspaso = null;
                    foreach (string linea in lineas)
                    {

                        string[] traspL = linea.Split(new char[]{'|'});

                        if (linea == lineas[0])
                        {
                            //traspaso.FOLIO + "|" + traspaso.LOTE + "|" + traspaso.FECHA + "|" + traspaso.SUCURSAL_ORIGEN.ToString() + "|" + traspaso.TOTAL + "|" + "0" + "|" +/* traspaso.FECHA_SURTIO*/ "|" + traspaso.USUARIO_ENVIA + "|" + /*traspaso.USUARIO_RECIBE +*/ "|" + traspaso.ACTIVO + "|" + traspaso.SUCURSAL_DESTINO.ToString();
                            traspaso = dtsInventario.TRASPASO.NewTRASPASORow();
                            traspaso.FOLIO = traspL[0];
                            traspaso.REFERENCIA= traspL[0];
                            traspaso.LOTE = short.Parse(traspL[1]);
                            traspaso.FECHA = traspL[2];
                            traspaso.SUCURSAL_ORIGEN =  short.Parse(traspL[3]);
                            traspaso.TOTAL = decimal.Parse(traspL[4]);
                            traspaso.USUARIO_RECIBE = traspL[5];
                            //traspaso.FECHA_SURTIDO = traspL[6];
                            traspaso.USUARIO_ENVIA = traspL[7];
                            traspaso.ACTIVO = traspL[9];
                            traspaso.SUCURSAL_DESTINO = short.Parse( traspL[10]);
                            continue;
                        }


                         //detalle["PEDIDO"] + "|" + detalle["LOTE"] + "|" + detalle["PARTIDA"] + "|" + detalle["ID"] + "|" +  detalle["NOMBRE"] + "|" + detalle["PEDIDO"] + "|" + detalle["ENVIADO"] + "|" + detalle["COSTO"] + "|" + ""/*detalle["PRECIO_RECIBE"]*/ + "|"  detalle["CAJA"].ToString() + "|" + detalle["INCIDENCIA"] + "|" + detalle["DEVUELTA"];//+ detalle.TIPO_MEDIC;
                        SIFModelo.Inventarios.InventarioDataSet.TRASPASO_DETRow traspDet = dtsInventario.TRASPASO_DET.NewTRASPASO_DETRow();
                        traspDet.FOLIO = traspL[0];
                        traspDet.LOTE = short.Parse(traspL[1]);
                        traspDet.NUM_PARTIDA = short.Parse(traspL[2]);
                        traspDet.ARTICULO_ID = traspL[3];
                        traspDet.CONCEPTO = traspL[4];
                        traspDet.CANTIDAD_SOLICITADA = int.Parse(traspL[5]);
                        traspDet.CANTIDAD_ENVIADA = int.Parse(traspL[6]);
                        traspDet.PRECIO_ENVIA = double.Parse(traspL[7]);
                        traspDet.CANTIDAD_RECIBIDA = 0;
                        traspDet.CAJA = short.Parse(traspL[9]);
                        traspDet.SOLICITADO = "S";
                        dtsInventario.TRASPASO_DET.AddTRASPASO_DETRow(traspDet);
                    }

                    //INSERTAR EL LOTE Y CADUCIDAD

                    this.TraspasoAlmacen.InsertaTraspasoAlmacen(Helpers.Sesion.Usuario.UsuariosID.ToString(), traspaso, dtsInventario.TRASPASO_DET, traspaso.ID_MOTIVO_TRANS);

                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message, "Traspasos obtener archivo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally
                {

                }
            }

        }

        private void buscarBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Buscar();
        }

        private void foliotextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Buscar();
            }
        }

        private void IncidenciasButtonItem_Click(object sender, EventArgs e)
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Seleccione la cabecera del traspaso");
                return;
            }
            var row = (GridRow)container;

            if (!ValidaOrigenDestinoExistente(row))
            {
                return;
            }

            string TraspasoID = row.Cells[1].Value.ToString();
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Recepcion_traspaso_incidencias.rpt", "{TRASPASO.FOLIO}='" + TraspasoID.ToString() + "' AND {TRASPASO_DET.INCIDENCIA} <> 0.00  AND {INV_TRASPASO.SUCURSAL_ID} = {TRASPASO.SUCURSAL_DESTINO}");
            Impresion.ShowDialog();
        }

        private void noPedidoButtonItem_Click(object sender, EventArgs e)
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Seleccione la cabecera del traspaso");
                return;
            }
            var row = (GridRow)container;

            if (!ValidaOrigenDestinoExistente(row))
            {
                return;
            }

            string TraspasoID = row.Cells[1].Value.ToString();
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Producto_no_pedido.rpt", "{TRASPASO.FOLIO}='" + TraspasoID.ToString() + "'  AND {INV_TRASPASO.SUCURSAL_ID} = {TRASPASO.SUCURSAL_DESTINO} AND  ({TRASPASO_DET.SOLICITADO} = 'X' OR {TRASPASO_DET.SOLICITADO} = 'D')");
            Impresion.ShowDialog();
        }

        private void rB_Devolcion_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_Devolcion.Checked)
            {
                Cual = 4;
                this.Buscar();
            }

        }
    }
}
