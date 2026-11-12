using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace SIFDatos.Inventario
{
    public class Faltantes
    {
        public static int NumeroFaltante(int sucursalId)
        {
            object id;
            string sentencia = "SELECT NVL( MAX(FOLIO_FALTANTE),0) + 1 FROM FALTANTE WHERE sucursal_id = :sucursalID";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("sucursalID", sucursalId);
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



        public static bool InsertaFaltanteDetalle(SIFModelo.Inventarios.InventarioDataSet.FALTANTE_DETRow modelo)
        {
            string sentencia = "SP_INS_FALTANTE_DET";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("folio_faltante", modelo.FOLIO_FALTANTE);
                    cmd.Parameters.Add("articulo_id", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("cantidad", modelo.CANTIDAD);

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

        public static bool InsertaFaltante(global::SIFModelo.Inventarios.InventarioDataSet.FALTANTERow modelo )
        {
            string sentencia = "SP_INS_FALTANTES";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("folio_faltante", modelo.FOLIO_FALTANTE);
                    cmd.Parameters.Add("fecha_faltante", modelo.FECHA_FALTANTE);
                    cmd.Parameters.Add("comentario", modelo.COMENTARIO);
                    cmd.Parameters.Add("user_genero_id", modelo.USER_GENERO_ID);

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
                        //if (id.ToString().IsInteger())
                        //{
                        //    if (int.Parse(id.ToString()) < 0)
                        //    {
                        //        throw new Exception("Ha ocurrido un error al insetrar el registro" + id.ToString());
                        //    }

                        //    //modelo.ID = int.Parse(id.ToString());
                        //}
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
