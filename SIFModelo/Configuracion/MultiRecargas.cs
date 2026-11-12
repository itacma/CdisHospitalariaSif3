using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SIFModelo.Configuracion
{
    public class MultiRecargas
    {

        public string DirectorioSalida
        {
            get;
            set;
        }

        public string JAR { get; set; }

        public string HostTelcel { get; set; }

        public string PuertoTelcel { get; set; }

        public string TimeOutTelcel { get; set; }

        public string PathJava { get; set; }

        public string TAEGrupo { get; set; }

        public List<string> Carriers { get; set; }

        public string ProductosTelcel { get; set; }

        public string ProductosMovistar { get; set; }


        public string ProductosUnefon { get; set; }

        public string ProductosNextel { get; set; }

        public string ProductosIusacell { get; set; }

        public string Encriptacion { get; set; }

        public string Timeout { get; set; }

        public string DirectorioQuerySalida { get; set; }
    }
}
