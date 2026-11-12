using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public static class TiposCompras
    {
        public enum TipoOferta : sbyte { PRECIO = (sbyte)'P', DESCUENTO = (sbyte)'D', MERCANCIA = (sbyte)'M', COMBINADA = (sbyte)'C' }

        public enum EstadoArticuloProveedor : sbyte { FALTANTE = (sbyte)'F', SIN_EXISTENCIA = (sbyte)'E', DESCONTINUADOS = (sbyte)'D', COMPRA = (sbyte)'C', NO_COMPRAR = (sbyte)'X', AGOTADO = (sbyte)'A', CODIGO = (sbyte)'N', TRANSFERENCIA = (sbyte)'T' }

        public static List<EstadoArticulosFleming> EstadosArticulosFleming = new List<EstadoArticulosFleming>()
        {
            new EstadoArticulosFleming(){ Estado= "AGOTADO", Clave = "AG"},
            new EstadoArticulosFleming(){ Estado= "DESCONTINUADO", Clave = "DE"},
            new EstadoArticulosFleming(){ Estado= "NO APLICA", Clave = "NA"},
            new EstadoArticulosFleming(){ Estado= "AGOTADO", Clave = "AG"},
            new EstadoArticulosFleming(){ Estado= "NO MANEJADO", Clave = "NM"},
            new EstadoArticulosFleming(){ Estado= "SIN PROBLEMA", Clave = "NO"}
        };
    }

    public class EstadoArticulosFleming
    {
        public string Estado
        {
            get;
            set;
        }

        public string Clave
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Estado;
        }
    }

    public class EstadoOrdenCompra
    {
        public string Estado
        {
            get;
            set;
        }

        public string Clave
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Estado;
        }
    }

    public static class EstadosOrdenCompra
    { 
          public static EstadoOrdenCompra ABIERTA = new EstadoOrdenCompra() { Estado= "ABIERTA", Clave = "A"};
          public static EstadoOrdenCompra CERRADA = new EstadoOrdenCompra() { Estado = "CERRADA", Clave = "C" };
          public static EstadoOrdenCompra PROCESADA = new EstadoOrdenCompra() { Estado = "PROCESADA", Clave = "P" };
          public static EstadoOrdenCompra EN_ASIGNACION_PRECIOS = new EstadoOrdenCompra() { Estado = "EN_ASIGNACION_PRECIOS", Clave = "L" };
          public static EstadoOrdenCompra AUTORIZADA_LISTA_PARA_ASIGNACION_PRECIOS = new EstadoOrdenCompra() { Estado = "AUTORIZADA_LISTA_PARA_ASIGNACION_PRECIOS", Clave = "E" };
          public static EstadoOrdenCompra CANCELADAS = new EstadoOrdenCompra() { Estado = "CANCELADAS", Clave = "XY" };
    }

}
