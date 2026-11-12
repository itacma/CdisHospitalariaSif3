namespace SIF.View.OrdenCompra
{
    partial class BonificacionUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BonificacionUserControl));
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.buttonItemCc = new DevComponents.DotNetBar.ButtonItem();
            this.btn_ModificacionLotYCad = new DevComponents.DotNetBar.ButtonItem();
            this.recibirButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.inicioDateTimeInput = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.finDateTimeInput = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.imprimirButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.cerrarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.cancelarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.radioButtonBon = new System.Windows.Forms.RadioButton();
            this.radioButtonDev = new System.Windows.Forms.RadioButton();
            this.radioButtonRep = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inicioDateTimeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finDateTimeInput)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.backButton.FadeEffect = false;
            this.backButton.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.Location = new System.Drawing.Point(10, 47);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backButton.Name = "backButton";
            this.backButton.PressedImage = ((System.Drawing.Image)(resources.GetObject("backButton.PressedImage")));
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.backButton.Size = new System.Drawing.Size(48, 48);
            this.backButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.backButton.TabIndex = 14;
            this.backButton.Text = "\r\nRegresar";
            this.backButton.Tooltip = "Regresar [F12]";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "bar1 (bar1)";
            this.bar1.AccessibleName = "bar1";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar1.AntiAlias = true;
            this.bar1.BackColor = System.Drawing.Color.Transparent;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.recibirButtonItem,
            this.imprimirButtonItem,
            this.cancelarButtonItem,
            this.cerrarButtonItem,
            this.buttonItemCc,
            this.btn_ModificacionLotYCad});
            this.bar1.Location = new System.Drawing.Point(64, 44);
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(793, 92);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 15;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(282, 32);
            this.titleLabel.Text = "COMPRAS\\BONIFICACION\\REPOSICION\\DEV A PROVEEDOR";
            // 
            // superGridControl1
            // 
            this.superGridControl1.BackColor = System.Drawing.Color.White;
           // this.superGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControl1.ForeColor = System.Drawing.Color.Black;
            this.superGridControl1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.superGridControl1.Location = new System.Drawing.Point(0, 0);
            this.superGridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.superGridControl1.Name = "superGridControl1";
            //this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = true;
            gridColumn1.DataPropertyName = "FOLIO";
            gridColumn1.DefaultNewRowCellValue = ((object)(resources.GetObject("gridColumn1.DefaultNewRowCellValue")));
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn1.HeaderText = "FOLIO";
            gridColumn1.Name = "FOLIOColumn";
            gridColumn1.Width = 130;
            gridColumn2.DataPropertyName = "LOTE";
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn2.HeaderText = "LOTE";
            gridColumn2.Name = "LOTEColumn";
            gridColumn2.Width = 80;
            gridColumn3.DataPropertyName = "CAT_SUCURSALES_NOMBRE";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn3.HeaderText = "SUCURSAL";
            gridColumn3.Name = "SUCURSALColumn";
            gridColumn3.Width = 120;
            gridColumn4.DataPropertyName = "FECHA_REG";
            gridColumn4.DefaultNewRowCellValue = ((object)(resources.GetObject("gridColumn4.DefaultNewRowCellValue")));
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn4.HeaderText = "REGISTRO";
            gridColumn4.Name = "FECHA_REGISTROColumn";
            gridColumn4.Width = 130;
            gridColumn5.DataPropertyName = "TOTAL";
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn5.HeaderText = "TOTAL";
            gridColumn5.Name = "TOTALColumn";
            gridColumn6.DataPropertyName = "CONCEPTO";
            gridColumn6.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn6.FillWeight = 140;
            gridColumn6.HeaderText = "CONCEPTO";
            gridColumn6.Name = "CONCEPTOColumn";
            gridColumn7.DataPropertyName = "DOC_REFERENCIA";
            gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn7.HeaderText = "REFERENCIA";
            gridColumn7.Name = "DOCUMENTO_REFERENCIAColumn";
            gridColumn8.DataPropertyName = "CAT_USUARIOS_NOMBRE";
            gridColumn8.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn8.HeaderText = "USUARIO";
            gridColumn8.Name = "USUARIO_NOMBREColumn";
            gridColumn9.DataPropertyName = "ACTIVO";
            gridColumn9.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn9.HeaderText = "ACTIVO";
            gridColumn9.Name = "ACTIVOColumn";
           /* this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn7);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn8);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn9);
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;*/
            this.superGridControl1.PrimaryGrid.ShowTreeButtons = true;
            this.superGridControl1.PrimaryGrid.ShowTreeLines = true;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(915, 489);
            this.superGridControl1.TabIndex = 0;
            this.superGridControl1.Text = "Artículos";
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.SplitterDistance = 75;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.statusLabel.Location = new System.Drawing.Point(67, 718);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(912, 30);
            this.statusLabel.TabIndex = 16;
            this.statusLabel.Text = "Status...";
            // 
            // recibirButtonItem
            // 
            this.recibirButtonItem.HoverImage = global::SIF.Properties.Resources.TableContentsTool1;
            this.recibirButtonItem.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.recibirButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.recibirButtonItem.Name = "recibirButtonItem";
            this.recibirButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.recibirButtonItem.Text = "Recibir Bonificacion \r\n[F8]";
            this.recibirButtonItem.Click += new System.EventHandler(this.recibirButtonItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.82857F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.114285F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.62857F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.08571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.34286F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.77143F));
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarTextBoxX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.inicioDateTimeInput, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.finDateTimeInput, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarButtonX, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonRep, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonDev, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonBon, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 75);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelX1
            // 
            this.labelX1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 9);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(34, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Folio:";
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
            this.buscarTextBoxX.Location = new System.Drawing.Point(43, 8);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(185, 25);
            this.buscarTextBoxX.TabIndex = 1;
            this.buscarTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buscarTextBoxX_KeyDown);
            // 
            // labelX2
            // 
            this.labelX2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(234, 9);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(48, 23);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "DESDE:";
            // 
            // inicioDateTimeInput
            // 
            this.inicioDateTimeInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.inicioDateTimeInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.inicioDateTimeInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inicioDateTimeInput.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.inicioDateTimeInput.ButtonDropDown.Visible = true;
            this.inicioDateTimeInput.IsPopupCalendarOpen = false;
            this.inicioDateTimeInput.Location = new System.Drawing.Point(305, 8);
            // 
            // 
            // 
            this.inicioDateTimeInput.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.inicioDateTimeInput.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inicioDateTimeInput.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.inicioDateTimeInput.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.inicioDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.inicioDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.inicioDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.inicioDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.inicioDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.inicioDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.inicioDateTimeInput.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inicioDateTimeInput.MonthCalendar.DisplayMonth = new System.DateTime(2012, 9, 1, 0, 0, 0, 0);
            this.inicioDateTimeInput.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.inicioDateTimeInput.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.inicioDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.inicioDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.inicioDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.inicioDateTimeInput.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inicioDateTimeInput.MonthCalendar.TodayButtonVisible = true;
            this.inicioDateTimeInput.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.inicioDateTimeInput.Name = "inicioDateTimeInput";
            this.inicioDateTimeInput.Size = new System.Drawing.Size(157, 25);
            this.inicioDateTimeInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.inicioDateTimeInput.TabIndex = 5;
            // 
            // labelX3
            // 
            this.labelX3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(468, 9);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(51, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "HASTA:";
            // 
            // finDateTimeInput
            // 
            this.finDateTimeInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.finDateTimeInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.finDateTimeInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.finDateTimeInput.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.finDateTimeInput.ButtonDropDown.Visible = true;
            this.finDateTimeInput.IsPopupCalendarOpen = false;
            this.finDateTimeInput.Location = new System.Drawing.Point(565, 8);
            // 
            // 
            // 
            this.finDateTimeInput.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.finDateTimeInput.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.finDateTimeInput.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.finDateTimeInput.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.finDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.finDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.finDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.finDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.finDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.finDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.finDateTimeInput.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.finDateTimeInput.MonthCalendar.DisplayMonth = new System.DateTime(2012, 9, 1, 0, 0, 0, 0);
            this.finDateTimeInput.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.finDateTimeInput.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.finDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.finDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.finDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.finDateTimeInput.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.finDateTimeInput.MonthCalendar.TodayButtonVisible = true;
            this.finDateTimeInput.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.finDateTimeInput.Name = "finDateTimeInput";
            this.finDateTimeInput.Size = new System.Drawing.Size(172, 25);
            this.finDateTimeInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.finDateTimeInput.TabIndex = 6;
            // 
            // buscarButtonX
            // 
            this.buscarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buscarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buscarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buscarButtonX.Location = new System.Drawing.Point(743, 9);
            this.buscarButtonX.Name = "buscarButtonX";
            this.buscarButtonX.Size = new System.Drawing.Size(75, 23);
            this.buscarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buscarButtonX.TabIndex = 2;
            this.buscarButtonX.Text = "Buscar";
            this.buscarButtonX.Click += new System.EventHandler(this.buscarButtonX_Click);
            // 
            // imprimirButtonItem
            // 
            this.imprimirButtonItem.HoverImage = global::SIF.Properties.Resources.Printer1;
            this.imprimirButtonItem.Image = global::SIF.Properties.Resources.Printer;
            this.imprimirButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.imprimirButtonItem.Name = "imprimirButtonItem";
            this.imprimirButtonItem.Tag = "3";
            this.imprimirButtonItem.Text = "Imprimir\r\n ";
            this.imprimirButtonItem.Click += new System.EventHandler(this.imprimirButtonItem_Click);
            // 
            // cerrarButtonItem
            // 
            this.cerrarButtonItem.HoverImage = global::SIF.Properties.Resources.BoxNewTool1;
            this.cerrarButtonItem.Image = global::SIF.Properties.Resources.LockInformation;
            this.cerrarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.cerrarButtonItem.Name = "cerrarButtonItem";
            this.cerrarButtonItem.Tag = "3";
            this.cerrarButtonItem.Text = "Cerrar\r\n ";
            this.cerrarButtonItem.Click += new System.EventHandler(this.cerrarButtonItem_Click);
            // 
            // cancelarButtonItem
            // 
            this.cancelarButtonItem.HoverImage = global::SIF.Properties.Resources.Cancel;
            this.cancelarButtonItem.Image = global::SIF.Properties.Resources.Cancel3;
            this.cancelarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.cancelarButtonItem.Name = "cancelarButtonItem";
            this.cancelarButtonItem.Tag = "4";
            this.cancelarButtonItem.Text = "Cancelar\r\n ";
            this.cancelarButtonItem.Click += new System.EventHandler(this.cancelarButtonItem_Click);
            // 
            // radioButtonBon
            // 
            this.radioButtonBon.AutoSize = true;
            this.radioButtonBon.Location = new System.Drawing.Point(305, 45);
            this.radioButtonBon.Name = "radioButtonBon";
            this.radioButtonBon.Size = new System.Drawing.Size(108, 21);
            this.radioButtonBon.TabIndex = 7;
            this.radioButtonBon.TabStop = true;
            this.radioButtonBon.Text = "Bonificaciones";
            this.radioButtonBon.UseVisualStyleBackColor = true;
            // 
            // radioButtonDev
            // 
            this.radioButtonDev.AutoSize = true;
            this.radioButtonDev.Location = new System.Drawing.Point(43, 45);
            this.radioButtonDev.Name = "radioButtonDev";
            this.radioButtonDev.Size = new System.Drawing.Size(168, 21);
            this.radioButtonDev.TabIndex = 8;
            this.radioButtonDev.TabStop = true;
            this.radioButtonDev.Text = "Devoluciones Proveedor";
            this.radioButtonDev.UseVisualStyleBackColor = true;
            // 
            // radioButtonRep
            // 
            this.radioButtonRep.AutoSize = true;
            this.radioButtonRep.Location = new System.Drawing.Point(565, 45);
            this.radioButtonRep.Name = "radioButtonRep";
            this.radioButtonRep.Size = new System.Drawing.Size(103, 21);
            this.radioButtonRep.TabIndex = 9;
            this.radioButtonRep.TabStop = true;
            this.radioButtonRep.Text = "Reposiciones";
            this.radioButtonRep.UseVisualStyleBackColor = true;
            // 
            // buttonItemCc
            // 
            this.buttonItemCc.HoverImage = global::SIF.Properties.Resources.Date1;
            this.buttonItemCc.Image = global::SIF.Properties.Resources.Date;
            this.buttonItemCc.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItemCc.Name = "buttonItemCc";
            this.buttonItemCc.Tag = "4";
            this.buttonItemCc.Text = "Caducidad\r\n ";
            this.buttonItemCc.Click += new System.EventHandler(this.buttonItemCc_Click);
            // 
            // btn_ModificacionLotYCad
            // 
            this.btn_ModificacionLotYCad.HoverImage = global::SIF.Properties.Resources.TableContentsTool1;
            this.btn_ModificacionLotYCad.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.btn_ModificacionLotYCad.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_ModificacionLotYCad.Name = "btn_ModificacionLotYCad";
            this.btn_ModificacionLotYCad.Tag = "47";
            this.btn_ModificacionLotYCad.Text = "Modificacion Lote y\r\nCaducidad";
            this.btn_ModificacionLotYCad.Click += new System.EventHandler(this.btn_ModificacionLotYCad_click);
            // 
            // BonificacionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "BonificacionUserControl";
            this.Load += new System.EventHandler(this.RecepcionOrdenCompraUserControl_Load);
          
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inicioDateTimeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finDateTimeInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem recibirButtonItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput inicioDateTimeInput;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput finDateTimeInput;
        private DevComponents.DotNetBar.ButtonItem imprimirButtonItem;
        private DevComponents.DotNetBar.ButtonItem cerrarButtonItem;
        private DevComponents.DotNetBar.ButtonItem cancelarButtonItem;

        private System.Windows.Forms.RadioButton radioButtonRep;
        private System.Windows.Forms.RadioButton radioButtonDev;
        private System.Windows.Forms.RadioButton radioButtonBon;
        private DevComponents.DotNetBar.ButtonItem buttonItemCc;
        private DevComponents.DotNetBar.ButtonItem btn_ModificacionLotYCad;
        //private DevComponents.DotNetBar.LabelX statusLabel;
    }
}
