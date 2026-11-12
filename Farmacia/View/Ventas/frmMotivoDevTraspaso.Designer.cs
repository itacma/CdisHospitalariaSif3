namespace SIF.View.Ventas
{
    partial class frmMotivoDevTraspaso
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
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.articuloLabel = new System.Windows.Forms.Label();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cmb_TipoDedvolucion = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cantidadDevueltaLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CantDev = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.CantDev)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(279, 143);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 31);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.White;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(194, 143);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(80, 31);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 22;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextColor = System.Drawing.Color.White;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // articuloLabel
            // 
            this.articuloLabel.AutoSize = true;
            this.articuloLabel.Location = new System.Drawing.Point(8, 9);
            this.articuloLabel.Name = "articuloLabel";
            this.articuloLabel.Size = new System.Drawing.Size(67, 13);
            this.articuloLabel.TabIndex = 29;
            this.articuloLabel.Text = "[ARTICULO]";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(8, 28);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(347, 23);
            this.labelX1.TabIndex = 28;
            this.labelX1.Text = "Motivo de Devolución";
            // 
            // cmb_TipoDedvolucion
            // 
            this.cmb_TipoDedvolucion.DisplayMember = "Text";
            this.cmb_TipoDedvolucion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_TipoDedvolucion.FormattingEnabled = true;
            this.cmb_TipoDedvolucion.ItemHeight = 14;
            this.cmb_TipoDedvolucion.Location = new System.Drawing.Point(8, 57);
            this.cmb_TipoDedvolucion.Name = "cmb_TipoDedvolucion";
            this.cmb_TipoDedvolucion.Size = new System.Drawing.Size(347, 20);
            this.cmb_TipoDedvolucion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmb_TipoDedvolucion.TabIndex = 27;
            // 
            // cantidadDevueltaLabel
            // 
            this.cantidadDevueltaLabel.Location = new System.Drawing.Point(8, 115);
            this.cantidadDevueltaLabel.Name = "cantidadDevueltaLabel";
            this.cantidadDevueltaLabel.Size = new System.Drawing.Size(62, 23);
            this.cantidadDevueltaLabel.TabIndex = 31;
            this.cantidadDevueltaLabel.Text = "0";
            this.cantidadDevueltaLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cantidadDevueltaLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Cantidad a devolver :";
            // 
            // CantDev
            // 
            this.CantDev.Location = new System.Drawing.Point(279, 92);
            this.CantDev.Name = "CantDev";
            this.CantDev.Size = new System.Drawing.Size(76, 20);
            this.CantDev.TabIndex = 32;
            this.CantDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CantDev.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmMotivoDevTraspaso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 177);
            this.ControlBox = false;
            this.Controls.Add(this.CantDev);
            this.Controls.Add(this.cantidadDevueltaLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.articuloLabel);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.cmb_TipoDedvolucion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMotivoDevTraspaso";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DEVOLUCION TRASPASO";
            this.Load += new System.EventHandler(this.frmMotivoDevTraspaso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CantDev)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private System.Windows.Forms.Label articuloLabel;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmb_TipoDedvolucion;
        private System.Windows.Forms.Label cantidadDevueltaLabel;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.NumericUpDown CantDev;
    }
}