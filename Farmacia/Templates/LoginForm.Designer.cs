namespace SIF.Templates
{
    partial class LoginForm
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.contrasenaTextBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.aceptarButton = new DevComponents.DotNetBar.ButtonX();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.usuarioTextBox = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cancelarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.keyBoardButtonX = new DevComponents.DotNetBar.ButtonX();
            this.superValidator = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator();
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(97)))), ((int)(((byte)(157)))));
            label2.Location = new System.Drawing.Point(158, 55);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(127, 30);
            label2.TabIndex = 0;
            label2.Text = "Contraseña:";
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(97)))), ((int)(((byte)(157)))));
            label1.Location = new System.Drawing.Point(158, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(91, 30);
            label1.TabIndex = 0;
            label1.Text = "Usuario:";
            label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // contrasenaTextBox
            // 
            this.contrasenaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.contrasenaTextBox.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.contrasenaTextBox.Border.Class = "TextBoxBorder";
            this.contrasenaTextBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.contrasenaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contrasenaTextBox.ForeColor = System.Drawing.Color.Black;
            this.highlighter.SetHighlightOnFocus(this.contrasenaTextBox, true);
            this.contrasenaTextBox.Location = new System.Drawing.Point(293, 58);
            this.contrasenaTextBox.Name = "contrasenaTextBox";
            this.contrasenaTextBox.PasswordChar = '●';
            this.contrasenaTextBox.Size = new System.Drawing.Size(188, 23);
            this.contrasenaTextBox.TabIndex = 2;
            this.contrasenaTextBox.UseSystemPasswordChar = true;
            this.superValidator.SetValidator1(this.contrasenaTextBox, this.requiredFieldValidator2);
            this.contrasenaTextBox.WatermarkText = "Contraseña";
            this.contrasenaTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.contrasenaTextBox_KeyDown);
            // 
            // aceptarButton
            // 
            this.aceptarButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.aceptarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.aceptarButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButton.Location = new System.Drawing.Point(170, 95);
            this.aceptarButton.Margin = new System.Windows.Forms.Padding(0);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(120, 30);
            this.aceptarButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButton.TabIndex = 3;
            this.aceptarButton.Text = "Iniciar";
            this.aceptarButton.TextColor = System.Drawing.Color.White;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.usuarioTextBox, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.contrasenaTextBox, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.aceptarButton, 2, 3);
            this.tableLayoutPanel2.Controls.Add(label2, 2, 2);
            this.tableLayoutPanel2.Controls.Add(label1, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.cancelarButtonX, 3, 3);
            this.tableLayoutPanel2.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(69, 113);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33444F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33444F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33112F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(504, 142);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // usuarioTextBox
            // 
            this.usuarioTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.usuarioTextBox.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.usuarioTextBox.Border.Class = "TextBoxBorder";
            this.usuarioTextBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.usuarioTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioTextBox.ForeColor = System.Drawing.Color.Black;
            this.highlighter.SetHighlightOnFocus(this.usuarioTextBox, true);
            this.usuarioTextBox.Location = new System.Drawing.Point(293, 17);
            this.usuarioTextBox.Name = "usuarioTextBox";
            this.usuarioTextBox.Size = new System.Drawing.Size(188, 25);
            this.usuarioTextBox.TabIndex = 1;
            this.superValidator.SetValidator1(this.usuarioTextBox, this.requiredFieldValidator1);
            this.usuarioTextBox.WatermarkText = "Usuario";
            this.usuarioTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usuarioTextBox_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.ForeColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = global::SIF.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(23, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.tableLayoutPanel2.SetRowSpan(this.pictureBox1, 3);
            this.pictureBox1.Size = new System.Drawing.Size(129, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // cancelarButtonX
            // 
            this.cancelarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cancelarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.cancelarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.cancelarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarButtonX.Location = new System.Drawing.Point(364, 95);
            this.cancelarButtonX.Margin = new System.Windows.Forms.Padding(0);
            this.cancelarButtonX.Name = "cancelarButtonX";
            this.cancelarButtonX.Size = new System.Drawing.Size(120, 30);
            this.cancelarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButtonX.TabIndex = 4;
            this.cancelarButtonX.Text = "Cancelar";
            this.cancelarButtonX.TextColor = System.Drawing.Color.White;
            this.cancelarButtonX.Click += new System.EventHandler(this.cancelarButtonX_Click);
            // 
            // keyBoardButtonX
            // 
            this.keyBoardButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.keyBoardButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.keyBoardButtonX.Image = global::SIF.Properties.Resources.Keyboard_1;
            this.keyBoardButtonX.Location = new System.Drawing.Point(69, 302);
            this.keyBoardButtonX.Name = "keyBoardButtonX";
            this.keyBoardButtonX.Size = new System.Drawing.Size(68, 58);
            this.keyBoardButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.keyBoardButtonX.TabIndex = 4;
            this.keyBoardButtonX.Click += new System.EventHandler(this.keyBoardButtonX_Click);
            // 
            // superValidator
            // 
            this.superValidator.ContainerControl = this;
            this.superValidator.Highlighter = this.highlighter;
            this.superValidator.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // highlighter
            // 
            this.highlighter.ContainerControl = this;
            this.highlighter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.BackgroundImage = global::SIF.Properties.Resources.loginBack;
            this.ClientSize = new System.Drawing.Size(644, 399);
            this.ControlBox = false;
            this.Controls.Add(this.keyBoardButtonX);
            this.Controls.Add(this.tableLayoutPanel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.Opacity = 0.85D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX contrasenaTextBox;
        private DevComponents.DotNetBar.ButtonX aceptarButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.TextBoxX usuarioTextBox;
        private DevComponents.DotNetBar.ButtonX keyBoardButtonX;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.ButtonX cancelarButtonX;
    }
}