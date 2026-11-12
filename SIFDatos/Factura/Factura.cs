using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using Oracle.DataAccess.Types;

namespace SIFDatos.Factura
{
    public static class Factura
    {
        public static bool RemsionFacturas(string Usuario, string referencia, DateTime fecha, string num_factura, string uuid, string tipoCFDI)
        {


            //string mensaje;
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {

                string sentencia = "INSERT INTO REMISION_FACTURAS(USUARIO_ID,REFERENCIA,FECHA,FOLIO_FEL,UUID,TIPO) VALUES(:usuarioid,:referencia,TO_DATE(:fecha,'DD/MM/RRRR HH24:MI:SS'),:foliofel,:uuid,:tipo)";

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {

                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Parameters.Add("usuarioid", Usuario);
                        cmd.Parameters.Add("referencia", referencia);
                        cmd.Parameters.Add("fecha", fecha.ToString("dd/MM/yyyy HH:mm:ss"));
                        cmd.Parameters.Add("foliofel", num_factura);
                        cmd.Parameters.Add("uuid", uuid);
                        cmd.Parameters.Add("tipo", tipoCFDI);
                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        // OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    }

                }

                return true;
            }

            catch (OracleException Oex)
            {

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + System.Environment.NewLine);

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

            return true;
        }
        public static bool InsertaFactura(string remision, string factura, string path, string uuid, string TipoCFDI)
        {
            string mensaje;
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_VENTAS.SP_INS_CTL_FACTURAS"; // "PKG_BANCOS.SP_INS_BANCO";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pBancos = cmd.Parameters.Add("outparam", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("num_remision", OracleDbType.Char, remision, ParameterDirection.Input);
                cmd.Parameters.Add("factura", OracleDbType.XmlType, new OracleXmlType(conn, factura), ParameterDirection.Input);
                cmd.Parameters.Add("path_factura", OracleDbType.Char, path, ParameterDirection.Input);
                cmd.Parameters.Add("uuid", OracleDbType.Varchar2, uuid, ParameterDirection.Input);
                cmd.Parameters.Add("tipo", OracleDbType.Varchar2, TipoCFDI, ParameterDirection.Input);

                // Execute the command
                //cmd.ExecuteNonQuery();

                // Construct an OracleDataReader from the REF CURSOR
                //OracleDataReader ereader = ((OracleRefCursor)pBancos.Value).GetDataReader();
                OracleDataReader ereader = cmd.ExecuteReader();

                if (ereader.HasRows)
                {
                    while (ereader.Read())
                    {
                        mensaje = "BD: " + ereader.GetValue(0).ToString() + Environment.NewLine;
                    }
                }
                else
                {
                    throw new Exception("BD XMLTYPE NO existen registros..." + Environment.NewLine);
                }

                ereader.Close();
                ereader.Dispose();

            }
            catch (OracleException Oex)
            {
                switch (Oex.Number)
                {
                    case 1:
                        throw new Exception("Error intentando insertar datos duplicados" + Environment.NewLine);
                        break;
                    case 12545:
                        throw new Exception("La base de datos NO esta disponible" + Environment.NewLine);
                        break;
                    default:
                        throw new Exception("Database error:" + System.Environment.NewLine + Oex.ToString() + System.Environment.NewLine);
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + System.Environment.NewLine);

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

            return true;
        }

        public static bool ActualizaFactura(SIFModelo.Remision remision, string acuseXML, string resp, string uuid)
        {
            //string mensaje;
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_UPD_CTL_FACTURAS"; // "PKG_BANCOS.SP_INS_BANCO";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pBancos = cmd.Parameters.Add("outparam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("ope", OracleDbType.Char, remision.Activo, ParameterDirection.Input);
                cmd.Parameters.Add("remision", OracleDbType.Varchar2, remision.NumeroRemision, ParameterDirection.Input);
                cmd.Parameters.Add("euuid", OracleDbType.Varchar2, uuid, ParameterDirection.Input);
                cmd.Parameters.Add("eacuse_cancelacion", OracleDbType.XmlType, new OracleXmlType(conn, acuseXML), ParameterDirection.Input);
                cmd.Parameters.Add("emsg_resp", OracleDbType.Char, resp, ParameterDirection.Input);

                // Execute the command
                //cmd.ExecuteNonQuery();

                // Construct an OracleDataReader from the REF CURSOR
                //OracleDataReader ereader = ((OracleRefCursor)pBancos.Value).GetDataReader();
                cmd.ExecuteReader();

                //if (ereader.HasRows)
                //{
                //    while (ereader.Read())
                //    {
                //        mensaje = "BD: " + ereader.GetValue(0).ToString() + Environment.NewLine;
                //    }
                //}
                //else
                //{
                //    throw new Exception("BD XMLTYPE NO existen registros..." + Environment.NewLine);
                //}

                //ereader.Close();
                //ereader.Dispose();

            }
            catch (OracleException Oex)
            {
                switch (Oex.Number)
                {
                    case 1:
                        throw new Exception("Error intentando insertar datos duplicados" + Environment.NewLine);
                        break;
                    case 12545:
                        throw new Exception("La base de datos NO esta disponible" + Environment.NewLine);
                        break;
                    default:
                        throw new Exception("Database error:" + System.Environment.NewLine + Oex.ToString() + System.Environment.NewLine);
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + System.Environment.NewLine);

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

            return true;
        }

