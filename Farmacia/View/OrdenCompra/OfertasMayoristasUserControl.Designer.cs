namespace SIF.View.OrdenCompra
{
    partial class OfertasMayoristasUserControl
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn14 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn15 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn16 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn17 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn18 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.imprimirButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.exportarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.incidenciasButtonItem = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.imprimirButtonItem,
            this.exportarButtonItem,
            this.incidenciasButtonItem});
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(361, 32);
            this.titleLabel.Text = "COMPRAS\\OFERTAS MAYORISTAS";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            gridColumn10.DataPropertyName = "CODIGO";
            gridColumn10.HeaderText = "CODIGO";
            gridColumn10.Name = "";
            gridColumn10.Width = 120;
            gridColumn11.DataPropertyName = "DESCRIPCION";
            gridColumn11.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn11.HeaderText = "DESCRIPCION";
            gridColumn11.Name = "";
            gridColumn11.Width = 250;
            gridColumn12.DataPropertyName = "LINEA";
            gridColumn12.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn12.HeaderText = "LINEA";
            gridColumn12.Name = "";
            gridColumn13.DataPropertyName = "CATEGORIA_INTERNA";
            gridColumn13.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn13.HeaderText = "TIPO";
            gridColumn13.Name = "";
            gridColumn14.DataPropertyName = "EOQ";
            gridColumn14.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn14.HeaderText = "EOQ";
            gridColumn14.Name = "";
            gridColumn14.Width = 80;
            gridColumn15.DataPropertyName = "SABA_OFERTA";
            gridColumn15.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn15.HeaderText = "SABA";
            gridColumn15.Name = "";
            gridColumn16.DataPropertyName = "DROGUEROS_OFERTA";
            gridColumn16.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn16.HeaderText = "DROGUEROS";
            gridColumn16.Name = "";
            gridColumn17.DataPropertyName = "NADRO_OFERTA";
            gridColumn17.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn17.HeaderText = "NADRO";
            gridColumn17.Name = "";
            gridColumn18.DataPropertyName = "MARZAM_OFERTA";
            gridColumn18.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn18.HeaderText = "MARZAM";
            gridColumn18.Name = "";
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn10);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn11);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn12);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn13);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn14);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn15);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn16);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn17);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn18);
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.ShowTreeButtons = true;
            this.superGridControl1.PrimaryGrid.ShowTreeLines = true;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(915, 514);
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.SplitterDistance = 50;
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarTextBoxX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarButtonX, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 50);
            this.tableLayoutPanel1.TabIndex = 1;
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
            this.labelX1.Size = new System.Drawing.Size(34, 23);
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
            this.buscarTextBoxX.Location = new System.Drawing.Point(43, 12);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(789, 25);
            this.buscarTextBoxX.TabIndex = 1;
            this.buscarTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buscarTextBoxX_KeyDown);
            // 
            // buscarButtonX
            // 
            this.buscarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buscarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buscarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buscarButtonX.Location = new System.Drawing.Point(838, 13);
            this.buscarButtonX.Name = "buscarButtonX";
            this.buscarButtonX.Size = new System.Drawing.Size(74, 23);
            this.buscarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buscarButtonX.TabIndex = 2;
            this.buscarButtonX.Text = "Buscar";
            this.buscarButtonX.Click += new System.EventHandler(this.buscarButtonX_Click);
            // 
            // imprimirButtonItem
            // 
            this.imprimirButtonItem.HoverImage = global::SIF.Properties.Resources.Printer1;
            this.imprimirButtonItem.Image = global::SIF.Properties.Resources.Printer;
            this.imprimirButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.imprimirButtonItem.Name = "imprimirButtonItem";
            this.imprimirButtonItem.Tag = "3";
            this.imprimirButtonItem.Text = "Imprimir\r\n ";
            this.imprimirButtonItem.Click += new System.EventHandler(this.imprimirButtonItem_Click);
            // 
            // exportarButtonItem
            // 
            this.exportarButtonItem.HoverImage = global::SIF.Properties.Resources.Export1;
            this.exportarButtonItem.Image = global::SIF.Properties.Resources.Export;
            this.exportarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.exportarButtonItem.Name = "exportarButtonItem";
            this.exportarButtonItem.Tag = "3";
            this.exportarButtonItem.Text = "Exportar\r\n ";
            this.exportarButtonItem.Click += new System.EventHandler(this.exportarButtonItem_Click);
            // 
            // incidenciasButtonItem
            // 
            this.incidenciasButtonItem.HoverImage = global::SIF.Properties.Resources.Printer1;
            this.incidenciasButtonItem.Image = global::SIF.Properties.Resources.Printer;
            this.incidenciasButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.incidenciasButtonItem.Name = "incidenciasButtonItem";
            this.incidenciasButtonItem.Tag = "3";
            this.incidenciasButtonItem.Text = "Incidencias\r\n ";
            this.incidenciasButtonItem.Click += new System.EventHandler(this.incidenciasButtonItem_Click);
            // 
            // OfertasMayoristasUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "OfertasMayoristasUserControl";
            this.Load += new System.EventHandler(this.RecepcionOrdenCompraUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
        private DevComponents.DotNetBar.ButtonItem imprimirButtonItem;
        private DevComponents.DotNetBar.ButtonItem exportarButtonItem;
        private DevComponents.DotNetBar.ButtonItem incidenciasButtonItem;
    }
}
