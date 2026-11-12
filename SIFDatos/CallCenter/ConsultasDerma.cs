using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using DevComponents.DotNetBar;
using System.Data;

namespace SIFDatos.CallCenter
{
    public class ConsultasDerma
    {

        public static SIFModelo.CallCenter.CallCenterDataSet CargaConsultasDerma()
        {
            SIFModelo.CallCenter.CallCenterDataSet ds = new SIFModelo.CallCenter.CallCenterDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.CallCenter.CallCenterDataSetTableAdapters.CONSULTATableAdapter ta = new SIFModelo.CallCenter.CallCenterDataSetTableAdapters.CONSULTATableAdapter();
                ta.Connection = cnx;

                ta.Fill(ds.CONSULTA);
            }
            return ds;
        }

        public static DataSet CargaConsultasDerma(int SucursalID)
        {
           
                DataSet ds = new DataSet("DSCallCenter");
                ds.Tables.Add("CatConsultas");
                string sentencia = "SELECT     CONSULTA.CONSULTA_ID, CONSULTA.SUCURSAL_ID, CONSULTA.FECHA_CITA, CONSULTA.HORARIO_ID,  MEDICO_ID, CONSULTA.CLIENTE_ID, CAT_MEDICOS.NOMBRE, CAT_MEDICOS.CED_PROFESIONAL,  " +
                                   " CAT_MEDICOS.REG_SSA, CAT_MEDICOS.ESPECIALIDAD_ID, CAT_MEDICOS.EMAIL, CAT_MEDICOS.TIPO_DIR,CAT_MEDICOS.ACTIVO, CAT_MEDICOS.CONSULTA_FARMACIA, CAT_ESPECIALIDAD.NOMBRE AS CAT_ESPECIALIDAD_NOMBRE,  " +
                                   " CAT_CLIENTES.NOMBRE AS CAT_CLIENTE_NOMBRE, CAT_CLIENTES.APE_PATERNO AS CAT_CLIENTES_APE_PATERNO, CAT_CLIENTES.APE_MATERNO AS CAT_CLIENTES_APE_MATERNO, HORARIOS.NOMBRE AS HORARIOS_NOMBRE,  " +
                                   " HORARIOS.DIA_SEMANA AS HORARIOS_DIA_SEMANA, HORARIOS.TURNO AS HORARIOS_TURNO, HORARIOS.HORA_INICIO AS HORARIOS_HORA_INICIO, HORARIOS.HORA_FIN AS HORARIOS_HORA_FIN " +
                                   " FROM   CONSULTA INNER JOIN CAT_MEDICOS ON CONSULTA.MEDICO_ID = CAT_MEDICOS.MEDICOS_ID INNER JOIN CAT_ESPECIALIDAD ON CAT_MEDICOS.ESPECIALIDAD_ID = CAT_ESPECIALIDAD.ESPECIALIDAD_ID INNER JOIN " +
                                   " CAT_CLIENTES ON CONSULTA.CLIENTE_ID = CAT_CLIENTES.CLIENTES_ID INNER JOIN HORARIOS ON CONSULTA.HORARIO_ID = HORARIOS.HORARIO_ID    where CONSULTA.SUCURSAL_ID= :SUCURSALID and HORARIOS.HORA_INICIO>SYSDATE";



                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Parameters.Add(":SUCURSALID", SucursalID);
                        cmd.Connection.Open();
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(ds, "CatConsultas");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);

                }

                }
                return ds;

            }                
                
        


        public static SIFModelo.CallCenter.CallCenterDataSet CargaConsultasDerma(SIFModelo.Medico medico)
        {
            SIFModelo.CallCenter.CallCenterDataSet ds = new SIFModelo.CallCenter.CallCenterDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.CallCenter.CallCenterDataSetTableAdapters.CONSULTATableAdapter ta = new SIFModelo.CallCenter.CallCenterDataSetTableAdapters.CONSULTATableAdapter();
                ta.Connection = cnx;

                ta.FillByMEDICOS_ID(ds.CONSULTA, medico.ID);
            }
            return ds;
        }


        public static bool InsertaConsulta(SIFModelo.CallCenter.CallCenterDataSet.CONSULTARow modelo)
        {
            string sentencia = "SP_INS_CONSULTA";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("consulta_id", modelo.CONSULTA_ID);
                    cmd.Parameters.Add("sucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("fecha_cita", modelo.FECHA_CITA);
                    cmd.Parameters.Add("horario_id", modelo.HORARIO_ID);
                    cmd.Parameters.Add("id_medico", modelo.MEDICO_ID);
                    cmd.Parameters.Add("id_cliente", modelo.CLIENTE_ID);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        //if (!outparam.Value.ToString().IsIntegerPositive())
                        //{
                        //   MessageBox.Show("Error al insertar consulta " + outparam.Value.ToString()); 
                        //    return false;
                        //}
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

        public static bool ActualizaConsulta(SIFModelo.CallCenter.CallCenterDataSet.CONSULTARow modelo)
        {
            string sentencia = "SP_UPD_CONSULTA";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("econsulta_id", modelo.CONSULTA_ID);
                    cmd.Parameters.Add("esucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("efecha_cita", modelo.FECHA_CITA);
                    cmd.Parameters.Add("ehorario_id", modelo.HORARIO_ID);
                    cmd.Parameters.Add("emedico_id", modelo.MEDICO_ID);
                    cmd.Parameters.Add("ecliente_id", modelo.CLIENTE_ID);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Int32);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

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
    }
}
