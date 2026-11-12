namespace SIF.View.Menu
{
    partial class ConfiguracionMenu
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
            this.sucursalesMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.cajasMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.clientesMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.productosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.tipoPagoMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem44 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.medicosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.proveedorMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.laboratoriosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.tipoMedicamentoMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.catalogosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
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
            this.subMenuLabelX.Size = new System.Drawing.Size(819, 40);
            this.subMenuLabelX.Text = "<font  color = \"#2E619D\"> Configuración del Sistema </font>";
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
            this.itemContainer1});
            this.metroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroTilePanel1.Location = new System.Drawing.Point(63, 110);
            this.metroTilePanel1.Name = "metroTilePanel1";
            this.metroTilePanel1.Size = new System.Drawing.Size(819, 580);
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
            this.itemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.sucursalesMetroTileItem,
            this.cajasMetroTileItem,
            this.clientesMetroTileItem,
            this.productosMetroTileItem,
            this.tipoPagoMetroTileItem,
            this.metroTileItem44,
            this.medicosMetroTileItem,
            this.proveedorMetroTileItem,
            this.laboratoriosMetroTileItem,
            this.tipoMedicamentoMetroTileItem,
            this.catalogosMetroTileItem,
            this.metroTileItem2});
            // 
            // sucursalesMetroTileItem
            // 
            this.sucursalesMetroTileItem.Image = global::SIF.Properties.Resources.Sucursales;
            this.sucursalesMetroTileItem.Name = "sucursalesMetroTileItem";
            this.sucursalesMetroTileItem.Tag = "40";
            this.sucursalesMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Maroon;
            this.sucursalesMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.sucursalesMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sucursalesMetroTileItem.TitleText = "Sucursales";
            this.sucursalesMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sucursalesMetroTileItem.Click += new System.EventHandler(this.sucursalesMetroTileItem_Click);
            // 
            // cajasMetroTileItem
            // 
            this.cajasMetroTileItem.Image = global::SIF.Properties.Resources.Cajas;
            this.cajasMetroTileItem.Name = "cajasMetroTileItem";
            this.cajasMetroTileItem.Tag = "44";
            this.cajasMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Rust;
            this.cajasMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.cajasMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cajasMetroTileItem.TitleText = "Cajas";
            this.cajasMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cajasMetroTileItem.Click += new System.EventHandler(this.cajasMetroTileItem_Click);
            // 
            // clientesMetroTileItem
            // 
            this.clientesMetroTileItem.Image = global::SIF.Properties.Resources.clientes;
            this.clientesMetroTileItem.Name = "clientesMetroTileItem";
            this.clientesMetroTileItem.Tag = "48";
            this.clientesMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkOlive;
            this.clientesMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.clientesMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.clientesMetroTileItem.TitleText = "Clientes";
            this.clientesMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientesMetroTileItem.Click += new System.EventHandler(this.clientesMetroTileItem_Click);
            // 
            // productosMetroTileItem
            // 
            this.productosMetroTileItem.Image = global::SIF.Properties.Resources.Productos;
            this.productosMetroTileItem.Name = "productosMetroTileItem";
            this.productosMetroTileItem.Tag = "41";
            this.productosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Olive;
            this.productosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.productosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.productosMetroTileItem.TitleText = "Productos";
            this.productosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productosMetroTileItem.Click += new System.EventHandler(this.productosMetroTileItem_Click);
            // 
            // tipoPagoMetroTileItem
            // 
            this.tipoPagoMetroTileItem.Image = global::SIF.Properties.Resources.TipoPago;
            this.tipoPagoMetroTileItem.Name = "tipoPagoMetroTileItem";
            this.tipoPagoMetroTileItem.Tag = "45";
            this.tipoPagoMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet;
            this.tipoPagoMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.tipoPagoMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tipoPagoMetroTileItem.TitleText = "Tipo de Pago";
            this.tipoPagoMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoPagoMetroTileItem.Click += new System.EventHandler(this.tipoPagoMetroTileItem_Click);
            // 
            // metroTileItem44
            // 
            this.metroTileItem44.Image = global::SIF.Properties.Resources.ubicaciones;
            this.metroTileItem44.Name = "metroTileItem44";
            this.metroTileItem44.Tag = "42";
            this.metroTileItem44.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Plum;
            this.metroTileItem44.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem44.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem44.TitleText = "Ubicaciones";
            this.metroTileItem44.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTileItem44.Click += new System.EventHandler(this.metroTileItem44_Click);
            // 
            // medicosMetroTileItem
            // 
            this.medicosMetroTileItem.Image = global::SIF.Properties.Resources.Medicos;
            this.medicosMetroTileItem.Name = "medicosMetroTileItem";
            this.medicosMetroTileItem.Tag = "46";
            this.medicosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal;
            this.medicosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.medicosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.medicosMetroTileItem.TitleText = "Médicos";
            this.medicosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.medicosMetroTileItem.Click += new System.EventHandler(this.medicosMetroTileItem_Click);
            // 
            // proveedorMetroTileItem
            // 
            this.proveedorMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.proveedorMetroTileItem.Image = global::SIF.Properties.Resources.tipodecliente;
            this.proveedorMetroTileItem.Name = "proveedorMetroTileItem";
            this.proveedorMetroTileItem.Tag = "43";
            this.proveedorMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal;
            this.proveedorMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.proveedorMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.proveedorMetroTileItem.TitleText = "Proveedores";
            this.proveedorMetroTileItem.Click += new System.EventHandler(this.proveedorMetroTileItem_Click);
            // 
            // laboratoriosMetroTileItem
            // 
            this.laboratoriosMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.laboratoriosMetroTileItem.Image = global::SIF.Properties.Resources.tipodecliente;
            this.laboratoriosMetroTileItem.Name = "laboratoriosMetroTileItem";
            this.laboratoriosMetroTileItem.Tag = "43";
            this.laboratoriosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal;
            this.laboratoriosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.laboratoriosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.laboratoriosMetroTileItem.TitleText = "Laboratorios";
            this.laboratoriosMetroTileItem.Click += new System.EventHandler(this.laboratoriosMetroTileItem_Click);
            // 
            // tipoMedicamentoMetroTileItem
            // 
            this.tipoMedicamentoMetroTileItem.Image = global::SIF.Properties.Resources.CAT_TIPO_MEDICAMENTO;
            this.tipoMedicamentoMetroTileItem.Name = "tipoMedicamentoMetroTileItem";
            this.tipoMedicamentoMetroTileItem.Tag = "47";
            this.tipoMedicamentoMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.MaroonWashed;
            this.tipoMedicamentoMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.tipoMedicamentoMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tipoMedicamentoMetroTileItem.TitleText = "Tipo Medicamento";
            this.tipoMedicamentoMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoMedicamentoMetroTileItem.Click += new System.EventHandler(this.tipoMedicamentoMetroTileItem_Click);
            // 
            // catalogosMetroTileItem
            // 
            this.catalogosMetroTileItem.Image = global::SIF.Properties.Resources.AcercaDe;
            this.catalogosMetroTileItem.Name = "catalogosMetroTileItem";
            this.catalogosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.catalogosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.catalogosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.catalogosMetroTileItem.TitleText = "Catálogos";
            this.catalogosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.catalogosMetroTileItem.Click += new System.EventHandler(this.catalogosMetroTileItem_Click);
            // 
            // metroTileItem2
            // 
            this.metroTileItem2.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem2.Enabled = false;
            this.metroTileItem2.Name = "metroTileItem2";
            this.metroTileItem2.Tag = "23";
            this.metroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem2.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem2.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // ConfiguracionMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTilePanel1);
            this.Name = "ConfiguracionMenu";
            this.Load += new System.EventHandler(this.ConfiguracionMenu_Load);
            this.Controls.SetChildIndex(this.metroTilePanel1, 0);
            this.Controls.SetChildIndex(this.titlelabelX, 0);
            this.Controls.SetChildIndex(this.subMenuLabelX, 0);
            this.Controls.SetChildIndex(this.salirButton, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem sucursalesMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem cajasMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem clientesMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem productosMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem tipoPagoMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem44;
        private DevComponents.DotNetBar.Metro.MetroTileItem medicosMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem proveedorMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem tipoMedicamentoMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem catalogosMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem laboratoriosMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem2;
    }
}
