namespace SIF.View.Configuracion
{
    partial class ConciliacionNadroForm
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
            this.btn_CreaConciliapFizer = new DevComponents.DotNetBar.ButtonX();
            this.btn_GetVaspFizer = new DevComponents.DotNetBar.ButtonX();
            this.dti_pFizerFin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX62 = new DevComponents.DotNetBar.LabelX();
            this.dti_pFizerIni = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX61 = new DevComponents.DotNetBar.LabelX();
            this.GridConciliapFizer = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.CadenaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folio = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.SucursalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FecMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantCompra = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.CantBenef = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.CotizacionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfirmaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActivoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dti_pFizerFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dti_pFizerIni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridConciliapFizer)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_CreaConciliapFizer
            // 
            this.btn_CreaConciliapFizer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_CreaConciliapFizer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_CreaConciliapFizer.Location = new System.Drawing.Point(517, 1);
            this.btn_CreaConciliapFizer.Name = "btn_CreaConciliapFizer";
            this.btn_CreaConciliapFizer.Size = new System.Drawing.Size(140, 23);
            this.btn_CreaConciliapFizer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_CreaConciliapFizer.TabIndex = 58;
            this.btn_CreaConciliapFizer.Text = "Crear Archivo Conciliación";
            this.btn_CreaConciliapFizer.Click += new System.EventHandler(this.btn_CreaConciliapFizer_Click);
            // 
            // btn_GetVaspFizer
            // 
            this.btn_GetVaspFizer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_GetVaspFizer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_GetVaspFizer.Location = new System.Drawing.Point(425, 1);
            this.btn_GetVaspFizer.Name = "btn_GetVaspFizer";
            this.btn_GetVaspFizer.Size = new System.Drawing.Size(75, 23);
            this.btn_GetVaspFizer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_GetVaspFizer.TabIndex = 57;
            this.btn_GetVaspFizer.Text = "Consultar";
            this.btn_GetVaspFizer.Click += new System.EventHandler(this.btn_GetVaspFizer_Click);
            // 
            // dti_pFizerFin
            // 
            this.dti_pFizerFin.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dti_pFizerFin.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dti_pFizerFin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_pFizerFin.ButtonClear.Visible = true;
            this.dti_pFizerFin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dti_pFizerFin.ButtonDropDown.Visible = true;
            this.dti_pFizerFin.CustomFormat = "dd/MM/yyyy";
            this.dti_pFizerFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dti_pFizerFin.ForeColor = System.Drawing.Color.Black;
            this.dti_pFizerFin.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dti_pFizerFin.IsPopupCalendarOpen = false;
            this.dti_pFizerFin.Location = new System.Drawing.Point(289, 3);
            // 
            // 
            // 
            this.dti_pFizerFin.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dti_pFizerFin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_pFizerFin.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dti_pFizerFin.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dti_pFizerFin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dti_pFizerFin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_pFizerFin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dti_pFizerFin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dti_pFizerFin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dti_pFizerFin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dti_pFizerFin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_pFizerFin.MonthCalendar.DisplayMonth = new System.DateTime(2012, 8, 1, 0, 0, 0, 0);
            this.dti_pFizerFin.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dti_pFizerFin.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dti_pFizerFin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dti_pFizerFin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_pFizerFin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dti_pFizerFin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_pFizerFin.MonthCalendar.TodayButtonVisible = true;
            this.dti_pFizerFin.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dti_pFizerFin.Name = "dti_pFizerFin";
            this.dti_pFizerFin.ShowUpDown = true;
            this.dti_pFizerFin.Size = new System.Drawing.Size(123, 21);
            this.dti_pFizerFin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dti_pFizerFin.TabIndex = 56;
            // 
            // labelX62
            // 
            this.labelX62.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX62.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX62.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX62.ForeColor = System.Drawing.Color.Black;
            this.labelX62.Location = new System.Drawing.Point(230, 1);
            this.labelX62.Name = "labelX62";
            this.labelX62.Size = new System.Drawing.Size(46, 23);
            this.labelX62.TabIndex = 55;
            this.labelX62.Text = " al ";
            this.labelX62.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // dti_pFizerIni
            // 
            this.dti_pFizerIni.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dti_pFizerIni.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dti_pFizerIni.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_pFizerIni.ButtonClear.Visible = true;
            this.dti_pFizerIni.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dti_pFizerIni.ButtonDropDown.Visible = true;
            this.dti_pFizerIni.CustomFormat = "dd/MM/yyyy";
            this.dti_pFizerIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dti_pFizerIni.ForeColor = System.Drawing.Color.Black;
            this.dti_pFizerIni.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dti_pFizerIni.IsPopupCalendarOpen = false;
            this.dti_pFizerIni.Location = new System.Drawing.Point(94, 3);
            // 
            // 
            // 
            this.dti_pFizerIni.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dti_pFizerIni.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_pFizerIni.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dti_pFizerIni.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dti_pFizerIni.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dti_pFizerIni.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_pFizerIni.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dti_pFizerIni.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dti_pFizerIni.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dti_pFizerIni.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dti_pFizerIni.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_pFizerIni.MonthCalendar.DisplayMonth = new System.DateTime(2012, 8, 1, 0, 0, 0, 0);
            this.dti_pFizerIni.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dti_pFizerIni.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dti_pFizerIni.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dti_pFizerIni.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dti_pFizerIni.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dti_pFizerIni.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dti_pFizerIni.MonthCalendar.TodayButtonVisible = true;
            this.dti_pFizerIni.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dti_pFizerIni.Name = "dti_pFizerIni";
            this.dti_pFizerIni.ShowUpDown = true;
            this.dti_pFizerIni.Size = new System.Drawing.Size(123, 21);
            this.dti_pFizerIni.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dti_pFizerIni.TabIndex = 54;
            this.dti_pFizerIni.Value = new System.DateTime(2012, 8, 1, 0, 0, 0, 0);
            // 
            // labelX61
            // 
            this.labelX61.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX61.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX61.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX61.ForeColor = System.Drawing.Color.Black;
            this.labelX61.Location = new System.Drawing.Point(9, 1);
            this.labelX61.Name = "labelX61";
            this.labelX61.Size = new System.Drawing.Size(72, 23);
            this.labelX61.TabIndex = 53;
            this.labelX61.Text = "Periodo del ";
            this.labelX61.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // GridConciliapFizer
            // 
            this.GridConciliapFizer.AllowUserToAddRows = false;
            this.GridConciliapFizer.AllowUserToDeleteRows = false;
            this.GridConciliapFizer.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridConciliapFizer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridConciliapFizer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridConciliapFizer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CadenaId,
            this.Folio,
            this.SucursalId,
            this.FecMov,
            this.Sku,
            this.CantCompra,
            this.CantBenef,
            this.CotizacionId,
            this.ConfirmaId,
            this.ActivoId});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridConciliapFizer.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridConciliapFizer.EnableHeadersVisualStyles = false;
            this.GridConciliapFizer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.GridConciliapFizer.Location = new System.Drawing.Point(9, 34);
            this.GridConciliapFizer.Name = "GridConciliapFizer";
            this.GridConciliapFizer.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridConciliapFizer.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GridConciliapFizer.Size = new System.Drawing.Size(815, 337);
            this.GridConciliapFizer.TabIndex = 52;
            // 
            // CadenaId
            // 
            this.CadenaId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CadenaId.HeaderText = "Cadena";
            this.CadenaId.Name = "CadenaId";
            this.CadenaId.ReadOnly = true;
            this.CadenaId.Width = 69;
            // 
            // Folio
            // 
            this.Folio.HeaderText = "FOLIO";
            this.Folio.Name = "Folio";
            this.Folio.ReadOnly = true;
            // 
            // SucursalId
            // 
            this.SucursalId.HeaderText = "Sucursal";
            this.SucursalId.Name = "SucursalId";
            this.SucursalId.ReadOnly = true;
            this.SucursalId.Width = 50;
            // 
            // FecMov
            // 
            this.FecMov.HeaderText = "Fecha Movimiento";
            this.FecMov.Name = "FecMov";
            this.FecMov.ReadOnly = true;
            this.FecMov.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FecMov.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FecMov.Width = 150;
            // 
            // Sku
            // 
            this.Sku.HeaderText = "Articulo";
            this.Sku.Name = "Sku";
            this.Sku.ReadOnly = true;
            // 
            // CantCompra
            // 
            // 
            // 
            // 
            this.CantCompra.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.CantCompra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CantCompra.HeaderText = "Compra";
            this.CantCompra.Name = "CantCompra";
            this.CantCompra.ReadOnly = true;
            // 
            // CantBenef
            // 
            // 
            // 
            // 
            this.CantBenef.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.CantBenef.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CantBenef.HeaderText = "Beneficio";
            this.CantBenef.Name = "CantBenef";
            this.CantBenef.ReadOnly = true;
            // 
            // CotizacionId
            // 
            this.CotizacionId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.CotizacionId.HeaderText = "Cotización";
            this.CotizacionId.Name = "CotizacionId";
            this.CotizacionId.ReadOnly = true;
            this.CotizacionId.Width = 5;
            // 
            // ConfirmaId
            // 
            this.ConfirmaId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ConfirmaId.HeaderText = "Confirmación";
            this.ConfirmaId.Name = "ConfirmaId";
            this.ConfirmaId.ReadOnly = true;
            this.ConfirmaId.Width = 5;
            // 
            // ActivoId
            // 
            this.ActivoId.HeaderText = "Estado";
            this.ActivoId.Name = "ActivoId";
            this.ActivoId.ReadOnly = true;
            // 
            // ConciliacionNadroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 383);
            this.Controls.Add(this.btn_CreaConciliapFizer);
            this.Controls.Add(this.btn_GetVaspFizer);
            this.Controls.Add(this.dti_pFizerFin);
            this.Controls.Add(this.labelX62);
            this.Controls.Add(this.dti_pFizerIni);
            this.Controls.Add(this.labelX61);
            this.Controls.Add(this.GridConciliapFizer);
            this.Name = "ConciliacionNadroForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conciliación Circulo Salud";
            this.Load += new System.EventHandler(this.ConciliacionPfizerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dti_pFizerFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dti_pFizerIni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridConciliapFizer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btn_CreaConciliapFizer;
        private DevComponents.DotNetBar.ButtonX btn_GetVaspFizer;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dti_pFizerFin;
        private DevComponents.DotNetBar.LabelX labelX62;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dti_pFizerIni;
        private DevComponents.DotNetBar.LabelX labelX61;
        private DevComponents.DotNetBar.Controls.DataGridViewX GridConciliapFizer;
        private System.Windows.Forms.DataGridViewTextBoxColumn CadenaId;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn SucursalId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FecMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sku;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn CantCompra;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn CantBenef;
        private System.Windows.Forms.DataGridViewTextBoxColumn CotizacionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfirmaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivoId;
    }
}