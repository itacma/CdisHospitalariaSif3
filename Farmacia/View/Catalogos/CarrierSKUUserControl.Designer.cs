namespace SIF.View.Catalogos
{
    partial class CarrierSKU
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarrierSKU));
            DevComponents.DotNetBar.LabelX labelX1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NuevoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.eliminarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColumnNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLAVEColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComisionColumn = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.CarrierIDColumn = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.ACTIVOColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiNoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buscarBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiNoBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.NuevoButtonItem,
            this.eliminarButtonItem});
            this.bar1.ItemSpacing = 10;
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(168, 32);
            this.titleLabel.Text = "SIF\\Carrier SKU";
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewX1);
            this.splitContainer1.SplitterDistance = 36;
            // 
            // statusLabel
            // 
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.statusLabel.Text = "";
            // 
            // fotoPictureBox
            // 
            this.fotoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("fotoPictureBox.Image")));
            // 
            // apellidosLabel
            // 
            this.apellidosLabel.Text = "";
            // 
            // nombreLabel
            // 
            this.nombreLabel.Text = "";
            // 
            // labelX1
            // 
            labelX1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelX1.AutoSize = true;
            // 
            // 
            // 
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.Location = new System.Drawing.Point(3, 8);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(43, 20);
            labelX1.TabIndex = 1;
            labelX1.Text = "Buscar:";
            // 
            // NuevoButtonItem
            // 
            this.NuevoButtonItem.HoverImage = global::SIF.Properties.Resources.NewDocument1;
            this.NuevoButtonItem.Image = global::SIF.Properties.Resources.NewDocument;
            this.NuevoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.NuevoButtonItem.Name = "NuevoButtonItem";
            this.NuevoButtonItem.Text = "Nuevo\r\n[F2]";
            // 
            // eliminarButtonItem
            // 
            this.eliminarButtonItem.HoverImage = global::SIF.Properties.Resources.DeleteDocument1;
            this.eliminarButtonItem.Image = global::SIF.Properties.Resources.DeleteDocument;
            this.eliminarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.eliminarButtonItem.Name = "eliminarButtonItem";
            this.eliminarButtonItem.Text = "Eliminar\r\n[F6]";
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // buscarTextBoxX
            // 
            this.buscarTextBoxX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buscarTextBoxX.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.buscarTextBoxX.Border.Class = "TextBoxBorder";
            this.buscarTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.buscarTextBoxX.ButtonCustom.Image = global::SIF.Properties.Resources.FilterDelete16;
            this.buscarTextBoxX.ButtonCustom.Visible = true;
            this.buscarTextBoxX.ForeColor = System.Drawing.Color.Black;
            this.highlighter1.SetHighlightOnFocus(this.buscarTextBoxX, true);
            this.buscarTextBoxX.Location = new System.Drawing.Point(51, 5);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(779, 25);
            this.buscarTextBoxX.TabIndex = 2;
            this.buscarTextBoxX.WatermarkText = "Buscar";
            this.buscarTextBoxX.ButtonCustomClick += new System.EventHandler(this.buscarTextBoxX_ButtonCustomClick);
            this.buscarTextBoxX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buscarTextBoxX_KeyUp);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToOrderColumns = true;
            this.dataGridViewX1.AutoGenerateColumns = false;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNombre,
            this.CLAVEColumn,
            this.ComisionColumn,
            this.CarrierIDColumn,
            this.ACTIVOColumn});
            this.dataGridViewX1.DataSource = this.bindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(915, 528);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            // 
            // ColumnNombre
            // 
            this.ColumnNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnNombre.DataPropertyName = "SKU";
            this.ColumnNombre.HeaderText = "SKU";
            this.ColumnNombre.MaxInputLength = 20;
            this.ColumnNombre.Name = "ColumnNombre";
            // 
            // CLAVEColumn
            // 
            this.CLAVEColumn.DataPropertyName = "Clave";
            this.CLAVEColumn.HeaderText = "CLAVE";
            this.CLAVEColumn.MaxInputLength = 20;
            this.CLAVEColumn.Name = "CLAVEColumn";
            // 
            // ComisionColumn
            // 
            // 
            // 
            // 
            this.ComisionColumn.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.ComisionColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ComisionColumn.DataPropertyName = "Monto";
            dataGridViewCellStyle3.Format = "0.00%";
            dataGridViewCellStyle3.NullValue = "0";
            this.ComisionColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.ComisionColumn.HeaderText = "MONTO";
            this.ComisionColumn.Increment = 1D;
            this.ComisionColumn.MaxValue = 10000D;
            this.ComisionColumn.MinValue = 1D;
            this.ComisionColumn.Name = "ComisionColumn";
            this.ComisionColumn.ShowUpDown = true;
            // 
            // CarrierIDColumn
            // 
            this.CarrierIDColumn.DataPropertyName = "CarrierID";
            this.CarrierIDColumn.DropDownHeight = 106;
            this.CarrierIDColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CarrierIDColumn.DropDownWidth = 121;
            this.CarrierIDColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CarrierIDColumn.HeaderText = "CARRIER";
            this.CarrierIDColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CarrierIDColumn.IntegralHeight = false;
            this.CarrierIDColumn.ItemHeight = 15;
            this.CarrierIDColumn.Name = "CarrierIDColumn";
            this.CarrierIDColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // ACTIVOColumn
            // 
            this.ACTIVOColumn.DataPropertyName = "Activo";
            this.ACTIVOColumn.HeaderText = "ACTIVO";
            this.ACTIVOColumn.Name = "ACTIVOColumn";
            this.ACTIVOColumn.ReadOnly = true;
            this.ACTIVOColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // buscarBackgroundWorker
            // 
            this.buscarBackgroundWorker.WorkerReportsProgress = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.Controls.Add(labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarTextBoxX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarButtonX, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 36);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // buscarButtonX
            // 
            this.buscarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buscarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buscarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buscarButtonX.Location = new System.Drawing.Point(837, 6);
            this.buscarButtonX.Name = "buscarButtonX";
            this.buscarButtonX.Size = new System.Drawing.Size(75, 23);
            this.buscarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buscarButtonX.TabIndex = 0;
            this.buscarButtonX.Text = "Buscar";
            this.buscarButtonX.Click += new System.EventHandler(this.buscarButtonX_Click);
            // 
            // CarrierSKU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CarrierSKU";
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiNoBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem NuevoButtonItem;
        private DevComponents.DotNetBar.ButtonItem eliminarButtonItem;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.BindingSource SiNoBindingSource;
        private System.ComponentModel.BackgroundWorker buscarBackgroundWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLAVEColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn ComisionColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn CarrierIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACTIVOColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
    }
}
