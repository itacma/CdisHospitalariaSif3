using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFNegocio
{
    public static class LoggerHelper
    {
        // Obtenemos el logger centralizado
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Error(string mensaje)
        {
            log.Error(mensaje);

        }

        public static void Info(string mensaje)
        {
            log.Info(mensaje);
        }
    }
}
