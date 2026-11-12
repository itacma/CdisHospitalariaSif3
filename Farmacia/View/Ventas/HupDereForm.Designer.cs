namespace SIF.View.Ventas
{
    partial class DatosDerechohabiente
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.cancelarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.ttratamiento = new System.Windows.Forms.GroupBox();
            this.tDias = new System.Windows.Forms.RadioButton();
            this.TMeses = new System.Windows.Forms.RadioButton();
            this.ttrata = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.idDer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.der = new System.Windows.Forms.ComboBox();
            this.ttratamiento.SuspendLayout();
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
            this.labelX1.Text = "Derechohabiente";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 150);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(347, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "T. Tratamiento";
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(203, 241);
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
            this.cancelarButtonX.Location = new System.Drawing.Point(289, 241);
            this.cancelarButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelarButtonX.Name = "cancelarButtonX";
            this.cancelarButtonX.Size = new System.Drawing.Size(80, 31);
            this.cancelarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButtonX.TabIndex = 22;
            this.cancelarButtonX.Text = "Cancelar";
            this.cancelarButtonX.TextColor = System.Drawing.Color.White;
            this.cancelarButtonX.Click += new System.EventHandler(this.cancelarButtonX_Click);
            // 
            // ttratamiento
            // 
            this.ttratamiento.Controls.Add(this.tDias);
            this.ttratamiento.Controls.Add(this.TMeses);
            this.ttratamiento.Location = new System.Drawing.Point(91, 165);
            this.ttratamiento.Name = "ttratamiento";
            this.ttratamiento.Size = new System.Drawing.Size(99, 59);
            this.ttratamiento.TabIndex = 23;
            this.ttratamiento.TabStop = false;
            // 
            // tDias
            // 
            this.tDias.AutoSize = true;
            this.tDias.Location = new System.Drawing.Point(6, 33);
            this.tDias.Name = "tDias";
            this.tDias.Size = new System.Drawing.Size(46, 17);
            this.tDias.TabIndex = 1;
            this.tDias.TabStop = true;
            this.tDias.Text = "Dias";
            this.tDias.UseVisualStyleBackColor = true;
            // 
            // TMeses
            // 
            this.TMeses.AutoSize = true;
            this.TMeses.Location = new System.Drawing.Point(6, 10);
            this.TMeses.Name = "TMeses";
            this.TMeses.Size = new System.Drawing.Size(56, 17);
            this.TMeses.TabIndex = 0;
            this.TMeses.TabStop = true;
            this.TMeses.Text = "Meses";
            this.TMeses.UseVisualStyleBackColor = true;
            this.TMeses.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // ttrata
            // 
            this.ttrata.Location = new System.Drawing.Point(13, 188);
            this.ttrata.Name = "ttrata";
            this.ttrata.Size = new System.Drawing.Size(72, 20);
            this.ttrata.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(248, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 36);
            this.button1.TabIndex = 25;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // idDer
            // 
            this.idDer.BackColor = System.Drawing.Color.White;
            this.idDer.Location = new System.Drawing.Point(13, 34);
            this.idDer.Name = "idDer";
            this.idDer.Size = new System.Drawing.Size(185, 20);
            this.idDer.TabIndex = 26;
            this.idDer.Tag = "";
            //this.idDer.TextChanged += new System.EventHandler(this.idDer_TextChanged);
            this.idDer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.idDer_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "ID Derechohabiente";
            // 
            // der
            // 
            this.der.FormattingEnabled = true;
            this.der.Location = new System.Drawing.Point(12, 100);
            this.der.Name = "der";
            this.der.Size = new System.Drawing.Size(334, 21);
            this.der.TabIndex = 28;
            this.der.SelectedIndexChanged += new System.EventHandler(this.der_SelectedIndexChanged);
            // 
            // DatosDerechohabiente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 291);
            this.ControlBox = false;
            this.Controls.Add(this.der);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idDer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ttrata);
            this.Controls.Add(this.ttratamiento);
            this.Controls.Add(this.cancelarButtonX);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Name = "DatosDerechohabiente";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos Derechohabiente";
            this.Load += new System.EventHandler(this.DatosDerechohabiente_Load);
            this.ttratamiento.ResumeLayout(false);
            this.ttratamiento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private DevComponents.DotNetBar.ButtonX cancelarButtonX;
        private System.Windows.Forms.GroupBox ttratamiento;
        private System.Windows.Forms.RadioButton tDias;
        private System.Windows.Forms.RadioButton TMeses;
        private System.Windows.Forms.TextBox ttrata;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox idDer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox der;
    }
}