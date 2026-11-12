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
    public partial class MenuUserControl : UserControl
    {
        public MenuUserControl()
        {
            InitializeComponent();
        }

        private void MenuUserControl_Load(object sender, EventArgs e)
        {
#if DEBUG
            this.apellidosLabel.Text = "APELLIDO USUARIO";
            this.nombreUsuarioLabel.Text = "NOMBRE USUARIO";
            //this.fotoPictureBox.Image = Helpers.Sesion.Foto;
#else

            //this.sucursalLabel.Text = "Sucursal: " + Helpers.Sesion.Sucursal;
            this.apellidosLabel.Text = Helpers.Sesion.Usuario.Apellidos;
            this.nombreUsuarioLabel.Text = Helpers.Sesion.Usuario.Nombre;
            this.fotoPictureBox.Image = Helpers.Sesion.Foto;
#endif

        }
    }
}
