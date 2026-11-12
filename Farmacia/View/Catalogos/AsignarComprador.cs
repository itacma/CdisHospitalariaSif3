using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Catalogos
{
    public partial class AsignarArtComp : DevComponents.DotNetBar.Metro.MetroForm
    {
       
        public AsignarArtComp()
        {
            InitializeComponent();
         //   listBox1.DrawMode = DrawMode.Normal;
           // listBox1.DrawItem += listBox1_DrawItem;
        

        }



        /// <summary>
        /// I--->  Variable que representa Asociar al comprador 
        /// D--->  Variable que representa DesAsociar al comprador
        /// A--->  Actualizacion del pivot, Actualiza la tabla cat_compradores_v2 la cual tiene los compradores en estructutra vertical
        /// S--->  Representa Si,Activo,Verdadero
        /// N--->  Representa No,Inactivo,Falso
        /// </summary>
        string vUsuario;
        string vProveedorDs;
        string vProveedorAs;
        private void cargaComp() {
            SIFNegocio.Compradores c = new SIFNegocio.Compradores();
            BindingSource cnombreC = new BindingSource();
            cnombreC.DataSource = c.BuscarComprador("COMPRADOR_C").DataSource;
            this.comboBox1.DataSource = cnombreC;
            comboBox1.DisplayMember = "COMPRADOR_C";                
        }

        private void cargaCompList() {
            /*SIFNegocio.Compradores c = new SIFNegocio.Compradores();
            BindingSource cnombreC = new BindingSource();
            cnombreC.DataSource = c.BuscarComprador("COMPRADOR_C").DataSource;
            
            foreach (object i in cnombreC ) {
                checkedListBox1.Items.Add(i);
            }*/
        }


        private void cargaCompAs(string usr,string usri ) {
            SIFNegocio.Compradores p = new SIFNegocio.Compradores();
            BindingSource cnombreP = new BindingSource();

            if (usri.Equals("="))
            {
                cnombreP.DataSource = p.BuscarComprador("NOMBRE_PROV_C", usr, usri, string.Empty).DataSource;
              //  this.listBox1.DataSource = cnombreP;
                
               // listBox1.DisplayMember = "NOMBREPROVC";
              
                


            }
            else { 
            
                cnombreP.DataSource = p.BuscarComprador("NOMBRE_PROV_C", usr, usri,string.Empty).DataSource;
           //     this.listBox2.DataSource = cnombreP;
           //     listBox2.DisplayMember = "NOMBREPROVC";
            }
            
        }




        



        private void cargaCompDs()
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int found =comboBox1.Text.IndexOf("-");
            if (found > 0)
            {
                 vUsuario = comboBox1.Text.Substring(0, found);
              //  this.cargaCompAs(vUsuario, "=");
//                this.cargaCompAs(vUsuario, "<>");
            }


        }

        private void AsignarArtComp_Load(object sender, EventArgs e)
        {   
                this.cargaComp();
                this.cargaCompList();
                this.asignaComp(null, null, "A");
                this.tp1ActivaBotones(true);

                dataGridViewAc1.Columns[0].ReadOnly = true;
                dataGridViewAc1.Columns[1].ReadOnly = true;
                dataGridViewAc1.Columns[2].ReadOnly = true;
                
           
        }

        
        private  void button1_Click(object sender, EventArgs e)
        {
            if (!comboBox1.Text.Equals("USUARIO"))
            {
             //   this.Asignar();
                this.cargaCompAs(vUsuario, "=");
                this.cargaCompAs(vUsuario, "<>");
            }
            else {
                MessageBox.Show("Selecciona un Comprador!", "Informacion",MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (!comboBox1.Text.Equals("USUARIO"))
            {
            //this.desAsignar();
            this.cargaCompAs(vUsuario, "=");
            this.cargaCompAs(vUsuario, "<>");
            }
             else
             {
                 MessageBox.Show("Selecciona un Comprador!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

             }
        }


        private void Asignar(string proveedor) {

             this.asignaComp(proveedor, vUsuario, "I");    
        }
        private void desAsignar(string proveedor)
        {
            this.asignaComp(proveedor, vUsuario, "D");
        }



        private void asignaComp(string vprob, string vusua,string tipomov) {
            SIFNegocio.Compradores p = new SIFNegocio.Compradores();
            if (p.AsigComprador(vprob, vusua, tipomov)==false) {
                MessageBox.Show("No  Realizar la operacion!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        
        }


        private void textBox1_KeyDown(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() != "")
            {
                if (!comboBox1.Text.Equals("USUARIO"))
                {

                    SIFNegocio.Compradores p = new SIFNegocio.Compradores();
                    BindingSource cnombreP = new BindingSource();
                    cnombreP.DataSource = p.BuscarComprador("NOMBRE_PROV_C", vUsuario, "<>", textBox1.Text).DataSource;
                 //   this.listBox2.DataSource = cnombreP;
                //    listBox2.DisplayMember = "NOMBREPROVC";
                }
                else {
                    MessageBox.Show("Selecciona un Comprador!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }

            }
        
        }



        public void load_gridProv(string A)
        {
            SIFNegocio.Compradores ConvCotizacion = new SIFNegocio.Compradores();            
            dataGridViewAc1.DataSource = ConvCotizacion.cargaGridProv(A);
            dataGridViewAc1.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewAc1.Sort(this.dataGridViewAc1.Columns["NOMBRE"], ListSortDirection.Ascending);
        }

        private void cBoxActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxActivos.Checked)
            {
                this.tp1ActivaBotones(true);
            }
        }

        private void cBoxInactivos_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxInactivos.Checked)
            {
                this.tp1ActivaBotones(false);
            }
        }

        private void tp1ActivaBotones(Boolean banderatp1) {

            if (banderatp1 == true)
            {
                this.load_gridProv("S");
                btnActivar.Enabled = false;
                btnDesactivar.Enabled = true;
                cBoxActivos.Checked = true;
                cBoxInactivos.Checked = false;

                
            }
            else {
                this.load_gridProv("N");
                btnActivar.Enabled = true;
                btnDesactivar.Enabled = false;
                cBoxActivos.Checked = false;
                cBoxInactivos.Checked = true;
            
            }
        
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            this.cambiaBanderaProv("S");
            this.load_gridProv("N");
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            this.cambiaBanderaProv("N");
            this.load_gridProv("S");
        }


        private void cambiaBanderaProv(string stado) {
            string cliente_id;
            
            SIFNegocio.Compradores p = new SIFNegocio.Compradores();            
            Int32 selectedCellCount =       dataGridViewAc1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                if (dataGridViewAc1.AreAllCellsSelected(true))
                {
                    MessageBox.Show("Selecciona un Proveedor", "Selecciona", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    /*for (int i = 0;i < selectedCellCount; i++)
                    {       */
                 
                       
                    int i = dataGridViewAc1.SelectedRows[0].Cells["CLIENTE_ID"].RowIndex;
                    
                    cliente_id = dataGridViewAc1.Rows[i].Cells[0].Value.ToString(); 

                        if (stado.Equals("S"))
                        {
                            if (p.cambiaEstadoP(cliente_id, stado) == false) {
                                MessageBox.Show("No se  pudo activar el cliente: "+cliente_id, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else {
                            if (p.cambiaEstadoP(cliente_id, stado) == false)
                            {
                                MessageBox.Show("No se pudo desactivar el cliente:" + cliente_id, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    //}
                }
            }
        }


        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            Graphics g = e.Graphics;
            
            g.FillRectangle(new SolidBrush(Color.White), e.Bounds);
            ListBox lb = (ListBox)sender;
            /*g.DrawString(//lb.Items[e.Index].ToString()
                //listBox1.Items.ToString()
                , e.Font, new SolidBrush(Color.Black), new PointF(e.Bounds.X, e.Bounds.Y));
                */
            e.DrawFocusRectangle();
        }




        private void button3_Click(object sender, EventArgs e)
        {
            this.load_grid();
        }        
               
        private void load_grid(){

            SIFNegocio.Compradores p = new SIFNegocio.Compradores();
            int found = comboBox1.Text.IndexOf("-");
            if (found > 0)
            {               
                vUsuario = comboBox1.Text.Substring(0, found);
                dGVCompradores.DataSource = p.cargaGridComprador(vUsuario);
                dGVCompradores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                this.dGVCompradores.Sort(this.dGVCompradores.Columns["PROVEEDOR_ID"], ListSortDirection.Ascending);
                this.InitializedGVCompradores(dGVCompradores);
                
                this.marcarAsignados();
            }
            else {

                MessageBox.Show("Selecciona un comprador");
            }
            
        }

        private void marcarAsignados() {
            int filas = dGVCompradores.RowCount;
            string  usuarioid;
            for (int i = 0; i < (filas-1); i++)
            {
                usuarioid = dGVCompradores.Rows[i].Cells["USUARIO_ID"].Value.ToString();
                if (usuarioid == vUsuario)
                {

                    dGVCompradores.Rows[i].Cells["Asociar"].Value = true;
                    dGVCompradores.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(230, 249, 255); 
                }

            }
        }

        private void dGVCompradores_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void dGVCompradores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dGVCompradores.Columns[e.ColumnIndex].HeaderText == "Asociar")
            {
                string valor =dGVCompradores.Rows[e.RowIndex].Cells["Asociar"].Value.ToString();
                Boolean bandera;
                
                if (String.IsNullOrEmpty(valor))
                {
                    bandera = false;
                }
                else {
                    bandera = Convert.ToBoolean( dGVCompradores.Rows[e.RowIndex].Cells["Asociar"].Value.ToString());
                }
                SIFNegocio.Compradores c = new SIFNegocio.Compradores();
              
                    if (bandera == false)
                    {
                        if (!comboBox1.Text.Equals("USUARIO"))
                        {
                            if (c.buscaExiste(vUsuario, dGVCompradores.Rows[e.RowIndex].Cells["PROVEEDOR_ID"].Value.ToString()))
                            {
                                MessageBox.Show("el usuario ya esta asignado");
                                dGVCompradores.EndEdit();
                                dGVCompradores.Rows[e.RowIndex].Cells["Asociar"].Value = false;
                                dGVCompradores.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
                            }
                            else
                            {
                            this.Asignar(dGVCompradores.Rows[e.RowIndex].Cells["PROVEEDOR_ID"].Value.ToString());
                            dGVCompradores.EndEdit();
                            dGVCompradores.Rows[e.RowIndex].Cells["Asociar"].Value = true;
                            dGVCompradores.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(230, 249, 255);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Selecciona un Comprador!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {

                        if (!comboBox1.Text.Equals("USUARIO"))
                        {
                            this.desAsignar(dGVCompradores.Rows[e.RowIndex].Cells["PROVEEDOR_ID"].Value.ToString());
                            dGVCompradores.EndEdit();
                            dGVCompradores.Rows[e.RowIndex].Cells["Asociar"].Value = false;
                            dGVCompradores.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
                        }
                        else
                        {
                            MessageBox.Show("Selecciona un Comprador!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                
            }
        }



        private void dGVCompradores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dGVCompradores.Columns[e.ColumnIndex].HeaderText == "Asociar")
            {
                MessageBox.Show(                    dGVCompradores.Rows[e.RowIndex].Cells["Asociar"].Value.ToString());
            }
        
        }


        private void InitializedGVCompradores(DataGridView dgv) {
            dgv.Columns[0].ReadOnly = true;
            dgv.Columns[1].ReadOnly = true;
            dgv.Columns[2].ReadOnly = true;
            dgv.Columns[3].ReadOnly = true;
        
        }


       
    }
}

