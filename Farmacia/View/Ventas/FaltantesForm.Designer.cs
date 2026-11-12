namespace SIF.View.Ventas
{
    partial class FaltantesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folioLabel = new System.Windows.Forms.Label();
            this.comentariosTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ARTICULO_IDColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.NOMBRE1Column = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.CANTIDADColumn = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.cancelarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.90214F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.09786F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.folioLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comentariosTextBoxX, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(654, 82);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FOLIO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "COMENTARIO:";
            // 
            // folioLabel
            // 
            this.folioLabel.AutoSize = true;
            this.folioLabel.Location = new System.Drawing.Point(106, 0);
            this.folioLabel.Name = "folioLabel";
            this.folioLabel.Size = new System.Drawing.Size(44, 13);
            this.folioLabel.TabIndex = 1;
            this.folioLabel.Text = "[FOLIO]";
            // 
            // comentariosTextBoxX
            // 
            this.comentariosTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comentariosTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.comentariosTextBoxX.Border.Class = "TextBoxBorder";
            this.comentariosTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.comentariosTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.comentariosTextBoxX.Location = new System.Drawing.Point(106, 28);
            this.comentariosTextBoxX.MaxLength = 500;
            this.comentariosTextBoxX.Multiline = true;
            this.comentariosTextBoxX.Name = "comentariosTextBoxX";
            this.comentariosTextBoxX.Size = new System.Drawing.Size(545, 51);
            this.comentariosTextBoxX.TabIndex = 2;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ARTICULO_IDColumn,
            this.NOMBRE1Column,
            this.CANTIDADColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.Size = new System.Drawing.Size(654, 222);
            this.dataGridViewX1.TabIndex = 1;
            // 
            // ARTICULO_IDColumn
            // 
            this.ARTICULO_IDColumn.DataPropertyName = "ARTICULO_ID";
            this.ARTICULO_IDColumn.HeaderText = "ARTICULO";
            this.ARTICULO_IDColumn.Name = "ARTICULO_IDColumn";
            this.ARTICULO_IDColumn.Width = 150;
            // 
            // NOMBRE1Column
            // 
            this.NOMBRE1Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NOMBRE1Column.DataPropertyName = "NOMBRE1";
            this.NOMBRE1Column.HeaderText = "NOMBRE";
            this.NOMBRE1Column.Name = "NOMBRE1Column";
            // 
            // CANTIDADColumn
            // 
            // 
            // 
            // 
            this.CANTIDADColumn.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.CANTIDADColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CANTIDADColumn.DataPropertyName = "CANTIDAD";
            this.CANTIDADColumn.HeaderText = "CANTIDAD";
            this.CANTIDADColumn.Increment = 1D;
            this.CANTIDADColumn.MaxValue = 99999D;
            this.CANTIDADColumn.MinValue = 1D;
            this.CANTIDADColumn.Name = "CANTIDADColumn";
            this.CANTIDADColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CANTIDADColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewX1);
            this.splitContainer1.Size = new System.Drawing.Size(654, 308);
            this.splitContainer1.SplitterDistance = 82;
            this.splitContainer1.TabIndex = 2;
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(477, 315);
            this.aceptarButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.aceptarButtonX.Name = "aceptarButtonX";
            this.aceptarButtonX.Size = new System.Drawing.Size(80, 31);
            this.aceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButtonX.TabIndex = 22;
            this.aceptarButtonX.Text = "Aceptar";
            this.aceptarButtonX.TextColor = System.Drawing.Color.White;
            this.aceptarButtonX.Click += new System.EventHandler(this.aceptarButtonX_Click);
            // 
            // cancelarButtonX
            // 
            this.cancelarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cancelarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.cancelarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.cancelarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarButtonX.Location = new System.Drawing.Point(574, 315);
            this.cancelarButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelarButtonX.Name = "cancelarButtonX";
            this.cancelarButtonX.Size = new System.Drawing.Size(80, 31);
            this.cancelarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButtonX.TabIndex = 23;
            this.cancelarButtonX.Text = "Cancelar";
            this.cancelarButtonX.TextColor = System.Drawing.Color.White;
            this.cancelarButtonX.Click += new System.EventHandler(this.cancelarButtonX_Click);
            // 
            // FaltantesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 354);
            this.Controls.Add(this.cancelarButtonX);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FaltantesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FALTANTES";
            this.Load += new System.EventHandler(this.FaltantesForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private DevComponents.DotNetBar.ButtonX cancelarButtonX;
        private System.Windows.Forms.Label folioLabel;
        private DevComponents.DotNetBar.Controls.TextBoxX comentariosTextBoxX;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ARTICULO_IDColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn NOMBRE1Column;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn CANTIDADColumn;
    }
}