using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.QuejasSugTipo
{
    public class CatQuejasSug
    {
         public int SugerenciaId
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public Tipos.QuejaSug Tipo
        {
            get;
            set;
        }

        public Tipos.SiNo Activo
        {
            get;
            set;
        }

        public List<SIFModelo.QuejasSugTipo.CatQuejaSugSubTipo> Detalles { get; set; }
    }
  }
