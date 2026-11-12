using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Banco
    {
        /// <summary>
        /// Id del Banco, identificador único
        /// </summary>
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// Nombre del Banco
        /// </summary>
        public string Nombre
        {
            get;
            set;
        }

        /// <summary>
        /// S/N
        /// </summary>
        public Tipos.SiNo Credito
        {
            get;
            set;
        }

        /// <summary>
        /// S/N
        /// </summary>
        public Tipos.SiNo Debito
        {
            get;
            set;
        }

        public decimal Comision
        {
            get;
            set;
        }


        /// <summary>
        /// Valores S/N
        /// </summary>
        public Tipos.SiNo Activo
        {
            get;
            set;
        }

    }
}
