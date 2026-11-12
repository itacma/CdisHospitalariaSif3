using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.WebServices
{
    public class Nadro
    {
        public int NadroID
        {
            get;
            set;
        }

        public string NumeroRemision
        {
            get;
            set;
        }

        public int CadenaID
        {
            get;
            set;
        }
        public int SucursalID
        {
            get;
            set;
        }

        public int UsuarioID
        {
            get;
            set;
        }

        public string NumeroTarjeta
        {
            get;
            set;
        }

        public string CotizacionID
        {
            get;
            set;
        }

        public DateTime FechaCompra
        {
            get;
            set;
        }

        public string NumeroConfirmacion
        {
            get;
            set;
        }

        public DateTime FechaConfirmacion
        {
            get;
            set;
        }

        public Tipos.SiNo Activo
        {
            get;
            set;
        }

        public string CedulaProfesionalMedico
        {
            get;
            set;
        }

        public decimal iva
        {
            get;
            set;
        }
    }
}
