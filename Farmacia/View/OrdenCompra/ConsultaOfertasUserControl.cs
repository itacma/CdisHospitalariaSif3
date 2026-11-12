using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;

namespace SIF.View.OrdenCompra
{
    public partial class ConsultaOfertasUserControl : Templates.ListaUserControl
    {
        public ConsultaOfertasUserControl()
        {
            InitializeComponent();
            Privilegios();
        }


        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 15, int.Parse(Xbtn.Tag.ToString()));
            }

        }
        
        #region Navegacion

        public View.Menu.ComprasMenu Owner;
        private bool Mostrado = false;
        public void Muestra()
        {
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;

            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }

        public void Back()
        {
            Owner.Owner.DesactivaComandos();
            Owner.ActivaComandos();
            this.DesactivaComandos();
            this.Mostrado = false;

            if (Owner.Owner.Contains(this))
            {
                Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            }
        }

        public void ActivaComandos()
        {
            agregaProductoButtonItem.Shortcuts.Add(eShortcut.F3);
        }

        public void DesactivaComandos()
        {
            agregaProductoButtonItem.Shortcuts.Clear();
        }

        #endregion

        #region Funciones Y Metodos


        private void Buscar()
        {
            //this.ocDS = descuentosL.Buscar(nombreTextBoxX.Text, dateTimeInput1.Value, dateTimeInput2.Value);
            //this.superGridControl1.PrimaryGrid.DataSource = ocDS;
            //this.superGridControl1.PrimaryGrid.DataMember = "LISTA_OFERTAS_VENTA";
        }

   
        #endregion

        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void ManejoDescuentosUserControl_Load(object sender, EventArgs e)
        {
            this.dateTimeInput1.Value = new System.DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, 1, 0, 0, 1);
            this.dateTimeInput2.Value = new System.DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, DateTime.DaysInMonth(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year,  SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month) , 23, 59, 59);
            this.nombreTextBoxX.Focus();
            this.Buscar();
        }

        private void dateTimeInput2_ValueChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void dateTimeInput1_ValueChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void agregaProductoButtonItem_Click(object sender, EventArgs e)
        {

        }


    }
}
