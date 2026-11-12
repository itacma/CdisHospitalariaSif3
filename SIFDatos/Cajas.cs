using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
namespace SIFDatos
{
    public static class Cajas
    {
        /// <summary>
        /// Utiliza el SP_INS_Caja para agregar un Caja
        /// </summary>
        /// <param name="modelo">La instancia del Caja</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.Caja modelo)
        {
            string sentencia = "SP_INS_CAT_CAJAS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("nombre", modelo.Nombre);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();

                        var id = cmd.ExecuteScalar();
                        //if (id.ToString().IsIntegerPositive())
                        //{
                        //Caja.Id = int.Parse(id.ToString());
                        //}
                        if (id.ToString().IsInteger())
                        {
                            if (int.Parse(id.ToString()) < 0)
                            {
                                throw new Exception("Ha ocurrido un error al insetrar el registro" + id.ToString());
                            }
                            modelo.ID = int.Parse(id.ToString());
                        }
                        else
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

        public static bool Elimina(SIFModelo.Caja modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_CAT_CAJAS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("ID", modelo.ID);

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

        public static bool Actualiza(SIFModelo.Caja modelo)
        {
            string sentencia = "SP_UPD_CAT_CAJAS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("eid", modelo.ID);
                    cmd.Parameters.Add("esucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("enombre", modelo.Nombre);
                    cmd.Parameters.Add("eactivo", (char)modelo.Activo);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
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

        public static List<SIFModelo.Caja> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.Caja> rows = new List<SIFModelo.Caja>();

            string sentencia = "SELECT * FROM cat_cajas";

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
                            SIFModelo.Caja registro = new SIFModelo.Caja();

                            registro.ID = System.Convert.ToInt32(oreader["CAJAS_ID"]);
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Activo = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());

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

        public static List<SIFModelo.Caja> BuscarPorSucursalActivo(SIFModelo.Sucursal sucursal)
        {
            List<SIFModelo.Caja> rows = new List<SIFModelo.Caja>();

            string sentencia = "SELECT * FROM cat_cajas WHERE activo = 'S' AND SUCURSAL_ID = " + sucursal.SucursalesID;

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
                            SIFModelo.Caja registro = new SIFModelo.Caja();

                            registro.ID = System.Convert.ToInt32(oreader["CAJAS_ID"]);
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Activo = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());

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

        public static bool IniciaTurno(SIFModelo.Caja modelo)
        {
            string sentencia = "sp_ins_control_cajas";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("caja_id", modelo.ID);
                    cmd.Parameters.Add("cajero_id", modelo.CajeroID);
                    cmd.Parameters.Add("fecha_apertura", modelo.FechaApertura);
                    cmd.Parameters.Add("fecha_cierre", modelo.FechaCierre);
                    cmd.Parameters.Add("monto_inicial", modelo.MontoInicial);
                    cmd.Parameters.Add("activo", (char)modelo.Abierto);

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

                            modelo.ID = int.Parse(id.ToString());
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

        //public bool TurnoIniciado(SIFModelo.Caja caja)
        //{
        //    List<SIFModelo.Caja> rows = new List<SIFModelo.Caja>();

        //    string sentencia = "SELECT * FROM CONTROL_CAJAS ";

        //    using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
        //    {

        //        using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
        //        {
        //            //
        //            cmd.Connection.Open();
        //            cmd.ExecuteNonQuery();
        //            OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

        //            if (oreader.HasRows)
        //            {
        //                while (oreader.Read())
        //                {
        //                    SIFModelo.Caja registro = new SIFModelo.Caja();

        //                    registro.ID = System.Convert.ToInt32(oreader["CAJA_ID"]);
        //                    registro.Nombre = oreader["NOMBRE"].ToString();
        //                    registro.Activo = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
        //                    registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());

        //                    rows.Add(registro);
        //                }
        //            }

        //        }

        //    }
        //    return rows;
        //}

        public static List<SIFModelo.Caja> BuscaControl(SIFModelo.Sucursal sucursal, DateTime fechaInicio, DateTime fechaFin)
        {
            List<SIFModelo.Caja> rows = new List<SIFModelo.Caja>();

            string sentencia = "SELECT o.id as CONTROL_ID,  o.SUCURSAL_ID, o.CAJA_ID, o.CAJERO_ID,o.FECHA_APERTURA,o.FECHA_CIERRE,o.MONTO_INICIAL,o.ACTIVO,j.NOMBRE as NOMBRE_CAJA ,u.NOMBRE as NOMBRE_USUARIO, u.APELLIDOS as APELLIDOS_USUARIO  FROM CONTROL_CAJAS o " +
" JOIN  CAT_CAJAS j " +
" ON (J.CAJAS_ID = o.caja_id) " +
" JOIN CAT_USUARIOS u " +
" ON  (o.CAJERO_ID = u.usuarios_id) " +
" WHERE  o.SUCURSAL_ID = :SucursalID ";

            sentencia += " AND o.FECHA_APERTURA >= TO_DATE('" + fechaInicio.ToString("yyyy/MM/dd HH:mm:ss") + "', 'YYYY/MM/DD HH24:MI:SS') " +
               " AND o.FECHA_APERTURA <= TO_DATE('" + fechaFin.ToString("yyyy/MM/dd HH:mm:ss") + "', 'YYYY/MM/DD HH24:MI:SS') ";

            sentencia += " ORDER BY FECHA_APERTURA DESC ";

            //o.activo = 'A' AND MODIFICADO PARA EL CORTE DE CAJA
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalID", sucursal.SucursalesID);
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable("dt");
                    da.Fill(dt);

                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Caja registro = new SIFModelo.Caja();

                            registro.ID = System.Convert.ToInt32(oreader["CAJA_ID"]);
                            registro.CajeroID = System.Convert.ToInt32(oreader["CAJERO_ID"]);
                            registro.Nombre = oreader["NOMBRE_CAJA"].ToString();
                            registro.NombreUsuario = oreader["NOMBRE_USUARIO"].ToString();
                            registro.Abierto = (SIFModelo.Tipos.AbiertoCerrado)(oreader["ACTIVO"].ToString()[0]);
                            registro.MontoInicial = System.Convert.ToDecimal(oreader["MONTO_INICIAL"].ToString());
                            registro.FechaApertura = System.DateTime.Parse(oreader["FECHA_APERTURA"].ToString());
                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.ControlCajaID = int.Parse(oreader["CONTROL_ID"].ToString());
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

        public static SIFModelo.Tipos.AbiertoCerrado StatusCaja(SIFModelo.Sucursal sucursal, SIFModelo.Caja caja)
        {
            List<SIFModelo.Caja> rows = new List<SIFModelo.Caja>();

            string sentencia = "SELECT  ACTIVO   FROM CONTROL_CAJAS  " +
" WHERE caja_id = :CajaId AND SUCURSAL_ID = :SucursalID AND ACTIVO = 'A'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Parameters.Add("CajaId", caja.ID);
                        cmd.Parameters.Add("SucursalID", sucursal.SucursalesID);
                        //
                        cmd.Connection.Open();


                        var resultado = cmd.ExecuteScalar();

                        if (resultado != null && resultado.ToString().Length == 1)
                        {
                            SIFModelo.Tipos.AbiertoCerrado cerradoAbierto = (SIFModelo.Tipos.AbiertoCerrado)resultado.ToString()[0];
                            return cerradoAbierto;
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
            return SIFModelo.Tipos.AbiertoCerrado.CERRADO;
        }

        public static bool CajaAbierta(SIFModelo.Sucursal sucursal, SIFModelo.Caja caja)
        {
            List<SIFModelo.Caja> rows = new List<SIFModelo.Caja>();

            string sentencia = "SELECT  ACTIVO   FROM CONTROL_CAJAS  " +
" WHERE trunc(fecha_apertura) like trunc(sysdate) and caja_id = :CajaId AND SUCURSAL_ID = :SucursalID AND ACTIVO = 'C'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Parameters.Add("CajaId", caja.ID);
                        cmd.Parameters.Add("SucursalID", sucursal.SucursalesID);
                        //
                        cmd.Connection.Open();


                        var resultado = cmd.ExecuteScalar();

                        if (resultado == null)
                        {
                            // SIFModelo.Tipos.AbiertoCerrado cerradoAbierto = (SIFModelo.Tipos.AbiertoCerrado)resultado.ToString()[0];
                            return true;
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
            return false;
        }

        public static SIFModelo.Caja CajaPorID(SIFModelo.Sucursal sucursal, SIFModelo.Caja caja)
        {
            List<SIFModelo.Caja> rows = new List<SIFModelo.Caja>();

            string sentencia = "SELECT  *   FROM CONTROL_CAJAS  " +
" WHERE caja_id = :CajaId AND SUCURSAL_ID = :SucursalID AND ACTIVO = 'A'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("CajaId", caja.ID);
                    cmd.Parameters.Add("SucursalID", sucursal.SucursalesID);
                    //
                    cmd.Connection.Open();


                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Caja registro = new SIFModelo.Caja();

                            registro.ID = System.Convert.ToInt32(oreader["CAJA_ID"]);
                            registro.CajeroID = System.Convert.ToInt32(oreader["CAJERO_ID"]);
                            //registro.Nombre = oreader["NOMBRE_CAJA"].ToString();
                            //registro.NombreUsuario = oreader["NOMBRE_USUARIO"].ToString();
                            registro.Abierto = (SIFModelo.Tipos.AbiertoCerrado)(oreader["ACTIVO"].ToString()[0]);
                            registro.MontoInicial = System.Convert.ToDecimal(oreader["MONTO_INICIAL"].ToString());
                            registro.FechaApertura = System.DateTime.Parse(oreader["FECHA_APERTURA"].ToString());
                            var fechaCierre = oreader["FECHA_CIERRE"];
                            if (fechaCierre.ToString().IsDatetime())
                            {
                                registro.FechaCierre = System.DateTime.Parse(oreader["FECHA_CIERRE"].ToString());
                            }
                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.ControlCajaID = int.Parse(oreader["ID"].ToString());
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


        public static int UsuarioCaja(SIFModelo.Sucursal sucursal, SIFModelo.Caja caja)
        {
            List<SIFModelo.Caja> rows = new List<SIFModelo.Caja>();

            string sentencia = "SELECT  cajero_id   FROM CONTROL_CAJAS  " +
" WHERE caja_id = :CajaId AND SUCURSAL_ID = :SucursalID AND ACTIVO = 'A'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("CajaId", caja.ID);
                    cmd.Parameters.Add("SucursalID", sucursal.SucursalesID);
                    //
                    cmd.Connection.Open();


                    var resultado = cmd.ExecuteScalar();

                    if (resultado != null && resultado.ToString().IsInteger())
                    {

                        return int.Parse(resultado.ToString());
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }
            return 0;
        }

        public static SIFModelo.Caja ControlControlCaja(SIFModelo.Sucursal sucursal, SIFModelo.Caja caja)
        {
            List<SIFModelo.Caja> rows = new List<SIFModelo.Caja>();

            string sentencia = "SELECT  *  FROM CONTROL_CAJAS  " +
" WHERE ID = :CONTRO_ID ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("CONTRO_ID", caja.ControlCajaID);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Caja registro = new SIFModelo.Caja();

                            registro.ID = System.Convert.ToInt32(oreader["CAJA_ID"]);
                            registro.CajeroID = System.Convert.ToInt32(oreader["CAJERO_ID"]);
                            //registro.Nombre = oreader["NOMBRE_CAJA"].ToString();
                            //registro.NombreUsuario = oreader["NOMBRE_USUARIO"].ToString();
                            registro.Abierto = (SIFModelo.Tipos.AbiertoCerrado)(oreader["ACTIVO"].ToString()[0]);
                            registro.MontoInicial = System.Convert.ToDecimal(oreader["MONTO_INICIAL"].ToString());
                            registro.FechaApertura = System.DateTime.Parse(oreader["FECHA_APERTURA"].ToString());
                            var fechaCierre = oreader["FECHA_CIERRE"];
                            if (fechaCierre.ToString().IsDatetime())
                            {
                                registro.FechaCierre = System.DateTime.Parse(oreader["FECHA_CIERRE"].ToString());
                            }
                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.ControlCajaID = int.Parse(oreader["ID"].ToString());
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

        public static bool ActualizaControl(SIFModelo.Caja modelo)
        {
            string sentencia = "sp_upd_control_cajas";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("esucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("ecaja_id", modelo.ID);
                    cmd.Parameters.Add("ecajero_id", modelo.CajeroID);
                    cmd.Parameters.Add("efecha_apertura", modelo.FechaApertura);
                    cmd.Parameters.Add("efecha_cierre", modelo.FechaCierre);
                    cmd.Parameters.Add("emonto_inicial", modelo.MontoInicial);
                    cmd.Parameters.Add("eactivo", (char)modelo.Abierto);

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

                            //  modelo.ID = int.Parse(id.ToString());
                        }
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
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

        //public static List<SIFModelo.Caja> BuscarPorSucursalActivo(SIFModelo.Sucursal sucursal)
        //{
        //    List<SIFModelo.Caja> rows = new List<SIFModelo.Caja>();

        //    string sentencia = "SELECT * FROM cat_cajas WHERE SUCURSAL_ID = :SucursalId";

        //    using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
        //    {

        //        using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
        //        {
        //            cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
        //            //
        //            cmd.Connection.Open();
        //            cmd.ExecuteNonQuery();
        //            OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

        //            if (oreader.HasRows)
        //            {
        //                while (oreader.Read())
        //                {
        //                    SIFModelo.Caja registro = new SIFModelo.Caja();

        //                    registro.ID = System.Convert.ToInt32(oreader["CAJAS_ID"]);
        //                    registro.Nombre = oreader["NOMBRE"].ToString();
        //                    registro.Activo = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
        //                    registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());

        //                    rows.Add(registro);
        //                }
        //            }

        //        }

        //    }
        //    return rows;
        //}

        public static SIFModelo.Ventas.CorteCajaDataSet.V_VALORESDataTable BuscaValores(SIFModelo.Caja caja, string fecha1, string fecha2, SIFModelo.Ventas.CorteCajaDataSet ds)
        {
            //SIFModelo.Ventas.CorteCajaDataSet ds = new SIFModelo.Ventas.CorteCajaDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.Ventas.CorteCajaDataSetTableAdapters.V_VALORESTableAdapter ta = new SIFModelo.Ventas.CorteCajaDataSetTableAdapters.V_VALORESTableAdapter();
                ta.Connection = cnx;
                ta.FillBySucursalCajaFecha(ds.V_VALORES, caja.SucursalID, caja.ID, fecha1, fecha2);
                //ta.FillByCajaSucursal(ds.V_VALORESDataTable,caja.SucursalID, caja.ID);
            }
            return ds.V_VALORES;
        }

        public static SIFModelo.Ventas.CorteCajaDataSet.V_VALORES_CONDENSADODataTable BuscaValoresCondensado(SIFModelo.Caja caja, string fecha1, string fecha2, SIFModelo.Ventas.CorteCajaDataSet ds)
        {
            //SIFModelo.Ventas.CorteCajaDataSet ds = new SIFModelo.Ventas.CorteCajaDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.Ventas.CorteCajaDataSetTableAdapters.V_VALORES_CONDENSADOTableAdapter ta = new SIFModelo.Ventas.CorteCajaDataSetTableAdapters.V_VALORES_CONDENSADOTableAdapter();
                ta.Connection = cnx;
                ta.FillByCajaSucursalFecha(ds.V_VALORES_CONDENSADO, caja.SucursalID, caja.ID, fecha1, fecha2);
                //ta.FillByCajaSucursal(ds.V_VALORESDataTable,caja.SucursalID, caja.ID);
            }
            return ds.V_VALORES_CONDENSADO;
        }

        public static SIFModelo.Ventas.CorteCajaDataSet.CORTE_CAJA_PAGOSDataTable CorteCajaPagos(SIFModelo.Caja caja, string fecha1, string fecha2, SIFModelo.Ventas.CorteCajaDataSet ds)
        {
            //SIFModelo.Ventas.CorteCajaDataSet ds = new SIFModelo.Ventas.CorteCajaDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.Ventas.CorteCajaDataSetTableAdapters.CORTE_CAJA_PAGOSTableAdapter ta = new SIFModelo.Ventas.CorteCajaDataSetTableAdapters.CORTE_CAJA_PAGOSTableAdapter();
                ta.Connection = cnx;
                ta.FillBy(ds.CORTE_CAJA_PAGOS, fecha1, caja.ID, caja.CajeroID, fecha2);
                //ta.FillByCajaSucursal(ds.V_VALORESDataTable,caja.SucursalID, caja.ID);
            }

            return ds.CORTE_CAJA_PAGOS;
        }
    }
}
