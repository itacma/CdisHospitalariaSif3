using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Cotizacion
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

        public int TipoClienteID
        {
            get;
            set;
        }

        public decimal PorcentajeDescuento
        {
            get;
            set;
        }

        public int ClienteID
        {
            get;
            set;
        }

        public DateTime FechaCotizacion
        {
            get;set;
        }


        public SIFModelo.Tipos.SiNo Receta
        {
            get;
            set;
        }

        public int MedicoID
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

        public decimal Descuento
        {
            get;
            set;
        }

        public string Comentario
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

        public decimal TotalArticulos
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

        public Tipos.TipoCotizacion TipoCotizacion
        {
            get;
            set;
        }

        public List<SIFModelo.CotizacionDetalle> Detalles
        {
            get;
            set;
        }

        public Tipos.SiNo Activo { get; set; }

        public string ProveedorBeneficio { get; set; }

        public Tipos.SiNo BeneficioProveedor { get; set; }
    }
}
