using Oracle.DataAccess.Client;
using SIFModelo.EpGo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFDatos.EpGo
{
    public static class DatosConfiguracionEpGo
    {

        public static List<modelConfiguracionEpGo> GetConfiguracionEpGo(string nombreConfig = "")
        {
            List<modelConfiguracionEpGo> listaConfig = new List<modelConfiguracionEpGo>();

            // Usamos parámetros vinculados (:pName) por seguridad y rendimiento
            string query = @"SELECT ID, NAME, DESCRIPCION, HOST, PORT, 
                            JWTTOKEN, USER_NAME, PASSWORD, ACTIVO 
                     FROM configuracion_epgo";
            if (!String.IsNullOrEmpty(nombreConfig))
                query += @" WHERE NAME = :pName";

            try
            {
                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(query, cnx))
                    {
                        // Agregamos el parámetro de entrada
                        if (!String.IsNullOrEmpty(nombreConfig))
                            cmd.Parameters.Add("pName", OracleDbType.Varchar2).Value = nombreConfig;

                        cnx.Open();

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            // Si el reader encuentra una fila, llenamos el modelo

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {


                                    modelConfiguracionEpGo config = new modelConfiguracionEpGo();
                                    config.Id = reader["ID"].ToString();
                                    config.Name = reader["NAME"].ToString();
                                    config.Descripcion = reader["DESCRIPCION"]?.ToString();
                                    config.Host = reader["HOST"]?.ToString();
                                    config.Port = reader["PORT"]?.ToString();
                                    config.Jwttoken = reader["JWTTOKEN"]?.ToString();
                                    config.User_name = reader["USER_NAME"]?.ToString();
                                    config.Password = reader["PASSWORD"]?.ToString();
                                    config.Activo = reader["ACTIVO"].ToString();
                                    config._baseUrl = $"{config.Host}:{config.Port}/api";
                                    listaConfig.Add(config);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al obtener configuración: " + ex.Message);
                throw;
            }

            return listaConfig;
        }


        public static bool epgoUpdJwtToken(modelConfiguracionEpGo config)
        {
            bool actualizado = false;

            // Definimos la sentencia SQL con parámetros vinculados para evitar SQL Injection 🛡️
            string query = @"UPDATE configuracion_epgo 
                     SET jwttoken = :new_token 
                     WHERE name = :name 
                     AND host = :host 
                     AND id = :id";

            try
            {
                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(query, cnx))
                    {
                        // Agregamos los parámetros en el orden en que aparecen en la consulta
                        cmd.Parameters.Add("new_token", OracleDbType.Varchar2).Value = config.Jwttoken;
                        cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = config.Name;
                        cmd.Parameters.Add("host", OracleDbType.Varchar2).Value = config.Host;
                        cmd.Parameters.Add("id", OracleDbType.Varchar2).Value = config.Id;

                        cnx.Open();

                        // Ejecutamos la instrucción y guardamos el número de filas afectadas
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        // Si las filas afectadas son mayores a 0, la actualización fue exitosa
                        actualizado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el JWT Token: " + ex.Message);
                throw;
            }

            return actualizado;
        }


        public static bool epgoUpdActivo(modelConfiguracionEpGo config)
        {
            bool actualizado = false;

            // Definimos la sentencia SQL con parámetros vinculados para evitar SQL Injection 🛡️
            string query = @"UPDATE configuracion_epgo 
                     SET activo = :new_activo
                     WHERE name = :name 
                     AND host = :host 
                     AND id = :id";

            try
            {
                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(query, cnx))
                    {
                        // Agregamos los parámetros en el orden en que aparecen en la consulta
                        cmd.Parameters.Add("new_activo", OracleDbType.Varchar2).Value = config.Activo;
                        cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = config.Name;
                        cmd.Parameters.Add("host", OracleDbType.Varchar2).Value = config.Host;
                        cmd.Parameters.Add("id", OracleDbType.Varchar2).Value = config.Id;

                        cnx.Open();
                        // Ejecutamos la instrucción y guardamos el número de filas afectadas
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        // Si las filas afectadas son mayores a 0, la actualización fue exitosa
                        actualizado = filasAfectadas > 0;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el Activo Token: " + ex.Message);
                throw;
            }

            return actualizado;
        }
    }
}
