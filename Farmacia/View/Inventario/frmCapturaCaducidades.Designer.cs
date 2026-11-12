namespace SIF.View.Inventario
{
    partial class frmCapturaCaducidades
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.agregarCadButtonX = new DevComponents.DotNetBar.ButtonX();
            this.GuardarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.lblReferenciaE = new System.Windows.Forms.Label();
            this.lblReferenciaD = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buscarBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.Articulo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.Cant_Lote = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.No_lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CADUCIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.41285F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.58715F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.agregarCadButtonX, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.GuardarButtonX, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblReferenciaE, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblReferenciaD, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.92593F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.07407F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(920, 482);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Articulo_id,
            this.Nombre,
            this.Cantidad,
            this.Cant_Lote,
            this.No_lote,
            this.CADUCIDAD,
            this.DIV});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 6);
            this.dataGridView1.Location = new System.Drawing.Point(3, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 4);
            this.dataGridView1.Size = new System.Drawing.Size(914, 392);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellEndEdit);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridView1_DataBindingComplete);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_RowHeaderMouseClick);
            // 
            // agregarCadButtonX
            // 
            this.agregarCadButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.agregarCadButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.agregarCadButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.agregarCadButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.agregarCadButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregarCadButtonX.Location = new System.Drawing.Point(133, 448);
            this.agregarCadButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.agregarCadButtonX.Name = "agregarCadButtonX";
            this.agregarCadButtonX.Size = new System.Drawing.Size(151, 30);
            this.agregarCadButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.agregarCadButtonX.TabIndex = 20;
            this.agregarCadButtonX.Text = "Dividir";
            this.agregarCadButtonX.TextColor = System.Drawing.Color.White;
            this.agregarCadButtonX.Click += new System.EventHandler(this.agregarCadButtonX_Click);
            // 
            // GuardarButtonX
            // 
            this.GuardarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.GuardarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GuardarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.GuardarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.GuardarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardarButtonX.Location = new System.Drawing.Point(3, 448);
            this.GuardarButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GuardarButtonX.Name = "agregarCadButtonX";
            this.GuardarButtonX.Size = new System.Drawing.Size(124, 30);
            this.GuardarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.GuardarButtonX.TabIndex = 20;
            this.GuardarButtonX.Text = "Guardar";
            this.GuardarButtonX.TextColor = System.Drawing.Color.White;
            this.GuardarButtonX.Click += new System.EventHandler(this.GuardarButtonX_Click);
            // 
            // lblReferenciaE
            // 
            this.lblReferenciaE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReferenciaE.AutoSize = true;
            this.lblReferenciaE.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferenciaE.Location = new System.Drawing.Point(39, 12);
            this.lblReferenciaE.Name = "lblReferenciaE";
            this.lblReferenciaE.Size = new System.Drawing.Size(88, 34);
            this.lblReferenciaE.TabIndex = 21;
            this.lblReferenciaE.Text = "Referencia:";
            // 
            // lblReferenciaD
            // 
            this.lblReferenciaD.AutoSize = true;
            this.lblReferenciaD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferenciaD.Location = new System.Drawing.Point(133, 12);
            this.lblReferenciaD.Name = "lblReferenciaD";
            this.lblReferenciaD.Size = new System.Drawing.Size(19, 19);
            this.lblReferenciaD.TabIndex = 22;
            this.lblReferenciaD.Text = "[]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(448, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "label4";
            // 
            // buscarBackgroundWorker
            // 
            this.buscarBackgroundWorker.WorkerReportsProgress = true;
            this.buscarBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // Articulo_id
            // 
            this.Articulo_id.DataPropertyName = "ARTICULO_ID";
            this.Articulo_id.Frozen = true;
            this.Articulo_id.HeaderText = "Articulo_id";
            this.Articulo_id.Name = "Articulo_id";
            this.Articulo_id.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "NOMBRE";
            this.Nombre.Frozen = true;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Cantidad
            // 
            // 
            // 
            // 
            this.Cantidad.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Cantidad.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Cantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Cantidad.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            this.Cantidad.DataPropertyName = "CANTIDAD";
            this.Cantidad.Frozen = true;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Cant_Lote
            // 
            // 
            // 
            // 
            this.Cant_Lote.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Cant_Lote.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Cant_Lote.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Cant_Lote.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            this.Cant_Lote.DataPropertyName = "CANT_LOTE";
            this.Cant_Lote.Frozen = true;
            this.Cant_Lote.HeaderText = "Cant_Lote";
            this.Cant_Lote.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.Cant_Lote.Name = "Cant_Lote";
            // 
            // No_lote
            // 
            this.No_lote.DataPropertyName = "NO_LOTE";
            this.No_lote.HeaderText = "No_lote";
            this.No_lote.Name = "No_lote";
            // 
            // CADUCIDAD
            // 
            this.CADUCIDAD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CADUCIDAD.DataPropertyName = "CADUCIDAD";
            this.CADUCIDAD.HeaderText = "Caducidad(AAAAMM)";
            this.CADUCIDAD.Name = "CADUCIDAD";
            this.CADUCIDAD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CADUCIDAD.Width = 135;
            // 
            // DIV
            // 
            this.DIV.DataPropertyName = "DIV";
            this.DIV.HeaderText = "DIV";
            this.DIV.Name = "DIV";
            this.DIV.ReadOnly = true;
            this.DIV.Visible = false;
            // 
            // frmCapturaCaducidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 506);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "frmCapturaCaducidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Captura de caducidades";
            this.Load += new System.EventHandler(this.FrmCapturaCaducidades_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevComponents.DotNetBar.ButtonX agregarCadButtonX;
        private DevComponents.DotNetBar.ButtonX GuardarButtonX;
        private System.ComponentModel.BackgroundWorker buscarBackgroundWorker;
        private System.Windows.Forms.Label lblReferenciaE;
        private System.Windows.Forms.Label lblReferenciaD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn Cantidad;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn Cant_Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn CADUCIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIV;
    }
}