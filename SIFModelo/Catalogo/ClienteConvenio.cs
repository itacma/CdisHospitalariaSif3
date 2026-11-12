using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class ClienteSubrogaccion
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

        public Tipos.SiNo PRECIO_FIJO
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
        

        public Tipos.TipoClienteSub TipoClienteSub
        {
            get;
            set;
        }

        public Tipos.SiNo RET_5MILLAR
        {
            get;
            set;
        }

        public DateTime FECHA_INI
        {
            get;
            set;
        }

        public DateTime FECHA_FIN
        {
            get;
            set;
        }

        public Decimal TOT_FACTURADO
        {
            get;
            set;
        }

        public DateTime FECHA_ULTMOV
        {
            get;
            set;
        }
        
        public String PERIODOFAC
        {
            get;
            set;
        }

        public String numCta
        {
            get;
            set;
        }
        public Tipos.SiNo REQ_LOTE
        {
            get;
            set;
        }
        
    }
}
