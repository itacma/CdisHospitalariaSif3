using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class DevolucionProveedorDetalle
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

        public string Comentario
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

        public decimal Costo
        {
            get;
            set;
        }

        public Decimal IVA
        {
            get;
            set;
        }

    }
}
