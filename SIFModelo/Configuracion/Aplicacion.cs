using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Configuracion
{
    public class Aplicacion
    {
        public int SucursalID
        {
            get;
            set;
        }

        public string SucursalNombre
        {
            get;
            set;
        }

        public string DirectorioReportes
        {
            get;
            set;
        }

        public string DirectorioImagenes
        {
            get;
            set;
        }


        public string DirectorioTemplates
        {
            get;
            set;
        }

        public string ImpresoraTickets
        {
            get;
            set;
        }

        public string ImpresoraReportes
        {
            get;
            set;
        }

        public string DireccionEmail { get; set; }

        public int DecimalesRedondeo { get { return 2; } }
    }
}
