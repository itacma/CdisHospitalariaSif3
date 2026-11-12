using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.IO.Compression;
using DevComponents.DotNetBar;

namespace SIF.View.Actualizador
{
    public partial class ProgresoDescarga : Form
    {
        public ProgresoDescarga()
        {
            InitializeComponent();
        }

        private void ProgresoDescarga_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            //MessageBox.Show("Es necesario actualizar el SIF3. \nPulse aceptar para comenzar la descarga de la nueva versión.","ACTUALIZADOR SIF3");
            try
            {
                //Cambiar la URL de descarga por nuevoSIF.exe y el destino de dummy a nuevoSIF.exe en caso de que se decida regresar a descarga via web
                //Cambiar la URL de descarga por dummy.txt en caso de que se decida regresar a ftp
                client.DownloadFileAsync(new Uri("http://www.ffleming.com.mx/download/sif3/compras/" + fileToDownload), "nuevoSIF.exe");
                progressBar1.Maximum = 10000;
                progressBar1.Value = (int)progressBar1.Maximum / 3;

            }
            catch
            {
               MessageBox.Show("ERROR AL DESCARGAR " + fileToDownload + " f-fleming \n\nRealice actualizacion manual");
            }

        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            SIF.Program.MessageBoxTemporal.Show("Descarga Completa! " + path, "ACTUALIZADOR SIF3", 5, false);
            this.Close();
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Maximum = ((int)(e.TotalBytesToReceive / 100));
            progressBar1.Value = (int)((e.BytesReceived / 100));
            //progressBar1.Maximum = 1000;//descomentar en caso de que se decida descargar via ftp
            //progressBar1.Value = 100;//descomentar en caso de que se decida descargar via ftp
            if (e.TotalBytesToReceive == e.BytesReceived)
            {
                if (progressBar1.Name != "TERMINADO")
                {
                    //ELIMINAR REGION EN CASO DE QUE SE DECIDA YA NO DESCARGAR MEDIANTE  FTP
                    /*
                    #region descargaftp

                    progressBar1.Value = (int)progressBar1.Maximum / 2;
                    try
                    {
                        String RemoteFtpPath = "ftp://www.ffleming.com.mx/public_html/download/sif3/compras/" + fileToDownload;
                        //MessageBox.Show("Ruta de fichero a descargar\n:"+RemoteFtpPath+":");
                        String LocalDestinationPath = "nuevoSIF.exe";
                        String Username = "ffleming";
                        String Password = "Ffl3m1ng!";
                        Boolean UseBinary = true; // use true for .zip file or false for a text file
                        Boolean UsePassive = false;

                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(RemoteFtpPath);
                        request.Method = WebRequestMethods.Ftp.DownloadFile;
                        request.KeepAlive = true;
                        request.UsePassive = UsePassive;
                        request.UseBinary = UseBinary;

                        request.Credentials = new NetworkCredential(Username, Password);
                        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                        Stream responseStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(responseStream);
                        using (FileStream writer = new FileStream(LocalDestinationPath, FileMode.Create))
                        {

                            long length = response.ContentLength;
                            int bufferSize = 2048;
                            int readCount;
                            byte[] buffer = new byte[2048];

                            readCount = responseStream.Read(buffer, 0, bufferSize);

                            while (readCount > 0)
                            {
                                writer.Write(buffer, 0, readCount);
                                readCount = responseStream.Read(buffer, 0, bufferSize);
                                if (progressBar1.Value + 1 > progressBar1.Maximum)
                                    progressBar1.Maximum = progressBar1.Maximum + 1;
                                progressBar1.Value += 1;
                            }
                        }
                        progressBar1.Value = progressBar1.Maximum;
                        reader.Close();
                        response.Close();
                    }
                    catch (WebException we)
                    {
                        MessageBox.Show("ERROR AL DESCARGAR " + fileToDownload + " via FTP \n\nRealice actualizacion manual \n " + we.ToString());
                    }




                    #endregion  descargaftp*/
                }
                progressBar1.Value = progressBar1.Maximum;
                progressBar1.Name = "TERMINADO";
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public string fileToDownload { get; set; }
    }
}