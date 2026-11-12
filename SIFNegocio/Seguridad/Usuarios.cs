using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace SIFNegocio.Seguridad
{
    public class Usuarios
    {
        public SIFModelo.Seguridad.Seguridad SeguridadDataSet = new SIFModelo.Seguridad.Seguridad();

        public SIFModelo.Seguridad.Seguridad Get(SIFModelo.Seguridad.Seguridad ds)
        {
            return SIFDatos.Seguridad.Usuarios.Get(ds);
        }

        public SIFModelo.Seguridad.Seguridad Update(SIFModelo.Seguridad.Seguridad ds)
        {
            return SIFDatos.Seguridad.Usuarios.Update(ds);
        }
     }

}
