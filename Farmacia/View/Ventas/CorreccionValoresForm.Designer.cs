namespace SIF.View.Ventas
{
    partial class CorreccionValoresForm
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
            this.correccionTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.recoleccionLabel = new System.Windows.Forms.Label();
            this.montoLabel = new System.Windows.Forms.Label();
            this.CancelarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.denominacionLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.integerInput1 = new DevComponents.Editors.IntegerInput();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recolección:";
            // 
            // correccionTextBoxX
            // 
            this.correccionTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.correccionTextBoxX.Border.Class = "TextBoxBorder";
            this.correccionTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.correccionTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.correccionTextBoxX.Location = new System.Drawing.Point(124, 160);
            this.correccionTextBoxX.Name = "correccionTextBoxX";
            this.correccionTextBoxX.Size = new System.Drawing.Size(211, 20);
            this.correccionTextBoxX.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Monto Corregido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Monto:";
            // 
            // recoleccionLabel
            // 
            this.recoleccionLabel.AutoSize = true;
            this.recoleccionLabel.Location = new System.Drawing.Point(119, 29);
            this.recoleccionLabel.Name = "recoleccionLabel";
            this.recoleccionLabel.Size = new System.Drawing.Size(89, 13);
            this.recoleccionLabel.TabIndex = 4;
            this.recoleccionLabel.Text = "[RECOLECCIÓN]";
            // 
            // montoLabel
            // 
            this.montoLabel.AutoSize = true;
            this.montoLabel.Location = new System.Drawing.Point(119, 85);
            this.montoLabel.Name = "montoLabel";
            this.montoLabel.Size = new System.Drawing.Size(53, 13);
            this.montoLabel.TabIndex = 5;
            this.montoLabel.Text = "[MONTO]";
            // 
            // CancelarButtonX
            // 
            this.CancelarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.CancelarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.CancelarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.CancelarButtonX.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarButtonX.Location = new System.Drawing.Point(255, 198);
            this.CancelarButtonX.Name = "CancelarButtonX";
            this.CancelarButtonX.Size = new System.Drawing.Size(80, 26);
            this.CancelarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CancelarButtonX.TabIndex = 7;
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
            this.aceptarButtonX.Location = new System.Drawing.Point(169, 198);
            this.aceptarButtonX.Name = "aceptarButtonX";
            this.aceptarButtonX.Size = new System.Drawing.Size(80, 26);
            this.aceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButtonX.TabIndex = 6;
            this.aceptarButtonX.Text = "Aceptar";
            this.aceptarButtonX.TextColor = System.Drawing.Color.White;
            this.aceptarButtonX.Click += new System.EventHandler(this.aceptarButtonX_Click);
            // 
            // denominacionLabel
            // 
            this.denominacionLabel.AutoSize = true;
            this.denominacionLabel.Location = new System.Drawing.Point(119, 54);
            this.denominacionLabel.Name = "denominacionLabel";
            this.denominacionLabel.Size = new System.Drawing.Size(97, 13);
            this.denominacionLabel.TabIndex = 9;
            this.denominacionLabel.Text = "[DENOMINACION]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "DENOMINACION:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cantidad:";
            // 
            // integerInput1
            // 
            // 
            // 
            // 
            this.integerInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput1.Location = new System.Drawing.Point(122, 126);
            this.integerInput1.MinValue = 1;
            this.integerInput1.Name = "integerInput1";
            this.integerInput1.ShowUpDown = true;
            this.integerInput1.Size = new System.Drawing.Size(213, 20);
            this.integerInput1.TabIndex = 10;
            this.integerInput1.Value = 1;
            // 
            // CorreccionValoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 236);
            this.ControlBox = false;
            this.Controls.Add(this.integerInput1);
            this.Controls.Add(this.denominacionLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CancelarButtonX);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.montoLabel);
            this.Controls.Add(this.recoleccionLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.correccionTextBoxX);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CorreccionValoresForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Valor";
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX correccionTextBoxX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label recoleccionLabel;
        private System.Windows.Forms.Label montoLabel;
        private DevComponents.DotNetBar.ButtonX CancelarButtonX;
        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private System.Windows.Forms.Label denominacionLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevComponents.Editors.IntegerInput integerInput1;
    }
}