using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
using DevComponents.DotNetBar;
using System.Windows.Forms;
namespace SIFDatos
{
    public static class Sucursales
    {
        /// <summary>
        /// Utiliza el SP_INS_Sucursal para agregar un Sucursal
        /// </summary>
        /// <param name="modelo">La instancia del Sucursal</param>
        /// <returns>bool Insertado</returns>
        public static SIFModelo.Sucursal Inserta(SIFModelo.Sucursal modelo)
        {
            string sentencia = "SP_INS_CAT_SUCURSALES";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nombre", modelo.Nombre);
                    cmd.Parameters.Add("calle", modelo.Calle);
                    cmd.Parameters.Add("colonia", modelo.Colonia);
                    cmd.Parameters.Add("cp", modelo.CodigoPostal);
                    cmd.Parameters.Add("ciudad", modelo.Ciudad);
                    cmd.Parameters.Add("no_ext", modelo.NumeroExterior);
                    cmd.Parameters.Add("no_int", modelo.NumeroInterior);
                    cmd.Parameters.Add("municipio", modelo.Municipio);
                    cmd.Parameters.Add("responsable_id", modelo.ResponsableID);
                    cmd.Parameters.Add("telefono", modelo.Telefono);
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("sucursal_usr", modelo.SucursalUsuario);
                    cmd.Parameters.Add("sucursal_cve", modelo.SucursalClave);
                    cmd.Parameters.Add("nadro_id", modelo.NadroID);
                    cmd.Parameters.Add("pfizer_id", modelo.PfizerID);
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
                            else
                            {
                                modelo.SucursalesID = int.Parse(id.ToString());
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

            return modelo;
        }

        public static bool Elimina(SIFModelo.Sucursal modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_SUCURSAL";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("ID", modelo.SucursalesID);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        id = cmd.ExecuteScalar();

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

        public static bool Actualiza(SIFModelo.Sucursal modelo)
        {
            string sentencia = "SP_UPD_CAT_SUCURSALES";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("esuc_id", modelo.SucursalesID);
                    cmd.Parameters.Add("enombre", modelo.Nombre);
                    cmd.Parameters.Add("ecalle", modelo.Calle);
                    cmd.Parameters.Add("ecolonia", modelo.Colonia);
                    cmd.Parameters.Add("ecp", modelo.CodigoPostal);
                    cmd.Parameters.Add("eciudad", modelo.Ciudad);
                    cmd.Parameters.Add("eno_ext", modelo.NumeroExterior);
                    cmd.Parameters.Add("eno_int", modelo.NumeroInterior);
                    cmd.Parameters.Add("emunicipio", modelo.Municipio);
                    cmd.Parameters.Add("eresponsable_id", modelo.ResponsableID);
                    cmd.Parameters.Add("etelefono", modelo.Telefono);
                    cmd.Parameters.Add("esucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("esucursal_usr", modelo.SucursalUsuario);
                    cmd.Parameters.Add("esucursal_cve", modelo.SucursalClave);
                    cmd.Parameters.Add("enadro_id", modelo.NadroID);
                    cmd.Parameters.Add("epfizer_id", modelo.PfizerID);
                    cmd.Parameters.Add("elink_almacen", modelo.Linkid);
                    
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                      id =  cmd.ExecuteScalar();
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
        public static void TestDBLink(string Link)
        {
            string ProductName="Conexion";
            string sqlSel = "SELECT * FROM DUAL@" + Link;
            using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlSel;

                OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (dr.HasRows)
                   MessageBox.Show("Conexión correcta", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                   MessageBox.Show("NO existe información link Sucursal", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                dr.Close();
                dr.Dispose();
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error:" + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        public static int ObtenExistencia(string Link, string Articulo_ID, int Suc)
        {
            string ProductName = "Existencia";
            string sqlSel = "SELECT existencia FROM inventario@" + Link +" where Articulo_ID="+Articulo_ID+" and Sucursal_ID="+Suc.ToString();
            using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    conn.Open();

                    // Create an OracleCommand
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sqlSel;

                    OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    if (dr.HasRows)
                        while (dr.Read())
                        {
                             return int.Parse(dr["existencia"].ToString());
                        }
                    else
                        return 0;

                    dr.Close();
                    dr.Dispose();
                }
                catch (Exception ex)
                {
                   MessageBox.Show("Error:" + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            return 0;
        }

        public static List<SIFModelo.Sucursal> Busca(string propiedad, string parametro)
        {
            string sentencia = "SELECT * FROM cat_sucursales WHERE SUCURSAL_USR='S' order by sucursales_id  asc";//JMQC //25/06/2018 agrego condicion sucursales_usr y ordenacion
            List<SIFModelo.Sucursal> rows = new List<SIFModelo.Sucursal>();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("REFCUR", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    //
                    try
                    {
                        cmd.Connection.Open();
                    }
                    catch(Exception _x)
                    {
                        return null;
                    }

                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Sucursal registro = new SIFModelo.Sucursal();

                            registro.SucursalesID = int.Parse(oreader["SUCURSALES_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Calle = oreader["CALLE"].ToString();
                            registro.Colonia = oreader["COLONIA"].ToString();
                            registro.CodigoPostal = oreader["CP"].ToString();
                            registro.Ciudad = oreader["CIUDAD"].ToString();
                            registro.NumeroExterior = oreader["NO_EXT"].ToString();
                            registro.NumeroInterior = oreader["NO_INT"].ToString();
                            registro.Municipio = oreader["MUNICIPIO"].ToString();
                            registro.ResponsableID = int.Parse( oreader["RESPONSABLE_ID"].ToString());
                            registro.Telefono = oreader["TELEFONO"].ToString();
                            registro.Linkid = oreader["LINK_ID"].ToString();

                            var sucursalID =oreader["SUCURSAL_ID"];
                            if (sucursalID.ToString().IsInteger())
                            {
                                registro.SucursalID = int.Parse(sucursalID.ToString());
                            }

                            var usuario = oreader["SUCURSAL_USR"];
                            if (!string.IsNullOrEmpty(usuario.ToString()))
                            {
                                registro.SucursalUsuario = oreader["SUCURSAL_USR"].ToString();
                            }

                            var sucursalClave = oreader["SUCURSAL_CVE"];
                            if(!string.IsNullOrEmpty(sucursalClave.ToString()))
                            {
                            registro.SucursalClave = oreader["SUCURSAL_CVE"].ToString();
                            }

                            string nadro = oreader["NADRO_ID"].ToString();
                            if (nadro.IsInteger())
                            {
                                registro.NadroID = int.Parse(nadro);
                            }

                            string pfizer = oreader["PFIZER_ID"].ToString();

                            if (pfizer.IsInteger())
                            {
                                registro.PfizerID = int.Parse(pfizer);
                            }

                            for (int i = 0; i < oreader.FieldCount; i++)//ITACMA
                            {//ITACMA
                                //var Q = oreader.GetName(i);
                                if (oreader.GetName(i) == "TIPO_SUCURSAL")//ITACMA
                                {
                                    registro.TipoSucursal = oreader["TIPO_SUCURSAL"].ToString();//ITACMA
                                }

                            }
                            rows.Add(registro);
                        }
                    }
                    if (null != cnx)
                    {
                        cmd.Connection.Close();
                   // cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                    }
                   
                }

               

            }
            return rows;
        }

        public static List<SIFModelo.Sucursal> BuscaAlmacenMandato(string propiedad, string parametro)
        {
            string sentencia = "SELECT * FROM cat_sucursales WHERE SUCURSAL_USR='S' and tipo_sucursal ='AM' order by sucursales_id  asc";//JMQC //25/06/2018 agrego condicion sucursales_usr y ordenacion
            List<SIFModelo.Sucursal> rows = new List<SIFModelo.Sucursal>();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("REFCUR", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    //
                    try
                    {
                        cmd.Connection.Open();
                    }
                    catch (Exception _x)
                    {
                        return null;
                    }

                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Sucursal registro = new SIFModelo.Sucursal();

                            registro.SucursalesID = int.Parse(oreader["SUCURSALES_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Calle = oreader["CALLE"].ToString();
                            registro.Colonia = oreader["COLONIA"].ToString();
                            registro.CodigoPostal = oreader["CP"].ToString();
                            registro.Ciudad = oreader["CIUDAD"].ToString();
                            registro.NumeroExterior = oreader["NO_EXT"].ToString();
                            registro.NumeroInterior = oreader["NO_INT"].ToString();
                            registro.Municipio = oreader["MUNICIPIO"].ToString();
                            registro.ResponsableID = int.Parse(oreader["RESPONSABLE_ID"].ToString());
                            registro.Telefono = oreader["TELEFONO"].ToString();
                            registro.Linkid = oreader["LINK_ID"].ToString();

                            var sucursalID = oreader["SUCURSAL_ID"];
                            if (sucursalID.ToString().IsInteger())
                            {
                                registro.SucursalID = int.Parse(sucursalID.ToString());
                            }

                            var usuario = oreader["SUCURSAL_USR"];
                            if (!string.IsNullOrEmpty(usuario.ToString()))
                            {
                                registro.SucursalUsuario = oreader["SUCURSAL_USR"].ToString();
                            }

                            var sucursalClave = oreader["SUCURSAL_CVE"];
                            if (!string.IsNullOrEmpty(sucursalClave.ToString()))
                            {
                                registro.SucursalClave = oreader["SUCURSAL_CVE"].ToString();
                            }

                            string nadro = oreader["NADRO_ID"].ToString();
                            if (nadro.IsInteger())
                            {
                                registro.NadroID = int.Parse(nadro);
                            }

                            string pfizer = oreader["PFIZER_ID"].ToString();

                            if (pfizer.IsInteger())
                            {
                                registro.PfizerID = int.Parse(pfizer);
                            }

                            for (int i = 0; i < oreader.FieldCount; i++)//ITACMA
                            {//ITACMA
                                //var Q = oreader.GetName(i);
                                if (oreader.GetName(i) == "TIPO_SUCURSAL")//ITACMA
                                {
                                    registro.TipoSucursal = oreader["TIPO_SUCURSAL"].ToString();//ITACMA
                                }

                            }
                            rows.Add(registro);
                        }
                    }
                    if (null != cnx)
                    {
                        cmd.Connection.Close();
                        // cmd.Connection.Dispose();
                        //OracleConnection.ClearPool(cnx);
                    }

                }



            }
            return rows;
        }



        public static List<SIFModelo.Sucursal> BuscaAlmacenNoVirtuales()
        {
            string sentencia = "SELECT * FROM cat_sucursales WHERE SUCURSAL_USR='S' and tipo_sucursal in ('CONVENIO', 'M','H' ) "+
                " order by sucursales_id  asc";//JMQC //25/06/2018 agrego condicion sucursales_usr y ordenacion
            List<SIFModelo.Sucursal> rows = new List<SIFModelo.Sucursal>();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("REFCUR", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    //
                    try
                    {
                        cmd.Connection.Open();
                    }
                    catch (Exception _x)
                    {
                        return null;
                    }

                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Sucursal registro = new SIFModelo.Sucursal();

                            registro.SucursalesID = int.Parse(oreader["SUCURSALES_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Calle = oreader["CALLE"].ToString();
                            registro.Colonia = oreader["COLONIA"].ToString();
                            registro.CodigoPostal = oreader["CP"].ToString();
                            registro.Ciudad = oreader["CIUDAD"].ToString();
                            registro.NumeroExterior = oreader["NO_EXT"].ToString();
                            registro.NumeroInterior = oreader["NO_INT"].ToString();
                            registro.Municipio = oreader["MUNICIPIO"].ToString();
                            registro.ResponsableID = int.Parse(oreader["RESPONSABLE_ID"].ToString());
                            registro.Telefono = oreader["TELEFONO"].ToString();
                            registro.Linkid = oreader["LINK_ID"].ToString();

                            var sucursalID = oreader["SUCURSAL_ID"];
                            if (sucursalID.ToString().IsInteger())
                            {
                                registro.SucursalID = int.Parse(sucursalID.ToString());
                            }

                            var usuario = oreader["SUCURSAL_USR"];
                            if (!string.IsNullOrEmpty(usuario.ToString()))
                            {
                                registro.SucursalUsuario = oreader["SUCURSAL_USR"].ToString();
                            }

                            var sucursalClave = oreader["SUCURSAL_CVE"];
                            if (!string.IsNullOrEmpty(sucursalClave.ToString()))
                            {
                                registro.SucursalClave = oreader["SUCURSAL_CVE"].ToString();
                            }

                            string nadro = oreader["NADRO_ID"].ToString();
                            if (nadro.IsInteger())
                            {
                                registro.NadroID = int.Parse(nadro);
                            }

                            string pfizer = oreader["PFIZER_ID"].ToString();

                            if (pfizer.IsInteger())
                            {
                                registro.PfizerID = int.Parse(pfizer);
                            }

                            for (int i = 0; i < oreader.FieldCount; i++)//ITACMA
                            {//ITACMA
                                //var Q = oreader.GetName(i);
                                if (oreader.GetName(i) == "TIPO_SUCURSAL")//ITACMA
                                {
                                    registro.TipoSucursal = oreader["TIPO_SUCURSAL"].ToString();//ITACMA
                                }

                            }
                            rows.Add(registro);
                        }
                    }
                    if (null != cnx)
                    {
                        cmd.Connection.Close();
                        // cmd.Connection.Dispose();
                        //OracleConnection.ClearPool(cnx);
                    }

                }



            }
            return rows;
        }

        public static SIFModelo.Sucursal SucursalPorID(int p)
        {
            string sentencia = "SELECT * FROM cat_sucursales WHERE SUCURSALES_ID = :SucursalID";
            List<SIFModelo.Sucursal> rows = new List<SIFModelo.Sucursal>();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {

                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {

                        cmd.Parameters.Add("SucursalID", p);

                        //
                        try
                        {
                            cmd.Connection.Open();
                        }
                        catch
                        {
                            return null;
                        }

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Sucursal registro = new SIFModelo.Sucursal();

                                registro.SucursalesID = int.Parse(oreader["SUCURSALES_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();
                                registro.Calle = oreader["CALLE"].ToString();
                                registro.Colonia = oreader["COLONIA"].ToString();
                                registro.CodigoPostal = oreader["CP"].ToString();
                                registro.Ciudad = oreader["CIUDAD"].ToString();
                                registro.NumeroExterior = oreader["NO_EXT"].ToString();
                                registro.NumeroInterior = oreader["NO_INT"].ToString();
                                registro.Municipio = oreader["MUNICIPIO"].ToString();
                                registro.ResponsableID = int.Parse(oreader["RESPONSABLE_ID"].ToString());
                                registro.Telefono = oreader["TELEFONO"].ToString();

                                var sucursalID = oreader["SUCURSAL_ID"];
                                if (sucursalID.ToString().IsInteger())
                                {
                                    registro.SucursalID = int.Parse(sucursalID.ToString());
                                }

                                var usuario = oreader["SUCURSAL_USR"];
                                if (!string.IsNullOrEmpty(usuario.ToString()))
                                {
                                    registro.SucursalUsuario = oreader["SUCURSAL_USR"].ToString();
                                }

                                var sucursalClave = oreader["SUCURSAL_CVE"];
                                if (!string.IsNullOrEmpty(sucursalClave.ToString()))
                                {
                                    registro.SucursalClave = oreader["SUCURSAL_CVE"].ToString();
                                }

                                string nadro = oreader["NADRO_ID"].ToString();
                                if (nadro.IsInteger())
                                {
                                    registro.NadroID = int.Parse(nadro);
                                }

                                string pfizer = oreader["PFIZER_ID"].ToString();

                                if (pfizer.IsInteger())
                                {
                                    registro.PfizerID = int.Parse(pfizer);
                                }

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
