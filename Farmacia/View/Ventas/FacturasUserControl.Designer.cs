namespace SIF.View.Ventas
{
    partial class FacturasUserControl
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cancelarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.facturarRemisionesDiaButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.NuevoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.totalLabelX = new DevComponents.DotNetBar.LabelX();
            this.totalesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.vistaPreviaButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.porReferenciaButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.vistaPreviaButtonItem,
            this.porReferenciaButtonItem,
            this.NuevoButtonItem,
            this.cancelarButtonItem,
            this.facturarRemisionesDiaButtonItem});
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(159, 32);
            this.titleLabel.Text = "SIF\\FACTURAS";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            gridColumn1.DataPropertyName = "NUM_REMISION";
            gridColumn1.HeaderText = "REMISION";
            gridColumn1.Name = "NUMERO_REMISIONColumn";
            gridColumn1.Width = 120;
            gridColumn2.DataPropertyName = "FECHA_VTA";
            gridColumn2.HeaderText = "FECHA DE VENTA";
            gridColumn2.Name = "FECHA_VENTAColumn";
            gridColumn2.Width = 130;
            gridColumn3.DataPropertyName = "SUBTOTAL";
            gridColumn3.HeaderText = "SUB TOTAL";
            gridColumn3.Name = "SUBTOTALColumn";
            gridColumn4.DataPropertyName = "IMPUESTO_IVA";
            gridColumn4.HeaderText = "IMPUESTO";
            gridColumn4.Name = "IMPUESTOColumn";
            gridColumn5.DataPropertyName = "DESCUENTO";
            gridColumn5.HeaderText = "DESCUENTO";
            gridColumn5.Name = "DESCUENTOColumn";
            gridColumn6.DataPropertyName = "TOTAL";
            gridColumn6.HeaderText = "TOTAL";
            gridColumn6.Name = "TOTALColumn";
            gridColumn7.DataPropertyName = "NUM_FACTURA";
            gridColumn7.HeaderText = "FACTURA";
            gridColumn7.Name = "FACTURAColumn";
            gridColumn8.DataPropertyName = "ACTIVO";
            gridColumn8.HeaderText = "STATUS";
            gridColumn8.Name = "ACTIVAColumn";
            gridColumn9.DataPropertyName = "CONDICIONES";
            gridColumn9.HeaderText = "CONDICIONES";
            gridColumn9.Name = "CONDICIONESColumn";
            gridColumn9.Width = 150;
            gridColumn10.DataPropertyName = "NumeroFactura";
            gridColumn10.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn10.HeaderText = "UUID";
            gridColumn10.Name = "";
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
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(915, 490);
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(915, 560);
            this.splitContainer1.SplitterDistance = 50;
            // 
            // statusLabel
            // 
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.statusLabel.Location = new System.Drawing.Point(67, 734);
            this.statusLabel.Size = new System.Drawing.Size(520, 14);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 13);
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
            this.buscarTextBoxX.Location = new System.Drawing.Point(73, 12);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(752, 25);
            this.buscarTextBoxX.TabIndex = 1;
            this.buscarTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxX1_KeyDown);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(831, 13);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Text = "Buscar";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // cancelarButtonItem
            // 
            this.cancelarButtonItem.Image = global::SIF.Properties.Resources.Cancel;
            this.cancelarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.cancelarButtonItem.Name = "cancelarButtonItem";
            this.cancelarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.cancelarButtonItem.Tag = "4";
            this.cancelarButtonItem.Text = "Cancelar \r\n[F8]";
            this.cancelarButtonItem.Click += new System.EventHandler(this.cancelarButtonItem_Click);
            // 
            // facturarRemisionesDiaButtonItem
            // 
            this.facturarRemisionesDiaButtonItem.HoverImage = global::SIF.Properties.Resources.Grouping1;
            this.facturarRemisionesDiaButtonItem.Image = global::SIF.Properties.Resources.Grouping;
            this.facturarRemisionesDiaButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.facturarRemisionesDiaButtonItem.Name = "facturarRemisionesDiaButtonItem";
            this.facturarRemisionesDiaButtonItem.Tag = "18";
            this.facturarRemisionesDiaButtonItem.Text = "Remisiones\r\n ";
            this.facturarRemisionesDiaButtonItem.Click += new System.EventHandler(this.facturarRemisionesDiaButtonItem_Click);
            // 
            // NuevoButtonItem
            // 
            this.NuevoButtonItem.HoverImage = global::SIF.Properties.Resources.NewDocument1;
            this.NuevoButtonItem.Image = global::SIF.Properties.Resources.NewDocument;
            this.NuevoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.NuevoButtonItem.Name = "NuevoButtonItem";
            this.NuevoButtonItem.Tag = "17";
            this.NuevoButtonItem.Text = "Refacturar \r\n[F2]";
            this.NuevoButtonItem.Click += new System.EventHandler(this.NuevoButtonItem_Click);
            // 
            // totalLabelX
            // 
            this.totalLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.totalLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.totalLabelX.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabelX.Location = new System.Drawing.Point(831, 704);
            this.totalLabelX.Name = "totalLabelX";
            this.totalLabelX.Size = new System.Drawing.Size(139, 23);
            this.totalLabelX.TabIndex = 21;
            this.totalLabelX.Text = "TOTAL: $0.00";
            this.totalLabelX.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // totalesFlowLayoutPanel
            // 
            this.totalesFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.totalesFlowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.totalesFlowLayoutPanel.Location = new System.Drawing.Point(67, 704);
            this.totalesFlowLayoutPanel.Name = "totalesFlowLayoutPanel";
            this.totalesFlowLayoutPanel.Size = new System.Drawing.Size(758, 30);
            this.totalesFlowLayoutPanel.TabIndex = 22;
            // 
            // vistaPreviaButtonItem
            // 
            this.vistaPreviaButtonItem.Image = global::SIF.Properties.Resources.EditDocument1;
            this.vistaPreviaButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.vistaPreviaButtonItem.Name = "vistaPreviaButtonItem";
            this.vistaPreviaButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.vistaPreviaButtonItem.Tag = "4";
            this.vistaPreviaButtonItem.Text = "Vista Previa\r\n ";
            this.vistaPreviaButtonItem.Click += new System.EventHandler(this.vistaPreviaButtonItem_Click);
            // 
            // porReferenciaButtonItem
            // 
            this.porReferenciaButtonItem.Image = global::SIF.Properties.Resources.EditDocument1;
            this.porReferenciaButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.porReferenciaButtonItem.Name = "porReferenciaButtonItem";
            this.porReferenciaButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.porReferenciaButtonItem.Tag = "4";
            this.porReferenciaButtonItem.Text = "Por Referencia\r\n ";
            this.porReferenciaButtonItem.Click += new System.EventHandler(this.porReferenciaButtonItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Total facturado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "IVA por facturar:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "$";
            // 
            // FacturasUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalLabelX);
            this.Controls.Add(this.totalesFlowLayoutPanel);
            this.Name = "FacturasUserControl";
            this.Load += new System.EventHandler(this.VentasPagoUserControl_Load);
            this.Controls.SetChildIndex(this.totalesFlowLayoutPanel, 0);
            this.Controls.SetChildIndex(this.totalLabelX, 0);
            this.Controls.SetChildIndex(this.statusLabel, 0);
            this.Controls.SetChildIndex(this.titleLabel, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.Controls.SetChildIndex(this.bar1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
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
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevComponents.DotNetBar.ButtonItem cancelarButtonItem;
        private DevComponents.DotNetBar.ButtonItem facturarRemisionesDiaButtonItem;
        private DevComponents.DotNetBar.ButtonItem NuevoButtonItem;
        private DevComponents.DotNetBar.LabelX totalLabelX;
        private System.Windows.Forms.FlowLayoutPanel totalesFlowLayoutPanel;
        private DevComponents.DotNetBar.ButtonItem vistaPreviaButtonItem;
        private DevComponents.DotNetBar.ButtonItem porReferenciaButtonItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
