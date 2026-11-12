namespace SIF.View.Subrogacion
{
    partial class ArticulosSubrogacionUserControl
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
            DevComponents.DotNetBar.LabelX labelX1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticulosSubrogacionUserControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NuevoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.eliminarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.importarCatButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.exportarCatButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.CLIENTE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANEXO = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.CODIGOCLI = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.ARTICULO_ID = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.NOMBRE1 = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.NOMBRE2 = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.PRECIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_DESC = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.POR_COSTO = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.POR_DESC_PRECIO = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.TIPO_MEDICAMENTO_CVE = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.LABORATORIO_ID = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.PROVEEDOR_ID = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.U_COMPRA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.U_VENTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_INI = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.FECHA_FIN = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.TIPO_MEDICAMENTO_CLI = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.ACTIVO = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.CODIGOCLI2 = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.SiNoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buscarBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.seleccionaClienteButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_SelectFileXls = new DevComponents.DotNetBar.ButtonX();
            this.ClienteTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.TipoDescSource = new System.Windows.Forms.BindingSource(this.components);
            labelX1 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiNoBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TipoDescSource)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.NuevoButtonItem,
            this.eliminarButtonItem,
            this.seleccionaClienteButtonItem,
            this.importarCatButtonItem,
            this.exportarCatButtonItem
            });
            this.bar1.ItemSpacing = 10;
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(297, 32);
            this.titleLabel.Text = "SUBROGACION\\ARTICULOS";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(64, 144);
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewX1);
            this.splitContainer1.Size = new System.Drawing.Size(915, 577);
            this.splitContainer1.SplitterDistance = 58;
            // 
            // statusLabel
            // 
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.statusLabel.Text = "";
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
            // labelX1
            // 
            labelX1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelX1.AutoSize = true;
            // 
            // 
            // 
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.Location = new System.Drawing.Point(45, 34);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(43, 20);
            labelX1.TabIndex = 27;
            labelX1.Text = "Buscar:";
            // 
            // NuevoButtonItem
            // 
            this.NuevoButtonItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("NuevoButtonItem.HoverImage")));
            this.NuevoButtonItem.Image = ((System.Drawing.Image)(resources.GetObject("NuevoButtonItem.Image")));
            this.NuevoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.NuevoButtonItem.Name = "NuevoButtonItem";
            this.NuevoButtonItem.Tag = "1";
            this.NuevoButtonItem.Text = "Nuevo\r\n[F2]";
            this.NuevoButtonItem.Click += new System.EventHandler(this.NuevoButtonItem_Click);
            // 
            // eliminarButtonItem
            // 
            this.eliminarButtonItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("eliminarButtonItem.HoverImage")));
            this.eliminarButtonItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarButtonItem.Image")));
            this.eliminarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.eliminarButtonItem.Name = "eliminarButtonItem";
            this.eliminarButtonItem.Tag = "6";
            this.eliminarButtonItem.Text = "Eliminar\r\n[F6]";
            this.eliminarButtonItem.Click += new System.EventHandler(this.eliminarButtonItem_Click);
            //
            //
            // 
            // importarCatButtonItem
            // 
            this.importarCatButtonItem.HoverImage = global::SIF.Properties.Resources.UserFindTool1;
            this.importarCatButtonItem.Image = global::SIF.Properties.Resources.UserFindTool;
            this.importarCatButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.importarCatButtonItem.Name = "importarCatButtonItem";
            this.importarCatButtonItem.Tag = "38";
            this.importarCatButtonItem.Text = "Importar\r\n[F7]";
            this.importarCatButtonItem.Click += new System.EventHandler(this.importarCatButtonItem_Click);
            //
            //
            // 
            // exportarCatButtonItem
            // 
            this.exportarCatButtonItem.HoverImage = global::SIF.Properties.Resources.Export1;
            this.exportarCatButtonItem.Image = global::SIF.Properties.Resources.Export;
            this.exportarCatButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.exportarCatButtonItem.Name = "exportarCatButtonItem";
            this.exportarCatButtonItem.Tag = "39";
            this.exportarCatButtonItem.Text = "Exportar";
            this.exportarCatButtonItem.Enabled = true;
            this.exportarCatButtonItem.Click += new System.EventHandler(this.exportarCatButtonItem_Click);
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
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
            this.buscarTextBoxX.ButtonCustom.Image = global::SIF.Properties.Resources.FilterDelete16;
            this.buscarTextBoxX.ButtonCustom.Visible = true;
            this.buscarTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.highlighter1.SetHighlightOnFocus(this.buscarTextBoxX, true);
            this.buscarTextBoxX.Location = new System.Drawing.Point(94, 34);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(736, 25);
            this.buscarTextBoxX.TabIndex = 26;
            this.buscarTextBoxX.WatermarkText = "Buscar";
            this.buscarTextBoxX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buscarTextBoxX_KeyUp);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToOrderColumns = true;
            this.dataGridViewX1.AutoGenerateColumns = false;
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewX1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLIENTE_ID,
            this.ID,
            this.ANEXO,
            this.CODIGOCLI,
            this.ARTICULO_ID,
            this.NOMBRE1,
            this.NOMBRE2,
            this.PRECIO,
            this.TIPO_DESC,
            this.POR_COSTO,
            this.POR_DESC_PRECIO,
            this.TIPO_MEDICAMENTO_CVE,
            this.LABORATORIO_ID,
            this.PROVEEDOR_ID,
            this.U_COMPRA,
            this.U_VENTA,
            this.FECHA_INI,
            this.FECHA_FIN,
            this.TIPO_MEDICAMENTO_CLI,
            this.ACTIVO,
            this.CODIGOCLI2});
            this.dataGridViewX1.DataSource = this.bindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.EnableHeadersVisualStyles = false;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(915, 499);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            this.dataGridViewX1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewX1_CellValidating);
            this.dataGridViewX1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_ColumnHeaderMouseClick);
            this.dataGridViewX1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_RowEnter);
            this.dataGridViewX1.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_RowValidated);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            this.dataGridViewX1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyUp);
            this.dataGridViewX1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewX1_MouseDoubleClick);
            // 
            // CLIENTE_ID
            // 
            this.CLIENTE_ID.DataPropertyName = "CLIENTE_ID";
            this.CLIENTE_ID.HeaderText = "CLIENTE_ID";
            this.CLIENTE_ID.Name = "CLIENTE_ID";
            this.CLIENTE_ID.Visible = false;
            this.CLIENTE_ID.Width = 98;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ID.Width = 45;
            // 
            // ANEXO
            // 
            this.ANEXO.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.ANEXO.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.ANEXO.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ANEXO.DataPropertyName = "ANEXO";
            this.ANEXO.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ANEXO.HeaderText = "ANEXO";
            this.ANEXO.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ANEXO.Name = "ANEXO";
            this.ANEXO.PasswordChar = '\0';
            this.ANEXO.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ANEXO.Text = "";
            this.ANEXO.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.ANEXO.WatermarkColor = System.Drawing.Color.Black;
            this.ANEXO.WatermarkText = "ANEXO";
            this.ANEXO.Width = 76;
            // 
            // CODIGOCLI
            // 
            this.CODIGOCLI.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.CODIGOCLI.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.CODIGOCLI.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CODIGOCLI.DataPropertyName = "CODIGOCLI";
            this.CODIGOCLI.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CODIGOCLI.HeaderText = "CODIGO CLIENTE";
            this.CODIGOCLI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CODIGOCLI.Name = "CODIGOCLI";
            this.CODIGOCLI.PasswordChar = '\0';
            this.CODIGOCLI.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CODIGOCLI.Text = "";
            this.CODIGOCLI.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.CODIGOCLI.WatermarkColor = System.Drawing.Color.Black;
            this.CODIGOCLI.WatermarkText = "CODIGO CLIENTE";
            this.CODIGOCLI.Width = 123;
            // 
            // ARTICULO_ID
            // 
            this.ARTICULO_ID.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.ARTICULO_ID.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.ARTICULO_ID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ARTICULO_ID.ButtonCustom.Visible = true;
            this.ARTICULO_ID.DataPropertyName = "ARTICULO_ID";
            this.ARTICULO_ID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ARTICULO_ID.HeaderText = "CLAVE";
            this.ARTICULO_ID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ARTICULO_ID.Name = "ARTICULO_ID";
            this.ARTICULO_ID.PasswordChar = '\0';
            this.ARTICULO_ID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ARTICULO_ID.Text = "";
            this.ARTICULO_ID.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.ARTICULO_ID.WatermarkColor = System.Drawing.Color.Black;
            this.ARTICULO_ID.WatermarkText = "CLAVE ARTICULO";
            this.ARTICULO_ID.Width = 70;
            // 
            // NOMBRE1
            // 
            this.NOMBRE1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.NOMBRE1.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.NOMBRE1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NOMBRE1.DataPropertyName = "NOMBRE1";
            this.NOMBRE1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NOMBRE1.HeaderText = "NOMBRE1";
            this.NOMBRE1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NOMBRE1.Name = "NOMBRE1";
            this.NOMBRE1.PasswordChar = '\0';
            this.NOMBRE1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NOMBRE1.Text = "";
            this.NOMBRE1.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.NOMBRE1.WatermarkColor = System.Drawing.Color.Black;
            this.NOMBRE1.WatermarkText = "NOMBRE ARTICULO";
            this.NOMBRE1.Width = 94;
            // 
            // NOMBRE2
            // 
            this.NOMBRE2.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.NOMBRE2.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.NOMBRE2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NOMBRE2.DataPropertyName = "NOMBRE2";
            this.NOMBRE2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NOMBRE2.HeaderText = "NOMBRE2";
            this.NOMBRE2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NOMBRE2.Name = "NOMBRE2";
            this.NOMBRE2.PasswordChar = '\0';
            this.NOMBRE2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NOMBRE2.Text = "";
            this.NOMBRE2.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.NOMBRE2.WatermarkColor = System.Drawing.Color.Black;
            this.NOMBRE2.WatermarkText = "NOMBRE 2 ARTICULO";
            this.NOMBRE2.Width = 94;
            // 
            // PRECIO
            // 
            this.PRECIO.DataPropertyName = "PRECIO";
            this.PRECIO.HeaderText = "PRECIO";
            this.PRECIO.Name = "PRECIO";
            this.PRECIO.Width = 76;
            // 
            // TIPO_DESC
            // 
            this.TIPO_DESC.DataPropertyName = "TIPO_DESC";
            this.TIPO_DESC.DropDownHeight = 106;
            this.TIPO_DESC.DropDownWidth = 121;
            this.TIPO_DESC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TIPO_DESC.HeaderText = "TIPO DESCUENTO";
            this.TIPO_DESC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TIPO_DESC.IntegralHeight = false;
            this.TIPO_DESC.ItemHeight = 15;
            this.TIPO_DESC.Name = "TIPO_DESC";
            this.TIPO_DESC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TIPO_DESC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TIPO_DESC.Width = 126;
            // 
            // POR_COSTO
            // 
            // 
            // 
            // 
            this.POR_COSTO.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.POR_COSTO.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.POR_COSTO.DataPropertyName = "POR_COSTO";
            this.POR_COSTO.HeaderText = " % SOBRE COSTO";
            this.POR_COSTO.MaxValue = 100;
            this.POR_COSTO.MinValue = 0;
            this.POR_COSTO.Name = "POR_COSTO";
            this.POR_COSTO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.POR_COSTO.ShowUpDown = true;
            this.POR_COSTO.Width = 125;
            // 
            // POR_DESC_PRECIO
            // 
            // 
            // 
            // 
            this.POR_DESC_PRECIO.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.POR_DESC_PRECIO.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.POR_DESC_PRECIO.DataPropertyName = "POR_DESC_PRECIO";
            this.POR_DESC_PRECIO.HeaderText = "% DESC PRECIO VTA";
            this.POR_DESC_PRECIO.MaxValue = 100;
            this.POR_DESC_PRECIO.MinValue = 0;
            this.POR_DESC_PRECIO.Name = "POR_DESC_PRECIO";
            this.POR_DESC_PRECIO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.POR_DESC_PRECIO.ShowUpDown = true;
            this.POR_DESC_PRECIO.Width = 119;
            // 
            // TIPO_MEDICAMENTO_CVE
            // 
            this.TIPO_MEDICAMENTO_CVE.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.TIPO_MEDICAMENTO_CVE.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.TIPO_MEDICAMENTO_CVE.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TIPO_MEDICAMENTO_CVE.DataPropertyName = "TIPO_MEDICAMENTO_CVE";
            this.TIPO_MEDICAMENTO_CVE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TIPO_MEDICAMENTO_CVE.HeaderText = "TIPO MEDICAMENTO";
            this.TIPO_MEDICAMENTO_CVE.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TIPO_MEDICAMENTO_CVE.Name = "TIPO_MEDICAMENTO_CVE";
            this.TIPO_MEDICAMENTO_CVE.PasswordChar = '\0';
            this.TIPO_MEDICAMENTO_CVE.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TIPO_MEDICAMENTO_CVE.Text = "";
            this.TIPO_MEDICAMENTO_CVE.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.TIPO_MEDICAMENTO_CVE.WatermarkColor = System.Drawing.Color.Black;
            this.TIPO_MEDICAMENTO_CVE.WatermarkText = "TIPO MEDICAMENTO";
            this.TIPO_MEDICAMENTO_CVE.Width = 143;
            // 
            // LABORATORIO_ID
            // 
            this.LABORATORIO_ID.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.LABORATORIO_ID.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.LABORATORIO_ID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LABORATORIO_ID.DataPropertyName = "LABORATORIO_ID";
            this.LABORATORIO_ID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LABORATORIO_ID.HeaderText = "LABORATORIO";
            this.LABORATORIO_ID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LABORATORIO_ID.Name = "LABORATORIO_ID";
            this.LABORATORIO_ID.PasswordChar = '\0';
            this.LABORATORIO_ID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LABORATORIO_ID.Text = "";
            this.LABORATORIO_ID.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.LABORATORIO_ID.WatermarkColor = System.Drawing.Color.Black;
            this.LABORATORIO_ID.WatermarkText = "LABORATORIO";
            this.LABORATORIO_ID.Width = 118;
            // 
            // PROVEEDOR_ID
            // 
            this.PROVEEDOR_ID.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.PROVEEDOR_ID.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.PROVEEDOR_ID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PROVEEDOR_ID.DataPropertyName = "PROVEEDOR_ID";
            this.PROVEEDOR_ID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PROVEEDOR_ID.HeaderText = "PROVEEDOR";
            this.PROVEEDOR_ID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PROVEEDOR_ID.Name = "PROVEEDOR_ID";
            this.PROVEEDOR_ID.PasswordChar = '\0';
            this.PROVEEDOR_ID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PROVEEDOR_ID.Text = "";
            this.PROVEEDOR_ID.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.PROVEEDOR_ID.WatermarkColor = System.Drawing.Color.Black;
            this.PROVEEDOR_ID.WatermarkText = "PROVEEDOR";
            this.PROVEEDOR_ID.Width = 107;
            // 
            // U_COMPRA
            // 
            this.U_COMPRA.DataPropertyName = "U_COMPRA";
            this.U_COMPRA.HeaderText = "U_COMPRA";
            this.U_COMPRA.Name = "U_COMPRA";
            this.U_COMPRA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // U_VENTA
            // 
            this.U_VENTA.DataPropertyName = "U_VENTA";
            this.U_VENTA.HeaderText = "U_VENTA";
            this.U_VENTA.Name = "U_VENTA";
            this.U_VENTA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.U_VENTA.Width = 87;
            // 
            // FECHA_INI
            // 
            // 
            // 
            // 
            this.FECHA_INI.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.FECHA_INI.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA_INI.DataPropertyName = "FECHA_INI";
            this.FECHA_INI.HeaderText = "FECHA_INI";
            this.FECHA_INI.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.FECHA_INI.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FECHA_INI.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA_INI.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.FECHA_INI.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA_INI.MonthCalendar.DisplayMonth = new System.DateTime(2013, 3, 1, 0, 0, 0, 0);
            this.FECHA_INI.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.FECHA_INI.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FECHA_INI.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA_INI.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.FECHA_INI.Name = "FECHA_INI";
            this.FECHA_INI.ShowUpDown = true;
            this.FECHA_INI.Width = 92;
            // 
            // FECHA_FIN
            // 
            // 
            // 
            // 
            this.FECHA_FIN.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.FECHA_FIN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA_FIN.DataPropertyName = "FECHA_FIN";
            this.FECHA_FIN.HeaderText = "FECHA_FIN";
            this.FECHA_FIN.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.FECHA_FIN.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FECHA_FIN.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA_FIN.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.FECHA_FIN.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA_FIN.MonthCalendar.DisplayMonth = new System.DateTime(2013, 3, 1, 0, 0, 0, 0);
            this.FECHA_FIN.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.FECHA_FIN.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FECHA_FIN.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA_FIN.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.FECHA_FIN.Name = "FECHA_FIN";
            this.FECHA_FIN.ShowUpDown = true;
            this.FECHA_FIN.Width = 95;
            // 
            // TIPO_MEDICAMENTO_CLI
            // 
            this.TIPO_MEDICAMENTO_CLI.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.TIPO_MEDICAMENTO_CLI.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.TIPO_MEDICAMENTO_CLI.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TIPO_MEDICAMENTO_CLI.DataPropertyName = "TIPO_MEDICAMENTO_CLI";
            this.TIPO_MEDICAMENTO_CLI.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TIPO_MEDICAMENTO_CLI.HeaderText = "TIPO_MEDICAMENTO_CLI";
            this.TIPO_MEDICAMENTO_CLI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TIPO_MEDICAMENTO_CLI.Name = "TIPO_MEDICAMENTO_CLI";
            this.TIPO_MEDICAMENTO_CLI.PasswordChar = '\0';
            this.TIPO_MEDICAMENTO_CLI.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TIPO_MEDICAMENTO_CLI.Text = "";
            this.TIPO_MEDICAMENTO_CLI.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.TIPO_MEDICAMENTO_CLI.WatermarkColor = System.Drawing.Color.Black;
            this.TIPO_MEDICAMENTO_CLI.WatermarkText = "TIPO MEDICAMENTO CLIENTE";
            this.TIPO_MEDICAMENTO_CLI.Width = 180;
            // 
            // ACTIVO
            // 
            this.ACTIVO.DataPropertyName = "ACTIVO";
            this.ACTIVO.DropDownHeight = 106;
            this.ACTIVO.DropDownWidth = 121;
            this.ACTIVO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ACTIVO.HeaderText = "ACTIVO";
            this.ACTIVO.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ACTIVO.IntegralHeight = false;
            this.ACTIVO.ItemHeight = 15;
            this.ACTIVO.Name = "ACTIVO";
            this.ACTIVO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ACTIVO.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ACTIVO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ACTIVO.Width = 58;
            // 
            // CODIGOCLI2
            // 
            this.CODIGOCLI2.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.CODIGOCLI2.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.CODIGOCLI2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CODIGOCLI2.DataPropertyName = "CODIGOCLI2";
            this.CODIGOCLI2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CODIGOCLI2.HeaderText = "CODIGO CLIENTE 2";
            this.CODIGOCLI2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CODIGOCLI2.Name = "CODIGOCLI2";
            this.CODIGOCLI2.PasswordChar = '\0';
            this.CODIGOCLI2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CODIGOCLI2.Text = "";
            this.CODIGOCLI2.Width = 132;
            // 
            // buscarBackgroundWorker
            // 
            this.buscarBackgroundWorker.WorkerReportsProgress = true;
            this.buscarBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.buscarBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // seleccionaClienteButtonItem
            // 
            this.seleccionaClienteButtonItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("seleccionaClienteButtonItem.HoverImage")));
            this.seleccionaClienteButtonItem.Image = ((System.Drawing.Image)(resources.GetObject("seleccionaClienteButtonItem.Image")));
            this.seleccionaClienteButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.seleccionaClienteButtonItem.Name = "seleccionaClienteButtonItem";
            this.seleccionaClienteButtonItem.Tag = "38";
            this.seleccionaClienteButtonItem.Text = "Cliente\r\n[F3]";
            this.seleccionaClienteButtonItem.Click += new System.EventHandler(this.seleccionaClienteButtonItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.05464F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.20219F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.852459F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_SelectFileXls, 3, 0);
            this.tableLayoutPanel1.Controls.Add(labelX1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ClienteTextBoxX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarButtonX, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buscarTextBoxX, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 58);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btn_SelectFileXls
            // 
            this.btn_SelectFileXls.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_SelectFileXls.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_SelectFileXls.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_SelectFileXls.Image = ((System.Drawing.Image)(resources.GetObject("btn_SelectFileXls.Image")));
            this.btn_SelectFileXls.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_SelectFileXls.Location = new System.Drawing.Point(836, 5);
            this.btn_SelectFileXls.Name = "btn_SelectFileXls";
            this.btn_SelectFileXls.Size = new System.Drawing.Size(76, 21);
            this.btn_SelectFileXls.TabIndex = 103;
            this.btn_SelectFileXls.Click += new System.EventHandler(this.btn_SelectFileXls_Click);
            // 
            // ClienteTextBoxX
            // 
            this.ClienteTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ClienteTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.ClienteTextBoxX.Border.Class = "TextBoxBorder";
            this.ClienteTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ClienteTextBoxX.ButtonCustom.Visible = true;
            this.ClienteTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.ClienteTextBoxX.Location = new System.Drawing.Point(94, 3);
            this.ClienteTextBoxX.Name = "ClienteTextBoxX";
            this.ClienteTextBoxX.Size = new System.Drawing.Size(736, 25);
            this.ClienteTextBoxX.TabIndex = 25;
            this.ClienteTextBoxX.WatermarkText = "Cliente";
            this.ClienteTextBoxX.ButtonCustomClick += new System.EventHandler(this.ClienteTextBoxX_ButtonCustomClick);
            this.ClienteTextBoxX.TextChanged += new System.EventHandler(this.ClienteTextBoxX_TextChanged);
            // 
            // buscarButtonX
            // 
            this.buscarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buscarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buscarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buscarButtonX.Location = new System.Drawing.Point(836, 34);
            this.buscarButtonX.Name = "buscarButtonX";
            this.buscarButtonX.Size = new System.Drawing.Size(75, 20);
            this.buscarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buscarButtonX.TabIndex = 1;
            this.buscarButtonX.Text = "Buscar";
            this.buscarButtonX.Click += new System.EventHandler(this.buscarButtonX_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cliente:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ArticulosSubrogacionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ArticulosSubrogacionUserControl";
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiNoBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TipoDescSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem NuevoButtonItem;
        private DevComponents.DotNetBar.ButtonItem eliminarButtonItem;
        private DevComponents.DotNetBar.ButtonItem importarCatButtonItem;
        private DevComponents.DotNetBar.ButtonItem exportarCatButtonItem;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.ComponentModel.BackgroundWorker buscarBackgroundWorker;
        private DevComponents.DotNetBar.ButtonItem seleccionaClienteButtonItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX ClienteTextBoxX;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private System.Windows.Forms.BindingSource SiNoBindingSource;
        private System.Windows.Forms.BindingSource TipoDescSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLIENTE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn ANEXO;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn CODIGOCLI;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn ARTICULO_ID;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn NOMBRE1;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn NOMBRE2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIO;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn TIPO_DESC;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn POR_COSTO;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn POR_DESC_PRECIO;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn TIPO_MEDICAMENTO_CVE;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn LABORATORIO_ID;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn PROVEEDOR_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn U_COMPRA;
        private System.Windows.Forms.DataGridViewTextBoxColumn U_VENTA;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn FECHA_INI;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn FECHA_FIN;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn TIPO_MEDICAMENTO_CLI;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn ACTIVO;
        private DevComponents.DotNetBar.ButtonX btn_SelectFileXls;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn CODIGOCLI2;
    }
}
