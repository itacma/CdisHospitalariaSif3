using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Text;

namespace SIFDatos.ReportesArdmin
{
    public static  class reportesAdmin
    {

        public static List<SIFModelo.ReportesAdmin.reportesUsuarios> GetReportesCmb(string tipoUsuario)
        {
            string sentencia = "SELECT id , nombre, Q_DESC,ACTIVO,COLUMNS_NAME,QUERY,PARAM1,PARAM2, REQUIERE_FECHAS , TIPO_USUARIO, TIPO              " +
                "  FROM tbl_reportes_usuarios WHERE  activo ='S' and tipo_usuario LIKE '%"+ tipoUsuario + "%'";
            List<SIFModelo.ReportesAdmin.reportesUsuarios> m = new List<SIFModelo.ReportesAdmin.reportesUsuarios>();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                       
                        //
                        cmd.Connection.Open();
                        //var res = cmd.ExecuteReader();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.ReportesAdmin.reportesUsuarios registro = new SIFModelo.ReportesAdmin.reportesUsuarios();

                                registro.id = int.Parse(oreader["ID"].ToString());
                                registro.nombre = oreader["NOMBRE"].ToString();
                                registro.q_desc = oreader["Q_DESC"].ToString();
                                registro.colums_name = oreader["COLUMNS_NAME"].ToString();
                                registro.query = oreader["QUERY"].ToString();
                                registro.param1 = oreader["PARAM1"].ToString();
                                registro.param2 = oreader["PARAM2"].ToString();
                                registro.requiereFechas = oreader["REQUIERE_FECHAS"].ToString();
                                registro.tipo_ususario = oreader["TIPO_USUARIO"].ToString();
                                registro.tipo_reporte = oreader["TIPO"].ToString();
                                m.Add(registro);

                                
                            }
                        }


                    }
                }
                catch
                {
                    m = null;

                }
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
            return m;
        }

        public static List<string> GetReportesResult(string pparam)
        {

            string sentencia = "SELECT RESULT FROM CS_REPORTES_USUARIOS WHERE RPT ='"+ pparam + "'";
            List<string> rows = new List<string>();
            //List<SIFModelo.ReportesAdmin.reportesUsuarios> m = new List<SIFModelo.ReportesAdmin.reportesUsuarios>();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {

                        
                        cmd.Connection.Open();                        
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                              
                                rows.Add(oreader["RESULT"].ToString());


                            }
                        }


                    }
                }
                catch
                {
                  

                }
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
            return rows;
        }



        public static List<string> GetReportesResultQuery(string _quey, string param1 = "")
        {

            string sentencia = _quey;
            List<string> rows = new List<string>();
            //List<SIFModelo.ReportesAdmin.reportesUsuarios> m = new List<SIFModelo.ReportesAdmin.reportesUsuarios>();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        if (param1!="")
                        cmd.Parameters.Add(":param1", param1);
                        cmd.Connection.Open();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {

                                rows.Add(oreader["RESULT"].ToString());


                            }
                        }


                    }
                }
                catch
                {


                }
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
            return rows;
        }



        public static DataTable GetDataTable(SIFModelo.ReportesAdmin.reportesUsuarios Model)
        {
            DataSet ds = new DataSet("DSDatos");
            DataTable datos = new DataTable();
            try
            {
                string numremisiones = "'%'";
             

                //ds.Tables.Add("TDatos");
                ds.Tables.Add("TDatos").Columns.Add("RESULT");

                string sentencia = Model.query
                    ;
              

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {

                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                       

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("p_id", Model.id);
               

                        OracleParameter ocursor = new OracleParameter("outcursor", OracleDbType.RefCursor);
                        ocursor.Direction = System.Data.ParameterDirection.Output;
                        cmd.Parameters.Add(ocursor);

                        if (!string.IsNullOrEmpty(Model.param1))
                        cmd.Parameters.Add("p_pram1", Model.param1);
                        if (!string.IsNullOrEmpty(Model.param2))
                            cmd.Parameters.Add("p_pram2", Model.param2);

                        cmd.Connection.Open();

                        OracleDataAdapter da = new OracleDataAdapter(cmd);

                        da.Fill( datos);

                    }

                }

              
            }



            catch (Exception EXC)
            {

            }
            return datos;
        }



        public static string spInsSif3BitacoraSucesos(SIFModelo.Sif3BitacoraSucesos Model)
        {
            string sentencia = "SP_INS_SIF3_BIT_DE_SUCESOS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("p_ususario_id", Model.Usuario);
                    cmd.Parameters.Add("p_proceso", Model.Proceso);
                    cmd.Parameters.Add("p_referencia", Model.Referencia);
                    cmd.Parameters.Add("p_mesaje", Model.Mensaje);
                    cmd.Parameters.Add("p_articulo_id", Model.Articuloid);
                    cmd.Parameters.Add("p_cantidad", Model.Cantidad);

                    //parametros del array para detalle
                    // IN ARRAY PARAMETERS

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("out_resutl", OracleDbType.Varchar2);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    outparam.Size = 1000;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        var id = outparam.Value;
                        return id.ToString();
                    }
                    catch (Exception EX)
                    {
                        EX.ToString();
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                        //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            return "-1";
        }

    }
}
