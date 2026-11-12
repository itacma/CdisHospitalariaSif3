namespace SIF.View.Marketing
{
    partial class SenEmailClientsAndCollaborators
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFiles = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtEmailFrom = new System.Windows.Forms.TextBox();
            this.GrupoEmailBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.SendButtonX = new DevComponents.DotNetBar.ButtonX();
            this.AddFileButtonX = new DevComponents.DotNetBar.ButtonX();
            this.btnConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(18, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Mensaje:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(18, 89);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Asunto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(11, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Enviar a Grupo:";
            this.label3.Visible = false;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.BackColor = System.Drawing.Color.White;
            this.lblFiles.ForeColor = System.Drawing.Color.Black;
            this.lblFiles.Location = new System.Drawing.Point(92, 307);
            this.lblFiles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(16, 13);
            this.lblFiles.TabIndex = 16;
            this.lblFiles.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(92, 285);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Archivos adjuntos:";
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.ForeColor = System.Drawing.Color.Black;
            this.txtMessage.Location = new System.Drawing.Point(94, 129);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(2);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(296, 145);
            this.txtMessage.TabIndex = 12;
            this.txtMessage.Text = "";
            // 
            // txtSubject
            // 
            this.txtSubject.BackColor = System.Drawing.Color.White;
            this.txtSubject.ForeColor = System.Drawing.Color.Black;
            this.txtSubject.Location = new System.Drawing.Point(94, 89);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(2);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(296, 20);
            this.txtSubject.TabIndex = 11;
            // 
            // txtEmailFrom
            // 
            this.txtEmailFrom.BackColor = System.Drawing.Color.White;
            this.txtEmailFrom.ForeColor = System.Drawing.Color.Black;
            this.txtEmailFrom.Location = new System.Drawing.Point(337, 11);
            this.txtEmailFrom.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailFrom.Name = "txtEmailFrom";
            this.txtEmailFrom.Size = new System.Drawing.Size(53, 20);
            this.txtEmailFrom.TabIndex = 10;
            this.txtEmailFrom.Visible = false;
            // 
            // GrupoEmailBoxEx
            // 
            this.GrupoEmailBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.GrupoEmailBoxEx.DisplayMember = "Text";
            this.GrupoEmailBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.GrupoEmailBoxEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GrupoEmailBoxEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GrupoEmailBoxEx.ForeColor = System.Drawing.SystemColors.WindowText;
            this.GrupoEmailBoxEx.FormattingEnabled = true;
            this.GrupoEmailBoxEx.ItemHeight = 14;
            this.GrupoEmailBoxEx.Location = new System.Drawing.Point(95, 35);
            this.GrupoEmailBoxEx.Name = "GrupoEmailBoxEx";
            this.GrupoEmailBoxEx.Size = new System.Drawing.Size(295, 20);
            this.GrupoEmailBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.GrupoEmailBoxEx.TabIndex = 3;
            this.GrupoEmailBoxEx.SelectedValueChanged += new System.EventHandler(this.GrupoEmailBoxEx_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(92, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Usuarios";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // SendButtonX
            // 
            this.SendButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.SendButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendButtonX.BackColor = System.Drawing.Color.DarkBlue;
            this.SendButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.SendButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendButtonX.Image = global::SIF.Properties.Resources.SendMail;
            this.SendButtonX.ImagePosition = DevComponents.DotNetBar.eImagePosition.Bottom;
            this.SendButtonX.Location = new System.Drawing.Point(334, 370);
            this.SendButtonX.Name = "aceptarButtonX";
            this.SendButtonX.Size = new System.Drawing.Size(50, 50);
            this.SendButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SendButtonX.TabIndex = 3;
            this.SendButtonX.TextColor = System.Drawing.Color.White;
            this.SendButtonX.Click += new System.EventHandler(this.SendButtonX_Click);
            // 
            // AddFileButtonX
            // 
            this.AddFileButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.AddFileButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddFileButtonX.BackColor = System.Drawing.Color.DarkBlue;
            this.AddFileButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.AddFileButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddFileButtonX.Image = global::SIF.Properties.Resources.Upload2;
            this.AddFileButtonX.ImagePosition = DevComponents.DotNetBar.eImagePosition.Bottom;
            this.AddFileButtonX.Location = new System.Drawing.Point(270, 370);
            this.AddFileButtonX.Name = "AddFileButtonX";
            this.AddFileButtonX.Size = new System.Drawing.Size(50, 50);
            this.AddFileButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.AddFileButtonX.TabIndex = 3;
            this.AddFileButtonX.TextColor = System.Drawing.Color.White;
            this.AddFileButtonX.Click += new System.EventHandler(this.AddFileButtonX_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(14, 392);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(83, 23);
            this.btnConfig.TabIndex = 21;
            this.btnConfig.Text = "Configuración";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.button1_Click);
            // 
            // SenEmailClientsAndCollaborators
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 427);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SendButtonX);
            this.Controls.Add(this.AddFileButtonX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtEmailFrom);
            this.Controls.Add(this.GrupoEmailBoxEx);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SenEmailClientsAndCollaborators";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar email";
            this.Load += new System.EventHandler(this.SenEmailClientsAndCollaborators_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtEmailFrom;
        private DevComponents.DotNetBar.ButtonX SendButtonX;
        private DevComponents.DotNetBar.ButtonX AddFileButtonX;
        private DevComponents.DotNetBar.Controls.ComboBoxEx GrupoEmailBoxEx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfig;
    }
}