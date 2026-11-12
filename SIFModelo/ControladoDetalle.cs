using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class ControladoDetalle
    {
        public int SucursalID
        {
            get;
            set;
        }

        public string Folio
        {
            get;
            set;
        }

        public int NumeroPartida
        {
            get;
            set;
        }

        public string ArticuloID
        {
            get;
            set;
        }

        public string Nombre1
        {
            get;
            set;
        }

        public string Nombre2
        {
            get;
            set;
        }

        public int Cantidad
        {
            get;
            set;
        }

        public decimal Precio
        {
            get;
            set;
        }


        public decimal IVA
        {
            get;
            set;
        }

        public int ImpuestoID
        {
            get;
            set;
        }

        public int DescuentoID
        {
            get;
            set;
        }

        public decimal PrecioCosto
        {
            get;
            set;
        }

        public SIFModelo.Tipos.TipoActivoControlado Activo
        {
            get;
            set;
        }


    }
}
