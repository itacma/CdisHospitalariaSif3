using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;

namespace SIF.View.Articulos
{
    public partial class TransferMayoristasForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public TransferMayoristasForm(SIFModelo.Articulo articulo = null)
        {
            InitializeComponent();
            this.articulo = articulo;
            this.dataGridViewX1.AutoGenerateColumns = false;
            this.ActivaBotones();            
            this.CargaLaboratorios();
            EstableceArticulos();
        }

        SIFModelo.Articulo articulo = null;

        private void EstableceArticulos()
        {
            SIFNegocio.OrdenCompra.InformacionMayorista imL = new SIFNegocio.OrdenCompra.InformacionMayorista();
            SIFModelo.OrdenCompra.InfromacionMayorista mayorista = imL.InformacionMayoristaPorArticulo(articulo);

            if (mayorista == null)
            {
                return;
            }


            if (mayorista.PERIODO_COMPRA_INICIO != null && mayorista.PERIODO_COMPRA_FIN != null)
            {
                dateTimeInput1.Value = mayorista.PERIODO_COMPRA_INICIO.Value;
                dateTimeInput2.Value = mayorista.PERIODO_COMPRA_FIN.Value;

                proveedorComboBoxEx.SelectedValue = mayorista.PROVEEDOR_ID;
            }
        }

        private void CargaLaboratorios()
        {
            SIFNegocio.Clientes clientesL = new SIFNegocio.Clientes();

            if (SIFNegocio.Clientes.LaboratoriosList.Count == 0)
            {
                SIFNegocio.Clientes.LaboratoriosList = clientesL.Laboratorios("");

                List<SIFModelo.Cliente> clientes = SIFNegocio.Clientes.LaboratoriosList;

                foreach (SIFModelo.Cliente cliente in clientes)
                {
                    cliente.Nombre = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno + " - " + cliente.ID;
                }
            }

            this.fabricanteComboBoxEx.DataSource = SIFNegocio.Clientes.LaboratoriosList;
            fabricanteComboBoxEx.DisplayMember = "Nombre";
            fabricanteComboBoxEx.ValueMember = "ID";

            if (articulo != null)
            {
                fabricanteComboBoxEx.SelectedValue = articulo.LABORATORIO_ID;
            }
            this.cargaClienteMayorista();
            //PROVEEDORES
            if (SIFNegocio.Clientes.ProveedoresList.Count == 0)
            {
                SIFNegocio.Clientes.ProveedoresList = clientesL.BuscarProveedoresMayoristas("", "");

                foreach (SIFModelo.Cliente cliente in SIFNegocio.Clientes.ProveedoresList)
                {
                    cliente.Nombre = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno + " - " + cliente.ID;
                }
            }

            this.proveedorComboBoxEx.DataSource = SIFNegocio.Clientes.ProveedoresList;
            proveedorComboBoxEx.DisplayMember = "Nombre";
            proveedorComboBoxEx.ValueMember = "ID";

            if (articulo != null)
            {
                proveedorComboBoxEx.SelectedValue = articulo.PROVEEDOR_ID;
            }
        }

        private bool isLoaded = false;
        SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
        private void CargaArticulos()
        {
            if (this.isLoaded && rBtnFabricante.Checked == true)
            //if (this.isLoaded)
            {
                string laboratorio = this.fabricanteComboBoxEx.SelectedValue.ToString();
                var articulos = articuloL.Buscar("LABORATORIO_ID", laboratorio);

                this.dataGridViewX1.DataSource = articulos;
                this.todosCheckBoxX.Checked = true;
            }
        }

