using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Configuracion
{
    public class Email
    {
        public string Servidor
        {
            get;
            set;
        }

        public int Puerto
        {
            get;
            set;
        }

        public string Usuario
        {
            get;
            set;
        }

        public string Contrasena
        {
            get;
            set;
        }

        public bool EsSSA
        {
            get;
            set;
        }
    }
}
