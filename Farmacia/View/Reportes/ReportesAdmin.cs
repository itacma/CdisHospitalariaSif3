using CrashReporterDotNET;
using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Reportes
{
    public partial class ReportesAdmin :  DevComponents.DotNetBar.Metro.MetroAppForm
    {
        bool ScriptCreate = false;
        List<SIFModelo.ReportesAdmin.reportesUsuarios> P_reportesList = new List<SIFModelo.ReportesAdmin.reportesUsuarios>();
        public ReportesAdmin()
        {
            InitializeComponent();
            cargaOpcionesRPTtipo();

            lblFechaFin.Visible = false;
            lblFechaInicio.Visible = false;
            dateTimeInput1.Visible = false;
            dateTimeInput2.Visible = false;

        }

        private void cargaOpcionesRPT(string tipoReporte)
        {

            List<SIFModelo.ReportesAdmin.reportesUsuarios> reportesList =
                                            P_reportesList
                                                .Where(x => x.tipo_reporte == tipoReporte
                                                ).ToList();


            

            if (reportesList == null)
            {
                reportesList = new List<SIFModelo.ReportesAdmin.reportesUsuarios>();
            }

            if (reportesList.Count > 0)
            {
                this.reportesComboBoxEx.DataSource = reportesList;

                reportesComboBoxEx.ValueMember = "id";
                reportesComboBoxEx.DisplayMember = "Nombre";
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

        private void examinarTemplatesMailButtonX_Click(object sender, EventArgs e)
        {
            this.examinaDirectorioMailTemplates();
        }
        private void CerrarButtonX_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void guardarButtonX_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (directorioTemplatesMailtextBox.Text.Length <= 0) {
                    MessageBox.Show("Seleccione el directorio de destino", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (NombreArchivoTemplatesMailtextBox.Text.Length <= 0)
                {
                    MessageBox.Show("Asigne un nombre a archivo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }

                string fullPath = directorioTemplatesMailtextBox.Text + @"\" + NombreArchivoTemplatesMailtextBox.Text + ".txt";
                SIFModelo.ReportesAdmin.reportesUsuarios datos =
                 
                  this.reportesComboBoxEx.SelectedItem as SIFModelo.ReportesAdmin.reportesUsuarios;


                if (datos.requiereFechas == "S")
                {

                    datos.param1 = dateTimeInput1.Value.ToString("dd/MM/yyyy HH:mm:ss");
                    datos.param2 = dateTimeInput2.Value.ToString("dd/MM/yyyy HH:mm:ss");

                }




                 List<String> reportesList = new List<string>();

                String _string;
                DataTable dt = new DataTable();
                //SIFModelo.Sucursal sucursal = ((ObjectView<SIFModelo.Sucursal>)this.sucursalComboBoxEx.SelectedItem).Object as SIFModelo.Sucursal;

                //if (!ScriptCreate)
                //{
                //    reportesList = new SIFNegocio.ReportesAdmin.ReportesV1().GetReportesResult(datos.nombre);
                //}
                //else {
                //    if (!string.IsNullOrEmpty(datos.param1) && !string.IsNullOrEmpty(datos.param2))
                //    {


                //         dt =new SIFNegocio.ReportesAdmin.ReportesV1().GetDataTable(datos);


                //    }
                //}
                dt = new SIFNegocio.ReportesAdmin.ReportesV1().GetDataTable(datos);
                if ( dt.Rows.Count>0){

                    string _ip = string.Empty ;
                    var host = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (var ip in host.AddressList)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            _ip= ip.ToString();

                        }
                    }

                    SIFModelo.Sif3BitacoraSucesos Q = new SIFModelo.Sif3BitacoraSucesos();

                    Q.Usuario = SIF.Helpers.Sesion.Usuario.UsuariosID.ToString();
                    Q.Proceso = "SIF_EXPORT";
                    Q.Referencia = datos.nombre;
                    Q.Mensaje = "El usuario " + Environment.MachineName.ToString() + "Exporto el informe "+ datos.nombre + " IP:"+ _ip;
                    Q.Articuloid = " ";
                    Q.Cantidad = 0;
                    string result = new SIFNegocio.ReportesAdmin.ReportesV1().spInsSif3BitacoraSucesos(Q);
                    if (result == "1:OK")
                    {
                       
                    }
                    else
                    {
                        MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                
                }

                using (StreamWriter writer = new StreamWriter(fullPath))
                {
                    writer.WriteLine(datos.colums_name);
                    
                    //if (reportesList.Count > 0) 
                    //{
                    //    foreach (String s in reportesList)
                    //    {
                    //        writer.WriteLine(s);
                    //    }
                    //}

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow R in dt.Rows)
                        {
                            writer.WriteLine(R[0].ToString());
                        }
                    }

                }
                MessageBox.Show("Reporte Exportado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Current = Cursors.Default;




                // Read a file  

                //string readText = File.ReadAllText(fullPath);
            }
            catch(Exception xe ) {
                MessageBox.Show(xe.ToString());
            }
            //Console.WriteLine(readText);
        }

        private void reportesComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {


            SIFModelo.ReportesAdmin.reportesUsuarios datos =
             this.reportesComboBoxEx.SelectedItem as SIFModelo.ReportesAdmin.reportesUsuarios;
            richTextBox1.Text = datos.q_desc;
            if (datos.requiereFechas == "S")
            {
                dateTimeInput1.Value = DateTime.Now;
                dateTimeInput2.Value = DateTime.Now;

                lblFechaFin.Visible = true;
                lblFechaInicio.Visible = true;
                dateTimeInput1.Visible = true;
                dateTimeInput2.Visible = true;
                //ScriptCreate = true;
            }
            else
            {
                lblFechaFin.Visible = false;
                lblFechaInicio.Visible = false;
                dateTimeInput1.Visible = false;
                dateTimeInput2.Visible = false;
               // ScriptCreate = false;
            }


            

        }

        private void tipoReporteComboBoxEx_SelectedValueChanged(object sender, EventArgs e)
        {

           
           /* SIFModelo.ReportesAdmin.reportesUsuarios datosTipo =

                 this.tipoReporteComboBoxEx.SelectedItem as SIFModelo.ReportesAdmin.reportesUsuarios;
           */
            cargaOpcionesRPT(tipoReporteComboBoxEx.Text);

        }

        private void cargaOpcionesRPTtipo() {
             P_reportesList = new SIFNegocio.ReportesAdmin.ReportesV1().GetReportesCmb(System.Convert.ToChar(SIF.Helpers.Sesion.Usuario.TipoUsuario).ToString());

            if (P_reportesList == null)
            {
                P_reportesList = new List<SIFModelo.ReportesAdmin.reportesUsuarios>();
            }

            List<string> lista = P_reportesList.Select(o => o.tipo_reporte).Distinct().ToList();

            if (lista.Count > 0)
            {
                this.tipoReporteComboBoxEx.DataSource = lista;

                //tipoReporteComboBoxEx.ValueMember = "id";
                cargaOpcionesRPT(tipoReporteComboBoxEx.Text);
            }

        }
        /*


private void CreaScript(string param ) 
{

   SIFModelo.ReportesAdmin.reportesUsuarios datos =
        this.reportesComboBoxEx.SelectedItem as SIFModelo.ReportesAdmin.reportesUsuarios;
   if (param == "FECHAS"){ 


   }

}*/
    }
}
