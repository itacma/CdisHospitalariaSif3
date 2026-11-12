namespace SIF.View.OrdenCompra
{
    partial class RecepcionOrdenCompraDetallesUserControl
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecepcionOrdenCompraDetallesUserControl));
            this.recibirButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.proveedorLabel = new System.Windows.Forms.Label();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.direccionalmacenLabel = new System.Windows.Forms.Label();
            this.almacenLabel = new System.Windows.Forms.Label();
            this.folioLabel = new System.Windows.Forms.Label();
            this.statusOClabel = new System.Windows.Forms.Label();
            this.pedidoLabel = new System.Windows.Forms.Label();
            this.facturadoLabel = new System.Windows.Forms.Label();
            this.recibidoLabel = new System.Windows.Forms.Label();
            this.lineasLabel = new System.Windows.Forms.Label();
            this.fechaElaboracionLabel = new System.Windows.Forms.Label();
            this.facturaLabel = new System.Windows.Forms.Label();
            this.lineasFacturaLabel = new System.Windows.Forms.Label();
            this.recibirYAfectarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.dividirButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.agregaProductoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.recibeComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.observacionesGeneralesTextBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.actualizaArticuloButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.nuevoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            label5 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
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
            this.recibirButtonItem,
            this.recibirYAfectarButtonItem,
            this.agregaProductoButtonItem,
            this.nuevoButtonItem,
            this.actualizaArticuloButtonItem});
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(249, 32);
            this.titleLabel.Text = "COMPRAS\\RECEPCION";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            this.superGridControl1.PrimaryGrid.ColumnHeader.RowHeight = 50;
            gridColumn1.DataPropertyName = "ARTICULO_ID";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn1.HeaderText = "ARTICULO";
            gridColumn1.Name = "ARTICULO_IDColumn";
            gridColumn1.Width = 130;
            gridColumn2.DataPropertyName = "CODIGO_PROVEEDOR";
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn2.HeaderText = "CODIGO PROVEEDOR";
            gridColumn2.Name = "CODIGO_PROVEEDORColumn";
            gridColumn3.DataPropertyName = "NOMBRE";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn3.HeaderText = "NOMBRE";
            gridColumn3.Name = "NOMBREColumn";
            gridColumn3.Width = 250;
            gridColumn4.DataPropertyName = "CANT_SOLICITADA";
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn4.HeaderText = "SOLICITADA";
            gridColumn4.Name = "CANTIDAD_SOLICITADAColumn";
            gridColumn5.DataPropertyName = "CANT_FACTURADA";
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn5.HeaderText = "FACTURADA";
            gridColumn5.Name = "CANTIDAD_FACTURADAColumn";
            gridColumn6.DataPropertyName = "CANT_RECIBIDA";
            gridColumn6.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn6.HeaderText = "RECIBIDA";
            gridColumn6.Name = "CANTIDAD_RECIBIDAColumn";
            gridColumn6.ReadOnly = true;
            gridColumn7.DataPropertyName = "CANT_DEV_FALTANTE";
            gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn7.HeaderText = "FALTANTE";
            gridColumn7.Name = "FALTANTEColumn";
            gridColumn8.DataPropertyName = "CANT_MALESTADO";
            gridColumn8.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn8.HeaderText = "MAL ESTADO";
            gridColumn8.Name = "CANT_MALESTADOColumn";
            gridColumn9.DataPropertyName = "CANT_PROX_CADUCAR";
            gridColumn9.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn9.HeaderText = "PROX. CADUCAR";
            gridColumn9.Name = "CANT_PROX_CADUCAR_Column";
            gridColumn10.DataPropertyName = "CANT_DEV_NO_PEDIDO";
            gridColumn10.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn10.HeaderText = "NO PEDIDO";
            gridColumn10.Name = "NO_PEDIDOColumn";
            gridColumn11.DataPropertyName = "CANT_DEV_PRECIO_ELEVADO";
            gridColumn11.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn11.HeaderText = "PREC. ELEVADO";
            gridColumn11.Name = "PRECIO_ELEVADOColumn";
            gridColumn12.DataPropertyName = "CANT_REPOSICION";
            gridColumn12.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn12.HeaderText = "REPOSICION";
            gridColumn12.Name = "CANT_REPOSICIONColumn";
            gridColumn12.Visible = false;
            gridColumn13.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.None;
            gridColumn13.DataPropertyName = "OBSERVACIONES";
            gridColumn13.HeaderText = "OBSERVACIONES";
            gridColumn13.Name = "OBSERVACIONESColumn";
            gridColumn13.Width = 200;
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn7);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn8);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn9);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn10);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn11);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn12);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn13);
            this.superGridControl1.PrimaryGrid.FrozenColumnCount = 3;
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.ShowTreeButtons = true;
            this.superGridControl1.PrimaryGrid.ShowTreeLines = true;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(915, 365);
            this.superGridControl1.ColumnHeaderClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridColumnHeaderClickEventArgs>(this.superGridControl1_ColumnHeaderClick);
            this.superGridControl1.DataBindingComplete += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridDataBindingCompleteEventArgs>(this.superGridControl1_DataBindingComplete);
            this.superGridControl1.EndEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl1_EndEdit);
            this.superGridControl1.PostRenderRow += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridPostRenderRowEventArgs>(this.superGridControl1_PostRenderRow);
            this.superGridControl1.SelectionChanged += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEventArgs>(this.superGridControl1_SelectionChanged);
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            this.superGridControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyUp);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(915, 508);
            // 
            // statusLabel
            // 
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 4);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(85, 17);
            label5.TabIndex = 16;
            label5.Text = "PROVEEDOR:";
            // 
            // label12
            // 
            label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(3, 54);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(77, 17);
            label12.TabIndex = 23;
            label12.Text = "DIRECCION:";
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(768, 4);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(56, 17);
            label6.TabIndex = 15;
            label6.Text = "PEDIDO:";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(552, 4);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(46, 17);
            label2.TabIndex = 14;
            label2.Text = "FOLIO:";
            // 
            // label7
            // 
            label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(3, 79);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(75, 17);
            label7.TabIndex = 23;
            label7.Text = "CLAVE ART:";
            // 
            // label8
            // 
            label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(3, 29);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(70, 17);
            label8.TabIndex = 23;
            label8.Text = "ALMACEN:";
            // 
            // label10
            // 
            label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(542, 29);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(56, 17);
            label10.TabIndex = 22;
            label10.Text = "STATUS:";
            // 
            // label11
            // 
            label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(460, 79);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(138, 17);
            label11.TabIndex = 21;
            label11.Text = "FECHA ELABORACION:";
            // 
            // label13
            // 
            label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(61, 688);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(111, 17);
            label13.TabIndex = 24;
            label13.Text = "OBSERVACIONES:";
            // 
            // label14
            // 
            label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(759, 29);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(65, 17);
            label14.TabIndex = 14;
            label14.Text = "FACTURA:";
            // 
            // label15
            // 
            label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(758, 54);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(66, 17);
            label15.TabIndex = 14;
            label15.Text = "RECIBIDO:";
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(772, 79);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 17);
            label1.TabIndex = 14;
            label1.Text = "LINEAS:";
            // 
            // label9
            // 
            label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(64, 657);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(50, 17);
            label9.TabIndex = 24;
            label9.Text = "Recibe:";
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(533, 54);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(65, 17);
            label3.TabIndex = 22;
            label3.Text = "FACTURA:";
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(746, 103);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(78, 17);
            label4.TabIndex = 24;
            label4.Text = "LINEAS FAC:";
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
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 258F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.Controls.Add(this.proveedorLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarTextBoxX, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.direccionalmacenLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(label12, 0, 2);
            this.tableLayoutPanel1.Controls.Add(label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(label8, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.almacenLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.folioLabel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(label10, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.statusOClabel, 3, 1);
            this.tableLayoutPanel1.Controls.Add(label14, 4, 1);
            this.tableLayoutPanel1.Controls.Add(label15, 4, 2);
            this.tableLayoutPanel1.Controls.Add(label6, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.pedidoLabel, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.facturadoLabel, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.recibidoLabel, 5, 2);
            this.tableLayoutPanel1.Controls.Add(label1, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lineasLabel, 5, 3);
            this.tableLayoutPanel1.Controls.Add(label11, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.fechaElaboracionLabel, 3, 3);
            this.tableLayoutPanel1.Controls.Add(label3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.facturaLabel, 3, 2);
            this.tableLayoutPanel1.Controls.Add(label4, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.lineasFacturaLabel, 5, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 123);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // proveedorLabel
            // 
            this.proveedorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.proveedorLabel.AutoSize = true;
            this.proveedorLabel.Location = new System.Drawing.Point(124, 4);
            this.proveedorLabel.Name = "proveedorLabel";
            this.proveedorLabel.Size = new System.Drawing.Size(216, 17);
            this.proveedorLabel.TabIndex = 21;
            this.proveedorLabel.Text = "[PROVEEDOR]";
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
            this.buscarTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.buscarTextBoxX.Location = new System.Drawing.Point(124, 78);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(216, 25);
            this.buscarTextBoxX.TabIndex = 1;
            this.buscarTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buscarTextBoxX_KeyDown);
            // 
            // direccionalmacenLabel
            // 
            this.direccionalmacenLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.direccionalmacenLabel.AutoSize = true;
            this.direccionalmacenLabel.Location = new System.Drawing.Point(124, 54);
            this.direccionalmacenLabel.Name = "direccionalmacenLabel";
            this.direccionalmacenLabel.Size = new System.Drawing.Size(216, 17);
            this.direccionalmacenLabel.TabIndex = 22;
            this.direccionalmacenLabel.Text = "[DIRECCION ALMACEN]";
            // 
            // almacenLabel
            // 
            this.almacenLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.almacenLabel.AutoSize = true;
            this.almacenLabel.Location = new System.Drawing.Point(124, 29);
            this.almacenLabel.Name = "almacenLabel";
            this.almacenLabel.Size = new System.Drawing.Size(216, 17);
            this.almacenLabel.TabIndex = 22;
            this.almacenLabel.Text = "[ALMACEN]";
            // 
            // folioLabel
            // 
            this.folioLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.folioLabel.AutoSize = true;
            this.folioLabel.Location = new System.Drawing.Point(686, 4);
            this.folioLabel.Name = "folioLabel";
            this.folioLabel.Size = new System.Drawing.Size(51, 17);
            this.folioLabel.TabIndex = 14;
            this.folioLabel.Text = "[FOLIO]";
            // 
            // statusOClabel
            // 
            this.statusOClabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.statusOClabel.AutoSize = true;
            this.statusOClabel.Location = new System.Drawing.Point(713, 29);
            this.statusOClabel.Name = "statusOClabel";
            this.statusOClabel.Size = new System.Drawing.Size(24, 17);
            this.statusOClabel.TabIndex = 21;
            this.statusOClabel.Text = "[A]";
            // 
            // pedidoLabel
            // 
            this.pedidoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pedidoLabel.AutoSize = true;
            this.pedidoLabel.Location = new System.Drawing.Point(897, 4);
            this.pedidoLabel.Name = "pedidoLabel";
            this.pedidoLabel.Size = new System.Drawing.Size(15, 17);
            this.pedidoLabel.TabIndex = 16;
            this.pedidoLabel.Text = "0";
            // 
            // facturadoLabel
            // 
            this.facturadoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.facturadoLabel.AutoSize = true;
            this.facturadoLabel.Location = new System.Drawing.Point(897, 29);
            this.facturadoLabel.Name = "facturadoLabel";
            this.facturadoLabel.Size = new System.Drawing.Size(15, 17);
            this.facturadoLabel.TabIndex = 16;
            this.facturadoLabel.Text = "0";
            // 
            // recibidoLabel
            // 
            this.recibidoLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.recibidoLabel.AutoSize = true;
            this.recibidoLabel.Location = new System.Drawing.Point(897, 54);
            this.recibidoLabel.Name = "recibidoLabel";
            this.recibidoLabel.Size = new System.Drawing.Size(15, 17);
            this.recibidoLabel.TabIndex = 16;
            this.recibidoLabel.Text = "0";
            // 
            // lineasLabel
            // 
            this.lineasLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lineasLabel.AutoSize = true;
            this.lineasLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineasLabel.Location = new System.Drawing.Point(850, 79);
            this.lineasLabel.Name = "lineasLabel";
            this.lineasLabel.Size = new System.Drawing.Size(62, 17);
            this.lineasLabel.TabIndex = 22;
            this.lineasLabel.Text = "[LINEAS]";
            // 
            // fechaElaboracionLabel
            // 
            this.fechaElaboracionLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.fechaElaboracionLabel.AutoSize = true;
            this.fechaElaboracionLabel.Location = new System.Drawing.Point(683, 79);
            this.fechaElaboracionLabel.Name = "fechaElaboracionLabel";
            this.fechaElaboracionLabel.Size = new System.Drawing.Size(54, 17);
            this.fechaElaboracionLabel.TabIndex = 22;
            this.fechaElaboracionLabel.Text = "[FECHA]";
            // 
            // facturaLabel
            // 
            this.facturaLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.facturaLabel.AutoSize = true;
            this.facturaLabel.Location = new System.Drawing.Point(667, 54);
            this.facturaLabel.Name = "facturaLabel";
            this.facturaLabel.Size = new System.Drawing.Size(70, 17);
            this.facturaLabel.TabIndex = 21;
            this.facturaLabel.Text = "[FACTURA]";
            // 
            // lineasFacturaLabel
            // 
            this.lineasFacturaLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lineasFacturaLabel.AutoSize = true;
            this.lineasFacturaLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineasFacturaLabel.Location = new System.Drawing.Point(850, 103);
            this.lineasFacturaLabel.Name = "lineasFacturaLabel";
            this.lineasFacturaLabel.Size = new System.Drawing.Size(62, 17);
            this.lineasFacturaLabel.TabIndex = 25;
            this.lineasFacturaLabel.Text = "[LINEAS]";
            // 
            // recibirYAfectarButtonItem
            // 
            this.recibirYAfectarButtonItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("recibirYAfectarButtonItem.HoverImage")));
            this.recibirYAfectarButtonItem.Image = ((System.Drawing.Image)(resources.GetObject("recibirYAfectarButtonItem.Image")));
            this.recibirYAfectarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.recibirYAfectarButtonItem.Name = "recibirYAfectarButtonItem";
            this.recibirYAfectarButtonItem.Text = "Recibir\r\n ";
            this.recibirYAfectarButtonItem.Click += new System.EventHandler(this.recibirYAfectarButtonItem_Click);
            // 
            // dividirButtonItem
            // 
            this.dividirButtonItem.HoverImage = global::SIF.Properties.Resources.Split1;
            this.dividirButtonItem.Image = global::SIF.Properties.Resources.Split;
            this.dividirButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.dividirButtonItem.Name = "dividirButtonItem";
            this.dividirButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.dividirButtonItem.Text = "Dividir\r\n ";
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
            // recibeComboBoxEx
            // 
            this.recibeComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recibeComboBoxEx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.recibeComboBoxEx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.recibeComboBoxEx.DisplayMember = "Text";
            this.recibeComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.recibeComboBoxEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.recibeComboBoxEx.FormattingEnabled = true;
            this.recibeComboBoxEx.ItemHeight = 19;
            this.recibeComboBoxEx.Location = new System.Drawing.Point(178, 649);
            this.recibeComboBoxEx.Name = "recibeComboBoxEx";
            this.recibeComboBoxEx.Size = new System.Drawing.Size(801, 25);
            this.recibeComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.recibeComboBoxEx.TabIndex = 25;
            // 
            // observacionesGeneralesTextBox
            // 
            this.observacionesGeneralesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.observacionesGeneralesTextBox.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.observacionesGeneralesTextBox.Border.Class = "TextBoxBorder";
            this.observacionesGeneralesTextBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.observacionesGeneralesTextBox.ForeColor = System.Drawing.Color.Black;
            this.observacionesGeneralesTextBox.Location = new System.Drawing.Point(178, 680);
            this.observacionesGeneralesTextBox.Multiline = true;
            this.observacionesGeneralesTextBox.Name = "observacionesGeneralesTextBox";
            this.observacionesGeneralesTextBox.Size = new System.Drawing.Size(801, 51);
            this.observacionesGeneralesTextBox.TabIndex = 26;
            // 
            // actualizaArticuloButtonItem
            // 
            this.actualizaArticuloButtonItem.Enabled = false;
            this.actualizaArticuloButtonItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("actualizaArticuloButtonItem.HoverImage")));
            this.actualizaArticuloButtonItem.Image = ((System.Drawing.Image)(resources.GetObject("actualizaArticuloButtonItem.Image")));
            this.actualizaArticuloButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.actualizaArticuloButtonItem.Name = "actualizaArticuloButtonItem";
            this.actualizaArticuloButtonItem.Text = "Actualiza\r\n ";
            this.actualizaArticuloButtonItem.Click += new System.EventHandler(this.actualizaArticuloButtonItem_Click);
            // 
            // nuevoButtonItem
            // 
            this.nuevoButtonItem.HoverImage = global::SIF.Properties.Resources.NewDocument1;
            this.nuevoButtonItem.Image = global::SIF.Properties.Resources.NewDocument;
            this.nuevoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.nuevoButtonItem.Name = "nuevoButtonItem";
            this.nuevoButtonItem.Text = "Nuevo\r\n ";
            this.nuevoButtonItem.Click += new System.EventHandler(this.nuevoButtonItem_Click);
            // 
            // RecepcionOrdenCompraDetallesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.observacionesGeneralesTextBox);
            this.Controls.Add(this.recibeComboBoxEx);
            this.Controls.Add(label9);
            this.Controls.Add(label13);
            this.Name = "RecepcionOrdenCompraDetallesUserControl";
            this.Load += new System.EventHandler(this.RecepcionOrdenCompraDetallesUserControl_Load);
            this.Controls.SetChildIndex(this.statusLabel, 0);
            this.Controls.SetChildIndex(this.titleLabel, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.Controls.SetChildIndex(this.bar1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(label13, 0);
            this.Controls.SetChildIndex(label9, 0);
            this.Controls.SetChildIndex(this.recibeComboBoxEx, 0);
            this.Controls.SetChildIndex(this.observacionesGeneralesTextBox, 0);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonItem recibirYAfectarButtonItem;
        private DevComponents.DotNetBar.ButtonItem dividirButtonItem;
        private System.Windows.Forms.Label folioLabel;
        private System.Windows.Forms.Label proveedorLabel;
        private System.Windows.Forms.Label direccionalmacenLabel;
        private System.Windows.Forms.Label almacenLabel;
        private System.Windows.Forms.Label statusOClabel;
        private System.Windows.Forms.Label fechaElaboracionLabel;
        private System.Windows.Forms.Label pedidoLabel;
        private System.Windows.Forms.Label facturadoLabel;
        private System.Windows.Forms.Label recibidoLabel;
        private DevComponents.DotNetBar.ButtonItem agregaProductoButtonItem;
        private System.Windows.Forms.Label lineasLabel;
        private DevComponents.DotNetBar.Controls.ComboBoxEx recibeComboBoxEx;
        private DevComponents.DotNetBar.Controls.TextBoxX observacionesGeneralesTextBox;
        private System.Windows.Forms.Label facturaLabel;
        private DevComponents.DotNetBar.ButtonItem actualizaArticuloButtonItem;
        private System.Windows.Forms.Label lineasFacturaLabel;
        private DevComponents.DotNetBar.ButtonItem nuevoButtonItem;
    }
}
