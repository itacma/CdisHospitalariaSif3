using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class ValeDevolucion
    {
        public int VALES_DEV_ID
        {
            get;
            set;
        }

        public int SUCURSAL_ID
        {
            get;
            set;
        }

        public string REMISION_ID
        {
            get;
            set;
        }

        public DateTime FECHA_EMISION
        {
            get;
            set;
        }

        public DateTime FECHA_VIGENCIA
        {

            get;
            set;
        }

        public int USUARIO_ID
        {
            get;
            set;
        }

        public int USER_AUTORIZA
        {
            get;
            set;
        }

        public int MOTIVO_ID
        {
            get;
            set;
        }

        public string OBSERVACIONES
        {
            get;
            set;
        }

        public string STATUS
        {
            get;
            set;
        }

        public string SUCURSAL_NOMBRE
        {
            get;
            set;
        }

        public string USUARIO_NOMBRE
        {
            get;
            set;
        }

        public string USUARIO_AUTORIZA_NOMBRE
        {
            get;
            set;
        }

        public string MOTIVO_NOMBRE
        {
            get;
            set;
        }
    }
}
