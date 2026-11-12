using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio.Configuracion
{
    public static class Configuraciones
    {
        private static SIFModelo.Configuracion.ServidorOracle servidorOracle;
        public static SIFModelo.Configuracion.ServidorOracle ServidorOracle
        {
            get { return servidorOracle; }
            set { servidorOracle = value; SIFDatos.Helpers.ConnectionString.SetStringConnection(value.CadenaConexion); }
        }

        public static SIFModelo.Configuracion.Aplicacion Aplicacion = new SIFModelo.Configuracion.Aplicacion();

        public static SIFModelo.Configuracion.Email Mail = new SIFModelo.Configuracion.Email();

        public static SIFModelo.Configuracion.Factura Factura = new SIFModelo.Configuracion.Factura();

        public static SIFModelo.Configuracion.Pfizer Pfizer = new SIFModelo.Configuracion.Pfizer();

        public static SIFModelo.Configuracion.TAE TAE = new SIFModelo.Configuracion.TAE();
        public static SIFModelo.Configuracion.MultiRecargas MultiRecargas = new SIFModelo.Configuracion.MultiRecargas();

        public static SIFModelo.Configuracion.Nadro Nadro = new SIFModelo.Configuracion.Nadro();

        public static DateTime fechaServidor()
        {
            return SIFDatos.Configuracion.FechaServidor();
        }



        public static int DecimalesRedondeo = 2;
        /// <summary>
        /// Llama a truncar al numero de decimales (decimalPlaces) o decimales en la configuración
        /// </summary>
        /// <param name="numberToTruncate">El número a truncar en formato decimal</param>
        /// <param name="decimalPaces">El número de decimales por defecto tomado de la configuración (DecimalesRedondeo)</param>
        /// <returns></returns>
        public static decimal TruncateToDecimalPlace(object numberToTruncate, int? decimalPaces = null)
        {
            if (decimalPaces == null)
            {
                return System.Convert.ToDecimal(numberToTruncate);
            }

            if (decimalPaces == null)
            {
                decimalPaces = DecimalesRedondeo;
            }

            //decimal power = (decimal)(Math.Pow(10.0, (double)decimalPaces));
            //return Math.Truncate((power * (decimal)numberToTruncate)) / power;

            return Math.Round((decimal)numberToTruncate, decimalPaces.Value);
        }

        public static string ReadDBSetting(string clave)
        {
            return SIFDatos.Configuracion.Leer(clave);
        }

        public static bool WriteDBSetting(string clave, string valor)
        {
            return SIFDatos.Configuracion.Actualiza(clave, valor);
        }

        public static string ReadDataBase()
        {
            return Helpers.ConnectionString.Connection();
        }
    }
}
