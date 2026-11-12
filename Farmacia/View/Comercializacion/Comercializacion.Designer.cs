
namespace SIF.View.Comercializacion
{
    partial class Comercializacion
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Comercializacion));
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.SaldosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.FacturasMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTilePanel1 = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.metroTileItem4 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem5 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.backButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.backButton.FadeEffect = false;
            this.backButton.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.Location = new System.Drawing.Point(9, 21);
            this.backButton.Name = "backButton";
            this.backButton.PressedImage = ((System.Drawing.Image)(resources.GetObject("backButton.PressedImage")));
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.backButton.Size = new System.Drawing.Size(48, 48);
            this.backButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.backButton.TabIndex = 17;
            this.backButton.Tooltip = "Regresar [F12]";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // titlelabelX
            // 
            this.titlelabelX.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.titlelabelX.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.titlelabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.titlelabelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlelabelX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(97)))), ((int)(((byte)(157)))));
            this.titlelabelX.Location = new System.Drawing.Point(63, 12);
            this.titlelabelX.Name = "titlelabelX";
            this.titlelabelX.Size = new System.Drawing.Size(485, 67);
            this.titlelabelX.TabIndex = 15;
            this.titlelabelX.Text = "<font  color = \"#2E6BFA\">Farmacias Fleming</font>";
            // 
            // salirButton
            // 
            this.salirButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.salirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.salirButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.salirButton.Image = ((System.Drawing.Image)(resources.GetObject("salirButton.Image")));
            this.salirButton.Location = new System.Drawing.Point(888, 628);
            this.salirButton.Name = "salirButton";
            this.salirButton.Size = new System.Drawing.Size(69, 66);
            this.salirButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.salirButton.TabIndex = 18;
            //this.salirButton.Click += new System.EventHandler(this.salirButton_Click);
            // 
            // subMenuLabelX
            // 
            this.subMenuLabelX.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.subMenuLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.subMenuLabelX.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subMenuLabelX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(97)))), ((int)(((byte)(157)))));
            this.subMenuLabelX.Location = new System.Drawing.Point(63, 63);
            this.subMenuLabelX.Name = "subMenuLabelX";
            this.subMenuLabelX.Size = new System.Drawing.Size(819, 62);
            this.subMenuLabelX.TabIndex = 20;
            this.subMenuLabelX.Text = "<font  color = \"#2E619D\">Comercialización</font>";

            // 
            // itemContainer1
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.BeginGroup = true;
            this.itemContainer1.ItemSpacing = 5;
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.SaldosMetroTileItem,
            this.FacturasMetroTileItem});
            // 
            // SaldosMetroTileItem
            // 
            this.SaldosMetroTileItem.DisabledBackColor = System.Drawing.Color.Green;
            this.SaldosMetroTileItem.Image = global::SIF.Properties.Resources.Home_loan;
            this.SaldosMetroTileItem.Name = "SaldosMetroTileItem";
            this.SaldosMetroTileItem.Tag = "1";
            this.SaldosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkGreen;
            this.SaldosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            this.SaldosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SaldosMetroTileItem.TitleText = "1 &Saldos Convenio";
            this.SaldosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaldosMetroTileItem.Click += new System.EventHandler(this.SaldosMetroTileItem_Click);
            // 
            // expedienteProveedoresMetroTileItem
            // 
            this.FacturasMetroTileItem.DisabledBackColor = System.Drawing.Color.Pink;
            this.FacturasMetroTileItem.Image = global::SIF.Properties.Resources.Factura;
            this.FacturasMetroTileItem.Name = "FacturasMetroTileItem";
            this.FacturasMetroTileItem.Tag = "2";
            this.FacturasMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Magenta;
            this.FacturasMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            this.FacturasMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FacturasMetroTileItem.TitleText = "2 &Menú 2";
            this.FacturasMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FacturasMetroTileItem.Click += new System.EventHandler(this.FacturasMetroTileItem_Click);
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
            this.itemContainer3,
            this.itemContainer2});
            this.metroTilePanel1.ItemSpacing = 5;
            this.metroTilePanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.metroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroTilePanel1.Location = new System.Drawing.Point(201, 110);
            this.metroTilePanel1.Name = "metroTilePanel1";
            this.metroTilePanel1.Size = new System.Drawing.Size(611, 584);
            this.metroTilePanel1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTilePanel1.TabIndex = 0;
            this.metroTilePanel1.Text = "metroTilePanel1";
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
            this.metroTileItem4});
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
            this.metroTileItem5});
            // 
            // metroTileItem4
            // 
            this.metroTileItem4.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem4.Enabled = false;
            this.metroTileItem4.Name = "metroTileItem4";
            this.metroTileItem4.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem4.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem4.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;

            // 
            // metroTileItem5
            // 
            this.metroTileItem5.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem5.Enabled = false;
            this.metroTileItem5.Name = "metroTileItem5";
            this.metroTileItem5.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem5.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem5.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;

            // 
            // Comercializacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTilePanel1);
            this.Name = "Comercializacion";
            this.Controls.SetChildIndex(this.subMenuLabelX, 0);
            this.Controls.SetChildIndex(this.titlelabelX, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.Controls.SetChildIndex(this.salirButton, 0);
            this.Controls.SetChildIndex(this.metroTilePanel1, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel1;
        private DevComponents.DotNetBar.Metro.MetroTileItem SaldosMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem FacturasMetroTileItem;
        private DevComponents.DotNetBar.ItemContainer itemContainer2;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem4;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem5;
    }
}
