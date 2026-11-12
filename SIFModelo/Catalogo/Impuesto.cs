using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Impuesto
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

        public decimal Porcentaje
        {
            get;
            set;
        }

        public DateTime VigenciaInicio
        {
            get;
            set;
        }

        public DateTime VigenciaFin
        {
            get;
            set;
        }


        public Tipos.SiNo Activo { get; set; }
    }
}
