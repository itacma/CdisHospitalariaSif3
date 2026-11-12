namespace SIF.View.Reportes
{
    partial class frmImpresion
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
            this.crViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crViewer
            // 
            this.crViewer.ActiveViewIndex = -1;
            this.crViewer.BackColor = System.Drawing.Color.White;
            this.crViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crViewer.ForeColor = System.Drawing.Color.Black;
            this.crViewer.Location = new System.Drawing.Point(0, 0);
            this.crViewer.Name = "crViewer";
            this.crViewer.ReuseParameterValuesOnRefresh = true;
            this.crViewer.Size = new System.Drawing.Size(797, 383);
            this.crViewer.TabIndex = 0;
            // 
            // frmImpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 383);
            this.Controls.Add(this.crViewer);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmImpresion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Impresión";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmImpresion_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crViewer;
    }
}