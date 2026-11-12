using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Inventarios
{
    public class ListaPrecios
    {
        public string ARTICULO_ID { get; set; }
        public int SUCURSAL_ID { get; set; }
        public decimal PRECIO_VENTA { get; set; }
        public decimal PRECIO_VENTA_MAX { get; set; }
        public decimal PRECIO_VENTA_FARM { get; set; }
        public decimal PRECIO_COSTO { get; set; }
        public decimal COSTO_PROM { get; set; }
        public decimal COSTO_ULT_COMPRA { get; set; }
        public DateTime FECHA_ALTA { get; set; }
        public DateTime FECHA_BAJA { get; set; }
        public int IMP_COMPRA { get; set; }
        public int IMP_VENTA { get; set; }
        public SIFModelo.Tipos.SiNo ACTIVO { get; set; }
        //L 20/11/2013
        //public decimal PORCENTAJE_IMP { get; set; }
    }
}
