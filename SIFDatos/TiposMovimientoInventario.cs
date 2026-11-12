using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
namespace SIFDatos
{
    public static class TipoMovimientos
    {
        /// <summary>
        /// Utiliza el SP_INS_TipoMovimiento para agregar un TipoMovimiento
        /// </summary>
        /// <param name="modelo">La instancia del TipoMovimiento</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.TipoMovimiento modelo)
        {
            string sentencia = "sp_ins_cat_tipo_mov_inv";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nombre", modelo.Nombre);
                    cmd.Parameters.Add("fecha_alta", modelo.FechaAlta);
                    cmd.Parameters.Add("tipo", System.Convert.ToChar(modelo.Tipo));
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

        public static bool Elimina(SIFModelo.TipoMovimiento modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_TIPO_MOV_INV";
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

        public static bool Actualiza(SIFModelo.TipoMovimiento modelo)
        {
            string sentencia = "sp_upd_cat_tipo_mov_inv";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("eid", modelo.ID);
                    cmd.Parameters.Add("enombre", modelo.Nombre);
                    cmd.Parameters.Add("eactivo", System.Convert.ToChar(modelo.Activo));
                    cmd.Parameters.Add("efecha_alta", modelo.FechaAlta);
                    cmd.Parameters.Add("efecha_baja", modelo.FechaBaja);
                    cmd.Parameters.Add("etipo", System.Convert.ToChar(modelo.Tipo));

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

        public static List<SIFModelo.TipoMovimiento> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.TipoMovimiento> rows = new List<SIFModelo.TipoMovimiento>();

            string sentencia = "SELECT * FROM CAT_TIPO_MOV_INV";

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
                            SIFModelo.TipoMovimiento registro = new SIFModelo.TipoMovimiento();
                            registro.ID = int.Parse(oreader["TIPO_MOV_INV_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Activo = (System.Convert.ToChar(oreader["ACTIVO"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);
                            registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                            var fechaBaja = oreader["FECHA_BAJA"];
                            if (fechaBaja != DBNull.Value)
                                registro.FechaBaja = (System.Convert.ToDateTime(oreader["FECHA_BAJA"]));
                            registro.Tipo = (SIFModelo.Tipos.Movimiento)System.Convert.ToSByte(oreader["TIPO"].ToString()[0]);

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

        public static List<SIFModelo.TipoMovimiento> BuscaActivo()
        {
            List<SIFModelo.TipoMovimiento> rows = new List<SIFModelo.TipoMovimiento>();

            string sentencia = "SELECT * FROM CAT_TIPO_MOV_INV WHERE activo  = '" + (char)SIFModelo.Tipos.SiNo.SI + "'";

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
                            SIFModelo.TipoMovimiento registro = new SIFModelo.TipoMovimiento();
                            registro.ID = int.Parse(oreader["TIPO_MOV_INV_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Activo = (System.Convert.ToChar(oreader["ACTIVO"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);
                            registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                            registro.FechaBaja = (System.Convert.ToDateTime(oreader["FECHA_BAJA"]));
                            registro.Tipo = (SIFModelo.Tipos.Movimiento)System.Convert.ToSByte(oreader["TIPO"].ToString()[0]);

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
