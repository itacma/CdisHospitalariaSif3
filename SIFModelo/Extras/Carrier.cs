using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Extras
{
    public class Carrier
    {
        public int CarrierID
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
    }
}
