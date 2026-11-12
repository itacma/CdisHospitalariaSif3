using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Configuracion
{
    public class Pfizer
    {
        private string programaID;
        public string ProgramaID
        {
            get { return programaID; }
            set { programaID = value; }
        }

        private int cadena;
        public int Cadena
        {
            get { return cadena; }
            set { cadena = value; }
        }

        private int sucursal;
        public int Sucursal
        {
            get { return sucursal; }
            set{sucursal = value;}
        }

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
    }
}
