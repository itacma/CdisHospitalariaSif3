using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.OrdenCompra
{
    public class TipoNcSaldoUtilizado
    {

        public string Id { get; set; }
        public int  Sucursal_id { get; set; }
        public int  Partida { get; set; }
        public string Concepto { get; set; }
        public string Folio_rdm { get; set; }
        public string Folio_referencia { get; set; }
        public Decimal Saldo { get; set; }
        public string Usuario_id { get; set; }
        public string Activo { get; set; }

    }
}
