namespace SIF.View.Inventario
{
    partial class frmRegistraCaducidad
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GuardarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.EditarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(122, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(122, 111);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumericUpDown1_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 137);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(334, 150);
            this.dataGridView1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "[Articulo]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Lote:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "[Referencia]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(228, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "[Cantidad REC]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "MM             YYYY                       CANTIDAD";
            // 
            // GuardarButtonX
            // 
            this.GuardarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.GuardarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GuardarButtonX.AutoSize = true;
            this.GuardarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.GuardarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.GuardarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardarButtonX.Location = new System.Drawing.Point(2, 300);
            this.GuardarButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GuardarButtonX.Name = "GuardarButtonX";
            this.GuardarButtonX.Size = new System.Drawing.Size(104, 37);
            this.GuardarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.GuardarButtonX.TabIndex = 20;
            this.GuardarButtonX.Text = "ACEPTAR";
            this.GuardarButtonX.TextColor = System.Drawing.Color.White;
            this.GuardarButtonX.Click += new System.EventHandler(this.GuardarButtonX_Click);


            // 
            // EditarButtonX
            // 
            this.EditarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.EditarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EditarButtonX.AutoSize = true;
            this.EditarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.EditarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.EditarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditarButtonX.Location = new System.Drawing.Point(150 ,300);
            this.EditarButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EditarButtonX.Name = "EditarButtonX";
            this.EditarButtonX.Size = new System.Drawing.Size(104, 37);
            this.EditarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.EditarButtonX.TabIndex = 20;
            this.EditarButtonX.Text = "Editar";
            this.EditarButtonX.TextColor = System.Drawing.Color.White;
            this.EditarButtonX.Click += new System.EventHandler(this.EditarButtonX_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(184, 111);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(72, 20);
            this.numericUpDown2.TabIndex = 11;
            this.numericUpDown2.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.numericUpDown2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumericUpDown2_KeyDown);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(262, 111);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(72, 20);
            this.numericUpDown3.TabIndex = 12;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumericUpDown3_KeyDown);
            // 
            // frmRegistraCaducidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 339);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.GuardarButtonX);
            this.Controls.Add(this.EditarButtonX);
            this.DoubleBuffered = true;
            this.Name = "frmRegistraCaducidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caducidad Por Articulo";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.ButtonX GuardarButtonX;
        private DevComponents.DotNetBar.ButtonX EditarButtonX;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
    }
}