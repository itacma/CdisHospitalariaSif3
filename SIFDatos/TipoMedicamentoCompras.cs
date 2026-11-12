using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
namespace SIFDatos
{
    public static class TiposMedicamentoCompras
    {
        /// <summary>
        /// Utiliza el SP_INS_TipoMedicamento para agregar un TipoMedicamentoCompras
        /// </summary>
        /// <param name="modelo">La instancia del TipoMedicamentoCompras</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.TipoMedicamentoCompras modelo)
        {
            string sentencia = "SP_INS_TIPO_MED_COMPRAS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nombre", modelo.Nombre);
                    cmd.Parameters.Add("clave", modelo.Clave);
                    cmd.Parameters.Add("tipo", modelo.Tipo);
                    cmd.Parameters.Add("oc_segmenta", modelo.oc_segmenta);
                    //cmd.Parameters.Add("activo", System.Convert.ToChar(modelo.Receta));

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

        public static bool Elimina(SIFModelo.TipoMedicamentoCompras modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_TIPO_MED_COMPRAS";
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

        public static bool Actualiza(SIFModelo.TipoMedicamentoCompras modelo)
        {
            string sentencia = "SP_UPD_TIPO_MED_COMPRAS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("eid", modelo.ID);
                    cmd.Parameters.Add("enombre", modelo.Nombre);
                    cmd.Parameters.Add("eclave", modelo.Clave);
                    cmd.Parameters.Add("etipo", modelo.Tipo);
                    cmd.Parameters.Add("eoc_segmenta", modelo.oc_segmenta);

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

        public static List<SIFModelo.TipoMedicamentoCompras> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.TipoMedicamentoCompras> rows = new List<SIFModelo.TipoMedicamentoCompras>();

            string sentencia = "SELECT * FROM TIPO_MEDICAMENTO_COMPRAS";

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
                            SIFModelo.TipoMedicamentoCompras registro = new SIFModelo.TipoMedicamentoCompras();
                            registro.ID = int.Parse(oreader["TIPO_MEDICAMENTO_COMPRAS_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Clave = oreader["CLAVE"].ToString();
                            registro.Tipo = int.Parse(oreader["TIPO"].ToString());
                            registro.oc_segmenta = int.Parse(oreader["oc_segmenta"].ToString());

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

        //public static List<SIFModelo.Tipos.ClaveTipoMedicamento> ClavesTipoMedicamento()
        //{
        //    List<SIFModelo.Tipos.ClaveTipoMedicamento> Claves = new List<SIFModelo.Tipos.ClaveTipoMedicamento>();

        //    SIFModelo.Tipos.ClaveTipoMedicamento N_A = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "N/A" };
        //    SIFModelo.Tipos.ClaveTipoMedicamento CO1 = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "CO1" };
        //    SIFModelo.Tipos.ClaveTipoMedicamento CO2 = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "CO2" };
        //    SIFModelo.Tipos.ClaveTipoMedicamento CO3 = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "CO3" };
        //    SIFModelo.Tipos.ClaveTipoMedicamento ANT = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "ANT" };
        //    SIFModelo.Tipos.ClaveTipoMedicamento ONC = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "ONC" };
        //    SIFModelo.Tipos.ClaveTipoMedicamento OTC = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "OTC" };
        //    SIFModelo.Tipos.ClaveTipoMedicamento POP = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "POP" };
        //    SIFModelo.Tipos.ClaveTipoMedicamento CAR = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "CAR" };
        //    SIFModelo.Tipos.ClaveTipoMedicamento REF = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "REF" };
        //    SIFModelo.Tipos.ClaveTipoMedicamento LAC = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "LAC" };
        //    SIFModelo.Tipos.ClaveTipoMedicamento DER = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "DER" };

        //    Claves.Add(N_A);
        //    Claves.Add(CO1);
        //    Claves.Add(CO2);
        //    Claves.Add(CO3);
        //    Claves.Add(ANT);
        //    Claves.Add(ONC);
        //    Claves.Add(OTC);
        //    Claves.Add(POP);
        //    Claves.Add(CAR);
        //    Claves.Add(REF);
        //    Claves.Add(LAC);
        //    Claves.Add(DER);

        //    return Claves;
        //}


        public static List<SIFModelo.TipoMedicamentoCompras> Tipos(int tipo)
        {
            List<SIFModelo.TipoMedicamentoCompras> rows = new List<SIFModelo.TipoMedicamentoCompras>();

            string sentencia = "SELECT * FROM TIPO_MEDICAMENTO_COMPRAS WHERE tipo = " + tipo + " ORDER BY  tipo_medicamento_compras_id ";

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
                            SIFModelo.TipoMedicamentoCompras registro = new SIFModelo.TipoMedicamentoCompras();
                            registro.ID = int.Parse(oreader["TIPO_MEDICAMENTO_COMPRAS_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Clave = oreader["CLAVE"].ToString();
                            registro.Tipo = System.Convert.ToInt32(oreader["TIPO"]);
                            registro.oc_segmenta = System.Convert.ToInt32(oreader["oc_segmenta"]);
                            //registro.Receta = (System.Convert.ToChar(oreader["RECETA"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);
                            //registro.Activo = (System.Convert.ToChar(oreader["ACTIVO"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);

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
    }
}
