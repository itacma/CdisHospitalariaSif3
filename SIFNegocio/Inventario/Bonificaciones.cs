using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace SIFNegocio.Inventario
{
    public class Bonificaciones
    {
        public SIFModelo.Inventarios.InventarioDataSet AjustesDataSet = new SIFModelo.Inventarios.InventarioDataSet();

        public SIFModelo.Inventarios.InventarioDataSet GetAjustes(DateTime fechaInicio, DateTime fechaFin, string Activo, string Folio)
        {
            return SIFDatos.Inventario.AjustesAlmacen.GetAjustes(fechaInicio.ToString("dd/MM/yyyy hh:mm:ss"), fechaFin.ToString("dd/MM/yyyy hh:mm:ss"), Activo, Folio);
        }
        public SIFModelo.Inventarios.InventarioDataSet GetAjustes(string Folio)
        {
            return SIFDatos.Inventario.AjustesAlmacen.GetAjustes(Folio, Helpers.Sesion.Sucursal);
        }

        public void InsInvAjuste(int Origen, int Destino, double Total,
                               string Tipo, string DocRef,
                               int[] Lote, int[] Sec, String[] ArtId,
                               String[] Nombre,
                               String[] Concepto, int[] Cant, double[] TotLote,
                               double[] Precio, double[] PrecioVta, SIFModelo.Usuario usuario)
        {
            SIFDatos.Inventario.AjustesAlmacen.InsInvAjuste(Origen, Destino, Total, Tipo, DocRef, Lote, Sec, ArtId, Nombre, Concepto, Cant, TotLote, Precio, PrecioVta, usuario);
        }

        public void UpdInvAjuste(string Folio, int Lote, int Origen, int Destino, string Tipo,
                               string DocRef, double Total,
                                int[] Sec, String[] ArtId, String[] Nombre,
                                String[] Concepto, int[] Cant,
                                double[] Precio, double[] PrecioVta)
        {
            SIFDatos.Inventario.AjustesAlmacen.UpdInvAjuste(Folio, Lote, Origen, Destino, Tipo, DocRef, Total, Sec, ArtId, Nombre, Concepto, Cant, Precio, PrecioVta);
        }

        public int AplicaAjuste(string Folio, int Lote, int Sucursal,
                                    String[] ArtId, int[] Cant, double[] Precio, string Tipo, string Usuario)
        {
            return SIFDatos.Inventario.AjustesAlmacen.AplicaAjuste(Folio, Lote, Sucursal, ArtId, Cant, Precio, Tipo, Usuario);
        }

        public int AplicaDevolucionProveedor(SIFModelo.DevolucionProveedor devProv, List<SIFModelo.DevolucionProveedorDetalle> devDetProv)
        {   /*string Folio, int Lote, int Sucursal,
                                    String[] ArtId, int[] Cant, double[] Precio, string Tipo, string Usuario)*/

            return SIFDatos.Inventario.AjustesAlmacen.AplicaDevProveedor(devProv, devDetProv);
        }

        public int AplicaReposicionProveedor(SIFModelo.ReposisionProveedor devProv, List<SIFModelo.ReposisionProveedorDetalle> devDetProv)
        {
            return SIFDatos.Inventario.AjustesAlmacen.AplicaRepProveedor(devProv, devDetProv);
        }
        public string AplicaBonificacion(string Folio, string Lote,  string Usuario)
        {
           return  SIFDatos.Inventario.BonificacionesAlmacen.AplicaBonificacion (Folio,  Lote, Usuario);
        }
        public void AplicaReposicion(string Folio, string Usuario)
        {
            SIFDatos.Inventario.BonificacionesAlmacen.AplicaReposicion(Folio, Usuario);
        }
        public string ObtieneBonificacion(string Folio,string lote,int mov)
        {
            return SIFDatos.Inventario.BonificacionesAlmacen.VerificarProcesados(Folio,lote,mov);
        }
        public string ObtieneReposicion(string Folio,string lote, int mov)
        {
            return SIFDatos.Inventario.BonificacionesAlmacen.VerificarProcesados(Folio,lote, mov);
        }
        public void AplicaDevolucionProv(string Folio, string Lote, string Usuario)
        {
            SIFDatos.Inventario.BonificacionesAlmacen.AplicaDevolucionProv(Folio, Usuario);
        }
        public void AplicaReposicionProv(string Folio, string Lote, string Usuario)
        {
            SIFDatos.Inventario.BonificacionesAlmacen.AplicaReposicionProv(Folio, Usuario);
        }
        public List<SIFModelo.DevolucionProveedorDetalle> cargaDevProv(string Folio)
        {
            return SIFDatos.Inventario.BonificacionesAlmacen.cargaDevProv(Folio);
        }

        public List<SIFModelo.ReposisionProveedorDetalle> cargaRepProv(string Folio)
        {
            return SIFDatos.Inventario.BonificacionesAlmacen.cargaRepProv(Folio);
        }
        
        
        //public SIFModelo.Inventarios.InventarioDataSet.AJUSTESRow AjustePorFolio(string AjusteID)
        //{
        //    return SIFDatos.Inventario.AjustesAlmacen.AjustePorFolio(AjusteID);
        //}
    }

}
