using DevComponents.DotNetBar.SuperGrid;
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
    public partial class AdminSaldos : Templates.CatalogoUserControl
    {
        private SIFNegocio.ReportesAdmin.Comercializacion _comercializacionNegocio = new SIFNegocio.ReportesAdmin.Comercializacion();
        int Cual = 0;
  
        public AdminSaldos()
        {
            InitializeComponent();
            CargarSaldos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string estado = ObtenerEstadoDesdeRadio(); 
            string texto = txtBoxBuscar.Text.Trim();

            int clienteId;
            int? id = int.TryParse(texto, out clienteId) ? (int?)clienteId : null;
            string nombre = id.HasValue ? null : texto;

            var lista = _comercializacionNegocio.BuscarSaldosCliente(id, nombre, estado);

            if (lista.Any())
            {
                superGridControl1.PrimaryGrid.DataSource = lista;
            }
            else
            {
                MessageBox.Show("No se encontraron registros para el cliente indicado.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                superGridControl1.PrimaryGrid.DataSource = null;
            }
        }

        private string ObtenerEstadoDesdeRadio()
        {
            if (radioBtnActivo.Checked) return "ACTIVO";
            if (radioBtnCerrado.Checked) return "CERRADO";
            if (radioBtnCancelado.Checked) return "CANCELADO";

            return null;
        }


        private void CargarSaldos()
        {
            var lista = _comercializacionNegocio.ObtenerSaldosConvenio();
            superGridControl1.PrimaryGrid.DataSource = lista;

        }

        private void radioBtnActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnActivo.Checked)
            {
                Cual = 0;
                Buscar();
            }
        }

        private void radioBtnCerrado_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnCerrado.Checked)
            {
                Cual = 1;
                Buscar();
            }
        }

        private void radioBtnCancelado_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnCancelado.Checked)
            {
                Cual = 2;
                Buscar();
            }
        }

        private void CerrarButtonItem_Click(object sender, EventArgs e)
        {
            //Boton para cerrar saldo
            var selectedRows = superGridControl1.PrimaryGrid.SelectedRows.Cast<GridRow>().ToList();

            if (!selectedRows.Any())
            {
                MessageBox.Show("Por favor selecciona un Saldo.");
                return;
            }

            var selectedRow = selectedRows[0];

            if (selectedRow != null)
            {
                // Validar estado del saldo
                string estado = selectedRow.Cells["Activo"]?.Value?.ToString()?.Trim().ToUpper() ?? "";

                if (estado != "ACTIVO")
                {
                    MessageBox.Show("Solo se pueden cerrar saldos que estén ACTIVOS.");
                    return;
                }

                SIFModelo.ReportesAdmin.Saldos salds = new SIFModelo.ReportesAdmin.Saldos
                {
                    CASS_ID = Convert.ToInt32(selectedRow.Cells["CASS_ID"].Value),
                    Usuario = Helpers.Sesion.Usuario.UsuariosID.ToString()
                };

                bool exito = _comercializacionNegocio.CerrarSaldosConvenio(salds);

                if (exito)
                {
                    MessageBox.Show("Saldo cerrado correctamente.");
                    CargarSaldos();
                }
                else
                {
                    MessageBox.Show("Error al cerrar el saldo.");
                }
            }
        }

        private void FacturasButtonItem_Click(object sender, EventArgs e)
        {
            AdminFacturas facturas = new AdminFacturas();
            facturas.Owner = this;
            facturas.Muestra();
        }

        private void ConsultarButtonItem_Click(object sender, EventArgs e)
        {
            SeleccionarCliente clienteSelec = new SeleccionarCliente();
            clienteSelec.ShowDialog();
        }

        private void GuardarButtonItem_Click(object sender, EventArgs e)
        {
            var selectedRows = superGridControl1.PrimaryGrid.SelectedRows.Cast<GridRow>().ToList();

            if (!selectedRows.Any())
            {
                MessageBox.Show("Por favor selecciona un saldo.");
                return;
            }

            var selectedRow = selectedRows[0];

            if (selectedRow != null)
            {
                int cassId = Convert.ToInt32(selectedRow.Cells["CASS_ID"].Value);
                decimal nuevoSaldo = Convert.ToDecimal(selectedRow.Cells["SaldoCredito"].Value);
                string usuario = Helpers.Sesion.Usuario.UsuariosID.ToString();

                var saldo = new SIFModelo.ReportesAdmin.Saldos
                {
                    CASS_ID = cassId,
                    SaldoCredito = nuevoSaldo,
                    Usuario = usuario
                };

                bool exito = _comercializacionNegocio.ActualizarSaldoCredito(saldo);

                if (exito)
                {
                    MessageBox.Show("Saldo actualizado correctamente.");
                    CargarSaldos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el saldo.");
                }
            }
        }

        private void CancelarButtonItem_Click(object sender, EventArgs e)
        {
            var selectedRows = superGridControl1.PrimaryGrid.SelectedRows.Cast<GridRow>().ToList();

            if (!selectedRows.Any())
            {
                MessageBox.Show("Por favor selecciona un Saldo.");
                return;
            }

            var selectedRow = selectedRows[0];

            if (selectedRow != null)
            {
                string estado = selectedRow.Cells["Activo"]?.Value?.ToString().ToUpper();

                if (estado == "CERRADO" || estado == "C")
                {
                    MessageBox.Show("No se puede cancelar un saldo que ya está cerrado.");
                    return;
                }

                SIFModelo.ReportesAdmin.Saldos salds = new SIFModelo.ReportesAdmin.Saldos
                {
                    CASS_ID = Convert.ToInt32(selectedRow.Cells["CASS_ID"].Value),
                    Usuario = Helpers.Sesion.Usuario.UsuariosID.ToString()
                };

                bool exito = _comercializacionNegocio.CancelarSaldosConvenio(salds);

                if (exito)
                {
                    MessageBox.Show("Saldo cancelado correctamente.");
                    CargarSaldos();
                }
                else
                {
                    MessageBox.Show("Error al cancelar el saldo.");
                }
            }
        }

        private void AgregarButtonItem_Click(object sender, EventArgs e)
        {
            Saldos saldo = new Saldos();
            saldo.FormClosed += (s, args) => CargarSaldos();
            saldo.ShowDialog();
        }

        
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void Back()
        {
            if (this.Mostrado && Owner.IsModalPanelDisplayed)
            {
                this.DesactivaComandos();
                Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = false;
            }
        }

        public void DesactivaComandos()
        {
            base.backButton.Shortcuts.Clear();
        }

        public MainForm Owner { get; set; }
        public bool Mostrado { get; set; }
        public void Muestra()
        {
            if (Mostrado)
            {
                return;
            }
            Mostrado = true;
            this.Dock = DockStyle.Fill;
            this.ActivaComandos();
            Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.Buscar();
        }

        public void ActivaComandos()
        {

        }

        public void Buscar()
        {
            string estado = "";

            switch (Cual)
            {
                case 0:
                    estado = "ACTIVO"; 
                    break;
                case 1:
                    estado = "CERRADO"; 
                    break;
                case 2:
                    estado = "CANCELADO"; 
                    break;
            }
            var lista = _comercializacionNegocio.BuscarSaldosPorEstado(estado);

            if (lista.Any())
            {
                superGridControl1.PrimaryGrid.Rows.Clear();
                superGridControl1.PrimaryGrid.Columns.Clear(); 
                superGridControl1.PrimaryGrid.DataSource = null;
                superGridControl1.PrimaryGrid.DataSource = lista;
            }
            else
            {
                MessageBox.Show("No se encontraron registros para el estado seleccionado.",
                         "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                superGridControl1.PrimaryGrid.DataSource = null;
            }

        }

    }
}
