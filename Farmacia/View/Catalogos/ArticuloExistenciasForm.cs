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
    public partial class ArticuloExistenciasForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        private SIFModelo.Articulo articulo;

        public ArticuloExistenciasForm()
        {
            InitializeComponent();
        }

        public ArticuloExistenciasForm(SIFModelo.Articulo articulo)
            : this()
        {
            // TODO: Complete member initialization
            this.articulo = articulo;
            CargaSucursales();
            EstableceArticulo();
            EstableceExistencias();
        }

        private void EstableceArticulo()
        {
            this.codigoLabelX.Text = articulo.ARTICULO_ID;
            this.nombre1LabelX.Text = articulo.NOMBRE1;
            this.nombre2LabelX.Text = articulo.NOMBRE2;
        }

        private bool validaInventario()
        {
            if(string.IsNullOrEmpty( ubicacionTextBoxX.Text))
            {
               MessageBox.Show("Debe ingresar la ubicación del artículo");
                ubicacionTextBoxX.Focus();
                return false;
            }


            if (string.IsNullOrEmpty( puntoReordenTextBox.Text))
            {
               MessageBox.Show("Debe especificar el punto de reorden");
                puntoReordenTextBox.Focus();
                return false;
            }

            if (!puntoReordenTextBox.Text.IsInteger())
            {
               MessageBox.Show("El punto de reorden no es válido");
                puntoReordenTextBox.Focus();
                return false;
            }

            return true;
        }

        private bool actualizaInventario()
        {
            if (!validaInventario())
            {
                return false;
            }

            SIFNegocio.Inventario.Inventario inventarioL = new SIFNegocio.Inventario.Inventario();
            SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow row  = new SIFModelo.Inventarios.InventarioDataSet().INVENTARIO.NewINVENTARIORow();
            row["ARTICULO_ID"] = this.articulo.ARTICULO_ID;
            SIFModelo.Sucursal sucursal = almacenComboBoxEx.SelectedItem as SIFModelo.Sucursal;
            row.SUCURSAL_ID = (short)sucursal.SucursalesID;
            row.UBICACION = ubicacionTextBoxX.Text;
            inventarioL.ActualizaUbicacion(row);

            row.PUNTO_DE_REORDEN =  System.Convert.ToInt16(this.puntoReordenTextBox.Text);
            SIFNegocio.Inventario.EOQ eoqL = new SIFNegocio.Inventario.EOQ();
            eoqL.ActualizaEOQinventario(row, sucursal);

            return true;
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

            almacenComboBoxEx.SelectedValue = Helpers.Sesion.Sucursal.SucursalesID;
        }

        private void EstableceExistencias()
        {
            if (!loaded)
            {
                return;
            }

            SIFModelo.Sucursal sucursal = almacenComboBoxEx.SelectedItem as SIFModelo.Sucursal;

            var inventario = new SIFNegocio.Inventario.Inventario().InventarioArticulo(articulo, sucursal);

            if (inventario == null)
            {
               MessageBox.Show("No fue posible consultar el inventario de la sucursal " + sucursal.Nombre);

                ultimaEntradaLabelX.Text = "";
                ultimaSalidaLabelX.Text = "";
                this.inventarioFisicoLabelX.Text = "";
                this.existenciasLabelX.Text = "";
                this.maximoLabelX.Text = "";
                this.minimoLabelX.Text = "";
                this.puntoReordenTextBox.Text = "";
                this.apartadoLabelX.Text = "";

                this.ubicacionTextBoxX.Text = "";

                return;
            }

            ultimaEntradaLabelX.Text = inventario.FECHA_ULT_MOV.ToShortDateString();
            ultimaSalidaLabelX.Text = inventario.FECHA_ULT_SAL.ToShortDateString();
            this.inventarioFisicoLabelX.Text = inventario.INV_FISICO.ToString();
            this.existenciasLabelX.Text = inventario.EXISTENCIAS.ToString();
            this.maximoLabelX.Text = inventario.EXISTENCIA_MAX.ToString();
            this.minimoLabelX.Text = inventario.EXISTENCIA_MIN.ToString();
            this.puntoReordenTextBox.Text = inventario.PUNTO_DE_REORDEN.ToString();
            this.apartadoLabelX.Text = inventario.APARTADO_VTAS.ToString();

            this.ubicacionTextBoxX.Text = inventario.UBICACION;
        }

        private void almacenComboBoxEx_SelectedValueChanged(object sender, EventArgs e)
        {
            this.EstableceExistencias();
        }

        bool loaded = false;
        private void ArticuloExistenciasForm_Load(object sender, EventArgs e)
        {
            loaded = true;

            EstableceExistencias();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (actualizaInventario())
            {
               MessageBox.Show("Se han actualizado los datos del artículos");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

    }
}
