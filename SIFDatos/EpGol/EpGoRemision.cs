using log4net;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIFDatos.EpGo
{
    public static class EpGoRemision
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(EpGoRemision));
        public static DataSet epgoRemisionPagada(string numeroRemision)
        {
            // Creamos el DataSet con el nombre que identificará el conjunto de datos
            DataSet ds = new DataSet("DSRemisionesPagadas");

            try
            {
                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand("EPGO_SP_GET_REM_PAGADA", cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetro de Entrada: Número de remisión
                        cmd.Parameters.Add("p_num_remision", OracleDbType.Varchar2).Value = numeroRemision;

                        // Parámetro de Salida 1: Cursor de Encabezado
                        OracleParameter outEncabezado = new OracleParameter("out_c_encabezado", OracleDbType.RefCursor);
                        outEncabezado.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outEncabezado);

                        // Parámetro de Salida 2: Cursor de Detalle
                        OracleParameter outDetalle = new OracleParameter("out_c_detalle", OracleDbType.RefCursor);
                        outDetalle.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outDetalle);

                        cmd.Connection.Open();

                        using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                        {
                            // El DataAdapter llenará automáticamente dos tablas en el DataSet
                            // Table (Índice 0) -> Encabezado
                            // Table1 (Índice 1) -> Detalle
                            da.Fill(ds);

                            // Renombramos las tablas para facilitar el mapeo a JSON
                            if (ds.Tables.Count > 0) ds.Tables[0].TableName = "Encabezado";
                            if (ds.Tables.Count > 1) ds.Tables[1].TableName = "Detalle";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log de error o manejo según tu arquitectura
                log.Error("Error en epgoRemisionPagada: " + ex.Message);
                throw;
            }

            return ds;
        }

        public static DataSet epgoGetInventario(List<string> detalles)
        {
            DataSet ds = new DataSet("DSInventario");

            // 1. Extraemos los ArticuloId del detalle para crear la lista del "IN"
            // Usamos Select para obtener solo los IDs y los unimos con comas
            string listaIds = string.Join("','", detalles);

            // Construimos la sentencia con la lista: 'ID1','ID2','ID3'
            string query = $"SELECT i.*,  sysdate ULT_FECHA_REFRESH   FROM INVENTARIO i  WHERE i.ARTICULO_ID IN ('{listaIds}')";

            try
            {
                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(query, cnx))
                    {
                        cmd.CommandType = CommandType.Text; // Es una consulta directa, no un SP
                        cnx.Open();

                        using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                        {
                            // Llenamos el DataSet con los datos encontrados 📋
                            da.Fill(ds, "InventarioActual");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error en epgoGetInventario: " + ex.Message);
                throw;
            }

            return ds;
        }

        public static DataSet epgoGetArticulosModificados(string documento, int tipoMovInvID)
        {
            DataSet ds = new DataSet("DSInventario");

            ///JMQC 22/01/2026 EL objetivo de este metodo es obtener todos los codigos del kardex que sufrieron afectaciones en el inventario por el movimiento
            ///
            // Construimos la sentencia con la lista: 'ID1','ID2','ID3'
            string query = $"select  distinct articulo_id    from  inv_kardex where documento ='{documento}' and tipo_mov_inv_id ={tipoMovInvID} ";

            try
            {
                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(query, cnx))
                    {
                        cmd.CommandType = CommandType.Text; // Es una consulta directa, no un SP
                        cnx.Open();

                        using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                        {
                            // Llenamos el DataSet con los datos encontrados 📋
                            da.Fill(ds, "ArticulosModificados");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error en epgoGetInventario: " + ex.Message);
                throw;
            }

            return ds;
        }

    }
}
