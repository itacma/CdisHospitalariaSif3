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
    public partial class MotivoCancelacionCantidadForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public MotivoCancelacionCantidadForm(SIFModelo.RemisionDetalle detalle)
        {
            InitializeComponent();
            this.cargaMotivos();
            this.detalle = detalle;
            AsignaCantidades();
            this.articuloLabel.Text = detalle.Nombre1 + " [" + detalle.ArticuloID + "]";
            
        }
       public SIFModelo.TipoDevolucion TipoDevolucion;
        private void cargaMotivos()
        {
            SIFNegocio.TipoDevolucions tipoN = new SIFNegocio.TipoDevolucions();
            BindingSource tipoBS = new BindingSource();
            tipoBS.DataSource = tipoN.BuscarVentas().DataSource;

            this.motivoCancelacionComboBoxEx.DataSource = tipoBS;
            motivoCancelacionComboBoxEx.DisplayMember = "Nombre";
            motivoCancelacionComboBoxEx.ValueMember = "TipoDevolucionID";
        }

        SIFModelo.RemisionDetalle detalle;
        SIFNegocio.Remision remisionL = new SIFNegocio.Remision();

        private void AsignaCantidades()
        {
            int cantidadDevuelta = remisionL.CantidadDevuelta(detalle);
            this.cantidadDevueltaLabel.Text = cantidadDevuelta.ToString();
            cantidadNumericUpDown.Maximum = detalle.CantidadRemision - cantidadDevuelta;
            cantidadNumericUpDown.Value = cantidadNumericUpDown.Maximum;
        }

        public int CantidadADevolver = 0;
        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            TipoDevolucion = motivoCancelacionComboBoxEx.SelectedItem as SIFModelo.TipoDevolucion;
            TipoDevolucion.Observaciones = this.textBoxX1.Text;
            this.CantidadADevolver = System.Convert.ToInt32(cantidadNumericUpDown.Value);

            if (this.CantidadADevolver == 0)
            {
                MessageBox.Show("La cantidad a devolver debe ser mayor a cero");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void MotivoCancelacionCantidadForm_Load(object sender, EventArgs e)
        {
           
        }

        private void cancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
