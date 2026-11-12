using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Keyboard;
using DevComponents.DotNetBar;

namespace SIF.Templates
{
    public partial class LoginForm : Form
    {
        TouchKeyboard virtualKeyboard;
        public LoginForm()
        {
            InitializeComponent();

            virtualKeyboard = new TouchKeyboard();
            virtualKeyboard.Text = "";
        }
        public string IDUSUARIO = "";
        private bool ValidaUsuario()
        {
            //if (!this.superValidator.Validate())
            //{
                if (String.IsNullOrEmpty(this.usuarioTextBox.Text))
                {
                   MessageBox.Show("Ingrese su nombre de usuario", "Inicio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.usuarioTextBox.Focus();
                    return false;
                }

                if (String.IsNullOrEmpty(this.contrasenaTextBox.Text))
                {
                   MessageBox.Show("Escriba su contraseña", "Inicio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.contrasenaTextBox.Focus();
                    return false;
                }

                SIFNegocio.Usuarios usuarioN = new SIFNegocio.Usuarios();
                SIFModelo.Usuario usuario = new SIFModelo.Usuario();
                usuario.AccesoID = this.usuarioTextBox.Text;
                IDUSUARIO=Convert.ToString(usuario.UsuariosID);
                usuario.Contrasena = this.contrasenaTextBox.Text;
                usuario = usuarioN.ValidaAcceso(usuario);

                if (usuario == null)
                {
                    //MessageBoxEx.Show("El usuario o la contraseña no son válidos", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.usuarioTextBox.Focus();
                    this.usuarioTextBox.SelectAll();
                    return false;
                }
                          
                Helpers.Sesion.Usuario = usuario;
                SIFNegocio.Helpers.Sesion.Usuario = usuario;
            
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
                return true;
                
            //}
            //return false;
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            
            ValidaUsuario();
        
        }

        private void keyBoardButtonX_Click(object sender, EventArgs e)
        {
            if (virtualKeyboard.GetShowTouchKeyboard(usuarioTextBox) == TouchKeyboardStyle.No)
            {
                virtualKeyboard.SetShowTouchKeyboard(this.usuarioTextBox, TouchKeyboardStyle.Floating);
                virtualKeyboard.SetShowTouchKeyboard(this.contrasenaTextBox, TouchKeyboardStyle.Floating);
            }

            usuarioTextBox.Focus();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            int x = this.Location.X - ((virtualKeyboard.Size.Width - this.Width) / 2);
            int y = this.Location.Y + (this.Height - (virtualKeyboard.Size.Height / 2));
            virtualKeyboard.FloatingLocation = new Point(x, y);

#if DEBUG
            this.usuarioTextBox.Text = "SISTEMAS";
            this.contrasenaTextBox.Text = "S1F24R";//"C$I2013";
#endif
        }

        private void usuarioTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.contrasenaTextBox.Focus();
            }
        }

        private void contrasenaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ValidaUsuario();
            }
        }

        private void cancelarButtonX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
