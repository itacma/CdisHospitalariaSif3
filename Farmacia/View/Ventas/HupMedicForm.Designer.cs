namespace SIF.View.Ventas
{
    partial class DatosMedico
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.cancelarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.button2 = new System.Windows.Forms.Button();
            this.idMED = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESPECIALIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEDULA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordeN_COMPRA_CABECERATableAdapter1 = new SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.ORDEN_COMPRA_CABECERATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 80);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(347, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Datos del Medico";
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(429, 175);
            this.aceptarButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.aceptarButtonX.Name = "aceptarButtonX";
            this.aceptarButtonX.Size = new System.Drawing.Size(80, 31);
            this.aceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButtonX.TabIndex = 21;
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
            this.cancelarButtonX.Location = new System.Drawing.Point(515, 175);
            this.cancelarButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelarButtonX.Name = "cancelarButtonX";
            this.cancelarButtonX.Size = new System.Drawing.Size(80, 31);
            this.cancelarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButtonX.TabIndex = 22;
            this.cancelarButtonX.Text = "Cancelar";
            this.cancelarButtonX.TextColor = System.Drawing.Color.White;
            this.cancelarButtonX.Click += new System.EventHandler(this.cancelarButtonX_Click);
            // 
            // button2
            // 
            this.button2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(250, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 36);
            this.button2.TabIndex = 25;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // idMED
            // 
            this.idMED.BackColor = System.Drawing.Color.White;
            this.idMED.Location = new System.Drawing.Point(13, 34);
            this.idMED.Name = "idMED";
            this.idMED.Size = new System.Drawing.Size(185, 20);
            this.idMED.TabIndex = 26;
            this.idMED.Tag = "";
           // this.idMED.TextChanged += new System.EventHandler(this.idMED_TextChanged);
            //this.idMED.KeyPress += new System.EventHandler(this.idMED_KeyPress);
            this.idMED.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.idMED_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "ID Medico";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NOMBRE,
            this.ESPECIALIDAD,
            this.CEDULA});
            this.dataGridView1.Location = new System.Drawing.Point(12, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(552, 55);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 80;
            // 
            // NOMBRE
            // 
            this.NOMBRE.HeaderText = "NOMBRE";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.ReadOnly = true;
            this.NOMBRE.Width = 220;
            // 
            // ESPECIALIDAD
            // 
            this.ESPECIALIDAD.HeaderText = "ESPECIALIDAD";
            this.ESPECIALIDAD.Name = "ESPECIALIDAD";
            this.ESPECIALIDAD.ReadOnly = true;
            // 
            // CEDULA
            // 
            this.CEDULA.HeaderText = "CEDULA";
            this.CEDULA.Name = "CEDULA";
            this.CEDULA.ReadOnly = true;
            // 
            // ordeN_COMPRA_CABECERATableAdapter1
            // 
            this.ordeN_COMPRA_CABECERATableAdapter1.ClearBeforeFill = true;
            // 
            // DatosMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 253);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idMED);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cancelarButtonX);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Name = "DatosMedico";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos Medico";
            this.Load += new System.EventHandler(this.DatosDerechohabiente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private DevComponents.DotNetBar.ButtonX cancelarButtonX;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox idMED;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.ORDEN_COMPRA_CABECERATableAdapter ordeN_COMPRA_CABECERATableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESPECIALIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEDULA;
    }
}