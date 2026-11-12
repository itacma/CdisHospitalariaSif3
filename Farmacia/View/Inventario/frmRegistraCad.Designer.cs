namespace SIF.View.Inventario
    {
    partial class frmRegistraCad
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
            this.LOTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CADUCIDAD = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.CANTIDAD = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.REFERENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_MOV_INV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EliminarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.NuevoButtonX = new DevComponents.DotNetBar.ButtonX();
            this.CancelarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.GuardarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.92704F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.07296F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewX1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.EliminarButtonX, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.NuevoButtonX, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CancelarButtonX, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.GuardarButtonX, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(595, 232);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LOTE,
            this.CADUCIDAD,
            this.CANTIDAD,
            this.REFERENCIA,
            this.TIPO_MOV_INV});
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
            this.dataGridViewX1.Location = new System.Drawing.Point(3, 34);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.Size = new System.Drawing.Size(576, 149);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            // 
            // LOTE
            // 
            this.LOTE.DataPropertyName = "lote";
            this.LOTE.HeaderText = "LOTE";
            this.LOTE.Name = "LOTE";
            // 
            // CADUCIDAD
            // 
            // 
            // 
            // 
            this.CADUCIDAD.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.CADUCIDAD.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.CADUCIDAD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CADUCIDAD.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            this.CADUCIDAD.DataPropertyName = "caducidad";
            this.CADUCIDAD.HeaderText = "CADUCIDAD";
            this.CADUCIDAD.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.CADUCIDAD.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.CADUCIDAD.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CADUCIDAD.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.CADUCIDAD.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CADUCIDAD.MonthCalendar.DisplayMonth = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            this.CADUCIDAD.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.CADUCIDAD.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.CADUCIDAD.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CADUCIDAD.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.CADUCIDAD.Name = "CADUCIDAD";
            // 
            // CANTIDAD
            // 
            // 
            // 
            // 
            this.CANTIDAD.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.CANTIDAD.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.CANTIDAD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CANTIDAD.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            this.CANTIDAD.DataPropertyName = "cantidad";
            this.CANTIDAD.HeaderText = "CANTIDAD";
            this.CANTIDAD.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.CANTIDAD.Name = "CANTIDAD";
            // 
            // REFERENCIA
            // 
            this.REFERENCIA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.REFERENCIA.DataPropertyName = "referencia";
            this.REFERENCIA.HeaderText = "REFERENCIA";
            this.REFERENCIA.Name = "REFERENCIA";
            this.REFERENCIA.ReadOnly = true;
            // 
            // TIPO_MOV_INV
            // 
            this.TIPO_MOV_INV.DataPropertyName = "tipo_mov_inv";
            this.TIPO_MOV_INV.HeaderText = "TIPO_MOV_INV";
            this.TIPO_MOV_INV.Name = "TIPO_MOV_INV";
            this.TIPO_MOV_INV.ReadOnly = true;
            // 
            // EliminarButtonX
            // 
            this.EliminarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.EliminarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EliminarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.EliminarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.EliminarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EliminarButtonX.Location = new System.Drawing.Point(105, 191);
            this.EliminarButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EliminarButtonX.Name = "EliminarButtonX";
            this.EliminarButtonX.Size = new System.Drawing.Size(90, 37);
            this.EliminarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.EliminarButtonX.TabIndex = 20;
            this.EliminarButtonX.Text = "Eliminar [F12]";
            this.EliminarButtonX.TextColor = System.Drawing.Color.White;
            this.EliminarButtonX.Click += new System.EventHandler(this.EliminarButtonX_Click);
            // 
            // NuevoButtonX
            // 
            this.NuevoButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.NuevoButtonX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NuevoButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.NuevoButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.NuevoButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NuevoButtonX.Location = new System.Drawing.Point(3, 192);
            this.NuevoButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NuevoButtonX.Name = "NuevoButtonX";
            this.NuevoButtonX.Size = new System.Drawing.Size(90, 35);
            this.NuevoButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.NuevoButtonX.TabIndex = 20;
            this.NuevoButtonX.Text = "Nuevo [F5]";
            this.NuevoButtonX.TextColor = System.Drawing.Color.White;
            this.NuevoButtonX.Click += new System.EventHandler(this.NuevoButtonX_Click);
            // 
            // CancelarButtonX
            // 
            this.CancelarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.CancelarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CancelarButtonX.AutoSize = true;
            this.CancelarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.CancelarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.CancelarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarButtonX.Location = new System.Drawing.Point(211, 191);
            this.CancelarButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CancelarButtonX.Name = "CancelarButtonX";
            this.CancelarButtonX.Size = new System.Drawing.Size(100, 37);
            this.CancelarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CancelarButtonX.TabIndex = 20;
            this.CancelarButtonX.Text = "Cancelar";
            this.CancelarButtonX.TextColor = System.Drawing.Color.White;
            this.CancelarButtonX.Click += new System.EventHandler(this.CancelarButtonX_Click);
            // 
            // GuardarButtonX
            // 
            this.GuardarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.GuardarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GuardarButtonX.AutoSize = true;
            this.GuardarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.GuardarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.GuardarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardarButtonX.Location = new System.Drawing.Point(317, 191);
            this.GuardarButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GuardarButtonX.Name = "GuardarButtonX";
            this.GuardarButtonX.Size = new System.Drawing.Size(104, 37);
            this.GuardarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.GuardarButtonX.TabIndex = 20;
            this.GuardarButtonX.Text = "Guardar [F9]";
            this.GuardarButtonX.TextColor = System.Drawing.Color.White;
            this.GuardarButtonX.Click += new System.EventHandler(this.GuardarButtonX_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 31);
            this.label1.TabIndex = 21;
            this.label1.Text = "[Articulo Name]";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(343, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 31);
            this.label2.TabIndex = 22;
            this.label2.Text = "Cant. Esc:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(427, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 31);
            this.label3.TabIndex = 23;
            this.label3.Text = "[Esc]";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmRegistraCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 253);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistraCad";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registra Lote y Caducidad";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX NuevoButtonX;
        private DevComponents.DotNetBar.ButtonX EliminarButtonX;
        private DevComponents.DotNetBar.ButtonX CancelarButtonX;
        private DevComponents.DotNetBar.ButtonX GuardarButtonX;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOTE;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn CADUCIDAD;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn REFERENCIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO_MOV_INV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        }
    }