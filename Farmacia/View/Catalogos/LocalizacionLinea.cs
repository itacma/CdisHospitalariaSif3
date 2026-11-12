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
    /// <summary>
    /// Cambia la contraseña del usuario
    /// </summary>
    public partial class LocalizacionLinea : DevComponents.DotNetBar.Metro.MetroForm
    {
        public LocalizacionLinea()
        {
            InitializeComponent();
            cargarLineas();
        }
        public Boolean unaLinea = true;

        private void cargarLineas()
        {
            SIFNegocio.Inventario.Inventario logica = new SIFNegocio.Inventario.Inventario();

            cmbLinea.DataSource = logica.CargarLineas();
            cmbLinea.DisplayMember = "Fila";
            
        }
        
        private void validarLinea()
        {
            int x;
            unaLinea = int.TryParse(cmbLinea.SelectedItem.ToString(), out x);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
            return;
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            validarLinea();
        }

        private void CancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void usuarioTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void ckbTodasLasLineas_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTodasLasLineas.Checked == true)
            {
                cmbLinea.SelectedIndex = 0;
                cmbLinea.Enabled = false;
            }
            else 
            {
                cmbLinea.Enabled = true;
            }
        }
    }
}
