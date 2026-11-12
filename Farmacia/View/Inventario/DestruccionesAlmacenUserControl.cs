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
    public partial class DestruccionesAlmacenUserControl : Templates.ListaUserControl
    {
        private int Cual = 0;
        public int ModuloID;
        public int mov = 8;
        SIFModelo.Inventarios.InventarioDataSet DsDestrucciones;
        SIFNegocio.Inventario.Traspasos Verifica = new SIFNegocio.Inventario.Traspasos();
        public DestruccionesAlmacenUserControl()
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
                    if (ModuloID == 5)
                        Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 24, int.Parse(Xbtn.Tag.ToString()));
                    else if(Xbtn.Tag.ToString()=="47")//19/01/2022 PIT Respetar el permiso del tag del button
                    {

                    }
                    else
                        Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 90, int.Parse(Xbtn.Tag.ToString()));
            }

        }
        DestruccionAlmacenUserControl frmDestruccion = new DestruccionAlmacenUserControl();

        private void Nuevo()
        {
            if (!frmDestruccion.Mostrado)
            {
                frmDestruccion = new DestruccionAlmacenUserControl();
                frmDestruccion.Parent = this;
                frmDestruccion.DestruccionID = "";
                frmDestruccion.Owner = Owner;
                frmDestruccion.Muestra();
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


        SIFNegocio.Inventario.Destrucciones destruccionesAlmacen = new SIFNegocio.Inventario.Destrucciones();
        public void Buscar()
        {

            switch (Cual)
            {
                case 0:
                    DsDestrucciones = destruccionesAlmacen.GetDestrucciones(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "S", foliotextBoxX.Text);
                    break;
                case 1:
                    DsDestrucciones = destruccionesAlmacen.GetDestrucciones(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "N", foliotextBoxX.Text);
                    break;
                case 2:
                    DsDestrucciones = destruccionesAlmacen.GetDestrucciones(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "X", foliotextBoxX.Text);
                    break;
                case 3:
                    DsDestrucciones = destruccionesAlmacen.GetDestrucciones(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "", foliotextBoxX.Text);
                    break;

            }
            DsDestrucciones.Relations.Add("1", DsDestrucciones.Tables["DESTRUCCIONESC"].Columns["FOLIO"],
                                              DsDestrucciones.Tables["DESTRUCCIONES_DET"].Columns["FOLIO"], false);

            DsDestrucciones.DESTRUCCIONES.DefaultView.Sort = "fecha desc";
            this.superGridControl1.PrimaryGrid.DataSource = DsDestrucciones;
            this.superGridControl1.PrimaryGrid.DataMember = "DESTRUCCIONESC";
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

            if (!frmDestruccion.Mostrado)
            {
                frmDestruccion = new DestruccionAlmacenUserControl();
                frmDestruccion.Parent = this;
                frmDestruccion.DestruccionID = row.Cells[0].Value.ToString();
                frmDestruccion.Owner = this.Owner;
                frmDestruccion.Muestra();
            }

        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            this.Envia();

        }
        private int Cancelar(string NoFolio, string NoLote)
        {
            SIFNegocio.Inventario.Traspasos tRAS = new SIFNegocio.Inventario.Traspasos();
            return tRAS.Cancela_Destruccion(NoFolio, NoLote);
        }

        private int CierraTraspaso(string NoFolio, string NoLote)
        {
            SIFNegocio.Inventario.Traspasos tRAS = new SIFNegocio.Inventario.Traspasos();
            return tRAS.CierraTraspaso(Helpers.Sesion.Usuario.UsuariosID.ToString(), NoFolio, NoLote);
        }
        private void cancela()
        {
            String ProductName = "Destruccion";
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);
            var row = (GridRow)container;
            if (!row.Cells["ACTIVO"].Value.ToString().Contains('X'))
            {
                if (MessageBoxEx.Show("¿Cancelar la destrucción " + row.Cells[0].Value.ToString()
                                                           + " - "
                                                           + row.Cells[1].Value.ToString() + "?",
                                  ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (Cancelar(row.Cells[0].Value.ToString(),
                                      row.Cells[1].Value.ToString()) > 0)
                        row.Cells["ACTIVO"].Value = "X";

            }
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            this.cancela();
            this.Buscar();
        }
        private void btn_ModificarLotYCad_click(object sender, EventArgs e)
        {
            string tipo_mov = "8";
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
            ModificacionLotesCaducidades frm_lotes = new ModificacionLotesCaducidades();

            if (row[5].Value.ToString() == "S")
            {
                if (frm_lotes.validParametro())
                {

                    frm_lotes._folio = row[0].Value.ToString();
                    frm_lotes._tipo_mov = tipo_mov;
                    frm_lotes._usuario = Helpers.Sesion.Usuario.UsuariosID.ToString();

                    frm_lotes.LlenadoDatos();

                    if (frm_lotes.muestra_form)
                    {
                        if (frm_lotes.ShowDialog() == DialogResult.OK)
                        {

                        }
                    }
                }
                else
                {
                   MessageBox.Show("La funcion no esta activada", "DESTRUCCIONES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
               MessageBox.Show("La destruccion ya fue cerrada", "DESTRUCCIONES", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void buttonItemCc_Click(object sender, EventArgs e)
        {

            this.capturaCaducidad();
        }
        private void capturaCaducidad()
        {

            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);
            var row = (GridRow)container;
            if (row == null)
                return;
            if (!row.Cells["ACTIVO"].Value.ToString().Contains('S') && (porsurtirRadioButton.Checked ))
            {
                MessageBox.Show("El movimiento tiene que estar cerrado");
                return;
            }
            SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(SIF.Helpers.Sesion.Usuario.UsuariosID);

            if (porsurtirRadioButton.Checked)
            {
                //Inventario.frmCapturaCaducidades frm = new Inventario.frmCapturaCaducidades(usuario, row.Cells["FOLIO"].Value.ToString() + "-" + row.Cells["LOTE"].Value.ToString(), 12);
                //frm.ShowDialog();
                // Inventario.controlCaducidadesSelectUserControl frmCc = new Inventario.controlCaducidadesSelectUserControl(row.Cells[0].Value.ToString(), 3, int.Parse(row.Cells[1].Value.ToString()));
                Inventario.ControlCaducidadesSalidasUserControl frmCc = new Inventario.ControlCaducidadesSalidasUserControl(row.Cells[0].Value.ToString(), mov, int.Parse(row.Cells[1].Value.ToString()));
                frmCc.Owner = this;
                frmCc.Muestra();
            }


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
               MessageBox.Show("Seleccione la cabecera de la Destruccion");
                return;
            }
            var row = (GridRow)container;
            if (!row.Cells["ACTIVO"].Value.ToString().Contains('X') & !row.Cells["ACTIVO"].Value.ToString().Contains('R'))
            {
                string folio = row.Cells[0].Value.ToString();
                int lote = Convert.ToInt16( row.Cells[1].Value);
                SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_destruccion.rpt", " {CS_RPT_DESTRUC_CAD.FOLIO}='" + folio + "' AND {CS_RPT_DESTRUC_CAD.LOTE}="+lote+"");///impresion de el REporte
                Impresion.ShowDialog();
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

            String ProductName = "Destrucciones";
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
                
             string   valido = Verifica.ValidaLInterno(row.Cells["FOLIOColumn"].Value.ToString(), row.Cells[1].Value.ToString(), mov);
                if (valido.Contains("-1"))
                {
                    MessageBox.Show(valido, "Caducidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBoxEx.Show("¿Aplicar la Destruccion " + row.Cells[0].Value.ToString()
                                                           + " - "
                                                           + row.Cells[1].Value.ToString() + "?",
                                   ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DataRow[] results = DsDestrucciones.DESTRUCCIONES_DET.Select("Folio='" + row.Cells[0].Value.ToString() + "'", "lote, ARTICULO_ID");
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
                    if (destruccionesAlmacen.AplicaAjuste22(row.Cells[0].Value.ToString(),
                                     Convert.ToInt16(row.Cells[1].Value.ToString()),
                                     Convert.ToInt16(row.Cells[2].Value.ToString().Split('-')[0]),
                                     row.Cells[4].Value.ToString(), Helpers.Sesion.Usuario.UsuariosID.ToString()) > 0)
                    { }




                 }

                else
                {
                   MessageBox.Show("Debe ser la misma sucursal destino verificar configuracion", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               
                imprimir();
            }
        }


        private void buttonItem2_Click(object sender, EventArgs e)
        {
            this.Cerrar();
        }

        private void buttonItem2_Click_1(object sender, EventArgs e)
        {
            this.Cerrar();
            this.Buscar();

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
