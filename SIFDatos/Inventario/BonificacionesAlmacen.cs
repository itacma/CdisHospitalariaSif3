using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data;
using DevComponents.DotNetBar;

namespace SIFDatos.Inventario
{
    public class BonificacionesAlmacen
    {

        public static string AplicaBonificacion(string Folio, string Lote, string Usuario)
        {
            string ProductName = "Bonificacion";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();
                string respuesta;
                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "PKG_CIERRE_CADUCIDADES21.sp_AFECTA_bonificacion";

                cmd.BindByName = true;

                cmd.Parameters.Add("V_FOLIO_B", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                cmd.Parameters.Add("V_LOTE_B", OracleDbType.Varchar2, Lote, ParameterDirection.Input);
                cmd.Parameters.Add("V_USUARIO", OracleDbType.Varchar2, Usuario, ParameterDirection.Input);
                OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Varchar2, 500);
                outparam.Direction = System.Data.ParameterDirection.Output;

                //AGREGAR LOS PARAMETROS
                cmd.Parameters.Add(outparam);

                // Execute the command
                try
                {
                   
                    cmd.ExecuteNonQuery();

                    return respuesta = outparam.Value.ToString();

                }
                catch (Exception ex)
                {

                    return respuesta=ex.ToString();
                }
                       

                

                // return Convert.ToInt32(pAjuste.Value.ToString());
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al aplicar LA BONIFICAION: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ex.ToString();
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);
                }
            }
        }

         public static void AplicaReposicion(string Folio, string Usuario)
        {
            string ProductName = "Reposicion";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SP_AFECTA_REPOSICION";

                cmd.BindByName = true;

                cmd.Parameters.Add("V_FOLIO_R", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                cmd.Parameters.Add("V_USUARIO", OracleDbType.Varchar2, Usuario, ParameterDirection.Input);


                // Execute the command
                cmd.ExecuteNonQuery();



               MessageBox.Show("Se Aplico la reposición", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                // return Convert.ToInt32(pAjuste.Value.ToString());
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al aplicar la reposición: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // return 0;
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);
                }
            }
        }

        public static List<SIFModelo.DevolucionProveedorDetalle> cargaDevProv(string folio)
        {
            List<SIFModelo.DevolucionProveedorDetalle> articulos = new List<SIFModelo.DevolucionProveedorDetalle>();
            SIFModelo.DevolucionProveedorDetalle det = new SIFModelo.DevolucionProveedorDetalle();
            string sentencia = "SELECT * FROM DEVOLUCION_PROV_DET where devolucion_id like'%" + folio + "'";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.BindByName = true;

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                det = new SIFModelo.DevolucionProveedorDetalle();
                                det.Cantidad = Convert.ToInt32(oreader["cantidad"].ToString());
                                det.ArticuloID = oreader["articulo_id"].ToString();
                                articulos.Add(det);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }
            return articulos;
        }
        public static List<SIFModelo.ReposisionProveedorDetalle> cargaRepProv(string folio)
        {
            List<SIFModelo.ReposisionProveedorDetalle> articulos = new List<SIFModelo.ReposisionProveedorDetalle>();
            SIFModelo.ReposisionProveedorDetalle det = new SIFModelo.ReposisionProveedorDetalle();
            string sentencia = "SELECT * FROM REPOSICION_PROV_DET where reposicion_id like'%" + folio + "'";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.BindByName = true;

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                det = new SIFModelo.ReposisionProveedorDetalle();
                                det.Cantidad = Convert.ToInt32(oreader["cantidad"].ToString());
                                det.ArticuloID = oreader["articulo_id"].ToString();
                                articulos.Add(det);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    finally
                    {

                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }
            return articulos;
        }
        public static void AplicaReposicionProv(string Folio, string Usuario)
        {
            string ProductName = "reposicion de prov";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_AFECTA_reposicion_prov";

                cmd.BindByName = true;

                cmd.Parameters.Add("V_FOLIO_B", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                cmd.Parameters.Add("V_USUARIO", OracleDbType.Varchar2, Usuario, ParameterDirection.Input);


                // Execute the command
                cmd.ExecuteNonQuery();



               MessageBox.Show("Se Aplico LA REPOSICION", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                // return Convert.ToInt32(pAjuste.Value.ToString());
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al aplicar LA REPOSICION de PROVEEDOR: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // return 0;
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);
                }
            }
        }
        public static void AplicaDevolucionProv (string Folio,  string Usuario)
        {
            string ProductName = "devoluicion a prov";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_AFECTA_devolucion_prov";
                
                cmd.BindByName = true;

                cmd.Parameters.Add("V_FOLIO_B", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                cmd.Parameters.Add("V_USUARIO", OracleDbType.Varchar2, Usuario, ParameterDirection.Input);

               
                // Execute the command
                cmd.ExecuteNonQuery();


               
                   MessageBox.Show("Se Aplico LA DEVOLUCION A PROVEEDOR", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                
               // return Convert.ToInt32(pAjuste.Value.ToString());
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al aplicar LA DEVOLUCION A PROVEEDOR: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
               // return 0;
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);
                }
            }
        }

        public static string VerificarProcesados(string Folio,string lote,int mov)
        {
            //List<SIFModelo.BonificacionDet_Caducidad> articulos = new List<SIFModelo.BonificacionDet_Caducidad>();
            //SIFModelo.BonificacionDet_Caducidad det = new SIFModelo.BonificacionDet_Caducidad();
            string sentencia = "SP_VERIFICA_LOT_CAD";
            string RESPUESTA;
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("v_folio", OracleDbType.Varchar2,15, Folio, ParameterDirection.Input);
                    cmd.Parameters.Add("v_lote", OracleDbType.Varchar2, 15, lote, ParameterDirection.Input);
                    cmd.Parameters.Add("v_mov", OracleDbType.Int32,3,Convert.ToInt32(mov),ParameterDirection.Input);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("resultado", OracleDbType.Varchar2,250);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        return RESPUESTA = outparam.Value.ToString();

                    }
                    catch (Exception ex)
                    {

                        return ex.ToString();
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                        //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            //return RESPUESTA;
        }

    }
}
