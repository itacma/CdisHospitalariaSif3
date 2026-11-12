using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro.ColorTables;
using DevComponents.DotNetBar;
using SIF.Helpers;
using System.Reflection;
using System.IO;
using System.Configuration;
using System.Threading;
using System.Security.Principal;
using System.Net.NetworkInformation;

namespace SIF
{
    public partial class MainForm : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        //COMENTARIO JUAN ANTONIO VALERA MARQUEZ PA SERVIRLE A DIOS Y A ASTE.
        string nombreVersion;
        Templates.LoginForm frmLogin = new Templates.LoginForm();
        public MainForm(string nombreVersion)
        {
            this.nombreVersion = nombreVersion;
        //   MessageBox.UseSystemLocalizedString = true;
            Templates.SplashCreenForm frmSplash = new Templates.SplashCreenForm();
            Application.DoEvents();
            frmSplash.ShowDialog();

            InitializeComponent();

            //SABER SI ES ADMINISTRADOR
            Thread.GetDomain().SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

            WindowsPrincipal myUser = (WindowsPrincipal)Thread.CurrentPrincipal;
            if (!myUser.IsInRole(WindowsBuiltInRole.Administrator))
            {
                #if DEBUG
                //MessageBoxEx.Show("Ejecute el sistema como administrador");
                #endif
            }
            //MessageBoxEx.Show("Ejecute el sistema como administrador1");
            //StyleManager.MetroColorGeneratorParameters =  new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, Color.FromArgb(204, 0, 43));
            //StyleManager.MetroColorGeneratorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, Color.FromArgb(46, 107, 250));
            StyleManager.MetroColorGeneratorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, Color.FromArgb(46, 97, 157));

            //this.InicializaFuentes();
            MetroColorGeneratorParameters theme = MetroColorGeneratorParameters.PowderRed;
            StyleManager.MetroColorGeneratorParameters = theme;

