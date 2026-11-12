using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    /// <summary>
    /// AVM 09-04-2015
    /// Almacena el motivo del pedido
    /// </summary>
    public class MotivoPedido
    {
        public MotivoPedido()
        {
        }

        public MotivoPedido(int ID,string NOMBRE,int MAX_SKUS,int CANTIDAD_PEDIDO_MAX_DIA,
            string PARAMETRO_EOQ,int VALOR_EOQ,string PARAMETRO_EXIS,int VALOR_EXIS, char ACTIVO)
        {
            this.ID = ID;
            this.NOMBRE = NOMBRE;
            this.MAX_SKUS = MAX_SKUS;
            this.CANTIDAD_PEDIDO_MAX_DIA = CANTIDAD_PEDIDO_MAX_DIA;
            this.PARAMETRO_EOQ = PARAMETRO_EOQ;
            this.VALOR_EOQ = VALOR_EOQ;
            this.PARAMETRO_EXIS = PARAMETRO_EXIS;
            this.VALOR_EXIS = VALOR_EXIS;
            this.ACTIVO = ACTIVO;
        }
        /// <summary>
        /// identificador del motivo del pedido
        /// </summary>
        public int ID
        {get;set;}

        /// <summary>
        /// nombre del motivo del pedido
        /// </summary>
        public string NOMBRE
        { get; set; }

        /// <summary>
        /// maximo de articulos por pedido
        /// </summary>
        public int MAX_SKUS
        { get; set; }

        /// <summary>
        /// maximo de este tipo de pedidos que se pueden realizar por día
        /// </summary>
        public int CANTIDAD_PEDIDO_MAX_DIA
        { get; set; }

        /// <summary>
        /// comparacion con EOQ
        /// </summary>
        public string PARAMETRO_EOQ
        { get; set; }

        /// <summary>
        /// valor de comparacion con eoq
        /// </summary>
        public int VALOR_EOQ
        { get; set; }

        /// <summary>
        /// comparacion con existencia
        /// </summary>
        public string PARAMETRO_EXIS
        { get; set; }

        /// <summary>
        /// valor de comparacion con existencia
        /// </summary>
        public int VALOR_EXIS
        { get; set; }

        /// <summary>
        /// fecha alta del motivo
        /// </summary>
        public DateTime FECHA_ALTA
        { get; set; }

        /// <summary>
        /// fecha baja del motivo
        /// </summary>
        public DateTime FECHA_BAJA
        { get; set; }

        /// <summary>
        /// motivo activo s/n
        /// </summary>
        public char ACTIVO
        { get; set; }
    }
}
