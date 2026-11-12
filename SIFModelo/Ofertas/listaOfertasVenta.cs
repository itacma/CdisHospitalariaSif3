using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Ofertas
{
    public class listaOfertasVenta
    {

        public int lista_ofertas_id { get; set; }
        public string NOMBRE { get; set; }
        public string LISTA_SUCURSAL_ID { get; set; }
        public string ACTIVO { get; set; }
        public DateTime fecha_generada { get; set; }
        public DateTime fecha_alta { get; set; }
        public DateTime fecha_baja { get; set; }
        public decimal total { get; set; }
    }
}
