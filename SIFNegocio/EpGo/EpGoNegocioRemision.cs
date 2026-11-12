using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIFNegocio.EpGo
{
    public class EpGoNegocioRemision
    {
        public System.Data.DataSet epgoRemisionPagada(string numeroRemision)
        {
            System.Data.DataSet ds = SIFDatos.EpGo.EpGoRemision.epgoRemisionPagada(numeroRemision);
            return ds;
        }

        public DataSet epgoGetInventario(List<string> detalles)
        {
            System.Data.DataSet ds = SIFDatos.EpGo.EpGoRemision.epgoGetInventario(detalles);
            return ds;
        }
        public DataSet epgoGetArticulosModificados(string documento, int tpInvID)
        {
            System.Data.DataSet ds = SIFDatos.EpGo.EpGoRemision.epgoGetArticulosModificados(documento, tpInvID);
            return ds;
        }
      

    }
}
