using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio.CallCenter
{
    public class QuejasSugerencias
    {
        public SIFModelo.QuejasSugerencias.CatalogoDataSet DsQuejasSugerencias = new SIFModelo.QuejasSugerencias.CatalogoDataSet();

        public SIFModelo.QuejasSugerencias.CatalogoDataSet CatalogoQuejasSugerenciasActivas()
        {
            DsQuejasSugerencias = SIFDatos.CallCenter.QuejasSugerencias.dtQuejasSugerencias();
            return DsQuejasSugerencias;
        }

        public SIFModelo.CallCenter.CallCenterDataSet DataSet = new SIFModelo.CallCenter.CallCenterDataSet();


        public bool NuevaQuejaSugerencia(SIFModelo.CallCenter.CallCenterDataSet.QUEJA_SUGERENCIARow QuejaSugerencia)
        {
            return SIFDatos.CallCenter.QuejasSugerencias.NuevaQuejaSugerencia(QuejaSugerencia);
        }

        public bool ModificaQuejaSugerencia(SIFModelo.CallCenter.CallCenterDataSet.QUEJA_SUGERENCIARow QuejaSugerencia)
        {
            return SIFDatos.CallCenter.QuejasSugerencias.ModificaQuejaSugerencia(QuejaSugerencia);
        }

       public SIFModelo.CallCenter.CallCenterDataSet BuscaQuejaSugerencia(DateTime fecha1, DateTime fecha2, String sucursal)
        {
            return SIFDatos.CallCenter.QuejasSugerencias.dtQuejasSugerencias(fecha1, fecha2, sucursal);
        }
    }
}
