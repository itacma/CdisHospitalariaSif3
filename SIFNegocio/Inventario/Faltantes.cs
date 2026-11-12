using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio.Inventario
{
    public class Faltantes
    {
        public SIFModelo.Inventarios.InventarioDataSet DataSet = new SIFModelo.Inventarios.InventarioDataSet();

        public int FolioFalntante(SIFModelo.Sucursal sucursal)
        {
            return SIFDatos.Inventario.Faltantes.NumeroFaltante(sucursal.SucursalesID);
        }

        public bool InsertaFaltante(SIFModelo.Inventarios.InventarioDataSet.FALTANTERow faltante)
        {
            return SIFDatos.Inventario.Faltantes.InsertaFaltante(faltante);
        }

        public bool InsertaFaltanteDetalle(SIFModelo.Inventarios.InventarioDataSet.FALTANTE_DETRow detalle)
        {
            return SIFDatos.Inventario.Faltantes.InsertaFaltanteDetalle(detalle);
        }

    }
}
