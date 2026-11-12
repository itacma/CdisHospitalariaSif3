namespace SIF.View.Almacen
{
    partial class ConsultaOrdenesCompraUserControl
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
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
            this.facturaButtonItem = new DevComponents.DotNetBar.ButtonItem();
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
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(488, 32);
            this.titleLabel.Text = "ALMACEN\\CONSULTA ORDENES DE COMPRA";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            gridColumn1.DataPropertyName = "FOLIO_OC_ID";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn1.HeaderText = "FOLIO";
            gridColumn1.Name = "FOLIOColumn";
            gridColumn1.Width = 120;
            gridColumn2.DataPropertyName = "PROVEEDOR_ID";
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn2.HeaderText = "PROVEEDOR ID";
            gridColumn2.Name = "PROVEEDOR_IDColumn";
            gridColumn3.DataPropertyName = "CAT_CLIENTES_NOMBRE";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn3.HeaderText = "PROVEEDOR";
            gridColumn3.Name = "PROVEEDORColumn";
            gridColumn3.Width = 170;
            gridColumn4.DataPropertyName = "SUCURSAL_ID";
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn4.HeaderText = "SUCURSAL";
            gridColumn4.Name = "SUCURSAL";
            gridColumn5.DataPropertyName = "FECHA_ALTA";
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn5.HeaderText = "ALTA";
            gridColumn5.Name = "FECHA_ALTAColumn";
            gridColumn5.Width = 130;
            gridColumn6.DataPropertyName = "FECHA_RECEPCION";
            gridColumn6.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn6.HeaderText = "RECEPCION";
            gridColumn6.Name = "FECHA_RECEPCIONColumn";
            gridColumn6.Width = 130;
            gridColumn7.DataPropertyName = "FECHA_CIERRE";
            gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn7.HeaderText = "CIERRE";
            gridColumn7.Name = "CIERREColumn";
            gridColumn7.Width = 130;
            gridColumn8.DataPropertyName = "ESTADO_OC";
            gridColumn8.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn8.HeaderText = "ESTADO";
            gridColumn8.Name = "ESTADO_OC_COLUMN";
            gridColumn8.Width = 70;
            gridColumn9.DataPropertyName = "CAT_USUARIOS_NOMBRE";
            gridColumn9.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn9.HeaderText = "USUARIO";
            gridColumn9.Name = "USUARIOColumn";
            gridColumn9.Width = 150;
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn7);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn8);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn9);
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(915, 491);
            this.superGridControl1.DoubleClick += new System.EventHandler(this.superGridControl1_DoubleClick);
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.SplitterDistance = 73;
            // 
            // statusLabel
            // 
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33407F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22272F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22272F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22049F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 73);
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
            this.buscarTextBoxX.Size = new System.Drawing.Size(271, 25);
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
            this.labelX2.Location = new System.Drawing.Point(280, 10);
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
            this.labelX3.Location = new System.Drawing.Point(464, 10);
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
            this.dateTimeInput1.Location = new System.Drawing.Point(280, 42);
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
            this.dateTimeInput1.Size = new System.Drawing.Size(178, 25);
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
            this.dateTimeInput2.Location = new System.Drawing.Point(464, 42);
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
            this.dateTimeInput2.Size = new System.Drawing.Size(178, 25);
            this.dateTimeInput2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput2.TabIndex = 5;
            this.dateTimeInput2.ValueChanged += new System.EventHandler(this.dateTimeInput2_ValueChanged);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(832, 43);
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
            this.labelX4.Location = new System.Drawing.Point(648, 10);
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
            this.statusOrdenCompraComboBoxEx.FormattingEnabled = true;
            this.statusOrdenCompraComboBoxEx.ItemHeight = 19;
            this.statusOrdenCompraComboBoxEx.Location = new System.Drawing.Point(648, 42);
            this.statusOrdenCompraComboBoxEx.Name = "statusOrdenCompraComboBoxEx";
            this.statusOrdenCompraComboBoxEx.Size = new System.Drawing.Size(178, 25);
            this.statusOrdenCompraComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.statusOrdenCompraComboBoxEx.TabIndex = 7;
            this.statusOrdenCompraComboBoxEx.SelectedIndexChanged += new System.EventHandler(this.statusOrdenCompraComboBoxEx_SelectedIndexChanged);
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
            // ConsultaOrdenesCompraUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ConsultaOrdenesCompraUserControl";
            this.Load += new System.EventHandler(this.VentasPagoUserControl_Load);
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
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput2;
        private DevComponents.DotNetBar.ButtonItem facturaButtonItem;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx statusOrdenCompraComboBoxEx;
    }
}
