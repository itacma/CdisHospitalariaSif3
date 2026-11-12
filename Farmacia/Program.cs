using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System.IO;
using CrashReporterDotNET;
using System.Threading;
using DevComponents.DotNetBar;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Configuration;
using SIF.Helpers;
using SIF.View.Actualizador;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Xml;


namespace SIF
{
    internal class ExampleApp : WindowsFormsApplicationBase
    {

        //protected override void OnCreateSplashScreen()
        //{
        //    // Custom splash screen
        //    this.SplashScreen = new Templates.SplashCreenForm();
        //}


        protected override void OnCreateMainForm()
        {

            base.OnCreateMainForm();
            // Time consuming startup operations go here
            // Application main form
            this.MainForm = new MainForm("N/A");
        }
    }


    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static public byte[] GetFileViaHttp(string url)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadData(url);
            }
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CultureInfo ci = new CultureInfo("es-MX");
            Application.CurrentCulture = ci;
            //Application.CurrentUICulture = ci;


#if !DEBUG
            Application.ThreadException +=
               ApplicationThreadException;
#endif
            if (!buscaSecionesAbiertas())
                return;

            Templates.SplashCreenForm frmSplash = new Templates.SplashCreenForm();
            Application.DoEvents();
            frmSplash.ShowDialog();

            try
            {

                string w_file = "SIF.exe";
                string w_directory = Directory.GetCurrentDirectory();
                //MessageBox.Show("LEYENDO FECHA ACTUAL DE SIF.EXE");//COMENTAR**************************************************
                DateTime c3 = File.GetLastWriteTime(System.IO.Path.Combine(w_directory, w_file));
                //MessageBoxTemporal.Show(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version + " *** " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString() + "fecha" + c3.ToString(), "ACTUALIZACION", 30, false);
                string defaultFileToDownload = "nuevoSIF.exe";
                File.Delete(defaultFileToDownload); //Borrar nuevoSIF.exe
                string fileToDownload = defaultFileToDownload; //almacena el nombre del archivo que contiene el paquete actualizador. Por defecto nuevoSIF.exe
                string macAddresses = string.Empty;

                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.OperationalStatus == OperationalStatus.Up)
                    {
                        macAddresses += nic.GetPhysicalAddress().ToString();
                        break;
                    }
                }
