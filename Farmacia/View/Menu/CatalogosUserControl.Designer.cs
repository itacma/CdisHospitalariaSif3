namespace SIF.View.Menu
{
    partial class CatalogosUserControl
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
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.monedasMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.bancosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.catValesDevMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.tipoDevolucionMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.tipoMovInventarioMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.especialidadMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.tipoCambioMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.descuentosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.impuestosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.tipoClienteMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.catalogosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ClientesConvenio = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem2 = new DevComponents.DotNetBar.Metro.MetroTileItem();
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
            // subMenuLabelX
            // 
            // 
            // 
            // 
            this.subMenuLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.subMenuLabelX.Text = "<font  color = \"#2E619D\">Catálogos</font>";
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
            this.metroTilePanel1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.metroTilePanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer3});
            this.metroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroTilePanel1.Location = new System.Drawing.Point(80, 131);
            this.metroTilePanel1.Name = "metroTilePanel1";
            this.metroTilePanel1.Size = new System.Drawing.Size(819, 580);
            this.metroTilePanel1.TabIndex = 24;
            this.metroTilePanel1.Text = "metroTilePanel1";
            // 
            // itemContainer3
            // 
            // 
            // 
            // 
            this.itemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer3.ItemSpacing = 5;
            this.itemContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer3.MultiLine = true;
            this.itemContainer3.Name = "itemContainer3";
            this.itemContainer3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.monedasMetroTileItem,
            this.bancosMetroTileItem,
            this.catValesDevMetroTileItem,
            this.tipoDevolucionMetroTileItem,
            this.tipoMovInventarioMetroTileItem,
            this.especialidadMetroTileItem,
            this.tipoCambioMetroTileItem,
            this.descuentosMetroTileItem,
            this.impuestosMetroTileItem,
            this.tipoClienteMetroTileItem,
            this.catalogosMetroTileItem,
            this.ClientesConvenio});
            // 
            // monedasMetroTileItem
            // 
            this.monedasMetroTileItem.Image = global::SIF.Properties.Resources.monedas;
            this.monedasMetroTileItem.Name = "monedasMetroTileItem";
            this.monedasMetroTileItem.Tag = "51";
            this.monedasMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkGreen;
            this.monedasMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.monedasMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.monedasMetroTileItem.TitleText = "Monedas";
            this.monedasMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monedasMetroTileItem.Click += new System.EventHandler(this.monedasMetroTileItem_Click);
            // 
            // bancosMetroTileItem
            // 
            this.bancosMetroTileItem.Image = global::SIF.Properties.Resources.CAT_BANCOS;
            this.bancosMetroTileItem.Name = "bancosMetroTileItem";
            this.bancosMetroTileItem.Tag = "55";
            this.bancosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet;
            this.bancosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.bancosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.bancosMetroTileItem.TitleText = "Bancos";
            this.bancosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bancosMetroTileItem.Click += new System.EventHandler(this.bancosMetroTileItem_Click);
            // 
            // catValesDevMetroTileItem
            // 
            this.catValesDevMetroTileItem.Image = global::SIF.Properties.Resources.CAT_VALES_DEV;
            this.catValesDevMetroTileItem.Name = "catValesDevMetroTileItem";
            this.catValesDevMetroTileItem.Tag = "58";
            this.catValesDevMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange;
            this.catValesDevMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.catValesDevMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.catValesDevMetroTileItem.TitleText = "Vales Devolución";
            this.catValesDevMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.catValesDevMetroTileItem.Click += new System.EventHandler(this.catValesDevMetroTileItem_Click);
            // 
            // tipoDevolucionMetroTileItem
            // 
            this.tipoDevolucionMetroTileItem.Image = global::SIF.Properties.Resources.CAT_TIPO_DEVOLUCION;
            this.tipoDevolucionMetroTileItem.Name = "tipoDevolucionMetroTileItem";
            this.tipoDevolucionMetroTileItem.Tag = "52";
            this.tipoDevolucionMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Olive;
            this.tipoDevolucionMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.tipoDevolucionMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tipoDevolucionMetroTileItem.TitleText = "Tipo Devolución";
            this.tipoDevolucionMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoDevolucionMetroTileItem.Click += new System.EventHandler(this.tipoDevolucionMetroTileItem_Click);
            // 
            // tipoMovInventarioMetroTileItem
            // 
            this.tipoMovInventarioMetroTileItem.Image = global::SIF.Properties.Resources.CAT_TIPO_MOV_INV;
            this.tipoMovInventarioMetroTileItem.Name = "tipoMovInventarioMetroTileItem";
            this.tipoMovInventarioMetroTileItem.Tag = "56";
            this.tipoMovInventarioMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue;
            this.tipoMovInventarioMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.tipoMovInventarioMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tipoMovInventarioMetroTileItem.TitleText = "Tipo Movimientos Inventario";
            this.tipoMovInventarioMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoMovInventarioMetroTileItem.Click += new System.EventHandler(this.tipoMovInventarioMetroTileItem_Click);
            // 
            // especialidadMetroTileItem
            // 
            this.especialidadMetroTileItem.Image = global::SIF.Properties.Resources.CAT_ESPECIALIDAD;
            this.especialidadMetroTileItem.Name = "especialidadMetroTileItem";
            this.especialidadMetroTileItem.Tag = "59";
            this.especialidadMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Rust;
            this.especialidadMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.especialidadMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.especialidadMetroTileItem.TitleText = "Especialidad";
            this.especialidadMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.especialidadMetroTileItem.Click += new System.EventHandler(this.especialidadMetroTileItem_Click);
            // 
            // tipoCambioMetroTileItem
            // 
            this.tipoCambioMetroTileItem.Image = global::SIF.Properties.Resources.tipodecambio;
            this.tipoCambioMetroTileItem.Name = "tipoCambioMetroTileItem";
            this.tipoCambioMetroTileItem.Tag = "53";
            this.tipoCambioMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure;
            this.tipoCambioMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.tipoCambioMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tipoCambioMetroTileItem.TitleText = "Tipo Cambio";
            this.tipoCambioMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoCambioMetroTileItem.Click += new System.EventHandler(this.tipoCambioMetroTileItem_Click);
            // 
            // descuentosMetroTileItem
            // 
            this.descuentosMetroTileItem.Image = global::SIF.Properties.Resources.CAT_DESCUENTOS;
            this.descuentosMetroTileItem.Name = "descuentosMetroTileItem";
            this.descuentosMetroTileItem.Tag = "57";
            this.descuentosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkOlive;
            this.descuentosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.descuentosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.descuentosMetroTileItem.TitleText = "Descuentos";
            this.descuentosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descuentosMetroTileItem.Click += new System.EventHandler(this.descuentosMetroTileItem_Click);
            // 
            // impuestosMetroTileItem
            // 
            this.impuestosMetroTileItem.Image = global::SIF.Properties.Resources.impuestos;
            this.impuestosMetroTileItem.Name = "impuestosMetroTileItem";
            this.impuestosMetroTileItem.Tag = "60";
            this.impuestosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.PlumWashed;
            this.impuestosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.impuestosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.impuestosMetroTileItem.TitleText = "Impuestos";
            this.impuestosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.impuestosMetroTileItem.Click += new System.EventHandler(this.impuestosMetroTileItem_Click);
            // 
            // tipoClienteMetroTileItem
            // 
            this.tipoClienteMetroTileItem.Image = global::SIF.Properties.Resources.tipodecliente;
            this.tipoClienteMetroTileItem.Name = "tipoClienteMetroTileItem";
            this.tipoClienteMetroTileItem.Tag = "54";
            this.tipoClienteMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish;
            this.tipoClienteMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.tipoClienteMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tipoClienteMetroTileItem.TitleText = "Tipo Cliente";
            this.tipoClienteMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoClienteMetroTileItem.Click += new System.EventHandler(this.tipoClienteMetroTileItem_Click);
            // 
            // catalogosMetroTileItem
            // 
            this.catalogosMetroTileItem.Image = global::SIF.Properties.Resources.AcercaDe;
            this.catalogosMetroTileItem.Name = "catalogosMetroTileItem";
            this.catalogosMetroTileItem.Tag = "9";
            this.catalogosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.catalogosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.catalogosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.catalogosMetroTileItem.TitleText = "Seguridad";
            this.catalogosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.catalogosMetroTileItem.Click += new System.EventHandler(this.catalogosMetroTileItem_Click);
            // 
            // ClientesConvenio
            // 
            this.ClientesConvenio.Image = global::SIF.Properties.Resources.ShieldUser;
            this.ClientesConvenio.Name = "ClientesConvenio";
            this.ClientesConvenio.Tag = "60";
            this.ClientesConvenio.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal;
            this.ClientesConvenio.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ClientesConvenio.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ClientesConvenio.TitleText = "Clientes Convenio";
            this.ClientesConvenio.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.ClientesConvenio.Click += new System.EventHandler(this.ClientesConvenio_Click);
            // 
            // metroTileItem1
            // 
            this.metroTileItem1.Image = global::SIF.Properties.Resources.impuestos;
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.Tag = "60";
            this.metroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.PlumWashed;
            this.metroTileItem1.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem1.TitleText = "Impuestos";
            this.metroTileItem1.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroTileItem2
            // 
            this.metroTileItem2.Image = global::SIF.Properties.Resources.impuestos;
            this.metroTileItem2.Name = "metroTileItem2";
            this.metroTileItem2.Tag = "60";
            this.metroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.PlumWashed;
            this.metroTileItem2.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem2.TitleText = "Impuestos";
            this.metroTileItem2.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // CatalogosUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTilePanel1);
            this.Name = "CatalogosUserControl";
            this.Controls.SetChildIndex(this.titlelabelX, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.Controls.SetChildIndex(this.salirButton, 0);
            this.Controls.SetChildIndex(this.subMenuLabelX, 0);
            this.Controls.SetChildIndex(this.metroTilePanel1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        private DevComponents.DotNetBar.Metro.MetroTileItem monedasMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem bancosMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem catValesDevMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem tipoDevolucionMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem tipoMovInventarioMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem especialidadMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem descuentosMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem impuestosMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem tipoCambioMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem tipoClienteMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem catalogosMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem ClientesConvenio;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem1;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem2;
    }
}
