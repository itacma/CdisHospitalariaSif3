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
    public partial class AccesoUsuarioForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public AccesoUsuarioForm()
        {
            InitializeComponent();
            this.cargaUsuarios();
        }

        public object Owner;
        public SIFModelo.Usuario Usuario;

        private void cargaUsuarios()
        {
            AutoCompleteStringCollection strCol = new AutoCompleteStringCollection();

            foreach (SIFModelo.Usuario usuario in new SIFNegocio.Usuarios().Buscar("ACTIVO", "S").DataSource)
            {
                strCol.Add(usuario.AccesoID);
            }

            this.usuarioTextBoxX.AutoCompleteCustomSource = strCol;
        }

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
            usuario = logica.ValidaAcceso(usuario);

            if (usuario != null)
            {
                SIFNegocio.WebServices.FEL wsFel = new SIFNegocio.WebServices.FEL();
                wsFel.numeroU(Convert.ToString(usuario.UsuariosID));
                this.Usuario = usuario;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
               // Helpers.Sesion.UsuarioSeleccionadoVenta = usuario;
                this.Close();
                return;
            }

           MessageBox.Show("Usuario no identificado correctamente", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            this.Validar();
        }

        private void VentaUsuarioForm_Load(object sender, EventArgs e)
        {
#if DEBUG
            this.usuarioTextBoxX.Text = "SISTEMAS";
            this.contrasenaTextBoxX.Text = "201890";// "C$I2013";
#endif

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

        private void labelX1_Click(object sender, EventArgs e)
        {

        }



    }
}
