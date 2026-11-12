namespace SIF.View.Menu.Ventas
{
    partial class ControladosUserControl
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
            this.generaFolioControladoMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.foliosControladosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
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
            this.subMenuLabelX.Text = "<font  color = \"#2E619D\">Controlados</font>";
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
            this.itemContainer1});
            this.metroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroTilePanel1.Location = new System.Drawing.Point(275, 109);
            this.metroTilePanel1.Name = "metroTilePanel1";
            this.metroTilePanel1.Size = new System.Drawing.Size(462, 400);
            this.metroTilePanel1.TabIndex = 21;
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
            this.generaFolioControladoMetroTileItem,
            this.foliosControladosMetroTileItem,
            this.metroTileItem3});
            // 
            // generaFolioControladoMetroTileItem
            // 
            this.generaFolioControladoMetroTileItem.Image = global::SIF.Properties.Resources.FolioControlado;
            this.generaFolioControladoMetroTileItem.Name = "generaFolioControladoMetroTileItem";
            this.generaFolioControladoMetroTileItem.Tag = "64";
            this.generaFolioControladoMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue;
            this.generaFolioControladoMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.generaFolioControladoMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.generaFolioControladoMetroTileItem.TitleText = "Genera Folio Controlado";
            this.generaFolioControladoMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.generaFolioControladoMetroTileItem.Click += new System.EventHandler(this.generaFolioControladoMetroTileItem_Click);
            // 
            // foliosControladosMetroTileItem
            // 
            this.foliosControladosMetroTileItem.Image = global::SIF.Properties.Resources.CancelacionTicket1;
            this.foliosControladosMetroTileItem.Name = "foliosControladosMetroTileItem";
            this.foliosControladosMetroTileItem.Tag = "65";
            this.foliosControladosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet;
            this.foliosControladosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.foliosControladosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.foliosControladosMetroTileItem.TitleText = "Cancelación de Ticket";
            this.foliosControladosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.foliosControladosMetroTileItem.Click += new System.EventHandler(this.foliosControladosMetroTileItem_Click);
            // 
            // metroTileItem3
            // 
            this.metroTileItem3.Image = global::SIF.Properties.Resources.AltaMedico;
            this.metroTileItem3.Name = "metroTileItem3";
            this.metroTileItem3.Tag = "66";
            this.metroTileItem3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Maroon;
            this.metroTileItem3.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem3.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem3.TitleText = "Alta de Médico y Receta";
            this.metroTileItem3.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.metroTileItem3.Visible = false;
            // 
            // ControladosUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTilePanel1);
            this.Name = "ControladosUserControl";
            this.Controls.SetChildIndex(this.titlelabelX, 0);
            this.Controls.SetChildIndex(this.subMenuLabelX, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.Controls.SetChildIndex(this.salirButton, 0);
            this.Controls.SetChildIndex(this.metroTilePanel1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem generaFolioControladoMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem foliosControladosMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem3;
    }
}
