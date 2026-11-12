using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Catalogo
{
    public class CatUnidadesDistribucion
    {
        public int Id { get; set; }
        public string Permiso_sct { get; set; }
        public string Numero_permiso_sct { get; set; }
        public string Configuracion_vehicular { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public string Asegura_resp_civil { get; set; }
        
        public string Poliza_resp_civil { get; set; }
        public string Activo { get; set; }
    }
}
