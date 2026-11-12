namespace SIF.View.OrdenCompra
{
    partial class FacturaDetallesUserControl
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn14 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn15 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label4;
            this.agregarArticuloButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.eliminarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.usuarioLabel = new System.Windows.Forms.Label();
            this.folioLabel = new System.Windows.Forms.Label();
            this.proveedorLabel = new System.Windows.Forms.Label();
            this.statusOClabel = new System.Windows.Forms.Label();
            this.CodigoTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cantidadTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.productosLabel = new System.Windows.Forms.Label();
            this.guardarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.seleccionaClienteButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.Tot_importe_facturalabelX = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.Tot_desctolabelX = new DevComponents.DotNetBar.LabelX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.Tot_ivaLabelX = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.Total_facturadoLabelX = new DevComponents.DotNetBar.LabelX();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.total_neto_factLabelX = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.Tot_descuento_sinivaLabelX = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.Tot_descuento_conivaLabelX = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.Total_iva_desctoLabelX = new DevComponents.DotNetBar.LabelX();
            this.Total_descto_descuentosLabelX = new DevComponents.DotNetBar.LabelX();
            label6 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.agregarArticuloButtonItem,
            this.seleccionaClienteButtonItem,
            this.eliminarButtonItem,
            this.guardarButtonItem});
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(323, 32);
            this.titleLabel.Text = "COMPRAS\\FACTURA DETALLE";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            this.superGridControl1.PrimaryGrid.CheckBoxes = true;
            gridColumn1.DataPropertyName = "ARTICULO_ID";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn1.HeaderText = "ARTICULO_ID";
            gridColumn1.Name = "ARTICULO_IDColumn";
            gridColumn2.DataPropertyName = "NOMBRE1";
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn2.HeaderText = "NOMBRE1";
            gridColumn2.Name = "NOMBRE1";
            gridColumn2.Width = 200;
            gridColumn3.DataPropertyName = "PZA_CCARGO";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn3.HeaderText = "PZA_CCARGO";
            gridColumn3.Name = "PZA_CCARGOColumn";
            gridColumn4.DataPropertyName = "PZA_SCARGO";
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn4.HeaderText = "PZA_SCARGO";
            gridColumn4.Name = "PZA_SCARGOColumn";
            gridColumn5.DataPropertyName = "PRECIO_VENTA_FAR";
            gridColumn5.Name = "PRECIO_VENTA_FAR";
            gridColumn6.DataPropertyName = "porc_oferta";
            gridColumn6.Name = "porc_oferta";
            gridColumn6.Width = 130;
            gridColumn7.DataPropertyName = "porc_descto";
            gridColumn7.Name = "porc_descto";
            gridColumn7.Width = 130;
            gridColumn8.DataPropertyName = "importe_neto";
            gridColumn8.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn8.Name = "importe_neto";
            gridColumn8.Width = 150;
            gridColumn9.DataPropertyName = "costo_neto_unit";
            gridColumn9.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn9.Name = "costo_neto_unit";
            gridColumn9.Width = 130;
            gridColumn10.DataPropertyName = "imp_descto_siniva";
            gridColumn10.Name = "imp_descto_siniva";
            gridColumn10.Width = 130;
            gridColumn11.DataPropertyName = "imp_descto_coniva";
            gridColumn11.Name = "imp_descto_coniva";
            gridColumn11.Width = 130;
            gridColumn12.DataPropertyName = "importe_iva";
            gridColumn12.Name = "importe_iva";
            gridColumn12.Width = 130;
            gridColumn13.DataPropertyName = "imp_descto_coniva_menosiva";
            gridColumn13.Name = "imp_descto_coniva_menosiva";
            gridColumn13.Width = 130;
            gridColumn14.DataPropertyName = "importe_cal1_oferta_coniva";
            gridColumn14.Name = "importe_cal1_oferta_coniva";
            gridColumn14.Width = 130;
            gridColumn15.DataPropertyName = "importe_cal1_oferta_siniva";
            gridColumn15.Name = "importe_cal1_oferta_siniva";
            gridColumn15.Width = 130;
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
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn14);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn15);
            this.superGridControl1.PrimaryGrid.FrozenColumnCount = 2;
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(915, 337);
            this.superGridControl1.Text = "";
            this.superGridControl1.EndEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl1_EndEdit);
            this.superGridControl1.PostRenderRow += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridPostRenderRowEventArgs>(this.superGridControl1_PostRenderRow);
            this.superGridControl1.RowDeleting += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowDeletingEventArgs>(this.superGridControl1_RowDeleting);
            this.superGridControl1.SelectionChanged += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEventArgs>(this.superGridControl1_SelectionChanged);
            this.superGridControl1.DoubleClick += new System.EventHandler(this.superGridControl1_DoubleClick);
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(915, 453);
            this.splitContainer1.SplitterDistance = 96;
            // 
            // statusLabel
            // 
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(637, 71);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(70, 17);
            label6.TabIndex = 5;
            label6.Text = "Productos:";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(339, 71);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(63, 17);
            label2.TabIndex = 10;
            label2.Text = "Cantidad:";
            // 
            // label9
            // 
            label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(43, 71);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(54, 17);
            label9.TabIndex = 10;
            label9.Text = "Codigo:";
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(668, 7);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(39, 17);
            label3.TabIndex = 3;
            label3.Text = "Folio:";
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 39);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(85, 17);
            label5.TabIndex = 15;
            label5.Text = "PROVEEDOR:";
            // 
            // label7
            // 
            label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(661, 39);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(46, 17);
            label7.TabIndex = 16;
            label7.Text = "Status:";
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 7);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(85, 17);
            label4.TabIndex = 15;
            label4.Text = "PROVEEDOR:";
            // 
            // agregarArticuloButtonItem
            // 
            this.agregarArticuloButtonItem.HoverImage = global::SIF.Properties.Resources.TableContentsTool1;
            this.agregarArticuloButtonItem.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.agregarArticuloButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.agregarArticuloButtonItem.Name = "agregarArticuloButtonItem";
            this.agregarArticuloButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.agregarArticuloButtonItem.Text = "Artículo \r\n[F3]";
            this.agregarArticuloButtonItem.Click += new System.EventHandler(this.agregaArticuloButtonItem_Click);
            // 
            // eliminarButtonItem
            // 
            this.eliminarButtonItem.HoverImage = global::SIF.Properties.Resources.Cancel1;
            this.eliminarButtonItem.Image = global::SIF.Properties.Resources.Cancel;
            this.eliminarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.eliminarButtonItem.Name = "eliminarButtonItem";
            this.eliminarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.eliminarButtonItem.Text = "Eliminar \r\n[F8]";
            this.eliminarButtonItem.Click += new System.EventHandler(this.eliminarButtonItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.usuarioLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(label3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.folioLabel, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.proveedorLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.statusOClabel, 5, 1);
            this.tableLayoutPanel1.Controls.Add(label7, 4, 1);
            this.tableLayoutPanel1.Controls.Add(label9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CodigoTextBoxX, 1, 2);
            this.tableLayoutPanel1.Controls.Add(label2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cantidadTextBoxX, 3, 2);
            this.tableLayoutPanel1.Controls.Add(label6, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.productosLabel, 5, 2);
            this.tableLayoutPanel1.Controls.Add(label4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0005F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0005F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0005F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 96);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // usuarioLabel
            // 
            this.usuarioLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.usuarioLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.usuarioLabel, 3);
            this.usuarioLabel.Location = new System.Drawing.Point(103, 7);
            this.usuarioLabel.Name = "usuarioLabel";
            this.usuarioLabel.Size = new System.Drawing.Size(504, 17);
            this.usuarioLabel.TabIndex = 14;
            this.usuarioLabel.Text = "[USUARIO]";
            // 
            // folioLabel
            // 
            this.folioLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.folioLabel.AutoSize = true;
            this.folioLabel.Location = new System.Drawing.Point(861, 7);
            this.folioLabel.Name = "folioLabel";
            this.folioLabel.Size = new System.Drawing.Size(51, 17);
            this.folioLabel.TabIndex = 13;
            this.folioLabel.Text = "[FOLIO]";
            // 
            // proveedorLabel
            // 
            this.proveedorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.proveedorLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.proveedorLabel, 3);
            this.proveedorLabel.Location = new System.Drawing.Point(103, 39);
            this.proveedorLabel.Name = "proveedorLabel";
            this.proveedorLabel.Size = new System.Drawing.Size(504, 17);
            this.proveedorLabel.TabIndex = 14;
            this.proveedorLabel.Text = "[PROVEEDOR]";
            // 
            // statusOClabel
            // 
            this.statusOClabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.statusOClabel.AutoSize = true;
            this.statusOClabel.Location = new System.Drawing.Point(888, 39);
            this.statusOClabel.Name = "statusOClabel";
            this.statusOClabel.Size = new System.Drawing.Size(24, 17);
            this.statusOClabel.TabIndex = 13;
            this.statusOClabel.Text = "[A]";
            // 
            // CodigoTextBoxX
            // 
            this.CodigoTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CodigoTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.CodigoTextBoxX.Border.Class = "TextBoxBorder";
            this.CodigoTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CodigoTextBoxX.ButtonCustom.Visible = true;
            this.CodigoTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.CodigoTextBoxX.Location = new System.Drawing.Point(103, 67);
            this.CodigoTextBoxX.Name = "CodigoTextBoxX";
            this.CodigoTextBoxX.Size = new System.Drawing.Size(199, 25);
            this.CodigoTextBoxX.TabIndex = 8;
            this.CodigoTextBoxX.WatermarkText = "Código";
            this.CodigoTextBoxX.ButtonCustomClick += new System.EventHandler(this.CodigoTextBoxX_ButtonCustomClick);
            this.CodigoTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodigoTextBoxX_KeyDown);
            // 
            // cantidadTextBoxX
            // 
            this.cantidadTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cantidadTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.cantidadTextBoxX.Border.Class = "TextBoxBorder";
            this.cantidadTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cantidadTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.cantidadTextBoxX.Location = new System.Drawing.Point(408, 67);
            this.cantidadTextBoxX.Name = "cantidadTextBoxX";
            this.cantidadTextBoxX.Size = new System.Drawing.Size(199, 25);
            this.cantidadTextBoxX.TabIndex = 9;
            this.cantidadTextBoxX.Text = "1";
            this.cantidadTextBoxX.WatermarkText = "Cantidad";
            this.cantidadTextBoxX.Enter += new System.EventHandler(this.cantidadTextBoxX_Enter);
            this.cantidadTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cantidadTextBoxX_KeyDown);
            // 
            // productosLabel
            // 
            this.productosLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.productosLabel.AutoSize = true;
            this.productosLabel.Location = new System.Drawing.Point(897, 71);
            this.productosLabel.Name = "productosLabel";
            this.productosLabel.Size = new System.Drawing.Size(15, 17);
            this.productosLabel.TabIndex = 12;
            this.productosLabel.Text = "0";
            // 
            // guardarButtonItem
            // 
            this.guardarButtonItem.HoverImage = global::SIF.Properties.Resources.SaveTool1;
            this.guardarButtonItem.Image = global::SIF.Properties.Resources.SaveTool;
            this.guardarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.guardarButtonItem.Name = "guardarButtonItem";
            this.guardarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.guardarButtonItem.Text = "Guardar \r\n[F5]";
            this.guardarButtonItem.Click += new System.EventHandler(this.guardarButtonItem_Click);
            // 
            // seleccionaClienteButtonItem
            // 
            this.seleccionaClienteButtonItem.HoverImage = global::SIF.Properties.Resources.UserFindTool1;
            this.seleccionaClienteButtonItem.Image = global::SIF.Properties.Resources.UserFindTool;
            this.seleccionaClienteButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.seleccionaClienteButtonItem.Name = "seleccionaClienteButtonItem";
            this.seleccionaClienteButtonItem.Text = "Proveedor \r\n[F3]";
            this.seleccionaClienteButtonItem.Click += new System.EventHandler(this.seleccionaClienteButtonItem_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.53719F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.46281F));
            this.tableLayoutPanel2.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Tot_importe_facturalabelX, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelX2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.Tot_desctolabelX, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelX15, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.Tot_ivaLabelX, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelX4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.Total_facturadoLabelX, 1, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(247, 600);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(363, 114);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(122, 14);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Tot_importe_factura";
            // 
            // Tot_importe_facturalabelX
            // 
            // 
            // 
            // 
            this.Tot_importe_facturalabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Tot_importe_facturalabelX.Location = new System.Drawing.Point(131, 3);
            this.Tot_importe_facturalabelX.Name = "Tot_importe_facturalabelX";
            this.Tot_importe_facturalabelX.Size = new System.Drawing.Size(75, 14);
            this.Tot_importe_facturalabelX.TabIndex = 1;
            this.Tot_importe_facturalabelX.Text = "$0.00";
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(3, 23);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(122, 14);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Tot_descto";
            // 
            // Tot_desctolabelX
            // 
            // 
            // 
            // 
            this.Tot_desctolabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Tot_desctolabelX.Location = new System.Drawing.Point(131, 23);
            this.Tot_desctolabelX.Name = "Tot_desctolabelX";
            this.Tot_desctolabelX.Size = new System.Drawing.Size(75, 14);
            this.Tot_desctolabelX.TabIndex = 1;
            this.Tot_desctolabelX.Text = "$0.00";
            // 
            // labelX15
            // 
            this.labelX15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Location = new System.Drawing.Point(3, 43);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(122, 14);
            this.labelX15.TabIndex = 0;
            this.labelX15.Text = "Tot_iva";
            // 
            // Tot_ivaLabelX
            // 
            // 
            // 
            // 
            this.Tot_ivaLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Tot_ivaLabelX.Location = new System.Drawing.Point(131, 43);
            this.Tot_ivaLabelX.Name = "Tot_ivaLabelX";
            this.Tot_ivaLabelX.Size = new System.Drawing.Size(75, 14);
            this.Tot_ivaLabelX.TabIndex = 1;
            this.Tot_ivaLabelX.Text = "$0.00";
            // 
            // labelX4
            // 
            this.labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(3, 63);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(122, 14);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Total_facturado";
            // 
            // Total_facturadoLabelX
            // 
            // 
            // 
            // 
            this.Total_facturadoLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Total_facturadoLabelX.Location = new System.Drawing.Point(131, 63);
            this.Total_facturadoLabelX.Name = "Total_facturadoLabelX";
            this.Total_facturadoLabelX.Size = new System.Drawing.Size(75, 14);
            this.Total_facturadoLabelX.TabIndex = 1;
            this.Total_facturadoLabelX.Text = "$0.00";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.32232F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.67768F));
            this.tableLayoutPanel3.Controls.Add(this.labelX3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.total_neto_factLabelX, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelX7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.Tot_descuento_sinivaLabelX, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelX9, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.Tot_descuento_conivaLabelX, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.labelX11, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.labelX12, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.Total_iva_desctoLabelX, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.Total_descto_descuentosLabelX, 1, 4);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(616, 597);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(363, 114);
            this.tableLayoutPanel3.TabIndex = 21;
            // 
            // labelX3
            // 
            this.labelX3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(3, 3);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(144, 14);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "total_neto_fact";
            // 
            // total_neto_factLabelX
            // 
            this.total_neto_factLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.total_neto_factLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.total_neto_factLabelX.Location = new System.Drawing.Point(153, 3);
            this.total_neto_factLabelX.Name = "total_neto_factLabelX";
            this.total_neto_factLabelX.Size = new System.Drawing.Size(207, 14);
            this.total_neto_factLabelX.TabIndex = 1;
            this.total_neto_factLabelX.Text = "$0.00";
            // 
            // labelX7
            // 
            this.labelX7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(3, 23);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(144, 14);
            this.labelX7.TabIndex = 0;
            this.labelX7.Text = "Tot_descuento_siniva";
            // 
            // Tot_descuento_sinivaLabelX
            // 
            this.Tot_descuento_sinivaLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Tot_descuento_sinivaLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Tot_descuento_sinivaLabelX.Location = new System.Drawing.Point(153, 23);
            this.Tot_descuento_sinivaLabelX.Name = "Tot_descuento_sinivaLabelX";
            this.Tot_descuento_sinivaLabelX.Size = new System.Drawing.Size(207, 14);
            this.Tot_descuento_sinivaLabelX.TabIndex = 1;
            this.Tot_descuento_sinivaLabelX.Text = "$0.00";
            // 
            // labelX9
            // 
            this.labelX9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(3, 43);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(144, 14);
            this.labelX9.TabIndex = 0;
            this.labelX9.Text = "Tot_descuento_coniva";
            // 
            // Tot_descuento_conivaLabelX
            // 
            this.Tot_descuento_conivaLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Tot_descuento_conivaLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Tot_descuento_conivaLabelX.Location = new System.Drawing.Point(153, 43);
            this.Tot_descuento_conivaLabelX.Name = "Tot_descuento_conivaLabelX";
            this.Tot_descuento_conivaLabelX.Size = new System.Drawing.Size(207, 14);
            this.Tot_descuento_conivaLabelX.TabIndex = 1;
            this.Tot_descuento_conivaLabelX.Text = "$0.00";
            // 
            // labelX11
            // 
            this.labelX11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(3, 63);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(144, 14);
            this.labelX11.TabIndex = 0;
            this.labelX11.Text = "Total_iva_descto";
            // 
            // labelX12
            // 
            this.labelX12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(3, 83);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(144, 14);
            this.labelX12.TabIndex = 0;
            this.labelX12.Text = "Total_descto_descuentos";
            // 
            // Total_iva_desctoLabelX
            // 
            this.Total_iva_desctoLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Total_iva_desctoLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Total_iva_desctoLabelX.Location = new System.Drawing.Point(153, 63);
            this.Total_iva_desctoLabelX.Name = "Total_iva_desctoLabelX";
            this.Total_iva_desctoLabelX.Size = new System.Drawing.Size(207, 14);
            this.Total_iva_desctoLabelX.TabIndex = 1;
            this.Total_iva_desctoLabelX.Text = "$0.00";
            // 
            // Total_descto_descuentosLabelX
            // 
            this.Total_descto_descuentosLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Total_descto_descuentosLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Total_descto_descuentosLabelX.Location = new System.Drawing.Point(153, 83);
            this.Total_descto_descuentosLabelX.Name = "Total_descto_descuentosLabelX";
            this.Total_descto_descuentosLabelX.Size = new System.Drawing.Size(207, 14);
            this.Total_descto_descuentosLabelX.TabIndex = 1;
            this.Total_descto_descuentosLabelX.Text = "$0.00";
            // 
            // FacturaDetallesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "FacturaDetallesUserControl";
            this.Load += new System.EventHandler(this.FacturaDetallesUserControl_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel2, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel3, 0);
            this.Controls.SetChildIndex(this.statusLabel, 0);
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
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem agregarArticuloButtonItem;
        private DevComponents.DotNetBar.ButtonItem eliminarButtonItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX CodigoTextBoxX;
        private DevComponents.DotNetBar.Controls.TextBoxX cantidadTextBoxX;
        private System.Windows.Forms.Label productosLabel;
        private System.Windows.Forms.Label usuarioLabel;
        private DevComponents.DotNetBar.ButtonItem guardarButtonItem;
        private System.Windows.Forms.Label folioLabel;
        private System.Windows.Forms.Label proveedorLabel;
        private System.Windows.Forms.Label statusOClabel;
        private DevComponents.DotNetBar.ButtonItem seleccionaClienteButtonItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX Tot_importe_facturalabelX;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX Tot_desctolabelX;
        private DevComponents.DotNetBar.LabelX Tot_ivaLabelX;
        private DevComponents.DotNetBar.LabelX labelX15;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX Total_facturadoLabelX;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevComponents.DotNetBar.LabelX total_neto_factLabelX;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX Tot_descuento_sinivaLabelX;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX Tot_descuento_conivaLabelX;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.LabelX Total_iva_desctoLabelX;
        private DevComponents.DotNetBar.LabelX Total_descto_descuentosLabelX;
    }
}
