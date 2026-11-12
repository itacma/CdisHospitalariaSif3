using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Subrogacion
{
    public partial class AnexoTipoValeForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public AnexoTipoValeForm()
        {
            InitializeComponent();
            tipoValeComboBoxEx.SelectedIndex = 0;
            clienteComboBoxEx.SelectedIndex = 0;
        }

       public string Anexo = "";
       public string TipoVale = "";
       public string ClienteID = "";

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            this.Anexo = this.anexoNumericUpDown.Value.ToString();
            this.TipoVale = tipoValeComboBoxEx.Text;
            this.ClienteID = clienteComboBoxEx.SelectedItem.ToString();


            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void tipoValeComboBoxEx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.aceptarButtonX_Click(null, null);
            }
        }

        
    }
}
