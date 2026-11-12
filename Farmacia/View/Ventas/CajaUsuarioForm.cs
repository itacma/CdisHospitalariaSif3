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
    public partial class CajaUsuarioForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public CajaUsuarioForm()
        {
            InitializeComponent();
            this.cargaUsuarios();
            this.CargaCajas();
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

        public int CajaID;
        Dictionary<string, SIFModelo.Caja> DicCajas;
        private void CargaCajas()
        {
            AutoCompleteStringCollection strCol = new AutoCompleteStringCollection();
            DicCajas = new Dictionary<string, SIFModelo.Caja>();
            foreach (SIFModelo.Caja modelo in new SIFNegocio.Cajas().BuscarPorSucursalActivo(Helpers.Sesion.Sucursal).DataSource)
            {
                DicCajas.Add(modelo.Nombre, modelo);
                strCol.Add(modelo.Nombre);
            }
            this.cajaTextBoxDropDown.AutoCompleteCustomSource = strCol;
        }

        SIFNegocio.Usuarios logica = new SIFNegocio.Usuarios();
        private bool Validar()
        {
            if (string.IsNullOrEmpty(usuarioTextBoxX.Text))
            {
               MessageBox.Show("Proporcione un número de usuario", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.usuarioTextBoxX.SelectAll();
                usuarioTextBoxX.Focus();
                this.usuarioTextBoxX.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(contrasenaTextBoxX.Text))
            {
               MessageBox.Show("Ingrese la contraseña", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.contrasenaTextBoxX.SelectAll();
                contrasenaTextBoxX.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cajaTextBoxDropDown.Text))
            {
                //MessageBoxEx.Show("Ingrese el nombre de la caja", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.contrasenaTextBoxX.SelectAll();
                return false;
            }



            SIFModelo.Usuario usuario = new SIFModelo.Usuario();
            usuario.AccesoID = this.usuarioTextBoxX.Text;
            usuario.Contrasena = this.contrasenaTextBoxX.Text;
            usuario = logica.ValidaAcceso(usuario);

            if (usuario != null)
            {
                // this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Usuario = usuario;

                //cajaid 
                if (!DicCajas.ContainsKey(cajaTextBoxDropDown.Text))
                {
                   MessageBox.Show("No se encontró la caja descrita con ese nombre");
                    this.cajaTextBoxDropDown.SelectAll();
                    this.cajaTextBoxDropDown.Focus();
                    return false;
                }
                var caja = DicCajas[cajaTextBoxDropDown.Text];

                if (caja == null)
                {
                   MessageBox.Show("No existe una caja con ese nombre");
                    return false;
                }

                caja.Abierto = new SIFNegocio.Cajas().StatusCaja(Helpers.Sesion.Sucursal, caja);

                if (caja.Abierto == SIFModelo.Tipos.AbiertoCerrado.CERRADO)
                {
                   MessageBox.Show("Debe abrir la caja antes de poder utilizarla");
                    return false;
                }

                caja.CajeroID = new SIFNegocio.Cajas().UsuarioCaja(Helpers.Sesion.Sucursal, caja);

                if (usuario.UsuariosID != caja.CajeroID)
                {

                   MessageBox.Show("La caja no fue abierta por el usuario ingresado");
                    return false;
                }

                if(caja.SucursalID != Helpers.Sesion.Sucursal.SucursalesID)
                {
                   MessageBox.Show("La caja no pertenece a esta sucursal");
                }

                this.CajaID = caja.ID;

                //int.Parse(this.cajaTextBoxDropDown.SelectedValue.ToString());
                //this.Close();
                this.validado = true;
                return true;
            }

           MessageBox.Show("Usuario no identificado correctamente", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private bool validado = false;
        private void aceptarButtonX_Click(object sender, EventArgs e)
        {

            Aceptar();
            //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            return;
        }

        private bool Aceptar()
        {
            if (this.Validar())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
                return true;
            }
            else
            {
                return false;
            }

        }

        private void VentaUsuarioForm_Load(object sender, EventArgs e)
        {
#if DEBUG
            this.usuarioTextBoxX.Text = "SISTEMAS";
            this.contrasenaTextBoxX.Text = "201890";// "C$I2013";
            this.cajaTextBoxDropDown.Text = "CAJA1";
#endif

            if (Helpers.Sesion.UsuarioSeleccionadoVenta == null)
            {
                // this.usuarioTextBoxX.SelectedItem = Helpers.Sesion.UsuarioSeleccionadoVenta;
                //this.contrasenaTextBoxX.SelectAll();
                this.usuarioTextBoxX.Focus();
            }
        }

        private void CancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void cajaTextBoxDropDown_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!validado)
                {
                    this.Aceptar();
                }
            }
        }

    }
}
