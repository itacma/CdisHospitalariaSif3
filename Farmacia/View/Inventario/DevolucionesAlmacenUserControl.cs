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
    public partial class DevolucionesAlmacenUserControl : Templates.ListaUserControl
    {
        int Cual =0;
        SIFNegocio.Inventario.Traspasos TraspasoAlmacen = new SIFNegocio.Inventario.Traspasos();
        SIFModelo.Inventarios.InventarioDataSet DsPedidosTrasp;
        public DevolucionesAlmacenUserControl()
        {
            InitializeComponent();
            this.dateTimeInput1.Value = DateTime.Parse("01/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year.ToString());
            this.dateTimeInput2.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor().AddHours(24);
            this.Buscar();
            Privilegios();
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(),38, int.Parse(Xbtn.Tag.ToString()));

            }

        }

        DevolucionAlmacenUserControl Devolucion = new DevolucionAlmacenUserControl();
        private void Nuevo()
        {
            if (!Devolucion.Mostrado)
            {
                Devolucion = new DevolucionAlmacenUserControl();
                Devolucion.Owner = this;
                Devolucion.Muestra();   
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        public bool Mostrado { get; set; }

        public Menu.InventarioMenu Owner { get; set; }

        public void Muestra()
        {
            if (Mostrado)
            {
                return;
            }

            this.Dock = DockStyle.Fill;
            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.ActivaComandos();
            this.Owner.DesactivaComandos();
            Mostrado = true;
        }

        public void ActivaComandos()
        {
            
        }

        public void Back()
        {
            try{
            Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.DesactivaComandos();
            this.Owner.ActivaComandos();
            Mostrado = false;
            }
            catch { }
        }

        public void DesactivaComandos()
        {

        }

        
        SIFNegocio.Inventario.Traspasos traspasoAlmacen = new SIFNegocio.Inventario.Traspasos();
        public void Buscar()
        {
            //DsPedidosTrasp.TRASPASO_DET = traspasoAlmacen.GetTraspasoDet(dateTimeInput1.Value.ToString(), dateTimeInput2.Value.ToString());
            switch (Cual)
            {
                case 0:
                    DsPedidosTrasp = traspasoAlmacen.GetTraspasos(dateTimeInput1.Value, dateTimeInput2.Value, "S", foliotextBoxX.Text, Helpers.Sesion.Sucursal.SucursalesID, "S");
                break;
                case 1:
                DsPedidosTrasp = traspasoAlmacen.GetTraspasos(dateTimeInput1.Value, dateTimeInput2.Value, "P", foliotextBoxX.Text, Helpers.Sesion.Sucursal.SucursalesID, "S");
                break;
                case 2:
                DsPedidosTrasp = traspasoAlmacen.GetTraspasos(dateTimeInput1.Value, dateTimeInput2.Value, "X", foliotextBoxX.Text, Helpers.Sesion.Sucursal.SucursalesID, "S");
                break;
                case 3:
                DsPedidosTrasp = traspasoAlmacen.GetTraspasos(dateTimeInput1.Value, dateTimeInput2.Value, "", foliotextBoxX.Text, Helpers.Sesion.Sucursal.SucursalesID, "S");
                break;
            }

            DsPedidosTrasp.Relations.Add("1", DsPedidosTrasp.Tables["TRASPASO"].Columns["FOLIO"],
                                              DsPedidosTrasp.Tables["TRASPASO_DET"].Columns["FOLIO"], false);

            this.superGridControl1.PrimaryGrid.DataSource = DsPedidosTrasp;
            this.superGridControl1.PrimaryGrid.DataMember = "TRASPASO";
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
            // enviar pedido
            String ProductName = "Traspasos Almacen";
            GridPanel panel = superGridControl1.PrimaryGrid;
            var container = ((GridContainer)panel.ActiveRow);
            var row = (GridRow)container;
            

            //verificar si el traspaso ya fue acualizado
            if (row.Cells["ACTIVO"].Value.ToString().Contains('S'))
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
                    int[] Cant = new int[results.Length];
                    int[] CantE = new int[results.Length];
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

                            object objSum = dtPedido.Compute("Sum(total)", "lote = " + CtlLote);
                            Total[ind] = Convert.ToDouble(objSum.ToString());
                        }
                        ind++;
                    }
                    int TotalR = 0;
                    if (row.Cells[8].Value.ToString() != "")
                        TotalR = int.Parse(row.Cells[8].Value.ToString());

                  //  TraspasoAlmacen.EnviaTraspasox(row.Cells[0].Value.ToString(), Lote, Convert.ToInt16(row.Cells[3].Value.ToString().Split('-')[0]), Convert.ToInt16(row.Cells[4].Value.ToString().Split('-')[0]),
                    //    TotalR, Sec, Articulo, Concepto, Cant, CantE, Total, Helpers.Sesion.Usuario.UsuariosID.ToString());
                    ////InsPedido(Convert.ToInt16(cmb_OrigPedido.Text.Split('-')[0]), Convert.ToInt16(cmb_DestPedido.Text.Split('-')[0]), tb_TotalPedido.Value,
                    ////          Lote, Sec, Articulo, Concepto, Cant, Total);
                }
            }
            else
            { 
                if(row.Cells["ACTIVO"].Value.ToString().Contains('P'))
                   MessageBox.Show("El traspaso ya se envio", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                   MessageBox.Show("El traspaso esta cancelado", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Buscar();
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
        }

        private void Actualizar()
        {
           
                GridPanel panel = superGridControl1.PrimaryGrid;
                var container = ((GridContainer)panel.ActiveRow);
                var row = (GridRow)container;
                if (row.Cells["ACTIVO"].Value.ToString().Contains('S'))
                {
                if (!Devolucion.Mostrado)
                {
                    //frmTraspaso = new DevolucionesAlmacenUserControl();
                    //frmTraspaso.TraspasoID = Int64.Parse(row.Cells[0].Value.ToString());
                    //frmTraspaso.lote = int.Parse(row.Cells[1].Value.ToString());
                    //frmTraspaso.Origen = row.Cells[3].Value.ToString();
                    //frmTraspaso.Owner = this;
                    //frmTraspaso.Muestra();
                    //this.Buscar();
                }
            }
            else
            {
                if (row.Cells["ACTIVO"].Value.ToString().Contains('P'))
                   MessageBox.Show("El traspaso ya se envio", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                   MessageBox.Show("El traspaso esta cancelado", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void imprimir()
        {
            SIF.View.Reportes.Inventarios.ReporteForm Reporte = new Reportes.Inventarios.ReporteForm(DsPedidosTrasp, 0);
            Reporte.ShowDialog();
        }
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            imprimir();
        }


    }
}
