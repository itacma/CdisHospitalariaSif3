using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Ventas
{
    /// <summary>
    /// Cambia la contraseña del usuario
    /// </summary>
    public partial class CambiarContrasenhaUsuario : DevComponents.DotNetBar.Metro.MetroForm
    {
        public CambiarContrasenhaUsuario(SIFModelo.Usuario userModificarPass)
        {
            InitializeComponent();
            UsuarioX = userModificarPass;
        }

        public object Owner;
        public SIFModelo.Usuario UsuarioX;
        int oportunidades = 0;


        SIFNegocio.Usuarios logica = new SIFNegocio.Usuarios();
        private void IgualarContraseñas()
        {
            if (string.IsNullOrEmpty(usuarioTextBoxX.Text))
            {
               MessageBox.Show("Ingrege la nueva contraseña", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.usuarioTextBoxX.SelectAll();
                usuarioTextBoxX.Focus();
                this.usuarioTextBoxX.Focus();
                return;
            }

            if (string.IsNullOrEmpty(contrasenaTextBoxX.Text))
            {
               MessageBox.Show("Debe confirmar la contraseña", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.contrasenaTextBoxX.SelectAll();
                contrasenaTextBoxX.Focus();
                return;
            }

            
            // igualar las la contraseñas             
            if (!usuarioTextBoxX.Text.Equals(contrasenaTextBoxX.Text))
            {
               MessageBox.Show("Las contraseñas deben ser iguales", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                contrasenaTextBoxX.Text = "";
                usuarioTextBoxX.Text = "";
                usuarioTextBoxX.Focus();

                oportunidades++;
                if (oportunidades >= 3)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                }

                return;
            }

            SIFModelo.Usuario usuario = new SIFModelo.Usuario();
            usuario = UsuarioX;
            usuario.Contrasena = this.contrasenaTextBoxX.Text;
            Boolean actualizo = logica.ActualizaContrasenha(usuario);

            if (actualizo)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                //MessageBox.Show(usuario.Nombre.ToString());
                this.Close();
                return;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return;
            }
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            this.IgualarContraseñas();
        }

        private void CancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void usuarioTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.contrasenaTextBoxX.Focus();
            }
        }
    }
}
