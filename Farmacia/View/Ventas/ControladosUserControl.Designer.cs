namespace SIF.View.Ventas
{
    partial class ControladosUserControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.cancelarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.imprimeTicketControladoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.antibioticosButtonItem = new DevComponents.DotNetBar.ButtonItem();
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
            this.cancelarButtonItem,
            this.imprimeTicketControladoButtonItem,
            this.antibioticosButtonItem});
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(217, 32);
            this.titleLabel.Text = "SIF\\CONTROLADOS";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            gridColumn1.DataPropertyName = "FOLIO";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn1.HeaderText = "FOLIO";
            gridColumn1.Name = "FOLIOColumn";
            gridColumn1.Width = 140;
            gridColumn2.DataPropertyName = "FECHA_ENTREGA";
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn2.HeaderText = "FECHA ENTREGA";
            gridColumn2.Name = "FECHA_ENTREGAColumn";
            gridColumn3.DataPropertyName = "RECETA";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn3.HeaderText = "RECETA";
            gridColumn3.Name = "RECETAColumn";
            gridColumn4.DataPropertyName = "REMISION_ID";
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn4.HeaderText = "REMISION";
            gridColumn4.Name = "REMISIONColumn";
            gridColumn4.Width = 150;
            gridColumn5.DataPropertyName = "CAT_USUARIOS_NOMBRE";
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn5.HeaderText = "USUARIO";
            gridColumn5.Name = "USUARIOColumn";
            gridColumn5.Width = 200;
            gridColumn6.DataPropertyName = "CAT_USUARIOS_RECIBE_NOMBRE";
            gridColumn6.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn6.HeaderText = "RECIBE";
            gridColumn6.Name = "CAT_USUARIOS_RECIBE_NOMBREColumn";
            gridColumn6.Width = 200;
            gridColumn7.DataPropertyName = "ACTIVO";
            gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            gridColumn7.HeaderText = "ACTIVO";
            gridColumn7.Name = "ACTIVOColumn";
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl1.PrimaryGrid.Columns.Add(gridColumn7);
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
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
            this.cancelarButtonItem.Text = "Cancelar \r\n[F8]";
            this.cancelarButtonItem.Click += new System.EventHandler(this.cancelarButtonItem_Click);
            // 
            // imprimeTicketControladoButtonItem
            // 
            this.imprimeTicketControladoButtonItem.HoverImage = global::SIF.Properties.Resources.Printer1;
            this.imprimeTicketControladoButtonItem.Image = global::SIF.Properties.Resources.Printer;
            this.imprimeTicketControladoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.imprimeTicketControladoButtonItem.Name = "imprimeTicketControladoButtonItem";
            this.imprimeTicketControladoButtonItem.Text = "TICKET\r\n ";
            this.imprimeTicketControladoButtonItem.Click += new System.EventHandler(this.imprimeTicketControladoButtonItem_Click);
            // 
            // antibioticosButtonItem
            // 
            this.antibioticosButtonItem.HoverImage = global::SIF.Properties.Resources.Printer1;
            this.antibioticosButtonItem.Image = global::SIF.Properties.Resources.Printer;
            this.antibioticosButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.antibioticosButtonItem.Name = "antibioticosButtonItem";
            this.antibioticosButtonItem.Text = "Antibioticos\r\n ";
            this.antibioticosButtonItem.Click += new System.EventHandler(this.antibioticosButtonItem_Click);
            // 
            // ControladosUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ControladosUserControl";
            this.Load += new System.EventHandler(this.VentasPagoUserControl_Load);
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
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonItem cancelarButtonItem;
        private DevComponents.DotNetBar.ButtonItem imprimeTicketControladoButtonItem;
        private DevComponents.DotNetBar.ButtonItem antibioticosButtonItem;
    }
}
