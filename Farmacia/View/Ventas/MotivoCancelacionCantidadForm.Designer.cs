namespace SIF.View.Ventas
{
    partial class MotivoCancelacionCantidadForm
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
            this.motivoCancelacionComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.cantidadDevueltaLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cantidadNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cancelarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.articuloLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // motivoCancelacionComboBoxEx
            // 
            this.motivoCancelacionComboBoxEx.DisplayMember = "Text";
            this.motivoCancelacionComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.motivoCancelacionComboBoxEx.FormattingEnabled = true;
            this.motivoCancelacionComboBoxEx.ItemHeight = 14;
            this.motivoCancelacionComboBoxEx.Location = new System.Drawing.Point(12, 60);
            this.motivoCancelacionComboBoxEx.Name = "motivoCancelacionComboBoxEx";
            this.motivoCancelacionComboBoxEx.Size = new System.Drawing.Size(347, 20);
            this.motivoCancelacionComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.motivoCancelacionComboBoxEx.TabIndex = 0;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 31);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(347, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Motivo de Cancelación";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 86);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(347, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Observaciones";
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
            this.textBoxX1.Location = new System.Drawing.Point(13, 107);
            this.textBoxX1.Multiline = true;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(346, 76);
            this.textBoxX1.TabIndex = 3;
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(194, 295);
            this.aceptarButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.aceptarButtonX.Name = "aceptarButtonX";
            this.aceptarButtonX.Size = new System.Drawing.Size(80, 31);
            this.aceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButtonX.TabIndex = 21;
            this.aceptarButtonX.Text = "Aceptar";
            this.aceptarButtonX.TextColor = System.Drawing.Color.White;
            this.aceptarButtonX.Click += new System.EventHandler(this.aceptarButtonX_Click);
            // 
            // cantidadDevueltaLabel
            // 
            this.cantidadDevueltaLabel.Location = new System.Drawing.Point(13, 209);
            this.cantidadDevueltaLabel.Name = "cantidadDevueltaLabel";
            this.cantidadDevueltaLabel.Size = new System.Drawing.Size(120, 23);
            this.cantidadDevueltaLabel.TabIndex = 25;
            this.cantidadDevueltaLabel.Text = "0";
            this.cantidadDevueltaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Cantidad devuelta anteriormente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Cantidad a Devolver:";
            // 
            // cantidadNumericUpDown
            // 
            this.cantidadNumericUpDown.Location = new System.Drawing.Point(16, 257);
            this.cantidadNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cantidadNumericUpDown.Name = "cantidadNumericUpDown";
            this.cantidadNumericUpDown.Size = new System.Drawing.Size(343, 20);
            this.cantidadNumericUpDown.TabIndex = 22;
            this.cantidadNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cancelarButtonX
            // 
            this.cancelarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cancelarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.cancelarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.cancelarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarButtonX.Location = new System.Drawing.Point(279, 295);
            this.cancelarButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelarButtonX.Name = "cancelarButtonX";
            this.cancelarButtonX.Size = new System.Drawing.Size(80, 31);
            this.cancelarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButtonX.TabIndex = 21;
            this.cancelarButtonX.Text = "Cancelar";
            this.cancelarButtonX.TextColor = System.Drawing.Color.White;
            this.cancelarButtonX.Click += new System.EventHandler(this.cancelarButtonX_Click);
            // 
            // articuloLabel
            // 
            this.articuloLabel.AutoSize = true;
            this.articuloLabel.Location = new System.Drawing.Point(16, 12);
            this.articuloLabel.Name = "articuloLabel";
            this.articuloLabel.Size = new System.Drawing.Size(67, 13);
            this.articuloLabel.TabIndex = 26;
            this.articuloLabel.Text = "[ARTICULO]";
            // 
            // MotivoCancelacionCantidadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 339);
            this.ControlBox = false;
            this.Controls.Add(this.articuloLabel);
            this.Controls.Add(this.cantidadDevueltaLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cantidadNumericUpDown);
            this.Controls.Add(this.cancelarButtonX);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.motivoCancelacionComboBoxEx);
            this.Name = "MotivoCancelacionCantidadForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MOTIVO DE CANCELACION";
            this.Load += new System.EventHandler(this.MotivoCancelacionCantidadForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cantidadNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx motivoCancelacionComboBoxEx;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private System.Windows.Forms.Label cantidadDevueltaLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown cantidadNumericUpDown;
        private DevComponents.DotNetBar.ButtonX cancelarButtonX;
        private System.Windows.Forms.Label articuloLabel;
    }
}