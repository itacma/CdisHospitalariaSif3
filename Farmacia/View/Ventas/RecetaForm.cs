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
    public partial class RecetaForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public RecetaForm()
        {
            InitializeComponent();
            ValeFechaDateTimeInput.CustomFormat = "MM dd yyyy";  
            this.ValeTextBoxX.Focus();
        }
        //public SIFModelo.Valesubrogacion Vale=new SIFModelo.Valesubrogacion();
        public DateTime fechaReceta;
        public string Noreceta;
        public string tipo;
        private bool validaLoteCaducidad()
        {
            if (string.IsNullOrEmpty(this.ValeTextBoxX.Text) || string.IsNullOrWhiteSpace(this.ValeTextBoxX.Text))
            {
               MessageBox.Show("Ingrese el No de Receta");
                this.ValeTextBoxX.Focus();
                return false;
            }

            if (this.ValeFechaDateTimeInput.Value == null || this.ValeFechaDateTimeInput.Value == new DateTime())
            {
               MessageBox.Show("Seleccione la fecha de de la Receta");
                this.ValeFechaDateTimeInput.Focus();
                return false;
            }

            return true;
        }

        private void LoteCaducidadForm_Load(object sender, EventArgs e)
        {
            ValeTextBoxX.Focus();
            this.ValeTextBoxX.SelectAll();
            ValeTextBoxX.TabIndex = 0;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            fechaReceta = this.ValeFechaDateTimeInput.Value;
            Noreceta = this.ValeTextBoxX.Text;

            if (this.ManualRadioButton.Checked == false && this.ElectronicaRadioButton.Checked == false)
                MessageBox.Show("Elija un tipo de Receta");
            else
            {
                if (this.ManualRadioButton.Checked == true)
                    tipo = "Manual";
                else if (this.ElectronicaRadioButton.Checked == true)
                    tipo = "Electronica";
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }  
          /*  if (this.validaLoteCaducidad())
            {
                Vale.FechaVale = ValeFechaDateTimeInput.Value;
                Vale.NoVale= ValeTextBoxX.Text;
                Vale.Tipo = "CB";

                if (ElectronicaRadioButton.Checked)
                {
                    Vale.Tipo = "AE";
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }*/
        }

        private void ValeFechaDateTimeInput_Click(object sender, EventArgs e)
        {

        }

        private void titleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
