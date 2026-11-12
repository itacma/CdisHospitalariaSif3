namespace SIF.View.Menu.Compras
{
    partial class ComprasUserControl
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
            this.metroTilePanel2 = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.ArticulosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.FacturasMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.metroTileItem5 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ActualizacionValesMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem4 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem2 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem3 = new DevComponents.DotNetBar.Metro.MetroTileItem();
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
            this.subMenuLabelX.Text = "<font  color = \"#2E619D\"> Subrogación</font>";
            // 
            // metroTilePanel2
            // 
            this.metroTilePanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.metroTilePanel2.BackgroundStyle.Class = "MetroTilePanel";
            this.metroTilePanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTilePanel2.ContainerControlProcessDialogKey = true;
            this.metroTilePanel2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer2,
            this.itemContainer3});
            this.metroTilePanel2.ItemSpacing = 5;
            this.metroTilePanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.metroTilePanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroTilePanel2.Location = new System.Drawing.Point(245, 143);
            this.metroTilePanel2.Name = "metroTilePanel2";
            this.metroTilePanel2.Size = new System.Drawing.Size(618, 579);
            this.metroTilePanel2.TabIndex = 25;
            this.metroTilePanel2.Text = "metroTilePanel2";
            // 
            // itemContainer2
            // 
            // 
            // 
            // 
            this.itemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer2.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemContainer2.ItemSpacing = 5;
            this.itemContainer2.MultiLine = true;
            this.itemContainer2.Name = "itemContainer2";
            this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ArticulosMetroTileItem,
            this.FacturasMetroTileItem,
            this.metroTileItem1,
            this.metroTileItem2});
            // 
            // ArticulosMetroTileItem
            // 
            this.ArticulosMetroTileItem.Image = global::SIF.Properties.Resources.traspaso;
            this.ArticulosMetroTileItem.Name = "ArticulosMetroTileItem";
            this.ArticulosMetroTileItem.Tag = "85";
            this.ArticulosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.MaroonWashed;
            this.ArticulosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ArticulosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ArticulosMetroTileItem.TitleText = "Catalogo Articulos";
            this.ArticulosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArticulosMetroTileItem.Click += new System.EventHandler(this.subrogacionMetroTileItem_Click);
            // 
            // FacturasMetroTileItem
            // 
            this.FacturasMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.FacturasMetroTileItem.Image = global::SIF.Properties.Resources.Factura;
            this.FacturasMetroTileItem.Name = "FacturasMetroTileItem";
            this.FacturasMetroTileItem.Tag = "86";
            this.FacturasMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue;
            this.FacturasMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.FacturasMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FacturasMetroTileItem.TitleText = "Facturación";
            this.FacturasMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FacturasMetroTileItem.Click += new System.EventHandler(this.FacturasMetroTileItem_Click);
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
            this.metroTileItem5,
            this.ActualizacionValesMetroTileItem,
            this.metroTileItem4,
            this.metroTileItem3});
            // 
            // metroTileItem5
            // 
            this.metroTileItem5.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem5.Image = global::SIF.Properties.Resources.CreditCard2;
            this.metroTileItem5.Name = "metroTileItem5";
            this.metroTileItem5.Tag = "88";
            this.metroTileItem5.Text = " ";
            this.metroTileItem5.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.PlumWashed;
            this.metroTileItem5.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem5.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem5.TitleText = "Ventas Crédito";
            this.metroTileItem5.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.metroTileItem5.Click += new System.EventHandler(this.metroTileItem5_Click);
            // 
            // ActualizacionValesMetroTileItem
            // 
            this.ActualizacionValesMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.ActualizacionValesMetroTileItem.Image = global::SIF.Properties.Resources.ActualizacionVales;
            this.ActualizacionValesMetroTileItem.Name = "ActualizacionValesMetroTileItem";
            this.ActualizacionValesMetroTileItem.Tag = "89";
            this.ActualizacionValesMetroTileItem.Text = " ";
            this.ActualizacionValesMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal;
            this.ActualizacionValesMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ActualizacionValesMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ActualizacionValesMetroTileItem.TitleText = "Actualización Vales";
            this.ActualizacionValesMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.ActualizacionValesMetroTileItem.Click += new System.EventHandler(this.ActualizacionValesMetroTileItem_Click);
            // 
            // metroTileItem4
            // 
            this.metroTileItem4.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem4.Enabled = false;
            this.metroTileItem4.Name = "metroTileItem4";
            this.metroTileItem4.Text = " ";
            this.metroTileItem4.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem4.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem4.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // metroTileItem1
            // 
            this.metroTileItem1.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem1.Enabled = false;
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.Text = " ";
            this.metroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem1.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // metroTileItem2
            // 
            this.metroTileItem2.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem2.Enabled = false;
            this.metroTileItem2.Name = "metroTileItem2";
            this.metroTileItem2.Text = " ";
            this.metroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem2.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
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
            // ComprasUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTilePanel2);
            this.Name = "ComprasUserControl";
            this.Controls.SetChildIndex(this.subMenuLabelX, 0);
            this.Controls.SetChildIndex(this.titlelabelX, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.Controls.SetChildIndex(this.salirButton, 0);
            this.Controls.SetChildIndex(this.metroTilePanel2, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel2;
        private DevComponents.DotNetBar.ItemContainer itemContainer2;
        private DevComponents.DotNetBar.Metro.MetroTileItem ArticulosMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem FacturasMetroTileItem;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem5;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem4;
        private DevComponents.DotNetBar.Metro.MetroTileItem ActualizacionValesMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem1;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem2;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem3;
    }
}
