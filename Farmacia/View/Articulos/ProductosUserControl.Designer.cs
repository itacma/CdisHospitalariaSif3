
namespace SIF.View.Articulos
{
    partial class ProductosUserControl
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticuloUserControl));
            DevComponents.DotNetBar.LabelX labelX1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.PRECIOColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.DISPONIBLEColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.UBICACIONColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.EXISTENCIASColumn = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.APARTADO_VTASColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.TIPO_MEDICAMENTOColumn = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.PAQUETEColumn = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.PROVEEDOR_NOMBREColumn = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.LABORATORIO_NOMBREColumn = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.UNIDAD_COMPRAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.UNIDAD_VENTAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.SUCURSALColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.LISTA_SUCURSAL_VENTAColumn = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.ActivoColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            labelX1 = new DevComponents.DotNetBar.LabelX();
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
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.ItemSpacing = 10;
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(276, 32);
            this.titleLabel.Text = "INVENTARIO\\PRODUCTO NO CONFORME\\PRODUCTOS";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(64, 102);
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewX1);
            this.splitContainer1.Size = new System.Drawing.Size(915, 619);
            this.splitContainer1.SplitterDistance = 35;
            this.splitContainer1.TabStop = false;
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
            this.apellidosLabel.Location = new System.Drawing.Point(713, 61);
            this.apellidosLabel.Text = "";
            // 
            // nombreLabel
            // 
            this.nombreLabel.Location = new System.Drawing.Point(713, 40);
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
            labelX1.Location = new System.Drawing.Point(3, 7);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(43, 20);
            labelX1.TabIndex = 1;
            labelX1.Text = "Buscar:";
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
            this.buscarTextBoxX.Location = new System.Drawing.Point(51, 5);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(779, 25);
            this.buscarTextBoxX.TabIndex = 0;
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
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLAVEColumn,
            this.NOMBREColumn,
            this.NOMBRE2Column,
            this.PRECIOColumn,
            this.DISPONIBLEColumn,
            this.UBICACIONColumn,
            this.EXISTENCIASColumn,
            this.APARTADO_VTASColumn,
            this.TIPO_MEDICAMENTOColumn,
            this.PAQUETEColumn,
            this.PROVEEDOR_NOMBREColumn,
            this.LABORATORIO_NOMBREColumn,
            this.UNIDAD_COMPRAColumn,
            this.UNIDAD_VENTAColumn,
            this.SUCURSALColumn,
            this.LISTA_SUCURSAL_VENTAColumn,
            this.ActivoColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(915, 564);
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
            this.CLAVEColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // NOMBREColumn
            // 
            this.NOMBREColumn.DataPropertyName = "NOMBRE1";
            this.NOMBREColumn.HeaderText = "NOMBRE";
            this.NOMBREColumn.Name = "NOMBREColumn";
            this.NOMBREColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NOMBREColumn.Width = 200;
            // 
            // NOMBRE2Column
            // 
            this.NOMBRE2Column.DataPropertyName = "NOMBRE2";
            this.NOMBRE2Column.HeaderText = "NOMBRE 2";
            this.NOMBRE2Column.Name = "NOMBRE2Column";
            this.NOMBRE2Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NOMBRE2Column.Width = 200;
            // 
            // PRECIOColumn
            // 
            this.PRECIOColumn.DataPropertyName = "PRECIO_VENTA";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.PRECIOColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.PRECIOColumn.HeaderText = "PRECIO";
            this.PRECIOColumn.Name = "PRECIOColumn";
            this.PRECIOColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PRECIOColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PRECIOColumn.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // DISPONIBLEColumn
            // 
            this.DISPONIBLEColumn.DataPropertyName = "DISPONIBLE";
            this.DISPONIBLEColumn.HeaderText = "DISPONIBLE P/VENTA";
            this.DISPONIBLEColumn.Name = "DISPONIBLEColumn";
            this.DISPONIBLEColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DISPONIBLEColumn.Text = "DISPONIBLE P/VENTA";
            this.DISPONIBLEColumn.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // UBICACIONColumn
            // 
            this.UBICACIONColumn.DataPropertyName = "UBICACION";
            this.UBICACIONColumn.HeaderText = "UBICACION";
            this.UBICACIONColumn.Name = "UBICACIONColumn";
            this.UBICACIONColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // EXISTENCIASColumn
            // 
            this.EXISTENCIASColumn.DataPropertyName = "EXISTENCIAS";
            this.EXISTENCIASColumn.HeaderText = "EXISTENCIAS";
            this.EXISTENCIASColumn.Name = "EXISTENCIASColumn";
            this.EXISTENCIASColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EXISTENCIASColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.EXISTENCIASColumn.Text = null;
            this.EXISTENCIASColumn.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            // 
            // APARTADO_VTASColumn
            // 
            this.APARTADO_VTASColumn.DataPropertyName = "APARTADO_VTAS";
            this.APARTADO_VTASColumn.HeaderText = "APARTADOS";
            this.APARTADO_VTASColumn.Name = "APARTADO_VTASColumn";
            this.APARTADO_VTASColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.APARTADO_VTASColumn.Text = "APARTADOS";
            // 
            // TIPO_MEDICAMENTOColumn
            // 
            this.TIPO_MEDICAMENTOColumn.DataPropertyName = "TIPO_MEDICAMENTO_CVE";
            this.TIPO_MEDICAMENTOColumn.HeaderText = "TIPO MEDICAMENTO";
            this.TIPO_MEDICAMENTOColumn.Name = "TIPO_MEDICAMENTOColumn";
            this.TIPO_MEDICAMENTOColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TIPO_MEDICAMENTOColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TIPO_MEDICAMENTOColumn.Text = null;
            this.TIPO_MEDICAMENTOColumn.Width = 230;
            // 
            // PAQUETEColumn
            // 
            this.PAQUETEColumn.DataPropertyName = "PAQUETE";
            //this.PAQUETEColumn.DropDownHeight = 106;
            //this.PAQUETEColumn.DropDownWidth = 121;
            //this.PAQUETEColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PAQUETEColumn.HeaderText = "PAQUETE";
            //this.PAQUETEColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            //this.PAQUETEColumn.IntegralHeight = false;
            //this.PAQUETEColumn.ItemHeight = 15;
            this.PAQUETEColumn.Name = "PAQUETEColumn";
            this.PAQUETEColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PAQUETEColumn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // PROVEEDOR_NOMBREColumn
            // 
            this.PROVEEDOR_NOMBREColumn.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.PROVEEDOR_NOMBREColumn.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.PROVEEDOR_NOMBREColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PROVEEDOR_NOMBREColumn.DataPropertyName = "CAT_PROVEEDOR_NOMBRE";
            this.PROVEEDOR_NOMBREColumn.ForeColor = System.Drawing.Color.Black;
            this.PROVEEDOR_NOMBREColumn.HeaderText = "PROVEEDOR";
            this.PROVEEDOR_NOMBREColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PROVEEDOR_NOMBREColumn.Name = "PROVEEDOR_NOMBREColumn";
            this.PROVEEDOR_NOMBREColumn.PasswordChar = '\0';
            this.PROVEEDOR_NOMBREColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PROVEEDOR_NOMBREColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PROVEEDOR_NOMBREColumn.Text = "";
            this.PROVEEDOR_NOMBREColumn.Width = 200;
            // 
            // LABORATORIO_NOMBREColumn
            // 
            this.LABORATORIO_NOMBREColumn.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.LABORATORIO_NOMBREColumn.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.LABORATORIO_NOMBREColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LABORATORIO_NOMBREColumn.DataPropertyName = "CAT_LABORATORIO_NOMBRE";
            this.LABORATORIO_NOMBREColumn.ForeColor = System.Drawing.Color.Black;
            this.LABORATORIO_NOMBREColumn.HeaderText = "LABORATORIO";
            this.LABORATORIO_NOMBREColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LABORATORIO_NOMBREColumn.Name = "LABORATORIO_NOMBREColumn";
            this.LABORATORIO_NOMBREColumn.PasswordChar = '\0';
            this.LABORATORIO_NOMBREColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LABORATORIO_NOMBREColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LABORATORIO_NOMBREColumn.Text = "";
            this.LABORATORIO_NOMBREColumn.Width = 200;
            // 
            // UNIDAD_COMPRAColumn
            // 
            this.UNIDAD_COMPRAColumn.DataPropertyName = "U_COMPRA";
            this.UNIDAD_COMPRAColumn.HeaderText = "U/ COMPRA";
            this.UNIDAD_COMPRAColumn.Name = "UNIDAD_COMPRAColumn";
            this.UNIDAD_COMPRAColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UNIDAD_COMPRAColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // UNIDAD_VENTAColumn
            // 
            this.UNIDAD_VENTAColumn.DataPropertyName = "U_VENTA";
            this.UNIDAD_VENTAColumn.HeaderText = "U/ VENTA";
            this.UNIDAD_VENTAColumn.Name = "UNIDAD_VENTAColumn";
            this.UNIDAD_VENTAColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UNIDAD_VENTAColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SUCURSALColumn
            // 
            this.SUCURSALColumn.DataPropertyName = "CAT_SUCURSALES_NOMBRE";
            this.SUCURSALColumn.HeaderText = "SUCURSAL";
            this.SUCURSALColumn.Name = "SUCURSALColumn";
            this.SUCURSALColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SUCURSALColumn.Text = "SUCURSAL";
            this.SUCURSALColumn.Width = 120;
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
            // ActivoColumn
            // 
            this.ActivoColumn.DataPropertyName = "Activo";
            this.ActivoColumn.HeaderText = "ACTIVO";
            this.ActivoColumn.Name = "ActivoColumn";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.Controls.Add(labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarTextBoxX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarButtonX, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 35);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buscarButtonX
            // 
            this.buscarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buscarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buscarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buscarButtonX.Location = new System.Drawing.Point(837, 6);
            this.buscarButtonX.Name = "buscarButtonX";
            this.buscarButtonX.Size = new System.Drawing.Size(75, 23);
            this.buscarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buscarButtonX.TabIndex = 0;
            this.buscarButtonX.Text = "Buscar";
            this.buscarButtonX.Click += new System.EventHandler(this.buscarButtonX_Click);
            // 
            // ArticuloUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ArticuloUserControl";
            this.Load += new System.EventHandler(this.CatArticulosUserControl_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn CLAVEColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBREColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE2Column;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn PRECIOColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn DISPONIBLEColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn UBICACIONColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn EXISTENCIASColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn APARTADO_VTASColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn TIPO_MEDICAMENTOColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn PAQUETEColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn PROVEEDOR_NOMBREColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn LABORATORIO_NOMBREColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn UNIDAD_COMPRAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn UNIDAD_VENTAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn SUCURSALColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn LISTA_SUCURSAL_VENTAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ActivoColumn;
    }
}
