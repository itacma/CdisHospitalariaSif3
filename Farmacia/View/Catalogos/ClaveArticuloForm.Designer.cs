namespace SIF.View.Catalogos
{
    partial class ClaveArticuloForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.claveTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.cancelarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.AceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave Producto:";
            // 
            // claveTextBoxX
            // 
            this.claveTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.claveTextBoxX.Border.Class = "TextBoxBorder";
            this.claveTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.claveTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.highlighter1.SetHighlightColor(this.claveTextBoxX, DevComponents.DotNetBar.Validator.eHighlightColor.Blue);
            this.claveTextBoxX.Location = new System.Drawing.Point(105, 35);
            this.claveTextBoxX.MaxLength = 40;
            this.claveTextBoxX.Name = "claveTextBoxX";
            this.claveTextBoxX.Size = new System.Drawing.Size(265, 22);
            this.claveTextBoxX.TabIndex = 1;
            this.claveTextBoxX.WatermarkText = "Clave";
            this.claveTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxX1_KeyDown);
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // cancelarButtonX
            // 
            this.cancelarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.cancelarButtonX.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButtonX.Location = new System.Drawing.Point(197, 77);
            this.cancelarButtonX.Name = "cancelarButtonX";
            this.cancelarButtonX.Size = new System.Drawing.Size(75, 23);
            this.cancelarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButtonX.TabIndex = 5;
            this.cancelarButtonX.Text = "Cancelar";
            this.cancelarButtonX.Click += new System.EventHandler(this.cancelarButtonX_Click);
            // 
            // AceptarButtonX
            // 
            this.AceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.AceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.AceptarButtonX.Location = new System.Drawing.Point(105, 77);
            this.AceptarButtonX.Name = "AceptarButtonX";
            this.AceptarButtonX.Size = new System.Drawing.Size(75, 23);
            this.AceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.AceptarButtonX.TabIndex = 4;
            this.AceptarButtonX.Text = "Aceptar";
            this.AceptarButtonX.Click += new System.EventHandler(this.AceptarButtonX_Click);
            // 
            // ClaveArticuloForm
            // 
            this.AcceptButton = this.AceptarButtonX;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelarButtonX;
            this.ClientSize = new System.Drawing.Size(372, 112);
            this.Controls.Add(this.cancelarButtonX);
            this.Controls.Add(this.AceptarButtonX);
            this.Controls.Add(this.claveTextBoxX);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClaveArticuloForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ClaveArticuloForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX claveTextBoxX;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.ButtonX cancelarButtonX;
        private DevComponents.DotNetBar.ButtonX AceptarButtonX;
    }
}