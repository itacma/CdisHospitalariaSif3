using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;




namespace SIF.View.Extras
{
    public partial class ProgresoExpImpFileExcel : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        DataTable dt = new DataTable();
        string file = string.Empty;

      
        public ProgresoExpImpFileExcel( DataTable pdt , string namePahtFile)
        {
            
            InitializeComponent();
            dt = pdt;
            file = namePahtFile;
            progressBar1.Value = 0;
            progressBar1.Maximum = dt.Rows.Count;
        }

        private void Progreso_Load(object sender, EventArgs e)
        {

            //if (ExportarBackgroundWorker.IsBusy != true)
            //{

            //    ExportarBackgroundWorker.RunWorkerAsync();
            //}
            comboBox1.Items.Add("Excel(*.xls) | *.xls");
            comboBox1.Items.Add("CSV Files (*.csv)|*.csv");
            

        }

        private void ExportarBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            //if (comboBox1.Text == "Excel(*.xls) | *.xls")
            //{
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();

                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    hoja_trabajo.Cells[1, i + 1] = dt.Columns[i].ColumnName.ToString();
                }


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        DataRow rd = dt.Rows[i];
                        if (j == 0)
                            hoja_trabajo.Cells[i + 2, j + 1].NumberFormat = "@";

                        hoja_trabajo.Cells[i + 2, j + 1] = rd[j].ToString();

                    }
                    if (ExportarBackgroundWorker.CancellationPending == true)
                    {



                        e.Cancel = true;
                        break;
                    }
                    //Thread.Sleep(10);
                    ExportarBackgroundWorker.ReportProgress(i);
                }


                libros_trabajo.SaveAs(file, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            //}
            //else if (comboBox1.Text == "CSV Files (*.csv)|*.csv") {
            //    StreamWriter sw = new StreamWriter(file, false);
            //    //headers    
            //    for (int i = 0; i < dt.Columns.Count; i++)
            //    {
            //        sw.Write(dt.Columns[i]);
            //        if (i < dt.Columns.Count - 1)
            //        {
            //            sw.Write(",");
            //        }
            //    }
            //    sw.Write(sw.NewLine);
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        for (int i = 0; i < dt.Columns.Count; i++)
            //        {
            //            if (!Convert.IsDBNull(dr[i]))
            //            {
            //                string value = dr[i].ToString();
            //                if (value.Contains(','))
            //                {
            //                    value = String.Format("\"{0}\"", value);
            //                    sw.Write(value);
            //                }
            //                else
            //                {
            //                    sw.Write(dr[i].ToString());
            //                }
            //            }
            //            if (i < dt.Columns.Count - 1)
            //            {
            //                sw.Write(",");
            //            }
            //        }
            //        sw.Write(sw.NewLine);
            //    }
            //    sw.Close();

            //}
            //else { 
            
            //}


        }


       
         
        

        private void ExportarBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void ExportarBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true) {
               MessageBox.Show("Se  Cancelo la operacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else if (e.Error!= null) {
               MessageBox.Show("Ocurrio un error", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
               MessageBox.Show("Fin de la exportacion","Informacion", MessageBoxButtons.OK,MessageBoxIcon.Information);
                
            }
            this.Close();
        }
        //DataRow rd;
        //int _i=0;
  
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(file)) {
               MessageBox.Show("Seleccione el archivo de destino", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ExportarBackgroundWorker.IsBusy != true)
            {

                ExportarBackgroundWorker.RunWorkerAsync();
            }

              
          


          
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if( ExportarBackgroundWorker.IsBusy==true)
            ExportarBackgroundWorker.CancelAsync();
            this.Close();
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void examinarDirectorio_Click(object sender, EventArgs e)
        {
            this.examinaDirectorioReportes();
        }


        private void examinaDirectorioReportes()
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls|CSV Files (*.csv)|*.csv";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                file = fichero.FileName;
            }
       }
    }
}
