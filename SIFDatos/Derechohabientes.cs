using System;
using System.Collections.Generic;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using DevComponents.DotNetBar;
namespace SIFDatos
{
    public static class Derechohabientes
    {
        /// <summary>
        /// Utiliza el SP_INS_TipoDevolucion para agregar un TipoDevolucion
        /// </summary>
        /// <param name="modelo">La instancia del TipoDevolucion</param>
        /// <returns>bool Insertado</returns>
        /*public static bool Inserta(SIFModelo.TipoDevolucion modelo)
        {
            string sentencia = "sp_ins_cat_tipo_devolucion";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nombre", modelo.Nombre);
                    cmd.Parameters.Add("compra_venta", System.Convert.ToChar(modelo.CompraVenta));

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

                            modelo.TipoDevolucionID = int.Parse(id.ToString());
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                    }

                }
            }

            return true;
        }

        public static bool Elimina(SIFModelo.TipoDevolucion modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_TIPO_DEVOLUCION";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("ID", modelo.TipoDevolucionID);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

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
                    }

                }
            }

            return true;
        }

        public static bool Actualiza(SIFModelo.TipoDevolucion modelo)
        {
            string sentencia = "sp_upd_cat_tipo_devolucion";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("edev_id", modelo.TipoDevolucionID);
                    cmd.Parameters.Add("enom", modelo.Nombre);
                    cmd.Parameters.Add("eactivo", System.Convert.ToChar(modelo.Activo));
                    cmd.Parameters.Add("ecpra_vta", System.Convert.ToChar(modelo.CompraVenta));

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
                    }

                }
            }

            return true;
        }
        */

