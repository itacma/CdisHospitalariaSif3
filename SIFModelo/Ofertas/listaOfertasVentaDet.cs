using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Ofertas
{
   public class listaOfertasVentaDet
    {
        public int lista_ofertas_id { get; set; }
        public string articulo_id { get; set; }
        public int partida { get; set; }
        public int cantidad { get; set; }
        public int beneficio_cant { get; set; }
        public int descuento { get; set; }
        public string activo { get; set; }
        public decimal importe_beneficio { get; set; }
        public string importe_pacto { get; set; }
        public string precio_de_compra { get; set; }
        public string aplicado_a { get; set; }
        public string nombre1 { get; set; }
    }
}
