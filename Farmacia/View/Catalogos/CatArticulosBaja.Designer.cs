namespace SIF.View.Catalogos
{
    partial class CatArticulosBaja
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatArticulosBaja));
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.buttonX_buscar = new DevComponents.DotNetBar.ButtonX();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxXBuscar = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX_Activar = new DevComponents.DotNetBar.ButtonX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(12, 87);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.Size = new System.Drawing.Size(864, 480);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToOrderColumns = true;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.ReadOnly = true;

            // 
            // buttonX_buscar
            // 
            this.buttonX_buscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX_buscar.Location = new System.Drawing.Point(3, 3);
            this.buttonX_buscar.Name = "buttonX_buscar";
            this.buttonX_buscar.Size = new System.Drawing.Size(107, 63);
            this.buttonX_buscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonX_buscar.TabIndex = 0;
            this.buttonX_buscar.Text = "Buscar";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(116, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "VVVVVVVVVVVVVVVVV";
            // 
            // textBoxXBuscar
            // 
            this.textBoxXBuscar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // 
            // 
            this.textBoxXBuscar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXBuscar.Location = new System.Drawing.Point(116, 28);
            this.textBoxXBuscar.Name = "textBoxXBuscar";
            this.textBoxXBuscar.TabIndex = 0;

            this.textBoxXBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxXBuscar.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxXBuscar.Border.Class = "TextBoxBorder";
            this.textBoxXBuscar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            //this.textBoxXBuscar.ButtonCustom.Image = global::SIF.Properties.Resources.FilterDelete16;
            //this.textBoxXBuscar.ButtonCustom.Visible = true;
            this.textBoxXBuscar.ForeColor = System.Drawing.Color.Black;
          //  this.highlighter1.SetHighlightOnFocus(this.buscarTextBoxX, true);
            this.textBoxXBuscar.WatermarkText = "Buscar";
            this.textBoxXBuscar.ButtonCustomClick += new System.EventHandler(this.buscarTextBoxX_ButtonCustomClick);
            this.textBoxXBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buscarTextBoxX_KeyUp);
            // 
            // buttonX_Activar
            // 
            this.buttonX_Activar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Activar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX_Activar.Location = new System.Drawing.Point(567, 3);
            this.buttonX_Activar.Name = "buttonX_Activar";
            this.buttonX_Activar.Size = new System.Drawing.Size(294, 63);
            this.buttonX_Activar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonX_Activar.TabIndex = 0;
            this.buttonX_Activar.Text = "Activar";
            this.buttonX_Activar.Click += new System.EventHandler(this.eliminarButtonItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.04745F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.95255F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 299F));
            this.tableLayoutPanel1.Controls.Add(this.buttonX_Activar, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonX_buscar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxXBuscar, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(864, 69);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // CatArticulosBaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 579);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dataGridViewX1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Load += new System.EventHandler(this.CatArticulosUserControl_Load);
            this.Name = "CatArticulosBaja";
            this.Text = "Articulos Baja";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX buttonX_buscar;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXBuscar;
        private DevComponents.DotNetBar.ButtonX buttonX_Activar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}