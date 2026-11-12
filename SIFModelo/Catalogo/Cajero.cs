using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Cajero
    {

        public string CajeroID
        {
            get;
            set;
        }

        public string SupervisorID
        {
            get;
            set;
        }

        /// <summary>
        /// Turno laboral
        /// </summary>
        public Tipos.Turno Turno
        {
            get;
            set;
        }

        public DateTime HoraEntrada
        {
            get;
            set;
        }

        public DateTime HoraSalida
        {
            get;
            set;
        }
    }
}
