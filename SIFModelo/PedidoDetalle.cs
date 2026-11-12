using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class PedidoDetalle
    {
        public int SucursalID
        {
            get;
            set;
        }

        public string NumeroPedido
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

        public int CantidadPedido
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
        public decimal MontoDescuento
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
    }
}
