using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SIFNegocio.Inventario
{
    public class PNCNegocio
    {
        public SIFModelo.Inventarios.InventarioDataSet DsPnc = new SIFModelo.Inventarios.InventarioDataSet();

        public SIFModelo.Inventarios.InventarioDataSet GetPncs(DateTime fechaInicio, DateTime fechaFin, string Activo, string Folio, string btn=null)
        {
            return SIFDatos.Inventario.PNCDatos.GetPncs(fechaInicio.ToString("dd/MM/yyyy hh:mm:ss"), fechaFin.ToString("dd/MM/yyyy hh:mm:ss"), Activo, Folio, btn);
        }

        public SIFModelo.Inventarios.InventarioDataSet GetPncs(string Folio)
        {
            return SIFDatos.Inventario.PNCDatos.GetPncs(Folio, Helpers.Sesion.Sucursal);
        }

        public void InsInvAjuste(int[] Lote, int[] Partida, String[] ArtId, String[] Nombre,
                               String[] Concepto, int[] Cantidad, double[] Costo, SIFModelo.Usuario usuario, int Total)
        {
            SIFDatos.Inventario.PNCDatos.InsInvAjuste(Lote, Partida, ArtId, Nombre, Cantidad, Costo, Concepto, usuario, Total);
        }

        public void UpdInvAjuste(String Folio, int Lote, int[] Partida, String[] ArtId, String[] Nombre,
                               String Concepto, int[] Cantidad, double[] Costo, SIFModelo.Usuario usuario, int Total)
        {
            SIFDatos.Inventario.PNCDatos.UpdInvAjuste(Folio, Lote, Partida, ArtId, Nombre, Concepto, Cantidad, Costo, usuario, Total);
        }

        public DataTable GetLotesCaducidades(string folio)
        {
            return SIFDatos.Inventario.PNCDatos.GetLotesCaducidades(folio);
        }

        public DataTable sp_GetDataSeleccionSalidas(string documento, int lote_documento)
        {
            return SIFDatos.Inventario.PNCDatos.sp_GetDataSeleccionSalidasDatos(documento, lote_documento);
        }

        public DataTable sp_GetDataSeleccionDetalleMov(string documento, int lote_documento)
        {
            return SIFDatos.Inventario.PNCDatos.sp_GetDataDetalleMovimiento(documento, lote_documento);
        }

        public Decimal sp_GuardadCaducidadesdeMovSalida(string pFoliocompra, int lote_documento, string pUsuario_id,
            List<Int16> L_partida,
            List<string> L_articulo_id,
            List<string> L_Lote_Interno,
            List<Int16> L_cant_lote,
            List<string> L_lote,
            List<string> L_loteProdcesado,
            List<string> L_caducidad
            , out string Respuesta)
        {
            Decimal r = SIFDatos.Inventario.PNCDatos.sp_GuardadCaducidadesdeMovSalida(pFoliocompra, lote_documento, pUsuario_id,
                      L_partida,
                      L_articulo_id,
                      L_Lote_Interno,
                      L_cant_lote,
                      L_lote,
                      L_loteProdcesado,
                      L_caducidad
                      , out String Respuestai);
                      Respuesta = Respuestai;
            return r;
        }

        public Decimal EliminarCaducidades(string pFoliocompra, int lote_documento, string pUsuario_id, out string Respuesta)
        {
            Decimal r = SIFDatos.Inventario.PNCDatos.EliminarCaducidades(pFoliocompra, lote_documento, pUsuario_id, out String Respuestai);
            Respuesta = Respuestai;
            return r;
        }

        public string ObtieneAjusteCad(string Folio, string lote)
        {
            return SIFDatos.Inventario.PNCDatos.VerificarProcesados(Folio, lote);
        }

        public string Cierre(string Folio, int lote, int sucursal, string usuario)
        {
            return SIFDatos.Inventario.PNCDatos.Cierre(Folio, lote, sucursal, usuario);
        }

        public string Cancela(string NoFolio, int NoLote, int sucursal, string usuario)
        {
            return SIFDatos.Inventario.PNCDatos.Cancela(NoFolio, NoLote, sucursal, usuario);
        }

        public string CancelaAbiertos(string NoFolio, int NoLote, int sucursal, string usuario)
        {
            return SIFDatos.Inventario.PNCDatos.CancelaAbiertos(NoFolio, NoLote, sucursal, usuario);
        }

        public string Edita(string NoFolio, int NoLote, int sucursal, string usuario)
        {
            return SIFDatos.Inventario.PNCDatos.Edita(NoFolio, NoLote, sucursal, usuario);
        }





    }
}
