namespace SIF.View.Ventas
{
    partial class TiempoAireTelcelForm
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
            this.components = new System.ComponentModel.Container();
            DevComponents.DotNetBar.LabelX labelX4;
            DevComponents.DotNetBar.LabelX labelX2;
            DevComponents.DotNetBar.LabelX labelX3;
            this.titleLabel = new System.Windows.Forms.Label();
            this.aceptarButtonX = new DevComponents.DotNetBar.ButtonX();
            this.cancelarButton = new DevComponents.DotNetBar.ButtonX();
            this.carriersTabControl = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.telcelTabItem = new DevComponents.DotNetBar.TabItem(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.recargaComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.maskedTextBoxAdv1 = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.maskedTextBoxAdv2 = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            labelX4 = new DevComponents.DotNetBar.LabelX();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            labelX3 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.carriersTabControl)).BeginInit();
            this.carriersTabControl.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX4
            // 
            // 
            // 
            // 
            labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX4.Location = new System.Drawing.Point(4, 104);
            labelX4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            labelX4.Name = "labelX4";
            labelX4.Size = new System.Drawing.Size(134, 28);
            labelX4.TabIndex = 7;
            labelX4.Text = "Confirmar:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.Location = new System.Drawing.Point(4, 20);
            labelX2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            labelX2.Name = "labelX2";
            labelX2.Size = new System.Drawing.Size(134, 28);
            labelX2.TabIndex = 1;
            labelX2.Text = "Monto:";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX3.Location = new System.Drawing.Point(4, 62);
            labelX3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            labelX3.Name = "labelX3";
            labelX3.Size = new System.Drawing.Size(134, 28);
            labelX3.TabIndex = 2;
            labelX3.Text = "Número Celular:";
            // 
            // titleLabel
            // 
            this.titleLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Light", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.titleLabel.ForeColor = System.Drawing.Color.Black;
            this.titleLabel.Location = new System.Drawing.Point(24, -8);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(218, 41);
            this.titleLabel.TabIndex = 14;
            this.titleLabel.Text = "SIF\\Tiempo Aire";
            // 
            // aceptarButtonX
            // 
            this.aceptarButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.aceptarButtonX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.aceptarButtonX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.aceptarButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.aceptarButtonX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButtonX.Location = new System.Drawing.Point(391, 251);
            this.aceptarButtonX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.aceptarButtonX.Name = "aceptarButtonX";
            this.aceptarButtonX.Size = new System.Drawing.Size(80, 32);
            this.aceptarButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.aceptarButtonX.TabIndex = 18;
            this.aceptarButtonX.Text = "Aceptar";
            this.aceptarButtonX.TextColor = System.Drawing.Color.White;
            this.aceptarButtonX.Click += new System.EventHandler(this.aceptarButtonX_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelarButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cancelarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.cancelarButton.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.cancelarButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarButton.Location = new System.Drawing.Point(487, 251);
            this.cancelarButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(80, 32);
            this.cancelarButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelarButton.TabIndex = 19;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.TextColor = System.Drawing.Color.White;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // carriersTabControl
            // 
            this.carriersTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.carriersTabControl.BackColor = System.Drawing.Color.White;
            this.carriersTabControl.CanReorderTabs = true;
            this.carriersTabControl.ColorScheme.TabItemBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 1F)});
            this.carriersTabControl.ColorScheme.TabItemHotBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 1F)});
            this.carriersTabControl.ColorScheme.TabItemSelectedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.carriersTabControl.ColorScheme.TabItemSelectedBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 1F)});
            this.carriersTabControl.Controls.Add(this.tabControlPanel1);
            this.carriersTabControl.ForeColor = System.Drawing.Color.Black;
            this.carriersTabControl.Location = new System.Drawing.Point(31, 46);
            this.carriersTabControl.Name = "carriersTabControl";
            this.carriersTabControl.SelectedTabFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.carriersTabControl.SelectedTabIndex = 0;
            this.carriersTabControl.Size = new System.Drawing.Size(539, 42);
            this.carriersTabControl.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.carriersTabControl.TabIndex = 1;
            this.carriersTabControl.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.carriersTabControl.Tabs.Add(this.telcelTabItem);
            this.carriersTabControl.TabStop = false;
            this.carriersTabControl.Text = "Carriers";
            this.carriersTabControl.SelectedTabChanged += new DevComponents.DotNetBar.TabStrip.SelectedTabChangedEventHandler(this.carriersTabControl_SelectedTabChanged);
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 41);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(539, 1);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.telcelTabItem;
            // 
            // telcelTabItem
            // 
            this.telcelTabItem.AttachedControl = this.tabControlPanel1;
            this.telcelTabItem.Image = global::SIF.Properties.Resources.telcel;
            this.telcelTabItem.Name = "telcelTabItem";
            this.telcelTabItem.Text = "TELCEL";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(labelX4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.recargaComboBoxEx, 1, 1);
            this.tableLayoutPanel1.Controls.Add(labelX2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(labelX3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.maskedTextBoxAdv1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.maskedTextBoxAdv2, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(36, 96);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33389F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33472F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3314F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(534, 143);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // recargaComboBoxEx
            // 
            this.recargaComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.recargaComboBoxEx.DisplayMember = "Text";
            this.recargaComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.recargaComboBoxEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.recargaComboBoxEx.FormattingEnabled = true;
            this.recargaComboBoxEx.ItemHeight = 21;
            this.recargaComboBoxEx.Location = new System.Drawing.Point(145, 19);
            this.recargaComboBoxEx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.recargaComboBoxEx.Name = "recargaComboBoxEx";
            this.recargaComboBoxEx.Size = new System.Drawing.Size(386, 27);
            this.recargaComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.recargaComboBoxEx.TabIndex = 0;
            // 
            // maskedTextBoxAdv1
            // 
            this.maskedTextBoxAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.maskedTextBoxAdv1.BackgroundStyle.Class = "TextBoxBorder";
            this.maskedTextBoxAdv1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.maskedTextBoxAdv1.ButtonClear.Visible = true;
            this.maskedTextBoxAdv1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.maskedTextBoxAdv1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.maskedTextBoxAdv1.Location = new System.Drawing.Point(145, 61);
            this.maskedTextBoxAdv1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.maskedTextBoxAdv1.Mask = "0000000000";
            this.maskedTextBoxAdv1.Name = "maskedTextBoxAdv1";
            this.maskedTextBoxAdv1.ShortcutsEnabled = false;
            this.maskedTextBoxAdv1.Size = new System.Drawing.Size(386, 28);
            this.maskedTextBoxAdv1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.maskedTextBoxAdv1.TabIndex = 2;
            this.maskedTextBoxAdv1.Text = "";
            this.maskedTextBoxAdv1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.maskedTextBoxAdv1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.maskedTextBoxAdv1.Enter += new System.EventHandler(this.maskedTextBoxAdv1_Enter);
            this.maskedTextBoxAdv1.Leave += new System.EventHandler(this.maskedTextBoxAdv1_Leave);
            // 
            // maskedTextBoxAdv2
            // 
            this.maskedTextBoxAdv2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.maskedTextBoxAdv2.BackgroundStyle.Class = "TextBoxBorder";
            this.maskedTextBoxAdv2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.maskedTextBoxAdv2.ButtonClear.Visible = true;
            this.maskedTextBoxAdv2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.maskedTextBoxAdv2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.maskedTextBoxAdv2.Location = new System.Drawing.Point(145, 103);
            this.maskedTextBoxAdv2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.maskedTextBoxAdv2.Mask = "0000000000";
            this.maskedTextBoxAdv2.Name = "maskedTextBoxAdv2";
            this.maskedTextBoxAdv2.ShortcutsEnabled = false;
            this.maskedTextBoxAdv2.Size = new System.Drawing.Size(386, 28);
            this.maskedTextBoxAdv2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.maskedTextBoxAdv2.TabIndex = 3;
            this.maskedTextBoxAdv2.Text = "";
            this.maskedTextBoxAdv2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.maskedTextBoxAdv2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.maskedTextBoxAdv2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBoxAdv2_KeyDown);
            this.maskedTextBoxAdv2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBoxAdv2_KeyPress);
            // 
            // TiempoAireTelcelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 296);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.carriersTabControl);
            this.Controls.Add(this.aceptarButtonX);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TiempoAireTelcelForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.TiempoAireTelcelForm_Activated);
            this.Load += new System.EventHandler(this.TiempoAireForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.carriersTabControl)).EndInit();
            this.carriersTabControl.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label titleLabel;
        private DevComponents.DotNetBar.ButtonX aceptarButtonX;
        private DevComponents.DotNetBar.ButtonX cancelarButton;
        private DevComponents.DotNetBar.TabControl carriersTabControl;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem telcelTabItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx recargaComboBoxEx;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv maskedTextBoxAdv1;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv maskedTextBoxAdv2;
    }
}