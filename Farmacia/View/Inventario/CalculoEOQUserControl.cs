using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;
using System.IO;
using System.Text.RegularExpressions;
using Equin.ApplicationFramework;
using System.Net;
using System.Net.Sockets;


namespace SIF.View.Inventario
{
    public partial class CalculoEOQUserControl : Templates.CatalogoUserControl
    {

        private DataTable Ft;
        delegate void SetComboBoxCellType(int iRowIndex);
        private bool solicitausuario = false;
        int old_cant = 0;
        int new_cant = 0;
        List<string> _liActualizacambios = new List<string>();
        Int32[] totales = new Int32[40];
        Int64 totalPiezas = 0;
        Decimal totalCosto = 0.0M;
        int editUser = 0; //corresponde a si el usuario desea editar el archivo esto para que dos usuarios no editen el concentrado al mismo tiempo
        Int16 conteoForEach = 0;
        DataGridViewCellStyle revisarRowStyle = new DataGridViewCellStyle();
        private Int16 limitaForeach(bool inicia, bool responde)
        {
            if (inicia)
            {
                conteoForEach = 0;
                return 0;
            }
            if (responde)
            {
                conteoForEach++;
                return conteoForEach;
            }
            return -1;
        }

        private int ParseIntField(DataRow row, string colName)
        {
            if (row == null) return 0;
            if (!row.Table.Columns.Contains(colName)) return 0;
            var val = row[colName];
            if (val == null || val == DBNull.Value) return 0;
            int r;
            return int.TryParse(val.ToString().Trim(), out r) ? r : 0;
        }



        public CalculoEOQUserControl()
        {
            InitializeComponent();
            CargaTipoMedicamento();
            CargaCalculosEOQ();
            this.inicializaColoresFilas();
        }

        SIFNegocio.Inventario.EOQ eoqL = new SIFNegocio.Inventario.EOQ();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        private void CargaCalculosEOQ()
        {
            /* SIFModelo.Sucursal sucursal = sucursalComboBoxEx.SelectedItem as SIFModelo.Sucursal;

             if (sucursal == null)
             {
                MessageBox.Show("Debe elegir una sucursal", "Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 this.sucursalComboBoxEx.Focus();
                 this.sucursalComboBoxEx.DroppedDown = true;
                 return;
             }
             //dt.Clear;
             string tipoMedicamento = "%%";
             if (tipoMedicamentoComboBoxEx.SelectedItem != null)
             {
                 SIFModelo.TipoMedicamento tipo = tipoMedicamentoComboBoxEx.SelectedItem as SIFModelo.TipoMedicamento;
                 if (tipo.Clave != "%")
                     tipoMedicamento = "%" + tipo.Clave + "%";
             }*/

            //dt = eoqL.CalculoEOQ(sucursal, this.dti_EoQFecIni.Value, dti_EoQFecFin.Value, this.tb_EoQDiasSoporte.Value, tb_EoQDiasTranscurre.Value, out peridos, tipoMedicamento);
            rbCompleto.Checked = true;
            this.sp_GetMensual();
            this.cargacontroles2();
            this.carcarFiltros();

        
         
            
        }

        private void sp_GetMensual() {
            string cadena = string.Empty;
            if (textBox1.Text.Length > 0)
            {
                int i = eoqL.sp_upd_filtro(1, "");
                if (String.IsNullOrEmpty(textBox1.Text))
                {
                    cadena = " and (nombre1 like '%' or codigo like '%')";
                }
                else
                {
                    cadena = " and (nombre1 like '%" + textBox1.Text + "%' or codigo like '%" + textBox1.Text + "%') ";

                }
                
            }
            if (rbCompleto.Checked) {
                cadena += "";
            }
            else {
                cadena += " and total>0 ";
            }
            switch (filtroComboBoxEx.Text ) {
                case "ACTIVOS":
                    cadena += " and ACTIVO='S' ";
                    break;
                case "INACTIVOS":
                    cadena += " and ACTIVO='N' ";
                    break;
            }

            dataGridViewX1.Refresh();
            ds = eoqL.get_EoqMes( cadena);
            dataGridViewX1.DataMember = "Eoq";
            this.dataGridViewX1.DataSource = ds;
            this.calculaTotal();
        }
        private void activaedicion(bool valor) {


   dataGridViewX1.Columns["02_CAP"].ReadOnly =valor;
   dataGridViewX1.Columns["03_MAT"].ReadOnly =valor;
   dataGridViewX1.Columns["04_POP"].ReadOnly =valor;
   dataGridViewX1.Columns["05_TEC"].ReadOnly =valor;
   dataGridViewX1.Columns["06_CHO"].ReadOnly =valor;
   dataGridViewX1.Columns["07_CEN"].ReadOnly =valor;
   dataGridViewX1.Columns["08_BEN"].ReadOnly =valor;
   dataGridViewX1.Columns["09_CU"].ReadOnly =valor;
   dataGridViewX1.Columns["10_GPE"].ReadOnly =valor;
   dataGridViewX1.Columns["11_AMA"].ReadOnly =valor;
   dataGridViewX1.Columns["12_ACA"].ReadOnly =valor;
   dataGridViewX1.Columns["17_SMT"].ReadOnly =valor;
   dataGridViewX1.Columns["18_CCU"].ReadOnly =valor;
   dataGridViewX1.Columns["20_TRR"].ReadOnly =valor;
   dataGridViewX1.Columns["21_STA"].ReadOnly =valor;

            dataGridViewX1.Columns["22_TLX"].ReadOnly = valor;
            dataGridViewX1.Columns["24_IZU"].ReadOnly = valor;
            dataGridViewX1.Columns["25_DIG"].ReadOnly = valor;
            dataGridViewX1.Columns["26_PZO"].ReadOnly = valor;







        }
        private void cargacontroles2()
        {


            //dataGridViewX1.DataMember = "Eoq";
            dataGridViewX1.Columns["CODIGO"].ReadOnly = true;
            dataGridViewX1.Columns["NOMBRE1"].ReadOnly = true;
            dataGridViewX1.Columns["TIPO3"].ReadOnly = true;
            dataGridViewX1.Columns["EXISTENCIAS_CDIS"].ReadOnly = true;
            dataGridViewX1.Columns["PRECIO_VENTA"].ReadOnly = true;
            dataGridViewX1.Columns["PRECIO_COSTO"].ReadOnly = true;

            dataGridViewX1.Columns["NOMBRE2"].ReadOnly = true;
            dataGridViewX1.Columns["ACTIVO"].ReadOnly = true;
            dataGridViewX1.Columns["FECHA_ULT_COMPRA"].ReadOnly = true;
            

            



            dataGridViewX1.Columns["TOTAL"].ReadOnly = true;
            dataGridViewX1.Columns["TOTAL"].Frozen = true;
            dataGridViewX1.Columns["CODIGO"].Frozen = true;
            dataGridViewX1.Columns["NOMBRE1"].Frozen = true;

            activaedicion(true);





        }

