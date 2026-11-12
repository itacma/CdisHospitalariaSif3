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
    public partial class SeleccionarCliente : DevComponents.DotNetBar.Metro.MetroForm
    {
        public SIFNegocio.ReportesAdmin.Comercializacion _comercializacionNegocio;

        public SeleccionarCliente()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            _comercializacionNegocio = new SIFNegocio.ReportesAdmin.Comercializacion();
        }

        private void SeleccionarCliente_Load(object sender, EventArgs e)
        {
            comboBoxCliente.Items.Clear();
            var ListaClientes = _comercializacionNegocio.CargaClientesConvenio().DataSource as List<ComercializacionMod>;
            comboBoxCliente.DataSource = ListaClientes;
            comboBoxCliente.DisplayMember = "NOMBRE";
            comboBoxCliente.ValueMember = "CLIENTES_ID";                        
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            int clienteId = Convert.ToInt32(comboBoxCliente.SelectedValue);
            var detalle = _comercializacionNegocio.ObtenerSaldoPorCliente(clienteId);

            if (detalle == null)
            {
                MessageBox.Show("No se encontró información para este cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                ConsultarSaldo consulta = new ConsultarSaldo(clienteId);
                consulta.ShowDialog();
            }

            this.Close();
        }
    }
}
