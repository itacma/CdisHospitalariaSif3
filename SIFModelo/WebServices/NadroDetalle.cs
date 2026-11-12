using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.WebServices
{
    public class NadroDetalle
    {
        public string NumeroRemision
        {
            get;
            set;
        }

        public long CantPagarNadro
        {
            get;
            set;
        }

        public long CantRegaloNadro
        {
            get;
            set;
        }

        public long CantAcumNadro
        {
            get;
            set;
        }

        public decimal PrecioFijo
        {
            get;
            set;
        }

        public decimal PrecDesctoNadro
        {
            get;
            set;
        }

        public decimal MontoDesctoNadro
        {
            get;
            set;
        }

        public double PorcenDesctoNadro
        {
            get;
            set;
        }

        public string REFERENCIA { get; set; }

        public bool SkuVta { get; set; }

        public string SkuMsg { get; set; }

        public string ArticuloID { get; set; }

        public decimal Precio { get; set; }

        public decimal PrecioMaximo { get; set; }

        public string CotizacionID { get; set; }

        public int Partida { get; set; }

        public decimal IVA { get; set; }

        public decimal PorcentajeIVA { get; set; }

        public int TipoPrecio { get; set; }
    }
}
