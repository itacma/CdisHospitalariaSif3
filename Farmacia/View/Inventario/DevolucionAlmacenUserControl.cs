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
    public partial class DevolucionAlmacenUserControl : Templates.CatalogoUserControl
    {
        public Int64 TraspasoID;
        public int lote;
        public String SucursalO;
        public String SucursalD;
        DataTable dtTraspaso = new DataTable();
        DataTable dtPedido = new DataTable();
        double PrecioArt = 0;
        string TipoArt = string.Empty;
        int NoLote = 0;
        public string Usr_Envia;
        public DevolucionAlmacenUserControl()
        {
            InitializeComponent();
            this.CargaSucursalOrigen();
            this.CargaSucursalDestino();
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


        }

        private void CargaSucursalDestino()
        {
            BindingList<SIFModelo.Sucursal> sucursales = new BindingList<SIFModelo.Sucursal>();
            //SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { Nombre = "[TODAS]", SucursalesID = 0 };
            //sucursales.Add(sucursal);
            //sucursales.ToList();d
            List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().Buscar("", "").DataSource as List<SIFModelo.Sucursal>;


        }

        public void ActivaComandos()
        {

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
                System.Windows.Forms.SendKeys.Send("{TAB}");
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


        }

        private void InicializaPedido()
        {
            foliotextBoxX.Text = TraspasoID.ToString();

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

        public DevolucionesAlmacenUserControl Owner { get; set; }

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
            Double[] PrecioE = new Double[results.Length];
            int[] Caja = new int[results.Length];
            String[] Pedido = new String[results.Length];

            Double Total = 0;
            int sec = 0;
            string CtlFolio = foliotextBoxX.Text;
            object objSum = dtTraspaso.Compute("Sum(total)", "");
            Total = Convert.ToDouble(objSum.ToString());

            foreach (DataRow rowdet in results)
            {
               
                Sec[sec] = sec + 1;
                Lote[sec] = Convert.ToInt16(rowdet["Lote"].ToString());
                Articulo[sec] = rowdet["id"].ToString();
                Concepto[sec] = rowdet["nombre"].ToString();
                CantS[sec] = Convert.ToInt16(rowdet["pedido"]);
                CantE[sec] = Convert.ToInt16(rowdet["Enviado"]);
                CantR[sec] = Convert.ToInt16(rowdet["Recibido"]);
                PrecioE[sec] = Convert.ToDouble(rowdet["precio"]);
                Caja[sec] = Convert.ToInt16(rowdet["caja"]);
                Pedido[sec] = rowdet["Solicita"].ToString();
                sec++;
            }
            //int result = traspasoAlmacenL.UpdTraspaso(CtlFolio,  Lote, Total, Sec, Articulo, Concepto, CantS, CantE, CantR, PrecioE, PrecioE, Caja, Pedido, Usr_Envia, Helpers.Sesion.Usuario.Nombre);
            
        }

        private void guardarButtonItem_Click(object sender, EventArgs e)
        {


            GuardarPedido();
            this.Back();
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
                AddArtTraspaso(NoLote, PrecioArt, 0); //NoCaja
                cantidadTextBoxX.Value = 1;
                CodigoTextBoxX.Focus();
                object objSum = dtTraspaso.Compute("Sum(total)", null);
                label1.Text = objSum.ToString();
            }

        private void cantidadTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            String ProductName = "Traspasos";

            if (e.KeyCode == Keys.Enter)
                AgregaArticulo();

                
        }

        private void AddArtTraspaso(int Lote, double Precio, int NoCaja)
        {
            String ProductName = "Traspasos";

            DataRow RegArt = dtTraspaso.Rows.Find(CodigoTextBoxX.Text);
            if (RegArt == null)
            {
                
                    dtTraspaso.Rows.Add(Lote,
                                      CodigoTextBoxX.Text,
                                      descripcionLabel.Text,
                                      0,0,
                                                                            cantidadTextBoxX.Text,
                                      Precio,
                                      NoCaja,
                                      'N');
                    dtTraspaso.DefaultView.Sort = "caja, id ASC";
            }
            else
            {
                RegArt["Recibido"] = Convert.ToInt16(cantidadTextBoxX.Text);
                RegArt["precio"] = Precio;
            }

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
            
        }

        private void cantidadTextBoxX_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
