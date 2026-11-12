namespace SIF.View.Subrogacion
{
    partial class ActualizacionValesUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizacionValesUserControl));
            DevComponents.DotNetBar.LabelX labelX1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.actualizarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.NUM_VALEColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REMISIONColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_VALEColumn = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.FECHA_VALEColumn = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.FECHA_RECEPCIONColumn = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
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
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.actualizarButtonItem});
            this.bar1.ItemSpacing = 10;
            this.bar1.Size = new System.Drawing.Size(793, 75);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(235, 32);
            this.titleLabel.Text = "SIF\\Actualización Vale";
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
            this.splitContainer1.SplitterDistance = 31;
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
            labelX1.Location = new System.Drawing.Point(3, 5);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(43, 20);
            labelX1.TabIndex = 1;
            labelX1.Text = "Buscar:";
            // 
            // actualizarButtonItem
            // 
            this.actualizarButtonItem.HoverImage = global::SIF.Properties.Resources.EditDocument;
            this.actualizarButtonItem.Image = global::SIF.Properties.Resources.EditDocument1;
            this.actualizarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.actualizarButtonItem.Name = "actualizarButtonItem";
            this.actualizarButtonItem.Text = "Actualizar[F6]";
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
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NUM_VALEColumn,
            this.REMISIONColumn,
            this.TIPO_VALEColumn,
            this.FECHA_VALEColumn,
            this.FECHA_RECEPCIONColumn});
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
            this.dataGridViewX1.Size = new System.Drawing.Size(915, 533);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            this.dataGridViewX1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewX1_CellValidating);
            this.dataGridViewX1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_ColumnHeaderMouseClick);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            this.dataGridViewX1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyUp);
            // 
            // NUM_VALEColumn
            // 
            this.NUM_VALEColumn.DataPropertyName = "NoVale";
            this.NUM_VALEColumn.HeaderText = "No. VALE";
            this.NUM_VALEColumn.MaxInputLength = 25;
            this.NUM_VALEColumn.Name = "NUM_VALEColumn";
            // 
            // REMISIONColumn
            // 
            this.REMISIONColumn.DataPropertyName = "NoRemision";
            this.REMISIONColumn.FillWeight = 120F;
            this.REMISIONColumn.HeaderText = "REMISION";
            this.REMISIONColumn.MaxInputLength = 15;
            this.REMISIONColumn.Name = "REMISIONColumn";
            this.REMISIONColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.REMISIONColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.REMISIONColumn.Width = 120;
            // 
            // TIPO_VALEColumn
            // 
            this.TIPO_VALEColumn.DataPropertyName = "Tipo";
            this.TIPO_VALEColumn.DropDownHeight = 106;
            this.TIPO_VALEColumn.DropDownWidth = 121;
            this.TIPO_VALEColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TIPO_VALEColumn.HeaderText = "TIPO";
            this.TIPO_VALEColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TIPO_VALEColumn.IntegralHeight = false;
            this.TIPO_VALEColumn.ItemHeight = 15;
            this.TIPO_VALEColumn.Name = "TIPO_VALEColumn";
            this.TIPO_VALEColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TIPO_VALEColumn.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            // 
            // FECHA_VALEColumn
            // 
            // 
            // 
            // 
            this.FECHA_VALEColumn.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.FECHA_VALEColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA_VALEColumn.DataPropertyName = "FechaVale";
            this.FECHA_VALEColumn.HeaderText = "FECHA_VALE";
            this.FECHA_VALEColumn.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.FECHA_VALEColumn.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FECHA_VALEColumn.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA_VALEColumn.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.FECHA_VALEColumn.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA_VALEColumn.MonthCalendar.DisplayMonth = new System.DateTime(2013, 8, 1, 0, 0, 0, 0);
            this.FECHA_VALEColumn.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.FECHA_VALEColumn.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FECHA_VALEColumn.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA_VALEColumn.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.FECHA_VALEColumn.Name = "FECHA_VALEColumn";
            // 
            // FECHA_RECEPCIONColumn
            // 
            // 
            // 
            // 
            this.FECHA_RECEPCIONColumn.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.FECHA_RECEPCIONColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA_RECEPCIONColumn.DataPropertyName = "FechaRecepcion";
            this.FECHA_RECEPCIONColumn.HeaderText = "FECHA_RECEPCION";
            this.FECHA_RECEPCIONColumn.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.FECHA_RECEPCIONColumn.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FECHA_RECEPCIONColumn.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA_RECEPCIONColumn.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.FECHA_RECEPCIONColumn.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA_RECEPCIONColumn.MonthCalendar.DisplayMonth = new System.DateTime(2013, 8, 1, 0, 0, 0, 0);
            this.FECHA_RECEPCIONColumn.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.FECHA_RECEPCIONColumn.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FECHA_RECEPCIONColumn.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.FECHA_RECEPCIONColumn.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.FECHA_RECEPCIONColumn.Name = "FECHA_RECEPCIONColumn";
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 31);
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
            // ActualizacionValesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ActualizacionValesUserControl";
            this.Load += new System.EventHandler(this.CatBancosUserControl_Load);
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

        private DevComponents.DotNetBar.ButtonItem actualizarButtonItem;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.BindingSource SiNoBindingSource;
        private System.ComponentModel.BackgroundWorker buscarBackgroundWorker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUM_VALEColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn REMISIONColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn TIPO_VALEColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn FECHA_VALEColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn FECHA_RECEPCIONColumn;
    }
}
