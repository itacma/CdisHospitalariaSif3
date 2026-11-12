namespace SIF.Templates
{
    partial class MenuUserControl
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
            this.backButton = new DevComponents.DotNetBar.ButtonX();
            this.titlelabelX = new DevComponents.DotNetBar.LabelX();
            this.salirButton = new DevComponents.DotNetBar.ButtonX();
            this.subMenuLabelX = new DevComponents.DotNetBar.LabelX();
            this.fotoPictureBox = new System.Windows.Forms.PictureBox();
            this.apellidosLabel = new System.Windows.Forms.Label();
            this.nombreUsuarioLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.backButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.backButton.FadeEffect = false;
            this.backButton.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.backButton.Image = global::SIF.Properties.Resources.Arrow_Left;
            this.backButton.Location = new System.Drawing.Point(9, 21);
            this.backButton.Name = "backButton";
            this.backButton.PressedImage = global::SIF.Properties.Resources.Arrow_Left_1;
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.backButton.Size = new System.Drawing.Size(48, 48);
            this.backButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.backButton.TabIndex = 17;
            this.backButton.Tooltip = "Regresar [F12]";
            // 
            // titlelabelX
            // 
            this.titlelabelX.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.titlelabelX.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.titlelabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.titlelabelX.Font = new System.Drawing.Font("AddCityboy", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlelabelX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(97)))), ((int)(((byte)(157)))));
            this.titlelabelX.Location = new System.Drawing.Point(63, 12);
            this.titlelabelX.Name = "titlelabelX";
            this.titlelabelX.Size = new System.Drawing.Size(485, 67);
            this.titlelabelX.TabIndex = 15;
            this.titlelabelX.Text = "<font  color = \"#2E6BFA\">SIFs Fleming</font>";
            // 
            // salirButton
            // 
            this.salirButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.salirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.salirButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.salirButton.Image = global::SIF.Properties.Resources.Exit;
            this.salirButton.Location = new System.Drawing.Point(888, 628);
            this.salirButton.Name = "salirButton";
            this.salirButton.Size = new System.Drawing.Size(69, 66);
            this.salirButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.salirButton.TabIndex = 18;
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
            this.subMenuLabelX.Text = "<font  color = \"#2E619D\"> Sub Menu</font>";
            // 
            // fotoPictureBox
            // 
            this.fotoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fotoPictureBox.BackColor = System.Drawing.Color.White;
            this.fotoPictureBox.ForeColor = System.Drawing.Color.Black;
            this.fotoPictureBox.Location = new System.Drawing.Point(888, 15);
            this.fotoPictureBox.Name = "fotoPictureBox";
            this.fotoPictureBox.Size = new System.Drawing.Size(64, 64);
            this.fotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotoPictureBox.TabIndex = 23;
            this.fotoPictureBox.TabStop = false;
            // 
            // apellidosLabel
            // 
            this.apellidosLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.apellidosLabel.BackColor = System.Drawing.Color.Transparent;
            this.apellidosLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apellidosLabel.ForeColor = System.Drawing.Color.Black;
            this.apellidosLabel.Location = new System.Drawing.Point(570, 35);
            this.apellidosLabel.Name = "apellidosLabel";
            this.apellidosLabel.Size = new System.Drawing.Size(312, 17);
            this.apellidosLabel.TabIndex = 22;
            this.apellidosLabel.Text = "Apellidos";
            this.apellidosLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nombreUsuarioLabel
            // 
            this.nombreUsuarioLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nombreUsuarioLabel.BackColor = System.Drawing.Color.Transparent;
            this.nombreUsuarioLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreUsuarioLabel.ForeColor = System.Drawing.Color.Black;
            this.nombreUsuarioLabel.Location = new System.Drawing.Point(566, 14);
            this.nombreUsuarioLabel.Name = "nombreUsuarioLabel";
            this.nombreUsuarioLabel.Size = new System.Drawing.Size(316, 21);
            this.nombreUsuarioLabel.TabIndex = 21;
            this.nombreUsuarioLabel.Text = "Nombre Usuario";
            this.nombreUsuarioLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MenuUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.salirButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.titlelabelX);
            this.Controls.Add(this.fotoPictureBox);
            this.Controls.Add(this.apellidosLabel);
            this.Controls.Add(this.nombreUsuarioLabel);
            this.Controls.Add(this.subMenuLabelX);
            this.Name = "MenuUserControl";
            this.Size = new System.Drawing.Size(1008, 752);
            this.Load += new System.EventHandler(this.MenuUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.ButtonX backButton;
        public DevComponents.DotNetBar.LabelX titlelabelX;
        public DevComponents.DotNetBar.ButtonX salirButton;
        public DevComponents.DotNetBar.LabelX subMenuLabelX;
        private System.Windows.Forms.PictureBox fotoPictureBox;
        private System.Windows.Forms.Label apellidosLabel;
        private System.Windows.Forms.Label nombreUsuarioLabel;
    }
}
