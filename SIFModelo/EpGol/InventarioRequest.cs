using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.EpGo
{
    public class InventarioRequest
    {
        // Identificadores principales 🔑
        public string articulo_id { get; set; }
        public int sucursal_id { get; set; }

        // Cantidades 🔢
        public int existencias { get; set; }
        public int existencia_min { get; set; }
        public int existencia_max { get; set; }
        public int punto_de_reorden { get; set; }
        public int inv_fisico { get; set; }
        public int apartado_vtas { get; set; }

        // Costos y Precios 💰
        public double ult_costo { get; set; }
        public double costo_prom { get; set; }
        public double peps { get; set; }
        public double ueps { get; set; }

        // Fechas (se envían como string en formato YYYY-MM-DD HH24:MI:SS) 
        public string fecha_ult_mov { get; set; }
        public string fecha_ult_ent { get; set; }
        public string fecha_ult_sal { get; set; }
        public string fecha_inv_fisico { get; set; }
        public string ult_fecha_refresh { get; set; }

        // Información de Auditoría y Ubicación 📍
        public string ubicacion { get; set; }
        public string ult_usuario { get; set; }
        public string ult_documento { get; set; }
        public int ult_mov_inv_id { get; set; }
        public int ult_partida { get; set; }
    }

}
