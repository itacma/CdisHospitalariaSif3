using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Catalogo
{
    public class RecoleccionValores
    {
        public int SEC
        {
            get;
            set;
        }

        public int SUCURSAL_ID
        {
            get;
            set;
        }

        public int CAJA_ID
        {
            get;
            set;
        }

        public int CAJERO_ID
        {
            get;
            set;
        }

        public string RECOLECCION_NOMBRE
        {
            get;
            set;
        }

        public int DENOMINACIONES_ID
        {
            get;
            set;
        }

        public decimal CANTIDAD
        {
            get;
            set;
        }

        public decimal IMPORTE
        {
            get;set;
        }

        public decimal TOTAL
        {
            get;
            set;
        }

        public DateTime FECHA
        {
            get;
            set;
        }

        public int SUPERVISOR
        {
            get;
            set;
        }

        public SIFModelo.Tipos.SiNo ACTIVO
        {
            get;
            set;
        }
    }
}
