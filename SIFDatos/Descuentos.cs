using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SIFDatos
{
    public static class Descuentos
    {
        /// <summary>
        /// Utiliza el SP_INS_Descuentos para agregar un Descuentos
        /// </summary>
        /// <param name="modelo">La instancia del Descuentos</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.Descuento modelo)
        {
            string sentencia = "SP_INS_CAT_DESCUENTOS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nombre", modelo.Nombre);
                    cmd.Parameters.Add("porcentaje", modelo.Porcentaje);
                    cmd.Parameters.Add("fecha_alta", modelo.FechaAlta);
                    cmd.Parameters.Add("fecha_baja", modelo.FechaBaja);

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

        public static bool Elimina(SIFModelo.Descuento modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_Descuentos";
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

        public static bool Actualiza(SIFModelo.Descuento modelo)
        {
            string sentencia = "SP_UPD_CAT_DESCUENTOS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("eid", modelo.ID);
                    cmd.Parameters.Add("enombre", modelo.Nombre);
                    cmd.Parameters.Add("eporcentaje", modelo.Porcentaje);
                    cmd.Parameters.Add("efecha_alta", modelo.FechaAlta);
                    cmd.Parameters.Add("efecha_baja", modelo.FechaBaja);
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

        public static List<SIFModelo.Descuento> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.Descuento> rows = new List<SIFModelo.Descuento>();

            string sentencia = "SELECT * FROM cat_descuentos";

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
                                SIFModelo.Descuento registro = new SIFModelo.Descuento();

                                registro.ID = int.Parse(oreader["DESCUENTOS_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();
                                registro.Activo = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                                registro.Porcentaje = System.Convert.ToDecimal(oreader["PORCENTAJE"]);
                                registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);

                                if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                                {
                                    registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                                }
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


        public static SIFModelo.Descuento DescuentoPorID(decimal p)
        {
            List<SIFModelo.Descuento> rows = new List<SIFModelo.Descuento>();

            string sentencia = "SELECT * FROM cat_descuentos WHERE DESCUENTOS_ID = " + p.ToString();

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
                                SIFModelo.Descuento registro = new SIFModelo.Descuento();

                                registro.ID = int.Parse(oreader["DESCUENTOS_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();
                                registro.Activo = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                                registro.Porcentaje = System.Convert.ToDecimal(oreader["PORCENTAJE"]);
                                registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"]);

                                if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                                {
                                    registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"]);
                                }
                                return registro;
                            }
                        }

                    }
                }
                catch {
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
                
        public static bool InsertarOActualizarEmpleadoMAPFRE(int descuentoId, string nombre, string noEmpleado, DateTime fechaNacimiento, DateTime fechaAlta, DateTime fechaInicio, DateTime fechaFin, int ultUsuarioId, string activo)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("SP_INSERT_O_ACT_EMPMAPFRE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetros del procedimiento almacenado
                        cmd.Parameters.Add("p_descuento_id", OracleDbType.Int32).Value = descuentoId;
                        cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = nombre;
                        cmd.Parameters.Add("p_no_empleado", OracleDbType.Varchar2).Value = noEmpleado;
                        cmd.Parameters.Add("p_fecha_nacimiento", OracleDbType.Date).Value = fechaNacimiento;
                        cmd.Parameters.Add("p_fecha_alta", OracleDbType.Date).Value = fechaAlta;
                        cmd.Parameters.Add("p_fecha_inicio", OracleDbType.Date).Value = fechaInicio;  // Nuevo parámetro
                        cmd.Parameters.Add("p_fecha_fin", OracleDbType.Date).Value = fechaFin;      // Nuevo parámetro
                        cmd.Parameters.Add("p_ult_usuario_id", OracleDbType.Int32).Value = ultUsuarioId;
                        cmd.Parameters.Add("p_activo", OracleDbType.Char).Value = activo;

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (OracleException ex)
            {
                // Verificamos si el código de error es -20002, que indica que el empleado ya existe
                if (ex.Number == 20002)
                {
                    MessageBox.Show("El número de empleado ya existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Manejar otras excepciones de Oracle
                    MessageBox.Show($"Error de Oracle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 
            }            
        }

        public static void DesactivarEmpleadosMAPFRE(List<string> listaNoEmpleadosEnArchivo)
        {
            if (listaNoEmpleadosEnArchivo == null || listaNoEmpleadosEnArchivo.Count == 0)
            {
                throw new ArgumentException("La lista de empleados está vacía.");
            }

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                cnx.Open();

                string empleadosEnArchivo = string.Join(",", listaNoEmpleadosEnArchivo);

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cnx;

                cmd.CommandText = $"UPDATE CAT_EMPLEADOS_DESC SET ACTIVO = 'N' WHERE NO_EMPLEADO NOT IN ({empleadosEnArchivo})";
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
            }

        }
        public static bool VerificarExistenciaEmpleado(string noEmpleado)
        {
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                OracleCommand cmd = new OracleCommand("SELECT COUNT(*) FROM CAT_EMPLEADOS_DESC WHERE NO_EMPLEADO = :NoEmpleado", cnx);
                cmd.Parameters.Add(":NoEmpleado", OracleDbType.Varchar2).Value = noEmpleado;

                cnx.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());  // Ejecutar la consulta para obtener el número de empleados

                return count > 0; // Si el número de empleados es mayor a 0, significa que existe
            }
        }

        public static void ActualizarFechaEmpleado(string noEmpleado)
        {
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                OracleCommand cmd = new OracleCommand("UPDATE CAT_EMPLEADOS_DESC SET ULT_FECHA_ACTUALIZACION = SYSDATE WHERE NO_EMPLEADO = :noEmpleado", cnx);
                cmd.Parameters.Add(":noEmpleado", OracleDbType.Varchar2).Value = noEmpleado;

                cnx.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
