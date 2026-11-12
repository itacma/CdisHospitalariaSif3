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
using System.Globalization;

namespace SIF.View.OrdenCompra
{
    public partial class LoteCaducidadDetallesUserControl : Templates.ListaUserControl
    {
        public LoteCaducidadDetallesUserControl(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow ordenCompra)
        {
            InitializeComponent();
            this.OrdenCompra = ordenCompra;
            //this.EstableceOrdenCompra();
            CargaRecepcionistas();

            EstableceCompra();
            this.inicializaColoresFilas();

            this.buscarTextBoxX.Focus();
            this.superGridControl1.PrimaryGrid.AllowRowDelete = false;
        }

        private void inicializaColoresFilas()
        {
            revisarRowStyle.Background.Color1 = Color.FromArgb(255, 35, 35);
            revisarRowStyle.Background.Color2 = Color.FromArgb(255, 35, 35);

            WarningCellStyle.Background.Color1 = Color.FromArgb(253, 215, 0);
            WarningCellStyle.Background.Color2 = Color.FromArgb(253, 215, 0);

            normalRowStyle = this.superGridControl1.DefaultVisualStyles.CellStyles.Default;
        }

        private SIFNegocio.OrdenCompra.Compras compraL = new SIFNegocio.OrdenCompra.Compras();

        private void CargaRecepcionistas()
        {
            List<string> recepcionistas = ordenCompraL.ListaRecepcionistas();

            foreach (string recepcionista in recepcionistas)
            {
                this.recibeComboBoxEx.Items.Add(recepcionista);
            }
        }

        private void EstableceCompra()
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow compra = SIFNegocio.OrdenCompra.Compras.OrdenCompraPorOCId(OrdenCompra);

            if (compra == null)
            {
               MessageBox.Show("Debe elegir una compra");
                return;
            }

            this.compraLote = SIFNegocio.OrdenCompra.Compras.CompraLotePorId(compra);

            if (compraLote == null)
            {
                compraLote = new SIFModelo.OrdenCompra.OrdenCompraDataSet().COMPRAS_LOTE.NewCOMPRAS_LOTERow();

                compraLote.RECEPCIONISTA = "";
                compraLote.OBSERVACIONES = "";
                compraLote.ACTIVO = "S";
                compraLote.FECHA = DateTime.Now;
                compraLote.FOLIO_COMPRA = compra.FOLIO_COMPRA;
                compraLote.USUARIO_ID = Helpers.Sesion.Usuario.UsuariosID.ToString();


                if (compra == null)
                {
                   MessageBox.Show("No hay una compra para asignar lote y caducidad");
                    return;
                }

                compraL.CompraDetalles = SIFNegocio.OrdenCompra.Compras.OrdenCompraDetallesPorCompraId(compra);

                this.detalles = new SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTEDataTable();

                int partida = 1;
                this.detalles.Constraints.Clear();
                foreach (var ocd in compraL.CompraDetalles)
                {
                    SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTERow det = this.detalles.NewCOMPRAS_DET_LOTERow();

                    det.PARTIDA = partida++;
                    det.ARTICULO_ID = ocd.ARTICULO_ID;
                    det.CODIGO_PROVEEDOR = "";
                    det.CANT_RECIBIDA = ocd.CANT_RECIBIDA;
                    det.FOLIO_COMPRA = compra.FOLIO_COMPRA;
                    det.TIPO = ocd.TIPO_MEDICAMENTO;
                    det.PROVEEDOR_ID = ocd.PROVEEDOR_ID;
                    det.NOMBRE = ocd.NOMBRE;
                    det.CANT_LOTE = 0;
                    det.LOTE = "";
                    det.SetCADUCIDADNull();
                    det.OBSERVACIONES = "";

                    detalles.AddCOMPRAS_DET_LOTERow(det);
                }
            }
            else
            {
                detalles = SIFNegocio.OrdenCompra.Compras.OrdenCompraDetallesLotePorCompraId(compraLote);
            }


            this.superGridControl1.PrimaryGrid.DataSource = detalles;
            this.superGridControl1.PrimaryGrid.DataMember = "COMPRAS_DET_LOTE";

            this.lineasLabel.Text = detalles.Rows.Count.ToString();

            if (compraLote.IsOBSERVACIONESNull())
            {
                compraLote.OBSERVACIONES = "";
            }

