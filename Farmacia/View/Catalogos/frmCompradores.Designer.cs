namespace SIF.View.Catalogos
{
    partial class frmCompradores
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
            this.btnXAceptar = new DevComponents.DotNetBar.ButtonX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnXCancelar = new DevComponents.DotNetBar.ButtonX();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXAceptar
            // 
            this.btnXAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXAceptar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnXAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnXAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnXAceptar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXAceptar.Location = new System.Drawing.Point(3, 4);
            this.btnXAceptar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXAceptar.Name = "btnCAceptar";
            this.btnXAceptar.Size = new System.Drawing.Size(80, 31);
            this.btnXAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXAceptar.TabIndex = 20;
            this.btnXAceptar.Text = "Aceptar";
            this.btnXAceptar.TextColor = System.Drawing.Color.White;
            this.btnXAceptar.Click += new System.EventHandler(this.btnXAceptar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkedListBox1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.83643F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.16357F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(339, 269);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel2.Controls.Add(this.btnXAceptar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnXCancelar, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(155, 217);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(181, 39);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnXCancelar
            // 
            this.btnXCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnXCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnXCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnXCancelar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXCancelar.Location = new System.Drawing.Point(93, 4);
            this.btnXCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXCancelar.Name = "cancelarButtonX";
            this.btnXCancelar.Size = new System.Drawing.Size(80, 31);
            this.btnXCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXCancelar.TabIndex = 20;
            this.btnXCancelar.Text = "Cancelar";
            this.btnXCancelar.TextColor = System.Drawing.Color.White;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(3, 3);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(329, 184);
            this.checkedListBox1.TabIndex = 1;
            // 
            // frmCompradores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 308);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "frmCompradores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compradores";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnXAceptar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private DevComponents.DotNetBar.ButtonX btnXCancelar;
     
    }
}