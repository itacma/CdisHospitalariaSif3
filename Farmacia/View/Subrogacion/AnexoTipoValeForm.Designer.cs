namespace SIF.View.Subrogacion
{
    partial class AnexoTipoValeForm
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
            this.tipoValeComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.anexoNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cancelarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.clienteComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            ((System.ComponentModel.ISupportInitialize)(this.anexoNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tipoValeComboBoxEx
            // 
            this.tipoValeComboBoxEx.DisplayMember = "Text";
            this.tipoValeComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tipoValeComboBoxEx.FormattingEnabled = true;
            this.tipoValeComboBoxEx.ItemHeight = 14;
            this.tipoValeComboBoxEx.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.tipoValeComboBoxEx.Location = new System.Drawing.Point(77, 53);
            this.tipoValeComboBoxEx.Name = "tipoValeComboBoxEx";
            this.tipoValeComboBoxEx.Size = new System.Drawing.Size(238, 20);
            this.tipoValeComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tipoValeComboBoxEx.TabIndex = 2;
            this.tipoValeComboBoxEx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tipoValeComboBoxEx_KeyDown);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "AE";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "CB";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 24);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(59, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "No. Anexo:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 51);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(59, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Tipo Vale:";
            // 
            // anexoNumericUpDown
            // 
            this.anexoNumericUpDown.Location = new System.Drawing.Point(77, 24);
            this.anexoNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.anexoNumericUpDown.Name = "anexoNumericUpDown";
            this.anexoNumericUpDown.Size = new System.Drawing.Size(238, 20);
            this.anexoNumericUpDown.TabIndex = 1;
            this.anexoNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cancelarButtonX
            // 
            this.cancelarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.cancelarButtonX.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButtonX.Location = new System.Drawing.Point(240, 109);
            this.cancelarButtonX.Name = "cancelarButtonX";
            this.cancelarButtonX.Size = new System.Drawing.Size(75, 23);
            this.cancelarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButtonX.TabIndex = 5;
            this.cancelarButtonX.Text = "Cancelar";
            this.cancelarButtonX.Click += new System.EventHandler(this.cancelarButtonX_Click);
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.aceptarButtonX.Location = new System.Drawing.Point(159, 109);
            this.aceptarButtonX.Name = "aceptarButtonX";
            this.aceptarButtonX.Size = new System.Drawing.Size(75, 23);
            this.aceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButtonX.TabIndex = 4;
            this.aceptarButtonX.Text = "Aceptar";
            this.aceptarButtonX.Click += new System.EventHandler(this.aceptarButtonX_Click);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(12, 76);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(59, 23);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "Cliente:";
            // 
            // clienteComboBoxEx
            // 
            this.clienteComboBoxEx.DisplayMember = "Text";
            this.clienteComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clienteComboBoxEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clienteComboBoxEx.FormattingEnabled = true;
            this.clienteComboBoxEx.ItemHeight = 14;
            this.clienteComboBoxEx.Items.AddRange(new object[] {
            this.comboItem3,
            this.comboItem4});
            this.clienteComboBoxEx.Location = new System.Drawing.Point(77, 83);
            this.clienteComboBoxEx.Name = "clienteComboBoxEx";
            this.clienteComboBoxEx.Size = new System.Drawing.Size(238, 20);
            this.clienteComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.clienteComboBoxEx.TabIndex = 3;
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "90";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "92";
            // 
            // AnexoTipoValeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelarButtonX;
            this.ClientSize = new System.Drawing.Size(327, 153);
            this.Controls.Add(this.clienteComboBoxEx);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.cancelarButtonX);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.anexoNumericUpDown);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.tipoValeComboBoxEx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnexoTipoValeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anexo/Tipo Vale";
            ((System.ComponentModel.ISupportInitialize)(this.anexoNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx tipoValeComboBoxEx;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.NumericUpDown anexoNumericUpDown;
        private DevComponents.DotNetBar.ButtonX cancelarButtonX;
        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx clienteComboBoxEx;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
    }
}