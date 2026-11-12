using Oracle.DataAccess.Client;
using SIFModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace SIFDatos
{
    public static class Clientes
    {
        /// <summary>
        /// Utiliza el SP_INS_Cliente para agregar un Cliente
        /// </summary>
        /// <param name="modelo">La instancia del Cliente</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.Cliente modelo)
        {
            string sentencia = "SP_INS_CAT_CLIENTES";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nombre", modelo.Nombre);
                    cmd.Parameters.Add("ape_paterno", modelo.ApellidoPaterno);
                    cmd.Parameters.Add("ape_materno", modelo.ApellidoMaterno);
                    cmd.Parameters.Add("tipo", (char)modelo.TipoCliente);
                    cmd.Parameters.Add("tipo_dir", modelo.TipoDireccion.Valor);
                    cmd.Parameters.Add("convenio", (char)modelo.Convenio);
                    cmd.Parameters.Add("fecha_ult_compra", modelo.FechaUltimaCompra);
                    cmd.Parameters.Add("descuento", modelo.Descuento);
                    cmd.Parameters.Add("boletinado", (char)modelo.Boletinado);
                    cmd.Parameters.Add("fecha_alta", modelo.FechaAlta);
                    cmd.Parameters.Add("lote_caducidad", (char)modelo.LoteCaducidad);
                    cmd.Parameters.Add("proveedor", (char)modelo.Proveedor);
                    cmd.Parameters.Add("lab_mayorista", (char)modelo.LaboratorioMayorista);
                    cmd.Parameters.Add("tarjeta_nadro", modelo.ReferenciaBeneficio);
                    cmd.Parameters.Add("subrogacion", (char)modelo.SUBROGACION);
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

        public static bool Elimina(SIFModelo.Cliente modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_Cliente";
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

        public static bool Actualiza(SIFModelo.Cliente modelo)
        {
            string sentencia = "SP_UPD_CAT_CLIENTES";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("eid", modelo.ID);
                    cmd.Parameters.Add("enombre", modelo.Nombre);
                    cmd.Parameters.Add("eape_paterno", modelo.ApellidoPaterno);
                    cmd.Parameters.Add("eape_materno", modelo.ApellidoMaterno);
                    cmd.Parameters.Add("etipo", System.Convert.ToChar(modelo.TipoCliente));
                    cmd.Parameters.Add("etipo_dir", modelo.TipoDireccion.Valor);
                    cmd.Parameters.Add("econvenio", System.Convert.ToChar(modelo.Convenio));
                    cmd.Parameters.Add("efecha_ult_compra", modelo.FechaUltimaCompra);
                    cmd.Parameters.Add("edescuento", modelo.Descuento);
                    cmd.Parameters.Add("eboletinado", System.Convert.ToChar(modelo.Boletinado));
                    cmd.Parameters.Add("efecha_alta", modelo.FechaAlta);
                    cmd.Parameters.Add("efecha_baja", modelo.FechaBaja);
                    cmd.Parameters.Add("elote_caducidad", System.Convert.ToChar(modelo.LoteCaducidad));
                    cmd.Parameters.Add("eproveedor", System.Convert.ToChar(modelo.Proveedor));
                    cmd.Parameters.Add("elab_mayorista", System.Convert.ToChar(modelo.LaboratorioMayorista));
                    cmd.Parameters.Add("etarjeta_nadro", modelo.ReferenciaBeneficio);
                    cmd.Parameters.Add("esubrogacion", System.Convert.ToChar(modelo.SUBROGACION));

                    cmd.Parameters.Add("eactivo", System.Convert.ToChar(modelo.Activo));
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);


                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteScalar();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            return false;
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

        public static List<SIFModelo.Cliente> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.Cliente> rows = new List<SIFModelo.Cliente>();

            string sentencia = "SELECT * FROM cat_clientes WHERE UPPER( NOMBRE ) LIKE '%" + parametro.ToUpper() + "%' OR UPPER(APE_PATERNO) LIKE '%" + parametro.ToUpper() + "%'  OR UPPER(APE_MATERNO) LIKE '%" + parametro.ToUpper() + "%'";

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
                            SIFModelo.Cliente registro = new SIFModelo.Cliente();

                            registro.ID = int.Parse(oreader["CLIENTES_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.ApellidoPaterno = oreader["APE_PATERNO"].ToString();
                            registro.ApellidoMaterno = oreader["APE_MATERNO"].ToString();
                            registro.TipoCliente = (SIFModelo.Tipos.TipoCliente)oreader["TIPO"].ToString()[0];

                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.casa.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.email.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.email;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.fiscal.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                            }

                            registro.Convenio = (SIFModelo.Tipos.SiNo)oreader["CONVENIO"].ToString()[0];
                            if (oreader["FECHA_ULT_COMPRA"].ToString().IsDatetime())
                            {
                                registro.FechaUltimaCompra = System.Convert.ToDateTime(oreader["FECHA_ULT_COMPRA"]);
                            }

                            registro.Descuento = System.Convert.ToDecimal(oreader["DESCUENTO"]);
                            registro.Boletinado = (SIFModelo.Tipos.SiNo)(oreader["BOLETINADO"].ToString()[0]);
                            registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                            if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                            {
                                registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                            }
                            registro.Activo = (SIFModelo.Tipos.SiNo)oreader["ACTIVO"].ToString()[0];
                            registro.LoteCaducidad = (SIFModelo.Tipos.SiNo)oreader["LOTE_CADUCIDAD"].ToString()[0];
                            registro.Proveedor = (SIFModelo.Tipos.SiNo)oreader["PROVEEDOR"].ToString()[0];
                            registro.LaboratorioMayorista = (SIFModelo.Tipos.LaboratorioMayorista)oreader["LAB_MAYORISTA"].ToString()[0];
                            registro.SUBROGACION = (SIFModelo.Tipos.SiNo) oreader["SUBROGACION"].ToString()[0];
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


        public static SIFModelo.DireccionCliente DireccionCliente(SIFModelo.Cliente cliente)
        {
            string sentencia = "SELECT TIPO_DIR, TELEFONO1, TELEFONO,    RFC, NO_INT, NO_EXT,    MUNICIPIO, ENTRECALLES, EMAIL,   LPAD( CP, 5, '0') CP, COLONIA, CLIENTES_ID,    CIUDAD, CALLE FROM DIR_CLIENTES WHERE clientes_id = :clientes_id  AND TIPO_DIR = :tipo_dir";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //PARAMETROS
                        cmd.Parameters.Add("clientes_id", cliente.ID);
                        OracleParameter oracleParameter = cmd.Parameters.Add("tipo_dir", cliente.TipoDireccion.Valor);
                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.DireccionCliente registro = new SIFModelo.DireccionCliente();

                                registro.ID = int.Parse(oreader["CLIENTES_ID"].ToString());

                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.casa.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                                }
                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.email.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.email;
                                }
                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.fiscal.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                                }

                                registro.RFC = oreader["RFC"].ToString();
                                registro.Calle = oreader["CALLE"].ToString();
                                registro.Colonia = oreader["COLONIA"].ToString();
                                registro.CodigoPostal = oreader["CP"].ToString();
                                registro.Ciudad = oreader["CIUDAD"].ToString();
                                registro.NumeroExterior = oreader["NO_EXT"].ToString();
                                registro.NumeroInterior = oreader["NO_INT"].ToString();
                                registro.Municipio = oreader["MUNICIPIO"].ToString();
                                registro.Telefono = oreader["TELEFONO"].ToString();
                                registro.Celular = oreader["TELEFONO1"].ToString();
                                registro.Email = oreader["EMAIL"].ToString();
                                registro.EntreCalles = oreader["ENTRECALLES"].ToString();

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

        public static SIFModelo.DireccionCliente DireccionCliente(SIFModelo.Cliente cliente, SIFModelo.Tipos.TipoDireccion TipoDir)
        {
            string sentencia = "SELECT TIPO_DIR, TELEFONO1, TELEFONO,    RFC, NO_INT, NO_EXT,    MUNICIPIO, ENTRECALLES, EMAIL,   LPAD( CP, 5, '0') CP, COLONIA, CLIENTES_ID,    CIUDAD, CALLE FROM DIR_CLIENTES WHERE clientes_id = :clientes_id AND TIPO_DIR = :TipoDir";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //PARAMETROS
                        cmd.Parameters.Add("clientes_id", cliente.ID);
                        cmd.Parameters.Add("TipoDir", TipoDir.Valor);
                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.DireccionCliente registro = new SIFModelo.DireccionCliente();

                                registro.ID = int.Parse(oreader["CLIENTES_ID"].ToString());

                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.casa.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                                }
                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.email.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.email;
                                }
                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.fiscal.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                                }

                                registro.RFC = oreader["RFC"].ToString();
                                registro.Calle = oreader["CALLE"].ToString();
                                registro.Colonia = oreader["COLONIA"].ToString();
                                registro.CodigoPostal = oreader["CP"].ToString();
                                registro.Ciudad = oreader["CIUDAD"].ToString();
                                registro.NumeroExterior = oreader["NO_EXT"].ToString();
                                registro.NumeroInterior = oreader["NO_INT"].ToString();
                                registro.Municipio = oreader["MUNICIPIO"].ToString();
                                registro.Telefono = oreader["TELEFONO"].ToString();
                                registro.Celular = oreader["TELEFONO1"].ToString();
                                registro.Email = oreader["EMAIL"].ToString();
                                registro.EntreCalles = oreader["ENTRECALLES"].ToString();

                                return registro;
                            }
                        }
                    }
                }
                catch   {           }
                finally 
                {
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

        public static bool InsertaDireccion(SIFModelo.DireccionCliente modelo)
        {
            string sentencia = "sp_ins_dir_clientes";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("clientes_id", modelo.ClienteID);
                    cmd.Parameters.Add("tipo_dir", modelo.TipoDireccion.Valor);
                    cmd.Parameters.Add("rfc", modelo.RFC);
                    cmd.Parameters.Add("calle", modelo.Calle);
                    cmd.Parameters.Add("colonia", modelo.Colonia);
                    cmd.Parameters.Add("cp", modelo.CodigoPostal);
                    cmd.Parameters.Add("ciudad", modelo.Ciudad);
                    cmd.Parameters.Add("no_ext", modelo.NumeroExterior);
                    cmd.Parameters.Add("no_int", modelo.NumeroInterior);
                    cmd.Parameters.Add("municipio", modelo.Municipio);
                    cmd.Parameters.Add("telefono", modelo.Telefono);
                    cmd.Parameters.Add("telefono1", modelo.Celular);
                    cmd.Parameters.Add("email", modelo.Email);
                    cmd.Parameters.Add("entrecalles", modelo.EntreCalles);

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

        public static bool ActualizaDireccion(SIFModelo.DireccionCliente modelo)
        {
            string sentencia = "sp_upd_dir_clientes";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("eclientes_id", modelo.ClienteID);
                    cmd.Parameters.Add("etipo_dir", modelo.TipoDireccion.Valor);
                    cmd.Parameters.Add("erfc", modelo.RFC);
                    cmd.Parameters.Add("ecalle", modelo.Calle);
                    cmd.Parameters.Add("ecolonia", modelo.Colonia);
                    cmd.Parameters.Add("ecp", modelo.CodigoPostal);
                    cmd.Parameters.Add("eciudad", modelo.Ciudad);
                    cmd.Parameters.Add("eno_ext", modelo.NumeroExterior);
                    cmd.Parameters.Add("eno_int", modelo.NumeroInterior);
                    cmd.Parameters.Add("emunicipio", modelo.Municipio);
                    cmd.Parameters.Add("etelefono", modelo.Telefono);
                    cmd.Parameters.Add("etelefono1", modelo.Celular);
                    cmd.Parameters.Add("eemail", modelo.Email);
                    cmd.Parameters.Add("eentrecalles", modelo.EntreCalles);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteScalar();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            return false;
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

        public static SIFModelo.Cliente ClientePorID(int clienteID)
        {
            string sentencia = "SELECT * FROM cat_clientes WHERE clientes_id = :clientes_id ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //PARAMETROS
                        cmd.Parameters.Add("clientes_id", clienteID);

                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Cliente registro = new SIFModelo.Cliente();

                                registro.ID = int.Parse(oreader["CLIENTES_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();
                                registro.ApellidoPaterno = oreader["APE_PATERNO"].ToString();
                                registro.ApellidoMaterno = oreader["APE_MATERNO"].ToString();
                                registro.TipoCliente = (SIFModelo.Tipos.TipoCliente)oreader["TIPO"].ToString()[0];

                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.casa.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                                }
                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.email.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.email;
                                }
                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.fiscal.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                                }

                                registro.Convenio = (SIFModelo.Tipos.SiNo)oreader["CONVENIO"].ToString()[0];
                                if (oreader["FECHA_ULT_COMPRA"].ToString().IsDatetime())
                                {
                                    registro.FechaUltimaCompra = System.Convert.ToDateTime(oreader["FECHA_ULT_COMPRA"]);
                                }

                                registro.Descuento = System.Convert.ToDecimal(oreader["DESCUENTO"]);
                                registro.Boletinado = (SIFModelo.Tipos.SiNo)(oreader["BOLETINADO"].ToString()[0]);
                                registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                                if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                                {
                                    registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                                }
                                registro.Activo = (SIFModelo.Tipos.SiNo)oreader["ACTIVO"].ToString()[0];
                                registro.LoteCaducidad = (SIFModelo.Tipos.SiNo)oreader["LOTE_CADUCIDAD"].ToString()[0];
                                registro.Proveedor = (SIFModelo.Tipos.SiNo)oreader["PROVEEDOR"].ToString()[0];
                                registro.SUBROGACION = (SIFModelo.Tipos.SiNo)oreader["SUBROGACION"].ToString()[0];
                                registro.Convenio = (SIFModelo.Tipos.SiNo)oreader["CONVENIO"].ToString()[0];
                                registro.LaboratorioMayorista = (SIFModelo.Tipos.LaboratorioMayorista)oreader["LAB_MAYORISTA"].ToString()[0];

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

        public static List<SIFModelo.Cliente> BuscaProveedores(string propiedad, string parametro)
        {
            List<SIFModelo.Cliente> rows = new List<SIFModelo.Cliente>();

            string sentencia = "SELECT * FROM cat_clientes WHERE ACTIVO LIKE 'S' ";

            if (propiedad == "PROVEEDOR")
            {
                sentencia += " AND  proveedor = 'S'";
            }
            if (propiedad == "LAB_MAYORISTA")
            {
                sentencia += " AND  LAB_MAYORISTA <> 'N'";
            }

            sentencia += " AND  (UPPER( CONCAT(CONCAT(nombre,ape_paterno ) ,APE_MATERNO )) LIKE UPPER('%" + parametro + "%') OR CLIENTES_ID LIKE  '%" + parametro + "%' )" ;

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
                            SIFModelo.Cliente registro = new SIFModelo.Cliente();

                            registro.ID = int.Parse(oreader["CLIENTES_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.ApellidoPaterno = oreader["APE_PATERNO"].ToString();
                            registro.ApellidoMaterno = oreader["APE_MATERNO"].ToString();
                            registro.TipoCliente = (SIFModelo.Tipos.TipoCliente)oreader["TIPO"].ToString()[0];

                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.casa.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.email.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.email;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.fiscal.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                            }

                            registro.Convenio = (SIFModelo.Tipos.SiNo)oreader["CONVENIO"].ToString()[0];
                            if (oreader["FECHA_ULT_COMPRA"].ToString().IsDatetime())
                            {
                                registro.FechaUltimaCompra = System.Convert.ToDateTime(oreader["FECHA_ULT_COMPRA"]);
                            }

                            registro.Descuento = System.Convert.ToDecimal(oreader["DESCUENTO"]);
                            registro.Boletinado = (SIFModelo.Tipos.SiNo)(oreader["BOLETINADO"].ToString()[0]);
                            registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                            if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                            {
                                registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                            }
                            registro.Activo = (SIFModelo.Tipos.SiNo)oreader["ACTIVO"].ToString()[0];
                            registro.LoteCaducidad = (SIFModelo.Tipos.SiNo)oreader["LOTE_CADUCIDAD"].ToString()[0];
                            registro.Proveedor = (SIFModelo.Tipos.SiNo)oreader["PROVEEDOR"].ToString()[0];
                            registro.LaboratorioMayorista = (SIFModelo.Tipos.LaboratorioMayorista)oreader["LAB_MAYORISTA"].ToString()[0];
                            registro.SUBROGACION = (SIFModelo.Tipos.SiNo)oreader["SUBROGACION"].ToString()[0];
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
















        public static List<SIFModelo.Cliente> BuscaClientes(string propiedad, string parametro)
        {
            List<SIFModelo.Cliente> rows = new List<SIFModelo.Cliente>();
            // checamos si el parametro tiene mas de una palabra y lo separamos en token

            //string sentencia="";
            //if (parametro.IndexOf(' ') > 0)
            //{
            //string[] Nombre = parametro.Split(' ');
            //if (Nombre.Length == 2)
            //{
            //    sentencia = "SELECT * FROM cat_clientes WHERE  NOMBRE LIKE '%" + Nombre[0] + "%' OR APE_PATERNO LIKE '%" + Nombre[0] + "%'  OR APE_MATERNO LIKE '%" + Nombre[0] + "%' OR "+
            //                                                  "NOMBRE LIKE '%" + Nombre[1] + "%' OR APE_PATERNO LIKE '%" + Nombre[1] + "%'  OR APE_MATERNO LIKE '%" + Nombre[1] + "%'" ;
            //}
            //else
            //    if (Nombre.Length == 3)
            //    sentencia = "SELECT * FROM cat_clientes WHERE  NOMBRE LIKE '%" + Nombre[0] + "%' OR APE_PATERNO LIKE '%" + Nombre[0] + "%'  OR APE_MATERNO LIKE '%" + Nombre[0] + "%' OR " +
            //                                                  "NOMBRE LIKE '%" + Nombre[1] + "%' OR APE_PATERNO LIKE '%" + Nombre[1] + "%'  OR APE_MATERNO LIKE '%" + Nombre[1] + "%' OR "+
            //                                                  "NOMBRE LIKE '%" + Nombre[2] + "%' OR APE_PATERNO LIKE '%" + Nombre[2] + "%'  OR APE_MATERNO LIKE '%" + Nombre[2] + "%'";
            //    else
            //        sentencia = "SELECT * FROM cat_clientes WHERE  NOMBRE LIKE '%" + parametro + "%' OR APE_PATERNO LIKE '%" + parametro + "%'  OR APE_MATERNO LIKE '%" + parametro + "%'";
            //}
            //else
            //sentencia = "SELECT * FROM cat_clientes WHERE  NOMBRE LIKE '%" + parametro + "%' OR APE_PATERNO LIKE '%" + parametro + "%'  OR APE_MATERNO LIKE '%" + parametro + "%'";
            string sentencia = "SELECT * FROM cat_clientes WHERE UPPER( NOMBRE || ' ' || APE_PATERNO || ' ' ||  APE_MATERNO ) LIKE '%" + parametro.ToUpper() + "%' OR TO_CHAR(CLIENTES_ID) = '" + parametro +"'";

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
                            SIFModelo.Cliente registro = new SIFModelo.Cliente();

                            registro.ID = int.Parse(oreader["CLIENTES_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.ApellidoPaterno = oreader["APE_PATERNO"].ToString();
                            registro.ApellidoMaterno = oreader["APE_MATERNO"].ToString();
                            registro.TipoCliente = (SIFModelo.Tipos.TipoCliente)oreader["TIPO"].ToString()[0];

                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.casa.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.email.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.email;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.fiscal.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                            }

                            registro.Convenio = (SIFModelo.Tipos.SiNo)oreader["CONVENIO"].ToString()[0];
                            if (oreader["FECHA_ULT_COMPRA"].ToString().IsDatetime())
                            {
                                registro.FechaUltimaCompra = System.Convert.ToDateTime(oreader["FECHA_ULT_COMPRA"]);
                            }

                            registro.Descuento = System.Convert.ToDecimal(oreader["DESCUENTO"]);
                            registro.Boletinado = (SIFModelo.Tipos.SiNo)(oreader["BOLETINADO"].ToString()[0]);
                            registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                            if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                            {
                                registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                            }
                            registro.Activo = (SIFModelo.Tipos.SiNo)oreader["ACTIVO"].ToString()[0];
                            registro.LoteCaducidad = (SIFModelo.Tipos.SiNo)oreader["LOTE_CADUCIDAD"].ToString()[0];
                            registro.Proveedor = (SIFModelo.Tipos.SiNo)oreader["PROVEEDOR"].ToString()[0];
                            registro.LaboratorioMayorista = (SIFModelo.Tipos.LaboratorioMayorista)oreader["LAB_MAYORISTA"].ToString()[0];
                            registro.SUBROGACION = (SIFModelo.Tipos.SiNo)oreader["SUBROGACION"].ToString()[0];
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



        public static List<SIFModelo.Cliente> BuscaClientesS(string propiedad, string parametro)
        {
            List<SIFModelo.Cliente> rows = new List<SIFModelo.Cliente>();

            string sentencia = "";
            if (parametro.IndexOf(' ') > 0)
            {
                string[] Nombre = parametro.Split(' ');
                if (Nombre.Length == 2)
                {
                    sentencia = "SELECT * FROM cat_clientes WHERE  subrogacion='S' and (UPPER(NOMBRE) LIKE '%" + Nombre[0].ToUpper() + "%' OR APE_PATERNO LIKE '%" + Nombre[0].ToUpper() + "%'  OR APE_MATERNO LIKE '%" + Nombre[0].ToUpper() + "%' OR " +
                                                                  "NOMBRE LIKE '%" + Nombre[1].ToUpper() + "%' OR APE_PATERNO LIKE '%" + Nombre[1].ToUpper() + "%'  OR APE_MATERNO LIKE '%" + Nombre[1].ToUpper() + "%')";
                }
                else
                    if (Nombre.Length == 3)
                        sentencia = "SELECT * FROM cat_clientes WHERE subrogacion='S' and ( UPPER(NOMBRE) LIKE '%" + Nombre[0].ToUpper() + "%' OR APE_PATERNO LIKE '%" + Nombre[0].ToUpper() + "%'  OR APE_MATERNO LIKE '%" + Nombre[0].ToUpper() + "%' OR " +
                                                                  "NOMBRE LIKE '%" + Nombre[1].ToUpper() + "%' OR APE_PATERNO LIKE '%" + Nombre[1].ToUpper() + "%'  OR APE_MATERNO LIKE '%" + Nombre[1].ToUpper() + "%')";
                    else
                        sentencia = "SELECT * FROM cat_clientes WHERE subrogacion='S' and (NOMBRE LIKE '%" + parametro.ToUpper() + "%' OR APE_PATERNO LIKE '%" + parametro.ToUpper() + "%'  OR APE_MATERNO LIKE '%" + parametro.ToUpper() + "%')";
            }
            else
                sentencia = "SELECT * FROM cat_clientes WHERE subrogacion='S' and ( NOMBRE LIKE '%" + parametro.ToUpper() + "%' OR APE_PATERNO LIKE '%" + parametro.ToUpper() + "%'  OR APE_MATERNO LIKE '%" + parametro.ToUpper() + "%')";



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
                            SIFModelo.Cliente registro = new SIFModelo.Cliente();

                            registro.ID = int.Parse(oreader["CLIENTES_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.ApellidoPaterno = oreader["APE_PATERNO"].ToString();
                            registro.ApellidoMaterno = oreader["APE_MATERNO"].ToString();
                            registro.TipoCliente = (SIFModelo.Tipos.TipoCliente)oreader["TIPO"].ToString()[0];

                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.casa.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.email.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.email;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.fiscal.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                            }

                            registro.Convenio = (SIFModelo.Tipos.SiNo)oreader["CONVENIO"].ToString()[0];
                            if (oreader["FECHA_ULT_COMPRA"].ToString().IsDatetime())
                            {
                                registro.FechaUltimaCompra = System.Convert.ToDateTime(oreader["FECHA_ULT_COMPRA"]);
                            }

                            registro.Descuento = System.Convert.ToDecimal(oreader["DESCUENTO"]);
                            registro.Boletinado = (SIFModelo.Tipos.SiNo)(oreader["BOLETINADO"].ToString()[0]);
                            registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                            if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                            {
                                registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                            }
                            registro.Activo = (SIFModelo.Tipos.SiNo)oreader["ACTIVO"].ToString()[0];
                            registro.LoteCaducidad = (SIFModelo.Tipos.SiNo)oreader["LOTE_CADUCIDAD"].ToString()[0];
                            registro.Proveedor = (SIFModelo.Tipos.SiNo)oreader["PROVEEDOR"].ToString()[0];
                            registro.LaboratorioMayorista = (SIFModelo.Tipos.LaboratorioMayorista)oreader["LAB_MAYORISTA"].ToString()[0];
                            registro.SUBROGACION = (SIFModelo.Tipos.SiNo)oreader["SUBROGACION"].ToString()[0];
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


        public static List<SIFModelo.Cliente> BuscaClientesSub(string propiedad, string parametro)
        {
            List<SIFModelo.Cliente> rows = new List<SIFModelo.Cliente>();

            string sentencia = "";
            if (parametro.IndexOf(' ') > 0)
            {
                string[] Nombre = parametro.Split(' ');
                if (Nombre.Length == 2)
                {
                    sentencia = "SELECT * FROM cat_clientes WHERE  (subrogacion='S' or convenio='S') and (UPPER(NOMBRE) LIKE '%" + Nombre[0].ToUpper() + "%' OR APE_PATERNO LIKE '%" + Nombre[0].ToUpper() + "%'  OR APE_MATERNO LIKE '%" + Nombre[0].ToUpper() + "%' OR " +
                                                                  "NOMBRE LIKE '%" + Nombre[1].ToUpper() + "%' OR APE_PATERNO LIKE '%" + Nombre[1].ToUpper() + "%'  OR APE_MATERNO LIKE '%" + Nombre[1].ToUpper() + "%' OR CLIENTES_ID LIKE '%" + Nombre[0].ToUpper() + "%' )";
                }
                else
                    if (Nombre.Length == 3)
                        sentencia = "SELECT * FROM cat_clientes WHERE (subrogacion='S' or convenio='S') and ( UPPER(NOMBRE) LIKE '%" + Nombre[0].ToUpper() + "%' OR APE_PATERNO LIKE '%" + Nombre[0].ToUpper() + "%'  OR APE_MATERNO LIKE '%" + Nombre[0].ToUpper() + "%' OR " +
                                                                  "NOMBRE LIKE '%" + Nombre[1].ToUpper() + "%' OR APE_PATERNO LIKE '%" + Nombre[1].ToUpper() + "%'  OR APE_MATERNO LIKE '%" + Nombre[1].ToUpper() + "%'  OR CLIENTES_ID LIKE '%" + Nombre[0].ToUpper() + "%'  )";
                    else
                        sentencia = "SELECT * FROM cat_clientes WHERE (subrogacion='S' or convenio='S') and (NOMBRE LIKE '%" + parametro.ToUpper() + "%' OR APE_PATERNO LIKE '%" + parametro.ToUpper() + "%'  OR APE_MATERNO LIKE '%" + parametro.ToUpper() + "%'  OR CLIENTES_ID LIKE '%" + parametro + "%' )";
            }
            else
                sentencia = "SELECT * FROM cat_clientes WHERE (subrogacion='S' or convenio='S') and ( NOMBRE LIKE '%" + parametro.ToUpper() + "%' OR APE_PATERNO LIKE '%" + parametro.ToUpper() + "%'  OR APE_MATERNO LIKE '%" + parametro.ToUpper() + "%'  OR CLIENTES_ID LIKE '%" + parametro + "%' )";



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
                            SIFModelo.Cliente registro = new SIFModelo.Cliente();

                            registro.ID = int.Parse(oreader["CLIENTES_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.ApellidoPaterno = oreader["APE_PATERNO"].ToString();
                            registro.ApellidoMaterno = oreader["APE_MATERNO"].ToString();
                            registro.TipoCliente = (SIFModelo.Tipos.TipoCliente)oreader["TIPO"].ToString()[0];

                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.casa.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.email.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.email;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.fiscal.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                            }

                            registro.Convenio = (SIFModelo.Tipos.SiNo)oreader["CONVENIO"].ToString()[0];
                            if (oreader["FECHA_ULT_COMPRA"].ToString().IsDatetime())
                            {
                                registro.FechaUltimaCompra = System.Convert.ToDateTime(oreader["FECHA_ULT_COMPRA"]);
                            }

                            registro.Descuento = System.Convert.ToDecimal(oreader["DESCUENTO"]);
                            registro.Boletinado = (SIFModelo.Tipos.SiNo)(oreader["BOLETINADO"].ToString()[0]);
                            registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                            if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                            {
                                registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                            }
                            registro.Activo = (SIFModelo.Tipos.SiNo)oreader["ACTIVO"].ToString()[0];
                            registro.LoteCaducidad = (SIFModelo.Tipos.SiNo)oreader["LOTE_CADUCIDAD"].ToString()[0];
                            registro.Proveedor = (SIFModelo.Tipos.SiNo)oreader["PROVEEDOR"].ToString()[0];
                            registro.LaboratorioMayorista = (SIFModelo.Tipos.LaboratorioMayorista)oreader["LAB_MAYORISTA"].ToString()[0];
                            registro.SUBROGACION = (SIFModelo.Tipos.SiNo)oreader["SUBROGACION"].ToString()[0];
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
        public static List<SIFModelo.Cliente> BuscaClientesC(string propiedad, string parametro,String Tipo,int CUAL)
        {
            List<SIFModelo.Cliente> rows = new List<SIFModelo.Cliente>();

            string sentencia = "";
            if (parametro.IndexOf(' ') > 0)
            {
                string[] Nombre = parametro.Split(' ');
                if (Nombre.Length == 2)
                {
                    sentencia = "SELECT * FROM cat_clientes WHERE  "+ Tipo +"='S' and (UPPER(NOMBRE) LIKE '%" + Nombre[0].ToUpper() + "%' OR APE_PATERNO LIKE '%" + Nombre[0].ToUpper() + "%'  OR APE_MATERNO LIKE '%" + Nombre[0].ToUpper() + "%' OR " +
                                                                  "NOMBRE LIKE '%" + Nombre[1].ToUpper() + "%' OR APE_PATERNO LIKE '%" + Nombre[1].ToUpper() + "%'  OR APE_MATERNO LIKE '%" + Nombre[1].ToUpper() + "%')";
                }
                else
                    if (Nombre.Length == 3)
                        sentencia = "SELECT * FROM cat_clientes WHERE " + Tipo + "='S' and ( UPPER(NOMBRE) LIKE '%" + Nombre[0].ToUpper() + "%' OR APE_PATERNO LIKE '%" + Nombre[0].ToUpper() + "%'  OR APE_MATERNO LIKE '%" + Nombre[0].ToUpper() + "%' OR " +
                                                                  "NOMBRE LIKE '%" + Nombre[1].ToUpper() + "%' OR APE_PATERNO LIKE '%" + Nombre[1].ToUpper() + "%'  OR APE_MATERNO LIKE '%" + Nombre[1].ToUpper() + "%')";
                    else
                        sentencia = "SELECT * FROM cat_clientes WHERE " + Tipo + "='S' and (NOMBRE LIKE '%" + parametro.ToUpper() + "%' OR APE_PATERNO LIKE '%" + parametro.ToUpper() + "%'  OR APE_MATERNO LIKE '%" + parametro.ToUpper() + "%')";
            }
            else
                sentencia = "SELECT * FROM cat_clientes WHERE " + Tipo + "='S' and ( NOMBRE LIKE '%" + parametro.ToUpper() + "%' OR APE_PATERNO LIKE '%" + parametro.ToUpper() + "%'  OR APE_MATERNO LIKE '%" + parametro.ToUpper() + "%')";



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
                            SIFModelo.Cliente registro = new SIFModelo.Cliente();

                            registro.ID = int.Parse(oreader["CLIENTES_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.ApellidoPaterno = oreader["APE_PATERNO"].ToString();
                            registro.ApellidoMaterno = oreader["APE_MATERNO"].ToString();
                            registro.TipoCliente = (SIFModelo.Tipos.TipoCliente)oreader["TIPO"].ToString()[0];

                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.casa.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.email.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.email;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.fiscal.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                            }

                            registro.Convenio = (SIFModelo.Tipos.SiNo)oreader["CONVENIO"].ToString()[0];
                            if (oreader["FECHA_ULT_COMPRA"].ToString().IsDatetime())
                            {
                                registro.FechaUltimaCompra = System.Convert.ToDateTime(oreader["FECHA_ULT_COMPRA"]);
                            }

                            registro.Descuento = System.Convert.ToDecimal(oreader["DESCUENTO"]);
                            registro.Boletinado = (SIFModelo.Tipos.SiNo)(oreader["BOLETINADO"].ToString()[0]);
                            registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                            if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                            {
                                registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                            }
                            registro.Activo = (SIFModelo.Tipos.SiNo)oreader["ACTIVO"].ToString()[0];
                            registro.LoteCaducidad = (SIFModelo.Tipos.SiNo)oreader["LOTE_CADUCIDAD"].ToString()[0];
                            registro.Proveedor = (SIFModelo.Tipos.SiNo)oreader["PROVEEDOR"].ToString()[0];
                            registro.LaboratorioMayorista = (SIFModelo.Tipos.LaboratorioMayorista)oreader["LAB_MAYORISTA"].ToString()[0];
                            registro.SUBROGACION = (SIFModelo.Tipos.SiNo)oreader["SUBROGACION"].ToString()[0];
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

        public static List<SIFModelo.Cliente> BuscaClientesC(string propiedad, string parametro, string listaProveedores)
        {
            List<SIFModelo.Cliente> rows = new List<SIFModelo.Cliente>();

            string[] ids = listaProveedores.Split('|');

            string lista = "";

            foreach (string s in ids)
            {
                lista += s + ",";
            }

            lista = lista.Trim(',');

            if (string.IsNullOrEmpty(lista))
            {
                lista = "0";
            }

            string sentencia = "SELECT * FROM cat_clientes WHERE (NOMBRE || ' ' || APE_PATERNO || ' ' || APE_MATERNO LIKE '%" + parametro.ToUpper() + "%' OR CLIENTES_ID LIKE '" + parametro + "' ) AND CLIENTES_ID IN (" + lista + ")";

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
                            SIFModelo.Cliente registro = new SIFModelo.Cliente();

                            registro.ID = int.Parse(oreader["CLIENTES_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.ApellidoPaterno = oreader["APE_PATERNO"].ToString();
                            registro.ApellidoMaterno = oreader["APE_MATERNO"].ToString();
                            registro.TipoCliente = (SIFModelo.Tipos.TipoCliente)oreader["TIPO"].ToString()[0];

                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.casa.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.email.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.email;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.fiscal.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                            }

                            registro.Convenio = (SIFModelo.Tipos.SiNo)oreader["CONVENIO"].ToString()[0];
                            if (oreader["FECHA_ULT_COMPRA"].ToString().IsDatetime())
                            {
                                registro.FechaUltimaCompra = System.Convert.ToDateTime(oreader["FECHA_ULT_COMPRA"]);
                            }

                            registro.Descuento = System.Convert.ToDecimal(oreader["DESCUENTO"]);
                            registro.Boletinado = (SIFModelo.Tipos.SiNo)(oreader["BOLETINADO"].ToString()[0]);
                            registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                            if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                            {
                                registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                            }
                            registro.Activo = (SIFModelo.Tipos.SiNo)oreader["ACTIVO"].ToString()[0];
                            registro.LoteCaducidad = (SIFModelo.Tipos.SiNo)oreader["LOTE_CADUCIDAD"].ToString()[0];
                            registro.Proveedor = (SIFModelo.Tipos.SiNo)oreader["PROVEEDOR"].ToString()[0];
                            registro.LaboratorioMayorista = (SIFModelo.Tipos.LaboratorioMayorista)oreader["LAB_MAYORISTA"].ToString()[0];
                            registro.SUBROGACION = (SIFModelo.Tipos.SiNo)oreader["SUBROGACION"].ToString()[0];
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

        public static List<SIFModelo.Cliente> BuscaLaboratorios(string parametros)
        {
            List<SIFModelo.Cliente> rows = new List<SIFModelo.Cliente>();

            string sentencia = "SELECT * FROM cat_clientes " +
            " WHERE  (LAB_MAYORISTA = 'L' OR LAB_MAYORISTA = 'M') " + // AND PROVEEDOR NOT LIKE 'S' " +
            " ORDER BY clientes_id ";
            // " AND ACTIVO = 'S'";

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
                            SIFModelo.Cliente registro = new SIFModelo.Cliente();

                            registro.ID = int.Parse(oreader["CLIENTES_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.ApellidoPaterno = oreader["APE_PATERNO"].ToString();
                            registro.ApellidoMaterno = oreader["APE_MATERNO"].ToString();
                            registro.TipoCliente = (SIFModelo.Tipos.TipoCliente)oreader["TIPO"].ToString()[0];

                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.casa.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.email.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.email;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.fiscal.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                            }

                            registro.Convenio = (SIFModelo.Tipos.SiNo)oreader["CONVENIO"].ToString()[0];
                            if (oreader["FECHA_ULT_COMPRA"].ToString().IsDatetime())
                            {
                                registro.FechaUltimaCompra = System.Convert.ToDateTime(oreader["FECHA_ULT_COMPRA"]);
                            }

                            registro.Descuento = System.Convert.ToDecimal(oreader["DESCUENTO"]);
                            registro.Boletinado = (SIFModelo.Tipos.SiNo)(oreader["BOLETINADO"].ToString()[0]);
                            registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                            if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                            {
                                registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                            }
                            registro.Activo = (SIFModelo.Tipos.SiNo)oreader["ACTIVO"].ToString()[0];
                            registro.LoteCaducidad = (SIFModelo.Tipos.SiNo)oreader["LOTE_CADUCIDAD"].ToString()[0];
                            registro.Proveedor = (SIFModelo.Tipos.SiNo)oreader["PROVEEDOR"].ToString()[0];
                            registro.LaboratorioMayorista = (SIFModelo.Tipos.LaboratorioMayorista)oreader["LAB_MAYORISTA"].ToString()[0];
                            registro.SUBROGACION = (SIFModelo.Tipos.SiNo)oreader["SUBROGACION"].ToString()[0];
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


        public static List<SIFModelo.Cliente> BuscarProveedoresMayoristas(string propiedad, string parametro, bool esCompleto = true)
        {
            List<SIFModelo.Cliente> rows = new List<SIFModelo.Cliente>();

            string sentencia = "SELECT * FROM cat_clientes INNER JOIN  CAT_PROVEEDOR " +
" ON CAT_CLIENTES.CLIENTES_ID = CAT_PROVEEDOR.CLIENTES_ID ";
            if (!esCompleto)
            {
                sentencia += " WHERE  CAT_CLIENTES.clientes_id IN (99064,99035,99012,99169)";
            }
          sentencia += " ORDER BY CAT_CLIENTES.clientes_id ";
           // " AND ACTIVO = 'S'";

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
                            SIFModelo.Cliente registro = new SIFModelo.Cliente();

                            registro.ID = int.Parse(oreader["CLIENTES_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.ApellidoPaterno = oreader["APE_PATERNO"].ToString();
                            registro.ApellidoMaterno = oreader["APE_MATERNO"].ToString();
                            registro.TipoCliente = (SIFModelo.Tipos.TipoCliente)oreader["TIPO"].ToString()[0];

                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.casa.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.email.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.email;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.fiscal.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                            }

                            registro.Convenio = (SIFModelo.Tipos.SiNo)oreader["CONVENIO"].ToString()[0];
                            if (oreader["FECHA_ULT_COMPRA"].ToString().IsDatetime())
                            {
                                registro.FechaUltimaCompra = System.Convert.ToDateTime(oreader["FECHA_ULT_COMPRA"]);
                            }

                            registro.Descuento = System.Convert.ToDecimal(oreader["DESCUENTO"]);
                            registro.Boletinado = (SIFModelo.Tipos.SiNo)(oreader["BOLETINADO"].ToString()[0]);
                            registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                            if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                            {
                                registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                            }
                            registro.Activo = (SIFModelo.Tipos.SiNo)oreader["ACTIVO"].ToString()[0];
                            registro.LoteCaducidad = (SIFModelo.Tipos.SiNo)oreader["LOTE_CADUCIDAD"].ToString()[0];
                            registro.Proveedor = (SIFModelo.Tipos.SiNo)oreader["PROVEEDOR"].ToString()[0];
                            registro.LaboratorioMayorista = (SIFModelo.Tipos.LaboratorioMayorista)oreader["LAB_MAYORISTA"].ToString()[0];
                            registro.SUBROGACION = (SIFModelo.Tipos.SiNo)oreader["SUBROGACION"].ToString()[0];
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

        public static List<SIFModelo.Cliente> BuscarProveedoresMayoristasVendedor(string propiedad, string parametro, SIFModelo.Usuario usuario)
        {
            List<SIFModelo.Cliente> rows = new List<SIFModelo.Cliente>();

            string sentencia = "select * from cat_clientes a, cat_compradores b where regexp_like(b.LISTA_PROVEEDOR_ID,a.clientes_id )and b.usuario_id='"+usuario.UsuariosID+"'  ";
            
         // sentencia += " ORDER BY CAT_CLIENTES.clientes_id ";
           // " AND ACTIVO = 'S'";

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
                            SIFModelo.Cliente registro = new SIFModelo.Cliente();

                            registro.ID = int.Parse(oreader["CLIENTES_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.ApellidoPaterno = oreader["APE_PATERNO"].ToString();
                            registro.ApellidoMaterno = oreader["APE_MATERNO"].ToString();
                            registro.TipoCliente = (SIFModelo.Tipos.TipoCliente)oreader["TIPO"].ToString()[0];

                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.casa.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.email.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.email;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.fiscal.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                            }

                            registro.Convenio = (SIFModelo.Tipos.SiNo)oreader["CONVENIO"].ToString()[0];
                            if (oreader["FECHA_ULT_COMPRA"].ToString().IsDatetime())
                            {
                                registro.FechaUltimaCompra = System.Convert.ToDateTime(oreader["FECHA_ULT_COMPRA"]);
                            }

                            registro.Descuento = System.Convert.ToDecimal(oreader["DESCUENTO"]);
                            registro.Boletinado = (SIFModelo.Tipos.SiNo)(oreader["BOLETINADO"].ToString()[0]);
                            registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                            if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                            {
                                registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                            }
                            registro.Activo = (SIFModelo.Tipos.SiNo)oreader["ACTIVO"].ToString()[0];
                            registro.LoteCaducidad = (SIFModelo.Tipos.SiNo)oreader["LOTE_CADUCIDAD"].ToString()[0];
                            registro.Proveedor = (SIFModelo.Tipos.SiNo)oreader["PROVEEDOR"].ToString()[0];
                            registro.LaboratorioMayorista = (SIFModelo.Tipos.LaboratorioMayorista)oreader["LAB_MAYORISTA"].ToString()[0];
                            registro.SUBROGACION = (SIFModelo.Tipos.SiNo)oreader["SUBROGACION"].ToString()[0];
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


        public static List<SIFModelo.Cliente> BuscaclientesMayorista(string parametros)//JOMAQC     26/09/2018
        {
            List<SIFModelo.Cliente> rows = new List<SIFModelo.Cliente>();

            string sentencia = "SELECT * FROM CS_CAT_CLIENTES_MAYORISTA ";
            

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
                            SIFModelo.Cliente registro = new SIFModelo.Cliente();

                            registro.ID = int.Parse(oreader["CLIENTES_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.ApellidoPaterno = oreader["APE_PATERNO"].ToString();
                            registro.ApellidoMaterno = oreader["APE_MATERNO"].ToString();
                            registro.TipoCliente = (SIFModelo.Tipos.TipoCliente)oreader["TIPO"].ToString()[0];

                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.casa.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.email.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.email;
                            }
                            if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoDireccion.fiscal.Valor)
                            {
                                registro.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
                            }

                            registro.Convenio = (SIFModelo.Tipos.SiNo)oreader["CONVENIO"].ToString()[0];
                            if (oreader["FECHA_ULT_COMPRA"].ToString().IsDatetime())
                            {
                                registro.FechaUltimaCompra = System.Convert.ToDateTime(oreader["FECHA_ULT_COMPRA"]);
                            }

                            registro.Descuento = System.Convert.ToDecimal(oreader["DESCUENTO"]);
                            registro.Boletinado = (SIFModelo.Tipos.SiNo)(oreader["BOLETINADO"].ToString()[0]);
                            registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);
                            if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                            {
                                registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                            }
                            registro.Activo = (SIFModelo.Tipos.SiNo)oreader["ACTIVO"].ToString()[0];
                            registro.LoteCaducidad = (SIFModelo.Tipos.SiNo)oreader["LOTE_CADUCIDAD"].ToString()[0];
                            registro.Proveedor = (SIFModelo.Tipos.SiNo)oreader["PROVEEDOR"].ToString()[0];
                            registro.LaboratorioMayorista = (SIFModelo.Tipos.LaboratorioMayorista)oreader["LAB_MAYORISTA"].ToString()[0];
                            registro.SUBROGACION = (SIFModelo.Tipos.SiNo)oreader["SUBROGACION"].ToString()[0];
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

        public static List<SIFModelo.Cliente> BuscaClientesLista(string parametros)
        {
            List<SIFModelo.Cliente> rows = new List<SIFModelo.Cliente>();

            string sentencia = "select clientes_id, nombre from cat_clientes where subrogacion='S' and convenio='S'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Cliente registro = new SIFModelo.Cliente();

                            registro.ID = int.Parse(oreader["CLIENTES_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();                            
                            rows.Add(registro);
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                }
            }
            return rows;
        }

        public static List<SIFModelo.Catalogo.Institucion> BuscaInstituciones(SIFModelo.Cliente cliente)
        {
            List<SIFModelo.Catalogo.Institucion> rows = new List<SIFModelo.Catalogo.Institucion>();

            string sentencia = "select institucion_id, nombre, cliente_id from CAT_CLIENTE_SUB_INSTITUCION WHERE cliente_id = :cliente_id";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("cliente_id", cliente.ID);

                    cmd.Connection.Open();
                    using (OracleDataReader oreader = cmd.ExecuteReader())
                    {
                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Catalogo.Institucion registro = new SIFModelo.Catalogo.Institucion();

                                registro.institucion_id = int.Parse(oreader["INSTITUCION_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();

                                rows.Add(registro);
                            }
                        }
                    }
                }

            }
            return rows;
        }


    }
}
