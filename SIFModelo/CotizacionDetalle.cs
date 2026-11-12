using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class CotizacionDetalle
    {
        public int SucursalID
        {
            get;
            set;
        }

        public string NumeroCotizacion
        {
            get;
            set;
        }
        public string NumRemision
        {
            get;
            set;
        }

        public int NumeroPartida
        {
            get;
            set;
        }

        public string ArticuloID
        {
            get;
            set;
        }

        public string Nombre1
        {
            get;
            set;
        }

        public string Nombre2
        {
            get;
            set;
        }

        public int CantidadCotizacion
        {
            get;
            set;
        }

        public decimal Precio
        {
            get;
            set;
        }

        public decimal IVA
        {
            get;
            set;
        }

        public int ImpuestoID
        {
            get;
            set;
        }

        public int DescuentoID
        {
            get;
            set;
        }



        public decimal PrecioCosto
        {
            get;
            set;
        }

        public decimal CantRem
        {
            get;
            set;
        }

        public decimal Descto
        {
            get;
            set;
        }

        public decimal PrecioVta
        {
            get;
            set;
        }

        public int PaqueteID
        {
            get;
            set;
        }

        public bool Validado { get; set; }

        public decimal Total { get; set; }

        public int PorcentajeDescuento { get; set; }

        public short RefOferta { get; set; }

        public decimal PrecioDescontado { get; set; }

        public int PiezasGratis { get; set; }

        public Tipos.SiNo BeneficioProveedor { get; set; }

        public string CODIGO_CLI { get; set; }

        public string COMENTARIO { get; set; }

        public decimal PorcentajeIVA { get; set; }

        public decimal PrecioProveedor { get; set; }

        public int TipoPrecioDescuento { get; set; }
    }
}
