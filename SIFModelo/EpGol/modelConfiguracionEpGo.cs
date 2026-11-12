using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.EpGo
{
    public class modelConfiguracionEpGo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Jwttoken { get; set; }
        public string User_name { get; set; }
        public string Password { get; set; }
        public string Activo { get; set; }

        public string _baseUrl { get; set; }



    }
}
