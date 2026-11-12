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
    public partial class AjustesAlmacenComprasUserControl : Templates.ListaUserControl
    {
        private int Cual = 0;
        public int ModuloID;
        SIFModelo.Inventarios.InventarioDataSet DsAjustes;
        public AjustesAlmacenComprasUserControl()
        {
            InitializeComponent();
            this.dateTimeInput1.Value = DateTime.Parse("01/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year.ToString());
            this.dateTimeInput2.Value = DateTime.Parse(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year.ToString());
            Privilegios();
        }
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    if (ModuloID == 3)
                        Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 24, int.Parse(Xbtn.Tag.ToString()));
                    else
                        Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 36, int.Parse(Xbtn.Tag.ToString()));
            }

        }
        AjusteAlmacenComprasUserControl frmAjuste = new AjusteAlmacenComprasUserControl();
        private void Nuevo()
        {
            if (!frmAjuste.Mostrado)
            {
                frmAjuste = new AjusteAlmacenComprasUserControl();
                frmAjuste.Parent = this;
                frmAjuste.AjusteID = "";
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
            this.Buscar();
        }

        public void ActivaComandos()
        {

        }

        public void Back()
        {
            try
            {
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


        SIFNegocio.Inventario.Ajustes ajustesAlmacen = new SIFNegocio.Inventario.Ajustes();
        public void Buscar()
        {

            switch (Cual)
            {
                case 0:
                    DsAjustes = ajustesAlmacen.GetAjustes(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "S", foliotextBoxX.Text);
                    break;
                case 1:
                    DsAjustes = ajustesAlmacen.GetAjustes(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "N", foliotextBoxX.Text);
                    break;
                case 2:
                    DsAjustes = ajustesAlmacen.GetAjustes(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "X", foliotextBoxX.Text);
                    break;
                case 3:
                    DsAjustes = ajustesAlmacen.GetAjustes(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "", foliotextBoxX.Text);
                    break;

            }
            DsAjustes.Relations.Add("1", DsAjustes.Tables["AjustesC"].Columns["FOLIO"],
                                              DsAjustes.Tables["AJUSTES_DET"].Columns["FOLIO"], false);

            DsAjustes.AjustesC.DefaultView.Sort = "fecha desc";
            this.superGridControl1.PrimaryGrid.DataSource = DsAjustes;
            this.superGridControl1.PrimaryGrid.DataMember = "AjustesC";
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

        private void Envia()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Debe seleccionar el encabezado del inventario");
                return;
            }

            var row = (GridRow)container;

            if (!frmAjuste.Mostrado)
            {
                frmAjuste = new AjusteAlmacenComprasUserControl();
                frmAjuste.Parent = this;
                frmAjuste.AjusteID = row.Cells[0].Value.ToString();
                frmAjuste.Owner = this.Owner;
                frmAjuste.Muestra();
            }

        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            this.Envia();

        }
        private int CancelTraspaso(string NoFolio, string NoLote)
        {
            SIFNegocio.Inventario.Traspasos tRAS = new SIFNegocio.Inventario.Traspasos();
            return tRAS.CancelTraspaso(NoFolio, NoLote);
        }

        private int CierraTraspaso(string NoFolio, string NoLote)
        {
            SIFNegocio.Inventario.Traspasos tRAS = new SIFNegocio.Inventario.Traspasos();
            return tRAS.CierraTraspaso(Helpers.Sesion.Usuario.UsuariosID.ToString(), NoFolio, NoLote);
        }
        private void cancela()
        {
            String ProductName = "Traspasos";
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);
            var row = (GridRow)container;
            if (!row.Cells["ACTIVO"].Value.ToString().Contains('X'))
            {
                if (MessageBoxEx.Show("¿Cancelar el Traspaso " + row.Cells[0].Value.ToString()
                                                           + " - "
                                                           + row.Cells[1].Value.ToString() + "?",
                                  ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (CancelTraspaso(row.Cells[0].Value.ToString(),
                                      row.Cells[1].Value.ToString()) > 0)
                        row.Cells["ACTIVO"].Value = "X";

            }
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            this.cancela();
            this.Buscar();
        }

        private void buttonItemCc_Click(object sender, EventArgs e) {

            this.capturaCaducidad();
        }

        private void capturaCaducidad() {
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);
            var row = (GridRow)container;
            if (!row.Cells["ACTIVO"].Value.ToString().Contains('S'))
            {
                MessageBox.Show("El movimiento tiene que estar cerrado");
                return;
            }
             SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(SIF.Helpers.Sesion.Usuario.UsuariosID);
            //Inventario.frmCapturaCaducidades frm = new Inventario.frmCapturaCaducidades(usuario, row.Cells["FOLIO"].Value.ToString(), 14 );
            //frm.ShowDialog();
            Inventario.controlCaducidadesSelectUserControl frmCc = new Inventario.controlCaducidadesSelectUserControl(row.Cells[0].Value.ToString(), 19, int.Parse(row.Cells[1].Value.ToString()));
            frmCc.Owner = this;
            frmCc.Muestra();
        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            this.Envia();
        }
        private void imprimir()
        {
            //String ProductName = "Traspasos";
            ////GridPanel panel = superGridControl1.PrimaryGrid;
            ////var container = ((GridContainer)panel.ActiveRow);
            //// var row = (GridRow)container;

            View.OrdenCompra.InventarioFechaTipoForm frmFecha = new OrdenCompra.InventarioFechaTipoForm();
            if (frmFecha.ShowDialog() == DialogResult.OK)
            {
                Reportes.frmImpresion frmImp = new Reportes.frmImpresion("RPT_Ajuste_de_Inventario.rpt", " {AJUSTES.TIPO_MOV} = '" + frmFecha.tb_DescConceptoAjuste.Text + "' AND {AJUSTES.FECHA_REG} >= DATE(" + frmFecha.dateTimeInput1.Value.ToString("yyyy,MM,dd") + ")  AND {AJUSTES.FECHA_REG} <=  DATE(" + frmFecha.dateTimeInput2.Value.ToString("yyyy,MM,dd") + ") ");
                frmImp.ShowDialog();
            }

            //GridPanel panel = superGridControl1.PrimaryGrid;
            //if (panel.ActiveRow == null)
            //{
            //    return;
            //}

            //var container = ((GridContainer)panel.ActiveRow);
            //if (!(container is GridRow))
            //{
            //   MessageBox.Show("Seleccione la cabecera del traspaso");
            //    return;
            //}
            //var row = (GridRow)container;
            //if (!row.Cells["ACTIVO"].Value.ToString().Contains('X') & !row.Cells["ACTIVO"].Value.ToString().Contains('R'))
            //{
            //    string folio = row.Cells[0].Value.ToString();
            //    SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_AJUSTES.rpt", " {AJUSTES.FOLIO}='" + folio + "'");
            //    Impresion.ShowDialog();
            //}
            //else
            //    if (row.Cells["ACTIVO"].Value.ToString().Contains('R'))
            //       MessageBox.Show("El Traspaso no se a recibido", "Traspasos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    else
            //       MessageBox.Show("El Traspaso esta cancelado", "Traspasos", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        private void superGridControl1_Click(object sender, EventArgs e)
        {

        }

        private void superGridControl1_DoubleClick(object sender, EventArgs e)
        {
            this.Envia();
        }

        private void porsurtirRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (porsurtirRadioButton.Checked)
            {
                Cual = 0;
                this.Buscar();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Cual = 1;
                this.Buscar();

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Cual = 2;
                this.Buscar();
            }
        }

        private void creditoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (creditoRadioButton.Checked)
            {
                Cual = 3;
                this.Buscar();
            }
        }
        private void Cerrar()
        {

            String ProductName = "Ajustes";
            GridPanel panel = superGridControl1.PrimaryGrid;
            if (panel.ActiveRow == null)
            {
                return;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Seleccione la cabecera del traspaso");
                return;
            }
            var row = (GridRow)container;



            if (row.Cells["ACTIVO"].Value.ToString().Contains('S'))
            {
                if (MessageBoxEx.Show("¿Aplicar el Ajuste " + row.Cells[0].Value.ToString()
                                                           + " - "
                                                           + row.Cells[1].Value.ToString() + "?",
                                   ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DataRow[] results = DsAjustes.AJUSTES_DET.Select("Folio='" + row.Cells[0].Value.ToString() + "'", "lote, ARTICULO_ID");
                    // IN Ajuste Array's
                    String[] Articulo = new String[results.Length];
                    Double[] Costo = new Double[results.Length];
                    int[] Cant = new int[results.Length];
                    int ind = 0;

                    foreach (DataRow rows in results)
                    {
                        // Sec[ind] = row[""];
                        Articulo[ind] = rows["ARTICULO_ID"].ToString();
                        Costo[ind] = Convert.ToDouble(rows["PRECIO_COSTO"]);
                        Cant[ind] = Convert.ToInt16(rows["CANTIDAD"]);
                        ind++;
                    }
                    if (ajustesAlmacen.AplicaAjuste(row.Cells[0].Value.ToString(),
                                     Convert.ToInt16(row.Cells[1].Value.ToString()),
                                     Convert.ToInt16(row.Cells[2].Value.ToString().Split('-')[0]), Articulo, Cant, Costo,
                                     row.Cells[4].Value.ToString(), Helpers.Sesion.Usuario.UsuariosID.ToString()) > 0)
                        this.Buscar();
                }
                else
                {
                   MessageBox.Show("Debe ser la misma sucursal destino verificar configuracion", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void buttonItem2_Click(object sender, EventArgs e)
        {
            this.Cerrar();
        }

        private void buttonItem2_Click_1(object sender, EventArgs e)
        {
            this.Cerrar();
            imprimir();
        }


        private void buttonItem4_Click_1(object sender, EventArgs e)
        {

        }

        private void buscarBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Buscar();
        }

        private void foliotextBoxX_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void foliotextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Buscar();
            }
        }

        private void nuevoPedidoButtonItem_Click_1(object sender, EventArgs e)
        {
            this.Nuevo();

        }

        private void buttonItem1_Click_1(object sender, EventArgs e)
        {
            this.Envia();
        }

        private void reposicionButtonItem_Click(object sender, EventArgs e)
        {
            String ProductName = "Reposición";

            Ventas.FechasFacturaGlobalForm frmFechas = new Ventas.FechasFacturaGlobalForm();
            frmFechas.ShowDialog();

            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_AJUSTES.rpt", " {AJUSTES.FECHA_REG} >= DATE(" + frmFechas.dateTimeInput1.Value.ToString("yyyy,MM,dd") + ") AND  {AJUSTES.FECHA_REG} >= DATE(" + frmFechas.dateTimeInput2.Value.ToString("yyyy,MM,dd") + ")", "", ProductName);
            Impresion.ShowDialog();
        }


    }
}
