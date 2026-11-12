namespace SIF.View.Ventas
{
    partial class ArticulosIsstepForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ARTICULO_ID = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ANEXO = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.CODIGOCLI = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.NOMBRE1 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.NOMBRE2 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.PRECIO = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.codigoTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToOrderColumns = true;
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewX1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ARTICULO_ID,
            this.ANEXO,
            this.CODIGOCLI,
            this.NOMBRE1,
            this.NOMBRE2,
            this.PRECIO});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewX1.EnableHeadersVisualStyles = false;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(12, 46);
            this.dataGridViewX1.Name = "dataGridViewX1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(772, 366);
            this.dataGridViewX1.TabIndex = 2;
            this.dataGridViewX1.DoubleClick += new System.EventHandler(this.dataGridViewX1_DoubleClick);
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            // 
            // ARTICULO_ID
            // 
            this.ARTICULO_ID.DataPropertyName = "ARTICULO_ID";
            this.ARTICULO_ID.HeaderText = "CLAVE";
            this.ARTICULO_ID.Name = "ARTICULO_ID";
            this.ARTICULO_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ARTICULO_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ARTICULO_ID.Width = 70;
            // 
            // ANEXO
            // 
            this.ANEXO.DataPropertyName = "ANEXO";
            this.ANEXO.HeaderText = "ANEXO";
            this.ANEXO.Name = "ANEXO";
            this.ANEXO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ANEXO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ANEXO.Width = 76;
            // 
            // CODIGOCLI
            // 
            this.CODIGOCLI.DataPropertyName = "CODIGOCLI";
            this.CODIGOCLI.HeaderText = "CODIGO CLIENTE";
            this.CODIGOCLI.Name = "CODIGOCLI";
            this.CODIGOCLI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CODIGOCLI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CODIGOCLI.Width = 123;
            // 
            // NOMBRE1
            // 
            this.NOMBRE1.DataPropertyName = "NOMBRE1";
            this.NOMBRE1.HeaderText = "NOMBRE1";
            this.NOMBRE1.Name = "NOMBRE1";
            this.NOMBRE1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NOMBRE1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.NOMBRE1.Width = 94;
            // 
            // NOMBRE2
            // 
            this.NOMBRE2.DataPropertyName = "NOMBRE2";
            this.NOMBRE2.HeaderText = "NOMBRE2";
            this.NOMBRE2.Name = "NOMBRE2";
            this.NOMBRE2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NOMBRE2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.NOMBRE2.Width = 94;
            // 
            // PRECIO
            // 
            this.PRECIO.DataPropertyName = "PRECIO";
            this.PRECIO.HeaderText = "PRECIO";
            this.PRECIO.Name = "PRECIO";
            this.PRECIO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PRECIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PRECIO.Width = 76;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Codigo:";
            // 
            // codigoTextBoxX
            // 
            this.codigoTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codigoTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.codigoTextBoxX.Border.Class = "TextBoxBorder";
            this.codigoTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.codigoTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.codigoTextBoxX.Location = new System.Drawing.Point(53, 12);
            this.codigoTextBoxX.Name = "codigoTextBoxX";
            this.codigoTextBoxX.Size = new System.Drawing.Size(650, 20);
            this.codigoTextBoxX.TabIndex = 0;
            this.codigoTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codigoTextBoxX_KeyDown);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(709, 12);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 1;
            this.buttonX1.Text = "Ubicar";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // ArticulosIsstepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 424);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.codigoTextBoxX);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.dataGridViewX1);
            this.DoubleBuffered = true;
            this.Name = "ArticulosIsstepForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artículos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ARTICULO_ID;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ANEXO;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn CODIGOCLI;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn NOMBRE1;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn NOMBRE2;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn PRECIO;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX codigoTextBoxX;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}