namespace SIF.View.Subrogacion
{
    partial class FacturasUserControl
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dateTimeInput2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateTimeInput1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ClienteTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturaButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.ingresaCmpGenTraspButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem = new DevComponents.DotNetBar.ButtonItem();
            this.seleccionaClienteButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.importarCatButtonItem = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.seleccionaClienteButtonItem,
            this.facturaButtonItem,
            this.ingresaCmpGenTraspButtonItem
            });
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(326, 32);
            this.titleLabel.Text = "SIF\\FACTURAS SUBROGACION";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            gridColumn1.DataPropertyName = "";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn1.HeaderText = "SELECCIONA";
            gridColumn1.Name = "SelColum";
            gridColumn1.NullString = "";
            gridColumn2.DataPropertyName = "NUM_REMISION";
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn2.HeaderText = "REMISION";
            gridColumn2.Name = "NUMERO_REMISIONColumn";
            gridColumn2.Width = 120;
            gridColumn3.DataPropertyName = "FECHA_VTA";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn3.HeaderText = "FECHA DE VENTA";
            gridColumn3.Name = "FECHA_VENTAColumn";
            gridColumn4.DataPropertyName = "SUBTOTAL";
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn4.HeaderText = "SUB TOTAL";
            gridColumn4.Name = "SUBTOTALColumn";
            gridColumn5.DataPropertyName = "IMPUESTO_IVA";
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn5.HeaderText = "IMPUESTO";
            gridColumn5.Name = "IMPUESTOColumn";
            gridColumn6.DataPropertyName = "DESCUENTO";
            gridColumn6.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn6.HeaderText = "DESCUENTO";
            gridColumn6.Name = "DESCUENTOColumn";
            gridColumn7.DataPropertyName = "TOTAL";
            gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn7.HeaderText = "TOTAL";
            gridColumn7.Name = "TOTALColumn";
            gridColumn8.DataPropertyName = "FACTURA";
            gridColumn8.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn8.HeaderText = "FACTURA";
            gridColumn8.Name = "FACTURAColumn";
            gridColumn9.DataPropertyName = "ACTIVO";
            gridColumn9.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn9.HeaderText = "STATUS";
            gridColumn9.Name = "ACTIVAColumn";
            gridColumn10.DataPropertyName = "CONDICIONES";
            gridColumn10.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn10.HeaderText = "CONDICIONES";
            gridColumn10.Name = "CONDICIONESColumn";
            gridColumn10.Width = 150;
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn7);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn8);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn9);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn10);
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(915, 447);
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.SplitterDistance = 117;
            this.splitContainer1.TabStop = false;
            // 
            // statusLabel
            // 
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 207F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.Controls.Add(this.labelX4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateTimeInput2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimeInput1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buscarTextBoxX, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ClienteTextBoxX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxX1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonX1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.radioButton2, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 117);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelX4
            // 
            this.labelX4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(3, 66);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(58, 23);
            this.labelX4.TabIndex = 27;
            this.labelX4.Text = "Remision:";
            // 
            // labelX1
            // 
            this.labelX1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(58, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Cliente";
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
            this.dateTimeInput2.Location = new System.Drawing.Point(483, 37);
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
            this.dateTimeInput2.Size = new System.Drawing.Size(150, 25);
            this.dateTimeInput2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput2.TabIndex = 3;
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
            this.dateTimeInput1.Location = new System.Drawing.Point(91, 37);
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
            this.dateTimeInput1.Size = new System.Drawing.Size(140, 25);
            this.dateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput1.TabIndex = 4;
            // 
            // labelX3
            // 
            this.labelX3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(276, 37);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(58, 23);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "Hasta:";
            // 
            // buscarTextBoxX
            // 
            this.buscarTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buscarTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.buscarTextBoxX.Border.Class = "TextBoxBorder";
            this.buscarTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.buscarTextBoxX, 3);
            this.buscarTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.buscarTextBoxX.Location = new System.Drawing.Point(91, 66);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(734, 25);
            this.buscarTextBoxX.TabIndex = 1;
            this.buscarTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxX1_KeyDown);
            // 
            // ClienteTextBoxX
            // 
            this.ClienteTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClienteTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.ClienteTextBoxX.Border.Class = "TextBoxBorder";
            this.ClienteTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ClienteTextBoxX.ButtonCustom.Visible = true;
            this.tableLayoutPanel1.SetColumnSpan(this.ClienteTextBoxX, 3);
            this.ClienteTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.ClienteTextBoxX.Location = new System.Drawing.Point(91, 3);
            this.ClienteTextBoxX.Name = "ClienteTextBoxX";
            this.ClienteTextBoxX.Size = new System.Drawing.Size(734, 25);
            this.ClienteTextBoxX.TabIndex = 26;
            this.ClienteTextBoxX.WatermarkText = "Código";
            this.ClienteTextBoxX.ButtonCustomClick += new System.EventHandler(this.CodigoTextBoxX_ButtonCustomClick);
            this.ClienteTextBoxX.TextChanged += new System.EventHandler(this.ClienteTextBoxX_TextChanged);
           


            // 
            // labelX2
            // 
            this.labelX2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(3, 37);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(58, 23);
            this.labelX2.TabIndex = 5;
            this.labelX2.Text = "Desde:";
            // 
            // checkBoxX1
            // 
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.Location = new System.Drawing.Point(91, 95);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(100, 14);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 28;
            this.checkBoxX1.Text = "Todas";
            this.checkBoxX1.CheckedChanged += new System.EventHandler(this.checkBoxX1_CheckedChanged);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(831, 5);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Text = "Buscar";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(276, 95);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(86, 19);
            this.radioButton1.TabIndex = 29;
            this.radioButton1.Text = "Precio Fijo";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(483, 95);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(83, 19);
            this.radioButton2.TabIndex = 30;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Normales";
            this.radioButton2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // facturaButtonItem
            // 
            this.facturaButtonItem.HoverImage = global::SIF.Properties.Resources.facturar1;
            this.facturaButtonItem.Image = global::SIF.Properties.Resources.Facturar;
            this.facturaButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.facturaButtonItem.Name = "facturaButtonItem";
            this.facturaButtonItem.Tag = "22";
            this.facturaButtonItem.Text = "FACTURA\r\n ";
            this.facturaButtonItem.Click += new System.EventHandler(this.facturaButtonItem_Click);
            // 
            // ingresaCmpGenTraspButtonItem
            // 
            this.ingresaCmpGenTraspButtonItem.HoverImage = global::SIF.Properties.Resources.facturar1;
            this.ingresaCmpGenTraspButtonItem.Image = global::SIF.Properties.Resources.Facturar;
            this.ingresaCmpGenTraspButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.ingresaCmpGenTraspButtonItem.Name = "ingresaCmpGenTraspButtonItem";
            this.ingresaCmpGenTraspButtonItem.Tag = "22";
            this.ingresaCmpGenTraspButtonItem.Text = "Ingresa\r\nCompra Gtrasp\r\n ";
            this.ingresaCmpGenTraspButtonItem.Click += new System.EventHandler(this.ingresaCmpGenTraspButtonItem_Click);
            // 
            // buttonItem
            // 
            this.buttonItem.Image = global::SIF.Properties.Resources.FundTool;
            this.buttonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem.Name = "buttonItem";
            this.buttonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.buttonItem.Text = "Pago \r\n[F5]";
            // 
            // seleccionaClienteButtonItem
            // 
            this.seleccionaClienteButtonItem.HoverImage = global::SIF.Properties.Resources.UserFindTool1;
            this.seleccionaClienteButtonItem.Image = global::SIF.Properties.Resources.UserFindTool;
            this.seleccionaClienteButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.seleccionaClienteButtonItem.Name = "seleccionaClienteButtonItem";
            this.seleccionaClienteButtonItem.Tag = "38";
            this.seleccionaClienteButtonItem.Text = "Cliente\r\n[F3]";
            this.seleccionaClienteButtonItem.Click += new System.EventHandler(this.seleccionaClienteButtonItem_Click);
            // 
            // FacturasUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "FacturasUserControl";
            this.Load += new System.EventHandler(this.VentasPagoUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevComponents.DotNetBar.ButtonItem facturaButtonItem;
        private DevComponents.DotNetBar.ButtonItem ingresaCmpGenTraspButtonItem;
        private DevComponents.DotNetBar.ButtonItem buttonItem;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX ClienteTextBoxX;
        private DevComponents.DotNetBar.ButtonItem seleccionaClienteButtonItem;
        private DevComponents.DotNetBar.ButtonItem importarCatButtonItem;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}
