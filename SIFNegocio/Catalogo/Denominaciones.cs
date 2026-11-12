using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio.Catalogo
{
    public class Denominaciones
    {
        public SIFModelo.Catalogo.CatalogoDataSet.DENOMINACIONESDataTable CargaDenominaciones()
        {
            return SIFDatos.Denominaciones.CargaDenominaciones();
        }


        public SIFModelo.Catalogo.CatalogoDataSet.DENOMINACIONESRow DenominacionPorID(int p)
        {
            return SIFDatos.Denominaciones.CargaDenominacionesPorId(p);
        }
    }
}
