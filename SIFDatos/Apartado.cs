using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace SIFDatos
{
    public class Apartado
    {
        public static DataSet ApartadosNoGenerados(SIFModelo.Sucursal sucursal, SIFModelo.Apartado Apartado,Boolean todos)
        {   string sentencia;
            DataSet ds = new DataSet("DSApartados");
            ds.Tables.Add("Apartado");
            if (todos)
                sentencia = " select NUM_APARTADO AS FOLIO, fecha_APARTADO as FECHA, (SELECT NOMBRE FROM CAT_USUARIOS WHERE CAT_USUARIOS.USUARIOS_ID=VENDEDOR_ID) AS ASESOR, (SELECT  NOMBRE || ' ' || APE_PATERNO || ' ' || APE_MATERNO FROM CAT_CLIENTES WHERE CAT_CLIENTES.CLIENTES_ID=APARTADO.CLIENTE_ID) AS NOMBRE, (Select COLONIA FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=APARTADO.CLIENTE_ID AND TIPO_DIR='CA') AS COLONIA, " +
                            " COMENTARIO,FACTURA,RECETA,TOT_ART_APARTADO AS NO_TOTAL_ARTICULOS, TOTAL, ANTICIPO_APART AS ANTICIPO " +
                            ", * FROM APARTADO WHERE  sucursal_id = :SucursalId AND NUM_APARTADO LIKE :NumeroApartado  ORDER BY NUM_APARTADO DESC"; //AND REF_REMISION_VTA IS NULL
            else
                sentencia = " select NUM_APARTADO AS FOLIO, fecha_APARTADO as FECHA, (SELECT NOMBRE FROM CAT_USUARIOS WHERE CAT_USUARIOS.USUARIOS_ID=VENDEDOR_ID) AS ASESOR, (SELECT  NOMBRE || ' ' || APE_PATERNO || ' ' || APE_MATERNO FROM CAT_CLIENTES WHERE CAT_CLIENTES.CLIENTES_ID=APARTADO.CLIENTE_ID) AS NOMBRE, (Select COLONIA FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=APARTADO.CLIENTE_ID AND TIPO_DIR='CA') AS COLONIA, " +
                            " COMENTARIO,FACTURA,RECETA,TOT_ART_APARTADO AS NO_TOTAL_ARTICULOS, TOTAL, ANTICIPO_APART AS ANTICIPO " +
                            ",* FROM APARTADO WHERE ACTIVO = 'S' AND sucursal_id = :SucursalId AND NUM_APARTADO LIKE :NumeroApartado AND REF_REMISION_VTA IS NULL ORDER BY NUM_APARTADO DESC"; //

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroApartado", "%" + Apartado.NumeroApartado + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Apartado");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            ds.Tables.Add("ApartadoDetalle");
            string sentenciaDetalles = " select num_APARTADO as folio, articulo_id as codigo,nombre1,cant_APARTADO as NoPiezas,(select ubicacion from inventario where inventario.articulo_id=APARTADO_DET.articulo_id and inventario.sucursal_id=APARTADO_DET.sucursal_id) as ubicacion, " +
                                       " (select tipo_medicamento_cve from cat_articulos where cat_articulos.articulo_id=APARTADO_DET.articulo_id) as Tipo,precio*cant_APARTADO as Total " +
                                       ", * FROM APARTADO_DET WHERE sucursal_id = :SucursalId AND NUM_APARTADO in (SELECT NUM_APARTADO FROM APARTADO WHERE  sucursal_id = :SucursalesId AND NUM_APARTADO LIKE :NumeroApartado AND REF_REMISION_VTA IS NULL )  ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                {
                    cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("SucursalesId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroApartado", "%" + Apartado.NumeroApartado + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "ApartadoDetalle");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    
                   //OracleConnection.ClearPool(cnx);
                }

            }

            return ds;
        }

        public static DataSet ApartadosNoGenerados(SIFModelo.Sucursal sucursal, SIFModelo.Apartado Apartado, Boolean todos, DateTime fecha1, DateTime fecha2)
        {
            string sentencia;
            DataSet ds = new DataSet("DSApartados");
            ds.Tables.Add("Apartado");
            if (todos)
                sentencia = " select NUM_APARTADO AS FOLIO, fecha_APARTADO as FECHA, (SELECT NOMBRE FROM CAT_USUARIOS WHERE CAT_USUARIOS.USUARIOS_ID=VENDEDOR_ID) AS ASESOR, (SELECT  NOMBRE || ' ' || APE_PATERNO || ' ' || APE_MATERNO FROM CAT_CLIENTES WHERE CAT_CLIENTES.CLIENTES_ID=APARTADO.CLIENTE_ID) AS NOMBRE, (Select COLONIA FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=APARTADO.CLIENTE_ID AND TIPO_DIR='CA') AS COLONIA, " +
                            " COMENTARIO,FACTURA,RECETA,TOT_ART_APARTADO AS NO_TOTAL_ARTICULOS, TOTAL, ANTICIPO_APART AS ANTICIPO " +
                            ", * FROM APARTADO WHERE  sucursal_id = :SucursalId AND NUM_APARTADO LIKE :NumeroApartado "; //AND REF_REMISION_VTA IS NULL
            else
                sentencia = " select NUM_APARTADO AS FOLIO, fecha_APARTADO as FECHA, (SELECT NOMBRE FROM CAT_USUARIOS WHERE CAT_USUARIOS.USUARIOS_ID=VENDEDOR_ID) AS ASESOR, (SELECT  NOMBRE || ' ' || APE_PATERNO || ' ' || APE_MATERNO FROM CAT_CLIENTES WHERE CAT_CLIENTES.CLIENTES_ID=APARTADO.CLIENTE_ID) AS NOMBRE, (Select COLONIA FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=APARTADO.CLIENTE_ID AND TIPO_DIR='CA') AS COLONIA, " +
                            " COMENTARIO,FACTURA,RECETA,TOT_ART_APARTADO AS NO_TOTAL_ARTICULOS, TOTAL, ANTICIPO_APART AS ANTICIPO " +
                            ",* FROM APARTADO WHERE ACTIVO = 'S' AND sucursal_id = :SucursalId AND NUM_APARTADO LIKE :NumeroApartado AND REF_REMISION_VTA IS NULL "; //

            sentencia += " AND fecha_APARTADO >= TO_DATE('" + fecha1.ToString("yyyy/MM/dd 00:00:00") + "','YYYY/MM/DD HH24:MI:SS') AND fecha_APARTADO <= TO_DATE('" + fecha2.ToString("yyyy/MM/dd 23:59:59") + "','YYYY/MM/DD HH24:MI:SS')";

            sentencia += " ORDER BY NUM_APARTADO DESC";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroApartado", "%" + Apartado.NumeroApartado + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Apartado");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            ds.Tables.Add("ApartadoDetalle");
            string sentenciaDetalles = " select num_APARTADO as folio, articulo_id as codigo,nombre1,cant_APARTADO as NoPiezas,(select ubicacion from inventario where inventario.articulo_id=APARTADO_DET.articulo_id and inventario.sucursal_id=APARTADO_DET.sucursal_id) as ubicacion, " +
                                       " (select tipo_medicamento_cve from cat_articulos where cat_articulos.articulo_id=APARTADO_DET.articulo_id) as Tipo,precio*cant_APARTADO as Total " +
                                       ", * FROM APARTADO_DET WHERE sucursal_id = :SucursalId AND NUM_APARTADO in (SELECT NUM_APARTADO FROM APARTADO WHERE  sucursal_id = :SucursalesId AND NUM_APARTADO LIKE :NumeroApartado AND REF_REMISION_VTA IS NULL )  ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                {
                    cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("SucursalesId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroApartado", "%" + Apartado.NumeroApartado + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "ApartadoDetalle");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            return ds;
        }

        public static bool Cancela(SIFModelo.Apartado Apartado)
        {
            throw new NotImplementedException();
        }

        public static List<SIFModelo.ApartadoDetalle> CargaDetalles(SIFModelo.Apartado Apartado)
        {
            List<SIFModelo.ApartadoDetalle> rows = new List<SIFModelo.ApartadoDetalle>();

            string sentencia = "SELECT * FROM APARTADO_DET WHERE sucursal_id = :SucursalId AND NUM_APARTADO = :NumApartado";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalId", Apartado.SucursalID);
                    cmd.Parameters.Add("NumApartado", Apartado.NumeroApartado);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.ApartadoDetalle registro = new SIFModelo.ApartadoDetalle();

                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.NumeroApartado = oreader["NUM_APARTADO"].ToString();
                            registro.NumeroPartida = int.Parse(oreader["NUM_PARTIDA"].ToString());
                            registro.ArticuloID = oreader["ARTICULO_ID"].ToString();
                            registro.Nombre1 = oreader["NOMBRE1"].ToString();
                            registro.Nombre2 = oreader["NOMBRE2"].ToString();
                            registro.CantidadApartado = int.Parse(oreader["CANT_APARTADO"].ToString());
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

        public static bool ActualizaApartado(SIFModelo.Apartado modelo)
        {
            string sentencia = "sp_upd_Apartado";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("esucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("enum_apartado", modelo.NumeroApartado);
                    cmd.Parameters.Add("etipo_cliente_id", modelo.TipoClienteID);
                    cmd.Parameters.Add("ecliente_id", modelo.ClienteID);
                    cmd.Parameters.Add("efecha_apartado", modelo.FechaApartado);
                    cmd.Parameters.Add("efec_confirm_apartado", modelo.FechaConfirmaApartado);
                    cmd.Parameters.Add("ereceta", System.Convert.ToChar(modelo.Receta));
                    cmd.Parameters.Add("eid_medico", modelo.MedicoID);
                    cmd.Parameters.Add("efec_remision_vta", modelo.FechaRemisionVenta);
                    cmd.Parameters.Add("eref_remision_vta", modelo.ReferenciaRemisionVenta);
                    cmd.Parameters.Add("evendedor_id", modelo.VendedorID);
                    cmd.Parameters.Add("evendedor_id_confirm", modelo.VendedorID);
                    cmd.Parameters.Add("emoneda_id", modelo.MonedaID);
                    cmd.Parameters.Add("etipo_cambio_id", modelo.TipoCambioID);
                    cmd.Parameters.Add("esubtotal", modelo.SubTotal);
                    cmd.Parameters.Add("eimpuesto_iva", modelo.ImpuestoIVA);
                    cmd.Parameters.Add("edescuento", modelo.Descuento);
                    cmd.Parameters.Add("enum_credencial", modelo.NumeroCredencial);
                    cmd.Parameters.Add("etotal", modelo.Total);
                    cmd.Parameters.Add("etot_art_apartado", modelo.TotalArticulos);
                    cmd.Parameters.Add("eactivo", System.Convert.ToChar(modelo.Activo));
                    cmd.Parameters.Add("eimporte_letra", modelo.ImporteLetra);
                    cmd.Parameters.Add("efactura", System.Convert.ToChar(modelo.Factura));
                    cmd.Parameters.Add("ecomentario",modelo.Comentario);
                    cmd.Parameters.Add("eanticipo_apart",modelo.Anticipo);
                    

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

        public static bool Inserta(SIFModelo.Apartado modelo)
        {
            string sentencia = "sp_ins_apartado";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("num_apartado", modelo.NumeroApartado);
                    cmd.Parameters.Add("tipo_cliente_id", modelo.TipoClienteID);
                    cmd.Parameters.Add("cliente_id", modelo.ClienteID);
                    cmd.Parameters.Add("fecha_apartado", modelo.FechaApartado);
                    cmd.Parameters.Add("fec_confirm_apartado", modelo.FechaConfirmaApartado);
                    cmd.Parameters.Add("receta", System.Convert.ToChar(modelo.Receta));
                    cmd.Parameters.Add("id_medico", modelo.MedicoID);
                    cmd.Parameters.Add("fec_remision_vta", modelo.FechaRemisionVenta);
                    cmd.Parameters.Add("ref_remision_vta", modelo.ReferenciaRemisionVenta);
                    cmd.Parameters.Add("vendedor_id", modelo.VendedorID);
                    cmd.Parameters.Add("vendedor_id_confirm", modelo.VendedorID);
                    cmd.Parameters.Add("moneda_id", modelo.MonedaID);
                    cmd.Parameters.Add("tipo_cambio_id", modelo.TipoCambioID);
                    cmd.Parameters.Add("subtotal", modelo.SubTotal);
                    cmd.Parameters.Add("impuesto_iva", modelo.ImpuestoVenta);
                    cmd.Parameters.Add("descuento", modelo.Descuento);
                    cmd.Parameters.Add("num_credencial", modelo.NumeroCredencial);
                    cmd.Parameters.Add("total", modelo.Total);
                    cmd.Parameters.Add("tot_art_apartado", modelo.TotalArticulos);
                    cmd.Parameters.Add("activo", System.Convert.ToChar(modelo.Activo));
                    cmd.Parameters.Add("importe_letra", modelo.ImporteLetra);
                    cmd.Parameters.Add("anticipo_apart", modelo.Anticipo);
                    cmd.Parameters.Add("factura", System.Convert.ToChar(modelo.Factura));
                    cmd.Parameters.Add("comentario", modelo.Comentario);
                   // cmd.Parameters.Add("tipo_cotizacion", System.Convert.ToChar(modelo.TipoCotizacion));

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




        public static bool InsertaDetalle(SIFModelo.ApartadoDetalle modelo)
        {
            string sentencia = "sp_ins_apartado_det";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("num_apartado", modelo.NumeroApartado);
                    cmd.Parameters.Add("num_partida", modelo.NumeroPartida);
                    cmd.Parameters.Add("articulo_id", modelo.ArticuloID);
                    cmd.Parameters.Add("nombre1", modelo.Nombre1);
                    cmd.Parameters.Add("nombre2", modelo.Nombre2);
                    cmd.Parameters.Add("cant_apartado", modelo.CantidadApartado);
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
        
        
        
        
        public static int NumeroApartado(int sucursalId, string prefijoFolio)
        {
            object id;
            string sentencia = "SELECT NVL(COUNT(num_apartado),0) + 1 FROM APARTADO WHERE TO_CHAR( fecha_apartado,'YY') = :prefijoFolio AND sucursal_id = :sucursalID";
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

        public static IEnumerable<SIFModelo.Apartado> ApartadoPendientes24hrs(SIFModelo.Sucursal sucursal)
        {
            throw new NotImplementedException();
        }

        public static bool InsertaBulk(SIFModelo.Apartado modelo, List<SIFModelo.ApartadoDetalle> detalles)
        {
            string sentencia = "PKG_VENTAS.sp_ins_apartado";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("p_sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("p_num_apartado", modelo.NumeroApartado);
                    cmd.Parameters.Add("p_tipo_cliente_id", modelo.TipoClienteID);
                    cmd.Parameters.Add("p_cliente_id", modelo.ClienteID);

                    cmd.Parameters.Add("p_receta", System.Convert.ToChar(modelo.Receta));
                    cmd.Parameters.Add("p_id_medico", modelo.MedicoID);
                    cmd.Parameters.Add("p_vendedor_id", modelo.VendedorID);

                    cmd.Parameters.Add("p_moneda_id", modelo.MonedaID);
                    cmd.Parameters.Add("p_tipo_cambio_id", modelo.TipoCambioID);
                    cmd.Parameters.Add("p_subtotal ", modelo.SubTotal);
                    cmd.Parameters.Add("p_impuesto_iva", modelo.ImpuestoVenta);
                    cmd.Parameters.Add("p_descuento", modelo.Descuento);
                    cmd.Parameters.Add("p_num_credencial", modelo.NumeroCredencial);
                    cmd.Parameters.Add("p_total", modelo.Total);
                    cmd.Parameters.Add("p_tot_art_apartado", modelo.TotalArticulos);
                    cmd.Parameters.Add("p_activo", System.Convert.ToChar(modelo.Activo).ToString());
                    cmd.Parameters.Add("p_importe_letra", modelo.ImporteLetra);
                    cmd.Parameters.Add("p_anticipo_apart", modelo.Anticipo);
                    cmd.Parameters.Add("p_factura", System.Convert.ToChar(modelo.Factura).ToString());
                    cmd.Parameters.Add("p_comentario", modelo.Comentario);
                    // cmd.Parameters.Add("tipo_cotizacion", System.Convert.ToChar(modelo.TipoCotizacion));

                    //ARRAY
                    List<decimal> vnum_partida = new List<decimal>();
                    List<string> varticulo_id = new List<string>();
                    List<string> vnombre1 = new List<string>();
                    List<string> vnombre2 = new List<string>();
                    List<decimal> vcant_apartado = new List<decimal>();
                    List<decimal> vprecio = new List<decimal>();
                    List<decimal> viva = new List<decimal>();
                    List<decimal> vimpuesto_id = new List<decimal>();
                    List<decimal> vdescuento_id = new  List<decimal>();
                    List<decimal> vprecio_costo = new List<decimal>();
                    List<decimal> vpaquete_id = new List<decimal>();

                    int numPartida = 1;
                    foreach (var detalle in detalles)
                    {
                        vnum_partida.Add(numPartida);
                        numPartida++;
                        varticulo_id.Add(detalle.ArticuloID);
                        vnombre1.Add(detalle.Nombre1);
                        vnombre2.Add(detalle.Nombre2);
                        vcant_apartado.Add(detalle.CantidadApartado);
                        vprecio.Add(detalle.Precio);
                        viva.Add(detalle.IVA);
                        vimpuesto_id.Add(detalle.ImpuestoID);
                        vdescuento_id.Add(detalle.DescuentoID);
                        vprecio_costo.Add(detalle.PrecioCosto);
                        vpaquete_id.Add(detalle.PaqueteID);
                    }


                    //DETALLE
                    OracleParameter pnum_partida = cmd.Parameters.Add("p_num_partida", OracleDbType.Decimal);
                    pnum_partida.Direction = ParameterDirection.Input;
                    pnum_partida.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pnum_partida.Value = vnum_partida.ToArray();

                    OracleParameter p_articulo_id = cmd.Parameters.Add("p_articulo_id", OracleDbType.Varchar2);
                    p_articulo_id.Direction = ParameterDirection.Input;
                    p_articulo_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_articulo_id.Value = varticulo_id.ToArray();

                    OracleParameter p_nombre1 = cmd.Parameters.Add("p_nombre1", OracleDbType.Varchar2);
                    p_nombre1.Direction = ParameterDirection.Input;
                    p_nombre1.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_nombre1.Value = vnombre1.ToArray();

                    OracleParameter p_nombre2 = cmd.Parameters.Add("p_nombre2", OracleDbType.Varchar2);
                    p_nombre2.Direction = ParameterDirection.Input;
                    p_nombre2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_nombre2.Value = vnombre2.ToArray();

                    OracleParameter p_cant_apartado = cmd.Parameters.Add("p_cant_apartado", OracleDbType.Decimal);
                    p_cant_apartado.Direction = ParameterDirection.Input;
                    p_cant_apartado.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_cant_apartado.Value = vcant_apartado.ToArray();

                    OracleParameter p_precio = cmd.Parameters.Add("p_precio", OracleDbType.Decimal);
                    p_precio.Direction = ParameterDirection.Input;
                    p_precio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_precio.Value = vprecio.ToArray();

                    OracleParameter p_iva = cmd.Parameters.Add("p_iva", OracleDbType.Decimal);
                    p_iva.Direction = ParameterDirection.Input;
                    p_iva.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_iva.Value = viva.ToArray();

                    OracleParameter p_impuesto_id = cmd.Parameters.Add("p_impuesto_id", OracleDbType.Decimal);
                    p_impuesto_id.Direction = ParameterDirection.Input;
                    p_impuesto_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_impuesto_id.Value = vimpuesto_id.ToArray();

                    OracleParameter p_descuento_id = cmd.Parameters.Add("p_descuento_id", OracleDbType.Decimal);
                    p_descuento_id.Direction = ParameterDirection.Input;
                    p_descuento_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_descuento_id.Value = vdescuento_id.ToArray();

                    OracleParameter p_precio_costo = cmd.Parameters.Add("p_precio_costo", OracleDbType.Decimal);
                    p_precio_costo.Direction = ParameterDirection.Input;
                    p_precio_costo.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_precio_costo.Value = vprecio_costo.ToArray();

                    OracleParameter p_paquete_id = cmd.Parameters.Add("p_paquete_id", OracleDbType.Decimal);
                    p_paquete_id.Direction = ParameterDirection.Input;
                    p_paquete_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    p_paquete_id.Value = vpaquete_id.ToArray();



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
    }
}
