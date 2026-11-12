namespace SIF.View.OrdenCompra
{
    partial class FoliosGeneradosForm
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
            this.foliosLabelX = new DevComponents.DotNetBar.LabelX();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.foliosGeneradosLabelX = new DevComponents.DotNetBar.LabelX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // foliosLabelX
            // 
            this.foliosLabelX.AutoSize = true;
            // 
            // 
            // 
            this.foliosLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.foliosLabelX.Location = new System.Drawing.Point(14, 3);
            this.foliosLabelX.Name = "foliosLabelX";
            this.foliosLabelX.Size = new System.Drawing.Size(49, 15);
            this.foliosLabelX.TabIndex = 0;
            this.foliosLabelX.Text = "[FOLIOS]";
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(192, 218);
            this.aceptarButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.aceptarButtonX.Name = "aceptarButtonX";
            this.aceptarButtonX.Size = new System.Drawing.Size(80, 31);
            this.aceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButtonX.TabIndex = 35;
            this.aceptarButtonX.Text = "Aceptar";
            this.aceptarButtonX.TextColor = System.Drawing.Color.White;
            this.aceptarButtonX.Click += new System.EventHandler(this.aceptarButtonX_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.foliosLabelX);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 208);
            this.panel1.TabIndex = 36;
            // 
            // foliosGeneradosLabelX
            // 
            // 
            // 
            // 
            this.foliosGeneradosLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.foliosGeneradosLabelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foliosGeneradosLabelX.Location = new System.Drawing.Point(12, 218);
            this.foliosGeneradosLabelX.Name = "foliosGeneradosLabelX";
            this.foliosGeneradosLabelX.Size = new System.Drawing.Size(174, 23);
            this.foliosGeneradosLabelX.TabIndex = 38;
            this.foliosGeneradosLabelX.Text = "labelX2";
            // 
            // FoliosGeneradosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.foliosGeneradosLabelX);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.aceptarButtonX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FoliosGeneradosForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folios";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private System.Windows.Forms.Panel panel1;
        public DevComponents.DotNetBar.LabelX foliosLabelX;
        public DevComponents.DotNetBar.LabelX foliosGeneradosLabelX;
    }
}