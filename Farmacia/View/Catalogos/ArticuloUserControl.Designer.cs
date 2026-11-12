namespace SIF.View.Catalogos
{
    partial class ArticuloUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticuloUserControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();            
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.NuevoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.ImportarPreciosVentaButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.eliminarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.laboratorioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoMedicamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoMonedaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.unidadCompraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.unidadVentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SiNoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buscarBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.proveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.CLAVEColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBREColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE2Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROVEEDOR_IDColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.PROVEEDOR_NOMBREColumn = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.TIPO_MEDICAMENTOColumn = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.LABORATORIO_NOMBREColumn = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.TIPO_MONEDAColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.UNIDAD_COMPRAColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIDAD_VENTAColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACTIVOColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAQUETEColumn = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.LISTA_SUCURSAL_VENTAColumn = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.editarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.preciosButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.existenciasButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.mayoristasButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.transferButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.imprimirButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.catProductosButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.catProductosBajaButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.catArticulosBajaButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.dbtn_AsignarComprador = new DevComponents.DotNetBar.ButtonItem();
            this.bnt_Actualizacion = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laboratorioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMedicamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMonedaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadCompraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadVentaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiNoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.NuevoButtonItem,
            this.eliminarButtonItem,
            this.editarButtonItem,
            this.preciosButtonItem,
            this.existenciasButtonItem,
            this.mayoristasButtonItem,
            this.transferButtonItem,
            this.imprimirButtonItem,
            this.catArticulosBajaButtonItem,
            this.dbtn_AsignarComprador,
            this.bnt_Actualizacion});
            this.bar1.ItemSpacing = 2;
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
            this.titleLabel.Size = new System.Drawing.Size(126, 32);
            this.titleLabel.Text = "SIF\\Articulo";
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
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewX1);
            this.splitContainer1.SplitterDistance = 30;
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
            // labelX1
            // 
            this.labelX1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(43, 20);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Buscar:";
            // 
            // NuevoButtonItem
            // 
            this.NuevoButtonItem.HoverImage = global::SIF.Properties.Resources.NewDocument1;
            this.NuevoButtonItem.Image = global::SIF.Properties.Resources.NewDocument;
            this.NuevoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.NuevoButtonItem.Name = "NuevoButtonItem";
            this.NuevoButtonItem.Tag = "1";
            this.NuevoButtonItem.Text = "Nuevo\r\n[F2]";
            this.NuevoButtonItem.Click += new System.EventHandler(this.NuevoButtonItem_Click);
            // 
            // eliminarButtonItem
            // 
            this.eliminarButtonItem.HoverImage = global::SIF.Properties.Resources.DeleteDocument1;
            this.eliminarButtonItem.Image = global::SIF.Properties.Resources.DeleteDocument;
            this.eliminarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.eliminarButtonItem.Name = "eliminarButtonItem";
            this.eliminarButtonItem.Tag = "6";
            this.eliminarButtonItem.Text = "Eliminar\r\n[F6]";
            this.eliminarButtonItem.Click += new System.EventHandler(this.eliminarButtonItem_Click);
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
            this.buscarTextBoxX.Location = new System.Drawing.Point(51, 3);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(779, 25);
            this.buscarTextBoxX.TabIndex = 2;
            this.buscarTextBoxX.WatermarkText = "Buscar";
            this.buscarTextBoxX.ButtonCustomClick += new System.EventHandler(this.buscarTextBoxX_ButtonCustomClick);
            this.buscarTextBoxX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buscarTextBoxX_KeyUp);
            // 
            // buscarBackgroundWorker
            // 
            this.buscarBackgroundWorker.WorkerReportsProgress = true;
            this.buscarBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.buscarBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToOrderColumns = true;
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
            this.CLAVEColumn,
            this.NOMBREColumn,
            this.NOMBRE2Column,
            this.PROVEEDOR_IDColumn,
            this.PROVEEDOR_NOMBREColumn,
            this.TIPO_MEDICAMENTOColumn,
            this.LABORATORIO_NOMBREColumn,
            this.TIPO_MONEDAColumn,
            this.UNIDAD_COMPRAColumn,
            this.UNIDAD_VENTAColumn,
            this.ACTIVOColumn,
            this.PAQUETEColumn,
            this.LISTA_SUCURSAL_VENTAColumn});
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
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(915, 534);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellContentClick);
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            this.dataGridViewX1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewX1_CellValidating);
            this.dataGridViewX1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_ColumnHeaderMouseClick);
            this.dataGridViewX1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewX1_DataError);
            this.dataGridViewX1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_RowEnter);
            this.dataGridViewX1.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_RowLeave);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            this.dataGridViewX1.DoubleClick += new System.EventHandler(this.dataGridViewX1_DoubleClick);
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            // 
            // CLAVEColumn
            // 
            this.CLAVEColumn.DataPropertyName = "ARTICULO_ID";
            this.CLAVEColumn.HeaderText = "CLAVE";
            this.CLAVEColumn.MaxInputLength = 20;
            this.CLAVEColumn.Name = "CLAVEColumn";
            this.CLAVEColumn.ReadOnly = true;
            // 
            // NOMBREColumn
            // 
            this.NOMBREColumn.DataPropertyName = "NOMBRE1";
            this.NOMBREColumn.HeaderText = "NOMBRE";
            this.NOMBREColumn.MaxInputLength = 100;
            this.NOMBREColumn.Name = "NOMBREColumn";
            this.NOMBREColumn.Width = 200;
            // 
            // NOMBRE2Column
            // 
            this.NOMBRE2Column.DataPropertyName = "NOMBRE2";
            this.NOMBRE2Column.HeaderText = "NOMBRE 2";
            this.NOMBRE2Column.MaxInputLength = 150;
            this.NOMBRE2Column.Name = "NOMBRE2Column";
            this.NOMBRE2Column.Width = 200;
            // 
            // PROVEEDOR_IDColumn
            // 
            this.PROVEEDOR_IDColumn.DataPropertyName = "LABORATORIO_ID";
            this.PROVEEDOR_IDColumn.HeaderText = "LINEA(LABORATORIOID)";
            this.PROVEEDOR_IDColumn.Name = "PROVEEDOR_IDColumn";
            this.PROVEEDOR_IDColumn.Width = 120;
            // 
            // PROVEEDOR_NOMBREColumn
            // 
            this.PROVEEDOR_NOMBREColumn.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.PROVEEDOR_NOMBREColumn.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.PROVEEDOR_NOMBREColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PROVEEDOR_NOMBREColumn.DataPropertyName = "LABORATORIO_NOMBRE";
            this.PROVEEDOR_NOMBREColumn.ForeColor = System.Drawing.Color.Black;
            this.PROVEEDOR_NOMBREColumn.HeaderText = "LABORATORIO (LABORATORIO_NOMBRE)";
            this.PROVEEDOR_NOMBREColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PROVEEDOR_NOMBREColumn.Name = "PROVEEDOR_NOMBREColumn";
            this.PROVEEDOR_NOMBREColumn.PasswordChar = '\0';
            this.PROVEEDOR_NOMBREColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PROVEEDOR_NOMBREColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PROVEEDOR_NOMBREColumn.Text = "";
            this.PROVEEDOR_NOMBREColumn.Width = 200;
            // 
            // TIPO_MEDICAMENTOColumn
            // 
            this.TIPO_MEDICAMENTOColumn.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.TIPO_MEDICAMENTOColumn.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.TIPO_MEDICAMENTOColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TIPO_MEDICAMENTOColumn.DataPropertyName = "TIPO_MEDICAMENTO_CVE";
            this.TIPO_MEDICAMENTOColumn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TIPO_MEDICAMENTOColumn.HeaderText = "TIPO MEDICAMENTO";
            this.TIPO_MEDICAMENTOColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TIPO_MEDICAMENTOColumn.Name = "TIPO_MEDICAMENTOColumn";
            this.TIPO_MEDICAMENTOColumn.PasswordChar = '\0';
            this.TIPO_MEDICAMENTOColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TIPO_MEDICAMENTOColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TIPO_MEDICAMENTOColumn.Text = "";
            // 
            // LABORATORIO_NOMBREColumn
            // 
            this.LABORATORIO_NOMBREColumn.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.LABORATORIO_NOMBREColumn.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.LABORATORIO_NOMBREColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LABORATORIO_NOMBREColumn.DataPropertyName = "PROVEEDOR_NOMBRE";
            this.LABORATORIO_NOMBREColumn.ForeColor = System.Drawing.Color.Black;
            this.LABORATORIO_NOMBREColumn.HeaderText = "PROVEEDOR (NOMBRE PROVEEDOR)";
            this.LABORATORIO_NOMBREColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LABORATORIO_NOMBREColumn.Name = "LABORATORIO_NOMBREColumn";
            this.LABORATORIO_NOMBREColumn.PasswordChar = '\0';
            this.LABORATORIO_NOMBREColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LABORATORIO_NOMBREColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LABORATORIO_NOMBREColumn.Text = "";
            // 
            // TIPO_MONEDAColumn
            // 
            this.TIPO_MONEDAColumn.DataPropertyName = "TIPO_MONEDA";
            this.TIPO_MONEDAColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.TIPO_MONEDAColumn.HeaderText = "TIPO MONEDA";
            this.TIPO_MONEDAColumn.Name = "TIPO_MONEDAColumn";
            this.TIPO_MONEDAColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TIPO_MONEDAColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // UNIDAD_COMPRAColumn
            // 
            this.UNIDAD_COMPRAColumn.DataPropertyName = "U_COMPRA";
            this.UNIDAD_COMPRAColumn.HeaderText = "U/ COMPRA";
            this.UNIDAD_COMPRAColumn.MaxInputLength = 20;
            this.UNIDAD_COMPRAColumn.Name = "UNIDAD_COMPRAColumn";
            // 
            // UNIDAD_VENTAColumn
            // 
            this.UNIDAD_VENTAColumn.DataPropertyName = "U_VENTA";
            this.UNIDAD_VENTAColumn.HeaderText = "U/ VENTA";
            this.UNIDAD_VENTAColumn.MaxInputLength = 20;
            this.UNIDAD_VENTAColumn.Name = "UNIDAD_VENTAColumn";
            // 
            // ACTIVOColumn
            // 
            this.ACTIVOColumn.DataPropertyName = "ACTIVO";
            this.ACTIVOColumn.HeaderText = "ACTIVO";
            this.ACTIVOColumn.Name = "ACTIVOColumn";
            this.ACTIVOColumn.ReadOnly = true;
            // 
            // PAQUETEColumn
            // 
            this.PAQUETEColumn.DataPropertyName = "PAQUETE";
            this.PAQUETEColumn.DropDownHeight = 106;
            this.PAQUETEColumn.DropDownWidth = 121;
            this.PAQUETEColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PAQUETEColumn.HeaderText = "PAQUETE";
            this.PAQUETEColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PAQUETEColumn.IntegralHeight = false;
            this.PAQUETEColumn.ItemHeight = 15;
            this.PAQUETEColumn.Name = "PAQUETEColumn";
            this.PAQUETEColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PAQUETEColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PAQUETEColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LISTA_SUCURSAL_VENTAColumn
            // 
            this.LISTA_SUCURSAL_VENTAColumn.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.LISTA_SUCURSAL_VENTAColumn.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.LISTA_SUCURSAL_VENTAColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LISTA_SUCURSAL_VENTAColumn.DataPropertyName = "LISTA_SUCURSAL_VTA";
            this.LISTA_SUCURSAL_VENTAColumn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LISTA_SUCURSAL_VENTAColumn.HeaderText = "SUCURSAL VENTA";
            this.LISTA_SUCURSAL_VENTAColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LISTA_SUCURSAL_VENTAColumn.MaxInputLength = 50;
            this.LISTA_SUCURSAL_VENTAColumn.Name = "LISTA_SUCURSAL_VENTAColumn";
            this.LISTA_SUCURSAL_VENTAColumn.PasswordChar = '\0';
            this.LISTA_SUCURSAL_VENTAColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LISTA_SUCURSAL_VENTAColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LISTA_SUCURSAL_VENTAColumn.Text = "";
            this.LISTA_SUCURSAL_VENTAColumn.Width = 150;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarTextBoxX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarButtonX, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 30);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // buscarButtonX
            // 
            this.buscarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buscarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buscarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buscarButtonX.Location = new System.Drawing.Point(837, 3);
            this.buscarButtonX.Name = "buscarButtonX";
            this.buscarButtonX.Size = new System.Drawing.Size(75, 23);
            this.buscarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buscarButtonX.TabIndex = 0;
            this.buscarButtonX.Text = "Buscar";
            this.buscarButtonX.Click += new System.EventHandler(this.buscarButtonX_Click);
            // 
            // editarButtonItem
            // 
            this.editarButtonItem.HoverImage = global::SIF.Properties.Resources.EditDocument;
            this.editarButtonItem.Image = global::SIF.Properties.Resources.EditDocument1;
            this.editarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.editarButtonItem.Name = "editarButtonItem";
            this.editarButtonItem.Tag = "2";
            this.editarButtonItem.Text = "Editar\r\n [F4]";
            this.editarButtonItem.Click += new System.EventHandler(this.editarButtonItem_Click);
            // 
            // preciosButtonItem
            // 
            this.preciosButtonItem.HoverImage = global::SIF.Properties.Resources.FundTool1;
            this.preciosButtonItem.Image = global::SIF.Properties.Resources.FundTool;
            this.preciosButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.preciosButtonItem.Name = "preciosButtonItem";
            this.preciosButtonItem.Tag = "43";
            this.preciosButtonItem.Text = "Precios\r\n ";
            this.preciosButtonItem.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ImportarPreciosVentaButtonItem
            });
            this.preciosButtonItem.Click += new System.EventHandler(this.preciosButtonItem_Click);
            // 
            // ImportarPreciosVentaButtonItem
            // 
            this.ImportarPreciosVentaButtonItem.HoverImage = global::SIF.Properties.Resources.FundTool1;
            this.ImportarPreciosVentaButtonItem.Image = global::SIF.Properties.Resources.FundTool;
            this.ImportarPreciosVentaButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.ImportarPreciosVentaButtonItem.Name = "ImportarPreciosVentaButtonItem";
            this.ImportarPreciosVentaButtonItem.Tag = "43";        
            this.ImportarPreciosVentaButtonItem.Text = "Importar\r\nPrecios Venta";
            this.ImportarPreciosVentaButtonItem.Click += new System.EventHandler(this.ImportarPreciosVentaButtonItem_Click);



            // 
            // existenciasButtonItem
            // 
            this.existenciasButtonItem.HoverImage = global::SIF.Properties.Resources.ListView1;
            this.existenciasButtonItem.Image = global::SIF.Properties.Resources.ListView;
            this.existenciasButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.existenciasButtonItem.Name = "existenciasButtonItem";
            this.existenciasButtonItem.Tag = "43";
            this.existenciasButtonItem.Text = "Existencias\r\n ";
            this.existenciasButtonItem.Click += new System.EventHandler(this.existenciasButtonItem_Click);
            // 
            // mayoristasButtonItem
            // 
            this.mayoristasButtonItem.HoverImage = global::SIF.Properties.Resources.Payments;
            this.mayoristasButtonItem.Image = global::SIF.Properties.Resources.Payments1;
            this.mayoristasButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.mayoristasButtonItem.Name = "mayoristasButtonItem";
            this.mayoristasButtonItem.Tag = "44";
            this.mayoristasButtonItem.Text = "Mayoristas\r\n ";
            this.mayoristasButtonItem.Click += new System.EventHandler(this.mayoristasButtonItem_Click);
            // 
            // transferButtonItem
            // 
            this.transferButtonItem.HoverImage = global::SIF.Properties.Resources.Date1;
            this.transferButtonItem.Image = global::SIF.Properties.Resources.Date;
            this.transferButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.transferButtonItem.Name = "transferButtonItem";
            this.transferButtonItem.Tag = "44";
            this.transferButtonItem.Text = "Transfer\r\n ";
            this.transferButtonItem.Click += new System.EventHandler(this.transferButtonItem_Click);
            // 
            // imprimirButtonItem
            // 
            this.imprimirButtonItem.HoverImage = global::SIF.Properties.Resources.Printer1;
            this.imprimirButtonItem.Image = global::SIF.Properties.Resources.Printer;
            this.imprimirButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.imprimirButtonItem.Name = "imprimirButtonItem";
            this.imprimirButtonItem.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.catProductosButtonItem,
            this.catProductosBajaButtonItem});
            this.imprimirButtonItem.Tag = "3";
            this.imprimirButtonItem.Text = "Imprimir\r\n ";
            // 
            // catProductosButtonItem
            // 
            this.catProductosButtonItem.Name = "catProductosButtonItem";
            this.catProductosButtonItem.Text = "Catálogo de Productos";
            this.catProductosButtonItem.Click += new System.EventHandler(this.catProductosButtonItem_Click);
            // 
            // catProductosBajaButtonItem
            // 
            this.catProductosBajaButtonItem.Name = "catProductosBajaButtonItem";
            this.catProductosBajaButtonItem.Text = "Catalogo Bajas";
            this.catProductosBajaButtonItem.Click += new System.EventHandler(this.catProductosBajaButtonItem_Click);
            // 
            // catArticulosBajaButtonItem
            // 
            this.catArticulosBajaButtonItem.HoverImage = global::SIF.Properties.Resources.DeleteTool;
            this.catArticulosBajaButtonItem.Image = global::SIF.Properties.Resources.DeleteTool;
            this.catArticulosBajaButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.catArticulosBajaButtonItem.Name = "catArticulosBajaButtonItem";
            this.catArticulosBajaButtonItem.Tag = "2";
            this.catArticulosBajaButtonItem.Text = "Articulos Baja\r\n O Proxima Baja ";
            this.catArticulosBajaButtonItem.Click += new System.EventHandler(this.catArticulosBajaButtonItem_Click);
            // 
            // dbtn_AsignarComprador
            // 
            this.dbtn_AsignarComprador.HoverImage = global::SIF.Properties.Resources.AddTool;
            this.dbtn_AsignarComprador.Image = global::SIF.Properties.Resources.AddTool;
            this.dbtn_AsignarComprador.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.dbtn_AsignarComprador.Name = "dbtn_AsignarComprador";
            this.dbtn_AsignarComprador.Tag = "2";
            this.dbtn_AsignarComprador.Text = "Asignar \n Comprador ";
            this.dbtn_AsignarComprador.Click += new System.EventHandler(this.dbtn_AsignarCompradorButtonItem_Click);
            // 
            // bnt_Actualizacion
            // 
            //this.bnt_Actualizacion.HoverImage = global::SIF.Properties.Resources.Upload2;
            //this.bnt_Actualizacion.Image = global::SIF.Properties.Resources.Upload1;
            //this.bnt_Actualizacion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            //this.bnt_Actualizacion.Name = "bnt_Actualizacion";
            //this.bnt_Actualizacion.Tag = "3";
            //this.bnt_Actualizacion.Text = "Actualizar \n Catalogo ";
            //this.bnt_Actualizacion.Click += new System.EventHandler(this.Actualiza_sif3);
            //
            //actualiza tienda
            // 
            this.bnt_Actualizacion.HoverImage = global::SIF.Properties.Resources.Printer1;
            this.bnt_Actualizacion.Image = global::SIF.Properties.Resources.Printer;
            this.bnt_Actualizacion.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.bnt_Actualizacion.Name = "bnt_Actualizacion";
            this.bnt_Actualizacion.Tag = "3";
            this.bnt_Actualizacion.Text = "Actualiza \n TiendaL";
            this.bnt_Actualizacion.Click += new System.EventHandler(this.btnConsumir_TL);
            // ArticuloUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ArticuloUserControl";
            this.Load += new System.EventHandler(this.CatArticulosUserControl_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laboratorioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMedicamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMonedaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadCompraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadVentaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiNoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem NuevoButtonItem;
        private DevComponents.DotNetBar.ButtonItem eliminarButtonItem;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.BindingSource SiNoBindingSource;
        private System.ComponentModel.BackgroundWorker buscarBackgroundWorker;
        private System.Windows.Forms.BindingSource laboratorioBindingSource;
        private System.Windows.Forms.BindingSource proveedorBindingSource;
        private System.Windows.Forms.BindingSource tipoMedicamentoBindingSource;
        private System.Windows.Forms.BindingSource tipoMonedaBindingSource;
        private System.Windows.Forms.BindingSource unidadCompraBindingSource;
        private System.Windows.Forms.BindingSource unidadVentaBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
        private DevComponents.DotNetBar.ButtonItem editarButtonItem;
        private DevComponents.DotNetBar.ButtonItem preciosButtonItem;
        private DevComponents.DotNetBar.ButtonItem existenciasButtonItem;
        private DevComponents.DotNetBar.ButtonItem mayoristasButtonItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLAVEColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBREColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE2Column;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn PROVEEDOR_IDColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn PROVEEDOR_NOMBREColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn TIPO_MEDICAMENTOColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn LABORATORIO_NOMBREColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn TIPO_MONEDAColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIDAD_COMPRAColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIDAD_VENTAColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACTIVOColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn PAQUETEColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn LISTA_SUCURSAL_VENTAColumn;
        private DevComponents.DotNetBar.ButtonItem transferButtonItem;
        private DevComponents.DotNetBar.ButtonItem imprimirButtonItem;
        private DevComponents.DotNetBar.ButtonItem catProductosButtonItem;
        private DevComponents.DotNetBar.ButtonItem catProductosBajaButtonItem;
        private DevComponents.DotNetBar.ButtonItem catArticulosBajaButtonItem;
        private DevComponents.DotNetBar.ButtonItem AsignarComprador;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonItem dbtn_AsignarComprador;
        private DevComponents.DotNetBar.ButtonItem bnt_Actualizacion;

        private DevComponents.DotNetBar.ButtonItem ImportarPreciosVentaButtonItem;
    }
}