        private void CargaTipoMedicamento()
        {
            List<SIFModelo.TipoMedicamento> tiposMedicamento = new SIFNegocio.TipoMedicamento().Buscar("", "").DataSource as List<SIFModelo.TipoMedicamento>;


            foreach (SIFModelo.TipoMedicamento tipo in tiposMedicamento)
            {
                tipo.Nombre = tipo.Clave + " - " + tipo.Nombre;
            }

            SIFModelo.TipoMedicamento todos = new SIFModelo.TipoMedicamento() { Clave = "%", ID = 0, Activo = SIFModelo.Tipos.SiNo.SI, Nombre = "[TODOS]", Receta = SIFModelo.Tipos.SiNo.NO };
            tiposMedicamento.Add(todos);

            this.tipoMedicamentoComboBoxEx.DataSource = tiposMedicamento;
            tipoMedicamentoComboBoxEx.DisplayMember = "Nombre";
            tipoMedicamentoComboBoxEx.ValueMember = "Clave";
            tipoMedicamentoComboBoxEx.SelectedItem = todos;

            filtroComboBoxEx.Items.Add("TODOS");
            filtroComboBoxEx.Items.Add("ACTIVOS");
            filtroComboBoxEx.Items.Add("INACTIVOS");
            filtroComboBoxEx.SelectedIndex = 1;



        }

        private void CargaSucursales()
        {
            BindingList<SIFModelo.Sucursal> sucursales = new BindingList<SIFModelo.Sucursal>();
            //SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { Nombre = "[TODAS]", SucursalesID = 0 };
            //sucursales.Add(sucursal);
            //sucursales.ToList();d
            List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().Buscar("", "").DataSource as List<SIFModelo.Sucursal>;

            foreach (SIFModelo.Sucursal sucursalBd in sucursalesBD)
            {
                sucursales.Add(sucursalBd);
            }

            this.sucursalComboBoxEx.DataSource = sucursales;
            sucursalComboBoxEx.DisplayMember = "NOMBRE";
            sucursalComboBoxEx.ValueMember = "SUCURSALESID";
            Ft = eoqL.FactorEoQ();


            sucursalComboBoxEx.SelectedValue = Helpers.Sesion.Sucursal.SucursalesID;

            dataGridViewX2.DataSource = Ft;
        }

