using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio
{
    public class OfertasCompras
    {
        public SIFModelo.Catalogo.CatalogoDataSet.OFERTAS_COMPRAS_MAYORISTADataTable Buscar(string parametroBusqueda, SIFModelo.Sucursal sucursal, SIFModelo.Cliente proveedor, string propiedadBusqueda)
        {
            OfertasMayoritsta = SIFDatos.OfertasCompras.Buscar(parametroBusqueda, sucursal, proveedor, propiedadBusqueda);
            return OfertasMayoritsta;
        }

        public SIFModelo.Catalogo.CatalogoDataSet.OFERTAS_COMPRAS_MAYORISTADataTable OfertasMayoritsta { get; set; }

        public bool Modificar(SIFModelo.Catalogo.CatalogoDataSet.OFERTAS_COMPRAS_MAYORISTARow Ofertas)
        {

            return SIFDatos.OfertasCompras.Modificar(Ofertas);
        }
    }
}
