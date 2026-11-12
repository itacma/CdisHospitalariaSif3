using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Remision
    {
        public int SucursalID
        {
            get;
            set;
        }

        public string NumeroRemision
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

        public DateTime FechaVenta
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

        public DateTime FechaPago
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

        public int TipoCambio
        {
            get;
            set;
        }

        public string Condiciones
        {
            get;
            set;
        }

        public decimal SubTotal
        {
            get;
            set;
        }

        public decimal Impuesto
        {
            get;
            set;
        }

        public decimal Total
        {
            get;
            set;
        }

        public decimal Descuento
        {
            get;
            set;
        }

        public decimal TotalArticulosRemision
        {
            get;
            set;
        }

        public string NumeroFactura
        {
            get;
            set;
        }

        public Tipos.SiNo Factura
        {
            get;
            set;
        }

        public string ImporteLetra
        {
            get;
            set;
        }

        public Tipos.StatusVenta Activo
        {
            get;
            set;
        }

        public string Comentarios
        {
            get;
            set;
        }

        public string NumeroPedido
        {
            get;
            set;
        }

        public Tipos.SiNo BeneficioProveedor
        {
            get;
            set;
        }

        public List<RemisionDetalle> Detalles { get; set; }

        public string TarjetaID
        {
            get;
            set;
        }

        public string ReferenciaProveedor { get; set; }

        public string ProveedorBeneficio { get; set; }
        
        public decimal PorcentajeDescuento { get; set; }

        public int DescuentoID { get; set; }
    }
}
