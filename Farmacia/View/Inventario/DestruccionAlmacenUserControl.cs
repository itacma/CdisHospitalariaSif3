using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Inventario
{
    public partial class DestruccionAlmacenUserControl : Templates.CatalogoUserControl
    {
        public SIFModelo.Sucursal sucursales = new SIFModelo.Sucursal();
        public string DestruccionID;
        public int lote;
        public String SucursalO;
        public String SucursalD;
        public Boolean MostradoArt = false;
        DataTable dtDestrucciones = new DataTable();
        DataTable dtPedido = new DataTable();
        double PrecioArt = 0;
        string TipoArt = string.Empty;
        int NoLote = 0;
        public string Usr_Envia;
        public DestruccionesAlmacenUserControl Parent = null;

        public DestruccionAlmacenUserControl()
        {
            InitializeComponent();
            this.CargaSucursalOrigen();
            this.CargaSucursalDestino();
            this.Grd_Pedido.AutoGenerateColumns = false;
        }

        public bool Mostrado { get; set; }


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
            /* BindingList<SIFModelo.Sucursal> sucursales2 = new BindingList<SIFModelo.Sucursal>();
             //SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { Nombre = "[TODAS]", SucursalesID = 0 };
             //sucursales.Add(sucursal);
             //sucursales.ToList();d
             List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().Buscar("", "").DataSource as List<SIFModelo.Sucursal>;

             foreach (SIFModelo.Sucursal sucursalBd in sucursalesBD)
             {
                 sucursales2.Add(sucursalBd);
             }

             SucursalOrigenComboBox.DataSource = sucursales2;
             SucursalOrigenComboBox.DisplayMember = "NOMBRE";
             SucursalOrigenComboBox.ValueMember = "SUCURSALESID";
             */
            
            sucursales = Helpers.Sesion.Sucursal;
        }

        private void CargaSucursalDestino()
        {
            /* BindingList<SIFModelo.Sucursal> sucursales2 = new BindingList<SIFModelo.Sucursal>();
             //SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { Nombre = "[TODAS]", SucursalesID = 0 };
             //sucursales.Add(sucursal);
             //sucursales.ToList();d
             List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().Buscar("", "").DataSource as List<SIFModelo.Sucursal>;

             foreach (SIFModelo.Sucursal sucursalBd in sucursalesBD)
             {
                 sucursales2.Add(sucursalBd);
             }

             SucursalDestinoComboBox.DataSource = sucursales2;
             SucursalDestinoComboBox.DisplayMember = "NOMBRE";
             SucursalDestinoComboBox.ValueMember = "SUCURSALESID";
             */
            //SIFModelo.Sucursal sucursales = new SIFModelo.Sucursal();
            sucursales = Helpers.Sesion.Sucursal;
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

        SIFNegocio.Inventario.Destrucciones DestruccionAlmacenL = new SIFNegocio.Inventario.Destrucciones();
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

        private void InicializaPedido()
        {
            dtDestrucciones.Columns.Add("lote", typeof(int));
            dtDestrucciones.Columns.Add("id", typeof(string));
            dtDestrucciones.Columns.Add("nombre", typeof(string));
            dtDestrucciones.Columns.Add("cantidad", typeof(int));
            dtDestrucciones.Columns.Add("ultimo_costo", typeof(double));
            dtDestrucciones.Columns.Add("costo", typeof(double));
            dtDestrucciones.Columns.Add("concepto", typeof(string));
            dtDestrucciones.Columns.Add("total", typeof(double), "cantidad * costo");
            dtDestrucciones.PrimaryKey = new DataColumn[] { dtDestrucciones.Columns["id"] };
            if (DestruccionID != "")
            {
                //var Ds = new SIFNegocio.Inventario.Ajustes().GetAjustes(DestruccionID);
                var Ds = new SIFNegocio.Inventario.Destrucciones().GetDestrucciones(DestruccionID);
                //SIFModelo.Inventarios.InventarioDataSet.AjustesCRow row = Ds.AjustesC.Rows[0] as SIFModelo.Inventarios.InventarioDataSet.AjustesCRow;
                SIFModelo.Inventarios.InventarioDataSet.DESTRUCCIONESCRow row = Ds.DESTRUCCIONESC.Rows[0] as SIFModelo.Inventarios.InventarioDataSet.DESTRUCCIONESCRow;
                tb_DocRefAjuste.Text = row.DOC_REFERENCIA;
                //tb_DescConceptoAjuste.Text = row.desc;
                SucursalDestinoComboBox.Text = row.DESTINO;
                SucursalOrigenComboBox.Text = row.ORIGEN;

                foliotextBoxX.Text = DestruccionID.ToString();
                //SucursalOrigenComboBox.Text = SucursalO;
                //SucursalDestinoComboBox.Text = SucursalD;
                //tb_DocRefAjuste.Text = Usr_Envia;
                Grd_Pedido.Columns.Clear();
                Grd_Pedido.AutoGenerateColumns = true;

                DestruccionAlmacenL.DestruccionesDataSet = DestruccionAlmacenL.GetDestrucciones(DestruccionID.ToString());
                foreach (SIFModelo.Inventarios.InventarioDataSet.DESTRUCCIONES_DETRow x in DestruccionAlmacenL.DestruccionesDataSet.DESTRUCCIONES_DET)
                {
                    dtDestrucciones.Rows.Add(x.LOTE,
                                   x.ARTICULO_ID,
                                   x.NOMBRE1,
                                   x.CANTIDAD,
                                   x.ULTIMO_COSTO,
                                   x.PRECIO_COSTO,
                                   x.CONCEPTO_DET);

                }


                Grd_Pedido.DataSource = dtDestrucciones;
                object objSum = dtDestrucciones.Compute("Sum(total)", null);
                var totArticulos = dtDestrucciones.Compute("Sum(cantidad)", null);
                cantArticulosLabel.Text = "Articulos: " + totArticulos.ToString();

                if (row.TIPO_MOV == "S")
                {
                    switch_TipoAjuste.Value = true;
                }
                else
                {
                    switch_TipoAjuste.Value = false;
                }

                if (dtDestrucciones.Rows.Count > 0)
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
                Grd_Pedido.DataSource = dtDestrucciones;
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
                    Parent.Buscar();
                }
                Mostrado = false;
            }
            catch { }
        }

        public void DesactivaComandos()
        {

        }

        public MainForm Owner { get; set; }

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

            object objSum = dtDestrucciones.Compute("Sum(total)", null);

            if (string.IsNullOrEmpty(objSum.ToString()))
            {
                objSum = 0;
            }

            totalLabel.Text = System.Convert.ToDecimal(objSum).ToString("C2");
            var totArticulos = dtDestrucciones.Compute("Sum(cantidad)", null);
            cantArticulosLabel.Text = "Articulos: " + totArticulos.ToString();

        }

        private void CalculaTotal()
        {
            object objSum = dtDestrucciones.Compute("Sum(total)", null);

            if (string.IsNullOrEmpty(objSum.ToString()))
            {
                objSum = 0;
            }

            totalLabel.Text = System.Convert.ToDecimal(objSum).ToString("C2");
            var totArticulos = dtDestrucciones.Compute("Sum(cantidad)", null);
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
            string ProductName = "Destrucciones";
            if (tb_DocRefAjuste.Text == "")
            {
               MessageBox.Show("Debe dar una documento de referencia", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Grd_Pedido.RowCount > 0 && foliotextBoxX.Text.Contains("Nuevo"))
            {
                DataRow[] results = dtDestrucciones.Select(null, "lote, id");
                if (!this.ValidaPedido(results))
                {
                    return;
                }

                if (MessageBoxEx.Show("¿Crear la nueva destruccion?", ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
                            object objSum = dtDestrucciones.Compute("Sum(total)", "lote = " + CtlLote);
                            var totArticulos = dtDestrucciones.Compute("Sum(cantidad)", "lote = " + CtlLote);
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


                    DestruccionAlmacenL.InsInvAjuste(Convert.ToInt16(sucursales.SucursalesID.ToString()), Convert.ToInt16(SucRef),
                          double.Parse(totalLabel.Text.Trim('$')), Tipo, tb_DocRefAjuste.Text, Lote, Sec, Articulo, Nombre, Concepto, Cant, Total, Costo, Precio, Helpers.Sesion.Usuario);
                    
                    this.Back();

                }

            }

            // Existe Ajuste
            if (Grd_Pedido.RowCount > 0 && !foliotextBoxX.Text.Contains("Nuevo"))
            {

                string Tipo = string.Empty;
                string SucRef = "0";

                DataRow[] results = dtDestrucciones.Select(null, "lote, id");
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

                object objSum = dtDestrucciones.Compute("Sum(total)", "lote = " + CtlLote);

                TotalAjuste = Convert.ToDouble(objSum.ToString());

                var totArticulos = dtDestrucciones.Compute("Sum(cantidad)", "lote = " + CtlLote);
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
                    Concepto[sec] = rowdet["concepto"].ToString();
                    Precio[sec] = Convert.ToDouble(rowdet["ultimo_costo"]);
                    Costo[sec] = Convert.ToDouble(rowdet["costo"]);
                    Cant[sec] = Convert.ToInt16(rowdet["cantidad"]);
                    sec++;
                }

                DestruccionAlmacenL.UpdInvAjuste(CtlFolio, Convert.ToInt16(CtlLote), Convert.ToInt16(SucursalOrigenComboBox.SelectedValue),
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
          /*  if (SucursalOrigenComboBox.SelectedIndex < 0 ||
                     SucursalDestinoComboBox.SelectedIndex < 0)
            {
               MessageBox.Show("Debe Seleccionar un Origen y Destino", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                SucursalOrigenComboBox.Focus();
                return;
            }*/
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
            object objSum = dtDestrucciones.Compute("Sum(total)", null);
            if (string.IsNullOrEmpty(objSum.ToString()))
            {
                objSum = 0;
            }
            totalLabel.Text = System.Convert.ToDecimal(objSum).ToString("C2");
            var totArticulos = dtDestrucciones.Compute("Sum(cantidad)", null);
            cantArticulosLabel.Text = "Articulos: " + totArticulos.ToString();

            if (dtDestrucciones.Rows.Count > 0)
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
               MessageBox.Show("Debe dar un concepto de destruccion ", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(CodigoTextBoxX.Text);
            int existencias = 0;

            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
            SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow Invt = inventario.InventarioArticulo(articulo, Helpers.Sesion.Sucursal);
            Lote = int.Parse(tb_LotePedido.Text);
            Precio = Invt.ULT_COSTO;
            Costo = Invt.COSTO_PROM;
            int iCant = int.Parse(cantidadTextBoxX.Text);
            if (switch_TipoAjuste.Value)
            {
                if (!inventario.InventarioArticulo(articulo, iCant, out existencias))
                    return;

            }
            else
            {

            }

            DataRow RegArt = dtDestrucciones.Rows.Find(CodigoTextBoxX.Text);
            if (RegArt == null)
            {
                dtDestrucciones.Rows.Add(Lote,
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
            SIFModelo.Inventarios.InventarioDataSet Pedidos = DestruccionAlmacenL.GetDestrucciones(foliotextBoxX.Text);
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

        /*
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

            DestruccionAlmacenL.DestruccionesDataSet = new SIFModelo.Inventarios.InventarioDataSet();

            short partida = 1;
            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow detalle in ds.Rows)
            {
                if (detalle.CANT_DEVUELTA > 0 || detalle.CANT_MALESTADO > 0 || detalle.CANT_REPOSICION > 0)
                {
                    //SIFModelo.Inventarios.InventarioDataSet.AJUSTES_DETRow ajuste2 = ajusteAlmacenL.AjustesDataSet.AJUSTES_DET.NewAJUSTES_DETRow();
                    SIFModelo.Inventarios.InventarioDataSet.DESTRUCCIONES_DETRow destruccion = DestruccionAlmacenL.DestruccionesDataSet.DESTRUCCIONES_DET.NewDESTRUCCIONES_DETRow();
                    destruccion.ARTICULO_ID = detalle.ARTICULO_ID;
                    destruccion.CANTIDAD = detalle.CANT_DEVUELTA + detalle.CANT_MALESTADO + detalle.CANT_REPOSICION;
                    destruccion.CONCEPTO_DET = tb_DescConceptoAjuste.Text;
                    destruccion.FOLIO = "0";
                    destruccion.LOTE = short.Parse(tb_LotePedido.Text);
                    destruccion.NOMBRE1 = detalle.NOMBRE;
                    destruccion.PARTIDA = partida++;
                    destruccion.PRECIO_COSTO = (double)detalle.COSTO;
                    destruccion.ULTIMO_COSTO = (double)detalle.NUEVO_FLEMING;
                    destruccion.SUCURSAL_ID = row.SUCURSAL_ID;

                    DestruccionAlmacenL.DestruccionesDataSet.DESTRUCCIONES_DET.AddDESTRUCCIONES_DETRow(destruccion);
                }
            }

            this.Grd_Pedido.DataSource = DestruccionAlmacenL.DestruccionesDataSet.DESTRUCCIONES_DET;
        }*/

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
            dtDestrucciones.AcceptChanges();
            object objSum = dtDestrucciones.Compute("Sum(total)", null);
            totalLabel.Text = System.Convert.ToDecimal(objSum).ToString("C2");
            var totArticulos = dtDestrucciones.Compute("Sum(cantidad)", null);
            cantArticulosLabel.Text = "Articulos: " + totArticulos.ToString();
        }

        private void switch_TipoAjuste_ValueChanged(object sender, EventArgs e)
        {
           /* if (switch_TipoAjuste.Value)
            {
                dtDestrucciones.Columns["costo"].ReadOnly = true;
                this.Grd_Pedido.Columns["costo"].ReadOnly = true;
            }
            else // Cancelación
            {
                dtDestrucciones.Columns["costo"].ReadOnly = false;
                this.Grd_Pedido.Columns["costo"].ReadOnly = false;
            }*/
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
    }
}
