using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio.Extras
{
    public class Estado
    {
        public List<SIFModelo.Extras.Estado> Estados = new List<SIFModelo.Extras.Estado>();

        public List<SIFModelo.Extras.Estado> CargaEstados()
        {
            return SIFDatos.Extras.Estado.CargaEstados();
        }

        public List<SIFModelo.Extras.Municipio> CargaMunicipios(SIFModelo.Extras.Estado estado)
        {
            return SIFDatos.Extras.Estado.CargaMunicipios(estado);
        }

        public List<SIFModelo.Extras.Colonia> CargaColonias(SIFModelo.Extras.Municipio municipio)
        {
            return SIFDatos.Extras.Estado.CargaColonias(municipio);
        }

        public List<SIFModelo.Extras.Colonia> CargaColoniasPorEstado(SIFModelo.Extras.Municipio municipio)
        {
            return SIFDatos.Extras.Estado.CargaColoniasPorEstado(municipio);
        }

        public List<SIFModelo.Extras.CPS> CargaCPS(SIFModelo.Extras.Colonia colonia)
        {
            return SIFDatos.Extras.Estado.CargaCPS(colonia);
        }
    }
}
