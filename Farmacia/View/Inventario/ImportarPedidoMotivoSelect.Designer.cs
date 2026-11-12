namespace SIF.View
{
    partial class ImportarPedidoMotivoSelect
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
            this.cmbTipoPedido = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbTipoPedido
            // 
            this.cmbTipoPedido.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbTipoPedido.FormattingEnabled = true;
            this.cmbTipoPedido.Location = new System.Drawing.Point(34, 35);
            this.cmbTipoPedido.Name = "cmbTipoPedido";
            this.cmbTipoPedido.Size = new System.Drawing.Size(177, 25);
            this.cmbTipoPedido.TabIndex = 0;
            this.cmbTipoPedido.SelectedIndexChanged += new System.EventHandler(this.cmbTipoPedido_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo Pedido";
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblReferencia.Location = new System.Drawing.Point(31, 86);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(69, 17);
            this.lblReferencia.TabIndex = 2;
            this.lblReferencia.Text = "Referencia";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtReferencia.Location = new System.Drawing.Point(34, 112);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(177, 25);
            this.txtReferencia.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnAceptar.Location = new System.Drawing.Point(226, 33);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 27);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // ImportarPedidoMotivoSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(325, 86);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtReferencia);
            this.Controls.Add(this.lblReferencia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTipoPedido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportarPedidoMotivoSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Pedido - Tipo Pedido";
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.Load += new System.EventHandler(this.ImportarPedidoMotivoSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTipoPedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Button btnAceptar;
    }
}