#if !DEBUG
                #region actualizadorWEB
                //ACTUALIZAR VIA WEB
                try
                {

                    //System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 1");
                    //System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2");
                    //System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 8");

                    //Para obtener el ID de la sucursal
                    string mLocationS = Directory.GetCurrentDirectory();
                    AssemblyName myAssemblyName = AssemblyName.GetAssemblyName(mLocationS + "\\SIF.exe");
                    Assembly xAssembly = Assembly.Load(myAssemblyName);
                    //xAssembly = xAssembly.GetType().Assembly;

                    string ConfigFile = xAssembly.ManifestModule.Name + ".config";
                    int sucursalId = 0;
                    XmlReader reader = XmlReader.Create(ConfigFile);
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "add"))
                        {
                            if (reader.HasAttributes)
                            {
                                if (reader.GetAttribute("key") == "SucursalID")
                                {
                                    //MessageBox.Show(reader.GetAttribute("value"));
                                    sucursalId = Int32.Parse(reader.GetAttribute("value"));
                                }
                            }
                        }
                    }
                    //reader.Close();

                    //MessageBox.Show("OBTENIENDO VERSION.TXT");//COMENTAR****************************************************
                    var result = GetFileViaHttp(@"http://www.ffleming.com.mx/download/sif3/compras/version2.txt");
                    string str = System.Text.Encoding.UTF8.GetString(result);
                    string[] strArr = str.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    //MessageBox.Show("*" + strArr[0] + "*" + c3.ToString() + "*");//COMENTAR****************************************************
                    //DateTime  dtFile = Convert.ToDateTime(strArr[0]);
                    var dtFile = DateTime.ParseExact(strArr[0], "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);//fecha contenida en version2.exe (es la fecha de la versión general)

                    //MessageBox.Show("convertido a fecha "+ dtFile.ToString());//COMENTAR****************************************************
                    string tamanyoNuevoSIF = strArr[1];//Peso en bytes de version general (nuevoSIF.exe)
                    string tamanyoActualizaSIF = strArr[2];
                    string wallPaper = strArr[3];

                    string versionesEspeciales = strArr[4];//Obtener versiones especificas para cada sucursal
                    defaultFileToDownload = strArr[5];
                    fileToDownload = defaultFileToDownload;
                    string[] sucursales_versiones = versionesEspeciales.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);//obtener cada una de las sucursales y su version especifica
                    //string fileToDownload = "nuevoSIF.exe"; //almacena el nombre del archivo que contiene el paquete actualizador. Por defecto nuevoSIF.exe
                    string[] detalleVersion = new string[1];
                    foreach (string version in sucursales_versiones)//accede a la sección que contiene la lista de sucursales y sus versiones 2-nuevoSIF2.exe-4402129,8-nuevoSIF8.exe-4402129)
                    {
                        detalleVersion = version.Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);//parte la lista en distintos elementos separandolos por guión (-)
                        if (detalleVersion.Length >= 4)
                        {
                            if (detalleVersion[0] != "" && detalleVersion[1] != "" && detalleVersion[2] != "" && detalleVersion[3] != "")
                            {
                                /*MessageBox.Show(version + "\n sucursal_id:" + detalleVersion[0] + ":\n versionEspecifica :" +
                                    detalleVersion[1] + " Peso:" + detalleVersion[2] + ": fecha :"+detalleVersion[3]+": ej : :"
                                    );*/
                                if (detalleVersion[0] == sucursalId.ToString()) //Si la sucursal aparece en la lista de versiones especiales, cambia el nombre de version a descargar y su fecha
                                {
                                    fileToDownload = detalleVersion[1];//Nombre de versión específica (ya no descarga nuevoSIF.exe sino la version específica)
                                    dtFile = DateTime.ParseExact(detalleVersion[3], "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);//Cambia la fecha general por la fecha de la versión específica
                                    tamanyoNuevoSIF = detalleVersion[2]; //Obtiene peso de versión específica, ya no toma el peso de la versión general
                                }
                            }
                            else
                            {
                                fileToDownload = defaultFileToDownload + " hay versiones especificas, faltaParametro";
                            }
                        }
                        else
                        {
                            fileToDownload = defaultFileToDownload + "sin datos de versiones especificas.";
                        }

                    }
                    if (macAddresses != "C8F750F8CA46")
                    {
                        var existeWall = File.Exists(wallPaper);
                        if (!existeWall)
                        {
                            WebClient webClientWall = new WebClient();
                            webClientWall.DownloadFile("http://www.ffleming.com.mx/download/sif3/wallpaper/" + wallPaper, wallPaper);
                        }
                        Wallpaper.Set(wallPaper, Wallpaper.Style.Centered);
                    }
                    //MessageBox.Show("TAMANYO ARCHIVO " + tamanyoNuevoSIF);//COMENTAR****************************************************
                    int resultf = DateTime.Compare(dtFile, c3);//comparamos fecha de ffleming.version.txt contra fecha de SIF.exe local
                    long length = 0;
                    //MessageBox.Show("resultado comparar fechas " + resultf);////COMENTAR****************************************************    

                    if (resultf > 0)//si la fecha de ffleming es mayor, actualizamos
                    {
                        MessageBox.Show("Es necesario actualizar SIF3, pulse aceptar para comenzar con la descarga");
                        try //Descarga de actualizaSIF.bat
                        {
                            WebClient myWebClient = new WebClient();
                            // Download the Web resource and save it into the current filesystem folder.
                            myWebClient.DownloadFile("http://www.ffleming.com.mx/download/sif3/compras/actualizaSIF.bat", "actualizaSIF.bat");
                        }
                        catch (System.Net.WebException wEx)
                        {
                           MessageBox.Show("LA DESCARGA DE actualizaSIF.bat FALLÓ\n\n Intentelo nuevamente más tarde \n" + wEx.Message);
                            fileToDownload = defaultFileToDownload + "x";
                        }
                        catch (System.NotSupportedException notEx)
                        {
                           MessageBox.Show("LA DESCARGA DE actualizaSIF.bat FALLÓ\n\n Intentelo nuevamente más tarde \n" + notEx.Message);
                            fileToDownload = defaultFileToDownload + "x";
                        }

                        try
                        {
                            length = new System.IO.FileInfo("actualizaSIF.bat").Length;
                        }
                        catch (System.IO.FileNotFoundException notfEx)
                        {
                           MessageBox.Show("NO EXISTE EL ARCHIVO actualizaSIF.bat \n\n Intentelo nuevamente más tarde \n" + notfEx.Message);
                            fileToDownload = defaultFileToDownload + "x";
                        }
                        //MessageBox.Show(length.ToString() + " - " + tamanyoArchivo);////COMENTAR****************************************************
                        if (length == 0)//si el archivo descargado tiene tamaño 0
                        {
                           MessageBox.Show("NO SE DESCARGO actualizaSIF.bat http://www.ffleming.com.mx/download/sif3/compras/actualizaSIF.bat \n INTENTELO NUEVAMENTE MAS TARDE", "ACTUALIZADOR SIF3");
                            fileToDownload = defaultFileToDownload + "x";

                        }
                        else if (length.ToString() != tamanyoActualizaSIF)//si el archivo descargado no coincide en tamaño contra el tamaño indicado por ffleming.version.txt
                        {
                           MessageBox.Show("EL PESO DE actualizaSIF.bat NO COINCIDE\n\nDESCARGADA - ULTIMA VERSION \n" + length.ToString() + " - " + tamanyoActualizaSIF + "\n\n INTENTELO NUEVAMENTE MAS TARDE", "ACTUALIZADOR SIF3");
                            fileToDownload = defaultFileToDownload + "x";

                        }
                        else //SI SE DESCARGO CORRECTAMENTE actualizaSIF.bat, procedemos a descargar nuevoSIF.exe
                        {
                            //MessageBox.Show("ABRIENDOCUADRO DE DESCARGA");////COMENTAR****************************************************                                          
                            ProgresoDescarga pd = new ProgresoDescarga();
                            pd.fileToDownload = fileToDownload;
                            pd.ShowDialog();
                            //MessageBox.Show("OBTENIENDO TAMANYO DE ARCHIVO ZIP DESCARGADO");////COMENTAR****************************************************
                            if (File.Exists("nuevoSIF.exe"))
                                length = new System.IO.FileInfo("nuevoSIF.exe").Length;
                            else
                            {
                                length = 0;
                            }
                            //MessageBox.Show(length.ToString() + " - " + tamanyoArchivo);////COMENTAR****************************************************
                            if (length == 0)//si el archivo descargado tiene tamaño 0
                            {
                               MessageBox.Show("NO SE DESCARGO " + fileToDownload + ", VERIFIQUE nuevoSIF.exe http://www.ffleming.com.mx/download/sif3/compras/nuevoSIF.exe \n INTENTELO DE NUEVO MAS TARDE", "ACTUALIZADOR SIF3");
                                fileToDownload = defaultFileToDownload + "x";

                            }
                            else if (length.ToString() != tamanyoNuevoSIF)//si el archivo descargado no coincide en tamaño contra el tamaño indicado por ffleming.version.txt
                            {
                               MessageBox.Show("EL PESO DE " + fileToDownload + " NO COINCIDE\n\nDESCARGADA - ULTIMA VERSION \n" + length.ToString() + " - " + tamanyoNuevoSIF + "\n\n INTENTELO NUEVAMENTE MAS TARDE", "ACTUALIZADOR SIF3");
                                fileToDownload = defaultFileToDownload + "x";

                            }
                            else
                            {
                                //MessageBox.Show("OBTENIENDO PATH ACTUAL");////COMENTAR****************************************************
                                string path = Directory.GetCurrentDirectory();
                                MessageBox.Show("Se procederá a actualizar, por favor cierre todos los puntos de venta abiertos y pulse aceptar. \n" + path, "ACTUALIZADOR SIF3");
                                try
                                {
                                    string proceso = "actualizaSIF.bat";
                                    ProcessStartInfo startInfo = new ProcessStartInfo(proceso);
                                    startInfo.Verb = "runas";
                                    System.Diagnostics.Process.Start(startInfo);
                                    return;
                                }
                                catch
                                {
                                   MessageBox.Show("LA ACTUALIZACION FALLÓ POR UNA EXCEPCION NO CONTROLADA AL EJECUTAR actualizaSIF.bat\nREALICE LA ACTUALIZACION MANUAL", "ACTUALIZADOR SIF3");
                                    fileToDownload = defaultFileToDownload + "x";
                                }
                            }
                        }
                    }
                    if (resultf == 0)
                    {
                        //MessageBox.Show(dtFile.ToString() + " nueva = local " + c3.ToString() + "El SIF se encuentra actualizado");                         
                        resultf = 0;
                    }
                    if (resultf < 0)
                    {
                        //MessageBox.Show(dtFile.ToString() + " nueva < local " + c3.ToString() + "El SIF se encuentra actualizado");
                        resultf = -1;
                    }

                }
                catch (WebException we)
                {


                    if (we.Status == WebExceptionStatus.NameResolutionFailure)
                    {
                        string errMsg = "Servidor de actualizacion SIF ffleming regreso  NOT FOUND exception para http://www.ffleming.com.mx/download/sif3/compras/version.txt o para Wallpaper \n Verify that the server is up and running.";
                        MessageBox.Show(errMsg, "Administrador de actualizacion de SIF3");
                        fileToDownload = defaultFileToDownload + "x";

                    }
                    else if (we.Status == WebExceptionStatus.Timeout)
                    {

                        string errMsg = "No se pudo conectar con servidor de actualización\n Servidor de actualizacion SIF  f-fleming regresó Timeout exception para http://www.ffleming.com.mx/download/sif3/compras/version.txt o para Wallpaper \n\nVerifique su conexión a internet e inténtelo de nuevo. \nVerify that the server is up and running.";
                        MessageBox.Show(errMsg, "Administrador de actualizacion de SIF3");
                        fileToDownload = defaultFileToDownload + "x";

                    }
                    else
                        if (we.Status == WebExceptionStatus.ProtocolError)
                        {

                            string errMsg = "No se pudo conectar con servidor de actualización \nServidor de  actualizacion SIF f-fleming regreso Timeout exception (Protocol error) para http://www.ffleming.com.mx/download/sif3/compras/version.txt o para Wallpaper \n\nVerifique su conexión a internet e inténtelo de nuevo. \nVerify that the server is up and running.";
                            MessageBox.Show(errMsg, "Administrador de actualizacion de SIF3");
                            fileToDownload = defaultFileToDownload + "x";

                        }
                        else
                        {

                            string errMsg = "Servidor de  actualizacion SIF ffleming regreso Unhandled exception para http://www.ffleming.com.mx/download/sif3/compras/version.txt o para Wallpaper \n VERIFIQUE SU CONEXION A INTERNET";
                            MessageBox.Show(errMsg, "Administrador de actualizacion de SIF3");
                            fileToDownload = defaultFileToDownload + "x";
                        }
                }
                catch (Exception e) { MessageBox.Show(e.ToString()); fileToDownload = defaultFileToDownload; }
                #endregion actualizadorWEB
                /*finaliza porción de código para actualizar*/


