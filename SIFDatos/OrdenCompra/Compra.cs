using System;
using System.Collections.Generic;
using System.Linq;
using Oracle.DataAccess.Client;
using System.Data;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using Oracle.DataAccess.Types;

namespace SIFDatos.OrdenCompra
{
    public static class Compra
    {

        public static int GeneraFolio(SIFModelo.Sucursal sucursal, string prefijoFolio)
        {
            object id;
            string sentencia = "SELECT SEC_RECEP_COMPRAS.NEXTVAL FROM DUAL";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.Parameters.Add("sucursalID", sucursal.SucursalesID);
                    //cmd.Parameters.Add("prefijoFolio", prefijoFolio);
                    cmd.BindByName = true;

                    try
                    {
                        cmd.Connection.Open();

                        id = cmd.ExecuteScalar();
                        if (string.IsNullOrEmpty(id.ToString()))
                        {
                            return -1;
                        }
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return int.Parse(id.ToString());
        }


        public static bool Inserta(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow modelo)
        {
            string sentencia = "PKG_COMPRAS.SP_INS_COMPRAS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("P_FOLIO_COMPRA", modelo.FOLIO_COMPRA);
                    cmd.Parameters.Add("P_FOLIO_OC", modelo.FOLIO_OC);
                    cmd.Parameters.Add("P_PROVEEDOR_ID", modelo.PROVEEDOR_ID);
                    cmd.Parameters.Add("P_FACTURA", modelo.FACTURA);
                    cmd.Parameters.Add("P_FOLIO_FACTURA_SAT", modelo.FOLIO_FACTURA_SAT);
                    cmd.Parameters.Add("P_TOT_IMPORTE_REC", modelo.TOT_IMPORTE_REC);
                    cmd.Parameters.Add("P_TOT_DESCTO_REC", modelo.TOT_DESCTO_REC);
                    cmd.Parameters.Add("P_TOT_IVA_REC", modelo.TOT_IVA_REC);
                    cmd.Parameters.Add("P_TOTAL_RECIBIDO", modelo.TOTAL_RECIBIDO);
                    cmd.Parameters.Add("P_TOTAL_NETO_RECIBIDO", modelo.TOTAL_NETO_RECIBIDO);
                    cmd.Parameters.Add("P_TOT_DESCTO_SINIVA_REC", modelo.TOT_DESCTO_SINIVA_REC);
                    cmd.Parameters.Add("P_TOT_DESCTO_CONIVA_REC", modelo.TOT_DESCTO_CONIVA_REC);
                    cmd.Parameters.Add("P_TOTAL_IVA_DESCTO_REC", modelo.TOTAL_IVA_DESCTO_REC);
                    cmd.Parameters.Add("P_TOTAL_DESCTO_DESCUENTOS_REC", modelo.TOTAL_DESCTO_DESCUENTOS_REC);
                    cmd.Parameters.Add("P_FECHA", modelo.FECHA);
                    cmd.Parameters.Add("P_ACTIVO", modelo.ACTIVO);
                    cmd.Parameters.Add("P_USUARIO_ID", modelo.USUARIO_ID);
                    cmd.Parameters.Add("P_USUARIO_ID_ASIG_PRECIO", modelo.USUARIO_ID_ASIG_PRECIO);
                    cmd.Parameters.Add("P_IMP_FALTANTE", modelo.IMP_FALTANTE);
                    cmd.Parameters.Add("P_IMP_DESC_FALTANTE", modelo.IMP_DESC_FALTANTE);
                    cmd.Parameters.Add("P_IMP_IVA_MAL", modelo.IMP_IVA_MAL);
                    cmd.Parameters.Add("P_TOT_FACTURA", modelo.TOT_FACTURA);
                    cmd.Parameters.Add("P_IVA_FACTURA", modelo.IVA_FACTURA);
                    cmd.Parameters.Add("P_MAL_OFERTADO", modelo.MAL_OFERTADO);
                    cmd.Parameters.Add("P_SIN_OFERTA", modelo.SIN_OFERTA);
                    cmd.Parameters.Add("P_RECEPCIONISTA", modelo.RECEPCIONISTA);
                    cmd.Parameters.Add("P_OBSERVACIONES", modelo.OBSERVACIONES);
                    cmd.Parameters.Add("P_TOT_IEPS_REC", "0");
                    cmd.Parameters.Add("P_TOTAL_IEPS_DESCTO_REC", "0");
                    cmd.Parameters.Add("P_IMP_IEPS_MAL", "0");
                    cmd.Parameters.Add("P_IEPS_FACTURA", "0");

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("OutParam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }

            return true;
        }

        public static bool InsertaCompraDetalle(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow modelo)
        {
            string sentencia = "PKG_COMPRAS.SP_INS_COMPRAS_DET";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("folio_compra", modelo.FOLIO_COMPRA);
                    cmd.Parameters.Add("folio_oc", modelo.FOLIO_OC);
                    cmd.Parameters.Add("proveedor_id", modelo.PROVEEDOR_ID);
                    cmd.Parameters.Add("articulo_id", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("nombre", modelo.NOMBRE);
                    cmd.Parameters.Add("precio_farm_rec", modelo.PRECIO_FARM_REC);
                    cmd.Parameters.Add("cant_recibida", modelo.CANT_RECIBIDA);
                    cmd.Parameters.Add("cant_prox_caducar", modelo.CANT_PROX_CADUCAR);
                    cmd.Parameters.Add("cant_malestado", modelo.CANT_MALESTADO);
                    cmd.Parameters.Add("cant_reposicion", modelo.CANT_REPOSICION);
                    cmd.Parameters.Add("porc_oferta", modelo.PORC_OFERTA);
                    cmd.Parameters.Add("porc_descto", modelo.PORC_DESCTO);
                    cmd.Parameters.Add("porc_descto_ad1", modelo.PORC_DESCTO_AD1);
                    cmd.Parameters.Add("porc_descto_ad2", modelo.PORC_DESCTO_AD2);
                    cmd.Parameters.Add("porc_descto_ad3", modelo.PORC_DESCTO_AD3);
                    cmd.Parameters.Add("porc_descto_ad4", modelo.PORC_DESCTO_AD4);
                    cmd.Parameters.Add("imp_oferta_siniva", modelo.IMP_OFERTA_SINIVA);
                    cmd.Parameters.Add("imp_oferta_coniva", modelo.IMP_OFERTA_CONIVA);
                    cmd.Parameters.Add("imp_descto_siniva", modelo.IMP_DESCTO_SINIVA);
                    cmd.Parameters.Add("imp_descto_coniva", modelo.IMP_DESCTO_CONIVA);
                    cmd.Parameters.Add("importe_iva", modelo.IMPORTE_IVA);
                    cmd.Parameters.Add("imp_descto_coniva_menosiva", modelo.IMP_DESCTO_CONIVA_MENOSIVA);
                    cmd.Parameters.Add("imp_recepcion_coniva", modelo.IMP_RECEPCION_CONIVA);
                    cmd.Parameters.Add("imp_recepcion_siniva", modelo.IMP_RECEPCION_SINIVA);
                    cmd.Parameters.Add("imp_cal1_oferta_coniva", modelo.IMP_CAL1_OFERTA_CONIVA);
                    cmd.Parameters.Add("imp_cal1_oferta_siniva", modelo.IMP_CAL1_OFERTA_SINIVA);
                    cmd.Parameters.Add("res_cal1_descto", modelo.RES_CAL1_DESCTO);
                    cmd.Parameters.Add("res_cal2_oferta", modelo.RES_CAL2_OFERTA);
                    cmd.Parameters.Add("res_cal3_desctoad1", modelo.RES_CAL3_DESCTOAD1);
                    cmd.Parameters.Add("res_cal4_desctoad2", modelo.RES_CAL4_DESCTOAD2);
                    cmd.Parameters.Add("res_cal5_desctoad3", modelo.RES_CAL5_DESCTOAD3);
                    cmd.Parameters.Add("res_cal6_desctoad4", modelo.RES_CAL6_DESCTOAD4);
                    cmd.Parameters.Add("costo_neto_unit_rec", modelo.COSTO_NETO_UNIT_REC);
                    cmd.Parameters.Add("importe_neto", modelo.IMPORTE_NETO);
                    cmd.Parameters.Add("dif_descto_iva", modelo.DIF_DESCTO_IVA);
                    cmd.Parameters.Add("flag_mal_ofertado", modelo.FLAG_MAL_OFERTADO);
                    cmd.Parameters.Add("descuento_general", modelo.DESCUENTO_GENERAL);
                    cmd.Parameters.Add("cant_factura", modelo.CANT_FACTURADA);
                    cmd.Parameters.Add("lote", modelo.LOTE);
                    cmd.Parameters.Add("caducidad", modelo.CADUCIDAD);
                    cmd.Parameters.Add("IMPORTE_IEPS", modelo.IMPORTE_IEPS);
                    cmd.Parameters.Add("PORCENTAJE_IEPS", modelo.PORCENTAJE_IEPS);
                    cmd.Parameters.Add("IEPS_MAL", modelo.IEPS_MAL);


                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            // return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        /*
           public static bool InsertaCompra(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow modelo)
        {
            string sentencia = "SP_INS_COMPRAS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("folio_compra", modelo.FOLIO_COMPRA);
                    cmd.Parameters.Add("folio_oc", modelo.FOLIO_OC);
                    cmd.Parameters.Add("proveedor_id", modelo.PROVEEDOR_ID);
                    cmd.Parameters.Add("factura", modelo.FACTURA);
                    cmd.Parameters.Add("folio_factura_sat", modelo.FOLIO_FACTURA_SAT);
                    cmd.Parameters.Add("tot_importe_rec", modelo.TOT_IMPORTE_REC);
                    cmd.Parameters.Add("tot_descto_rec", modelo.TOT_DESCTO_REC);
                    cmd.Parameters.Add("tot_iva_rec", modelo.TOT_IVA_REC);
                    cmd.Parameters.Add("total_recibido", modelo.TOTAL_RECIBIDO);
                    cmd.Parameters.Add("total_neto_recibido", modelo.TOTAL_NETO_RECIBIDO);
                    cmd.Parameters.Add("tot_descto_siniva_rec", modelo.TOT_DESCTO_SINIVA_REC);
                    cmd.Parameters.Add("tot_descto_coniva_rec", modelo.TOT_DESCTO_CONIVA_REC);
                    cmd.Parameters.Add("total_iva_descto_rec", modelo.TOTAL_IVA_DESCTO_REC);
                    cmd.Parameters.Add("total_descto_descuentos_rec", modelo.TOTAL_DESCTO_DESCUENTOS_REC);
                    cmd.Parameters.Add("fecha", modelo.FECHA);
                    cmd.Parameters.Add("activo", modelo.ACTIVO);
                    cmd.Parameters.Add("usuario_id", modelo.USUARIO_ID);
                    cmd.Parameters.Add("usuario_id_asig_precio", modelo.USUARIO_ID_ASIG_PRECIO);
                    cmd.Parameters.Add("imp_faltante", modelo.IMP_FALTANTE);
                    cmd.Parameters.Add("imp_desc_faltante", modelo.IMP_DESC_FALTANTE);
                    cmd.Parameters.Add("imp_iva_mal", modelo.IMP_IVA_MAL);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    try
                    {
                        cmd.Connection.Open();
                        var id = cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                    }

                }
            }
            return true;
        }
         
         */

        public static bool Actualiza(SIFModelo.OrdenCompra.OrdenesCompraDataSet.COMPRASRow modelo)
        {
            string sentencia = "SP_UPD_COMPRAS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("efolio_compra", modelo.FOLIO_COMPRA);
                    cmd.Parameters.Add("efolio_oc", modelo.FOLIO_OC);
                    cmd.Parameters.Add("eproveedor_id", modelo.PROVEEDOR_ID);
                    cmd.Parameters.Add("efactura", modelo.FACTURA);
                    //cmd.Parameters.Add("esubtotal_recibido", modelo.SUBTOTAL_RECIBIDO);
                    //cmd.Parameters.Add("edescuento_recibido", modelo.DESCUENTO_RECIBIDO);
                    //cmd.Parameters.Add("eimpuesto_recibido", modelo.IMPUESTO_RECIBIDO);
                    //cmd.Parameters.Add("etotal_recibido", modelo.TOTAL_RECIBIDO);
                    //cmd.Parameters.Add("esubtotal_facturado", modelo.SUBTOTAL_FACTURADO);
                    //cmd.Parameters.Add("edescuento_facturado", modelo.DESCUENTO_FACTURADO);
                    //cmd.Parameters.Add("eimpuesto_facturado", modelo.IMPUESTO_FACTURADO);
                    //cmd.Parameters.Add("etotal_facturado", modelo.TOTAL_FACTURADO);
                    //cmd.Parameters.Add("efecha", modelo.FECHA);
                    //cmd.Parameters.Add("eestado", modelo.ESTADO);
                    cmd.Parameters.Add("eusuario_id", modelo.USUARIO_ID);
                    cmd.Parameters.Add("eusuario_id_asig_precio", modelo.USUARIO_ID_ASIG_PRECIO);
                    cmd.Parameters.Add("eimp_faltante", modelo.IMP_FALTANTE);
                    cmd.Parameters.Add("eimp_desc_faltante", modelo.IMP_DESC_FALTANTE);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        //if (!outparam.Value.ToString().IsIntegerPositive())
                        //{
                        //    return false;
                        //}
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }

            return true;
        }

        public static bool Actualiza(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow modelo)
        {
            string sentencia = "PKG_COMPRAS.SP_UPD_COMPRAS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("P_FOLIO_COMPRA", modelo.FOLIO_COMPRA);
                    cmd.Parameters.Add("P_FOLIO_OC", modelo.FOLIO_OC);
                    cmd.Parameters.Add("P_PROVEEDOR_ID", modelo.PROVEEDOR_ID);

                    if (String.IsNullOrEmpty(modelo.FACTURA))
                    {
                        modelo.FACTURA = "-";
                    }
                    cmd.Parameters.Add("P_FACTURA", modelo.FACTURA);
                    cmd.Parameters.Add("P_FOLIO_FACTURA_SAT", modelo.FOLIO_FACTURA_SAT);
                    cmd.Parameters.Add("P_TOT_IMPORTE_REC", modelo.TOT_IMPORTE_REC);
                    cmd.Parameters.Add("P_TOT_DESCTO_REC", modelo.TOT_DESCTO_REC);
                    cmd.Parameters.Add("P_TOT_IVA_REC", modelo.TOT_IVA_REC);
                    cmd.Parameters.Add("P_TOTAL_RECIBIDO", modelo.TOTAL_RECIBIDO);
                    cmd.Parameters.Add("P_TOTAL_NETO_RECIBIDO", modelo.TOTAL_NETO_RECIBIDO);
                    cmd.Parameters.Add("P_TOT_DESCTO_SINIVA_REC", modelo.TOT_DESCTO_SINIVA_REC);
                    cmd.Parameters.Add("P_TOT_DESCTO_CONIVA_REC", modelo.TOT_DESCTO_CONIVA_REC);
                    cmd.Parameters.Add("P_TOTAL_IVA_DESCTO_REC", modelo.TOTAL_IVA_DESCTO_REC);
                    cmd.Parameters.Add("P_TOTAL_DESCTO_DESCUENTOS_REC", modelo.TOTAL_DESCTO_DESCUENTOS_REC);
                    cmd.Parameters.Add("P_FECHA", modelo.FECHA);
                    cmd.Parameters.Add("P_ACTIVO", modelo.ACTIVO);
                    cmd.Parameters.Add("P_USUARIO_ID", modelo.USUARIO_ID);
                    cmd.Parameters.Add("P_USUARIO_ID_ASIG_PRECIO", modelo.USUARIO_ID_ASIG_PRECIO);
                    cmd.Parameters.Add("P_IMP_FALTANTE", modelo.IMP_FALTANTE);
                    cmd.Parameters.Add("P_IMP_DESC_FALTANTE", modelo.IMP_DESC_FALTANTE);
                    cmd.Parameters.Add("P_IMP_IVA_MAL", modelo.IMP_IVA_MAL);
                    cmd.Parameters.Add("P_TOT_FACTURA", modelo.TOT_FACTURA);
                    cmd.Parameters.Add("P_IVA_FACTURA", modelo.IVA_FACTURA);
                    cmd.Parameters.Add("P_MAL_OFERTADO", modelo.MAL_OFERTADO);
                    cmd.Parameters.Add("P_SIN_OFERTA", modelo.SIN_OFERTA);
                    cmd.Parameters.Add("P_RECEPCIONISTA", modelo.RECEPCIONISTA);
                    cmd.Parameters.Add("P_OBSERVACIONES", modelo.OBSERVACIONES);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("OutParam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }

            return true;
        }


        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASDataTable OrdenesCompraPorOCId(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OrdenCompra)
        {
            //AGREGAMOS LA OFERTA
            SIFModelo.OrdenCompra.OrdenCompraDataSet ds = new SIFModelo.OrdenCompra.OrdenCompraDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.COMPRASTableAdapter ta = new SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.COMPRASTableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;
                ds.EnforceConstraints = false;
                ta.FillByFolioOC(ds.COMPRAS, OrdenCompra.FOLIO_OC_ID);
            }

            return ds.COMPRAS;
        }

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow CompraPorId(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow compra)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet ds = new SIFModelo.OrdenCompra.OrdenCompraDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.COMPRASTableAdapter ta = new SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.COMPRASTableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;

                ta.FillByFolioCompra(ds.COMPRAS, compra.FOLIO_COMPRA);
            }

            if (ds.COMPRAS.Rows.Count > 0)
                return ds.COMPRAS.Rows[0] as SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow;

