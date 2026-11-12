using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    /// <summary>
    /// Especialidad Medica
    /// </summary>
   public class Especialidad
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

       public Tipos.SiNo Activo
       {
           get;
           set;
       }

    }
}
