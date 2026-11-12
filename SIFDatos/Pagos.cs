using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace SIFDatos
{
    public class Pagos
    {
        public static bool Inserta(SIFModelo.Pagos modelo)
        {
            string sentencia = "sp_ins_pagos1";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("cliente_id", modelo.ClienteID);
                    cmd.Parameters.Add("num_pago", modelo.NumeroPago);
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("fecha", modelo.Fecha);
                    cmd.Parameters.Add("moneda_id", modelo.MonedaID);
                    cmd.Parameters.Add("tipocambio_id", modelo.TipoCambioID);
                    cmd.Parameters.Add("importe_vta", modelo.ImporteVenta);
                    cmd.Parameters.Add("tipopago_id", modelo.TipoPagoID);
                    cmd.Parameters.Add("doc_pago", modelo.DocumentoPago);
                    cmd.Parameters.Add("banco_id", modelo.BancoID);
                    cmd.Parameters.Add("caja_id", modelo.CajaID);
                    cmd.Parameters.Add("cajero_id", modelo.CajeroID);
                    cmd.Parameters.Add("remision_id", modelo.RemisionID);
                    cmd.Parameters.Add("activo", (char)modelo.Activo);
                    cmd.Parameters.Add("importe_iva", modelo.ImporteIVA);
                    cmd.Parameters.Add("importe_total", modelo.ImporteTotal);
                    cmd.Parameters.Add("tipopago_fac_id", modelo.TipoPagoFacID);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();

                        var id = cmd.ExecuteScalar();
                        if (id.ToString().IsInteger())
                        {
                            if (int.Parse(id.ToString()) < 0)
                            {
                                throw new Exception("Ha ocurrido un error al insetrar el registro" + id.ToString());
                            }

                            //modelo.ID = int.Parse(id.ToString());
                        }
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


        public static bool InsertaPagosBulk(SIFModelo.Pagos modelo, List<SIFModelo.PagosDetalle> detalles)
        {
            string sentencia = "pkg_ventas.sp_ins_pagos";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("cliente_id", modelo.ClienteID);
                    cmd.Parameters.Add("num_pago", modelo.NumeroPago);
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("fecha", modelo.Fecha);
                    cmd.Parameters.Add("moneda_id", modelo.MonedaID);
                    cmd.Parameters.Add("tipocambio_id", modelo.TipoCambioID);
                    cmd.Parameters.Add("importe_vta", modelo.ImporteVenta);
                    cmd.Parameters.Add("tipopago_id", modelo.TipoPagoID);
                    cmd.Parameters.Add("doc_pago", modelo.DocumentoPago);
                    cmd.Parameters.Add("banco_id", modelo.BancoID);
                    cmd.Parameters.Add("caja_id", modelo.CajaID);
                    cmd.Parameters.Add("cajero_id", modelo.CajeroID);
                    cmd.Parameters.Add("remision_id", modelo.RemisionID);
                    cmd.Parameters.Add("activo", (char)modelo.Activo);
                    cmd.Parameters.Add("importe_iva", modelo.ImporteIVA);
                    cmd.Parameters.Add("importe_total", modelo.ImporteTotal);
                    cmd.Parameters.Add("tipopago_fac_id", modelo.TipoPagoFacID);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //DETALLES

                    OracleParameter pnum_pagos = cmd.Parameters.Add("num_pagos", OracleDbType.Decimal);
                    pnum_pagos.Direction = ParameterDirection.Input;
                    pnum_pagos.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter psucursales_id = cmd.Parameters.Add("sucursales_id", OracleDbType.Decimal);
                    psucursales_id.Direction = ParameterDirection.Input;
                    psucursales_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter pfechas = cmd.Parameters.Add("fechas", OracleDbType.Varchar2);
                    pfechas.Direction = ParameterDirection.Input;
                    pfechas.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter ptipospago_id = cmd.Parameters.Add("tipospago_id", OracleDbType.Decimal);
                    ptipospago_id.Direction = ParameterDirection.Input;
                    ptipospago_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;


                    OracleParameter pcomisiones = cmd.Parameters.Add("comisiones", OracleDbType.Decimal);
                    pcomisiones.Direction = ParameterDirection.Input;
                    pcomisiones.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter pimportes = cmd.Parameters.Add("importes", OracleDbType.Decimal);
                    pimportes.Direction = ParameterDirection.Input;
                    pimportes.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter pnum_cuenta = cmd.Parameters.Add("num_cuenta", OracleDbType.Decimal);
                    pnum_cuenta.Direction = ParameterDirection.Input;
                    pnum_cuenta.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter premisiones_id = cmd.Parameters.Add("remisiones_id", OracleDbType.Varchar2);
                    premisiones_id.Direction = ParameterDirection.Input;
                    premisiones_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;


                    List<Decimal> lnum_pagos = new List<decimal>();
                    List<decimal> lsucursales_id = new List<decimal>();
                    List<string> lfechas = new List<string>();
                    List<decimal> ltipospago_id = new List<decimal>();
                    List<decimal> lcomisiones = new List<decimal>();
                    List<decimal> limportes = new List<decimal>();
                    List<decimal> lnum_cuenta = new List<decimal>();
                    List<string> lremisiones_id = new List<string>();

                    foreach (var detalle in detalles)
                    {
                        lnum_pagos.Add(detalle.NUM_PAGO);
                        lsucursales_id.Add(detalle.SUCURSAL_ID);
                        string fecha = detalle.FECHA.ToString("dd/MM/yyyy HH:mm:ss");
                        lfechas.Add(fecha);
                        ltipospago_id.Add(detalle.TIPO_PAGO_ID);
                        lcomisiones.Add(detalle.COMISION);
                        limportes.Add(detalle.IMPORTE);
                        if ((detalle.NUM_CUENTA == null) || !detalle.NUM_CUENTA.ToString().IsInteger())
                        {
                            detalle.NUM_CUENTA = "0";
                        }
                        lnum_cuenta.Add(decimal.Parse(detalle.NUM_CUENTA));
                        lremisiones_id.Add(detalle.REMISION_ID);
                    }

                    pnum_pagos.Value = lnum_pagos.ToArray();
                    psucursales_id.Value = lsucursales_id.ToArray();
                    pfechas.Value = lfechas.ToArray();
                    ptipospago_id.Value = ltipospago_id.ToArray();
                    pcomisiones.Value = lcomisiones.ToArray();
                    pimportes.Value = limportes.ToArray();
                    pnum_cuenta.Value = lnum_cuenta.ToArray();
                    premisiones_id.Value = lremisiones_id.ToArray();

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        var id = outparam.Value;
                        if (id.ToString().IsInteger())
                        {
                            if (int.Parse(id.ToString()) < 0)
                            {
                                throw new Exception("Ha ocurrido un error al insetrar el registro" + id.ToString());
                            }

                            //modelo.ID = int.Parse(id.ToString());
                        }
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


        public static SIFModelo.Pagos PagoPorRemision(SIFModelo.Remision remision)
        {
            string sentencia = "SELECT * FROM PAGOS where REMISION_ID = :RemisionID";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Parameters.Add("RemisionID", remision.NumeroRemision);
                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Pagos registro = new SIFModelo.Pagos();

                                registro.ClienteID = int.Parse(oreader["CLIENTE_ID"].ToString());
                                registro.NumeroPago = int.Parse(oreader["NUM_PAGO"].ToString());
                                registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.Fecha = DateTime.Parse(oreader["FECHA"].ToString());
                                registro.MonedaID = int.Parse(oreader["MONEDA_ID"].ToString());
                                registro.TipoCambioID = int.Parse(oreader["TIPOCAMBIO_ID"].ToString());
                                registro.ImporteVenta = decimal.Parse(oreader["IMPORTE_VTA"].ToString());
                                registro.TipoPagoID = int.Parse(oreader["TIPOPAGO_ID"].ToString());
                                if (oreader["TIPOPAGO_ID_FAC"].ToString().IsInteger())
                                    registro.TipoPagoFacID = int.Parse(oreader["TIPOPAGO_ID_FAC"].ToString());
                                registro.DocumentoPago = oreader["DOC_PAGO"].ToString();
                                registro.BancoID = int.Parse(oreader["BANCO_ID"].ToString());
                                registro.CajaID = int.Parse(oreader["CAJA_ID"].ToString());
                                registro.CajeroID = int.Parse(oreader["CAJERO_ID"].ToString());
                                registro.RemisionID = oreader["REMISION_ID"].ToString();
                                registro.Activo = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                                registro.ImporteIVA = decimal.Parse(oreader["IMPORTE_IVA"].ToString());
                                registro.ImporteTotal = decimal.Parse(oreader["IMPORTE_TOTAL"].ToString());

                                return registro;
                            }
                        }

                    }
                }
                finally {
                    if (null != cnx)
                    {
                        cnx.Close();
                        cnx.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                }

            }
            return null;

        }

        public static bool InsertaDetalle(SIFModelo.PagosDetalle modelo)
        {
            string sentencia = "SP_INS_PAGOS_DET";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("num_pago", modelo.NUM_PAGO);
                    cmd.Parameters.Add("sucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("fecha", modelo.FECHA);
                    cmd.Parameters.Add("tipopago_id", modelo.TIPO_PAGO_ID);
                    cmd.Parameters.Add("comision", modelo.COMISION);
                    cmd.Parameters.Add("importe", modelo.IMPORTE);
                    cmd.Parameters.Add("num_cuenta", modelo.NUM_CUENTA);
                    cmd.Parameters.Add("remision_id", modelo.REMISION_ID);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();

                        var id = cmd.ExecuteScalar();
                        if (id.ToString().IsInteger())
                        {
                            if (int.Parse(id.ToString()) < 0)
                            {
                                throw new Exception("Ha ocurrido un error al insetrar el registro" + id.ToString());
                            }

                            //modelo.ID = int.Parse(id.ToString());
                        }
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

        public static SIFModelo.Ventas.CorteCajaDataSet.V_PAGOS_DETALLEDataTable BuscaPagosDetalle(SIFModelo.Caja caja, string fecha1, string fecha2)
        {
            SIFModelo.Ventas.CorteCajaDataSet ds = new SIFModelo.Ventas.CorteCajaDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.Ventas.CorteCajaDataSetTableAdapters.V_PAGOS_DETALLETableAdapter ta = new SIFModelo.Ventas.CorteCajaDataSetTableAdapters.V_PAGOS_DETALLETableAdapter();
                ta.Connection = cnx;

                ta.FillBySucursalCajaFecha(ds.V_PAGOS_DETALLE, caja.SucursalID, caja.ID, fecha1, fecha2);
            }
            return ds.V_PAGOS_DETALLE;
        }


        public static SIFModelo.Ventas.CorteCajaDataSet.V_PAGOS_CONDENSADODataTable BuscaPagosDetalleConglomerado(SIFModelo.Caja caja, string fecha1, string fecha2)
        {
            SIFModelo.Ventas.CorteCajaDataSet ds = new SIFModelo.Ventas.CorteCajaDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.Ventas.CorteCajaDataSetTableAdapters.V_PAGOS_CONDENSADOTableAdapter ta = new SIFModelo.Ventas.CorteCajaDataSetTableAdapters.V_PAGOS_CONDENSADOTableAdapter();
                ta.Connection = cnx;

                ta.FillByCajaSucursalFecha(ds.V_PAGOS_CONDENSADO, caja.SucursalID, caja.ID, fecha1, fecha2);
            }
            return ds.V_PAGOS_CONDENSADO;
        }
    }
}
