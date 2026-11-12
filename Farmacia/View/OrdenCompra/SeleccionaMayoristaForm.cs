using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.OrdenCompra
{
    public partial class SeleccionaMayoristaForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public SeleccionaMayoristaForm()
        {
            InitializeComponent();
            cargaCliente();
        }

        private bool valida()
        {
            if (this.clienteComboBoxEx.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un mayorista");
                return false;
            }

            return true;
        }

        SIFNegocio.Clientes clienteL = new SIFNegocio.Clientes();

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public SIFModelo.Cliente clienteSeleccionado;
        List<SIFModelo.Cliente> clientes = new List<SIFModelo.Cliente>();
        private void cargaCliente()
        {
            SIFModelo.Cliente clienteM = new SIFModelo.Cliente();
            clienteM.Nombre = "[TODOS]";
            clientes.Add(clienteM);
            clientes.AddRange(clienteL.BuscarProveedoresMayoristas("", "", false));

            this.clienteComboBoxEx.DataSource = clientes;
            clienteComboBoxEx.DisplayMember = "Nombre";
            clienteComboBoxEx.ValueMember = "ID";
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (this.valida())
            {
                this.clienteSeleccionado = clienteComboBoxEx.SelectedItem as SIFModelo.Cliente;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
               
            }
        }
    }
}
