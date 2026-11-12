namespace SIF.View.Almacen
{
    partial class RecepcionUserControl
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
            DevComponents.DotNetBar.LabelX labelX1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecepcionUserControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NuevoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.eliminarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Folio = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.FOLIOID = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.PROVEEDORID = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.PROVEEDOR = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.FECHA = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTADO_OC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHAR = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.FECHAM = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.FACTURA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTROLADO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OBSERVACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USUARIOid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUCURSAL_ID = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.ACTIVO = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.buscarBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.NuevoButtonItem,
            this.eliminarButtonItem,
            this.buttonItem3});
            this.bar1.ItemSpacing = 10;
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(373, 32);
            this.titleLabel.Text = "ALMACEN\\RECEPCION DE BULTOS";
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
            this.splitContainer1.SplitterDistance = 32;
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
            labelX1.Location = new System.Drawing.Point(3, 6);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(43, 20);
            labelX1.TabIndex = 1;
            labelX1.Text = "Buscar:";
            // 
            // NuevoButtonItem
            // 
            this.NuevoButtonItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("NuevoButtonItem.HoverImage")));
            this.NuevoButtonItem.Image = ((System.Drawing.Image)(resources.GetObject("NuevoButtonItem.Image")));
            this.NuevoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.NuevoButtonItem.Name = "NuevoButtonItem";
            this.NuevoButtonItem.Tag = "1";
            this.NuevoButtonItem.Text = "Nuevo\r\n[F2]";
            this.NuevoButtonItem.Click += new System.EventHandler(this.NuevoButtonItem_Click);
            // 
            // eliminarButtonItem
            // 
            this.eliminarButtonItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("eliminarButtonItem.HoverImage")));
            this.eliminarButtonItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarButtonItem.Image")));
            this.eliminarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.eliminarButtonItem.Name = "eliminarButtonItem";
            this.eliminarButtonItem.Tag = "6";
            this.eliminarButtonItem.Text = "Eliminar\r\n[F6]";
            this.eliminarButtonItem.Click += new System.EventHandler(this.eliminarButtonItem_Click);
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
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
            this.buscarTextBoxX.Size = new System.Drawing.Size(779, 25);
            this.buscarTextBoxX.TabIndex = 2;
            this.buscarTextBoxX.WatermarkText = "Buscar";
            this.buscarTextBoxX.ButtonCustomClick += new System.EventHandler(this.buscarTextBoxX_ButtonCustomClick);
            this.buscarTextBoxX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buscarTextBoxX_KeyUp);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToOrderColumns = true;
            this.dataGridViewX1.AutoGenerateColumns = false;
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Folio,
            this.FOLIOID,
            this.PROVEEDORID,
            this.PROVEEDOR,
            this.FECHA,
            this.USUARIO,
            this.ESTADO_OC,
            this.FECHAR,
            this.FECHAM,
            this.FACTURA,
            this.TOTAL,
            this.CONTROLADO,
            this.OBSERVACION,
            this.USUARIOid,
            this.SUCURSAL_ID,
            this.ACTIVO});
            this.dataGridViewX1.DataSource = this.bindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(915, 532);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            this.dataGridViewX1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewX1_CellValidating);
            this.dataGridViewX1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_ColumnHeaderMouseClick);
            this.dataGridViewX1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_RowEnter);
            this.dataGridViewX1.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_RowValidated);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            this.dataGridViewX1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyUp);
            this.dataGridViewX1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewX1_MouseDoubleClick);
            // 
            // Folio
            // 
            // 
            // 
            // 
            this.Folio.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Folio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Folio.DataPropertyName = "BULTO_ID";
            this.Folio.HeaderText = "FOLIO";
            this.Folio.Name = "Folio";
            this.Folio.Width = 68;
            // 
            // FOLIOID
            // 
            this.FOLIOID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.FOLIOID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.FOLIOID.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.FOLIOID.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.FOLIOID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FOLIOID.ButtonCustom.Visible = true;
            this.FOLIOID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.FOLIOID.DataPropertyName = "FOLIO_OC_ID";
            this.FOLIOID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FOLIOID.HeaderText = "FOLIO ORDEN COMPRA";
            this.FOLIOID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FOLIOID.Name = "FOLIOID";
            this.FOLIOID.PasswordChar = '\0';
            this.FOLIOID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FOLIOID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FOLIOID.Text = "";
            this.FOLIOID.Width = 158;
            // 
            // PROVEEDORID
            // 
            // 
            // 
            // 
            this.PROVEEDORID.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.PROVEEDORID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PROVEEDORID.DataPropertyName = "PROVEEDOR_ID";
            this.PROVEEDORID.HeaderText = "PROVEEDOR ID";
            this.PROVEEDORID.Name = "PROVEEDORID";
            this.PROVEEDORID.Width = 113;
            // 
            // PROVEEDOR
            // 
            this.PROVEEDOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.PROVEEDOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.PROVEEDOR.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.PROVEEDOR.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.PROVEEDOR.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PROVEEDOR.ButtonCustom.Visible = true;
            this.PROVEEDOR.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.PROVEEDOR.DataPropertyName = "NOMBRE_PROVEEDOR";
            this.PROVEEDOR.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PROVEEDOR.HeaderText = "PROVEEDOR";
            this.PROVEEDOR.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PROVEEDOR.Name = "PROVEEDOR";
            this.PROVEEDOR.PasswordChar = '\0';
            this.PROVEEDOR.ReadOnly = true;
            this.PROVEEDOR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PROVEEDOR.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PROVEEDOR.Text = "";
            this.PROVEEDOR.Width = 107;
            // 
            // FECHA
            // 
            // 
            // 
            // 
            this.FECHA.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.FECHA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA.ButtonDropDown.Visible = true;
            this.FECHA.DataPropertyName = "FECHA";
            this.FECHA.HeaderText = "FECHA";
            this.FECHA.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.FECHA.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FECHA.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.FECHA.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA.MonthCalendar.DisplayMonth = new System.DateTime(2013, 3, 1, 0, 0, 0, 0);
            this.FECHA.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.FECHA.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FECHA.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.FECHA.Name = "FECHA";
            this.FECHA.Width = 71;
            // 
            // USUARIO
            // 
            this.USUARIO.HeaderText = "USUARIO";
            this.USUARIO.Name = "USUARIO";
            this.USUARIO.Width = 87;
            // 
            // ESTADO_OC
            // 
            this.ESTADO_OC.DataPropertyName = "ESTADO_OC";
            this.ESTADO_OC.HeaderText = "ESTADO_OC";
            this.ESTADO_OC.MaxInputLength = 3;
            this.ESTADO_OC.Name = "ESTADO_OC";
            this.ESTADO_OC.Width = 104;
            // 
            // FECHAR
            // 
            // 
            // 
            // 
            this.FECHAR.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.FECHAR.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHAR.ButtonDropDown.Visible = true;
            this.FECHAR.DataPropertyName = "FECHA_RECEPCION";
            this.FECHAR.HeaderText = "FECHA RECEPCION";
            this.FECHAR.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.FECHAR.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FECHAR.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHAR.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.FECHAR.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHAR.MonthCalendar.DisplayMonth = new System.DateTime(2013, 3, 1, 0, 0, 0, 0);
            this.FECHAR.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.FECHAR.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FECHAR.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHAR.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.FECHAR.Name = "FECHAR";
            this.FECHAR.Width = 131;
            // 
            // FECHAM
            // 
            // 
            // 
            // 
            this.FECHAM.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.FECHAM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHAM.ButtonDropDown.Visible = true;
            this.FECHAM.DataPropertyName = "FECHA_MENSAJERIA";
            this.FECHAM.HeaderText = "FECHA MENSAJERIA";
            this.FECHAM.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.FECHAM.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FECHAM.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHAM.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.FECHAM.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHAM.MonthCalendar.DisplayMonth = new System.DateTime(2013, 3, 1, 0, 0, 0, 0);
            this.FECHAM.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.FECHAM.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FECHAM.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHAM.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.FECHAM.Name = "FECHAM";
            this.FECHAM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FECHAM.Width = 137;
            // 
            // FACTURA
            // 
            this.FACTURA.DataPropertyName = "FACTURA";
            this.FACTURA.HeaderText = "FACTURA";
            this.FACTURA.Name = "FACTURA";
            this.FACTURA.Width = 87;
            // 
            // TOTAL
            // 
            this.TOTAL.DataPropertyName = "TOTA_RECIBIDO";
            this.TOTAL.HeaderText = "TOTAL RECIBIDO";
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.Width = 119;
            // 
            // CONTROLADO
            // 
            this.CONTROLADO.DataPropertyName = "CONTROLADO";
            this.CONTROLADO.FalseValue = "N";
            this.CONTROLADO.HeaderText = "CONTROLADO";
            this.CONTROLADO.IndeterminateValue = "N";
            this.CONTROLADO.Name = "CONTROLADO";
            this.CONTROLADO.TrueValue = "S";
            // 
            // OBSERVACION
            // 
            this.OBSERVACION.DataPropertyName = "OBSERVACION";
            this.OBSERVACION.HeaderText = "OBSERVACION";
            this.OBSERVACION.Name = "OBSERVACION";
            this.OBSERVACION.Width = 119;
            // 
            // USUARIOid
            // 
            this.USUARIOid.DataPropertyName = "USUARIO_ID";
            this.USUARIOid.HeaderText = "USUARIOID";
            this.USUARIOid.Name = "USUARIOid";
            this.USUARIOid.Visible = false;
            this.USUARIOid.Width = 99;
            // 
            // SUCURSAL_ID
            // 
            // 
            // 
            // 
            this.SUCURSAL_ID.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.SUCURSAL_ID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SUCURSAL_ID.DataPropertyName = "SUCURSAL_ID";
            this.SUCURSAL_ID.HeaderText = "SUCURSAL_ID";
            this.SUCURSAL_ID.Name = "SUCURSAL_ID";
            this.SUCURSAL_ID.Visible = false;
            this.SUCURSAL_ID.Width = 112;
            // 
            // ACTIVO
            // 
            this.ACTIVO.DataPropertyName = "ACTIVO";
            this.ACTIVO.DropDownHeight = 106;
            this.ACTIVO.DropDownWidth = 121;
            this.ACTIVO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ACTIVO.HeaderText = "ACTIVO";
            this.ACTIVO.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ACTIVO.IntegralHeight = false;
            this.ACTIVO.ItemHeight = 15;
            this.ACTIVO.Name = "ACTIVO";
            this.ACTIVO.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ACTIVO.Width = 77;
            // 
            // buscarBackgroundWorker
            // 
            this.buscarBackgroundWorker.WorkerReportsProgress = true;
            this.buscarBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.buscarBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.Controls.Add(labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarTextBoxX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarButtonX, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 32);
            this.tableLayoutPanel1.TabIndex = 2;
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
            // buttonItem3
            // 
            this.buttonItem3.HoverImage = global::SIF.Properties.Resources.BoxNewTool1;
            this.buttonItem3.Image = global::SIF.Properties.Resources.IMPRIMIR;
            this.buttonItem3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Tag = "3";
            this.buttonItem3.Text = "Imprimir\r\n ";
            this.buttonItem3.Click += new System.EventHandler(this.buttonItem3_Click);
            // 
            // RecepcionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "RecepcionUserControl";
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem NuevoButtonItem;
        private DevComponents.DotNetBar.ButtonItem eliminarButtonItem;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.ComponentModel.BackgroundWorker buscarBackgroundWorker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn Folio;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn FOLIOID;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn PROVEEDORID;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn PROVEEDOR;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTADO_OC;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn FECHAR;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn FECHAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn FACTURA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CONTROLADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn USUARIOid;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn SUCURSAL_ID;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn ACTIVO;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
    }
}
