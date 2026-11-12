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
using System.Text.RegularExpressions;
using SIF.View.Ventas;

namespace SIF.View.Inventario
{
    public partial class RecepcionTrapasoAlmacenUserControl : Templates.CatalogoUserControl
    {

        // ROMA 16SEP2013
        delegate void SetComboBoxCellType(int iRowIndex);
        bool bIsComboBox = false;
        bool bInitPedido = false;
        DataGridViewCell currentCell;
        Regex objNotWholePattern = new Regex(@"^-[1-9]+$|^[1-9]+$"); //  [^1-9]\d*$
        Regex objNotSolcitadoPattern = new Regex(@"^(S)$"); // ^(S|D)$

        private void ChangeCellToComboBox(int iRowIndex)
        {

            if (bIsComboBox == false)
            {
                DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

                dgComboCell.DataSource = null;

                DataTable dt = new DataTable();

                SIFNegocio.Inventario.Traspasos TipoDev = new SIFNegocio.Inventario.Traspasos();
                dt = TipoDev.GetTipoDevolucion();
                dgComboCell.DataSource = dt; // TipoDev.GetTipoDevolucion();
                ////dgComboCell.ValueType = typeof(string);
                dgComboCell.ValueMember = "Devolucion"; // "ID";
                dgComboCell.DisplayMember = "Devolucion"; // "NOMBRE";

                Grd_Pedido.Rows[iRowIndex].Cells[Grd_Pedido.CurrentCell.ColumnIndex] = dgComboCell;
                bIsComboBox = true;
            }
        }

        // ROMA 16SEP2013
        private int Partidas;
        public string TraspasoID;
        public int lote;
        public String SucursalO;
        public String SucursalD;
        DataTable dtTraspaso = new DataTable();
        DataTable dtPedido = new DataTable();
        double PrecioArt = 0;
        string TipoArt = string.Empty;
        int NoLote = 0;
        public string Usr_Envia;
        public RecepcionTrapasoAlmacenUserControl()
        {
            InitializeComponent();
            this.CargaSucursalOrigen();
            this.CargaSucursalDestino();
            //this.CargaTipoDevolucion();

            this.CodigoTextBoxX.Focus();
            this.Grd_Pedido.AutoGenerateColumns = false;
        }

        public bool Mostrado { get; set; }

        internal void Muestra()
        {
            if (Mostrado)
            {
                return;
            }

            this.Dock = DockStyle.Fill;
            Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.ActivaComandos();
            this.Owner.DesactivaComandos();
            Mostrado = true;
        }

        private void CargaSucursalOrigen()
        {
            BindingList<SIFModelo.Sucursal> sucursales = new BindingList<SIFModelo.Sucursal>();
            //SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { Nombre = "[TODAS]", SucursalesID = 0 };
            //sucursales.Add(sucursal);
            //sucursales.ToList();d
            List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().Buscar("", "").DataSource as List<SIFModelo.Sucursal>;

            foreach (SIFModelo.Sucursal sucursalBd in sucursalesBD)
            {
                sucursales.Add(sucursalBd);
            }

            SucursalOrigenComboBox.DataSource = sucursales;
            SucursalOrigenComboBox.DisplayMember = "NOMBRE";
            SucursalOrigenComboBox.ValueMember = "SUCURSALESID";
        }

        private void CargaSucursalDestino()
        {
            BindingList<SIFModelo.Sucursal> sucursales = new BindingList<SIFModelo.Sucursal>();
            //SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { Nombre = "[TODAS]", SucursalesID = 0 };
            //sucursales.Add(sucursal);
            //sucursales.ToList();d
            List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().Buscar("", "S").DataSource as List<SIFModelo.Sucursal>;//L 03/01/2013 La letra S en el parámetro indica que solo mostrara los almacenes activos

            foreach (SIFModelo.Sucursal sucursalBd in sucursalesBD)
            {
                sucursales.Add(sucursalBd);
            }

            SucursalDestinoComboBox.DataSource = sucursales;
            SucursalDestinoComboBox.DisplayMember = "NOMBRE";
            SucursalDestinoComboBox.ValueMember = "SUCURSALESID";
        }

        private void CargaTipoDevolucion()
        {
            DataGridViewComboBoxColumn cbTipDev = Grd_Pedido.Columns["TipDev"] as DataGridViewComboBoxColumn;
            SIFNegocio.Inventario.Traspasos TipoDev = new SIFNegocio.Inventario.Traspasos();

            cbTipDev.DataSource = TipoDev.GetTipoDevolucion();
            cbTipDev.DisplayMember = "NOMBRE";
            cbTipDev.ValueMember = "TIPDEV";

            ////bindingSourceTipDev.DataSource = TipoDev.GetTipoDevolucion();

        }

        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);

