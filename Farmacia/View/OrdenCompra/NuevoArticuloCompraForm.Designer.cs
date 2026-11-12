namespace SIF.View.OrdenCompra
{
    partial class NuevoArticuloCompraForm
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
            this.nombreTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.cancelarButton = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.costoTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.articuloLabelX = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cantidadTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(26, 35);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Nombre";
            // 
            // nombreTextBoxX
            // 
            this.nombreTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.nombreTextBoxX.Border.Class = "TextBoxBorder";
            this.nombreTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.nombreTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.nombreTextBoxX.Location = new System.Drawing.Point(26, 64);
            this.nombreTextBoxX.Name = "nombreTextBoxX";
            this.nombreTextBoxX.Size = new System.Drawing.Size(293, 20);
            this.nombreTextBoxX.TabIndex = 0;
            this.nombreTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nombreTextBoxX_KeyDown);
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(136, 205);
            this.aceptarButtonX.Name = "aceptarButtonX";
            this.aceptarButtonX.Size = new System.Drawing.Size(80, 26);
            this.aceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButtonX.TabIndex = 2;
            this.aceptarButtonX.Text = "Aceptar";
            this.aceptarButtonX.TextColor = System.Drawing.Color.White;
            this.aceptarButtonX.Click += new System.EventHandler(this.aceptarButtonX_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.cancelarButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarButton.Location = new System.Drawing.Point(239, 205);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(80, 26);
            this.cancelarButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButton.TabIndex = 3;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.TextColor = System.Drawing.Color.White;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(26, 93);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 23;
            this.labelX2.Text = "Costo";
            // 
            // costoTextBoxX
            // 
            this.costoTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.costoTextBoxX.Border.Class = "TextBoxBorder";
            this.costoTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.costoTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.costoTextBoxX.Location = new System.Drawing.Point(26, 122);
            this.costoTextBoxX.Name = "costoTextBoxX";
            this.costoTextBoxX.Size = new System.Drawing.Size(293, 20);
            this.costoTextBoxX.TabIndex = 1;
            this.costoTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.costoTextBoxX_KeyDown);
            // 
            // articuloLabelX
            // 
            // 
            // 
            // 
            this.articuloLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.articuloLabelX.Location = new System.Drawing.Point(26, 6);
            this.articuloLabelX.Name = "articuloLabelX";
            this.articuloLabelX.Size = new System.Drawing.Size(75, 23);
            this.articuloLabelX.TabIndex = 24;
            this.articuloLabelX.Text = "[ARTICULO]";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(26, 150);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 26;
            this.labelX3.Text = "Cantidad";
            // 
            // cantidadTextBoxX
            // 
            this.cantidadTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.cantidadTextBoxX.Border.Class = "TextBoxBorder";
            this.cantidadTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cantidadTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.cantidadTextBoxX.Location = new System.Drawing.Point(26, 179);
            this.cantidadTextBoxX.Name = "cantidadTextBoxX";
            this.cantidadTextBoxX.Size = new System.Drawing.Size(293, 20);
            this.cantidadTextBoxX.TabIndex = 25;
            // 
            // NuevoArticuloCompraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 250);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.cantidadTextBoxX);
            this.Controls.Add(this.articuloLabelX);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.costoTextBoxX);
            this.Controls.Add(this.nombreTextBoxX);
            this.Controls.Add(this.labelX1);
            this.Name = "NuevoArticuloCompraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NUEVO";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private DevComponents.DotNetBar.ButtonX cancelarButton;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX articuloLabelX;
        public DevComponents.DotNetBar.Controls.TextBoxX nombreTextBoxX;
        public DevComponents.DotNetBar.Controls.TextBoxX costoTextBoxX;
        private DevComponents.DotNetBar.LabelX labelX3;
        public DevComponents.DotNetBar.Controls.TextBoxX cantidadTextBoxX;
    }
}