using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Configuracion
{
    public class Nadro
    {
        private string cadena;
        public string Cadena
        {
            get { return cadena; }
            set{cadena = value;}
        }

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string contrasena;      
        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        private int sucursal;
        public int Sucursal
        {
            get { return sucursal; }
            set { sucursal = value; }
        }

    }
}
