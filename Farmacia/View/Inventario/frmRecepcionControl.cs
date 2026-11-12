using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIF.View.Ventas;
using DevComponents.DotNetBar;

namespace SIF.View.Inventario
{
    public partial class frmRecepcionControl : Templates.CatalogoUserControl
    {
        public RecepcionTraspasosAlmacenUserControl Owner { get; set; }
        public bool Mostrado { get; set; }

        frmMotivoDevTraspaso frmDevolucion;
        SIFNegocio.Inventario.Traspasos traspasoAlmacenL = new SIFNegocio.Inventario.Traspasos();

        private int Partidas;
        public string TraspasoID;
        public int lote;
        public String SucursalO;
        public String SucursalD;
        public string Usr_Envia;
        DataTable dtTraspaso = new DataTable();
        string TipoArt = string.Empty;
        int NoLote = 0;
        double PrecioArt = 0;

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
            this.CodigoTextBoxX.Focus(); //L 12/12/2013 para asegurar que el focus esté en captura de código de barras
        }

        private void CargaSucursalOrigen()
        {
            BindingList<SIFModelo.Sucursal> sucursales = new BindingList<SIFModelo.Sucursal>();
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
            List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().Buscar("", "").DataSource as List<SIFModelo.Sucursal>;

            foreach (SIFModelo.Sucursal sucursalBd in sucursalesBD)
            {
                sucursales.Add(sucursalBd);
            }

            SucursalDestinoComboBox.DataSource = sucursales;
            SucursalDestinoComboBox.DisplayMember = "NOMBRE";
            SucursalDestinoComboBox.ValueMember = "SUCURSALESID";
        }

        private void InicializaPedido()
        {
            foliotextBoxX.Text = TraspasoID.ToString();
            SucursalOrigenComboBox.Text = SucursalO;
            SucursalDestinoComboBox.Text = SucursalD;
            dtTraspaso = traspasoAlmacenL.GetTraspasoDetalle(TraspasoID.ToString(), lote);

            Grd_Recepcion.DataSource = dtTraspaso;//1 breAK
            Grd_Recepcion.EndEdit();
            string CadSol, ArtID = string.Empty;
            int CIncidencia = 0;
            CalculaTotal();
        }//2 break

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

        private int SetSolicitado(string NoFolio, string NoLote, int NoPartida, string Edo)
        {
            SIFNegocio.Inventario.Traspasos tSol = new SIFNegocio.Inventario.Traspasos();
            return tSol.SetSolicitado(NoFolio, NoLote.ToString(), NoPartida, Edo);
        }

