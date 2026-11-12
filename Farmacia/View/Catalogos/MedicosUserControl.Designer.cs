namespace SIF.View.Catalogos
{
    partial class MedicosUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedicosUserControl));
            DevComponents.DotNetBar.LabelX labelX1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NuevoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.eliminarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buscarBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.NOMBREColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CED_PROColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REG_SSAColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESPECIALIDADColumn = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.EMAILColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_DIRColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CONSULTA_FARMACIAColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FECHA_ALTAColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_BAJAColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACTIVOColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.titleLabel.Size = new System.Drawing.Size(135, 32);
            this.titleLabel.Text = "SIF\\Medicos";
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
            this.splitContainer1.SplitterDistance = 34;
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
            labelX1.Location = new System.Drawing.Point(3, 7);
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
            this.NuevoButtonItem.Tag = "1";
            this.NuevoButtonItem.Text = "Nuevo\r\n[F2]";
            this.NuevoButtonItem.Click += new System.EventHandler(this.NuevoButtonItem_Click);
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
            this.buscarTextBoxX.Location = new System.Drawing.Point(51, 4);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(779, 25);
            this.buscarTextBoxX.TabIndex = 2;
            this.buscarTextBoxX.WatermarkText = "Buscar";
            this.buscarTextBoxX.ButtonCustomClick += new System.EventHandler(this.buscarTextBoxX_ButtonCustomClick);
            this.buscarTextBoxX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buscarTextBoxX_KeyUp);
            // 
            // buscarBackgroundWorker
            // 
            this.buscarBackgroundWorker.WorkerReportsProgress = true;
            this.buscarBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.buscarBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToOrderColumns = true;
            this.dataGridViewX1.AutoGenerateColumns = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NOMBREColumn,
            this.CED_PROColumn,
            this.REG_SSAColumn,
            this.ESPECIALIDADColumn,
            this.EMAILColumn,
            this.TIPO_DIRColumn,
            this.CONSULTA_FARMACIAColumn,
            this.FECHA_ALTAColumn,
            this.FECHA_BAJAColumn,
            this.ACTIVOColumn});
            this.dataGridViewX1.DataSource = this.bindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.EnableHeadersVisualStyles = false;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(915, 530);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewX1_CellBeginEdit);
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            this.dataGridViewX1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_CellMouseDoubleClick);
            this.dataGridViewX1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewX1_CellValidating);
            this.dataGridViewX1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_ColumnHeaderMouseClick);
            this.dataGridViewX1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_RowEnter);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            this.dataGridViewX1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyUp);
            // 
            // NOMBREColumn
            // 
            this.NOMBREColumn.DataPropertyName = "Nombre";
            this.NOMBREColumn.HeaderText = "NOMBRE";
            this.NOMBREColumn.MaxInputLength = 100;
            this.NOMBREColumn.Name = "NOMBREColumn";
            this.NOMBREColumn.Width = 200;
            // 
            // CED_PROColumn
            // 
            this.CED_PROColumn.DataPropertyName = "CedulaProfesional";
            this.CED_PROColumn.HeaderText = "CEDULA";
            this.CED_PROColumn.MaxInputLength = 20;
            this.CED_PROColumn.Name = "CED_PROColumn";
            // 
            // REG_SSAColumn
            // 
            this.REG_SSAColumn.DataPropertyName = "RegistroSSA";
            this.REG_SSAColumn.HeaderText = "SSA";
            this.REG_SSAColumn.MaxInputLength = 20;
            this.REG_SSAColumn.Name = "REG_SSAColumn";
            this.REG_SSAColumn.Visible = false;
            // 
            // ESPECIALIDADColumn
            // 
            this.ESPECIALIDADColumn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ESPECIALIDADColumn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.ESPECIALIDADColumn.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.ESPECIALIDADColumn.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.ESPECIALIDADColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ESPECIALIDADColumn.ButtonCustom.Image = global::SIF.Properties.Resources.TableofContents16;
            this.ESPECIALIDADColumn.ButtonCustom.Visible = true;
            this.ESPECIALIDADColumn.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ESPECIALIDADColumn.DataPropertyName = "EspecialidadNombre";
            this.ESPECIALIDADColumn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ESPECIALIDADColumn.HeaderText = "ESPECIALIDAD";
            this.ESPECIALIDADColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ESPECIALIDADColumn.Name = "ESPECIALIDADColumn";
            this.ESPECIALIDADColumn.PasswordChar = '\0';
            this.ESPECIALIDADColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ESPECIALIDADColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ESPECIALIDADColumn.Text = "";
            this.ESPECIALIDADColumn.Width = 150;
            // 
            // EMAILColumn
            // 
            this.EMAILColumn.DataPropertyName = "Email";
            this.EMAILColumn.HeaderText = "EMAIL";
            this.EMAILColumn.MaxInputLength = 100;
            this.EMAILColumn.Name = "EMAILColumn";
            this.EMAILColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EMAILColumn.Visible = false;
            // 
            // TIPO_DIRColumn
            // 
            this.TIPO_DIRColumn.DataPropertyName = "TipoConsulta";
            this.TIPO_DIRColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.TIPO_DIRColumn.HeaderText = "DIRECCION";
            this.TIPO_DIRColumn.Name = "TIPO_DIRColumn";
            this.TIPO_DIRColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TIPO_DIRColumn.Width = 130;
            // 
            // CONSULTA_FARMACIAColumn
            // 
            this.CONSULTA_FARMACIAColumn.DataPropertyName = "ConsultaFarmacia";
            this.CONSULTA_FARMACIAColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.CONSULTA_FARMACIAColumn.HeaderText = "CONSULTA";
            this.CONSULTA_FARMACIAColumn.Name = "CONSULTA_FARMACIAColumn";
            this.CONSULTA_FARMACIAColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FECHA_ALTAColumn
            // 
            this.FECHA_ALTAColumn.DataPropertyName = "FechaAlta";
            this.FECHA_ALTAColumn.HeaderText = "ALTA";
            this.FECHA_ALTAColumn.Name = "FECHA_ALTAColumn";
            this.FECHA_ALTAColumn.ReadOnly = true;
            this.FECHA_ALTAColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FECHA_BAJAColumn
            // 
            this.FECHA_BAJAColumn.DataPropertyName = "FechaBaja";
            this.FECHA_BAJAColumn.HeaderText = "BAJA";
            this.FECHA_BAJAColumn.Name = "FECHA_BAJAColumn";
            this.FECHA_BAJAColumn.ReadOnly = true;
            this.FECHA_BAJAColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ACTIVOColumn
            // 
            this.ACTIVOColumn.DataPropertyName = "Activo";
            this.ACTIVOColumn.HeaderText = "ACTIVO";
            this.ACTIVOColumn.Name = "ACTIVOColumn";
            this.ACTIVOColumn.ReadOnly = true;
            this.ACTIVOColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 34);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // buscarButtonX
            // 
            this.buscarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buscarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buscarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buscarButtonX.Location = new System.Drawing.Point(837, 5);
            this.buscarButtonX.Name = "buscarButtonX";
            this.buscarButtonX.Size = new System.Drawing.Size(75, 23);
            this.buscarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buscarButtonX.TabIndex = 0;
            this.buscarButtonX.Text = "Buscar";
            this.buscarButtonX.Click += new System.EventHandler(this.buscarButtonX_Click);
            // 
            // MedicosUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MedicosUserControl";
            this.Load += new System.EventHandler(this.CatMedicoUserControl_Load);
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
        private System.ComponentModel.BackgroundWorker buscarBackgroundWorker;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBREColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CED_PROColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn REG_SSAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn ESPECIALIDADColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAILColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn TIPO_DIRColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn CONSULTA_FARMACIAColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_ALTAColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_BAJAColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACTIVOColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
    }
}
