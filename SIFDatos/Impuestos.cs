using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
namespace SIFDatos
{
    public static class Impuestos
    {
        /// <summary>
        /// Utiliza el SP_INS_Impuesto para agregar un Impuesto
        /// </summary>
        /// <param name="modelo">La instancia del Impuesto</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.Impuesto modelo)
        {
            string sentencia = "SP_INS_CAT_IMPUESTO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nombre", modelo.Nombre);
                    cmd.Parameters.Add("porcentaje", modelo.Porcentaje);
                    cmd.Parameters.Add("fec_vigencia_ini", modelo.VigenciaInicio);
                    cmd.Parameters.Add("fec_vigencia_fin", modelo.VigenciaInicio);

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

        public static bool Elimina(SIFModelo.Impuesto modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_IMPUESTO";
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
                        cmd.ExecuteReader();

                        modelo.ID = 10;

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

        public static bool Actualiza(SIFModelo.Impuesto modelo)
        {
            string sentencia = "SP_UPD_CAT_IMPUESTO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("eid", modelo.ID);
                    cmd.Parameters.Add("enombre", modelo.Nombre);
                    cmd.Parameters.Add("eporcentaje", modelo.Porcentaje);
                    cmd.Parameters.Add("efec_vigencia_ini", modelo.VigenciaInicio);
                    cmd.Parameters.Add("efec_vigencia_fin", modelo.VigenciaFin);

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

        public static List<SIFModelo.Impuesto> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.Impuesto> rows = new List<SIFModelo.Impuesto>();

            string sentencia = "SELECT * FROM cat_impuesto";

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
                                SIFModelo.Impuesto registro = new SIFModelo.Impuesto();

                                registro.ID = int.Parse(oreader["IMPUESTO_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();
                                registro.Porcentaje = System.Convert.ToDecimal(oreader["PORCENTAJE"]);
                                registro.VigenciaInicio = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);

                                var fechaBaja = oreader["FECHA_BAJA"];
                                if (fechaBaja.ToString().IsDatetime())
                                {
                                    registro.VigenciaFin = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                                }

                                if (registro.VigenciaFin != null && registro.VigenciaFin != new DateTime())
                                {
                                    registro.Activo = SIFModelo.Tipos.SiNo.NO;
                                }
                                else
                                {
                                    registro.Activo = SIFModelo.Tipos.SiNo.SI;
                                }

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


        public static SIFModelo.Impuesto ImpuestoPorID(int p)
        {
            List<SIFModelo.Impuesto> rows = new List<SIFModelo.Impuesto>();

            string sentencia = "SELECT * FROM cat_impuesto WHERE IMPUESTO_ID = :ImpuestoID";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //
                        cmd.Parameters.Add(":ImpuestoID", p);
                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Impuesto registro = new SIFModelo.Impuesto();

                                registro.ID = int.Parse(oreader["IMPUESTO_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();
                                registro.Porcentaje = System.Convert.ToDecimal(oreader["PORCENTAJE"]);
                                registro.VigenciaInicio = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);

                                if (oreader["FECHA_BAJA"] != DBNull.Value)
                                {
                                    registro.VigenciaFin = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);

                                }


                                return registro;
                            }
                        }

                    }
                }
                catch {
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

        public static  SIFModelo.CatClavesSat buscarporClaveSat(string p)
            {
            SIFModelo.CatClavesSat dato = new SIFModelo.CatClavesSat();
            
            string sentencia = "SELECT clave_id , clave_prod_serv, descripcion FROM CAT_CLAVES_SAT WHERE CLAVE_PROD_SERV = '" + p + "'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        try
                        {
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                            if (oreader.HasRows)
                            {
                                while (oreader.Read())
                                {
                                    dato.ID = int.Parse(oreader["CLAVE_ID"].ToString());
                                    dato.clave = oreader["CLAVE_PROD_SERV"].ToString();
                                    dato.Descripcion = oreader["DESCRIPCION"].ToString();
                                    return dato;
                                }
                            }
                        }
                        catch (Exception e)
                        {

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
            return dato;
            }

    }
}
