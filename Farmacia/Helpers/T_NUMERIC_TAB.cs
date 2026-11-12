using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIF.Helpers
{
    [OracleCustomTypeMapping("T_NUMERIC_TAB")]
    public class T_NUMERIC_TAB : IOracleArrayTypeFactory
    {
        public Array CreateArray(int numElems)
        {
            return new decimal[numElems]; // arreglo de decimales
        }

        public Array CreateStatusArray(int numElems)
        {
            return null;
        }
    }
}
