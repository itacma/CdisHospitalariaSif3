using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace SIFDatos.CallCenter
{
    public static class QuejasSugerencias
    {
        public static SIFModelo.QuejasSugerencias.CatalogoDataSet dtQuejasSugerencias()
        {
            SIFModelo.QuejasSugerencias.CatalogoDataSet ds = new SIFModelo.QuejasSugerencias.CatalogoDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.QuejasSugerencias.CatalogoDataSetTableAdapters.CAT_QUEJA_SUGERENCIATableAdapter ta = new SIFModelo.QuejasSugerencias.CatalogoDataSetTableAdapters.CAT_QUEJA_SUGERENCIATableAdapter();
                ta.Connection = cnx;

                ta.FillByActivo(ds.CAT_QUEJA_SUGERENCIA);
            }
            return ds;
        }


        public static SIFModelo.CallCenter.CallCenterDataSet dtQuejasSugerencias(DateTime fecha1, DateTime fecha2, String Sucursal)
        {
            SIFModelo.CallCenter.CallCenterDataSet ds = new SIFModelo.CallCenter.CallCenterDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.CallCenter.CallCenterDataSetTableAdapters.QUEJA_SUGERENCIATableAdapter ta = new SIFModelo.CallCenter.CallCenterDataSetTableAdapters.QUEJA_SUGERENCIATableAdapter();
                ta.Connection = cnx;
                string sfecha1 = fecha1.ToString("yyyy/MM/dd 00:00:00");
                string sfecha2 = fecha2.ToString("yyyy/MM/dd 23:59:59");
                ta.FillByFechas(ds.QUEJA_SUGERENCIA, sfecha1, sfecha2,Sucursal);
            }
            return ds;
        }

        public static bool NuevaQuejaSugerencia(SIFModelo.CallCenter.CallCenterDataSet.QUEJA_SUGERENCIARow modelo)
        {
            string sentencia = "SP_INS_QUEJA_SUGERENCIA";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("queja_sugerencia_id", modelo.QUEJA_SUGERENCIA_ID);
                    cmd.Parameters.Add("sucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("fecha_alta", modelo.FECHA_ALTA);
                    cmd.Parameters.Add("fecha_suceso", modelo.FECHA_SUCESO);
                    cmd.Parameters.Add("queja_sugerencia", modelo.QUEJA_SUGERENCIA);
                    cmd.Parameters.Add("cliente_id", modelo.CLIENTE_ID);
                    cmd.Parameters.Add("comentario", modelo.COMENTARIO);
                    cmd.Parameters.Add("user_genero_id", modelo.USER_GENERO_ID);
                    cmd.Parameters.Add("user_levanto_id", modelo.USER_LEVANTO_ID);
                    cmd.Parameters.Add("cat_queja_sugerencia_id", modelo.CAT_QUEJA_SUGERENCIA_ID);
                    cmd.Parameters.Add("queja_sugerencia_tipo_id", modelo.CAT_QUEJA_SUGERENCIA_TIPO_ID);
                    cmd.Parameters.Add("solucion", modelo.SOLUCION);
                    cmd.Parameters.Add("fecha_solucion", modelo.FECHA_SOLUCION);
                    cmd.Parameters.Add("estatus", modelo.ESTATUS);


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

                            modelo.QUEJA_SUGERENCIA_ID = int.Parse(id.ToString());
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

        public static bool ModificaQuejaSugerencia(SIFModelo.CallCenter.CallCenterDataSet.QUEJA_SUGERENCIARow modelo)
        {
            string sentencia = "SP_UPD_QUEJA_SUGERENCIA";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("equeja_sugerencia_id", modelo.QUEJA_SUGERENCIA_ID);
                    cmd.Parameters.Add("esucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("efecha_alta", modelo.FECHA_ALTA);
                    cmd.Parameters.Add("efecha_suceso", modelo.FECHA_SUCESO);
                    cmd.Parameters.Add("equeja_sugerencia", modelo.QUEJA_SUGERENCIA);
                    cmd.Parameters.Add("ecliente_id", modelo.CLIENTE_ID);
                    cmd.Parameters.Add("ecomentario", modelo.COMENTARIO);
                    cmd.Parameters.Add("eid_user_genero", modelo.USER_GENERO_ID);
                    cmd.Parameters.Add("eid_user_levanto", modelo.USER_LEVANTO_ID);
                    cmd.Parameters.Add("ecat_queja_sugerencia_id", modelo.CAT_QUEJA_SUGERENCIA_ID);
                    cmd.Parameters.Add("ecat_queja_sug_tipo_id", modelo.CAT_QUEJA_SUGERENCIA_TIPO_ID);
                    cmd.Parameters.Add("esolucion", modelo.SOLUCION);
                    cmd.Parameters.Add("efecha_solucion", modelo.FECHA_SOLUCION);
                    cmd.Parameters.Add("eestatus", modelo.ESTATUS);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        var id = outparam.Value;
                        if (id.ToString().IsIntegerPositive())
                        {
                            return true;
                            //if (int.Parse(id.ToString()) < 0)
                            //{
                            //    throw new Exception("Ha ocurrido un error al insetrar el registro" + id.ToString());
                            //}

                            //modelo.QUEJA_SUGERENCIA_ID = int.Parse(id.ToString());
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
    }
}
