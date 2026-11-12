using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
namespace SIFDatos
{
    public static class ClienteConvenios
    {
        /// <summary>
        /// Utiliza el SP_INS_ClienteConvenio para agregar un ClienteConvenio
        /// </summary>
        /// <param name="modelo">La instancia del ClienteConvenio</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.ClienteConvenio modelo)
        {
            string sentencia = "SP_INS_CAT_CLIENTE_CONVENIO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("cliente_id", modelo.ID);
                    cmd.Parameters.Add("tipo_pago", modelo.TipoPagoID);
                    cmd.Parameters.Add("dias_plazo", modelo.DiasPlazo);
                    cmd.Parameters.Add("condicion_vta", System.Convert.ToChar(modelo.CondicionVenta));
                    cmd.Parameters.Add("dia_vencimiento", modelo.DiaVencimiento);
                    cmd.Parameters.Add("saldo", modelo.Saldo);
                    cmd.Parameters.Add("lim_credito", modelo.LimiteCredito);
                    cmd.Parameters.Add("porcentaje_sobre_costo", modelo.PorScosto);
                    cmd.Parameters.Add("porcentaje_descuento", modelo.PorDesc);
                    cmd.Parameters.Add("Precio_fijo", System.Convert.ToChar(modelo.PrecioFijo));
                    cmd.Parameters.Add("Num_cuenta", modelo.numCta);

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

        public static bool Elimina(SIFModelo.ClienteConvenio modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_ClienteConvenio";
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

        public static bool Actualiza(SIFModelo.ClienteConvenio modelo)
        {
            string sentencia = "SP_UPD_CAT_CLIENTE_CONVENIO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("eid", modelo.ID);
                    cmd.Parameters.Add("etipo_pago", modelo.TipoPagoID);
                    cmd.Parameters.Add("edias_plazo", modelo.DiasPlazo);
                    cmd.Parameters.Add("econdicion_vta", System.Convert.ToChar(modelo.CondicionVenta));
                    cmd.Parameters.Add("edia_vencimiento", modelo.DiaVencimiento);
                    cmd.Parameters.Add("esaldo", modelo.Saldo);
                    cmd.Parameters.Add("elim_credito", modelo.LimiteCredito);
                    cmd.Parameters.Add("eporcentaje_sobre_costo", modelo.PorScosto);
                    cmd.Parameters.Add("eporcentaje_descuento", modelo.PorDesc);
                    cmd.Parameters.Add("ePrecio_fijo", System.Convert.ToChar(modelo.PrecioFijo));
                    cmd.Parameters.Add("eNum_cuenta", modelo.numCta);
                    
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

        public static List<SIFModelo.ClienteConvenio> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.ClienteConvenio> rows = new List<SIFModelo.ClienteConvenio>();

            string sentencia = "SELECT * FROM cat_cliente_convenio";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //TIPO DE COMANDO
                    cmd.CommandType = CommandType.StoredProcedure;
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("REFCUR", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.ClienteConvenio registro = new SIFModelo.ClienteConvenio()
                            {
                                ID = int.Parse(oreader["CLIENTE_CONVENIO_ID"].ToString()),
                                TipoPagoID = int.Parse(oreader["TIPO_PAGO"].ToString()),
                                DiasPlazo = int.Parse(oreader["DIAS_PLAZO"].ToString()),
                                CondicionVenta = (SIFModelo.Tipos.CondicionVenta)(System.Convert.ToSByte(oreader["CONDICION_VTA"]).ToString()[0]),
                                DiaVencimiento = int.Parse(oreader["DIA_VENCIMIENTO"].ToString()),
                                Saldo = System.Convert.ToDecimal(oreader["SALDO"]),
                                LimiteCredito = System.Convert.ToDecimal(oreader["LIM_CREDITO"]),
                                PorDesc = System.Convert.ToInt16(oreader["PORCENTAJE_DESCUENTO"]),
                                PorScosto = System.Convert.ToInt16(oreader["PORCENTAJE_SOBRE_COSTO"]),
                                PrecioFijo = (SIFModelo.Tipos.SiNo)(System.Convert.ToSByte(oreader["PRECIO_FIJO"]).ToString()[0]),
                                numCta = oreader["PRECIO_FIJO"].ToString()
                            };
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


        public static SIFModelo.ClienteConvenio ClienteConvenioPorID(int p)
        {
            string sentencia = "SELECT * FROM cat_cliente_convenio WHERE CLIENTE_CONVENIO_ID = :ClienteID";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //PARAMETROS ENTRADA
                        cmd.Parameters.Add("ClienteID", p);

                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.ClienteConvenio registro = new SIFModelo.ClienteConvenio();
                                registro.ID = int.Parse(oreader["CLIENTE_CONVENIO_ID"].ToString());
                                registro.TipoPagoID = int.Parse(oreader["TIPO_PAGO"].ToString());
                                registro.DiasPlazo = int.Parse(oreader["DIAS_PLAZO"].ToString());
                                registro.CondicionVenta = (SIFModelo.Tipos.CondicionVenta)(System.Convert.ToSByte(oreader["CONDICION_VTA"].ToString()[0]));
                                registro.DiaVencimiento = int.Parse(oreader["DIA_VENCIMIENTO"].ToString());
                                registro.Saldo = System.Convert.ToDecimal(oreader["SALDO"]);
                                registro.LimiteCredito = System.Convert.ToDecimal(oreader["LIM_CREDITO"]);
                                registro.PorScosto = System.Convert.ToInt16(oreader["PORCENTAJE_SOBRE_COSTO"]);
                                registro.PorDesc = System.Convert.ToInt16(oreader["PORCENTAJE_DESCUENTO"]);
                                registro.numCta = oreader["NUM_CUENTA"].ToString();
                                if (oreader["PRECIO_FIJO"].ToString() != "")
                                    registro.PrecioFijo = (SIFModelo.Tipos.SiNo)(System.Convert.ToSByte(oreader["PRECIO_FIJO"].ToString()[0]));
                                else
                                    registro.PrecioFijo = SIFModelo.Tipos.SiNo.NO;
                                return registro;
                            }
                        }

                    }
                }
                catch { }
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
        }
    }
}
