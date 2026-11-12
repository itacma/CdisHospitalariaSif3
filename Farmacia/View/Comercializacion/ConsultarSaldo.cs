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
    public partial class ConsultarSaldo : DevComponents.DotNetBar.Metro.MetroForm
    {
        private SIFNegocio.ReportesAdmin.Comercializacion _comercializacionNegocio = new SIFNegocio.ReportesAdmin.Comercializacion();
        private int _clienteId;
        public ConsultarSaldo(int clienteId)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            _clienteId = clienteId;
            ConsultarSaldoMetodo();
        }


        private void ConsultarSaldoMetodo()
        {
            var detalle = _comercializacionNegocio.ObtenerSaldoPorCliente(_clienteId);

            if (detalle != null)
            {
                codigoLabelX.Text = detalle.CLIENTE_ID.ToString();
                nombreLabelX.Text = detalle.NOMBRE;
                FechaInicioLabelX.Text = detalle.FECHA_SALDO_INI.ToString("dd/MM/yyyy");
                FechaFinlabelX7.Text = detalle.FECHA_SALDO_FIN.ToString("dd/MM/yyyy");
                FechaActualizacionlabelX8.Text = detalle.ULT_FECHA_MODIFICACION.ToString("dd/MM/yyyy HH:mm:ss");
                SaldoCreditolabelX9.Text = $"${detalle.SALDO_CREDITO:N2}";
                SaldoCargolabelX13.Text = $"${detalle.SALDO_CARGO:N2}";
                SaldoAbonolabelX7.Text = $"${detalle.SALDO_ABONO:N2}";
                SaldDisponiblelabelX8.Text = $"${detalle.SALDO_DISPONIBLE:N2}";
            }
            else
            {
                MessageBox.Show("No se encontró información para este cliente.");
            }
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
    }
}
