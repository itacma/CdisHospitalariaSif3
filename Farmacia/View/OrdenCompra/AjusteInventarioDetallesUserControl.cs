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
    public partial class AjusteInventarioDetallesUserControl : Templates.ListaUserControl
    {
        public AjusteInventarioDetallesUserControl()
        {
            InitializeComponent();
            this.CodigoTextBoxX.Focus();
            this.cargaSucursales();
            this.cargaTiposMovimiento();
        }

        private void cargaSucursales()
        {
            SIFNegocio.Sucursales sucursalL = new SIFNegocio.Sucursales();
            this.sucursalComboBoxEx.DataSource = sucursalL.Buscar("", "");
            sucursalComboBoxEx.DisplayMember = "Nombre";
            sucursalComboBoxEx.ValueMember = "SucursalesID";
        }

        private void cargaTiposMovimiento()
        {
            List<SIFModelo.TipoMovimiento> movimientos = new SIFNegocio.TipoMovimientos().BuscarActivos();
            BindingSource src = new BindingSource();
            src.DataSource = movimientos;

            this.tipoMovimientoComboBoxEx.DataSource = src;
            tipoMovimientoComboBoxEx.DisplayMember = "Nombre";
            tipoMovimientoComboBoxEx.ValueMember = "ID";
        }

        public AjusteInventarioUserControl Owner;
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
        }
        public void DesactivaComandos()
        {
            this.backButton.Shortcuts.Clear();
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

            var encontrado = from b in dsOrdenCompra.AJUSTES_DET where b.ARTICULO_ID == articulo.ARTICULO_ID select b;

            if (encontrado.Count() > 0)
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.AJUSTES_DETRow rwAjusteInventario = encontrado.First();
                rwAjusteInventario.CANTIDAD += cantidad;
            }
            else
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.AJUSTES_DETRow rwAjusteInventario = dsOrdenCompra.AJUSTES_DET.NewAJUSTES_DETRow();
                rwAjusteInventario.ARTICULO_ID = articulo.ARTICULO_ID;
                rwAjusteInventario.CANTIDAD = cantidad;
                rwAjusteInventario.NOMBRE1 = articulo.NOMBRE1;
                rwAjusteInventario.NOMBRE2 = articulo.NOMBRE2;
                rwAjusteInventario.PRECIO = (double)precios.PRECIO_COSTO;
                rwAjusteInventario.PRECIO_VTA = (double)precios.PRECIO_VENTA;
                rwAjusteInventario.SUCURSAL_ID = 0;
                rwAjusteInventario.FOLIO = "";
                rwAjusteInventario.LOTE = 0;
                rwAjusteInventario.CONCEPTO_DET = articulo.NOMBRE1;
                rwAjusteInventario.PARTIDA = (short)(rwAjusteInventario.Table.Rows.Count + 1);

                this.ordenaPartidas();
                this.dsOrdenCompra.AJUSTES_DET.AddAJUSTES_DETRow(rwAjusteInventario);
            }

            this.calculaTotal();
            this.cantidadTextBoxX.Text = "1";
            superGridControl1.Refresh();
        }

        private void ordenaPartidas()
        {
            for (short p = 1; p <= this.dsOrdenCompra.AJUSTES_DET.Rows.Count; p++)
            {
                ((SIFModelo.OrdenCompra.OrdenesCompraDataSet.AJUSTES_DETRow)this.dsOrdenCompra.AJUSTES_DET.Rows[p - 1]).PARTIDA = p;
            }
        }

        private void eliminar()
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija un producto de la list");
                return;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.AJUSTES_DETRow detalle = ((DataRowView)((GridRow)this.superGridControl1.PrimaryGrid.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.AJUSTES_DETRow;

            if (MessageBoxEx.Show("¿Quitar el artículo  " + detalle.ARTICULO_ID + " [ " + detalle.NOMBRE1 + "]?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            this.dsOrdenCompra.AJUSTES_DET.RemoveAJUSTES_DETRow(detalle);
            this.ordenaPartidas();
            this.superGridControl1.Refresh();
        }

        private void guardar()
        {
            if (!valida())
            {
                return;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.AJUSTESRow AjusteInventario = dsOrdenCompra.AJUSTES.NewAJUSTESRow();
            AjusteInventario.ACTIVO = ((char)SIFModelo.Tipos.SiNo.SI).ToString();
            AjusteInventario.CONCEPTO_AJUS = this.conceptoTextBoxX.Text;
            AjusteInventario.DOC_REFERENCIA = this.referenciaTextBoxX.Text;
            AjusteInventario.FECHA_REG = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

            AjusteInventario.LOTE = short.Parse(this.loteTextBoxX.Text);
            SIFModelo.Sucursal sucursal = ((ObjectView<SIFModelo.Sucursal>)this.sucursalComboBoxEx.SelectedItem).Object as SIFModelo.Sucursal;
            AjusteInventario.SUCURSAL_ID = (short)sucursal.SucursalesID;
            AjusteInventario.SUCURSAL_REF = (short)sucursal.SucursalesID;
            AjusteInventario.TIPO_MOV = ((char)((SIFModelo.TipoMovimiento)this.tipoMovimientoComboBoxEx.SelectedItem).Tipo).ToString();
            AjusteInventario.TOTAL = calculaTotal();
            AjusteInventario.USUARIO_ID = UsuarioId.ToString();
            AjusteInventario.USUARIO_AUTORIZA = "";
            AjusteInventario.FOLIO = new SIFNegocio.OrdenCompra.AjusteInventario().FolioAjusteInventario((int)AjusteInventario.SUCURSAL_ID);
            AjusteInventario.TOTAL = this.calculaTotal();
            bool insertado = new SIFNegocio.OrdenCompra.AjusteInventario().InsertaAjuste(AjusteInventario, this.dsOrdenCompra.AJUSTES_DET);

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

            if (string.IsNullOrEmpty(this.conceptoTextBoxX.Text))
            {
               MessageBox.Show("Debe ingresar el concepto de la bonificación");
                this.conceptoTextBoxX.Focus();
                return false;
            }

            var conceptoVacio = from c in dsOrdenCompra.AJUSTES_DET where c.CONCEPTO_DET == "" select c;

            if (conceptoVacio.Count() > 0)
            {
               MessageBox.Show("Debe ingresar los detalles de bonificación");
                return false;
            }

            return true;
        }

        private double calculaTotal()
        {
            var totalv = dsOrdenCompra.AJUSTES_DET.Sum(v => v.CANTIDAD * v.PRECIO_VTA);
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

        private void AjusteInventarioDetallesUserControl_Load(object sender, EventArgs e)
        {
            this.superGridControl1.PrimaryGrid.DataSource = dsOrdenCompra.AJUSTES_DET;
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
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.AJUSTES_DETRow modelo = new SIFModelo.OrdenCompra.OrdenesCompraDataSet().AJUSTES_DET.NewAJUSTES_DETRow();
            string propiedadBusqueda = Helpers.Reflect.GetMember(() => modelo.NOMBRE1).Name;

            if (e.GridCell.GridColumn.DataPropertyName == Helpers.Reflect.GetMember(() => modelo.CANTIDAD).Name)
            {

                modelo = ((DataRowView)(e.GridCell.GridRow.DataItem)).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.AJUSTES_DETRow;
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
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true,true);
            }
        }



    }
}
