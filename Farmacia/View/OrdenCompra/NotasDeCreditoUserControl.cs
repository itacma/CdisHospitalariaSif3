using DevComponents.DotNetBar;
using SIF.View.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SIF.View.OrdenCompra
{
    public partial class NotasDeCreditoUserControl : Templates.CatalogoUserControl
    {

        public MainForm Owner;
        public bool Mostrado = false;
        public NotasDeCreditoUserControl()
        {
            InitializeComponent();
            cargaProveedores();
            this.Grd_Pedido.AutoGenerateColumns = false;
        }


        public string AjusteID;
        public int lote;
        public String SucursalO;
        public String SucursalD;
        public Boolean MostradoArt = false;
        DataTable dtNotasCredito = new DataTable();
        DataTable dtAjustes = new DataTable();
        DataTable dtPedido = new DataTable();
        double PrecioArt = 0;
        string TipoArt = string.Empty;
        int NoLote = 0;
        public string Usr_Envia;
        public NotasDeCreditoControl Parent = null;


        // public bool Mostrado { get; set; }


        private void Devolucion()
        {
            View.OrdenCompra.OrdenesCompraUserControl OC = new OrdenCompra.OrdenesCompraUserControl();
            OC.Owner = this;
            OC.Muestra();
        }


        internal void Muestra()
        {
            if (Mostrado)
            {
                return;
            }

            this.Dock = DockStyle.Fill;
            this.ActivaComandos();
            Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            Mostrado = true;
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
        { BindingList<SIFModelo.Sucursal> sucursales = new BindingList<SIFModelo.Sucursal>();
            List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().Buscar("", "").DataSource as List<SIFModelo.Sucursal>;

            foreach (SIFModelo.Sucursal sucursalBd in sucursalesBD)
            {
                sucursales.Add(sucursalBd);
            }

            SucursalDestinoComboBox.DataSource = sucursales;
            SucursalDestinoComboBox.DisplayMember = "NOMBRE";
            SucursalDestinoComboBox.ValueMember = "SUCURSALESID";
        }

        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.guardarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
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
                // System.Windows.Forms.SendKeys.Send("{TAB}");
            }

            this.AgregaArticulo(articulo);
        }

        SIFNegocio.Inventario.Ajustes ajusteAlmacenL = new SIFNegocio.Inventario.Ajustes();
        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            int cantidad = 1;

            if (this.cantidadTextBoxX.Text.IsIntegerPositive())
                cantidad = int.Parse(this.cantidadTextBoxX.Text);

            CodigoTextBoxX.Text = articulo.ARTICULO_ID;
            cantidadTextBoxX.Focus();
            //LIMPIAMOS TODAS LOS DATOS
            AgregaArticulo();

        }
        private void iniciacilizaNotacredito()
        {
            
            dtNotasCredito.Columns.Add("concepto", typeof(String));
            dtNotasCredito.Columns.Add("foliofiscal", typeof(string));            
            dtNotasCredito.Columns.Add("Saldo", typeof(double));
            dtNotasCredito.Columns.Add("proveedor_id", typeof(string));            
            dtNotasCredito.PrimaryKey = new DataColumn[] { dtNotasCredito.Columns["foliofiscal"] };
            Grd_Pedido.AutoGenerateColumns = true;
            Grd_Pedido.DataSource = dtNotasCredito;
            Grd_Pedido.Columns[2].DefaultCellStyle.Format = "##,##0.00";
        }


        private void InicializaPedido()
        {
            dtAjustes.Columns.Add("lote", typeof(int));
            dtAjustes.Columns.Add("id", typeof(string));
            dtAjustes.Columns.Add("nombre", typeof(string));
            dtAjustes.Columns.Add("cantidad", typeof(int));
            dtAjustes.Columns.Add("ultimo_costo", typeof(double));
            dtAjustes.Columns.Add("costo", typeof(double));
            dtAjustes.Columns.Add("concepto", typeof(string));
            dtAjustes.Columns.Add("total", typeof(double), "cantidad * costo");
            dtAjustes.PrimaryKey = new DataColumn[] { dtAjustes.Columns["id"] };
            if (AjusteID != "")
            {
                var Ds = new SIFNegocio.Inventario.Ajustes().GetAjustes(AjusteID);

                SIFModelo.Inventarios.InventarioDataSet.AjustesCRow row = Ds.AjustesC.Rows[0] as SIFModelo.Inventarios.InventarioDataSet.AjustesCRow;
                tb_DocRefAjuste.Text = row.DOC_REFERENCIA;
                //tb_DescConceptoAjuste.Text = row.desc;
                SucursalDestinoComboBox.Text = row.DESTINO;
                SucursalOrigenComboBox.Text = row.ORIGEN;

                foliotextBoxX.Text = AjusteID.ToString();
                //SucursalOrigenComboBox.Text = SucursalO;
                //SucursalDestinoComboBox.Text = SucursalD;
                //tb_DocRefAjuste.Text = Usr_Envia;
                Grd_Pedido.Columns.Clear();
                Grd_Pedido.AutoGenerateColumns = true;

                ajusteAlmacenL.AjustesDataSet = ajusteAlmacenL.GetAjustes(AjusteID.ToString());
                foreach (SIFModelo.Inventarios.InventarioDataSet.AJUSTES_DETRow x in ajusteAlmacenL.AjustesDataSet.AJUSTES_DET)
                {
                    DataRow
                        _dr = dtAjustes.NewRow();
                    _dr["lote"] = x.LOTE;
                    _dr["id"] = x.ARTICULO_ID;
                    _dr["nombre"] = x.NOMBRE1;
                    _dr["cantidad"] = x.CANTIDAD;
                    _dr["ultimo_costo"] = x.PRECIO_COSTO;
                    _dr["costo"] = x.PRECIO_COSTO;
                    _dr["concepto"] = x.CONCEPTO_DET;
                    /*
                    dtAjustes.Rows.Add(x.LOTE,
                                   x.ARTICULO_ID,
                                   x.NOMBRE1,
                                   x.CANTIDAD,

                                 //x.ULTIMO_COSTO,
                                   x.PRECIO_COSTO,
                                   x.CONCEPTO_DET);*/
                    dtAjustes.Rows.Add(_dr);

                }



                Grd_Pedido.DataSource = dtAjustes;
                object objSum = dtAjustes.Compute("Sum(total)", null);
                var totArticulos = dtAjustes.Compute("Sum(cantidad)", null);
                cantArticulosLabel.Text = "Articulos: " + totArticulos.ToString();

                if (row.TIPO_MOV == "S")
                {
                    switch_TipoAjuste.Value = true;
                }
                else
                {
                    switch_TipoAjuste.Value = false;
                }

                if (dtAjustes.Rows.Count > 0)
                {
                    this.switch_TipoAjuste.IsReadOnly = true;
                }
                else
                {
                    this.switch_TipoAjuste.IsReadOnly = false;
                }
            }
            else
            {
                SucursalOrigenComboBox.Text = Helpers.Sesion.Sucursal.Nombre;
                SucursalDestinoComboBox.Text = Helpers.Sesion.Sucursal.Nombre;
                Grd_Pedido.AutoGenerateColumns = true;
                Grd_Pedido.DataSource = dtAjustes;
            }
            //formato a las columnas
            Grd_Pedido.Columns[0].Width = 100;
            Grd_Pedido.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grd_Pedido.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grd_Pedido.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grd_Pedido.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grd_Pedido.Columns[4].DefaultCellStyle.Format = "##,##0.00";
            Grd_Pedido.Columns[5].DefaultCellStyle.Format = "##,##0.00";
            Grd_Pedido.Columns[7].DefaultCellStyle.Format = "##,##0.00";
            for (int i = 0; i < Grd_Pedido.Columns.Count; i++)
                Grd_Pedido.Columns[i].ReadOnly = true;
            Grd_Pedido.Columns["Cantidad"].ReadOnly = false;

            if (switch_TipoAjuste.Value)
            {
                Grd_Pedido.Columns["costo"].ReadOnly = true;
            }
            else // Cancelación
            {
                Grd_Pedido.Columns["costo"].ReadOnly = false;
            }
        }


        private void SeleccionaArticulo()
        {
            View.Articulos.ArticuloUserControl frmArticulo = new Articulos.ArticuloUserControl();

            if (!MostradoArt)
            {
                MostradoArt = true;
                frmArticulo = new Articulos.ArticuloUserControl();
                MainForm lanza;
                frmArticulo.Dock = DockStyle.Fill;
                this.cantidadTextBoxX.Text = "1";
                //frmArticulo.Muestra();

                frmArticulo.Owner = this;
                Owner.ShowModalPanel(frmArticulo, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.DesactivaComandos();
                frmArticulo.ActivaComandos();
                MostradoArt = false;
            }
        }



        public void Back()
        {
            try
            {
                Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.DesactivaComandos();
                this.Owner.ActivaComandos();
                if (Parent != null)
                {
                    //Parent.Buscar();
                }
                Mostrado = false;
            }
            catch { }
        }

        public void DesactivaComandos()
        {

        }

        // public MainForm Owner { get; set; }

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
            //this.InicializaPedido();
            this.iniciacilizaNotacredito();
            //object objSum = dtAjustes.Compute("Sum(total)", null);

            //if (string.IsNullOrEmpty(objSum.ToString()))
            //{
            //    objSum = 0;
            //}

            //totalLabel.Text = System.Convert.ToDecimal(objSum).ToString("C2");
            //var totArticulos = dtAjustes.Compute("Sum(cantidad)", null);
            //cantArticulosLabel.Text = "Articulos: " + totArticulos.ToString();

        }

        private void CalculaTotal()
        {
            object objSum = dtAjustes.Compute("Sum(total)", null);

            if (string.IsNullOrEmpty(objSum.ToString()))
            {
                objSum = 0;
            }

            totalLabel.Text = System.Convert.ToDecimal(objSum).ToString("C2");
            var totArticulos = dtAjustes.Compute("Sum(cantidad)", null);
            cantArticulosLabel.Text = "Articulos: " + totArticulos.ToString();
        }

        private void cancelarButtonItem_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private bool ValidaPedido(DataRow[] rows)
        {
            foreach (DataRow row in rows)
            {
                SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(row["id"].ToString());
                if (!(precios.PRECIO_VENTA >= System.Convert.ToDecimal(row["costo"])))
                {
                   MessageBox.Show("El precio de venta (" + precios.PRECIO_VENTA.ToString("C2") + ") no puede ser menor al costo (" + System.Convert.ToDecimal(row["costo"]).ToString("C2") + ") del artículo " + row["id"].ToString());
                    return false;
                }

            }

            return true;
        }

        private void GuardarPedido()
        {
            string ProductName = "Ajustes";
            if (tb_DocRefAjuste.Text == "")
            {
               MessageBox.Show("Debe dar una referencia de documento", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Grd_Pedido.RowCount > 0 && foliotextBoxX.Text.Contains("Nuevo"))
            {
                DataRow[] results = dtAjustes.Select(null, "lote, id");
                if (!this.ValidaPedido(results))
                {
                    return;
                }

                if (MessageBoxEx.Show("¿Crear el nuevo ajuste?", ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    // IN Ajuste Array's
                    int[] Lote = new int[results.Length];
                    int[] Sec = new int[results.Length];
                    String[] Articulo = new String[results.Length];
                    String[] Nombre = new string[results.Length];
                    String[] Concepto = new String[results.Length];
                    Double[] Precio = new Double[results.Length];
                    Double[] Costo = new Double[results.Length];
                    Double[] Total = new Double[results.Length];
                    int[] Cant = new int[results.Length];
                    int ind = 0, sec = 0;
                    string CtlLote = string.Empty;
                    string Tipo = string.Empty;
                    string SucRef = "0";
                    //dtAjustes.Columns.Add("lote", typeof(int));
                    //dtAjustes.Columns.Add("id", typeof(string));
                    //dtAjustes.Columns.Add("nombre", typeof(string));
                    //dtAjustes.Columns.Add("cantidad", typeof(int));
                    //dtAjustes.Columns.Add("precio", typeof(double));
                    //dtAjustes.Columns.Add("concepto", typeof(string));
                    //dtAjustes.Columns.Add("total", typeof(double), "cantidad * precio");

                    foreach (DataRow row in results)
                    {
                        if (CtlLote.Contains(row["lote"].ToString()))
                        {
                            sec++;
                            Lote[ind] = Convert.ToInt16(row["lote"].ToString());
                            Sec[ind] = sec;
                            Articulo[ind] = row["id"].ToString();
                            Nombre[ind] = row["nombre"].ToString();
                            Concepto[ind] = row["concepto"].ToString();
                            Precio[ind] = Convert.ToDouble(row["ultimo_costo"]);
                            Costo[ind] = Convert.ToDouble(row["costo"]);
                            Cant[ind] = Convert.ToInt16(row["cantidad"]);
                        }
                        else
                        {
                            sec = 0;
                            sec++;
                            CtlLote = row["lote"].ToString();
                            Lote[ind] = Convert.ToInt16(row["lote"].ToString());
                            Sec[ind] = sec;
                            Articulo[ind] = row["id"].ToString();
                            Nombre[ind] = row["nombre"].ToString();
                            Concepto[ind] = row["concepto"].ToString();
                            Precio[ind] = Convert.ToDouble(row["ultimo_costo"]);
                            Cant[ind] = Convert.ToInt16(row["cantidad"]);
                            Costo[ind] = Convert.ToDouble(row["costo"]);
                            object objSum = dtAjustes.Compute("Sum(total)", "lote = " + CtlLote);
                            var totArticulos = dtAjustes.Compute("Sum(cantidad)", "lote = " + CtlLote);
                            cantArticulosLabel.Text = "Articulos: " + totArticulos.ToString();
                            Total[ind] = Convert.ToDouble(objSum.ToString());
                        }
                        ind++;
                    }

                    if (switch_TipoAjuste.Value)
                    {
                        Tipo = "S";
                        //Grd_Pedido.Columns["costo"].ReadOnly = false;
                    }
                    else // Cancelación
                    {
                        Tipo = "E";
                        //Grd_Pedido.Columns["costo"].ReadOnly = true;
                    }

                    if (SucursalDestinoComboBox.SelectedIndex >= 0)
                        SucRef = SucursalDestinoComboBox.SelectedValue.ToString();


                    ajusteAlmacenL.InsInvAjuste(Convert.ToInt16(SucursalOrigenComboBox.SelectedValue.ToString()), Convert.ToInt16(SucRef),
                          double.Parse(totalLabel.Text.Trim('$')), Tipo, tb_DocRefAjuste.Text, Lote, Sec, Articulo, Nombre, Concepto, Cant, Total, Costo, Precio, Helpers.Sesion.Usuario);
                    this.Back();

                }

            }

            // Existe Ajuste
            if (Grd_Pedido.RowCount > 0 && !foliotextBoxX.Text.Contains("Nuevo"))
            {

                string Tipo = string.Empty;
                string SucRef = "0";

                DataRow[] results = dtAjustes.Select(null, "lote, id");
                // IN Pedido Array's
                int[] Sec = new int[results.Length];
                String[] Articulo = new String[results.Length];
                String[] Nombre = new string[results.Length];
                String[] Concepto = new String[results.Length];
                Double[] Precio = new Double[results.Length];
                Double[] Costo = new Double[results.Length];
                Double[] Total = new Double[results.Length];
                int[] Cant = new int[results.Length];
                Double TotalAjuste = 0;
                int sec = 0;
                string CtlFolio = foliotextBoxX.Text;
                string CtlLote = tb_LotePedido.Text;

                object objSum = dtAjustes.Compute("Sum(total)", "lote = " + CtlLote);

                TotalAjuste = Convert.ToDouble(objSum.ToString());

                var totArticulos = dtAjustes.Compute("Sum(cantidad)", "lote = " + CtlLote);
                cantArticulosLabel.Text = "Articulos: " + totArticulos.ToString();
                if (switch_TipoAjuste.Value)
                {
                    Tipo = "S";
                }
                else // Cancelación
                {
                    Tipo = "E";
                }

                if (SucursalDestinoComboBox.SelectedIndex >= 0)
                    SucRef = SucursalDestinoComboBox.SelectedValue.ToString();

                foreach (DataRow rowdet in results)
                {
                    Sec[sec] = sec + 1;
                    Articulo[sec] = rowdet["id"].ToString();
                    Nombre[sec] = rowdet["nombre"].ToString();
                    Concepto[sec] = rowdet["concepto"].ToString() == "" ? "AJUSTE" : rowdet["concepto"].ToString();
                    Precio[sec] = Convert.ToDouble(rowdet["ultimo_costo"]);
                    Costo[sec] = Convert.ToDouble(rowdet["costo"]);
                    Cant[sec] = Convert.ToInt16(rowdet["cantidad"]);
                    sec++;
                }

                ajusteAlmacenL.UpdInvAjuste(CtlFolio, Convert.ToInt16(CtlLote), Convert.ToInt16(SucursalOrigenComboBox.SelectedValue),
                    Convert.ToInt16(SucRef), Tipo, tb_DocRefAjuste.Text, TotalAjuste,
                    Sec, Articulo, Nombre, Concepto, Cant, Costo, Precio);
                this.Back();
            }

        }

        private void guardarButtonItem_Click(object sender, EventArgs e)
        {


            GuardarPedido();

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
                this.CodigoTextBoxX.SelectAll();
            }

            if (e.KeyCode == Keys.F3)
            {
                this.SeleccionaArticulo();
            }
        }

        private void CodigoTextBoxX_TextChanged(object sender, EventArgs e)
        {

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

            // Agrega Articulo
            descripcionLabel.Text = articulo.NOMBRE1;
            AddArtTraspaso(NoLote, PrecioArt, 0); //NoCaja
            cantidadTextBoxX.Value = 1;
            CodigoTextBoxX.Focus();
            object objSum = dtAjustes.Compute("Sum(total)", null);
            if (string.IsNullOrEmpty(objSum.ToString()))
            {
                objSum = 0;
            }
            totalLabel.Text = System.Convert.ToDecimal(objSum).ToString("C2");
            var totArticulos = dtAjustes.Compute("Sum(cantidad)", null);
            cantArticulosLabel.Text = "Articulos: " + totArticulos.ToString();

            if (dtAjustes.Rows.Count > 0)
            {
                this.switch_TipoAjuste.IsReadOnly = true;
            }
            else
            {
                this.switch_TipoAjuste.IsReadOnly = false;
            }
        }

        private void cantidadTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                AgregaArticulo();


        }

        private void AddArtTraspaso(int Lote, double Precio, double Costo)
        {
            if (tb_DescConceptoAjuste.Text == "")
            {
               MessageBox.Show("Debe dar un concepto de ajuste ", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(CodigoTextBoxX.Text);
            int existencias = 0;

            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
            SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow Invt = inventario.InventarioArticulo(articulo, Helpers.Sesion.Sucursal);
            Lote = int.Parse(tb_LotePedido.Text);
            Precio = (double)Invt.ULT_COSTO;
            Costo = (double)Invt.COSTO_PROM;
            int iCant = int.Parse(cantidadTextBoxX.Text);
            if (switch_TipoAjuste.Value)
            {
                if (!inventario.InventarioArticulo(articulo, iCant, out existencias))
                    return;

            }
            else
            {

            }

            DataRow RegArt = dtAjustes.Rows.Find(CodigoTextBoxX.Text);
            if (RegArt == null)
            {
                dtAjustes.Rows.Add(Lote,
                                   CodigoTextBoxX.Text,
                                   descripcionLabel.Text,
                                   cantidadTextBoxX.Text,
                                   Precio,
                                   Costo,
                                   tb_DescConceptoAjuste.Text);
                // dtAjustes.DefaultView.Sort = "lote, id ASC";
            }
            else
                RegArt["cantidad"] = Convert.ToInt32(cantidadTextBoxX.Text);

        }

        private void Grd_Pedido_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.Delete) || (e.Shift && e.KeyCode == Keys.Delete))
            {
                DataObject d = Grd_Pedido.GetClipboardContent();
                if (d == null) { return; }
                Clipboard.SetDataObject(d);
            }
        }



        private void buttonItem2_Click(object sender, EventArgs e)
        {
            GuardarPedido();
            SIFModelo.Inventarios.InventarioDataSet Pedidos = ajusteAlmacenL.GetAjustes(foliotextBoxX.Text);
            SIF.View.Reportes.Inventarios.ReporteForm Reporte = new Reportes.Inventarios.ReporteForm(Pedidos, 1);
            Reporte.ShowDialog();
        }

        private void cantidadTextBoxX_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tb_DescConceptoAjuste_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AgregaArticulo();
        }

        private void devolucionButtonItem_Click(object sender, EventArgs e)
        {
            this.Devolucion();
        }


        internal void DevolucionCompra(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow row)
        {
            SIFNegocio.OrdenCompra.Compras compraL = new SIFNegocio.OrdenCompra.Compras();

            tb_DocRefAjuste.Text = row.FOLIO_OC_ID;
            tb_DescConceptoAjuste.Text = "DEVOLUCION/REPOSICION";
            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow compra = SIFNegocio.OrdenCompra.Compras.OrdenCompraPorOCId(row);

            if (compra == null)
            {
               MessageBox.Show("No hay una recepción de mercancia relacionada con la Orden de Compra");
                return;
            }

            var ds = SIFNegocio.OrdenCompra.Compras.OrdenCompraDetallesPorCompraId(compra);

            ajusteAlmacenL.AjustesDataSet = new SIFModelo.Inventarios.InventarioDataSet();

            short partida = 1;
            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow detalle in ds.Rows)
            {
                if (detalle.CANT_PROX_CADUCAR > 0 || detalle.CANT_MALESTADO > 0 || detalle.CANT_REPOSICION > 0)
                {
                    SIFModelo.Inventarios.InventarioDataSet.AJUSTES_DETRow ajuste = ajusteAlmacenL.AjustesDataSet.AJUSTES_DET.NewAJUSTES_DETRow();
                    ajuste.ARTICULO_ID = detalle.ARTICULO_ID;
                    ajuste.CANTIDAD = detalle.CANT_PROX_CADUCAR + detalle.CANT_MALESTADO + detalle.CANT_REPOSICION;
                    ajuste.CONCEPTO_DET = tb_DescConceptoAjuste.Text;
                    ajuste.FOLIO = "0";
                    ajuste.LOTE = short.Parse(tb_LotePedido.Text);
                    ajuste.NOMBRE1 = detalle.NOMBRE;
                    ajuste.PARTIDA = partida++;
                    ajuste.PRECIO_COSTO = Convert.ToDecimal(detalle.COSTO);
                    // ajuste.ULTIMO_COSTO = detalle.NUEVO_FLEMING;
                    ajuste.SUCURSAL_ID = row.SUCURSAL_ID;

                    ajusteAlmacenL.AjustesDataSet.AJUSTES_DET.AddAJUSTES_DETRow(ajuste);
                }
            }

            this.Grd_Pedido.DataSource = ajusteAlmacenL.AjustesDataSet.AJUSTES_DET;
        }

        //private void CalculaTotal()
        //{ 
        //    var total = dtAjustes.Compute("SUM(total)","");
        //    if (total.ToString().IsFloat())
        //    {
        //        totalLabel.Text = System.Convert.ToDecimal( total).ToString("C2");
        //    }
        //    else { totalLabel.Text = "$0.00"; }
        //}

        private void Grd_Pedido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dtAjustes.AcceptChanges();
            object objSum = dtAjustes.Compute("Sum(total)", null);
            totalLabel.Text = System.Convert.ToDecimal(objSum).ToString("C2");
            var totArticulos = dtAjustes.Compute("Sum(cantidad)", null);
            cantArticulosLabel.Text = "Articulos: " + totArticulos.ToString();
        }

        private void switch_TipoAjuste_ValueChanged(object sender, EventArgs e)
        {
            if (switch_TipoAjuste.Value)
            {
                dtAjustes.Columns["costo"].ReadOnly = true;
                this.Grd_Pedido.Columns["costo"].ReadOnly = true;
            }
            else // Cancelación
            {
                dtAjustes.Columns["costo"].ReadOnly = false;
                this.Grd_Pedido.Columns["costo"].ReadOnly = false;
            }
        }

        private void Grd_Pedido_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (Grd_Pedido.Rows.Count > 0)
            {
                this.switch_TipoAjuste.IsReadOnly = true;
            }
            else
            {
                this.switch_TipoAjuste.IsReadOnly = false;
            }
            CalculaTotal();
        }

        private void Grd_Pedido_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void tb_DocRefAjuste_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    revisaCompra();
            //}
        }

        private void revisaCompra()
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow cRow = new SIFModelo.OrdenCompra.OrdenCompraDataSet().COMPRAS.NewCOMPRASRow();
            cRow.FOLIO_COMPRA = this.tb_DocRefAjuste.Text;
            cRow = SIFNegocio.OrdenCompra.Compras.CompraPorId(cRow);

            if (cRow != null)
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable dt = SIFNegocio.OrdenCompra.Compras.OrdenCompraDetallesPorCompraId(cRow);

                foreach (var item in dt)
                {

                }

            }
        }



        private void ImportarCsv()
        {
            SIFNegocio.Articulo art = new SIFNegocio.Articulo();
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Seleccione el archivo a Procesar";
            fdlg.Filter = "CSV files (*.CSV)|*.csv";
            fdlg.RestoreDirectory = true;
            bool FmtValid = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                SIFNegocio.Subrogacion.Factura insr = new SIFNegocio.Subrogacion.Factura();
                System.Data.DataTable dtPedido = new System.Data.DataTable();
                dtPedido.Columns.Add("codigo", typeof(string));         //Corresponde al codigo del Articulo
                //dtPedido.Columns.Add("nombre1", typeof(string));       //Corresponde al nmombre del Producto                
                dtPedido.Columns.Add("cantidad", typeof(Int32));        //cantidad pedida de Eoq
                dtPedido.Columns.Add("referencia", typeof(String));        //cantidad pedida de Eoq

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
                    List<String> listaInex = new List<string>();
                    List<String> listaInexTemp = new List<string>();
                    List<String> listaInexReplazo = new List<string>();//contien los codigos de remplazo
                    bool cantidadValida = true;
                    while ((str = reader.ReadLine()) != null)
                    {
                        int x = str.Split(',').Count();
                        if (x != 3)
                        {
                            FmtValid = false;
                            MessageBox.Show("El formato de Archivo " + FName + " es Invalido" + Environment.NewLine + "Sugerencia el numero de colmnas son mayor o menor a las solicitadas ");
                            break;
                        }
                        // Valida cantidad
                        if (objNotNumPattern.IsMatch(str.Split(',')[1]))
                        {
                            cantidadValida = false;
                            MessageBox.Show("La cantidad " + str.Split(',')[1].ToString() + " no es valido");
                            break;
                        }
                        if (Convert.ToUInt32(str.Split(',')[1].ToString()) <= 0)
                        {
                            cantidadValida = false;
                            MessageBox.Show("La cantidad Eoq " + str.Split(',')[1].ToString() + " Debe de ser mayor a Cero");
                            break;
                        }

                        string codigo = str.Split(',')[0];
                        SIFModelo.Articulo Exs = art.BuscarPorClaveActivo(codigo);
                        if (Exs == null)
                        {
                            listaInex.Add(str);
                            //FmtValid = false;
                        }
                        else
                        {
                            dtPedido.Rows.Add(str.Split(',')[0],
                                             //  str.Split(',')[1],
                                             str.Split(',')[1],
                                             str.Split(',')[2]
                                             );
                            Regs++;

                        }

                    }
                    if ((!FmtValid) || !cantidadValida)
                    {
                        return;
                    }

                    Int16 ArticulosInex2 = 0;

                    if (listaInex.Count > 0)
                    {
                        string msg = string.Empty;
                        msg += "No existen los codigos:" + Environment.NewLine;
                        foreach (string s in listaInex)
                        {
                            msg += s.ToString() + Environment.NewLine;
                            if (this.limitaForeach(false, true) > 20)
                            {
                                msg += "..................." + Environment.NewLine;
                                this.limitaForeach(true, false);
                                break;
                            }


                        }

                        MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "Favor de validar el codigo correcto!", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else
                    {
                        FmtValid = true;
                    }

                    // Lee archivo

                    if (FmtValid)
                    {
                        reader.Close();
                        reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));

                        DataRow[] results = dtPedido.Select(null, "codigo");



                        String[] Clave = new String[results.Length];
                        //  String[] Nombre1 = new String[results.Length];
                        Int32[] Cantidad = new Int32[results.Length];

                        int ind = 0;

                        foreach (DataRow rows in dtPedido.Rows)
                        {
                            Clave[ind] = rows["codigo"].ToString().Trim();
                            //Nombre1[ind] = rows["nombre1"].ToString().Trim();
                            Cantidad[ind] = int.Parse(rows["cantidad"].ToString().Trim());



                            this.cantidadTextBoxX.Text = rows["cantidad"].ToString().Trim();
                            tb_DescConceptoAjuste.Text = rows["referencia"].ToString().Trim();
                            AgregaArticulo(rows["codigo"].ToString().Trim());

                            ind++;
                        }
                        foreach (string cv in Clave)
                        {


                        }


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        Int16 conteoForEach = 0;
        private Int16 limitaForeach(bool inicia, bool responde)
        {
            /// por cada consumo en la sintaxis this.limitaForeach(false, true)  realiza un incremento a su valor de retorno
            // la sintaxis del consumo del metodo this.limitaForeach(true, false) su valor de retorno sera cero (0)
            if (inicia)
            {
                conteoForEach = 0;
                return 0;
            }
            if (responde)
            {
                conteoForEach++;
                return conteoForEach;
            }
            return -1;
        }

        private void importarButtonItem_Click(object sender, EventArgs e)
        {
            this.ImportarCsv();
        }
        private void ObtenerAjtHupButtonItem_Click(object sender, EventArgs e)
        {
            if (switch_TipoAjuste.Value)
            {
                MessageBox.Show("Solo se permite obtener ajustes cuando el nuevo ajuste es de entrada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dtAjustes.Rows.Count > 0)
            {
                MessageBox.Show("Para obtener un ajuste no tiene que tener ningun producto agregado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmAjustesJHup frm = new frmAjustesJHup();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.dt.Rows.Count > 0)
                {
                    DataTable _dt = frm.dt;
                    foreach (DataRow r in frm.dt.Rows)
                    {
                        this.cantidadTextBoxX.Text = r["CANTIDAD"].ToString();
                        tb_DescConceptoAjuste.Text = "TRASPASO HOSPITALARIA";
                        AgregaArticuloG(r["ARTICULO_ID"].ToString(), Convert.ToDecimal(r["PRECIO"].ToString()));
                    }

                }

            }
        }



        public void AgregaArticuloG(string claveArticulo, decimal _p)
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
                // System.Windows.Forms.SendKeys.Send("{TAB}");
            }

            this.AgregaArticuloG(articulo, _p);
        }

        public void AgregaArticuloG(SIFModelo.Articulo _articulo, decimal _pr)
        {
            int cantidad = 1;

            if (this.cantidadTextBoxX.Text.IsIntegerPositive())
                cantidad = int.Parse(this.cantidadTextBoxX.Text);

            CodigoTextBoxX.Text = _articulo.ARTICULO_ID;
            cantidadTextBoxX.Focus();


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

            // Agrega Articulo
            descripcionLabel.Text = articulo.NOMBRE1;
            AddArtTraspasoG(NoLote, PrecioArt, (double)_pr); //NoCaja
            cantidadTextBoxX.Value = 1;
            CodigoTextBoxX.Focus();
            object objSum = dtAjustes.Compute("Sum(total)", null);
            if (string.IsNullOrEmpty(objSum.ToString()))
            {
                objSum = 0;
            }
            totalLabel.Text = System.Convert.ToDecimal(objSum).ToString("C2");
            var totArticulos = dtAjustes.Compute("Sum(cantidad)", null);
            cantArticulosLabel.Text = "Articulos: " + totArticulos.ToString();

            if (dtAjustes.Rows.Count > 0)
            {
                this.switch_TipoAjuste.IsReadOnly = true;
            }
            else
            {
                this.switch_TipoAjuste.IsReadOnly = false;
            }


        }




        private void AddArtTraspasoG(int Lote, double Precio, double Costo)
        {
            if (tb_DescConceptoAjuste.Text == "")
            {
               MessageBox.Show("Debe dar un concepto de ajuste ", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(CodigoTextBoxX.Text);
            int existencias = 0;

            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
            SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow Invt = inventario.InventarioArticulo(articulo, Helpers.Sesion.Sucursal);
            Lote = int.Parse(tb_LotePedido.Text);
            /*Precio = (double)Invt.ULT_COSTO;
            Costo = (double)Invt.COSTO_PROM;
            Costo-*/
            Precio = (double)Invt.ULT_COSTO;
            //Costo = (double)Costo;
            int iCant = int.Parse(cantidadTextBoxX.Text);
            if (switch_TipoAjuste.Value)
            {
                if (!inventario.InventarioArticulo(articulo, iCant, out existencias))
                    return;

            }
            else
            {

            }

            DataRow RegArt = dtAjustes.Rows.Find(CodigoTextBoxX.Text);
            if (RegArt == null)
            {
                dtAjustes.Rows.Add(Lote,
                                   CodigoTextBoxX.Text,
                                   descripcionLabel.Text,
                                   cantidadTextBoxX.Text,
                                   Precio,
                                   Costo,
                                   tb_DescConceptoAjuste.Text);
                // dtAjustes.DefaultView.Sort = "lote, id ASC";
            }
            else
                RegArt["cantidad"] = Convert.ToInt32(cantidadTextBoxX.Text);

        }
        private void FechaIniciodateTimeInput_ValueChanged(object sender, EventArgs e)
        {
            //code
        }
        private void FechaFindateTimeInput_ValueChanged(object sender, EventArgs e)
        {
            //code
        }
        private void ProveedorComboBoxEx_SelectedValueChanged(object sender, EventArgs e)
        {
            //segment code
        }

        private void SaldoTextBoxX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }
        private void cargaProveedores()
        {
            SIFNegocio.Clientes clientesL = new SIFNegocio.Clientes();
            if (SIFNegocio.Clientes.ProveedoresList.Count == 0)
            {
                SIFNegocio.Clientes.ProveedoresList = clientesL.BuscarProveedores("", "").DataSource as List<SIFModelo.Cliente>;
            }

            List<SIFModelo.Cliente> proveedores = SIFNegocio.Clientes.ProveedoresList;

            foreach (SIFModelo.Cliente cliente in proveedores)
            {
                cliente.Nombre = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno + " - " + cliente.ID;
            }

            this.ProveedorComboBoxEx.DataSource = proveedores;
            ProveedorComboBoxEx.DisplayMember = "Nombre";
            ProveedorComboBoxEx.ValueMember = "ID";
        }


    }
}
