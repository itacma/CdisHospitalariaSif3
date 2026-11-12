using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.ReportesAdmin
{
    public class ComercializacionMod
    {
        public int CASS_ID { get; set; }
        public int CLIENTES_ID { get;  set; }
        public string NOMBRE { get;  set; }
        public string ACTIVO { get;  set; }
        public string NUMFACTURA { get; set; }
        public string FOLIOFACTURA { get; set; }
        public string COMENTARIOS { get; set; }
        public DateTime FECHAFACTURA { get; set; }
        public DateTime FECHA_CARGA { get; set; }
        public decimal TOTAL { get; set; }
        public string USUARIOALTA { get; set; }
    }

}
