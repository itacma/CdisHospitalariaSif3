using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class UsuarioCajero
    {
        public int CajeroID
        {
            get;
            set;
        }

        public int UsuarioID
        {
            get;
            set;
        }

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