            return null;
        }


        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable BuscaCompraDetalle(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow compra)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet ds = new SIFModelo.OrdenCompra.OrdenCompraDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.COMPRAS_DETTableAdapter ta = new SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.COMPRAS_DETTableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;
                ds.COMPRAS_DET.Constraints.Clear();
                ta.FillByFolioCompra(ds.COMPRAS_DET, compra.FOLIO_COMPRA);
             }

            return ds.COMPRAS_DET;
        }

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASDataTable BuscaCompraPorOCID(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OrdenCompra)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet ds = new SIFModelo.OrdenCompra.OrdenCompraDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.COMPRASTableAdapter ta = new SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.COMPRASTableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;

                ta.FillByFolioCompra(ds.COMPRAS, OrdenCompra.FOLIO_OC_ID);
            }

            return ds.COMPRAS;
        }

        public static string CodigoProveedorSABA(SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocdRow)
        {
            object id;
            string sentencia = "SELECT NVL(codigo_articulo,'') FROM ext_cat_saba WHERE codigo_ean = :codigo_ean";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.Parameters.Add("sucursalID", sucursal.SucursalesID);
                    cmd.Parameters.Add("codigo_ean", ocdRow.ARTICULO_ID);
                    cmd.BindByName = true;

                    try
                    {
                        cmd.Connection.Open();

                        id = cmd.ExecuteScalar();
                        if (string.IsNullOrEmpty(id.ToString()))
                        {
                            return "";
                        }
                    }
                    catch (Exception)
                    {
                        return "";
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return id.ToString();
        }

        public static string CodigoProveedorNADRO(SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocdRow)
        {
            object id;
            string sentencia = "SELECT NVL(codigo_articulo,'') FROM EXT_AUTOIIC_NADRO WHERE codigo_ean = :codigo_ean";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.Parameters.Add("sucursalID", sucursal.SucursalesID);
                    cmd.Parameters.Add("codigo_ean", ocdRow.ARTICULO_ID);
                    cmd.BindByName = true;

                    try
                    {
                        cmd.Connection.Open();

                        id = cmd.ExecuteScalar();
                        if (string.IsNullOrEmpty(id.ToString()))
                        {
                            return "";
                        }
                    }
                    catch (Exception)
                    {
                        return "";
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return id.ToString();
        }

        public static string CodigoProveedorDROG(SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocdRow)
        {
            object id;
            string sentencia = "SELECT NVL(codigo_articulo,'') FROM EXT_CAT_DROG WHERE codigo_ean = :codigo_ean";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.Parameters.Add("sucursalID", sucursal.SucursalesID);
                    cmd.Parameters.Add("codigo_ean", ocdRow.ARTICULO_ID);
                    cmd.BindByName = true;

                    try
                    {
                        cmd.Connection.Open();

                        id = cmd.ExecuteScalar();
                        if (string.IsNullOrEmpty(id.ToString()))
                        {
                            return "";
                        }
                    }
                    catch (Exception)
                    {
                        return "";
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return id.ToString();
        }

        public static SIFModelo.Catalogo.ArticuloMayorista CatalogoProveedorDROG(SIFModelo.Articulo articulo)
        {
            string sentencia = "SELECT * FROM EXT_CAT_DROG WHERE codigo_ean = :codigo_ean";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.Parameters.Add("sucursalID", sucursal.SucursalesID);
                    cmd.Parameters.Add("codigo_ean", articulo.ARTICULO_ID);
                    cmd.BindByName = true;

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            SIFModelo.Catalogo.ArticuloMayorista articuloM = new SIFModelo.Catalogo.ArticuloMayorista();
                            while (oreader.Read())
                            {
                                articuloM.ArticuloID = oreader["CODIGO_EAN"].ToString();
                                articuloM.PorcentajeIESPS = System.Convert.ToDecimal(oreader["PORCE_IESPS"]);
                                articuloM.PrecioFarmacia = System.Convert.ToDecimal(oreader["PRECIO_FARMACIA"])/100m;
                                articuloM.PrecioPublico = System.Convert.ToDecimal(oreader["PRECIO_PUBLICO"]) / 100M;

                                return articuloM;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }

            return null;
        }

        public static SIFModelo.Catalogo.ArticuloMayorista CatalogoProveedorSABA(SIFModelo.Articulo articulo)
        {
            string sentencia = "SELECT * FROM EXT_CAT_SABA WHERE codigo_ean = :codigo_ean";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.Parameters.Add("sucursalID", sucursal.SucursalesID);
                    cmd.Parameters.Add("codigo_ean", articulo.ARTICULO_ID);
                    cmd.BindByName = true;

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            SIFModelo.Catalogo.ArticuloMayorista articuloM = new SIFModelo.Catalogo.ArticuloMayorista();
                            while (oreader.Read())
                            {
                                articuloM.ArticuloID = oreader["CODIGO_EAN"].ToString();
                                articuloM.PorcentajeIESPS = System.Convert.ToDecimal(oreader["PORCE_IESPS"]);
                                articuloM.PrecioFarmacia = System.Convert.ToDecimal(oreader["PRECIO_FARMACIA"])/100;
                                articuloM.PrecioPublico = System.Convert.ToDecimal(oreader["PRECIO_PUBLICO"])/100;

                                return articuloM;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }

            return null;
        }

        public static SIFModelo.Catalogo.ArticuloMayorista CatalogoProveedorNadro(SIFModelo.Articulo articulo)
        {
            string sentencia = "SELECT * FROM EXT_CAT_SABA WHERE codigo_ean = :codigo_ean";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.Parameters.Add("sucursalID", sucursal.SucursalesID);
                    cmd.Parameters.Add("codigo_ean", articulo.ARTICULO_ID);
                    cmd.BindByName = true;

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            SIFModelo.Catalogo.ArticuloMayorista articuloM = new SIFModelo.Catalogo.ArticuloMayorista();
                            while (oreader.Read())
                            {
                                articuloM.ArticuloID = oreader["CODIGO_EAN"].ToString();
                                articuloM.PorcentajeIESPS = System.Convert.ToDecimal(oreader["PORCE_IESPS"]);
                                articuloM.PrecioFarmacia = System.Convert.ToDecimal(oreader["PRECIO_FARMACIA"]) / 100;
                                articuloM.PrecioPublico = System.Convert.ToDecimal(oreader["PRECIO_PUBLICO"]) / 100;

                                return articuloM;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }

            return null;
        }

        public static List<string> ListaRecepcionistas()
        {
            List<string> recepcionistas = new List<string>();

            string sentencia = "SELECT * FROM COMPRAS_RECEPCIONISTA ";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.BindByName = true;

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                recepcionistas.Add(oreader["NOMBRE"].ToString());
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return recepcionistas;
        }
      
        public static DataSet BuscaBonificacion(string folio_compra, DateTime fecha1, DateTime fecha2)
        {
            DataSet ds = new DataSet("detallesBon");
            ds.Tables.Add("BONIFICACION");
            
            string sentencia = "SELECT BONIFICACION.FOLIO, BONIFICACION.LOTE, BONIFICACION.SUCURSAL_ID, BONIFICACION.FECHA_REG, BONIFICACION.TOTAL, " +
                       " BONIFICACION.CONCEPTO, BONIFICACION.DOC_REFERENCIA, BONIFICACION.USUARIO_ID, BONIFICACION.ACTIVO,  " +
                       " CAT_USUARIOS.NOMBRE AS CAT_USUARIOS_NOMBRE, CAT_USUARIOS.APELLIDOS  " +
                       " FROM BONIFICACION INNER JOIN " +
                       " CAT_USUARIOS ON BONIFICACION.USUARIO_ID = CAT_USUARIOS.USUARIOS_ID INNER JOIN " +
                       " CAT_SUCURSALES ON BONIFICACION.SUCURSAL_ID = CAT_SUCURSALES.SUCURSALES_ID " +
           " WHERE BONIFICACION.FOLIO LIKE :Folio AND BONIFICACION.FECHA_REG BETWEEN :Fecha1 AND :Fecha2";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add(":Folio", "%" + folio_compra + "%");
                    cmd.Parameters.Add(":Fecha1", fecha1);
                    cmd.Parameters.Add(":Fecha2", fecha2);
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "BONIFICACION");
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);
                }

            }

            ds.Tables.Add("BONIFICACION_DET");
          //  string sentenciaDetalles = " select dd.DEVOLUCION_ID ,dd.ARTICULO_ID ARTICULO_ID,dd.NOMBRE1 NOMBRE1,dd.CANTIDAD CANTIDAD,dd.PRECIO_VENTA PRECIO_VENTA,dd.PRECIO_COSTO PRECIO_COSTO,dd.IVA IVA," +
   string sentenciaDetalles = "SELECT BONIFICACION_DET.FOLIO, BONIFICACION_DET.LOTE, BONIFICACION_DET.SUCURSAL_ID, BONIFICACION_DET.PARTIDA, " +
                        " BONIFICACION_DET.ARTICULO_ID, BONIFICACION_DET.CANTIDAD, BONIFICACION_DET.PRECIO,  CAT_ARTICULOS.NOMBRE1, " +
                        " BONIFICACION_DET.PRECIO_VTA,BONIFICACION_DET.CONCEPTO_DET, CAT_ARTICULOS.NOMBRE2 " +
                        " FROM BONIFICACION_DET INNER JOIN " +
                        " CAT_ARTICULOS ON BONIFICACION_DET.ARTICULO_ID = CAT_ARTICULOS.ARTICULO_ID " +
                        " WHERE BONIFICACION_DET.FOLIO IN ( SELECT BONIFICACION.FOLIO  FROM BONIFICACION WHERE BONIFICACION.FOLIO LIKE :Folio AND BONIFICACION.FECHA_REG BETWEEN :Fecha1 AND :Fecha2)";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                {
                    cmd.Parameters.Add(":Folio", "%" + folio_compra + "%");
                    cmd.Parameters.Add(":Fecha1", fecha1);
                    cmd.Parameters.Add(":Fecha2", fecha2);
                    /* cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                     cmd.Parameters.Add("SucursalesId", sucursal.SucursalesID);
                     cmd.Parameters.Add("NumeroCotizacion", "%" + Cotizacion.NumeroCotizacion + "%");*/
                    //cmd.Parameters.Add("num_dev", "%" + folio_compra + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "BONIFICACION_DET");
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);
                }

            }

            return ds;
        }

        public static DataSet BuscaRepProveedor(string folio_compra, DateTime fecha1, DateTime fecha2)
        {
            DataSet ds = new DataSet("detallesRep");
            ds.Tables.Add("Reposicion");
            /* string sentencia = "select NUM_COTIZACION AS FOLIO, fecha_COTIZACION as FECHA, (SELECT NOMBRE FROM CAT_USUARIOS WHERE CAT_USUARIOS.USUARIOS_ID=VENDEDOR_ID) AS ASESOR, (SELECT  NOMBRE || ' ' || APE_PATERNO || ' ' || APE_MATERNO FROM CAT_CLIENTES WHERE CAT_CLIENTES.CLIENTES_ID=COTIZACION.CLIENTE_ID) AS NOMBRE, (Select COLONIA FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=COTIZACION.CLIENTE_ID AND TIPO_DIR='CA') AS COLONIA, " +
                                " COMENTARIO,FACTURA,RECETA,TOT_ART_COTIZACION AS NO_TOTAL_ARTICULOS,TOTAL " +
                                ",ACTIVO as status, * FROM COTIZACION WHERE  ACTIVO='S' AND sucursal_id = :SucursalId AND  TIPO_COTIZACION='" + " " + "' AND NUM_Cotizacion LIKE :NumeroCotizacion  ORDER BY NUM_COTIZACION DESC "; //AND REF_REMISION_VTA IS NULL*/
            string sentencia = " select REPOSICION_ID ,SUCURSAL_ID ,PROVEEDOR_ID ,FECHA ,RDM ,COMENTARIO ,TOTAL ,ACTIVO ," +
 "(select nombre from cat_usuarios where usuarios_id=d.USUARIO_ID) usuario from REPOSICION_prov d  where REPOSICION_ID like'%" + folio_compra + "%' and  FECHA BETWEEN :Fecha1 AND :Fecha2";// +
            //"where  devolucion_id like :num_dev";
            //sentencia = "select * from cat_Articulos";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add(":Fecha1", fecha1);
                    cmd.Parameters.Add(":Fecha2", fecha2);
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Reposicion");
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);
                }

            }

            ds.Tables.Add("ReposicionDetalles");
            string sentenciaDetalles = " select dd.REPOSICION_ID ,dd.ARTICULO_ID ARTICULO_ID,dd.NOMBRE1 NOMBRE1,dd.CANTIDAD CANTIDAD,dd.PRECIO_VENTA PRECIO_VENTA,dd.PRECIO_COSTO PRECIO_COSTO,dd.IVA IVA," +
"dd.COMENTARIO COMENTARIo from REPOSICION_prov_det dd, REPOSICION_prov d where d.REPOSICION_ID=dd.REPOSICION_ID and d.REPOSICION_ID like'%" + folio_compra + "%' and  d.FECHA BETWEEN :Fecha1 AND :Fecha2";// and dd.devolucion_id like :num_dev";
            //sentenciaDetalles = "select * from lista_precios";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                {
                    /* cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                     cmd.Parameters.Add("SucursalesId", sucursal.SucursalesID);
                     cmd.Parameters.Add("NumeroCotizacion", "%" + Cotizacion.NumeroCotizacion + "%");*/
                    //cmd.Parameters.Add("num_dev", "%" + folio_compra + "%");
                    cmd.Parameters.Add(":Fecha1", fecha1);
                    cmd.Parameters.Add(":Fecha2", fecha2);
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "ReposicionDetalles");
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);
                }

            }

            return ds;
        }

        public static DataSet BuscaDevProveedor(string folio_compra, DateTime fecha1, DateTime fecha2)
        {
            DataSet ds = new DataSet("detallesDev");
            ds.Tables.Add("Devolucion");
           /* string sentencia = "select NUM_COTIZACION AS FOLIO, fecha_COTIZACION as FECHA, (SELECT NOMBRE FROM CAT_USUARIOS WHERE CAT_USUARIOS.USUARIOS_ID=VENDEDOR_ID) AS ASESOR, (SELECT  NOMBRE || ' ' || APE_PATERNO || ' ' || APE_MATERNO FROM CAT_CLIENTES WHERE CAT_CLIENTES.CLIENTES_ID=COTIZACION.CLIENTE_ID) AS NOMBRE, (Select COLONIA FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=COTIZACION.CLIENTE_ID AND TIPO_DIR='CA') AS COLONIA, " +
                               " COMENTARIO,FACTURA,RECETA,TOT_ART_COTIZACION AS NO_TOTAL_ARTICULOS,TOTAL " +
                               ",ACTIVO as status, * FROM COTIZACION WHERE  ACTIVO='S' AND sucursal_id = :SucursalId AND  TIPO_COTIZACION='" + " " + "' AND NUM_Cotizacion LIKE :NumeroCotizacion  ORDER BY NUM_COTIZACION DESC "; //AND REF_REMISION_VTA IS NULL*/
            string sentencia = " select DEVOLUCION_ID ,SUCURSAL_ID ,PROVEEDOR_ID ,FECHA ,RDM ,COMENTARIO ,TOTAL ,ACTIVO ," +
 "(select nombre from cat_usuarios where usuarios_id=d.USUARIO_ID) usuario from DEVOLUCION_prov d  where devolucion_id like'%" + folio_compra + "%' and  FECHA BETWEEN :Fecha1 AND :Fecha2";// +
 //"where  devolucion_id like :num_dev";
            //sentencia = "select * from cat_Articulos";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add(":Fecha1", fecha1);
                    cmd.Parameters.Add(":Fecha2", fecha2);
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Devolucion");
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);
                }

            }

            ds.Tables.Add("DevolucionDetalles");
            string sentenciaDetalles = " select dd.DEVOLUCION_ID ,dd.ARTICULO_ID ARTICULO_ID,dd.NOMBRE1 NOMBRE1,dd.CANTIDAD CANTIDAD,dd.PRECIO_VENTA PRECIO_VENTA,dd.PRECIO_COSTO PRECIO_COSTO,dd.IVA IVA,"+
