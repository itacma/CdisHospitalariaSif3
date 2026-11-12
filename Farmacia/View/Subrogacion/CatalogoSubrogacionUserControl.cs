using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using Excel;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

using Equin.ApplicationFramework;
using SIF.View.Catalogos;
using DevComponents.DotNetBar.SuperGrid;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace SIF.View.Subrogacion
{
    public partial class CatalogoSubrogacionUserControl : Templates.CatalogoUserControl
    {
        //public int SugerenciaID;
        //private DataGridViewTextBoxDropDownColumn Columna;
        //private int ClienteID;
        View.Catalogos.ClienteControl frmCliente;
        private int ClienteID;
        private List<SIFModelo.SubRogacion.CatalogoConvenio> catalogosMes;

        public CatalogoSubrogacionUserControl()
        {
            InitializeComponent();
            CargarCatalogos();
            CargarMeses();
            Privilegios();
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                // Do not change enabled state for the export button here (designer controls it)
                //if (object.ReferenceEquals(Xbtn, this.exportarCatButtonItem))
                //{
                //    // leave enabled state as set in designer
                //    continue;
                //}

                //if (Xbtn.Tag != null & Xbtn.Tag != "")
                //    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 85, int.Parse(Xbtn.Tag.ToString()));

            }
            //dataGridViewX1.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 85, 2);
        }

        public bool Mostrado;
        public MainForm Owner { get; set; }

        private SIFNegocio.Subrogacion.Articulos logica = new SIFNegocio.Subrogacion.Articulos();
        private string propiedadBusqueda = "";
        SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow current;

        #region Navegacion

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            seleccionaClienteButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
        }

        /// <summary>
        /// Activa los acesos cortos mediante el teclado
        /// </summary>
        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
            seleccionaClienteButtonItem.Shortcuts.Clear();
        }
        private SIFNegocio.Articulo LstArticulos = new SIFNegocio.Articulo();
        
                       

        private void seleccionaClienteButtonItem_Click(object sender, EventArgs e)
        {
            SeleccionaCliente();
        }

        private void SeleccionaCliente()
        {


            if (frmCliente == null)
            {
                frmCliente = new View.Catalogos.ClienteControl();
                frmCliente.Dock = DockStyle.Fill;
                frmCliente.Owner = this;
            }
            frmCliente.Muestra();


        }

        void ColClave_ButtonCustomClick(object sender, EventArgs e)
        {
            //Columna = sender as DataGridViewTextBoxDropDownColumn;
            SIF.View.Articulos.ArticuloUserControl FrmArticulos = new Articulos.ArticuloUserControl();
            FrmArticulos.Owner = this;
            FrmArticulos.Muestra();

        }       

        private void Back()
        {
            logica.Update(logica.ArticulosDs);

            if (this.Mostrado && Owner.IsModalPanelDisplayed)
            {
                this.DesactivaComandos();
                Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);

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
                //string filtro = " NOMBRE1 LIKE '%" + buscarTextBoxX.Text.ToUpper() + "%'";
                //filtro += " OR ARTICULO_ID LIKE '%" + buscarTextBoxX.Text.ToUpper() + "%'";
                //filtro += " OR CODIGOCLI  LIKE '%" + buscarTextBoxX.Text.ToUpper() + "%'";
                //this.dataGridViewX1.DataSource = logica.ArticulosDs.CAT_ARTICULOS_SUB.Select(filtro);  //.ApplyFilter(delegate(SIFModelo.QuejasSugTipo.CatQuejaSugSubTipo customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
                //this.bindingSource.DataSource = logica.ArticulosDs.CAT_ARTICULOS_SUB.Select(filtro);
            }
            catch
            {
            }
        }

        #endregion

        //BARRA DE MENU
        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            //this.buscar();
            //
            this.buscarLocal();
        }

        public void AgregarCliente(SIFModelo.Cliente cliente)
        {
            ClienteID = cliente.ID;
            lblCliente.Tag = cliente.ID;
            lblCliente.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
            //buscar();
        }
        
        
        //Refrescar el Grid      
        //this.dataGridViewX1.Refresh();
        //DataGridViewCell celdaEditada;
        //View.Catalogos.ClienteControl frmCliente;

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }        
               
        private void importarCatButtonItem_Click(object sender, EventArgs e)
        {
            //Agregar nuevo formulario para la importanción de catalogos:
            ImportarCatArticulosSub importar = new ImportarCatArticulosSub();
            if (importar.ShowDialog() != DialogResult.OK)
                return;
        }

        private void CargarMeses()
        {
            comboBoxMes.DataSource = new[]
            {
                new { Numero = 0, Nombre = "TODOS" },
                new { Numero = 1, Nombre = "ENERO" },
                new { Numero = 2, Nombre = "FEBRERO" },
                new { Numero = 3, Nombre = "MARZO" },
                new { Numero = 4, Nombre = "ABRIL" },
                new { Numero = 5, Nombre = "MAYO" },
                new { Numero = 6, Nombre = "JUNIO" },
                new { Numero = 7, Nombre = "JULIO" },
                new { Numero = 8, Nombre = "AGOSTO" },
                new { Numero = 9, Nombre = "SEPTIEMBRE" },
                new { Numero = 10, Nombre = "OCTUBRE" },
                new { Numero = 11, Nombre = "NOVIEMBRE" },
                new { Numero = 12, Nombre = "DICIEMBRE" }
            };

            comboBoxMes.DisplayMember = "Nombre";
            comboBoxMes.ValueMember = "Numero";
            comboBoxMes.SelectedIndex = 0;
        }

        private void CargarCatalogos()
        {
            // Llama a la capa de negocio
            catalogosMes = SIFNegocio.Subrogacion.Articulos.GetCatalogosMes();
            MostrarCatalogos(catalogosMes);
        }

        private void MostrarCatalogos(List<SIFModelo.SubRogacion.CatalogoConvenio> lista)
        {
            dataGridView1.ReadOnly = false; // Mantenemos false para permitir el clic en los botones
            dataGridView1.AllowUserToAddRows = false; // Evita la fila en blanco al final para agregar
            dataGridView1.AllowUserToDeleteRows = false; // Deshabilita la tecla Delete/Supr para eliminar filas

            // AutoGenerateColumns en true permite que cree las columnas automáticamente según las propiedades del modelo
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                // Si no es un botón de acción, se marca como ReadOnly
                if (col.Name != "btnExportar" && col.Name != "btnEliminar")
                {
                    col.ReadOnly = true;
                }
            }

            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        
            // Ocultar o mostrar columnas específicas
            //if (dataGridView1.Columns["ClienteId"] != null)
               // dataGridView1.Columns["ClienteId"].Visible = true;

            if (dataGridView1.Columns["Mes"] != null)
                dataGridView1.Columns["Mes"].Visible = false;

            AgregarColumnasAccion();

            if (dataGridView1.Columns["ClienteId"] != null)
                dataGridView1.Columns["ClienteId"].FillWeight = 30;
        }

        private void AgregarColumnasAccion()
        {
            // 1. Columna de Botón EXPORTAR
            if (!dataGridView1.Columns.Contains("btnExportar"))
            {
                DataGridViewButtonColumn colExportar = new DataGridViewButtonColumn();
                colExportar.Name = "btnExportar";
                colExportar.HeaderText = "Acción";
                colExportar.Text = "Exportar";
                colExportar.UseColumnTextForButtonValue = true; // Muestra "Exportar" en cada celda
                colExportar.FillWeight = 60;

                dataGridView1.Columns.Add(colExportar);
            }

            // 2. Columna de Botón ELIMINAR
            if (!dataGridView1.Columns.Contains("btnEliminar"))
            {
                DataGridViewButtonColumn colEliminar = new DataGridViewButtonColumn();
                colEliminar.Name = "btnEliminar";
                colEliminar.HeaderText = "Acción";
                colEliminar.Text = "Eliminar";
                colEliminar.UseColumnTextForButtonValue = true; // Muestra "Eliminar" en cada celda
                colEliminar.FillWeight = 60;

                dataGridView1.Columns.Add(colEliminar);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegurar que no se haga clic en los encabezados de columna (e.RowIndex < 0)
            if (e.RowIndex < 0) return;

            // Obtener el objeto del modelo correspondiente a la fila seleccionada
            var itemSeleccionado = (SIFModelo.SubRogacion.CatalogoConvenio)dataGridView1.Rows[e.RowIndex].DataBoundItem;

            // --- ACCIÓN: EXPORTAR ---
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnExportar")
            {
                ExportarRegistro(itemSeleccionado);
            }

            // --- ACCIÓN: ELIMINAR ---
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                DialogResult dialog = MessageBox.Show(
                    $"¿Está seguro de eliminar el convenio del cliente '{itemSeleccionado.Nombre_cliente}' para el mes '{itemSeleccionado.Mes_texto}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    EliminarRegistro(itemSeleccionado);
                }
            }
        }

        private void ExportarRegistro(SIFModelo.SubRogacion.CatalogoConvenio item)
        {
            MessageBox.Show($"Exportando información del cliente {item.Nombre_cliente}...", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Aquí implementas tu lógica de exportación (Excel, PDF, etc.)
        }

        private void EliminarRegistro(SIFModelo.SubRogacion.CatalogoConvenio item)
        {
            // Aquí ejecutas la llamada a tu Capa de Negocio/Datos para eliminar en BD
            // bool exito = SIFNegocio.Subrogacion.Articulos.EliminarConvenio(item.ClienteId, item.Mes);

            MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Recargar la lista para refrescar el grid
            //CargarCatalogos();
        }

        private void clienteBox_SelectedIndexChanged(object sender, EventArgs e)
        {          
            int clienteId;

            if (!int.TryParse(lblCliente.ToString(),out clienteId))
            {
                return;
            }

            if (clienteId == 0)
            {
                MostrarCatalogos(catalogosMes);
                return;
            }

            List<SIFModelo.SubRogacion.CatalogoConvenio> filtrados =
                catalogosMes
                    .Where(x => x.ClienteId == clienteId)
                    .ToList();

            MostrarCatalogos(filtrados);
        }
    }
}
