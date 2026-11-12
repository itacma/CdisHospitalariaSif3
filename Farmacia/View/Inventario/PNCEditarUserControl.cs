using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.IO;
using System.Text.RegularExpressions;

namespace SIF.View.Inventario
{
    public partial class PNCEditarUserControl : SIF.Templates.CatalogoUserControl
    {
        public string AjusteID;
        public int lote;
        public String SucursalO;
        public String SucursalD;
        public Boolean MostradoArt = false;
        DataTable dtAjustes = new DataTable();
        DataTable dtPedido = new DataTable();
        double PrecioArt = 0;
        string TipoArt = string.Empty;
        int NoLote = 0;
        public string Usr_Envia;
        public ProductoNoConformeUserControl Parent = null;

        public PNCEditarUserControl()
        {
            InitializeComponent();
            inicializaColoresFilas();
        }

        DataGridViewCellStyle revisarRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle GuardadosRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle faltanteRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle normalRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle WarningCellStyle = new DataGridViewCellStyle();

        private void inicializaColoresFilas()
        {
            revisarRowStyle = new DataGridViewCellStyle(this.Grd_Pedido.DefaultCellStyle);
            revisarRowStyle.BackColor = Color.FromArgb(237, 224, 249);//237,224,249
            //revisarRowStyle.BackColor.Color2 = Color.FromArgb(255, 35, 35);

            WarningCellStyle = new DataGridViewCellStyle(this.Grd_Pedido.DefaultCellStyle);
            WarningCellStyle.BackColor = Color.FromArgb(253, 215, 0);
            //WarningCellStyle.BackColor.Color2 = Color.FromArgb(253, 215, 0);

            GuardadosRowStyle = new DataGridViewCellStyle(this.Grd_Pedido.DefaultCellStyle);
            GuardadosRowStyle.BackColor = Color.FromArgb(115, 240, 109);
            //margenRowStyle.BackColor.Color2 = Color.FromArgb(200, 100, 100);

            faltanteRowStyle = new DataGridViewCellStyle(this.Grd_Pedido.DefaultCellStyle);
            faltanteRowStyle.BackColor = Color.FromArgb(255, 87, 51);
            //faltanteRowStyle.Background.Color2 = Color.FromArgb(0, 176, 80);

            normalRowStyle = new DataGridViewCellStyle(this.Grd_Pedido.DefaultCellStyle);
            normalRowStyle = this.Grd_Pedido.DefaultCellStyle;
        }

        public bool Mostrado { get; set; }

        public MainForm Owner { get; set; }

        SIFNegocio.Inventario.PNCNegocio ajusteAlmacenL = new SIFNegocio.Inventario.PNCNegocio();

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void agregaProductoButtonItem_Click(object sender, EventArgs e)
        {
            this.SeleccionaArticulo();
        }

        private void CodigoTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.SeleccionaArticulo();
        }

        private void CodigoTextBoxX_TextChanged(object sender, EventArgs e)
        {

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

        private void cantidadTextBoxX_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cantidadTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AgregaArticulo();
        }

