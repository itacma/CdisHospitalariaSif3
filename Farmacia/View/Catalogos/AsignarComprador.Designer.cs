namespace SIF.View.Catalogos
{
    partial class AsignarArtComp
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
            this.tbControlPcA = new System.Windows.Forms.TabControl();
            this.tPagepProveedores = new System.Windows.Forms.TabPage();
            this.cBoxInactivos = new System.Windows.Forms.CheckBox();
            this.cBoxActivos = new System.Windows.Forms.CheckBox();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            this.dataGridViewAc1 = new System.Windows.Forms.DataGridView();
            this.tbPageCompradores = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.dGVCompradores = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tbPageArtComprador = new System.Windows.Forms.TabPage();
            this.tbControlPcA.SuspendLayout();
            this.tPagepProveedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAc1)).BeginInit();
            this.tbPageCompradores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCompradores)).BeginInit();
            this.SuspendLayout();
            // 
            // tbControlPcA
            // 
            this.tbControlPcA.Controls.Add(this.tPagepProveedores);
            this.tbControlPcA.Controls.Add(this.tbPageCompradores);
            this.tbControlPcA.Controls.Add(this.tbPageArtComprador);
            this.tbControlPcA.Location = new System.Drawing.Point(37, 15);
            this.tbControlPcA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbControlPcA.Name = "tbControlPcA";
            this.tbControlPcA.SelectedIndex = 0;
            this.tbControlPcA.Size = new System.Drawing.Size(1332, 681);
            this.tbControlPcA.TabIndex = 0;
            // 
            // tPagepProveedores
            // 
            this.tPagepProveedores.Controls.Add(this.cBoxInactivos);
            this.tPagepProveedores.Controls.Add(this.cBoxActivos);
            this.tPagepProveedores.Controls.Add(this.btnDesactivar);
            this.tPagepProveedores.Controls.Add(this.btnActivar);
            this.tPagepProveedores.Controls.Add(this.dataGridViewAc1);
            this.tPagepProveedores.Location = new System.Drawing.Point(4, 25);
            this.tPagepProveedores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tPagepProveedores.Name = "tPagepProveedores";
            this.tPagepProveedores.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tPagepProveedores.Size = new System.Drawing.Size(1324, 652);
            this.tPagepProveedores.TabIndex = 0;
            this.tPagepProveedores.Text = "Proveedores";
            this.tPagepProveedores.UseVisualStyleBackColor = true;
            // 
            // cBoxInactivos
            // 
            this.cBoxInactivos.AutoSize = true;
            this.cBoxInactivos.Location = new System.Drawing.Point(393, 27);
            this.cBoxInactivos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBoxInactivos.Name = "cBoxInactivos";
            this.cBoxInactivos.Size = new System.Drawing.Size(85, 21);
            this.cBoxInactivos.TabIndex = 4;
            this.cBoxInactivos.Text = "Inactivos";
            this.cBoxInactivos.UseVisualStyleBackColor = true;
            this.cBoxInactivos.CheckedChanged += new System.EventHandler(this.cBoxInactivos_CheckedChanged);
            // 
            // cBoxActivos
            // 
            this.cBoxActivos.AutoSize = true;
            this.cBoxActivos.Location = new System.Drawing.Point(31, 27);
            this.cBoxActivos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBoxActivos.Name = "cBoxActivos";
            this.cBoxActivos.Size = new System.Drawing.Size(75, 21);
            this.cBoxActivos.TabIndex = 3;
            this.cBoxActivos.Text = "Activos";
            this.cBoxActivos.UseVisualStyleBackColor = true;
            this.cBoxActivos.CheckedChanged += new System.EventHandler(this.cBoxActivos_CheckedChanged);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Location = new System.Drawing.Point(997, 578);
            this.btnDesactivar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(123, 36);
            this.btnDesactivar.TabIndex = 2;
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.UseVisualStyleBackColor = true;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // btnActivar
            // 
            this.btnActivar.Location = new System.Drawing.Point(997, 69);
            this.btnActivar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(127, 34);
            this.btnActivar.TabIndex = 1;
            this.btnActivar.Text = "Activar";
            this.btnActivar.UseVisualStyleBackColor = true;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // dataGridViewAc1
            // 
            this.dataGridViewAc1.BackgroundColor = System.Drawing.Color.Gray;
            this.dataGridViewAc1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAc1.Location = new System.Drawing.Point(8, 69);
            this.dataGridViewAc1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewAc1.Name = "dataGridViewAc1";
            this.dataGridViewAc1.Size = new System.Drawing.Size(985, 558);
            this.dataGridViewAc1.TabIndex = 0;
            // 
            // tbPageCompradores
            // 
            this.tbPageCompradores.Controls.Add(this.button3);
            this.tbPageCompradores.Controls.Add(this.dGVCompradores);
            this.tbPageCompradores.Controls.Add(this.textBox1);
            this.tbPageCompradores.Controls.Add(this.label3);
            this.tbPageCompradores.Controls.Add(this.label1);
            this.tbPageCompradores.Controls.Add(this.comboBox1);
            this.tbPageCompradores.Location = new System.Drawing.Point(4, 25);
            this.tbPageCompradores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPageCompradores.Name = "tbPageCompradores";
            this.tbPageCompradores.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPageCompradores.Size = new System.Drawing.Size(1324, 652);
            this.tbPageCompradores.TabIndex = 1;
            this.tbPageCompradores.Text = "Compradores";
            this.tbPageCompradores.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(323, 34);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 36);
            this.button3.TabIndex = 12;
            this.button3.Text = "Buscar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dGVCompradores
            // 
            this.dGVCompradores.AllowUserToAddRows = false;
            this.dGVCompradores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVCompradores.Location = new System.Drawing.Point(39, 134);
            this.dGVCompradores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dGVCompradores.Name = "dGVCompradores";
            this.dGVCompradores.Size = new System.Drawing.Size(1259, 470);
            this.dGVCompradores.TabIndex = 11;
            this.dGVCompradores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVCompradores_CellClick);
            this.dGVCompradores.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVCompradores_CellEndEdit);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(823, 87);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(265, 22);
            this.textBox1.TabIndex = 10;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(817, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Proveedores por asignar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selecciona Comprador";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(39, 41);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(256, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tbPageArtComprador
            // 
            this.tbPageArtComprador.Location = new System.Drawing.Point(4, 25);
            this.tbPageArtComprador.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPageArtComprador.Name = "tbPageArtComprador";
            this.tbPageArtComprador.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPageArtComprador.Size = new System.Drawing.Size(1324, 652);
            this.tbPageArtComprador.TabIndex = 2;
            this.tbPageArtComprador.Text = "Articulo Comprador";
            this.tbPageArtComprador.UseVisualStyleBackColor = true;
            // 
            // AsignarArtComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 710);
            this.Controls.Add(this.tbControlPcA);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AsignarArtComp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.AsignarArtComp_Load);
            this.tbControlPcA.ResumeLayout(false);
            this.tPagepProveedores.ResumeLayout(false);
            this.tPagepProveedores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAc1)).EndInit();
            this.tbPageCompradores.ResumeLayout(false);
            this.tbPageCompradores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCompradores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbControlPcA;
        private System.Windows.Forms.TabPage tPagepProveedores;
        private System.Windows.Forms.TabPage tbPageCompradores;
        private System.Windows.Forms.TabPage tbPageArtComprador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.DataGridView dataGridViewAc1;
        private System.Windows.Forms.CheckBox cBoxInactivos;
        private System.Windows.Forms.CheckBox cBoxActivos;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dGVCompradores;


    }
}