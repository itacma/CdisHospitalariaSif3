using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.WebServices
{
    public class TarjetaPfizer
    {
        public string TarjetaID
        {
            get;
            set;
        }

        public int ClienteID
        {
            get;
            set;
        }

        public string SesionID
        {
            get;
            set;
        }

        public string NumeroConfirmacion { get; set; }
    }
}
