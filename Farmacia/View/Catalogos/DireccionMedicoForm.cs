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
    public partial class DireccionMedicoForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public DireccionMedicoForm()
        {
            InitializeComponent();
        }

        SIFModelo.Medico Medico;

        public DireccionMedicoForm(SIFModelo.Medico Medico)
        {
            InitializeComponent();
            this.Medico = Medico;
        }

        SIFModelo.DireccionMedico direccionMedico;
        SIFNegocio.Medicos MedicoN = new SIFNegocio.Medicos();

        private void inicializa()
        {
            this.nombreMedicoLabelX.Text = Medico.Nombre;
            this.tipoDireccionLabelX.Text = Medico.TipoConsulta.Tipo;

            //BUSCAR SI YA EXISTE EL TIPO DE DIRECCION EN EL CATALOGO CON EL Medico SELECCIONADO
            direccionMedico = MedicoN.DireccionMedico(Medico, Medico.TipoConsulta);
            //
            if (direccionMedico != null)
            {
                this.emailTextBoxX.Text = direccionMedico.Email;
                this.telefonoMaskedTextBoxAdv.Text = direccionMedico.Telefono;
                this.cpNumericUpDown.Text = direccionMedico.CodigoPostal;
                this.estadoComboBoxEx.Text = direccionMedico.Ciudad;
                this.municipioComboBoxEx.Text = direccionMedico.Municipio;
                this.coloniaComboBoxEx.Text = direccionMedico.Colonia;
                this.calleTextBoxX.Text = direccionMedico.Calle;
                this.numExteriorNumericUpDown.Text = direccionMedico.NumeroExterior;
                this.numInteriorNumericUpDown.Text = direccionMedico.NumeroInterior;
            }
        }

        private bool Valida()
        {
            if (!string.IsNullOrEmpty(emailTextBoxX.Text) && !SIFNegocio.Helpers.Validadociones.IsValidEmail(emailTextBoxX.Text))
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
            municipio.Nombre = this.municipioComboBoxEx.Text;

            if (municipio == null || string.IsNullOrEmpty(municipio.Nombre))
            {
                return;
            }

            coloniasBindingsource = new BindingSource();
            coloniasBindingsource.DataSource = estadoN.CargaColonias(municipio);

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

        private bool GuardaDireccion()
        {
            bool esNuevo = false;

            if (direccionMedico == null)
            {
                esNuevo = true;
                direccionMedico = new SIFModelo.DireccionMedico();
            }

           

            direccionMedico.MedicoID = Medico.ID;
            direccionMedico.TipoDireccion = Medico.TipoConsulta;

            direccionMedico.Email = this.emailTextBoxX.Text;
            direccionMedico.Telefono = this.telefonoMaskedTextBoxAdv.Text;
            direccionMedico.CodigoPostal = this.cpNumericUpDown.Text;
            direccionMedico.Ciudad = this.estadoComboBoxEx.Text;
            direccionMedico.Municipio =  municipioComboBoxEx.Text;
            direccionMedico.Colonia = this.coloniaComboBoxEx.Text;
            direccionMedico.Calle = this.calleTextBoxX.Text;
            direccionMedico.NumeroExterior = this.numExteriorNumericUpDown.Text;
            direccionMedico.NumeroInterior = this.numInteriorNumericUpDown.Text;
            
            if (esNuevo)
            {
                return MedicoN.NuevoDireccion(direccionMedico);
            }
            else
            {
                return MedicoN.ModificarDireccion(direccionMedico);
            }

            return false;
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (Valida())
            {
                if (this.GuardaDireccion())
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void cancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void DireccionMedicoForm_Load(object sender, EventArgs e)
        {
            this.CargaEstados();

            this.inicializa();

            if (Medico.ID == 0)
            {
                this.estadoComboBoxEx.Text = "Puebla";
                this.municipioComboBoxEx.Text = "Puebla";
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
            //this.CargaCPS();
        }

    }
}