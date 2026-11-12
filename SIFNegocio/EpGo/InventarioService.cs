using Newtonsoft.Json;
using SIFModelo.EpGo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SIFNegocio.EpGo
{
    public class InventarioService
    {

        EpGoNegocioRemision epr = new EpGoNegocioRemision();
        //private static readonly ILog log = LogManager.GetLogger(typeof(VentaService));
        public InventarioService()
        {
            NegocioConfiguracionEpGo._httpClient = new HttpClient();
            NegocioConfiguracionEpGo._httpClient.Timeout = TimeSpan.FromSeconds(10);
            // _baseUrl = epr.ObtenerUrlServicioVentasInventario();

        }
        private async Task<bool> ProcesaEnviaInvetario(modelConfiguracionEpGo api, string documento, int tipo_mov_inv_id)
        {

            try
            {



                DataSet dsInvArtDoc = epr.epgoGetArticulosModificados(documento, tipo_mov_inv_id);


                List<string> listaIds = dsInvArtDoc.Tables["ArticulosModificados"].AsEnumerable()
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

                    NegocioConfiguracionEpGo._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", api.Jwttoken);

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


        public async Task<bool> ReportaInventarioWS(string documento, int tipo_mov_ind)
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


                //  DataSet ds = epr.epgoRemisionPagada(numeroRemision);
                //await ProcesaEnviaVenta(numeroRemision, cnx, ds);
                await ProcesaEnviaInvetario(cnx, documento, tipo_mov_ind);
                return true;
            }
            catch (Exception ex)
            {
                LoggerHelper.Error("Error crítico en el proceso: " + ex.Message);
                return false;
            }

        }

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

        private string FormatearFechaOracle(object fechaRow)
        {
            if (fechaRow == DBNull.Value || fechaRow == null) return "";
            return Convert.ToDateTime(fechaRow).ToString("yyyy-MM-dd HH:mm:ss");
        }


        public void SendInvetarioApiGo(string documento, int tipoMov_invId)
        {
            try
            {
                //SIFNegocio.EpGo.InventarioService servicio = new SIFNegocio.EpGo.InventarioService();


                bool estaConectado = System.Threading.Tasks.Task.Run(() => ReportaInventarioWS(documento, tipoMov_invId)).Result;
                // 3. Resultado
                if (estaConectado)
                {
                    LoggerHelper.Info("\n[EXITO] Conexión establecida con el servicio Go.");
                }
                else
                {
                    LoggerHelper.Error("\n[ERROR] No se pudo conectar al servicio.");
                }
            }
            catch (Exception _x)
            {


            }

        }





    }
}
