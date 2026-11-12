namespace SIF.View.Ventas
{
    partial class RecoleccionValoresUserControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cajaLabelX = new DevComponents.DotNetBar.LabelX();
            this.cajeroLabelX = new DevComponents.DotNetBar.LabelX();
            this.nombreRecoleccionComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.billeteMonedaComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cantidadTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.importeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(347, 32);
            this.titleLabel.Text = "VENTA\\RECOLECCION VALORES";
            // 
            // superGridControl1
            // 
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(915, 439);
            this.superGridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.superGridControl1_KeyDown);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.SplitterDistance = 125;
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cajaLabelX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cajeroLabelX, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.nombreRecoleccionComboBoxEx, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.billeteMonedaComboBoxEx, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.cantidadTextBoxX, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.importeLabel, 4, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 125);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "CAJA:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "CAJERO:";
            // 
            // cajaLabelX
            // 
            // 
            // 
            // 
            this.cajaLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cajaLabelX.Location = new System.Drawing.Point(166, 3);
            this.cajaLabelX.Name = "cajaLabelX";
            this.cajaLabelX.Size = new System.Drawing.Size(75, 23);
            this.cajaLabelX.TabIndex = 1;
            this.cajaLabelX.Text = "[CAJA]";
            // 
            // cajeroLabelX
            // 
            // 
            // 
            // 
            this.cajeroLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cajeroLabelX.Location = new System.Drawing.Point(166, 34);
            this.cajeroLabelX.Name = "cajeroLabelX";
            this.cajeroLabelX.Size = new System.Drawing.Size(75, 23);
            this.cajeroLabelX.TabIndex = 2;
            this.cajeroLabelX.Text = "labelX2";
            // 
            // nombreRecoleccionComboBoxEx
            // 
            this.nombreRecoleccionComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nombreRecoleccionComboBoxEx.DisplayMember = "Text";
            this.nombreRecoleccionComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.nombreRecoleccionComboBoxEx.FormattingEnabled = true;
            this.nombreRecoleccionComboBoxEx.ItemHeight = 19;
            this.nombreRecoleccionComboBoxEx.Location = new System.Drawing.Point(166, 96);
            this.nombreRecoleccionComboBoxEx.Name = "nombreRecoleccionComboBoxEx";
            this.nombreRecoleccionComboBoxEx.Size = new System.Drawing.Size(230, 25);
            this.nombreRecoleccionComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.nombreRecoleccionComboBoxEx.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "RECOLECCION:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "BILLETE/MONEDA:";
            // 
            // billeteMonedaComboBoxEx
            // 
            this.billeteMonedaComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.billeteMonedaComboBoxEx.DisplayMember = "Text";
            this.billeteMonedaComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.billeteMonedaComboBoxEx.FormattingEnabled = true;
            this.billeteMonedaComboBoxEx.ItemHeight = 19;
            this.billeteMonedaComboBoxEx.Location = new System.Drawing.Point(402, 96);
            this.billeteMonedaComboBoxEx.Name = "billeteMonedaComboBoxEx";
            this.billeteMonedaComboBoxEx.Size = new System.Drawing.Size(127, 25);
            this.billeteMonedaComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.billeteMonedaComboBoxEx.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(535, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "CANTIDAD:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(682, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "IMPORTE:";
            // 
            // cantidadTextBoxX
            // 
            this.cantidadTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cantidadTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.cantidadTextBoxX.Border.Class = "TextBoxBorder";
            this.cantidadTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cantidadTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.cantidadTextBoxX.Location = new System.Drawing.Point(535, 96);
            this.cantidadTextBoxX.Name = "cantidadTextBoxX";
            this.cantidadTextBoxX.Size = new System.Drawing.Size(141, 25);
            this.cantidadTextBoxX.TabIndex = 4;
            // 
            // importeLabel
            // 
            this.importeLabel.AutoSize = true;
            this.importeLabel.Location = new System.Drawing.Point(682, 93);
            this.importeLabel.Name = "importeLabel";
            this.importeLabel.Size = new System.Drawing.Size(39, 17);
            this.importeLabel.TabIndex = 0;
            this.importeLabel.Text = "$0.00";
            // 
            // RecoleccionValoresUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "RecoleccionValoresUserControl";
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.LabelX cajaLabelX;
        private DevComponents.DotNetBar.LabelX cajeroLabelX;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx nombreRecoleccionComboBoxEx;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx billeteMonedaComboBoxEx;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX cantidadTextBoxX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label importeLabel;
    }
}
