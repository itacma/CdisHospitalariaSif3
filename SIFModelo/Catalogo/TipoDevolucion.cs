using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class TipoDevolucion
    {
        public int TipoDevolucionID
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        /// <summary>
        /// Indica si la devolución es de Compra o de Venta 
        /// </summary>
        public Tipos.CompraVenta CompraVenta
        {
            get;
            set;
        }

        public Tipos.SiNo Activo
        {
            get;
            set;
        }

        public string Observaciones { get; set; }
    }
}
