namespace SIF.View.Ventas
{
    partial class FoliocontroladoUserControl
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
            DevComponents.DotNetBar.LabelX labelX2;
            DevComponents.DotNetBar.LabelX labelX3;
            DevComponents.DotNetBar.LabelX labelX23;
            DevComponents.DotNetBar.LabelX labelX4;
            this.agregaProductoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ConRetieneReceta = new System.Windows.Forms.CheckBox();
            this.btnCliente = new DevComponents.DotNetBar.ButtonX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.nombreClienteLabelX = new DevComponents.DotNetBar.LabelX();
            this.conRecetaCheckBox = new System.Windows.Forms.CheckBox();
            this.CodigoTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cantidadTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.descripcionTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.vendedorLabelX = new DevComponents.DotNetBar.LabelX();
            this.totalLetraLabelX = new DevComponents.DotNetBar.LabelX();
            this.seleccionaClienteButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.guardarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.cancelarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.totalLabelX = new DevComponents.DotNetBar.LabelX();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.descuentoLabelX = new DevComponents.DotNetBar.LabelX();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.IVAlabelX = new DevComponents.DotNetBar.LabelX();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.subtotalLabelX = new DevComponents.DotNetBar.LabelX();
            this.labelX19 = new DevComponents.DotNetBar.LabelX();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            labelX3 = new DevComponents.DotNetBar.LabelX();
            labelX23 = new DevComponents.DotNetBar.LabelX();
            labelX4 = new DevComponents.DotNetBar.LabelX();
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
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.ColorScheme.ExplorerBarBackground = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bar1.ColorScheme.ExplorerBarBackground2 = System.Drawing.Color.Green;
            this.bar1.ColorScheme.ItemHotBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bar1.ColorScheme.ItemHotBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.agregaProductoButtonItem,
            this.seleccionaClienteButtonItem,
            this.guardarButtonItem,
            this.cancelarButtonItem});
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.bar1.Size = new System.Drawing.Size(713, 92);
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(164, 32);
            this.titleLabel.Text = "SIF\\Controlado";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
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
            gridColumn3.Name = "NOMBRE2Coumn";
            gridColumn3.Width = 200;
            gridColumn4.DataPropertyName = "CantidadRemision";
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn4.HeaderText = "CANTIDAD";
            gridColumn4.Name = "CANTIDADColumn";
            gridColumn4.Width = 80;
            gridColumn5.DataPropertyName = "Descuento";
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn5.HeaderText = "DESCUENTO";
            gridColumn5.Name = "DESCUENTOColumn";
            gridColumn6.DataPropertyName = "Precio";
            gridColumn6.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn6.HeaderText = "PRECIO";
            gridColumn6.Name = "COSTOColumn";
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(915, 346);
            this.superGridControl1.EndEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl1_EndEdit);
            this.superGridControl1.RowDeleting += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDeletingEventArgs>(this.superGridControl1_RowDeleting);
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(64, 145);
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(915, 460);
            this.splitContainer1.SplitterDistance = 94;
            // 
            // statusLabel
            // 
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.statusLabel.Location = new System.Drawing.Point(68, 706);
            this.statusLabel.Size = new System.Drawing.Size(709, 22);
            this.statusLabel.Text = "";
            // 
            // labelX2
            // 
            labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelX2.AutoSize = true;
            // 
            // 
            // 
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.Location = new System.Drawing.Point(45, 34);
            labelX2.Name = "labelX2";
            labelX2.Size = new System.Drawing.Size(62, 20);
            labelX2.TabIndex = 2;
            labelX2.Text = "Vendedor:";
            // 
            // labelX3
            // 
            labelX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelX3.AutoSize = true;
            // 
            // 
            // 
            labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX3.Location = new System.Drawing.Point(60, 65);
            labelX3.Name = "labelX3";
            labelX3.Size = new System.Drawing.Size(47, 20);
            labelX3.TabIndex = 0;
            labelX3.Text = "Código:";
            // 
            // labelX23
            // 
            labelX23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelX23.AutoSize = true;
            // 
            // 
            // 
            labelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX23.Location = new System.Drawing.Point(276, 65);
            labelX23.Name = "labelX23";
            labelX23.Size = new System.Drawing.Size(57, 20);
            labelX23.TabIndex = 20;
            labelX23.Text = "Cantidad:";
            // 
            // labelX4
            // 
            labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelX4.AutoSize = true;
            // 
            // 
            // 
            labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX4.Location = new System.Drawing.Point(497, 65);
            labelX4.Name = "labelX4";
            labelX4.Size = new System.Drawing.Size(72, 20);
            labelX4.TabIndex = 26;
            labelX4.Text = "Descripción:";
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.47523F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.47367F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.47367F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.57743F));
            this.tableLayoutPanel1.Controls.Add(this.ConRetieneReceta, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCliente, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nombreClienteLabelX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(labelX2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.conRecetaCheckBox, 6, 1);
            this.tableLayoutPanel1.Controls.Add(labelX3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CodigoTextBoxX, 1, 2);
            this.tableLayoutPanel1.Controls.Add(labelX23, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cantidadTextBoxX, 3, 2);
            this.tableLayoutPanel1.Controls.Add(labelX4, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.descripcionTextBoxX, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.vendedorLabelX, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 94);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // ConRetieneReceta
            // 
            this.ConRetieneReceta.Location = new System.Drawing.Point(575, 34);
            this.ConRetieneReceta.Name = "ConRetieneReceta";
            this.ConRetieneReceta.Size = new System.Drawing.Size(128, 21);
            this.ConRetieneReceta.TabIndex = 34;
            this.ConRetieneReceta.Text = "Retiene Receta";
            this.ConRetieneReceta.UseVisualStyleBackColor = true;
            this.ConRetieneReceta.CheckedChanged += new System.EventHandler(this.ConRetieneReceta_CheckedChanged);
            // 
            // btnCliente
            // 
            this.btnCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCliente.Location = new System.Drawing.Point(264, 34);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(49, 20);
            this.btnCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCliente.TabIndex = 33;
            this.btnCliente.Text = "...";
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // labelX7
            // 
            this.labelX7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(8, 3);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(99, 20);
            this.labelX7.TabIndex = 22;
            this.labelX7.Text = "Nombre Médico:";
            // 
            // nombreClienteLabelX
            // 
            this.nombreClienteLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.nombreClienteLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.nombreClienteLabelX, 4);
            this.nombreClienteLabelX.Location = new System.Drawing.Point(113, 3);
            this.nombreClienteLabelX.Name = "nombreClienteLabelX";
            this.nombreClienteLabelX.Size = new System.Drawing.Size(456, 17);
            this.nombreClienteLabelX.TabIndex = 22;
            // 
            // conRecetaCheckBox
            // 
            this.conRecetaCheckBox.Location = new System.Drawing.Point(726, 34);
            this.conRecetaCheckBox.Name = "conRecetaCheckBox";
            this.conRecetaCheckBox.Size = new System.Drawing.Size(66, 21);
            this.conRecetaCheckBox.TabIndex = 31;
            this.conRecetaCheckBox.Text = "Receta";
            this.conRecetaCheckBox.UseVisualStyleBackColor = true;
            this.conRecetaCheckBox.CheckedChanged += new System.EventHandler(this.conRecetaCheckBox_CheckedChanged);
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
            this.CodigoTextBoxX.Location = new System.Drawing.Point(113, 65);
            this.CodigoTextBoxX.Name = "CodigoTextBoxX";
            this.CodigoTextBoxX.Size = new System.Drawing.Size(145, 25);
            this.CodigoTextBoxX.TabIndex = 1;
            this.CodigoTextBoxX.WatermarkText = "Código";
            this.CodigoTextBoxX.ButtonCustomClick += new System.EventHandler(this.CodigoTextBoxX_ButtonCustomClick);
            this.CodigoTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodigoTextBoxX_KeyDown);
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
            this.cantidadTextBoxX.Location = new System.Drawing.Point(339, 65);
            this.cantidadTextBoxX.Name = "cantidadTextBoxX";
            this.cantidadTextBoxX.Size = new System.Drawing.Size(145, 25);
            this.cantidadTextBoxX.TabIndex = 21;
            this.cantidadTextBoxX.Text = "1";
            this.cantidadTextBoxX.WatermarkText = "Cantidad";
            this.cantidadTextBoxX.Enter += new System.EventHandler(this.cantidadTextBoxX_Enter);
            this.cantidadTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cantidadTextBoxX_KeyDown);
            // 
            // descripcionTextBoxX
            // 
            this.descripcionTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descripcionTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.descripcionTextBoxX.Border.Class = "TextBoxBorder";
            this.descripcionTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.descripcionTextBoxX, 2);
            this.descripcionTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.descripcionTextBoxX.Location = new System.Drawing.Point(575, 65);
            this.descripcionTextBoxX.Name = "descripcionTextBoxX";
            this.descripcionTextBoxX.Size = new System.Drawing.Size(337, 25);
            this.descripcionTextBoxX.TabIndex = 27;
            this.descripcionTextBoxX.WatermarkText = "Descripción";
            // 
            // vendedorLabelX
            // 
            this.vendedorLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.vendedorLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.vendedorLabelX.Location = new System.Drawing.Point(113, 34);
            this.vendedorLabelX.Name = "vendedorLabelX";
            this.vendedorLabelX.Size = new System.Drawing.Size(145, 25);
            this.vendedorLabelX.TabIndex = 32;
            // 
            // totalLetraLabelX
            // 
            this.totalLetraLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.totalLetraLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.totalLetraLabelX.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLetraLabelX.Location = new System.Drawing.Point(64, 614);
            this.totalLetraLabelX.Name = "totalLetraLabelX";
            this.totalLetraLabelX.Size = new System.Drawing.Size(569, 22);
            this.totalLetraLabelX.TabIndex = 14;
            this.totalLetraLabelX.Text = "Cero pesos con cero centavos 00/100 M.N.";
            this.totalLetraLabelX.TextAlignment = System.Drawing.StringAlignment.Far;
            this.totalLetraLabelX.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // seleccionaClienteButtonItem
            // 
            this.seleccionaClienteButtonItem.HoverImage = global::SIF.Properties.Resources.UserFindTool1;
            this.seleccionaClienteButtonItem.Image = global::SIF.Properties.Resources.UserFindTool;
            this.seleccionaClienteButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.seleccionaClienteButtonItem.Name = "seleccionaClienteButtonItem";
            this.seleccionaClienteButtonItem.Text = "Vendedor \r\n[F3]";
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
            // cancelarButtonItem
            // 
            this.cancelarButtonItem.HoverImage = global::SIF.Properties.Resources.DeleteBinTool1;
            this.cancelarButtonItem.Image = global::SIF.Properties.Resources.DeleteBinTool;
            this.cancelarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.cancelarButtonItem.Name = "cancelarButtonItem";
            this.cancelarButtonItem.Text = "Cancelar\r\n[F8]";
            this.cancelarButtonItem.Click += new System.EventHandler(this.cancelarButtonItem_Click);
            // 
            // highlighter
            // 
            this.highlighter.ContainerControl = this;
            this.highlighter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.totalLabelX, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.labelX16, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.descuentoLabelX, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.labelX17, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.IVAlabelX, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelX18, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.subtotalLabelX, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelX19, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(639, 609);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(340, 122);
            this.tableLayoutPanel3.TabIndex = 21;
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
            this.totalLabelX.Location = new System.Drawing.Point(103, 93);
            this.totalLabelX.Name = "totalLabelX";
            this.totalLabelX.Size = new System.Drawing.Size(234, 26);
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
            this.labelX16.Location = new System.Drawing.Point(3, 93);
            this.labelX16.Name = "labelX16";
            this.labelX16.Size = new System.Drawing.Size(94, 17);
            this.labelX16.TabIndex = 28;
            this.labelX16.Text = "Total:";
            this.labelX16.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // descuentoLabelX
            // 
            this.descuentoLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.descuentoLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.descuentoLabelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descuentoLabelX.Location = new System.Drawing.Point(103, 63);
            this.descuentoLabelX.Name = "descuentoLabelX";
            this.descuentoLabelX.Size = new System.Drawing.Size(234, 24);
            this.descuentoLabelX.TabIndex = 27;
            this.descuentoLabelX.Text = "$0.00";
            this.descuentoLabelX.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX17
            // 
            // 
            // 
            // 
            this.labelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX17.Location = new System.Drawing.Point(3, 63);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(94, 17);
            this.labelX17.TabIndex = 26;
            this.labelX17.Text = "Descuento:";
            this.labelX17.TextAlignment = System.Drawing.StringAlignment.Far;
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
            this.IVAlabelX.Location = new System.Drawing.Point(103, 33);
            this.IVAlabelX.Name = "IVAlabelX";
            this.IVAlabelX.Size = new System.Drawing.Size(234, 24);
            this.IVAlabelX.TabIndex = 25;
            this.IVAlabelX.Text = "$0.00";
            this.IVAlabelX.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX18
            // 
            // 
            // 
            // 
            this.labelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX18.Location = new System.Drawing.Point(3, 33);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(94, 17);
            this.labelX18.TabIndex = 24;
            this.labelX18.Text = "IVA:";
            this.labelX18.TextAlignment = System.Drawing.StringAlignment.Far;
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
            this.subtotalLabelX.Size = new System.Drawing.Size(234, 24);
            this.subtotalLabelX.TabIndex = 23;
            this.subtotalLabelX.Text = "$0.00";
            this.subtotalLabelX.TextAlignment = System.Drawing.StringAlignment.Far;
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
            // FoliocontroladoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.totalLetraLabelX);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FoliocontroladoUserControl";
            this.Load += new System.EventHandler(this.VentaUserControl_Load);
            this.Controls.SetChildIndex(this.statusLabel, 0);
            this.Controls.SetChildIndex(this.totalLetraLabelX, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel3, 0);
            this.Controls.SetChildIndex(this.titleLabel, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.Controls.SetChildIndex(this.bar1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
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

        private DevComponents.DotNetBar.ButtonItem agregaProductoButtonItem;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.ButtonItem seleccionaClienteButtonItem;
        private DevComponents.DotNetBar.ButtonItem guardarButtonItem;
        private DevComponents.DotNetBar.ButtonItem cancelarButtonItem;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevComponents.DotNetBar.LabelX totalLetraLabelX;
        private DevComponents.DotNetBar.Controls.TextBoxX CodigoTextBoxX;
        private DevComponents.DotNetBar.Controls.TextBoxX cantidadTextBoxX;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevComponents.DotNetBar.LabelX totalLabelX;
        private DevComponents.DotNetBar.LabelX labelX16;
        private DevComponents.DotNetBar.LabelX descuentoLabelX;
        private DevComponents.DotNetBar.LabelX labelX17;
        private DevComponents.DotNetBar.LabelX IVAlabelX;
        private DevComponents.DotNetBar.LabelX labelX18;
        private DevComponents.DotNetBar.LabelX subtotalLabelX;
        private DevComponents.DotNetBar.LabelX labelX19;
        private DevComponents.DotNetBar.Controls.TextBoxX descripcionTextBoxX;
        private DevComponents.DotNetBar.LabelX nombreClienteLabelX;
        private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.CheckBox conRecetaCheckBox;
        private DevComponents.DotNetBar.LabelX vendedorLabelX;
        private DevComponents.DotNetBar.ButtonX btnCliente;
        private System.Windows.Forms.CheckBox ConRetieneReceta;
    }
}
