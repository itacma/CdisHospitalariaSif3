using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace SIFDatos.OrdenCompra
{
    public class AjusteInventario
    {
        public static DataSet Busca(string Folio, DateTime fecha1, DateTime fecha2)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet dsOrdenesCompra = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

            string sentencia = "SELECT FOLIO, LOTE, SUCURSAL_ID, FECHA_REG, TOTAL, CONCEPTO, TIPO_MOV, DOC_REFERENCIA, SUCURSAL_REF, USUARIO_ID, USUARIO_AUTORIZA,  ACTIVO " +
                            " FROM AJUSTES" +
                            " WHERE FOLIO LIKE '%" + Folio + "%'  AND FECHA_REG >= TO_DATE('" + fecha1.ToString("yyyy-MM-dd HH:mm:ss") + "', 'YYYY-MM-DD HH24:MI:SS') " +
                            " AND FECHA_REG <= TO_DATE('" + fecha2.ToString("yyyy-MM-dd HH:mm:ss") + "', 'YYYY-MM-DD HH24:MI:SS')";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.Parameters.Add(":Folio", "%" + Folio + "%");
                    //cmd.Parameters.Add("Fecha1", fecha1);
                    //cmd.Parameters.Add("Fecha2", fecha2);
                    //
                    using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                    {
                        td.Fill(dsOrdenesCompra.AJUSTES);
                    }
                }
            }

            string folios = "";
            foreach (var item in dsOrdenesCompra.AJUSTES)
            {
                folios += item.FOLIO + ",";
            }

            folios = folios.Trim(',');


            if (string.IsNullOrEmpty(folios))
            {
                return dsOrdenesCompra;
            }
//DETALLES
            string sentenciaDetalle = "SELECT AJUSTES_DET.FOLIO, AJUSTES_DET.LOTE, AJUSTES_DET.SUCURSAL_ID, AJUSTES_DET.PARTIDA, AJUSTES_DET.ARTICULO_ID, " +
                         " AJUSTES_DET.CANTIDAD, AJUSTES_DET.PRECIO, AJUSTES_DET.CONCEPTO_DET, AJUSTES_DET.PRECIO_VTA, CAT_ARTICULOS.NOMBRE1,  " +
                         " CAT_ARTICULOS.NOMBRE2 " +
                         " FROM AJUSTES_DET INNER JOIN " +
                         " CAT_ARTICULOS ON AJUSTES_DET.ARTICULO_ID = CAT_ARTICULOS.ARTICULO_ID" +
                         " WHERE AJUSTES_DET.FOLIO IN (" + folios + ")";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentenciaDetalle, cnx))
                {
                    using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                    {
                        td.Fill(dsOrdenesCompra.AJUSTES_DET);
                    }
                }
            }
            return dsOrdenesCompra;
        }

        public static bool Inserta(SIFModelo.OrdenCompra.OrdenesCompraDataSet.AJUSTESRow modelo)
        {
            string sentencia = "sp_ins_ajustes";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("folio", modelo.FOLIO);
                    cmd.Parameters.Add("lote", modelo.LOTE);
                    cmd.Parameters.Add("sucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("fecha_reg", modelo.FECHA_REG);
                    cmd.Parameters.Add("total", modelo.TOTAL);
                    cmd.Parameters.Add("concepto_ajus", modelo.CONCEPTO_AJUS);
                    cmd.Parameters.Add("tipo_mov", modelo.TIPO_MOV);
                    cmd.Parameters.Add("doc_referencia", modelo.DOC_REFERENCIA);
                    cmd.Parameters.Add("sucursal_ref", modelo.SUCURSAL_REF);
                    cmd.Parameters.Add("usuario_id", modelo.USUARIO_ID);
                    cmd.Parameters.Add("usuario_autoriza", modelo.USUARIO_AUTORIZA);
                    cmd.Parameters.Add("activo", modelo.ACTIVO);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            // return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static bool InsertaDetalle(SIFModelo.OrdenCompra.OrdenesCompraDataSet.AJUSTES_DETRow modelo)
        {
            string sentencia = "sp_ins_ajustes_det";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("folio", modelo.FOLIO);
                    cmd.Parameters.Add("lote", modelo.LOTE);
                    cmd.Parameters.Add("sucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("partida", modelo.PARTIDA);
                    cmd.Parameters.Add("articulo_id", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("nombre1", modelo.NOMBRE1);
                    cmd.Parameters.Add("cantidad", modelo.CANTIDAD);
                    cmd.Parameters.Add("precio", modelo.PRECIO);
                    cmd.Parameters.Add("concepto_det", modelo.CONCEPTO_DET);
                    cmd.Parameters.Add("precio_vta", modelo.PRECIO_VTA);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            // return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static int GeneraFolio(int sucursal, string prefijoFolio)
        {
            object id;
            string sentencia = "SELECT NVL(COUNT(*),0) + 1 FROM AJUSTES  WHERE TO_CHAR(FECHA_REG,'YY') = :prefijoFolio AND sucursal_id = :sucursalID";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("sucursalID", sucursal);
                    cmd.Parameters.Add("prefijoFolio", prefijoFolio);
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return int.Parse(id.ToString());
        }
    }
}
