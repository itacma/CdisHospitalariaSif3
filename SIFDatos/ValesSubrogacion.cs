using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
namespace SIFDatos
{
    public static class ValesSubrogacion
    {
        /// <summary>
        /// Utiliza el SP_INS_Caja para agregar un Caja
        /// </summary>
        /// <param name="modelo">La instancia del Caja</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.Valesubrogacion modelo)
        {
            string sentencia = "SP_INS_REMISION_VALE";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalId);
                    cmd.Parameters.Add("NoRemision", modelo.NoRemision);
                    cmd.Parameters.Add("Novale", modelo.NoVale);
                    cmd.Parameters.Add("FechaVale", modelo.FechaVale);
                    cmd.Parameters.Add("TipoVale", modelo.Tipo);

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
                                throw new Exception("Ha ocurrido un error al insertar el registro" + id.ToString());
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

        public static bool Actualiza(SIFModelo.Valesubrogacion modelo)
        {
            string sentencia = "sp_upd_remision_vale";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("eid", modelo.ID);
                    cmd.Parameters.Add("esucursal_id", modelo.SucursalId);
                    cmd.Parameters.Add("enum_vale", modelo.NoVale);
                    cmd.Parameters.Add("enum_remision", modelo.NoRemision);
                    cmd.Parameters.Add("efecha_vale", modelo.FechaVale);
                    cmd.Parameters.Add("efecha_recepcion", modelo.FechaRecepcion);
                    cmd.Parameters.Add("etipo_vale", modelo.Tipo);

                    //cmd.Parameters.Add("eactivo", (char)modelo.Activo);
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


        public static SIFModelo.Valesubrogacion BuscarPorRemisionActivo(SIFModelo.Valesubrogacion vale)
        {
            List<SIFModelo.Caja> rows = new List<SIFModelo.Caja>();

            string sentencia = "SELECT * FROM remision_vale WHERE num_remision = '" + vale.NoRemision + "'";

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
                                SIFModelo.Valesubrogacion registro = new SIFModelo.Valesubrogacion();

                                var fechaRecepcion = oreader["FECHA_RECEPCION"];
                                if (fechaRecepcion.ToString().IsDatetime())
                                    registro.FechaRecepcion = System.Convert.ToDateTime(oreader["FECHA_RECEPCION"]);
                                var fechaVale = oreader["FECHA_VALE"];
                                if (fechaVale.ToString().IsDatetime())
                                    registro.FechaVale = System.Convert.ToDateTime(oreader["FECHA_VALE"]);
                                registro.ID = int.Parse(oreader["ID"].ToString());
                                registro.NoRemision = oreader["NUM_REMISION"].ToString();
                                registro.NoVale = oreader["NUM_VALE"].ToString();
                                registro.SucursalId = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.Tipo = oreader["TIPO_VALE"].ToString();
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

        public static List<SIFModelo.Valesubrogacion> Buscar(string parametros)
        {
            List<SIFModelo.Valesubrogacion> rows = new List<SIFModelo.Valesubrogacion>();

            string sentencia = "SELECT * FROM remision_vale WHERE num_remision LIKE '%" + parametros + "%' OR NUM_VALE LIKE '%" + parametros + "%' OR TIPO_VALE LIKE '%" + parametros + "%'";

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
                            SIFModelo.Valesubrogacion registro = new SIFModelo.Valesubrogacion();

                            registro.ID = int.Parse(oreader["ID"].ToString());
                            registro.NoRemision = oreader["NUM_REMISION"].ToString();
                            registro.NoVale = oreader["NUM_VALE"].ToString();
                            registro.SucursalId = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.Tipo = oreader["TIPO_VALE"].ToString();

                            var fechaRecepcion = oreader["FECHA_RECEPCION"];
                            if (fechaRecepcion.ToString().IsDatetime())
                                registro.FechaRecepcion = System.Convert.ToDateTime(oreader["FECHA_RECEPCION"]);
                            var fechaVale = oreader["FECHA_VALE"];
                            if (fechaVale.ToString().IsDatetime())
                                registro.FechaVale = System.Convert.ToDateTime(oreader["FECHA_VALE"]);

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
    }
}
