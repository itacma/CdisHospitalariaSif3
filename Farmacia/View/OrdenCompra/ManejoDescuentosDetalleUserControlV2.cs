using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.OrdenCompra
{
    public partial class ManejoDescuentosDetalleUserControlV2 : Templates.ListaUserControl
    {

        List<SIFModelo.Ofertas.listaOfertasVentaDet> ListaOfertasDetalles = new List<SIFModelo.Ofertas.listaOfertasVentaDet>();
        SIFModelo.Ofertas.listaOfertasVenta ListaOfertasEncabezado = new SIFModelo.Ofertas.listaOfertasVenta();
        public ManejoDescuentosDetalleUserControlV2()
        {
            InitializeComponent();
        }
        public ManejoDescuentosDetalleUserControlV2(SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow lista)
        {
            InitializeComponent();
            this.InicializaColumnas();
            this.Lista = lista;
           // this.EstableceArticulos();
        }

        public View.OrdenCompra.ManejoDescuentosUserControl Owner;
        SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow Lista;
        private SIFNegocio.OrdenCompra.ManejoDescuentos descuentosL = new SIFNegocio.OrdenCompra.ManejoDescuentos();
        private SIFNegocio.Articulo logica = new SIFNegocio.Articulo();
        private string propiedadBusqueda = "";
        string ultimaBusqueda = "";
        SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow Current;

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
           // this.agregaProductoButtonItem.Shortcuts.Add(eShortcut.F4);
        }

        public void DesactivaComandos()
        {
            //this.agregaProductoButtonItem.Shortcuts.Clear();
        }

        #endregion



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
           // this.AplicaAcomboBoxEx.DataSource = tipos;
            
        }

        private void buscarTextBoxX_KeyUp(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Down && e.KeyCode != Keys.Escape)
            //if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Down && e.KeyCode != Keys.Escape)
             //   this.buscaArticulos();
                //this.buscarTextBoxX.SelectAll();
            
        }
        private void buscaArticulos()
        {
            ultimaBusqueda = buscarTextBoxX.Text;
            string parametroBusqueda = "%" + this.buscarTextBoxX.Text.Replace(' ', '%') + "%";

            //if (string.IsNullOrEmpty(this.propiedadBusqueda))
            //{
            //if (this.buscarTextBoxX.Text.Length > 3)
            //{
            //if (Owner is SIF.View.Ventas.VentaUserControl)
            //{
            //    SIF.View.Ventas.VentaUserControl Padre = Owner as SIF.View.Ventas.VentaUserControl;
            //    if (Padre.ClienteSub == null)
            //        logica.BuscarConInventarioActivo(parametroBusqueda, Helpers.Sesion.Sucursal, propiedadBusqueda);
            //    else
            //        if (Padre.ClienteSub.PRECIO_FIJO == SIFModelo.Tipos.SiNo.SI)
            //        logica.BuscarConInventarioSub(parametroBusqueda, Helpers.Sesion.Sucursal, propiedadBusqueda);
            //    else
            //        logica.BuscarConInventario(parametroBusqueda, Helpers.Sesion.Sucursal, propiedadBusqueda);
            //}
            //else
            //{
                logica.BuscarConInventarioActivo(parametroBusqueda, Helpers.Sesion.Sucursal, propiedadBusqueda);
           // }

            this.dataGridViewX1.DataSource = logica.InventarioDataSet.ARTICULO_INVENTARIO;
        }

        private void buscarTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ultimaBusqueda == buscarTextBoxX.Text)
                {
                    // AgregaArticuloGrid(true);
                    return;
                }
                else {
                    this.buscaArticulos();
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                buscarTextBoxX.Clear();
            }
            if (e.KeyCode == Keys.Down)
            {
                this.dataGridViewX1.Focus();
                return;
            }
        }
        private void AgregaArticuloGrid(bool selected = true)
        {
            //if (selected)
            //{
            //    if (dataGridViewX1.SelectedRows.Count <= 0)
            //    {
            //        MessageBox.Show("¿Debe seleccionar un artículo de la tabla?");
            //        return;
            //    }
            //}
            //else
            //{
            //    if (dataGridViewX1.Rows.Count <= 0)
            //    {
            //        MessageBox.Show("¿Debe seleccionar un artículo de la tabla?");
            //        return;
            //    }
            //}

            //SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow articulo = null;
            //if (selected)
            //{
            //    articulo = ((DataRowView)dataGridViewX1.SelectedRows[0].DataBoundItem).Row as SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow;
            //}
            //else
            //{
            //    articulo = ((DataRowView)dataGridViewX1.Rows[0].DataBoundItem).Row as SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow;
            //}

            //this.CodigoTextBoxX.Text = articulo.ARTICULO_ID;
            //this.AgregaArticulo(articulo.ARTICULO_ID);
            //this.cantidadTextBoxX.Text = "1";
            //this.buscarTextBoxX.SelectAll();
            //this.buscarTextBoxX.Focus();
        }

        private void dataGridViewX1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AgregaArticulo(SelectedArticulo());
        }
        private SIFModelo.Articulo SelectedArticulo()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;

            if (panel.ActiveRow == null)
            {
                return null;
            }

            var container = ((GridContainer)panel.ActiveRow);

            if (container is GridPanel)
            {
                return null;
            }

            var row = (GridRow)container;

            DataRow datarow = ((DataRowView)row.DataItem).Row;
            SIFModelo.Articulo articulo = new SIFModelo.Articulo();
        

            articulo.ARTICULO_ID = datarow[this.CLAVEColumn.Name].ToString();
            articulo.NOMBRE1 = datarow[this.NOMBREColumn.Name].ToString();
            articulo.NOMBRE2 = datarow[this.NOMBRE2Column.Name].ToString();
            articulo.TIPO_MEDICAMENTO_CVE = datarow[this.TIPO_MEDICAMENTOColumn.Name].ToString();


           
            return articulo;
        }

        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            //REVISAR SI YA EXISTE UNA OFERTA CON ESE ARTICULO Y ESTA ACTIVO

            this.Current = null;
            //LIMPIAMOS TODAS LOS DATOS

            //SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow rowOfertas = descuentosL.Detalles.NewLISTA_OFERTAS_VENTA_DETALLEDataTableRow();
            SIFModelo.Ofertas.listaOfertasVentaDet rowOfertasDet = new SIFModelo.Ofertas.listaOfertasVentaDet();
            rowOfertasDet.lista_ofertas_id = 0;
            rowOfertasDet.articulo_id = articulo.ARTICULO_ID;
            rowOfertasDet.partida = 0;
            rowOfertasDet.cantidad = 1;
           // rowOfertasDet.importe_pacto = 0;
            rowOfertasDet.descuento = 1;
            rowOfertasDet.activo = "A";
            rowOfertasDet.importe_beneficio = 1;
            //rowOfertasDet.precio_de_compra = 0;
            rowOfertasDet.nombre1 = articulo.NOMBRE1;
            rowOfertasDet.beneficio_cant = 0;
            rowOfertasDet.aplicado_a = AplicaAcomboBoxEx.SelectedValue.ToString();

            //   descuentosL.Detalles.AddLISTA_OFERTAS_VENTA_DETALLEDataTableRow(rowOfertas);
            // Current = rowOfertas;

            //ListaOfertasEncabezado.LISTA_OFERTAS_ID = this.Lista.LISTA_OFERTAS_ID;
            //ListaOfertasDetalles.ACTIVO = "A";

            //  RecalculaDetalle(rowOfertas);

            //SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow detalleExistente = descuentosL.DescuentoActivo(articulo, Lista);

            //if (detalleExistente != null)
            //{
            //    MessageBox.Show("Ya existe un descuento aplicado para este artículo", "Infromacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (!articulo.TIPO_MEDICAMENTO_CVE.Contains("CD"))
            //{
            //    MessageBox.Show("El articulo No permite aplicar descuento", "Infromacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //  descuentosL.NuevoDetalle(rowOfertas);

            this.superGridControl1.PrimaryGrid.DataSource = descuentosL.Detalles;
            //this.codigoTextBoxX.Text = articulo.ARTICULO_ID;
            //cantidadTextBoxX.Focus();
            this.buscarTextBoxX.SelectAll();

        }

        private void ManejoDescuentosDetalleUserControlV2_Load(object sender, EventArgs e)
        {
           // this.superGridControl1.PrimaryGrid.DataSource = descuentosL.Detalles;
           // this.codigoTextBoxX.Focus();


            Dictionary<string, string> tipos = new Dictionary<string, string>();
            tipos.Add("FLEMING", "F");
            tipos.Add("PMP", "P");
            BindingSource bs = new BindingSource();
            bs.DataSource = tipos;

            this.AplicaAcomboBoxEx.DataSource = bs;
            AplicaAcomboBoxEx.DisplayMember = "Key";
            AplicaAcomboBoxEx.ValueMember = "Value";
        }
    }
}
