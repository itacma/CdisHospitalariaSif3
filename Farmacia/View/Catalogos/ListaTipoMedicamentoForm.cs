using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Catalogos
{
    public partial class ListaTipoMedicamentoForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public static string clavesat ;
        public ListaTipoMedicamentoForm(SIFModelo.Articulo articulo)
        {
            this.articulo = articulo;
            InitializeComponent();
            this.cargalista();
            this.iniciaClavesatTextBox();//JMQC 07/11/2017: Cambios Sat 
            clavesat = string.Empty;
        }


        private const char divisor = '|';
        SIFModelo.Articulo articulo;

        private string listaTipoMedicamento;
        public string ListaTipoMedicamento
        {
            get { return listaTipoMedicamento; }
        }

        Dictionary<string, SIFModelo.TipoMedicamento> diccionarioTipoMedicamento;
        private void cargalista()
        {
            diccionarioTipoMedicamento = new Dictionary<string, SIFModelo.TipoMedicamento>();
            List<string> lista = new List<string>(articulo.TIPO_MEDICAMENTO_CVE.Split(divisor));

            foreach (SIFModelo.TipoMedicamento tipo in new SIFNegocio.TipoMedicamento().Buscar("", "").DataSource)
            {
                diccionarioTipoMedicamento.Add(tipo.Clave + "-" + tipo.Nombre, tipo);

                if (lista.Contains(tipo.Clave.ToString()))
                {
                    listaTipoMedicamentoCheckedListBox.Items.Add(tipo.Clave + "-" + tipo.Nombre , true);
                }
                else
                {
                    listaTipoMedicamentoCheckedListBox.Items.Add(tipo.Clave +"-" + tipo.Nombre, false);
                }
            }
        }

        private void creaLista()
        {
            foreach (var item in listaTipoMedicamentoCheckedListBox.CheckedItems)
            {
                SIFModelo.TipoMedicamento tipo = diccionarioTipoMedicamento[item.ToString()];
                listaTipoMedicamento += tipo.Clave+ divisor.ToString();
            }

            if (listaTipoMedicamento.Contains("T3") && !listaTipoMedicamento.Contains("F1"))
            {
                listaTipoMedicamento += "F1|";
            }
            if (cfdi33 > 0)                           //JMQC 07/11/2017: Cambios Sat 
            listaTipoMedicamento += "ST"+claveSatTextBoxX.Text + divisor.ToString();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (!this.buscarClaveSat())            //JMQC 07/11/2017: Cambios Sat 
            return;
            clavesat = claveSatTextBoxX.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.creaLista();
            this.Close();
        }
        #region  JMQC 07/11/2017: Cambios Sat
        SIFModelo.CatClavesSat Msni = new SIFModelo.CatClavesSat();
        SIFNegocio.Impuestos sni = new SIFNegocio.Impuestos();
        SIFNegocio.Extras.Parametros param = new SIFNegocio.Extras.Parametros();
        int cfdi33 = 0;

        private Boolean buscarClaveSat() {
          cfdi33 = param.ObtenParametro("CFDI3.3");
        //cfdi33 = 1;
            if (claveSatTextBoxX.Text.Length < 8 && cfdi33>0)
                {
            MessageBox.Show("La calve sat debe de ser minimo de 8 digitos ", "Clave Sat" + Msni.clave, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
            }
            Msni = sni.buscarClaveSat(claveSatTextBoxX.Text);
            if (!String.IsNullOrEmpty(Msni.clave))
                return true;
            else
                {
                if (cfdi33 <= 0) {
                return true;
                    }
                MessageBox.Show("No existe la clave dentro del catalogo Sat ", "Clave Sat" + Msni.clave, MessageBoxButtons.OK, MessageBoxIcon.Warning );
                return false;
                }
            }

         private void claveSatTextBoxX_KeyDown(object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter)
                {
                if (!this.buscarClaveSat())
                    {                    
                    return;
                    }
                else
                    {
                    MessageBox.Show(Msni.clave + "-" + Msni.Descripcion, "Clave Sat", MessageBoxButtons.OK, MessageBoxIcon.Information);                  
                    }
                }
            }

        private void iniciaClavesatTextBox()
            {
            SIFNegocio.Extras.Parametros param = new SIFNegocio.Extras.Parametros();
            //Cfdi33 = param.ObtenParametro("CFDI3.3");

            claveSatTextBoxX.ButtonCustom.Visible = true;
            claveSatTextBoxX.ButtonCustomClick += claveSatTextBoxXColumn_ButtonCustom_CLICK;

            }


        void claveSatTextBoxXColumn_ButtonCustom_CLICK(object sender, EventArgs e)
            {

            System.Diagnostics.Process.Start("http://200.57.3.46:443/PyS/catPyS.aspx");
            }
        #endregion
    }
}