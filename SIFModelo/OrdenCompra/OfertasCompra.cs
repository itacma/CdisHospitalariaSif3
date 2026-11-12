using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.OrdenCompra
{
    public class OfertasCompra
    {
        public int ProveedorID
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public decimal DescuentoOfrecido
        {
            get;
            set;
        }

        public decimal DescuentoEspecialProveedor
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

        public decimal PrecioCosto
        {
            get;
            set;
        }

        public decimal PrecioFarmacia
        {
            get;
            set;
        }


        public string TipoOferta { get; set; }
    }
}
