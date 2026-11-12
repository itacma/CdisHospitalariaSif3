using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace SIFDatos
{
    public class Cotizaciones
    {
        public static DataSet CotizacionsNoGenerados(SIFModelo.Sucursal sucursal, SIFModelo.Cotizacion Cotizacion, String Tipo)
        {
            DataSet ds = new DataSet("DSCotizaciones");
            ds.Tables.Add("Cotizaciones");
            string sentencia = "select NUM_COTIZACION AS FOLIO, fecha_COTIZACION as FECHA, (SELECT NOMBRE FROM CAT_USUARIOS WHERE CAT_USUARIOS.USUARIOS_ID=VENDEDOR_ID) AS ASESOR, (SELECT  NOMBRE || ' ' || APE_PATERNO || ' ' || APE_MATERNO FROM CAT_CLIENTES WHERE CAT_CLIENTES.CLIENTES_ID=COTIZACION.CLIENTE_ID) AS NOMBRE, (Select COLONIA FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=COTIZACION.CLIENTE_ID AND TIPO_DIR='CA') AS COLONIA, " +
                               " COMENTARIO,FACTURA,RECETA,TOT_ART_COTIZACION AS NO_TOTAL_ARTICULOS,TOTAL " +
                               ",ACTIVO as status, * FROM COTIZACION WHERE  ACTIVO='S' AND sucursal_id = :SucursalId AND  TIPO_COTIZACION='" + Tipo + "' AND NUM_Cotizacion LIKE :NumeroCotizacion  ORDER BY NUM_COTIZACION DESC "; //AND REF_REMISION_VTA IS NULL

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroCotizacion", "%" + Cotizacion.NumeroCotizacion + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Cotizaciones");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            ds.Tables.Add("CotizacionDetalles");
            string sentenciaDetalles = " select num_COTIZACION as folio, articulo_id as codigo,nombre1,cant_COTIZACION as NoPiezas,(select ubicacion from inventario where inventario.articulo_id=COTIZACION_DET.articulo_id and inventario.sucursal_id=COTIZACION_DET.sucursal_id) as ubicacion, " +
                                       " (select tipo_medicamento_cve from cat_articulos where cat_articulos.articulo_id=COTIZACION_DET.articulo_id) as Tipo,precio*cant_COTIZACION as Total " +
                                       " , * FROM cotizacion_det WHERE sucursal_id = :SucursalId AND NUM_COTIZACION in (SELECT NUM_COTIZACION FROM Cotizacion WHERE  sucursal_id = :SucursalesId AND NUM_COTIZACION LIKE :NumeroCotizacion )ORDER BY cotizacion_det.NUM_PARTIDA  ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                {
                    cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("SucursalesId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroCotizacion", "%" + Cotizacion.NumeroCotizacion + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "CotizacionDetalles");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            return ds;
        }

        public static DataSet CotizacionsNoGenerados(SIFModelo.Sucursal sucursal, SIFModelo.Cotizacion Cotizacion, String Tipo, DateTime fecha1, DateTime fecha2)
        {
            DataSet ds = new DataSet("DSCotizaciones");
            ds.Tables.Add("Cotizaciones");
            string sentencia = "select COTIZACION.NUM_COTIZACION AS FOLIO, COTIZACION.fecha_COTIZACION as FECHA, (SELECT NOMBRE FROM CAT_USUARIOS WHERE CAT_USUARIOS.USUARIOS_ID=VENDEDOR_ID) AS ASESOR, (SELECT  NOMBRE || ' ' || APE_PATERNO || ' ' || APE_MATERNO FROM CAT_CLIENTES WHERE CAT_CLIENTES.CLIENTES_ID=COTIZACION.CLIENTE_ID) AS NOMBRE, (Select COLONIA FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=COTIZACION.CLIENTE_ID AND TIPO_DIR='CA') AS COLONIA,  COMENTARIO,FACTURA,RECETA,TOT_ART_COTIZACION AS NO_TOTAL_ARTICULOS,TOTAL ,ACTIVO as status " +
                //" cotizacion.*, " +
                //" COTIZ_REMISION_VTA.* " +
" FROM COTIZACION " +
" LEFT OUTER JOIN COTIZ_REMISION_VTA " +
" ON COTIZACION.NUM_COTIZACION = COTIZ_REMISION_VTA.NUM_COTIZACION " +
" WHERE   COTIZACION.sucursal_id = :SucursalId ";
            sentencia += " AND COTIZACION.TIPO_COTIZACION = '" + Tipo + "' AND COTIZACION.NUM_Cotizacion LIKE :NumeroCotizacion  "; //AND REF_REMISION_VTA IS NULL
            sentencia += " AND fecha_COTIZACION >= TO_DATE('" + fecha1.ToString("yyyy/MM/dd 00:00:00") + "','YYYY/MM/DD HH24:MI:SS') AND fecha_COTIZACION <= TO_DATE('" + fecha2.ToString("yyyy/MM/dd 23:59:59") + "','YYYY/MM/DD HH24:MI:SS')";
            sentencia += " ORDER BY COTIZACION.NUM_COTIZACION DESC ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroCotizacion", "%" + Cotizacion.NumeroCotizacion + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Cotizaciones");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            ds.Tables.Add("CotizacionDetalles");
            string sentenciaDetalles = " select num_COTIZACION as folio, articulo_id as codigo,nombre1,cant_COTIZACION as NoPiezas,Precio as Precio,(select ubicacion from inventario where inventario.articulo_id=COTIZACION_DET.articulo_id and inventario.sucursal_id=COTIZACION_DET.sucursal_id) as ubicacion, " +
                                       " (select tipo_medicamento_cve from cat_articulos where cat_articulos.articulo_id=COTIZACION_DET.articulo_id) as Tipo,precio*cant_COTIZACION as Total " +
                                       "  FROM cotizacion_det WHERE sucursal_id = :SucursalId AND NUM_COTIZACION in (SELECT NUM_COTIZACION FROM Cotizacion WHERE  sucursal_id = :SucursalesId AND NUM_COTIZACION LIKE :NumeroCotizacion ) ORDER BY cotizacion_det.NUM_PARTIDA  ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                {
                    cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("SucursalesId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroCotizacion", "%" + Cotizacion.NumeroCotizacion + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "CotizacionDetalles");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            return ds;
        }

        public static bool Cancela(SIFModelo.Cotizacion Cotizacion)
        {
            throw new NotImplementedException();
        }
        public static List<SIFModelo.CotizacionDetalle> CargaDetallesF(SIFModelo.Cotizacion Cotizacion)
        {
            List<SIFModelo.CotizacionDetalle> rows = new List<SIFModelo.CotizacionDetalle>();

            string sentencia = "SELECT C.* FROM COTIZACION_DET C, INVENTARIO I WHERE C.ARTICULO_ID=I.ARTICULO_ID AND C.sucursal_id = :SucursalId AND C.NUM_COTIZACION = :NumCotizacion ORDER BY C.NUM_PARTIDA ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalId", Cotizacion.SucursalID);
                    cmd.Parameters.Add("NumCotizacion", Cotizacion.NumeroCotizacion);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.CotizacionDetalle registro = new SIFModelo.CotizacionDetalle();

                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.NumeroCotizacion = oreader["NUM_COTIZACION"].ToString();
                            registro.NumeroPartida = int.Parse(oreader["NUM_PARTIDA"].ToString());
                            registro.ArticuloID = oreader["ARTICULO_ID"].ToString();
                            registro.Nombre1 = oreader["NOMBRE1"].ToString();
                            registro.Nombre2 = oreader["NOMBRE2"].ToString();
                            registro.CantidadCotizacion = int.Parse(oreader["CANT_COTIZACION"].ToString());
                            registro.Precio = decimal.Parse(oreader["PRECIO"].ToString());
                            registro.IVA = decimal.Parse(oreader["IVA"].ToString());
                            registro.ImpuestoID = int.Parse(oreader["IMPUESTO_ID"].ToString());
                            registro.DescuentoID = int.Parse(oreader["DESCUENTO_ID"].ToString());
                            registro.PrecioCosto = decimal.Parse(oreader["PRECIO_COSTO"].ToString());
                            registro.PaqueteID = int.Parse(oreader["PAQUETE_ID"].ToString());
                            registro.CantRem = int.Parse(oreader["CANT_REMISIONADA"].ToString());
                            registro.Descto = decimal.Parse(oreader["DESCUENTO"].ToString());
                            registro.Total = decimal.Parse(oreader["TOTAL_REN"].ToString());
                            registro.PrecioVta = decimal.Parse(oreader["PRECIO_VTA"].ToString());
                            registro.COMENTARIO = oreader["COMENTARIO"].ToString();

                            rows.Add(registro);
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);

                }

            }

            return rows;

        }
        public static List<SIFModelo.CotizacionDetalle> CargaDetalles(SIFModelo.Cotizacion Cotizacion)
        {
            List<SIFModelo.CotizacionDetalle> rows = new List<SIFModelo.CotizacionDetalle>();

            string sentencia = "SELECT C.* FROM COTIZACION_DET C, INVENTARIO I WHERE C.ARTICULO_ID=I.ARTICULO_ID AND C.sucursal_id = :SucursalId AND C.NUM_COTIZACION = :NumCotizacion AND I.EXISTENCIAS>0 ORDER BY C.NUM_PARTIDA ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalId", Cotizacion.SucursalID);
                    cmd.Parameters.Add("NumCotizacion", Cotizacion.NumeroCotizacion);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.CotizacionDetalle registro = new SIFModelo.CotizacionDetalle();

                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.NumeroCotizacion = oreader["NUM_COTIZACION"].ToString();
                            registro.NumeroPartida = int.Parse(oreader["NUM_PARTIDA"].ToString());
                            registro.ArticuloID = oreader["ARTICULO_ID"].ToString();
                            registro.Nombre1 = oreader["NOMBRE1"].ToString();
                            registro.Nombre2 = oreader["NOMBRE2"].ToString();
                            registro.CantidadCotizacion = int.Parse(oreader["CANT_COTIZACION"].ToString());
                            registro.Precio = decimal.Parse(oreader["PRECIO"].ToString());
                            registro.IVA = decimal.Parse(oreader["IVA"].ToString());
                            registro.ImpuestoID = int.Parse(oreader["IMPUESTO_ID"].ToString());
                            registro.DescuentoID = int.Parse(oreader["DESCUENTO_ID"].ToString());
                            registro.PrecioCosto = decimal.Parse(oreader["PRECIO_COSTO"].ToString());
                            registro.PaqueteID = int.Parse(oreader["PAQUETE_ID"].ToString());
                            registro.CantRem = int.Parse(oreader["CANT_REMISIONADA"].ToString());
                            registro.Descto = decimal.Parse(oreader["DESCUENTO"].ToString());
                            registro.Total = decimal.Parse(oreader["TOTAL_REN"].ToString());
                            registro.PrecioVta = decimal.Parse(oreader["PRECIO_VTA"].ToString());

                            rows.Add(registro);
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);

                }

            }

            return rows;

        }
        public static SIFModelo.Cotizacion CargaCotizacionNum(string Cotizacion, SIFModelo.Sucursal sucursal)
        {
            string sentencia = "SELECT * FROM COTIZACION WHERE sucursal_id = :SucursalId AND NUM_COTIZACION = :NumCotizacion";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalId", sucursal.SucursalID);
                    cmd.Parameters.Add("NumCotizacion", Cotizacion);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Cotizacion registro = new SIFModelo.Cotizacion();

                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.NumeroCotizacion = oreader["NUM_COTIZACION"].ToString();
                            registro.TipoClienteID = int.Parse(oreader["TIPO_CLIENTE_ID"].ToString());
                            registro.ClienteID = int.Parse(oreader["CLIENTE_ID"].ToString());
                            registro.FechaCotizacion = System.Convert.ToDateTime(oreader["FECHA_COTIZACION"]);
                            registro.Receta = (SIFModelo.Tipos.SiNo)oreader["RECETA"].ToString()[0];
                            registro.MedicoID = int.Parse(oreader["ID_MEDICO"].ToString());
                            registro.VendedorID = int.Parse(oreader["VENDEDOR_ID"].ToString());
                            registro.MonedaID = int.Parse(oreader["MONEDA_ID"].ToString());
                            registro.TipoCambioID = int.Parse(oreader["TIPO_CAMBIO_ID"].ToString());
                            registro.SubTotal = decimal.Parse(oreader["SUBTOTAL"].ToString());
                            registro.ImpuestoVenta = decimal.Parse(oreader["IMPUESTO_IVA"].ToString());
                            registro.Descuento = decimal.Parse(oreader["DESCUENTO"].ToString());
                            registro.NumeroCredencial = oreader["NUM_CREDENCIAL"].ToString();
                            registro.Total = decimal.Parse(oreader["TOTAL"].ToString());
                            registro.TotalArticulos = int.Parse(oreader["TOT_ART_COTIZACION"].ToString());
                            registro.Activo = (SIFModelo.Tipos.SiNo)oreader["ACTIVO"].ToString()[0];
                            registro.ImporteLetra = oreader["IMPORTE_LETRA"].ToString();
                            registro.Factura = (SIFModelo.Tipos.SiNo)oreader["FACTURA"].ToString()[0];
                            registro.TipoCotizacion = (SIFModelo.Tipos.TipoCotizacion)oreader["TIPO_COTIZACION"].ToString()[0];
                            registro.Comentario = oreader["COMENTARIO"].ToString();

                            return registro;
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }
            }

            return null;
        }
        public static SIFModelo.Cotizacion CargaCotizacion(SIFModelo.Cotizacion Cotizacion, SIFModelo.Sucursal sucursal)
        {
            string sentencia = "SELECT * FROM COTIZACION WHERE sucursal_id = :SucursalId AND NUM_COTIZACION = :NumCotizacion";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Parameters.Add("SucursalId", sucursal.SucursalID);
                        cmd.Parameters.Add("NumCotizacion", Cotizacion.NumeroCotizacion);
                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Cotizacion registro = new SIFModelo.Cotizacion();

                                registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.NumeroCotizacion = oreader["NUM_COTIZACION"].ToString();
                                registro.TipoClienteID = int.Parse(oreader["TIPO_CLIENTE_ID"].ToString());
                                registro.ClienteID = int.Parse(oreader["CLIENTE_ID"].ToString());
                                registro.FechaCotizacion = System.Convert.ToDateTime(oreader["FECHA_COTIZACION"]);
                                registro.Receta = (SIFModelo.Tipos.SiNo)oreader["RECETA"].ToString()[0];
                                registro.MedicoID = int.Parse(oreader["ID_MEDICO"].ToString());
                                registro.VendedorID = int.Parse(oreader["VENDEDOR_ID"].ToString());
                                registro.MonedaID = int.Parse(oreader["MONEDA_ID"].ToString());
                                registro.TipoCambioID = int.Parse(oreader["TIPO_CAMBIO_ID"].ToString());
                                registro.SubTotal = decimal.Parse(oreader["SUBTOTAL"].ToString());
                                registro.ImpuestoVenta = decimal.Parse(oreader["IMPUESTO_IVA"].ToString());
                                registro.Descuento = decimal.Parse(oreader["DESCUENTO"].ToString());
                                registro.NumeroCredencial = oreader["NUM_CREDENCIAL"].ToString();
                                registro.Total = decimal.Parse(oreader["TOTAL"].ToString());
                                registro.TotalArticulos = int.Parse(oreader["TOT_ART_COTIZACION"].ToString());
                                registro.Activo = (SIFModelo.Tipos.SiNo)oreader["ACTIVO"].ToString()[0];
                                registro.ImporteLetra = oreader["IMPORTE_LETRA"].ToString();
                                registro.Factura = (SIFModelo.Tipos.SiNo)oreader["FACTURA"].ToString()[0];
                                registro.TipoCotizacion = (SIFModelo.Tipos.TipoCotizacion)oreader["TIPO_COTIZACION"].ToString()[0];
                                registro.Comentario = oreader["COMENTARIO"].ToString();

                                return registro;
                            }
                        }
                    }
                }
                catch { }
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


        public static bool ActualizaCotizacion(SIFModelo.Cotizacion modelo)
        {
            string sentencia = "sp_upd_Cotizacion";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("esucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("enum_cotizacion", modelo.NumeroCotizacion);
                    cmd.Parameters.Add("etipo_cliente_id", modelo.TipoClienteID);
                    cmd.Parameters.Add("ecliente_id", modelo.ClienteID);
                    cmd.Parameters.Add("efecha_cotizacion", modelo.FechaCotizacion);
                    cmd.Parameters.Add("ereceta", System.Convert.ToChar(modelo.Receta));
                    cmd.Parameters.Add("eid_medico", modelo.MedicoID);
                    cmd.Parameters.Add("evendedor_id", modelo.VendedorID);
                    cmd.Parameters.Add("emoneda_id", modelo.MonedaID);
                    cmd.Parameters.Add("etipo_cambio_id", modelo.TipoCambioID);
                    cmd.Parameters.Add("esubtotal", modelo.SubTotal);
                    cmd.Parameters.Add("eimpuesto_iva", modelo.ImpuestoVenta);
                    cmd.Parameters.Add("edescuento", modelo.Descuento);
                    cmd.Parameters.Add("enum_credencial", modelo.NumeroCredencial);
                    cmd.Parameters.Add("etotal", modelo.Total);
                    cmd.Parameters.Add("etot_art_cotizacion", modelo.TotalArticulos);
                    cmd.Parameters.Add("eactivo", System.Convert.ToChar(modelo.Activo));
                    cmd.Parameters.Add("eimporte_letra", modelo.ImporteLetra);
                    cmd.Parameters.Add("efactura", System.Convert.ToChar(modelo.Factura));
                    cmd.Parameters.Add("ecomentario", modelo.Comentario);
                    cmd.Parameters.Add("etipo_cotizacion", System.Convert.ToChar(modelo.TipoCotizacion));

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Int32);
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
                        
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            return true;
        }

        public static IEnumerable<SIFModelo.Cotizacion> CotizacionesPendientes24hrs(SIFModelo.Sucursal sucursal)
        {
            throw new NotImplementedException();
        }

        public static bool Inserta(SIFModelo.Cotizacion modelo)
        {
            string sentencia = "sp_ins_cotizacion";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("num_cotizacion", modelo.NumeroCotizacion);
                    cmd.Parameters.Add("tipo_cliente_id", modelo.TipoClienteID);
                    cmd.Parameters.Add("cliente_id", modelo.ClienteID);
                    cmd.Parameters.Add("fecha_cotizacion", modelo.FechaCotizacion);
                    cmd.Parameters.Add("receta", System.Convert.ToChar(modelo.Receta));
                    cmd.Parameters.Add("id_medico", modelo.MedicoID);
                    cmd.Parameters.Add("vendedor_id", modelo.VendedorID);
                    cmd.Parameters.Add("moneda_id", modelo.MonedaID);
                    cmd.Parameters.Add("tipo_cambio_id", modelo.TipoCambioID);
                    cmd.Parameters.Add("subtotal", modelo.SubTotal);
                    cmd.Parameters.Add("impuesto_iva", modelo.ImpuestoVenta);
                    cmd.Parameters.Add("descuento", modelo.Descuento);
                    cmd.Parameters.Add("num_credencial", modelo.NumeroCredencial);
                    cmd.Parameters.Add("total", modelo.Total);
                    cmd.Parameters.Add("tot_art_cotizacion", modelo.TotalArticulos);
                    cmd.Parameters.Add("importe_letra", modelo.ImporteLetra);
                    cmd.Parameters.Add("factura", System.Convert.ToChar(modelo.Factura));
                    cmd.Parameters.Add("tipo_cotizacion", System.Convert.ToChar(modelo.TipoCotizacion));
                    cmd.Parameters.Add("activo", System.Convert.ToChar(modelo.Activo));
                    cmd.Parameters.Add("comentario", modelo.Comentario);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
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
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            return true;
        }

        public static bool Elimina(SIFModelo.Cotizacion modelo)
        {
            string sentencia = "sp_del_cotizacion";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sucursalID", modelo.SucursalID);
                    cmd.Parameters.Add("numcot", modelo.NumeroCotizacion);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
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
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            return true;
        }
        public static bool InsertaDetalle(SIFModelo.CotizacionDetalle modelo)
        {
            string sentencia = "sp_ins_cotizacion_det";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("num_cotizacion", modelo.NumeroCotizacion);
                    cmd.Parameters.Add("num_partida", modelo.NumeroPartida);
                    cmd.Parameters.Add("articulo_id", modelo.ArticuloID);
                    cmd.Parameters.Add("nombre1", modelo.Nombre1);
                    cmd.Parameters.Add("nombre2", modelo.Nombre2);
                    cmd.Parameters.Add("cant_cotizacion", modelo.CantidadCotizacion);
                    cmd.Parameters.Add("precio", modelo.Precio);
                    cmd.Parameters.Add("iva", modelo.IVA);
                    cmd.Parameters.Add("impuesto_id", modelo.ImpuestoID);
                    cmd.Parameters.Add("descuento_id", modelo.DescuentoID);
                    cmd.Parameters.Add("precio_costo", modelo.PrecioCosto);
                    cmd.Parameters.Add("paquete_id", modelo.PaqueteID);
                    cmd.Parameters.Add("CANT_REMISIONADA", modelo.CantRem);
                    cmd.Parameters.Add("DESCUENTO", modelo.Descto);
                    cmd.Parameters.Add("TOTAL_REN", modelo.Total);
                    cmd.Parameters.Add("PRECIO_VTA", modelo.PrecioVta);
                    cmd.Parameters.Add("NO_REMISION", modelo.NumRemision);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
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
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            return true;
        }

        public static int NumeroCotizacion(int sucursalId, string prefijoFolio)
        {
            object id;
            string sentencia = "SELECT NVL(COUNT(num_cotizacion),0) + 1 FROM COTIZACION WHERE TO_CHAR( fecha_cotizacion,'YY') = :prefijoFolio AND sucursal_id = :sucursalID";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("sucursalID", sucursalId);
                    cmd.Parameters.Add("prefijoFolio", prefijoFolio);
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
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }
            return int.Parse(id.ToString());
        }

        public static bool CotizacionVentaInserta(SIFModelo.Cotizacion modelo, SIFModelo.Remision remision)
        {
            string sentencia = "SP_INS_COTIZ_REMISION_VTA";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("SUCURSAL_ID", modelo.SucursalID);
                    cmd.Parameters.Add("NUM_COTIZACION", modelo.NumeroCotizacion);
                    cmd.Parameters.Add("FEC_REMISION_VTA", remision.FechaVenta);
                    cmd.Parameters.Add("REF_REMISION_VTA", remision.NumeroRemision);
                    cmd.Parameters.Add("TIPO_COTIZACION", (char)modelo.TipoCotizacion);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
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
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            return true;
        }

        public static bool InsertaBulk(SIFModelo.Cotizacion modelo, List<SIFModelo.CotizacionDetalle> detalles)
        {
            string sentencia = "PKG_VENTAS.sp_ins_cotizacion";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("p_sucursal_id", OracleDbType.Decimal, modelo.SucursalID, ParameterDirection.Input);
                    cmd.Parameters.Add("p_num_cotizacion", OracleDbType.Varchar2, modelo.NumeroCotizacion, ParameterDirection.Input);
                    cmd.Parameters.Add("p_tipo_cliente_id", OracleDbType.Decimal, modelo.TipoClienteID, ParameterDirection.Input);
                    cmd.Parameters.Add("p_cliente_id", OracleDbType.Decimal, modelo.ClienteID, ParameterDirection.Input);

                    cmd.Parameters.Add("p_receta", OracleDbType.Char, System.Convert.ToChar(modelo.Receta).ToString(), ParameterDirection.Input);
                    cmd.Parameters.Add("p_id_medico", OracleDbType.Decimal, modelo.MedicoID, ParameterDirection.Input);
                    cmd.Parameters.Add("p_vendedor_id", OracleDbType.Decimal, modelo.VendedorID, ParameterDirection.Input);
                    cmd.Parameters.Add("p_moneda_id", OracleDbType.Decimal, modelo.MonedaID, ParameterDirection.Input);
                    cmd.Parameters.Add("p_tipo_cambio_id", OracleDbType.Decimal, modelo.TipoCambioID, ParameterDirection.Input);
                    cmd.Parameters.Add("p_subtotal", OracleDbType.Decimal, modelo.SubTotal, ParameterDirection.Input);
                    cmd.Parameters.Add("p_impuesto_iva", OracleDbType.Decimal, modelo.ImpuestoVenta, ParameterDirection.Input);
                    cmd.Parameters.Add("p_descuentoh", OracleDbType.Decimal, modelo.Descuento, ParameterDirection.Input);
                    cmd.Parameters.Add("p_num_credencial", OracleDbType.Varchar2, modelo.NumeroCredencial, ParameterDirection.Input);
                    cmd.Parameters.Add("p_total", OracleDbType.Decimal, modelo.Total, ParameterDirection.Input);
                    cmd.Parameters.Add("p_tot_art_cotizacion", OracleDbType.Varchar2, modelo.TotalArticulos, ParameterDirection.Input);
                    cmd.Parameters.Add("p_importe_letra", OracleDbType.Varchar2, modelo.ImporteLetra, ParameterDirection.Input);
                    cmd.Parameters.Add("p_factura", OracleDbType.Char, System.Convert.ToChar(modelo.Factura).ToString(), ParameterDirection.Input);
                    cmd.Parameters.Add("p_tipo_cotizacion", OracleDbType.Char, System.Convert.ToChar(modelo.TipoCotizacion).ToString(), ParameterDirection.Input);
                    //cmd.Parameters.Add("activo", System.Convert.ToChar(modelo.Activo));
                    cmd.Parameters.Add("p_comentario", OracleDbType.Varchar2, modelo.Comentario, ParameterDirection.Input);

                    //LISTA
                    List<decimal> Lnum_partida = new List<decimal>();
                    List<string> Larticulo_id = new List<string>();
                    List<string> Lnombre1 = new List<string>();
                    List<string> Lnombre2 = new List<string>();
                    List<decimal> Lcant_cotizacion = new List<decimal>();
                    List<decimal> Lprecio = new List<decimal>();
                    List<decimal> Liva = new List<decimal>();
                    List<decimal> Limpuesto_id = new List<decimal>();
                    List<decimal> Ldescuento_id = new List<decimal>();
                    List<decimal> Lprecio_costo = new List<decimal>();
                    List<decimal> Lpaquete_id = new List<decimal>();
                    List<decimal> Lcant_remision = new List<decimal>();
                    List<decimal> Ldescuentod = new List<decimal>();
                    List<decimal> Ltotal_ren = new List<decimal>();
                    List<decimal> Lprecio_vta = new List<decimal>();
                    List<string> Lno_remision = new List<string>();
                    List<string> Lcoment = new List<string>();

                    int numPartida = 1;
                    foreach (var detalle in detalles)
                    {
                        Lnum_partida.Add(numPartida);
                        numPartida++;
                        Larticulo_id.Add(detalle.ArticuloID);
                        Lnombre1.Add(detalle.Nombre1);
                        Lnombre2.Add(detalle.Nombre2);
                        Lcant_cotizacion.Add(detalle.CantidadCotizacion);
                        Lprecio.Add(detalle.Precio);
                        Liva.Add(detalle.IVA);
                        Limpuesto_id.Add(detalle.ImpuestoID);
                        Ldescuento_id.Add(detalle.DescuentoID);
                        Lprecio_costo.Add(detalle.PrecioCosto);
                        Ldescuento_id.Add(detalle.DescuentoID);
                        Lpaquete_id.Add(detalle.PaqueteID);
                        Lcant_remision.Add(detalle.CantRem);
                        Ldescuentod.Add(detalle.Descto);
                        Ltotal_ren.Add(detalle.Total);
                        Lprecio_vta.Add(detalle.PrecioVta);
                        Lno_remision.Add(detalle.NumRemision);
                        Lcoment.Add(detalle.COMENTARIO);
                    }


                    OracleParameter pnum_partida = cmd.Parameters.Add("p_num_partida", OracleDbType.Decimal);
                    pnum_partida.Direction = ParameterDirection.Input;
                    pnum_partida.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pnum_partida.Value = Lnum_partida.ToArray();

                    OracleParameter p_articulo_id = cmd.Parameters.Add("p_articulo_id", OracleDbType.Varchar2);
                    p_articulo_id.Direction = ParameterDirection.Input;
                    p_articulo_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_articulo_id.Value = Larticulo_id.ToArray();

                    OracleParameter p_nombre1 = cmd.Parameters.Add("p_nombre1", OracleDbType.Varchar2);
                    p_nombre1.Direction = ParameterDirection.Input;
                    p_nombre1.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_nombre1.Value = Lnombre1.ToArray();

                    OracleParameter p_nombre2 = cmd.Parameters.Add("p_nombre2", OracleDbType.Varchar2);
                    p_nombre2.Direction = ParameterDirection.Input;
                    p_nombre2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_nombre2.Value = Lnombre2.ToArray();

                    OracleParameter p_cant_cotizacion = cmd.Parameters.Add("p_cant_cotizacion", OracleDbType.Decimal);
                    p_cant_cotizacion.Direction = ParameterDirection.Input;
                    p_cant_cotizacion.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_cant_cotizacion.Value = Lcant_cotizacion.ToArray();

                    OracleParameter p_precio = cmd.Parameters.Add("p_precio", OracleDbType.Decimal);
                    p_precio.Direction = ParameterDirection.Input;
                    p_precio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_precio.Value = Lprecio.ToArray();

                    OracleParameter p_iva = cmd.Parameters.Add("p_iva", OracleDbType.Decimal);
                    p_iva.Direction = ParameterDirection.Input;
                    p_iva.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_iva.Value = Liva.ToArray();

                    OracleParameter p_impuesto_id = cmd.Parameters.Add("p_impuesto_id", OracleDbType.Decimal);
                    p_impuesto_id.Direction = ParameterDirection.Input;
                    p_impuesto_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_impuesto_id.Value = Limpuesto_id.ToArray();

                    OracleParameter p_descuento_id = cmd.Parameters.Add("p_descuento_id", OracleDbType.Decimal);
                    p_descuento_id.Direction = ParameterDirection.Input;
                    p_descuento_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_descuento_id.Value = Ldescuento_id.ToArray();

                    OracleParameter p_precio_costo = cmd.Parameters.Add("p_precio_costo", OracleDbType.Decimal);
                    p_precio_costo.Direction = ParameterDirection.Input;
                    p_precio_costo.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_precio_costo.Value = Lprecio_costo.ToArray();

                    OracleParameter p_paquete_id = cmd.Parameters.Add("p_paquete_id", OracleDbType.Decimal);
                    p_paquete_id.Direction = ParameterDirection.Input;
                    p_paquete_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_paquete_id.Value = Lpaquete_id.ToArray();

                    OracleParameter p_cant_remision = cmd.Parameters.Add("p_cant_remision", OracleDbType.Decimal);
                    p_cant_remision.Direction = ParameterDirection.Input;
                    p_cant_remision.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_cant_remision.Value = Lcant_remision.ToArray();

                    OracleParameter p_descuentod = cmd.Parameters.Add("p_descuentod", OracleDbType.Decimal);
                    p_descuentod.Direction = ParameterDirection.Input;
                    p_descuentod.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_descuentod.Value = Ldescuentod.ToArray();

                    OracleParameter p_total_ren = cmd.Parameters.Add("p_total_ren", OracleDbType.Decimal);
                    p_total_ren.Direction = ParameterDirection.Input;
                    p_total_ren.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_total_ren.Value = Ltotal_ren.ToArray();

                    OracleParameter p_precio_vta = cmd.Parameters.Add("p_precio_vta", OracleDbType.Decimal);
                    p_precio_vta.Direction = ParameterDirection.Input;
                    p_precio_vta.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_precio_vta.Value = Lprecio_vta.ToArray();

                    OracleParameter p_no_remision = cmd.Parameters.Add("p_no_remision", OracleDbType.Varchar2);
                    p_no_remision.Direction = ParameterDirection.Input;
                    p_no_remision.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_no_remision.Value = Lno_remision.ToArray();

                    OracleParameter p_coment_det = cmd.Parameters.Add("p_comentario_det", OracleDbType.Varchar2);
                    p_coment_det.Direction = ParameterDirection.Input;
                    p_coment_det.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_coment_det.Value = Lcoment.ToArray();

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("OutParam", OracleDbType.Int32);
                    outparam.Direction = System.Data.ParameterDirection.Output;
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
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }
            return true;

        }

        public static string CreaCotizacionDeremision(string remision, string movimiento, String _cnx)
        {
            string sentencia = "SP_CREA_COTIZACION_D_REMI";
            using (OracleConnection cnx = new OracleConnection(_cnx))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS

                    cmd.Parameters.Add("V_FOLIOF", remision);
                    cmd.Parameters.Add("v_movimiento", movimiento);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Varchar2);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam).Size = 1000;

                    //object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        return outparam.Value.ToString();
                    }
                    catch (Exception ext)
                    {

                        return ext.ToString();
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }


        }



    }
}
