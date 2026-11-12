namespace SIF.View.Menu
{
    partial class VentasMenu
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
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.ventaMostradorMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ventaCotizacionesMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ventaPedidosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ventaApartadoEspecialMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ventaDevolucionesMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ventaCancelacionMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ventasFacturaMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTilePanel1 = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.ventaCajaMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.ventaControladosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem4 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ventaNotasDeVentaMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem2 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem3 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem5 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // titlelabelX
            // 
            // 
            // 
            // 
            this.titlelabelX.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.titlelabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.titlelabelX.Text = "<font  color = \"#2E6BFA\">Farmacias Fleming</font>";
            // 
            // salirButton
            // 
            this.salirButton.Click += new System.EventHandler(this.salirButton_Click);
            // 
            // subMenuLabelX
            // 
            // 
            // 
            // 
            this.subMenuLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.subMenuLabelX.Location = new System.Drawing.Point(63, 65);
            this.subMenuLabelX.Text = "<font  color = \"#2E619D\">Venta </font>";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.BeginGroup = true;
            this.itemContainer1.ItemSpacing = 5;
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ventaMostradorMetroTileItem,
            this.ventaCotizacionesMetroTileItem,
            this.ventaPedidosMetroTileItem,
            this.ventaApartadoEspecialMetroTileItem});
            // 
            // ventaMostradorMetroTileItem
            // 
            this.ventaMostradorMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.ventaMostradorMetroTileItem.Image = global::SIF.Properties.Resources.Market_white;
            this.ventaMostradorMetroTileItem.Name = "ventaMostradorMetroTileItem";
            this.ventaMostradorMetroTileItem.Tag = "1";
            this.ventaMostradorMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish;
            this.ventaMostradorMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ventaMostradorMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ventaMostradorMetroTileItem.TitleText = "1 Nota de &Venta";
            this.ventaMostradorMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventaMostradorMetroTileItem.Click += new System.EventHandler(this.ventaMostradorMetroTileItem_Click);
            // 
            // ventaCotizacionesMetroTileItem
            // 
            this.ventaCotizacionesMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.ventaCotizacionesMetroTileItem.Image = global::SIF.Properties.Resources.Tag;
            this.ventaCotizacionesMetroTileItem.Name = "ventaCotizacionesMetroTileItem";
            this.ventaCotizacionesMetroTileItem.Tag = "2";
            this.ventaCotizacionesMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange;
            this.ventaCotizacionesMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ventaCotizacionesMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ventaCotizacionesMetroTileItem.TitleText = "2 &Cotizaciones";
            this.ventaCotizacionesMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventaCotizacionesMetroTileItem.Click += new System.EventHandler(this.ventaCotizacionesMetroTileItem_Click);
            // 
            // ventaPedidosMetroTileItem
            // 
            this.ventaPedidosMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.ventaPedidosMetroTileItem.Image = global::SIF.Properties.Resources.Box;
            this.ventaPedidosMetroTileItem.Name = "ventaPedidosMetroTileItem";
            this.ventaPedidosMetroTileItem.Tag = "3";
            this.ventaPedidosMetroTileItem.Text = "Pedidos";
            this.ventaPedidosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green;
            this.ventaPedidosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ventaPedidosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ventaPedidosMetroTileItem.TitleText = "3 &Pedidos";
            this.ventaPedidosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventaPedidosMetroTileItem.Click += new System.EventHandler(this.pedidosMetroTileItem_Click);
            // 
            // ventaApartadoEspecialMetroTileItem
            // 
            this.ventaApartadoEspecialMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.ventaApartadoEspecialMetroTileItem.Image = global::SIF.Properties.Resources.First_Aid_Kit;
            this.ventaApartadoEspecialMetroTileItem.Name = "ventaApartadoEspecialMetroTileItem";
            this.ventaApartadoEspecialMetroTileItem.Tag = "4";
            this.ventaApartadoEspecialMetroTileItem.Text = "Apartado /\r\nReserva Especial";
            this.ventaApartadoEspecialMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet;
            this.ventaApartadoEspecialMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ventaApartadoEspecialMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ventaApartadoEspecialMetroTileItem.TitleText = "4 Apartado/&Reserva Especial";
            this.ventaApartadoEspecialMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventaApartadoEspecialMetroTileItem.Click += new System.EventHandler(this.ventaApartadoEspecialMetroTileItem_Click);
            // 
            // ventaDevolucionesMetroTileItem
            // 
            this.ventaDevolucionesMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.ventaDevolucionesMetroTileItem.Image = global::SIF.Properties.Resources.Transaction_fee;
            this.ventaDevolucionesMetroTileItem.Name = "ventaDevolucionesMetroTileItem";
            this.ventaDevolucionesMetroTileItem.Tag = "5";
            this.ventaDevolucionesMetroTileItem.Text = "Devoluciones";
            this.ventaDevolucionesMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue;
            this.ventaDevolucionesMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ventaDevolucionesMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ventaDevolucionesMetroTileItem.TitleText = "5 &Devoluciones";
            this.ventaDevolucionesMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventaDevolucionesMetroTileItem.Click += new System.EventHandler(this.ventaDevolucionesMetroTileItem_Click);
            // 
            // ventaCancelacionMetroTileItem
            // 
            this.ventaCancelacionMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.ventaCancelacionMetroTileItem.Image = global::SIF.Properties.Resources.CancelacionTicket;
            this.ventaCancelacionMetroTileItem.Name = "ventaCancelacionMetroTileItem";
            this.ventaCancelacionMetroTileItem.Tag = "6";
            this.ventaCancelacionMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellowish;
            this.ventaCancelacionMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ventaCancelacionMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ventaCancelacionMetroTileItem.TitleText = "6 Cancelación de Tic&ket";
            this.ventaCancelacionMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventaCancelacionMetroTileItem.Click += new System.EventHandler(this.ventaCancelacionMetroTileItem_Click);
            // 
            // ventasFacturaMetroTileItem
            // 
            this.ventasFacturaMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.ventasFacturaMetroTileItem.Image = global::SIF.Properties.Resources.Certificate_Information;
            this.ventasFacturaMetroTileItem.Name = "ventasFacturaMetroTileItem";
            this.ventasFacturaMetroTileItem.Tag = "7";
            this.ventasFacturaMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Plum;
            this.ventasFacturaMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ventasFacturaMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ventasFacturaMetroTileItem.TitleText = "7 Fac&turas";
            this.ventasFacturaMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventasFacturaMetroTileItem.Click += new System.EventHandler(this.ventasFacturaMetroTileItem_Click);
            // 
            // metroTilePanel1
            // 
            this.metroTilePanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.metroTilePanel1.BackgroundStyle.Class = "MetroTilePanel";
            this.metroTilePanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTilePanel1.ContainerControlProcessDialogKey = true;
            this.metroTilePanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1,
            this.itemContainer3,
            this.itemContainer2});
            this.metroTilePanel1.ItemSpacing = 5;
            this.metroTilePanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.metroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroTilePanel1.Location = new System.Drawing.Point(201, 110);
            this.metroTilePanel1.Name = "metroTilePanel1";
            this.metroTilePanel1.Size = new System.Drawing.Size(611, 584);
            this.metroTilePanel1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTilePanel1.TabIndex = 0;
            this.metroTilePanel1.Text = "metroTilePanel1";
            // 
            // itemContainer3
            // 
            // 
            // 
            // 
            this.itemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer3.ItemSpacing = 5;
            this.itemContainer3.MultiLine = true;
            this.itemContainer3.Name = "itemContainer3";
            this.itemContainer3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ventaDevolucionesMetroTileItem,
            this.ventaCancelacionMetroTileItem,
            this.ventasFacturaMetroTileItem,
            this.ventaCajaMetroTileItem});
            // 
            // ventaCajaMetroTileItem
            // 
            this.ventaCajaMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.ventaCajaMetroTileItem.Image = global::SIF.Properties.Resources.Counting_machine;
            this.ventaCajaMetroTileItem.Name = "ventaCajaMetroTileItem";
            this.ventaCajaMetroTileItem.Tag = "7";
            this.ventaCajaMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Olive;
            this.ventaCajaMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ventaCajaMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ventaCajaMetroTileItem.TitleText = "8 Ca&ja";
            this.ventaCajaMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.ventaCajaMetroTileItem.Click += new System.EventHandler(this.cajaMetroTileItem_Click);
            // 
            // itemContainer2
            // 
            // 
            // 
            // 
            this.itemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer2.ItemSpacing = 5;
            this.itemContainer2.MultiLine = true;
            this.itemContainer2.Name = "itemContainer2";
            this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ventaControladosMetroTileItem,
            this.metroTileItem1,
            this.metroTileItem4,
            this.metroTileItem5});
            // 
            // ventaControladosMetroTileItem
            // 
            this.ventaControladosMetroTileItem.DisabledBackColor = System.Drawing.Color.Silver;
            this.ventaControladosMetroTileItem.Image = global::SIF.Properties.Resources.Syringe;
            this.ventaControladosMetroTileItem.Name = "ventaControladosMetroTileItem";
            this.ventaControladosMetroTileItem.Tag = "8";
            this.ventaControladosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure;
            this.ventaControladosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ventaControladosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ventaControladosMetroTileItem.TitleText = "9 C&ontrolados";
            this.ventaControladosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.ventaControladosMetroTileItem.Click += new System.EventHandler(this.controladosMetroTileItem_Click);
            // 
            // metroTileItem1
            // 
            this.metroTileItem1.DisabledBackColor = System.Drawing.Color.DarkBlue;
            this.metroTileItem1.Image = global::SIF.Properties.Resources.tipodecambio;
            this.metroTileItem1.DisabledBackColor = System.Drawing.Color.Silver;            
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.TitleText = "13 Reportes";
            this.metroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem1.TileSize = new System.Drawing.Size(140, 140);
            this.metroTileItem1.Click += new System.EventHandler(this.metroTileItem1_Click);
     
            // 
            // metroTileItem4
            // 
            this.metroTileItem4.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem4.Enabled = false;
            this.metroTileItem4.Name = "metroTileItem4";
            this.metroTileItem4.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem4.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem4.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem4.Click += new System.EventHandler(this.metroTileItem4_Click);
            // 
            // ventaNotasDeVentaMetroTileItem
            // 
            this.ventaNotasDeVentaMetroTileItem.Image = global::SIF.Properties.Resources.Insurance_Bill;
            this.ventaNotasDeVentaMetroTileItem.Name = "ventaNotasDeVentaMetroTileItem";
            this.ventaNotasDeVentaMetroTileItem.Text = "Notas de VentaN";
            this.ventaNotasDeVentaMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Coffee;
            this.ventaNotasDeVentaMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.ventaNotasDeVentaMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ventaNotasDeVentaMetroTileItem.TitleText = "Genera &Nota de VentaN";
            this.ventaNotasDeVentaMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroTileItem2
            // 
            this.metroTileItem2.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem2.Image = global::SIF.Properties.Resources.Market_white;
            this.metroTileItem2.Name = "metroTileItem2";
            this.metroTileItem2.Tag = "1";
            this.metroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish;
            this.metroTileItem2.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem2.TitleText = "1 Nota de &Venta";
            this.metroTileItem2.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroTileItem3
            // 
            this.metroTileItem3.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem3.Image = global::SIF.Properties.Resources.Market_white;
            this.metroTileItem3.Name = "metroTileItem3";
            this.metroTileItem3.Tag = "1";
            this.metroTileItem3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blueish;
            this.metroTileItem3.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem3.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem3.TitleText = "1 Nota de &Venta";
            this.metroTileItem3.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroTileItem5
            // 
            this.metroTileItem5.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem5.Enabled = false;
            this.metroTileItem5.Name = "metroTileItem5";
            this.metroTileItem5.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem5.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem5.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // VentasMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTilePanel1);
            this.Name = "VentasMenu";
            this.Controls.SetChildIndex(this.subMenuLabelX, 0);
            this.Controls.SetChildIndex(this.salirButton, 0);
            this.Controls.SetChildIndex(this.titlelabelX, 0);
            this.Controls.SetChildIndex(this.metroTilePanel1, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel1;
        private DevComponents.DotNetBar.Metro.MetroTileItem ventaPedidosMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem ventaDevolucionesMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem ventasFacturaMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem ventaApartadoEspecialMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem ventaCotizacionesMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem ventaMostradorMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem ventaCancelacionMetroTileItem;
        private DevComponents.DotNetBar.ItemContainer itemContainer2;
        private DevComponents.DotNetBar.Metro.MetroTileItem ventaCajaMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem ventaControladosMetroTileItem;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem1;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem4;
        private DevComponents.DotNetBar.Metro.MetroTileItem ventaNotasDeVentaMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem2;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem3;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem5;
    }
}
