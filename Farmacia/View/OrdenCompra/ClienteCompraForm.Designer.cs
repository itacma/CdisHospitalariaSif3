namespace SIF.View.OrdenCompra
{
    partial class ClienteCompraForm
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
            this.clientesListBox = new System.Windows.Forms.ListBox();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.cancelarButton = new DevComponents.DotNetBar.ButtonX();
            this.articuloLabel = new System.Windows.Forms.Label();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.proveedorTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // clientesListBox
            // 
            this.clientesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientesListBox.FormattingEnabled = true;
            this.clientesListBox.Location = new System.Drawing.Point(12, 52);
            this.clientesListBox.Name = "clientesListBox";
            this.clientesListBox.Size = new System.Drawing.Size(442, 199);
            this.clientesListBox.TabIndex = 0;
            this.clientesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ofertasListBox_MouseDoubleClick);
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(271, 276);
            this.aceptarButtonX.Name = "aceptarButtonX";
            this.aceptarButtonX.Size = new System.Drawing.Size(80, 26);
            this.aceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButtonX.TabIndex = 20;
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
            this.cancelarButton.Location = new System.Drawing.Point(374, 276);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(80, 26);
            this.cancelarButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButton.TabIndex = 19;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.TextColor = System.Drawing.Color.White;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // articuloLabel
            // 
            this.articuloLabel.AutoSize = true;
            this.articuloLabel.Location = new System.Drawing.Point(9, 9);
            this.articuloLabel.Name = "articuloLabel";
            this.articuloLabel.Size = new System.Drawing.Size(67, 13);
            this.articuloLabel.TabIndex = 21;
            this.articuloLabel.Text = "[ARTICULO]";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 29);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 22;
            this.labelX1.Text = "Proveedor:";
            // 
            // proveedorTextBoxX
            // 
            this.proveedorTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.proveedorTextBoxX.Border.Class = "TextBoxBorder";
            this.proveedorTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.proveedorTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.proveedorTextBoxX.Location = new System.Drawing.Point(68, 29);
            this.proveedorTextBoxX.Name = "proveedorTextBoxX";
            this.proveedorTextBoxX.Size = new System.Drawing.Size(386, 20);
            this.proveedorTextBoxX.TabIndex = 23;
            this.proveedorTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.proveedorTextBoxX_KeyDown);
            // 
            // ClienteCompraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelarButton;
            this.ClientSize = new System.Drawing.Size(466, 314);
            this.ControlBox = false;
            this.Controls.Add(this.proveedorTextBoxX);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.articuloLabel);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.clientesListBox);
            this.Name = "ClienteCompraForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OFERTAS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox clientesListBox;
        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private DevComponents.DotNetBar.ButtonX cancelarButton;
        private System.Windows.Forms.Label articuloLabel;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX proveedorTextBoxX;
    }
}