namespace SIF.View.Catalogos
{
    partial class InventarioFisicoUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventarioFisicoUserControl));
            DevComponents.DotNetBar.LabelX labelX1;
            DevComponents.DotNetBar.LabelX labelX4;
            DevComponents.DotNetBar.LabelX labelX2;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtTbf = new System.Windows.Forms.TextBox();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.laboratorioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoMedicamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoMonedaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.unidadCompraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.unidadVentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SiNoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buscarBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.proveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Fila = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.AnaquelColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.NIVELColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.NOMBREColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.NOMBRE2Column = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column2 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.FISICO1Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIF1Column = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.periodoComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.filaComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.anaquelComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.reporte1buttonItem = new DevComponents.DotNetBar.ButtonItem();
            this.reporte2buttonItem = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem8 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem9 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.switch_Captura = new DevComponents.DotNetBar.Controls.SwitchButton();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            labelX4 = new DevComponents.DotNetBar.LabelX();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laboratorioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMedicamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMonedaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadCompraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadVentaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiNoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).BeginInit();
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
            this.buttonItem1,
            this.buttonItem9,
            this.buttonItem7,
            this.buttonItem8,
            this.buttonItem2
            });
            this.bar1.ItemSpacing = 10;
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(353, 32);
            this.titleLabel.Text = "INVENTARIO\\INVENTARIO FISICO";
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
            // txtTbf
            // 
            this.txtTbf.Location = new System.Drawing.Point(641, 3);
            this.txtTbf.Name = "txtTbf";
            this.txtTbf.Size = new System.Drawing.Size(85, 25);
            this.txtTbf.TabIndex = 6;
            this.txtTbf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTbf_KeyDown);
            // 
            // labelX1
            // 
            labelX1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelX1.AutoSize = true;
            // 
            // 
            // 
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.Location = new System.Drawing.Point(234, 7);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(25, 20);
            labelX1.TabIndex = 1;
            labelX1.Text = "Fila:";
            // 
            // labelX4
            // 
            labelX4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelX4.AutoSize = true;
            // 
            // 
            // 
            labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX4.Location = new System.Drawing.Point(4, 7);
            labelX4.Name = "labelX4";
            labelX4.Size = new System.Drawing.Size(50, 20);
            labelX4.TabIndex = 3;
            labelX4.Text = "Periodo:";
            // 
            // labelX2
            // 
            labelX2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelX2.AutoSize = true;
            // 
            // 
            // 
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.Location = new System.Drawing.Point(413, 7);
            labelX2.Name = "labelX2";
            labelX2.Size = new System.Drawing.Size(53, 20);
            labelX2.TabIndex = 1;
            labelX2.Text = "Anaquel:";
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
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
            this.dataGridViewX1.AllowUserToOrderColumns = true;
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
            this.Column1,
            this.Fila,
            this.AnaquelColumn,
            this.NIVELColumn,
            this.NOMBREColumn,
            this.NOMBRE2Column,
            this.Column2,
            this.FISICO1Column,
            this.DIF1Column,
            this.Column4});
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
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(915, 530);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            this.dataGridViewX1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewX1_CellValidating);
            this.dataGridViewX1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_ColumnHeaderMouseClick);
            this.dataGridViewX1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewX1_DataBindingComplete);
            this.dataGridViewX1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewX1_DataError);
            this.dataGridViewX1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_RowEnter);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            this.dataGridViewX1.DoubleClick += new System.EventHandler(this.dataGridViewX1_DoubleClick);
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ARTICULO_ID";
            this.Column1.HeaderText = "ARTICULO_ID";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 130;
            // 
            // Fila
            // 
            this.Fila.DataPropertyName = "FILA";
            this.Fila.HeaderText = "FILA";
            this.Fila.Name = "Fila";
            this.Fila.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Fila.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // AnaquelColumn
            // 
            this.AnaquelColumn.DataPropertyName = "ANAQUEL";
            this.AnaquelColumn.HeaderText = "ANAQUEL";
            this.AnaquelColumn.Name = "AnaquelColumn";
            this.AnaquelColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AnaquelColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // NIVELColumn
            // 
            this.NIVELColumn.DataPropertyName = "Nivel";
            this.NIVELColumn.HeaderText = "NIVEL";
            this.NIVELColumn.Name = "NIVELColumn";
            // 
            // NOMBREColumn
            // 
            this.NOMBREColumn.DataPropertyName = "DESCRIPCION";
            this.NOMBREColumn.HeaderText = "NOMBRE1";
            this.NOMBREColumn.Name = "NOMBREColumn";
            this.NOMBREColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NOMBREColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.NOMBREColumn.Width = 200;
            // 
            // NOMBRE2Column
            // 
            this.NOMBRE2Column.DataPropertyName = "NOMBRE2";
            this.NOMBRE2Column.HeaderText = "NOMBRE2";
            this.NOMBRE2Column.Name = "NOMBRE2Column";
            this.NOMBRE2Column.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "EXISTENCIA";
            this.Column2.HeaderText = "EXISTENCIAS";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FISICO1Column
            // 
            this.FISICO1Column.DataPropertyName = "CONTEO1";
            this.FISICO1Column.HeaderText = "CONTEO1";
            this.FISICO1Column.Name = "FISICO1Column";
            this.FISICO1Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DIF1Column
            // 
            this.DIF1Column.DataPropertyName = "DIF1";
            this.DIF1Column.HeaderText = "DIF1";
            this.DIF1Column.Name = "DIF1Column";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "COSTO_PROM";
            this.Column4.HeaderText = "COSTO PROMEDIO";
            this.Column4.Name = "Column4";
            this.Column4.Width = 130;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.periodoComboBoxEx, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.filaComboBoxEx, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.anaquelComboBoxEx, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX2, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX3, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.switch_Captura, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarButtonX, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTbf, 8, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 34);
            this.tableLayoutPanel1.TabIndex = 2;

            // 
            // periodoComboBoxEx
            // 
            this.periodoComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.periodoComboBoxEx.DisplayMember = "Text";
            this.periodoComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.periodoComboBoxEx.FormattingEnabled = true;
            this.periodoComboBoxEx.ItemHeight = 19;
            this.periodoComboBoxEx.Location = new System.Drawing.Point(60, 3);
            this.periodoComboBoxEx.Name = "periodoComboBoxEx";
            this.periodoComboBoxEx.Size = new System.Drawing.Size(137, 25);
            this.periodoComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.periodoComboBoxEx.TabIndex = 4;
            this.periodoComboBoxEx.SelectedIndexChanged += new System.EventHandler(this.periodoComboBoxEx_SelectedIndexChanged);
            // 
            // filaComboBoxEx
            // 
            this.filaComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filaComboBoxEx.DisplayMember = "Text";
            this.filaComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.filaComboBoxEx.FormattingEnabled = true;
            this.filaComboBoxEx.ItemHeight = 19;
            this.filaComboBoxEx.Location = new System.Drawing.Point(265, 3);
            this.filaComboBoxEx.Name = "filaComboBoxEx";
            this.filaComboBoxEx.Size = new System.Drawing.Size(132, 25);
            this.filaComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.filaComboBoxEx.TabIndex = 4;
            this.filaComboBoxEx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.filaComboBoxEx_KeyUp);
            // 
            // anaquelComboBoxEx
            // 
            this.anaquelComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.anaquelComboBoxEx.DisplayMember = "Text";
            this.anaquelComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.anaquelComboBoxEx.FormattingEnabled = true;
            this.anaquelComboBoxEx.ItemHeight = 19;
            this.anaquelComboBoxEx.Location = new System.Drawing.Point(472, 3);
            this.anaquelComboBoxEx.Name = "anaquelComboBoxEx";
            this.anaquelComboBoxEx.Size = new System.Drawing.Size(125, 25);
            this.anaquelComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.anaquelComboBoxEx.TabIndex = 4;
            this.anaquelComboBoxEx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anaquelComboBoxEx_KeyUp);
            // 
            // buscarButtonX
            // 
            this.buscarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buscarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buscarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buscarButtonX.Location = new System.Drawing.Point(834, 5);
            this.buscarButtonX.Margin = new System.Windows.Forms.Padding(0);
            this.buscarButtonX.Name = "buscarButtonX";
            this.buscarButtonX.Size = new System.Drawing.Size(81, 23);
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
            // 
            // buttonItem1
            // 
            this.buttonItem1.HoverImage = global::SIF.Properties.Resources.BoxNewTool1;
            this.buttonItem1.Image = global::SIF.Properties.Resources.IMPRIMIR;
            this.buttonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.reporte1buttonItem,
            this.reporte2buttonItem});
            this.buttonItem1.Tag = "3";
            this.buttonItem1.Text = "Imprimir\r\n ";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // reporte1buttonItem
            // 
            this.reporte1buttonItem.Name = "reporte1buttonItem";
            this.reporte1buttonItem.Text = "Resultado";
            this.reporte1buttonItem.Click += new System.EventHandler(this.reporte1buttonItem_Click);
            // 
            // reporte2buttonItem
            // 
            this.reporte2buttonItem.Name = "reporte2buttonItem";
            this.reporte2buttonItem.Text = "Toma";
            this.reporte2buttonItem.Click += new System.EventHandler(this.reporte2buttonItem_Click);
            // 
            // buttonItem7
            // 
            this.buttonItem7.HoverImage = global::SIF.Properties.Resources.SaveTool1;
            this.buttonItem7.Image = global::SIF.Properties.Resources.SaveTool;
            this.buttonItem7.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.Tag = "3";
            this.buttonItem7.Text = "Salvar\r\n ";
            this.buttonItem7.Click += new System.EventHandler(this.buttonItem7_Click);

         
            

            // 
            // switch_Captura
            // 
            this.switch_Captura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.switch_Captura.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.switch_Captura.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switch_Captura.ForeColor = System.Drawing.Color.Black;
            this.switch_Captura.Location = new System.Drawing.Point(550, 3);
            this.switch_Captura.Name = "switch_TipoAjuste";
            this.switch_Captura.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.switch_Captura.OffText = "COMPLETO";
            this.switch_Captura.OffTextColor = System.Drawing.Color.White;
            this.switch_Captura.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.switch_Captura.OnText = "DIFERENCIAS";
            this.switch_Captura.OnTextColor = System.Drawing.Color.White;
            this.switch_Captura.Size = new System.Drawing.Size(85, 28);
            this.switch_Captura.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switch_Captura.TabIndex = 5;
            this.switch_Captura.ValueChanged += new System.EventHandler(this.switch_Captura_ValueChanged_1);

            // 
            // buttonItem8
            // 
            this.buttonItem8.HoverImage = global::SIF.Properties.Resources.NewDocument1;
            this.buttonItem8.Image = global::SIF.Properties.Resources.NewDocument;
            this.buttonItem8.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem8.Name = "buttonItem8";
            this.buttonItem8.Tag = "3";
            this.buttonItem8.Text = "Crear Ajuste\r\n ";
            this.buttonItem8.Click += new System.EventHandler(this.buttonItem8_Click);
            // 
            // buttonItem9
            // 
            this.buttonItem9.HoverImage = global::SIF.Properties.Resources.EditDocument;
            this.buttonItem9.Image = global::SIF.Properties.Resources.EditDocument1;
            this.buttonItem9.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem9.Name = "buttonItem9";
            this.buttonItem9.Tag = "3";
            this.buttonItem9.Text = "Crear Periodo\r\n ";
            this.buttonItem9.Click += new System.EventHandler(this.buttonItem9_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.HoverImage = global::SIF.Properties.Resources.TableContentsTool1;
            this.buttonItem2.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.buttonItem2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Tag = "3";
            this.buttonItem2.Text = "Agrega Artículo\r\n ";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click_1);
            // 
            // InventarioFisicoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "InventarioFisicoUserControl";
            this.Load += new System.EventHandler(this.CatArticulosUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laboratorioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMedicamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMonedaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadCompraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadVentaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiNoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.BindingSource SiNoBindingSource;
        private System.ComponentModel.BackgroundWorker buscarBackgroundWorker;
        private System.Windows.Forms.BindingSource laboratorioBindingSource;
        private System.Windows.Forms.BindingSource proveedorBindingSource;
        private System.Windows.Forms.BindingSource tipoMedicamentoBindingSource;
        private System.Windows.Forms.BindingSource tipoMonedaBindingSource;
        private System.Windows.Forms.BindingSource unidadCompraBindingSource;
        private System.Windows.Forms.BindingSource unidadVentaBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx periodoComboBoxEx;
        private DevComponents.DotNetBar.Controls.ComboBoxEx filaComboBoxEx;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
        private DevComponents.DotNetBar.Controls.ComboBoxEx anaquelComboBoxEx;
        private DevComponents.DotNetBar.ButtonItem buttonItem7;
        

        private DevComponents.DotNetBar.ButtonItem buttonItem8;
        private DevComponents.DotNetBar.ButtonItem buttonItem9;
        private DevComponents.DotNetBar.ButtonItem reporte1buttonItem;
        private DevComponents.DotNetBar.ButtonItem reporte2buttonItem;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column1;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Fila;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn AnaquelColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn NIVELColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn NOMBREColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn NOMBRE2Column;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FISICO1Column;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn DIF1Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.SwitchButton switch_Captura;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.TextBox txtTbf;
        
            
    }
}
