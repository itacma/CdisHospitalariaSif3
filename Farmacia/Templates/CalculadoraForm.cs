using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.Templates
{
    public partial class CalculadoraForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public CalculadoraForm()
        {
            InitializeComponent();
        }

        public Double Resultado;

        private void Aceptar()
        {
          Resultado =  this.calculator1.Value;
          this.DialogResult = System.Windows.Forms.DialogResult.OK;
          this.Close();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }
    }
}