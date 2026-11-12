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
    public partial class ConversioAlmacenUserControl : Templates.CatalogoUserControl
    {
        public string ConversionID;
        public string Referencia;

        public Boolean MostradoArt = false;
        string TipoArt = string.Empty;
        int NoLote = 0;
        public string Usr_Envia;
        public ConversioAlmacenUserControl()
        {
            InitializeComponent();
            
            
        }

        public bool Mostrado { get; set; }


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

        

        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.guardarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            
            
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
            
            this.AgregaArticulo(articulo);
        }

        SIFNegocio.Inventario.Conversiones ConversionL = new SIFNegocio.Inventario.Conversiones();
        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            
            int cantidad = 1;

            if (this.cantidadTextBoxXe.Text.IsIntegerPositive())
                cantidad = int.Parse(this.cantidadTextBoxXe.Text);

            ArticuloID.Text = articulo.ARTICULO_ID;
            cantidadTextBoxXe.Focus();
            //LIMPIAMOS TODAS LOS DATOS
            AgregaArticulo();


        }

        private void InicializaPedido()
        {
            
            if (ConversionID !="" )
            {
                foliotextBoxX.Text = ConversionID.ToString();
                textBoxX1.Text = Referencia;

                ConversionL.AjustesDataSet= ConversionL.GetConversion(ConversionID.ToString());
                Grd_Pedido.DataSource = ConversionL.AjustesDataSet.CONVERSION_DET;

                
            }   
            else
            {
                Grd_Pedido.DataSource = ConversionL.AjustesDataSet.CONVERSION_DET;
            }
            //formato a las columnas
                SIFNegocio.Inventario.Equivalencias Equi = new SIFNegocio.Inventario.Equivalencias();
                ConversionL.AjustesDataSet=Equi.GetEquivalencias(ConversionL.AjustesDataSet);
                ArticuloID.DataSource = ConversionL.AjustesDataSet.CAT_EQUIVALENCIAS;
                ArticuloID.DisplayMember="ARTICULO_ID";
                ArticuloID.ValueMember = "EQUIVALENCIA_ID";
                ArticuloCon.DataSource=ConversionL.AjustesDataSet.CAT_EQUIVALENCIAS;
                ArticuloCon.DisplayMember = "ARTICULO_IDE";
            
                descripcionLabel.DataBindings.Add(new Binding
               ("Text", ConversionL.AjustesDataSet.CAT_EQUIVALENCIAS, "Nombre1"));
                label2.DataBindings.Add(new Binding
                 ("Text", ConversionL.AjustesDataSet.CAT_EQUIVALENCIAS, "Nombree1"));

        }

        

        public void Back()
        {   
            try{
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

        public MainForm Owner { get; set; }



        private void PedidoAlmacenUserControl_Load(object sender, EventArgs e)
        {
            this.InicializaPedido();

        }

        
        private void cancelarButtonItem_Click(object sender, EventArgs e)
        {
         
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void GuardarPedido()
        {
            string ProductName = "Ajustes";
            if (textBoxX1.Text == "")
            {
               MessageBox.Show("Debe dar una referencia", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Grd_Pedido.RowCount > 0 && foliotextBoxX.Text.Contains("Nuevo"))
            {
                if (MessageBoxEx.Show("¿Crear la conversión?", ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    DataRow[] results = ConversionL.AjustesDataSet.CONVERSION_DET.Select(null, "Articulo_ID");
                     // IN Ajuste Array's
                    int[] Sec = new int[results.Length];
                    String[] Articulo = new String[results.Length];
                    String[] Nombre = new string[results.Length];
                    String[] ArticuloC = new String[results.Length];
                    String[] Nombrec = new string[results.Length];
                    Double[] CostoC = new Double[results.Length];
                    Double[] Costo = new Double[results.Length];
                    Double[] Total = new Double[results.Length];
                    int[] Cant = new int[results.Length];
                    int[] CantE = new int[results.Length];
                    int ind = 0, sec = 0;
                    string CtlLote = string.Empty;
                    string Tipo = string.Empty;
                    string SucRef = "0";

                    foreach (DataRow row in results)
                    {
                            sec++;
                            Sec[ind] = sec;
                            Articulo[ind] = row["ARTICULO_ID"].ToString();
                            Nombre[ind] = row["NOMBRE1"].ToString();
                            ArticuloC[ind] = row["ARTICULO_IDE"].ToString();
                            Nombrec[ind] = row["NOMBRE1E"].ToString();
                            CostoC[ind] = Convert.ToDouble(row["COSTOE"]);
                            Costo[ind] = Convert.ToDouble(row["COSTO"]);
                            Cant[ind] = Convert.ToInt16(row["CANTIDAD"]);
                            CantE[ind] = Convert.ToInt16(row["CANTIDADE"]);
                        ind++;
                    }

                    

                    if (ArticuloCon.SelectedIndex >= 0)
                        SucRef = ArticuloCon.SelectedValue.ToString();

                    ConversionL.InsConversion(textBoxX1.Text, SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString(), Helpers.Sesion.Usuario.UsuariosID.ToString(), "P", Articulo,
                        Nombre, Cant, ArticuloC, Nombrec, CantE, Costo, CostoC, Sec);
                 this.Back();
                    
                }

            }

            // Existe Ajuste
            if (Grd_Pedido.RowCount > 0 && !foliotextBoxX.Text.Contains("Nuevo"))
            {
                
                                string Tipo = string.Empty;
                                string SucRef = "0";

                                DataRow[] results = ConversionL.AjustesDataSet.CONVERSION_DET.Select(null, "articulo_id");
                                // IN Pedido Array's
                                int[] Sec = new int[results.Length];
                                String[] Articulo = new String[results.Length];
                                String[] Nombre = new string[results.Length];
                                String[] ArticuloC = new String[results.Length];
                                String[] Nombrec = new string[results.Length];
                                Double[] CostoC = new Double[results.Length];
                                Double[] Costo = new Double[results.Length];
                                Double[] Total = new Double[results.Length];
                                int[] Cant = new int[results.Length];
                                int[] CantE = new int[results.Length];
                                int ind = 0, sec = 0;
                                string CtlLote = string.Empty;
                                
                                foreach (DataRow row in results)
                                {
                                    sec++;
                                    Sec[ind] = sec;
                                    Articulo[ind] = row["ARTICULO_ID"].ToString();
                                    Nombre[ind] = row["NOMBRE1"].ToString();
                                    ArticuloC[ind] = row["ARTICULO_IDE"].ToString();
                                    Nombrec[ind] = row["NOMBRE1E"].ToString();
                                    CostoC[ind] = Convert.ToDouble(row["COSTOE"]);
                                    Costo[ind] = Convert.ToDouble(row["COSTO"]);
                                    Cant[ind] = Convert.ToInt16(row["CANTIDAD"]);
                                    CantE[ind] = Convert.ToInt16(row["CANTIDADE"]);
                                    ind++;
                                }
                                ConversionL.UpdConversion(ConversionID, textBoxX1.Text, Helpers.Sesion.Usuario.UsuariosID.ToString(), "P", Articulo, Nombre,
                                    Cant, ArticuloC, Nombrec, CantE, Costo, CostoC,Sec);
                                this.Back();
                }
            
        }

        private void guardarButtonItem_Click(object sender, EventArgs e)
        {


            GuardarPedido();
            
        }


        private void AgregaArticulo()
        {
            if (ArticuloID.SelectedIndex < 0 ||   ArticuloCon.SelectedIndex < 0)
                {
                   MessageBox.Show("Debe Seleccionar un articulo y una equivalencia", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ArticuloID.Focus();
                    return;
                }
                SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
                SIFModelo.Articulo articulo = articuloL.BuscarPorClave(ArticuloID.Text);



                if (string.IsNullOrEmpty(ArticuloID.Text) ||
                                       articulo == null)
                {
                   MessageBox.Show("Debe seleccionar un articulo", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ArticuloID.Focus();
                    return;
                }
                SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
                SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow Invt = inventario.InventarioArticulo(articulo, Helpers.Sesion.Sucursal);
                if (Invt.EXISTENCIAS < decimal.Parse(cantidadTextBoxX.Text))
                {
                   MessageBox.Show("No se tienen sufucientes existencias", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Agrega Articulo
                descripcionLabel.Text = articulo.NOMBRE1;
                ArticuloID.Focus();
                //object objSum = ConversionL.AjustesDataSet.CONVERSION_DET.Compute("Sum(Cantidad*Costo)", null);
                var Encontrado = from p in ConversionL.AjustesDataSet.CONVERSION_DET where p.ARTICULO_ID == articulo.ARTICULO_ID select p;
                if (Encontrado.Count() > 0)
                {
                    SIFModelo.Inventarios.InventarioDataSet.CONVERSION_DETRow rw = Encontrado.First();
                    rw.ARTICULO_ID = ArticuloID.Text;
                    rw.ARTICULO_IDE = ArticuloCon.Text;
                    rw.CANTIDAD = decimal.Parse(cantidadTextBoxX.Text);
                    rw.CANTIDADE = decimal.Parse(cantidadTextBoxXe.Text);
                    rw.COSTO = decimal.Parse(TxtCosto.Text);
                    rw.COSTOE = decimal.Parse(TxtCostoad.Text);
                    rw.NOMBRE1 = label2.Text;
                    rw.NOMBRE1E = descripcionLabel.Text;
                }
                else
                {
                    SIFModelo.Inventarios.InventarioDataSet.CONVERSION_DETRow rw = ConversionL.AjustesDataSet.CONVERSION_DET.NewCONVERSION_DETRow();
                    rw.ARTICULO_ID = ArticuloID.Text;
                    rw.ARTICULO_IDE = ArticuloCon.Text;
                    rw.CANTIDAD = decimal.Parse(cantidadTextBoxX.Text);
                    rw.CANTIDADE =decimal.Parse( cantidadTextBoxXe.Text);
                    rw.COSTO = decimal.Parse(TxtCosto.Text);
                    rw.COSTOE = decimal.Parse(TxtCostoad.Text);
                    rw.NOMBRE1 = label2.Text;
                    rw.NOMBRE1E = descripcionLabel.Text;
                    ConversionL.AjustesDataSet.CONVERSION_DET.AddCONVERSION_DETRow(rw);
                }
                
            }

        private void cantidadTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                AgregaArticulo();

                
        }

        private void AddArtTraspaso(int Lote, double Precio, double Costo)
        {
           
            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(ArticuloID.Text);
            int existencias = 0;
           
            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
            SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow Invt = inventario.InventarioArticulo(articulo, Helpers.Sesion.Sucursal);
            Precio = Invt.COSTO_PROM;
            Costo = Invt.ULT_COSTO;
            int iCant = int.Parse(cantidadTextBoxXe.Text);

              
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
        private int CierraTraspaso(string NoFolio, string NoLote)
        {
            SIFNegocio.Inventario.Traspasos tRAS = new SIFNegocio.Inventario.Traspasos();
            return tRAS.CierraTraspaso(Helpers.Sesion.Usuario.UsuariosID.ToString(),NoFolio, NoLote);
        }
        private void Cerrar()
        {

           
                if (MessageBoxEx.Show("¿Cerrar el Traspaso " + foliotextBoxX.Text +
                                                           "?",
                                  ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (CierraTraspaso(foliotextBoxX.Text,
                                      "1") > 0)
                        this.Back();

            
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            GuardarPedido();
            Cerrar();
            SIFModelo.Inventarios.InventarioDataSet Pedidos = ConversionL.GetConversion(foliotextBoxX.Text);
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

        private void Valores()
        {
            if (ArticuloID.SelectedIndex != -1)
            {
                if (ArticuloID.SelectedValue.ToString().IsInteger())
                {
                    int Equi_ID = int.Parse(ArticuloID.SelectedValue.ToString());
                    SIFModelo.Inventarios.InventarioDataSet.CAT_EQUIVALENCIASRow Row =
                    ConversionL.AjustesDataSet.CAT_EQUIVALENCIAS.FindByEQUIVALENCIA_ID(Equi_ID);
                    if (Row != null)
                    {//buscamos los dos articulos y obtenemos el costo
                        SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();

                        SIFModelo.Articulo articulo = articuloL.BuscarPorClave(ArticuloID.Text);

                        SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
                        SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow Invt = inventario.InventarioArticulo(articulo, Helpers.Sesion.Sucursal);

                        cantidadTextBoxXe.Text = (Row.EQUIVALENCIA * cantidadTextBoxX.Value).ToString();
                        TxtCosto.Text = Invt.ULT_COSTO.ToString();
                        if (Row.EQUIVALENCIA != 0)
                            TxtCostoad.Text = (Invt.ULT_COSTO / Row.EQUIVALENCIA).ToString();
                    }
                }
            }
        
        }

        private void ArticuloID_SelectedValueChanged(object sender, EventArgs e)
        {
            //mostramos el nombre y la conversion y agregamos al detalle
            Valores();    
        }

        private void ArticuloID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cantidadTextBoxX_ValueChanged_1(object sender, EventArgs e)
        {
            Valores();    
        }

        private void cantidadTextBoxX_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaArticulo(ArticuloID.Text);
             
            }

        }

        private void ArticuloID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaArticulo(ArticuloID.Text);

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            AgregaArticulo();
        }
    }
}
