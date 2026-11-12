namespace SIF.View.Ventas
{
    partial class PagoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.titleLabel = new System.Windows.Forms.Label();
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            this.tipoPagoComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.tipoPagoFacturaComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.aceptarButton = new DevComponents.DotNetBar.ButtonX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.TipoPagoColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ImporteColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ComisionColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.NumCuentaColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.agregarPagoButtonX = new DevComponents.DotNetBar.ButtonX();
            this.bancoComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.bancoLabel = new System.Windows.Forms.Label();
            this.numCuentaTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.numCuentaLabel = new System.Windows.Forms.Label();
            this.pagoTextBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.importeLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.ComisionLabel = new System.Windows.Forms.Label();
            this.descuentoLabel = new System.Windows.Forms.Label();
            this.impuestosLabel = new System.Windows.Forms.Label();
            this.cambioLabel = new System.Windows.Forms.Label();
            this.fechaVentaLabel = new System.Windows.Forms.Label();
            this.folioLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.formaPagoFacturalabel = new System.Windows.Forms.Label();
            this.numeroCuentaPagolabel = new System.Windows.Forms.Label();
            this.numeroCuentaFacturaTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.datosClienteButtonX = new DevComponents.DotNetBar.ButtonX();
            label5 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.Color.White;
            label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.ForeColor = System.Drawing.Color.Black;
            label5.Location = new System.Drawing.Point(370, 98);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(103, 21);
            label5.TabIndex = 3;
            label5.Text = "Total a Pagar:";
            // 
            // label10
            // 
            label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label10.AutoSize = true;
            label10.BackColor = System.Drawing.Color.White;
            label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.ForeColor = System.Drawing.Color.Black;
            label10.Location = new System.Drawing.Point(370, 36);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(98, 21);
            label10.TabIndex = 16;
            label10.Text = "Por Liquidar:";
            // 
            // label15
            // 
            label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label15.AutoSize = true;
            label15.BackColor = System.Drawing.Color.White;
            label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label15.ForeColor = System.Drawing.Color.Black;
            label15.Location = new System.Drawing.Point(370, 5);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(59, 21);
            label15.TabIndex = 16;
            label15.Text = "TOTAL:";
            // 
            // label14
            // 
            label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label14.AutoSize = true;
            label14.BackColor = System.Drawing.Color.White;
            label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label14.ForeColor = System.Drawing.Color.Black;
            label14.Location = new System.Drawing.Point(3, 67);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(79, 21);
            label14.TabIndex = 13;
            label14.Text = "Comisión:";
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.White;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Location = new System.Drawing.Point(3, 98);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(86, 21);
            label1.TabIndex = 13;
            label1.Text = "Descuento:";
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.White;
            label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.ForeColor = System.Drawing.Color.Black;
            label4.Location = new System.Drawing.Point(3, 129);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(85, 21);
            label4.TabIndex = 2;
            label4.Text = "Impuestos:";
            // 
            // label6
            // 
            label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            label6.AutoSize = true;
            label6.BackColor = System.Drawing.Color.White;
            label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.ForeColor = System.Drawing.Color.Black;
            label6.Location = new System.Drawing.Point(3, 160);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(151, 21);
            label6.TabIndex = 4;
            label6.Text = "Cambio Propuesto:";
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.White;
            label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.ForeColor = System.Drawing.Color.Black;
            label3.Location = new System.Drawing.Point(3, 36);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(91, 21);
            label3.TabIndex = 1;
            label3.Text = "Fecha Nota:";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.White;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ForeColor = System.Drawing.Color.Black;
            label2.Location = new System.Drawing.Point(3, 5);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 21);
            label2.TabIndex = 0;
            label2.Text = "Folio:";
            // 
            // label7
            // 
            label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label7.AutoSize = true;
            label7.BackColor = System.Drawing.Color.White;
            label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.ForeColor = System.Drawing.Color.Black;
            label7.Location = new System.Drawing.Point(370, 67);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(118, 21);
            label7.TabIndex = 11;
            label7.Text = "Forma de Pago:";
            // 
            // titleLabel
            // 
            this.titleLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Light", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.titleLabel.ForeColor = System.Drawing.Color.Black;
            this.titleLabel.Location = new System.Drawing.Point(51, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(83, 41);
            this.titleLabel.TabIndex = 14;
            this.titleLabel.Text = "Pago";
            // 
            // highlighter
            // 
            this.highlighter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // tipoPagoComboBoxEx
            // 
            this.tipoPagoComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tipoPagoComboBoxEx.DisplayMember = "Text";
            this.tipoPagoComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tipoPagoComboBoxEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoPagoComboBoxEx.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoPagoComboBoxEx.FormattingEnabled = true;
            this.highlighter.SetHighlightOnFocus(this.tipoPagoComboBoxEx, true);
            this.tipoPagoComboBoxEx.ItemHeight = 23;
            this.tipoPagoComboBoxEx.Location = new System.Drawing.Point(500, 65);
            this.tipoPagoComboBoxEx.Name = "tipoPagoComboBoxEx";
            this.tipoPagoComboBoxEx.Size = new System.Drawing.Size(185, 29);
            this.tipoPagoComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tipoPagoComboBoxEx.TabIndex = 1;
            this.tipoPagoComboBoxEx.SelectedIndexChanged += new System.EventHandler(this.tipoPagoComboBoxEx_SelectedIndexChanged);
            this.tipoPagoComboBoxEx.SelectedValueChanged += new System.EventHandler(this.tipoPagoComboBoxEx_SelectedValueChanged);
            this.tipoPagoComboBoxEx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tipoPagoComboBoxEx_KeyDown);
            // 
            // tipoPagoFacturaComboBoxEx
            // 
            this.tipoPagoFacturaComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tipoPagoFacturaComboBoxEx.DisplayMember = "Text";
            this.tipoPagoFacturaComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tipoPagoFacturaComboBoxEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoPagoFacturaComboBoxEx.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoPagoFacturaComboBoxEx.FormattingEnabled = true;
            this.highlighter.SetHighlightOnFocus(this.tipoPagoFacturaComboBoxEx, true);
            this.tipoPagoFacturaComboBoxEx.ItemHeight = 23;
            this.tipoPagoFacturaComboBoxEx.Location = new System.Drawing.Point(379, 487);
            this.tipoPagoFacturaComboBoxEx.Name = "tipoPagoFacturaComboBoxEx";
            this.tipoPagoFacturaComboBoxEx.Size = new System.Drawing.Size(229, 29);
            this.tipoPagoFacturaComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tipoPagoFacturaComboBoxEx.TabIndex = 19;
            this.tipoPagoFacturaComboBoxEx.Visible = false;
            this.tipoPagoFacturaComboBoxEx.SelectedValueChanged += new System.EventHandler(this.tipoPagoFacturaComboBoxEx_SelectedValueChanged);
            // 
            // aceptarButton
            // 
            this.aceptarButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aceptarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.aceptarButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButton.Location = new System.Drawing.Point(617, 519);
            this.aceptarButton.Margin = new System.Windows.Forms.Padding(100, 5, 100, 5);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(129, 30);
            this.aceptarButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButton.TabIndex = 21;
            this.aceptarButton.Text = "A&ceptar";
            this.aceptarButton.TextColor = System.Drawing.Color.White;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click_1);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToOrderColumns = true;
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipoPagoColumn,
            this.ImporteColumn,
            this.ComisionColumn,
            this.NumCuentaColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(58, 281);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.Size = new System.Drawing.Size(688, 198);
            this.dataGridViewX1.TabIndex = 18;
            this.dataGridViewX1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewX1_RowsRemoved);
            // 
            // TipoPagoColumn
            // 
            this.TipoPagoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TipoPagoColumn.DataPropertyName = "TIPO_PAGO_NOMBRE";
            this.TipoPagoColumn.HeaderText = "TIPO PAGO";
            this.TipoPagoColumn.Name = "TipoPagoColumn";
            this.TipoPagoColumn.ReadOnly = true;
            this.TipoPagoColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TipoPagoColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ImporteColumn
            // 
            this.ImporteColumn.DataPropertyName = "IMPORTE";
            this.ImporteColumn.HeaderText = "IMPORTE";
            this.ImporteColumn.Name = "ImporteColumn";
            this.ImporteColumn.ReadOnly = true;
            // 
            // ComisionColumn
            // 
            this.ComisionColumn.DataPropertyName = "COMISION";
            this.ComisionColumn.HeaderText = "COMISION";
            this.ComisionColumn.Name = "ComisionColumn";
            this.ComisionColumn.ReadOnly = true;
            // 
            // NumCuentaColumn
            // 
            this.NumCuentaColumn.DataPropertyName = "NUM_CUENTA";
            this.NumCuentaColumn.HeaderText = "No. CUENTA";
            this.NumCuentaColumn.Name = "NumCuentaColumn";
            this.NumCuentaColumn.ReadOnly = true;
            // 
            // agregarPagoButtonX
            // 
            this.agregarPagoButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.agregarPagoButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.agregarPagoButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.agregarPagoButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.agregarPagoButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregarPagoButtonX.Location = new System.Drawing.Point(583, 191);
            this.agregarPagoButtonX.Margin = new System.Windows.Forms.Padding(5);
            this.agregarPagoButtonX.Name = "agregarPagoButtonX";
            this.agregarPagoButtonX.Size = new System.Drawing.Size(100, 26);
            this.agregarPagoButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.agregarPagoButtonX.TabIndex = 5;
            this.agregarPagoButtonX.Text = "&Agregar";
            this.agregarPagoButtonX.TextColor = System.Drawing.Color.White;
            this.agregarPagoButtonX.Click += new System.EventHandler(this.agregarPagoButtonX_Click);
            // 
            // bancoComboBoxEx
            // 
            this.bancoComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bancoComboBoxEx.DisplayMember = "Text";
            this.bancoComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bancoComboBoxEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bancoComboBoxEx.FormattingEnabled = true;
            this.bancoComboBoxEx.ItemHeight = 23;
            this.bancoComboBoxEx.Location = new System.Drawing.Point(500, 158);
            this.bancoComboBoxEx.Name = "bancoComboBoxEx";
            this.bancoComboBoxEx.Size = new System.Drawing.Size(185, 29);
            this.bancoComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bancoComboBoxEx.TabIndex = 4;
            this.bancoComboBoxEx.Visible = false;
            // 
            // bancoLabel
            // 
            this.bancoLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bancoLabel.AutoSize = true;
            this.bancoLabel.BackColor = System.Drawing.Color.White;
            this.bancoLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bancoLabel.ForeColor = System.Drawing.Color.Black;
            this.bancoLabel.Location = new System.Drawing.Point(370, 160);
            this.bancoLabel.Name = "bancoLabel";
            this.bancoLabel.Size = new System.Drawing.Size(55, 21);
            this.bancoLabel.TabIndex = 19;
            this.bancoLabel.Text = "Banco:";
            this.bancoLabel.Visible = false;
            // 
            // numCuentaTextBoxX
            // 
            this.numCuentaTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numCuentaTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.numCuentaTextBoxX.Border.Class = "TextBoxBorder";
            this.numCuentaTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.numCuentaTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.numCuentaTextBoxX.Location = new System.Drawing.Point(500, 127);
            this.numCuentaTextBoxX.Name = "numCuentaTextBoxX";
            this.numCuentaTextBoxX.Size = new System.Drawing.Size(185, 29);
            this.numCuentaTextBoxX.TabIndex = 3;
            this.numCuentaTextBoxX.Visible = false;
            this.numCuentaTextBoxX.Enter += new System.EventHandler(this.numCuentaTextBoxX_Enter);
            // 
            // numCuentaLabel
            // 
            this.numCuentaLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numCuentaLabel.AutoSize = true;
            this.numCuentaLabel.BackColor = System.Drawing.Color.White;
            this.numCuentaLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCuentaLabel.ForeColor = System.Drawing.Color.Black;
            this.numCuentaLabel.Location = new System.Drawing.Point(370, 129);
            this.numCuentaLabel.Name = "numCuentaLabel";
            this.numCuentaLabel.Size = new System.Drawing.Size(87, 21);
            this.numCuentaLabel.TabIndex = 21;
            this.numCuentaLabel.Text = "No. Cuenta";
            this.numCuentaLabel.Visible = false;
            // 
            // pagoTextBox
            // 
            this.pagoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pagoTextBox.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.pagoTextBox.Border.Class = "TextBoxBorder";
            this.pagoTextBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pagoTextBox.ForeColor = System.Drawing.Color.Black;
            this.pagoTextBox.Location = new System.Drawing.Point(500, 96);
            this.pagoTextBox.Name = "pagoTextBox";
            this.pagoTextBox.Size = new System.Drawing.Size(185, 29);
            this.pagoTextBox.TabIndex = 2;
            this.pagoTextBox.TextChanged += new System.EventHandler(this.pagoTextBox_TextChanged);
            this.pagoTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pagoTextBox_KeyDown);
            // 
            // importeLabel
            // 
            this.importeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.importeLabel.AutoSize = true;
            this.importeLabel.BackColor = System.Drawing.Color.White;
            this.importeLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importeLabel.ForeColor = System.Drawing.Color.Black;
            this.importeLabel.Location = new System.Drawing.Point(500, 36);
            this.importeLabel.Name = "importeLabel";
            this.importeLabel.Size = new System.Drawing.Size(50, 21);
            this.importeLabel.TabIndex = 7;
            this.importeLabel.Text = "$0.00";
            // 
            // totalLabel
            // 
            this.totalLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.totalLabel.AutoSize = true;
            this.totalLabel.BackColor = System.Drawing.Color.White;
            this.totalLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.ForeColor = System.Drawing.Color.Black;
            this.totalLabel.Location = new System.Drawing.Point(500, 3);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(61, 25);
            this.totalLabel.TabIndex = 7;
            this.totalLabel.Text = "$0.00";
            // 
            // ComisionLabel
            // 
            this.ComisionLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ComisionLabel.AutoSize = true;
            this.ComisionLabel.BackColor = System.Drawing.Color.White;
            this.ComisionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComisionLabel.ForeColor = System.Drawing.Color.Black;
            this.ComisionLabel.Location = new System.Drawing.Point(160, 67);
            this.ComisionLabel.Name = "ComisionLabel";
            this.ComisionLabel.Size = new System.Drawing.Size(49, 21);
            this.ComisionLabel.TabIndex = 14;
            this.ComisionLabel.Text = "$0.00";
            // 
            // descuentoLabel
            // 
            this.descuentoLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.descuentoLabel.AutoSize = true;
            this.descuentoLabel.BackColor = System.Drawing.Color.White;
            this.descuentoLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descuentoLabel.ForeColor = System.Drawing.Color.Black;
            this.descuentoLabel.Location = new System.Drawing.Point(160, 98);
            this.descuentoLabel.Name = "descuentoLabel";
            this.descuentoLabel.Size = new System.Drawing.Size(49, 21);
            this.descuentoLabel.TabIndex = 14;
            this.descuentoLabel.Text = "$0.00";
            // 
            // impuestosLabel
            // 
            this.impuestosLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.impuestosLabel.AutoSize = true;
            this.impuestosLabel.BackColor = System.Drawing.Color.White;
            this.impuestosLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.impuestosLabel.ForeColor = System.Drawing.Color.Black;
            this.impuestosLabel.Location = new System.Drawing.Point(160, 129);
            this.impuestosLabel.Name = "impuestosLabel";
            this.impuestosLabel.Size = new System.Drawing.Size(49, 21);
            this.impuestosLabel.TabIndex = 9;
            this.impuestosLabel.Text = "$0.00";
            // 
            // cambioLabel
            // 
            this.cambioLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cambioLabel.AutoSize = true;
            this.cambioLabel.BackColor = System.Drawing.Color.White;
            this.cambioLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cambioLabel.ForeColor = System.Drawing.Color.Black;
            this.cambioLabel.Location = new System.Drawing.Point(160, 158);
            this.cambioLabel.Name = "cambioLabel";
            this.cambioLabel.Size = new System.Drawing.Size(61, 25);
            this.cambioLabel.TabIndex = 17;
            this.cambioLabel.Text = "$0.00";
            // 
            // fechaVentaLabel
            // 
            this.fechaVentaLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fechaVentaLabel.AutoSize = true;
            this.fechaVentaLabel.BackColor = System.Drawing.Color.White;
            this.fechaVentaLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaVentaLabel.ForeColor = System.Drawing.Color.Black;
            this.fechaVentaLabel.Location = new System.Drawing.Point(160, 36);
            this.fechaVentaLabel.Name = "fechaVentaLabel";
            this.fechaVentaLabel.Size = new System.Drawing.Size(158, 21);
            this.fechaVentaLabel.TabIndex = 8;
            this.fechaVentaLabel.Text = "01/01/0001 00:00:00";
            // 
            // folioLabel
            // 
            this.folioLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.folioLabel.AutoSize = true;
            this.folioLabel.BackColor = System.Drawing.Color.White;
            this.folioLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folioLabel.ForeColor = System.Drawing.Color.Black;
            this.folioLabel.Location = new System.Drawing.Point(160, 5);
            this.folioLabel.Name = "folioLabel";
            this.folioLabel.Size = new System.Drawing.Size(19, 21);
            this.folioLabel.TabIndex = 15;
            this.folioLabel.Text = "0";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.folioLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.fechaVentaLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cambioLabel, 1, 5);
            this.tableLayoutPanel1.Controls.Add(label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.impuestosLabel, 1, 4);
            this.tableLayoutPanel1.Controls.Add(label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.descuentoLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(label14, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ComisionLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(label7, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.tipoPagoComboBoxEx, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.totalLabel, 4, 0);
            this.tableLayoutPanel1.Controls.Add(label15, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.importeLabel, 4, 1);
            this.tableLayoutPanel1.Controls.Add(label10, 3, 1);
            this.tableLayoutPanel1.Controls.Add(label5, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.pagoTextBox, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.numCuentaLabel, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.numCuentaTextBoxX, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.bancoLabel, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.bancoComboBoxEx, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.agregarPagoButtonX, 4, 6);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(58, 53);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49834F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49834F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49834F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49834F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50084F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50084F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50167F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(688, 222);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // formaPagoFacturalabel
            // 
            this.formaPagoFacturalabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.formaPagoFacturalabel.AutoSize = true;
            this.formaPagoFacturalabel.BackColor = System.Drawing.Color.White;
            this.formaPagoFacturalabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formaPagoFacturalabel.ForeColor = System.Drawing.Color.Black;
            this.formaPagoFacturalabel.Location = new System.Drawing.Point(61, 492);
            this.formaPagoFacturalabel.Name = "formaPagoFacturalabel";
            this.formaPagoFacturalabel.Size = new System.Drawing.Size(312, 21);
            this.formaPagoFacturalabel.TabIndex = 20;
            this.formaPagoFacturalabel.Text = "Forma de Pago que aparecerá en la Factura:";
            this.formaPagoFacturalabel.Visible = false;
            // 
            // numeroCuentaPagolabel
            // 
            this.numeroCuentaPagolabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numeroCuentaPagolabel.AutoSize = true;
            this.numeroCuentaPagolabel.BackColor = System.Drawing.Color.White;
            this.numeroCuentaPagolabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroCuentaPagolabel.ForeColor = System.Drawing.Color.Black;
            this.numeroCuentaPagolabel.Location = new System.Drawing.Point(231, 528);
            this.numeroCuentaPagolabel.Name = "numeroCuentaPagolabel";
            this.numeroCuentaPagolabel.Size = new System.Drawing.Size(142, 21);
            this.numeroCuentaPagolabel.TabIndex = 21;
            this.numeroCuentaPagolabel.Text = "Número de cuenta:";
            this.numeroCuentaPagolabel.Visible = false;
            // 
            // numeroCuentaFacturaTextBoxX
            // 
            this.numeroCuentaFacturaTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numeroCuentaFacturaTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.numeroCuentaFacturaTextBoxX.Border.Class = "TextBoxBorder";
            this.numeroCuentaFacturaTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.numeroCuentaFacturaTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.numeroCuentaFacturaTextBoxX.Location = new System.Drawing.Point(379, 528);
            this.numeroCuentaFacturaTextBoxX.Name = "numeroCuentaFacturaTextBoxX";
            this.numeroCuentaFacturaTextBoxX.Size = new System.Drawing.Size(229, 22);
            this.numeroCuentaFacturaTextBoxX.TabIndex = 20;
            this.numeroCuentaFacturaTextBoxX.Visible = false;
            // 
            // datosClienteButtonX
            // 
            this.datosClienteButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.datosClienteButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.datosClienteButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.datosClienteButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.datosClienteButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datosClienteButtonX.Location = new System.Drawing.Point(52, 518);
            this.datosClienteButtonX.Margin = new System.Windows.Forms.Padding(5);
            this.datosClienteButtonX.Name = "datosClienteButtonX";
            this.datosClienteButtonX.Size = new System.Drawing.Size(94, 41);
            this.datosClienteButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.datosClienteButtonX.TabIndex = 22;
            this.datosClienteButtonX.Text = "Datos Cliente";
            this.datosClienteButtonX.TextColor = System.Drawing.Color.White;
            this.datosClienteButtonX.Click += new System.EventHandler(this.datosClienteButtonX_Click);
            // 
            // PagoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.datosClienteButtonX);
            this.Controls.Add(this.numeroCuentaPagolabel);
            this.Controls.Add(this.formaPagoFacturalabel);
            this.Controls.Add(this.tipoPagoFacturaComboBoxEx);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.numeroCuentaFacturaTextBoxX);
            this.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PagoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PagoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label titleLabel;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
        private DevComponents.DotNetBar.ButtonX aceptarButton;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX agregarPagoButtonX;
        private DevComponents.DotNetBar.Controls.ComboBoxEx bancoComboBoxEx;
        private System.Windows.Forms.Label bancoLabel;
        private DevComponents.DotNetBar.Controls.TextBoxX numCuentaTextBoxX;
        private System.Windows.Forms.Label numCuentaLabel;
        private DevComponents.DotNetBar.Controls.TextBoxX pagoTextBox;
        private System.Windows.Forms.Label importeLabel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label ComisionLabel;
        private System.Windows.Forms.Label descuentoLabel;
        private System.Windows.Forms.Label impuestosLabel;
        private System.Windows.Forms.Label cambioLabel;
        private System.Windows.Forms.Label fechaVentaLabel;
        private System.Windows.Forms.Label folioLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx tipoPagoComboBoxEx;
        private DevComponents.DotNetBar.Controls.ComboBoxEx tipoPagoFacturaComboBoxEx;
        private System.Windows.Forms.Label formaPagoFacturalabel;
        private System.Windows.Forms.Label numeroCuentaPagolabel;
        private DevComponents.DotNetBar.Controls.TextBoxX numeroCuentaFacturaTextBoxX;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn TipoPagoColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ImporteColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ComisionColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn NumCuentaColumn;
        private DevComponents.DotNetBar.ButtonX datosClienteButtonX;

    }
}