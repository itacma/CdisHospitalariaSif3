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
    public partial class RecetaMedicoForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public RecetaMedicoForm()
        {
            InitializeComponent();
        }

        public SIFModelo.Receta receta = new SIFModelo.Receta();

        private bool validaReceta()
        {
            if (string.IsNullOrEmpty(this.textBoxX1.Text))
            {
               MessageBox.Show("Ingrese el numero de la receta");
                return false;
            }

            if (string.IsNullOrEmpty(this.textBoxX2.Text))
            {
               MessageBox.Show("Debe escribir el nombre del médico o su cedula");
                return false;
            }

            receta.NumeroReceta = textBoxX1.Text;
            receta.Medico = textBoxX2.Text;
            receta.FechaEmision = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

            return true;
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void CancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void textBoxX2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.aceptarButtonX_Click(null, null);
            }
        }
    }
}
