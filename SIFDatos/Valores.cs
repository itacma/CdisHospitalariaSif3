using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace SIFDatos
{
    public class Valores
    {
        public static bool Inserta(SIFModelo.Catalogo.CatalogoDataSet.VALORESRow modelo)
        {
            string sentencia = "SP_INS_VALORES";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sec", modelo.SEC);
                    cmd.Parameters.Add("sucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("caja_id", modelo.CAJA_ID);
                    cmd.Parameters.Add("cajero_id", modelo.CAJERO_ID);
                    cmd.Parameters.Add("recoleccion_nombre", modelo.RECOLECCION_NOMBRE);
                    cmd.Parameters.Add("denominaciones_id", modelo.DENOMINACIONES_ID);
                    cmd.Parameters.Add("cantidad", modelo.CANTIDAD);
                    cmd.Parameters.Add("importe", modelo.IMPORTE);
                    cmd.Parameters.Add("total", modelo.TOTAL);
                    cmd.Parameters.Add("fecha", modelo.FECHA);
                    cmd.Parameters.Add("supervisor", modelo.SUPERVISOR);
                    cmd.Parameters.Add("activo", modelo.ACTIVO);

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

                            modelo.SEC = int.Parse(id.ToString());
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

        public static int NumeroSecuencia(int cajaId, int sucursalId)
        {
            object id;
            string sentencia = "SELECT NVL(MAX(SEC),0) + 1 FROM VALORES WHERE sucursal_id = :sucursalID AND CAJA_ID LIKE :CajaID";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("sucursalID", sucursalId);
                    cmd.Parameters.Add("CajaID", cajaId);
                    cmd.BindByName = true;

                    try
                    {
                        cmd.Connection.Open();

                        id = cmd.ExecuteScalar();
                        if (string.IsNullOrEmpty(id.ToString()))
                        {
                            return -1;
                        }
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                    finally
                    {

                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }
            return int.Parse(id.ToString());
        }

        public static SIFModelo.Catalogo.CatalogoDataSet CargaDatosFecha(SIFModelo.Caja caja, DateTime dateTime, DateTime fechaCierre)
        {
            SIFModelo.Catalogo.CatalogoDataSet ds = new SIFModelo.Catalogo.CatalogoDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.Catalogo.CatalogoDataSetTableAdapters.VALORESTableAdapter ta = new SIFModelo.Catalogo.CatalogoDataSetTableAdapters.VALORESTableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;
                string fecha = dateTime.ToString("yyyyMMdd HH:mm:ss");
                string fechaC = fechaCierre.ToString("yyyyMMdd HH:mm:ss");
                ta.FillByFechasCajaSucursal(ds.VALORES, caja.SucursalID, caja.ID, fecha, fechaC);
            }

            return ds;
        }

        public static bool Actualiza(SIFModelo.Catalogo.CatalogoDataSet.VALORESRow modelo)
        {
            string sentencia = "SP_UPD_VALORES";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("esec", modelo.SEC);
                    cmd.Parameters.Add("esucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("ecaja_id", modelo.CAJA_ID);
                    cmd.Parameters.Add("ecajero_id", modelo.CAJERO_ID);
                    cmd.Parameters.Add("erecoleccion_nombre", modelo.RECOLECCION_NOMBRE);
                    cmd.Parameters.Add("edenominaciones_id", modelo.DENOMINACIONES_ID);
                    cmd.Parameters.Add("ecantidad", modelo.CANTIDAD);
                    cmd.Parameters.Add("eimporte", modelo.IMPORTE);
                    cmd.Parameters.Add("etotal", modelo.TOTAL);
                    cmd.Parameters.Add("efecha", modelo.FECHA);
                    cmd.Parameters.Add("esupervisor", modelo.SUPERVISOR);
                    cmd.Parameters.Add("eactivo", modelo.ACTIVO);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();

                        cmd.ExecuteScalar();
                        if (outparam.Value.ToString().IsInteger())
                        {
                            if (int.Parse(outparam.Value.ToString()) < 0)
                            {
                                throw new Exception("Ha ocurrido un error al actualizar el registro ");
                            }

                            //modelo.SEC = int.Parse(outparam.Value.ToString());
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
