using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Tipos
{
    public class TipoConsulta
    {
        /// <summary>
        /// Tipos de direccion FI (FISCAL) EM(EMAIL) CA(CASA)
        /// </summary>
        public string Tipo
        {
            get;set;
        }
        public string Valor
        {
        get;set;
        }

        public static SIFModelo.Tipos.TipoConsulta CASA = new SIFModelo.Tipos.TipoConsulta() { Tipo = "CASA", Valor = "CA" };
        public static SIFModelo.Tipos.TipoConsulta OFICINA = new SIFModelo.Tipos.TipoConsulta() { Tipo = "OFICINA", Valor = "OF" };
        public static SIFModelo.Tipos.TipoConsulta HOSPITAL = new SIFModelo.Tipos.TipoConsulta() { Tipo = "HOSPITAL", Valor = "HO" };
        public static SIFModelo.Tipos.TipoConsulta CELULAR = new SIFModelo.Tipos.TipoConsulta() { Tipo = "CELULAR", Valor = "CE" };
        public static SIFModelo.Tipos.TipoConsulta NEXTEL = new SIFModelo.Tipos.TipoConsulta() { Tipo = "NEXTEL", Valor = "NX" };

        public override string ToString()
        {
            return Tipo;
        }

    }
}
