using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using System.IO;
using System.Text.RegularExpressions;

namespace SIF.View.Inventario
{
    public partial class PedidosAlmacenUserControl : Templates.ListaUserControl
    {
        SIFModelo.Inventarios.InventarioDataSet DsPedidosTrasp;
        int Cual = 0;
        public PedidosAlmacenUserControl()
        {
            InitializeComponent();
            //this.dateTimeInput1.Value = DateTime.Parse("01/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year.ToString());
            //this.dateTimeInput2.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor().AddHours(23);
            this.dateTimeInput1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            this.dateTimeInput2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            Privilegios();

            GridLabelXEditControl editC = this.superGridControl1.PrimaryGrid.Columns["FECHA_COLUMN"].EditControl as GridLabelXEditControl;
            //editC.
            // editC.EditorFormattedValue = "";
            if(Helpers.Sesion.Sucursal.SucursalesID == 13 )
                this.superGridControl1.PrimaryGrid.Columns[9].Visible = true;
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 29, int.Parse(Xbtn.Tag.ToString()));
            }

        }

        PedidoAlmacenUserControl frmPedido = new PedidoAlmacenUserControl();

        private void Nuevo()
        {
            if (!frmPedido.Mostrado)
            {
                frmPedido = new PedidoAlmacenUserControl();
                frmPedido.Owner = this;
                frmPedido.Muestra();
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
        SIFNegocio.Inventario.PedidosAlmacen pedidoAlmacen = new SIFNegocio.Inventario.PedidosAlmacen();
        public void Buscar()
        {

            switch (Cual)
            {
                case 0:
                    //                    DsPedidosTrasp = pedidoAlmacen.PedidosTraspasos(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "S", foliotextBoxX.Text);
                    DsPedidosTrasp = pedidoAlmacen.PedidosTraspasos(dateTimeInput1.Value, dateTimeInput2.Value, "S", foliotextBoxX.Text);
                    break;
                case 1:
                    //                    DsPedidosTrasp = pedidoAlmacen.PedidosTraspasos(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "P", foliotextBoxX.Text);
                    DsPedidosTrasp = pedidoAlmacen.PedidosTraspasos(dateTimeInput1.Value, dateTimeInput2.Value, "P", foliotextBoxX.Text);
                    break;
                case 2:
                    //                    DsPedidosTrasp = pedidoAlmacen.PedidosTraspasos(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "X", foliotextBoxX.Text);
                    DsPedidosTrasp = pedidoAlmacen.PedidosTraspasos(dateTimeInput1.Value, dateTimeInput2.Value, "X", foliotextBoxX.Text);
                    break;
                case 3:
                    DsPedidosTrasp = pedidoAlmacen.PedidosTraspasos(dateTimeInput1.Value, dateTimeInput2.Value, "", foliotextBoxX.Text);
                    break;
            }


            SIFModelo.Inventarios.InventarioDataSet DsPedidosTrasp2;


            //DsPedidosTrasp.Relations.Add("1",DsPedidosTrasp.Tables["PEDIDO_TRASP"].Columns["FOLIO"],
            //                                  DsPedidosTrasp.Tables["PEDIDO_TRASP_DET1"].Columns["FOLIO"], false);

            //DsPedidosTrasp.Relations.Add("2", DsPedidosTrasp.Tables["PEDIDO_TRASP"].Columns["LOTE"],
            //                                  DsPedidosTrasp.Tables["PEDIDO_TRASP_DET1"].Columns["LOTE"], false);
            DsPedidosTrasp.PEDIDO_TRASP.DefaultView.Sort = "fecha desc";

            this.superGridControl1.PrimaryGrid.DataSource = DsPedidosTrasp;
            this.superGridControl1.PrimaryGrid.DataMember = "PEDIDO_TRASP";


            foreach (SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASPRow row in DsPedidosTrasp.PEDIDO_TRASP.Rows)
            {
                object total = DsPedidosTrasp.PEDIDO_TRASP_DET1.Compute("SUM(CANTIDAD_SOLIC)", "FOLIO = '" + row.FOLIO + "' AND LOTE = " + row.LOTE);
                if (total.ToString().IsFloat())
                {
                    row.TOTAL = System.Convert.ToDecimal(total);
                }
            }

            // this.superGridControl1.PrimaryGrid.AutoGenerateColumns = true;
        }

        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void PedidosAlmacenUserControl_Load(object sender, EventArgs e)
        {
            superGridControl1.PrimaryGrid.MultiSelect = true;
        }

        private void nuevoPedidoButtonItem_Click(object sender, EventArgs e)
        {
            this.Nuevo();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            //this.Envia();
            // ROMA 14AGO2013
            ////this.EnviaSIF2();
            this.EnviaPedidoTraspaso();
            // ROMA 14AGO2013
        }

        // ROMA 14AGO2013
        private void EnviaSIF2()
        {
            String ProductName = "Pedidos Almacen";

            GridPanel panel = superGridControl1.PrimaryGrid;
            if (panel.ActiveRow == null)
            {
                return;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Seleccione la cabecera del Pedido");
                return;
            }
            var row = (GridRow)container;
            if (row.Cells["ACTIVO_COLUMN"].Value.ToString().Contains('S'))
            {
                if (MessageBoxEx.Show("¿Enviar el pedido: " + row.Cells["FOLIO_COLUMN"].Value.ToString()
                                                                    + " - " + row.Cells["LOTE_COLUMN"].Value.ToString()
                                                                    + "?",
                                ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    pedidoAlmacen.UpdateEdoPedido(row.Cells[0].Value.ToString(), row.Cells["LOTE_COLUMN"].Value.ToString());
                }
            }
            else
            {
                if (row.Cells["ACTIVO_COLUMN"].Value.ToString().Contains('P'))
                   MessageBox.Show("El pedido ya se envio", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                   MessageBox.Show("El pedido esta cancelado", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Buscar();

        }

        private void EnviaPedidoTraspaso()
        {
            string pError = "Error";
            string Resul = string.Empty;

            GridPanel panel = superGridControl1.PrimaryGrid;
            if (panel.ActiveRow == null)
            {
                return;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Seleccione la cabecera del Pedido");
                return;
            }
            var row = (GridRow)container;
            if (row.Cells["ACTIVO_COLUMN"].Value.ToString().Contains('S'))
            {
                if (MessageBoxEx.Show("¿Enviar el pedido: " + row.Cells["FOLIO_COLUMN"].Value.ToString()
                                                                    + " - " + row.Cells["LOTE_COLUMN"].Value.ToString()
                                                                    + "?",
                                ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Resul = pedidoAlmacen.CreaPedidoTraspaso(row.Cells[0].Value.ToString(), row.Cells["LOTE_COLUMN"].Value.ToString(),
                    int.Parse(row.Cells["ORIGEN_COLUMN"].Value.ToString().Split('-')[0]),
                    int.Parse(row.Cells["DESTINO_COLUMN"].Value.ToString().Split('-')[0]));

                    if ( !Regex.IsMatch(Resul, pError))
                    {
                        this.Buscar();
                    }

                   MessageBox.Show(Resul, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                if (row.Cells["ACTIVO_COLUMN"].Value.ToString().Contains('P'))
                   MessageBox.Show("El pedido ya se envio", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                   MessageBox.Show("El pedido esta cancelado", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // ROMA 14AGO2013

        private void Envia()
        {
            // enviar pedido
            DataTable dtPedido = new DataTable();

            dtPedido.Columns.Add("lote", typeof(int));
            dtPedido.Columns.Add("id", typeof(string));
            dtPedido.Columns.Add("nombre", typeof(string));
            dtPedido.Columns.Add("cantidad", typeof(int));
            dtPedido.Columns.Add("precio", typeof(double));
            dtPedido.Columns.Add("total", typeof(double), "cantidad * precio");
            dtPedido.PrimaryKey = new DataColumn[] { dtPedido.Columns["id"] };

            String ProductName = "Pedidos Almacen";

            GridPanel panel = superGridControl1.PrimaryGrid;
            if (panel.ActiveRow == null)
            {
                return;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Seleccione la cabecera del Pedido");
                return;
            }
            var row = (GridRow)container;
            if (row.Cells["ACTIVO_COLUMN"].Value.ToString().Contains('S'))
            {
                if (MessageBoxEx.Show("¿Enviar el pedido: " + row.Cells["FOLIO_COLUMN"].Value.ToString()
                                                                    + " - " + row.Cells["LOTE_COLUMN"].Value.ToString()
                                                                    + "?",
                                ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    dtPedido = pedidoAlmacen.PedidoDetalle(row.Cells["FOLIO_COLUMN"].Value.ToString(), int.Parse(row.Cells["LOTE_COLUMN"].Value.ToString()));
                    DataRow[] results = dtPedido.Select(null, "lote, id");
                    // IN Pedido Array's
                    int[] Lote = new int[results.Length];
                    int[] Sec = new int[results.Length];
                    String[] Articulo = new String[results.Length];
                    String[] Concepto = new String[results.Length];
                    Double[] Total = new Double[results.Length];
                    int[] Cant = new int[results.Length];
                    int[] CantE = new int[results.Length];
                    int ind = 0, sec = 0;
                    string CtlLote = string.Empty;

                    foreach (DataRow rows in results)
                    {
                        if (CtlLote.Contains(rows["lote"].ToString()))
                        {
                            sec++;
                            Lote[ind] = Convert.ToInt16(rows["lote"].ToString());
                            Sec[ind] = sec;
                            Articulo[ind] = rows["id"].ToString();
                            Concepto[ind] = rows["nombre"].ToString();
                            Cant[ind] = Convert.ToInt16(rows["cantidad"]);
                            CantE[ind] = 0;
                        }
                        else
                        {
                            sec = 0;
                            sec++;
                            CtlLote = rows["lote"].ToString();
                            Lote[ind] = Convert.ToInt16(rows["lote"].ToString());
                            Sec[ind] = sec;
                            Articulo[ind] = rows["id"].ToString();
                            Concepto[ind] = rows["nombre"].ToString();
                            Cant[ind] = Convert.ToInt16(rows["cantidad"]);
                            CantE[ind] = 0;
                            object objSum = dtPedido.Compute("Sum(total)", "lote = " + CtlLote);
                            Total[ind] = Convert.ToDouble(objSum.ToString());
                        }
                        ind++;
                    }
                    pedidoAlmacen.Enviapedidox(row.Cells[0].Value.ToString(), Lote, Convert.ToInt16(row.Cells[3].Value.ToString().Split('-')[0]), Convert.ToInt16(row.Cells[2].Value.ToString().Split('-')[0]),
                        int.Parse(row.Cells[8].Value.ToString()), Sec, Articulo, Concepto, Cant, CantE, Total);
                    ////InsPedido(Convert.ToInt16(cmb_OrigPedido.Text.Split('-')[0]), Convert.ToInt16(cmb_DestPedido.Text.Split('-')[0]), tb_TotalPedido.Value,
                    ////          Lote, Sec, Articulo, Concepto, Cant, Total);
                }
            }
            else
            {
                if (row.Cells["ACTIVO_COLUMN"].Value.ToString().Contains('P'))
                   MessageBox.Show("El pedido ya se envio", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                   MessageBox.Show("El pedido esta cancelado", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Buscar();
        }

        private void cancelar()
        {
            String ProductName = "Pedidos Almacen";
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);
            var row = (GridRow)container;
            if (!row.Cells["ACTIVO_COLUMN"].Value.ToString().Contains('X')) // 6
            {
                if (MessageBoxEx.Show("¿Cancelar el Pedido " + row.Cells["FOLIO_COLUMN"].Value.ToString()
                                                           + " - "
                                                           + row.Cells["LOTE_COLUMN"].Value.ToString() + "?",
                                   ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (pedidoAlmacen.CancelPedido(row.Cells["FOLIO_COLUMN"].Value.ToString(),
                                      row.Cells["LOTE_COLUMN"].Value.ToString()) > 0)
                        row.Cells["ACTIVO_COLUMN"].Value = "X"; // 6
                this.Buscar();
            }
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            this.cancelar();
        }

        private void abrir()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            if (panel.ActiveRow == null)
            {
                return;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Seleccione la cabecera del Pedido");
                return;
            }
            var row = (GridRow)container;
            if (row.Cells["ACTIVO_COLUMN"].Value.ToString().Contains('S'))
            {
                if (!frmPedido.Mostrado)
                {

                    frmPedido = new PedidoAlmacenUserControl();
                    frmPedido.Owner = this;
                    // mandamos el pedido
                    frmPedido.NoPedido = row.Cells[0].Value.ToString();
                    frmPedido.NoLote = int.Parse(row.Cells["LOTE_COLUMN"].Value.ToString());
                    frmPedido.Muestra();

                }
            }
            else
            {
                if (row.Cells["ACTIVO_COLUMN"].Value.ToString().Contains('P'))
                   MessageBox.Show("El Pedido ya se envio", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                   MessageBox.Show("El Pedido esta cancelado", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            abrir();
        }

        private void superGridControl1_DoubleClick(object sender, EventArgs e)
        {
            abrir();
        }

        private void buttonItem1_Click_1(object sender, EventArgs e)
        {
            abrir();
        }

        private void porsurtirRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (porsurtirRadioButton.Checked)
            {
                Cual = 0;
                Buscar();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Cual = 1;
                Buscar();
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Cual = 2;
                Buscar();
            }
        }

        private void creditoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (creditoRadioButton.Checked)
            {
                Cual = 3;
                Buscar();
            }
        }

        //private void Duplicar()
        //{
        //    String ProductName = "Pedidos Almacen";
        //    GridPanel panel = superGridControl1.PrimaryGrid;
        //    if (panel.ActiveRow == null)
        //    {
        //        return;
        //    }

        //    var container = ((GridContainer)panel.ActiveRow);
        //    if (!(container is GridRow))
        //    {
        //       MessageBox.Show("Seleccione la cabecera del Pedido");
        //        return;
        //    }
        //    var row = (GridRow)container;
        //    if (!row.Cells[6].Value.ToString().Contains('X'))
        //    {
        //        if (MessageBoxEx.Show("¿Duplicar el Pedido " + row.Cells[0].Value.ToString()
        //                                                   + " - "
        //                                                   + row.Cells["LOTE"].Value.ToString() + "?",
        //                           ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
        //        {
        //            int NoFolio = pedidoAlmacen.DuplicaPedido(row.Cells[0].Value.ToString(), row.Cells["LOTE"].Value.ToString());
        //        }

        //        this.Buscar();
        //    }
        //}

        private void Duplicar()
        {
            String ProductName = "Pedidos Almacen";
            GridPanel panel = superGridControl1.PrimaryGrid;
            if (panel.ActiveRow == null)
            {
                return;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Seleccione la cabecera del Pedido");
                return;
            }
            var row = (GridRow)container;

            switch (row.Cells["ACTIVO_COLUMN"].Value.ToString())
            {
                case "X":
                   MessageBox.Show("El pedido esta cancelado, NO se puede duplicar", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "S":
                   MessageBox.Show("El pedido esta generado, NO se puede duplicar", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    if (MessageBoxEx.Show("¿Duplicar el Pedido " + row.Cells["FOLIO_COLUMN"].Value.ToString()
                                                               + " - "
                                                               + row.Cells["LOTE_COLUMN"].Value.ToString() + "?",
                                       ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int NoFolio = pedidoAlmacen.DuplicaPedido(row.Cells["FOLIO_COLUMN"].Value.ToString(), row.Cells["LOTE_COLUMN"].Value.ToString());
                        if (NoFolio >= 0)
                            this.Buscar();
                    }

                    break;
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            this.Duplicar();
        }

        private void GeneraArchivo()
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
               MessageBox.Show("Seleccione la cabecera del  Traspaso");
                return;
            }

            // generamos uns archivo para la importacion del traspaso.


            var row = (GridRow)container;
            if (!row.Cells["ACTIVO"].Value.ToString().Contains('X'))
            {
                int[] Lote = new int[2];
                saveFileDialog1.Title = "Dar nombre del archivo para el pedido:";
                saveFileDialog1.FileName = "P" + row.Cells[0].Value.ToString() + ".xml";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    SIFModelo.Inventarios.InventarioDataSet PedidosTrasp = pedidoAlmacen.PedidosTraspasos(dateTimeInput1.Value, dateTimeInput2.Value, "", row.Cells[0].Value.ToString());
                    PedidosTrasp.WriteXml(saveFileDialog1.FileName);
                    Lote[0] = int.Parse(row.Cells["LOTE"].Value.ToString());
                    Lote[1] = 1;
                    pedidoAlmacen.ActEstatus(row.Cells[0].Value.ToString(), Lote);
                    this.Buscar();
                    // actualizamos el status del pedido.
                }
            }
        }

        Boolean almacen50 = false;
        #region ROMA
        private void CrearPedidoEspecial()
        {
            SIFModelo.MotivoPedido MotivoPedidoM;
            String Referencia;

            ImportarPedidoMotivoSelect frmMotivoPedido = new ImportarPedidoMotivoSelect();
            if (DialogResult.OK == frmMotivoPedido.ShowDialog())
            {
                MotivoPedidoM = frmMotivoPedido.MotivoPedidoModel;
                Referencia = frmMotivoPedido.Referencia;

                OpenFileDialog fdlg = new OpenFileDialog();
                fdlg.Title = "Seleccione el archivo a Procesar";
                fdlg.Filter = "CSV files (*.csv)|*.csv";
                fdlg.RestoreDirectory = true;
                bool FmtValid = true;
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    // DataTable Pedido
                    DataTable dtPedido = new DataTable();
                    dtPedido.Columns.Add("id", typeof(string));
                    dtPedido.Columns.Add("cantidad", typeof(int));
                    dtPedido.PrimaryKey = new DataColumn[] { dtPedido.Columns["id"] };

                    StreamReader reader = StreamReader.Null;
                    string str = null;
                    int Regs = 0;
                    string FName = fdlg.SafeFileName;
                    string FPath = Path.GetDirectoryName(fdlg.FileName);
                    string FExt = Path.GetExtension(FName);
                    Regex objNotNumPattern = new Regex(@"[^0-9]");
                    Regex objNotAlphaPattern = new Regex(@"[^a-zA-Z0-9\s]");
                    try
                    {
                        // Valida formato de archivo
                        reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
                        while ((str = reader.ReadLine()) != null)
                        {
                            if (str.Split(',').Count() != 2)
                            {
                                FmtValid = false;
                               MessageBox.Show("El formato de Archivo " + FName + " es Invalido");
                                break;
                            }

                            // Valida id articulo
                            if (objNotAlphaPattern.IsMatch(str.Split(',')[0]))
                            {
                                FmtValid = false;
                               MessageBox.Show("El código de articulo " + str.Split(',')[0] + " es Invalido");
                                break;
                            }

                            // Valida cantidad
                            if (objNotNumPattern.IsMatch(str.Split(',')[1]))
                            {
                                FmtValid = false;
                               MessageBox.Show("La cantidad solictada " + str.Split(',')[1] + " es Invalida");
                                break;
                            }

                        }
                        // Lee archivo
                        string Result = "";
                        if (FmtValid)
                        {
                            reader.Close();
                            reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
                            while ((str = reader.ReadLine()) != null)
                            {
                                DataRow RegArt = dtPedido.Rows.Find(str.Split(',')[0]);
                                if (RegArt == null)
                                {
                                    dtPedido.Rows.Add(str.Split(',')[0],
                                                      str.Split(',')[1]);
                                }

                                Regs++;
                            }

                            DataRow[] results = dtPedido.Select(null, "id");

                            ///
                            //VALIDA QUE LA CANTIDAD DE ACTICULOS AGREGADOS SEA IGUAL O MENOR A LA PERMITIDA
                            if (results.Length >= MotivoPedidoM.MAX_SKUS)
                            {
                                 MessageBox.Show("LA CANTIDAD DE ARTICULOS SOBREPASA LA CANTIDAD PERMITIDA POR EL TIPO DE PEDIDO: " + MotivoPedidoM.NOMBRE);
                                 return;
                            }

                            //recorre cada articulo y valida las reglas;
                            foreach (DataRow rows in results)
                            {
                                String articulo = rows["id"].ToString().Trim();
                                SIFNegocio.Articulo ArtNegocio = new SIFNegocio.Articulo();
                                SIFModelo.Articulo articuloM = new SIFModelo.Articulo();
                                articuloM.ARTICULO_ID = articulo;
                                SIFModelo.Inventarios.Inventario InventarioArt = ArtNegocio.InventarioPorArticulo(articuloM);
                                if (InventarioArt == null)
                                {
                                    MessageBox.Show("EL ARTICULO NO EXISTE EN EL CATÁLOGO: " +
                                           articulo + ", VERIFIQUE EL ARCHIVO.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    return;
                                }

                                #region VALIDAR EOQ EN CASO DE NO VENIR VACIO
                                if (MotivoPedidoM.PARAMETRO_EOQ != "" || !MotivoPedidoM.PARAMETRO_EOQ.Equals(null))
                                {
                                    if (MotivoPedidoM.PARAMETRO_EOQ.Equals("=")) //si es diferente no es igual (==)
                                    {
                                        if (InventarioArt.PuntoDeReorden != MotivoPedidoM.VALOR_EOQ)
                                        {
                                            MessageBox.Show("EL EOQ DEL ARTICULO ES DIFERENTE DE: (" + MotivoPedidoM.VALOR_EOQ + ")"+
                                             "\n" +"\n" + "LA REGLA DEL TIPO DE PEDIDO: (" + MotivoPedidoM.NOMBRE + ") NO SE CUMPLE. " + "\n" + "\n" + "ARTICULO: " + articulo, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            return;
                                        }

                                    }
                                    else if (MotivoPedidoM.PARAMETRO_EOQ.Equals(">"))
                                    {
                                        if (InventarioArt.PuntoDeReorden <= MotivoPedidoM.VALOR_EOQ)
                                        {
                                            MessageBox.Show("EL EOQ DEL ARTICULO ES MENOR O IGUAL A: (" + MotivoPedidoM.VALOR_EOQ + ")"+
                                             "\n" +"\n" + "LA REGLA DEL TIPO DE PEDIDO: (" + MotivoPedidoM.NOMBRE + ") NO SE CUMPLE. " + "\n" + "\n" + "ARTICULO: " + articulo, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            return;
                                        }
                                    } 
                                    else if (MotivoPedidoM.PARAMETRO_EOQ.Equals("<"))
                                    {
                                        if (InventarioArt.PuntoDeReorden >= MotivoPedidoM.VALOR_EOQ)
                                        {
                                            MessageBox.Show("EL EOQ DEL ARTICULO ES MAYOR O IGUAL A: (" + MotivoPedidoM.VALOR_EOQ + ")" +
                                             "\n" + "\n" + "LA REGLA DEL TIPO DE PEDIDO: (" + MotivoPedidoM.NOMBRE + ") NO SE CUMPLE. " + "\n" + "\n" + "ARTICULO: " + articulo, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            return;
                                        }
                                    }
                                    else if (MotivoPedidoM.PARAMETRO_EOQ.Equals(">="))
                                    {
                                        if (InventarioArt.PuntoDeReorden < MotivoPedidoM.VALOR_EOQ)
                                        {
                                            MessageBox.Show("EL EOQ DEL ARTICULO ES MENOR A: (" + MotivoPedidoM.VALOR_EOQ + ")" +
                                             "\n" + "\n" + "LA REGLA DEL TIPO DE PEDIDO: (" + MotivoPedidoM.NOMBRE + ") NO SE CUMPLE. " + "\n" + "\n" + "ARTICULO: " + articulo, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            return;
                                        }
                                    }
                                    else if (MotivoPedidoM.PARAMETRO_EOQ.Equals("<="))
                                    {
                                        if (InventarioArt.PuntoDeReorden > MotivoPedidoM.VALOR_EOQ)
                                        {
                                            MessageBox.Show("EL EOQ DEL ARTICULO ES MAYOR A: (" + MotivoPedidoM.VALOR_EOQ + ")" +
                                             "\n" + "\n" + "LA REGLA DEL TIPO DE PEDIDO: (" + MotivoPedidoM.NOMBRE + ") NO SE CUMPLE. " + "\n" + "\n" + "ARTICULO: " + articulo, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            return;
                                        }
                                    }
                                    else if (MotivoPedidoM.PARAMETRO_EOQ.Equals("<>")) // si son iguales no es diferente de (<>)
                                    {
                                        if (InventarioArt.PuntoDeReorden == MotivoPedidoM.VALOR_EOQ)
                                        {
                                            MessageBox.Show("EL EOQ DEL ARTICULO ES IGUAL A: (" + MotivoPedidoM.VALOR_EOQ + ")" +
                                             "\n" + "\n" + "LA REGLA DEL TIPO DE PEDIDO: (" + MotivoPedidoM.NOMBRE + ") NO SE CUMPLE. " + "\n" + "\n" + "ARTICULO: " + articulo, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            return;
                                        }
                                    }
                                }
                                #endregion VALIDAR EOQ EN CASO DE NO VENIR VACIO

                                #region VALIDAR EXISTENCIA EN CASO DE NO VENIR VACIO
                                if (MotivoPedidoM.PARAMETRO_EXIS != " " || !MotivoPedidoM.PARAMETRO_EXIS.Equals(null))
                                {
                                    if (MotivoPedidoM.PARAMETRO_EXIS.Equals("=")) //si es diferente no es igual (==)
                                    {
                                        if (InventarioArt.Existencias != MotivoPedidoM.VALOR_EXIS)
                                        {
                                            MessageBox.Show("LA EXISTENCIA DEL ARTICULO ES DIFERENTE DE: (" + MotivoPedidoM.VALOR_EXIS + ")" +
                                             "\n" + "\n" + " LA REGLA DEL TIPO PEDIDO: (" + MotivoPedidoM.NOMBRE + ") NO SE CUMPLE.  " + "\n" + "\n" + "ARTICULO: " + articulo, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            return;
                                        }

                                    }
                                    else if (MotivoPedidoM.PARAMETRO_EXIS.Equals(">"))
                                    {
                                        if (InventarioArt.Existencias <= MotivoPedidoM.VALOR_EXIS)
                                        {
                                            MessageBox.Show("LA EXISTENCIA DEL ARTICULO ES MENOR O IGUAL A: (" + MotivoPedidoM.VALOR_EXIS + ")" +
                                             "\n" + "\n" + " LA REGLA DEL TIPO PEDIDO: (" + MotivoPedidoM.NOMBRE + ") NO SE CUMPLE.  " + "\n" + "\n" + "ARTICULO: " + articulo, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            return;
                                        }
                                    }
                                    else if (MotivoPedidoM.PARAMETRO_EXIS.Equals("<"))
                                    {
                                        if (InventarioArt.Existencias >= MotivoPedidoM.VALOR_EXIS)
                                        {
                                            MessageBox.Show("LA EXISTENCIA DEL ARTICULO ES MAYOR O IGUAL A: (" + MotivoPedidoM.VALOR_EXIS + ")" +
                                             "\n" + "\n" + " LA REGLA DEL TIPO PEDIDO: (" + MotivoPedidoM.NOMBRE + ") NO SE CUMPLE.  " + "\n" + "\n" + "ARTICULO: " + articulo, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            return;
                                        }
                                    }
                                    else if (MotivoPedidoM.PARAMETRO_EXIS.Equals(">="))
                                    {
                                        if (InventarioArt.Existencias < MotivoPedidoM.VALOR_EXIS)
                                        {
                                            MessageBox.Show("LA EXISTENCIA DEL ARTICULO ES MENOR A: (" + MotivoPedidoM.VALOR_EXIS + ")" +
                                              "\n" + "\n" + " LA REGLA DEL TIPO PEDIDO: (" + MotivoPedidoM.NOMBRE + ") NO SE CUMPLE.  " + "\n" + "\n" + "ARTICULO: " + articulo, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            return;
                                        }
                                    }
                                    else if (MotivoPedidoM.PARAMETRO_EXIS.Equals("<="))
                                    {
                                        if (InventarioArt.Existencias > MotivoPedidoM.VALOR_EXIS)
                                        {
                                            MessageBox.Show("LA EXISTENCIA DEL ARTICULO ES MAYOR A: (" + MotivoPedidoM.VALOR_EXIS + ")" +
                                             "\n" + "\n" + " LA REGLA DEL TIPO PEDIDO: (" + MotivoPedidoM.NOMBRE + ") NO SE CUMPLE.  " + "\n" + "\n" + "ARTICULO: " + articulo, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            return;
                                        }
                                    }
                                    else if (MotivoPedidoM.PARAMETRO_EXIS.Equals("<>")) // si son iguales no es diferente de (<>)
                                    {
                                        if (InventarioArt.Existencias == MotivoPedidoM.VALOR_EXIS)
                                        {
                                            MessageBox.Show("LA EXISTENCIA DEL ARTICULO ES IGUAL A: (" + MotivoPedidoM.VALOR_EXIS + ")" +
                                            "\n" + "\n" + " LA REGLA DEL TIPO PEDIDO: (" + MotivoPedidoM.NOMBRE + ") NO SE CUMPLE.  " + "\n" + "\n" + "ARTICULO: " + articulo, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            return;
                                        }
                                    }
                                }
                                #endregion VALIDAR EXISTENCIA EN CASO DE NO VENIR VACIO
                            }
                            ///

                            // IN Pedido Array's
                            String[] Articulo = new String[results.Length];
                            int[] Cant = new int[results.Length];
                            int ind = 0;

                            foreach (DataRow rows in results)
                            {
                                Articulo[ind] = rows["id"].ToString().Trim();
                                Cant[ind] = Convert.ToInt16(rows["cantidad"]);
                                ind++;
                            }

                            Result = pedidoAlmacen.CreaPedidoEspecial(Helpers.Sesion.Usuario.UsuariosID.ToString(), Helpers.Sesion.Sucursal.SucursalID, 1, Articulo, Cant,MotivoPedidoM.ID,Referencia);
                            string msg = "Se creo el pedido con el folio " + Result + Environment.NewLine + "Se procesaron " + Regs.ToString() + ", registros";
                            MessageBox.Show(msg, "Pedido Especial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Buscar();
                        }
                    }
                    catch (Exception ex)
                    {
                       MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        reader.Close();
                    }

                }
            }
        }
        #endregion ROMA

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            ////GeneraArchivo(); ROMA
            CrearPedidoEspecial();
             this.Buscar();
        }

        private void buscarBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Buscar();
        }

        private void foliotextBoxX_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void foliotextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Buscar();
            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {

        }


        private void ExportarArchivo()
        {
            if (this.superGridControl1.PrimaryGrid.SelectedRows.OfType<GridRow>().Count() <= 0)
            {
               MessageBox.Show("Debe seleccionar un pedido");
                return;
            }


            FolderBrowserDialog sfd = new FolderBrowserDialog();

            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            foreach (var row in this.superGridControl1.PrimaryGrid.SelectedRows)
            {

                SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASPRow traspaso = ((DataRowView)((GridRow)row).DataItem).Row as SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASPRow;

                if (traspaso.ACTIVO != "S")
                {
                    MessageBox.Show("El pedido ya no está activo");
                    return;
                }
                
                string[] origenL = traspaso.ORIGEN.Split(new char[] { '-' });
                string[] destinoL = traspaso.DESTINO.Split(new char[] { '-' });

                string norigen = "";
                if (origenL.Length > 1)
                    norigen = origenL[0].Trim();

                string ndestino = "";
                if (destinoL.Length > 1)
                    ndestino = destinoL[0].Trim();

                string titulo = traspaso.FOLIO + "-" + norigen + "-" + ndestino + "-" + traspaso.LOTE +".pedido";
                string url = System.IO.Path.Combine(sfd.SelectedPath, titulo);
                
                if (System.IO.File.Exists(url))
                {
                    var res = MessageBox.Show("El archivo " + titulo + " ya existe, ¿desea reemplazarlo?", "Reemplazar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                        continue;
                    }
                    else
                    {
                        System.IO.File.Delete(url);
                    }
                }

                using (StreamWriter sw = new StreamWriter(url))
                {
                    //SECUENCIA DE PEDIDO TRASPASO
                    string header = traspaso.FOLIO +"|" + traspaso.LOTE + "|" + traspaso.FECHA.ToString("yyyy/MM/dd HH:mm:ss") + "|" + norigen + "|" + traspaso.TOTAL+ "|" + "0" + "|" +/* traspaso.FECHA_SURTIO*/ "|" + traspaso.USUARIO_GENERA + "|" + /*traspaso.USUARIO_RECIBE +*/ "|" + traspaso.ACTIVO + "|" + ndestino;
                    sw.WriteLine(header);


                    var det = new SIFNegocio.Inventario.PedidosAlmacen().GetPedidosTraspaso(traspaso.FOLIO, traspaso.LOTE);

                    foreach (var detalle in det.PEDIDO_TRASP_DET)
                    {
                        SIFModelo.Articulo articuloC = new SIFModelo.Articulo(){ ARTICULO_ID = detalle.ARTICULO_ID};
                        var precios = SIFNegocio.Articulo.PrecioArticulo(articuloC);
                        string sdet = detalle.FOLIO + "|" + detalle.LOTE + "|" + detalle.PARTIDA + "|" + detalle.ARTICULO_ID + "|" + detalle.CANTIDAD_SOLIC + "|" + detalle.CONCEPTO + "|" + precios.COSTO_PROM;
                        sw.WriteLine(sdet);
                    }
                }

                //actualizar el status
                pedidoAlmacen.UpdateEdoPedido(traspaso.FOLIO, traspaso.LOTE.ToString());
            }
           // MessageBox.Show("Se generaron los archivos correctamente");
        }


        private void exportarButtonItem_Click(object sender, EventArgs e)
        {
            ExportarArchivo();
        }
    }
}
