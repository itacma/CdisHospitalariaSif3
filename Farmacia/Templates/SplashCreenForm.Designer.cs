namespace SIF.Templates
{
    partial class SplashCreenForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashCreenForm));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.labelX1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(107)))), ((int)(((byte)(250)))));
            this.labelX1.Location = new System.Drawing.Point(12, 421);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(711, 44);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "SISTEMA INTEGRAL DE FARMACIA Ver. 3.0";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.labelX2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(107)))), ((int)(((byte)(250)))));
            this.labelX2.Location = new System.Drawing.Point(12, 471);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(711, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Todos los derechos reservados por Farmacias Fleming ®";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX3
            // 
            this.labelX3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Trebuchet MS", 30F, System.Drawing.FontStyle.Italic);
            this.labelX3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(107)))), ((int)(((byte)(250)))));
            this.labelX3.Location = new System.Drawing.Point(0, 12);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(735, 44);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "BIENVENIDO";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 3000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SIF.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(735, 394);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // SplashCreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(735, 515);
            this.ControlBox = false;
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelX2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashCreenForm";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.SplashCreenForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.Timer timer;
    }
}