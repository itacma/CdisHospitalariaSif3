namespace SIF.View.Catalogos
{
    partial class ValesDevolucionUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValesDevolucionUserControl));
            DevComponents.DotNetBar.LabelX labelX1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.eliminarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.SUCURSALColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.REMISIONColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.USUARIO_IDColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.USUARIO_AUTORIZAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.MOTIVOColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.FECHA_EMISIONColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.VIGENCIAColumn = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.OBSERVACIONESColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.STATUSColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
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
            this.backButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.backButton.FadeEffect = false;
            this.backButton.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.Location = new System.Drawing.Point(10, 47);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backButton.Name = "backButton";
            this.backButton.PressedImage = ((System.Drawing.Image)(resources.GetObject("backButton.PressedImage")));
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.backButton.Size = new System.Drawing.Size(48, 48);
            this.backButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.backButton.TabIndex = 14;
            this.backButton.Text = "\r\nRegresar";
            this.backButton.Tooltip = "Regresar [F12]";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "bar1 (bar1)";
            this.bar1.AccessibleName = "bar1";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar1.AntiAlias = true;
            this.bar1.BackColor = System.Drawing.Color.Transparent;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.eliminarButtonItem});
            this.bar1.ItemSpacing = 10;
            this.bar1.Location = new System.Drawing.Point(64, 44);
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(793, 92);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 15;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(223, 32);
            this.titleLabel.Text = "SIF\\Vales Devolución";
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
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.statusLabel.Location = new System.Drawing.Point(67, 718);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(912, 30);
            this.statusLabel.TabIndex = 16;
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
            // eliminarButtonItem
            // 
            this.eliminarButtonItem.HoverImage = global::SIF.Properties.Resources.DeleteDocument1;
            this.eliminarButtonItem.Image = global::SIF.Properties.Resources.DeleteDocument;
            this.eliminarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.eliminarButtonItem.Name = "eliminarButtonItem";
            this.eliminarButtonItem.Tag = "4";
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
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SUCURSALColumn,
            this.REMISIONColumn,
            this.USUARIO_IDColumn,
            this.USUARIO_AUTORIZAColumn,
            this.MOTIVOColumn,
            this.FECHA_EMISIONColumn,
            this.VIGENCIAColumn,
            this.OBSERVACIONESColumn,
            this.STATUSColumn});
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
            // SUCURSALColumn
            // 
            this.SUCURSALColumn.DataPropertyName = "SUCURSAL_NOMBRE";
            this.SUCURSALColumn.HeaderText = "SUCURSAL";
            this.SUCURSALColumn.Name = "SUCURSALColumn";
            this.SUCURSALColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // REMISIONColumn
            // 
            this.REMISIONColumn.DataPropertyName = "REMISION_ID";
            this.REMISIONColumn.FillWeight = 120F;
            this.REMISIONColumn.HeaderText = "REMISION";
            this.REMISIONColumn.Name = "REMISIONColumn";
            this.REMISIONColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.REMISIONColumn.Width = 120;
            // 
            // USUARIO_IDColumn
            // 
            this.USUARIO_IDColumn.DataPropertyName = "USUARIO_NOMBRE";
            this.USUARIO_IDColumn.FillWeight = 150F;
            this.USUARIO_IDColumn.HeaderText = "USUARIO";
            this.USUARIO_IDColumn.Name = "USUARIO_IDColumn";
            this.USUARIO_IDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.USUARIO_IDColumn.Width = 150;
            // 
            // USUARIO_AUTORIZAColumn
            // 
            this.USUARIO_AUTORIZAColumn.DataPropertyName = "USUARIO_AUTORIZA_NOMBRE";
            this.USUARIO_AUTORIZAColumn.FillWeight = 150F;
            this.USUARIO_AUTORIZAColumn.HeaderText = "AUTORIZADO POR";
            this.USUARIO_AUTORIZAColumn.Name = "USUARIO_AUTORIZAColumn";
            this.USUARIO_AUTORIZAColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.USUARIO_AUTORIZAColumn.Width = 150;
            // 
            // MOTIVOColumn
            // 
            this.MOTIVOColumn.DataPropertyName = "MOTIVO_NOMBRE";
            this.MOTIVOColumn.FillWeight = 160F;
            this.MOTIVOColumn.HeaderText = "MOTIVO";
            this.MOTIVOColumn.Name = "MOTIVOColumn";
            this.MOTIVOColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MOTIVOColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MOTIVOColumn.Width = 160;
            // 
            // FECHA_EMISIONColumn
            // 
            this.FECHA_EMISIONColumn.DataPropertyName = "FECHA_EMISION";
            this.FECHA_EMISIONColumn.HeaderText = "EMISION";
            this.FECHA_EMISIONColumn.Name = "FECHA_EMISIONColumn";
            this.FECHA_EMISIONColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FECHA_EMISIONColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // VIGENCIAColumn
            // 
            // 
            // 
            // 
            this.VIGENCIAColumn.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.VIGENCIAColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.VIGENCIAColumn.DataPropertyName = "FECHA_VIGENCIA";
            this.VIGENCIAColumn.HeaderText = "VIGENCIA";
            this.VIGENCIAColumn.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.VIGENCIAColumn.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.VIGENCIAColumn.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.VIGENCIAColumn.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.VIGENCIAColumn.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.VIGENCIAColumn.MonthCalendar.DisplayMonth = new System.DateTime(2012, 7, 1, 0, 0, 0, 0);
            this.VIGENCIAColumn.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.VIGENCIAColumn.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.VIGENCIAColumn.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.VIGENCIAColumn.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.VIGENCIAColumn.Name = "VIGENCIAColumn";
            // 
            // OBSERVACIONESColumn
            // 
            this.OBSERVACIONESColumn.DataPropertyName = "OBSERVACIONES";
            this.OBSERVACIONESColumn.FillWeight = 200F;
            this.OBSERVACIONESColumn.HeaderText = "OBSERVACIONES";
            this.OBSERVACIONESColumn.Name = "OBSERVACIONESColumn";
            this.OBSERVACIONESColumn.Width = 200;
            // 
            // STATUSColumn
            // 
            this.STATUSColumn.DataPropertyName = "STATUS";
            this.STATUSColumn.FillWeight = 80F;
            this.STATUSColumn.HeaderText = "STATUS";
            this.STATUSColumn.Name = "STATUSColumn";
            this.STATUSColumn.Width = 80;
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
            // ValesDevolucionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ValesDevolucionUserControl";
            this.Load += new System.EventHandler(this.CatBancosUserControl_Load);
            this.Controls.SetChildIndex(this.nombreLabel, 0);
            this.Controls.SetChildIndex(this.apellidosLabel, 0);
            this.Controls.SetChildIndex(this.fotoPictureBox, 0);
            this.Controls.SetChildIndex(this.sucursalLabel, 0);
            this.Controls.SetChildIndex(this.statusLabel, 0);
            this.Controls.SetChildIndex(this.titleLabel, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.Controls.SetChildIndex(this.bar1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
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

        private DevComponents.DotNetBar.ButtonItem eliminarButtonItem;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.BindingSource SiNoBindingSource;
        private System.ComponentModel.BackgroundWorker buscarBackgroundWorker;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn SUCURSALColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn REMISIONColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn USUARIO_IDColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn USUARIO_AUTORIZAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn MOTIVOColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn FECHA_EMISIONColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn VIGENCIAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn OBSERVACIONESColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn STATUSColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
    }
}
