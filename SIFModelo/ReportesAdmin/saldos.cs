using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.ReportesAdmin
{
    public class Saldos
    {
        public int CASS_ID { get; set; }
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public decimal SaldoCredito { get; set; }
        public string Activo { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
