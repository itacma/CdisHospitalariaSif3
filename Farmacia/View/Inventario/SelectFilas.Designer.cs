namespace SIF.View.Inventario
{
    partial class SelectFilas
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.AceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.CancelarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.DisplayMember = "Name";
            this.checkedListBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(44, 29);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(269, 184);
            this.checkedListBox1.TabIndex = 0;
            // 
            // AceptarButtonX
            // 
            this.AceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.AceptarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AceptarButtonX.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AceptarButtonX.Location = new System.Drawing.Point(50, 250);
            this.AceptarButtonX.Name = "AceptarButtonX";
            this.AceptarButtonX.Size = new System.Drawing.Size(100, 50);
            this.AceptarButtonX.TabIndex = 0;
            this.AceptarButtonX.Text = "Aceptar";
            this.AceptarButtonX.TextColor = System.Drawing.Color.Black;
            this.AceptarButtonX.Click += new System.EventHandler(this.aceptarButtonX_Click);
            // 
            // CancelarButtonX
            // 
            this.CancelarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.CancelarButtonX.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButtonX.Location = new System.Drawing.Point(200, 250);
            this.CancelarButtonX.Name = "CancelarButtonX";
            this.CancelarButtonX.Size = new System.Drawing.Size(100, 50);
            this.CancelarButtonX.TabIndex = 0;
            this.CancelarButtonX.Text = "Cancelar";
            this.CancelarButtonX.TextColor = System.Drawing.Color.Black;
            this.CancelarButtonX.Click += new System.EventHandler(this.CancelarButtonX_Click);
            // 
            // SelectFilas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.CancelButton = this.CancelarButtonX;
            this.ClientSize = new System.Drawing.Size(342, 312);
            this.ControlBox = false;
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.AceptarButtonX);
            this.Controls.Add(this.CancelarButtonX);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectFilas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecciona las Filas a Surtir";
            this.Load += new System.EventHandler(this.SelectFilas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private DevComponents.DotNetBar.ButtonX AceptarButtonX;
        private DevComponents.DotNetBar.ButtonX CancelarButtonX;
    }
}