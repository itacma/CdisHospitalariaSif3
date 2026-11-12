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
    public partial class DatosMedico : DevComponents.DotNetBar.Metro.MetroForm
    {
        public DatosMedico()
        {
            InitializeComponent();
            this.labelX1.Visible = false;
            this.aceptarButtonX.Enabled = false;
            this.dataGridView1.Visible = false;
            this.dataGridView1.RowHeadersVisible = false;
        }

        public SIFModelo.hupMed IDMD;
        string idmed;
       // public int ttrat;
        //bool esnum;
       
        private Boolean cargaMotivos()
        {
             idmed = this.idMED.Text;
            if (string.IsNullOrEmpty(idmed) || string.IsNullOrWhiteSpace(idmed))
            {
                this.labelX1.Visible = false;
                this.aceptarButtonX.Enabled = false;
                this.dataGridView1.Visible = false;
                this.dataGridView1.RowHeadersVisible = false;
                MessageBox.Show("El Id de el Medico es Obligatorio");
                return false;
            }
            else
            {
              //  SIFNegocio.TipoDevolucions tipoN = new SIFNegocio.TipoDevolucions();
                SIFNegocio.ListDerechohabientes listam = new SIFNegocio.ListDerechohabientes();
                ///BindingSource tipoBS = new BindingSource();
                IDMD = listam.BuscarM(idmed);


                if (IDMD.IDmed == null)
                {
                    
                    this.labelX1.Visible = false;
                    this.aceptarButtonX.Enabled = false;
                    this.dataGridView1.Visible = false;
                    this.dataGridView1.RowHeadersVisible = false;
                    MessageBox.Show("El Id de Derechohabiente NO se encuentra el la BD");
                    return false;
                }
                else
                {

                  /*  this.MED.DataSource = tipoBS;

                    MED.DisplayMember = "NOMBRE";*/
                    
                    //IDDR = der.SelectedItem.ToString();
                    if (IDMD.Estado == SIFModelo.Tipos.SiNo.NO)
                    {
                        
                        this.labelX1.Visible = false;
                        this.aceptarButtonX.Enabled = false;
                        this.dataGridView1.Visible = false;
                        this.dataGridView1.RowHeadersVisible = false;
                        MessageBox.Show("El Medico esta INACTIVO");
                    }
                    else
                    {
                        this.labelX1.Visible = false;
                        this.dataGridView1.RowHeadersVisible = false;
                        this.aceptarButtonX.Enabled = true;
                        dataGridView1.Rows.Clear();
                        this.dataGridView1.Visible = true;
                        this.dataGridView1.Rows[0].Cells["ID"].Value=IDMD.IDmed.ToString();
                        this.dataGridView1.Rows[0].Cells["NOMBRE"].Value = IDMD.Nombre.ToString();
                        this.dataGridView1.Rows[0].Cells["ESPECIALIDAD"].Value = IDMD.Especialidad.ToString();
                        this.dataGridView1.Rows[0].Cells["CEDULA"].Value = IDMD.Cedula.ToString();
                       // this.dataGridView1.Rows[0].Cells["ESTADO"].Value = IDMD.Estado.ToString();
                        //this.dataGridView1.Rows.
                        this.aceptarButtonX.Enabled = true;
                    }

                    return true;
                }
            }
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            IDMD.IDmed = idmed;
           
           /* if (string.IsNullOrEmpty(this.idMED.Text.ToString()) || string.IsNullOrWhiteSpace(this.idMED.Text.ToString()))
                MessageBox.Show("Escribir ID del Derechohabiente");
            else if (string.IsNullOrEmpty(this.ttrataEE.Text.ToString()) || string.IsNullOrWhiteSpace(this.ttrataEE.Text.ToString()))
                MessageBox.Show("Escribir Tiempo de Tratamiento");
            else if (this.TMeses.Checked == false && this.tDias.Checked == false)
                MessageBox.Show("Elija un lapso de Tiempo, DIAS o MESES");
            else if(esnum=int.TryParse(this.ttrataEE.Text, out ttrat)==false)
                MessageBox.Show("El Tiempo de Tratamiento no es Valido(Debe ser un valor NUMERICO)");         
            else
            {
                ttrat = int.Parse(this.ttrataEE.Text);
                if (this.TMeses.Checked == true)
                    lapso = "Meses";
                else if (this.tDias.Checked == true)
                    lapso = "Dias";*/

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
           // }
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

        

        private void der_SelectedIndexChanged(object sender, EventArgs e)
        {
           // IDMD = (SIFModelo.hupMed)MED.SelectedItem;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void idMED_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                this.cargaMotivos();
            }
        }
        
    }
}
