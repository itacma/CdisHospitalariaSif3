using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    /// <summary>
    /// Tipo de movimiento en el inventario
    /// </summary>
    public class TipoMovimiento
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

        public DateTime FechaAlta
        {
            get;
            set;
        }

        public DateTime FechaBaja
        {
            get;
            set;
        }

        public Tipos.Movimiento Tipo
        {
            get;
            set;
        }


    }
}
