using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Pedido
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

        public int TipoClienteID
        {
            get;
            set;
        }

        public int ClienteID
        {
            get;
            set;
        }

        public DateTime FechaPedido
        {
            get;
            set;
        }

        public Tipos.SiNo Receta
        {
            get;
            set;
        }

        public int MedicoID
        {
            get;
            set;
        }

        public DateTime FechaRemisionVenta
        {
            get;
            set;
        }
        public string Comentario
        {
            get;
            set;
        }

        public string ReferenciaRemisionVenta
        {
            get;
            set;
        }

        public int VendedorID
        {
            get;
            set;
        }

        public int MonedaID
        {
            get;
            set;
        }

        public int TipoCambioID
        {
            get;
            set;
        }

        public decimal SubTotal
        {
            get;
            set;
        }

        public decimal ImpuestoVenta
        {
            get;
            set;
        }
        public decimal ImpuestoIVA
        {
            get;
            set;
        }

        public decimal Descuento
        {
            get;
            set;
        }


        public decimal PorcentajeDescuento
        {
            get;
            set;
        }

        public string NumeroCredencial
        {
            get;
            set;
        }

        public decimal Total
        {
            get;
            set;
        }

        public decimal TotalArticulosPedido
        {
            get;
            set;
        }

        public Tipos.SiNo Activo
        {
            get;
            set;
        }

        public string ImporteLetra
        {
            get;
            set;
        }

        public Tipos.SiNo Factura
        {
            get;
            set;
        }

        public List<PedidoDetalle> Detalles { get; set; }

        public int TipoPagoID
        {   
            get;
            set;
        }

        public decimal TotalPago
        {
            get;
            set;
        }
    }
}
