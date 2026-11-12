using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Apartado
    {
        public int SucursalID
        {
            get;
            set;
        }

        public string NumeroApartado
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

        public DateTime FechaApartado
        {
            get;
            set;
        }
        public DateTime FechaConfirmaApartado
        {
            get;
            set;
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
        public DateTime FechaRemisionVenta
        {
            get;
            set;
        }

        public string ReferenciaRemisionVenta
        {
            get;
            set;
        }
        public string Comentario
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
        public decimal PorcentajeDescuento
        {
            get;
            set;
        }
        public decimal Descuento
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
        public decimal Anticipo
        {
            get;
            set;
        }
        
        public List<SIFModelo.ApartadoDetalle> Detalles
        {
            get;
            set;
        }

        public Tipos.SiNo Activo { get; set; }
    }
   
}
