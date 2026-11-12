using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class hupMed
    {
        public string IDmed
        {
            get;
            set;
        }

       public string Nombre
        {
            get;
            set;
        }
        public string Especialidad
        {
            get;
            set;
        }
        public string Cedula
        {
            get;
            set;
        }


        public Tipos.SiNo Estado { get; set; }
    }
}
