using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;


namespace SIFNegocio.Seguridad
{
    public class Bitacora
    {
        public SIFModelo.Seguridad.Seguridad SeguridadDataSet = new SIFModelo.Seguridad.Seguridad();

        public SIFModelo.Seguridad.Seguridad Get(String Fecini, String FecFin, SIFModelo.Seguridad.Seguridad ds, String UsuarioID)
        {
            return SIFDatos.Seguridad.Bitacora.Get(Fecini, FecFin, ds, UsuarioID);
        }

        public void Ins(String Comentario, int Opcion_id, int Operacion_ID, String UsuarioId)
        {
             SIFDatos.Seguridad.Bitacora.Insert(Comentario, Opcion_id, Operacion_ID, UsuarioId);
        }
    }
}
