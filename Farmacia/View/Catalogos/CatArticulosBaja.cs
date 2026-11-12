using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using Equin.ApplicationFramework;

namespace SIF.View.Catalogos
{
    public partial class CatArticulosBaja : Form
    {
        private SIFNegocio.Articulo logica = new SIFNegocio.Articulo();
        private string propiedadBusqueda = "";
        public CatArticulosBaja()
        {
            InitializeComponent();
        }
        string parametroBusqueda="";
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
             parametroBusqueda = this.textBoxXBuscar.Text.Replace(" ", "");

            if (string.IsNullOrEmpty(parametroBusqueda))
            {
                //if (this.buscarTextBoxX.Text.Length > 3)
                //{
                
                  //  logica.BuscarConInventarioActivo("" + parametroBusqueda + "", Helpers.Sesion.Sucursal, propiedadBusqueda);
                logica.buscarFil("", parametroBusqueda);
                
                //}
            }
            else
            {
                logica.buscarFil("", parametroBusqueda);
                   // logica.BuscarConInventarioActivo("" + parametroBusqueda + "", Helpers.Sesion.Sucursal, propiedadBusqueda);
                
            }

        }
        private void eliminarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }
        private bool Eliminar()
        {
            int registros = dataGridViewX1.SelectedRows.Count;
            if (registros <= 0 && dataGridViewX1.CurrentRow == null)
            {
               MessageBox.Show("Seleccione el Producto a Activar");
                return false;
            }
            if(registros>1)
            {
               MessageBox.Show("Solo se permite Activar un prodcuto a la vez");
                return false;
            }
            SIFNegocio.Articulo art = new SIFNegocio.Articulo();
            //if (registros > 1)
            //{
            //    DialogResult res =MessageBox.Show("¿Eliminar " + registros + " registros?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //    if (res == DialogResult.No)
            //    {
            //        return false;
            //    }

            //    foreach (DataGridViewRow registro in dataGridViewX1.SelectedRows)
            //    {
            //        SIFModelo.Articulo articulo = ((ObjectView<SIFModelo.Articulo>)registro.DataBoundItem).Object as SIFModelo.Articulo;


            //        if (articulo.ACTIVO == SIFModelo.Tipos.SiNo.NO)
            //        {
            //            continue;
            //        }

            //        articulo.ACTIVO = SIFModelo.Tipos.SiNo.NO;

            //        if (!logica.Modificar(articulo))
            //        {
            //           MessageBox.Show("No se eliminó el registro " + articulo.NOMBRE1);

            //        }

            //    }
            //}
            SIFModelo.ArticuloBaja articulo = ((ObjectView<SIFModelo.ArticuloBaja>)dataGridViewX1.CurrentRow.DataBoundItem).Object as SIFModelo.ArticuloBaja;
            
            if (articulo.ACTIVO == SIFModelo.Tipos.SiNo.NO)
            {
                DialogResult res =MessageBox.Show("¿Activar el elemento seleccionado?", "Activar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (res == DialogResult.Yes)
                {
                    articulo.ACTIVO = SIFModelo.Tipos.SiNo.SI;

                    SIFModelo.Articulo artB = art.BuscarPorClave(articulo.ARTICULO_ID);
                    artB.ACTIVO = SIFModelo.Tipos.SiNo.SI;
                    if (!logica.Modificar(artB))
                    {
                       MessageBox.Show("El elemento no pudo ser activado " + articulo.NOMBRE1);

                    }
                }
            }
            else
            {



                if (articulo.ACTIVO == SIFModelo.Tipos.SiNo.NO)
                {
                   MessageBox.Show("El articulo ya ha sido desactivado anteriormente");
                    return false;
                }

                DialogResult res =MessageBox.Show("¿Eliminar el registro " + articulo.NOMBRE1 + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    return false;
                }

                articulo.ACTIVO = SIFModelo.Tipos.SiNo.NO;

                SIFModelo.Articulo artB = art.BuscarPorClave(articulo.ARTICULO_ID);
                artB.ACTIVO = SIFModelo.Tipos.SiNo.SI;
                if (!logica.Modificar(artB))
                {
                   MessageBox.Show("No se eliminó el registro " + articulo.NOMBRE1);

                }
            }
            dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            logica.buscarFil("", "");
            this.bindingSource.DataSource = logica.ListaArticuloBaja;
            this.dataGridViewX1.DataSource = bindingSource;
            dataGridViewX1.Refresh();

            return true;
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //logica.buscarV();
            logica.buscarFil("", parametroBusqueda);
            this.bindingSource.DataSource = logica.ListaArticuloBaja;
            this.dataGridViewX1.DataSource = bindingSource;
            this.dataGridViewX1.Cursor = Cursors.Default;
            this.Cursor = Cursors.Default;
            //this.statusLabel.Text = "";
        }

        private void buscarTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.textBoxXBuscar.Clear();
            this.buscarLocal();
        }
        private void buscarTextBoxX_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.textBoxXBuscar.Clear();
                return;
            }
            if (e.KeyData == Keys.F5)
            {
               // this.seleccionaArticulo();
                return;
            }
            if (e.KeyData == Keys.Down)
            {
                this.dataGridViewX1.Focus();
                return;
            }
            this.Buscar();
        }

        private void buscarLocal()
        {
            this.Buscar();

            if (string.IsNullOrEmpty(propiedadBusqueda))
            {
                SIFModelo.Articulo articulo = new SIFModelo.Articulo();
                propiedadBusqueda = Helpers.Reflect.GetMember(() => articulo.NOMBRE1).Name;
            }

            try
            {
                logica.ListaArticulos.ApplyFilter(delegate(SIFModelo.Articulo customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(textBoxXBuscar.Text.ToUpper()); });
            }
            catch
            {
            }
        }
        private void CatArticulosUserControl_Load(object sender, EventArgs e)
        {
            logica.buscarV();
            this.bindingSource.DataSource = this.logica.ListaArticuloBaja;
            this.dataGridViewX1.DataSource = bindingSource;
            this.textBoxXBuscar.Focus();
        }
        private void Buscar()
        {
           // this.statusLabel.Text = "Buscando elementos...";
            dataGridViewX1.Cursor = Cursors.WaitCursor;


            //if (this.logica.ListaArticulos.Count == 0 || this.buscarTextBoxX.Text.Length <= 1)
            //{
            if (!backgroundWorker.IsBusy)
            {
                this.backgroundWorker.RunWorkerAsync();
            }
            //}

            //if (this.buscarTextBoxX.Text.Length > 1)
            //{
            //    this.buscarLocal();
            //    this.dataGridViewX1.Cursor = Cursors.Default;
            //    return;
            //}


        }
    }
}
