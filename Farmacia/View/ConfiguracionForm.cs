using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Oracle.DataAccess.Client;
using System.Configuration;
using System.Reflection;
using SIF.Helpers;
using System.IO;
using System.Diagnostics;
using DevComponents.DotNetBar.Controls;
using Equin.ApplicationFramework;
namespace SIF.View
{
    public partial class ConfiguracionForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ConfiguracionForm()
        {
            InitializeComponent();
        }

        string OraConndb = "Data Source ="
                    + "(DESCRIPTION ="
                    + "  (ADDRESS_LIST ="
                    + "    (ADDRESS = (PROTOCOL = #1) (#6 = #2) (#7 = #3))"
                    + "   )"
                    + "    (CONNECT_DATA ="
                    + "      (#4 = #5)"
                    + "    )"
                    + "  );"
                    + "User Id=user;Password=pwd;";
        string Oradb;

        #region Funciones y Metodos

        private void probarConexion()
        {
            Cursor.Current = Cursors.WaitCursor;
            cProgress.Visible = true;
            cProgress.IsRunning = true;
            System.Windows.Forms.Application.DoEvents();

            Oradb = OraConndb;
            Oradb = Oradb.Replace("#5", TB_NServicio.Text);
            if (chkBox_SID.Checked == true)
                Oradb = Oradb.Replace("#4", "SID");
            else
                Oradb = Oradb.Replace("#4", "SERVICE_NAME");
            switch (CBox_Protocolo.Text)
            {
                case "TCP/IP":
                    Oradb = Oradb.Replace("#1", "TCP");
                    Oradb = Oradb.Replace("#6", "HOST");
                    Oradb = Oradb.Replace("#7", "PORT");
                    break;
                case "Names Pipes":
                    Oradb = Oradb.Replace("#1", "NMP");
                    Oradb = Oradb.Replace("#6", "SERVER");
                    Oradb = Oradb.Replace("#7", "PIPE");
                    break;
                case "IPC":
                    Oradb = Oradb.Replace("#1", "IPC");
                    Oradb = Oradb.Replace("#6", "KEY");
                    Oradb = Oradb.Replace("(#7 = #3)", "");
                    break;
                default:
                    Oradb = Oradb.Replace("#1", "TCP");
                    break;
            }

            Oradb = Oradb.Replace("#2", TB_Host.Text);
            Oradb = Oradb.Replace("#3", TB_NoPuerto.Text);
            Oradb = Oradb.Replace("user", TB_Usuario.Text);

            RTB_Result.Clear();
            RTB_Result.AppendText("Cadena: " + System.Environment.NewLine);
            RTB_Result.AppendText(Oradb + System.Environment.NewLine);
            Oradb = Oradb.Replace("pwd", TB_pwd.Text);

            OracleConnection conn = new OracleConnection(Oradb);
            try
            {
                //using connection string attributes to connect to Oracle Database
                //conn.ConnectionString = "User Id=datastage;Password=scldwh12;Data Source=REPOSCEL";
                conn.Open();
             


                RTB_Result.AppendText("Connected to Oracle " + conn.ServerVersion + System.Environment.NewLine);
            }
            catch (OracleException Oex)
            {
                switch (Oex.Number)
                {
                    case 1:
                        RTB_Result.AppendText("Error intentando insertar datos duplicados" + System.Environment.NewLine);
                        break;
                    case 12545:
                        RTB_Result.AppendText("La base de datos NO esta disponible" + System.Environment.NewLine);
                        break;
                    default:
                        RTB_Result.AppendText("Database error:" + System.Environment.NewLine + Oex.ToString() + System.Environment.NewLine);
                        break;
                }
            }
            catch (Exception ex)
            {
                RTB_Result.AppendText(ex.ToString() + System.Environment.NewLine);
            }

            finally
            {
                conn.Close();
                conn.Dispose();
              
               //OracleConnection.ClearPool(conn);

                cProgress.Visible = false;
                cProgress.IsRunning = false;
                Cursor.Current = Cursors.Default;
            }
        }

