using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Tipos
{
    public class TipoDireccion
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

        public static SIFModelo.Tipos.TipoDireccion fiscal = new SIFModelo.Tipos.TipoDireccion() { Tipo = "FISCAL", Valor = "FI" };
        public static SIFModelo.Tipos.TipoDireccion email = new SIFModelo.Tipos.TipoDireccion() { Tipo = "TRABAJO", Valor = "EM" };
        public static SIFModelo.Tipos.TipoDireccion casa = new SIFModelo.Tipos.TipoDireccion() { Tipo = "CASA", Valor = "CA" };


        public override string ToString()
        {
            return Tipo;
        }

    }
}
