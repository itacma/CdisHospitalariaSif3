
namespace SIF.View
{
    partial class ModificacionLotesCaducidades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificacionLotesCaducidades));
            this.dt_lotes = new System.Windows.Forms.DataGridView();
            this.lb_usuario = new System.Windows.Forms.Label();
            this.lb_folio = new System.Windows.Forms.Label();
            this.lb_otros = new System.Windows.Forms.Label();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.txt_lote = new System.Windows.Forms.TextBox();
            this.txt_caducidad = new System.Windows.Forms.TextBox();
            this.lb_lote = new System.Windows.Forms.Label();
            this.lb_caducidad = new System.Windows.Forms.Label();
            this.gb_modificaciones = new System.Windows.Forms.GroupBox();
            this.lb_loteInterno = new System.Windows.Forms.Label();
            this.lb_articuloId = new System.Windows.Forms.Label();
            this.txt_cadVieja = new System.Windows.Forms.TextBox();
            this.txt_loteViejo = new System.Windows.Forms.TextBox();
            this.btn_aceptarCambio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dt_lotes)).BeginInit();
            this.gb_modificaciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // dt_lotes
            // 
            this.dt_lotes.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_lotes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_lotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_lotes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dt_lotes.Location = new System.Drawing.Point(12, 12);
            this.dt_lotes.MultiSelect = false;
            this.dt_lotes.Name = "dt_lotes";
            this.dt_lotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_lotes.Size = new System.Drawing.Size(691, 459);
            this.dt_lotes.TabIndex = 0;
            this.dt_lotes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_lotes_CellClick);
            this.dt_lotes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_lotes_CellContentClick);
            // 
            // lb_usuario
            // 
            this.lb_usuario.AutoSize = true;
            this.lb_usuario.Location = new System.Drawing.Point(711, 223);
            this.lb_usuario.Name = "lb_usuario";
            this.lb_usuario.Size = new System.Drawing.Size(35, 13);
            this.lb_usuario.TabIndex = 1;
            this.lb_usuario.Text = "label1";
            this.lb_usuario.Visible = false;
            // 
            // lb_folio
            // 
            this.lb_folio.AutoSize = true;
            this.lb_folio.Location = new System.Drawing.Point(709, 243);
            this.lb_folio.Name = "lb_folio";
            this.lb_folio.Size = new System.Drawing.Size(35, 13);
            this.lb_folio.TabIndex = 2;
            this.lb_folio.Text = "label2";
            this.lb_folio.Visible = false;
            // 
            // lb_otros
            // 
            this.lb_otros.AutoSize = true;
            this.lb_otros.Location = new System.Drawing.Point(711, 271);
            this.lb_otros.Name = "lb_otros";
            this.lb_otros.Size = new System.Drawing.Size(35, 13);
            this.lb_otros.TabIndex = 3;
            this.lb_otros.Text = "label3";
            this.lb_otros.Visible = false;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.BackColor = System.Drawing.Color.LightBlue;
            this.btn_aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aceptar.Location = new System.Drawing.Point(795, 327);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(180, 56);
            this.btn_aceptar.TabIndex = 4;
            this.btn_aceptar.Text = "CERRAR";
            this.btn_aceptar.UseVisualStyleBackColor = false;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // txt_lote
            // 
            this.txt_lote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lote.Location = new System.Drawing.Point(23, 55);
            this.txt_lote.MaxLength = 20;
            this.txt_lote.Name = "txt_lote";
            this.txt_lote.Size = new System.Drawing.Size(210, 26);
            this.txt_lote.TabIndex = 5;
            this.txt_lote.TextChanged += new System.EventHandler(this.txt_lote_TextChanged);
            this.txt_lote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_lote_KeyPress);
            // 
            // txt_caducidad
            // 
            this.txt_caducidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_caducidad.Location = new System.Drawing.Point(23, 126);
            this.txt_caducidad.MaxLength = 4;
            this.txt_caducidad.Name = "txt_caducidad";
            this.txt_caducidad.Size = new System.Drawing.Size(89, 26);
            this.txt_caducidad.TabIndex = 6;
            this.txt_caducidad.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txt_caducidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_caducidad_KeyPress);
            // 
            // lb_lote
            // 
            this.lb_lote.AutoSize = true;
            this.lb_lote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_lote.Location = new System.Drawing.Point(20, 25);
            this.lb_lote.Name = "lb_lote";
            this.lb_lote.Size = new System.Drawing.Size(40, 13);
            this.lb_lote.TabIndex = 7;
            this.lb_lote.Text = "Lote :";
            // 
            // lb_caducidad
            // 
            this.lb_caducidad.AutoSize = true;
            this.lb_caducidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_caducidad.Location = new System.Drawing.Point(20, 99);
            this.lb_caducidad.Name = "lb_caducidad";
            this.lb_caducidad.Size = new System.Drawing.Size(75, 13);
            this.lb_caducidad.TabIndex = 8;
            this.lb_caducidad.Text = "Caducidad :";
            // 
            // gb_modificaciones
            // 
            this.gb_modificaciones.Controls.Add(this.lb_loteInterno);
            this.gb_modificaciones.Controls.Add(this.lb_articuloId);
            this.gb_modificaciones.Controls.Add(this.txt_cadVieja);
            this.gb_modificaciones.Controls.Add(this.txt_loteViejo);
            this.gb_modificaciones.Controls.Add(this.btn_aceptarCambio);
            this.gb_modificaciones.Controls.Add(this.lb_lote);
            this.gb_modificaciones.Controls.Add(this.txt_caducidad);
            this.gb_modificaciones.Controls.Add(this.lb_caducidad);
            this.gb_modificaciones.Controls.Add(this.txt_lote);
            this.gb_modificaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_modificaciones.Location = new System.Drawing.Point(742, 12);
            this.gb_modificaciones.Name = "gb_modificaciones";
            this.gb_modificaciones.Size = new System.Drawing.Size(271, 198);
            this.gb_modificaciones.TabIndex = 9;
            this.gb_modificaciones.TabStop = false;
            this.gb_modificaciones.Text = "NUEVO LOTE O CADUCIDAD";
            this.gb_modificaciones.Visible = false;
            // 
            // lb_loteInterno
            // 
            this.lb_loteInterno.AutoSize = true;
            this.lb_loteInterno.Location = new System.Drawing.Point(23, 208);
            this.lb_loteInterno.Name = "lb_loteInterno";
            this.lb_loteInterno.Size = new System.Drawing.Size(51, 16);
            this.lb_loteInterno.TabIndex = 13;
            this.lb_loteInterno.Text = "label1";
            this.lb_loteInterno.Visible = false;
            // 
            // lb_articuloId
            // 
            this.lb_articuloId.AutoSize = true;
            this.lb_articuloId.Location = new System.Drawing.Point(23, 176);
            this.lb_articuloId.Name = "lb_articuloId";
            this.lb_articuloId.Size = new System.Drawing.Size(51, 16);
            this.lb_articuloId.TabIndex = 12;
            this.lb_articuloId.Text = "label1";
            this.lb_articuloId.Visible = false;
            // 
            // txt_cadVieja
            // 
            this.txt_cadVieja.Location = new System.Drawing.Point(205, 141);
            this.txt_cadVieja.Name = "txt_cadVieja";
            this.txt_cadVieja.Size = new System.Drawing.Size(100, 22);
            this.txt_cadVieja.TabIndex = 11;
            this.txt_cadVieja.Visible = false;
            // 
            // txt_loteViejo
            // 
            this.txt_loteViejo.Location = new System.Drawing.Point(180, 90);
            this.txt_loteViejo.Name = "txt_loteViejo";
            this.txt_loteViejo.Size = new System.Drawing.Size(100, 22);
            this.txt_loteViejo.TabIndex = 10;
            this.txt_loteViejo.Visible = false;
            // 
            // btn_aceptarCambio
            // 
            this.btn_aceptarCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aceptarCambio.Location = new System.Drawing.Point(179, 188);
            this.btn_aceptarCambio.Name = "btn_aceptarCambio";
            this.btn_aceptarCambio.Size = new System.Drawing.Size(146, 56);
            this.btn_aceptarCambio.TabIndex = 9;
            this.btn_aceptarCambio.Text = "ACEPTAR";
            this.btn_aceptarCambio.UseVisualStyleBackColor = true;
            this.btn_aceptarCambio.Visible = false;
            this.btn_aceptarCambio.Click += new System.EventHandler(this.btn_aceptarCambio_Click);
            // 
            // ModificacionLotesCaducidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1023, 488);
            this.Controls.Add(this.gb_modificaciones);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.lb_otros);
            this.Controls.Add(this.lb_folio);
            this.Controls.Add(this.lb_usuario);
            this.Controls.Add(this.dt_lotes);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModificacionLotesCaducidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificacion De Lotes Y Caducidades";
            this.Load += new System.EventHandler(this.ModificacionLotesCaducidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_lotes)).EndInit();
            this.gb_modificaciones.ResumeLayout(false);
            this.gb_modificaciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dt_lotes;
        private System.Windows.Forms.Label lb_usuario;
        private System.Windows.Forms.Label lb_folio;
        private System.Windows.Forms.Label lb_otros;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.TextBox txt_lote;
        private System.Windows.Forms.TextBox txt_caducidad;
        private System.Windows.Forms.Label lb_lote;
        private System.Windows.Forms.Label lb_caducidad;
        private System.Windows.Forms.GroupBox gb_modificaciones;
        private System.Windows.Forms.Button btn_aceptarCambio;
        private System.Windows.Forms.TextBox txt_cadVieja;
        private System.Windows.Forms.TextBox txt_loteViejo;
        private System.Windows.Forms.Label lb_loteInterno;
        private System.Windows.Forms.Label lb_articuloId;
    }
}