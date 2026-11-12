using System;
using Oracle.DataAccess.Types;

namespace SIF.View.Menu.Compras
{
    /// <summary>
    /// Implementación para el tipo definido en Oracle: FARMACIA.T_VARCHAR_TAB
    /// </summary>
    [OracleCustomTypeMapping("FARMACIA.T_VARCHAR_TAB")]
    public class VarcharArrayFactory : IOracleArrayTypeFactory
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

    /// <summary>
    /// Implementación para el tipo definido en Oracle: FARMACIA.T_NUMERIC_TAB
    /// </summary>
    [OracleCustomTypeMapping("FARMACIA.T_NUMERIC_TAB")]
    public class NumberArrayFactory : IOracleArrayTypeFactory
    {
        public Array CreateArray(int numElems)
        {
            return new decimal[numElems];
        }

        public Array CreateStatusArray(int numElems)
        {
            return new OracleUdtStatus[numElems];
        }
    }
}