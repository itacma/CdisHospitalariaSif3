namespace SIF.View.Catalogos
{
    partial class ListaTipoMedicamentoForm
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
        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        this.listaTipoMedicamentoCheckedListBox = new System.Windows.Forms.CheckedListBox();
        this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
        this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
        this.cancelarButton = new DevComponents.DotNetBar.ButtonX();
        this.notaLabel = new System.Windows.Forms.Label();
        this.claveSatTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
        this.tableLayoutPanel1.SuspendLayout();
        this.tableLayoutPanel2.SuspendLayout();
        this.SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.tableLayoutPanel1.ColumnCount = 1;
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanel1.Controls.Add(this.listaTipoMedicamentoCheckedListBox, 0, 0);
        this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
        this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 4);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.RowCount = 2;
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
        this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 388);
        this.tableLayoutPanel1.TabIndex = 2;
        // 
        // listaTipoMedicamentoCheckedListBox
        // 
        this.listaTipoMedicamentoCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.listaTipoMedicamentoCheckedListBox.FormattingEnabled = true;
        this.listaTipoMedicamentoCheckedListBox.Location = new System.Drawing.Point(3, 3);
        this.listaTipoMedicamentoCheckedListBox.Name = "listaTipoMedicamentoCheckedListBox";
        this.listaTipoMedicamentoCheckedListBox.Size = new System.Drawing.Size(594, 337);
        this.listaTipoMedicamentoCheckedListBox.TabIndex = 0;
        // 
        // tableLayoutPanel2
        // 
        this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.tableLayoutPanel2.ColumnCount = 3;
        this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.53659F));
        this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.46341F));
        this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
        this.tableLayoutPanel2.Controls.Add(this.claveSatTextBoxX, 0, 0);
        this.tableLayoutPanel2.Controls.Add(this.aceptarButtonX, 1, 0);
        this.tableLayoutPanel2.Controls.Add(this.cancelarButton, 2, 0);
        this.tableLayoutPanel2.Location = new System.Drawing.Point(305, 346);
        this.tableLayoutPanel2.Name = "tableLayoutPanel2";
        this.tableLayoutPanel2.RowCount = 1;
        this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanel2.Size = new System.Drawing.Size(292, 39);
        this.tableLayoutPanel2.TabIndex = 1;
        // 
        // claveSatTextBoxX
        // 
        this.claveSatTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.claveSatTextBoxX.BackColor = System.Drawing.Color.White;
        // 
        // 
        // 
        this.claveSatTextBoxX.Border.Class = "TextBoxBorder";
        this.claveSatTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
        this.claveSatTextBoxX.ForeColor = System.Drawing.Color.Black;
        this.claveSatTextBoxX.Location = new System.Drawing.Point(83, 144);
        this.claveSatTextBoxX.Name = "claveSatTextBoxX";
        this.claveSatTextBoxX.Size = new System.Drawing.Size(328, 20);
        this.claveSatTextBoxX.TabIndex = 1;
        this.claveSatTextBoxX.WatermarkText = "Clave Sat";
        this.claveSatTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.claveSatTextBoxX_KeyDown);
        // 
        // aceptarButtonX
        // 
        this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
        this.aceptarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
        this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
        this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.aceptarButtonX.Location = new System.Drawing.Point(124, 4);
        this.aceptarButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        this.aceptarButtonX.Name = "aceptarButtonX";
        this.aceptarButtonX.Size = new System.Drawing.Size(80, 31);
        this.aceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
        this.aceptarButtonX.TabIndex = 20;
        this.aceptarButtonX.Text = "Aceptar";
        this.aceptarButtonX.TextColor = System.Drawing.Color.White;
        this.aceptarButtonX.Click += new System.EventHandler(this.aceptarButtonX_Click);
        // 
        // cancelarButton
        // 
        this.cancelarButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
        this.cancelarButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.cancelarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
        this.cancelarButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
        this.cancelarButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cancelarButton.Location = new System.Drawing.Point(210, 4);
        this.cancelarButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        this.cancelarButton.Name = "cancelarButton";
        this.cancelarButton.Size = new System.Drawing.Size(79, 31);
        this.cancelarButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
        this.cancelarButton.TabIndex = 19;
        this.cancelarButton.Text = "Cancelar";
        this.cancelarButton.TextColor = System.Drawing.Color.White;
        this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
        // 
        // notaLabel
        // 
        this.notaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.notaLabel.AutoSize = true;
        this.notaLabel.Location = new System.Drawing.Point(9, 354);
        this.notaLabel.Name = "notaLabel";
        this.notaLabel.Size = new System.Drawing.Size(0, 13);
        this.notaLabel.TabIndex = 3;
        // 
        // ListaTipoMedicamentoForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(625, 396);
        this.Controls.Add(this.notaLabel);
        this.Controls.Add(this.tableLayoutPanel1);
        this.DoubleBuffered = true;
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Name = "ListaTipoMedicamentoForm";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "TIPO MEDICAMENTO";
        this.tableLayoutPanel1.ResumeLayout(false);
        this.tableLayoutPanel2.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevComponents.DotNetBar.ButtonX cancelarButton;
        public System.Windows.Forms.CheckedListBox listaTipoMedicamentoCheckedListBox;
        public System.Windows.Forms.Label notaLabel;
        public DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private DevComponents.DotNetBar.Controls.TextBoxX claveSatTextBoxX;

    }
}