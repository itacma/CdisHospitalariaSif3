using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using System.Data;
namespace SIFDatos
{
    public static class Medicos
    {
        /// <summary>
        /// Utiliza el SP_INS_Medico para agregar un Medico
        /// </summary>
        /// <param name="modelo">La instancia del Medico</param>
        /// <returns>bool Insertado</returns>
        public static bool Inserta(SIFModelo.Medico modelo)
        {
            string sentencia = "sp_ins_cat_medicos";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nombre", modelo.Nombre);
                    cmd.Parameters.Add("ced_profesional", modelo.CedulaProfesional);
                    cmd.Parameters.Add("reg_ssa", modelo.RegistroSSA);
                    cmd.Parameters.Add("especialidad_id", modelo.EspecialidadNombre);
                    cmd.Parameters.Add("email", modelo.Email);
                    cmd.Parameters.Add("tipo_dir", modelo.TipoConsulta.Valor);
                    cmd.Parameters.Add("fecha_alta", modelo.FechaAlta);
                    cmd.Parameters.Add("fecha_baja", modelo.FechaBaja);
                    cmd.Parameters.Add("consulta_farmacia", (char)modelo.ConsultaFarmacia);
                    cmd.Parameters.Add("activo", (char)modelo.Activo);
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

        public static bool Elimina(SIFModelo.Medico modelo)
        {
            throw new NotImplementedException();

            string sentencia = "SP_DEL_Medico";
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

        public static bool Actualiza(SIFModelo.Medico modelo)
        {
            string sentencia = "sp_upd_cat_medicos";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("eid", modelo.ID);
                    cmd.Parameters.Add("enombre", modelo.Nombre);
                    cmd.Parameters.Add("eced_profesional", modelo.CedulaProfesional);
                    cmd.Parameters.Add("ereg_ssa", modelo.RegistroSSA);
                    cmd.Parameters.Add("eespecialidad_id", modelo.EspecialidadNombre);
                    cmd.Parameters.Add("eemail", modelo.Email);
                    cmd.Parameters.Add("etipo_dir", modelo.TipoConsulta.Valor);
                    cmd.Parameters.Add("efecha_alta", modelo.FechaAlta);
                    cmd.Parameters.Add("efecha_baja", modelo.FechaBaja);
                    cmd.Parameters.Add("econsulta_farmacia", (char)modelo.ConsultaFarmacia);
                    cmd.Parameters.Add("eactivo", (char)modelo.Activo);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        id = cmd.ExecuteScalar();

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

        public static List<SIFModelo.Medico> Busca(string propiedad, string parametro)
        {
            List<SIFModelo.Medico> rows = new List<SIFModelo.Medico>();

            string sentencia = "SELECT * FROM cat_medicos";

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
                            SIFModelo.Medico registro = new SIFModelo.Medico();

                            registro.ID = int.Parse(oreader["MEDICOS_ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.CedulaProfesional = oreader["CED_PROFESIONAL"].ToString();
                            registro.RegistroSSA = oreader["REG_SSA"].ToString();
                            registro.EspecialidadNombre = oreader["ESPECIALIDAD_ID"].ToString();
                            registro.Email = oreader["EMAIL"].ToString();

                            string tipoDireccion = oreader["TIPO_DIR"].ToString();
                            if (tipoDireccion == SIFModelo.Tipos.TipoConsulta.CASA.Valor)
                            {
                                registro.TipoConsulta = SIFModelo.Tipos.TipoConsulta.CASA;
                            }
                            if (tipoDireccion == SIFModelo.Tipos.TipoConsulta.CELULAR.Valor)
                            {

                                registro.TipoConsulta = SIFModelo.Tipos.TipoConsulta.CELULAR;
                            }
                            if (tipoDireccion == SIFModelo.Tipos.TipoConsulta.HOSPITAL.Valor)
                            {

                                registro.TipoConsulta = SIFModelo.Tipos.TipoConsulta.HOSPITAL;
                            }
                            if (tipoDireccion == SIFModelo.Tipos.TipoConsulta.NEXTEL.Valor)
                            {

                                registro.TipoConsulta = SIFModelo.Tipos.TipoConsulta.NEXTEL;
                            }
                            if (tipoDireccion == SIFModelo.Tipos.TipoConsulta.OFICINA.Valor)
                            {

                                registro.TipoConsulta = SIFModelo.Tipos.TipoConsulta.OFICINA;
                            }

                            registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"].ToString());

                            if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                            {
                                registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"].ToString());
                            }

                            registro.ConsultaFarmacia = (SIFModelo.Tipos.SiNo)(System.Convert.ToSByte(oreader["CONSULTA_FARMACIA"].ToString()[0]));

                            registro.Activo = (SIFModelo.Tipos.SiNo)(System.Convert.ToSByte(oreader["ACTIVO"].ToString()[0]));

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

        public static SIFModelo.Medico BuscaPorID(string parametro)
        {
            List<SIFModelo.Medico> rows = new List<SIFModelo.Medico>();

            string sentencia = "SELECT * FROM cat_medicos WHERE medicos_id = :medicos_id";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {

                        cmd.Parameters.Add("medicos_id", parametro);
                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Medico registro = new SIFModelo.Medico();

                                registro.ID = int.Parse(oreader["MEDICOS_ID"].ToString());
                                registro.Nombre = oreader["NOMBRE"].ToString();
                                registro.CedulaProfesional = oreader["CED_PROFESIONAL"].ToString();
                                registro.RegistroSSA = oreader["REG_SSA"].ToString();
                                registro.EspecialidadNombre = oreader["ESPECIALIDAD_ID"].ToString();
                                registro.Email = oreader["EMAIL"].ToString();

                                string tipoDireccion = oreader["TIPO_DIR"].ToString();
                                if (tipoDireccion == SIFModelo.Tipos.TipoConsulta.CASA.Valor)
                                {
                                    registro.TipoConsulta = SIFModelo.Tipos.TipoConsulta.CASA;
                                }
                                if (tipoDireccion == SIFModelo.Tipos.TipoConsulta.CELULAR.Valor)
                                {

                                    registro.TipoConsulta = SIFModelo.Tipos.TipoConsulta.CELULAR;
                                }
                                if (tipoDireccion == SIFModelo.Tipos.TipoConsulta.HOSPITAL.Valor)
                                {

                                    registro.TipoConsulta = SIFModelo.Tipos.TipoConsulta.HOSPITAL;
                                }
                                if (tipoDireccion == SIFModelo.Tipos.TipoConsulta.NEXTEL.Valor)
                                {

                                    registro.TipoConsulta = SIFModelo.Tipos.TipoConsulta.NEXTEL;
                                }
                                if (tipoDireccion == SIFModelo.Tipos.TipoConsulta.OFICINA.Valor)
                                {

                                    registro.TipoConsulta = SIFModelo.Tipos.TipoConsulta.OFICINA;
                                }

                                registro.FechaAlta = System.Convert.ToDateTime(oreader["FECHA_ALTA"].ToString());

                                if (oreader["FECHA_BAJA"].ToString().IsDatetime())
                                {
                                    registro.FechaBaja = System.Convert.ToDateTime(oreader["FECHA_BAJA"].ToString());
                                }

                                registro.ConsultaFarmacia = (SIFModelo.Tipos.SiNo)(System.Convert.ToSByte(oreader["CONSULTA_FARMACIA"].ToString()[0]));

                                registro.Activo = (SIFModelo.Tipos.SiNo)(System.Convert.ToSByte(oreader["ACTIVO"].ToString()[0]));

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

        public static bool InsertaDireccion(SIFModelo.DireccionMedico modelo)
        {
            string sentencia = "sp_ins_dir_medico";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("medico_id", modelo.MedicoID);
                    cmd.Parameters.Add("tipo_dir", modelo.TipoDireccion.Valor);
                    cmd.Parameters.Add("calle", modelo.Calle);
                    cmd.Parameters.Add("colonia", modelo.Colonia);
                    cmd.Parameters.Add("cp", modelo.CodigoPostal);
                    cmd.Parameters.Add("ciudad", modelo.Ciudad);
                    cmd.Parameters.Add("no_ext", modelo.NumeroExterior);
                    cmd.Parameters.Add("no_int", modelo.NumeroInterior);
                    cmd.Parameters.Add("municipio", modelo.Municipio);
                    cmd.Parameters.Add("telefono", modelo.Telefono);
                    cmd.Parameters.Add("email", modelo.Email);

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

        public static bool ActualizaDireccion(SIFModelo.DireccionMedico modelo)
        {
            string sentencia = "sp_upd_dir_medico";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("emedico_id", modelo.MedicoID);
                    cmd.Parameters.Add("etipo_dir", modelo.TipoDireccion.Valor);
                    cmd.Parameters.Add("ecalle", modelo.Calle);
                    cmd.Parameters.Add("ecolonia", modelo.Colonia);
                    cmd.Parameters.Add("ecp", modelo.CodigoPostal);
                    cmd.Parameters.Add("eciudad", modelo.Ciudad);
                    cmd.Parameters.Add("eno_ext", modelo.NumeroExterior);
                    cmd.Parameters.Add("eno_int", modelo.NumeroInterior);
                    cmd.Parameters.Add("emunicipio", modelo.Municipio);
                    cmd.Parameters.Add("etelefono", modelo.Telefono);
                    cmd.Parameters.Add("eemail", modelo.Email);
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

        public static SIFModelo.DireccionMedico DireccionMedico(SIFModelo.Medico medico)
        {
            string sentencia = "SELECT * FROM dir_medico WHERE medico_id = :medico_id ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //PARAMETROS
                        cmd.Parameters.Add("medico_id", medico.ID);

                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.DireccionMedico registro = new SIFModelo.DireccionMedico();

                                registro.ID = int.Parse(oreader["MEDICO_ID"].ToString());

                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoConsulta.CASA.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoConsulta.CASA;
                                }
                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoConsulta.CELULAR.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoConsulta.CELULAR;
                                }
                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoConsulta.HOSPITAL.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoConsulta.HOSPITAL;
                                }
                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoConsulta.NEXTEL.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoConsulta.NEXTEL;
                                }
                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoConsulta.OFICINA.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoConsulta.OFICINA;
                                }

                                registro.Calle = oreader["CALLE"].ToString();
                                registro.Colonia = oreader["COLONIA"].ToString();
                                registro.CodigoPostal = oreader["CP"].ToString();
                                registro.Ciudad = oreader["CIUDAD"].ToString();
                                registro.NumeroExterior = oreader["NO_EXT"].ToString();
                                registro.NumeroInterior = oreader["NO_INT"].ToString();
                                registro.Municipio = oreader["MUNICIPIO"].ToString();
                                registro.Telefono = oreader["TELEFONO"].ToString();
                                registro.Email = oreader["EMAIL"].ToString();

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

        public static SIFModelo.DireccionMedico DireccionMedico(SIFModelo.Medico medico, SIFModelo.Tipos.TipoConsulta tipoDir)
        {
            string sentencia = "SELECT * FROM dir_medico WHERE medico_id = :medico_id AND TIPO_DIR = :TipoDir ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //PARAMETROS
                        cmd.Parameters.Add("medico_id", medico.ID);
                        cmd.Parameters.Add("TipoDir", tipoDir.Valor);
                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.DireccionMedico registro = new SIFModelo.DireccionMedico();

                                registro.ID = int.Parse(oreader["MEDICO_ID"].ToString());

                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoConsulta.CASA.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoConsulta.CASA;
                                }
                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoConsulta.CELULAR.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoConsulta.CELULAR;
                                }
                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoConsulta.HOSPITAL.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoConsulta.HOSPITAL;
                                }
                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoConsulta.NEXTEL.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoConsulta.NEXTEL;
                                }
                                if (oreader["TIPO_DIR"].ToString() == SIFModelo.Tipos.TipoConsulta.OFICINA.Valor)
                                {
                                    registro.TipoDireccion = SIFModelo.Tipos.TipoConsulta.OFICINA;
                                }

                                registro.Calle = oreader["CALLE"].ToString();
                                registro.Colonia = oreader["COLONIA"].ToString();
                                registro.CodigoPostal = oreader["CP"].ToString();
                                registro.Ciudad = oreader["CIUDAD"].ToString();
                                registro.NumeroExterior = oreader["NO_EXT"].ToString();
                                registro.NumeroInterior = oreader["NO_INT"].ToString();
                                registro.Municipio = oreader["MUNICIPIO"].ToString();
                                registro.Telefono = oreader["TELEFONO"].ToString();
                                registro.Email = oreader["EMAIL"].ToString();

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
