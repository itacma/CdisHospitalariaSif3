using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;

namespace SIF.View.Subrogacion
{
    public partial class CamposForm : DevComponents.DotNetBar.Metro.MetroForm
    {   public String ListaArg; 
        public CamposForm(bool PrecioFijo)
        {
            InitializeComponent();
            if (PrecioFijo)
            {
                this.listBox2.Items.AddRange(new object[] {
            "No Remisión",
            "Anexo",
            "Codigo Cliente",
            "Nombre Producto Cliente",
            "Componente Activo Cliente",
            "Tipo Medicamento Cliente",
            "Codigo Articulo",
            "Nombre Producto",
            "Nombre2 SAL",
            "Componente Activo",
            "Tipo Medicamento",
            "Laboratorio",
            "Proveedor",
            "Tipo Descuento",
                "Tipo Vale",

                });
            }
            else
            {
                this.listBox2.Items.AddRange(new object[] {
            "No Remisión",
            "Codigo Articulo",
            "Nombre Producto",
            "Componente Activo",
            "Tipo Medicamento",
            "Laboratorio",
            "Proveedor",
            "Tipo Descuento",
                "Tipo Vale"});
            }

        }


        private void inicializa()
        {
        }

        
        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                ListaArg = "";
                foreach (String X in listBox1.Items)
                { 
                    ListaArg=ListaArg+"{"+X +"}";
                }
                this.Close();
        }

        private void cancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null)
            {
                return;
            }
            listBox1.Items.Add(listBox2.SelectedItem);
            listBox2.Items.Remove(listBox2.SelectedItem);
            
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
               MessageBox.Show("Debe seleccionar el concepto");
                return;
            }

            listBox2.Items.Add(listBox1.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            foreach (String Item in listBox2.Items)
            {
                listBox1.Items.Add(Item);
            }
            listBox2.Items.Clear();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            foreach (String Item in listBox1.Items)
            {
                listBox2.Items.Add(Item);
            }
            listBox1.Items.Clear();
        }


    }
}