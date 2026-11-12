using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.Templates
{
    public partial class ListaUserControl : UserControl
    {
        public ListaUserControl()
        {
            InitializeComponent();

            if (Helpers.Sesion.Sucursal == null)
            {
                Helpers.Sesion.Sucursal = new SIFModelo.Sucursal();
                Helpers.Sesion.Usuario = new SIFModelo.Usuario();
                Helpers.Sesion.Usuario.Genero = SIFModelo.Tipos.Genero.MASCULINO;
            }

            this.sucursalLabel.Text = "Sucursal: " + Helpers.Sesion.Sucursal.Nombre;
            this.apellidosLabel.Text = Helpers.Sesion.Usuario.Apellidos;
            this.nombreLabel.Text = Helpers.Sesion.Usuario.Nombre;
            this.fotoPictureBox.Image = Helpers.Sesion.Foto;
        }

        private void backButton_Click(object sender, EventArgs e)
        {

        }
    }
}
