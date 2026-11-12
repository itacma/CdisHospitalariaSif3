using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Ventas
{
    public partial class DatosDerechohabiente : DevComponents.DotNetBar.Metro.MetroForm
    {
        public DatosDerechohabiente()
        {
            InitializeComponent();
        }

        public SIFModelo.hupBnf IDDR;
        public string lapso;
        public int ttrat;
        bool esnum;
        private Boolean cargaMotivos()
        {
            string idder = this.idDer.Text;
            if (string.IsNullOrEmpty(idder) || string.IsNullOrWhiteSpace(idder))
            {
                MessageBox.Show("El Id de Derechohabiente es Obligatorio");
                return false;
            }
            else
            {
                SIFNegocio.TipoDevolucions tipoN = new SIFNegocio.TipoDevolucions();
                SIFNegocio.ListDerechohabientes listaD = new SIFNegocio.ListDerechohabientes();
                BindingSource tipoBS = new BindingSource();
                tipoBS.DataSource = listaD.Buscar(idder).DataSource;
                

                if (tipoBS.Count == 0)
                {
                    MessageBox.Show("El Id de Derechohabiente NO se encuentra el la BD");
                    return false;
                }
                else
                {

                    this.der.DataSource = tipoBS;

                    der.DisplayMember = "NOMBRE";
                  
                    

                    return true;
                }
            }
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(this.idDer.Text.ToString()) || string.IsNullOrWhiteSpace(this.idDer.Text.ToString()))
                MessageBox.Show("Escribir ID del Derechohabiente");
            else if (string.IsNullOrEmpty(this.ttrata.Text.ToString()) || string.IsNullOrWhiteSpace(this.ttrata.Text.ToString()))
                MessageBox.Show("Escribir Tiempo de Tratamiento");
            else if (this.TMeses.Checked == false && this.tDias.Checked == false)
                MessageBox.Show("Elija un lapso de Tiempo, DIAS o MESES");
            else if(esnum=int.TryParse(this.ttrata.Text, out ttrat)==false)
                MessageBox.Show("El Tiempo de Tratamiento no es Valido(Debe ser un valor NUMERICO)");
                 else if (IDDR.Estado == SIFModelo.Tipos.SiNo.NO)
                       // if (der.DisplayMember="" == SIFModelo.Tipos.SiNo.NO)
                    {
                        MessageBox.Show("El Derechohabiente esta INACTIVO");
                        //this.aceptarButtonX.Enabled = false;
                    }
            else
            {
                
                ttrat = int.Parse(this.ttrata.Text);
                if (this.TMeses.Checked == true)
                    lapso = "Meses";
                else if (this.tDias.Checked == true)
                    lapso = "Dias";
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }

        private void cancelarButtonX_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void DatosDerechohabiente_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.cargaMotivos();
        }
        private void idDer_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                this.cargaMotivos();
            }
        }
        
        

        private void der_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDDR =  (SIFModelo.hupBnf)der.SelectedItem;
            IDDR.IDBnf.ToString();
        }
        
    }
}
