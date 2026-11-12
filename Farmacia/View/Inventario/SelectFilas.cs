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

namespace SIF.View.Inventario
{
    public partial class SelectFilas : Form
    {
        public string folio, filas="";
        public int lote;
        public bool todas=false;
        public SelectFilas()
        {
            InitializeComponent();
        }

        private void SelectFilas_Load(object sender, EventArgs e)
        {
            cargaFilas(folio, lote);
        }

        public void cargaFilas(string folio, int lote)
        {
            string sentencia = "  select fila from cs_traspaso_fila  where  folio ='" + folio + "'   and   lote  =" + lote + "  group by fila order by fila asc";
            using (OracleConnection cnx = new OracleConnection(SIFNegocio.Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                        DataSet ds = new DataSet();
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(ds);
                        if (oreader.HasRows)
                        {
                            CheckedListBox itemT = new CheckedListBox();
                            itemT.Text = "Todas";
                            itemT.Name = "Todas";
                            checkedListBox1.Items.Add(itemT, false);
                            while (oreader.Read())
                            {
                                CheckedListBox item = new CheckedListBox();

                                item.Tag = oreader["FILA"].ToString();

                                item.Text = oreader["FILA"].ToString();
                                item.Name = oreader["FILA"].ToString();
                                checkedListBox1.Items.Add(item, false);
                                filas = item.Text;
                            }
                            if (checkedListBox1.Items.Count == 2)
                            {
                                foreach (CheckedListBox itemChecked in checkedListBox1.Items)
                                {
                                    if (itemChecked.Text == "Todas")
                                    {
                                        itemChecked.Enabled = false;
                                        itemChecked.Visible = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                           MessageBox.Show("No hay existencias suficientes para surtir el traspaso: "+folio);
                            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                       MessageBox.Show("Error:" + ex.Message);
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }
                }
            } 
        }
        
        private void valida()
        {
            int check = 0, ind = 0;
            foreach (CheckedListBox itemChecked in checkedListBox1.Items)
            {
                if (checkedListBox1.GetItemChecked(ind))
                    check++;

                if (ind == 0 && checkedListBox1.GetItemChecked(ind)==true)
                {
                    todas = true;
                }

                ind++;
            }
            
            if (check == 0)
            {
               MessageBox.Show("Debes de seleccionar una Fila a surtir");
            }
            else
            {
                filas = "";
                if (!todas)
                {
                    foreach (CheckedListBox itemChecked in checkedListBox1.CheckedItems)
                    {
                        if (itemChecked.Text != "Todas")
                        filas = filas + "," + itemChecked.Text;
                    }
                }
                else
                {
                    foreach (CheckedListBox itemChecked in checkedListBox1.Items)
                    {
                        if (itemChecked.Text != "Todas")
                        filas = filas + "," + itemChecked.Text;
                    }
                }
                
                filas = filas.Remove(0, 1);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            valida();
        }
        private void CancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
