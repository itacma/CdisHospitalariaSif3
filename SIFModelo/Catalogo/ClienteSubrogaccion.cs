using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class ClienteConvenio
    {
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// El tipo de pago relacionado con el catalogo de tipos de pago
        /// </summary>
        public int TipoPagoID
        {
            get;
            set;
        }

        public int DiasPlazo
        {
            get;
            set;
        }

        public Tipos.CondicionVenta CondicionVenta
        {
            get;
            set;
        }

        /// <summary>
        /// Dias en que vence el convenio
        /// </summary>
        public int DiaVencimiento
        {
            get;
            set;
        }

        public int PorDesc
        {
            get;
            set;
        }
        
        public int PorScosto
        {
            get;
            set;
        }

        public decimal Saldo
        {
            get;
            set;
        }

        public decimal LimiteCredito
        {
            get;
            set;
        }
        public String numCta
        {
            get;
            set;
        }
        public Tipos.SiNo PrecioFijo
        {
            get;
            set;
        }
    }
}
