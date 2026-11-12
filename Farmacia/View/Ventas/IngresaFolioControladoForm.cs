using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Ventas
{
    public partial class IngresaFolioControladoForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public int usuarioID;
        public IngresaFolioControladoForm()
        {
            InitializeComponent();
        }
        public SIFModelo.Controlado FolioControlado;
        private Boolean Valida()
        {
            if (string.IsNullOrEmpty(this.textBoxX1.Text) || string.IsNullOrWhiteSpace(this.textBoxX1.Text))
            {
               MessageBox.Show("Debe ingresar un folio");
                this.textBoxX1.Focus();
                return false;
            }

            string prefijo = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yy");
            int numControlado = 0;
            string sb = Helpers.Sesion.Sucursal.SucursalesID.ToString("00") + prefijo + numControlado.ToString().PadLeft(6, '0');
            int s = (sb.Length) - textBoxX1.Text.Length;
            string st = "";
            if (s > 0)
            {
                st = sb.Substring(0, s);
            }
            sb = st + textBoxX1.Text;

            FolioControlado = new SIFModelo.Controlado();
            FolioControlado.Folio = sb;
            SIFNegocio.Controlado controladoL = new SIFNegocio.Controlado();
            FolioControlado = controladoL.ControladoPorFolio(FolioControlado);

            if (FolioControlado == null)
            {
               MessageBox.Show("El folio no existe o no se ha dado de alta");
                this.textBoxX1.Focus();
                this.textBoxX1.SelectAll();
                return false;
            }

            if (((char)FolioControlado.Activo != 'S' && FolioControlado.Activo != SIFModelo.Tipos.TipoActivoControlado.GENERADA ) || (!string.IsNullOrEmpty(FolioControlado.RemisionID) && FolioControlado.RemisionID != "0"))
            {
               MessageBox.Show("Folio no activo");
                this.textBoxX1.Focus();
                this.textBoxX1.SelectAll();
                return false;
            }

            //verificamos que el folio controlado tenga el mismo usuario que se ingreso en folios controlados
            if (FolioControlado.UsuarioID != usuarioID)
            {
               MessageBox.Show("Folio no pertenece al usuario activo");
                return false;
            }

            
            //CARGAR LOS DETALLES DEL FOLIO CONTROLADO
            FolioControlado.Detalles = controladoL.DetallesControlado(FolioControlado);
            return true;
        }



        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (this.Valida())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void IngresaFolioControladoForm_Load(object sender, EventArgs e)
        {
            this.textBoxX1.Focus();
        }
    }
}