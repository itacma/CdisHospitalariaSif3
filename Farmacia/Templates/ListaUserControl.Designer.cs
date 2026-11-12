namespace SIF.Templates
{
    partial class ListaUserControl
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
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.backButton = new DevComponents.DotNetBar.ButtonX();
            this.titleLabel = new System.Windows.Forms.Label();
            this.statusLabel = new DevComponents.DotNetBar.LabelX();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fotoPictureBox = new System.Windows.Forms.PictureBox();
            this.apellidosLabel = new System.Windows.Forms.Label();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.sucursalLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "bar1 (bar1)";
            this.bar1.AccessibleName = "bar1";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar1.AntiAlias = true;
            this.bar1.BackColor = System.Drawing.Color.Transparent;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.Location = new System.Drawing.Point(64, 44);
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(793, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 15;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // backButton
            // 
            this.backButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.backButton.FadeEffect = false;
            this.backButton.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.backButton.Image = global::SIF.Properties.Resources.Arrow_Left;
            this.backButton.Location = new System.Drawing.Point(10, 47);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backButton.Name = "backButton";
            this.backButton.PressedImage = global::SIF.Properties.Resources.Arrow_Left_1;
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.backButton.Size = new System.Drawing.Size(48, 48);
            this.backButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.backButton.TabIndex = 14;
            this.backButton.Text = "\r\nRegresar";
            this.backButton.Tooltip = "Regresar [F12]";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.titleLabel.ForeColor = System.Drawing.Color.Black;
            this.titleLabel.Location = new System.Drawing.Point(60, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(104, 32);
            this.titleLabel.TabIndex = 12;
            this.titleLabel.Text = "SIF\\Form";
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.statusLabel.Location = new System.Drawing.Point(67, 718);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(912, 30);
            this.statusLabel.TabIndex = 16;
            this.statusLabel.Text = "Status...";
            // 
            // superGridControl1
            // 
            this.superGridControl1.BackColor = System.Drawing.Color.White;
            this.superGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControl1.ForeColor = System.Drawing.Color.Black;
            this.superGridControl1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.superGridControl1.Location = new System.Drawing.Point(0, 0);
            this.superGridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.superGridControl1.Name = "superGridControl1";
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(915, 441);
            this.superGridControl1.TabIndex = 0;
            this.superGridControl1.Text = "Artículos";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(64, 137);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1MinSize = 50;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.superGridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(915, 584);
            this.splitContainer1.SplitterDistance = 123;
            this.splitContainer1.SplitterWidth = 20;
            this.splitContainer1.TabIndex = 13;
            // 
            // fotoPictureBox
            // 
            this.fotoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fotoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.fotoPictureBox.ForeColor = System.Drawing.Color.Black;
            this.fotoPictureBox.Image = global::SIF.Properties.Resources.PharmacistFemale;
            this.fotoPictureBox.Location = new System.Drawing.Point(915, 31);
            this.fotoPictureBox.Name = "fotoPictureBox";
            this.fotoPictureBox.Size = new System.Drawing.Size(64, 64);
            this.fotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotoPictureBox.TabIndex = 19;
            this.fotoPictureBox.TabStop = false;
            // 
            // apellidosLabel
            // 
            this.apellidosLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.apellidosLabel.AutoSize = true;
            this.apellidosLabel.BackColor = System.Drawing.Color.Transparent;
            this.apellidosLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apellidosLabel.ForeColor = System.Drawing.Color.Black;
            this.apellidosLabel.Location = new System.Drawing.Point(917, 116);
            this.apellidosLabel.Name = "apellidosLabel";
            this.apellidosLabel.Size = new System.Drawing.Size(62, 17);
            this.apellidosLabel.TabIndex = 18;
            this.apellidosLabel.Text = "Apellidos";
            this.apellidosLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nombreLabel
            // 
            this.nombreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.BackColor = System.Drawing.Color.Transparent;
            this.nombreLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreLabel.ForeColor = System.Drawing.Color.Black;
            this.nombreLabel.Location = new System.Drawing.Point(853, 95);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(126, 21);
            this.nombreLabel.TabIndex = 17;
            this.nombreLabel.Text = "Nombre Usuario";
            this.nombreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sucursalLabel
            // 
            this.sucursalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sucursalLabel.BackColor = System.Drawing.Color.Transparent;
            this.sucursalLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sucursalLabel.ForeColor = System.Drawing.Color.Black;
            this.sucursalLabel.Location = new System.Drawing.Point(679, 10);
            this.sucursalLabel.Name = "sucursalLabel";
            this.sucursalLabel.Size = new System.Drawing.Size(300, 21);
            this.sucursalLabel.TabIndex = 20;
            this.sucursalLabel.Text = "Sucursal: Matriz";
            this.sucursalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ListaUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::SIF.Properties.Resources.fondo_v3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.sucursalLabel);
            this.Controls.Add(this.fotoPictureBox);
            this.Controls.Add(this.apellidosLabel);
            this.Controls.Add(this.nombreLabel);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.statusLabel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ListaUserControl";
            this.Size = new System.Drawing.Size(1008, 752);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevComponents.DotNetBar.ButtonX backButton;
        public DevComponents.DotNetBar.Bar bar1;
        public System.Windows.Forms.Label titleLabel;
        public DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        public System.Windows.Forms.SplitContainer splitContainer1;
        public DevComponents.DotNetBar.LabelX statusLabel;
        private System.Windows.Forms.PictureBox fotoPictureBox;
        private System.Windows.Forms.Label apellidosLabel;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.Label sucursalLabel;
    }
}
