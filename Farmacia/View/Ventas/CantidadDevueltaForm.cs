using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Ventas
{
    public partial class CantidadDevueltaForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public CantidadDevueltaForm(SIFModelo.RemisionDetalle detalle)
        {
            InitializeComponent();

            this.detalle = detalle;
            this.AsignaCantidades();
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
            this.CantidadADevolver = System.Convert.ToInt32(cantidadNumericUpDown.Value);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void CancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void cantidadNumericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.aceptarButtonX_Click(null, null);
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.CancelarButtonX_Click(null, null);
            }
        }

        private void CantidadDevueltaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
