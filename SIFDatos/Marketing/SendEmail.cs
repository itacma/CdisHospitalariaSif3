using SIFDatos.Helpers;
using SIFModelo.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIFDatos.Marketing
{
    public static class SendEmail
    {
        public static List<SIFModelo.Marketing.modelPersona> BuscaListaemails(string activo, int grupo)
        {
            List<SIFModelo.Marketing.modelPersona> rows = new List<SIFModelo.Marketing.modelPersona>();
            string COLUMNAS = "ID, ID_GRUPO, EMAIL, ACTIVO, NAME, ID_EMPLEADO ";
            string whereClause = "";

            if (!String.IsNullOrEmpty(activo))
            {
                whereClause += " WHERE ACTIVO = '" + activo + "'";
            }

            if (grupo != -1)
            {
                if (!String.IsNullOrEmpty(whereClause))
                {
                    whereClause += " AND";
                }
                else
                {
                    whereClause += " WHERE";
                }
                whereClause += " ID_GRUPO = " + grupo;
            }
            string sentencia = "SELECT " + COLUMNAS + " FROM CS_EMAILS_CLIENTES_MAKI" + whereClause;

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Connection.Open();
                        OracleDataReader oreader = cmd.ExecuteReader();

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Marketing.modelPersona registro = new SIFModelo.Marketing.modelPersona
                                {
                                    Id = int.Parse(oreader["ID"].ToString()),
                                    Name = oreader["NAME"].ToString(),
                                    grupo = oreader["ID_GRUPO"].ToString(),
                                    Email = oreader["EMAIL"].ToString(),  // Asegúrate de asignar el campo EMAIL
                                    activo = oreader["ACTIVO"].ToString(),
                                    id_emp = oreader["ID_EMPLEADO"].ToString()
                                };

                                rows.Add(registro);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (cnx != null)
                    {
                        cnx.Close();
                        cnx.Dispose();
                    }
                }
            }
            return rows;
        }

        public static List<SIFModelo.Marketing.MGrupoSendEmail> BuscaListaGrupos()
        {
            List<SIFModelo.Marketing.MGrupoSendEmail> rows = new List<SIFModelo.Marketing.MGrupoSendEmail>();
            string COLUMNAS = " ID_GRUPO, DESCRIPCION,	CORREOS, ACTIVO_SIF, ACTIVO  ";


            string sentencia = "SELECT " + COLUMNAS + " FROM CS_EMAILS_CLIT_MAKI_GRUOP where ACTIVO='S'";

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
                                SIFModelo.Marketing.MGrupoSendEmail registro = new SIFModelo.Marketing.MGrupoSendEmail();
                                registro.IdGrupo = int.Parse(oreader["ID_GRUPO"].ToString());
                                registro.Descripcion = oreader["DESCRIPCION"].ToString();
                                registro.conteEmail = int.Parse(oreader["CORREOS"].ToString());
                                registro.activo = oreader["ACTIVO"].ToString();
                                registro.activo_sif = oreader["ACTIVO_SIF"].ToString();


                                if (registro.activo_sif!="N")
                                    rows.Add(registro);
                            }
                        }

                    }
                }
                catch { }
                finally
                {
                    if (null != cnx)
                    {
                        cnx.Close();
                        cnx.Dispose();
                    }
                }

            }
            return rows;
        }

        public static void InsertEmailLog(string userId, string fecha, string tieneAdjuntos, string descripcionAdjuntos, string nombreEquipo, string asunto, string grupo, string mensajeRespuesta, string estadoEnvio)
        {
            string connectionString = Helpers.ConnectionString.Connection();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string insertQuery = "INSERT INTO CLIT_MAKI_EMAIL_LOG (UserID, Fecha, TieneAdjuntos, DescripcionAdjuntos, NombreEquipo, Asunto, Grupo, MensajeRespuesta, EstadoEnvio) " +
                                    "VALUES (:UserID, TO_DATE(:Fecha, 'DD/MM/YYYY HH24:MI:SS'), :TieneAdjuntos, :DescripcionAdjuntos, :NombreEquipo, :Asunto, :Grupo, :MensajeRespuesta, :EstadoEnvio)";
                using (OracleCommand command = new OracleCommand(insertQuery, connection))
                {
                    command.Parameters.Add(new OracleParameter("UserID", userId));
                    command.Parameters.Add(new OracleParameter("Fecha", fecha));
                    command.Parameters.Add(new OracleParameter("TieneAdjuntos", tieneAdjuntos));
                    command.Parameters.Add(new OracleParameter("DescripcionAdjuntos", descripcionAdjuntos));
                    command.Parameters.Add(new OracleParameter("NombreEquipo", nombreEquipo));
                    command.Parameters.Add(new OracleParameter("Asunto", asunto));
                    command.Parameters.Add(new OracleParameter("Grupo", grupo));
                    command.Parameters.Add(new OracleParameter("MensajeRespuesta", mensajeRespuesta));
                    command.Parameters.Add(new OracleParameter("EstadoEnvio", estadoEnvio));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
                
        public static void ActualizarCampoActivo(string name, string activo)
        {
            string sentencia = "UPDATE CAT_EMAILS_CLIT_MAKI SET ACTIVO = :Activo WHERE NAME = :Name";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    cnx.Open();

                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Parameters.Add(new OracleParameter(":Name", name));
                        cmd.Parameters.Add(new OracleParameter(":Activo", "N"));

                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    if (cnx != null)
                    {
                        cnx.Close();
                        cnx.Dispose();
                    }
                }
            }
        }

        public static void InsertarNuevoCliente( string email, string nombre, string apellidos, int numeroEmpleado)
        {
             // Query para la tabla CAT_EMAILS_CLIENTES_MAKI
             string queryClientesMaki = "INSERT INTO CAT_EMAILS_CLIT_MAKI (ID, EMAIL, ACTIVO, NAME, ID_EMPLEADO) " +
                                         "VALUES (SEQ_EMAILS_CLIENTES_MAKI.NEXTVAL, :email, 'S', :name, :idEmpleado)";

             // Query para la tabla CAT_EMAILS_CLIT_MAKI_GRUP
             string queryClientesMakiGrup = "INSERT INTO CAT_EMAILS_CLIT_MAKI_GRUP (ID_GRUPO, EMAIL) " +
                                            "VALUES (1000, :email)";

             using (OracleConnection connection = new OracleConnection(Helpers.ConnectionString.Connection()))
             {
                 OracleTransaction transaction = null;
                 try
                 {
                     connection.Open();
                     transaction = connection.BeginTransaction();

                     using (OracleCommand command = new OracleCommand(queryClientesMaki, connection))
                     {
                         command.Transaction = transaction;
                         command.Parameters.Add(new OracleParameter("email", email));
                         command.Parameters.Add(new OracleParameter("name", apellidos + " " + nombre));
                         command.Parameters.Add(new OracleParameter("idEmpleado", numeroEmpleado));
                         command.ExecuteNonQuery();
                     }

                     using (OracleCommand command = new OracleCommand(queryClientesMakiGrup, connection))
                     {
                         command.Transaction = transaction;
                         command.Parameters.Add(new OracleParameter("email", email));
                         command.ExecuteNonQuery();
                     }
                     transaction.Commit();
                 }
                 catch (Exception ex)
                 {
                     if (transaction != null)
                     {
                         transaction.Rollback();
                     }
                     MessageBox.Show("Error al insertar en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                 finally
                 {
                     if (connection != null)
                     {
                         connection.Close();
                         connection.Dispose();
                     }
                 }
             }            
        }

        public static bool IsEmailDuplicated(string email)
        {
            string queryVerificarEmail = "SELECT COUNT(*) FROM CAT_EMAILS_CLIT_MAKI WHERE EMAIL = :email";
            using (OracleConnection connection = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    connection.Open();

                    using (OracleCommand command = new OracleCommand(queryVerificarEmail, connection))
                    {
                        command.Parameters.Add(new OracleParameter("email", email));
                        int emailCount = Convert.ToInt32(command.ExecuteScalar());
                        return emailCount > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar el correo en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
        }

        public static void EliminarDeGrupo(int idGrupo, string email)
        {
            string query = "DELETE FROM CAT_EMAILS_CLIT_MAKI_GRUP WHERE EMAIL = :email AND ID_GRUPO = :idGrupo";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(query, cnx))
                    {
                        cmd.Parameters.Add(new OracleParameter("email", email));
                        cmd.Parameters.Add(new OracleParameter("idGrupo", idGrupo));

                        cnx.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Registro eliminado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningún registro con los criterios proporcionados.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar el registro: " + ex.Message);
                }
                finally
                {
                    cnx.Close();
                    cnx.Dispose();
                }
            }
        }

        public static List<SIFModelo.Marketing.modelPersona> BuscarUsuariosNoEnGrupo()
        {
            List<SIFModelo.Marketing.modelPersona> usuariosNoEnGrupo = new List<SIFModelo.Marketing.modelPersona>();
            string sentencia = "SELECT ID, NAME, EMAIL FROM CS_EMAILS_CLIENTES_MAKI WHERE id_grupo = 1000 ORDER BY NAME ASC";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Connection.Open();
                        OracleDataReader oreader = cmd.ExecuteReader();

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                usuariosNoEnGrupo.Add(new modelPersona
                                {
                                    Id = int.Parse(oreader["ID"].ToString()),
                                    Name = oreader["NAME"].ToString(),
                                    Email = oreader["EMAIL"].ToString()
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    if (cnx != null)
                    {
                        cnx.Close();
                        cnx.Dispose();
                    }
                }
            }

            return usuariosNoEnGrupo;
        }

        public static void AgregarClienteAlGrupo( int idGrupo, string email)
        {
            string sentencia = "INSERT INTO CAT_EMAILS_CLIT_MAKI_GRUP (ID_GRUPO, EMAIL)  VALUES (:idGrupo, :email)";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Parameters.Add(new OracleParameter(":idGrupo", idGrupo));
                        cmd.Parameters.Add(new OracleParameter(":email", email));
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    if (cnx != null)
                    {
                        cnx.Close();
                        cnx.Dispose();
                    }
                }
            }
        }

        // Método para encriptar y guardar el email
        public static void SaveEmail(string email)
        {
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    cnx.Open();
                    string query = "UPDATE TBL_PARAMETROS SET VALUE = :EMAIL WHERE ID=1";
                    using (OracleCommand cmd = new OracleCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue(":EMAIL", email);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cnx.Close();
                    cnx.Dispose();
                }
            }
        }

        // Método para encriptar y guardar la contraseña
        public static void SaveEncryptedPassword(string plainPassword)
        {
            string encryptedPassword = CryptorEngine.Encrypt(plainPassword, true);

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    cnx.Open();
                    string query = "UPDATE TBL_PARAMETROS SET VALUE = :PASSWORD WHERE ID=2";
                    using (OracleCommand cmd = new OracleCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue(":PASSWORD", encryptedPassword);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cnx.Close();
                    cnx.Dispose();
                }
            }
        }

        public static string GetEmail()
        {
            string email = string.Empty;

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    cnx.Open();
                    string query = "SELECT VALUE FROM TBL_PARAMETROS WHERE ID=1";
                    using (OracleCommand cmd = new OracleCommand(query, cnx))
                    {
                        OracleDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            email = reader["VALUE"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    cnx.Close();
                    cnx.Dispose();
                }
            }
            return email;
        }

        // Método para desencriptar la contraseña
        public static string GetDecryptedPassword()
        {
            string encryptedPassword = string.Empty;

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    cnx.Open();
                    string query = "SELECT VALUE FROM TBL_PARAMETROS WHERE ID=2";
                    using (OracleCommand cmd = new OracleCommand(query, cnx))
                    {
                        OracleDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            encryptedPassword = reader["VALUE"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cnx.Close();
                    cnx.Dispose();
                }
            }

            if (!string.IsNullOrEmpty(encryptedPassword))
            {
                return CryptorEngine.Decrypt(encryptedPassword, true);
            }
            return string.Empty;
        }
    }
}