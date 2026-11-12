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
    public partial class FacturaVistaPreviaForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FacturaVistaPreviaForm(SIFModelo.Remision remision)
        {
            InitializeComponent();
            this.dataGridViewX1.AutoGenerateColumns = false;
            this.remision = remision;
            CargaFactura();
        }

        SIFModelo.Remision remision;

        SIFNegocio.Remision remisionL = new SIFNegocio.Remision();
        private void CargaFactura()
        {
            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(remision.ClienteID);

            SIFModelo.Sucursal sucursal = new SIFModelo.Sucursal();
            sucursal = new SIFNegocio.Sucursales().SucursalPorID(remision.SucursalID);
            //sucursal = new SIFNegocio.Sucursales().Buscar("","");
            SIFModelo.DireccionCliente dirFiscal = new SIFModelo.DireccionCliente();
            dirFiscal = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);

            clientelabelX.Text = cliente.Nombre;
            rfclabelX.Text = dirFiscal.RFC;
            direccionlabelX.Text = dirFiscal.Calle  + " " + dirFiscal.NumeroExterior + " " + dirFiscal.Colonia + " " + dirFiscal.CodigoPostal + " " + dirFiscal.Ciudad;
            
            //View.Catalogos.DireccionClienteForm frmCliente = new Catalogos.DireccionClienteForm(cliente);
            //if (frmCliente.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}

            //QUITAR EL IVA DE TODOS LOS DETALLES
            //RESTAMOS EL IVA
            remision.SubTotal = 0;

            remision.Descuento = 0;

            SIFNegocio.Remision logicaF = new SIFNegocio.Remision();
            remision = logicaF.FacturaDeRemision(remision);

            this.dataGridViewX1.DataSource = remision.Detalles;
            this.subtotalLabelX.Text = remision.SubTotal.ToString("C2");
            this.descuentoLabelX.Text = remision.Descuento.ToString("C2");
            this.ivaLabelX.Text = remision.Impuesto.ToString("C2");
            this.totalLabelX.Text = remision.Total.ToString("C2");
        }


    }
}
