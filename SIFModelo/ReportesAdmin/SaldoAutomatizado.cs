using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.ReportesAdmin
{
    public class SaldoAutomatizado
    {
        public int CLIENTE_ID { get; set; }
        public string NOMBRE { get; set; }
        public DateTime FECHA_SALDO_INI { get; set; }
        public DateTime FECHA_SALDO_FIN { get; set; }

        public DateTime ULT_FECHA_MODIFICACION { get; set; }
        public decimal SALDO_CREDITO { get; set; }
        public decimal SALDO_CARGO { get; set; }
        public decimal SALDO_ABONO { get; set; }
        public decimal SALDO_DISPONIBLE { get; set; }
        public string ACTIVO { get; set; }

    }
}
