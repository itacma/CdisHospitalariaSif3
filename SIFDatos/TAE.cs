using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace SIFDatos
{
    public static class TAE
    {
        public static bool InsertaTAE(SIFModelo.WebServices.TAE recarga)
        {

            string OraGAC = Helpers.ConnectionString.Connection();
            OracleConnection conn = new OracleConnection(OraGAC);

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_INS_CTL_TAE"; // "PKG_BANCOS.SP_INS_BANCO";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pTAE = cmd.Parameters.Add("outparam", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("carrier", recarga.Carrier);
                cmd.Parameters.Add("remision",  int.Parse( recarga.Remision));
                cmd.Parameters.Add("telefono", recarga.Telefono);
                cmd.Parameters.Add("articulo", recarga.Articulo);
                cmd.Parameters.Add("importe", recarga.Importe);
                cmd.Parameters.Add("fecha", recarga.Fecha.ToString("dd/MM/yyyy HH:mm:ss"));
                cmd.Parameters.Add("gpo", recarga.Grupo);
                cmd.Parameters.Add("cad", recarga.Cadena);
                cmd.Parameters.Add("suc", recarga.Sucursal);
                cmd.Parameters.Add("caj", recarga.Caja);
                cmd.Parameters.Add("refe", recarga.Referencia);
                cmd.Parameters.Add("respid",  recarga.Respuesta);
                cmd.Parameters.Add("resp",  recarga.Respuesta);
                cmd.Parameters.Add("archivo", recarga.Archivo);

                OracleDataReader ereader = cmd.ExecuteReader();

                //if (ereader.HasRows)
                //{
                //    while (ereader.Read())
                //    {
                //       MessageBox.Show("BD: " + ereader.GetValue(0).ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //}
                //else
                //    throw new Exception("BD TAE NO existen registros de resultados..." + ProductName);

                cmd.Parameters.Clear();
                ereader.Close();
                ereader.Dispose();

            }
            catch (OracleException Oex)
            {
                switch (Oex.Number)
                {
                    case 1:
                        throw new Exception("Error intentando insertar datos duplicados");
                        return false;
                        break;
                    case 12545:
                        throw new Exception("La base de datos NO esta disponible");
                        return false;
                        break;
                    default:
                        throw new Exception("Database error:");
                        return false;
                        break;
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                return false;
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return true;

        }

        public static SIFModelo.WebServices.TAE Control(SIFModelo.Remision remision)
        {
            string sentencia = "SELECT * FROM CTL_TAE WHERE NUM_REMISION = :NumeroRemision";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //Parametros
                    cmd.Parameters.Add("NumeroRemision", remision.NumeroRemision);

                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.WebServices.TAE registro = new SIFModelo.WebServices.TAE();

                            registro.Carrier = int.Parse(oreader["CARRIER_ID"].ToString());
                            registro.Remision =  oreader["NUM_REMISION"].ToString();
                            registro.Telefono = oreader["NUM_TELEFONO"].ToString();
                            registro.Archivo = oreader["ARTICULO_ID"].ToString();
                            registro.Importe = decimal.Parse(oreader["IMPORTE"].ToString());
                            registro.Fecha = DateTime.Parse(oreader["FECHA_ALTA"].ToString());
                            registro.Grupo = int.Parse(oreader["GRUPO"].ToString());
                            registro.Cadena = int.Parse(oreader["CADENA"].ToString());
                            registro.Sucursal = int.Parse(oreader["SUCURSAL"].ToString());
                            registro.Caja = int.Parse(oreader["CAJA"].ToString());
                            registro.Referencia = oreader["REFERENCIA"].ToString();
                            registro.RespuestaID = oreader["RESPUESTA_ID"].ToString();
                            registro.Respuesta = oreader["RESPUESTA_DESC"].ToString();
                            registro.Archivo = oreader["NOM_ARCHIVO"].ToString();
                            registro.Articulo = oreader["ARTICULO_ID"].ToString();
                            
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

        public static bool UpdTae(SIFModelo.WebServices.TAE modelo)
        {
           //return false;

            int d = 0;
            if (!int.TryParse(modelo.Referencia, out d))
            {
                modelo.Referencia = "-1";
            }
            
             d = 0;
            if (!int.TryParse(modelo.RespuestaID, out d))
            {
                modelo.RespuestaID = "-1";
            }

            string sentencia = "sp_upd_ctl_tae";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("ecarrier_id", modelo.Carrier);
                    cmd.Parameters.Add("enum_remision", modelo.Remision);
                    cmd.Parameters.Add("enum_telefono", modelo.Telefono);
                    cmd.Parameters.Add("earticulo_id", modelo.Articulo);
                    cmd.Parameters.Add("eimporte", modelo.Importe);
                    cmd.Parameters.Add("efecha_alta", modelo.Fecha);
                    cmd.Parameters.Add("egrupo", modelo.Grupo);
                    cmd.Parameters.Add("ecadena", modelo.Cadena);
                    cmd.Parameters.Add("esucursal", modelo.Sucursal);
                    cmd.Parameters.Add("ecaja", modelo.Caja);
                    cmd.Parameters.Add("ereferencia", modelo.Referencia);
                    cmd.Parameters.Add("erespuesta_id", int.Parse(modelo.RespuestaID));
                    cmd.Parameters.Add("erespuesta_desc", modelo.Respuesta);
                    cmd.Parameters.Add("enom_archivo", modelo.Archivo);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();

                        var id = cmd.ExecuteScalar();
                        if (outparam.Value.ToString().IsInteger())
                        {
                            if (int.Parse(outparam.Value.ToString()) < 0)
                            {
                                throw new Exception("Ha ocurrido un error al insetrar el registro" + id.ToString());
                            }
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

        public static List<SIFModelo.RemisionDetalle> ProductosTAE(SIFModelo.WebServices.Carrier Carrier)
        {
            string sentencia = "SELECT * FROM cat_carrier_sku WHERE carrier_id = :CarrierID ORDER BY monto asc ";
            List<SIFModelo.RemisionDetalle> articulos = new List<SIFModelo.RemisionDetalle>();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //Parametros
                    cmd.Parameters.Add("CarrierID", Carrier.CarrierID);

                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.WebServices.TAE registro = new SIFModelo.WebServices.TAE();

                            SIFModelo.RemisionDetalle item = new SIFModelo.RemisionDetalle();
                            item.Precio = decimal.Parse(oreader["MONTO"].ToString());
                            item.ArticuloID = oreader["SKU"].ToString();
                            item.Nombre1 = oreader["CLAVE"].ToString();
                            item.Nombre2 = oreader["CARRIER_ID"].ToString();

                            articulos.Add(item);
                        }
                    }

                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);

                }

            }
            return articulos;
        }
    }
}
