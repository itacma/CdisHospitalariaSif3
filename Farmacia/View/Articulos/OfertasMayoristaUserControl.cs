using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using Equin.ApplicationFramework;

namespace SIF.View.Articulos
{
    public partial class OfertasMayoristaUserControl : Templates.CatalogoUserControl
    {
        public OfertasMayoristaUserControl()
        {
            InitializeComponent();
            this.dataGridViewX1.AutoGenerateColumns = false;
        }

        public bool Mostrado;
        public View.Menu.ComprasMenu Owner;

        private SIFNegocio.OfertasCompras logica = new SIFNegocio.OfertasCompras();
        private string propiedadBusqueda = "";
        SIFModelo.Catalogo.CatalogoDataSet.OFERTAS_COMPRAS_MAYORISTARow current;

        #region Navegacion

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            //NuevoButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            //eliminarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
        }

        /// <summary>
        /// Activa los acesos cortos mediante el teclado
        /// </summary>
        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
            //NuevoButtonItem.Shortcuts.Clear();
            //eliminarButtonItem.Shortcuts.Clear();
        }

        private void Back()
        {
            try
            {
                if (Owner is View.Menu.ComprasMenu)
                {
                    View.Menu.ComprasMenu propietario = Owner as View.Menu.ComprasMenu;
                    propietario.ActivaComandos();
                    this.DesactivaComandos();
                    //this.Dock = DockStyle.Fill;

                    if (propietario.Owner.Contains(this))
                    {
                        propietario.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        this.Mostrado = false;
                    }
                }
            }
            catch { }
        }

        private void Salir()
        {
            DialogResult res = MessageBox.Show("¿Desea salir del catálogo?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Back();
            }
        }

        public void Muestra()
        {

            if (Owner is View.Menu.ComprasMenu)
            {
                View.Menu.ComprasMenu propietario = Owner as View.Menu.ComprasMenu;
                propietario.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                propietario.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            }
            this.Mostrado = true;

            this.propiedadBusqueda = string.Empty;
            this.buscarTextBoxX.Focus();
        }

        #endregion

        #region Funciones y Metodos Privados

        private void AplicaDescuentoEspecialGeneral()
        {
            DescuentoEspecialProveedorForm frmDescuento = new DescuentoEspecialProveedorForm();
            if (frmDescuento.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            foreach (DataGridViewRow row in this.dataGridViewX1.Rows)
            {
                SIFModelo.Catalogo.CatalogoDataSet.OFERTAS_COMPRAS_MAYORISTARow cm = row.DataBoundItem as SIFModelo.Catalogo.CatalogoDataSet.OFERTAS_COMPRAS_MAYORISTARow;
                cm.DESCTO_ESPECIAL_PROVEE = frmDescuento.descuento;
                this.Modificar(cm);
            }
        }

        internal void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            if (articulo == null)
            {
                return;
            }

            //AGREGAMOS EL ARTÍCULO A LA LISTA DE PRECIOS

            //SIFModelo.Catalogo.CatalogoDataSet.OFERTAS_COMPRAS_MAYORISTARow oferta = logica.OfertasMayoritsta.NewOFERTAS_COMPRAS_MAYORISTARow();
            //oferta.ARTICULO_ID = articulo.ARTICULO_ID;
            //oferta.CANTIDAD_ACOMPRAR = 1;
            //oferta.CODIGO_PROVEEDOR = articulo.CODIGO_CLI;
            //oferta.DESCRIP_DESCTO = "";
            //oferta.DESCTO_ADICIONAL_PROVEE = "";
            //oferta.DESCTO_ESPECIAL_PROVEE = "";
            //oferta.DESCTO_OFRECIDO = "0";
            //oferta.ESCALA = 0;
            //oferta.ESTADO_ART_FLEMING = 

        }

        private void SeleccionaArticulo()
        {
            View.Articulos.ArticuloUserControl frmArticulo = new Articulos.ArticuloUserControl();

            frmArticulo.Dock = DockStyle.Fill;
            frmArticulo.Owner = this;

            frmArticulo.Muestra();
        }

        private void Buscar()
        {
            this.statusLabel.Text = "Buscando elementos...";
            dataGridViewX1.Cursor = Cursors.WaitCursor;


            if (this.logica.OfertasMayoritsta == null || (this.logica.OfertasMayoritsta.Count == 0 || this.buscarTextBoxX.Text.Length <= 1))
            {
                if (!buscarBackgroundWorker.IsBusy)
                {
                    this.buscarBackgroundWorker.RunWorkerAsync();
                }
            }
            else
            {
                this.buscarLocal();
                this.dataGridViewX1.Cursor = Cursors.Default;
                return;
            }
        }

        private Boolean Modificar(SIFModelo.Catalogo.CatalogoDataSet.OFERTAS_COMPRAS_MAYORISTARow Articulo)
        {
            this.Cursor = Cursors.WaitCursor;
            this.statusLabel.Text = "Actualizando registro...";

            bool modificado = logica.Modificar(Articulo);

            if (!modificado)
            {
                if (dataGridViewX1.IsCurrentCellInEditMode)
                {
                    dataGridViewX1.CancelEdit();
                }
                dataGridViewX1.Refresh();
            }

            this.Cursor = Cursors.Default;

            this.statusLabel.Text = "";
            return true;
            //return modificado;
        }

        private void buscarLocal()
        {
            //this.Buscar();

            dataGridViewX1.DataSource = logica.OfertasMayoritsta.Select("ARTICULO_ID LIKE '%" + buscarTextBoxX.Text + "%' OR NOMBRE1 LIKE '%" + buscarTextBoxX.Text + "%'");

        }



        #endregion

        //BARRA DE MENU
        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }


        private void modificarButtonItem_Click(object sender, EventArgs e)
        {
            this.current = this.bindingSource.Current as SIFModelo.Catalogo.CatalogoDataSet.OFERTAS_COMPRAS_MAYORISTARow; // as SIFModelo.Articulo;
        }

        private void CatArticulosUserControl_Load(object sender, EventArgs e)
        {
            this.bindingSource.DataSource = this.logica.OfertasMayoritsta;
            this.dataGridViewX1.DataSource = bindingSource;
            this.buscarTextBoxX.Focus();
            this.Buscar();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        DataGridViewCell celdaEditada;
        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //VALIDAR LA COLUMNA Y EL VALOR
            DataGridViewX grid = sender as DataGridViewX;
            SIFModelo.Catalogo.CatalogoDataSet.OFERTAS_COMPRAS_MAYORISTARow Articulo = ((SIFModelo.Catalogo.CatalogoDataSet.OFERTAS_COMPRAS_MAYORISTARow)((DataRowView)grid.CurrentRow.DataBoundItem).Row);

            //SI ES MODIFICADO
            if (!string.IsNullOrEmpty(Articulo.ARTICULO_ID))
            {
                this.Modificar(Articulo);
            }

            celdaEditada = grid[e.ColumnIndex, e.RowIndex];

        }

        private void dataGridViewX1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DevComponents.DotNetBar.Controls.DataGridViewX grid = sender as DevComponents.DotNetBar.Controls.DataGridViewX;
            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];
            this.buscarTextBoxX.WatermarkText = "BUSCAR POR " + columna.HeaderText;
            this.propiedadBusqueda = columna.DataPropertyName;
        }

        private void dataGridViewX1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //VALIDAR LA COLUMNA Y EL VALOR
            DevComponents.DotNetBar.Controls.DataGridViewX grid = sender as DevComponents.DotNetBar.Controls.DataGridViewX;
            //SIFModelo.Articulo Articulo = grid.CurrentRow.DataBoundItem as SIFModelo.Articulo;

            //DataGridViewColumn columna = grid.Columns[e.ColumnIndex];

            ////RECUPERA EL NOMBRE DE LA PROPIEDAD Y LA COMPARA CON LA PROPIEDA DESEADA
            //if (columna.DataPropertyName == Helpers.Reflect.GetMember(() => Articulo.NOMBRE1).Name)
            //{
            //    if (string.IsNullOrWhiteSpace(e.FormattedValue as string) || e.FormattedValue as string == "NOMBRE" || string.IsNullOrEmpty(e.FormattedValue as string))
            //    {
            //       MessageBox.Show("El nombre es obligatorio, verifique la información");
            //        e.Cancel = true;
            //        return;
            //    }
            //    if ((e.FormattedValue as string).Length > 100)
            //    {
            //       MessageBox.Show("El nombre es muy largo, verifique la información");
            //    }
            //}

        }

        private void dataGridViewX1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F4)
            {
                this.buscarTextBoxX.SelectAll();
                this.buscarTextBoxX.Focus();
            }
        }

        private void buscarTextBoxX_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
                return;
            }

            this.Buscar();
        }

        public bool soloActivos = false;

        public SIFModelo.Cliente proveedor = new SIFModelo.Cliente();

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string parametroBusqueda = "%" + this.buscarTextBoxX.Text + "%";

            logica.Buscar(parametroBusqueda, Helpers.Sesion.Sucursal, proveedor, propiedadBusqueda);

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            this.dataGridViewX1.DataSource = logica.OfertasMayoritsta;
            this.dataGridViewX1.Cursor = Cursors.Default;
            this.Cursor = Cursors.Default;
            this.buscarTextBoxX.Focus();
        }

        private void buscarTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Clear();
            this.buscarLocal();
        }

        private void descuentoCredencialButtonItem_Click(object sender, EventArgs e)
        {
            this.AplicaDescuentoEspecialGeneral();
        }



        private void agregaProductoButtonItem_Click(object sender, EventArgs e)
        {
            this.SeleccionaArticulo();
        }


    }
}
