using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using Equin.ApplicationFramework;
using System.Windows.Forms;

namespace SIFNegocio.Extras
    {
    public class Parametros
        {
        public int ObtenParametro(string parametro)
            {
            int activo = SIFDatos.Extras.Parametros.ObtenParametro(parametro);
            return activo;
            }

        }
    }
