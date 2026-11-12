namespace SIF.View.OrdenCompra
{
    partial class NumeroFacturaForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.cancelarButton = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.numeroFacturaTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.ordenCompraLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.proveedorLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimeInput1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateTimeInput2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.FOLIO_SATColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.NUM_FACTURAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.COINCIDENCIASColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.FECHAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.IMPORTE_SIN_IVAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.IMPORTE_CON_IVAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.IVAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.TOTALColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ESTADODColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.TOTAL_NETO_FACTURAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.DESCTO_SIVAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.DESCTO_CIVAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.TOTAL_DESCTOSColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).BeginInit();
            this.SuspendLayout();
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(599, 432);
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
            this.cancelarButton.Location = new System.Drawing.Point(702, 432);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(80, 26);
            this.cancelarButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButton.TabIndex = 21;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.TextColor = System.Drawing.Color.White;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "NUMERO DE FACTURA:";
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToOrderColumns = true;
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FOLIO_SATColumn,
            this.NUM_FACTURAColumn,
            this.COINCIDENCIASColumn,
            this.FECHAColumn,
            this.IMPORTE_SIN_IVAColumn,
            this.IMPORTE_CON_IVAColumn,
            this.IVAColumn,
            this.TOTALColumn,
            this.ESTADODColumn,
            this.TOTAL_NETO_FACTURAColumn,
            this.DESCTO_SIVAColumn,
            this.DESCTO_CIVAColumn,
            this.TOTAL_DESCTOSColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(31, 108);
            this.dataGridViewX1.MultiSelect = false;
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(751, 308);
            this.dataGridViewX1.TabIndex = 24;
            this.dataGridViewX1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewX1_RowPostPaint);
            this.dataGridViewX1.DoubleClick += new System.EventHandler(this.dataGridViewX1_DoubleClick);
            // 
            // numeroFacturaTextBoxX
            // 
            this.numeroFacturaTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numeroFacturaTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.numeroFacturaTextBoxX.Border.Class = "TextBoxBorder";
            this.numeroFacturaTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.numeroFacturaTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.numeroFacturaTextBoxX.Location = new System.Drawing.Point(160, 65);
            this.numeroFacturaTextBoxX.Name = "numeroFacturaTextBoxX";
            this.numeroFacturaTextBoxX.Size = new System.Drawing.Size(622, 20);
            this.numeroFacturaTextBoxX.TabIndex = 1;
            this.numeroFacturaTextBoxX.TextChanged += new System.EventHandler(this.numeroFacturaTextBoxX_TextChanged);
            this.numeroFacturaTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxX1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = " ORDEN DE COMPRA:";
            // 
            // ordenCompraLabel
            // 
            this.ordenCompraLabel.AutoSize = true;
            this.ordenCompraLabel.Location = new System.Drawing.Point(150, 8);
            this.ordenCompraLabel.Name = "ordenCompraLabel";
            this.ordenCompraLabel.Size = new System.Drawing.Size(119, 13);
            this.ordenCompraLabel.TabIndex = 25;
            this.ordenCompraLabel.Text = "[ORDEN DE COMPRA]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "PROVEEDOR:";
            // 
            // proveedorLabel
            // 
            this.proveedorLabel.AutoSize = true;
            this.proveedorLabel.Location = new System.Drawing.Point(112, 26);
            this.proveedorLabel.Name = "proveedorLabel";
            this.proveedorLabel.Size = new System.Drawing.Size(81, 13);
            this.proveedorLabel.TabIndex = 25;
            this.proveedorLabel.Text = "[PROVEEDOR]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = "Desde:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(326, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 93;
            this.label5.Text = "Hasta:";
            // 
            // dateTimeInput1
            // 
            // 
            // 
            // 
            this.dateTimeInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput1.ButtonDropDown.Visible = true;
            this.dateTimeInput1.IsPopupCalendarOpen = false;
            this.dateTimeInput1.Location = new System.Drawing.Point(75, 42);
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.DisplayMonth = new System.DateTime(2012, 12, 1, 0, 0, 0, 0);
            this.dateTimeInput1.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInput1.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput1.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInput1.Name = "dateTimeInput1";
            this.dateTimeInput1.Size = new System.Drawing.Size(243, 20);
            this.dateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput1.TabIndex = 90;
            this.dateTimeInput1.ValueChanged += new System.EventHandler(this.dateTimeInput1_ValueChanged);
            // 
            // dateTimeInput2
            // 
            // 
            // 
            // 
            this.dateTimeInput2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput2.ButtonDropDown.Visible = true;
            this.dateTimeInput2.IsPopupCalendarOpen = false;
            this.dateTimeInput2.Location = new System.Drawing.Point(370, 42);
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput2.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.DisplayMonth = new System.DateTime(2012, 12, 1, 0, 0, 0, 0);
            this.dateTimeInput2.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInput2.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput2.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInput2.Name = "dateTimeInput2";
            this.dateTimeInput2.Size = new System.Drawing.Size(243, 20);
            this.dateTimeInput2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput2.TabIndex = 91;
            this.dateTimeInput2.ValueChanged += new System.EventHandler(this.dateTimeInput2_ValueChanged);
            // 
            // FOLIO_SATColumn
            // 
            this.FOLIO_SATColumn.DataPropertyName = "FOLIO_FACTURA_SAT";
            this.FOLIO_SATColumn.HeaderText = "FOLIO_SAT";
            this.FOLIO_SATColumn.Name = "FOLIO_SATColumn";
            // 
            // NUM_FACTURAColumn
            // 
            this.NUM_FACTURAColumn.DataPropertyName = "NUM_FACTURA";
            this.NUM_FACTURAColumn.HeaderText = "FACTURA";
            this.NUM_FACTURAColumn.Name = "NUM_FACTURAColumn";
            this.NUM_FACTURAColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NUM_FACTURAColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // COINCIDENCIASColumn
            // 
            this.COINCIDENCIASColumn.DataPropertyName = "COINCIDENCIAS";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "0%";
            dataGridViewCellStyle1.NullValue = "0%";
            this.COINCIDENCIASColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.COINCIDENCIASColumn.FillWeight = 80F;
            this.COINCIDENCIASColumn.HeaderText = "COINCIDENCIAS";
            this.COINCIDENCIASColumn.Name = "COINCIDENCIASColumn";
            this.COINCIDENCIASColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COINCIDENCIASColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FECHAColumn
            // 
            this.FECHAColumn.DataPropertyName = "FECHA_FACTURA";
            this.FECHAColumn.FillWeight = 80F;
            this.FECHAColumn.HeaderText = "FECHA";
            this.FECHAColumn.Name = "FECHAColumn";
            this.FECHAColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FECHAColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IMPORTE_SIN_IVAColumn
            // 
            this.IMPORTE_SIN_IVAColumn.DataPropertyName = "TOTAL_IMPORTE_FACTURA";
            this.IMPORTE_SIN_IVAColumn.HeaderText = "IMPORTE TOTAL";
            this.IMPORTE_SIN_IVAColumn.Name = "IMPORTE_SIN_IVAColumn";
            this.IMPORTE_SIN_IVAColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IMPORTE_SIN_IVAColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IMPORTE_CON_IVAColumn
            // 
            this.IMPORTE_CON_IVAColumn.DataPropertyName = "TOTAL_DESCTO";
            this.IMPORTE_CON_IVAColumn.HeaderText = "DESCUENTO";
            this.IMPORTE_CON_IVAColumn.Name = "IMPORTE_CON_IVAColumn";
            this.IMPORTE_CON_IVAColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IMPORTE_CON_IVAColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IVAColumn
            // 
            this.IVAColumn.DataPropertyName = "TOTAL_IVA";
            this.IVAColumn.FillWeight = 80F;
            this.IVAColumn.HeaderText = "IVA";
            this.IVAColumn.Name = "IVAColumn";
            this.IVAColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IVAColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TOTALColumn
            // 
            this.TOTALColumn.DataPropertyName = "TOTAL_FACTURADO";
            this.TOTALColumn.HeaderText = "FACTURADO";
            this.TOTALColumn.Name = "TOTALColumn";
            this.TOTALColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TOTALColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ESTADODColumn
            // 
            this.ESTADODColumn.DataPropertyName = "ESTADO";
            this.ESTADODColumn.HeaderText = "ESTADO";
            this.ESTADODColumn.Name = "ESTADODColumn";
            this.ESTADODColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ESTADODColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TOTAL_NETO_FACTURAColumn
            // 
            this.TOTAL_NETO_FACTURAColumn.DataPropertyName = "TOTAL_NETO_FACTURA";
            this.TOTAL_NETO_FACTURAColumn.HeaderText = "NETO";
            this.TOTAL_NETO_FACTURAColumn.Name = "TOTAL_NETO_FACTURAColumn";
            // 
            // DESCTO_SIVAColumn
            // 
            this.DESCTO_SIVAColumn.DataPropertyName = "TOTAL_DESCTO_SIVA";
            this.DESCTO_SIVAColumn.HeaderText = "DESCTO S/IVA";
            this.DESCTO_SIVAColumn.Name = "DESCTO_SIVAColumn";
            // 
            // DESCTO_CIVAColumn
            // 
            this.DESCTO_CIVAColumn.DataPropertyName = "TOTAL_DESCTO_CIVA";
            this.DESCTO_CIVAColumn.HeaderText = "DESCTO C/IVA";
            this.DESCTO_CIVAColumn.Name = "DESCTO_CIVAColumn";
            // 
            // TOTAL_DESCTOSColumn
            // 
            this.TOTAL_DESCTOSColumn.DataPropertyName = "TOTAL_DESCTO_DESCTOS";
            this.TOTAL_DESCTOSColumn.HeaderText = "DESCUENTOS";
            this.TOTAL_DESCTOSColumn.Name = "TOTAL_DESCTOSColumn";
            // 
            // NumeroFacturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 470);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimeInput1);
            this.Controls.Add(this.dateTimeInput2);
            this.Controls.Add(this.proveedorLabel);
            this.Controls.Add(this.ordenCompraLabel);
            this.Controls.Add(this.numeroFacturaTextBoxX);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.cancelarButton);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NumeroFacturaForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FACTURA";
            this.Load += new System.EventHandler(this.NumeroFacturaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private DevComponents.DotNetBar.ButtonX cancelarButton;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.Controls.TextBoxX numeroFacturaTextBoxX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ordenCompraLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label proveedorLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        public DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput1;
        public DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput2;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn FOLIO_SATColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn NUM_FACTURAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn COINCIDENCIASColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn FECHAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn IMPORTE_SIN_IVAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn IMPORTE_CON_IVAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn IVAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn TOTALColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ESTADODColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn TOTAL_NETO_FACTURAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn DESCTO_SIVAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn DESCTO_CIVAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn TOTAL_DESCTOSColumn;
    }
}