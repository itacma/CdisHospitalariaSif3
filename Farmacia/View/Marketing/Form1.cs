using System;
using System.Windows.Forms;

namespace SIF.View.Marketing
{
    public partial class frmConfiguracion : Form
    {
        private SIFNegocio.Marketing.SendEmail _sendEmailNegocio;

        public frmConfiguracion()
        {
            InitializeComponent();
            _sendEmailNegocio = new SIFNegocio.Marketing.SendEmail();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void txtEmail1_TextChanged(object sender, EventArgs e)
        {

        }
                
        private void btnGuardarPsw_Click(object sender, EventArgs e)
        {
            string email = txtEmail1.Text;
            string password = txtPassword1.Text;
            try
            {
                // Guardar email y contraseña encriptada
                _sendEmailNegocio.SaveEmail(email);
                _sendEmailNegocio.SaveEncryptedPassword(password);

                MessageBox.Show("Configuración guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la configuración: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
    }
}
