using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using Equin.ApplicationFramework;

namespace SIF.View.OrdenCompra
{
    public partial class BonificacionDetallesUserControl : Templates.ListaUserControl
    {
        public BonificacionDetallesUserControl()
        {
            InitializeComponent();
            this.CodigoTextBoxX.Focus();
            this.cargaSucursales();
            this.cargaConceptosBonificacion();
        }

        private void cargaSucursales()
        {
            SIFNegocio.Sucursales sucursalL = new SIFNegocio.Sucursales();
            this.sucursalComboBoxEx.DataSource = sucursalL.Buscar("", "");
            sucursalComboBoxEx.DisplayMember = "Nombre";
            sucursalComboBoxEx.ValueMember = "SucursalesID";
            sucursalComboBoxEx.SelectedIndex = 0;
        }

        private void cargaConceptosBonificacion()
        {
            this.conceptoBoxEx.DataSource = new SIFNegocio.TipoDevolucions().BuscarCompras();
            conceptoBoxEx.DisplayMember = "Nombre";
            conceptoBoxEx.ValueMember = "TipoDevolucionID";
        }

        public BonificacionUserControl Owner;
        internal void Muestra()
        {
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;

            Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }

        private void Back()
        {
            try{
            if (this.Mostrado && Owner.Owner.Owner.IsModalPanelDisplayed)
            {
                //this.DesactivaComandos();
                try
                {
                    if (Owner.Owner.Owner.Contains(this))
                    {
                        Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Owner.ActivaComandos();
                    this.Mostrado = false;
                    this.DesactivaComandos();
                }
                catch
                {

                }
            }
            }
            catch { }
        }

        public void ActivaComandos()
        {
            this.backButton.Shortcuts.Add(eShortcut.F12);
            this.agregaProductoButtonItem.Shortcuts.Add(eShortcut.F4);
            this.eliminarArticuloButtonItem.Shortcuts.Add(eShortcut.F8);
            this.recibirButtonItem.Shortcuts.Add(eShortcut.F5);
        }
        public void DesactivaComandos()
        {
            this.backButton.Shortcuts.Clear();
            this.agregaProductoButtonItem.Shortcuts.Clear();
            this.eliminarArticuloButtonItem.Shortcuts.Clear();
            this.recibirButtonItem.Shortcuts.Clear();
        }

        public bool Mostrado { get; set; }
        public int UsuarioId { get; set; }


        #region Funciones y Metodos

        private void SeleccionaArticulo()
        {
            Articulos.ArticuloUserControl frmArticulo;

            frmArticulo = new View.Articulos.ArticuloUserControl();
            frmArticulo.Dock = DockStyle.Fill;
            frmArticulo.Owner = this;

            frmArticulo.Muestra();
        }

        internal void AgregaArticulo(string claveArticulo)
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


        SIFModelo.OrdenCompra.OrdenesCompraDataSet dsOrdenCompra = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();
        internal void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            SIFModelo.Inventarios.ListaPrecios precios = SIFNegocio.Articulo.PrecioArticulo(articulo);

            if (precios == null)
            {
                precios = new SIFModelo.Inventarios.ListaPrecios();
            }

            this.CodigoTextBoxX.Text = articulo.ARTICULO_ID;
            this.descripcionTextBoxX.Text = articulo.NOMBRE1;

            int cantidad = int.Parse(this.cantidadTextBoxX.Text);

            //CHECAR SI YA EXISTE EL ARTICULO EN LA TABLA

            var encontrado = from b in dsOrdenCompra.BONIFICACION_DET where b.ARTICULO_ID == articulo.ARTICULO_ID select b;

            if (encontrado.Count() > 0)
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.BONIFICACION_DETRow rwBonificacion = encontrado.First();
                rwBonificacion.CANTIDAD += cantidad;
            }
            else
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.BONIFICACION_DETRow rwBonificacion = dsOrdenCompra.BONIFICACION_DET.NewBONIFICACION_DETRow();
                rwBonificacion.ARTICULO_ID = articulo.ARTICULO_ID;
                rwBonificacion.CANTIDAD = cantidad;
                rwBonificacion.NOMBRE1 = articulo.NOMBRE1;
                rwBonificacion.NOMBRE2 = articulo.NOMBRE2;
                rwBonificacion.PRECIO = 0;
                rwBonificacion.PRECIO_VTA = (double)precios.PRECIO_VENTA;
                rwBonificacion.SUCURSAL_ID = 0;
                rwBonificacion.FOLIO = "";
                rwBonificacion.LOTE = 0;
                rwBonificacion.CONCEPTO_DET = articulo.NOMBRE1;
                rwBonificacion.PARTIDA = (short)(rwBonificacion.Table.Rows.Count + 1);

                this.ordenaPartidas();
                this.dsOrdenCompra.BONIFICACION_DET.AddBONIFICACION_DETRow(rwBonificacion);
            }

