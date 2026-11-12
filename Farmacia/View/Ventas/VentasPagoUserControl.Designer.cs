namespace SIF.View.Ventas
{
    partial class VentasPagoUserControl
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
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonItem = new DevComponents.DotNetBar.ButtonItem();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imprimeTicketButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.tiempoAireButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.taeButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.multiRecargasButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.facturaButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem,
            this.tiempoAireButtonItem,
            this.imprimeTicketButtonItem,
            this.facturaButtonItem,
            this.buttonItem1});
            this.bar1.Size = new System.Drawing.Size(793, 92);
            this.bar1.ItemClick += new System.EventHandler(this.bar1_ItemClick);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(270, 32);
            this.titleLabel.Text = "SIF\\PAGOS DE REMISION";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            gridColumn1.DataPropertyName = "NUM_REMISION";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn1.HeaderText = "REMISION";
            gridColumn1.Name = "NUMERO_REMISIONColumn";
            gridColumn1.Width = 120;
            gridColumn2.DataPropertyName = "FECHA_VTA";
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn2.HeaderText = "FECHA DE VENTA";
            gridColumn2.Name = "FECHA_VENTAColumn";
            gridColumn3.DataPropertyName = "SUBTOTAL";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn3.HeaderText = "SUB TOTAL";
            gridColumn3.Name = "SUBTOTALColumn";
            gridColumn4.DataPropertyName = "IMPUESTO_IVA";
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn4.HeaderText = "IMPUESTO";
            gridColumn4.Name = "IMPUESTOColumn";
            gridColumn5.DataPropertyName = "DESCUENTO";
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn5.HeaderText = "DESCUENTO";
            gridColumn5.Name = "DESCUENTOColumn";
            gridColumn6.DataPropertyName = "TOTAL";
            gridColumn6.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn6.HeaderText = "TOTAL";
            gridColumn6.Name = "TOTALColumn";
            gridColumn7.DataPropertyName = "FACTURA";
            gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn7.HeaderText = "FACTURA";
            gridColumn7.Name = "FACTURAColumn";
            gridColumn8.DataPropertyName = "ACTIVO";
            gridColumn8.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn8.HeaderText = "STATUS";
            gridColumn8.Name = "ACTIVAColumn";
            gridColumn9.DataPropertyName = "CONDICIONES";
            gridColumn9.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn9.HeaderText = "CONDICIONES";
            gridColumn9.Name = "CONDICIONESColumn";
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
            this.superGridControl1.Size = new System.Drawing.Size(915, 512);
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            this.superGridControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.superGridControl1_MouseDoubleClick);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.SplitterDistance = 52;
            this.splitContainer1.TabStop = false;
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
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarTextBoxX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonX1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 52);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 14);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(58, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Remision:";
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
            this.buscarTextBoxX.Location = new System.Drawing.Point(73, 13);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(752, 25);
            this.buscarTextBoxX.TabIndex = 0;
            this.buscarTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxX1_KeyDown);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(831, 14);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Text = "Buscar";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonItem
            // 
            this.buttonItem.Image = global::SIF.Properties.Resources.FundTool;
            this.buttonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem.Name = "buttonItem";
            this.buttonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.buttonItem.Text = "Pago \r\n[F5]";
            this.buttonItem.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // imprimeTicketButtonItem
            // 
            this.imprimeTicketButtonItem.HoverImage = global::SIF.Properties.Resources.Printer1;
            this.imprimeTicketButtonItem.Image = global::SIF.Properties.Resources.Printer;
            this.imprimeTicketButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.imprimeTicketButtonItem.Name = "imprimeTicketButtonItem";
            this.imprimeTicketButtonItem.Text = "TICKET\r\n ";
            this.imprimeTicketButtonItem.Click += new System.EventHandler(this.imprimeTicketButtonItem_Click);
            // 
            // tiempoAireButtonItem
            // 
            this.tiempoAireButtonItem.Image = global::SIF.Properties.Resources.MobileTool;
            this.tiempoAireButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.tiempoAireButtonItem.Name = "tiempoAireButtonItem";
            this.tiempoAireButtonItem.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.taeButtonItem,
            this.multiRecargasButtonItem});
            this.tiempoAireButtonItem.Text = "TAE\r\n ";
            // 
            // taeButtonItem
            // 
            this.taeButtonItem.HoverImage = global::SIF.Properties.Resources.TAE1;
            this.taeButtonItem.Image = global::SIF.Properties.Resources.TAE;
            this.taeButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.taeButtonItem.Name = "taeButtonItem";
            this.taeButtonItem.Text = "Telcel";
            this.taeButtonItem.Click += new System.EventHandler(this.taeButtonItem_Click);
            // 
            // multiRecargasButtonItem
            // 
            this.multiRecargasButtonItem.HoverImage = global::SIF.Properties.Resources.MultiRecargas1;
            this.multiRecargasButtonItem.Image = global::SIF.Properties.Resources.MultiRecargas;
            this.multiRecargasButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.multiRecargasButtonItem.Name = "multiRecargasButtonItem";
            this.multiRecargasButtonItem.Text = "Multirecargas";
            this.multiRecargasButtonItem.Click += new System.EventHandler(this.multiRecargasButtonItem_Click);
            // 
            // facturaButtonItem
            // 
            this.facturaButtonItem.HoverImage = global::SIF.Properties.Resources.facturar1;
            this.facturaButtonItem.Image = global::SIF.Properties.Resources.Facturar;
            this.facturaButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.facturaButtonItem.Name = "facturaButtonItem";
            this.facturaButtonItem.Text = "FACTURA\r\n ";
            this.facturaButtonItem.Click += new System.EventHandler(this.facturaButtonItem_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.HoverImage = global::SIF.Properties.Resources.TAE1;
            this.buttonItem1.Image = global::SIF.Properties.Resources.TAE;
            this.buttonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "CONSULTA\r\n ";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click_1);
            // 
            // VentasPagoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "VentasPagoUserControl";
            this.Load += new System.EventHandler(this.VentasPagoUserControl_Load);
            this.Leave += new System.EventHandler(this.VentasPagoUserControl_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.ButtonItem buttonItem;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevComponents.DotNetBar.ButtonItem imprimeTicketButtonItem;
        private DevComponents.DotNetBar.ButtonItem tiempoAireButtonItem;
        private DevComponents.DotNetBar.ButtonItem taeButtonItem;
        private DevComponents.DotNetBar.ButtonItem multiRecargasButtonItem;
        private DevComponents.DotNetBar.ButtonItem facturaButtonItem;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
    }
}
