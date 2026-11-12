namespace SIF.View.Ventas
{
    partial class ControlCajasUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlCajasUserControl));
            DevComponents.DotNetBar.LabelX labelX1;
            DevComponents.DotNetBar.LabelX labelX2;
            DevComponents.DotNetBar.LabelX labelX3;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CerrarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sucursalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SiNoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buscarBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.USUARIOColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ColumnNombre = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.FECHA_APERTURAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.MONTOColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ESTADOColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.recoleccionButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.controlCajaButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.fechaInicioDateTimeInput = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.fechaTerminoDateTimeInput = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            labelX3 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiNoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fechaInicioDateTimeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaTerminoDateTimeInput)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.CerrarButtonItem,
            this.recoleccionButtonItem,
            this.controlCajaButtonItem});
            this.bar1.ItemSpacing = 10;
            this.bar1.Size = new System.Drawing.Size(793, 92);
            this.bar1.ItemClick += new System.EventHandler(this.bar1_ItemClick);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(186, 32);
            this.titleLabel.Text = "SIF\\Control Cajas";
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewX1);
            this.splitContainer1.SplitterDistance = 31;
            // 
            // statusLabel
            // 
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.statusLabel.Text = "";
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
            // labelX1
            // 
            labelX1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelX1.AutoSize = true;
            // 
            // 
            // 
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.Location = new System.Drawing.Point(3, 5);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(43, 20);
            labelX1.TabIndex = 1;
            labelX1.Text = "Buscar:";
            // 
            // labelX2
            // 
            labelX2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelX2.AutoSize = true;
            // 
            // 
            // 
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.Location = new System.Drawing.Point(480, 5);
            labelX2.Name = "labelX2";
            labelX2.Size = new System.Drawing.Size(41, 20);
            labelX2.TabIndex = 1;
            labelX2.Text = "Desde:";
            // 
            // labelX3
            // 
            labelX3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelX3.AutoSize = true;
            // 
            // 
            // 
            labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX3.Location = new System.Drawing.Point(662, 5);
            labelX3.Name = "labelX3";
            labelX3.Size = new System.Drawing.Size(38, 20);
            labelX3.TabIndex = 1;
            labelX3.Text = "Hasta:";
            // 
            // CerrarButtonItem
            // 
            this.CerrarButtonItem.HoverImage = global::SIF.Properties.Resources.Bid1;
            this.CerrarButtonItem.Image = global::SIF.Properties.Resources.Bid;
            this.CerrarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.CerrarButtonItem.Name = "CerrarButtonItem";
            this.CerrarButtonItem.Text = "Cerrar\r\n[F6]";
            this.CerrarButtonItem.Click += new System.EventHandler(this.CerrarButtonItem_Click);
            // 
            // highlighter1
            // 
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
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
            this.buscarTextBoxX.ButtonCustom.Image = global::SIF.Properties.Resources.FilterDelete16;
            this.buscarTextBoxX.ButtonCustom.Visible = true;
            this.buscarTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.highlighter1.SetHighlightOnFocus(this.buscarTextBoxX, true);
            this.buscarTextBoxX.Location = new System.Drawing.Point(51, 3);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(420, 25);
            this.buscarTextBoxX.TabIndex = 0;
            this.buscarTextBoxX.WatermarkText = "Buscar";
            this.buscarTextBoxX.ButtonCustomClick += new System.EventHandler(this.buscarTextBoxX_ButtonCustomClick);
            this.buscarTextBoxX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buscarTextBoxX_KeyUp);
            // 
            // buscarBackgroundWorker
            // 
            this.buscarBackgroundWorker.WorkerReportsProgress = true;
            this.buscarBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.buscarBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AutoGenerateColumns = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.USUARIOColumn,
            this.ColumnNombre,
            this.FECHA_APERTURAColumn,
            this.MONTOColumn,
            this.ESTADOColumn});
            this.dataGridViewX1.DataSource = this.bindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.EnableHeadersVisualStyles = false;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(915, 533);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_ColumnHeaderMouseClick);
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            // 
            // USUARIOColumn
            // 
            this.USUARIOColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.USUARIOColumn.DataPropertyName = "NombreUsuario";
            this.USUARIOColumn.HeaderText = "USUARIO";
            this.USUARIOColumn.Name = "USUARIOColumn";
            this.USUARIOColumn.ReadOnly = true;
            this.USUARIOColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.USUARIOColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.USUARIOColumn.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ColumnNombre
            // 
            this.ColumnNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnNombre.DataPropertyName = "Nombre";
            this.ColumnNombre.HeaderText = "NOMBRE";
            this.ColumnNombre.Name = "ColumnNombre";
            this.ColumnNombre.ReadOnly = true;
            this.ColumnNombre.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnNombre.Width = 87;
            // 
            // FECHA_APERTURAColumn
            // 
            this.FECHA_APERTURAColumn.DataPropertyName = "FechaApertura";
            this.FECHA_APERTURAColumn.HeaderText = "FECHA APERTURA";
            this.FECHA_APERTURAColumn.Name = "FECHA_APERTURAColumn";
            this.FECHA_APERTURAColumn.ReadOnly = true;
            this.FECHA_APERTURAColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FECHA_APERTURAColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MONTOColumn
            // 
            this.MONTOColumn.DataPropertyName = "MontoInicial";
            this.MONTOColumn.HeaderText = "MONTO INICIAL";
            this.MONTOColumn.Name = "MONTOColumn";
            this.MONTOColumn.ReadOnly = true;
            this.MONTOColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MONTOColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ESTADOColumn
            // 
            this.ESTADOColumn.DataPropertyName = "ABIERTO";
            this.ESTADOColumn.HeaderText = "ESTADO";
            this.ESTADOColumn.Name = "ESTADOColumn";
            this.ESTADOColumn.ReadOnly = true;
            // 
            // recoleccionButtonItem
            // 
            this.recoleccionButtonItem.HoverImage = global::SIF.Properties.Resources.Cent1;
            this.recoleccionButtonItem.Image = global::SIF.Properties.Resources.Cent;
            this.recoleccionButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.recoleccionButtonItem.Name = "recoleccionButtonItem";
            this.recoleccionButtonItem.Text = "Recolección\r\n ";
            this.recoleccionButtonItem.Click += new System.EventHandler(this.recoleccionButtonItem_Click);
            // 
            // controlCajaButtonItem
            // 
            this.controlCajaButtonItem.HoverImage = global::SIF.Properties.Resources.Cent1;
            this.controlCajaButtonItem.Image = global::SIF.Properties.Resources.Cent;
            this.controlCajaButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.controlCajaButtonItem.Name = "controlCajaButtonItem";
            this.controlCajaButtonItem.Text = "Corte\r\n ";
            this.controlCajaButtonItem.Click += new System.EventHandler(this.controlCajaButtonItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.Controls.Add(labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarTextBoxX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarButtonX, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.fechaInicioDateTimeInput, 3, 0);
            this.tableLayoutPanel1.Controls.Add(labelX2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.fechaTerminoDateTimeInput, 5, 0);
            this.tableLayoutPanel1.Controls.Add(labelX3, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 31);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // buscarButtonX
            // 
            this.buscarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buscarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buscarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buscarButtonX.Location = new System.Drawing.Point(837, 4);
            this.buscarButtonX.Name = "buscarButtonX";
            this.buscarButtonX.Size = new System.Drawing.Size(75, 23);
            this.buscarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buscarButtonX.TabIndex = 0;
            this.buscarButtonX.Text = "Buscar";
            this.buscarButtonX.Click += new System.EventHandler(this.buscarButtonX_Click);
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
            this.fechaInicioDateTimeInput.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector;
            this.fechaInicioDateTimeInput.IsPopupCalendarOpen = false;
            this.fechaInicioDateTimeInput.Location = new System.Drawing.Point(527, 3);
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
            this.fechaInicioDateTimeInput.Size = new System.Drawing.Size(124, 25);
            this.fechaInicioDateTimeInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.fechaInicioDateTimeInput.TabIndex = 26;
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
            this.fechaTerminoDateTimeInput.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector;
            this.fechaTerminoDateTimeInput.IsPopupCalendarOpen = false;
            this.fechaTerminoDateTimeInput.Location = new System.Drawing.Point(706, 3);
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
            this.fechaTerminoDateTimeInput.Size = new System.Drawing.Size(124, 25);
            this.fechaTerminoDateTimeInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.fechaTerminoDateTimeInput.TabIndex = 26;
            // 
            // ControlCajasUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.Name = "ControlCajasUserControl";
            this.Load += new System.EventHandler(this.CatCajasUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiNoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fechaInicioDateTimeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaTerminoDateTimeInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem CerrarButtonItem;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.BindingSource sucursalesBindingSource;
        private System.ComponentModel.BackgroundWorker buscarBackgroundWorker;
        private System.Windows.Forms.BindingSource SiNoBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonItem recoleccionButtonItem;
        private DevComponents.DotNetBar.ButtonItem controlCajaButtonItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput fechaInicioDateTimeInput;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput fechaTerminoDateTimeInput;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn USUARIOColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ColumnNombre;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn FECHA_APERTURAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn MONTOColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ESTADOColumn;
    }
}
