namespace SIF.View.Ventas
{
    partial class LocalizacionLinea
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.ckbTodasLasLineas = new System.Windows.Forms.CheckBox();
            this.cmbLinea = new System.Windows.Forms.ComboBox();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.CancelarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ckbTodasLasLineas, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbLinea, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.55319F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.44681F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 103);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.labelX1.Size = new System.Drawing.Size(120, 15);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Linea:";
            // 
            // ckbTodasLasLineas
            // 
            this.ckbTodasLasLineas.AutoSize = true;
            this.ckbTodasLasLineas.Location = new System.Drawing.Point(3, 63);
            this.ckbTodasLasLineas.Name = "ckbTodasLasLineas";
            this.ckbTodasLasLineas.Size = new System.Drawing.Size(102, 16);
            this.ckbTodasLasLineas.TabIndex = 2;
            this.ckbTodasLasLineas.Text = "Todas las lineas";
            this.ckbTodasLasLineas.UseVisualStyleBackColor = true;
            this.ckbTodasLasLineas.Visible = false;
            this.ckbTodasLasLineas.CheckedChanged += new System.EventHandler(this.ckbTodasLasLineas_CheckedChanged);
            // 
            // cmbLinea
            // 
            this.cmbLinea.FormattingEnabled = true;
            this.cmbLinea.Location = new System.Drawing.Point(3, 34);
            this.cmbLinea.Name = "cmbLinea";
            this.cmbLinea.Size = new System.Drawing.Size(274, 21);
            this.cmbLinea.TabIndex = 3;
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(122, 104);
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
            this.CancelarButtonX.Location = new System.Drawing.Point(208, 104);
            this.CancelarButtonX.Name = "CancelarButtonX";
            this.CancelarButtonX.Size = new System.Drawing.Size(80, 26);
            this.CancelarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CancelarButtonX.TabIndex = 4;
            this.CancelarButtonX.Text = "Cancelar";
            this.CancelarButtonX.TextColor = System.Drawing.Color.White;
            this.CancelarButtonX.Click += new System.EventHandler(this.CancelarButtonX_Click);
            // 
            // LocalizacionLinea
            // 
            this.AcceptButton = this.aceptarButtonX;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButtonX;
            this.ClientSize = new System.Drawing.Size(303, 147);
            this.ControlBox = false;
            this.Controls.Add(this.CancelarButtonX);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LocalizacionLinea";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linea";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private DevComponents.DotNetBar.ButtonX CancelarButtonX;
        private System.Windows.Forms.CheckBox ckbTodasLasLineas;
        public System.Windows.Forms.ComboBox cmbLinea;
    }
}