#endif
                // MessageBox.Show("FINALIZO CODIGO PARA ACTUALIZAR");////COMENTAR****************************************************

                Application.Run(new MainForm(fileToDownload));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido una excepción no controlada, por favor envie la siguiente información"+Environment.NewLine+ex.ToString());

                //ENVIAMOS LA EXCEPCION
                var reportCrash = new ReportCrash
                {
                    FromEmail = "ExcepcionesSIF3@gmail.com",
                    ToEmail = "ExcepcionesSIF3@gmail.com",
                    SMTPHost = "smtp.gmail.com",
                    Port = 587,
                    UserName = "ExcepcionesSIF3@gmail.com",
                    Password = "fuaf.0605",
                    EnableSSL = true,
                };
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("ExcepcionesSIF3@gmail.com", "fuaf.0605"),
                    EnableSsl = true
                };
                try
                {


                    IPHostEntry host;
                    string localIP = " ";
                    host = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (IPAddress ip in host.AddressList)
                    {
                        if (ip.AddressFamily.ToString() == "InterNetwork")
                        {
                            localIP = ip.ToString();
                        }
                    }
                    // MessageBox.Show("Tú IP Local Es: " + localIP);
                    client.Send("ExcepcionesSIF3@gmail.com", "ExcepcionesSIF3@gmail.com", "Excepcion SIF3:::: IP:" + localIP.ToString() + " Usuario:" + Helpers.Sesion.Usuario.UsuariosID.ToString() + " Suc:" + Helpers.Sesion.Sucursal.SucursalID.ToString(), ex.ToString() + " : " + Helpers.Sesion.Sucursal.Nombre.ToString());
                    reportCrash.Send(ex);
                }
                catch { }

                //DIRECCION DEL ENSAMBLADO

                using (StreamWriter sw = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + "\\log.sif"))
                {
                    // Add some text to the file.
                    //sw.Write("This is the ");
                    sw.WriteLine("---------" + SIFNegocio.Configuracion.Configuraciones.fechaServidor() + "----------");
                    sw.WriteLine(ex.ToString());

                    if (ex.InnerException != null)
                    {
                        sw.WriteLine("INNER EXCEPTION");
                        sw.WriteLine(ex.InnerException.ToString());
                    }
                    sw.WriteLine("-------------------");
                    // Arbitrary objects can also be written to the file.
                }

            }
            //ExampleApp application = new ExampleApp();
            //#if !DEBUG
            //            application.Run(Environment.GetCommandLineArgs());
            //#else
