namespace SIF.View.OrdenCompra
{
    partial class OfertasComprasUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfertasComprasUserControl));
            DevComponents.DotNetBar.LabelX labelX1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
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
            this.CLAVEColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.PROVEEDOR_NOMBREColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FECHA_ALTAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.NOMBREColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.LABORATORIO_NOMBREColumn = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.PRECIO_FARMACIAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.PRECIO_PUBLICOColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.TIPO_OFERTAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.DESCUENTO_OFRECIDOColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.DESCRIPCION_DESCUENTOColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.MINIMO_PIEZASColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.CANTIDAD_COMPRARColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.PIEZAS_CON_CARGOColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.PIEZAS_SIN_CARGOColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ESTADO_ART_PROVEEDOR = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ESTADO_ART_FLEMINGColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.DESCUENTO_ADICIONAL_PROVEEDORColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.DESCUENTO_ESPECIAL_PROVEEDORColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.FECHA_BAJAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.CODIGO_PROVEEDORColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ESCALAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laboratorioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMedicamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMonedaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadCompraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadVentaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiNoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.ItemSpacing = 10;
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(223, 32);
            this.titleLabel.Text = "COMPRAS\\OFERTAS";
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
            this.splitContainer1.SplitterDistance = 33;
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
            labelX1.Location = new System.Drawing.Point(787, 6);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(43, 20);
            labelX1.TabIndex = 1;
            labelX1.Text = "Buscar:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 771F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.Controls.Add(this.buscarTextBoxX, 0, 0);
            this.tableLayoutPanel1.Controls.Add(labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarButtonX, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 33);
            this.tableLayoutPanel1.TabIndex = 1;
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
            this.buscarTextBoxX.Location = new System.Drawing.Point(3, 4);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(765, 25);
            this.buscarTextBoxX.TabIndex = 3;
            this.buscarTextBoxX.WatermarkText = "Buscar";
            this.buscarTextBoxX.ButtonCustomClick += new System.EventHandler(this.buscarTextBoxX_ButtonCustomClick);
            this.buscarTextBoxX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buscarTextBoxX_KeyUp);
            // 
            // buscarButtonX
            // 
            this.buscarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buscarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buscarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buscarButtonX.Location = new System.Drawing.Point(837, 5);
            this.buscarButtonX.Name = "buscarButtonX";
            this.buscarButtonX.Size = new System.Drawing.Size(75, 23);
            this.buscarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buscarButtonX.TabIndex = 0;
            this.buscarButtonX.Text = "Buscar";
            this.buscarButtonX.Click += new System.EventHandler(this.buscarButtonX_Click);
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
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
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLAVEColumn,
            this.PROVEEDOR_NOMBREColumn,
            this.FECHA_ALTAColumn,
            this.NOMBREColumn,
            this.LABORATORIO_NOMBREColumn,
            this.PRECIO_FARMACIAColumn,
            this.PRECIO_PUBLICOColumn,
            this.TIPO_OFERTAColumn,
            this.DESCUENTO_OFRECIDOColumn,
            this.DESCRIPCION_DESCUENTOColumn,
            this.MINIMO_PIEZASColumn,
            this.CANTIDAD_COMPRARColumn,
            this.PIEZAS_CON_CARGOColumn,
            this.PIEZAS_SIN_CARGOColumn,
            this.ESTADO_ART_PROVEEDOR,
            this.ESTADO_ART_FLEMINGColumn,
            this.DESCUENTO_ADICIONAL_PROVEEDORColumn,
            this.DESCUENTO_ESPECIAL_PROVEEDORColumn,
            this.FECHA_BAJAColumn,
            this.CODIGO_PROVEEDORColumn,
            this.ESCALAColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(915, 531);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            this.dataGridViewX1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewX1_CellValidating);
            this.dataGridViewX1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_ColumnHeaderMouseClick);
            this.dataGridViewX1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewX1_DataError);
            this.dataGridViewX1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_RowEnter);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            this.dataGridViewX1.DoubleClick += new System.EventHandler(this.dataGridViewX1_DoubleClick);
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            // 
            // CLAVEColumn
            // 
            this.CLAVEColumn.DataPropertyName = "ARTICULO_ID";
            this.CLAVEColumn.HeaderText = "CLAVE";
            this.CLAVEColumn.Name = "CLAVEColumn";
            this.CLAVEColumn.ReadOnly = true;
            this.CLAVEColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CLAVEColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // PROVEEDOR_NOMBREColumn
            // 
            this.PROVEEDOR_NOMBREColumn.DataPropertyName = "ProveedorID";
            this.PROVEEDOR_NOMBREColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.PROVEEDOR_NOMBREColumn.HeaderText = "PROVEEDOR";
            this.PROVEEDOR_NOMBREColumn.Name = "PROVEEDOR_NOMBREColumn";
            this.PROVEEDOR_NOMBREColumn.ReadOnly = true;
            this.PROVEEDOR_NOMBREColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PROVEEDOR_NOMBREColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PROVEEDOR_NOMBREColumn.Width = 200;
            // 
            // FECHA_ALTAColumn
            // 
            this.FECHA_ALTAColumn.DataPropertyName = "FechaAlta";
            this.FECHA_ALTAColumn.HeaderText = "FECHA ALTA";
            this.FECHA_ALTAColumn.Name = "FECHA_ALTAColumn";
            // 
            // NOMBREColumn
            // 
            this.NOMBREColumn.DataPropertyName = "NOMBRE1";
            this.NOMBREColumn.HeaderText = "NOMBRE";
            this.NOMBREColumn.Name = "NOMBREColumn";
            this.NOMBREColumn.ReadOnly = true;
            this.NOMBREColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NOMBREColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.NOMBREColumn.Width = 200;
            // 
            // LABORATORIO_NOMBREColumn
            // 
            this.LABORATORIO_NOMBREColumn.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.LABORATORIO_NOMBREColumn.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.LABORATORIO_NOMBREColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LABORATORIO_NOMBREColumn.DataPropertyName = "LaboratorioID";
            this.LABORATORIO_NOMBREColumn.ForeColor = System.Drawing.Color.Black;
            this.LABORATORIO_NOMBREColumn.HeaderText = "LABORATORIO";
            this.LABORATORIO_NOMBREColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LABORATORIO_NOMBREColumn.Name = "LABORATORIO_NOMBREColumn";
            this.LABORATORIO_NOMBREColumn.PasswordChar = '\0';
            this.LABORATORIO_NOMBREColumn.ReadOnly = true;
            this.LABORATORIO_NOMBREColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LABORATORIO_NOMBREColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LABORATORIO_NOMBREColumn.Text = "";
            // 
            // PRECIO_FARMACIAColumn
            // 
            this.PRECIO_FARMACIAColumn.DataPropertyName = "PrecioFarmacia";
            this.PRECIO_FARMACIAColumn.HeaderText = "PRECIO FARMACIA";
            this.PRECIO_FARMACIAColumn.Name = "PRECIO_FARMACIAColumn";
            this.PRECIO_FARMACIAColumn.ReadOnly = true;
            // 
            // PRECIO_PUBLICOColumn
            // 
            this.PRECIO_PUBLICOColumn.DataPropertyName = "PrecioPublico";
            this.PRECIO_PUBLICOColumn.HeaderText = "PRECIO_PUBLICO";
            this.PRECIO_PUBLICOColumn.Name = "PRECIO_PUBLICOColumn";
            this.PRECIO_PUBLICOColumn.ReadOnly = true;
            // 
            // TIPO_OFERTAColumn
            // 
            this.TIPO_OFERTAColumn.DataPropertyName = "TipoOferta";
            this.TIPO_OFERTAColumn.HeaderText = "TIPO OFERTA";
            this.TIPO_OFERTAColumn.Name = "TIPO_OFERTAColumn";
            this.TIPO_OFERTAColumn.ReadOnly = true;
            // 
            // DESCUENTO_OFRECIDOColumn
            // 
            this.DESCUENTO_OFRECIDOColumn.DataPropertyName = "DescuentoOfrecido";
            this.DESCUENTO_OFRECIDOColumn.HeaderText = "DESCUNTO OFRECIDO";
            this.DESCUENTO_OFRECIDOColumn.Name = "DESCUENTO_OFRECIDOColumn";
            this.DESCUENTO_OFRECIDOColumn.ReadOnly = true;
            // 
            // DESCRIPCION_DESCUENTOColumn
            // 
            this.DESCRIPCION_DESCUENTOColumn.DataPropertyName = "DescripcionDescuento";
            this.DESCRIPCION_DESCUENTOColumn.HeaderText = "DESCRIPCION DESCUENTO";
            this.DESCRIPCION_DESCUENTOColumn.Name = "DESCRIPCION_DESCUENTOColumn";
            this.DESCRIPCION_DESCUENTOColumn.ReadOnly = true;
            // 
            // MINIMO_PIEZASColumn
            // 
            this.MINIMO_PIEZASColumn.DataPropertyName = "MinimoPiezas";
            this.MINIMO_PIEZASColumn.HeaderText = "MINIMO PIEZAS";
            this.MINIMO_PIEZASColumn.Name = "MINIMO_PIEZASColumn";
            this.MINIMO_PIEZASColumn.ReadOnly = true;
            this.MINIMO_PIEZASColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MINIMO_PIEZASColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CANTIDAD_COMPRARColumn
            // 
            this.CANTIDAD_COMPRARColumn.DataPropertyName = "CantidadComprar";
            this.CANTIDAD_COMPRARColumn.HeaderText = "CANTIDAD COMPRAR";
            this.CANTIDAD_COMPRARColumn.Name = "CANTIDAD_COMPRARColumn";
            this.CANTIDAD_COMPRARColumn.ReadOnly = true;
            // 
            // PIEZAS_CON_CARGOColumn
            // 
            this.PIEZAS_CON_CARGOColumn.DataPropertyName = "PiezasConCargo";
            this.PIEZAS_CON_CARGOColumn.HeaderText = "PIEZAS CON CARGO";
            this.PIEZAS_CON_CARGOColumn.Name = "PIEZAS_CON_CARGOColumn";
            this.PIEZAS_CON_CARGOColumn.ReadOnly = true;
            // 
            // PIEZAS_SIN_CARGOColumn
            // 
            this.PIEZAS_SIN_CARGOColumn.DataPropertyName = "PiezasSinCargo";
            this.PIEZAS_SIN_CARGOColumn.HeaderText = "PIEZAS SIN CARGO";
            this.PIEZAS_SIN_CARGOColumn.Name = "PIEZAS_SIN_CARGOColumn";
            this.PIEZAS_SIN_CARGOColumn.ReadOnly = true;
            // 
            // ESTADO_ART_PROVEEDOR
            // 
            this.ESTADO_ART_PROVEEDOR.DataPropertyName = "EstadoArticuloProveedor";
            this.ESTADO_ART_PROVEEDOR.HeaderText = "ESTADO ARTICULO PROVEEDOR";
            this.ESTADO_ART_PROVEEDOR.Name = "ESTADO_ART_PROVEEDOR";
            this.ESTADO_ART_PROVEEDOR.ReadOnly = true;
            // 
            // ESTADO_ART_FLEMINGColumn
            // 
            this.ESTADO_ART_FLEMINGColumn.DataPropertyName = "EstadoArticuloFleming";
            this.ESTADO_ART_FLEMINGColumn.HeaderText = "ESTADO ARTICULO FLEMING";
            this.ESTADO_ART_FLEMINGColumn.Name = "ESTADO_ART_FLEMINGColumn";
            this.ESTADO_ART_FLEMINGColumn.ReadOnly = true;
            // 
            // DESCUENTO_ADICIONAL_PROVEEDORColumn
            // 
            this.DESCUENTO_ADICIONAL_PROVEEDORColumn.DataPropertyName = "DescuentoAdicional";
            this.DESCUENTO_ADICIONAL_PROVEEDORColumn.HeaderText = "DESCUENTO ADICIONAL PROVEEDOR";
            this.DESCUENTO_ADICIONAL_PROVEEDORColumn.Name = "DESCUENTO_ADICIONAL_PROVEEDORColumn";
            this.DESCUENTO_ADICIONAL_PROVEEDORColumn.ReadOnly = true;
            // 
            // DESCUENTO_ESPECIAL_PROVEEDORColumn
            // 
            this.DESCUENTO_ESPECIAL_PROVEEDORColumn.DataPropertyName = "DescuentoEspecialProveedor";
            this.DESCUENTO_ESPECIAL_PROVEEDORColumn.HeaderText = "DESCUENTO ESPECIAL PROVEEDOR";
            this.DESCUENTO_ESPECIAL_PROVEEDORColumn.Name = "DESCUENTO_ESPECIAL_PROVEEDORColumn";
            this.DESCUENTO_ESPECIAL_PROVEEDORColumn.ReadOnly = true;
            // 
            // FECHA_BAJAColumn
            // 
            this.FECHA_BAJAColumn.DataPropertyName = "FechaBaja";
            this.FECHA_BAJAColumn.HeaderText = "FECHA BAJA";
            this.FECHA_BAJAColumn.Name = "FECHA_BAJAColumn";
            this.FECHA_BAJAColumn.ReadOnly = true;
            // 
            // CODIGO_PROVEEDORColumn
            // 
            this.CODIGO_PROVEEDORColumn.DataPropertyName = "CodigoProveedor";
            this.CODIGO_PROVEEDORColumn.HeaderText = "CODIGO PROVEEDOR";
            this.CODIGO_PROVEEDORColumn.Name = "CODIGO_PROVEEDORColumn";
            this.CODIGO_PROVEEDORColumn.ReadOnly = true;
            // 
            // ESCALAColumn
            // 
            this.ESCALAColumn.DataPropertyName = "Escala";
            this.ESCALAColumn.HeaderText = "ESCALA";
            this.ESCALAColumn.Name = "ESCALAColumn";
            this.ESCALAColumn.ReadOnly = true;
            this.ESCALAColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ESCALAColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // OfertasComprasUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "OfertasComprasUserControl";
            this.Load += new System.EventHandler(this.CatArticulosUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laboratorioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMedicamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMonedaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadCompraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadVentaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiNoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
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
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn CLAVEColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn PROVEEDOR_NOMBREColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn FECHA_ALTAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn NOMBREColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn LABORATORIO_NOMBREColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn PRECIO_FARMACIAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn PRECIO_PUBLICOColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn TIPO_OFERTAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn DESCUENTO_OFRECIDOColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn DESCRIPCION_DESCUENTOColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn MINIMO_PIEZASColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn CANTIDAD_COMPRARColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn PIEZAS_CON_CARGOColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn PIEZAS_SIN_CARGOColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ESTADO_ART_PROVEEDOR;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ESTADO_ART_FLEMINGColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn DESCUENTO_ADICIONAL_PROVEEDORColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn DESCUENTO_ESPECIAL_PROVEEDORColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn FECHA_BAJAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn CODIGO_PROVEEDORColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ESCALAColumn;
    }
}
