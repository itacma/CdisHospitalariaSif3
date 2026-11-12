namespace SIF.View.Ventas
{
    partial class ApartadoUserControl
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
            DevComponents.DotNetBar.LabelX labelX2;
            DevComponents.DotNetBar.LabelX labelX1;
            DevComponents.DotNetBar.LabelX labelX3;
            DevComponents.DotNetBar.LabelX labelX14;
            DevComponents.DotNetBar.LabelX labelX16;
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.superGridControl2 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.agregaProductoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.descuentoCredencialButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.guardarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.cantidadLetraLabelX = new DevComponents.DotNetBar.LabelX();
            this.SKUtextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.vendedorLabelX = new DevComponents.DotNetBar.LabelX();
            this.clienteLabelX = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.folioVentaLabelX = new DevComponents.DotNetBar.LabelX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.creditoRadioButton = new System.Windows.Forms.RadioButton();
            this.loteCaducidadCheckBox = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            labelX3 = new DevComponents.DotNetBar.LabelX();
            labelX14 = new DevComponents.DotNetBar.LabelX();
            labelX16 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.titleLabel.Size = new System.Drawing.Size(145, 32);
            this.titleLabel.Text = "SIF\\Apartado";
            // 
            // superGridControl1
            // 
            this.superGridControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.superGridControl1.Location = new System.Drawing.Point(25, 89);
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(919, 216);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(64, 145);
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.superGridControl2);
            this.splitContainer1.Size = new System.Drawing.Size(919, 569);
            this.splitContainer1.SplitterDistance = 164;
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
            labelX2.Location = new System.Drawing.Point(3, 65);
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
            labelX1.Location = new System.Drawing.Point(3, 96);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(75, 17);
            labelX1.TabIndex = 0;
            labelX1.Text = "SKU:";
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
            labelX3.Text = "Clave Apartado:";
            // 
            // labelX14
            // 
            // 
            // 
            // 
            labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX14.Location = new System.Drawing.Point(314, 96);
            labelX14.Name = "labelX14";
            labelX14.Size = new System.Drawing.Size(75, 17);
            labelX14.TabIndex = 20;
            labelX14.Text = "Cantidad:";
            // 
            // labelX16
            // 
            // 
            // 
            // 
            labelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX16.Location = new System.Drawing.Point(314, 3);
            labelX16.Name = "labelX16";
            labelX16.Size = new System.Drawing.Size(75, 17);
            labelX16.TabIndex = 23;
            labelX16.Text = "Pago:";
            // 
            // superGridControl2
            // 
            this.superGridControl2.BackColor = System.Drawing.Color.White;
            this.superGridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControl2.ForeColor = System.Drawing.Color.Black;
            this.superGridControl2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.superGridControl2.Location = new System.Drawing.Point(0, 0);
            this.superGridControl2.Name = "superGridControl2";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn1.HeaderText = "SELECT";
            gridColumn1.Name = "";
            gridColumn1.Width = 30;
            gridColumn2.HeaderText = "CODIGO";
            gridColumn2.Name = "";
            gridColumn3.HeaderText = "DESCRIPCION";
            gridColumn3.Name = "";
            gridColumn3.Width = 200;
            gridColumn4.HeaderText = "LINEA";
            gridColumn4.Name = "";
            gridColumn5.HeaderText = "CANTIDAD";
            gridColumn5.Name = "";
            gridColumn6.HeaderText = "PRECIO";
            gridColumn6.Name = "";
            gridColumn7.HeaderText = "DESCUENTO";
            gridColumn7.Name = "";
            gridColumn8.HeaderText = "TOTAL";
            gridColumn8.Name = "";
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn7);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn8);
            this.superGridControl2.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl2.Size = new System.Drawing.Size(919, 385);
            this.superGridControl2.TabIndex = 17;
            this.superGridControl2.Text = "superGridControl2";
            this.superGridControl2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl2_KeyDown);
            // 
            // agregaProductoButtonItem
            // 
            this.agregaProductoButtonItem.HoverImage = global::SIF.Properties.Resources.AddTool1;
            this.agregaProductoButtonItem.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.agregaProductoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.agregaProductoButtonItem.Name = "agregaProductoButtonItem";
            this.agregaProductoButtonItem.Text = "Catálogo\r\nde Productos [F3]";
            // 
            // descuentoCredencialButtonItem
            // 
            this.descuentoCredencialButtonItem.HoverImage = global::SIF.Properties.Resources.IDCardTool1;
            this.descuentoCredencialButtonItem.Image = global::SIF.Properties.Resources.IDCardTool;
            this.descuentoCredencialButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.descuentoCredencialButtonItem.Name = "descuentoCredencialButtonItem";
            this.descuentoCredencialButtonItem.Text = "Descuento\r\nCredencial";
            // 
            // guardarButtonItem
            // 
            this.guardarButtonItem.HoverImage = global::SIF.Properties.Resources.SaveTool1;
            this.guardarButtonItem.Image = global::SIF.Properties.Resources.SaveTool;
            this.guardarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.guardarButtonItem.Name = "guardarButtonItem";
            this.guardarButtonItem.Text = "Guardar\r\n Apartado [F5]";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33629F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33185F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33185F));
            this.tableLayoutPanel1.Controls.Add(this.labelX13, 0, 5);
            this.tableLayoutPanel1.Controls.Add(labelX2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cantidadLetraLabelX, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.SKUtextBoxX, 1, 3);
            this.tableLayoutPanel1.Controls.Add(labelX1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelX8, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX9, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX10, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelX11, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelX7, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelX6, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelX5, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX4, 6, 0);
            this.tableLayoutPanel1.Controls.Add(labelX3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.vendedorLabelX, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.clienteLabelX, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX12, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.folioVentaLabelX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(labelX14, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxX1, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 4, 0);
            this.tableLayoutPanel1.Controls.Add(labelX16, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.loteCaducidadCheckBox, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(919, 164);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // labelX13
            // 
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.labelX13, 7);
            this.labelX13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX13.Location = new System.Drawing.Point(3, 147);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(715, 14);
            this.labelX13.TabIndex = 26;
            this.labelX13.Text = "Apartado con Anticipo de $450";
            // 
            // cantidadLetraLabelX
            // 
            // 
            // 
            // 
            this.cantidadLetraLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.cantidadLetraLabelX, 7);
            this.cantidadLetraLabelX.Location = new System.Drawing.Point(3, 127);
            this.cantidadLetraLabelX.Name = "cantidadLetraLabelX";
            this.cantidadLetraLabelX.Size = new System.Drawing.Size(715, 14);
            this.cantidadLetraLabelX.TabIndex = 14;
            this.cantidadLetraLabelX.Text = "Cero pesos con cero centavos 00/100 M.N.";
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
            this.SKUtextBoxX.Location = new System.Drawing.Point(123, 96);
            this.SKUtextBoxX.Name = "SKUtextBoxX";
            this.SKUtextBoxX.Size = new System.Drawing.Size(170, 25);
            this.SKUtextBoxX.TabIndex = 1;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.labelX8.Location = new System.Drawing.Point(745, 3);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(161, 22);
            this.labelX8.TabIndex = 10;
            this.labelX8.Text = "$0.00";
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(745, 34);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(161, 17);
            this.labelX9.TabIndex = 11;
            this.labelX9.Text = "$0.00";
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(745, 65);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(161, 10);
            this.labelX10.TabIndex = 12;
            this.labelX10.Text = "$0.00";
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.labelX11.Location = new System.Drawing.Point(745, 96);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(161, 17);
            this.labelX11.TabIndex = 13;
            this.labelX11.Text = "$0.00";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(625, 96);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(111, 17);
            this.labelX7.TabIndex = 9;
            this.labelX7.Text = "Total:";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(625, 65);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(111, 17);
            this.labelX6.TabIndex = 8;
            this.labelX6.Text = "Descuento:";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(625, 34);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(111, 17);
            this.labelX5.TabIndex = 7;
            this.labelX5.Text = "IVA:";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(625, 3);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(111, 17);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "Subtotal:";
            // 
            // vendedorLabelX
            // 
            // 
            // 
            // 
            this.vendedorLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.vendedorLabelX.Location = new System.Drawing.Point(3, 34);
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
            this.clienteLabelX.Location = new System.Drawing.Point(123, 34);
            this.clienteLabelX.Name = "clienteLabelX";
            this.clienteLabelX.Size = new System.Drawing.Size(160, 17);
            this.clienteLabelX.TabIndex = 5;
            this.clienteLabelX.Text = "[MOSTRADOR]";
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(123, 65);
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
            this.textBoxX1.Location = new System.Drawing.Point(434, 96);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(170, 25);
            this.textBoxX1.TabIndex = 21;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.radioButton1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.creditoRadioButton, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(434, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(159, 25);
            this.tableLayoutPanel2.TabIndex = 16;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(73, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Contado";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // creditoRadioButton
            // 
            this.creditoRadioButton.AutoSize = true;
            this.creditoRadioButton.Location = new System.Drawing.Point(82, 3);
            this.creditoRadioButton.Name = "creditoRadioButton";
            this.creditoRadioButton.Size = new System.Drawing.Size(69, 19);
            this.creditoRadioButton.TabIndex = 1;
            this.creditoRadioButton.TabStop = true;
            this.creditoRadioButton.Text = "Crédito";
            this.creditoRadioButton.UseVisualStyleBackColor = true;
            // 
            // loteCaducidadCheckBox
            // 
            this.loteCaducidadCheckBox.Location = new System.Drawing.Point(314, 34);
            this.loteCaducidadCheckBox.Name = "loteCaducidadCheckBox";
            this.tableLayoutPanel1.SetRowSpan(this.loteCaducidadCheckBox, 2);
            this.loteCaducidadCheckBox.Size = new System.Drawing.Size(114, 56);
            this.loteCaducidadCheckBox.TabIndex = 24;
            this.loteCaducidadCheckBox.Text = "Requiere Lote y Caducidad";
            this.loteCaducidadCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(434, 34);
            this.checkBox1.Name = "checkBox1";
            this.tableLayoutPanel1.SetRowSpan(this.checkBox1, 2);
            this.checkBox1.Size = new System.Drawing.Size(80, 56);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.Text = "Factura";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // highlighter
            // 
            this.highlighter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // ApartadoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ApartadoUserControl";
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl2;
        private DevComponents.DotNetBar.ButtonItem agregaProductoButtonItem;
        private DevComponents.DotNetBar.ButtonItem descuentoCredencialButtonItem;
        private DevComponents.DotNetBar.ButtonItem guardarButtonItem;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.LabelX cantidadLetraLabelX;
        private DevComponents.DotNetBar.Controls.TextBoxX SKUtextBoxX;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX vendedorLabelX;
        private DevComponents.DotNetBar.LabelX clienteLabelX;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.LabelX folioVentaLabelX;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton creditoRadioButton;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private System.Windows.Forms.CheckBox loteCaducidadCheckBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
    }
}
