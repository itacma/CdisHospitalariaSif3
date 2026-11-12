using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.WebServices
{
    public class TarjetaNadro
    {

        public string NumeroTarjeta
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

        public string Respuesta { get; set; }

        public string NumeroConfirmacion { get; set; }
    }
}
