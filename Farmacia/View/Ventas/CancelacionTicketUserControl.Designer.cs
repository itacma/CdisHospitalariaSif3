namespace SIF.View.Ventas
{
    partial class CancelacionTicketUserControl
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.dateTimeInput1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateTimeInput2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.statusComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cancelarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.cancelacionAutomaticaButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.cancelacionAutomaticaBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.imprimeTicketButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.facturaButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem8 = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).BeginInit();
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
            this.cancelarButtonItem,
            this.cancelacionAutomaticaButtonItem,
            this.imprimeTicketButtonItem,
            this.facturaButtonItem,
            this.buttonItem1});
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(280, 32);
            this.titleLabel.Text = "SIF\\CANCELACION TICKET";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            gridColumn1.DataPropertyName = "NUM_REMISION";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn1.HeaderText = "REMISION";
            gridColumn1.Name = "NUMERO_REMISIONColumn";
            gridColumn1.Width = 120;
            gridColumn2.DataPropertyName = "COMENTARIOS";
            gridColumn2.HeaderText = "COMENTARIOS";
            gridColumn2.Name = "COMENTARIOSColumn";
            gridColumn2.Width = 250;
            gridColumn3.DataPropertyName = "FECHA_VTA";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn3.HeaderText = "FECHA DE VENTA";
            gridColumn3.Name = "FECHA_VENTAColumn";
            gridColumn3.Width = 130;
            gridColumn4.DataPropertyName = "CLIENTE_ID";
            gridColumn4.HeaderText = "CLIENTE";
            gridColumn4.Name = "CLIENTE";
            gridColumn5.DataPropertyName = "SUBTOTAL";
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn5.HeaderText = "SUB TOTAL";
            gridColumn5.Name = "SUBTOTALColumn";
            gridColumn6.DataPropertyName = "IMPUESTO_IVA";
            gridColumn6.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn6.HeaderText = "IMPUESTO";
            gridColumn6.Name = "IMPUESTOColumn";
            gridColumn7.DataPropertyName = "DESCUENTO";
            gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn7.HeaderText = "DESCUENTO";
            gridColumn7.Name = "DESCUENTOColumn";
            gridColumn8.DataPropertyName = "TOTAL";
            gridColumn8.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn8.HeaderText = "TOTAL";
            gridColumn8.Name = "TOTALColumn";
            gridColumn9.DataPropertyName = "FACTURA";
            gridColumn9.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn9.HeaderText = "FACTURA";
            gridColumn9.Name = "FACTURAColumn";
            gridColumn10.DataPropertyName = "ACTIVO";
            gridColumn10.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn10.HeaderText = "STATUS";
            gridColumn10.Name = "ACTIVAColumn";
            gridColumn11.DataPropertyName = "CONDICIONES";
            gridColumn11.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn11.HeaderText = "CONDICIONES";
            gridColumn11.Name = "CONDICIONESColumn";
            gridColumn11.Width = 150;
            gridColumn12.DataPropertyName = "VEDNOMBRE";
            gridColumn12.HeaderText = "VENDEDOR";
            gridColumn12.Name = "Vendedor";
            gridColumn13.DataPropertyName = "ORIGEN";
            gridColumn13.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn13.HeaderText = "ORIGEN";
            gridColumn13.Name = "ORIGEN_LABEL";
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
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn11);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn12);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn13);
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(915, 464);
            this.superGridControl1.TabIndex = 5;
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.SplitterDistance = 100;
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarTextBoxX, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateTimeInput1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimeInput2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonX1, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusComboBoxEx, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 24);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(58, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Remision:";
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
            this.buscarTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.buscarTextBoxX.Location = new System.Drawing.Point(3, 62);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(328, 25);
            this.buscarTextBoxX.TabIndex = 1;
            this.buscarTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxX1_KeyDown);
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(337, 24);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(58, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Desde:";
            // 
            // labelX3
            // 
            this.labelX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(504, 24);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(58, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Hasta:";
            // 
            // dateTimeInput1
            // 
            this.dateTimeInput1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.dateTimeInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput1.ButtonDropDown.Visible = true;
            this.dateTimeInput1.IsPopupCalendarOpen = false;
            this.dateTimeInput1.Location = new System.Drawing.Point(337, 62);
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
            this.dateTimeInput1.MonthCalendar.DisplayMonth = new System.DateTime(2012, 10, 1, 0, 0, 0, 0);
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
            this.dateTimeInput1.Size = new System.Drawing.Size(161, 25);
            this.dateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput1.TabIndex = 2;
            // 
            // dateTimeInput2
            // 
            this.dateTimeInput2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.dateTimeInput2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput2.ButtonDropDown.Visible = true;
            this.dateTimeInput2.IsPopupCalendarOpen = false;
            this.dateTimeInput2.Location = new System.Drawing.Point(504, 62);
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
            this.dateTimeInput2.MonthCalendar.DisplayMonth = new System.DateTime(2012, 10, 1, 0, 0, 0, 0);
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
            this.dateTimeInput2.Size = new System.Drawing.Size(161, 25);
            this.dateTimeInput2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput2.TabIndex = 3;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(838, 63);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(74, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 4;
            this.buttonX1.Text = "Buscar";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // labelX4
            // 
            this.labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(671, 24);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(58, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Hasta:";
            // 
            // statusComboBoxEx
            // 
            this.statusComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.statusComboBoxEx.DisplayMember = "Text";
            this.statusComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.statusComboBoxEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBoxEx.FormattingEnabled = true;
            this.statusComboBoxEx.ItemHeight = 19;
            this.statusComboBoxEx.Location = new System.Drawing.Point(671, 62);
            this.statusComboBoxEx.Name = "statusComboBoxEx";
            this.statusComboBoxEx.Size = new System.Drawing.Size(161, 25);
            this.statusComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.statusComboBoxEx.TabIndex = 5;
            this.statusComboBoxEx.SelectedIndexChanged += new System.EventHandler(this.statusComboBoxEx_SelectedIndexChanged);
            // 
            // cancelarButtonItem
            // 
            this.cancelarButtonItem.HoverImage = global::SIF.Properties.Resources.Cancel1;
            this.cancelarButtonItem.Image = global::SIF.Properties.Resources.Cancel;
            this.cancelarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.cancelarButtonItem.Name = "cancelarButtonItem";
            this.cancelarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.cancelarButtonItem.Tag = "14";
            this.cancelarButtonItem.Text = "Por folio \r\n[F8]";
            this.cancelarButtonItem.Click += new System.EventHandler(this.cancelarButtonItem_Click);
            // 
            // cancelacionAutomaticaButtonItem
            // 
            this.cancelacionAutomaticaButtonItem.HoverImage = global::SIF.Properties.Resources.Junk1;
            this.cancelacionAutomaticaButtonItem.Image = global::SIF.Properties.Resources.Junk;
            this.cancelacionAutomaticaButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.cancelacionAutomaticaButtonItem.Name = "cancelacionAutomaticaButtonItem";
            this.cancelacionAutomaticaButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F9);
            this.cancelacionAutomaticaButtonItem.Tag = "15";
            this.cancelacionAutomaticaButtonItem.Text = "Automatica \r\n[F9]";
            this.cancelacionAutomaticaButtonItem.Visible = false;
            this.cancelacionAutomaticaButtonItem.Click += new System.EventHandler(this.cancelacionAutomaticaButtonItem_Click);
            // 
            // cancelacionAutomaticaBackgroundWorker
            // 
            this.cancelacionAutomaticaBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.cancelacionAutomaticaBackgroundWorker_DoWork);
            this.cancelacionAutomaticaBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.cancelacionAutomaticaBackgroundWorker_RunWorkerCompleted);
            // 
            // imprimeTicketButtonItem
            // 
            this.imprimeTicketButtonItem.HoverImage = global::SIF.Properties.Resources.Printer1;
            this.imprimeTicketButtonItem.Image = global::SIF.Properties.Resources.Printer;
            this.imprimeTicketButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.imprimeTicketButtonItem.Name = "imprimeTicketButtonItem";
            this.imprimeTicketButtonItem.Tag = "16";
            this.imprimeTicketButtonItem.Text = "TICKET\r\n ";
            this.imprimeTicketButtonItem.Click += new System.EventHandler(this.imprimeTicketButtonItem_Click);
            // 
            // facturaButtonItem
            // 
            this.facturaButtonItem.HoverImage = global::SIF.Properties.Resources.facturar1;
            this.facturaButtonItem.Image = global::SIF.Properties.Resources.Facturar;
            this.facturaButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.facturaButtonItem.Name = "facturaButtonItem";
            this.facturaButtonItem.Text = "FACTURA\r\n ";
            this.facturaButtonItem.Click += new System.EventHandler(this.facturaButtonItem_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.HoverImage = global::SIF.Properties.Resources.Printer1;
            this.buttonItem1.Image = global::SIF.Properties.Resources.Printer;
            this.buttonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem2,
            this.buttonItem3,
            this.buttonItem7,
            this.buttonItem4,
            this.buttonItem5,
            this.buttonItem6,
            this.buttonItem8});
            this.buttonItem1.Tag = "16";
            this.buttonItem1.Text = "REPORTES\r\n ";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "No Pagadas";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "Pagadas";
            this.buttonItem3.Click += new System.EventHandler(this.buttonItem3_Click);
            // 
            // buttonItem7
            // 
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.Text = "Pagadas X Forma de pago";
            this.buttonItem7.Click += new System.EventHandler(this.buttonItem7_Click);
            // 
            // buttonItem4
            // 
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Text = "Canceladas";
            this.buttonItem4.Click += new System.EventHandler(this.buttonItem4_Click);
            // 
            // buttonItem5
            // 
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "Facturadas";
            this.buttonItem5.Click += new System.EventHandler(this.buttonItem5_Click);
            // 
            // buttonItem6
            // 
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.Text = "No Facturadas";
            this.buttonItem6.Click += new System.EventHandler(this.buttonItem6_Click);
            // 
            // buttonItem8
            // 
            this.buttonItem8.Name = "buttonItem8";
            this.buttonItem8.Text = "Faltantes";
            this.buttonItem8.Click += new System.EventHandler(this.buttonItem8_Click);
            // 
            // CancelacionTicketUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CancelacionTicketUserControl";
            this.Load += new System.EventHandler(this.VentasPagoUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).EndInit();
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
        private DevComponents.DotNetBar.ButtonItem cancelarButtonItem;
        private DevComponents.DotNetBar.ButtonItem cancelacionAutomaticaButtonItem;
        private System.ComponentModel.BackgroundWorker cancelacionAutomaticaBackgroundWorker;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput2;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx statusComboBoxEx;
        private DevComponents.DotNetBar.ButtonItem imprimeTicketButtonItem;
        private DevComponents.DotNetBar.ButtonItem facturaButtonItem;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.ButtonItem buttonItem6;
        private DevComponents.DotNetBar.ButtonItem buttonItem7;
        private DevComponents.DotNetBar.ButtonItem buttonItem8;
    }
}
