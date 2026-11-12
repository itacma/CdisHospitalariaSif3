namespace SIF.View.Ventas
{
    partial class CantidadDevueltaForm
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
            this.cantidadNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.CancelarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.cantidadDevueltaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cantidadNumericUpDown
            // 
            this.cantidadNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cantidadNumericUpDown.Location = new System.Drawing.Point(175, 44);
            this.cantidadNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cantidadNumericUpDown.Name = "cantidadNumericUpDown";
            this.cantidadNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.cantidadNumericUpDown.TabIndex = 0;
            this.cantidadNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cantidadNumericUpDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cantidadNumericUpDown_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cantidad a Devolver:";
            // 
            // CancelarButtonX
            // 
            this.CancelarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.CancelarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.CancelarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.CancelarButtonX.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarButtonX.Location = new System.Drawing.Point(215, 89);
            this.CancelarButtonX.Name = "CancelarButtonX";
            this.CancelarButtonX.Size = new System.Drawing.Size(80, 26);
            this.CancelarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CancelarButtonX.TabIndex = 2;
            this.CancelarButtonX.Text = "Cancelar";
            this.CancelarButtonX.TextColor = System.Drawing.Color.White;
            this.CancelarButtonX.Click += new System.EventHandler(this.CancelarButtonX_Click);
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(129, 89);
            this.aceptarButtonX.Name = "aceptarButtonX";
            this.aceptarButtonX.Size = new System.Drawing.Size(80, 26);
            this.aceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButtonX.TabIndex = 1;
            this.aceptarButtonX.Text = "Aceptar";
            this.aceptarButtonX.TextColor = System.Drawing.Color.White;
            this.aceptarButtonX.Click += new System.EventHandler(this.aceptarButtonX_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cantidad devuelta anteriormente:";
            // 
            // cantidadDevueltaLabel
            // 
            this.cantidadDevueltaLabel.Location = new System.Drawing.Point(175, 14);
            this.cantidadDevueltaLabel.Name = "cantidadDevueltaLabel";
            this.cantidadDevueltaLabel.Size = new System.Drawing.Size(120, 23);
            this.cantidadDevueltaLabel.TabIndex = 7;
            this.cantidadDevueltaLabel.Text = "0";
            this.cantidadDevueltaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CantidadDevueltaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 127);
            this.Controls.Add(this.cantidadDevueltaLabel);
            this.Controls.Add(this.CancelarButtonX);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cantidadNumericUpDown);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CantidadDevueltaForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CANTIDAD A DEVOLVER";
            this.Load += new System.EventHandler(this.CantidadDevueltaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cantidadNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown cantidadNumericUpDown;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX CancelarButtonX;
        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label cantidadDevueltaLabel;
    }
}