using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar;

namespace SIF.View.Seguridad
{
    public partial class BitacoraUserControl : Templates.ListaUserControl
    {
        private int Cual = 0;
        public Boolean MostradoArt = false;
        SIFModelo.Inventarios.InventarioDataSet DsAjustes;
        public BitacoraUserControl()
        {
            InitializeComponent();
            superGridControl1.DataBindingComplete += SuperGridControl1DataBindingComplete;
            this.dateTimeInput1.Value = DateTime.Parse("01/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year.ToString());
            this.dateTimeInput2.Value = DateTime.Parse(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year.ToString());
           }


        void SuperGridControl1DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;

            if (panel.DataMember == "OPCIONES")
            {
                CustomizeDetailsPanel(panel);
            }
            if (panel.DataMember == "BITACORA")
            {
                panel.Columns["OPCION"].Visible = false;
                panel.Columns["OPCION_ID"].Visible = false;
            }
            if (panel.DataMember == "MODULOS")
            {
                panel.Columns["MODULO_ID"].Visible = false;
            }

        }
        private void CustomizeDetailsPanel(GridPanel panel)
        {
            panel.Columns["MODULO"].Visible = false;
            panel.Columns["OPCION_ID"].Visible = false;
        }

        public void AsignaUsuario(SIFModelo.Usuario usuario)
        {
            //this.current = ((ObjectView<SIFModelo.Sucursal>)bindingSource.Current).Object as SIFModelo.Sucursal;

            UsuarioTextBoxX.Text = usuario.UsuariosID.ToString();
            this.Buscar();

            //current.ResponsableID = usuario.UsuariosID;
            //current.ResponsableNombre = usuario.Nombre;
            //this.Modificar(current);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        public bool Mostrado { get; set; }

        public MainForm Owner { get; set; }

        public void Muestra()
        {
            if (Mostrado)
            {
                return;
            }
            Mostrado = true;
            this.Dock = DockStyle.Fill;
            this.ActivaComandos();
            Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }

        public void ActivaComandos()
        {

        }

        public void Back()
        {
            Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            //this.DesactivaComandos();
            //((this.Owner.ActivaComandos();
            Mostrado = false;
        }

        public void DesactivaComandos()
        {

        }

        private void SeleccionaArticulo(object sender, EventArgs e)
        {

            View.Catalogos.UsuarioUserControl frmUsuario = new Catalogos.UsuarioUserControl();

            MostradoArt = true;
            MainForm lanza;
            frmUsuario.Dock = DockStyle.Fill;
            //frmArticulo.Muestra();
            frmUsuario.Owner = this;
            frmUsuario.Muestra();
            this.DesactivaComandos();
        }

        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            UsuarioTextBoxX.Text = articulo.ARTICULO_ID;
        }
        SIFNegocio.Seguridad.Bitacora SeguridadDs= new SIFNegocio.Seguridad.Bitacora();
        public  void Buscar()
        {
            SeguridadDs.SeguridadDataSet.Clear();
            this.superGridControl1.PrimaryGrid.DataSource = SeguridadDs.Get(dateTimeInput1.Value.ToString("dd/MM/yyyy hh:mm:ss"), dateTimeInput2.Value.AddHours(24).ToString("dd/MM/yyyy hh:mm:ss"), SeguridadDs.SeguridadDataSet, UsuarioTextBoxX.Text);
            this.superGridControl1.PrimaryGrid.DataMember = "MODULOS";
        }

        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void PedidosAlmacenUserControl_Load(object sender, EventArgs e)
        {
            this.dateTimeInput1.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            this.dateTimeInput2.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

        }

       

        private void SeleccionaArticulo()
        {

        }

        
    }
}
