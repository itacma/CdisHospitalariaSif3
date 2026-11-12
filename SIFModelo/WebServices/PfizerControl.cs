using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.WebServices
{
    public class PfizerControl
    {

        public string NO_REMISION
        {
            get;
            set;
        }

        public int CADENA_ID
        {
            get;
            set;
        }

        public int SUCURSAL_ID
        {
            get;
            set;
        }

        public string USUARIO_ID
        {
            get;
            set;
        }

        public string NO_TARJETA
        {
            get;
            set;
        }

        public string COTIZACION_ID
        {
            get;
            set;
        }

        public DateTime FECHA_COMPRA
        {
            get;
            set;
        }

        public string NO_CONFIRMACION
        {
            get;
            set;
        }

        public DateTime FECHA_CONFIRMACION
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