        private string peridos;
        public void InitializeDataGridViewCalculoEoQ(DataGridViewX dgv, string HdrCols, int nCols)
        {
            if (dgv.Columns.Count == 0)
            {
                return;
            }
            int PerCol = dgv.ColumnCount - 10;
            int ind = 2;

            DataGridViewIntegerInputColumn ColCantidad = new DataGridViewIntegerInputColumn();

            dgv.Columns[0].Frozen = true;
            dgv.Columns[0].HeaderText = "Código";
            dgv.Columns[0].ReadOnly = true;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[0].Name = "Col_CodigoArtEoQ";
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            dgv.Columns[1].Frozen = true;
            dgv.Columns[1].HeaderText = "Descripción";
            dgv.Columns[1].ReadOnly = true;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[1].Name = "Col_DescArtEoQ";
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            for (ind = 2; ind < PerCol; ind++)
            {
                dgv.Columns[ind].Frozen = true;
                dgv.Columns[ind].ReadOnly = true;
                dgv.Columns[ind].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[ind].Name = "Col_Periodo" + ind;
                dgv.Columns[ind].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }

            dgv.Columns[ind].Frozen = true;
            dgv.Columns[ind].HeaderText = "Total";
            dgv.Columns[ind].ReadOnly = true;
            dgv.Columns[ind].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[ind].Name = "Col_TotalVtas";
            dgv.Columns[ind].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            //dgv.Columns[ind].Visible = false;

            dgv.Columns[ind + 1].Frozen = false;
            dgv.Columns[ind + 1].HeaderText = "Ult. Movimiento";
            dgv.Columns[ind + 1].ReadOnly = true;
            dgv.Columns[ind + 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[ind + 1].Name = "Col_UltMov";
            dgv.Columns[ind + 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader; // .ColumnHeader;
            dgv.Columns[ind + 1].Visible = true;

            dgv.Columns[ind + 2].Frozen = false;
            dgv.Columns[ind + 2].HeaderText = "Faltante";
            dgv.Columns[ind + 2].ReadOnly = true;
            dgv.Columns[ind + 2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[ind + 2].Name = "Col_FaltanteVtas";
            dgv.Columns[ind + 2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgv.Columns[ind + 3].Frozen = false;
            dgv.Columns[ind + 3].HeaderText = "Existencia";
            dgv.Columns[ind + 3].ReadOnly = true;
            dgv.Columns[ind + 3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[ind + 3].Name = "Col_ExistenciaVtas";
            dgv.Columns[ind + 3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgv.Columns[ind + 4].Frozen = false;
            dgv.Columns[ind + 4].HeaderText = "Precio";
            dgv.Columns[ind + 4].ReadOnly = true;
            dgv.Columns[ind + 4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[ind + 4].Name = "Col_PrecioArt";
            dgv.Columns[ind + 4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader; // .ColumnHeader;
            dgv.Columns[ind + 4].Visible = true;

            dgv.Columns[ind + 5].Frozen = false;
            dgv.Columns[ind + 5].HeaderText = "Costo";
            dgv.Columns[ind + 5].ReadOnly = true;
            dgv.Columns[ind + 5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[ind + 5].Name = "Col_CostoArt";
            dgv.Columns[ind + 5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // .ColumnHeader;
            dgv.Columns[ind + 5].Visible = true;



            //dgv.Columns.Remove("Tipo");


            //DataGridViewComboBoxColumn Columna = new DataGridViewComboBoxColumn();
            //     Ft= eoqL.FactorEoQ();

            //     Columna.DataSource = Ft;
            //     Columna.DisplayMember = "Factor_ID";
            //     Columna.DataPropertyName = "Tipo";
            //     Columna.ValueMember = "Factor_ID";
            //     Columna.HeaderText = "Tipo";
            //     Columna.Name = "Col_TipoArt";
            //     Columna.Frozen = false;
            //     Columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //     dgv.Columns.Insert(ind + 6, Columna);



            dgv.Columns[ind + 7].Frozen = false;
            dgv.Columns[ind + 7].HeaderText = "Factor";
            //  dgv.Columns[ind + 7].ReadOnly = false;
            dgv.Columns[ind + 7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[ind + 7].Name = "Col_FactorArt";
            dgv.Columns[ind + 7].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgv.Columns[ind + 7].Visible = true;

            if (dgv.Columns.Count <= (ind + 8))
            {
                return;
                dgv.Columns.Add(new DataGridViewColumn());
                dgv.Columns.Add(new DataGridViewColumn());
            }

            dgv.Columns[ind + 8].Frozen = false;
            dgv.Columns[ind + 8].HeaderText = "EoQ Inventario";
            dgv.Columns[ind + 8].ReadOnly = false;
            dgv.Columns[ind + 8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[ind + 8].Name = "Col_EoQArtInventario";
            dgv.Columns[ind + 8].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgv.Columns[ind + 8].DataPropertyName = "EoQ_Inventario";
            dgv.Columns[ind + 8].Visible = true;

            dgv.Columns[ind + 9].Frozen = false;
            dgv.Columns[ind + 9].HeaderText = "EoQ Calculado";
            //dgv.Columns[ind + 9].ReadOnly = false;
            dgv.Columns[ind + 9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[ind + 9].Name = "Col_EoQArt";
            dgv.Columns[ind + 9].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgv.Columns[ind + 9].DataPropertyName = "EoQ";
            dgv.Columns[ind + 9].Visible = true;


        }

        bool bIsComboBox = false;
        private void ChangeCellToComboBox(int iRowIndex)
        {
            if (bIsComboBox == false)
            {
                DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

                Ft = eoqL.FactorEoQ();

                dgComboCell.DataSource = Ft;
                dgComboCell.ValueMember = "Tipo";
                dgComboCell.DisplayMember = "Tipo";

                dataGridViewX1.Rows[iRowIndex].Cells[dataGridViewX1.CurrentCell.ColumnIndex] = dgComboCell;
                bIsComboBox = true;
            }
        }

        private void AutoNumberRowsForGridView(DataGridView dataGridView)
        {
            if (dataGridView != null)
            {
                for (int count = 0; (count <= (dataGridView.Rows.Count - 1)); count++)
                {
                    // dataGridView.Rows[count].HeaderCell.Value = string.Format((count + 1).ToString(), "0");
                    dataGridView.Rows[count].HeaderCell.Value = (count + 1).ToString().PadLeft(2, '0');
                }
            }
        }

        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.CargaCalculosEOQ();
        }

        public Menu.InventarioMenu Owner { get; set; }
        public bool Mostrado = false;
        internal void Muestra()
        {
            if (Mostrado)
            {
                return;
            }

            this.Dock = DockStyle.Fill;
            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.ActivaComandos();
            this.CargaSucursales();
            this.Owner.DesactivaComandos();
            Mostrado = true;
        }

        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
        }

        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
        }

        private void Back()
        {
            try

            {
                this.GuardaEOQ();
                SIFNegocio.Inventario.EOQ snieoq = new SIFNegocio.Inventario.EOQ();
                snieoq.EditaEoq(SIF.Helpers.Sesion.Usuario.UsuariosID, 0);
                Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.DesactivaComandos();
                this.Owner.ActivaComandos();
                Mostrado = false;
            }
            catch { }
        }

        private void dti_EoQFecIni_ValueChanged(object sender, EventArgs e)
        {
            if (dti_EoQFecFin.Value < dti_EoQFecIni.Value)
            {
               MessageBox.Show("Fecha Final NO puede ser menor a la Fecha inicio", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                tb_EoQDiasTranscurre.Value = SIFNegocio.Helpers.SifUtils.DaysBetweenDates(dti_EoQFecIni.Value, dti_EoQFecFin.Value);
            }
        }

        private void dti_EoQFecFin_ValueChanged(object sender, EventArgs e)
        {
            if (dti_EoQFecFin.Value < dti_EoQFecIni.Value)
            {
               MessageBox.Show("Fecha Final NO puede ser menor a la Fecha inicio", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                tb_EoQDiasTranscurre.Value = SIFNegocio.Helpers.SifUtils.DaysBetweenDates(dti_EoQFecIni.Value, dti_EoQFecFin.Value);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                   string s = "\"";
                    s += dataGridViewX1.Columns[e.ColumnIndex].HeaderText;
                    s += "\"";
                    string _codigo = dataGridViewX1.Rows[e.RowIndex].Cells["CODIGO"].Value.ToString();
                    new_cant = int.Parse(dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    _liActualizacambios.Add("UPDATE eoq_mensual_suc_recibidos  set " + s + " =" + new_cant + " WHERE CODIGO ='" + _codigo + "'");
            }
            catch {

            }
            
        }

        private void dataGridViewX2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // actualizamos los datos en la tabla
            DataGridViewX grid = sender as DataGridViewX;
            if (e.ColumnIndex == 1)
            {
                DataRow Rd = Ft.Rows.Find(grid[0, e.RowIndex].Value.ToString());
                eoqL.ActualizaFactor(Rd);
                CargaCalculosEOQ();
            }
        }

        private void dataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                DataObject d = dataGridViewX1.GetClipboardContent();
                if (d == null) { return; }
                Clipboard.SetDataObject(d);
            }
        }

        private void dataGridViewX2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                DataObject d = dataGridViewX2.GetClipboardContent();
                if (d == null) { return; }
                Clipboard.SetDataObject(d);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CalculoEOQUserControl_Load(object sender, EventArgs e)
        {
            dti_EoQFecFin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            dti_EoQFecIni.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
        }

        private void dataGridViewX1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX1.Columns.Contains("Tipo"))
            {
                SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
                if (e.ColumnIndex == this.dataGridViewX1.Columns["Tipo"].Index)
                {
                    this.dataGridViewX1.BeginInvoke(objChangeCellType, e.RowIndex);
                    bIsComboBox = false;
                }
            }
        }

        private void GuardaEOQ()
        {
            if (_liActualizacambios.Count > 0) {
                SIFNegocio.Inventario.EOQ eoqL = new SIFNegocio.Inventario.EOQ();
                bool guardado =eoqL.actualizaModificaciones(_liActualizacambios);
                if (!guardado) {
                    MessageBox.Show("No se guardaron los datos favor de verificar los articulos modificados");
                }
            }
            _liActualizacambios=new List<string>();
        }


        private void actualizarEOQ()
        {
            if (MessageBox.Show("EstaaccionvadesarrollarvariasmodificacionesasuSistema recalculandolos puntos:" +
                Environment.NewLine + "1.- Actualizacion de punto de reorden en el cdis" +
                Environment.NewLine + "2.- Modificacion de eoq en sucursales" +
                Environment.NewLine + "Pasos que ejecutara" +
                Environment.NewLine + "1.- Procesar- procesa los datos de una tabla externa que conieene el concentrado de eoq de precios(Archivo Excel)" +
                Environment.NewLine + "2.- Aplicar- actualiza los datods a  concentrado para su validacion" +
                Environment.NewLine + "3.- Actualizar - actualiza el punto de reorden del inventario ", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning

                ) == DialogResult.Cancel)
                return;

            string rAplicar = this.importarConsEoq();
            if (MessageBox.Show(rAplicar + Environment.NewLine + "Desea continuar  con la operacion", "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            string rProcesado =procesarEoq();
            if (MessageBox.Show(rProcesado + Environment.NewLine + "Desea continuar  con la operacion", "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            

            var res =MessageBox.Show("¿Desea pasar la información de la columna \"EOQ calculado\" a la columna \"EOQ inventario\" ?", "Actualizar EOQ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                SIFNegocio.Inventario.EOQ snieoq = new SIFNegocio.Inventario.EOQ();
                string resul = snieoq.spActualizaConcentradoEoq();
                MessageBox.Show(resul.ToString(), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            /*foreach (DataRow row in dt.Rows)
            {
                row["eoq_inventario"] = row["eoq"];
            }*/

        }

        private void guardarButtonItem_Click(object sender, EventArgs e)
        {
            this.refrescar();
        }

        private void actualizarButtonItem_Click(object sender, EventArgs e)
        {
            actualizarEOQ();
        }

        private void generaConcentradoButtonItem_Click(object sender, EventArgs e) {
            
            this.generaConcentrado();
            this.ExportarArchivo();
            this.refrescar();
        }
        private void ExportarArchivo()
        {
            

            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    /*
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();

                    libros_trabajo = aplicacion.Workbooks.Add();

                    System.Data.DataTable dt = new System.Data.DataTable();
                    bool catalogocompleto = false;
                    if (DialogResult.Yes ==
                       MessageBox.Show("Deseas exportar todo el catalogo?"+
                        Environment.NewLine+"Si preciona Yes se exportara el catalogo con y sin eoq"
                        , "Catalogo completo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        catalogocompleto = true;


                    }
                    dt = eoqL.ExportaEoqXls(catalogocompleto);
                    //  libros_trabajo.Worksheets.Add(dt, "Eoq");
                    ///*
                    ///

                    Extras.ProgresoExpImpFileExcel  frm = new Extras.ProgresoExpImpFileExcel(dt, fichero.FileName);
                    frm.ShowDialog();
                    */
                   // List<String> reportesList = new List<string>();
                   // reportesList = new SIFNegocio.ReportesAdmin.ReportesV1().GetReportesResultQuery("SELECT * FROM ");


                }
                catch (Exception e)
                {
                    MessageBox.Show("No se pudo Exportar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void editarButtonItem_Click(object sender, EventArgs e)
        {

            /*this.generaConcentrado();
            this.refrescar();*/

            editUser=(editUser == 0)?1:0;
            this.editar();
        }
        private void editar() {
            SIFNegocio.Inventario.EOQ snieoq = new SIFNegocio.Inventario.EOQ();
            string resp = snieoq.EditaEoq(SIF.Helpers.Sesion.Usuario.UsuariosID,   editUser);
            if (resp.Contains(SIF.Helpers.Sesion.Usuario.UsuariosID.ToString()))
            {
                MessageBox.Show(resp, "Informacion",MessageBoxButtons.OK, MessageBoxIcon.Information);
                activaedicion(false);

            }
            else {
                MessageBox.Show(resp,"Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                activaedicion(true);
            }

            


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Cambios JMQC
        private void ImportarConsButtonItem_Click(object sender, EventArgs e)
        {
           // this.importarConsEoq();
        }

        private string 
            importarConsEoq()
        {
            SIFNegocio.Inventario.EOQ snieoq = new SIFNegocio.Inventario.EOQ();
            return snieoq.spAplicaArchivoImp();
            //MessageBox.Show(resul.ToString(), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void generaConcentrado()
        {
            if (DialogResult.OK == MessageBox.Show("Actualizara el eoq mensual del servidor remoto, desea continuar?", "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                try
                {



                    this.checkedListBox1.DataSource = new List<String>();

                    SIFNegocio.Inventario.EOQ snieoq = new SIFNegocio.Inventario.EOQ();
                    string resul = snieoq.spGeneraConcentradoMensual(SIF.Helpers.Sesion.Usuario.UsuariosID);
                    MessageBox.Show(resul.ToString(), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        //private void cargaTipoMedicamento


        private void procesarButtonItem_Click(object sender, EventArgs e)
        {
           // procesarEoq();
        }


        private string  procesarEoq() {
            SIFNegocio.Inventario.EOQ snieoq = new SIFNegocio.Inventario.EOQ();
            //return snieoq.spProcesaConcentradoEoq(); 
            string resul = snieoq.spProcesaConcentradoEoq();
            MessageBox.Show(resul.ToString(), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return resul;
        }


        private void filtroComboBoxEx_SelectedValueChanged(object sender, EventArgs e)
        {
            /*if (fabricanteComboBoxEx.SelectedValue != null)
                lineaTextBoxX.Text = fabricanteComboBoxEx.SelectedValue.ToString();*/
        }


        #endregion

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void refrescar()
        {
            this.GuardaEOQ();
            this.carcarFiltros();
            this.sp_GetMensual();
            


        }


        private void carcarFiltros()
        {
            string cadenaExe = string.Empty;
            if (checkedListBox1.Items.Count > 0)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i) == false)
                    {
                        SIFModelo.Inventarios.filtrosEoq md = (SIFModelo.Inventarios.filtrosEoq)checkedListBox1.Items[i];
                        //  MessageBox.Show("This is the value of ceckhed Item " + myCheckedListBox.Items[i].ToString());cadenaExe+="'"+md.tipo3+"',";
                        cadenaExe += "'" + md.tipo3 + "',";

                    }

                }

                if (!String.IsNullOrEmpty(cadenaExe))
                {
                    string sub = cadenaExe.Substring(0, cadenaExe.Length - 1);
                    cadenaExe = " and tipo3 in (" + sub + ")";
                    int i = eoqL.sp_upd_filtro(0, cadenaExe);
                }
                cadenaExe = string.Empty;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i) == true)
                    {
                        SIFModelo.Inventarios.filtrosEoq md = (SIFModelo.Inventarios.filtrosEoq)checkedListBox1.Items[i];
                        //  MessageBox.Show("This is the value of ceckhed Item " + myCheckedListBox.Items[i].ToString());cadenaExe+="'"+md.tipo3+"',";
                        cadenaExe += "'" + md.tipo3 + "',";

                    }

                }

                
            }
                List<SIFModelo.Inventarios.filtrosEoq> tipo3filtrado = new SIFNegocio.Inventario.EOQ().BuscarfiltrosEoq().DataSource as List<SIFModelo.Inventarios.filtrosEoq>;

                this.checkedListBox1.DataSource = tipo3filtrado;
                checkedListBox1.DisplayMember = "tipo3";
                checkedListBox1.ValueMember = "id";
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    SIFModelo.Inventarios.filtrosEoq md = (SIFModelo.Inventarios.filtrosEoq)checkedListBox1.Items[i];
                    if (md.filtro == 1)
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }
            
        }

        private void buscar2ButtonX_Click(object sender, EventArgs e)
        {
            //actualizarArticulo();
            this.refrescar();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {

                    checkedListBox1.SetItemChecked(i, false);

                }
            }

        }

        private void dataGridViewX1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)

        {
          if (e.KeyCode == Keys.Enter)
                this.refrescar();
            

        }

        private void calculaTotal()
        {
            for (int i= 0; i < totales.Length; i++) {
                totales[i] = 0;
            }
            totalPiezas = 0;
            totalCosto = 0.0M;
            totales[2] = 0;
            foreach (DataGridViewRow dr  in dataGridViewX1.Rows) {
                
                if (dr.Cells["TIPO3"].Value.ToString().Contains("BAJA") || dr.Cells["TIPO3"].Value.ToString().Contains("FALTANTE") || dr.Cells["TIPO3"].Value.ToString().Contains("DESCONTINUADO")|| dr.Cells["ACTIVO"].Value.ToString().Contains("N")) {

                    DataGridViewRow GridRow = this.dataGridViewX1.Rows[dr.Index];

                    GridRow.DefaultCellStyle = revisarRowStyle;
                    GridRow.DefaultCellStyle.ApplyStyle(revisarRowStyle);
                }

                totales[2] += int.Parse(dr.Cells["02_CAP"].Value.ToString());
                totales[3] += int.Parse(dr.Cells["03_MAT"].Value.ToString());
                totales[4] += int.Parse(dr.Cells["04_POP"].Value.ToString());
                totales[5] += int.Parse(dr.Cells["05_TEC"].Value.ToString());
                totales[6] += int.Parse(dr.Cells["06_CHO"].Value.ToString());
                totales[7] += int.Parse(dr.Cells["07_CEN"].Value.ToString());
                totales[8] += int.Parse(dr.Cells["08_BEN"].Value.ToString());
                totales[9] += int.Parse(dr.Cells["09_CU"].Value.ToString());
                totales[10] += int.Parse(dr.Cells["10_GPE"].Value.ToString());
                totales[11] += int.Parse(dr.Cells["11_AMA"].Value.ToString());
                totales[12] += int.Parse(dr.Cells["12_ACA"].Value.ToString());
                totales[17] += int.Parse(dr.Cells["17_SMT"].Value.ToString());
                totales[18] += int.Parse(dr.Cells["18_CCU"].Value.ToString());
                totales[20] += int.Parse(dr.Cells["20_TRR"].Value.ToString());
                totales[21] += int.Parse(dr.Cells["21_STA"].Value.ToString());
                totales[22] += int.Parse(dr.Cells["22_TLX"].Value.ToString());                
                totales[24] += int.Parse(dr.Cells["24_IZU"].Value.ToString());
                totales[25] += int.Parse(dr.Cells["25_DIG"].Value.ToString());
                totales[26] += int.Parse(dr.Cells["26_PZO"].Value.ToString());

                totalPiezas += int.Parse(dr.Cells["TOTAL"].Value.ToString());
                totalCosto += Decimal.Parse(dr.Cells["PRECIO_COSTO"].Value.ToString());


            }

            lbl2.Text = "Cap: " + totales[2].ToString();
            lbl3.Text = "Mat: " + totales[3].ToString();
            lbl4.Text = "Pop: " + totales[4].ToString();
            lbl5.Text = "Tec: " + totales[5].ToString();
            lbl6.Text = "Cho: " + totales[6].ToString();
            lbl7.Text = "Cen: " + totales[7].ToString();
            lbl8.Text = "Ben: " + totales[8].ToString();
            lbl9.Text = "Cu: " + totales[9].ToString();
            lbl10.Text = "Gpe: " + totales[10].ToString();
            lbl11.Text = "Ama: " + totales[11].ToString();
            lbl12.Text = "Aca: " + totales[12].ToString();
            lbl17.Text = "Smt: " + totales[17].ToString();
            lbl18.Text = "Ccu: " + totales[18].ToString();
            lbl20.Text = "Trr: " + totales[20].ToString();
            lbl21.Text = "Sta: " + totales[21].ToString();
            lbl24.Text="Izu: "+ totales[24].ToString();

            lblTotalCosto.Text = "$ "+totalCosto.ToString();

             lblTotalP.Text= "Pzas: "+totalPiezas.ToString();

            
        }

        private void inicializaColoresFilas()
        {
            revisarRowStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            revisarRowStyle.BackColor = Color.FromArgb(247, 115, 117);
            //revisarRowStyle.BackColor.Color2 = Color.FromArgb(255, 35, 35);
/*
            WarningCellStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            WarningCellStyle.BackColor = Color.FromArgb(253, 215, 0);
            //WarningCellStyle.BackColor.Color2 = Color.FromArgb(253, 215, 0);

            margenRowStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            margenRowStyle.BackColor = Color.FromArgb(200, 100, 100);
            //margenRowStyle.BackColor.Color2 = Color.FromArgb(200, 100, 100);

            faltanteRowStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            faltanteRowStyle.BackColor = Color.FromArgb(0, 176, 80);
            //faltanteRowStyle.Background.Color2 = Color.FromArgb(0, 176, 80);

            normalRowStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            normalRowStyle = this.dataGridViewX1.DefaultCellStyle;*/
        }
        private void importarButtonItem_Click(object sender, EventArgs e)
        {
            this.importaEoqMod();
        }
        private void importaEoqMod()
        {
            SIFNegocio.Articulo art = new SIFNegocio.Articulo();
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Seleccione el archivo a Procesar";
            fdlg.Filter = "CSV files (*.CSV)|*.csv";
            fdlg.RestoreDirectory = true;
            bool FmtValid = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                SIFNegocio.Subrogacion.Factura insr = new SIFNegocio.Subrogacion.Factura();
                System.Data.DataTable dtPedido = new System.Data.DataTable();
                dtPedido.Columns.Add("codigo", typeof(string));         //Corresponde al codigo del Articulo                
                dtPedido.Columns.Add("cap", typeof(string));
                dtPedido.Columns.Add("mat", typeof(string));
                dtPedido.Columns.Add("pop", typeof(string));
                dtPedido.Columns.Add("tec", typeof(string));
                dtPedido.Columns.Add("cho", typeof(string));
                dtPedido.Columns.Add("cen", typeof(string));
                dtPedido.Columns.Add("ben", typeof(string));
                dtPedido.Columns.Add("cu", typeof(string));
                dtPedido.Columns.Add("gpe", typeof(string));
                dtPedido.Columns.Add("ama", typeof(string));
                dtPedido.Columns.Add("aca", typeof(string));
                dtPedido.Columns.Add("smt", typeof(string));
                dtPedido.Columns.Add("ccu", typeof(string));
                //dtPedido.Columns.Add("trr", typeof(Int32));
                dtPedido.Columns.Add("stn", typeof(string));
                dtPedido.Columns.Add("izu", typeof(string));
                //dtPedido.Columns.Add("dia", typeof(Int32));
               // dtPedido.Columns.Add("po", typeof(Int32));
                dtPedido.Columns.Add("tep", typeof(string));
                dtPedido.Columns.Add("hjz", typeof(string));
                //dtPedido.Columns.Add("chg", typeof(Int32));
                dtPedido.Columns.Add("atl", typeof(string));
                // Reutilizar la tabla creada arriba: limpiar y definir columnas exactas
               


                StreamReader reader = StreamReader.Null;
                string str = null;
                int Regs = 0;
                string FName = fdlg.SafeFileName;
                string FPath = Path.GetDirectoryName(fdlg.FileName);
                string FExt = Path.GetExtension(FName);
                Regex objNotNumPattern = new Regex(@"[^0-9]");
                Regex objNotAlphaPattern = new Regex(@"[^a-zA-Z0-9\s]");
                try
                {

                    // Valida formato de archivo
                    reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
                    List<String> listaInex = new List<string>();
                    List<String> listaInexTemp = new List<string>();
                    List<String> listaInexReplazo = new List<string>();//contien los codigos de remplazo
                    bool cantidadValida = true;
                    
                    while ((str = reader.ReadLine()) != null)
                    {
                        var parts = str.Split(',');
                        int x = parts.Length;
                        // ahora esperamos 19 columnas: ArtId + Cant2,3,4,5,6,7,8,9,10,11,12,17,18,21,24,29,31,37
                        if (x != 19)
                        {
                            FmtValid = false;
                            MessageBox.Show("El formato de Archivo " + FName + " es Invalido" + Environment.NewLine + "El archivo debe contener 19 columnas: ArtId + 18 cantidades");
                            break;
                        }
                        // Valida que las columnas numericas sean enteros o vacias
                        for (int idx = 1; idx < 19; idx++)
                        {
                            string val = parts[idx].Trim();
                            if (val.Length == 0) continue; // tratar vacio como 0
                            int tmp;
                            if (!int.TryParse(val, out tmp))
                            {
                                cantidadValida = false;
                                MessageBox.Show("La cantidad '" + val + "' no es valida en la linea: " + (Regs + 1));
                                break;
                            }
                        }
                        if (!cantidadValida) break;

                        string codigo = parts[0];
                        SIFModelo.Articulo Exs = art.BuscarPorClaveActivo(codigo);
                        if (Exs == null)
                        {
                            listaInex.Add(str);
                            //FmtValid = false;
                        }
                        else
                        {
                            // Agregar solo 19 columnas esperadas
                            dtPedido.Rows.Add(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7], parts[8], parts[9], parts[10], parts[11], parts[12], parts[13], parts[14], parts[15], parts[16], parts[17], parts[18]);
                             Regs++;
                        }

                    }
                    if ((!FmtValid) || !cantidadValida)
                    {
                        return;
                    }

                    Int16 ArticulosInex2 = 0;


                    if (listaInex.Count > 0)
                    {
                        string msg = string.Empty;
                        msg += "No existen los codigos:" + Environment.NewLine;
                        foreach (string s in listaInex)
                        {
                            msg += s.ToString() + Environment.NewLine;
                            if (this.limitaForeach(false, true) > 20)
                            {
                                msg += "..................." + Environment.NewLine;
                                this.limitaForeach(true, false);
                                break;
                            }


                        }

                        MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "Favor de validar el codigo correcto!", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else
                    {
                        FmtValid = true;
                    }

                    // Lee archivo

                    if (FmtValid)
                    {
                        reader.Close();
                        reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
                      

                        DataRow[] results = dtPedido.Select(null, "codigo");



                        String[] Clave = new String[results.Length];
                        int[] arraycap = new int[results.Length];
                        int[] arraymat = new int[results.Length];
                        int[] arraypop = new int[results.Length];
                        int[] arraytec = new int[results.Length];
                        int[] arraycho = new int[results.Length];
                        int[] arraycen = new int[results.Length];
                        int[] arrayben = new int[results.Length];
                        int[] arraycu = new int[results.Length];
                        int[] arraygpe = new int[results.Length];
                        int[] arrayama = new int[results.Length];
                        int[] arrayaca = new int[results.Length];
                        int[] arraysmt = new int[results.Length];
                        int[] arrayccu = new int[results.Length];
                        int[] arraytrr = new int[results.Length];
                        int[] arraystn = new int[results.Length];
                        int[] arrayizu = new int[results.Length];
                        int[] arraydia = new int[results.Length];
                        int[] arraypo = new int[results.Length];
                        int[] arraytep = new int[results.Length];
                        int[] arrayhjz = new int[results.Length];
                        int[] arraychg = new int[results.Length];
                        int[] arrayatl = new int[results.Length];

                        int ind = 0;

                        foreach (DataRow rows in dtPedido.Rows)
                        {
                            Clave[ind] = rows["codigo"].ToString().Trim();
                            // Use safe parser to avoid format exceptions and ensure correct mapping
                            arraycap[ind] = ParseIntField(rows, "cap");      // 02_CAP
                            arraymat[ind] = ParseIntField(rows, "mat");      // 03_MAT
                            arraypop[ind] = ParseIntField(rows, "pop");      // 04_POP
                            arraytec[ind] = ParseIntField(rows, "tec");      // 05_TEC
                            arraycho[ind] = ParseIntField(rows, "cho");      // 06_CHO
                            arraycen[ind] = ParseIntField(rows, "cen");      // 07_CEN
                            arrayben[ind] = ParseIntField(rows, "ben");      // 08_BEN
                            arraycu[ind] = ParseIntField(rows, "cu");        // 09_CU
                            arraygpe[ind] = ParseIntField(rows, "gpe");      // 10_GPE
                            arrayama[ind] = ParseIntField(rows, "ama");      // 11_AMA
                            arrayaca[ind] = ParseIntField(rows, "aca");      // 12_ACA
                            arraysmt[ind] = ParseIntField(rows, "smt");      // 17_SMT
                            arrayccu[ind] = ParseIntField(rows, "ccu");      // 18_CCU
                            // _20 (TRR) not provided in this CSV format -> set 0
                            arraytrr[ind] = 0;
                            // _21 (STA)
                            arraystn[ind] = ParseIntField(rows, "stn");      // 21_STA
                            // _24 (IZU)
                            arrayizu[ind] = ParseIntField(rows, "izu");      // 24_IZU
                            // _25 and _26 not provided -> 0
                            arraydia[ind] = 0; // 25_DIG
                            arraypo[ind] = 0;  // 26_PZO
                            // _29 and _31 from CSV
                            arraytep[ind] = ParseIntField(rows, "tep");      // 29_TEP
                            arrayhjz[ind] = ParseIntField(rows, "hjz");      // 31_HJZ
                            // _51 not provided -> 0
                            arraychg[ind] = 0;                                // 51_CHG
                            // ATL
                            arrayatl[ind] = ParseIntField(rows, "atl");     // 37_ATL

                            ind++;
                        }
                        
                        SIFNegocio.Inventario.EOQ snieoq = new SIFNegocio.Inventario.EOQ();


                        string resul = snieoq.insertaEoqImpFile(
                               Clave,
                            arraycap,
                            arraymat,
                            arraypop,
                            arraytec,
                            arraycho,
                            arraycen,
                            arrayben,
                            arraycu,
                            arraygpe,
                            arrayama,
                            arrayaca,
                            arraysmt,
                            arrayccu,
                            arraytrr,
                            arraystn,
                            arrayizu,
                            arraydia,
                            arraypo,
                            arraytep,
                            arrayhjz,
                            arraychg,
                            arrayatl

                             );
                        MessageBox.Show(resul, "Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    reader.Close();
                }
            }
        }

    }
}
