using SIFModelo;
using SIFModelo.Catalogo;
using SIFModelo.Marketing;
using SIFModelo.Tipos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SIF.View.Catalogos
{
    public partial class ImportarCatArticulosSub : DevComponents.DotNetBar.Metro.MetroForm
    {
        //SIFNegocio.Clientes negocio = new SIFNegocio.Clientes();
       //SIFModelo.Cliente cliente = ClienteConvenio.clienteBox.SelectedItem;

        public int ClienteID, institucionId;

        // Parsed file data (populated by buscarArchivoI)
        private List<string> parsedClaves = new List<string>();
        private List<decimal> parsedPrecios = new List<decimal>();
        private List<string> parsedIsss = new List<string>();
        private List<string> parsedTipo = new List<string>();
        private List<string> parsedClavesGob = new List<string>();
        private string parsedFileName = string.Empty;
        private bool parsedFileLoaded = false;
        private SIFNegocio.Subrogacion.Articulos logica = new SIFNegocio.Subrogacion.Articulos();
        public ImportarCatArticulosSub()
        {
            InitializeComponent();
            this.cargaClientesConvenio();
            this.Load += Form1_Load;

        }

        public void aceptarButtonX_Click(object sender, EventArgs e)
        {
            //DateTime fechaInicioDt = this.fechaInicioDateTimeInput.Value.Date; // 00:00:00
            //DateTime fechaTerminoDateTimeInput = this.fechaTerminoDateTimeInput.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59); // 23:59:59

            if (!parsedFileLoaded)
            {
                MessageBox.Show("Debe seleccionar y validar un archivo antes de aceptar.");
                return;
            }
            
            SIFNegocio.Subrogacion.Articulos artNg = new SIFNegocio.Subrogacion.Articulos();
            string usuarioId = Helpers.Sesion.Usuario.UsuariosID.ToString();

            try
            {
                string resultado = string.Empty;

                if (ClienteID == 3012)
                {
                    resultado = artNg.sp_insCatalogoSubImp3012(
                        ClienteID,
                        usuarioId.ToString(),
                        parsedClaves.ToArray(),
                        parsedClavesGob.ToArray(),
                        parsedIsss.ToArray(),
                        parsedPrecios.ToArray(),
                        parsedTipo.ToArray(),
                        //fechaInicio,
                        //fechaFin,
                        "N"
                    );
                }
                else
                {
                    int? instId = (institucionId > 0) ? (int?)institucionId : null;
                    resultado = artNg.insertaCatalogoImp(
                        ClienteID,                        
                        parsedClaves.ToArray(),
                        parsedPrecios.ToArray(),
                        //fechaInicio,
                        //fechaFin,
                        parsedFileName,//nombre archivo
                        usuarioId,//usuario
                        instId//,
                       
                    );
                }
                this.Cursor = Cursors.Default;
                MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset parsed state
                parsedFileLoaded = false;
                parsedFileName = string.Empty;
                parsedClaves.Clear();
                parsedPrecios.Clear();
                parsedIsss.Clear();
                parsedTipo.Clear();
                parsedClavesGob.Clear();
                //if (this.ArchivoLabel != null)
                //    this.ArchivoLabel.Text = string.Empty;

                // limpiar cliente
                ClienteID = 0;
                if (this.clienteBox != null)
                {
                    this.clienteBox.SelectedIndex = -1;
                    this.clienteBox.Text = string.Empty;
                }

                // limpiar institución
                institucionId = 0;
                if (this.institucionBox != null)
                {
                    this.institucionBox.SelectedIndex = -1;
                    this.institucionBox.DataSource = null;
                    this.institucionBox.Visible = false;
                    this.label4.Visible = false;
                }

                // dejar fechas vacías (usar DateTime.MinValue como indicador)
                //if (this.fechaInicioDateTimeInput != null)
                //    this.fechaInicioDateTimeInput.Value = DateTime.MinValue;
                /*if (this.fechaTerminoDateTimeInput != null)
                    this.fechaTerminoDateTimeInput.Value = DateTime.MinValue;*/
                //return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //// Confirmación
            //string agregar = (DialogResult.Yes == MessageBox.Show(
            //    "¿Desea conservar el catálogo cargado en sistema?", "Pregunta",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question)) ? "S" : "N";

            //// ======================================
            //// INSERTAR
            //// ======================================
            //string fechaInicio = fechaInicioDateTimeInput.Value.ToString("dd/MM/yyyy HH:mm:ss");
            //string fechaFin = fechaTerminoDateTimeInput.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("dd/MM/yyyy HH:mm:ss");

            //SIFNegocio.Subrogacion.Articulos artNg = new SIFNegocio.Subrogacion.Articulos();

            //if (ClienteID == 3012)
            //{
            //    string resultado =
            //        artNg.sp_insCatalogoSubImp3012(
            //            ClienteID,
            //            Helpers.Sesion.Usuario.UsuariosID.ToString(),
            //            claves.ToArray(),
            //            clavesGob.ToArray(),
            //            isss.ToArray(),
            //            precios.ToArray(),
            //            tipo.ToArray(),
            //            fechaInicio,
            //            fechaFin,
            //            agregar
            //        );

            //    MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //}
            //else
            //{
            //    string resultado = artNg.insertaCatalogoImp(
            //            ClienteID,
            //            Helpers.Sesion.Usuario.UsuariosID.ToString(),
            //            claves.ToArray(),
            //            precios.ToArray(),
            //            fechaInicio,
            //            fechaFin,
            //            institucionId,
            //            agregar);

            //    MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
                        
        }

        private void CancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void clienteBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (clienteBox.SelectedItem is SIFModelo.Cliente clienteSeleccionado)
            {
                if (clienteSeleccionado.ID == 3014)
                {
                    SIFNegocio.Clientes ins = new SIFNegocio.Clientes();
                    List<SIFModelo.Catalogo.Institucion> listaInstituciones = ins.BuscaInstituciones(clienteSeleccionado);

                    institucionBox.DataSource = null;
                    institucionBox.DataSource = listaInstituciones;
                    institucionBox.DisplayMember = "Nombre";
                    institucionBox.ValueMember = "institucion_id";

                    institucionBox.Visible = true;
                    label4.Visible = true;
                }
                else
                {
                    institucionBox.Visible = false;
                    label4.Visible = false;
                    institucionBox.DataSource = null;
                }
            }
        }

        private void institucionBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cargaClientesConvenio()
        {
            BindingSource src = new BindingSource();
            src.DataSource = new SIFNegocio.Clientes().BuscaClientesLista("");
            this.clienteBox.DataSource = src;

            clienteBox.DisplayMember = "NOMBRE";
            clienteBox.ValueMember = "ID";
        }
        
        private void refreshButtonX_Click(object sender, EventArgs e)
        {
            if (clienteBox.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un cliente antes de eliminar su catálogo.", "Eliminar catálogo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clienteId = Convert.ToInt32(clienteBox.SelectedValue);

            var resp = MessageBox.Show("¿Desea eliminar todo el catálogo del cliente seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != DialogResult.Yes)
                return;

            try
            {
                int? instId = (institucionBox.SelectedValue != null) ? (int?)Convert.ToInt32(institucionBox.SelectedValue) : null;
                string userId = Helpers.Sesion.Usuario.UsuariosID.ToString();
                
                string deleted = SIFNegocio.Subrogacion.Articulos.Delete(clienteId.ToString(), userId, instId);
                if (deleted == "0")
                {
                    MessageBox.Show("El cliente no tiene un catálogo.", "Eliminar catálogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                   MessageBox.Show(string.Format("Catálogo eliminado correctamente. Registros eliminados: {0}", deleted), "Eliminar catálogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Limpiar estado del formulario
                parsedFileLoaded = false;
                parsedFileName = string.Empty;
                parsedClaves.Clear();
                parsedPrecios.Clear();
                parsedIsss.Clear();
                parsedTipo.Clear();
                parsedClavesGob.Clear();
                //if (this.ArchivoLabel != null)
                //    this.ArchivoLabel.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el catálogo: " + ex.Message, "Eliminar catálogo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            //xfm
            if (clienteBox.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un cliente antes de eliminar su catálogo.", "Eliminar catálogo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clienteId = Convert.ToInt32(clienteBox.SelectedValue);

            var resp = MessageBox.Show("¿Desea eliminar todo el catálogo del cliente seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != DialogResult.Yes)
                return;

            try
            {
                int? instId = (institucionBox.SelectedValue != null) ? (int?)Convert.ToInt32(institucionBox.SelectedValue) : null;
                string userId = Helpers.Sesion.Usuario.UsuariosID.ToString();

                //string _delete = SIFNegocio.Subrogacion.Articulos.Delete(clienteId.ToString());

                string deleted = SIFNegocio.Subrogacion.Articulos.Delete(clienteId.ToString(), userId, instId);


                if (deleted == "0 Registros eliminados correctamente")
                {
                    MessageBox.Show("El cliente no tiene un catálogo.", "Eliminar catálogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(string.Format("Catálogo eliminado correctamente. Registros eliminados: {0}", deleted), "Eliminar catálogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Limpiar estado del formulario
                parsedFileLoaded = false;
                parsedFileName = string.Empty;
                parsedClaves.Clear();
                parsedPrecios.Clear();
                parsedIsss.Clear();
                parsedTipo.Clear();
                parsedClavesGob.Clear();
                //if (this.ArchivoLabel != null)
                //    this.ArchivoLabel.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el catálogo: " + ex.Message, "Eliminar catálogo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            this.buscarArchivoI();
        }        
        private void buscarArchivoI()
        {
            // 1. Obtener y validar el ID del cliente seleccionado en el ComboBox
            if (clienteBox.SelectedValue == null || !int.TryParse(clienteBox.SelectedValue.ToString(), out int clienteId))
            {
                MessageBox.Show("Por favor, seleccione un cliente válido antes de continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int columnasEsperadas = (clienteId == 3012) ? 5 : 2;

            // 2. Mostrar mensaje explicativo con la estructura esperada según el cliente
            string mensajeEstructura = (clienteId == 3012)
                ? "El cliente seleccionado requiere un archivo CSV de 5 columnas con el siguiente orden:\n\n" +
                  "1. Articulo\n2. Precio\n3. ClaveGob\n4. Clave_Isstep\n5. Tipo Medicamento"
                : "El cliente seleccionado requiere un archivo CSV de 2 columnas con el siguiente orden:\n\n" +
                  "1. Articulo\n2. Precio";

            MessageBox.Show(mensajeEstructura, "Estructura del Archivo Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 3. Configurar y abrir el diálogo de selección de archivos
            OpenFileDialog fdlg = new OpenFileDialog
            {
                Title = "Seleccione el archivo CSV a Procesar",
                Filter = "Archivos CSV (*.csv)|*.csv",
                RestoreDirectory = true
            };

            if (fdlg.ShowDialog() != DialogResult.OK)
                return;

            string FName = fdlg.SafeFileName;
            string FPath = Path.GetDirectoryName(fdlg.FileName);

            try
            {
                bool FmtValid = true;

                var claves = new List<string>();
                var precios = new List<decimal>();
                var isss = new List<string>();
                var tipo = new List<string>();
                var clavesGob = new List<string>();

                using (var reader = new StreamReader(
                    Path.Combine(FPath, FName),
                    Encoding.GetEncoding("iso-8859-1")))
                {
                    string str;
                    bool anyLine = false;
                    int numeroLinea = 0;

                    while ((str = reader.ReadLine()) != null)
                    {
                        numeroLinea++;

                        // Omitir líneas vacías o espacios
                        if (String.IsNullOrWhiteSpace(str))
                            continue;

                        anyLine = true;
                        string[] parts = str.Split(',');

                        // Validar número de columnas por cada fila
                        if (parts.Length != columnasEsperadas)
                        {
                            MessageBox.Show(
                                $"Error en la línea {numeroLinea}:\n" +
                                $"El archivo '{FName}' tiene un formato inválido.\n" +
                                $"Se esperaban {columnasEsperadas} columnas pero se encontraron {parts.Length}.",
                                "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            FmtValid = false;
                            break;
                        }

                        string codigo = parts[0].Trim();

                        // Validar conversión a decimal del Precio
                        if (!Decimal.TryParse(parts[1].Trim(), out decimal precio))
                        {
                            MessageBox.Show(
                                $"Error en la línea {numeroLinea}:\n" +
                                $"El precio '{parts[1]}' no es un valor numérico válido.",
                                "Precio Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            FmtValid = false;
                            break;
                        }

                        // Validar que el precio sea estrictamente mayor a 0
                        if (precio <= 0)
                        {
                            MessageBox.Show(
                                $"Error en la línea {numeroLinea}:\n" +
                                $"El precio debe ser un monto mayor a 0. Valor encontrado: {precio}",
                                "Precio Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            FmtValid = false;
                            break;
                        }

                        // Guardar los datos según el cliente
                        if (clienteId == 3012)
                        {
                            claves.Add(codigo);
                            precios.Add(precio);
                            clavesGob.Add(parts[2].Trim());
                            isss.Add(parts[3].Trim());
                            tipo.Add(parts[4].Trim());
                        }
                        else
                        {
                            claves.Add(codigo);
                            precios.Add(precio);
                        }
                    }

                    // Validar si el archivo no contenía registros útiles
                    if (!anyLine)
                    {
                        MessageBox.Show("El archivo seleccionado está vacío.", "Archivo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Si ocurrió algún fallo en la iteración, detenemos el flujo
                if (!FmtValid)
                    return;

                // Asignación de variables procesadas
                parsedClaves = claves;
                parsedPrecios = precios;
                parsedIsss = isss;
                parsedTipo = tipo;
                parsedClavesGob = clavesGob;
                parsedFileName = fdlg.FileName;
                parsedFileLoaded = true;

                MessageBox.Show("Archivo validado correctamente.\nSe procederá con la carga del catálogo...", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (this.directorioTextBoxX != null)
                {
                    // Asignamos fdlg.FileName para mostrar toda la ruta (ej. C:\Usuarios\Documentos\archivo.csv)
                    this.directorioTextBoxX.Text = fdlg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al leer el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Agregar los nombres de los meses
            //for (int i = 1; i <= 12; i++)
            //{
            //    comboBoxMes.Items.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i));
            //}
            int mesActual = DateTime.Now.Month; // 1-12

            for (int i = 0; i < 6; i++)
            {
                // Calcula el mes con "wrap-around" (ej: Nov + 3 = Feb)
                int mes = ((mesActual - 1 + i) % 12) + 1;
                DateTime dt = new DateTime(DateTime.Now.Year, mesActual, 1).AddMonths(i);

                comboBoxMes.Items.Add(
                    //CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes)
                    dt.ToString("MMMM yyyy"));
            }

            // Selecciona el mes vigente (primer elemento)
            comboBoxMes.SelectedIndex = 0;
        }

        
        // Para obtener el valor seleccionado (número del mes)
        private void comboBoxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMes.SelectedIndex >= 0)
            {
                // El índice es 0-based, por lo que Enero es índice 0
                int mesNumero = comboBoxMes.SelectedIndex + 1;
                MessageBox.Show($"Mes seleccionado: {comboBoxMes.SelectedItem} (Número: {mesNumero})");
            }
        }

    }
}
