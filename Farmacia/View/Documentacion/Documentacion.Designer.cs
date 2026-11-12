
namespace SIF.View.Documentacion
{
    partial class Documentacion
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
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.nuevaCarpetaButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.EliminarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.descargarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.cargarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.seleccionarArchivosButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.btnCargarArchivos = new System.Windows.Forms.Button();
            this.btnSubir = new System.Windows.Forms.Button();
            this.progressBarSubida = new System.Windows.Forms.ProgressBar();
            this.listBoxArchivosSeleccionados = new System.Windows.Forms.ListBox();
            this.lblEstadoSubida = new System.Windows.Forms.Label();
            this.tableLayoutPanelBack = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelA = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelB = new System.Windows.Forms.TableLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.tableLayoutPanelBack.SuspendLayout();
            this.tableLayoutPanelB.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "bar1 (bar1)";
            this.bar1.AccessibleName = "bar1";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar1.AntiAlias = true;
            this.bar1.BackColor = System.Drawing.Color.Transparent;
            this.bar1.ColorScheme.ExplorerBarBackground = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bar1.ColorScheme.ExplorerBarBackground2 = System.Drawing.Color.Green;
            this.bar1.ColorScheme.ItemHotBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bar1.ColorScheme.ItemHotBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.nuevaCarpetaButtonItem,
            this.EliminarButtonItem,
            this.descargarButtonItem});
            this.bar1.Location = new System.Drawing.Point(3, 32);
            this.bar1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(200, 57);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.bar1.TabIndex = 15;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // nuevaCarpetaButtonItem
            // 
            this.nuevaCarpetaButtonItem.HoverImage = global::SIF.Properties.Resources.BoxNewTool1;
            this.nuevaCarpetaButtonItem.Image = global::SIF.Properties.Resources.BoxNewTool;
            this.nuevaCarpetaButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.nuevaCarpetaButtonItem.Name = "nuevaCarpetaButtonItem";
            // 
            // EliminarButtonItem
            // 
            this.EliminarButtonItem.HoverImage = global::SIF.Properties.Resources.DeleteBinTool1;
            this.EliminarButtonItem.Image = global::SIF.Properties.Resources.DeleteBinTool;
            this.EliminarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.EliminarButtonItem.Name = "EliminarButtonItem";
            // 
            // descargarButtonItem
            // 
            this.descargarButtonItem.HoverImage = global::SIF.Properties.Resources.Download21;
            this.descargarButtonItem.Image = global::SIF.Properties.Resources.Download11;
            this.descargarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.descargarButtonItem.Name = "descargarButtonItem";
            // 
            // bar2
            // 
            this.bar2.AccessibleDescription = "bar2 (bar2)";
            this.bar2.AccessibleName = "bar2";
            this.bar2.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar2.AntiAlias = true;
            this.bar2.BackColor = System.Drawing.Color.Transparent;
            this.bar2.ColorScheme.ExplorerBarBackground = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bar2.ColorScheme.ExplorerBarBackground2 = System.Drawing.Color.Green;
            this.bar2.ColorScheme.ItemHotBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bar2.ColorScheme.ItemHotBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bar2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cargarButtonItem,
            this.seleccionarArchivosButtonItem});
            this.bar2.Location = new System.Drawing.Point(454, 32);
            this.bar2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(200, 57);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.bar2.TabIndex = 15;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // cargarButtonItem
            // 
            this.cargarButtonItem.Enabled = false;
            this.cargarButtonItem.HoverImage = global::SIF.Properties.Resources.Upload2;
            this.cargarButtonItem.Image = global::SIF.Properties.Resources.Upload1;
            this.cargarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.cargarButtonItem.Name = "cargarButtonItem";
            this.cargarButtonItem.Click += new System.EventHandler(this.cargarButtonItem_Click);
            // 
            // seleccionarArchivosButtonItem
            // 
            this.seleccionarArchivosButtonItem.HoverImage = global::SIF.Properties.Resources.AddTool1;
            this.seleccionarArchivosButtonItem.Image = global::SIF.Properties.Resources.AddTool;
            this.seleccionarArchivosButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.seleccionarArchivosButtonItem.Name = "seleccionarArchivosButtonItem";
            this.seleccionarArchivosButtonItem.Click += new System.EventHandler(this.seleccionarArchivosButtonItem1_Click);
            // 
            // btnCargarArchivos
            // 
            this.btnCargarArchivos.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnCargarArchivos.Location = new System.Drawing.Point(707, 476);
            this.btnCargarArchivos.Name = "btnCargarArchivos";
            this.btnCargarArchivos.Size = new System.Drawing.Size(80, 59);
            this.btnCargarArchivos.TabIndex = 0;
            this.btnCargarArchivos.Text = "Seleccionar Archivos";
            this.btnCargarArchivos.UseVisualStyleBackColor = true;
            this.btnCargarArchivos.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSubir
            // 
            this.btnSubir.Location = new System.Drawing.Point(601, 512);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(75, 23);
            this.btnSubir.TabIndex = 1;
            this.btnSubir.Text = "button2";
            this.btnSubir.UseVisualStyleBackColor = true;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // progressBarSubida
            // 
            this.progressBarSubida.Location = new System.Drawing.Point(1, 507);
            this.progressBarSubida.Name = "progressBarSubida";
            this.progressBarSubida.Size = new System.Drawing.Size(402, 28);
            this.progressBarSubida.TabIndex = 2;
            // 
            // listBoxArchivosSeleccionados
            // 
            this.listBoxArchivosSeleccionados.FormattingEnabled = true;
            this.listBoxArchivosSeleccionados.Location = new System.Drawing.Point(409, 488);
            this.listBoxArchivosSeleccionados.Name = "listBoxArchivosSeleccionados";
            this.listBoxArchivosSeleccionados.Size = new System.Drawing.Size(186, 56);
            this.listBoxArchivosSeleccionados.TabIndex = 3;
            // 
            // lblEstadoSubida
            // 
            this.lblEstadoSubida.AutoSize = true;
            this.lblEstadoSubida.Location = new System.Drawing.Point(641, 458);
            this.lblEstadoSubida.Name = "lblEstadoSubida";
            this.lblEstadoSubida.Size = new System.Drawing.Size(35, 13);
            this.lblEstadoSubida.TabIndex = 4;
            this.lblEstadoSubida.Text = "label1";
            // 
            // tableLayoutPanelBack
            // 
            this.tableLayoutPanelBack.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelBack.ColumnCount = 2;
            this.tableLayoutPanelBack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBack.Controls.Add(this.tableLayoutPanelA, 0, 0);
            this.tableLayoutPanelBack.Controls.Add(this.tableLayoutPanelB, 0, 1);
            this.tableLayoutPanelBack.Location = new System.Drawing.Point(4, 9);
            this.tableLayoutPanelBack.Name = "tableLayoutPanelBack";
            this.tableLayoutPanelBack.RowCount = 2;
            this.tableLayoutPanelBack.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.92683F));
            this.tableLayoutPanelBack.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.07317F));
            this.tableLayoutPanelBack.Size = new System.Drawing.Size(786, 410);
            this.tableLayoutPanelBack.TabIndex = 5;
            // 
            // tableLayoutPanelA
            // 
            this.tableLayoutPanelA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelA.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelA.ColumnCount = 2;
            this.tableLayoutPanelBack.SetColumnSpan(this.tableLayoutPanelA, 2);
            this.tableLayoutPanelA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelA.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelA.Name = "tableLayoutPanelA";
            this.tableLayoutPanelA.RowCount = 2;
            this.tableLayoutPanelA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelA.Size = new System.Drawing.Size(780, 129);
            this.tableLayoutPanelA.TabIndex = 0;
            // 
            // tableLayoutPanelB
            // 
            this.tableLayoutPanelB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelB.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelB.ColumnCount = 3;
            this.tableLayoutPanelBack.SetColumnSpan(this.tableLayoutPanelB, 2);
            this.tableLayoutPanelB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.36842F));
            this.tableLayoutPanelB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.tableLayoutPanelB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.10526F));
            this.tableLayoutPanelB.Controls.Add(this.bar1, 0, 1);
            this.tableLayoutPanelB.Controls.Add(this.bar2, 2, 1);
            this.tableLayoutPanelB.Controls.Add(this.listBox1, 0, 2);
            this.tableLayoutPanelB.Controls.Add(this.listBox2, 2, 2);
            this.tableLayoutPanelB.Location = new System.Drawing.Point(3, 138);
            this.tableLayoutPanelB.Name = "tableLayoutPanelB";
            this.tableLayoutPanelB.RowCount = 4;
            this.tableLayoutPanelB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.53532F));
            this.tableLayoutPanelB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.01859F));
            this.tableLayoutPanelB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelB.Size = new System.Drawing.Size(780, 269);
            this.tableLayoutPanelB.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 96);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(363, 134);
            this.listBox1.TabIndex = 16;
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(454, 96);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(323, 134);
            this.listBox2.TabIndex = 17;
            // 
            // Documentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 556);
            this.Controls.Add(this.tableLayoutPanelBack);
            this.Controls.Add(this.lblEstadoSubida);
            this.Controls.Add(this.listBoxArchivosSeleccionados);
            this.Controls.Add(this.progressBarSubida);
            this.Controls.Add(this.btnSubir);
            this.Controls.Add(this.btnCargarArchivos);
            this.DoubleBuffered = true;
            this.Name = "Documentacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Documentacion";
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.tableLayoutPanelBack.ResumeLayout(false);
            this.tableLayoutPanelB.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCargarArchivos;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.ProgressBar progressBarSubida;
        private System.Windows.Forms.ListBox listBoxArchivosSeleccionados;
        private System.Windows.Forms.Label lblEstadoSubida;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBack;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelA;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelB;
        

        public DevComponents.DotNetBar.Bar bar1;
        public DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem nuevaCarpetaButtonItem;
        private DevComponents.DotNetBar.ButtonItem cargarButtonItem;
        private DevComponents.DotNetBar.ButtonItem descargarButtonItem;
        private DevComponents.DotNetBar.ButtonItem EliminarButtonItem;
        private DevComponents.DotNetBar.ButtonItem seleccionarArchivosButtonItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
    }
}


