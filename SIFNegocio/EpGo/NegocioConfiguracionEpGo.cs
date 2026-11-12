using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace SIFNegocio.EpGo
{
    public static class NegocioConfiguracionEpGo
    {
        //public static SIFModelo.EpGo.modelConfiguracionEpGo configuracionEpGo { get; set; }
        public static List<SIFModelo.EpGo.modelConfiguracionEpGo> ListaEndPointsGo { get; set; }

        public static HttpClient _httpClient;

        public static int ParametroActivo { get; set; }

    }


}
