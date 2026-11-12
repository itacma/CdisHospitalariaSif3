using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace SIFNegocio.Almacen
{
    public class Bultos
    {
        public SIFModelo.Inventarios.InventarioDataSet AjustesDataSet = new SIFModelo.Inventarios.InventarioDataSet();

        public SIFModelo.Inventarios.InventarioDataSet Get(SIFModelo.Inventarios.InventarioDataSet ds)
        {
            return SIFDatos.Almacen.Bultos.Get(ds);
        }

        public SIFModelo.Inventarios.InventarioDataSet Update(SIFModelo.Inventarios.InventarioDataSet ds)
        {
            return SIFDatos.Almacen.Bultos.Update(ds);
        }
     }

}
