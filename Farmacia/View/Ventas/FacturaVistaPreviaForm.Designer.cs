namespace SIF.View.Ventas
{
    partial class FacturaVistaPreviaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.CantidadColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.UnidadColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.DescripcionColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.PrecioUnitarioColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ImoprteColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.subtotalLabelX = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.descuentoLabelX = new DevComponents.DotNetBar.LabelX();
            this.ivaLabelX = new DevComponents.DotNetBar.LabelX();
            this.totalLabelX = new DevComponents.DotNetBar.LabelX();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ClienteLabel = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.clientelabelX = new DevComponents.DotNetBar.LabelX();
            this.rfclabelX = new DevComponents.DotNetBar.LabelX();
            this.direccionlabelX = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CantidadColumn,
            this.UnidadColumn,
            this.DescripcionColumn,
            this.PrecioUnitarioColumn,
            this.ImoprteColumn});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(1, 117);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.Size = new System.Drawing.Size(778, 320);
            this.dataGridViewX1.TabIndex = 0;
            // 
            // CantidadColumn
            // 
            this.CantidadColumn.DataPropertyName = "CantidadRemision";
            this.CantidadColumn.HeaderText = "Cantidad";
            this.CantidadColumn.Name = "CantidadColumn";
            this.CantidadColumn.ReadOnly = true;
            // 
            // UnidadColumn
            // 
            this.UnidadColumn.DataPropertyName = "Unidad";
            this.UnidadColumn.HeaderText = "Unidad";
            this.UnidadColumn.Name = "UnidadColumn";
            this.UnidadColumn.ReadOnly = true;
            // 
            // DescripcionColumn
            // 
            this.DescripcionColumn.DataPropertyName = "Nombre1";
            this.DescripcionColumn.FillWeight = 300F;
            this.DescripcionColumn.HeaderText = "Descripción";
            this.DescripcionColumn.Name = "DescripcionColumn";
            this.DescripcionColumn.ReadOnly = true;
            this.DescripcionColumn.Width = 300;
            // 
            // PrecioUnitarioColumn
            // 
            this.PrecioUnitarioColumn.DataPropertyName = "Precio";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "C2";
            this.PrecioUnitarioColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.PrecioUnitarioColumn.FillWeight = 150F;
            this.PrecioUnitarioColumn.HeaderText = "Precio Unitario";
            this.PrecioUnitarioColumn.Name = "PrecioUnitarioColumn";
            this.PrecioUnitarioColumn.ReadOnly = true;
            this.PrecioUnitarioColumn.TextAlignment = System.Drawing.StringAlignment.Far;
            this.PrecioUnitarioColumn.Width = 150;
            // 
            // ImoprteColumn
            // 
            this.ImoprteColumn.DataPropertyName = "Total";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "C2";
            this.ImoprteColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.ImoprteColumn.FillWeight = 150F;
            this.ImoprteColumn.HeaderText = "Importe";
            this.ImoprteColumn.Name = "ImoprteColumn";
            this.ImoprteColumn.ReadOnly = true;
            this.ImoprteColumn.TextAlignment = System.Drawing.StringAlignment.Far;
            this.ImoprteColumn.Width = 150;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.subtotalLabelX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelX4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.descuentoLabelX, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ivaLabelX, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.totalLabelX, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(529, 443);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(243, 100);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // subtotalLabelX
            // 
            this.subtotalLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.subtotalLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.subtotalLabelX.Location = new System.Drawing.Point(124, 3);
            this.subtotalLabelX.Name = "subtotalLabelX";
            this.subtotalLabelX.Size = new System.Drawing.Size(116, 19);
            this.subtotalLabelX.TabIndex = 2;
            this.subtotalLabelX.Text = "$0.00";
            this.subtotalLabelX.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(3, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 19);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Subtotal";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(3, 28);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 19);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Descuento";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(3, 53);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 19);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "IVA";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(3, 78);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 19);
            this.labelX4.TabIndex = 1;
            this.labelX4.Text = "Total:";
            // 
            // descuentoLabelX
            // 
            this.descuentoLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.descuentoLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.descuentoLabelX.Location = new System.Drawing.Point(124, 28);
            this.descuentoLabelX.Name = "descuentoLabelX";
            this.descuentoLabelX.Size = new System.Drawing.Size(116, 19);
            this.descuentoLabelX.TabIndex = 2;
            this.descuentoLabelX.Text = "$0.00";
            this.descuentoLabelX.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // ivaLabelX
            // 
            this.ivaLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.ivaLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ivaLabelX.Location = new System.Drawing.Point(124, 53);
            this.ivaLabelX.Name = "ivaLabelX";
            this.ivaLabelX.Size = new System.Drawing.Size(116, 19);
            this.ivaLabelX.TabIndex = 2;
            this.ivaLabelX.Text = "$0.00";
            this.ivaLabelX.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // totalLabelX
            // 
            this.totalLabelX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.totalLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.totalLabelX.Location = new System.Drawing.Point(124, 78);
            this.totalLabelX.Name = "totalLabelX";
            this.totalLabelX.Size = new System.Drawing.Size(116, 19);
            this.totalLabelX.TabIndex = 2;
            this.totalLabelX.Text = "$0.00";
            this.totalLabelX.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.483291F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.51671F));
            this.tableLayoutPanel2.Controls.Add(this.ClienteLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelX5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelX6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.clientelabelX, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rfclabelX, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.direccionlabelX, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(778, 100);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // ClienteLabel
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ClienteLabel.Location = new System.Drawing.Point(3, 3);
            this.ClienteLabel.Name = "ClienteLabel";
            this.ClienteLabel.Size = new System.Drawing.Size(60, 23);
            this.ClienteLabel.TabIndex = 0;
            this.ClienteLabel.Text = "Cliente:";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(3, 36);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(60, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "RFC:";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(3, 69);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(60, 23);
            this.labelX6.TabIndex = 0;
            this.labelX6.Text = "Dirección:";
            // 
            // clientelabelX
            // 
            this.clientelabelX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.clientelabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.clientelabelX.Location = new System.Drawing.Point(69, 3);
            this.clientelabelX.Name = "clientelabelX";
            this.clientelabelX.Size = new System.Drawing.Size(706, 23);
            this.clientelabelX.TabIndex = 0;
            this.clientelabelX.Text = "[Cliente]";
            // 
            // rfclabelX
            // 
            this.rfclabelX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.rfclabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rfclabelX.Location = new System.Drawing.Point(69, 36);
            this.rfclabelX.Name = "rfclabelX";
            this.rfclabelX.Size = new System.Drawing.Size(706, 23);
            this.rfclabelX.TabIndex = 0;
            this.rfclabelX.Text = "[RFC]";
            // 
            // direccionlabelX
            // 
            this.direccionlabelX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.direccionlabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.direccionlabelX.Location = new System.Drawing.Point(69, 69);
            this.direccionlabelX.Name = "direccionlabelX";
            this.direccionlabelX.Size = new System.Drawing.Size(706, 23);
            this.direccionlabelX.TabIndex = 0;
            this.direccionlabelX.Text = "[Direccion]";
            // 
            // FacturaVistaPreviaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dataGridViewX1);
            this.DoubleBuffered = true;
            this.Name = "FacturaVistaPreviaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX subtotalLabelX;
        private DevComponents.DotNetBar.LabelX descuentoLabelX;
        private DevComponents.DotNetBar.LabelX ivaLabelX;
        private DevComponents.DotNetBar.LabelX totalLabelX;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn CantidadColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn UnidadColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn DescripcionColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn PrecioUnitarioColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ImoprteColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevComponents.DotNetBar.LabelX ClienteLabel;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX clientelabelX;
        private DevComponents.DotNetBar.LabelX rfclabelX;
        private DevComponents.DotNetBar.LabelX direccionlabelX;
    }
}