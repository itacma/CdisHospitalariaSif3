using SIFModelo.ReportesAdmin;
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Text;

namespace SIFDatos.ReportesArdmin
{
    public class Comercializacion
    {
        public static bool ActualizarFactura(ComercializacionMod factura)
        {
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand("PKG_ADMIN_SALDOS_CONVENIO.SP_ACTUALIZAR_FACTURA", cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("P_CASS_ID", OracleDbType.Int32).Value = factura.CASS_ID;
                        cmd.Parameters.Add("P_NUM_FACTURA", OracleDbType.Varchar2).Value = factura.NUMFACTURA;
                        cmd.Parameters.Add("P_FOLIO", OracleDbType.Varchar2).Value = factura.FOLIOFACTURA;
                        cmd.Parameters.Add("P_COMENTARIOS", OracleDbType.Varchar2).Value = factura.COMENTARIOS;
                        cmd.Parameters.Add("P_FECHA_FACTURA", OracleDbType.Date).Value = factura.FECHAFACTURA;
                        cmd.Parameters.Add("P_TOTAL", OracleDbType.Decimal).Value = factura.TOTAL;
                        cmd.Parameters.Add("P_USUARIO", OracleDbType.Varchar2).Value = factura.USUARIOALTA;

                        cnx.Open();
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar factura: " + ex.Message);
                    return false;
                }
            }
        }

