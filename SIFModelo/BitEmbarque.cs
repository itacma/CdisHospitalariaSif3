using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class BitEmbarque
    {
        public Int16 num_entrega { get; set; }
        public string folio_traspaso { get; set; }
        public Int16 lote { get; set; }
        public Int16 suc_origen { get; set; }
        public Int16 suc_destino { get; set; }
        public Int16 usuario_envia { get; set; }
        public Int16 distribuidor_id { get; set; }
        public Int16 caja_grande { get; set; }
        public Int16 caja_chica { get; set; }
        public Int16 bulto { get; set; }
        public Int16 bolsa { get; set; }
        public Int16 temperatura { get; set; }
        public Int16 factura_controlados { get; set; }
        public string observaciones { get; set; }
        public string activo { get; set; }

        public Int16 refrigerados { get; set; }

        public int IdUnidadDistribucion { get; set; }

    }
}
