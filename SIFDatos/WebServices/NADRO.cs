using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace SIFDatos.WebServices
{
    public static class NADRO
    {
        public static bool Inserta(SIFModelo.WebServices.Nadro modelo)
        {
            string sentencia = "sp_ins_ctl_nadro";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    DateTime? fechaConfirmacion = null;

                    if (modelo.FechaConfirmacion != new DateTime())
                    {
                        fechaConfirmacion = fechaConfirmacion.Value;
                    }

                    //PARAMETROS
                    cmd.Parameters.Add("no_remision", modelo.NumeroRemision);
                    cmd.Parameters.Add("cadena_id", modelo.CadenaID);
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("usuario_id", modelo.UsuarioID);
                    cmd.Parameters.Add("no_tarjeta", modelo.NumeroTarjeta);
                    cmd.Parameters.Add("cotizacion_id", modelo.CotizacionID);
                    cmd.Parameters.Add("fecha_compra", modelo.FechaCompra);
                    cmd.Parameters.Add("no_confirmacion", modelo.NumeroConfirmacion);
                    cmd.Parameters.Add("fecha_confirmacion", fechaConfirmacion);
                    cmd.Parameters.Add("activo", (char)modelo.Activo);
                    cmd.Parameters.Add("cedulaprofesionalmedico", modelo.CedulaProfesionalMedico);


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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }

            return true;
        }


        public static bool InsertaDetalle(SIFModelo.WebServices.NadroDetalle modelo)
        {
            string sentencia = "sp_ins_ctl_nadro_det";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("cotizacion_id", modelo.CotizacionID);
                    cmd.Parameters.Add("articulo_id", modelo.ArticuloID);
                    cmd.Parameters.Add("num_partida", modelo.Partida);
                    cmd.Parameters.Add("precio", modelo.PrecDesctoNadro);
                    cmd.Parameters.Add("precio_sif", modelo.Precio);
                    cmd.Parameters.Add("precio_fijo", modelo.PrecioFijo);
                    cmd.Parameters.Add("porcentaje_descuento", modelo.PorcenDesctoNadro);
                    cmd.Parameters.Add("monto_descuento", modelo.MontoDesctoNadro);
                    cmd.Parameters.Add("piezas_pedido", modelo.CantPagarNadro);
                    cmd.Parameters.Add("piezas_beneficio", modelo.CantRegaloNadro);
                    cmd.Parameters.Add("iva", modelo.IVA);
                    cmd.Parameters.Add("porcentaje_iva", "0");
                    cmd.Parameters.Add("tipo_precio_descuento", modelo.TipoPrecio);

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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }

            return true;
        }


        public static List<SIFModelo.WebServices.NadroDetalle> ControlDetalles(SIFModelo.WebServices.Nadro nadro)
        {

            List<SIFModelo.WebServices.NadroDetalle> rows = new List<SIFModelo.WebServices.NadroDetalle>();
            try
            {
                string sentencia = "SELECT * FROM ctl_nadro_det WHERE COTIZACION_ID = :COTIZACION_ID";

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {

                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Parameters.Add("COTIZACION_ID", nadro.CotizacionID);
                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.WebServices.NadroDetalle registro = new SIFModelo.WebServices.NadroDetalle();
                                if (registro != null)
                                {  // registro.NumeroRemision = oreader["NO_REMISION"].ToString();
                                    registro.CotizacionID = oreader["COTIZACION_ID"].ToString();
                                    registro.ArticuloID = oreader["ARTICULO_ID"].ToString();
                                    registro.Partida = int.Parse(oreader["NUM_PARTIDA"].ToString());
                                    registro.Precio = decimal.Parse(oreader["PRECIO_SIF"].ToString());
                                    registro.TipoPrecio = int.Parse(oreader["PRECIO"].ToString());
                                    //registro.Preciosif = oreader["PRECIO_SIF"].ToString();
                                    registro.PrecioFijo = decimal.Parse(oreader["PRECIO_FIJO"].ToString());
                                    registro.PorcenDesctoNadro = double.Parse(oreader["PORCENTAJE_DESCUENTO"].ToString());
                                    registro.MontoDesctoNadro = decimal.Parse(oreader["MONTO_DESCUENTO"].ToString());
                                    registro.CantPagarNadro = int.Parse(oreader["PIEZAS_PEDIDO"].ToString());
                                    registro.CantRegaloNadro = int.Parse(oreader["PIEZAS_BENEFICIO"].ToString());
                                    registro.IVA = decimal.Parse(oreader["IVA"].ToString());

                                    //registro. = oreader["PORCENTAJE_IVA"].ToString();
                                    rows.Add(registro);
                                }
                            }
                        }
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }
                 
                }

            }
            catch (Exception ex)
            {
                //rtb_Msg.AppendText(ex.ToString() + System.Environment.NewLine);
            }
            finally
            {
            }
            return rows;
        }


        public static SIFModelo.WebServices.Nadro Control(SIFModelo.Remision remision)
        {
            string sentencia = "SELECT * FROM ctl_nadro WHERE NO_REMISION = :REMISION_ID AND SUCURSAL_ID = :SUCURSAL_ID";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("REMISION_ID", remision.NumeroRemision);
                    cmd.Parameters.Add("SUCURSAL_ID", remision.SucursalID);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.WebServices.Nadro registro = new SIFModelo.WebServices.Nadro();
                            if (registro != null)
                            {
                                registro.NumeroRemision = oreader["NO_REMISION"].ToString();
                                registro.CadenaID = int.Parse(oreader["CADENA_ID"].ToString());
                                registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.UsuarioID = int.Parse(oreader["USUARIO_ID"].ToString());
                                registro.NumeroTarjeta = oreader["NO_TARJETA"].ToString();

                                registro.CotizacionID = oreader["COTIZACION_ID"].ToString();
                                registro.FechaCompra = DateTime.Parse(oreader["FECHA_COMPRA"].ToString());
                                registro.NumeroConfirmacion = oreader["NO_CONFIRMACION"].ToString();
                                var FECHA_CONFIRMACION = oreader["FECHA_CONFIRMACION"];
                                if (FECHA_CONFIRMACION.ToString().IsDatetime())
                                    registro.FechaConfirmacion = DateTime.Parse(oreader["FECHA_CONFIRMACION"].ToString());
                                registro.Activo = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                                registro.CedulaProfesionalMedico = oreader["CEDULAPROFESIONALMEDICO"].ToString();
                            }
                            return registro;
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);
                }

            }
            return null;
        }

        public static bool Actualiza(SIFModelo.WebServices.Nadro modelo)
        {
            string sentencia = "sp_upd_ctl_nadro";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("eno_remision", modelo.NumeroRemision);
                    cmd.Parameters.Add("ecadena_id", modelo.CadenaID);
                    cmd.Parameters.Add("esucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("eusuario_id", modelo.UsuarioID);
                    cmd.Parameters.Add("eno_tarjeta", modelo.NumeroTarjeta);
                    cmd.Parameters.Add("ecotizacion_id", modelo.CotizacionID);
                    cmd.Parameters.Add("efecha_compra", modelo.FechaCompra);
                    cmd.Parameters.Add("eno_confirmacion", modelo.NumeroConfirmacion);
                    cmd.Parameters.Add("efecha_confirmacion", modelo.FechaConfirmacion);
                    cmd.Parameters.Add("eactivo", (char)modelo.Activo);
                    cmd.Parameters.Add("ecedulaprofesionalmedico", modelo.CedulaProfesionalMedico);
                    //cmd.Parameters.Add("porcentaje_iva", modelo.iva);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();

                        var id = cmd.ExecuteScalar();
                        //if (id.ToString().IsInteger())
                        //{
                        //    if (int.Parse(id.ToString()) < 0)
                        //    {
                        //        throw new Exception("Ha ocurrido un error al insetrar el registro" + id.ToString());
                        //    }

                        //    //modelo.ID = int.Parse(id.ToString());
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
    }
}
