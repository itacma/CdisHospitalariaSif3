using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.ReportesAdmin
{
    public class PeriodoSaldo
    {
        public int CassId { get; set; }
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public int Mes { get; set; }
        public int Year { get; set; }
        public decimal SaldoCredito { get; set; }
        public DateTime FechaInicio => new DateTime(Year, Mes, 1);
        public DateTime FechaFin => new DateTime(Year, Mes, DateTime.DaysInMonth(Year, Mes),23,59,59);
        public string Activo { get; set; }
        public string Usuario { get; set; }
    }
}
