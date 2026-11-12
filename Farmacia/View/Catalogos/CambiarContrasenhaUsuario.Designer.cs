namespace SIF.View.Ventas
{
    partial class CambiarContrasenhaUsuario
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
            this.contrasenaTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.usuarioTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxDropDown();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.CancelarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.contrasenaTextBoxX, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.usuarioTextBoxX, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX2, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 104);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // contrasenaTextBoxX
            // 
            this.contrasenaTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.contrasenaTextBoxX.Border.Class = "TextBoxBorder";
            this.contrasenaTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.contrasenaTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.contrasenaTextBoxX.Location = new System.Drawing.Point(3, 81);
            this.contrasenaTextBoxX.Name = "contrasenaTextBoxX";
            this.contrasenaTextBoxX.PasswordChar = '•';
            this.contrasenaTextBoxX.Size = new System.Drawing.Size(274, 20);
            this.contrasenaTextBoxX.TabIndex = 2;
            // 
            // usuarioTextBoxX
            // 
            this.usuarioTextBoxX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.usuarioTextBoxX.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // 
            // 
            this.usuarioTextBoxX.BackgroundStyle.Class = "TextBoxBorder";
            this.usuarioTextBoxX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.usuarioTextBoxX.Location = new System.Drawing.Point(3, 29);
            this.usuarioTextBoxX.Name = "usuarioTextBoxX";
            this.usuarioTextBoxX.PasswordChar = '•';
            this.usuarioTextBoxX.Size = new System.Drawing.Size(274, 20);
            this.usuarioTextBoxX.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.usuarioTextBoxX.TabIndex = 1;
            this.usuarioTextBoxX.Text = "";
            this.usuarioTextBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usuarioTextBoxX_KeyDown);
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(120, 20);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Nueva contraseña:";
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(3, 55);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(120, 20);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Confirme contraseña";
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(123, 110);
            this.aceptarButtonX.Name = "aceptarButtonX";
            this.aceptarButtonX.Size = new System.Drawing.Size(80, 26);
            this.aceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButtonX.TabIndex = 3;
            this.aceptarButtonX.Text = "Aceptar";
            this.aceptarButtonX.TextColor = System.Drawing.Color.White;
            this.aceptarButtonX.Click += new System.EventHandler(this.aceptarButtonX_Click);
            // 
            // CancelarButtonX
            // 
            this.CancelarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.CancelarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.CancelarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.CancelarButtonX.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarButtonX.Location = new System.Drawing.Point(209, 110);
            this.CancelarButtonX.Name = "CancelarButtonX";
            this.CancelarButtonX.Size = new System.Drawing.Size(80, 26);
            this.CancelarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CancelarButtonX.TabIndex = 4;
            this.CancelarButtonX.Text = "Cancelar";
            this.CancelarButtonX.TextColor = System.Drawing.Color.White;
            this.CancelarButtonX.Click += new System.EventHandler(this.CancelarButtonX_Click);
            // 
            // CambiarContrasenhaUsuario
            // 
            this.AcceptButton = this.aceptarButtonX;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButtonX;
            this.ClientSize = new System.Drawing.Size(304, 148);
            this.ControlBox = false;
            this.Controls.Add(this.CancelarButtonX);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CambiarContrasenhaUsuario";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuario";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX contrasenaTextBoxX;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private DevComponents.DotNetBar.ButtonX CancelarButtonX;
        private DevComponents.DotNetBar.Controls.TextBoxDropDown usuarioTextBoxX;
    }
}