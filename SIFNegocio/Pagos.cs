using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio
{
    public class Pagos
    {
        internal SIFModelo.Pagos PagoPorRemision(SIFModelo.Remision remision)
        {
            return SIFDatos.Pagos.PagoPorRemision(remision);
        }

        public bool Abona(SIFModelo.Pagos pago)
        {
            return SIFDatos.Pagos.Inserta(pago);
        }
        
        public bool AbonaBulk(SIFModelo.Pagos pago, List<SIFModelo.PagosDetalle> detalles)
        {
            return SIFDatos.Pagos.InsertaPagosBulk(pago, detalles);//Inserta en pagos y pagos_det
        }

        public bool PagoDetalle(SIFModelo.PagosDetalle pagoDetalle)
        {
            return SIFDatos.Pagos.InsertaDetalle(pagoDetalle);
        }

        public SIFModelo.Ventas.CorteCajaDataSet.V_PAGOS_DETALLEDataTable BuscaPagosDetalle(SIFModelo.Caja caja, DateTime Fecha1, DateTime fecha2)
        {
            string sfecha1 = Fecha1.ToString("dd/MM/yyyy HH:mm:ss");
            string sfecha2 = fecha2.ToString("dd/MM/yyyy HH:mm:ss");
            return SIFDatos.Pagos.BuscaPagosDetalle(caja, sfecha1, sfecha2);
        }

        public SIFModelo.Ventas.CorteCajaDataSet.V_PAGOS_CONDENSADODataTable BuscaPagosCondensado(SIFModelo.Caja caja, DateTime Fecha1, DateTime fecha2)
        {
            string sfecha1 = Fecha1.ToString("dd/MM/yyyy HH:mm:ss");
            string sfecha2 = fecha2.ToString("dd/MM/yyyy HH:mm:ss");

            return SIFDatos.Pagos.BuscaPagosDetalleConglomerado(caja, sfecha1, sfecha2);
        }

        public SIFModelo.Pagos Pago(SIFModelo.Remision remision)
        {
            return SIFDatos.Pagos.PagoPorRemision(remision);
        }
    }
}