            this.calculaTotal();
            this.cantidadTextBoxX.Text = "1";
            superGridControl1.Refresh();
        }

        private void ordenaPartidas()
        {
            for (short p = 1; p <= this.dsOrdenCompra.BONIFICACION_DET.Rows.Count; p++)
            {
                ((SIFModelo.OrdenCompra.OrdenesCompraDataSet.BONIFICACION_DETRow)this.dsOrdenCompra.BONIFICACION_DET.Rows[p - 1]).PARTIDA = p;
            }
        }

        private void eliminar()
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija un producto de la list");
                return;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.BONIFICACION_DETRow detalle = ((DataRowView)((GridRow)this.superGridControl1.PrimaryGrid.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.BONIFICACION_DETRow;

            if (MessageBoxEx.Show("¿Quitar el artículo  " + detalle.ARTICULO_ID + " [ " + detalle.NOMBRE1 + "]?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            this.dsOrdenCompra.BONIFICACION_DET.RemoveBONIFICACION_DETRow(detalle);
            this.ordenaPartidas();
            this.superGridControl1.Refresh();
        }

        private void guardar()
        {
            if (!valida())
            {
                return;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.BONIFICACIONRow bonificacion = dsOrdenCompra.BONIFICACION.NewBONIFICACIONRow();
            bonificacion.ACTIVO = "A"; //activo
            bonificacion.CONCEPTO = this.conceptoBoxEx.SelectedValue.ToString();
            bonificacion.DOC_REFERENCIA = this.referenciaTextBoxX.Text;
            bonificacion.FECHA_REG = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

            bonificacion.LOTE = short.Parse(this.loteTextBoxX.Text);
            SIFModelo.Sucursal sucursal = ((ObjectView<SIFModelo.Sucursal>)this.sucursalComboBoxEx.SelectedItem).Object as SIFModelo.Sucursal;
            bonificacion.SUCURSAL_ID = (short)sucursal.SucursalesID;
            bonificacion.TOTAL = calculaTotal();
            bonificacion.USUARIO_ID = UsuarioId.ToString();

            bonificacion.FOLIO = new SIFNegocio.OrdenCompra.OrdenCompra().FolioBonificacion((int)bonificacion.SUCURSAL_ID);

            bool insertado = new SIFNegocio.OrdenCompra.OrdenCompra().InsertaBonificacion(bonificacion, this.dsOrdenCompra.BONIFICACION_DET);

            if (!insertado)
            {
               MessageBox.Show("Ocurrió un error al procesar la bonificación");
                return;
            }
           MessageBox.Show("Se ha creado la bonificiación correctamente");
            this.Back();
            //LIMPIAR
        }



        private bool valida()
        {
            if (string.IsNullOrEmpty(this.loteTextBoxX.Text))
            {
               MessageBox.Show("Debe ingresar el número de lote");
                this.loteTextBoxX.Focus();
                return false;
            }
            if (this.sucursalComboBoxEx.SelectedValue == null)
            {
               MessageBox.Show("Debe especificar a la sucursal k involucra");
                sucursalComboBoxEx.Focus();
                return false;
            }
            if (!loteTextBoxX.Text.IsInteger())
            {
               MessageBox.Show("El lote debe ser numero");
                this.loteTextBoxX.Focus();
                this.loteTextBoxX.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(this.referenciaTextBoxX.Text))
            {
               MessageBox.Show("Escriba la referencia");
                this.referenciaTextBoxX.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.conceptoBoxEx.Text))
            {
               MessageBox.Show("Debe ingresar el concepto de la bonificación");
                this.conceptoBoxEx.Focus();
                return false;
            }


            if (this.conceptoBoxEx.SelectedValue == null)
            {
               MessageBox.Show("Debe especificar el concepto de la bonificación");
                conceptoBoxEx.Focus();
                return false;
            }

            var conceptoVacio = from c in dsOrdenCompra.BONIFICACION_DET where c.CONCEPTO_DET == "" select c;

            if (conceptoVacio.Count() > 0)
            {
               MessageBox.Show("Debe ingresar los detalles de bonificación");
                return false;
            }

            return true;
        }

        private double calculaTotal()
        {
            var totalv = dsOrdenCompra.BONIFICACION_DET.Sum(v => v.CANTIDAD * v.PRECIO_VTA);
            double total = 0;

            if (totalv.ToString().IsFloat())
            {
                total = double.Parse(totalv.ToString());
                this.totalLabelX.Text = total.ToString("C2");
            }
            return total;
        }
        #endregion

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void agregaProductoButtonItem_Click(object sender, EventArgs e)
        {
            this.SeleccionaArticulo();
        }

        private void BonificacionDetallesUserControl_Load(object sender, EventArgs e)
        {
            this.superGridControl1.PrimaryGrid.DataSource = dsOrdenCompra.BONIFICACION_DET;
            this.CodigoTextBoxX.Focus();
        }

        private void CodigoTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            //BUSCAR EL ARTICULO QUE PERTENECE A LA CLAVE
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaArticulo(CodigoTextBoxX.Text);
            }

            if (e.KeyCode == Keys.F3)
            {
                this.SeleccionaArticulo();
            }
        }

        private void CodigoTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.SeleccionaArticulo();
        }

        private void eliminarArticuloButtonItem_Click(object sender, EventArgs e)
        {
            this.eliminar();
        }

        private void recibirButtonItem_Click(object sender, EventArgs e)
        {
            this.guardar();
        }

        private void superGridControl1_EndEdit(object sender, GridEditEventArgs e)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.BONIFICACION_DETRow modelo = new SIFModelo.OrdenCompra.OrdenesCompraDataSet().BONIFICACION_DET.NewBONIFICACION_DETRow();
            string propiedadBusqueda = Helpers.Reflect.GetMember(() => modelo.NOMBRE1).Name;

            if (e.GridCell.GridColumn.DataPropertyName == Helpers.Reflect.GetMember(() => modelo.CANTIDAD).Name)
            {
                modelo = ((DataRowView)(e.GridCell.GridRow.DataItem)).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.BONIFICACION_DETRow;
                if (modelo.CANTIDAD < 1)
                {
                    MessageBox.Show("La cantidad no es válida");
                    modelo.CANTIDAD = 1;
                    e.GridCell.Value = 1;
                    e.Cancel = true;
                    return;
                }

                this.calculaTotal();
            }
        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }
        }

        private void cantidadTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaArticulo(this.CodigoTextBoxX.Text);
                this.CodigoTextBoxX.Focus();
            }
        }



    }
}
