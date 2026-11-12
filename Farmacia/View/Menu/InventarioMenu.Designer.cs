using System;
namespace SIF.View.Menu
{
    partial class InventarioMenu
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
            this.metroTilePanel1 = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.pedidoAlmacenMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem13 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem14 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem17 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.consultaProductosMetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem16 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem18 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem20 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem21 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.generaEOQmetroTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem2 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem3 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.itemContainer4 = new DevComponents.DotNetBar.ItemContainer();
            this.pncTileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
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
            this.subMenuLabelX.Location = new System.Drawing.Point(63, 66);
            this.subMenuLabelX.Text = "Inventario";
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
            this.itemContainer2,
            this.itemContainer3,
            this.itemContainer4});
            this.metroTilePanel1.ItemSpacing = 5;
            this.metroTilePanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.metroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroTilePanel1.Location = new System.Drawing.Point(200, 110);
            this.metroTilePanel1.Name = "metroTilePanel1";
            this.metroTilePanel1.Size = new System.Drawing.Size(627, 627);
            this.metroTilePanel1.TabIndex = 0;
            this.metroTilePanel1.Text = "metroTilePanel1";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.ItemSpacing = 5;
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.pedidoAlmacenMetroTileItem,
            this.metroTileItem13,
            this.metroTileItem14,
            this.metroTileItem17});
            // 
            // pedidoAlmacenMetroTileItem
            // 
            this.pedidoAlmacenMetroTileItem.Image = global::SIF.Properties.Resources.Pedido_a_inventario;
            this.pedidoAlmacenMetroTileItem.Name = "pedidoAlmacenMetroTileItem";
            this.pedidoAlmacenMetroTileItem.Tag = "29";
            this.pedidoAlmacenMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.PlumWashed;
            this.pedidoAlmacenMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.pedidoAlmacenMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pedidoAlmacenMetroTileItem.TitleText = "Pedidos";
            this.pedidoAlmacenMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pedidoAlmacenMetroTileItem.Click += new System.EventHandler(this.pedidoAlmacenMetroTileItem_Click);
            // 
            // metroTileItem13
            // 
            this.metroTileItem13.Image = global::SIF.Properties.Resources.Enviodetraspasos;
            this.metroTileItem13.Name = "metroTileItem13";
            this.metroTileItem13.Tag = "30";
            this.metroTileItem13.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure;
            this.metroTileItem13.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem13.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem13.TitleText = "Envio de Traspasos";
            this.metroTileItem13.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTileItem13.Click += new System.EventHandler(this.metroTileItem13_Click);
            // 
            // metroTileItem14
            // 
            this.metroTileItem14.Image = global::SIF.Properties.Resources.recepcióndeTraspasos;
            this.metroTileItem14.Name = "metroTileItem14";
            this.metroTileItem14.Tag = "31";
            this.metroTileItem14.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkOlive;
            this.metroTileItem14.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem14.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem14.TitleText = "Recepción de Traspasos";
            this.metroTileItem14.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTileItem14.Click += new System.EventHandler(this.metroTileItem14_Click);
            // 
            // metroTileItem17
            // 
            this.metroTileItem17.Image = global::SIF.Properties.Resources.Kardex;
            this.metroTileItem17.Name = "metroTileItem17";
            this.metroTileItem17.Tag = "32";
            this.metroTileItem17.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Rust;
            this.metroTileItem17.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem17.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem17.TitleText = "KARDEX";
            this.metroTileItem17.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTileItem17.Click += new System.EventHandler(this.metroTileItem17_Click);
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
            this.consultaProductosMetroTileItem,
            this.metroTileItem16,
            this.metroTileItem18,
            this.metroTileItem20});
            // 
            // consultaProductosMetroTileItem
            // 
            this.consultaProductosMetroTileItem.Image = global::SIF.Properties.Resources.ConsultadeProductos;
            this.consultaProductosMetroTileItem.Name = "consultaProductosMetroTileItem";
            this.consultaProductosMetroTileItem.Tag = "33";
            this.consultaProductosMetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green;
            this.consultaProductosMetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.consultaProductosMetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.consultaProductosMetroTileItem.TitleText = "Consulta de Artículos";
            this.consultaProductosMetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultaProductosMetroTileItem.Click += new System.EventHandler(this.consultaProductosMetroTileItem_Click);
            // 
            // metroTileItem16
            // 
            this.metroTileItem16.Image = global::SIF.Properties.Resources.AltaProductos;
            this.metroTileItem16.Name = "metroTileItem16";
            this.metroTileItem16.Tag = "34";
            this.metroTileItem16.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Olive;
            this.metroTileItem16.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem16.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem16.TitleText = "Alta de Artículos";
            this.metroTileItem16.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTileItem16.Click += new System.EventHandler(this.metroTileItem16_Click);
            // 
            // metroTileItem18
            // 
            this.metroTileItem18.Image = global::SIF.Properties.Resources.ConversiondePiezas;
            this.metroTileItem18.Name = "metroTileItem18";
            this.metroTileItem18.Tag = "35";
            this.metroTileItem18.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange;
            this.metroTileItem18.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem18.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem18.TitleText = "Conversión de Piezas";
            this.metroTileItem18.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTileItem18.Click += new System.EventHandler(this.metroTileItem18_Click);
            // 
            // metroTileItem20
            // 
            this.metroTileItem20.Image = global::SIF.Properties.Resources.AjustesInventario;
            this.metroTileItem20.Name = "metroTileItem20";
            this.metroTileItem20.Tag = "36";
            this.metroTileItem20.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Maroon;
            this.metroTileItem20.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem20.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem20.TitleText = "Ajustes";
            this.metroTileItem20.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTileItem20.Click += new System.EventHandler(this.metroTileItem20_Click);
            string tipo_usuariop = Helpers.Sesion.Usuario.TipoUsuario.ToString();
            
            bool result = tipo_usuariop.Equals("ADMINISTRATIVO", StringComparison.CurrentCultureIgnoreCase);
            if (result)
            {
                this.metroTileItem20.Enabled = true;

            }
            else
            {
                this.metroTileItem20.Enabled = false;
            }
            // metroTileItem21
            // 
            this.metroTileItem21.Image = global::SIF.Properties.Resources.Destrucciones4;
            this.metroTileItem21.Name = "metroTileItem21";
            this.metroTileItem21.Tag = "90";
            this.metroTileItem21.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green;
            this.metroTileItem21.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem21.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem21.TitleText = "Destrucciones";
            this.metroTileItem21.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTileItem21.Click += new System.EventHandler(this.metroTileItem21_Click);



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
            this.generaEOQmetroTileItem,
            this.metroTileItem2,
            this.metroTileItem3,
            this.metroTileItem21});

            // 
            // generaEOQmetroTileItem
            // 
            this.generaEOQmetroTileItem.Image = global::SIF.Properties.Resources.EoQ;
            this.generaEOQmetroTileItem.Name = "generaEOQmetroTileItem";
            this.generaEOQmetroTileItem.Tag = "37";
            this.generaEOQmetroTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure;
            this.generaEOQmetroTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.generaEOQmetroTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.generaEOQmetroTileItem.TitleText = "Genera EOQ";
            this.generaEOQmetroTileItem.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generaEOQmetroTileItem.Click += new System.EventHandler(this.generaEOQmetroTileItem_Click);
            // 
            // metroTileItem2
            // 
            this.metroTileItem2.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem2.Image = global::SIF.Properties.Resources.EQUIVALENCIA;
            this.metroTileItem2.Name = "metroTileItem2";
            this.metroTileItem2.Tag = "39";
            this.metroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Teal;
            this.metroTileItem2.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem2.TitleText = "Equivalencias";
            this.metroTileItem2.Click += new System.EventHandler(this.metroTileItem2_Click);
            // 
            // metroTileItem3
            // 
            this.metroTileItem3.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem3.Image = global::SIF.Properties.Resources.ColumnChooser;
            this.metroTileItem3.Name = "metroTileItem3";
            this.metroTileItem3.Tag = "39";
            this.metroTileItem3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue;
            this.metroTileItem3.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem3.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem3.TitleText = "Inventario Fisico";
            this.metroTileItem3.Click += new System.EventHandler(this.metroTileItem3_Click);
            // 
            // itemContainer4
            // 
            // 
            // 
            // 
            this.itemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer3.ItemSpacing = 5;
            this.itemContainer3.MultiLine = true;
            this.itemContainer3.Name = "itemContainer4";
            this.itemContainer3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.pncTileItem});
            // 
            // pncTileItem
            // 
            this.pncTileItem.Image = global::SIF.Properties.Resources.Productos;
            this.pncTileItem.Name = "pncTileItem";
            this.pncTileItem.Tag = "36";
            this.pncTileItem.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Plum;
            this.pncTileItem.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.pncTileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pncTileItem.TitleText = "Producto no conforme";
            this.pncTileItem.Click += new System.EventHandler(this.pncTileItem_Click);
            // 
            // metroTileItem1
            // 
            this.metroTileItem1.DisabledBackColor = System.Drawing.Color.Silver;
            this.metroTileItem1.Enabled = false;
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.Tag = "23";
            this.metroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.metroTileItem1.TileSize = new System.Drawing.Size(140, 140);
            // 
            // 
            // 
            this.metroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem1.TitleTextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // InventarioMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTilePanel1);
            this.Name = "InventarioMenu";
            this.Controls.SetChildIndex(this.subMenuLabelX, 0);
            this.Controls.SetChildIndex(this.salirButton, 0);
            this.Controls.SetChildIndex(this.titlelabelX, 0);
            this.Controls.SetChildIndex(this.metroTilePanel1, 0);
            this.Controls.SetChildIndex(this.backButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem pedidoAlmacenMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem13;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem14;
        private DevComponents.DotNetBar.Metro.MetroTileItem consultaProductosMetroTileItem;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem16;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem17;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem18;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem20;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem21;
        private DevComponents.DotNetBar.Metro.MetroTileItem generaEOQmetroTileItem;
        private DevComponents.DotNetBar.ItemContainer itemContainer2;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem2;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem3;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem1;
        private DevComponents.DotNetBar.ItemContainer itemContainer4;
        private DevComponents.DotNetBar.Metro.MetroTileItem pncTileItem;
    }
}
