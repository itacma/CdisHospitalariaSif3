using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Ventas
{
    public partial class PagoForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        SIFModelo.Remision remision;
        SIFModelo.Caja cajaID;
        SIFModelo.Cajero cajeroID;
        SIFModelo.TipoPago tipoPago;

        public PagoForm(SIFModelo.Remision remision, SIFModelo.Caja cajaId, SIFModelo.Cajero cajeroId)
        {
            InitializeComponent();
            this.remision = remision;
            this.cajaID = cajaId;
            this.cajeroID = cajeroId;
            //this.tipoPagoComboBoxEx.SelectedIndex = 0;
            this.InicializaDatos();
            this.calculaTotales();
            this.cargaTipoPago();
            this.cargaBancos();

            this.folioLabel.Text = remision.NumeroPedido;
        }

        public SIFModelo.TipoCambio tipoCambio;
        public SIFModelo.Banco banco;
        public string referencia;
        public decimal pagoMonto;

        private void cargaBancos()
        {
            SIFNegocio.Bancos LtipoPago = new SIFNegocio.Bancos();

            BindingSource bs = new BindingSource();
            bs.DataSource = LtipoPago.Buscar("ACTIVO", "S").DataSource;
            this.bancoComboBoxEx.DataSource = bs;

            bancoComboBoxEx.DisplayMember = "Nombre";
            bancoComboBoxEx.ValueMember = "ID";
        }

        BindingList<SIFModelo.TipoPago> bsTiposPago = new BindingList<SIFModelo.TipoPago>();
        BindingList<SIFModelo.TipoPago> bsfactura = new BindingList<SIFModelo.TipoPago>();
        SIFModelo.TipoPago CREDITO = new SIFModelo.TipoPago();
        private void cargaTipoPago()
        {
            SIFNegocio.TipoPagos LtipoPago = new SIFNegocio.TipoPagos();

            bsTiposPago = new BindingList<SIFModelo.TipoPago>(LtipoPago.Buscar("ACTIVO", "S").DataSource as List<SIFModelo.TipoPago>);


            //EFECTIVO
            SIFModelo.TipoPago EFECTIVO = new SIFModelo.TipoPago();
            var vEFECTIVO = from t in bsTiposPago where t.Nombre == "EFECTIVO" select t;
            if (vEFECTIVO.Count() > 0)
            {
                EFECTIVO = vEFECTIVO.First();
            }
            else
            {
                EFECTIVO = new SIFModelo.TipoPago();
                EFECTIVO.Activo = SIFModelo.Tipos.SiNo.SI;
                EFECTIVO.Comision = SIFModelo.Tipos.SiNo.NO;
                EFECTIVO.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                EFECTIVO.Nombre = "EFECTIVO";
                EFECTIVO.Porcentaje = 0;

                EFECTIVO = new SIFNegocio.TipoPagos().Nuevo(EFECTIVO);

                bsTiposPago.Add(EFECTIVO);
            }

            //TARJETA DE CREDITO
            SIFModelo.TipoPago TCREDITO = new SIFModelo.TipoPago();
            var vTCREDITO = from t in bsTiposPago where t.Nombre == "TARJETA DE CREDITO" select t;
            if (vTCREDITO.Count() > 0)
            {
                TCREDITO = vTCREDITO.First();
            }
            else
            {
                TCREDITO = new SIFModelo.TipoPago();
                TCREDITO.Activo = SIFModelo.Tipos.SiNo.SI;
                TCREDITO.Comision = SIFModelo.Tipos.SiNo.NO;
                TCREDITO.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                TCREDITO.Nombre = "TARJETA DE CREDITO";
                TCREDITO.Porcentaje = 0;

                TCREDITO = new SIFNegocio.TipoPagos().Nuevo(TCREDITO);
                bsTiposPago.Add(TCREDITO);
            }
            //

            //TARJETA DE DEBITO
            SIFModelo.TipoPago TDEBITO = new SIFModelo.TipoPago();
            var vTDEBITO = from t in bsTiposPago where t.Nombre == "TARJETA DE DEBITO" select t;
            if (vTDEBITO.Count() > 0)
            {
                TDEBITO = vTDEBITO.First();
            }
            else
            {
                TDEBITO = new SIFModelo.TipoPago();
                TDEBITO.Activo = SIFModelo.Tipos.SiNo.SI;
                TDEBITO.Comision = SIFModelo.Tipos.SiNo.NO;
                TDEBITO.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                TDEBITO.Nombre = "TARJETA DE DEBITO";
                TDEBITO.Porcentaje = 0;

                TDEBITO = new SIFNegocio.TipoPagos().Nuevo(TDEBITO);
                bsTiposPago.Add(TDEBITO);
            }
            //

            //CHEQUE
            SIFModelo.TipoPago CHEQUE = new SIFModelo.TipoPago();
            var vCHEQUE = from t in bsTiposPago where t.Nombre == "CHEQUE" select t;
            if (vCHEQUE.Count() > 0)
            {
                CHEQUE = vCHEQUE.First();
            }
            else
            {
                CHEQUE = new SIFModelo.TipoPago();
                CHEQUE.Activo = SIFModelo.Tipos.SiNo.SI;
                CHEQUE.Comision = SIFModelo.Tipos.SiNo.NO;
                CHEQUE.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                CHEQUE.Nombre = "CHEQUE";
                CHEQUE.Porcentaje = 0;

                CHEQUE = new SIFNegocio.TipoPagos().Nuevo(CHEQUE);
                bsTiposPago.Add(CHEQUE);
            }
            //

            //VALE DEVOLUCION
            SIFModelo.TipoPago VALEDEVOLUCION = new SIFModelo.TipoPago();
            var vVALEDEVOLUCION = from t in bsTiposPago where t.Nombre == "VALE DEVOLUCION" select t;
            if (vVALEDEVOLUCION.Count() > 0)
            {
                VALEDEVOLUCION = vVALEDEVOLUCION.First();
            }
            else
            {
                VALEDEVOLUCION = new SIFModelo.TipoPago();
                VALEDEVOLUCION.Activo = SIFModelo.Tipos.SiNo.SI;
                VALEDEVOLUCION.Comision = SIFModelo.Tipos.SiNo.NO;
                VALEDEVOLUCION.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                VALEDEVOLUCION.Nombre = "VALE DEVOLUCION";
                VALEDEVOLUCION.Porcentaje = 0;

                VALEDEVOLUCION = new SIFNegocio.TipoPagos().Nuevo(VALEDEVOLUCION);
                bsTiposPago.Add(VALEDEVOLUCION);
            }
            //

            //CREDITO

            var vCREDITO = from t in bsTiposPago where t.Nombre == "CREDITO" select t;
            if (vCREDITO.Count() > 0)
            {
                CREDITO = vCREDITO.First();
            }
            else
            {
                CREDITO = new SIFModelo.TipoPago();
                CREDITO.Activo = SIFModelo.Tipos.SiNo.SI;
                CREDITO.Comision = SIFModelo.Tipos.SiNo.NO;
                CREDITO.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                CREDITO.Nombre = "CREDITO";
                CREDITO.Porcentaje = 0;

                CREDITO = new SIFNegocio.TipoPagos().Nuevo(CREDITO);
                bsTiposPago.Add(CREDITO);
            }
            //


            //TRANSFERENCIA BANCARIA
            SIFModelo.TipoPago TRASNFERENCIA = new SIFModelo.TipoPago();
            var vTRASNFERENCIA = from t in bsTiposPago where t.Nombre == "TRANSFERENCIA BANCARIA" select t;
            if (vTRASNFERENCIA.Count() > 0)
            {
                TRASNFERENCIA = vTRASNFERENCIA.First();
            }
            else
            {
                TRASNFERENCIA = new SIFModelo.TipoPago();
                TRASNFERENCIA.Activo = SIFModelo.Tipos.SiNo.SI;
                TRASNFERENCIA.Comision = SIFModelo.Tipos.SiNo.NO;
                TRASNFERENCIA.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                TRASNFERENCIA.Nombre = "TRANSFERENCIA BANCARIA";
                TRASNFERENCIA.Porcentaje = 0;

                TRASNFERENCIA = new SIFNegocio.TipoPagos().Nuevo(TRASNFERENCIA);
                bsTiposPago.Add(TRASNFERENCIA);
            }
            //


            //TRANSFERENCIA BANCARIA
            SIFModelo.TipoPago TARJETASERVICIO = new SIFModelo.TipoPago();
            var vTARJETASERVICIO = from t in bsTiposPago where t.Nombre == "TARJETA DE SERVICIO" select t;
            if (vTARJETASERVICIO.Count() > 0)
            {
                TARJETASERVICIO = vTARJETASERVICIO.First();
            }
            else
            {
                TARJETASERVICIO = new SIFModelo.TipoPago();
                TARJETASERVICIO.Activo = SIFModelo.Tipos.SiNo.SI;
                TARJETASERVICIO.Comision = SIFModelo.Tipos.SiNo.NO;
                TARJETASERVICIO.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                TARJETASERVICIO.Nombre = "TARJETA DE SERVICIO";
                TARJETASERVICIO.Porcentaje = 0;

                TARJETASERVICIO = new SIFNegocio.TipoPagos().Nuevo(TARJETASERVICIO);
                bsTiposPago.Add(TARJETASERVICIO);
            }
            //

            //MONEDEROS ELECTRONICOS
            SIFModelo.TipoPago MONEDEROS_ELECTRONICOS = new SIFModelo.TipoPago();
            var vMONEDEROS_ELECTRONICOS = from t in bsTiposPago where t.Nombre == "MONEDEROS ELECTRONICOS" select t;
            if (vMONEDEROS_ELECTRONICOS.Count() > 0)
            {
                MONEDEROS_ELECTRONICOS = vMONEDEROS_ELECTRONICOS.First();
            }
            else
            {
                MONEDEROS_ELECTRONICOS = new SIFModelo.TipoPago();
                MONEDEROS_ELECTRONICOS.Activo = SIFModelo.Tipos.SiNo.SI;
                MONEDEROS_ELECTRONICOS.Comision = SIFModelo.Tipos.SiNo.NO;
                MONEDEROS_ELECTRONICOS.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                MONEDEROS_ELECTRONICOS.Nombre = "MONEDEROS ELECTRONICOS";
                MONEDEROS_ELECTRONICOS.Porcentaje = 0;

                MONEDEROS_ELECTRONICOS = new SIFNegocio.TipoPagos().Nuevo(MONEDEROS_ELECTRONICOS);
                bsTiposPago.Add(MONEDEROS_ELECTRONICOS);
            }
            //

            //NO IDENTIFICADO
            SIFModelo.TipoPago NO_IDENTIFICADO = new SIFModelo.TipoPago();
            var vNO_IDENTIFICADO = from t in bsTiposPago where t.Nombre == "NO IDENTIFICADO" select t;
            if (vNO_IDENTIFICADO.Count() > 0)
            {
                NO_IDENTIFICADO = vNO_IDENTIFICADO.First();
            }
            else
            {
                NO_IDENTIFICADO = new SIFModelo.TipoPago();
                NO_IDENTIFICADO.Activo = SIFModelo.Tipos.SiNo.SI;
                NO_IDENTIFICADO.Comision = SIFModelo.Tipos.SiNo.NO;
                NO_IDENTIFICADO.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                NO_IDENTIFICADO.Nombre = "NO IDENTIFICADO";
                NO_IDENTIFICADO.Porcentaje = 0;

                NO_IDENTIFICADO = new SIFNegocio.TipoPagos().Nuevo(NO_IDENTIFICADO);
                bsTiposPago.Add(NO_IDENTIFICADO);
            }
            //

            #region comentarios

            //var vtipoPago = from t in bs where t.Nombre == "NO IDENTIFICADO" select t;
            //var ftipoPago = from t in bsfactura where t.Nombre == "NO IDENTIFICADO" select t;

            ////CARGAMOS EL TIPO DE PAGO NO IDENTIFICADO
            //SIFModelo.TipoPago NoIdentificado = null;
            //if (vtipoPago.Count() > 0)
            //{
            //    NoIdentificado = vtipoPago.First();
            //}
            //else
            //{
            //    SIFModelo.TipoPago tipoPagoNOIdentificado = new SIFModelo.TipoPago();
            //    tipoPagoNOIdentificado.Activo = SIFModelo.Tipos.SiNo.SI;
            //    tipoPagoNOIdentificado.Comision = SIFModelo.Tipos.SiNo.NO;
            //    tipoPagoNOIdentificado.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            //    tipoPagoNOIdentificado.Nombre = "NO IDENTIFICADO";
            //    tipoPagoNOIdentificado.Porcentaje = 0;

            //    NoIdentificado = new SIFNegocio.TipoPagos().Nuevo(tipoPagoNOIdentificado);

            //    bs.Add(NoIdentificado);
            //    bsfactura.Add(NoIdentificado);
            //}

            //SIFModelo.TipoPago fNoIdentificado = null;
            //if (ftipoPago.Count() > 0)
            //{
            //    fNoIdentificado = ftipoPago.First();
            //}

            //var vtipoPagoEfectivo = from t in bs where t.Nombre == "EFECTIVO" select t;

            //SIFModelo.TipoPago Efectivo = null;
            //if (vtipoPagoEfectivo.Count() > 0)
            //{
            //    Efectivo = vtipoPagoEfectivo.First();
            //}
            //else
            //{
            //    SIFModelo.TipoPago tipoPagoEFECTIVO = new SIFModelo.TipoPago();
            //    tipoPagoEFECTIVO.Activo = SIFModelo.Tipos.SiNo.SI;
            //    tipoPagoEFECTIVO.Comision = SIFModelo.Tipos.SiNo.NO;
            //    tipoPagoEFECTIVO.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            //    tipoPagoEFECTIVO.Nombre = "EFECTIVO";
            //    tipoPagoEFECTIVO.Porcentaje = 0;

            //    tipoPagoEFECTIVO = new SIFNegocio.TipoPagos().Nuevo(tipoPagoEFECTIVO);

            //    bs.Add(tipoPagoEFECTIVO);
            //    bsfactura.Add(tipoPagoEFECTIVO);
            //}

            //var vtipoPagoCredito = from t in bs where t.Nombre == "CREDITO" select t;

            //SIFModelo.TipoPago Credito = null;
            //if (vtipoPagoCredito.Count() > 0)
            //{
            //    Credito = vtipoPagoCredito.First();
            //}
            //else
            //{
            //    SIFModelo.TipoPago tipoPagoCREDITO = new SIFModelo.TipoPago();
            //    tipoPagoCREDITO.Activo = SIFModelo.Tipos.SiNo.SI;
            //    tipoPagoCREDITO.Comision = SIFModelo.Tipos.SiNo.NO;
            //    tipoPagoCREDITO.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            //    tipoPagoCREDITO.Nombre = "CREDITO";
            //    tipoPagoCREDITO.Porcentaje = 0;

            //    Credito = new SIFNegocio.TipoPagos().Nuevo(tipoPagoCREDITO);
            //    bs.Add(Credito);
            //    bsfactura.Add(Credito);
            //}

            //if (remision.MonedaID == 0)
            //{
            //    bs.Remove(Credito);
            //}


            #endregion


            //LLENAR LOS COMBOBOX DE TIPO DE PAGO
            //bs.Add(EFECTIVO);
            //bs.Add(TCREDITO);
            //bs.Add(TDEBITO);
            //bs.Add(CHEQUE);
            //bs.Add(VALEDEVOLUCION);
            //bs.Add(CREDITO);



            //LLENAR EL COMBOBOX DE FACTURA
            bsfactura.Add(EFECTIVO);
            bsfactura.Add(CHEQUE);
            bsfactura.Add(TRASNFERENCIA);
            bsfactura.Add(TCREDITO);
            bsfactura.Add(TDEBITO);
            bsfactura.Add(TARJETASERVICIO);
            bsfactura.Add(MONEDEROS_ELECTRONICOS);
            bsfactura.Add(NO_IDENTIFICADO);



            //bs.Remove(NoIdentificado);

            //if (remision.Factura == SIFModelo.Tipos.SiNo.SI)
            //{
            //    if (NoIdentificado != null)
            //    {
            //        tipoPagoFacturaComboBoxEx.SelectedItem = NoIdentificado;
            //    }
            //}
            //else
            //{


            //}


            //QUITAMOS EL CREDITO DE LA LISTA SI NO ES CLIENTE CONVENIO

            //AGREGAR LOS TIPOS DE PAGO
            this.tipoPagoComboBoxEx.DataSource = bsTiposPago;
            tipoPagoComboBoxEx.DisplayMember = "Nombre";
            tipoPagoComboBoxEx.ValueMember = "Id";

            if (remision.Factura == SIFModelo.Tipos.SiNo.SI)
            {
                tipoPagoFacturaComboBoxEx.DataSource = bsfactura;
                this.tipoPagoFacturaComboBoxEx.SelectedItem = NO_IDENTIFICADO;
                tipoPagoFacturaComboBoxEx.DisplayMember = "Nombre";
                tipoPagoFacturaComboBoxEx.ValueMember = "Id";
            }


            if (remision.TipoCambio == 1)
            {
                tipoPagoComboBoxEx.SelectedItem = CREDITO;
                tipoPagoComboBoxEx.Enabled = false;
            }
            else
            {
                bsTiposPago.Remove(CREDITO);
                tipoPagoComboBoxEx.SelectedItem = EFECTIVO;
            }


            //VALIDA SI ES CLIENTE CONVENIO Y EL TIPO DE PAGO
            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(this.remision.ClienteID);

            if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI && remision.Factura == SIFModelo.Tipos.SiNo.SI)
            {
                SIFModelo.ClienteConvenio convenio = new SIFNegocio.ClienteConvenios().ClientePorID(cliente.ID);

                if (convenio == null)
                {
                   MessageBox.Show("No hay información del cliente convenio " + cliente.ID);
                    //return;
                }
                else
                {
                    SIFModelo.TipoPago Convenio = new SIFModelo.TipoPago();
                    var vTipoPago = from v in bsTiposPago where v.ID == convenio.TipoPagoID select v;

                    if (vTipoPago.Count() > 0)
                    {
                        Convenio = vTipoPago.First();

                        this.tipoPagoFacturaComboBoxEx.SelectedItem = Convenio;
                        this.numeroCuentaFacturaTextBoxX.Text = convenio.numCta;
                        return;
                    }
                }
            }

        }

        private void CargaPagosAnteriores()
        {

        }

        public SIFModelo.Pagos pago = new SIFModelo.Pagos();
        private void AbonaPago()
        {
            SIFNegocio.Pagos pagosN = new SIFNegocio.Pagos();

            pago.Activo = SIFModelo.Tipos.SiNo.SI;

            // this.moneda = monedaComboBoxEx.SelectedItem as SIFModelo.Moneda;
            this.banco = bancoComboBoxEx.SelectedItem as SIFModelo.Banco;
            //this.tipoCambio = tipoCambioComboBoxEx.SelectedItem as SIFModelo.TipoCambio;
            this.tipoPago = new SIFModelo.TipoPago();
            if (remision.Factura == SIFModelo.Tipos.SiNo.NO)
            {
                tipoPago = tipoPagoComboBoxEx.SelectedItem as SIFModelo.TipoPago;
                pago.TipoPagoFacID = tipoPago.ID;
            }
            else
            {

                tipoPago = tipoPagoFacturaComboBoxEx.SelectedItem as SIFModelo.TipoPago;
                pago.TipoPagoFacID = tipoPago.ID;
                tipoPago = tipoPagoComboBoxEx.SelectedItem as SIFModelo.TipoPago;
            }

            this.pagoMonto = decimal.Parse(this.pagoTextBox.Text);
            this.referencia = this.numCuentaTextBoxX.Text;
            pago.BancoID = this.banco.ID;
            pago.CajaID = cajaID.ID;
            pago.CajeroID = int.Parse(cajeroID.CajeroID);
            pago.ClienteID = remision.ClienteID;
            pago.DocumentoPago = this.referencia;
            pago.Fecha = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            pago.ImporteIVA = remision.Impuesto;
            pago.ImporteTotal = remision.Total;
            pago.ImporteVenta = remision.Total;
            pago.MonedaID = 0;// moneda.ID;
            pago.NumeroPago = 1;
            pago.RemisionID = remision.NumeroRemision;
            pago.SucursalID = remision.SucursalID;
            pago.TipoCambioID = 1;// tipoCambio.ID;
            pago.TipoPagoID = tipoPago.ID;
            pago.DocumentoPago = numeroCuentaFacturaTextBoxX.Text;
            //VERIFICAMOS SI ES CREDITO EL PAGO ABONAMOS A SU SALDO EL CREDITO Y EN CASO DE SUBROGACIONSALDO A REMISIONES POR FACTURAR
            if (tipoPagoComboBoxEx.SelectedItem == CREDITO)
            {
                // verificamos si el cliente es tipo subrogaccion o cliente convenio
                SIFNegocio.Clientes ClienteLog = new SIFNegocio.Clientes();
                SIFModelo.Cliente Cliente = ClienteLog.ClientePorID(remision.ClienteID);
                if (Cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
                {
                    SIFNegocio.ClienteConvenios ClienteConl = new SIFNegocio.ClienteConvenios();
                    SIFModelo.ClienteConvenio ClienteConvenio = ClienteConl.ClientePorID(remision.ClienteID);

                    //actualizamos el saldo en cliente convenio
                    if (ClienteConvenio != null)
                    {
                        ClienteConvenio.Saldo = ClienteConvenio.Saldo + remision.Total;
                        ClienteConl.Modificar(ClienteConvenio);
                    }
                }
                if (Cliente.SUBROGACION == SIFModelo.Tipos.SiNo.SI)
                {
                    SIFNegocio.ClienteSubrogacion ClienteSubL = new SIFNegocio.ClienteSubrogacion();
                    SIFModelo.ClienteSubrogaccion ClienteSub = ClienteSubL.ClientePorID(remision.ClienteID);
                    if (ClienteSub != null)
                    {
                        ClienteSub.Saldo = ClienteSub.Saldo + remision.Total;
                        ClienteSubL.Modificar(ClienteSub);
                    }
                }
            }

        }


        public BindingList<SIFModelo.PagosDetalle> pagosDetalle = new BindingList<SIFModelo.PagosDetalle>();
        private void Agregar()
        {
            if (this.pagoMonto >= remision.Total && remision.Total > 0)
            {
               MessageBox.Show("El monto ya ha sido cubierto");
                return;
            }

            if (!this.pagoTextBox.Text.IsFloatPositive())
            {
                pagoTextBox.Focus();
                pagoTextBox.SelectAll();
               MessageBox.Show("El monto ingresado en el pago no es válido", "Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SIFModelo.PagosDetalle pagoDetalle = new SIFModelo.PagosDetalle();

            var vTipoPago = this.tipoPagoComboBoxEx.SelectedItem as SIFModelo.TipoPago;

            if (vTipoPago == null)
            {
               MessageBox.Show("Por favor elija el tipo de pago");
                tipoPagoComboBoxEx.DroppedDown = true;
                return;
            }

            SIFModelo.TipoPago tipoPago = vTipoPago as SIFModelo.TipoPago;

            if (tipoPago.Nombre == "CREDITO")
            {
                SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(this.remision.ClienteID);

                if ((cliente.Convenio == SIFModelo.Tipos.SiNo.NO) & (cliente.SUBROGACION == SIFModelo.Tipos.SiNo.NO))
                {
                   MessageBox.Show("El cliente no puede tener crédito");
                    return;
                }
            }

            if (tipoPago.Nombre.ToUpper() != "EFECTIVO" && !tipoPago.Nombre.ToUpper().Contains("NO IDENTIFICADO") && !tipoPago.Nombre.ToUpper().Contains("VALE DEVOLUCION") && (tipoPago.Nombre.ToUpper() != "CREDITO"))
            {
                if (string.IsNullOrEmpty(this.numCuentaTextBoxX.Text))
                {
                   MessageBox.Show("Ingrese el número de cuenta");
                    this.numCuentaTextBoxX.Focus();
                    return;
                }
            }


            //var vDetalle = from p in pagosDetalle where p.TIPO_PAGO_ID == tipoPago.ID select p;



            //if (vDetalle.Count() > 0)
            //{
            //    SIFModelo.PagosDetalle detallePago = vDetalle.First();
            //    detallePago.IMPORTE += decimal.Parse(this.pagoTextBox.Text);
            //    detallePago.NUM_CUENTA += this.numCuentaTextBoxX.Text;
            //}
            //else
            //{
            pagoDetalle.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            if (this.numCuentaTextBoxX.Text.IsInteger())
                pagoDetalle.NUM_CUENTA = this.numCuentaTextBoxX.Text;
            pagoDetalle.NUM_PAGO = 0;
            pagoDetalle.SUCURSAL_ID = Helpers.Sesion.Sucursal.SucursalesID;
            pagoDetalle.TIPO_PAGO_ID = tipoPago.ID;
            pagoDetalle.TIPO_PAGO_NOMBRE = tipoPago.Nombre;
            pagoDetalle.IMPORTE = decimal.Parse(this.pagoTextBox.Text);
            pagoDetalle.PAGO_COMPLETO = decimal.Parse(this.pagoTextBox.Text);
            if (pagoDetalle.IMPORTE > restante)
            {
                pagoDetalle.IMPORTE = restante;
            }

            //pagoDetalle.TIPOPAGO_ID = new SIFNegocio.TipoPagos()



            pagosDetalle.Add(pagoDetalle);
            //}

            if (tipoPago.Porcentaje > 0)
            {
                pagoDetalle.COMISION = pagoDetalle.IMPORTE * (tipoPago.Porcentaje / 100m);
            }

            this.dataGridViewX1.DataSource = pagosDetalle;
            this.dataGridViewX1.Invalidate(true);

            this.calculaTotales();

            this.pagoTextBox.SelectAll();
            this.numCuentaTextBoxX.Clear();
            this.tipoPagoComboBoxEx.Focus();


            this.pagoTextBox.Text = this.restante.ToString("###,###.00");
        }



        private void InicializaDatos()
        {
            this.fechaVentaLabel.Text = remision.FechaVenta.ToShortDateString();
            descuentoLabel.Text = remision.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.impuestosLabel.Text = remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.importeLabel.Text = remision.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

            this.pagoTextBox.Text = remision.Total.ToString("0.00");

            if (this.remision.Factura == SIFModelo.Tipos.SiNo.SI)
            {
                this.tipoPagoFacturaComboBoxEx.Visible = true;
                this.formaPagoFacturalabel.Visible = true;

                this.numeroCuentaPagolabel.Visible = true;
                this.numeroCuentaFacturaTextBoxX.Visible = true;
            }
        }


        private bool validaPago()
        {
            if (!this.pagoTextBox.Text.IsFloatPositive())
            {
               MessageBox.Show("El es incorrecto, ingrese un monto sin simbolos de moneda");
                this.pagoTextBox.Focus();
                this.pagoTextBox.SelectAll();
                return false;
            }

            if (tipoPagoComboBoxEx.SelectedItem == null)
            {
               MessageBox.Show("Seleccione un tipo de pago");
                tipoPagoComboBoxEx.Focus();
                return false;
            }

            if (remision.Factura == SIFModelo.Tipos.SiNo.SI)
            {
                SIFModelo.TipoPago tipoPago = tipoPagoFacturaComboBoxEx.SelectedItem as SIFModelo.TipoPago;

                if (tipoPago != null)
                {
                    if (tipoPago.Nombre.ToUpper().Contains("TRANSFERENCIA") || tipoPago.Nombre.ToUpper().Contains("CHEQUE") || tipoPago.Nombre.ToUpper().Contains("TARJETA DE CREDITO") || tipoPago.Nombre.ToUpper().Contains("TARJETA DE DEBITO") || tipoPago.Nombre.ToUpper().Contains("TARJETA DE SERVICIO") || tipoPago.Nombre.ToUpper().Contains("MONEDEROS ELECTRONICOS"))
                    {
                        if (numeroCuentaFacturaTextBoxX.Text.Length < 4)
                        {
                           MessageBox.Show("Debe ingresar los ultimos 4 digitos de la cuenta");
                            this.numeroCuentaFacturaTextBoxX.Focus();
                            return false;
                        }
                    }
                }
            }
            else
            {

            }

            if (SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(pagoMonto,2) < SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(this.remision.Total,2))
            {
               MessageBox.Show("Debe abonar el total");
                this.pagoTextBox.SelectAll();
                this.pagoTextBox.Focus();
                return false;
            }

            //if (remision.Factura == SIFModelo.Tipos.SiNo.SI)
            //{
            //    SIFModelo.TipoPago tipoPago = tipoPagoFacturaComboBoxEx.SelectedItem as SIFModelo.TipoPago;
            //}

            return true;
        }

        private decimal restante = 0;
        private void calculaTotales()
        {
            //this.importeLabel.Text = remision.Total.ToString("C2");
            //impuesto = (remision.Total * (decimal)remision.Impuesto);
            //this.fechaVentaLabel.Text = impuesto.ToString("C2");
            //total = remision.Total + impuesto;
            //this.impuestosLabel.Text = total.ToString("C2");

            try
            {
                this.pagoMonto = this.pagosDetalle.Sum(p => p.IMPORTE);

                decimal pagoCompleto = this.pagosDetalle.Sum(p => p.PAGO_COMPLETO);
                //decimal pagoSiguiente = 0;

                //if (pagoTextBox.Text.IsFloatPositive())
                //{
                //    pagoSiguiente = decimal.Parse(pagoTextBox.Text);
                //}

                if (this.remision.Total < (pagoCompleto))
                {
                    decimal cambio = (pagoCompleto) - (this.remision.Total);
                    this.cambioLabel.Text = cambio.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
                }
                else
                {
                    this.cambioLabel.Text = "$0.00";
                }

                decimal porLiquidar = remision.Total - pagoMonto;

                if (porLiquidar < 0)
                {
                    porLiquidar = 0;
                }

                restante = porLiquidar;

                importeLabel.Text = porLiquidar.ToString("C2");

                //this.pagoTextBox.Text = porLiquidar.ToString("###,###.00");
                decimal comision = this.pagosDetalle.Sum(p => p.COMISION);

                ComisionLabel.Text = comision.ToString("C2");
            }
            catch
            {

            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PagoForm_Load(object sender, EventArgs e)
        {
            this.dataGridViewX1.AutoGenerateColumns = false;
            folioLabel.Text = remision.NumeroRemision.ToString();
            this.totalLabel.Text = remision.Total.ToString("c2");
            this.calculaTotales();

        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void pagoTextBox_TextChanged(object sender, EventArgs e)
        {
            this.calculaTotales();
        }

        private void guardarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void aceptarButton_Click_1(object sender, EventArgs e)
        {
            if (!this.validaPago())
            {
                //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                return;
            }

            if (remision.Factura == SIFModelo.Tipos.SiNo.SI)
            {
                datosClienteButtonX_Click(null, null);
            }

            this.AbonaPago();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        public List<SIFModelo.Devolucion> valesUtilizados = new List<SIFModelo.Devolucion>();
        private void agregarPagoButtonX_Click(object sender, EventArgs e)
        {
            this.Agregar();
        }

        private void tipoPagoComboBoxEx_SelectedValueChanged(object sender, EventArgs e)
        {
            SIFModelo.TipoPago tipoPago = tipoPagoComboBoxEx.SelectedItem as SIFModelo.TipoPago;
            if (!tipoPago.Nombre.ToUpper().Contains("EFECTIVO") && !tipoPago.Nombre.ToUpper().Contains("NO IDENTIFICADO") && !tipoPago.Nombre.ToUpper().Contains("VALE DEVOLUCION") && (tipoPago.Nombre.ToUpper() != "CREDITO"))
            {
                this.bancoComboBoxEx.Visible = true;
                this.numCuentaTextBoxX.Visible = true;
                numCuentaLabel.Visible = true;
                bancoLabel.Visible = true;
                numCuentaTextBoxX.Text = "NO APLICA";
            }
            else
            {

                this.bancoComboBoxEx.Visible = false;
                this.numCuentaTextBoxX.Visible = false;
                numCuentaLabel.Visible = false;
                bancoLabel.Visible = false;
            }

            if (tipoPago.Nombre.ToUpper().Contains("VALE DEVOLUCION"))
            {

                var vtipoPagoEfectivo = from t in bsTiposPago where t.Nombre == "EFECTIVO" select t;

                SIFModelo.TipoPago Efectivo = null;
                Efectivo = vtipoPagoEfectivo.First();
                //if (vtipoPagoEfectivo.Count() > 0)
                //{

                //}

                //var vValeDevolucion = from t in bs where t.Nombre == "VALE DEVOLUCION" select t;

                //SIFModelo.TipoPago ValeDevolucion = null;
                ////if (vtipoPagoEfectivo.Count() > 0)
                ////{
                //ValeDevolucion = vValeDevolucion.First();
                //tipoPagoComboBoxEx.SelectedItem = Efectivo;


                //MOSTRAR LA VENTANA DE VALE DE DEVOLUCION PARA CONFIRMAR SU NUMERO
                NumeroValeDevolucionForm FrmNumeroValeDevolucion = new NumeroValeDevolucionForm();
                if (FrmNumeroValeDevolucion.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                   MessageBox.Show("Debe ingresar el número de vale de devolución", "Vale devolución", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.tipoPagoComboBoxEx.SelectedItem = Efectivo;
                    return;
                }

                string numeroVale = FrmNumeroValeDevolucion.ValeDevolucion;
                SIFModelo.Sucursal sucursal = FrmNumeroValeDevolucion.Sucursal;
                SIFModelo.Devolucion valeDevolucion = new SIFNegocio.Devoluciones().DevolucionPorNumero(numeroVale, sucursal);

                if (valeDevolucion == null)
                {
                   MessageBox.Show("No existe el vale de devolución");
                    this.tipoPagoComboBoxEx.SelectedItem = Efectivo;
                    return;
                }

                if (valeDevolucion.Activo != SIFModelo.Tipos.ActivoDevolucion.ABIERTA)
                {
                   MessageBox.Show("El vale ya no esta activo o fue utilizado");
                    this.tipoPagoComboBoxEx.SelectedItem = Efectivo;
                    return;
                }

                if (valeDevolucion.FechaDevolucion > SIFNegocio.Configuracion.Configuraciones.fechaServidor().AddDays(8))
                {
                   MessageBox.Show("El vale de devolución ya ha caducado");
                    this.tipoPagoComboBoxEx.SelectedItem = Efectivo;
                    return;
                }

                //VALIDAR SI EL VALE CUBRE EFECTIVAMENTE EL MONTO if(valeDevolucion.

                if (valeDevolucion.TotalDevolucion > restante)
                {
                   MessageBox.Show("El vale de devolución excede el monto, su valor es de: " + valeDevolucion.TotalDevolucion.ToString("C2"));
                    this.tipoPagoComboBoxEx.SelectedItem = Efectivo;
                    return;
                }

                this.pagoTextBox.Text = valeDevolucion.TotalDevolucion.ToString("0.00");

                valesUtilizados.Add(valeDevolucion);

                this.Agregar();

                this.tipoPagoComboBoxEx.SelectedItem = Efectivo;
            }

        }

        private void pagoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Agregar();
            }
        }

        private void tipoPagoComboBoxEx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.pagoTextBox.SelectAll();
                this.pagoTextBox.Focus();
            }
        }

        private void dataGridViewX1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.calculaTotales();
        }

        private void tipoPagoComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void tipoPagoFacturaComboBoxEx_SelectedValueChanged(object sender, EventArgs e)
        {
            SIFModelo.TipoPago tipoPago = tipoPagoFacturaComboBoxEx.SelectedItem as SIFModelo.TipoPago;
            if (tipoPago.Nombre.ToUpper().Contains("TRANSFERENCIA") || tipoPago.Nombre.ToUpper().Contains("CHEQUE") || tipoPago.Nombre.ToUpper().Contains("TARJETA DE CREDITO") || tipoPago.Nombre.ToUpper().Contains("TARJETA DE DEBITO") || tipoPago.Nombre.ToUpper().Contains("TARJETA DE SERVICIO") || tipoPago.Nombre.ToUpper().Contains("MONEDEROS ELECTRONICOS"))
            {
                numeroCuentaFacturaTextBoxX.ReadOnly = false;
                numeroCuentaFacturaTextBoxX.Text = "";
            }
            else
            {
                numeroCuentaFacturaTextBoxX.ReadOnly = true;
                numeroCuentaFacturaTextBoxX.Text = "";//"NO IDENTIFICADO";
            }
        }

        private void numCuentaTextBoxX_Enter(object sender, EventArgs e)
        {
            numCuentaTextBoxX.SelectAll();
        }

        private void datosClienteButtonX_Click(object sender, EventArgs e)
        {

            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(this.remision.ClienteID);
            cliente.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
            View.Catalogos.DireccionClienteForm frmDireccion = new Catalogos.DireccionClienteForm(cliente);
            frmDireccion.ShowDialog();
        }

    }
}
