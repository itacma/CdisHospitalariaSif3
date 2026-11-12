using Oracle.DataAccess.Client;
using SIFModelo.ReportesAdmin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Comercializacion
{
    public partial class Saldos : DevComponents.DotNetBar.Metro.MetroForm
    {
        public SIFNegocio.ReportesAdmin.Comercializacion _comercializacionNegocio;

        public Saldos()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            _comercializacionNegocio = new SIFNegocio.ReportesAdmin.Comercializacion();
        }

        private void Saldos_Load(object sender, EventArgs e)
        {
            comboBoxCliente.Items.Clear();
            var ListaClientes = _comercializacionNegocio.CargaClientesConvenio().DataSource as List<ComercializacionMod>;
            comboBoxCliente.DataSource = ListaClientes;
            comboBoxCliente.DisplayMember = "NOMBRE";
            comboBoxCliente.ValueMember = "CLIENTES_ID";


            comboBoxMes.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                string mes = new DateTime(2000, i, 1).ToString("MMMM", new System.Globalization.CultureInfo("es-ES")).ToUpper();
                comboBoxMes.Items.Add(mes);
            }

        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            try
            {
                if (!decimal.TryParse(txtBoxSaldo.Text, out decimal saldoCredito))
                {
                    MessageBox.Show("Ingrese un saldo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var datos = new PeriodoSaldo
                {
                    ClienteId = (int)comboBoxCliente.SelectedValue,
                    Mes = comboBoxMes.SelectedIndex + 1,
                    Year = DateTime.Now.Year,
                    SaldoCredito = saldoCredito,
                    Usuario = Helpers.Sesion.Usuario.UsuariosID.ToString()

                };

                bool exito = SIFNegocio.ReportesAdmin.Comercializacion.InsertarNuevoSaldo(datos);

                if (exito)
                {
                    MessageBox.Show("Saldo guardado correctamente.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al guardar el saldo.");
                }
            }
            catch (OracleException ex)
            {
                //MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ex.Number == 20002) 
                {
                    MessageBox.Show("⚠ Ya existe un saldo activo con el mes seleccionado",
                                    "Advertencia",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error inesperado: " + ex.Message,
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarCampos()
        {
            if (comboBoxCliente.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxCliente.Focus();
                return false;
            }

            if (comboBoxMes.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un mes.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxMes.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBoxSaldo.Text))
            {
                MessageBox.Show("El saldo no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxSaldo.Focus();
                return false;
            }

            if (!decimal.TryParse(txtBoxSaldo.Text, out _))
            {
                MessageBox.Show("El saldo debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxSaldo.Focus();
                return false;
            }

            return true;
        }

    }
}
