using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class ArticuloBaja
    {
        public string ARTICULO_ID
        {
            get;
            set;
        }
        /// <summary>
        /// Estado activo o inactivo
        /// </summary>
        public Tipos.SiNo ACTIVO
        {
            get;
            set;
        }

        public string NOMBRE1
        {
            get;
            set;
        }


        public string NOMBRE2
        {
            get;
            set;
        }

        public int LABORATORIO_ID
        {
            get;
            set;
        }

        public string LABORATORIO_NOMBRE
        {
            get;
            set;
        }

    }
}
