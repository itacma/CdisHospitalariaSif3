
using System;

namespace SIF.View.Comercializacion
{
    partial class AdminSaldos
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminSaldos));
            this.AgregarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.CerrarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.CancelarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.ConsultarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.GuardarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.FacturasButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SiNoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buscarBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.TipoDescSource = new System.Windows.Forms.BindingSource(this.components);
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxBuscar = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnBuscar = new System.Windows.Forms.Button();
            this.radioBtnActivo = new System.Windows.Forms.RadioButton();
            this.radioBtnCancelado = new System.Windows.Forms.RadioButton();
            this.radioBtnCerrado = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiNoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoDescSource)).BeginInit();
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
            this.backButton.Location = new System.Drawing.Point(10, 60);
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
            this.backButton.Size = new System.Drawing.Size(48, 64);
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
            this.AgregarButtonItem,
            this.CerrarButtonItem,
            this.ConsultarButtonItem,
            this.GuardarButtonItem,
            this.CancelarButtonItem,
            this.FacturasButtonItem});
            this.bar1.ItemSpacing = 10;
            this.bar1.Location = new System.Drawing.Point(64, 64);
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(793, 75);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 15;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(316, 32);
            this.titleLabel.Text = "COMERCIALIZACION\\SALDOS";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(64, 170);
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.radioBtnCerrado);
            this.splitContainer1.Panel1.Controls.Add(this.radioBtnCancelado);
            this.splitContainer1.Panel1.Controls.Add(this.radioBtnActivo);
            this.splitContainer1.Panel1.Controls.Add(this.btnBuscar);
            this.splitContainer1.Panel1.Controls.Add(this.txtBoxBuscar);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.superGridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(915, 551);
            this.splitContainer1.SplitterDistance = 81;
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
            // AgregarButtonItem
            // 
            this.AgregarButtonItem.HoverImage = global::SIF.Properties.Resources.facturar1;
            this.AgregarButtonItem.Image = global::SIF.Properties.Resources.Facturar;
            this.AgregarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.AgregarButtonItem.Name = "AgregarButtonItem";
            this.AgregarButtonItem.Tag = "1";
            this.AgregarButtonItem.Text = "Agregar";
            this.AgregarButtonItem.Click += new System.EventHandler(this.AgregarButtonItem_Click);
            // 
            // CerrarButtonItem
            // 
            this.CerrarButtonItem.HoverImage = global::SIF.Properties.Resources.DeleteDocument1;
            this.CerrarButtonItem.Image = global::SIF.Properties.Resources.DeleteDocument;
            this.CerrarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.CerrarButtonItem.Name = "CerrarButtonItem";
            this.CerrarButtonItem.Tag = "6";
            this.CerrarButtonItem.Text = "Cerrar";
            this.CerrarButtonItem.Click += new System.EventHandler(this.CerrarButtonItem_Click);
            // 
            // CancelarButtonItem
            // 
            this.CancelarButtonItem.HoverImage = global::SIF.Properties.Resources.Cancel3;
            this.CancelarButtonItem.Image = global::SIF.Properties.Resources.Cancel2;
            this.CancelarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.CancelarButtonItem.Name = "CancelarButtonItem";
            this.CancelarButtonItem.Tag = "2";
            this.CancelarButtonItem.Text = "Cancelar";
            this.CancelarButtonItem.Click += new System.EventHandler(this.CancelarButtonItem_Click);
            // 
            // ConsultarButtonItem
            // 
            this.ConsultarButtonItem.HoverImage = global::SIF.Properties.Resources.Payments;
            this.ConsultarButtonItem.Image = global::SIF.Properties.Resources.Payments1;
            this.ConsultarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.ConsultarButtonItem.Name = "ConsultarButtonItem";
            this.ConsultarButtonItem.Tag = "3";
            this.ConsultarButtonItem.Text = "Consultar";
            this.ConsultarButtonItem.Click += new System.EventHandler(this.ConsultarButtonItem_Click);
            // 
            // GuardarButtonItem
            // 
            this.GuardarButtonItem.HoverImage = global::SIF.Properties.Resources.SaveTool1;
            this.GuardarButtonItem.Image = global::SIF.Properties.Resources.SaveTool;
            this.GuardarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.GuardarButtonItem.Name = "GuardarButtonItem";
            this.GuardarButtonItem.Tag = "4";
            this.GuardarButtonItem.Text = "Guardar";
            this.GuardarButtonItem.Click += new System.EventHandler(this.GuardarButtonItem_Click);
            // 
            // FacturasButtonItem
            // 
            this.FacturasButtonItem.HoverImage = global::SIF.Properties.Resources.CertificateAdd1;
            this.FacturasButtonItem.Image = global::SIF.Properties.Resources.CertificateAdd;
            this.FacturasButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.FacturasButtonItem.Name = "FacturasButtonItem";
            this.FacturasButtonItem.Tag = "5";
            this.FacturasButtonItem.Text = "Factura";
            this.FacturasButtonItem.Click += new System.EventHandler(this.FacturasButtonItem_Click);
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // buscarBackgroundWorker
            // 
            this.buscarBackgroundWorker.WorkerReportsProgress = true;
            // 
            // superGridControl1
            // 
            this.superGridControl1.BackColor = System.Drawing.Color.White;
            this.superGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControl1.ForeColor = System.Drawing.Color.Black;
            this.superGridControl1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.superGridControl1.Location = new System.Drawing.Point(0, 0);
            this.superGridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.superGridControl1.Name = "superGridControl1";
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.superGridControl1.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.superGridControl1.Size = new System.Drawing.Size(915, 450);
            this.superGridControl1.TabIndex = 0;
            this.superGridControl1.Text = "Artículos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar:";
            // 
            // txtBoxBuscar
            // 
            this.txtBoxBuscar.Location = new System.Drawing.Point(72, 12);
            this.txtBoxBuscar.Name = "txtBoxBuscar";
            this.txtBoxBuscar.Size = new System.Drawing.Size(527, 25);
            this.txtBoxBuscar.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(668, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // radioBtnActivo
            // 
            this.radioBtnActivo.AutoSize = true;
            this.radioBtnActivo.Checked = true;
            this.radioBtnActivo.Location = new System.Drawing.Point(1, 57);
            this.radioBtnActivo.Name = "radioBtnActivo";
            this.radioBtnActivo.Size = new System.Drawing.Size(67, 21);
            this.radioBtnActivo.TabIndex = 3;
            this.radioBtnActivo.TabStop = true;
            this.radioBtnActivo.Text = "Activos";
            this.radioBtnActivo.UseVisualStyleBackColor = true;
            this.radioBtnActivo.CheckedChanged += new System.EventHandler(this.radioBtnActivo_CheckedChanged);
            // 
            // radioBtnCancelado
            // 
            this.radioBtnCancelado.AutoSize = true;
            this.radioBtnCancelado.Location = new System.Drawing.Point(405, 57);
            this.radioBtnCancelado.Name = "radioBtnCancelado";
            this.radioBtnCancelado.Size = new System.Drawing.Size(87, 21);
            this.radioBtnCancelado.TabIndex = 4;
            this.radioBtnCancelado.TabStop = true;
            this.radioBtnCancelado.Text = "Cancelados";
            this.radioBtnCancelado.UseVisualStyleBackColor = true;
            this.radioBtnCancelado.CheckedChanged += new System.EventHandler(this.radioBtnCancelado_CheckedChanged);
            // 
            // radioBtnCerrado
            // 
            this.radioBtnCerrado.AutoSize = true;
            this.radioBtnCerrado.Location = new System.Drawing.Point(831, 57);
            this.radioBtnCerrado.Name = "radioBtnCerrado";
            this.radioBtnCerrado.Size = new System.Drawing.Size(80, 21);
            this.radioBtnCerrado.TabIndex = 5;
            this.radioBtnCerrado.TabStop = true;
            this.radioBtnCerrado.Text = "Cerrados";
            this.radioBtnCerrado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioBtnCerrado.UseVisualStyleBackColor = true;
            this.radioBtnCerrado.CheckedChanged += new System.EventHandler(this.radioBtnCerrado_CheckedChanged);
            // 
            // AdminSaldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "AdminSaldos";
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
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SiNoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipoDescSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
                

        #endregion

        private DevComponents.DotNetBar.ButtonItem AgregarButtonItem;
        private DevComponents.DotNetBar.ButtonItem CancelarButtonItem;
        private DevComponents.DotNetBar.ButtonItem ConsultarButtonItem;
        private DevComponents.DotNetBar.ButtonItem GuardarButtonItem;
        private DevComponents.DotNetBar.ButtonItem FacturasButtonItem;
        private DevComponents.DotNetBar.ButtonItem CerrarButtonItem;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.ComponentModel.BackgroundWorker buscarBackgroundWorker;
        private System.Windows.Forms.BindingSource SiNoBindingSource;
        private System.Windows.Forms.BindingSource TipoDescSource;
        public DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private System.Windows.Forms.RadioButton radioBtnCerrado;
        private System.Windows.Forms.RadioButton radioBtnCancelado;
        private System.Windows.Forms.RadioButton radioBtnActivo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBoxBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

    }
}
