using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.EpGol
{
    public class VentaDocumentoRequest
    {
        [JsonProperty("tipo_mov_inv_id")]
        public int TipoMovInvId { get; set; }

        [JsonProperty("sucursal_id")]
        public int SucursalId { get; set; }

        [JsonProperty("documento")]
        public string Documento { get; set; }

        [JsonProperty("fecha_genera")]
        public string FechaGenera { get; set; }

        [JsonProperty("fecha_cierre")]
        public string FechaCierre { get; set; }

        [JsonProperty("usuario_genera")]
        public int UsuarioGenera { get; set; }

        [JsonProperty("cliente")]
        public int Cliente { get; set; }

        [JsonProperty("tipo_cliente")]
        public string TipoCliente { get; set; }

        [JsonProperty("condiciones")]
        public string Condiciones { get; set; }

        [JsonProperty("pcredito")]
        public string PCredito { get; set; }

        [JsonProperty("sif")]
        public string Sif { get; set; }

        [JsonProperty("descuento")]
        public string Descuento { get; set; }

        [JsonProperty("importe_descuento")]
        public string ImporteDescuento { get; set; }

        [JsonProperty("importe_total")]
        public double ImporteTotal { get; set; }

        [JsonProperty("caja_id")]
        public int CajaId { get; set; }

        [JsonProperty("cajero_id")]
        public string CajeroId { get; set; }

        [JsonProperty("detalle")]
        public List<VentaDetalleRequest> Detalle { get; set; }
    }

    public class VentaDetalleRequest
    {
        [JsonProperty("partida")]
        public int Partida { get; set; }

        [JsonProperty("articulo_id")]
        public string ArticuloId { get; set; }

        [JsonProperty("existencia")]
        public int Existencia { get; set; }

        [JsonProperty("fecha")]
        public string Fecha { get; set; }

        [JsonProperty("entrada")]
        public int Entrada { get; set; }

        [JsonProperty("salida")]
        public int Salida { get; set; }

        [JsonProperty("costo_prom")]
        public double CostoProm { get; set; }

        [JsonProperty("costo")]
        public double Costo { get; set; }

        [JsonProperty("usuario_id")]
        public string UsuarioId { get; set; }

        [JsonProperty("kardex_id")]
        public int KardexId { get; set; }

        [JsonProperty("precio_costo")]
        public double PrecioCosto { get; set; }

        [JsonProperty("precio_venta")]
        public double PrecioVenta { get; set; }

        [JsonProperty("iva")]
        public double Iva { get; set; }
        [JsonProperty("importe_descuento")]
        public double Importe_descuento { get; set; }
    }

}
