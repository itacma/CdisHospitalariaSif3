using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace SIFDatos.Inventario
{
    public class Inventario
    {
        /// <summary>
        /// AVM 24-04-2015 
        /// Carga las lineas de inventario para el reporte de ubicacion.
        /// </summary>
        /// <returns></returns>
        public static List<String> CargarLineas()
        {
            List<String> _lineas = new List<String>();
            _lineas.Add("[TODAS]");

            string sentencia = "SELECT to_number(REGEXP_SUBSTR (ubicacion, '[^|]+', 1, 1)) Fila " +
                               "FROM Inventario inv, Cat_Articulos art " +
                               "WHERE REGEXP_LIKE (art.lista_sucursal_vta, '3', 'i') " +
                                     "AND (NOT REGEXP_LIKE (tipo_medicamento_cve, 'tae|sp', 'i') or tipo_medicamento_cve is null) " +
                                     "AND inv.articulo_id = art.articulo_id " +
                                     "AND inv.existencias > 0 " +
                               "Group by to_number(REGEXP_SUBSTR (ubicacion, '[^|]+', 1, 1)) " +
                               "order by to_number(REGEXP_SUBSTR (ubicacion, '[^|]+', 1, 1)) asc";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    try
                    {
                        cmd.Connection.Open();
                        OracleDataReader read = cmd.ExecuteReader();

                        if (read.HasRows)
                        {
                            while (read.Read())
                            {
                                _lineas.Add(read["Fila"].ToString());
                            }
                        }
                    }
                    catch
                    {


                    }
                    finally {


                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                }

            }

            return _lineas;

        }
        public static bool Actualiza(SIFModelo.Inventarios.Inventario modelo, int partida)
        {
            string sentencia = "sp_upd_inventario";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("earticulo_id", modelo.ArticuloID);
                    cmd.Parameters.Add("esucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("eexistencias", modelo.Existencias);
                    cmd.Parameters.Add("eexistencia_min", modelo.ExistenciasMinimas);
                    cmd.Parameters.Add("eexistencia_max", modelo.ExistenciasMaximas);
                    cmd.Parameters.Add("epunto_de_reorden", modelo.PuntoDeReorden);
                    cmd.Parameters.Add("einv_fisico", modelo.InventarioFisico);
                    cmd.Parameters.Add("efech_ult_mov", modelo.UltimaModificacion);
                    cmd.Parameters.Add("efech_ult_ent", modelo.UltimaEntrada);
                    cmd.Parameters.Add("efech_ult_sal", modelo.UltimaSalida);
                    cmd.Parameters.Add("eult_costo", modelo.UltimoCosto);
                    cmd.Parameters.Add("ecosto_prom", modelo.CostoPromedio);
                    cmd.Parameters.Add("epeps", modelo.PEPS);
                    cmd.Parameters.Add("eueps", modelo.UEPS);
                    cmd.Parameters.Add("efecha_inv_fisico", modelo.FechaInventarioFisico);
                    cmd.Parameters.Add("eubicacion", modelo.Ubicacion);
                    cmd.Parameters.Add("eapartado_vtas", modelo.ApartadoVentas);
                    cmd.Parameters.Add("eusuario", modelo.UsuarioID);
                    cmd.Parameters.Add("eDocumento", modelo.Documento);
                    cmd.Parameters.Add("eMOV_INV_ID", modelo.MOV_INV_ID);
                    cmd.Parameters.Add("ePartida", modelo.Partida);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();

                        cmd.ExecuteScalar();
                        if (outparam.Value.ToString().IsInteger())
                        {
                            if (int.Parse(outparam.Value.ToString()) < 0)
                            {
                                throw new Exception("Ha ocurrido un error al actualizar el registro" + outparam.Value.ToString());
                            }

                            modelo.ID = int.Parse(outparam.Value.ToString());
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

        public static bool InventarioApartado(SIFModelo.Articulo articulo, Decimal Cantidad, SIFModelo.Sucursal sucursal)
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand

                OracleCommand cmd = conn.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pkg_ventas.sp_act_apartado_vta";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pOutParam = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("suc_id", OracleDbType.Int32, sucursal.SucursalesID, ParameterDirection.Input);
                cmd.Parameters.Add("art_id", OracleDbType.Varchar2, articulo.ARTICULO_ID, ParameterDirection.Input);
                cmd.Parameters.Add("Cant", OracleDbType.Decimal, Cantidad, ParameterDirection.Input);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Apartado DB: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);
                }
            }

            return true;

        }

        public static bool InsertaMovimiento(SIFModelo.Inventarios.MovimientoInventario modelo)
        {
            string sentencia = "sp_ins_inventario_mov";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("articulo_id", modelo.ArticuloID);
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("existencias", modelo.Existencias);
                    cmd.Parameters.Add("existencia_min", modelo.ExistenciasMinimas);
                    cmd.Parameters.Add("existencia_max", modelo.ExistenciasMaximas);
                    cmd.Parameters.Add("punto_de_reorden", modelo.PuntoDeReorden);
                    cmd.Parameters.Add("inv_fisico", modelo.InventarioFisico);
                    cmd.Parameters.Add("fecha_ult_mov", modelo.UltimaModificacion);
                    cmd.Parameters.Add("fecha_ult_ent", modelo.UltimaEntrada);
                    cmd.Parameters.Add("fecha_ult_sal", modelo.UltimaSalida);
                    cmd.Parameters.Add("ult_costo", modelo.UltimoCosto);
                    cmd.Parameters.Add("ecosto_prom", modelo.CostoPromedio);
                    cmd.Parameters.Add("peps", modelo.PEPS);
                    cmd.Parameters.Add("ueps", modelo.UEPS);
                    cmd.Parameters.Add("fecha_inv_fisico", modelo.FechaInventarioFisico);
                    cmd.Parameters.Add("ubicacion", modelo.Ubicacion);
                    cmd.Parameters.Add("apartado_vtas", modelo.ApartadoVentas);
                    cmd.Parameters.Add("tipo_mov", modelo.TipoMovimiento);
                    cmd.Parameters.Add("usuario", modelo.UsuarioID);
                    cmd.Parameters.Add("cantidad", modelo.Cantidad);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();

                        cmd.ExecuteScalar();
                        if (outparam.Value.ToString().IsInteger())
                        {
                            if (int.Parse(outparam.Value.ToString()) < 0)
                            {
                                throw new Exception("Ha ocurrido un error al actualizar el registro" + outparam.Value.ToString());
                            }

                            modelo.ID = int.Parse(outparam.Value.ToString());
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

        public static SIFModelo.Inventarios.InventarioDataSet ArticuloInventario(SIFModelo.Articulo articulo, SIFModelo.Sucursal sucursal)
        {
            SIFModelo.Inventarios.InventarioDataSet dsInventario = new SIFModelo.Inventarios.InventarioDataSet();

            string sentencia = "SELECT INVENTARIO.ARTICULO_ID, INVENTARIO.SUCURSAL_ID, INVENTARIO.EXISTENCIAS, INVENTARIO.EXISTENCIA_MIN, " +
                       "  INVENTARIO.EXISTENCIA_MAX, INVENTARIO.PUNTO_DE_REORDEN, INVENTARIO.INV_FISICO, INVENTARIO.FECHA_ULT_MOV,  " +
                       "  INVENTARIO.FECHA_ULT_ENT, INVENTARIO.FECHA_ULT_SAL, INVENTARIO.ULT_COSTO, INVENTARIO.COSTO_PROM, INVENTARIO.PEPS,  " +
                       "  INVENTARIO.UEPS, INVENTARIO.FECHA_INV_FISICO, INVENTARIO.UBICACION, INVENTARIO.APARTADO_VTAS, CAT_ARTICULOS.NOMBRE1,  " +
                       "  CAT_ARTICULOS.NOMBRE2, CAT_ARTICULOS.TIPO_MEDICAMENTO_CVE, CAT_ARTICULOS.LISTA_SUCURSAL_VTA,  " +
                       "  CAT_ARTICULOS.PROVEEDOR_ID, CAT_ARTICULOS.LABORATORIO_ID " +
                       "  FROM INVENTARIO INNER JOIN " +
                       "  CAT_ARTICULOS ON INVENTARIO.ARTICULO_ID = CAT_ARTICULOS.ARTICULO_ID";
            sentencia += " WHERE CAT_ARTICULOS.NOMBRE1 LIKE :p_articulo_nombre1 AND INVENTARIO.SUCURSAL_ID = :p_sucursal_id OR INVENTARIO.ARTICULO_ID LIKE :p_articulo_nombre1 AND INVENTARIO.SUCURSAL_ID = :p_sucursal_id ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("p_articulo_nombre1", "%" + articulo.NOMBRE1 + "%");
                    cmd.Parameters.Add("p_sucursal_id", sucursal.SucursalesID);
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dsInventario.INVENTARIO);
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            return dsInventario;

        }

        public static SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow ArticuloInventario(string articulo, SIFModelo.Sucursal sucursal)
        {
            SIFModelo.Inventarios.InventarioDataSet dsInventario = new SIFModelo.Inventarios.InventarioDataSet();

            string sentencia = "SELECT     C.ARTICULO_ID, C.SUCURSAL_ID, C.EXISTENCIAS, (SELECT SUM(B.EXISTENCIAS) FROM INVENTARIO B WHERE B.ARTICULO_ID = C.ARTICULO_ID ) AS EXISTENCIA_GENERAL ,C.EXISTENCIA_MIN, C.EXISTENCIA_MAX,  " +
                     " C.PUNTO_DE_REORDEN, C.INV_FISICO, C.FECHA_ULT_MOV, C.FECHA_ULT_ENT, C.FECHA_ULT_SAL,  " +
                     " C.ULT_COSTO, C.COSTO_PROM, C.PEPS, C.UEPS, C.FECHA_INV_FISICO, C.UBICACION,  " +
                     " C.APARTADO_VTAS, CAT_ARTICULOS.NOMBRE1, CAT_ARTICULOS.NOMBRE2, CAT_ARTICULOS.TIPO_MEDICAMENTO_CVE,  " +
                     " CAT_ARTICULOS.LISTA_SUCURSAL_VTA, CAT_ARTICULOS.PROVEEDOR_ID, CAT_ARTICULOS.LABORATORIO_ID " +
                     " FROM INVENTARIO C INNER JOIN " +
                     " CAT_ARTICULOS ON C.ARTICULO_ID = CAT_ARTICULOS.ARTICULO_ID " +
                     " WHERE C.ARTICULO_ID = :p_articulo_id AND C.SUCURSAL_ID = :p_sucursal_id";



            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("p_articulo_id", articulo);
                    cmd.Parameters.Add("p_sucursal_id", sucursal.SucursalesID);
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dsInventario.INVENTARIO);
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            if (dsInventario.INVENTARIO.Rows.Count > 0)
            {
                return dsInventario.INVENTARIO.Rows[0] as SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow;
            }
            else
            {
                return null;
            }

        }

        public static bool ActualizaUbicacion(SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow modelo)
        {
            string sentencia = "UPDATE INVENTARIO SET ubicacion =:p_ubicacion ";
            sentencia += " WHERE articulo_id = :p_articulo_id AND sucursal_id = :p_sucursal_id ";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("p_articulo_id", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("p_sucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("p_ubicacion", modelo.UBICACION);

                    try
                    {
                        cmd.Connection.Open();

                        cmd.ExecuteScalar();
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

        public static bool ActualizaExistencia(SIFModelo.Sucursal sucursal, List<SIFModelo.RemisionDetalle> detalles, SIFModelo.Cajero usuario, SIFModelo.Remision remision, int UltMovInd)
        {
            string sentencia = "PKG_VENTAS.sp_act_existencia_vta";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("suc_id", sucursal.SucursalID);

                    //parametros del array para detalle
                    // IN ARRAY PARAMETERS


                    OracleParameter particulo_id = cmd.Parameters.Add("art_id", OracleDbType.Varchar2);
                    particulo_id.Direction = ParameterDirection.Input;
                    particulo_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;


                    OracleParameter pcant_remision = cmd.Parameters.Add("Cant", OracleDbType.Decimal);
                    pcant_remision.Direction = ParameterDirection.Input;
                    pcant_remision.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter pusuario = cmd.Parameters.Add("UltUsr", OracleDbType.Varchar2);
                    pusuario.Direction = ParameterDirection.Input;
                    pusuario.Value = usuario.CajeroID;
                    //pusuario.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter pUltDocto = cmd.Parameters.Add("UltDocto", OracleDbType.Varchar2);
                    pUltDocto.Direction = ParameterDirection.Input;
                    pUltDocto.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter pUltMovInd = cmd.Parameters.Add("UltMovInd", OracleDbType.Decimal);
                    pUltMovInd.Direction = ParameterDirection.Input;
                    pUltMovInd.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter pnum_partida = cmd.Parameters.Add("UltPar", OracleDbType.Decimal);
                    pnum_partida.Direction = ParameterDirection.Input;
                    pnum_partida.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    //
                    //VALORES

                    List<string> Varticulo_id = new List<string>();
                    List<decimal> Vcant_remision = new List<decimal>();
                    //List<string> Vusuario_remision = new List<string>();
                    List<string> VUltDocto = new List<string>();
                    List<decimal> VUltMovInd = new List<decimal>();
                    List<decimal> Vnum_partida = new List<decimal>();

                    foreach (var detalle in detalles)
                    {
                        Varticulo_id.Add(detalle.ArticuloID);
                        Vcant_remision.Add(detalle.CantidadRemision * -1);
                        // Vusuario_remision.Add(usuario.CajeroID);
                        VUltDocto.Add(remision.NumeroRemision);
                        VUltMovInd.Add(UltMovInd);
                        Vnum_partida.Add(detalle.NumeroPartida);
                    }


                    particulo_id.Value = Varticulo_id.ToArray();
                    pcant_remision.Value = Vcant_remision.ToArray();
                    //pusuario.Value = Vusuario_remision.ToArray();
                    pUltDocto.Value = VUltDocto.ToArray();
                    pUltMovInd.Value = VUltMovInd.ToArray();
                    pnum_partida.Value = Vnum_partida.ToArray();


                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("OutParam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

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
                                throw new Exception("Ha ocurrido un error al insertar el registro" + id.ToString());
                            }

                            //modelo. = int.Parse(id.ToString());
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

        public static bool ActualizaExistencia(SIFModelo.Sucursal sucursal, List<SIFModelo.DevolucionDetalle> detalles, SIFModelo.Usuario usuario, SIFModelo.Devolucion devolucion, decimal UltMovInd)
        {
            string sentencia = "PKG_VENTAS.sp_act_existencia_dev";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("suc_id", sucursal.SucursalID);

                    //parametros del array para detalle
                    // IN ARRAY PARAMETERS


                    OracleParameter particulo_id = cmd.Parameters.Add("art_id", OracleDbType.Varchar2);
                    particulo_id.Direction = ParameterDirection.Input;
                    particulo_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;


                    OracleParameter pcant_remision = cmd.Parameters.Add("Cant", OracleDbType.Decimal);
                    pcant_remision.Direction = ParameterDirection.Input;
                    pcant_remision.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter pusuario = cmd.Parameters.Add("UltUsr", OracleDbType.Varchar2);
                    pusuario.Direction = ParameterDirection.Input;
                    pusuario.Value = usuario.UsuariosID;
                    //pusuario.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter pUltDocto = cmd.Parameters.Add("UltDocto", OracleDbType.Varchar2);
                    pUltDocto.Direction = ParameterDirection.Input;
                    pUltDocto.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter pUltMovInd = cmd.Parameters.Add("UltMovInd", OracleDbType.Decimal);
                    pUltMovInd.Direction = ParameterDirection.Input;
                    pUltMovInd.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter pnum_partida = cmd.Parameters.Add("UltPar", OracleDbType.Decimal);
                    pnum_partida.Direction = ParameterDirection.Input;
                    pnum_partida.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    //
                    //VALORES

                    List<string> Varticulo_id = new List<string>();
                    List<decimal> Vcant_remision = new List<decimal>();
                    //List<string> Vusuario_remision = new List<string>();
                    List<string> VUltDocto = new List<string>();
                    List<decimal> VUltMovInd = new List<decimal>();
                    List<decimal> Vnum_partida = new List<decimal>();

                    foreach (var detalle in detalles)
                    {
                        Varticulo_id.Add(detalle.ArticuloID);
                        Vcant_remision.Add(detalle.Cantidad);
                        // Vusuario_remision.Add(usuario.CajeroID);
                        VUltDocto.Add(devolucion.DevolucionID);
                        VUltMovInd.Add(UltMovInd);
                        Vnum_partida.Add(detalle.NumeroPartida);
                    }


                    particulo_id.Value = Varticulo_id.ToArray();
                    pcant_remision.Value = Vcant_remision.ToArray();
                    //pusuario.Value = Vusuario_remision.ToArray();
                    pUltDocto.Value = VUltDocto.ToArray();
                    pUltMovInd.Value = VUltMovInd.ToArray();
                    pnum_partida.Value = Vnum_partida.ToArray();


                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("OutParam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

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
                                throw new Exception("Ha ocurrido un error al insertar el registro" + id.ToString());
                            }

                            //modelo. = int.Parse(id.ToString());
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

        public static bool InsertaListaPrecios(SIFModelo.Inventarios.ListaPrecios precio)
        {
            string sentencia = "SP_INS_LISTA_PRECIOS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("articulo_id", precio.ARTICULO_ID);
                    cmd.Parameters.Add("sucursal_id", precio.SUCURSAL_ID);
                    cmd.Parameters.Add("precio_venta", precio.PRECIO_VENTA);
                    cmd.Parameters.Add("precio_venta_max", precio.PRECIO_VENTA_MAX);
                    cmd.Parameters.Add("precio_venta_farm", precio.PRECIO_VENTA_FARM);
                    cmd.Parameters.Add("precio_costo", precio.PRECIO_COSTO);
                    cmd.Parameters.Add("costo_prom", precio.COSTO_PROM);
                    cmd.Parameters.Add("costo_ult_compra", precio.COSTO_ULT_COMPRA);
                    cmd.Parameters.Add("fecha_alta", precio.FECHA_ALTA);
                    cmd.Parameters.Add("imp_compra", precio.IMP_COMPRA);
                    cmd.Parameters.Add("imp_venta", precio.IMP_VENTA);
                    cmd.Parameters.Add("activo", (char)precio.ACTIVO);

                    //parametros del array para detalle
                    // IN ARRAY PARAMETERS

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("OutParam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

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
                                throw new Exception("Ha ocurrido un error al insertar el registro" + id.ToString());
                            }

                            //modelo. = int.Parse(id.ToString());
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

        public static bool ActualizaListaPrecios(SIFModelo.Inventarios.ListaPrecios precio)
        {
            string sentencia = "SP_UPD_LISTA_PRECIOS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("earticulo_id", precio.ARTICULO_ID);
                    cmd.Parameters.Add("esucursal_id", precio.SUCURSAL_ID);
                    cmd.Parameters.Add("eprecio_venta", precio.PRECIO_VENTA);
                    cmd.Parameters.Add("eprecio_venta_max", precio.PRECIO_VENTA_MAX);
                    cmd.Parameters.Add("eprecio_venta_farm", precio.PRECIO_VENTA_FARM);
                    cmd.Parameters.Add("eprecio_costo", precio.PRECIO_COSTO);
                    cmd.Parameters.Add("ecosto_prom", precio.COSTO_PROM);
                    cmd.Parameters.Add("ecosto_ult_compra", precio.COSTO_ULT_COMPRA);
                    cmd.Parameters.Add("efecha_alta", precio.FECHA_ALTA);
                    DateTime? fBaja = null;
if(precio.FECHA_BAJA != new DateTime() && precio.FECHA_ALTA < precio.FECHA_BAJA)
{
    fBaja = precio.FECHA_BAJA;
}
                    cmd.Parameters.Add("efecha_baja", fBaja);
                    cmd.Parameters.Add("eimp_compra", precio.IMP_COMPRA);
                    cmd.Parameters.Add("eimp_venta", precio.IMP_VENTA);
                    cmd.Parameters.Add("eactivo", (char)precio.ACTIVO);

                    //parametros del array para detalle
                    // IN ARRAY PARAMETERS

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("OutParam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

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
                                throw new Exception("Ha ocurrido un error al insertar el registro" + id.ToString());
                            }

                            //modelo. = int.Parse(id.ToString());
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

        internal static bool ActualizaPMP(SIFModelo.Inventarios.ListaPrecios modelo, string pUltUsuarioId)
        {
            string sentencia = "UPDATE lista_precios SET precio_venta_max =:p_pmp, ult_user= :p_ult_user ";
            sentencia += " WHERE articulo_id = :p_articulo_id AND sucursal_id = :p_sucursal_id ";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("p_articulo_id", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("p_sucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("p_pmp", modelo.PRECIO_VENTA_MAX);
                    cmd.Parameters.Add("p_ult_user", pUltUsuarioId);

                    try
                    {
                        cmd.Connection.Open();

                        cmd.ExecuteScalar();
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

        internal static bool ActualizaPrecioFleming(SIFModelo.Inventarios.ListaPrecios modelo,  string pUltUsuarioId)
        {
            string sentencia = "UPDATE lista_precios SET PRECIO_VENTA =:p_pf, ult_user= :p_ult_user ";
            sentencia += " WHERE articulo_id = :p_articulo_id AND sucursal_id = :p_sucursal_id ";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("p_articulo_id", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("p_sucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("p_pf", modelo.PRECIO_VENTA);
                    cmd.Parameters.Add("p_ult_user", pUltUsuarioId);

                    try
                    {
                        cmd.Connection.Open();

                        cmd.ExecuteScalar();
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
