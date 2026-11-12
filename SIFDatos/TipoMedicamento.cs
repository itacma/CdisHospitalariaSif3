using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
namespace SIFDatos
{
    public static class TiposMedicamento
    {
        /// <summary>
        /// Utiliza el SP_INS_TipoMedicamento para agregar un TipoMedicamento
        /// </summary>
        /// <param name="modelo">La instancia del TipoMedicamento</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.TipoMedicamento modelo)
        {
            string sentencia = "SP_INS_CAT_TIPO_MEDICAMENTO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nombre", modelo.Nombre);
                    cmd.Parameters.Add("clave", modelo.Clave);
                    cmd.Parameters.Add("receta", System.Convert.ToChar(modelo.Receta));
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

            string sentencia = "SP_DEL_TipoMedicamento";
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

        public static bool Actualiza(SIFModelo.TipoMedicamento modelo)
        {
            string sentencia = "SP_UPD_CAT_TIPO_MEDICAMENTO";
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
                    cmd.Parameters.Add("ereceta", System.Convert.ToChar(modelo.Receta));
                    cmd.Parameters.Add("eactivo", System.Convert.ToChar(modelo.Activo));

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
        //public class A : B { }
    
        public static List<SIFModelo.TipoMedicamento> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.TipoMedicamento> rows = new List<SIFModelo.TipoMedicamento>();

            string sentencia = "SELECT * FROM cat_tipo_medicamento";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
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
                                SIFModelo.TipoMedicamento registro = new SIFModelo.TipoMedicamento();
                                registro.ID = int.Parse(oreader["TIPO_MEDICAMENTO_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();
                                registro.Clave = oreader["CLAVE"].ToString();
                                registro.Receta = (System.Convert.ToChar(oreader["RECETA"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);
                                registro.Activo = (System.Convert.ToChar(oreader["ACTIVO"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);

                                rows.Add(registro);
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
            return rows;
        }
        public static List<SIFModelo.Tipos.tipo6> BuscaTipo6(string activo )
        {
            ///<summary>
            ///se agrega tipo 6 solicitud de precios 23/07/2019 JMQC
            /// </summary>
            List<SIFModelo.Tipos.tipo6> rows = new List<SIFModelo.Tipos.tipo6>();

            string sentencia = "SELECT ID, NOMBRE  ,ACTIVO FROM cat_tipo6 where activo like '"+activo+"'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
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
                                SIFModelo.Tipos.tipo6 registro = new SIFModelo.Tipos.tipo6();
                                registro.id = int.Parse(oreader["ID"].ToString());
                                registro.nombre = oreader["NOMBRE"].ToString();
                                registro.activo = oreader["ACTIVO"].ToString();

                                rows.Add(registro);
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
            return rows;
        }
        public static List<SIFModelo.Tipos.ClaveTipoMedicamento> ClavesTipoMedicamento()
        {
            List<SIFModelo.Tipos.ClaveTipoMedicamento> Claves = new List<SIFModelo.Tipos.ClaveTipoMedicamento>();

            SIFModelo.Tipos.ClaveTipoMedicamento N_A = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "N/A" };
            SIFModelo.Tipos.ClaveTipoMedicamento CO1 = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "CO1" };
            SIFModelo.Tipos.ClaveTipoMedicamento CO2 = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "CO2" };
            SIFModelo.Tipos.ClaveTipoMedicamento CO3 = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "CO3" };
            SIFModelo.Tipos.ClaveTipoMedicamento ANT = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "ANT" };
            SIFModelo.Tipos.ClaveTipoMedicamento ONC = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "ONC" };
            SIFModelo.Tipos.ClaveTipoMedicamento OTC = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "OTC" };
            SIFModelo.Tipos.ClaveTipoMedicamento POP = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "POP" };
            SIFModelo.Tipos.ClaveTipoMedicamento CAR = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "CAR" };
            SIFModelo.Tipos.ClaveTipoMedicamento REF = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "REF" };
            SIFModelo.Tipos.ClaveTipoMedicamento LAC = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "LAC" };
            SIFModelo.Tipos.ClaveTipoMedicamento DER = new SIFModelo.Tipos.ClaveTipoMedicamento() { Clave = "DER" };

            Claves.Add(N_A);
            Claves.Add(CO1);
            Claves.Add(CO2);
            Claves.Add(CO3);
            Claves.Add(ANT);
            Claves.Add(ONC);
            Claves.Add(OTC);
            Claves.Add(POP);
            Claves.Add(CAR);
            Claves.Add(REF);
            Claves.Add(LAC);
            Claves.Add(DER);

            return Claves;
        }


        public static List<SIFModelo.TipoMedicamento> Tipos(int tipo)
        {
            List<SIFModelo.TipoMedicamento> rows = new List<SIFModelo.TipoMedicamento>();

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
                            SIFModelo.TipoMedicamento registro = new SIFModelo.TipoMedicamento();
                            registro.ID = int.Parse(oreader["TIPO_MEDICAMENTO_COMPRAS_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Clave = oreader["CLAVE"].ToString();
                            //registro.Tipo = System.Convert.ToInt32(oreader["TIPO"]);
                            //registro.Receta = (System.Convert.ToChar(oreader["RECETA"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);
                            //registro.Activo = (System.Convert.ToChar(oreader["ACTIVO"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);

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

        public static List<SIFModelo.CatClavesSat> TiposSat()
            {
            List<SIFModelo.CatClavesSat> rows = new List<SIFModelo.CatClavesSat>();

            string sentencia = "select clave_id , clave_prod_serv, clave_prod_serv||' - '||descripcion descripcion ,  FECHA_INICIO_VIG,FECHA_FIN_VIG from cat_claves_sat where activo ='S'";

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
                            SIFModelo.CatClavesSat registro = new SIFModelo.CatClavesSat();
                            //registro.ID = int.Parse(oreader["CLAVE_ID"].ToString());
                            registro.clave = oreader["CLAVE_PROD_SERV"].ToString();
                            registro.Descripcion = oreader["DESCRIPCION"].ToString();
                            //registro.Tipo = System.Convert.ToInt32(oreader["TIPO"]);
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
