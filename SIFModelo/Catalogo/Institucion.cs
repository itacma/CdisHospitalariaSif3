using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Catalogo
{
    public class Institucion
    {
        public int institucion_id
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public int cliente_id
        {
            get;
            set;
        }
    }
}
