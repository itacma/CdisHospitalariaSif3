namespace SIF.View.Ventas
{
    partial class CotizacionUserControl
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.LabelX labelX1;
            DevComponents.DotNetBar.LabelX labelX14;
            DevComponents.DotNetBar.LabelX labelX5;
            DevComponents.DotNetBar.LabelX labelX3;
            DevComponents.DotNetBar.LabelX labelX2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CotizacionUserControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cantidadTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.vendedorLabelX = new DevComponents.DotNetBar.LabelX();
            this.clienteLabelX = new DevComponents.DotNetBar.LabelX();
            this.RFClabelX = new DevComponents.DotNetBar.LabelX();
            this.conFacturaCheckBox = new System.Windows.Forms.CheckBox();
            this.folioCotizacionLabelX = new DevComponents.DotNetBar.LabelX();
            this.CodigoTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.sucursalesComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.agregaProductoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.guardarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.LblDescuento = new DevComponents.DotNetBar.LabelX();
            this.labelX19 = new DevComponents.DotNetBar.LabelX();
            this.subtotalLabelX = new DevComponents.DotNetBar.LabelX();
            this.totalLabelX = new DevComponents.DotNetBar.LabelX();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.IVAlabelX = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.totalLetraLabelX = new DevComponents.DotNetBar.LabelX();
            this.cancelarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.seleccionaClienteButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.descuentoCredencialButtonItem = new DevComponents.DotNetBar.ButtonItem();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            labelX14 = new DevComponents.DotNetBar.LabelX();
            labelX5 = new DevComponents.DotNetBar.LabelX();
            labelX3 = new DevComponents.DotNetBar.LabelX();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.TabIndex = 3;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.agregaProductoButtonItem,
            this.seleccionaClienteButtonItem,
            this.descuentoCredencialButtonItem,
            this.guardarButtonItem,
            this.cancelarButtonItem});
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.bar1.Size = new System.Drawing.Size(783, 92);
            this.bar1.ItemClick += new System.EventHandler(this.bar1_ItemClick);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(157, 32);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "SIF\\Cotizacion";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            gridColumn1.DataPropertyName = "ArticuloID";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn1.HeaderText = "CODIGO";
            gridColumn1.Name = "ARTICULO_IDColumn";
            gridColumn2.DataPropertyName = "Nombre1";
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn2.HeaderText = "NOMBRE 1";
            gridColumn2.Name = "NOMBRE1Column";
            gridColumn2.Width = 200;
            gridColumn3.DataPropertyName = "Nombre2";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn3.HeaderText = "NOMBRE 2";
            gridColumn3.Name = "NOMBRE2Column";
            gridColumn3.Width = 200;
            gridColumn4.DataPropertyName = "CantidadCotizacion";
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn4.HeaderText = "CANTIDAD";
            gridColumn4.Name = "CANTIDADColumn";
            gridColumn5.DataPropertyName = "Precio";
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn5.HeaderText = "PRECIO";
            gridColumn5.Name = "PRECIOColumn";
            gridColumn6.DataPropertyName = "Total";
            gridColumn6.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn6.HeaderText = "TOTAL";
            gridColumn6.Name = "TOTALColumn";
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(919, 295);
            this.superGridControl1.TabIndex = 1;
            this.superGridControl1.EndEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl1_EndEdit);
            this.superGridControl1.RowDeleting += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDeletingEventArgs>(this.superGridControl1_RowDeleting);
            this.superGridControl1.Click += new System.EventHandler(this.superGridControl1_Click);
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(64, 145);
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(919, 448);
            this.splitContainer1.SplitterDistance = 133;
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
            labelX1.Location = new System.Drawing.Point(3, 108);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(75, 16);
            labelX1.TabIndex = 0;
            labelX1.Text = "Código:";
            // 
            // labelX14
            // 
            // 
            // 
            // 
            labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX14.Location = new System.Drawing.Point(485, 108);
            labelX14.Name = "labelX14";
            labelX14.Size = new System.Drawing.Size(75, 16);
            labelX14.TabIndex = 20;
            labelX14.Text = "Cantidad:";
            // 
            // labelX5
            // 
            labelX5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelX5.AutoSize = true;
            // 
            // 
            // 
            labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX5.Location = new System.Drawing.Point(452, 42);
            labelX5.Name = "labelX5";
            labelX5.Size = new System.Drawing.Size(27, 20);
            labelX5.TabIndex = 31;
            labelX5.Text = "RFC:";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX3.Location = new System.Drawing.Point(3, 42);
            labelX3.Name = "labelX3";
            labelX3.Size = new System.Drawing.Size(114, 21);
            labelX3.TabIndex = 4;
            labelX3.Text = "Numero de folio:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.Location = new System.Drawing.Point(3, 3);
            labelX2.Name = "labelX2";
            labelX2.Size = new System.Drawing.Size(114, 14);
            labelX2.TabIndex = 5;
            labelX2.Text = "Numero de Suc:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33629F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33185F));
            this.tableLayoutPanel1.Controls.Add(labelX1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(labelX14, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.cantidadTextBoxX, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.vendedorLabelX, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.clienteLabelX, 1, 2);
            this.tableLayoutPanel1.Controls.Add(labelX5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.RFClabelX, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.conFacturaCheckBox, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.folioCotizacionLabelX, 1, 1);
            this.tableLayoutPanel1.Controls.Add(labelX3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(labelX2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CodigoTextBoxX, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.sucursalesComboBoxEx, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.70886F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.70886F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(919, 133);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cantidadTextBoxX
            // 
            this.cantidadTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cantidadTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.cantidadTextBoxX.Border.Class = "TextBoxBorder";
            this.cantidadTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cantidadTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.highlighter.SetHighlightOnFocus(this.cantidadTextBoxX, true);
            this.cantidadTextBoxX.Location = new System.Drawing.Point(605, 108);
            this.cantidadTextBoxX.Name = "cantidadTextBoxX";
            this.cantidadTextBoxX.Size = new System.Drawing.Size(311, 25);
            this.cantidadTextBoxX.TabIndex = 1;
            this.cantidadTextBoxX.Text = "1";
            this.cantidadTextBoxX.WatermarkText = "Cantidad";
            this.cantidadTextBoxX.TextChanged += new System.EventHandler(this.cantidadTextBoxX_TextChanged);
            this.cantidadTextBoxX.Enter += new System.EventHandler(this.cantidadTextBoxX_Enter);
            this.cantidadTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cantidadTextBoxX_KeyDown);
            // 
            // vendedorLabelX
            // 
            // 
            // 
            // 
            this.vendedorLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.vendedorLabelX.Location = new System.Drawing.Point(3, 81);
            this.vendedorLabelX.Name = "vendedorLabelX";
            this.vendedorLabelX.Size = new System.Drawing.Size(111, 17);
            this.vendedorLabelX.TabIndex = 3;
            this.vendedorLabelX.Text = "Clave del Cliente:";
            // 
            // clienteLabelX
            // 
            this.clienteLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.clienteLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.clienteLabelX, 4);
            this.clienteLabelX.Location = new System.Drawing.Point(123, 81);
            this.clienteLabelX.Name = "clienteLabelX";
            this.clienteLabelX.Size = new System.Drawing.Size(793, 21);
            this.clienteLabelX.TabIndex = 5;
            this.clienteLabelX.Text = "[MOSTRADOR]";
            // 
            // RFClabelX
            // 
            this.RFClabelX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RFClabelX.AutoSize = true;
            // 
            // 
            // 
            this.RFClabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RFClabelX.Location = new System.Drawing.Point(485, 42);
            this.RFClabelX.Name = "RFClabelX";
            this.RFClabelX.Size = new System.Drawing.Size(75, 20);
            this.RFClabelX.TabIndex = 30;
            this.RFClabelX.Text = "XX001001XX";
            // 
            // conFacturaCheckBox
            // 
            this.conFacturaCheckBox.AutoSize = true;
            this.conFacturaCheckBox.Location = new System.Drawing.Point(605, 42);
            this.conFacturaCheckBox.Name = "conFacturaCheckBox";
            this.conFacturaCheckBox.Size = new System.Drawing.Size(125, 21);
            this.conFacturaCheckBox.TabIndex = 21;
            this.conFacturaCheckBox.Text = "Requiere Factura";
            this.conFacturaCheckBox.UseVisualStyleBackColor = true;
            this.conFacturaCheckBox.CheckedChanged += new System.EventHandler(this.conFacturaCheckBox_CheckedChanged);
            // 
            // folioCotizacionLabelX
            // 
            this.folioCotizacionLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.folioCotizacionLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.folioCotizacionLabelX.Location = new System.Drawing.Point(123, 50);
            this.folioCotizacionLabelX.Name = "folioCotizacionLabelX";
            this.folioCotizacionLabelX.Size = new System.Drawing.Size(310, 17);
            this.folioCotizacionLabelX.TabIndex = 15;
            this.folioCotizacionLabelX.Text = "[COTIZACION]";
            // 
            // CodigoTextBoxX
            // 
            this.CodigoTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CodigoTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.CodigoTextBoxX.Border.Class = "TextBoxBorder";
            this.CodigoTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CodigoTextBoxX.ButtonCustom.Visible = true;
            this.CodigoTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.CodigoTextBoxX.Location = new System.Drawing.Point(123, 108);
            this.CodigoTextBoxX.Name = "CodigoTextBoxX";
            this.CodigoTextBoxX.Size = new System.Drawing.Size(310, 25);
            this.CodigoTextBoxX.TabIndex = 0;
            this.CodigoTextBoxX.WatermarkText = "Código";
            this.CodigoTextBoxX.ButtonCustomClick += new System.EventHandler(this.CodigoTextBoxX_ButtonCustomClick_1);
            this.CodigoTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodigoTextBoxX_KeyDown);
            // 
            // sucursalesComboBoxEx
            // 
            this.sucursalesComboBoxEx.DisplayMember = "Text";
            this.sucursalesComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.sucursalesComboBoxEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sucursalesComboBoxEx.FormattingEnabled = true;
            this.sucursalesComboBoxEx.ItemHeight = 19;
            this.sucursalesComboBoxEx.Location = new System.Drawing.Point(123, 3);
            this.sucursalesComboBoxEx.Name = "sucursalesComboBoxEx";
            this.sucursalesComboBoxEx.Size = new System.Drawing.Size(310, 25);
            this.sucursalesComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sucursalesComboBoxEx.TabIndex = 3;
            this.sucursalesComboBoxEx.SelectedIndexChanged += new System.EventHandler(this.sucursalesComboBoxEx_SelectedIndexChanged);
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
            // guardarButtonItem
            // 
            this.guardarButtonItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("guardarButtonItem.HoverImage")));
            this.guardarButtonItem.Image = ((System.Drawing.Image)(resources.GetObject("guardarButtonItem.Image")));
            this.guardarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.guardarButtonItem.Name = "guardarButtonItem";
            this.guardarButtonItem.Text = "Guardar\r\n[F5]";
            this.guardarButtonItem.Click += new System.EventHandler(this.guardarButtonItem_Click);
            // 
            // highlighter
            // 
            this.highlighter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.LblDescuento, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelX19, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.subtotalLabelX, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.totalLabelX, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.labelX16, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.labelX18, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.IVAlabelX, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.labelX4, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(647, 600);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(336, 115);
            this.tableLayoutPanel3.TabIndex = 23;
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // LblDescuento
            // 
            this.LblDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.LblDescuento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LblDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDescuento.Location = new System.Drawing.Point(103, 30);
            this.LblDescuento.Name = "LblDescuento";
            this.LblDescuento.Size = new System.Drawing.Size(230, 21);
            this.LblDescuento.TabIndex = 31;
            this.LblDescuento.Text = "$0.00";
            this.LblDescuento.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX19
            // 
            // 
            // 
            // 
            this.labelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX19.Location = new System.Drawing.Point(3, 3);
            this.labelX19.Name = "labelX19";
            this.labelX19.Size = new System.Drawing.Size(94, 17);
            this.labelX19.TabIndex = 22;
            this.labelX19.Text = "Subtotal:";
            this.labelX19.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // subtotalLabelX
            // 
            this.subtotalLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.subtotalLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.subtotalLabelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotalLabelX.Location = new System.Drawing.Point(103, 3);
            this.subtotalLabelX.Name = "subtotalLabelX";
            this.subtotalLabelX.Size = new System.Drawing.Size(230, 21);
            this.subtotalLabelX.TabIndex = 23;
            this.subtotalLabelX.Text = "$0.00";
            this.subtotalLabelX.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // totalLabelX
            // 
            this.totalLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.totalLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.totalLabelX.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.totalLabelX.Location = new System.Drawing.Point(103, 84);
            this.totalLabelX.Name = "totalLabelX";
            this.totalLabelX.Size = new System.Drawing.Size(230, 28);
            this.totalLabelX.TabIndex = 29;
            this.totalLabelX.Text = "$0.00";
            this.totalLabelX.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX16
            // 
            // 
            // 
            // 
            this.labelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX16.Location = new System.Drawing.Point(3, 84);
            this.labelX16.Name = "labelX16";
            this.labelX16.Size = new System.Drawing.Size(94, 17);
            this.labelX16.TabIndex = 28;
            this.labelX16.Text = "Total:";
            this.labelX16.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX18
            // 
            // 
            // 
            // 
            this.labelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX18.Location = new System.Drawing.Point(3, 57);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(94, 17);
            this.labelX18.TabIndex = 24;
            this.labelX18.Text = "IVA:";
            this.labelX18.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // IVAlabelX
            // 
            this.IVAlabelX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.IVAlabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.IVAlabelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IVAlabelX.Location = new System.Drawing.Point(103, 57);
            this.IVAlabelX.Name = "IVAlabelX";
            this.IVAlabelX.Size = new System.Drawing.Size(230, 21);
            this.IVAlabelX.TabIndex = 25;
            this.IVAlabelX.Text = "$0.00";
            this.IVAlabelX.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX4.Location = new System.Drawing.Point(3, 30);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(94, 21);
            this.labelX4.TabIndex = 30;
            this.labelX4.Text = "Descuento:";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // totalLetraLabelX
            // 
            this.totalLetraLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.totalLetraLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.totalLetraLabelX.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLetraLabelX.Location = new System.Drawing.Point(68, 605);
            this.totalLetraLabelX.Name = "totalLetraLabelX";
            this.totalLetraLabelX.Size = new System.Drawing.Size(523, 22);
            this.totalLetraLabelX.TabIndex = 22;
            this.totalLetraLabelX.Text = "Cero pesos con cero centavos 00/100 M.N.";
            this.totalLetraLabelX.TextAlignment = System.Drawing.StringAlignment.Far;
            this.totalLetraLabelX.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // cancelarButtonItem
            // 
            this.cancelarButtonItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("cancelarButtonItem.HoverImage")));
            this.cancelarButtonItem.Image = ((System.Drawing.Image)(resources.GetObject("cancelarButtonItem.Image")));
            this.cancelarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.cancelarButtonItem.Name = "cancelarButtonItem";
            this.cancelarButtonItem.Text = "Cancelar\r\n[F8]";
            this.cancelarButtonItem.Click += new System.EventHandler(this.cancelarButtonItem_Click);
            // 
            // seleccionaClienteButtonItem
            // 
            this.seleccionaClienteButtonItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("seleccionaClienteButtonItem.HoverImage")));
            this.seleccionaClienteButtonItem.Image = ((System.Drawing.Image)(resources.GetObject("seleccionaClienteButtonItem.Image")));
            this.seleccionaClienteButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.seleccionaClienteButtonItem.Name = "seleccionaClienteButtonItem";
            this.seleccionaClienteButtonItem.Text = "Cliente\r\n[F3]";
            this.seleccionaClienteButtonItem.Click += new System.EventHandler(this.seleccionaClienteButtonItem_Click);
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
            // CotizacionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.totalLetraLabelX);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "CotizacionUserControl";
            this.Load += new System.EventHandler(this.CotizacionUserControl_Load);
            this.Controls.SetChildIndex(this.totalLetraLabelX, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel3, 0);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.LabelX vendedorLabelX;
        private DevComponents.DotNetBar.LabelX clienteLabelX;
        private DevComponents.DotNetBar.Controls.TextBoxX cantidadTextBoxX;
        private DevComponents.DotNetBar.ButtonItem agregaProductoButtonItem;
        private DevComponents.DotNetBar.ButtonItem guardarButtonItem;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevComponents.DotNetBar.LabelX totalLabelX;
        private DevComponents.DotNetBar.LabelX labelX16;
        private DevComponents.DotNetBar.LabelX subtotalLabelX;
        private DevComponents.DotNetBar.LabelX labelX19;
        private DevComponents.DotNetBar.LabelX IVAlabelX;
        private DevComponents.DotNetBar.LabelX labelX18;
        private DevComponents.DotNetBar.LabelX totalLetraLabelX;
        private DevComponents.DotNetBar.ButtonItem cancelarButtonItem;
        private DevComponents.DotNetBar.ButtonItem seleccionaClienteButtonItem;
        private System.Windows.Forms.CheckBox conFacturaCheckBox;
        private DevComponents.DotNetBar.LabelX RFClabelX;
        private DevComponents.DotNetBar.ButtonItem descuentoCredencialButtonItem;
        private DevComponents.DotNetBar.Controls.TextBoxX CodigoTextBoxX;
        private DevComponents.DotNetBar.LabelX LblDescuento;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX folioCotizacionLabelX;
        private DevComponents.DotNetBar.Controls.ComboBoxEx sucursalesComboBoxEx;
    }
}
