using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Configuracion
{
    public class Factura
    {
        private string usuarioFEL;
        public string UsuarioFEL
        {
            get { return usuarioFEL; }
            set { usuarioFEL = value; }
        }

        private string passwordFEL;
        public string PasswordFEL
        {
            get { return passwordFEL; }
            set {passwordFEL = value;}
        }

        private String directorioFacturas;
        public string DirectorioFacturas
        {
            get { return directorioFacturas; }
            set{ directorioFacturas = value;}
        }

        private string rfcEmisor;
        public string RFCEmisor
        {
            get { return rfcEmisor; }
            set{rfcEmisor =  value;}
        }

        private string actividadEmpresarial;
        public string ActividadEmpresarial
        {
            get { return actividadEmpresarial; }
            set { actividadEmpresarial = value; }
        }

        public string PaginaWEB { get; set; }

        public string Email { get; set; }

        private string tipoPago;
        public string TipoPago { get { return tipoPago; } set { tipoPago = value; } }

        //public string MetodoDePago { get; set; }
    }
}
