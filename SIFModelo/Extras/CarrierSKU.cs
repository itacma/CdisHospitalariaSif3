using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Extras
{
    public class CarrierSKU
    {
        public int CarrierID
        {
            get;
            set;
        }

        public string SKU
        {
            get;
            set;
        }

        public decimal Monto
        {
            get;
            set;
        }

        public string Clave
        {
            get;
            set;
        }

        public SIFModelo.Tipos.SiNo Activo
        {
            get;
            set;
        }
    }
}
