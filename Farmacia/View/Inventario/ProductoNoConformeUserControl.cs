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
    public partial class ProductoNoConformeUserControl : SIF.Templates.ListaUserControl
    {
        private int Cual = 0;
        public int ModuloID;
        public string tipo_movi_c;
        SIFModelo.Inventarios.InventarioDataSet DsPnc;

        public ProductoNoConformeUserControl()
        {
            InitializeComponent();
            this.dateTimeInput1.Value = DateTime.Parse("01/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year.ToString());
            this.dateTimeInput2.Value = DateTime.Parse(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year.ToString());
        }
      
        PNCNuevoUserControl frmPNC = new PNCNuevoUserControl();
        private void Nuevo()
        {
            if (!frmPNC.Mostrado)
            {
                frmPNC = new PNCNuevoUserControl();
                frmPNC.Parent = this;
                //frmPNC.AjusteID = "";
                frmPNC.Owner = Owner;
                frmPNC.Muestra();
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


        SIFNegocio.Inventario.PNCNegocio pncs = new SIFNegocio.Inventario.PNCNegocio();
        public void Buscar()
        {

            switch (Cual)
            {
                case 0:
                    //DsPnc = pncs.GetPncs(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "S", foliotextBoxX.Text);
                    DsPnc = pncs.GetPncs(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "ABIERTO", foliotextBoxX.Text);
                    break;
                case 1:
                    DsPnc = pncs.GetPncs(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "CANCELADO", foliotextBoxX.Text);
                    break;
                case 2:
                    DsPnc = pncs.GetPncs(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "CERRADO", foliotextBoxX.Text);
                    break;
                case 3:
                    DsPnc = pncs.GetPncs(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "ASIGNACION DE CADUCIDADES", foliotextBoxX.Text);
                    break;

            }
            DsPnc.Relations.Add("1", DsPnc.Tables["PNC"].Columns["FOLIO"], DsPnc.Tables["PNC_DET"].Columns["FOLIO"], false);

            DsPnc.PNC.DefaultView.Sort = "folio desc";
            this.superGridControl1.PrimaryGrid.DataSource = DsPnc;
            this.superGridControl1.PrimaryGrid.DataMember = "PNC";
        }

        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void nuevoButtonItem_Click(object sender, EventArgs e)
        {
            this.Nuevo();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            this.Envia();

        }

        private void caducidad_Click(object sender, EventArgs e)
        {
            this.capturaCaducidad();
        }

        PNCEditarUserControl frmEditar = new PNCEditarUserControl();
        private void Envia()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = (GridContainer) panel.ActiveRow;

            if (!(container is GridRow))
            {
               MessageBox.Show("Debe seleccionar el encabezado del movimiento","Producto No Conforme");
                return;
            }

            var row = (GridRow)container;

            if (!frmEditar.Mostrado && row.Cells["ACTIVO"].Value.ToString().Contains("ABIERTO"))
            {
                frmEditar = new PNCEditarUserControl();
                frmEditar.Parent = this;
                frmEditar.AjusteID = row.Cells[0].Value.ToString();
                frmEditar.Owner = this.Owner;
                frmEditar.Muestra();
            }
            else if (!frmEditar.Mostrado && row.Cells["ACTIVO"].Value.ToString().Contains("CANCELADO"))
            {
               MessageBox.Show("El folio esta cancelado no se puede editar", "Producto No Conforme");
            }
            else if (!frmEditar.Mostrado && row.Cells["ACTIVO"].Value.ToString().Contains("CERRADO"))
            {
                if (MessageBoxEx.Show("¿Desea editar el folio " + row.Cells[0].Value.ToString() + " - "
                                                           + row.Cells[1].Value.ToString() + "?",
                                  "Producto No Conforme", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string respuesta = pncs.Edita(row.Cells[0].Value.ToString(), Convert.ToInt32(row.Cells[1].Value.ToString()), Helpers.Sesion.Sucursal.SucursalID, Helpers.Sesion.Usuario.UsuariosID.ToString());

                    if (!respuesta.Contains("OK"))
                    {
                        MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                        
                    else
                    {
                        frmEditar = new PNCEditarUserControl();
                        frmEditar.Parent = this;
                        frmEditar.AjusteID = row.Cells[0].Value.ToString();
                        frmEditar.Owner = this.Owner;
                        frmEditar.Muestra();
                    }                        

                }
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.cancela();
        }

        private void cancela()
        {
            String ProductName = "Producto No Conforme";
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);
            
            if (!(container is GridRow))
            {
               MessageBox.Show("Debe seleccionar el encabezado del movimiento", "Producto No Conforme");
                return;
            }

            var row = (GridRow)container;

            if (row.Cells["ACTIVO"].Value.ToString().Contains("CERRADO") & Helpers.Sesion.Usuario.TipoUsuario.ToString() == "ADMINISTRATIVO")
            {

                if (MessageBoxEx.Show("¿Cancelar el folio " + row.Cells[0].Value.ToString() + " - "
                                                           + row.Cells[1].Value.ToString() + "?",
                                  ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string respuesta = pncs.Cancela(row.Cells[0].Value.ToString(), Convert.ToInt32(row.Cells[1].Value.ToString()), Helpers.Sesion.Sucursal.SucursalID, Helpers.Sesion.Usuario.UsuariosID.ToString());

                    if (!respuesta.Contains("OK"))
                        MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("El folio se ha cancelado", "Producto No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Buscar();
                    //imprimir();
                }

            } 
            else if (row.Cells["ACTIVO"].Value.ToString().Contains("CANCELADO"))
            {
               MessageBox.Show("El folio ya esta cancelado", ProductName);
            }
            else if ((row.Cells["ACTIVO"].Value.ToString().Contains("ABIERTO") || row.Cells["ACTIVO"].Value.ToString().Contains("ASIGNACION DE CADUCIDADES")) & Helpers.Sesion.Usuario.TipoUsuario.ToString() == "ADMINISTRATIVO")
            {
                if (MessageBoxEx.Show("¿Cancelar el folio " + row.Cells[0].Value.ToString() + " - "
                                                           + row.Cells[1].Value.ToString() + "?",
                                  ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string respuesta = pncs.CancelaAbiertos(row.Cells[0].Value.ToString(), Convert.ToInt32(row.Cells[1].Value.ToString()), Helpers.Sesion.Sucursal.SucursalID, Helpers.Sesion.Usuario.UsuariosID.ToString());

                    if (!respuesta.Contains("OK"))
                        MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("El folio se ha cancelado", "Producto No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Buscar();
                    //imprimir();
                }
            }
            else
            {
               MessageBox.Show("Para cancelar debes tener permisos de administrador", ProductName);
            }

        }

        private void capturaCaducidad()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);

            if (!(container is GridRow))
            {
               MessageBox.Show("Debe seleccionar el encabezado del movimiento", "Producto No Conforme");
                return;
            }

            var row = (GridRow)container;

            if (!row.Cells["ACTIVO"].Value.ToString().Contains("ABIERTO"))
            {
                MessageBox.Show("El movimiento tiene que estar abierto", "Producto No Conforme");
                return;
            }           

            Inventario.PNCCaducidadUserControl frmCc = new Inventario.PNCCaducidadUserControl(row.Cells[0].Value.ToString(), int.Parse(row.Cells[1].Value.ToString()));
            frmCc.Owner = this.Owner;
            frmCc.Parent = this;
            frmCc.Muestra();
          

        }

        private void PedidosAlmacenUserControl_Load(object sender, EventArgs e)
        {
            this.dateTimeInput1.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            this.dateTimeInput2.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

        }

        private int CierraTraspaso(string NoFolio, string NoLote)
        {
            SIFNegocio.Inventario.Traspasos tRAS = new SIFNegocio.Inventario.Traspasos();
            return tRAS.CierraTraspaso(Helpers.Sesion.Usuario.UsuariosID.ToString(), NoFolio, NoLote);
        }              

        private void btnModificarLotYCad_click(object sender, EventArgs e)
        {
            string tipo_mov = "2";//ajuste
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

            if (activosRadioButton.Checked)
            {
                if (frm_lotes.validParametro())
                {
                    if (row[4].Value.ToString() == "S")
                    {
                        frm_lotes._folio = row[0].Value.ToString();
                        frm_lotes._tipo_mov = tipo_mov;
                        frm_lotes._usuario = Helpers.Sesion.Usuario.UsuariosID.ToString();

                        frm_lotes.LlenadoDatos();

                        if (frm_lotes.muestra_form)
                        {
                            if (frm_lotes.ShowDialog() == DialogResult.OK)
                            { }

                        }

                    }
                    else
                    {
                        MessageBox.Show("Solo se permite la edición en movimientos de salida", "INFORMACION");
                    }
                }
                else
                {
                    MessageBox.Show("Esta funcion no esta activada", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            if (radioButton1.Checked)
            {
                if (frm_lotes.validParametro())
                {
                    if (row[4].Value.ToString() == "E")
                    {
                        frm_lotes._folio = row[0].Value.ToString();
                        frm_lotes._tipo_mov = tipo_mov;
                        frm_lotes._usuario = Helpers.Sesion.Usuario.UsuariosID.ToString();

                        frm_lotes.LlenadoDatos();

                        if (frm_lotes.muestra_form)
                        {
                            if (frm_lotes.ShowDialog() == DialogResult.OK)
                            { }

                        }

                    }
                    else
                    {
                        MessageBox.Show("Solo se permite la edición en traspasos de Entrada", "INFORMACION");
                    }
                }
                else
                {
                    MessageBox.Show("Esta funcion no esta activada", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
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

        private void folioButtonItem_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        private void existenciasButtonItem_Click(object sender, EventArgs e)
        {
            imprimirExistencias();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            this.Envia();
        }

        private void imprimir()
        {
            //GridPanel panel = superGridControl1.PrimaryGrid;
            //var container = ((GridContainer)panel.ActiveRow);
            // var row = (GridRow)container;

            GridPanel panel = superGridControl1.PrimaryGrid;
            if (panel.ActiveRow == null)
            {
               MessageBox.Show("Debe seleccionar el encabezado de un movimiento", "Producto No Conforme");
                return;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Debe seleccionar el encabezado del movimiento", "Producto No Conforme");
                return;
            }

            var row = (GridRow)container;
            if (row.Cells["ACTIVO"].Value.ToString()=="CERRADO")
            {
                string folio = row.Cells[0].Value.ToString();
                SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_PNC.rpt", " {PNC.FOLIO}='" + folio + "'");
                Impresion.ShowDialog();
            }
            else //if (row.Cells["ACTIVO"].Value.ToString()=="ABIERTO")
               MessageBox.Show("El folio debe estar cerrado", "Producto No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //else if (row.Cells["ACTIVO"].Value.ToString()=="CANCELADO")
              // MessageBox.Show("El folio esta cancelado", "Producto No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void imprimirExistencias()
        {
            //GridPanel panel = superGridControl1.PrimaryGrid;
            //var container = ((GridContainer)panel.ActiveRow);
            // var row = (GridRow)container;
            String ProductName = "Producto No Conforme";
            Ventas.FechasFacturaGlobalForm frmFechas = new Ventas.FechasFacturaGlobalForm();
            frmFechas.ShowDialog();

            //SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_PNC_FULL.rpt");
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_PNC_FULL2.rpt", " {PNC.FECHA_REG} >= DATE(" + frmFechas.dateTimeInput1.Value.ToString("yyyy,MM,dd") + ") AND  {PNC.FECHA_REG} <= DATE(" + frmFechas.dateTimeInput2.Value.ToString("yyyy,MM,dd") + ")", "", ProductName);
            Impresion.ShowDialog();

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
            if (activosRadioButton.Checked)
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

        private void AsignacionDCRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ADCRadioButton.Checked)
            {
                Cual = 3;
                this.Buscar();
            }
        }

        private void buttonItem2_Click_1(object sender, EventArgs e)
        {
            this.Cerrar();
        }

        private void Cerrar()
        {
            string folioAjuste = "";
            string lote = "";
            String ProductName = "Producto No Conforme";
            string valido;

            GridPanel panel = superGridControl1.PrimaryGrid;
            if (panel.ActiveRow == null)
            {
                return;
            }

            var container = ((GridContainer)panel.ActiveRow);

            if (!(container is GridRow))
            {
               MessageBox.Show("Debe seleccionar el encabezado del movimiento", "Producto No Conforme");
                return;
            }

            var row = (GridRow)container;

            if (row.Cells["ACTIVO"].Value.ToString().Contains("ASIGNACION DE CADUCIDADES"))
            {
                folioAjuste = row.Cells[0].Value.ToString();
                lote = row.Cells[1].Value.ToString();

                valido = pncs.ObtieneAjusteCad(folioAjuste, lote);

                if (valido.Contains("-1") || valido.Contains("ORA-"))
                {
                    MessageBox.Show(valido, "Producto No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBoxEx.Show("¿Desea cerrar el folio " + row.Cells[0].Value.ToString()
                                                           + " - "
                                                           + row.Cells[1].Value.ToString() + "?",
                                   ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string respuesta = pncs.Cierre(row.Cells[0].Value.ToString(), Convert.ToInt32(row.Cells[1].Value.ToString()), Helpers.Sesion.Sucursal.SucursalID, Helpers.Sesion.Usuario.UsuariosID.ToString());

                    if (!respuesta.Contains("OK"))
                        MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Folio cerrado con éxito", "Producto No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Buscar();
                    //imprimir();
                }

            }
            else if (row.Cells["ACTIVO"].Value.ToString().Contains("CANCELADO"))
            {
                MessageBox.Show("El folio esta cancelado no se puede cerrar", "Producto No Conforme");
            }
            else if (row.Cells["ACTIVO"].Value.ToString().Contains("CERRADO"))
            {
                MessageBox.Show("El folio ya esta cerrado", "Producto No Conforme");
            }
            else if (row.Cells["ACTIVO"].Value.ToString().Contains("ABIERTO"))
            {
                MessageBox.Show("Debe asignar los lotes y las caducidades", "Producto No Conforme");
            }


        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            //    this.Cerrar();
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
