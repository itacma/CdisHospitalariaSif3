namespace SIF.View.Inventario
{
    partial class CatEquivalenciasUserControl
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
            DevComponents.DotNetBar.LabelX labelX1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatEquivalenciasUserControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NuevoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.eliminarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ID = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.ARTICULO_ID = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EQUIVALENCIA_ID = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.NOMBRE_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIDAD = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.ACTIVO = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
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
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
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
            this.titleLabel.Size = new System.Drawing.Size(331, 32);
            this.titleLabel.Text = "INVENTARIOS\\EQUIVALENCIAS";
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
            this.splitContainer1.SplitterDistance = 32;
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
            labelX1.Location = new System.Drawing.Point(3, 6);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(43, 20);
            labelX1.TabIndex = 1;
            labelX1.Text = "Buscar:";
            // 
            // NuevoButtonItem
            // 
            this.NuevoButtonItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("NuevoButtonItem.HoverImage")));
            this.NuevoButtonItem.Image = ((System.Drawing.Image)(resources.GetObject("NuevoButtonItem.Image")));
            this.NuevoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.NuevoButtonItem.Name = "NuevoButtonItem";
            this.NuevoButtonItem.Tag = "1";
            this.NuevoButtonItem.Text = "Nuevo\r\n[F2]";
            this.NuevoButtonItem.Click += new System.EventHandler(this.NuevoButtonItem_Click);
            // 
            // eliminarButtonItem
            // 
            this.eliminarButtonItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("eliminarButtonItem.HoverImage")));
            this.eliminarButtonItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarButtonItem.Image")));
            this.eliminarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.eliminarButtonItem.Name = "eliminarButtonItem";
            this.eliminarButtonItem.Tag = "6";
            this.eliminarButtonItem.Text = "Eliminar\r\n[F6]";
            this.eliminarButtonItem.Click += new System.EventHandler(this.eliminarButtonItem_Click);
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
            this.buscarTextBoxX.Location = new System.Drawing.Point(51, 3);
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
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ARTICULO_ID,
            this.NOMBRE,
            this.EQUIVALENCIA_ID,
            this.NOMBRE_E,
            this.UNIDAD,
            this.ACTIVO});
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
            this.dataGridViewX1.Size = new System.Drawing.Size(915, 532);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            this.dataGridViewX1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewX1_CellValidating);
            this.dataGridViewX1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_ColumnHeaderMouseClick);
            this.dataGridViewX1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_RowEnter);
            this.dataGridViewX1.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_RowValidated);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            this.dataGridViewX1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyUp);
            this.dataGridViewX1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewX1_MouseDoubleClick);
            // 
            // ID
            // 
            // 
            // 
            // 
            this.ID.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.ID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ID.DataPropertyName = "EQUIVALENCIA_ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // ARTICULO_ID
            // 
            this.ARTICULO_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ARTICULO_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.ARTICULO_ID.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.ARTICULO_ID.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.ARTICULO_ID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ARTICULO_ID.ButtonCustom.Visible = true;
            this.ARTICULO_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ARTICULO_ID.DataPropertyName = "ARTICULO_ID";
            this.ARTICULO_ID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ARTICULO_ID.HeaderText = "CLAVE";
            this.ARTICULO_ID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ARTICULO_ID.Name = "ARTICULO_ID";
            this.ARTICULO_ID.PasswordChar = '\0';
            this.ARTICULO_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ARTICULO_ID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ARTICULO_ID.Text = "";
            this.ARTICULO_ID.WatermarkText = "Clave Articulo";
            // 
            // NOMBRE
            // 
            this.NOMBRE.DataPropertyName = "NOMBRE1";
            this.NOMBRE.HeaderText = "NOMBRE";
            this.NOMBRE.Name = "NOMBRE";
            // 
            // EQUIVALENCIA_ID
            // 
            this.EQUIVALENCIA_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.EQUIVALENCIA_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.EQUIVALENCIA_ID.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.EQUIVALENCIA_ID.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.EQUIVALENCIA_ID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.EQUIVALENCIA_ID.ButtonCustom.Visible = true;
            this.EQUIVALENCIA_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.EQUIVALENCIA_ID.DataPropertyName = "ARTICULO_IDE";
            this.EQUIVALENCIA_ID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EQUIVALENCIA_ID.HeaderText = "EQUIVALENCIA";
            this.EQUIVALENCIA_ID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EQUIVALENCIA_ID.Name = "EQUIVALENCIA_ID";
            this.EQUIVALENCIA_ID.PasswordChar = '\0';
            this.EQUIVALENCIA_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EQUIVALENCIA_ID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EQUIVALENCIA_ID.Text = "";
            this.EQUIVALENCIA_ID.WatermarkText = "Equivalencia Articulo";
            // 
            // NOMBRE_E
            // 
            this.NOMBRE_E.DataPropertyName = "NOMBREE1";
            this.NOMBRE_E.HeaderText = "NOMBRE EQUIVALENCIA";
            this.NOMBRE_E.Name = "NOMBRE_E";
            // 
            // UNIDAD
            // 
            // 
            // 
            // 
            this.UNIDAD.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.UNIDAD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UNIDAD.DataPropertyName = "EQUIVALENCIA";
            this.UNIDAD.HeaderText = "UNIDADES";
            this.UNIDAD.Name = "UNIDAD";
            this.UNIDAD.ShowUpDown = true;
            // 
            // ACTIVO
            // 
            this.ACTIVO.DataPropertyName = "ACTIVO";
            this.ACTIVO.DropDownHeight = 106;
            this.ACTIVO.DropDownWidth = 121;
            this.ACTIVO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ACTIVO.HeaderText = "ACTIVO";
            this.ACTIVO.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ACTIVO.IntegralHeight = false;
            this.ACTIVO.ItemHeight = 15;
            this.ACTIVO.Name = "ACTIVO";
            this.ACTIVO.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // buscarBackgroundWorker
            // 
            this.buscarBackgroundWorker.WorkerReportsProgress = true;
            this.buscarBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.buscarBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 32);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // buscarButtonX
            // 
            this.buscarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buscarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buscarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buscarButtonX.Location = new System.Drawing.Point(837, 4);
            this.buscarButtonX.Name = "buscarButtonX";
            this.buscarButtonX.Size = new System.Drawing.Size(75, 23);
            this.buscarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buscarButtonX.TabIndex = 0;
            this.buscarButtonX.Text = "Buscar";
            this.buscarButtonX.Click += new System.EventHandler(this.buscarButtonX_Click);
            // 
            // CatEquivalenciasUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CatEquivalenciasUserControl";
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
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
        private System.ComponentModel.BackgroundWorker buscarBackgroundWorker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn ID;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn ARTICULO_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn EQUIVALENCIA_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE_E;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn UNIDAD;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn ACTIVO;
    }
}
