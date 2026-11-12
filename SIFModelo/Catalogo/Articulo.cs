using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Articulo
    {
        public string ARTICULO_ID
        {
            get;
            set;
        }

        public int CODIGO_CLI_ID
        {
            get;
            set;
        }

        public string CODIGO_CLI
        {
            get;
            set;
        }
        /// <summary>
        /// Estado activo o inactivo
        /// </summary>
        public Tipos.SiNo ACTIVO
        {
            get;
            set;
        }

        public int TIPO_MONEDA
        {
            get;
            set;
        }

        public string NOMBRE1
        {
            get;
            set;
        }


        public string NOMBRE2
        {
            get;
            set;
        }

        public string TIPO_MEDICAMENTO_CVE
        {
            get;
            set;
        }

        public int LABORATORIO_ID
        {
            get;
            set;
        }

        public string LABORATORIO_NOMBRE
        {
            get;
            set;
        }

        public int PROVEEDOR_ID
        {
            get;
            set;
        }

        public string PROVEEDOR_NOMBRE
        {
            get;
            set;
        }

        public string U_COMPRA
        {
            get;
            set;
        }

        public string U_VENTA
        {
            get;
            set;
        }


        public string LISTA_SUCURSAL_VTA
        {
            get;
            set;
        }

        public Tipos.SiNo PAQUETE
        {
            get;
            set;
        }

        public Tipos.SiNo CONTROLADO { get; set; }

        public Tipos.SiNo VTA_SIN_EXISTENCIA
        {
            get;
            set;
        }

        public string FactorID { get; set; }
        public int cMayorista { get; set; }//JOMAQC 26/09/2018 se integra para ver quien es su comprador mayorista en caso de que lo tenga
    }
}
