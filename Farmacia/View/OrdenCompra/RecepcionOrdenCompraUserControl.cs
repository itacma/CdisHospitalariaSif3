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
    public partial class RecepcionOrdenCompraUserControl : Templates.ListaUserControl
    {
        public RecepcionOrdenCompraUserControl()
        {
            InitializeComponent();
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            Privilegios();
        }
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 11, int.Parse(Xbtn.Tag.ToString()));
            }

        }


        private SIFNegocio.OrdenCompra.OrdenCompra ordenCompraL = new SIFNegocio.OrdenCompra.OrdenCompra();
        private void buscarCabeceras()
        {
            if (!this.loaded)
            {
                return;
            }
            string statusOc = "%";
            if (!string.IsNullOrEmpty(this.statusOCComboBoxEx.SelectedValue.ToString()))
            {
                statusOc = this.statusOCComboBoxEx.SelectedValue.ToString();
                if (statusOc.Length == 1)
                {
                    statusOc += " ";
                }

            }
            this.superGridControl1.PrimaryGrid.DataSource = ordenCompraL.BuscaOrdenCompra(this.buscarTextBoxX.Text, this.dateTimeInput1.Value, this.dateTimeInput2.Value, statusOc);
            this.superGridControl1.PrimaryGrid.DataMember = "V_ORDEN_COMPRA";
        }

        private void dividirOrdenCompra()
        {
            if (superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Orden de Compra a dividir");
                return;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow ordenCompra;
            ordenCompra = ((DataRowView)((GridRow)this.superGridControl1.PrimaryGrid.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;

            SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(this.UsuarioId);


            View.OrdenCompra.OrdenCompraUserControl ocu = new View.OrdenCompra.OrdenCompraUserControl(ordenCompra.FOLIO_OC_ID, usuario, true);
            ocu.Owner = this;
            ocu.Muestra();

            //control;

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
            statusOCComboBoxEx.SelectedValue = statusOC["CERRADA"];
        }

        private void RecibirOrdenCompra()
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija una Orden de Compra");
                return;
            }


            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow ordenCompra;
            ordenCompra = ((DataRowView)((GridRow)this.superGridControl1.PrimaryGrid.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;

            if (ordenCompra.ESTADO_OC.Trim() != "C" && ordenCompra.ESTADO_OC.Trim() != "E")
            {
               MessageBox.Show("La orden de compra debe estar cerrada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //VALIDAR QUE LA ORDEN DE COMPRA TENGA UNA FACTURA
            if (ordenCompra.ESTADO_OC.Trim() == "C")
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow facturaProveedor = new SIFNegocio.OrdenCompra.OrdenCompra().FacturaPorNumero(ordenCompra);
                if (facturaProveedor == null)
                {
                    DialogResult dlg =MessageBox.Show("La orden de compra no tiene asociada una factura, ¿desea agregarla en este momento?", "Factura", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (dlg == DialogResult.Cancel)
                    {
                        return;
                    }


                    if (dlg == DialogResult.Yes)
                    {
                        if (!this.AsignaFactura())
                        {
                            return;
                        }
                    }
                    else
                    {
                        // return;
                    }
                }
            }

            View.OrdenCompra.RecepcionOrdenCompraDetallesUserControl frmDetalles = new RecepcionOrdenCompraDetallesUserControl(ordenCompra);
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
            try
            {
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

        private void Unir()
        {
            //mostramos la columna para seleccion
            DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl SELECTColumn = this.superGridControl1.PrimaryGrid.Columns["SELECTColumn"].EditControl as DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl;

            SIFModelo.OrdenCompra.OrdenesCompraDataSet ordenCompraDS = this.superGridControl1.PrimaryGrid.DataSource as SIFModelo.OrdenCompra.OrdenesCompraDataSet;
            SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETDataTable DetallesNuevaOrden = new SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETDataTable();

            List<DataRow> ordenesSeleccionadas = new List<DataRow>();

            foreach (DataRow row in ordenCompraDS.V_ORDEN_COMPRA.Rows)
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OCrow = row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;
                if (OCrow.SELECCIONADO == "True")
                {
                    ordenesSeleccionadas.Add(OCrow);
                }
            }

            if (ordenesSeleccionadas.Count() <= 1)
            {
               MessageBox.Show("Debe elegir al menos dos ordenes de compra");
                return;
            }

            int proveedorId = 0;
            foreach (DataRow row in ordenesSeleccionadas)
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow seleccionadoRow = row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;

                if (proveedorId != 0)
                {
                    if (seleccionadoRow.PROVEEDOR_ID != proveedorId)
                    {
                       MessageBox.Show("Solo puede unir ordenes de compra del mismo proveedor");
                        return;
                    }
                }
                else
                {
                    proveedorId = seleccionadoRow.PROVEEDOR_ID;
                }

                if (seleccionadoRow.ESTADO_OC.Trim() != "A")
                {
                   MessageBox.Show("La orden de compra " + seleccionadoRow.FOLIO_OC_ID + " no está activa, solo puede unir ordenes de compra Activas");
                    return;
                }
            }

            foreach (DataRow row in ordenesSeleccionadas)
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow seleccionadoRow = row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;

                foreach (SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow vDetalle in new SIFNegocio.OrdenCompra.OrdenCompra().BuscaOrdenCompraDetalle(seleccionadoRow))
                {

                    SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow detalle = DetallesNuevaOrden.NewORDEN_COMPRA_DETRow();
                    detalle.ARTICULO_ID = vDetalle.ARTICULO_ID;
                    detalle.CANT_DEVUELTA = vDetalle.CANT_DEVUELTA;
                    detalle.CANT_FACTURADA = vDetalle.CANT_FACTURADA;
                    detalle.CANT_MALESTADO = vDetalle.CANT_MALESTADO;
                    detalle.CANT_RECIBIDA = vDetalle.CANT_RECIBIDA;
                    detalle.CANT_REPOSICION = vDetalle.CANT_REPOSICION;
                    detalle.CANT_SOLICITADA = vDetalle.CANT_SOLICITADA;
                    detalle.DESCRIP_OFERTA = vDetalle.DESCRIP_OFERTA;
                    detalle.DESCTO_FACTURA = vDetalle.DESCTO_FACTURA;
                    detalle.DESCTO_FACTURA_AD1 = vDetalle.DESCTO_FACTURA_AD1;
                    detalle.DESCTO_RECIBIDO = vDetalle.DESCTO_RECIBIDO;
                    detalle.DESCTO_RECIBIDO_AD1 = vDetalle.DESCTO_RECIBIDO_AD1;
                    detalle.DESCTO_RECIBIDO_AD2 = vDetalle.DESCTO_RECIBIDO_AD2;
                    detalle.PRECIO_COSTO = vDetalle.PRECIO_COSTO;
                    detalle.PRECIO_FACTURA = vDetalle.PRECIO_FACTURA;
                    //detalle.PUNTO_DE_REORDEN = vDetalle.PUNTO_DE_REORDEN;
                    detalle.ULT_PRECIO_COMPRA = (double)vDetalle.ULT_PRECIO_COMPRA;
                    //detalle.EXISTENCIAS = vDetalle.EXISTENCIAS;
                    detalle.FOLIO_OC_ID = "";


                    SIFModelo.Articulo articuloM = new SIFNegocio.Articulo().BuscarPorClave(detalle.ARTICULO_ID);
                    detalle.IMPORTE = detalle.CANT_SOLICITADA * detalle.PRECIO_COSTO;
                    detalle.LABORATORIO_ID = articuloM.LABORATORIO_ID;
                    detalle.PROVEEDOR_ID = proveedorId;

                    detalle.TIPO_MEDICAMENTO_CVE = articuloM.TIPO_MEDICAMENTO_CVE;
                    //detalle.IMPORTE = vDetalle.IMPORTE;

                    DetallesNuevaOrden.AddORDEN_COMPRA_DETRow(detalle);
                }

                //LA CANCELAMOS
                seleccionadoRow.ESTADO_OC = "C";
                ordenCompraL.ActualizaOrdenCompra(seleccionadoRow);
            }
            SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(UsuarioId);
            SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow ordenCompraRow = new SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRADataTable().NewORDEN_COMPRARow();

            ordenCompraRow.ESTADO_OC = "A";
            ordenCompraRow.FECHA_ALTA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            ordenCompraRow.FECHA_AUTORIZA = new DateTime();
            ordenCompraRow.FECHA_CIERRE = new DateTime();
            ordenCompraRow.FECHA_RECEPCION = new DateTime();
            ordenCompraRow.FOLIO_OC_ID = "";
            ordenCompraRow.PROVEEDOR_ID = proveedorId;
            ordenCompraRow.SUCURSAL_ID = (short)Helpers.Sesion.Sucursal.SucursalesID;
            ordenCompraRow.USUARIO_ID = UsuarioId;
            ordenCompraRow.USUARIO_ID_AUTORIZA = "0";

            ordenCompraL.GuardaOrdenCompra(Helpers.Sesion.Sucursal, usuario, ordenCompraRow, DetallesNuevaOrden, true);
        }

        private bool AsignaFactura()
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Elija la Orden de Compra a editar");
                return false;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC = ((DataRowView)((GridRow)this.superGridControl1.ActiveRow).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow;

            View.OrdenCompra.NumeroFacturaForm frmFactura = new NumeroFacturaForm(oC);
            if (frmFactura.ShowDialog() == DialogResult.Cancel)
            {
                return false;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow factura = new SIFNegocio.OrdenCompra.OrdenCompra().FacturaPorNumero(frmFactura.NumeroFactura);

            if (factura == null)
            {
               MessageBox.Show("La factura ingresada no existe");
                return false;
            }

            if (factura.ESTADO != "A")
            {
               MessageBox.Show("La factura ingresada no esta activa");
                return false;
            }

            if (oC.PROVEEDOR_ID != factura.PROVEEDOR_ID)
            {
               MessageBox.Show("El proveedor de la factura no coincide con el de la orden de compra");
                return false;
            }

            //SIFModelo.OrdenCompra.OrdenesCompraDataSet.COMPRASRow rowCompras = new SIFModelo.OrdenCompra.OrdenesCompraDataSet().COMPRAS.NewCOMPRASRow();

            //rowCompras.FOLIO_OC = oC.FOLIO_OC_ID;
            //rowCompras.FACTURA = factura.NUM_FACTURA.ToString();
            //rowCompras.DESCUENTO_FACTURADO = 0;
            //rowCompras.DESCUENTO_RECIBIDO = 0;
            //rowCompras.ESTADO = "C";
            //rowCompras.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            //rowCompras.FOLIO_COMPRA = SIFNegocio.OrdenCompra.Compras.FolioCompra(Helpers.Sesion.Sucursal);
            //rowCompras.IMP_DESC_FALTANTE = 0;
            //rowCompras.IMP_FALTANTE = 0;
            //rowCompras.IMPUESTO_FACTURADO = (double)factura.TOTAL_IVA;
            //rowCompras.IMPUESTO_RECIBIDO = 0;
            //rowCompras.PROVEEDOR_ID = factura.PROVEEDOR_ID;
            //rowCompras.SUBTOTAL_FACTURADO = 0;
            //rowCompras.SUBTOTAL_RECIBIDO = 0;
            //rowCompras.TOTAL_FACTURADO = (double)factura.TOTAL_FACTURADO;
            //rowCompras.TOTAL_RECIBIDO = 0;
            //rowCompras.USUARIO_ID = this.UsuarioId.ToString();
            //rowCompras.USUARIO_ID_ASIG_PRECIO = "0";

            //SIFNegocio.OrdenCompra.Compras.Guardar(rowCompras);

            factura.FOLIO_OC = oC.FOLIO_OC_ID;
            new SIFNegocio.OrdenCompra.OrdenCompra().AsociaFactura(factura);

           MessageBox.Show("Factura " + factura.NUM_FACTURA + " se asoció a la orden de compra  " + oC.FOLIO_OC_ID + " correctamente");
            return true;
        }


        public void ActivaComandos()
        {
            this.recibirButtonItem.Shortcuts.Add(eShortcut.F5);
            this.backButton.Shortcuts.Add(eShortcut.F12);
        }
        public void DesactivaComandos()
        {
            this.recibirButtonItem.Shortcuts.Clear();
            this.backButton.Shortcuts.Clear();
        }

        public bool Mostrado { get; set; }

        public int UsuarioId { get; set; }

        private void recibirButtonItem_Click(object sender, EventArgs e)
        {
            this.RecibirOrdenCompra();
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

        private bool loaded = false;
        private void RecepcionOrdenCompraUserControl_Load(object sender, EventArgs e)
        {
            this.dateTimeInput1.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, 1, 0, 0, 0);
            this.dateTimeInput2.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, 23, 59, 59);

            cargaEstadosOrdenCompra();
            this.buscarTextBoxX.Focus();
            this.loaded = true;
            this.buscarCabeceras();
        }

        private void facturaButtonItem_Click(object sender, EventArgs e)
        {
            this.AsignaFactura();
        }

        private void statusOCComboBoxEx_SelectedValueChanged(object sender, EventArgs e)
        {
            this.buscarCabeceras();
        }

        private void dateTimeInput2_ValueChanged(object sender, EventArgs e)
        {
            this.buscarCabeceras();
        }

        private void dateTimeInput1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.buscarCabeceras();
            }
        }

        private void superGridControl1_DoubleClick(object sender, EventArgs e)
        {
            this.RecibirOrdenCompra();
        }

        private void unirButtonItem_Click(object sender, EventArgs e)
        {
            this.Unir();
        }

        private void dividirButtonItem_Click(object sender, EventArgs e)
        {
            this.dividirOrdenCompra();
        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }
        }
    }
}
