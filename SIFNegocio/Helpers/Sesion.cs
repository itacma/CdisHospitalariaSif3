using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio.Helpers
{
   public static class Sesion
    {
       public static SIFModelo.Sucursal Sucursal {get; set;}
       public static SIFModelo.Usuario Usuario
       {
           get;
           set;
       }
    }
}
