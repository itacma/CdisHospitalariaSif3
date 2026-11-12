using DevComponents.DotNetBar;

namespace SIF.View.OrdenCompra
{
    partial class OrdenesCompraUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdenesCompraUserControl));
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.dateTimeInput1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateTimeInput2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.statusOrdenCompraComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.porEOQAutomaticaBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.eliminarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.imprimirButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.compraProveedorButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.IncidenciasButtonItem = new DevComponents.DotNetBar.ButtonItem();
            //this.talonDePagoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.OrdenCompraCaducidadesItem = new DevComponents.DotNetBar.ButtonItem();
            this.IncidenciasRecepcion = new DevComponents.DotNetBar.ButtonItem();
            this.ControlCaducidadesButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.editarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.LiberarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.ImportarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.EdicionButtonItem=new DevComponents.DotNetBar.ButtonItem() ;
            this.HerramientasButtonItem = new DevComponents.DotNetBar.ButtonItem();            
            this.CaducidadesButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.cerrarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.cambiarProveButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.AsignarModoPagoItem = new DevComponents.DotNetBar.ButtonItem();
            this.cambiarEstadoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.devolucionProveButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.reposicionProveButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.facturaButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.unirButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.dividirButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.cuentasPorPagarbuttonItem = new DevComponents.DotNetBar.ButtonItem();
            this.recibirButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.preciosButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.asociarFacturasButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.desAsociarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.facturaAutomaticaButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.loteCaducidadButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.reutilizarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.CompraConAjusteButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.ModificacionDeLotesYCaducidadItem = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
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
            this.EdicionButtonItem,              
            this.imprimirButtonItem,
            this.cuentasPorPagarbuttonItem,
            this.cerrarButtonItem,
            this.recibirButtonItem,
            this.preciosButtonItem,
            this.asociarFacturasButtonItem,
            //this.loteCaducidadButtonItem,
            this.HerramientasButtonItem,
            this.CaducidadesButtonItem,
            this.ModificacionDeLotesYCaducidadItem,
            this.LiberarButtonItem,
            this.ImportarButtonItem


            });
            this.bar1.Location = new System.Drawing.Point(64, 44);
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(978, 92);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 15;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(520, 32);
            this.titleLabel.Text = "COMPRAS\\CONSULTA DE ORDENES DE COMPRA";
            // 
            // superGridControl1
            // 
            this.superGridControl1.BackColor = System.Drawing.Color.White;
            this.superGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControl1.ForeColor = System.Drawing.Color.Black;
            this.superGridControl1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.superGridControl1.Location = new System.Drawing.Point(0, 0);
            this.superGridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.superGridControl1.Name = "superGridControl1";
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            gridColumn1.DataPropertyName = "SELECCIONADO";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn1.HeaderText = " ";
            gridColumn1.Name = "SELECTColumn";
            gridColumn1.Width = 40;
            gridColumn2.DataPropertyName = "FOLIO_OC_ID";
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn2.HeaderText = "FOLIO";
            gridColumn2.Name = "FOLIOColumn";
            gridColumn2.Width = 120;
            gridColumn3.DataPropertyName = "PROVEEDOR_ID";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn3.HeaderText = "PROVEEDOR ID";
            gridColumn3.Name = "PROVEEDOR_IDColumn";
            gridColumn4.DataPropertyName = "CAT_CLIENTES_NOMBRE";
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn4.HeaderText = "PROVEEDOR";
            gridColumn4.Name = "PROVEEDORColumn";
            gridColumn4.Width = 170;
            gridColumn5.DataPropertyName = "SUCURSAL_ID";
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn5.HeaderText = "SUCURSAL";
            gridColumn5.Name = "SUCURSAL";
            gridColumn6.DataPropertyName = "FECHA_ALTA";
            gridColumn6.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn6.HeaderText = "ALTA";
            gridColumn6.Name = "FECHA_ALTAColumn";
            gridColumn6.Width = 130;
            gridColumn7.DataPropertyName = "FECHA_RECEPCION";
            gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn7.HeaderText = "RECEPCION";
            gridColumn7.Name = "FECHA_RECEPCIONColumn";
            gridColumn7.Width = 130;
            gridColumn8.DataPropertyName = "FECHA_CIERRE";
            gridColumn8.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn8.HeaderText = "CIERRE";
            gridColumn8.Name = "CIERREColumn";
            gridColumn8.Width = 130;
            gridColumn9.DataPropertyName = "ESTADO_OC";
            gridColumn9.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn9.HeaderText = "ESTADO";
            gridColumn9.Name = "ESTADO_OC_COLUMN";
            gridColumn9.Width = 70;
            gridColumn10.DataPropertyName = "CAT_USUARIOS_NOMBRE";
            gridColumn10.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn10.HeaderText = "USUARIO";
            gridColumn10.Name = "USUARIOColumn";
            gridColumn10.Width = 150;
            gridColumn11.DataPropertyName = "FOLIO_COMPRA";
            gridColumn11.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn11.HeaderText = "RECEPCION";
            gridColumn11.Name = "RECEPCION_Column";
            gridColumn12.DataPropertyName = "FACTURA";
            gridColumn12.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn12.HeaderText = "FACTURA";
            gridColumn12.Name = "FACTURAColumn";
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn7);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn8);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn9);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn10);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn11);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn12);
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(1783, 491);
            this.superGridControl1.TabIndex = 0;
            this.superGridControl1.Text = "Artículos";
            this.superGridControl1.EndEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEditEventArgs>(this.superGridControl1_EndEdit);
            this.superGridControl1.DoubleClick += new System.EventHandler(this.superGridControl1_DoubleClick);
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            this.superGridControl1.Click += new System.EventHandler(this.superGridControl1_click);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1783, 584);
            this.splitContainer1.SplitterDistance = 73;
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
            this.statusLabel.Size = new System.Drawing.Size(1780, 30);
            this.statusLabel.TabIndex = 16;
            this.statusLabel.Text = "Status...";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33407F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22272F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22272F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22049F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarTextBoxX, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateTimeInput1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimeInput2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonX1, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusOrdenCompraComboBoxEx, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1783, 73);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 10);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(58, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Folio:";
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
            this.buscarTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.buscarTextBoxX.Location = new System.Drawing.Point(3, 42);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(553, 25);
            this.buscarTextBoxX.TabIndex = 1;
            this.buscarTextBoxX.TextChanged += new System.EventHandler(this.buscarTextBoxX_TextChanged);
            this.buscarTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxX1_KeyDown);
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(562, 10);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(58, 23);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "Fecha1:";
            // 
            // labelX3
            // 
            this.labelX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(934, 10);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(58, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "Fecha2:";
            // 
            // dateTimeInput1
            // 
            this.dateTimeInput1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.dateTimeInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput1.ButtonDropDown.Visible = true;
            this.dateTimeInput1.IsPopupCalendarOpen = false;
            this.dateTimeInput1.Location = new System.Drawing.Point(562, 42);
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.DisplayMonth = new System.DateTime(2012, 10, 1, 0, 0, 0, 0);
            this.dateTimeInput1.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInput1.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput1.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInput1.Name = "dateTimeInput1";
            this.dateTimeInput1.Size = new System.Drawing.Size(366, 25);
            this.dateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput1.TabIndex = 5;
            this.dateTimeInput1.ValueChanged += new System.EventHandler(this.dateTimeInput1_ValueChanged);
            // 
            // dateTimeInput2
            // 
            this.dateTimeInput2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.dateTimeInput2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput2.ButtonDropDown.Visible = true;
            this.dateTimeInput2.IsPopupCalendarOpen = false;
            this.dateTimeInput2.Location = new System.Drawing.Point(934, 42);
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput2.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.DisplayMonth = new System.DateTime(2012, 10, 1, 0, 0, 0, 0);
            this.dateTimeInput2.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInput2.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput2.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInput2.Name = "dateTimeInput2";
            this.dateTimeInput2.Size = new System.Drawing.Size(366, 25);
            this.dateTimeInput2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput2.TabIndex = 5;
            this.dateTimeInput2.ValueChanged += new System.EventHandler(this.dateTimeInput2_ValueChanged);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(1678, 43);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Text = "Buscar";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // labelX4
            // 
            this.labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(1306, 10);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(58, 23);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "Status:";
            // 
            // statusOrdenCompraComboBoxEx
            // 
            this.statusOrdenCompraComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.statusOrdenCompraComboBoxEx.DisplayMember = "Text";
            this.statusOrdenCompraComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.statusOrdenCompraComboBoxEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusOrdenCompraComboBoxEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusOrdenCompraComboBoxEx.FormattingEnabled = true;
            this.statusOrdenCompraComboBoxEx.ItemHeight = 19;
            this.statusOrdenCompraComboBoxEx.Location = new System.Drawing.Point(1306, 42);
            this.statusOrdenCompraComboBoxEx.Name = "statusOrdenCompraComboBoxEx";
            this.statusOrdenCompraComboBoxEx.Size = new System.Drawing.Size(366, 25);
            this.statusOrdenCompraComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.statusOrdenCompraComboBoxEx.TabIndex = 7;
            this.statusOrdenCompraComboBoxEx.SelectedIndexChanged += new System.EventHandler(this.statusOrdenCompraComboBoxEx_SelectedIndexChanged);
            // 
            // eliminarButtonItem
            // 
            this.eliminarButtonItem.HoverImage = global::SIF.Properties.Resources.Cancel1;
            this.eliminarButtonItem.Image = global::SIF.Properties.Resources.Cancel;
            this.eliminarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.eliminarButtonItem.Name = "eliminarButtonItem";
            this.eliminarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.eliminarButtonItem.Tag = "46";
            this.eliminarButtonItem.Text = "Cancelar \r\n[F8]";
            this.eliminarButtonItem.Click += new System.EventHandler(this.eliminarButtonItem_Click);
            // 
            // imprimirButtonItem
            // 
            this.imprimirButtonItem.HoverImage = global::SIF.Properties.Resources.Printer1;
            this.imprimirButtonItem.Image = global::SIF.Properties.Resources.Printer;
            this.imprimirButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.imprimirButtonItem.Name = "imprimirButtonItem";
            this.imprimirButtonItem.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.compraProveedorButtonItem,
            this.IncidenciasButtonItem,
            //this.talonDePagoButtonItem,
            this.IncidenciasRecepcion,
            this.OrdenCompraCaducidadesItem});
            this.imprimirButtonItem.Tag = "3";
            this.imprimirButtonItem.Text = "Imprimir\r\n ";
            this.imprimirButtonItem.Click += new System.EventHandler(this.imprimirButtonItem_Click);
            // 
            // compraProveedorButtonItem
            // 
            this.compraProveedorButtonItem.Name = "compraProveedorButtonItem";
            this.compraProveedorButtonItem.Text = "Compra Proveedor";
            this.compraProveedorButtonItem.Click += new System.EventHandler(this.compraProveedorButtonItem_Click);
            // 
            // IncidenciasButtonItem
            // 
            this.IncidenciasButtonItem.Name = "IncidenciasButtonItem";
            this.IncidenciasButtonItem.Text = "Incidencias Compras";
            this.IncidenciasButtonItem.Click += new System.EventHandler(this.IncidenciasButtonItem_Click);
            // 
            // talonDePagoButtonItem
            // 
            //this.talonDePagoButtonItem.Name = "talonDePagoButtonItem";
            //this.talonDePagoButtonItem.Text = "Talón de proveedor";
            //this.talonDePagoButtonItem.Click += new System.EventHandler(this.talonDePagoButtonItem_Click);
            // 
            // OrdenCompraCaducidadesItem
            // 
            this.OrdenCompraCaducidadesItem.Name = "OrdenCompraCaducidadesItem";
            this.OrdenCompraCaducidadesItem.Text = "OrdenCompra Caducidades";
            this.OrdenCompraCaducidadesItem.Click += new System.EventHandler(this.OrdenCompraCaducidadesItem_Click);
            // 
            // IncidenciasRecepcion
            // 
            this.IncidenciasRecepcion.Name = "IncidenciasRecepcion";
            this.IncidenciasRecepcion.Text = "Incidencias Recepcion";
            this.IncidenciasRecepcion.Click += new System.EventHandler(this.IncidenciasRecepcionButtonItem_Click);
            // 
            // ControlCaducidadesButtonItem
            // 
            this.ControlCaducidadesButtonItem.HoverImage = global::SIF.Properties.Resources.Date1;
            this.ControlCaducidadesButtonItem.Image = global::SIF.Properties.Resources.Date;
            this.ControlCaducidadesButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.ControlCaducidadesButtonItem.Name = "ControlCaducidadesButtonItem";
            this.ControlCaducidadesButtonItem.Tag = "26";
            this.ControlCaducidadesButtonItem.Text = "Control\r\nCaducidades";
            this.ControlCaducidadesButtonItem.Click += new System.EventHandler(this.ControlCaducidadesButtonItem_Click);
            // 
            // CompraConAjusteButtonItem
            // 
            this.CompraConAjusteButtonItem.HoverImage = global::SIF.Properties.Resources.Download22;
            this.CompraConAjusteButtonItem.Image = global::SIF.Properties.Resources.Download11;
            this.CompraConAjusteButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.CompraConAjusteButtonItem.Name = "CompraConAjusteButtonItem";
            this.CompraConAjusteButtonItem.Tag = "46";
            this.CompraConAjusteButtonItem.Text = "Obtener Ajuste\r\nde HUP";
            this.CompraConAjusteButtonItem.Click += new System.EventHandler(this.CompraConAjusteButtonItem_Click);
            // 
            // ModificacionDeLotesYCaducidadItem
            // 
            this.ModificacionDeLotesYCaducidadItem.HoverImage = global::SIF.Properties.Resources.TableContentsTool1;
            this.ModificacionDeLotesYCaducidadItem.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.ModificacionDeLotesYCaducidadItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.ModificacionDeLotesYCaducidadItem.Name = "ModificacionDeLotesYCaducidadItem";
            this.ModificacionDeLotesYCaducidadItem.Tag = "47";
            this.ModificacionDeLotesYCaducidadItem.Text = "Modificar Lote y\r\nCaducidad";
            this.ModificacionDeLotesYCaducidadItem.Click += new System.EventHandler(this.ModificacionDeLotesYCaducidad_Click);
            // 
            // EdicionButtonItem
            // 
            this.EdicionButtonItem.HoverImage = global::SIF.Properties.Resources.ListView1;
            this.EdicionButtonItem.Image = global::SIF.Properties.Resources.ListView;
            this.EdicionButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.EdicionButtonItem.Name = "EdicionButtonItem";
            
            this.EdicionButtonItem.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.editarButtonItem,
            this.eliminarButtonItem,
            this.unirButtonItem,
            this.dividirButtonItem,
            this.reutilizarButtonItem,
            this.cambiarProveButtonItem,
            this.AsignarModoPagoItem,
            this.cambiarEstadoButtonItem});
            this.EdicionButtonItem.Tag = "25";
            this.EdicionButtonItem.Text = "Editar \r\nOrden";


            // 
            // HerramientasButtonItem
            // 
            this.HerramientasButtonItem.HoverImage = global::SIF.Properties.Resources.Download2;
            this.HerramientasButtonItem.Image = global::SIF.Properties.Resources.Download1;
            this.HerramientasButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.HerramientasButtonItem.Name = "HerramientasButtonItem";
            this.HerramientasButtonItem.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.devolucionProveButtonItem,
            this.reposicionProveButtonItem,            
            this.CompraConAjusteButtonItem
            });
            this.HerramientasButtonItem.Tag = "25";
            this.HerramientasButtonItem.Text = "Herramientas \r\nAdicionales";


            // 
            // CaducidadesButtonItem
            // 
            this.CaducidadesButtonItem.HoverImage = global::SIF.Properties.Resources.Date1;
            this.CaducidadesButtonItem.Image = global::SIF.Properties.Resources.Date;
            this.CaducidadesButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.CaducidadesButtonItem.Name = "CaducidadesButtonItem";
            this.CaducidadesButtonItem.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {            
            this.ControlCaducidadesButtonItem
            });
            this.CaducidadesButtonItem.Tag = "25";
            this.CaducidadesButtonItem.Text = "Caducidades\r\n ";



            //this.EdicionButtonItem.Click += new System.EventHandler(this.editarButtonItem_Click);


            // 
            // editarButtonItem
            // 
            this.editarButtonItem.HoverImage = global::SIF.Properties.Resources.ListView1;
            this.editarButtonItem.Image = global::SIF.Properties.Resources.ListView;
            this.editarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.editarButtonItem.Name = "editarButtonItem";
            this.editarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.editarButtonItem.Tag = "25";
            this.editarButtonItem.Text = "Editar \r\n[F5]";
            this.editarButtonItem.Click += new System.EventHandler(this.editarButtonItem_Click);

            // 
            // LiberarButtonItem
            // 
            this.LiberarButtonItem.HoverImage = global::SIF.Properties.Resources.Download21;
            this.LiberarButtonItem.Image = global::SIF.Properties.Resources.Download12;
            this.LiberarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.LiberarButtonItem.Name = "LiberarButtonItem";
            this.LiberarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlL);
            this.LiberarButtonItem.Tag = "25";
            this.LiberarButtonItem.Text = "Liberar\r\n ";
            this.LiberarButtonItem.Click += new System.EventHandler(this.LiberarButtonItem_Click);

            // 
            // ImportarButtonItem
            // 
            this.ImportarButtonItem.HoverImage = global::SIF.Properties.Resources.TableContentsTool1;
            this.ImportarButtonItem.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.ImportarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.ImportarButtonItem.Name = "ImportarButtonItem";
            this.ImportarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlL);
            this.ImportarButtonItem.Tag = "27";
            this.ImportarButtonItem.Text = "Importar\r\n ";
            this.ImportarButtonItem.Click += new System.EventHandler(this.ImportarButtonItem_Click);

            // 
            // cerrarButtonItem
            // 
            this.cerrarButtonItem.HoverImage = global::SIF.Properties.Resources.LockInformation1;
            this.cerrarButtonItem.Image = global::SIF.Properties.Resources.LockInformation;
            this.cerrarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.cerrarButtonItem.Name = "cerrarButtonItem";
            this.cerrarButtonItem.Tag = "26";
            this.cerrarButtonItem.Text = "Cerrar\r\n ";
            this.cerrarButtonItem.Click += new System.EventHandler(this.cerrarButtonItem_Click);
            // 
            // cambiarProveButtonItem
            // 
            this.cambiarProveButtonItem.HoverImage = global::SIF.Properties.Resources.UserFindTool1;
            this.cambiarProveButtonItem.Image = global::SIF.Properties.Resources.UserFindTool;
            this.cambiarProveButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.cambiarProveButtonItem.Name = "cambiarProveButtonItem";
            this.cambiarProveButtonItem.Tag = "26";
            this.cambiarProveButtonItem.Text = "Cambiar \r\nProveedor ";
            this.cambiarProveButtonItem.Click += new System.EventHandler(this.cambiarProveButtonItem_Click);

            //AsignarModoPagoItem

            this.AsignarModoPagoItem.HoverImage = global::SIF.Properties.Resources.Payments1;
            this.AsignarModoPagoItem.Image = global::SIF.Properties.Resources.Payments;
            this.AsignarModoPagoItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.AsignarModoPagoItem.Name = "AsignarModoPagoItem";
            this.AsignarModoPagoItem.Tag = "26";
            this.AsignarModoPagoItem.Text = "Asignar \r\nModo Pago";
            this.AsignarModoPagoItem.Click += new System.EventHandler(this.AsignarModoPagoItem_Click);
            // 
            // cambiarEstadoButtonItem
            // 
            this.cambiarEstadoButtonItem.HoverImage = global::SIF.Properties.Resources.ABRIR1;
            this.cambiarEstadoButtonItem.Image = global::SIF.Properties.Resources.ABRIR;
            this.cambiarEstadoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.cambiarEstadoButtonItem.Name = "cambiarEstadoButtonItem";
            this.cambiarEstadoButtonItem.Tag = "26";
            this.cambiarEstadoButtonItem.Text = "Cambiar a \r\nEstado E ";
            this.cambiarEstadoButtonItem.Click += new System.EventHandler(this.cambiarEstButtonItem_Click);
            // 
            // devolucionProveButtonItem
            // 
            this.devolucionProveButtonItem.HoverImage = global::SIF.Properties.Resources.compraLogoDevHover;
            this.devolucionProveButtonItem.Image = global::SIF.Properties.Resources.compraLogoDev;
            this.devolucionProveButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.devolucionProveButtonItem.Name = "devolucionProveButtonItem";
            this.devolucionProveButtonItem.Tag = "26";
            this.devolucionProveButtonItem.Text = "Devolucion\r\nProveedor ";
            this.devolucionProveButtonItem.Click += new System.EventHandler(this.devolucionProveButtonItem_Click);
            // 
            // reposicionProveButtonItem
            // 
            this.reposicionProveButtonItem.HoverImage = global::SIF.Properties.Resources.compraLogoRepoHover;
            this.reposicionProveButtonItem.Image = global::SIF.Properties.Resources.compraLogoRepo;
            this.reposicionProveButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.reposicionProveButtonItem.Name = "reposicionProveButtonItem";
            this.reposicionProveButtonItem.Tag = "26";
            this.reposicionProveButtonItem.Text = "Reposicion \r\nProveedor ";
            this.reposicionProveButtonItem.Click += new System.EventHandler(this.reposicionProveButtonItem_Click);
            // 
            // facturaButtonItem
            // 
            this.facturaButtonItem.HoverImage = global::SIF.Properties.Resources.Cancel1;
            this.facturaButtonItem.Image = global::SIF.Properties.Resources.Cancel;
            this.facturaButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.facturaButtonItem.Name = "facturaButtonItem";
            this.facturaButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.facturaButtonItem.Text = "Factura\r\n ";
            // 
            // unirButtonItem
            // 
            this.unirButtonItem.HoverImage = global::SIF.Properties.Resources.Merge1;
            this.unirButtonItem.Image = global::SIF.Properties.Resources.Merge;
            this.unirButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.unirButtonItem.Name = "unirButtonItem";
            this.unirButtonItem.Tag = "21";
            this.unirButtonItem.Text = "Unir\r\n ";
            this.unirButtonItem.Click += new System.EventHandler(this.unirButtonItem_Click);
            // 
            // dividirButtonItem
            // 
            this.dividirButtonItem.HoverImage = global::SIF.Properties.Resources.Split1;
            this.dividirButtonItem.Image = global::SIF.Properties.Resources.Split;
            this.dividirButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.dividirButtonItem.Name = "dividirButtonItem";
            this.dividirButtonItem.Tag = "20";
            this.dividirButtonItem.Text = "Dividir\r\n ";
            this.dividirButtonItem.Click += new System.EventHandler(this.dividirButtonItem_Click);
            // 
            // cuentasPorPagarbuttonItem
            // 
            this.cuentasPorPagarbuttonItem.HoverImage = global::SIF.Properties.Resources.Payments;
            this.cuentasPorPagarbuttonItem.Image = global::SIF.Properties.Resources.Payments1;
            this.cuentasPorPagarbuttonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.cuentasPorPagarbuttonItem.Name = "cuentasPorPagarbuttonItem";
            this.cuentasPorPagarbuttonItem.Tag = "3";
            this.cuentasPorPagarbuttonItem.Text = "Ctas Pagar\r\n ";
            this.cuentasPorPagarbuttonItem.Visible = false;
            this.cuentasPorPagarbuttonItem.Click += new System.EventHandler(this.cuentasPorPagarbuttonItem_Click);
            // 
            // recibirButtonItem
            // 
            this.recibirButtonItem.HoverImage = global::SIF.Properties.Resources.BoxNewTool1;
            this.recibirButtonItem.Image = global::SIF.Properties.Resources.BoxNewTool;
            this.recibirButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.recibirButtonItem.Name = "recibirButtonItem";
            this.recibirButtonItem.Tag = "26";
            this.recibirButtonItem.Text = "Recepción\r\n ";
            this.recibirButtonItem.Click += new System.EventHandler(this.recibirButtonItem_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.HoverImage = global::SIF.Properties.Resources.Cancel1;
            this.buttonItem2.Image = global::SIF.Properties.Resources.Cancel;
            this.buttonItem2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.buttonItem2.Tag = "26";
            this.buttonItem2.Text = "Cerrar\r\n ";
            // 
            // preciosButtonItem
            // 
            this.preciosButtonItem.HoverImage = global::SIF.Properties.Resources.Bid1;
            this.preciosButtonItem.Image = global::SIF.Properties.Resources.Bid;
            this.preciosButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.preciosButtonItem.Name = "preciosButtonItem";
            this.preciosButtonItem.Tag = "26";
            this.preciosButtonItem.Text = "Precios\r\n ";
            this.preciosButtonItem.Click += new System.EventHandler(this.preciosButtonItem_Click);
            // 
            // asociarFacturasButtonItem
            // 
            this.asociarFacturasButtonItem.HoverImage = global::SIF.Properties.Resources.CertificateAdd1;
            this.asociarFacturasButtonItem.Image = global::SIF.Properties.Resources.CertificateAdd;
            this.asociarFacturasButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.asociarFacturasButtonItem.Name = "asociarFacturasButtonItem";
            this.asociarFacturasButtonItem.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.desAsociarButtonItem,
            this.facturaAutomaticaButtonItem});
            this.asociarFacturasButtonItem.Text = "Factura\r\n ";
            this.asociarFacturasButtonItem.Click += new System.EventHandler(this.asociarFacturasButtonItem_Click);
            // 
            // desAsociarButtonItem
            // 
            this.desAsociarButtonItem.Name = "desAsociarButtonItem";
            this.desAsociarButtonItem.Text = "Desasociar";
            this.desAsociarButtonItem.Click += new System.EventHandler(this.desAsociarButtonItem_Click);
            // 
            // facturaAutomaticaButtonItem
            // 
            this.facturaAutomaticaButtonItem.HoverImage = global::SIF.Properties.Resources.facturar1;
            this.facturaAutomaticaButtonItem.Image = global::SIF.Properties.Resources.Facturar;
            this.facturaAutomaticaButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.facturaAutomaticaButtonItem.Name = "facturaAutomaticaButtonItem";
            this.facturaAutomaticaButtonItem.Text = "Factura\r\nAutomática";
            this.facturaAutomaticaButtonItem.Click += new System.EventHandler(this.facturaAutomaticaButtonItem_Click);
            // 
            // loteCaducidadButtonItem
            // 
            this.loteCaducidadButtonItem.HoverImage = global::SIF.Properties.Resources.Date1;
            this.loteCaducidadButtonItem.Image = global::SIF.Properties.Resources.Date;
            this.loteCaducidadButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.loteCaducidadButtonItem.Name = "loteCaducidadButtonItem";
            this.loteCaducidadButtonItem.Tag = "26";
            this.loteCaducidadButtonItem.Text = "Lote\r\nCaducidad";
            this.loteCaducidadButtonItem.Click += new System.EventHandler(this.loteCaducidadButtonItem_Click);
            // 
            // reutilizarButtonItem
            // 
            this.reutilizarButtonItem.HoverImage = global::SIF.Properties.Resources.U_turn1;
            this.reutilizarButtonItem.Image = global::SIF.Properties.Resources.U_turn;
            this.reutilizarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.reutilizarButtonItem.Name = "reutilizarButtonItem";
            this.reutilizarButtonItem.Tag = "20";
            this.reutilizarButtonItem.Text = "Reutilizar\r\n ";
            this.reutilizarButtonItem.Click += new System.EventHandler(this.reutilizarButtonItem_Click);
            // 
            // OrdenesCompraUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "OrdenesCompraUserControl";
            this.Size = new System.Drawing.Size(1876, 752);
            this.Load += new System.EventHandler(this.VentasPagoUserControl_Load);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.ComponentModel.BackgroundWorker porEOQAutomaticaBackgroundWorker;
        private DevComponents.DotNetBar.ButtonItem eliminarButtonItem;
        private DevComponents.DotNetBar.ButtonItem imprimirButtonItem;
        private DevComponents.DotNetBar.ButtonItem editarButtonItem;
        private DevComponents.DotNetBar.ButtonItem LiberarButtonItem;
        private DevComponents.DotNetBar.ButtonItem ImportarButtonItem;
        private DevComponents.DotNetBar.ButtonItem EdicionButtonItem;
        private DevComponents.DotNetBar.ButtonItem HerramientasButtonItem;
        private DevComponents.DotNetBar.ButtonItem CaducidadesButtonItem;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput2;
        private DevComponents.DotNetBar.ButtonItem cerrarButtonItem;
        private DevComponents.DotNetBar.ButtonItem cambiarProveButtonItem;
        private DevComponents.DotNetBar.ButtonItem AsignarModoPagoItem;
        private DevComponents.DotNetBar.ButtonItem devolucionProveButtonItem;
        private DevComponents.DotNetBar.ButtonItem reposicionProveButtonItem;
        private DevComponents.DotNetBar.ButtonItem cambiarEstadoButtonItem;
        // private DevComponents.DotNetBar.ButtonItem bonificacionProveButtonItem;
        private DevComponents.DotNetBar.ButtonItem facturaButtonItem;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx statusOrdenCompraComboBoxEx;
        private DevComponents.DotNetBar.ButtonItem unirButtonItem;
        private DevComponents.DotNetBar.ButtonItem dividirButtonItem;
        private DevComponents.DotNetBar.ButtonItem cuentasPorPagarbuttonItem;
        private DevComponents.DotNetBar.ButtonItem recibirButtonItem;
        private DevComponents.DotNetBar.ButtonItem ControlCaducidadesButtonItem;
        private DevComponents.DotNetBar.ButtonItem CompraConAjusteButtonItem;
        private DevComponents.DotNetBar.ButtonItem ModificacionDeLotesYCaducidadItem;
        private DevComponents.DotNetBar.ButtonItem preciosButtonItem;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem asociarFacturasButtonItem;
        private DevComponents.DotNetBar.ButtonItem facturaAutomaticaButtonItem;
        private DevComponents.DotNetBar.ButtonItem loteCaducidadButtonItem;
        private DevComponents.DotNetBar.ButtonItem reutilizarButtonItem;
        private DevComponents.DotNetBar.ButtonItem desAsociarButtonItem;
        private DevComponents.DotNetBar.ButtonItem compraProveedorButtonItem;
        //private DevComponents.DotNetBar.ButtonItem talonDePagoButtonItem;
        private DevComponents.DotNetBar.ButtonItem OrdenCompraCaducidadesItem;
        private DevComponents.DotNetBar.ButtonItem IncidenciasRecepcionButtonItem;
        private DevComponents.DotNetBar.ButtonItem IncidenciasButtonItem;
        private DevComponents.DotNetBar.ButtonItem IncidenciasRecepcion;
    }
}
