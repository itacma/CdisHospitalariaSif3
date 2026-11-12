using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View
{
    public partial class frmAjustesJHup : DevComponents.DotNetBar.Metro.MetroForm
    {
        SIFNegocio.Inventario.Ajustes ajustesAlmacen = new SIFNegocio.Inventario.Ajustes();
        public  DataTable dt =  new DataTable();
        public frmAjustesJHup()
        {
            InitializeComponent();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0 &&textBox1.Text.Length>0)
            {

               
                if (MessageBox.Show("¿Seguro que desea crear la orden de compra con los datos seleccionados?", "AVISO"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                {

                    string respuesta  =ajustesAlmacen.CreaAjusteOrdenCompraMandato(textBox1.Text, 99091, Helpers.Sesion.Usuario.UsuariosID.ToString());
                    MessageBox.Show(respuesta, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            } 
        }

        
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox1.TextLength>1)
            {
                
                this.Buscar();
            }
        }
        private void Buscar() 
        {
            try
            {
                dt = ajustesAlmacen.getAjthup(textBox1.Text, "");
                int no_existe = 0;

                string fo, fc, ft = "";
                ajustesAlmacen.getFoliosOC(textBox1.Text, out fo, out fc, out ft);

                if (fo == "" || fc == "" || ft == "")
                {
                    if (dt.Rows.Count > 0)
                    {
                        dataGridViewX1.DataSource = dt.DefaultView.ToTable(false, "CLAVE2", "DESC_1", "CANTIDAD", "PRECIO");

                        foreach (DataGridViewRow row in dataGridViewX1.Rows)
                        {

                            bool existe = ajustesAlmacen.validaArticulo(row.Cells["CLAVE2"].Value.ToString());
                            if (existe)
                            {
                                row.DefaultCellStyle.BackColor = Color.AliceBlue;
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                                no_existe++;
                            }

                        }

                        if (no_existe >= 1)
                        {
                            MessageBox.Show("Valida los articulos marcados en Rojo ");
                            aceptarButtonX.Enabled = false;
                        }

                    }
                    else
                    {
                        MessageBox.Show("No se encontraron datos.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    if (MessageBox.Show("La referencia " + textBox1.Text + " tiene los siguientes datos: \nfolio de orden " + fo + "\nfolio de compra " + fc + "\nfolio de traspaso "
                        + ft, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
               
            }
            catch (Exception s) {
                MessageBox.Show(s.ToString());
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
