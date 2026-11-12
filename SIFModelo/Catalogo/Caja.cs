using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Caja
    {
        public int ID
        {
            get;
            set;
        }

        public int AperturaCajaID
        {
            get;
            set;
        }

        public int SucursalID
        {
            get;
            set;
        }

        public int CajeroID
        {
            get;
            set;
        }

        public string SucursalNombre
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public Tipos.SiNo Activo
        {
            get;
            set;
        }

        public Tipos.AbiertoCerrado Abierto
        {
            get;
            set;
        }

        public DateTime FechaApertura
        {
            get;
            set;
        }

        public DateTime? FechaCierre
        {
            get;
            set;
        }

        public decimal MontoInicial
        {
            get;
            set;
        }


        public string NombreUsuario
        {
            get;
            set;
        }

        public int ControlCajaID
        {
            get;
            set;
        }

    }
}