        public static List<SIFModelo.hupBnf> Busca(string id)
        {
            List<SIFModelo.hupBnf> rows = new List<SIFModelo.hupBnf>();

            string sentencia = "SELECT * FROM HUPBNF where( idemp =trim(:idemp) or idbnf =trim(:idemp)) ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //
                    cmd.Parameters.Add("idemp", id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.hupBnf registro = new SIFModelo.hupBnf();

                            registro.IDEmp = oreader["IDEMP"].ToString();
                            registro.IDBnf = oreader["IDBNF"].ToString();
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Parentesco = oreader["PARENTESCO"].ToString();
                            registro.Expediente = oreader["EXPEDIENTE"].ToString();
                            registro.Estado = (System.Convert.ToChar(oreader["ESTADO"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);
                            /*
                            registro.TipoDevolucionID = int.Parse(oreader["TIPO_DEVOLUCION_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Activo = (System.Convert.ToChar(oreader["ACTIVO"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);
                            registro.CompraVenta = (SIFModelo.Tipos.CompraVenta)(System.Convert.ToSByte(oreader["COMPRA_VENTA"].ToString()[0]));
                            */
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
        public static SIFModelo.hupMed BuscaM(string id)
        {
            SIFModelo.hupMed registro = new SIFModelo.hupMed();

            //string sentencia = "SELECT * FROM HUPMED where id =trim(:idMED) ";
            string sentencia = "SELECT HUPMED.ID,HUPMED.NOMBRE, HUPMED.CEDULA,HUPMED.ESTADO,HUPESP.ESPECIALIDAD FROM HUPMED ,hupesp where HUPESP.ESPID=HUPMED.ESPECIALIDAD AND  HUPMED.id =trim(:idMED)";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //
                        cmd.Parameters.Add("idMED", id);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            //while (oreader.Read())
                            //{
                            //SIFModelo.hupBnf registro = new SIFModelo.hupBnf();

                            registro.IDmed = oreader["ID"].ToString();
                            // registro.IDBnf = oreader["IDBNF"].ToString();
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Especialidad = oreader["ESPECIALIDAD"].ToString();
                            registro.Cedula = oreader["CEDULA"].ToString();
                            registro.Estado = (System.Convert.ToChar(oreader["ESTADO"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);
                            /*
                            registro.TipoDevolucionID = int.Parse(oreader["TIPO_DEVOLUCION_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Activo = (System.Convert.ToChar(oreader["ACTIVO"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);
                            registro.CompraVenta = (SIFModelo.Tipos.CompraVenta)(System.Convert.ToSByte(oreader["COMPRA_VENTA"].ToString()[0]));
                            */
                            return (registro);
                            //}
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
            return registro;
        }

        public static SIFModelo.hupDReceta BuscaReceta(string id)
        {
            SIFModelo.hupDReceta registro = new SIFModelo.hupDReceta();

            string sentencia = "SELECT * FROM HUP_RECETA_HUP where num_remision =trim(:idemp) ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //
                        cmd.Parameters.Add("idemp", id);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            //while (oreader.Read())
                            //{
                            //SIFModelo.hupBnf registro = new SIFModelo.hupBnf();
                            registro.Num_remision = oreader["NUM_REMISION"].ToString();
                            registro.Receta = oreader["RECETA"].ToString();
                            registro.Tipo = oreader["TIPO"].ToString();
                            registro.FechaS = oreader["FECHA_SURTIDO"].ToString();
                            registro.FechaR = oreader["FECHA_RECETA"].ToString();
                            registro.Id_pac = oreader["ID_PAC"].ToString();
                            registro.Id_med = oreader["ID_MED"].ToString();
                            registro.meses = oreader["MESES"].ToString();

                            return (registro);
                            //}
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
            return registro;
        }

        public static SIFModelo.hupEmp BuscaEmpleado(string id)
        {
            SIFModelo.hupEmp registro = new SIFModelo.hupEmp();

            string sentencia = "SELECT * FROM hupemp where id =trim(:idemp) ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //
                        cmd.Parameters.Add("idemp", id);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            //while (oreader.Read())
                            //{
                            //SIFModelo.hupBnf registro = new SIFModelo.hupBnf();
                            registro.ID = oreader["ID"].ToString();
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.deptoid = oreader["DEPTOID"].ToString();
                            registro.Estado = (System.Convert.ToChar(oreader["ESTADO"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);


                            return (registro);
                            //}
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
            return registro;
        }
        public static SIFModelo.hupBnf BuscaB(string id)
        {
            SIFModelo.hupBnf registro = new SIFModelo.hupBnf();

            string sentencia = "SELECT * FROM HUPBNF where idbnf =trim(:idemp) ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //
                        cmd.Parameters.Add("idemp", id);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            //while (oreader.Read())
                            //{
                            //SIFModelo.hupBnf registro = new SIFModelo.hupBnf();

                            registro.IDEmp = oreader["IDEMP"].ToString();
                            registro.IDBnf = oreader["IDBNF"].ToString();
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Parentesco = oreader["PARENTESCO"].ToString();
                            registro.Expediente = oreader["EXPEDIENTE"].ToString();
                            registro.Estado = (System.Convert.ToChar(oreader["ESTADO"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);
                            /*
                            registro.TipoDevolucionID = int.Parse(oreader["TIPO_DEVOLUCION_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Activo = (System.Convert.ToChar(oreader["ACTIVO"]) == 'S' ? SIFModelo.Tipos.SiNo.SI : SIFModelo.Tipos.SiNo.NO);
                            registro.CompraVenta = (SIFModelo.Tipos.CompraVenta)(System.Convert.ToSByte(oreader["COMPRA_VENTA"].ToString()[0]));
                            */
                            return (registro);
                            //}
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
            return registro;
        }

        public static SIFModelo.cliente_Hup BuscaCliente(string id)
        {
           // SIFModelo.cliente_Hup rows = new SIFModelo.cliente_Hup();
            SIFModelo.cliente_Hup registro = new SIFModelo.cliente_Hup();
            string sentencia = "SELECT * FROM HUP_CLIENTE_HUP where cliente_id =trim(:idcli) ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //
                        cmd.Parameters.Add("idcli", id);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                //SIFModelo.cliente_Hup registro = new SIFModelo.cliente_Hup();
                                registro.cliente_id = int.Parse(oreader["CLIENTE_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();

                                // rows.Add(registro);
                            }
                            return registro;
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
        public static SIFModelo.hupDReceta guardaReceta(SIFModelo.hupDReceta datosr)
        {
           
           // string sentencia = "INSERT INTO HUP_RECETA_HUP (NUM_REMISION,RECETA,TIPO,FECHA_SURTIDO,FECHA_RECETA,ID_PAC,ID_MED,MESES)VALUES(':NREMISION',':NRECETA',':RTIPO',:RFECHAS,:RFECHAR,':IDPAC',':IDMED',':MES') ";
            string sentencia = "INSERT INTO HUP_RECETA_HUP (NUM_REMISION,RECETA,TIPO,FECHA_SURTIDO,FECHA_RECETA,ID_PAC,ID_MED,MESES)VALUES ('" + datosr.Num_remision + "','" + datosr.Receta + "','" + datosr.Tipo + "','" + datosr.FechaS + "','" + datosr.FechaR + "','" +  datosr.Id_pac + "','" +  datosr.Id_med + "','" + datosr.meses + "')";
                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                   {
                        //PARAMETROS
                                                                                                                                                                                                               cmd.Parameters.Add("NREMISION", datosr.Num_remision);
                                                                                                                                                                                                               cmd.Parameters.Add("NRECETA", datosr.Receta);
                                                                                                                                                                                                               cmd.Parameters.Add("RTIPO", datosr.Tipo);
                                                                                                                                                                                                               cmd.Parameters.Add("RFECHAS", datosr.FechaS);
                                                                                                                                                                                                               cmd.Parameters.Add("RFECHAR", datosr.FechaR);
                                                                                                                                                                                                               cmd.Parameters.Add("IDPAC", datosr.Id_pac);
                                                                                                                                                                                                               cmd.Parameters.Add("IDMED", datosr.Id_med);
                                                                                                                                                                                                               cmd.Parameters.Add("MES", datosr.meses);

                        try
                        {
                            cmd.Connection.Open();
                           MessageBox.Show("..GUARDANDO RECETA..");
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                           MessageBox.Show("Error:" + ex.Message);
                            //return null;
                        }
                        finally 
                        {
                            //MessageBox.Show(cmd.CommandText.ToString());
                           // MessageBox.Show(cnx.ConnectionString.ToString());
                           // MessageBox.Show(cmd.Connection.ToString());
                            cmd.Connection.Close();                        
                            cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                    }
                }

                return null;
        }

     
    }
}
