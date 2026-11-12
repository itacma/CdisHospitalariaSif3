using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class TipoMedicamento
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

        public string Clave
        {
            get;
            set;
        }

        public Tipos.SiNo Receta
        {
            get;
            set;
        }

        public Tipos.SiNo Activo
        {
            get;
            set;
        }
    }
}
