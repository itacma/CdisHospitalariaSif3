using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Catalogos
{
    public partial class ListaPromocionNewConfForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ListaPromocionNewConfForm()
        {
            InitializeComponent();
        }



        private const char divisor = '|';
        SIFModelo.Articulo articulo;

        private string listaSucursales;
        public string ListaSucursales
        {
            get { return listaSucursales; }
        }

        Dictionary<string, SIFModelo.Sucursal> diccionarioSucursal;
        private SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow current;
        private void cargalista()
        {
            diccionarioSucursal = new Dictionary<string, SIFModelo.Sucursal>();
            List<string> lista = new List<string>();

            if (articulo != null)
            {
                lista = new List<string>(articulo.LISTA_SUCURSAL_VTA.Split(divisor));
            }

            if (current != null)
            {
                lista = new List<string>(current.LISTA_SUCURSAL_ID.Split(divisor));
            }


            foreach (SIFModelo.Sucursal suc in new SIFNegocio.Sucursales().Buscar("", "").DataSource)
            {
                diccionarioSucursal.Add(suc.Nombre, suc);

                if (lista.Contains(suc.SucursalesID.ToString()))
                {
                    listaSucursalesCheckedListBox.Items.Add(suc.Nombre, true);
                }
                else
                {
                    listaSucursalesCheckedListBox.Items.Add(suc.Nombre, false);
                }
            }
        }

        private void creaLista()
        {
            foreach (var item in listaSucursalesCheckedListBox.CheckedItems)
            {
                SIFModelo.Sucursal suc = diccionarioSucursal[item.ToString()];
                listaSucursales += suc.SucursalesID + divisor.ToString();
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.creaLista();
            this.Close();
        }
    }
}
