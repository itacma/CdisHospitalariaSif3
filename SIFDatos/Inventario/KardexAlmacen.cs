using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data;
using DevComponents.DotNetBar;

namespace SIFDatos.Inventario
{
    public class KardexAlmacen
    {
        public static SIFModelo.Inventarios.InventarioDataSet GetKardex(string Ini, string Fin,String Articulo_ID, string  tipoMM)
        {

            SIFModelo.Inventarios.InventarioDataSet Ds = new SIFModelo.Inventarios.InventarioDataSet();


            Cursor.Current = Cursors.WaitCursor;

            //   int nRow = 1, ind = 0;

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();
                /*
                #region DETALLE DE CADUCIDADES
                Ds.Tables.Add("CaducidadesDetalles");
                string sentenciaDetalles = "select folio, articulo_id , no_lote  from control_caducidades "; //sucursal_id = :sucursalId AND

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {

                    using (OracleCommand cmd2 = new OracleCommand(sentenciaDetalles, cnx))
                    {
                        //cmd.Parameters.Add("sucursalId", sucursal.SucursalesID);
                        //cmd.Parameters.Add("sucursalesId", sucursal.SucursalesID);
                        //cmd2.Parameters.Add("NumeroRequisicion", "%" + rfd.Requisicion + "%");
                        //
                        cmd2.Connection.Open();
                        OracleDataAdapter da2 = new OracleDataAdapter(cmd2);
                        da2.Fill(Ds, "CaducidadesDetalles");
                    }

                }
                #endregion

                */
                // Create an OracleCommand

                OracleCommand cmd = conn.CreateCommand();
                
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_INVENTARIOS.sp_get_Kardex";
                    cmd.BindByName = true;

                    // OUT REF CURSOR bound
                    OracleParameter pPedido = cmd.Parameters.Add("Hdr", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.Parameters.Add("FecIni", OracleDbType.Varchar2, Ini, ParameterDirection.Input);
                    cmd.Parameters.Add("FecFin", OracleDbType.Varchar2, Fin, ParameterDirection.Input);
                    cmd.Parameters.Add("ArtID", OracleDbType.Varchar2, Articulo_ID, ParameterDirection.Input);
                    cmd.Parameters.Add("tipoM", OracleDbType.Varchar2, tipoMM, ParameterDirection.Input);
                
                                
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(Ds, "KARDEX");
                conn.Close();
                conn.Dispose();
               //OracleConnection.ClearPool(conn);



            }
            catch (Exception ex)
            {
                //MessageBoxEx.Show(ex.Message, "Kardex", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            return Ds;

        }



        public static List<SIFModelo.LTipoMK> BTMK()
        {
            List<SIFModelo.LTipoMK> rows = new List<SIFModelo.LTipoMK>();

            string sentencia = "SELECT DISTINCT NOMBRE tipo FROM CAT_TIPO_MOV_INV order by 1 asc";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                    SIFModelo.LTipoMK registro = new SIFModelo.LTipoMK();
                    if (oreader.HasRows)
                    {

                        registro.tipoMk = ("TODOS");
                        rows.Add(registro);

                        while (oreader.Read())
                        {
                            registro = new SIFModelo.LTipoMK();
                            registro.tipoMk = oreader["tipo"].ToString();
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

        public static List<SIFModelo.Proveedor> PROV()
        {
            List<SIFModelo.Proveedor> rows = new List<SIFModelo.Proveedor>();

            string sentencia = "SELECT trim(nombre) prov FROM cat_clientes WHERE proveedor='S' ORDER BY nombre asc";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                    SIFModelo.Proveedor registros = new SIFModelo.Proveedor();
                    if (oreader.HasRows)
                    {

                        registros.proveedor = ("TODOS");
                        rows.Add(registros);

                        while (oreader.Read())
                        {
                            registros = new SIFModelo.Proveedor();
                            registros.proveedor = oreader["prov"].ToString();
                            rows.Add(registros);

                        }

                    }

                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    //OracleConnection.ClearPool(cnx);

                }

            }
            return rows;
        }
        public static DataTable sp_Get_Art_cad_porFecha(string fechaI)
            {
            
            DataTable taCaducidad = new DataTable("CONTROL_CADUCIDADES");
            taCaducidad.Columns.Add("lote", typeof(string));
            taCaducidad.Columns.Add("caducidad", typeof(DateTime));
            taCaducidad.Columns.Add("cantidad", typeof(int));
            taCaducidad.Columns.Add("DOCUMENTO", typeof(String));
            taCaducidad.Columns.Add("tipo_mov_inv", typeof(string));
            //SIFModelo.Inventarios.InventarioDataSet Ds = new SIFModelo.Inventarios.InventarioDataSet();
            string sentencia = "PKG_CADUCIDADES.sp_Get_Art_Cad_PorFecha";

          //  taCaducidad = Ds.Tables["CONTROL_CADUCIDADES"];

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                    cmd.CommandType = CommandType.StoredProcedure;

                    OracleParameter fecha_i = new OracleParameter("fechaini", OracleDbType.Varchar2);
                    fecha_i.Value = fechaI;
                    cmd.Parameters.Add(fecha_i);


                    OracleParameter Articulos = new OracleParameter("caducidades", OracleDbType.RefCursor);
                    Articulos.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(Articulos);

                    //
                    cmd.Connection.Open();
                    //OracleDataAdapter da = new OracleDataAdapter(cmd);

                    //da.Fill(Ds, "CONTROL_CADUCIDADES");
                    cmd.ExecuteReader();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                        {
                        while (oreader.Read())
                            {
                            DataRow row = taCaducidad.NewRow();
                            row["lote"] = oreader["NO_LOTE"];
                            //Ds.Tables["CONTROL_CADUCIDADES"];

                            DateTime dt = DateTime.ParseExact(oreader["Caducidad"].ToString(), "dd/MM/yyyy",
                                 System.Globalization.CultureInfo.InvariantCulture);
                            dt.ToString("dd/MM/yyyy");
                            row["caducidad"] = dt;
                            row["cantidad"] = oreader["Cantidad"];
                            row["DOCUMENTO"] = oreader["Folio"];
                            row["tipo_mov_inv"] = oreader["tipo_mov_inv"];
                            taCaducidad.Rows.Add(row);
                            }
                        //Ds.Tables.Add(taCaducidad);
                        }

                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

                    
            }

            return taCaducidad;
            }
       
        public static DataSet getKardexCad(string Ini, string Fin, String Articulo_ID, string tipoMM,string proveedor)
        {
            ///<sumary>
            ///obtiene el Kardex mas las caducidades registradas  JMQC 26/04/2018
            ///</sumary>
            DataSet ds = new DataSet("DSKardex");
            try
            {

                ds.Tables.Add("KARDEXN");
                string sentencia = "SELECT * ";
                sentencia += " FROM INV_KARDEX";
                sentencia += " WHERE INV_KARDEX.FECHA BETWEEN TO_DATE('" + Ini + "', 'DD/MM/YYYY HH24:MI:SS') AND TO_DATE('" + Fin + "', 'DD/MM/YYYY HH24:MI:SS')            ";
                sentencia += " AND usuario_id > 0";
                sentencia += " AND ARTICULO_ID like '" + Articulo_ID + "'";
                sentencia += " AND TIPO_MOVIMIENTO LIKE '" + tipoMM  + proveedor + "'" ;
                sentencia += " ORDER BY KARDEX_ID"; //sucursal_id = :SucursalId AND
                

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {

                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        OracleParameter pPedido = cmd.Parameters.Add("Hdr", OracleDbType.RefCursor, ParameterDirection.Output);
                        cmd.Connection.Open();
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(ds, "KARDEXN");
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }

                ds.Tables.Add("CADUCIDADES");
                //PIT 14/02/2022 SE MUESTRAN LAS CADUCIDADES DE LA TABLA recepcion_compradet_caducidad EN LUGAR DE MV_control_caducidades_listagg
                string sentenciaDetalles = "select " +
                    "LOTE_INTERNO ULT_LOTE_INTERNO,LOTE,CADUCIDAD,CANTIDAD, USUARIO_ID" +
                    " from recepcion_compradet_caducidad where articulo_id like '" + Articulo_ID + "' "; //sucursal_id = :sucursalId AND

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {

                    using (OracleCommand cmd= new OracleCommand(sentenciaDetalles, cnx))
                    {
                        cmd.Connection.Open();
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(ds, "CADUCIDADES");

                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
                return ds;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
                return ds;
            }
        }


    }
}
