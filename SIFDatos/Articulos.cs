using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using static SIFModelo.WebServices.MRespuestas;

namespace SIFDatos
{
    public static class Articulos
    {
        /// <summary>
        /// Utiliza el SP_INS_Articulo para agregar un Articulo
        /// </summary>
        /// <param name="modelo">La instancia del Articulo</param>
        /// <returns>bool Insertado</returns>
        /// 
        public static SIFModelo.Inventarios.Inventario InventarioPorArticulo(SIFModelo.Articulo art)
        {
            //List<SIFModelo.Inventarios.Inventario> InventariosList = new List<SIFModelo.Inventarios.Inventario>();
            string sentencia = "SELECT ARTICULO_ID, " +
                                       "SUCURSAL_ID, " +
                                       "EXISTENCIA_MIN, " +
                                       "EXISTENCIA_MAX, " +
                                       "INV_FISICO, " +
                                       "EXISTENCIAS, " +
                                       "PUNTO_DE_REORDEN " +
                                "FROM INVENTARIO " +
                                "WHERE ARTICULO_ID = :ID_ART";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    object precio = "0";
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //parametros
                        cmd.Parameters.Add("ID_ART", art.ARTICULO_ID);
                        //
                        cmd.Connection.Open();
                        precio = cmd.ExecuteScalar();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Inventarios.Inventario registro = new SIFModelo.Inventarios.Inventario();

                                registro.ArticuloID = oreader["ARTICULO_ID"].ToString();
                                registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.ExistenciasMinimas = int.Parse(oreader["EXISTENCIA_MIN"].ToString());
                                registro.ExistenciasMaximas = int.Parse(oreader["EXISTENCIA_MAX"].ToString());
                                registro.Existencias = int.Parse(oreader["EXISTENCIAS"].ToString());
                                registro.PuntoDeReorden = int.Parse(oreader["PUNTO_DE_REORDEN"].ToString());
                                registro.InventarioFisico = int.Parse(oreader["INV_FISICO"].ToString());

                                return registro;
                                //InventariosList.Add(registro);
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
        public static bool Inserta(SIFModelo.Articulo modelo)
        {
            string sentencia = "sp_ins_cat_articulos";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("articulo_id", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("tipo_moneda", modelo.TIPO_MONEDA);
                    cmd.Parameters.Add("nombre1", modelo.NOMBRE1);
                    cmd.Parameters.Add("nombre2", modelo.NOMBRE2);
                    cmd.Parameters.Add("tipo_medicamento_cve", modelo.TIPO_MEDICAMENTO_CVE);
                    cmd.Parameters.Add("laboratorio_id", modelo.LABORATORIO_ID);
                    cmd.Parameters.Add("proveedor_id", modelo.PROVEEDOR_ID);
                    cmd.Parameters.Add("u_compra", modelo.U_COMPRA);
                    cmd.Parameters.Add("u_venta", modelo.U_VENTA);
                    cmd.Parameters.Add("lista_sucursal_vta", modelo.LISTA_SUCURSAL_VTA);
                    cmd.Parameters.Add("paquete", System.Convert.ToChar(modelo.PAQUETE));

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

        public static bool Elimina(SIFModelo.Articulo modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_Articulo";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("ID", modelo.ARTICULO_ID);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteReader();

                        //modelo.ID = 10;

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

        public static bool Actualiza(SIFModelo.Articulo modelo)
        {
            string sentencia = "sp_upd_cat_articulos";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("earticulo_id", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("etipo_moneda", modelo.TIPO_MONEDA);
                    cmd.Parameters.Add("enombre1", modelo.NOMBRE1);
                    cmd.Parameters.Add("enombre2", modelo.NOMBRE2);
                    cmd.Parameters.Add("etipo_medicamento_cve", modelo.TIPO_MEDICAMENTO_CVE);
                    cmd.Parameters.Add("elaboratorio_id", modelo.LABORATORIO_ID);
                    cmd.Parameters.Add("eproveedor_id", modelo.PROVEEDOR_ID);
                    cmd.Parameters.Add("eu_compra", modelo.U_COMPRA);
                    cmd.Parameters.Add("eu_venta", modelo.U_VENTA);
                    cmd.Parameters.Add("elista_sucursal_vta", modelo.LISTA_SUCURSAL_VTA);
                    cmd.Parameters.Add("epaquete", System.Convert.ToChar(modelo.PAQUETE));
                    cmd.Parameters.Add("eactivo", System.Convert.ToChar(modelo.ACTIVO));

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
                        id = outparam.Value;
                        if (!id.ToString().IsIntegerPositive())
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

        public static List<SIFModelo.ArticuloBaja> BuscaX(string propiedad, string parametro)
        {
            List<SIFModelo.ArticuloBaja> rows = new List<SIFModelo.ArticuloBaja>();

            string sentencia = "SELECT A.ARTICULO_ID, A.ACTIVO, A.NOMBRE1, A.NOMBRE2, A.LABORATORIO_ID , C.NOMBRE LABORATORIO  FROM cat_articulos  A, CAT_CLIENTES C WHERE A.ACTIVO in('N','D') AND A.PROVEEDOR_ID=C.CLIENTES_ID ";

            if (!string.IsNullOrEmpty(propiedad) && !string.IsNullOrEmpty(parametro))
            {
                //sentencia += " AND " + propiedad + " LIKE '%" + parametro.ToUpper() + "%'";
                sentencia += " AND (A.NOMBRE1 LIKE '%" + parametro.ToUpper() + "%' OR A.ARTICULO_ID LIKE '%" + parametro.ToUpper() + "%' OR A.NOMBRE2 LIKE '%" + parametro.ToUpper() + "%' OR A.PROVEEDOR_ID LIKE '%" + parametro.ToUpper() + "%' OR C.CLIENTES_ID LIKE '%" + parametro.ToUpper() + "%' OR C.NOMBRE LIKE '%" + parametro.ToUpper() + "%')";
            }
            else
            {
                sentencia += " AND (A.NOMBRE1 LIKE '%" + parametro.ToUpper() + "%' OR A.ARTICULO_ID LIKE '%" + parametro.ToUpper() + "%' OR A.NOMBRE2 LIKE '%" + parametro.ToUpper() + "%' OR A.PROVEEDOR_ID LIKE '%" + parametro.ToUpper() + "%' OR C.CLIENTES_ID LIKE '%" + parametro.ToUpper() + "%' OR C.NOMBRE LIKE '%" + parametro.ToUpper() + "%')";
            }

            sentencia += " ORDER BY A.NOMBRE1 ASC";

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
                            SIFModelo.ArticuloBaja registro = new SIFModelo.ArticuloBaja();

                            registro.ARTICULO_ID = oreader["ARTICULO_ID"].ToString();
                           // registro.TIPO_MONEDA = int.Parse(oreader["TIPO_MONEDA"].ToString());
                            registro.NOMBRE1 = oreader["NOMBRE1"].ToString();
                            registro.NOMBRE2 = oreader["NOMBRE2"].ToString();
                            registro.LABORATORIO_NOMBRE = oreader["LABORATORIO"].ToString();
                            //registro.TIPO_MEDICAMENTO_CVE = oreader["TIPO_MEDICAMENTO_CVE"].ToString();
                            var lab = oreader["LABORATORIO_ID"];
                            if (lab.ToString().IsInteger())
                            {
                                registro.LABORATORIO_ID = int.Parse(lab.ToString());
                            }
                           // registro.PROVEEDOR_ID = int.Parse(oreader["PROVEEDOR_ID"].ToString());
                         //   registro.U_COMPRA = oreader["U_COMPRA"].ToString();
                          //  registro.U_VENTA = oreader["U_VENTA"].ToString();
                         //   registro.LISTA_SUCURSAL_VTA = oreader["LISTA_SUCURSAL_VTA"].ToString();
                            if (!string.IsNullOrEmpty(oreader["ACTIVO"].ToString()))
                            {
                                if (oreader["ACTIVO"].ToString().Contains("S"))
                                    registro.ACTIVO = SIFModelo.Tipos.SiNo.SI;
                                else
                            {
                                registro.ACTIVO = SIFModelo.Tipos.SiNo.NO;
                            }
                            }
                            else
                            {
                                registro.ACTIVO = SIFModelo.Tipos.SiNo.NO;
                            }
                           // registro.VTA_SIN_EXISTENCIA = (SIFModelo.Tipos.SiNo)(oreader["VTA_SIN_EXISTENCIA"].ToString()[0]);
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

        public static List<SIFModelo.Articulo> Busca(string propiedad, string parametro, bool clienteMayorista)
        {
           List<SIFModelo.Articulo> rows = new List<SIFModelo.Articulo>();
            string sentencia = string.Empty;
            if (clienteMayorista)
            {
                sentencia= "SELECT    A.*,              L.Nombre Nombre_Laboratorio,       AM.proveedor_id PROVEEDOR_MAYORISTA ,     C.Nombre Nom_Pv,     NVL(CAH.ARTICULO_ID , 'N') CODIGO_CLI " +
                            "FROM Cat_Articulos A,  cs_CAT_CLIENTES_MAYORISTA C, cat_clientes l,                         CAT_ART_CLIENT_MAYORISTA am,      CS_ARTICULOS_HUP_SIF3 CAH" +
                            " WHERE A.Activo = 'S'    AND A.Proveedor_Id = L.Clientes_Id      AND C.clientes_Id = AM.PROVEEDOR_ID       AND A.ARTICULO_ID = am.articulo_id AND A.ARTICULO_ID =CAH.ARTICULO_ID(+) " +
                            " AND  am.PROVEEDOR_ID LIKE '%" + parametro.ToUpper()+ "' ORDER BY A.NOMBRE1 ASC";

                
            }
            else
            {
                /* sentencia = "SELECT A.*, L.NOMBRE NOMBRE_LABORATORIO, C.NOMBRE NOM_PV FROM cat_articulos  A, CAT_CLIENTES C, CAT_CLIENTES L WHERE A.ACTIVO='S' AND A.PROVEEDOR_ID=C.CLIENTES_ID AND A.LABORATORIO_ID = L.CLIENTES_ID";*/
                   sentencia =  "SELECT "
                                    + "a.*,     l.nombre    nombre_laboratorio,     c.nombre    nom_pv,     NVL(CAH.ARTICULO_ID , 'N') CODIGO_CLI  "
                                + "FROM "
                                    + "cat_articulos  a,     cat_clientes   c,     cat_clientes   l,     CS_ARTICULOS_HUP_SIF3 CAH  "
                                + "WHERE "
                                    + "a.activo = 'S'      "
                                    + "AND a.proveedor_id = c.clientes_id     AND A.ARTICULO_ID =CAH.ARTICULO_ID(+)      "
                                    + "AND a.laboratorio_id = l.clientes_id  ";


                if (!string.IsNullOrEmpty(propiedad) && !string.IsNullOrEmpty(parametro))
                {
                    //sentencia += " AND " + propiedad + " LIKE '%" + parametro.ToUpper() + "%'";
                    sentencia += " AND (A.NOMBRE1 LIKE '%" + parametro.ToUpper() + "%' OR A.ARTICULO_ID LIKE '%" + parametro.ToUpper() + "%' OR A.NOMBRE2 LIKE '%" + parametro.ToUpper() + "%' OR A.PROVEEDOR_ID LIKE '%" + parametro.ToUpper() + "%' OR C.CLIENTES_ID LIKE '%" + parametro.ToUpper() + "%' OR C.NOMBRE LIKE '%" + parametro.ToUpper() + "%')";
                }
                else
                {
                    sentencia += " AND (A.NOMBRE1 LIKE '%" + parametro.ToUpper() + "%' OR A.ARTICULO_ID LIKE '%" + parametro.ToUpper() + "%' OR A.NOMBRE2 LIKE '%" + parametro.ToUpper() + "%' OR A.PROVEEDOR_ID LIKE '%" + parametro.ToUpper() + "%' OR C.CLIENTES_ID LIKE '%" + parametro.ToUpper() + "%' OR C.NOMBRE LIKE '%" + parametro.ToUpper() + "%')";
                }

                sentencia += " ORDER BY A.NOMBRE1 ASC";
            }
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
                            SIFModelo.Articulo registro = new SIFModelo.Articulo();
                            registro.CODIGO_CLI = oreader["CODIGO_CLI"].ToString();
                            registro.ARTICULO_ID = oreader["ARTICULO_ID"].ToString();
                            registro.TIPO_MONEDA = int.Parse(oreader["TIPO_MONEDA"].ToString());
                            registro.NOMBRE1 = oreader["NOMBRE1"].ToString();
                            registro.NOMBRE2 = oreader["NOMBRE2"].ToString();
                            registro.TIPO_MEDICAMENTO_CVE = oreader["TIPO_MEDICAMENTO_CVE"].ToString();
                            var lab = oreader["LABORATORIO_ID"];
                            if (lab.ToString().IsInteger())
                            {
                                registro.LABORATORIO_ID = int.Parse(lab.ToString());
                            }
                            registro.PROVEEDOR_ID = int.Parse(oreader["PROVEEDOR_ID"].ToString());
                            registro.U_COMPRA = oreader["U_COMPRA"].ToString();
                            registro.U_VENTA = oreader["U_VENTA"].ToString();
                            registro.LISTA_SUCURSAL_VTA = oreader["LISTA_SUCURSAL_VTA"].ToString();
                            if (!string.IsNullOrEmpty(oreader["ACTIVO"].ToString()))
                            {
                                registro.PAQUETE = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                                registro.ACTIVO = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                            }
                            else
                            {
                                registro.PAQUETE = SIFModelo.Tipos.SiNo.NO;
                                registro.ACTIVO = SIFModelo.Tipos.SiNo.NO;
                            }
                            if (clienteMayorista)
                            {
                                registro.cMayorista = int.Parse(oreader["PROVEEDOR_MAYORISTA"].ToString());
                            }
                            registro.VTA_SIN_EXISTENCIA = (SIFModelo.Tipos.SiNo)(oreader["VTA_SIN_EXISTENCIA"].ToString()[0]);
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


        public static SIFModelo.Articulo ArticuloPorClave(string claveArticulo)
        {
            string sentencia = "SELECT * FROM cat_articulos WHERE ARTICULO_ID LIKE :Clave";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //parametros
                    cmd.Parameters.Add("Clave", claveArticulo);
                    //
                    OracleDataReader oreader = null;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Articulo registro = new SIFModelo.Articulo();

                                registro.ARTICULO_ID = oreader["ARTICULO_ID"].ToString();
                                registro.TIPO_MONEDA = int.Parse(oreader["TIPO_MONEDA"].ToString());
                                registro.NOMBRE1 = oreader["NOMBRE1"].ToString();
                                registro.NOMBRE2 = oreader["NOMBRE2"].ToString();
                                registro.TIPO_MEDICAMENTO_CVE = oreader["TIPO_MEDICAMENTO_CVE"].ToString();
                                if (oreader["LABORATORIO_ID"].ToString().IsInteger())
                                {
                                    registro.LABORATORIO_ID = int.Parse(oreader["LABORATORIO_ID"].ToString());
                                }
                                registro.PROVEEDOR_ID = int.Parse(oreader["PROVEEDOR_ID"].ToString());
                                registro.U_COMPRA = oreader["U_COMPRA"].ToString();
                                registro.U_VENTA = oreader["U_VENTA"].ToString();
                                registro.LISTA_SUCURSAL_VTA = oreader["LISTA_SUCURSAL_VTA"].ToString();
                                registro.PAQUETE = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                                registro.ACTIVO = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                                registro.VTA_SIN_EXISTENCIA = (SIFModelo.Tipos.SiNo)(oreader["VTA_SIN_EXISTENCIA"].ToString()[0]);
                                registro.FactorID = oreader["FACTOR_ID"].ToString();
                                return registro;
                            }
                        }


                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        if (oreader != null)
                            oreader.Close();
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }


                }

            }
            return null;
        }
        public static SIFModelo.Articulo ArticuloPorClaveSub(string claveArticulo, String articuloID, String ClienteID)
        {
            string sentencia;
            if (String.IsNullOrEmpty(articuloID))
            {
                articuloID = claveArticulo;
                sentencia = "SELECT        CAT_ARTICULOS_SUB.ID, CAT_ARTICULOS_SUB.CODIGOCLI, CAT_ARTICULOS_SUB.ARTICULO_ID, CAT_ARTICULOS.ACTIVO, CAT_ARTICULOS.TIPO_MONEDA, " +
                                "             CAT_ARTICULOS.NOMBRE1, CAT_ARTICULOS.NOMBRE2, CAT_ARTICULOS.TIPO_MEDICAMENTO_CVE, " +
                                "             CAT_ARTICULOS.PROVEEDOR_ID, CAT_ARTICULOS.LABORATORIO_ID, CAT_ARTICULOS.U_COMPRA, " +
                                "             CAT_ARTICULOS.U_VENTA, CAT_ARTICULOS.LISTA_SUCURSAL_VTA, CAT_ARTICULOS.PAQUETE, " +
                                "              CAT_ARTICULOS.FACTOR_ID, CAT_ARTICULOS.VTA_SIN_EXISTENCIA " +
                                " FROM            CAT_ARTICULOS INNER JOIN CAT_ARTICULOS_SUB ON CAT_ARTICULOS.ARTICULO_ID = CAT_ARTICULOS_SUB.ARTICULO_ID " +
                                " WHERE        ( (CAT_ARTICULOS_SUB.CODIGOCLI = :Clave or CAT_ARTICULOS_SUB.ARTICULO_ID = :ClaveID) and CAT_ARTICULOS_SUB.CLIENTE_ID=:Cliente) AND CAT_ARTICULOS_SUB.ACTIVO = 'S'";
            }
            else
            {
                sentencia = "SELECT        CAT_ARTICULOS_SUB.ID, CAT_ARTICULOS_SUB.CODIGOCLI, CAT_ARTICULOS_SUB.ARTICULO_ID, CAT_ARTICULOS.ACTIVO, CAT_ARTICULOS.TIPO_MONEDA, " +
                                "             CAT_ARTICULOS.NOMBRE1, CAT_ARTICULOS.NOMBRE2, CAT_ARTICULOS.TIPO_MEDICAMENTO_CVE, " +
                                "             CAT_ARTICULOS.PROVEEDOR_ID, CAT_ARTICULOS.LABORATORIO_ID, CAT_ARTICULOS.U_COMPRA, " +
                                "             CAT_ARTICULOS.U_VENTA, CAT_ARTICULOS.LISTA_SUCURSAL_VTA, CAT_ARTICULOS.PAQUETE, " +
                                "              CAT_ARTICULOS.FACTOR_ID, CAT_ARTICULOS.VTA_SIN_EXISTENCIA " +
                                " FROM            CAT_ARTICULOS INNER JOIN CAT_ARTICULOS_SUB ON CAT_ARTICULOS.ARTICULO_ID = CAT_ARTICULOS_SUB.ARTICULO_ID " +
                                " WHERE        ( (CAT_ARTICULOS_SUB.CODIGOCLI = :Clave and CAT_ARTICULOS_SUB.ARTICULO_ID = :ClaveID) and CAT_ARTICULOS_SUB.CLIENTE_ID=:Cliente) AND CAT_ARTICULOS_SUB.ACTIVO = 'S'";
            }

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //parametros
                        cmd.Parameters.Add("Clave", claveArticulo);
                        cmd.Parameters.Add("ClaveID", articuloID);
                        cmd.Parameters.Add("Cliente", ClienteID);
                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Articulo registro = new SIFModelo.Articulo();

                                registro.CODIGO_CLI_ID = System.Convert.ToInt32(oreader["ID"]);
                                registro.ARTICULO_ID = oreader["ARTICULO_ID"].ToString();
                                registro.CODIGO_CLI = oreader["CODIGOCLI"].ToString();
                                registro.TIPO_MONEDA = int.Parse(oreader["TIPO_MONEDA"].ToString());
                                registro.NOMBRE1 = oreader["NOMBRE1"].ToString();
                                registro.NOMBRE2 = oreader["NOMBRE2"].ToString();
                                registro.TIPO_MEDICAMENTO_CVE = oreader["TIPO_MEDICAMENTO_CVE"].ToString();
                                if (oreader["LABORATORIO_ID"].ToString().IsInteger())
                                {
                                    registro.LABORATORIO_ID = int.Parse(oreader["LABORATORIO_ID"].ToString());
                                }
                                registro.PROVEEDOR_ID = int.Parse(oreader["PROVEEDOR_ID"].ToString());
                                registro.U_COMPRA = oreader["U_COMPRA"].ToString();
                                registro.U_VENTA = oreader["U_VENTA"].ToString();
                                registro.LISTA_SUCURSAL_VTA = oreader["LISTA_SUCURSAL_VTA"].ToString();
                                registro.PAQUETE = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                                registro.ACTIVO = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                                registro.VTA_SIN_EXISTENCIA = (SIFModelo.Tipos.SiNo)(oreader["VTA_SIN_EXISTENCIA"].ToString()[0]);
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

        public static SIFModelo.Articulo ArticuloPorClaveSub(string claveArticulo, String ClienteID)
        {
            string sentencia = "SELECT        CAT_ARTICULOS_SUB.ID, CAT_ARTICULOS_SUB.CODIGOCLI, CAT_ARTICULOS_SUB.ARTICULO_ID, CAT_ARTICULOS.ACTIVO, CAT_ARTICULOS.TIPO_MONEDA, " +
                                "             CAT_ARTICULOS.NOMBRE1, CAT_ARTICULOS.NOMBRE2, CAT_ARTICULOS.TIPO_MEDICAMENTO_CVE, " +
                                "             CAT_ARTICULOS.PROVEEDOR_ID, CAT_ARTICULOS.LABORATORIO_ID, CAT_ARTICULOS.U_COMPRA, " +
                                "             CAT_ARTICULOS.U_VENTA, CAT_ARTICULOS.LISTA_SUCURSAL_VTA, CAT_ARTICULOS.PAQUETE, " +
                                "              CAT_ARTICULOS.FACTOR_ID, CAT_ARTICULOS.VTA_SIN_EXISTENCIA " +
                                " FROM            CAT_ARTICULOS INNER JOIN CAT_ARTICULOS_SUB ON CAT_ARTICULOS.ARTICULO_ID = CAT_ARTICULOS_SUB.ARTICULO_ID " +
                                " WHERE        ( (CAT_ARTICULOS_SUB.CODIGOCLI = :Clave OR CAT_ARTICULOS_SUB.ARTICULO_ID = :ClaveID) and CAT_ARTICULOS_SUB.CLIENTE_ID=:Cliente) AND CAT_ARTICULOS_SUB.ACTIVO = 'S'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //parametros
                    cmd.Parameters.Add("Clave", claveArticulo);
                    cmd.Parameters.Add("ClaveID", claveArticulo);
                    cmd.Parameters.Add("Cliente", ClienteID);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Articulo registro = new SIFModelo.Articulo();

                            registro.CODIGO_CLI_ID = System.Convert.ToInt32(oreader["ID"]);
                            registro.ARTICULO_ID = oreader["ARTICULO_ID"].ToString();
                            registro.CODIGO_CLI = oreader["CODIGOCLI"].ToString();
                            registro.TIPO_MONEDA = int.Parse(oreader["TIPO_MONEDA"].ToString());
                            registro.NOMBRE1 = oreader["NOMBRE1"].ToString();
                            registro.NOMBRE2 = oreader["NOMBRE2"].ToString();
                            registro.TIPO_MEDICAMENTO_CVE = oreader["TIPO_MEDICAMENTO_CVE"].ToString();
                            if (oreader["LABORATORIO_ID"].ToString().IsInteger())
                            {
                                registro.LABORATORIO_ID = int.Parse(oreader["LABORATORIO_ID"].ToString());
                            }
                            registro.PROVEEDOR_ID = int.Parse(oreader["PROVEEDOR_ID"].ToString());
                            registro.U_COMPRA = oreader["U_COMPRA"].ToString();
                            registro.U_VENTA = oreader["U_VENTA"].ToString();
                            registro.LISTA_SUCURSAL_VTA = oreader["LISTA_SUCURSAL_VTA"].ToString();
                            registro.PAQUETE = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                            registro.ACTIVO = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                            registro.VTA_SIN_EXISTENCIA = (SIFModelo.Tipos.SiNo)(oreader["VTA_SIN_EXISTENCIA"].ToString()[0]);
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

        public static decimal ArticuloPorClaveSubPrecio(string claveArticulo, String ClienteID)
        {
            string sentencia = "SELECT PRECIO FROM CAT_ARTICULOS_SUB " +
                                " WHERE   ( ARTICULO_ID = :Clave and CLIENTE_ID  = :Cliente) AND CAT_ARTICULOS_SUB.ACTIVO = 'S'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //parametros
                        cmd.Parameters.Add("Clave", claveArticulo);
                        //cmd.Parameters.Add("ClaveID", claveArticulo);
                        cmd.Parameters.Add("Cliente", ClienteID);
                        //
                        cmd.Connection.Open();
                        var precio = cmd.ExecuteScalar();
                        //OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        //if (oreader.HasRows)
                        //{
                        //    while (oreader.Read())
                        //    {
                        //SIFModelo.Articulo registro = new SIFModelo.Articulo();

                        //precio = oreader["precio"];

                        if (precio.ToString().IsFloat())
                        {
                            precio = decimal.Parse(precio.ToString());

                            return decimal.Parse(precio.ToString());
                        }

                        return 0;
                        //    }
                        //}

                    }
                }
                catch {

                }
                finally{

                    if (null != cnx)
                    {
                        cnx.Close();
                        cnx.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                }
            }
            return 0;
        }

        public static SIFModelo.Inventarios.ListaPrecios PrecioArticulo(string claveArticulo)
        {
            string sentencia = "SELECT * FROM lista_precios WHERE ARTICULO_ID = :Clave AND activo = 'S' ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    object precio = "0";
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //parametros
                        cmd.Parameters.Add("Clave", claveArticulo);
                        //
                        cmd.Connection.Open();
                        precio = cmd.ExecuteScalar();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Inventarios.ListaPrecios registro = new SIFModelo.Inventarios.ListaPrecios();

                                registro.ARTICULO_ID = oreader["ARTICULO_ID"].ToString();
                                registro.SUCURSAL_ID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.PRECIO_VENTA = decimal.Parse(oreader["PRECIO_VENTA"].ToString());
                                registro.PRECIO_VENTA_MAX = decimal.Parse(oreader["PRECIO_VENTA_MAX"].ToString());
                                registro.PRECIO_VENTA_FARM = decimal.Parse(oreader["PRECIO_VENTA_FARM"].ToString());
                                registro.PRECIO_COSTO = decimal.Parse(oreader["PRECIO_COSTO"].ToString());
                                registro.COSTO_PROM = decimal.Parse(oreader["COSTO_PROM"].ToString());
                                registro.COSTO_ULT_COMPRA = decimal.Parse(oreader["COSTO_ULT_COMPRA"].ToString());
                                registro.FECHA_ALTA = DateTime.Parse(oreader["FECHA_ALTA"].ToString());

                                var fechaBaja = oreader["FECHA_BAJA"];

                                if (fechaBaja.ToString().IsDatetime())
                                {
                                    registro.FECHA_BAJA = DateTime.Parse(fechaBaja.ToString());
                                }

                                registro.IMP_COMPRA = int.Parse(oreader["IMP_COMPRA"].ToString());
                                registro.IMP_VENTA = int.Parse(oreader["IMP_VENTA"].ToString());
                                registro.ACTIVO = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
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

        public static SIFModelo.Inventarios.ListaPrecios PrecioArticuloSub(string claveArticulo)
        {
            string sentencia = "SELECT        LISTA_PRECIOS.ARTICULO_ID, LISTA_PRECIOS.SUCURSAL_ID, LISTA_PRECIOS.PRECIO_VENTA, " +
                               " LISTA_PRECIOS.PRECIO_VENTA_MAX, LISTA_PRECIOS.PRECIO_VENTA_FARM, LISTA_PRECIOS.PRECIO_COSTO,  " +
                               " LISTA_PRECIOS.COSTO_PROM, LISTA_PRECIOS.COSTO_ULT_COMPRA, LISTA_PRECIOS.FECHA_ALTA,  " +
                               " LISTA_PRECIOS.FECHA_BAJA, LISTA_PRECIOS.IMP_COMPRA, LISTA_PRECIOS.IMP_VENTA, LISTA_PRECIOS.ACTIVO,  " +
                               " CAT_ARTICULOS_SUB.CODIGOCLI FROM  LISTA_PRECIOS INNER JOIN      CAT_ARTICULOS_SUB ON LISTA_PRECIOS.ARTICULO_ID = CAT_ARTICULOS_SUB.ARTICULO_ID  " +
                               " WHERE        (CAT_ARTICULOS_SUB.CODIGOCLI = :Clave) AND (LISTA_PRECIOS.ACTIVO = 'S') AND CAT_ARTICULOS_SUB.ACTIVO = 'S' ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                object precio = "0";
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    try
                    {
                        //parametros
                        cmd.Parameters.Add("Clave", claveArticulo);
                        //
                        cmd.Connection.Open();
                        precio = cmd.ExecuteScalar();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Inventarios.ListaPrecios registro = new SIFModelo.Inventarios.ListaPrecios();

                                registro.ARTICULO_ID = oreader["ARTICULO_ID"].ToString();
                                registro.SUCURSAL_ID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.PRECIO_VENTA = decimal.Parse(oreader["PRECIO_VENTA"].ToString());
                                registro.PRECIO_VENTA_MAX = decimal.Parse(oreader["PRECIO_VENTA_MAX"].ToString());
                                registro.PRECIO_VENTA_FARM = decimal.Parse(oreader["PRECIO_VENTA_FARM"].ToString());
                                registro.PRECIO_COSTO = decimal.Parse(oreader["PRECIO_COSTO"].ToString());
                                registro.COSTO_PROM = decimal.Parse(oreader["COSTO_PROM"].ToString());
                                registro.COSTO_ULT_COMPRA = decimal.Parse(oreader["COSTO_ULT_COMPRA"].ToString());
                                registro.FECHA_ALTA = DateTime.Parse(oreader["FECHA_ALTA"].ToString());

                                var fechaBaja = oreader["FECHA_BAJA"];

                                if (fechaBaja.ToString().IsDatetime())
                                {
                                    registro.FECHA_BAJA = DateTime.Parse(fechaBaja.ToString());
                                }

                                registro.IMP_COMPRA = int.Parse(oreader["IMP_COMPRA"].ToString());
                                registro.IMP_VENTA = int.Parse(oreader["IMP_VENTA"].ToString());
                                registro.ACTIVO = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                                return registro;
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
                    

            }
            return null;
        }
        public static SIFModelo.Inventarios.InventarioDataSet BuscaPorNombreCodigo(string parametroBusqueda, SIFModelo.Sucursal sucursal, string columna = "")
        {
            SIFModelo.Inventarios.InventarioDataSet ds = new SIFModelo.Inventarios.InventarioDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.Inventarios.InventarioDataSetTableAdapters.ARTICULO_INVENTARIOTableAdapter ta = new SIFModelo.Inventarios.InventarioDataSetTableAdapters.ARTICULO_INVENTARIOTableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;
                //ta2.CO

                if (columna == "TIPO_MEDICAMENTO_CVE")
                {
                    ta.FillByTipoMedicamento(ds.ARTICULO_INVENTARIO, parametroBusqueda.ToUpper(), sucursal.SucursalesID);
                }
                else
                {
                    ta.FillByCLAVE_NOMBRES(ds.ARTICULO_INVENTARIO, sucursal.SucursalesID, parametroBusqueda.ToUpper());
                }
            }

            return ds;
        }

        public static SIFModelo.Inventarios.InventarioDataSet BuscaPorNombreCodigoSub(string parametroBusqueda, SIFModelo.Sucursal sucursal, string columna = "")
        {
            SIFModelo.Inventarios.InventarioDataSet ds = new SIFModelo.Inventarios.InventarioDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.Inventarios.InventarioDataSetTableAdapters.ARTICULO_INVENTARIOTableAdapter ta = new SIFModelo.Inventarios.InventarioDataSetTableAdapters.ARTICULO_INVENTARIOTableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;

                if (columna == "TIPO_MEDICAMENTO_CVE")
                {
                    ta.FillByTipoMedicamento(ds.ARTICULO_INVENTARIO, parametroBusqueda.ToUpper(), sucursal.SucursalesID);
                }
                else
                {
                    ta.FillByCodeSubrog(ds.ARTICULO_INVENTARIO, sucursal.SucursalesID, parametroBusqueda.ToUpper());
                }
            }

            return ds;
        }


        public static SIFModelo.Inventarios.InventarioDataSet BuscaPorNombreCodigoActivo(string propiedadBusqueda, SIFModelo.Sucursal sucursal, string parametroBusqueda)
        {
            SIFModelo.Inventarios.InventarioDataSet ds = new SIFModelo.Inventarios.InventarioDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.Inventarios.InventarioDataSetTableAdapters.ARTICULO_INVENTARIOTableAdapter ta = new SIFModelo.Inventarios.InventarioDataSetTableAdapters.ARTICULO_INVENTARIOTableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;

                if (propiedadBusqueda == "TIPO_MEDICAMENTO_CVE")
                {
                    ta.FillByTipoMedicamentoActivo(ds.ARTICULO_INVENTARIO, parametroBusqueda.ToUpper(), sucursal.SucursalesID);
                }
                else
                {
                    ta.FillByCLAVE_NOMBES_ACTIVO(ds.ARTICULO_INVENTARIO, sucursal.SucursalesID, parametroBusqueda.ToUpper());
                }
            }

            return ds;
        }

        public static bool MasDeUnoPorClaveSub(string claveArticulo, string ClienteID)
        {
            string sentencia = "SELECT COUNT(*) AS ENCONTRADOS " +
                //"CAT_ARTICULOS_SUB.CODIGOCLI, CAT_ARTICULOS_SUB.ARTICULO_ID, CAT_ARTICULOS.ACTIVO, CAT_ARTICULOS.TIPO_MONEDA, " +
                //"             CAT_ARTICULOS.NOMBRE1, CAT_ARTICULOS.NOMBRE2, CAT_ARTICULOS.TIPO_MEDICAMENTO_CVE, " +
                //"             CAT_ARTICULOS.PROVEEDOR_ID, CAT_ARTICULOS.LABORATORIO_ID, CAT_ARTICULOS.U_COMPRA, " +
                //"             CAT_ARTICULOS.U_VENTA, CAT_ARTICULOS.LISTA_SUCURSAL_VTA, CAT_ARTICULOS.PAQUETE, " +
                //"              CAT_ARTICULOS.FACTOR_ID, CAT_ARTICULOS.VTA_SIN_EXISTENCIA " +
                                " FROM            CAT_ARTICULOS INNER JOIN CAT_ARTICULOS_SUB ON CAT_ARTICULOS.ARTICULO_ID = CAT_ARTICULOS_SUB.ARTICULO_ID " +
                                " WHERE        ( (CAT_ARTICULOS_SUB.CODIGOCLI = :Clave ) and CAT_ARTICULOS_SUB.CLIENTE_ID=:Cliente) AND CAT_ARTICULOS_SUB.ACTIVO = 'S'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //parametros
                        cmd.Parameters.Add("Clave", claveArticulo);
                        //cmd.Parameters.Add("ClaveID", claveArticulo);
                        cmd.Parameters.Add("Cliente", ClienteID);
                        //
                        cmd.Connection.Open();
                        var res = cmd.ExecuteScalar();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (res.ToString().IsInteger())
                        {
                            if (System.Convert.ToInt32(res) > 1)
                            {
                                return true;
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
            return false;
        }



        public static bool MasDeUnoPorArticuloSub(string claveArticulo, string ClienteID)
        {
            string sentencia = "SELECT COUNT(*) AS ENCONTRADOS " +
                //"CAT_ARTICULOS_SUB.CODIGOCLI, CAT_ARTICULOS_SUB.ARTICULO_ID, CAT_ARTICULOS.ACTIVO, CAT_ARTICULOS.TIPO_MONEDA, " +
                //"             CAT_ARTICULOS.NOMBRE1, CAT_ARTICULOS.NOMBRE2, CAT_ARTICULOS.TIPO_MEDICAMENTO_CVE, " +
                //"             CAT_ARTICULOS.PROVEEDOR_ID, CAT_ARTICULOS.LABORATORIO_ID, CAT_ARTICULOS.U_COMPRA, " +
                //"             CAT_ARTICULOS.U_VENTA, CAT_ARTICULOS.LISTA_SUCURSAL_VTA, CAT_ARTICULOS.PAQUETE, " +
                //"              CAT_ARTICULOS.FACTOR_ID, CAT_ARTICULOS.VTA_SIN_EXISTENCIA " +
                              " FROM            CAT_ARTICULOS INNER JOIN CAT_ARTICULOS_SUB ON CAT_ARTICULOS.ARTICULO_ID = CAT_ARTICULOS_SUB.ARTICULO_ID " +
                              " WHERE        ( (CAT_ARTICULOS_SUB.ARTICULO_ID = :Clave ) and CAT_ARTICULOS_SUB.CLIENTE_ID=:Cliente) AND CAT_ARTICULOS_SUB.ACTIVO = 'S'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //parametros
                        cmd.Parameters.Add("Clave", claveArticulo);
                        //cmd.Parameters.Add("ClaveID", claveArticulo);
                        cmd.Parameters.Add("Cliente", ClienteID);
                        //
                        cmd.Connection.Open();
                        var res = cmd.ExecuteScalar();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (res.ToString().IsInteger())
                        {
                            if (System.Convert.ToInt32(res) > 1)
                            {
                                return true;
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
            return false;
        }

        public static SIFModelo.Inventarios.InventarioDataSet BuscaPorNombreCodigoSubActivo(string parametroBusqueda, SIFModelo.Sucursal sucursal, string columna)
        {
            SIFModelo.Inventarios.InventarioDataSet ds = new SIFModelo.Inventarios.InventarioDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.Inventarios.InventarioDataSetTableAdapters.ARTICULO_INVENTARIOTableAdapter ta = new SIFModelo.Inventarios.InventarioDataSetTableAdapters.ARTICULO_INVENTARIOTableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;

                if (columna == "TIPO_MEDICAMENTO_CVE")
                {
                    ta.FillByTipoMedicamentoActivo(ds.ARTICULO_INVENTARIO, parametroBusqueda.ToUpper(), sucursal.SucursalesID);
                }
                else
                {
                    ta.FillByCodeSubrogActivo(ds.ARTICULO_INVENTARIO, sucursal.SucursalesID, parametroBusqueda.ToUpper());
                }
            }

            return ds;
        }

        public static bool ActualizaPMP(SIFModelo.Inventarios.ListaPrecios precio , string pUltUsuariIid)
        {
            return SIFDatos.Inventario.Inventario.ActualizaPMP(precio, pUltUsuariIid);
        }

        public static bool ActualizaPFleming(SIFModelo.Inventarios.ListaPrecios precio,  string pUltUsuarioId)
        {
            return SIFDatos.Inventario.Inventario.ActualizaPrecioFleming(precio, pUltUsuarioId);
        }

        public static SIFModelo.Inventarios.InventarioDataSet BuscarPorComprador(string listaComprador)
        {
            throw new NotImplementedException();
        }

        public static bool ActualizaCodigo(string ArticuloID, string Clave)
        {
            object id;
            string sentencia = "UPDATE cat_articulos SET articulo_id = '" + Clave + "' WHERE articulo_id = '" + ArticuloID + "'";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
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
            return true;
        }

        public static bool ActualizaPFarmacia(SIFModelo.Inventarios.ListaPrecios modelo, string pUltUsuarioId)
        {
            string sentencia = "UPDATE lista_precios SET PRECIO_VENTA_FARM =:p_pmp, ult_user=:p_ult_usr ";
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
                    cmd.Parameters.Add("p_pmp", modelo.PRECIO_VENTA_FARM);
                    cmd.Parameters.Add("p_ult_usr", pUltUsuarioId);

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


        /// <summary>
        /// AVM 20-08-2015
        /// Retorna la existencia actual y la ubicaion del articulo.
        /// </summary>
        /// <param name="idArticulo">identificador del articulo</param>
        /// <returns></returns>
        public static SIFModelo.Inventarios.Inventario ExistencuiaUbicacionArticulo(string ID_ART)
        {
            string sentencia = "SELECT * FROM CS_UBICACIONES WHERE ARTICULO_ID = :ID_ART";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //parametros
                        cmd.Parameters.Add("ID_ART", ID_ART);
                        //
                        cmd.Connection.Open();
                        //precio = cmd.ExecuteScalar();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Inventarios.Inventario registro = new SIFModelo.Inventarios.Inventario();

                                registro.ArticuloID = oreader["ARTICULO_ID"].ToString();
                                registro.fila = oreader["FILA"].ToString();
                                registro.anaquel = oreader["ANAQUEL"].ToString();
                                registro.nivel = oreader["NIVEL"].ToString();
                                registro.Existencias = int.Parse(oreader["EXISTENCIAS"].ToString());

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

        public static Double maxBytesImg()
        {
            string sentencia = "SELECT MAX_BYTES_IMG from cs_max_bytes_img_articulos";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Connection.Open();
                        var res = cmd.ExecuteScalar();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                        if (res.ToString().IsInteger())
                        {
                            if (System.Convert.ToDouble(res) > 0)
                                return Convert.ToDouble(res.ToString());
                            else
                                return 0;
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
            return 0;
        }

        public static bool BuscaSiEsHupSif3(string propiedad)
        {
                string sentencia = " select count (*) cnt  from CS_ARTICULOS_HUP_SIF3 where articulo_id ='"+propiedad+"'";


            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
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
                                int r = Convert.ToInt16(oreader["CNT"].ToString());
                                if (r > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }

                    }
                }
                catch
                {
                }
                finally
                {
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

        public static SIFModelo.Articulo ArticuloPorClaveActiva(string claveArticulo)
        {
            string sentencia = "SELECT * FROM cat_articulos WHERE ARTICULO_ID LIKE :Clave and activo ='S'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //parametros
                    cmd.Parameters.Add("Clave", claveArticulo);
                    //
                    OracleDataReader oreader = null;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Articulo registro = new SIFModelo.Articulo();

                                registro.ARTICULO_ID = oreader["ARTICULO_ID"].ToString();
                                registro.TIPO_MONEDA = int.Parse(oreader["TIPO_MONEDA"].ToString());
                                registro.NOMBRE1 = oreader["NOMBRE1"].ToString();
                                registro.NOMBRE2 = oreader["NOMBRE2"].ToString();
                                registro.TIPO_MEDICAMENTO_CVE = oreader["TIPO_MEDICAMENTO_CVE"].ToString();
                                if (oreader["LABORATORIO_ID"].ToString().IsInteger())
                                {
                                    registro.LABORATORIO_ID = int.Parse(oreader["LABORATORIO_ID"].ToString());
                                }
                                registro.PROVEEDOR_ID = int.Parse(oreader["PROVEEDOR_ID"].ToString());
                                registro.U_COMPRA = oreader["U_COMPRA"].ToString();
                                registro.U_VENTA = oreader["U_VENTA"].ToString();
                                registro.LISTA_SUCURSAL_VTA = oreader["LISTA_SUCURSAL_VTA"].ToString();
                                registro.PAQUETE = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                                registro.ACTIVO = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                                registro.VTA_SIN_EXISTENCIA = (SIFModelo.Tipos.SiNo)(oreader["VTA_SIN_EXISTENCIA"].ToString()[0]);
                                registro.FactorID = oreader["FACTOR_ID"].ToString();
                                return registro;
                            }
                        }


                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        if (oreader != null)
                            oreader.Close();
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }


                }

            }
            return null;
        }

        public static List<string>  ClavesNoValidas()
        {
            string sentencia = "SELECT * FROM claves_no_validas";
            List<string> registros = new List<string>();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    
                    //
                    OracleDataReader oreader = null;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                registros.Add(oreader["CLAVE"].ToString()); 
                            }
                            return registros;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        if (oreader != null)
                            oreader.Close();
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                        //OracleConnection.ClearPool(cnx);
                    }


                }

            }
            return null;
        }


        public static string Actualiza_Sif3(string Usuario_id)
        {
            string sentencia = "ACTUALIZACION_SIF3_2023";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;
                    cmd.Parameters.Add("P_USUARIO_ID", Usuario_id);
                    //PARAMETROS

                    OracleParameter outparam = new OracleParameter("OUTPARAM", OracleDbType.Varchar2);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    outparam.Size = 1000;
                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        var id = outparam.Value;
                        return id.ToString();
                    }
                    catch (Exception ex)
                    {
                        return ex.ToString();
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

        public static String ActualizacionTL()
        {
            String resultado = string.Empty;
            try
            {

                SIFModelo.Configuracion.configApiTL datos;
                datos = SIFDatos.WebServices.ApiTL.Control("ACTUALIZACION_TL");
                string url = datos.URI;
                string apiKey = datos.KEY;

                // Creamos la petición manual
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Timeout = 1000000;
                request.ReadWriteTimeout = 1000000;

                // Configuramos los Headers
                request.Headers.Add(datos.USER, apiKey);
                request.ContentType = "application/json";
                request.ContentLength = 0;
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;

                // Obtenemos la respuesta
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string jsonResponse = reader.ReadToEnd();
                        RespuestaApi miRespuesta = JsonConvert.DeserializeObject<RespuestaApi>(jsonResponse);

                        if (miRespuesta.status == "SUCCESS")
                        {
                            // Ejemplo 1: Mostrar el mensaje general
                            resultado = miRespuesta.status + "-" + miRespuesta.message;



                        }
                        else
                        {
                            resultado = "La API respondió con error: " + miRespuesta.message;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Manejo de errores específicos de red (404, 500, etc.)
                if (ex.Status == WebExceptionStatus.Timeout)
                {
                    resultado = "Error: El servidor tardó demasiado en responder (Timeout).";
                }
                else
                if (ex.Response != null)
                {
                    using (StreamReader errorReader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        resultado = "Error del servidor: " + errorReader.ReadToEnd();
                    }
                }
                else
                {
                    resultado = "Error de conexión: " + ex.Message;
                }
            }
            catch (Exception ex)
            {
                resultado = "Error inesperado: " + ex.Message;
            }

            return resultado;
        }



    }
}
