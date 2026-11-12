using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Types;

namespace SIF3.Clases
{
    [OracleCustomTypeMapping("SIF3.BANCOSVARRAY")]
    public class DateArrayFactory : IOracleCustomTypeFactory, IOracleArrayTypeFactory
    {
        public IOracleCustomType CreateObject()
        {
            return new DateArray();
        }

        public Array CreateArray(int numElems)
        {
            return new String[numElems];
        }

        public Array CreateStatusArray(int numElems)
        {
            return new OracleUdtStatus[numElems];
        }
    }
}
