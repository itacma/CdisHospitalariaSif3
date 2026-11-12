namespace SIF.View.Ventas
{
    partial class DescuentoForm
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
            DevComponents.DotNetBar.LabelX labelX1;
            DevComponents.DotNetBar.LabelX labelX2;
            DevComponents.DotNetBar.LabelX labelX3;
            this.titleLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.beneficioComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.porcentajeLabelX = new DevComponents.DotNetBar.LabelX();
            this.folioCredencialTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cancelarButton = new DevComponents.DotNetBar.ButtonX();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.Location = new System.Drawing.Point(3, 4);
            labelX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(132, 29);
            labelX1.TabIndex = 0;
            labelX1.Text = "Tipo de Descuento:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.Location = new System.Drawing.Point(3, 41);
            labelX2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            labelX2.Name = "labelX2";
            labelX2.Size = new System.Drawing.Size(155, 30);
            labelX2.TabIndex = 1;
            labelX2.Text = "Porcentaje de Descuento:";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX3.Location = new System.Drawing.Point(3, 79);
            labelX3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            labelX3.Name = "labelX3";
            labelX3.Size = new System.Drawing.Size(128, 30);
            labelX3.TabIndex = 2;
            labelX3.Text = "Folio de Credencial:";
            // 
            // titleLabel
            // 
            this.titleLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Light", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.titleLabel.ForeColor = System.Drawing.Color.Black;
            this.titleLabel.Location = new System.Drawing.Point(21, -9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(151, 41);
            this.titleLabel.TabIndex = 13;
            this.titleLabel.Text = "Descuento";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(labelX2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(labelX3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.beneficioComboBoxEx, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.porcentajeLabelX, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.folioCredencialTextBoxX, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(28, 36);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(401, 114);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // beneficioComboBoxEx
            // 
            this.beneficioComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.beneficioComboBoxEx.DisplayMember = "Text";
            this.beneficioComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.beneficioComboBoxEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.beneficioComboBoxEx.FormattingEnabled = true;
            this.highlighter.SetHighlightOnFocus(this.beneficioComboBoxEx, true);
            this.beneficioComboBoxEx.ItemHeight = 19;
            this.beneficioComboBoxEx.Location = new System.Drawing.Point(164, 6);
            this.beneficioComboBoxEx.Name = "beneficioComboBoxEx";
            this.beneficioComboBoxEx.Size = new System.Drawing.Size(234, 25);
            this.beneficioComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.beneficioComboBoxEx.TabIndex = 3;
            this.beneficioComboBoxEx.SelectedIndexChanged += new System.EventHandler(this.beneficioComboBoxEx_SelectedIndexChanged);
            // 
            // porcentajeLabelX
            // 
            this.porcentajeLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.porcentajeLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.porcentajeLabelX.Location = new System.Drawing.Point(164, 44);
            this.porcentajeLabelX.Name = "porcentajeLabelX";
            this.porcentajeLabelX.Size = new System.Drawing.Size(234, 23);
            this.porcentajeLabelX.TabIndex = 4;
            this.porcentajeLabelX.Text = "0%";
            // 
            // folioCredencialTextBoxX
            // 
            this.folioCredencialTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.folioCredencialTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.folioCredencialTextBoxX.Border.Class = "TextBoxBorder";
            this.folioCredencialTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.folioCredencialTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.highlighter.SetHighlightOnFocus(this.folioCredencialTextBoxX, true);
            this.folioCredencialTextBoxX.Location = new System.Drawing.Point(164, 82);
            this.folioCredencialTextBoxX.Name = "folioCredencialTextBoxX";
            this.folioCredencialTextBoxX.Size = new System.Drawing.Size(234, 25);
            this.folioCredencialTextBoxX.TabIndex = 5;
            this.folioCredencialTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.folioCredencialTextBoxX_KeyDown);
            // 
            // cancelarButton
            // 
            this.cancelarButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelarButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cancelarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.cancelarButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.cancelarButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarButton.Location = new System.Drawing.Point(346, 157);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(80, 26);
            this.cancelarButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButton.TabIndex = 15;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.TextColor = System.Drawing.Color.White;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(243, 157);
            this.aceptarButtonX.Name = "aceptarButtonX";
            this.aceptarButtonX.Size = new System.Drawing.Size(80, 26);
            this.aceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButtonX.TabIndex = 16;
            this.aceptarButtonX.Text = "Aceptar";
            this.aceptarButtonX.TextColor = System.Drawing.Color.White;
            this.aceptarButtonX.Click += new System.EventHandler(this.aceptarButtonX_Click);
            // 
            // highlighter
            // 
            this.highlighter.ContainerControl = this;
            this.highlighter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // DescuentoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 206);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DescuentoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DescuentoForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx beneficioComboBoxEx;
        private DevComponents.DotNetBar.LabelX porcentajeLabelX;
        private DevComponents.DotNetBar.Controls.TextBoxX folioCredencialTextBoxX;
        private DevComponents.DotNetBar.ButtonX cancelarButton;
        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
    }
}