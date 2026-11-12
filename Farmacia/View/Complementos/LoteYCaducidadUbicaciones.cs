using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Complementos
{
    public partial class LoteYCaducidadUbicaciones : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        String Varticulo_id;
        Int32 cantidadTot;
        int periodo = 0;
        DataTable ListArticulosRecepcioCaptura = new DataTable();
        DataGridViewCell celdaEditada;

        List<Int32> L_partida = new List<Int32>();
        List<string> L_articulo_id = new List<string>();
        List<Int32> L_cant_lote = new List<Int32>();
        List<string> L_lote = new List<string>();
        List<string> L_caducidad = new List<string>();
        int saveKey = 0;


        public LoteYCaducidadUbicaciones(String particulo_id, string particulo_name, Int32 pcantidadTotal, int pPeriodo)
        {
            InitializeComponent();
            CargaParametros(particulo_id, particulo_name, pcantidadTotal, pPeriodo);
            cargarDatos();

        }


        private void CargaParametros(String larticulo_id, string larticulo_name, Int32 lcantidadTotal, int Pperiodo)
        {
            periodo = Pperiodo;
            Varticulo_id = larticulo_id;
            cantidadTot = lcantidadTotal;
            label1.Text = larticulo_id + " - " + larticulo_name;
            label2.Text = lcantidadTotal + " Piezas";
            label3.Text = "F11: Guardar";
            label4.Text = "";// "Ctrl+L: Limpiar";

        }

        private void cargarDatos()
        {
            DataTable dt = new SIFNegocio.caducidades().sp_GetDataLotesYcaducidadesSku(Varticulo_id, periodo);
            ListArticulosRecepcioCaptura = dt;
            if (dt.Rows.Count > 0)
            {
                //ListArticulosRecepcioCaptura.DefaultView.Sort = " NOMBRE ASC";
                dataGridViewX1.DataSource = ListArticulosRecepcioCaptura.DefaultView.ToTable(false, "CANTIDAD", "NO_LOTE", "CADUCIDAD");

            }
            else
            {
                DataRow ndr = ListArticulosRecepcioCaptura.NewRow();
                ndr["ARTICULO_ID"] = Varticulo_id;
                ndr["CANTIDAD"] = cantidadTot;
                ndr["NUM_PARTIDA"] = 1;
                //  ndr[""] = ;

                ListArticulosRecepcioCaptura.Rows.Add(ndr);

                ListArticulosRecepcioCaptura.DefaultView.Sort = " num_partida ASC";
                //dataGridViewX1.DataSource = ListArticulosRecepcioCaptura;
                dataGridViewX1.DataSource = ListArticulosRecepcioCaptura.DefaultView.ToTable(false, "CANTIDAD", "NO_LOTE", "CADUCIDAD");





            }
        }

        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            celdaEditada = dataGridViewX1.CurrentRow.Cells[e.ColumnIndex];

            ListArticulosRecepcioCaptura = (DataTable)(dataGridViewX1.DataSource);

            // object objSum = ListArticulosRecepcion.Compute("Sum(CANTIDAD)", "ARTICULO_ID = '" + dataGridViewX1.CurrentRow.Cells[0].Value + "'");


            if (celdaEditada.ColumnIndex == 0)
            {
                try
                {
                    int newCantidadRow = 0;
                    var valor = celdaEditada.Value;


                    if (!valor.ToString().IsIntegerPositive())
                    {
                        //MessageBoxEx.Show("El valor debe ser numérico");
                        letrero("El valor debe ser numérico");
                        celdaEditada.Value = 0;
                        return;
                    }
                    if (int.Parse(valor.ToString()) == 0)
                    {
                        //MessageBoxEx.Show("El valor debe ser mayor a cero");
                        letrero("El valor debe ser mayor a cero");
                        celdaEditada.Value = 1;
                        return;
                    }


                    //CALCULAR EL TOTAL
                    var datagridRow = dataGridViewX1.Rows[e.RowIndex].DataBoundItem;

                    if (!(datagridRow is DataRowView))
                    {
                        return;
                    }

                    DataRow dgRow = ((DataRowView)((dataGridViewX1.Rows[e.RowIndex].DataBoundItem))).Row;
                    decimal cantiad = decimal.Parse(dgRow["cantidad"].ToString());



                    //int totalEnCaptura = 0;
                    //foreach (DataRow _dr in ListArticulosRecepcioCaptura.Rows)
                    //{


                    //    if (_dr["ARTICULO_ID"].ToString() == dataGridViewX1.CurrentRow.Cells[0].Value.ToString())
                    //    {
                    //        totalEnCaptura += int.Parse(_dr["CANTIDAD"].ToString());
                    //    }
                    //}

                    object totalEnCaptura = ListArticulosRecepcioCaptura.Compute("Sum(CANTIDAD)", string.Empty);



                    newCantidadRow = cantidadTot
                         - Convert.ToInt32(totalEnCaptura.ToString());


                    //if (newCantidadRow > 0)
                    //{

                    //    DataRow ndr = ListArticulosRecepcioCaptura.NewRow();
                        
                    //    ndr["CANTIDAD"] = newCantidadRow;
                        



                    //    ListArticulosRecepcioCaptura.Rows.Add(ndr);

                       
                    //    dataGridViewX1.DataSource = ListArticulosRecepcioCaptura;
                    //    saveKey = 0;
                        
                    //}



                }
                catch (Exception _EX)
                {

                   MessageBox.Show(_EX.ToString());
                }
            }

        }



        private bool Validar(DataTable dt)
        {
            int partida = 0;
            L_partida = new List<Int32>();
            L_articulo_id = new List<string>();

            L_cant_lote = new List<Int32>();
            L_lote = new List<string>();

            L_caducidad = new List<string>();





            Int32 total = 0;

            if (dt != null && dt.AsEnumerable().Any())
            {
                var duplicatesData = dt.AsEnumerable().GroupBy(r => r["NO_LOTE"], g => g["CADUCIDAD"]).Where(gr => gr.Count() > 1);
                //Check if duplicate records exists
                if (duplicatesData != null &&
                    duplicatesData.Any())
                {

                }
            }

            //Recorremos el grid de articulos Capturados para identificar la cantidad total capturada
            foreach (DataRow _drcapturados in dt.Rows)
            {

                if (!fechaCaducidadValida(_drcapturados["CADUCIDAD"].ToString(), _drcapturados["NO_LOTE"].ToString()))
                {

                    if (DialogResult.Yes == (
                   MessageBox.Show(
                        "Valide que la fecha de caducidad sean correctas(Puede dejar " +
                        "vacias las celdas para guardar sin caducidad)"
                        , "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)))
                        return true;
                    return false;
                }

                if (!String.IsNullOrEmpty(_drcapturados["NO_LOTE"].ToString()) && !String.IsNullOrEmpty(_drcapturados["CADUCIDAD"].ToString()))
                {
                    partida++;
                    L_partida.Add(partida);
                    L_articulo_id.Add(Varticulo_id);
                    L_lote.Add(_drcapturados["NO_LOTE"].ToString().ToUpper());
                    L_caducidad.Add(_drcapturados["CADUCIDAD"].ToString());
                    L_cant_lote.Add(int.Parse(_drcapturados["CANTIDAD"].ToString()));
                    total += Int32.Parse(_drcapturados["CANTIDAD"].ToString());

                }


            }



            if (cantidadTot != total)
            {

                letrero("El total de piezas capturadas es diferente a  la cantidad capturada en el inventario Fisico ");
                //MessageBox.Show("El total de piezas capturadas es diferente a  la cantidad capturada en el inventario Fisico ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (L_partida.Count <= 0)
            {
                //MessageBoxEx.Show("Sin registros a procesar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                letrero("Sin registros a procesar");
                return false;
            }
            return true;

        }

        private bool fechaCaducidadValida(string _f, string _lote)
        {
            try
            {
                if (_f.Length == 0 && _lote.Length == 0)
                {
                    return true;
                }
                if (_f.Length >= 0 && _lote.Length == 0)
                {
                    return false;
                }
                DateTime fechaservidor = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                DateTime FechaCaducidad = DateTime.ParseExact("01" + _f, "ddMMyy", CultureInfo.InvariantCulture);
                int dif = ((FechaCaducidad.Year - fechaservidor.Year) * 12) + FechaCaducidad.Month - fechaservidor.Month;
                if (dif >= 0)
                    return true;
                else
                    return false;
            }
            catch (Exception _x)

            {
                return false;

            }


        }
        private void guardar()
        {
            ListArticulosRecepcioCaptura = (DataTable)(dataGridViewX1.DataSource);

            if (!Validar(ListArticulosRecepcioCaptura))
                return;

            SIFNegocio.caducidades negocio = new SIFNegocio.caducidades();
            string RespuestaInsertaMsg = "";
            decimal inserta = negocio.sp_SaveCaduCapturadasSku
                (Helpers.Sesion.Usuario.UsuariosID.ToString(),
                    periodo,
                    L_partida,
                    L_articulo_id,
                    L_cant_lote,
                    L_lote,
                    L_caducidad
                );
            if (inserta <= 0)
            {

               MessageBox.Show(RespuestaInsertaMsg, "Guardar ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                 
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }



        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                //case Keys.D | Keys.Control | Keys.Alt | Keys.Shift:
                case Keys.L | Keys.Control://Dividir
                    this.Limpiar();
                    return true;
                case Keys.G | Keys.Control://guardar
                    this.guardar();
                    return true;
                case Keys.F11:
                    this.guardar();
                    return true;
                case Keys.R | Keys.Control:
                    this.agregarRow();
                    return true;
                    //case Keys.A | Keys.Control://Asginar Valores  de grid al modelo
                    //    this.AsginarM();
                    //    return true;
            }
            return base.ProcessCmdKey(ref message, keys);
        }
        private void agregarRow() {

            try
            {
                DataRow ndr = ListArticulosRecepcioCaptura.NewRow();

                ndr["CANTIDAD"] = 0;




                ListArticulosRecepcioCaptura.Rows.Add(ndr);


                dataGridViewX1.DataSource = ListArticulosRecepcioCaptura;
                saveKey = 0;
            }
            catch (Exception xm) {
                MessageBox.Show(xm.ToString());
            }


        } 

        private void Limpiar()
        {
            return;
            if (DialogResult.Yes ==MessageBox.Show("Se eliminaran las caducidades" + Environment.NewLine + "Desea continuar?", "Limpiar caducidades", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {

                ListArticulosRecepcioCaptura.Clear();
                DataRow ndr = ListArticulosRecepcioCaptura.NewRow();
                ndr["ARTICULO_ID"] = Varticulo_id;
                ndr["CANTIDAD"] = cantidadTot;
                ndr["NUM_PARTIDA"] = 1;
                //  ndr[""] = ;

                ListArticulosRecepcioCaptura.Rows.Add(ndr);
                ListArticulosRecepcioCaptura.DefaultView.Sort = " num_partida ASC";
                dataGridViewX1.DataSource = ListArticulosRecepcioCaptura.DefaultView.ToTable(false, "CANTIDAD", "NO_LOTE", "CADUCIDAD");



            }

        }

        private void letrero(string texto)
        {
            int rdn = new Random().Next(1, 10);
            if (rdn == 1)
            {
                this.richTextBox1.ForeColor = System.Drawing.Color.DarkRed;
            }
            else if (rdn == 2)
            {
                this.richTextBox1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                this.richTextBox1.ForeColor = System.Drawing.Color.OrangeRed;
            }
            richTextBox1.Text = texto;
        }

        private void dataGridViewX1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {

                // object objSum = ListArticulosRecepcion.Compute("Sum(CANTIDAD)", "ARTICULO_ID = '" + dataGridViewX1.CurrentRow.Cells[0].Value + "'");
                if (celdaEditada == null)
                    return;

                if (celdaEditada.ColumnIndex == (dataGridViewX1.Columns.Count - 1) && celdaEditada.RowIndex == (dataGridViewX1.Rows.Count - 1))
                {
                    /// if (saveKey > 0)
                    guardar();
                    // else
                    //    saveKey++;


                }
            }
        }
    }
}
