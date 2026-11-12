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

namespace SIF.View.CallCenter
{
    public partial class CotizacionClienteMayoreoUserControl : Templates.CatalogoUserControl
    {
        public object Owner;
        private bool Mostrado;
        private int UsuarioID = 0;
        decimal PorScosto = 0m;
        SIFNegocio.cotizacionesClienteMayoristaNg cCMng = new SIFNegocio.cotizacionesClienteMayoristaNg();//cCMng cotizacion cliente mayorista negocio
        SIFNegocio.Cotizacion LogicaCotiza = new SIFNegocio.Cotizacion();
        public CotizacionClienteMayoreoUserControl()
        {
            InitializeComponent();
            this.cargaConfiguracionesIniciales();
            this.buscarTextBoxX.Focus();
        }



        public void Muestra()
        {
            ActivaComandos();


            if (Owner is CotizacionesClienteMayoreoUserControl)
            {

                CotizacionesClienteMayoreoUserControl propietario = Owner as CotizacionesClienteMayoreoUserControl;
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();

                this.ActivaComandos();
                this.Dock = DockStyle.Fill;
                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
                //Opciones();
                View.Ventas.AccesoUsuarioForm frmAcesoUsuario = new AccesoUsuarioForm();
                if (frmAcesoUsuario.ShowDialog() != DialogResult.OK)
                {
                    this.Back();
                    return;
                }
                UsuarioID = frmAcesoUsuario.Usuario.UsuariosID;
                //    this.CargaArticulosAbuscar();
            }


        }
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            /*this.guardarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.cancelarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.agregaProductoButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.seleccionaClienteButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);*/



        }


        private void cargaConfiguracionesIniciales() {
            this.cBoxExEnPrecio.Items.Add("PRECIO VENTA");
            this.cBoxExEnPrecio.Items.Add("PRECIO COSTO");
            this.cBoxExProcentajeOImporte.Items.Add("PORCENTAJE");
            this.cBoxExProcentajeOImporte.Items.Add("IMPORTE");
            this.cBoxExEnPrecio.SelectedIndex = 0;
            this.cBoxExProcentajeOImporte.SelectedIndex = 0;
            this.definirPrecioActivo(false, false);
            this.numericUpDown2.Value = 0.01M;




        }