        public List<Saldos> BuscarSaldosPorCliente(int? clienteId, string nombreCliente, string estado)
        {
            List<Saldos> lista = new List<Saldos>();

            using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
            using (OracleCommand cmd = new OracleCommand("PKG_ADMIN_SALDOS_CONVENIO.SP_BUSCAR_SALDOS_CLIENTE", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("P_CLIENTE_ID", OracleDbType.Int32).Value = (object)clienteId ?? DBNull.Value;
                cmd.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(nombreCliente) ? DBNull.Value : (object)nombreCliente;
                cmd.Parameters.Add("P_ESTADO", OracleDbType.Varchar2).Value = estado ?? "S";
                cmd.Parameters.Add("P_RESULTADO", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                conn.Open();
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Saldos
                        {
                            CASS_ID = int.Parse(reader["CASS_ID"].ToString()),
                            ClienteId = Convert.ToInt32(reader["CLIENTE_ID"]),
                            Nombre = reader["NOMBRE"].ToString(),
                            FechaInicio = Convert.ToDateTime(reader["FECHA_INICIO"]),
                            FechaFin = Convert.ToDateTime(reader["FECHA_FIN"]),
                            SaldoCredito = Convert.ToDecimal(reader["SALDO_CREDITO"]),
                            Usuario = reader["USUARIO_ALTA"].ToString(),
                            Activo = reader["ACTIVO"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public static List<ComercializacionMod> BuscarFacturasPorEstado(string estado)
        {
            List<ComercializacionMod> lista = new List<ComercializacionMod>();

            using (OracleConnection con = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                con.Open();
                using (var command = new OracleCommand("PKG_ADMIN_SALDOS_CONVENIO.SP_BUSCAR_FACTURAS_POR_ESTADO", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("P_ESTADO", OracleDbType.Varchar2).Value = estado;
                    command.Parameters.Add("P_RESULTADO", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ComercializacionMod
                            {
                                CASS_ID = int.Parse(reader["CASS_ID"].ToString()),
                                NOMBRE = reader["NOMBRE"].ToString(),
                                CLIENTES_ID = int.Parse(reader["CLIENTE_ID"].ToString()),
                                NUMFACTURA = reader["NUM_FACTURA"].ToString(),
                                FOLIOFACTURA = reader["FOLIO_FACTURA"].ToString(),
                                COMENTARIOS = reader["COMENTARIOS"].ToString(),
                                FECHAFACTURA = DateTime.Parse(reader["FECHA_FACTURA"].ToString()),
                                TOTAL = decimal.Parse(reader["TOTAL_IMPORTE_FACTURA"].ToString()),
                                FECHA_CARGA = DateTime.Parse(reader["FECHA_CARGA"].ToString()),
                                USUARIOALTA = reader["USR_ALTA"].ToString(),
                                ACTIVO = reader["ACTIVO"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static List<Saldos> BuscarSaldosPorEstado(string estado)
        {
            List<Saldos> lista = new List<Saldos>();

            using (OracleConnection con = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                con.Open();
                using (var command = new OracleCommand("PKG_ADMIN_SALDOS_CONVENIO.SP_BUSCAR_SALDOS_POR_ESTADO", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("P_ESTADO", OracleDbType.Varchar2).Value = estado;
                    command.Parameters.Add("P_RESULTADO", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Saldos
                            {
                                CASS_ID = int.Parse(reader["CASS_ID"].ToString()),
                                Nombre = reader["NOMBRE"].ToString(),
                                ClienteId = int.Parse(reader["CLIENTE_ID"].ToString()),
                                SaldoCredito = int.Parse(reader["SALDO_CREDITO"].ToString()),
                                FechaInicio = DateTime.Parse(reader["FECHA_INICIO"].ToString()),
                                FechaFin = DateTime.Parse(reader["FECHA_FIN"].ToString()),
                                Usuario = reader["USUARIO"].ToString(),
                                Activo = reader["ACTIVO"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;       
        }

        public static List<ComercializacionMod> CargaClientesConvenio()
        {
            List<ComercializacionMod> clientesConvenio = new List<ComercializacionMod>();
            string query = "select *from cat_clientes where convenio ='S' and activo='S'";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(query, cnx))
                    {
                        cmd.Connection.Open();
                        OracleDataReader oreader = cmd.ExecuteReader();

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                clientesConvenio.Add(new ComercializacionMod
                                {
                                    CLIENTES_ID = int.Parse(oreader["CLIENTES_ID"].ToString()),
                                    NOMBRE = oreader["NOMBRE"].ToString(),
                                    ACTIVO = oreader["ACTIVO"].ToString()
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

            return clientesConvenio;
        }

        public static bool InsertarFacturaConvenio(ComercializacionMod factura)
        {
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand("PKG_ADMIN_SALDOS_CONVENIO.SP_INSERTAR_FACTURA_CONVENIO", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("P_CLIENTE_ID", factura.CLIENTES_ID));
                    cmd.Parameters.Add(new OracleParameter("P_NUM_FACTURA", factura.NUMFACTURA));
                    cmd.Parameters.Add(new OracleParameter("P_FOLIO_FACTURA", factura.FOLIOFACTURA));
                    cmd.Parameters.Add(new OracleParameter("P_COMENTARIOS", factura.COMENTARIOS));
                    cmd.Parameters.Add(new OracleParameter("P_FECHA_FACTURA", factura.FECHAFACTURA));
                    cmd.Parameters.Add(new OracleParameter("P_TOTAL_IMPORTE_FACTURA", factura.TOTAL));
                    cmd.Parameters.Add(new OracleParameter("P_USER_ID", factura.USUARIOALTA));

                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    return true;                    
                }
            }
        }

        public static List<ComercializacionMod> ObtenerFacturasConvenio()
        {
            List<ComercializacionMod> lista = new List<ComercializacionMod>();

            string query = "SELECT * FROM VW_FACTURAS_CONVENIO ORDER BY FECHA_CARGA DESC";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(query, cnx))
                    {
                        cnx.Open();
                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            lista.Add(new ComercializacionMod
                            {
                                CASS_ID = int.Parse(reader["CASS_ID"].ToString()),
                                NOMBRE = reader["NOMBRE"].ToString(),
                                CLIENTES_ID = int.Parse(reader["CLIENTE_ID"].ToString()),
                                NUMFACTURA = reader["NUM_FACTURA"].ToString(),
                                FOLIOFACTURA = reader["FOLIO_FACTURA"].ToString(),
                                COMENTARIOS = reader["COMENTARIOS"].ToString(),
                                FECHAFACTURA = DateTime.Parse(reader["FECHA_FACTURA"].ToString()),
                                TOTAL = decimal.Parse(reader["TOTAL_IMPORTE_FACTURA"].ToString()),
                                FECHA_CARGA = DateTime.Parse(reader["FECHA_CARGA"].ToString()),
                                USUARIOALTA = reader["USR_ALTA"].ToString(),
                                ACTIVO = reader["ACTIVO"].ToString()

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener facturas: " + ex.Message);
                }
            }

            return lista;
        }

        public static bool CancelarFacturaConvenio(ComercializacionMod factura)
        {
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand("PKG_ADMIN_SALDOS_CONVENIO.SP_CANCELAR_FACTURA_CONVENIO ", cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.BindByName = true;

                        cmd.Parameters.Add(new OracleParameter("P_USER_ID", factura.USUARIOALTA));
                        cmd.Parameters.Add(new OracleParameter("P_CASS_ID", factura.CASS_ID));

                        try
                        {
                            cnx.Open();
                            cmd.ExecuteNonQuery();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al cancelar factura: " + ex.Message);
                            return false;
                        }
                    }
                }
                catch (OracleException ex)
                {
                    if (ex.Number == 20001)
                        throw new ApplicationException(ex.Message);
                    else
                        throw; 
                }

            }
        }

        public static bool InsertarSaldoCliente(PeriodoSaldo datos)
        {
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand("PKG_ADMIN_SALDOS_CONVENIO.SP_INSERTAR_SALDO_CREDITO", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("P_CLIENTE_ID", OracleDbType.Int32).Value = datos.ClienteId;
                    cmd.Parameters.Add("P_FECHA_INICIO", OracleDbType.Date).Value = datos.FechaInicio;
                    cmd.Parameters.Add("P_FECHA_FIN", OracleDbType.Date).Value = datos.FechaFin;
                    cmd.Parameters.Add("P_SALDO_CREDITO", OracleDbType.Decimal).Value = datos.SaldoCredito;
                    cmd.Parameters.Add(new OracleParameter("P_USUARIO_ALTA", datos.Usuario));

                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public static List<Saldos> ObtenerSaldosConvenio()
        {
            List<Saldos> lista = new List<Saldos>();
            string query = "SELECT * FROM VW_SALDOS_CONVENIO ORDER BY 1 DESC";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(query, cnx))
                    {
                        cnx.Open();
                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            lista.Add(new Saldos
                            {
                                CASS_ID = int.Parse(reader["CASS_ID"].ToString()),
                                Nombre = reader["NOMBRE"].ToString(),
                                ClienteId = int.Parse(reader["CLIENTE_ID"].ToString()),
                                SaldoCredito = int.Parse(reader["SALDO_CREDITO"].ToString()),
                                FechaInicio = DateTime.Parse(reader["FECHA_INICIO"].ToString()),
                                FechaFin = DateTime.Parse(reader["FECHA_FIN"].ToString()),
                                Usuario = reader["USUARIO"].ToString(),
                                Activo = reader["ACTIVO"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener saldos: " + ex.Message);
                }
            }
            return lista;
        }

        public static bool CancelarSaldosConvenio(Saldos saldo)
        {
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand("PKG_ADMIN_SALDOS_CONVENIO.SP_CANCELAR_SALDO_CONVENIO ", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    cmd.Parameters.Add(new OracleParameter("P_USER_ID", saldo.Usuario));
                    cmd.Parameters.Add(new OracleParameter("P_CASS_ID", saldo.CASS_ID));

                    try
                    {
                        cnx.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al cancelar Saldo: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public static bool ActualizarSaldoCredito(Saldos saldo)
        {
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand("PKG_ADMIN_SALDOS_CONVENIO.SP_ACTUALIZAR_SALDO_CREDITO", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("P_CASS_ID", saldo.CASS_ID));
                    cmd.Parameters.Add(new OracleParameter("P_SALDO_CREDITO", saldo.SaldoCredito));
                    cmd.Parameters.Add(new OracleParameter("P_USER_ID", saldo.Usuario));

                    try
                    {
                        cnx.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al actualizar saldo: " + ex.Message);
                        return false;
                    }
                }
            }
        }               

        public static SaldoAutomatizado ObtenerSaldoPorCliente(int clienteId)
        {
            SaldoAutomatizado saldo = null;
            
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    cnx.Open();
                    using (OracleCommand cmd = new OracleCommand("PKG_ADMIN_SALDOS_CONVENIO.SP_OBTENER_SALDO_CLIENTE", cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("P_CLIENTE_ID", OracleDbType.Int32).Value = clienteId;
                        cmd.Parameters.Add("P_RESULTADO", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                saldo = new SaldoAutomatizado
                                {
                                    CLIENTE_ID = Convert.ToInt32(reader["CLIENTE_ID"]),
                                    NOMBRE = reader["NOMBRE"].ToString(),
                                    FECHA_SALDO_INI = reader["FECHA_SALDO_INI"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FECHA_SALDO_INI"]),
                                    FECHA_SALDO_FIN = reader["FECHA_SALDO_FIN"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["FECHA_SALDO_FIN"]),
                                    ULT_FECHA_MODIFICACION = reader["ULT_FECHA_MODIFICACION"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["ULT_FECHA_MODIFICACION"]),
                                    SALDO_CREDITO = reader["SALDO_CREDITO"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["SALDO_CREDITO"]),
                                    SALDO_CARGO = reader["SALDO_CARGO"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["SALDO_CARGO"]),
                                    SALDO_ABONO = reader["SALDO_ABONO"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["SALDO_ABONO"]),
                                    SALDO_DISPONIBLE = reader["SALDO_DISPONIBLE"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["SALDO_DISPONIBLE"])
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener el saldo del cliente: " + ex.Message);
                }
            }
            return saldo;
        }

        public static bool CerrarSaldosConvenio(Saldos saldo)
        {
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand("PKG_ADMIN_SALDOS_CONVENIO.SP_CERRAR_SALDO_CONVENIO ", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    cmd.Parameters.Add(new OracleParameter("P_USER_ID", saldo.Usuario));
                    cmd.Parameters.Add(new OracleParameter("P_CASS_ID", saldo.CASS_ID));

                    try
                    {
                        cnx.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al cerrar Saldo: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public static bool CerrarFacturas(ComercializacionMod factura)
        {
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand("PKG_ADMIN_SALDOS_CONVENIO.SP_CERRAR_FACTURA_CONVENIO ", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    cmd.Parameters.Add(new OracleParameter("P_USER_ID", factura.USUARIOALTA));
                    cmd.Parameters.Add(new OracleParameter("P_CASS_ID", factura.CASS_ID));

                    try
                    {
                        cnx.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al cerrar Factura: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