        private bool guardaTransfer()
        {
            if (!this.valida())
                return false;
            /*

            if (this.dateTimeInput1.Value == new DateTime())
            {
               MessageBox.Show("Debe elegir la fecha de inicio");
                this.dateTimeInput1.Focus();
                return false;
            }
            if (this.dateTimeInput2.Value == new DateTime())
            {
               MessageBox.Show("Debe elegir la fecha final");
                this.dateTimeInput2.Focus();
                return false;
            }

            if (this.dateTimeInput1.Value > dateTimeInput2.Value)
            {
               MessageBox.Show("La fecha final no puede ser mayor a la fecha inicial");
                this.dateTimeInput1.Focus();
                return false;
            }

            int seleccionados = 0;
            foreach (DataGridViewRow row in this.dataGridViewX1.Rows)
            {
                SIFModelo.Articulo articulo = ((Equin.ApplicationFramework.ObjectView<SIFModelo.Articulo>)row.DataBoundItem).Object as SIFModelo.Articulo;
                if ((bool)((DataGridViewCheckBoxXCell)row.Cells["SeleccionadoColumn"]).Value == false)
                {
                    continue;
                }
                seleccionados++;
            }



            if (seleccionados == 0)
            {
               MessageBox.Show("Debe seleccionar al menos un artículo");
                return false;
            }
            */
            int seleccionados = 0;
            foreach (DataGridViewRow row in this.dataGridViewX1.Rows)
            {
                SIFModelo.Articulo articulo = ((Equin.ApplicationFramework.ObjectView<SIFModelo.Articulo>)row.DataBoundItem).Object as SIFModelo.Articulo;
                if ((bool)((DataGridViewCheckBoxXCell)row.Cells["SeleccionadoColumn"]).Value == false)
                {
                    continue;
                }
                seleccionados++;
            }
            if (seleccionados == 0)
            {
               MessageBox.Show("Debe seleccionar al menos un artículo");
                return false;
            }
            foreach (DataGridViewRow row in this.dataGridViewX1.Rows)
            {

                SIFModelo.Articulo articulo = ((Equin.ApplicationFramework.ObjectView<SIFModelo.Articulo>)row.DataBoundItem).Object as SIFModelo.Articulo;
                if ((bool)((DataGridViewCheckBoxXCell)row.Cells["SeleccionadoColumn"]).Value == false)
                {
                    continue;
                }

                SIFModelo.OrdenCompra.InfromacionMayorista mayorista = new SIFModelo.OrdenCompra.InfromacionMayorista();
                SIFNegocio.OrdenCompra.InformacionMayorista ofL = new SIFNegocio.OrdenCompra.InformacionMayorista();

                mayorista = ofL.InformacionMayoristaPorArticulo(articulo);

                if (mayorista == null)
                {
                    mayorista = new SIFModelo.OrdenCompra.InfromacionMayorista();

                    mayorista.ARTICULO_ID = articulo.ARTICULO_ID;
                    mayorista.PROVEEDOR_ID = 0;
                    mayorista.CODIGO_NADRO = " ";
                    mayorista.CODIGO_DROGUEROS = " ";
                    mayorista.CODIGO_SABA = " ";

                    mayorista.DESCUENTO_NADRO = 0;
                    mayorista.DESCUENTO_DROGUEROS = 0;
                    mayorista.DESCUENTO_SABA = 0;

                    mayorista.DESCTO_ADICIONAL_NADRO = 0;
                    mayorista.DESCTO_ADICIONAL_DROGUEROS = 0;
                    mayorista.DESCTO_ADICIONAL_SABA = 0;

                    mayorista.EDO_COMPRA_NADRO = SIFModelo.Tipos.TipoStatusMayorista.TRANSFER;
                    mayorista.EDO_COMPRA_DROGUEROS = SIFModelo.Tipos.TipoStatusMayorista.TRANSFER;
                    mayorista.EDO_COMPRA_SABA = SIFModelo.Tipos.TipoStatusMayorista.TRANSFER;

                    mayorista.COMPRA_CON_MAYORISTA = SIFModelo.Tipos.ComprarConMayorista.MAYORISTA;
                }

                if (this.bloqueadoCheckBoxX.Checked)
                {
                    mayorista.Bloqueado = SIFModelo.Tipos.SiNo.SI;
                }
                else
                {
                    mayorista.Bloqueado = SIFModelo.Tipos.SiNo.NO;
                }


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


                //if (
                ofL.GuardaInformacionMayorista(mayorista);
                //{

                //}
            }
           MessageBox.Show("Se ha guardado la información de transfer");
            return true;
        }