            if (compraLote.IsRECEPCIONISTANull())
            {
                compraLote.RECEPCIONISTA = "";
            }

            if (compraLote.IsRECEPCIONISTANull())
            {
                compraLote.RECEPCIONISTA = "";
            }

            this.observacionesGeneralesTextBox.Text = compraLote.OBSERVACIONES;
            this.recibeComboBoxEx.Text = compraLote.RECEPCIONISTA;
            this.folioLabel.Text = compraLote.FOLIO_COMPRA;

            //   CalculaTotal();
        }

        SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OrdenCompra;
        private SIFNegocio.OrdenCompra.OrdenCompra ordenCompraL = new SIFNegocio.OrdenCompra.OrdenCompra();

        SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_LOTERow compraLote;
        SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTEDataTable detalles;

        private void AgregaArticulo()
        {
            View.Articulos.ArticuloUserControl frmArticulos = new View.Articulos.ArticuloUserControl();
            frmArticulos.Owner = this;
            frmArticulos.Muestra();
        }

        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            if (articulo == null)
            {
               MessageBox.Show("Debe elgir un producto para la orden de compra");
                return;
            }

            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTERow row = detalles.NewCOMPRAS_DET_LOTERow();
            row.ARTICULO_ID = articulo.ARTICULO_ID;
            row.NOMBRE = articulo.NOMBRE1;
            //row.CANT_SOLICITADA = 0;
            row.FOLIO_COMPRA = compraLote.FOLIO_COMPRA;
            //row.PROVEEDOR_ID = compraLote.PROVEEDOR_ID;
            detalles.AddCOMPRAS_DET_LOTERow(row);