#if !DEBUG 
            try
            {
           
                Application.Run(new MainForm("N/A"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido una excepción no controlada, por favor envie la siguiente información");

                //ENVIAMOS LA EXCEPCION
                var reportCrash = new ReportCrash
                {
                    FromEmail = "sif.farmacia@gmail.com",
                    ToEmail = "sif.farmacia@gmail.com",
                    SMTPHost = "smtp.gmail.com",
                    Port = 587,
                    UserName = "sif.farmacia@gmail.com",
                    Password = "siffarmacia",
                    EnableSSL = true,
                };

                reportCrash.Send(ex);

                //DIRECCION DEL ENSAMBLADO

                using (StreamWriter sw = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + "\\log.sif"))
                {
                    // Add some text to the file.
                    //sw.Write("This is the ");
                    sw.WriteLine("---------" + SIFNegocio.Configuracion.Configuraciones.fechaServidor() + "----------");
                    sw.WriteLine(ex.ToString());

                    if (ex.InnerException != null)
                    {
                        sw.WriteLine("INNER EXCEPTION");
                        sw.WriteLine(ex.InnerException.ToString());
                    }
                    sw.WriteLine("-------------------");
                    // Arbitrary objects can also be written to the file.
                }

            }  
#else
            //try
            //{
            Application.Run(new MainForm("N/A"));
            //}
            //catch (Exception e)
            //{
            //    if (e.Message.ToString() == "Error en la operación solicitada del Portapapeles.")
            //    {
            //       MessageBox.Show("Error en la operación solicitada del Portapapeles.");

            //    }
            //    else
            //    {
            //        var reportCrash = new ReportCrash
            //        {
            //            FromEmail = "sif.farmacia@gmail.com",
            //            ToEmail = "sif.farmacia@gmail.com",
            //            SMTPHost = "smtp.gmail.com",
            //            Port = 587,
            //            UserName = "sif.farmacia@gmail.com",
            //            Password = "siffarmacia",
            //            EnableSSL = true,
            //        };

            //        reportCrash.Send(e);
            //    }
            //}
#endif
        }

        static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var reportCrash = new ReportCrash
            {
                FromEmail = "sif.farmacia@gmail.com",
                ToEmail = "sif.farmacia@gmail.com",
                SMTPHost = "smtp.gmail.com",
                Port = 587,
                UserName = "sif.farmacia@gmail.com",
                Password = "siffarmacia",
                EnableSSL = true,
            };

            reportCrash.Send(e.Exception);
        }

        public class MessageBoxTemporal
        {
            System.Threading.Timer IntervaloTiempo;
            string TituloMessageBox;
            string TextoMessageBox;
            int TiempoMaximo;
            IntPtr hndLabel = IntPtr.Zero;
            bool MostrarContador;

            MessageBoxTemporal(string texto, string titulo, int tiempo, bool contador)
            {
                TituloMessageBox = titulo;
                TiempoMaximo = tiempo;
                TextoMessageBox = texto;
                MostrarContador = contador;

                if (TiempoMaximo > 99) return; //Máximo 99 segundos
                IntervaloTiempo = new System.Threading.Timer(EjecutaCada1Segundo,
                    null, 1000, 1000);
                if (contador)
                {
                    DialogResult ResultadoMensaje = MessageBox.Show(texto + "\r\nEste mensaje se cerrará dentro de " +
                        TiempoMaximo.ToString("00") + " segundos ...", titulo);
                    if (ResultadoMensaje == DialogResult.OK) IntervaloTiempo.Dispose();
                }
                else
                {
                    DialogResult ResultadoMensaje = MessageBox.Show(texto + "...", titulo);
                    if (ResultadoMensaje == DialogResult.OK) IntervaloTiempo.Dispose();
                }
            }
            public static void Show(string texto, string titulo, int tiempo, bool contador)
            {
                new MessageBoxTemporal(texto, titulo, tiempo, contador);
            }
            void EjecutaCada1Segundo(object state)
            {
                TiempoMaximo--;
                if (TiempoMaximo <= 0)
                {
                    IntPtr hndMBox = FindWindow(null, TituloMessageBox);
                    if (hndMBox != IntPtr.Zero)
                    {
                        SendMessage(hndMBox, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                        IntervaloTiempo.Dispose();
                    }
                }
                else if (MostrarContador)
                {
                    // Ha pasado un intervalo de 1 seg:
                    if (hndLabel != IntPtr.Zero)
                    {
                        SetWindowText(hndLabel, TextoMessageBox +
                            "\r\nEste mensaje se cerrará dentro de " +
                            TiempoMaximo.ToString("00") + " segundos");
                    }
                    else
                    {
                        IntPtr hndMBox = FindWindow(null, TituloMessageBox);
                        if (hndMBox != IntPtr.Zero)
                        {
                            // Ha encontrado el MessageBox, busca ahora el texto
                            hndLabel = FindWindowEx(hndMBox, IntPtr.Zero, "Static", null);
                            if (hndLabel != IntPtr.Zero)
                            {
                                // Ha encontrado el texto porque el MessageBox
                                // solo tiene un control "Static".
                                SetWindowText(hndLabel, TextoMessageBox +
                                    "\r\nEste mensaje se cerrará dentro de " +
                                    TiempoMaximo.ToString("00") + " segundos");
                            }
                        }
                    }
                }
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll",
                CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true,
                CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter,
                string lpszClass, string lpszWindow);
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true,
                CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern bool SetWindowText(IntPtr hwnd, string lpString);
        }

        public static bool  buscaSecionesAbiertas()
        {
            try
            {
                List<string> list = new List<string>();
                Process[] procesos;
                procesos = Process.GetProcesses();
                foreach (Process pro in procesos)
                {
                    if (pro.ProcessName == "SIF")
                    {
                        list.Add(pro.ProcessName);
                    }
                }
                DialogResult Dr = new DialogResult();
                if (list.Count > 2)
                {
                    MessageBox.Show("No puede iniciar nuevas sesiones por que ya  tiene sesiones abiertas, Cierre los Sif abiertos","informacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
    }



}