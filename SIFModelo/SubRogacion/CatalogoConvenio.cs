using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.SubRogacion
{
    public class CatalogoConvenio
    {
        public int ClienteId { get; set; }
        public string Nombre_cliente { get; set; }
        public string Nombre_Institucion { get; set; }
        public int Mes { get; set; }
        public string Mes_texto { get; set; }

    }
}