            this.agregaProductoButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);

        }

        public void AgregaArticulo(string claveArticulo)
        {
            ////bool Existe = true;
            if (string.IsNullOrEmpty(claveArticulo))
            {
                return;
            }

            // ROMA 13AGO2013 EXISTE ARTICULO EN EL PEDIDO
            ////DataRow RegArt = dtTraspaso.Rows.Find(claveArticulo);
            ////if (RegArt == null)
            ////{
            ////    ////if (MessageBoxEx.Show("¿El articulo " + claveArticulo + ", NO fue solicitado desea agregarlo?", ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            ////    ////{
            ////    ////    return;
            ////    ////}
            ////    Existe = false;
            ////}
            // ROMA 13AGO2013

            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(claveArticulo);

            if (articulo == null)
            {
               MessageBox.Show("El artículo no existe en el catalogo");

                return;
            }
            else
            {
                descripcionLabel.Text = articulo.NOMBRE1;
                TipoArt = articulo.TIPO_MEDICAMENTO_CVE;
                NoLote = lote;
                ////if (!Existe)
                ////    NoLote = 99;
                ////else
                ////{
                ////    if (TipoArt.Contains("F1"))
                ////        NoLote = 2;
                ////    else
                ////        NoLote = 1;
                ////}

                // System.Windows.Forms.SendKeys.Send("{TAB}");
            }

            this.AgregaArticulo(articulo);
        }

        SIFNegocio.Inventario.Traspasos traspasoAlmacenL = new SIFNegocio.Inventario.Traspasos();
        SIFModelo.Inventarios.InventarioDataSet.TRASPASORow traspaso;
        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            int cantidad = 1;

            if (this.cantidadTextBoxX.Text.IsIntegerPositive())
                cantidad = int.Parse(this.cantidadTextBoxX.Text);

            CodigoTextBoxX.Text = articulo.ARTICULO_ID;
            cantidadTextBoxX.Focus();
            //LIMPIAMOS TODAS LOS DATOS
            AgregaArticulo();
            CalculaTotal();
        }

        private void ValPedido()
        {
            string CadSol, ArtID = string.Empty;
            int CIncidencia = 0;
            for (int i = 0; i < Grd_Pedido.Columns.Count; i++)
                Grd_Pedido.Columns[i].ReadOnly = true;

            Grd_Pedido.Columns["Recibido"].ReadOnly = false;
            Grd_Pedido.Columns["Recibe"].ReadOnly = false;
            foreach (DataGridViewRow row in Grd_Pedido.Rows)
            {
                CadSol = row.Cells["Solicita"].Value.ToString();
                ArtID = row.Cells["ID"].Value.ToString();
                CIncidencia = int.Parse(row.Cells["Incidencia"].Value.ToString());
                switch (CadSol)
                {
                    case "S":
                    case "A":
                        row.Cells["Recibe"].Value = true;
                        break;
                    default:
                        row.Cells["Recibe"].Value = false;
                        break;
                }

                if (CodigoTextBoxX.Text.Contains(ArtID))
                {
                    row.Selected = true;
                    int ren = row.Cells["ID"].RowIndex;
                    Grd_Pedido.FirstDisplayedCell = Grd_Pedido[row.Cells["ID"].ColumnIndex, ren];
                }

                // Color Incidencia
                if (CIncidencia > 0) //Positivo
                {
                    Grd_Pedido[row.Cells["Incidencia"].ColumnIndex, row.Cells["Incidencia"].RowIndex].Style.ForeColor = Color.Blue;
                }
                else if (CIncidencia < 0) // Negativo
                {
                    Grd_Pedido[row.Cells["Incidencia"].ColumnIndex, row.Cells["Incidencia"].RowIndex].Style.ForeColor = Color.Red;
                }
                else // Cero
                {
                    Grd_Pedido[row.Cells["Incidencia"].ColumnIndex, row.Cells["Incidencia"].RowIndex].Style.ForeColor = Color.Black;
                }
            }
        }

        private void InicializaPedido()
        {
            foliotextBoxX.Text = TraspasoID.ToString();
            SucursalOrigenComboBox.Text = SucursalO;
            SucursalDestinoComboBox.Text = SucursalD;
            //dtTraspaso = traspasoAlmacenL.GetTraspasoDet(TraspasoID.ToString(), lote);
            dtTraspaso = traspasoAlmacenL.GetTraspasoDetalle(TraspasoID.ToString(), lote);
            ////dtTraspaso.Columns.Remove("total");
            ////dtTraspaso.Columns.Add("total", typeof(double), "Recibido * Costo");
            ////Partidas = dtTraspaso.Rows.Count + 1;
            //dtTraspaso.DefaultView.RowFilter="Recibido>0";

            // ROMA 13AGO2013
            ////dtTraspaso.PrimaryKey = new DataColumn[] { dtTraspaso.Columns["id"] };
            // ROMA 13AGO2013

            Grd_Pedido.DataSource = dtTraspaso;
            // lineasLabel.Text = dtTraspaso.Rows.Count.ToString();
            string CadSol, ArtID = string.Empty;
            int CIncidencia = 0;
            for (int i = 0; i < Grd_Pedido.Columns.Count; i++)
                Grd_Pedido.Columns[i].ReadOnly = true;

            Grd_Pedido.Columns["Recibido"].ReadOnly = false;
            Grd_Pedido.Columns["Recibe"].ReadOnly = false;
            Grd_Pedido.Columns["ColTipDev"].ReadOnly = false;
            foreach (DataGridViewRow row in Grd_Pedido.Rows)
            {
                CadSol = row.Cells["Solicita"].Value.ToString();
                ArtID = row.Cells["ID"].Value.ToString();
                CIncidencia = int.Parse(row.Cells["Incidencia"].Value.ToString());
                switch (CadSol)
                {
                    case "S":
                    case "A":
                        row.Cells["Recibe"].Value = true;
                        break;
                    default:
                        row.Cells["Recibe"].Value = false;
                        break;
                }

                if (CodigoTextBoxX.Text.Contains(ArtID))
                {
                    row.Selected = true;
                    int ren = row.Cells["ID"].RowIndex;
                    Grd_Pedido.FirstDisplayedCell = Grd_Pedido[row.Cells["ID"].ColumnIndex, ren];

                    //Grd_Pedido.FirstDisplayedScrollingRowIndex = ren;                    
                    //Grd_Pedido.CurrentCell = Grd_Pedido.Rows[ren].Cells[0];
                    ////Grd_Pedido.FirstDisplayedCell = Grd_Pedido["Articulo", row.Cells["Articulo"].RowIndex];
                }

                // Color Incidencia
                if (CIncidencia > 0) //Positivo
                {
                    Grd_Pedido[row.Cells["Incidencia"].ColumnIndex, row.Cells["Incidencia"].RowIndex].Style.ForeColor = Color.Blue;
                }
                else if (CIncidencia < 0) // Negativo
                {
                    Grd_Pedido[row.Cells["Incidencia"].ColumnIndex, row.Cells["Incidencia"].RowIndex].Style.ForeColor = Color.Red;
                }
                else // Cero
                {
                    Grd_Pedido[row.Cells["Incidencia"].ColumnIndex, row.Cells["Incidencia"].RowIndex].Style.ForeColor = Color.Black;
                }
            }
            CalculaTotal();
        }

        private void SeleccionaArticulo()
        {
            View.Articulos.ArticuloUserControl frmArticulo = new Articulos.ArticuloUserControl();

            //if (frmArticulo == null)
            //{
            // frmArticulo = new Articulos.ArticuloUserControl();
            frmArticulo.Dock = DockStyle.Fill;
            frmArticulo.Owner = this;

            //}
            this.cantidadTextBoxX.Text = "1";
            frmArticulo.Muestra();
            //frmArticulo.Owner = this;
            //this.Owner.Owner.ShowModalPanel(frmArticulo, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            //this.DesactivaComandos();
            //frmArticulo.ActivaComandos();
        }

        public void Back()
        {
            try
            {
                Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.DesactivaComandos();
                this.Owner.ActivaComandos();
                Mostrado = false;
                Owner.Buscar();
            }
            catch { }
        }

        public void DesactivaComandos()
        {

        }

        public RecepcionTraspasosAlmacenUserControl Owner { get; set; }

        private void CodigoTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.SeleccionaArticulo();
        }

        private void agregaProductoButtonItem_Click(object sender, EventArgs e)
        {
            this.SeleccionaArticulo();
        }

        private void PedidoAlmacenUserControl_Load(object sender, EventArgs e)
        {
            this.InicializaPedido();
        }

        private void porEOQButtonItem_Click(object sender, EventArgs e)
        {
            //   this.GeneraPorEOQ();
        }

        private void cancelarButtonItem_Click(object sender, EventArgs e)
        {
            // this.Cancelar();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void GuardarPedido()
        {
            DataRow[] results = dtTraspaso.Select(null, "caja, id");
            // IN Pedido Array's
            int[] Lote = new int[results.Length];
            int[] Sec = new int[results.Length];
            String[] Articulo = new String[results.Length];
            String[] Concepto = new String[results.Length];
            int[] CantS = new int[results.Length];
            int[] CantE = new int[results.Length];
            int[] CantR = new int[results.Length];
            int[] CantD = new int[results.Length];
            Double[] PrecioE = new Double[results.Length];
            int[] Caja = new int[results.Length];
            String[] Pedido = new String[results.Length];
            String[] NoLote = new String[results.Length];
            String[] FecCad = new String[results.Length];
            String[] TipDev = new String[results.Length]; // ROMA 16SEP2013
            Double Total = 0;
            int sec = 0;
            string CtlFolio = foliotextBoxX.Text;
            object objSum = dtTraspaso.Compute("Sum(total)", "");
            Total = Convert.ToDouble(objSum.ToString());

            foreach (DataRow rowdet in results)
            {
                Sec[sec] = Convert.ToInt16(rowdet["Partida"]); // sec + 1;
                Lote[sec] = Convert.ToInt16(rowdet["Lote"].ToString());
                Articulo[sec] = rowdet["id"].ToString();
                Concepto[sec] = rowdet["nombre"].ToString();
                CantS[sec] = Convert.ToInt16(rowdet["pedido"]);
                CantE[sec] = Convert.ToInt16(rowdet["Enviado"]);
                CantR[sec] = Convert.ToInt16(rowdet["Recibido"]);
                CantD[sec] = Convert.ToInt16(rowdet["Devuelta"]);
                PrecioE[sec] = Convert.ToDouble(rowdet["costo"]);
                Caja[sec] = Convert.ToInt16(rowdet["caja"]);
                Pedido[sec] = rowdet["Solicita"].ToString();
                NoLote[sec] = rowdet["NoLote"].ToString();
                FecCad[sec] = rowdet["FechaCad"].ToString();
                TipDev[sec] = rowdet["devolucion"].ToString();
                sec++;
            }
            int result = traspasoAlmacenL.UpdTraspaso(CtlFolio, Lote, Total, Sec, Articulo, Concepto, CantS, CantE, CantR, CantD, PrecioE, PrecioE, Caja, Pedido, Usr_Envia, Helpers.Sesion.Usuario.Nombre, NoLote, FecCad, TipDev);
            //dtTraspaso.Columns.Add("lote", typeof(int));
            //DataColumn workCol = dtTraspaso.Columns.Add("Partida", typeof(int));
            //dtTraspaso.Columns.Add("id", typeof(string));
            //dtTraspaso.Columns.Add("nombre", typeof(string));
            //dtTraspaso.Columns.Add("Nolote", typeof(string));
            //dtTraspaso.Columns.Add("FechaCad", typeof(string));
            //dtTraspaso.Columns.Add("pedido", typeof(int));
            //dtTraspaso.Columns.Add("enviado", typeof(int));
            //dtTraspaso.Columns.Add("Recibido", typeof(int));
            //dtTraspaso.Columns.Add("Devuelta", typeof(int)); // ROMA 11SEP2013
            //dtTraspaso.Columns.Add("Existencia", typeof(int)); // typeof(double));
            //dtTraspaso.Columns.Add("Costo", typeof(double));
            //dtTraspaso.Columns.Add("caja", typeof(int));
            //dtTraspaso.Columns.Add("solicita", typeof(string));
            //dtTraspaso.Columns.Add("devuelta", typeof(int));
            //dtTraspaso.Columns.Add("devolucion", typeof(string)); // typeof(int));

        }

        private void guardarButtonItem_Click(object sender, EventArgs e)
        {
            GuardarPedido();
            this.Back();
        }

        private decimal CalculaTotal()
        {
            lineasLabel.Text = dtTraspaso.Rows.Count.ToString();

            object objSum = dtTraspaso.Compute("Sum(total)", "");
            decimal total = 0;
            if (objSum.ToString().IsFloat())
            {
                total = System.Convert.ToDecimal(objSum);
            }

            this.label1.Text = total.ToString("C2");

            object objPiezas = dtTraspaso.Compute("Sum(Recibido)", "");
            decimal totalPiezas = 0;
            if (objPiezas.ToString().IsInteger())
            {
                totalPiezas = System.Convert.ToInt32(objPiezas);
                label2.Text = totalPiezas.ToString();
            }

            object objPzasEnvio = dtTraspaso.Compute("Sum(Enviado)", null);
            decimal totalPzasEnv = 0;
            if (objPzasEnvio.ToString().IsInteger())
            {
                totalPzasEnv = System.Convert.ToInt32(objPzasEnvio);
                label2.Text += " / " + totalPzasEnv.ToString();
            }
            else
            {
                label2.Text += " / 0";
            }

            return total;
        }

        private void CodigoTextBoxX_Enter(object sender, EventArgs e)
        {
            this.CodigoTextBoxX.SelectAll();
        }

        private void CodigoTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaArticulo(CodigoTextBoxX.Text);
                InicializaPedido(); // ROMA 21AGO2013
                this.CodigoTextBoxX.SelectAll();
            }

            if (e.KeyCode == Keys.F3)
            {
                this.SeleccionaArticulo();
            }
        }

        private void AgregaArticulo()
        {
            if (SucursalOrigenComboBox.SelectedIndex < 0 ||
                     SucursalDestinoComboBox.SelectedIndex < 0)
            {
               MessageBox.Show("Debe Seleccionar un Origen y Destino", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                SucursalOrigenComboBox.Focus();
                return;
            }
            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(CodigoTextBoxX.Text);

            if (string.IsNullOrEmpty(CodigoTextBoxX.Text) ||
                                   articulo == null)
            {
               MessageBox.Show("Debe seleccionar un articulo", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                CodigoTextBoxX.Focus();
                return;
            }

            //verificamos lote y caducidad
            if (ChkLote.Checked)
            {
                if (string.IsNullOrEmpty(textBoxX1.Text) || string.IsNullOrEmpty(FechaCaducidad.Value.ToString()))
                {
                   MessageBox.Show("Debe dar un No Lote", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxX1.Focus();
                    return;
                }
            }
            // Agrega Articulo
            //obtenemos el costo del articulo
            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
            SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow Invt = inventario.InventarioArticulo(articulo, Helpers.Sesion.Sucursal);
            if (Invt != null)
                PrecioArt = Invt.COSTO_PROM;
            else
                PrecioArt = 0;

            descripcionLabel.Text = articulo.NOMBRE1;

            AddArtTraspaso(NoLote, PrecioArt, 0); //NoCaja
            cantidadTextBoxX.Value = 1;
            CodigoTextBoxX.Focus();
            //object objSum = dtTraspaso.Compute("Sum(total)", null);
            //label1.Text = objSum.ToString();
            //object objSum1 = dtTraspaso.Compute("Sum(recibido)", null);
            //label2.Text = objSum1.ToString();
            //string CadSol, ArtID = string.Empty;
            //int CIncidencia = 0;
            //for (int i = 0; i < Grd_Pedido.Columns.Count; i++)
            //    Grd_Pedido.Columns[i].ReadOnly = true;
            //Grd_Pedido.Columns["Recibido"].ReadOnly = false;
            //Grd_Pedido.Columns["Recibe"].ReadOnly = false;
            //foreach (DataGridViewRow row in Grd_Pedido.Rows)
            //{
            //    CadSol = row.Cells["Solicita"].Value.ToString();
            //    ArtID = row.Cells["ID"].Value.ToString();
            //    CIncidencia = int.Parse(row.Cells["Incidencia"].Value.ToString());
            //    switch (CadSol)
            //    {
            //        case "S":
            //        case "A":
            //            row.Cells["Recibe"].Value = true;
            //            break;
            //        default:
            //            row.Cells["Recibe"].Value = false;
            //            break;
            //    }

            //    if (CodigoTextBoxX.Text.Contains(ArtID))
            //    {
            //        row.Selected = true;
            //        int ren = row.Cells["ID"].RowIndex;
            //        Grd_Pedido.FirstDisplayedCell = Grd_Pedido[row.Cells["ID"].ColumnIndex, ren];
            //        //Grd_Pedido.FirstDisplayedScrollingRowIndex = indx;
            //        //Grd_Pedido.CurrentCell = Grd_Pedido.Rows[indx].Cells[0];
            //    }
            //    // Color Incidencia
            //    if (CIncidencia > 0) //Positivo
            //    {
            //        Grd_Pedido[row.Cells["Incidencia"].ColumnIndex, row.Cells["Incidencia"].RowIndex].Style.ForeColor = Color.Blue;
            //    }
            //    else if (CIncidencia < 0) // Negativo
            //    {
            //        Grd_Pedido[row.Cells["Incidencia"].ColumnIndex, row.Cells["Incidencia"].RowIndex].Style.ForeColor = Color.Red;
            //    }
            //    else // Cero
            //    {
            //        Grd_Pedido[row.Cells["Incidencia"].ColumnIndex, row.Cells["Incidencia"].RowIndex].Style.ForeColor = Color.Black;
            //    }
            //}
        }

        private void cantidadTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            String ProductName = "Traspasos";

            if (e.KeyCode == Keys.Enter)
            {
                AgregaArticulo();
                //this.AgregaArticulo(CodigoTextBoxX.Text);
                InicializaPedido(); // ROMA 21AGO2013

            }
        }

        private void AddArtTraspaso(int Lote, double Precio, int NoCaja)
        {

            ////dtTraspaso.Constraints.Clear(); ROMA13AGO2013 ???????
            //dtTraspaso.DataSet.EnforceConstraints = false;

            //String ProductName = "Traspasos";
            int NoPartida = -1;

            try
            {
                if (cantidadTextBoxX.Text.IsInteger())
                {
                    string fechaCaducidad = "";
                    if (FechaCaducidad.Value != new DateTime())
                    {
                        fechaCaducidad = FechaCaducidad.Value.ToString();
                    }

                    DataRow[] Regs = dtTraspaso.Select("ID='" + CodigoTextBoxX.Text + "'  AND NOLOTE='" + textBoxX1.Text + "' AND FechaCad='" + fechaCaducidad + "'");
                    DataRow RegArt = null;
                    if (Regs.Count() > 0)
                        RegArt = Regs[0];
                    if (RegArt == null)
                    {
                        NoPartida = Convert.ToInt16(dtTraspaso.Compute("MAX(Partida)", null));
                        dtTraspaso.Rows.Add(Lote,
                                          NoPartida + 1, // Partidas,
                                          CodigoTextBoxX.Text,
                                          descripcionLabel.Text,
                                          textBoxX1.Text,
                                          FechaCaducidad.Value.ToString(),
                                          0,
                                          0,
                                          cantidadTextBoxX.Text,
                                          0, // Incidencia ROMA
                                          0,
                                          Precio,
                                          NoCaja,
                                          'X',
                                          cantidadTextBoxX.Text, // Devolucion
                                          0
                        );
                        dtTraspaso.DefaultView.Sort = " PARTIDA DESC, caja, id ASC";
                        Partidas++;
                        //dtTraspaso.Columns.Add("lote", typeof(int));
                        //DataColumn workCol = dtTraspaso.Columns.Add("Partida", typeof(int));
                        //dtTraspaso.Columns.Add("id", typeof(string));
                        //dtTraspaso.Columns.Add("nombre", typeof(string));
                        //dtTraspaso.Columns.Add("Nolote", typeof(string));
                        //dtTraspaso.Columns.Add("FechaCad", typeof(string));
                        //dtTraspaso.Columns.Add("pedido", typeof(int));
                        //dtTraspaso.Columns.Add("enviado", typeof(int));
                        //dtTraspaso.Columns.Add("Recibido", typeof(int));
                        //dtTraspaso.Columns.Add("Devuelta", typeof(int)); // ROMA 11SEP2013
                        //dtTraspaso.Columns.Add("Existencia", typeof(int)); // typeof(double));
                        //dtTraspaso.Columns.Add("Costo", typeof(double));
                        //dtTraspaso.Columns.Add("caja", typeof(int));
                        //dtTraspaso.Columns.Add("solicita", typeof(string));
                    }
                    else
                    {
                        RegArt["Recibido"] = Convert.ToInt16(RegArt["Recibido"].ToString()) + Convert.ToInt16(cantidadTextBoxX.Text);
                        ////RegArt["Incidencia"] = Convert.ToInt16(RegArt["Recibido"].ToString()) - Convert.ToInt16(RegArt["Enviado"].ToString());
                        //dtTraspaso.Columns.Add("enviado", typeof(int));
                        //dtTraspaso.Columns.Add("Recibido", typeof(int));
                        //dtTraspaso.Columns.Add("Incidencia", typeof(int));
                    }
                    GuardarPedido();
                }
            }
            catch
            { }
        }

        private void Grd_Pedido_KeyDown(object sender, KeyEventArgs e)
        {
            ////if ((e.Control && e.KeyCode == Keys.Delete) || (e.Shift && e.KeyCode == Keys.Delete))
            ////{
            ////    DataObject d = Grd_Pedido.GetClipboardContent();
            ////    if (d == null) { return; }
            ////    Clipboard.SetDataObject(d);
            ////}
            if (e.KeyCode == Keys.Delete) // && _celWasEndEdit == null)
            {
                // ROMA 13AGO2013
                e.SuppressKeyPress = true;
                string rowID = string.Empty;
                if (Grd_Pedido.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in Grd_Pedido.SelectedRows)
                    {
                        try
                        {
                            rowID = row.Cells["ID"].Value.ToString();
                            if (MessageBoxEx.Show("¿Borrar el registro " + rowID + "?", ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                DataRow RegArt = dtTraspaso.Rows.Find(rowID);
                                if (RegArt != null)
                                {
                                    dtTraspaso.Rows.Remove(RegArt);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                           MessageBox.Show(ex.ToString() + System.Environment.NewLine, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    //object objSum = dtTraspaso.Compute("Sum(total)", null);
                    //label1.Text = objSum.ToString();
                    //object objSum1 = dtTraspaso.Compute("Sum(recibido)", null);
                    //label2.Text = objSum1.ToString();
                    GuardarPedido();
                    CalculaTotal();
                }
                // ROMA 13AGI2013
            }
        }

        private int CierraTraspaso(string NoFolio, int NoLote)
        {
            SIFNegocio.Inventario.Traspasos tRAS = new SIFNegocio.Inventario.Traspasos();
            return tRAS.CierraTraspaso(Helpers.Sesion.Usuario.UsuariosID.ToString(), NoFolio, NoLote.ToString());
        }

        private void Cerrar()
        {
            if (MessageBoxEx.Show("¿Cerrar el Traspaso " + foliotextBoxX.Text + "?",
                              ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                if (CierraTraspaso(foliotextBoxX.Text, lote) > 0)
                    this.Back();
        }

        private int SetSolicitado(string NoFolio, string NoLote, int NoPartida, string Edo)
        {
            SIFNegocio.Inventario.Traspasos tSol = new SIFNegocio.Inventario.Traspasos();
            return tSol.SetSolicitado(NoFolio, NoLote.ToString(), NoPartida, Edo);
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            GuardarPedido();
            Cerrar();
            //SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Incidencia_Recepcion_Almacen.rpt", "{TRASPASO.FOLIO}='" + foliotextBoxX.Text + "'");
            //Impresion.ShowDialog();
        }

        private void FechaCaducidad_Click(object sender, EventArgs e)
        {
            AgregaArticulo();
        }

        private void Grd_Pedido_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //if (null != Grd_Pedido)
            //{
            //    foreach (DataGridViewRow r in Grd_Pedido.Rows)
            //    {
            //        Grd_Pedido.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            //    }
            //}

            // ROMA 17AGO2013 ??????
            ////GuardarPedido();
            ////CalculaTotal();

        }

        private void Grd_Pedido_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string Col_Name = Grd_Pedido.Columns[e.ColumnIndex].Name;
            int CantOld, CantNew, CantPed, Envio;

            switch (Col_Name)
            {
                case "Recibido":
                    if (Grd_Pedido[e.ColumnIndex, e.RowIndex].IsInEditMode)
                    {
                        CodigoTextBoxX.Text = Grd_Pedido["ArticuloID", e.RowIndex].Value.ToString();
                        CantPed = int.Parse(Grd_Pedido["pedido", e.RowIndex].Value.ToString());
                        CantOld = int.Parse(Grd_Pedido["enviado", e.RowIndex].Value.ToString());
                        CantNew = int.Parse(e.FormattedValue.ToString());
                    }
                    break;
                //if (Grd_Pedido["Solicita", e.RowIndex].Value.ToString().Contains("S"))
                //    e.Cancel = true;
                //else
                //    Grd_Pedido.EndEdit();
                //break;
                default:
                    break;
            }
        }

        private void Grd_Pedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Col_Name = Grd_Pedido.Columns[e.ColumnIndex].Name;
            int result = 0, CIncidencia = 0;

            CIncidencia = Convert.ToInt16(Grd_Pedido["Incidencia", e.RowIndex].Value.ToString());
            //if (!objNotWholePattern.IsMatch(Grd_Pedido["Incidencia", e.RowIndex].Value.ToString()) &&  //Grd_Pedido["Solicita", e.RowIndex].Value.ToString() == "S")
            //   (objNotSolcitadoPattern.IsMatch(Grd_Pedido["Solicita", e.RowIndex].Value.ToString())) )
            //{
            //    Grd_Pedido.CancelEdit();
            //    //Grd_Pedido.EndEdit();
            //    return;
            //}

            switch (Col_Name)
            {
                case "Recibe":
                    if (!Grd_Pedido[Col_Name, e.RowIndex].ReadOnly)
                    {
                        switch (Grd_Pedido["Solicita", e.RowIndex].Value.ToString())
                        {
                            case "S":
                                result = SetSolicitado(foliotextBoxX.Text, Grd_Pedido["LoteId", e.RowIndex].Value.ToString(), Convert.ToInt16(Grd_Pedido["Partida", e.RowIndex].Value), "D");
                                if (result > 0)
                                {
                                    //Grd_Pedido["Solicita", e.RowIndex].Value = "D"; // ROMA 31AGO2013
                                    Grd_Pedido.EndEdit();
                                    InicializaPedido();
                                }
                                else
                                    Grd_Pedido.CancelEdit();
                                break;
                            case "D": // ROMA 31AGO2013
                                result = SetSolicitado(foliotextBoxX.Text, Grd_Pedido["LoteId", e.RowIndex].Value.ToString(), Convert.ToInt16(Grd_Pedido["Partida", e.RowIndex].Value), "S");
                                if (result > 0)
                                {
                                    //Grd_Pedido["Solicita", e.RowIndex].Value = "S";
                                    Grd_Pedido.EndEdit();
                                    InicializaPedido();
                                }
                                else
                                    Grd_Pedido.CancelEdit();
                                break;
                            case "X": // NO Solicitado, Devolución
                                result = SetSolicitado(foliotextBoxX.Text, Grd_Pedido["LoteId", e.RowIndex].Value.ToString(), Convert.ToInt16(Grd_Pedido["Partida", e.RowIndex].Value), "A");
                                if (result > 0)
                                {
                                    ////Grd_Pedido["Solicita", e.RowIndex].Value = "A";
                                    ////Grd_Pedido["Devolucion", e.RowIndex].Value = Grd_Pedido["Incidencia", e.RowIndex].Value;
                                    Grd_Pedido.EndEdit();
                                    InicializaPedido();
                                }
                                else
                                    Grd_Pedido.CancelEdit();
                                break;
                            case "A": // No Solicitado, Se recibe Completo 
                                result = SetSolicitado(foliotextBoxX.Text, Grd_Pedido["LoteId", e.RowIndex].Value.ToString(), Convert.ToInt16(Grd_Pedido["Partida", e.RowIndex].Value), "X");
                                if (result > 0)
                                {
                                    ////Grd_Pedido["Solicita", e.RowIndex].Value = "X";
                                    Grd_Pedido.EndEdit();
                                    InicializaPedido();
                                }
                                else
                                    Grd_Pedido.CancelEdit();
                                break;
                            default:
                                Grd_Pedido.CancelEdit();
                                break;
                        }
                    }
                    break;
                case "ColTipDev":
                    ////if (bInitPedido)
                    ////{
                    ////    Grd_Pedido.EndEdit();
                    ////    InicializaPedido();
                    ////    bInitPedido = false;
                    ////}
                    string Param = string.Empty;
                    Param += foliotextBoxX.Text + "|";
                    Param += Grd_Pedido["LoteId", e.RowIndex].Value.ToString() + "|";
                    Param += Grd_Pedido["ID", e.RowIndex].Value.ToString() + " - " + Grd_Pedido["Nombre", e.RowIndex].Value.ToString() + "|";
                    Param += Grd_Pedido["Devolucion", e.RowIndex].Value.ToString() + "|"; // OJO Incidencia
                    Param += Grd_Pedido["ColTipDev", e.RowIndex].Value.ToString() + "|";
                    Param += Grd_Pedido["Partida", e.RowIndex].Value.ToString();

                    frmMotivoDevTraspaso frmDevolucion = new frmMotivoDevTraspaso(Param);
                    if (frmDevolucion.ShowDialog() != DialogResult.OK)
                    {
                        Grd_Pedido.CancelEdit();
                    }
                    else
                    {
                        Grd_Pedido.EndEdit();
                        InicializaPedido();
                    }

                    break;
                default: // Otra Columna
                    break;
            }

            ////switch (Col_Name)
            ////{
            ////    case "Recibe":
            ////        if (!Grd_Pedido[Col_Name, e.RowIndex].ReadOnly && int.Parse(Grd_Pedido["Incidencia", e.RowIndex].Value.ToString()) >= 0) 
            ////        {
            ////            //if ( int.Parse(Grd_Pedido["Incidencia", e.RowIndex].Value.ToString()) <= 0)
            ////            //    Grd_Pedido.CancelEdit();

            ////            switch (Grd_Pedido["Solicita", e.RowIndex].Value.ToString())
            ////            {
            ////                case "S":
            ////                    ////Grd_Pedido.CancelEdit();
            ////                    result = SetSolicitado(foliotextBoxX.Text, Grd_Pedido["LoteId", e.RowIndex].Value.ToString(), Convert.ToInt16(Grd_Pedido["Partida", e.RowIndex].Value), "D");
            ////                    if (result > 0)
            ////                    {
            ////                        Grd_Pedido["Solicita", e.RowIndex].Value = "D"; // ROMA 31AGO2013
            ////                        Grd_Pedido.EndEdit();
            ////                        InicializaPedido();
            ////                    }
            ////                    else
            ////                        Grd_Pedido.CancelEdit();
            ////                    break;
            ////                case "D": // ROMA 31AGO2013
            ////                    result = SetSolicitado(foliotextBoxX.Text, Grd_Pedido["LoteId", e.RowIndex].Value.ToString(), Convert.ToInt16(Grd_Pedido["Partida", e.RowIndex].Value), "S");
            ////                    if (result > 0)
            ////                    {
            ////                        Grd_Pedido["Solicita", e.RowIndex].Value = "S";
            ////                        Grd_Pedido.EndEdit();
            ////                        InicializaPedido();
            ////                    }
            ////                    else
            ////                        Grd_Pedido.CancelEdit();
            ////                    break;
            ////                case "X":
            ////                    result = SetSolicitado(foliotextBoxX.Text, Grd_Pedido["LoteId", e.RowIndex].Value.ToString(), Convert.ToInt16(Grd_Pedido["Partida", e.RowIndex].Value), "A");
            ////                    if (result > 0)
            ////                    {
            ////                        Grd_Pedido["Solicita", e.RowIndex].Value = "A";
            ////                        Grd_Pedido.EndEdit();
            ////                    }
            ////                    else
            ////                        Grd_Pedido.CancelEdit();
            ////                    break;
            ////                case "A":
            ////                    result = SetSolicitado(foliotextBoxX.Text, Grd_Pedido["LoteId", e.RowIndex].Value.ToString(), Convert.ToInt16(Grd_Pedido["Partida", e.RowIndex].Value), "X");
            ////                    if (result > 0)
            ////                    {
            ////                        Grd_Pedido["Solicita", e.RowIndex].Value = "X";
            ////                        Grd_Pedido.EndEdit();
            ////                    }
            ////                    else
            ////                        Grd_Pedido.CancelEdit();
            ////                    break;
            ////                default:
            ////                    Grd_Pedido.CancelEdit();
            ////                    break;
            ////            }
            ////        }
            ////        else
            ////        {
            ////            //MessageBoxEx.Show("La cantidad recibida debe ser mayor a cero");
            ////           MessageBox.Show("La cantidad incidencia debe ser distinta a cero");
            ////            Grd_Pedido.CancelEdit();
            ////        }
            ////        break;
            ////    default:
            ////        break;
            ////}

        }

        private void Grd_Pedido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Editar");

        }

        private void Grd_Pedido_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Col_Name = Grd_Pedido.Columns[e.ColumnIndex].Name;

            switch (Col_Name)
            {
                case "Recibe":
                case "ColTipDev":
                    if (!Grd_Pedido[Col_Name, e.RowIndex].ReadOnly)
                        Grd_Pedido.CancelEdit();
                    break;
                default:
                    break;
            }

        }

        private void Grd_Pedido_Sorted(object sender, EventArgs e)
        {
            Grd_Pedido.FirstDisplayedCell = Grd_Pedido.CurrentCell;
        }

        private void btn_ImpIncidencias_Click(object sender, EventArgs e)
        {
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Recepcion_traspaso.rpt", "{TRASPASO.FOLIO}='" + TraspasoID.ToString() + "' AND {TRASPASO.LOTE}=" + lote);
            Impresion.ShowDialog();
        }

        private void Grd_Pedido_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string Col_Name = Grd_Pedido.Columns[e.ColumnIndex].Name;
            switch (Col_Name)
            {
                case "ColTipDev":
                    if (!objNotWholePattern.IsMatch(Grd_Pedido["Incidencia", e.RowIndex].Value.ToString()) &&  //Grd_Pedido["Solicita", e.RowIndex].Value.ToString() == "S")
                       (!objNotSolcitadoPattern.IsMatch(Grd_Pedido["Solicita", e.RowIndex].Value.ToString())))
                    {
                        Grd_Pedido.CancelEdit();
                        return;
                    }
                    break;
                default:
                    break;
            }

            ////// tipo_devolucion
            ////SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
            ////string Col_Name = Grd_Pedido.Columns[e.ColumnIndex].Name;

            ////switch (Col_Name)
            ////{
            ////    case "ColTipDev":
            ////        if (Grd_Pedido["Incidencia", e.RowIndex].Value.ToString() != "0")
            ////        {
            ////            this.Grd_Pedido.BeginInvoke(objChangeCellType, e.RowIndex);
            ////            bIsComboBox = false;
            ////        }
            ////        else
            ////        {
            ////            Grd_Pedido.CancelEdit();
            ////            SendKeys.Send("{TAB}");
            ////            //bIsComboBox = true;
            ////        }
            ////        break;
            ////    default:
            ////        break;
            ////}

            ////////if (e.ColumnIndex == this.Grd_Pedido.Columns["tipo_devolucion"].Index)
            ////////{
            ////////    this.Grd_Pedido.BeginInvoke(objChangeCellType, e.RowIndex);
            ////////    bIsComboBox = false;
            ////////}
        }

        ////private void Grd_Pedido_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        ////{
        ////    if (Grd_Pedido.CurrentCell.ColumnIndex == 17)
        ////    {
        ////        ComboBox cmbBox = e.Control as ComboBox;
        ////        if (cmbBox != null)
        ////        {
        ////            cmbBox.SelectedValueChanged -= new EventHandler(cmbox_SelectedValueChanged);
        ////            cmbBox.SelectedValueChanged += new EventHandler(cmbox_SelectedValueChanged);
        ////        }
        ////        currentCell = this.Grd_Pedido.CurrentCell;
        ////    }
        ////}

        private void cmbox_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!string.IsNullOrEmpty(cb.Text))
            {
                string result = cb.Text; // Grd_Pedido.CurrentCell.Value.ToString();
                SetDevolucion(foliotextBoxX.Text, Grd_Pedido["LoteId", currentCell.RowIndex].Value.ToString(),
                                Convert.ToInt16(Grd_Pedido["Partida", currentCell.RowIndex].Value),
                                result,
                                Convert.ToInt16(Grd_Pedido["Incidencia", currentCell.RowIndex].Value));
                //MessageBoxEx.Show(result);
                cb.SelectedValueChanged -= new EventHandler(cmbox_SelectedValueChanged);
                //            this.Grd_Pedido.CommitEdit(DataGridViewDataErrorContexts.Commit);
                //            this.Grd_Pedido.CurrentCell = this.Grd_Pedido.Rows[currentCell.RowIndex].Cells[currentCell.ColumnIndex - 1];
                //this.Grd_Pedido.CurrentCell.Value.ToString();
                SendKeys.Send("{TAB}");
                bInitPedido = true;
                //InicializaPedido();
                ////Grd_Pedido.FirstDisplayedCell = Grd_Pedido.CurrentCell;
                //this.Grd_Pedido.EndEdit();
            }
            else
            {
                SendKeys.Send("{TAB}");
                bInitPedido = false;
            }
        }

        private int SetDevolucion(string NoFolio, string NoLote, int NoPartida, string Edo, int Cant)
        {
            SIFNegocio.Inventario.Traspasos tSol = new SIFNegocio.Inventario.Traspasos();
            return tSol.SetDevolucion(NoFolio, NoLote.ToString(), NoPartida, "W", Edo, Cant);
        }

        private void chkbox_Enviado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_Enviado.Checked)
            {
                foreach (DataGridViewRow row in Grd_Pedido.Rows)
                {
                    row.Visible = true;
                }
            }
            else
            {
                Grd_Pedido.CurrentCell = null;
                foreach (DataGridViewRow row in Grd_Pedido.Rows)
                {
                    if (row.Cells["EnviadoColumn"].Value.ToString() == "0")
                        row.Visible = false;
                }
            }

        }

        private void IncidenciasButtonItem_Click(object sender, EventArgs e)
        {
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Recepcion_traspaso_incidencias.rpt", "{TRASPASO.FOLIO}='" + TraspasoID.ToString() + "' AND {TRASPASO_DET.INCIDENCIA} <> 0.00  AND {INV_TRASPASO.SUCURSAL_ID} = {TRASPASO.SUCURSAL_DESTINO}");
            //SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Recepcion_traspaso_incidencias.rpt", "{TRASPASO.FOLIO}='" + TraspasoID.ToString() + "' AND ( {TRASPASO_DET.SOLICITADO} = 'D' OR {TRASPASO_DET.SOLICITADO} = 'X' ) AND {INV_TRASPASO.SUCURSAL_ID} = {TRASPASO.SUCURSAL_DESTINO}");
            Impresion.ShowDialog();
        }

        private void DevolucionButtonItem_Click(object sender, EventArgs e)
        {
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Producto_no_pedido.rpt", "{TRASPASO.FOLIO}='" + TraspasoID.ToString() + "' AND ( {TRASPASO_DET.SOLICITADO} = 'D' OR {TRASPASO_DET.SOLICITADO} = 'X' ) AND {INV_TRASPASO.SUCURSAL_ID} = {TRASPASO.SUCURSAL_DESTINO}");
            //            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Recepcion_traspaso_incidencias.rpt", "{TRASPASO.FOLIO}='" + TraspasoID.ToString() + "' AND ( {TRASPASO_DET.SOLICITADO} = 'D' OR {TRASPASO_DET.SOLICITADO} = 'X' ) AND {INV_TRASPASO.SUCURSAL_ID} = {TRASPASO.SUCURSAL_DESTINO}");
            Impresion.ShowDialog();
        }



    }
}
