using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SIFNegocio.OrdenCompra
{
    public class AjusteInventario
    {
         public DataSet Ajustes(string Folio, DateTime fecha1, DateTime fecha2)
        {
            return SIFDatos.OrdenCompra.AjusteInventario.Busca(Folio, fecha1, fecha2);
        }

        public bool InsertaAjuste(SIFModelo.OrdenCompra.OrdenesCompraDataSet.AJUSTESRow bonificacion, SIFModelo.OrdenCompra.OrdenesCompraDataSet.AJUSTES_DETDataTable detalles)
        {
          bool insertado =  SIFDatos.OrdenCompra.AjusteInventario.Inserta(bonificacion);
          if (insertado)
          {
              foreach (var detalle in detalles)
              {
                  detalle.LOTE = bonificacion.LOTE;
                  detalle.FOLIO = bonificacion.FOLIO;
                  detalle.SUCURSAL_ID = bonificacion.SUCURSAL_ID;

                  SIFDatos.OrdenCompra.AjusteInventario.InsertaDetalle(detalle);
              }
          }
            return insertado;
        }

        public string FolioAjusteInventario(int sucursal)
        {
            string prefijoFolio = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yy");
            int folio = SIFDatos.OrdenCompra.AjusteInventario.GeneraFolio(sucursal, prefijoFolio);

            string sb = sucursal.ToString("00") + prefijoFolio + folio.ToString().PadLeft(11, '0'); ;
            return sb;
        }
    }
}
