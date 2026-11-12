using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.WebServices
{
    public class FelControl
    {
        public string NUM_REMISION { get; set; }

        public string FACTURA { get; set; }

        public string PATH_FACTURA { get; set; }

        public DateTime FECHA_ALTA { get; set; }

        public string ACTIVO { get; set; }

        public DateTime FECHA_BAJA { get; set; }

        public string UUID { get; set; }

        public string ACUSE_CANCELACION { get; set; }

        public DateTime FECHA_ENVIO { get; set; }

        public string MSG_RESPUESTA { get; set; }

        public string TIPO_CFDI { get; set; }
    }
}
