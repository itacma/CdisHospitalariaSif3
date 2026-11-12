
namespace SIF.View.Catalogos
{
    partial class frmImagenesArticuloIdGoogleDrive
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.metroStatusBar1 = new DevComponents.DotNetBar.Metro.MetroStatusBar();
            this.closeMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.EliminarMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.sb_lblMsg = new DevComponents.DotNetBar.LabelItem();
            this.SincronizarMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.AceptarMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(609, 11);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(127, 416);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // metroStatusBar1
            // 
            this.metroStatusBar1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroStatusBar1.ContainerControlProcessDialogKey = true;
            this.metroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroStatusBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroStatusBar1.ForeColor = System.Drawing.Color.Black;
            this.metroStatusBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.closeMetroTileItem,
            this.EliminarMetroTileItem,
            this.sb_lblMsg,
            this.SincronizarMetroTileItem,
            this.AceptarMetroTileItem});
            this.metroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroStatusBar1.Location = new System.Drawing.Point(0, 442);
            this.metroStatusBar1.Name = "metroStatusBar1";
            this.metroStatusBar1.Size = new System.Drawing.Size(739, 45);
            this.metroStatusBar1.TabIndex = 10;
            this.metroStatusBar1.Text = "metroStatusBar1";
            // 
            // closeMetroTileItem
            // 
            this.closeMetroTileItem.AutoRotateFramesInterval = 5000;
            this.closeMetroTileItem.Image = global::SIF.Properties.Resources.Cancel1;
            this.closeMetroTileItem.Name = "closeMetroTileItem";
            this.closeMetroTileItem.Tag = "1";
            this.closeMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.closeMetroTileItem.TileSize = new System.Drawing.Size(55, 55);
            // 
            // 
            // 
            this.closeMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.closeMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 11F);
            this.closeMetroTileItem.Tooltip = "Cerrar";
            this.closeMetroTileItem.Click += new System.EventHandler(this.closeMetroTileItem_Click);
            // 
            // EliminarMetroTileItem
            // 
            this.EliminarMetroTileItem.AutoRotateFramesInterval = 5000;
            this.EliminarMetroTileItem.Image = global::SIF.Properties.Resources.Junk1;
            this.EliminarMetroTileItem.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.EliminarMetroTileItem.Name = "EliminarMetroTileItem";
            this.EliminarMetroTileItem.Tag = "1";
            this.EliminarMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.EliminarMetroTileItem.TileSize = new System.Drawing.Size(55, 55);
            // 
            // 
            // 
            this.EliminarMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.EliminarMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 11F);
            this.EliminarMetroTileItem.Tooltip = "Sincronizar";
            this.EliminarMetroTileItem.Click += new System.EventHandler(this.EliminarMetroTileItem_Click);
            // 
            // sb_lblMsg
            // 
            this.sb_lblMsg.Name = "sb_lblMsg";
            this.sb_lblMsg.Stretch = true;
            this.sb_lblMsg.Text = " ";
            // 
            // SincronizarMetroTileItem
            // 
            this.SincronizarMetroTileItem.AutoRotateFramesInterval = 5000;
            this.SincronizarMetroTileItem.Image = global::SIF.Properties.Resources.Upload2;
            this.SincronizarMetroTileItem.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.SincronizarMetroTileItem.Name = "SincronizarMetroTileItem";
            this.SincronizarMetroTileItem.Tag = "1";
            this.SincronizarMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.SincronizarMetroTileItem.TileSize = new System.Drawing.Size(55, 55);
            // 
            // 
            // 
            this.SincronizarMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SincronizarMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 11F);
            this.SincronizarMetroTileItem.Tooltip = "Sincronizar";
            this.SincronizarMetroTileItem.Click += new System.EventHandler(this.SincronizarMetroTileItem_Click);
            // 
            // AceptarMetroTileItem
            // 
            this.AceptarMetroTileItem.AutoRotateFramesInterval = 5000;
            this.AceptarMetroTileItem.Image = global::SIF.Properties.Resources.AddTool1;
            this.AceptarMetroTileItem.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.AceptarMetroTileItem.Name = "AceptarMetroTileItem";
            this.AceptarMetroTileItem.Tag = "1";
            this.AceptarMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.AceptarMetroTileItem.TileSize = new System.Drawing.Size(55, 55);
            // 
            // 
            // 
            this.AceptarMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.AceptarMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 11F);
            this.AceptarMetroTileItem.Tooltip = "Agregar";
            this.AceptarMetroTileItem.Click += new System.EventHandler(this.AceptarMetroTileItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(26, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(577, 415);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // frmImagenesArticuloIdGoogleDrive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 488);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.metroStatusBar1);
            this.Name = "frmImagenesArticuloIdGoogleDrive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmImagenesArticuloIdGoogleDrive";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private DevComponents.DotNetBar.Metro.MetroStatusBar metroStatusBar1;
        private DevComponents.DotNetBar.Metro.MetroTileItem AceptarMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem SincronizarMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem closeMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem EliminarMetroTileItem;
        private DevComponents.DotNetBar.LabelItem sb_lblMsg;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}