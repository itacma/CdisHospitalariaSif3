using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Inventario
{
    public partial class PedidoAlmacenUserControl : Templates.CatalogoUserControl
    {
        Boolean almacen50 = false;
        string TipoArt = string.Empty;
        public int NoLote;
        public String NoPedido;

        SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASPRow Pedido;

        public PedidoAlmacenUserControl()
        {
            InitializeComponent();
            LblSucOrigen.Text = Helpers.Sesion.Sucursal.SucursalID.ToString() + "-" + Helpers.Sesion.Sucursal.Nombre;
            this.CargaSucursalDestino();
            this.CargaMotivoPedido();
            this.Grd_Pedido.AutoGenerateColumns = false;
        }

        public bool Mostrado { get; set; }

        internal void Muestra()
        {
            if (Mostrado)
            {
                return;
            }

            this.Dock = DockStyle.Fill;
            Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.ActivaComandos();
            this.Owner.DesactivaComandos();
            Mostrado = true;
            foliotextBoxX.Text = "Nuevo";

            // verificamos el pedido y si existe lo mostramos
            if (NoPedido != null)
            {
                pedidoAlmacenL.PedidosDataSet = pedidoAlmacenL.GetPedidosTraspaso(NoPedido, NoLote);
                foliotextBoxX.Text = NoPedido;
                DataRow Pedidos = pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP.Rows[0];
                LblSucOrigen.Text = Pedidos["Origen"].ToString();
                SucursalDestinoComboBox.Text = Pedidos["Destino"].ToString();
                tb_LotePedido.Text = Pedidos["Lote"].ToString();
                txtReferencia.Text = Pedidos["Referencia"].ToString();

                ///AVM 10-04-2015 SE EDITA EL MOTIVO EN EL COMBO Y SE INHABILITA EL COMBO.
                cmbMotivoPedido.SelectedIndex = int.Parse(Pedidos["ID_MOTIVO_PEDIDO"].ToString());
                cmbMotivoPedido.Enabled = false;
                ///f

                Grd_Pedido.DataSource = pedidoAlmacenL.PedidosDataSet;
                Grd_Pedido.DataMember = "PEDIDO_TRASP_DET";
                label1.Text = pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET.Compute("Sum(CANTIDAD_SOLIC)", "").ToString();
            }
        }

        /// <summary>
        /// CARGA LOS MOTIVOS DEL PEDIDOP
        /// </summary>
        private void CargaMotivoPedido()
        {
            List<SIFModelo.MotivoPedido> MotivoPedido_List = new List<SIFModelo.MotivoPedido>();

            SIFNegocio.MotivoPedido MotivoPedidoN = new SIFNegocio.MotivoPedido(); 
            SIFModelo.MotivoPedido MotivoPedidoM = new SIFModelo.MotivoPedido();             
            MotivoPedidoM.ID = 0;
            MotivoPedidoM.NOMBRE = "SELECCIONE...";

            foreach(var item in MotivoPedidoN.Buscar())
            {
                if (MotivoPedido_List.Count == 0)
                    MotivoPedido_List.Add(MotivoPedidoM);

                MotivoPedido_List.Add(item);
            }
            
            cmbMotivoPedido.DataSource = MotivoPedido_List;
            cmbMotivoPedido.DisplayMember = "NOMBRE";
            cmbMotivoPedido.ValueMember = "ID";
            
        }

        private void CargaSucursalDestino()
        {
            BindingList<SIFModelo.Sucursal> sucursales = new BindingList<SIFModelo.Sucursal>();
            //SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { Nombre = "[TODAS]", SucursalesID = 0 };
            //sucursales.Add(sucursal);
            //sucursales.ToList();d
            List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().Buscar("", "").DataSource as List<SIFModelo.Sucursal>;

            /// AVM 21-04-2015
            SIFModelo.Sucursal modelSeleccione = new SIFModelo.Sucursal();
            modelSeleccione.Nombre = "SELECCIONE...";
            modelSeleccione.SucursalesID = -1;
            modelSeleccione.SucursalID = -1;
            
            sucursales.Add(modelSeleccione);
            ///AVM 21-04-2015

            foreach (SIFModelo.Sucursal sucursalBd in sucursalesBD)
            {
                if (sucursalBd.SucursalID != Helpers.Sesion.Sucursal.SucursalID)
                    sucursales.Add(sucursalBd);
            }

            SucursalDestinoComboBox.DataSource = sucursales;
            SucursalDestinoComboBox.DisplayMember = "NOMBRE";
            SucursalDestinoComboBox.ValueMember = "SUCURSALESID";
        }

        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.guardarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.agregaProductoButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);

        }

        public void AgregaA(string claveArticulo)
        {
            if (string.IsNullOrEmpty(claveArticulo))
            {
                return;
            }

            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(claveArticulo);

            if (articulo == null)
            {
               MessageBox.Show("El artículo no existe en el catalogo");
                return;
            }
            string TipoArt = string.Empty;
            descripcionLabel.Text = articulo.NOMBRE1;
            TipoArt = articulo.TIPO_MEDICAMENTO_CVE;
            if (TipoArt.Contains("F1"))
                NoLote = 2;
            else
                NoLote = 1;
            // System.Windows.Forms.SendKeys.Send("{TAB}");
            this.AgregaArticulo(articulo);
        }

        public void AgregaArticulo(string claveArticulo)
        {
            if (string.IsNullOrEmpty(claveArticulo))
            {
                return;
            }

            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(claveArticulo);

            if (articulo == null)
            {
               MessageBox.Show("El artículo no existe en el catalogo");
                return;
            }
            string TipoArt = string.Empty;
            descripcionLabel.Text = articulo.NOMBRE1;
            TipoArt = articulo.TIPO_MEDICAMENTO_CVE;
            if (TipoArt.Contains("F1"))
                NoLote = 2;
            else
                NoLote = 1;
            //System.Windows.Forms.SendKeys.Send("{TAB}");
            this.AgregaArticulo(articulo);
        }
        public void modificaCantidad(string claveArticulo)
        {
            if (string.IsNullOrEmpty(claveArticulo))
            {
                return;
            }

            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            SIFModelo.Articulo articulo = articuloL.BuscarPorClave(claveArticulo);

            if (articulo == null)
            {
               MessageBox.Show("El artículo no existe en el catalogo");
                return;
            }
            string TipoArt = string.Empty;
            descripcionLabel.Text = articulo.NOMBRE1;
            TipoArt = articulo.TIPO_MEDICAMENTO_CVE;
            if (TipoArt.Contains("F1"))
                NoLote = 2;
            else
                NoLote = 1;
            //System.Windows.Forms.SendKeys.Send("{TAB}");
            this.Modificaarticulo(articulo);
        }

        SIFNegocio.Inventario.PedidosAlmacen pedidoAlmacenL = new SIFNegocio.Inventario.PedidosAlmacen();
        public void Modificaarticulo(SIFModelo.Articulo articulo)
        {
            //REVISAR SI YA EXISTE UNA OFERTA CON ESE ARTICULO Y ESTA ACTIVO
            int cantidad = 0;
            CodigoTextBoxX.Text = articulo.ARTICULO_ID;
            if (this.cantidadTextBoxX.Text.IsIntegerPositive())
                cantidad = int.Parse(this.cantidadTextBoxX.Text);

            SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow rowDetalle = pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET.NewPEDIDO_TRASP_DETRow();
            // buscamos si ya existe en el detalle solo agregamos la cantidad

            Pedido.LOTE = tb_LotePedido.Value;
            rowDetalle.ARTICULO_ID = articulo.ARTICULO_ID;

            rowDetalle.CANTIDAD_SOLIC = cantidad;
            rowDetalle.CONCEPTO = articulo.NOMBRE1;
            rowDetalle.FOLIO = Pedido.FOLIO;
            if (articulo.TIPO_MEDICAMENTO_CVE.Contains("F1"))
                rowDetalle.LOTE = 2;
            else
                rowDetalle.LOTE = 1;
            rowDetalle.PARTIDA = pedidoAlmacenL.SigPart(pedidoAlmacenL.PedidosDataSet, int.Parse(rowDetalle.LOTE.ToString()));
            rowDetalle.NOMBRE1 = articulo.NOMBRE1;
            rowDetalle.NOMBRE2 = articulo.NOMBRE2;
            rowDetalle.SOLICITADO = cantidad;
            rowDetalle.LISTA_SUCURSAL_VTA = articulo.LISTA_SUCURSAL_VTA;
            double EOQ = new SIFNegocio.Inventario.Inventario().InventarioArticulo(articulo).PUNTO_DE_REORDEN;
            rowDetalle.EOQ = (int)EOQ;
            pedidoAlmacenL.AgregaDetalleCantidad(rowDetalle, pedidoAlmacenL.PedidosDataSet);
            label1.Text = pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET.Compute("Sum(CANTIDAD_SOLIC)", "").ToString();
            this.Grd_Pedido.DataSource = pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET;
            descripcionLabel.Text = articulo.NOMBRE1;
        }
        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            /// AVM 09-04-2015
            /// valida las reglas segun el motivo del pedido que se halla seleccionado
            if (cmbMotivoPedido.SelectedIndex >= 1)
                if (!ValidarReglasTipoPedido(articulo))
                    return;

            //REVISAR SI YA EXISTE UNA OFERTA CON ESE ARTICULO Y ESTA ACTIVO
            int cantidad = 1;
            CodigoTextBoxX.Text = articulo.ARTICULO_ID;
            if (this.cantidadTextBoxX.Text.IsIntegerPositive())
                cantidad = int.Parse(this.cantidadTextBoxX.Text);

            SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow rowDetalle = pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET.NewPEDIDO_TRASP_DETRow();
            // buscamos si ya existe en el detalle solo agregamos la cantidad

            Pedido.LOTE = tb_LotePedido.Value;
            rowDetalle.ARTICULO_ID = articulo.ARTICULO_ID;

            rowDetalle.CANTIDAD_SOLIC = cantidad;
            rowDetalle.CONCEPTO = articulo.NOMBRE1;
            rowDetalle.FOLIO = Pedido.FOLIO;
            if (articulo.TIPO_MEDICAMENTO_CVE.Contains("F1"))
                rowDetalle.LOTE = 2;
            else
                rowDetalle.LOTE = 1;
            rowDetalle.PARTIDA = pedidoAlmacenL.SigPart(pedidoAlmacenL.PedidosDataSet, int.Parse(rowDetalle.LOTE.ToString()));
            rowDetalle.NOMBRE1 = articulo.NOMBRE1;
            rowDetalle.NOMBRE2 = articulo.NOMBRE2;
            rowDetalle.SOLICITADO = cantidad;
            rowDetalle.LISTA_SUCURSAL_VTA = articulo.LISTA_SUCURSAL_VTA;
            double EOQ = new SIFNegocio.Inventario.Inventario().InventarioArticulo(articulo).PUNTO_DE_REORDEN;
            rowDetalle.EOQ = (int)EOQ;
            pedidoAlmacenL.AgregaDetalle(rowDetalle, pedidoAlmacenL.PedidosDataSet);
            label1.Text = pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET.Compute("Sum(CANTIDAD_SOLIC)", "").ToString();
            this.Grd_Pedido.DataSource = pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET;
            descripcionLabel.Text = articulo.NOMBRE1;

            if (pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET.Count >= 1)
                cmbMotivoPedido.Enabled = false;
        }

        /// <summary>
        /// AVM 09-04-2015
        /// Valida las reglas del pedido
        /// </summary>
        private Boolean ValidarReglasTipoPedido(SIFModelo.Articulo articulo)
        {
            //////
            SIFModelo.MotivoPedido MotivoPedidoModel = cmbMotivoPedido.SelectedItem as SIFModelo.MotivoPedido;

            SIFNegocio.Articulo ArtNegocio = new SIFNegocio.Articulo();
            SIFModelo.Inventarios.Inventario InventarioArt = ArtNegocio.InventarioPorArticulo(articulo);
            /////////

            //VALIDA QUE LA CANTIDAD DE ACTICULOS AGREGADOS SEA IGUAL O MENOR A LA PERMITIDA
            if (pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET.Count >= MotivoPedidoModel.MAX_SKUS)
            {
                var encontrado = from r in pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET where r.ARTICULO_ID == articulo.ARTICULO_ID select r;
                if (encontrado.Count() < 1)
                {
                    MessageBox.Show("Se ha alcanzado el número máximo de elementos para el tipo de pedido: " + MotivoPedidoModel.NOMBRE);
                    return false;
                }
            }

            #region VALIDAR EOQ EN CASO DE NO VENIR VACIO
            if (MotivoPedidoModel.PARAMETRO_EOQ != "" || !MotivoPedidoModel.PARAMETRO_EOQ.Equals(null))
            {
                if (MotivoPedidoModel.PARAMETRO_EOQ.Equals("=")) //si es diferente no es igual (==)
                {
                    if (InventarioArt.PuntoDeReorden != MotivoPedidoModel.VALOR_EOQ)
                    {
                        MessageBox.Show("EL PUNTO DE REORDEN DEL ARTICULO ES DIFERENTE DE LA REGLA DEL" +
                        " MOTIVO SELECCIONADO: (" +MotivoPedidoModel.VALOR_EOQ + ").", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return false;
                    }

                }
                else if (MotivoPedidoModel.PARAMETRO_EOQ.Equals(">"))
                {
                    if (InventarioArt.PuntoDeReorden <= MotivoPedidoModel.VALOR_EOQ)
                    {
                        MessageBox.Show("EL PUNTO DE REORDEN DEL ARTICULO ES DIFERENTE DE LA REGLA DEL" +
                        " MOTIVO SELECCIONADO: (" + MotivoPedidoModel.NOMBRE + ").", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return false;
                    }
                }
                else if (MotivoPedidoModel.PARAMETRO_EOQ.Equals("<"))
                {
                    if (InventarioArt.PuntoDeReorden >= MotivoPedidoModel.VALOR_EOQ)
                    {
                        MessageBox.Show("EL PUNTO DE REORDEN DEL ARTICULO ES DIFERENTE DE LA REGLA DEL" +
                        " MOTIVO SELECCIONADO: (" + MotivoPedidoModel.NOMBRE + ").", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return false;
                    }
                }
                else if (MotivoPedidoModel.PARAMETRO_EOQ.Equals(">="))
                {
                    if (InventarioArt.PuntoDeReorden < MotivoPedidoModel.VALOR_EOQ)
                    {
                        MessageBox.Show("EL PUNTO DE REORDEN DEL ARTICULO ES DIFERENTE DE LA REGLA DEL" +
                        " MOTIVO SELECCIONADO: (" + MotivoPedidoModel.NOMBRE + ").", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return false;
                    }
                }
                else if (MotivoPedidoModel.PARAMETRO_EOQ.Equals("<="))
                {
                    if (InventarioArt.PuntoDeReorden > MotivoPedidoModel.VALOR_EOQ)
                    {
                    MessageBox.Show("EL PUNTO DE REORDEN DEL ARTICULO ES DIFERENTE DE LA REGLA DEL" +
                    " MOTIVO SELECCIONADO: (" + MotivoPedidoModel.NOMBRE + ").", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                    }
                }
                else if (MotivoPedidoModel.PARAMETRO_EOQ.Equals("<>")) // si son iguales no es diferente de (<>)
                {
                    if (InventarioArt.PuntoDeReorden == MotivoPedidoModel.VALOR_EOQ)
                    {
                        MessageBox.Show("EL PUNTO DE REORDEN DEL ARTICULO ES DIFERENTE DE LA REGLA DEL" +
                        " MOTIVO SELECCIONADO: (" + MotivoPedidoModel.NOMBRE + ").", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return false;
                    }
                }
            }
            #endregion VALIDAR EOQ EN CASO DE NO VENIR VACIO

            #region VALIDAR EXISTENCIA EN CASO DE NO VENIR VACIO
                if (MotivoPedidoModel.PARAMETRO_EXIS != " " || !MotivoPedidoModel.PARAMETRO_EXIS.Equals(null))
                {
                    if (MotivoPedidoModel.PARAMETRO_EXIS.Equals("=")) //si es diferente no es igual (==)
                    {
                        if (InventarioArt.Existencias != MotivoPedidoModel.VALOR_EXIS)
                        {
                            MessageBox.Show("LA EXISTENCIA DEL ARTICULO ES DIFERENTE DE LA REGLA DEL" +
                                " MOTIVO SELECCIONADO: (" + MotivoPedidoModel.NOMBRE + ").", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return false;
                        }

                    }
                    else if (MotivoPedidoModel.PARAMETRO_EXIS.Equals(">"))
                    {
                        if (InventarioArt.Existencias <= MotivoPedidoModel.VALOR_EXIS)
                        {
                            MessageBox.Show("LA EXISTENCIA DEL ARTICULO ES DIFERENTE DE LA REGLA DEL" +
                                " MOTIVO SELECCIONAD: (" + MotivoPedidoModel.NOMBRE + ").", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return false;
                        }
                    }
                    else if (MotivoPedidoModel.PARAMETRO_EXIS.Equals("<"))
                    {
                        if (InventarioArt.Existencias >= MotivoPedidoModel.VALOR_EXIS)
                        {
                            MessageBox.Show("LA EXISTENCIA DEL ARTICULO ES DIFERENTE DE LA REGLA DEL" +
                                " MOTIVO SELECCIONADO: (" + MotivoPedidoModel.NOMBRE + ").", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return false;
                        }
                    }
                    else if (MotivoPedidoModel.PARAMETRO_EXIS.Equals(">="))
                    {
                        if (InventarioArt.Existencias < MotivoPedidoModel.VALOR_EXIS)
                        {
                            MessageBox.Show("LA EXISTENCIA DEL ARTICULO ES DIFERENTE DE LA REGLA DEL" +
                                " MOTIVO SELECCIONADO: (" + MotivoPedidoModel.NOMBRE + ").", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return false;
                        }
                    }
                    else if (MotivoPedidoModel.PARAMETRO_EXIS.Equals("<="))
                    {
                        if (InventarioArt.Existencias > MotivoPedidoModel.VALOR_EXIS)
                        {
                            MessageBox.Show("LA EXISTENCIA DEL ARTICULO ES DIFERENTE DE LA REGLA DEL" +
                                " MOTIVO SELECCIONADO: (" + MotivoPedidoModel.NOMBRE + ").", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return false;
                        }
                    }
                    else if (MotivoPedidoModel.PARAMETRO_EXIS.Equals("<>")) // si son iguales no es diferente de (<>)
                    {
                        if (InventarioArt.Existencias == MotivoPedidoModel.VALOR_EXIS)
                        {
                            MessageBox.Show("LA EXISTENCIA DEL ARTICULO ES DIFERENTE DE LA REGLA DEL" +
                                " MOTIVO SELECCIONADO: (" + MotivoPedidoModel.NOMBRE + ").", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return false;
                        }
                    }
                }
                #endregion VALIDAR EXISTENCIA EN CASO DE NO VENIR VACIO
            return true;
        }

        private void InicializaPedido()
        {
            SIFModelo.Sucursal x = Helpers.Sesion.Sucursal;
            if(x.SucursalesID == 13)
            {
                almacen50 = true;
                txtReferencia.Visible = true;
                lblReferencia.Visible = true;
            }
            this.Pedido = this.pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP.NewPEDIDO_TRASPRow();
            this.Pedido.FOLIO = "";
            this.Pedido.ACTIVO = "S";
            this.Pedido.SUCURSAL_GENERA = 0;
            this.Pedido.SUCURSAL_RECIBE = 0;
            this.Pedido.TOTAL = 0;
            this.Pedido.USUARIO_GENERA = "0";
            this.Pedido.USUARIO_RECIBE = "0";
            this.Pedido.LOTE = 0;
        
        }

        private void SeleccionaArticulo()
        {
            SIFModelo.MotivoPedido motivo = cmbMotivoPedido.SelectedItem as SIFModelo.MotivoPedido;
            if (motivo.ID <= 0)
            {
                MessageBox.Show("Debe seleccionar un motivo", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ///FALTA BORRAR LO QUE HAY EN EL GRI Y EN LA VARIABLE GLOBAL PARA QUE SI CAMBIA DE SELECCION
                ///EMPIEZE DE NUEVO
                return;
            }

            View.Articulos.ArticuloUserControl frmArticulo = new Articulos.ArticuloUserControl();

            //if (frmArticulo == null)
            //{
            // frmArticulo = new Articulos.ArticuloUserControl();
            frmArticulo.Dock = DockStyle.Fill;
            frmArticulo.Owner = this;

            //}
            this.cantidadTextBoxX.Text = "1";
            frmArticulo.Muestra();
            //frmArticulo.Owner = this;
            //this.Owner.Owner.ShowModalPanel(frmArticulo, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            //this.DesactivaComandos();
            //frmArticulo.ActivaComandos();
        }

        private void GeneraPorEOQ()
        {
            if (SucursalDestinoComboBox.SelectedItem == null)
            {
               MessageBox.Show("Elija la sucursal destino");
                return;
            }

            if (pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET.Rows.Count > 0)
            {
                if (MessageBoxEx.Show("Los registros existentes serán eliminados, ¿desea continuar?", "EoQ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }


            this.pedidoAlmacenL.PedidosPorEOQ(Helpers.Sesion.Sucursal);
            this.Grd_Pedido.DataSource = pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET;
        }

        public void Back()
        {
            try{
            Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.DesactivaComandos();
            this.Owner.ActivaComandos();
            this.Owner.Buscar();
            Mostrado = false;
            }
            catch { }
        }

        public void DesactivaComandos()
        {

        }

        public PedidosAlmacenUserControl Owner { get; set; }

        private void CodigoTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.SeleccionaArticulo();
        }

        private void agregaProductoButtonItem_Click(object sender, EventArgs e)
        {
            this.SeleccionaArticulo();
        }

        private void PedidoAlmacenUserControl_Load(object sender, EventArgs e)
        {
            this.InicializaPedido();

        }

        private void porEOQButtonItem_Click(object sender, EventArgs e)
        {
            this.GeneraPorEOQ();
        }

        private void cancelarButtonItem_Click(object sender, EventArgs e)
        {
            // this.Cancelar();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void GuardarPedido()
        {
            //AVM validar que halla un motivo seleccionado
            SIFModelo.MotivoPedido motivo = cmbMotivoPedido.SelectedItem as SIFModelo.MotivoPedido;
            if (motivo.ID <= 0)
            {
                MessageBox.Show("Debe seleccionar un motivo", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (SucursalDestinoComboBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Debe seleccionar una sucursal destino", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            this.Pedido.SUCURSAL_GENERA = Helpers.Sesion.Sucursal.SucursalID;
            this.Pedido.SUCURSAL_RECIBE = int.Parse(SucursalDestinoComboBox.SelectedValue.ToString());
            //this.Pedido.TOTAL = int.Parse(label1.Text);
            this.Pedido.USUARIO_GENERA = Helpers.Sesion.Usuario.UsuariosID.ToString();
            this.Pedido.USUARIO_RECIBE = "0";
            this.Pedido.LOTE = tb_LotePedido.Value;            
            this.Pedido.ID_MOTIVO_PEDIDO = motivo.ID;

            this.Pedido.REFERENCIA = txtReferencia.Text;

            int countPedidosDetalle = pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET.Count();

            if (foliotextBoxX.Text == "Nuevo")
                pedidoAlmacenL.InsertaPedidoAlmacen(Helpers.Sesion.Usuario.UsuariosID.ToString(), this.Pedido, pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET);
            else
            {
                this.Pedido.FOLIO = foliotextBoxX.Text;
                pedidoAlmacenL.ActualizaPedidoAlmacen(this.Pedido, pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET);
            }
            this.Back();
        }

        private void guardarButtonItem_Click(object sender, EventArgs e)
        {
            GuardarPedido();
        }

        private void CodigoTextBoxX_Enter(object sender, EventArgs e)
        {
            this.CodigoTextBoxX.SelectAll();
        }

        private void CodigoTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SIFModelo.MotivoPedido motivo = cmbMotivoPedido.SelectedItem as SIFModelo.MotivoPedido;
                if (motivo.ID <= 0)
                {
                    MessageBox.Show("Debe seleccionar un motivo", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ///FALTA BORRAR LO QUE HAY EN EL GRI Y EN LA VARIABLE GLOBAL PARA QUE SI CAMBIA DE SELECCION
                    ///EMPIEZE DE NUEVO
                    return;
                }

                this.AgregaA(CodigoTextBoxX.Text);
                this.CodigoTextBoxX.SelectAll();
            }

            if (e.KeyCode == Keys.F3)
            {
                this.SeleccionaArticulo();
            }
        }

        private void CodigoTextBoxX_KeyUp(object sender, KeyEventArgs e)//L 27/11/2013 MOSTRAR DESCRIPCION MIENTRAS SE VA CAPTURANDO EAN
        {
            if (
                ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) ||
                  (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                  (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                )
               )
            {
                //MessageBox.Show((char)e.KeyValue+" "+(char)e.KeyData+" "+(char)e.KeyCode+" "+sender.ToString());
                //CodigoTextBoxX.Text += (char)e.KeyValue;
                SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
                //MessageBox.Show("-" + CodigoTextBoxX.Text + "% ");
                if (articuloL.BuscarPorClave(CodigoTextBoxX.Text + "%") == null)
                {
                    //MessageBox.Show("nulo: ");
                    descripcionLabel.Text = "Código no encontrado";
                }
                else
                {
                    SIFModelo.Articulo articulo = articuloL.BuscarPorClave(CodigoTextBoxX.Text + "%");
                    //MessageBox.Show("NO nulo: " + articulo.NOMBRE1 + "-");
                    descripcionLabel.Text = articulo.NOMBRE1;
                }
            }
        }

        private void Grd_Pedido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            Grd_Pedido.Rows[e.RowIndex].ErrorText = string.Empty;
           // _celWasEndEdit = Grd_Pedido[e.ColumnIndex, e.RowIndex];
            this.modificaCantidad(Grd_Pedido[2, e.RowIndex].Value.ToString());
            
            CodigoTextBoxX.Focus();//L 28/11/2013 al editar la celda, regresa el focus a captura EAN


        }

        private void cantidadTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaArticulo(CodigoTextBoxX.Text);
            }
        }

        private void Grd_Pedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) // && _celWasEndEdit == null)
            {
                // ROMA 13AGO2013
                e.SuppressKeyPress = true;
                string rowID = string.Empty;
                string msg = string.Empty;
                if (Grd_Pedido.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in Grd_Pedido.SelectedRows)
                    {
                        try
                        {
                            msg = row.Cells["ARTICULO_IDColumn"].Value.ToString() + " - " + row.Cells["NOMBRE1Column"].Value.ToString();
                            rowID = row.Cells["ARTICULO_IDColumn"].Value.ToString();
                            if (MessageBoxEx.Show("¿Borrar el registro " + msg + "?", ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                //pedidoAlmacenL.AgregaDetalle(rowDetalle, pedidoAlmacenL.PedidosDataSet);
                                //                                pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET.RemovePEDIDO_TRASP_DETRow();
                                var encontrado = from r in pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET where r.ARTICULO_ID == rowID select r;

                                if (encontrado.Count() > 0)
                                {
                                    SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow contenido = encontrado.FirstOrDefault<SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow>();
                                    int x = contenido.PARTIDA;
                                    pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET.RemovePEDIDO_TRASP_DETRow(contenido);
                                    int i = 0;
                                    foreach (var item in pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET)
                                    {
                                        
                                        if (item.PARTIDA > (x - 1))
                                        {
                                            item.PARTIDA = short.Parse((x + i).ToString());
                                            i++;
                                        }
                                    }

                                    label1.Text = pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET.Compute("Sum(CANTIDAD_SOLIC)", "").ToString();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                           MessageBox.Show(ex.ToString() + System.Environment.NewLine, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                // ROMA 13AGO2013
            }
        }

        private void cmbMotivoPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            SIFModelo.MotivoPedido MotivoPedidoModel = cmbMotivoPedido.SelectedItem as SIFModelo.MotivoPedido;

            DateTime toDay = DateTime.Now;
            if (SIFNegocio.Pedidos.PedidosLimiteHoy(toDay.ToString("dd/MM/yy"), MotivoPedidoModel))
            {
                if (NoPedido == null)
                {
                    MessageBox.Show("Se ha alcanzado el número máximo de pedidos (" + MotivoPedidoModel.CANTIDAD_PEDIDO_MAX_DIA +
                                    "). Segun el tipo de pedido: " + MotivoPedidoModel.NOMBRE);
                    cmbMotivoPedido.SelectedIndex = 0;
                }
            }  
        }

    }
}
       