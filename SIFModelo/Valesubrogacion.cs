using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Valesubrogacion
    {
        public int SucursalId
        {
            get;
            set;
        }
        public Int32 ID
        {
            get;
            set;
        }

        public String NoRemision
        {
            get;
            set;
        }

        public String NoVale
        {
            get;
            set;
        }

        public DateTime FechaVale
        {
            get;
            set;
        }

        public DateTime FechaRecepcion
        {
            get;
            set;
        }


        public string Tipo { get; set; }
    }
}
