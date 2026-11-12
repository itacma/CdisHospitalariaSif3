namespace SIF.View.CallCenter
{
    partial class CotizacionesUserControl
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
            DevComponents.DotNetBar.LabelX labelX1;
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
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.contadoRadioButton = new System.Windows.Forms.RadioButton();
            this.creditoRadioButton = new System.Windows.Forms.RadioButton();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.cantidadLetraLabelX = new DevComponents.DotNetBar.LabelX();
            this.superGridControl2 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.cancelarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.imprimirCrButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.nuevoPedidoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.nuevoPedidoButtonItem,
            this.buttonItem1,
            this.buttonItem3,
            this.cancelarButtonItem,
            this.imprimirCrButtonItem});
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.bar1.Size = new System.Drawing.Size(944, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(352, 32);
            this.titleLabel.Text = "SIF\\Cotizaciones Cliente convenio";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(930, 449);
            this.superGridControl1.DoubleClick += new System.EventHandler(this.buttonItem1_Click);
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
            this.splitContainer1.SplitterDistance = 100;
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
            // labelX1
            // 
            // 
            // 
            // 
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.Location = new System.Drawing.Point(3, 3);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(114, 19);
            labelX1.TabIndex = 0;
            labelX1.Text = "COTIZACION:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33629F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarTextBoxX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarButtonX, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cantidadLetraLabelX, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(930, 100);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel5, 2);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 263F));
            this.tableLayoutPanel5.Controls.Add(this.radioButton1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.contadoRadioButton, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.creditoRadioButton, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 65);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(789, 32);
            this.tableLayoutPanel5.TabIndex = 20;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(266, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(81, 21);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Por Surtir";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // contadoRadioButton
            // 
            this.contadoRadioButton.AutoSize = true;
            this.contadoRadioButton.Location = new System.Drawing.Point(3, 3);
            this.contadoRadioButton.Name = "contadoRadioButton";
            this.contadoRadioButton.Size = new System.Drawing.Size(92, 21);
            this.contadoRadioButton.TabIndex = 3;
            this.contadoRadioButton.Text = "Canceladas";
            this.contadoRadioButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.contadoRadioButton.UseVisualStyleBackColor = true;
            this.contadoRadioButton.CheckedChanged += new System.EventHandler(this.contadoRadioButton_CheckedChanged);
            // 
            // creditoRadioButton
            // 
            this.creditoRadioButton.AutoSize = true;
            this.creditoRadioButton.Location = new System.Drawing.Point(529, 3);
            this.creditoRadioButton.Name = "creditoRadioButton";
            this.creditoRadioButton.Size = new System.Drawing.Size(73, 21);
            this.creditoRadioButton.TabIndex = 4;
            this.creditoRadioButton.Text = "Surtidas";
            this.creditoRadioButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.creditoRadioButton.UseVisualStyleBackColor = true;
            this.creditoRadioButton.CheckedChanged += new System.EventHandler(this.creditoRadioButton_CheckedChanged);
            // 
            // buscarTextBoxX
            // 
            this.buscarTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buscarTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.buscarTextBoxX.Border.Class = "TextBoxBorder";
            this.buscarTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.buscarTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.highlighter.SetHighlightOnFocus(this.buscarTextBoxX, true);
            this.buscarTextBoxX.Location = new System.Drawing.Point(123, 3);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(669, 25);
            this.buscarTextBoxX.TabIndex = 1;
            this.buscarTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buscarTextBoxX_KeyDown);
            // 
            // buscarButtonX
            // 
            this.buscarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buscarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buscarButtonX.Location = new System.Drawing.Point(813, 3);
            this.buscarButtonX.Name = "buscarButtonX";
            this.buscarButtonX.Size = new System.Drawing.Size(75, 25);
            this.buscarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.buscarButtonX.TabIndex = 19;
            this.buscarButtonX.Text = "Buscar";
            this.buscarButtonX.Click += new System.EventHandler(this.buscarButtonX_Click);
            // 
            // cantidadLetraLabelX
            // 
            // 
            // 
            // 
            this.cantidadLetraLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.cantidadLetraLabelX, 4);
            this.cantidadLetraLabelX.Location = new System.Drawing.Point(3, 34);
            this.cantidadLetraLabelX.Name = "cantidadLetraLabelX";
            this.cantidadLetraLabelX.Size = new System.Drawing.Size(733, 19);
            this.cantidadLetraLabelX.TabIndex = 14;
            this.cantidadLetraLabelX.Text = "SELECCIONA UNA COTIZACION Y PULSANDO EN EL NUMERO PUEDES VER DETALLE";
            // 
            // superGridControl2
            // 
            this.superGridControl2.BackColor = System.Drawing.Color.White;
            this.superGridControl2.ForeColor = System.Drawing.Color.Black;
            this.superGridControl2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.superGridControl2.Location = new System.Drawing.Point(82, 42);
            this.superGridControl2.Name = "superGridControl2";
            gridColumn1.HeaderText = "SURTIDO";
            gridColumn1.Name = "";
            gridColumn1.Width = 60;
            gridColumn2.HeaderText = "SELECT";
            gridColumn2.Name = "";
            gridColumn2.Width = 50;
            gridColumn3.HeaderText = "HEADER";
            gridColumn3.Name = "";
            gridColumn4.HeaderText = "DESCRIPCION";
            gridColumn4.Name = "";
            gridColumn5.HeaderText = "LINEA";
            gridColumn5.Name = "";
            gridColumn6.HeaderText = "CANTIDAD";
            gridColumn6.Name = "";
            gridColumn7.HeaderText = "PRECIO";
            gridColumn7.Name = "";
            gridColumn8.HeaderText = "DESCUENTO";
            gridColumn8.Name = "";
            gridColumn9.HeaderText = "TOTAL";
            gridColumn9.Name = "";
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn1);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn2);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn3);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn4);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn5);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn6);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn7);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn8);
            this.superGridControl2.PrimaryGrid.Columns.Add(gridColumn9);
            this.superGridControl2.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl2.Size = new System.Drawing.Size(791, 181);
            this.superGridControl2.TabIndex = 1;
            this.superGridControl2.Text = "superGridControl2";
            // 
            // cancelarButtonItem
            // 
            this.cancelarButtonItem.HoverImage = global::SIF.Properties.Resources.Cancel1;
            this.cancelarButtonItem.Image = global::SIF.Properties.Resources.Cancel;
            this.cancelarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.cancelarButtonItem.Name = "cancelarButtonItem";
            this.cancelarButtonItem.Tag = "4";
            this.cancelarButtonItem.Text = "Cancelar\r\nCotizacion";
            this.cancelarButtonItem.Click += new System.EventHandler(this.cancelarButtonItem_Click);
            // 
            // highlighter
            // 
            this.highlighter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // buttonItem3
            // 
            this.buttonItem3.HoverImage = global::SIF.Properties.Resources.BoxNewTool1;
            this.buttonItem3.Image = global::SIF.Properties.Resources.IMPRIMIR;
            this.buttonItem3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Tag = "3";
            this.buttonItem3.Text = "Imprimir\r\n ";
            this.buttonItem3.Click += new System.EventHandler(this.buttonItem3_Click);
            // 
            // imprimirCrButtonItem
            // 
            this.imprimirCrButtonItem.HoverImage = global::SIF.Properties.Resources.BoxNewTool1;
            this.imprimirCrButtonItem.Image = global::SIF.Properties.Resources.IMPRIMIR;
            this.imprimirCrButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.imprimirCrButtonItem.Name = "imprimirCrButtonItem";
            this.imprimirCrButtonItem.Tag = "3";
            this.imprimirCrButtonItem.Text = "Imprimir\r\nRemoto";
            this.imprimirCrButtonItem.Click += new System.EventHandler(this.imprimirCrButtonItem_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.HoverImage = global::SIF.Properties.Resources.BoxNewTool1;
            this.buttonItem1.Image = global::SIF.Properties.Resources.ABRIR;
            this.buttonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Tag = "30";
            this.buttonItem1.Text = "Abrir\r\n ";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // nuevoPedidoButtonItem
            // 
            this.nuevoPedidoButtonItem.HoverImage = global::SIF.Properties.Resources.BoxNewTool1;
            this.nuevoPedidoButtonItem.Image = global::SIF.Properties.Resources.BoxNewTool;
            this.nuevoPedidoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.nuevoPedidoButtonItem.Name = "nuevoPedidoButtonItem";
            this.nuevoPedidoButtonItem.Tag = "1";
            this.nuevoPedidoButtonItem.Text = "Nuevo\r\n ";
            this.nuevoPedidoButtonItem.Click += new System.EventHandler(this.nuevoPedidoButtonItem_Click);
            // 
            // CotizacionesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "CotizacionesUserControl";
            this.Load += new System.EventHandler(this.cotizacionsUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.LabelX cantidadLetraLabelX;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl2;
        private DevComponents.DotNetBar.ButtonItem cancelarButtonItem;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.RadioButton contadoRadioButton;
        private System.Windows.Forms.RadioButton creditoRadioButton;
        private DevComponents.DotNetBar.ButtonItem nuevoPedidoButtonItem;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem imprimirCrButtonItem;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}
