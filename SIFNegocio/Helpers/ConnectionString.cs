using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio.Helpers
{
    public class ConnectionString
    {
        public static string Connection()
        {
            return SIFDatos.Helpers.ConnectionString.Connection();
        }

    }
}
