using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Pagos
    {
        public int ClienteID
        {
            get;
            set;
        }

        public int NumeroPago
        {
            get;
            set;
        }

        public int SucursalID
        {
            get;
            set;
        }
        public DateTime Fecha
        {
            get;
            set;
        }

        public int MonedaID
        {
            get;
            set;
        }

        public int TipoCambioID
        {
            get;
            set;
        }

        public decimal ImporteVenta
        {
            get;
            set;
        }
        public int TipoPagoID
        {
            get;
            set;
        }
        public int TipoPagoFacID
        {
            get;
            set;
        }
        public string DocumentoPago
        {
            get;
            set;
        }

        public int BancoID
        {
            get;
            set;
        }
        public int CajaID
        {
            get;
            set;
        }
        public int CajeroID
        {
            get;
            set;
        }
        public string RemisionID
        {
            get;
            set;
        }
        public Tipos.SiNo Activo
        {
            get;
            set;
        }
        public decimal ImporteIVA
        {
            get;
            set;
        }

        public decimal ImporteTotal
        {
            get;
            set;
        }


    }
}
