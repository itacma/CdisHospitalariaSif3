using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIFNegocio
{
    public class cotizacionesClienteMayoristaNg
    {
        public System.Data.DataSet BuscaCotizaciones(SIFModelo.Sucursal sucursal, SIFModelo.Cotizacion Cotizacion, string tipo)
        {
            System.Data.DataSet ds = SIFDatos.cotizacionesClienteMayorista.getCotizaciones(sucursal, Cotizacion, tipo);
            return ds;
        }
        public DataTable buscarArticulo(string cadena) {
            return SIFDatos.cotizacionesClienteMayorista.buscarArticuloDt(cadena);


        }
    }
}
