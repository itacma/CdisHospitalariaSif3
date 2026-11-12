using System;
namespace SIF
{
    static class funciones
    {
        public static void Bitacora(String msg, int Opc, int Oper)
        {
            SIFNegocio.Seguridad.Bitacora bt = new SIFNegocio.Seguridad.Bitacora();
            bt.Ins(msg, Opc, Oper, Helpers.Sesion.Usuario.UsuariosID.ToString());
        }
    }
}