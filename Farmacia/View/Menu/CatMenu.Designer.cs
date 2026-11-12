namespace SIF.View.Menu
{
    partial class CatMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatMenu));
            this.metroTilePanel1 = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.generaCotizacionMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.citasDermaMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.quejaSugerenciaMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.metroTileItem6 =new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem2 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem3 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ventaPedidosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem4 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.EnvioMarketingMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem5 = new DevComponents.DotNetBar.Metro.MetroTileItem();
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
            this.subMenuLabelX.Location = new System.Drawing.Point(63, 55);
            this.subMenuLabelX.Text = "<font  color = \"#2E619D\">CAC Call Center</font>";
            // 
            // metroTilePanel1
            // 
            this.metroTilePanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroTilePanel1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.metroTilePanel1.BackgroundStyle.Class = "MetroTilePanel";
            this.metroTilePanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTilePanel1.ContainerControlProcessDialogKey = true;
            this.metroTilePanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer2,
            this.itemContainer1,
            this.itemContainer3});
            this.metroTilePanel1.ItemSpacing = 5;
            this.metroTilePanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.metroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroTilePanel1.Location = new System.Drawing.Point(275, 109);
            this.metroTilePanel1.Name = "metroTilePanel1";
            this.metroTilePanel1.Size = new System.Drawing.Size(462, 478);
            this.metroTilePanel1.TabIndex = 0;
            this.metroTilePanel1.Text = "metroTilePanel1";
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
            this.generaCotizacionMetroTileItem,
            this.citasDermaMetroTileItem,this.EnvioMarketingMetroTileItem}
            );
            // 
            // generaCotizacionMetroTileItem
            // 
            this.generaCotizacionMetroTileItem.Image = global::SIF.Properties.Resources.TagCAT;
            this.generaCotizacionMetroTileItem.Name = "generaCotizacionMetroTileItem";
            this.generaCotizacionMetroTileItem.Tag = "25";
            this.generaCotizacionMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Rust;
            this.generaCotizacionMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.generaCotizacionMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.generaCotizacionMetroTileItem.TitleText = "Genera Cotización";
            this.generaCotizacionMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generaCotizacionMetroTileItem.Click += new System.EventHandler(this.generaCotizacionMetroTileItem_Click);
            // 
            // citasDermaMetroTileItem
            // 
            this.citasDermaMetroTileItem.Image = global::SIF.Properties.Resources.Phone_Book;
            this.citasDermaMetroTileItem.Name = "citasDermaMetroTileItem";
            this.citasDermaMetroTileItem.Tag = "26";
            this.citasDermaMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure;
            this.citasDermaMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.citasDermaMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.citasDermaMetroTileItem.TitleText = "Citas Derma";
            this.citasDermaMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.citasDermaMetroTileItem.Click += new System.EventHandler(this.citasDermaMetroTileItem_Click);
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
            this.quejaSugerenciaMetroTileItem,
            this.metroTileItem1});
            // 
            // quejaSugerenciaMetroTileItem
            // 
            this.quejaSugerenciaMetroTileItem.Image = global::SIF.Properties.Resources.HelpCAT1;
            this.quejaSugerenciaMetroTileItem.Name = "quejaSugerenciaMetroTileItem";
            this.quejaSugerenciaMetroTileItem.Tag = "27";
            this.quejaSugerenciaMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkBlue;
            this.quejaSugerenciaMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.quejaSugerenciaMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.quejaSugerenciaMetroTileItem.TitleText = "Queja/Sugerencia";
            this.quejaSugerenciaMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quejaSugerenciaMetroTileItem.Click += new System.EventHandler(this.quejaSugerenciaMetroTileItem_Click);
            // 
            // EnvioMarketingMetroTileItem
            // 
            this.EnvioMarketingMetroTileItem.Image = global::SIF.Properties.Resources.Venta3;
            this.EnvioMarketingMetroTileItem.Name = "EnvioMarketingMetroTileItem";
            this.EnvioMarketingMetroTileItem.Tag = "26";
            this.EnvioMarketingMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure;
            this.EnvioMarketingMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.EnvioMarketingMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.EnvioMarketingMetroTileItem.TitleText = "Marketing";
            this.EnvioMarketingMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnvioMarketingMetroTileItem.Click += new System.EventHandler(this.EnvioMarketingMetroTileItem_Click);
            // 
            // metroTileItem1
            // 
            this.metroTileItem1.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem1.Image = ((System.Drawing.Image)(resources.GetObject("metroTileItem1.Image")));
            this.metroTileItem1.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTileItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.Stretch = true;
            this.metroTileItem1.Tag = "28";
            this.metroTileItem1.Text = "Catalogo Quejas y Sugerencias";
            this.metroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue;
            this.metroTileItem1.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem1.TitleText = "Catalogo\r\nQuejas/Sugerencias";
            this.metroTileItem1.Click += new System.EventHandler(this.metroTileItem1_Click);
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
            this.metroTileItem2,
            //this.metroTileItem3,
                this.metroTileItem6});
            // 
            // metroTileItem2
            // 
            this.metroTileItem2.Image = global::SIF.Properties.Resources.clientesconvenio;
            this.metroTileItem2.Name = "metroTileItem2";
            this.metroTileItem2.Tag = "26";
            this.metroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure;
            this.metroTileItem2.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem2.TitleText = "Cotización Clientes Convenio";
            this.metroTileItem2.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTileItem2.Click += new System.EventHandler(this.metroTileItem2_Click);
            // 
            // metroTileItem6
            // 
            this.metroTileItem6.Image = global::SIF.Properties.Resources.Insurance_Bill;
            this.metroTileItem6.Name = "metroTileItem6";
            this.metroTileItem6.Tag = "26";
            this.metroTileItem6.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure;
            this.metroTileItem6.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem6.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem6.TitleText = "Cotización Cliente Mayorista";
            this.metroTileItem6.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTileItem6.Click += new System.EventHandler(this.metroTileItem6_Click);
            // 
            // metroTileItem3
            // 
            this.metroTileItem3.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem3.Enabled = false;
            this.metroTileItem3.Name = "metroTileItem3";
            this.metroTileItem3.Tag = "23";
            this.metroTileItem3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem3.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem3.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem3.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // ventaPedidosMetroTileItem
            // 
            this.ventaPedidosMetroTileItem.Image = global::SIF.Properties.Resources.Box;
            this.ventaPedidosMetroTileItem.Name = "ventaPedidosMetroTileItem";
            this.ventaPedidosMetroTileItem.Text = "Pedidos";
            this.ventaPedidosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green;
            this.ventaPedidosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ventaPedidosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ventaPedidosMetroTileItem.TitleText = "3 &Pedidos";
            this.ventaPedidosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroTileItem4
            // 
            this.metroTileItem4.Image = global::SIF.Properties.Resources.Box;
            this.metroTileItem4.Name = "metroTileItem4";
            this.metroTileItem4.Text = "Pedidos";
            this.metroTileItem4.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green;
            this.metroTileItem4.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem4.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem4.TitleText = "3 &Pedidos";
            this.metroTileItem4.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroTileItem5
            // 
            this.metroTileItem5.Image = global::SIF.Properties.Resources.HelpCAT1;
            this.metroTileItem5.Name = "metroTileItem5";
            this.metroTileItem5.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkBlue;
            this.metroTileItem5.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem5.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem5.TitleText = "Queja/Sugerencia";
            this.metroTileItem5.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // CatMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.metroTilePanel1);
            this.Name = "CatMenu";
            this.Controls.SetChildIndex(this.subMenuLabelX, 0);
            this.Controls.SetChildIndex(this.titlelabelX, 0);
            this.Controls.SetChildIndex(this.salirButton, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.Controls.SetChildIndex(this.metroTilePanel1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer2;
        private DevComponents.DotNetBar.Metro.MetroTileItem generaCotizacionMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem quejaSugerenciaMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem citasDermaMetroTileItem;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem1;
        private DevComponents.DotNetBar.Metro.MetroTileItem ventaPedidosMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem4;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem5;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem2;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem6;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem3;
        private DevComponents.DotNetBar.Metro.MetroTileItem EnvioMarketingMetroTileItem;
    }
}
