namespace SIF.View.OrdenCompra
{
    partial class NuevoListaOfertaForm
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
            this.nombreTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.sucursalesTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.cancelarButton = new DevComponents.DotNetBar.ButtonX();
            this.impArchivoButton = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.fechaInicioDateTimeInput = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.fechaTerminoDateTimeInput = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fechaInicioDateTimeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaTerminoDateTimeInput)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(40, 25);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Nombre:";
            // 
            // nombreTextBoxX
            // 
            this.nombreTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.nombreTextBoxX.Border.Class = "TextBoxBorder";
            this.nombreTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.nombreTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.nombreTextBoxX.Location = new System.Drawing.Point(101, 25);
            this.nombreTextBoxX.Name = "nombreTextBoxX";
            this.nombreTextBoxX.Size = new System.Drawing.Size(290, 20);
            this.nombreTextBoxX.TabIndex = 1;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(40, 58);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(88, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Sucursales:";
            // 
            // sucursalesTextBoxX
            // 
            this.sucursalesTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.sucursalesTextBoxX.Border.Class = "TextBoxBorder";
            this.sucursalesTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sucursalesTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.sucursalesTextBoxX.Location = new System.Drawing.Point(101, 58);
            this.sucursalesTextBoxX.Name = "sucursalesTextBoxX";
            this.sucursalesTextBoxX.Size = new System.Drawing.Size(290, 20);
            this.sucursalesTextBoxX.TabIndex = 2;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(398, 58);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(21, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 3;
            this.buttonX1.Text = "...";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(208, 161);
            this.aceptarButtonX.Name = "aceptarButtonX";
            this.aceptarButtonX.Size = new System.Drawing.Size(80, 26);
            this.aceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButtonX.TabIndex = 22;
            this.aceptarButtonX.Text = "Aceptar";
            this.aceptarButtonX.TextColor = System.Drawing.Color.White;
            this.aceptarButtonX.Click += new System.EventHandler(this.aceptarButtonX_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.cancelarButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarButton.Location = new System.Drawing.Point(311, 161);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(80, 26);
            this.cancelarButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButton.TabIndex = 21;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.TextColor = System.Drawing.Color.White;
            // 
            // impArchivoButton
            // 
            this.impArchivoButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.impArchivoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.impArchivoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.impArchivoButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.impArchivoButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.impArchivoButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.impArchivoButton.Location = new System.Drawing.Point(100, 161);
            this.impArchivoButton.Name = "impArchivoButton";
            this.impArchivoButton.Size = new System.Drawing.Size(80, 26);
            this.impArchivoButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.impArchivoButton.TabIndex = 3;
            this.impArchivoButton.Text = "Archivo";
            this.impArchivoButton.TextColor = System.Drawing.Color.White;
            this.impArchivoButton.Click += new System.EventHandler(this.impArchivoButton_Click);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(40, 87);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(88, 23);
            this.labelX3.TabIndex = 23;
            this.labelX3.Text = "Alta:";
            // 
            // fechaInicioDateTimeInput
            // 
            // 
            // 
            // 
            this.fechaInicioDateTimeInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.fechaInicioDateTimeInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechaInicioDateTimeInput.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.fechaInicioDateTimeInput.ButtonDropDown.Visible = true;
            this.fechaInicioDateTimeInput.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.fechaInicioDateTimeInput.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
            this.fechaInicioDateTimeInput.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.fechaInicioDateTimeInput.IsPopupCalendarOpen = false;
            this.fechaInicioDateTimeInput.Location = new System.Drawing.Point(101, 89);
            // 
            // 
            // 
            this.fechaInicioDateTimeInput.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.fechaInicioDateTimeInput.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechaInicioDateTimeInput.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.fechaInicioDateTimeInput.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.fechaInicioDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.fechaInicioDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.fechaInicioDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.fechaInicioDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fechaInicioDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.fechaInicioDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.fechaInicioDateTimeInput.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechaInicioDateTimeInput.MonthCalendar.DayClickAutoClosePopup = false;
            this.fechaInicioDateTimeInput.MonthCalendar.DisplayMonth = new System.DateTime(2013, 3, 1, 0, 0, 0, 0);
            this.fechaInicioDateTimeInput.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.fechaInicioDateTimeInput.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.fechaInicioDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.fechaInicioDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.fechaInicioDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.fechaInicioDateTimeInput.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechaInicioDateTimeInput.MonthCalendar.TodayButtonVisible = true;
            this.fechaInicioDateTimeInput.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.fechaInicioDateTimeInput.Name = "fechaInicioDateTimeInput";
            this.fechaInicioDateTimeInput.Size = new System.Drawing.Size(290, 20);
            this.fechaInicioDateTimeInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.fechaInicioDateTimeInput.TabIndex = 24;
            // 
            // fechaTerminoDateTimeInput
            // 
            // 
            // 
            // 
            this.fechaTerminoDateTimeInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.fechaTerminoDateTimeInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechaTerminoDateTimeInput.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.fechaTerminoDateTimeInput.ButtonDropDown.Visible = true;
            this.fechaTerminoDateTimeInput.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.fechaTerminoDateTimeInput.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
            this.fechaTerminoDateTimeInput.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.fechaTerminoDateTimeInput.IsPopupCalendarOpen = false;
            this.fechaTerminoDateTimeInput.Location = new System.Drawing.Point(101, 116);
            // 
            // 
            // 
            this.fechaTerminoDateTimeInput.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.fechaTerminoDateTimeInput.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechaTerminoDateTimeInput.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.fechaTerminoDateTimeInput.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.fechaTerminoDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.fechaTerminoDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.fechaTerminoDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.fechaTerminoDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fechaTerminoDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.fechaTerminoDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.fechaTerminoDateTimeInput.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechaTerminoDateTimeInput.MonthCalendar.DayClickAutoClosePopup = false;
            this.fechaTerminoDateTimeInput.MonthCalendar.DisplayMonth = new System.DateTime(2013, 3, 1, 0, 0, 0, 0);
            this.fechaTerminoDateTimeInput.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.fechaTerminoDateTimeInput.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.fechaTerminoDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.fechaTerminoDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.fechaTerminoDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.fechaTerminoDateTimeInput.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechaTerminoDateTimeInput.MonthCalendar.TodayButtonVisible = true;
            this.fechaTerminoDateTimeInput.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.fechaTerminoDateTimeInput.Name = "fechaTerminoDateTimeInput";
            this.fechaTerminoDateTimeInput.Size = new System.Drawing.Size(290, 20);
            this.fechaTerminoDateTimeInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.fechaTerminoDateTimeInput.TabIndex = 26;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(40, 114);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(88, 23);
            this.labelX4.TabIndex = 25;
            this.labelX4.Text = "Baja:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Archivo.......";
            // 
            // NuevoListaOfertaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 199);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fechaTerminoDateTimeInput);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.fechaInicioDateTimeInput);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.impArchivoButton);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.sucursalesTextBoxX);
            this.Controls.Add(this.nombreTextBoxX);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NuevoListaOfertaForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Ofertas";
            ((System.ComponentModel.ISupportInitialize)(this.fechaInicioDateTimeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaTerminoDateTimeInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX nombreTextBoxX;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX sucursalesTextBoxX;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private DevComponents.DotNetBar.ButtonX cancelarButton;
        private DevComponents.DotNetBar.ButtonX impArchivoButton;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput fechaInicioDateTimeInput;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput fechaTerminoDateTimeInput;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.Label label1;
    }
}