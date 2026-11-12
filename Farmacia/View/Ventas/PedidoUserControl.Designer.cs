namespace SIF.View.Ventas
{
    partial class PedidoUserControl
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
            DevComponents.DotNetBar.LabelX labelX2;
            DevComponents.DotNetBar.LabelX labelX1;
            DevComponents.DotNetBar.LabelX labelX3;
            DevComponents.DotNetBar.LabelX labelX14;
            this.agregaProductoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.descuentoCredencialButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.guardarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SKUtextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.vendedorLabelX = new DevComponents.DotNetBar.LabelX();
            this.clienteLabelX = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.folioVentaLabelX = new DevComponents.DotNetBar.LabelX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.labelX19 = new DevComponents.DotNetBar.LabelX();
            this.labelX20 = new DevComponents.DotNetBar.LabelX();
            this.labelX21 = new DevComponents.DotNetBar.LabelX();
            this.labelX22 = new DevComponents.DotNetBar.LabelX();
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            labelX3 = new DevComponents.DotNetBar.LabelX();
            labelX14 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
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
            this.descuentoCredencialButtonItem,
            this.guardarButtonItem});
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.bar1.Size = new System.Drawing.Size(944, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(121, 32);
            this.titleLabel.Text = "SIF\\Pedido";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn1.HeaderText = "SELECT";
            gridColumn1.Name = "";
            gridColumn2.HeaderText = "CODIGO";
            gridColumn2.Name = "";
            gridColumn3.HeaderText = "DESCRIPCION";
            gridColumn3.Name = "";
            gridColumn4.HeaderText = "LINEA";
            gridColumn4.Name = "";
            gridColumn5.HeaderText = "CANTIDAD";
            gridColumn5.Name = "";
            gridColumn6.HeaderText = "PRECIO";
            gridColumn6.Name = "";
            gridColumn7.HeaderText = "DESCTO";
            gridColumn7.Name = "";
            gridColumn8.HeaderText = "TOTAL";
            gridColumn8.Name = "";
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn7);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn8);
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(919, 284);
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
            this.splitContainer1.SplitterDistance = 144;
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
            // labelX2
            // 
            // 
            // 
            // 
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.Location = new System.Drawing.Point(3, 75);
            labelX2.Name = "labelX2";
            labelX2.Size = new System.Drawing.Size(75, 17);
            labelX2.TabIndex = 2;
            labelX2.Text = "Vendedor:";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.Location = new System.Drawing.Point(3, 111);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(75, 17);
            labelX1.TabIndex = 0;
            labelX1.Text = "Código:";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX3.Location = new System.Drawing.Point(3, 3);
            labelX3.Name = "labelX3";
            labelX3.Size = new System.Drawing.Size(114, 25);
            labelX3.TabIndex = 4;
            labelX3.Text = "Clave Pedido:";
            // 
            // labelX14
            // 
            // 
            // 
            // 
            labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX14.Location = new System.Drawing.Point(470, 111);
            labelX14.Name = "labelX14";
            labelX14.Size = new System.Drawing.Size(75, 17);
            labelX14.TabIndex = 20;
            labelX14.Text = "Cantidad:";
            // 
            // agregaProductoButtonItem
            // 
            this.agregaProductoButtonItem.HoverImage = global::SIF.Properties.Resources.AddTool1;
            this.agregaProductoButtonItem.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.agregaProductoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.agregaProductoButtonItem.Name = "agregaProductoButtonItem";
            this.agregaProductoButtonItem.Text = "Productos\r\n[F3]";
            // 
            // descuentoCredencialButtonItem
            // 
            this.descuentoCredencialButtonItem.HoverImage = global::SIF.Properties.Resources.IDCardTool1;
            this.descuentoCredencialButtonItem.Image = global::SIF.Properties.Resources.IDCardTool;
            this.descuentoCredencialButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.descuentoCredencialButtonItem.Name = "descuentoCredencialButtonItem";
            this.descuentoCredencialButtonItem.Text = "Credencial\r\n ";
            // 
            // guardarButtonItem
            // 
            this.guardarButtonItem.HoverImage = global::SIF.Properties.Resources.SaveTool1;
            this.guardarButtonItem.Image = global::SIF.Properties.Resources.SaveTool;
            this.guardarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.guardarButtonItem.Name = "guardarButtonItem";
            this.guardarButtonItem.Text = "Guardar\r\n[F5]";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33629F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33185F));
            this.tableLayoutPanel1.Controls.Add(labelX2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.SKUtextBoxX, 1, 3);
            this.tableLayoutPanel1.Controls.Add(labelX1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(labelX3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.vendedorLabelX, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.clienteLabelX, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX12, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.folioVentaLabelX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(labelX14, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxX1, 4, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(919, 144);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // SKUtextBoxX
            // 
            this.SKUtextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SKUtextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.SKUtextBoxX.Border.Class = "TextBoxBorder";
            this.SKUtextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SKUtextBoxX.ForeColor = System.Drawing.Color.Black;
            this.highlighter.SetHighlightOnFocus(this.SKUtextBoxX, true);
            this.SKUtextBoxX.Location = new System.Drawing.Point(123, 111);
            this.SKUtextBoxX.Name = "SKUtextBoxX";
            this.SKUtextBoxX.Size = new System.Drawing.Size(326, 25);
            this.SKUtextBoxX.TabIndex = 1;
            this.SKUtextBoxX.WatermarkText = "Código";
            // 
            // vendedorLabelX
            // 
            // 
            // 
            // 
            this.vendedorLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.vendedorLabelX.Location = new System.Drawing.Point(3, 39);
            this.vendedorLabelX.Name = "vendedorLabelX";
            this.vendedorLabelX.Size = new System.Drawing.Size(111, 17);
            this.vendedorLabelX.TabIndex = 3;
            this.vendedorLabelX.Text = "Clave del Cliente:";
            // 
            // clienteLabelX
            // 
            // 
            // 
            // 
            this.clienteLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.clienteLabelX, 4);
            this.clienteLabelX.Location = new System.Drawing.Point(123, 39);
            this.clienteLabelX.Name = "clienteLabelX";
            this.clienteLabelX.Size = new System.Drawing.Size(791, 30);
            this.clienteLabelX.TabIndex = 5;
            this.clienteLabelX.Text = "[MOSTRADOR]";
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(123, 75);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(160, 17);
            this.labelX12.TabIndex = 18;
            this.labelX12.Text = "[VENDEDOR]";
            // 
            // folioVentaLabelX
            // 
            // 
            // 
            // 
            this.folioVentaLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.folioVentaLabelX.Location = new System.Drawing.Point(123, 3);
            this.folioVentaLabelX.Name = "folioVentaLabelX";
            this.folioVentaLabelX.Size = new System.Drawing.Size(160, 17);
            this.folioVentaLabelX.TabIndex = 15;
            this.folioVentaLabelX.Text = "1478565";
            // 
            // textBoxX1
            // 
            this.textBoxX1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.ForeColor = System.Drawing.Color.Black;
            this.highlighter.SetHighlightOnFocus(this.textBoxX1, true);
            this.textBoxX1.Location = new System.Drawing.Point(590, 111);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(326, 25);
            this.textBoxX1.TabIndex = 21;
            this.textBoxX1.WatermarkText = "Cantidad";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.labelX13, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelX15, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelX16, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.labelX17, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.labelX18, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.labelX19, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelX20, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.labelX21, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(724, 600);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(259, 106);
            this.tableLayoutPanel4.TabIndex = 22;
            // 
            // labelX13
            // 
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.labelX13.Location = new System.Drawing.Point(132, 3);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(124, 20);
            this.labelX13.TabIndex = 10;
            this.labelX13.Text = "$0.00";
            this.labelX13.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX15
            // 
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Location = new System.Drawing.Point(132, 29);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(124, 17);
            this.labelX15.TabIndex = 11;
            this.labelX15.Text = "$0.00";
            this.labelX15.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX16
            // 
            // 
            // 
            // 
            this.labelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX16.Location = new System.Drawing.Point(132, 55);
            this.labelX16.Name = "labelX16";
            this.labelX16.Size = new System.Drawing.Size(124, 10);
            this.labelX16.TabIndex = 12;
            this.labelX16.Text = "$0.00";
            this.labelX16.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX17
            // 
            // 
            // 
            // 
            this.labelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX17.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.labelX17.Location = new System.Drawing.Point(132, 81);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(124, 17);
            this.labelX17.TabIndex = 13;
            this.labelX17.Text = "$0.00";
            this.labelX17.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX18
            // 
            // 
            // 
            // 
            this.labelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX18.Location = new System.Drawing.Point(3, 81);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(111, 17);
            this.labelX18.TabIndex = 9;
            this.labelX18.Text = "Total:";
            // 
            // labelX19
            // 
            // 
            // 
            // 
            this.labelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX19.Location = new System.Drawing.Point(3, 3);
            this.labelX19.Name = "labelX19";
            this.labelX19.Size = new System.Drawing.Size(111, 17);
            this.labelX19.TabIndex = 6;
            this.labelX19.Text = "Subtotal:";
            // 
            // labelX20
            // 
            // 
            // 
            // 
            this.labelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX20.Location = new System.Drawing.Point(3, 55);
            this.labelX20.Name = "labelX20";
            this.labelX20.Size = new System.Drawing.Size(111, 17);
            this.labelX20.TabIndex = 8;
            this.labelX20.Text = "Descuento:";
            // 
            // labelX21
            // 
            // 
            // 
            // 
            this.labelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX21.Location = new System.Drawing.Point(3, 29);
            this.labelX21.Name = "labelX21";
            this.labelX21.Size = new System.Drawing.Size(111, 17);
            this.labelX21.TabIndex = 7;
            this.labelX21.Text = "IVA:";
            // 
            // labelX22
            // 
            // 
            // 
            // 
            this.labelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX22.Location = new System.Drawing.Point(250, 712);
            this.labelX22.Name = "labelX22";
            this.labelX22.Size = new System.Drawing.Size(733, 14);
            this.labelX22.TabIndex = 23;
            this.labelX22.Text = "Cero pesos con cero centavos 00/100 M.N.";
            this.labelX22.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // highlighter
            // 
            this.highlighter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // PedidoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelX22);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "PedidoUserControl";
            this.Controls.SetChildIndex(this.statusLabel, 0);
            this.Controls.SetChildIndex(this.titleLabel, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.Controls.SetChildIndex(this.bar1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel4, 0);
            this.Controls.SetChildIndex(this.labelX22, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem agregaProductoButtonItem;
        private DevComponents.DotNetBar.ButtonItem descuentoCredencialButtonItem;
        private DevComponents.DotNetBar.ButtonItem guardarButtonItem;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX SKUtextBoxX;
        private DevComponents.DotNetBar.LabelX vendedorLabelX;
        private DevComponents.DotNetBar.LabelX clienteLabelX;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.LabelX folioVentaLabelX;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.LabelX labelX15;
        private DevComponents.DotNetBar.LabelX labelX16;
        private DevComponents.DotNetBar.LabelX labelX17;
        private DevComponents.DotNetBar.LabelX labelX18;
        private DevComponents.DotNetBar.LabelX labelX19;
        private DevComponents.DotNetBar.LabelX labelX20;
        private DevComponents.DotNetBar.LabelX labelX21;
        private DevComponents.DotNetBar.LabelX labelX22;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
    }
}
