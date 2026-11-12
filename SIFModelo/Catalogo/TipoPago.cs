using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class TipoPago
    {
        public int ID
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public Tipos.SiNo Activo
        {
            get;
            set;
        }

        /// <summary>
        /// Indica si genera un porcentaje de comision
        /// </summary>
        public Tipos.SiNo Comision
        {
            get;
            set;
        }

        /// <summary>
        /// Porcentaje de comision
        /// </summary>
        public decimal Porcentaje
        {
            get;
            set;
        }

        public DateTime FechaAlta
        {
            get;
            set;
        }

        public DateTime? FechaBaja
        {
            get;
            set;
        }
    }
}
