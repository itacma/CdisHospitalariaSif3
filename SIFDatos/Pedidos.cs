using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace SIFDatos
{
    public class Pedidos
    {
        public static DataSet PedidosNoGenerados(SIFModelo.Sucursal sucursal, SIFModelo.Pedido pedido, Boolean todos)
        {
            string sentencia = "";
            DataSet ds = new DataSet("DSPedidos");
            ds.Tables.Add("Pedidos");
            if (todos)
                sentencia = "select NUM_PEDIDO AS FOLIO, fecha_pedido as FECHA, (SELECT NOMBRE FROM CAT_USUARIOS WHERE CAT_USUARIOS.USUARIOS_ID=VENDEDOR_ID) AS ASESOR, (SELECT NOMBRE || ' ' || APE_PATERNO || ' ' || APE_MATERNO  FROM CAT_CLIENTES WHERE CAT_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID) AS NOMBRE, (Select COLONIA FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID AND TIPO_DIR='CA') AS COLONIA, (Select MUNICIPIO FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID AND TIPO_DIR='CA') AS MUNICIPIO," +
                            " COMENTARIO,FACTURA,RECETA,TOT_ARTICULOS_PEDIDO AS NO_TOTAL_ARTICULOS,(SELECT NOMBRE FROM CAT_TIPO_PAGO WHERE CAT_TIPO_PAGO.TIPO_PAGO_ID=PEDIDO.TIPO_PAGO_ID) AS FORMA_PAGO, TOTAL, TOTAL_PAGO AS PAGO,TOTAL_PAGO-TOTAL AS CAMBIO " +
                            ",* from pedido WHERE  sucursal_id = :SucursalId AND NUM_PEDIDO LIKE :NumeroPedido AND pedido.activo = 'S' ORDER BY NUM_PEDIDO DESC"; //AND REF_REMISION_VTA IS NULL
            else
                sentencia = "select NUM_PEDIDO AS FOLIO, fecha_PEdido as FECHA, (SELECT NOMBRE FROM CAT_USUARIOS WHERE CAT_USUARIOS.USUARIOS_ID=VENDEDOR_ID) AS ASESOR, (SELECT NOMBRE || ' ' || APE_PATERNO || ' ' || APE_MATERNO  FROM CAT_CLIENTES WHERE CAT_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID) AS NOMBRE, (Select COLONIA FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID AND TIPO_DIR='CA') AS COLONIA,(Select MUNICIPIO FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID AND TIPO_DIR='CA') AS MUNICIPIO, " +
                            " COMENTARIO,FACTURA,RECETA,TOT_ARTICULOS_PEDIDO AS NO_TOTAL_ARTICULOS,(SELECT NOMBRE FROM CAT_TIPO_PAGO WHERE CAT_TIPO_PAGO.TIPO_PAGO_ID=PEDIDO.TIPO_PAGO_ID) AS FORMAPAGO, TOTAL, TOTAL_PAGO AS PAGO,TOTAL_PAGO-TOTAL AS CAMBIO " +
                            ",* from pedido WHERE  sucursal_id = :SucursalId AND NUM_PEDIDO LIKE :NumeroPedido  AND REF_REMISION_VTA IS NULL AND pedido.activo = 'S' ORDER BY NUM_PEDIDO DESC"; //

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroPedido", "%" + pedido.NumeroPedido + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Pedidos");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            ds.Tables.Add("PedidoDetalles");
            string sentenciaDetalles = " select num_pedido as folio, articulo_id as codigo,nombre1,cant_pedido as NoPiezas,(select ubicacion from inventario where inventario.articulo_id=pedido_det.articulo_id and inventario.sucursal_id=pedido_det.sucursal_id) as ubicacion, " +
                                       " (select tipo_medicamento_cve from cat_articulos where cat_articulos.articulo_id=pedido_det.articulo_id) as Tipo,precio*cant_pedido as Total " +
                                       ",* FROM PEDIDO_DET WHERE sucursal_id = :SucursalId AND NUM_PEDIDO in (SELECT NUM_PEDIDO FROM pedido WHERE  sucursal_id = :SucursalesId AND NUM_PEDIDO LIKE :NumeroPedido  )  "; //AND REF_REMISION_VTA IS NULL

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                {
                    cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("SucursalesId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroPedido", "%" + pedido.NumeroPedido + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "PedidoDetalles");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            return ds;
        }

        public static SIFModelo.Pedido ObtenPedido(String NoReferencia)
        {
            string sentencia = "";
            DataSet ds = new DataSet("DSPedidos");
            SIFModelo.Pedido pedido = new SIFModelo.Pedido();
            ds.Tables.Add("Pedidos");

            sentencia = "select NUM_PEDIDO AS FOLIO, fecha_PEdido as FECHA, (SELECT NOMBRE FROM CAT_USUARIOS WHERE CAT_USUARIOS.USUARIOS_ID=VENDEDOR_ID) AS ASESOR, (SELECT NOMBRE || ' ' || APE_PATERNO || ' ' || APE_MATERNO  FROM CAT_CLIENTES WHERE CAT_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID) AS NOMBRE, (Select COLONIA FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID AND TIPO_DIR='CA') AS COLONIA,(Select MUNICIPIO FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID AND TIPO_DIR='CA') AS MUNICIPIO, " +
                        " COMENTARIO,FACTURA,RECETA,TOT_ARTICULOS_PEDIDO AS NO_TOTAL_ARTICULOS,(SELECT NOMBRE FROM CAT_TIPO_PAGO WHERE CAT_TIPO_PAGO.TIPO_PAGO_ID=PEDIDO.TIPO_PAGO_ID) AS FORMAPAGO, TOTAL, TOTAL_PAGO AS PAGO,TOTAL_PAGO-TOTAL AS CAMBIO " +
                        ",pedido.* from pedido WHERE   REF_REMISION_VTA LIKE :NumeroPedido  AND pedido.activo = 'S' ORDER BY NUM_PEDIDO DESC"; //

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandText = sentencia;
                    cmd.Parameters.Add("NumeroPedido", "" + NoReferencia + "");
                    //
                    cmd.Connection.Open();

                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            //da.Fill(ds, "Pedidos");
                            pedido.ClienteID = int.Parse(oreader["CLIENTE_ID"].ToString());
                            pedido.NumeroPedido = oreader["NUM_PEDIDO"].ToString();
                            pedido.SubTotal = decimal.Parse(oreader["SUBTOTAL"].ToString());
                            pedido.Total = decimal.Parse(oreader["TOTAL"].ToString());
                            pedido.Comentario = oreader["COMENTARIO"].ToString();
                            pedido.TipoPagoID = int.Parse(oreader["TIPO_PAGO_ID"].ToString());
                            pedido.TotalPago = decimal.Parse(oreader["TOTAL_PAGO"].ToString());
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }


            return pedido;


        }

        public static bool Cancela(SIFModelo.Pedido Pedido)
        {
            throw new NotImplementedException();
        }

        public static List<SIFModelo.PedidoDetalle> CargaDetalles(SIFModelo.Pedido pedido)
        {
            List<SIFModelo.PedidoDetalle> rows = new List<SIFModelo.PedidoDetalle>();

            string sentencia = "SELECT * FROM PEDIDO_DET WHERE sucursal_id = :SucursalId AND NUM_PEDIDO = :NumPedido";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalId", pedido.SucursalID);
                    cmd.Parameters.Add("NumPedido", pedido.NumeroPedido);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.PedidoDetalle registro = new SIFModelo.PedidoDetalle();

                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.NumeroPedido = oreader["NUM_PEDIDO"].ToString();
                            registro.NumeroPartida = int.Parse(oreader["NUM_PARTIDA"].ToString());
                            registro.ArticuloID = oreader["ARTICULO_ID"].ToString();
                            registro.Nombre1 = oreader["NOMBRE1"].ToString();
                            registro.Nombre2 = oreader["NOMBRE2"].ToString();
                            registro.CantidadPedido = int.Parse(oreader["CANT_PEDIDO"].ToString());
                            registro.Precio = decimal.Parse(oreader["PRECIO"].ToString());
                            registro.IVA = decimal.Parse(oreader["IVA"].ToString());
                            registro.ImpuestoID = int.Parse(oreader["IMPUESTO_ID"].ToString());
                            registro.DescuentoID = int.Parse(oreader["DESCUENTO_ID"].ToString());
                            registro.PrecioCosto = decimal.Parse(oreader["PRECIO_COSTO"].ToString());
                            registro.PaqueteID = int.Parse(oreader["PAQUETE_ID"].ToString());

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

        public static bool ActualizaPedido(SIFModelo.Pedido modelo)
        {
            string sentencia = "sp_upd_pedido";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("esucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("enum_pedido", modelo.NumeroPedido);
                    cmd.Parameters.Add("etipo_cliente_id", modelo.TipoClienteID);
                    cmd.Parameters.Add("ecliente_id", modelo.ClienteID);
                    cmd.Parameters.Add("efecha_pedido", modelo.FechaPedido);
                    cmd.Parameters.Add("ereceta", System.Convert.ToChar(modelo.Receta));
                    cmd.Parameters.Add("emedico_id", modelo.MedicoID);
                    cmd.Parameters.Add("efec_remision_vta", modelo.FechaRemisionVenta);
                    cmd.Parameters.Add("eref_remision_vta", modelo.ReferenciaRemisionVenta);
                    cmd.Parameters.Add("evendedor_id", modelo.VendedorID);
                    cmd.Parameters.Add("emoneda_id", modelo.MonedaID);
                    cmd.Parameters.Add("etipo_cambio_id", modelo.TipoCambioID);
                    cmd.Parameters.Add("esubtotal", modelo.SubTotal);
                    cmd.Parameters.Add("eimpuesto_iva", modelo.ImpuestoIVA);
                    cmd.Parameters.Add("edescuento", modelo.Descuento);
                    cmd.Parameters.Add("enum_credencial", modelo.NumeroCredencial);
                    cmd.Parameters.Add("etotal", modelo.Total);
                    cmd.Parameters.Add("etot_articulos_pedido", modelo.TotalArticulosPedido);
                    cmd.Parameters.Add("eactivo", System.Convert.ToChar(modelo.Activo));
                    cmd.Parameters.Add("eimporte_letra", modelo.ImporteLetra);
                    cmd.Parameters.Add("efactura", System.Convert.ToChar(modelo.Factura));
                    cmd.Parameters.Add("etipo_pago_id", modelo.TipoPagoID);
                    cmd.Parameters.Add("ecomentario", modelo.Comentario);
                    cmd.Parameters.Add("etotal_pago", modelo.TotalPago);


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


        public static bool Inserta(SIFModelo.Pedido modelo)
        {
            string sentencia = "sp_ins_pedido";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("num_pedido", modelo.NumeroPedido);
                    cmd.Parameters.Add("tipo_cliente_id", modelo.TipoClienteID);
                    cmd.Parameters.Add("cliente_id", modelo.ClienteID);
                    cmd.Parameters.Add("fecha_pedido", modelo.FechaPedido);
                    cmd.Parameters.Add("receta", System.Convert.ToChar(modelo.Receta));
                    cmd.Parameters.Add("medico_id", modelo.MedicoID);
                    cmd.Parameters.Add("fec_remision_vta", modelo.FechaRemisionVenta);
                    cmd.Parameters.Add("ref_remision_vta", modelo.ReferenciaRemisionVenta);
                    cmd.Parameters.Add("vendedor_id", modelo.VendedorID);
                    cmd.Parameters.Add("moneda_id", modelo.MonedaID);
                    cmd.Parameters.Add("tipo_cambio_id", modelo.TipoCambioID);
                    cmd.Parameters.Add("subtotal", modelo.SubTotal);
                    cmd.Parameters.Add("impuesto_iva", modelo.ImpuestoVenta);
                    cmd.Parameters.Add("descuento", modelo.Descuento);
                    cmd.Parameters.Add("num_credencial", modelo.NumeroCredencial);
                    cmd.Parameters.Add("total", modelo.Total);
                    cmd.Parameters.Add("tot_articulos_pedido", modelo.TotalArticulosPedido);
                    cmd.Parameters.Add("importe_letra", modelo.ImporteLetra);
                    cmd.Parameters.Add("tipo_pago_id", modelo.TipoPagoID);
                    cmd.Parameters.Add("total_pago", modelo.TotalPago);
                    cmd.Parameters.Add("factura", System.Convert.ToChar(modelo.Factura));
                    cmd.Parameters.Add("comentario", modelo.Comentario);
                    //cmd.Parameters.Add("tipo_cotizacion", System.Convert.ToChar(modelo.TipoCotizacion));

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

        public static bool Inserta(SIFModelo.Pedido modelo, List<SIFModelo.PedidoDetalle> detalles)
        {
            string sentencia = "PKG_VENTAS.sp_ins_pedido";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("p_sucursal_id", OracleDbType.Decimal,  modelo.SucursalID, ParameterDirection.Input );
                    cmd.Parameters.Add("p_num_pedido", OracleDbType.Varchar2,   modelo.NumeroPedido, ParameterDirection.Input);
                    cmd.Parameters.Add("p_tipo_cliente_id", OracleDbType.Decimal, modelo.TipoClienteID, ParameterDirection.Input);
                    cmd.Parameters.Add("p_cliente_id", OracleDbType.Decimal, modelo.ClienteID, ParameterDirection.Input);
                    //cmd.Parameters.Add("fecha_pedido", modelo.FechaPedido);
                    cmd.Parameters.Add("p_receta", OracleDbType.Char, System.Convert.ToChar(modelo.Receta).ToString(), ParameterDirection.Input);
                    cmd.Parameters.Add("p_id_medico", OracleDbType.Decimal, modelo.MedicoID, ParameterDirection.Input);
                    //cmd.Parameters.Add("fec_remision_vta", modelo.FechaRemisionVenta);
                    //cmd.Parameters.Add("ref_remision_vta", modelo.ReferenciaRemisionVenta);
                    cmd.Parameters.Add("p_vendedor_id", OracleDbType.Decimal, modelo.VendedorID, ParameterDirection.Input);
                    cmd.Parameters.Add("p_moneda_id", OracleDbType.Decimal,  modelo.MonedaID , ParameterDirection.Input);
                    cmd.Parameters.Add("p_tipo_cambio_id", OracleDbType.Decimal, modelo.TipoCambioID, ParameterDirection.Input);
                    cmd.Parameters.Add("p_subtotal",OracleDbType.Decimal,  modelo.SubTotal, ParameterDirection.Input);
                    cmd.Parameters.Add("p_impuesto_iva",OracleDbType.Decimal, modelo.ImpuestoVenta, ParameterDirection.Input);
                    cmd.Parameters.Add("p_descuento",OracleDbType.Decimal, modelo.Descuento, ParameterDirection.Input);
                    cmd.Parameters.Add("p_num_credencial",OracleDbType.Varchar2, modelo.NumeroCredencial, ParameterDirection.Input);
                    cmd.Parameters.Add("p_total", OracleDbType.Decimal, modelo.Total, ParameterDirection.Input);
                    cmd.Parameters.Add("p_tot_art_pedido", OracleDbType.Decimal, modelo.TotalArticulosPedido, ParameterDirection.Input);
                    cmd.Parameters.Add("p_importe_letra", OracleDbType.Varchar2, modelo.ImporteLetra, ParameterDirection.Input);
                    cmd.Parameters.Add("p_factura", OracleDbType.Char, ((char)modelo.Factura).ToString(), ParameterDirection.Input);
                    cmd.Parameters.Add("p_tipo_pago_id", OracleDbType.Decimal, modelo.TipoPagoID, ParameterDirection.Input);
                    cmd.Parameters.Add("p_total_pago", OracleDbType.Decimal, modelo.TotalPago, ParameterDirection.Input);
                    cmd.Parameters.Add("p_comentario", OracleDbType.Varchar2, modelo.Comentario, ParameterDirection.Input);

                    //cmd.Parameters.Add("total_pago", modelo.TotalPago);
                    //cmd.Parameters.Add("factura", System.Convert.ToChar(modelo.Factura));
                    //cmd.Parameters.Add("comentario", modelo.Comentario);
                    //cmd.Parameters.Add("tipo_cotizacion", System.Convert.ToChar(modelo.TipoCotizacion));

                    //ARRAY
                    List<decimal> Lnum_partida = new List<decimal>();
                    List<string> L_articulo_id = new List<string>();
                    List<string> L_nombre1 = new List<string>();
                    List<string> L_nombre2 = new List<string>();
                    List<decimal> l_cant_pedido = new List<decimal>();
                    List<decimal> l_precio = new List<decimal>();
                    List<decimal> l_iva = new List<decimal>();
                    List<decimal> L_impuesto_id = new List<decimal>();
                    List<decimal> L_descuento_id = new List<decimal>();
                    List<decimal> L_precio_costo = new List<decimal>();
                    List<decimal> L_paquete_id = new List<decimal>();

                    foreach (SIFModelo.PedidoDetalle detalle in detalles)
                    {
                        Lnum_partida.Add(detalle.NumeroPartida);
                        L_articulo_id.Add(detalle.ArticuloID);
                        L_nombre1.Add(detalle.Nombre1);
                        L_nombre2.Add(detalle.Nombre2);
                        l_cant_pedido.Add(detalle.CantidadPedido);
                        l_precio.Add(detalle.Precio);
                        l_iva.Add(detalle.IVA);
                        L_impuesto_id.Add(detalle.ImpuestoID);
                        L_descuento_id.Add(detalle.DescuentoID);
                        L_precio_costo.Add(detalle.PrecioCosto);
                        L_paquete_id.Add(detalle.PaqueteID);

                    }

                    OracleParameter pnum_partida = cmd.Parameters.Add("p_num_partida", OracleDbType.Decimal);
                    pnum_partida.Direction = ParameterDirection.Input;
                    pnum_partida.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pnum_partida.Value = Lnum_partida.ToArray();

                    OracleParameter p_articulo_id = cmd.Parameters.Add("p_articulo_id", OracleDbType.Varchar2);
                    p_articulo_id.Direction = ParameterDirection.Input;
                    p_articulo_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_articulo_id.Value = L_articulo_id.ToArray();

                    OracleParameter p_nombre1 = cmd.Parameters.Add("p_nombre1", OracleDbType.Varchar2);
                    p_nombre1.Direction = ParameterDirection.Input;
                    p_nombre1.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_nombre1.Value = L_nombre1.ToArray();
                    
                    OracleParameter p_nombre2 = cmd.Parameters.Add("p_nombre2", OracleDbType.Varchar2);
                    p_nombre2.Direction = ParameterDirection.Input;
                    p_nombre2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_nombre2.Value = L_nombre2.ToArray();

                    OracleParameter p_cant_pedido = cmd.Parameters.Add("p_cant_pedido", OracleDbType.Decimal);
                    p_cant_pedido.Direction = ParameterDirection.Input;
                    p_cant_pedido.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_cant_pedido.Value = l_cant_pedido.ToArray();

                    OracleParameter p_precio = cmd.Parameters.Add("p_precio", OracleDbType.Decimal);
                    p_precio.Direction = ParameterDirection.Input;
                    p_precio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_precio.Value = l_precio.ToArray();

                    OracleParameter p_iva = cmd.Parameters.Add("p_iva", OracleDbType.Decimal);
                    p_iva.Direction = ParameterDirection.Input;
                    p_iva.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_iva.Value = l_iva.ToArray();

                    OracleParameter p_impuesto_id = cmd.Parameters.Add("p_impuesto_id", OracleDbType.Decimal);
                    p_impuesto_id.Direction = ParameterDirection.Input;
                    p_impuesto_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_impuesto_id.Value = L_impuesto_id.ToArray();

                    OracleParameter p_descuento_id = cmd.Parameters.Add("p_descuento_id", OracleDbType.Decimal);
                    p_descuento_id.Direction = ParameterDirection.Input;
                    p_descuento_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_descuento_id.Value = L_descuento_id.ToArray();

                    OracleParameter p_precio_costo = cmd.Parameters.Add("p_precio_costo", OracleDbType.Decimal);
                    p_precio_costo.Direction = ParameterDirection.Input;
                    p_precio_costo.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_precio_costo.Value = L_precio_costo.ToArray();

                    OracleParameter p_paquete_id = cmd.Parameters.Add("p_paquete_id", OracleDbType.Decimal);
                    p_paquete_id.Direction = ParameterDirection.Input;
                    p_paquete_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_paquete_id.Value = L_paquete_id.ToArray();


                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("OutParam", OracleDbType.Int32);
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

        public static bool InsertaDetalle(SIFModelo.PedidoDetalle modelo)
        {
            string sentencia = "sp_ins_pedido_det";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("num_Pedido", modelo.NumeroPedido);
                    cmd.Parameters.Add("num_partida", modelo.NumeroPartida);
                    cmd.Parameters.Add("articulo_id", modelo.ArticuloID);
                    cmd.Parameters.Add("nombre1", modelo.Nombre1);
                    cmd.Parameters.Add("nombre2", modelo.Nombre2);
                    cmd.Parameters.Add("cant_pedido", modelo.CantidadPedido);
                    cmd.Parameters.Add("precio", modelo.Precio);
                    cmd.Parameters.Add("iva", modelo.IVA);
                    cmd.Parameters.Add("impuesto_id", modelo.ImpuestoID);
                    cmd.Parameters.Add("descuento_id", modelo.DescuentoID);
                    cmd.Parameters.Add("precio_costo", modelo.PrecioCosto);
                    cmd.Parameters.Add("paquete_id", modelo.PaqueteID);

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
        public static int NumeroPedidoF(int sucursalId, string prefijoFolio)
        {
            object id;
            string sentencia = "SELECT NVL(COUNT(NUM_PEDIDO),0) + 1 FROM PEDIDO WHERE  sucursal_id = :sucursalID";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("sucursalID", sucursalId);
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
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }
            return int.Parse(id.ToString());
        }
        public static int NumeroPedido(int sucursalId, string prefijoFolio)
        {
            object id;
            string sentencia = "SELECT NVL(COUNT(NUM_PEDIDO),0) + 1 FROM PEDIDO WHERE TO_CHAR( fecha_pedido,'YY') = :prefijoFolio AND sucursal_id = :sucursalID";
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

        public static DataSet PedidosNoGenerados(SIFModelo.Sucursal sucursal, SIFModelo.Pedido pedido, bool todos, DateTime fecha1, DateTime fecha2)
        {

            string sentencia = "";
            DataSet ds = new DataSet("DSPedidos");
            ds.Tables.Add("Pedidos");
            /* if (todos)
                sentencia = "select NUM_PEDIDO AS FOLIO, fecha_pedido as FECHA, (SELECT NOMBRE FROM CAT_USUARIOS WHERE CAT_USUARIOS.USUARIOS_ID=VENDEDOR_ID) AS ASESOR, (SELECT NOMBRE || ' ' || APE_PATERNO || ' ' || APE_MATERNO  FROM CAT_CLIENTES WHERE CAT_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID) AS NOMBRE, (Select COLONIA FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID AND TIPO_DIR='CA') AS COLONIA, (Select MUNICIPIO FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID AND TIPO_DIR='CA') AS MUNICIPIO," +
                            " COMENTARIO,FACTURA,RECETA,TOT_ARTICULOS_PEDIDO AS NO_TOTAL_ARTICULOS,(SELECT NOMBRE FROM CAT_TIPO_PAGO WHERE CAT_TIPO_PAGO.TIPO_PAGO_ID=PEDIDO.TIPO_PAGO_ID) AS FORMA_PAGO, TOTAL, TOTAL_PAGO AS PAGO,TOTAL_PAGO-TOTAL AS CAMBIO " +
                            ",* from pedido WHERE  sucursal_id = :SucursalId AND NUM_PEDIDO LIKE :NumeroPedido AND pedido.activo = 'S' "; //AND REF_REMISION_VTA IS NULL
            else
                sentencia = "select NUM_PEDIDO AS FOLIO, fecha_PEdido as FECHA, (SELECT NOMBRE FROM CAT_USUARIOS WHERE CAT_USUARIOS.USUARIOS_ID=VENDEDOR_ID) AS ASESOR, (SELECT NOMBRE || ' ' || APE_PATERNO || ' ' || APE_MATERNO  FROM CAT_CLIENTES WHERE CAT_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID) AS NOMBRE, (Select COLONIA FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID AND TIPO_DIR='CA') AS COLONIA,(Select MUNICIPIO FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID AND TIPO_DIR='CA') AS MUNICIPIO, " +
                            " COMENTARIO,FACTURA,RECETA,TOT_ARTICULOS_PEDIDO AS NO_TOTAL_ARTICULOS,(SELECT NOMBRE FROM CAT_TIPO_PAGO WHERE CAT_TIPO_PAGO.TIPO_PAGO_ID=PEDIDO.TIPO_PAGO_ID) AS FORMAPAGO, TOTAL, TOTAL_PAGO AS PAGO,TOTAL_PAGO-TOTAL AS CAMBIO " +
                            ",* from pedido WHERE  sucursal_id = :SucursalId AND NUM_PEDIDO LIKE :NumeroPedido  AND REF_REMISION_VTA IS NULL AND pedido.activo = 'S' "; //
  ORIGINAL VMJA 26022015 */
            if (todos)
                sentencia = "select NUM_PEDIDO AS FOLIO, fecha_pedido as FECHA, (SELECT NOMBRE FROM CAT_USUARIOS WHERE CAT_USUARIOS.USUARIOS_ID=VENDEDOR_ID) AS ASESOR, (SELECT NOMBRE || ' ' || APE_PATERNO || ' ' || APE_MATERNO  FROM CAT_CLIENTES WHERE CAT_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID) AS NOMBRE, (Select COLONIA FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID AND TIPO_DIR='CA') AS COLONIA, (Select MUNICIPIO FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID AND TIPO_DIR='CA') AS MUNICIPIO," +
                            " COMENTARIO,FACTURA,RECETA,TOT_ARTICULOS_PEDIDO AS NO_TOTAL_ARTICULOS,(SELECT NOMBRE FROM CAT_TIPO_PAGO WHERE CAT_TIPO_PAGO.TIPO_PAGO_ID=PEDIDO.TIPO_PAGO_ID) AS FORMA_PAGO, TOTAL, TOTAL_PAGO AS PAGO,TOTAL_PAGO-TOTAL AS CAMBIO,TO_CHAR(FEC_REMISION_VTA, 'DD/MM/yyyy hh24:mi:ss') AS FECHA_REMISION, REF_REMISION_VTA AS REMISION_VTA ,(SELECT NOMBRE FROM CAT_SUCURSALES WHERE CAT_SUCURSALES.SUCURSALES_ID=PEDIDO.SUCURSAL_ID) AS SUCURSAL " +
                            " ,* from pedido WHERE  NUM_PEDIDO LIKE :NumeroPedido AND pedido.activo = 'S' "; //AND REF_REMISION_VTA IS NULL
            else
                sentencia = "select NUM_PEDIDO AS FOLIO, fecha_PEdido as FECHA, (SELECT NOMBRE FROM CAT_USUARIOS WHERE CAT_USUARIOS.USUARIOS_ID=VENDEDOR_ID) AS ASESOR, (SELECT NOMBRE || ' ' || APE_PATERNO || ' ' || APE_MATERNO  FROM CAT_CLIENTES WHERE CAT_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID) AS NOMBRE, (Select COLONIA FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID AND TIPO_DIR='CA') AS COLONIA,(Select MUNICIPIO FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=PEDIDO.CLIENTE_ID AND TIPO_DIR='CA') AS MUNICIPIO, " +
                            " COMENTARIO,FACTURA,RECETA,TOT_ARTICULOS_PEDIDO AS NO_TOTAL_ARTICULOS,(SELECT NOMBRE FROM CAT_TIPO_PAGO WHERE CAT_TIPO_PAGO.TIPO_PAGO_ID=PEDIDO.TIPO_PAGO_ID) AS FORMAPAGO, TOTAL, TOTAL_PAGO AS PAGO,TOTAL_PAGO-TOTAL AS CAMBIO,TO_CHAR(FEC_REMISION_VTA, 'DD/MM/yyyy hh24:mi:ss')  AS FECHA_REMISION,  REF_REMISION_VTA AS REMISION_VTA , (SELECT NOMBRE FROM CAT_SUCURSALES WHERE CAT_SUCURSALES.SUCURSALES_ID=PEDIDO.SUCURSAL_ID) AS SUCURSAL" +
                            " ,* from pedido WHERE  NUM_PEDIDO LIKE :NumeroPedido  AND REF_REMISION_VTA IS NULL AND pedido.activo = 'S' "; //

            sentencia += " AND fecha_pedido >= TO_DATE('" + fecha1.ToString("yyyy/MM/dd 00:00:00") + "','YYYY/MM/DD HH24:MI:SS') AND fecha_pedido <= TO_DATE('" + fecha2.ToString("yyyy/MM/dd 23:59:59") + "','YYYY/MM/DD HH24:MI:SS')";
            sentencia += " ORDER BY NUM_PEDIDO DESC"; 
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);ORIGINAL VMJA 26022015
                    cmd.Parameters.Add("NumeroPedido", "%" + pedido.NumeroPedido + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Pedidos");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            ds.Tables.Add("PedidoDetalles");
            /*   string sentenciaDetalles = " select num_pedido as folio, articulo_id as codigo,nombre1,cant_pedido as NoPiezas,(select ubicacion from inventario where inventario.articulo_id=pedido_det.articulo_id and inventario.sucursal_id=pedido_det.sucursal_id) as ubicacion, " +
                                       " (select tipo_medicamento_cve from cat_articulos where cat_articulos.articulo_id=pedido_det.articulo_id) as Tipo,precio*cant_pedido as Total " +
                                       ",* FROM PEDIDO_DET WHERE sucursal_id = :SucursalId AND NUM_PEDIDO in (SELECT NUM_PEDIDO FROM pedido WHERE  sucursal_id = :SucursalesId AND NUM_PEDIDO LIKE :NumeroPedido  )  "; //AND REF_REMISION_VTA IS NULL
ORIGINAL VMJA 26022015*/
            string sentenciaDetalles = " select num_pedido as folio, articulo_id as codigo,nombre1,cant_pedido as NoPiezas,(select ubicacion from inventario where inventario.articulo_id=pedido_det.articulo_id) as ubicacion, " +
                                       " (select tipo_medicamento_cve from cat_articulos where cat_articulos.articulo_id=pedido_det.articulo_id) as Tipo,precio*cant_pedido as Total " +
                                       ",* FROM PEDIDO_DET WHERE  NUM_PEDIDO in (SELECT NUM_PEDIDO FROM pedido WHERE  NUM_PEDIDO LIKE :NumeroPedido  )  "; //AND REF_REMISION_VTA IS NULL

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                {
                   /* cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("SucursalesId", sucursal.SucursalesID); ORIGINAL 26022015*/
                    cmd.Parameters.Add("NumeroPedido", "%" + pedido.NumeroPedido + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "PedidoDetalles");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            return ds;
        }

        /// <summary>
        /// AVM 10-04-2015
        /// consulta los pedidos por la fecha actual
        /// </summary>
        /// <param name="toDay"></param> la fecha actual
        /// <returns></returns>
        public static Boolean PedidosLimiteHoy(String toDay,SIFModelo.MotivoPedido MotivoPedido)
        {
            string sentencia = "SELECT FOLIO " +
                               "FROM PEDIDO_TRASP " +
                               "WHERE TO_DATE(FECHA_PED, 'DD/MM/YY') = TO_DATE(:toDay, 'DD/MM/YY') " +
                                "AND ID_MOTIVO_PEDIDO = :idMotivoPedido AND ACTIVO != 'X' GROUP BY FOLIO";                   //'09/04/15'
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Parameters.Add("toDay", toDay);
                        cmd.Parameters.Add("idMotivoPedido", MotivoPedido.ID);
                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        int ra = oreader.RecordsAffected;
                        long rz = oreader.RowSize;
                        int hf = oreader.HiddenFieldCount;
                        int contador = 0;
                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                contador++;
                            }
                            if (contador >= MotivoPedido.CANTIDAD_PEDIDO_MAX_DIA)
                                return true;
                        }
                    }
                }
                catch
                {

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
            return false;
        }
    }
}
