using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;

namespace SIF.View.OrdenCompra
{
    public partial class OfertasCompraForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public OfertasCompraForm(SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ordenCompra)
        {
            this.proveedorID = ordenCompra.PROVEEDOR_ID;
            InitializeComponent();
            this.ordenCompra = ordenCompra;
            this.articuloLabel.Text = ordenCompra.ARTICULO_ID + " [" + ordenCompra["NOMBRE1"] + "]";
            this.agregaOfertas();
        }
        int? proveedorID;
        SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ordenCompra;


        private void agregaOfertas()
        {
            SIFNegocio.OrdenCompra.OrdenCompra ocl = new SIFNegocio.OrdenCompra.OrdenCompra();
            List<string> ofertas = ocl.Ofertas(ordenCompra.ARTICULO_ID, Helpers.Sesion.Sucursal.SucursalesID.ToString(), proveedorID);


            List<SIFModelo.OrdenCompra.OfertasCompra> ofertasCompra = new List<SIFModelo.OrdenCompra.OfertasCompra>();

            //if (ofertas.Count == 0)
            //{
            //SIFModelo.OrdenCompra.OfertasCompra ocMR = new SIFModelo.OrdenCompra.OfertasCompra();
            //ocMR.DescuentoEspecialProveedor = 0;
            //ocMR.DescuentoOfrecido = 0;

            //SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(ordenCompra.ARTICULO_ID);
            //SIFModelo.Cliente proveedor = new SIFNegocio.Clientes().ClientePorID(articulo.PROVEEDOR_ID);

            //ocMR.Nombre = proveedor.Nombre + " " + proveedor.ApellidoPaterno + " " + proveedor.ApellidoMaterno;
            //ocMR.PiezasConCargo = 1;
            //ocMR.PiezasSinCargo = 0;
            //ocMR.ProveedorID = proveedor.ID;
            //ocMR.PrecioFarmacia = ordenCompra.PRECIO_FARMACIA;
            //ocMR.PrecioCosto = ordenCompra.PRECIO_FARMACIA;
            //ofertasCompra.Add(ocMR);
            //}


            //if (proveedor != null && proveedor.ID == 99012)
            //{
            //    SIFNegocio.OrdenCompra.OrdenCompra oferasL = new SIFNegocio.OrdenCompra.OrdenCompra();

            //    SIFModelo.OrdenCompra.OfertaCompra ofEsp = oferasL.ofertaEspecialSaba(articulo.ARTICULO_ID, Helpers.Sesion.Sucursal.SucursalesID.ToString());

            //    if (ofEsp != null)
            //    {
            //        string ofeEspecial = 99012 + "|" + ofEsp.Nombre1 + "|" + ofEsp.DescuentoOfrecido.ToString("0.00") + "|" + "0.00" + "|" + "1" + "|" + "0" + "|" + "0.00" + "|" + "0.00";
            //        ofertas.Add(ofeEspecial);
            //    }
            //}



            foreach (string s in ofertas)
            {
                SIFModelo.OrdenCompra.OfertasCompra ocM = new SIFModelo.OrdenCompra.OfertasCompra();

                string[] data = s.Split(new char[] { '|' });

                if (data.Length <= 1)
                {
                    continue;
                }
                ocM.ProveedorID = int.Parse(data[0]);
                ocM.Nombre = data[1];
                ocM.DescuentoOfrecido = decimal.Parse(data[2]);
                ocM.DescuentoEspecialProveedor = decimal.Parse(data[3]);
                ocM.PiezasConCargo = int.Parse(data[4]);
                ocM.PiezasSinCargo = int.Parse(data[5]);
                ocM.PrecioFarmacia = ordenCompra.PRECIO_FARMACIA;
                ocM.PrecioCosto = ordenCompra.PRECIO_FARMACIA;
                decimal descuentoOfrecido = (ocM.PrecioCosto * (ocM.DescuentoOfrecido / 100m));
                decimal descuentoAdicional = (descuentoOfrecido * (ocM.DescuentoEspecialProveedor / 100m));
                ocM.PrecioCosto = ocM.PrecioCosto - descuentoOfrecido - descuentoAdicional;
                ofertasCompra.Add(ocM);

            }


            SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow usuario = new SIFModelo.Catalogo.CatalogoDataSet().COMPRADOR.NewCOMPRADORRow();

            usuario.USUARIO_ID = ordenCompra.USUARIO_ID.ToString();
            string listaProveedores = new SIFNegocio.Compradores().CompradorPorID(usuario).LISTA_PROVEEDOR_ID;

            foreach (var sproveedor in listaProveedores.Split(new char[]{ '|' }))
            {

                if (string.IsNullOrEmpty(sproveedor))
                {
                    continue;
                }
                    //AGREGAR LOS PROVEEDORES DEL USUARIO AUNQUE NO TENGAN OFERTA
                    var psaba = from s in ofertasCompra where s.ProveedorID == System.Convert.ToInt32(sproveedor) select s;

                    if (psaba.Count() == 0)
                    {
                        SIFModelo.OrdenCompra.OfertasCompra ocMProveedor = new SIFModelo.OrdenCompra.OfertasCompra();
                        ocMProveedor.ProveedorID = System.Convert.ToInt32(sproveedor);

                        SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(ocMProveedor.ProveedorID);
                        ocMProveedor.Nombre = cliente.Nombre;
                        ocMProveedor.DescuentoOfrecido = 0;
                        ocMProveedor.DescuentoEspecialProveedor = 0;
                        ocMProveedor.PiezasConCargo = 0;
                        ocMProveedor.PiezasSinCargo = 0;
                        ocMProveedor.PrecioFarmacia = ordenCompra.PRECIO_FARMACIA;
                        ocMProveedor.PrecioCosto = ordenCompra.PRECIO_FARMACIA;
                        decimal descuentoOfrecido = 0;
                        decimal descuentoAdicional = 0;
                        ocMProveedor.PrecioCosto = ocMProveedor.PrecioCosto - descuentoOfrecido - descuentoAdicional;
                        ofertasCompra.Add(ocMProveedor);
                    }
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = ofertasCompra;
            superGridControl1.PrimaryGrid.DataSource = bs;
        }

        private bool Valida()
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Debe seleccionar una oferta");
                return false;
            }
            return true;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        public SIFModelo.OrdenCompra.OfertasCompra Oferta = null;
        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (this.Valida())
            {
                Oferta = ((BindingSource)((GridRow)this.superGridControl1.PrimaryGrid.ActiveRow).DataItem).Current as SIFModelo.OrdenCompra.OfertasCompra;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void ofertasListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.aceptarButtonX_Click(null, null);
        }

        private void superGridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.aceptarButtonX_Click(null, null);
        }

    }
}
