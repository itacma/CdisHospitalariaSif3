using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace SIFDatos.Extras
{
    public class CarrierSKU
    {
        /// <summary>
        /// Utiliza el SP_INS_Extras.Carrier para agregar un Extras.Carrier
        /// </summary>
        /// <param name="modelo">La instancia del Extras.Carrier</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.Extras.CarrierSKU modelo)
        {
            string sentencia = "sp_ins_cat_carrier_sku";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nombre", modelo.SKU);

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

                            modelo.CarrierID = int.Parse(id.ToString());
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

        public static bool Elimina(SIFModelo.Extras.CarrierSKU modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_Carrier";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("ID", modelo.CarrierID);

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

                        modelo.CarrierID = 10;

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

        public static bool Actualiza(SIFModelo.Extras.CarrierSKU modelo)
        {
            string sentencia = "sp_upd_cat_carrier";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("carrier_id", modelo.CarrierID);
                    cmd.Parameters.Add("enom", modelo.SKU);
                    cmd.Parameters.Add("eactivo", System.Convert.ToChar(modelo.Activo));

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Int32);
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }

            return true;
        }

        public static List<SIFModelo.Extras.CarrierSKU> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.Extras.CarrierSKU> rows = new List<SIFModelo.Extras.CarrierSKU>();

            string sentencia = "SELECT * FROM cat_carriers";

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
                            SIFModelo.Extras.CarrierSKU registro = new SIFModelo.Extras.CarrierSKU();

                            registro.CarrierID = int.Parse(oreader["carrier_id"].ToString());
                            registro.SKU = oreader["NOMBRE"].ToString();
                            registro.Activo = (SIFModelo.Tipos.SiNo)(oreader["DEBITO"].ToString()[0]);

                            rows.Add(registro);
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);

                }

            }
            return rows;
        }

    }
}
