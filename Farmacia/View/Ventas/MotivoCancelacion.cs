using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Ventas
{
    public partial class MotivoCancelacion : DevComponents.DotNetBar.Metro.MetroForm
    {
        public MotivoCancelacion()
        {
            InitializeComponent();
            this.cargaMotivos();
        }
       public SIFModelo.TipoDevolucion TipoDevolucion;
        private void cargaMotivos()
        {
            SIFNegocio.TipoDevolucions tipoN = new SIFNegocio.TipoDevolucions();
            BindingSource tipoBS = new BindingSource();
            tipoBS.DataSource = tipoN.Buscar("", "").DataSource;

            this.motivoCancelacionComboBoxEx.DataSource = tipoBS;
            motivoCancelacionComboBoxEx.DisplayMember = "Nombre";
            motivoCancelacionComboBoxEx.ValueMember = "TipoDevolucionID";
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            TipoDevolucion = motivoCancelacionComboBoxEx.SelectedItem as SIFModelo.TipoDevolucion;
            TipoDevolucion.Observaciones = this.textBoxX1.Text;
            //MessageBox.Show(Helpers.Sesion.Usuario.UsuariosID.ToString());
            //MessageBox.Show(this.);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;//L 11/12/2013 Para permitir devolver la remision completa
            this.Close();
        }

        private void cancelarButtonX_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No se generó ninguna devolución");
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
