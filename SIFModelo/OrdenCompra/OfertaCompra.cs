using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.OrdenCompra
{
    public class OfertaCompra
    {
        public string ArticuloID
        {
            get;
            set;
        }

        public int ProveedorID
        {
            get;
            set;
        }

        public DateTime FechaAlta
        {
            get;
            set;
        }


        public string Nombre1
        {
            get;
            set;
        }

        public int LaboratorioID
        {
            get;
            set;
        }

        public decimal  PrecioFarmacia
        {
            get;
            set;
        }

        public decimal PrecioPublico
        {
            get;
            set;
        }
        public SIFModelo.TiposCompras.TipoOferta TipoOferta
        {
            get;
            set;
        }

        public decimal DescuentoOfrecido
        {
            get;
            set;
        }

        public string DescripcionDescuento
        {
            get;
            set;
        }

        public int MinimoPiezas
        {
            get;
            set;
        }

        public int CantidadComprar
        {
            get;
            set;
        }

        public int PiezasConCargo
        {
            get;
            set;
        }

        public int PiezasSinCargo
        {
            get;
            set;
        }

        public SIFModelo.TiposCompras.EstadoArticuloProveedor EstadoArticuloProveedor
        {
            get;
            set;
        }
        
        public SIFModelo.EstadoArticulosFleming EstadoArticulosFleming
        {
            get;
            set;
        }

        public decimal DescuentoAdicionalProveedor
        {
            get;
            set;
        }

        public decimal DescuentoEspecialProveedor
        {
            get;
            set;
        }

        public DateTime? FechaBaja
        {
            get;
            set;
        }

        public string CodigoProveedor
        {
            get;
            set;
        }

        public int Escala
        {
            get;
            set;
        }



    }
}
