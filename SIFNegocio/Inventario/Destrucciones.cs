using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace SIFNegocio.Inventario
{
    public class Destrucciones
    {
        public SIFModelo.Inventarios.InventarioDataSet DestruccionesDataSet = new SIFModelo.Inventarios.InventarioDataSet();

        public SIFModelo.Inventarios.InventarioDataSet GetDestrucciones(DateTime fechaInicio, DateTime fechaFin, string Activo, string Folio)
        {
            return SIFDatos.Inventario.DestruccionesAlmacen.GetDestrucciones(fechaInicio.ToString("dd/MM/yyyy hh:mm:ss"), fechaFin.ToString("dd/MM/yyyy hh:mm:ss"), Activo, Folio);
        }
        public SIFModelo.Inventarios.InventarioDataSet GetDestrucciones(string Folio)
        {
            return SIFDatos.Inventario.DestruccionesAlmacen.GetDestrucciones(Folio, Helpers.Sesion.Sucursal);
        }

        public void InsInvAjuste(int Origen, int Destino, double Total,
                               string Tipo, string DocRef,
                               int[] Lote, int[] Sec, String[] ArtId,
                               String[] Nombre,
                               String[] Concepto, int[] Cant, double[] TotLote,
                               double[] Precio, double[] PrecioVta, SIFModelo.Usuario usuario)
        {
            //SIFDatos.Inventario.AjustesAlmacen.InsInvAjuste(Origen, Destino, Total, Tipo, DocRef, Lote, Sec, ArtId, Nombre, Concepto, Cant, TotLote, Precio, PrecioVta, usuario);
            SIFDatos.Inventario.DestruccionesAlmacen.InsInvDestruccion(Origen, Destino, Total, Tipo, DocRef, Lote, Sec, ArtId, Nombre, Concepto, Cant, TotLote, Precio, PrecioVta, usuario);
        }

        public void UpdInvAjuste(string Folio, int Lote, int Origen, int Destino, string Tipo,
                               string DocRef, double Total,
                                int[] Sec, String[] ArtId, String[] Nombre,
                                String[] Concepto, int[] Cant,
                                double[] Precio, double[] PrecioVta)
        {
            //SIFDatos.Inventario.AjustesAlmacen.UpdInvAjuste(Folio, Lote, Origen, Destino, Tipo, DocRef, Total, Sec, ArtId, Nombre, Concepto, Cant, Precio, PrecioVta);
            SIFDatos.Inventario.DestruccionesAlmacen.UpdInvDestruccion(Folio, Lote, Origen, Destino, Tipo, DocRef, Total, Sec, ArtId, Nombre, Concepto, Cant, Precio, PrecioVta);
        }

        public int AplicaAjuste(string Folio, int Lote, int Sucursal,
                                    String[] ArtId, int[] Cant, double[] Precio, string Tipo, string Usuario)
        {
           // return SIFDatos.Inventario.AjustesAlmacen.AplicaAjuste(Folio, Lote, Sucursal, ArtId, Cant, Precio, Tipo, Usuario);
            return SIFDatos.Inventario.DestruccionesAlmacen.AplicaDestruccion(Folio, Lote, Sucursal, ArtId, Cant, Precio, Tipo, Usuario);
        }
        public int AplicaAjuste22(string Folio, int Lote, int Sucursal, string Tipo, string Usuario)
        {
            // return SIFDatos.Inventario.AjustesAlmacen.AplicaAjuste(Folio, Lote, Sucursal, ArtId, Cant, Precio, Tipo, Usuario);
            return SIFDatos.Inventario.DestruccionesAlmacen.AplicaDestruccion22(Folio, Lote, Sucursal, Tipo, Usuario);
        }

        //public SIFModelo.Inventarios.InventarioDataSet.AJUSTESRow AjustePorFolio(string AjusteID)
        //{
        //    return SIFDatos.Inventario.AjustesAlmacen.AjustePorFolio(AjusteID);
        //}
    }

}
