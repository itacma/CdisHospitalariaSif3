using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.OrdenCompra
{
    public partial class ClienteCompraForm : DevComponents.DotNetBar.Metro.MetroForm
    {

        public ClienteCompraForm(SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ordenCompra, SIFModelo.Usuario usuario)
        {
            InitializeComponent();
            this.ordenCompra = ordenCompra;
            this.usuario = usuario;
            this.articuloLabel.Text = ordenCompra.ARTICULO_ID + " [" + ordenCompra["NOMBRE1"] + "]";
            this.agregaClientes();
        }
        SIFModelo.Usuario usuario;
        SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ordenCompra;

        private void agregaClientes()
        {
            this.Cursor = Cursors.WaitCursor;
            SIFNegocio.Usuarios usuarios = new SIFNegocio.Usuarios();
            // List<string> clientesId = usuarios.ListaProveedores(usuario).Split(new char[] { ',' }).ToList();
            //List<string> clientesId = new List<string>();


            List<SIFModelo.Cliente> proveedores = new SIFNegocio.Clientes().BuscarProveedores("", proveedorTextBoxX.Text).DataSource as List<SIFModelo.Cliente>;

            //foreach (SIFModelo.Cliente proveedor in proveedores)
            //{
            //    clientesId.Add(proveedor.ID.ToString());
            //}

            List<string> clientes = new List<string>();

            if (proveedores.Count == 0)
            {
                SIFModelo.Articulo articuloDefault = new SIFNegocio.Articulo().BuscarPorClave(ordenCompra.ARTICULO_ID);
                SIFModelo.Cliente proveedorDefault = new SIFNegocio.Clientes().ClientePorID(articuloDefault.PROVEEDOR_ID);
                clientes.Add(proveedorDefault.ID + " | " + proveedorDefault.Nombre + " " + proveedorDefault.ApellidoPaterno + " " + proveedorDefault.ApellidoMaterno);
                return;
            }

            foreach (var proveedorDefault in proveedores)
            {
                // SIFModelo.Cliente proveedorDefault = new SIFNegocio.Clientes().ClientePorID(int.Parse(idCliente));
                clientes.Add(proveedorDefault.ID + " | " + proveedorDefault.Nombre + " " + proveedorDefault.ApellidoPaterno + " " + proveedorDefault.ApellidoMaterno);

            }

            this.clientesListBox.DataSource = clientes;
            this.Cursor = Cursors.Arrow;
        }

        private bool Valida()
        {
            if (this.clientesListBox.SelectedItems.Count == 0)
            {
               MessageBox.Show("Debe seleccionar un cliente");
                return false;
            }

            return true;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        public int cliente = 0;
        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (this.Valida())
            {
                string clienteSeleccionado = this.clientesListBox.SelectedItem as string;
                string[] clientePartes = clienteSeleccionado.Split(new char[] { '|' });
                string clienteId = clientePartes[0].Trim();
                string clienteNombre = clientePartes[1].Trim();

                this.cliente = int.Parse(clienteId);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void ofertasListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.aceptarButtonX_Click(null, null);
        }

        private void proveedorTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.agregaClientes();
            }
        }

    }
}
