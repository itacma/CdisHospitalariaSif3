using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SIF3.Clases;

namespace SIF.View.Ventas
{
    public partial class frmActiveCard : DevComponents.DotNetBar.Metro.MetroForm
    {
        string Sesion = "";
        private string GetLogin(string Cad, string Usr, string Pwd, string Suc)
        {
            Sesion = string.Empty;

            try
            {
                SIFNegocio.WebServices.NADRO wsNadro = new SIFNegocio.WebServices.NADRO();
                Sesion = wsNadro.GetLogin(SIFNegocio.Configuracion.Configuraciones.Nadro);
                return Sesion;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message,
                    ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return string.Empty;
            }
        }

        private bool ActiveCard()
        {
            bool OK = false;
            try
            {
                SIFNegocio.WebServices.NADRO wsNadro = new SIFNegocio.WebServices.NADRO();

                SIFModelo.WebServices.TarjetaNadro tN = new SIFModelo.WebServices.TarjetaNadro();
                tN.SesionID = this.Sesion;
                tN.NumeroTarjeta = this.tb_NadroNoTarjeta.Text;

                SIFModelo.Cliente cliente = new SIFModelo.Cliente();
                cliente.Nombre = this.tb_NadroNomPaciente.Text;
                cliente.ApellidoPaterno = this.tb_NadroApePatPaciente.Text;
                cliente.ApellidoMaterno = this.tb_NadroApeMatPaciente.Text;

                SIFModelo.DireccionCliente dir = new SIFModelo.DireccionCliente();
                dir.Telefono = tb_NadroNoTelefono.Text;
                dir.Email = tb_NadroeMail.Text;
                dir.CodigoPostal = tb_CP.Text;
                //int sexo = tb_Sexo.SelectedIndex;
                DateTime fechaN = tb_FechaN.Value;
                string selecSex = this.tb_Sexo.GetItemText(this.tb_Sexo.SelectedItem);
               
                //MessageBox.Show(selected);
                if (selecSex == "Masculino")
                {
                    selecSex = "M";
                }
                else
                {
                    selecSex = "F";
                }
                bool activado = wsNadro.ActivaTarjeta(SIFNegocio.Configuracion.Configuraciones.Nadro, tN, cliente, dir, fechaN, selecSex, nombreUSuario);

                return activado;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message,
                    ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return OK;
            }
        }

        public frmActiveCard()
        {
            InitializeComponent();
        }

        // the new added constructor with parameter
        string nombreUSuario;
        SIFModelo.Cliente cliente;
        public frmActiveCard(string strParam, SIFModelo.Cliente cliente, string usuarionom)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(strParam))
                this.tb_NadroNoTarjeta.Text = strParam;
            if (cliente.ID != 0)
            {
                this.cliente = cliente;
                this.cargaCliente();
            }
            nombreUSuario = usuarionom;
        }

        private void cargaCliente()
        {
            this.tb_NadroNomPaciente.Text = cliente.Nombre;
            this.tb_NadroApePatPaciente.Text = cliente.ApellidoPaterno;
            this.tb_NadroApeMatPaciente.Text = cliente.ApellidoMaterno;

            SIFModelo.DireccionCliente direccion = new SIFNegocio.Clientes().DireccionCliente(cliente);

            if (direccion == null)
            {
                direccion = new SIFModelo.DireccionCliente();
            }

            this.tb_NadroNoTelefono.Text = direccion.Telefono;
            this.tb_NadroeMail.Text = direccion.Email;
        }

        private bool validar()
        {
            if (string.IsNullOrEmpty(this.tb_NadroNoTarjeta.Text))
            {
               MessageBox.Show("Debe ingresar el número de tarjeta NADRO");
                this.tb_NadroNoTarjeta.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.tb_NadroNomPaciente.Text))
            {
               MessageBox.Show("Debe proporcionar un nombre para el cliente");
                this.tb_NadroNomPaciente.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.tb_NadroApePatPaciente.Text))
            {
               MessageBox.Show("Ingrese el apellido paterno");
                this.tb_NadroApePatPaciente.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.tb_NadroApeMatPaciente.Text))
            {
               MessageBox.Show("Ingrese el apellido materno");
                this.tb_NadroApeMatPaciente.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.tb_NadroNoTelefono.Text) | this.tb_NadroNoTelefono.Text.Length < 10)
            {

                if (string.IsNullOrEmpty(tb_NadroNoTelefono.Text))
                {
                   MessageBox.Show("El número de teléfono es obligatorio");
                }
                else
                {
                    if (tb_NadroNoTelefono.Text.Length < 10)
                    {
                       MessageBox.Show("Capture los 10 dígitos del número telefónico");
                    }
                }

                this.tb_NadroNoTelefono.Focus();
                this.tb_NadroNoTelefono.Select();
                return false;
            }

            if (!string.IsNullOrEmpty(this.tb_NadroeMail.Text))
            {
                if (!SIFNegocio.Helpers.Validadociones.IsValidEmail(this.tb_NadroeMail.Text))
                {
                   MessageBox.Show("La dirección de correo electrónico no es válida");
                    this.tb_NadroeMail.Focus();
                    this.tb_NadroeMail.SelectAll();
                    return false;
                }
            }

            return true;
        }

        private void btn_ActiveCard_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }

            if (string.IsNullOrEmpty(SIFNegocio.Configuracion.Configuraciones.Nadro.Cadena) ||
                 string.IsNullOrEmpty(SIFNegocio.Configuracion.Configuraciones.Nadro.Usuario) ||
                 string.IsNullOrEmpty(SIFNegocio.Configuracion.Configuraciones.Nadro.Contrasena) ||
                 string.IsNullOrEmpty(SIFNegocio.Configuracion.Configuraciones.Nadro.Sucursal.ToString()))
            {
               MessageBox.Show("Error en la configuración del servicio" + Environment.NewLine +
                                  "Configure el servicio antes de usuarlo", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                Cursor.Current = Cursors.WaitCursor;

                string Respuesta = GetLogin(SIFNegocio.Configuracion.Configuraciones.Nadro.Cadena,
                                            SIFNegocio.Configuracion.Configuraciones.Nadro.Usuario,
                                            SIFNegocio.Configuracion.Configuraciones.Nadro.Contrasena,
                                            SIFNegocio.Configuracion.Configuraciones.Nadro.Sucursal.ToString());

                if (!string.IsNullOrEmpty(Respuesta))
                {
                    if (ActiveCard())
                    {
                        // MessageBox.Show("La Tarjeta: " + tb_NadroNoTarjeta.Text + Environment.NewLine +
                        //"Se Activo!", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cursor.Current = Cursors.Default;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }

                }

                Cursor.Current = Cursors.Default;

                // close the dialog
                this.Close();
            }
        }

        private void tb_FechaN_Click(object sender, EventArgs e)
        {

        }
    }
}