"dd.COMENTARIO COMENTARIo from DEVOLUCION_prov_det dd, DEVOLUCION_prov d where d.devolucion_id=dd.devolucion_id and d.devolucion_id like'%" + folio_compra + "%' and  d.FECHA BETWEEN :Fecha1 AND :Fecha2";// and dd.devolucion_id like :num_dev";
//sentenciaDetalles = "select * from lista_precios";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                {
                   /* cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("SucursalesId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroCotizacion", "%" + Cotizacion.NumeroCotizacion + "%");*/
                    //cmd.Parameters.Add("num_dev", "%" + folio_compra + "%");
                    cmd.Parameters.Add(":Fecha1", fecha1);
                    cmd.Parameters.Add(":Fecha2", fecha2);
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "DevolucionDetalles");
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);
                }

            }

            return ds;
        }
        public static List<SIFModelo.OrdenCompra.RepoProveedor> RepDetallesCompra(string folio_compra)
        {
            List<SIFModelo.OrdenCompra.RepoProveedor> lista = new List<SIFModelo.OrdenCompra.RepoProveedor>();
            SIFModelo.OrdenCompra.RepoProveedor registro;
            string sentencia = "SELECT  d .ARTICULO_ID,  d.NOMBRE,  d .CANT_FACTURADA,  d .CANT_RECIBIDA,  d .CODIGO_PROVEEDOR,  to_char(d .COSTO_NETO_UNIT_REC)COSTO_NETO_UNIT_REC,  d .FOLIO_COMPRA,  d .FOLIO_OC,  d .IMPORTE_IEPS,  d .IMPORTE_IVA,  d .PORC_IVA,  d .PRECIO_FLEMING,  d .PRECIO_MAXIMO,  d .PRECIO_VENTA,  NVL (  (    SELECT      TIPO_MEDICAMENTO_COMPRAS.NOMBRE    FROM      TIPO_MEDICAMENTO_COMPRAS   ";
            sentencia += " WHERE      TIPO_MEDICAMENTO_COMPRAS.TIPO_MEDICAMENTO_COMPRAS_ID = AR.TIPO3  )  , '') TIPO_MEDICAMENTO,  CAT.LABORATORIO_ID,NVL(DEV.CANTIDAD,0) CANT_REPOSICION FROM  COMPRAS_DET d,CAT_ARTICULOS_MAYORISTA ar, CAT_ARTICULOS cat,REP_PROVEEDOR_DETALLE DEV where   ar.ARTICULO_ID = d .ARTICULO_ID and  CAT.ARTICULO_ID = D.ARTICULO_ID  AND D.FOLIO_COMPRA=DEV.RDM(+)  and D.articulo_id=dev.articulo_id(+)  and        (FOLIO_COMPRA LIKE '" + folio_compra + "')ORDER BY  d .NOMBRE ASC ";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.BindByName = true;

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {

                            while (oreader.Read())
                            {
                                registro = new SIFModelo.OrdenCompra.RepoProveedor();
                                // recepcionistas.Add(oreader["NOMBRE"].ToString());
                                registro.ARTICULO_ID = (oreader["ARTICULO_ID"].ToString());
                                registro.CANT_REPOSICION = Convert.ToDecimal((oreader["CANT_REPOSICION"].ToString()));
                                registro.CANT_FACTURADA = Convert.ToInt32((oreader["CANT_FACTURADA"].ToString()));
                                registro.CANT_RECIBIDA = Convert.ToInt32((oreader["CANT_RECIBIDA"].ToString()));
                                registro.CODIGO_PROVEEDOR = (oreader["CODIGO_PROVEEDOR"].ToString());
                                registro.COSTO_NETO_UNIT_REC = Convert.ToDecimal((oreader["COSTO_NETO_UNIT_REC"].ToString()));
                                registro.FOLIO_COMPRA = (oreader["FOLIO_COMPRA"].ToString());
                                registro.FOLIO_OC = (oreader["FOLIO_OC"].ToString());
                                registro.IMPORTE_IEPS = Convert.ToDecimal((oreader["IMPORTE_IEPS"].ToString()));
                                registro.IMPORTE_IVA = Convert.ToDecimal((oreader["IMPORTE_IVA"].ToString()));
                                registro.LABORATORIO_ID = (oreader["LABORATORIO_ID"].ToString());
                                registro.NOMBRE = (oreader["NOMBRE"].ToString());
                                registro.PORC_IVA = Convert.ToDecimal((oreader["PORC_IVA"].ToString()));
                                registro.PRECIO_FLEMING = Convert.ToDecimal((oreader["PRECIO_FLEMING"].ToString()));
                                registro.PRECIO_MAXIMO = Convert.ToDecimal((oreader["PRECIO_MAXIMO"].ToString()));
                                registro.PRECIO_VENTA = Convert.ToDecimal((oreader["PRECIO_VENTA"].ToString()));
                                registro.TIPO_MEDICAMENTO = (oreader["TIPO_MEDICAMENTO"].ToString());


                                lista.Add(registro);

                            }
                        }
                    }
                    catch (Exception e)
                    {
                       MessageBox.Show("Error: " + e.ToString());
                        return lista;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return lista;
        }
        public static List<SIFModelo.OrdenCompra.DevProveedor> devDetallesCompra(string folio_compra)
        {
            List<SIFModelo.OrdenCompra.DevProveedor> lista = new List<SIFModelo.OrdenCompra.DevProveedor>();
                SIFModelo.OrdenCompra.DevProveedor registro;
                string sentencia = "SELECT  d .ARTICULO_ID,  d.NOMBRE,  d .CANT_FACTURADA,  d .CANT_RECIBIDA,  d .CODIGO_PROVEEDOR,  to_char(d .COSTO_NETO_UNIT_REC)COSTO_NETO_UNIT_REC,  d .FOLIO_COMPRA,  d .FOLIO_OC,  d .IMPORTE_IEPS,  d .IMPORTE_IVA,  d .PORC_IVA,  d .PRECIO_FLEMING,  d .PRECIO_MAXIMO,  d .PRECIO_VENTA,  NVL (  (    SELECT      TIPO_MEDICAMENTO_COMPRAS.NOMBRE    FROM      TIPO_MEDICAMENTO_COMPRAS   ";
            sentencia+=" WHERE      TIPO_MEDICAMENTO_COMPRAS.TIPO_MEDICAMENTO_COMPRAS_ID = AR.TIPO3  )  , '') TIPO_MEDICAMENTO,  CAT.LABORATORIO_ID,NVL(DEV.CANTIDAD,0) CANT_DEVUELTA FROM  COMPRAS_DET d,CAT_ARTICULOS_MAYORISTA ar, CAT_ARTICULOS cat,DEV_PROVEEDOR_DETALLE DEV where   ar.ARTICULO_ID = d .ARTICULO_ID and  CAT.ARTICULO_ID = D.ARTICULO_ID  AND D.FOLIO_COMPRA=DEV.RDM(+)  and D.articulo_id=dev.articulo_id(+)  and        (FOLIO_COMPRA LIKE '"+folio_compra+"')ORDER BY  d .NOMBRE ASC ";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.BindByName = true;

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                          
                            while (oreader.Read())
                            {
                                registro = new SIFModelo.OrdenCompra.DevProveedor();
                               // recepcionistas.Add(oreader["NOMBRE"].ToString());
                                registro.ARTICULO_ID = (oreader["ARTICULO_ID"].ToString());
                                registro.CANT_DEVUELTA = Convert.ToDecimal((oreader["CANT_DEVUELTA"].ToString()));
                                registro.CANT_FACTURADA = Convert.ToInt32((oreader["CANT_FACTURADA"].ToString()));
                                registro.CANT_RECIBIDA = Convert.ToInt32((oreader["CANT_RECIBIDA"].ToString()));
                                registro.CODIGO_PROVEEDOR = (oreader["CODIGO_PROVEEDOR"].ToString());
                                registro.COSTO_NETO_UNIT_REC = Convert.ToDecimal((oreader["COSTO_NETO_UNIT_REC"].ToString()));
                                registro.FOLIO_COMPRA = (oreader["FOLIO_COMPRA"].ToString());
                                registro.FOLIO_OC = (oreader["FOLIO_OC"].ToString());
                                registro.IMPORTE_IEPS = Convert.ToDecimal((oreader["IMPORTE_IEPS"].ToString()));
                                registro.IMPORTE_IVA = Convert.ToDecimal((oreader["IMPORTE_IVA"].ToString()));
                                registro.LABORATORIO_ID = (oreader["LABORATORIO_ID"].ToString());
                                registro.NOMBRE = (oreader["NOMBRE"].ToString());
                                registro.PORC_IVA = Convert.ToDecimal((oreader["PORC_IVA"].ToString()));
                                registro.PRECIO_FLEMING = Convert.ToDecimal((oreader["PRECIO_FLEMING"].ToString()));
                                registro.PRECIO_MAXIMO = Convert.ToDecimal((oreader["PRECIO_MAXIMO"].ToString()));
                                registro.PRECIO_VENTA = Convert.ToDecimal((oreader["PRECIO_VENTA"].ToString()));
                                registro.TIPO_MEDICAMENTO = (oreader["TIPO_MEDICAMENTO"].ToString());
                                
                                    
                                lista.Add(registro);

                            }
                        }
                    }
                    catch (Exception e)
                    {
                       MessageBox.Show("Error: "+e.ToString());
                        return lista;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return lista;
        }
        public static bool InsertaDetalles(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow rowCompras, SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable detalles)
        {
            string sentencia = "PKG_COMPRAS.SP_INS_ORDENES_COMPRA_DET";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("p_FOLIO_COMPRA", OracleDbType.Varchar2,  rowCompras.FOLIO_COMPRA , ParameterDirection.Input);
                    cmd.Parameters.Add("p_FOLIO_OC", OracleDbType.Varchar2, rowCompras.FOLIO_OC, ParameterDirection.Input);
                    cmd.Parameters.Add("p_PROVEEDOR_ID", OracleDbType.Decimal, rowCompras.PROVEEDOR_ID, ParameterDirection.Input);

                    OracleParameter P_ARTICULO_ID = cmd.Parameters.Add("p_ARTICULO_ID", OracleDbType.Varchar2);
                    P_ARTICULO_ID.Direction = ParameterDirection.Input;
                    P_ARTICULO_ID.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_NOMBRE = cmd.Parameters.Add("p_NOMBRE", OracleDbType.Varchar2);
                    P_NOMBRE.Direction = ParameterDirection.Input;
                    P_NOMBRE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PRECIO_FARM_REC = cmd.Parameters.Add("p_PRECIO_FARM_REC", OracleDbType.Decimal);
                    P_PRECIO_FARM_REC.Direction = ParameterDirection.Input;
                    P_PRECIO_FARM_REC.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_RECIBIDA = cmd.Parameters.Add("p_CANT_RECIBIDA", OracleDbType.Decimal);
                    P_CANT_RECIBIDA.Direction = ParameterDirection.Input;
                    P_CANT_RECIBIDA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_PROX_CADUCAR = cmd.Parameters.Add("p_CANT_PROX_CADUCAR", OracleDbType.Decimal);
                    P_CANT_PROX_CADUCAR.Direction = ParameterDirection.Input;
                    P_CANT_PROX_CADUCAR.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_MALESTADO = cmd.Parameters.Add("p_CANT_MALESTADO", OracleDbType.Decimal);
                    P_CANT_MALESTADO.Direction = ParameterDirection.Input;
                    P_CANT_MALESTADO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_REPOSICION = cmd.Parameters.Add("p_CANT_REPOSICION", OracleDbType.Decimal);
                    P_CANT_REPOSICION.Direction = ParameterDirection.Input;
                    P_CANT_REPOSICION.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PORC_OFERTA = cmd.Parameters.Add("p_PORC_OFERTA", OracleDbType.Decimal);
                    P_PORC_OFERTA.Direction = ParameterDirection.Input;
                    P_PORC_OFERTA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PORC_DESCTO = cmd.Parameters.Add("p_PORC_DESCTO", OracleDbType.Decimal);
                    P_PORC_DESCTO.Direction = ParameterDirection.Input;
                    P_PORC_DESCTO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PORC_DESCTO_AD1 = cmd.Parameters.Add("p_PORC_DESCTO_AD1", OracleDbType.Decimal);
                    P_PORC_DESCTO_AD1.Direction = ParameterDirection.Input;
                    P_PORC_DESCTO_AD1.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PORC_DESCTO_AD2 = cmd.Parameters.Add("p_PORC_DESCTO_AD2", OracleDbType.Decimal);
                    P_PORC_DESCTO_AD2.Direction = ParameterDirection.Input;
                    P_PORC_DESCTO_AD2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PORC_DESCTO_AD3 = cmd.Parameters.Add("p_PORC_DESCTO_AD3", OracleDbType.Decimal);
                    P_PORC_DESCTO_AD3.Direction = ParameterDirection.Input;
                    P_PORC_DESCTO_AD3.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PORC_DESCTO_AD4 = cmd.Parameters.Add("p_PORC_DESCTO_AD4", OracleDbType.Decimal);
                    P_PORC_DESCTO_AD4.Direction = ParameterDirection.Input;
                    P_PORC_DESCTO_AD4.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_OFERTA_SINIVA = cmd.Parameters.Add("p_IMP_OFERTA_SINIVA", OracleDbType.Decimal);
                    P_IMP_OFERTA_SINIVA.Direction = ParameterDirection.Input;
                    P_IMP_OFERTA_SINIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_OFERTA_CONIVA = cmd.Parameters.Add("p_IMP_OFERTA_CONIVA", OracleDbType.Decimal);
                    P_IMP_OFERTA_CONIVA.Direction = ParameterDirection.Input;
                    P_IMP_OFERTA_CONIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_DESCTO_SINIVA = cmd.Parameters.Add("p_IMP_DESCTO_SINIVA", OracleDbType.Decimal);
                    P_IMP_DESCTO_SINIVA.Direction = ParameterDirection.Input;
                    P_IMP_DESCTO_SINIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_DESCTO_CONIVA = cmd.Parameters.Add("p_IMP_DESCTO_CONIVA", OracleDbType.Decimal);
                    P_IMP_DESCTO_CONIVA.Direction = ParameterDirection.Input;
                    P_IMP_DESCTO_CONIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMPORTE_IVA = cmd.Parameters.Add("p_IMPORTE_IVA", OracleDbType.Decimal);
                    P_IMPORTE_IVA.Direction = ParameterDirection.Input;
                    P_IMPORTE_IVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_DESCTO_CONIVA_MENOSIVA = cmd.Parameters.Add("p_IMP_DESCTO_CONIVA_MENOSIVA", OracleDbType.Decimal);
                    P_IMP_DESCTO_CONIVA_MENOSIVA.Direction = ParameterDirection.Input;
                    P_IMP_DESCTO_CONIVA_MENOSIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_RECEPCION_CONIVA = cmd.Parameters.Add("p_IMP_RECEPCION_CONIVA", OracleDbType.Decimal);
                    P_IMP_RECEPCION_CONIVA.Direction = ParameterDirection.Input;
                    P_IMP_RECEPCION_CONIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_RECEPCION_SINIVA = cmd.Parameters.Add("p_IMP_RECEPCION_SINIVA", OracleDbType.Decimal);
                    P_IMP_RECEPCION_SINIVA.Direction = ParameterDirection.Input;
                    P_IMP_RECEPCION_SINIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_CAL1_OFERTA_CONIVA = cmd.Parameters.Add("p_IMP_CAL1_OFERTA_CONIVA", OracleDbType.Decimal);
                    P_IMP_CAL1_OFERTA_CONIVA.Direction = ParameterDirection.Input;
                    P_IMP_CAL1_OFERTA_CONIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_CAL1_OFERTA_SINIVA = cmd.Parameters.Add("p_IMP_CAL1_OFERTA_SINIVA", OracleDbType.Decimal);
                    P_IMP_CAL1_OFERTA_SINIVA.Direction = ParameterDirection.Input;
                    P_IMP_CAL1_OFERTA_SINIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_RES_CAL1_DESCTO = cmd.Parameters.Add("p_RES_CAL1_DESCTO", OracleDbType.Decimal);
                    P_RES_CAL1_DESCTO.Direction = ParameterDirection.Input;
                    P_RES_CAL1_DESCTO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_RES_CAL2_OFERTA = cmd.Parameters.Add("p_RES_CAL2_OFERTA", OracleDbType.Decimal);
                    P_RES_CAL2_OFERTA.Direction = ParameterDirection.Input;
                    P_RES_CAL2_OFERTA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_RES_CAL3_DESCTOAD1 = cmd.Parameters.Add("p_RES_CAL3_DESCTOAD1", OracleDbType.Decimal);
                    P_RES_CAL3_DESCTOAD1.Direction = ParameterDirection.Input;
                    P_RES_CAL3_DESCTOAD1.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_RES_CAL4_DESCTOAD2 = cmd.Parameters.Add("p_RES_CAL4_DESCTOAD2", OracleDbType.Decimal);
                    P_RES_CAL4_DESCTOAD2.Direction = ParameterDirection.Input;
                    P_RES_CAL4_DESCTOAD2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_RES_CAL5_DESCTOAD3 = cmd.Parameters.Add("p_RES_CAL5_DESCTOAD3", OracleDbType.Decimal);
                    P_RES_CAL5_DESCTOAD3.Direction = ParameterDirection.Input;
                    P_RES_CAL5_DESCTOAD3.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_RES_CAL6_DESCTOAD4 = cmd.Parameters.Add("p_RES_CAL6_DESCTOAD4", OracleDbType.Decimal);
                    P_RES_CAL6_DESCTOAD4.Direction = ParameterDirection.Input;
                    P_RES_CAL6_DESCTOAD4.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_COSTO_NETO_UNIT_REC = cmd.Parameters.Add("p_COSTO_NETO_UNIT_REC", OracleDbType.Decimal);
                    P_COSTO_NETO_UNIT_REC.Direction = ParameterDirection.Input;
                    P_COSTO_NETO_UNIT_REC.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMPORTE_NETO = cmd.Parameters.Add("p_IMPORTE_NETO", OracleDbType.Decimal);
                    P_IMPORTE_NETO.Direction = ParameterDirection.Input;
                    P_IMPORTE_NETO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_DIF_DESCTO_IVA = cmd.Parameters.Add("p_DIF_DESCTO_IVA", OracleDbType.Decimal);
                    P_DIF_DESCTO_IVA.Direction = ParameterDirection.Input;
                    P_DIF_DESCTO_IVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_FLAG_MAL_OFERTADO = cmd.Parameters.Add("p_FLAG_MAL_OFERTADO", OracleDbType.Varchar2);
                    P_FLAG_MAL_OFERTADO.Direction = ParameterDirection.Input;
                    P_FLAG_MAL_OFERTADO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_DESCUENTO_GENERAL = cmd.Parameters.Add("p_DESCUENTO_GENERAL", OracleDbType.Decimal);
                    P_DESCUENTO_GENERAL.Direction = ParameterDirection.Input;
                    P_DESCUENTO_GENERAL.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_FACTURA = cmd.Parameters.Add("p_CANT_FACTURA", OracleDbType.Decimal);
                    P_CANT_FACTURA.Direction = ParameterDirection.Input;
                    P_CANT_FACTURA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_DEV_FALTANTE = cmd.Parameters.Add("p_CANT_DEV_FALTANTE", OracleDbType.Decimal);
                    P_CANT_DEV_FALTANTE.Direction = ParameterDirection.Input;
                    P_CANT_DEV_FALTANTE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_DEV_NO_PEDIDO = cmd.Parameters.Add("p_CANT_DEV_NO_PEDIDO", OracleDbType.Decimal);
                    P_CANT_DEV_NO_PEDIDO.Direction = ParameterDirection.Input;
                    P_CANT_DEV_NO_PEDIDO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_DEV_PRECIO_ELEVADO = cmd.Parameters.Add("p_CANT_DEV_PRECIO_ELEVADO", OracleDbType.Decimal);
                    P_CANT_DEV_PRECIO_ELEVADO.Direction = ParameterDirection.Input;
                    P_CANT_DEV_PRECIO_ELEVADO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_DEV_FILLER1 = cmd.Parameters.Add("p_CANT_DEV_FILLER1", OracleDbType.Decimal);
                    P_CANT_DEV_FILLER1.Direction = ParameterDirection.Input;
                    P_CANT_DEV_FILLER1.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_DEV_FILLER2 = cmd.Parameters.Add("p_CANT_DEV_FILLER2", OracleDbType.Decimal);
                    P_CANT_DEV_FILLER2.Direction = ParameterDirection.Input;
                    P_CANT_DEV_FILLER2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PARTIDA = cmd.Parameters.Add("p_PARTIDA", OracleDbType.Decimal);
                    P_PARTIDA.Direction = ParameterDirection.Input;
                    P_PARTIDA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_LOTE = cmd.Parameters.Add("p_LOTE", OracleDbType.Varchar2);
                    P_LOTE.Direction = ParameterDirection.Input;
                    P_LOTE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CADUCIDAD = cmd.Parameters.Add("p_CADUCIDAD", OracleDbType.Varchar2);
                    P_CADUCIDAD.Direction = ParameterDirection.Input;
                    P_CADUCIDAD.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_FACTURADA = cmd.Parameters.Add("p_CANT_FACTURADA", OracleDbType.Decimal);
                    P_CANT_FACTURADA.Direction = ParameterDirection.Input;
                    P_CANT_FACTURADA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_SOLICITADA = cmd.Parameters.Add("p_CANT_SOLICITADA", OracleDbType.Decimal);
                    P_CANT_SOLICITADA.Direction = ParameterDirection.Input;
                    P_CANT_SOLICITADA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_COSTO = cmd.Parameters.Add("p_COSTO", OracleDbType.Decimal);
                    P_COSTO.Direction = ParameterDirection.Input;
                    P_COSTO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_SIN_OFERTA = cmd.Parameters.Add("p_SIN_OFERTA", OracleDbType.Decimal);
                    P_SIN_OFERTA.Direction = ParameterDirection.Input;
                    P_SIN_OFERTA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_TOTAL_DESCTO_FACTURA = cmd.Parameters.Add("p_TOTAL_DESCTO_FACTURA", OracleDbType.Decimal);
                    P_TOTAL_DESCTO_FACTURA.Direction = ParameterDirection.Input;
                    P_TOTAL_DESCTO_FACTURA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_TOTAL_OFERTA_FACTURA = cmd.Parameters.Add("p_TOTAL_OFERTA_FACTURA", OracleDbType.Decimal);
                    P_TOTAL_OFERTA_FACTURA.Direction = ParameterDirection.Input;
                    P_TOTAL_OFERTA_FACTURA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PRECIO_FACTURA = cmd.Parameters.Add("p_PRECIO_FACTURA", OracleDbType.Decimal);
                    P_PRECIO_FACTURA.Direction = ParameterDirection.Input;
                    P_PRECIO_FACTURA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PRECIO_FARMACIA = cmd.Parameters.Add("p_PRECIO_FARMACIA", OracleDbType.Decimal);
                    P_PRECIO_FARMACIA.Direction = ParameterDirection.Input;
                    P_PRECIO_FARMACIA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IVA_MAL_OFERTADO = cmd.Parameters.Add("p_IVA_MAL_OFERTADO", OracleDbType.Decimal);
                    P_IVA_MAL_OFERTADO.Direction = ParameterDirection.Input;
                    P_IVA_MAL_OFERTADO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PRECIO_MAXIMO = cmd.Parameters.Add("p_PRECIO_MAXIMO", OracleDbType.Decimal);
                    P_PRECIO_MAXIMO.Direction = ParameterDirection.Input;
                    P_PRECIO_MAXIMO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_NUEVO_FLEMING = cmd.Parameters.Add("p_NUEVO_FLEMING", OracleDbType.Decimal);
                    P_NUEVO_FLEMING.Direction = ParameterDirection.Input;
                    P_NUEVO_FLEMING.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PORC_IVA = cmd.Parameters.Add("p_PORC_IVA", OracleDbType.Decimal);
                    P_PORC_IVA.Direction = ParameterDirection.Input;
                    P_PORC_IVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_MAL_OFERTADO = cmd.Parameters.Add("p_MAL_OFERTADO", OracleDbType.Decimal);
                    P_MAL_OFERTADO.Direction = ParameterDirection.Input;
                    P_MAL_OFERTADO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PRECIO_FACTURA_MAX = cmd.Parameters.Add("p_PRECIO_FACTURA_MAX", OracleDbType.Decimal);
                    P_PRECIO_FACTURA_MAX.Direction = ParameterDirection.Input;
                    P_PRECIO_FACTURA_MAX.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CODIGO_PROVEEDOR = cmd.Parameters.Add("p_CODIGO_PROVEEDOR", OracleDbType.Varchar2);
                    P_CODIGO_PROVEEDOR.Direction = ParameterDirection.Input;
                    P_CODIGO_PROVEEDOR.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PRECIO_VENTA = cmd.Parameters.Add("p_PRECIO_VENTA", OracleDbType.Decimal);
                    P_PRECIO_VENTA.Direction = ParameterDirection.Input;
                    P_PRECIO_VENTA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_COSTO_ULT_COMPRA = cmd.Parameters.Add("p_COSTO_ULT_COMPRA", OracleDbType.Decimal);
                    P_COSTO_ULT_COMPRA.Direction = ParameterDirection.Input;
                    P_COSTO_ULT_COMPRA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_MARGEN_UTILIDAD = cmd.Parameters.Add("p_MARGEN_UTILIDAD", OracleDbType.Decimal);
                    P_MARGEN_UTILIDAD.Direction = ParameterDirection.Input;
                    P_MARGEN_UTILIDAD.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_FACTURA_CONIVA = cmd.Parameters.Add("p_IMP_FACTURA_CONIVA", OracleDbType.Decimal);
                    P_IMP_FACTURA_CONIVA.Direction = ParameterDirection.Input;
                    P_IMP_FACTURA_CONIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_FACTURA_SINIVA = cmd.Parameters.Add("p_IMP_FACTURA_SINIVA", OracleDbType.Decimal);
                    P_IMP_FACTURA_SINIVA.Direction = ParameterDirection.Input;
                    P_IMP_FACTURA_SINIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PRECIO_FLEMING = cmd.Parameters.Add("p_PRECIO_FLEMING", OracleDbType.Decimal);
                    P_PRECIO_FLEMING.Direction = ParameterDirection.Input;
                    P_PRECIO_FLEMING.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_OBSERVACIONES = cmd.Parameters.Add("p_OBSERVACIONES", OracleDbType.Varchar2);
                    P_OBSERVACIONES.Direction = ParameterDirection.Input;
                    P_OBSERVACIONES.CollectionType = OracleCollectionType.PLSQLAssociativeArray;



                    //LLENAR LOS VALORES DE LOS PARAMETROS
                    List<String> L_ARTICULO_ID = new List<String>();
                    List<String> L_NOMBRE = new List<String>();
                    List<Decimal> L_PRECIO_FARM_REC = new List<Decimal>();
                    List<Decimal> L_CANT_RECIBIDA = new List<Decimal>();
                    List<Decimal> L_CANT_PROX_CADUCAR = new List<Decimal>();
                    List<Decimal> L_CANT_MALESTADO = new List<Decimal>();
                    List<Decimal> L_CANT_REPOSICION = new List<Decimal>();
                    List<Decimal> L_PORC_OFERTA = new List<Decimal>();
                    List<Decimal> L_PORC_DESCTO = new List<Decimal>();
                    List<Decimal> L_PORC_DESCTO_AD1 = new List<Decimal>();
                    List<Decimal> L_PORC_DESCTO_AD2 = new List<Decimal>();
                    List<Decimal> L_PORC_DESCTO_AD3 = new List<Decimal>();
                    List<Decimal> L_PORC_DESCTO_AD4 = new List<Decimal>();
                    List<Decimal> L_IMP_OFERTA_SINIVA = new List<Decimal>();
                    List<Decimal> L_IMP_OFERTA_CONIVA = new List<Decimal>();
                    List<Decimal> L_IMP_DESCTO_SINIVA = new List<Decimal>();
                    List<Decimal> L_IMP_DESCTO_CONIVA = new List<Decimal>();
                    List<Decimal> L_IMPORTE_IVA = new List<Decimal>();
                    List<Decimal> L_IMP_DESCTO_CONIVA_MENOSIVA = new List<Decimal>();
                    List<Decimal> L_IMP_RECEPCION_CONIVA = new List<Decimal>();
                    List<Decimal> L_IMP_RECEPCION_SINIVA = new List<Decimal>();
                    List<Decimal> L_IMP_CAL1_OFERTA_CONIVA = new List<Decimal>();
                    List<Decimal> L_IMP_CAL1_OFERTA_SINIVA = new List<Decimal>();
                    List<Decimal> L_RES_CAL1_DESCTO = new List<Decimal>();
                    List<Decimal> L_RES_CAL2_OFERTA = new List<Decimal>();
                    List<Decimal> L_RES_CAL3_DESCTOAD1 = new List<Decimal>();
                    List<Decimal> L_RES_CAL4_DESCTOAD2 = new List<Decimal>();
                    List<Decimal> L_RES_CAL5_DESCTOAD3 = new List<Decimal>();
                    List<Decimal> L_RES_CAL6_DESCTOAD4 = new List<Decimal>();
                    List<Decimal> L_COSTO_NETO_UNIT_REC = new List<Decimal>();
                    List<Decimal> L_IMPORTE_NETO = new List<Decimal>();
                    List<Decimal> L_DIF_DESCTO_IVA = new List<Decimal>();
                    List<String> L_FLAG_MAL_OFERTADO = new List<String>();
                    List<Decimal> L_DESCUENTO_GENERAL = new List<Decimal>();
                    List<Decimal> L_CANT_FACTURA = new List<Decimal>();
                    List<Decimal> L_CANT_DEV_FALTANTE = new List<Decimal>();
                    List<Decimal> L_CANT_DEV_NO_PEDIDO = new List<Decimal>();
                    List<Decimal> L_CANT_DEV_PRECIO_ELEVADO = new List<Decimal>();
                    List<Decimal> L_CANT_DEV_FILLER1 = new List<Decimal>();
                    List<Decimal> L_CANT_DEV_FILLER2 = new List<Decimal>();
                    List<Decimal> L_PARTIDA = new List<Decimal>();
                    List<String> L_LOTE = new List<String>();
                    List<String> L_CADUCIDAD = new List<String>();
                    List<Decimal> L_CANT_FACTURADA = new List<Decimal>();
                    List<Decimal> L_CANT_SOLICITADA = new List<Decimal>();
                    List<Decimal> L_COSTO = new List<Decimal>();
                    List<Decimal> L_SIN_OFERTA = new List<Decimal>();
                    List<Decimal> L_TOTAL_DESCTO_FACTURA = new List<Decimal>();
                    List<Decimal> L_TOTAL_OFERTA_FACTURA = new List<Decimal>();
                    List<Decimal> L_PRECIO_FACTURA = new List<Decimal>();
                    List<Decimal> L_PRECIO_FARMACIA = new List<Decimal>();
                    List<Decimal> L_IVA_MAL_OFERTADO = new List<Decimal>();
                    List<Decimal> L_PRECIO_MAXIMO = new List<Decimal>();
                    List<Decimal> L_NUEVO_FLEMING = new List<Decimal>();
                    List<Decimal> L_PORC_IVA = new List<Decimal>();
                    List<Decimal> L_MAL_OFERTADO = new List<Decimal>();
                    List<Decimal> L_PRECIO_FACTURA_MAX = new List<Decimal>();
                    List<String> L_CODIGO_PROVEEDOR = new List<String>();
                    List<Decimal> L_PRECIO_VENTA = new List<Decimal>();
                    List<Decimal> L_COSTO_ULT_COMPRA = new List<Decimal>();
                    List<Decimal> L_MARGEN_UTILIDAD = new List<Decimal>();
                    List<Decimal> L_IMP_FACTURA_CONIVA = new List<Decimal>();
                    List<Decimal> L_IMP_FACTURA_SINIVA = new List<Decimal>();
                    List<Decimal> L_PRECIO_FLEMING = new List<Decimal>();
                    List<String> L_OBSERVACIONES = new List<String>();

                    foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row in detalles)
                    {
                        L_ARTICULO_ID.Add(row.ARTICULO_ID);
                        L_NOMBRE.Add(row.NOMBRE);
                        L_PRECIO_FARM_REC.Add((decimal)row.PRECIO_FARM_REC);
                        L_CANT_RECIBIDA.Add((decimal)row.CANT_RECIBIDA);
                        L_CANT_PROX_CADUCAR.Add((decimal)row.CANT_PROX_CADUCAR);
                        L_CANT_MALESTADO.Add((decimal)row.CANT_MALESTADO);
                        L_CANT_REPOSICION.Add((decimal)row.CANT_REPOSICION);
                        L_PORC_OFERTA.Add((decimal)row.PORC_OFERTA);
                        L_PORC_DESCTO.Add((decimal)row.PORC_DESCTO);
                        L_PORC_DESCTO_AD1.Add((decimal)row.PORC_DESCTO_AD1);
                        L_PORC_DESCTO_AD2.Add((decimal)row.PORC_DESCTO_AD2);
                        L_PORC_DESCTO_AD3.Add((decimal)row.PORC_DESCTO_AD3);
                        L_PORC_DESCTO_AD4.Add((decimal)row.PORC_DESCTO_AD4);
                        L_IMP_OFERTA_SINIVA.Add((decimal)row.IMP_OFERTA_SINIVA);
                        L_IMP_OFERTA_CONIVA.Add((decimal)row.IMP_OFERTA_CONIVA);
                        L_IMP_DESCTO_SINIVA.Add((decimal)row.IMP_DESCTO_SINIVA);
                        L_IMP_DESCTO_CONIVA.Add((decimal)row.IMP_DESCTO_CONIVA);
                        L_IMPORTE_IVA.Add((decimal)row.IMPORTE_IVA);
                        L_IMP_DESCTO_CONIVA_MENOSIVA.Add((decimal)row.IMP_DESCTO_CONIVA_MENOSIVA);
                        L_IMP_RECEPCION_CONIVA.Add((decimal)row.IMP_RECEPCION_CONIVA);
                        L_IMP_RECEPCION_SINIVA.Add((decimal)row.IMP_RECEPCION_SINIVA);
                        L_IMP_CAL1_OFERTA_CONIVA.Add((decimal)row.IMP_CAL1_OFERTA_CONIVA);
                        L_IMP_CAL1_OFERTA_SINIVA.Add((decimal)row.IMP_CAL1_OFERTA_SINIVA);
                        L_RES_CAL1_DESCTO.Add((decimal)row.RES_CAL1_DESCTO);
                        L_RES_CAL2_OFERTA.Add((decimal)row.RES_CAL2_OFERTA);
                        L_RES_CAL3_DESCTOAD1.Add((decimal)row.RES_CAL3_DESCTOAD1);
                        L_RES_CAL4_DESCTOAD2.Add((decimal)row.RES_CAL4_DESCTOAD2);
                        L_RES_CAL5_DESCTOAD3.Add((decimal)row.RES_CAL5_DESCTOAD3);
                        L_RES_CAL6_DESCTOAD4.Add((decimal)row.RES_CAL6_DESCTOAD4);
                        L_COSTO_NETO_UNIT_REC.Add((decimal)row.COSTO_NETO_UNIT_REC);
                        L_IMPORTE_NETO.Add((decimal)row.IMPORTE_NETO);
                        L_DIF_DESCTO_IVA.Add((decimal)row.DIF_DESCTO_IVA);
                        L_FLAG_MAL_OFERTADO.Add(row.FLAG_MAL_OFERTADO);
                        L_DESCUENTO_GENERAL.Add((decimal)row.DESCUENTO_GENERAL);
                        L_CANT_FACTURA.Add((decimal)row.CANT_FACTURA);
                        L_CANT_DEV_FALTANTE.Add((decimal)row.CANT_DEV_FALTANTE);
                        L_CANT_DEV_NO_PEDIDO.Add((decimal)row.CANT_DEV_NO_PEDIDO);
                        L_CANT_DEV_PRECIO_ELEVADO.Add((decimal)row.CANT_DEV_PRECIO_ELEVADO);
                        L_CANT_DEV_FILLER1.Add((decimal)row.CANT_DEV_FILLER1);
                        L_CANT_DEV_FILLER2.Add((decimal)row.CANT_DEV_FILLER2);
                        L_PARTIDA.Add((decimal)row.PARTIDA);
                        L_LOTE.Add(row.LOTE);

                        string caducidad = "";
                        if (!row.IsCADUCIDADNull() && row.CADUCIDAD != new DateTime())
                        {
                            caducidad = row.CADUCIDAD.ToString("yyyy-MM-dd HH:mm:ss");
                        }

                        L_CADUCIDAD.Add(caducidad);
                        L_CANT_FACTURADA.Add((decimal)row.CANT_FACTURADA);
                        L_CANT_SOLICITADA.Add((decimal)row.CANT_SOLICITADA);
                        L_COSTO.Add((decimal)row.COSTO);
                        L_SIN_OFERTA.Add((decimal)row.SIN_OFERTA);
                        L_TOTAL_DESCTO_FACTURA.Add((decimal)row.TOTAL_DESCTO_FACTURA);
                        L_TOTAL_OFERTA_FACTURA.Add((decimal)row.TOTAL_OFERTA_FACTURA);
                        L_PRECIO_FACTURA.Add((decimal)row.PRECIO_FACTURA);
                        L_PRECIO_FARMACIA.Add((decimal)row.PRECIO_FARMACIA);
                        L_IVA_MAL_OFERTADO.Add((decimal)row.IVA_MAL_OFERTADO);
                        L_PRECIO_MAXIMO.Add((decimal)row.PRECIO_MAXIMO);
                        L_NUEVO_FLEMING.Add((decimal)row.NUEVO_FLEMING);
                        L_PORC_IVA.Add((decimal)row.PORC_IVA);
                        L_MAL_OFERTADO.Add((decimal)row.MAL_OFERTADO);
                        L_PRECIO_FACTURA_MAX.Add((decimal)row.PRECIO_FACTURA_MAX);
                        L_CODIGO_PROVEEDOR.Add(row.CODIGO_PROVEEDOR);
                        L_PRECIO_VENTA.Add((decimal)row.PRECIO_VENTA);
                        L_COSTO_ULT_COMPRA.Add((decimal)row.COSTO_ULT_COMPRA);
                        L_MARGEN_UTILIDAD.Add((decimal)row.MARGEN_UTILIDAD);
                        L_IMP_FACTURA_CONIVA.Add((decimal)row.IMP_FACTURA_CONIVA);
                        L_IMP_FACTURA_SINIVA.Add((decimal)row.IMP_FACTURA_SINIVA);
                        L_PRECIO_FLEMING.Add((decimal)row.PRECIO_FLEMING);
                        if (row.IsOBSERVACIONESNull())
                        {
                            row.OBSERVACIONES = "";
                        }
                        L_OBSERVACIONES.Add((string)row.OBSERVACIONES);
                    }

                    P_ARTICULO_ID.Value = L_ARTICULO_ID.ToArray();
                    P_NOMBRE.Value = L_NOMBRE.ToArray();
                    P_PRECIO_FARM_REC.Value = L_PRECIO_FARM_REC.ToArray();
                    P_CANT_RECIBIDA.Value = L_CANT_RECIBIDA.ToArray();
                    P_CANT_PROX_CADUCAR.Value = L_CANT_PROX_CADUCAR.ToArray();
                    P_CANT_MALESTADO.Value = L_CANT_MALESTADO.ToArray();
                    P_CANT_REPOSICION.Value = L_CANT_REPOSICION.ToArray();
                    P_PORC_OFERTA.Value = L_PORC_OFERTA.ToArray();
                    P_PORC_DESCTO.Value = L_PORC_DESCTO.ToArray();
                    P_PORC_DESCTO_AD1.Value = L_PORC_DESCTO_AD1.ToArray();
                    P_PORC_DESCTO_AD2.Value = L_PORC_DESCTO_AD2.ToArray();
                    P_PORC_DESCTO_AD3.Value = L_PORC_DESCTO_AD3.ToArray();
                    P_PORC_DESCTO_AD4.Value = L_PORC_DESCTO_AD4.ToArray();
                    P_IMP_OFERTA_SINIVA.Value = L_IMP_OFERTA_SINIVA.ToArray();
                    P_IMP_OFERTA_CONIVA.Value = L_IMP_OFERTA_CONIVA.ToArray();
                    P_IMP_DESCTO_SINIVA.Value = L_IMP_DESCTO_SINIVA.ToArray();
                    P_IMP_DESCTO_CONIVA.Value = L_IMP_DESCTO_CONIVA.ToArray();
                    P_IMPORTE_IVA.Value = L_IMPORTE_IVA.ToArray();
                    P_IMP_DESCTO_CONIVA_MENOSIVA.Value = L_IMP_DESCTO_CONIVA_MENOSIVA.ToArray();
                    P_IMP_RECEPCION_CONIVA.Value = L_IMP_RECEPCION_CONIVA.ToArray();
                    P_IMP_RECEPCION_SINIVA.Value = L_IMP_RECEPCION_SINIVA.ToArray();
                    P_IMP_CAL1_OFERTA_CONIVA.Value = L_IMP_CAL1_OFERTA_CONIVA.ToArray();
                    P_IMP_CAL1_OFERTA_SINIVA.Value = L_IMP_CAL1_OFERTA_SINIVA.ToArray();
                    P_RES_CAL1_DESCTO.Value = L_RES_CAL1_DESCTO.ToArray();
                    P_RES_CAL2_OFERTA.Value = L_RES_CAL2_OFERTA.ToArray();
                    P_RES_CAL3_DESCTOAD1.Value = L_RES_CAL3_DESCTOAD1.ToArray();
                    P_RES_CAL4_DESCTOAD2.Value = L_RES_CAL4_DESCTOAD2.ToArray();
                    P_RES_CAL5_DESCTOAD3.Value = L_RES_CAL5_DESCTOAD3.ToArray();
                    P_RES_CAL6_DESCTOAD4.Value = L_RES_CAL6_DESCTOAD4.ToArray();
                    P_COSTO_NETO_UNIT_REC.Value = L_COSTO_NETO_UNIT_REC.ToArray();
                    P_IMPORTE_NETO.Value = L_IMPORTE_NETO.ToArray();
                    P_DIF_DESCTO_IVA.Value = L_DIF_DESCTO_IVA.ToArray();
                    P_FLAG_MAL_OFERTADO.Value = L_FLAG_MAL_OFERTADO.ToArray();
                    P_DESCUENTO_GENERAL.Value = L_DESCUENTO_GENERAL.ToArray();
                    P_CANT_FACTURA.Value = L_CANT_FACTURA.ToArray();
                    P_CANT_DEV_FALTANTE.Value = L_CANT_DEV_FALTANTE.ToArray();
                    P_CANT_DEV_NO_PEDIDO.Value = L_CANT_DEV_NO_PEDIDO.ToArray();
                    P_CANT_DEV_PRECIO_ELEVADO.Value = L_CANT_DEV_PRECIO_ELEVADO.ToArray();
                    P_CANT_DEV_FILLER1.Value = L_CANT_DEV_FILLER1.ToArray();
                    P_CANT_DEV_FILLER2.Value = L_CANT_DEV_FILLER2.ToArray();
                    P_PARTIDA.Value = L_PARTIDA.ToArray();
                    P_LOTE.Value = L_LOTE.ToArray();
                    P_CADUCIDAD.Value = L_CADUCIDAD.ToArray();
                    P_CANT_FACTURADA.Value = L_CANT_FACTURADA.ToArray();
                    P_CANT_SOLICITADA.Value = L_CANT_SOLICITADA.ToArray();
                    P_COSTO.Value = L_COSTO.ToArray();
                    P_SIN_OFERTA.Value = L_SIN_OFERTA.ToArray();
                    P_TOTAL_DESCTO_FACTURA.Value = L_TOTAL_DESCTO_FACTURA.ToArray();
                    P_TOTAL_OFERTA_FACTURA.Value = L_TOTAL_OFERTA_FACTURA.ToArray();
                    P_PRECIO_FACTURA.Value = L_PRECIO_FACTURA.ToArray();
                    P_PRECIO_FARMACIA.Value = L_PRECIO_FARMACIA.ToArray();
                    P_IVA_MAL_OFERTADO.Value = L_IVA_MAL_OFERTADO.ToArray();
                    P_PRECIO_MAXIMO.Value = L_PRECIO_MAXIMO.ToArray();
                    P_NUEVO_FLEMING.Value = L_NUEVO_FLEMING.ToArray();
                    P_PORC_IVA.Value = L_PORC_IVA.ToArray();
                    P_MAL_OFERTADO.Value = L_MAL_OFERTADO.ToArray();
                    P_PRECIO_FACTURA_MAX.Value = L_PRECIO_FACTURA_MAX.ToArray();
                    P_CODIGO_PROVEEDOR.Value = L_CODIGO_PROVEEDOR.ToArray();
                    P_PRECIO_VENTA.Value = L_PRECIO_VENTA.ToArray();
                    P_COSTO_ULT_COMPRA.Value = L_COSTO_ULT_COMPRA.ToArray();
                    P_MARGEN_UTILIDAD.Value = L_MARGEN_UTILIDAD.ToArray();
                    P_IMP_FACTURA_CONIVA.Value = L_IMP_FACTURA_CONIVA.ToArray();
                    P_IMP_FACTURA_SINIVA.Value = L_IMP_FACTURA_SINIVA.ToArray();
                    P_PRECIO_FLEMING.Value = L_PRECIO_FLEMING.ToArray();
                    P_OBSERVACIONES.Value = L_OBSERVACIONES.ToArray();

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("OutParam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }

            return true;
        }


        public static bool InsertaDetalle(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow rowCompras, SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow detalle)
        {
            string sentencia = "PKG_COMPRAS.SP_INS_ORDEN_COMPRA_DET";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("p_FOLIO_COMPRA", rowCompras.FOLIO_COMPRA);
                    cmd.Parameters.Add("p_FOLIO_OC", rowCompras.FOLIO_OC);
                    cmd.Parameters.Add("p_PROVEEDOR_ID", rowCompras.PROVEEDOR_ID);
                    cmd.Parameters.Add("p_ARTICULO_ID", detalle.ARTICULO_ID);
                    cmd.Parameters.Add("p_NOMBRE", detalle.NOMBRE);
                    cmd.Parameters.Add("p_PRECIO_FARM_REC", detalle.PRECIO_FARM_REC);
                    cmd.Parameters.Add("p_CANT_RECIBIDA", detalle.CANT_RECIBIDA);
                    cmd.Parameters.Add("p_CANT_PROX_CADUCAR", detalle.CANT_PROX_CADUCAR);
                    cmd.Parameters.Add("p_CANT_MALESTADO", detalle.CANT_MALESTADO);
                    cmd.Parameters.Add("p_CANT_REPOSICION", detalle.CANT_REPOSICION);
                    cmd.Parameters.Add("p_PORC_OFERTA", detalle.PORC_OFERTA);
                    cmd.Parameters.Add("p_PORC_DESCTO", detalle.PORC_DESCTO);
                    cmd.Parameters.Add("p_PORC_DESCTO_AD1", detalle.PORC_DESCTO_AD1);
                    cmd.Parameters.Add("p_PORC_DESCTO_AD2", detalle.PORC_DESCTO_AD2);
                    cmd.Parameters.Add("p_PORC_DESCTO_AD3", detalle.PORC_DESCTO_AD3);
                    cmd.Parameters.Add("p_PORC_DESCTO_AD4", detalle.PORC_DESCTO_AD4);
                    cmd.Parameters.Add("p_IMP_OFERTA_SINIVA", detalle.IMP_OFERTA_SINIVA);
                    cmd.Parameters.Add("p_IMP_OFERTA_CONIVA", detalle.IMP_OFERTA_CONIVA);
                    cmd.Parameters.Add("p_IMP_DESCTO_SINIVA", detalle.IMP_DESCTO_SINIVA);
                    cmd.Parameters.Add("p_IMP_DESCTO_CONIVA", detalle.IMP_DESCTO_CONIVA);
                    cmd.Parameters.Add("p_IMPORTE_IVA", detalle.IMPORTE_IVA);
                    cmd.Parameters.Add("p_IMP_DESCTO_CONIVA_MENOSIVA", detalle.IMP_DESCTO_CONIVA_MENOSIVA);
                    cmd.Parameters.Add("p_IMP_RECEPCION_CONIVA", detalle.IMP_RECEPCION_CONIVA);
                    cmd.Parameters.Add("p_IMP_RECEPCION_SINIVA", detalle.IMP_RECEPCION_SINIVA);
                    cmd.Parameters.Add("p_IMP_CAL1_OFERTA_CONIVA", detalle.IMP_CAL1_OFERTA_CONIVA);
                    cmd.Parameters.Add("p_IMP_CAL1_OFERTA_SINIVA", detalle.IMP_CAL1_OFERTA_SINIVA);
                    cmd.Parameters.Add("p_RES_CAL1_DESCTO", detalle.RES_CAL1_DESCTO);
                    cmd.Parameters.Add("p_RES_CAL2_OFERTA", detalle.RES_CAL2_OFERTA);
                    cmd.Parameters.Add("p_RES_CAL3_DESCTOAD1", detalle.RES_CAL3_DESCTOAD1);
                    cmd.Parameters.Add("p_RES_CAL4_DESCTOAD2", detalle.RES_CAL4_DESCTOAD2);
                    cmd.Parameters.Add("p_RES_CAL5_DESCTOAD3", detalle.RES_CAL5_DESCTOAD3);
                    cmd.Parameters.Add("p_RES_CAL6_DESCTOAD4", detalle.RES_CAL6_DESCTOAD4);
                    cmd.Parameters.Add("p_COSTO_NETO_UNIT_REC", detalle.COSTO_NETO_UNIT_REC);
                    cmd.Parameters.Add("p_IMPORTE_NETO", detalle.IMPORTE_NETO);
                    cmd.Parameters.Add("p_DIF_DESCTO_IVA", detalle.DIF_DESCTO_IVA);
                    cmd.Parameters.Add("p_FLAG_MAL_OFERTADO", detalle.FLAG_MAL_OFERTADO);
                    cmd.Parameters.Add("p_DESCUENTO_GENERAL", detalle.DESCUENTO_GENERAL);
                    cmd.Parameters.Add("p_CANT_FACTURA", detalle.CANT_FACTURA);
                    cmd.Parameters.Add("p_CANT_DEV_FALTANTE", detalle.CANT_DEV_FALTANTE);
                    cmd.Parameters.Add("p_CANT_DEV_NO_PEDIDO", detalle.CANT_DEV_NO_PEDIDO);
                    cmd.Parameters.Add("p_CANT_DEV_PRECIO_ELEVADO", detalle.CANT_DEV_PRECIO_ELEVADO);
                    cmd.Parameters.Add("p_CANT_DEV_FILLER1", detalle.CANT_DEV_FILLER1);
                    cmd.Parameters.Add("p_CANT_DEV_FILLER2", detalle.CANT_DEV_FILLER2);
                    cmd.Parameters.Add("p_PARTIDA", detalle.PARTIDA);
                    cmd.Parameters.Add("p_LOTE", detalle.LOTE);

                    string caducidad = "";
                    if (!detalle.IsCADUCIDADNull() && detalle.CADUCIDAD != new DateTime())
                    {
                        caducidad = detalle.CADUCIDAD.ToString("yyyy-MM-dd HH:mm:ss");
                    }
 
                    cmd.Parameters.Add("p_CADUCIDAD", caducidad);
                    cmd.Parameters.Add("p_CANT_FACTURADA", detalle.CANT_FACTURADA);
                    cmd.Parameters.Add("p_CANT_SOLICITADA", detalle.CANT_SOLICITADA);
                    cmd.Parameters.Add("p_COSTO", detalle.COSTO);
                    cmd.Parameters.Add("p_SIN_OFERTA", detalle.SIN_OFERTA);
                    cmd.Parameters.Add("p_TOTAL_DESCTO_FACTURA", detalle.TOTAL_DESCTO_FACTURA);
                    cmd.Parameters.Add("p_TOTAL_OFERTA_FACTURA", detalle.TOTAL_OFERTA_FACTURA);
                    cmd.Parameters.Add("p_PRECIO_FACTURA", detalle.PRECIO_FACTURA);
                    cmd.Parameters.Add("p_PRECIO_FARMACIA", detalle.PRECIO_FARMACIA);
                    cmd.Parameters.Add("p_IVA_MAL_OFERTADO", detalle.IVA_MAL_OFERTADO);
                    cmd.Parameters.Add("p_PRECIO_MAXIMO", detalle.PRECIO_MAXIMO);
                    cmd.Parameters.Add("p_NUEVO_FLEMING", detalle.NUEVO_FLEMING);
                    cmd.Parameters.Add("p_PORC_IVA", detalle.PORC_IVA);
                    cmd.Parameters.Add("p_MAL_OFERTADO", detalle.MAL_OFERTADO);
                    cmd.Parameters.Add("p_PRECIO_FACTURA_MAX", detalle.PRECIO_FACTURA_MAX);
                    cmd.Parameters.Add("p_CODIGO_PROVEEDOR", detalle.CODIGO_PROVEEDOR);
                    cmd.Parameters.Add("p_PRECIO_VENTA", detalle.PRECIO_VENTA);
                    cmd.Parameters.Add("p_COSTO_ULT_COMPRA", detalle.COSTO_ULT_COMPRA);
                    cmd.Parameters.Add("p_MARGEN_UTILIDAD", detalle.MARGEN_UTILIDAD);
                    cmd.Parameters.Add("p_IMP_FACTURA_CONIVA", detalle.IMP_FACTURA_CONIVA);
                    cmd.Parameters.Add("p_IMP_FACTURA_SINIVA", detalle.IMP_FACTURA_SINIVA);
                    cmd.Parameters.Add("p_PRECIO_FLEMING", detalle.PRECIO_FLEMING);
                    

                    cmd.Parameters.Add("p_OBSERVACIONES", detalle.IsOBSERVACIONESNull()?"":detalle.OBSERVACIONES);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("OutParam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }

            return true;
        }

        public static bool ActualizaDetalle(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow rowCompras, SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow detalle)
        {
            string sentencia = "PKG_COMPRAS.SP_UPD_COMPRA_DET";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;
                    if (detalle.ARTICULO_ID == "7501001147594")
                    { 
                    
                    }
                    //PARAMETROS
                    cmd.Parameters.Add("p_FOLIO_COMPRA", rowCompras.FOLIO_COMPRA);
                    cmd.Parameters.Add("p_FOLIO_OC", rowCompras.FOLIO_OC);
                    cmd.Parameters.Add("p_PROVEEDOR_ID", rowCompras.PROVEEDOR_ID);
                    cmd.Parameters.Add("p_ARTICULO_ID", detalle.ARTICULO_ID);
                    cmd.Parameters.Add("p_NOMBRE", detalle.NOMBRE);
                    cmd.Parameters.Add("p_PRECIO_FARM_REC", detalle.PRECIO_FARM_REC);
                    cmd.Parameters.Add("p_CANT_RECIBIDA", detalle.CANT_RECIBIDA);
                    cmd.Parameters.Add("p_CANT_PROX_CADUCAR", detalle.CANT_PROX_CADUCAR);
                    cmd.Parameters.Add("p_CANT_MALESTADO", detalle.CANT_MALESTADO);
                    cmd.Parameters.Add("p_CANT_REPOSICION", detalle.CANT_REPOSICION);
                    cmd.Parameters.Add("p_PORC_OFERTA", detalle.PORC_OFERTA);
                    cmd.Parameters.Add("p_PORC_DESCTO", detalle.PORC_DESCTO);
                    cmd.Parameters.Add("p_PORC_DESCTO_AD1", detalle.PORC_DESCTO_AD1);
                    cmd.Parameters.Add("p_PORC_DESCTO_AD2", detalle.PORC_DESCTO_AD2);
                    cmd.Parameters.Add("p_PORC_DESCTO_AD3", detalle.PORC_DESCTO_AD3);
                    cmd.Parameters.Add("p_PORC_DESCTO_AD4", detalle.PORC_DESCTO_AD4);
                    cmd.Parameters.Add("p_IMP_OFERTA_SINIVA", detalle.IMP_OFERTA_SINIVA);
                    cmd.Parameters.Add("p_IMP_OFERTA_CONIVA", detalle.IMP_OFERTA_CONIVA);
                    cmd.Parameters.Add("p_IMP_DESCTO_SINIVA", detalle.IMP_DESCTO_SINIVA);
                    cmd.Parameters.Add("p_IMP_DESCTO_CONIVA", detalle.IMP_DESCTO_CONIVA);
                    cmd.Parameters.Add("p_IMPORTE_IVA", detalle.IMPORTE_IVA);
                    cmd.Parameters.Add("p_IMP_DESCTO_CONIVA_MENOSIVA", detalle.IMP_DESCTO_CONIVA_MENOSIVA);
                    cmd.Parameters.Add("p_IMP_RECEPCION_CONIVA", detalle.IMP_RECEPCION_CONIVA);
                    cmd.Parameters.Add("p_IMP_RECEPCION_SINIVA", detalle.IMP_RECEPCION_SINIVA);
                    cmd.Parameters.Add("p_IMP_CAL1_OFERTA_CONIVA", detalle.IMP_CAL1_OFERTA_CONIVA);
                    cmd.Parameters.Add("p_IMP_CAL1_OFERTA_SINIVA", detalle.IMP_CAL1_OFERTA_SINIVA);
                    cmd.Parameters.Add("p_RES_CAL1_DESCTO", detalle.RES_CAL1_DESCTO);
                    cmd.Parameters.Add("p_RES_CAL2_OFERTA", detalle.RES_CAL2_OFERTA);
                    cmd.Parameters.Add("p_RES_CAL3_DESCTOAD1", detalle.RES_CAL3_DESCTOAD1);
                    cmd.Parameters.Add("p_RES_CAL4_DESCTOAD2", detalle.RES_CAL4_DESCTOAD2);
                    cmd.Parameters.Add("p_RES_CAL5_DESCTOAD3", detalle.RES_CAL5_DESCTOAD3);
                    cmd.Parameters.Add("p_RES_CAL6_DESCTOAD4", detalle.RES_CAL6_DESCTOAD4);
                    cmd.Parameters.Add("p_COSTO_NETO_UNIT_REC", detalle.COSTO_NETO_UNIT_REC);
                    cmd.Parameters.Add("p_IMPORTE_NETO", detalle.IMPORTE_NETO);
                    cmd.Parameters.Add("p_DIF_DESCTO_IVA", detalle.DIF_DESCTO_IVA);
                    cmd.Parameters.Add("p_FLAG_MAL_OFERTADO", detalle.FLAG_MAL_OFERTADO);
                    cmd.Parameters.Add("p_DESCUENTO_GENERAL", detalle.DESCUENTO_GENERAL);
                    cmd.Parameters.Add("p_CANT_FACTURA", detalle.CANT_FACTURA);
                    cmd.Parameters.Add("p_CANT_DEV_FALTANTE", detalle.CANT_DEV_FALTANTE);
                    cmd.Parameters.Add("p_CANT_DEV_NO_PEDIDO", detalle.CANT_DEV_NO_PEDIDO);
                    cmd.Parameters.Add("p_CANT_DEV_PRECIO_ELEVADO", detalle.CANT_DEV_PRECIO_ELEVADO);
                    cmd.Parameters.Add("p_CANT_DEV_FILLER1", detalle.CANT_DEV_FILLER1);
                    cmd.Parameters.Add("p_CANT_DEV_FILLER2", detalle.CANT_DEV_FILLER2);
                    cmd.Parameters.Add("p_PARTIDA", detalle.PARTIDA);
                    if (detalle.IsLOTENull())
                    {
                        detalle.LOTE = " ";
                    }
                    cmd.Parameters.Add("p_LOTE", detalle.LOTE);
                    string caducidad = "";
                    if (!detalle.IsCADUCIDADNull() && detalle.CADUCIDAD != new DateTime())
                    {
                        caducidad = detalle.CADUCIDAD.ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    cmd.Parameters.Add("p_CADUCIDAD", caducidad);
                    cmd.Parameters.Add("p_CANT_FACTURADA", detalle.CANT_FACTURADA);
                    cmd.Parameters.Add("p_CANT_SOLICITADA", detalle.CANT_SOLICITADA);
                    cmd.Parameters.Add("p_COSTO", detalle.COSTO);
                    cmd.Parameters.Add("p_SIN_OFERTA", detalle.SIN_OFERTA);
                    cmd.Parameters.Add("p_TOTAL_DESCTO_FACTURA", detalle.TOTAL_DESCTO_FACTURA);
                    cmd.Parameters.Add("p_TOTAL_OFERTA_FACTURA", detalle.TOTAL_OFERTA_FACTURA);
                    cmd.Parameters.Add("p_PRECIO_FACTURA", detalle.PRECIO_FACTURA);
                    cmd.Parameters.Add("p_PRECIO_FARMACIA", detalle.PRECIO_FARMACIA);
                    cmd.Parameters.Add("p_IVA_MAL_OFERTADO", detalle.IVA_MAL_OFERTADO);
                    cmd.Parameters.Add("p_PRECIO_MAXIMO", detalle.PRECIO_MAXIMO);
                    cmd.Parameters.Add("p_NUEVO_FLEMING", detalle.NUEVO_FLEMING);
                    cmd.Parameters.Add("p_PORC_IVA", detalle.PORC_IVA);
                    cmd.Parameters.Add("p_MAL_OFERTADO", detalle.MAL_OFERTADO);
                    cmd.Parameters.Add("p_PRECIO_FACTURA_MAX", detalle.PRECIO_FACTURA_MAX);
                    cmd.Parameters.Add("p_CODIGO_PROVEEDOR", detalle.CODIGO_PROVEEDOR);
                    cmd.Parameters.Add("p_PRECIO_VENTA", detalle.PRECIO_VENTA);
                    cmd.Parameters.Add("p_COSTO_ULT_COMPRA", detalle.COSTO_ULT_COMPRA);
                    cmd.Parameters.Add("p_MARGEN_UTILIDAD", detalle.MARGEN_UTILIDAD);
                    cmd.Parameters.Add("p_IMP_FACTURA_CONIVA", detalle.IMP_FACTURA_CONIVA);
                    cmd.Parameters.Add("p_IMP_FACTURA_SINIVA", detalle.IMP_FACTURA_SINIVA);
                    cmd.Parameters.Add("p_PRECIO_FLEMING", detalle.PRECIO_FLEMING);
                    if (detalle.IsOBSERVACIONESNull())
                    {
                        detalle.OBSERVACIONES = "";
                    }
                    cmd.Parameters.Add("p_OBSERVACIONES", detalle.OBSERVACIONES);
                    if (detalle.IsIMPORTE_IEPSNull())
                    {
                        detalle.IMPORTE_IEPS = 0;
                    }
                    cmd.Parameters.Add("p_IMPORTE_IEPS", detalle.IMPORTE_IEPS);
                    if (detalle.IsPORCENTAJE_IEPSNull())
                    {
                        detalle.PORCENTAJE_IEPS = 0;
                    }
                    cmd.Parameters.Add("p_PORCENTAJE_IEPS", detalle.PORCENTAJE_IEPS);

                    if (detalle.IsIEPS_MALNull())
                    {
                        detalle.IEPS_MAL = 0;
                    }
                    cmd.Parameters.Add("p_IEPS_MAL", detalle.IEPS_MAL);


                    if (detalle.IsDESC1_DESCNull())
                    {
                        detalle.DESC1_DESC = "";
                    }
                    if (detalle.IsDESC2_DESCNull())
                    {
                        detalle.DESC2_DESC = "";
                    }
                    if (detalle.IsDESC3_DESCNull())
                    {
                        detalle.DESC3_DESC = "";
                    }

                    cmd.Parameters.Add("p_DESC1_DESC", detalle.DESC1_DESC);
                    cmd.Parameters.Add("p_DESC2_DESC", detalle.DESC2_DESC);
                    cmd.Parameters.Add("p_DESC3_DESC", detalle.DESC3_DESC);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("OutParam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }

            return true;
        }

        public static bool ActualizaDetalles(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow rowCompras, SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable detalles)
        {
            string sentencia = "PKG_COMPRAS.SP_UPD_COMPRA_BULK_DET";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("p_FOLIO_COMPRA", rowCompras.FOLIO_COMPRA);
                    cmd.Parameters.Add("p_FOLIO_OC", rowCompras.FOLIO_OC);
                    cmd.Parameters.Add("p_PROVEEDOR_ID", rowCompras.PROVEEDOR_ID);

                    OracleParameter P_ARTICULO_ID = cmd.Parameters.Add("p_ARTICULO_ID", OracleDbType.Varchar2);
                    P_ARTICULO_ID.Direction = ParameterDirection.Input;
                    P_ARTICULO_ID.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_NOMBRE = cmd.Parameters.Add("p_NOMBRE", OracleDbType.Varchar2);
                    P_NOMBRE.Direction = ParameterDirection.Input;
                    P_NOMBRE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PRECIO_FARM_REC = cmd.Parameters.Add("p_PRECIO_FARM_REC", OracleDbType.Decimal);
                    P_PRECIO_FARM_REC.Direction = ParameterDirection.Input;
                    P_PRECIO_FARM_REC.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_RECIBIDA = cmd.Parameters.Add("p_CANT_RECIBIDA", OracleDbType.Decimal);
                    P_CANT_RECIBIDA.Direction = ParameterDirection.Input;
                    P_CANT_RECIBIDA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_PROX_CADUCAR = cmd.Parameters.Add("p_CANT_PROX_CADUCAR", OracleDbType.Decimal);
                    P_CANT_PROX_CADUCAR.Direction = ParameterDirection.Input;
                    P_CANT_PROX_CADUCAR.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_MALESTADO = cmd.Parameters.Add("p_CANT_MALESTADO", OracleDbType.Decimal);
                    P_CANT_MALESTADO.Direction = ParameterDirection.Input;
                    P_CANT_MALESTADO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_REPOSICION = cmd.Parameters.Add("p_CANT_REPOSICION", OracleDbType.Decimal);
                    P_CANT_REPOSICION.Direction = ParameterDirection.Input;
                    P_CANT_REPOSICION.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PORC_OFERTA = cmd.Parameters.Add("p_PORC_OFERTA", OracleDbType.Decimal);
                    P_PORC_OFERTA.Direction = ParameterDirection.Input;
                    P_PORC_OFERTA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PORC_DESCTO = cmd.Parameters.Add("p_PORC_DESCTO", OracleDbType.Decimal);
                    P_PORC_DESCTO.Direction = ParameterDirection.Input;
                    P_PORC_DESCTO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PORC_DESCTO_AD1 = cmd.Parameters.Add("p_PORC_DESCTO_AD1", OracleDbType.Decimal);
                    P_PORC_DESCTO_AD1.Direction = ParameterDirection.Input;
                    P_PORC_DESCTO_AD1.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PORC_DESCTO_AD2 = cmd.Parameters.Add("p_PORC_DESCTO_AD2", OracleDbType.Decimal);
                    P_PORC_DESCTO_AD2.Direction = ParameterDirection.Input;
                    P_PORC_DESCTO_AD2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PORC_DESCTO_AD3 = cmd.Parameters.Add("p_PORC_DESCTO_AD3", OracleDbType.Decimal);
                    P_PORC_DESCTO_AD3.Direction = ParameterDirection.Input;
                    P_PORC_DESCTO_AD3.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PORC_DESCTO_AD4 = cmd.Parameters.Add("p_PORC_DESCTO_AD4", OracleDbType.Decimal);
                    P_PORC_DESCTO_AD4.Direction = ParameterDirection.Input;
                    P_PORC_DESCTO_AD4.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_OFERTA_SINIVA = cmd.Parameters.Add("p_IMP_OFERTA_SINIVA", OracleDbType.Decimal);
                    P_IMP_OFERTA_SINIVA.Direction = ParameterDirection.Input;
                    P_IMP_OFERTA_SINIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_OFERTA_CONIVA = cmd.Parameters.Add("p_IMP_OFERTA_CONIVA", OracleDbType.Decimal);
                    P_IMP_OFERTA_CONIVA.Direction = ParameterDirection.Input;
                    P_IMP_OFERTA_CONIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_DESCTO_SINIVA = cmd.Parameters.Add("p_IMP_DESCTO_SINIVA", OracleDbType.Decimal);
                    P_IMP_DESCTO_SINIVA.Direction = ParameterDirection.Input;
                    P_IMP_DESCTO_SINIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_DESCTO_CONIVA = cmd.Parameters.Add("p_IMP_DESCTO_CONIVA", OracleDbType.Decimal);
                    P_IMP_DESCTO_CONIVA.Direction = ParameterDirection.Input;
                    P_IMP_DESCTO_CONIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMPORTE_IVA = cmd.Parameters.Add("p_IMPORTE_IVA", OracleDbType.Decimal);
                    P_IMPORTE_IVA.Direction = ParameterDirection.Input;
                    P_IMPORTE_IVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_DESCTO_CONIVA_MENOSIVA = cmd.Parameters.Add("p_IMP_DESCTO_CONIVA_MENOSIVA", OracleDbType.Decimal);
                    P_IMP_DESCTO_CONIVA_MENOSIVA.Direction = ParameterDirection.Input;
                    P_IMP_DESCTO_CONIVA_MENOSIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_RECEPCION_CONIVA = cmd.Parameters.Add("p_IMP_RECEPCION_CONIVA", OracleDbType.Decimal);
                    P_IMP_RECEPCION_CONIVA.Direction = ParameterDirection.Input;
                    P_IMP_RECEPCION_CONIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_RECEPCION_SINIVA = cmd.Parameters.Add("p_IMP_RECEPCION_SINIVA", OracleDbType.Decimal);
                    P_IMP_RECEPCION_SINIVA.Direction = ParameterDirection.Input;
                    P_IMP_RECEPCION_SINIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_CAL1_OFERTA_CONIVA = cmd.Parameters.Add("p_IMP_CAL1_OFERTA_CONIVA", OracleDbType.Decimal);
                    P_IMP_CAL1_OFERTA_CONIVA.Direction = ParameterDirection.Input;
                    P_IMP_CAL1_OFERTA_CONIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_CAL1_OFERTA_SINIVA = cmd.Parameters.Add("p_IMP_CAL1_OFERTA_SINIVA", OracleDbType.Decimal);
                    P_IMP_CAL1_OFERTA_SINIVA.Direction = ParameterDirection.Input;
                    P_IMP_CAL1_OFERTA_SINIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_RES_CAL1_DESCTO = cmd.Parameters.Add("p_RES_CAL1_DESCTO", OracleDbType.Decimal);
                    P_RES_CAL1_DESCTO.Direction = ParameterDirection.Input;
                    P_RES_CAL1_DESCTO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_RES_CAL2_OFERTA = cmd.Parameters.Add("p_RES_CAL2_OFERTA", OracleDbType.Decimal);
                    P_RES_CAL2_OFERTA.Direction = ParameterDirection.Input;
                    P_RES_CAL2_OFERTA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_RES_CAL3_DESCTOAD1 = cmd.Parameters.Add("p_RES_CAL3_DESCTOAD1", OracleDbType.Decimal);
                    P_RES_CAL3_DESCTOAD1.Direction = ParameterDirection.Input;
                    P_RES_CAL3_DESCTOAD1.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_RES_CAL4_DESCTOAD2 = cmd.Parameters.Add("p_RES_CAL4_DESCTOAD2", OracleDbType.Decimal);
                    P_RES_CAL4_DESCTOAD2.Direction = ParameterDirection.Input;
                    P_RES_CAL4_DESCTOAD2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_RES_CAL5_DESCTOAD3 = cmd.Parameters.Add("p_RES_CAL5_DESCTOAD3", OracleDbType.Decimal);
                    P_RES_CAL5_DESCTOAD3.Direction = ParameterDirection.Input;
                    P_RES_CAL5_DESCTOAD3.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_RES_CAL6_DESCTOAD4 = cmd.Parameters.Add("p_RES_CAL6_DESCTOAD4", OracleDbType.Decimal);
                    P_RES_CAL6_DESCTOAD4.Direction = ParameterDirection.Input;
                    P_RES_CAL6_DESCTOAD4.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_COSTO_NETO_UNIT_REC = cmd.Parameters.Add("p_COSTO_NETO_UNIT_REC", OracleDbType.Decimal);
                    P_COSTO_NETO_UNIT_REC.Direction = ParameterDirection.Input;
                    P_COSTO_NETO_UNIT_REC.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMPORTE_NETO = cmd.Parameters.Add("p_IMPORTE_NETO", OracleDbType.Decimal);
                    P_IMPORTE_NETO.Direction = ParameterDirection.Input;
                    P_IMPORTE_NETO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_DIF_DESCTO_IVA = cmd.Parameters.Add("p_DIF_DESCTO_IVA", OracleDbType.Decimal);
                    P_DIF_DESCTO_IVA.Direction = ParameterDirection.Input;
                    P_DIF_DESCTO_IVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_FLAG_MAL_OFERTADO = cmd.Parameters.Add("p_FLAG_MAL_OFERTADO", OracleDbType.Varchar2);
                    P_FLAG_MAL_OFERTADO.Direction = ParameterDirection.Input;
                    P_FLAG_MAL_OFERTADO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_DESCUENTO_GENERAL = cmd.Parameters.Add("p_DESCUENTO_GENERAL", OracleDbType.Decimal);
                    P_DESCUENTO_GENERAL.Direction = ParameterDirection.Input;
                    P_DESCUENTO_GENERAL.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_FACTURA = cmd.Parameters.Add("p_CANT_FACTURA", OracleDbType.Decimal);
                    P_CANT_FACTURA.Direction = ParameterDirection.Input;
                    P_CANT_FACTURA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_DEV_FALTANTE = cmd.Parameters.Add("p_CANT_DEV_FALTANTE", OracleDbType.Decimal);
                    P_CANT_DEV_FALTANTE.Direction = ParameterDirection.Input;
                    P_CANT_DEV_FALTANTE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_DEV_NO_PEDIDO = cmd.Parameters.Add("p_CANT_DEV_NO_PEDIDO", OracleDbType.Decimal);
                    P_CANT_DEV_NO_PEDIDO.Direction = ParameterDirection.Input;
                    P_CANT_DEV_NO_PEDIDO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_DEV_PRECIO_ELEVADO = cmd.Parameters.Add("p_CANT_DEV_PRECIO_ELEVADO", OracleDbType.Decimal);
                    P_CANT_DEV_PRECIO_ELEVADO.Direction = ParameterDirection.Input;
                    P_CANT_DEV_PRECIO_ELEVADO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_DEV_FILLER1 = cmd.Parameters.Add("p_CANT_DEV_FILLER1", OracleDbType.Decimal);
                    P_CANT_DEV_FILLER1.Direction = ParameterDirection.Input;
                    P_CANT_DEV_FILLER1.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_DEV_FILLER2 = cmd.Parameters.Add("p_CANT_DEV_FILLER2", OracleDbType.Decimal);
                    P_CANT_DEV_FILLER2.Direction = ParameterDirection.Input;
                    P_CANT_DEV_FILLER2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PARTIDA = cmd.Parameters.Add("p_PARTIDA", OracleDbType.Decimal);
                    P_PARTIDA.Direction = ParameterDirection.Input;
                    P_PARTIDA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_LOTE = cmd.Parameters.Add("p_LOTE", OracleDbType.Varchar2);
                    P_LOTE.Direction = ParameterDirection.Input;
                    P_LOTE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CADUCIDAD = cmd.Parameters.Add("p_CADUCIDAD", OracleDbType.Varchar2);
                    P_CADUCIDAD.Direction = ParameterDirection.Input;
                    P_CADUCIDAD.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_FACTURADA = cmd.Parameters.Add("p_CANT_FACTURADA", OracleDbType.Decimal);
                    P_CANT_FACTURADA.Direction = ParameterDirection.Input;
                    P_CANT_FACTURADA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_SOLICITADA = cmd.Parameters.Add("p_CANT_SOLICITADA", OracleDbType.Decimal);
                    P_CANT_SOLICITADA.Direction = ParameterDirection.Input;
                    P_CANT_SOLICITADA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_COSTO = cmd.Parameters.Add("p_COSTO", OracleDbType.Decimal);
                    P_COSTO.Direction = ParameterDirection.Input;
                    P_COSTO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_SIN_OFERTA = cmd.Parameters.Add("p_SIN_OFERTA", OracleDbType.Decimal);
                    P_SIN_OFERTA.Direction = ParameterDirection.Input;
                    P_SIN_OFERTA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_TOTAL_DESCTO_FACTURA = cmd.Parameters.Add("p_TOTAL_DESCTO_FACTURA", OracleDbType.Decimal);
                    P_TOTAL_DESCTO_FACTURA.Direction = ParameterDirection.Input;
                    P_TOTAL_DESCTO_FACTURA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_TOTAL_OFERTA_FACTURA = cmd.Parameters.Add("p_TOTAL_OFERTA_FACTURA", OracleDbType.Decimal);
                    P_TOTAL_OFERTA_FACTURA.Direction = ParameterDirection.Input;
                    P_TOTAL_OFERTA_FACTURA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PRECIO_FACTURA = cmd.Parameters.Add("p_PRECIO_FACTURA", OracleDbType.Decimal);
                    P_PRECIO_FACTURA.Direction = ParameterDirection.Input;
                    P_PRECIO_FACTURA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PRECIO_FARMACIA = cmd.Parameters.Add("p_PRECIO_FARMACIA", OracleDbType.Decimal);
                    P_PRECIO_FARMACIA.Direction = ParameterDirection.Input;
                    P_PRECIO_FARMACIA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IVA_MAL_OFERTADO = cmd.Parameters.Add("p_IVA_MAL_OFERTADO", OracleDbType.Decimal);
                    P_IVA_MAL_OFERTADO.Direction = ParameterDirection.Input;
                    P_IVA_MAL_OFERTADO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PRECIO_MAXIMO = cmd.Parameters.Add("p_PRECIO_MAXIMO", OracleDbType.Decimal);
                    P_PRECIO_MAXIMO.Direction = ParameterDirection.Input;
                    P_PRECIO_MAXIMO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_NUEVO_FLEMING = cmd.Parameters.Add("p_NUEVO_FLEMING", OracleDbType.Decimal);
                    P_NUEVO_FLEMING.Direction = ParameterDirection.Input;
                    P_NUEVO_FLEMING.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PORC_IVA = cmd.Parameters.Add("p_PORC_IVA", OracleDbType.Decimal);
                    P_PORC_IVA.Direction = ParameterDirection.Input;
                    P_PORC_IVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_MAL_OFERTADO = cmd.Parameters.Add("p_MAL_OFERTADO", OracleDbType.Decimal);
                    P_MAL_OFERTADO.Direction = ParameterDirection.Input;
                    P_MAL_OFERTADO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PRECIO_FACTURA_MAX = cmd.Parameters.Add("p_PRECIO_FACTURA_MAX", OracleDbType.Decimal);
                    P_PRECIO_FACTURA_MAX.Direction = ParameterDirection.Input;
                    P_PRECIO_FACTURA_MAX.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CODIGO_PROVEEDOR = cmd.Parameters.Add("p_CODIGO_PROVEEDOR", OracleDbType.Varchar2);
                    P_CODIGO_PROVEEDOR.Direction = ParameterDirection.Input;
                    P_CODIGO_PROVEEDOR.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PRECIO_VENTA = cmd.Parameters.Add("p_PRECIO_VENTA", OracleDbType.Decimal);
                    P_PRECIO_VENTA.Direction = ParameterDirection.Input;
                    P_PRECIO_VENTA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_COSTO_ULT_COMPRA = cmd.Parameters.Add("p_COSTO_ULT_COMPRA", OracleDbType.Decimal);
                    P_COSTO_ULT_COMPRA.Direction = ParameterDirection.Input;
                    P_COSTO_ULT_COMPRA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_MARGEN_UTILIDAD = cmd.Parameters.Add("p_MARGEN_UTILIDAD", OracleDbType.Decimal);
                    P_MARGEN_UTILIDAD.Direction = ParameterDirection.Input;
                    P_MARGEN_UTILIDAD.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_FACTURA_CONIVA = cmd.Parameters.Add("p_IMP_FACTURA_CONIVA", OracleDbType.Decimal);
                    P_IMP_FACTURA_CONIVA.Direction = ParameterDirection.Input;
                    P_IMP_FACTURA_CONIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMP_FACTURA_SINIVA = cmd.Parameters.Add("p_IMP_FACTURA_SINIVA", OracleDbType.Decimal);
                    P_IMP_FACTURA_SINIVA.Direction = ParameterDirection.Input;
                    P_IMP_FACTURA_SINIVA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PRECIO_FLEMING = cmd.Parameters.Add("p_PRECIO_FLEMING", OracleDbType.Decimal);
                    P_PRECIO_FLEMING.Direction = ParameterDirection.Input;
                    P_PRECIO_FLEMING.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_OBSERVACIONES = cmd.Parameters.Add("p_OBSERVACIONES", OracleDbType.Varchar2);
                    P_OBSERVACIONES.Direction = ParameterDirection.Input;
                    P_OBSERVACIONES.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IMPORTE_IEPS = cmd.Parameters.Add("p_IMPORTE_IEPS", OracleDbType.Decimal);
                    P_IMPORTE_IEPS.Direction = ParameterDirection.Input;
                    P_IMPORTE_IEPS.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_PORCENTAJE_IEPS = cmd.Parameters.Add("p_PORCENTAJE_IEPS", OracleDbType.Decimal);
                    P_PORCENTAJE_IEPS.Direction = ParameterDirection.Input;
                    P_PORCENTAJE_IEPS.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_IEPS_MAL = cmd.Parameters.Add("p_IEPS_MAL", OracleDbType.Decimal);
                    P_IEPS_MAL.Direction = ParameterDirection.Input;
                    P_IEPS_MAL.CollectionType = OracleCollectionType.PLSQLAssociativeArray;


                    //LLENAR LOS VALORES DE LOS PARAMETROS
                    List<String> L_ARTICULO_ID = new List<String>();
                    List<String> L_NOMBRE = new List<String>();
                    List<Decimal> L_PRECIO_FARM_REC = new List<Decimal>();
                    List<Decimal> L_CANT_RECIBIDA = new List<Decimal>();
                    List<Decimal> L_CANT_PROX_CADUCAR = new List<Decimal>();
                    List<Decimal> L_CANT_MALESTADO = new List<Decimal>();
                    List<Decimal> L_CANT_REPOSICION = new List<Decimal>();
                    List<Decimal> L_PORC_OFERTA = new List<Decimal>();
                    List<Decimal> L_PORC_DESCTO = new List<Decimal>();
                    List<Decimal> L_PORC_DESCTO_AD1 = new List<Decimal>();
                    List<Decimal> L_PORC_DESCTO_AD2 = new List<Decimal>();
                    List<Decimal> L_PORC_DESCTO_AD3 = new List<Decimal>();
                    List<Decimal> L_PORC_DESCTO_AD4 = new List<Decimal>();
                    List<Decimal> L_IMP_OFERTA_SINIVA = new List<Decimal>();
                    List<Decimal> L_IMP_OFERTA_CONIVA = new List<Decimal>();
                    List<Decimal> L_IMP_DESCTO_SINIVA = new List<Decimal>();
                    List<Decimal> L_IMP_DESCTO_CONIVA = new List<Decimal>();
                    List<Decimal> L_IMPORTE_IVA = new List<Decimal>();
                    List<Decimal> L_IMP_DESCTO_CONIVA_MENOSIVA = new List<Decimal>();
                    List<Decimal> L_IMP_RECEPCION_CONIVA = new List<Decimal>();
                    List<Decimal> L_IMP_RECEPCION_SINIVA = new List<Decimal>();
                    List<Decimal> L_IMP_CAL1_OFERTA_CONIVA = new List<Decimal>();
                    List<Decimal> L_IMP_CAL1_OFERTA_SINIVA = new List<Decimal>();
                    List<Decimal> L_RES_CAL1_DESCTO = new List<Decimal>();
                    List<Decimal> L_RES_CAL2_OFERTA = new List<Decimal>();
                    List<Decimal> L_RES_CAL3_DESCTOAD1 = new List<Decimal>();
                    List<Decimal> L_RES_CAL4_DESCTOAD2 = new List<Decimal>();
                    List<Decimal> L_RES_CAL5_DESCTOAD3 = new List<Decimal>();
                    List<Decimal> L_RES_CAL6_DESCTOAD4 = new List<Decimal>();
                    List<Decimal> L_COSTO_NETO_UNIT_REC = new List<Decimal>();
                    List<Decimal> L_IMPORTE_NETO = new List<Decimal>();
                    List<Decimal> L_DIF_DESCTO_IVA = new List<Decimal>();
                    List<String> L_FLAG_MAL_OFERTADO = new List<String>();
                    List<Decimal> L_DESCUENTO_GENERAL = new List<Decimal>();
                    List<Decimal> L_CANT_FACTURA = new List<Decimal>();
                    List<Decimal> L_CANT_DEV_FALTANTE = new List<Decimal>();
                    List<Decimal> L_CANT_DEV_NO_PEDIDO = new List<Decimal>();
                    List<Decimal> L_CANT_DEV_PRECIO_ELEVADO = new List<Decimal>();
                    List<Decimal> L_CANT_DEV_FILLER1 = new List<Decimal>();
                    List<Decimal> L_CANT_DEV_FILLER2 = new List<Decimal>();
                    List<Decimal> L_PARTIDA = new List<Decimal>();
                    List<String> L_LOTE = new List<String>();
                    List<String> L_CADUCIDAD = new List<String>();
                    List<Decimal> L_CANT_FACTURADA = new List<Decimal>();
                    List<Decimal> L_CANT_SOLICITADA = new List<Decimal>();
                    List<Decimal> L_COSTO = new List<Decimal>();
                    List<Decimal> L_SIN_OFERTA = new List<Decimal>();
                    List<Decimal> L_TOTAL_DESCTO_FACTURA = new List<Decimal>();
                    List<Decimal> L_TOTAL_OFERTA_FACTURA = new List<Decimal>();
                    List<Decimal> L_PRECIO_FACTURA = new List<Decimal>();
                    List<Decimal> L_PRECIO_FARMACIA = new List<Decimal>();
                    List<Decimal> L_IVA_MAL_OFERTADO = new List<Decimal>();
                    List<Decimal> L_PRECIO_MAXIMO = new List<Decimal>();
                    List<Decimal> L_NUEVO_FLEMING = new List<Decimal>();
                    List<Decimal> L_PORC_IVA = new List<Decimal>();
                    List<Decimal> L_MAL_OFERTADO = new List<Decimal>();
                    List<Decimal> L_PRECIO_FACTURA_MAX = new List<Decimal>();
                    List<String> L_CODIGO_PROVEEDOR = new List<String>();
                    List<Decimal> L_PRECIO_VENTA = new List<Decimal>();
                    List<Decimal> L_COSTO_ULT_COMPRA = new List<Decimal>();
                    List<Decimal> L_MARGEN_UTILIDAD = new List<Decimal>();
                    List<Decimal> L_IMP_FACTURA_CONIVA = new List<Decimal>();
                    List<Decimal> L_IMP_FACTURA_SINIVA = new List<Decimal>();
                    List<Decimal> L_PRECIO_FLEMING = new List<Decimal>();
                    List<String>  L_OBSERVACIONES = new List<String>();
                    List<Decimal> L_IMPORTE_IEPS = new List<Decimal>();
                    List<Decimal> L_PORCENTAJE_IEPS = new List<Decimal>();
                    List<Decimal> L_IEPS_MAL = new List<Decimal>();

                    foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row in detalles)
                    {
                        L_ARTICULO_ID.Add(row.ARTICULO_ID);
                        L_NOMBRE.Add(row.NOMBRE);
                        L_PRECIO_FARM_REC.Add((decimal)row.PRECIO_FARM_REC);
                        L_CANT_RECIBIDA.Add((decimal)row.CANT_RECIBIDA);
                        L_CANT_PROX_CADUCAR.Add((decimal)row.CANT_PROX_CADUCAR);
                        L_CANT_MALESTADO.Add((decimal)row.CANT_MALESTADO);
                        L_CANT_REPOSICION.Add((decimal)row.CANT_REPOSICION);
                        L_PORC_OFERTA.Add((decimal)row.PORC_OFERTA);
                        L_PORC_DESCTO.Add((decimal)row.PORC_DESCTO);
                        L_PORC_DESCTO_AD1.Add((decimal)row.PORC_DESCTO_AD1);
                        L_PORC_DESCTO_AD2.Add((decimal)row.PORC_DESCTO_AD2);
                        L_PORC_DESCTO_AD3.Add((decimal)row.PORC_DESCTO_AD3);
                        L_PORC_DESCTO_AD4.Add((decimal)row.PORC_DESCTO_AD4);
                        L_IMP_OFERTA_SINIVA.Add((decimal)row.IMP_OFERTA_SINIVA);
                        L_IMP_OFERTA_CONIVA.Add((decimal)row.IMP_OFERTA_CONIVA);
                        L_IMP_DESCTO_SINIVA.Add((decimal)row.IMP_DESCTO_SINIVA);
                        L_IMP_DESCTO_CONIVA.Add((decimal)row.IMP_DESCTO_CONIVA);
                        L_IMPORTE_IVA.Add((decimal)row.IMPORTE_IVA);
                        L_IMP_DESCTO_CONIVA_MENOSIVA.Add((decimal)row.IMP_DESCTO_CONIVA_MENOSIVA);
                        L_IMP_RECEPCION_CONIVA.Add((decimal)row.IMP_RECEPCION_CONIVA);
                        L_IMP_RECEPCION_SINIVA.Add((decimal)row.IMP_RECEPCION_SINIVA);
                        L_IMP_CAL1_OFERTA_CONIVA.Add((decimal)row.IMP_CAL1_OFERTA_CONIVA);
                        L_IMP_CAL1_OFERTA_SINIVA.Add((decimal)row.IMP_CAL1_OFERTA_SINIVA);
                        L_RES_CAL1_DESCTO.Add((decimal)row.RES_CAL1_DESCTO);
                        L_RES_CAL2_OFERTA.Add((decimal)row.RES_CAL2_OFERTA);
                        L_RES_CAL3_DESCTOAD1.Add((decimal)row.RES_CAL3_DESCTOAD1);
                        L_RES_CAL4_DESCTOAD2.Add((decimal)row.RES_CAL4_DESCTOAD2);
                        L_RES_CAL5_DESCTOAD3.Add((decimal)row.RES_CAL5_DESCTOAD3);
                        L_RES_CAL6_DESCTOAD4.Add((decimal)row.RES_CAL6_DESCTOAD4);
                        L_COSTO_NETO_UNIT_REC.Add((decimal)row.COSTO_NETO_UNIT_REC);
                        L_IMPORTE_NETO.Add((decimal)row.IMPORTE_NETO);
                        L_DIF_DESCTO_IVA.Add((decimal)row.DIF_DESCTO_IVA);
                        L_FLAG_MAL_OFERTADO.Add(row.FLAG_MAL_OFERTADO);
                        L_DESCUENTO_GENERAL.Add((decimal)row.DESCUENTO_GENERAL);
                        L_CANT_FACTURA.Add((decimal)row.CANT_FACTURA);
                        L_CANT_DEV_FALTANTE.Add((decimal)row.CANT_DEV_FALTANTE);
                        L_CANT_DEV_NO_PEDIDO.Add((decimal)row.CANT_DEV_NO_PEDIDO);
                        L_CANT_DEV_PRECIO_ELEVADO.Add((decimal)row.CANT_DEV_PRECIO_ELEVADO);
                        L_CANT_DEV_FILLER1.Add((decimal)row.CANT_DEV_FILLER1);
                        L_CANT_DEV_FILLER2.Add((decimal)row.CANT_DEV_FILLER2);
                        L_PARTIDA.Add((decimal)row.PARTIDA);
                        L_LOTE.Add(row.LOTE);

                        string caducidad = "";
                        if (!row.IsCADUCIDADNull() && row.CADUCIDAD != new DateTime())
                        {
                            caducidad = row.CADUCIDAD.ToString("yyyy-MM-dd HH:mm:ss");
                        }

                        L_CADUCIDAD.Add(caducidad);
                        L_CANT_FACTURADA.Add((decimal)row.CANT_FACTURADA);
                        L_CANT_SOLICITADA.Add((decimal)row.CANT_SOLICITADA);
                        L_COSTO.Add((decimal)row.COSTO);
                        L_SIN_OFERTA.Add((decimal)row.SIN_OFERTA);
                        L_TOTAL_DESCTO_FACTURA.Add((decimal)row.TOTAL_DESCTO_FACTURA);
                        L_TOTAL_OFERTA_FACTURA.Add((decimal)row.TOTAL_OFERTA_FACTURA);
                        L_PRECIO_FACTURA.Add((decimal)row.PRECIO_FACTURA);
                        L_PRECIO_FARMACIA.Add((decimal)row.PRECIO_FARMACIA);
                        L_IVA_MAL_OFERTADO.Add((decimal)row.IVA_MAL_OFERTADO);
                        L_PRECIO_MAXIMO.Add((decimal)row.PRECIO_MAXIMO);
                        L_NUEVO_FLEMING.Add((decimal)row.NUEVO_FLEMING);
                        L_PORC_IVA.Add((decimal)row.PORC_IVA);
                        L_MAL_OFERTADO.Add((decimal)row.MAL_OFERTADO);
                        L_PRECIO_FACTURA_MAX.Add((decimal)row.PRECIO_FACTURA_MAX);
                        L_CODIGO_PROVEEDOR.Add(row.CODIGO_PROVEEDOR);
                        L_PRECIO_VENTA.Add((decimal)row.PRECIO_VENTA);
                        L_COSTO_ULT_COMPRA.Add((decimal)row.COSTO_ULT_COMPRA);
                        L_MARGEN_UTILIDAD.Add((decimal)row.MARGEN_UTILIDAD);
                        L_IMP_FACTURA_CONIVA.Add((decimal)row.IMP_FACTURA_CONIVA);
                        L_IMP_FACTURA_SINIVA.Add((decimal)row.IMP_FACTURA_SINIVA);
                        L_PRECIO_FLEMING.Add((decimal)row.PRECIO_FLEMING);
                        if (row.IsOBSERVACIONESNull())
                        {
                            row.OBSERVACIONES = "";
                        }
                        L_OBSERVACIONES.Add((string)row.OBSERVACIONES);
                        L_IMPORTE_IEPS.Add((decimal)row.IMPORTE_IEPS);
                        L_PORCENTAJE_IEPS.Add((decimal)row.PORCENTAJE_IEPS);
                        L_IEPS_MAL.Add((decimal)row.IEPS_MAL);
                    }

                    P_ARTICULO_ID.Value = L_ARTICULO_ID.ToArray();
                    P_NOMBRE.Value = L_NOMBRE.ToArray();
                    P_PRECIO_FARM_REC.Value = L_PRECIO_FARM_REC.ToArray();
                    P_CANT_RECIBIDA.Value = L_CANT_RECIBIDA.ToArray();
                    P_CANT_PROX_CADUCAR.Value = L_CANT_PROX_CADUCAR.ToArray();
                    P_CANT_MALESTADO.Value = L_CANT_MALESTADO.ToArray();
                    P_CANT_REPOSICION.Value = L_CANT_REPOSICION.ToArray();
                    P_PORC_OFERTA.Value = L_PORC_OFERTA.ToArray();
                    P_PORC_DESCTO.Value = L_PORC_DESCTO.ToArray();
                    P_PORC_DESCTO_AD1.Value = L_PORC_DESCTO_AD1.ToArray();
                    P_PORC_DESCTO_AD2.Value = L_PORC_DESCTO_AD2.ToArray();
                    P_PORC_DESCTO_AD3.Value = L_PORC_DESCTO_AD3.ToArray();
                    P_PORC_DESCTO_AD4.Value = L_PORC_DESCTO_AD4.ToArray();
                    P_IMP_OFERTA_SINIVA.Value = L_IMP_OFERTA_SINIVA.ToArray();
                    P_IMP_OFERTA_CONIVA.Value = L_IMP_OFERTA_CONIVA.ToArray();
                    P_IMP_DESCTO_SINIVA.Value = L_IMP_DESCTO_SINIVA.ToArray();
                    P_IMP_DESCTO_CONIVA.Value = L_IMP_DESCTO_CONIVA.ToArray();
                    P_IMPORTE_IVA.Value = L_IMPORTE_IVA.ToArray();
                    P_IMP_DESCTO_CONIVA_MENOSIVA.Value = L_IMP_DESCTO_CONIVA_MENOSIVA.ToArray();
                    P_IMP_RECEPCION_CONIVA.Value = L_IMP_RECEPCION_CONIVA.ToArray();
                    P_IMP_RECEPCION_SINIVA.Value = L_IMP_RECEPCION_SINIVA.ToArray();
                    P_IMP_CAL1_OFERTA_CONIVA.Value = L_IMP_CAL1_OFERTA_CONIVA.ToArray();
                    P_IMP_CAL1_OFERTA_SINIVA.Value = L_IMP_CAL1_OFERTA_SINIVA.ToArray();
                    P_RES_CAL1_DESCTO.Value = L_RES_CAL1_DESCTO.ToArray();
                    P_RES_CAL2_OFERTA.Value = L_RES_CAL2_OFERTA.ToArray();
                    P_RES_CAL3_DESCTOAD1.Value = L_RES_CAL3_DESCTOAD1.ToArray();
                    P_RES_CAL4_DESCTOAD2.Value = L_RES_CAL4_DESCTOAD2.ToArray();
                    P_RES_CAL5_DESCTOAD3.Value = L_RES_CAL5_DESCTOAD3.ToArray();
                    P_RES_CAL6_DESCTOAD4.Value = L_RES_CAL6_DESCTOAD4.ToArray();
                    P_COSTO_NETO_UNIT_REC.Value = L_COSTO_NETO_UNIT_REC.ToArray();
                    P_IMPORTE_NETO.Value = L_IMPORTE_NETO.ToArray();
                    P_DIF_DESCTO_IVA.Value = L_DIF_DESCTO_IVA.ToArray();
                    P_FLAG_MAL_OFERTADO.Value = L_FLAG_MAL_OFERTADO.ToArray();
                    P_DESCUENTO_GENERAL.Value = L_DESCUENTO_GENERAL.ToArray();
                    P_CANT_FACTURA.Value = L_CANT_FACTURA.ToArray();
                    P_CANT_DEV_FALTANTE.Value = L_CANT_DEV_FALTANTE.ToArray();
                    P_CANT_DEV_NO_PEDIDO.Value = L_CANT_DEV_NO_PEDIDO.ToArray();
                    P_CANT_DEV_PRECIO_ELEVADO.Value = L_CANT_DEV_PRECIO_ELEVADO.ToArray();
                    P_CANT_DEV_FILLER1.Value = L_CANT_DEV_FILLER1.ToArray();
                    P_CANT_DEV_FILLER2.Value = L_CANT_DEV_FILLER2.ToArray();
                    P_PARTIDA.Value = L_PARTIDA.ToArray();
                    P_LOTE.Value = L_LOTE.ToArray();
                    P_CADUCIDAD.Value = L_CADUCIDAD.ToArray();
                    P_CANT_FACTURADA.Value = L_CANT_FACTURADA.ToArray();
                    P_CANT_SOLICITADA.Value = L_CANT_SOLICITADA.ToArray();
                    P_COSTO.Value = L_COSTO.ToArray();
                    P_SIN_OFERTA.Value = L_SIN_OFERTA.ToArray();
                    P_TOTAL_DESCTO_FACTURA.Value = L_TOTAL_DESCTO_FACTURA.ToArray();
                    P_TOTAL_OFERTA_FACTURA.Value = L_TOTAL_OFERTA_FACTURA.ToArray();
                    P_PRECIO_FACTURA.Value = L_PRECIO_FACTURA.ToArray();
                    P_PRECIO_FARMACIA.Value = L_PRECIO_FARMACIA.ToArray();
                    P_IVA_MAL_OFERTADO.Value = L_IVA_MAL_OFERTADO.ToArray();
                    P_PRECIO_MAXIMO.Value = L_PRECIO_MAXIMO.ToArray();
                    P_NUEVO_FLEMING.Value = L_NUEVO_FLEMING.ToArray();
                    P_PORC_IVA.Value = L_PORC_IVA.ToArray();
                    P_MAL_OFERTADO.Value = L_MAL_OFERTADO.ToArray();
                    P_PRECIO_FACTURA_MAX.Value = L_PRECIO_FACTURA_MAX.ToArray();
                    P_CODIGO_PROVEEDOR.Value = L_CODIGO_PROVEEDOR.ToArray();
                    P_PRECIO_VENTA.Value = L_PRECIO_VENTA.ToArray();
                    P_COSTO_ULT_COMPRA.Value = L_COSTO_ULT_COMPRA.ToArray();
                    P_MARGEN_UTILIDAD.Value = L_MARGEN_UTILIDAD.ToArray();
                    P_IMP_FACTURA_CONIVA.Value = L_IMP_FACTURA_CONIVA.ToArray();
                    P_IMP_FACTURA_SINIVA.Value = L_IMP_FACTURA_SINIVA.ToArray();
                    P_PRECIO_FLEMING.Value = L_PRECIO_FLEMING.ToArray();
                    P_OBSERVACIONES.Value = L_OBSERVACIONES.ToArray();
                    P_IMPORTE_IEPS.Value = L_IMPORTE_IEPS.ToArray();
                    P_PORCENTAJE_IEPS.Value = L_PORCENTAJE_IEPS.ToArray();
                    P_IEPS_MAL.Value = L_IEPS_MAL.ToArray();

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("OutParam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }

            return true;
        }

        public static bool ActualizaCodigo(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow detalle, string clave)
        {
            object id;
            string sentencia = "UPDATE orden_compra_det SET articulo_id = '" + detalle.ARTICULO_ID + "' , NOMBRE = '" + detalle.NOMBRE + "' WHERE articulo_id = '" + clave + "'";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    try
                    {
                        cmd.Connection.Open();

                        id = cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static bool ActualizaCodigo(string ArticuloID, string Nombre, string Clave)
        {
            object id;
            string sentencia = "UPDATE compras_det SET articulo_id = '" + ArticuloID + "', NOMBRE = '" + Nombre + "' WHERE articulo_id = '" + Clave + "'";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    try
                    {
                        cmd.Connection.Open();

                        id = cmd.ExecuteNonQuery();
                        
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }


        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_LOTERow CompraLotePorId(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow compra)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet dsOrdenesCompra = new SIFModelo.OrdenCompra.OrdenCompraDataSet();

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.COMPRAS_LOTETableAdapter ta = new SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.COMPRAS_LOTETableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;
                ta.FillByFOLIO(dsOrdenesCompra.COMPRAS_LOTE, compra.FOLIO_COMPRA);
            }

            if (dsOrdenesCompra.COMPRAS_LOTE.Count > 0)
            {
                return dsOrdenesCompra.COMPRAS_LOTE[0];
            }

            return null;
        }

        public static bool GuardaLoteCaducidad(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_LOTERow compraLote, SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTEDataTable detalles)
        {

            string sentencia = "PKG_COMPRAS.SP_INS_COMPRA_LOTE";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("p_FOLIO_COMPRA", compraLote.FOLIO_COMPRA);
                    cmd.Parameters.Add("p_FECHA", compraLote.FECHA);
                    cmd.Parameters.Add("p_ACTIVO", compraLote.ACTIVO);
                    cmd.Parameters.Add("p_USUARIO_ID", compraLote.USUARIO_ID);
                    cmd.Parameters.Add("p_OBSERVACIONES", compraLote.OBSERVACIONES);
                    cmd.Parameters.Add("p_RECEPCIONISTA", compraLote.RECEPCIONISTA);


                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("OutParam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }
                }
            }
            return true;
        }



        public static bool ActualziarRecepcionPrecios(string RDM)
        {

            string sentencia = "SP_AFECTA_RECEPCION";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("V_FOLIO_COMPRA_B", RDM);
                    /*
                                        //PARAMETROS DE SALIDA
                                        OracleParameter outparam = new OracleParameter("v_out", OracleDbType.Varchar2);
                                        outparam.Direction = System.Data.ParameterDirection.Output;

                                        //AGREGAR LOS PARAMETROS
                                        cmd.Parameters.Add(outparam);*/
                    OracleParameter outparam = new OracleParameter("v_out", OracleDbType.Varchar2);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    outparam.Size = 1500;
                    cmd.Parameters.Add(outparam);


                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        //MessageBoxEx.Show("Se han asignado los precios correctamente");
                        //MessageBoxEx.Show(" Precios : " + outparam.Value.ToString());
                        if (outparam.Value.ToString().Contains("1:OK"))
                        {
                            //MessageBoxEx.Show("Se Proceso la orden de compra", "informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                            return true;

                        }
                        else
                        {
                           MessageBox.Show(outparam.Value.ToString(), "informacion", System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Stop);
                            return false;
                        }
                        

                    }
                    catch(Exception e)
                    {
                       MessageBox.Show(" Error : "+e.ToString());
                        //MessageBoxEx.Show(" Error : " + outparam.Value.ToString());
                        return false;

                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }
                }
            }
           // return true;
        }

        public static bool GuardaLoteCaducidadDetalles(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_LOTERow compraLote, SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTEDataTable detalles)
        {

            string sentencia = "PKG_COMPRAS.SP_SAVE_COMPRA_LOTE_DET";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    OracleParameter P_PARTIDA = cmd.Parameters.Add("P_PARTIDA", OracleDbType.Decimal);
                    P_PARTIDA.Direction = ParameterDirection.Input;
                    P_PARTIDA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    cmd.Parameters.Add("P_FOLIO_COMPRA", compraLote.FOLIO_COMPRA);

                    OracleParameter P_PROVEEDOR_ID = cmd.Parameters.Add("P_PROVEEDOR_ID", OracleDbType.Decimal);
                    P_PROVEEDOR_ID.Direction = ParameterDirection.Input;
                    P_PROVEEDOR_ID.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_TIPO = cmd.Parameters.Add("P_TIPO", OracleDbType.Varchar2);
                    P_TIPO.Direction = ParameterDirection.Input;
                    P_TIPO.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_ARTICULO_ID = cmd.Parameters.Add("p_ARTICULO_ID", OracleDbType.Varchar2);
                    P_ARTICULO_ID.Direction = ParameterDirection.Input;
                    P_ARTICULO_ID.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CODIGO_PROVEEDOR = cmd.Parameters.Add("P_CODIGO_PROVEEDOR", OracleDbType.Varchar2);
                    P_CODIGO_PROVEEDOR.Direction = ParameterDirection.Input;
                    P_CODIGO_PROVEEDOR.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_NOMBRE = cmd.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2);
                    P_NOMBRE.Direction = ParameterDirection.Input;
                    P_NOMBRE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_RECIBIDA = cmd.Parameters.Add("P_CANT_RECIBIDA", OracleDbType.Decimal);
                    P_CANT_RECIBIDA.Direction = ParameterDirection.Input;
                    P_CANT_RECIBIDA.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CANT_LOTE = cmd.Parameters.Add("P_CANT_LOTE", OracleDbType.Decimal);
                    P_CANT_LOTE.Direction = ParameterDirection.Input;
                    P_CANT_LOTE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_LOTE = cmd.Parameters.Add("P_LOTE", OracleDbType.Varchar2);
                    P_LOTE.Direction = ParameterDirection.Input;
                    P_LOTE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_CADUCIDAD = cmd.Parameters.Add("P_CADUCIDAD", OracleDbType.Varchar2);
                    P_CADUCIDAD.Direction = ParameterDirection.Input;
                    P_CADUCIDAD.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter P_OBSERVACIONES = cmd.Parameters.Add("P_OBSERVACIONES", OracleDbType.Varchar2);
                    P_OBSERVACIONES.Direction = ParameterDirection.Input;
                    P_OBSERVACIONES.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("OutParam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    List<Int32> L_PARTIDA = new List<Int32>();
                    List<Int32> L_PROVEEDOR_ID = new List<Int32>();
                    List<String> L_TIPO = new List<String>();
                    List<String> L_ARTICULO_ID = new List<String>();
                    List<String> L_CODIGO_PROVEEDOR = new List<String>();
                    List<String> L_NOMBRE = new List<String>();
                    List<Int32> L_CANT_RECIBIDA = new List<Int32>();
                    List<Int32> L_CANT_LOTE = new List<Int32>();
                    List<String> L_LOTE = new List<String>();
                    List<String> L_CADUCIDAD = new List<String>();
                    List<String> L_OBSERVACIONES = new List<String>();

                    foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTERow detalle in detalles)
                    {
                        L_PARTIDA.Add(detalle.PARTIDA);
                        L_PROVEEDOR_ID.Add(detalle.PROVEEDOR_ID);
                        L_TIPO.Add(detalle.TIPO);
                        L_ARTICULO_ID.Add(detalle.ARTICULO_ID);

                        if (string.IsNullOrEmpty(detalle.CODIGO_PROVEEDOR))
                        {
                            detalle.CODIGO_PROVEEDOR = " ";
                        }

                        L_CODIGO_PROVEEDOR.Add(detalle.CODIGO_PROVEEDOR);
                        L_NOMBRE.Add(detalle.NOMBRE);
                        L_CANT_RECIBIDA.Add(detalle.CANT_RECIBIDA);
                        L_CANT_LOTE.Add(detalle.CANT_LOTE);

                        if (detalle.IsLOTENull())
                        {
                            detalle.LOTE = "";
                        }
                        L_LOTE.Add(detalle.LOTE);

                        if (detalle.IsCADUCIDADNull())
                        {
                            detalle.CADUCIDAD = new DateTime();
                        }
                         
                        L_CADUCIDAD.Add(detalle.CADUCIDAD.ToString("yyyy-MM-dd"));


                        if (detalle.IsOBSERVACIONESNull())
                        {
                            detalle.OBSERVACIONES = "";
                        }
                        L_OBSERVACIONES.Add(detalle.OBSERVACIONES);
                    }

                    P_PARTIDA.Value = L_PARTIDA.ToArray();
                    P_PROVEEDOR_ID.Value = L_PROVEEDOR_ID.ToArray();
                    P_TIPO.Value = L_TIPO.ToArray();
                    P_ARTICULO_ID.Value = L_ARTICULO_ID.ToArray();
                    P_CODIGO_PROVEEDOR.Value = L_CODIGO_PROVEEDOR.ToArray();
                    P_NOMBRE.Value = L_NOMBRE.ToArray();
                    P_CANT_RECIBIDA.Value = L_CANT_RECIBIDA.ToArray();
                    P_CANT_LOTE.Value = L_CANT_LOTE.ToArray();
                    P_LOTE.Value = L_LOTE.ToArray();
                    P_CADUCIDAD.Value = L_CADUCIDAD.ToArray();
                    P_OBSERVACIONES.Value = L_OBSERVACIONES.ToArray();

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }
                }
            }
            return true;
        }

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTEDataTable CompraDetalleLotePorId(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_LOTERow compraLote)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet dsOrdenesCompra = new SIFModelo.OrdenCompra.OrdenCompraDataSet();

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.COMPRAS_DET_LOTETableAdapter ta = new SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.COMPRAS_DET_LOTETableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;
                ta.FillByFOLIO(dsOrdenesCompra.COMPRAS_DET_LOTE, compraLote.FOLIO_COMPRA);
            }

            dsOrdenesCompra.COMPRAS_DET_LOTE.CODIGO_PROVEEDORColumn.DefaultValue = "";
            dsOrdenesCompra.COMPRAS_DET_LOTE.OBSERVACIONESColumn.DefaultValue = "";
            dsOrdenesCompra.COMPRAS_DET_LOTE.CODIGO_PROVEEDORColumn.DefaultValue = "";
            dsOrdenesCompra.COMPRAS_DET_LOTE.TIPOColumn.DefaultValue = "";

            return dsOrdenesCompra.COMPRAS_DET_LOTE;
        }




        public static string spCierraCaducidades(string RDM)
        {

            string sentencia = "Pkg_Caducidades_V3.sp_cierre_caducidades";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("pe_documento", RDM);
                    /*
                                        //PARAMETROS DE SALIDA
                                        OracleParameter outparam = new OracleParameter("v_out", OracleDbType.Varchar2);
                                        outparam.Direction = System.Data.ParameterDirection.Output;

                                        //AGREGAR LOS PARAMETROS
                                        cmd.Parameters.Add(outparam);*/
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Varchar2);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    outparam.Size = 1500;

                    cmd.Parameters.Add(outparam);


                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                       //MessageBox.Show("Se han asignado los precios correctamente");
                        //MessageBoxEx.Show(" Precios : " + outparam.Value.ToString());
                        return outparam.Value.ToString() ;

                    }
                    catch (Exception e)
                    {
                       MessageBox.Show(" Error : " + e.ToString());
                        //MessageBoxEx.Show(" Error : " + outparam.Value.ToString());
                        return e.ToString();

                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                        //OracleConnection.ClearPool(cmd.Connection);
                    }
                }
            }
            // return true;
        }

        public static string spLiberaOrdenCompra(string RDM)
        {

            string sentencia = "Pkg_Caducidades_V3.sp_libera_orden_compra";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("pe_documento", RDM);
                    /*
                                        //PARAMETROS DE SALIDA
                                        OracleParameter outparam = new OracleParameter("v_out", OracleDbType.Varchar2);
                                        outparam.Direction = System.Data.ParameterDirection.Output;

                                        //AGREGAR LOS PARAMETROS
                                        cmd.Parameters.Add(outparam);*/
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Varchar2);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    outparam.Size = 1500;

                    cmd.Parameters.Add(outparam);


                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        //MessageBoxEx.Show("Se han asignado los precios correctamente");
                        //MessageBoxEx.Show(" Precios : " + outparam.Value.ToString());
                        return outparam.Value.ToString();

                    }
                    catch (Exception e)
                    {
                       MessageBox.Show(" Error : " + e.ToString());
                        //MessageBoxEx.Show(" Error : " + outparam.Value.ToString());
                        return e.ToString();

                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                        //OracleConnection.ClearPool(cmd.Connection);
                    }
                }
            }
            // return true;
        }


        public static string spCreaTraspasosVirtuales(string RDM,string idsuc)
        {

            string sentencia = "SP_GENERA_TRASPASO_VIRTUAL_OC";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("V_OC", RDM);
                    cmd.Parameters.Add("V_SUCURSAL_DESTINO",idsuc );
                    /*
                                        //PARAMETROS DE SALIDA
                                        OracleParameter outparam = new OracleParameter("v_out", OracleDbType.Varchar2);
                                        outparam.Direction = System.Data.ParameterDirection.Output;

                                        //AGREGAR LOS PARAMETROS
                                        cmd.Parameters.Add(outparam);*/
                    OracleParameter outparam = new OracleParameter("V_RESPUESTA", OracleDbType.Varchar2);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    outparam.Size = 1500;

                    cmd.Parameters.Add(outparam);


                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        //MessageBoxEx.Show("Se han asignado los precios correctamente");
                        //MessageBoxEx.Show(" Precios : " + outparam.Value.ToString());
                        return outparam.Value.ToString();

                    }
                    catch (Exception e)
                    {
                       MessageBox.Show(" Error : " + e.ToString());
                        //MessageBoxEx.Show(" Error : " + outparam.Value.ToString());
                        return e.ToString();

                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                        //OracleConnection.ClearPool(cmd.Connection);
                    }
                }
            }
            // return true;
        }



        public static List<SIFModelo.OrdenCompra.ModoPago> ObtieneDatosPago()
        {
            string sentencia = "SELECT * FROM cat_modo_pago_oc where estado='S'";//;
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.Parameters.Add("sucursalID", sucursal.SucursalesID);
                    //cmd.Parameters.Add("codigo_ean", articulo.ARTICULO_ID);
                    //cmd.BindByName = true;
                   List<SIFModelo.OrdenCompra.ModoPago> DatosPagoT = new List<SIFModelo.OrdenCompra.ModoPago>();
                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        

                        if (oreader.HasRows)
                        {
                            // SIFModelo.Catalogo.ArticuloMayorista();
                            while (oreader.Read())
                            {
                                SIFModelo.OrdenCompra.ModoPago DatosPago = new SIFModelo.OrdenCompra.ModoPago();
                                DatosPago.modo_pago_id = int.Parse(oreader["modo_pago_id"].ToString());
                                DatosPago.nombre = oreader["nombre"].ToString();
                                DatosPago.estado = oreader["estado"].ToString();
                                DatosPagoT.Add(DatosPago);

                                
                            }
                            
                        }
                        return DatosPagoT;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                        //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }

            return null;
        }

        public static string UpdOCModoPago(string oc, string mp)
        {

            string sentencia = "SP_UPD_MODOPAGO_OC";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("OC", oc);
                    cmd.Parameters.Add("MP", mp);
                    OracleParameter outparam = new OracleParameter("V_RESPUESTA", OracleDbType.Varchar2);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    outparam.Size = 1500;

                    cmd.Parameters.Add(outparam);


                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        //MessageBoxEx.Show("Se han asignado los precios correctamente");
                        //MessageBoxEx.Show(" Precios : " + outparam.Value.ToString());
                        return outparam.Value.ToString();

                    }
                    catch (Exception e)
                    {
                       MessageBox.Show(" Error : " + e.ToString());
                        //MessageBoxEx.Show(" Error : " + outparam.Value.ToString());
                        return e.ToString();

                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                        //OracleConnection.ClearPool(cmd.Connection);
                    }
                }
            }
            // return true;
        }

        public static void CompararPrecioUAMPH(List<SIFModelo.OrdenCompra.ArticuloPrecio> articulos, int usuarioId, string FOLIO_COMPRA)
        {
            string[] arrArt = articulos.Select(a => a.ArticuloId).ToArray();
            decimal[] arrPre = articulos.Select(a => a.Precio).ToArray();

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand("SP_COMPARAR_PRECIO_UAMPH", cnx))
                {
                    cnx.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 1) Artículos(VARCHAR2[])
                    cmd.Parameters.Add(new OracleParameter("p_articulos", OracleDbType.Array)
                    {
                        Direction = ParameterDirection.Input,
                        UdtTypeName = "FARMACIA.T_VARCHAR_TAB",
                        Value = arrArt
                    });

                    // 2) Precios   (NUMBER[])
                    cmd.Parameters.Add(new OracleParameter("p_precios", OracleDbType.Array)
                    {
                        Direction = ParameterDirection.Input,
                        UdtTypeName = "FARMACIA.T_NUMERIC_TAB",
                        Value = arrPre
                    });

                    OracleParameter pUser = new OracleParameter("P_USUARIO_ID", OracleDbType.Int16);
                    pUser.Direction = ParameterDirection.Input;
                    pUser.Value = usuarioId;
                    cmd.Parameters.Add(pUser);

                    cmd.Parameters.Add("p_folio_compra", OracleDbType.Varchar2).Value = FOLIO_COMPRA;


                    cmd.Parameters.Add(new OracleParameter("p_resultado", OracleDbType.Clob)
                    {
                        Direction = ParameterDirection.Output
                    });

                    cmd.ExecuteNonQuery();

                    // Obtener el CLOB devuelto
                    var lob = (OracleClob)cmd.Parameters["p_resultado"].Value;
                    string resultado = !lob.IsNull ? lob.Value : string.Empty;

                    // Mostrar advertencias si hay líneas
                    if (!string.IsNullOrEmpty(resultado))
                    {
                       MessageBox.Show(resultado,
                                          "Validaciones de UAMPH",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public static string InsertarAuditoria(string userId, string fecha, string num_orden, string Total_piezas, string Ruta_archivo)
        {
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                string Query = "INSERT INTO TBL_IMPORTA_CSV_OC(NUM_ORDEN, FECHA_REGISTRO, USUARIO, TOTAL_PIEZAS, RUTA_ARCHIVO) VALUES(:NUM_ORDEN, TO_DATE(:Fecha_REGISTRO, 'DD/MM/YYYY HH24:MI:SS'), :UserID, :TOTAL_PIEZAS, :RUTA_ARCHIVO)";
                using (OracleCommand command = new OracleCommand(Query, cnx))
                {
                    command.Parameters.Add(new OracleParameter("NUM_ORDEN", num_orden));
                    command.Parameters.Add(new OracleParameter("FECHA_REGISTRO", fecha));
                    command.Parameters.Add(new OracleParameter("UserID", userId));
                    command.Parameters.Add(new OracleParameter("Total_piezas", Total_piezas));
                    command.Parameters.Add(new OracleParameter("Ruta_archivo", Ruta_archivo));

                    
                    cnx.Open();
                    command.ExecuteNonQuery();

                    return "OK";
                }
            }
        }

        public static void ActualizarComprasDetMasivo(List<string> articulos, List<decimal> cantidades, List<decimal> precios, string FOLIO_COMPRA, string numFactura)
        {
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand("SP_UPDATE_COMPRAS_DET", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // NUM_COMPRA
                    cmd.Parameters.Add("P_NUM_COMPRA", OracleDbType.Varchar2).Value = FOLIO_COMPRA;

                    // ARTICULOS -> T_VARCHAR_TAB
                    OracleParameter pArticulos = new OracleParameter();
                    pArticulos.ParameterName = "P_ARTICULOS";
                    pArticulos.OracleDbType = OracleDbType.Array;
                    pArticulos.UdtTypeName = "T_VARCHAR_TAB";
                    pArticulos.Value = articulos.ToArray();
                    cmd.Parameters.Add(pArticulos);

                    // CANTIDADES -> T_NUMERIC_TAB
                    OracleParameter pCantidades = new OracleParameter();
                    pCantidades.ParameterName = "P_CANTIDADES";
                    pCantidades.OracleDbType = OracleDbType.Array;
                    pCantidades.UdtTypeName = "T_NUMERIC_TAB";
                    pCantidades.Value = cantidades.ToArray();
                    cmd.Parameters.Add(pCantidades);

                    // PRECIOS -> T_NUMERIC_TAB
                    OracleParameter pPrecios = new OracleParameter();
                    pPrecios.ParameterName = "P_PRECIOS";
                    pPrecios.OracleDbType = OracleDbType.Array;
                    pPrecios.UdtTypeName = "T_NUMERIC_TAB";
                    pPrecios.Value = precios.ToArray();
                    cmd.Parameters.Add(pPrecios);

                    cmd.Parameters.Add("P_NUM_FACTURA", OracleDbType.Varchar2).Value = numFactura;


                    cnx.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static string ValidarComprasDet(string numCompra, List<string> articulos)
        {
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand("SP_VALIDAR_COMPRAS_DET", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Número de compra
                    cmd.Parameters.Add("P_NUM_COMPRA", OracleDbType.Varchar2).Value = numCompra;

                    // Lista de artículos
                    OracleParameter pArticulos = new OracleParameter();
                    pArticulos.ParameterName = "P_ARTICULOS";
                    pArticulos.OracleDbType = OracleDbType.Array;
                    pArticulos.UdtTypeName = "T_VARCHAR_TAB";
                    pArticulos.Value = articulos.ToArray();
                    cmd.Parameters.Add(pArticulos);

                    // Resultado (mensaje)
                    OracleParameter pResultado = new OracleParameter();
                    pResultado.ParameterName = "P_RESULTADO";
                    pResultado.OracleDbType = OracleDbType.Varchar2;
                    pResultado.Size = 4000;
                    pResultado.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(pResultado);

                    cnx.Open();
                    cmd.ExecuteNonQuery();

                    return pResultado.Value.ToString();
                }
            }
        }

        public static bool ExisteOrdenEnAuditoria(string numOrden)
        {
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                string query = "SELECT COUNT(*) FROM TBL_IMPORTA_CSV_OC WHERE NUM_ORDEN = :NUM_ORDEN";
                using (OracleCommand cmd = new OracleCommand(query, cnx))
                {
                    cmd.Parameters.Add(new OracleParameter("NUM_ORDEN", numOrden));
                    cnx.Open();

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

    }
}
