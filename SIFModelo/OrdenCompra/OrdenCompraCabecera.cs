using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.OrdenCompra
{
    public class OrdenCompraCabecera
    {
        public string FolioOrdenCompra
        {
            get;
            set;
        }

        public string UsuarioID
        {
            get;
            set;
        }

        public int ProveedorID
        {
            get;
            set;
        }

        public string ProveedorNombre
        {
            get;
            set;
        }

        public int SucursalID
        {
            get;
            set;
        }

        public string SucursalNombre
        {
            get;
            set;
        }

        public List<SIFModelo.OrdenCompra.OrdenCompraDataSet> OrdenesCompra
        {
            get;
            set;
        }

    }
}
