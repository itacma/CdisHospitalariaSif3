namespace SIF.View.OrdenCompra
{
    partial class SeleccionaMayoristaForm
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
            DevComponents.DotNetBar.LabelX labelX1;
            this.clienteComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.cancelarButton = new DevComponents.DotNetBar.ButtonX();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // clienteComboBoxEx
            // 
            this.clienteComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clienteComboBoxEx.DisplayMember = "Text";
            this.clienteComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clienteComboBoxEx.FormattingEnabled = true;
            this.clienteComboBoxEx.ItemHeight = 14;
            this.clienteComboBoxEx.Location = new System.Drawing.Point(33, 79);
            this.clienteComboBoxEx.Name = "clienteComboBoxEx";
            this.clienteComboBoxEx.Size = new System.Drawing.Size(361, 20);
            this.clienteComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.clienteComboBoxEx.TabIndex = 2;
            // 
            // labelX1
            // 
            labelX1.AutoSize = true;
            // 
            // 
            // 
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.Location = new System.Drawing.Point(33, 45);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(56, 15);
            labelX1.TabIndex = 3;
            labelX1.Text = "Proveedor:";
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(211, 132);
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
            this.cancelarButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarButton.Location = new System.Drawing.Point(314, 132);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(80, 26);
            this.cancelarButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButton.TabIndex = 19;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.TextColor = System.Drawing.Color.White;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // SeleccionaMayoristaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 179);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(labelX1);
            this.Controls.Add(this.clienteComboBoxEx);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeleccionaMayoristaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mayorista";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx clienteComboBoxEx;
        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private DevComponents.DotNetBar.ButtonX cancelarButton;
    }
}