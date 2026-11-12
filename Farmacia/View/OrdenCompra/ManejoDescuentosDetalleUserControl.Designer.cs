namespace SIF.View.OrdenCompra
{
    partial class ManejoDescuentosDetalleUserControl
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
            DevComponents.DotNetBar.LabelX labelX1;
            DevComponents.DotNetBar.LabelX labelX2;
            DevComponents.DotNetBar.LabelX labelX3;
            DevComponents.DotNetBar.LabelX labelX4;
            DevComponents.DotNetBar.LabelX labelX5;
            this.agregaProductoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.codigoTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tipoComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.cantidadTextBoxX = new DevComponents.Editors.IntegerInput();
            this.descuentoNumericUpDown = new DevComponents.Editors.IntegerInput();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.cancelarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            labelX3 = new DevComponents.DotNetBar.LabelX();
            labelX4 = new DevComponents.DotNetBar.LabelX();
            labelX5 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadTextBoxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descuentoNumericUpDown)).BeginInit();
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
            this.cancelarButtonItem});
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(272, 32);
            this.titleLabel.Text = "COMPRAS\\DESCUENTOS";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            gridColumn1.DataPropertyName = "ARTICULO_ID";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn1.HeaderText = "ARTICULO";
            gridColumn1.Name = "ARTICULO_IDColumn";
            gridColumn1.Width = 130;
            gridColumn2.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            gridColumn2.DataPropertyName = "NOMBRE1";
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn2.HeaderText = "NOMBRE1";
            gridColumn2.Name = "NOMBRE1Column";
            gridColumn2.Width = 150;
            gridColumn3.DataPropertyName = "DESCUENTO";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn3.HeaderText = "DESCUENTO";
            gridColumn3.Name = "DESCUENTOColumn";
            gridColumn3.Width = 80;
            gridColumn4.DataPropertyName = "APLICADO_A";
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridComboBoxExEditControl);
            gridColumn4.HeaderText = "APLICADO A:";
            gridColumn4.Name = "APLICADO_AColumn";
            gridColumn5.DataPropertyName = "IMPORTE_BENEFICIO";
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            gridColumn5.HeaderText = "IMP BENEFICIO";
            gridColumn5.Name = "IMPORTE_COLUMN";
            gridColumn6.DataPropertyName = "PRECIO_DE_COMPRA";
            gridColumn6.HeaderText = "COSTO";
            gridColumn6.Name = "PRECIO_DE_COMPRAColumn";
            gridColumn7.DataPropertyName = "ACTIVO";
            gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn7.HeaderText = "ACTIVO";
            gridColumn7.Name = "ACTIVOColumn";
            gridColumn7.Width = 60;
            gridColumn8.DataPropertyName = "PRECIO_FARMACIA";
            gridColumn8.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn8.HeaderText = "PRECIO FARMACIA";
            gridColumn8.Name = "PRECIO_FARMACIAColumn";
            gridColumn9.DataPropertyName = "PMP";
            gridColumn9.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn9.HeaderText = "PRECIO MAXIMO";
            gridColumn9.Name = "PMPColumn";
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn7);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn8);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn9);
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(915, 499);
            this.superGridControl1.Text = "";
            this.superGridControl1.EndEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl1_EndEdit);
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.SplitterDistance = 65;
            // 
            // statusLabel
            // 
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // labelX1
            // 
            labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.Location = new System.Drawing.Point(3, 4);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(65, 23);
            labelX1.TabIndex = 0;
            labelX1.Text = "ARTICULO:";
            // 
            // labelX2
            // 
            labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.Location = new System.Drawing.Point(287, 37);
            labelX2.Name = "labelX2";
            labelX2.Size = new System.Drawing.Size(83, 23);
            labelX2.TabIndex = 0;
            labelX2.Text = "GENERAL:";
            // 
            // labelX3
            // 
            labelX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX3.Location = new System.Drawing.Point(287, 4);
            labelX3.Name = "labelX3";
            labelX3.Size = new System.Drawing.Size(83, 23);
            labelX3.TabIndex = 27;
            labelX3.Text = "DESCUENTO:";
            // 
            // labelX4
            // 
            labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX4.Location = new System.Drawing.Point(516, 4);
            labelX4.Name = "labelX4";
            labelX4.Size = new System.Drawing.Size(81, 23);
            labelX4.TabIndex = 28;
            labelX4.Text = "APLICADO A:";
            // 
            // labelX5
            // 
            labelX5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX5.Location = new System.Drawing.Point(516, 37);
            labelX5.Name = "labelX5";
            labelX5.Size = new System.Drawing.Size(81, 23);
            labelX5.TabIndex = 28;
            labelX5.Text = "APLICA:";
            // 
            // agregaProductoButtonItem
            // 
            this.agregaProductoButtonItem.HoverImage = global::SIF.Properties.Resources.TableContentsTool1;
            this.agregaProductoButtonItem.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.agregaProductoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.agregaProductoButtonItem.Name = "agregaProductoButtonItem";
            this.agregaProductoButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.agregaProductoButtonItem.Text = "ARTICULO \r\n[F4]";
            this.agregaProductoButtonItem.Click += new System.EventHandler(this.agregaProductoButtonItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 315F));
            this.tableLayoutPanel1.Controls.Add(labelX4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(labelX3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.codigoTextBoxX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tipoComboBoxEx, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.cantidadTextBoxX, 3, 0);
            this.tableLayoutPanel1.Controls.Add(labelX5, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.descuentoNumericUpDown, 3, 1);
            this.tableLayoutPanel1.Controls.Add(labelX2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxEx1, 5, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 65);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // codigoTextBoxX
            // 
            this.codigoTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.codigoTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.codigoTextBoxX.Border.Class = "TextBoxBorder";
            this.codigoTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.codigoTextBoxX.ButtonCustom.Visible = true;
            this.codigoTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.codigoTextBoxX.Location = new System.Drawing.Point(74, 3);
            this.codigoTextBoxX.Name = "codigoTextBoxX";
            this.codigoTextBoxX.Size = new System.Drawing.Size(207, 25);
            this.codigoTextBoxX.TabIndex = 2;
            this.codigoTextBoxX.ButtonCustomClick += new System.EventHandler(this.codigoTextBoxX_ButtonCustomClick);
            this.codigoTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codigoTextBoxX_KeyDown);
            // 
            // tipoComboBoxEx
            // 
            this.tipoComboBoxEx.DisplayMember = "Text";
            this.tipoComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tipoComboBoxEx.FormattingEnabled = true;
            this.tipoComboBoxEx.ItemHeight = 19;
            this.tipoComboBoxEx.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.tipoComboBoxEx.Location = new System.Drawing.Point(603, 3);
            this.tipoComboBoxEx.Name = "tipoComboBoxEx";
            this.tipoComboBoxEx.Size = new System.Drawing.Size(250, 25);
            this.tipoComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tipoComboBoxEx.TabIndex = 24;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "PMP";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "FLEMING";
            // 
            // cantidadTextBoxX
            // 
            // 
            // 
            // 
            this.cantidadTextBoxX.BackgroundStyle.Class = "DateTimeInputBackground";
            this.cantidadTextBoxX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cantidadTextBoxX.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.cantidadTextBoxX.Location = new System.Drawing.Point(376, 3);
            this.cantidadTextBoxX.MaxValue = 100;
            this.cantidadTextBoxX.MinValue = 1;
            this.cantidadTextBoxX.Name = "cantidadTextBoxX";
            this.cantidadTextBoxX.ShowUpDown = true;
            this.cantidadTextBoxX.Size = new System.Drawing.Size(134, 25);
            this.cantidadTextBoxX.TabIndex = 25;
            this.cantidadTextBoxX.Value = 1;
            // 
            // descuentoNumericUpDown
            // 
            // 
            // 
            // 
            this.descuentoNumericUpDown.BackgroundStyle.Class = "DateTimeInputBackground";
            this.descuentoNumericUpDown.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.descuentoNumericUpDown.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.descuentoNumericUpDown.Location = new System.Drawing.Point(376, 35);
            this.descuentoNumericUpDown.MaxValue = 100;
            this.descuentoNumericUpDown.MinValue = 1;
            this.descuentoNumericUpDown.Name = "descuentoNumericUpDown";
            this.descuentoNumericUpDown.ShowUpDown = true;
            this.descuentoNumericUpDown.Size = new System.Drawing.Size(134, 25);
            this.descuentoNumericUpDown.TabIndex = 26;
            this.descuentoNumericUpDown.Value = 1;
            this.descuentoNumericUpDown.ValueChanged += new System.EventHandler(this.descuentoNumericUpDown_ValueChanged_1);
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 19;
            this.comboBoxEx1.Items.AddRange(new object[] {
            this.comboItem3,
            this.comboItem4});
            this.comboBoxEx1.Location = new System.Drawing.Point(603, 35);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(250, 25);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 24;
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "PMP";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "FLEMING";
            // 
            // cancelarButtonItem
            // 
            this.cancelarButtonItem.HoverImage = global::SIF.Properties.Resources.DeleteBinTool1;
            this.cancelarButtonItem.Image = global::SIF.Properties.Resources.DeleteBinTool;
            this.cancelarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.cancelarButtonItem.Name = "cancelarButtonItem";
            this.cancelarButtonItem.Tag = "29";
            this.cancelarButtonItem.Text = "Cancelar\r\n[F8]";
            this.cancelarButtonItem.Click += new System.EventHandler(this.cancelarButtonItem_Click);
            // 
            // ManejoDescuentosDetalleUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ManejoDescuentosDetalleUserControl";
            this.Load += new System.EventHandler(this.ManejoDescuentosDetalleUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cantidadTextBoxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descuentoNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem agregaProductoButtonItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX codigoTextBoxX;
        private DevComponents.DotNetBar.Controls.ComboBoxEx tipoComboBoxEx;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.IntegerInput cantidadTextBoxX;
        private DevComponents.Editors.IntegerInput descuentoNumericUpDown;
        private DevComponents.DotNetBar.ButtonItem cancelarButtonItem;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
    }
}
