using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
namespace SIFDatos
{
    public static class TiposCambio
    {
        /// <summary>
        /// Utiliza el SP_INS_TipoCambio para agregar un TipoCambio
        /// </summary>
        /// <param name="modelo">La instancia del TipoCambio</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.TipoCambio modelo)
        {
            string sentencia = "SP_INS_TIPO_CAMBIO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nombre", modelo.Nombre);
                    cmd.Parameters.Add("factor", modelo.Factor);
                    cmd.Parameters.Add("fec_vigencia_ini", modelo.VigenciaInicio);
                    cmd.Parameters.Add("fec_vigencia_fin", modelo.VigenciaFin);

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
                        }
                        //QUITAR CUANDO SE RECUPERE EL ID CORRECTAMENTE
                        modelo.ID = int.Parse(id.ToString());

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

        public static bool Elimina(SIFModelo.TipoCambio modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_TIPO_CAMBIO";
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

        public static bool Actualiza(SIFModelo.TipoCambio modelo)
        {
            string sentencia = "SP_UPD_TIPO_CAMBIO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("eid", modelo.ID);
                    cmd.Parameters.Add("enombre", modelo.Nombre);
                    cmd.Parameters.Add("efactor", modelo.Factor);
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

        public static List<SIFModelo.TipoCambio> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.TipoCambio> rows = new List<SIFModelo.TipoCambio>();

            string sentencia = "SELECT * FROM tipo_cambio";

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
                            SIFModelo.TipoCambio registro = new SIFModelo.TipoCambio();
                            registro.ID = System.Convert.ToInt32(oreader["TIPO_CAMBIO_ID"]);
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Factor = decimal.Parse(oreader["FACTOR"].ToString());
                            registro.VigenciaInicio = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                            registro.VigenciaFin = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                            if (registro.VigenciaFin.ToString().IsDatetime() && registro.VigenciaFin != new DateTime())
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
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }
            return rows;
        }


        public static SIFModelo.TipoCambio BuscaPorID(int p)
        {
            string sentencia = "SELECT * FROM tipo_cambio  WHERE tipo_cambio_id = :TipoCambio";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("TipoCambio", p);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.TipoCambio registro = new SIFModelo.TipoCambio();
                            registro.ID = System.Convert.ToInt32(oreader["TIPO_CAMBIO_ID"]);
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Factor = decimal.Parse(oreader["FACTOR"].ToString());
                            registro.VigenciaInicio = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                            registro.VigenciaFin = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                            if (registro.VigenciaFin.ToString().IsDatetime() && registro.VigenciaFin != new DateTime())
                            {
                                registro.Activo = SIFModelo.Tipos.SiNo.NO;
                            }
                            else
                            {
                                registro.Activo = SIFModelo.Tipos.SiNo.SI;
                            }
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
    }
}
