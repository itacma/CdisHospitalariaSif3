
namespace SIF.View.Complementos
{
    partial class frmSelecionCaducidad
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Totalpp = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.lblcantidadpedida = new System.Windows.Forms.Label();
            this.CantidadColumn = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.CANTIDAD_ENVColumn = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.CANTIDAD_DISPONIBLEColumn = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.LoteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaducidadColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOTE_INTERNOColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Totalpp)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewX1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Totalpp, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblcantidadpedida, 0, 1);
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.013374F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.013374F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.97885F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.331052F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.66335F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(499, 464);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CantidadColumn,
            this.CANTIDAD_ENVColumn,
            this.CANTIDAD_DISPONIBLEColumn,
            this.LoteColumn,
            this.CaducidadColumn,
            this.LOTE_INTERNOColumn});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewX1, 5);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(3, 67);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.Size = new System.Drawing.Size(493, 309);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 379);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 2);
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(201, 379);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.richTextBox1, 4);
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Location = new System.Drawing.Point(3, 416);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(390, 45);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 4);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(201, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // Totalpp
            // 
            this.Totalpp.Location = new System.Drawing.Point(399, 35);
            this.Totalpp.Name = "Totalpp";
            this.Totalpp.Size = new System.Drawing.Size(97, 20);
            this.Totalpp.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(300, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 32);
            this.label5.TabIndex = 7;
            this.label5.Text = "Total de Piezas";
            // 
            // lblcantidadpedida
            // 
            this.lblcantidadpedida.AutoSize = true;
            this.lblcantidadpedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcantidadpedida.Location = new System.Drawing.Point(3, 32);
            this.lblcantidadpedida.Name = "lblcantidadpedida";
            this.lblcantidadpedida.Size = new System.Drawing.Size(52, 18);
            this.lblcantidadpedida.TabIndex = 8;
            this.lblcantidadpedida.Text = "label6";
            this.lblcantidadpedida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CantidadColumn
            // 
            // 
            // 
            // 
            this.CantidadColumn.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.CantidadColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CantidadColumn.DataPropertyName = "CANTIDAD_LOTE";
            this.CantidadColumn.HeaderText = "CANTIDAD_LOTE";
            this.CantidadColumn.Name = "CantidadColumn";
            this.CantidadColumn.ReadOnly = true;
            this.CantidadColumn.Visible = false;
            // 
            // CANTIDAD_ENVColumn
            // 
            // 
            // 
            // 
            this.CANTIDAD_ENVColumn.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.CANTIDAD_ENVColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CANTIDAD_ENVColumn.DataPropertyName = "CANTIDAD_ENV";
            this.CANTIDAD_ENVColumn.HeaderText = "CANTIDAD_ENV";
            this.CANTIDAD_ENVColumn.MinValue = 0;
            this.CANTIDAD_ENVColumn.Name = "CANTIDAD_ENVColumn";
            // 
            // CANTIDAD_DISPONIBLEColumn
            // 
            // 
            // 
            // 
            this.CANTIDAD_DISPONIBLEColumn.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.CANTIDAD_DISPONIBLEColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CANTIDAD_DISPONIBLEColumn.DataPropertyName = "CANTIDAD_DISPONIBLE";
            this.CANTIDAD_DISPONIBLEColumn.HeaderText = "CANTIDAD_DISPONIBLE";
            this.CANTIDAD_DISPONIBLEColumn.Name = "CANTIDAD_DISPONIBLEColumn";
            this.CANTIDAD_DISPONIBLEColumn.ReadOnly = true;
            this.CANTIDAD_DISPONIBLEColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // LoteColumn
            // 
            this.LoteColumn.DataPropertyName = "NO_LOTE";
            this.LoteColumn.HeaderText = "LOTE";
            this.LoteColumn.MaxInputLength = 20;
            this.LoteColumn.Name = "LoteColumn";
            this.LoteColumn.ReadOnly = true;
            // 
            // CaducidadColumn
            // 
            this.CaducidadColumn.DataPropertyName = "CADUCIDAD";
            this.CaducidadColumn.HeaderText = "CADUCIDAD";
            this.CaducidadColumn.MaxInputLength = 4;
            this.CaducidadColumn.Name = "CaducidadColumn";
            this.CaducidadColumn.ReadOnly = true;
            // 
            // LOTE_INTERNOColumn
            // 
            this.LOTE_INTERNOColumn.DataPropertyName = "LOTE_INTERNO";
            this.LOTE_INTERNOColumn.HeaderText = "LOTE_INTERNO";
            this.LOTE_INTERNOColumn.Name = "LOTE_INTERNOColumn";
            this.LOTE_INTERNOColumn.ReadOnly = true;
            // 
            // frmSelecionCaducidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 480);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelecionCaducidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSelecionCaducidad";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Totalpp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.NumericUpDown Totalpp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblcantidadpedida;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn CantidadColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn CANTIDAD_ENVColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn CANTIDAD_DISPONIBLEColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaducidadColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOTE_INTERNOColumn;
    }
}