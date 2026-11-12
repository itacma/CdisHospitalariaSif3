using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Catalogos
{
    public partial class ArticuloMayoristasForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        private SIFModelo.Articulo articulo;

        public ArticuloMayoristasForm()
        {
            InitializeComponent();
        }

        public ArticuloMayoristasForm(SIFModelo.Articulo articulo)
            : this()
        {
            // TODO: Complete member initialization
            this.articulo = articulo;
            EstableceArticulo();
            cargaStatusProveedores();
            CargaProveedores();
            CargaInformacionMayorista();
        }

        private void EstableceArticulo()
        {
            this.codigoLabelX.Text = articulo.ARTICULO_ID;
            this.nombre1LabelX.Text = articulo.NOMBRE1;
            this.nombre2LabelX.Text = articulo.NOMBRE2;
        }

        private bool validaInformacionMayorista()
        {

            if (string.IsNullOrEmpty(descFinancieroNadroTextBoxX.Text))
            {
                descFinancieroNadroTextBoxX.Text = "0";
            }

            if (string.IsNullOrEmpty(descFinancieroDroguerosTextBoxX.Text))
            {
                descFinancieroDroguerosTextBoxX.Text = "0";
            }

            if (string.IsNullOrEmpty(descFinancieroSABATextBoxX.Text))
            {
                descFinancieroSABATextBoxX.Text = "0";
            }

            if (string.IsNullOrEmpty(descFinancieroMARZAMTextBoxX.Text))
            {
                descFinancieroMARZAMTextBoxX.Text = "0";
            }

            if (string.IsNullOrEmpty(descAdicionalNADROTextBoxX.Text))
            {
                descAdicionalNADROTextBoxX.Text = "0";
            }

            if (string.IsNullOrEmpty(descAdicionalDROGUEROStextBoxX.Text))
            {
                descAdicionalDROGUEROStextBoxX.Text = "0";
            }

            if (string.IsNullOrEmpty(descFinancieroSABATextBoxX.Text))
            {
                descFinancieroSABATextBoxX.Text = "0";
            }

            if (string.IsNullOrEmpty(descFinancieroMARZAMTextBoxX.Text))
            {
                descFinancieroMARZAMTextBoxX.Text = "0";
            }

            return true;
        }

        //guardar la informacion del mayorista
        private bool guardaInformacionMayorista()
        {

            SIFModelo.OrdenCompra.InfromacionMayorista mayorista = new SIFModelo.OrdenCompra.InfromacionMayorista();

            SIFNegocio.OrdenCompra.InformacionMayorista ofL = new SIFNegocio.OrdenCompra.InformacionMayorista();

            mayorista = ofL.InformacionMayoristaPorArticulo(articulo);

            if (mayorista == null)
            {
                mayorista = new SIFModelo.OrdenCompra.InfromacionMayorista();
            }

            if (!this.validaInformacionMayorista())
            {
                return false;
            }
            

            mayorista.ARTICULO_ID = articulo.ARTICULO_ID;
            //mayorista.PROVEEDOR_ID = proveedorComboBoxEx; //Cambio  para permitir que el cambio del usuario afecte la dba
            mayorista.CODIGO_NADRO = codigoNadroTextBoxX.Text;
            mayorista.CODIGO_DROGUEROS = CodigoDroguerosTextBoxX.Text;
            mayorista.CODIGO_SABA = codigoSABAtextBoxX.Text;
            mayorista.CODIGO_MARZAM = codigoMARZAMtextBoxX.Text;

            mayorista.DESCUENTO_NADRO = System.Convert.ToDecimal(descFinancieroNadroTextBoxX.Text);
            mayorista.DESCUENTO_DROGUEROS = System.Convert.ToDecimal(descFinancieroDroguerosTextBoxX.Text);
            mayorista.DESCUENTO_SABA = System.Convert.ToDecimal(descFinancieroSABATextBoxX.Text);
            mayorista.DESCUENTO_MARZAM = System.Convert.ToDecimal(descFinancieroMARZAMTextBoxX.Text);

            mayorista.DESCTO_ADICIONAL_NADRO = System.Convert.ToDecimal(descAdicionalNADROTextBoxX.Text);
            mayorista.DESCTO_ADICIONAL_DROGUEROS = System.Convert.ToDecimal(descAdicionalDROGUEROStextBoxX.Text);
            mayorista.DESCTO_ADICIONAL_SABA = System.Convert.ToDecimal(descAdicionalSABAtextBoxX.Text);
            mayorista.DESCTO_ADICIONAL_MARZAM = System.Convert.ToDecimal(descAdicionalMARZAMtextBoxX.Text);
            
            mayorista.EDO_COMPRA_NADRO = (SIFModelo.Tipos.TipoStatusMayorista)(Enum.Parse(typeof(SIFModelo.Tipos.TipoStatusMayorista), statusNadroComboBoxEx.SelectedValue.ToString()));
            mayorista.EDO_COMPRA_DROGUEROS = (SIFModelo.Tipos.TipoStatusMayorista)(Enum.Parse(typeof(SIFModelo.Tipos.TipoStatusMayorista), statusDroguerosComboBoxEx.SelectedValue.ToString()));
            mayorista.EDO_COMPRA_SABA = (SIFModelo.Tipos.TipoStatusMayorista)(Enum.Parse(typeof(SIFModelo.Tipos.TipoStatusMayorista), statusSabaComboBoxEx.SelectedValue.ToString()));
            mayorista.EDO_COMPRA_MARZAM = (SIFModelo.Tipos.TipoStatusMayorista)(Enum.Parse(typeof(SIFModelo.Tipos.TipoStatusMayorista), statusMARZAMComboBoxEx.SelectedValue.ToString()));

            //GUARDAR COMPRAR CON
            if (dateTimeInput1.Value != new DateTime() && dateTimeInput2.Value != new DateTime())
            {
                mayorista.PERIODO_COMPRA_INICIO = dateTimeInput1.Value;
                mayorista.PERIODO_COMPRA_FIN = dateTimeInput2.Value;

                SIFModelo.Cliente comprarCon = this.proveedorComboBoxEx.SelectedItem as SIFModelo.Cliente;

                if (comprarCon != null)
                {
                    mayorista.PROVEEDOR_ID = comprarCon.ID;
                }
            }
            else
            {
                mayorista.PERIODO_COMPRA_INICIO = null;
                mayorista.PERIODO_COMPRA_FIN = null;

                mayorista.PROVEEDOR_ID = 0;
            }

            ofL.GuardaInformacionMayorista(mayorista);

            bool? aplicadoA = null;
            if(this.articuloRadioButton.Checked)
            {
            aplicadoA = null;
            }
            if(this.proveedorRadioButton.Checked)
            {
            aplicadoA = false;
            }
            if(this.todoRadioButton.Checked)
            {
            aplicadoA = true;
            }



            ofL.actualizaEstadoMayorsita(mayorista, aplicadoA);
            return true;
        }

        private void CargaProveedores()
        {
            SIFNegocio.Clientes clientesL = new SIFNegocio.Clientes();
            List<SIFModelo.Cliente> clientes = clientesL.BuscarProveedoresMayoristas("", "");

            foreach (SIFModelo.Cliente cliente in clientes)
            {
                cliente.Nombre = cliente.ID + " - " + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
            }

            this.proveedorComboBoxEx.DataSource = clientes;
            proveedorComboBoxEx.DisplayMember = "Nombre";
            proveedorComboBoxEx.ValueMember = "ID";

            proveedorComboBoxEx.SelectedValue = articulo.LABORATORIO_ID;
        }

        Dictionary<SIFModelo.Tipos.TipoStatusMayorista, string> tiposMayorista;
        private void cargaStatusProveedores()
        {
            tiposMayorista = new Dictionary<SIFModelo.Tipos.TipoStatusMayorista, string>();

            List<SIFModelo.Tipos.TipoStatusMayorista> tipos = new List<SIFModelo.Tipos.TipoStatusMayorista>();
            SIFModelo.Tipos.TipoStatusMayorista agotado = SIFModelo.Tipos.TipoStatusMayorista.AGOTADO;
            SIFModelo.Tipos.TipoStatusMayorista codigo = SIFModelo.Tipos.TipoStatusMayorista.CODIGO;
            SIFModelo.Tipos.TipoStatusMayorista compra = SIFModelo.Tipos.TipoStatusMayorista.COMPRA;
            SIFModelo.Tipos.TipoStatusMayorista descontinuado = SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO;
            SIFModelo.Tipos.TipoStatusMayorista faltante = SIFModelo.Tipos.TipoStatusMayorista.FALTANTE;
            SIFModelo.Tipos.TipoStatusMayorista no_comprar = SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR;
            SIFModelo.Tipos.TipoStatusMayorista sin_existencia = SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA;
            SIFModelo.Tipos.TipoStatusMayorista transfer = SIFModelo.Tipos.TipoStatusMayorista.TRANSFER;

            tiposMayorista.Add(agotado, ((char)agotado).ToString() + " - " + agotado.ToString());
            tiposMayorista.Add(codigo, ((char)codigo).ToString() + " - " + codigo.ToString());
            tiposMayorista.Add(compra, ((char)compra).ToString() + " - " + compra.ToString());
            tiposMayorista.Add(descontinuado, ((char)descontinuado).ToString() + " - " + descontinuado.ToString());
            tiposMayorista.Add(faltante, ((char)faltante).ToString() + " - " + faltante.ToString());
            tiposMayorista.Add(no_comprar, ((char)no_comprar).ToString() + " - " + no_comprar.ToString());
            tiposMayorista.Add(sin_existencia, ((char)sin_existencia).ToString() + " - " + sin_existencia.ToString());
            tiposMayorista.Add(transfer, ((char)transfer).ToString() + " - " + transfer.ToString());

            BindingSource nadroBS = new BindingSource();
            nadroBS.DataSource = tiposMayorista;

            statusNadroComboBoxEx.DataSource = nadroBS;
            statusNadroComboBoxEx.DisplayMember = "Value";
            statusNadroComboBoxEx.ValueMember = "Key";

            BindingSource droguerosBS = new BindingSource();
            droguerosBS.DataSource = tiposMayorista;

            statusDroguerosComboBoxEx.DataSource = droguerosBS;
            statusDroguerosComboBoxEx.DisplayMember = "Value";
            statusDroguerosComboBoxEx.ValueMember = "Key";

            BindingSource sabaBS = new BindingSource();
            sabaBS.DataSource = tiposMayorista;

            statusSabaComboBoxEx.DataSource = sabaBS;
            statusSabaComboBoxEx.DisplayMember = "Value";
            statusSabaComboBoxEx.ValueMember = "Key";

            BindingSource marzamBS = new BindingSource();
            marzamBS.DataSource = tiposMayorista;

            statusMARZAMComboBoxEx.DataSource = marzamBS;
            statusMARZAMComboBoxEx.DisplayMember = "Value";
            statusMARZAMComboBoxEx.ValueMember = "Key";

        }

        private void CargaInformacionMayorista()
        {
            SIFNegocio.OrdenCompra.InformacionMayorista imL = new SIFNegocio.OrdenCompra.InformacionMayorista();
            SIFModelo.OrdenCompra.InfromacionMayorista mayorista = imL.InformacionMayoristaPorArticulo(articulo);

            if (mayorista == null)
            {
                return;
            }

            codigoNadroTextBoxX.Text = mayorista.CODIGO_NADRO;
            codigoSABAtextBoxX.Text = mayorista.CODIGO_SABA;
            CodigoDroguerosTextBoxX.Text = mayorista.CODIGO_DROGUEROS;
            codigoMARZAMtextBoxX.Text = mayorista.CODIGO_MARZAM;

            descFinancieroNadroTextBoxX.Text = mayorista.DESCUENTO_NADRO.ToString();
            descFinancieroDroguerosTextBoxX.Text = mayorista.DESCUENTO_DROGUEROS.ToString();
            descFinancieroSABATextBoxX.Text = mayorista.DESCUENTO_SABA.ToString();
            descFinancieroMARZAMTextBoxX.Text = mayorista.DESCUENTO_MARZAM.ToString();

            descAdicionalNADROTextBoxX.Text = mayorista.DESCTO_ADICIONAL_NADRO.ToString();
            descAdicionalDROGUEROStextBoxX.Text = mayorista.DESCTO_ADICIONAL_DROGUEROS.ToString();
            descAdicionalSABAtextBoxX.Text = mayorista.DESCTO_ADICIONAL_SABA.ToString();
            descAdicionalMARZAMtextBoxX.Text = mayorista.DESCTO_ADICIONAL_MARZAM.ToString();

            var stNadro = from t in tiposMayorista where t.Key == mayorista.EDO_COMPRA_NADRO select t;
            var stDrogueros = from t in tiposMayorista where t.Key == mayorista.EDO_COMPRA_DROGUEROS select t;
            var stSaba = from t in tiposMayorista where t.Key == mayorista.EDO_COMPRA_SABA select t;
            var stMarzam = from t in tiposMayorista where t.Key == mayorista.EDO_COMPRA_MARZAM select t;

            statusNadroComboBoxEx.SelectedItem = stNadro.FirstOrDefault();
            statusDroguerosComboBoxEx.SelectedItem = stDrogueros.FirstOrDefault();
            statusSabaComboBoxEx.SelectedItem = stSaba.FirstOrDefault();
            statusMARZAMComboBoxEx.SelectedItem = stMarzam.FirstOrDefault();


            if (mayorista.PERIODO_COMPRA_INICIO != null && mayorista.PERIODO_COMPRA_FIN != null)
            {
                dateTimeInput1.Value = mayorista.PERIODO_COMPRA_INICIO.Value;
                dateTimeInput2.Value = mayorista.PERIODO_COMPRA_FIN.Value;

                proveedorComboBoxEx.SelectedValue = mayorista.PROVEEDOR_ID;
            }
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (this.guardaInformacionMayorista())
            {

               MessageBox.Show("Se ha guardado la información de mayoristas");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

    }
}
