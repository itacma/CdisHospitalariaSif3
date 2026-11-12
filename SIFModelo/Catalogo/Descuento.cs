using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Descuento
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

        public decimal Porcentaje
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

        public DateTime? FechaBaja
        {
            get;
            set;
        }


        public string NumeroCredencial { get; set; }

        public string NoEmpleado { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public int UltUsuarioId { get; set; }

        public string ActivoMapfre { get; set; }

        public int DescuentoId { get; set; }

    }
}
