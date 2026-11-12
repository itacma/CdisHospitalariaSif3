using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;

namespace SIF.View.Catalogos
{
    public partial class ConvenioClienteForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        BindingList<SIFModelo.TipoPago> bsTiposPago = new BindingList<SIFModelo.TipoPago>();
        BindingList<SIFModelo.TipoPago> bsfactura = new BindingList<SIFModelo.TipoPago>();
        public ConvenioClienteForm()
        {
            InitializeComponent();
        }

        SIFModelo.Cliente cliente;
        public ConvenioClienteForm(SIFModelo.Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;

        }
        SIFModelo.ClienteConvenio ConvenioCliente;
        SIFNegocio.ClienteConvenios clienteN = new SIFNegocio.ClienteConvenios();

        private void inicializa()
        {
            this.nombreClienteLabelX.Text = cliente.Nombre;
            this.apellidoPaternoLabelX.Text = cliente.ApellidoPaterno;
            this.apellidoMaternoLabelX.Text = cliente.ApellidoMaterno;


            //BUSCAR SI YA EXISTE EL CLIENTE CONVENIO

            ConvenioCliente = clienteN.ClientePorID (cliente.ID);
            //
            if (ConvenioCliente != null)
            {
                SaldotextBoxX.Text = ConvenioCliente.Saldo.ToString("##,###,##0.00");
                PorecentajeDescuentointegerInput.Text = ConvenioCliente.PorDesc.ToString();
                PorcentajeCostointegerInput.Text = ConvenioCliente.PorScosto.ToString();
                LimiteCreditointegerInput.Text = ConvenioCliente.LimiteCredito.ToString();
                DiasVencintegerInput.Text = ConvenioCliente.DiaVencimiento.ToString();
                DiasPlazo.Text = ConvenioCliente.DiasPlazo.ToString();
                CtaBoxX1.Text = ConvenioCliente.numCta;
                SIFModelo.TipoPago CREDITO = new SIFModelo.TipoPago();
                var vCREDITO = from t in bsTiposPago where t.ID == ConvenioCliente.TipoPagoID select t;
                if (vCREDITO.Count() > 0)
                {
                    CREDITO = vCREDITO.First();
                }
                tipoPagoComboBoxEx.Text = CREDITO.Nombre;

                condvtaComboBoxEx.SelectedValue = ConvenioCliente.CondicionVenta;
                PrecioFijo.SelectedValue = ConvenioCliente.PrecioFijo;
            }
        }

        private bool GuardaDireccion()
        {
            if (!Valida())
            {
                return false;
            }
            bool esNuevo = false;

            if (ConvenioCliente == null)
            {
                esNuevo = true;
                ConvenioCliente = new SIFModelo.ClienteConvenio();
            }

            ConvenioCliente.ID = cliente.ID;

            ConvenioCliente.CondicionVenta = (SIFModelo.Tipos.CondicionVenta) condvtaComboBoxEx.SelectedValue;
            ConvenioCliente.DiasPlazo = DiasPlazo.Value; 
            ConvenioCliente.DiaVencimiento = DiasVencintegerInput.Value;
            ConvenioCliente.TipoPagoID = (tipoPagoComboBoxEx.SelectedItem as SIFModelo.TipoPago).ID;
            ConvenioCliente.LimiteCredito = LimiteCreditointegerInput.Value;
            ConvenioCliente.PorScosto = PorcentajeCostointegerInput.Value;
            ConvenioCliente.PorDesc = PorecentajeDescuentointegerInput.Value;
            ConvenioCliente.PrecioFijo = (SIFModelo.Tipos.SiNo) PrecioFijo.SelectedValue;
            ConvenioCliente.numCta = CtaBoxX1.Text;

            if (esNuevo)
            {
                return clienteN.Nuevo(ConvenioCliente).ID!=0;
            }
            else
            {
                return clienteN.Modificar(ConvenioCliente);
            }

        }

        
        private void cargaTipoPago()
        {
            SIFNegocio.TipoPagos LtipoPago = new SIFNegocio.TipoPagos();

            bsTiposPago = new BindingList<SIFModelo.TipoPago>(LtipoPago.Buscar("ACTIVO", "S").DataSource as List<SIFModelo.TipoPago>);
            
            //AGREGAR LOS TIPOS DE PAGO
            this.tipoPagoComboBoxEx.DataSource = bsTiposPago;
            tipoPagoComboBoxEx.DisplayMember = "Nombre";
            tipoPagoComboBoxEx.ValueMember = "Id";

            Dictionary<string, SIFModelo.Tipos.SiNo> SiNo = new Dictionary<string, SIFModelo.Tipos.SiNo>();
            SiNo.Add(Enum.GetName(typeof(SIFModelo.Tipos.SiNo), SIFModelo.Tipos.SiNo.SI), SIFModelo.Tipos.SiNo.SI);
            SiNo.Add(Enum.GetName(typeof(SIFModelo.Tipos.SiNo), SIFModelo.Tipos.SiNo.NO), SIFModelo.Tipos.SiNo.NO);

            this.SiNoBindingSource.DataSource = SiNo;
            PrecioFijo.DataSource = SiNoBindingSource;
            this.PrecioFijo.DisplayMember = "Key";
            this.PrecioFijo.ValueMember = "Value";
        }
        private void llenaCondVta()
        {
            Dictionary<string, SIFModelo.Tipos.CondicionVenta> CondVta = new Dictionary<string, SIFModelo.Tipos.CondicionVenta>();
            CondVta.Add(Enum.GetName(typeof(SIFModelo.Tipos.CondicionVenta), SIFModelo.Tipos.CondicionVenta.EFECTIVO), SIFModelo.Tipos.CondicionVenta.EFECTIVO);
            CondVta.Add(Enum.GetName(typeof(SIFModelo.Tipos.CondicionVenta), SIFModelo.Tipos.CondicionVenta.CREDITO), SIFModelo.Tipos.CondicionVenta.CREDITO);
            CondVta.Add(Enum.GetName(typeof(SIFModelo.Tipos.CondicionVenta), SIFModelo.Tipos.CondicionVenta.AMBOS), SIFModelo.Tipos.CondicionVenta.AMBOS);
            CondVtaSource.DataSource = CondVta;
            this.condvtaComboBoxEx.DataSource = CondVtaSource;
            this.condvtaComboBoxEx.DisplayMember = "Key";
            this.condvtaComboBoxEx.ValueMember = "Value";
        }


        private Boolean Valida()
        {

            if (string.IsNullOrEmpty(tipoPagoComboBoxEx.Text))
            {
               MessageBox.Show("Proporcione el tipo de pago");
                this.tipoPagoComboBoxEx.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(condvtaComboBoxEx.Text))
            {
               MessageBox.Show("Proporcione la condicion de venta");
                this.condvtaComboBoxEx.Focus();
                return false;
            }

            return true;
        }

        
        
        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (this.GuardaDireccion())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void cancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void DireccionClienteForm_Load(object sender, EventArgs e)
        {
            cargaTipoPago();
            llenaCondVta();
            this.inicializa();
            
        }

        private void tipoPagoComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

    }
}