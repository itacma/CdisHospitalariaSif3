
namespace SIF.View.Marketing
{
    partial class frmConfiguracion
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
            this.txtEmail1 = new System.Windows.Forms.TextBox();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardarPsw = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEmail1
            // 
            this.txtEmail1.Location = new System.Drawing.Point(151, 94);
            this.txtEmail1.Name = "txtEmail1";
            this.txtEmail1.Size = new System.Drawing.Size(230, 20);
            this.txtEmail1.TabIndex = 0;
            this.txtEmail1.TextChanged += new System.EventHandler(this.txtEmail1_TextChanged);
            // 
            // txtPassword1
            // 
            this.txtPassword1.Location = new System.Drawing.Point(151, 171);
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.Size = new System.Drawing.Size(230, 20);
            this.txtPassword1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Correo:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña:";
            // 
            // btnGuardarPsw
            // 
            this.btnGuardarPsw.Location = new System.Drawing.Point(306, 230);
            this.btnGuardarPsw.Name = "btnGuardarPsw";
            this.btnGuardarPsw.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarPsw.TabIndex = 4;
            this.btnGuardarPsw.Text = "Guardar";
            this.btnGuardarPsw.UseVisualStyleBackColor = true;
            this.btnGuardarPsw.Click += new System.EventHandler(this.btnGuardarPsw_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(308, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Favor de escribir el correo y la contraseña del remitente a utilizar";
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 316);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGuardarPsw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword1);
            this.Controls.Add(this.txtEmail1);
            this.Name = "frmConfiguracion";
            this.Text = "Configuración de Correo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmail1;
        private System.Windows.Forms.TextBox txtPassword1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuardarPsw;
        private System.Windows.Forms.Label label3;
    }
}