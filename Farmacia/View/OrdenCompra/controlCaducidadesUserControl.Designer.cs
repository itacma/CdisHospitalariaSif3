namespace SIF.View.OrdenCompra
    {
    partial class controlCaducidadesUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlCaducidadesUserControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.CerrarbuttonItem = new DevComponents.DotNetBar.ButtonItem();
            this.RestaurarbuttonItem = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ARTICULOIDComlumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.NOMBRE1Column = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.CANTIDADColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOTEColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CADUCIDADColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ARTICULO_IDCAPColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.NOMBRE_CAPColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.CANTIDAD_CAPColumn = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.BuscartextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.BuscarlabelX = new DevComponents.DotNetBar.LabelX();
            this.MensajelabelX = new DevComponents.DotNetBar.LabelX();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Foliolabel = new System.Windows.Forms.Label();
            this.folioCompralabelDto = new System.Windows.Forms.Label();
            this.importarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.importarButtonItemCDIS = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
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
            // bar1
            // 
            this.bar1.AccessibleDescription = "bar1 (bar1)";
            this.bar1.AccessibleName = "bar1";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar1.AntiAlias = true;
            this.bar1.BackColor = System.Drawing.Color.Transparent;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem7,
            this.RestaurarbuttonItem,
            this.CerrarbuttonItem,
            this.importarButtonItem});
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
            this.titleLabel.Size = new System.Drawing.Size(313, 32);
            this.titleLabel.Text = "SIF\\CONTROL CADUCIDADES";
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
            this.splitContainer1.SplitterDistance = 96;
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
            // buttonItem7
            // 
            this.buttonItem7.HoverImage = global::SIF.Properties.Resources.SaveTool1;
            this.buttonItem7.Image = global::SIF.Properties.Resources.SaveTool;
            this.buttonItem7.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.Tag = "3";
            this.buttonItem7.Text = "Salvar\r\n ";
            this.buttonItem7.Click += new System.EventHandler(this.buttonItem7_Click);

            // CerrarbuttonItem
            // 
            this.CerrarbuttonItem.HoverImage = global::SIF.Properties.Resources.LockInformation1;
            this.CerrarbuttonItem.Image = global::SIF.Properties.Resources.LockInformation;
            this.CerrarbuttonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.CerrarbuttonItem.Name = "CerrarbuttonItem";
            this.CerrarbuttonItem.Tag = "3";
            this.CerrarbuttonItem.Text = "Cerrar\r\n ";
            this.CerrarbuttonItem.Click += new System.EventHandler(this.CerrarbuttonItem_Click);
            // 
            // importarButtonItem
            // 
            this.importarButtonItem.HoverImage = global::SIF.Properties.Resources.Upload21;
            this.importarButtonItem.Image = global::SIF.Properties.Resources.Upload1;
            this.importarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.importarButtonItem.Name = "importarButtonItem";
            this.importarButtonItem.Tag = "33";
            this.importarButtonItem.Text = "Importar HUP\r\n ";
            this.importarButtonItem.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.importarButtonItemCDIS
            });
            this.importarButtonItem.Click += new System.EventHandler(this.importarButtonItem_Click);
            // 
            // importarButtonItemCDIS
            // 
            this.importarButtonItemCDIS.HoverImage = global::SIF.Properties.Resources.Upload21;
            this.importarButtonItemCDIS.Image = global::SIF.Properties.Resources.Upload1;
            this.importarButtonItemCDIS.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.importarButtonItemCDIS.Name = "importarButtonItemCDIS";
            this.importarButtonItemCDIS.Tag = "33";
            this.importarButtonItemCDIS.Text = "Importar CDIS \r\n ";
          
            this.importarButtonItemCDIS.Click += new System.EventHandler(this.importarButtonItemCDIS_Click);


            // 
            // RestaurarbuttonItem
            // 
            this.RestaurarbuttonItem.HoverImage = global::SIF.Properties.Resources.U_turn1;
            this.RestaurarbuttonItem.Image = global::SIF.Properties.Resources.U_turn;
            this.RestaurarbuttonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.RestaurarbuttonItem.Name = "RestaurarbuttonItem";
            this.RestaurarbuttonItem.Tag = "3";
            this.RestaurarbuttonItem.Text = "Restablecer\r\n ";
            this.RestaurarbuttonItem.Click += new System.EventHandler(this.RestaurarbuttonItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.77411F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.201625F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.02427F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewX2, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(909, 462);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ARTICULOIDComlumn,
            this.NOMBRE1Column,
            this.CANTIDADColumn,
            this.LOTEColumn,
            this.CADUCIDADColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewX1, 3);
            this.dataGridViewX1.Size = new System.Drawing.Size(537, 456);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            this.dataGridViewX1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewX1_DataBindingComplete);
            // 
            // ARTICULOIDComlumn
            // 
            this.ARTICULOIDComlumn.DataPropertyName = "ARTICULO_ID";
            this.ARTICULOIDComlumn.HeaderText = "ARTICULOID";
            this.ARTICULOIDComlumn.Name = "ARTICULOIDComlumn";
            this.ARTICULOIDComlumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ARTICULOIDComlumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // NOMBRE1Column
            // 
            this.NOMBRE1Column.DataPropertyName = "nombre";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            this.NOMBRE1Column.DefaultCellStyle = dataGridViewCellStyle1;
            this.NOMBRE1Column.HeaderText = "NOMBRE";
            this.NOMBRE1Column.Name = "NOMBRE1Column";
            this.NOMBRE1Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NOMBRE1Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CANTIDADColumn
            // 
            this.CANTIDADColumn.DataPropertyName = "cantidad";
            this.CANTIDADColumn.HeaderText = "CANTIDAD";
            this.CANTIDADColumn.Name = "CANTIDADColumn";
            this.CANTIDADColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // LOTEColumn
            // 
            this.LOTEColumn.DataPropertyName = "no_lote";
            this.LOTEColumn.HeaderText = "LOTE";
            this.LOTEColumn.MaxInputLength = 20;
            this.LOTEColumn.Name = "LOTEColumn";
            this.LOTEColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // CADUCIDADColumn
            // 
            this.CADUCIDADColumn.DataPropertyName = "caducidad";
            this.CADUCIDADColumn.HeaderText = "CADUCIDAD";
            this.CADUCIDADColumn.MaxInputLength = 4;
            this.CADUCIDADColumn.Name = "CADUCIDADColumn";
            this.CADUCIDADColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewX2
            // 
            this.dataGridViewX2.AllowUserToAddRows = false;
            this.dataGridViewX2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ARTICULO_IDCAPColumn,
            this.NOMBRE_CAPColumn,
            this.CANTIDAD_CAPColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX2.Location = new System.Drawing.Point(566, 3);
            this.dataGridViewX2.Name = "dataGridViewX2";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewX2, 3);
            this.dataGridViewX2.Size = new System.Drawing.Size(340, 456);
            this.dataGridViewX2.TabIndex = 1;
            // 
            // ARTICULO_IDCAPColumn
            // 
            this.ARTICULO_IDCAPColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ARTICULO_IDCAPColumn.DataPropertyName = "ARTICULO_ID";
            this.ARTICULO_IDCAPColumn.HeaderText = "ARTICULO_ID";
            this.ARTICULO_IDCAPColumn.Name = "ARTICULO_IDCAPColumn";
            this.ARTICULO_IDCAPColumn.ReadOnly = true;
            this.ARTICULO_IDCAPColumn.Width = 89;
            // 
            // NOMBRE_CAPColumn
            // 
            this.NOMBRE_CAPColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NOMBRE_CAPColumn.DataPropertyName = "NOMBRE";
            this.NOMBRE_CAPColumn.HeaderText = "NOMBRE";
            this.NOMBRE_CAPColumn.Name = "NOMBRE_CAPColumn";
            this.NOMBRE_CAPColumn.ReadOnly = true;
            this.NOMBRE_CAPColumn.Width = 68;
            // 
            // CANTIDAD_CAPColumn
            // 
            // 
            // 
            // 
            this.CANTIDAD_CAPColumn.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.CANTIDAD_CAPColumn.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.CANTIDAD_CAPColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CANTIDAD_CAPColumn.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.CANTIDAD_CAPColumn.DataPropertyName = "CANTIDAD";
            this.CANTIDAD_CAPColumn.HeaderText = "CANTIDAD";
            this.CANTIDAD_CAPColumn.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.CANTIDAD_CAPColumn.Name = "CANTIDAD_CAPColumn";
            this.CANTIDAD_CAPColumn.ReadOnly = true;
            // 
            // BuscartextBoxX
            // 
            // 
            // 
            // 
            this.BuscartextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.BuscartextBoxX.Location = new System.Drawing.Point(0, 0);
            this.BuscartextBoxX.Name = "BuscartextBoxX";
            this.BuscartextBoxX.Size = new System.Drawing.Size(100, 20);
            this.BuscartextBoxX.TabIndex = 0;
            this.BuscartextBoxX.WatermarkText = "Buscar...";
            // 
            // BuscarlabelX
            // 
            // 
            // 
            // 
            this.BuscarlabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.BuscarlabelX.Location = new System.Drawing.Point(0, 0);
            this.BuscarlabelX.Name = "BuscarlabelX";
            this.BuscarlabelX.TabIndex = 0;
            this.BuscarlabelX.Text = "Buscar.";
            // 
            // MensajelabelX
            // 
            // 
            // 
            // 
            this.MensajelabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MensajelabelX.Location = new System.Drawing.Point(0, 0);
            this.MensajelabelX.Name = "MensajelabelX";
            this.MensajelabelX.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.Foliolabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.folioCompralabelDto, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(903, 90);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // Foliolabel
            // 
            this.Foliolabel.AutoSize = true;
            this.Foliolabel.Location = new System.Drawing.Point(3, 22);
            this.Foliolabel.Name = "Foliolabel";
            this.Foliolabel.Size = new System.Drawing.Size(90, 17);
            this.Foliolabel.TabIndex = 2;
            this.Foliolabel.Text = "Folio Compra:";
            // 
            // folioCompralabelDto
            // 
            this.folioCompralabelDto.AutoSize = true;
            this.folioCompralabelDto.Location = new System.Drawing.Point(183, 22);
            this.folioCompralabelDto.Name = "folioCompralabelDto";
            this.folioCompralabelDto.Size = new System.Drawing.Size(89, 17);
            this.folioCompralabelDto.TabIndex = 3;
            this.folioCompralabelDto.Text = "[Foliocompra]";
            // 
            // controlCaducidadesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "controlCaducidadesUserControl";
            this.Load += new System.EventHandler(this.controlCaducidadesUserControl_Load);
            this.Controls.SetChildIndex(this.nombreLabel, 0);
            this.Controls.SetChildIndex(this.apellidosLabel, 0);
            this.Controls.SetChildIndex(this.fotoPictureBox, 0);
            this.Controls.SetChildIndex(this.sucursalLabel, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.statusLabel, 0);
            this.Controls.SetChildIndex(this.titleLabel, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.Controls.SetChildIndex(this.bar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }





        #endregion
        private DevComponents.DotNetBar.ButtonItem buttonItem7;
        private DevComponents.DotNetBar.ButtonItem CerrarbuttonItem;
        private DevComponents.DotNetBar.ButtonItem RestaurarbuttonItem;        
        private System.Windows.Forms.BindingSource bindingSource;        
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ARTICULOIDComlumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn NOMBRE1Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDADColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOTEColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CADUCIDADColumn;        
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ARTICULO_IDCAPColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn NOMBRE_CAPColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn CANTIDAD_CAPColumn;        
        private DevComponents.DotNetBar.Controls.TextBoxX BuscartextBoxX;
        private DevComponents.DotNetBar.LabelX BuscarlabelX;
        private DevComponents.DotNetBar.LabelX MensajelabelX;        
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label Foliolabel;
        private System.Windows.Forms.Label folioCompralabelDto;
        private DevComponents.DotNetBar.ButtonItem importarButtonItem;
        private DevComponents.DotNetBar.ButtonItem importarButtonItemCDIS;

    }
}
