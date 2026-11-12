namespace SIF.View.Catalogos
{
    partial class UsuarioIDForm
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.AceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.cancelarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(13, 37);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Acceso:";
            // 
            // AceptarButtonX
            // 
            this.AceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.AceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.AceptarButtonX.Location = new System.Drawing.Point(85, 84);
            this.AceptarButtonX.Name = "AceptarButtonX";
            this.AceptarButtonX.Size = new System.Drawing.Size(75, 23);
            this.AceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.AceptarButtonX.TabIndex = 2;
            this.AceptarButtonX.Text = "Aceptar";
            this.AceptarButtonX.Click += new System.EventHandler(this.AceptarButtonX_Click);
            // 
            // cancelarButtonX
            // 
            this.cancelarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.cancelarButtonX.Location = new System.Drawing.Point(189, 84);
            this.cancelarButtonX.Name = "cancelarButtonX";
            this.cancelarButtonX.Size = new System.Drawing.Size(75, 23);
            this.cancelarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButtonX.TabIndex = 3;
            this.cancelarButtonX.Text = "Cancelar";
            this.cancelarButtonX.Click += new System.EventHandler(this.cancelarButtonX_Click);
            // 
            // textBoxX1
            // 
            this.textBoxX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.ForeColor = System.Drawing.Color.Black;
            this.textBoxX1.Location = new System.Drawing.Point(60, 37);
            this.textBoxX1.MaxLength = 10;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(204, 20);
            this.textBoxX1.TabIndex = 1;
            this.textBoxX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxX1_KeyDown);
            // 
            // UsuarioIDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 119);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.cancelarButtonX);
            this.Controls.Add(this.AceptarButtonX);
            this.Controls.Add(this.labelX1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsuarioIDForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.UsuarioIDForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX AceptarButtonX;
        private DevComponents.DotNetBar.ButtonX cancelarButtonX;
        public DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
    }
}