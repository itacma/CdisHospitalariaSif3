using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DevComponents.DotNetBar;

namespace SIF.View.OrdenCompra
{
    public partial class AsignacionPreciosFinalizaForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        private SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OrdenCompra;

        public AsignacionPreciosFinalizaForm()
        {
            InitializeComponent();
        }

        SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow compra;
        decimal diferenciaTotal = 0;

        public AsignacionPreciosFinalizaForm(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OrdenCompra, SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow compra)// SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OrdenCompra, decimal ImporteFactura, decimal DescuentoFactura, decimal IVAFactura, decimal TotalFactura, decimal ImporteRecibido, decimal DescuentoRecibido, decimal IVARecibido, decimal TotalRecibido, decimal MalOfertado, decimal sinOferta, SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow compra, decimal TotalFaltante, decimal totalMalEstado, decimal TotalNoPedido, decimal TotalProximoCaducar, decimal TotalPrecioElevado, decimal totalDescto1, decimal totalDescto2, decimal totalDescto3, decimal TotalNoLlego, decimal importaIVA_MalOfertado)
            : this()
        {
            int cantidad = 0;
            string mensaje = String.Empty;
            string estado_old = String.Empty;
            this.compra = compra;

            facturaTextBox.Text = compra.FACTURA;
         
            if (compra.IsFOLIO_FACTURA_SATNull())
            {
                compra.FOLIO_FACTURA_SAT = "-";
            }
            uuidTextBoxX.Text = compra.FOLIO_FACTURA_SAT;

            new SIFNegocio.OrdenCompra.OrdenCompra().Verificar_ctl_oc(OrdenCompra.FOLIO_OC_ID, out mensaje, out cantidad, out estado_old);
            if (OrdenCompra.ESTADO_OC != "E" || (mensaje == "1" && estado_old.Trim() == "L"))
            {
                aceptarButtonX.Enabled = false;
            }

            // TODO: Complete member initialization
            this.OrdenCompra = OrdenCompra;

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow factura = new SIFNegocio.OrdenCompra.OrdenCompra().FacturaPorNumero(OrdenCompra);// new SIFNegocio.OrdenCompra.OrdenCompra().BuscaCompras(this.OrdenCompra);
            if (factura != null)
            {
                facturaTextBox.Text = factura.NUM_FACTURA.ToString();
                if (compra.PROVEEDOR_ID == 99064 && !string.IsNullOrEmpty( factura.FOLIO_FACTURA_SAT))
                    facturaTextBox.Text = factura.FOLIO_FACTURA_SAT;// compra.FOLIO_FACTURA_SAT;
            }

            //if(v_importeFactura.ToString().IsFloatPositive())
            //{
            //    decimal importeFactura = decimal.Parse(v_importeFactura.ToString());
            //}

            //this.difTotalLabel.Text = TotalFaltante.ToString("C2");
            //this.malEstadoLabel.Text = totalMalEstado.ToString("C2");
            //this.noPedidoLabel.Text = TotalNoPedido.ToString("C2");
            //this.proxCaducarLabel.Text = TotalProximoCaducar.ToString("C2");
            //this.precElevadoLabel.Text = TotalPrecioElevado.ToString("C2");

            this.importeFacturaLabel.Text = compra.TOT_FACTURA.ToString("c2");
            this.descuentoFacturaLabel.Text = compra.DESCUENTO_FACTURA.ToString("c2");
            this.IVAfacturaLabel.Text = compra.IVA_FACTURA.ToString("c2");
            this.IEPSfacturaLabel.Text = compra.IEPS_FACTURA.ToString("C2");

            decimal totalFactura = (compra.TOT_FACTURA - compra.DESCUENTO_FACTURA + compra.IVA_FACTURA + compra.IEPS_FACTURA);
            this.totalFacturaLabel.Text = totalFactura.ToString("c2");

            decimal totalDescuento = (decimal)(compra.TOT_DESCTO_REC + compra.MAL_OFERTADO);

            descuentoRecibidoLabel.Text = compra.TOT_DESCTO_REC.ToString("c2");
            IVArecibidoLabel.Text = (compra.TOT_IVA_REC).ToString("c2");
            iepsRecibidolabel.Text = compra.TOT_IEPS_REC.ToString("c2");

            decimal totalRecepcion = (compra.TOT_IMPORTE_REC + compra.TOT_DESCTO_REC + compra.TOT_IEPS_REC + compra.TOT_IVA_REC + compra.TOTAL_IVA_DESCTO_REC + compra.TOTAL_IEPS_DESCTO_REC);
            importeRecibidoLabel.Text = totalRecepcion.ToString("c2"); //.TOTAL_RECIBIDO.ToString("c2");

            decimal importeTotalRecepcion = compra.TOT_IMPORTE_REC + compra.TOT_IEPS_REC + compra.TOT_IVA_REC;
            this.totalRecibidoLabel.Text = importeTotalRecepcion.ToString("c2");


            descto1Label.Text = compra.IMP_DESC_AD1.ToString("C2");
            descto2Label.Text = compra.IMP_DESC_AD2.ToString("C2");
            descto3Label.Text = compra.IMP_DESC_AD3.ToString("C2");
            double totalDescuentosAdicionales = compra.IMP_DESC_AD1 + compra.IMP_DESC_AD2 + compra.IMP_DESC_AD3 ;
            descuentosLabel.Text = totalDescuentosAdicionales.ToString("C2");
    
            //IMPUESTOS
            difIESPlabel.Text = compra.TOTAL_IEPS_DESCTO_REC.ToString("C2");
            difIVAlabel.Text = compra.TOTAL_IVA_DESCTO_REC.ToString("C2");

            decimal totalImpuestosRecepcion = compra.TOTAL_IEPS_DESCTO_REC + compra.TOTAL_IVA_DESCTO_REC;
            impuestosLabel.Text = totalImpuestosRecepcion.ToString("c2");

            //INCIDENCIAS

            this.difTotalLabel.Text = compra.IMP_FALTANTE.ToString("c2");
            this.malEstadoLabel.Text = compra.MAL_ESTADO.ToString("c2");
            this.noPedidoLabel.Text = compra.NO_PEDIDO.ToString("c2");
            this.proxCaducarLabel.Text = compra.PROX_CADUCAR.ToString("c2");
            this.precElevadoLabel.Text = compra.PREC_ELEVADO.ToString("c2");

            decimal totalIncidencias = compra.IMP_FALTANTE + compra.MAL_ESTADO + compra.NO_PEDIDO + compra.PROX_CADUCAR + compra.PREC_ELEVADO;
            subTotal1Label.Text = totalIncidencias.ToString("C2");
            decimal TotalDiferencias = totalIncidencias + (decimal)totalDescuentosAdicionales + totalImpuestosRecepcion;
            totalDifLabel.Text = TotalDiferencias.ToString("C2");

            diferenciaTotal = totalFactura - importeTotalRecepcion - TotalDiferencias;
            comparacionLabel.Text = diferenciaTotal.ToString("c2");

 

            //sinOfertaLabel.Text = compra.SIN_OFERTA.ToString("C2");
            //malOfertadoLabel.Text = compra.MAL_OFERTADO.ToString("C2");


            //this.totalFacturaLabel.Text = (compra.TOT_FACT_RECIBIDO + compra.DESCUENTO_FACTURA).ToString("c2");

            //this.importeRecibidoLabel.Text =    compra.TOTAL_RECIBIDO.ToString("c2");
            //this.descuentoRecibidoLabel.Text = compra.TOTAL_DESCTO_DESCUENTOS_REC.ToString("c2");
            //this.IVArecibidoLabel.Text = IVARecibido.ToString("c2");
            //this.iepsRecibidolabel.Text = compra.TOT_IEPS_REC.ToString("C2");
            //this.totalRecibidoLabel.Text = ( compra.TOTAL_RECIBIDO - compra.TOTAL_DESCTO_DESCUENTOS_REC).ToString("c2"); // (TotalRecibido - DescuentoRecibido - IVARecibido - compra.TOT_IEPS_REC).ToString("c2");

            //subTotal1Label.Text = (TotalFaltante + totalMalEstado + TotalNoPedido + TotalProximoCaducar + TotalPrecioElevado).ToString("C2");
            ////this.malOfertadoLabel.Text = (DescuentoFactura - DescuentoRecibido).ToString("c2");
            //decimal difIVA = (IVAFactura - IVARecibido); //+ importaIVA_MalOfertado;
            //this.difIVAlabel.Text = difIVA.ToString("c2");

            //decimal difIESPS = compra.IEPS_FACTURA - compra.TOT_IEPS_REC;
            //difIESPlabel.Text = difIESPS.ToString("c2");

            ////  this.difTotalLabel.Text = (TotalFactura - TotalRecibido - DescuentoRecibido - difIVA).ToString("c2");
            //this.difTotalLabel.Text = TotalFaltante.ToString("c2");
            //sinOfertaLabel.Text = sinOferta.ToString("c2");

            //noLlegoLabel.Text = TotalNoLlego.ToString("C2");

            //this.malOfertadoLabel.Text = MalOfertado.ToString("C2");
            //decimal desctoDif = (compra.DESCUENTO_FACTURA - DescuentoRecibido);
            //decimal totalDiferencia = TotalFaltante + totalMalEstado + TotalNoPedido + TotalProximoCaducar + difIVA + difIESPS + sinOferta + totalDescto1 + totalDescto2 + totalDescto3;
            //totalDifLabel.Text = totalDiferencia.ToString("C2");



            //descuentosLabel.Text = (totalDescto1 + totalDescto2 + totalDescto3 + MalOfertado + sinOferta).ToString("C2");
            //impuestosLabel.Text = (difIVA + difIESPS).ToString("C2");

            //if (diferenciaTotal == 0 || (diferenciaTotal <= 0.4m && diferenciaTotal >= -0.4m))
            //{
            //    comparacionLabel.BackColor = Color.Green;
            //}
            //else
            //{
            //    comparacionLabel.BackColor = Color.Red;
            //}

        }

