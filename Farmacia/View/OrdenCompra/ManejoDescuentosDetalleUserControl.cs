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

namespace SIF.View.OrdenCompra
{
    public partial class ManejoDescuentosDetalleUserControl : Templates.ListaUserControl
    {
        public ManejoDescuentosDetalleUserControl(SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow lista)
        {
            InitializeComponent();
            this.InicializaColumnas();
            this.Lista = lista;
            this.EstableceArticulos();
        }

        public ManejoDescuentosDetalleUserControl()
        {
            InitializeComponent();
            this.InicializaColumnas();

        }

        private void Cancelar()
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Debe seleccionar un artículo a cancelar");
                return;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow detalle = ((DataRowView)((GridRow)superGridControl1.PrimaryGrid.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow;

            if (MessageBoxEx.Show("¿Desea cancelar el detalle " + detalle.ARTICULO_ID + " [" + detalle.NOMBRE1 + "]?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            detalle.ACTIVO = "N";
            descuentosL.ModificarDetalle(detalle);

        }

        public View.OrdenCompra.ManejoDescuentosUserControl Owner;
        SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow Lista;
        private SIFNegocio.OrdenCompra.ManejoDescuentos descuentosL = new SIFNegocio.OrdenCompra.ManejoDescuentos();

        #region Navegacion
        public bool Mostrado = false;
        public void Muestra()
        {
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;

            Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }

        public void Back()
        {
            Owner.ActivaComandos();
            this.DesactivaComandos();
            this.Mostrado = false;

            if (Owner.Owner.Owner.Contains(this))
            {
                Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            }
            this.RecalculaOferta(this.Lista);
        }


        public void RecalculaOferta(SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow row)
        {
            var vtotalOFerta = this.descuentosL.Detalles.Compute("SUM(importe_beneficio)", "");

            decimal totalOferta = 0;

            if (vtotalOFerta.ToString().IsFloat())
            {
                totalOferta = decimal.Parse(vtotalOFerta.ToString());
            }

            Lista.TOTAL = totalOferta;

            descuentosL.Modificar(Lista);
        }

        public void ActivaComandos()
        {
            this.agregaProductoButtonItem.Shortcuts.Add(eShortcut.F4);
        }

        public void DesactivaComandos()
        {
            this.agregaProductoButtonItem.Shortcuts.Clear();
        }

        #endregion

        #region Funciones y Metodos

        private void EstableceArticulos()
        {
            this.superGridControl1.PrimaryGrid.DataSource = descuentosL.CargaDetalles(Lista);
            //this.superGridControl1.PrimaryGrid.DataMember = "LISTA_OFERTAS_VENTA_DETALLEDataTable";
        }

        private void InicializaColumnas()
        {
            var col2 = this.superGridControl1.PrimaryGrid.Columns["APLICADO_A_Column"];
            GridComboBoxExEditControl APLICADO_A_Column = this.superGridControl1.PrimaryGrid.Columns["APLICADO_AColumn"].EditControl as GridComboBoxExEditControl;

            Dictionary<string, string> tipos = new Dictionary<string, string>();
            tipos.Add("FLEMING", "F");
            tipos.Add("COSTO", "C");
            BindingSource bs = new BindingSource();
            bs.DataSource = tipos;
            APLICADO_A_Column.DataSource = bs;
            APLICADO_A_Column.DisplayMember = "Key";
            APLICADO_A_Column.ValueMember = "VALUE";
        }

        private bool ValidaOferta(SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow oferta)
        {
            if (oferta.FECHA_BAJA < oferta.FECHA_ALTA)
            {
               MessageBox.Show("La fecha de baja no puede ser menor a la fecha de alta");
                return false;
            }

            return true;
        }

        private void AgregaArticulo()
        {
            View.Articulos.ArticuloUserControl frmArticulo;

            frmArticulo = new View.Articulos.ArticuloUserControl();
            frmArticulo.Dock = DockStyle.Fill;
            frmArticulo.Owner = this;
            frmArticulo.Muestra();
        }

        SIFModelo.OrdenCompra.OrdenesCompraDataSet ocDS = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();
        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            //REVISAR SI YA EXISTE UNA OFERTA CON ESE ARTICULO Y ESTA ACTIVO

            this.Current = null;
            //LIMPIAMOS TODAS LOS DATOS

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow rowOfertas = descuentosL.Detalles.NewLISTA_OFERTAS_VENTA_DETALLEDataTableRow();
            rowOfertas.LISTA_OFERTAS_ID = 0;
            rowOfertas.ARTICULO_ID = articulo.ARTICULO_ID;
            rowOfertas.PARTIDA = 0;
            rowOfertas.CANTIDAD = 1;
            rowOfertas.IMPORTE_PACTO = 0;
            rowOfertas.DESCUENTO = cantidadTextBoxX.Value;
            rowOfertas.ACTIVO = "A";
            rowOfertas.IMPORTE_BENEFICIO = 1;
            rowOfertas.IMPORTE_PACTO = 0;
            rowOfertas.PRECIO_DE_COMPRA = 0;
            rowOfertas.NOMBRE1 = articulo.NOMBRE1;
            rowOfertas.BENEFICIO_CANT = 0;
            rowOfertas.APLICADO_A = tipoComboBoxEx.SelectedValue.ToString();

            descuentosL.Detalles.AddLISTA_OFERTAS_VENTA_DETALLEDataTableRow(rowOfertas);
            // Current = rowOfertas;

            rowOfertas.LISTA_OFERTAS_ID = this.Lista.LISTA_OFERTAS_ID;
            rowOfertas.ACTIVO = "A";

            RecalculaDetalle(rowOfertas);

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow detalleExistente = descuentosL.DescuentoActivo(articulo, Lista);

            if (detalleExistente != null)
            {
               MessageBox.Show("Ya existe un descuento aplicado para este artículo");
                return;
            }

            descuentosL.NuevoDetalle(rowOfertas);

            this.superGridControl1.PrimaryGrid.DataSource = descuentosL.Detalles;
            this.codigoTextBoxX.Text = articulo.ARTICULO_ID;
            cantidadTextBoxX.Focus();

        }



        private void RecalculaDetalle(SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow rowOfertas)
        {
            SIFModelo.Articulo articulo = new SIFModelo.Articulo { ARTICULO_ID = rowOfertas.ARTICULO_ID };
            SIFModelo.Inventarios.ListaPrecios precio = SIFNegocio.Articulo.PrecioArticulo(articulo);

            if (precio != null)
            {
                rowOfertas.PRECIO_DE_COMPRA = (double)precio.COSTO_ULT_COMPRA;

                if (rowOfertas.APLICADO_A == "P")
                {
                    rowOfertas.IMPORTE_BENEFICIO = (double)(rowOfertas.CANTIDAD * (precio.PRECIO_VENTA_MAX * ((decimal)rowOfertas.DESCUENTO / 100m)));
                }

                if (rowOfertas.APLICADO_A == "F")
                {
                    rowOfertas.IMPORTE_BENEFICIO = (double)(rowOfertas.CANTIDAD * (precio.PRECIO_VENTA * ((decimal)rowOfertas.DESCUENTO / 100m)));
                }

                rowOfertas.PRECIO_FARMACIA = precio.PRECIO_VENTA_FARM;
                rowOfertas.PMP = precio.PRECIO_VENTA_MAX;
            }
        }

        public void AgregaArticulo(string ArticuloID)
        {
            SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(ArticuloID);

            if (articulo == null)
            {
               MessageBox.Show("El artículo no fue encontrado en el catálogo");
                return;
            }

            this.AgregaArticulo(articulo);
        }

        public void Aplicar()
        {
            foreach (var oferta in this.ocDS.LISTA_OFERTAS_VENTA)
            {
                oferta.ACTIVO = "S";
                descuentosL.Nuevo(oferta, false);
            }
           MessageBox.Show("Las ofertas han sido guardadas y aplicadas");
            this.Back();
        }

        public void Guardar()
        {
            //if (this.Lista == null)
            //{
            //   MessageBox.Show("");
            //    ////preguntar por las fechas de alta y de baja

            //    //Lista = new SIFModelo.OrdenCompra.OrdenesCompraDataSet().LISTA_OFERTAS_VENTA.NewLISTA_OFERTAS_VENTARow();
            //    //Lista.ACTIVO = "S";
            //    ////Lista.FECHA_ALTA
            //}

            foreach (var oferta in this.ocDS.LISTA_OFERTAS_VENTA_DETALLEDataTable)
            {
                oferta.LISTA_OFERTAS_ID = this.Lista.LISTA_OFERTAS_ID;
                oferta.ACTIVO = "A";
                descuentosL.NuevoDetalle(oferta);
            }

           MessageBox.Show("Se han creado las ofertas para aplicarlas después");
            this.Back();
        }
        #endregion

        private void agregaProductoButtonItem_Click(object sender, EventArgs e)
        {
            this.AgregaArticulo();
        }

        private void ManejoDescuentosDetalleUserControl_Load(object sender, EventArgs e)
        {
            this.superGridControl1.PrimaryGrid.DataSource = descuentosL.Detalles;
            this.codigoTextBoxX.Focus();


            Dictionary<string, string> tipos = new Dictionary<string, string>();
            tipos.Add("FLEMING", "F");
            tipos.Add("PMP", "P");
            BindingSource bs = new BindingSource();
            bs.DataSource = tipos;

            this.tipoComboBoxEx.DataSource = bs;
            tipoComboBoxEx.DisplayMember = "Key";
            tipoComboBoxEx.ValueMember = "Value";
        }

        private void codigoTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.AgregaArticulo();
        }

        SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow Current;

        private void aplicarButtonItem_Click(object sender, EventArgs e)
        {
            this.Aplicar();
        }

        private void guardarButtonItem_Click(object sender, EventArgs e)
        {
            this.Guardar();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
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
                AgregaArticulo(codigoTextBoxX.Text);
            }
        }

        private void superGridControl1_EndEdit(object sender, GridEditEventArgs e)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow row = (SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow)((DataRowView)e.GridCell.GridRow.DataItem).Row;
            this.RecalculaDetalle(row);
            descuentosL.ModificarDetalle(row);
        }

        private void descuentoNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            foreach (var articulo in descuentosL.Detalles)
            {
                articulo.DESCUENTO = (float)descuentoNumericUpDown.Value;
                RecalculaDetalle(articulo);
            }
        }

        private void cancelarButtonItem_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void codigoTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaArticulo(this.codigoTextBoxX.Text);
            }
        }

        private void AplicaDescuentoGeneral()
        {
            foreach (var row in descuentosL.Detalles)
            {
                row.DESCUENTO = this.descuentoNumericUpDown.Value;
                RecalculaDetalle(row);
            }
        }

        private void descuentoNumericUpDown_ValueChanged_1(object sender, EventArgs e)
        {
            this.AplicaDescuentoGeneral();
        }

    }
}
