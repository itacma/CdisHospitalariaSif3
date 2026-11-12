using SIFModelo.Marketing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Marketing
{
    public partial class fmrSendUserEmailEdicion : DevComponents.DotNetBar.Metro.MetroForm
    {
        private int _idGrupoSeleccionado;
        public SIFNegocio.Marketing.SendEmail _sendEmailNegocio;

        public fmrSendUserEmailEdicion(int idGrupoSeleccionado)
        {
            InitializeComponent();
            _idGrupoSeleccionado = idGrupoSeleccionado;
            _sendEmailNegocio = new SIFNegocio.Marketing.SendEmail();
            mostrarControles(true);
            cargarGruposEmail(); // Cargar la lista de grupos en el ComboBox
            GrupoEmailBoxEx.SelectedValue = _idGrupoSeleccionado; // Seleccionar el grupo actual
            getListas();

            GrupoEmailBoxEx.SelectedValueChanged += GrupoEmailBoxEx_SelectedValueChanged;
        }

        private void mostrarControles(bool pcarga)
        {
            if (pcarga)
            {
                mostrarAgregarUsuario(false);
                mostrarEliminarUsuario(false);
                mostrarrbAgregarExistente(false);
            }
            else
            {
                if (rbAgregarUsuario.Checked == true)
                {
                    mostrarAgregarUsuario(true);
                    mostrarEliminarUsuario(false);
                    mostrarrbAgregarExistente(false);
                }
                if (rbdeditarGrupo.Checked == true)
                {
                    mostrarAgregarUsuario(false);
                    mostrarEliminarUsuario(true);
                    mostrarrbAgregarExistente(false);
                }
                if (rbAgregarExistente.Checked == true)
                {
                    mostrarAgregarUsuario(false);
                    mostrarEliminarUsuario(false);
                    mostrarrbAgregarExistente(true);
                    CargarUsuariosDisponibles();
                }
            }
        }

        private void mostrarAgregarUsuario(bool estado)
        {
            label2.Visible = estado;
            label3.Visible = estado;
            label4.Visible = estado;
            label6.Visible = estado;
            GrupoEmailBoxEx.Visible = false;
            btnAceptar.Visible = estado;
            txtNombre.Visible = estado;
            txtNoEmp.Visible = estado;
            txtApellidos.Visible = estado;
            txtEmail.Visible = estado;
            btnActualizar.Visible = estado;
        }

        private void mostrarEliminarUsuario(bool estado)
        {
            label1.Visible = estado;
            ListEmailBoxEx.Visible = estado;
            button1.Visible = estado;
            btnDesvincular.Visible = estado;
            

        }

        private void mostrarrbAgregarExistente(bool estado)
        {
            cbxUsuarios.Visible = estado;
            btnAgregarUsuario.Visible = estado;
        }

        private void rbdeditarGrupo_CheckedChanged(object sender, EventArgs e)
        {
            mostrarControles(false);
        }

        private void rbAgregarUsuario_CheckedChanged(object sender, EventArgs e)
        {
            mostrarControles(false);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            mostrarControles(false);
        }


        private void getListas()
        {
            if (_idGrupoSeleccionado != -1)
            {
                List<modelPersona> ListaEmails = new SIFNegocio.Marketing.SendEmail().Buscar("S", _idGrupoSeleccionado).DataSource as List<modelPersona>;
                ListEmailBoxEx.DataSource = ListaEmails;
                ListEmailBoxEx.DisplayMember = "Name";
                ListEmailBoxEx.ValueMember = "Email";
            }
            else
            {
                MessageBox.Show("No se encontró el grupo seleccionado en la base de datos.");
            }
        }

        private void GrupoEmailBoxEx_SelectedValueChanged(object sender, EventArgs e)
        {
            if (GrupoEmailBoxEx.SelectedValue != null)
            {
                if (GrupoEmailBoxEx.SelectedValue != null)
                {
                    try
                    {
                        var selectedItem = GrupoEmailBoxEx.SelectedItem as MGrupoSendEmail;
                        if (selectedItem != null)
                        {
                            int selectedGroupId = selectedItem.IdGrupo;
                            //Console.WriteLine("Valor del id del grupo seleccionado del formulario2: " + selectedGroupId);
                            List<modelPersona> ListaEmails = new SIFNegocio.Marketing.SendEmail().Buscar("S", selectedGroupId).DataSource as List<modelPersona>;
                            ListEmailBoxEx.DataSource = ListaEmails;
                            ListEmailBoxEx.DisplayMember = "Name";
                        }
                        else
                        {
                            MessageBox.Show("El elemento seleccionado no es del tipo esperado.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al procesar el valor seleccionado: " + ex.Message);
                    }
                }

            }
        }

        private void cargarGruposEmail()
        {
            var GruposEmails = _sendEmailNegocio.BuscarListGrupo().DataSource as List<MGrupoSendEmail>;
            if (GruposEmails == null || GruposEmails.Count == 0)
            {
                MessageBox.Show("No se encontraron grupos de correos electrónicos.");
                return;
            }
            GrupoEmailBoxEx.DataSource = GruposEmails;
            GrupoEmailBoxEx.DisplayMember = "Descripcion";
            GrupoEmailBoxEx.ValueMember = "IdGrupo";
        }

        private void btnDesvincular_Click(object sender, EventArgs e)
        {
            var selectedPersona = (modelPersona)ListEmailBoxEx.SelectedItem;
            if (selectedPersona != null)
            {
                var email = selectedPersona.Email;
                Console.WriteLine("Valor del correo: " + email);
                if (!string.IsNullOrEmpty(email))
                {
                    try
                    {
                        var nombre = selectedPersona.Name;
                        var idGrupo = selectedPersona.grupo;
                        _sendEmailNegocio.EliminarDeGrupo(_idGrupoSeleccionado, email);
                        MessageBox.Show("Se ha desviculado el registro correctamente.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getListas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al intentar eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el email correspondiente en la vista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un email primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Código del botón ELIMINAR USUARIO, para cambiar a estado N
            if (ListEmailBoxEx.SelectedValue != null)
            {
                var selectedNombre = (SIFModelo.Marketing.modelPersona)ListEmailBoxEx.SelectedItem;
                _sendEmailNegocio.DesactivarEmail(selectedNombre.Name);
                MessageBox.Show("Se a eliminado al usuario", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getListas();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un email primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            //Botón para agregar usuario existente            
            if (cbxUsuarios.SelectedItem != null)
            {
                var selectedPersona = (modelPersona)cbxUsuarios.SelectedItem;
                var email = selectedPersona.Email;
                var idGrupo = _idGrupoSeleccionado;

                try
                {
                    _sendEmailNegocio.AgregarClienteAlGrupo(idGrupo, email);
                    MessageBox.Show("Usuario añadido correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getListas();
                    // Opcional: Limpiar la selección del ComboBox y ocultarlo
                    cbxUsuarios.SelectedIndex = -1;
                    cbxUsuarios.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al añadir usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //BOTON DE GUARDAR DEL rdNuevoUsuario
            string nombreIngresado = txtNombre.Text.Trim();
            string apellidosIngresados = txtApellidos.Text.Trim();
            string numeroEmpleadoIngresadoTexto = txtNoEmp.Text.Trim();
            string emailIngresado = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(nombreIngresado) || string.IsNullOrEmpty(apellidosIngresados) ||
                string.IsNullOrEmpty(numeroEmpleadoIngresadoTexto) || string.IsNullOrEmpty(emailIngresado))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            nombreIngresado = nombreIngresado.ToUpper();
            apellidosIngresados = apellidosIngresados.ToUpper();

            if (!int.TryParse(numeroEmpleadoIngresadoTexto, out int numeroEmpleadoIngresado))
            {
                MessageBox.Show("El número de empleado debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(emailIngresado))
            {
                MessageBox.Show("El correo electrónico no tiene una estructura válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_sendEmailNegocio.IsEmailDuplicated(emailIngresado))
            {
                MessageBox.Show("El correo ya está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _sendEmailNegocio.AgregarCliente(emailIngresado, nombreIngresado, apellidosIngresados, numeroEmpleadoIngresado);
                MessageBox.Show("Datos insertados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getListas();
                LimpiarFormulario();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtNoEmp.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void CargarUsuariosDisponibles()
        {
            try
            {
                var usuariosDisponibles = _sendEmailNegocio.BuscarUsuariosNoEnGrupo().DataSource as List<modelPersona>;
                if (usuariosDisponibles != null && usuariosDisponibles.Count > 0)
                {
                    cbxUsuarios.DataSource = usuariosDisponibles;
                    cbxUsuarios.DisplayMember = "Name";
                    cbxUsuarios.ValueMember = "Email";
                    cbxUsuarios.Visible = true; // Mostrar el ComboBox
                }
                else
                {
                    MessageBox.Show("No hay usuarios disponibles para añadir.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios disponibles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListEmailBoxEx_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ListEmailBoxEx.SelectedValue != null)
            {
            }
        }
        
        
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Boton que actualiza la lista del grupo
            this.importarLayout();

        }

        private void importarLayout()
        {
            //Método para importar layout para la actualizacion de correos por grupo
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Seleccionar archivo CSV para importar";
            openFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Multiselect = false; // No permitir seleccionar múltiples archivos



        }

        }
}