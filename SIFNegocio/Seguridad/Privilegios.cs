using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;


namespace SIFNegocio.Seguridad
{
    public class Privilegios
    {
        public SIFModelo.Seguridad.Seguridad SeguridadDataSet = new SIFModelo.Seguridad.Seguridad();

        public SIFModelo.Seguridad.Seguridad Get(SIFModelo.Seguridad.Seguridad ds,String UsuarioID)
        {
            return SIFDatos.Seguridad.Privilegios.Get(ds,UsuarioID);
        }

        public SIFModelo.Seguridad.Seguridad Update(SIFModelo.Seguridad.Seguridad ds,String UsuarioID)
        {
            return SIFDatos.Seguridad.Privilegios.Update(ds, UsuarioID);
        }

        public void verifica(ItemContainer Contenedor, String UsuarioID)
        {
            foreach (MetroTileItem OB in Contenedor.SubItems)
            {
                OB.Enabled = SIFDatos.Seguridad.Privilegios.Verifica(OB, UsuarioID);
            }
        }
        public void verifica(MetroTileItem Contenedor, String UsuarioID)
        {
            Contenedor.Enabled = SIFDatos.Seguridad.Privilegios.Verifica(Contenedor, UsuarioID);           
        }
        public void verificaOpc(ItemContainer Contenedor, String UsuarioID,int Modulo)
        {
            foreach (MetroTileItem OB in Contenedor.SubItems)
            {
                OB.Enabled = SIFDatos.Seguridad.Privilegios.VerificaOpc(OB, UsuarioID, Modulo);
            }
        }
        public void verificaOpc(MetroTileItem OP, String UsuarioID, int Modulo)
        {

            OP.Enabled = SIFDatos.Seguridad.Privilegios.VerificaOpc(OP, UsuarioID, Modulo);
            
        }
        public Boolean VerificaOperacion(String UsuarioID, int Opcion, int Operacion)
        {

            return SIFDatos.Seguridad.Privilegios.VerificaOperacion(UsuarioID,Opcion,Operacion);

        }
        public Int32 VerificaAccesoIngreso(string pacceso_id, string ppass, out string pmensajeOut)
        {
            pmensajeOut = "";
            string outintermedio="";
            Int32 G= SIFDatos.Seguridad.Privilegios.VerificaAccesoIngreso(pacceso_id, ppass, out outintermedio);
            pmensajeOut = outintermedio;
            return G;

        }
        
    }

}
