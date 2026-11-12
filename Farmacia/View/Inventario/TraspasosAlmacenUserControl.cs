//TraspasosAlmacenUserControl.cs
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
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;

namespace SIF.View.Inventario
{
    public partial class TraspasosAlmacenUserControl : Templates.ListaUserControl
    {
        int Cual = 0;
        public int ModuloID;
        SIFNegocio.Inventario.Traspasos TraspasoAlmacen = new SIFNegocio.Inventario.Traspasos();
        SIFModelo.Inventarios.InventarioDataSet DsPedidosTrasp;
        SIFModelo.Tipos.parmFac parametrosFac = new SIFModelo.Tipos.parmFac();
        public TraspasosAlmacenUserControl()
        {
            InitializeComponent();
            //this.dateTimeInput1.Value = DateTime.Parse("01/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year.ToString());
            //this.dateTimeInput2.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor().AddHours(24);
            this.dateTimeInput1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            this.dateTimeInput2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            this.cargarMotivoPedido();
            this.CargaSucursalDestino();
            Privilegios();
        }
        /// <summary>
        /// AVM 15-08-2015
        /// Carga las sucursales 
        /// </summary>
        private void CargaSucursalDestino()
        {
            BindingList<SIFModelo.Sucursal> sucursales = new BindingList<SIFModelo.Sucursal>();
            //SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { Nombre = "[TODAS]", SucursalesID = 0 };
            //sucursales.Add(sucursal);
            //sucursales.ToList();d
            List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().Buscar("", "S").DataSource as List<SIFModelo.Sucursal>;//L 03/01/2013 PARA QUE SOLO SE MUESTREN LOS ALMACENES ACTIVOS EN SUCURSAL DESTINO

            /// AVM 21-04-2015
            SIFModelo.Sucursal modelSeleccione = new SIFModelo.Sucursal();
            modelSeleccione.Nombre = "SUCURSAL...";
            modelSeleccione.SucursalesID = -1;
            modelSeleccione.SucursalID = -1;

            sucursales.Add(modelSeleccione);
            /// AVM 21-04-2015

            foreach (SIFModelo.Sucursal sucursalBd in sucursalesBD)
            {
                sucursales.Add(sucursalBd);
            }

            cmbSucursal.DataSource = sucursales;
            cmbSucursal.DisplayMember = "NOMBRE";
            cmbSucursal.ValueMember = "SUCURSALESID";
        }

