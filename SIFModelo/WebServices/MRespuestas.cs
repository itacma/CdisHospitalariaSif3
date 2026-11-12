using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.WebServices
{
    public class MRespuestas
    {
        public class Producto
        {
            public int idEmpresa { get; set; }
            public string sku { get; set; }
            public int pr_id { get; set; }
        }

        public class RespuestaApi
        {
            public string status { get; set; }
            public string message { get; set; }
            public string error { get; set; }
            public string details { get; set; }
            public List<Producto> productos { get; set; }
        }



    }
}





