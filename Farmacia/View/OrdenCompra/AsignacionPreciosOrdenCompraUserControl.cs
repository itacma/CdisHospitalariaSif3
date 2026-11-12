using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;

namespace SIF.View.OrdenCompra
{
    public partial class AsignacionPreciosOrdenCompraUserControl : Templates.ListaUserControl
    {
        public AsignacionPreciosOrdenCompraUserControl()
        {
            InitializeComponent();
            this.dateTimeInput1.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month,1, 0,0,0);
            this.dateTimeInput2.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, 23, 59, 59);
            this.cargaEstadosOrdenCompra();
            Privilegios();
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 12, int.Parse(Xbtn.Tag.ToString()));
            }

        }
        private SIFNegocio.OrdenCompra.OrdenCompra ordenCompraL = new SIFNegocio.OrdenCompra.OrdenCompra();
        private void buscarCabeceras()
        {
            string status = "%";
            if (this.statusOCComboBoxEx.SelectedValue != null)
            {
                status = this.statusOCComboBoxEx.SelectedValue.ToString();

                if (status.Length == 1 && status != "%")
                {
                    status += " ";
                }
            }
            this.superGridControl1.PrimaryGrid.DataSource = ordenCompraL.BuscaOrdenCompra(this.buscarTextBoxX.Text, this.dateTimeInput1.Value, this.dateTimeInput2.Value, status);
            this.superGridControl1.PrimaryGrid.DataMember = "V_ORDEN_COMPRA";
        }

        private void cargaEstadosOrdenCompra()
        {
            Dictionary<string, string> statusOC = new Dictionary<string, string>();
            statusOC.Add("[TODOS]", "%");
            statusOC.Add("ABIERTA", "A");
            statusOC.Add("CERRADA", "C");
            statusOC.Add("PROCESADA", "P");
            statusOC.Add("AUTORIZADA LISTA PARA ASIGNACION DE PRECIOS", "E");
            statusOC.Add("EN ASIGNACION DE PRECIOS", "L");
            statusOC.Add("CANCELADAS", "XY");

            BindingSource bs = new BindingSource();
            bs.DataSource = statusOC;
            this.statusOCComboBoxEx.DataSource = bs;
            statusOCComboBoxEx.DisplayMember = "Key";
            statusOCComboBoxEx.ValueMember = "Value";
            statusOCComboBoxEx.SelectedValue = statusOC["AUTORIZADA LISTA PARA ASIGNACION DE PRECIOS"];
        }


        private void AsignarOrdenCompra()
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija una Orden de Compra");
                return;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow ordenCompra;
            ordenCompra = ((DataRowView)((GridRow)this.superGridControl1.PrimaryGrid.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;

            if (ordenCompra.ESTADO_OC.Trim() != "E" && ordenCompra.ESTADO_OC.Trim() != "L")
            {
               MessageBox.Show("Solo puede recibir ordenes de compra listas para asignar precios (E)");
                return;
            }

            View.OrdenCompra.AsignacionPreciosOrdenCompraDetallesUserControl frmDetalles = new AsignacionPreciosOrdenCompraDetallesUserControl(ordenCompra);
            frmDetalles.Owner = this;
            frmDetalles.Muestra();
        }

        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.buscarCabeceras();
        }

        public Menu.ComprasMenu Owner { get; set; }

        internal void Muestra()
        {
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;

            //SIF.View.Ventas.AccesoUsuarioForm frmUsuario = new SIF.View.Ventas.AccesoUsuarioForm();
            //if (frmUsuario.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}

            this.UsuarioId = Helpers.Sesion.Usuario.UsuariosID;

            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }

        private void Back()
        {
            try{
            if (this.Mostrado && Owner.Owner.IsModalPanelDisplayed)
            {
                //this.DesactivaComandos();
                try
                {
                    if (Owner.Owner.Contains(this))
                    {
                        Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    this.Owner.ActivaComandos();
                    this.Mostrado = false;
                    this.DesactivaComandos();
                }
                catch
                {

                }
            }
            }
            catch { }
        }

        public void ActivaComandos()
        {
            this.backButton.Shortcuts.Add(eShortcut.F12);
            this.recibirButtonItem.Shortcuts.Add(eShortcut.F8);
        }
        public void DesactivaComandos()
        {
            this.backButton.Shortcuts.Clear();
            this.recibirButtonItem.Shortcuts.Clear();
        }

        public bool Mostrado { get; set; }

        public int UsuarioId { get; set; }

        private void recibirButtonItem_Click(object sender, EventArgs e)
        {
            this.AsignarOrdenCompra();
        }

        private void buscarTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.buscarCabeceras();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
                this.buscarCabeceras();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void RecepcionOrdenCompraUserControl_Load(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Focus();
            this.buscarCabeceras();
        }

        private void statusOCComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buscarCabeceras();
        }

        private void superGridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.AsignarOrdenCompra();
        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }
        }

        private void dateTimeInput1_ValueChanged(object sender, EventArgs e)
        {
            buscarCabeceras();
        }
    }
}
