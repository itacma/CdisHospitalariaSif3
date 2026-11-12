using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using Oracle.DataAccess.Types;

namespace SIFDatos.OrdenCompra
{
    public class OrdenCompraRecibe
    {

        public static DataTable SetRecepcionCompra(SIFModelo.Sucursal sucursal, SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow modelo)
        {
            DataTable dt = new DataTable("DATOS");
            string sentencia = "PKG_RECEPCION_COMPRAS.SP_SET_RECEPCION_COMPRA";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("p_folio", modelo.FOLIO_COMPRA);
                    cmd.Parameters.Add("p_proveedorid", modelo.PROVEEDOR_ID);
                    cmd.Parameters.Add("p_sucursalid", sucursal.SucursalesID );
                    cmd.Parameters.Add("p_articulo", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("p_partida", modelo.PARTIDA);
                    cmd.Parameters.Add("p_cant", modelo.CANT_FACTURADA);
                    cmd.Parameters.Add("p_pmp", modelo.PRECIO_MAXIMO);
                    cmd.Parameters.Add("p_pfarm", modelo.PRECIO_FARMACIA);
                    cmd.Parameters.Add("p_poferta", modelo.PORC_OFERTA);
                    cmd.Parameters.Add("p_descto", modelo.PORC_DESCTO);
                    cmd.Parameters.Add("p_desctoad1", modelo.PORC_DESCTO_AD1);
                    cmd.Parameters.Add("p_desctoad2", modelo.PORC_DESCTO_AD2);
                    cmd.Parameters.Add("p_desctoad3", modelo.PORC_DESCTO_AD3);
                    cmd.Parameters.Add("p_iva", modelo.PORC_IVA);
                    cmd.Parameters.Add("p_iesp", modelo.PORCENTAJE_IEPS);
                    
                    cmd.Parameters.Add("p_cantdev", modelo.CANT_DEV_FALTANTE + modelo.CANT_MALESTADO + modelo.CANT_PROX_CADUCAR + modelo.CANT_DEV_NO_PEDIDO+modelo.CANT_DEV_PRECIO_ELEVADO);//LGS 20/08/2015 PARA QUE CONSIDERE EL RESTO DE CONCEPTOS A DEVOLVER (NO PEDIDO, PRECIO ELEVADO)

                    //PARAMETROS DE SALIDA
                    OracleParameter hdr = new OracleParameter("HDR", OracleDbType.RefCursor);
                    hdr.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(hdr);

                    object id = 0;
                    try
                    {
                       // cmd.Connection.Open();
                       //var reader =  cmd.ExecuteReader();
                       // OracleRefCursor rHDR = hdr.Value as OracleRefCursor;

                        using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                        {
                            td.Fill(dt);

                            if (dt.Rows.Count >= 1)
                            { 
                                DataRow rw = dt.Rows[0];
                                modelo.COSTO_NETO_UNIT_REC = System.Convert.ToDouble(rw["COSTO_NETO_UNITARIO"]);
                                modelo.COSTO = System.Convert.ToDouble(rw["COSTO_NETO_UNITARIO"]);

                                modelo.RES_CAL3_DESCTOAD1 = System.Convert.ToDouble(rw["imp_dev_ad1"]);  // -System.Convert.ToDouble(rw["imp_descto_ad1"]);
                                modelo.RES_CAL4_DESCTOAD2 = System.Convert.ToDouble(rw["imp_dev_ad2"]); //System.Convert.ToDouble(rw["imp_descto_ad2"]); //
                                modelo.RES_CAL5_DESCTOAD3 = System.Convert.ToDouble(rw["imp_dev_ad3"]); // System.Convert.ToDouble(rw["imp_descto_ad3"]); // ;
                                modelo.IMPORTE_IVA = System.Convert.ToDouble(rw["IMP_IVA"]) - System.Convert.ToDouble(rw["imp_dev_iva"]);
                                modelo.IMPORTE_IEPS = System.Convert.ToDouble(rw["IMP_IESP"]) - System.Convert.ToDouble(rw["imp_dev_iesp"]);
                                modelo.TOTAL_DESCTO_FACTURA = System.Convert.ToDouble(rw["IMP_OFTA"]);

                                modelo.DIF_DESCTO_IVA = System.Convert.ToDouble(rw["IMP_DEV_IVA"]) + System.Convert.ToDouble(rw["IMP_DEV_IVA_AD1"]) + System.Convert.ToDouble(rw["IMP_DEV_IVA_AD2"]) + System.Convert.ToDouble(rw["IMP_DEV_IVA_AD3"]);
                              //  modelo.DIF_DESCTO_IESP = System.Convert.ToDouble(rw["IMP_DEV_IESP"]);
                                modelo.IMP_DESCTO_SINIVA = System.Convert.ToDouble(rw["imp_dev_ad1"]);

                              //  modelo.COSTO_NETO_UNIT_REC = System.Convert.ToDouble(rw["IMP_NETO_AD3"]) / modelo.CANT_FACTURA;
                                //modelo.RES_CAL3_DESCTOAD1 = System.Convert.ToDouble(rw["IMP_DESC_AD1"]);
                                //modelo.im
                                //modelo.COSTO = 
                                modelo.IMPORTE_NETO = modelo.COSTO_NETO_UNIT_REC * modelo.CANT_RECIBIDA;
                            }
                        }

                        
                    }
                    catch (Exception)
                    {
                        return dt;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            return dt;
        }


        public static bool RecepcionCompraTot(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow modelo)
        {
            string sentencia = "PKG_RECEPCION_COMPRAS.SP_SET_RECEPCION_COMPRA_TOT";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("p_folio", modelo.FOLIO_COMPRA);

                    //PARAMETROS DE SALIDA
                    OracleParameter outp =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                    //AGREGAR LOS PARAMETROS
                   // cmd.Parameters.Add(outp);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            return true;
        }

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow   GetRecepcionCompraTot(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow modelo)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow det = new SIFModelo.OrdenCompra.OrdenCompraDataSet().COMPRAS.NewCOMPRASRow();
            string sentencia = "PKG_RECEPCION_COMPRAS.SP_GET_RECEPCION_COMPRA_TOT";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("p_folio", modelo.FOLIO_COMPRA);

                    //PARAMETROS DE SALIDA
                    OracleParameter hdFactura = new OracleParameter("Factura", OracleDbType.RefCursor);
                    hdFactura.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(hdFactura);

                    OracleParameter hdRecepcion = new OracleParameter("Recepcion", OracleDbType.RefCursor);
                    hdRecepcion.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(hdRecepcion);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        OracleDataAdapter da = new OracleDataAdapter();
                        DataTable dt = new DataTable("factura");
                        OracleRefCursor rcf = (OracleRefCursor)hdFactura.Value;
                        da.Fill(dt, rcf);
                        
                        modelo.TOT_FACT_RECIBIDO = System.Convert.ToDecimal(dt.Rows[4][5]); // System.Convert.ToDecimal(dt.Rows[0][5]) + System.Convert.ToDecimal(dt.Rows[1][5]);
                        modelo.DESCUENTO_FACTURA = System.Convert.ToDecimal(dt.Rows[4][4]); // System.Convert.ToDecimal(dt.Rows[0][4]) + System.Convert.ToDecimal(dt.Rows[1][4]);
                        
                        decimal descuentoIEPS =  System.Convert.ToDecimal(dt.Rows[2][4]);
                        decimal descuentoIVA = System.Convert.ToDecimal(dt.Rows[3][4]);

                        modelo.DESCUENTO_FACTURA -= (descuentoIEPS + descuentoIVA);

                        modelo.IEPS_FACTURA = System.Convert.ToDecimal(dt.Rows[2][5]); 
                        modelo.IVA_FACTURA = System.Convert.ToDecimal(dt.Rows[3][5]);
                        modelo.TOT_FACTURA =  System.Convert.ToDecimal(dt.Rows[0][2]) + System.Convert.ToDecimal(dt.Rows[1][2]);
                        //modelo.TOTAL

                        OracleDataAdapter dar = new OracleDataAdapter();
                        DataTable dtr = new DataTable("recepcion");
                        OracleRefCursor drc = (OracleRefCursor)hdRecepcion.Value;
                        dar.Fill(dtr, drc);

                        modelo.TOT_IMPORTE_REC = System.Convert.ToDecimal(dtr.Rows[0][5]) + System.Convert.ToDecimal(dtr.Rows[1][5]);
                        modelo.TOT_DESCTO_REC = System.Convert.ToDecimal(dtr.Rows[0][4]) + System.Convert.ToDecimal(dtr.Rows[1][4]);
                        modelo.TOT_IEPS_REC = System.Convert.ToDecimal(dtr.Rows[2][5]);
                        decimal iepsDEV = System.Convert.ToDecimal(dtr.Rows[2][3]);
                        modelo.TOTAL_IEPS_DESCTO_REC = System.Convert.ToDecimal(dtr.Rows[2][4]) + iepsDEV;
                        modelo.TOT_IVA_REC = System.Convert.ToDecimal(dtr.Rows[3][5]);
                        modelo.TOTAL_RECIBIDO = System.Convert.ToDecimal(dtr.Rows[0][3]) + System.Convert.ToDecimal(dtr.Rows[1][3]);
                        modelo.TOTAL_NETO_RECIBIDO = System.Convert.ToDecimal(dtr.Rows[1][5]);
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                }
            }

            return modelo;
        }
    }
}
