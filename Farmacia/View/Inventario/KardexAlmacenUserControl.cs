using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar;

namespace SIF.View.Inventario
{
    public partial class KardexAlmacenUserControl : Templates.ListaUserControl
    {
        private int Cual = 0;
        public Boolean MostradoArt = false;
        SIFModelo.Inventarios.InventarioDataSet DsAjustes;
        public KardexAlmacenUserControl()
        {
            InitializeComponent();
            this.dateTimeInput1.Value = DateTime.Parse(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year.ToString());
            this.dateTimeInput2.Value = DateTime.Parse(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year.ToString() + " 23:59:59");
            Privilegios();
            this.CargaTipoMov();
            this.CargaProv();
        }
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 32, int.Parse(Xbtn.Tag.ToString()));
            }

        }
        ConversioAlmacenUserControl frmAjuste = new ConversioAlmacenUserControl();
        private void Nuevo()
        {
            if (!frmAjuste.Mostrado)
            {
                frmAjuste = new ConversioAlmacenUserControl();
                frmAjuste.ConversionID = "";
                frmAjuste.Owner = Owner;
                frmAjuste.Muestra();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        public bool Mostrado { get; set; }

        public MainForm Owner { get; set; }

        public void Muestra()
        {
            if (Mostrado)
            {
                return;
            }
            Mostrado = true;
            this.Dock = DockStyle.Fill;
            this.ActivaComandos();
            Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }

        public void ActivaComandos()
        {

        }

        public void Back()
        {
            try{
            Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            //this.DesactivaComandos();
            //((this.Owner.ActivaComandos();
            Mostrado = false;
            }
            catch { }
        }

        public void DesactivaComandos()
        {

        }

        private void SeleccionaArticulo(object sender, EventArgs e)
        {
            View.Articulos.ArticuloUserControl frmArticulo = new Articulos.ArticuloUserControl();
            //MessageBox.Show("Load MostradoArt");
            if (!MostradoArt)
            {
                MostradoArt = true;
                frmArticulo = new Articulos.ArticuloUserControl();
                MainForm lanza;
                frmArticulo.Dock = DockStyle.Fill;
                //frmArticulo.Muestra();

                frmArticulo.Owner = this;
                Owner.ShowModalPanel(frmArticulo, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.DesactivaComandos();
                frmArticulo.ActivaComandos();
            }
        }

        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            CodigoTextBoxX.Text = articulo.ARTICULO_ID;
            MostradoArt = false;
        }
        SIFNegocio.Inventario.Kardex KardexAlmacen = new SIFNegocio.Inventario.Kardex();
        SIFNegocio.caducidades cd = new SIFNegocio.caducidades();// JMQC 11-12-2017 Lo agrego para que motrar caducidades en kardex
        public DataTable TaCaducidades { get; set; }// JMQC 11-12-2017 Lo agrego para que motrar caducidades en kardex

        public void Buscar()
            {
            try
            {
                lblUbicacion.Text = "Ubicación: ";
                lblExistencia.Text = "Existencia: ";

                string Artculo_ID = string.Empty;


                string v_movimiento = CbxTipoMovimiento.Text + "%";
                string proveedor = comboBox1.Text+ "%";

                if (v_movimiento.Equals("TODOS%")) //si queremos mostrar todos los movimientos
                {
                    v_movimiento = "%";
                }
                if (proveedor.Equals("TODOS%") || proveedor.Equals("SIFModelo.Proveedor%"))//si queremos mostrar todos los proveedores
                {
                    proveedor = "%";
                }

                if (CodigoTextBoxX.Text == "")
                {
                    Artculo_ID = "%";
                }
                       
                else
                {
                   
                   
                    Artculo_ID = CodigoTextBoxX.Text; 
                    
                    SIFModelo.Inventarios.Inventario inventarioM = new SIFModelo.Inventarios.Inventario();
                    inventarioM = SIFNegocio.Articulo.ExistencuiaUbicacionArticulo(CodigoTextBoxX.Text);
                    lblUbicacion.Text = "Ubicación: Fila[" + inventarioM.fila + "]" + " Anaquel: [" + inventarioM.anaquel + "]" + " Nivel: [" + inventarioM.nivel + "]".ToString();
                    lblExistencia.Text = "Existencia: " + inventarioM.Existencias;
                }
                    /*
                     * 
                if (CodigoTextBoxX.Text == "")
                    if (v_movimiento.Equals("TODOS%"))
                    {
                            v_movimiento = "%";
                            Artculo_ID = "%";
                            /*
                            this.superGridControl1.PrimaryGrid.DataSource = KardexAlmacen.GetKardex(dateTimeInput1.Value, dateTimeInput2.Value, "", "%", "%");
                            this.superGridControl1.PrimaryGrid.DataMember = "KARDEX";

                    }
                    //else {                         this.superGridControl1.PrimaryGrid.DataSource = KardexAlmacen.GetKardex(dateTimeInput1.Value, dateTimeInput2.Value, "", "%",v_movimiento);                                            }


                else
                {/*
                    if (v_movimiento.Equals("TODOS%"))
                    {
                            //this.superGridControl1.PrimaryGrid.DataSource = KardexAlmacen.GetKardex(dateTimeInput1.Value, dateTimeInput2.Value, "", CodigoTextBoxX.Text, "%");

                        }
                    else {
                            //this.superGridControl1.PrimaryGrid.DataSource = KardexAlmacen.GetKardex(dateTimeInput1.Value, dateTimeInput2.Value, "", CodigoTextBoxX.Text, v_movimiento);                        
                        }
                          //  Artculo_ID = CodigoTextBoxX.Text;
                    SIFModelo.Inventarios.Inventario inventarioM = new SIFModelo.Inventarios.Inventario();
                    inventarioM = SIFNegocio.Articulo.ExistencuiaUbicacionArticulo(CodigoTextBoxX.Text);
                    lblUbicacion.Text = "Ubicación: Fila["+ inventarioM.fila +"]" + " Anaquel: [" + inventarioM.anaquel +"]" + " Nivel: ["+ inventarioM.nivel +"]".ToString();
                    lblExistencia.Text = "Existencia: " + inventarioM.Existencias;



                }*/
                DataSet ds = KardexAlmacen.GetKardexN(dateTimeInput1.Value, dateTimeInput2.Value, "", Artculo_ID, v_movimiento,proveedor);
                ds.Relations.Add("1", ds.Tables["KARDEXN"].Columns["ULT_LOTE_INTERNO"], ds.Tables["CADUCIDADES"].Columns["ULT_LOTE_INTERNO"], false);


                this.superGridControl1.PrimaryGrid.DataSource = ds;
                this.superGridControl1.PrimaryGrid.DataMember = "KARDEXN";
                // this.superGridControl1.PrimaryGrid.DataMember = "KARDEX";
                calculaTotales();
             }
             catch (Exception e) { }
        }

        private void calculaTotales()
        {

            /*SIFModelo.Inventarios.InventarioDataSet ds = this.superGridControl1.PrimaryGrid.DataSource as SIFModelo.Inventarios.InventarioDataSet;
            SIFModelo.Inventarios.InventarioDataSet.INV_KARDEXDataTable dt =  ds.INV_KARDEX;
            var totalMovimientos = dt.Rows.Count;
            var totalMovEntrada = dt.Select("TIPO_MOVIMIENTO LIKE '%ENTRADA%'").Count();
            var totalMovSalida = dt.Select("TIPO_MOVIMIENTO LIKE '%SALIDA%'").Count();

            decimal totalEntrada = 0;
            foreach (var row in dt.Select("TIPO_MOVIMIENTO LIKE '%ENTRADA%'"))
            {
                totalEntrada += System.Convert.ToDecimal(row["ENTRADA"]) * System.Convert.ToDecimal(row["COSTO"]);
            }

            decimal totalSalida = 0;
            foreach (var row in dt.Select("TIPO_MOVIMIENTO LIKE '%SALIDA%'"))
            {
                totalSalida += System.Convert.ToDecimal(row["SALIDA"]) * System.Convert.ToDecimal(row["COSTO"]);
            }


            movimientosLabelX.Text = "MOVIMIENTOS = " + totalMovimientos.ToString();
            entradasLabelX.Text = "ENTRADAS = " + totalMovEntrada.ToString();
            salidasLabelX.Text = "SALIDAS = " + totalMovSalida.ToString();

            totalEntradaLabelX.Text = "TOTAL ENTRADA = " + System.Convert.ToDecimal(totalEntrada).ToString("C2");
            totalSalidaLabelX.Text = "TOTAL SALIDA = " + System.Convert.ToDecimal(totalSalida).ToString("C2");
            */
            SIFModelo.Inventarios.InventarioDataSet ds = this.superGridControl1.PrimaryGrid.DataSource as SIFModelo.Inventarios.InventarioDataSet;
            DataSet dt = this.superGridControl1.PrimaryGrid.DataSource as DataSet;
            var totalMovimientos = dt.Tables["KARDEXN"].Rows.Count;
            var totalMovEntrada = dt.Tables["KARDEXN"].Select("TIPO_MOVIMIENTO LIKE '%ENTRADA%'").Count();
            var totalMovSalida = dt.Tables["KARDEXN"].Select("TIPO_MOVIMIENTO LIKE '%SALIDA%'").Count();

            decimal totalEntrada = 0;
            foreach (var row in dt.Tables["KARDEXN"].Select("TIPO_MOVIMIENTO LIKE '%ENTRADA%'"))
            {
                totalEntrada += System.Convert.ToDecimal(row["ENTRADA"]) * System.Convert.ToDecimal(row["COSTO"]);
            }

            decimal totalSalida = 0;
            foreach (var row in dt.Tables["KARDEXN"].Select("TIPO_MOVIMIENTO LIKE '%SALIDA%'"))
            {
                totalSalida += System.Convert.ToDecimal(row["SALIDA"]) * System.Convert.ToDecimal(row["COSTO"]);
            }


            movimientosLabelX.Text = "MOVIMIENTOS = " + totalMovimientos.ToString();
            entradasLabelX.Text = "ENTRADAS = " + totalMovEntrada.ToString();
            salidasLabelX.Text = "SALIDAS = " + totalMovSalida.ToString();

            totalEntradaLabelX.Text = "TOTAL ENTRADA = " + System.Convert.ToDecimal(totalEntrada).ToString("C2");
            totalSalidaLabelX.Text = "TOTAL SALIDA = " + System.Convert.ToDecimal(totalSalida).ToString("C2");

        }

        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            
            this.Buscar();
         
        }

        private void PedidosAlmacenUserControl_Load(object sender, EventArgs e)
        {
            
            this.dateTimeInput1.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            this.dateTimeInput2.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

        }

        private void nuevoPedidoButtonItem_Click(object sender, EventArgs e)
        {
            this.Nuevo();
        }

        private void SeleccionaArticulo()
        {

        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            string Artculo_ID = string.Empty;//validar

            string v_movimiento = CbxTipoMovimiento.Text + "*";//movimiento
            string proveedor = comboBox1.Text + "*";//proveedor

            if (v_movimiento.Equals("TODOS*")) //si queremos mostrar todos los movimientos
            {
                v_movimiento = "*";
            }
            if (proveedor.Equals("TODOS*") || proveedor.Equals("SIFModelo.Proveedor*"))//si queremos mostrar todos los proveedores
            {
                proveedor = "*";
            }

            if (CodigoTextBoxX.Text == "")
            {
                Artculo_ID = "*";
            }
            else { Artculo_ID = CodigoTextBoxX.Text; }

            String Parm1 = "{CS_RPT_KARDEX_LOTES.FECHA}>=DATE(" + dateTimeInput1.Value.ToString("yyyy,MM,dd") + ") AND {CS_RPT_KARDEX_LOTES.FECHA}<=DATE(" + dateTimeInput2.Value.ToString("yyyy,MM,dd") + ")";
            //if (CodigoTextBoxX.Text != "")
            string fechas = dateTimeInput1.Value.ToString("D") + " al " + dateTimeInput2.Value.ToString("D");
                Parm1 = Parm1 + " AND {CS_RPT_KARDEX_LOTES.ARTICULO_ID} LIKE '" + Artculo_ID + "'";
                Parm1 = Parm1 + " AND {CS_RPT_KARDEX_LOTES.TIPO_MOVIMIENTO} LIKE '" + v_movimiento + proveedor + "'";
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Kardex.rpt", Parm1, fechas);
           
            Impresion.ShowDialog();
        }

        private void KardexAlmacenUserControl_Load(object sender, EventArgs e)
        {
           // Buscar();
        }

        private void CodigoTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Buscar();
            }
        }
        SIFNegocio.Inventario.Kardex Fd = new SIFNegocio.Inventario.Kardex();

        private void CargaTipoMov() {
            BindingSource tipoMov = new BindingSource();
            
            tipoMov.DataSource = Fd.BuscaTipoMK().DataSource;            
            this.CbxTipoMovimiento.DataSource = tipoMov;
            CbxTipoMovimiento.DisplayMember = "tipoMk";
        
        }

        SIFNegocio.Inventario.Kardex Pr = new SIFNegocio.Inventario.Kardex();
        private void CargaProv()
        {
            BindingSource proveedor = new BindingSource();

            proveedor.DataSource = Pr.BuscaProv().DataSource;
            this.comboBox1.DataSource = proveedor;
            comboBox1.DisplayMember = "proveedor";

        }

        

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CbxTipoMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dato = CbxTipoMovimiento.Text;

            if(dato== "ENTRADA POR COMPRA")
            {
                comboBox1.Visible = true;
                label4.Visible = true;
            }
            else
            {
                comboBox1.Visible = false;
                label4.Visible = false;
                comboBox1.Text = "TODOS";
            }
        }

        private void tableLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void q_Clipboard() {

            DataSet dt = this.superGridControl1.PrimaryGrid.DataSource as DataSet;
            DataTable dataSource = new  DataTable();
            dataSource = dt.Tables["KARDEXN"];
            StringBuilder csvBuilder = new StringBuilder();

            // Agregar encabezados de columna
            foreach (DataColumn column in dataSource.Columns)
            {
                csvBuilder.Append(column.ColumnName + "\t");
            }

            csvBuilder.AppendLine(); // Agregar salto de línea después de encabezados

            // Agregar filas de datos
            foreach (DataRow row in dataSource.Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    csvBuilder.Append(row[i] + "\t");
                }

                csvBuilder.AppendLine(); // Agregar salto de línea después de cada fila
            }

            Clipboard.SetText(csvBuilder.ToString());


        }


        private void Clipboard2_Click(object sender, EventArgs e)
        {
            Cursor.Current= Cursors.WaitCursor;
            q_Clipboard();
            Cursor.Current = Cursors.Default;
        }


    }
}
