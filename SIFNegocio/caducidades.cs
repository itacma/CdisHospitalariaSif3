using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Equin.ApplicationFramework;

namespace SIFNegocio
    {
    public class caducidades
        {

            #region Control Caducidades version 1.1- 1.2
        public DataTable TaCaducidades { get; set; }
        public BindingListView<SIFModelo.Inventarios.SkuCaducidad> BLVCaducidades;
        public int ins_Caducidades(string referencia, string articuloId,
                              int[] partida, String[] lote,
                              String[] caducidades, int[] Cant, string tipo, string usuario
                              )
            {
            return SIFDatos.caducidades.insCaducidades(referencia, articuloId, partida, lote, caducidades, Cant, tipo, usuario);

            }

        
            public int del_Caducidades(string Articulo, string referencia)
            {
            return SIFDatos.caducidades.delCaducidades(Articulo, referencia);
            }
        public DataTable sp_Get_Art_cadPorFolio(string refe, string artt)
            {
            return SIFDatos.caducidades.sp_Get_Art_cad_porFolio(refe, artt);
            }

        public DataTable sp_GetDataCaducidadesOc(string nFolioRoR)
            {
            return SIFDatos.caducidades.sp_GetDataRequisiciones(nFolioRoR);
            }
        public int ins_Caducidades_bulk(string referencia, string tipoMov, string usuario, List<SIFModelo.modeloCaducidades>  listCaducidades)
        {
            return SIFDatos.caducidades.insCaducidades_bulk(referencia ,tipoMov, usuario, listCaducidades);

        }
        public DataTable sp_GetDataCaducidadesMovimiento(string documento, int id_movimiento)
        {
            return SIFDatos.caducidades.sp_GetDataCaducidadesMovimiento(documento, id_movimiento);
        }

        public int upd_ctl_cad_bulk(string referencia, string tipoMov, string usuario, List<SIFModelo.Inventarios.SkuCaducidad> listCaducidades)
        {
            return SIFDatos.caducidades.upd_ctl_cad_bulk(referencia, tipoMov, usuario, listCaducidades);

        }
        #endregion

        //public static List<SIFModelo.Inventarios.SkuCaducidad> sp_GetDataRcc(string documento)
        //{
        //    return SIFDatos.caducidades.sp_GetDataRcc(documento);
        //}



        public DataTable sp_GetDataRcc(string documento)
        {
            return SIFDatos.caducidades.sp_GetDataRcc(documento);
        }




        public DataTable sp_GetDataRc(string documento)
        {
            return SIFDatos.caducidades.sp_GetDataRc(documento);
        }

        
        public DataTable sp_GetDataCaducidadesMovimientoV3(string documento , int id_movimiento)
        {
            return SIFDatos.caducidades.sp_GetDataCaducidadesMovimientoV3(documento,  id_movimiento);
        }

        public DataTable sp_GetDataCaduSelccionRecepcionCompra(string documento, int lote_documento, int id_movimiento)
        {
            return SIFDatos.caducidades.sp_GetDataCaduSeleccionRecepcionCompra(documento, lote_documento , id_movimiento);
        }

        public DataTable getLotesYCaducidadM(string folio, string tipo_mov,string lote)
        {
            return SIFDatos.caducidades.getLotesYCaducidadM(folio, tipo_mov,lote);
        }

        public DataTable getLotesYCaducidad_Salida(string folio, string tipo_mov, string lote)
        {
            return SIFDatos.caducidades.getLotesYCaducidad_Salida(folio, tipo_mov, lote);
        }

        public Decimal spActualizaLotesCaducidades_pro(string usuario,string movimiento,string articuloid,char columna,string old,string nuevo,string loteInt)
        {
            return SIFDatos.caducidades.spActualizaLotesCaducidades(usuario,movimiento,articuloid,columna,old,nuevo,loteInt);
        }
        public Decimal ValidaCambio(string lote_interno)
        {
            return SIFDatos.caducidades.validaCambioLoteCaducidad(lote_interno);
        }

        public Decimal sp_GuardadCaducidadesCapturadas(string pFoliocompra, string pUsuario_id,
                 List<Int32> L_partida,
        List<string> L_articulo_id,
        List<string> L_Lote_Interno,
        List<Int32> L_cant_lote,
        List<string> L_lote,
        List<string> L_loteProdcesado,
        List<string> L_caducidad

            , out string Respuesta)
        {
            
            Decimal r= SIFDatos.caducidades.sp_GuardadCaducidadesCapturadas( pFoliocompra,  pUsuario_id,
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




        public Decimal sp_GuardadCaducidadesSelectMovimiento(string pFoliocompra, int lote_documento, string pUsuario_id, int id_movimiento,
                 List<Int32> L_partida,
        List<string> L_articulo_id,
        List<string> L_Lote_Interno,
        List<Int32> L_cant_lote,
        List<string> L_lote,
        List<string> L_loteProdcesado,
        List<string> L_caducidad

            , out string Respuesta)
        {

            Decimal r = SIFDatos.caducidades.sp_GuardadCaducidadesSelectMovimiento(pFoliocompra, lote_documento, pUsuario_id, id_movimiento,
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
        /// <summary>
        ///  Obtendremos los datos de RecepcionOrden compra det para que sean modificados los lotes y caducidades
        /// </summary>
        /// <param name="documento"></param>
        /// <returns></returns>
        public DataTable sp_GetDataLotesYcaducidadesSku(string articulo_id,int periodo)
        {
            return SIFDatos.caducidades.sp_GetDataLotesYcaducidadesSku(articulo_id, periodo);
        }

        public  Decimal
          sp_SaveCaduCapturadasSku(
                      string pUsuario_id,
                      int periodo,
                      List<Int32> L_partida,
                      List<string> L_articulo_id,
                      List<Int32> L_cant_lote,
                      List<string> L_lote,
                      List<string> L_caducidad)
        {
            return SIFDatos.caducidades.sp_SaveCaduCapturadasSku(
                     pUsuario_id,
                      periodo,
                     L_partida,
                     L_articulo_id,
                     L_cant_lote,
                     L_lote,
                     L_caducidad

                );
        }

    }
}
