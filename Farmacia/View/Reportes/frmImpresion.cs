using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using CrystalDecisions.Windows.Forms;

namespace SIF.View.Reportes
{
    public partial class frmImpresion : DevComponents.DotNetBar.Metro.MetroForm
    {
        public string Reporte { get; set; }
        public string Param1 { get; set; }
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public Dictionary<string, object> parameters { get; set; }


        ReportDocument rd = new ReportDocument();
        private static string BD = "SIF";


        private void ConfigureCrystalReports()
        {
            //this.crViewer.ShowGroupTreeButton = false;
            //this.crViewer.ShowGroupTree();
            HideTreeGroupBox(true);
            try
            {
                SIFModelo.Configuracion.Aplicacion configuracion = new SIFModelo.Configuracion.Aplicacion();
                SIFModelo.Configuracion.ServidorOracle servidor = new SIFModelo.Configuracion.ServidorOracle();

                string OraGAC = SIFNegocio.Configuracion.Configuraciones.ServidorOracle.CadenaConexion;
                string Srv = OraGAC.Split(';')[0].Replace("Data Source =", string.Empty); // .Split('=')[1]; 
                string User = OraGAC.Split(';')[1].Split('=')[1];
                string Pwd = OraGAC.Split(';')[2].Split('=')[1];

                configuracion.DirectorioReportes = SIFNegocio.Configuracion.Configuraciones.Aplicacion.DirectorioReportes;

                // Set Report
                rd.Load(configuracion.DirectorioReportes + @"\" + @Reporte);
                //Set the actual database location, assumes that you are using only one database in the report

                rd.DataSourceConnections[0].SetConnection(Srv, BD, User, Pwd);

                // Set Report Titles
                rd.SummaryInfo.ReportAuthor = Autor;
                rd.SummaryInfo.ReportComments = "Alexander Fleming";
                rd.SummaryInfo.ReportTitle = Titulo;
                //rd.SELE
                // Set Crystal Report Viewer Properties
                crViewer.ShowCloseButton = false;
                //crViewer.ShowCopyButton = false;
                //crViewer.ShowExportButton = false;
                crViewer.ShowLogo = false;
                crViewer.ShowParameterPanelButton = false;
                crViewer.ShowPrintButton = true;

                //rd.SetParameterValue("SUCURSAL", SIF.Helpers.Sesion.Sucursal.Nombre);  
                if (parameters != null && parameters.Count > 0)
                {
                    foreach (var p in parameters)
                    {
                        rd.SetParameterValue(p.Key, p.Value);
                    }
                }
                else
                {
                    //if (string.IsNullOrEmpty(seleccion))
                    //{
                    //    rd.SetSQLCommandTable( ,"",seleccion);
                    //}
                    //else
                    //{
                    crViewer.SelectionFormula = Param1;
                    //}
                }

                crViewer.ReportSource = rd;
            }
            catch(Exception x)
            {
               MessageBox.Show("Debe configurar la carpeta de reportes ", "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureCrystalReports(DataSet ds)
        {
            //this.crViewer.ShowGroupTreeButton = false;
            //this.crViewer.ShowGroupTree();
            HideTreeGroupBox(true);
            try
            {
                SIFModelo.Configuracion.Aplicacion configuracion = new SIFModelo.Configuracion.Aplicacion();
                SIFModelo.Configuracion.ServidorOracle servidor = new SIFModelo.Configuracion.ServidorOracle();

                string OraGAC = SIFNegocio.Configuracion.Configuraciones.ServidorOracle.CadenaConexion;
                string Srv = OraGAC.Split(';')[0].Replace("Data Source =", string.Empty); // .Split('=')[1]; 
                string User = OraGAC.Split(';')[1].Split('=')[1];
                string Pwd = OraGAC.Split(';')[2].Split('=')[1]; ;

                configuracion.DirectorioReportes = SIFNegocio.Configuracion.Configuraciones.Aplicacion.DirectorioReportes;

                // Set Report

                rd.Load(configuracion.DirectorioReportes + @"\" + @Reporte);

                rd.SetDataSource(ds);

                if (parameters != null && parameters.Count > 0)
                {
                    foreach (var p in parameters)
                    {
                        rd.SetParameterValue(p.Key, p.Value);
                        //rd.ParameterFields.Add(p.Key, CrystalDecisions.Shared.ParameterValueKind.StringParameter, CrystalDecisions.Shared.DiscreteOrRangeKind.DiscreteValue);

                    }
                }

                //Set the actual database location, assumes that you are using only one database in the report

                //rd.DataSourceConnections[0].SetConnection(Srv, BD, User, Pwd);

                // Set Report Titles
                rd.SummaryInfo.ReportAuthor = Autor;
                rd.SummaryInfo.ReportComments = "Alexander Fleming";
                rd.SummaryInfo.ReportTitle = Titulo;
                //rd.SELE
                // Set Crystal Report Viewer Properties
                crViewer.ShowCloseButton = false;
                //crViewer.ShowCopyButton = false;
                //crViewer.ShowExportButton = false;
                crViewer.ShowLogo = false;
                crViewer.ShowParameterPanelButton = false;
                crViewer.ShowPrintButton = true;
                
                crViewer.ReportSource = rd;
            }
            catch
            {
               MessageBox.Show("Debe configurar la carpeta de reportes ", "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureCrystalReports(Boolean parametroYcondicion)
        {
            //this.crViewer.ShowGroupTreeButton = false;
            //this.crViewer.ShowGroupTree();
            HideTreeGroupBox(true);
            try
            {
                SIFModelo.Configuracion.Aplicacion configuracion = new SIFModelo.Configuracion.Aplicacion();
                SIFModelo.Configuracion.ServidorOracle servidor = new SIFModelo.Configuracion.ServidorOracle();

                string OraGAC = SIFNegocio.Configuracion.Configuraciones.ServidorOracle.CadenaConexion;
                string Srv = OraGAC.Split(';')[0].Replace("Data Source =", string.Empty); // .Split('=')[1]; 
                string User = OraGAC.Split(';')[1].Split('=')[1];
                string Pwd = OraGAC.Split(';')[2].Split('=')[1]; ;

                configuracion.DirectorioReportes = SIFNegocio.Configuracion.Configuraciones.Aplicacion.DirectorioReportes;

                // Set Report
                rd.Load(configuracion.DirectorioReportes + @"\" + @Reporte);
                //Set the actual database location, assumes that you are using only one database in the report

                rd.DataSourceConnections[0].SetConnection(Srv, BD, User, Pwd);

                // Set Report Titles
                rd.SummaryInfo.ReportAuthor = Autor;
                rd.SummaryInfo.ReportComments = "Alexander Fleming";
                rd.SummaryInfo.ReportTitle = Titulo;
                //rd.SELE
                // Set Crystal Report Viewer Properties
                crViewer.ShowCloseButton = false;
                //crViewer.ShowCopyButton = false;
                //crViewer.ShowExportButton = false;
                crViewer.ShowLogo = false;
                crViewer.ShowParameterPanelButton = false;
                crViewer.ShowPrintButton = true;

                //rd.SetParameterValue("SUCURSAL", SIF.Helpers.Sesion.Sucursal.Nombre);  
                if (parameters != null && parameters.Count > 0)
                {
                    foreach (var p in parameters)
                    {
                        rd.SetParameterValue(p.Key, p.Value);
                    }
                }
                
                crViewer.SelectionFormula = Param1;

                crViewer.ReportSource = rd;
            }
            catch (Exception x)
            {
               MessageBox.Show("Debe configurar la carpeta de reportes ", "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void     HideTreeGroupBox(bool esOculto)
        {
            System.Windows.Forms.Control control = null;
            for (int i = 0; i < crViewer.Controls.Count; i++)
            {
                control = crViewer.Controls[i];
                if (control is ReportGroupTree)
                {  //Hide the Group tree by default.
                    control.Visible = !esOculto;
                    continue;
                }
            }
        }

        string seleccion = "";

        public frmImpresion()
        {
            InitializeComponent();
            ConfigureCrystalReports();
        }

        public frmImpresion(string strReporte, string strParam, Dictionary<string, object> parametros = null, string seleccion = null)
        {
            this.seleccion = seleccion;
            this.parameters = parametros;
            Reporte = @strReporte;
            Param1 = @strParam;
            InitializeComponent();
            ConfigureCrystalReports(true);
        }

        public frmImpresion(string strReporte)
        {
            //this.seleccion = seleccion;
            //this.parameters = parametros;
            Reporte = @strReporte;
            //Param1 = @strParam;
            InitializeComponent();
            ConfigureCrystalReports();
        }

        public frmImpresion(string strReporte, DataSet dt, Dictionary<string, object> parametros = null)
        {
            InitializeComponent();
            dts = dt;
            this.parameters = parametros;
            this.Reporte = strReporte;
            ConfigureCrystalReports(dts);
        }

        DataSet dts = null;

        public frmImpresion(string strReporte, string strParam, string strAutor, string titulo = "")
        {
            Reporte = @strReporte;
            Param1 = @strParam;
            Autor = strAutor;
            this.Titulo = titulo;
            InitializeComponent();
            ConfigureCrystalReports();
        }

        private void frmImpresion_FormClosed(object sender, FormClosedEventArgs e)
        {
            rd.Close();
        }

        private   void ConfigureCrystalReportsDirecto()
        {
            //this.crViewer.ShowGroupTreeButton = false;
            //this.crViewer.ShowGroupTree();

     

           // HideTreeGroupBox(true);
            try
            {
                SIFModelo.Configuracion.Aplicacion configuracion = new SIFModelo.Configuracion.Aplicacion();
                SIFModelo.Configuracion.ServidorOracle servidor = new SIFModelo.Configuracion.ServidorOracle();

                string OraGAC = SIFNegocio.Configuracion.Configuraciones.ServidorOracle.CadenaConexion;
                string Srv = OraGAC.Split(';')[0].Replace("Data Source =", string.Empty); // .Split('=')[1]; 
                string User = OraGAC.Split(';')[1].Split('=')[1];
                string Pwd = OraGAC.Split(';')[2].Split('=')[1]; ;

                configuracion.DirectorioReportes = SIFNegocio.Configuracion.Configuraciones.Aplicacion.DirectorioReportes;

                // Set Report
                rd.Load(configuracion.DirectorioReportes + @"\" + @Reporte);
                //Set the actual database location, assumes that you are using only one database in the report

                if (parameters != null && parameters.Count > 0)
                {
                    foreach (var p in parameters)
                    {
                        rd.SetParameterValue(p.Key, p.Value);
                    }
                }

                rd.DataSourceConnections[0].SetConnection(Srv, BD, User, Pwd);

                // Set Report Titles
                rd.SummaryInfo.ReportAuthor = Autor;
                rd.SummaryInfo.ReportComments = "Alexander Fleming";
                rd.SummaryInfo.ReportTitle = Titulo;
                //rd.SELE
                // Set Crystal Report Viewer Properties
                rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                rd.PrintToPrinter(1, false, 0, 0);

                //crViewer.ShowCloseButton = false;
                ////crViewer.ShowCopyButton = false;
                ////crViewer.ShowExportButton = false;
                //crViewer.ShowLogo = false;
                //crViewer.ShowParameterPanelButton = false;
                //crViewer.ShowPrintButton = true;

                ////rd.SetParameterValue("SUCURSAL", SIF.Helpers.Sesion.Sucursal.Nombre);  
            

                //crViewer.SelectionFormula = Param1;

                //crViewer.ReportSource = rd;
            }
            catch (Exception x)
            {
               MessageBox.Show("Debe configurar la carpeta de reportes ", "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public frmImpresion(string strReporte, string strParam,bool esDirecto, Dictionary<string, object> parametros = null)
        {
            this.seleccion = seleccion;
            this.parameters = parametros;
            Reporte = @strReporte;
            Param1 = @strParam;
            //InitializeComponent();
            //ConfigureCrystalReports(true);
            ConfigureCrystalReportsDirecto();
        }

    }
}