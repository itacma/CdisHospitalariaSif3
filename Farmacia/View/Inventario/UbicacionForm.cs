using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Inventario
{
    public partial class UbicacionForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public UbicacionForm(string ubicacion)
        {
            InitializeComponent();
            this.Ubicacion = ubicacion;
            estableceUbicacion();
        }

        string fila = "";
        string anaquel = "";
        string nivel = "";

        public void estableceUbicacion()
        {
            string[] claves = Ubicacion.Split('|');
           
            if (claves.Length >= 3)
            {
                fila = claves[0];
                anaquel = claves[1];
                nivel = claves[2];
            }

            textBoxX1.Text = fila;
            textBoxX2.Text = anaquel;
            textBoxX3.Text = nivel;

        }

        private bool valida()
        {
            if (string.IsNullOrEmpty(this.textBoxX1.Text) || string.IsNullOrWhiteSpace(textBoxX1.Text))
            {
               MessageBox.Show("Ingrese la fila");
                this.textBoxX1.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.textBoxX2.Text) || string.IsNullOrWhiteSpace(textBoxX2.Text))
            {
               MessageBox.Show("Ingrese el anaquel");
                this.textBoxX1.Focus();
                return false;
            }

            if (!this.textBoxX2.Text.ToString().IsInteger())
            {
               MessageBox.Show("Debe ingresar un número de anaquel");
                textBoxX2.SelectAll();
                textBoxX2.Focus();
                return false;
            }


            if (!this.textBoxX1.Text.IsInteger())
            {
               MessageBox.Show("Debe especificar el número de fila");
                this.textBoxX1.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.textBoxX3.Text) || string.IsNullOrWhiteSpace(textBoxX3.Text))
            {
               MessageBox.Show("Ingrese el nivel");
                this.textBoxX3.Focus();
                return false;
            }

            Ubicacion = textBoxX1.Text + "|" + textBoxX2.Text + "|" + textBoxX3.Text;

            return true;
        }

        public string Ubicacion;

        private void CancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (this.valida())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }


    }
}
