namespace SIF.View.Ventas
{
    partial class ApartadoEspecialUserControl
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.LabelX labelX2;
            DevComponents.DotNetBar.LabelX labelX1;
            DevComponents.DotNetBar.LabelX labelX3;
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn14 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn15 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn16 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn17 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SKUtextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.vendedorLabelX = new DevComponents.DotNetBar.LabelX();
            this.clienteLabelX = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.folioVentaLabelX = new DevComponents.DotNetBar.LabelX();
            this.superGridControl2 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            labelX3 = new DevComponents.DotNetBar.LabelX();
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
            this.buttonItem1});
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.bar1.Size = new System.Drawing.Size(944, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(353, 32);
            this.titleLabel.Text = "SIF\\Apartado Especial en Sucursal";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            gridColumn1.HeaderText = "SELECT";
            gridColumn1.Name = "";
            gridColumn1.Width = 60;
            gridColumn2.HeaderText = "CLAVE APARTADO";
            gridColumn2.Name = "";
            gridColumn2.Width = 110;
            gridColumn3.HeaderText = "FECHA APARTADO";
            gridColumn3.Name = "";
            gridColumn3.Width = 120;
            gridColumn4.HeaderText = "CLAVE DEL CLIENTE";
            gridColumn4.Name = "";
            gridColumn4.Width = 150;
            gridColumn5.HeaderText = "NOMBRE COMPLETO DEL CLIENTE";
            gridColumn5.Name = "";
            gridColumn5.Width = 250;
            gridColumn6.HeaderText = "CANTIDAD";
            gridColumn6.Name = "";
            gridColumn7.HeaderText = "DESCUENTO";
            gridColumn7.Name = "";
            gridColumn8.HeaderText = "TOTAL";
            gridColumn8.Name = "";
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn7);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn8);
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(930, 409);
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(64, 145);
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.superGridControl2);
            this.splitContainer1.Size = new System.Drawing.Size(930, 569);
            this.splitContainer1.SplitterDistance = 140;
            // 
            // statusLabel
            // 
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.statusLabel.Location = new System.Drawing.Point(64, 722);
            this.statusLabel.Size = new System.Drawing.Size(744, 30);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.Location = new System.Drawing.Point(3, 73);
            labelX2.Name = "labelX2";
            labelX2.Size = new System.Drawing.Size(75, 17);
            labelX2.TabIndex = 2;
            labelX2.Text = "Vendedor:";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.Location = new System.Drawing.Point(3, 108);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(114, 19);
            labelX1.TabIndex = 0;
            labelX1.Text = "CLAVE PEDIDO:";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX3.Location = new System.Drawing.Point(3, 3);
            labelX3.Name = "labelX3";
            labelX3.Size = new System.Drawing.Size(75, 17);
            labelX3.TabIndex = 4;
            labelX3.Text = "Folio:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33629F));
            this.tableLayoutPanel1.Controls.Add(labelX2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.SKUtextBoxX, 1, 3);
            this.tableLayoutPanel1.Controls.Add(labelX1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(labelX3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.vendedorLabelX, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.clienteLabelX, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX12, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.folioVentaLabelX, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(930, 140);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // SKUtextBoxX
            // 
            this.SKUtextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SKUtextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.SKUtextBoxX.Border.Class = "TextBoxBorder";
            this.SKUtextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SKUtextBoxX.ForeColor = System.Drawing.Color.Black;
            this.highlighter.SetHighlightOnFocus(this.SKUtextBoxX, true);
            this.SKUtextBoxX.Location = new System.Drawing.Point(123, 108);
            this.SKUtextBoxX.Name = "SKUtextBoxX";
            this.SKUtextBoxX.Size = new System.Drawing.Size(804, 25);
            this.SKUtextBoxX.TabIndex = 1;
            // 
            // vendedorLabelX
            // 
            // 
            // 
            // 
            this.vendedorLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.vendedorLabelX.Location = new System.Drawing.Point(3, 38);
            this.vendedorLabelX.Name = "vendedorLabelX";
            this.vendedorLabelX.Size = new System.Drawing.Size(111, 17);
            this.vendedorLabelX.TabIndex = 3;
            this.vendedorLabelX.Text = "Clave del Cliente:";
            // 
            // clienteLabelX
            // 
            // 
            // 
            // 
            this.clienteLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.clienteLabelX.Location = new System.Drawing.Point(123, 38);
            this.clienteLabelX.Name = "clienteLabelX";
            this.clienteLabelX.Size = new System.Drawing.Size(169, 17);
            this.clienteLabelX.TabIndex = 5;
            this.clienteLabelX.Text = "[MOSTRADOR]";
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(123, 73);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(169, 17);
            this.labelX12.TabIndex = 18;
            this.labelX12.Text = "[VENDEDOR]";
            // 
            // folioVentaLabelX
            // 
            // 
            // 
            // 
            this.folioVentaLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.folioVentaLabelX.Location = new System.Drawing.Point(123, 3);
            this.folioVentaLabelX.Name = "folioVentaLabelX";
            this.folioVentaLabelX.Size = new System.Drawing.Size(169, 17);
            this.folioVentaLabelX.TabIndex = 15;
            this.folioVentaLabelX.Text = "1478565";
            // 
            // superGridControl2
            // 
            this.superGridControl2.BackColor = System.Drawing.Color.White;
            this.superGridControl2.ForeColor = System.Drawing.Color.Black;
            this.superGridControl2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.superGridControl2.Location = new System.Drawing.Point(82, 42);
            this.superGridControl2.Name = "superGridControl2";
            gridColumn9.HeaderText = "SURTIDO";
            gridColumn9.Name = "";
            gridColumn9.Width = 60;
            gridColumn10.HeaderText = "SELECT";
            gridColumn10.Name = "";
            gridColumn10.Width = 50;
            gridColumn11.HeaderText = "HEADER";
            gridColumn11.Name = "";
            gridColumn12.HeaderText = "DESCRIPCION";
            gridColumn12.Name = "";
            gridColumn13.HeaderText = "LINEA";
            gridColumn13.Name = "";
            gridColumn14.HeaderText = "CANTIDAD";
            gridColumn14.Name = "";
            gridColumn15.HeaderText = "PRECIO";
            gridColumn15.Name = "";
            gridColumn16.HeaderText = "DESCUENTO";
            gridColumn16.Name = "";
            gridColumn17.HeaderText = "TOTAL";
            gridColumn17.Name = "";
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn9);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn10);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn11);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn12);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn13);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn14);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn15);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn16);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn17);
            this.superGridControl2.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl2.Size = new System.Drawing.Size(791, 181);
            this.superGridControl2.TabIndex = 1;
            this.superGridControl2.Text = "superGridControl2";
            // 
            // buttonItem1
            // 
            this.buttonItem1.HoverImage = global::SIF.Properties.Resources.BoxNewTool1;
            this.buttonItem1.Image = global::SIF.Properties.Resources.BoxNewTool;
            this.buttonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "Reserva\r\nApartado";
            // 
            // highlighter
            // 
            this.highlighter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // ApartadoEspecialUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ApartadoEspecialUserControl";
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

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX SKUtextBoxX;
        private DevComponents.DotNetBar.LabelX vendedorLabelX;
        private DevComponents.DotNetBar.LabelX clienteLabelX;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.LabelX folioVentaLabelX;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl2;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
    }
}
