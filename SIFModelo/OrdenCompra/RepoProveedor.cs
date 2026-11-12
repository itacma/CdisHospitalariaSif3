using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.OrdenCompra
{
    public class RepoProveedor
    {
        public string ARTICULO_ID
        {
            get;
            set;
        }

        public string NOMBRE
        {
            get;
            set;
        }

        public int CANT_FACTURADA
        {
            get;
            set;
        }
        public int CANT_RECIBIDA
        {
            get;
            set;
        }
        public string CODIGO_PROVEEDOR
        {
            get;
            set;
        }

        public decimal COSTO_NETO_UNIT_REC
        {
            get;
            set;
        }

        public string FOLIO_COMPRA
        {
            get;
            set;
        }

        public string FOLIO_OC
        {
            get;
            set;
        }
        public decimal IMPORTE_IEPS
        {
            get;
            set;
        }
        public decimal IMPORTE_IVA
        {
            get;
            set;
        }
        public decimal PORC_IVA
        {
            get;
            set;
        }

        public decimal PRECIO_FLEMING
        {
            get;
            set;
        }
        public decimal PRECIO_MAXIMO
        {
            get;
            set;
        }
        public decimal PRECIO_VENTA
        {
            get;
            set;
        }
        public string TIPO_MEDICAMENTO
        {
            get;
            set;
        }
        public string LABORATORIO_ID
        {
            get;
            set;
        }
        public decimal CANT_REPOSICION
        {
            get;
            set;
        }
    }
}
