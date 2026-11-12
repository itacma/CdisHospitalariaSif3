using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Receta
    {

        public int RecetaID
        {
            get;
            set;
        }

        public string NumeroReceta
        {
            get;
            set;
        }

        public string Medico
        {
            get;
            set;
        }

        public DateTime FechaEmision
        {
            get;
            set;
        }
    }
}
