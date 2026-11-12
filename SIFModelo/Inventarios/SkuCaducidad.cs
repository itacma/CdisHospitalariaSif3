using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Inventarios
{
    public class SkuCaducidad
    {


        public string FolioCompra { get; set; }
        public string articuloId { get; set; }
        public string nombre { get; set; }

        public Int32 cantidad { get; set; }
        public Int32 CantidadCompra { get; set; }
        public Int32 cant_lote { get; set; }//Se descontinua para la version 1.3
        public string no_lote { get; set; }
        public DateTime caducidad { get; set; }
        public string div { get; set; }

        public int partida{  get; set; }
        public string lote__interno { get; set; }
        public string Foliot { get; set; }// pertenece al folio de traspaso

        public int lotet { get; set; }// pertenece al lote del traspaso  string p_Articulo_id,
        public Int32 CantidadPedida { get; set; }// pertenece a la cantidad pedida del traspaso 
       


    }
}
