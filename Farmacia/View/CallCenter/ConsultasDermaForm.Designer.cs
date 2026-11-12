namespace SIF.View.CallCenter
{
    partial class ConsultasDermaForm
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
            DevComponents.DotNetBar.LabelX labelX1;
            DevComponents.DotNetBar.LabelX labelX4;
            DevComponents.DotNetBar.LabelX labelX2;
            DevComponents.DotNetBar.LabelX labelX3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultasDermaForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dateNavigator1 = new DevComponents.DotNetBar.Schedule.DateNavigator();
            this.calendarView = new DevComponents.DotNetBar.Schedule.CalendarView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sucursalesComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.monthCalendarAdv1 = new DevComponents.Editors.DateTimeAdv.MonthCalendarAdv();
            this.clienteLabelX = new DevComponents.DotNetBar.LabelX();
            this.medicoLabelX = new DevComponents.DotNetBar.LabelX();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCliente = new DevComponents.DotNetBar.ButtonX();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMedico = new DevComponents.DotNetBar.ButtonX();
            this.horarioComboBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.nuevaCitaButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.eliminarArticuloButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.seleccionaClienteButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.seleccionaMedicoButtonItem = new DevComponents.DotNetBar.ButtonItem();
            this.guardarButtonItem = new DevComponents.DotNetBar.ButtonItem();
            labelX1 = new DevComponents.DotNetBar.LabelX();
            labelX4 = new DevComponents.DotNetBar.LabelX();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            labelX3 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.dateNavigator1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bar1
            // 
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.nuevaCitaButtonItem,
            this.seleccionaClienteButtonItem,
            this.seleccionaMedicoButtonItem,
            this.guardarButtonItem,
            this.eliminarArticuloButtonItem});
            this.bar1.Size = new System.Drawing.Size(793, 92);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(306, 32);
            this.titleLabel.Text = "CALL CENTER\\CITAS DERMA";
            // 
            // splitContainer1
            // 
            this.splitContainer1.IsSplitterFixed = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
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
            // labelX1
            // 
            // 
            // 
            // 
            labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelX1.Location = new System.Drawing.Point(3, 361);
            labelX1.Name = "labelX1";
            labelX1.Size = new System.Drawing.Size(75, 14);
            labelX1.TabIndex = 3;
            labelX1.Text = "Horario";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelX4.Location = new System.Drawing.Point(3, 139);
            labelX4.Name = "labelX4";
            labelX4.Size = new System.Drawing.Size(75, 14);
            labelX4.TabIndex = 4;
            labelX4.Text = "Sucursal";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelX2.Location = new System.Drawing.Point(3, 3);
            labelX2.Name = "labelX2";
            labelX2.Size = new System.Drawing.Size(75, 8);
            labelX2.TabIndex = 4;
            labelX2.Text = "Cliente";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelX3.Location = new System.Drawing.Point(3, 3);
            labelX3.Name = "labelX3";
            labelX3.Size = new System.Drawing.Size(75, 8);
            labelX3.TabIndex = 4;
            labelX3.Text = "Medico";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dateNavigator1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 564);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.CalendarView = this.calendarView;
            this.dateNavigator1.CanvasColor = System.Drawing.SystemColors.Control;
            this.dateNavigator1.Controls.Add(this.calendarView);
            this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateNavigator1.Location = new System.Drawing.Point(183, 3);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.Size = new System.Drawing.Size(729, 558);
            this.dateNavigator1.Style.BackColor1.Color = System.Drawing.Color.White;
            this.dateNavigator1.TabIndex = 1;
            // 
            // calendarView
            // 
            this.calendarView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendarView.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.calendarView.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.calendarView.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.calendarView.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.calendarView.ContainerControlProcessDialogKey = true;
            this.calendarView.ForeColor = System.Drawing.Color.Black;
            this.calendarView.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.calendarView.Location = new System.Drawing.Point(3, 31);
            this.calendarView.MultiUserTabHeight = 24;
            this.calendarView.Name = "calendarView";
            this.calendarView.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Week;
            this.calendarView.ShowOnlyWorkDayHours = true;
            this.calendarView.Size = new System.Drawing.Size(723, 520);
            this.calendarView.TabIndex = 0;
            this.calendarView.TimeIndicator.BorderColor = System.Drawing.Color.Empty;
            this.calendarView.TimeIndicator.Tag = null;
            this.calendarView.TimeSlotDuration = 30;
            this.calendarView.WeekDayCanExtendRange = false;
            this.calendarView.YearViewShowGridLines = false;
            this.calendarView.ItemClick += new System.EventHandler(this.calendarView_ItemClick);
            this.calendarView.ItemRemoved += new DevComponents.DotNetBar.ItemControl.ItemRemovedEventHandler(this.calendarView_ItemRemoved);
            this.calendarView.Click += new System.EventHandler(this.calendarView_Click);
            this.calendarView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.calendarView_KeyDown);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.sucursalesComboBoxEx, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.monthCalendarAdv1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.clienteLabelX, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.medicoLabelX, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.horarioComboBoxEx, 0, 8);
            this.tableLayoutPanel2.Controls.Add(labelX1, 0, 7);
            this.tableLayoutPanel2.Controls.Add(labelX4, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 12;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33444F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33444F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(174, 508);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // sucursalesComboBoxEx
            // 
            this.sucursalesComboBoxEx.DisplayMember = "Text";
            this.sucursalesComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.sucursalesComboBoxEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sucursalesComboBoxEx.FormattingEnabled = true;
            this.sucursalesComboBoxEx.ItemHeight = 19;
            this.sucursalesComboBoxEx.Location = new System.Drawing.Point(3, 159);
            this.sucursalesComboBoxEx.Name = "sucursalesComboBoxEx";
            this.sucursalesComboBoxEx.Size = new System.Drawing.Size(168, 25);
            this.sucursalesComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sucursalesComboBoxEx.TabIndex = 21;
            this.sucursalesComboBoxEx.SelectedIndexChanged += new System.EventHandler(this.sucursalesComboBoxEx_SelectedIndexChanged);
            // 
            // monthCalendarAdv1
            // 
            this.monthCalendarAdv1.AnnuallyMarkedDates = new System.DateTime[0];
            this.monthCalendarAdv1.AutoSize = true;
            // 
            // 
            // 
            this.monthCalendarAdv1.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.monthCalendarAdv1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.monthCalendarAdv1.BackgroundStyle.BorderBottomWidth = 1;
            this.monthCalendarAdv1.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.monthCalendarAdv1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.monthCalendarAdv1.BackgroundStyle.BorderLeftWidth = 1;
            this.monthCalendarAdv1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.monthCalendarAdv1.BackgroundStyle.BorderRightWidth = 1;
            this.monthCalendarAdv1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.monthCalendarAdv1.BackgroundStyle.BorderTopWidth = 1;
            this.monthCalendarAdv1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.monthCalendarAdv1.Colors.DayMarker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.monthCalendarAdv1.Colors.DayMarker.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.monthCalendarAdv1.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.monthCalendarAdv1.ContainerControlProcessDialogKey = true;
            this.monthCalendarAdv1.DisplayMonth = new System.DateTime(2012, 11, 1, 0, 0, 0, 0);
            this.monthCalendarAdv1.Location = new System.Drawing.Point(3, 3);
            this.monthCalendarAdv1.MarkedDates = new System.DateTime[0];
            this.monthCalendarAdv1.MonthlyMarkedDates = new System.DateTime[0];
            this.monthCalendarAdv1.Name = "monthCalendarAdv1";
            // 
            // 
            // 
            this.monthCalendarAdv1.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.monthCalendarAdv1.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.monthCalendarAdv1.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.monthCalendarAdv1.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.monthCalendarAdv1.Size = new System.Drawing.Size(170, 131);
            this.monthCalendarAdv1.TabIndex = 2;
            this.monthCalendarAdv1.Text = "monthCalendarAdv1";
            this.monthCalendarAdv1.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.monthCalendarAdv1.DateChanged += new System.EventHandler(this.monthCalendarAdv1_DateChanged);
            this.monthCalendarAdv1.ItemClick += new System.EventHandler(this.monthCalendarAdv1_ItemClick);
            // 
            // clienteLabelX
            // 
            this.clienteLabelX.AutoSize = true;
            // 
            // 
            // 
            this.clienteLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.clienteLabelX.Location = new System.Drawing.Point(3, 217);
            this.clienteLabelX.Name = "clienteLabelX";
            this.clienteLabelX.Size = new System.Drawing.Size(58, 20);
            this.clienteLabelX.TabIndex = 5;
            this.clienteLabelX.Text = "[CLIENTE]";
            // 
            // medicoLabelX
            // 
            this.medicoLabelX.AutoSize = true;
            // 
            // 
            // 
            this.medicoLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.medicoLabelX.Location = new System.Drawing.Point(3, 303);
            this.medicoLabelX.Name = "medicoLabelX";
            this.medicoLabelX.Size = new System.Drawing.Size(59, 20);
            this.medicoLabelX.TabIndex = 5;
            this.medicoLabelX.Text = "[MEDICO]";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(labelX2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCliente, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 189);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(168, 22);
            this.tableLayoutPanel3.TabIndex = 21;
            // 
            // btnCliente
            // 
            this.btnCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCliente.Location = new System.Drawing.Point(87, 3);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(49, 16);
            this.btnCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCliente.TabIndex = 5;
            this.btnCliente.Text = "...";
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btnMedico, 0, 0);
            this.tableLayoutPanel4.Controls.Add(labelX3, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 275);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(168, 22);
            this.tableLayoutPanel4.TabIndex = 23;
            // 
            // btnMedico
            // 
            this.btnMedico.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMedico.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnMedico.Location = new System.Drawing.Point(87, 3);
            this.btnMedico.Name = "btnMedico";
            this.btnMedico.Size = new System.Drawing.Size(49, 16);
            this.btnMedico.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMedico.TabIndex = 6;
            this.btnMedico.Text = "...";
            this.btnMedico.Click += new System.EventHandler(this.btnMedico_Click);
            // 
            // horarioComboBoxEx
            // 
            this.horarioComboBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.horarioComboBoxEx.DisplayMember = "Text";
            this.horarioComboBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.horarioComboBoxEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.horarioComboBoxEx.FormattingEnabled = true;
            this.horarioComboBoxEx.ItemHeight = 19;
            this.horarioComboBoxEx.Location = new System.Drawing.Point(3, 381);
            this.horarioComboBoxEx.Name = "horarioComboBoxEx";
            this.horarioComboBoxEx.Size = new System.Drawing.Size(168, 25);
            this.horarioComboBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.horarioComboBoxEx.TabIndex = 6;
            // 
            // nuevaCitaButtonItem
            // 
            this.nuevaCitaButtonItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("nuevaCitaButtonItem.HoverImage")));
            this.nuevaCitaButtonItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevaCitaButtonItem.Image")));
            this.nuevaCitaButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.nuevaCitaButtonItem.Name = "nuevaCitaButtonItem";
            this.nuevaCitaButtonItem.Tag = "1";
            this.nuevaCitaButtonItem.Text = "Nueva\r\n [F2]";
            this.nuevaCitaButtonItem.Click += new System.EventHandler(this.nuevaCitaButtonItem_Click);
            // 
            // eliminarArticuloButtonItem
            // 
            this.eliminarArticuloButtonItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("eliminarArticuloButtonItem.HoverImage")));
            this.eliminarArticuloButtonItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarArticuloButtonItem.Image")));
            this.eliminarArticuloButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.eliminarArticuloButtonItem.Name = "eliminarArticuloButtonItem";
            this.eliminarArticuloButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.eliminarArticuloButtonItem.Tag = "6";
            this.eliminarArticuloButtonItem.Text = "Eliminar \r\n[F6]";
            // 
            // seleccionaClienteButtonItem
            // 
            this.seleccionaClienteButtonItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("seleccionaClienteButtonItem.HoverImage")));
            this.seleccionaClienteButtonItem.Image = ((System.Drawing.Image)(resources.GetObject("seleccionaClienteButtonItem.Image")));
            this.seleccionaClienteButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.seleccionaClienteButtonItem.Name = "seleccionaClienteButtonItem";
            this.seleccionaClienteButtonItem.Text = "Cliente\r\n[F3]";
            this.seleccionaClienteButtonItem.Click += new System.EventHandler(this.seleccionaClienteButtonItem_Click);
            // 
            // seleccionaMedicoButtonItem
            // 
            this.seleccionaMedicoButtonItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("seleccionaMedicoButtonItem.HoverImage")));
            this.seleccionaMedicoButtonItem.Image = global::SIF.Properties.Resources.IDCardTool;
            this.seleccionaMedicoButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.seleccionaMedicoButtonItem.Name = "seleccionaMedicoButtonItem";
            this.seleccionaMedicoButtonItem.Text = "Medico\r\n[F4]";
            this.seleccionaMedicoButtonItem.Click += new System.EventHandler(this.seleccionaMedicoButtonItem_Click);
            // 
            // guardarButtonItem
            // 
            this.guardarButtonItem.HoverImage = ((System.Drawing.Image)(resources.GetObject("guardarButtonItem.HoverImage")));
            this.guardarButtonItem.Image = ((System.Drawing.Image)(resources.GetObject("guardarButtonItem.Image")));
            this.guardarButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.guardarButtonItem.Name = "guardarButtonItem";
            this.guardarButtonItem.Tag = "5";
            this.guardarButtonItem.Text = "Guardar\r\n[F5]";
            this.guardarButtonItem.Click += new System.EventHandler(this.guardarButtonItem_Click);
            // 
            // ConsultasDermaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ConsultasDermaForm";
            this.Load += new System.EventHandler(this.ConsultasDermaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.dateNavigator1.ResumeLayout(false);
            this.dateNavigator1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Schedule.CalendarView calendarView;
        private DevComponents.DotNetBar.Schedule.DateNavigator dateNavigator1;
        private DevComponents.Editors.DateTimeAdv.MonthCalendarAdv monthCalendarAdv1;
        private DevComponents.DotNetBar.ButtonItem nuevaCitaButtonItem;
        private DevComponents.DotNetBar.ButtonItem eliminarArticuloButtonItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevComponents.DotNetBar.LabelX clienteLabelX;
        private DevComponents.DotNetBar.LabelX medicoLabelX;
        private DevComponents.DotNetBar.Controls.ComboBoxEx horarioComboBoxEx;
        private DevComponents.DotNetBar.Controls.ComboBoxEx sucursalesComboBoxEx;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevComponents.DotNetBar.ButtonItem seleccionaClienteButtonItem;
        private DevComponents.DotNetBar.ButtonItem seleccionaMedicoButtonItem;
        private DevComponents.DotNetBar.ButtonItem guardarButtonItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevComponents.DotNetBar.ButtonX btnCliente;
        private DevComponents.DotNetBar.ButtonX btnMedico;
    }
}