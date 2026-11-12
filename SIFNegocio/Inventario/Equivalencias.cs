using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace SIFNegocio.Inventario
{
    public class Equivalencias
    {
        public SIFModelo.Inventarios.InventarioDataSet AjustesDataSet = new SIFModelo.Inventarios.InventarioDataSet();

        public SIFModelo.Inventarios.InventarioDataSet GetEquivalencias(SIFModelo.Inventarios.InventarioDataSet ds)
        {
            return SIFDatos.Inventario.Equivalencias.Get(ds);
        }

        public SIFModelo.Inventarios.InventarioDataSet Update(SIFModelo.Inventarios.InventarioDataSet ds)
        {
            return SIFDatos.Inventario.Equivalencias.Update(ds);
        }
     }

}