        public static bool ReFactura(int sucursal, string remision, string factura, string path, string num_factura, string uuid, string tipoCFDI)
        {
            string mensaje;
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_VENTAS.sp_refactura_vta";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pBancos = cmd.Parameters.Add("outparam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("p_sucursal", OracleDbType.Int32, sucursal, ParameterDirection.Input);
                cmd.Parameters.Add("p_num_remision", OracleDbType.Varchar2, remision, ParameterDirection.Input);
                cmd.Parameters.Add("p_num_factura", OracleDbType.Varchar2, num_factura, ParameterDirection.Input);
                cmd.Parameters.Add("p_factura", OracleDbType.XmlType, new OracleXmlType(conn, factura), ParameterDirection.Input);
                cmd.Parameters.Add("p_path_factura", OracleDbType.Char, path, ParameterDirection.Input);
                cmd.Parameters.Add("p_uuid", OracleDbType.Varchar2, uuid, ParameterDirection.Input);
                cmd.Parameters.Add("p_tipo_cfdi", OracleDbType.Varchar2, tipoCFDI, ParameterDirection.Input);



                // Execute the command
                //cmd.ExecuteNonQuery();

                // Construct an OracleDataReader from the REF CURSOR
                //OracleDataReader ereader = ((OracleRefCursor)pBancos.Value).GetDataReader();
                cmd.ExecuteNonQuery();

                if (pBancos.Value.ToString().IsInteger())
                {

                    if (int.Parse(pBancos.Value.ToString()) > 0)
                    {
                        return true;
                    }
                    //while (ereader.Read())
                    //{
                    //    mensaje = "BD: " + ereader.GetValue(0).ToString() + Environment.NewLine;
                    //}
                }
                else
                {
                    throw new Exception("BD XMLTYPE NO existen registros..." + Environment.NewLine);
                }

                //ereader.Close();
                //ereader.Dispose();
                return false;
            }


            catch (OracleException Oex)
            {
                //switch (Oex.Number)
                //{
                //    case 1:
                //        throw new Exception("Error intentando insertar datos duplicados" + Environment.NewLine);
                //        break;
                //    case 12545:
                //        throw new Exception("La base de datos NO esta disponible" + Environment.NewLine);
                //        break;
                //    default:
                //        throw new Exception("Database error:" + System.Environment.NewLine + Oex.ToString() + System.Environment.NewLine);
                //        break;
                //}
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString() + System.Environment.NewLine);

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

            return true;
        }


        public static SIFModelo.WebServices.FelControl DevolucionPorRemision(SIFModelo.Remision remision)
        {
            SIFModelo.WebServices.FelControl fc = null;

            string sentencia = "SELECT * FROM CTL_FACTURAS WHERE NUM_REMISION = :RemisionID AND TIPO_CFDI = 'CRE' AND activo = 'S'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Parameters.Add("RemisionID", remision.NumeroRemision);
                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                fc = new SIFModelo.WebServices.FelControl();

                                fc.UUID = oreader["UUID"].ToString();
                                fc.TIPO_CFDI = oreader["TIPO_CFDI"].ToString();
                                fc.PATH_FACTURA = oreader["PATH_FACTURA"].ToString();
                                fc.NUM_REMISION = oreader["NUM_REMISION"].ToString();
                                fc.MSG_RESPUESTA = oreader["MSG_RESPUESTA"].ToString();
                                if (oreader["FECHA_ENVIO"].ToString().IsDatetime())
                                    fc.FECHA_ENVIO = DateTime.Parse(oreader["FECHA_ENVIO"].ToString());
                                if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                                    fc.FECHA_BAJA = DateTime.Parse(oreader["FECHA_BAJA"].ToString());
                                if (oreader["FECHA_ALTA"].ToString().IsDatetime())
                                    fc.FECHA_ALTA = DateTime.Parse(oreader["FECHA_ALTA"].ToString());
                                fc.ACUSE_CANCELACION = oreader["ACUSE_CANCELACION"].ToString();
                                fc.ACTIVO = oreader["ACTIVO"].ToString();
                                return fc;
                            }
                        }

                    }
                }
                catch
                {

                }
                finally {
                    if (null != cnx)
                    {
                        cnx.Close();
                        cnx.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                }

            }
            return null;


            return fc;
        }





    }
}
