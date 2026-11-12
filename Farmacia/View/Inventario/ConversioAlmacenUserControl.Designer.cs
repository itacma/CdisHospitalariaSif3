namespace SIF.View.Inventario
{
    partial class ConversioAlmacenUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConversioAlmacenUserControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX82 = new DevComponents.DotNetBar.LabelX();
            this.foliotextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX75 = new DevComponents.DotNetBar.LabelX();
            this.labelX78 = new DevComponents.DotNetBar.LabelX();
            this.ArticuloID = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.comboItem10 = new DevComponents.Editors.ComboItem();
            this.labelX77 = new DevComponents.DotNetBar.LabelX();
            this.label2 = new System.Windows.Forms.Label();
            this.cantidadTextBoxX = new DevComponents.Editors.IntegerInput();
            this.cantidadTextBoxXe = new DevComponents.Editors.IntegerInput();
            this.TxtCosto = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ArticuloCon = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem12 = new DevComponents.Editors.ComboItem();
            this.comboItem13 = new DevComponents.Editors.ComboItem();
            this.TxtCostoad = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.descripcionLabel = new System.Windows.Forms.Label();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.guardarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.Grd_Pedido = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadTextBoxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadTextBoxXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Pedido)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.guardarButtonItem});
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(436, 32);
            this.titleLabel.Text = "INVENTARIO\\ CONVERSIONES ALMACEN";
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.56521F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.43478F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 218F));
            this.tableLayoutPanel1.Controls.Add(this.labelX82, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.foliotextBoxX, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX75, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX78, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.ArticuloID, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX77, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cantidadTextBoxX, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.cantidadTextBoxXe, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.TxtCosto, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.ArticuloCon, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.TxtCostoad, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.descripcionLabel, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelX4, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelX2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxX1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelX3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonX1, 6, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelX82
            // 
            this.labelX82.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX82.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX82.ForeColor = System.Drawing.Color.Black;
            this.labelX82.Location = new System.Drawing.Point(552, 3);
            this.labelX82.Name = "labelX82";
            this.labelX82.Size = new System.Drawing.Size(120, 20);
            this.labelX82.TabIndex = 72;
            this.labelX82.Text = "Costo";
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
            this.foliotextBoxX.Location = new System.Drawing.Point(37, 29);
            this.foliotextBoxX.Name = "foliotextBoxX";
            this.foliotextBoxX.Size = new System.Drawing.Size(133, 25);
            this.foliotextBoxX.TabIndex = 6;
            this.foliotextBoxX.Text = "Nuevo";
            // 
            // labelX75
            // 
            this.labelX75.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX75.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX75.ForeColor = System.Drawing.Color.Black;
            this.labelX75.Location = new System.Drawing.Point(37, 3);
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
            this.labelX78.Location = new System.Drawing.Point(450, 3);
            this.labelX78.Name = "labelX78";
            this.labelX78.Size = new System.Drawing.Size(69, 20);
            this.labelX78.TabIndex = 62;
            this.labelX78.Text = "Cantidad";
            // 
            // ArticuloID
            // 
            this.ArticuloID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArticuloID.DisplayMember = "Text";
            this.ArticuloID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ArticuloID.ForeColor = System.Drawing.Color.Black;
            this.ArticuloID.FormattingEnabled = true;
            this.ArticuloID.ItemHeight = 19;
            this.ArticuloID.Items.AddRange(new object[] {
            this.comboItem9,
            this.comboItem10});
            this.ArticuloID.Location = new System.Drawing.Point(176, 29);
            this.ArticuloID.Name = "ArticuloID";
            this.ArticuloID.Size = new System.Drawing.Size(147, 25);
            this.ArticuloID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ArticuloID.TabIndex = 8;
            this.ArticuloID.SelectedIndexChanged += new System.EventHandler(this.ArticuloID_SelectedIndexChanged);
            this.ArticuloID.SelectedValueChanged += new System.EventHandler(this.ArticuloID_SelectedValueChanged);
            this.ArticuloID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArticuloID_KeyDown);
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "ReCargar - Reload";
            // 
            // comboItem10
            // 
            this.comboItem10.Text = "Consulta - Query";
            // 
            // labelX77
            // 
            this.labelX77.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX77.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX77.ForeColor = System.Drawing.Color.Black;
            this.labelX77.Location = new System.Drawing.Point(176, 3);
            this.labelX77.Name = "labelX77";
            this.labelX77.Size = new System.Drawing.Size(69, 20);
            this.labelX77.TabIndex = 60;
            this.labelX77.Text = "Articulo";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 85;
            this.label2.Text = "[DESCRIPCION]";
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
            this.cantidadTextBoxX.Location = new System.Drawing.Point(450, 29);
            this.cantidadTextBoxX.MaxValue = 9999;
            this.cantidadTextBoxX.MinValue = 1;
            this.cantidadTextBoxX.Name = "cantidadTextBoxX";
            this.cantidadTextBoxX.ShowUpDown = true;
            this.cantidadTextBoxX.Size = new System.Drawing.Size(80, 21);
            this.cantidadTextBoxX.TabIndex = 86;
            this.cantidadTextBoxX.Value = 1;
            this.cantidadTextBoxX.ValueChanged += new System.EventHandler(this.cantidadTextBoxX_ValueChanged_1);
            this.cantidadTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cantidadTextBoxX_KeyDown_1);
            // 
            // cantidadTextBoxXe
            // 
            this.cantidadTextBoxXe.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.cantidadTextBoxXe.BackgroundStyle.Class = "DateTimeInputBackground";
            this.cantidadTextBoxXe.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cantidadTextBoxXe.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.cantidadTextBoxXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantidadTextBoxXe.ForeColor = System.Drawing.Color.Black;
            this.cantidadTextBoxXe.Location = new System.Drawing.Point(450, 75);
            this.cantidadTextBoxXe.MaxValue = 9999;
            this.cantidadTextBoxXe.MinValue = 1;
            this.cantidadTextBoxXe.Name = "cantidadTextBoxXe";
            this.cantidadTextBoxXe.ShowUpDown = true;
            this.cantidadTextBoxXe.Size = new System.Drawing.Size(80, 21);
            this.cantidadTextBoxXe.TabIndex = 11;
            this.cantidadTextBoxXe.Value = 1;
            this.cantidadTextBoxXe.ValueChanged += new System.EventHandler(this.cantidadTextBoxX_ValueChanged);
            this.cantidadTextBoxXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cantidadTextBoxX_KeyDown);
            // 
            // TxtCosto
            // 
            this.TxtCosto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCosto.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.TxtCosto.Border.Class = "TextBoxBorder";
            this.TxtCosto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TxtCosto.ForeColor = System.Drawing.Color.Black;
            this.TxtCosto.Location = new System.Drawing.Point(552, 29);
            this.TxtCosto.Name = "TxtCosto";
            this.TxtCosto.Size = new System.Drawing.Size(141, 25);
            this.TxtCosto.TabIndex = 87;
            this.TxtCosto.WatermarkText = "Costo";
            // 
            // ArticuloCon
            // 
            this.ArticuloCon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArticuloCon.DisplayMember = "Text";
            this.ArticuloCon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ArticuloCon.ForeColor = System.Drawing.Color.Black;
            this.ArticuloCon.FormattingEnabled = true;
            this.ArticuloCon.ItemHeight = 19;
            this.ArticuloCon.Items.AddRange(new object[] {
            this.comboItem12,
            this.comboItem13});
            this.ArticuloCon.Location = new System.Drawing.Point(176, 75);
            this.ArticuloCon.Name = "ArticuloCon";
            this.ArticuloCon.Size = new System.Drawing.Size(147, 25);
            this.ArticuloCon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ArticuloCon.TabIndex = 9;
            // 
            // comboItem12
            // 
            this.comboItem12.Text = "ReCargar - Reload";
            // 
            // comboItem13
            // 
            this.comboItem13.Text = "Consulta - Query";
            // 
            // TxtCostoad
            // 
            this.TxtCostoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCostoad.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.TxtCostoad.Border.Class = "TextBoxBorder";
            this.TxtCostoad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TxtCostoad.ForeColor = System.Drawing.Color.Black;
            this.TxtCostoad.Location = new System.Drawing.Point(552, 75);
            this.TxtCostoad.Name = "TxtCostoad";
            this.TxtCostoad.Size = new System.Drawing.Size(141, 25);
            this.TxtCostoad.TabIndex = 81;
            this.TxtCostoad.WatermarkText = "Costo";
            // 
            // descripcionLabel
            // 
            this.descripcionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descripcionLabel.AutoSize = true;
            this.descripcionLabel.Location = new System.Drawing.Point(329, 72);
            this.descripcionLabel.Name = "descripcionLabel";
            this.descripcionLabel.Size = new System.Drawing.Size(115, 17);
            this.descripcionLabel.TabIndex = 77;
            this.descripcionLabel.Text = "[DESCRIPCION]";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(450, 55);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 14);
            this.labelX1.TabIndex = 76;
            this.labelX1.Text = "Cantidad";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(552, 55);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(56, 14);
            this.labelX4.TabIndex = 84;
            this.labelX4.Text = "Costo ";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(176, 55);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(128, 14);
            this.labelX2.TabIndex = 88;
            this.labelX2.Text = "Articulo a Convertir";
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
            this.textBoxX1.Location = new System.Drawing.Point(37, 75);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(133, 25);
            this.textBoxX1.TabIndex = 89;
            this.textBoxX1.WatermarkText = "Dar una referencia";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(37, 55);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(74, 14);
            this.labelX3.TabIndex = 90;
            this.labelX3.Text = "Referencia";
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
            // Grd_Pedido
            // 
            this.Grd_Pedido.AllowUserToAddRows = false;
            this.Grd_Pedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grd_Pedido.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grd_Pedido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.Grd_Pedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grd_Pedido.DefaultCellStyle = dataGridViewCellStyle11;
            this.Grd_Pedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grd_Pedido.EnableHeadersVisualStyles = false;
            this.Grd_Pedido.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.Grd_Pedido.Location = new System.Drawing.Point(0, 0);
            this.Grd_Pedido.Name = "Grd_Pedido";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grd_Pedido.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.Grd_Pedido.Size = new System.Drawing.Size(915, 464);
            this.Grd_Pedido.TabIndex = 6;
            this.Grd_Pedido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grd_Pedido_KeyDown);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(699, 75);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 22);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 91;
            this.buttonX1.Text = "Agregar";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // ConversioAlmacenUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ConversioAlmacenUserControl";
            this.Load += new System.EventHandler(this.PedidoAlmacenUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadTextBoxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadTextBoxXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Pedido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.LabelX labelX78;
        private DevComponents.DotNetBar.LabelX labelX77;
        private DevComponents.DotNetBar.LabelX labelX75;
        private DevComponents.DotNetBar.Controls.TextBoxX foliotextBoxX;
        private DevComponents.DotNetBar.Controls.ComboBoxEx ArticuloID;
        private DevComponents.Editors.ComboItem comboItem9;
        private DevComponents.Editors.ComboItem comboItem10;
        private DevComponents.DotNetBar.Controls.ComboBoxEx ArticuloCon;
        private DevComponents.Editors.ComboItem comboItem12;
        private DevComponents.Editors.ComboItem comboItem13;
        private DevComponents.DotNetBar.LabelX labelX82;
        private System.Windows.Forms.Label descripcionLabel;
        private DevComponents.DotNetBar.ButtonItem guardarButtonItem;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.IntegerInput cantidadTextBoxXe;
        private DevComponents.DotNetBar.Controls.TextBoxX TxtCostoad;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.DataGridViewX Grd_Pedido;
        private System.Windows.Forms.Label label2;
        private DevComponents.Editors.IntegerInput cantidadTextBoxX;
        private DevComponents.DotNetBar.Controls.TextBoxX TxtCosto;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}