            this.ActivaComandos();
            this.activaAnimaciones(false);
            //MessageBoxEx.Show("Ejecute el sistema como administradoR2");


        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            vf.verifica(this.itemContainer1, Helpers.Sesion.Usuario.UsuariosID.ToString());
            almacenMetroTileItem.Enabled = false;
        }

        DevComponents.DotNetBar.Primitives.CustomCollection<DevComponents.DotNetBar.Metro.MetroTileFrame> ventasMetroTileItems;
        DevComponents.DotNetBar.Primitives.CustomCollection<DevComponents.DotNetBar.Metro.MetroTileFrame> comprasMetroTileItems;
        DevComponents.DotNetBar.Primitives.CustomCollection<DevComponents.DotNetBar.Metro.MetroTileFrame> almacenMetroTileItems;
        DevComponents.DotNetBar.Primitives.CustomCollection<DevComponents.DotNetBar.Metro.MetroTileFrame> CATmetroTileItems;
        DevComponents.DotNetBar.Primitives.CustomCollection<DevComponents.DotNetBar.Metro.MetroTileFrame> inventarioMetroTileItems;
        DevComponents.DotNetBar.Primitives.CustomCollection<DevComponents.DotNetBar.Metro.MetroTileFrame> configuracionMetroTileItems;



        private void activaAnimaciones(bool activo)
        {
            // activo = false;
            if (activo)
            {
                ventasMetroTileItem.Frames.Clear();
                foreach (DevComponents.DotNetBar.Metro.MetroTileFrame frame in ventasMetroTileItems)
                {
                    ventasMetroTileItem.Frames.Add(frame);
                }

                comprasMetroTileItem.Frames.Clear();
                foreach (DevComponents.DotNetBar.Metro.MetroTileFrame frame in comprasMetroTileItems)
                {
                    comprasMetroTileItem.Frames.Add(frame);
                }

                almacenMetroTileItem.Frames.Clear();
                foreach (DevComponents.DotNetBar.Metro.MetroTileFrame frame in almacenMetroTileItems)
                {
                    almacenMetroTileItem.Frames.Add(frame);
                }

                CATmetroTileItem.Frames.Clear();
                foreach (DevComponents.DotNetBar.Metro.MetroTileFrame frame in CATmetroTileItems)
                {
                    CATmetroTileItem.Frames.Add(frame);
                }

                inventarioMetroTileItem.Frames.Clear();
                foreach (DevComponents.DotNetBar.Metro.MetroTileFrame frame in inventarioMetroTileItems)
                {
                    inventarioMetroTileItem.Frames.Add(frame);
                }

                configuracionMetroTileItem.Frames.Clear();
                foreach (DevComponents.DotNetBar.Metro.MetroTileFrame frame in configuracionMetroTileItems)
                {
                    configuracionMetroTileItem.Frames.Add(frame);
                }

            }
            else
            {
                ventasMetroTileItems = new DevComponents.DotNetBar.Primitives.CustomCollection<DevComponents.DotNetBar.Metro.MetroTileFrame>();
                foreach (DevComponents.DotNetBar.Metro.MetroTileFrame frame in ventasMetroTileItem.Frames)
                {
                    ventasMetroTileItems.Add(frame);
                }
                ventasMetroTileItem.Frames.Clear();
                ventasMetroTileItem.Frames.Add(ventasMetroTileItems[0]);

                comprasMetroTileItems = new DevComponents.DotNetBar.Primitives.CustomCollection<DevComponents.DotNetBar.Metro.MetroTileFrame>();
                foreach (DevComponents.DotNetBar.Metro.MetroTileFrame frame in comprasMetroTileItem.Frames)
                {
                    comprasMetroTileItems.Add(frame);
                }
                comprasMetroTileItem.Frames.Clear();
                comprasMetroTileItem.Frames.Add(comprasMetroTileItems[0]);

                almacenMetroTileItems = new DevComponents.DotNetBar.Primitives.CustomCollection<DevComponents.DotNetBar.Metro.MetroTileFrame>();
                foreach (DevComponents.DotNetBar.Metro.MetroTileFrame frame in almacenMetroTileItem.Frames)
                {
                    almacenMetroTileItems.Add(frame);
                }
                almacenMetroTileItem.Frames.Clear();
                almacenMetroTileItem.Frames.Add(almacenMetroTileItems[0]);

                CATmetroTileItems = new DevComponents.DotNetBar.Primitives.CustomCollection<DevComponents.DotNetBar.Metro.MetroTileFrame>();
                foreach (DevComponents.DotNetBar.Metro.MetroTileFrame frame in CATmetroTileItem.Frames)
                {
                    CATmetroTileItems.Add(frame);
                }
                CATmetroTileItem.Frames.Clear();
                CATmetroTileItem.Frames.Add(CATmetroTileItems[0]);

                inventarioMetroTileItems = new DevComponents.DotNetBar.Primitives.CustomCollection<DevComponents.DotNetBar.Metro.MetroTileFrame>();
                foreach (DevComponents.DotNetBar.Metro.MetroTileFrame frame in inventarioMetroTileItem.Frames)
                {
                    inventarioMetroTileItems.Add(frame);
                }
                inventarioMetroTileItem.Frames.Clear();
                inventarioMetroTileItem.Frames.Add(inventarioMetroTileItems[0]);

                configuracionMetroTileItems = new DevComponents.DotNetBar.Primitives.CustomCollection<DevComponents.DotNetBar.Metro.MetroTileFrame>();
                foreach (DevComponents.DotNetBar.Metro.MetroTileFrame frame in configuracionMetroTileItem.Frames)
                {
                    configuracionMetroTileItems.Add(frame);
                }
                configuracionMetroTileItem.Frames.Clear();
                configuracionMetroTileItem.Frames.Add(configuracionMetroTileItems[0]);
            }

        }

        private void cargaConfiguraciones()
        {
            //CONFIGURACION DEL SERVIDOR

            SIFModelo.Configuracion.ServidorOracle Servidor = new SIFModelo.Configuracion.ServidorOracle();
            Assembly xAssembly = this.GetType().Assembly;
            string ConfigFile = xAssembly.ManifestModule.Name + ".config";

            if (File.Exists(ConfigFile) == false)
            {
               MessageBox.Show(this, "El archivo de Configuración " + ConfigFile + ", NO existe", "SIF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //System.Windows.Forms.MessageBox.Show("El archivo de Configuración " + ConfigFile + ", NO existe");
                return;
            }

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
            string Oradb = "";
            if (Cad.Length != 0)
            {
                servicio = Cad[0].TrimEnd();
                Oradb = ConfigurationManager.ConnectionStrings[servicio].ConnectionString;

                //AGREGAMOS LA CADENA DE CONEXION PARA DESCOMPONERLA
                Servidor.CadenaConexion = Oradb;

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

                for (int i = 0; i < CadOra.Length; i++)
                {
                    switch (CadOra[i])
                    {
                        case "PROTOCOL":
                            Servidor.Protocolo = CadOra[i + 2];
                            break;
                        case "HOST":
                            Servidor.Host = CadOra[i + 2];
                            break;
                        case "PORT":
                            Servidor.Puerto = int.Parse(CadOra[i + 2]);
                            break;
                        case "SID":
                            Servidor.NombreServicio = CadOra[i + 2];
                            break;
                        case "SERVICE_NAME":
                            Servidor.NombreServicio = CadOra[i + 2];
                            break;
                        default:
                            break;
                    }

                }

                Servidor.TipoConexion = "";

                Servidor.Usuario = CadUsr[1];

                //Servidor.Password = SIFNegocio.Helpers.CryptorEngine.Decrypt(CadPwd[1], true);

                //Para que tome la contraseña literal del .ini

                //#if DEBUG
                //                                Servidor.Password = CadPwd[1];
                //#else
                Servidor.Password = SIFNegocio.Helpers.CryptorEngine.Decrypt(CadPwd[1], true);
                //#endif
                Servidor.CadenaConexion = Servidor.CadenaConexion.Replace(passwordEncriptado, Servidor.Password);// + "max pool size = 1;";
                SIFNegocio.Configuracion.Configuraciones.ServidorOracle = Servidor ;
            }

            //CONFIGURACION DE LA APLICACION
            SIFModelo.Configuracion.Aplicacion configuracion = new SIFModelo.Configuracion.Aplicacion();

            configuracion.SucursalID = int.Parse(ConfigSettings.ReadSetting("SucursalID").ToString());
            configuracion.DirectorioReportes = ConfigSettings.ReadSetting("DirectorioReportes");
            configuracion.DirectorioImagenes = ConfigSettings.ReadSetting("DirectorioImagenes");
            configuracion.DirectorioTemplates = ConfigSettings.ReadSetting("DirectorioPlantillasEmail");
            configuracion.ImpresoraTickets = ConfigSettings.ReadSetting("ImpresoraTickets");
            configuracion.ImpresoraReportes = ConfigSettings.ReadSetting("ImpresoraReportes");

            SIFNegocio.Configuracion.Configuraciones.Aplicacion = configuracion;

            //CONFIGURACION EMAIL
            SIFModelo.Configuracion.Email email = new SIFModelo.Configuracion.Email();

            email.Servidor = ConfigSettings.ReadDBSetting("MailServer");
            email.Puerto = int.Parse(ConfigSettings.ReadDBSetting("MailPort"));
            email.EsSSA = ConfigSettings.ReadDBSetting("MailSSL") == "1" ? true : false;

            email.Usuario = ConfigSettings.ReadDBSetting("MailUser");
            email.Contrasena = SIFNegocio.Helpers.CryptorEngine.Decrypt(ConfigSettings.ReadDBSetting("MailPWD"), true);
            SIFNegocio.Configuracion.Configuraciones.Mail = email;

            //CONFIGURACION TAE
            SIFModelo.Configuracion.TAE tae = new SIFModelo.Configuracion.TAE();
            tae.HostTelcel = ConfigSettings.ReadDBSetting("ConfigHostTelCel");
            //tae.Carriers = new List<string>() { "TELCEL", "MOVISTAR", "UNEFON", "NEXTEL" };
            tae.DirectorioSalida = ConfigSettings.ReadSetting("PathTAESalida");
            tae.PathJava = ConfigSettings.ReadSetting("PathJavaHome");
            //tae.ProductosMovistar = ConfigSettings.ReadSetting("ProdMoviStar");
            //tae.ProductosNextel = ConfigSettings.ReadSetting("ProdMoviStar");//AGREGAR LOS PRODUCTOS
            //tae.ProductosTelcel = ConfigSettings.ReadSetting("ProdTelCel");
            //tae.ProductosUnefon = ConfigSettings.ReadSetting("ProdMoviStar");//AGREGAR LOS PRODUCTOS
            tae.PuertoTelcel = ConfigSettings.ReadDBSetting("ConfigPortTelCel");
            tae.TAEGrupo = ConfigSettings.ReadDBSetting("ConfigGrupoTelCel");
            tae.TimeOutTelcel = ConfigSettings.ReadDBSetting("ConfigTimeTelCel");
            tae.JAR = ConfigSettings.ReadSetting("JarTelCel");
            tae.Encriptacion = ConfigSettings.ReadDBSetting("FraseEncriptacionTelCel");
            tae.DirectorioQuerySalida = ConfigSettings.ReadSetting("PathTAEQuerySalida");

            SIFNegocio.Configuracion.Configuraciones.TAE = tae;



            //CONFIGURACION MULTIRECARGAS
            SIFModelo.Configuracion.MultiRecargas multi = new SIFModelo.Configuracion.MultiRecargas();
            multi.HostTelcel = ConfigSettings.ReadDBSetting("ConfigHostMultiRecargas");
            //tae.Carriers = new List<string>() { "TELCEL", "MOVISTAR", "UNEFON", "NEXTEL" };
            multi.DirectorioSalida = ConfigSettings.ReadSetting("PathSalidaMultiRecargas");
            multi.PathJava = ConfigSettings.ReadSetting("PathJavaHomeMultiRecargas");
            //tae.ProductosMovistar = ConfigSettings.ReadSetting("ProdMoviStar");
            //tae.ProductosNextel = ConfigSettings.ReadSetting("ProdMoviStar");//AGREGAR LOS PRODUCTOS
            //tae.ProductosTelcel = ConfigSettings.ReadSetting("ProdTelCel");
            //tae.ProductosUnefon = ConfigSettings.ReadSetting("ProdMoviStar");//AGREGAR LOS PRODUCTOS
            multi.PuertoTelcel = ConfigSettings.ReadDBSetting("ConfigPortMultiRecargas");
            multi.TAEGrupo = ConfigSettings.ReadDBSetting("ConfigGrupoMultiRecargas");
            multi.TimeOutTelcel = ConfigSettings.ReadDBSetting("ConfigTimeMultiRecargas");
            multi.JAR = ConfigSettings.ReadSetting("JarMultiRecargas");
            multi.Encriptacion = ConfigSettings.ReadDBSetting("FraseEncriptacioMultiRecargas");
            multi.DirectorioQuerySalida = ConfigSettings.ReadSetting("PathMultiRecargasQuerySalida");

            SIFNegocio.Configuracion.Configuraciones.MultiRecargas = multi;


            //CARGA PFIZER
            SIFModelo.Configuracion.Pfizer pfizer = new SIFModelo.Configuracion.Pfizer();
            pfizer.Cadena = int.Parse(ConfigSettings.ReadDBSetting("ConfigpFizerCadena").ToString());
            pfizer.ProgramaID = ConfigSettings.ReadDBSetting("ConfigpFizerPrograma");
            pfizer.Sucursal = int.Parse(ConfigSettings.ReadDBSetting("ConfigpFizerSucursal"));
            pfizer.Usuario = ConfigSettings.ReadDBSetting("ConfigpFizerUsuario");
            SIFNegocio.Configuracion.Configuraciones.Pfizer = pfizer;

            //CARGA NADRO
            SIFModelo.Configuracion.Nadro nadro = new SIFModelo.Configuracion.Nadro();
            nadro.Cadena = ConfigSettings.ReadDBSetting("ConfigNadroCadena").ToString();
            //nadro.ProgramaID = ConfigSettings.ReadSetting("ConfigpFizerPrograma");
            nadro.Sucursal = int.Parse(ConfigSettings.ReadDBSetting("ConfigNadroSucursal"));
            nadro.Usuario = ConfigSettings.ReadDBSetting("ConfigNadroUsr");
            nadro.Contrasena = ConfigSettings.ReadDBSetting("ConfigNadroPwd");
            string urlWSNADROtextBoxX = string.Empty;
            urlWSNADROtextBoxX = ConfigSettings.ReadDBSetting("WSCirculodelaSaludSoap");
            SIFNegocio.Configuracion.Configuraciones.Nadro = nadro;
#if DEBUG
            //nadro.Contrasena = "12345";
            //urlWSNADROtextBoxX = "http://104.210.149.162/nadro_pruebas/WSCirculodelasalud.asmx";
            urlWSNADROtextBoxX = "http://ws.circulodelasalud.mx/";
            nadro.Contrasena = "8EZL076";

#endif
            ConfigSettings.WriteEndPoint("WSCirculodelaSaludSoap", urlWSNADROtextBoxX);
            ConfigurationManager.RefreshSection("appSettings");

            //SIFModelo.Configuracion.Nadro nadro = new SIFModelo.Configuracion.Nadro();

            SIFNegocio.Configuracion.Configuraciones.Nadro = nadro;

            //CARGA CONFIGURACION FEL
            SIFModelo.Configuracion.Factura fel = new SIFModelo.Configuracion.Factura();

            fel.DirectorioFacturas = ConfigSettings.ReadSetting("ConfigFELDirXML");
            fel.PasswordFEL = ConfigSettings.ReadDBSetting("ConfigFELPwd");
            fel.ActividadEmpresarial = ConfigSettings.ReadDBSetting("ConfigFELActividadEmpresarial");
            fel.RFCEmisor = ConfigSettings.ReadDBSetting("ConfigFELRfc");
            fel.TipoPago = ConfigSettings.ReadDBSetting("ConfigFELFormaPago");
            //fel.MetodoDePago = ConfigSettings.ReadDBSetting("ConfigFELMetodoPago");
            fel.UsuarioFEL = ConfigSettings.ReadDBSetting("ConfigFELUser");
            fel.Email = ConfigSettings.ReadDBSetting("ConfigFELEmail");
            fel.PaginaWEB = ConfigSettings.ReadDBSetting("ConfigFELPaginaWeb");
            SIFNegocio.Configuracion.Configuraciones.Factura = fel;
        }



        private void InicializaFuentes()
        {
            //titlelabelX.Font = Helpers.FuentesSIF.FuenteAddCityBoy(35.25f);
            //titlelabelX.ForeColor = StyleManager.MetroColorGeneratorParameters.BaseColor;

        }

        public void ActivaComandos()
        {
            this.ventasMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftV);
            this.ventasMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl1);
            this.comprasMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftC);
            this.comprasMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl2);
            this.almacenMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftA);
            this.almacenMetroTileItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl3);
            this.CATmetroTileItem.Shortcuts.Add(eShortcut.CtrlShiftL);
            this.CATmetroTileItem.Shortcuts.Add(eShortcut.Ctrl4);
            this.inventarioMetroTileItem.Shortcuts.Add(eShortcut.CtrlShiftI);
            this.inventarioMetroTileItem.Shortcuts.Add(eShortcut.Ctrl5);
            this.configuracionMetroTileItem.Shortcuts.Add(eShortcut.CtrlShiftO);
            this.configuracionMetroTileItem.Shortcuts.Add(eShortcut.Ctrl6);

        }

        public void DesactivaComandos()
        {
            this.ventasMetroTileItem.Shortcuts.Clear();
            this.ventasMetroTileItem.Shortcuts.Clear();
            this.comprasMetroTileItem.Shortcuts.Clear();
            this.almacenMetroTileItem.Shortcuts.Clear();
            this.CATmetroTileItem.Shortcuts.Clear();
            this.inventarioMetroTileItem.Shortcuts.Clear();
            this.configuracionMetroTileItem.Shortcuts.Clear();
        }

        View.Ventas.VentaUserControl ventaControl;
        public void NavegaVentas()
        {
            if (ventaControl == null)
            {
                ventaControl = new View.Ventas.VentaUserControl();
                ventaControl.Dock = DockStyle.Fill;
                ventaControl.Owner = this.ventasMenu;
            }

            if (!ventaControl.Mostrado)
            {
                this.DesactivaComandos();
                ShowModalPanel(ventaControl, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                ventaControl.ActivaComandos();
                ventaControl.Mostrado = true;
            }

        }

        #region Navegacion Menu
        View.Menu.CatMenu catMenu;
        private void NavegaMenuCAT()
        {
            if (catMenu == null)
            {
                catMenu = new View.Menu.CatMenu();
                catMenu.Dock = DockStyle.Fill;
                catMenu.Owner = this;
            }
            if (catMenu.Mostrado)
            {
                return;
            }
            this.DesactivaComandos();
            ShowModalPanel(catMenu, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            catMenu.ActivaComandos();
            catMenu.Mostrado = true;
        }

        View.Menu.ComprasMenu comprasMenu;
        private void NavegaMenuCompras()
        {

            if (comprasMenu == null)
            {
                comprasMenu = new View.Menu.ComprasMenu();
                comprasMenu.Dock = DockStyle.Fill;
                comprasMenu.Owner = this;

            }
            if (comprasMenu.Mostrado)
            {
                return;
            }
            this.DesactivaComandos();
            ShowModalPanel(comprasMenu, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            comprasMenu.Mostrado = true;
            comprasMenu.ActivaComandos();
        }

        View.Menu.InventarioMenu inventarioMenu;
        private void NavegaMenuInventario()
        {
            if (inventarioMenu == null)
            {
                inventarioMenu = new View.Menu.InventarioMenu();
                inventarioMenu.Dock = DockStyle.Fill;
                inventarioMenu.Owner = this;
            }
            if (inventarioMenu.Mostrado)
            {
                return;
            }
            this.DesactivaComandos();
            ShowModalPanel(inventarioMenu, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            inventarioMenu.ActivaComandos();
            inventarioMenu.Mostrado = true;
        }

        View.Menu.AlmacenMenu almacenMenu;
        private void NavegaMenuAlmacen()
        {
            if (almacenMenu == null)
            {
                almacenMenu = new View.Menu.AlmacenMenu();
                almacenMenu.Dock = DockStyle.Fill;
                almacenMenu.Owner = this;
            }

            this.DesactivaComandos();
            ShowModalPanel(almacenMenu, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            almacenMenu.ActivaComandos();
        }

        View.Menu.ConfiguracionMenu configuracionMenu;
        private void NavegaMenuConfiguracion()
        {
            if (configuracionMenu == null)
            {
                configuracionMenu = new View.Menu.ConfiguracionMenu();
                configuracionMenu.Dock = DockStyle.Fill;
                configuracionMenu.Owner = this;
            }

            this.DesactivaComandos();
            ShowModalPanel(configuracionMenu, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            configuracionMenu.ActivaComandos();
        }

        View.Menu.VentasMenu ventasMenu;
        private void NavegaMenuVentas()
        {
            if (ventasMenu == null)
            {
                ventasMenu = new View.Menu.VentasMenu();
                ventasMenu.Dock = DockStyle.Fill;
                ventasMenu.Owner = this;
            }

            this.DesactivaComandos();

            if (!ventasMenu.Mostrado)
            {
                ShowModalPanel(ventasMenu, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                ventasMenu.ActivaComandos();
            }
        }
        View.Menu.gestionAdministrativaMenu gAmenu;      
        private void NavegaReportes()
        {
            if (gAmenu == null)
            {
                gAmenu = new View.Menu.gestionAdministrativaMenu();
                gAmenu.Dock = DockStyle.Fill;
                gAmenu.Owner = this;

            }
            if (gAmenu.Mostrado)
            {
                return;
            }
            this.DesactivaComandos();
            ShowModalPanel(gAmenu, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            gAmenu.Mostrado = true;
            gAmenu.ActivaComandos();



            /*
            View.Reportes.ReportesAdmin nvf = new View.Reportes.ReportesAdmin();
            nvf.ShowDialog();*/

            //View.Documentacion.Documentacion frm = new View.Documentacion.Documentacion();
            //frm.ShowDialog();


        }

        View.Comercializacion.Comercializacion gComercializacion;
        private void NavegaComercializacion()
        {
            if (gComercializacion == null)
            {
                gComercializacion = new View.Comercializacion.Comercializacion();
                gComercializacion.Dock = DockStyle.Fill;
                //gComercializacion.Owner = this;

            }
            if (gComercializacion.Mostrado)
            {
                return;
            }
            this.DesactivaComandos();
            ShowModalPanel(gComercializacion, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            gComercializacion.Mostrado = true;
            gComercializacion.ActivaComandos();
        }
        public void Salir()
        {
            DialogResult result =MessageBox.Show("¿Desea cerrar la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
                this.Close();
            SIF.funciones.Bitacora("Cierra Sesion", 81, 36);
        }
        #endregion

        private void OnLoaded(object sender, EventArgs args)
        {
            Application.Idle -= new EventHandler(OnLoaded);

            //REVISAMOS SI HAY CONFIGURACION
            this.cargaConfiguraciones();
            if (string.IsNullOrEmpty(SIFNegocio.Configuracion.Configuraciones.ServidorOracle.Host))
            {
               MessageBox.Show("Configure la conexión al servidor de base de datos");

                View.ConfiguracionForm frmConfiguracion = new View.ConfiguracionForm();
                frmConfiguracion.configuracionTabControl.SelectedTabIndex = 1;
                frmConfiguracion.ShowDialog();
                //this.cargaConfiguraciones();
            }

            //ASIGNAMOS LA CADENA DE CONEXION A LOS DATOS

            //MOSTRAMOS EL DIALOGO DE CONEXION
            if (frmLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
                return;
            }
            string local = Directory.GetCurrentDirectory();
            string mLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            DateTime ss = new DateTime();
            ss = File.GetLastWriteTime(mLocation);
            this.Enabled = true;
            this.activaAnimaciones(true);
            Privilegios();
            SIF.funciones.Bitacora("Inicia Sesion", 81, 35);
            //this.sucursalLabel.Text = "Sucursal: " + Helpers.Sesion.Sucursal;
            this.apellidosLabel.Text = Helpers.Sesion.Usuario.Apellidos;
            this.nombreUsuarioLabel.Text = Helpers.Sesion.Usuario.Nombre;
            this.fotoPictureBox.Image = Helpers.Sesion.Foto;

            SIFModelo.Sucursal sucursalM = new SIFNegocio.Sucursales().SucursalPorID(SIFNegocio.Configuracion.Configuraciones.Aplicacion.SucursalID);
            Helpers.Sesion.Sucursal = sucursalM;
            SIFNegocio.Helpers.Sesion.Sucursal = sucursalM;
            this.sucursalLabel.Text = Helpers.Sesion.Sucursal.Nombre;
            this.VersionLabel.Text = " Version:" + ss.ToString() + " " + this.nombreVersion;
            if (SIF.Helpers.Sesion.Usuario.TipoUsuario == SIFModelo.Tipos.TipoUsuario.ADMINISTRATIVO || SIF.Helpers.Sesion.Usuario.TipoUsuario == SIFModelo.Tipos.TipoUsuario.SUPERVISOR)
            {
                this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
                this.ReportesMetroTileItem
            });
            }
            this.ventasMetroTileItem.Focus();

            #region Transmision por API
#if !DEBUG


            
            SIFNegocio.EpGo.TestServiceEpGO servicio = new SIFNegocio.EpGo.TestServiceEpGO();


            if (SIFNegocio.EpGo.NegocioConfiguracionEpGo
               .ParametroActivo > 0)
            {
                bool estaConectado = System.Threading.Tasks.Task.Run(() => servicio.TestConectividadAll()).Result;
                // 3. Resultado
                if (estaConectado)
                {
                    SIFNegocio.LoggerHelper.Info("\n[EXITO:2601231207] Conexión establecida con el servicio Go.");
                }
                else
                {
                    SIFNegocio.LoggerHelper.Error("\n[ERROR:2601231207] No se pudo conectar al servicio.");
                }
            }
#endif
            #endregion
            //this.ActiveControl = this.metroTilePanel;
            // TODO: add relevant code here
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Enabled = false;

            // Add metro color themes
            MetroColorGeneratorParameters[] metroThemes = MetroColorGeneratorParameters.GetAllPredefinedThemes();
            foreach (MetroColorGeneratorParameters mt in metroThemes)
            {
                ButtonItem theme = new ButtonItem(mt.ThemeName, mt.ThemeName);
                theme.Command = new Command();
                theme.CommandParameter = mt;
                theme.Click += new EventHandler(this.btnColorTheme_Click);
                btnColorTheme.SubItems.Add(theme);
            }

            base.OnLoad(e);

            Application.Idle += new EventHandler(OnLoaded);
        }


        private void ventasMetroTileItem_Click(object sender, EventArgs e)
        {
            this.NavegaMenuVentas();
        }

        private void salirButtonItem_Click(object sender, EventArgs e)
        {
            this.Salir();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.sb_LblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnColorTheme_Click(object sender, EventArgs e)
        {
            MetroColorGeneratorParameters theme = (MetroColorGeneratorParameters)((ButtonItem)sender).CommandParameter;
            StyleManager.MetroColorGeneratorParameters = theme;
        }

        private void CATmetroTileItem_Click(object sender, EventArgs e)
        {
            this.NavegaMenuCAT();
        }

        private void comprasMetroTileItem_Click(object sender, EventArgs e)
        {
            this.NavegaMenuCompras();
        }

        private void inventarioMetroTileItem_Click(object sender, EventArgs e)
        {
            this.NavegaMenuInventario();
        }

        private void almacenMetroTileItem_Click(object sender, EventArgs e)
        {
            NavegaMenuAlmacen();
        }

        private void configuracionMetroTileItem_Click(object sender, EventArgs e)
        {
            NavegaMenuConfiguracion();
        }

        private void ventasMetroTileItem_DoubleClick(object sender, EventArgs e)
        {

        }

        private void metroShell1_SettingsButtonClick(object sender, EventArgs e)
        {

            View.ConfiguracionForm frmConfiguracion = new View.ConfiguracionForm();
            frmConfiguracion.ShowDialog();
        }

        private void metroShell1_Click(object sender, EventArgs e)
        {

        }

        private void metroShell1_HelpButtonClick(object sender, EventArgs e)
        {
           MessageBox.Show("v.080713");
        }

        private void ReportesMetroTileItem_Click(object sender, EventArgs e)
        {
            this.NavegaReportes();
        }

        private void comercializacionMetroTileItem_Click(object sender, EventArgs e)
        {
            //SIF.View.Comercializacion.Comercializacion comer = new SIF.View.Comercializacion.Comercializacion();
            //comer.Dock = DockStyle.Fill;
            ////comer.Owner = this;
            //comer.Muestra();

            this.NavegaComercializacion();
        }
    }
}