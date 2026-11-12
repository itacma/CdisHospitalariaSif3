namespace SIF.View.CallCenter
{
    partial class QuejaSugerenciaUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuejaSugerenciaUserControl));
            DevComponents.DotNetBar.LabelX labelX1;
            DevComponents.DotNetBar.LabelX labelX2;
            DevComponents.DotNetBar.LabelX labelX3;
            DevComponents.DotNetBar.LabelX labelX4;
            DevComponents.DotNetBar.LabelX labelX5;
            DevComponents.DotNetBar.LabelX labelX6;
            this.seleccionaClienteButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.guardarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fechaSucesoDateTimeInput = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.tipoQuejaSugerenciaComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.clienteLabelX = new DevComponents.DotNetBar.LabelX();
            this.sucursalComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.usuarioGeneraLabelX = new DevComponents.DotNetBar.LabelX();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.quejaRadioButton = new System.Windows.Forms.RadioButton();
            this.sugerenciaRadioButton = new System.Windows.Forms.RadioButton();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.quejaTextBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            labelX3 = new DevComponents.DotNetBar.LabelX();
            labelX4 = new DevComponents.DotNetBar.LabelX();
            labelX5 = new DevComponents.DotNetBar.LabelX();
            labelX6 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fechaSucesoDateTimeInput)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.guardarButtonItem});
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(319, 32);
            this.titleLabel.Text = "CAT/QUEJAS Y SUGERENCIAS";
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
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.SplitterDistance = 110;
            // 
            // statusLabel
            // 
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
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
            labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.Location = new System.Drawing.Point(3, 8);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(54, 23);
            labelX1.TabIndex = 0;
            labelX1.Text = "Genera:";
            // 
            // labelX2
            // 
            labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.Location = new System.Drawing.Point(3, 48);
            labelX2.Name = "labelX2";
            labelX2.Size = new System.Drawing.Size(54, 23);
            labelX2.TabIndex = 0;
            labelX2.Text = "Cliente:";
            // 
            // labelX3
            // 
            labelX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX3.Location = new System.Drawing.Point(422, 8);
            labelX3.Name = "labelX3";
            labelX3.Size = new System.Drawing.Size(93, 23);
            labelX3.TabIndex = 0;
            labelX3.Text = "Fecha Suceso:";
            // 
            // labelX4
            // 
            labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX4.Location = new System.Drawing.Point(422, 48);
            labelX4.Name = "labelX4";
            labelX4.Size = new System.Drawing.Size(93, 23);
            labelX4.TabIndex = 0;
            labelX4.Text = "Tipo:";
            // 
            // labelX5
            // 
            labelX5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX5.Location = new System.Drawing.Point(697, 8);
            labelX5.Name = "labelX5";
            labelX5.Size = new System.Drawing.Size(55, 23);
            labelX5.TabIndex = 0;
            labelX5.Text = "Sucursal:";
            // 
            // labelX6
            // 
            labelX6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX6.Location = new System.Drawing.Point(422, 83);
            labelX6.Name = "labelX6";
            labelX6.Size = new System.Drawing.Size(93, 23);
            labelX6.TabIndex = 7;
            labelX6.Text = "Sub Tipo:";
            // 
            // seleccionaClienteButtonItem
            // 
            this.seleccionaClienteButtonItem.HoverImage = global::SIF.Properties.Resources.UserFindTool1;
            this.seleccionaClienteButtonItem.Image = global::SIF.Properties.Resources.UserFindTool;
            this.seleccionaClienteButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.seleccionaClienteButtonItem.Name = "seleccionaClienteButtonItem";
            this.seleccionaClienteButtonItem.Text = "Cliente\r\n[F3]";
            this.seleccionaClienteButtonItem.Click += new System.EventHandler(this.seleccionaClienteButtonItem_Click);
            // 
            // guardarButtonItem
            // 
            this.guardarButtonItem.HoverImage = global::SIF.Properties.Resources.SaveTool1;
            this.guardarButtonItem.Image = global::SIF.Properties.Resources.SaveTool;
            this.guardarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.guardarButtonItem.Name = "guardarButtonItem";
            this.guardarButtonItem.Text = "Guardar\r\n[F5]";
            this.guardarButtonItem.Click += new System.EventHandler(this.guardarButtonItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(labelX2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(labelX3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(labelX4, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.fechaSucesoDateTimeInput, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tipoQuejaSugerenciaComboBoxEx, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.clienteLabelX, 1, 1);
            this.tableLayoutPanel1.Controls.Add(labelX5, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.sucursalComboBoxEx, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.usuarioGeneraLabelX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 6, 1);
            this.tableLayoutPanel1.Controls.Add(labelX6, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxEx1, 4, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 110);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // fechaSucesoDateTimeInput
            // 
            this.fechaSucesoDateTimeInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.fechaSucesoDateTimeInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.fechaSucesoDateTimeInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechaSucesoDateTimeInput.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.fechaSucesoDateTimeInput.ButtonDropDown.Visible = true;
            this.fechaSucesoDateTimeInput.IsPopupCalendarOpen = false;
            this.fechaSucesoDateTimeInput.Location = new System.Drawing.Point(521, 7);
            // 
            // 
            // 
            this.fechaSucesoDateTimeInput.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.fechaSucesoDateTimeInput.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechaSucesoDateTimeInput.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.fechaSucesoDateTimeInput.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.fechaSucesoDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.fechaSucesoDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.fechaSucesoDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.fechaSucesoDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fechaSucesoDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.fechaSucesoDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.fechaSucesoDateTimeInput.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechaSucesoDateTimeInput.MonthCalendar.DisplayMonth = new System.DateTime(2012, 11, 1, 0, 0, 0, 0);
            this.fechaSucesoDateTimeInput.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.fechaSucesoDateTimeInput.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.fechaSucesoDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.fechaSucesoDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.fechaSucesoDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.fechaSucesoDateTimeInput.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechaSucesoDateTimeInput.MonthCalendar.TodayButtonVisible = true;
            this.fechaSucesoDateTimeInput.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.fechaSucesoDateTimeInput.Name = "fechaSucesoDateTimeInput";
            this.fechaSucesoDateTimeInput.Size = new System.Drawing.Size(152, 25);
            this.fechaSucesoDateTimeInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.fechaSucesoDateTimeInput.TabIndex = 3;
            // 
            // tipoQuejaSugerenciaComboBoxEx
            // 
            this.tipoQuejaSugerenciaComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tipoQuejaSugerenciaComboBoxEx.DisplayMember = "Text";
            this.tipoQuejaSugerenciaComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tipoQuejaSugerenciaComboBoxEx.FormattingEnabled = true;
            this.tipoQuejaSugerenciaComboBoxEx.ItemHeight = 19;
            this.tipoQuejaSugerenciaComboBoxEx.Location = new System.Drawing.Point(521, 47);
            this.tipoQuejaSugerenciaComboBoxEx.Name = "tipoQuejaSugerenciaComboBoxEx";
            this.tipoQuejaSugerenciaComboBoxEx.Size = new System.Drawing.Size(152, 25);
            this.tipoQuejaSugerenciaComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tipoQuejaSugerenciaComboBoxEx.TabIndex = 4;
            this.tipoQuejaSugerenciaComboBoxEx.SelectedIndexChanged += new System.EventHandler(this.tipoQuejaSugerenciaComboBoxEx_SelectedIndexChanged);
            // 
            // clienteLabelX
            // 
            this.clienteLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.clienteLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.clienteLabelX.Location = new System.Drawing.Point(63, 48);
            this.clienteLabelX.Name = "clienteLabelX";
            this.clienteLabelX.Size = new System.Drawing.Size(311, 23);
            this.clienteLabelX.TabIndex = 5;
            this.clienteLabelX.Text = "[CLIENTE]";
            // 
            // sucursalComboBoxEx
            // 
            this.sucursalComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sucursalComboBoxEx.DisplayMember = "Text";
            this.sucursalComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.sucursalComboBoxEx.FormattingEnabled = true;
            this.sucursalComboBoxEx.ItemHeight = 19;
            this.sucursalComboBoxEx.Location = new System.Drawing.Point(758, 7);
            this.sucursalComboBoxEx.Name = "sucursalComboBoxEx";
            this.sucursalComboBoxEx.Size = new System.Drawing.Size(154, 25);
            this.sucursalComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sucursalComboBoxEx.TabIndex = 6;
            // 
            // usuarioGeneraLabelX
            // 
            this.usuarioGeneraLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.usuarioGeneraLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.usuarioGeneraLabelX.Location = new System.Drawing.Point(63, 8);
            this.usuarioGeneraLabelX.Name = "usuarioGeneraLabelX";
            this.usuarioGeneraLabelX.Size = new System.Drawing.Size(311, 23);
            this.usuarioGeneraLabelX.TabIndex = 5;
            this.usuarioGeneraLabelX.Text = "[GENERA]";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.quejaRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.sugerenciaRadioButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(697, 45);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(215, 30);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // quejaRadioButton
            // 
            this.quejaRadioButton.AutoSize = true;
            this.quejaRadioButton.Location = new System.Drawing.Point(3, 3);
            this.quejaRadioButton.Name = "quejaRadioButton";
            this.quejaRadioButton.Size = new System.Drawing.Size(60, 21);
            this.quejaRadioButton.TabIndex = 1;
            this.quejaRadioButton.TabStop = true;
            this.quejaRadioButton.Text = "Queja";
            this.quejaRadioButton.UseVisualStyleBackColor = true;
            // 
            // sugerenciaRadioButton
            // 
            this.sugerenciaRadioButton.AutoSize = true;
            this.sugerenciaRadioButton.Location = new System.Drawing.Point(69, 3);
            this.sugerenciaRadioButton.Name = "sugerenciaRadioButton";
            this.sugerenciaRadioButton.Size = new System.Drawing.Size(90, 21);
            this.sugerenciaRadioButton.TabIndex = 1;
            this.sugerenciaRadioButton.TabStop = true;
            this.sugerenciaRadioButton.Text = "Sugerencia";
            this.sugerenciaRadioButton.UseVisualStyleBackColor = true;
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 19;
            this.comboBoxEx1.Location = new System.Drawing.Point(521, 83);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(152, 25);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.quejaTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 333);
            this.panel1.TabIndex = 0;
            // 
            // quejaTextBox
            // 
            this.quejaTextBox.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.quejaTextBox.Border.Class = "TextBoxBorder";
            this.quejaTextBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.quejaTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quejaTextBox.ForeColor = System.Drawing.Color.Black;
            this.quejaTextBox.Location = new System.Drawing.Point(0, 0);
            this.quejaTextBox.MaxLength = 500;
            this.quejaTextBox.Multiline = true;
            this.quejaTextBox.Name = "quejaTextBox";
            this.quejaTextBox.Size = new System.Drawing.Size(915, 333);
            this.quejaTextBox.TabIndex = 2;
            this.quejaTextBox.WatermarkText = "Comentario de queja o sugerencia";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.textBoxX1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 333);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.79339F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.20661F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(915, 121);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // textBoxX1
            // 
            this.textBoxX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxX1.ForeColor = System.Drawing.Color.Black;
            this.textBoxX1.Location = new System.Drawing.Point(3, 33);
            this.textBoxX1.MaxLength = 500;
            this.textBoxX1.Multiline = true;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(909, 85);
            this.textBoxX1.TabIndex = 3;
            this.textBoxX1.WatermarkText = "Solucion de queja o sugerencia";
            // 
            // QuejaSugerenciaUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "QuejaSugerenciaUserControl";
            this.Load += new System.EventHandler(this.QuejaSugerenciaUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fechaSucesoDateTimeInput)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem seleccionaClienteButtonItem;
        private DevComponents.DotNetBar.ButtonItem guardarButtonItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton quejaRadioButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton sugerenciaRadioButton;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput fechaSucesoDateTimeInput;
        private DevComponents.DotNetBar.Controls.ComboBoxEx tipoQuejaSugerenciaComboBoxEx;
        private DevComponents.DotNetBar.LabelX usuarioGeneraLabelX;
        private DevComponents.DotNetBar.LabelX clienteLabelX;
        private DevComponents.DotNetBar.Controls.ComboBoxEx sucursalComboBoxEx;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.TextBoxX quejaTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
    }
}
