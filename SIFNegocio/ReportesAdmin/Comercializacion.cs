using Equin.ApplicationFramework;
using SIFModelo.ReportesAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio.ReportesAdmin
{
    public class Comercializacion
    {
        public BindingListView<SIFModelo.ReportesAdmin.ComercializacionMod> ListClientes;

        public List<Saldos> BuscarSaldosCliente(int? clienteId, string nombreCliente, string estado)
        {
            var comercializacionDatos = new SIFDatos.ReportesArdmin.Comercializacion();
            return comercializacionDatos.BuscarSaldosPorCliente(clienteId, nombreCliente, estado);
        }

        public List<Saldos> BuscarSaldosPorEstado(string estado)
        {
            return SIFDatos.ReportesArdmin.Comercializacion.BuscarSaldosPorEstado(estado);
        }

        public List<ComercializacionMod> BuscarFacturasPorEstado(string estado)
        {
            return SIFDatos.ReportesArdmin.Comercializacion.BuscarFacturasPorEstado(estado);
        }

        public BindingListView<SIFModelo.ReportesAdmin.ComercializacionMod> CargaClientesConvenio()
        {
            ListClientes = new BindingListView<SIFModelo.ReportesAdmin.ComercializacionMod>(SIFDatos.ReportesArdmin.Comercializacion.CargaClientesConvenio());
            return ListClientes;
        }

        public bool GuardarFacturaConvenio(ComercializacionMod factura)
        {
            return SIFDatos.ReportesArdmin.Comercializacion.InsertarFacturaConvenio(factura);
        }

        public List<ComercializacionMod> ObtenerFacturasConvenio()
        {
            return SIFDatos.ReportesArdmin.Comercializacion.ObtenerFacturasConvenio();
        }

        public bool CancelarFacturaConvenio(ComercializacionMod factura)
        {
            return SIFDatos.ReportesArdmin.Comercializacion.CancelarFacturaConvenio(factura);
        }

        public static bool InsertarNuevoSaldo(PeriodoSaldo datos)
        {
            return SIFDatos.ReportesArdmin.Comercializacion.InsertarSaldoCliente(datos);
        }

        public List<Saldos> ObtenerSaldosConvenio()
        {
            return SIFDatos.ReportesArdmin.Comercializacion.ObtenerSaldosConvenio();
        }

        public bool CancelarSaldosConvenio(Saldos saldo)
        {
            return SIFDatos.ReportesArdmin.Comercializacion.CancelarSaldosConvenio(saldo);
        }

        public bool ActualizarSaldoCredito(Saldos saldo)
        {
            return SIFDatos.ReportesArdmin.Comercializacion.ActualizarSaldoCredito(saldo);
        }

        public SaldoAutomatizado ObtenerSaldoPorCliente(int clienteId)
        {
            return SIFDatos.ReportesArdmin.Comercializacion.ObtenerSaldoPorCliente(clienteId);
        }

        public bool CerrarSaldosConvenio(Saldos saldo)
        {
            return SIFDatos.ReportesArdmin.Comercializacion.CerrarSaldosConvenio(saldo);
        }

        public bool CerrarFacturasConvenio(ComercializacionMod factura)
        {
            return SIFDatos.ReportesArdmin.Comercializacion.CerrarFacturas(factura);
        }

        public bool ActualizarFactura(ComercializacionMod factura)
        {
            return SIFDatos.ReportesArdmin.Comercializacion.ActualizarFactura(factura);
        }
    }
}
