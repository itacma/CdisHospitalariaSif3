using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class DireccionMedico
    {
        public int ID
        {
            get;
            set;
        }

        public int MedicoID
        {
            get;
            set;
        }

        public Tipos.TipoConsulta TipoDireccion
        {
            get;
            set;
        }


        public string Calle
        {
            get;
            set;
        }

        public string Colonia
        {
            get;
            set;
        }

        public string CodigoPostal
        {
            get;
            set;
        }

        public string Ciudad
        {
            get;
            set;
        }

        public string NumeroExterior
        {
            get;
            set;
        }

        public string NumeroInterior
        {
            get;
            set;
        }

        public string Municipio
        {
            get;
            set;
        }
        
        public string Telefono
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }
    }
}
