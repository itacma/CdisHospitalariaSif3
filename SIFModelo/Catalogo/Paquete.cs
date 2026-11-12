using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Paquete
    {
        public int ID
        { 
            get; 
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public Tipos.SiNo Activo
        {
            get;
            set;
        }

        public DateTime FechaAlta
        {
            get;
            set;
        }

        public DateTime FechaBaja
        {
            get;
            set;
        }

    }
}
