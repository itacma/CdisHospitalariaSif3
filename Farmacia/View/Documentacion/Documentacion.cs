using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SIF.View.Documentacion
{
    public partial class Documentacion : DevComponents.DotNetBar.Metro.MetroForm
    {

        private string[] _selectedFiles;
        //private string _parentFolderId = "14HVPlHObeolvSYxDrtFZdGybFh5uucok"; // Puedes cambiarlo por el ID de tu carpeta destino en Drive
        private string _parentFolderId = "19Vy9CabgZs0F_FIIziMvZBZeY5Ze9Bt0"; // Puedes cambiarlo por el ID de tu carpeta destino en Drive
        
        // Credenciales de Google Drive API (reemplaza con las tuyas)
        private static readonly string[] Scopes = { DriveService.Scope.DriveFile };
        private static readonly string ApplicationName = "DriveUploaderApp";


        public Documentacion()
        {
            InitializeComponent();
        }
        private async void seleccionarArchivosButtonItem1_Click(object sender, EventArgs e)
        { 
         OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Seleccionar archivos para cargar (máximo 30)";
            openFileDialog.Filter = "Todos los archivos (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileNames.Length > 0 && openFileDialog.FileNames.Length <= 30)
                {
                    _selectedFiles = openFileDialog.FileNames;
                    // Puedes mostrar los nombres de los archivos seleccionados en algún control de la interfaz si lo deseas
                    listBoxArchivosSeleccionados.Items.Clear();
                    foreach (string file in _selectedFiles)
                    {
                        listBoxArchivosSeleccionados.Items.Add(Path.GetFileName(file));
                        listBox2.Items.Add(Path.GetFileName(file));
                        
                    }
                    btnSubir.Enabled = true; // Habilitar el botón de subir una vez que se seleccionan archivos
                    cargarButtonItem.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Por favor, selecciona entre 1 y 30 archivos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _selectedFiles = null;
                    listBoxArchivosSeleccionados.Items.Clear();
                    btnSubir.Enabled = false;
                    cargarButtonItem.Enabled = false;
                }
            }
        }

            private async void button1_Click(object sender, EventArgs e)
        {
           
        }


        public async Task<string> GetFolderIdByNameAsync(DriveService service, string folderName)
        {
            var request = service.Files.List();
            request.Q = $"mimeType='application/vnd.google-apps.folder' and name='{folderName}' and trashed=false";
            var response = await request.ExecuteAsync();
            if (response.Files != null && response.Files.Count > 0)
            {
                return response.Files[0].Id; // Devuelve el ID de la primera carpeta con ese nombre
            }
            else
            {
                return null; // No se encontró ninguna carpeta con ese nombre
            }
        }


        
        private async void cargarButtonItem_Click(object sender, EventArgs e)
        {
 if (_selectedFiles != null && _selectedFiles.Length > 0)
            {
                btnCargarArchivos.Enabled = false;
                btnSubir.Enabled = false;
                cargarButtonItem.Enabled = false;
                progressBarSubida.Visible = true;
                progressBarSubida.Maximum = _selectedFiles.Length;
                progressBarSubida.Value = 0;
                lblEstadoSubida.Text = "Subiendo archivos...";

                try
                {/*
                    var service = await AuthenticateAndGetServiceAsync();

                    if (service != null)
                    {


                       //var v= await GetFolderIdByNameAsync(service, "EQUIPOS");

                        foreach (string filePath in _selectedFiles)
                        {
                            await UploadFileToDriveAsync(service, filePath, _parentFolderId);
                            progressBarSubida.Value++;
                            lblEstadoSubida.Text = $"Subiendo: {Path.GetFileName(filePath)} ({progressBarSubida.Value}/{progressBarSubida.Maximum})";
                        }

                        MessageBox.Show("Archivos subidos exitosamente a Google Drive.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);






                    }
                    else
                    {
                        MessageBox.Show("Error al autenticar con Google Drive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }*/


                    InitializeService();

                    // ID de la carpeta de Google Drive donde subir los archivos
                    string folderId = "19Vy9CabgZs0F_FIIziMvZBZeY5Ze9Bt0";
                    foreach (string filePath in _selectedFiles)
                    {
                        // Subir un archivo individual
                        string fileId = await UploadFileAsync(filePath, folderId);
                        MessageBox.Show($"Archivo subido con ID: {fileId}");
                    }
                    // Subir múltiples archivos
                    string[] filePaths = new string[] {
            "C:\\ruta\\al\\archivo1.pdf",
            "C:\\ruta\\al\\archivo2.jpg",
            "C:\\ruta\\al\\archivo3.mp4"
        };

                    List<string> fileIds = await UploadMultipleFilesAsync(filePaths, folderId,
                        (fileName, current, total) =>
                        {
                            Console.WriteLine($"Subiendo {fileName} ({current}/{total})");
                        });

                    Console.WriteLine($"Se subieron {fileIds.Count} archivos");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error durante la subida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnCargarArchivos.Enabled = true;
                    btnSubir.Enabled = false;
                    cargarButtonItem.Enabled = false;
                    progressBarSubida.Visible = false;
                    lblEstadoSubida.Text = "";
                    _selectedFiles = null;
                    listBoxArchivosSeleccionados.Items.Clear();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona archivos para subir primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


            private async void btnSubir_Click(object sender, EventArgs e)
        {
           
        }
            private static readonly string _credentialsJson = @"
                {
                ""installed"":{
                            ""client_id"":""781732223411-cpub1mum03214qj4t3c1onart066v3rc.apps.googleusercontent.com"",
                            ""project_id"":""sif3-doc-prov"",
                            ""auth_uri"":""https://accounts.google.com/o/oauth2/auth"",
                            ""token_uri"":""https://oauth2.googleapis.com/token"",
                            ""auth_provider_x509_cert_url"":""https://www.googleapis.com/oauth2/v1/certs"",
                            ""client_secret"":""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"",
                            ""redirect_uris"":[""http://localhost""]
                    }
                }";
        private async Task<DriveService> AuthenticateAndGetServiceAsync()
        {
            UserCredential credential;

            // Ruta al archivo JSON de tus credenciales de Google Cloud (descargado desde la consola de Google Cloud)
            //string credentialsPath = @"C:\Users\itacma\Downloads\client_secret_coordinaciongestion.json"; // Reemplaza con la ruta correcta
            string credentialsPath = @"C:\Users\itacma\Downloads\client_secret_sif3.json"; // Reemplaza con la ruta correcta



  


            try
            {
                /*using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json"; // Donde se guardará el token de acceso



                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)
                    );
                    Console.WriteLine("Credenciales guardadas en: " + credPath);
                }*/

                using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(_credentialsJson)))
                {
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore("token.json", true) // Puedes mantener FileDataStore para persistencia
                    );
                    Console.WriteLine("Credenciales cargadas desde texto.");
                }





                // Crear el servicio de Google Drive API.
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
                return service;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"El archivo de credenciales no se encontró en la ruta: {credentialsPath}", "Error de Credenciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error durante la autenticación: {ex.Message}", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private async Task UploadFileToDriveAsync(DriveService service, string filePath, string parentFolderId)
        {
            try
            {
                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = Path.GetFileName(filePath),
                    Parents = new List<string> { parentFolderId }
                };

                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    var uploadRequest = service.Files.Create(fileMetadata, stream, GetMimeTypev1(filePath));
                    uploadRequest.ProgressChanged += (progress) =>
                    {
                        switch (progress.Status)
                        {
                            case Google.Apis.Upload.UploadStatus.Uploading:
                                Console.WriteLine("Subiendo {0}: {1:P}", Path.GetFileName(filePath), progress.BytesSent / (double)stream.Length);
                                break;
                            case Google.Apis.Upload.UploadStatus.Completed:
                                Console.WriteLine("Subida de {0} completada.", Path.GetFileName(filePath));
                                break;
                            case Google.Apis.Upload.UploadStatus.Failed:
                                Console.WriteLine("Error en la subida de {0}: {1}", Path.GetFileName(filePath), progress.Exception);
                                break;
                        }
                    };
                    await uploadRequest.UploadAsync();
                }
            }
         
            catch (Exception ex)
            {
                MessageBox.Show($"Error al subir el archivo {Path.GetFileName(filePath)}: {ex.Message}", "Error de Subida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetMimeTypev1(string filePath)
        {
            string contentType = "application/octet-stream";
            string ext = Path.GetExtension(filePath).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                contentType = regKey.GetValue("Content Type").ToString();
            return contentType;
        }


        #region carga de archivos drive
        private DriveService _driveService;

        // Credenciales en formato JSON (reemplazar con tus propias credenciales)
        private static readonly string _serviceAccountJson = @" {
  ""type"": ""service_account"",
  ""project_id"": ""sif3-456417"",
  ""private_key_id"": ""97da9b1e5df6ce936ee43abe8b08ace8a6b457b0"",
  ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDGOuej8UMSW5cZ\nU24DmFwOHCfl2CtOKGZfyH3zxC/NFGfvvo3b31HyM8buyOiA/LW2YeJtZT9EY8a/\niHaSkGXFBIPACyvY8gzr+XUPQRCIEJcJfsva4jBMAFuA9oKMqn9sRTmaBiivWxBD\nuxQZWxmtw0xQ4MRkK6xIZObv9v3olgcMLURFLJRDD0Dq9LveCAz/WEiztU8bK3Y4\n0RvehG7vwa/dG6QYBCE8zGJuyB5x/4iVM4ODRY5zLbqPnHKozRw/CBVZ/xs3gbjq\nRU+kTR+IaG3TX2u5mGBQ7/tSS0GsvJa+kCvheK8gfZrhZ6UhYwapAUNRezUKIXHQ\nsFjbhLoPAgMBAAECggEAFM0Hk5d0f0+nGlw71hq9xilEMoUtfiUVIQXr2ZGDppR2\nl5y6TBEyCyVNwa7JXwellb7NwMb4DZgeueh68MRAOZ1Qqe1CK6CypGxn0TL1piF/\nh9qLT6uef8slzvGPH22gs17MPZJZ4JTAryrJYCPEHQy6TF5ZnV1L1cjoxtN3L1mn\nW4Rq/psSPztw8rnvdoSO9Jf+Zej3N4rGXFs+Xkfb1DfDAyO+khI3Q7VTI6vfjuGK\np4T61FoSF09h3c4biQhThNVUDa3HZK0stwg/EZmMQwfazum6Dvr3fJg/wM4oKQ/3\n6PL6uPOdojy+e+xDOo9y7nQfx+JBkYD+aE4jIlsuIQKBgQD5e93vG+jkXPMfwwBq\n4Rcvm2O3GTe3aJv7Epdv4Lx+Mgz751k0qI5TA2N1lveZ3tRS4NleHTKQdPhX7oHS\nIqnf0+cMK6KuKBf9I4W9xayia0QRfzVz92IRnS2nhYtJ/VPh9mEOomjzUOPsAIRR\n+i31gvg/74cCwVlVsKsF7tC/sQKBgQDLaFaJDX3gR+Awj6tF1zsJpVzM8c7jbrxg\n8AolJBPgW+R0a3BAib/VrBRtytwMmysnEpVlag+gGJV1MqglVudR0TUHuqISgsD5\nv8ngpQQcAhMhmHPvnf2h/fWcdkc/E1rSdCuNhWe2h8c4ZujKlEpEaWlOk/JH9WAk\nak185YtFvwKBgQCV6/i/Ur9OVAkKIi3jDGbZhgCTLEVOIz/wzghRA/VhxIQG8Myr\nl0sH2bZwGIusXLqtH0+gfd0/7/q5JKvA8nGw/u8OYj59d7yKs0kQdHS8mccq2I3v\npU66lQC1dcvxZ5l75YoHuFNnPEnrLZhWhwgNTGoQScmRP02G8AamJxAs0QKBgFX2\nnYPEaOtNVQkQ3rBgernj4elXVDk4BnLtX0w9CA1sqIsvELyluqYh2GxiLEdDmKQl\nrW+zuDDP0vI522gUZyRjxwaiMHakPcwO6tF+y9LOaalsFasx2QwKGS/rqMaWdm60\n2+cudxtkHKTQkRd0PkLVTcUAr4cLw3sAVgkvtYFfAoGBALkIy+HYepi5F3Y+tH4Q\ncsQn742gullL3LGEWFJwAb0M1jtDOOvqZuV/ELv0Tub/389HF7NV9LUHhZHKgi9S\nwsvkD5TWrBJqNVo4pbDr4R4mAVWvpnwKu6sH5LFOeNOqRwy5mvHjw+4sOCTJ0qDC\nB4C/6FW6IITWTV2K6Km6HRaD\n-----END PRIVATE KEY-----\n"",
  ""client_email"": ""cs-sif3-sistemaspr@sif3-456417.iam.gserviceaccount.com"",
  ""client_id"": ""101979217414702542631"",
  ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
  ""token_uri"": ""https://oauth2.googleapis.com/token"",
  ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
  ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/cs-sif3-sistemaspr%40sif3-456417.iam.gserviceaccount.com"",
  ""universe_domain"": ""googleapis.com""
}
";
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

            if (!System.IO.File.Exists(filePath))
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
                    MessageBox.Show($"Error al subir el archivo {Path.GetFileName(filePath)}: {ex.Message}");
                }
            }

            return uploadedFileIds;
        }
        /*
         * /// <summary>
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
        */
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

        public class GoogleDriveException : Exception
        {
            public GoogleDriveException(string message) : base(message) { }
            public GoogleDriveException(string message, Exception innerException) : base(message, innerException) { }
        }

        #endregion

    }
}
