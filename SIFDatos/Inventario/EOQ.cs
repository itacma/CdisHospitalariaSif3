using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIFDatos.Inventario
{
    public static class EOQ
    {
        public static DataTable Get_VentasEoQ(string SucId, string FecIni, string FecFin,int diasEOQ, int diasTranscurridos, out string periodos, string tipoMedicamento = "%")
        {
            Cursor.Current = Cursors.WaitCursor;

            int nCols = 0, ind = 0;
            periodos = string.Empty;
            string ForEoQ = string.Empty;
            DataTable dtEoQ = new DataTable();
            char[] charsToTrim = { ' ', '+' };

            //string BD = "SIF";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_CALCULO_EOQ.sp_ventas_art";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pCols = cmd.Parameters.Add("ColsPeriodo", OracleDbType.RefCursor, ParameterDirection.Output);
                OracleParameter pVentas = cmd.Parameters.Add("Vtas", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("FecIni", OracleDbType.Varchar2, FecIni, ParameterDirection.Input);
                cmd.Parameters.Add("FecFin", OracleDbType.Varchar2, FecFin, ParameterDirection.Input);
                cmd.Parameters.Add("SucId", OracleDbType.Varchar2, SucId, ParameterDirection.Input);
                cmd.Parameters.Add("TipoMedicamento", OracleDbType.Varchar2, tipoMedicamento, ParameterDirection.Input);

                OracleDataReader _rdrObj = cmd.ExecuteReader();

                if (_rdrObj.HasRows) // Crear Tabla
                {
                    dtEoQ.Columns.Add("id", typeof(string));
                    dtEoQ.Columns.Add("nombre", typeof(string));
                    //                    dtEoQ.Columns.Add("total", typeof(double), "cantidad * precio");
                    dtEoQ.PrimaryKey = new DataColumn[] { dtEoQ.Columns["id"] };

                    while (_rdrObj.Read())
                    {
                        dtEoQ.Columns.Add(_rdrObj.GetString(_rdrObj.GetOrdinal("Periodo")), typeof(int));
                        periodos += "IsNull(" + _rdrObj.GetString(_rdrObj.GetOrdinal("Periodo")) + ", 0) + ";
                        nCols++;
                    }
                    //Periodos += "0";
                    periodos = periodos.TrimEnd(charsToTrim);
                    dtEoQ.Columns.Add("total", typeof(int), periodos);
                    dtEoQ.Columns.Add("ultmov", typeof(string));
                    dtEoQ.Columns.Add("faltante", typeof(int));
                    dtEoQ.Columns.Add("existencia", typeof(int));
                    dtEoQ.Columns.Add("precio", typeof(double));
                    dtEoQ.Columns.Add("costo", typeof(double));
                    dtEoQ.Columns.Add("Tipo", typeof(string));
                    dtEoQ.Columns.Add("factor", typeof(double));
                    dtEoQ.Columns.Add("EoQ_Inventario", typeof(int));
                    //dtEoQ.Columns["EoQ_Inventario"].ReadOnly = false;
                    


                    // Fórmula EoQ
                    ForEoQ = "((total * " + diasEOQ.ToString() + " ) / " + diasTranscurridos.ToString() + ") * factor";
                    dtEoQ.Columns.Add("EoQ", typeof(int), ForEoQ);
                    //dtEoQ.Columns["EoQ"].ReadOnly = false;

                    dtEoQ.Columns["factor"].ReadOnly = true;

                    DataRow dr;

                    // Llena Data Table
                    if (_rdrObj.NextResult())
                    {
                        if (_rdrObj.HasRows)
                        {
                            object[] rvalues = new object[_rdrObj.FieldCount];
                            dr = dtEoQ.NewRow();
                            while (_rdrObj.Read())
                            {
                                _rdrObj.GetValues(rvalues);
                                dtEoQ.Rows.Add(rvalues);
                            }
                            //Grd_VentasEoQ.DataSource = null;
                            //Grd_VentasEoQ.DataSource = dtEoQ;
                            //// Columns Format
                            //SIFUtils.InitializeDataGridViewCalculoEoQ(Grd_VentasEoQ, Periodos, nCols);
                            //SIFUtils.AutoNumberRowsForGridView(Grd_VentasEoQ);

                            return dtEoQ;
                        }
                    }
                }
                else
                {
                    //                    Grd_Traspaso.Rows.Clear();
                   MessageBox.Show("NO existe información de Ventas en el periodo especificado...", "Periodo EOQ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                _rdrObj.Close();
                _rdrObj.Dispose();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "EOQ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);
                }
                Cursor.Current = Cursors.Default;

            }

            if (dtEoQ.Columns.Count == 0)
            {
                dtEoQ.Columns.Add("total", typeof(int), periodos);
                dtEoQ.Columns.Add("ultmov", typeof(string));
                dtEoQ.Columns.Add("faltante", typeof(int));
                dtEoQ.Columns.Add("existencia", typeof(int));
                dtEoQ.Columns.Add("precio", typeof(double));
                dtEoQ.Columns.Add("costo", typeof(double));
                dtEoQ.Columns.Add("Tipo", typeof(string));
                dtEoQ.Columns.Add("factor", typeof(double));
                
                dtEoQ.Columns["factor"].ReadOnly = true;
                
                dtEoQ.Columns.Add("EoQ_Inventario", typeof(int));
                dtEoQ.Columns["EoQ_Inventario"].ReadOnly = false;
                dtEoQ.Columns.Add("EoQ", typeof(int), ForEoQ);
                dtEoQ.Columns["EoQ"].ReadOnly = true;
            }

            return dtEoQ;
        }

        public static DataTable Get_FactorEoQ()
        {
            Cursor.Current = Cursors.WaitCursor;

            int nCols = 0, ind = 0;
            
            string ForEoQ = string.Empty;
            DataTable dtEoQ = new DataTable();
            char[] charsToTrim = { ' ', '+' };

            //string BD = "SIF";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Select Factor_ID,Factor from CAT_FACTOR_EOQ ";
                

                // OUT REF CURSOR bound
                
                OracleDataReader _rdrObj = cmd.ExecuteReader();

                if (_rdrObj.HasRows) // Crear Tabla
                {
                    dtEoQ.Columns.Add("Tipo", typeof(string));
                    dtEoQ.Columns.Add("Factor", typeof(double));
                    
                    dtEoQ.PrimaryKey = new DataColumn[] { dtEoQ.Columns["Tipo"] };


                    DataRow dr;

                   
                            object[] rvalues = new object[_rdrObj.FieldCount];
                            dr = dtEoQ.NewRow();
                            while (_rdrObj.Read())
                            {
                                _rdrObj.GetValues(rvalues);
                                dtEoQ.Rows.Add(rvalues);
                            }
                            return dtEoQ;
                    
                }
                else
                {
                    //                    Grd_Traspaso.Rows.Clear();
                   MessageBox.Show("NO existe información de Ventas en el periodo especificado...", "Periodo EOQ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                _rdrObj.Close();
                _rdrObj.Dispose();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "EOQ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);
                }
                Cursor.Current = Cursors.Default;

            }

            return dtEoQ;
        }



        public static bool Actualiza(DataRow Factor)
        {
            string sentencia = "PKG_CALCULO_EOQ.SP_UPD_CAT_FACTOR_EOQ";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("efactor_id", Factor["Tipo"]);
                    cmd.Parameters.Add("efactor", Factor["Factor"]);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

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

        public static bool ActualizaEOQinventario(DataRow Factor, SIFModelo.Sucursal sucursal)
        {
            string sentencia = "PKG_CALCULO_EOQ.SP_UPD_PUNTO_REORDEN";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("Sucursal",sucursal.SucursalesID);
                    cmd.Parameters.Add("ArtId", Factor["ARTICULO_ID"]);
                    cmd.Parameters.Add("EoQ", Factor["PUNTO_DE_REORDEN"]);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

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


        public static bool ActualizaEOQinventarioBulk(List<DataRow> rows, SIFModelo.Sucursal sucursal,string periodo_inicio, string periodo_fin, int usuario_id, string peridos)
        {
            string sentencia = "PKG_CALCULO_EOQ.sp_upd_EoQ_inventario";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("Sucursal", sucursal.SucursalesID);
                    cmd.Parameters.Add("Periodo1", periodo_inicio);
                    cmd.Parameters.Add("Periodo2", periodo_fin);
                    cmd.Parameters.Add("Usuario", usuario_id);
                    cmd.Parameters.Add("Periodos", peridos);


                    OracleParameter pArtId = cmd.Parameters.Add("ArtId", OracleDbType.Varchar2);
                    pArtId.Direction = ParameterDirection.Input;
                    pArtId.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter pNombre = cmd.Parameters.Add("Nombre", OracleDbType.Varchar2);
                    pNombre.Direction = ParameterDirection.Input;
                    pNombre.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter pCant = cmd.Parameters.Add("Cant", OracleDbType.Decimal);
                    pCant.Direction = ParameterDirection.Input;
                    pCant.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    List<string> lArtID = new List<string>();
                    List<string> lNombre = new List<string>();
                    List<decimal> lCant = new List<decimal>();

                    foreach (DataRow row in rows)
                    {
                        lArtID.Add(row["id"].ToString());
                        lNombre.Add(row["Nombre"].ToString());
                        lCant.Add(System.Convert.ToDecimal( row["EoQ_Inventario"]));
                    }

                    pArtId.Value = lArtID.ToArray();
                    pNombre.Value = lNombre.ToArray();
                    pCant.Value = lCant.ToArray();


                    ////PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

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


        public static bool ActualizaTipoEOQ(DataRow row, SIFModelo.Sucursal sucursal)
        {
            string sentencia = "PKG_CALCULO_EOQ.sp_upd_tipo_eoq";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("ArtId", row["ID"]);
                    cmd.Parameters.Add("TipoEoQ", row["TIPO"]);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

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

        public static String insertaEoqImpFileSdie(
            String[] _Clave,
                                    int[] _2,
                                    int[] _3,
                                    int[] _4,
                                    int[] _5,
                                    int[] _6,
                                    int[] _7,
                                    int[] _8,
                                    int[] _9,
                                    int[] _10,
                                    int[] _11,
                                    int[] _12,
                                    int[] _17,
                                    int[] _18,
                                    int[] _20,
                                    int[] _21,
                                    int[] _24,
                                    int[] _25,
                                    int[] _26,
                                    int[] _29,
                                    int[] _31,
                                    int[] _51,
                                    int[] _37
            )
        {

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();


                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_CALCULO_EoQ.Imp_File_Eoq_Revisado";

                cmd.BindByName = true;

                OracleParameter InArtId = cmd.Parameters.Add("ArtId", OracleDbType.Varchar2);
                InArtId.Direction = ParameterDirection.Input;
                InArtId.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InArtId.Value = _Clave;


                OracleParameter InCantidad2 = cmd.Parameters.Add("Cant2", OracleDbType.Decimal);
                InCantidad2.Direction = ParameterDirection.Input;
                InCantidad2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad2.Value = _2;

                OracleParameter InCantidad3 = cmd.Parameters.Add("Cant3", OracleDbType.Decimal);
                InCantidad3.Direction = ParameterDirection.Input;
                InCantidad3.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad3.Value = _3;

                OracleParameter InCantidad4 = cmd.Parameters.Add("Cant4", OracleDbType.Decimal);
                InCantidad4.Direction = ParameterDirection.Input;
                InCantidad4.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad4.Value = _4;

                OracleParameter InCantidad5 = cmd.Parameters.Add("Cant5", OracleDbType.Decimal);
                InCantidad5.Direction = ParameterDirection.Input;
                InCantidad5.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad5.Value = _5;

                OracleParameter InCantidad6 = cmd.Parameters.Add("Cant6", OracleDbType.Decimal);
                InCantidad6.Direction = ParameterDirection.Input;
                InCantidad6.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad6.Value = _6;

                OracleParameter InCantidad7 = cmd.Parameters.Add("Cant7", OracleDbType.Decimal);
                InCantidad7.Direction = ParameterDirection.Input;
                InCantidad7.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad7.Value = _7;

                OracleParameter InCantidad8 = cmd.Parameters.Add("Cant8", OracleDbType.Decimal);
                InCantidad8.Direction = ParameterDirection.Input;
                InCantidad8.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad8.Value = _8;

                OracleParameter InCantidad9 = cmd.Parameters.Add("Cant9", OracleDbType.Decimal);
                InCantidad9.Direction = ParameterDirection.Input;
                InCantidad9.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad9.Value = _9;

                OracleParameter InCantidad10 = cmd.Parameters.Add("Cant10", OracleDbType.Decimal);
                InCantidad10.Direction = ParameterDirection.Input;
                InCantidad10.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad10.Value = _10;

                OracleParameter InCantidad11 = cmd.Parameters.Add("Cant11", OracleDbType.Decimal);
                InCantidad11.Direction = ParameterDirection.Input;
                InCantidad11.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad11.Value = _11;

                OracleParameter InCantidad12 = cmd.Parameters.Add("Cant12", OracleDbType.Decimal);
                InCantidad12.Direction = ParameterDirection.Input;
                InCantidad12.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad12.Value = _12;

                OracleParameter InCantidad17 = cmd.Parameters.Add("Cant17", OracleDbType.Decimal);
                InCantidad17.Direction = ParameterDirection.Input;
                InCantidad17.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad17.Value = _17;

                OracleParameter InCantidad18 = cmd.Parameters.Add("Cant18", OracleDbType.Decimal);
                InCantidad18.Direction = ParameterDirection.Input;
                InCantidad18.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad18.Value = _18;

                OracleParameter InCantidad20 = cmd.Parameters.Add("Cant20", OracleDbType.Decimal);
                InCantidad20.Direction = ParameterDirection.Input;
                InCantidad20.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad20.Value = _20;

                OracleParameter InCantidad21 = cmd.Parameters.Add("Cant21", OracleDbType.Decimal);
                InCantidad21.Direction = ParameterDirection.Input;
                InCantidad21.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad21.Value = _21;

                OracleParameter InCantidad24 = cmd.Parameters.Add("Cant24", OracleDbType.Decimal);
                InCantidad24.Direction = ParameterDirection.Input;
                InCantidad24.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad24.Value = _24;


                OracleParameter InCantidad25 = cmd.Parameters.Add("Cant25", OracleDbType.Decimal);
                InCantidad25.Direction = ParameterDirection.Input;
                InCantidad25.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad25.Value = _25;

                OracleParameter InCantidad26 = cmd.Parameters.Add("Cant26", OracleDbType.Decimal);
                InCantidad26.Direction = ParameterDirection.Input;
                InCantidad26.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad26.Value = _26;

                OracleParameter InCantidad29 = cmd.Parameters.Add("Cant29", OracleDbType.Decimal);
                InCantidad29.Direction = ParameterDirection.Input;
                InCantidad29.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad29.Value = _29;


                OracleParameter InCantidad31 = cmd.Parameters.Add("Cant31", OracleDbType.Decimal);
                InCantidad31.Direction = ParameterDirection.Input;
                InCantidad31.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad31.Value = _31;

                OracleParameter InCantidad51 = cmd.Parameters.Add("Cant51", OracleDbType.Decimal);
                InCantidad51.Direction = ParameterDirection.Input;
                InCantidad51.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad51.Value = _51;

                // Cantidad ATL (sucursal 37)
                OracleParameter InCantidad37 = cmd.Parameters.Add("Cant37", OracleDbType.Decimal);
                InCantidad37.Direction = ParameterDirection.Input;
                InCantidad37.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad37.Value = _37;

                OracleParameter pInsRespuesta =
                    cmd.Parameters.Add("OutParam", OracleDbType.Varchar2, ParameterDirection.Output);
                pInsRespuesta.Size = 1000;


                cmd.ExecuteNonQuery();


                return pInsRespuesta.Value.ToString();
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);
                }
            }
        }

        public static string spAplicaArchivoImp()
        {

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();


                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_CALCULO_EoQ.sp_aplica_RECIBIDO";
                cmd.BindByName = true;
                OracleParameter pInsRespuesta =
                    cmd.Parameters.Add("outparam", OracleDbType.Varchar2, ParameterDirection.Output);
                pInsRespuesta.Size = 1000;
                cmd.ExecuteNonQuery();
                return pInsRespuesta.Value.ToString();
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);
                }
            }
        }


        public static string spGeneraConcentradoMensual(int usuario_id)
        {

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                /*obtenemos el eoq de data2012*/
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_CALCULO_EoQ.sp_get_eoq_remoto";
                cmd.BindByName = true;
                
                OracleParameter pInsRespuesta =
                    cmd.Parameters.Add("outchar", OracleDbType.Varchar2, ParameterDirection.Output);
                pInsRespuesta.Size = 1000;
                cmd.ExecuteNonQuery();
                return pInsRespuesta.Value.ToString();
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);
                }
            }
        }


        public static string spProcesaConcentradoEoq()
        {

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();


                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_CALCULO_EoQ.sp_procesa_Cons_eoq";
                cmd.BindByName = true;
                OracleParameter pInsRespuesta =
                    cmd.Parameters.Add("outparam", OracleDbType.Varchar2, ParameterDirection.Output);
                pInsRespuesta.Size = 1000;
                cmd.ExecuteNonQuery();
                return pInsRespuesta.Value.ToString();
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);
                }
            }
        }




        public static string spActualizaConcentradoEoq()
        {

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();


                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_CALCULO_EoQ.sp_cierra_pdr_inventario";
                cmd.BindByName = true;
                OracleParameter pInsRespuesta =
                    cmd.Parameters.Add("outparam", OracleDbType.Varchar2, ParameterDirection.Output);
                pInsRespuesta.Size = 1000;
                cmd.ExecuteNonQuery();
                return pInsRespuesta.Value.ToString();
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);
                }
            }
        }




        public static DataSet get_EoqMes(string cadenab )
        {
            DataSet ds = new DataSet("DSEoq");
           
                string sentencia = "";

                ds.Tables.Add("Eoq");

                sentencia = "PKG_CALCULO_EoQ.SP_GET_EOQ_MENSUAL";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {


                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("cadenabuscar", cadenab);




                        OracleParameter requiciciones = new OracleParameter("outcursor", OracleDbType.RefCursor);
                        requiciciones.Direction = System.Data.ParameterDirection.Output;
                        cmd.Parameters.Add(requiciciones);


                        cmd.Connection.Open();

                        OracleDataAdapter da = new OracleDataAdapter(cmd);


                        da.Fill(ds, "Eoq");
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);

                    }


                    /*
                    ds.Tables.Add("PedidoDetalles");

                    string sentenciaDetalles = "SELECT p.num_pedido as folio,  pd.articulo_id as codigo,  pd.nombre1,  pd.cant_pedido AS NoPiezas,  i.ubicacion as ubicacion,  a.tipo_medicamento_cve as tipo,  pd.precio*pd.cant_pedido as total"
                                              + " FROM PEDIDO P,  PEDIDO_DET pd,  inventario  i,  cat_articulos a"
                                              + " WHERE p.num_pedido=pd.num_pedido and pd.articulo_id =i.ARTICULO_ID and pd.articulo_id =a.ARTICULO_ID and p.num_pedido like :NumeroPedido"
                                              + " AND fecha_pedido >= TO_DATE('" + fecha1.ToString("yyyy/MM/dd 00:00:00") + "','YYYY/MM/DD HH24:MI:SS') AND fecha_pedido <= TO_DATE('" + fecha2.ToString("yyyy/MM/dd 23:59:59") + "','YYYY/MM/DD HH24:MI:SS')"
                                              ;

                    using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                    {

                        using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                        {

                            cmd.Parameters.Add("NumeroPedido", "%" + Fnum_pedido + "%");
                            //
                            cmd.Connection.Open();
                            OracleDataAdapter da = new OracleDataAdapter(cmd);
                            da.Fill(ds, "PedidoDetalles");
                        }

                    }*/
                }
                catch (Exception exc)
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
            return ds;
        }

        
        public static List<SIFModelo.Inventarios.filtrosEoq> buscaFiltroEoq()
        {
            List<SIFModelo.Inventarios.filtrosEoq> rows = new List<SIFModelo.Inventarios.filtrosEoq>();

            string sentencia = "SELECT    tipo3,    f   filtro,    1 id FROM    eoq_mensual_suc_recibidos GROUP BY    tipo3,    f order by tipo3 asc";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    try
                    {
                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                //SIFModelo.Inventarios.Inventario
                                SIFModelo.Inventarios.filtrosEoq registro = new SIFModelo.Inventarios.filtrosEoq();
                                registro.tipo3 = oreader["TIPO3"].ToString();
                                registro.filtro = int.Parse(oreader["FILTRO"].ToString());
                                registro.id = int.Parse(oreader["ID"].ToString());


                                rows.Add(registro);
                            }
                        }
                    }
                    catch (Exception E_)
                    {


                    }
                    finally {


                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }

            }
            return rows;
        }

        public static int sp_upd_filtro_eoq(int valor,// corresponde al valor de 0 o 1 ,0 para quitalo del grid 1 para motrarlo en grid
            string add_cadena_exe// corresponde a la cadena que se quiere ejecutar en base de datos (el tipo de medicaquemnto que no se quiere mostrar o que si se quiere mostrar)
            )
        {

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();


                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_CALCULO_EoQ.sp_UPD_FILTRO";
                cmd.BindByName = true;

                cmd.Parameters.Add("V_VALOR", valor);
                cmd.Parameters.Add("v_cadena_c", add_cadena_exe);
                OracleParameter pInsRespuesta =cmd.Parameters.Add("outnumber", OracleDbType.Int32, ParameterDirection.Output);
                
                cmd.ExecuteNonQuery();
                return int.Parse(pInsRespuesta.Value.ToString());
            }
            catch (Exception ex)
            {

                return 0;
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);
                }
            }
        }


        public static bool actualizaModificaciones(List<string> l )
        {
            string sentencia = "PKG_CALCULO_EOQ.sp_set_eoq_modificacion_li";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;
                    List<string> L_exe = new List<string>();
                    foreach (string dato in l)
                    {
                        L_exe.Add(dato.ToString());
                        
                    }
                    OracleParameter pLista = cmd.Parameters.Add("p_lista", OracleDbType.Varchar2);
                    pLista.Direction = ParameterDirection.Input;
                    pLista.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pLista.Value = L_exe.ToArray();



                    ////PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outnumber", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            return false;
                        }
                    }
                    catch (Exception exc)
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

        public static string editaEoq(int usuario_id, int edita /*1 es para editar 0 para finalizar edicion*/)
        {

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                /*obtenemos el eoq de data2012*/
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_CALCULO_EOQ.sp_set_edita_cons";
                cmd.BindByName = true;
                cmd.Parameters.Add("V_USUARIO_ID", usuario_id);
                cmd.Parameters.Add("v_editar", edita);

                OracleParameter pInsRespuesta =
                    cmd.Parameters.Add("outchar", OracleDbType.Varchar2, ParameterDirection.Output);
                pInsRespuesta.Size = 1000;
                cmd.ExecuteNonQuery();
                return pInsRespuesta.Value.ToString();
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);
                }
            }
        }


        public static DataTable ExportaEoqXls(bool catalogocompleto)
        {
            DataTable tableListaBnf = new DataTable("EoqMensual");

            tableListaBnf.Columns.Add("CODIGO", typeof(String));
            tableListaBnf.Columns.Add("NOMBRE1", typeof(String));
            tableListaBnf.Columns.Add("NOMBRE2", typeof(String));
            tableListaBnf.Columns.Add("TIPO3", typeof(String));
            tableListaBnf.Columns.Add("EXISTENCIAS_CDIS", typeof(String));
            tableListaBnf.Columns.Add("FECHA_ULT_COMPRA");
            tableListaBnf.Columns.Add("PRECIO_VENTA", typeof(decimal));
            tableListaBnf.Columns.Add("PRECIO_COSTO", typeof(decimal));
            tableListaBnf.Columns.Add("CAP", typeof(Int32));
            tableListaBnf.Columns.Add("MAT", typeof(Int32));
            tableListaBnf.Columns.Add("POP", typeof(Int32));
            tableListaBnf.Columns.Add("TEC", typeof(Int32));
            tableListaBnf.Columns.Add("CHO", typeof(Int32));
            tableListaBnf.Columns.Add("CEN", typeof(Int32));
            tableListaBnf.Columns.Add("BEN", typeof(Int32));
            tableListaBnf.Columns.Add("CU" , typeof(Int32));
            tableListaBnf.Columns.Add("GPE", typeof(Int32));
            tableListaBnf.Columns.Add("AMA", typeof(Int32));
            tableListaBnf.Columns.Add("ACA", typeof(Int32));
            tableListaBnf.Columns.Add("SMT", typeof(Int32));
            tableListaBnf.Columns.Add("CCU", typeof(Int32));
            tableListaBnf.Columns.Add("TRR", typeof(Int32));
            tableListaBnf.Columns.Add("STA", typeof(Int32));
            tableListaBnf.Columns.Add("TLX", typeof(Int32));
            tableListaBnf.Columns.Add("IZU", typeof(Int32));
            tableListaBnf.Columns.Add("DIG", typeof(Int32));
            tableListaBnf.Columns.Add("PZO", typeof(Int32));






            string sentencia = "Pkg_Caducidades_V2.SP_GET_FILE_CONCENTRADO_EOQ";
            string V = Helpers.ConnectionString.Connection();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    if (catalogocompleto)
                        cmd.Parameters.Add("CCCOMPLETO", "S");
                    else
                        cmd.Parameters.Add("CCCOMPLETO", "N");

                    OracleParameter requiciciones = new OracleParameter("eoq", OracleDbType.RefCursor);
                    requiciciones.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(requiciciones);
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteReader();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                DataRow row = tableListaBnf.NewRow();


                                row["CODIGO"] = oreader["CODIGO"];
                                row["NOMBRE1"] = oreader["NOMBRE1"];
                                row["NOMBRE2"] = oreader["NOMBRE2"];
                                row["TIPO3"] = oreader["TIPO3"];
                                row["EXISTENCIAS_CDIS"] = oreader["EXISTENCIAS_CDIS"];
                                row["FECHA_ULT_COMPRA"] = oreader["FECHA_ULT_COMPRA"];
                                row["PRECIO_VENTA"] = oreader["PRECIO_VENTA"];
                                row["PRECIO_COSTO"] = oreader["PRECIO_COSTO"];
                                row["CAP"] = oreader["02_CAP"];
                                row["MAT"] = oreader["03_MAT"];
                                row["POP"] = oreader["04_POP"];
                                row["TEC"] = oreader["05_TEC"];
                                row["CHO"] = oreader["06_CHO"];
                                row["CEN"] = oreader["07_CEN"];
                                row["BEN"] = oreader["08_BEN"];
                                row["CU"] = oreader["09_CU"];
                                row["GPE"] = oreader["10_GPE"];
                                row["AMA"] = oreader["11_AMA"];
                                row["ACA"] = oreader["12_ACA"];
                                row["SMT"] = oreader["17_SMT"];
                                row["CCU"] = oreader["18_CCU"];
                                row["TRR"] = oreader["20_TRR"];
                                row["STA"] = oreader["21_STA"];
                                row["TLX"] = oreader["22_TLX"];
                                row["IZU"] = oreader["24_IZU"];
                                row["DIG"] = oreader["25_DIG"];
                                row["PZO"] = oreader["26_PZO"];






                                tableListaBnf.Rows.Add(row);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error:\n" + e.ToString() + "\n" + "En: PKG_VENTAS_TCA.sp_get_articulos_vale");
                    }
                }
            }
            return tableListaBnf;
        }



    }
}
