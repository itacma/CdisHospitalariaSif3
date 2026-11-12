namespace SIF.View.Menu
{
    partial class ComprasMenu
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroTilePanel1 = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.generaOrdenCompraMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.consultaOCMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.recepcionComprasMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.metroTileItem31 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ajusteInventarioMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ofertasComprasMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.facturasMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.ofertasMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.subrogacionMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.NotasCreditoMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ReportesAdminMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.tipoMedicamentoComprasMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ofertasProveedorMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem3 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem6 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.manejoDescuentosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // titlelabelX
            // 
            // 
            // 
            // 
            this.titlelabelX.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.titlelabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.titlelabelX.Text = "<font  color = \"#2E6BFA\">Farmacias Fleming</font>";
            // 
            // salirButton
            // 
            this.salirButton.Click += new System.EventHandler(this.salirButton_Click);
            // 
            // subMenuLabelX
            // 
            // 
            // 
            // 
            this.subMenuLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.subMenuLabelX.Location = new System.Drawing.Point(63, 64);
            this.subMenuLabelX.Text = "<font  color = \"#2E619D\">Compras</font>";
            // 
            // metroTilePanel1
            // 
            this.metroTilePanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.metroTilePanel1.BackgroundStyle.Class = "MetroTilePanel";
            this.metroTilePanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTilePanel1.ContainerControlProcessDialogKey = true;
            this.metroTilePanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1,
            this.itemContainer2,
            this.itemContainer3});
            this.metroTilePanel1.ItemSpacing = 5;
            this.metroTilePanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.metroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroTilePanel1.Location = new System.Drawing.Point(200, 110);
            this.metroTilePanel1.Name = "metroTilePanel1";
            this.metroTilePanel1.Size = new System.Drawing.Size(615, 580);
            this.metroTilePanel1.TabIndex = 0;
            this.metroTilePanel1.Text = "metroTilePanel1";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.ItemSpacing = 5;
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.generaOrdenCompraMetroTileItem,
            this.consultaOCMetroTileItem,
            this.recepcionComprasMetroTileItem,
            this.metroTileItem1});
            // 
            // generaOrdenCompraMetroTileItem
            // 
            this.generaOrdenCompraMetroTileItem.Image = global::SIF.Properties.Resources.Box_Software;
            this.generaOrdenCompraMetroTileItem.Name = "generaOrdenCompraMetroTileItem";
            this.generaOrdenCompraMetroTileItem.Tag = "10";
            this.generaOrdenCompraMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.PlumWashed;
            this.generaOrdenCompraMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.generaOrdenCompraMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.generaOrdenCompraMetroTileItem.TitleText = "Genera Orden\r\nde Compra";
            this.generaOrdenCompraMetroTileItem.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.generaOrdenCompraMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generaOrdenCompraMetroTileItem.Click += new System.EventHandler(this.generaOrdenCompraMetroTileItem_Click);
            // 
            // consultaOCMetroTileItem
            // 
            this.consultaOCMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.consultaOCMetroTileItem.Image = global::SIF.Properties.Resources.BoxConsulta;
            this.consultaOCMetroTileItem.Name = "consultaOCMetroTileItem";
            this.consultaOCMetroTileItem.Tag = "13";
            this.consultaOCMetroTileItem.Text = "Consulta Ordenes Compra";
            this.consultaOCMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange;
            this.consultaOCMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.consultaOCMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.consultaOCMetroTileItem.TitleText = "Consulta \r\nOrden Compra";
            this.consultaOCMetroTileItem.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.consultaOCMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.consultaOCMetroTileItem.Click += new System.EventHandler(this.consultaOCMetroTileItem_Click);
            // 
            // recepcionComprasMetroTileItem
            // 
            this.recepcionComprasMetroTileItem.Image = global::SIF.Properties.Resources.Box_add;
            this.recepcionComprasMetroTileItem.Name = "recepcionComprasMetroTileItem";
            this.recepcionComprasMetroTileItem.Tag = "11";
            this.recepcionComprasMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure;
            this.recepcionComprasMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.recepcionComprasMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.recepcionComprasMetroTileItem.TitleText = "Recepción Compras";
            this.recepcionComprasMetroTileItem.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.recepcionComprasMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recepcionComprasMetroTileItem.Click += new System.EventHandler(this.recepcionComprasMetroTileItem_Click);
            // 
            // metroTileItem1
            // 
            this.metroTileItem1.Image = global::SIF.Properties.Resources.Money_transfer;
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.Tag = "12";
            this.metroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem1.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem1.TitleText = "Asignación de Precios";
            this.metroTileItem1.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTileItem1.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTileItem1.Click += new System.EventHandler(this.metroTileItem1_Click);
            // 
            // itemContainer2
            // 
            // 
            // 
            // 
            this.itemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer2.ItemSpacing = 5;
            this.itemContainer2.MultiLine = true;
            this.itemContainer2.Name = "itemContainer2";
            this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.metroTileItem31,
            this.ajusteInventarioMetroTileItem,
            this.ofertasComprasMetroTileItem,
            this.facturasMetroTileItem});
            // 
            // metroTileItem31
            // 
            this.metroTileItem31.Image = global::SIF.Properties.Resources.bonificacion;
            this.metroTileItem31.Name = "metroTileItem31";
            this.metroTileItem31.Tag = "14";
            this.metroTileItem31.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkGreen;
            this.metroTileItem31.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem31.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem31.TitleText = "Bonificacion \r\n Reposicion\r\n Dev a Proveedor";
            this.metroTileItem31.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTileItem31.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTileItem31.Click += new System.EventHandler(this.metroTileItem31_Click);
            // 
            // ajusteInventarioMetroTileItem
            // 
            this.ajusteInventarioMetroTileItem.Image = global::SIF.Properties.Resources.Replace_Data;
            this.ajusteInventarioMetroTileItem.Name = "ajusteInventarioMetroTileItem";
            this.ajusteInventarioMetroTileItem.Tag = "16";
            this.ajusteInventarioMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Gray;
            this.ajusteInventarioMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ajusteInventarioMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ajusteInventarioMetroTileItem.TitleText = "Ajustes al inventario";
            this.ajusteInventarioMetroTileItem.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.ajusteInventarioMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ajusteInventarioMetroTileItem.Click += new System.EventHandler(this.ajusteInventarioMetroTileItem_Click);
            // 
            // ofertasComprasMetroTileItem
            // 
            this.ofertasComprasMetroTileItem.Image = global::SIF.Properties.Resources.Discount;
            this.ofertasComprasMetroTileItem.ImageTextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.ofertasComprasMetroTileItem.Name = "ofertasComprasMetroTileItem";
            this.ofertasComprasMetroTileItem.Tag = "17";
            this.ofertasComprasMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Plum;
            this.ofertasComprasMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ofertasComprasMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ofertasComprasMetroTileItem.TitleText = "Ofertas CAMPAÑA";
            this.ofertasComprasMetroTileItem.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.ofertasComprasMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ofertasComprasMetroTileItem.Click += new System.EventHandler(this.manejoDescuentosMetroTileItem_Click);
            // 
            // facturasMetroTileItem
            // 
            this.facturasMetroTileItem.Image = global::SIF.Properties.Resources.Factura;
            this.facturasMetroTileItem.ImageTextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.facturasMetroTileItem.Name = "facturasMetroTileItem";
            this.facturasMetroTileItem.Tag = "18";
            this.facturasMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Coffee;
            this.facturasMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.facturasMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.facturasMetroTileItem.TitleText = "Facturas\r\n";
            this.facturasMetroTileItem.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.facturasMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facturasMetroTileItem.Click += new System.EventHandler(this.facturasMetroTileItem_Click);
            // 
            // itemContainer3
            // 
            // 
            // 
            // 
            this.itemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer3.ItemSpacing = 5;
            this.itemContainer3.MultiLine = true;
            this.itemContainer3.Name = "itemContainer3";
            this.itemContainer3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ofertasMetroTileItem,
            this.subrogacionMetroTileItem,
            this.ReportesAdminMetroTileItem,
            this.NotasCreditoMetroTileItem/*,
            this.tipoMedicamentoComprasMetroTileItem,
            this.ofertasProveedorMetroTileItem*/});
            // 
            // ofertasMetroTileItem
            // 
            this.ofertasMetroTileItem.Image = global::SIF.Properties.Resources.Box_Software;
            this.ofertasMetroTileItem.Name = "ofertasMetroTileItem";
            this.ofertasMetroTileItem.Tag = "19";
            this.ofertasMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.PlumWashed;
            this.ofertasMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ofertasMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ofertasMetroTileItem.TitleText = "Ofertas";
            this.ofertasMetroTileItem.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.ofertasMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ofertasMetroTileItem.Click += new System.EventHandler(this.ofertasMetroTileItem_Click);
            // 
            // subrogacionMetroTileItem
            // 
            this.subrogacionMetroTileItem.Image = global::SIF.Properties.Resources.Scale;
            this.subrogacionMetroTileItem.Name = "subrogacionMetroTileItem";
            this.subrogacionMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish;
            this.subrogacionMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.subrogacionMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.subrogacionMetroTileItem.TitleText = "Subrogación";
            this.subrogacionMetroTileItem.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.subrogacionMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subrogacionMetroTileItem.Click += new System.EventHandler(this.subrogacionMetroTileItem_Click);


            // 
            // NotasCreditoMetroTileItem
            // 
            this.NotasCreditoMetroTileItem.Image = global::SIF.Properties.Resources.Money_transfer;
            this.NotasCreditoMetroTileItem.Name = "NotasCreditoMetroTileItem";
            this.NotasCreditoMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkGreen;
            this.NotasCreditoMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.NotasCreditoMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NotasCreditoMetroTileItem.TitleText = "Notas\n\rCredito Provedor";
            this.NotasCreditoMetroTileItem.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.NotasCreditoMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotasCreditoMetroTileItem.Click += new System.EventHandler(this.NotasCreditoMetroTileItem_Click);

            // 
            // ReportesAdminMetroTileItem
            // 
            this.ReportesAdminMetroTileItem.Image = global::SIF.Properties.Resources.ConsultaWS;
            this.ReportesAdminMetroTileItem.Name = "ReportesAdminMetroTileItem";
            this.ReportesAdminMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish;
            this.ReportesAdminMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ReportesAdminMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ReportesAdminMetroTileItem.TitleText = "Reporte de Ventas";
            this.ReportesAdminMetroTileItem.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.ReportesAdminMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportesAdminMetroTileItem.Click += new System.EventHandler(this.ReportesAdminMetroTileItem_Click);
            // 
            // tipoMedicamentoComprasMetroTileItem
            // 
            this.tipoMedicamentoComprasMetroTileItem.Image = global::SIF.Properties.Resources.CAT_TIPO_MEDICAMENTO1;
            this.tipoMedicamentoComprasMetroTileItem.Name = "tipoMedicamentoComprasMetroTileItem";
            this.tipoMedicamentoComprasMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal;
            this.tipoMedicamentoComprasMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.tipoMedicamentoComprasMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tipoMedicamentoComprasMetroTileItem.TitleText = "Tipo Medicamento";
            this.tipoMedicamentoComprasMetroTileItem.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.tipoMedicamentoComprasMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoMedicamentoComprasMetroTileItem.Click += new System.EventHandler(this.tipoMedicamentoComprasMetroTileItem_Click);
            // 
            // ofertasProveedorMetroTileItem
            // 
            this.ofertasProveedorMetroTileItem.Image = global::SIF.Properties.Resources.CAT_DESCUENTOS;
            this.ofertasProveedorMetroTileItem.Name = "ofertasProveedorMetroTileItem";
            this.ofertasProveedorMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.MaroonWashed;
            this.ofertasProveedorMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ofertasProveedorMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ofertasProveedorMetroTileItem.TitleText = "Ofertas Proveedor";
            this.ofertasProveedorMetroTileItem.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.ofertasProveedorMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ofertasProveedorMetroTileItem.Click += new System.EventHandler(this.ofertasProveedorMetroTileItem_Click);
            // 
            // metroTileItem3
            // 
            this.metroTileItem3.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem3.Enabled = false;
            this.metroTileItem3.Name = "metroTileItem3";
            this.metroTileItem3.Text = " ";
            this.metroTileItem3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem3.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem3.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // metroTileItem6
            // 
            this.metroTileItem6.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem6.Enabled = false;
            this.metroTileItem6.Name = "metroTileItem6";
            this.metroTileItem6.Text = " ";
            this.metroTileItem6.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem6.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem6.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // manejoDescuentosMetroTileItem
            // 
            this.manejoDescuentosMetroTileItem.Image = global::SIF.Properties.Resources.descto;
            this.manejoDescuentosMetroTileItem.Name = "manejoDescuentosMetroTileItem";
            this.manejoDescuentosMetroTileItem.Tag = "15";
            this.manejoDescuentosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellowish;
            this.manejoDescuentosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.manejoDescuentosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.manejoDescuentosMetroTileItem.TitleText = "Manejo de descuentos";
            this.manejoDescuentosMetroTileItem.TitleTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.manejoDescuentosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manejoDescuentosMetroTileItem.Click += new System.EventHandler(this.manejoDescuentosMetroTileItem_Click);
            // 
            // ComprasMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTilePanel1);
            this.Location = new System.Drawing.Point(55, 0);
            this.Name = "ComprasMenu";
            this.Controls.SetChildIndex(this.salirButton, 0);
            this.Controls.SetChildIndex(this.subMenuLabelX, 0);
            this.Controls.SetChildIndex(this.titlelabelX, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.Controls.SetChildIndex(this.metroTilePanel1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem recepcionComprasMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem generaOrdenCompraMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem31;
        private DevComponents.DotNetBar.Metro.MetroTileItem ajusteInventarioMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem1;
        private DevComponents.DotNetBar.ItemContainer itemContainer2;
        private DevComponents.DotNetBar.Metro.MetroTileItem consultaOCMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem facturasMetroTileItem;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem3;
        private DevComponents.DotNetBar.Metro.MetroTileItem ofertasMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem subrogacionMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem NotasCreditoMetroTileItem;

        private DevComponents.DotNetBar.Metro.MetroTileItem ReportesAdminMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem ofertasComprasMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem6;
        private DevComponents.DotNetBar.Metro.MetroTileItem manejoDescuentosMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem tipoMedicamentoComprasMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem ofertasProveedorMetroTileItem;
    }
}
