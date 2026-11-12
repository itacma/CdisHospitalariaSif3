namespace SIF.View.Catalogos
{
    partial class SucursalesUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SucursalesUserControl));
            DevComponents.DotNetBar.LabelX labelX1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NuevoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.eliminarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.usuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buscarBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.ColumnNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESPONSABLEColumn = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.TELEFONOColumn = new DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn();
            this.SUCURSAL_IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USUARIOColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLAVEColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CALLEColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NO_EXTColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUM_INTERIORColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIUDADColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MUNICIPIOColumn = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.COLONIAColumn = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.CPColumn = new DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn();
            this.NADRO_IDColumn = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.PFIZER_IDColumn = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).BeginInit();
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
            this.eliminarButtonItem});
            this.bar1.ItemSpacing = 10;
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(156, 32);
            this.titleLabel.Text = "SIF\\Sucursales";
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
            this.splitContainer1.SplitterDistance = 34;
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
            labelX1.Location = new System.Drawing.Point(3, 7);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(43, 20);
            labelX1.TabIndex = 1;
            labelX1.Text = "Buscar:";
            // 
            // NuevoButtonItem
            // 
            this.NuevoButtonItem.HoverImage = global::SIF.Properties.Resources.NewDocument1;
            this.NuevoButtonItem.Image = global::SIF.Properties.Resources.NewDocument;
            this.NuevoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.NuevoButtonItem.Name = "NuevoButtonItem";
            this.NuevoButtonItem.Tag = "1";
            this.NuevoButtonItem.Text = "Nuevo\r\n[F2]";
            this.NuevoButtonItem.Click += new System.EventHandler(this.NuevoButtonItem_Click);
            // 
            // eliminarButtonItem
            // 
            this.eliminarButtonItem.Enabled = false;
            this.eliminarButtonItem.HoverImage = global::SIF.Properties.Resources.DeleteDocument1;
            this.eliminarButtonItem.Image = global::SIF.Properties.Resources.DeleteDocument;
            this.eliminarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.eliminarButtonItem.Name = "eliminarButtonItem";
            this.eliminarButtonItem.Tag = "6";
            this.eliminarButtonItem.Text = "Eliminar\r\n[F6]";
            this.eliminarButtonItem.Visible = false;
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
            this.buscarTextBoxX.Location = new System.Drawing.Point(51, 4);
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
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNombre,
            this.RESPONSABLEColumn,
            this.TELEFONOColumn,
            this.SUCURSAL_IDColumn,
            this.USUARIOColumn,
            this.CLAVEColumn,
            this.CALLEColumn,
            this.NO_EXTColumn,
            this.NUM_INTERIORColumn,
            this.CIUDADColumn,
            this.MUNICIPIOColumn,
            this.COLONIAColumn,
            this.CPColumn,
            this.NADRO_IDColumn,
            this.PFIZER_IDColumn});
            this.dataGridViewX1.DataSource = this.bindingSource;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(915, 530);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewX1_CellBeginEdit);
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            this.dataGridViewX1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewX1_CellValidating);
            this.dataGridViewX1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_ColumnHeaderMouseClick);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            this.dataGridViewX1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyUp);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 34);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // buscarButtonX
            // 
            this.buscarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buscarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buscarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buscarButtonX.Location = new System.Drawing.Point(837, 5);
            this.buscarButtonX.Name = "buscarButtonX";
            this.buscarButtonX.Size = new System.Drawing.Size(75, 23);
            this.buscarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buscarButtonX.TabIndex = 0;
            this.buscarButtonX.Text = "Buscar";
            this.buscarButtonX.Click += new System.EventHandler(this.buscarButtonX_Click);
            // 
            // ColumnNombre
            // 
            this.ColumnNombre.DataPropertyName = "Nombre";
            this.ColumnNombre.HeaderText = "NOMBRE";
            this.ColumnNombre.MaxInputLength = 100;
            this.ColumnNombre.Name = "ColumnNombre";
            this.ColumnNombre.Width = 150;
            // 
            // RESPONSABLEColumn
            // 
            this.RESPONSABLEColumn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.RESPONSABLEColumn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.RESPONSABLEColumn.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.RESPONSABLEColumn.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.RESPONSABLEColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RESPONSABLEColumn.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.RESPONSABLEColumn.DataPropertyName = "ResponsableNombre";
            this.RESPONSABLEColumn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RESPONSABLEColumn.HeaderText = "RESPONSABLE";
            this.RESPONSABLEColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RESPONSABLEColumn.Name = "RESPONSABLEColumn";
            this.RESPONSABLEColumn.PasswordChar = '\0';
            this.RESPONSABLEColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RESPONSABLEColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RESPONSABLEColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RESPONSABLEColumn.Text = "";
            // 
            // TELEFONOColumn
            // 
            this.TELEFONOColumn.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.TELEFONOColumn.BackgroundStyle.Class = "DataGridViewBorder";
            this.TELEFONOColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TELEFONOColumn.Culture = new System.Globalization.CultureInfo("es-MX");
            this.TELEFONOColumn.DataPropertyName = "Telefono";
            this.TELEFONOColumn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TELEFONOColumn.HeaderText = "TELEFONO";
            this.TELEFONOColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TELEFONOColumn.Mask = "(###) ### ### ####";
            this.TELEFONOColumn.Name = "TELEFONOColumn";
            this.TELEFONOColumn.PasswordChar = '\0';
            this.TELEFONOColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TELEFONOColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TELEFONOColumn.Text = "(   )         ";
            // 
            // SUCURSAL_IDColumn
            // 
            this.SUCURSAL_IDColumn.DataPropertyName = "SucursalID";
            this.SUCURSAL_IDColumn.HeaderText = "SUCURSAL";
            this.SUCURSAL_IDColumn.MaxInputLength = 100;
            this.SUCURSAL_IDColumn.Name = "SUCURSAL_IDColumn";
            this.SUCURSAL_IDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SUCURSAL_IDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // USUARIOColumn
            // 
            this.USUARIOColumn.DataPropertyName = "SucursalUsuario";
            this.USUARIOColumn.HeaderText = "USUARIO";
            this.USUARIOColumn.MaxInputLength = 100;
            this.USUARIOColumn.Name = "USUARIOColumn";
            this.USUARIOColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.USUARIOColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CLAVEColumn
            // 
            this.CLAVEColumn.DataPropertyName = "SucursalClave";
            dataGridViewCellStyle1.Format = "•";
            dataGridViewCellStyle1.NullValue = null;
            this.CLAVEColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.CLAVEColumn.HeaderText = "CLAVE";
            this.CLAVEColumn.MaxInputLength = 100;
            this.CLAVEColumn.Name = "CLAVEColumn";
            // 
            // CALLEColumn
            // 
            this.CALLEColumn.DataPropertyName = "Calle";
            this.CALLEColumn.HeaderText = "CALLE";
            this.CALLEColumn.MaxInputLength = 100;
            this.CALLEColumn.Name = "CALLEColumn";
            this.CALLEColumn.Width = 200;
            // 
            // NO_EXTColumn
            // 
            this.NO_EXTColumn.DataPropertyName = "NumeroExterior";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.NO_EXTColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.NO_EXTColumn.HeaderText = "NO. EXTERIOR";
            this.NO_EXTColumn.MaxInputLength = 10;
            this.NO_EXTColumn.Name = "NO_EXTColumn";
            this.NO_EXTColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // NUM_INTERIORColumn
            // 
            this.NUM_INTERIORColumn.DataPropertyName = "NumeroInterior";
            dataGridViewCellStyle3.Format = "N0";
            this.NUM_INTERIORColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.NUM_INTERIORColumn.HeaderText = "NO. INTERIOR";
            this.NUM_INTERIORColumn.MaxInputLength = 10;
            this.NUM_INTERIORColumn.Name = "NUM_INTERIORColumn";
            this.NUM_INTERIORColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // CIUDADColumn
            // 
            this.CIUDADColumn.DataPropertyName = "Ciudad";
            this.CIUDADColumn.HeaderText = "CIUDAD";
            this.CIUDADColumn.Name = "CIUDADColumn";
            this.CIUDADColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // MUNICIPIOColumn
            // 
            this.MUNICIPIOColumn.DataPropertyName = "Municipio";
            dataGridViewCellStyle4.Format = "N0";
            this.MUNICIPIOColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.MUNICIPIOColumn.DropDownHeight = 106;
            this.MUNICIPIOColumn.DropDownWidth = 121;
            this.MUNICIPIOColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MUNICIPIOColumn.HeaderText = "MUNICIPIO";
            this.MUNICIPIOColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MUNICIPIOColumn.IntegralHeight = false;
            this.MUNICIPIOColumn.ItemHeight = 15;
            this.MUNICIPIOColumn.Name = "MUNICIPIOColumn";
            this.MUNICIPIOColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MUNICIPIOColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // COLONIAColumn
            // 
            this.COLONIAColumn.DataPropertyName = "Colonia";
            this.COLONIAColumn.DropDownHeight = 106;
            this.COLONIAColumn.DropDownWidth = 121;
            this.COLONIAColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.COLONIAColumn.HeaderText = "COLONIA";
            this.COLONIAColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.COLONIAColumn.IntegralHeight = false;
            this.COLONIAColumn.ItemHeight = 15;
            this.COLONIAColumn.Name = "COLONIAColumn";
            this.COLONIAColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COLONIAColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // CPColumn
            // 
            this.CPColumn.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.CPColumn.BackgroundStyle.Class = "DataGridViewBorder";
            this.CPColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CPColumn.Culture = new System.Globalization.CultureInfo("es-MX");
            this.CPColumn.DataPropertyName = "CodigoPostal";
            this.CPColumn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CPColumn.HeaderText = "C.P.";
            this.CPColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CPColumn.Mask = "#####";
            this.CPColumn.Name = "CPColumn";
            this.CPColumn.PasswordChar = '\0';
            this.CPColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CPColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CPColumn.Text = "";
            this.CPColumn.Width = 85;
            // 
            // NADRO_IDColumn
            // 
            // 
            // 
            // 
            this.NADRO_IDColumn.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.NADRO_IDColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NADRO_IDColumn.DataPropertyName = "NadroID";
            dataGridViewCellStyle5.NullValue = "N0";
            this.NADRO_IDColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.NADRO_IDColumn.DisplayFormat = "####";
            this.NADRO_IDColumn.HeaderText = "NADRO";
            this.NADRO_IDColumn.Increment = 1D;
            this.NADRO_IDColumn.MaxValue = 9999D;
            this.NADRO_IDColumn.MinValue = 0D;
            this.NADRO_IDColumn.Name = "NADRO_IDColumn";
            this.NADRO_IDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // PFIZER_IDColumn
            // 
            // 
            // 
            // 
            this.PFIZER_IDColumn.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.PFIZER_IDColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PFIZER_IDColumn.DataPropertyName = "PfizerID";
            dataGridViewCellStyle6.Format = "N0";
            this.PFIZER_IDColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.PFIZER_IDColumn.DisplayFormat = "####";
            this.PFIZER_IDColumn.HeaderText = "PFIZER";
            this.PFIZER_IDColumn.Increment = 1D;
            this.PFIZER_IDColumn.MaxValue = 9999D;
            this.PFIZER_IDColumn.MinValue = 0D;
            this.PFIZER_IDColumn.Name = "PFIZER_IDColumn";
            // 
            // SucursalesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "SucursalesUserControl";
            this.Load += new System.EventHandler(this.CatSucursalsUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource usuarioBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNombre;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn RESPONSABLEColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn TELEFONOColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUCURSAL_IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn USUARIOColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLAVEColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CALLEColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO_EXTColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUM_INTERIORColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIUDADColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn MUNICIPIOColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn COLONIAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn CPColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn NADRO_IDColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn PFIZER_IDColumn;
    }
}
