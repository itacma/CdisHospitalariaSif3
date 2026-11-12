using SIFDatos.OrdenCompra;
using SIFModelo.OrdenCompra;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using static SIFDatos.OrdenCompra.NotasDeCredito;

namespace SIFNegocio.OrdenCompra
{
   public class NotasDecredito
    {
        public DataSet getNotasCredito(string p_Ini, string p_Fin, String p_folio, string p_activo)
        {

            return SIFDatos.OrdenCompra.NotasDeCredito.getNotasCredito( p_Ini,  p_Fin,  p_folio,  p_activo);

        }
        public String insNotaDeCredtio(
              string p_Usuario_id,
                             string p_motivo,
                             String p_fecha_inicio,
                             string p_fecha_fin,
                             Decimal[] p_proveedor,
                             Decimal[] partida,
                             Decimal[] SaldoTotal,
                             String[] concepto,
                             String[] FolioFiscal,
                             decimal subtotal,
                             decimal iva
            )
        {

            return SIFDatos.OrdenCompra.NotasDeCredito.insNotaDeCredtio(
                p_Usuario_id,
                   p_motivo,
                              p_fecha_inicio,
                             p_fecha_fin,
                              p_proveedor,
                             partida,
                             SaldoTotal,
                             concepto,
                             FolioFiscal,
                             subtotal,
                             iva

                );

        }

        public DataSet getNotasCreditoVigentes()
        {
            return SIFDatos.OrdenCompra.NotasDeCredito.getNotasCreditoVigentes();
        }

        public string insertaRelacionNC(TipoNcSaldoUtilizado modelo)
        {
            return SIFDatos.OrdenCompra.NotasDeCredito.insertaRelacionNC(modelo);
        }
        public string GetSaldoRequeridoOC(string  rdm)
        {
            return SIFDatos.OrdenCompra.NotasDeCredito.GetSaldoRequeridoOC(rdm);
        }

        public void ActualizarEstadoNotaDeCredito(string folio, string estado)       
        {
            SIFDatos.OrdenCompra.NotasDeCredito.ActualizarEstadoNotaDeCredito(folio,estado);
        }

        public static DatosFolio ObtenerDatosFolio(string folio)
        {
            return SIFDatos.OrdenCompra.NotasDeCredito.ObtenerDatosFolio(folio);
        }

        public void ActualizarDatosFolio(string folio, DateTime fechaInicio, DateTime fechaFin, decimal subtotal, string cfdi, decimal iva, decimal total)
        {
            SIFDatos.OrdenCompra.NotasDeCredito.ActualizarDatosFolio(folio, fechaInicio, fechaFin, subtotal, cfdi, iva, total);
        }
    }
}
