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
    public partial class AgregarFactura : DevComponents.DotNetBar.Metro.MetroForm
    {
        public SIFNegocio.ReportesAdmin.Comercializacion _comercializacionNegocio;

        public AgregarFactura()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            _comercializacionNegocio = new SIFNegocio.ReportesAdmin.Comercializacion();
        }

        private void AgregarFactura_Load(object sender, EventArgs e)
        {
            comboBoxCliente.Items.Clear();

            var ListaClientes = _comercializacionNegocio.CargaClientesConvenio().DataSource as List<ComercializacionMod>;
            comboBoxCliente.DataSource = ListaClientes;
            comboBoxCliente.DisplayMember = "NOMBRE";
            comboBoxCliente.ValueMember = "CLIENTES_ID";
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            try
            {
                var factura = new ComercializacionMod
                {
                    CLIENTES_ID = ((ComercializacionMod)comboBoxCliente.SelectedItem).CLIENTES_ID,
                    NUMFACTURA = txtBoxNumFactura.Text,
                    FOLIOFACTURA = txtBoxFolioFactura.Text,
                    COMENTARIOS = txtBoxComentarios.Text,
                    FECHAFACTURA = dateTimePicker.Value,
                    TOTAL = decimal.Parse(txtBoxTotal.Text),
                    USUARIOALTA = Helpers.Sesion.Usuario.UsuariosID.ToString()
                };

                bool exito = _comercializacionNegocio.GuardarFacturaConvenio(factura);

                if (exito)
                {
                    MessageBox.Show("Factura guardada correctamente.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al guardar la factura.");
                }
            }
            catch (Oracle.DataAccess.Client.OracleException ex)
            {
                MessageBox.Show("Advertencia: " + ex.Message, "Validación de Factura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtBoxNumFactura.Text))
            {
                MessageBox.Show("El número de factura no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxNumFactura.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBoxFolioFactura.Text))
            {
                MessageBox.Show("El folio de factura no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxFolioFactura.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBoxComentarios.Text))
            {
                MessageBox.Show("El campo comentarios no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxComentarios.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBoxTotal.Text))
            {
                MessageBox.Show("El total no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxTotal.Focus();
                return false;
            }

            if (comboBoxCliente.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxCliente.Focus();
                return false;
            }

            return true;
        }

    }
}