        private int SetRecibido(string NoFolio, string NoLote, int NoPartida, int CantR, int CantD)
        {
            SIFNegocio.Inventario.Traspasos tSol = new SIFNegocio.Inventario.Traspasos();
            return tSol.SetRecibido(NoFolio, NoLote.ToString(), NoPartida, CantR, CantD);
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
            String[] Procesado = new String[results.Length];//L 21/11/2013
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
                    Procesado[sec] = rowdet["Procesado"].ToString();//L 21/11/2013
                    sec++;

            }
            int result = traspasoAlmacenL.UpdTraspaso(CtlFolio, Lote, Total, Sec, Articulo, Concepto, CantS, CantE, CantR, CantD, PrecioE, PrecioE, Caja, Pedido, Usr_Envia, Helpers.Sesion.Usuario.Nombre, NoLote, FecCad, TipDev);
        }

        private void Cerrar()
        {
            string valido;
            int mov = 12;
            valido = traspasoAlmacenL.ValidaLInterno(foliotextBoxX.Text, lote.ToString(), mov);
            //MessageBox.Show(valido);
            if (valido.Contains("-1"))
            {
                MessageBox.Show(valido, "Caducidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBoxEx.Show("¿Cerrar el Traspaso " + foliotextBoxX.Text + "?",
                              ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                if (CierraTraspaso(foliotextBoxX.Text, lote) > 0)
                {
                    #region Consume API
                    //consumir la Api para reportar el inventario a la base de datos de la nube
                    if (SIFNegocio.EpGo.NegocioConfiguracionEpGo.ParametroActivo >= 1)
                    {
                        int tipoMovInvID = traspasoAlmacenL.ObtenTpoMovInvIDTraspaso(foliotextBoxX.Text, lote.ToString());
                        new SIFNegocio.EpGo.InventarioService().SendInvetarioApiGo(
                           foliotextBoxX.Text + "-" + lote, tipoMovInvID
                            );
                    }
                    #endregion
                    imprimir(foliotextBoxX.Text, lote);
                    //despliegaCapturaLoteCad(foliotextBoxX.Text+"-"+ lote);
                }
                    this.Back();
        }
        private void imprimir(string folio, int lote)
        {
            String ProductName = "Traspasos";
            //GridPanel panel = superGridControl1.PrimaryGrid;
            //var container = ((GridContainer)panel.ActiveRow);
            // var row = (GridRow)container;
               
                SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Recepcion_traspaso.rpt", "{TRASPASO.FOLIO}='" + folio + "' AND {TRASPASO.LOTE}=" +lote);
                Impresion.ShowDialog();
            
        }


        private int CierraTraspaso(string NoFolio, int NoLote)
        {
            //SIFNegocio.Inventario.Traspasos tRAS = new SIFNegocio.Inventario.Traspasos();
            //if (SucursalD.Contains(Helpers.Sesion.Sucursal.Nombre.ToString()))
            //{
                return traspasoAlmacenL.CierraTraspaso21(Helpers.Sesion.Usuario.UsuariosID.ToString(), NoFolio, NoLote.ToString());
           /* }
            else
                return tRAS.CierraTraspaso(Helpers.Sesion.Usuario.UsuariosID.ToString(), NoFolio, NoLote.ToString());*/
        }

        public void AgregaArticulo(string claveArticulo)
        {
            if (string.IsNullOrEmpty(claveArticulo))
            {
                return;
            }

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
            }

            this.AgregaArticulo(articulo);
        }

        SIFModelo.Inventarios.InventarioDataSet.TRASPASORow traspaso;
        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            int cantidad = 1;

            if (this.cantidadTextBoxX.Text.IsIntegerPositive())
                cantidad = int.Parse(this.cantidadTextBoxX.Text);

            CodigoTextBoxX.Text = articulo.ARTICULO_ID;
            cantidadTextBoxX.Focus();
            AgregaArticulo();
            CalculaTotal();
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
            //L 26/11/2013 AGREGA AQUI EL FOCUS EN CAPTURA DE EAN
        }

        private void AddArtTraspaso(int Lote, double Precio, int NoCaja)
        {
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
                        //dtTraspaso.DefaultView.Sort = " PARTIDA DESC, caja, id ASC";
                        Partidas++;
                    }
                    else
                    {
                        RegArt["Recibido"] = Convert.ToInt16(RegArt["Recibido"].ToString()) + Convert.ToInt16(cantidadTextBoxX.Text);
                        if (RegArt["Solicita"].ToString().Contains("X"))
                        {
                            RegArt["Devuelta"] = Convert.ToInt16(RegArt["Devuelta"].ToString()) + Convert.ToInt16(cantidadTextBoxX.Text);
                        }
                    }
                    GuardarPedido();
                }
            }
            catch
            { }
        }

        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.agregaProductoButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
        }

        private void SeleccionaArticulo()
        {
            View.Articulos.ArticuloUserControl frmArticulo = new Articulos.ArticuloUserControl();

            frmArticulo.Dock = DockStyle.Fill;
            frmArticulo.Owner = this;

            this.cantidadTextBoxX.Text = "1";
            frmArticulo.Muestra();
        }

        public void Back()
        {
            try
            {
                Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                //this.DesactivaComandos();
                this.Owner.ActivaComandos();
                Mostrado = false;
                this.Grd_Recepcion.EndEdit();
                Owner.Buscar();
            }
            catch { }
        }

        public frmRecepcionControl()
        {
            InitializeComponent();
            this.CargaSucursalOrigen();
            this.CargaSucursalDestino();
            this.Grd_Recepcion.AutoGenerateColumns = false;
            this.CodigoTextBoxX.Focus();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void frmRecepcionControl_Load(object sender, EventArgs e)
        {
            InicializaPedido();
        }

        private void Grd_Recepcion_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string Col_Name = Grd_Recepcion.Columns[e.ColumnIndex].Name;
            int CantOld, CantPed, CantRec, CantEnv, CantIncide, Result, CantRecibir;

            switch (Col_Name)
            {
                case "ColRecibido":
                    if (Grd_Recepcion[e.ColumnIndex, e.RowIndex].IsInEditMode)
                    {
                        CodigoTextBoxX.Text = Grd_Recepcion["ColID", e.RowIndex].Value.ToString();
                        CantPed = int.Parse(Grd_Recepcion["ColPedido", e.RowIndex].Value.ToString());
                        CantOld = int.Parse(Grd_Recepcion["ColEnviado", e.RowIndex].Value.ToString());
                        CantRec = int.Parse(Grd_Recepcion["ColRecibido", e.RowIndex].Value.ToString());
                        CantEnv = int.Parse(Grd_Recepcion["ColEnviado", e.RowIndex].Value.ToString());
                        int CantDev = int.Parse(Grd_Recepcion["ColDevolucion", e.RowIndex].Value.ToString());
                        CantRecibir = int.Parse(e.FormattedValue.ToString());
                        CantIncide = CantRecibir - CantEnv;

                        if (CantDev > 0)
                        {
                           MessageBox.Show("Se restablecerá la cantidad devuelta");

                            Grd_Recepcion["ColTipDev", e.RowIndex].Value = "NO APLICA";
                            Grd_Recepcion["ColDevolucion", e.RowIndex].Value = 0;
                            Grd_Recepcion["ColSolicita", e.RowIndex].Value = "S";

                            frmDevolucion = new frmMotivoDevTraspaso();
                            frmDevolucion.SetDevolucion(foliotextBoxX.Text, lote.ToString(), System.Convert.ToInt32(Grd_Recepcion["ColPartida", e.RowIndex].Value), Grd_Recepcion["ColSolicita", e.RowIndex].Value.ToString(), "No Aplica", 0);



                            //e.Cancel = true;
                            //return;
                        }


                        switch (Grd_Recepcion["ColSolicita", e.RowIndex].Value.ToString())
                        {
                            case "S":
                            case "D":
                            case "A":
                                Result = SetRecibido(foliotextBoxX.Text, Grd_Recepcion["ColLote", e.RowIndex].Value.ToString(),
                                    int.Parse(Grd_Recepcion["ColPartida", e.RowIndex].Value.ToString()), CantRecibir, 0);
                                if (Result > 0)
                                {
                                    Grd_Recepcion["ColDevolucion", e.RowIndex].Value = 0;
                                    Grd_Recepcion["ColIncidencia", e.RowIndex].Value = CantIncide;
                                    if (Grd_Recepcion.Rows[e.RowIndex] == Grd_Recepcion.Rows[Grd_Recepcion.Rows.Count - 1])
                                    {
                                        Grd_Recepcion.CommitEdit(DataGridViewDataErrorContexts.Commit);
                                        // this.Grd_Recepcion.CurrentCell = Grd_Recepcion.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
                                    }
                                    else
                                    {
                                        Grd_Recepcion.EndEdit(); CalculaTotal();


                                    }
                                }
                                else
                                {
                                    Grd_Recepcion.CancelEdit();
                                    e.Cancel = true;
                                }
                                break;
                            case "X":
                                Result = SetRecibido(foliotextBoxX.Text, Grd_Recepcion["ColLote", e.RowIndex].Value.ToString(),
                                    int.Parse(Grd_Recepcion["ColPartida", e.RowIndex].Value.ToString()), CantRecibir, CantRecibir);
                                if (Result > 0)
                                {
                                    Grd_Recepcion["ColDevolucion", e.RowIndex].Value = CantRecibir;
                                    Grd_Recepcion["ColIncidencia", e.RowIndex].Value = CantRecibir;
                                    Grd_Recepcion.EndEdit();
                                }
                                else
                                {
                                    Grd_Recepcion.CancelEdit();
                                    e.Cancel = true;
                                }
                                break;
                            default:
                                Grd_Recepcion.CancelEdit();
                                e.Cancel = true;
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }

        }

        private void Grd_Recepcion_CellContentClick(object sender, DataGridViewCellEventArgs e)//L 26/11/2013 aquo cacharias el evento donde presionan enter en el contenido de celda
        {
            string Col_Name = Grd_Recepcion.Columns[e.ColumnIndex].Name;
            string Param = string.Empty;
            int result = 0;

            switch (Col_Name)
            {
                case "ColRecibe":

                    DataGridViewCheckBoxCell cell = Grd_Recepcion[Col_Name, e.RowIndex] as DataGridViewCheckBoxCell;

                    //if (cell.Value.ToString() == "False")
                    //{
                    //    //Grd_Recepcion["ColSolicita", e.RowIndex].Value = "S";
                    //}

                    if (!Grd_Recepcion[Col_Name, e.RowIndex].ReadOnly)
                    {
                        switch (Grd_Recepcion["ColSolicita", e.RowIndex].Value.ToString())
                        {
                            case "S":
                                Param += foliotextBoxX.Text + "|";
                                Param += Grd_Recepcion["ColLote", e.RowIndex].Value.ToString() + "|";
                                Param += Grd_Recepcion["ColID", e.RowIndex].Value.ToString() + " - " + Grd_Recepcion["ColNombre", e.RowIndex].Value.ToString() + "|";
                                Param += Grd_Recepcion["ColRecibido", e.RowIndex].Value.ToString() + "|"; // OJO Incidencia
                                Param += Grd_Recepcion["ColTipDev", e.RowIndex].Value.ToString() + "|";
                                Param += Grd_Recepcion["ColPartida", e.RowIndex].Value.ToString() + "|";
                                Param += "D";

                                frmDevolucion = new frmMotivoDevTraspaso(Param);
                                if (frmDevolucion.ShowDialog() != DialogResult.OK)
                                {
                                    Grd_Recepcion.CancelEdit();
                                }
                                else
                                {
                                  DataRow rowRecepcion = ((DataRowView)(Grd_Recepcion.Rows[e.RowIndex].DataBoundItem)).Row;
                                  rowRecepcion["devuelta"] = frmDevolucion.CantDev.Value;
                                  Grd_Recepcion.EndEdit();
                                    InicializaPedido();
                                }
                                break;
                            case "D": // ROMA 31AGO2013
                                int CantDev = 0;
                                //CantDev = int.Parse(Grd_Recepcion["ColRecibido", e.RowIndex].Value.ToString()) - int.Parse(Grd_Recepcion["ColDevolucion", e.RowIndex].Value.ToString());
                                Grd_Recepcion["ColTipDev", e.RowIndex].Value = "NO APLICA";
                                Grd_Recepcion["ColDevolucion", e.RowIndex].Value = 0;
                                Grd_Recepcion["ColSolicita", e.RowIndex].Value = "S";

                                Param += foliotextBoxX.Text + "|";
                                Param += Grd_Recepcion["ColLote", e.RowIndex].Value.ToString() + "|";
                                Param += Grd_Recepcion["ColID", e.RowIndex].Value.ToString() + " - " + Grd_Recepcion["ColNombre", e.RowIndex].Value.ToString() + "|";
                                Param += CantDev.ToString() + "|";
                                Param += Grd_Recepcion["ColTipDev", e.RowIndex].Value.ToString() + "|";
                                Param += Grd_Recepcion["ColPartida", e.RowIndex].Value.ToString() + "|";
                                Param += "S";



                                Grd_Recepcion[Col_Name, e.RowIndex].Value = true;
                                frmDevolucion = new frmMotivoDevTraspaso(Param);
                                frmDevolucion.SetDevolucion(foliotextBoxX.Text, lote.ToString(), System.Convert.ToInt32( Grd_Recepcion["ColPartida", e.RowIndex].Value), Grd_Recepcion["ColSolicita", e.RowIndex].Value.ToString(), "No Aplica", 0);
                                //if (frmDevolucion.ShowDialog() != DialogResult.OK)
                                //{
                                //    Grd_Recepcion.CancelEdit();
                                
                                //else
                                //{
                                    Grd_Recepcion.EndEdit();
                                    InicializaPedido();
                                //}
                                break;
                            case "X": // NO Solicitado, Devolución
                                Param += foliotextBoxX.Text + "|";
                                Param += Grd_Recepcion["ColLote", e.RowIndex].Value.ToString() + "|";
                                Param += Grd_Recepcion["ColID", e.RowIndex].Value.ToString() + " - " + Grd_Recepcion["ColNombre", e.RowIndex].Value.ToString() + "|";
                                Param += "0|"; //Grd_Recepcion["ColRecibido", e.RowIndex].Value.ToString() + "|"; // OJO Incidencia
                                Param += Grd_Recepcion["ColTipDev", e.RowIndex].Value.ToString() + "|";
                                Param += Grd_Recepcion["ColPartida", e.RowIndex].Value.ToString() + "|";
                                Param += "A";
                                frmDevolucion = new frmMotivoDevTraspaso(Param);
                                if (frmDevolucion.ShowDialog() != DialogResult.OK)
                                {
                                    Grd_Recepcion.CancelEdit();
                                }
                                else
                                {
                                    Grd_Recepcion.EndEdit();
                                    InicializaPedido();
                                }
                                break;
                            case "A": // No Solicitado, Se recibe Completo 
                                Param += foliotextBoxX.Text + "|";
                                Param += Grd_Recepcion["ColLote", e.RowIndex].Value.ToString() + "|";
                                Param += Grd_Recepcion["ColID", e.RowIndex].Value.ToString() + " - " + Grd_Recepcion["ColNombre", e.RowIndex].Value.ToString() + "|";
                                Param += Grd_Recepcion["ColIncidencia", e.RowIndex].Value.ToString() + "|"; // OJO Incidencia
                                Param += Grd_Recepcion["ColTipDev", e.RowIndex].Value.ToString() + "|";
                                Param += Grd_Recepcion["ColPartida", e.RowIndex].Value.ToString() + "|";
                                Param += "X";

                                frmDevolucion = new frmMotivoDevTraspaso(Param);
                                if (frmDevolucion.ShowDialog() != DialogResult.OK)
                                {
                                    Grd_Recepcion.CancelEdit();
                                }
                                else
                                {
                                    Grd_Recepcion.EndEdit();
                                    InicializaPedido();
                                }
                                break;
                            default:
                                Grd_Recepcion.CancelEdit();
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void Grd_Recepcion_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            string CadSol, ArtID = string.Empty;
            int CIncidencia = 0;
            int rowActual = 0;//L 26/11/2013
            if(Grd_Recepcion.CurrentRow!=null)
                Grd_Recepcion.CurrentRow.Selected = true;
            //MessageBox.Show(Grd_Recepcion.CurrentRow.ToString());
            foreach (DataGridViewRow row in Grd_Recepcion.Rows)
            {
                //MessageBox.Show("1) " + Grd_Recepcion.CurrentRow + " ROW " + row.Index.ToString());//L 25/11/2013
                CadSol = row.Cells["ColSolicita"].Value.ToString();
                ArtID = row.Cells["ColID"].Value.ToString();
                CIncidencia = int.Parse(row.Cells["ColIncidencia"].Value.ToString());
                switch (CadSol)
                {
                    case "S":
                    case "A":
                        row.Cells["ColRecibe"].Value = true;
                        break;
                    default:
                        row.Cells["ColRecibe"].Value = false;
                        break;
                }

                if (CodigoTextBoxX.Text.Contains(ArtID))
                {
                    row.Selected = true; //L 25/11/2013 Selecciona el row que estas modificando
                    //MessageBox.Show("Seleccionado el row que se está editando, partida "+ (row.Index+1));
                    rowActual = row.Index;//L 26/11/2013
                    //int ren = row.Cells["ColID"].RowIndex;//L 26/11/2013 e equivalente a RowActual

                    Grd_Recepcion.FirstDisplayedCell = Grd_Recepcion[row.Cells["ColID"].ColumnIndex, rowActual]; //L 25/11/2013 Mueve la pantalla para visualizar el row modificado
                    //MessageBox.Show("row actual hacia arriba: "+Grd_Recepcion.CurrentRow +" ROW "+row.Index.ToString()); //L 25/11/2013
                    //Al escribir EAN: 
                    //Hasta este punto, la barra desplazadora se mueve a la partida editada
                }

                // Color Incidencia
                if (CIncidencia > 0) //Positivo
                {
                    Grd_Recepcion[row.Cells["ColIncidencia"].ColumnIndex, row.Cells["ColIncidencia"].RowIndex].Style.ForeColor = Color.Blue;
                }
                else if (CIncidencia < 0) // Negativo
                {
                    Grd_Recepcion[row.Cells["ColIncidencia"].ColumnIndex, row.Cells["ColIncidencia"].RowIndex].Style.ForeColor = Color.Red;
                }
                else // Cero
                {
                    Grd_Recepcion[row.Cells["ColIncidencia"].ColumnIndex, row.Cells["ColIncidencia"].RowIndex].Style.ForeColor = Color.Black;
                }
            }

            CalculaTotal();
            //L 26/11/2013
            /*
            Grd_Recepcion.Rows[rowActual].Selected = false;
            Grd_Recepcion.Rows[0].Selected = true;
            Grd_Recepcion.Rows[1].Selected = true;
            Grd_Recepcion.Rows[2].Selected = true;
            Grd_Recepcion.Rows[3].Selected = true;
            Grd_Recepcion.Rows[4].Selected = true;
            int col = this.Grd_Recepcion.CurrentCell.ColumnIndex;
            int rown = this.Grd_Recepcion.CurrentCell.RowIndex;
            this.Grd_Recepcion.CurrentCell = this.Grd_Recepcion[col, rown];
             */
        }

        private void btn_ImpIncidencias_Click(object sender, EventArgs e)
        {
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Recepcion_traspaso.rpt", "{TRASPASO.FOLIO}='" + TraspasoID.ToString() + "' AND {TRASPASO.LOTE}=" + lote);
            Impresion.ShowDialog();
        }

        private void IncidenciasButtonItem_Click(object sender, EventArgs e)
        {
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Recepcion_traspaso_incidencias.rpt", "{TRASPASO.FOLIO}='" + TraspasoID.ToString() + "' AND {TRASPASO_DET.INCIDENCIA} <> 0.00  AND {INV_TRASPASO.SUCURSAL_ID} = {TRASPASO.SUCURSAL_DESTINO}");
            Impresion.ShowDialog();
        }

        private void DevolucionButtonItem_Click(object sender, EventArgs e)
        {
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Producto_no_pedido.rpt", "{TRASPASO.FOLIO}='" + TraspasoID.ToString() + "' AND ( {TRASPASO_DET.SOLICITADO} = 'D' OR {TRASPASO_DET.SOLICITADO} = 'X' ) AND {INV_TRASPASO.SUCURSAL_ID} = {TRASPASO.SUCURSAL_DESTINO}");
            Impresion.ShowDialog();
        }

        private void chkbox_Enviado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_Enviado.Checked)
            {
                foreach (DataGridViewRow row in Grd_Recepcion.Rows)
                {
                    row.Visible = true;
                }
            }
            else
            {
                Grd_Recepcion.CurrentCell = null;
                foreach (DataGridViewRow row in Grd_Recepcion.Rows)
                {
                    if (row.Cells["ColEnviado"].Value.ToString() == "0")
                        row.Visible = false;
                }
            }
        }

        private void btnCierraTraspaso_Click(object sender, EventArgs e)
        {
            GuardarPedido();
            Cerrar();
        }



        private void cantidadTextBoxX_KeyDown(object sender, KeyEventArgs e)//Controla cuando das enter en cantidad (A un lado de donde captura EAN)
        {
            
            
            if (e.KeyCode == Keys.Enter )
            {
                AgregaArticulo();
                InicializaPedido(); // ROMA 21AGO2013
            }

        }

        private void CodigoTextBoxX_KeyDown(object sender, KeyEventArgs e)//Controla cuando presiona una tecla en el textbox del EAN
        
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

        private void CodigoTextBoxX_KeyUp(object sender, KeyEventArgs e)//L 27/11/2013 MOSTRAR DESCRIPCION MIENTRAS SE VA CAPTURANDO EAN
        {
            if ( 
                ( ( e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z ) ||
                  ( e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 ) ||
                  ( e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
                //LGS 24042016 PARA QUE SOLO BUSQUE EL NOMBRE DEL PRODUCTO AL PRESIONAR F2
                  (e.KeyCode == Keys.F2)
                )
               )
            {
                //MessageBox.Show((char)e.KeyValue+" "+(char)e.KeyData+" "+(char)e.KeyCode+" "+sender.ToString());
                //CodigoTextBoxX.Text += (char)e.KeyValue;
                SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
                //MessageBox.Show("-" + CodigoTextBoxX.Text + "% ");
                if (e.KeyCode == Keys.F2)
                {
                    if (articuloL.BuscarPorClave(CodigoTextBoxX.Text + "%") == null)
                    {
                        //MessageBox.Show("nulo: ");
                        descripcionLabel.Text = "Código no encontrado";
                    }
                    else
                    {
                        SIFModelo.Articulo articulo = articuloL.BuscarPorClave(CodigoTextBoxX.Text + "%");
                        //MessageBox.Show("NO nulo: " + articulo.NOMBRE1 + "-");
                        descripcionLabel.Text = articulo.NOMBRE1;
                    }
                }
            }
        }

        //L 27/11/2013 Evitar que borren partidas en grid
        private void Grd_Recepcion_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (this.Grd_Recepcion["ColEnviado", e.Row.Index].Value.ToString() == "0")
            {
                e.Cancel = false;
            }
            else
            {
                MessageBox.Show("No puedes borrar partidas con cantidad enviada mayor a 0" );
                e.Cancel = true;
            }
        }

        private void CodigoTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.SeleccionaArticulo();
        }

        private void CodigoTextBoxX_Enter(object sender, EventArgs e)
        {
            this.CodigoTextBoxX.SelectAll();
        }
        
        /*private void Grd_Recepcion_KeyDown(object sender, KeyEventArgs e)//Entra al dar enter en el grid pero sin editar nada
        {
            //L 26/11/2013
            //MessageBox.Show("kEYdOWN");
            if (e.KeyData == Keys.Enter)
            {
                //MessageBox.Show("Editando");
            }
            //if (e.KeyCode == Keys.Enter || (e.KeyCode.Equals(Keys.Return)))
            //{
                //L 26/11/2013
                /*int col = this.Grd_Recepcion.CurrentCell.ColumnIndex;
                int row = this.Grd_Recepcion.CurrentCell.RowIndex;
                this.Grd_Recepcion.CurrentCell = this.Grd_Recepcion[col, row];
                */
            //}
        /*}*/
        
        private void Grd_Recepcion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CodigoTextBoxX.Focus();

            //int icol = this.Grd_Recepcion.CurrentCell.ColumnIndex;//se borra por ser equivalente a e.ColumnIndex
            int irow = this.Grd_Recepcion.CurrentCell.RowIndex;//Es equivalente a e.RowIndex
            //MessageBox.Show("CellEndEdit icol "+icol+" irow "+irow+" rowindex"+e.RowIndex+" colIndex "+e.ColumnIndex);
            //MessageBox.Show(this.Grd_Recepcion.Rows.Count+" ");
            DataGridViewRow rprevio = this.Grd_Recepcion.Rows[irow];
            if (e.RowIndex == 0)
            {
                irow = this.Grd_Recepcion.Rows.Count - 1;
                rprevio = this.Grd_Recepcion.Rows[irow];//Seleccionamos la linea anterior
            }
            else
	        {
                rprevio = this.Grd_Recepcion.Rows[irow-1];//Seleccionamos la linea anterior
	        }

            foreach (DataGridViewRow row in Grd_Recepcion.Rows)
            {
                //MessageBox.Show(row.Index+" vs "+ e.RowIndex);
                if (row.Index == e.RowIndex)
                {

                    Grd_Recepcion[row.Cells["ColRecibido"].ColumnIndex, row.Cells["ColRecibido"].RowIndex].Style.ForeColor = Color.Black;
                }
                if (row.Index != e.RowIndex)
                    Grd_Recepcion[row.Cells["ColRecibido"].ColumnIndex, row.Cells["ColRecibido"].RowIndex].Style.ForeColor = Color.AntiqueWhite;

            }
            rprevio.Selected = true;//Seleccionamos la linea anterior esperando que el grid no se salte a la siguiente
            //MessageBox.Show("Debe estar seleccionado el anterior " + irow);
        }


        
        private void agregaProductoButtonItem_Click(object sender, EventArgs e)
        {
            SeleccionaArticulo();
        }

        internal void DesactivaComandos()
        {
            agregaProductoButtonItem.Shortcuts.Clear();
        }

        private void despliegaCapturaLoteCad(string  _referencisa) {
            try
            {
                SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(SIF.Helpers.Sesion.Usuario.UsuariosID);


                Inventario.frmCapturaCaducidades frm = new Inventario.frmCapturaCaducidades(usuario, _referencisa, 12);
                frm.ShowDialog();
            }
            catch (Exception exc) {
                MessageBox.Show(exc.ToString());
            }
            
        }
    }
}
