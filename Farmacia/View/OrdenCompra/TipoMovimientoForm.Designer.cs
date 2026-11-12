namespace SIF.View.OrdenCompra
{
    partial class TipoMovimientoForm
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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            DevComponents.DotNetBar.LabelX labelX2;
            DevComponents.DotNetBar.LabelX labelX1;
            DevComponents.DotNetBar.LabelX labelX4;
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.sucursalLabelX = new DevComponents.DotNetBar.LabelX();
            this.sucursalComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.cancelarButton = new DevComponents.DotNetBar.ButtonX();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            labelX4 = new DevComponents.DotNetBar.LabelX();
            tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.4856F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.5144F));
            tableLayoutPanel1.Controls.Add(labelX2, 0, 1);
            tableLayoutPanel1.Controls.Add(labelX1, 0, 0);
            tableLayoutPanel1.Controls.Add(this.comboBoxEx1, 1, 0);
            tableLayoutPanel1.Controls.Add(this.sucursalLabelX, 1, 1);
            tableLayoutPanel1.Controls.Add(labelX4, 0, 2);
            tableLayoutPanel1.Controls.Add(this.sucursalComboBoxEx, 1, 2);
            tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanel1.Size = new System.Drawing.Size(486, 157);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // labelX2
            // 
            labelX2.AutoSize = true;
            // 
            // 
            // 
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.Location = new System.Drawing.Point(3, 55);
            labelX2.Name = "labelX2";
            labelX2.Size = new System.Drawing.Size(65, 15);
            labelX2.TabIndex = 2;
            labelX2.Text = "SUCURSAL:";
            // 
            // labelX1
            // 
            labelX1.AutoSize = true;
            // 
            // 
            // 
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.Location = new System.Drawing.Point(3, 3);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(105, 15);
            labelX1.TabIndex = 0;
            labelX1.Text = "TIPO MOVIMIENTO:";
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 14;
            this.comboBoxEx1.Location = new System.Drawing.Point(122, 3);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(361, 20);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 1;
            // 
            // sucursalLabelX
            // 
            this.sucursalLabelX.AutoSize = true;
            // 
            // 
            // 
            this.sucursalLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sucursalLabelX.Location = new System.Drawing.Point(122, 55);
            this.sucursalLabelX.Name = "sucursalLabelX";
            this.sucursalLabelX.Size = new System.Drawing.Size(62, 15);
            this.sucursalLabelX.TabIndex = 3;
            this.sucursalLabelX.Text = "SUCURSAL";
            // 
            // labelX4
            // 
            labelX4.AutoSize = true;
            // 
            // 
            // 
            labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX4.Location = new System.Drawing.Point(3, 107);
            labelX4.Name = "labelX4";
            labelX4.Size = new System.Drawing.Size(70, 15);
            labelX4.TabIndex = 2;
            labelX4.Text = "INVOLUCRA:";
            // 
            // sucursalComboBoxEx
            // 
            this.sucursalComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sucursalComboBoxEx.DisplayMember = "Text";
            this.sucursalComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.sucursalComboBoxEx.FormattingEnabled = true;
            this.sucursalComboBoxEx.ItemHeight = 14;
            this.sucursalComboBoxEx.Location = new System.Drawing.Point(122, 107);
            this.sucursalComboBoxEx.Name = "sucursalComboBoxEx";
            this.sucursalComboBoxEx.Size = new System.Drawing.Size(361, 20);
            this.sucursalComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sucursalComboBoxEx.TabIndex = 4;
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(315, 233);
            this.aceptarButtonX.Name = "aceptarButtonX";
            this.aceptarButtonX.Size = new System.Drawing.Size(80, 26);
            this.aceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButtonX.TabIndex = 18;
            this.aceptarButtonX.Text = "Aceptar";
            this.aceptarButtonX.TextColor = System.Drawing.Color.White;
            // 
            // cancelarButton
            // 
            this.cancelarButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.cancelarButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.cancelarButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarButton.Location = new System.Drawing.Point(418, 233);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(80, 26);
            this.cancelarButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButton.TabIndex = 17;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.TextColor = System.Drawing.Color.White;
            // 
            // TipoMovimientoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 271);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(tableLayoutPanel1);
            this.Name = "TipoMovimientoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TIPO MOVIMIENTO";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private DevComponents.DotNetBar.ButtonX cancelarButton;
        private DevComponents.DotNetBar.Controls.ComboBoxEx sucursalComboBoxEx;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.LabelX sucursalLabelX;
    }
}