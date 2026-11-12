namespace SIF.View.Catalogos
{
    partial class AgregaArticuloInvFisForm
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
            this.codigoTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.conteoTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cancelarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.AceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(96, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Código Artículo:";
            // 
            // codigoTextBoxX
            // 
            this.codigoTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codigoTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.codigoTextBoxX.Border.Class = "TextBoxBorder";
            this.codigoTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.codigoTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.codigoTextBoxX.Location = new System.Drawing.Point(12, 41);
            this.codigoTextBoxX.Name = "codigoTextBoxX";
            this.codigoTextBoxX.Size = new System.Drawing.Size(330, 22);
            this.codigoTextBoxX.TabIndex = 0;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 78);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(96, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Conteo:";
            // 
            // conteoTextBoxX
            // 
            this.conteoTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.conteoTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.conteoTextBoxX.Border.Class = "TextBoxBorder";
            this.conteoTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.conteoTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.conteoTextBoxX.Location = new System.Drawing.Point(12, 107);
            this.conteoTextBoxX.Name = "conteoTextBoxX";
            this.conteoTextBoxX.Size = new System.Drawing.Size(330, 22);
            this.conteoTextBoxX.TabIndex = 2;
            // 
            // cancelarButtonX
            // 
            this.cancelarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.cancelarButtonX.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButtonX.Location = new System.Drawing.Point(258, 156);
            this.cancelarButtonX.Name = "cancelarButtonX";
            this.cancelarButtonX.Size = new System.Drawing.Size(75, 23);
            this.cancelarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButtonX.TabIndex = 7;
            this.cancelarButtonX.Text = "Cancelar";
            this.cancelarButtonX.Click += new System.EventHandler(this.cancelarButtonX_Click);
            // 
            // AceptarButtonX
            // 
            this.AceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.AceptarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.AceptarButtonX.Location = new System.Drawing.Point(166, 156);
            this.AceptarButtonX.Name = "AceptarButtonX";
            this.AceptarButtonX.Size = new System.Drawing.Size(75, 23);
            this.AceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.AceptarButtonX.TabIndex = 6;
            this.AceptarButtonX.Text = "Aceptar";
            this.AceptarButtonX.Click += new System.EventHandler(this.AceptarButtonX_Click);
            // 
            // AgregaArticuloInvFisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelarButtonX;
            this.ClientSize = new System.Drawing.Size(354, 197);
            this.Controls.Add(this.cancelarButtonX);
            this.Controls.Add(this.AceptarButtonX);
            this.Controls.Add(this.conteoTextBoxX);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.codigoTextBoxX);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregaArticuloInvFisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario Físico";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX codigoTextBoxX;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX conteoTextBoxX;
        private DevComponents.DotNetBar.ButtonX cancelarButtonX;
        private DevComponents.DotNetBar.ButtonX AceptarButtonX;
    }
}