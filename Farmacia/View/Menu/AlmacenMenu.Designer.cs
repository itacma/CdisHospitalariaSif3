namespace SIF.View.Menu
{
    partial class AlmacenMenu
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
            this.recepcionBultosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem10 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem2 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.metroTileItem3 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem5 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem6 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem4 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem7 = new DevComponents.DotNetBar.Metro.MetroTileItem();
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
            this.subMenuLabelX.Text = "<font  color = \"#2E619D\">Almacén</font>";
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
            this.itemContainer2});
            this.metroTilePanel1.ItemSpacing = 5;
            this.metroTilePanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.metroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroTilePanel1.Location = new System.Drawing.Point(199, 131);
            this.metroTilePanel1.Name = "metroTilePanel1";
            this.metroTilePanel1.Size = new System.Drawing.Size(618, 579);
            this.metroTilePanel1.TabIndex = 0;
            this.metroTilePanel1.Text = "metroTilePanel1";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemContainer1.ItemSpacing = 5;
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.recepcionBultosMetroTileItem,
            this.metroTileItem10,
            this.metroTileItem2,
            this.metroTileItem7});
            // 
            // recepcionBultosMetroTileItem
            // 
            this.recepcionBultosMetroTileItem.Image = global::SIF.Properties.Resources.bultos;
            this.recepcionBultosMetroTileItem.Name = "recepcionBultosMetroTileItem";
            this.recepcionBultosMetroTileItem.Tag = "20";
            this.recepcionBultosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Gray;
            this.recepcionBultosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.recepcionBultosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.recepcionBultosMetroTileItem.TitleText = "Recepcion de Bultos";
            this.recepcionBultosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recepcionBultosMetroTileItem.Click += new System.EventHandler(this.recepcionBultosMetroTileItem_Click);
            // 
            // metroTileItem10
            // 
            this.metroTileItem10.Image = global::SIF.Properties.Resources.traspaso;
            this.metroTileItem10.Name = "metroTileItem10";
            this.metroTileItem10.Tag = "22";
            this.metroTileItem10.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.MaroonWashed;
            this.metroTileItem10.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem10.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem10.TitleText = "Traspaso a Sucursales";
            this.metroTileItem10.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTileItem10.Click += new System.EventHandler(this.metroTileItem10_Click);
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
            this.metroTileItem3,
            this.metroTileItem5,
            this.metroTileItem6,
            this.metroTileItem4});
            // 
            // metroTileItem3
            // 
            this.metroTileItem3.Image = global::SIF.Properties.Resources.AjustesInventario;
            this.metroTileItem3.Name = "metroTileItem3";
            this.metroTileItem3.Tag = "24";
            this.metroTileItem3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem3.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem3.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem3.TitleText = "Ajustes al inventario";
            this.metroTileItem3.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTileItem3.Click += new System.EventHandler(this.metroTileItem3_Click);
            // 
            // metroTileItem5
            // 
            this.metroTileItem5.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem5.Enabled = false;
            this.metroTileItem5.Name = "metroTileItem5";
            this.metroTileItem5.Text = " ";
            this.metroTileItem5.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem5.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem5.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
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
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.metroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // metroTileItem7
            // 
            this.metroTileItem7.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem7.Enabled = false;
            this.metroTileItem7.Name = "metroTileItem7";
            this.metroTileItem7.Tag = "23";
            this.metroTileItem7.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem7.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem7.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem7.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // AlmacenMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTilePanel1);
            this.Name = "AlmacenMenu";
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
        private DevComponents.DotNetBar.Metro.MetroTileItem recepcionBultosMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem10;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem1;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem2;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem3;
        private DevComponents.DotNetBar.ItemContainer itemContainer2;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem5;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem6;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem4;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem7;
    }
}
