namespace SIF.View.Ventas
{
    partial class RecetaForm
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
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.cancelarButton = new DevComponents.DotNetBar.ButtonX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ValeFechaDateTimeInput = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.ValeTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.ManualRadioButton = new System.Windows.Forms.RadioButton();
            this.ElectronicaRadioButton = new System.Windows.Forms.RadioButton();
            this.titleLabel = new System.Windows.Forms.Label();
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValeFechaDateTimeInput)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(5, 6);
            this.labelX1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(105, 22);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "No Receta:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(5, 41);
            this.labelX2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(105, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Fecha Receta:";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(5, 76);
            this.labelX3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(105, 23);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "Tipo:";
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(227, 160);
            this.aceptarButtonX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.aceptarButtonX.Name = "aceptarButtonX";
            this.aceptarButtonX.Size = new System.Drawing.Size(107, 40);
            this.aceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButtonX.TabIndex = 3;
            this.aceptarButtonX.Text = "Aceptar";
            this.aceptarButtonX.TextColor = System.Drawing.Color.White;
            this.aceptarButtonX.Click += new System.EventHandler(this.aceptarButtonX_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelarButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cancelarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.cancelarButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarButton.Location = new System.Drawing.Point(355, 160);
            this.cancelarButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(107, 40);
            this.cancelarButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButton.TabIndex = 4;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.TextColor = System.Drawing.Color.White;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.12613F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.87387F));
            this.tableLayoutPanel1.Controls.Add(this.labelX3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelX2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ValeFechaDateTimeInput, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ValeTextBoxX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(21, 37);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33444F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33444F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33112F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(441, 107);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // ValeFechaDateTimeInput
            // 
            // 
            // 
            // 
            this.ValeFechaDateTimeInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ValeFechaDateTimeInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ValeFechaDateTimeInput.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.ValeFechaDateTimeInput.ButtonDropDown.Visible = true;
            this.highlighter.SetHighlightOnFocus(this.ValeFechaDateTimeInput, true);
            this.ValeFechaDateTimeInput.IsPopupCalendarOpen = false;
            this.ValeFechaDateTimeInput.Location = new System.Drawing.Point(118, 38);
            // 
            // 
            // 
            this.ValeFechaDateTimeInput.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ValeFechaDateTimeInput.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ValeFechaDateTimeInput.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.ValeFechaDateTimeInput.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.ValeFechaDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.ValeFechaDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.ValeFechaDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.ValeFechaDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ValeFechaDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ValeFechaDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.ValeFechaDateTimeInput.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ValeFechaDateTimeInput.MonthCalendar.DisplayMonth = new System.DateTime(2012, 5, 1, 0, 0, 0, 0);
            this.ValeFechaDateTimeInput.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.ValeFechaDateTimeInput.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ValeFechaDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ValeFechaDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.ValeFechaDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ValeFechaDateTimeInput.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ValeFechaDateTimeInput.MonthCalendar.TodayButtonVisible = true;
            this.ValeFechaDateTimeInput.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.ValeFechaDateTimeInput.Name = "ValeFechaDateTimeInput";
            this.ValeFechaDateTimeInput.Size = new System.Drawing.Size(320, 27);
            this.ValeFechaDateTimeInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ValeFechaDateTimeInput.TabIndex = 2;
            this.ValeFechaDateTimeInput.Click += new System.EventHandler(this.ValeFechaDateTimeInput_Click);
            // 
            // ValeTextBoxX
            // 
            this.ValeTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.ValeTextBoxX.Border.Class = "TextBoxBorder";
            this.ValeTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ValeTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.ValeTextBoxX.Location = new System.Drawing.Point(118, 3);
            this.ValeTextBoxX.MaxLength = 15;
            this.ValeTextBoxX.Name = "ValeTextBoxX";
            this.ValeTextBoxX.Size = new System.Drawing.Size(320, 27);
            this.ValeTextBoxX.TabIndex = 1;
            this.ValeTextBoxX.WatermarkText = "Receta";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.ManualRadioButton, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.ElectronicaRadioButton, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(118, 73);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(320, 31);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // ManualRadioButton
            // 
            this.ManualRadioButton.AutoSize = true;
            this.ManualRadioButton.Checked = true;
            this.ManualRadioButton.Location = new System.Drawing.Point(3, 3);
            this.ManualRadioButton.Name = "ManualRadioButton";
            this.ManualRadioButton.Size = new System.Drawing.Size(76, 24);
            this.ManualRadioButton.TabIndex = 0;
            this.ManualRadioButton.TabStop = true;
            this.ManualRadioButton.Text = "Manual";
            this.ManualRadioButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ManualRadioButton.UseVisualStyleBackColor = true;
            // 
            // ElectronicaRadioButton
            // 
            this.ElectronicaRadioButton.AutoSize = true;
            this.ElectronicaRadioButton.Location = new System.Drawing.Point(163, 3);
            this.ElectronicaRadioButton.Name = "ElectronicaRadioButton";
            this.ElectronicaRadioButton.Size = new System.Drawing.Size(100, 24);
            this.ElectronicaRadioButton.TabIndex = 1;
            this.ElectronicaRadioButton.TabStop = true;
            this.ElectronicaRadioButton.Text = "Electronica";
            this.ElectronicaRadioButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ElectronicaRadioButton.UseVisualStyleBackColor = true;
            // 
            // titleLabel
            // 
            this.titleLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Light", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.titleLabel.ForeColor = System.Drawing.Color.Black;
            this.titleLabel.Location = new System.Drawing.Point(14, -9);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(102, 41);
            this.titleLabel.TabIndex = 19;
            this.titleLabel.Text = "Receta";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.titleLabel.Click += new System.EventHandler(this.titleLabel_Click);
            // 
            // highlighter
            // 
            this.highlighter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // RecetaForm
            // 
            this.AcceptButton = this.aceptarButtonX;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelarButton;
            this.ClientSize = new System.Drawing.Size(481, 214);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.titleLabel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecetaForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LoteCaducidadForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ValeFechaDateTimeInput)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private DevComponents.DotNetBar.ButtonX cancelarButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput ValeFechaDateTimeInput;
        public System.Windows.Forms.Label titleLabel;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
        private DevComponents.DotNetBar.Controls.TextBoxX ValeTextBoxX;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.RadioButton ManualRadioButton;
        private System.Windows.Forms.RadioButton ElectronicaRadioButton;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}