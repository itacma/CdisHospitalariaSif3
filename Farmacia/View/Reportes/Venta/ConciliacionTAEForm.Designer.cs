namespace SIF.View.Reportes.Venta
{
    partial class ConciliacionTAEForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_GetConciliaMul = new DevComponents.DotNetBar.ButtonX();
            this.btn_GetConciliaTae = new DevComponents.DotNetBar.ButtonX();
            this.cmb_CarriersTae = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.labelX65 = new DevComponents.DotNetBar.LabelX();
            this.GridConciliaTae = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.RespIdRecarga = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btn_GetVtasTae = new DevComponents.DotNetBar.ButtonX();
            this.dti_TaeFin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX63 = new DevComponents.DotNetBar.LabelX();
            this.dti_TaeIni = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX64 = new DevComponents.DotNetBar.LabelX();
            this.queryButtonX = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.GridConciliaTae)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dti_TaeFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dti_TaeIni)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_GetConciliaMul
            // 
            this.btn_GetConciliaMul.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_GetConciliaMul.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_GetConciliaMul.Location = new System.Drawing.Point(792, 13);
            this.btn_GetConciliaMul.Name = "btn_GetConciliaMul";
            this.btn_GetConciliaMul.Size = new System.Drawing.Size(75, 28);
            this.btn_GetConciliaMul.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_GetConciliaMul.TabIndex = 61;
            this.btn_GetConciliaMul.Text = "Crear Archivo\r\nMultirecargas";
            this.btn_GetConciliaMul.Click += new System.EventHandler(this.btn_GetConciliaMul_Click);
            // 
            // btn_GetConciliaTae
            // 
            this.btn_GetConciliaTae.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_GetConciliaTae.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_GetConciliaTae.Location = new System.Drawing.Point(711, 13);
            this.btn_GetConciliaTae.Name = "btn_GetConciliaTae";
            this.btn_GetConciliaTae.Size = new System.Drawing.Size(75, 28);
            this.btn_GetConciliaTae.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_GetConciliaTae.TabIndex = 60;
            this.btn_GetConciliaTae.Text = "Crear Archivo\r\nTAE";
            this.btn_GetConciliaTae.Click += new System.EventHandler(this.btn_GetConciliaTae_Click);
            // 
            // cmb_CarriersTae
            // 
            this.cmb_CarriersTae.DisplayMember = "Text";
            this.cmb_CarriersTae.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_CarriersTae.ForeColor = System.Drawing.Color.Black;
            this.cmb_CarriersTae.FormattingEnabled = true;
            this.cmb_CarriersTae.ItemHeight = 16;
            this.cmb_CarriersTae.Items.AddRange(new object[] {
            this.comboItem3,
            this.comboItem4});
            this.cmb_CarriersTae.Location = new System.Drawing.Point(70, 12);
            this.cmb_CarriersTae.Name = "cmb_CarriersTae";
            this.cmb_CarriersTae.Size = new System.Drawing.Size(150, 22);
            this.cmb_CarriersTae.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmb_CarriersTae.TabIndex = 58;
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "ReCargar - Reload";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "Consulta - Query";
            // 
            // labelX65
            // 
            this.labelX65.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX65.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX65.ForeColor = System.Drawing.Color.Black;
            this.labelX65.Location = new System.Drawing.Point(9, 11);
            this.labelX65.Name = "labelX65";
            this.labelX65.Size = new System.Drawing.Size(55, 23);
            this.labelX65.TabIndex = 59;
            this.labelX65.Text = "Carrier :";
            this.labelX65.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // GridConciliaTae
            // 
            this.GridConciliaTae.AllowUserToAddRows = false;
            this.GridConciliaTae.AllowUserToDeleteRows = false;
            this.GridConciliaTae.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GridConciliaTae.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridConciliaTae.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridConciliaTae.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridConciliaTae.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RespIdRecarga});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridConciliaTae.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridConciliaTae.EnableHeadersVisualStyles = false;
            this.GridConciliaTae.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.GridConciliaTae.Location = new System.Drawing.Point(22, 65);
            this.GridConciliaTae.Name = "GridConciliaTae";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridConciliaTae.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GridConciliaTae.Size = new System.Drawing.Size(860, 375);
            this.GridConciliaTae.TabIndex = 57;
            // 
            // RespIdRecarga
            // 
            this.RespIdRecarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RespIdRecarga.HeaderText = "Sts";
            this.RespIdRecarga.Name = "RespIdRecarga";
            this.RespIdRecarga.ReadOnly = true;
            this.RespIdRecarga.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RespIdRecarga.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RespIdRecarga.Width = 47;
            // 
            // btn_GetVtasTae
            // 
            this.btn_GetVtasTae.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_GetVtasTae.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_GetVtasTae.Location = new System.Drawing.Point(625, 13);
            this.btn_GetVtasTae.Name = "btn_GetVtasTae";
            this.btn_GetVtasTae.Size = new System.Drawing.Size(75, 28);
            this.btn_GetVtasTae.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_GetVtasTae.TabIndex = 56;
            this.btn_GetVtasTae.Text = "Consultar";
            this.btn_GetVtasTae.Click += new System.EventHandler(this.btn_GetVtasTae_Click);
            // 
            // dti_TaeFin
            // 
            this.dti_TaeFin.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dti_TaeFin.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dti_TaeFin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_TaeFin.ButtonClear.Visible = true;
            this.dti_TaeFin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dti_TaeFin.ButtonDropDown.Visible = true;
            this.dti_TaeFin.CustomFormat = "dd/MM/yyyy";
            this.dti_TaeFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dti_TaeFin.ForeColor = System.Drawing.Color.Black;
            this.dti_TaeFin.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dti_TaeFin.IsPopupCalendarOpen = false;
            this.dti_TaeFin.Location = new System.Drawing.Point(474, 13);
            // 
            // 
            // 
            this.dti_TaeFin.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dti_TaeFin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_TaeFin.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dti_TaeFin.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dti_TaeFin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dti_TaeFin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_TaeFin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dti_TaeFin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dti_TaeFin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dti_TaeFin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dti_TaeFin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_TaeFin.MonthCalendar.DisplayMonth = new System.DateTime(2012, 8, 1, 0, 0, 0, 0);
            this.dti_TaeFin.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dti_TaeFin.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dti_TaeFin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dti_TaeFin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_TaeFin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dti_TaeFin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_TaeFin.MonthCalendar.TodayButtonVisible = true;
            this.dti_TaeFin.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dti_TaeFin.Name = "dti_TaeFin";
            this.dti_TaeFin.ShowUpDown = true;
            this.dti_TaeFin.Size = new System.Drawing.Size(123, 21);
            this.dti_TaeFin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dti_TaeFin.TabIndex = 55;
            // 
            // labelX63
            // 
            this.labelX63.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX63.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX63.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX63.ForeColor = System.Drawing.Color.Black;
            this.labelX63.Location = new System.Drawing.Point(439, 11);
            this.labelX63.Name = "labelX63";
            this.labelX63.Size = new System.Drawing.Size(28, 23);
            this.labelX63.TabIndex = 54;
            this.labelX63.Text = " al ";
            this.labelX63.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // dti_TaeIni
            // 
            this.dti_TaeIni.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dti_TaeIni.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dti_TaeIni.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_TaeIni.ButtonClear.Visible = true;
            this.dti_TaeIni.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dti_TaeIni.ButtonDropDown.Visible = true;
            this.dti_TaeIni.CustomFormat = "dd/MM/yyyy";
            this.dti_TaeIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dti_TaeIni.ForeColor = System.Drawing.Color.Black;
            this.dti_TaeIni.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dti_TaeIni.IsPopupCalendarOpen = false;
            this.dti_TaeIni.Location = new System.Drawing.Point(311, 13);
            // 
            // 
            // 
            this.dti_TaeIni.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dti_TaeIni.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_TaeIni.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dti_TaeIni.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dti_TaeIni.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dti_TaeIni.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_TaeIni.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dti_TaeIni.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dti_TaeIni.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dti_TaeIni.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dti_TaeIni.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_TaeIni.MonthCalendar.DisplayMonth = new System.DateTime(2012, 8, 1, 0, 0, 0, 0);
            this.dti_TaeIni.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dti_TaeIni.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dti_TaeIni.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dti_TaeIni.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_TaeIni.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dti_TaeIni.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_TaeIni.MonthCalendar.TodayButtonVisible = true;
            this.dti_TaeIni.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dti_TaeIni.Name = "dti_TaeIni";
            this.dti_TaeIni.ShowUpDown = true;
            this.dti_TaeIni.Size = new System.Drawing.Size(123, 21);
            this.dti_TaeIni.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dti_TaeIni.TabIndex = 53;
            this.dti_TaeIni.Value = new System.DateTime(2012, 8, 1, 0, 0, 0, 0);
            // 
            // labelX64
            // 
            this.labelX64.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX64.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX64.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX64.ForeColor = System.Drawing.Color.Black;
            this.labelX64.Location = new System.Drawing.Point(226, 11);
            this.labelX64.Name = "labelX64";
            this.labelX64.Size = new System.Drawing.Size(72, 23);
            this.labelX64.TabIndex = 52;
            this.labelX64.Text = "Periodo del ";
            this.labelX64.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // queryButtonX
            // 
            this.queryButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.queryButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.queryButtonX.Location = new System.Drawing.Point(807, 446);
            this.queryButtonX.Name = "queryButtonX";
            this.queryButtonX.Size = new System.Drawing.Size(75, 28);
            this.queryButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.queryButtonX.TabIndex = 62;
            this.queryButtonX.Text = "Query";
            this.queryButtonX.Click += new System.EventHandler(this.queryButtonX_Click);
            // 
            // ConciliacionTAEForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 476);
            this.Controls.Add(this.queryButtonX);
            this.Controls.Add(this.btn_GetConciliaMul);
            this.Controls.Add(this.btn_GetConciliaTae);
            this.Controls.Add(this.cmb_CarriersTae);
            this.Controls.Add(this.labelX65);
            this.Controls.Add(this.GridConciliaTae);
            this.Controls.Add(this.btn_GetVtasTae);
            this.Controls.Add(this.dti_TaeFin);
            this.Controls.Add(this.labelX63);
            this.Controls.Add(this.dti_TaeIni);
            this.Controls.Add(this.labelX64);
            this.Name = "ConciliacionTAEForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conciliacion TAE";
            this.Load += new System.EventHandler(this.ConciliacionTAEForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridConciliaTae)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dti_TaeFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dti_TaeIni)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btn_GetConciliaMul;
        private DevComponents.DotNetBar.ButtonX btn_GetConciliaTae;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmb_CarriersTae;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.DotNetBar.LabelX labelX65;
        private DevComponents.DotNetBar.Controls.DataGridViewX GridConciliaTae;
        private DevComponents.DotNetBar.ButtonX btn_GetVtasTae;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dti_TaeFin;
        private DevComponents.DotNetBar.LabelX labelX63;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dti_TaeIni;
        private DevComponents.DotNetBar.LabelX labelX64;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RespIdRecarga;
        private DevComponents.DotNetBar.ButtonX queryButtonX;

    }
}