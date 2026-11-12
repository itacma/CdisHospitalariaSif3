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
    public partial class ConversionAlmacenUserControl : Templates.ListaUserControl
    {
        private int Cual = 0;
        SIFModelo.Inventarios.InventarioDataSet DsAjustes;
        public ConversionAlmacenUserControl()
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
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 35, int.Parse(Xbtn.Tag.ToString()));

            }

        }
        ConversioAlmacenUserControl frmConversion = new ConversioAlmacenUserControl();
        private void Nuevo()
        {
            if (!frmConversion.Mostrado)
            {
                frmConversion = new ConversioAlmacenUserControl();
                frmConversion.ConversionID = "";
                frmConversion.Owner = Owner;
                frmConversion.Muestra();
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


        SIFNegocio.Inventario.Conversiones ConversionAlmacen = new SIFNegocio.Inventario.Conversiones();
        public void Buscar()
        {

            switch (Cual)
            {
                case 0:
                    DsAjustes = ConversionAlmacen.GetConversion(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "S", foliotextBoxX.Text);
                    break;
                case 1:
                    DsAjustes = ConversionAlmacen.GetConversion(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "N", foliotextBoxX.Text);
                    break;
                case 2:
                    DsAjustes = ConversionAlmacen.GetConversion(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "C", foliotextBoxX.Text);
                    break;
                case 3:
                    DsAjustes = ConversionAlmacen.GetConversion(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "", foliotextBoxX.Text);
                    break;

            }
            DsAjustes.Relations.Add("1", DsAjustes.Tables["CONVERSION"].Columns["CONVERSION_ID"],
                                              DsAjustes.Tables["CONVERSION_DET"].Columns["CONVERSION_ID"], false);

            DsAjustes.AjustesC.DefaultView.Sort = "fecha desc";
            this.superGridControl1.PrimaryGrid.DataSource = DsAjustes;
            this.superGridControl1.PrimaryGrid.DataMember = "CONVERSION";
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
            if (panel.ActiveRow == null)
            {
                return;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Seleccione la cabecera de la conversión");
                return;
            }
            var row = (GridRow)container;
            if (!frmConversion.Mostrado)
            {
                frmConversion = new ConversioAlmacenUserControl();
                frmConversion.ConversionID = row.Cells[0].Value.ToString();
                frmConversion.Referencia = row.Cells[1].Value.ToString();
                frmConversion.Owner = this.Owner;
                frmConversion.Muestra();
            }

        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            this.Envia();

        }
        private int CancelTraspaso(string NoFolio, string NoLote)
        {
            SIFNegocio.Inventario.Conversiones tRAS = new SIFNegocio.Inventario.Conversiones();
            tRAS.CancelaConversion(NoFolio);
            return 0;
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
            if (!row.Cells["ESTADO"].Value.ToString().Contains('X'))
            {
                if (MessageBoxEx.Show("¿Cancelar el conversión " + row.Cells[0].Value.ToString()
                                                           + " - "
                                                           + row.Cells[1].Value.ToString() + "?",
                                  ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (CancelTraspaso(row.Cells[0].Value.ToString(),
                                      row.Cells[1].Value.ToString()) > 0)
                        row.Cells["ESTADO"].Value = "X";

            }
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            this.cancela();
            this.Buscar();
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
            String ProductName = "Traspasos";
            //GridPanel panel = superGridControl1.PrimaryGrid;
            //var container = ((GridContainer)panel.ActiveRow);
            // var row = (GridRow)container;

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
            if (!row.Cells["ESTADO"].Value.ToString().Contains('X') & !row.Cells["ESTADO"].Value.ToString().Contains('R'))
            {
                SIFModelo.Inventarios.InventarioDataSet Pedidos = ConversionAlmacen.GetConversion(row.Cells[0].Value.ToString());
                SIF.View.Reportes.Inventarios.ReporteForm Reporte = new Reportes.Inventarios.ReporteForm(Pedidos, 1);
                Reporte.ShowDialog();
            }
            else
                if (row.Cells["ACTIVO"].Value.ToString().Contains('R'))
                   MessageBox.Show("El Traspaso no se a recibido", "Traspasos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                   MessageBox.Show("El Traspaso esta cancelado", "Traspasos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
               MessageBox.Show("Seleccione la cabecera de la conversión");
                return;
            }
            var row = (GridRow)container;



            if (row.Cells["ESTADO"].Value.ToString().Contains('S'))
            {
                if (MessageBoxEx.Show("¿Aplicar la conversión " + row.Cells[0].Value.ToString() + "?",
                                   ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DataRow[] results = DsAjustes.CONVERSION_DET.Select("CONVERSION_ID='" + row.Cells[0].Value.ToString() + "'", "ARTICULO_ID");
                    // IN Ajuste Array's
                    String[] Articulo = new String[results.Length];
                    String[] Nombre = new String[results.Length];
                    Double[] Costo = new Double[results.Length];
                    int[] Cant = new int[results.Length];
                    int[] Sec = new int[results.Length];

                    String[] ArticuloE = new String[results.Length];
                    String[] NombreE = new String[results.Length];
                    Double[] CostoE = new Double[results.Length];
                    int[] CantE = new int[results.Length];
                    int ind = 0;

                    foreach (DataRow rows in results)
                    {
                        // Sec[ind] = row[""];
                        Articulo[ind] = rows["ARTICULO_ID"].ToString();
                        Nombre[ind] = rows["NOMBRE1"].ToString();
                        Costo[ind] = Convert.ToDouble(rows["COSTO"]);
                        Cant[ind] = Convert.ToInt16(rows["CANTIDAD"]);

                        ArticuloE[ind] = rows["ARTICULO_IDE"].ToString();
                        NombreE[ind] = rows["NOMBRE1E"].ToString();
                        CostoE[ind] = Convert.ToDouble(rows["COSTOE"]);
                        CantE[ind] = Convert.ToInt16(rows["CANTIDADE"]);
                        Sec[ind] = ind;
                        ind++;

                    }
                    if (ConversionAlmacen.AplicaConversion(row.Cells[0].Value.ToString(), Helpers.Sesion.Sucursal.SucursalID, Helpers.Sesion.Usuario.UsuariosID.ToString()
                        , Articulo, Nombre, Cant, ArticuloE, NombreE, CantE, Costo, CostoE) > 0)
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


    }
}