        private void tb_DescConceptoAjuste_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AgregaArticulo();
        }

        private void tb_DocRefAjuste_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void NuevoUserControl_Load(object sender, EventArgs e)
        {
            this.InicializaNuevo();

            var totArticulos = dtAjustes.Compute("Sum(cantidad)", null);
            cantArticulosLabel.Text = "Artículos: " + totArticulos.ToString();

        }

        internal void Muestra()
        {
            if (Mostrado)
            {
                return;
            }

            this.Dock = DockStyle.Fill;
            //this.ActivaComandos();
            Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            Mostrado = true;
        }

        public void Back()
        {
            try
            {
                Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                //this.DesactivaComandos();
                this.Owner.ActivaComandos();
                if (Parent != null)
                {
                    Parent.Buscar();
                }
                Mostrado = false;
            }
            catch { }
        }

        private void guardarButtonItem_Click(object sender, EventArgs e)
        {
            GuardarPedido();
        }

        private void SeleccionaArticulo()
        {
            View.Articulos.ProductosUserControl frmArticulo = new Articulos.ProductosUserControl();

            if (!MostradoArt)
            {
                MostradoArt = true;
                frmArticulo = new Articulos.ProductosUserControl();
                MainForm lanza;
                frmArticulo.Dock = DockStyle.Fill;
                this.cantidadTextBoxX.Text = "1";
                //frmArticulo.Muestra();

                frmArticulo.Owner = this;
                Owner.ShowModalPanel(frmArticulo, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                //this.DesactivaComandos();
                frmArticulo.ActivaComandos();
                MostradoArt = false;
            }
        }

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

        private void AgregaArticulo()
        {
            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(CodigoTextBoxX.Text);

            if (tb_DescConceptoAjuste.Text == "")
            {
               MessageBox.Show("Debe dar un nombre al concepto", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            

            if (string.IsNullOrEmpty(CodigoTextBoxX.Text) ||
                                   articulo == null)
            {
               MessageBox.Show("Debe seleccionar un artículo", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                CodigoTextBoxX.Focus();
                return;
            }

            // Agrega Articulo
            //descripcionLabel.Text = articulo.NOMBRE1;
            AddArtTraspaso(NoLote, PrecioArt, 0); //NoCaja
            cantidadTextBoxX.Value = 1;
            CodigoTextBoxX.Focus();

            var totArticulos = dtAjustes.Compute("Sum(cantidad)", null);
            cantArticulosLabel.Text = "Artículos: " + totArticulos.ToString();
            /*
            if (dtAjustes.Rows.Count > 0)
            {
                this.switch_TipoAjuste.IsReadOnly = true;
            }
            else
            {
                this.switch_TipoAjuste.IsReadOnly = false;
            }
            */
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
               MessageBox.Show("El artículo no existe en el catálogo");

                return;
            }
            else
            {
                //descripcionLabel.Text = articulo.NOMBRE1;
                TipoArt = articulo.TIPO_MEDICAMENTO_CVE;
                if (TipoArt.Contains("F1"))
                    NoLote = 2;
                else
                    NoLote = 1;
                // System.Windows.Forms.SendKeys.Send("{TAB}");
            }

            this.AgregaArticulo(articulo);
        }

        private void AddArtTraspaso(int Lote, double Precio, double Costo)
        {
            if (tb_DescConceptoAjuste.Text == "")
            {
               MessageBox.Show("Debe dar un nombre al concepto", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(CodigoTextBoxX.Text);
            int existencias = 0;

            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
            SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow Invt = inventario.InventarioArticulo(articulo, Helpers.Sesion.Sucursal);

            if (Invt == null)
            {
                Invt = new SIFModelo.Inventarios.InventarioDataSet().INVENTARIO.NewINVENTARIORow();
                Invt.ULT_COSTO = 0;
                Invt.COSTO_PROM = 0;
            }

            Lote = int.Parse(tb_LotePedido.Text);
            Precio = (double)Invt.ULT_COSTO;
            Costo = (double)Invt.COSTO_PROM;
            int iCant = int.Parse(cantidadTextBoxX.Text);

            if (iCant <= 0)
            {
               MessageBox.Show("La cantidad ingresada debe ser mayor a cero", "Producto No Conforme");
                return;
            }

            DataRow RegArt = dtAjustes.Rows.Find(CodigoTextBoxX.Text);
            if (RegArt == null)
            {
                if (iCant <= (Invt.EXISTENCIAS - Invt.APARTADO_VTAS))
                {
                    dtAjustes.Rows.Add(Lote, CodigoTextBoxX.Text, articulo.NOMBRE1, cantidadTextBoxX.Text, Costo);//, tb_DescConceptoAjuste.Text);
                }
                else
                {
                    MessageBox.Show("La cantidad ingresada debe ser igual o menor a la cantidad disponible", "Producto No Conforme");
                }
            }
            else
            {
                if (iCant <= (Invt.EXISTENCIAS - Invt.APARTADO_VTAS))
                {
                    if (Convert.ToInt32(cantidadTextBoxX.Text) > 1)
                    {
                        RegArt["cantidad"] = Convert.ToInt32(cantidadTextBoxX.Text);
                    }
                    else
                        RegArt["cantidad"] = Convert.ToInt32(cantidadTextBoxX.Text) + Convert.ToInt32(RegArt["cantidad"].ToString());
                }
                else
                {
                   MessageBox.Show("La cantidad ingresada debe ser igual o menor a la cantidad disponible", "Producto No Conforme");
                }
            }

        }

        private void Grd_Pedido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dtAjustes.AcceptChanges();
            var totArticulos = dtAjustes.Compute("Sum(cantidad)", null);
            cantArticulosLabel.Text = "Artículos: " + totArticulos.ToString();
        }

        private void Grd_Pedido_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void Grd_Pedido_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (Grd_Pedido.Rows.Count > 0)
            {
            }
            else
            {
            }
            CalculaTotal();
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

        private void CalculaTotal()
        {
            var totArticulos = dtAjustes.Compute("Sum(cantidad)", null);
            cantArticulosLabel.Text = "Artículos: " + totArticulos.ToString();
        }

        private void InicializaNuevo()
        {
            //dtAjustes.Columns.Add("FOLIO", typeof(string));
            dtAjustes.Columns.Add("LOTE", typeof(int));
            //dtAjustes.Columns.Add("SUCURSAL_ID", typeof(int));
            //dtAjustes.Columns.Add("PARTIDA", typeof(int));
            dtAjustes.Columns.Add("ARTICULO_ID", typeof(string));
            dtAjustes.Columns.Add("NOMBRE1", typeof(string));
            dtAjustes.Columns.Add("CANTIDAD", typeof(int));
            dtAjustes.Columns.Add("PRECIO_COSTO", typeof(double));
            //dtAjustes.Columns.Add("CONCEPTO_DET", typeof(string));
            dtAjustes.PrimaryKey = new DataColumn[] { dtAjustes.Columns["ARTICULO_ID"] };

            if (AjusteID != "")
            {
                var Ds = new SIFNegocio.Inventario.PNCNegocio().GetPncs(AjusteID);

                SIFModelo.Inventarios.InventarioDataSet.PNCRow row = Ds.PNC.Rows[0] as SIFModelo.Inventarios.InventarioDataSet.PNCRow;
                tb_DescConceptoAjuste.Text = row.DOC_REFERENCIA;
                foliotextBoxX.Text = AjusteID.ToString();
                Grd_Pedido.Columns.Clear();
                Grd_Pedido.AutoGenerateColumns = true;

                ajusteAlmacenL.DsPnc = ajusteAlmacenL.GetPncs(AjusteID.ToString());
                foreach (SIFModelo.Inventarios.InventarioDataSet.PNC_DETRow x in ajusteAlmacenL.DsPnc.PNC_DET)
                {
                    DataRow
                    _dr = dtAjustes.NewRow();
                    //_dr["FOLIO"] = x.FOLIO;
                    _dr["LOTE"] = x.LOTE;
                    //_dr["SUCURSAL_ID"] = x.SUCURSAL_ID;
                    //_dr["PARTIDA"] = x.PARTIDA;
                    _dr["ARTICULO_ID"] = x.ARTICULO_ID;
                    _dr["NOMBRE1"] = x.NOMBRE1;
                    _dr["CANTIDAD"] = x.CANTIDAD;
                    _dr["PRECIO_COSTO"] = x.PRECIO_COSTO;
                    //_dr["CONCEPTO_DET"] = x.CONCEPTO_DET;
                    dtAjustes.Rows.Add(_dr);
                }

                Grd_Pedido.DataSource = dtAjustes;
                var totArticulos = dtAjustes.Compute("Sum(cantidad)", null);
                cantArticulosLabel.Text = "Artículos: " + totArticulos.ToString();

            }
            else
            {
                Grd_Pedido.AutoGenerateColumns = true;
                Grd_Pedido.DataSource = dtAjustes;
            }

            //formato a las columnas
            Grd_Pedido.Columns[0].Width = 100;
            Grd_Pedido.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grd_Pedido.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grd_Pedido.Columns[3].DefaultCellStyle.Format = "##,##0.00";
            Grd_Pedido.Columns[4].DefaultCellStyle.Format = "##,##0.00";
            //Grd_Pedido.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //Grd_Pedido.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //Grd_Pedido.Columns[5].DefaultCellStyle.Format = "##,##0.00";


            for (int i = 0; i < Grd_Pedido.Columns.Count; i++)
                Grd_Pedido.Columns[i].ReadOnly = true;

            //Grd_Pedido.Columns["Cantidad"].ReadOnly = false;
        }

        private void GuardarPedido()
        {
            string ProductName = "Producto No Conforme";
            if (tb_DescConceptoAjuste.Text == "")
            {
               MessageBox.Show("Debe dar una concepto de documento", ProductName);
                return;
            }

            if (Grd_Pedido.RowCount > 0 && foliotextBoxX.Text.Contains("Nuevo"))
            {
                DataRow[] results = dtAjustes.Select(null, "lote, articulo_id");
                if (!this.ValidaPedido(results))
                {
                    return;
                }

                if (MessageBoxEx.Show("¿Crear el nuevo ajuste?", ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    // IN Ajuste Array's
                    int[] Lote = new int[results.Length];
                    int[] Partida = new int[results.Length];
                    String[] Articulo_id = new String[results.Length];
                    String[] Nombre = new string[results.Length];
                    int[] Cantidad = new int[results.Length];
                    Double[] Costo = new Double[results.Length];
                    String[] Concepto = new String[results.Length];
                    int ind = 0, partida = 0, Total;
                    string CtlLote = string.Empty;

                    foreach (DataRow row in results)
                    {
                        if (CtlLote.Contains(row["LOTE"].ToString()))
                        {
                            partida++;
                            Lote[ind] = Convert.ToInt16(row["LOTE"].ToString());
                            Partida[ind] = partida;
                            Articulo_id[ind] = row["ARTICULO_ID"].ToString();
                            Nombre[ind] = row["NOMBRE1"].ToString();
                            Concepto[ind] = tb_DescConceptoAjuste.Text;// row["CONCEPTO_DET"].ToString();
                            Costo[ind] = Convert.ToDouble(row["PRECIO_COSTO"]);
                            Cantidad[ind] = Convert.ToInt16(row["CANTIDAD"]);
                        }
                        else
                        {
                            partida = 0;
                            partida++;
                            CtlLote = row["LOTE"].ToString();
                            Lote[ind] = Convert.ToInt16(row["LOTE"].ToString());
                            Partida[ind] = partida;
                            Articulo_id[ind] = row["ARTICULO_ID"].ToString();
                            Nombre[ind] = row["NOMBRE1"].ToString();
                            Concepto[ind] = tb_DescConceptoAjuste.Text; //row["CONCEPTO_DET"].ToString();
                            Cantidad[ind] = Convert.ToInt16(row["CANTIDAD"]);
                            Costo[ind] = Convert.ToDouble(row["PRECIO_COSTO"]);
                            var total = dtAjustes.Compute("Sum(cantidad)", null);
                            cantArticulosLabel.Text = "Articulos: " + total.ToString();
                        }
                        ind++;
                    }

                    var totalArt = dtAjustes.Compute("Sum(cantidad)", null);
                    Total = Convert.ToInt16(totalArt.ToString());

                    ajusteAlmacenL.InsInvAjuste(Lote, Partida, Articulo_id, Nombre, Concepto, Cantidad, Costo, Helpers.Sesion.Usuario, Total);
                    this.Back();
                }

            }

            // Existe Ajuste
            if (Grd_Pedido.RowCount > 0 && !foliotextBoxX.Text.Contains("Nuevo"))
            {
                DataRow[] results1 = dtAjustes.Select(null, "lote, articulo_id");
                if (!this.ValidaPedido(results1))
                {
                    return;
                }

                string Folio = foliotextBoxX.Text;
                if (MessageBoxEx.Show("¿ Desea editar el folio " + Folio + " ?", ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DataRow[] results = dtAjustes.Select(null, "lote, articulo_id");
                    // IN Ajuste Array's
                    int[] Partida = new int[results.Length];
                    String[] Articulo_id = new String[results.Length];
                    String[] Nombre = new string[results.Length];
                    int[] Cantidad = new int[results.Length];
                    Double[] Costo = new Double[results.Length];
                    int ind = 0, partida = 0, Total;
                    int Lote = Convert.ToInt16(tb_LotePedido.Text);
                    //string Folio = foliotextBoxX.Text;
                    string Concepto = tb_DescConceptoAjuste.Text;

                    foreach (DataRow row in results)
                    {
                        partida++;
                        Partida[ind] = partida;
                        Articulo_id[ind] = row["ARTICULO_ID"].ToString();
                        Nombre[ind] = row["NOMBRE1"].ToString();
                        Cantidad[ind] = Convert.ToInt16(row["CANTIDAD"]);
                        Costo[ind] = Convert.ToDouble(row["PRECIO_COSTO"]);
                        //object objSum = dtAjustes.Compute("Sum(total)", "lote = " + CtlLote);
                        var totArticulos = dtAjustes.Compute("Sum(cantidad)", null);
                        cantArticulosLabel.Text = "Articulos: " + totArticulos.ToString();
                        ind++;
                    }

                    var totalArt = dtAjustes.Compute("Sum(cantidad)", null);
                    Total = Convert.ToInt16(totalArt.ToString());

                    ajusteAlmacenL.UpdInvAjuste(Folio, Lote, Partida, Articulo_id, Nombre, Concepto, Cantidad, Costo, Helpers.Sesion.Usuario, Total);
                    this.Back();
                }
            }

        }

        private bool ValidaPedido(DataRow[] rows)
        {
            int bandera = 0;

            foreach (DataRow row in rows)
            {
                SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(row["articulo_id"].ToString());
                //if (!(precios.PRECIO_VENTA >= System.Convert.ToDecimal(row["precio_costo"])))
                //{
                //   MessageBox.Show("El precio de venta (" + precios.PRECIO_VENTA.ToString("C2") + ") no puede ser menor al costo (" + System.Convert.ToDecimal(row["costo"]).ToString("C2") + ") del artículo " + row["articulo_id"].ToString());
                //    return false;
                //}

                SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
                SIFModelo.Articulo articulo = articuloL.BuscarPorClave(row["articulo_id"].ToString());
                SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
                SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow Invt = inventario.InventarioArticulo(articulo, Helpers.Sesion.Sucursal);
                int iCant = int.Parse(row["cantidad"].ToString());

                if (iCant <= (Invt.EXISTENCIAS - Invt.APARTADO_VTAS))
                {
                    PintaFilaTrue(row["articulo_id"].ToString(), GuardadosRowStyle);
                }
                else
                {
                    PintaFilaFalse(row["articulo_id"].ToString(), revisarRowStyle);
                    bandera++;
                }

            }

            if (bandera == 0)
            {
                return true;
            }
            else
            {
               MessageBox.Show("La cantidad ingresada debe ser igual o menor a la cantidad disponible", "Producto No Conforme");
                return false;
            }

            return true;
        }

        private void PintaFilaTrue(string articulo_id, DataGridViewCellStyle _style)
        {
            foreach (DataGridViewRow grow in Grd_Pedido.Rows)
            {
                if (grow.Cells["ARTICULO_ID"].Value.ToString() == articulo_id)
                {
                    PintaFila(grow, GuardadosRowStyle);
                }
            }
        }

        private void PintaFilaFalse(string articulo_id, DataGridViewCellStyle _style)
        {
            foreach (DataGridViewRow grow in Grd_Pedido.Rows)
            {
                if (grow.Cells["ARTICULO_ID"].Value.ToString() == articulo_id)
                {
                    PintaFila(grow, revisarRowStyle);
                }

            }
        }

        private void PintaFila(DataGridViewRow dgrow, DataGridViewCellStyle _style)
        {
            if (dgrow == null)
            {
                return;
            }
            var datagridRow = dgrow.DataBoundItem;

            if (!(datagridRow is DataRowView))
            {
                return;
            }

            dgrow.DefaultCellStyle = _style;
            dgrow.DefaultCellStyle.ApplyStyle(_style);
        }





    }
}
