
using DevComponents.DotNetBar;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using SIFModelo.OrdenCompra;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIFDatos.OrdenCompra
{
    public class DatosFolio
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Motivo { get; set; }
        public string FolioFiscal { get; set; }
        public string Proveedor { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
    }
    public static class NotasDeCredito
    {
        public static DataSet getNotasCredito(string p_Ini, string p_Fin, String p_folio, string p_activo)
        {
            ///<sumary>
            ///obtiene el Kardex mas las caducidades registradas  JMQC 26/04/2018
            ///</sumary>
            DataSet ds = new DataSet("DSNotasCredito");
           
            string sentencia = "";

            ds.Tables.Add("FC_NOTA_CREDITO");
            sentencia = "pkg_mdo_notas_credito.sp_obtener_nc";
            
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {


                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("fecha_i", p_Ini);
                        cmd.Parameters.Add("fecha_f", p_Fin);
                        cmd.Parameters.Add("folio", p_folio);
                        cmd.Parameters.Add("activo_n", p_activo);

                        OracleParameter requiciciones = new OracleParameter("outnc", OracleDbType.RefCursor);
                        requiciciones.Direction = System.Data.ParameterDirection.Output;
                        cmd.Parameters.Add(requiciciones);
                        cmd.Connection.Open();

                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(ds, "FC_NOTA_CREDITO");
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();                        

                    }
                }
                catch (Exception exc)
                {
                }
                finally
                {
                    if (null != cnx)
                    {
                        cnx.Close();
                        cnx.Dispose();
                        //OracleConnection.ClearPool(cnx);
                    }
                }

            }

            ds.Tables.Add("FC_NOTA_CREDITO_DET");

            sentencia = "pkg_mdo_notas_credito.sp_obtener_nc_det";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {


                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("fecha_i", p_Ini);
                        cmd.Parameters.Add("fecha_f", p_Fin);
                        cmd.Parameters.Add("folio", p_folio);

                        OracleParameter requiciciones = new OracleParameter("outnc", OracleDbType.RefCursor);
                        requiciciones.Direction = System.Data.ParameterDirection.Output;
                        cmd.Parameters.Add(requiciciones);
                        cmd.Connection.Open();

                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(ds, "FC_NOTA_CREDITO_DET");
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();

                    }
                }
                catch (Exception exc)
                {
                }
                finally
                {
                    if (null != cnx)
                    {
                        cnx.Close();
                        cnx.Dispose();
                        //OracleConnection.ClearPool(cnx);
                    }
                }

            }

            return ds;
        }
        public static DataSet getNotasCreditoVigentes()
        {
            ///<sumary>
            ///obtiene el Kardex mas las caducidades registradas  JMQC 26/04/2018
            ///</sumary>
            DataSet ds = new DataSet("DSNotasCredito");

            string sentencia = "";

            ds.Tables.Add("FC_NOTA_CREDITO");

            sentencia = "pkg_mdo_notas_credito.sp_get_nc_cerradas";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {


                        cmd.CommandType = CommandType.StoredProcedure;
                     

                        OracleParameter requiciciones = new OracleParameter("outnc", OracleDbType.RefCursor);
                        requiciciones.Direction = System.Data.ParameterDirection.Output;
                        cmd.Parameters.Add(requiciciones);
                        cmd.Connection.Open();

                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(ds, "FC_NOTA_CREDITO");
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();

                    }
                }
                catch (Exception exc)
                {
                }
                finally
                {
                    if (null != cnx)
                    {
                        cnx.Close();
                        cnx.Dispose();
                        //OracleConnection.ClearPool(cnx);
                    }
                }

            }

            return ds;
        }


        public static String insNotaDeCredtio(
                             string p_Usuario_id,
                             string p_motivo,                             
                             String p_fecha_inicio,
                             string p_fecha_fin,
                             Decimal[] p_proveedor,
                             Decimal[] partida, 
                             Decimal[] SaldoTotal,
                             String[] concepto,
                             String[] FolioFiscal,
                             decimal subtotal,
                             decimal iva


                             )
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pkg_mdo_notas_credito.sp_crear_nc";
                cmd.BindByName = true;

                cmd.Parameters.Add("usuario", OracleDbType.Varchar2, p_Usuario_id, ParameterDirection.Input);
                cmd.Parameters.Add("fecha_i", OracleDbType.Varchar2, p_fecha_inicio, ParameterDirection.Input);
                cmd.Parameters.Add("fecha_f", OracleDbType.Varchar2, p_fecha_fin, ParameterDirection.Input);
                cmd.Parameters.Add("comentarios", OracleDbType.Varchar2, p_motivo, ParameterDirection.Input);
                cmd.Parameters.Add("subtotal", OracleDbType.Decimal, subtotal, ParameterDirection.Input);
                cmd.Parameters.Add("iva", OracleDbType.Decimal, iva, ParameterDirection.Input);
                cmd.Parameters.Add("tot_utilizado", OracleDbType.Decimal, 0, ParameterDirection.Input);

                OracleParameter InSaldoTotal = cmd.Parameters.Add("saldo_tot", OracleDbType.Decimal);
                InSaldoTotal.Direction = ParameterDirection.Input;
                InSaldoTotal.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InSaldoTotal.Value = SaldoTotal;

                OracleParameter InConcepto = cmd.Parameters.Add("concepto", OracleDbType.Varchar2);
                InConcepto.Direction = ParameterDirection.Input;
                InConcepto.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InConcepto.Value = concepto;

                OracleParameter InFolioFiscal = cmd.Parameters.Add("folio_fiscal", OracleDbType.Varchar2);
                InFolioFiscal.Direction = ParameterDirection.Input;
                InFolioFiscal.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InFolioFiscal.Value = FolioFiscal;

                OracleParameter Inp_proveedor = cmd.Parameters.Add("proveedor", OracleDbType.Decimal);
                Inp_proveedor.Direction = ParameterDirection.Input;
                Inp_proveedor.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                Inp_proveedor.Value = p_proveedor;

                OracleParameter InPartida = cmd.Parameters.Add("filas", OracleDbType.Decimal);
                InPartida.Direction = ParameterDirection.Input;
                InPartida.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPartida.Value = partida;


                // OUT parameter
                OracleParameter pTraspaso =
                    cmd.Parameters.Add("outfolio", OracleDbType.Varchar2, ParameterDirection.Output);
                pTraspaso.Size = 1000;


                // Execute the command
                cmd.ExecuteNonQuery();


                return pTraspaso.Value.ToString();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return ex.ToString();
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return "Error";
        }
                
        public static String insertaRelacionNC(
                                   TipoNcSaldoUtilizado modelo
            )
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pkg_mdo_notas_credito.sp_insert_nc_utilizado";
                cmd.BindByName = true;

                cmd.Parameters.Add("nc_id",       OracleDbType.Varchar2, modelo.Id, ParameterDirection.Input);
                cmd.Parameters.Add("concepto",       OracleDbType.Varchar2, modelo.Concepto, ParameterDirection.Input);
                cmd.Parameters.Add("rdm",   OracleDbType.Varchar2, modelo.Folio_rdm, ParameterDirection.Input);
                cmd.Parameters.Add("referencia", OracleDbType.Varchar2, modelo.Folio_referencia, ParameterDirection.Input);
                cmd.Parameters.Add("saldo_util",       OracleDbType.Decimal, modelo.Saldo, ParameterDirection.Input);
                cmd.Parameters.Add("usuario",   OracleDbType.Varchar2, Convert.ToInt32(modelo.Usuario_id), ParameterDirection.Input);

                // OUT parameter
                OracleParameter pTraspaso =
                    cmd.Parameters.Add("outnc", OracleDbType.Varchar2, ParameterDirection.Output);
                pTraspaso.Size = 1000;


                // Execute the command
                cmd.ExecuteNonQuery();


                return pTraspaso.Value.ToString();
              

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return "Error";
        }


        public static String GetSaldoRequeridoOC(
                                  string modelo
           )
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pkg_mdo_notas_credito.sp_get_saldo_requerido";
                cmd.BindByName = true;

                cmd.Parameters.Add("rdm", OracleDbType.Varchar2, modelo, ParameterDirection.Input);
                

                // OUT parameter
                OracleParameter pTraspaso =
                    cmd.Parameters.Add("outsaldo  ", OracleDbType.Varchar2, ParameterDirection.Output);
                pTraspaso.Size = 1000;

                // Execute the command
                cmd.ExecuteNonQuery();


                return pTraspaso.Value.ToString();


            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return "Error";
        }
                     

        public static void ActualizarEstadoNotaDeCredito(string folio, string estado)
        {
            using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    conn.Open();
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "pkg_mdo_notas_credito.sp_actualizar_nc_cancel_cerrar";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("folio", OracleDbType.Varchar2, folio, ParameterDirection.Input);
                    cmd.Parameters.Add("activo_s", OracleDbType.Char, estado, ParameterDirection.Input);

                    OracleParameter outNc = cmd.Parameters.Add("outnc", OracleDbType.Varchar2, ParameterDirection.Output);
                    outNc.Size = 1000;
                    cmd.ExecuteNonQuery();

                    string resultado = outNc.Value.ToString();
                    if (resultado.StartsWith("1:OK"))
                    {
                        //MessageBox.Show("El estado de la nota de crédito ha sido actualizado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el estado de la nota de crédito: " + resultado);
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show($"Error de Oracle: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}");
                }
            }
        }
                  
        public static DatosFolio ObtenerDatosFolio(string folio)
        {
            DatosFolio datos = new DatosFolio();
            using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("pkg_mdo_notas_credito.sp_obtener_datos_folio", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;

                cmd.Parameters.Add("p_folio", OracleDbType.Varchar2).Value = folio;
                cmd.Parameters.Add("p_fecha_inicio", OracleDbType.Date).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_fecha_fin", OracleDbType.Date).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_motivo", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_folio_fiscal", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_nombre_proveedor", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_subtotal", OracleDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_iva", OracleDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_total", OracleDbType.Decimal).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
         
                OracleDate oracleDateInicio = (OracleDate)cmd.Parameters["p_fecha_inicio"].Value;
                datos.FechaInicio = oracleDateInicio.Value;

                OracleDate oracleDateFin = (OracleDate)cmd.Parameters["p_fecha_fin"].Value;
                datos.FechaFin = oracleDateFin.Value;
                datos.Motivo = cmd.Parameters["p_motivo"].Value.ToString();
                datos.FolioFiscal = cmd.Parameters["p_folio_fiscal"].Value.ToString();
                datos.Proveedor = cmd.Parameters["p_nombre_proveedor"].Value.ToString();
                
                OracleDecimal oracleSubtotal = (OracleDecimal)cmd.Parameters["p_subtotal"].Value;
                datos.Subtotal = oracleSubtotal.Value;

                OracleDecimal oracleIva = (OracleDecimal)cmd.Parameters["p_iva"].Value;
                datos.Iva = oracleIva.Value;

                OracleDecimal oracleTotal = (OracleDecimal)cmd.Parameters["p_total"].Value;
                datos.Total = oracleTotal.Value;
            }
            return datos;
        }

        public static void ActualizarDatosFolio(string folio, DateTime fechaInicio, DateTime fechaFin, decimal subtotal, string cfdi, decimal iva, decimal total)
        {
            string procedimiento = "pkg_mdo_notas_credito.sp_actualizar_datos_folio";

            using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(procedimiento, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_folio", OracleDbType.Varchar2).Value = folio;
                    cmd.Parameters.Add("p_fecha_inicio", OracleDbType.Date).Value = fechaInicio;
                    cmd.Parameters.Add("p_fecha_fin", OracleDbType.Date).Value = fechaFin;
                    cmd.Parameters.Add("p_subtotal", OracleDbType.Decimal).Value = subtotal;
                    cmd.Parameters.Add("p_cfdi", OracleDbType.Varchar2).Value = cfdi;
                    cmd.Parameters.Add("p_iva", OracleDbType.Decimal).Value = iva;
                    cmd.Parameters.Add("p_total", OracleDbType.Decimal).Value = total;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores
                        Console.WriteLine("Error al actualizar los datos del folio: " + ex.Message);
                    }
                }
            }
        }
    }
}
