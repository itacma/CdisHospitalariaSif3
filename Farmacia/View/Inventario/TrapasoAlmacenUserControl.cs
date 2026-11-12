using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Text.RegularExpressions;
using System.Media;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Threading;
using SIFModelo;
using System.Reflection;

namespace SIF.View.Inventario
{
    public partial class TraspasoAlmacenUserControl : Templates.CatalogoUserControl
    {
        private DataGridViewCell _celWasEndEdit;

        public String TraspasoID;
        public int lote;
        /*AVM*/
        public String filasMostrar = "";
        public String Origen;
        public String Destino;
        public String RefPedido = "";
        public Int32 idMotivoT=0;
        private Boolean activaSelectPedido= true;
        DataTable dtTraspaso = new DataTable();
        int Partidas = 1;
        int CantOld, CantNew, CantPed, Envio;
        double PrecioArt = 0;
        string TipoArt = string.Empty;
        int NoLote = 0;
        int forma = -1;// (0==escaneo, 1== gird, 2 == cantidad   )
        bool PedidoTraspaso = false;
        bool EditarRB = true;
        public string tipoSucursal_ = string.Empty;
        public TraspasoAlmacenUserControl()
        {
            InitializeComponent();
            this.CargaSucursalOrigen();
            this.CargaSucursalDestino();
            this.CargaMotivos();    ///JMQ 08-02-2017
            this.Grd_Pedido.AutoGenerateColumns = false;

            CodigoTextBoxX.Focus();
        }


        /// <summary>
        /// AVM 13-04-2015
        /// carga los motivos del traspaso.
        /// </summary>
         
        private void CargaMotivos()
        {
            /*JMQ 08-02-2017*/
            SIFNegocio.Inventario.Traspasos Bt = new SIFNegocio.Inventario.Traspasos();
            BindingSource catTipoPedido = new BindingSource();
            catTipoPedido.DataSource = Bt.buscarTipoPedido().DataSource;
            cmbMotivoTras.DataSource = catTipoPedido;
            cmbMotivoTras.DisplayMember = "NOMBRE";
            cmbMotivoTras.SelectedIndex = 0;

            


        }

        public bool Mostrado { get; set; }


        internal void Muestra()
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
            tb_LotePedido.Text = lote.ToString();

            //SucursalOrigenComboBox.Text = Origen;
            //SucursalDestinoComboBox.Text = Destino;
            if (RefPedido.ToString() == "")//L 27/11/2013 Para saber si el traspaso es sin pedido y permitir al usuario enviar más piezas de las pedidas
            {
                LabelPedido.Text = " ";//L 2/11/2013 LabelPedido se encuentra a la izquierda del grid de recepcion, se usa un espacio en blanco para que no se vea
            }
            if (foliotextBoxX.Text == "Nuevo")
            {
                LabelPedido.Text = " ";
                //SucursalOrigenComboBox.Text = Helpers.Sesion.Sucursal.Nombre;
                SucursalOrigenComboBox.SelectedIndex = SucursalOrigenComboBox.FindStringExact(Helpers.Sesion.Sucursal.Nombre);
                
            }
            else
            {
                SucursalOrigenComboBox.SelectedIndex = SucursalOrigenComboBox.FindStringExact(Helpers.Sesion.Sucursal.Nombre);
               
                
                SIFNegocio.Inventario.Traspasos ObtieneSuc = new SIFNegocio.Inventario.Traspasos();

                DataTable sx = ObtieneSuc.getSucDestrasp(TraspasoID.ToString(), lote);
                DataRow row = sx.Rows[0];
                SIFModelo.Sucursal _DESTINO = new SIFNegocio.Sucursales().SucursalPorID(row.Field<int>("sucursal_destino"));
                List<SIFModelo.Sucursal> _d = g_sucursales
                   .Where(suc => suc.SucursalesID == _DESTINO.SucursalesID)
                   .ToList();


                SucursalDestinoComboBox.SelectedItem = _d[0];



                //int sucaca = SucursalDestinoComboBox.FindStringExact(Destino.Split('-')[1].Trim());
                InhabilitaRB();
                /*AVM 14-08-2015*/
                if (RefPedido == "" || string.IsNullOrEmpty(RefPedido.ToString()) || RefPedido == " ")
                    SucursalDestinoComboBox.Enabled = true;
                /*****************/
            }
            /*JMQ 10022017 Selecciona el tipo de pedido sistema*/
           /* string motivotraspaso=SIFNegocio.Inventario.Traspasos.buscarFolioT(TraspasoID).ToString();
              foreach (var item in cmbMotivoTras.Items){
                      if (item.GetType().GetProperty("ID").GetValue(item, null).ToString() == motivotraspaso)
                      {
                          cmbMotivoTras.SelectedItem = item;
                          cmbMotivoTras.Enabled = false;
                          break;
                      }
                    }    
        
            */
            if (!string.IsNullOrEmpty(SIFNegocio.Inventario.Traspasos.buscarFolioT(TraspasoID).ToString())) {
                cmbMotivoTras.Enabled = false;
                activaSelectPedido = false;

            }
            CodigoTextBoxX.Focus();
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

