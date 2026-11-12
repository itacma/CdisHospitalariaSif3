using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace SIFNegocio.Seguridad
{
    public class TiposUsuarios
    {
        public SIFModelo.Seguridad.Seguridad SeguridadDataSet = new SIFModelo.Seguridad.Seguridad();

        public SIFModelo.Seguridad.Seguridad Get(SIFModelo.Seguridad.Seguridad ds)
        {
            return SIFDatos.Seguridad.TiposUsuario.Get(ds);
        }

        public SIFModelo.Seguridad.Seguridad Update(SIFModelo.Seguridad.Seguridad ds)
        {
            return SIFDatos.Seguridad.TiposUsuario.Update(ds);
        }
     }

}
