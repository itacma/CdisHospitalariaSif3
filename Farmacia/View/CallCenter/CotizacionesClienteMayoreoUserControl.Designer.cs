namespace SIF.View.CallCenter
{
    partial class CotizacionesClienteMayoreoUserControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CotizacionesClienteMayoreoUserControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimeInput1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateTimeInput2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.rbTodo = new System.Windows.Forms.RadioButton();
            this.rbAbiertas = new System.Windows.Forms.RadioButton();
            this.rbTerminadas = new System.Windows.Forms.RadioButton();
            this.rbConverRemision = new System.Windows.Forms.RadioButton();
            this.rbCancelados = new System.Windows.Forms.RadioButton();
            this.rbLiberados = new System.Windows.Forms.RadioButton();
            this.nuevoPedidoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).BeginInit();
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

            this.backButton.Size = new System.Drawing.Size(48, 48);
            this.backButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.backButton.TabIndex = 14;
            this.backButton.Text = "\r\nRegresar";
            this.backButton.Tooltip = "Regresar [F12]";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(352, 32);
            this.titleLabel.Text = "SIF\\Cotizaciones Cliente Mayorista";
            // 
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
            this.nuevoPedidoButtonItem,
            this.buttonItem1});
            this.bar1.Location = new System.Drawing.Point(64, 44);
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(793, 101);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 15;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.SplitterDistance = 140;
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
            // fotoPictureBox
            // 
            this.fotoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("fotoPictureBox.Image")));
            // 
            // apellidosLabel
            // 
            this.apellidosLabel.Text = "";
            // 
            // nombreLabel
            // 
            this.nombreLabel.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewX1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(906, 389);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewX1, 5);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewX1, 4);
            this.dataGridViewX1.RowTemplate.Height = 24;
            this.dataGridViewX1.Size = new System.Drawing.Size(900, 311);
            this.dataGridViewX1.TabIndex = 0;
            // 
            // buscarTextBoxX
            // 
            this.buscarTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buscarTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.buscarTextBoxX.Border.Class = "TextBoxBorder";
            this.buscarTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel2.SetColumnSpan(this.buscarTextBoxX, 2);
            this.buscarTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.buscarTextBoxX.Location = new System.Drawing.Point(116, 38);
            this.buscarTextBoxX.Margin = new System.Windows.Forms.Padding(4);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(216, 35);
            this.buscarTextBoxX.TabIndex = 1;
            this.buscarTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buscarTextBoxX_KeyDown);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.Controls.Add(this.buscarTextBoxX, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.dateTimeInput1, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.dateTimeInput2, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.buscarButtonX, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblBuscar, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblFechaInicio, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblFechaFin, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.rbTodo, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.rbAbiertas, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.rbTerminadas, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.rbConverRemision, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.rbCancelados, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.rbLiberados, 5, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(9, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(903, 134);
            this.tableLayoutPanel2.TabIndex = 0;
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
            this.dateTimeInput1.Location = new System.Drawing.Point(451, 37);
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
            this.dateTimeInput1.Size = new System.Drawing.Size(106, 29);
            this.dateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput1.TabIndex = 22;
            // 
            // dateTimeInput2
            // 
            this.dateTimeInput2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.dateTimeInput2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput2.ButtonDropDown.Visible = true;
            this.dateTimeInput2.IsPopupCalendarOpen = false;
            this.dateTimeInput2.Location = new System.Drawing.Point(675, 37);
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
            this.dateTimeInput2.Size = new System.Drawing.Size(106, 29);
            this.dateTimeInput2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput2.TabIndex = 22;
            // 
            // buscarButtonX
            // 
            this.buscarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buscarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buscarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buscarButtonX.Location = new System.Drawing.Point(788, 38);
            this.buscarButtonX.Margin = new System.Windows.Forms.Padding(4);
            this.buscarButtonX.Name = "buscarButtonX";
            this.buscarButtonX.Size = new System.Drawing.Size(111, 26);
            this.buscarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.buscarButtonX.TabIndex = 19;
            this.buscarButtonX.Text = "Buscar";
            this.buscarButtonX.Click += new System.EventHandler(this.buscarButtonX_Click);
            // 
            // lblBuscar
            // 
            this.lblBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(3, 34);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(64, 34);
            this.lblBuscar.TabIndex = 23;
            this.lblBuscar.Text = "Buscar;";
            this.lblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(341, 34);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(104, 34);
            this.lblFechaInicio.TabIndex = 24;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            this.lblFechaInicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(584, 34);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(85, 34);
            this.lblFechaFin.TabIndex = 25;
            this.lblFechaFin.Text = "Fecha Fin:";
            this.lblFechaFin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbTodo
            // 
            this.rbTodo.AutoSize = true;
            this.rbTodo.Location = new System.Drawing.Point(3, 71);
            this.rbTodo.Name = "rbTodo";
            this.rbTodo.Size = new System.Drawing.Size(68, 27);
            this.rbTodo.TabIndex = 26;
            this.rbTodo.TabStop = true;
            this.rbTodo.Text = "Todo";
            this.rbTodo.UseVisualStyleBackColor = true;
            // 
            // rbAbiertas
            // 
            this.rbAbiertas.AutoSize = true;
            this.rbAbiertas.Location = new System.Drawing.Point(115, 71);
            this.rbAbiertas.Name = "rbAbiertas";
            this.rbAbiertas.Size = new System.Drawing.Size(93, 27);
            this.rbAbiertas.TabIndex = 27;
            this.rbAbiertas.TabStop = true;
            this.rbAbiertas.Text = "Abiertas";
            this.rbAbiertas.UseVisualStyleBackColor = true;
            // 
            // rbTerminadas
            // 
            this.rbTerminadas.AutoSize = true;
            this.rbTerminadas.Location = new System.Drawing.Point(227, 71);
            this.rbTerminadas.Name = "rbTerminadas";
            this.rbTerminadas.Size = new System.Drawing.Size(106, 27);
            this.rbTerminadas.TabIndex = 28;
            this.rbTerminadas.TabStop = true;
            this.rbTerminadas.Text = "Terminadas";
            this.rbTerminadas.UseVisualStyleBackColor = true;
            // 
            // rbConverRemision
            // 
            this.rbConverRemision.AutoSize = true;
            this.rbConverRemision.Location = new System.Drawing.Point(339, 71);
            this.rbConverRemision.Name = "rbConverRemision";
            this.rbConverRemision.Size = new System.Drawing.Size(106, 27);
            this.rbConverRemision.TabIndex = 29;
            this.rbConverRemision.TabStop = true;
            this.rbConverRemision.Text = "Con Remision";
            this.rbConverRemision.UseVisualStyleBackColor = true;
            // 
            // rbCancelados
            // 
            this.rbCancelados.AutoSize = true;
            this.rbCancelados.Location = new System.Drawing.Point(451, 71);
            this.rbCancelados.Name = "rbCancelados";
            this.rbCancelados.Size = new System.Drawing.Size(106, 27);
            this.rbCancelados.TabIndex = 30;
            this.rbCancelados.TabStop = true;
            this.rbCancelados.Text = "Cancelados";
            this.rbCancelados.UseVisualStyleBackColor = true;
            // 
            // rbLiberados
            // 
            this.rbLiberados.AutoSize = true;
            this.rbLiberados.Location = new System.Drawing.Point(563, 71);
            this.rbLiberados.Name = "rbLiberados";
            this.rbLiberados.Size = new System.Drawing.Size(104, 27);
            this.rbLiberados.TabIndex = 31;
            this.rbLiberados.TabStop = true;
            this.rbLiberados.Text = "Liberados";
            this.rbLiberados.UseVisualStyleBackColor = true;
            // 
            // nuevoPedidoButtonItem
            // 
            this.nuevoPedidoButtonItem.HoverImage = global::SIF.Properties.Resources.BoxNewTool1;
            this.nuevoPedidoButtonItem.Image = global::SIF.Properties.Resources.BoxNewTool;
            this.nuevoPedidoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.nuevoPedidoButtonItem.Name = "nuevoPedidoButtonItem";
            this.nuevoPedidoButtonItem.Tag = "1";
            this.nuevoPedidoButtonItem.Text = "Nuevo\r\n ";
            this.nuevoPedidoButtonItem.Click += new System.EventHandler(this.nuevoPedidoButtonItem_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.HoverImage = global::SIF.Properties.Resources.BoxNewTool1;
            this.buttonItem1.Image = global::SIF.Properties.Resources.ABRIR;
            this.buttonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Tag = "30";
            this.buttonItem1.Text = "Abrir\r\n ";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // CotizacionesClienteMayoreoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CotizacionesClienteMayoreoUserControl";
            this.Controls.SetChildIndex(this.nombreLabel, 0);
            this.Controls.SetChildIndex(this.apellidosLabel, 0);
            this.Controls.SetChildIndex(this.fotoPictureBox, 0);
            this.Controls.SetChildIndex(this.sucursalLabel, 0);
            this.Controls.SetChildIndex(this.statusLabel, 0);
            this.Controls.SetChildIndex(this.titleLabel, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.Controls.SetChildIndex(this.bar1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem nuevoPedidoButtonItem;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput2;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.RadioButton rbTodo;
        private System.Windows.Forms.RadioButton rbAbiertas;
        private System.Windows.Forms.RadioButton rbTerminadas;
        private System.Windows.Forms.RadioButton rbConverRemision;
        private System.Windows.Forms.RadioButton rbCancelados;
        private System.Windows.Forms.RadioButton rbLiberados;

    }
}
