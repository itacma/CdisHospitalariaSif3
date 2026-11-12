namespace SIF.View.Subrogacion
{
    partial class GeneraFacturasUserControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.SeparaTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.TxtConcepto = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.TxtClave = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Chkcincomillar = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkLoteSerie = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkDetalle = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.tipoPagoComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.TxtNumCta = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonItem = new DevComponents.DotNetBar.ButtonItem();
            this.cancelarButtonItem = new DevComponents.DotNetBar.ButtonItem();
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
            this.cancelarButtonItem});
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(418, 32);
            this.titleLabel.Text = "SIF\\GENERA FACTURAS SUBROGACION";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(915, 447);
            this.superGridControl1.Click += new System.EventHandler(this.superGridControl1_Click);
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.SplitterDistance = 117;
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
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.52577F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.77319F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.69945F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.25683F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.30928F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.30928F));
            this.tableLayoutPanel1.Controls.Add(this.labelX4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.SeparaTextBoxX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtConcepto, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TxtClave, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Chkcincomillar, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkLoteSerie, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkDetalle, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.tipoPagoComboBoxEx, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX3, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX5, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtNumCta, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonX1, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 117);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelX4
            // 
            this.labelX4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(3, 68);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(153, 23);
            this.labelX4.TabIndex = 27;
            this.labelX4.Text = "Dato Clave Detalle:";
            // 
            // labelX1
            // 
            this.labelX1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(135, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Separar Factura por:";
            // 
            // labelX2
            // 
            this.labelX2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(3, 37);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(153, 23);
            this.labelX2.TabIndex = 5;
            this.labelX2.Text = "Datos Concepto Detalle:";
            // 
            // SeparaTextBoxX
            // 
            this.SeparaTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SeparaTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.SeparaTextBoxX.Border.Class = "TextBoxBorder";
            this.SeparaTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SeparaTextBoxX.ButtonCustom.Visible = true;
            this.tableLayoutPanel1.SetColumnSpan(this.SeparaTextBoxX, 4);
            this.SeparaTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.SeparaTextBoxX.Location = new System.Drawing.Point(163, 3);
            this.SeparaTextBoxX.Name = "SeparaTextBoxX";
            this.SeparaTextBoxX.Size = new System.Drawing.Size(653, 25);
            this.SeparaTextBoxX.TabIndex = 28;
            this.SeparaTextBoxX.WatermarkText = "Seleccione los campos por los cuales se generara una factura";
            this.SeparaTextBoxX.ButtonCustomClick += new System.EventHandler(this.ClienteTextBoxX_ButtonCustomClick);
            // 
            // TxtConcepto
            // 
            this.TxtConcepto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtConcepto.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.TxtConcepto.Border.Class = "TextBoxBorder";
            this.TxtConcepto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TxtConcepto.ButtonCustom.Visible = true;
            this.tableLayoutPanel1.SetColumnSpan(this.TxtConcepto, 2);
            this.TxtConcepto.ForeColor = System.Drawing.Color.Black;
            this.TxtConcepto.Location = new System.Drawing.Point(163, 37);
            this.TxtConcepto.Name = "TxtConcepto";
            this.TxtConcepto.Size = new System.Drawing.Size(456, 25);
            this.TxtConcepto.TabIndex = 29;
            this.TxtConcepto.WatermarkText = "Escriba el concepto o seleccione los campos para la descripción";
            this.TxtConcepto.ButtonCustomClick += new System.EventHandler(this.textBoxX1_ButtonCustomClick);
            this.TxtConcepto.TextChanged += new System.EventHandler(this.TxtConcepto_TextChanged);
            // 
            // TxtClave
            // 
            this.TxtClave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtClave.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.TxtClave.Border.Class = "TextBoxBorder";
            this.TxtClave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TxtClave.ButtonCustom.Visible = true;
            this.tableLayoutPanel1.SetColumnSpan(this.TxtClave, 2);
            this.TxtClave.ForeColor = System.Drawing.Color.Black;
            this.TxtClave.Location = new System.Drawing.Point(163, 66);
            this.TxtClave.Name = "TxtClave";
            this.TxtClave.Size = new System.Drawing.Size(456, 25);
            this.TxtClave.TabIndex = 30;
            this.TxtClave.WatermarkText = "Escriba la clave o seleccione los campos para la clave";
            this.TxtClave.ButtonCustomClick += new System.EventHandler(this.textBoxX2_ButtonCustomClick);
            // 
            // Chkcincomillar
            // 
            // 
            // 
            // 
            this.Chkcincomillar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Chkcincomillar.Location = new System.Drawing.Point(163, 100);
            this.Chkcincomillar.Name = "Chkcincomillar";
            this.Chkcincomillar.Size = new System.Drawing.Size(100, 14);
            this.Chkcincomillar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Chkcincomillar.TabIndex = 33;
            this.Chkcincomillar.Text = "5 Millar";
            // 
            // chkLoteSerie
            // 
            // 
            // 
            // 
            this.chkLoteSerie.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkLoteSerie.Location = new System.Drawing.Point(399, 100);
            this.chkLoteSerie.Name = "chkLoteSerie";
            this.chkLoteSerie.Size = new System.Drawing.Size(174, 14);
            this.chkLoteSerie.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkLoteSerie.TabIndex = 34;
            this.chkLoteSerie.Text = "Requiere Lote Caducidad";
            this.chkLoteSerie.CheckedChanged += new System.EventHandler(this.chkLoteSerie_CheckedChanged);
            // 
            // chkDetalle
            // 
            // 
            // 
            // 
            this.chkDetalle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkDetalle.Location = new System.Drawing.Point(625, 100);
            this.chkDetalle.Name = "chkDetalle";
            this.chkDetalle.Size = new System.Drawing.Size(97, 14);
            this.chkDetalle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkDetalle.TabIndex = 31;
            this.chkDetalle.Text = "Resumen";
            // 
            // tipoPagoComboBoxEx
            // 
            this.tipoPagoComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tipoPagoComboBoxEx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.tipoPagoComboBoxEx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tipoPagoComboBoxEx.DisplayMember = "Text";
            this.tipoPagoComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tipoPagoComboBoxEx.FormattingEnabled = true;
            this.tipoPagoComboBoxEx.ItemHeight = 19;
            this.tipoPagoComboBoxEx.Location = new System.Drawing.Point(728, 37);
            this.tipoPagoComboBoxEx.Name = "tipoPagoComboBoxEx";
            this.tipoPagoComboBoxEx.Size = new System.Drawing.Size(88, 25);
            this.tipoPagoComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tipoPagoComboBoxEx.TabIndex = 36;
            this.tipoPagoComboBoxEx.WatermarkText = "Forma Pago";
            // 
            // labelX3
            // 
            this.labelX3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(625, 37);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(97, 23);
            this.labelX3.TabIndex = 37;
            this.labelX3.Text = "Tipo Pago:";
            // 
            // labelX5
            // 
            this.labelX5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(625, 68);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(90, 23);
            this.labelX5.TabIndex = 38;
            this.labelX5.Text = "Num Cta:";
            // 
            // TxtNumCta
            // 
            this.TxtNumCta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNumCta.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.TxtNumCta.Border.Class = "TextBoxBorder";
            this.TxtNumCta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TxtNumCta.ForeColor = System.Drawing.Color.Black;
            this.TxtNumCta.Location = new System.Drawing.Point(728, 66);
            this.TxtNumCta.Name = "TxtNumCta";
            this.TxtNumCta.Size = new System.Drawing.Size(88, 25);
            this.TxtNumCta.TabIndex = 35;
            this.TxtNumCta.WatermarkText = "4 Digitos Cta";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(822, 5);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Text = "Actualizar";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonItem
            // 
            this.buttonItem.Image = global::SIF.Properties.Resources.FundTool;
            this.buttonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem.Name = "buttonItem";
            this.buttonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.buttonItem.Text = "Pago \r\n[F5]";
            // 
            // cancelarButtonItem
            // 
            this.cancelarButtonItem.HoverImage = global::SIF.Properties.Resources.facturar1;
            this.cancelarButtonItem.Image = global::SIF.Properties.Resources.Facturar;
            this.cancelarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.cancelarButtonItem.Name = "cancelarButtonItem";
            this.cancelarButtonItem.Tag = "4";
            this.cancelarButtonItem.Text = "Generar\r\nFacturas";
            this.cancelarButtonItem.Click += new System.EventHandler(this.cancelarButtonItem_Click);
            // 
            // GeneraFacturasUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "GeneraFacturasUserControl";
            this.Load += new System.EventHandler(this.GeneraFacturasUserControl_Load);
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
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevComponents.DotNetBar.ButtonItem buttonItem;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX SeparaTextBoxX;
        private DevComponents.DotNetBar.Controls.TextBoxX TxtConcepto;
        private DevComponents.DotNetBar.Controls.TextBoxX TxtClave;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkDetalle;
        private DevComponents.DotNetBar.Controls.CheckBoxX Chkcincomillar;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkLoteSerie;
        private DevComponents.DotNetBar.ButtonItem cancelarButtonItem;
        private DevComponents.DotNetBar.Controls.TextBoxX TxtNumCta;
        private DevComponents.DotNetBar.Controls.ComboBoxEx tipoPagoComboBoxEx;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX5;
    }
}
