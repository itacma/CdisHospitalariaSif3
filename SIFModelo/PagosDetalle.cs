using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class PagosDetalle
    {
        public int NUM_PAGO
        {
            get;
            set;
        }

        public int SUCURSAL_ID
        {
            get;
            set;
        }
        public DateTime FECHA
        {
            get;
            set;
        }

        public int TIPO_PAGO_ID
        {
            get;
            set;
        }

        public decimal COMISION
        {
            get;
            set;
        }

        public decimal IMPORTE
        {
            get;
            set;
        }

        public string NUM_CUENTA
        {
            get;
            set;
        }

        public string TIPO_PAGO_NOMBRE { get; set; }

        public bool EsValeDevolucion { get; set; }

        public decimal PAGO_COMPLETO { get; set; }

        public string REMISION_ID { get; set; }
    }
}
