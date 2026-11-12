using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SIFModelo.EpGo;
using SIFModelo.EpGol;

namespace SIFNegocio.EpGo
{
    public class VentaService
    {

        EpGoNegocioRemision epr = new EpGoNegocioRemision();

        public VentaService()
        {
            NegocioConfiguracionEpGo._httpClient = new HttpClient();
            NegocioConfiguracionEpGo._httpClient.Timeout = TimeSpan.FromSeconds(10);
            // _baseUrl=epr.ObtenerUrlServicioVentasInventario();

        }

        //public async Task<bool> TestConectividad()
        //{
        //    if (String.IsNullOrEmpty(_baseUrl)) return false;

        //    try
        //    {
        //        // El endpoint /health no requiere token JWT
        //        HttpResponseMessage response = await _httpClient.GetAsync($"{_baseUrl}/health").ConfigureAwait(false); ;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            string contenido = await response.Content.ReadAsStringAsync();
        //            //og.("Conexión exitosa: " + contenido);
        //            return true;
        //        }

        //        log.Error("Servidor respondió con error: " + response.StatusCode);
        //        return false;
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        log.Error("Error de red (¿Puerto cerrado o IP incorrecta?): " + ex.Message);
        //        return false;
        //    }
        //}
        //public async Task<string> ObtenerTokenJWT(string usuario, string password)
        //{
        //    if (String.IsNullOrEmpty(_baseUrl)) return null;
        //    try
        //    {
        //        // Creamos el objeto con las credenciales (debe coincidir con la struct de Go)
        //        var creds = new { usuario = usuario, password = password };
        //        string json = JsonConvert.SerializeObject(creds);
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //        // Enviamos la petición POST al endpoint de login
        //        // .ConfigureAwait(false) es vital para evitar el bloqueo (deadlock)
        //        HttpResponseMessage response = await _httpClient.PostAsync($"{_baseUrl}/login", content).ConfigureAwait(false);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        //            var resultado = JsonConvert.DeserializeObject<LoginResponse>(responseBody);
        //            return resultado.Token;
        //        }
        //        else
        //        {
        //            log.Error("\n[ERROR Login]: " + response.ReasonPhrase);
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("\n[ERROR Crítico Login]: " + ex.GetBaseException().Message);
        //        return null;
        //    }
        //}


        private async Task<bool> ProcesaEnviaVenta(string numeroRemision, modelConfiguracionEpGo api, DataSet ds)
        {




            if (ds.Tables["Encabezado"].Rows.Count == 0)
            {
                LoggerHelper.Error("No se encontraron datos para la remisión: " + numeroRemision);
                return false;
            }
            // dsP = ds;
            // 2. Realizar el mapeo de var vtaRequest
            DataRow rowEnc = ds.Tables["Encabezado"].Rows[0];
            var vtaRequest = new VentaDocumentoRequest
            {
                TipoMovInvId = Convert.ToInt32(rowEnc["tipo_mov_inv_id"]),
                SucursalId = Convert.ToInt32(rowEnc["sucursal_id"]),
                Documento = rowEnc["documento"].ToString(),
                FechaGenera = Convert.ToDateTime(rowEnc["fecha_genera"]).ToString("yyyy-MM-dd HH:mm:ss"),
                FechaCierre = Convert.ToDateTime(rowEnc["fecha_cierre"]).ToString("yyyy-MM-dd HH:mm:ss"),
                UsuarioGenera = Convert.ToInt32(rowEnc["usuario_genera"]),
                Cliente = Convert.ToInt32(rowEnc["cliente"]),
                TipoCliente = rowEnc["tipo_cliente"].ToString(),
                Condiciones = rowEnc["condiciones"].ToString(),
                PCredito = rowEnc["pcredito"].ToString(),
                Sif = rowEnc["sif"] == DBNull.Value ? "" : rowEnc["sif"].ToString(),
                Descuento = rowEnc["descuento"].ToString(),
                ImporteDescuento = rowEnc["importe_descuento"].ToString(),
                ImporteTotal = Convert.ToDouble(rowEnc["importe_total"]),
                CajaId = Convert.ToInt32(rowEnc["caja_id"]),
                CajeroId = rowEnc["cajero_id"].ToString(),
                Detalle = ds.Tables["Detalle"].AsEnumerable().Select(d => new VentaDetalleRequest
                {
                    Partida = Convert.ToInt32(d["partida"]),
                    ArticuloId = d["articulo_id"].ToString(),
                    Existencia = d["existencia"] == DBNull.Value ? 0 : Convert.ToInt32(d["existencia"]),
                    Fecha = d["fecha"] == DBNull.Value ? "" : Convert.ToDateTime(d["fecha"]).ToString("yyyy-MM-dd HH:mm:ss"),
                    Entrada = d["entrada"] == DBNull.Value ? 0 : Convert.ToInt32(d["entrada"]),
                    Salida = d["salida"] == DBNull.Value ? 0 : Convert.ToInt32(d["salida"]),
                    CostoProm = d["costo_prom"] == DBNull.Value ? 0 : Convert.ToDouble(d["costo_prom"]),
                    Costo = d["costo"] == DBNull.Value ? 0 : Convert.ToDouble(d["costo"]),
                    UsuarioId = d["usuario_id"].ToString(),
                    KardexId = d["kardex_id"] == DBNull.Value ? 0 : Convert.ToInt32(d["kardex_id"]),
                    PrecioCosto = d["precio_costo"] == DBNull.Value ? 0 : Convert.ToDouble(d["precio_costo"]),
                    PrecioVenta = Convert.ToDouble(d["precio"]),
                    Iva = d["iva"] == DBNull.Value ? 0 : Convert.ToDouble(d["iva"]),
                    Importe_descuento = d["importe_descuento"] == DBNull.Value ? 0 : Convert.ToDouble(d["importe_descuento"])

                }).ToList()
            };

            // 3. Serializar y Configurar la petición HTTP
            string json = JsonConvert.SerializeObject(vtaRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Agregar el Token JWT al encabezado
            NegocioConfiguracionEpGo._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", api.Jwttoken);

            // 4. Enviar al endpoint de Go
            HttpResponseMessage response = await NegocioConfiguracionEpGo
                ._httpClient.PostAsync($"{api._baseUrl}/ventasSucursalesDocumento", content);

            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(resultString);

                if (result.code == 1)
                {
                    LoggerHelper.Info("Venta transmitida exitosamente.");
                    return true;
                }
            }

            return true;

        }