            this.lineasLabel.Text = detalles.Rows.Count.ToString();

        }

        public void AgregarLoteCaducidad()
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTERow detalle = ((((GridRow)this.superGridControl1.PrimaryGrid.ActiveRow).DataItem as DataRowView).Row) as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTERow;

            if (detalle == null)
            {
               MessageBox.Show("Debe elgir un producto para la orden de compra");
                return;
            }

            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTERow row = detalles.NewCOMPRAS_DET_LOTERow();
            row.ARTICULO_ID = detalle.ARTICULO_ID;
            //row.CADUCIDAD = detalle.CADUCIDAD;
            row.CANT_LOTE = 1;
            row.CANT_RECIBIDA = detalle.CANT_RECIBIDA;
            row.CODIGO_PROVEEDOR = detalle.CODIGO_PROVEEDOR;
            row.FOLIO_COMPRA = detalle.FOLIO_COMPRA;
            row.LOTE = "";
            row.NOMBRE = detalle.NOMBRE;
            row.OBSERVACIONES = "";
            row.PARTIDA = detalles.Count;
            row.PROVEEDOR_ID = detalle.PROVEEDOR_ID;
            row.TIPO = detalle.TIPO;

            detalles.AddCOMPRAS_DET_LOTERow(row);
        }



        DataView vDetalles;
        private void buscarLocal()
        {
            //if (string.IsNullOrEmpty(propiedadBusqueda))
            //{
            //    SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow modelo = new SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETDataTable().NewORDEN_COMPRA_DETRow();
            //    propiedadBusqueda = Helpers.Reflect.GetMember(() => modelo.ARTICULO_ID).Name;
            //}
            ////vDetalles.RowFilter = propiedadBusqueda + " like '%" + this.buscarTextBoxX.Text.ToUpper() + "%'";
            //try
            //{
            //    ((DataTable)this.superGridControl1.PrimaryGrid.DataSource).Select(propiedadBusqueda + " like '%" + this.buscarTextBoxX.Text + "%'");
            //}
            //catch
            //{
            //}

            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable table = this.superGridControl1.PrimaryGrid.DataSource as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable;


            var encontrado = from e in table where (e.ARTICULO_ID == this.buscarTextBoxX.Text) || (e.NOMBRE.Contains(buscarTextBoxX.Text)) select e;


            if (encontrado.Count() > 0)
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow modelo = encontrado.First();


                var res =MessageBox.Show("¿Ya existe el medicamento en la lista de recepción, ¿desea agregar otro registro?", "Guardar", MessageBoxButtons.YesNo);

                if (res == DialogResult.Yes)
                {
                    SIFModelo.Articulo articulo = new SIFModelo.Articulo();
                    articulo.ARTICULO_ID = buscarTextBoxX.Text;

                    articulo = new SIFNegocio.Articulo().BuscarPorClave(articulo.ARTICULO_ID);

                    if (articulo == null)
                    {
                        return;
                    }
                    this.AgregaArticulo(articulo);
                }
                //scroll into view
                //this.superGridControl1.PrimaryGrid.SetActiveRow( = modelo;
                return;

            }
            else
            {

                SIFModelo.Articulo articulo = new SIFModelo.Articulo();
                articulo.ARTICULO_ID = buscarTextBoxX.Text;

                articulo = new SIFNegocio.Articulo().BuscarPorClave(articulo.ARTICULO_ID);

                if (articulo == null)
                {
                    return;
                }

                var res =MessageBox.Show("El artículo no se encontró en la lista de recepción, ¿desea agregarlo?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    return;
                }

                this.AgregaArticulo(articulo);
            }

        }

        private void Recibir()
        {
            //validar que llene las piezas correspondientes

            Boolean errorCero = false;
            //foreach (SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow row in )
            foreach (DataRow row in detalles)
            {
                if (System.Convert.ToInt32(row["CANT_RECIBIDA"]) == 0)
                //if(row.CANT_RECIBIDA == 0)
                {

                    errorCero = true;
                }

                var vs = from s in detalles where s.ARTICULO_ID == row["ARTICULO_ID"].ToString() select s;

                // SIFModelo.OrdenCompra.OrdenesCompraDataSet.COMPRAS_DETRow dRow = vs.FirstOrDefault();

                //if (dRow != null)
                //{
                //    dRow.CANT_RECIBIDA = System.Convert.ToInt32(row["CANT_RECIBIDA"]);
                //    dRow.CANT_FACTURADA = System.Convert.ToInt32(row["CANT_FACTURADA"]);
                //}
            }

            if (errorCero)
            {
                DialogResult dlg =MessageBox.Show("Hay artículos sin recibir, ¿Seguir con la recepción?", "Recibir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dlg == DialogResult.No)
                {


                    return;
                }
            }

            this.OrdenCompra.ESTADO_OC = "E";
            OrdenCompra.FECHA_AUTORIZA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            if (OrdenCompra.IsFECHA_CIERRENull())
                OrdenCompra.FECHA_CIERRE = new DateTime();
            if (OrdenCompra.IsFECHA_RECEPCIONNull())
                OrdenCompra.FECHA_RECEPCION = new DateTime();

            this.ordenCompraL.ActualizaOrdenCompra(OrdenCompra);
            this.RecibirOrdenCompra();
            this.Back();
        }

        private void CalculaTotal()
        {

            if (detalles == null)
            {
                return;
            }

            var v_cantidadSolicitada = detalles.Compute("SUM(cant_recibida)", "");
            var v_cantidadRecibida = detalles.Compute("SUM(cant_lote)", "");

            if (v_cantidadSolicitada.ToString().IsInteger())
            {
                this.pedidoLabel.Text = v_cantidadSolicitada.ToString();
            }

            if (v_cantidadRecibida.ToString().IsInteger())
            {
                this.recibidoLabel.Text = v_cantidadRecibida.ToString();
            }

        }

        private void RecibirOrdenCompra()
        {
            if (!validaTotales())
            {
                return;
            }

            //compraLote.RECEPCIONISTA = this.recibeComboBoxEx.Text;
            compraLote.OBSERVACIONES = observacionesGeneralesTextBox.Text;
            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTEDataTable table = this.superGridControl1.PrimaryGrid.DataSource as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTEDataTable;


            if (SIFNegocio.OrdenCompra.Compras.GuardarCompraLote(compraLote, table))
            {

                //if (!SIFNegocio.OrdenCompra.Compras.GuardaDetalles(rowDet))
                //{
                //   MessageBox.Show("Ocurrió un error al actualizar la compra");
                //    return;


                //}
                //foreach (DataRow row in table.Rows)
                //{
                //    SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow rowDet = new SIFModelo.OrdenCompra.OrdenesCompraDataSet().ORDEN_COMPRA_DET.NewORDEN_COMPRA_DETRow();

                //    rowDet.ARTICULO_ID = row["ARTICULO_ID"].ToString();
                //    rowDet.CANT_DEVUELTA = System.Convert.ToInt32(row["CANT_DEVUELTA"]);
                //    rowDet.CANT_FACTURADA = System.Convert.ToInt32(row["CANT_FACTURADA"]);
                //    rowDet.CANT_MALESTADO = System.Convert.ToInt32(row["CANT_MALESTADO"]);
                //    rowDet.CANT_RECIBIDA = System.Convert.ToInt32(row["CANT_RECIBIDA"]);
                //    rowDet.CANT_REPOSICION = System.Convert.ToInt32(row["CANT_REPOSICION"]);
                //    rowDet.CANT_SOLICITADA = System.Convert.ToInt32(row["CANT_SOLICITADA"]);
                //    rowDet.CODIGO_PROVEEDOR = row["CODIGO_PROVEEDOR"].ToString();
                //    //rowDet.DESCRIP_OFERTA = row["DESCRIP_OFERTA"].ToString();
                //    //rowDet.DESCTO_FACTURA = System.Convert.ToDecimal(row["DESCTO_FACTURA"]);
                //    rowDet.DESCTO_RECIBIDO = System.Convert.ToDecimal(row["DESCTO_RECIBIDO"]);
                //    rowDet.DESCTO_RECIBIDO_AD1 = System.Convert.ToDecimal(row["DESCTO_RECIBIDO_AD1"]);
                //    rowDet.DESCTO_RECIBIDO_AD2 = System.Convert.ToDecimal(row["DESCTO_RECIBIDO_AD2"]);
                //    rowDet.DESCTO_RECIBIDO_AD3 = System.Convert.ToDecimal(row["DESCTO_RECIBIDO_AD3"]);
                //    rowDet.DESCTO_RECIBIDO_AD4 = System.Convert.ToDecimal(row["DESCTO_RECIBIDO_AD4"]);
                //    rowDet.DESCUENTO_GENERAL = System.Convert.ToDecimal(row["DESCUENTO_GENERAL"]);
                //    rowDet.EXISTENCIAS = System.Convert.ToInt32(row["EXISTENCIAS"]);
                //    rowDet.FOLIO_OC_ID = row["FOLIO_OC_ID"].ToString();
                //    rowDet.IMPORTE = System.Convert.ToDecimal(row["IMPORTE"]);
                //    rowDet.LABORATORIO_ID = System.Convert.ToInt32(row["LABORATORIO_ID"]);
                //    rowDet.MARGEN_UTILIDAD = System.Convert.ToDecimal(row["MARGEN_UTILIDAD"]);
                //    rowDet.NOMBRE = row["NOMBRE"].ToString();
                //    rowDet.NUM_PARTIDA = System.Convert.ToDecimal(row["NUM_PARTIDA"]);
                //    rowDet.OBSERVACION_OC_DET = row["OBSERVACION_OC_DET"].ToString();
                //    rowDet.OFERTA_COMPRA_ID = System.Convert.ToDecimal(row["OFERTA_COMPRA_ID"]);
                //    rowDet.PRECIO_COSTO = System.Convert.ToDecimal(row["PRECIO_COSTO"]);
                //    rowDet.PRECIO_FACTURA = System.Convert.ToDecimal(row["PRECIO_FACTURA"]);
                //    rowDet.PRECIO_FARMACIA = System.Convert.ToDecimal(row["PRECIO_FARMACIA"]);
                //    rowDet.PROVEEDOR_ID = System.Convert.ToInt32(row["PROVEEDOR_ID"]);
                //    rowDet.PUNTO_DE_REORDEN = System.Convert.ToInt32(row["PUNTO_DE_REORDEN"]);
                //    rowDet.TIPO_MEDICAMENTO_CVE = row["TIPO_MEDICAMENTO_CVE"].ToString();
                //    rowDet.ULT_PRECIO_COMPRA = System.Convert.ToDouble(row["ULT_PRECIO_COMPRA"]);
                //    rowDet.USUARIO_ID = System.Convert.ToDecimal(row["USUARIO_ID"]);


                //}

                MessageBox.Show("Se han agregado los lotes y caducidades " + compraLote.FOLIO_COMPRA);
            }


        }

        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.buscarLocal();
        }

        public object Owner { get; set; }

        internal void Muestra()
        {
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;

            if (Owner is View.OrdenCompra.RecepcionOrdenCompraUserControl)
            {
                View.OrdenCompra.RecepcionOrdenCompraUserControl propietario = Owner as View.OrdenCompra.RecepcionOrdenCompraUserControl;
                propietario.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                propietario.Owner.DesactivaComandos();
                propietario.DesactivaComandos();
            }

            if (Owner is View.OrdenCompra.OrdenesCompraUserControl)
            {
                View.OrdenCompra.OrdenesCompraUserControl propietario = Owner as View.OrdenCompra.OrdenesCompraUserControl;
                View.Menu.ComprasMenu propietarioOwner = propietario.Owner as View.Menu.ComprasMenu;
                propietarioOwner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                propietario.DesactivaComandos();
            }
        }

        private void Back()
        {
            try
            {
                if (Owner is View.OrdenCompra.RecepcionOrdenCompraUserControl)
                {
                    View.OrdenCompra.RecepcionOrdenCompraUserControl propietario = Owner as View.OrdenCompra.RecepcionOrdenCompraUserControl;
                    if (propietario.Owner.Owner.Contains(this))
                    {
                        propietario.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    propietario.ActivaComandos();
                    this.Mostrado = false;
                    this.DesactivaComandos();
                }

                if (Owner is View.OrdenCompra.OrdenesCompraUserControl)
                {
                    View.OrdenCompra.OrdenesCompraUserControl propietario = Owner as View.OrdenCompra.OrdenesCompraUserControl;
                    View.Menu.ComprasMenu propietarioOwner = propietario.Owner as View.Menu.ComprasMenu;
                    if (propietarioOwner.Owner.Contains(this))
                    {
                        propietarioOwner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    }
                    propietario.ActivaComandos();
                    this.Mostrado = false;
                    this.DesactivaComandos();
                }
            }
            catch { }
        }

        public void ActivaComandos()
        {
            this.backButton.Shortcuts.Add(eShortcut.F12);
            this.agregarLoteCaducidadButtonItem.Shortcuts.Add(eShortcut.F4);
            this.recibirButtonItem.Shortcuts.Add(eShortcut.F5);
            // this.recibirYAfectarButtonItem.Shortcuts.Add(eShortcut.);
        }
        public void DesactivaComandos()
        {
            this.backButton.Shortcuts.Clear();
            this.agregarLoteCaducidadButtonItem.Shortcuts.Clear();
            this.recibirButtonItem.Shortcuts.Clear();
            //this.recibirYAfectarButtonItem.Shortcuts.Clear();
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
                this.buscarLocal();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
                this.buscarLocal();
            }
        }

        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle revisarRowStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle normalRowStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
        DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle WarningCellStyle = new DevComponents.DotNetBar.SuperGrid.Style.CellVisualStyle();//superGridControl1.DefaultVisualStyles.RowStyles;

        private int cantidadArticulo(string articuloClave)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable table = this.superGridControl1.PrimaryGrid.DataSource as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable;

            object obj = table.Compute("cantidad", "articulo_id = '" + articuloClave + "'");

            int cantidadAgregada = 0;

            if (SIFNegocio.Helpers.Validadociones.IsNumeric(obj.ToString()))
            {
                cantidadAgregada = System.Convert.ToInt32(obj.ToString());
            }

            return cantidadAgregada;

        }

        private void superGridControl1_EndEdit(object sender, DevComponents.DotNetBar.SuperGrid.GridEditEventArgs e)
        {
            if (superGridControl1.EditorColumn == superGridControl1.PrimaryGrid.Columns["OBSERVACIONESColumn"])
            {
                return;
            }

            if (superGridControl1.EditorColumn != superGridControl1.PrimaryGrid.Columns["CADUCIDADColumn"] && superGridControl1.EditorColumn != superGridControl1.PrimaryGrid.Columns["LOTEColumn"])
            {
                if (!e.EditControl.EditorFormattedValue.ToString().IsIntegerPositive())
                {
                    e.EditControl.EndEdit();
                    MessageBox.Show("El formato de número no es válido");
                    e.Cancel = true;
                    return;
                }
            }
            // int nuevoValor = int.Parse(e.EditControl.EditorFormattedValue.ToString());

            SuperGridControl grid = sender as SuperGridControl;
            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTERow row = (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTERow)((DataRowView)(e.GridCell.GridRow.DataItem)).Row;
            if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_LOTE).Name)
            {
                //row.CANT_FACTURADA = nuevoValor;
                //if (row.CANT_RECIBIDA > row.CANT_LOTE)
                //{
                //    e.EditControl.EndEdit();
                //    MessageBox.Show("La cantidad de la factura es mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                //else
                if (row.CANT_RECIBIDA >= row.CANT_LOTE)
                {
                    object obj = detalles.Compute("SUM(CANT_LOTE)", " ARTICULO_ID = '" + row.ARTICULO_ID + "'");

                    if (obj.ToString().IsInteger())
                    {
                        decimal articulosLote = System.Convert.ToInt32(obj.ToString());

                        if (articulosLote > row.CANT_RECIBIDA)
                        {
                            MessageBox.Show("La cantidad de lote no puede ser mayor al total de la recepcion");
                            e.Cancel = true;
                            return;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("La cantidad de lote no puede ser mayor a la recibida");
                    e.Cancel = true;
                    return;
                }
            }

            //if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_RECIBIDA).Name)
            //{
            //    // row.CANT_RECIBIDA = nuevoValor;
            //    if (row.CANT_RECIBIDA > row.CANT_SOLICITADA)
            //    {
            //        e.EditControl.EndEdit();
            //        MessageBox.Show("La cantidad recibida es mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    if (row.CANT_RECIBIDA == row.CANT_SOLICITADA)
            //    {
            //        //e.GridCell.GridRow.CellStyles.Default = normalRowStyle;
            //        //e.GridCell.GridRow.RowStyles.Default.ApplyStyle(normalRowStyle);
            //    }
            //}

            //if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_DEV_FALTANTE).Name)
            //{
            //    // row.CANT_RECIBIDA = nuevoValor;
            //    if (row.CANT_DEV_FALTANTE > row.CANT_SOLICITADA)
            //    {
            //        e.EditControl.EndEdit();
            //        MessageBox.Show("La cantidad faltante no puede ser mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }

            //}

            ////if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_MALESTADO).Name || grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_DEV_FALTANTE).Name || grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_PROX_CADUCAR).Name || grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_DEV_NO_PEDIDO).Name || grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_DEV_PRECIO_ELEVADO ).Name)
            ////{
            ////    if (( row.CANT_MALESTADO + row.CANT_DEV_FALTANTE + row.CANT_PROX_CADUCAR +  row.CANT_DEV_NO_PEDIDO +  row.CANT_DEV_PRECIO_ELEVADO) > row.CANT_RECIBIDA)
            ////    {
            ////        e.EditControl.EndEdit();
            ////        MessageBox.Show("La cantidad a devolver es mayor a la recibida", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ////    }
            ////}

            ////if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_PROX_CADUCAR).Name)
            ////{
            ////    if (row.CANT_PROX_CADUCAR > row.CANT_SOLICITADA)
            ////    {
            ////        e.EditControl.EndEdit();
            ////        MessageBox.Show("La cantidad devuelta es mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ////    }
            ////}

            ////if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_REPOSICION).Name)
            ////{
            ////    if (row.CANT_REPOSICION > row.CANT_SOLICITADA)
            ////    {
            ////        e.EditControl.EndEdit();
            ////        MessageBox.Show("La cantidad repuesta es mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ////    }
            ////}

            ////if (grid.PrimaryGrid.Columns[e.GridCell.ColumnIndex].DataPropertyName == Helpers.Reflect.GetMember(() => row.CANT_REPOSICION).Name)
            ////{
            ////    if (row.CANT_REPOSICION > row.CANT_SOLICITADA)
            ////    {
            ////        MessageBox.Show("La cantidad repuesta es mayor a la solicitada", "Recibir", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            ////    }
            ////}

            ////calcula totales
            //int cantRecibida = row.CANT_FACTURADA;

            //if (cantRecibida == 0 && row.FacturaProveedorDetalle == null)
            //{
            //    cantRecibida = row.CANT_SOLICITADA;
            //}

            //row.CANT_RECIBIDA = cantRecibida - row.CANT_DEV_FALTANTE - row.CANT_DEV_NO_PEDIDO - row.CANT_DEV_PRECIO_ELEVADO - row.CANT_MALESTADO - row.CANT_PROX_CADUCAR;
            //e.GridCell.GridRow.Cells["CANTIDAD_RECIBIDAColumn"].Value = row.CANT_RECIBIDA;
            ////

            //this.CalculaTotal();
        }

        private bool validaTotales()
        {
            List<string> detallesAgregados = new List<string>();


            int partida = 1;
            foreach (var detalle in detalles)
            {
                detalle.PARTIDA = partida;
                partida++;

                if (!detallesAgregados.Contains(detalle.ARTICULO_ID))
                {
                    detallesAgregados.Add(detalle.ARTICULO_ID);
                }
            }

            bool esIncompleto  = false;

            foreach (string articulo_id in detallesAgregados)
            {
                object objLote = detalles.Compute("SUM(CANT_LOTE)", " ARTICULO_ID = '" + articulo_id + "'");

                var articuloEncontrado = detalles.First(d => d.ARTICULO_ID == articulo_id);
                decimal cantidadArticulo = 0;

                if (articuloEncontrado != null)
                {
                    articuloEncontrado.CANT_RECIBIDA = articuloEncontrado.CANT_RECIBIDA;
                }

                if (objLote.ToString().IsInteger())
                {
                    if (cantidadArticulo.ToString().IsInteger())
                    {
                        int cantLote = System.Convert.ToInt32(objLote);
                        int cantRecibida = System.Convert.ToInt32(cantidadArticulo);

                        if (cantRecibida != cantLote)
                        {
                            esIncompleto = true;
                           // return false;
                        }
                    }
                }
            }


            if (MessageBoxEx.Show("La cantidad en lote y caducidad no cubre el total de articulos recibidos, ¿Desea continuar?", "Guardar",  MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return false;
            }

            return true;
        }

        private string propiedadBusqueda;
        private void superGridControl1_ColumnHeaderClick(object sender, GridColumnHeaderClickEventArgs e)
        {
            this.buscarTextBoxX.WatermarkText = "BUSCAR POR " + e.GridColumn.HeaderText;
            this.propiedadBusqueda = e.GridColumn.DataPropertyName;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void RecepcionOrdenCompraDetallesUserControl_Load(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Focus();
            this.superGridControl1.PrimaryGrid.SelectionGranularity = SelectionGranularity.Cell;
        }

        private void superGridControl1_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {

        }

        private void recibirYAfectarButtonItem_Click(object sender, EventArgs e)
        {
            this.Recibir();
        }

        private void superGridControl1_PostRenderRow(object sender, GridPostRenderRowEventArgs e)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTERow row = (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTERow)((DataRowView)( ((GridRow)e.GridRow).DataItem)).Row;


            if (row.IsCADUCIDADNull())
            {
                row.CADUCIDAD = new DateTime();
            }
            if (row.IsOBSERVACIONESNull())
            {
                row.OBSERVACIONES = "";
            }
            if (row.IsLOTENull())
            {
                row.LOTE = "";
            }


            object objLote = detalles.Compute("SUM(CANT_LOTE)", " ARTICULO_ID = '" + row.ARTICULO_ID + "'");

            if (objLote.ToString().IsInteger())
            {
                  int cantLote = System.Convert.ToInt32(objLote);
                    int cantRecibida = row.CANT_RECIBIDA;

                    if (cantRecibida != cantLote)
                    {
                        e.GridRow.CellStyles.Default = WarningCellStyle;
                        e.GridRow.RowStyles.Default.ApplyStyle(WarningCellStyle);
                        // return false;
                    }
            }

            //VALIDAR QUE EL LOTE Y CADUICIDAD SEA UNICO POR ARTICULO
            object loteRepetido = detalles.Compute("COUNT(ARTICULO_ID)", "ARTICULO_ID = '" + row.ARTICULO_ID + "' AND LOTE = '" + row.LOTE+ "' AND CADUCIDAD = '" +row.CADUCIDAD+ "'");

            if (loteRepetido.ToString().IsInteger())
            {
                int lRepetido = System.Convert.ToInt32(loteRepetido.ToString());

                if (lRepetido > 1)
                {
                    e.GridRow.CellStyles.Default = this.revisarRowStyle;
                    e.GridRow.RowStyles.Default.ApplyStyle(revisarRowStyle);
                }
            }
            
            ////if (row.CANT_RECIBIDA == 0)
            ////{
            ////    e.GridRow.CellStyles.Default = WarningCellStyle;
            ////    e.GridRow.RowStyles.Default.ApplyStyle(WarningCellStyle);
            ////}
            ////else if (row.CANT_FACTURADA > row.CANT_SOLICITADA)
            ////{
            ////    e.GridRow.CellStyles.Default = revisarRowStyle;
            ////    e.GridRow.RowStyles.Default.ApplyStyle(revisarRowStyle);
            ////}
            ////else if (row.CANT_RECIBIDA > row.CANT_SOLICITADA)
            ////{
            ////    e.GridRow.CellStyles.Default = revisarRowStyle;
            ////    e.GridRow.RowStyles.Default.ApplyStyle(revisarRowStyle);
            ////}
            ////else
            ////{
            ////    e.GridRow.CellStyles.Default = normalRowStyle;
            ////    e.GridRow.RowStyles.Default.ApplyStyle(normalRowStyle);
            ////}


            //else if (row.CANT_MALESTADO > row.CANT_SOLICITADA)
            //{
            //    e.GridRow.CellStyles.Default = revisarRowStyle;
            //    e.GridRow.RowStyles.Default.ApplyStyle(revisarRowStyle);
            //}
            //else if (row.CANT_DEVUELTA > row.CANT_SOLICITADA)
            //{
            //    e.GridRow.CellStyles.Default = revisarRowStyle;
            //    e.GridRow.RowStyles.Default.ApplyStyle(revisarRowStyle);
            //}
            //else if (row.CANT_REPOSICION > row.CANT_SOLICITADA)
            //{
            //    e.GridRow.CellStyles.Default = revisarRowStyle;
            //    e.GridRow.RowStyles.Default.ApplyStyle(revisarRowStyle);
            //}
            //else
            //{
            //    e.GridRow.CellStyles.Default = normalRowStyle;
            //    e.GridRow.RowStyles.Default.ApplyStyle(normalRowStyle);
            //}
        }

        private void superGridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            //GridRow row = this.superGridControl1.ActiveRow as GridRow;

            //if (row == null)
            //{
            //    return;
            //}

            //if (e.KeyCode == Keys.Down)
            //{

            //    int columna = superGridControl1.ActiveCell.ColumnIndex;
            //    if (row.RowIndex < superGridControl1.PrimaryGrid.LastSelectableRow.RowIndex)
            //    { row.GetCell(columna).BeginEdit(true); }

            //    //GridCell celda = this.superGridControl1.;
            //    //celda = superGridControl1.cell 
            //    //var s = superGridControl1.PrimaryGrid.SetActiveCell( superGridControl1.PrimaryGrid.ActiveRow.rowi;
            //    // //superGridControl1.PrimaryGrid.SetActiveCell();
            //    // //this.superGridControl1.PrimaryGrid.SetActiveCell(celda);
            //    // celda.BeginEdit(true);
            //}
            //if (e.KeyCode == Keys.Right)
            //{
            //    int columna = superGridControl1.ActiveCell.ColumnIndex;
            //    if (columna <= superGridControl1.PrimaryGrid.Columns.Count - 1)
            //    {
            //        columna++;
            //        try
            //        {
            //            row.GetCell(columna).BeginEdit(true);
            //        }
            //        catch
            //        {
            //            superGridControl1.CancelCapture();
            //        }
            //    }
            //}
        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }
        }

        private void agregaProductoButtonItem_Click(object sender, EventArgs e)
        {
            this.AgregaArticulo();
        }

        private void actualizaArticuloButtonItem_Click(object sender, EventArgs e)
        {
            View.Articulos.ArticuloUserControl frmArticulos = new View.Articulos.ArticuloUserControl();
            frmArticulos.Owner = this;
            frmArticulos.Funcion = "Actualiza";
            frmArticulos.Muestra();
        }

        public void actualizaArticulo(SIFModelo.Articulo articulo)
        {
            Catalogos.ClaveArticuloForm frmArticulo = new Catalogos.ClaveArticuloForm();

            var detalle = ((((GridRow)this.superGridControl1.PrimaryGrid.ActiveRow).DataItem as DataRowView).Row) as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow;

            String codigoAnterior = detalle.ARTICULO_ID;

            detalle.ARTICULO_ID = articulo.ARTICULO_ID;
            detalle.NOMBRE = articulo.NOMBRE1;
            ordenCompraL.ActualizaCodigo(detalle, codigoAnterior);

            //si existe orden de compra tambien actualizar
            //if (compra == null)
            //{
            SIFNegocio.OrdenCompra.Compras.ActualizaCodigo(detalle.ARTICULO_ID, articulo.NOMBRE1, codigoAnterior);

            detalle.ARTICULO_ID = articulo.ARTICULO_ID;

            this.superGridControl1.PrimaryGrid.DataSource = detalles;
            //}
        }

        private void agregarLoteCaducidadButtonItem_Click(object sender, EventArgs e)
        {
            this.AgregarLoteCaducidad();
        }
    }
}
