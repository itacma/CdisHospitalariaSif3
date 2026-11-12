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
    public partial class frmCapturaCaducidades : DevComponents.DotNetBar.Metro.MetroForm
    {
        DataGridViewCellStyle revisarRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle margenRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle faltanteRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle SobranteRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle normalRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle WarningCellStyle = new DataGridViewCellStyle();

        SIFNegocio.caducidades cadNego = new SIFNegocio.caducidades();
        SIFModelo.Usuario _user = new SIFModelo.Usuario();
        string _docmuento = string.Empty;
        int _id_movimiento = 0;
        SIFModelo.Inventarios.SkuCaducidad _skuCad = new SIFModelo.Inventarios.SkuCaducidad();
        DataTable dt = new DataTable();

        public frmCapturaCaducidades(SIFModelo.Usuario user, string folioDocumento, int id_movimiento)
        {
            _user = user;
            _docmuento = folioDocumento;
            
            _id_movimiento = id_movimiento;
            InitializeComponent();
            inicializaColoresFilas();
            CargaDatosMovimiento();
            PintaFila();
            lblReferenciaD.Text = _docmuento;

        }
        private void CargaDatosMovimiento()
        {
            this.cadNego.TaCaducidades = this.cadNego.sp_GetDataCaducidadesMovimiento(_docmuento, _id_movimiento);
            if (this.cadNego.TaCaducidades.Rows.Count > 0)
            {
                DataRow row = this.cadNego.TaCaducidades.Rows[0];            
                    dataGridView1.DataSource =this.cadNego.TaCaducidades.DefaultView.ToTable(false, "ARTICULO_ID", "NOMBRE", "CANTIDAD", "CANT_LOTE", "NO_LOTE", "CADUCIDAD", "DIV");

            }
            
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                //case Keys.D | Keys.Control | Keys.Alt | Keys.Shift:
                case Keys.D | Keys.Control ://Dividir
                    this.dividir();
                    return true;
                case Keys.G | Keys.Control://guardar
                    this.guardar();
                    return true;
                case Keys.A | Keys.Control://Asginar Valores  de grid al modelo
                    this.AsginarM();
                    return true;
            }            
            return base.ProcessCmdKey(ref message, keys);
        }

        private void guardar() {
            if (this.valida()) {
                guardaBulk();
            }



        }
        private void guardaBulk() {
            dt = (DataTable)(dataGridView1.DataSource);
            List<SIFModelo.Inventarios.SkuCaducidad> li = new List<SIFModelo.Inventarios.SkuCaducidad>();

            int i = 1;
            foreach (DataRow dr in dt.Rows)
            {
                SIFModelo.Inventarios.SkuCaducidad valor = new SIFModelo.Inventarios.SkuCaducidad();
                valor.articuloId =  dr["articulo_id"].ToString();
                valor.nombre =      dr["nombre"].ToString();
                valor.cantidad =    Convert.ToInt32(dr["cantidad"].ToString());
                valor.cant_lote =   Convert.ToInt32(dr["cant_lote"].ToString());
                valor.no_lote =     dr["no_lote"].ToString();
                valor.caducidad =   Convert.ToDateTime( dr["caducidad"].ToString());
                valor.partida +=    i;
                li.Add(valor);
            }

            int r=this.cadNego.upd_ctl_cad_bulk(_docmuento, _id_movimiento.ToString(), _user.UsuariosID.ToString(), li);
            if (r > 0)
            {
                MessageBox.Show("Guardado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else {

                MessageBox.Show("No se pudo guardar La caducidad","Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            this.dataGridView1.DataSource = dt;

            foreach (DataGridViewRow grow in dataGridView1.Rows)
            {
                PintaFila(grow);
            }

            this.dataGridView1.Cursor = Cursors.Default;
        }

        private void GuardarButtonX_Click(object sender, EventArgs e) {
            this.guardar();
        }
        private void agregarCadButtonX_Click(object sender, EventArgs e)
        {

            this.dividir();
            
        }


        private void dividir() {
            Int32 Vqueda = 0;
            try
            {
                if (String.IsNullOrEmpty(_skuCad.articuloId))
                {
                    MessageBox.Show("Seleccione el Producto (Click en el encabezado de la fila)");
                    return;
                }
                if (string.IsNullOrEmpty(_skuCad.no_lote)) {
                    MessageBox.Show("Capture el Lote y caducidad");
                    return;
                }
                if (_skuCad.div == "S")
                {
                    MessageBox.Show("No puede dividir una fila ya dividida");
                    return;
                }
                MessageBox.Show(_skuCad.articuloId + " " + _skuCad.nombre, "Dividir", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dt = (DataTable)(dataGridView1.DataSource);
                foreach (DataRow dr1 in dt.Rows)
                {
                    if (_skuCad.articuloId == dr1["ARTICULO_ID"].ToString() && dr1["DIV"].ToString() == "N")
                    {
                        int TCantidad = dataGridView1.Rows.Cast<DataGridViewRow>()
                             .AsEnumerable().Where(x => x.Cells["ARTICULO_ID"].Value.ToString() == dr1["ARTICULO_ID"].ToString())
                             .Sum(x => int.Parse(x.Cells["CANTIDAD"].Value.ToString()));
                        int TCantidadL = dataGridView1.Rows.Cast<DataGridViewRow>()
                                     .AsEnumerable().Where(x => x.Cells["ARTICULO_ID"].Value.ToString() == dr1["ARTICULO_ID"].ToString())
                                     .Sum(x => int.Parse(x.Cells["CANT_LOTE"].Value.ToString()));
                        Vqueda = TCantidad - TCantidadL;
                        dr1["CANT_LOTE"] = Vqueda;
                    }
                }
                if (Vqueda <= 0)
                {
                    return;
                }


                DataRow dr = dt.NewRow();
                dr["ARTICULO_ID"] = _skuCad.articuloId;
                dr["NOMBRE"] = _skuCad.nombre;
                dr["CANTIDAD"] = 0;
                dr["CANT_LOTE"] = _skuCad.cant_lote;
                dr["NO_LOTE"] = "";
                dr["CADUCIDAD"] = _skuCad.caducidad;
                dr["DIV"] = "S";
                dt.Rows.Add(dr);
                dataGridView1.DataSource = dt;
                PintaFila();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _skuCad.articuloId = dataGridView1[0, e.RowIndex].Value.ToString();
            _skuCad.nombre = dataGridView1[1, e.RowIndex].Value.ToString();
            _skuCad.cantidad = Convert.ToInt32( dataGridView1[2, e.RowIndex].Value.ToString());
            _skuCad.cant_lote = Convert.ToInt32(dataGridView1[3, e.RowIndex].Value.ToString());
            _skuCad.no_lote = dataGridView1[4, e.RowIndex].Value.ToString();
            _skuCad.caducidad = Convert.ToDateTime(dataGridView1[5, e.RowIndex].Value.ToString());
            _skuCad.div=dataGridView1[6, e.RowIndex].Value.ToString();
        }

        private void AsginarM() {
            //asigna los valores de la Fila actual de datagridvies en el modelo _skuCak
            _skuCad.articuloId = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            _skuCad.nombre = dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            _skuCad.cantidad = Convert.ToInt32(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            _skuCad.cant_lote = Convert.ToInt32(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            _skuCad.no_lote = dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            _skuCad.caducidad = Convert.ToDateTime(dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            _skuCad.div = dataGridView1[6, dataGridView1.CurrentCell.RowIndex].Value.ToString();
        }


        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView1[6, e.RowIndex].Value.ToString() == "S" && e.ColumnIndex == 3) {
                MessageBox.Show("No se puede Editar una fila proveniente de una division");
                return;
            }            
            agregarCadButtonX.Enabled = false;            

        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        
            agregarCadButtonX.Enabled = true;
            if (!buscaRepetidosLote())
                return;

        }

        private Boolean buscaRepetidosLote() {
            foreach (DataGridViewRow dgr in dataGridView1.Rows)
            {
                string v_lote = dgr.Cells[4].Value.ToString();
                string v_Art = dgr.Cells[0].Value.ToString();
                int count = 0;
                foreach (DataGridViewRow dgri in dataGridView1.Rows)
                {
                    if (v_lote == dgri.Cells[4].Value.ToString() && v_Art == dgri.Cells[0].Value.ToString())
                    {
                        count += 1;
                    }
                }
                if (count > 1)
                {
                    MessageBox.Show("El lote ya esta capturado en otra Fila");
                    return false;
                }
            }
            return true;
        }

        private bool valida() {
            try
            {
                buscaRepetidosLote();
                DataTable dt = (DataTable)(dataGridView1.DataSource);

                foreach (DataGridViewRow dgr in dataGridView1.Rows)
                {
                    int TCantidad = dataGridView1.Rows.Cast<DataGridViewRow>()
                                 .AsEnumerable().Where(x => x.Cells["ARTICULO_ID"].Value.ToString() == dgr.Cells["ARTICULO_ID"].Value.ToString())
                                 .Sum(x => int.Parse(x.Cells["CANTIDAD"].Value.ToString()));
                    int TCantidadL = dataGridView1.Rows.Cast<DataGridViewRow>()
                                 .AsEnumerable().Where(x => x.Cells["ARTICULO_ID"].Value.ToString() == dgr.Cells["ARTICULO_ID"].Value.ToString())
                                 .Sum(x => int.Parse(x.Cells["CANT_LOTE"].Value.ToString()));
                    if (TCantidad != TCantidadL)
                    {
                        MessageBox.Show("La captura del codigo " + dgr.Cells["ARTICULO_ID"].Value.ToString() + " " + dgr.Cells["NOMBRE"].Value.ToString() + " No fue correcta, favor de Validar");
                        return false
                            ;
                    }
                    if (string.IsNullOrEmpty(dgr.Cells["no_lote"].Value.ToString()))
                    {
                        MessageBox.Show("El LOTE Capturado del codigo " + dgr.Cells["ARTICULO_ID"].Value.ToString() + " " + dgr.Cells["NOMBRE"].Value.ToString() + " no es Vailo", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    
                    int _Year = Convert.ToInt16(dgr.Cells["caducidad"].Value.ToString().Substring(0, 4));
                    int _mes = Convert.ToInt16(dgr.Cells["caducidad"].Value.ToString().Substring(4, 2));
                    int _YearA = Convert.ToInt16(DateTime.Now.ToString("yyyy"));

                    if (string.IsNullOrEmpty(dgr.Cells["CADUCIDAD"].Value.ToString()) || _mes < 0 || _mes > 12 || _Year < _YearA)
                    {
                        MessageBox.Show("El MES o AÑO Capturado del codigo " + dgr.Cells["ARTICULO_ID"].Value.ToString() + " " + dgr.Cells["NOMBRE"].Value.ToString() + " no es Vailo", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }

                }
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private void inicializaColoresFilas()
        {
            revisarRowStyle = new DataGridViewCellStyle(this.dataGridView1.DefaultCellStyle);
            revisarRowStyle.BackColor = Color.FromArgb(255, 35, 35);
            //revisarRowStyle.BackColor.Color2 = Color.FromArgb(255, 35, 35);

            WarningCellStyle = new DataGridViewCellStyle(this.dataGridView1.DefaultCellStyle);
            WarningCellStyle.BackColor = Color.FromArgb(253, 215, 0);
            //WarningCellStyle.BackColor.Color2 = Color.FromArgb(253, 215, 0);

            margenRowStyle = new DataGridViewCellStyle(this.dataGridView1.DefaultCellStyle);
            margenRowStyle.BackColor = Color.FromArgb(200, 100, 100);
            //margenRowStyle.BackColor.Color2 = Color.FromArgb(200, 100, 100);

            faltanteRowStyle = new DataGridViewCellStyle(this.dataGridView1.DefaultCellStyle);
            faltanteRowStyle.BackColor = Color.FromArgb(0, 176, 80);

            SobranteRowStyle = new DataGridViewCellStyle(this.dataGridView1.DefaultCellStyle);
            SobranteRowStyle.BackColor = Color.FromArgb(12, 255, 0);
            //faltanteRowStyle.Background.Color2 = Color.FromArgb(0, 176, 80);

            normalRowStyle = new DataGridViewCellStyle(this.dataGridView1.DefaultCellStyle);
            normalRowStyle = this.dataGridView1.DefaultCellStyle;
        }



        private void PintaFila(DataGridViewRow dgrow)
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

            DataRow row = ((DataRowView)((dataGridView1.Rows[dgrow.Index].DataBoundItem))).Row;
            decimal conteo = 0;
            decimal existencia = 0;
            decimal diferencia = 0;

            var vconteo = row["cant_lote"];

            if (!vconteo.ToString().IsIntegerPositive())
            {
                return;
            }

            conteo = decimal.Parse(row["cant_lote"].ToString());
            existencia = decimal.Parse(row["cantidad"].ToString());
            diferencia = conteo - existencia;
            if (row == null)
            {
                return;
            }

            DataGridViewRow GridRow = this.dataGridView1.Rows[dgrow.Index];
            GridRow.DefaultCellStyle = normalRowStyle;
            GridRow.DefaultCellStyle.ApplyStyle(normalRowStyle);

            if (String.IsNullOrEmpty(row["no_lote"].ToString()))
            {
                

                GridRow.DefaultCellStyle = revisarRowStyle;
                GridRow.DefaultCellStyle.ApplyStyle(revisarRowStyle);


            }



            if (row["div"].ToString() == "S") {
                

                    GridRow.DefaultCellStyle = SobranteRowStyle;
                    GridRow.DefaultCellStyle.ApplyStyle(SobranteRowStyle);
                

            }


     
        }

        private void PintaFila()
        {

            foreach (DataGridViewRow dgrow in dataGridView1.Rows)
            {
                PintaFila(dgrow);
            }
            this.dataGridView1.Cursor = Cursors.Default;
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            PintaFila(dataGridView1.CurrentRow as DataGridViewRow);
        }

        private void FrmCapturaCaducidades_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            ToolTip toolTip2 = new ToolTip();
            toolTip1.SetToolTip(agregarCadButtonX, "Ctrl+A,Ctrl+D");
            toolTip2.SetToolTip(GuardarButtonX, "Ctrl+G");
            PintaFila();
        }
    }
}