        private async Task<bool> ProcesaEnviaInvetarioDeVenta(modelConfiguracionEpGo api, DataSet ds)
        {

            try
            {

                //_httpClient = new HttpClient();
                //_httpClient.Timeout = TimeSpan.FromSeconds(10);



                if (ds.Tables["Detalle"].Rows.Count == 0)
                {
                    LoggerHelper.Error("No se encontraron datos para reportar el inventario ");
                    return false;
                }

                List<string> listaIds = ds.Tables["Detalle"].AsEnumerable()
                         .Select(row => row.Field<string>("articulo_id"))
                         .Where(id => !string.IsNullOrEmpty(id)) // Filtramos nulos o vacíos
                         .Distinct() // Evitamos duplicados si el mismo artículo aparece varias veces
                         .ToList();
                if (listaIds.Count() > 0)
                {
                    DataSet dsInvArt = epr.epgoGetInventario(listaIds);

                    var bulk = MapearInventario(dsInvArt);
                    string json = JsonConvert.SerializeObject(bulk);

                    //string json = JsonConvert.SerializeObject(vtaRequest);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    // Enviamos el inventario
                    HttpResponseMessage responseInventario = await NegocioConfiguracionEpGo.
                        _httpClient.PostAsync($"{api._baseUrl}/inventarioSucursales", content);

                    if (responseInventario.IsSuccessStatusCode)
                    {
                        string resultString = await responseInventario.Content.ReadAsStringAsync();
                        dynamic result = JsonConvert.DeserializeObject(resultString);

                        if (result.code == 1)
                        {
                            LoggerHelper.Info("inventario actualizado");
                            return true;
                        }
                    }

                    LoggerHelper.Error("Error al transmitir: " + responseInventario.ReasonPhrase);
                }
                return false;
            }
            catch (Exception _x)
            {
                return false;

            }
        }

        /// <summary>
        /// Procesa una remisión pagada y la envía al servicio de Go
        /// </summary>
        public async Task<bool> ReportarVentaWS(string numeroRemision)
        {
            if (NegocioConfiguracionEpGo.ParametroActivo <= 0)
                return false;

            modelConfiguracionEpGo cnx = NegocioConfiguracionEpGo.ListaEndPointsGo.FirstOrDefault(x => x.Name == "API_URL_VENTAS_INVENTARIO" && x.Id == "1");

            TestServiceEpGO tStatus = new TestServiceEpGO();
            try
            {
                if (cnx == null)
                { return false; }



                if (!await tStatus.TestConectividad(cnx))
                {
                    return false;
                }

                if (!await tStatus.validaToken(cnx))
                {
                    return false;
                }


                DataSet ds = epr.epgoRemisionPagada(numeroRemision);
                await ProcesaEnviaVenta(numeroRemision, cnx, ds);
                await ProcesaEnviaInvetarioDeVenta(cnx, ds);
                return true;
            }
            catch (Exception ex)
            {
                LoggerHelper.Error("Error crítico en el proceso: " + ex.Message);
                return false;
            }

        }



