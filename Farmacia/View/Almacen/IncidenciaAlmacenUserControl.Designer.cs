namespace SIF.View.Almacen
{
    partial class IncidenciaAlmacenUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncidenciaAlmacenUserControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Grd_Pedido = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Recibido = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CodigoTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.descripcionLabel = new System.Windows.Forms.Label();
            this.foliotextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX75 = new DevComponents.DotNetBar.LabelX();
            this.labelX78 = new DevComponents.DotNetBar.LabelX();
            this.labelX77 = new DevComponents.DotNetBar.LabelX();
            this.SucursalDestinoComboBox = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem12 = new DevComponents.Editors.ComboItem();
            this.comboItem13 = new DevComponents.Editors.ComboItem();
            this.SucursalOrigenComboBox = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.comboItem10 = new DevComponents.Editors.ComboItem();
            this.labelX80 = new DevComponents.DotNetBar.LabelX();
            this.cantidadTextBoxX = new DevComponents.Editors.IntegerInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.switch_TipoAjuste = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Pedido)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadTextBoxX)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem2});
            this.bar1.Size = new System.Drawing.Size(793, 75);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(270, 32);
            this.titleLabel.Text = "ALMACEN\\ INCIDENCIAS";
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Grd_Pedido);
            // 
            // statusLabel
            // 
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // fotoPictureBox
            // 
            this.fotoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("fotoPictureBox.Image")));
            // 
            // apellidosLabel
            // 
            this.apellidosLabel.Text = "";
            // 
            // nombreLabel
            // 
            this.nombreLabel.Text = "";
            // 
            // Grd_Pedido
            // 
            this.Grd_Pedido.AllowUserToAddRows = false;
            this.Grd_Pedido.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grd_Pedido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grd_Pedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd_Pedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Recibido});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grd_Pedido.DefaultCellStyle = dataGridViewCellStyle2;
            this.Grd_Pedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grd_Pedido.Enabled = false;
            this.Grd_Pedido.EnableHeadersVisualStyles = false;
            this.Grd_Pedido.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.Grd_Pedido.Location = new System.Drawing.Point(0, 0);
            this.Grd_Pedido.Name = "Grd_Pedido";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grd_Pedido.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Grd_Pedido.Size = new System.Drawing.Size(915, 464);
            this.Grd_Pedido.TabIndex = 6;
            this.Grd_Pedido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grd_Pedido_KeyDown);
            // 
            // Recibido
            // 
            // 
            // 
            // 
            this.Recibido.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Recibido.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Recibido.DataPropertyName = "Recibido";
            this.Recibido.HeaderText = "Recibido";
            this.Recibido.Name = "Recibido";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.16216F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.83784F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 353F));
            this.tableLayoutPanel1.Controls.Add(this.CodigoTextBoxX, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.descripcionLabel, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.foliotextBoxX, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX75, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX78, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX77, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.SucursalDestinoComboBox, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.SucursalOrigenComboBox, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX80, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cantidadTextBoxX, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.switch_TipoAjuste, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX2, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 100);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.CodigoTextBoxX.Location = new System.Drawing.Point(29, 75);
            this.CodigoTextBoxX.Name = "CodigoTextBoxX";
            this.CodigoTextBoxX.Size = new System.Drawing.Size(183, 25);
            this.CodigoTextBoxX.TabIndex = 10;
            this.CodigoTextBoxX.Visible = false;
            this.CodigoTextBoxX.WatermarkText = "Código";
            this.CodigoTextBoxX.ButtonCustomClick += new System.EventHandler(this.CodigoTextBoxX_ButtonCustomClick);
            this.CodigoTextBoxX.TextChanged += new System.EventHandler(this.CodigoTextBoxX_TextChanged);
            this.CodigoTextBoxX.Enter += new System.EventHandler(this.CodigoTextBoxX_Enter);
            this.CodigoTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodigoTextBoxX_KeyDown);
            // 
            // descripcionLabel
            // 
            this.descripcionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descripcionLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.descripcionLabel, 2);
            this.descripcionLabel.Location = new System.Drawing.Point(431, 72);
            this.descripcionLabel.Name = "descripcionLabel";
            this.descripcionLabel.Size = new System.Drawing.Size(481, 17);
            this.descripcionLabel.TabIndex = 77;
            this.descripcionLabel.Text = "[DESCRIPCION]";
            this.descripcionLabel.Visible = false;
            // 
            // foliotextBoxX
            // 
            this.foliotextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foliotextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.foliotextBoxX.Border.Class = "TextBoxBorder";
            this.foliotextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.foliotextBoxX.Enabled = false;
            this.foliotextBoxX.ForeColor = System.Drawing.Color.Black;
            this.foliotextBoxX.Location = new System.Drawing.Point(29, 29);
            this.foliotextBoxX.Name = "foliotextBoxX";
            this.foliotextBoxX.Size = new System.Drawing.Size(183, 25);
            this.foliotextBoxX.TabIndex = 6;
            // 
            // labelX75
            // 
            this.labelX75.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX75.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX75.ForeColor = System.Drawing.Color.Black;
            this.labelX75.Location = new System.Drawing.Point(29, 3);
            this.labelX75.Name = "labelX75";
            this.labelX75.Size = new System.Drawing.Size(74, 20);
            this.labelX75.TabIndex = 5;
            this.labelX75.Text = "Folio";
            // 
            // labelX78
            // 
            this.labelX78.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX78.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX78.ForeColor = System.Drawing.Color.Black;
            this.labelX78.Location = new System.Drawing.Point(431, 3);
            this.labelX78.Name = "labelX78";
            this.labelX78.Size = new System.Drawing.Size(69, 20);
            this.labelX78.TabIndex = 62;
            this.labelX78.Text = "Destino";
            // 
            // labelX77
            // 
            this.labelX77.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX77.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX77.ForeColor = System.Drawing.Color.Black;
            this.labelX77.Location = new System.Drawing.Point(244, 3);
            this.labelX77.Name = "labelX77";
            this.labelX77.Size = new System.Drawing.Size(69, 20);
            this.labelX77.TabIndex = 60;
            this.labelX77.Text = "Origen";
            // 
            // SucursalDestinoComboBox
            // 
            this.SucursalDestinoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SucursalDestinoComboBox.DisplayMember = "Text";
            this.SucursalDestinoComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.SucursalDestinoComboBox.Enabled = false;
            this.SucursalDestinoComboBox.ForeColor = System.Drawing.Color.Black;
            this.SucursalDestinoComboBox.FormattingEnabled = true;
            this.SucursalDestinoComboBox.ItemHeight = 19;
            this.SucursalDestinoComboBox.Items.AddRange(new object[] {
            this.comboItem12,
            this.comboItem13});
            this.SucursalDestinoComboBox.Location = new System.Drawing.Point(431, 29);
            this.SucursalDestinoComboBox.Name = "SucursalDestinoComboBox";
            this.SucursalDestinoComboBox.Size = new System.Drawing.Size(127, 25);
            this.SucursalDestinoComboBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SucursalDestinoComboBox.TabIndex = 9;
            // 
            // comboItem12
            // 
            this.comboItem12.Text = "ReCargar - Reload";
            // 
            // comboItem13
            // 
            this.comboItem13.Text = "Consulta - Query";
            // 
            // SucursalOrigenComboBox
            // 
            this.SucursalOrigenComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SucursalOrigenComboBox.DisplayMember = "Text";
            this.SucursalOrigenComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.SucursalOrigenComboBox.Enabled = false;
            this.SucursalOrigenComboBox.ForeColor = System.Drawing.Color.Black;
            this.SucursalOrigenComboBox.FormattingEnabled = true;
            this.SucursalOrigenComboBox.ItemHeight = 19;
            this.SucursalOrigenComboBox.Items.AddRange(new object[] {
            this.comboItem9,
            this.comboItem10});
            this.SucursalOrigenComboBox.Location = new System.Drawing.Point(244, 29);
            this.SucursalOrigenComboBox.Name = "SucursalOrigenComboBox";
            this.SucursalOrigenComboBox.Size = new System.Drawing.Size(181, 25);
            this.SucursalOrigenComboBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SucursalOrigenComboBox.TabIndex = 8;
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "ReCargar - Reload";
            // 
            // comboItem10
            // 
            this.comboItem10.Text = "Consulta - Query";
            // 
            // labelX80
            // 
            this.labelX80.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX80.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX80.ForeColor = System.Drawing.Color.Black;
            this.labelX80.Location = new System.Drawing.Point(29, 55);
            this.labelX80.Name = "labelX80";
            this.labelX80.Size = new System.Drawing.Size(46, 14);
            this.labelX80.TabIndex = 73;
            this.labelX80.Text = "Código";
            this.labelX80.Visible = false;
            // 
            // cantidadTextBoxX
            // 
            this.cantidadTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.cantidadTextBoxX.BackgroundStyle.Class = "DateTimeInputBackground";
            this.cantidadTextBoxX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cantidadTextBoxX.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.cantidadTextBoxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantidadTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.cantidadTextBoxX.Location = new System.Drawing.Point(244, 75);
            this.cantidadTextBoxX.MaxValue = 9999;
            this.cantidadTextBoxX.MinValue = 1;
            this.cantidadTextBoxX.Name = "cantidadTextBoxX";
            this.cantidadTextBoxX.ShowUpDown = true;
            this.cantidadTextBoxX.Size = new System.Drawing.Size(80, 21);
            this.cantidadTextBoxX.TabIndex = 11;
            this.cantidadTextBoxX.Value = 1;
            this.cantidadTextBoxX.Visible = false;
            this.cantidadTextBoxX.ValueChanged += new System.EventHandler(this.cantidadTextBoxX_ValueChanged);
            this.cantidadTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cantidadTextBoxX_KeyDown);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(244, 55);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 14);
            this.labelX1.TabIndex = 76;
            this.labelX1.Text = "Cantidad";
            this.labelX1.Visible = false;
            // 
            // switch_TipoAjuste
            // 
            this.switch_TipoAjuste.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.switch_TipoAjuste.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switch_TipoAjuste.ForeColor = System.Drawing.Color.Black;
            this.switch_TipoAjuste.Location = new System.Drawing.Point(564, 29);
            this.switch_TipoAjuste.Name = "switch_TipoAjuste";
            this.switch_TipoAjuste.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.switch_TipoAjuste.OffText = "ORIGEN";
            this.switch_TipoAjuste.OffTextColor = System.Drawing.Color.White;
            this.switch_TipoAjuste.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.switch_TipoAjuste.OnText = "DESTINO";
            this.switch_TipoAjuste.OnTextColor = System.Drawing.Color.White;
            this.switch_TipoAjuste.Size = new System.Drawing.Size(105, 20);
            this.switch_TipoAjuste.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switch_TipoAjuste.TabIndex = 79;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(564, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(69, 20);
            this.labelX2.TabIndex = 80;
            this.labelX2.Text = "Aplicar a ";
            // 
            // buttonItem2
            // 
            this.buttonItem2.HoverImage = global::SIF.Properties.Resources.BoxNewTool1;
            this.buttonItem2.Image = global::SIF.Properties.Resources.LockInformation;
            this.buttonItem2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "Aplicar";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // IncidenciaAlmacenUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "IncidenciaAlmacenUserControl";
            this.Load += new System.EventHandler(this.PedidoAlmacenUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Pedido)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadTextBoxX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX Grd_Pedido;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.LabelX labelX78;
        private DevComponents.DotNetBar.LabelX labelX77;
        private DevComponents.DotNetBar.LabelX labelX75;
        private DevComponents.DotNetBar.Controls.TextBoxX foliotextBoxX;
        private DevComponents.DotNetBar.Controls.ComboBoxEx SucursalOrigenComboBox;
        private DevComponents.Editors.ComboItem comboItem9;
        private DevComponents.Editors.ComboItem comboItem10;
        private DevComponents.DotNetBar.Controls.ComboBoxEx SucursalDestinoComboBox;
        private DevComponents.Editors.ComboItem comboItem12;
        private DevComponents.Editors.ComboItem comboItem13;
        private DevComponents.DotNetBar.LabelX labelX80;
        private DevComponents.DotNetBar.Controls.TextBoxX CodigoTextBoxX;
        private System.Windows.Forms.Label descripcionLabel;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.IntegerInput cantidadTextBoxX;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn Recibido;
        private DevComponents.DotNetBar.Controls.SwitchButton switch_TipoAjuste;
        private DevComponents.DotNetBar.LabelX labelX2;
    }
}
