using Oracle.DataAccess.Types;
using System;

namespace SIFDatos.OrdenCompra
{
    class ODCIVARCHAR2LISTFactory : IOracleArrayTypeFactory
    {
        public Array CreateArray(int numElems)
        {
            return new string[numElems];
        }

        public Array CreateStatusArray(int numElems)
        {
            return new OracleUdtStatus[numElems];
        }
    }
}
