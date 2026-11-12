
namespace SIF.View.Extras
{
    partial class ProgresoExpImpFileExcel
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

            this.examinarDirectorio = new DevComponents.DotNetBar.ButtonX();
            this.ExportarBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            //this.ExportarBackgroundWorkerCsv = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExportarBackgroundWorker
            // 
            this.ExportarBackgroundWorker.WorkerReportsProgress = true;
            this.ExportarBackgroundWorker.WorkerSupportsCancellation = true;
            this.ExportarBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ExportarBackgroundWorker_DoWork);
            this.ExportarBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ExportarBackgroundWorker_ProgressChanged);
            this.ExportarBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ExportarBackgroundWorker_RunWorkerCompleted);
            // 
            // examinarDirectorio
            // 
            this.examinarDirectorio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.examinarDirectorio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.examinarDirectorio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.examinarDirectorio.Image = global::SIF.Properties.Resources.Open16;
            this.examinarDirectorio.Location = new System.Drawing.Point(227, 28);
            this.examinarDirectorio.Name = "examinarDirectorio";
            this.examinarDirectorio.Size = new System.Drawing.Size(21, 23);
            this.examinarDirectorio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.examinarDirectorio.TabIndex = 8;
            this.examinarDirectorio.Tooltip = "Examinar";
            this.examinarDirectorio.Click += new System.EventHandler(this.examinarDirectorio_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.progressBar1, 5);
            this.progressBar1.ForeColor = System.Drawing.Color.Black;
            this.progressBar1.Location = new System.Drawing.Point(3, 34);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(787, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(635, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Iniciar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(428, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(149, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(161, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Formato";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.66961F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.05044F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.052963F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.examinarDirectorio, 3, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(793, 62);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // ProgresoExpImpFileExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 270);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProgresoExpImpFileExcel";
            this.Text = "Progreso";
            this.Load += new System.EventHandler(this.Progreso_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker ExportarBackgroundWorker;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.ButtonX examinarDirectorio;
    }
}



