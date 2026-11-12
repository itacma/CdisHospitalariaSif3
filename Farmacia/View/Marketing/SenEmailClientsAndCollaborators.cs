using DevComponents.DotNetBar;
using SIFModelo.Marketing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;


namespace SIF.View.Marketing
{
    public partial class SenEmailClientsAndCollaborators : DevComponents.DotNetBar.Metro.MetroForm
    {
        private SIFNegocio.Marketing.SendEmail _sendEmailNegocio;
        private string myEmail;
        private string MyPassword;
        //private string myEmail = "marketing@ffleming.com.mx";
        //private string MyPassword = "njkp mxhy hmpn xmim";
        //private string myEmail = "sistemaspr@ffleming.com.mx";
        //private string MyPassword = "zvht muvq xwzs swwi";
        private string MyAlias = "Promociones Fleming";
        private string[] myAdjuntos;
        private MailMessage mCorreo;
        //private string destinatarioPrincipal = "jose.m.quechol@gmail.com"; // Destinatario principal
        //private string destinatarioPrincipal = "sup.marketing@ffleming.com.mx";

        List<modelPersona> lp = new List<modelPersona>();
        List<string> list = new List<string>();

        public SenEmailClientsAndCollaborators()
        {
            InitializeComponent();
            _sendEmailNegocio = new SIFNegocio.Marketing.SendEmail();
            getListMailsDB();
            txtEmailFrom.Enabled = false;
            getListas();
            label2.Text = "El correo será enviado a: " + lp.Count().ToString() + " Usuarios";

            myEmail = _sendEmailNegocio.GetEmail();
            MyPassword = _sendEmailNegocio.GetDecryptedPassword();
            Console.WriteLine("Email: " + myEmail);
            Console.WriteLine("Password: " + MyPassword);
        }

        public void ObtenerEmail()
        {
            myEmail = _sendEmailNegocio.GetEmail(); //
        }
                
        private MailMessage CrearCuerpoCorreo(string email)
        {
            var correo = new MailMessage
            {
                From = new MailAddress(myEmail, MyAlias, System.Text.Encoding.UTF8),
                Subject = txtSubject.Text.Trim(),
                Body = txtMessage.Text.Trim().Replace("\n", "<br />"),
                IsBodyHtml = true,
                Priority = MailPriority.High
            };
            // Agregar destinatario principal y destinatario individual
            //correo.To.Add(destinatarioPrincipal);
            //correo.Bcc.Add(email);
            correo.To.Add(email);
            if (myAdjuntos != null)
            {
                foreach (string adjunto in myAdjuntos)
                {
                    Attachment attachment = new Attachment(adjunto);
                    correo.Attachments.Add(attachment);
                }
            }

            return correo;
        }
        private void getListas()
        {
            if (GrupoEmailBoxEx.SelectedItem != null)
            {
                MGrupoSendEmail j = GrupoEmailBoxEx.SelectedItem as MGrupoSendEmail;
                lp = new SIFNegocio.Marketing.SendEmail().Buscar("S", j.IdGrupo).DataSource as List<modelPersona>;
            }

        }

        private void EscribirLog(string contenido)
        {
            string rutaArchivo = "C:\\Program Files (x86)\\Sistema Integral de Farmacia\\SIF 3.0 CDIS\\sif.log";
            try
            {
                // Escribir el contenido en el archivo (reemplaza el contenido existente)
                File.WriteAllText(rutaArchivo, contenido);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al escribir el log: " + ex.Message);
            }
        }

        private void Enviar()
        {
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587, // Puerto para TLS
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(myEmail, MyPassword)
            };
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return true; };

            StringBuilder logBuilder = new StringBuilder(); // Para construir el contenido del log
            bool envioExitoso = true;
            foreach (modelPersona destinatario in lp)
            {
                try
                {
                    mCorreo = CrearCuerpoCorreo(destinatario.Email.Trim());
                    smtp.Send(mCorreo);

                    //LogEnvioCorreo("Éxito", destinatario.Email, "Enviado correctamente");
                    logBuilder.AppendLine($"Correo enviado a {destinatario.Email} - Éxito");
                }
                catch (SmtpException e)
                {
                    envioExitoso = false;
                    MessageBox.Show($"Error al enviar el correo a {destinatario.Email}: {e.Message}");
                    //LogEnvioCorreo("Falló", destinatario.Email, $"Error al enviar el correo: {e.Message}");
                    logBuilder.AppendLine($"Correo a {destinatario.Email} falló - Error SMTP: {e.Message}");
                    break;
                }
                catch (Exception ex)
                {
                    envioExitoso = false;
                    MessageBox.Show($"Error al enviar el correo a {destinatario.Email}: {ex.Message}");
                    //LogEnvioCorreo("Falló", destinatario.Email, $"Error al enviar el correo: {ex.Message}");
                    logBuilder.AppendLine($"Correo a {destinatario.Email} falló - Error general: {ex.Message}");
                    break;
                }
            }
            EscribirLog(logBuilder.ToString());
            string mensajeRespuesta = envioExitoso ? "Correos fueron enviados correctamente." : "Error al enviar algunos correos.";
            string estadoEnvio = envioExitoso ? "Éxito" : "Falló";
            RegistrarLogEnvioGeneral(estadoEnvio, mensajeRespuesta);

