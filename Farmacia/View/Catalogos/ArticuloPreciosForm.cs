using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Catalogos
{
    public partial class ArticuloPreciosForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        private SIFModelo.Articulo articulo;

        public ArticuloPreciosForm()
        {
            InitializeComponent();
        }

        public ArticuloPreciosForm(SIFModelo.Articulo articulo)
            : this()
        {
            // TODO: Complete member initialization
            this.articulo = articulo;
            CargaSucursales();
            this.CargaPrecios();
            EstableceArticulo();
        }

        private void calculaUtilidad()
        {
           
            decimal precioFleming = 0;
            decimal precioMaximoPublico = 0;
            decimal precioCosto = 0;

            if (precioFlemingTextBoxX.Text.IsFloat())
            {
                precioFleming = System.Convert.ToDecimal(precioFlemingTextBoxX.Text);
            }

            if (precioMaximoPublicoBoxX.Text.IsFloat())
            {
                precioMaximoPublico = System.Convert.ToDecimal(precioMaximoPublicoBoxX.Text);
            }

            if (precioCostoTextBoxX.Text.IsFloat())
            {
                precioCosto = System.Convert.ToDecimal(precioCostoTextBoxX.Text);
            }
            
            //precioUnitarioUtilidadTextBoxX descto de pmp = pf / pmp * 100 -100
            decimal descuentoPMP = 0;
            if (precioMaximoPublico > 0)
            {
                descuentoPMP = (((precioFleming / precioMaximoPublico) * 100) - 100) * -1;
            }
            

            //UTILIDAD pf / pcosto * 100 - 100

            SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precio.IMP_VENTA);

            if (impuesto == null)
            {
                impuesto = new SIFModelo.Impuesto();
            }

            decimal ivaArticulo = 0;
            decimal ivaArticulot = 0;
            if (impuesto.Porcentaje > 0)
            {
                ivaArticulo = precioFleming / (impuesto.Porcentaje /100);
            }
            if (impuesto.Porcentaje > 0)
            {
                ivaArticulot = precioCosto *( (impuesto.Porcentaje / 100)+1);
            }

            decimal utilidadSIVA = 0;
            if (precioCosto > 0)
            {
              utilidadSIVA =  ((precioFleming / precioCosto) * 100) - 100;
            }

            decimal utilidad = 0;
            if (precioFleming > 0)
            {
            utilidad = (((precioFleming - ivaArticulot)/precioFleming)*100 );
            }

            descuentoPMPTextBoxX.Text = descuentoPMP.ToString("0.000");

            if (impuesto.Porcentaje == 0)
                utilidadTextBoxX.Text = utilidadSIVA.ToString("0.000");
            else
            utilidadTextBoxX.Text = utilidad.ToString("0.000");

           
            precioFarmaciaConIVATextBoxX.Text = utilidadSIVA.ToString("0.000");

        }

        private void EstableceArticulo()
        {
            this.codigoLabelX.Text = articulo.ARTICULO_ID;
            this.nombre1LabelX.Text = articulo.NOMBRE1;
            this.nombre2LabelX.Text = articulo.NOMBRE2;

            almacenComboBoxEx.SelectedValue = Helpers.Sesion.Sucursal.SucursalesID;
        }

        private void CargaSucursales()
        {
            BindingList<SIFModelo.Sucursal> sucursales = new BindingList<SIFModelo.Sucursal>();
            List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().Buscar("", "").DataSource as List<SIFModelo.Sucursal>;

            foreach (SIFModelo.Sucursal sucursalBd in sucursalesBD)
            {
                sucursales.Add(sucursalBd);
            }

            almacenComboBoxEx.DataSource = sucursales;
            almacenComboBoxEx.DisplayMember = "NOMBRE";
            almacenComboBoxEx.ValueMember = "SUCURSALESID";
        }

        SIFModelo.Inventarios.ListaPrecios precio;
        private void CargaPrecios()
        {
            precio = new SIFNegocio.Articulo().ArticuloPrecio(articulo.ARTICULO_ID);

            if (precio == null)
            {
                precio = new SIFModelo.Inventarios.ListaPrecios();
            }

            this.precioMaximoPublicoBoxX.Text = precio.PRECIO_VENTA_MAX.ToString();
            this.precioFarmaciaTextBoxX.Text = precio.PRECIO_VENTA_FARM.ToString();
            this.precioCostoTextBoxX.Text = precio.PRECIO_COSTO.ToString();
            this.costoPromedioTextBoxX.Text = precio.COSTO_PROM.ToString();
            this.precioFlemingTextBoxX.Text = precio.PRECIO_VENTA.ToString();
            //this.precioMinimoTextBoxX.Text = 
            calculaUtilidad();
        }

        private void GuardaPMPPF()
        {
           precio.PRECIO_VENTA_MAX = System.Convert.ToDecimal(this.precioMaximoPublicoBoxX.Text);
           precio.PRECIO_VENTA_FARM = System.Convert.ToDecimal(this.precioFarmaciaTextBoxX.Text);
            //this.precioCostoTextBoxX.Text = precio.PRECIO_COSTO.ToString();
            //this.costoPromedioTextBoxX.Text = precio.COSTO_PROM.ToString();
           precio.PRECIO_VENTA = System.Convert.ToDecimal( this.precioFlemingTextBoxX.Text);


            SIFNegocio.Articulo.ActualizaPMP(precio, Helpers.Sesion.Usuario.UsuariosID.ToString());
            SIFNegocio.Articulo.ActualizaPFleming(precio,  Helpers.Sesion.Usuario.UsuariosID.ToString());
            SIFNegocio.Articulo.ActualizaPFarmacia(precio,  Helpers.Sesion.Usuario.UsuariosID.ToString());
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            //GUARDAR PMP,PF Y PF

            if (System.Convert.ToDecimal(precioMaximoPublicoBoxX.Text) < System.Convert.ToDecimal(precioFlemingTextBoxX.Text)) {
                MessageBox.Show("El precio de venta maximo es menor al precio Fleming", "Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            GuardaPMPPF();
           MessageBox.Show("Se ha guardado el precio establecido");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void precioMaximoPublicoBoxX_TextChanged(object sender, EventArgs e)
        {
            this.calculaUtilidad();
        }

        private void precioFlemingTextBoxX_TextChanged(object sender, EventArgs e)
        {
            this.calculaUtilidad();
        }


       
    }
}
