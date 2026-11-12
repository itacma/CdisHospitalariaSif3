namespace SIF.View.Menu.Ventas
{
    partial class CajaUserControl
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
            this.pagoCajaMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ingresoCajaMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.mantenimientoACajasMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
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
            this.subMenuLabelX.Text = "<font  color = \"#2E619D\">Caja</font>";
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
            this.pagoCajaMetroTileItem,
            this.ingresoCajaMetroTileItem,
            this.mantenimientoACajasMetroTileItem});
            // 
            // pagoCajaMetroTileItem
            // 
            this.pagoCajaMetroTileItem.Image = global::SIF.Properties.Resources.PagoNotasVenta;
            this.pagoCajaMetroTileItem.Name = "pagoCajaMetroTileItem";
            this.pagoCajaMetroTileItem.Tag = "61";
            this.pagoCajaMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellowish;
            this.pagoCajaMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.pagoCajaMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pagoCajaMetroTileItem.TitleText = "1 Pago Nota VentaN";
            this.pagoCajaMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.pagoCajaMetroTileItem.Click += new System.EventHandler(this.pagoCajaMetroTileItem_Click);
            // 
            // ingresoCajaMetroTileItem
            // 
            this.ingresoCajaMetroTileItem.Image = global::SIF.Properties.Resources.IngresoCajera;
            this.ingresoCajaMetroTileItem.Name = "ingresoCajaMetroTileItem";
            this.ingresoCajaMetroTileItem.Tag = "62";
            this.ingresoCajaMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green;
            this.ingresoCajaMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ingresoCajaMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ingresoCajaMetroTileItem.TitleText = "2 Ingreso Cajera";
            this.ingresoCajaMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.ingresoCajaMetroTileItem.Click += new System.EventHandler(this.ingresoCajaMetroTileItem_Click);
            // 
            // mantenimientoACajasMetroTileItem
            // 
            this.mantenimientoACajasMetroTileItem.Image = global::SIF.Properties.Resources.Cajas;
            this.mantenimientoACajasMetroTileItem.Name = "mantenimientoACajasMetroTileItem";
            this.mantenimientoACajasMetroTileItem.Tag = "63";
            this.mantenimientoACajasMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange;
            this.mantenimientoACajasMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.mantenimientoACajasMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.mantenimientoACajasMetroTileItem.TitleText = "3 Mantenimiento a Cajas";
            this.mantenimientoACajasMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.mantenimientoACajasMetroTileItem.Click += new System.EventHandler(this.mantenimientoACajasMetroTileItem_Click);
            // 
            // CajaUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTilePanel1);
            this.Name = "CajaUserControl";
            this.Controls.SetChildIndex(this.subMenuLabelX, 0);
            this.Controls.SetChildIndex(this.titlelabelX, 0);
            this.Controls.SetChildIndex(this.metroTilePanel1, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.Controls.SetChildIndex(this.salirButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem ingresoCajaMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem mantenimientoACajasMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem pagoCajaMetroTileItem;
    }
}
