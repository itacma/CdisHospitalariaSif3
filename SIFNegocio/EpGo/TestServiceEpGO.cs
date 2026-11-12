using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SIFDatos.EpGo;
using SIFModelo.EpGo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SIFNegocio.EpGo
{
    public class TestServiceEpGO
    {

        // private HttpClient _httpClient;
        /// private  string _baseUrl = ""; // Cambiar por la IP/Puerto real

        //DatosConfiguracionEpGo epr = new DatosConfiguracionEpGo();

        //private static readonly ILog log = LogManager.GetLogger(typeof(TestServiceEpGO));
        public TestServiceEpGO()
        {
            NegocioConfiguracionEpGo._httpClient = new HttpClient();

            NegocioConfiguracionEpGo._httpClient.Timeout = TimeSpan.FromSeconds(10);

            NegocioConfiguracionEpGo
                .ListaEndPointsGo
                = DatosConfiguracionEpGo.GetConfiguracionEpGo();

            NegocioConfiguracionEpGo
                .ParametroActivo
                = new SIFNegocio
                        .Extras
                        .Parametros().ObtenParametro("SEND_DATA_API_GO");



        }

        public async Task<bool> validaToken(modelConfiguracionEpGo cnx)
        {
            try
            {

                if (!EsTokenVigente(cnx.Jwttoken))// si el token no es valida generamos 1 nuevo 
                {
                    cnx.Jwttoken = await ObtenerTokenJWT(cnx);
                    DatosConfiguracionEpGo.epgoUpdJwtToken(cnx);//actualizamos en la base de datos
                    return true;
                }
                return true;

            }
            catch (Exception _x)
            {
                return false;
            }

        }


        public bool CambiaEstadoEndPoint(modelConfiguracionEpGo cnx, string new_estado)
        {
            try
            {
                cnx.Activo = new_estado;
                DatosConfiguracionEpGo.epgoUpdActivo(cnx);//actualizamos en la base de datos
                return true;
            }
            catch (Exception _x)
            {
                return false;
            }

        }

        public async Task<bool> TestConectividadAll()
        {
            foreach (modelConfiguracionEpGo cnx in NegocioConfiguracionEpGo.ListaEndPointsGo)
            {

                if (!string.IsNullOrEmpty(cnx.Host))
                {
                    bool respuesta = await TestConectividad(cnx);
                    if (respuesta)
                    {

                        await validaToken(cnx);

                    }

                }
                return true;
            }
            return false;
        }

        public async Task<bool> TestConectividad(modelConfiguracionEpGo cnx)
        {
            //    if (String.IsNullOrEmpty(_baseUrl)) return false;
            //string _baseUrl = $"{cnx.Host}:{cnx.Port}/api";
            try
            {
                // El endpoint /health no requiere token JWT
                HttpResponseMessage response = await NegocioConfiguracionEpGo._httpClient.GetAsync($"{cnx._baseUrl}/health").ConfigureAwait(false); ;

                if (response.IsSuccessStatusCode)
                {
                    string contenido = await response.Content.ReadAsStringAsync();
                    CambiaEstadoEndPoint(cnx, "S");
                    return true;
                }

                LoggerHelper.Error("Servidor respondió con error: " + response.StatusCode);
                CambiaEstadoEndPoint(cnx, "N");
                return false;
            }
            catch (HttpRequestException ex)
            {
                LoggerHelper.Error("Error de red (¿Puerto cerrado o IP incorrecta?): " + ex.Message);
                CambiaEstadoEndPoint(cnx, "N");
                return false;
            }
        }
        public async Task<string> ObtenerTokenJWT(modelConfiguracionEpGo conf)
        {
            // if (String.IsNullOrEmpty(_baseUrl)) return null;
            try
            {
                // Creamos el objeto con las credenciales (debe coincidir con la struct de Go)
                var creds = new { usuario = conf.User_name, password = conf.Password };
                string json = JsonConvert.SerializeObject(creds);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Enviamos la petición POST al endpoint de login
                // .ConfigureAwait(false) es vital para evitar el bloqueo (deadlock)
                HttpResponseMessage response = await NegocioConfiguracionEpGo._httpClient.PostAsync($"{conf._baseUrl}/login", content).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var resultado = JsonConvert.DeserializeObject<LoginResponse>(responseBody);

                    return resultado.Token;
                }
                else
                {
                    LoggerHelper.Error("\n[ERROR Login]: " + response.ReasonPhrase);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Error("\n[ERROR Crítico Login]: " + ex.GetBaseException().Message);
                return null;
            }
        }





        public bool EsTokenVigente(string token)
        {

            ///Nota: Este metodo solo compara vigencia
            try
            {
                // 1. Dividir el token para obtener el Payload (la segunda parte)
                string[] partes = token.Split('.');
                if (partes.Length < 2) return false;

                string payloadBase64 = partes[1];

                // 2. Ajustar el relleno (padding) de Base64 si es necesario
                payloadBase64 = payloadBase64.Replace('-', '+').Replace('_', '/');
                switch (payloadBase64.Length % 4)
                {
                    case 2: payloadBase64 += "=="; break;
                    case 3: payloadBase64 += "="; break;
                }

                // 3. Decodificar de Base64 a String JSON
                byte[] datosRaw = Convert.FromBase64String(payloadBase64);
                string jsonString = Encoding.UTF8.GetString(datosRaw);

                // 4. Analizar el JSON para buscar el campo "exp"
                JObject json = JObject.Parse(jsonString);
                long expUnix = (long)json["exp"];



                // 1. Definimos el punto de partida (Unix Epoch)
                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

                // 2. Sumamos los segundos que vienen en el campo "exp"
                DateTime fechaExp = epoch.AddSeconds(expUnix);
                // 5. Comparar con la hora actual (UTC)
                //DateTime fechaExp = DateTimeOffset.FromUnixTimeSeconds(expUnix).UtcDateTime;

                // Retorna true si la fecha actual es menor a la de expiración
                return DateTime.UtcNow < fechaExp;
            }
            catch
            {
                // Si el token está mal formado o no tiene "exp", no es válido
                return false;
            }
        }


    }
}
