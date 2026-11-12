using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class DevolucionDetalle
    {
        public string DevolucionID
        {
            get;
            set;
        }

        public int SucursalID
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

        public decimal Cantidad
        {
            get;
            set;
        }

        public decimal Precio
        {
            get;
            set;
        }

        public decimal Descuento
        {
            get;
            set;
        }

        public Decimal IVA
        {
            get;
            set;
        }

        public decimal PrecioCosto
        {
            get;
            set;
        }

        public decimal TipoDevolucionID
        {
            get;
            set;
        }

        public decimal Total { get; set; }

        public int ImpuestoID { get; set; }

        public int DescuentoID { get; set; }


        public int RefOferta { get; set; }
    }
}
