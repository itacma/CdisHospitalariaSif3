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
using System.IO;
using System.Text.RegularExpressions;

namespace SIF.View.Catalogos
{
    public partial class CatalogoDescuentosUserControl : Templates.CatalogoUserControl
    {
        public CatalogoDescuentosUserControl()
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
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 57, int.Parse(Xbtn.Tag.ToString()));

            }
            dataGridViewX1.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 57, 2);
        }

        public bool Mostrado;
        public Menu.ConfiguracionMenu Owner;

        private SIFNegocio.Descuentos logica = new SIFNegocio.Descuentos();
        private string propiedadBusqueda = "";
        SIFModelo.Descuento current;

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
        private void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
            NuevoButtonItem.Shortcuts.Clear();
            eliminarButtonItem.Shortcuts.Clear();
        }

        private void Back()
        {
            try
            {
                if (this.Mostrado && Owner.Owner.IsModalPanelDisplayed)
                {
                    this.DesactivaComandos();
                    if (Owner.Owner.Contains(this))
                    {
                        Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Owner.ActivaComandos();
                    this.Owner.Owner.ActivaComandos();
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
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;

            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.Mostrado = true;
        }


        #endregion

        #region Funciones y Metodos Privados

        private void InicializaColumnas()
        {
            //BUSQUEDA LOCAL
            SIFModelo.Descuento modelo = new SIFModelo.Descuento();
            this.propiedadBusqueda = Helpers.Reflect.GetMember(() => modelo.Nombre).Name;
            //
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

        private bool Nuevo()
        {
            this.dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);

            this.current = ((ObjectView<SIFModelo.Descuento>)this.bindingSource.AddNew()).Object as SIFModelo.Descuento;
            this.current.Nombre = "NOMBRE";
            this.current.Porcentaje = 0;
            this.current.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            this.current.Activo = SIFModelo.Tipos.SiNo.SI;


            if (this.logica.Nuevo(current).ID == 0)
            {
                MessageBox.Show("Ha ocurrido un error al agregar el Descuento, verifique que su información sea correcta");
                logica.CatDescuentosList.CancelNew(logica.CatDescuentosList.Count - 1);

                dataGridViewX1.CancelEdit();
                dataGridViewX1.Refresh();
                return false;
            }
            else
            {
                this.dataGridViewX1.BeginEdit(true);
                return true;
            }
        }

        private bool Eliminar()
        {
            int registros = dataGridViewX1.SelectedRows.Count;
            if (registros <= 0 && dataGridViewX1.CurrentRow == null)
            {
               MessageBox.Show("Seleccione el registro a eliminar");
                return false;
            }

            //if (registros > 1)
            //{
            //    DialogResult res =MessageBox.Show("¿Eliminar " + registros + " registros?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (res == DialogResult.No)
            //    {
            //        return false;
            //    }

            //    foreach (DataGridViewRow registro in dataGridViewX1.SelectedRows)
            //    {
            //        SIFModelo.Descuento descuento = ((ObjectView<SIFModelo.Descuento>)registro.DataBoundItem).Object as SIFModelo.Descuento;
            //        if (descuento.Activo == SIFModelo.Tipos.SiNo.NO)
            //        {
            //            continue;
            //        }

            //        descuento.Activo = SIFModelo.Tipos.SiNo.NO;
            //        descuento.FechaBaja = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

            //        if (!logica.Modificar(descuento))
            //        {
            //           MessageBox.Show("No se eliminó el registro " + descuento.Nombre);
            //        }

            //    }
            //}


            //else
            //{
            SIFModelo.Descuento descuento = ((ObjectView<SIFModelo.Descuento>)dataGridViewX1.CurrentRow.DataBoundItem).Object as SIFModelo.Descuento;

            if (descuento.Activo == SIFModelo.Tipos.SiNo.NO)
            {
               MessageBox.Show("El descuento ya ha sido desactivado anteriormente");
                return false;
            }

            DialogResult res =MessageBox.Show("¿Eliminar el registro " + descuento.Nombre + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return false;
            }


            descuento.Activo = SIFModelo.Tipos.SiNo.NO;
            descuento.FechaBaja = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

            if (!logica.Modificar(descuento))
            {
               MessageBox.Show("No se eliminó el registro " + descuento.Nombre);
            }
            //}

            dataGridViewX1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dataGridViewX1.Refresh();

            return true;
        }

        private void importarLayout(int descuentoId)
        {                        
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Seleccionar archivo CSV para importar";
            openFileDialog.Filter = "Archivos CSV (*.csv)|*.csv"; 
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            openFileDialog.Multiselect = false; // No permitir seleccionar múltiples archivos
            bool FmtValid = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataTable dtPedido = new DataTable();
                dtPedido.Columns.Add("nombre", typeof(string));        
                dtPedido.Columns.Add("no_empleado", typeof(string));  
                dtPedido.Columns.Add("fecha_nacimiento", typeof(DateTime));
                dtPedido.Columns.Add("fecha_fin", typeof(DateTime));
                
                StreamReader reader = StreamReader.Null;
                string FName = openFileDialog.SafeFileName;
                string FPath = Path.GetDirectoryName(openFileDialog.FileName);

                try
                {
                    reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
                    string str;
                    List<string> listaNoEmpleadosEnArchivo = new List<string>();

                    while ((str = reader.ReadLine()) != null)
                    {
                        str = str.Trim();
                        string[] columns = str.Split(',');
                        if (columns.Length != 4)
                        {
                            FmtValid = false;
                           MessageBox.Show("El formato de Archivo " + FName + " es Invalido. Debe contener cuatro columnas: nombre, no_empleado, fecha_nacimiento, Vigencia");
                            break;
                        }
                        string nombre = columns[0].Trim();  // Eliminar espacios en blanco de los valores
                        string no_empleado = columns[1].Trim();
                        string fecha_nacimiento_str = columns[2].Trim();
                        string fecha_fin_str = columns[3].Trim();
                        if (!Regex.IsMatch(no_empleado, @"^[a-zA-Z0-9]+$"))
                        {
                            FmtValid = false;
                            MessageBox.Show("El número de empleado " + no_empleado + " no es válido.");
                            break;
                        }
                        if (!DateTime.TryParse(fecha_nacimiento_str, out DateTime fecha_nacimiento))
                        {
                            FmtValid = false;
                            MessageBox.Show("La fecha de nacimiento " + fecha_nacimiento_str + " no es válida.");
                            break;
                        }
                        if (!DateTime.TryParse(fecha_fin_str, out DateTime fecha_fin))
                        {
                            FmtValid = false;
                            MessageBox.Show("La fecha de nacimiento " + fecha_fin_str + " no es válida.");
                            break;
                        }
                        listaNoEmpleadosEnArchivo.Add(no_empleado); // Agregar el no_empleado a la lista para verificar después
                        dtPedido.Rows.Add(nombre, no_empleado, fecha_nacimiento, fecha_fin_str);//tabla temporal para recorrer todas las lineas
                    }
                    if (FmtValid)
                    {
                        SIFNegocio.Descuentos artNg = new SIFNegocio.Descuentos();
                        List<string> empleadosExistentes = new List<string>();

                        // Verificar si los empleados ya existen en base de datos
                        foreach (DataRow row in dtPedido.Rows)
                        {
                            string no_empleado = row["no_empleado"].ToString();
                            bool esActivo = artNg.VerificarExistenciaEmpleado(no_empleado);

                            if (esActivo)
                            {
                                empleadosExistentes.Add(no_empleado);
                            }
                        }
                                                
                        // Si existen empleados duplicados, no detener la importación, solo actualizar la fecha
                        if (empleadosExistentes.Count > 0)
                        {
                            foreach (string noEmpleado in empleadosExistentes)
                            {
                                try
                                {
                                    // Aquí se actualiza solo la fecha de actualización para los empleados existentes
                                    artNg.ActualizarFechaEmpleado(noEmpleado);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error al actualizar la fecha del empleado {noEmpleado}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }

                        int Regs = 0;                        
                        foreach (DataRow row in dtPedido.Rows)
                        {
                            int DescuentoId = descuentoId;
                            string nombre = row["nombre"].ToString();
                            string no_empleado = row["no_empleado"].ToString();
                            DateTime fecha_nacimiento = (DateTime)row["fecha_nacimiento"];
                            DateTime fechaAlta = DateTime.Now;
                            DateTime fechaInicio = DateTime.Now;
                            DateTime fechaFin = (DateTime)row["fecha_fin"];
                            int ultUsuarioId = Helpers.Sesion.Usuario.UsuariosID; ; 
                            string activo = "S";
                        
                        try
                        {
                           artNg.InsertarOActualizarEmpleadoMAPFRE(new SIFModelo.Descuento
                           {
                               DescuentoId = DescuentoId,
                               Nombre = nombre,
                               NoEmpleado = no_empleado,
                               FechaNacimiento = fecha_nacimiento,
                               FechaAlta = fechaAlta,
                               FechaInicio = fechaInicio,
                               FechaFin = fechaFin,
                               UltUsuarioId = ultUsuarioId,
                               ActivoMapfre = "S"
                           });
                           Regs++;
                        }
                        catch (Exception EX2)
                        {
                            MessageBox.Show(EX2.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }                        
                        if (listaNoEmpleadosEnArchivo.Count > 0)
                        {
                            try
                            {
                                artNg.DesactivarEmpleadosMAPFRE(listaNoEmpleadosEnArchivo);
                            }
                            catch (Exception ex)
                            {
                                //MessageBox.Show("Error al desactivar empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hay empleados para desactivar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        MessageBox.Show("Se procesaron " + Regs + " registros correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (OverflowException ex)
                {
                    MessageBox.Show("Error de desbordamiento al insertar empleado: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }
            else
            {
                MessageBox.Show("No se seleccionó ningún archivo.");
            }
        }             
                
        private Boolean Modificar(SIFModelo.Descuento Descuento)
        {
            this.Cursor = Cursors.WaitCursor;
            this.statusLabel.Text = "Actualizando registro...";

            bool modificado = logica.Modificar(Descuento);

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
            return modificado;
        }

        private void buscarLocal()
        {
            if (string.IsNullOrEmpty(propiedadBusqueda))
            {
                propiedadBusqueda = new SIFModelo.Descuento().GetType().GetProperties()[0].Name;
            }

            try
            {
                logica.CatDescuentosList.ApplyFilter(delegate(SIFModelo.Descuento customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
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

        private void modificarButtonItem_Click(object sender, EventArgs e)
        {
            this.current = this.bindingSource.Current as SIFModelo.Descuento;
        }

        private void eliminarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        private void importarLayoutButtonItem_Click(object sender, EventArgs e)
        {
            this.importarLayout(12);            
        }

        private void importar3016ButtonItem_Click(object sender, EventArgs e)
        {
            this.importarLayout(13);
        }

        private void CatDescuentoUserControl_Load(object sender, EventArgs e)
        {
            this.importarLayoutButtonItem.Enabled = true;
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
            SIFModelo.Descuento Descuento = ((ObjectView<SIFModelo.Descuento>)grid.CurrentRow.DataBoundItem).Object as SIFModelo.Descuento;

            //SI ES MODIFICADO
            if (Descuento.ID != 0)
            {
                this.Modificar(Descuento);
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
            SIFModelo.Descuento Descuento = ((ObjectView<SIFModelo.Descuento>)grid.CurrentRow.DataBoundItem).Object as SIFModelo.Descuento;

            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];

            //RECUPERA EL NOMBRE DE LA PROPIEDAD Y LA COMPARA CON LA PROPIEDA DESEADA
            if (columna.DataPropertyName == Helpers.Reflect.GetMember(() => Descuento.Nombre).Name)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue as string) || e.FormattedValue as string == "NOMBRE" || string.IsNullOrEmpty(e.FormattedValue as string))
                {
                   MessageBox.Show("El nombre es obligatorio, verifique la información");
                    e.Cancel = true;
                    return;
                }
                if ((e.FormattedValue as string).Length > 100)
                {
                   MessageBox.Show("El nombre es muy largo, verifique la información");
                }
            }
            if (columna.DataPropertyName == Helpers.Reflect.GetMember(() => Descuento.Porcentaje).Name)
            {
                if ((e.FormattedValue as string).IsFloatPositive())
                {
                    decimal comision = System.Convert.ToDecimal(e.FormattedValue);
                    if (comision > 100 || comision < 0)
                    {
                       MessageBox.Show("El valor no está dentro del rango válido, verifique la información");
                        e.Cancel = true;
                        return;
                    }
                }
                else
                {
                   MessageBox.Show("Ingrese un número válido dentro del rango, verifique la información");
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void dataGridViewX1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.Eliminar();
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
            logica.Buscar("", "");
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.bindingSource.DataSource = logica.CatDescuentosList;
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
            }
            celdaEditada = null;

        }

        private void buscarTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Clear();
            this.buscarLocal();
        }


        private void dataGridViewX1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewX grid = sender as DataGridViewX;
            if (grid.IsCurrentCellInEditMode)
            {
                return;
            }
            DataGridViewRow row = grid.Rows[e.RowIndex];
            row.ReadOnly = false;
            if (row != null)
            {
                SIFModelo.Descuento modelo = ((ObjectView<SIFModelo.Descuento>)row.DataBoundItem).Object as SIFModelo.Descuento;

                //los permisos para modificar son activos
                if (false)
                {
                    if (modelo == this.current)
                    {
                        row.ReadOnly = false;
                        return;
                    }
                    row.ReadOnly = true;
                    return;
                }

                if (modelo.Activo == SIFModelo.Tipos.SiNo.NO)
                {
                    row.ReadOnly = true;
                    return;
                }
                else
                {
                    List<DataGridViewCell> celdas = new List<DataGridViewCell>();
                    foreach (DataGridViewCell celda in row.Cells)
                    {
                        if (celda.ReadOnly)
                        {
                            celdas.Add(celda);
                        }
                    }

                    row.ReadOnly = false;

                    foreach (DataGridViewCell celda in celdas)
                    {
                        celda.ReadOnly = true;
                    }
                }
            }
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
