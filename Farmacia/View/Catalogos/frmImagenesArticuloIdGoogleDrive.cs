using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace SIF.View.Catalogos
{
    public partial class frmImagenesArticuloIdGoogleDrive : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        static string[] Scopes = { DriveService.Scope.DriveReadonly };
        static string ApplicationName = "Drive API .NET Quickstart";
        public string ArticuloID;
        System.Windows.Forms.ImageList myImageList = new ImageList();
        System.Windows.Forms.ImageList myImageListSmall = new ImageList();
        System.Windows.Forms.ImageList myImageListLarge = new ImageList();
        int count = 0;

        string imagenSeleccionadaPaht = "";
        private string DirectoryImagenesEquipo="";//directorio de imagenes configurado en donde se descargaran las imagenes de drive
        private string DirectoryImagenesEquipoSku="";// directorio donde se alamcenan las imagenes por sku [DirectoryImagenesEquipo+ el sku del producto]
        private string DirectoryImagenesEquipoSkuRead = "";// directorio donde se alamcenan las imagenes por sku [DirectoryImagenesEquipo+ el sku del producto]

        public string ImageNewName = "";

        OpenFileDialog ofd = new OpenFileDialog()
        {
            Multiselect = true,
            ValidateNames = true,
            Filter =
         "JPG|*jpg|JPEG|*.jpeg|PNG|*.png"
        };
        FileInfo fi;

        public frmImagenesArticuloIdGoogleDrive(string _ArticuloID)
        {
            InitializeComponent();
            ArticuloID = _ArticuloID;
            // cargar();
            DescargarDatos();
        }


        private void cargar()
        {
            myImageList.ImageSize = new Size(100, 100);
            myImageListSmall.ImageSize = new Size(72, 72);
            myImageListLarge.ImageSize = new Size(150, 150);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //listView1
                listView1.Items.Clear();
                foreach (string fileName in ofd.FileNames)
                {
                    fi = new FileInfo(fileName);
                    FileInfo fileinfo = new FileInfo(fileName);
                    using (FileStream stream = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {

                        myImageList.Images.Add(Image.FromStream(stream));

                        myImageListSmall.Images.Add(Image.FromStream(stream));
                        myImageListLarge.Images.Add(Image.FromStream(stream));
                        stream.Dispose();
                        stream.Close();
                    }
                    
                    listView1.LargeImageList = myImageList;

                    listView1.Items.Add(new ListViewItem
                    {
                        ImageIndex = count,
                        Text = fi.Name,
                        Tag = fi.FullName
                    });
                    count++;
                }
            }


            /*  ImageList images = new ImageList();
              images.Images.Add(
                  LoadImage("https://drive.google.com/file/d/1MGZ1KaZKQqVdrwChuMPFoydhDOOWVJwj/view?usp=sharing"));
              images.Images.Add(
                  LoadImage("https://drive.google.com/file/d/1dhSI-aB52CNpr03Nf127oIjfFhUcMAyV/view?usp=sharing"));

              listView1.SmallImageList = images;
              listView1.Items.Add("An item", 0);
              listView1.Items.Add("Another item item", 1);*/

        }



        private Image LoadImage(string url)
        {
            System.Net.WebRequest request =
                System.Net.WebRequest.Create(url);

            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream =
                response.GetResponseStream();

            Bitmap bmp = new Bitmap(responseStream);

            responseStream.Dispose();

            return bmp;
        }

        private void DescargarDatos()
        {
            try
            {
                UserCredential credential;

                using (var stream =
                    new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }

                // Create Drive API service.
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                // Define parameters of request.
                FilesResource.ListRequest listRequest = service.Files.List();

                listRequest.PageSize = 500;
                listRequest.Fields = "nextPageToken, files(id, name)";

                // List files.
                IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                    .Files;
                Console.WriteLine("Files:");


                FilesResource.ListRequest listRequestID = service.Files.List();
                listRequestID.Q = "('1Q-usQ-W6KAVzJuZ6XEAGf4Zf_MmgdaYw' in parents)";


                //  listRequest.PageSize = 10;
                //    listRequest.Fields = "nextPageToken, files(id, name)";

                // List files.
                IList<Google.Apis.Drive.v3.Data.File> files_Folder = listRequestID.Execute()
                      .Files;


                if (files_Folder != null && files_Folder.Count > 0)
                {
                    foreach (var file in files_Folder)
                    {

                        // Console.WriteLine("{0} ({1})", file.Name, file.Id);
                        if (file.MimeType == "application/vnd.google-apps.folder")
                        {
                            if (ArticuloID == file.Name)
                            {


                                Console.WriteLine("Its a folder {0} ({1})", file.Name, file.Id);

                                var folderobj = List_Folder_Files(service, file.Id);
                                
                                
                                 DirectoryImagenesEquipo= @"C:\imagenes pagina";
                                clearfolder(file.Name, DirectoryImagenesEquipo);

                                foreach (var file_value in folderobj)
                                {

                                   
                                    DownloadFile(service, file_value, DirectoryImagenesEquipo + "\\" + file.Name+ "\\"+file_value.Name);

                                   
                                    Console.WriteLine("Its a folder {0} ({1})", file_value.Name, file_value.Id);
                                }
                                DirectoryImagenesEquipoSku = DirectoryImagenesEquipo + "\\" + file.Name;
                                DirectoryImagenesEquipoSkuRead = DirectoryImagenesEquipo + "\\" + file.Name;
                                getImagenesLocal(DirectoryImagenesEquipoSku);

                            }

                        }
                        else
                        {
                            Console.WriteLine("{0} ({1})({2})", file.Name, file.Id, file.MimeType);
                        }

                    }

                }
                /*
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        Console.WriteLine("{0} ({1})", file.Name, file.Id);
                    }

                }
                else
                {
                    Console.WriteLine("No files found.");
                }*/
                Console.Read();
            }
            catch (Exception _x) {


            }

        }

        private void getImagenesLocal(string pahtLocal) 
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(pahtLocal);

            myImageList=new ImageList();
            myImageList.ImageSize = new Size(50, 50);
             myImageListSmall.ImageSize = new Size(37, 37);
             myImageListLarge.ImageSize = new Size(80, 08);

            listView1.Items.Clear();
            listView1.Items.Clear();
            if (listView1.Items.Count > 0)
            {
                listView1.LargeImageList.Images.Clear();
            }
            foreach (FileInfo fileAlojado in di.GetFiles())
            {
                //fi = new FileInfo(fileAlojado.Name);
                //FileInfo fileinfo = new FileInfo(fileAlojado);
                using (FileStream stream = new FileStream(fileAlojado.FullName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    Image img = Image.FromStream(stream);
                    img.Tag = fileAlojado.FullName;
                    myImageList.Images.Add(fileAlojado.FullName, img);

                    //   myImageListSmall.Images.Add(Image.FromStream(stream));
                    //  myImageListLarge.Images.Add(Image.FromStream(stream));
                    stream.Close();
                    stream.Dispose();


                }
                listView1.LargeImageList = myImageList;

                listView1.Items.Add(new ListViewItem
                {
                    ImageIndex = count,
                    Text = fileAlojado.Name,
                    Tag = fileAlojado.FullName
                });
                count++;
            }
            if (listView1.Items.Count > 0)
            {
                ///Agregago la primera imagen a la
                using (FileStream stream = new FileStream(listView1.Items[0].Tag.ToString(), FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    pictureBox1.Image = Image.FromStream(stream);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    stream.Dispose();
                }
            }


           // pictureBox1.Image = Image.FromFile(listView1.Items[0].Tag.ToString());
           
          //  imagenSeleccionadaPaht = listView1.Items[0].Tag.ToString();


        }
        private void clearfolder( String sku , string PathImagenes) {
                        //Directorio principal de imagenes

            string PathImagenesSku = PathImagenes + "\\" + sku;/// diretorio del sku
            if (Directory.Exists(PathImagenes))
            {
              
                if (Directory.Exists(PathImagenesSku))
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(PathImagenesSku);

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    
                }
                else 
                {
                    Directory.CreateDirectory(PathImagenesSku);
                }
            }
            else {

               MessageBox.Show("No existe el diretorio de imagenes Para la pagina", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }


        }

        public static IList<Google.Apis.Drive.v3.Data.File> List_Folder_Files(DriveService service, string Folderid)
        {
            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            //listRequest.Q = "('1Q-usQ-W6KAVzJuZ6XEAGf4Zf_MmgdaYw' in parents)";
            listRequest.Q = "('" + Folderid + "' in parents)";
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                  .Files;
            return files;

        }


        private  void DownloadFile(Google.Apis.Drive.v3.DriveService service, Google.Apis.Drive.v3.Data.File file, string saveTo)
        {

            var request = service.Files.Get(file.Id);
            var stream = new System.IO.MemoryStream();

            // Add a handler which will be notified on progress changes.
            // It will notify on each chunk download and when the
            // download is completed or failed.
            request.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
            {
                switch (progress.Status)
                {
                    case Google.Apis.Download.DownloadStatus.Downloading:
                        {
                            Console.WriteLine(progress.BytesDownloaded);
                            break;
                        }
                    case Google.Apis.Download.DownloadStatus.Completed:
                        {
                            Console.WriteLine("Download complete.");
                            SaveStream(stream, saveTo);
                            break;
                        }
                    case Google.Apis.Download.DownloadStatus.Failed:
                        {
                            Console.WriteLine("Download failed.");
                            break;
                        }
                }
            };
            request.Download(stream);

        }


      

        private void SaveStream(MemoryStream stream, string FilePath)
        {
           // FilePath= @"C:\Users\itacma\Documents\Downloads\\quecholina.png";
            using (FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                stream.WriteTo(file);
                file.Close();
            }

        }

       
        private void AceptarMetroTileItem_Click(object sender, EventArgs e)
        {

            this.abrir();


        }
        private void SincronizarMetroTileItem_Click(object sender, EventArgs e)
        {
            try
            {
                UserCredential credential;

                using (var stream =
                    new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }

                // Create Drive API service.
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    // ApplicationName = ApplicationName,
                    ApplicationName ="InicioRapido",
                });


                System.IO.DirectoryInfo di = new DirectoryInfo(DirectoryImagenesEquipoSkuRead);

               
                foreach (FileInfo fileAlojado in di.GetFiles())
                {
                    


                    uploadFile(service, fileAlojado.FullName, "");

                    count++;
                }


               
            }
            catch (Exception ef) { }

        }
        private void EliminarMetroTileItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrEmpty(imagenSeleccionadaPaht))
                {

                    if (System.IO.File.Exists(imagenSeleccionadaPaht))
                    {

                        System.IO.File.Delete(imagenSeleccionadaPaht);
                       //MessageBox.Show("Archivo Eliminado");
                        getImagenesLocal(DirectoryImagenesEquipoSku);
                        imagenSeleccionadaPaht = "";
                    }
                    else MessageBox.Show("No se encontro el Archivo");
                }
            }
            catch (IOException ioExp)
            {
               MessageBox.Show( ioExp.Message);
            }


        }
        
        private void abrir()
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
                foreach (string fileName in ofd.FileNames)
                {
                    fi = new FileInfo(fileName);
                    FileInfo fileinfo = new FileInfo(fileName);
                    if (fi.DirectoryName != DirectoryImagenesEquipoSkuRead)
                    {

                        System.IO.File.Copy(fileName, DirectoryImagenesEquipoSkuRead+"\\"+fi.Name, true);
                        
                    }
                  
                }
                getImagenesLocal(DirectoryImagenesEquipoSkuRead);
            }


        }

        private void closeMetroTileItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("Esta seguro que desea salir?", "Espera", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            else
                this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           // pictureBox1.Image = Image.FromFile(listView1.SelectedItems().Tag.ToString());

        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

            using (FileStream stream = new FileStream(listView1.Items[e.ItemIndex].Tag.ToString(), FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                pictureBox1.Image = Image.FromStream(stream);
                stream.Dispose();
            }
           // pictureBox1.Image = Image.FromFile();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            imagenSeleccionadaPaht = listView1.Items[e.ItemIndex].Tag.ToString();
        }
        public Google.Apis.Drive.v3.Data.File uploadFile(DriveService _service, string _uploadFile, string _parent, string _descrp = "Uploaded with .NET!")
        {
            if (System.IO.File.Exists(_uploadFile))
            {
                Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
                body.Name = System.IO.Path.GetFileName(_uploadFile);
                body.Description = _descrp;
                body.MimeType = GetMimeType(_uploadFile);
                // body.Parents = new List<string> { _parent };// UN comment if you want to upload to a folder(ID of parent folder need to be send as paramter in above method)
                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try
                {
                    FilesResource.CreateMediaUpload request = _service.Files.Create(body, stream, GetMimeType(_uploadFile));
                    request.SupportsTeamDrives = true;
                    // You can bind event handler with progress changed event and response recieved(completed event)
                    request.ProgressChanged += Request_ProgressChanged;
                    request.ResponseReceived += Request_ResponseReceived;
                    request.Fields = "1Q-usQ-W6KAVzJuZ6XEAGf4Zf_MmgdaYw";
                    request.Upload();
                    var f= request.ResponseBody;
                    return f;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error Occured");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("The file does not exist.", "404");
                return null;
            }
        }

        private  string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }
        private void Request_ProgressChanged(Google.Apis.Upload.IUploadProgress obj)
        {
           // textBox2.Text += obj.Status + " " + obj.BytesSent;
        }

        private void Request_ResponseReceived(Google.Apis.Drive.v3.Data.File obj)
        {
            if (obj != null)
            {
                MessageBox.Show("File was uploaded sucessfully--" + obj.Id);
            }
        }

    }
}
