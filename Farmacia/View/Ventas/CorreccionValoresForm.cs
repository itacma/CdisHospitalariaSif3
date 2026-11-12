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
    public partial class CorreccionValoresForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public CorreccionValoresForm(SIFModelo.Catalogo.CatalogoDataSet.VALORESRow valor)
        {
            this.Valor = valor;
            InitializeComponent();
            cargaValor();
        }

        SIFModelo.Catalogo.CatalogoDataSet.VALORESRow Valor;

        private void cargaValor()
        {
            this.recoleccionLabel.Text = Valor.RECOLECCION_NOMBRE;
            denominacionLabel.Text = Valor.DENOMINACIONES_NOMBRE;
            this.montoLabel.Text = Valor.IMPORTE.ToString("C2");
        }

        public decimal NuevoValor = 0;
        public int NuevaCantidad = 0;

        private bool CalculaDiferencia()
        {
            if (!correccionTextBoxX.Text.IsFloatPositive())
            {
               MessageBox.Show("El monto de la corrección debe ser numérico", "Correccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.correccionTextBoxX.SelectAll();
                correccionTextBoxX.Focus();
                return false;
            }
                NuevoValor = decimal.Parse(this.correccionTextBoxX.Text);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
                return true;
        }

        private void CancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            this.CalculaDiferencia();
        }
    }
}
