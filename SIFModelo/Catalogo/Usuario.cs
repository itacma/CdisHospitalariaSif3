using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Usuario
    {
        public int UsuariosID
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public string Apellidos
        {
            get;
            set;
        }

        public string AccesoID
        {
            get;
            set;
        }

        public Tipos.SiNo Activo
        {
            get;
            set;
        }

        public string Contrasena
        {
            get;
            set;
        }

        public int SucursalID
        {
            get;
            set;
        }

        public Tipos.TipoUsuario TipoUsuario
        {
            get;
            set;
        }

        public DateTime FechaAlta
        {
            get;
            set;
        }
        public DateTime? FechaBaja
        {
            get;
            set;
        }

        /// <summary>
        /// El sexo o genero del usuario Masculino o Femenimo
        /// </summary>
        public Tipos.Genero Genero
        {
            get;
            set;
        }
        

        public DateTime? Fecha_vigencia_passw
        {
            get;
            set;
        }
        public int ingresosErroneos 
        {
            get;
            set;
        }
        public DateTime? fechaUltAcceso
        {
            get;
            set;
        }

    }
}
