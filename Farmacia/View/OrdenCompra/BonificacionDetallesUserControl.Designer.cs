namespace SIF.View.OrdenCompra
{
    partial class BonificacionDetallesUserControl
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
            DevComponents.DotNetBar.LabelX labelX20;
            DevComponents.DotNetBar.LabelX labelX3;
            DevComponents.DotNetBar.LabelX labelX2;
            DevComponents.DotNetBar.LabelX labelX23;
            DevComponents.DotNetBar.LabelX labelX4;
            DevComponents.DotNetBar.LabelX labelX1;
            DevComponents.DotNetBar.LabelX labelX5;
            DevComponents.DotNetBar.LabelX labelX6;
            DevComponents.DotNetBar.LabelX labelX7;
            DevComponents.DotNetBar.LabelX labelX8;
            this.totalLabelX = new DevComponents.DotNetBar.LabelX();
            this.recibirButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.folioVentaLabelX = new DevComponents.DotNetBar.LabelX();
            this.vendedorLabelX = new DevComponents.DotNetBar.LabelX();
            this.CodigoTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cantidadTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.descripcionTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.sucursalComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.loteTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.referenciaTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.conceptoBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.eliminarArticuloButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.agregaProductoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            labelX20 = new DevComponents.DotNetBar.LabelX();
            labelX3 = new DevComponents.DotNetBar.LabelX();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            labelX23 = new DevComponents.DotNetBar.LabelX();
            labelX4 = new DevComponents.DotNetBar.LabelX();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            labelX5 = new DevComponents.DotNetBar.LabelX();
            labelX6 = new DevComponents.DotNetBar.LabelX();
            labelX7 = new DevComponents.DotNetBar.LabelX();
            labelX8 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.eliminarArticuloButtonItem,
            this.recibirButtonItem});
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(284, 32);
            this.titleLabel.Text = "COMPRAS\\BONIFICACION";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            this.superGridControl1.PrimaryGrid.ColumnHeader.RowHeight = 25;
            gridColumn1.DataPropertyName = "ARTICULO_ID";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn1.HeaderText = "ARTICULO";
            gridColumn1.Name = "ARTICULO_IDColumn";
            gridColumn2.DataPropertyName = "NOMBRE1";
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn2.HeaderText = "NOMBRE";
            gridColumn2.Name = "NOMBREColumn";
            gridColumn2.Width = 200;
            gridColumn3.DataPropertyName = "CANTIDAD";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn3.HeaderText = "CANTIDAD";
            gridColumn3.Name = "CANTIDADColumn";
            gridColumn4.DataPropertyName = "PRECIO";
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn4.HeaderText = "PRECIO";
            gridColumn4.Name = "PRECIOColumn";
            gridColumn5.DataPropertyName = "PRECIO_VTA";
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn5.HeaderText = "PRECIO VENTA";
            gridColumn5.Name = "PRECIO_VENTAColumn";
            gridColumn6.DataPropertyName = "CONCEPTO_DET";
            gridColumn6.HeaderText = "CONCEPTO DETALLE";
            gridColumn6.Name = "CONCEPTO_DETColumn";
            gridColumn6.Width = 250;
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl1.PrimaryGrid.RowHeaderWidth = 30;
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.ShowTreeButtons = true;
            this.superGridControl1.PrimaryGrid.ShowTreeLines = true;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(915, 414);
            this.superGridControl1.EndEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl1_EndEdit);
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(915, 557);
            this.splitContainer1.TabIndex = 6;
            // 
            // statusLabel
            // 
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // labelX20
            // 
            labelX20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelX20.AutoSize = true;
            // 
            // 
            // 
            labelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX20.Location = new System.Drawing.Point(43, 3);
            labelX20.Name = "labelX20";
            labelX20.Size = new System.Drawing.Size(41, 20);
            labelX20.TabIndex = 4;
            labelX20.Text = "FOLIO:";
            // 
            // labelX3
            // 
            labelX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelX3.AutoSize = true;
            // 
            // 
            // 
            labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX3.Location = new System.Drawing.Point(30, 93);
            labelX3.Name = "labelX3";
            labelX3.Size = new System.Drawing.Size(54, 20);
            labelX3.TabIndex = 0;
            labelX3.Text = "CODIGO:";
            // 
            // labelX2
            // 
            labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelX2.AutoSize = true;
            // 
            // 
            // 
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.Location = new System.Drawing.Point(24, 63);
            labelX2.Name = "labelX2";
            labelX2.Size = new System.Drawing.Size(60, 20);
            labelX2.TabIndex = 2;
            labelX2.Text = "USUARIO:";
            // 
            // labelX23
            // 
            labelX23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelX23.AutoSize = true;
            // 
            // 
            // 
            labelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX23.Location = new System.Drawing.Point(249, 93);
            labelX23.Name = "labelX23";
            labelX23.Size = new System.Drawing.Size(68, 20);
            labelX23.TabIndex = 20;
            labelX23.Text = "CANTIDAD:";
            // 
            // labelX4
            // 
            labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelX4.AutoSize = true;
            // 
            // 
            // 
            labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX4.Location = new System.Drawing.Point(482, 93);
            labelX4.Name = "labelX4";
            labelX4.Size = new System.Drawing.Size(86, 20);
            labelX4.TabIndex = 26;
            labelX4.Text = "DESCRIPCION:";
            // 
            // labelX1
            // 
            labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelX1.AutoSize = true;
            // 
            // 
            // 
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.Location = new System.Drawing.Point(282, 3);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(35, 20);
            labelX1.TabIndex = 21;
            labelX1.Text = "LOTE:";
            // 
            // labelX5
            // 
            labelX5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelX5.AutoSize = true;
            // 
            // 
            // 
            labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX5.Location = new System.Drawing.Point(491, 3);
            labelX5.Name = "labelX5";
            labelX5.Size = new System.Drawing.Size(77, 20);
            labelX5.TabIndex = 22;
            labelX5.Text = "REFERENCIA:";
            // 
            // labelX6
            // 
            labelX6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelX6.AutoSize = true;
            // 
            // 
            // 
            labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX6.Location = new System.Drawing.Point(13, 33);
            labelX6.Name = "labelX6";
            labelX6.Size = new System.Drawing.Size(71, 20);
            labelX6.TabIndex = 23;
            labelX6.Text = "CONCEPTO:";
            // 
            // labelX7
            // 
            labelX7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelX7.AutoSize = true;
            // 
            // 
            // 
            labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX7.Location = new System.Drawing.Point(492, 63);
            labelX7.Name = "labelX7";
            labelX7.Size = new System.Drawing.Size(76, 20);
            labelX7.TabIndex = 22;
            labelX7.Text = "INVOLUCRA:";
            // 
            // labelX8
            // 
            labelX8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            labelX8.AutoSize = true;
            // 
            // 
            // 
            labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX8.Location = new System.Drawing.Point(739, 701);
            labelX8.Name = "labelX8";
            labelX8.Size = new System.Drawing.Size(43, 20);
            labelX8.TabIndex = 27;
            labelX8.Text = "TOTAL:";
            // 
            // totalLabelX
            // 
            this.totalLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.totalLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.totalLabelX.Location = new System.Drawing.Point(788, 701);
            this.totalLabelX.Name = "totalLabelX";
            this.totalLabelX.Size = new System.Drawing.Size(188, 20);
            this.totalLabelX.TabIndex = 28;
            this.totalLabelX.Text = "$0.00";
            this.totalLabelX.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // recibirButtonItem
            // 
            this.recibirButtonItem.HoverImage = global::SIF.Properties.Resources.SaveTool1;
            this.recibirButtonItem.Image = global::SIF.Properties.Resources.SaveTool;
            this.recibirButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.recibirButtonItem.Name = "recibirButtonItem";
            this.recibirButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.recibirButtonItem.Text = "Guardar \r\n[F5]";
            this.recibirButtonItem.Click += new System.EventHandler(this.recibirButtonItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.47523F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.47367F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.47367F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.57743F));
            this.tableLayoutPanel1.Controls.Add(labelX6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(labelX20, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.folioVentaLabelX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(labelX2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.vendedorLabelX, 1, 2);
            this.tableLayoutPanel1.Controls.Add(labelX3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.CodigoTextBoxX, 1, 3);
            this.tableLayoutPanel1.Controls.Add(labelX23, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cantidadTextBoxX, 3, 3);
            this.tableLayoutPanel1.Controls.Add(labelX4, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.descripcionTextBoxX, 5, 3);
            this.tableLayoutPanel1.Controls.Add(labelX1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(labelX5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(labelX7, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.sucursalComboBoxEx, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.loteTextBoxX, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.referenciaTextBoxX, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.conceptoBoxEx, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 123);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // folioVentaLabelX
            // 
            // 
            // 
            // 
            this.folioVentaLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.folioVentaLabelX.Location = new System.Drawing.Point(90, 3);
            this.folioVentaLabelX.Name = "folioVentaLabelX";
            this.folioVentaLabelX.Size = new System.Drawing.Size(145, 17);
            this.folioVentaLabelX.TabIndex = 15;
            // 
            // vendedorLabelX
            // 
            this.vendedorLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.vendedorLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.vendedorLabelX, 3);
            this.vendedorLabelX.Location = new System.Drawing.Point(90, 63);
            this.vendedorLabelX.Name = "vendedorLabelX";
            this.vendedorLabelX.Size = new System.Drawing.Size(379, 17);
            this.vendedorLabelX.TabIndex = 18;
            this.vendedorLabelX.Text = "[VENDEDOR]";
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
            this.CodigoTextBoxX.Location = new System.Drawing.Point(90, 93);
            this.CodigoTextBoxX.Name = "CodigoTextBoxX";
            this.CodigoTextBoxX.Size = new System.Drawing.Size(146, 25);
            this.CodigoTextBoxX.TabIndex = 1;
            this.CodigoTextBoxX.WatermarkText = "CODIGO";
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
            this.cantidadTextBoxX.Location = new System.Drawing.Point(323, 93);
            this.cantidadTextBoxX.Name = "cantidadTextBoxX";
            this.cantidadTextBoxX.Size = new System.Drawing.Size(146, 25);
            this.cantidadTextBoxX.TabIndex = 2;
            this.cantidadTextBoxX.Text = "1";
            this.cantidadTextBoxX.WatermarkText = "Cantidad";
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
            this.descripcionTextBoxX.Location = new System.Drawing.Point(574, 93);
            this.descripcionTextBoxX.Name = "descripcionTextBoxX";
            this.descripcionTextBoxX.Size = new System.Drawing.Size(338, 25);
            this.descripcionTextBoxX.TabIndex = 3;
            this.descripcionTextBoxX.WatermarkText = "DESCRIPCION";
            // 
            // sucursalComboBoxEx
            // 
            this.sucursalComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.sucursalComboBoxEx, 2);
            this.sucursalComboBoxEx.DisplayMember = "Text";
            this.sucursalComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.sucursalComboBoxEx.FormattingEnabled = true;
            this.sucursalComboBoxEx.ItemHeight = 19;
            this.sucursalComboBoxEx.Location = new System.Drawing.Point(574, 63);
            this.sucursalComboBoxEx.Name = "sucursalComboBoxEx";
            this.sucursalComboBoxEx.Size = new System.Drawing.Size(338, 25);
            this.sucursalComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sucursalComboBoxEx.TabIndex = 7;
            // 
            // loteTextBoxX
            // 
            this.loteTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loteTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.loteTextBoxX.Border.Class = "TextBoxBorder";
            this.loteTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.loteTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.loteTextBoxX.Location = new System.Drawing.Point(323, 3);
            this.loteTextBoxX.MaxLength = 3;
            this.loteTextBoxX.Name = "loteTextBoxX";
            this.loteTextBoxX.Size = new System.Drawing.Size(146, 25);
            this.loteTextBoxX.TabIndex = 4;
            this.loteTextBoxX.WatermarkText = "LOTE";
            // 
            // referenciaTextBoxX
            // 
            this.referenciaTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.referenciaTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.referenciaTextBoxX.Border.Class = "TextBoxBorder";
            this.referenciaTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.referenciaTextBoxX, 2);
            this.referenciaTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.referenciaTextBoxX.Location = new System.Drawing.Point(574, 3);
            this.referenciaTextBoxX.MaxLength = 20;
            this.referenciaTextBoxX.Name = "referenciaTextBoxX";
            this.referenciaTextBoxX.Size = new System.Drawing.Size(338, 25);
            this.referenciaTextBoxX.TabIndex = 5;
            this.referenciaTextBoxX.WatermarkText = "DOCUMENTO REFERENCIA";
            // 
            // conceptoBoxEx
            // 
            this.conceptoBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.conceptoBoxEx, 6);
            this.conceptoBoxEx.DisplayMember = "Text";
            this.conceptoBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.conceptoBoxEx.FormattingEnabled = true;
            this.conceptoBoxEx.ItemHeight = 19;
            this.conceptoBoxEx.Location = new System.Drawing.Point(90, 33);
            this.conceptoBoxEx.Name = "conceptoBoxEx";
            this.conceptoBoxEx.Size = new System.Drawing.Size(822, 25);
            this.conceptoBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.conceptoBoxEx.TabIndex = 27;
            // 
            // eliminarArticuloButtonItem
            // 
            this.eliminarArticuloButtonItem.HoverImage = global::SIF.Properties.Resources.DeleteBinTool1;
            this.eliminarArticuloButtonItem.Image = global::SIF.Properties.Resources.DeleteBinTool;
            this.eliminarArticuloButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.eliminarArticuloButtonItem.Name = "eliminarArticuloButtonItem";
            this.eliminarArticuloButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.eliminarArticuloButtonItem.Text = "Eliminar \r\n[F8]";
            this.eliminarArticuloButtonItem.Click += new System.EventHandler(this.eliminarArticuloButtonItem_Click);
            // 
            // agregaProductoButtonItem
            // 
            this.agregaProductoButtonItem.HoverImage = global::SIF.Properties.Resources.TableContentsTool1;
            this.agregaProductoButtonItem.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.agregaProductoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.agregaProductoButtonItem.Name = "agregaProductoButtonItem";
            this.agregaProductoButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.agregaProductoButtonItem.Text = "Productos \r\n[F4]";
            this.agregaProductoButtonItem.Click += new System.EventHandler(this.agregaProductoButtonItem_Click);
            // 
            // BonificacionDetallesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.totalLabelX);
            this.Controls.Add(labelX8);
            this.Name = "BonificacionDetallesUserControl";
            this.Load += new System.EventHandler(this.BonificacionDetallesUserControl_Load);
            this.Controls.SetChildIndex(this.statusLabel, 0);
            this.Controls.SetChildIndex(this.titleLabel, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.Controls.SetChildIndex(this.bar1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(labelX8, 0);
            this.Controls.SetChildIndex(this.totalLabelX, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem recibirButtonItem;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.LabelX folioVentaLabelX;
        private DevComponents.DotNetBar.LabelX vendedorLabelX;
        private DevComponents.DotNetBar.Controls.TextBoxX CodigoTextBoxX;
        private DevComponents.DotNetBar.Controls.TextBoxX cantidadTextBoxX;
        private DevComponents.DotNetBar.Controls.TextBoxX descripcionTextBoxX;
        private DevComponents.DotNetBar.Controls.ComboBoxEx sucursalComboBoxEx;
        private DevComponents.DotNetBar.Controls.TextBoxX loteTextBoxX;
        private DevComponents.DotNetBar.Controls.TextBoxX referenciaTextBoxX;
        private DevComponents.DotNetBar.ButtonItem eliminarArticuloButtonItem;
        private DevComponents.DotNetBar.ButtonItem agregaProductoButtonItem;
        private DevComponents.DotNetBar.LabelX totalLabelX;
        private DevComponents.DotNetBar.Controls.ComboBoxEx conceptoBoxEx;
    }
}
