namespace SIF.View.Menu
{
    partial class CatalogosSegUserControl
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
            this.metroTileItem2 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.perfilesMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem3 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem46 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.compradoresMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem4 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.impuestosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem5 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem7 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem6 = new DevComponents.DotNetBar.Metro.MetroTileItem();
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
            this.metroTilePanel1.Location = new System.Drawing.Point(63, 131);
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
            this.metroTileItem2,
            this.perfilesMetroTileItem,
            this.metroTileItem3,
            this.metroTileItem46,
            this.compradoresMetroTileItem,
            this.metroTileItem4,
            this.impuestosMetroTileItem,
            this.metroTileItem5,
            this.metroTileItem7});
            // 
            // metroTileItem2
            // 
            this.metroTileItem2.Image = global::SIF.Properties.Resources.usuarios;
            this.metroTileItem2.Name = "metroTileItem2";
            this.metroTileItem2.Tag = "67";
            this.metroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellowish;
            this.metroTileItem2.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem2.TitleText = "Usuarios";
            this.metroTileItem2.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTileItem2.Click += new System.EventHandler(this.metroTileItem2_Click);
            // 
            // perfilesMetroTileItem
            // 
            this.perfilesMetroTileItem.Image = global::SIF.Properties.Resources.CAT_VALES_DEV;
            this.perfilesMetroTileItem.Name = "perfilesMetroTileItem";
            this.perfilesMetroTileItem.Tag = "68";
            this.perfilesMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange;
            this.perfilesMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.perfilesMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.perfilesMetroTileItem.TitleText = "Perfiles";
            this.perfilesMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perfilesMetroTileItem.Click += new System.EventHandler(this.perfilesMetroTileItem_Click);
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
            // metroTileItem46
            // 
            this.metroTileItem46.Image = global::SIF.Properties.Resources.Permisos;
            this.metroTileItem46.Name = "metroTileItem46";
            this.metroTileItem46.Tag = "79";
            this.metroTileItem46.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green;
            this.metroTileItem46.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem46.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem46.TitleText = "Permisos";
            this.metroTileItem46.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTileItem46.Click += new System.EventHandler(this.metroTileItem46_Click);
            // 
            // compradoresMetroTileItem
            // 
            this.compradoresMetroTileItem.Image = global::SIF.Properties.Resources.User_Earth;
            this.compradoresMetroTileItem.Name = "compradoresMetroTileItem";
            this.compradoresMetroTileItem.Tag = "69";
            this.compradoresMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue;
            this.compradoresMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.compradoresMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.compradoresMetroTileItem.TitleText = "Compradores";
            this.compradoresMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compradoresMetroTileItem.Click += new System.EventHandler(this.compradoresMetroTileItem_Click);
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
            // impuestosMetroTileItem
            // 
            this.impuestosMetroTileItem.Image = global::SIF.Properties.Resources.impuestos;
            this.impuestosMetroTileItem.Name = "impuestosMetroTileItem";
            this.impuestosMetroTileItem.Tag = "69";
            this.impuestosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.PlumWashed;
            this.impuestosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.impuestosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.impuestosMetroTileItem.TitleText = "Bitacora";
            this.impuestosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.impuestosMetroTileItem.Click += new System.EventHandler(this.impuestosMetroTileItem_Click);
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
            // metroTileItem7
            // 
            this.metroTileItem7.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem7.Enabled = false;
            this.metroTileItem7.Name = "metroTileItem7";
            this.metroTileItem7.Text = " ";
            this.metroTileItem7.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem7.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem7.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // metroTileItem1
            // 
            this.metroTileItem1.Image = global::SIF.Properties.Resources.usuarios;
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellowish;
            this.metroTileItem1.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem1.TitleText = "Usuarios";
            this.metroTileItem1.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // CatalogosSegUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTilePanel1);
            this.Name = "CatalogosSegUserControl";
            this.Controls.SetChildIndex(this.metroTilePanel1, 0);
            this.Controls.SetChildIndex(this.titlelabelX, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.Controls.SetChildIndex(this.salirButton, 0);
            this.Controls.SetChildIndex(this.subMenuLabelX, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem2;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem1;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem46;
        private DevComponents.DotNetBar.Metro.MetroTileItem perfilesMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem impuestosMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem compradoresMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem3;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem4;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem5;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem7;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem6;
    }
}
