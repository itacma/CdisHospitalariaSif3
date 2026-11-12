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
namespace SIF.View.Ventas
{
    public partial class ControlCajasUserControl : Templates.CatalogoUserControl
    {
        public ControlCajasUserControl()
        {
            InitializeComponent();
        }

        public bool Mostrado;
        public Menu.Ventas.CajaUserControl Owner;

        private SIFNegocio.Cajas logica = new SIFNegocio.Cajas();
        private string propiedadBusqueda = "";
        SIFModelo.Caja current;

        #region Navegacion

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            CerrarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
        }

        /// <summary>
        /// Activa los acesos cortos mediante el teclado
        /// </summary>
        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
            CerrarButtonItem.Shortcuts.Clear();
        }

        private void Back()
        {
            if (this.Mostrado && Owner.Owner.Owner.IsModalPanelDisplayed)
            {
                this.DesactivaComandos();
                if (Owner.Owner.Owner.Contains(this))
                {
                    Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }
                this.Owner.ActivaComandos();
                this.Owner.Owner.ActivaComandos();
                this.Mostrado = false;
            }
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
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;

            Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.Mostrado = true;
        }


        #endregion

        #region Funciones y Metodos Privados

        private void ControlCaja()
        {

            SIFModelo.Caja modelo = ((ObjectView<SIFModelo.Caja>)dataGridViewX1.CurrentRow.DataBoundItem).Object as SIFModelo.Caja;

            if (modelo == null)
            {
               MessageBox.Show("Seleccione una caja");
                return;
            }


            CorteCajaUserControl frmControl = new CorteCajaUserControl(modelo);
            frmControl.Owner = this;
            frmControl.Muestra();
        }

        private void Buscar()
        {
            this.dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            this.statusLabel.Text = "Buscando elementos...";
            dataGridViewX1.Cursor = Cursors.WaitCursor;
            if (!buscarBackgroundWorker.IsBusy)
            {
                this.buscarBackgroundWorker.RunWorkerAsync();
            }
        }

        private Boolean Modificar()
        {


            SIFModelo.Caja Caja = new SIFModelo.Caja();

            int registros = dataGridViewX1.SelectedRows.Count;
            if (registros <= 0 && dataGridViewX1.CurrentRow == null)
            {
               MessageBox.Show("Seleccione la caja a cerrar");
                return false;
            }

            SIFModelo.Caja modelo = ((ObjectView<SIFModelo.Caja>)dataGridViewX1.CurrentRow.DataBoundItem).Object as SIFModelo.Caja;

            if (modelo.Abierto == SIFModelo.Tipos.AbiertoCerrado.CERRADO)
            {
               MessageBox.Show("La caja ya fue cerrada, necesita volver a abrirla para realizar cambios", "Cerrar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (MessageBoxEx.Show("¿Cerrar la caja " + modelo.Nombre + "?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return false;
            }

            this.RecoleccionValores(true);

            //MOSTRAMOS LA CANTIDAD DE MONEDAS
            //ControlCajaMonedasForm fromMonedas = new ControlCajaMonedasForm(modelo);
            //if (fromMonedas.ShowDialog() != DialogResult.OK)
            //{
            //    return false;
            //}



            this.Cursor = Cursors.WaitCursor;
            this.statusLabel.Text = "Actualizando registro...";

            bool modificado = logica.ModificarControlCaja(modelo);
            if (!modificado)
            {
                if (dataGridViewX1.IsCurrentCellInEditMode)
                {
                    dataGridViewX1.CancelEdit();
                }
                dataGridViewX1.Refresh();
            }

            //dataGridViewX1.Rows.Remove(dataGridViewX1.CurrentRow);

            this.Cursor = Cursors.Default;

            this.statusLabel.Text = "";

           MessageBox.Show("La caja se ha cerrado correctamente");

            return modificado;
        }

        private bool RecoleccionValores(bool esCerrar = false)
        {
            SIFModelo.Caja Caja = new SIFModelo.Caja();

            int registros = dataGridViewX1.SelectedRows.Count;
            if (registros <= 0 && dataGridViewX1.CurrentRow == null)
            {
               MessageBox.Show("Seleccione la caja a cerrar");
                return false;
            }

            SIFModelo.Caja modelo = ((ObjectView<SIFModelo.Caja>)dataGridViewX1.CurrentRow.DataBoundItem).Object as SIFModelo.Caja;
            if (modelo.Abierto == SIFModelo.Tipos.AbiertoCerrado.CERRADO)
            {
                var res =MessageBox.Show("La caja ya fue cerrada, ¿Desea volver a ingresar recolección de valores?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (res == DialogResult.No)
                {
                    return false;
                }
            }

            if (modelo.FechaCierre == null)
            {
                modelo.FechaCierre = new DateTime(modelo.FechaApertura.Year, modelo.FechaApertura.Month, modelo.FechaApertura.Day, 23, 59, 59);
            }


            if ((SIFNegocio.Configuracion.Configuraciones.fechaServidor() - modelo.FechaCierre.Value).TotalHours > 72)
            {
               MessageBox.Show("No puede realizar recolecciones con fecha de cierre es mayor a 72 hrs.");
                return false;
            }

            //RecoleccionValoresUserControl frmMonedas = new RecoleccionValoresUserControl(modelo);
            //frmMonedas.Owner = this;

            //AccesoUsuarioForm frmAcceso = new AccesoUsuarioForm();
            //if (frmAcceso.ShowDialog() != DialogResult.OK)
            //{
            //    return false;
            //}
           
            Ventas.ControlCajaMonedasForm frmControl = new ControlCajaMonedasForm(modelo, Helpers.Sesion.Usuario, esCerrar);
            frmControl.ShowDialog();

            return true;
        }

        private void buscarLocal()
        {
            if (string.IsNullOrEmpty(propiedadBusqueda))
            {
                propiedadBusqueda = new SIFModelo.Caja().GetType().GetProperties()[0].Name;
            }

            try
            {
                logica.CatCajasList.ApplyFilter(delegate(SIFModelo.Caja customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
            }
            catch
            {
            }
        }
        #endregion

        //BARRA DE MENU
        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }


        private void modificarButtonItem_Click(object sender, EventArgs e)
        {
            this.current = this.bindingSource.Current as SIFModelo.Caja;
        }

        private void CatCajasUserControl_Load(object sender, EventArgs e)
        {
            this.fechaInicioDateTimeInput.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, 1, 0, 0, 0);
            this.fechaTerminoDateTimeInput.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, DateTime.DaysInMonth(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month), 23, 59, 59);
            this.buscarTextBoxX.Focus();
            this.Buscar();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void dataGridViewX1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DevComponents.DotNetBar.Controls.DataGridViewX grid = sender as DevComponents.DotNetBar.Controls.DataGridViewX;
            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];
            this.buscarTextBoxX.WatermarkText = "BUSCAR POR " + columna.HeaderText;
            this.propiedadBusqueda = columna.DataPropertyName;
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
            logica.ControlBuscar(Helpers.Sesion.Sucursal, fechaInicioDateTimeInput.Value, fechaTerminoDateTimeInput.Value);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.bindingSource.DataSource = logica.CatCajasList;
            this.dataGridViewX1.DataSource = bindingSource;
            this.dataGridViewX1.Cursor = Cursors.Default;
        }


        private void buscarTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Clear();
            this.buscarLocal();
        }

        private void CerrarButtonItem_Click(object sender, EventArgs e)
        {
            this.Modificar();
        }

        private void recoleccionButtonItem_Click(object sender, EventArgs e)
        {
            this.RecoleccionValores();
        }

        private void bar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void controlCajaButtonItem_Click(object sender, EventArgs e)
        {
            this.ControlCaja();
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



    }
}
