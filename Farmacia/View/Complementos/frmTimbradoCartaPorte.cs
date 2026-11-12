using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Complementos
{
    public partial class frmTimbradoCartaPorte : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        string folio = string.Empty;
        int lote =0;
        public frmTimbradoCartaPorte(string pfolio,int  plote  )
        {
            InitializeComponent();
            folio = pfolio;
            lote = plote;
            getDistribuidores();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.No ==MessageBox.Show("Desea salir?",
                "informacion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (actualiza())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }
        private void getDistribuidores() {

            List<SIFModelo.Catalogo.CatDistribuidores>
                d = new List<SIFModelo.Catalogo.CatDistribuidores>();
            d = new SIFNegocio.Inventario.Traspasos().getdistribuidores("S");

            this.comboBoxExDistribuidor.DataSource = d;
            this.comboBoxExDistribuidor.DisplayMember = "Nombre_completo";
            
            List<SIFModelo.Catalogo.CatUnidadesDistribucion>
                ud = new List<SIFModelo.Catalogo.CatUnidadesDistribucion>();
            ud = new SIFNegocio.Inventario.Traspasos().get_unidadescDitribucion("S");

            this.comboBoxExUnidades.DataSource = ud;
            this.comboBoxExUnidades.DisplayMember = "Descripcion";

        }
        private bool actualiza() {

            return new SIFNegocio.Inventario.Traspasos().
                    actializaTraspasoDistribuidor
                    (
                        folio,
                        lote,
                        ((SIFModelo.Catalogo.CatDistribuidores)comboBoxExDistribuidor.SelectedValue).Usuarios_id,
                        ((SIFModelo.Catalogo.CatUnidadesDistribucion)comboBoxExUnidades.SelectedValue).Id
                    );
        }


    }
}
