namespace SIF.View.Catalogos
{
    partial class UsuarioUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsuarioUserControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.NuevoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.eliminarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.GeneroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TipousuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SucursalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SiNoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buscarBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.ACCESOColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBREColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APELLIDOSColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCambiarContraseña = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CONTRASENAColumn = new DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn();
            this.GENEROColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TIPO_USUARIOColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SUCURSALColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ACTIVOColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_ALTAColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_BAJAColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USUARIOS_IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipousuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SucursalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiNoBindingSource)).BeginInit();
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
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
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
            this.NuevoButtonItem,
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
            this.titleLabel.Size = new System.Drawing.Size(137, 32);
            this.titleLabel.Text = "SIF\\Usuarios";
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
            this.statusLabel.Text = "Status...";
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
            this.labelX1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(43, 20);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Buscar:";
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarTextBoxX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buscarButtonX, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 31);
            this.tableLayoutPanel1.TabIndex = 1;
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
            // highlighter1
            // 
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToOrderColumns = true;
            this.dataGridViewX1.AutoGenerateColumns = false;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ACCESOColumn,
            this.NOMBREColumn,
            this.APELLIDOSColumn,
            this.btnCambiarContraseña,
            this.CONTRASENAColumn,
            this.GENEROColumn,
            this.TIPO_USUARIOColumn,
            this.SUCURSALColumn,
            this.ACTIVOColumn,
            this.FECHA_ALTAColumn,
            this.FECHA_BAJAColumn,
            this.USUARIOS_IDColumn});
            this.dataGridViewX1.DataSource = this.bindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(915, 533);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellContentClick);
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            this.dataGridViewX1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewX1_CellValidating);
            this.dataGridViewX1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_ColumnHeaderMouseClick);
            this.dataGridViewX1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewX1_DataError);
            this.dataGridViewX1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_RowEnter);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            this.dataGridViewX1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewX1_MouseDoubleClick);
            // 
            // buscarBackgroundWorker
            // 
            this.buscarBackgroundWorker.WorkerReportsProgress = true;
            this.buscarBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.buscarBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // ACCESOColumn
            // 
            this.ACCESOColumn.DataPropertyName = "AccesoID";
            this.ACCESOColumn.HeaderText = "ACCESO";
            this.ACCESOColumn.MaxInputLength = 10;
            this.ACCESOColumn.Name = "ACCESOColumn";
            // 
            // NOMBREColumn
            // 
            this.NOMBREColumn.DataPropertyName = "Nombre";
            this.NOMBREColumn.HeaderText = "NOMBRE";
            this.NOMBREColumn.MaxInputLength = 100;
            this.NOMBREColumn.Name = "NOMBREColumn";
            this.NOMBREColumn.Width = 250;
            // 
            // APELLIDOSColumn
            // 
            this.APELLIDOSColumn.DataPropertyName = "Apellidos";
            this.APELLIDOSColumn.HeaderText = "APELLIDOS";
            this.APELLIDOSColumn.MaxInputLength = 100;
            this.APELLIDOSColumn.Name = "APELLIDOSColumn";
            this.APELLIDOSColumn.Width = 300;
            // 
            // btnCambiarContraseña
            // 
            this.btnCambiarContraseña.HeaderText = "CAMBIAR CONTRASEÑA";
            this.btnCambiarContraseña.Name = "btnCambiarContraseña";
            // 
            // CONTRASENAColumn
            // 
            this.CONTRASENAColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CONTRASENAColumn.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.CONTRASENAColumn.BackgroundStyle.Class = "DataGridViewBorder";
            this.CONTRASENAColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CONTRASENAColumn.Culture = new System.Globalization.CultureInfo("es-MX");
            this.CONTRASENAColumn.DataPropertyName = "Contrasena";
            dataGridViewCellStyle1.Format = "••••";
            dataGridViewCellStyle1.NullValue = null;
            this.CONTRASENAColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.CONTRASENAColumn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CONTRASENAColumn.HeaderText = "CONTRASEÑA";
            this.CONTRASENAColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CONTRASENAColumn.Mask = "";
            this.CONTRASENAColumn.MaxInputLength = 10;
            this.CONTRASENAColumn.Name = "CONTRASENAColumn";
            this.CONTRASENAColumn.PasswordChar = '●';
            this.CONTRASENAColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CONTRASENAColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CONTRASENAColumn.Text = "";
            this.CONTRASENAColumn.UseSystemPasswordChar = true;
            this.CONTRASENAColumn.Visible = false;
            this.CONTRASENAColumn.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.CONTRASENAColumn.Width = 116;
            // 
            // GENEROColumn
            // 
            this.GENEROColumn.DataPropertyName = "Genero";
            this.GENEROColumn.DataSource = this.GeneroBindingSource;
            this.GENEROColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.GENEROColumn.HeaderText = "GENERO";
            this.GENEROColumn.Name = "GENEROColumn";
            this.GENEROColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GENEROColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.GENEROColumn.Width = 80;
            // 
            // TIPO_USUARIOColumn
            // 
            this.TIPO_USUARIOColumn.DataPropertyName = "TipoUsuario";
            this.TIPO_USUARIOColumn.DataSource = this.TipousuarioBindingSource;
            this.TIPO_USUARIOColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.TIPO_USUARIOColumn.HeaderText = "TIPO USUARIO";
            this.TIPO_USUARIOColumn.Name = "TIPO_USUARIOColumn";
            this.TIPO_USUARIOColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TIPO_USUARIOColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TIPO_USUARIOColumn.Width = 110;
            // 
            // SUCURSALColumn
            // 
            this.SUCURSALColumn.DataPropertyName = "SucursalID";
            this.SUCURSALColumn.DataSource = this.SucursalBindingSource;
            this.SUCURSALColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.SUCURSALColumn.HeaderText = "SUCURSAL";
            this.SUCURSALColumn.Name = "SUCURSALColumn";
            this.SUCURSALColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SUCURSALColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SUCURSALColumn.Width = 110;
            // 
            // ACTIVOColumn
            // 
            this.ACTIVOColumn.DataPropertyName = "Activo";
            this.ACTIVOColumn.HeaderText = "ACTIVO";
            this.ACTIVOColumn.Name = "ACTIVOColumn";
            this.ACTIVOColumn.ReadOnly = true;
            this.ACTIVOColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ACTIVOColumn.Width = 70;
            // 
            // FECHA_ALTAColumn
            // 
            this.FECHA_ALTAColumn.DataPropertyName = "FechaAlta";
            this.FECHA_ALTAColumn.HeaderText = "FECHA ALTA";
            this.FECHA_ALTAColumn.Name = "FECHA_ALTAColumn";
            this.FECHA_ALTAColumn.ReadOnly = true;
            // 
            // FECHA_BAJAColumn
            // 
            this.FECHA_BAJAColumn.DataPropertyName = "FechaBaja";
            this.FECHA_BAJAColumn.HeaderText = "FECHA BAJA";
            this.FECHA_BAJAColumn.Name = "FECHA_BAJAColumn";
            this.FECHA_BAJAColumn.ReadOnly = true;
            // 
            // USUARIOS_IDColumn
            // 
            this.USUARIOS_IDColumn.DataPropertyName = "UsuariosID";
            this.USUARIOS_IDColumn.HeaderText = "USUARIOS ID";
            this.USUARIOS_IDColumn.MaxInputLength = 10;
            this.USUARIOS_IDColumn.Name = "USUARIOS_IDColumn";
            this.USUARIOS_IDColumn.ReadOnly = true;
            this.USUARIOS_IDColumn.Width = 130;
            // 
            // UsuarioUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.Name = "UsuarioUserControl";
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipousuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SucursalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiNoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem NuevoButtonItem;
        private DevComponents.DotNetBar.ButtonItem eliminarButtonItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.BindingSource SiNoBindingSource;
        private System.ComponentModel.BackgroundWorker buscarBackgroundWorker;
        private System.Windows.Forms.BindingSource GeneroBindingSource;
        private System.Windows.Forms.BindingSource TipousuarioBindingSource;
        private System.Windows.Forms.BindingSource SucursalBindingSource;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACCESOColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBREColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn APELLIDOSColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnCambiarContraseña;
        private DevComponents.DotNetBar.Controls.DataGridViewMaskedTextBoxAdvColumn CONTRASENAColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn GENEROColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn TIPO_USUARIOColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn SUCURSALColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACTIVOColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_ALTAColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_BAJAColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn USUARIOS_IDColumn;
    }
}
