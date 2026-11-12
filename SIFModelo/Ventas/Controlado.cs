using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Controlado
    {
        public int SucursalId
        {
            get;
            set;
        }

        public string Folio
        {
            get;
            set;
        }

        public int MedicoID
        {
            get;
            set;
        }

        public DateTime FechaEntrega
        {
            get;
            set;
        }

        public int UsuarioID
        {
            get;
            set;
        }

        public string RemisionID
        {
            get;
            set;
        }

        public Tipos.TipoActivoControlado Activo
        {
            get;
            set;
        }

        public Tipos.SiNo Receta
        {
            get;
            set;
        }

        public Tipos.SiNo Retiene
        {
            get;
            set;
        }


        public int EntregaID
        {
            get;
            set;
        }


        public List<SIFModelo.ControladoDetalle> Detalles { get; set; }

        public string FolioAntibiotico { get; set; }
    }
}
