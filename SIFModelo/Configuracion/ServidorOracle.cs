using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Configuracion
{
    public class ServidorOracle
    {
        public string NombreServicio
        {
            get;
            set;
        }

        public string TipoConexion
        {
            get;
            set;
        }

        public string Protocolo
        {
            get;
            set;
        }

        public string Host
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

        public string Password
        {
            get;
            set;
        }

        public string CadenaConexion
        {
            get;
            set;
        }
    }
}
