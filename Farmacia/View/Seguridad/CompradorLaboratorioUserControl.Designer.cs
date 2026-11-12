namespace SIF.View.Seguridad
{
    partial class CompradorLaboratorioUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompradorLaboratorioUserControl));
            DevComponents.DotNetBar.LabelX labelX1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buscarTextBoxX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buscarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NuevoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.eliminarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.USUARIO_IDColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.NOMBREColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.APELLIDOSColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.LISTA_PROVEEDOR_IDColumn = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.LISTA_SUCURSAL_IDColumn = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.FECHA_ALTAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
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
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(346, 32);
            this.titleLabel.Text = "CONFIGURACION\\COMPRADOR";
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
            this.splitContainer1.SplitterDistance = 33;
            // 
            // statusLabel
            // 
            // 
            // 
            // 
            this.statusLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 33);
            this.tableLayoutPanel1.TabIndex = 2;
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
            this.buscarTextBoxX.Location = new System.Drawing.Point(51, 4);
            this.buscarTextBoxX.Name = "buscarTextBoxX";
            this.buscarTextBoxX.Size = new System.Drawing.Size(779, 25);
            this.buscarTextBoxX.TabIndex = 2;
            this.buscarTextBoxX.WatermarkText = "Buscar";
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
            // NuevoButtonItem
            // 
            this.NuevoButtonItem.HoverImage = global::SIF.Properties.Resources.NewDocument1;
            this.NuevoButtonItem.Image = global::SIF.Properties.Resources.NewDocument;
            this.NuevoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.NuevoButtonItem.Name = "NuevoButtonItem";
            this.NuevoButtonItem.Text = "Nuevo\r\n[F2]";
            this.NuevoButtonItem.Click += new System.EventHandler(this.NuevoButtonItem_Click);
            // 
            // eliminarButtonItem
            // 
            this.eliminarButtonItem.HoverImage = global::SIF.Properties.Resources.DeleteDocument1;
            this.eliminarButtonItem.Image = global::SIF.Properties.Resources.DeleteDocument;
            this.eliminarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.eliminarButtonItem.Name = "eliminarButtonItem";
            this.eliminarButtonItem.Text = "Eliminar\r\n[F6]";
            this.eliminarButtonItem.Click += new System.EventHandler(this.eliminarButtonItem_Click);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AutoGenerateColumns = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.USUARIO_IDColumn,
            this.NOMBREColumn,
            this.APELLIDOSColumn,
            this.LISTA_PROVEEDOR_IDColumn,
            this.LISTA_SUCURSAL_IDColumn,
            this.FECHA_ALTAColumn});
            this.dataGridViewX1.DataSource = this.bindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.EnableHeadersVisualStyles = false;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewX1.Size = new System.Drawing.Size(915, 531);
            this.dataGridViewX1.TabIndex = 0;
            // 
            // USUARIO_IDColumn
            // 
            this.USUARIO_IDColumn.DataPropertyName = "ACCESO_ID";
            this.USUARIO_IDColumn.HeaderText = "USUARIO";
            this.USUARIO_IDColumn.Name = "USUARIO_IDColumn";
            this.USUARIO_IDColumn.ReadOnly = true;
            // 
            // NOMBREColumn
            // 
            this.NOMBREColumn.DataPropertyName = "NOMBRE";
            this.NOMBREColumn.FillWeight = 120F;
            this.NOMBREColumn.HeaderText = "NOMBRE";
            this.NOMBREColumn.Name = "NOMBREColumn";
            this.NOMBREColumn.ReadOnly = true;
            this.NOMBREColumn.Width = 140;
            // 
            // APELLIDOSColumn
            // 
            this.APELLIDOSColumn.DataPropertyName = "APELLIDOS";
            this.APELLIDOSColumn.HeaderText = "APELLIDOS";
            this.APELLIDOSColumn.Name = "APELLIDOSColumn";
            this.APELLIDOSColumn.ReadOnly = true;
            this.APELLIDOSColumn.Width = 160;
            // 
            // LISTA_PROVEEDOR_IDColumn
            // 
            this.LISTA_PROVEEDOR_IDColumn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.LISTA_PROVEEDOR_IDColumn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.LISTA_PROVEEDOR_IDColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LISTA_PROVEEDOR_IDColumn.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.LISTA_PROVEEDOR_IDColumn.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.LISTA_PROVEEDOR_IDColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LISTA_PROVEEDOR_IDColumn.ButtonCustom.Visible = true;
            this.LISTA_PROVEEDOR_IDColumn.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.LISTA_PROVEEDOR_IDColumn.DataPropertyName = "LISTA_PROVEEDOR_ID";
            this.LISTA_PROVEEDOR_IDColumn.ForeColor = System.Drawing.Color.Black;
            this.LISTA_PROVEEDOR_IDColumn.HeaderText = "LISTA PROVEEDOR";
            this.LISTA_PROVEEDOR_IDColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LISTA_PROVEEDOR_IDColumn.Name = "LISTA_PROVEEDOR_IDColumn";
            this.LISTA_PROVEEDOR_IDColumn.PasswordChar = '\0';
            this.LISTA_PROVEEDOR_IDColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LISTA_PROVEEDOR_IDColumn.Text = "";
            // 
            // LISTA_SUCURSAL_IDColumn
            // 
            this.LISTA_SUCURSAL_IDColumn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.LISTA_SUCURSAL_IDColumn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.LISTA_SUCURSAL_IDColumn.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.LISTA_SUCURSAL_IDColumn.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.LISTA_SUCURSAL_IDColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LISTA_SUCURSAL_IDColumn.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.LISTA_SUCURSAL_IDColumn.DataPropertyName = "LISTA_SUCURSAL_ID";
            this.LISTA_SUCURSAL_IDColumn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LISTA_SUCURSAL_IDColumn.HeaderText = "LISTA_SUCURSAL";
            this.LISTA_SUCURSAL_IDColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LISTA_SUCURSAL_IDColumn.Name = "LISTA_SUCURSAL_IDColumn";
            this.LISTA_SUCURSAL_IDColumn.PasswordChar = '\0';
            this.LISTA_SUCURSAL_IDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LISTA_SUCURSAL_IDColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LISTA_SUCURSAL_IDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LISTA_SUCURSAL_IDColumn.Text = "";
            // 
            // FECHA_ALTAColumn
            // 
            this.FECHA_ALTAColumn.DataPropertyName = "FECHA_ALTA";
            this.FECHA_ALTAColumn.HeaderText = "FECHA ALTA";
            this.FECHA_ALTAColumn.Name = "FECHA_ALTAColumn";
            this.FECHA_ALTAColumn.ReadOnly = true;
            // 
            // CompradorLaboratorioUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CompradorLaboratorioUserControl";
            this.Load += new System.EventHandler(this.CompradorLaboratorioUserControl_Load);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX buscarTextBoxX;
        private DevComponents.DotNetBar.ButtonX buscarButtonX;
        private DevComponents.DotNetBar.ButtonItem NuevoButtonItem;
        private DevComponents.DotNetBar.ButtonItem eliminarButtonItem;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn USUARIO_IDColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn NOMBREColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn APELLIDOSColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn LISTA_PROVEEDOR_IDColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn LISTA_SUCURSAL_IDColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn FECHA_ALTAColumn;
    }
}
