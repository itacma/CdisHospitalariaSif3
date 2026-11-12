namespace SIF.View.Articulos
{
    partial class OfertasMayoristaUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfertasMayoristaUserControl));
            DevComponents.DotNetBar.LabelX labelX1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buscarBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.CLAVEColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.CODIGO_PROVEEDORColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.NOMBREColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.DESCTO_OFRECIDOColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.DESCTO_ADICIONAL_PROVEEColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.DESCTO_ESPECIAL_PROVEEColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_ALTAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.FECHA_BAJAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.PROVEEDOR_IDColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.NOMBRE_PROVEEDORColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.descuentoCredencialButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.agregaProductoButtonItem = new DevComponents.DotNetBar.ButtonItem();
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
            this.agregaProductoButtonItem,
            this.descuentoCredencialButtonItem});
            this.bar1.ItemSpacing = 10;
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(298, 32);
            this.titleLabel.Text = "COMPRAS\\OFERTAS PFIZER";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(64, 144);
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewX1);
            this.splitContainer1.Size = new System.Drawing.Size(915, 577);
            this.splitContainer1.SplitterDistance = 49;
            this.splitContainer1.TabStop = false;
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
            this.apellidosLabel.Location = new System.Drawing.Point(713, 61);
            this.apellidosLabel.Text = "";
            // 
            // nombreLabel
            // 
            this.nombreLabel.Location = new System.Drawing.Point(713, 40);
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
            labelX1.Location = new System.Drawing.Point(3, 14);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(43, 20);
            labelX1.TabIndex = 1;
            labelX1.Text = "Buscar:";
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
            this.buscarTextBoxX.Location = new System.Drawing.Point(51, 12);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(779, 25);
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
            this.dataGridViewX1.AllowUserToOrderColumns = true;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLAVEColumn,
            this.CODIGO_PROVEEDORColumn,
            this.NOMBREColumn,
            this.DESCTO_OFRECIDOColumn,
            this.DESCTO_ADICIONAL_PROVEEColumn,
            this.DESCTO_ESPECIAL_PROVEEColumn,
            this.FECHA_ALTAColumn,
            this.FECHA_BAJAColumn,
            this.PROVEEDOR_IDColumn,
            this.NOMBRE_PROVEEDORColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(915, 508);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            this.dataGridViewX1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewX1_CellValidating);
            this.dataGridViewX1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_ColumnHeaderMouseClick);
            // 
            // CLAVEColumn
            // 
            this.CLAVEColumn.DataPropertyName = "ARTICULO_ID";
            this.CLAVEColumn.HeaderText = "CLAVE";
            this.CLAVEColumn.Name = "CLAVEColumn";
            this.CLAVEColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CLAVEColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CODIGO_PROVEEDORColumn
            // 
            this.CODIGO_PROVEEDORColumn.DataPropertyName = "CODIGO_PROVEEDOR";
            this.CODIGO_PROVEEDORColumn.HeaderText = "CODIGO PROVEEDOR";
            this.CODIGO_PROVEEDORColumn.Name = "CODIGO_PROVEEDORColumn";
            // 
            // NOMBREColumn
            // 
            this.NOMBREColumn.DataPropertyName = "NOMBRE1";
            this.NOMBREColumn.HeaderText = "NOMBRE";
            this.NOMBREColumn.Name = "NOMBREColumn";
            this.NOMBREColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NOMBREColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.NOMBREColumn.Width = 200;
            // 
            // DESCTO_OFRECIDOColumn
            // 
            this.DESCTO_OFRECIDOColumn.DataPropertyName = "DESCTO_OFRECIDO";
            this.DESCTO_OFRECIDOColumn.HeaderText = "DESCTO_OFRECIDO";
            this.DESCTO_OFRECIDOColumn.Name = "DESCTO_OFRECIDOColumn";
            this.DESCTO_OFRECIDOColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DESCTO_OFRECIDOColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DESCTO_ADICIONAL_PROVEEColumn
            // 
            this.DESCTO_ADICIONAL_PROVEEColumn.DataPropertyName = "DESCTO_ADICIONAL_PROVEE";
            this.DESCTO_ADICIONAL_PROVEEColumn.HeaderText = "ADICIONAL";
            this.DESCTO_ADICIONAL_PROVEEColumn.Name = "DESCTO_ADICIONAL_PROVEEColumn";
            // 
            // DESCTO_ESPECIAL_PROVEEColumn
            // 
            this.DESCTO_ESPECIAL_PROVEEColumn.DataPropertyName = "DESCTO_ESPECIAL_PROVEE";
            this.DESCTO_ESPECIAL_PROVEEColumn.HeaderText = "DESCTO_ESPECIAL";
            this.DESCTO_ESPECIAL_PROVEEColumn.Name = "DESCTO_ESPECIAL_PROVEEColumn";
            // 
            // FECHA_ALTAColumn
            // 
            this.FECHA_ALTAColumn.DataPropertyName = "FECHA_ALTA";
            this.FECHA_ALTAColumn.HeaderText = "FECHA ALTA";
            this.FECHA_ALTAColumn.Name = "FECHA_ALTAColumn";
            this.FECHA_ALTAColumn.Width = 120;
            // 
            // FECHA_BAJAColumn
            // 
            this.FECHA_BAJAColumn.DataPropertyName = "FECHA_BAJA";
            this.FECHA_BAJAColumn.HeaderText = "FECHA BAJA";
            this.FECHA_BAJAColumn.Name = "FECHA_BAJAColumn";
            this.FECHA_BAJAColumn.Width = 120;
            // 
            // PROVEEDOR_IDColumn
            // 
            this.PROVEEDOR_IDColumn.DataPropertyName = "PROVEEDOR_ID";
            this.PROVEEDOR_IDColumn.HeaderText = "PROVEEDOR_ID";
            this.PROVEEDOR_IDColumn.Name = "PROVEEDOR_IDColumn";
            // 
            // NOMBRE_PROVEEDORColumn
            // 
            this.NOMBRE_PROVEEDORColumn.DataPropertyName = "PROVEEDOR_NOMBRE";
            this.NOMBRE_PROVEEDORColumn.HeaderText = "PROVEEDOR";
            this.NOMBRE_PROVEEDORColumn.Name = "NOMBRE_PROVEEDORColumn";
            this.NOMBRE_PROVEEDORColumn.Width = 250;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 49);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buscarButtonX
            // 
            this.buscarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buscarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buscarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buscarButtonX.Location = new System.Drawing.Point(837, 13);
            this.buscarButtonX.Name = "buscarButtonX";
            this.buscarButtonX.Size = new System.Drawing.Size(75, 23);
            this.buscarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buscarButtonX.TabIndex = 0;
            this.buscarButtonX.Text = "Buscar";
            this.buscarButtonX.Click += new System.EventHandler(this.buscarButtonX_Click);
            // 
            // descuentoCredencialButtonItem
            // 
            this.descuentoCredencialButtonItem.HoverImage = global::SIF.Properties.Resources.IDCardTool1;
            this.descuentoCredencialButtonItem.Image = global::SIF.Properties.Resources.IDCardTool;
            this.descuentoCredencialButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.descuentoCredencialButtonItem.Name = "descuentoCredencialButtonItem";
            this.descuentoCredencialButtonItem.Text = "Descuento\r\n ";
            this.descuentoCredencialButtonItem.Click += new System.EventHandler(this.descuentoCredencialButtonItem_Click);
            // 
            // agregaProductoButtonItem
            // 
            this.agregaProductoButtonItem.HoverImage = global::SIF.Properties.Resources.TableContentsTool1;
            this.agregaProductoButtonItem.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.agregaProductoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.agregaProductoButtonItem.Name = "agregaProductoButtonItem";
            this.agregaProductoButtonItem.Text = "Productos \r\n[F4]";
            this.agregaProductoButtonItem.Click += new System.EventHandler(this.agregaProductoButtonItem_Click);
            // 
            // OfertasMayoristaUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "OfertasMayoristaUserControl";
            this.Load += new System.EventHandler(this.CatArticulosUserControl_Load);
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

        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.ComponentModel.BackgroundWorker buscarBackgroundWorker;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn CLAVEColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn CODIGO_PROVEEDORColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn NOMBREColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn DESCTO_OFRECIDOColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn DESCTO_ADICIONAL_PROVEEColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCTO_ESPECIAL_PROVEEColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn FECHA_ALTAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn FECHA_BAJAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn PROVEEDOR_IDColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn NOMBRE_PROVEEDORColumn;
        private DevComponents.DotNetBar.ButtonItem descuentoCredencialButtonItem;
        private DevComponents.DotNetBar.ButtonItem agregaProductoButtonItem;
    }
}
