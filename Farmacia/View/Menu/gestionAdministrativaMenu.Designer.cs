
namespace SIF.View.Menu
{
    partial class gestionAdministrativaMenu
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
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            
            this.comercializacionMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.GeneralesMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.finanzasMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.recursosHumanosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            
            this.metroTilePanel1 = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            
            
            this.metroTileItem4 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            
            
            
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
            this.subMenuLabelX.Location = new System.Drawing.Point(63, 65);
            this.subMenuLabelX.Text = "<font  color = \"#2E619D\">Departamentos </font>";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.BeginGroup = true;
            this.itemContainer1.ItemSpacing = 5;
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            

            this.GeneralesMetroTileItem,
                        this.comercializacionMetroTileItem});
               // 
            // comercializacionMetroTileItem
            // 
            this.comercializacionMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.comercializacionMetroTileItem.Image = global::SIF.Properties.Resources.User_Earth;
            this.comercializacionMetroTileItem.Name = "comercializacionMetroTileItem";
            this.comercializacionMetroTileItem.Tag = "2";
            this.comercializacionMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange;
            this.comercializacionMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.comercializacionMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.comercializacionMetroTileItem.TitleText = "2 &Comercializacion";
            this.comercializacionMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comercializacionMetroTileItem.Click += new System.EventHandler(this.comercializacionMetroTileItem_Click);
            // 
            // GeneralesMetroTileItem
            // 
            this.GeneralesMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.GeneralesMetroTileItem.Image = global::SIF.Properties.Resources.ReporMedi;
            this.GeneralesMetroTileItem.Name = "GeneralesMetroTileItem";
            this.GeneralesMetroTileItem.Tag = "1";
            
            this.GeneralesMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green;
            this.GeneralesMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.GeneralesMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.GeneralesMetroTileItem.TitleText = "1 &Generales";
            this.GeneralesMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneralesMetroTileItem.Click += new System.EventHandler(this.GeneralesMetroTileItem_Click);
            // 
            // finanzasMetroTileItem
            // 
            this.finanzasMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.finanzasMetroTileItem.Image = global::SIF.Properties.Resources.TipoPago;
            this.finanzasMetroTileItem.Name = "finanzasMetroTileItem";
            this.finanzasMetroTileItem.Tag = "9";
            this.finanzasMetroTileItem.Text = "Finanzas";
            this.finanzasMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet;
            this.finanzasMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.finanzasMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.finanzasMetroTileItem.TitleText = "9 Finanzas";
            this.finanzasMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finanzasMetroTileItem.Click += new System.EventHandler(this.finanzasMetroTileItem_Click);
            // 
            // recursosHumanosMetroTileItem
            // 
            this.recursosHumanosMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.recursosHumanosMetroTileItem.Image = global::SIF.Properties.Resources.usuarios;
            this.recursosHumanosMetroTileItem.Name = "recursosHumanosMetroTileItem";
            this.recursosHumanosMetroTileItem.Tag = "5";
            this.recursosHumanosMetroTileItem.Text = "Recursos \r\nHumanos";
            this.recursosHumanosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue;
            this.recursosHumanosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.recursosHumanosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.recursosHumanosMetroTileItem.TitleText = "5 &RH";
            this.recursosHumanosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recursosHumanosMetroTileItem.Click += new System.EventHandler(this.recursosHumanosMetroTileItem_Click);
            
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
            this.recursosHumanosMetroTileItem});
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
            
            this.finanzasMetroTileItem,
            this.metroTileItem4,
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
            // VentasMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTilePanel1);
            this.Name = "gestionAdministrativaMenu";
            this.Controls.SetChildIndex(this.subMenuLabelX, 0);
            this.Controls.SetChildIndex(this.salirButton, 0);
            this.Controls.SetChildIndex(this.titlelabelX, 0);
            this.Controls.SetChildIndex(this.metroTilePanel1, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel1;
        private DevComponents.DotNetBar.Metro.MetroTileItem GeneralesMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem recursosHumanosMetroTileItem;
        
        private DevComponents.DotNetBar.Metro.MetroTileItem finanzasMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem comercializacionMetroTileItem;
               
        private DevComponents.DotNetBar.ItemContainer itemContainer2;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem4;        
        
        
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem5;
    }
}
