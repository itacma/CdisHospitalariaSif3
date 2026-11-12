namespace SIF.View.Seguridad
{
    partial class PerfilesUserControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerfilesUserControl));
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.UsuarioTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.agregaUsuarioButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel9 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem9 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel10 = new DevComponents.DotNetBar.TabControlPanel();
            this.subrogacionTabItem = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem4 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel5 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem5 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel6 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem6 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel7 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem7 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel8 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem8 = new DevComponents.DotNetBar.TabItem(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.agregaUsuarioButtonItem,
            this.buttonItem1,
            this.buttonItem3});
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(280, 32);
            this.titleLabel.Text = "CATALOGOS\\PRIVILEGIOS";
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
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.SplitterDistance = 81;
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
            // buttonItem3
            // 
            this.buttonItem3.HoverImage = global::SIF.Properties.Resources.BoxNewTool1;
            this.buttonItem3.Image = global::SIF.Properties.Resources.IMPRIMIR;
            this.buttonItem3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Tag = "3";
            this.buttonItem3.Text = "Imprimir\r\n ";
            // 
            // buttonItem5
            // 
            this.buttonItem5.HoverImage = global::SIF.Properties.Resources.BoxNewTool1;
            this.buttonItem5.Image = global::SIF.Properties.Resources.BoxNewTool;
            this.buttonItem5.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "Reserva\r\nApartado";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarButtonX, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.UsuarioTextBoxX, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxX1, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.69231F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.30769F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 81);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel5, 3);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.Controls.Add(this.checkBox1, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 49);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(726, 29);
            this.tableLayoutPanel5.TabIndex = 24;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(64, 21);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Todos";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // buscarButtonX
            // 
            this.buscarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buscarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buscarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buscarButtonX.Location = new System.Drawing.Point(837, 20);
            this.buscarButtonX.Name = "buscarButtonX";
            this.buscarButtonX.Size = new System.Drawing.Size(75, 20);
            this.buscarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buscarButtonX.TabIndex = 1;
            this.buscarButtonX.Text = "Buscar";
            this.buscarButtonX.Click += new System.EventHandler(this.buscarButtonX_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Perfil:";
            // 
            // UsuarioTextBoxX
            // 
            this.UsuarioTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsuarioTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.UsuarioTextBoxX.Border.Class = "TextBoxBorder";
            this.UsuarioTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UsuarioTextBoxX.ButtonCustom.Visible = true;
            this.tableLayoutPanel1.SetColumnSpan(this.UsuarioTextBoxX, 2);
            this.UsuarioTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.UsuarioTextBoxX.Location = new System.Drawing.Point(3, 18);
            this.UsuarioTextBoxX.Name = "UsuarioTextBoxX";
            this.UsuarioTextBoxX.Size = new System.Drawing.Size(360, 25);
            this.UsuarioTextBoxX.TabIndex = 25;
            this.UsuarioTextBoxX.WatermarkText = "Usuario";
            this.UsuarioTextBoxX.ButtonCustomClick += new System.EventHandler(this.SeleccionaArticulo);
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
            this.textBoxX1.ButtonCustom.Visible = true;
            this.textBoxX1.ForeColor = System.Drawing.Color.Black;
            this.textBoxX1.Location = new System.Drawing.Point(369, 18);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(360, 25);
            this.textBoxX1.TabIndex = 26;
            this.textBoxX1.WatermarkText = "Perfil";
            this.textBoxX1.ButtonCustomClick += new System.EventHandler(this.textBoxX1_ButtonCustomClick);
            // 
            // agregaUsuarioButtonItem
            // 
            this.agregaUsuarioButtonItem.HoverImage = global::SIF.Properties.Resources.TableContentsTool1;
            this.agregaUsuarioButtonItem.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.agregaUsuarioButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.agregaUsuarioButtonItem.Name = "agregaUsuarioButtonItem";
            this.agregaUsuarioButtonItem.Text = "Usuario \r\n[F4]";
            this.agregaUsuarioButtonItem.Click += new System.EventHandler(this.SeleccionaArticulo);
            // 
            // buttonItem1
            // 
            this.buttonItem1.HoverImage = global::SIF.Properties.Resources.TableContentsTool1;
            this.buttonItem1.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.buttonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "Perfil \r\n[F3]";
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.Transparent;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel9);
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Controls.Add(this.tabControlPanel10);
            this.tabControl1.Controls.Add(this.tabControlPanel4);
            this.tabControl1.Controls.Add(this.tabControlPanel5);
            this.tabControl1.Controls.Add(this.tabControlPanel6);
            this.tabControl1.Controls.Add(this.tabControlPanel7);
            this.tabControl1.Controls.Add(this.tabControlPanel8);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ForeColor = System.Drawing.Color.Black;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 1;
            this.tabControl1.Size = new System.Drawing.Size(915, 483);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Metro;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Tabs.Add(this.tabItem3);
            this.tabControl1.Tabs.Add(this.tabItem4);
            this.tabControl1.Tabs.Add(this.tabItem5);
            this.tabControl1.Tabs.Add(this.tabItem6);
            this.tabControl1.Tabs.Add(this.tabItem7);
            this.tabControl1.Tabs.Add(this.tabItem8);
            this.tabControl1.Tabs.Add(this.tabItem9);
            this.tabControl1.Tabs.Add(this.subrogacionTabItem);
            this.tabControl1.Text = "Compras";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.AutoScroll = true;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(915, 456);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "Ventas";
            // 
            // tabControlPanel9
            // 
            this.tabControlPanel9.AutoScroll = true;
            this.tabControlPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel9.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel9.Name = "tabControlPanel9";
            this.tabControlPanel9.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel9.Size = new System.Drawing.Size(915, 456);
            this.tabControlPanel9.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel9.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel9.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel9.Style.GradientAngle = 90;
            this.tabControlPanel9.TabIndex = 9;
            this.tabControlPanel9.TabItem = this.tabItem9;
            // 
            // tabItem9
            // 
            this.tabItem9.AttachedControl = this.tabControlPanel9;
            this.tabItem9.Name = "tabItem9";
            this.tabItem9.Text = "Seguridad";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.AutoScroll = true;
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(915, 456);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 3;
            this.tabControlPanel3.TabItem = this.tabItem3;
            // 
            // tabItem3
            // 
            this.tabItem3.AttachedControl = this.tabControlPanel3;
            this.tabItem3.Name = "tabItem3";
            this.tabItem3.Text = "Almacen";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.AutoScroll = true;
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(915, 456);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "Compras";
            // 
            // tabControlPanel10
            // 
            this.tabControlPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel10.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel10.Name = "tabControlPanel10";
            this.tabControlPanel10.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel10.Size = new System.Drawing.Size(915, 456);
            this.tabControlPanel10.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel10.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel10.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel10.Style.GradientAngle = 90;
            this.tabControlPanel10.TabIndex = 10;
            this.tabControlPanel10.TabItem = this.subrogacionTabItem;
            // 
            // subrogacionTabItem
            // 
            this.subrogacionTabItem.AttachedControl = this.tabControlPanel10;
            this.subrogacionTabItem.Name = "subrogacionTabItem";
            this.subrogacionTabItem.Text = "Subrogación";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.AutoScroll = true;
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(915, 456);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 4;
            this.tabControlPanel4.TabItem = this.tabItem4;
            // 
            // tabItem4
            // 
            this.tabItem4.AttachedControl = this.tabControlPanel4;
            this.tabItem4.Name = "tabItem4";
            this.tabItem4.Text = "CAC Center";
            // 
            // tabControlPanel5
            // 
            this.tabControlPanel5.AutoScroll = true;
            this.tabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel5.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel5.Name = "tabControlPanel5";
            this.tabControlPanel5.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel5.Size = new System.Drawing.Size(915, 456);
            this.tabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel5.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel5.Style.GradientAngle = 90;
            this.tabControlPanel5.TabIndex = 5;
            this.tabControlPanel5.TabItem = this.tabItem5;
            // 
            // tabItem5
            // 
            this.tabItem5.AttachedControl = this.tabControlPanel5;
            this.tabItem5.Name = "tabItem5";
            this.tabItem5.Text = "Inventario";
            // 
            // tabControlPanel6
            // 
            this.tabControlPanel6.AutoScroll = true;
            this.tabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel6.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel6.Name = "tabControlPanel6";
            this.tabControlPanel6.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel6.Size = new System.Drawing.Size(915, 456);
            this.tabControlPanel6.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel6.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel6.Style.GradientAngle = 90;
            this.tabControlPanel6.TabIndex = 6;
            this.tabControlPanel6.TabItem = this.tabItem6;
            // 
            // tabItem6
            // 
            this.tabItem6.AttachedControl = this.tabControlPanel6;
            this.tabItem6.Name = "tabItem6";
            this.tabItem6.Text = "Configuración";
            // 
            // tabControlPanel7
            // 
            this.tabControlPanel7.AutoScroll = true;
            this.tabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel7.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel7.Name = "tabControlPanel7";
            this.tabControlPanel7.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel7.Size = new System.Drawing.Size(915, 456);
            this.tabControlPanel7.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel7.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel7.Style.GradientAngle = 90;
            this.tabControlPanel7.TabIndex = 7;
            this.tabControlPanel7.TabItem = this.tabItem7;
            // 
            // tabItem7
            // 
            this.tabItem7.AttachedControl = this.tabControlPanel7;
            this.tabItem7.Name = "tabItem7";
            this.tabItem7.Text = "Caja";
            // 
            // tabControlPanel8
            // 
            this.tabControlPanel8.AutoScroll = true;
            this.tabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel8.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel8.Name = "tabControlPanel8";
            this.tabControlPanel8.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel8.Size = new System.Drawing.Size(915, 456);
            this.tabControlPanel8.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel8.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel8.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel8.Style.GradientAngle = 90;
            this.tabControlPanel8.TabIndex = 8;
            this.tabControlPanel8.TabItem = this.tabItem8;
            // 
            // tabItem8
            // 
            this.tabItem8.AttachedControl = this.tabControlPanel8;
            this.tabItem8.Name = "tabItem8";
            this.tabItem8.Text = "Controlados";
            // 
            // PerfilesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "PerfilesUserControl";
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private DevComponents.DotNetBar.Controls.TextBoxX UsuarioTextBoxX;
        private DevComponents.DotNetBar.ButtonItem agregaUsuarioButtonItem;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private System.Windows.Forms.CheckBox checkBox1;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel9;
        private DevComponents.DotNetBar.TabItem tabItem9;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel8;
        private DevComponents.DotNetBar.TabItem tabItem8;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel6;
        private DevComponents.DotNetBar.TabItem tabItem6;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel5;
        private DevComponents.DotNetBar.TabItem tabItem5;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private DevComponents.DotNetBar.TabItem tabItem4;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.TabItem tabItem3;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel7;
        private DevComponents.DotNetBar.TabItem tabItem7;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel10;
        private DevComponents.DotNetBar.TabItem subrogacionTabItem;
    }
}
