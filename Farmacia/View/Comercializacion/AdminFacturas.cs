using DevComponents.DotNetBar.SuperGrid;
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
    public partial class AdminFacturas : Templates.CatalogoUserControl
    {
        private SIFNegocio.ReportesAdmin.Comercializacion _comercializacionNegocio = new SIFNegocio.ReportesAdmin.Comercializacion();
        int Cual = 0;

        public AdminFacturas()
        {
            InitializeComponent();
            CargarFacturas();
        }

        private void radioBtnActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnActivo.Checked)
            {
                Cual = 0;
                BuscarFacturas();
            }
        }

        private void radioBtnCerrado_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnCerrado.Checked)
            {
                Cual = 1;
                BuscarFacturas();
            }
        }

        private void radioBtnCancelado_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnCancelado.Checked)
            {
                Cual = 2;
                BuscarFacturas();
            }
        }

        private void radioButtonTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnCancelado.Checked)
            {
                Cual = 3;
                BuscarFacturas();
            }
        }

        private void BuscarFacturas()
        {

            List<ComercializacionMod> lista;

            switch (Cual)
            {
                case 0:
                    lista = _comercializacionNegocio.BuscarFacturasPorEstado("ACTIVO"); 
                    break;
                case 1:
                    lista = _comercializacionNegocio.BuscarFacturasPorEstado("CERRADO"); 
                    break;
                case 2:
                    lista = _comercializacionNegocio.BuscarFacturasPorEstado("CANCELADO"); 
                    break;
                case 3:
                    lista = _comercializacionNegocio.ObtenerFacturasConvenio();
                    break;
                default:
                    lista = new List<ComercializacionMod>();
                    break;
            }

            if (lista.Any())
            {
                superGridControl1.PrimaryGrid.Rows.Clear();
                superGridControl1.PrimaryGrid.DataSource = lista;
            }
            else
            {
                MessageBox.Show("No se encontraron registros.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                superGridControl1.PrimaryGrid.DataSource = null;
            }
        }

        private void AceptarButtonItem_Click(object sender, EventArgs e)
        {
            var selectedRows = superGridControl1.PrimaryGrid.SelectedRows.Cast<GridRow>().ToList();

            if (!selectedRows.Any())
            {
                MessageBox.Show("Por favor selecciona una factura");
                return;
            }

            var selectedRow = selectedRows[0];

            if (selectedRow != null)
            {
                string estado = selectedRow.Cells["ACTIVO"]?.Value?.ToString();


                if (estado != "S" && estado != "ACTIVO")
                {
                    MessageBox.Show("Solo se pueden editar facturas activas.");
                    //return;
                    CargarFacturas();
                }

                try
                {
                    int cassId = Convert.ToInt32(selectedRow.Cells["CASS_ID"].Value);
                    string numFactura = selectedRow.Cells["NUMFACTURA"]?.Value?.ToString();
                    string folio = selectedRow.Cells["FOLIOFACTURA"]?.Value?.ToString();
                    string comentarios = selectedRow.Cells["COMENTARIOS"]?.Value?.ToString();
                    DateTime fechaFactura = Convert.ToDateTime(selectedRow.Cells["FECHAFACTURA"].Value);
                    decimal total = Convert.ToDecimal(selectedRow.Cells["TOTAL"].Value);
                    string usuario = Helpers.Sesion.Usuario.UsuariosID.ToString();

                    var factura = new ComercializacionMod
                    {
                        CASS_ID = cassId,
                        NUMFACTURA = numFactura,
                        FOLIOFACTURA = folio,
                        COMENTARIOS = comentarios,
                        FECHAFACTURA = fechaFactura,
                        TOTAL = total,
                        USUARIOALTA = usuario
                    };

                    bool exito = _comercializacionNegocio.ActualizarFactura(factura);

                    if (exito)
                    {
                        MessageBox.Show("Factura actualizada correctamente.");
                        CargarFacturas(); // Recarga el grid
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar la factura.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar los cambios: " + ex.Message);
                }
            }
        }

        private void AgregarButtonItem_Click(object sender, EventArgs e)
        {
            //Botón para abrir formulario de Agregar Factura
            AgregarFactura fact = new AgregarFactura();
            fact.FormClosed += (s, args) => CargarFacturas();
            fact.ShowDialog();
        }

        private void CerrarButtonItem_Click(object sender, EventArgs e)
        {
            //Botón para cerrar una Factura
            var selectedRows = superGridControl1.PrimaryGrid.SelectedRows.Cast<GridRow>().ToList();

            if (!selectedRows.Any())
            {
                MessageBox.Show("Por favor selecciona una factura.");
                return;
            }

            var selectedRow = selectedRows[0];

            if (selectedRow != null)
            {
                SIFModelo.ReportesAdmin.ComercializacionMod factur = new SIFModelo.ReportesAdmin.ComercializacionMod
                {
                    CASS_ID = Convert.ToInt32(selectedRow.Cells["CASS_ID"].Value),
                    USUARIOALTA = Helpers.Sesion.Usuario.UsuariosID.ToString()
                };

                bool exito = _comercializacionNegocio.CerrarFacturasConvenio(factur);

                if (exito)
                {
                    MessageBox.Show("Factura cerrada correctamente.");
                    CargarFacturas();
                }
                else
                {
                    MessageBox.Show("Solo se pueden cerrar facturas activas");
                }
            }
        }

        private void CargarFacturas()
        {
            var lista = _comercializacionNegocio.ObtenerFacturasConvenio();
            superGridControl1.PrimaryGrid.DataSource = lista;
        }

        private void CancelarButtonItem_Click(object sender, EventArgs e)
        {
            var selectedRows = superGridControl1.PrimaryGrid.SelectedRows.Cast<GridRow>().ToList();

            if (!selectedRows.Any())
            {
                MessageBox.Show("Por favor selecciona una factura.");
                return;
            }

            var selectedRow = selectedRows[0];

            if (selectedRow != null)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Estás seguro que deseas cancelar la factura?",
                    "Confirmar cancelación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resultado != DialogResult.Yes)
                    return;

                ComercializacionMod factura = new ComercializacionMod
                {
                    CASS_ID = Convert.ToInt32(selectedRow.Cells["CASS_ID"].Value),
                    USUARIOALTA = Helpers.Sesion.Usuario.UsuariosID.ToString()
                };

                bool exito = _comercializacionNegocio.CancelarFacturaConvenio(factura);

                if (exito)
                {
                    MessageBox.Show("Factura cancelada correctamente.");
                    CargarFacturas();
                }
                else
                {
                    MessageBox.Show("No se puede cancelar una factura cerrada con fecha anterior al mes actual");
                }

            }
        }


        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void Back()
        {
            if (this.Mostrado && Owner.Owner.IsModalPanelDisplayed)
            {
                this.DesactivaComandos();
                Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = false;
            }
        }

        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();            
        }
        public AdminSaldos Owner { get; set; }
        public bool Mostrado { get; set; }
        public void Muestra()
        {            
            if (Mostrado)
            {
                return;
            }

            this.Dock = DockStyle.Fill;
            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.ActivaComandos();
            this.Owner.DesactivaComandos();
            Mostrado = true;
        }

        public void ActivaComandos()
        {

        }

    }
}
