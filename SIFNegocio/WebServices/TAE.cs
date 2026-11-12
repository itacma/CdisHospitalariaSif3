using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace SIFNegocio.WebServices
{
    public class TAE
    {

        //private string Recarga_TelCel(string ProdId, string TelId, decimal Importe, SIFModelo.Configuracion.TAE configuracion)
        //{
        //    string directorioEnsamblado = System.Reflection.Assembly.GetExecutingAssembly().Location;


        //    string ret = string.Empty;
        //    string err = string.Empty;
        //    string resul = string.Empty;
        //    string str = null;
        //    string quote = "\"";
        //    string CIni = "<";
        //    string CFin = ">";
        //    string Sep = " ";
        //    string HostTelCel = configuracion.HostTelcel;
        //    string PuertoTelCel = configuracion.PuertoTelcel;
        //    string Operacion = "Reload";
        //    string sWait = configuracion.TimeOutTelcel;
        //    string[] TAEGpo = configuracion.TAEGrupo.Split('|');
        //    char[] charsToTrim = { '<', '>' };
        //    Random r = new Random();
        //    int iWait = 5000;

        //    if (!string.IsNullOrEmpty(sWait))
        //        iWait = Convert.ToInt32(sWait);

        //    // Nombre Archivo de respuesta
        //    string GpoId = TAEGpo[0];
        //    string CadId = TAEGpo[1];
        //    string TieId = TAEGpo[2];
        //    string CajId = TAEGpo[3];
        //    string Folio = r.Next(1, 1000).ToString();

        //    // Cadena de Envio
        //    string FecEnv = .fecha.ToString("dd/MM/yyyy HH:mm:ss");
        //    string Sku = ProdId;
        //    string NumTel = TelId;

        //    string PathRecarga = configuracion.DirectorioSalida;
        //    string FileTae = GpoId + CadId + TieId + CajId + Folio + ".txt";
        //    string FileRecarga = Path.Combine(PathRecarga, FileTae);
        //    string command = string.Empty;

        //    try
        //    {
        //        command = configuracion.PathJava + "java -jar " + directorioEnsamblado + "conector.jar ";
        //        command += HostTelCel + Sep;
        //        command += PuertoTelCel + Sep;
        //        command += quote + CIni + Operacion + CFin;
        //        command += CIni + GpoId + CFin;
        //        command += CIni + CadId + CFin;
        //        command += CIni + TieId + CFin;
        //        command += CIni + CajId + CFin;
        //        command += CIni + FecEnv + CFin;
        //        command += CIni + Sku + CFin;
        //        command += CIni + NumTel + CFin;
        //        command += CIni + Folio + CFin + quote + Sep;
        //        command += configuracion.Encriptacion + Sep + @PathRecarga + "\\"; //Llave encriptacion

        //        Process javaProcess = new Process();

        //        StreamWriter writer;
        //        StreamReader reader;
        //        StreamReader error;

        //        ProcessStartInfo info = new ProcessStartInfo("cmd");
        //        //info.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

        //        info.CreateNoWindow = true;
        //        info.UseShellExecute = false;
        //        info.RedirectStandardInput = true;
        //        info.RedirectStandardOutput = true;
        //        info.RedirectStandardError = true;

        //        javaProcess.StartInfo = info;
        //        javaProcess.Start();

        //        writer = javaProcess.StandardInput;
        //        reader = javaProcess.StandardOutput;
        //        error = javaProcess.StandardError;

        //        writer.AutoFlush = true;
        //        writer.WriteLine(@command);
        //        writer.Close();

        //        //javaProcess.WaitForExit(iWait);
        //        javaProcess.WaitForExit();

        //        if (javaProcess.HasExited)
        //        {
        //            ret = reader.ReadToEnd();
        //            err = error.ReadToEnd();

        //            int eCode = javaProcess.ExitCode;
        //            javaProcess.Close();

        //            if (string.IsNullOrEmpty(err))
        //            {
        //                // Recupera archivo de respuesta
        //                if (File.Exists(FileRecarga))
        //                {
        //                    // Read File Result
        //                    StreamReader rFile = new StreamReader(FileRecarga, System.Text.Encoding.GetEncoding("iso-8859-1"));
        //                    while ((str = rFile.ReadLine()) != null)
        //                    {
        //                        string[] Tokens = str.Split('<');
        //                        resul = Tokens[Tokens.Length - 2].TrimEnd(charsToTrim) +
        //                                " - " +
        //                                Tokens[Tokens.Length - 1].TrimEnd(charsToTrim) + Environment.NewLine +
        //                                "No. Transacción: " + Tokens[Tokens.Length - 3].TrimEnd(charsToTrim) + Environment.NewLine +
        //                                Tokens[Tokens.Length - 4].TrimEnd(charsToTrim) + Environment.NewLine +
        //                                Tokens[Tokens.Length - 5].TrimEnd(charsToTrim);
        //                        //MessageBoxEx.Show(Tokens[Tokens.Length - 2].TrimEnd(charsToTrim) + " - " +
        //                        //    Tokens[Tokens.Length - 1].TrimEnd(charsToTrim));

        //                        // Guarda la Inf. en la BD
        //                        //SIFDatos.TAE.InsertaTAE(1, Folio, Convert.ToInt64(NumTel), Sku, Importe, Tokens[5].TrimEnd(charsToTrim),
        //                        //    Convert.ToInt16(GpoId), Convert.ToInt16(CadId), 1, Convert.ToInt16(CadId), Convert.ToDecimal(Tokens[Tokens.Length - 3].TrimEnd(charsToTrim)),
        //                        //    Convert.ToInt16(Tokens[Tokens.Length - 2].TrimEnd(charsToTrim)),
        //                        //    Tokens[Tokens.Length - 1].TrimEnd(charsToTrim),
        //                        //    FileRecarga);

        //                    }
        //                    rFile.Close();
        //                    rFile.Dispose();
        //                    return resul;
        //                }
        //                else
        //                    return "El archivo " + FileRecarga + ", NO se genero";
        //            } // Null err
        //            else
        //                return err;
        //        }
        //        else // HasExited
        //        {
        //            javaProcess.Close();
        //            return "El tiempo de espera del Job se agoto";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBoxEx.Show(ex.Message);
        //        return ex.Message;
        //    }
        //}

        public static List<SIFModelo.RemisionDetalle> Productos(SIFModelo.WebServices.Carrier Carrier, SIFModelo.Configuracion.TAE configuracion)
        {
            List<SIFModelo.RemisionDetalle> articulos = new List<SIFModelo.RemisionDetalle>();

            //string tb_HostTelCel = configuracion.HostTelcel;
            //string tb_PuertoTelCel = configuracion.PuertoTelcel;

            //string[] Tokens = configuracion.TAEGrupo.Split('|');

            //string tb_GpoTelCel = Tokens[0];
            //string tb_CadTelCel = Tokens[1];
            //string tb_TieTelCel = Tokens[2];
            //string tb_CajaTelCel = Tokens[3];

            //string CtasMail = "";
            //if (Carrier.Nombre == "TELCEL")
            //    CtasMail = configuracion.ProductosTelcel;
            //if (Carrier.Nombre == "MOVISTAR")
            //    CtasMail = configuracion.ProductosMovistar;
            //if (Carrier.Nombre == "UNEFON")
            //    CtasMail = configuracion.ProductosUnefon;
            //if (Carrier.Nombre == "NEXTEL")
            //    CtasMail = configuracion.ProductosNextel;
            //if (Carrier.Nombre == "IUSACELL")
            //    CtasMail = configuracion.ProductosIusacell;

            //string[] producto = null;

            //if (!string.IsNullOrEmpty(CtasMail))
            //{
            //    foreach (string Cad in CtasMail.Split('|'))
            //    {
            //        if (!string.IsNullOrEmpty(Cad))
            //        {
            //            producto = Cad.Split(',');
            //            SIFModelo.Articulo item = new SIFModelo.Articulo();
            //            item.U_VENTA = producto[0];
            //            item.ARTICULO_ID = producto[1];
            //            item.NOMBRE1 = producto[2];
            //            item.NOMBRE2 = producto[3];

            //            //item.SubItems.AddRange(subItems);
            //            articulos.Add(item);
            //        }
            //    }
            //}

            articulos = SIFDatos.TAE.ProductosTAE(Carrier);

            return articulos;
        }

        public static void Inserta(SIFModelo.WebServices.TAE detalle)
        {
            string FolioOriginal = detalle.Remision;
            string Folio = detalle.Remision.Substring(4);
            detalle.Remision = int.Parse(Folio).ToString();
            SIFDatos.TAE.InsertaTAE(detalle);

            detalle.Remision = FolioOriginal;
        }

        public Boolean Cerrar(SIFModelo.WebServices.TAE control, SIFModelo.Remision remision, SIFModelo.Configuracion.TAE configuracion)
        {
            string directorioEnsamblado = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string ret = string.Empty;
            string err = string.Empty;
            string resul = string.Empty;
            string str = null;
            string quote = "\"";
            string CIni = "<";
            string CFin = ">";
            string Sep = " ";
            string HostTelCel = configuracion.HostTelcel;
            string PuertoTelCel = configuracion.PuertoTelcel;
            string Operacion = "Reload";
            string sWait = configuracion.TimeOutTelcel;
            string[] TAEGpo = configuracion.TAEGrupo.Split('|');
            char[] charsToTrim = { '<', '>' };
            Random r = new Random();
            int iWait = 5000;

            if (!string.IsNullOrEmpty(sWait))
                iWait = Convert.ToInt32(sWait);

            // Nombre Archivo de respuesta
            string GpoId = TAEGpo[0];
            string CadId = TAEGpo[1];
            string TieId = TAEGpo[2];
            string CajId = control.Caja.ToString();
            string Folio = remision.NumeroRemision; //r.Next(1, 1000).ToString();

            // Cadena de Envio
            string FecEnv = control.Fecha.ToString("dd/MM/yyyy HH:mm:ss");
            string Sku = control.Articulo;
            string NumTel = control.Telefono;

            string PathRecarga = configuracion.DirectorioSalida;
            string FileTae = GpoId + CadId + TieId + CajId + Folio + ".txt";
            string FileRecarga = Path.Combine(PathRecarga, FileTae);
            string command = string.Empty;

            try
            {
                if (control.Carrier.ToString().Equals("1")) // TELCEL
                    command = "\"" + configuracion.PathJava + "\\java.exe \" -jar \"" + directorioEnsamblado + "\\conector.jar\" ";
                else // MULTIRECARGAS
                    command = "\"" + configuracion.PathJava + "\\java.exe \" -jar \"" + directorioEnsamblado + "\\ mom.jar ";

                command += HostTelCel + Sep;
                command += PuertoTelCel + Sep;
                command += quote + CIni + Operacion + CFin;
                command += CIni + GpoId + CFin;
                command += CIni + CadId + CFin;
                command += CIni + TieId + CFin;
                command += CIni + CajId + CFin;
                command += CIni + FecEnv + CFin;
                command += CIni + Sku + CFin;
                command += CIni + NumTel + CFin;

                //si es diferente de telcel
                if (control.Carrier != 1)
                {
                    //revisar el parametro que hace falta
                    command += CIni + "1" + CFin;
                }

                command += CIni + Folio + CFin + quote + Sep;
                command += configuracion.Encriptacion + Sep + @PathRecarga + "\\"; //Llave encriptacion

                //command = "\"" + configuracion.PathJava + "\\java.exe \" -jar \"" + directorioEnsamblado + "\\conector.jar\" " +HostTelCel + " " + PuertoTelCel + " " + quote + "<Query><7><1><1><1><09/07/2012 15:32:08><8469760101006><1111111111><170>" + quote + " " + "Pruebas R:\\Recargas\\";

                Process javaProcess = new Process();

                StreamWriter writer;
                StreamReader reader;
                StreamReader error;

                ProcessStartInfo info = new ProcessStartInfo("cmd");
                //info.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

                info.CreateNoWindow = true;
                info.UseShellExecute = false;
                info.RedirectStandardInput = true;
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = true;

                javaProcess.StartInfo = info;
                javaProcess.Start();

                writer = javaProcess.StandardInput;
                reader = javaProcess.StandardOutput;
                error = javaProcess.StandardError;

                writer.AutoFlush = true;
                writer.WriteLine(@command);
                writer.Close();

                //javaProcess.WaitForExit(iWait);
                javaProcess.WaitForExit();

                if (javaProcess.HasExited)
                {
                    ret = reader.ReadToEnd();
                    err = error.ReadToEnd();

                    int eCode = javaProcess.ExitCode;
                    javaProcess.Close();

                    if (string.IsNullOrEmpty(err))
                    {
                        // Recupera archivo de respuesta
                        if (File.Exists(FileRecarga))
                        {
                            // Read File Result
                            using (StreamReader rFile = new StreamReader(FileRecarga, System.Text.Encoding.GetEncoding("iso-8859-1")))
                            {
                                while ((str = rFile.ReadLine()) != null)
                                {
                                    string[] Tokens = str.Split('<');
                                    resul = Tokens[Tokens.Length - 2].TrimEnd(charsToTrim) +
                                            " - " +
                                            Tokens[Tokens.Length - 1].TrimEnd(charsToTrim) + Environment.NewLine +
                                            "No. Transacción: " + Tokens[Tokens.Length - 3].TrimEnd(charsToTrim) + Environment.NewLine +
                                            Tokens[Tokens.Length - 4].TrimEnd(charsToTrim) + Environment.NewLine +
                                            Tokens[Tokens.Length - 5].TrimEnd(charsToTrim);
                                    //MessageBoxEx.Show(Tokens[Tokens.Length - 2].TrimEnd(charsToTrim) + " - " +
                                    //    Tokens[Tokens.Length - 1].TrimEnd(charsToTrim));

                                    control.Archivo = FileTae;
                                    //control.Fecha = Tokens[5].TrimEnd(charsToTrim);
                                    control.Sucursal = Configuracion.Configuraciones.Aplicacion.SucursalID;
                                    control.Grupo = Convert.ToInt16(GpoId);
                                    control.Cadena = Convert.ToInt16(CadId);
                                    control.Caja = Convert.ToInt16(CajId);
                                    control.Referencia = (Tokens[Tokens.Length - 3].TrimEnd(charsToTrim));
                                    control.RespuestaID = Tokens[Tokens.Length - 2].TrimEnd(charsToTrim);
                                    control.Respuesta = Tokens[Tokens.Length - 1].TrimEnd(charsToTrim);
                                    // Guarda la Inf. en la BD
                                    SIFDatos.TAE.UpdTae(control);

                                    if (control.RespuestaID != "0")
                                    {
                                       MessageBox.Show(control.Respuesta + " cod. " + control.RespuestaID);
                                        return false;
                                    }
                                }
                                rFile.Close();
                                rFile.Dispose();
                            }
                            return true;
                        }
                        else
                           MessageBox.Show("El archivo " + FileRecarga + ", NO se genero");
                        return false;
                    } // Null err
                    else
                    {
                       MessageBox.Show(err);
                        return false;
                    }
                }
                else // HasExited
                {
                    javaProcess.Close();
                   MessageBox.Show("El tiempo de espera del Job se agoto");
                    return false;
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
                //return ex.Message;
            }
            return true;
        }

        public string Recarga_TelCel(string carrier, string ProdId, string TelId, decimal Importe, SIFModelo.Configuracion.TAE configuracion, SIFModelo.WebServices.TAE control)
        {

            string directorioEnsamblado = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string ret = string.Empty;
            string err = string.Empty;
            string resul = string.Empty;
            string str = null;
            string quote = "\"";
            string CIni = "<";
            string CFin = ">";
            string Sep = " ";
            string HostTelCel = configuracion.HostTelcel;
            string PuertoTelCel = configuracion.PuertoTelcel;
            //string PATHJAVA = ConfigSettings.ReadSetting("ConfigPortTelCel");
            string Operacion = "Reload";
            string sWait = configuracion.TimeOutTelcel;
            string[] TAEGpo = configuracion.TAEGrupo.Split('|');
            char[] charsToTrim = { '<', '>' };
            Random r = new Random();
            int iWait = 5000;

            if (!string.IsNullOrEmpty(sWait))
                iWait = Convert.ToInt32(sWait);

            // Nombre Archivo de respuesta
            string GpoId = TAEGpo[0];
            string CadId = TAEGpo[1];
            string TieId = TAEGpo[2];
            string CajId = control.Caja.ToString();

            // string remision = control.Remision.Substring(4);
            string Folio = control.Remision; // Int32.Parse(remision).ToString();//r.Next(1, 1000).ToString();

            // Cadena de Envio
            //control.Fecha = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            string FecEnv = control.Fecha.ToString("dd/MM/yyyy HH:mm:ss");
            string Sku = ProdId;
            string NumTel = TelId;

            string PathRecarga = configuracion.DirectorioSalida;
            string FileTae = GpoId + CadId + TieId + CajId + Folio + ".txt";
            string FileRecarga = Path.Combine(PathRecarga, FileTae);
            string command = string.Empty;

            try
            {
                //if (carrier.Equals("1")) // TELCEL
                //    command = "java -jar conector.jar ";
                //else // MULTIRECARGAS
                //    command = "java -jar mom.jar ";

                //if (control.Carrier.ToString().Equals("1")) // TELCEL
                command = "\"" + configuracion.PathJava + "\\java.exe \" -jar " + "\"" + configuracion.JAR + "\" ";
                //else // MULTIRECARGAS
                //    command = "\"" + configuracion.PathJava + "\\java.exe \" -jar \"" + directorioEnsamblado + "\\mom.jar\" ";

                command += HostTelCel + Sep;
                command += PuertoTelCel + Sep;
                command += quote + CIni + Operacion + CFin;
                command += CIni + GpoId + CFin;
                command += CIni + CadId + CFin;
                command += CIni + TieId + CFin;
                command += CIni + CajId + CFin;
                command += CIni + FecEnv + CFin;
                command += CIni + Sku + CFin;
                command += CIni + NumTel + CFin;
                command += CIni + Folio + CFin + quote + Sep;
                command += configuracion.Encriptacion + Sep + @PathRecarga + "\\"; //Llave encriptacion

                Process javaProcess = new Process();

                StreamWriter writer;
                StreamReader reader;
                StreamReader error;

                ProcessStartInfo info = new ProcessStartInfo("cmd");
                //info.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

                info.CreateNoWindow = true;
                info.UseShellExecute = false;
                info.RedirectStandardInput = true;
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = true;

                javaProcess.StartInfo = info;

                //1. Enviamos petición
                javaProcess.Start();

                writer = javaProcess.StandardInput;
                reader = javaProcess.StandardOutput;
                error = javaProcess.StandardError;

                writer.AutoFlush = true;
                writer.WriteLine(@command);
                writer.Close();

                //javaProcess.WaitForExit(iWait);
                javaProcess.WaitForExit();

                if (javaProcess.HasExited)
                {
                    ret = reader.ReadToEnd();
                    err = error.ReadToEnd();

                    int eCode = javaProcess.ExitCode;
                    javaProcess.Close();

                    if (string.IsNullOrEmpty(err))
                    {
                        // Recupera archivo de respuesta
                        if (File.Exists(FileRecarga))
                        {
                            // Read File Result
                            StreamReader rFile = new StreamReader(FileRecarga, System.Text.Encoding.GetEncoding("iso-8859-1"));
                            while ((str = rFile.ReadLine()) != null)
                            {
                                string[] Tokens = str.Split('<');
                                resul = Tokens[Tokens.Length - 2].TrimEnd(charsToTrim) +
                                        " - " +
                                        Tokens[Tokens.Length - 1].TrimEnd(charsToTrim) + Environment.NewLine +
                                        "No. Transacción: " + Tokens[Tokens.Length - 3].TrimEnd(charsToTrim) + Environment.NewLine +
                                        Tokens[Tokens.Length - 4].TrimEnd(charsToTrim) + Environment.NewLine +
                                        Tokens[Tokens.Length - 5].TrimEnd(charsToTrim);

                                string fechaRecepcion = Tokens[5].TrimEnd(charsToTrim);



                                control.Archivo = FileTae;
                                //control.Fecha = Tokens[5].TrimEnd(charsToTrim);
                                control.Sucursal = Configuracion.Configuraciones.Aplicacion.SucursalID;
                                control.Grupo = Convert.ToInt16(GpoId);
                                control.Cadena = Convert.ToInt16(CadId);
                                control.Caja = Convert.ToInt16(CajId);
                                control.Referencia = (Tokens[Tokens.Length - 3].TrimEnd(charsToTrim));

                                control.RespuestaID = Tokens[Tokens.Length - 2].TrimEnd(charsToTrim);
                                control.Respuesta = Tokens[Tokens.Length - 1].TrimEnd(charsToTrim);

                                int d = 0;
                                if (!int.TryParse(control.Referencia, out d))
                                {
                                    control.Referencia = "";
                                }

                                SIFDatos.TAE.UpdTae(control);
                               MessageBox.Show(control.RespuestaID + " " + control.Respuesta);

                                if (control.RespuestaID == "8" || control.RespuestaID == "5" || control.RespuestaID == "6" || control.RespuestaID == "71" || control.RespuestaID == "72") //== 80
                                {
                                    //2. Si error_time_out                                    

                                    //if ((numeroMaximoPeticiones - numeroPeticion) <= 0)
                                    //{
                                    //    return "";
                                    //}

                                    //2.1. Esperar 5 segundos
                                   MessageBox.Show("Ha ocurrido un error: " + control.Respuesta + ", en 5 segundos se intentará nuevamente");
                                    Application.UseWaitCursor = true;
                                    System.Threading.Thread.Sleep(5000);
                                    Application.UseWaitCursor = true;


                                    string consulta = this.QueryTae(control, configuracion);

                                    if (control.RespuestaID == "8" || control.RespuestaID == "5" || control.RespuestaID == "6" || control.RespuestaID == "71" || control.RespuestaID == "72")
                                    {
                                       MessageBox.Show("Ha ocurrido un error: " + control.Respuesta + ", en 5 segundos se intentará nuevamente");
                                        //2.2. Enviar Query
                                        Application.UseWaitCursor = true;
                                        System.Threading.Thread.Sleep(5000);
                                        Application.UseWaitCursor = true;

                                        string consultar = this.QueryTae(control, configuracion);
                                    }
                                    else
                                    {
                                        DateTime fecha;
                                        if (DateTime.TryParse(fechaRecepcion, out fecha))
                                        {
                                            control.Fecha = DateTime.Parse(fechaRecepcion, System.Globalization.CultureInfo.GetCultureInfo("ES-mx"));

                                            SIFDatos.TAE.UpdTae(control);
                                        }
                                    }

                                    //2.2.1

                                    if (!string.IsNullOrEmpty(consulta))
                                    {
                                        return consulta;
                                    }



                                    //numeroPeticion++;
                                    //string resp = this.Recarga_TelCel(carrier, ProdId, TelId, Importe, configuracion, control);

                                    //return err;

                                    //return "";
                                    //control.Referencia = "0";
                                }


                                if (control.RespuestaID == "0") //== 80
                                {
                                    SIFDatos.TAE.UpdTae(control);
                                }
                                //MessageBoxEx.Show(Tokens[Tokens.Length - 2].TrimEnd(charsToTrim) + " - " +
                                //    Tokens[Tokens.Length - 1].TrimEnd(charsToTrim));

                                // Guarda la Inf. en la BD
                                //  InsTAE(Convert.ToInt16(carrier), Folio, Convert.ToInt64(NumTel), Sku, Importe, Tokens[5].TrimEnd(charsToTrim),
                                //Convert.ToInt16(GpoId), Convert.ToInt16(CadId), 1, Convert.ToInt16(CadId), Convert.ToDecimal(Tokens[Tokens.Length - 3].TrimEnd(charsToTrim)),
                                //Convert.ToInt16(Tokens[Tokens.Length - 2].TrimEnd(charsToTrim)),
                                //Tokens[Tokens.Length - 1].TrimEnd(charsToTrim),
                                //FileRecarga);

                            }
                            rFile.Close();
                            rFile.Dispose();
                            return resul;
                        }
                        else
                        {
                           MessageBox.Show("El archivo " + FileRecarga + ", NO se genero, en 5 segundos se intentará nuevamente");
                            Application.UseWaitCursor = true;
                            System.Threading.Thread.Sleep(5000);
                            Application.UseWaitCursor = true;
                            string consulta = this.QueryTae(control, configuracion);
                            return consulta;
                        }
                    } // Null err
                    else
                    {


                        //{
                        //   MessageBox.Show("Ha ocurrido un error: " + err + ", en 5 segundos se intentará una vez mas");

                        //    System.Threading.Thread.Sleep(5000);

                        //    this.Recarga_TelCel(carrier, ProdId, TelId, Importe, configuracion, control);

                        return err;
                        //}
                    }
                }
                else // HasExited
                {
                    javaProcess.Close();
                    return "El tiempo de espera del Job se agoto";
                }
            }
            catch (Exception ex)
            {
                //MessageBoxEx.Show(ex.Message);
                return ex.Message;
            }

            return string.Empty;
        }

        public string QueryTae(SIFModelo.WebServices.TAE control, SIFModelo.Configuracion.TAE configuracion)
        {
            //if (GridConciliaTaeQry.SelectedRows.Count <= 0)
            //{
            //   MessageBox.Show("Debe Seleccionar un registro para consultar TAE...", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            string remision = control.Remision; //.Substring(4);
            string Folio = Int32.Parse(remision).ToString();//r.Next(1, 1000).ToString();

            Cursor.Current = Cursors.WaitCursor;
            //string[] aCadena;
            string CarrierId = control.Carrier.ToString(); //cmb_CarriersTaeQry.Text.Split('-')[0].Trim();
            string ret = string.Empty;
            string err = string.Empty;
            string str = null;
            string quote = "\"";
            string CIni = "<";
            string CFin = ">";
            string Sep = " ";
            string Operacion = "Query";
            string sWait = configuracion.Timeout; //ConfigSettings.ReadSetting("ConfigTimeTelCel");
            char[] charsToTrim = { '<', '>' };
            Random r = new Random();
            int iWait = 50000;

            if (!string.IsNullOrEmpty(sWait))
                iWait = Convert.ToInt32(sWait);

            // Get Cadena Servicio TAE
            string Cad = control.Cadena.ToString(); //. , row.Cells[0].Value.ToString());

            //aCadena = Cad.Split('|');

            //if (aCadena.Length != 5)
            //    return;

            // Nombre Archivo de respuesta



            string[] TAEGpo = SIFNegocio.Configuracion.Configuraciones.TAE.TAEGrupo.Split('|');
            control.Grupo = int.Parse(TAEGpo[0]);
            control.Cadena = int.Parse(TAEGpo[1]);
            control.Sucursal = int.Parse(TAEGpo[2]);

            string GpoId = control.Grupo.ToString();
            string CadId = control.Cadena.ToString();
            string TieId = control.Sucursal.ToString();
            string CajId = control.Caja.ToString();


            //string Folio = Folio; // row.Cells[0].Value.ToString(); 

            // Cadena de Envio
            string FecEnv = control.Fecha.ToString("dd/MM/yyyy HH:mm:ss"); //  "29/11/2012 15:54:23";
            string Sku = control.Articulo;
            string NumTel = control.Telefono;

            string PathRecarga = configuracion.DirectorioQuerySalida;
            string FileTae = GpoId + CadId + TieId + CajId + Folio + ".txt";
            string FileRecarga = Path.Combine(PathRecarga, FileTae);
            string command = string.Empty;

            try
            {
                command = "\"" + configuracion.PathJava + "\\java.exe \" -jar " + "\"" + configuracion.JAR + "\" ";
                command += configuracion.HostTelcel + Sep;
                command += configuracion.PuertoTelcel + Sep;
                command += quote + CIni + Operacion + CFin;
                command += CIni + GpoId + CFin;
                command += CIni + CadId + CFin;
                command += CIni + TieId + CFin;
                command += CIni + CajId + CFin;
                command += CIni + FecEnv + CFin;
                command += CIni + Sku + CFin;
                command += CIni + NumTel + CFin;
                command += CIni + Folio + CFin + quote + Sep; // "114"
                command += configuracion.Encriptacion + Sep + @PathRecarga + "\\"; // "c:\\desarrollo\\recargas\\"; 

                Process javaProcess = new Process();

                StreamWriter writer;
                StreamReader reader;
                StreamReader error;

                ProcessStartInfo info = new ProcessStartInfo("cmd");
                //info.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

                info.CreateNoWindow = true;
                info.UseShellExecute = false;
                info.RedirectStandardInput = true;
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = true;

                javaProcess.StartInfo = info;
                javaProcess.Start();

                writer = javaProcess.StandardInput;
                reader = javaProcess.StandardOutput;
                error = javaProcess.StandardError;

                writer.AutoFlush = true;

                writer.WriteLine(@command);
                writer.Close();
                Application.UseWaitCursor = true;
                javaProcess.WaitForExit(iWait); // 5000
                Application.UseWaitCursor = false;
                if (javaProcess.HasExited)
                {
                    ret = reader.ReadToEnd();
                    err = error.ReadToEnd();

                    int eCode = javaProcess.ExitCode;
                    javaProcess.Close();

                    if (string.IsNullOrEmpty(err))
                    {  // Recupera archivo de respuesta
                        if (File.Exists(FileRecarga))
                        {
                            // Read File Result
                            StreamReader rFile = new StreamReader(FileRecarga, System.Text.Encoding.GetEncoding("iso-8859-1"));
                            while ((str = rFile.ReadLine()) != null)
                            {
                                string[] Tokens = str.Split('<');
                                string resultado = Tokens[Tokens.Length - 2].TrimEnd(charsToTrim) + " - " +
                                    Tokens[Tokens.Length - 1].TrimEnd(charsToTrim);

                                control.Referencia = (Tokens[Tokens.Length - 3].TrimEnd(charsToTrim));
                                control.RespuestaID = Tokens[Tokens.Length - 2].TrimEnd(charsToTrim);
                                control.Respuesta = Tokens[Tokens.Length - 1].TrimEnd(charsToTrim);

                                if (control.RespuestaID == "8" || control.RespuestaID == "5" || control.RespuestaID == "6" || control.RespuestaID == "71" || control.RespuestaID == "72")
                                {  //2.2.1. Si error_time_out

                                    resultado = control.RespuestaID.ToString() + " " + control.Respuesta;
                                    // return false;
                                }
                               MessageBox.Show(resultado);
                                return resultado;
                            }

                            rFile.Close();
                            rFile.Dispose();
                        }
                    }
                    else
                       MessageBox.Show("El archivo " + FileRecarga + ", NO existe" + err, "Consulta TAE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else // Cancelar Job
                    javaProcess.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            return "";
        }

        public string QueryTae(SIFModelo.WebServices.TAE control, SIFModelo.Configuracion.MultiRecargas configuracion)
        {
            //if (GridConciliaTaeQry.SelectedRows.Count <= 0)
            //{
            //   MessageBox.Show("Debe Seleccionar un registro para consultar TAE...", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            string remision = control.Remision; //.Substring(4);
            string Folio = Int32.Parse(remision).ToString();//r.Next(1, 1000).ToString();

            Cursor.Current = Cursors.WaitCursor;
            //string[] aCadena;
            string CarrierId = control.Carrier.ToString(); //cmb_CarriersTaeQry.Text.Split('-')[0].Trim();
            string ret = string.Empty;
            string err = string.Empty;
            string str = null;
            string quote = "\"";
            string CIni = "<";
            string CFin = ">";
            string Sep = " ";
            string Operacion = "Query";
            string sWait = configuracion.Timeout; //ConfigSettings.ReadSetting("ConfigTimeTelCel");
            char[] charsToTrim = { '<', '>' };
            Random r = new Random();
            int iWait = 5000;

            if (!string.IsNullOrEmpty(sWait))
                iWait = Convert.ToInt32(sWait);

            // Get Cadena Servicio TAE
            string Cad = control.Cadena.ToString(); //. , row.Cells[0].Value.ToString());

            //aCadena = Cad.Split('|');

            //if (aCadena.Length != 5)
            //    return;

            // Nombre Archivo de respuesta
            string GpoId = control.Grupo.ToString();
            string CadId = control.Cadena.ToString();
            string TieId = control.Sucursal.ToString();
            string CajId = control.Caja.ToString();
            //string Folio = Folio; // row.Cells[0].Value.ToString(); 

            // Cadena de Envio
            string FecEnv = control.Fecha.ToString("dd/MM/yyyy HH:mm:ss"); //  "29/11/2012 15:54:23";
            string Sku = control.Articulo;
            string NumTel = control.Telefono;

            string PathRecarga = configuracion.DirectorioQuerySalida;
            string FileTae = GpoId + CadId + TieId + CajId + Folio + ".txt";
            string FileRecarga = Path.Combine(PathRecarga, FileTae);
            string command = string.Empty;

            try
            {
                command = "\"" + configuracion.PathJava + "\\java.exe \" -jar " + "\"" + configuracion.JAR + "\" ";
                command += configuracion.HostTelcel + Sep;
                command += configuracion.PuertoTelcel + Sep;
                command += quote + CIni + Operacion + CFin;
                command += CIni + GpoId + CFin;
                command += CIni + CadId + CFin;
                command += CIni + TieId + CFin;
                command += CIni + CajId + CFin;
                command += CIni + FecEnv + CFin;
                command += CIni + Sku + CFin;
                command += CIni + NumTel + CFin;
                command += CIni + Folio + CFin + quote + Sep; // "114"
                command += configuracion.Encriptacion + Sep + @PathRecarga + "\\"; // "c:\\desarrollo\\recargas\\"; 

                Process javaProcess = new Process();

                StreamWriter writer;
                StreamReader reader;
                StreamReader error;

                ProcessStartInfo info = new ProcessStartInfo("cmd");
                //info.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

                info.CreateNoWindow = true;
                info.UseShellExecute = false;
                info.RedirectStandardInput = true;
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = true;

                javaProcess.StartInfo = info;
                javaProcess.Start();

                writer = javaProcess.StandardInput;
                reader = javaProcess.StandardOutput;
                error = javaProcess.StandardError;

                writer.AutoFlush = true;

                writer.WriteLine(@command);
                writer.Close();

                javaProcess.WaitForExit(iWait); // 5000

                if (javaProcess.HasExited)
                {
                    ret = reader.ReadToEnd();
                    err = error.ReadToEnd();

                    int eCode = javaProcess.ExitCode;
                    javaProcess.Close();

                    if (string.IsNullOrEmpty(err))
                    {  // Recupera archivo de respuesta
                        if (File.Exists(FileRecarga))
                        {
                            // Read File Result
                            StreamReader rFile = new StreamReader(FileRecarga, System.Text.Encoding.GetEncoding("iso-8859-1"));
                            while ((str = rFile.ReadLine()) != null)
                            {
                                string[] Tokens = str.Split('<');
                                string resultado = Tokens[Tokens.Length - 2].TrimEnd(charsToTrim) + " - " +
                                    Tokens[Tokens.Length - 1].TrimEnd(charsToTrim);

                                control.Referencia = (Tokens[Tokens.Length - 3].TrimEnd(charsToTrim));
                                control.RespuestaID = Tokens[Tokens.Length - 2].TrimEnd(charsToTrim);
                                control.Respuesta = Tokens[Tokens.Length - 1].TrimEnd(charsToTrim);

                                if (control.RespuestaID == "8" || control.RespuestaID == "5" || control.RespuestaID == "6" || control.RespuestaID == "71" || control.RespuestaID == "72")
                                {  //2.2.1. Si error_time_out

                                    resultado = control.RespuestaID.ToString() + " " + control.Respuesta;
                                    // return false;
                                }
                               MessageBox.Show(resultado);
                                return resultado;
                            }

                            rFile.Close();
                            rFile.Dispose();
                        }
                    }
                    else
                       MessageBox.Show("El archivo " + FileRecarga + ", NO existe" + err, "Consulta TAE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else // Cancelar Job
                    javaProcess.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            return "";
        }


        public string Recarga_MultiRecargas(string carrier, string ProdId, string TelId, decimal Importe, SIFModelo.Configuracion.MultiRecargas configuracion, SIFModelo.WebServices.TAE control)
        {
            string directorioEnsamblado = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string ret = string.Empty;
            string err = string.Empty;
            string resul = string.Empty;
            string str = null;
            string quote = "\"";
            string CIni = "<";
            string CFin = ">";
            string Sep = " ";
            string HostTelCel = configuracion.HostTelcel;
            string PuertoTelCel = configuracion.PuertoTelcel;
            //string PATHJAVA = ConfigSettings.ReadSetting("ConfigPortTelCel");
            string Operacion = "Reload";
            string sWait = configuracion.TimeOutTelcel;
            string[] TAEGpo = configuracion.TAEGrupo.Split('|');
            char[] charsToTrim = { '<', '>' };
            Random r = new Random();


            int iWait = 5000;
            if (!string.IsNullOrEmpty(configuracion.Timeout))
                iWait = Convert.ToInt32(configuracion.Timeout);

            // Nombre Archivo de respuesta
            string GpoId = TAEGpo[0];
            string CadId = TAEGpo[1];
            string TieId = TAEGpo[2];
            string CajId = control.Caja.ToString();

            string remision = control.Remision; //.Substring(4);
            string Folio = Int32.Parse(remision).ToString();//r.Next(1, 1000).ToString();

            // Cadena de Envio
            //control.Fecha = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            string FecEnv = control.Fecha.ToString("dd/MM/yyyy HH:mm:ss");
            string Sku = ProdId;
            string NumTel = TelId;

            string PathRecarga = configuracion.DirectorioSalida;
            string FileTae = GpoId + CadId + TieId + CajId + Folio + ".txt";
            string FileRecarga = Path.Combine(PathRecarga, FileTae);
            string command = string.Empty;

            try
            {
                //if (carrier.Equals("1")) // TELCEL
                //    command = "java -jar conector.jar ";
                //else // MULTIRECARGAS
                //    command = "java -jar mom.jar ";

                //if (control.Carrier.ToString().Equals("1")) // TELCEL
                command = "\"" + configuracion.PathJava + "\\java.exe \" -jar " + "\"" + configuracion.JAR + "\" ";
                //else // MULTIRECARGAS
                //    command = "\"" + configuracion.PathJava + "\\java.exe \" -jar \"" + directorioEnsamblado + "\\mom.jar\" ";

                command += HostTelCel + Sep;
                command += PuertoTelCel + Sep;
                command += quote + CIni + Operacion + CFin;
                command += CIni + GpoId + CFin;
                command += CIni + CadId + CFin;
                command += CIni + TieId + CFin;
                command += CIni + CajId + CFin;
                command += CIni + FecEnv + CFin;
                command += CIni + Sku + CFin;
                command += CIni + NumTel + CFin;
                command += CIni + Folio + CFin + quote + Sep;
                command += configuracion.Encriptacion + Sep + @PathRecarga + "\\"; //Llave encriptacion

                Process javaProcess = new Process();

                StreamWriter writer;
                StreamReader reader;
                StreamReader error;

                ProcessStartInfo info = new ProcessStartInfo("cmd");
                //info.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

                info.CreateNoWindow = true;
                info.UseShellExecute = false;
                info.RedirectStandardInput = true;
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = true;

                javaProcess.StartInfo = info;
                javaProcess.Start();

                writer = javaProcess.StandardInput;
                reader = javaProcess.StandardOutput;
                error = javaProcess.StandardError;

                writer.AutoFlush = true;
                writer.WriteLine(@command);
                writer.Close();

                //javaProcess.WaitForExit(iWait);
                javaProcess.WaitForExit();

                if (javaProcess.HasExited)
                {
                    ret = reader.ReadToEnd();
                    err = error.ReadToEnd();

                    int eCode = javaProcess.ExitCode;
                    javaProcess.Close();

                    if (string.IsNullOrEmpty(err))
                    {
                        // Recupera archivo de respuesta
                        if (File.Exists(FileRecarga))
                        {
                            // Read File Result
                            StreamReader rFile = new StreamReader(FileRecarga, System.Text.Encoding.GetEncoding("iso-8859-1"));
                            while ((str = rFile.ReadLine()) != null)
                            {
                                string[] Tokens = str.Split('<');
                                resul = Tokens[Tokens.Length - 2].TrimEnd(charsToTrim) +
                                        " - " +
                                        Tokens[Tokens.Length - 1].TrimEnd(charsToTrim) + Environment.NewLine +
                                        "No. Transacción: " + Tokens[Tokens.Length - 3].TrimEnd(charsToTrim) + Environment.NewLine +
                                        Tokens[Tokens.Length - 4].TrimEnd(charsToTrim) + Environment.NewLine +
                                        Tokens[Tokens.Length - 5].TrimEnd(charsToTrim);

                                control.Archivo = FileTae;

                                string fechaRecepcion = Tokens[5].TrimEnd(charsToTrim);

                                DateTime fechaSalida;
                                if (DateTime.TryParse(fechaRecepcion, out fechaSalida))
                                {
                                    control.Fecha = DateTime.Parse(fechaRecepcion);
                                }
                                control.Sucursal = Configuracion.Configuraciones.Aplicacion.SucursalID;
                                control.Grupo = Convert.ToInt16(GpoId);
                                control.Cadena = Convert.ToInt16(CadId);
                                control.Caja = Convert.ToInt16(CajId);
                                control.Referencia = (Tokens[Tokens.Length - 3].TrimEnd(charsToTrim));
                                control.RespuestaID = Tokens[Tokens.Length - 2].TrimEnd(charsToTrim);
                                control.Respuesta = Tokens[Tokens.Length - 1].TrimEnd(charsToTrim);

                                int d = 0;
                                if (!int.TryParse(control.Referencia, out d))
                                {
                                    control.Referencia = "";
                                }

                                SIFDatos.TAE.UpdTae(control);

                                if (control.RespuestaID == "8" || control.RespuestaID == "5" || control.RespuestaID == "6" || control.RespuestaID == "71" || control.RespuestaID == "72")
                                {
                                   MessageBox.Show("Ha ocurrido un error: " + control.Respuesta + ", en 5 segundos se intentará nuevamente");
                                    Application.UseWaitCursor = true;
                                    System.Threading.Thread.Sleep(5000);
                                    Application.UseWaitCursor = true;
                                    string consulta = this.QueryTae(control, configuracion);

                                    if (control.RespuestaID == "8" || control.RespuestaID == "5" || control.RespuestaID == "6" || control.RespuestaID == "71" || control.RespuestaID == "72")
                                    {
                                       MessageBox.Show("Ha ocurrido un error: " + control.Respuesta + ", en 5 segundos se intentará nuevamente");
                                        //2.2. Enviar Query
                                        Application.UseWaitCursor = true;
                                        System.Threading.Thread.Sleep(5000);
                                        Application.UseWaitCursor = true;

                                        string consultar = this.QueryTae(control, configuracion);
                                    }

                                    return err;
                                }




                                //MessageBoxEx.Show(Tokens[Tokens.Length - 2].TrimEnd(charsToTrim) + " - " +
                                //    Tokens[Tokens.Length - 1].TrimEnd(charsToTrim));

                                // Guarda la Inf. en la BD
                                //  InsTAE(Convert.ToInt16(carrier), Folio, Convert.ToInt64(NumTel), Sku, Importe, Tokens[5].TrimEnd(charsToTrim),
                                //Convert.ToInt16(GpoId), Convert.ToInt16(CadId), 1, Convert.ToInt16(CadId), Convert.ToDecimal(Tokens[Tokens.Length - 3].TrimEnd(charsToTrim)),
                                //Convert.ToInt16(Tokens[Tokens.Length - 2].TrimEnd(charsToTrim)),
                                //Tokens[Tokens.Length - 1].TrimEnd(charsToTrim),
                                //FileRecarga);

                            }
                            rFile.Close();
                            rFile.Dispose();
                            return resul;
                        }
                        else
                        {
                           MessageBox.Show("El archivo " + FileRecarga + ", NO se genero, en 5 segundos se intentará nuevamente");
                            Application.UseWaitCursor = true;
                            System.Threading.Thread.Sleep(5000);
                            Application.UseWaitCursor = true;
                            string consulta = this.QueryTae(control, configuracion);
                            return consulta;
                        }
                    } // Null err
                    else
                        return err;
                }
                else // HasExited
                {
                    javaProcess.Close();
                    return "El tiempo de espera del Job se agoto";
                }
            }
            catch (Exception ex)
            {
                //MessageBoxEx.Show(ex.Message);
                return ex.Message;
            }
        }

        public SIFModelo.WebServices.TAE Control(SIFModelo.Remision remision, bool formatear = true)
        {
            string folioOriginal = "";
            if (formatear)
            {
                folioOriginal = remision.NumeroRemision;
                string Folio = remision.NumeroRemision.Substring(4);

                remision.NumeroRemision = int.Parse(Folio).ToString();
            }

            SIFModelo.WebServices.TAE resultado = SIFDatos.TAE.Control(remision);

            if (formatear)
            {
                remision.NumeroRemision = folioOriginal;
            }
            return resultado;
        }

        public SIFModelo.Catalogo.CatalogoDataSet.CTL_TAEDataTable ConsultaVentas(string carrier, DateTime dateTimeInicio, DateTime dateTimeFin)
        {
            return SIFDatos.WebServices.TAE.GetVentasTAE(carrier, dateTimeInicio, dateTimeFin);
        }

        public SIFModelo.Catalogo.CatalogoDataSet.CTL_TAEDataTable ConsultaRecargaNoExitosa(string carrier, DateTime dateTimeInicio, DateTime dateTimeFin)
        {
            SIFModelo.Catalogo.CatalogoDataSet.CTL_TAEDataTable controles = SIFDatos.WebServices.TAE.RecargaNoExitosa();

            //if (controles.Count > 0)
            //{
            //    return controles.Last();
            //}

            return controles;
        }

        public List<string> Carriers()
        {
            return SIFDatos.WebServices.TAE.Carriers();
        }

        public bool ActualizaTAE(SIFModelo.WebServices.TAE control)
        {
            return SIFDatos.TAE.UpdTae(control);
        }
    }
}
