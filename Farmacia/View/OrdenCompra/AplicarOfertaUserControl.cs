using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.OrdenCompra
{
    public partial class AplicarOfertaUserControl : Templates.CatalogoUserControl
    {
        public AplicarOfertaUserControl(bool esFacturas = false)
        {
            InitializeComponent();
            this.esFacturas = esFacturas;
            dataGridViewX1.AutoGenerateColumns = false;
            Privilegios();

            if (esFacturas)
            {
                this.cargaArchivoOfertasButtonItem.Visible = false;
                this.facturasButtonItem.Visible = true;
                this.titleLabel.Text = "COMPRAS\\APLICAR FACTURAS";
            }
            else
            {
                this.cargaArchivoOfertasButtonItem.Visible = true;
                this.facturasButtonItem.Visible = false;
            }
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 19, int.Parse(Xbtn.Tag.ToString()));
            }

        }

        SIFNegocio.OrdenCompra.ArchivoOfertas ofertasL = new SIFNegocio.OrdenCompra.ArchivoOfertas();
        private bool esFacturas;
        private void cargaArchivos()
        {
            if (esFacturas)
            {
                this.dataGridViewX1.DataSource = ofertasL.ArchivosFacturasProveedores();
            }
            else
            {
                this.dataGridViewX1.DataSource = ofertasL.ArchivosProveedores();
            }
        }

        private void Aplicar()
        {
            if (this.dataGridViewX1.CurrentRow == null)
            {
               MessageBox.Show("Debe elegir un archivo a aplicar");
                return;
            }

            //APLICAMOS EL ARCHIVO
           MessageBox.Show("Se importará el archivo, este proceso puede tardar varios minutos","Importar",  MessageBoxButtons.OK);
            this.Cursor = Cursors.WaitCursor;
            SIFModelo.OrdenCompra.OrdenCompraDataSet.CTL_ARCHIVOS_PROVEEDORRow row = ((DataRowView)dataGridViewX1.CurrentRow.DataBoundItem).Row as SIFModelo.OrdenCompra.OrdenCompraDataSet.CTL_ARCHIVOS_PROVEEDORRow;
            if (!ofertasL.Aplicar(row))
            {
                this.Cursor = Cursors.Default;
               MessageBox.Show("Ha ocurrido un error al importar los archivos, verifique que el archivo sea correcto","Importar",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Cursor = Cursors.Default;

           MessageBox.Show("Se ha importado el archivo correctamente!");

            if (esFacturas)
            {
                this.cargaArchivosFacturas();
            }
            else
            {
                this.cargaArchivos();
            }
        }

        private void cargaArchivoOfertasButtonItem_Click(object sender, EventArgs e)
        {
            this.cargaArchivos();
        }

        public void Back()
        {
            try{
            Owner.ActivaComandos();
            this.DesactivaComandos();
            if (Owner.Owner.Contains(this))
            {
                Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            }
            this.Mostrado = true;
            }
            catch { }
        }

        private void DesactivaComandos()
        {
            this.backButton.Shortcuts.Clear();
        }

        public Menu.ComprasMenu Owner { get; set; }

        internal void Muestra()
        {
            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;
        }

        private void ActivaComandos()
        {
            this.backButton.Shortcuts.Add(eShortcut.F12);
        }

        public bool Mostrado { get; set; }



        private void aplicarButtonItem_Click(object sender, EventArgs e)
        {
            this.Aplicar();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void AplicarOfertaUserControl_Load(object sender, EventArgs e)
        {
            if (esFacturas)
            {
                this.cargaArchivosFacturas();
            }
            else
            {
                this.cargaArchivos();
            }
        }

        private void dataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                DataObject d = dataGridViewX1.GetClipboardContent();
                if (d == null) { return; }
                Clipboard.SetDataObject(d);
            }
        }

        private void facturasButtonItem_Click(object sender, EventArgs e)
        {
            this.cargaArchivosFacturas();
        }

        private void cargaArchivosFacturas()
        {
            this.dataGridViewX1.DataSource = ofertasL.ArchivosFacturasProveedores();
        }
    }
}