        BindingList<SIFModelo.Sucursal> g_sucursales = new BindingList<SIFModelo.Sucursal>();
        private void CargaSucursalDestino()
        {
            BindingList<SIFModelo.Sucursal> sucursales = new BindingList<SIFModelo.Sucursal>();
            //SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { Nombre = "[TODAS]", SucursalesID = 0 };
            //sucursales.Add(sucursal);
            //sucursales.ToList();d
            //List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().Buscar("", "S").DataSource as List<SIFModelo.Sucursal>;//L 03/01/2013 PARA QUE SOLO SE MUESTREN LOS ALMACENES ACTIVOS EN SUCURSAL DESTINO
            List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().BuscarAlmacenesNoVirtuales().DataSource as List<SIFModelo.Sucursal>;//JMQC 21/05/2026 PARA QUE SOLO CARGUE SUCURSALES  DE FLEMING

            /// AVM 21-04-2015
            SIFModelo.Sucursal modelSeleccione = new SIFModelo.Sucursal();
            modelSeleccione.Nombre = "SELECCIONE...";
            modelSeleccione.SucursalesID = -1;
            modelSeleccione.SucursalID = -1;

            sucursales.Add(modelSeleccione);
            /// AVM 21-04-2015

            foreach (SIFModelo.Sucursal sucursalBd in sucursalesBD)
            {
                sucursales.Add(sucursalBd);
            }
            g_sucursales = sucursales;

            SucursalDestinoComboBox.DataSource = sucursales;
            SucursalDestinoComboBox.DisplayMember = "NOMBRE";
            SucursalDestinoComboBox.ValueMember = "SUCURSALESID";
        }

        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.agregaProductoButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);

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
                if (TipoArt.Contains("F1"))
                    NoLote = 2;
                else
                    NoLote = 1;
                //System.Windows.Forms.SendKeys.Send("{TAB}");
                this.AgregaArticulo(articulo);
            }
        }

        SIFNegocio.Inventario.Traspasos traspasoAlmacenL = new SIFNegocio.Inventario.Traspasos();
        SIFModelo.Inventarios.InventarioDataSet.TRASPASORow traspaso;
        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            //REVISAR SI TIENE EXISTENCIAS Y ESTA ACTIVO
            int cantidad = 1;

            if (this.cantidadTextBoxX.Text.IsIntegerPositive())
                cantidad = int.Parse(this.cantidadTextBoxX.Text);

            CodigoTextBoxX.Text = articulo.ARTICULO_ID;
            cantidadTextBoxX.Focus();
            descripcionLabel.Text = articulo.NOMBRE1;
            //LIMPIAMOS TODAS LOS DATOS
            //AgregaArticulo();
        }

        private void InicializaPedido()
        {
            if (!String.IsNullOrEmpty(TraspasoID))
            {
                foliotextBoxX.Text = TraspasoID.ToString();
                tb_LotePedido.Text = lote.ToString();
                //traspasoAlmacenL.GetFilas(TraspasoID.ToString(), lote);
                /*SelectFilas filas = new SelectFilas();
                filas.folio = TraspasoID.ToString();
                filas.lote = lote;
                filas.ShowDialog();
                if (filas.DialogResult == DialogResult.OK)
                {*/

                    //dtTraspaso = traspasoAlmacenL.GetTraspasoDet(TraspasoID.ToString(), lote);
                    dtTraspaso = traspasoAlmacenL.GetTraspasoDetFilas(TraspasoID.ToString(), lote, filasMostrar);
                //MessageBox.Show(dtTraspaso.Rows[1].ToString());
                AsignaTipoTrasp(lote);
                   // this.InicializaPedido();
                /*}
                else if (filas.DialogResult == DialogResult.Cancel)
                    Back();
                 */
                ////dtTraspaso.DefaultView.Sort = "Existencia DESC";

                ///AVM mí la line aantes del for para que recorra el grid ya cargado. 21-08-2015
                Grd_Pedido.DataSource = dtTraspaso;

                    for (int i = 0; i < Grd_Pedido.Rows.Count; i++)
                    {
                        //Grd_Pedido.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

                        // Grd_Pedido.Rows[i].Cells["incidencia"].;
                        if (Grd_Pedido.Rows[i].DefaultCellStyle.BackColor == Color.Green)
                        {
                            Grd_Pedido.Rows[i].Cells["incidencia"].Value = 1;
                        }
                        else if (Grd_Pedido.Rows[i].DefaultCellStyle.BackColor == Color.FromArgb(255, 51, 51))
                        {
                            Grd_Pedido.Rows[i].Cells["incidencia"].Value = 3;
                        }
                        else if (Grd_Pedido.Rows[i].DefaultCellStyle.BackColor == Color.Yellow)
                        {
                            Grd_Pedido.Rows[i].Cells["incidencia"].Value = 2;
                        }
                        else
                            Grd_Pedido.Rows[i].Cells["incidencia"].Value = 4;
                    }
                    dtTraspaso.DefaultView.Sort = "incidencia desc";
                               
                Partidas = dtTraspaso.Rows.Count + 1;
                /*for (int i = 0; i < Grd_Pedido.Rows.Count; i++)
                {
                    if (int.Parse(Grd_Pedido.Rows[i].Cells["pedido"].Value.ToString()) > int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString()) & (int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString()) > 0))
                        Grd_Pedido.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;//FromArgb(255, 255, 255);//surtido incompleto
                    if (int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString()) == int.Parse(Grd_Pedido.Rows[i].Cells["pedido"].Value.ToString()))
                        Grd_Pedido.Rows[i].DefaultCellStyle.BackColor = Color.Green;//FromArgb(0, 255, 0);//Surtido
                 

                     if (int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString())==0)
                    Grd_Pedido.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 51, 51);//No escaneado, enviado o surtido
                }*/

                ////object objSum =dtTraspaso.Compute ("Max(Lote)+1","");
                ////if (objSum.ToString()!="")
                ////tb_LotePedido.Text = objSum.ToString();
                CalculaTotal();
            }
            else
            {
                foliotextBoxX.Text = "Nuevo";
                dtTraspaso = new DataTable();
                dtTraspaso.Columns.Add("lote", typeof(int));
                DataColumn workCol = dtTraspaso.Columns.Add("Partida", typeof(int));
                workCol.AllowDBNull = false;
                workCol.Unique = true;
                workCol.AutoIncrement = true;
                workCol.AutoIncrementSeed = 1;
                workCol.AutoIncrementStep = 1;
                dtTraspaso.Columns.Add("id", typeof(string));
                dtTraspaso.Columns.Add("nombre", typeof(string));
                dtTraspaso.Columns.Add("Nolote", typeof(string));
                dtTraspaso.Columns.Add("FechaCad", typeof(string));
                dtTraspaso.Columns.Add("pedido", typeof(int));
                dtTraspaso.Columns.Add("enviado", typeof(int));
                dtTraspaso.Columns["enviado"].ReadOnly = false;
                dtTraspaso.Columns.Add("Recibido", typeof(int));
                dtTraspaso.Columns.Add("Existencia", typeof(double));
                dtTraspaso.Columns.Add("Costo", typeof(double));
                dtTraspaso.Columns.Add("caja", typeof(int));
                dtTraspaso.Columns.Add("solicita", typeof(string));
                dtTraspaso.Columns.Add("total", typeof(double), "enviado * Costo");
                dtTraspaso.PrimaryKey = new DataColumn[] { dtTraspaso.Columns["LOTE,PARTIDA"] };

                Grd_Pedido.DataSource = dtTraspaso;

                for (int i = 0; i < Grd_Pedido.Columns.Count; i++)
                    Grd_Pedido.Columns[i].ReadOnly = true;
                Grd_Pedido.Columns["Enviado"].ReadOnly = false;
                SucursalDestinoComboBox.Enabled = true;
                //textBoxX1.Enabled = false;//L 27/11/2013 EN CASO DE UN TRASPASO SIN PEDIDO, NO SE CAPTURA REFERENCIA
            }

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
            try{
            Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.DesactivaComandos();
            this.Owner.ActivaComandos();
            this.Owner.Buscar();
            Mostrado = false;
            }
            catch { }
        }

        public void DesactivaComandos()
        {

        }

        public TraspasosAlmacenUserControl Owner { get; set; }

        private void CodigoTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.SeleccionaArticulo();
        }

        private void agregaProductoButtonItem_Click(object sender, EventArgs e)
        {
            this.SeleccionaArticulo();
        }
        private void RBGeneralesRButtonItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Grd_Pedido.Rows)
            {
                if (row.Cells.Count > 0)
                {
                    EditarRB = false;
                }
            }
            if (!EditarRB)
            {
                InhabilitaRB();

            }
            if (EditarRB)
            {
                if (RBGenerales.Checked)
                {
                    RBControlados.Checked = false;
                    this.tb_LotePedido.Value = 1;
                    this.tb_LotePedido.Enabled = false;
                }
                else
                {
                    if (RBGenerales.Checked == false)
                    {
                        RBControlados.Checked = true;
                        this.tb_LotePedido.Value = 2;
                        this.tb_LotePedido.Enabled = false;
                    }
                }
            }
            
            //this.RBControlados.Checked = false;
        }
        private void RBControladosRButtonItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Grd_Pedido.Rows)
            {
                if (row.Cells.Count > 0)
                {
                    EditarRB = false;
                }
            }
            if (!EditarRB)
            {
                InhabilitaRB();

            }
            if (EditarRB)
            {
                if (RBControlados.Checked)
                {
                    RBGenerales.Checked = false;
                    this.tb_LotePedido.Value = 2;
                    this.tb_LotePedido.Enabled = false;

                }
                else
                {
                    if (RBControlados.Checked == false)
                    {
                        RBGenerales.Checked = true;
                        this.tb_LotePedido.Value = 1;
                        this.tb_LotePedido.Enabled = false;

                    }
                }
            }
           
            
             
            //this.RBGenerales.Checked = false;
        }

        private void PedidoAlmacenUserControl_Load(object sender, EventArgs e)
        {
            if (Mostrado)
                return;
            else
                this.getFilas();
            this.InicializaPedido();
        }
        private void getFilas()
        {

           
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
            int[] Sec = new int[results.Length];
            int[] Lotes = new int[results.Length];
            String[] Articulo = new String[results.Length];
            String[] Concepto = new String[results.Length];
            String[] NoLote = new String[results.Length];
            String[] FechaCad = new String[results.Length];
            int[] CantS = new int[results.Length];
            int[] CantE = new int[results.Length];
            int[] CantR = new int[results.Length];
            int[] CantD = new int[results.Length];
            Double[] PrecioE = new Double[results.Length];
            int[] Caja = new int[results.Length];
            String[] Pedido = new String[results.Length];
            Decimal[] TotLote = new Decimal[results.Length];
            int MOTIVO = 0;             //AVM 13-04-2015
            Double Total = 0;
            Decimal DTotal = 0;
            int sec = 0;
            string CtlFolio = foliotextBoxX.Text;
            string CtlLote = tb_LotePedido.Text;

            //CANCELADO / HASTA NUEVO AVISO 14-04-2015
            if (cmbMotivoTras.SelectedIndex <= 0)     ///*JMQ 08-02-2017*/
            {
                MessageBox.Show("Debe seleccionar un motivo", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            
            //MOTIVO = cmbMotivoTras.SelectedIndex;

            object objSum = dtTraspaso.Compute("Sum(total)", "lote = " + CtlLote);
            if (objSum.ToString() != "")
                Total = Convert.ToDouble(objSum.ToString());

            foreach (DataRow rowdet in results)
            {
                Sec[sec] = sec + 1;
                Articulo[sec] = rowdet["id"].ToString();
                Concepto[sec] = rowdet["nombre"].ToString();
                NoLote[sec] = rowdet["NoLote"].ToString();
                FechaCad[sec] = rowdet["FechaCad"].ToString();
                CantS[sec] = Convert.ToInt16(rowdet["pedido"]);
                CantE[sec] = Convert.ToInt16(rowdet["enviado"]);
                CantR[sec] = Convert.ToInt16(rowdet["Recibido"]);
                //comentado por L 14/11/2013
                //CantD[sec] = Convert.ToInt16(rowdet["Devuelta"]);
                PrecioE[sec] = Convert.ToDouble(rowdet["Costo"]);
                Caja[sec] = Convert.ToInt16(rowdet["caja"]);
                Pedido[sec] = rowdet["Solicita"].ToString();
                bool esnull=String.IsNullOrEmpty(Pedido[sec]);
                if (Pedido[sec] == "" || esnull == false)
                    Pedido[sec] = "N";
                Lotes[sec] = Convert.ToInt16(rowdet["Lote"]);
                sec++;
            }
            int result;
            if (foliotextBoxX.Text == "Nuevo")
            {                
                foliotextBoxX.Text = traspasoAlmacenL.InsertaTraspasoAlmacen(Helpers.Sesion.Usuario.UsuariosID.ToString(), int.Parse(SucursalOrigenComboBox.SelectedValue.ToString()), int.Parse(SucursalDestinoComboBox.SelectedValue.ToString()), DTotal, Lotes, Sec, Articulo, Concepto, CantS, CantE, CantR, TotLote, PrecioE, Caja, NoLote, FechaCad, MOTIVO);
            }
            else
            {
                result = traspasoAlmacenL.UpdTraspaso(CtlFolio, Lotes, Total, Sec, Articulo, Concepto, CantS, CantE, CantR, CantD, PrecioE, PrecioE, Caja, Pedido, Convert.ToString(Helpers.Sesion.Usuario.UsuariosID), "0", NoLote, FechaCad);
            }
        }

        //private void guardarButtonItem_Click(object sender, EventArgs e)
        //{
        //    GuardarPedido();
        //    this.Back();
        //}

        private void CodigoTextBoxX_Enter(object sender, EventArgs e)
        {
            this.CodigoTextBoxX.SelectAll();
        }

        private void CodigoTextBoxX_KeyUp(object sender, KeyEventArgs e)//L 27/11/2013 MOSTRAR DESCRIPCION MIENTRAS SE VA CAPTURANDO EAN
        {
            if (
                ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) ||
                  (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                  (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
                  //LGS 24042016 PARA QUE SOLO BUSQUE EL NOMBRE DEL PRODUCTO AL PRESIONAR F2
                  (e.KeyCode == Keys.F2)
                )
               )
            {
                //MessageBox.Show((char)e.KeyValue+" "+(char)e.KeyData+" "+(char)e.KeyCode+" "+sender.ToString());
                //CodigoTextBoxX.Text += (char)e.KeyValue;
                SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
                //MessageBox.Show("-" + CodigoTextBoxX.Text + "% ");
                //LGS 25042016 PARA EVITAR QUE BUSQUE NOMBRE DE PRODUCTO CADA QUE TECLEAN UN CODIGO
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
        public bool VerificaTraspasoSN(string folio,int lote)
        { 
            SIFNegocio.Inventario.Traspasos ValidTraso = new SIFNegocio.Inventario.Traspasos();
          string resultado= ValidTraso.getActivotrasp(folio, lote);
            if (resultado.Contains('S')) 
            { 
                return true;
            } 
            else 
            { 
                return false; 
            }  
        }

        Boolean bandEsCodigoEnter = false;
        private void CodigoTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                forma = 0;
                Error err = new Error();
                string NOMBREaRT = " ";

                /************AVM 12-08-2015*********/
                //TRUE identifica si se esta agregando un producto desde la caja de texto o se cambia la cnatidad directamente del grid
                bandEsCodigoEnter = true;
                CantOld = 0;
                Boolean codigoEncontrado = false;
                for (int i = 0; i < Grd_Pedido.Rows.Count; i++)
                {

                    if (Grd_Pedido.Rows[i].Cells["ArticuloID"].Value.ToString() == CodigoTextBoxX.Text)
                    {
                        NOMBREaRT = Grd_Pedido.Rows[i].Cells["Nombre"].Value.ToString();
                        int rowActual = Grd_Pedido.Rows[i].Index;
                        //recorre el grid y localiza el articulo que se esta agregando para tomar la cantidad que se tiene antes de agregar el nuevo.
                        CantOld = int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString()); //Grd_Pedido[Grd_Pedido.Rows[i].Cells["enviado"].ColumnIndex, rowActual];
                        codigoEncontrado = true; 
                    }
                }

                /*AVM 14-08-2015*/
                if (RefPedido != "" || !string.IsNullOrEmpty(RefPedido.ToString()))
                {
                    if (!codigoEncontrado)
                    {
                        Console.Beep(800, 450);
                        SystemSounds.Hand.Play();
                        err = new Error();
                        err.mensaje = "*** El articulo ingresado no se encentra en la(s) fila(s) seleccionda(as)***";
                        err.ShowDialog();
                        //DESPUES DE MOSRAR EL MENSAJE SELECCIONAR EL CODIGO ERRONEO PARA ESCANEAR NUEVAMENTE
                        this.CodigoTextBoxX.SelectAll();
                        return;
                    }
                }
                
                /*********************************************/

                //this.AgregaArticulo(CodigoTextBoxX.Text);
                // Valida si existe el articulo en el pedido
                SIFNegocio.Inventario.Traspasos inventario = new SIFNegocio.Inventario.Traspasos();
                SIFNegocio.Articulo art = new SIFNegocio.Articulo();
                
                int result = inventario.ExistePedidoArt(foliotextBoxX.Text, tb_LotePedido.Text, CodigoTextBoxX.Text, cantidadTextBoxX.Value);//REGRESA 2 SI ES TRASPASO SIN PEDIDO

                //var articuloEnGrid = from grd in dtTraspaso.Columns where grd["id"] == CodigoTextBoxX.Text
                if (foliotextBoxX.Text != "Nuevo")
                {
                    if (!VerificaTraspasoSN(foliotextBoxX.Text, int.Parse((tb_LotePedido.Text))))
                    {
                        MessageBox.Show("Este traspaso fue Cancelado o Cerrado y ya NO se encuentra activo");
                        Back();
                        return;// VERIFICA QUE LA PRIMERA ITERACION EL FOLIO NO SEA NULL*******************
                    }
                }

                switch (result)
                {
                    case 1: // Pedido
                        SetTraspasoPedido(cantidadTextBoxX.Value);
                        break;
                    case 2: // NO Pedido
                        SetTraspasoPedido(cantidadTextBoxX.Value);
                        break;
                    case 3: // Pedido envio Mayor a lo solicitado
                 
                        Console.Beep(800, 450);
                        SystemSounds.Hand.Play();
                        //BeepMe();
                          err = new Error();
                          err.mensaje = "*** Cantidad enviada mayor a la solicitada ***" + Environment.NewLine + "Codigo: " + CodigoTextBoxX.Text + " Nombre:" + NOMBREaRT;
                        err.ShowDialog();
                       //MessageBox.Show("*** Cantidad enviada mayor a la solicitada ***" + Environment.NewLine + "articulo " + CodigoTextBoxX.Text, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default: // Articulo No existe en el pedido
                        Console.Beep(800, 450);
                        SystemSounds.Hand.Play();
                        //BeepMe();
                         err = new Error();
                         SIFModelo.Articulo articuloescan = art.BuscarPorClave(CodigoTextBoxX.Text);
                        if (articuloescan!=null)
                         err.mensaje = "El Articulo " + articuloescan.NOMBRE1+ " Codigo:" + CodigoTextBoxX.Text + ", NO existe en el Pedido ";
                        else
                            err.mensaje = "El Articulo con  Codigo : " + CodigoTextBoxX.Text + " , NO existe";

                        err.ShowDialog();

                        //MessageBoxEx.Show("El articulo " + CodigoTextBoxX.Text + ", NO existe en el Pedido ", ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
                        break;
                }


                ////if (result > 0) // Existe en el pedido
                ////{
                ////    SetTraspasoPedido(cantidadTextBoxX.Value);
                ////}
                ////else
                ////{
                ////   MessageBox.Show("El articulo " + CodigoTextBoxX.Text + ", NO existe en el Pedido", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ////}
                this.CodigoTextBoxX.SelectAll();
            }

            if (e.KeyCode == Keys.F3)
            {
                this.SeleccionaArticulo();
            }
            VerificaRows();

        }
       [DllImport("Kernel32.dll")]
        public static extern bool Beep(UInt32 frequency, UInt32 duration);
        public static void BeepMe()
        {
            int Frequency = 800;
            int DurationInMS = 550;
            uint u = Convert.ToUInt32(Frequency);
            uint y = Convert.ToUInt32(DurationInMS);
            Beep(u, y);
            
        }
        private void VerificaRows()
        {

            foreach (DataGridViewRow row in Grd_Pedido.Rows)
            {
                if (row.Cells.Count > 0)
                {
                    EditarRB = false;
                }
            }
            if (!EditarRB)
            {
                InhabilitaRB();
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
            AddArtTraspaso(NoLote, PrecioArt, Convert.ToInt32(tb_CajaTraspaso.Text)); //NoCaja
            
            cantidadTextBoxX.Value = 1;
            CodigoTextBoxX.Focus();
            object objSum = dtTraspaso.Compute("Sum(total)", null);
            if (objSum.ToString().IsFloat())
                label1.Text = double.Parse(objSum.ToString()).ToString("##,###,##0.00");
            object objSum1 = dtTraspaso.Compute("Sum(Enviado)", null);
            label2.Text = objSum1.ToString();
        }
        private void InhabilitaRB()
        {
            RBControlados.Enabled = false;
            RBGenerales.Enabled = false;
        }
        private void NoMostrarRB()
        {
            RBControlados.Visible = false;
            RBGenerales.Visible = false;

        }
        private void AsignaTipoTrasp(int lote_v)
        {
            if (lote_v == 1)
            {
                RBGenerales.Checked = true;
            }
            else
            {
                if (lote_v == 2)
                {
                    RBControlados.Checked = true;
                }
            }
        }


            private void cantidadTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (foliotextBoxX.Text != "Nuevo")
                {
                    if (!VerificaTraspasoSN(foliotextBoxX.Text, int.Parse((tb_LotePedido.Text))))
                    {
                        MessageBox.Show("Este traspaso fue Cancelado o Cerrado y ya NO se encuentra activo");
                        Back();
                        return;// VERIFICA QUE LA PRIMERA ITERACION EL FOLIO NO SEA NULL*******************
                    }
                }
                forma = 2;
                //AgregaArticulo();
                ////SetTraspasoPedido(cantidadTextBoxX.Value);
                SIFNegocio.Inventario.Traspasos inventario = new SIFNegocio.Inventario.Traspasos();
                int result = inventario.ExistePedidoArt(foliotextBoxX.Text, tb_LotePedido.Text, CodigoTextBoxX.Text, cantidadTextBoxX.Value);

                switch (result)
                {
                    case 1: // Pedido
                        SetTraspasoPedido(cantidadTextBoxX.Value);
                        break;
                    case 2: // NO Pedido
                        SetTraspasoPedido(cantidadTextBoxX.Value);
                        break;
                    case 3: // Pedido envio Mayor a lo solicitado
                       MessageBox.Show("*** Cantidad enviada mayor a la solicitada ***" + Environment.NewLine + "articulo " + CodigoTextBoxX.Text, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default: // Articulo No existe en el pedido
                       MessageBox.Show("El articulo " + CodigoTextBoxX.Text + ", NO existe en el Pedido", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }

        private void AddArtTraspaso(int Lote, double Precio, int NoCaja)
        {
            String ProductName = "Traspasos";
            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(CodigoTextBoxX.Text);
            int existencias = 0;
            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
            SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow Invt = inventario.InventarioArticulo(articulo, Helpers.Sesion.Sucursal);
            Lote = int.Parse(tb_LotePedido.Text);
            Precio = Invt.COSTO_PROM;
            int iCant = int.Parse(cantidadTextBoxX.Text);
            DataRow[] Regs = dtTraspaso.Select("ID='" + CodigoTextBoxX.Text + "' AND LOTE=" + tb_LotePedido.Text + " AND NOLOTE='" + textBoxX1.Text + "' AND FechaCad='" + FechaCaducidad.Value.ToString() + "'");
            DataRow RegArt = null;
            if (Regs.Count() > 0)
                RegArt = Regs[0];


            if (RegArt == null)
            {
                // verificamos existencia
                if (RefPedido.Trim().Length > 2)
                {
                    if (MessageBoxEx.Show("El articulo NO existe en el Pedido" + Environment.NewLine + "¿Desea agregarlo?", ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (inventario.InventarioArticulo(articulo, iCant, out existencias))
                        {
                            dtTraspaso.Rows.Add(Lote, Partidas,
                                          CodigoTextBoxX.Text,
                                          articulo.NOMBRE1,
                                          textBoxX1.Text,
                                          FechaCaducidad.Value.ToString(),
                                          0,
                                          cantidadTextBoxX.Text,
                                          0,
                                          existencias,
                                          Precio,
                                          NoCaja,
                                          'N');
                            Partidas++;
                            dtTraspaso.DefaultView.Sort = "Partida DESC,lote,caja, id ASC";
                            GuardarPedido();
                        }
                    }
                }
                else
                {
                    if (inventario.InventarioArticulo(articulo, iCant, out existencias))
                    {
                        dtTraspaso.Rows.Add(Lote, Partidas,
                                  CodigoTextBoxX.Text,
                                  articulo.NOMBRE1,
                                  textBoxX1.Text,
                                  FechaCaducidad.Value.ToString(),
                                  0,
                                  cantidadTextBoxX.Text,
                                  0,
                                  existencias,
                                  Precio,
                                  NoCaja,
                                  'N');
                        Partidas++;
                        dtTraspaso.DefaultView.Sort = "Partida DESC,lote,caja, id ASC";
                        GuardarPedido();
                        // creamos el nuevo registro
                    }
                }
            }
            else
            {
                if (inventario.InventarioArticulo(articulo, iCant, out existencias))
                {
                    if ((Convert.ToInt16(RegArt["enviado"].ToString()) + Convert.ToInt16(cantidadTextBoxX.Text)) > Convert.ToInt16(RegArt["Pedido"].ToString()) & (Convert.ToInt16(RegArt["Pedido"].ToString()) > 0))
                    {
                        if (MessageBoxEx.Show("la cantidad Pedida es menor deseas agregar" + Environment.NewLine + "¿Desea agregarlo?", ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                            return;
                    }
                    RegArt["enviado"] = Convert.ToInt16(RegArt["enviado"].ToString()) + Convert.ToInt16(cantidadTextBoxX.Text);
                    RegArt["Costo"] = Precio;
                    RegArt["Lote"] = tb_LotePedido.Text;
                    RegArt["caja"] = NoCaja;
                    GuardarPedido();
                }

            }
            //PONEMOS EL COLOR A LA FILA
            for (int i = 0; i < Grd_Pedido.Rows.Count; i++)
            {/*

                if (int.Parse(Grd_Pedido.Rows[i].Cells["pedido"].Value.ToString()) < int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString()) & (int.Parse(Grd_Pedido.Rows[i].Cells["pedido"].Value.ToString()) > 0))
                    Grd_Pedido.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(253, 215, 0);
                if (int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString()) < int.Parse(Grd_Pedido.Rows[i].Cells["pedido"].Value.ToString()))
                    Grd_Pedido.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(3, 200, 150);
                if (int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString()) == int.Parse(Grd_Pedido.Rows[i].Cells["pedido"].Value.ToString()))
                    Grd_Pedido.Rows[i].DefaultCellStyle.BackColor = Color.White;
                if (int.Parse(Grd_Pedido.Rows[i].Cells["existencia"].Value.ToString()) < int.Parse(Grd_Pedido.Rows[i].Cells["pedido"].Value.ToString()))
                    Grd_Pedido.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(204, 0, 43);*/
                if (int.Parse(Grd_Pedido.Rows[i].Cells["pedido"].Value.ToString()) > int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString()) & (int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString()) > 0))
                    Grd_Pedido.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;//FromArgb(255, 255, 255);//surtido incompleto
                if (int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString()) == int.Parse(Grd_Pedido.Rows[i].Cells["pedido"].Value.ToString()))
                    Grd_Pedido.Rows[i].DefaultCellStyle.BackColor = Color.Green;//FromArgb(0, 255, 0);//Surtido
                /* if ((int.Parse(Grd_Pedido.Rows[i].Cells["existencia"].Value.ToString()) < int.Parse(Grd_Pedido.Rows[i].Cells["pedido"].Value.ToString())) || (int.Parse(Grd_Pedido.Rows[i].Cells["existencia"].Value.ToString()) < int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString())))
                     Grd_Pedido.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(204, 0, 43);*/

                if (int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString()) == 0)
                    Grd_Pedido.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 51, 51);//No escaneado, enviado o surtido
            }

        }

        private void tb_CajaTraspaso_KeyDown(object sender, KeyEventArgs e)
        {
            ////String ProductName = "Traspasos";

            ////if (e.KeyCode == Keys.Enter)
            ////{
            ////     AgregaArticulo();
            ////}
        }

        private void FechaCaducidad_Enter(object sender, EventArgs e)
        {
            ////AgregaArticulo();
        }

        #region ROMA

        private bool SetTraspasoPedido(int Cant)
        {

            Regex objNotNumPattern = new Regex(@"[^0-9]");
            bool OK = false;
            System.Reflection.PropertyInfo pi = cmbMotivoTras.SelectedItem.GetType().GetProperty("ID");

            if (SucursalOrigenComboBox.SelectedIndex < 0)
            {
               MessageBox.Show("Debe Seleccionar un Origen", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                SucursalOrigenComboBox.Focus();
                return false;
            }

            if (SucursalDestinoComboBox.SelectedIndex <= 0)
            {
               MessageBox.Show("Debe Seleccionar destino", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                SucursalOrigenComboBox.Focus();
                return false;
            }
            if ((cmbMotivoTras.SelectedIndex <= 0) & activaSelectPedido == true)     ///*JMQ 08-02-2017*/
            {
                MessageBox.Show("Debe seleccionar un motivo", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (Convert.ToInt16(SucursalOrigenComboBox.SelectedValue.ToString()) == Convert.ToInt16(SucursalDestinoComboBox.SelectedValue.ToString()))
            {
               MessageBox.Show("El Origen y Destino del traspaso NO puede ser el mismo", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                SucursalDestinoComboBox.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(CodigoTextBoxX.Text))
            {
               MessageBox.Show("Debe seleccionar un articulo", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                CodigoTextBoxX.Focus();
                return false;
            }

            if (!RBControlados.Checked && !RBGenerales.Checked && (Int32)(pi.GetValue(cmbMotivoTras.SelectedItem, null)) > 0)
            {
               MessageBox.Show("Debe seleccionar el tipo de traspaso", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                CodigoTextBoxX.Focus();
                return false;
            }
            SIFNegocio.Articulo arti = new SIFNegocio.Articulo();
            SIFModelo.Articulo articuloescan = arti.BuscarPorClave(CodigoTextBoxX.Text);
            if (articuloescan != null && PedidoTraspaso == false)
            {
                if (RBGenerales.Checked && articuloescan.TIPO_MEDICAMENTO_CVE.Contains("F1"))
                {
                    MessageBox.Show("El Codigo: " + articuloescan.ARTICULO_ID + " - " + articuloescan.NOMBRE1 + " es un articulo controlado,no se puede cargar en este folio");
                    return false;
                }
                else
                if (RBControlados.Checked && !articuloescan.TIPO_MEDICAMENTO_CVE.Contains("F1"))
                {
                    MessageBox.Show("El Codigo: " + articuloescan.ARTICULO_ID + " - " + articuloescan.NOMBRE1 + " es un articulo NO controlado,no se puede cargar en este folio");
                    return false;
                }
            }

            /* AVM 08-04-2015 Validar que seleccione un motivo del traspaso.
            if (string.IsNullOrEmpty(txtMotivo.Text))
            {
                return false;
            }
            */
            SIFNegocio.Inventario.Traspasos inventario = new SIFNegocio.Inventario.Traspasos();
            string lotttt = string.Empty, refPEdido = string.Empty;
            if (foliotextBoxX.Text == "Nuevo")
                lotttt = tb_LotePedido.Text; //textBoxX1.Text;
            else
            {
                lotttt = Grd_Pedido.Rows[0].Cells["LoteID"].Value.ToString();

            }

            if (RefPedido == "" || string.IsNullOrEmpty(RefPedido.ToString()) || RefPedido == " ")
            {
                refPEdido = "0";
            }
            else
            {
                refPEdido = RefPedido;
            }


            if (idMotivoT == 0)
            {
                idMotivoT = (Int32)(pi.GetValue(cmbMotivoTras.SelectedItem, null));
            }


            string result = inventario.SetTraspasoPedido(refPEdido,
                Helpers.Sesion.Usuario.UsuariosID.ToString(),
                foliotextBoxX.Text,
                Helpers.Sesion.Sucursal.SucursalesID,
                Helpers.Sesion.Usuario.AccesoID,
               Convert.ToInt16(SucursalOrigenComboBox.SelectedValue.ToString()),
               Convert.ToInt16(SucursalDestinoComboBox.SelectedValue.ToString()),
               CodigoTextBoxX.Text,
               Cant,
               lotttt,
               FechaCaducidad.Value,
               "N",
               idMotivoT

               ); // textBoxX1.Text,


            // Valida resultado
            if (objNotNumPattern.IsMatch(result))
            {
                Console.Beep(800, 450);
                Error err = new Error();
                err.mensaje = result;
                err.ShowDialog();
                //MessageBoxEx.Show(result, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                OK = false;
            }
            else
            {


                string r = new SIFNegocio.Inventario.Traspasos().getNumeroLotesSku1(CodigoTextBoxX.Text);

                if (r.Length == 22)
                {

                }
                else
                {
                    int cant2 = 0;
                    int rows = -1;
                    if (forma == 0)
                        cant2 = Cant;
                    else if (forma == 1)
                        cant2
                            = CantNew;
                    else
                        cant2 = Cant;

                    if (cant2 == 0)
                    {

                    }
                    else
                    {


                        foreach (DataGridViewRow dgv in Grd_Pedido.Rows)
                        {
                            if (dgv.Cells["ArticuloID"].Value.ToString() == CodigoTextBoxX.Text)
                            {
                                rows = dgv.Index;
                                break;
                            }
                        }

                        if (rows < 0)
                        {
                            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
                            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(CodigoTextBoxX.Text);
                            SIFModelo.Inventarios.SkuCaducidad MCaducidad = new SIFModelo.Inventarios.SkuCaducidad();
                            MCaducidad.articuloId = articulo.ARTICULO_ID;
                            MCaducidad.Foliot = result;
                            MCaducidad.cantidad = cant2;
                            MCaducidad.lotet = Int32.Parse(tb_LotePedido.Text);
                            MCaducidad.nombre = articulo.NOMBRE1.ToString();
                            MCaducidad.CantidadPedida = 0;
                            Console.Beep(900, 300);
                            Complementos.frmSelecionCaducidad frm = new Complementos.frmSelecionCaducidad(MCaducidad);
                            if (frm.ShowDialog() != DialogResult.OK)
                            {
                                return false;
                            }
                            else
                            {
                                Cant = frm.Totalpescaneado;
                            }
                        }
                        else
                        {


                            SIFModelo.Inventarios.SkuCaducidad MCaducidad = new SIFModelo.Inventarios.SkuCaducidad();
                            MCaducidad.articuloId = Grd_Pedido.Rows[rows].Cells["ArticuloID"].Value.ToString();
                            MCaducidad.Foliot = foliotextBoxX.Text;
                            MCaducidad.cantidad = cant2;
                            MCaducidad.lotet = int.Parse(lotttt);
                            MCaducidad.nombre = Grd_Pedido.Rows[rows].Cells["Nombre"].Value.ToString();
                            MCaducidad.CantidadPedida = Int32.Parse(Grd_Pedido.Rows[rows].Cells["Pedido"].Value.ToString());
                            Console.Beep(900, 300);
                            Complementos.frmSelecionCaducidad frm = new Complementos.frmSelecionCaducidad(MCaducidad);
                            if (frm.ShowDialog() != DialogResult.OK)
                            {
                                return false;
                            }
                            else
                            {
                                Cant = frm.Totalpescaneado;
                            }
                        }
                    }

                }











                foliotextBoxX.Text = result;
                if (RefPedido == "" || string.IsNullOrEmpty(RefPedido.ToString()) || RefPedido == " ")
                {
                    dtTraspaso = traspasoAlmacenL.GetTraspasoDet(foliotextBoxX.Text, Int32.Parse(tb_LotePedido.Text));
                    dtTraspaso.DefaultView.Sort = "lote, partida";
                }
                else
                {
                    /*AVM 18-08-2015*/
                    /***Busca el registro que se esta agregando en la BD para actualizarlo en el grid y el DataTable***/
                    DataTable dtTraspasoDet = new DataTable();
                    dtTraspasoDet = traspasoAlmacenL.GetTraspasoDetPorID(foliotextBoxX.Text, CodigoTextBoxX.Text);

                    ///Busca el elemento que se esta agregando en el grid para re-establecer los valores de 'enviado' y 'Existencia'
                    IEnumerable<DataRow> itemInDT = from order in dtTraspaso.AsEnumerable()
                                                    where order.Field<string>("id").Equals(CodigoTextBoxX.Text)
                                                    //&& order.Field<int>("Partida") == int.Parse(tb_LotePedido.Text.ToString()) //No se puede comprar la partida cuando se agrega desde el txtCodigo
                                                    select order;
                    var Item = itemInDT.FirstOrDefault();

                    ///Busca el elemento que retorna la consulta en la bd para obtener los valores que se entablecerán en 'enviado' y 'Existencia'
                    IEnumerable<DataRow> ArtAgregado = from order in dtTraspasoDet.AsEnumerable()
                                                       where order.Field<string>("id").Equals(CodigoTextBoxX.Text)
                                                          && order.Field<int>("Partida") == int.Parse(Item["Partida"].ToString())
                                                       select order;
                    var agregado = ArtAgregado.FirstOrDefault();

                    //actualiza la cantidad enviada en el grid.
                    Item["enviado"] = int.Parse(agregado[7].ToString());
                    ///Actualiza las existencias en el grid
                    Item["Existencia"] = int.Parse(agregado[9].ToString());
                    /*******************************************************************************************************/

                    for (int i = 0; i < Grd_Pedido.Rows.Count; i++)
                    {
                        if (Grd_Pedido.Rows[i].DefaultCellStyle.BackColor == Color.Green)
                        {
                            Grd_Pedido.Rows[i].Cells["incidencia"].Value = 1;
                        }
                        else if (Grd_Pedido.Rows[i].DefaultCellStyle.BackColor == Color.FromArgb(255, 51, 51))
                        {
                            Grd_Pedido.Rows[i].Cells["incidencia"].Value = 3;
                        }
                        else if (Grd_Pedido.Rows[i].DefaultCellStyle.BackColor == Color.Yellow)
                        {
                            Grd_Pedido.Rows[i].Cells["incidencia"].Value = 2;
                        }
                        else
                            Grd_Pedido.Rows[i].Cells["incidencia"].Value = 4;

                        //int incidencia = Convert.ToInt32(Grd_Pedido.Rows[i].Cells["Pedido"].Value.ToString()) - Convert.ToInt32(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString());

                        if (Grd_Pedido.Rows[i].Cells["ArticuloID"].Value.ToString() == CodigoTextBoxX.Text)
                        {
                            int rowActual = Grd_Pedido.Rows[i].Index;
                            /*if (Grd_Pedido.Rows.Count != 0)
                                rowActual = rowActual - 1;*/
                            /*if (bandEsCodigoEnter == false)
                                cantidad = CantOld;
                            else
                                cantidad = int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString());
                            */
                            //Grd_Pedido.Rows[i].Cells["enviado"].Value = CantOld + Cant;
                            Grd_Pedido.Rows[i].Selected = true;
                            Grd_Pedido.FirstDisplayedCell = Grd_Pedido[Grd_Pedido.Rows[i].Cells["enviado"].ColumnIndex, rowActual];

                            //Grd_Pedido.CurrentCell = Grd_Pedido[Grd_Pedido.Rows[i].Cells["enviado"].ColumnIndex, rowActual]; //-1

                            /**AVM 14-08-2015**/
                            if (rowActual == 0)
                                Grd_Pedido.CurrentCell = Grd_Pedido[Grd_Pedido.Rows[i].Cells["enviado"].ColumnIndex, rowActual]; //-1
                            else
                                Grd_Pedido.CurrentCell = Grd_Pedido[Grd_Pedido.Rows[i].Cells["enviado"].ColumnIndex, rowActual - 1]; //-1
                            /*****************/
                        }
                    }
                    dtTraspaso.DefaultView.Sort = "incidencia desc";
                    Grd_Pedido.DataSource = dtTraspaso;
                    //Grd_Pedido.Sort(Grd_Pedido.Columns["incidencia"], ListSortDirection.Descending);
                    /* DataGridView datagrid2 = new DataGridView();
                     datagrid2 = Grd_Pedido;
                     datagrid2.Sort(datagrid2.Columns["incidencia"], ListSortDirection.Descending);
                     // dtTraspaso.DefaultView.Sort = "incidencia desc";
                    // Grd_Pedido.DataSource = dtTraspaso;
                    */
                }

                int activeRow = 0;
                int activeColumn = 0;
                if (Grd_Pedido.CurrentCell != null)
                {
                    activeRow = Grd_Pedido.CurrentCell.RowIndex;
                    activeColumn = Grd_Pedido.CurrentCell.ColumnIndex;
                }
                if (RefPedido != "" || string.IsNullOrEmpty(RefPedido.ToString()) || RefPedido != " ")
                {
                    Grd_Pedido.DataSource = null;
                    Grd_Pedido.DataSource = dtTraspaso;
                }
                if ((Grd_Pedido.Rows.Count - 1) > (activeRow))
                {
                    Grd_Pedido.CurrentCell = Grd_Pedido.Rows[activeRow + 1].Cells[activeColumn];
                }
                else
                {
                    Grd_Pedido.CurrentCell = Grd_Pedido.Rows[activeRow].Cells[activeColumn];
                }
                OK = true;
            }
            CalculaTotal();
            return OK;

        
        }

        private bool SetTraspasoPedidoArt(string NoLote, int Cant)
        {

            Regex objNotNumPattern = new Regex(@"[^0-9]");
            bool OK = false;

            if (SucursalOrigenComboBox.SelectedIndex < 0 || SucursalDestinoComboBox.SelectedIndex < 0)
            {
               MessageBox.Show("Debe Seleccionar un Origen y Destino", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                SucursalOrigenComboBox.Focus();
                return false;
            }

            if (Convert.ToInt16(SucursalOrigenComboBox.SelectedValue.ToString()) == Convert.ToInt16(SucursalDestinoComboBox.SelectedValue.ToString()))
            {
               MessageBox.Show("El Origen y Destino del traspaso NO puede ser el mismo", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                SucursalDestinoComboBox.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(CodigoTextBoxX.Text))
            {
               MessageBox.Show("Debe seleccionar un articulo", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                CodigoTextBoxX.Focus();
                return false;
            }

            SIFNegocio.Inventario.Traspasos inventario = new SIFNegocio.Inventario.Traspasos();

            string result = inventario.SetTraspasoPedidoArt(foliotextBoxX.Text, NoLote.ToString(), Helpers.Sesion.Sucursal.SucursalesID, CodigoTextBoxX.Text, Cant);

            // Valida resultado
            if (objNotNumPattern.IsMatch(result))
            {
               MessageBox.Show(result, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                OK = false;
            }
            else
            {
                foliotextBoxX.Text = result;
                dtTraspaso = traspasoAlmacenL.GetTraspasoDet(foliotextBoxX.Text, int.Parse(NoLote));
                dtTraspaso.DefaultView.Sort = "incidencia desc,lote, partida";
                Grd_Pedido.DataSource = null;
                Grd_Pedido.DataSource = dtTraspaso;
                OK = true;
            }
            CalculaTotal();

            return OK;
        }

        private void CalculaTotal()
        {
            object objSum = dtTraspaso.Compute("Sum(total)", null);
            if (string.IsNullOrEmpty(objSum.ToString()))
            {
                return;
            }
            label1.Text = double.Parse(objSum.ToString()).ToString("##,###,##0.00");
            object objSum1 = dtTraspaso.Compute("Sum(Enviado)", null);
            object objSumPedido = dtTraspaso.Compute("Sum(Pedido)", null);
            String vs = "( " + objSumPedido.ToString() + "/" + objSum1.ToString() +")";
            label2.Text = vs;
            string ArtID = string.Empty;
            int GuardaCantidadPedida = 0;

            foreach (DataGridViewRow row in Grd_Pedido.Rows)
            {
                ArtID = row.Cells["ArticuloID"].Value.ToString();
                if (CodigoTextBoxX.Text.Contains(ArtID))
                {
                    row.Selected = true;
                    int ren = row.Cells["ArticuloID"].RowIndex;
                    //Grd_Pedido.FirstDisplayedCell = Grd_Pedido[row.Cells["ArticuloID"].ColumnIndex, ren];
                }
            }

            foreach (DataGridViewRow row in Grd_Pedido.Rows)
            {
                GuardaCantidadPedida = int.Parse(row.Cells["pedido"].Value.ToString());
                if (GuardaCantidadPedida>0)
                {
                    PedidoTraspaso = true; 
                }
            }
            
        }

        #endregion ROMA

        private void Grd_Pedido_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)//Verifica que el traspaso no haya cambiado de status
        {
            if (foliotextBoxX.Text != "Nuevo")
            {
                if (!VerificaTraspasoSN(foliotextBoxX.Text, int.Parse((tb_LotePedido.Text))))
                {
                    MessageBox.Show("Este traspaso fue Cancelado o Cerrado y ya NO se encuentra activo");
                    Back();
                    return;
                }
            }
            string Col_Name = Grd_Pedido.Columns[e.ColumnIndex].Name;
            //int CantOld, CantNew, CantPed, Envio;

            switch (Col_Name)
            {
                case "enviado":
                    if (Grd_Pedido[e.ColumnIndex, e.RowIndex].IsInEditMode)
                    {
                        CodigoTextBoxX.Text = Grd_Pedido["ArticuloID", e.RowIndex].Value.ToString();
                        CantPed = int.Parse(Grd_Pedido["pedido", e.RowIndex].Value.ToString());
                        CantOld = int.Parse(Grd_Pedido["enviado", e.RowIndex].Value.ToString());
                        CantNew = int.Parse(e.FormattedValue.ToString());
                        forma = 1;
                        if (foliotextBoxX.Text != "Nuevo" /*&& LabelPedido.Text != " "*/)//L 27/11/2013 En caso de un traspaso sin pedido, debe permitir modificar el grid aunque la cantidad  enviada sea mayor a la pedida
                        if ((CantNew > CantPed)&& (LabelPedido.Text.ToString()!= " ")) // Mayor a lo solicitado
                        {
                            Grd_Pedido.CancelEdit();
                            e.Cancel = true;
                            Console.Beep(800, 450);
                            SystemSounds.Hand.Play();
                           // BeepMe();
                            Error err = new Error();
                            err.mensaje = "*** Cantidad enviada mayor a la solicitada ***" + Environment.NewLine + "Articulo " + CodigoTextBoxX.Text + " " + Grd_Pedido["Nombre", e.RowIndex].Value.ToString();
                            err.ShowDialog();
                           ///MessageBox.Show("*** Cantidad enviada mayor a la solicitada ***" + Environment.NewLine + "articulo " + CodigoTextBoxX.Text, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (CantOld != CantNew)
                            {
                                Envio = CantNew - CantOld;
                                Grd_Pedido.EndEdit();
                                e.Cancel = true;
                                /*AVM 12-08-2015 sirve para identificar si se esta agregando un producto desde la caja de texto o se cambia la cnatidad directamente del grid*/
                                bandEsCodigoEnter = false;
                                if (!SetTraspasoPedido(Envio))
                                {
                                    Grd_Pedido["enviado", e.RowIndex].Value = CantOld;
                                    Grd_Pedido.CancelEdit();
                                }
                            }
                            else
                            {
                                e.Cancel = true;

                                int activeRow = Grd_Pedido.CurrentCell.RowIndex;
                                int activeColumn = Grd_Pedido.CurrentCell.ColumnIndex;

                                Grd_Pedido.EndEdit();

                                if ((Grd_Pedido.Rows.Count - 1) > (activeRow))
                                {
                                    Grd_Pedido.CurrentCell = Grd_Pedido.Rows[activeRow + 1].Cells[activeColumn];
                                }
                                else
                                {
                                    Grd_Pedido.CurrentCell = Grd_Pedido.Rows[activeRow].Cells[activeColumn];
                                }
                            }
                        }
                    }
                    CalculaTotal();
                    break;
                default:
                    break;
            }
        }

        private void Grd_Pedido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Grd_Pedido.Rows[e.RowIndex].ErrorText = string.Empty;
            _celWasEndEdit = Grd_Pedido[e.ColumnIndex, e.RowIndex];
            CodigoTextBoxX.Focus();//L 28/11/2013 al editar la celda, regresa el focus a captura EAN
        }

        private void Grd_Pedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && _celWasEndEdit == null)
            {
                if (foliotextBoxX.Text != "Nuevo")
                {
                    if (!VerificaTraspasoSN(foliotextBoxX.Text, int.Parse((tb_LotePedido.Text))))
                    {
                        MessageBox.Show("Este traspaso fue Cancelado o Cerrado y ya NO se encuentra activo");
                        Back();
                        return;// VERIFICA QUE LA PRIMERA ITERACION EL FOLIO NO SEA NULL*******************
                    }
                }
                e.SuppressKeyPress = true;
                int Cant = 0;
                string msg = string.Empty;
                if (Grd_Pedido.SelectedRows.Count > 0)
                {
                    if (RefPedido == "" || RefPedido == " ")
                    {
                        foreach (DataGridViewRow row in Grd_Pedido.SelectedRows)
                        {
                            try
                            {
                                msg = row.Cells["ArticuloID"].Value.ToString() + " - " + row.Cells["Nombre"].Value.ToString();
                                Cant = int.Parse(row.Cells["enviado"].Value.ToString()) * -1;
                                if (MessageBox.Show("¿Borrar el registro " + msg + "?", ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                {
                                    CodigoTextBoxX.Text = row.Cells["ArticuloID"].Value.ToString();
                                    SetTraspasoPedidoArt(row.Cells["LoteID"].Value.ToString(), Cant);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString() + System.Environment.NewLine, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No puedes suprimir lineas de un Pedido.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }


        private void Grd_Pedido_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
            Partidas = dtTraspaso.Rows.Count + 1;
            for (int i = 0; i < Grd_Pedido.Rows.Count; i++)
            {
                string ARTICULOID = Grd_Pedido.Rows[i].Cells["ArticuloID"].Value.ToString();
                if (int.Parse(Grd_Pedido.Rows[i].Cells["pedido"].Value.ToString()) > int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString()) & (int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString()) > 0))
                {
                    Grd_Pedido.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                   // this.dataGridView1.Rows[e.RowIndex].Cells[dataGridView_ForeColorNum.Name].Value = 1;
                   // Grd_Pedido.Rows[i].Cells[Grd_Pedido_ForeColorNum.Name].Value = 1;
                }//FromArgb(255, 255, 255);//surtido incompleto
                if (int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString()) == int.Parse(Grd_Pedido.Rows[i].Cells["pedido"].Value.ToString()))
                {
                    Grd_Pedido.Rows[i].DefaultCellStyle.BackColor = Color.Green;//FromArgb(0, 255, 0);//Surtido
                }
                if (int.Parse(Grd_Pedido.Rows[i].Cells["enviado"].Value.ToString()) == 0)
                {
                    Grd_Pedido.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 51, 51);//No escaneado, NO enviado o NO surtido
                }
            }
        }

        /*AVM 14-08-2015*/
        private void SucursalDestinoComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if(IsType.IsIntegerPositive(SucursalDestinoComboBox.SelectedValue.ToString()) && !foliotextBoxX.Text.Equals("Nuevo"))
                    SIFNegocio.Inventario.Traspasos.ActualizarTraspaso(int.Parse(SucursalDestinoComboBox.SelectedValue.ToString()), foliotextBoxX.Text);
            }
            catch (Exception)
            {

            }            
        }

        private void IncidenciasButtonItem_Click(object sender, System.EventArgs e)
        {            
            if (RefPedido == "" || string.IsNullOrEmpty(RefPedido.ToString()) || RefPedido == " ")
            {
               MessageBox.Show("En un pedido por asignar no existen incidencias.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Pedido_Almacen_Incidencias.rpt", "{CS_PEDIDO_ALMACEN_INCIDENCIAS.FOLIO}='" + TraspasoID +
                                                                                 "' AND {CS_PEDIDO_ALMACEN_INCIDENCIAS.FILA} IN [" + filasMostrar + "]"); //AND {CS_PEDIDO_ALMACEN_INCIDENCIAS.USUARIO_ENVIA}='" + SIFNegocio.Helpers.Sesion.Usuario.UsuariosID + "'
            Impresion.ShowDialog();
        }
    #region Integracion para lote y caducidad
            //JMQC  13-12-217      
        private void Grd_Pedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            try
                {
                string[] arr = new string[5];

                arr[0] = Grd_Pedido["ArticuloID", e.RowIndex].Value.ToString(); //codigo de el articulo
                arr[1] = Grd_Pedido["Nombre", e.RowIndex].Value.ToString();     //nombre de el articulo
                arr[2] = Grd_Pedido["Enviado", e.RowIndex].Value.ToString();    // cantidad escaneada para lote y caducidad
                arr[3] = foliotextBoxX.Text+"-"+tb_LotePedido.Text;             //referencia de el articulo
                arr[4] = "3";                                                   //tipo de movimiento


                if (Grd_Pedido.Columns[e.ColumnIndex].HeaderText == "No Lote")
                    {

                    if (int.Parse(arr[2]) <= 0)
                        MessageBox.Show("La cantidad surtida no puede ser 0", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    frmRegistraCad frm = new frmRegistraCad(arr);
                    frm.ShowDialog();

                    }
                }
            catch (Exception exc) {
                MessageBox.Show(exc.ToString());
                
                }
            
            }
    #endregion Integracion para lote y caducidad
        /****************/
    }
}
