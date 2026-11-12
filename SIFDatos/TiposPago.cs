using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
namespace SIFDatos
{
    public static class TipoPagos
    {
        /// <summary>
        /// Utiliza el SP_INS_TipoPago para agregar un TipoPago
        /// </summary>
        /// <param name="modelo">La instancia del TipoPago</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.TipoPago modelo)
        {
            string sentencia = "SP_INS_CAT_TIPO_PAGO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nombre", modelo.Nombre);
                    cmd.Parameters.Add("comision", (char)modelo.Comision);
                    cmd.Parameters.Add("porcentaje", modelo.Porcentaje);
                    cmd.Parameters.Add("fecha_alta", modelo.FechaAlta);

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

        public static bool Elimina(SIFModelo.TipoPago modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_TIPO_PAGO";
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

        public static bool Actualiza(SIFModelo.TipoPago modelo)
        {
            string sentencia = "SP_UPD_CAT_TIPO_PAGO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("eid", modelo.ID);
                    cmd.Parameters.Add("enombre", modelo.Nombre);
                    cmd.Parameters.Add("ecomision", (char)modelo.Comision);
                    cmd.Parameters.Add("eporcentaje", modelo.Porcentaje);
                    cmd.Parameters.Add("efecha_alta", modelo.FechaAlta);
                    cmd.Parameters.Add("eactivo", System.Convert.ToChar(modelo.Activo));
                    cmd.Parameters.Add("efecha_baja", modelo.FechaBaja);

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

        public static List<SIFModelo.TipoPago> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.TipoPago> rows = new List<SIFModelo.TipoPago>();

            string sentencia = "SELECT * FROM cat_tipo_pago";

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
                            SIFModelo.TipoPago registro = new SIFModelo.TipoPago();

                            registro.ID = int.Parse(oreader["TIPO_PAGO_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Comision = (SIFModelo.Tipos.SiNo)(oreader["COMISION"].ToString()[0]);
                            registro.Porcentaje = System.Convert.ToDecimal(oreader["PORCENTAJE"]);
                            registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                            if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                            {
                                registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                            }
                            registro.Activo = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
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

        public static List<SIFModelo.Tipos.TipoPago> TiposPago()
        {
            List<SIFModelo.Tipos.TipoPago> tiposPago = new List<SIFModelo.Tipos.TipoPago>();


            SIFModelo.Tipos.TipoPago noIdentificado = new SIFModelo.Tipos.TipoPago() { Tipo = "NO IDENTIFICADO" };
            SIFModelo.Tipos.TipoPago efectivo = new SIFModelo.Tipos.TipoPago() { Tipo = "EFECTIVO" };
            SIFModelo.Tipos.TipoPago tCredito = new SIFModelo.Tipos.TipoPago() { Tipo = "T.CREDITO" };
            SIFModelo.Tipos.TipoPago tDebito = new SIFModelo.Tipos.TipoPago() { Tipo = "T.DEBITO" };
            SIFModelo.Tipos.TipoPago cheque = new SIFModelo.Tipos.TipoPago() { Tipo = "CHEQUE" };
            SIFModelo.Tipos.TipoPago valesDevolucion = new SIFModelo.Tipos.TipoPago() { Tipo = "VALES DEVOLUCION" };
            SIFModelo.Tipos.TipoPago valesConvenio = new SIFModelo.Tipos.TipoPago() { Tipo = "VALES CONVENIO" };
            SIFModelo.Tipos.TipoPago spei = new SIFModelo.Tipos.TipoPago() { Tipo = "SPEI" };

            tiposPago.Add(noIdentificado);
            tiposPago.Add(efectivo);
            tiposPago.Add(tCredito);
            tiposPago.Add(tDebito);
            tiposPago.Add(cheque);
            tiposPago.Add(valesDevolucion);
            tiposPago.Add(valesConvenio);
            tiposPago.Add(spei);

            return tiposPago;
        }


        public static SIFModelo.TipoPago TipoPagoPorID(int p)
        {
            List<SIFModelo.TipoPago> rows = new List<SIFModelo.TipoPago>();

            string sentencia = "SELECT * FROM cat_tipo_pago WHERE TIPO_PAGO_ID = :TipoPago";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //
                        cmd.Parameters.Add("TipoPago", p);

                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.TipoPago registro = new SIFModelo.TipoPago();

                                registro.ID = int.Parse(oreader["TIPO_PAGO_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();
                                registro.Comision = (SIFModelo.Tipos.SiNo)(oreader["COMISION"].ToString()[0]);
                                registro.Porcentaje = System.Convert.ToDecimal(oreader["PORCENTAJE"]);
                                registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                                if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                                {
                                    registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                                }
                                registro.Activo = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
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
