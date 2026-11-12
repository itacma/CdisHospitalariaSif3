using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Inventario
    {
    public partial class frmRegistraCad : DevComponents.DotNetBar.Metro.MetroForm
        {

        string[] arr = new string[5];
                //codigo de el articulo
                //nombre de el articulo
                // cantidad escaneada para lote y caducidad
                //referencia de el articulo
                //tipo de movimiento


        int total = 0;
        bool nuevaFila = false;


        int[] partida;
        String[] lote;
        String[] caducidades;
        int[] Cant;
        SIFNegocio.caducidades cd = new SIFNegocio.caducidades();



        public DataTable TaCaducidades { get; set; }
        public frmRegistraCad(string[] dtrArticulo)
            {
            InitializeComponent();
            arr = dtrArticulo;
            this.iniciaComponentes();
            }


        private void inicializaGrid()
            {
            this.tieneCaducidades();
            }
        private void iniciaComponentes() {
            this.inicializaGrid();
            this.NuevoButtonX.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.EliminarButtonX.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.GuardarButtonX.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F9);
            dataGridViewX1.AllowUserToAddRows = false;
            label1.Text = arr[1].ToString();
            label3.Text = arr[2].ToString();
            
            }
        private void tieneCaducidades()
            {

            TaCaducidades = cd.sp_Get_Art_cadPorFolio(arr[3].ToString(), arr[0].ToString());

            if (TaCaducidades.Rows.Count > 0)
                {

                foreach (DataRow dgv in TaCaducidades.Rows)
                    {
                    int rowId = dataGridViewX1.Rows.Add();
                    DataGridViewRow row = dataGridViewX1.Rows[rowId];
                    row.Cells["LOTE"].Value = dgv.ItemArray[0];
                    row.Cells["CADUCIDAD"].Value = dgv.ItemArray[1];
                    row.Cells["CANTIDAD"].Value = dgv.ItemArray[2];
                    row.Cells["REFERENCIA"].Value = dgv.ItemArray[3];
                    row.Cells["TIPO_MOV_INV"].Value = dgv.ItemArray[4];
                    }
                }
            }

        private void NuevoButtonX_Click(object sender, EventArgs e)
            {
            this.agregafila();
            }

        private void agregafila()
            {

            int i = dataGridViewX1.Rows.Cast<DataGridViewRow>()
                              .AsEnumerable()
                              .Sum(x => int.Parse(x.Cells["CANTIDAD"].Value.ToString()));
            if (i >= int.Parse(arr[2]))
                {
                MessageBox.Show("se completo la cantidad Loteada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (dataGridViewX1.Rows.Count > 0)
                {
                if (!this.validaCantidad())
                    return;
                }
            int rowId = dataGridViewX1.Rows.Add();
            DateTime cadu = DateTime.Now;
            DataGridViewRow row = dataGridViewX1.Rows[rowId];
            row.Cells["LOTE"].Value = "";
            row.Cells["CADUCIDAD"].Value = cadu.AddMonths(8);
            row.Cells["CANTIDAD"].Value = int.Parse(arr[2]) - total;
            row.Cells["REFERENCIA"].Value = arr[3];
            row.Cells["TIPO_MOV_INV"].Value = arr[4];
            dataGridViewX1.CurrentCell = dataGridViewX1.Rows[row.Index].Cells["LOTE"];
            dataGridViewX1.BeginEdit(true);
            }




        private Boolean valida()
            {
            foreach (DataGridViewRow row in dataGridViewX1.Rows)
                {
                if (int.Parse(row.Cells["CANTIDAD"].Value.ToString()) <= 0)
                    {
                    MessageBox.Show("La cantidad no es valida");
                    dataGridViewX1.CurrentCell = dataGridViewX1.Rows[row.Index].Cells["CANTIDAD"];
                    dataGridViewX1.BeginEdit(true);
                    return false;
                    }
                }
            foreach (DataGridViewRow row in dataGridViewX1.Rows)
                {
                if (string.IsNullOrEmpty(row.Cells["LOTE"].Value.ToString()))
                    {
                    MessageBox.Show("Debe capturar el lote");
                    dataGridViewX1.CurrentCell = dataGridViewX1.Rows[row.Index].Cells["LOTE"];
                    dataGridViewX1.BeginEdit(true);

                    return false;
                    }

                }

            return true;
            }

        private Boolean validaCantidad()
            {

            bool existeCero = false;
            foreach (DataGridViewRow row in dataGridViewX1.Rows)
                {
                if (int.Parse(row.Cells["CANTIDAD"].Value.ToString()) <= 0)
                    existeCero = true;
                }

            if (existeCero)
                {
                MessageBox.Show("No puedes Asignar lote a una cantidad Cero.");
                return false;
                }

            total = dataGridViewX1.Rows.Cast<DataGridViewRow>()
                              .AsEnumerable()
                              .Sum(x => int.Parse(x.Cells["CANTIDAD"].Value.ToString()));

            if (total > int.Parse(arr[2]))
                {
                MessageBox.Show("La cantidad capturada supera a la cantidad Escaneada");
                return false;
                }
            else
                {
                if (total < int.Parse(arr[2]))
                    nuevaFila = true;
                }

            return true;
            }

        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
            string columnaNombre = dataGridViewX1.Columns[e.ColumnIndex].HeaderText;
            switch (columnaNombre)
                {
                case "CANTIDAD":

                    if (!this.validaCantidad())
                        {
                        dataGridViewX1.CurrentCell.Value = 0;
                        }
                    if (nuevaFila)
                        this.agregafila();

                    break;
                case "LOTE":
                    if (!this.capturoLote(e))
                        return;
                    break;
                }





            }


        private bool capturoLote(DataGridViewCellEventArgs e)
            {
            if (String.IsNullOrEmpty(dataGridViewX1.Rows[e.RowIndex].Cells["LOTE"].Value.ToString()))
                {
                MessageBox.Show("Debes capturar un lote", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewX1.CurrentCell = dataGridViewX1.Rows[e.RowIndex].Cells["LOTE"];
                dataGridViewX1.BeginEdit(true);
                dataGridViewX1.Rows[e.RowIndex].Cells["CADUCIDAD"].ReadOnly = true;
                dataGridViewX1.Rows[e.RowIndex].Cells["CANTIDAD"].ReadOnly = true;
                return false;
                }
            else
                {
                dataGridViewX1.Rows[e.RowIndex].Cells["CADUCIDAD"].ReadOnly = false;
                dataGridViewX1.Rows[e.RowIndex].Cells["CANTIDAD"].ReadOnly = false;

                }

            return true;
            }

        private void CancelarButtonX_Click(object sender, EventArgs e)
            {
            this.cerrarFrm();
            }

        private void GuardarButtonX_Click(object sender, EventArgs e)
            {

            if (!this.valida())
                return;
            this.llenarDatos();
            int r = cd.ins_Caducidades(arr[3].ToString(), arr[0].ToString(), partida, lote, caducidades, Cant, arr[4].ToString(), "304");
            if (r <= 0)
                MessageBox.Show("No se insertaron los datos\nPKG_CADUCIDADES.sp_ins_caducidades", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
                MessageBox.Show("Ok","Guardado", MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.cerrarFrm();

            }
        private void EliminarButtonX_Click(object sender, EventArgs e)
            {

            //DataGridViewRow dr = dataGridViewX1.SelectedRows.;
            int ir = dataGridViewX1.SelectedRows.Count;
            if (ir == 1)
                {
                int rowindex = dataGridViewX1.CurrentRow.Index;
                DataGridViewRow dr = dataGridViewX1.Rows[rowindex];
                dataGridViewX1.Rows.Remove(dr);
                }

            }


        private void llenarDatos()
            {
            int p = 0;
            lote = new string[dataGridViewX1.Rows.Count];
            caducidades = new string[dataGridViewX1.Rows.Count];
            Cant = new int[dataGridViewX1.Rows.Count];
            partida = new int[dataGridViewX1.Rows.Count];
            foreach (DataGridViewRow dr in dataGridViewX1.Rows)
                {
                lote[dr.Index] = dr.Cells["LOTE"].Value.ToString();
                DateTime fec = DateTime.Parse(dr.Cells["CADUCIDAD"].Value.ToString());
                caducidades[dr.Index] = fec.ToString("dd/MM/yyyy");
                Cant[dr.Index] = int.Parse(dr.Cells["CANTIDAD"].Value.ToString());
                p++;
                partida[dr.Index] += p;

                }

            }
        private void cerrarFrm() {
            this.EliminarButtonX.Shortcuts.Clear();
            this.GuardarButtonX.Shortcuts.Clear();
            this.NuevoButtonX.Shortcuts.Clear();
            this.Close();
            
            }

        }
    }