        private void TransferMayoristasForm_Load(object sender, EventArgs e)
        {
            isLoaded = true;
            this.CargaArticulos();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (this.guardaTransfer())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void fabricanteComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargaArticulos();
            todosCheckBoxX.Checked = false;
        }
        private void todosCheckBoxX_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridViewX1.Rows)
            {
                ((DataGridViewCheckBoxXCell)row.Cells["SeleccionadoColumn"]).Value = todosCheckBoxX.Checked;
            }
        }

        private void fabricanteComboBoxEx_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                if (fabricanteComboBoxEx.Text.IsInteger())
                {
                    int fabricanteID = int.Parse(fabricanteComboBoxEx.Text);

                    List<SIFModelo.Cliente> lista = fabricanteComboBoxEx.DataSource as List<SIFModelo.Cliente>;

                    var encontrado = from l in lista where l.ID == fabricanteID select l;

                    if (encontrado.Count() > 0)
                    {
                        this.fabricanteComboBoxEx.SelectedItem = encontrado.First<SIFModelo.Cliente>();
                    }
                }
            }
        }

        private void proveedorComboBoxEx_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                if (proveedorComboBoxEx.Text.IsInteger())
                {
                    int fabricanteID = int.Parse(proveedorComboBoxEx.Text);

                    List<SIFModelo.Cliente> lista = proveedorComboBoxEx.DataSource as List<SIFModelo.Cliente>;

                    var encontrado = from l in lista where l.ID == fabricanteID select l;

                    if (encontrado.Count() > 0)
                    {
                        this.proveedorComboBoxEx.SelectedItem = encontrado.First<SIFModelo.Cliente>();
                    }
                }
            }
        
        }

        #region  Asociar articulo a  Mayorista 
        /*
         * JOMAQC 26/09/2018
         Esta region nace con el propocito de que una seria de articulos ya se a por laboratorio o por codigo se asocie a un proveedor mayorista para su compra
         */
        
        private void MayoristaComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargaArticulosMayorista();
           todosCheckBoxX.Checked = false;
        }


        private void MayoristaComboBoxEx_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                if (MayoristaComboBoxEx.Text.IsInteger())
                {
                    int fabricanteID = int.Parse(MayoristaComboBoxEx.Text);

                    List<SIFModelo.Cliente> lista = MayoristaComboBoxEx.DataSource as List<SIFModelo.Cliente>;

                    var encontrado = from l in lista where l.ID == fabricanteID select l;

                    if (encontrado.Count() > 0)
                    {
                        this.MayoristaComboBoxEx.SelectedItem = encontrado.First<SIFModelo.Cliente>();
                    }
                }
            }
        }

        private void cargaClienteMayorista() {

            SIFNegocio.Clientes clientesM = new SIFNegocio.Clientes();

            if (SIFNegocio.Clientes.MayoristasList.Count == 0)
            {
                SIFNegocio.Clientes.MayoristasList = clientesM.clientesMayoristas("");

                List<SIFModelo.Cliente> clientes = SIFNegocio.Clientes.MayoristasList;

                foreach (SIFModelo.Cliente cliente in clientes)
                {
                    cliente.Nombre = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno + " - " + cliente.ID;
                }
            }

            this.MayoristaComboBoxEx.DataSource = SIFNegocio.Clientes.MayoristasList;
            MayoristaComboBoxEx.DisplayMember = "Nombre";
            MayoristaComboBoxEx.ValueMember = "ID";


        }


        private void CargaArticulosMayorista()
        {
                if (this.isLoaded && rBtnMayorista.Checked == true)
                {
                    string clienteMayorista = this.MayoristaComboBoxEx.SelectedValue.ToString();
                    var articulos = articuloL.BuscarFcM("", clienteMayorista);
                    this.dataGridViewX1.DataSource = articulos;
                    this.todosCheckBoxX.Checked = true;
                }
            
        }


        #endregion

        private void rBtnFabricante_CheckedChanged(object sender, EventArgs e)
        {
            this.fabricanteComboBoxEx.Enabled = rBtnFabricante.Checked;
            if (rBtnFabricante.Checked == true) {
                this.MayoristaComboBoxEx.Enabled = true;
            }
        }

        private void rBtnProveedor_CheckedChanged(object sender, EventArgs e)
        {
            this.proveedorComboBoxEx.Enabled = rBtnProveedor.Checked;
        }

        private void rBtnMayorista_CheckedChanged(object sender, EventArgs e)
        {
            this.MayoristaComboBoxEx.Enabled = rBtnMayorista.Checked;
        }

        private void ActivaBotones() {
            this.rBtnFabricante.Checked = true;
            this.proveedorComboBoxEx.Enabled = false;
            this.MayoristaComboBoxEx.Enabled = true;

        }

        private bool guardaMayorista()
        {
            if (
            MessageBox.Show("Esta seguro de que desea agregar los productos al mayorista:" + this.MayoristaComboBoxEx.SelectedValue.ToString()
                , "Infromacion ", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel) {
                return false;
            }
            Boolean huboError = false;

            if (!this.valida())
                return false;

            int seleccionados = 0;
            foreach (DataGridViewRow row in this.dataGridViewX1.Rows)
            {
                SIFModelo.Articulo articulo = ((Equin.ApplicationFramework.ObjectView<SIFModelo.Articulo>)row.DataBoundItem).Object as SIFModelo.Articulo;
                if ((bool)((DataGridViewCheckBoxXCell)row.Cells["SeleccionadoColumn"]).Value == false)
                {
                    continue;
                }
                seleccionados++;
            }
            if (seleccionados == 0)
            {
               MessageBox.Show("Debe seleccionar al menos un artículo");
                return false;
            }



            foreach (DataGridViewRow row in this.dataGridViewX1.Rows)
            {

                SIFModelo.Articulo articulo = ((Equin.ApplicationFramework.ObjectView<SIFModelo.Articulo>)row.DataBoundItem).Object as SIFModelo.Articulo;
                if ((bool)((DataGridViewCheckBoxXCell)row.Cells["SeleccionadoColumn"]).Value == false)
                {
                    continue;
                }

                SIFModelo.OrdenCompra.InfromacionMayorista mayorista = new SIFModelo.OrdenCompra.InfromacionMayorista();
                 SIFNegocio.OrdenCompra.InformacionMayorista ofL = new SIFNegocio.OrdenCompra.InformacionMayorista();
                
                mayorista = new SIFModelo.OrdenCompra.InfromacionMayorista();

                mayorista.ARTICULO_ID = articulo.ARTICULO_ID;
                mayorista.PROVEEDOR_ID = Convert.ToInt32(this.MayoristaComboBoxEx.SelectedValue.ToString());
                mayorista.PEDIR = SIFModelo.Tipos.SiNo.SI;

                mayorista.COMPRA_CON_MAYORISTA = SIFModelo.Tipos.ComprarConMayorista.MAYORISTA;
                mayorista.EDO_COMPRA = SIFModelo.Tipos.TipoStatusMayorista.COMPRA;
                mayorista.PERIODO_COMPRA_INICIO = dateTimeInput1.Value;
                mayorista.PERIODO_COMPRA_FIN = dateTimeInput2.Value;
               

                string respuesta =ofL.GuardarInfClientMayorista(mayorista);
                if (respuesta.Contains("-1: ERROR")) {
                    huboError = true;
                    MessageBox.Show(respuesta);
                }
       
            }
            if(!huboError)
           MessageBox.Show("Se Asocio el (los) producto(s) al mayorista");
            return true;
        }

        private void MayoristaButtonX_Click(object sender, EventArgs e)
        {
            if (this.guardaMayorista())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }


        private bool valida() {

            if (this.dateTimeInput1.Value == new DateTime())
            {
               MessageBox.Show("Debe elegir la fecha de inicio");
                this.dateTimeInput1.Focus();
                return false;
            }
            if (this.dateTimeInput2.Value == new DateTime())
            {
               MessageBox.Show("Debe elegir la fecha final");
                this.dateTimeInput2.Focus();
                return false;
            }

            if (this.dateTimeInput1.Value > dateTimeInput2.Value)
            {
               MessageBox.Show("La fecha final no puede ser mayor a la fecha inicial");
                this.dateTimeInput1.Focus();
                return false;
            }

           
            return true;
        }

        


    }
}
