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
    public partial class ValeSubrogacionForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ValeSubrogacionForm()
        {
            InitializeComponent();
            //ValeFechaDateTimeInput.CustomFormat = "MM dd yyyy hh mm ss";  
            this.ValeTextBoxX.Focus();
        }
        public SIFModelo.Valesubrogacion Vale=new SIFModelo.Valesubrogacion();

        private bool validaLoteCaducidad()
        {
            if (string.IsNullOrEmpty(this.ValeTextBoxX.Text) || string.IsNullOrWhiteSpace(this.ValeTextBoxX.Text))
            {
               MessageBox.Show("Ingrese el No Vale");
                this.ValeTextBoxX.Focus();
                return false;
            }

            if (this.ValeFechaDateTimeInput.Value == null || this.ValeFechaDateTimeInput.Value == new DateTime())
            {
               MessageBox.Show("Seleccione la fecha de del vale");
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
            if (this.validaLoteCaducidad())
            {
                Vale.FechaVale = ValeFechaDateTimeInput.Value;
                Vale.NoVale= ValeTextBoxX.Text;
                Vale.Tipo = "CB";

                if (especialidadRadioButton.Checked)
                {
                    Vale.Tipo = "AE";
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void ValeFechaDateTimeInput_Click(object sender, EventArgs e)
        {

        }
    }
}
