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

namespace SIF.View.Almacen
{
    public partial class IncidenciasAlmacenUserControl : Templates.ListaUserControl
    {
        private int Cual = 0;
        SIFNegocio.Inventario.Traspasos TraspasoAlmacen = new SIFNegocio.Inventario.Traspasos();
        SIFModelo.Inventarios.InventarioDataSet DsPedidosTrasp;
        public IncidenciasAlmacenUserControl()
        {
            InitializeComponent();
            this.dateTimeInput1.Value = DateTime.Parse("01/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year.ToString());
            this.dateTimeInput2.Value = DateTime.Parse(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year.ToString());
            Privilegios();
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 21, int.Parse(Xbtn.Tag.ToString()));
            }

        }
        IncidenciaAlmacenUserControl frmTraspaso = new IncidenciaAlmacenUserControl();
        private void Nuevo()
        {
            if (!frmTraspaso.Mostrado)
            {
                frmTraspaso = new IncidenciaAlmacenUserControl();
                frmTraspaso.Owner = this;
                frmTraspaso.Muestra();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        public bool Mostrado { get; set; }

        public MainForm Owner { get; set; }

        public void Muestra()
        {
            if (Mostrado)
            {
                return;
            }

            this.Dock = DockStyle.Fill;
            Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
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
            try
            {
                Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
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

            switch (Cual)
            {
                case 0:
                    DsPedidosTrasp = traspasoAlmacen.GetTraspasos(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "I", foliotextBoxX.Text, Helpers.Sesion.Sucursal.SucursalesID, "E");
                    break;
                case 2:
                    DsPedidosTrasp = traspasoAlmacen.GetTraspasos(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "X", foliotextBoxX.Text, Helpers.Sesion.Sucursal.SucursalesID, "E");
                    break;
                case 3:
                    DsPedidosTrasp = traspasoAlmacen.GetTraspasos(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "", foliotextBoxX.Text, Helpers.Sesion.Sucursal.SucursalesID, "E");
                    break;

            }


            DsPedidosTrasp.Relations.Add("1", DsPedidosTrasp.Tables["TRASPASO"].Columns["FOLIO"],
                                              DsPedidosTrasp.Tables["TRASPASO_DET"].Columns["FOLIO"], false);
            DsPedidosTrasp.TRASPASO.DefaultView.Sort = "fecha desc";
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

        private void Envia()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);
            var row = (GridRow)container;

            if (!frmTraspaso.Mostrado)
            {
                frmTraspaso = new IncidenciaAlmacenUserControl();
                frmTraspaso.TraspasoID = Int64.Parse(row.Cells[0].Value.ToString());
                frmTraspaso.lote = int.Parse(row.Cells[1].Value.ToString());
                frmTraspaso.SucursalO = row.Cells[3].Value.ToString();
                frmTraspaso.SucursalD = row.Cells[4].Value.ToString();
                frmTraspaso.Usr_Envia = row.Cells[5].Value.ToString();
                frmTraspaso.Owner = this;
                frmTraspaso.Muestra();
            }

        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            this.Envia();

        }
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
            if (!row.Cells["ACTIVO"].Value.ToString().Contains('X'))
            {
                if (MessageBoxEx.Show("¿Cancelar el Traspaso " + row.Cells[0].Value.ToString()
                                                           + " - "
                                                           + row.Cells[1].Value.ToString() + "?",
                                  ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (CancelTraspaso(row.Cells[0].Value.ToString(),
                                      row.Cells[1].Value.ToString()) > 0)
                        row.Cells["ACTIVO"].Value = "X";

            }
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            this.cancela();
            this.Buscar();
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
            this.Envia();
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
            if (!row.Cells["ACTIVO"].Value.ToString().Contains('X') & !row.Cells["ACTIVO"].Value.ToString().Contains('R'))
            {
                SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Incidencia_Recepcion_Almacen.rpt", "{TRASPASO.FOLIO}='" + row.Cells[0].Value.ToString() + "'");
                Impresion.ShowDialog();
            }
            else
                if (row.Cells["ACTIVO"].Value.ToString().Contains('R'))
                   MessageBox.Show("El Traspaso no se a recibido", "Traspasos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                   MessageBox.Show("El Traspaso esta cancelado", "Traspasos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void superGridControl1_Click(object sender, EventArgs e)
        {

        }

        private void superGridControl1_DoubleClick(object sender, EventArgs e)
        {
            this.Envia();
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
            if (!row.Cells["ACTIVO"].Value.ToString().Contains('X'))
            {
                int SucPed = int.Parse(row.Cells[4].Value.ToString().Split('-')[0]);
                if (SucPed == Helpers.Sesion.Sucursal.SucursalID)
                {
                    if (MessageBoxEx.Show("¿Cerrar el Traspaso " + row.Cells[0].Value.ToString()
                                                            + " - "
                                                            + row.Cells[1].Value.ToString() + "?",
                                    ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (CierraTraspaso(row.Cells[0].Value.ToString(),
                                          row.Cells[1].Value.ToString()) > 0)
                            row.Cells["ACTIVO"].Value = "C";
                    this.Buscar();
                }
                else
                {
                   MessageBox.Show("Debe ser la misma sucursal destino verificar configuracion", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void buttonItem2_Click(object sender, EventArgs e)
        {
            this.Cerrar();
        }

        private void buttonItem2_Click_1(object sender, EventArgs e)
        {
            this.Cerrar();
            imprimir();
        }

        private void AbrirArchivo()
        {
            openFileDialog1.Title = "Selecciona el archivo de traspaso";
            openFileDialog1.FileName = "";
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
                    
                    /// AVM 13-04-2015
                    /// OBTENER EL MOTIVO DEL ARCHIVO DE EXCEL    
                    int ID_MOTIVO = 0;

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
                   TraspasoAlmacen.InsertaTraspasoAlmacen(Helpers.Sesion.Usuario.UsuariosID.ToString(), int.Parse(Pedidos["Origen"].ToString().Split('-')[0]), int.Parse(Pedidos["Destino"].ToString().Split('-')[0]), DTotal, Lotes, Sec, Articulo, Concepto, CantS, CantE, CantR, TotLote, PrecioE, Caja, NoLote, FecCad,ID_MOTIVO);
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
        private void buttonItem4_Click_1(object sender, EventArgs e)
        {
            AbrirArchivo();
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

        private void buttonItem1_Click_1(object sender, EventArgs e)
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);
            var row = (GridRow)container;
            if (row == null)
            {
               MessageBox.Show("Elija el registro a mostrar");
                return;
            }
            if (!frmTraspaso.Mostrado)
            {
                frmTraspaso = new IncidenciaAlmacenUserControl();
                frmTraspaso.TraspasoID = Int64.Parse(row.Cells[1].Value.ToString());
                frmTraspaso.lote = int.Parse(row.Cells[2].Value.ToString());
                frmTraspaso.SucursalO = row.Cells[4].Value.ToString();
                frmTraspaso.SucursalD = row.Cells[5].Value.ToString();
                frmTraspaso.Usr_Envia = row.Cells[6].Value.ToString();
                frmTraspaso.Owner = this;
                frmTraspaso.Muestra();
            }
        }


    }
}
