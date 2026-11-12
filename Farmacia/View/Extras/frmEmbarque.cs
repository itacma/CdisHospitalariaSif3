using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Extras
{
    public partial class frmEmbarque : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        SIFNegocio.Inventario.Traspasos t = new SIFNegocio.Inventario.Traspasos();
        SIFNegocio.Usuarios user = new SIFNegocio.Usuarios();
        SIFModelo.BitEmbarque ModelEmbarque = new SIFModelo.BitEmbarque();
        BindingList<SIFModelo.Catalogo.CatDistribuidores> bsDistribuidores = new BindingList<SIFModelo.Catalogo.CatDistribuidores>();
        BindingList<SIFModelo.Catalogo.CatUnidadesDistribucion> bsUnidadesDistribuidores = new BindingList<SIFModelo.Catalogo.CatUnidadesDistribucion>();

        public frmEmbarque(SIFModelo.BitEmbarque _embarque)
        {
            ModelEmbarque = _embarque;
            InitializeComponent();
            load();
        }
        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        private void load()
            {
            
            bsDistribuidores = new BindingList<SIFModelo.Catalogo.CatDistribuidores>( new SIFNegocio.Inventario.Traspasos().getdistribuidores("S"));
            if (bsDistribuidores.Count > 0)
            {
                this.DistribuidorComboBoxEx.DataSource = bsDistribuidores;
                DistribuidorComboBoxEx.DisplayMember = "Nombre_completo";
                DistribuidorComboBoxEx.ValueMember = "Usuarios_id";

                DistribuidorComboBoxEx.SelectedIndex = DistribuidorComboBoxEx.Items.Count - 1;
            }
            else {
               MessageBox.Show("No se encontraron distribuidores activos valide que en el catalogo de usuarios existe un distribuidor ", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }

            //List<SIFModelo.Catalogo.CatUnidadesDistribucion>
            //ud = new List<SIFModelo.Catalogo.CatUnidadesDistribucion>();

            bsUnidadesDistribuidores = new BindingList<SIFModelo.Catalogo.CatUnidadesDistribucion>(new SIFNegocio.Inventario.Traspasos().get_unidadescDitribucion("S"));

           // this.comboBoxExUnidades.DataSource = bsUnidadesDistribuidores;
           // this.comboBoxExUnidades.DisplayMember = "Descripcion";

            if (bsUnidadesDistribuidores.Count > 0)
            {
                this.comboBoxExUnidades.DataSource = bsUnidadesDistribuidores;
                comboBoxExUnidades.DisplayMember = "Descripcion";
                comboBoxExUnidades.ValueMember = "Id";

                comboBoxExUnidades.SelectedIndex = comboBoxExUnidades.Items.Count - 1;
            }
            else
            {
               MessageBox.Show("No se encontraron unidades de distribucion activos  ", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }


        }
        private void aceptarButtonX_Click(object sender, EventArgs e)
        {


            if (!aceptar())
            {
                return;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }

        private bool aceptar() {



            SIFModelo.Catalogo.CatDistribuidores _user = DistribuidorComboBoxEx.SelectedItem as SIFModelo.Catalogo.CatDistribuidores;
            SIFModelo.Catalogo.CatUnidadesDistribucion unidades = comboBoxExUnidades.SelectedItem as SIFModelo.Catalogo.CatUnidadesDistribucion;
            ModelEmbarque.distribuidor_id       = Int16.Parse(_user.Usuarios_id.ToString());
            ModelEmbarque.caja_grande           = Int16.Parse(nupdCajasGrandes.Value.ToString());
            ModelEmbarque.caja_chica            = Int16.Parse(nupdCajasChicas.Value.ToString());
            ModelEmbarque.bulto                 = Int16.Parse(nupdBultos.Value.ToString());
            ModelEmbarque.bolsa                 = Int16.Parse(nupdBolsas.Value.ToString());
            ModelEmbarque.temperatura           = Int16.Parse(nupdTemperatura.Value.ToString());
            ModelEmbarque.factura_controlados   = Int16.Parse(nupdFacturaControlados.Value.ToString());
            ModelEmbarque.IdUnidadDistribucion = unidades.Id;
            ModelEmbarque.observaciones =" ";
            ModelEmbarque.activo = "A";
            ModelEmbarque.refrigerados = Int16.Parse(nupdRefrigerados.Value.ToString());
            


            if (

            (Int16.Parse(nupdCajasGrandes.Value.ToString()) +
            Int16.Parse(nupdCajasChicas.Value.ToString()) +
            Int16.Parse(nupdBultos.Value.ToString()) +
            Int16.Parse(nupdBolsas.Value.ToString())
             ) <= 0
                )
            {
               MessageBox.Show("Tiene que ingresar almenos una caja, bulto o bolsa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                if (t.ResgistraEmbarque(ModelEmbarque) > 0)
                {
                    return true;
                    
                }
                else
                {

                    if (DialogResult.Yes ==MessageBox.Show("No se registro el embarque desea continuar?" + Environment.NewLine + "Presione no para reintentar", "Espera",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    {
                        return true;
                    }
                    else 
                    {

                        return false;
                    }
                    
                }
            }

            

    }


        private void DistribuidorComboBoxEx_SelectedValueChanged(object sender, EventArgs e)
        {
           

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
