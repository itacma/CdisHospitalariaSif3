using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class ClasificacionSSA
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
        /// Indica si el medicamento requiere receta
        /// </summary>
        public Tipos.SiNo Receta
        {
            get;
            set;
        }
    }
}
