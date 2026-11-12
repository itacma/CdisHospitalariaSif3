namespace SIF.View.Ventas
{
    partial class ApartadosUserControl
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.LabelX labelX1;
            DevComponents.DotNetBar.LabelX labelX2;
            DevComponents.DotNetBar.LabelX labelX3;
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
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.contadoRadioButton = new System.Windows.Forms.RadioButton();
            this.creditoRadioButton = new System.Windows.Forms.RadioButton();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cantidadLetraLabelX = new DevComponents.DotNetBar.LabelX();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.dateTimeInput1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateTimeInput2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.superGridControl2 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.salirButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.cancelarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            this.imprimirButtonItem = new DevComponents.DotNetBar.ButtonItem();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            labelX3 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.cancelarButtonItem,
            this.buttonItem3,
            this.salirButtonItem,
            this.imprimirButtonItem});
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.bar1.Size = new System.Drawing.Size(944, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(154, 32);
            this.titleLabel.Text = "SIF\\Apartados";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            gridColumn1.DataPropertyName = "FOLIO";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn1.HeaderText = "FOLIO";
            gridColumn1.Name = "";
            gridColumn1.Width = 120;
            gridColumn2.DataPropertyName = "FECHA";
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn2.HeaderText = "FECHA";
            gridColumn2.Name = "";
            gridColumn2.Width = 130;
            gridColumn3.DataPropertyName = "REF_REMISION_VTA";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn3.HeaderText = "REMISION";
            gridColumn3.Name = "";
            gridColumn3.Width = 120;
            gridColumn4.DataPropertyName = "FEC_REMISION_VTA";
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn4.HeaderText = "FECHA VTA";
            gridColumn4.Name = "";
            gridColumn4.Width = 130;
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(930, 449);
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(64, 145);
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.superGridControl2);
            this.splitContainer1.Size = new System.Drawing.Size(930, 569);
            this.splitContainer1.SplitterDistance = 100;
            // 
            // statusLabel
            // 
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.statusLabel.Location = new System.Drawing.Point(64, 722);
            this.statusLabel.Size = new System.Drawing.Size(744, 30);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.Location = new System.Drawing.Point(3, 3);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(114, 19);
            labelX1.TabIndex = 0;
            labelX1.Text = "Apartado:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.Location = new System.Drawing.Point(445, 71);
            labelX2.Name = "labelX2";
            labelX2.Size = new System.Drawing.Size(48, 19);
            labelX2.TabIndex = 23;
            labelX2.Text = "DESDE:";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX3.Location = new System.Drawing.Point(639, 71);
            labelX3.Name = "labelX3";
            labelX3.Size = new System.Drawing.Size(51, 19);
            labelX3.TabIndex = 24;
            labelX3.Text = "HASTA:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33629F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarTextBoxX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cantidadLetraLabelX, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buscarButtonX, 7, 0);
            this.tableLayoutPanel1.Controls.Add(labelX2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(labelX3, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.dateTimeInput1, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.dateTimeInput2, 5, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(930, 100);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel5, 2);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.contadoRadioButton, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.creditoRadioButton, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 71);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(436, 26);
            this.tableLayoutPanel5.TabIndex = 22;
            // 
            // contadoRadioButton
            // 
            this.contadoRadioButton.AutoSize = true;
            this.contadoRadioButton.Location = new System.Drawing.Point(3, 3);
            this.contadoRadioButton.Name = "contadoRadioButton";
            this.contadoRadioButton.Size = new System.Drawing.Size(67, 20);
            this.contadoRadioButton.TabIndex = 3;
            this.contadoRadioButton.Text = "Todos ";
            this.contadoRadioButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.contadoRadioButton.UseVisualStyleBackColor = true;
            // 
            // creditoRadioButton
            // 
            this.creditoRadioButton.AutoSize = true;
            this.creditoRadioButton.Checked = true;
            this.creditoRadioButton.Location = new System.Drawing.Point(221, 3);
            this.creditoRadioButton.Name = "creditoRadioButton";
            this.creditoRadioButton.Size = new System.Drawing.Size(161, 20);
            this.creditoRadioButton.TabIndex = 4;
            this.creditoRadioButton.TabStop = true;
            this.creditoRadioButton.Text = "Apartados sin remisión";
            this.creditoRadioButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.creditoRadioButton.UseVisualStyleBackColor = true;
            // 
            // buscarTextBoxX
            // 
            this.buscarTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buscarTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.buscarTextBoxX.Border.Class = "TextBoxBorder";
            this.buscarTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.buscarTextBoxX, 5);
            this.buscarTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.highlighter.SetHighlightOnFocus(this.buscarTextBoxX, true);
            this.buscarTextBoxX.Location = new System.Drawing.Point(123, 3);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(706, 25);
            this.buscarTextBoxX.TabIndex = 1;
            this.buscarTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buscarTextBoxX_KeyDown);
            // 
            // cantidadLetraLabelX
            // 
            // 
            // 
            // 
            this.cantidadLetraLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.cantidadLetraLabelX, 4);
            this.cantidadLetraLabelX.Location = new System.Drawing.Point(3, 37);
            this.cantidadLetraLabelX.Name = "cantidadLetraLabelX";
            this.cantidadLetraLabelX.Size = new System.Drawing.Size(630, 19);
            this.cantidadLetraLabelX.TabIndex = 14;
            this.cantidadLetraLabelX.Text = "SELECCIONA UN APARTADO Y PULSANDO EN EL NUMERO PUEDES VER DETALLE";
            // 
            // buscarButtonX
            // 
            this.buscarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buscarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buscarButtonX.Location = new System.Drawing.Point(852, 3);
            this.buscarButtonX.Name = "buscarButtonX";
            this.buscarButtonX.Size = new System.Drawing.Size(75, 25);
            this.buscarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.buscarButtonX.TabIndex = 19;
            this.buscarButtonX.Text = "Buscar";
            this.buscarButtonX.Click += new System.EventHandler(this.buscarButtonX_Click);
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
            this.dateTimeInput1.Location = new System.Drawing.Point(503, 71);
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
            this.dateTimeInput1.MonthCalendar.DisplayMonth = new System.DateTime(2013, 5, 1, 0, 0, 0, 0);
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
            this.dateTimeInput1.Size = new System.Drawing.Size(130, 25);
            this.dateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput1.TabIndex = 25;
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
            this.dateTimeInput2.Location = new System.Drawing.Point(696, 71);
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
            this.dateTimeInput2.MonthCalendar.DisplayMonth = new System.DateTime(2013, 5, 1, 0, 0, 0, 0);
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
            this.dateTimeInput2.Size = new System.Drawing.Size(133, 25);
            this.dateTimeInput2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput2.TabIndex = 26;
            // 
            // superGridControl2
            // 
            this.superGridControl2.BackColor = System.Drawing.Color.White;
            this.superGridControl2.ForeColor = System.Drawing.Color.Black;
            this.superGridControl2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.superGridControl2.Location = new System.Drawing.Point(82, 42);
            this.superGridControl2.Name = "superGridControl2";
            gridColumn5.HeaderText = "SURTIDO";
            gridColumn5.Name = "";
            gridColumn5.Width = 60;
            gridColumn6.HeaderText = "SELECT";
            gridColumn6.Name = "";
            gridColumn6.Width = 50;
            gridColumn7.HeaderText = "HEADER";
            gridColumn7.Name = "";
            gridColumn8.HeaderText = "DESCRIPCION";
            gridColumn8.Name = "";
            gridColumn9.HeaderText = "LINEA";
            gridColumn9.Name = "";
            gridColumn10.HeaderText = "CANTIDAD";
            gridColumn10.Name = "";
            gridColumn11.HeaderText = "PRECIO";
            gridColumn11.Name = "";
            gridColumn12.HeaderText = "DESCUENTO";
            gridColumn12.Name = "";
            gridColumn13.HeaderText = "TOTAL";
            gridColumn13.Name = "";
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn7);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn8);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn9);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn10);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn11);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn12);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn13);
            this.superGridControl2.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl2.Size = new System.Drawing.Size(791, 181);
            this.superGridControl2.TabIndex = 1;
            this.superGridControl2.Text = "superGridControl2";
            // 
            // salirButtonItem
            // 
            this.salirButtonItem.HoverImage = global::SIF.Properties.Resources.ShoppingCart1;
            this.salirButtonItem.Image = global::SIF.Properties.Resources.ShoppingCart;
            this.salirButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.salirButtonItem.Name = "salirButtonItem";
            this.salirButtonItem.Tag = "12";
            this.salirButtonItem.Text = "Convertir en \r\nVenta [F5]";
            this.salirButtonItem.Click += new System.EventHandler(this.salirButtonItem_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.Enabled = false;
            this.buttonItem1.HoverImage = global::SIF.Properties.Resources.LogoutTool1;
            this.buttonItem1.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.buttonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "Kardex\r\n ";
            this.buttonItem1.Visible = false;
            // 
            // cancelarButtonItem
            // 
            this.cancelarButtonItem.HoverImage = global::SIF.Properties.Resources.Cancel1;
            this.cancelarButtonItem.Image = global::SIF.Properties.Resources.Cancel;
            this.cancelarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.cancelarButtonItem.Name = "cancelarButtonItem";
            this.cancelarButtonItem.Tag = "4";
            this.cancelarButtonItem.Text = "Cancelar\r\nApartados";
            this.cancelarButtonItem.Click += new System.EventHandler(this.cancelarButtonItem_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.Enabled = false;
            this.buttonItem3.HoverImage = global::SIF.Properties.Resources.Export1;
            this.buttonItem3.Image = global::SIF.Properties.Resources.Export;
            this.buttonItem3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "Enviar\r\nSolucitud";
            this.buttonItem3.Visible = false;
            // 
            // highlighter
            // 
            this.highlighter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // imprimirButtonItem
            // 
            this.imprimirButtonItem.HoverImage = global::SIF.Properties.Resources.BoxNewTool1;
            this.imprimirButtonItem.Image = global::SIF.Properties.Resources.IMPRIMIR;
            this.imprimirButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.imprimirButtonItem.Name = "imprimirButtonItem";
            this.imprimirButtonItem.Text = "Imprimir\r\n ";
            this.imprimirButtonItem.Click += new System.EventHandler(this.imprimirButtonItem_Click);
            // 
            // ApartadosUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ApartadosUserControl";
            this.Load += new System.EventHandler(this.cotizacionsUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.LabelX cantidadLetraLabelX;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl2;
        private DevComponents.DotNetBar.ButtonItem salirButtonItem;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem cancelarButtonItem;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.RadioButton contadoRadioButton;
        private System.Windows.Forms.RadioButton creditoRadioButton;
        private DevComponents.DotNetBar.ButtonItem imprimirButtonItem;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput2;
    }
}
