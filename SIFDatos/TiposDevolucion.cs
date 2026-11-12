using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
namespace SIFDatos
{
    public static class TipoDevolucions
    {
        /// <summary>
        /// Utiliza el SP_INS_TipoDevolucion para agregar un TipoDevolucion
        /// </summary>
        /// <param name="modelo">La instancia del TipoDevolucion</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.TipoDevolucion modelo)
        {
            string sentencia = "sp_ins_cat_tipo_devolucion";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nombre", modelo.Nombre);
                    cmd.Parameters.Add("compra_venta", System.Convert.ToChar(modelo.CompraVenta));

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

                            modelo.TipoDevolucionID = int.Parse(id.ToString());
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

        public static bool Elimina(SIFModelo.TipoDevolucion modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_TIPO_DEVOLUCION";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("ID", modelo.TipoDevolucionID);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

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

        public static bool Actualiza(SIFModelo.TipoDevolucion modelo)
        {
            string sentencia = "sp_upd_cat_tipo_devolucion";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("edev_id", modelo.TipoDevolucionID);
                    cmd.Parameters.Add("enom", modelo.Nombre);
                    cmd.Parameters.Add("eactivo", System.Convert.ToChar(modelo.Activo));
                    cmd.Parameters.Add("ecpra_vta", System.Convert.ToChar(modelo.CompraVenta));

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

        public static List<SIFModelo.TipoDevolucion> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.TipoDevolucion> rows = new List<SIFModelo.TipoDevolucion>();

            string sentencia = "SELECT * FROM CAT_TIPO_DEVOLUCION";

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
                                SIFModelo.TipoDevolucion registro = new SIFModelo.TipoDevolucion();

                                registro.TipoDevolucionID = int.Parse(oreader["TIPO_DEVOLUCION_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();
                                registro.Activo = (System.Convert.ToChar(oreader["ACTIVO"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);
                                registro.CompraVenta = (SIFModelo.Tipos.CompraVenta)(System.Convert.ToSByte(oreader["COMPRA_VENTA"].ToString()[0]));

                                rows.Add(registro);
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
            return rows;
        }


        public static List<SIFModelo.TipoDevolucion> BuscaCompra()
        {
            List<SIFModelo.TipoDevolucion> rows = new List<SIFModelo.TipoDevolucion>();

            // string sentencia = "SELECT * FROM CAT_TIPO_DEVOLUCION WHERE (COMPRA_VENTA LIKE 'V' OR  COMPRA_VENTA LIKE 'C') AND ACTIVO = 'S'";
            string sentencia = "SELECT * FROM CAT_TIPO_DEVOLUCION WHERE (COMPRA_VENTA LIKE 'C') AND ACTIVO = 'S'";

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
                            SIFModelo.TipoDevolucion registro = new SIFModelo.TipoDevolucion();

                            registro.TipoDevolucionID = int.Parse(oreader["TIPO_DEVOLUCION_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Activo = (System.Convert.ToChar(oreader["ACTIVO"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);
                            registro.CompraVenta = (SIFModelo.Tipos.CompraVenta)(System.Convert.ToSByte(oreader["COMPRA_VENTA"].ToString()[0]));

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

        public static List<SIFModelo.TipoDevolucion> BuscaVenta()
        {
            List<SIFModelo.TipoDevolucion> rows = new List<SIFModelo.TipoDevolucion>();

            string sentencia = "SELECT * FROM CAT_TIPO_DEVOLUCION WHERE (COMPRA_VENTA LIKE 'V' OR  COMPRA_VENTA LIKE 'A') AND ACTIVO = 'S'";

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
                            SIFModelo.TipoDevolucion registro = new SIFModelo.TipoDevolucion();

                            registro.TipoDevolucionID = int.Parse(oreader["TIPO_DEVOLUCION_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Activo = (System.Convert.ToChar(oreader["ACTIVO"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);
                            registro.CompraVenta = (SIFModelo.Tipos.CompraVenta)(System.Convert.ToSByte(oreader["COMPRA_VENTA"].ToString()[0]));

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

        public static List<SIFModelo.TipoDevolucion> BuscaTraspaso()
        {
            List<SIFModelo.TipoDevolucion> rows = new List<SIFModelo.TipoDevolucion>();

            string sentencia = "SELECT * FROM CAT_TIPO_DEVOLUCION WHERE COMPRA_VENTA LIKE 'T' AND ACTIVO = 'S'";

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
                            SIFModelo.TipoDevolucion registro = new SIFModelo.TipoDevolucion();

                            registro.TipoDevolucionID = int.Parse(oreader["TIPO_DEVOLUCION_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Activo = (System.Convert.ToChar(oreader["ACTIVO"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);
                            registro.CompraVenta = (SIFModelo.Tipos.CompraVenta)(System.Convert.ToSByte(oreader["COMPRA_VENTA"].ToString()[0]));

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
