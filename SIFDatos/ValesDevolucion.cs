using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
using Oracle.DataAccess.Types;
namespace SIFDatos
{
    public static class ValesDevolucions
    {
        /// <summary>
        /// Utiliza el SP_INS_ValesDevolucion para agregar un ValesDevolucion
        /// </summary>
        /// <param name="modelo">La instancia del ValesDevolucion</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.Devolucion modelo)
        {
            string sentencia = "sp_ins_devolucion";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("devolucion_id", modelo.DevolucionID);
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("cliente_id", modelo.ClienteID);
                    cmd.Parameters.Add("fecha_dev", modelo.FechaDevolucion);
                    cmd.Parameters.Add("ref_venta", modelo.ReferenciaVenta);
                    cmd.Parameters.Add("comentario", modelo.Comentario);
                    cmd.Parameters.Add("total_dev", modelo.TotalDevolucion);
                    cmd.Parameters.Add("activo", (char)modelo.Activo);
                    cmd.Parameters.Add("usuario_id", modelo.UsuarioID);
                    cmd.Parameters.Add("autoriza_id", modelo.AutorizaID);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteScalar();
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

        public static bool InsertaDevolucionVTA(SIFModelo.Devolucion modelo, SIFModelo.WebServices.FelControl fc)
        {
            string sentencia = "pkg_ventas.sp_devolucion_vta";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                cnx.Open();
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("p_numdev", OracleDbType.Varchar2, modelo.DevolucionID, ParameterDirection.Input);
                    cmd.Parameters.Add("p_sucursal", OracleDbType.Int32, modelo.SucursalID, ParameterDirection.Input);
                    cmd.Parameters.Add("p_clienteid", OracleDbType.Int32, modelo.ClienteID, ParameterDirection.Input);
                    //cmd.Parameters.Add("fecha_dev", modelo.FechaDevolucion);
                    cmd.Parameters.Add("p_num_remision", OracleDbType.Varchar2, modelo.ReferenciaVenta, ParameterDirection.Input);
                    cmd.Parameters.Add("p_comentario", OracleDbType.Varchar2, modelo.Comentario, ParameterDirection.Input);
                    cmd.Parameters.Add("p_total_dev", OracleDbType.Decimal, modelo.TotalDevolucion, ParameterDirection.Input);
                    cmd.Parameters.Add("p_usuario", OracleDbType.Varchar2, modelo.UsuarioID.ToString(), ParameterDirection.Input);
                    //cmd.Parameters.Add("activo", (char)modelo.Activo);
                    cmd.Parameters.Add("p_autoriza", OracleDbType.Int32, modelo.AutorizaID, ParameterDirection.Input);


                    //array
                    List<int> lnum_partida = new List<int>();
                    List<string> lart_id = new List<string>();
                    List<string> lnombre1 = new List<string>();
                    List<string> lnombre2 = new List<string>();
                    List<decimal> lcantidad = new List<decimal>();
                    List<decimal> lprecio = new List<decimal>();
                    List<decimal> ldescuento = new List<decimal>();
                    List<decimal> lcosto = new List<decimal>();
                    List<decimal> liva = new List<decimal>();
                    List<decimal> ltipo_dev_id = new List<decimal>();
                    foreach (var detalle in modelo.Detalles)
                    {
                        lnum_partida.Add(detalle.NumeroPartida);
                        lart_id.Add(detalle.ArticuloID);
                        lnombre1.Add(detalle.Nombre1);
                        lnombre2.Add(detalle.Nombre2);
                        lcantidad.Add(detalle.Cantidad);
                        lprecio.Add(detalle.Precio);
                        ldescuento.Add(detalle.Descuento);
                        liva.Add(detalle.IVA);
                        lcosto.Add(detalle.PrecioCosto);
                        ltipo_dev_id.Add(detalle.TipoDevolucionID);
                    }

                    OracleParameter num_partida = cmd.Parameters.Add("num_partida", OracleDbType.Decimal);
                    num_partida.Direction = ParameterDirection.Input;
                    num_partida.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    //cmd.Parameters.Add(num_partida);

                    OracleParameter articulo_id = cmd.Parameters.Add("articulo_id", OracleDbType.Varchar2);
                    articulo_id.Direction = ParameterDirection.Input;
                    articulo_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    //cmd.Parameters.Add(articulo_id);

                    OracleParameter Nombre1 = cmd.Parameters.Add("nombre1", OracleDbType.Varchar2);
                    Nombre1.Direction = ParameterDirection.Input;
                    Nombre1.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    //cmd.Parameters.Add(Nombre1);

                    OracleParameter Nombre2 = cmd.Parameters.Add("nombre2", OracleDbType.Varchar2);
                    Nombre2.Direction = ParameterDirection.Input;
                    Nombre2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    //cmd.Parameters.Add(Nombre2);

                    OracleParameter cantidad = cmd.Parameters.Add("cantidad", OracleDbType.Decimal);
                    cantidad.Direction = ParameterDirection.Input;
                    cantidad.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    //cmd.Parameters.Add(cantidad);

                    OracleParameter precio = cmd.Parameters.Add("precio", OracleDbType.Decimal);
                    precio.Direction = ParameterDirection.Input;
                    precio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    //cmd.Parameters.Add(precio);

                    OracleParameter descuento = cmd.Parameters.Add("descuento", OracleDbType.Decimal);
                    descuento.Direction = ParameterDirection.Input;
                    descuento.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    //cmd.Parameters.Add(descuento);

                    OracleParameter iva = cmd.Parameters.Add("iva", OracleDbType.Decimal);
                    iva.Direction = ParameterDirection.Input;
                    iva.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    //cmd.Parameters.Add(iva);

                    OracleParameter pcosto = cmd.Parameters.Add("pcosto", OracleDbType.Decimal);
                    pcosto.Direction = ParameterDirection.Input;
                    pcosto.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    //cmd.Parameters.Add(pcosto);

                    OracleParameter tipo_dev_id = cmd.Parameters.Add("tipo_dev_id", OracleDbType.Decimal);
                    tipo_dev_id.Direction = ParameterDirection.Input;
                    tipo_dev_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    //cmd.Parameters.Add(tipo_dev_id);


                    num_partida.Value = lnum_partida.ToArray();
                    articulo_id.Value = lart_id.ToArray();
                    Nombre1.Value = lnombre1.ToArray();
                    Nombre2.Value = lnombre2.ToArray();
                    cantidad.Value = lcantidad.ToArray();
                    precio.Value = lprecio.ToArray();
                    descuento.Value = ldescuento.ToArray();
                    iva.Value = liva.ToArray();
                    pcosto.Value = lcosto.ToArray();
                    tipo_dev_id.Value = ltipo_dev_id.ToArray();

                    //DATOS DE FACTURA
                    cmd.Parameters.Add("p_factura", OracleDbType.XmlType, new OracleXmlType(cnx, fc.FACTURA), ParameterDirection.Input);
                    cmd.Parameters.Add("p_path_factura", OracleDbType.Varchar2, fc.PATH_FACTURA, ParameterDirection.Input);
                    cmd.Parameters.Add("p_uuid", OracleDbType.Varchar2, fc.UUID, ParameterDirection.Input);
                    cmd.Parameters.Add("p_tipo_cfdi", OracleDbType.Varchar2, fc.TIPO_CFDI, ParameterDirection.Input);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("OutParam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outparam);


                    try
                    {
                        //cmd.Connection.Open();
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


        public static bool Actualiza(SIFModelo.Devolucion modelo)
        {
            string sentencia = "SP_UPD_DEVOLUCION";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("edevolucion_id", modelo.DevolucionID);
                    cmd.Parameters.Add("esucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("ecliente_id", modelo.ClienteID);
                    cmd.Parameters.Add("efecha_dev", System.Convert.ToDateTime(modelo.FechaDevolucion));
                    cmd.Parameters.Add("eref_venta", modelo.ReferenciaVenta);
                    cmd.Parameters.Add("ecomentario", modelo.Comentario);
                    cmd.Parameters.Add("etotal_dev", modelo.TotalDevolucion);
                    cmd.Parameters.Add("eactivo", (char)modelo.Activo);
                    cmd.Parameters.Add("eusuario_id", modelo.UsuarioID);
                    cmd.Parameters.Add("eautoriza_id", modelo.AutorizaID);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteScalar();

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

        public static SIFModelo.Devolucion BuscaPorNumeroDevolucion(string numero, SIFModelo.Sucursal sucursal)
        {
            string sentencia = "SELECT * FROM DEVOLUCION WHERE  DEVOLUCION_ID = :numero AND SUCURSAL_ID = :SucursalID ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {

                        //PARAMETROS
                        cmd.Parameters.Add(":numero", numero);
                        cmd.Parameters.Add(":SucursalID", sucursal.SucursalesID);

                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Devolucion registro = new SIFModelo.Devolucion();

                                registro.DevolucionID = oreader["DEVOLUCION_ID"].ToString();
                                registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.ClienteID = int.Parse(oreader["CLIENTE_ID"].ToString());
                                registro.ReferenciaVenta = oreader["REF_VENTA"].ToString();
                                registro.FechaDevolucion = System.Convert.ToDateTime(oreader["FECHA_DEV"]);
                                registro.Comentario = oreader["COMENTARIO"].ToString();
                                registro.TotalDevolucion = decimal.Parse(oreader["TOTAL_DEV"].ToString());
                                registro.Activo = ((SIFModelo.Tipos.ActivoDevolucion)oreader["ACTIVO"].ToString()[0]);
                                registro.UsuarioID = int.Parse(oreader["USUARIO_ID"].ToString());
                                registro.AutorizaID = int.Parse(oreader["AUTORIZA_ID"].ToString());

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

        public static List<SIFModelo.DevolucionDetalle> BuscaDetalles(string numero, SIFModelo.Sucursal sucursal)
        {
            string sentencia = "SELECT * FROM DEVOLUCION_DET WHERE  DEVOLUCION_ID = :numero AND SUCURSAL_ID = :SucursalID ";
            List<SIFModelo.DevolucionDetalle> registros = new List<SIFModelo.DevolucionDetalle>();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {

                        //PARAMETROS
                        cmd.Parameters.Add(":numero", numero);
                        cmd.Parameters.Add(":SucursalID", sucursal.SucursalesID);

                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.DevolucionDetalle registro = new SIFModelo.DevolucionDetalle();

                                registro.DevolucionID = oreader["DEVOLUCION_ID"].ToString();
                                registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.ArticuloID = oreader["ARTICULO_ID"].ToString();
                                registro.Descuento = decimal.Parse(oreader["DESCUENTO"].ToString());
                                registro.IVA = decimal.Parse(oreader["IVA"].ToString());
                                registro.Nombre1 = oreader["NOMBRE1"].ToString();
                                registro.Nombre2 = oreader["NOMBRE2"].ToString();
                                registro.Cantidad = int.Parse(oreader["cantidad"].ToString());
                                registro.Precio = decimal.Parse(oreader["PRECIO"].ToString());
                                registro.PrecioCosto = decimal.Parse(oreader["PCOSTO"].ToString());
                                registro.TipoDevolucionID = int.Parse(oreader["TIPO_DEV_ID"].ToString());
                                registros.Add(registro);

                            }
                            return registros;
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
            return null;
        }
        public static SIFModelo.Devolucion BuscaPorRemision(string numero, SIFModelo.Sucursal sucursal)
        {

            string sentencia = "SELECT * FROM DEVOLUCION WHERE  REF_VENTA = :numero AND SUCURSAL_ID = :SucursalID ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //PARAMETROS
                        cmd.Parameters.Add("numero", numero);
                        cmd.Parameters.Add("SucursalID", sucursal.SucursalesID);

                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Devolucion registro = new SIFModelo.Devolucion();

                                registro.DevolucionID = oreader["DEVOLUCION_ID"].ToString();
                                registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.ClienteID = int.Parse(oreader["CLIENTE_ID"].ToString());
                                registro.ReferenciaVenta = oreader["REF_VENTA"].ToString();
                                registro.FechaDevolucion = System.Convert.ToDateTime(oreader["FECHA_DEV"]);
                                registro.ReferenciaVenta = oreader["COMENTARIO"].ToString();
                                registro.TotalDevolucion = decimal.Parse(oreader["TOTAL_DEV"].ToString());
                                registro.Activo = ((SIFModelo.Tipos.ActivoDevolucion)oreader["ACTIVO"].ToString()[0]);
                                registro.UsuarioID = int.Parse(oreader["USUARIO_ID"].ToString());
                                registro.AutorizaID = int.Parse(oreader["AUTORIZA_ID"].ToString());

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

        public static List<SIFModelo.Devolucion> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.Devolucion> rows = new List<SIFModelo.Devolucion>();

            string sentencia = "SELECT * FROM devolucion";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //TIPO DE COMANDO
                    cmd.CommandType = CommandType.StoredProcedure;
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("REFCUR", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Devolucion registro = new SIFModelo.Devolucion();

                            registro.DevolucionID = oreader["DEVOLUCION_ID"].ToString();
                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.SucursalID = int.Parse(oreader["CLIENTE_ID"].ToString());
                            registro.ReferenciaVenta = oreader["REF_VENTA"].ToString();
                            registro.FechaDevolucion = System.Convert.ToDateTime(oreader["FECHA_DEV"]);
                            registro.ReferenciaVenta = oreader["COMENTARIO"].ToString();
                            registro.TotalDevolucion = decimal.Parse(oreader["TOTAL_DEV"].ToString());
                            registro.Activo = ((SIFModelo.Tipos.ActivoDevolucion)oreader["ACTIVO"].ToString()[0]);
                            registro.UsuarioID = int.Parse(oreader["USUARIO_ID"].ToString());
                            registro.AutorizaID = int.Parse(oreader["AUTORIZA_ID"].ToString());

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


        public static List<SIFModelo.ValeDevolucion> BuscaVales(string propiedad, string parametro)
        {
            List<SIFModelo.ValeDevolucion> rows = new List<SIFModelo.ValeDevolucion>();

            string sentencia = "SELECT CAT_VALES_DEV.VALES_DEV_ID, CAT_VALES_DEV.SUCURSAL_ID, CAT_VALES_DEV.REMISION_ID, " +
                     " CAT_VALES_DEV.FECHA_EMISION, CAT_VALES_DEV.FECHA_VIGENCIA, CAT_VALES_DEV.USUARIO_ID,  " +
                     " CAT_VALES_DEV.USER_AUTORIZA, CAT_VALES_DEV.MOTIVO_ID, CAT_VALES_DEV.OBSERVACIONES,  " +
                     " CAT_VALES_DEV.STATUS, CAT_SUCURSALES.NOMBRE AS SUCURSAL_NOMBRE,  " +
                     " CAT_TIPO_DEVOLUCION.NOMBRE AS MOTIVO_NOMBRE " +
                     " , CAT_USUARIOS.NOMBRE || ' ' || CAT_USUARIOS.APELLIDOS USUARIO_NOMBRE,  " +
                     " CAT_USUARIOS_1.NOMBRE || ' ' || CAT_USUARIOS_1.APELLIDOS AS USUARIO_AUTORIZA_NOMBRE " +
                     " FROM CAT_VALES_DEV INNER JOIN " +
                     " CAT_SUCURSALES ON CAT_VALES_DEV.SUCURSAL_ID = CAT_SUCURSALES.SUCURSALES_ID INNER JOIN " +
                     " CAT_USUARIOS ON CAT_VALES_DEV.USUARIO_ID = CAT_USUARIOS.USUARIOS_ID INNER JOIN " +
                     " CAT_TIPO_DEVOLUCION ON CAT_VALES_DEV.MOTIVO_ID = CAT_TIPO_DEVOLUCION.TIPO_DEVOLUCION_ID LEFT OUTER JOIN " +
                     " CAT_USUARIOS CAT_USUARIOS_1 ON CAT_VALES_DEV.USER_AUTORIZA = CAT_USUARIOS_1.USUARIOS_ID";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.ValeDevolucion registro = new SIFModelo.ValeDevolucion();

                            registro.VALES_DEV_ID = int.Parse(oreader["VALES_DEV_ID"].ToString());
                            registro.SUCURSAL_ID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.REMISION_ID = oreader["REMISION_ID"].ToString();
                            registro.FECHA_EMISION = DateTime.Parse(oreader["FECHA_EMISION"].ToString());
                            registro.FECHA_VIGENCIA = System.Convert.ToDateTime(oreader["FECHA_VIGENCIA"]);
                            registro.USUARIO_ID = int.Parse(oreader["USUARIO_ID"].ToString());
                            registro.USER_AUTORIZA = int.Parse(oreader["USER_AUTORIZA"].ToString());
                            registro.MOTIVO_ID = int.Parse(oreader["MOTIVO_ID"].ToString());
                            registro.OBSERVACIONES = oreader["OBSERVACIONES"].ToString();
                            registro.SUCURSAL_NOMBRE = oreader["SUCURSAL_NOMBRE"].ToString();
                            registro.USUARIO_NOMBRE = oreader["USUARIO_NOMBRE"].ToString();
                            registro.USUARIO_AUTORIZA_NOMBRE = oreader["USUARIO_AUTORIZA_NOMBRE"].ToString();
                            registro.STATUS = oreader["STATUS"].ToString();
                            registro.MOTIVO_NOMBRE = oreader["MOTIVO_NOMBRE"].ToString();
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

        public static bool InsertaDetalle(SIFModelo.DevolucionDetalle modelo)
        {
            string sentencia = "sp_ins_devolucion_det";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("devolucion_id", modelo.DevolucionID);
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("num_partida", modelo.NumeroPartida);
                    cmd.Parameters.Add("articulo_id", modelo.ArticuloID);
                    cmd.Parameters.Add("nombre1", modelo.Nombre1);
                    cmd.Parameters.Add("nombre2", modelo.Nombre2);
                    cmd.Parameters.Add("cantidad", modelo.Cantidad);
                    cmd.Parameters.Add("precio", modelo.Precio);
                    cmd.Parameters.Add("descuento", modelo.Descuento);
                    cmd.Parameters.Add("iva", modelo.IVA);
                    cmd.Parameters.Add("pcosto", modelo.PrecioCosto);
                    cmd.Parameters.Add("tipo_dev_id", modelo.TipoDevolucionID);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteScalar();

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

        public static int NumeroDevolucion(SIFModelo.Sucursal sucursal, string prefijo)
        {
            object id;
            string sentencia = "SELECT SEC_DEVOLUCION.NEXTVAL FROM DUAL"; //WHERE TO_CHAR( FECHA_DEV,'YY') = :prefijoFolio AND sucursal_id = :sucursalID";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.Parameters.Add("sucursalID", sucursal.SucursalesID);
                    //cmd.Parameters.Add("prefijoFolio", prefijo);
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


        public static SIFModelo.ValeDevolucion InsertaValeDevolucion(SIFModelo.ValeDevolucion modelo)
        {
            string sentencia = "SP_INS_CAT_VALES_DEV";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("remision_id", modelo.REMISION_ID);
                    cmd.Parameters.Add("fecha_emision", modelo.FECHA_EMISION);
                    cmd.Parameters.Add("fecha_vigencia", modelo.FECHA_VIGENCIA);
                    cmd.Parameters.Add("usuario_id", modelo.USUARIO_ID);
                    cmd.Parameters.Add("user_autoriza", modelo.USER_AUTORIZA);
                    cmd.Parameters.Add("motivo_id", modelo.MOTIVO_ID);
                    cmd.Parameters.Add("observaciones", modelo.OBSERVACIONES);
                    cmd.Parameters.Add("status", modelo.STATUS);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();
                        var id = cmd.ExecuteScalar();

                        //id = outparam.Value;
                        if (id.ToString().IsInteger())
                        {
                            if (int.Parse(id.ToString()) < 0)
                            {
                                throw new Exception("Ha ocurrido un error al insetrar el registro" + id.ToString());
                            }

                            modelo.VALES_DEV_ID = int.Parse(id.ToString());
                        }
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

        public static bool ActualizaValeDevolucion(SIFModelo.ValeDevolucion modelo)
        {
            string sentencia = "SP_UPD_CAT_VALES_DEV";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("evale_id", modelo.VALES_DEV_ID);
                    cmd.Parameters.Add("esuc_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("eremision_id", modelo.REMISION_ID);
                    cmd.Parameters.Add("efecha_emision", modelo.FECHA_EMISION);
                    cmd.Parameters.Add("efecha_vigencia", modelo.FECHA_VIGENCIA);
                    cmd.Parameters.Add("eusuario_id", modelo.USUARIO_ID.ToString());
                    cmd.Parameters.Add("euser_autoriza", modelo.USER_AUTORIZA.ToString());
                    cmd.Parameters.Add("emotivo_id", modelo.MOTIVO_ID);
                    cmd.Parameters.Add("eobservaciones", modelo.OBSERVACIONES);
                    cmd.Parameters.Add("estatus", modelo.STATUS[0]);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteScalar();

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



        public static int CantidadDevuelta(SIFModelo.RemisionDetalle detalle)
        {
            object id;
            string sentencia = "SELECT NVL(SUM(CANTIDAD),0) FROM DEVOLUCION_DET T JOIN DEVOLUCION D " +
                " ON T.DEVOLUCION_ID = D.DEVOLUCION_ID AND D.SUCURSAL_ID = T.SUCURSAL_ID " +
                " WHERE D.REF_VENTA LIKE :RemisionID " +
                " AND T.SUCURSAL_ID = :SucursalID" +
                " AND T.ARTICULO_ID LIKE :ArticuloID";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalID", detalle.SucursalID);
                    cmd.Parameters.Add("RemisionID", detalle.NumeroRemision);
                    cmd.Parameters.Add("ArticuloID", detalle.ArticuloID);
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

        public static SIFModelo.ValeDevolucion BuscarPorRemisionSucursal(string remision, SIFModelo.Sucursal sucursal)
        {
            string sentencia = "SELECT CAT_VALES_DEV.VALES_DEV_ID, CAT_VALES_DEV.SUCURSAL_ID, CAT_VALES_DEV.REMISION_ID, " +
                      " CAT_VALES_DEV.FECHA_EMISION, CAT_VALES_DEV.FECHA_VIGENCIA, CAT_VALES_DEV.USUARIO_ID,  " +
                      " CAT_VALES_DEV.USER_AUTORIZA, CAT_VALES_DEV.MOTIVO_ID, CAT_VALES_DEV.OBSERVACIONES,  " +
                      " CAT_VALES_DEV.STATUS, CAT_SUCURSALES.NOMBRE AS SUCURSAL_NOMBRE,  " +
                      " CAT_TIPO_DEVOLUCION.NOMBRE AS MOTIVO_NOMBRE " +
                      " , CAT_USUARIOS.NOMBRE || ' ' || CAT_USUARIOS.APELLIDOS USUARIO_NOMBRE,  " +
                      " CAT_USUARIOS_1.NOMBRE || ' ' || CAT_USUARIOS_1.APELLIDOS AS USUARIO_AUTORIZA_NOMBRE " +
                      " FROM CAT_VALES_DEV INNER JOIN " +
                      " CAT_SUCURSALES ON CAT_VALES_DEV.SUCURSAL_ID = CAT_SUCURSALES.SUCURSALES_ID INNER JOIN " +
                      " CAT_USUARIOS ON CAT_VALES_DEV.USUARIO_ID = CAT_USUARIOS.USUARIO_ID INNER JOIN " +
                      " CAT_TIPO_DEVOLUCION ON CAT_VALES_DEV.MOTIVO_ID = CAT_TIPO_DEVOLUCION.TIPO_DEVOLUCION_ID LEFT OUTER JOIN " +
                      " CAT_USUARIOS CAT_USUARIOS_1 ON CAT_VALES_DEV.USER_AUTORIZA = CAT_USUARIOS_1.USUARIOS_ID" +
                      " WHERE  CAT_VALES_DEV.REMISION_ID LIKE :RemisionID AND CAT_VALES_DEV.SUCURSAL_ID = :SucursalID ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Parameters.Add("RemisionID", remision);
                        cmd.Parameters.Add("SucursalID", sucursal.SucursalesID);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.ValeDevolucion registro = new SIFModelo.ValeDevolucion();

                                registro.VALES_DEV_ID = int.Parse(oreader["VALES_DEV_ID"].ToString());
                                registro.SUCURSAL_ID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.REMISION_ID = oreader["REMISION_ID"].ToString();
                                registro.FECHA_EMISION = DateTime.Parse(oreader["FECHA_EMISION"].ToString());
                                registro.FECHA_VIGENCIA = System.Convert.ToDateTime(oreader["FECHA_VIGENCIA"]);
                                registro.USUARIO_ID = int.Parse(oreader["USUARIO_ID"].ToString());
                                registro.USER_AUTORIZA = int.Parse(oreader["USER_AUTORIZA"].ToString());
                                registro.MOTIVO_ID = int.Parse(oreader["MOTIVO_ID"].ToString());
                                registro.OBSERVACIONES = oreader["OBSERVACIONES"].ToString();
                                registro.SUCURSAL_NOMBRE = oreader["SUCURSAL_NOMBRE"].ToString();
                                registro.USUARIO_NOMBRE = oreader["USUARIO_NOMBRE"].ToString();
                                registro.USUARIO_AUTORIZA_NOMBRE = oreader["USUARIO_AUTORIZA_NOMBRE"].ToString();
                                registro.STATUS = oreader["STATUS"].ToString();
                                registro.MOTIVO_NOMBRE = oreader["MOTIVO_NOMBRE"].ToString();
                                return registro;
                            }
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
            return null;
        }
    }
}
