using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class DevolucionProveedor
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

        public int ProveedorID
        {
            get;
            set;
        }

        public DateTime Fecha
        {
            get;
            set;
        }

        public string RDM
        {
            get;
            set;
        }

        public string Comentario
        {
            get;
            set;
        }

        public decimal Total
        {
            get;
            set;
        }

        public SIFModelo.Tipos.ActivoDevolucion Activo
        {
            get;
            set;
        }

        public int UsuarioID
        {
            get;
            set;
        }



       public List<SIFModelo.DevolucionProveedorDetalle> Detalles
        {
            get;
            set;
        }
        
        public decimal Impuesto
        {
            get;
            set;
        }
        public decimal SubTotal
        {
            get;
            set;
        }

        public decimal Descuento { get; set; }
    }
}
