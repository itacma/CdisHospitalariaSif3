using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Moneda
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

        /// <summary>
        /// Indica si el tipo de moneda esta activo o inactivo
        /// </summary>
        public Tipos.SiNo Activo
        {
            get;
            set;
        }

        /// <summary>
        /// Tasa de cambio
        /// </summary>
        public decimal Factor
        {
            get;
            set;
        }

    }
}
