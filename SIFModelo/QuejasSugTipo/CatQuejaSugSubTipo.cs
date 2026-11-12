using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.QuejasSugTipo
{
    public class CatQuejaSugSubTipo
    {
        public int SugerenciaId
        {
            get;
            set;
        }

        public int SugerenciaTipoId
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
    }
}
