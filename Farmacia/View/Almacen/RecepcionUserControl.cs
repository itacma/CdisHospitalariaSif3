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

using Equin.ApplicationFramework;
using SIF.View.Catalogos;
using DevComponents.DotNetBar.SuperGrid;
namespace SIF.View.Almacen
{
    public partial class RecepcionUserControl : Templates.CatalogoUserControl
    {
        public int SugerenciaID;
        private DataGridViewTextBoxDropDownColumn Columna;
        public RecepcionUserControl()
        {
            InitializeComponent();
            this.InicializaColumnas();

            Privilegios();
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 39, int.Parse(Xbtn.Tag.ToString()));

            }
            dataGridViewX1.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 39, 2);
        }

        public bool Mostrado;
        public MainForm Owner { get; set; }

        private SIFNegocio.Almacen.Bultos logica = new SIFNegocio.Almacen.Bultos();
        private string propiedadBusqueda = "";
        SIFModelo.Inventarios.InventarioDataSet.BULTOSRow current;

        #region Navegacion

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            NuevoButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            eliminarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
        }

        /// <summary>
        /// Activa los acesos cortos mediante el teclado
        /// </summary>
        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
            NuevoButtonItem.Shortcuts.Clear();
            eliminarButtonItem.Shortcuts.Clear();
        }
        private SIFNegocio.Articulo LstArticulos = new SIFNegocio.Articulo();
        private void InicializaColumnas()
        {

            logica.AjustesDataSet = logica.Get(logica.AjustesDataSet);
            bindingSource.DataSource = logica.AjustesDataSet.BULTOS;
            DataGridViewTextBoxDropDownColumn ColOrden = dataGridViewX1.Columns["FOLIOID"] as DataGridViewTextBoxDropDownColumn;
            ColOrden.ButtonCustomClick += new EventHandler<EventArgs>(ColOrden_ButtonCustomClick);

        }

        void ColOrden_ButtonCustomClick(object sender, EventArgs e)
        {

            Columna = sender as DataGridViewTextBoxDropDownColumn;
            SIF.View.Almacen.ConsultaOrdenesCompraUserControl OrdenCompra = new ConsultaOrdenesCompraUserControl();
            OrdenCompra.Owner = this;
            OrdenCompra.Muestra();

        }


        public void AgregaOrdenCompra(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow ordenCompra)
        {
            //agregamos la orden de compra al renglon
            if (Columna != null)
            {
                SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(int.Parse(ordenCompra.USUARIO_ID));

                dataGridViewX1[Columna.Index, dataGridViewX1.CurrentRow.Index].Value = ordenCompra.FOLIO_OC_ID;
                dataGridViewX1[Columna.Index + 1, dataGridViewX1.CurrentRow.Index].Value = ordenCompra.PROVEEDOR_ID;
                dataGridViewX1[Columna.Index + 2, dataGridViewX1.CurrentRow.Index].Value = ordenCompra.CAT_CLIENTES_NOMBRE;
                dataGridViewX1[Columna.Index + 3, dataGridViewX1.CurrentRow.Index].Value = ordenCompra.FECHA_ALTA;
                dataGridViewX1[Columna.Index + 4, dataGridViewX1.CurrentRow.Index].Value = usuario.Nombre;
                dataGridViewX1[Columna.Index + 5, dataGridViewX1.CurrentRow.Index].Value = ordenCompra.ESTADO_OC.Trim();
                dataGridViewX1[Columna.Index + 6, dataGridViewX1.CurrentRow.Index].Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                dataGridViewX1[Columna.Index + 12, dataGridViewX1.CurrentRow.Index].Value = Helpers.Sesion.Usuario.UsuariosID;
                dataGridViewX1[Columna.Index + 13, dataGridViewX1.CurrentRow.Index].Value = Helpers.Sesion.Sucursal.SucursalID;

            }
        }


        private void Back()
        {
            try
            {
                logica.Update(logica.AjustesDataSet);

                if (this.Mostrado && Owner.IsModalPanelDisplayed)
                {
                    this.DesactivaComandos();
                    Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);

                    this.Mostrado = false;
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
            if (Mostrado)
            {
                return;
            }
            Mostrado = true;
            this.Dock = DockStyle.Fill;
            this.ActivaComandos();
            Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);

        }


        #endregion

        #region Funciones y Metodos Privados





        private void buscarLocal()
        {
            if (string.IsNullOrEmpty(propiedadBusqueda))
            {
                // propiedadBusqueda = new SIFModelo.QuejasSugTipo.CatQuejasSug().GetType().GetProperties()[0].Name;
            }

            try
            {
                // logica.CatQuejasSugList.ApplyFilter(delegate(SIFModelo.QuejasSugTipo.CatQuejaSugSubTipo customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
            }
            catch
            {
            }
        }

        #endregion

        //BARRA DE MENU
        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.buscarLocal();
        }

        private void NuevoButtonItem_Click(object sender, EventArgs e)
        {
            this.Nuevo();
        }

        private void Nuevo()
        {
            bindingSource.AddNew();


        }

        private void modificarButtonItem_Click(object sender, EventArgs e)
        {
            this.current = this.bindingSource.Current as SIFModelo.Inventarios.InventarioDataSet.BULTOSRow;
        }

        private void eliminarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        private void Eliminar()
        {
            bindingSource.RemoveCurrent();
            logica.Update(logica.AjustesDataSet);
        }


        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        DataGridViewCell celdaEditada;
        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

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
            switch (e.ColumnIndex)
            {
                case 1:
                    // bucamos el nombre del articulo
                    break;
                case 3:
                    //buscamos el nombre del articulo
                    break;
            }
        }

        private void dataGridViewX1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                //  this.Eliminar();
            }
            if (e.KeyCode == Keys.F4)
            {
                this.buscarTextBoxX.SelectAll();
                this.buscarTextBoxX.Focus();
            }
        }

        private void buscarTextBoxX_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.buscarButtonX.PerformClick();
            }
            if (e.KeyData == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
            }
            this.buscarLocal();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //logica.Buscar("", "",SugerenciaID);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.bindingSource.DataSource = logica.AjustesDataSet.BULTOS;
            this.dataGridViewX1.Cursor = Cursors.Default;
        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            if (MouseButtons != 0) return;

            DevComponents.DotNetBar.Controls.DataGridViewX grid = sender as DevComponents.DotNetBar.Controls.DataGridViewX;
            if (celdaEditada != null && grid.CurrentCell != null)
            {
                // if we are currently in the next line of last edit cell 
                if (grid.CurrentCell.RowIndex == celdaEditada.RowIndex + 1 &&
                     grid.CurrentCell.ColumnIndex == celdaEditada.ColumnIndex)
                {
                    int iColNew;
                    int iRowNew = 0;
                    if (celdaEditada.ColumnIndex >= grid.ColumnCount - 1)
                    {
                        iColNew = 0;
                        iRowNew = grid.CurrentCell.RowIndex;
                    }
                    else
                    {
                        iColNew = celdaEditada.ColumnIndex + 1;
                        iRowNew = celdaEditada.RowIndex;
                    }
                    grid.CurrentCell = grid[iColNew, iRowNew];
                }
                // grid.BeginEdit(true);
            }
            celdaEditada = null;

        }

        private void dataGridViewX1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Owner is MedicosUserControl)
            {
                if (bindingSource.Current != null)
                {
                    SIFModelo.QuejasSugTipo.CatQuejasSug QuejaSug = ((ObjectView<SIFModelo.QuejasSugTipo.CatQuejasSug>)bindingSource.Current).Object as SIFModelo.QuejasSugTipo.CatQuejasSug;


                    this.Back();
                }
            }
        }

        private void buscarTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Clear();
            this.buscarLocal();
        }

        private void dataGridViewX1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                DataObject d = dataGridViewX1.GetClipboardContent();
                if (d == null) { return; }
                Clipboard.SetDataObject(d);
            }
        }

        private void dataGridViewX1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            logica.Update(logica.AjustesDataSet);

        }


        public EventHandler<EventArgs> ColClave_ButtonCustomClick { get; set; }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Recepcion_bultos.rpt", "");
            Impresion.ShowDialog();
        }
    }
}
