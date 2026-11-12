using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Catalogos
{
    public partial class DireccionClienteForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public DireccionClienteForm()
        {
            InitializeComponent();
        }

        SIFModelo.Cliente cliente;
        public DireccionClienteForm(SIFModelo.Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;

        }
        SIFModelo.DireccionCliente direccionCliente;
        SIFNegocio.Clientes clienteN = new SIFNegocio.Clientes();

        private void inicializa()
        {
            this.nombreClienteLabelX.Text = cliente.Nombre;
            this.apellidoPaternoLabelX.Text = cliente.ApellidoPaterno;
            this.apellidoMaternoLabelX.Text = cliente.ApellidoMaterno;

            this.tipoDireccionLabelX.Text = cliente.TipoDireccion.Tipo;
            if (cliente.TipoDireccion.Tipo != "FISCAL")
            {
                RFCtextBoxX.Visible = false;

            }

            //BUSCAR SI YA EXISTE EL TIPO DE DIRECCION EN EL CATALOGO CON EL CLIENTE SELECCIONADO

            direccionCliente = clienteN.DireccionCliente(cliente, cliente.TipoDireccion);
            //
            if (direccionCliente != null)
            {
                this.RFCtextBoxX.Text = direccionCliente.RFC;
                this.emailTextBoxX.Text = direccionCliente.Email;
                this.telefonoMaskedTextBoxAdv.Text = direccionCliente.Telefono;
                this.CPmaskedTextBoxAdv.Text = (direccionCliente.CodigoPostal.ToString().Length<5?"0"+direccionCliente.CodigoPostal.ToString():direccionCliente.CodigoPostal.ToString());
                this.estadoComboBoxEx.Text = direccionCliente.Ciudad;
                this.municipioComboBoxEx.Text = this.direccionCliente.Municipio;
                this.coloniaComboBoxEx.Text = direccionCliente.Colonia;
                this.calleTextBoxX.Text = direccionCliente.Calle;
                this.numExteriorNumericUpDown.Text = direccionCliente.NumeroExterior;
                this.numInteriorNumericUpDown.Text = direccionCliente.NumeroInterior;
                this.CelularTextBoxAdv1.Text = direccionCliente.Celular;
                this.txtEntreCalles.Text = direccionCliente.EntreCalles;
            }
        }

        private bool GuardaDireccion()
        {
            if (!Valida())
            {
                return false;
            }
            bool esNuevo = false;

            if (direccionCliente == null)
            {
                esNuevo = true;
                direccionCliente = new SIFModelo.DireccionCliente();
            }

            direccionCliente.ClienteID = cliente.ID;
            direccionCliente.TipoDireccion = cliente.TipoDireccion;

            direccionCliente.RFC = this.RFCtextBoxX.Text;
            direccionCliente.Email = this.emailTextBoxX.Text;
            direccionCliente.Telefono = this.telefonoMaskedTextBoxAdv.Text;
            direccionCliente.CodigoPostal = this.CPmaskedTextBoxAdv.Text;
            direccionCliente.Ciudad = this.estadoComboBoxEx.Text;
            direccionCliente.Municipio = municipioComboBoxEx.Text;
            direccionCliente.Colonia = this.coloniaComboBoxEx.Text;
            direccionCliente.Calle = this.calleTextBoxX.Text;
            direccionCliente.NumeroExterior = this.numExteriorNumericUpDown.Text;
            direccionCliente.NumeroInterior = this.numInteriorNumericUpDown.Text;
            direccionCliente.Celular = this.CelularTextBoxAdv1.Text;
            direccionCliente.EntreCalles = this.txtEntreCalles.Text;

            if (esNuevo)
            {
                return clienteN.NuevoDireccion(direccionCliente);
            }
            else
            {
                return clienteN.ModificarDireccion(direccionCliente);
            }

        }

        private Boolean Valida()
        {

            //if (!string.IsNullOrEmpty(this.RFCtextBoxX.Text) && !SIFNegocio.Helpers.Validadociones.ValidarRFC(this.RFCtextBoxX.Text))
            //{
            //    //MessageBoxEx.Show("El rfc");
            //    ////this.highlighter1.SetHighlightColor(RFCtextBoxX, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            //    //return false;
            //}

            if (string.IsNullOrEmpty(emailTextBoxX.Text) && !SIFNegocio.Helpers.Validadociones.IsValidEmail(emailTextBoxX.Text))
            {
                //this.highlighter1.SetHighlightColor(emailTextBoxX, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
               MessageBox.Show("El email no es correcto");
                this.emailTextBoxX.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(telefonoMaskedTextBoxAdv.Text))
            {
               MessageBox.Show("Ingrese el teléfono");
                this.telefonoMaskedTextBoxAdv.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(numExteriorNumericUpDown.Text))
            {
               MessageBox.Show("Proporcione el número exterior");
                this.numExteriorNumericUpDown.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(calleTextBoxX.Text))
            {
               MessageBox.Show("El campo Calle es obligatorio");
                this.calleTextBoxX.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(coloniaComboBoxEx.Text))
            {
               MessageBox.Show("El campo Colonia es obligatorio");
                this.coloniaComboBoxEx.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(estadoComboBoxEx.Text))
            {
               MessageBox.Show("El Estado es obligatorio");
                this.estadoComboBoxEx.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(municipioComboBoxEx.Text))
            {
               MessageBox.Show("El Municipio es obligatorio");
                this.municipioComboBoxEx.Focus();
                return false;
            }
            //if (this.CPmaskedTextBoxAdv.Text.Length > 5)
            //{
            //   MessageBox.Show("El código postal es incorrecto");
            //    CPmaskedTextBoxAdv.SelectAll();
            //    return false;
            //}

            if (cliente.TipoDireccion == SIFModelo.Tipos.TipoDireccion.fiscal)
                if (!SIFNegocio.Helpers.Validadociones.ValidarRFC(this.RFCtextBoxX.Text))
                {
                   //MessageBox.Show("El RFC no es válido, por favor verifique", "RFC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

            return true;
        }

        BindingSource estadosBindingsource;
        SIFNegocio.Extras.Estado estadoN = new SIFNegocio.Extras.Estado();
        private void CargaEstados()
        {
            estadosBindingsource = new BindingSource();
            estadosBindingsource.DataSource = estadoN.CargaEstados();

            this.estadoComboBoxEx.DataSource = estadosBindingsource;
            this.estadoComboBoxEx.DisplayMember = "Nombre";
            this.estadoComboBoxEx.ValueMember = "Nombre";
        }

        BindingSource municipiosBindingsource;
        private void CargaMunicipios()
        {
            SIFModelo.Extras.Estado estado = new SIFModelo.Extras.Estado();
            estado.Nombre = this.estadoComboBoxEx.Text;
            //estado.Nombre = "PUEBLA";

            if (estado == null || string.IsNullOrEmpty(estado.Nombre))
            {
                return;
            }

            municipiosBindingsource = new BindingSource();
            municipiosBindingsource.DataSource = estadoN.CargaMunicipios(estado);

            this.municipioComboBoxEx.DataSource = municipiosBindingsource;
            this.municipioComboBoxEx.DisplayMember = "Nombre";
            this.municipioComboBoxEx.ValueMember = "Nombre";
            municipioComboBoxEx.Update();
        }

        BindingSource coloniasBindingsource;
        private void CargaColonias()
        {
            SIFModelo.Extras.Municipio municipio = new SIFModelo.Extras.Municipio();
            municipio.Nombre = this.estadoComboBoxEx.Text;
            municipio.Estado = this.estadoComboBoxEx.Text;

            if (municipio == null || string.IsNullOrEmpty(municipio.Nombre))
            {
                return;
            }

            coloniasBindingsource = new BindingSource();
            coloniasBindingsource.DataSource = estadoN.CargaColoniasPorEstado(municipio);

            this.coloniaComboBoxEx.DataSource = coloniasBindingsource;
            this.coloniaComboBoxEx.DisplayMember = "Nombre";
            this.coloniaComboBoxEx.ValueMember = "Nombre";
            coloniaComboBoxEx.Update();
        }

        BindingSource cpsBindingsource;
        private void CargaCPS()
        {
            SIFModelo.Extras.Colonia colonia = new SIFModelo.Extras.Colonia();
            colonia.Nombre = this.coloniaComboBoxEx.Text;

            if (colonia == null || string.IsNullOrEmpty(colonia.Nombre))
            {
                return;
            }

            cpsBindingsource = new BindingSource();
            cpsBindingsource.DataSource = estadoN.CargaCPS(colonia);

            this.coloniaComboBoxEx.DataSource = cpsBindingsource;
            this.coloniaComboBoxEx.DisplayMember = "Nombre";
            this.coloniaComboBoxEx.ValueMember = "Nombre";
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (this.GuardaDireccion())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void cancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void DireccionClienteForm_Load(object sender, EventArgs e)
        {
            this.CargaEstados();
            this.CargaMunicipios();
            this.CargaColonias();
            this.inicializa();

            if (this.direccionCliente == null)
            {
                this.estadoComboBoxEx.Text = "PUEBLA";
                this.municipioComboBoxEx.Text = "PUEBLA";
                this.coloniaComboBoxEx.Text = "CENTRO";
            }
        }


        private void estadoComboBoxEx_Leave(object sender, EventArgs e)
        {
            this.CargaMunicipios();
        }

        private void municipioComboBoxEx_Leave(object sender, EventArgs e)
        {
            this.CargaColonias();
        }

        private void coloniaComboBoxEx_Leave(object sender, EventArgs e)
        {
            this.CargaCPS();
        }

        private void CPmaskedTextBoxAdv_Enter(object sender, EventArgs e)
        {
            this.CPmaskedTextBoxAdv.SelectedText = CPmaskedTextBoxAdv.Text;
        }
    }
}