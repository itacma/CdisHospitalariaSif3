using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Oracle.DataAccess.Client;

namespace SIFDatos.Helpers
{
    public static class ConnectionString
    {

        private static string stringConnection;
        public static string Connection()
        {
            return stringConnection;
        }

        public static void SetStringConnection(string connection)
        {
        stringConnection = connection;
        }
    }
}
