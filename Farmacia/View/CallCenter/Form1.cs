using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.CallCenter
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {


        public class suc { 
            public string nombre { get; set; }
            public string cnx { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
            this.cargaSucursales();
        }

        List<suc> lisutaS = new List<suc>();
        private void cargaSucursales() {
            suc suc1 = new suc();
            suc1.nombre = "MATRIZ";
            suc1.cnx = "Data Source =(DESCRIPTION =  (ADDRESS_LIST =    (ADDRESS = (PROTOCOL = TCP) (HOST = siff)          (PORT = 1521))   )    (CONNECT_DATA =      (SID = FARMACIA)   )  );User Id=FARMACIA;Password=OPERADOR;";

            suc suc2 = new suc();
            suc2.nombre = "CU";
            suc2.cnx = "Data Source =(DESCRIPTION =  (ADDRESS_LIST =    (ADDRESS = (PROTOCOL = TCP) (HOST = 148.228.105.11) (PORT = 8080))  )    (CONNECT_DATA =      (SID = F9S3)       )  );User Id=FARMACIA;Password=f9s3=;";

            suc suc3 = new suc();
            suc3.nombre = "TECAMACHALCO";
            suc3.cnx = "Data Source =(DESCRIPTION =  (ADDRESS_LIST =    (ADDRESS = (PROTOCOL = TCP) (HOST = 148.228.236.70) (PORT = 1521))  )    (CONNECT_DATA =      (SID = F5S3)       )  );User Id=FARMACIA;Password=FAFL05;";


            suc suc4 = new suc();
            suc4.nombre = "GOBIERNO";
            suc4.cnx = "Data Source =(DESCRIPTION =  (ADDRESS_LIST =    (ADDRESS = (PROTOCOL = TCP) (HOST = 172.19.24.6) (PORT = 1521)) )    (CONNECT_DATA =      (SID = F19S3)      )  );User Id=farmacia;Password=FAFL19;";

            lisutaS.Add(suc1);
            lisutaS.Add(suc2);
            lisutaS.Add(suc3);

            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = lisutaS;
            comboBox1.DataSource = bindingSource1.DataSource;
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "nombre";

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string cadenaN = SIFNegocio.Configuracion.Configuraciones.ServidorOracle.CadenaConexion;

            string respuesta = string.Empty;
            try
            {
                string cnx = (comboBox1.SelectedItem as suc).cnx;
                SIFNegocio.Configuracion.Configuraciones.ServidorOracle.CadenaConexion = cnx;
                SIFNegocio.Cotizacion sc = new SIFNegocio.Cotizacion();
                respuesta = sc.CreaCotizacionDeremision(textBox1.Text, "P", cnx);
                string ss = respuesta.Substring(0, 5);
                if (ss != "1: OK" && ss != "0: OK")
                {
                    respuesta += Environment.NewLine + "COMUNIQUE AL DEPARTAMENTO DE SISTEMAS";
                    MessageBox.Show(respuesta);
                }
                else
                {

                    if (ss == "1: OK")
                    {
                        String Parm1 = "{COTIZACION.NUM_COTIZACION}='" + respuesta.Split('|')[1] + "' AND {DIR_CLIENTES.TIPO_DIR}='FI'";
                        SIFNegocio.Usuarios Logusu = new SIFNegocio.Usuarios();
                     //   SIFModelo.Usuario Vend = Logusu.UsuarioPorId(Convert.ToInt16(respuesta.Split('|')[2].ToString()));
                        SIFModelo.Usuario Vend = Logusu.UsuarioPorId_cnx(Convert.ToInt16(respuesta.Split('|')[2].ToString()), cnx);
                        SIF.View.Reportes.frmImpresion Impresion = new SIF.View.Reportes.frmImpresion("RPT_Cotizaciones.rpt", Parm1, Vend.Nombre + ' ' + Vend.Apellidos);
                        Impresion.ShowDialog();




                    }
                }
            }
            catch (Exception ext)
            {
                respuesta = ext.ToString();
                MessageBox.Show(respuesta);
            }

              SIFNegocio.Configuracion.Configuraciones.ServidorOracle.CadenaConexion= cadenaN;

        }
    }
}