        /// <summary>
        /// AVM 15-08-2015
        /// CARGA EL MOTIVO DEL PEDIDO.
        /// </summary>
        private void cargarMotivoPedido()
        {
            List<SIFModelo.MotivoPedido> MotivoPedido_List = new List<SIFModelo.MotivoPedido>();

            SIFNegocio.MotivoPedido MotivoPedidoN = new SIFNegocio.MotivoPedido();
            SIFModelo.MotivoPedido MotivoPedidoM = new SIFModelo.MotivoPedido();
            MotivoPedidoM.ID = -1;
            MotivoPedidoM.NOMBRE = "TIPO PEDIDO...";

            foreach (var item in MotivoPedidoN.Buscar())
            {
                if (MotivoPedido_List.Count == 0)
                    MotivoPedido_List.Add(MotivoPedidoM);

                MotivoPedido_List.Add(item);
            }

            cmbTipoPedido.DataSource = MotivoPedido_List;
            cmbTipoPedido.DisplayMember = "NOMBRE";
            cmbTipoPedido.ValueMember = "ID";

        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    if (ModuloID == 3)
                        Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 23, int.Parse(Xbtn.Tag.ToString()));
                    else if (Xbtn.Tag.ToString() == "47")//PIT 18/01/2022 Respetar el permiso del tag original
                    {
                        //Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 13, int.Parse(Xbtn.Tag.ToString()));
                    }
                    else
                        Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 30, int.Parse(Xbtn.Tag.ToString()));
            }

        }

        TraspasoAlmacenUserControl frmTraspaso = new TraspasoAlmacenUserControl();
        private void Nuevo()
        {
            if (!frmTraspaso.Mostrado)
            {
                frmTraspaso = new TraspasoAlmacenUserControl();
                frmTraspaso.Owner = this;
                frmTraspaso.Muestra();
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

            this.Dock = DockStyle.Fill;
            Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.ActivaComandos();
            this.Owner.DesactivaComandos();
            Mostrado = true;
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
                this.DesactivaComandos();
                this.Owner.ActivaComandos();
                Mostrado = false;
            }
            catch
            {
            }
        }

        public void DesactivaComandos()
        {

        }

        SIFNegocio.Inventario.Traspasos traspasoAlmacen = new SIFNegocio.Inventario.Traspasos();
        public void Buscar()
        {
            //DsPedidosTrasp.TRASPASO_DET = traspasoAlmacen.GetTraspasoDet(dateTimeInput1.Value.ToString(), dateTimeInput2.Value.ToString());
            int SucDestino = int.Parse(cmbSucursal.SelectedValue.ToString());
            int tipoPedido = int.Parse(cmbTipoPedido.SelectedValue.ToString());

            switch (Cual)
            {
                case 0:
                    DsPedidosTrasp = traspasoAlmacen.GetTraspasos(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "S",
                        foliotextBoxX.Text, Helpers.Sesion.Sucursal.SucursalesID, "S", SucDestino, tipoPedido);
                    break;
                case 1:
                    DsPedidosTrasp = traspasoAlmacen.GetTraspasos(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "C",
                        foliotextBoxX.Text, Helpers.Sesion.Sucursal.SucursalesID, "S", SucDestino, tipoPedido);
                    break;
                case 2:
                    DsPedidosTrasp = traspasoAlmacen.GetTraspasos(dateTimeInput1.Value, dateTimeInput2.Value.AddDays(1), "X",
                        foliotextBoxX.Text, Helpers.Sesion.Sucursal.SucursalesID, "S", SucDestino, tipoPedido);
                    break;
                case 3:
                    DsPedidosTrasp = traspasoAlmacen.GetTraspasos(dateTimeInput1.Value, dateTimeInput2.Value, "SE",
                        foliotextBoxX.Text, Helpers.Sesion.Sucursal.SucursalesID, "S", SucDestino, tipoPedido);
                    break;
            }

            DataColumn[] pColumns = new DataColumn[] { DsPedidosTrasp.Tables["TRASPASO"].Columns["FOLIO"],
                                                       DsPedidosTrasp.Tables["TRASPASO"].Columns["LOTE"] };

            DataColumn[] cColumns = new DataColumn[] { DsPedidosTrasp.Tables["TRASPASO_DET"].Columns["FOLIO"],
                                                       DsPedidosTrasp.Tables["TRASPASO_DET"].Columns["LOTE"] };
            if (Helpers.Sesion.Sucursal.SucursalesID != 1)
                DsPedidosTrasp.Relations.Add("1", pColumns, cColumns, false);

            ////DsPedidosTrasp.Relations.Add("1", DsPedidosTrasp.Tables["TRASPASO"].Columns["FOLIO"],
            ////                                  DsPedidosTrasp.Tables["TRASPASO_DET"].Columns["FOLIO"], false);

            DsPedidosTrasp.TRASPASO.DefaultView.Sort = "fecha desc";

            this.superGridControl1.PrimaryGrid.DataSource = DsPedidosTrasp;
            this.superGridControl1.PrimaryGrid.DataMember = "TRASPASO";

            GridPanel panel = superGridControl1.PrimaryGrid;
            SIFNegocio.Inventario.Traspasos traspasoAlmacenL = new SIFNegocio.Inventario.Traspasos();

            ////this.superGridControl1.PrimaryGrid.Columns["SUCURSAL_DESTINO"].Visible = false;
            ////this.superGridControl1.PrimaryGrid.Columns["SUCURSAL_ORIGEN"].Visible = false;
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

        private bool ValidaOrigenDestinoExistente(GridRow row)
        {
            string origen = row.Cells[3].Value.ToString();
            string destino = row.Cells[4].Value.ToString();

            if (origen.Contains("NO EXISTE"))
            {
               MessageBox.Show("El origen no existe");
                return false;
            }

            if (destino.Contains("NO EXISTE"))
            {
               MessageBox.Show("El destino no existe");
                return false;
            }

            return true;
        }

        private void Envia()
        {
            // enviar pedido
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

            if (!ValidaOrigenDestinoExistente(row))
            {
                return;
            }

            //verificar si el traspaso ya fue acualizado
            if (row.Cells["ACTIVOColumn"].Value.ToString().Contains('S'))
            {
                int SucPed = int.Parse(row.Cells[3].Value.ToString().Split('-')[0]);
                if (SucPed == Helpers.Sesion.Sucursal.SucursalID)
                {
                    if (MessageBoxEx.Show("¿Enviar el Traspaso: " + row.Cells[0].Value.ToString()
                                                                        + " - " + row.Cells["LOTE"].Value.ToString()
                                                                        + "?",
                                    ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        DataTable dtPedido = TraspasoAlmacen.GetTraspasoDet(row.Cells[0].Value.ToString(), int.Parse(row.Cells["LOTE"].Value.ToString()));
                        DataRow[] results = dtPedido.Select(null, "lote, id");
                        // IN Pedido Array's
                        int[] Lote = new int[results.Length];
                        int[] Sec = new int[results.Length];
                        String[] Articulo = new String[results.Length];
                        String[] Concepto = new String[results.Length];
                        Double[] Total = new Double[results.Length];
                        Double[] Precio = new Double[results.Length];
                        int[] Caja = new int[results.Length];
                        int[] Cant = new int[results.Length];
                        int[] CantE = new int[results.Length];
                        String[] NoLote = new String[results.Length];
                        String[] FecCad = new String[results.Length];
                        int ind = 0, sec = 0;
                        string CtlLote = string.Empty;

                        foreach (DataRow rows in results)
                        {
                            if (CtlLote.Contains(rows["lote"].ToString()))
                            {
                                sec++;
                                Lote[ind] = Convert.ToInt16(rows["lote"].ToString());
                                Sec[ind] = sec;
                                Articulo[ind] = rows["id"].ToString();
                                Concepto[ind] = rows["nombre"].ToString();
                                Cant[ind] = Convert.ToInt16(rows["Pedido"]);
                                CantE[ind] = Convert.ToInt16(rows["enviado"]);
                                Precio[ind] = Convert.ToDouble(rows["Costo"]);
                                Caja[ind] = Convert.ToInt16(rows["Caja"]);
                                NoLote[ind] = rows["NoLote"].ToString();
                                FecCad[ind] = rows["FechaCad"].ToString();
                            }
                            else
                            {
                                sec = 0;
                                sec++;
                                CtlLote = rows["lote"].ToString();
                                Lote[ind] = Convert.ToInt16(rows["lote"].ToString());
                                Sec[ind] = sec;
                                Articulo[ind] = rows["id"].ToString();
                                Concepto[ind] = rows["nombre"].ToString();
                                Cant[ind] = Convert.ToInt16(rows["Pedido"]);
                                CantE[ind] = Convert.ToInt16(rows["enviado"]);
                                Precio[ind] = Convert.ToDouble(rows["Costo"]);
                                Caja[ind] = Convert.ToInt16(rows["Caja"]);
                                object objSum = dtPedido.Compute("Sum(total)", "lote = " + CtlLote);
                                Total[ind] = Convert.ToDouble(objSum.ToString());
                                NoLote[ind] = rows["NoLote"].ToString();
                                FecCad[ind] = rows["FechaCad"].ToString();
                            }
                            ind++;
                        }
                        int TotalR = 0;
                        if (row.Cells[8].Value.ToString() != "")
                            TotalR = int.Parse(row.Cells[8].Value.ToString());
                        object objSum1 = dtPedido.Compute("Sum(enviado)", "");
                        int CantEnv = int.Parse(objSum1.ToString());
                        if (CantEnv > 0)
                            TraspasoAlmacen.EnviaTraspasox(row.Cells[0].Value.ToString(), Lote, Convert.ToInt16(row.Cells[3].Value.ToString().Split('-')[0]), Convert.ToInt16(row.Cells[4].Value.ToString().Split('-')[0]),
                                TotalR, Sec, Articulo, Concepto, Cant, CantE, Precio, Caja, Total, Helpers.Sesion.Usuario.UsuariosID.ToString(), NoLote, FecCad);
                        else
                           MessageBox.Show("No se ha ingresado ninguna cantidad", ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                        ////InsPedido(Convert.ToInt16(cmb_OrigPedido.Text.Split('-')[0]), Convert.ToInt16(cmb_DestPedido.Text.Split('-')[0]), tb_TotalPedido.Value,
                        ////          Lote, Sec, Articulo, Concepto, Cant, Total);
                    }
                }
                else
                {
                   MessageBox.Show("Debe ser la misma sucursal origen verificar configuración", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (row.Cells["ACTIVOColumn"].Value.ToString().Contains('P'))
                   MessageBox.Show("El traspaso ya se envio", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                   MessageBox.Show("El traspaso esta cancelado", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Buscar();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {

            this.Cerrar();
            //   this.Envia();
            this.Buscar();
        }

        //private int CancelTraspaso(string NoFolio, string NoLote)
        //{
        //    SIFNegocio.Inventario.Traspasos tRAS = new SIFNegocio.Inventario.Traspasos();
        //    return tRAS.CancelTraspaso(NoFolio, NoLote);
        //}

        private string CancelTraspaso(string NoFolio, string NoLote)
        {
            SIFNegocio.Inventario.Traspasos tRAS = new SIFNegocio.Inventario.Traspasos();
            return tRAS.Cancel_Traspaso(NoFolio, NoLote);
        }

        #region comentado
        //private void cancela()
        //{
        //    String ProductName = "Traspasos";
        //    GridPanel panel = superGridControl1.PrimaryGrid;
        //    if (panel.ActiveRow == null)
        //    {
        //        return;
        //    }

        //    var container = ((GridContainer)panel.ActiveRow);
        //    if (!(container is GridRow))
        //    {
        //       MessageBox.Show("Seleccione la cabecera del traspaso");
        //        return;
        //    }
        //    var row = (GridRow)container;
        //    if (!row.Cells["ACTIVOColumn"].Value.ToString().Contains('X'))
        //    {
        //        if (MessageBoxEx.Show("¿Cancelar el Traspaso " + row.Cells[0].Value.ToString()
        //                                                   + " - "
        //                                                   + row.Cells[1].Value.ToString() + "?",
        //                          ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
        //        {
        //            if (CancelTraspaso(row.Cells[0].Value.ToString(),
        //                              row.Cells[1].Value.ToString()) > 0)
        //                row.Cells["ACTIVOColumn"].Value = "X";
        //            this.Buscar();
        //        }
        //    }
        //}
        #endregion

        private void cancela()
        {
            string pError = "actualizados";
            string Resul = string.Empty;
            String ProductName = "Traspasos";
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
            if (!row.Cells["ACTIVOColumn"].Value.ToString().Contains('X'))
            {
                if (MessageBoxEx.Show("¿Cancelar el Traspaso " + row.Cells[0].Value.ToString()
                                                           + " - "
                                                           + row.Cells[1].Value.ToString() + "?",
                                  ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Resul = CancelTraspaso(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());

                    if (Regex.IsMatch(Resul, pError))
                    {
                        row.Cells["ACTIVOColumn"].Value = "X";
                        this.Buscar();
                    }

                   MessageBox.Show(Resul, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            SIF.View.Ventas.CambiarContrasenhaUsuarioLogin frmCambiarPassConfirm = new Ventas.CambiarContrasenhaUsuarioLogin();
            if (frmCambiarPassConfirm.ShowDialog() == DialogResult.OK && (frmCambiarPassConfirm.Usuario.TipoUsuario == SIFModelo.Tipos.TipoUsuario.ADMINISTRATIVO || frmCambiarPassConfirm.Usuario.TipoUsuario == SIFModelo.Tipos.TipoUsuario.SUPERVISOR))
            {
                this.cancela();
            }
            else
            {
                return;
            }

        }

        private void Actualizar()
        {

            String ProductName = "Traspasos";
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
            if (row.Cells["ACTIVOColumn"].Value.ToString().Contains('S'))
            {
                if (int.Parse(row.Cells["TOTALColumn"].Value.ToString()) < 1)
                {
                   MessageBox.Show("No existe detalle del traspaso", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (!frmTraspaso.Mostrado)
                {
                    SIF.View.Inventario.SelectFilas frmSel = new SelectFilas();
                    if (!row.Cells["REFERENCIAColumn"].Value.ToString().Equals(""))
                    {
                        frmSel.lote = int.Parse(row.Cells[1].Value.ToString());
                        frmSel.folio = row.Cells[0].Value.ToString();

                        if (System.Windows.Forms.DialogResult.OK != frmSel.ShowDialog())
                        {
                            return;
                        }
                    }

                    frmTraspaso = new TraspasoAlmacenUserControl();

                    if (!row.Cells["REFERENCIAColumn"].Value.ToString().Equals(""))
                        frmTraspaso.filasMostrar = frmSel.filas;

                    frmTraspaso.TraspasoID = row.Cells[0].Value.ToString(); // Int64.Parse(row.Cells[0].Value.ToString());
                    frmTraspaso.lote = int.Parse(row.Cells[1].Value.ToString());
                    frmTraspaso.Origen = row.Cells[3].Value.ToString();
                    frmTraspaso.Destino = row.Cells[4].Value.ToString();
                    frmTraspaso.RefPedido = row.Cells["REFERENCIAColumn"].Value.ToString();
                    frmTraspaso.RefPedido = row.Cells[10].Value.ToString();
                    frmTraspaso.idMotivoT= int.Parse(cmbTipoPedido.SelectedValue.ToString());
                    /*if (!string.IsNullOrEmpty(row.Cells[12].Value.ToString()))
                    {                   
                        if(row.Cells[12].Value.ToString()=="SISTEMA"){
                        frmTraspaso.idMotivoT = 6;
                        }
                    }*/
                    frmTraspaso.Owner = this;
                    frmTraspaso.Muestra();
                    //this.Buscar();
                }

            }
            else
            {
                if (row.Cells["ACTIVOColumn"].Value.ToString().Contains('C'))
                   MessageBox.Show("El traspaso ya se envió", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                   MessageBox.Show("El traspaso está cancelado", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void superGridControl1_DoubleClick(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

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

        private void buttonItem1_Click_1(object sender, EventArgs e)
        {
            Actualizar();
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
            if (!row.Cells["ACTIVOColumn"].Value.ToString().Contains('S') && (creditoRadioButton.Checked || porsurtirRadioButton.Checked))
            {
                MessageBox.Show("El movimiento tiene que estar cerrado");
                return;
            }
            SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(SIF.Helpers.Sesion.Usuario.UsuariosID);

            if (porsurtirRadioButton.Checked || creditoRadioButton.Checked)
            {
                //Inventario.frmCapturaCaducidades frm = new Inventario.frmCapturaCaducidades(usuario, row.Cells["FOLIO"].Value.ToString() + "-" + row.Cells["LOTE"].Value.ToString(), 12);
                //frm.ShowDialog();
               // Inventario.controlCaducidadesSelectUserControl frmCc = new Inventario.controlCaducidadesSelectUserControl(row.Cells[0].Value.ToString(), 3, int.Parse(row.Cells[1].Value.ToString()));
                Inventario.ControlCaducidadesSalidasUserControl frmCc = new Inventario.ControlCaducidadesSalidasUserControl(row.Cells[0].Value.ToString(), 3, int.Parse(row.Cells[1].Value.ToString()));
                frmCc.Owner = this;
                frmCc.Muestra();
            }


        }

        private void imprimir()
        {
            String ProductName = "Traspasos";
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
            //L 15/11/2013 se modifica para que se imprima el traspaso aunque ya haya sido enviado
            //if (/*row.Cells["ACTIVOColumn"].Value.ToString().Contains('S')*/ true)
            // {
            try
            {
                SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Pedido_Almacen_General1.rpt", "{CS_RPT_ENCABEZADO_TRASPASO_CAD.FOLIO} = '" + row.Cells[0].Value.ToString() + "' AND {CS_RPT_ENCABEZADO_TRASPASO_CAD.LOTE}=" + row.Cells[1].Value.ToString());
                // SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("orden123.rpt", "{CS_ASIGNA_PRECIOS_ORDENES2019.FOLIO} = '19054898'");
                Impresion.ShowDialog();
            }
            catch (Exception xp) {
                MessageBox.Show(xp.ToString());
            }
            // }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        /* VALILDAR LA OPCION DE GENERAR ARCHIVO */
        private void GeneraArchivo()
        {
            String ProductName = "Traspasos";
            GridPanel panel = superGridControl1.PrimaryGrid;
            if (panel.ActiveRow == null)
            {
                return;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Seleccione la cabecera del  Traspaso");
                return;
            }

            // generamos uns archivo para la importacion del traspaso.

            var row = (GridRow)container;
            SIFModelo.Inventarios.InventarioDataSet.TRASPASORow traspaso = (SIFModelo.Inventarios.InventarioDataSet.TRASPASORow)((DataRowView)row.DataItem).Row;

            if (!row.Cells["ACTIVOColumn"].Value.ToString().Contains('X'))
            {
                saveFileDialog1.Title = "Exportar el traspaso en un archivo";
                string titulo = traspaso.FOLIO + "-" + traspaso.SUCURSAL_ORIGEN + "-" + traspaso.SUCURSAL_DESTINO + "-" + traspaso.LOTE;
                saveFileDialog1.FileName = titulo + ".traspaso";
                if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                if (saveFileDialog1.FileName != "")
                {
                    //SIFModelo.Inventarios.InventarioDataSet PedidosTrasp = traspasoAlmacen.GetTraspasos(dateTimeInput1.Value, dateTimeInput2.Value, "", row.Cells[0].Value.ToString(), Helpers.Sesion.Sucursal.SucursalesID, "S");
                    // PedidosTrasp.WriteXml(saveFileDialog1.FileName);
                    //ACTUALIZAMOS EL TRASPASO Y LAS EXISTENCIAS.

                    string url = saveFileDialog1.FileName;

                    //if (System.IO.File.Exists(url))
                    //{
                    //    var res = MessageBox.Show("El archivo " + titulo + " ya existe, ¿desea reemplazarlo?", "Reemplazar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //    if (res == DialogResult.No)
                    //    {
                    //        return;
                    //    }
                    //    else
                    //    {
                    //        System.IO.File.Delete(url);
                    //    }
                    //}

                    using (StreamWriter sw = new StreamWriter(url))
                    {
                        //SECUENCIA DE PEDIDO TRASPASO .ToString("yyyy/MM/dd HH:mm:ss")
                        string header = traspaso.FOLIO + "|" + traspaso.LOTE + "|" + traspaso.FECHA + "|" + traspaso.SUCURSAL_ORIGEN.ToString() + "|" + traspaso.TOTAL + "|" + "0" + "|" +/* traspaso.FECHA_SURTIO*/ "|" + traspaso.USUARIO_ENVIA + "|" + /*traspaso.USUARIO_RECIBE +*/ "|" + traspaso.ACTIVO + "|" + traspaso.SUCURSAL_DESTINO.ToString();
                        sw.WriteLine(header);

                        var det = new SIFNegocio.Inventario.Traspasos().GetTraspasoDetalle(traspaso.FOLIO, traspaso.LOTE);

                        foreach (DataRow detalle in det.Rows)
                        {
                            string sdet = detalle["PEDIDO"] + "|" + detalle["LOTE"] + "|" + detalle["PARTIDA"] + "|" + detalle["ID"] + "|" + detalle["NOMBRE"] + "|" + detalle["PEDIDO"] + "|" + detalle["ENVIADO"] + "|" + detalle["COSTO"] + "|" + ""/*detalle["PRECIO_RECIBE"]*/ + "|" + detalle["CAJA"].ToString() + "|" + detalle["INCIDENCIA"] + "|" + detalle["DEVUELTA"];//+ detalle.TIPO_MEDIC;
                            sw.WriteLine(sdet);
                        }
                    }
                    //actualizar el status
                    //pedidoAlmacen.UpdateEdoPedido(traspaso.FOLIO, traspaso.LOTE.ToString());
                    MessageBox.Show("Se generó el archivo correctamente");
                }
            }
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            GeneraArchivo();
        }

        /* VALILDAR LA OPCION DE IMPORTAR ARCHIVO */
        private void AbrirArchivo()
        {
            openFileDialog1.Title = "Selecciona el archivo de traspaso";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                // procesamos el archivo
                try
                {
                    SIFModelo.Inventarios.InventarioDataSet PedidosTrasp = new SIFModelo.Inventarios.InventarioDataSet();
                    PedidosTrasp.ReadXml(openFileDialog1.FileName);
                    //guardamos el traspaso y le asignamos nuevo folio

                    DataRow[] results = PedidosTrasp.PEDIDO_TRASP_DET1.Select(null, "lote,partida");
                    // IN Pedido Array's
                    int[] Sec = new int[results.Length];
                    int[] Lotes = new int[results.Length];
                    String[] Articulo = new String[results.Length];
                    String[] Concepto = new String[results.Length];
                    int[] CantS = new int[results.Length];
                    int[] CantE = new int[results.Length];
                    int[] CantR = new int[results.Length];
                    Double[] PrecioE = new Double[results.Length];
                    int[] Caja = new int[results.Length];
                    String[] Pedido = new String[results.Length];
                    Decimal[] TotLote = new Decimal[results.Length];
                    String[] NoLote = new String[results.Length];
                    String[] FecCad = new String[results.Length];
                    Double Total = 0;
                    Decimal DTotal = 0;
                    int sec = 0;
                    DataRow Pedidos = PedidosTrasp.PEDIDO_TRASP.Rows[0];
                    string CtlFolio = Pedidos["FOLIO"].ToString();
                    string CtlLote = Pedidos["Lote"].ToString();

                    ///SE OBTIENE EL MOTIVO DEL TRASPASO DEL ARCHIVO DE EXCEL
                    int ID_MOTIVO = 0;

                    object objSum = PedidosTrasp.PEDIDO_TRASP_DET1.Compute("Sum(CANTIDAD_SOLIC)", "lote = " + CtlLote);
                    if (objSum.ToString() != "")
                        Total = Convert.ToDouble(objSum.ToString());

                    foreach (DataRow rowdet in results)
                    {
                        Sec[sec] = sec + 1;
                        Articulo[sec] = rowdet["ARTICULO_ID"].ToString();
                        Concepto[sec] = rowdet["CONCEPTO"].ToString();
                        CantS[sec] = Convert.ToInt16(rowdet["CANTIDAD_SOLIC"]);
                        CantE[sec] = 0;
                        CantR[sec] = 0;
                        PrecioE[sec] = 0;
                        Caja[sec] = 0;
                        Pedido[sec] = rowdet["CANTIDAD_SOLIC"].ToString();
                        NoLote[sec] = rowdet["REFLOTE"].ToString();
                        FecCad[sec] = rowdet["CADUCIDAD"].ToString();
                        sec++;
                    }
                    TraspasoAlmacen.InsertaTraspasoAlmacen(Helpers.Sesion.Usuario.UsuariosID.ToString(), int.Parse(Pedidos["Destino"].ToString().Split('-')[0]), int.Parse(Pedidos["Origen"].ToString().Split('-')[0]), DTotal, Lotes, Sec, Articulo, Concepto, CantS, CantE, CantR, TotLote, PrecioE, Caja, NoLote, FecCad, ID_MOTIVO);

                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message, "Traspasos obtener archivo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally
                {

                }
            }
        }
        /*
        private void ImportarArchivo()
        {
            Int16 nPartida = 0;
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Archivo de Pedido SIF (*.csv)|*.csv";
            if (opf.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (!opf.CheckFileExists)
            {
               MessageBox.Show("El archivo especificado no existe, por favor verifique");
                return;
            }




            string[] lineas = System.IO.File.ReadAllLines(opf.FileName);
            if (lineas.Count() <= 0)
            {
               MessageBox.Show("El archivo no tiene información");
                return;
            }


            SIFModelo.Inventarios.InventarioDataSet dtsInventario = new SIFModelo.Inventarios.InventarioDataSet();
            SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASPRow traspaso = null;
            DateTime fecha = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            foreach (string linea in lineas)
            { 
                 
                if (linea == lineas[0])
                {
                    traspaso = dtsInventario.PEDIDO_TRASP.NewPEDIDO_TRASPRow();
                    string[] param = linea.Split(new char[] { ',' });

                    
/*                    traspaso.FOLIO = param[0];
                    traspaso.LOTE = System.Convert.ToInt32(param[1]);
                    traspaso.FECHA = DateTime.Parse(param[2]);
                    traspaso.SUCURSAL_GENERA = System.Convert.ToInt32(param[10]);
                    traspaso.TOTAL = System.Convert.ToInt32(param[4]);
                    traspaso.FOLIO_TRASPASO = param[5].ToString();
                    ////traspaso.FECHA_SURTIDO = param[6].ToString();
                    traspaso.USUARIO_GENERA = param[7].ToString();
                    ////traspaso.USUARIO_RECIBE = param[8].ToString();
                    traspaso.ACTIVO = param[9].ToString();
                    traspaso.SUCURSAL_RECIBE = System.Convert.ToInt32(param[3]);
                    dtsInventario.PEDIDO_TRASP.AddPEDIDO_TRASPRow(traspaso);*-


                    traspaso.FOLIO = "010002015";
                    traspaso.LOTE = 1;
                    traspaso.FECHA = fecha;
                    traspaso.SUCURSAL_GENERA = 1;
                    traspaso.TOTAL = 0;
                    traspaso.FOLIO_TRASPASO = "";
                    ////traspaso.FECHA_SURTIDO = param[6].ToString();
                    traspaso.USUARIO_GENERA = SIFNegocio.Helpers.Sesion.Usuario.UsuariosID.ToString();
                    ////traspaso.USUARIO_RECIBE = param[8].ToString();
                    traspaso.ACTIVO = "S";
                    traspaso.SUCURSAL_RECIBE = System.Convert.ToInt32(param[3]);
                    dtsInventario.PEDIDO_TRASP.AddPEDIDO_TRASPRow(traspaso);
                    continue;
                }

                SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow detalle = dtsInventario.PEDIDO_TRASP_DET.NewPEDIDO_TRASP_DETRow();
                string[] paramDet = linea.Split(new char[] { ',' });
                //detalle.FOLIO + "|" + detalle.LOTE + "|" + detalle.PARTIDA + "|" + detalle.ARTICULO_ID + "|" + detalle.CANTIDAD_SOLIC + "|" + detalle.CONCEPTO + "|";//+ detalle.TIPO_MEDIC;
                detalle.FOLIO = "010002015";
                detalle.LOTE = 1;
                detalle.PARTIDA = System.Convert.ToInt16(nPartida + 1);
                detalle.ARTICULO_ID = paramDet[0];
                detalle.CANTIDAD_SOLIC = System.Convert.ToInt32(paramDet[2]);
                detalle.CONCEPTO = paramDet[1];
                //detalle.TIPO_MEDIC = paramDet[6];
                detalle.PRECIO = 0; //System.Convert.ToDecimal(paramDet[6]);
                dtsInventario.PEDIDO_TRASP_DET.AddPEDIDO_TRASP_DETRow(detalle);
                nPartida += 1;
            }

            //LLAMAR AL STORE PROCEDURE 
            SIFNegocio.Inventario.Traspasos traspasoL = new SIFNegocio.Inventario.Traspasos();
            traspasoL.ImportaPedidoAlmacen(Helpers.Sesion.Usuario.UsuariosID, traspaso, dtsInventario.PEDIDO_TRASP_DET);
            MessageBox.Show("Se ha importado correctamente el archivo");
        }*/


        private void ImportarArchivo()
        {

            Int16 nPartida = 0;
            int suc = Convert.ToInt16(ImpFileTraspasoSelect.sucursalD.ToString());
            int idmotivo = Convert.ToInt16(ImpFileTraspasoSelect.motivoPedido.ToString());
            SIFNegocio.Articulo ba = new SIFNegocio.Articulo();
            //SIFModelo.Articulo Articulo = new SIFModelo.Articulo();--Es obsoleto 20/8/25

            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Archivo de Pedido SIF (*.csv)|*.csv";
            if (opf.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (!opf.CheckFileExists)
            {
               MessageBox.Show("El archivo especificado no existe, por favor verifique");
                return;
            }

            string[] lineas = System.IO.File.ReadAllLines(opf.FileName);
            if (lineas.Count() <= 0)
            {
               MessageBox.Show("El archivo no tiene información");
                return;
            }


            SIFModelo.Inventarios.InventarioDataSet dtsInventario = new SIFModelo.Inventarios.InventarioDataSet();
            //SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASPRow traspaso = null;--obsoleto 20/8/25
            DateTime fecha = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            Regex objNoAlpha = new Regex(@"[^a-zA-Z0-9\s]");
            bool OperacionViva = false;
            try
            {
                DataTable dtPedido = new DataTable();
                dtPedido.Columns.Add("id", typeof(string));
                //dtPedido.Columns.Add("cantidad", typeof(int));
                dtPedido.PrimaryKey = new DataColumn[] { dtPedido.Columns["id"] };


                foreach (string linea in lineas)
                {
                    //Cambio para asociar el lote de todos los articulo a importar XFM
                    string[] paramDet = linea.Split(new char[] { ',' });

                    if (paramDet.Length < 2)
                        continue; // línea inválida

                    string articuloId = paramDet[0].Trim();
                    int cantidad = Convert.ToInt32(paramDet[1]);


                    // Validaciones
                    if (objNoAlpha.IsMatch(articuloId))
                    {
                        MessageBox.Show("El código del Artículo " + articuloId + " es inválido");
                        OperacionViva = false;
                        break;
                    }

                    if (ba.BuscarPorClave(articuloId) == null)
                    {
                        MessageBox.Show("El código del Artículo " + articuloId + " No Existe");
                        OperacionViva = false;
                        break;
                    }

                    // validar duplicados en dtPedido
                    if (dtPedido.Rows.Find(articuloId) != null)
                    {
                        MessageBox.Show("El artículo " + articuloId + " ya está en el archivo");
                        continue;
                    }

                    // si es válido lo agregamos a control
                    dtPedido.Rows.Add(articuloId);

                    //DataRow RegArt = dtPedido.Rows.Find(linea.Split(',')[0]);
                    SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow detalle = dtsInventario.PEDIDO_TRASP_DET.NewPEDIDO_TRASP_DETRow();
                    //string[] paramDet = linea.Split(new char[] { ',' });

                    //if (objNoAlpha.IsMatch(paramDet[0])) {
                    //    MessageBox.Show("El codigo del Articulo " + paramDet[0] + " es invalido");
                    //    OperacionViva = false;
                    //    break;

                    //}


                    //if (
                    //    ba.BuscarPorClave(paramDet[0]) == null)
                    //{
                    //    MessageBox.Show("El codigo del Articulo " + paramDet[0] + " No Existe");
                    //    OperacionViva = false;
                    //    break;


                    //}
                    detalle.FOLIO = "010002015";
                    detalle.LOTE = 1;
                    detalle.ARTICULO_ID = paramDet[0];
                    detalle.CANTIDAD_SOLIC = System.Convert.ToInt32(paramDet[1]);
                    detalle.PARTIDA = System.Convert.ToInt16(nPartida + 1);

                    dtsInventario.PEDIDO_TRASP_DET.AddPEDIDO_TRASP_DETRow(detalle);
                    //nPartida += 1;
                    nPartida++;
                    OperacionViva = true;
                }

                if (!OperacionViva) {

                    MessageBox.Show("No se puede Importar el archivo !");
                    return;
                }
                SIFNegocio.Inventario.Traspasos traspasoL = new SIFNegocio.Inventario.Traspasos();
                traspasoL.ImportaPedidoAlmacen(Helpers.Sesion.Usuario.UsuariosID, /*traspaso*/  suc, idmotivo, dtsInventario.PEDIDO_TRASP_DET);
                MessageBox.Show("Se ha importado correctamente el archivo");


            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());

            }
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            // AbrirArchivo();
            ImpFileTraspasoSelect sucSelect = new ImpFileTraspasoSelect();
            if (DialogResult.OK == sucSelect.ShowDialog())
            {
                ImportarArchivo();
                this.Buscar();
            }
            else
            {
                return;
            }


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

        #region ROMA
        private int CierraTraspaso(string NoFolio, int NoLote)
        {
            SIFNegocio.Inventario.Traspasos tRAS = new SIFNegocio.Inventario.Traspasos();
            //return tRAS.CierraTraspasoRec(Helpers.Sesion.Usuario.UsuariosID.ToString(), NoFolio, NoLote.ToString());
            return tRAS.CierraTraspaso21(Helpers.Sesion.Usuario.UsuariosID.ToString(), NoFolio, NoLote.ToString());
                
        }

        private void Cerrar()
        {
            String ProductName = "Traspasos";
            string Resul = string.Empty;
            string pError = "Error";

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

            int SucOri = int.Parse(row.Cells["ORIGENColumn"].Value.ToString().Split('-')[0]);
            int SucDes = int.Parse(row.Cells["DESTINOColumn"].Value.ToString().Split('-')[0]);
            //if (SucPed == Helpers.Sesion.Sucursal.SucursalID)

            switch (row.Cells["ACTIVOColumn"].Value.ToString())
            {
                case "S":
                    /*if (MessageBoxEx.Show("¿Cerrar el Traspaso " + row.Cells["FOLIOColumn"].Value.ToString()
                                                               + " - "
                                                               + row.Cells["LOTEColumn"].Value.ToString() + "?",
                                      ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {*/

                    /************************************************************************************/
                    string valido,validasp;
                    int mov = 3;
                    valido = TraspasoAlmacen.ValidaLInterno(row.Cells["FOLIOColumn"].Value.ToString(), row.Cells["LOTEColumn"].Value.ToString(), mov);
                    if (valido.Contains("-1") || valido is null)
                    {
                        MessageBox.Show(valido, "Caducidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    validasp = TraspasoAlmacen.ValidaSalida3(row.Cells["FOLIOColumn"].Value.ToString(), row.Cells["LOTEColumn"].Value.ToString());
                    //MessageBox.Show(validasp);
                    if (int.Parse(validasp)<0 )
                    {
                        MessageBox.Show(validasp+", No se asigno el lote interno en traspaso.Comuniquese con Sistemas", "Caducidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SIFModelo.Inventarios.InventarioDataSet.TRASPASORow traspaso = (SIFModelo.Inventarios.InventarioDataSet.TRASPASORow)((DataRowView)row.DataItem).Row;

                    DataTable dtPedido = TraspasoAlmacen.GetTraspasoDet(traspaso.FOLIO, traspaso.LOTE);
                    DataRow[] results = dtPedido.Select(null, "lote, id");
                    Boolean AmarilloORojo = false;
                    foreach (var item in results)
                    {
                        String pedido = item["Pedido"].ToString();
                        String enviado = item["Enviado"].ToString();
                        if (int.Parse(item["Pedido"].ToString()) > int.Parse(item["Enviado"].ToString()))
                        {
                            //if ((item as SIFModelo.Inventarios.InventarioDataSet.TRASPASO_DETRow).CANTIDAD_SOLICITADA > (item as SIFModelo.Inventarios.InventarioDataSet.TRASPASO_DETRow).CANTIDAD_ENVIADA)
                            AmarilloORojo = true;
                            break;
                        }
                    }

                    if (AmarilloORojo)
                    {
                        SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Pedido_Almacen_Incidencias.rpt", "{CS_PEDIDO_ALMACEN_INCIDENCIAS.FOLIO}='" + row.Cells[0].Value.ToString() + "'");
                        Impresion.ShowDialog();

                        if (System.Windows.Forms.DialogResult.OK != MessageBox.Show("El traspaso contiene incidencias. ¿Desea continuar?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                        {
                            return;
                        }
                    }


                    SIF.View.Ventas.CambiarContrasenhaUsuarioLogin frmCambiarPassConfirm = new Ventas.CambiarContrasenhaUsuarioLogin();
                    if (frmCambiarPassConfirm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    ///<summary>
                    /// Cambios para registrar el embarque Itacma 09/06/2021
                    ///</summary>

                    //Complementos.frmTimbradoCartaPorte ftcp = new Complementos.frmTimbradoCartaPorte( row.Cells["FOLIOColumn"].Value.ToString(),   int.Parse(row.Cells["LOTEColumn"].Value.ToString()));
                    //if (ftcp.ShowDialog() != DialogResult.OK)
                    //{
                    //    MessageBox.Show("No se pudo insetar el registro en bitacora de embarque", "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                    //    return;
                    //}


                    ///<summary>
                    /// Cambios para registrar el embarque Itacma 09/06/2021
                    ///</summary>
                    ///
                    if (new SIFNegocio.Extras.Parametros().ObtenParametro("SOLICITAEMBARQUE") > 0 

                        )
                    {
                        SIFModelo.BitEmbarque embar = new SIFModelo.BitEmbarque();
                        embar.folio_traspaso = row.Cells["FOLIOColumn"].Value.ToString();
                        embar.lote = Int16.Parse(row.Cells["LOTEColumn"].Value.ToString());
                        embar.suc_origen = Int16.Parse(SucOri.ToString());
                        embar.suc_destino = Int16.Parse(SucDes.ToString());
                        embar.usuario_envia = Int16.Parse(frmCambiarPassConfirm.Usuario.UsuariosID.ToString());
                        Extras.frmEmbarque frmembarque = new Extras.frmEmbarque(embar);

                        if (frmembarque.ShowDialog() != DialogResult.OK)
                        {
                            MessageBox.Show("No se pudo insetar el registro en bitacora de embarque", "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                            return;
                        }
                   }
                    /************************************************************************************/
                    

                    if (CierraTraspaso(row.Cells["FOLIOColumn"].Value.ToString(),
                                        int.Parse(row.Cells["LOTEColumn"].Value.ToString())) > 0)
                    {
                        


                        row.Cells["ACTIVOColumn"].Value = "C";
                        // Envia Traspaso ROMA 03SEP2013
                        Resul = TraspasoAlmacen.EnviaTraspasoSalida(row.Cells["FOLIOColumn"].Value.ToString(),
                            row.Cells["LOTEColumn"].Value.ToString(), SucOri, SucDes);
                        this.timbraTraspaso(row.Cells["FOLIOColumn"].Value.ToString(), row.Cells["LOTEColumn"].Value.ToString(), SucDes);//timbra taspaso JMQC 06062018

                        #region Consume API


                        //consumir la Api para reportar el inventario a la base de datos de la nube
                        if (SIFNegocio.EpGo.NegocioConfiguracionEpGo.ParametroActivo >= 1)
                        {
                            int tipoMovInvID = TraspasoAlmacen.ObtenTpoMovInvIDTraspaso(row.Cells["FOLIOColumn"].Value.ToString(), row.Cells["LOTEColumn"].Value.ToString());
                            new SIFNegocio.EpGo.InventarioService().SendInvetarioApiGo(

                            row.Cells["FOLIOColumn"].Value.ToString() + "-" +
                            row.Cells["LOTEColumn"].Value.ToString(), tipoMovInvID
                                );
                        }

                        #endregion

                        if (!Regex.IsMatch(Resul, pError))
                        {
                            this.Buscar();
                        }

                      // MessageBox.Show(Resul, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        imprimir();
                    }

                    break;
                case "X":
                   MessageBox.Show("El traspaso " + row.Cells[0].Value.ToString() + " - " + row.Cells[1].Value.ToString() + ", ya se cancelo.",
                        ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "C":
                   MessageBox.Show("El traspaso " + row.Cells[0].Value.ToString() + " - " + row.Cells[1].Value.ToString() + ", ya se cerro.",
                        ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    break;

            }
        }

        #endregion ROMA
        /*AVM 13-08-2015*/
        private void IncidenciasButtonItem_Click(object sender, EventArgs e)
        {
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
            if (row.Cells["REFERENCIAColumn"].Value.ToString().Equals(""))
            {
               MessageBox.Show("El traspaso no pertenece a ningun pedido, no se pueden mostrar incidencias.");
                return;
            }
            /***************** SE MUESTRA LA VENTANA PARA QUE SELECCIONE LAS LINEAS *********************/
            SIF.View.Inventario.SelectFilas frmSel = new SelectFilas();
            frmSel.lote = int.Parse(row.Cells[1].Value.ToString());
            frmSel.folio = row.Cells[0].Value.ToString();

            if (System.Windows.Forms.DialogResult.OK != frmSel.ShowDialog())
            {
                return;
            }
            /***************** SE MUESTRA LA VENTANA PARA QUE SELECCIONE LAS LINEAS *********************/

            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Pedido_Almacen_Incidencias.rpt", "{CS_PEDIDO_ALMACEN_INCIDENCIAS.FOLIO}='" + row.Cells[0].Value.ToString() +
                                                                                 "' AND {CS_PEDIDO_ALMACEN_INCIDENCIAS.FILA} IN [" + frmSel.filas + "]");
            Impresion.ShowDialog();
        }

        private void GeneralPorFilasButtonItem_Click(object sender, EventArgs e)
        {
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
            if (row.Cells["REFERENCIAColumn"].Value.ToString().Equals(""))
            {
               MessageBox.Show("El traspaso no pertenece a ningun pedido, no se pueden mostrar incidencias.");
                return;
            }
            /***************** SE MUESTRA LA VENTANA PARA QUE SELECCIONE LAS LINEAS *********************/
            /* no aplica para este reporte
            SIF.View.Inventario.SelectFilas frmSel = new SelectFilas();
            frmSel.lote = int.Parse(row.Cells[1].Value.ToString());
            frmSel.folio = row.Cells[0].Value.ToString();

            if (System.Windows.Forms.DialogResult.OK != frmSel.ShowDialog())
            {
                return;
            }
             * */
            /***************** SE MUESTRA LA VENTANA PARA QUE SELECCIONE LAS LINEAS *********************/

            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Pedido_Almacen.rpt", "{CS_RPT_PEDIDO_ALMACEN.FOLIO} = '" + row.Cells[0].Value.ToString() + "' AND {CS_RPT_PEDIDO_ALMACEN.LOTE}=" + row.Cells[1].Value.ToString());
            Impresion.ShowDialog();
        }

        private void timbraTraspaso(string folio, string lote, int sucD)
        {
            SIFNegocio.Extras.Parametros param = new SIFNegocio.Extras.Parametros();
            int timbrarTraspasos = param.ObtenParametro("TIMBRARTRASPASO");
            Boolean timbra = false;
            if (timbrarTraspasos > 0)
            {
                string path = @"C:\FEL\Facturas";
                List<int> list_spt = new List<int>();

                Boolean existeCarpeta = true;
                SIFNegocio.Inventario.Traspasos logicaT = new SIFNegocio.Inventario.Traspasos();

                list_spt = logicaT.sucursalesParaTimbrar();
                foreach (int i in list_spt) {
                    if (i == sucD) {
                        timbra = true;
                        break;
                    }
                }
                if (!timbra)
                    return;
                SIFNegocio.Remision logicaR = new SIFNegocio.Remision();
                parametrosFac.folioTraspaso = folio;
                parametrosFac.loteTraspaso = Convert.ToInt32(lote);
                parametrosFac.usoCfdi = "P01";
                parametrosFac.usuarioId = SIF.Helpers.Sesion.Usuario.UsuariosID;
                parametrosFac.lExp = SIF.Helpers.Sesion.Sucursal.CodigoPostal.ToString();
                if (System.IO.Path.HasExtension(path))
                {
                    MessageBox.Show("no existe la ruta:\"" + path + "\"" + "Configure una carpeta de reportes", "No existe la carpeta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    existeCarpeta = false;


                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    SIFModelo.Tipos.parmFac respuesta = logicaT.timbraTraspaso(parametrosFac);
                    Cursor.Current = Cursors.Default;
                    if (respuesta.respuesta.Contains("0: OK"))
                    {
                        if (!existeCarpeta)
                        {
                            MessageBox.Show("Se timbro el traspaso correctamente: " + parametrosFac.uuid, "Timbrado correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {

                            DialogResult dlr =
                            MessageBox.Show("Se creo la factura correctamente: " + parametrosFac.uuid + "\n\ndesea Imprimir la factura?", "Factura creada correctamente", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dlr == DialogResult.Yes)
                            {
                                string strObtPdf = logicaR.obtPdf(parametrosFac.uuid).ToString();
                                if (strObtPdf.Contains("0: OK"))
                                {
                                    path += "\\" + parametrosFac.uuid.ToString() + ".pdf";
                                    System.Diagnostics.Process.Start(path);
                                }
                                else
                                {
                                    MessageBox.Show(strObtPdf);

                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(respuesta.respuesta.ToString());

                    }
                }
            }


        }


        private void timbraTraspasoCartaPorte(string folio, string lote, int sucD)
        {
            SIFNegocio.Extras.Parametros param = new SIFNegocio.Extras.Parametros();
            int timbrarTraspasos = param.ObtenParametro("TIMBRARTRASPASO");
            Boolean timbra = false;
            if (timbrarTraspasos > 0)
            {
                string path = @"C:\FEL\Facturas";
                List<int> list_spt = new List<int>();

                Boolean existeCarpeta = true;
                SIFNegocio.Inventario.Traspasos logicaT = new SIFNegocio.Inventario.Traspasos();

                list_spt = logicaT.sucursalesParaTimbrar();
                foreach (int i in list_spt)
                {
                    if (i == sucD)
                    {
                        timbra = true;
                        break;
                    }
                }
                if (!timbra)
                    return;
                SIFNegocio.Remision logicaR = new SIFNegocio.Remision();
                parametrosFac.folioTraspaso = folio;
                parametrosFac.loteTraspaso = Convert.ToInt32(lote);
                parametrosFac.usoCfdi = "P01";
                parametrosFac.usuarioId = SIF.Helpers.Sesion.Usuario.UsuariosID;
                parametrosFac.lExp = SIF.Helpers.Sesion.Sucursal.CodigoPostal.ToString();
                if (System.IO.Path.HasExtension(path))
                {
                    MessageBox.Show("no existe la ruta:\"" + path + "\"" + "Configure una carpeta de reportes", "No existe la carpeta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    existeCarpeta = false;


                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    SIFModelo.Tipos.parmFac respuesta = logicaT.timbraTraspaso(parametrosFac);
                    Cursor.Current = Cursors.Default;
                    if (respuesta.respuesta.Contains("0: OK"))
                    {
                        if (!existeCarpeta)
                        {
                            MessageBox.Show("Se timbro el traspaso correctamente: " + parametrosFac.uuid, "Timbrado correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {

                            DialogResult dlr =
                            MessageBox.Show("Se creo la factura correctamente: " + parametrosFac.uuid + "\n\ndesea Imprimir la factura?", "Factura creada correctamente", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dlr == DialogResult.Yes)
                            {
                                string strObtPdf = logicaR.obtPdf(parametrosFac.uuid).ToString();
                                if (strObtPdf.Contains("0: OK"))
                                {
                                    path += "\\" + parametrosFac.uuid.ToString() + ".pdf";
                                    System.Diagnostics.Process.Start(path);
                                }
                                else
                                {
                                    MessageBox.Show(strObtPdf);

                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(respuesta.respuesta.ToString());

                    }
                }
            }


        }
        private void buttonItem9_Click_1(object sender, EventArgs e)
        {

            if (SIF.Helpers.Sesion.Usuario.TipoUsuario != SIFModelo.Tipos.TipoUsuario.ADMINISTRATIVO && SIF.Helpers.Sesion.Usuario.TipoUsuario != SIFModelo.Tipos.TipoUsuario.SUPERVISOR) {
                MessageBox.Show("El usuario debe de ser Administrador o supervisor", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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
            if (row.Cells["ACTIVOColumn"].Value.ToString() != "C") {
                MessageBox.Show("El traspaso tiene que estar Cerrado.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            SIFNegocio.Inventario.Traspasos logicaT = new SIFNegocio.Inventario.Traspasos();
            string existe = logicaT.existeTimbreT(row.Cells["FOLIOColumn"].Value.ToString(), row.Cells["LOTEColumn"].Value.ToString());
            if (existe == "Exception")
                return;
            if (existe != "0|0") {
                if (MessageBox.Show("El traspaso ya tiene un timbre asociado" + Environment.NewLine + "FOLIO FEL:" + existe.Split('|')[0] + Environment.NewLine + "UUID:" + existe.Split('|')[1] + Environment.NewLine + "desea timbrarlo Denuevo?", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                    return;
                }
            }
            this.timbraTraspaso(row.Cells["FOLIOColumn"].Value.ToString(), row.Cells["LOTEColumn"].Value.ToString(), int.Parse(row.Cells["DESTINOColumn"].Value.ToString().Split('-')[0]));
        }


        private void existeTimbreT() {


        }

        private void ModificacionLotesYCaducidades_click(object sender, EventArgs e)
        {
            string tipo_mov = "3";//traspaso
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

            if (frm_lotes.validParametro())
            {
                if ( porsurtirRadioButton.Checked || creditoRadioButton.Checked)
                {
                    frm_lotes._folio = row[0].Value.ToString();
                    frm_lotes._lote = row[1].Value.ToString();
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
                    MessageBox.Show("Solo permitido en traspasos escaneados o por surtir", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
        }
            else
                MessageBox.Show("Esta funcion no esta activada","Información",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }

            private void EtiquetaButtonItem_Click(object sender, EventArgs e){
            List<string> list = new List<string>();
            Process[] procesos;
            procesos = Process.GetProcesses();
            foreach (Process pro in procesos)
            {
                if (pro.ProcessName == "SIF")
                {
                    list.Add(pro.ProcessName);
                }
            }
            if (list.Count > 2) {
                MessageBox.Show("No puede iniciar nuevas sesiones por que ya  tiene sesiones abiertas, Cierre los Sif abiertos"
                    + Environment.NewLine + Environment.NewLine+"Desea que el sistema cierre los Sif abiertos","Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
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
            if (row.Cells["ACTIVOColumn"].Value.ToString() != "C")
            {
                MessageBox.Show("El traspaso tiene que estar Cerrado.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
           // SIFNegocio.Inventario.Traspasos logicaT = new SIFNegocio.Inventario.Traspasos();

            SIFNegocio.Inventario.Traspasos.CImprimeEtiqueta(row.Cells["FOLIOColumn"].Value.ToString(), Convert.ToInt16(row.Cells["LOTEColumn"].Value.ToString()));
            
            
        }


        private void EmbarqueRptButtonItem_Click(object sender, EventArgs e)
        {
            SIFModelo.Articulo art = new SIFModelo.Articulo();
            art.LISTA_SUCURSAL_VTA = "1|";
            Catalogos.ListaSucursalVentaForm frmLista = new Catalogos.ListaSucursalVentaForm(art);
            string f = string.Empty;
            if (frmLista.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                f = frmLista.ListaSucursales;


            }
            if (string.IsNullOrEmpty(f))
                return;

            string[] s = f.Split('|');

            if (s.Count() > 6) {

                return;
            }
            try
            {
                int G = string.Join(",", s).Length;
                string CADENA= string.Empty;//= string.Join(",", s).Substring(0,G-1);
                foreach (string j in s) {
                    if (!String.IsNullOrEmpty(j))
                        if (String.IsNullOrEmpty(CADENA))
                            CADENA += " and ({ CS_RPT_BITACORA_EMBARQUE.sucursal_destinon}=" + j;
                        else {
                            CADENA += " or { CS_RPT_BITACORA_EMBARQUE.sucursal_destinon}=" + j;
                        }

                }


                SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_Embarque.rpt", "{CS_RPT_BITACORA_EMBARQUE.fecha_registro} >= DATE(" + dateTimeInput1.Value.ToString("yyyy,MM,dd") + ") AND  {CS_RPT_BITACORA_EMBARQUE.fecha_registro} >= DATE(" + dateTimeInput2.Value.ToString("yyyy,MM,dd") + ") "+ CADENA+")");

                // SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("orden123.rpt", "{CS_ASIGNA_PRECIOS_ORDENES2019.FOLIO} = '19054898'");
                Impresion.ShowDialog();
            }
            catch (Exception xp)
            {
                MessageBox.Show(xp.ToString());
            }
            // }

        }


    }
}

