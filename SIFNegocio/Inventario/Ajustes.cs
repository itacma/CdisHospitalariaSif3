using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace SIFNegocio.Inventario
{
    public class Ajustes
    {
        public SIFModelo.Inventarios.InventarioDataSet AjustesDataSet = new SIFModelo.Inventarios.InventarioDataSet();

        public SIFModelo.Inventarios.InventarioDataSet GetAjustes(DateTime fechaInicio, DateTime fechaFin,string Activo,string Folio)
        {
            return SIFDatos.Inventario.AjustesAlmacen.GetAjustes(fechaInicio.ToString("dd/MM/yyyy hh:mm:ss"), fechaFin.ToString("dd/MM/yyyy hh:mm:ss"),Activo,Folio);
        }
        public SIFModelo.Inventarios.InventarioDataSet GetAjustes(string Folio)
        {
            return SIFDatos.Inventario.AjustesAlmacen.GetAjustes( Folio,Helpers.Sesion.Sucursal);
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
                                    String[] ArtId, int[] Cant, double[] Precio, string Tipo,string Usuario)
        {
         
            return SIFDatos.Inventario.AjustesAlmacen.AplicaAjuste(Folio, Lote,Sucursal, ArtId, Cant, Precio, Tipo,Usuario);
        }
        public int AplicaAjusteAjustes(string Folio, int Lote, int Sucursal,
                                    String[] ArtId, int[] Cant, double[] Precio, string Tipo, string Usuario, String[] lotes_internos)
        {
            return SIFDatos.Inventario.AjustesAlmacen.AplicaAjusteAjustes(Folio, Lote, Sucursal, ArtId, Cant, Precio, Tipo, Usuario, lotes_internos);
        }

        public string ObtieneAjusteCad(string Folio, string lote,int mov)
        {
            return SIFDatos.Inventario.AjustesAlmacen.VerificarProcesados(Folio, lote,mov);
        }
        public string CierreAjustes(string Folio,int lote,int sucursal,string usuario)
        {
            return SIFDatos.Inventario.AjustesAlmacen.CierreAjustes2021(Folio,lote, sucursal,usuario);
        }
        public string ObtieneLoteInternoAjst(string Folio,string sku,int cantidad)
        {
            return SIFDatos.Inventario.AjustesAlmacen.ObtieneLoteInterno(Folio, sku,cantidad);
        }

        //public SIFModelo.Inventarios.InventarioDataSet.AJUSTESRow AjustePorFolio(string AjusteID)
        //{
        //    return SIFDatos.Inventario.AjustesAlmacen.AjustePorFolio(AjusteID);
        //}
        public  DataTable getAjthup(string referencia, string cnx) 
        {
            return SIFDatos.Inventario.AjustesAlmacen.getAjusteHUP_V2(referencia);
        }
        public  string CreaAjusteOrdenCompraMandato(string Folio, int pProveedorId, string usuario)
        {
           return SIFDatos.Inventario.AjustesAlmacen.CreaAjusteOrdenCompraMandato(Folio, pProveedorId, usuario);
        }

         public bool validaArticulo(string codigo)
         {
            return SIFDatos.Inventario.AjustesAlmacen.validaArticulo(codigo);
         }

        public void getFoliosOC(string referencia, out string fo, out string fc, out string ft)
        {
            SIFDatos.Inventario.AjustesAlmacen.getFoliosOC(referencia, out fo, out fc, out ft);
        }

    }

}