            //MessageBox.Show("El proceso de envío de correos se ha completado."); 
            if (envioExitoso)
            {
                MessageBox.Show("Proceso de envío de correos completado correctamente.");
            }
            else
            {
                MessageBox.Show("Error en el proceso de envío de correos.");
            }
            lblFiles.Text = "";
            LimpiarFormulario();
        }

        private void RegistrarLogEnvioGeneral(string estadoEnvio, string mensajeRespuesta)
        {
            try
            {
                // Variables a guardar en la base de datos
                string userId = Helpers.Sesion.Usuario.UsuariosID.ToString();
                string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                string adjuntosInfo = myAdjuntos != null && myAdjuntos.Length > 0 ? "Sí" : "No";
                string descripcionAdjuntos = myAdjuntos != null && myAdjuntos.Length > 0 ? string.Join("\n", myAdjuntos) : "N/A";
                string nombreEquipo = Environment.MachineName.ToString();
                string asunto = txtSubject.Text.Trim();
                string grupo = GrupoEmailBoxEx.SelectedItem != null ? ((MGrupoSendEmail)GrupoEmailBoxEx.SelectedItem).Descripcion : "N/A";

                _sendEmailNegocio.LogEmail(userId, fecha, adjuntosInfo, descripcionAdjuntos, nombreEquipo, asunto, grupo, mensajeRespuesta, estadoEnvio);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el log general del envío: " + ex.Message);
            }
        }

        private void LimpiarFormulario()
        {
            txtSubject.Text = string.Empty;
            txtMessage.Text = string.Empty;
        }

        private void AdjuntarArchivos()
        {            
            var names = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Title = "Adjuntar archivos al correo";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Lista temporal para almacenar archivos válidos
                List<string> archivosValidos = new List<string>();
                foreach (string file in ofd.FileNames)
                {
                    // Obtener la extensión del archivo
                    string fileExtension = Path.GetExtension(file).ToLower();
                    // Verificar si el archivo es un video
                    if (fileExtension == ".avi" || fileExtension == ".mp4")
                    {
                        // Solo aceptar .avi y .mp4 para videos
                        if (fileExtension == ".avi" || fileExtension == ".mp4")
                        {
                            archivosValidos.Add(file);
                        }
                        else
                        {
                            // Mostrar mensaje de error para archivos de video no válidos
                           MessageBox.Show($"Archivo de video no válido: {file}. Solo se permiten archivos de video en formato AVI o MP4.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Aceptar otros tipos de archivos sin restricciones
                        archivosValidos.Add(file);
                    }
                }
                // Asignar los archivos válidos a myAdjuntos
                myAdjuntos = archivosValidos.ToArray();
            }

            if (myAdjuntos != null && myAdjuntos.Length > 0)
            {
                for (int i = 0; i < myAdjuntos.Length; i++)
                {
                    names += myAdjuntos[i] + "\n";
                }

                lblFiles.Text = names;
            }
            else
            {
               MessageBox.Show("¡No se adjuntó ningún archivo válido!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        

        private void SendButtonX_Click(object sender, EventArgs e)
        {
            if (lp.Count == 0)
            {
                MessageBox.Show("No existen destinatarios a los que enviar el correo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //CrearCuerpoCorreo();
            Enviar();
            this.Close();
        }
        private void AddFileButtonX_Click(object sender, EventArgs e)
        {
            AdjuntarArchivos();
        }
       
        private void getListMailsDB()
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

        private void GrupoEmailBoxEx_SelectedValueChanged(object sender, EventArgs e)
        {
            getListas();
            if (GrupoEmailBoxEx.SelectedValue != null)
            {
                try
                {
                    getListas();
                    label2.Text = "El correo será enviado a: " + lp.Count().ToString() + " Usuarios";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("SelectedValue es nulo.");
            }
        }

        public string LeerArchivoTexto(string rutaArchivo)
        {
            // Verificamos si el archivo existe
            if (!File.Exists(rutaArchivo))
            {
                return "0:ERROR El archivo no existe:" + rutaArchivo;
            }

            try
            {
                // Leemos el contenido del archivo usando StreamReader
                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        list.Add(linea.Replace("\r\n", ""));

                    }
                    return "1:OK";
                }
            }
            catch (Exception ex)
            {
                // Manejamos cualquier excepción que pueda ocurrir durante la lectura
                return "0:ERROR al leer el archivo: " + rutaArchivo + ". Detalle: " + ex.Message;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        internal void label2_Click_1(object sender, EventArgs e)
        {
            if (GrupoEmailBoxEx.SelectedValue != null)
            {
                try
                {
                    int idGrupoSeleccionado = Convert.ToInt32(GrupoEmailBoxEx.SelectedValue);
                    fmrSendUserEmailEdicion frm = new fmrSendUserEmailEdicion(idGrupoSeleccionado);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //frm.UserEmailsUpdated += EditForm_UserEmailsUpdated;//ACTUALIZAR FORMULARIO
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un grupo antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SenEmailClientsAndCollaborators_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Botón configuración
            frmConfiguracion frm = new frmConfiguracion();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();                        
            
        }
    }
}