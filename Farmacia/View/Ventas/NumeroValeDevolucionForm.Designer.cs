namespace SIF.View.Ventas
{
    partial class NumeroValeDevolucionForm
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
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.numeroValeTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.sucursalComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cancelarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(153, 127);
            this.aceptarButtonX.Name = "aceptarButtonX";
            this.aceptarButtonX.Size = new System.Drawing.Size(80, 26);
            this.aceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButtonX.TabIndex = 3;
            this.aceptarButtonX.Text = "Aceptar";
            this.aceptarButtonX.TextColor = System.Drawing.Color.White;
            this.aceptarButtonX.Click += new System.EventHandler(this.aceptarButtonX_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(306, 23);
            this.labelX1.TabIndex = 5;
            this.labelX1.Text = "Ingrese el número de nota del vale de devolución:";
            // 
            // numeroValeTextBoxX
            // 
            this.numeroValeTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.numeroValeTextBoxX.Border.Class = "TextBoxBorder";
            this.numeroValeTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.numeroValeTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.numeroValeTextBoxX.Location = new System.Drawing.Point(12, 41);
            this.numeroValeTextBoxX.Name = "numeroValeTextBoxX";
            this.numeroValeTextBoxX.Size = new System.Drawing.Size(306, 20);
            this.numeroValeTextBoxX.TabIndex = 0;
            this.numeroValeTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numeroValeTextBoxX_KeyDown);
            // 
            // sucursalComboBoxEx
            // 
            this.sucursalComboBoxEx.DisplayMember = "Text";
            this.sucursalComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.sucursalComboBoxEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sucursalComboBoxEx.FormattingEnabled = true;
            this.sucursalComboBoxEx.ItemHeight = 14;
            this.sucursalComboBoxEx.Location = new System.Drawing.Point(13, 91);
            this.sucursalComboBoxEx.Name = "sucursalComboBoxEx";
            this.sucursalComboBoxEx.Size = new System.Drawing.Size(305, 20);
            this.sucursalComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sucursalComboBoxEx.TabIndex = 2;
            this.sucursalComboBoxEx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sucursalComboBoxEx_KeyDown);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(13, 67);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(306, 23);
            this.labelX2.TabIndex = 5;
            this.labelX2.Text = "Indique la sucursal donde se realizó la venta";
            // 
            // cancelarButtonX
            // 
            this.cancelarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.cancelarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.cancelarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarButtonX.Location = new System.Drawing.Point(239, 127);
            this.cancelarButtonX.Name = "cancelarButtonX";
            this.cancelarButtonX.Size = new System.Drawing.Size(80, 26);
            this.cancelarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButtonX.TabIndex = 6;
            this.cancelarButtonX.Text = "Cancelar";
            this.cancelarButtonX.TextColor = System.Drawing.Color.White;
            this.cancelarButtonX.Click += new System.EventHandler(this.cancelarButtonX_Click);
            // 
            // NumeroValeDevolucionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelarButtonX;
            this.ClientSize = new System.Drawing.Size(330, 165);
            this.Controls.Add(this.cancelarButtonX);
            this.Controls.Add(this.sucursalComboBoxEx);
            this.Controls.Add(this.numeroValeTextBoxX);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.aceptarButtonX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NumeroValeDevolucionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NUMERO DE VALE DE DEVOLUCION";
            this.Load += new System.EventHandler(this.NumeroValeDevolucionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX numeroValeTextBoxX;
        private DevComponents.DotNetBar.Controls.ComboBoxEx sucursalComboBoxEx;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX cancelarButtonX;

    }
}