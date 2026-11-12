using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Windows.Forms;

namespace SIFNegocio.Extras
{
    public class GoogleDriveUploader
    {
        // Servicio de Google Drive
       /* private DriveService _driveService;

        // Credenciales en formato JSON (reemplazar con tus propias credenciales)
        private static readonly string _serviceAccountJson = @"{
  ""type"": ""service_account"",
  ""project_id"": ""tu-proyecto-id"",
  ""private_key_id"": ""tu-private-key-id"",
  ""private_key"": ""-----BEGIN PRIVATE KEY-----\nTu-Clave-Privada-Aquí\n-----END PRIVATE KEY-----\n"",
  ""client_email"": ""tu-service-account@tu-proyecto-id.iam.gserviceaccount.com"",
  ""client_id"": ""tu-client-id"",
  ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
  ""token_uri"": ""https://oauth2.googleapis.com/token"",
  ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
  ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/tu-service-account%40tu-proyecto-id.iam.gserviceaccount.com""
}";

        // Alcances de permisos
        private static readonly string[] Scopes = { DriveService.Scope.DriveFile };

        // Nombre de la aplicación
        private static readonly string ApplicationName = "GoogleDriveUploaderSimplified";

        /// <summary>
        /// Constructor que inicializa el servicio de Google Drive con autenticación de cuenta de servicio
        /// </summary>
        public GoogleDriveUploader()
        {
            try
            {
                // Inicializar el servicio
                InitializeService();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al inicializar el servicio de Google Drive: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Inicializa el servicio de Google Drive con autenticación de cuenta de servicio
        /// </summary>
        private void InitializeService()
        {
            try
            {
                // Crear credenciales desde el JSON de la cuenta de servicio
                using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(_serviceAccountJson)))
                {
                    var credential = GoogleCredential.FromStream(stream)
                        .CreateScoped(Scopes);

                    // Crear el servicio de Google Drive
                    _driveService = new DriveService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = ApplicationName,
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al inicializar el servicio: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Sube un archivo a Google Drive en la carpeta especificada
        /// </summary>
        /// <param name="filePath">Ruta del archivo a subir</param>
        /// <param name="folderId">ID de la carpeta de Google Drive donde se subirá el archivo</param>
        /// <returns>ID del archivo subido</returns>
        public async Task<string> UploadFileAsync(string filePath, string folderId)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("La ruta del archivo no puede estar vacía");

            if (string.IsNullOrEmpty(folderId))
                throw new ArgumentException("El ID de la carpeta no puede estar vacío");

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"No se encontró el archivo: {filePath}");

            try
            {
                // Crear metadatos del archivo
                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = Path.GetFileName(filePath),
                    Parents = new List<string> { folderId }
                };

                // Obtener el tipo MIME del archivo
                string mimeType = GetMimeType(filePath);

                // Crear el stream para subir el archivo
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    // Crear la solicitud de subida
                    var request = _driveService.Files.Create(fileMetadata, stream, mimeType);

                    // Configurar para reportar progreso
                    request.ProgressChanged += (progress) =>
                    {
                        switch (progress.Status)
                        {
                            case Google.Apis.Upload.UploadStatus.Uploading:
                                Console.WriteLine($"Subiendo {Path.GetFileName(filePath)}: {progress.BytesSent / (double)stream.Length:P}");
                                break;
                            case Google.Apis.Upload.UploadStatus.Completed:
                                Console.WriteLine($"Subida de {Path.GetFileName(filePath)} completada.");
                                break;
                            case Google.Apis.Upload.UploadStatus.Failed:
                                Console.WriteLine($"Error en la subida de {Path.GetFileName(filePath)}: {progress.Exception}");
                                break;
                        }
                    };

                    // Ejecutar la subida
                    var response = await request.UploadAsync();

                    // Verificar si la subida fue exitosa
                    if (response.Status == Google.Apis.Upload.UploadStatus.Completed)
                    {
                        return request.ResponseBody.Id;
                    }
                    else
                    {
                        throw new Exception($"Error al subir el archivo: {response.Status}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al subir el archivo {Path.GetFileName(filePath)}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Sube múltiples archivos a Google Drive en la carpeta especificada
        /// </summary>
        /// <param name="filePaths">Lista de rutas de archivos a subir</param>
        /// <param name="folderId">ID de la carpeta de Google Drive donde se subirán los archivos</param>
        /// <param name="progressCallback">Callback para reportar progreso (opcional)</param>
        /// <returns>Lista de IDs de los archivos subidos</returns>
        public async Task<List<string>> UploadMultipleFilesAsync(string[] filePaths, string folderId, Action<string, int, int> progressCallback = null)
        {
            if (filePaths == null || filePaths.Length == 0)
                throw new ArgumentException("La lista de archivos no puede estar vacía");

            if (string.IsNullOrEmpty(folderId))
                throw new ArgumentException("El ID de la carpeta no puede estar vacío");

            List<string> uploadedFileIds = new List<string>();
            int totalFiles = filePaths.Length;
            int currentFile = 0;

            foreach (string filePath in filePaths)
            {
                try
                {
                    currentFile++;

                    // Notificar progreso si se proporcionó un callback
                    progressCallback?.Invoke(Path.GetFileName(filePath), currentFile, totalFiles);

                    // Subir el archivo
                    string fileId = await UploadFileAsync(filePath, folderId);
                    uploadedFileIds.Add(fileId);
                }
                catch (Exception ex)
                {
                    // Continuar con el siguiente archivo en caso de error
                    Console.WriteLine($"Error al subir el archivo {Path.GetFileName(filePath)}: {ex.Message}");
                }
            }

            return uploadedFileIds;
        }

        /// <summary>
        /// Obtiene el ID de una carpeta por su nombre
        /// </summary>
        /// <param name="folderName">Nombre de la carpeta</param>
        /// <returns>ID de la carpeta o null si no se encuentra</returns>
        public async Task<string> GetFolderIdByNameAsync(string folderName)
        {
            if (string.IsNullOrEmpty(folderName))
                throw new ArgumentException("El nombre de la carpeta no puede estar vacío");

            try
            {
                // Crear la consulta para buscar la carpeta
                var request = _driveService.Files.List();
                request.Q = $"mimeType='application/vnd.google-apps.folder' and name='{folderName}' and trashed=false";
                request.Spaces = "drive";
                request.Fields = "files(id, name)";

                // Ejecutar la consulta
                var response = await request.ExecuteAsync();

                // Verificar si se encontró la carpeta
                if (response.Files != null && response.Files.Count > 0)
                {
                    return response.Files[0].Id;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar la carpeta {folderName}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Crea una carpeta en Google Drive
        /// </summary>
        /// <param name="folderName">Nombre de la carpeta</param>
        /// <param name="parentFolderId">ID de la carpeta padre (opcional)</param>
        /// <returns>ID de la carpeta creada</returns>
        public async Task<string> CreateFolderAsync(string folderName, string parentFolderId = null)
        {
            if (string.IsNullOrEmpty(folderName))
                throw new ArgumentException("El nombre de la carpeta no puede estar vacío");

            try
            {
                // Crear metadatos de la carpeta
                var folderMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = folderName,
                    MimeType = "application/vnd.google-apps.folder"
                };

                // Agregar carpeta padre si se especificó
                if (!string.IsNullOrEmpty(parentFolderId))
                {
                    folderMetadata.Parents = new List<string> { parentFolderId };
                }

                // Crear la carpeta
                var request = _driveService.Files.Create(folderMetadata);
                request.Fields = "id";
                var folder = await request.ExecuteAsync();

                return folder.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear la carpeta {folderName}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene el tipo MIME de un archivo
        /// </summary>
        /// <param name="filePath">Ruta del archivo</param>
        /// <returns>Tipo MIME del archivo</returns>
        private string GetMimeType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            // Mapa de extensiones comunes a tipos MIME
            Dictionary<string, string> mimeTypes = new Dictionary<string, string>
            {
                { ".pdf", "application/pdf" },
                { ".doc", "application/msword" },
                { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
                { ".xls", "application/vnd.ms-excel" },
                { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
                { ".ppt", "application/vnd.ms-powerpoint" },
                { ".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation" },
                { ".txt", "text/plain" },
                { ".csv", "text/csv" },
                { ".jpg", "image/jpeg" },
                { ".jpeg", "image/jpeg" },
                { ".png", "image/png" },
                { ".gif", "image/gif" },
                { ".bmp", "image/bmp" },
                { ".tif", "image/tiff" },
                { ".tiff", "image/tiff" },
                { ".mp3", "audio/mpeg" },
                { ".mp4", "video/mp4" },
                { ".avi", "video/x-msvideo" },
                { ".mov", "video/quicktime" },
                { ".wmv", "video/x-ms-wmv" },
                { ".zip", "application/zip" },
                { ".rar", "application/x-rar-compressed" },
                { ".7z", "application/x-7z-compressed" }
            };

            // Intentar obtener el tipo MIME del diccionario
            if (mimeTypes.TryGetValue(extension, out string mimeType))
            {
                return mimeType;
            }

            // Si no se encuentra en el diccionario, intentar obtenerlo del registro de Windows
            try
            {
                Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(extension);
                if (regKey != null && regKey.GetValue("Content Type") != null)
                {
                    return regKey.GetValue("Content Type").ToString();
                }
            }
            catch
            {
                // Ignorar errores al acceder al registro
            }

            // Si todo falla, devolver tipo genérico
            return "application/octet-stream";
        }
       */
    }
}
