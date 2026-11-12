using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using DevComponents.DotNetBar;

namespace SIF.View.Ventas
{
   
    public partial class Cliente18Form : DevComponents.DotNetBar.Metro.MetroForm
    {
        public string nombre="",numeror="",siniestro ="",autorizacion ="";
        public int   clienter=0;
        DateTime fecha_rem;
        public Cliente18Form(SIFModelo.RemisionDetalle detalle)
        {
            InitializeComponent();

            
        }
        public Cliente18Form(string remision,int cliente,DateTime fecha)
        {
            numeror = remision;
            clienter = cliente;
            InitializeComponent();
            this.Focus();

        }

        private void AsignaCantidades()
        {
            nombre = this.textBoxNombre.Text;
            siniestro = this.textBoxSiniestro.Text;
            //autorizacion = this.textBoxAtuorizacion.Text;
            autorizacion = " ";
        }

      

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            
            AsignaCantidades();
           string sentencia = "INSERT INTO CLIENTE_ESPECIAL(NUM_REMISION,CLIENTE_ID,NOMBRE_ASEGURADO,NO_SINIESTRO,NO_AUTORIZACION) VALUES ('"+numeror+"','"+clienter+"','"+nombre+"','"+siniestro+"','"+autorizacion+"')";
            using (OracleConnection cnx = new OracleConnection(SIFNegocio.Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                       MessageBox.Show("Error:"+ex.Message);
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }
                }
            }


            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
            
        }

        private void CancelarButtonX_Click(object sender, EventArgs e)
        {
            //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //this.Close();
        }

        }
}
