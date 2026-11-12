using DevComponents.DotNetBar;
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
    public partial class PNCCaducidadUserControl : SIF.Templates.CatalogoUserControl
    {
        //public object Owner;
        //public bool Mostrado;
        private int idMovimiento;
        private String FolioDocumento;
        private int Lote_documento;
        DataTable ListArticulosRecepcion = new DataTable();
        DataTable ListArticulosRecepcioSeleccion = new DataTable();
        DataTable ListArticulosRecepcioSeleccionOrg = new DataTable();//Lo utilizo para saber el estado original de la seleccion
        DataTable ListArticulosRecepcionDetalle = new DataTable();
        public ProductoNoConformeUserControl Parent = null;

        List<Int16> L_partida = new List<Int16>();
        List<string> L_articulo_id = new List<string>();
        List<string> L_Lote_Interno = new List<string>();
        List<Int16> L_cant_lote = new List<Int16>();
        List<string> L_lote = new List<string>();
        List<string> L_loteProdcesado = new List<string>();
        List<string> L_caducidad = new List<string>();
        DataGridViewCell celdaEditada;
        DataGridViewRow FilaEditada;
        AutoCompleteStringCollection strAutocompleteNumlote = new AutoCompleteStringCollection();
        int nRow = 0;
        public bool Mostrado { get; set; }

        public MainForm Owner { get; set; }

        public PNCCaducidadUserControl(string pfolioMovimiento, int pe_lote_documeto = 0)
        {
            InitializeComponent();
            inicializaColoresFilas();
            FolioDocumento = pfolioMovimiento;
            //idMovimiento = pidMov;
            Lote_documento = pe_lote_documeto;
            buscar();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        DataGridViewCellStyle revisarRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle GuardadosRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle faltanteRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle normalRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle WarningCellStyle = new DataGridViewCellStyle();

        private void inicializaColoresFilas()
        {
            revisarRowStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            revisarRowStyle.BackColor = Color.FromArgb(237, 224, 249);//237,224,249
            //revisarRowStyle.BackColor.Color2 = Color.FromArgb(255, 35, 35);

            WarningCellStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            WarningCellStyle.BackColor = Color.FromArgb(253, 215, 0);
            //WarningCellStyle.BackColor.Color2 = Color.FromArgb(253, 215, 0);

            GuardadosRowStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            GuardadosRowStyle.BackColor = Color.FromArgb(115, 240, 109);
            //margenRowStyle.BackColor.Color2 = Color.FromArgb(200, 100, 100);

            faltanteRowStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            faltanteRowStyle.BackColor = Color.FromArgb(255, 87, 51);
            //faltanteRowStyle.Background.Color2 = Color.FromArgb(0, 176, 80);

            normalRowStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            normalRowStyle = this.dataGridViewX1.DefaultCellStyle;
        }

        private void buscar()
        {
            ///<summary> itacma 
            /// + Utilizo 2 data tables 1 para el origen de datos y 2 para la capruta de datos ya que la cantidad por lote puede variar
            /// </summary>

            ReferenciaLabeDto.Text = FolioDocumento;
            //Recibo las caducidades Capturadas
            DataTable dt = new SIFNegocio.Inventario.PNCNegocio().GetLotesCaducidades(FolioDocumento);

            //Recibo los productos con caducidad Recibida en la Orden de compra
            ListArticulosRecepcion = new SIFNegocio.Inventario.PNCNegocio().sp_GetDataSeleccionSalidas(FolioDocumento, Lote_documento);
            ListArticulosRecepcionDetalle = new SIFNegocio.Inventario.PNCNegocio().sp_GetDataSeleccionDetalleMov(FolioDocumento, Lote_documento);
            ListArticulosRecepcioSeleccion = dt;
            ListArticulosRecepcioSeleccionOrg = ListArticulosRecepcioSeleccion;

            if (dt.Rows.Count > 0)
            {
                ListArticulosRecepcioSeleccion.DefaultView.Sort = " NOMBRE ASC";
                dataGridViewX1.DataSource = ListArticulosRecepcioSeleccion.DefaultView.ToTable(false, "ARTICULO_ID", "NOMBRE", "CANTIDAD", "NO_LOTE", "CADUCIDAD", "LOTE_INTERNO");
                ListArticulosRecepcion.DefaultView.Sort = " NOMBRE ASC";
                dataGridViewX2.DataSource = ListArticulosRecepcion.DefaultView.ToTable(false, "ARTICULO_ID", "NOMBRE", "CANTIDAD_LOTE", "CANTIDAD_DISPONIBLE", "NO_LOTE", "CADUCIDAD", "LOTE_INTERNO");
                FolioDocumento = ListArticulosRecepcioSeleccion.Rows[0].ItemArray[0].ToString();
            }

            //for (int i = 0; i < dataGridViewX1.Columns.Count; i++)
                //dataGridViewX1.Columns[i].ReadOnly = true;

            for (int i = 0; i < dataGridViewX2.Columns.Count; i++)
                dataGridViewX2.Columns[i].ReadOnly = true;
        }

        public void Muestra()
        {
            //if (this.Owner is Inventario.ProductoNoConformeUserControl)
            //{
            //    ((Inventario.ProductoNoConformeUserControl)Owner).Owner.DesactivaComandos();
            //    ((Inventario.ProductoNoConformeUserControl)Owner).DesactivaComandos();
            //    //this.ActivaComandos();
            //    this.Dock = DockStyle.Fill;
            //    this.Mostrado = true;

            //    ((Inventario.ProductoNoConformeUserControl)Owner).Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            //}
            if (Mostrado)
            {
                return;
            }

            this.Dock = DockStyle.Fill;
            //this.ActivaComandos();
            Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            Mostrado = true;
        }

        private void Back()
        {

            try
            {
                Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                //this.DesactivaComandos();
                
                this.Owner.ActivaComandos();
                if (Parent != null)
                {
                    Parent.Buscar();
                }
                Mostrado = false;
            }
            catch { }
        }

        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            celdaEditada = dataGridViewX1.CurrentRow.Cells[e.ColumnIndex];

            ListArticulosRecepcioSeleccion = (DataTable)(dataGridViewX1.DataSource);

            object objSum = ListArticulosRecepcionDetalle.Compute("Sum(CANTIDAD)", "ARTICULO_ID = '" + dataGridViewX1.CurrentRow.Cells[0].Value + "'");

            if (celdaEditada.ColumnIndex == 2)
            {
                try
                {
                    int newCantidadRow = 0;
                    var valor = celdaEditada.Value;

                    if (!valor.ToString().IsIntegerPositive())
                    {
                       MessageBox.Show("El valor debe ser numérico");
                        celdaEditada.Value = 0;
                        return;
                    }

                    if (int.Parse(valor.ToString()) == 0)
                    {
                       MessageBox.Show("El valor debe ser mayor a cero");
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

                    int totalEnCaptura = 0;
                    foreach (DataRow _dr in ListArticulosRecepcioSeleccion.Rows)
                    {
                        if (_dr["ARTICULO_ID"].ToString() == dataGridViewX1.CurrentRow.Cells[0].Value.ToString())
                        {
                            totalEnCaptura += int.Parse(_dr["CANTIDAD"].ToString());
                        }
                    }
                    newCantidadRow = Convert.ToInt32(objSum.ToString()) - totalEnCaptura;

                    if (newCantidadRow > 0)
                    {
                        DataRow nEWrOW = ListArticulosRecepcioSeleccion.NewRow();

                        nEWrOW["ARTICULO_ID"] = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                        nEWrOW["NOMBRE"] = dataGridViewX1.CurrentRow.Cells[1].Value.ToString();
                        nEWrOW["CANTIDAD"] = newCantidadRow;
                        nEWrOW["NO_LOTE"] = "";
                        nEWrOW["CADUCIDAD"] = Convert.ToDateTime("01/01/2001"); ;

                        ListArticulosRecepcioSeleccion.Rows.Add(nEWrOW);

                        ListArticulosRecepcioSeleccion.DefaultView.Sort = " NOMBRE ASC";
                        dataGridViewX1.DataSource = ListArticulosRecepcioSeleccion;

                    }

                }
                catch (Exception _EX)
                {

                   MessageBox.Show(_EX.ToString());
                }
            }
        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                FilaEditada = dataGridViewX1.CurrentRow;

                Articulo_IDlabel.Text = FilaEditada.Cells["ARTICULO_IDColumn"].Value.ToString();
                Nombre1label.Text = FilaEditada.Cells["NOMBRE1Column"].Value.ToString();
                CantidadnumericUpDown.Value = Convert.ToInt16(FilaEditada.Cells["CANTIDADColumn"].Value.ToString());
                //CantidadnumericUpDown.Text = FilaEditada.Cells["CANTIDADColumn"].Value.ToString();
                NumLoteSelectTextBoxX.Text = FilaEditada.Cells["NO_LOTEColumn"].Value.ToString();

                //ArticuloSleccionado = grow.Cells["ARTICULO_IDColumn"].Value.ToString();
                string rowFilter = string.Format("[{0}] = '{1}'", "ARTICULO_ID", FilaEditada.Cells["ARTICULO_IDColumn"].Value.ToString());
                (dataGridViewX2.DataSource as DataTable).DefaultView.RowFilter = rowFilter;

                strAutocompleteNumlote.Clear();
                foreach (DataGridViewRow StNolote in dataGridViewX2.Rows)
                    strAutocompleteNumlote.Add(StNolote.Cells["NO_LOTE_Column"].Value.ToString() + "^" + StNolote.Cells["CADUCIDAD_Column"].Value.ToString() + "^" + StNolote.Cells["LOTE_INTERNOSColumn"].Value.ToString());

                this.NumLoteSelectTextBoxX.AutoCompleteCustomSource = strAutocompleteNumlote;
            }
            catch (Exception _x)
            {
               MessageBox.Show(_x.ToString(), "Producto No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dataGridViewX2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (!ValidaCodigoSeleccionado())
                {
                    return;
                }

                DataGridViewRow grow = dataGridViewX2.Rows[e.RowIndex];

                //foreach (DataRow dr in ListArticulosRecepcioSeleccion.Rows)
                //{
                // MessageBox.Show(""+Convert.ToInt32(FilaEditada.Cells["CANTIDADColumn"].Value));
                //MessageBox.Show("" + Convert.ToInt32(grow.Cells[3].Value.ToString()));
                if (Convert.ToInt32(FilaEditada.Cells["CANTIDADColumn"].Value.ToString()) <= Convert.ToInt32(grow.Cells[3].Value.ToString()))
                {

                    FilaEditada.Cells["LOTE_INTERNOSColumn"].Value = grow.Cells["LOTE_INTERNOSColumn"].Value.ToString();
                    FilaEditada.Cells["NO_LOTEColumn"].Value = grow.Cells["NO_LOTE_Column"].Value.ToString();
                    FilaEditada.Cells["CADUCIDADColumn"].Value = grow.Cells["CADUCIDAD_Column"].Value.ToString();

                }
                else
                   MessageBox.Show("La cantidad del lote es menor a la cantidad del movimiento, No se puede asignar","Producto No Conforme");
                // }
                //ListArticulosRecepcioSeleccion.DefaultView.Sort = " NOMBRE ASC";
                //dataGridViewX1.DataSource = ListArticulosRecepcioSeleccion.DefaultView.ToTable(false, "ARTICULO_ID", "NOMBRE", "CANTIDAD", "NO_LOTE", "CADUCIDAD", "LOTE_INTERNO"); ;
            }
            catch (Exception _x)
            {


            }

        }

        private bool ValidaCodigoSeleccionado()
        {
            if (FilaEditada == null)
            {
               MessageBox.Show("Seleccione un codigo a asignar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void NumLoteSelectTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (!ValidaCodigoSeleccionado())
                    {
                        return;
                    }

                    FilaEditada.Cells["LOTE_INTERNOColumn"].Value = NumLoteSelectTextBoxX.Text.Split('^')[2];// obtenemos el lote interno
                    FilaEditada.Cells["NO_LOTEColumn"].Value = NumLoteSelectTextBoxX.Text.Split('^')[0];// obtenemos el lote 
                    FilaEditada.Cells["CADUCIDADColumn"].Value = NumLoteSelectTextBoxX.Text.Split('^')[1];// obtenemos Caducidad

                    if (FilaEditada.Index + 1 < dataGridViewX1.RowCount)
                    {
                        // dataGridViewX1.Rows[nRow].Selected = false;
                        // dataGridViewX1.Rows[++nRow].Selected = true;
                        dataGridViewX1.CurrentCell = dataGridViewX1[1, FilaEditada.Index + 1];
                        FilaEditada = dataGridViewX1.CurrentRow;

                        Articulo_IDlabel.Text = FilaEditada.Cells["ARTICULO_IDColumn"].Value.ToString();
                        Nombre1label.Text = FilaEditada.Cells["NOMBRE1Column"].Value.ToString();
                        CantidadnumericUpDown.Value = int.Parse(FilaEditada.Cells["CANTIDADColumn"].Value.ToString());
                        //CantidadnumericUpDown.Text = FilaEditada.Cells["CANTIDADColumn"].Value.ToString();

                        //ArticuloSleccionado = grow.Cells["ARTICULO_IDColumn"].Value.ToString();
                        string rowFilter = string.Format("[{0}] = '{1}'", "ARTICULO_ID", FilaEditada.Cells["ARTICULO_IDColumn"].Value.ToString());
                        (dataGridViewX2.DataSource as DataTable).DefaultView.RowFilter = rowFilter;

                        strAutocompleteNumlote.Clear();
                        foreach (DataGridViewRow StNolote in dataGridViewX2.Rows)
                            strAutocompleteNumlote.Add(StNolote.Cells["NO_LOTE_Column"].Value.ToString() + "^" + StNolote.Cells["CADUCIDAD_Column"].Value.ToString() + "^" + StNolote.Cells["LOTE_INTERNOSColumn"].Value.ToString());

                        this.NumLoteSelectTextBoxX.AutoCompleteCustomSource = strAutocompleteNumlote;
                    }

                }
                catch (Exception _x)
                {


                }
            }
        }

        private void RestaurarbuttonItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes ==MessageBox.Show("Se eliminarán todas las caducidades y lotes asignados " + Environment.NewLine + "¿Desea continuar?", "Producto No Conforme", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                /*ListArticulosRecepcioSeleccion = ListArticulosRecepcioSeleccionOrg;
                ListArticulosRecepcioSeleccion.DefaultView.Sort = " NOMBRE ASC";
                dataGridViewX1.DataSource = ListArticulosRecepcioSeleccion.DefaultView.ToTable(false, "ARTICULO_ID", "NOMBRE", "CANTIDAD", "NO_LOTE", "CADUCIDAD", "LOTE_INTERNO");*/

                SIFNegocio.Inventario.PNCNegocio negocio = new SIFNegocio.Inventario.PNCNegocio();
                string RespuestaInsertaMsg = "";
                decimal inserta = negocio.EliminarCaducidades(FolioDocumento.Split('-')[0], Lote_documento, Helpers.Sesion.Usuario.UsuariosID.ToString(), out RespuestaInsertaMsg);
                this.Back();
            }
        }

        private void dateTimeInput1_ValueChanged(object sender, EventArgs e)
        {
            this.buscar();
        }

        private void dateTimeInput2_ValueChanged(object sender, EventArgs e)
        {
            this.buscar();
        }

        private void BuscaLoteLRtextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.buscar();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.BuscaLoteLRtextBoxX.Clear();
                this.buscar();
            }
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            this.guardar();
        }

        private void guardar()
        {
            //SIF.View.Inventario.AjusteAlmacenUserControl tipo_movimiento = new AjusteAlmacenUserControl();
            ListArticulosRecepcioSeleccion = (DataTable)(dataGridViewX1.DataSource);

            if (!Validar(ListArticulosRecepcioSeleccion))
                return;

            SIFNegocio.Inventario.PNCNegocio negocio = new SIFNegocio.Inventario.PNCNegocio();
            string RespuestaInsertaMsg = "";
            decimal inserta = negocio.sp_GuardadCaducidadesdeMovSalida(FolioDocumento.Split('-')[0], Lote_documento, Helpers.Sesion.Usuario.UsuariosID.ToString(),
                    L_partida,
                    L_articulo_id,
                    L_Lote_Interno,
                    L_cant_lote,
                    L_lote,
                    L_loteProdcesado,
                    L_caducidad
                , out RespuestaInsertaMsg);

            if (inserta <= 0)
            {
               MessageBox.Show(RespuestaInsertaMsg + string.Join(",",L_caducidad), "Producto No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                foreach (string _articulo in L_articulo_id)
                {
                    PintaFilaCiclo(_articulo, GuardadosRowStyle);
                    //buscar();
                }
                //   carga_lotes();
                //buscar();
            }
        }

        private bool Validar(DataTable dt)
        {
            try
            {
                short partida = 0;
                L_partida = new List<Int16>();
                L_articulo_id = new List<string>();
                L_Lote_Interno = new List<string>();
                L_cant_lote = new List<Int16>();
                L_lote = new List<string>();
                L_loteProdcesado = new List<string>();
                L_caducidad = new List<string>();

                var query = from row in dt.AsEnumerable().
                             Where(row => row.Field<string>("LOTE_INTERNO") != null)
                            group row by

                                        row.Field<string>("ARTICULO_ID") + row.Field<string>("LOTE_INTERNO") into sales
                            orderby sales.Key
                            select new
                            {
                                _articuloId = sales.Key,
                                conteo = sales.Count()
                            };

                // print result
                foreach (var repetido in query)
                {
                    if (repetido.conteo > 1)
                    {

                       MessageBox.Show("El código: " + repetido._articuloId + " contiene lotes mal asignados " + Environment.NewLine +
                            "Razones posibles: " + Environment.NewLine +
                            "Hay más de una partida del producto con el mismo lote y caducidad", "Producto No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        PintaFilaCiclo(repetido._articuloId, faltanteRowStyle);
                        return false;
                    }
                    //Console.WriteLine("{0}\t{1}", repetido._articuloId, repetido.conteo);
                }

                foreach (DataRow _dr in ListArticulosRecepcionDetalle.Rows)//ListArticulosRecepcioSeleccionOrg.Rows) 
                {
                    object objSumS = dt.Compute("Sum(CANTIDAD)", "ARTICULO_ID = '" + _dr["ARTICULO_ID"].ToString() + "'");
                    object objSumO = ListArticulosRecepcionDetalle.Compute("Sum(CANTIDAD)", "ARTICULO_ID = '" + _dr["ARTICULO_ID"].ToString() + "'");
                    if (Convert.ToInt32(objSumO) != Convert.ToInt32(objSumS))
                    {
                       MessageBox.Show(_dr["ARTICULO_ID"].ToString() + "La cantidad de asignación es diferente a la cantidad definida por el movimiento",
                            "Producto No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //PintaFilaCiclo(_dr["ARTICULO_ID"].ToString(), faltanteRowStyle);
                        //foreach (DataRow dtr in ListArticulosRecepcioSeleccion.Rows)
                        //{
                        //    if (_dr["ARTICULO_ID"] == dtr["ARTICULO_ID"])
                        //    {
                        //        _dr["CANTIDAD"] = dtr["CANTIDAD"];
                        //    }

                        //}
                        return false;
                    }
                }

                foreach (DataRow dr in dt.Rows)
                {
                    if (!String.IsNullOrEmpty(dr["LOTE_INTERNO"].ToString()))
                    {
                        partida++;
                        L_partida.Add(partida);
                        L_articulo_id.Add(dr["ARTICULO_ID"].ToString());
                        L_Lote_Interno.Add(dr["LOTE_INTERNO"].ToString());
                        L_lote.Add(dr["NO_LOTE"].ToString());
                        //L_caducidad.Add(dr["CADUCIDAD"].ToString());
                        L_caducidad.Add(dr["CADUCIDAD"].ToString().Substring(1,19));
                        L_loteProdcesado.Add("N");
                        L_cant_lote.Add(short.Parse(dr["CANTIDAD"].ToString()));
                        //total += Int32.Parse(dr["CANTIDAD"].ToString());
                    }
                }

                if (L_partida.Count <= 0)
                {
                   MessageBox.Show("Sin registros a procesar", "Producto No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                return true;
            }
            catch (Exception e) { return false; }
        }

        private void PintaFilaCiclo(string articulo_id, DataGridViewCellStyle _style)
        {
            foreach (DataGridViewRow grow in dataGridViewX1.Rows)
            {
                if (grow.Cells["ARTICULO_IDColumn"].Value.ToString() == articulo_id)
                {
                    PintaFila(grow, revisarRowStyle);
                }

            }
        }

        private void PintaFila(DataGridViewRow dgrow, DataGridViewCellStyle _style)
        {
            if (dgrow == null)
            {
                return;
            }
            var datagridRow = dgrow.DataBoundItem;

            if (!(datagridRow is DataRowView))
            {
                return;
            }

            dgrow.DefaultCellStyle = _style;
            dgrow.DefaultCellStyle.ApplyStyle(_style);
        }




    }
}
