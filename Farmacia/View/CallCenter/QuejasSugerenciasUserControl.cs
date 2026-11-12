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

namespace SIF.View.CallCenter
{
    public partial class QuejasSugerenciasUserControl : Templates.CatalogoUserControl
    {
        public QuejasSugerenciasUserControl()
        {
            InitializeComponent();
            this.superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            this.CargaSucursales();
            this.dateTimeInput1.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            dateTimeInput2.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            Privilegios();
        }
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 27, int.Parse(Xbtn.Tag.ToString()));
            }

        }
        public void Nuevo()
        {
            View.CallCenter.QuejaSugerenciaUserControl qs = new QuejaSugerenciaUserControl(usuario, null);
            qs.Owner = this;
            qs.Mostrar();
        }

        private void CargaSucursales()
        {
            BindingList<SIFModelo.Sucursal> sucursales = new BindingList<SIFModelo.Sucursal>();
            SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal() { Nombre = "[TODAS]", SucursalesID = 0 };
            sucursales.Add(sucursal);
            //sucursales.ToList();d
            List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().Buscar("", "").DataSource as List<SIFModelo.Sucursal>;

            foreach (SIFModelo.Sucursal sucursalBd in sucursalesBD)
            {
                sucursales.Add(sucursalBd);
            }



            this.sucursalComboBoxEx.DataSource = sucursales;
            sucursalComboBoxEx.DisplayMember = "NOMBRE";
            sucursalComboBoxEx.ValueMember = "SUCURSALESID";
        }

        public void Modificar()
        {
            if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
                return;
            }

            SIFModelo.CallCenter.CallCenterDataSet.QUEJA_SUGERENCIARow rowQs = ((SIFModelo.CallCenter.CallCenterDataSet.QUEJA_SUGERENCIARow)((DataRowView)((GridRow)(this.superGridControl1.PrimaryGrid.ActiveRow)).DataItem).Row);
            View.CallCenter.QuejaSugerenciaUserControl qs = new QuejaSugerenciaUserControl(usuario, rowQs);
            qs.Owner = this;
            qs.Mostrar();
        }

        private void NuevoButtonItem_Click(object sender, EventArgs e)
        {
            this.Nuevo();
        }

        public Menu.CatMenu Owner;

        public void Back()
        {
            try
            {
                this.DesactivaComandos();
                Owner.ActivaComandos();
                if (Owner.Owner.Contains(this))
                {
                    Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }
                this.Mostrado = false;
            }
            catch { }
        }

        public void DesactivaComandos()
        {
            this.backButton.Shortcuts.Clear();
            this.NuevoButtonItem.Shortcuts.Clear();
            //this.elimninarButtonItem.Shortcuts.Clear();
        }

        SIFModelo.Usuario usuario;
        public void Muestra()
        {
            View.Ventas.AccesoUsuarioForm frmAcceso = new View.Ventas.AccesoUsuarioForm();

            if (frmAcceso.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            usuario = frmAcceso.Usuario;

            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;

            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }

        public void ActivaComandos()
        {
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.NuevoButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
            // this.elimninarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
        }

        public bool Mostrado { get; set; }

        #region Funciones y Metodos

        SIFNegocio.CallCenter.QuejasSugerencias Negocio = new SIFNegocio.CallCenter.QuejasSugerencias();
        private void Buscar()
        {
            DateTime fecha1 = dateTimeInput1.Value;
            DateTime fecha2 = dateTimeInput2.Value;
            string sucursal = this.sucursalComboBoxEx.Text == "[TODAS]" ? "%" : this.sucursalComboBoxEx.Text;


            this.superGridControl1.PrimaryGrid.DataSource = this.Negocio.BuscaQuejaSugerencia(fecha1, fecha2, sucursal).QUEJA_SUGERENCIA;

        }

        #endregion

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void modificarButtonItem_Click(object sender, EventArgs e)
        {
            this.Modificar();
        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }
        }

        private void superGridControl1_DoubleClick(object sender, EventArgs e)
        {
            this.Modificar();
        }


    }
}
