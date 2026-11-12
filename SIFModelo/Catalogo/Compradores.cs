using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Compradores
    {
        public int UsuarioID
        {
            get;
            set;
        }

        public SIFModelo.Tipos.SiNo Activo
        {
            get;
            set;
        }

        public string ListaSucursalID
        {
            get;
            set;
        }

        public Char Tipo
        {
            get;
            set;
        }

        public string ListaProveedorId
        {
            get;
            set;
        }

        public DateTime FechaAlta
        {
            get;
            set;
        }
        //<JQM 24032017
        public string Nombre { get; set; }
        public string AccesoId { get; set; }
        public string SActivo { get; set; }
        //>

    }
}