        public void Back()
        {
            try
            {
                CotizacionesClienteMayoreoUserControl propietario = Owner as CotizacionesClienteMayoreoUserControl;
                propietario.ActivaComandos();
                this.DesactivaComandos();

                this.Dock = DockStyle.Fill;
                if (Owner is CotizacionesClienteMayoreoUserControl)
                {
                    CotizacionesClienteMayoreoUserControl p = Owner as CotizacionesClienteMayoreoUserControl;
                    p.Buscar();
                }
                if (this.Mostrado)
                {
                    if (propietario.Owner.Contains(this))
                        propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }
                this.Mostrado = false;

            }
            catch (Exception e)
            {

            }
        }
        private void buscarTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Buscar();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
            }
        }

        private void codigoTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Buscar();
            }

            /*if (e.KeyCode == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
            }*/
        }

        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
            /*   this.guardarButtonItem.Shortcuts.Clear();
               this.cancelarButtonItem.Shortcuts.Clear();
               this.seleccionaClienteButtonItem.Shortcuts.Clear();
               this.agregaProductoButtonItem.Shortcuts.Clear();*/
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        public void Buscar()
        {
            DataTable dt = cCMng.buscarArticulo(buscarTextBoxX.Text.ToString());
            dataGridViewX2.DataSource = dt;
        }

        private void cBoxDefinirPrecio_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxDefinirPrecio.Checked)
            {
                if (dataGridViewX1.RowCount > 0)
                {
                    MessageBox.Show("Ya agrego articulos a la cotizacion" + Environment.NewLine + "Remueva los articulos para utilizar esta opcion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.definirPrecioActivo(true, true);
            }
            else
            {
                if (dataGridViewX1.RowCount > 0)
                {
                    MessageBox.Show("Ya agrego articulos a la cotizacion" + Environment.NewLine + "Remueva los articulos para cambiar esta opcion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.definirPrecioActivo(false, false);
            }
        }

        private void definirPrecioActivo(Boolean enable , Boolean visible) {
        this.cBoxExEnPrecio.Visible = visible;
        this.cBoxExProcentajeOImporte.Visible = visible;
        this.cBoxExEnPrecio.Enabled = enable;
        this.cBoxExProcentajeOImporte.Enabled = enable;
        this.numericUpDown2.Visible=visible;
        this.numericUpDown2.Enabled = enable;
        }

        private void dataGridViewX2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewX2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.agregacodigo0(e);
        }

        private void dataGridViewX2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.agregacodigo(e);
        }

        private void agregacodigo(DataGridViewCellMouseEventArgs e) {
            this.AgregaArticulo(dataGridViewX2.Rows[e.RowIndex].Cells["ARTICULO_ID"].Value.ToString());

        }
        private void agregacodigo0(DataGridViewCellEventArgs e)
        {

            this.codigoTextBoxX.Text =dataGridViewX2.Rows[e.RowIndex].Cells["ARTICULO_ID"].Value.ToString();
            numericUpDown1.Focus();
            
            


        }
        public void AgregaArticulo(string claveArticulo)
        {
            if (string.IsNullOrEmpty(claveArticulo))
            {
                return;
            }
            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = null;
            articulo = articuloL.BuscarPorClave(claveArticulo);
            if (articulo == null)
            {
                MessageBox.Show("El artículo no existe en el catalogo");
                return;
            }
            this.AgregaArticulo(articulo);
        }

        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {

            LogicaCotiza.CotizacionM.SucursalID = SIF.Helpers.Sesion.Sucursal.SucursalesID;
            if (!articulo.LISTA_SUCURSAL_VTA.Contains(this.LogicaCotiza.CotizacionM.SucursalID.ToString()))
            {
                MessageBox.Show("El artículo no está permitido en esta sucursal");
                return;
            }

            if (!this.numericUpDown1.Text.ToString().IsIntegerPositive())
            {
                numericUpDown1.Text = "1";
            }

            this.codigoTextBoxX.Text = articulo.ARTICULO_ID;


            SIFModelo.CotizacionDetalle detalle = new SIFModelo.CotizacionDetalle();
            detalle.ArticuloID = articulo.ARTICULO_ID;
            detalle.Nombre1 = articulo.NOMBRE1;
            detalle.Nombre2 = articulo.NOMBRE2;
            detalle.CantidadCotizacion = detalle.CantidadCotizacion + int.Parse(this.numericUpDown1.Text);
            if (!this.PrecioArticulo(detalle, PorScosto))
                return;
            LogicaCotiza.AgregaDetalle(detalle);
            this.agregadatosGrid();
            
     
            //DataGridViewRow dr= new DataGridViewRow();
            
                


            //this.CalculaTotal();
            this.codigoTextBoxX.SelectAll();
            this.numericUpDown1.Text = "1";
            codigoTextBoxX.Focus();
        }
        private void agregadatosGrid() {

            DataTable dt = new DataTable();
            dt.Columns.Add("ARTICULOID");
            dt.Columns.Add("NOMBRE1");
            dt.Columns.Add("NOMBRE2");
            dt.Columns.Add("CANTIDADCOTIZACION");
            dt.Columns.Add("PRECIO");
            dt.Columns.Add("TOTAL");
            dt.Columns.Add("COMENTARIO");

            foreach (SIFModelo.CotizacionDetalle cdt in LogicaCotiza.CotizacionDetalles)
            {
                DataRow dr = dt.NewRow();
                dr["ARTICULOID"] = cdt.ArticuloID;
                dr["NOMBRE1"] = cdt.Nombre1;
                dr["NOMBRE2"] = cdt.Nombre2;
                dr["CANTIDADCOTIZACION"] = cdt.CantidadCotizacion;
                dr["PRECIO"] = cdt.Precio;
                dr["TOTAL"] = cdt.Total;
                dr["COMENTARIO"] = cdt.COMENTARIO;
                dt.Rows.Add(dr);

            }
            dataGridViewX1.DataSource = dt.DefaultView.ToTable(false, "ARTICULOID", "NOMBRE1", "NOMBRE2", "CANTIDADCOTIZACION", "PRECIO", "TOTAL", "COMENTARIO"); ;

        }


        private bool PrecioArticulo(SIFModelo.CotizacionDetalle detalle, Decimal PorSCosto)
        {
            SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
            detalle.PrecioVta = precios.PRECIO_VENTA;
            detalle.PrecioCosto = precios.PRECIO_COSTO;

            if (precios == null)
            {
                MessageBox.Show("No hay un precio activo para este producto");
                return false;
            }
            else
            {
                SIFModelo.Articulo articulop = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);

                if (PorScosto > 0 && !articulop.TIPO_MEDICAMENTO_CVE.ToString().Contains("SD"))//L 20/12/2013 No aplicar porcentaje sobre costo si es SD
                {
                    if (detalle.Precio < precios.COSTO_PROM)
                    {
                        MessageBox.Show("El precio del producto No puede ser menor al Costo", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_COSTO + (precios.PRECIO_COSTO * PorScosto / 100));
                    detalle.Total = detalle.CantidadCotizacion * detalle.Precio;
                    detalle.PrecioCosto = precios.PRECIO_COSTO;
                    detalle.PrecioVta = precios.PRECIO_VENTA;

                    if (detalle.Precio == 0)
                    {
                        MessageBox.Show("El precio del producto es cero", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    detalle.ImpuestoID = precios.IMP_VENTA;
                    SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);
                    if (impuesto != null)
                    {
                        decimal calculaImpuesto = detalle.Total * (impuesto.Porcentaje / 100m);
                        detalle.IVA = calculaImpuesto;
                    }
                }
                else
                {

                    if (PorScosto > 0 && articulop.TIPO_MEDICAMENTO_CVE.ToString().Contains("SD"))
                    {
                        MessageBox.Show("Este producto no aplica descuento: " + articulop.ARTICULO_ID + " " + articulop.NOMBRE1);
                    }
                    if (detalle.PrecioVta < precios.COSTO_PROM)
                    {
                       MessageBox.Show("El precio del producto No puede ser menor al Costo", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    detalle.Precio = precios.PRECIO_VENTA;
                    detalle.Total = detalle.CantidadCotizacion * detalle.Precio;
                    detalle.PrecioCosto = precios.PRECIO_COSTO;
                    detalle.PrecioVta = precios.PRECIO_VENTA;

                    if (detalle.Precio == 0)
                    {
                       MessageBox.Show("El precio del producto es cero", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }


                    detalle.ImpuestoID = precios.IMP_VENTA;
                    SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);
                    if (impuesto != null)
                    {
                        decimal calculaImpuesto = detalle.Total * (impuesto.Porcentaje / 100m);
                        detalle.IVA = calculaImpuesto;
                    }
                }
            }
            return true;
        }

        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool refrescar = false;
                if (dataGridViewX1.Columns[e.ColumnIndex].HeaderText == "COMENTARIO" ||
                    dataGridViewX1.Columns[e.ColumnIndex].HeaderText == "PRECIO" ||
                    dataGridViewX1.Columns[e.ColumnIndex].HeaderText == "CANTIDAD")
                {
                    foreach (DataGridViewRow dr in dataGridViewX1.Rows)
                    {
                        string articulo = dr.Cells["CODIGO"].Value.ToString();
                        foreach (SIFModelo.CotizacionDetalle cdt in LogicaCotiza.CotizacionDetalles)
                        {
                            if (articulo == cdt.ArticuloID)
                            {
                                cdt.COMENTARIO = dr.Cells["COMENTARIO"].Value.ToString();
                                cdt.Precio = Convert.ToDecimal(dr.Cells["PRECIO"].Value);
                                cdt.CantidadCotizacion = Convert.ToInt32(dr.Cells["CANTIDAD"].Value.ToString());
                                cdt.Total = cdt.Precio * cdt.CantidadCotizacion;
                                refrescar = true;

                            }

                        }

                    }


                }
                if (refrescar)
                {
                    this.agregadatosGrid();
                }
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.ToString());
            }
        }

        private void dataGridViewX1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
           /* var itemToRemove = resultlist.SingleOrDefault(r => r.Id == 2);
            if (itemToRemove != null)
                resultList.Remove(itemToRemove);*/
        }




    }
}
