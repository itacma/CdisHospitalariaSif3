using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.OrdenCompra
{
    public class OrdenCompra
    {
        public string OrdenCompraID
        {
            get;
            set;
        }

        public string UsuarioID
        {
            get;
            set;
        }

        public int ProveedorID
        {
            get;
            set;
        }

        public string ProveedorNombre
        {
            get;
            set;
        }

        public int SucursalID
        {
            get;
            set;
        }

        public string SucursalNombre
        {
            get;
            set;
        }



        public string ArticuloID
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public int CantidadSolicitada
        {
            get;
            set;
        }

        public int OfertaCompraID
        {
            get;
            set;
        }

        public string DescripcionCompra
        {
            get;
            set;
        }

        public decimal PrecioCosto
        {
            get;
            set;
        }

        public decimal UltimoPrecioCompra
        {
            get;
            set;
        }

        public int CantidadFacturada
        {
            get;
            set;
        }

        public int CantidadRecibida
        {
            get;
            set;
        }

        public int CantidadDevuelta
        {
            get;
            set;
        }

        public int CantidadMalEstado
        {
            get;
            set;
        }

        public int CantidadReposicion
        {
            get;
            set;
        }

        public decimal PrecioFactura
        {
            get;
            set;
        }

        public decimal DescuentoFactura
        {
            get;
            set;
        }
        
        public decimal DescuentoFacturaAD1
        {
            get;
            set;
        }

        public decimal DescuentoRecibido
        {
            get;
            set;
        }

        public decimal DescuentoRecibidoAD1
        {
            get;
            set;
        }

        public decimal DescuentoRecibidoAD2
        {
            get;
            set;
        }

        public DateTime FechaAlta
        {
            get;
            set;
        }

        public DateTime FechaRecepcion
        {
            get;
            set;
        }

        public DateTime FechaCierre
        {
            get;
            set;
        }

        public int UsuarioAutorizaID
        {
            get;
            set;
        }

        public DateTime FechaAutoriza
        {
            get;
            set;
        }

        public SIFModelo.EstadoOrdenCompra EstadoOrdenCompra
        {
            get;
            set;
        }



    }
}
