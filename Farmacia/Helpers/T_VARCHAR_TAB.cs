using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIF.Helpers
{
    [OracleCustomTypeMapping("T_VARCHAR_TAB")]
    public class T_VARCHAR_TAB : IOracleArrayTypeFactory
    {
        public Array CreateArray(int numElems)
        {
            return new string[numElems]; // arreglo de cadenas
        }

        public Array CreateStatusArray(int numElems)
        {
            return null; // no usamos array de estado
        }
    }
}
