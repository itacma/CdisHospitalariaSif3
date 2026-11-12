using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
namespace SIFDatos
{
    public static class Usuarios
    {

        /// <summary>
        /// AVM 20-04-2015
        /// Actuliza la contraseña del usuario 
        /// </summary>
        /// <param name="usr"></param>
        /// <returns></returns>
        public static Boolean ActualizaContrasenha(SIFModelo.Usuario usr)
        {
            int result = 0;
            String sql = "UPDATE CAT_USUARIOS SET contrasena = :pass where usuarios_id = :idUsuario";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sql,cnx))
                {
                    cmd.Parameters.Add("pass", usr.Contrasena);
                    cmd.Parameters.Add("idUsuario", usr.UsuariosID);

                    try
                    {
                        cmd.Connection.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception x)
                    {
                        throw new Exception("No se pudo completar la operación, intentelo nuevamente." + x.Message);
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                    if (result <= 0)
                        return false;
                    return true;
                }
            }
        }

        /// <summary>
        /// AVM 20-04-2015
        /// Valida el usuario al que se le modificara la contraseña.
        /// solo regresa un true en caso de que el usuario y la contraseña sean validas.
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        public static Boolean ValidaUsuarioCambioPass(SIFModelo.Usuario modelo, Boolean validarAdmonSuper = false)
        {
            List<SIFModelo.Usuario> Usuarios = new List<SIFModelo.Usuario>();
            string sentencia = "";

            if(validarAdmonSuper)
                sentencia = "SELECT * FROM CAT_USUARIOS WHERE activo = 'S' AND acceso_id = :acceso_id AND contrasena = :contrasena AND TIPO_USUARIO IN ('A','S')";
            else
                sentencia = "SELECT * FROM CAT_USUARIOS WHERE activo = 'S' AND acceso_id = :acceso_id AND contrasena = :contrasena ";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //PARAMETROS
                    cmd.Parameters.Add("acceso_id", modelo.AccesoID);
                    cmd.Parameters.Add("contrasena", modelo.Contrasena);

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {

                                return true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al conectar con el servidor: " + ex.Message);

                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Busca el usuario por accesoId y contraseña
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        ///         
        public static SIFModelo.Usuario ValidaAcceso(SIFModelo.Usuario modelo)
        {
            List<SIFModelo.Usuario> Usuarios = new List<SIFModelo.Usuario>();

            string sentencia = "SELECT * FROM CAT_USUARIOS WHERE activo = 'S' AND acceso_id = :acceso_id AND contrasena = :contrasena ";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //PARAMETROS
                    cmd.Parameters.Add("acceso_id", modelo.AccesoID );
                    cmd.Parameters.Add("contrasena", modelo.Contrasena );

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Usuario registro = new SIFModelo.Usuario();
                  
                                registro.UsuariosID =  int.Parse(oreader["USUARIOS_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();
                                registro.Apellidos = oreader["APELLIDOS"].ToString();
                                registro.AccesoID = oreader["ACCESO_ID"].ToString();
                                registro.Activo = (SIFModelo.Tipos.SiNo)System.Convert.ToSByte(oreader["ACTIVO"].ToString()[0]);
                                registro.Contrasena = oreader["CONTRASENA"].ToString();
                                registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.TipoUsuario = (SIFModelo.Tipos.TipoUsuario)System.Convert.ToSByte(oreader["TIPO_USUARIO"].ToString()[0]);
                                registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);

                                DateTime fechaBaja;
                                if (System.DateTime.TryParse(oreader["FECHA_BAJA"].ToString(), out fechaBaja))
                                {
                                    registro.FechaBaja = fechaBaja;  
                                }

                                registro.Genero = (SIFModelo.Tipos.Genero)System.Convert.ToSByte(oreader["SEXO"].ToString()[0]);

                                int usuariovalidado = int.Parse(oreader["USUARIOS_ID"].ToString());

                                return registro;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al conectar con el servidor: " + ex.Message);
                       
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                }
            }
            return null;
        }

        public static SIFModelo.Usuario ValidaUsuario(string accesoid)
        {
            List<SIFModelo.Usuario> Usuarios = new List<SIFModelo.Usuario>();

            string sentencia = "SELECT * FROM CAT_USUARIOS WHERE activo = 'S' AND acceso_id = :acceso_id ";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //PARAMETROS
                    cmd.Parameters.Add("acceso_id", accesoid);
                    //cmd.Parameters.Add("contrasena", modelo.Contrasena);

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Usuario registro = new SIFModelo.Usuario();

                                registro.UsuariosID = int.Parse(oreader["USUARIOS_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();
                                registro.Apellidos = oreader["APELLIDOS"].ToString();
                                registro.AccesoID = oreader["ACCESO_ID"].ToString();
                                registro.Activo = (SIFModelo.Tipos.SiNo)System.Convert.ToSByte(oreader["ACTIVO"].ToString()[0]);
                                registro.Contrasena = oreader["CONTRASENA"].ToString();
                                registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.TipoUsuario = (SIFModelo.Tipos.TipoUsuario)System.Convert.ToSByte(oreader["TIPO_USUARIO"].ToString()[0]);
                                registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);

                                DateTime fechaBaja;
                                if (System.DateTime.TryParse(oreader["FECHA_BAJA"].ToString(), out fechaBaja))
                                {
                                    registro.FechaBaja = fechaBaja;
                                }

                                registro.Genero = (SIFModelo.Tipos.Genero)System.Convert.ToSByte(oreader["SEXO"].ToString()[0]);

                                return registro;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al conectar con el servidor: " + ex.Message);

                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);



                    }
                }
            }
            return null;
        }

        public static SIFModelo.Usuario UsuarioPorId(SIFModelo.Usuario modelo)
        {
            List<SIFModelo.Usuario> Usuarios = new List<SIFModelo.Usuario>();

            string sentencia = "SELECT * FROM CAT_USUARIOS WHERE USUARIOS_ID = :acceso_id";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //PARAMETROS
                    cmd.Parameters.Add("acceso_id", modelo.UsuariosID);

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Usuario registro = new SIFModelo.Usuario();

                                registro.UsuariosID = int.Parse(oreader["USUARIOS_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();
                                registro.Apellidos = oreader["APELLIDOS"].ToString();
                                registro.AccesoID = oreader["ACCESO_ID"].ToString();
                                registro.Activo = (SIFModelo.Tipos.SiNo)System.Convert.ToSByte(oreader["ACTIVO"].ToString()[0]);
                                registro.Contrasena = oreader["CONTRASENA"].ToString();
                                registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.TipoUsuario = (SIFModelo.Tipos.TipoUsuario)System.Convert.ToSByte(oreader["TIPO_USUARIO"].ToString()[0]);
                                registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);

                                DateTime fechaBaja;
                                if (System.DateTime.TryParse(oreader["FECHA_BAJA"].ToString(), out fechaBaja))
                                {
                                    registro.FechaBaja = fechaBaja;
                                }

                                registro.Genero = (SIFModelo.Tipos.Genero)System.Convert.ToSByte(oreader["SEXO"].ToString()[0]);

                                return registro;
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
                       // cmd.Connection.Dispose();
                       ////OracleConnection.ClearPool(cnx);
                    }

                }
            }
            return null;
        }

        public static SIFModelo.Usuario UsuarioPorAccesoId(SIFModelo.Usuario modelo)
        {
            List<SIFModelo.Usuario> Usuarios = new List<SIFModelo.Usuario>();

            string sentencia = "SELECT * FROM CAT_USUARIOS WHERE ACCESO_ID = :acceso_id";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //PARAMETROS
                    cmd.Parameters.Add("acceso_id", modelo.AccesoID);

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Usuario registro = new SIFModelo.Usuario();

                                registro.UsuariosID = int.Parse(oreader["USUARIOS_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();
                                registro.Apellidos = oreader["APELLIDOS"].ToString();
                                registro.AccesoID = oreader["ACCESO_ID"].ToString();
                                registro.Activo = (SIFModelo.Tipos.SiNo)System.Convert.ToSByte(oreader["ACTIVO"].ToString()[0]);
                                registro.Contrasena = oreader["CONTRASENA"].ToString();
                                registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.TipoUsuario = (SIFModelo.Tipos.TipoUsuario)System.Convert.ToSByte(oreader["TIPO_USUARIO"].ToString()[0]);
                                registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);

                                DateTime fechaBaja;
                                if (System.DateTime.TryParse(oreader["FECHA_BAJA"].ToString(), out fechaBaja))
                                {
                                    registro.FechaBaja = fechaBaja;
                                }

                                registro.Genero = (SIFModelo.Tipos.Genero)System.Convert.ToSByte(oreader["SEXO"].ToString()[0]);

                                return registro;
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
            return null;
        }

        /// <summary>
        /// Utiliza el SP_INS_Usuario para agregar un Usuario
        /// </summary>
        /// <param name="modelo">La instancia del Usuario</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.Usuario modelo)
        {
            string sentencia = "SP_INS_CAT_USUARIOS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("USUARIOS_ID", modelo.UsuariosID);
                    cmd.Parameters.Add("nombre", modelo.Nombre);
                    cmd.Parameters.Add("apellidos", modelo.Apellidos);
                    cmd.Parameters.Add("acceso_id", modelo.AccesoID);
                    cmd.Parameters.Add("activo", System.Convert.ToChar(modelo.Activo));
                    cmd.Parameters.Add("contrasena", modelo.Contrasena);
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("tipo_usuario", System.Convert.ToChar(modelo.TipoUsuario));
                    cmd.Parameters.Add("fecha_alta", modelo.FechaAlta);
                    cmd.Parameters.Add("fecha_baja", modelo.FechaBaja);
                    cmd.Parameters.Add("sexo", (char)modelo.Genero);

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
                                throw new Exception("Ha ocurrido un error al insetrar el registro");
                            }

                            modelo.UsuariosID = int.Parse(id.ToString());
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

        public static bool Elimina(SIFModelo.Usuario modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_USUARIO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("ID", modelo.UsuariosID);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteReader();
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

        public static bool Actualiza(SIFModelo.Usuario modelo)
        {
            string sentencia = "SP_UPD_CAT_USUARIOS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("euser_id", modelo.UsuariosID);
                    cmd.Parameters.Add("enombre", modelo.Nombre);
                    cmd.Parameters.Add("eapellidos", modelo.Apellidos);
                    cmd.Parameters.Add("eacceso_id", modelo.AccesoID);
                    cmd.Parameters.Add("econtrasena", modelo.Contrasena);
                    cmd.Parameters.Add("esucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("etipo_usuario", System.Convert.ToChar(modelo.TipoUsuario));
                    cmd.Parameters.Add("efecha_alta", modelo.FechaAlta);
                    cmd.Parameters.Add("efecha_baja", modelo.FechaBaja);
                    cmd.Parameters.Add("esexo", (char)modelo.Genero);
                    cmd.Parameters.Add("eactivo", (char)modelo.Activo);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteScalar();

                        if (outparam.Value.ToString().IsIntegerPositive())
                        {
                            if (int.Parse(outparam.Value.ToString()) > 0)
                            {
                                return true;
                            }

                        }
                        else
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

        public static List<SIFModelo.Usuario> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.Usuario> rows = new List<SIFModelo.Usuario>();

            string sentencia = "SELECT * FROM CAT_USUARIOS ";
            if (!string.IsNullOrEmpty(propiedad))
            { 
            sentencia += " WHERE " +propiedad + " LIKE '%" + parametro+ "%'";
            }

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
                            SIFModelo.Usuario registro = new SIFModelo.Usuario();

                            registro.UsuariosID = int.Parse( oreader["USUARIOS_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Apellidos = oreader["APELLIDOS"].ToString();
                            registro.AccesoID = oreader["ACCESO_ID"].ToString();
                            registro.Activo = (SIFModelo.Tipos.SiNo)System.Convert.ToSByte(oreader["ACTIVO"].ToString()[0]);
                            registro.Contrasena = oreader["CONTRASENA"].ToString();
                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.TipoUsuario = (SIFModelo.Tipos.TipoUsuario)System.Convert.ToSByte(oreader["TIPO_USUARIO"].ToString()[0]);
                            registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);

                            DateTime fechaBaja;
                            if (System.DateTime.TryParse(oreader["FECHA_BAJA"].ToString(), out fechaBaja))
                            {
                                registro.FechaBaja = fechaBaja;
                            }
                            //DateTime fechavigPassw;
                            //if (System.DateTime.TryParse(oreader["FECHA_VIGENCIA_PASSW"].ToString(), out fechavigPassw))
                            //{
                            //    registro.Fecha_vigencia_passw = fechavigPassw;
                            //}

                            //DateTime fechaultAcceso;
                            //if (System.DateTime.TryParse(oreader["FECHA_ULT_ACCESO"].ToString(), out fechaultAcceso))
                            //{
                            //    registro.fechaUltAcceso = fechaultAcceso;
                            //}

                            //registro.ingresosErroneos = int.Parse(oreader["INGRESOS_ERRONEOS"].ToString());

                            registro.Genero = (SIFModelo.Tipos.Genero)System.Convert.ToSByte(oreader["SEXO"].ToString()[0]);

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

        public static SIFModelo.Compradores ListaProveedores(SIFModelo.Usuario usuario)
        {
            string sentencia = "SELECT * FROM CAT_COMPRADORES ";
            sentencia += " WHERE USUARIO_ID = " + usuario.UsuariosID.ToString();


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
                            SIFModelo.Compradores registro = new SIFModelo.Compradores();

                            registro.UsuarioID = int.Parse(oreader["USUARIO_ID"].ToString());
                            registro.ListaSucursalID = oreader["LISTA_SUCURSAL_ID"].ToString();
                            registro.Tipo = oreader["TIPO"].ToString()[0];
                            registro.Activo = (SIFModelo.Tipos.SiNo)System.Convert.ToSByte(oreader["ACTIVO"].ToString()[0]);
                            registro.ListaProveedorId = oreader["LISTA_PROVEEDOR_ID"].ToString();
                            registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);

                          
                            return registro;
                        }
                    }

                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }
            return new SIFModelo.Compradores();
        }


        public static List<SIFModelo.Usuario> ListaDistribuidores()
        {
            List<SIFModelo.Usuario> Usuarios = new List<SIFModelo.Usuario>();

            string sentencia = "SELECT * FROM CAT_USUARIOS WHERE TIPO_USUARIO='D'";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //PARAMETROS
                    //cmd.Parameters.Add("acceso_id", modelo.AccesoID);

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Usuario registro = new SIFModelo.Usuario();

                                registro.UsuariosID = int.Parse(oreader["USUARIOS_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString()+ oreader["APELLIDOS"].ToString();
                                registro.Apellidos = oreader["APELLIDOS"].ToString();
                                registro.AccesoID = oreader["ACCESO_ID"].ToString();
                                registro.Activo = (SIFModelo.Tipos.SiNo)System.Convert.ToSByte(oreader["ACTIVO"].ToString()[0]);
                                registro.Contrasena = oreader["CONTRASENA"].ToString();
                                registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.TipoUsuario = (SIFModelo.Tipos.TipoUsuario)System.Convert.ToSByte(oreader["TIPO_USUARIO"].ToString()[0]);
                                registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);

                                DateTime fechaBaja;
                                if (System.DateTime.TryParse(oreader["FECHA_BAJA"].ToString(), out fechaBaja))
                                {
                                    registro.FechaBaja = fechaBaja;
                                }

                                registro.Genero = (SIFModelo.Tipos.Genero)System.Convert.ToSByte(oreader["SEXO"].ToString()[0]);
                                Usuarios.Add(registro);
                                //return Usuarios;
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
            return Usuarios;
        }

        public static List<SIFModelo.Compradores> ListaCompradores(string proveedorId)
        {
            List<SIFModelo.Compradores> rows = new List<SIFModelo.Compradores>();
            string
    sentencia = "SELECT C.USUARIO_ID, ";
    sentencia +="   U.NOMBRE,";
    sentencia +="   U.ACCESO_ID,";
    sentencia +="   C.LISTA_SUCURSAL_ID,";
    sentencia +="   C.ACTIVO,";
    sentencia +="   C.ACTIVO_F,";
    sentencia +="   C.LISTA_PROVEEDOR_ID";
    sentencia +=" FROM CAT_USUARIOS U ,";
    sentencia +="  (SELECT CP.usuario_id,";
            if(!string.IsNullOrEmpty(proveedorId)){
                sentencia +="    CASE";
                sentencia +="     WHEN regexp_like (CP.LISTA_PROVEEDOR_ID ,'"+proveedorId+"','i')";
                sentencia +="     THEN 'C'";
                sentencia +="     ELSE 'U'";
                sentencia +="    END ACTIVO_F,";
            }else
            {
            sentencia+=" 'U' ACTIVO_F,";
            }
    sentencia +="    CP.LISTA_SUCURSAL_ID,";
    sentencia +="    CP.ACTIVO,";
    sentencia +="    CP.LISTA_PROVEEDOR_ID";
    sentencia +="   FROM cat_compradores CP";
    sentencia +="   WHERE CP.ACTIVO ='S'";
    sentencia +="   ) C";
    sentencia +="   WHERE C.USUARIO_ID =U.USUARIOS_ID ";


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
                            SIFModelo.Compradores registro = new SIFModelo.Compradores();
                            registro.UsuarioID = int.Parse(oreader["USUARIO_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.AccesoId = oreader["ACCESO_ID"].ToString();
                            registro.ListaSucursalID = oreader["LISTA_SUCURSAL_ID"].ToString();
                            registro.Activo = (SIFModelo.Tipos.SiNo)System.Convert.ToSByte(oreader["ACTIVO"].ToString()[0]);
                            registro.SActivo = oreader["ACTIVO_F"].ToString();
                            registro.ListaProveedorId = oreader["LISTA_PROVEEDOR_ID"].ToString();
                            rows.Add(registro);
                        }
                       
                    }

                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);

                }

            }
            //return new List<SIFModelo.Compradores>();
            return rows;
        }


        public static SIFModelo.Usuario UsuarioPorId_cnx(SIFModelo.Usuario modelo, string _cnx)
        {
            List<SIFModelo.Usuario> Usuarios = new List<SIFModelo.Usuario>();

            string sentencia = "SELECT * FROM CAT_USUARIOS WHERE USUARIOS_ID = :acceso_id";
            using (OracleConnection cnx = new OracleConnection(_cnx))

            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //PARAMETROS
                    cmd.Parameters.Add("acceso_id", modelo.UsuariosID);

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Usuario registro = new SIFModelo.Usuario();

                                registro.UsuariosID = int.Parse(oreader["USUARIOS_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();
                                registro.Apellidos = oreader["APELLIDOS"].ToString();
                                registro.AccesoID = oreader["ACCESO_ID"].ToString();
                                registro.Activo = (SIFModelo.Tipos.SiNo)System.Convert.ToSByte(oreader["ACTIVO"].ToString()[0]);
                                registro.Contrasena = oreader["CONTRASENA"].ToString();
                                registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.TipoUsuario = (SIFModelo.Tipos.TipoUsuario)System.Convert.ToSByte(oreader["TIPO_USUARIO"].ToString()[0]);
                                registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);

                                DateTime fechaBaja;
                                if (System.DateTime.TryParse(oreader["FECHA_BAJA"].ToString(), out fechaBaja))
                                {
                                    registro.FechaBaja = fechaBaja;
                                }

                                registro.Genero = (SIFModelo.Tipos.Genero)System.Convert.ToSByte(oreader["SEXO"].ToString()[0]);

                                return registro;
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
            return null;
        }

    }
}
