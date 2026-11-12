namespace SIF.View.Inventario
{
    partial class AjusteAlmacenUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AjusteAlmacenUserControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            //this.backButton = new DevComponents.DotNetBar.ButtonX();
            //this.bar1 = new DevComponents.DotNetBar.Bar();
            //this.statusLabel = new DevComponents.DotNetBar.LabelX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cantArticulosLabel = new System.Windows.Forms.Label();
            this.labelX82 = new DevComponents.DotNetBar.LabelX();
            this.CodigoTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.foliotextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX75 = new DevComponents.DotNetBar.LabelX();
            this.labelX78 = new DevComponents.DotNetBar.LabelX();
            this.labelX80 = new DevComponents.DotNetBar.LabelX();
            this.SucursalOrigenComboBox = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.comboItem10 = new DevComponents.Editors.ComboItem();
            this.cantidadTextBoxX = new DevComponents.Editors.IntegerInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.totalLabel = new System.Windows.Forms.Label();
            this.labelX77 = new DevComponents.DotNetBar.LabelX();
            this.switch_TipoAjuste = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tb_LotePedido = new DevComponents.Editors.IntegerInput();
            this.SucursalDestinoComboBox = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem12 = new DevComponents.Editors.ComboItem();
            this.comboItem13 = new DevComponents.Editors.ComboItem();
            this.tb_DocRefAjuste = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.descripcionLabel = new System.Windows.Forms.Label();
            this.tb_DescConceptoAjuste = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.Label21 = new System.Windows.Forms.Label();
            this.importarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.ObtenerAjtHup = new DevComponents.DotNetBar.ButtonItem();
            this.guardarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.agregaProductoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.Grd_Pedido = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.devolucionButtonItem = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadTextBoxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_LotePedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Pedido)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.backButton.FadeEffect = false;
            this.backButton.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.Location = new System.Drawing.Point(10, 47);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backButton.Name = "backButton";
            this.backButton.PressedImage = ((System.Drawing.Image)(resources.GetObject("backButton.PressedImage")));
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.backButton.Size = new System.Drawing.Size(48, 48);
            this.backButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.backButton.TabIndex = 14;
            this.backButton.Text = "\r\nRegresar";
            this.backButton.Tooltip = "Regresar [F12]";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "bar1 (bar1)";
            this.bar1.AccessibleName = "bar1";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar1.AntiAlias = true;
            this.bar1.BackColor = System.Drawing.Color.Transparent;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.agregaProductoButtonItem,
            this.guardarButtonItem,
            this.devolucionButtonItem,
            this.importarButtonItem,
            this.ObtenerAjtHup});
            this.bar1.Location = new System.Drawing.Point(64, 44);
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(793, 92);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 15;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(354, 32);
            this.titleLabel.Text = "INVENTARIO\\ AJUSTES ALMACEN";
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
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.statusLabel.Location = new System.Drawing.Point(67, 718);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(912, 30);
            this.statusLabel.TabIndex = 16;
            this.statusLabel.Text = "Status...";
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 231F));
            this.tableLayoutPanel1.Controls.Add(this.cantArticulosLabel, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelX82, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.CodigoTextBoxX, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.foliotextBoxX, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX75, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX78, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX80, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.SucursalOrigenComboBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cantidadTextBoxX, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.totalLabel, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelX77, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.switch_TipoAjuste, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tb_LotePedido, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.SucursalDestinoComboBox, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.tb_DocRefAjuste, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX3, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.descripcionLabel, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.tb_DescConceptoAjuste, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelX4, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.Label21, 5, 2);
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
            // cantArticulosLabel
            // 
            this.cantArticulosLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cantArticulosLabel.AutoSize = true;
            this.cantArticulosLabel.Location = new System.Drawing.Point(687, 72);
            this.cantArticulosLabel.Name = "cantArticulosLabel";
            this.cantArticulosLabel.Size = new System.Drawing.Size(225, 17);
            this.cantArticulosLabel.TabIndex = 78;
            this.cantArticulosLabel.Text = "Articulos: 0";
            // 
            // labelX82
            // 
            this.labelX82.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX82.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX82.ForeColor = System.Drawing.Color.Black;
            this.labelX82.Location = new System.Drawing.Point(540, 3);
            this.labelX82.Name = "labelX82";
            this.labelX82.Size = new System.Drawing.Size(120, 20);
            this.labelX82.TabIndex = 72;
            this.labelX82.Text = "Documento";
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
            this.CodigoTextBoxX.Location = new System.Drawing.Point(3, 75);
            this.CodigoTextBoxX.Name = "CodigoTextBoxX";
            this.CodigoTextBoxX.Size = new System.Drawing.Size(155, 25);
            this.CodigoTextBoxX.TabIndex = 0;
            this.CodigoTextBoxX.WatermarkText = "Código";
            this.CodigoTextBoxX.ButtonCustomClick += new System.EventHandler(this.CodigoTextBoxX_ButtonCustomClick);
            this.CodigoTextBoxX.TextChanged += new System.EventHandler(this.CodigoTextBoxX_TextChanged);
            this.CodigoTextBoxX.Enter += new System.EventHandler(this.CodigoTextBoxX_Enter);
            this.CodigoTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodigoTextBoxX_KeyDown);
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
            this.foliotextBoxX.Location = new System.Drawing.Point(3, 29);
            this.foliotextBoxX.Name = "foliotextBoxX";
            this.foliotextBoxX.Size = new System.Drawing.Size(155, 25);
            this.foliotextBoxX.TabIndex = 3;
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
            this.labelX75.Location = new System.Drawing.Point(3, 3);
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
            this.labelX78.Location = new System.Drawing.Point(438, 3);
            this.labelX78.Name = "labelX78";
            this.labelX78.Size = new System.Drawing.Size(69, 20);
            this.labelX78.TabIndex = 62;
            this.labelX78.Text = "Lote";
            // 
            // labelX80
            // 
            this.labelX80.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX80.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX80.ForeColor = System.Drawing.Color.Black;
            this.labelX80.Location = new System.Drawing.Point(3, 55);
            this.labelX80.Name = "labelX80";
            this.labelX80.Size = new System.Drawing.Size(46, 14);
            this.labelX80.TabIndex = 73;
            this.labelX80.Text = "Código";
            // 
            // SucursalOrigenComboBox
            // 
            this.SucursalOrigenComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SucursalOrigenComboBox.DisplayMember = "Text";
            this.SucursalOrigenComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.SucursalOrigenComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SucursalOrigenComboBox.ForeColor = System.Drawing.Color.Black;
            this.SucursalOrigenComboBox.FormattingEnabled = true;
            this.SucursalOrigenComboBox.ItemHeight = 19;
            this.SucursalOrigenComboBox.Items.AddRange(new object[] {
            this.comboItem9,
            this.comboItem10});
            this.SucursalOrigenComboBox.Location = new System.Drawing.Point(164, 29);
            this.SucursalOrigenComboBox.Name = "SucursalOrigenComboBox";
            this.SucursalOrigenComboBox.Size = new System.Drawing.Size(147, 25);
            this.SucursalOrigenComboBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SucursalOrigenComboBox.TabIndex = 4;
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "ReCargar - Reload";
            // 
            // comboItem10
            // 
            this.comboItem10.Text = "Consulta - Query";
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
            this.cantidadTextBoxX.Location = new System.Drawing.Point(164, 75);
            this.cantidadTextBoxX.MaxValue = 9999;
            this.cantidadTextBoxX.MinValue = 1;
            this.cantidadTextBoxX.Name = "cantidadTextBoxX";
            this.cantidadTextBoxX.ShowUpDown = true;
            this.cantidadTextBoxX.TabIndex = 1;
            this.cantidadTextBoxX.Value = 1;
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
            this.labelX1.Location = new System.Drawing.Point(164, 55);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 14);
            this.labelX1.TabIndex = 76;
            this.labelX1.Text = "Cantidad";
            // 
            // totalLabel
            // 
            this.totalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(897, 52);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(15, 17);
            this.totalLabel.TabIndex = 77;
            this.totalLabel.Text = "0";
            // 
            // labelX77
            // 
            this.labelX77.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX77.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX77.ForeColor = System.Drawing.Color.Black;
            this.labelX77.Location = new System.Drawing.Point(164, 3);
            this.labelX77.Name = "labelX77";
            this.labelX77.Size = new System.Drawing.Size(69, 20);
            this.labelX77.TabIndex = 60;
            this.labelX77.Text = "Origen";
            // 
            // switch_TipoAjuste
            // 
            this.switch_TipoAjuste.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.switch_TipoAjuste.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switch_TipoAjuste.ForeColor = System.Drawing.Color.Black;
            this.switch_TipoAjuste.Location = new System.Drawing.Point(317, 29);
            this.switch_TipoAjuste.Name = "switch_TipoAjuste";
            this.switch_TipoAjuste.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.switch_TipoAjuste.OffText = "ENTRADA";
            this.switch_TipoAjuste.OffTextColor = System.Drawing.Color.White;
            this.switch_TipoAjuste.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.switch_TipoAjuste.OnText = "SALIDA";
            this.switch_TipoAjuste.OnTextColor = System.Drawing.Color.White;
            this.switch_TipoAjuste.Size = new System.Drawing.Size(105, 20);
            this.switch_TipoAjuste.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switch_TipoAjuste.TabIndex = 5;
            this.switch_TipoAjuste.ValueChanged += new System.EventHandler(this.switch_TipoAjuste_ValueChanged);
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(317, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(69, 20);
            this.labelX2.TabIndex = 79;
            this.labelX2.Text = "Tipo";
            // 
            // tb_LotePedido
            // 
            this.tb_LotePedido.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_LotePedido.BackgroundStyle.Class = "DateTimeInputBackground";
            this.tb_LotePedido.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_LotePedido.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.tb_LotePedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_LotePedido.ForeColor = System.Drawing.Color.Black;
            this.tb_LotePedido.Location = new System.Drawing.Point(438, 29);
            this.tb_LotePedido.MaxValue = 9999;
            this.tb_LotePedido.MinValue = 1;
            this.tb_LotePedido.Name = "tb_LotePedido";
            this.tb_LotePedido.ShowUpDown = true;
            this.tb_LotePedido.TabIndex = 6;
            this.tb_LotePedido.Value = 1;
            // 
            // SucursalDestinoComboBox
            // 
            this.SucursalDestinoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SucursalDestinoComboBox.DisplayMember = "Text";
            this.SucursalDestinoComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.SucursalDestinoComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SucursalDestinoComboBox.ForeColor = System.Drawing.Color.Black;
            this.SucursalDestinoComboBox.FormattingEnabled = true;
            this.SucursalDestinoComboBox.ItemHeight = 19;
            this.SucursalDestinoComboBox.Items.AddRange(new object[] {
            this.comboItem12,
            this.comboItem13});
            this.SucursalDestinoComboBox.Location = new System.Drawing.Point(687, 29);
            this.SucursalDestinoComboBox.Name = "SucursalDestinoComboBox";
            this.SucursalDestinoComboBox.Size = new System.Drawing.Size(225, 25);
            this.SucursalDestinoComboBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SucursalDestinoComboBox.TabIndex = 8;
            // 
            // comboItem12
            // 
            this.comboItem12.Text = "ReCargar - Reload";
            // 
            // comboItem13
            // 
            this.comboItem13.Text = "Consulta - Query";
            // 
            // tb_DocRefAjuste
            // 
            this.tb_DocRefAjuste.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_DocRefAjuste.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_DocRefAjuste.Border.Class = "TextBoxBorder";
            this.tb_DocRefAjuste.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_DocRefAjuste.ForeColor = System.Drawing.Color.Black;
            this.tb_DocRefAjuste.Location = new System.Drawing.Point(540, 29);
            this.tb_DocRefAjuste.MaxLength = 25;
            this.tb_DocRefAjuste.Name = "tb_DocRefAjuste";
            this.tb_DocRefAjuste.Size = new System.Drawing.Size(141, 25);
            this.tb_DocRefAjuste.TabIndex = 7;
            this.tb_DocRefAjuste.WatermarkText = "Documento Soporte";
            this.tb_DocRefAjuste.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_DocRefAjuste_KeyDown);
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(687, 3);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(120, 20);
            this.labelX3.TabIndex = 82;
            this.labelX3.Text = "Sucursal Referencia";
            // 
            // descripcionLabel
            // 
            this.descripcionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descripcionLabel.AutoSize = true;
            this.descripcionLabel.Location = new System.Drawing.Point(540, 72);
            this.descripcionLabel.Name = "descripcionLabel";
            this.descripcionLabel.Size = new System.Drawing.Size(141, 17);
            this.descripcionLabel.TabIndex = 77;
            this.descripcionLabel.Text = "[DESCRIPCION]";
            // 
            // tb_DescConceptoAjuste
            // 
            this.tb_DescConceptoAjuste.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_DescConceptoAjuste.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tb_DescConceptoAjuste.Border.Class = "TextBoxBorder";
            this.tb_DescConceptoAjuste.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.tb_DescConceptoAjuste, 2);
            this.tb_DescConceptoAjuste.ForeColor = System.Drawing.Color.Black;
            this.tb_DescConceptoAjuste.Location = new System.Drawing.Point(317, 75);
            this.tb_DescConceptoAjuste.Name = "tb_DescConceptoAjuste";
            this.tb_DescConceptoAjuste.Size = new System.Drawing.Size(217, 25);
            this.tb_DescConceptoAjuste.TabIndex = 2;
            this.tb_DescConceptoAjuste.WatermarkText = "Concepto ajuste articulo";
            this.tb_DescConceptoAjuste.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_DescConceptoAjuste_KeyDown);
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(317, 55);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(56, 14);
            this.labelX4.TabIndex = 84;
            this.labelX4.Text = "Concepto";
            // 
            // Label21
            // 
            this.Label21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label21.AutoSize = true;
            this.Label21.Location = new System.Drawing.Point(540, 52);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(141, 17);
            this.Label21.TabIndex = 77;
            this.Label21.Text = "TOTAL:";
            // 
            // importarButtonItem
            // 
            this.importarButtonItem.HoverImage = global::SIF.Properties.Resources.U_turn1;
            this.importarButtonItem.Image = global::SIF.Properties.Resources.U_turn;
            this.importarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.importarButtonItem.Name = "importarButtonItem";
            this.importarButtonItem.Text = "importar\r\n ";
            this.importarButtonItem.Click += new System.EventHandler(this.importarButtonItem_Click);
            // 
            // ObtenerAjtHup
            // 
            this.ObtenerAjtHup.Enabled = false;
            this.ObtenerAjtHup.HoverImage = global::SIF.Properties.Resources.DUPLICAR;
            this.ObtenerAjtHup.Image = global::SIF.Properties.Resources.DUPLICAR;
            this.ObtenerAjtHup.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.ObtenerAjtHup.Name = "ObtenerAjtHup";
            this.ObtenerAjtHup.Text = "Obtener Ajuste Hup";
            this.ObtenerAjtHup.Click += new System.EventHandler(this.ObtenerAjtHupButtonItem_Click);
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
            // agregaProductoButtonItem
            // 
            this.agregaProductoButtonItem.HoverImage = global::SIF.Properties.Resources.TableContentsTool1;
            this.agregaProductoButtonItem.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.agregaProductoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.agregaProductoButtonItem.Name = "agregaProductoButtonItem";
            this.agregaProductoButtonItem.Text = "Productos \r\n[F4]";
            this.agregaProductoButtonItem.Click += new System.EventHandler(this.agregaProductoButtonItem_Click);
            // 
            // Grd_Pedido
            // 
            this.Grd_Pedido.AllowUserToAddRows = false;
            this.Grd_Pedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grd_Pedido.DefaultCellStyle = dataGridViewCellStyle2;
            this.Grd_Pedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grd_Pedido.EnableHeadersVisualStyles = false;
            this.Grd_Pedido.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
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
            this.Grd_Pedido.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_Pedido_CellEndEdit);
            this.Grd_Pedido.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Grd_Pedido_DataError);
            this.Grd_Pedido.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.Grd_Pedido_RowsRemoved);
            this.Grd_Pedido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grd_Pedido_KeyDown);
            // 
            // devolucionButtonItem
            // 
            this.devolucionButtonItem.HoverImage = global::SIF.Properties.Resources.U_turn1;
            this.devolucionButtonItem.Image = global::SIF.Properties.Resources.U_turn;
            this.devolucionButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.devolucionButtonItem.Name = "devolucionButtonItem";
            this.devolucionButtonItem.Text = "Devolución\r\n ";
            this.devolucionButtonItem.Click += new System.EventHandler(this.devolucionButtonItem_Click);
            // 
            // AjusteAlmacenUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "AjusteAlmacenUserControl";
            this.Load += new System.EventHandler(this.PedidoAlmacenUserControl_Load);
            this.Controls.SetChildIndex(this.nombreLabel, 0);
            this.Controls.SetChildIndex(this.apellidosLabel, 0);
            this.Controls.SetChildIndex(this.fotoPictureBox, 0);
            this.Controls.SetChildIndex(this.sucursalLabel, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadTextBoxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_LotePedido)).EndInit();
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
        private DevComponents.DotNetBar.Controls.ComboBoxEx SucursalOrigenComboBox;
        private DevComponents.Editors.ComboItem comboItem9;
        private DevComponents.Editors.ComboItem comboItem10;
        private DevComponents.DotNetBar.Controls.ComboBoxEx SucursalDestinoComboBox;
        private DevComponents.Editors.ComboItem comboItem12;
        private DevComponents.Editors.ComboItem comboItem13;
        private DevComponents.DotNetBar.LabelX labelX82;
        private DevComponents.DotNetBar.LabelX labelX80;
        private DevComponents.DotNetBar.Controls.TextBoxX CodigoTextBoxX;
        private System.Windows.Forms.Label descripcionLabel;
        private System.Windows.Forms.Label totalLabel;
        private DevComponents.DotNetBar.ButtonItem guardarButtonItem;
        private DevComponents.DotNetBar.ButtonItem agregaProductoButtonItem;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.IntegerInput cantidadTextBoxX;
        private DevComponents.DotNetBar.Controls.SwitchButton switch_TipoAjuste;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.IntegerInput tb_LotePedido;
        private DevComponents.DotNetBar.Controls.TextBoxX tb_DocRefAjuste;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX tb_DescConceptoAjuste;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.DataGridViewX Grd_Pedido;
        private DevComponents.DotNetBar.ButtonItem devolucionButtonItem;
        private System.Windows.Forms.Label Label21;
        private System.Windows.Forms.Label cantArticulosLabel;
        private DevComponents.DotNetBar.ButtonItem importarButtonItem;
        private DevComponents.DotNetBar.ButtonItem ObtenerAjtHupButtonItem;
        //private DevComponents.DotNetBar.ButtonX backButton;
        //private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem ObtenerAjtHup;
        //private DevComponents.DotNetBar.LabelX statusLabel;
    }
}
