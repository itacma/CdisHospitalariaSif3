namespace SIF.View.OrdenCompra
{
    partial class AplicarOfertaUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AplicarOfertaUserControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cargaArchivoOfertasButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.aplicarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.facturasButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.PROVEEDOR_IDColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.PROVEEDORColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ARCHIVOColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.USUARIOColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.DESCARGAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.CARGAColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.ACTIVOColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.MENSAJEColumn = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
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
            this.facturasButtonItem,
            this.cargaArchivoOfertasButtonItem,
            this.aplicarButtonItem});
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(312, 32);
            this.titleLabel.Text = "COMPRAS\\APLICAR OFERTAS";
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewX1);
            this.splitContainer1.SplitterDistance = 0;
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
            // cargaArchivoOfertasButtonItem
            // 
            this.cargaArchivoOfertasButtonItem.HoverImage = global::SIF.Properties.Resources.TableContentsTool1;
            this.cargaArchivoOfertasButtonItem.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.cargaArchivoOfertasButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.cargaArchivoOfertasButtonItem.Name = "cargaArchivoOfertasButtonItem";
            this.cargaArchivoOfertasButtonItem.Tag = "29";
            this.cargaArchivoOfertasButtonItem.Text = "OFERTAS\r\n ";
            this.cargaArchivoOfertasButtonItem.Click += new System.EventHandler(this.cargaArchivoOfertasButtonItem_Click);
            // 
            // aplicarButtonItem
            // 
            this.aplicarButtonItem.HoverImage = global::SIF.Properties.Resources.TableContentsTool1;
            this.aplicarButtonItem.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.aplicarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.aplicarButtonItem.Name = "aplicarButtonItem";
            this.aplicarButtonItem.Tag = "28";
            this.aplicarButtonItem.Text = "APLICAR\r\n ";
            this.aplicarButtonItem.Click += new System.EventHandler(this.aplicarButtonItem_Click);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PROVEEDOR_IDColumn,
            this.PROVEEDORColumn,
            this.ARCHIVOColumn,
            this.USUARIOColumn,
            this.DESCARGAColumn,
            this.CARGAColumn,
            this.ACTIVOColumn,
            this.MENSAJEColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.MultiSelect = false;
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(915, 564);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            // 
            // facturasButtonItem
            // 
            this.facturasButtonItem.AutoExpandOnClick = true;
            this.facturasButtonItem.HoverImage = global::SIF.Properties.Resources.TableContentsTool1;
            this.facturasButtonItem.Image = global::SIF.Properties.Resources.TableContentsTool;
            this.facturasButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.facturasButtonItem.Name = "facturasButtonItem";
            this.facturasButtonItem.Tag = "29";
            this.facturasButtonItem.Text = "FACTURAS\r\n ";
            this.facturasButtonItem.Click += new System.EventHandler(this.facturasButtonItem_Click);
            // 
            // PROVEEDOR_IDColumn
            // 
            this.PROVEEDOR_IDColumn.DataPropertyName = "PROVEEDOR_ID";
            this.PROVEEDOR_IDColumn.HeaderText = "PROVEEDOR ID";
            this.PROVEEDOR_IDColumn.Name = "PROVEEDOR_IDColumn";
            this.PROVEEDOR_IDColumn.ReadOnly = true;
            this.PROVEEDOR_IDColumn.Width = 110;
            // 
            // PROVEEDORColumn
            // 
            this.PROVEEDORColumn.DataPropertyName = "NOMBRE";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.PROVEEDORColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.PROVEEDORColumn.HeaderText = "PROVEEDOR";
            this.PROVEEDORColumn.Name = "PROVEEDORColumn";
            this.PROVEEDORColumn.ReadOnly = true;
            this.PROVEEDORColumn.Width = 160;
            // 
            // ARCHIVOColumn
            // 
            this.ARCHIVOColumn.DataPropertyName = "NOM_ARCHIVO";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ARCHIVOColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.ARCHIVOColumn.HeaderText = "ARCHIVO";
            this.ARCHIVOColumn.Name = "ARCHIVOColumn";
            this.ARCHIVOColumn.ReadOnly = true;
            this.ARCHIVOColumn.Width = 150;
            // 
            // USUARIOColumn
            // 
            this.USUARIOColumn.DataPropertyName = "USUARIO_ID";
            this.USUARIOColumn.HeaderText = "USUARIO";
            this.USUARIOColumn.Name = "USUARIOColumn";
            this.USUARIOColumn.ReadOnly = true;
            // 
            // DESCARGAColumn
            // 
            this.DESCARGAColumn.DataPropertyName = "FECHA_DESCARGA";
            this.DESCARGAColumn.HeaderText = "DESCARGA";
            this.DESCARGAColumn.Name = "DESCARGAColumn";
            this.DESCARGAColumn.ReadOnly = true;
            this.DESCARGAColumn.Width = 130;
            // 
            // CARGAColumn
            // 
            this.CARGAColumn.DataPropertyName = "FECHA_CARGA";
            this.CARGAColumn.HeaderText = "CARGA";
            this.CARGAColumn.Name = "CARGAColumn";
            this.CARGAColumn.ReadOnly = true;
            this.CARGAColumn.Width = 130;
            // 
            // ACTIVOColumn
            // 
            this.ACTIVOColumn.DataPropertyName = "ACTIVO";
            this.ACTIVOColumn.HeaderText = "ACTIVO";
            this.ACTIVOColumn.Name = "ACTIVOColumn";
            this.ACTIVOColumn.ReadOnly = true;
            this.ACTIVOColumn.Width = 80;
            // 
            // MENSAJEColumn
            // 
            this.MENSAJEColumn.DataPropertyName = "MENSAJE";
            this.MENSAJEColumn.HeaderText = "MENSAJE";
            this.MENSAJEColumn.Name = "MENSAJEColumn";
            this.MENSAJEColumn.ReadOnly = true;
            // 
            // AplicarOfertaUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "AplicarOfertaUserControl";
            this.Load += new System.EventHandler(this.AplicarOfertaUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem cargaArchivoOfertasButtonItem;
        private DevComponents.DotNetBar.ButtonItem aplicarButtonItem;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonItem facturasButtonItem;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn PROVEEDOR_IDColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn PROVEEDORColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ARCHIVOColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn USUARIOColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn DESCARGAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn CARGAColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn ACTIVOColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn MENSAJEColumn;
    }
}
