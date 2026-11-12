using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.ReportesAdmin
{
    public class reportesUsuarios
    {

        public int id   {get;set;}
        public string nombre {get;set;}
        public string q_desc { get; set; }
        public string query  {get;set;}
        public string param1 { get; set; }
        public string param2 { get; set; }
        public string activo { get;set;}
        public string colums_name {get;set;}
        public string requiereFechas { get; set; }
        public string tipo_reporte { get; set; }
        public string tipo_ususario { get; set; }



    }
}