        private void guardarConexion()
        {
            if (MessageBoxEx.Show("¿Salvar Cambios?", "SIF v3.0", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Oradb = OraConndb;
                Oradb = Oradb.Replace("#5", TB_NServicio.Text);
                if (chkBox_SID.Checked == true)
                    Oradb = Oradb.Replace("#4", "SID");
                else
                    Oradb = Oradb.Replace("#4", "SERVICE_NAME");
                switch (CBox_Protocolo.Text)
                {
                    case "TCP/IP":
                        Oradb = Oradb.Replace("#1", "TCP");
                        Oradb = Oradb.Replace("#6", "HOST");
                        Oradb = Oradb.Replace("#7", "PORT");
                        break;
                    case "Names Pipes":
                        Oradb = Oradb.Replace("#1", "NMP");
                        Oradb = Oradb.Replace("#6", "SERVER");
                        Oradb = Oradb.Replace("#7", "PIPE");
                        break;
                    case "IPC":
                        Oradb = Oradb.Replace("#1", "IPC");
                        Oradb = Oradb.Replace("#6", "KEY");
                        Oradb = Oradb.Replace("(#7 = #3)", "");
                        break;
                    default:
                        Oradb = Oradb.Replace("#1", "TCP");
                        break;
                }

                Oradb = Oradb.Replace("#2", TB_Host.Text);
                Oradb = Oradb.Replace("#3", TB_NoPuerto.Text);
                Oradb = Oradb.Replace("user", TB_Usuario.Text);

                /// string CadOracle = string.Format(CadConBD, CBox_Protocolo.Text, TB_Host.Text, TB_NoPuerto.Text, CBox_TipoConexion.Text, TB_NServicio.Text, TB_Usuario.Text, TB_pwd.Text);
                RTB_Result.Clear();
                // RTB_Result.AppendText(CadOracle + Environment.NewLine);

                Oradb = Oradb.Replace("pwd", SIFNegocio.Helpers.CryptorEngine.Encrypt(TB_pwd.Text, true));
                Helpers.ConfigDBSettings.WriteSetting(TB_NServicio.Text, Oradb);
                //CB_NombreServicio.Items.Clear();
                //// ConfigurationManager.RefreshSection("connectionStrings");
                //ConnectionStringSettingsCollection ConnStrings = ConfigurationManager.ConnectionStrings;
                //foreach (ConnectionStringSettings conn in ConnStrings)
                //{
                //    if (conn.ProviderName.EndsWith("OracleClient"))
                //        CB_NombreServicio.Items.Add(conn.Name + " - " + conn.ProviderName);
                //}
                //CB_NombreServicio.Items.Add("Nuevo");
                //// Force a reload of a changed section.
                SIFModelo.Configuracion.ServidorOracle servidorOracle = new SIFModelo.Configuracion.ServidorOracle();

                servidorOracle.Host = TB_Host.Text;
                servidorOracle.NombreServicio = TB_NServicio.Text;
                servidorOracle.Password = SIFNegocio.Helpers.CryptorEngine.Encrypt(TB_pwd.Text, true);
                servidorOracle.Protocolo = CBox_Protocolo.Text;
                servidorOracle.Puerto = (int)TB_NoPuerto.Value;
                servidorOracle.TipoConexion = CBox_TipoConexion.Text;
                servidorOracle.Usuario = TB_Usuario.Text;

                servidorOracle.CadenaConexion = Oradb.Replace(servidorOracle.Password, TB_pwd.Text);
                SIFNegocio.Configuracion.Configuraciones.ServidorOracle = servidorOracle;
                ConfigurationManager.RefreshSection("connectionStrings");
            }
        }

        private void cargaConexion()
        {
            Assembly xAssembly = this.GetType().Assembly;
            string ConfigFile = xAssembly.ManifestModule.Name + ".config";

            if (File.Exists(ConfigFile) == false)
            {
               MessageBox.Show(this, "El archivo de Configuración " + ConfigFile + ", NO existe", "SIF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //System.Windows.Forms.MessageBox.Show("El archivo de Configuración " + ConfigFile + ", NO existe");
            }
            else
            {
                // Base de Datos
                //CB_NombreServicio.Items.Clear
                string servicio = "";
                string connectionName = "";
                ConnectionStringSettingsCollection ConnStrings = ConfigurationManager.ConnectionStrings;
                foreach (ConnectionStringSettings conn in ConnStrings)
                {
                    if (conn.ProviderName.EndsWith("OracleClient"))
                    {
                        connectionName = conn.Name;
                        servicio = conn.Name;
                    }
                    //  CB_NombreServicio.Items.Add(conn.Name + " - " + conn.ProviderName);
                }

                string[] Cad = servicio.Split('-');
                if (Cad.Length != 0)
                {
                    servicio = Cad[0].TrimEnd();
                    Oradb = ConfigurationManager.ConnectionStrings[servicio].ConnectionString;
                    Oradb = Oradb.Replace(")", "");
                    Oradb = Oradb.Replace("(", "");
                    // Parsea Cadena Conexión
                    string[] CadCon = Oradb.Split(';');
                    string[] CadOra = CadCon[0].Split(' ');
                    string[] CadUsr = CadCon[1].Split('=');

                    string passwordEncriptado = CadCon[2];
                    string passowrd = passwordEncriptado.Substring(0, passwordEncriptado.IndexOf("="));
                    passwordEncriptado = passwordEncriptado.Substring(passwordEncriptado.IndexOf("=") + 1);
                    string[] CadPwd = new string[] { passowrd, passwordEncriptado };
                    CBox_TipoConexion.SelectedIndex = 0;
                    for (int i = 0; i < CadOra.Length; i++)
                    {
                        switch (CadOra[i])
                        {
                            case "PROTOCOL":
                                CBox_Protocolo.SelectedIndex = CBox_Protocolo.FindString(CadOra[i + 2]);
                                break;
                            case "HOST":
                                TB_Host.Text = CadOra[i + 2];
                                break;
                            case "PORT":
                                TB_NoPuerto.Text = CadOra[i + 2];
                                break;
                            case "SID":
                                TB_NServicio.Text = CadOra[i + 2];
                                chkBox_SID.Checked = true;
                                break;
                            case "SERVICE_NAME":
                                TB_NServicio.Text = CadOra[i + 2];
                                chkBox_SID.Checked = false;
                                break;
                            default:
                                break;
                        }

                    }

                    TB_Usuario.Text = CadUsr[1];
                    TB_pwd.Text = SIFNegocio.Helpers.CryptorEngine.Decrypt(CadPwd[1], true);

                    //CB_NombreServicio.Items.Add("Nuevo");

                }
            }
        }

        private void cargaEmail()
        {
            txtServer.Text = ConfigSettings.ReadDBSetting("MailServer");
            txtPort.Text = ConfigSettings.ReadDBSetting("MailPort");
            if (txtPort.Text.Length == 0)
                txtPort.Text = "587";
            if (ConfigSettings.ReadDBSetting("MailSSL") == "1")
                chkBox_SSL.Checked = true;
            else
                chkBox_SSL.Checked = false;
            txtUsername.Text = ConfigSettings.ReadDBSetting("MailUser");
            txtPassword.Text = SIFNegocio.Helpers.CryptorEngine.Decrypt(ConfigSettings.ReadDBSetting("MailPWD"), true);
        }

        private void cargaPfizer()
        {
            string programa = ConfigSettings.ReadDBSetting("ConfigpFizerPrograma");
            string cadena = ConfigSettings.ReadDBSetting("ConfigpFizerCadena");
            string sucursal = ConfigSettings.ReadDBSetting("ConfigpFizerSucursal");
            string PathSalidaPfizer = ConfigSettings.ReadSetting("PathpFizerSalida");

            urlWSPfizerTextBoxX.Text = ConfigSettings.ReadEndPoint("WSPrepagoSoap");
            usuarioPfizerTextBoxX.Text = ConfigSettings.ReadDBSetting("ConfigpFizerUsuario");

            //this.tb_ProgId.Value = int.Parse(programa);
            this.tb_ProgId.Text = programa;
            //this.tb_CadenaId.Value = int.Parse(cadena);
            this.tb_CadenaId.Text = cadena;
            //this.tb_SucursalId.Value = int.Parse(sucursal);
            this.tb_SucursalId.Text = sucursal;

            this.directorioPfizerTextBoxX.Text = PathSalidaPfizer;
        }

        private void cargaNadro()
        {
            tb_NadroCad.Text = ConfigSettings.ReadDBSetting("ConfigNadroCadena");
            tb_NadroUsr.Text = ConfigSettings.ReadDBSetting("ConfigNadroUsr");
            tb_NadroPwd.Text = ConfigSettings.ReadDBSetting("ConfigNadroPwd");
            tb_NadroSuc.Text = ConfigSettings.ReadDBSetting("ConfigNadroSucursal");
            urlWSNADROtextBoxX.Text = ConfigSettings.ReadEndPoint("WSCirculodelaSaludSoap");
        }

        private void cargaTAE()
        {
            tb_HostTelCel.Text = ConfigSettings.ReadDBSetting("ConfigHostTelCel");
            tb_PuertoTelCel.Text = ConfigSettings.ReadDBSetting("ConfigPortTelCel");
            tb_TimeMaxTelCel.Text = ConfigSettings.ReadDBSetting("ConfigTimeTelCel");
            //tb_JavaHome.Text = ConfigSettings.ReadSetting("ConfigTimeTelCel");

            tb_JavaHome.Text = ConfigSettings.ReadSetting("PathJavaHome");
            tb_taesalida.Text = ConfigSettings.ReadSetting("PathTAESalida");
            jarTaeURLTextBoxX.Text = ConfigSettings.ReadSetting("JarTelCel");
            consultaTAETextBoxX.Text = ConfigSettings.ReadSetting("PathTAEQuerySalida");

            prefijoMultiTextBoxX.Text = ConfigSettings.ReadDBSetting("ConfigPrefijoMultir");

            fraseEncriptacionTextBoxX.Text = ConfigSettings.ReadDBSetting("FraseEncriptacionTelCel");

            prefijoTelcelTextBoxX.Text = ConfigSettings.ReadDBSetting("ConfigPrefijoTelCel");

            string CadTelCel = ConfigSettings.ReadDBSetting("ConfigGrupoTelCel");

            string[] valoresTAE = CadTelCel.Split(new char[] { '|' });
            if (valoresTAE.Length == 4)
            {
                tb_GpoTelCel.Text = valoresTAE[0];
                tb_CadTelCel.Text = valoresTAE[1];
                tb_TieTelCel.Text = valoresTAE[2];
                tb_CajaTelCel.Text = valoresTAE[3];
            }
        }

        private void CargaMultiRecargas()
        {
            ConfigHostMultiRecargasTextBox.Text = ConfigSettings.ReadDBSetting("ConfigHostMultiRecargas");
            ConfigPortMultiRecargasIntegerInput.Text = ConfigSettings.ReadDBSetting("ConfigPortMultiRecargas");
            ConfigTimeMultiRecargasIntegerInput.Text = ConfigSettings.ReadDBSetting("ConfigTimeMultiRecargas");

            //PathJavaHomeMultiRecargasTextBoxX.Text = ConfigSettings.ReadSetting("PathJavaHomeMultiRecargas");
            //PathSalidaMultiRecargasTextBoxX.Text = ConfigSettings.ReadSetting("PathSalidaMultiRecargas");

            PathJavaHomeMultiRecargasTextBoxX.Text = ConfigSettings.ReadSetting("PathJavaHomeMultiRecargas");
            PathSalidaMultiRecargasTextBoxX.Text = ConfigSettings.ReadSetting("PathSalidaMultiRecargas");
            JarMultiRecargasTextBoxX.Text = ConfigSettings.ReadSetting("JarMultiRecargas");
            dirQueryMultiRecargasTextBox.Text = ConfigSettings.ReadSetting("PathMultiRecargasQuerySalida");


            fraseEncriptacionMultiTextBoxX.Text = ConfigSettings.ReadDBSetting("FraseEncriptacioMultiRecargas");

            string CadTelCel = ConfigSettings.ReadDBSetting("ConfigGrupoMultiRecargas");

            string[] valoresTAE = CadTelCel.Split(new char[] { '|' });
            if (valoresTAE.Length == 4)
            {
                grupoMultiRecargasIntegerInput.Text = valoresTAE[0];
                cadenaMultiRecargasIntegerInput.Text = valoresTAE[1];
                tiendaMultiRecargasIntegerInput.Text = valoresTAE[2];
                cajaMultiRecargasIntegerInput.Text = valoresTAE[3];
            }
        }

        private void cargaFEL()
        {
            tb_DirXMLFel.Text = ConfigSettings.ReadSetting("ConfigFELDirXML");
            tb_RFCFel.Text = ConfigSettings.ReadDBSetting("ConfigFELRfc");
            tb_UsrFel.Text = ConfigSettings.ReadDBSetting("ConfigFELUser");
            tb_PwdFel.Text = ConfigSettings.ReadDBSetting("ConfigFELPwd");
            tb_MetodoPagoFel.Text = ConfigSettings.ReadDBSetting("ConfigFELMetodoPago");
            tb_FormaPagoFel.Text = ConfigSettings.ReadDBSetting("ConfigFELFormaPago");
            felActividadEmpresarialTextBoxX.Text = ConfigSettings.ReadDBSetting("ConfigFELActividadEmpresarial");
            felEmailTextBoxX.Text = ConfigSettings.ReadDBSetting("ConfigFELEmail");
            felPaginaWebTextBoxX.Text = ConfigSettings.ReadDBSetting("ConfigFELPaginaWeb");
        }

        private void cargaSucursales()
        {
            SIFNegocio.Sucursales sucursales = new SIFNegocio.Sucursales();
            List<SIFModelo.Sucursal> sucursalesList = sucursales.Buscar("", "").DataSource as List<SIFModelo.Sucursal>;

            if (sucursalesList == null)
            {
                sucursalesList = new List<SIFModelo.Sucursal>();
            }

            if (sucursalesList.Count > 0)
            {
                this.sucursalesComboBoxEx.DataSource = sucursalesList;

                sucursalesComboBoxEx.ValueMember = "SucursalesID";
                sucursalesComboBoxEx.DisplayMember = "Nombre";
            }
        }


        private void cargaImpresoras()
        {
            Dictionary<string, string> impresoras = new Dictionary<string, string>();
            foreach (var impresora in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                var impresoraNombre = impresora.ToString();
                impresoras.Add(impresoraNombre, impresoraNombre);
            }
            BindingSource impresorasBindingSource = new BindingSource();
            impresorasBindingSource.DataSource = impresoras;

            impresoraTicketsComboBoxEx.DataSource = impresorasBindingSource;
            impresoraTicketsComboBoxEx.DisplayMember = "Key";
            impresoraTicketsComboBoxEx.DisplayMember = "Value";

            BindingSource impresorasFacturasBindingSource = new BindingSource();
            impresorasFacturasBindingSource.DataSource = impresoras;
            impresoraFacturasComboBoxEx.DataSource = impresorasFacturasBindingSource;
            impresoraFacturasComboBoxEx.DisplayMember = "Key";
            impresoraFacturasComboBoxEx.DisplayMember = "Value";
        }


        private void examinaDirectorioReportes()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.directorioReportesTextBoxX.Text = dialog.SelectedPath;
            }
        }

