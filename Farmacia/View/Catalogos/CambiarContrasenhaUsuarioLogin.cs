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
    public partial class CambiarContrasenhaUsuarioLogin : DevComponents.DotNetBar.Metro.MetroForm
    {
        SIFModelo.Usuario userLog = new SIFModelo.Usuario();
        int contador = 0;
        Boolean esAdministrador = false;

        public CambiarContrasenhaUsuarioLogin(SIFModelo.Usuario usuarioConfirmar)
        {
            InitializeComponent();
            //this.cargaUsuarios();
            userLog = usuarioConfirmar;
            contrasenaTextBoxX.Focus();
            usuarioTextBoxX.Enabled = false;
            usuarioTextBoxX.Text = usuarioConfirmar.AccesoID;
        }

        public CambiarContrasenhaUsuarioLogin()
        {
            esAdministrador = true;
            InitializeComponent();
            //this.cargaUsuarios();
            userLog = null;
            contrasenaTextBoxX.Focus();
        }

        public object Owner;
        public SIFModelo.Usuario Usuario;

        /*private void cargaUsuarios()
        {
            //BindingSource srcUsuario = new BindingSource();
            //  srcUsuario.DataSource = new SIFNegocio.Usuarios().Buscar("ACTIVO", "S");

            AutoCompleteStringCollection strCol = new AutoCompleteStringCollection();

            foreach (SIFModelo.Usuario usuario in new SIFNegocio.Usuarios().Buscar("ACTIVO", "S").DataSource)
            {
                strCol.Add(usuario.AccesoID);
            }


            this.usuarioTextBoxX.AutoCompleteCustomSource = strCol;
            //usuarioTextBoxX.DisplayMember = "UsuariosID";
            //usuarioTextBoxX.ValueMember = "UsuariosID";

            //if (usuarioTextBoxX.Items.Count > 0)
            //{
            //    usuarioTextBoxX.SelectedIndex = 0;
            //}
        }*/

        SIFNegocio.Usuarios logica = new SIFNegocio.Usuarios();
        private void Validar()
        {
            if (string.IsNullOrEmpty(usuarioTextBoxX.Text))
            {
               MessageBox.Show("Proporcione un número de usuario", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.usuarioTextBoxX.SelectAll();
                usuarioTextBoxX.Focus();
                this.usuarioTextBoxX.Focus();
                return;
            }
            
            if (string.IsNullOrEmpty(contrasenaTextBoxX.Text))
            {
               MessageBox.Show("Ingrese la contraseña", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.contrasenaTextBoxX.SelectAll();
                contrasenaTextBoxX.Focus();
                return;
            }

            SIFModelo.Usuario usuario = new SIFModelo.Usuario();
            usuario.AccesoID = this.usuarioTextBoxX.Text;
            usuario.Contrasena = this.contrasenaTextBoxX.Text;
            SIFNegocio.Usuarios USER = new SIFNegocio.Usuarios();
            

            if (logica.ValidaUsuarioCambioPass(usuario,esAdministrador))
            {
              Usuario=  USER.UsuarioPorAccesoID(usuario);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
                return;
            }
            else
            {
               MessageBox.Show("Usuario no identificado correctamente", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                contador++;
                contrasenaTextBoxX.SelectAll();
                contrasenaTextBoxX.Focus();
            }

            if (contador >= 3)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return;
            }
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            this.Validar();
        }

        private void VentaUsuarioForm_Load(object sender, EventArgs e)
        {
            
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

        private void VentaUsuarioForm_Activated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.usuarioTextBoxX.Text))
            {
                this.contrasenaTextBoxX.Focus();
            }
        }



    }
}
