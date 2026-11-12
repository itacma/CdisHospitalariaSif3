using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Equin.ApplicationFramework;

namespace SIFNegocio
    {
    public class CaducidadesSalida
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
            return SIFDatos.CaducidadesSalidas.sp_GetDataCaducidadesMovimientoV3(documento,  id_movimiento);
        }

        public DataTable sp_GetDataSeleccionSalidas(string documento, int lote_documento, int id_movimiento)
        {
            return SIFDatos.CaducidadesSalidas.sp_GetDataSeleccionSalidasDatos(documento, lote_documento , id_movimiento);
        }
        

        public DataTable sp_GetDataskuCaducidades(SIFModelo.Inventarios.SkuCaducidad particulo_id)
        {
            return SIFDatos.CaducidadesSalidas.sp_GetDataskuCaducidades(particulo_id);
        }

        public DataTable sp_GetDataSeleccionDetalleMov (string documento, int lote_documento, int id_movimiento)
        {
            return SIFDatos.CaducidadesSalidas.sp_GetDataDetalleMovimiento(documento, lote_documento, id_movimiento);
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




        public Decimal sp_GuardadCaducidadesdeMovSalida(string pFoliocompra, int lote_documento, string pUsuario_id, int id_movimiento,
                 List<Int32> L_partida,
        List<string> L_articulo_id,
        List<string> L_Lote_Interno,
        List<Int32> L_cant_lote,
        List<string> L_lote,
        List<string> L_loteProdcesado,
        List<string> L_caducidad

            , out string Respuesta)
        {

            Decimal r = SIFDatos.CaducidadesSalidas.sp_GuardadCaducidadesdeMovSalida(pFoliocompra, lote_documento, pUsuario_id, id_movimiento,
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


        public  string sp_GuardadCaducidadesSeleccionadasT(string pFolioT, string pArticulo_id, int pLoteT,
                                   List<SIFModelo.Inventarios.SkuCaducidad> pLista


)
        {
            return SIFDatos.CaducidadesSalidas.sp_GuardadCaducidadesSeleccionadasT( pFolioT,  pArticulo_id,  pLoteT,
                                    pLista);


        }


    }
}