        private void examinaDirectorioImagenes()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.directorioImagenesTextBox.Text = dialog.SelectedPath;
            }
        }

        private void examinaDirectorioMailTemplates()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.directorioTemplatesMailtextBox.Text = dialog.SelectedPath;
            }
        }

        private void guardaConfiguracionAplicacion()
        {
            //VALIDAMOS LOS DATOS
            if (sucursalesComboBoxEx.SelectedValue == null)
            {
               MessageBox.Show("Seleccione una sucursal");
                sucursalesComboBoxEx.Focus();
                return;
            }

            if (!new System.IO.DirectoryInfo(this.directorioReportesTextBoxX.Text).Exists)
            {
               MessageBox.Show("El directorio destinado a reportes no existe");
                this.directorioReportesTextBoxX.SelectAll();
                return;
            }

            if (!new System.IO.DirectoryInfo(this.directorioImagenesTextBox.Text).Exists)
            {
               MessageBox.Show("El directorio destinado a imágenes no existe");
                this.directorioImagenesTextBox.SelectAll();
                return;
            }

            if (!new System.IO.DirectoryInfo(this.directorioTemplatesMailtextBox.Text).Exists)
            {
               MessageBox.Show("El directorio las plantillas de email no existe");
                this.directorioTemplatesMailtextBox.SelectAll();
                return;
            }

            ConfigSettings.WriteSetting("SucursalID", sucursalesComboBoxEx.SelectedValue.ToString());
            ConfigSettings.WriteSetting("DirectorioReportes", directorioReportesTextBoxX.Text);
            ConfigSettings.WriteSetting("DirectorioImagenes", directorioImagenesTextBox.Text);
            ConfigSettings.WriteSetting("DirectorioPlantillasEmail", directorioTemplatesMailtextBox.Text);
            ConfigSettings.WriteSetting("ImpresoraTickets", impresoraTicketsComboBoxEx.Text);
            ConfigSettings.WriteSetting("ImpresoraReportes", impresoraFacturasComboBoxEx.Text);

            ConfigurationManager.RefreshSection("appSettings");


            //recargamos la configuracion
            SIFModelo.Configuracion.Aplicacion configuracion = new SIFModelo.Configuracion.Aplicacion();

            configuracion.SucursalID = int.Parse(ConfigSettings.ReadSetting("SucursalID").ToString());
            configuracion.DirectorioReportes = ConfigSettings.ReadSetting("DirectorioReportes");
            configuracion.DirectorioImagenes = ConfigSettings.ReadSetting("DirectorioImagenes");
            configuracion.DirectorioTemplates = ConfigSettings.ReadSetting("DirectorioPlantillasEmail");
            configuracion.ImpresoraTickets = ConfigSettings.ReadSetting("ImpresoraTickets");
            configuracion.ImpresoraReportes = ConfigSettings.ReadSetting("ImpresoraReportes");

            SIFNegocio.Configuracion.Configuraciones.Aplicacion = configuracion;



           MessageBox.Show("Se ha guardado la configuración de la aplicación correctamente");
        }


        public void cargaConfiguracion()
        {
            //sucursalesComboBoxEx.Text = ConfigSettings.ReadSetting("SucursalID");
            var sucursalid = ConfigSettings.ReadSetting("SucursalID");
            if (sucursalid.ToString().IsInteger())
            {
                sucursalesComboBoxEx.SelectedValue = int.Parse(sucursalid);
            }
            directorioReportesTextBoxX.Text = ConfigSettings.ReadSetting("DirectorioReportes");
            directorioImagenesTextBox.Text = ConfigSettings.ReadSetting("DirectorioImagenes");
            directorioTemplatesMailtextBox.Text = ConfigSettings.ReadSetting("DirectorioPlantillasEmail");
            impresoraTicketsComboBoxEx.Text = ConfigSettings.ReadSetting("ImpresoraTickets");
            impresoraFacturasComboBoxEx.Text = ConfigSettings.ReadSetting("ImpresoraReportes");


        }


        private void guardaEmail()
        {
            ConfigSettings.WriteDBSetting("MailServer", txtServer.Text);
            ConfigSettings.WriteDBSetting("MailPort", txtPort.Text);
            ConfigSettings.WriteDBSetting("MailSSL", chkBox_SSL.Checked ? "1" : "0");
            ConfigSettings.WriteDBSetting("MailUser", txtUsername.Text);
            ConfigSettings.WriteDBSetting("MailPWD", SIFNegocio.Helpers.CryptorEngine.Encrypt(txtPassword.Text, true));
            ConfigSettings.WriteDBSetting("ImpresoraReportes", impresoraFacturasComboBoxEx.Text);
        }
        #endregion

        private void guardarButtonX_Click(object sender, EventArgs e)
        {
            this.guardarConexion();
        }

        private void probarConexionButtonX_Click(object sender, EventArgs e)
        {
            this.probarConexion();
        }

        private void ConfiguracionForm_Load(object sender, EventArgs e)
        {
            this.cargaSucursales();

            // Init ComboBox Connection Type
            CBox_TipoConexion.Items.Clear();
            CBox_TipoConexion.Items.Add("Dedicated Server");
            CBox_TipoConexion.Items.Add("Shared Server");

            // Init ComboBoc Protocol
            CBox_Protocolo.Items.Clear();
            CBox_Protocolo.Items.Add("TCP/IP");
            CBox_Protocolo.Items.Add("Names Pipes");
            CBox_Protocolo.Items.Add("IPC");


            this.cargaConexion();
            this.cargaImpresoras();
            this.cargaConfiguracion();
            this.cargaEmail();
            this.cargaPfizer();
            this.cargaTAE();
            this.CargaMultiRecargas();
            this.cargaFEL();
            this.cargaNadro();
            this.sucursalesComboBoxEx.Focus();
        }

        private void examinarDirectorioReportesButtonX_Click(object sender, EventArgs e)
        {
            this.examinaDirectorioReportes();
        }

        private void examinarDirectorioImagenesButtonX_Click(object sender, EventArgs e)
        {
            this.examinaDirectorioImagenes();
        }

        private void examinarTemplatesMailButtonX_Click(object sender, EventArgs e)
        {
            this.examinaDirectorioMailTemplates();
        }

        private void guardarConfiguracionAplicacionButtonX_Click(object sender, EventArgs e)
        {
            this.guardaConfiguracionAplicacion();
        }

        private void tabControl1_SelectedTabChanged(object sender, TabStripTabChangedEventArgs e)
        {
            switch (e.NewTab.Name)
            {
                case "aplicacionTabItem":
                    this.sucursalesComboBoxEx.Focus();
                    break;
                case "baseDatosTabItem":
                    this.TB_NServicio.SelectAll();
                    this.TB_NServicio.Focus();
                    break;
                case "correoTabItem":
                    this.txtServer.SelectAll();
                    this.txtServer.Focus();
                    break;
            }
        }

        private void btn_SaveMail_Click(object sender, EventArgs e)
        {
            this.guardaEmail();
        }

        private void btn_ConfigpFizer_Click(object sender, EventArgs e)
        {
            ConfigSettings.WriteDBSetting("ConfigpFizerPrograma", tb_ProgId.Text);
            ConfigSettings.WriteDBSetting("ConfigpFizerCadena", tb_CadenaId.Text);
            ConfigSettings.WriteDBSetting("ConfigpFizerSucursal", tb_SucursalId.Text);
            ConfigSettings.WriteEndPoint("WSPrepagoSoap", urlWSPfizerTextBoxX.Text);
            ConfigSettings.WriteSetting("PathpFizerSalida", directorioPfizerTextBoxX.Text);
            ConfigSettings.WriteDBSetting("ConfigpFizerUsuario", usuarioPfizerTextBoxX.Text);

            ConfigurationManager.RefreshSection("appSettings");
           MessageBox.Show("La configuración de Pfizer se ha guardado correctamente");
        }

        private void btn_GuardarFiscal_Click(object sender, EventArgs e)
        {
            ConfigSettings.WriteSetting("ConfigFELDirXML", tb_DirXMLFel.Text);
            ConfigSettings.WriteDBSetting("ConfigFELRfc", tb_RFCFel.Text);
            ConfigSettings.WriteDBSetting("ConfigFELUser", tb_UsrFel.Text);
            ConfigSettings.WriteDBSetting("ConfigFELPwd", tb_PwdFel.Text);
            ConfigSettings.WriteDBSetting("ConfigFELMetodoPago", tb_MetodoPagoFel.Text);
            ConfigSettings.WriteDBSetting("ConfigFELFormaPago", tb_FormaPagoFel.Text);
            ConfigSettings.WriteDBSetting("ConfigFELActividadEmpresarial", felActividadEmpresarialTextBoxX.Text);
            ConfigSettings.WriteDBSetting("ConfigFELEmail", felEmailTextBoxX.Text);
            ConfigSettings.WriteDBSetting("ConfigFELPaginaWeb", felPaginaWebTextBoxX.Text);

            ConfigurationManager.RefreshSection("appSettings");

           MessageBox.Show("La configuración de FEL se ha guardado correctamente");
        }

        private void btn_TestTaeTelCel_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string ret = string.Empty;
            string err = string.Empty;
            string str = null;
            string quote = "\"";
            string CIni = "<";
            string CFin = ">";
            string Sep = " ";
            string Operacion = string.Empty;
            string sWait = ConfigSettings.ReadSetting("ConfigTimeTelCel");
            char[] charsToTrim = { '<', '>' };
            Random r = new Random();
            int iWait = 5000;

            if (!string.IsNullOrEmpty(sWait))
                iWait = Convert.ToInt32(sWait);


            // Nombre Archivo de respuesta
            string GpoId = tb_GpoTelCel.Value.ToString();
            string CadId = tb_CadTelCel.Value.ToString();
            string TieId = tb_TieTelCel.Value.ToString();
            string CajId = tb_CajaTelCel.Value.ToString();
            string Folio = r.Next(1, 100).ToString();

            // Cadena de Envio
            string FecEnv = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("dd/MM/yyyy HH:mm:ss");
            string Sku = "8469766750482";
            string NumTel = "1111111111";

            string PathRecarga = tb_taesalida.Text;
            string FileTae = GpoId + CadId + TieId + CajId + Folio + ".txt";
            string FileRecarga = Path.Combine(PathRecarga, FileTae);
            string command = string.Empty;

            try
            {
                //string command = Path.Combine(tb_JavaHome.Text, "java.exe -version");
                //if (string.IsNullOrEmpty(cmb_Operacion.Text))
                Operacion = "Query";
                //else
                //{
                //    Operacion = cmb_Operacion.Text.Split('-')[1].Trim();

                //}

                //command = " "java -jar conector.jar ";
                command = "\"" + tb_JavaHome.Text + "\\" + "java\" -jar " + "\"" + jarTaeURLTextBoxX.Text + "\"" + " ";
                command += tb_HostTelCel.Text + Sep;
                command += tb_PuertoTelCel.Text + Sep;
                command += quote + CIni + Operacion + CFin;
                command += CIni + GpoId + CFin;
                command += CIni + CadId + CFin;
                command += CIni + TieId + CFin;
                command += CIni + CajId + CFin;
                command += CIni + FecEnv + CFin;
                command += CIni + Sku + CFin;
                command += CIni + NumTel + CFin;
                command += CIni + "24744" + CFin + quote + Sep; //Folio
                command += "Pruebas" + Sep + @PathRecarga + "\\"; // "c:\\desarrollo\\recargas\\"; 

                //command = "java -jar conector.jar " + tb_HostTelCel.Text + " " + tb_PuertoTelCel.Text + " " + quote + "<Query><7><1><1><1><09/07/2012 15:32:08><8469760101006><1111111111><170>" + quote + " " + "Pruebas c:\\desarrollo\\recargas\\";
                //                command = "java -jar conector.jar " + tb_HostTelCel.Text + " " + tb_PuertoTelCel.Text + " " + quote + "<ReLoad><7><1><1><1><09/07/2012 18:32:08><8469766750482><1111111111><170>" + quote + " " + "Pruebas c:\\desarrollo\\recargas\\";

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
                    {
                        // Recupera archivo de respuesta
                        if (File.Exists(FileRecarga))
                        {
                            // Read File Result
                            StreamReader rFile = new StreamReader(FileRecarga, System.Text.Encoding.GetEncoding("iso-8859-1"));
                            while ((str = rFile.ReadLine()) != null)
                            {
                                string[] Tokens = str.Split('<');
                               MessageBox.Show(Tokens[Tokens.Length - 2].TrimEnd(charsToTrim) + " - " +
                                    Tokens[Tokens.Length - 1].TrimEnd(charsToTrim));
                            }

                            rFile.Close();
                            rFile.Dispose();
                        }
                        else
                        {
                           MessageBox.Show("La configuración es correcta: \n" + ret);
                        }
                    }
                    else
                    {
                       MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
        }

        private void btn_SaveTaeTelCel_Click(object sender, EventArgs e)
        {
            string CadTelCel = tb_GpoTelCel.Text + '|' + tb_CadTelCel.Text + '|' + tb_TieTelCel.Text + '|' + tb_CajaTelCel.Text;
            ConfigSettings.WriteDBSetting("ConfigGrupoTelCel", CadTelCel);
            ConfigSettings.WriteDBSetting("ConfigHostTelCel", tb_HostTelCel.Text);
            ConfigSettings.WriteDBSetting("ConfigPortTelCel", tb_PuertoTelCel.Text);
            ConfigSettings.WriteDBSetting("ConfigTimeTelCel", tb_TimeMaxTelCel.Text);
            ConfigSettings.WriteDBSetting("FraseEncriptacionTelCel", fraseEncriptacionTextBoxX.Text);
            ConfigSettings.WriteDBSetting("ConfigPrefijoTelCel", prefijoTelcelTextBoxX.Text);
            //ConfigSettings.WriteSetting("WaitTelcel", timeoutTelcelIntegerInput.Text);
            ConfigurationManager.RefreshSection("appSettings");
           MessageBox.Show("Se ha gardado correctamente la configuración de TAE");
        }

        private void btn_JavaHome_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog bdlg = new FolderBrowserDialog();
                bdlg.ShowNewFolderButton = true;
                bdlg.SelectedPath = Environment.CurrentDirectory;

                if (bdlg.ShowDialog() == DialogResult.OK)
                {
                    tb_JavaHome.Text = bdlg.SelectedPath;
                    ConfigSettings.WriteSetting("PathJavaHome", tb_JavaHome.Text);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        private void btn_SalidaTae_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog bdlg = new FolderBrowserDialog();
            bdlg.ShowNewFolderButton = true;
            bdlg.SelectedPath = Environment.CurrentDirectory;

            if (bdlg.ShowDialog() == DialogResult.OK)
            {
                tb_taesalida.Text = bdlg.SelectedPath;
                ConfigSettings.WriteSetting("PathTAESalida", tb_taesalida.Text);
                ConfigurationManager.RefreshSection("appSettings");
            }


        }

        private void btn_SalidaFEL_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog bdlg = new FolderBrowserDialog();
            bdlg.ShowNewFolderButton = true;
            bdlg.SelectedPath = Environment.CurrentDirectory;

            if (bdlg.ShowDialog() == DialogResult.OK)
            {
                tb_DirXMLFel.Text = bdlg.SelectedPath;
                //ConfigSettings.WriteSetting("ConfigFELDirXML", tb_DirXMLFel.Text);

                //ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void btn_NadroSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_NadroUsr.Text))
            {
                this.tb_NadroUsr.Focus();
               MessageBox.Show("El usuario es necesario para la conexión NADRO");
                return;
            }

            if (string.IsNullOrEmpty(tb_NadroPwd.Text))
            {
               MessageBox.Show("Debe ingresar la contraseña para la conexión NADRO");
                this.tb_NadroPwd.Focus();
                return;
            }

            if (string.IsNullOrEmpty(urlWSNADROtextBoxX.Text))
            {
               MessageBox.Show("Especifique la URL del Web Service");
                urlWSNADROtextBoxX.Focus();
                return;
            }

            ConfigSettings.WriteDBSetting("ConfigNadroCadena", tb_NadroCad.Text);
            ConfigSettings.WriteDBSetting("ConfigNadroUsr", tb_NadroUsr.Text);
            ConfigSettings.WriteDBSetting("ConfigNadroPwd", tb_NadroPwd.Text);
            ConfigSettings.WriteDBSetting("ConfigNadroSucursal", tb_NadroSuc.Text);
            ConfigSettings.WriteEndPoint("WSCirculodelaSaludSoap", urlWSNADROtextBoxX.Text);
            ConfigurationManager.RefreshSection("appSettings");

            SIFModelo.Configuracion.Nadro nadro = new SIFModelo.Configuracion.Nadro();
            nadro.Cadena = tb_NadroCad.Text;
            //nadro.ProgramaID = ConfigSettings.ReadSetting("ConfigpFizerPrograma");
            nadro.Sucursal = int.Parse(tb_NadroSuc.Text);
            nadro.Usuario = tb_NadroUsr.Text;
            nadro.Contrasena = tb_NadroPwd.Text;
            
            SIFNegocio.Configuracion.Configuraciones.Nadro = nadro;


           MessageBox.Show("Se ha guardado la configuración");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //RTB_RMail.Clear();
            if (txtTo.Text == String.Empty)
            {
                MessageBox.Show("El campo para no puede ser vacio", "Factura Electrónica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTo.Focus();
            }
            else
               MessageBox.Show(SIF3.Clases.clsSMTP.SendSMTP(txtServer.Text, int.Parse(txtPort.Text), txtUsername.Text, txtPassword.Text, chkBox_SSL.Checked ? true : false, txtTo.Text, txtUsername.Text, "SIF 3.0 PRUEBA DE ENVIO", "Este mail se ha enviado desde la aplicación SIF 3.0, indicando que la configuración es correcta", null, true));
            Cursor.Current = Cursors.Default;
        }

        private void conciliacionbuttonX_Click(object sender, EventArgs e)
        {
            View.Reportes.Venta.ConciliacionTAEForm frmConciliacion = new Reportes.Venta.ConciliacionTAEForm();
            frmConciliacion.ShowDialog();
        }

        private void btn_NadroTest_Click(object sender, EventArgs e)
        {
            string SesionID = "";
            try
            {
                SIFNegocio.WebServices.NADRO wsNadro = new SIFNegocio.WebServices.NADRO();
                SIFModelo.Configuracion.Nadro configuracion = new SIFModelo.Configuracion.Nadro();
                configuracion.Cadena = tb_NadroCad.Text;
                configuracion.Contrasena = tb_NadroPwd.Text;
                configuracion.Sucursal = int.Parse(tb_NadroSuc.Text);
                configuracion.Usuario = tb_NadroUsr.Text;
                SesionID = wsNadro.GetLogin(configuracion);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }

            if (!string.IsNullOrEmpty(SesionID))
            {
               MessageBox.Show("Se ha iniciado la sesión correctamente " + SesionID);
            }
        }

        private void taeJarButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog bdlg = new OpenFileDialog();
            bdlg.Filter = "JAR de conexión (*.jar)|*.jar";

            if (bdlg.ShowDialog() == DialogResult.OK)
            {
                jarTaeURLTextBoxX.Text = bdlg.FileName;
                ConfigSettings.WriteSetting("JarTelCel", jarTaeURLTextBoxX.Text);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void guardarMultiRecargasButtonX_Click(object sender, EventArgs e)
        {
            string CadTelMultiRecargas = grupoMultiRecargasIntegerInput.Text + '|' + cadenaMultiRecargasIntegerInput.Text + '|' + tiendaMultiRecargasIntegerInput.Text + '|' + cajaMultiRecargasIntegerInput.Text;
            ConfigSettings.WriteDBSetting("ConfigGrupoMultiRecargas", CadTelMultiRecargas);
            ConfigSettings.WriteDBSetting("ConfigHostMultiRecargas", ConfigHostMultiRecargasTextBox.Text);
            ConfigSettings.WriteDBSetting("ConfigPortMultiRecargas", ConfigPortMultiRecargasIntegerInput.Text);
            ConfigSettings.WriteDBSetting("ConfigTimeMultiRecargas", ConfigTimeMultiRecargasIntegerInput.Text);
            ConfigSettings.WriteDBSetting("FraseEncriptacioMultiRecargas", fraseEncriptacionMultiTextBoxX.Text);

            ConfigSettings.WriteDBSetting("ConfigPrefijoMultir", prefijoMultiTextBoxX.Text);

            //ConfigSettings.WriteSetting("WaitMultiRecargas", timeoutMultiIntegerInput.Text);
            ConfigurationManager.RefreshSection("appSettings");
           MessageBox.Show("Se ha gardado correctamente la configuración de MULTI RECARGAS");
        }

        private void javaHomeMultiButtonX_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog bdlg = new FolderBrowserDialog();
                bdlg.ShowNewFolderButton = true;
                bdlg.SelectedPath = Environment.CurrentDirectory;

                if (bdlg.ShowDialog() == DialogResult.OK)
                {
                    PathJavaHomeMultiRecargasTextBoxX.Text = bdlg.SelectedPath;
                    ConfigSettings.WriteSetting("PathJavaHomeMultiRecargas", PathJavaHomeMultiRecargasTextBoxX.Text);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        private void dirRespuestasMultiButtonX_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog bdlg = new FolderBrowserDialog();
            bdlg.ShowNewFolderButton = true;
            bdlg.SelectedPath = Environment.CurrentDirectory;

            if (bdlg.ShowDialog() == DialogResult.OK)
            {
                PathSalidaMultiRecargasTextBoxX.Text = bdlg.SelectedPath;
                ConfigSettings.WriteSetting("PathSalidaMultiRecargas", PathSalidaMultiRecargasTextBoxX.Text);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void archivoJarMultiButtonX_Click(object sender, EventArgs e)
        {
            OpenFileDialog bdlg = new OpenFileDialog();
            bdlg.Filter = "JAR de conexión (*.jar)|*.jar";

            if (bdlg.ShowDialog() == DialogResult.OK)
            {
                JarMultiRecargasTextBoxX.Text = bdlg.FileName;
                ConfigSettings.WriteSetting("JarMultiRecargas", JarMultiRecargasTextBoxX.Text);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void probarMultiRecargasbuttonX_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string ret = string.Empty;
            string err = string.Empty;
            string str = null;
            string quote = "\"";
            string CIni = "<";
            string CFin = ">";
            string Sep = " ";
            string Operacion = string.Empty;
            string sWait = ConfigSettings.ReadSetting("ConfigTimeTelCel");
            char[] charsToTrim = { '<', '>' };
            Random r = new Random();
            int iWait = 5000;

            if (!string.IsNullOrEmpty(sWait))
                iWait = Convert.ToInt32(sWait);


            // Nombre Archivo de respuesta
            string GpoId = grupoMultiRecargasIntegerInput.Value.ToString();
            string CadId = cadenaMultiRecargasIntegerInput.Value.ToString();
            string TieId = tiendaMultiRecargasIntegerInput.Value.ToString();
            string CajId = cajaMultiRecargasIntegerInput.Value.ToString();
            string Folio = r.Next(1, 100).ToString();

            // Cadena de Envio
            string FecEnv = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("dd/MM/yyyy HH:mm:ss");
            string Sku = "8469766750482";
            string NumTel = "1111111111";

            string PathRecarga = PathSalidaMultiRecargasTextBoxX.Text;
            string FileTae = GpoId + CadId + TieId + CajId + Folio + ".txt";
            string FileRecarga = Path.Combine(PathRecarga, FileTae);
            string command = string.Empty;

            try
            {
                //string command = Path.Combine(tb_JavaHome.Text, "java.exe -version");
                //if (string.IsNullOrEmpty(cmb_Operacion.Text))
                Operacion = "Query";
                //else
                //{
                //    Operacion = cmb_Operacion.Text.Split('-')[1].Trim();

                //}

                //command = " "java -jar conector.jar ";
                command = "\"" + PathJavaHomeMultiRecargasTextBoxX.Text + "\\" + "java\" -jar " + "\"" + JarMultiRecargasTextBoxX.Text + "\"" + " ";
                command += ConfigHostMultiRecargasTextBox.Text + Sep;
                command += ConfigPortMultiRecargasIntegerInput.Text + Sep;
                command += quote + CIni + Operacion + CFin;
                command += CIni + GpoId + CFin;
                command += CIni + CadId + CFin;
                command += CIni + TieId + CFin;
                command += CIni + CajId + CFin;
                command += CIni + FecEnv + CFin;
                command += CIni + Sku + CFin;
                command += CIni + NumTel + CFin;
                command += CIni + "24744" + CFin + quote + Sep; //Folio
                command += "Pruebas" + Sep + @PathRecarga + "\\"; // "c:\\desarrollo\\recargas\\"; 

                //command = "java -jar conector.jar " + tb_HostTelCel.Text + " " + tb_PuertoTelCel.Text + " " + quote + "<Query><7><1><1><1><09/07/2012 15:32:08><8469760101006><1111111111><170>" + quote + " " + "Pruebas c:\\desarrollo\\recargas\\";
                //                command = "java -jar conector.jar " + tb_HostTelCel.Text + " " + tb_PuertoTelCel.Text + " " + quote + "<ReLoad><7><1><1><1><09/07/2012 18:32:08><8469766750482><1111111111><170>" + quote + " " + "Pruebas c:\\desarrollo\\recargas\\";

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
                    {
                        // Recupera archivo de respuesta
                        if (File.Exists(FileRecarga))
                        {
                            // Read File Result
                            StreamReader rFile = new StreamReader(FileRecarga, System.Text.Encoding.GetEncoding("iso-8859-1"));
                            while ((str = rFile.ReadLine()) != null)
                            {
                                string[] Tokens = str.Split('<');
                               MessageBox.Show(Tokens[Tokens.Length - 2].TrimEnd(charsToTrim) + " - " +
                                    Tokens[Tokens.Length - 1].TrimEnd(charsToTrim));
                            }

                            rFile.Close();
                            rFile.Dispose();
                        }
                        else
                        {
                           MessageBox.Show("La configuración es correcta: \n" + ret);
                        }
                    }
                    else
                    {
                       MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
        }

        private void conciliacionMultirecargasButtonX_Click(object sender, EventArgs e)
        {
            View.Reportes.Venta.ConciliacionTAEForm frmConciliacion = new Reportes.Venta.ConciliacionTAEForm();
            frmConciliacion.ShowDialog();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog bdlg = new FolderBrowserDialog();
            bdlg.ShowNewFolderButton = true;
            bdlg.SelectedPath = Environment.CurrentDirectory;

            if (bdlg.ShowDialog() == DialogResult.OK)
            {
                dirQueryMultiRecargasTextBox.Text = bdlg.SelectedPath;
                ConfigSettings.WriteSetting("PathMultiRecargasQuerySalida", dirQueryMultiRecargasTextBox.Text);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void consultaTAEButtonX_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog bdlg = new FolderBrowserDialog();
            bdlg.ShowNewFolderButton = true;
            bdlg.SelectedPath = Environment.CurrentDirectory;

            if (bdlg.ShowDialog() == DialogResult.OK)
            {
                consultaTAETextBoxX.Text = bdlg.SelectedPath;
                ConfigSettings.WriteSetting("PathTAEQuerySalida", consultaTAETextBoxX.Text);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        SIFNegocio.Sucursales Suc = new SIFNegocio.Sucursales();
        private void Sucursales_Click(object sender, EventArgs e)
        {
   
            GridLinksSuc.DataSource = Suc.BuscarLink("", "");
            for (int i = 3; i < GridLinksSuc.Columns.Count-2; i++)
            {
                GridLinksSuc.Columns[i].Visible = false;
            }
        }

        private void GridLinksSuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewButtonXCell cell = GridLinksSuc.CurrentCell as DataGridViewButtonXCell;

            if (cell != null)
            {
                if (cell.ReadOnly)
                    return;

                DataGridViewButtonXColumn bc =
                    GridLinksSuc.Columns[e.ColumnIndex] as DataGridViewButtonXColumn;

                if (bc != null)
                {
                    string s = Convert.ToString(cell.Value);

                    switch (bc.Name)
                    {
                        case "btn_Link":
                            Suc.TestDBLink(GridLinksSuc["ID_Link", e.RowIndex].Value.ToString());
                            break;
                    }
                }
            }
        }

        private Boolean Modificar(SIFModelo.Sucursal Sucursal)
        {
            this.Cursor = Cursors.WaitCursor;

            bool modificado = Suc.Modificar(Sucursal);

            if (!modificado)
            {
                this.GridLinksSuc.CancelEdit();
                this.GridLinksSuc.Refresh();
            }

            this.Cursor = Cursors.Default;

            return modificado;
        }
        DataGridViewCell celdaEditada;
        private void GridLinksSuc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //VALIDAR LA COLUMNA Y EL VALOR
            DataGridViewX grid = sender as DataGridViewX;
            SIFModelo.Sucursal Sucursal = ((ObjectView<SIFModelo.Sucursal>)grid.CurrentRow.DataBoundItem).Object as SIFModelo.Sucursal;

            //SI ES MODIFICADO
            if (Sucursal.SucursalesID != 0)
            {
                this.Modificar(Sucursal);
            }

            celdaEditada = grid[e.ColumnIndex, e.RowIndex];
        }

        private void directorioPfizerButtonX_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog bdlg = new FolderBrowserDialog();
            bdlg.ShowNewFolderButton = true;
            bdlg.SelectedPath = Environment.CurrentDirectory;

            if (bdlg.ShowDialog() == DialogResult.OK)
            {
                directorioPfizerTextBoxX.Text = bdlg.SelectedPath;
                //ConfigSettings.WriteSetting("ConfigFELDirXML", tb_DirXMLFel.Text);

                //ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void pathPfizerConciliacionButtonX_Click(object sender, EventArgs e)
        {
            View.Configuracion.ConciliacionPfizerForm frmConciliacion = new Configuracion.ConciliacionPfizerForm();
            frmConciliacion.ShowDialog();
        }



        private void conciliacionNadroButtonX_Click(object sender, EventArgs e)
        {
            View.Configuracion.ConciliacionNadroForm frmConciliacion = new Configuracion.ConciliacionNadroForm();
            frmConciliacion.ShowDialog();
        }

      


    }
}