        private void AsignacionPreciosFinalizaForm_Load(object sender, EventArgs e)
        {
            if (diferenciaTotal == 0 || (diferenciaTotal <= 0.4m && diferenciaTotal >= -0.4m))
            {
                comparacionLabel.BackColor = Color.Green;
            }
            else
            {
                comparacionLabel.BackColor = Color.Red;
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {

            if (diferenciaTotal > 0.04m)
            {
                MessageBox.Show("Hay una diferencia mayor a 0.04 entre los recibido y el total facturado");
                return;
            }

            if (MessageBoxEx.Show("¿Está completamente seguro de asignar los precios?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void calculadoraButtonX_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("calc.exe");
            }
            catch
            {

            }
        }

        private void imprimirButtonX_Click(object sender, EventArgs e)
        {
            String Parm1 = "{CS_DEVOLUCION_COMPRAS.FOLIO_OC_ID} = '" + compra.FOLIO_COMPRA+ "'";
            SIFNegocio.Usuarios Logusu = new SIFNegocio.Usuarios();
            SIFModelo.Usuario Vend = Helpers.Sesion.Usuario;
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_IncidenciasFactura.rpt", Parm1, Vend.Nombre + ' ' + Vend.Apellidos);
            Impresion.ShowDialog();
        }


    }
}
