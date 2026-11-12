using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Medico
    {
        public int ID
        { 
            get; 
            set; 
        }

        public string Nombre
        {
            get;
            set;
        }

        public string CedulaProfesional
        {
            get;
            set;
        }

        public string RegistroSSA
        {
            get;
            set;
        }

        /*public int EspecialidadID
        {
            get;
            set;
        }*/
       
        public string EspecialidadNombre
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Tipo de consulta médica TIPO_DIR
        /// </summary>
        public Tipos.TipoConsulta TipoConsulta
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
        /// Define si da consultas en la farmacia
        /// </summary>
        public Tipos.SiNo ConsultaFarmacia
        {
            get;
            set;
        }

        public Tipos.SiNo Activo
        {
            get;
            set;
        }
    }
}
