using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SIFNegocio.OrdenCompra
{
    public class OrdenCompraRecibe
    {

        public DataTable recepcionDatos = new DataTable();
        public DataTable SetRecepcionCompra(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow modelo)
        {
            recepcionDatos = SIFDatos.OrdenCompra.OrdenCompraRecibe.SetRecepcionCompra(Helpers.Sesion.Sucursal,modelo);
            return recepcionDatos;
        }



        public void SetRecepcionCompraTot(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow Compra)
        {
            SIFDatos.OrdenCompra.OrdenCompraRecibe.RecepcionCompraTot(Compra);
        }

        public SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow GetRecepcionCompraTot(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow Compra)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow cm = SIFDatos.OrdenCompra.OrdenCompraRecibe.GetRecepcionCompraTot(Compra);
            return cm;
        }
    }
}