        //private async Task<string> epgoGestionarToken() {


        //    string  tkDb=epr.epgoGestionarToken("G", "");
        //    if (tkDb == "NewToken")
        //    {

        //        string jwtToken = await ObtenerTokenJWT("admin_farmacia", "Farma2026!");
        //        if (!String.IsNullOrEmpty(jwtToken))
        //        SIFDatos.EpGo.EpGoRemision.epgoGestionarToken("U", jwtToken);
        //        return jwtToken;
        //    }
        //    else
        //        return tkDb;

        //}



        public InventarioBulkRequest MapearInventario(DataSet ds)
        {
            var bulk = new InventarioBulkRequest { articulos = new List<InventarioRequest>() };

            if (ds.Tables.Contains("InventarioActual"))
            {
                foreach (DataRow row in ds.Tables["InventarioActual"].Rows)
                {
                    var item = new InventarioRequest
                    {
                        // Identificadores
                        articulo_id = row["ARTICULO_ID"].ToString(),
                        sucursal_id = row["SUCURSAL_ID"] == DBNull.Value ? 0 : Convert.ToInt32(row["SUCURSAL_ID"]),

                        // Cantidades (Enteros)
                        existencias = row["EXISTENCIAS"] == DBNull.Value ? 0 : Convert.ToInt32(row["EXISTENCIAS"]),
                        existencia_min = row["EXISTENCIA_MIN"] == DBNull.Value ? 0 : Convert.ToInt32(row["EXISTENCIA_MIN"]),
                        existencia_max = row["EXISTENCIA_MAX"] == DBNull.Value ? 0 : Convert.ToInt32(row["EXISTENCIA_MAX"]),
                        punto_de_reorden = row["PUNTO_DE_REORDEN"] == DBNull.Value ? 0 : Convert.ToInt32(row["PUNTO_DE_REORDEN"]),
                        inv_fisico = row["INV_FISICO"] == DBNull.Value ? 0 : Convert.ToInt32(row["INV_FISICO"]),
                        apartado_vtas = row["APARTADO_VTAS"] == DBNull.Value ? 0 : Convert.ToInt32(row["APARTADO_VTAS"]),

                        // Costos (Doubles)
                        ult_costo = row["ULT_COSTO"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["ULT_COSTO"]),
                        costo_prom = row["COSTO_PROM"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["COSTO_PROM"]),
                        peps = row["PEPS"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["PEPS"]),
                        ueps = row["UEPS"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["UEPS"]),

                        // Ubicación y Auditoría
                        ubicacion = row["UBICACION"]?.ToString() ?? "",
                        ult_usuario = row["ULT_USUARIO"]?.ToString() ?? "",
                        ult_documento = row["ULT_DOCUMENTO"]?.ToString() ?? "",
                        ult_mov_inv_id = row["ULT_MOV_INV_ID"] == DBNull.Value ? 0 : Convert.ToInt32(row["ULT_MOV_INV_ID"]),
                        ult_partida = row["ULT_PARTIDA"] == DBNull.Value ? 0 : Convert.ToInt32(row["ULT_PARTIDA"]),

                        // Fechas formateadas para Go 📅
                        fecha_ult_mov = FormatearFechaOracle(row["FECHA_ULT_MOV"]),
                        fecha_ult_ent = FormatearFechaOracle(row["FECHA_ULT_ENT"]),
                        fecha_ult_sal = FormatearFechaOracle(row["FECHA_ULT_SAL"]),
                        fecha_inv_fisico = FormatearFechaOracle(row["FECHA_INV_FISICO"]),
                        ult_fecha_refresh = FormatearFechaOracle(row["ULT_FECHA_REFRESH"])
                    };

                    bulk.articulos.Add(item);
                }
            }

            return bulk;
        }

        // Método auxiliar para evitar repetir la lógica de fechas
        private string FormatearFechaOracle(object fechaRow)
        {
            if (fechaRow == DBNull.Value || fechaRow == null) return "";
            return Convert.ToDateTime(fechaRow).ToString("yyyy-MM-dd HH:mm:ss");
        }

    }


    // Esta clase debe estar en el mismo archivo o en uno nuevo dentro del proyecto
    public class LoginResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
