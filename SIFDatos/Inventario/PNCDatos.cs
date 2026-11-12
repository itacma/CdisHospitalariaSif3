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
    public class PNCDatos
    {
        public static SIFModelo.Inventarios.InventarioDataSet GetPncs(String Folio, SIFModelo.Sucursal sucursal,string btn=null)
        {
            return GetPncs(DateTime.Today.ToString(),DateTime.Today.ToString(), "", Folio,btn);
        }

        public static SIFModelo.Inventarios.InventarioDataSet GetPncs(string Ini, string Fin, String Activo, String Folio,string btn=null)
        {
            SIFModelo.Inventarios.InventarioDataSet DsPnc = new SIFModelo.Inventarios.InventarioDataSet();

            Cursor.Current = Cursors.WaitCursor;

            //   int nRow = 1, ind = 0;

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();

                if (Folio !="")
                {
                    cmd.CommandText = "SELECT FOLIO, LOTE, SUCURSAL_ID, TO_CHAR(FECHA_REG, 'DD/MM/YYYY HH24:MI:SS') FECHA_REG, " +
                                      "TOTAL, NVL(TO_CHAR(FECHA_CAN, 'DD/MM/YYYY HH24:MI:SS'), ' ') FECHA_CAN, DOC_REFERENCIA, " +
                                      "USUARIO_ID, E.NOMBRE ACTIVO from pnc, " +
                                      "(select * from cat_estatus_table_farmacia WHERE table_name='PRODUCTO_NO_CONFORME' AND ACTIVO='S') E " +
                                      "where PNC.ACTIVO = E.CVE AND Folio like  nvl('%" + Folio + "%',0)";// AND TRUNC(FECHA_REG) between TO_DATE('" + Ini.Substring(0, 10) + "','DD/MM/RRRR') AND TO_DATE('" + Fin.Substring(0, 10) + "','DD/MM/RRRR')";
                }
                else
                {
                    cmd.CommandText = "SELECT FOLIO, LOTE, SUCURSAL_ID, TO_CHAR(FECHA_REG, 'DD/MM/YYYY HH24:MI:SS') FECHA_REG, " +
                                      "TOTAL, NVL(TO_CHAR(FECHA_CAN, 'DD/MM/YYYY HH24:MI:SS'), ' ') FECHA_CAN, DOC_REFERENCIA, " +
                                      "USUARIO_ID, E.NOMBRE ACTIVO from pnc, " +
                                      "(select * from cat_estatus_table_farmacia WHERE table_name='PRODUCTO_NO_CONFORME' AND ACTIVO='S') E " +
                                      "where PNC.ACTIVO = E.CVE AND Folio like  nvl('%" + Folio + "%',0) AND TRUNC(FECHA_REG) between TO_DATE('" + Ini.Substring(0,10)+ "','DD/MM/RRRR') AND TO_DATE('" + Fin.Substring(0,10)+ "','DD/MM/RRRR')";

                    //cmd.BindByName = true;
                }

                OracleDataReader _rdrObj = cmd.ExecuteReader();
                //Grd_Pedido.Rows.Add(_rdrObj.RecordsAffected);

                while (_rdrObj.Read())
                {
                    SIFModelo.Inventarios.InventarioDataSet.PNCRow rw = DsPnc.PNC.NewPNCRow();
                    rw.FOLIO = _rdrObj.GetString(_rdrObj.GetOrdinal("FOLIO"));
                    rw.LOTE = _rdrObj.GetInt16(_rdrObj.GetOrdinal("LOTE")).ToString();
                    rw.SUCURSAL_ID = _rdrObj.GetInt16(_rdrObj.GetOrdinal("SUCURSAL_ID")).ToString();
                    rw.FECHA_REG = _rdrObj.GetString(_rdrObj.GetOrdinal("FECHA_REG"));
                    rw.TOTAL = _rdrObj.GetInt32(_rdrObj.GetOrdinal("TOTAL")).ToString();
                    rw.FECHA_CAN = _rdrObj.GetString(_rdrObj.GetOrdinal("FECHA_CAN"));
                    rw.DOC_REFERENCIA = _rdrObj.GetString(_rdrObj.GetOrdinal("DOC_REFERENCIA"));
                    rw.USUARIO_ID = _rdrObj.GetString(_rdrObj.GetOrdinal("USUARIO_ID"));
                    rw.ACTIVO = _rdrObj.GetString(_rdrObj.GetOrdinal("ACTIVO"));

                    if (Activo == "" || Activo == rw.ACTIVO)
                    //if (Activo == "" || rw.ACTIVO == "ABIERTO" || rw.ACTIVO == "CANCELADO" || rw.ACTIVO == "CERRADO")
                        DsPnc.PNC.AddPNCRow(rw);

                    OracleCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandText = "PKG_PRODUCTO_NO_CONFORME.SP_GET_PNC_DET";
                    cmd1.BindByName = true;

                    // OUT REF CURSOR bound
                    OracleParameter pPedido1 = cmd1.Parameters.Add("Det", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd1.Parameters.Add("NoFolio", OracleDbType.Varchar2, _rdrObj.GetString(_rdrObj.GetOrdinal("FOLIO")), ParameterDirection.Input);
                    cmd1.Parameters.Add("NoLote", OracleDbType.Decimal, _rdrObj.GetInt16(_rdrObj.GetOrdinal("LOTE")), ParameterDirection.Input);

                    OracleDataReader _rdrObj1 = cmd1.ExecuteReader();

                    if (_rdrObj1.HasRows)
                    {

                        while (_rdrObj1.Read())
                        {
                            string pfolio = _rdrObj.GetString(_rdrObj.GetOrdinal("FOLIO"));
                            string plote = _rdrObj1.GetInt16(_rdrObj1.GetOrdinal("LOTE")).ToString();
                            string psucursal = _rdrObj1.GetOrdinal("SUCURSAL_ID").ToString();
                            string ppartida = _rdrObj1.GetInt32(_rdrObj1.GetOrdinal("PARTIDA")).ToString();
                            string particulo = _rdrObj1.GetString(_rdrObj1.GetOrdinal("ARTICULO_ID"));
                            string pnombre = _rdrObj1.GetString(_rdrObj1.GetOrdinal("NOMBRE1"));
                            string pcantidad = _rdrObj1.GetInt32(_rdrObj1.GetOrdinal("CANTIDAD")).ToString();
                            string pprecio = _rdrObj1.GetDouble(_rdrObj1.GetOrdinal("PRECIO_COSTO")).ToString();
                            string pconcepto = _rdrObj1.GetString(_rdrObj1.GetOrdinal("CONCEPTO_DETALLE"));

                            DsPnc.PNC_DET.AddPNC_DETRow(pfolio,plote,psucursal,ppartida,particulo,pnombre,pcantidad,pprecio,pconcepto);
                        }
                    }
                    _rdrObj1.Close();
                    _rdrObj1.Dispose();

                }

                _rdrObj.Close();
                _rdrObj.Dispose();

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Producto No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            return DsPnc;

        }

        public static void InsInvAjuste(int[] Lote, int[] Partida, String[] ArtId, String[] Nombre,
                               int[] Cant, double[] Costo, String[] Concepto, SIFModelo.Usuario usuario, int Total)
        {
            string ProductName = "Producto No Conforme";

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PRODUCTO_NO_CONFORME.SP_NUEVO_PNC";
                cmd.BindByName = true;

                // Input Array Lote
                OracleParameter InLote = cmd.Parameters.Add("Lote", OracleDbType.Decimal);
                InLote.Direction = ParameterDirection.Input;
                InLote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InLote.Value = Lote;

                // Input Array Partida
                OracleParameter InSec = cmd.Parameters.Add("Partida", OracleDbType.Decimal);
                InSec.Direction = ParameterDirection.Input;
                InSec.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InSec.Value = Partida;

                // IN Array ID's
                OracleParameter InArtId = cmd.Parameters.Add("ArtId", OracleDbType.Varchar2);
                InArtId.Direction = ParameterDirection.Input;
                InArtId.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InArtId.Value = ArtId;

                // IN Array Articulos
                OracleParameter InNombre = cmd.Parameters.Add("Nombre", OracleDbType.Varchar2);
                InNombre.Direction = ParameterDirection.Input;
                InNombre.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InNombre.Value = Nombre;

                // IN Array Cantidad
                OracleParameter InCant = cmd.Parameters.Add("Cant", OracleDbType.Decimal);
                InCant.Direction = ParameterDirection.Input;
                InCant.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCant.Value = Cant;

                // IN Array Precio
                OracleParameter InPrecio = cmd.Parameters.Add("Costo", OracleDbType.Double);
                InPrecio.Direction = ParameterDirection.Input;
                InPrecio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecio.Value = Costo;

                // IN Array Concepto
                OracleParameter InConcep = cmd.Parameters.Add("Concepto", OracleDbType.Varchar2);
                InConcep.Direction = ParameterDirection.Input;
                InConcep.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InConcep.Value = Concepto;

                cmd.Parameters.Add("Usuario", OracleDbType.Varchar2, usuario.UsuariosID, ParameterDirection.Input);

                cmd.Parameters.Add("Total", OracleDbType.Decimal, Total, ParameterDirection.Input);

                // OUT parameter
                OracleParameter pPedido =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);              

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pPedido.Value.ToString()))
                {
                   MessageBox.Show("Se creo el movimiento con el folio " + pPedido.Value.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al crear el movimiento: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static void UpdInvAjuste(String Folio, int Lote, int[] Partida, String[] ArtId, String[] Nombre,
                               String Concepto, int[] Cant, double[] Costo, SIFModelo.Usuario usuario, int Total)
        {
            string ProductName = "Producto No Conforme";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PRODUCTO_NO_CONFORME.SP_EDITAR_PNC";
                cmd.BindByName = true;

                cmd.Parameters.Add("Folio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);

                cmd.Parameters.Add("Lote", OracleDbType.Int16, Lote, ParameterDirection.Input);

                // Input Array Partida
                OracleParameter InSec = cmd.Parameters.Add("Partida", OracleDbType.Decimal);
                InSec.Direction = ParameterDirection.Input;
                InSec.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InSec.Value = Partida;

                // IN Array ID's
                OracleParameter InArtId = cmd.Parameters.Add("ArtId", OracleDbType.Varchar2);
                InArtId.Direction = ParameterDirection.Input;
                InArtId.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InArtId.Value = ArtId;

                // IN Array Articulos
                OracleParameter InNombre = cmd.Parameters.Add("Nombre", OracleDbType.Varchar2);
                InNombre.Direction = ParameterDirection.Input;
                InNombre.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InNombre.Value = Nombre;

                // IN Array Cantidad
                OracleParameter InCant = cmd.Parameters.Add("Cant", OracleDbType.Decimal);
                InCant.Direction = ParameterDirection.Input;
                InCant.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCant.Value = Cant;

                // IN Array Precio
                OracleParameter InPrecio = cmd.Parameters.Add("Costo", OracleDbType.Double);
                InPrecio.Direction = ParameterDirection.Input;
                InPrecio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecio.Value = Costo;

                cmd.Parameters.Add("Concepto", OracleDbType.Varchar2, Concepto, ParameterDirection.Input);

                cmd.Parameters.Add("Usuario", OracleDbType.Varchar2, usuario.UsuariosID, ParameterDirection.Input);

                cmd.Parameters.Add("Total", OracleDbType.Int16, Total, ParameterDirection.Input);

                // OUT parameter
                OracleParameter pPedido =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pPedido.Value.ToString()))
                {
                    if (Convert.ToDecimal(pPedido.Value.ToString()) > 0)
                       MessageBox.Show("Se actualizó el folio: " + pPedido.Value.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al actualizar el folio: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static DataTable GetLotesCaducidades(string documento)
        {
            DataTable tableCaducidades = new DataTable("CaducidadesSku");
            tableCaducidades.Columns.Add("DOCUMENTO", typeof(String));
            tableCaducidades.Columns.Add("ARTICULO_ID", typeof(String));
            tableCaducidades.Columns.Add("NOMBRE", typeof(String));
            tableCaducidades.Columns.Add("CANTIDAD", typeof(Int32));
            tableCaducidades.Columns.Add("NO_LOTE", typeof(String));
            tableCaducidades.Columns.Add("CADUCIDAD", typeof(DateTime));
            tableCaducidades.Columns.Add("LOTE_INTERNO", typeof(String));

            List<SIFModelo.Inventarios.SkuCaducidad> Lista = new List<SIFModelo.Inventarios.SkuCaducidad>();

            string sentencia = "PKG_PRODUCTO_NO_CONFORME.SP_GET_LOTES_CADUCIDADES";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter Pe_documento = new OracleParameter("pe_documento", OracleDbType.Varchar2);
                    Pe_documento.Value = documento;
                    cmd.Parameters.Add(Pe_documento);

                    OracleParameter requisiciones = new OracleParameter("outcursor", OracleDbType.RefCursor);
                    requisiciones.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(requisiciones);

                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteReader();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                //DataRow row = tableCaducidades.NewRow();
                                DataRow sku = tableCaducidades.NewRow();
                                //row["FOLIO_OC_ID"] = oreader["FOLIO_OC_ID"];
                                sku["DOCUMENTO"] = oreader["DOCUMENTO"].ToString();
                                sku["ARTICULO_ID"] = oreader["ARTICULO_ID"].ToString();
                                sku["NOMBRE"] = oreader["NOMBRE"].ToString();
                                sku["CANTIDAD"] = int.Parse(oreader["CANTIDAD"].ToString());
                                sku["NO_LOTE"] = oreader["LOTE"].ToString();
                                DateTime dateValue;

                                if (oreader["CADUCIDAD"].ToString().IsDatetime())
                                    sku["CADUCIDAD"] = Convert.ToDateTime(oreader["CADUCIDAD"].ToString());
                                else
                                {
                                    sku["CADUCIDAD"] = Convert.ToDateTime("01/01/2001");

                                   MessageBox.Show("Error no se puede encontrar caducidad para el artículo" +
                                        Environment.NewLine + "Para el artículo " + oreader["ARTICULO_ID"].ToString(), "Producto No Conforme", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

                                }
                                sku["LOTE_INTERNO"] = oreader["LOTE_INTERNO"].ToString();

                                tableCaducidades.Rows.Add(sku);
                            }
                        }
                    }
                    catch (Exception e)
                    {

                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                        //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            return tableCaducidades;
        }

        public static DataTable sp_GetDataSeleccionSalidasDatos(string documento, int lote_documento)
        {
            DataTable tableCaducidades = new DataTable("CaducidadesSku");
            tableCaducidades.Columns.Add("DOCUMENTO", typeof(String));
            tableCaducidades.Columns.Add("ARTICULO_ID", typeof(String));
            tableCaducidades.Columns.Add("NOMBRE", typeof(String));
            tableCaducidades.Columns.Add("CANTIDAD_LOTE", typeof(Int32));
            tableCaducidades.Columns.Add("CANTIDAD_DISPONIBLE", typeof(Int32));
            tableCaducidades.Columns.Add("NO_LOTE", typeof(String));
            tableCaducidades.Columns.Add("CADUCIDAD", typeof(DateTime));
            tableCaducidades.Columns.Add("LOTE_INTERNO", typeof(String));

            List<SIFModelo.Inventarios.SkuCaducidad> Lista = new List<SIFModelo.Inventarios.SkuCaducidad>();

            string sentencia = "PKG_PRODUCTO_NO_CONFORME.SP_GET_CAD_EXISTENTES";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter Pe_documento = new OracleParameter("pe_documento", OracleDbType.Varchar2);
                    Pe_documento.Value = documento;
                    cmd.Parameters.Add(Pe_documento);

                    OracleParameter Pe_lote_documento = new OracleParameter("pe_lote_documento", OracleDbType.Int16);
                    Pe_lote_documento.Value = lote_documento;
                    cmd.Parameters.Add(Pe_lote_documento);

                    OracleParameter requiciciones = new OracleParameter("outcursor", OracleDbType.RefCursor);
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
                                DataRow sku = tableCaducidades.NewRow();
                                sku["DOCUMENTO"] = oreader["DOCUMENTO"].ToString();
                                sku["ARTICULO_ID"] = oreader["ARTICULO_ID"].ToString();
                                sku["NOMBRE"] = oreader["NOMBRE"].ToString();
                                sku["CANTIDAD_LOTE"] = int.Parse(oreader["CANTIDAD_LOTE"].ToString());
                                sku["CANTIDAD_DISPONIBLE"] = int.Parse(oreader["CANTIDAD_DISPONIBLE"].ToString());
                                sku["NO_LOTE"] = oreader["LOTE"].ToString();

                                if (oreader["CADUCIDAD"].ToString().IsDatetime())
                                    sku["CADUCIDAD"] = Convert.ToDateTime(oreader["CADUCIDAD"].ToString());
                                else
                                {

                                    sku["CADUCIDAD"] = Convert.ToDateTime("01/01/2001");

                                   MessageBox.Show("Error no se puede encontrar caducidad para el artículo" +
                                        Environment.NewLine + "Para el artículo " + oreader["ARTICULO_ID"].ToString(), "Producto No Conforme", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

                                }
                                sku["LOTE_INTERNO"] = oreader["LOTE_INTERNO"].ToString();

                                tableCaducidades.Rows.Add(sku);
                            }
                        }
                    }
                    catch (Exception e)
                    {

                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                        //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            return tableCaducidades;
        }

        public static DataTable sp_GetDataDetalleMovimiento(string documento, int lote_documento)
        {
            DataTable tableDetalles = new DataTable("CaducidadesSku");
            tableDetalles.Columns.Add("DOCUMENTO", typeof(String));
            tableDetalles.Columns.Add("NO_LOTE", typeof(String));
            tableDetalles.Columns.Add("ARTICULO_ID", typeof(String));
            tableDetalles.Columns.Add("CANTIDAD", typeof(Int32));

            List<SIFModelo.Inventarios.SkuCaducidad> Lista = new List<SIFModelo.Inventarios.SkuCaducidad>();

            string sentencia = "PKG_PRODUCTO_NO_CONFORME.SP_GET_DETALLE_MOV";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter Pe_documento = new OracleParameter("pe_documento", OracleDbType.Varchar2);
                    Pe_documento.Value = documento;
                    cmd.Parameters.Add(Pe_documento);

                    OracleParameter Pe_lote_documento = new OracleParameter("pe_lote_documento", OracleDbType.Int16);
                    Pe_lote_documento.Value = lote_documento;
                    cmd.Parameters.Add(Pe_lote_documento);

                    OracleParameter requiciciones = new OracleParameter("outcursor", OracleDbType.RefCursor);
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
                                DataRow sku = tableDetalles.NewRow();
                                sku["DOCUMENTO"] = oreader["DOCUMENTO"].ToString();
                                sku["NO_LOTE"] = oreader["LOTE"].ToString();
                                sku["ARTICULO_ID"] = oreader["ARTICULO_ID"].ToString();
                                sku["CANTIDAD"] = int.Parse(oreader["CANTIDAD"].ToString());
                                tableDetalles.Rows.Add(sku);
                            }
                        }
                    }
                    catch (Exception e)
                    {

                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                    }

                }
            }

            return tableDetalles;
        }

        public static Decimal sp_GuardadCaducidadesdeMovSalida(string pFoliocompra, int lote_documento, string pUsuario_id,
            List<Int16> L_partida, List<string> L_articulo_id, List<string> L_Lote_Interno, List<Int16> L_cant_lote,
            List<string> L_lote, List<string> L_loteProdcesado, List<string> L_caducidad, out string Respuesta)
        {
            ///<summary>
            ///Guardamos las caducidades Capturadas en el modulo de captura de caducidades
            /// 
            /// </summary>
            try
            {
                List<SIFModelo.Inventarios.SkuCaducidad> Lista = new List<SIFModelo.Inventarios.SkuCaducidad>();

                string sentencia = "PKG_PRODUCTO_NO_CONFORME.SP_SET_LOTE_CADUCIDAD";

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cnx.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("P_documento", OracleDbType.Varchar2, pFoliocompra, ParameterDirection.Input);
                        cmd.Parameters.Add("P_USUARIO_ID", OracleDbType.Varchar2, pUsuario_id, ParameterDirection.Input);
                        cmd.Parameters.Add("p_lote_documento", OracleDbType.Int16, lote_documento, ParameterDirection.Input);

                        OracleParameter pPartida = cmd.Parameters.Add("P_NUM_PARTIDA", OracleDbType.Decimal);
                        pPartida.Direction = ParameterDirection.Input;
                        pPartida.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        pPartida.Value = L_partida.ToArray();

                        OracleParameter pArticulo_id = cmd.Parameters.Add("p_Articulo_id", OracleDbType.Varchar2);
                        pArticulo_id.Direction = ParameterDirection.Input;
                        pArticulo_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        pArticulo_id.Value = L_articulo_id.ToArray();

                        OracleParameter pLote_Interno = cmd.Parameters.Add("P_LOTE_INTERNO", OracleDbType.Varchar2);
                        pLote_Interno.Direction = ParameterDirection.Input;
                        pLote_Interno.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        pLote_Interno.Value = L_Lote_Interno.ToArray();

                        OracleParameter plote = cmd.Parameters.Add("P_LOTE", OracleDbType.Varchar2);
                        plote.Direction = ParameterDirection.Input;
                        plote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        plote.Value = L_lote.ToArray();

                        OracleParameter pcaducidad = cmd.Parameters.Add("p_caducidad", OracleDbType.Varchar2);
                        pcaducidad.Direction = ParameterDirection.Input;
                        pcaducidad.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        pcaducidad.Value = L_caducidad.ToArray();

                        OracleParameter pLoteProcesado = cmd.Parameters.Add("P_PROCESADO", OracleDbType.Varchar2);
                        pLoteProcesado.Direction = ParameterDirection.Input;
                        pLoteProcesado.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        pLoteProcesado.Value = L_loteProdcesado.ToArray();

                        OracleParameter pcant_lote = cmd.Parameters.Add("P_CANTIDAD", OracleDbType.Decimal);
                        pcant_lote.Direction = ParameterDirection.Input;
                        pcant_lote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        pcant_lote.Value = L_cant_lote.ToArray();

                        // OUT parameter
                        OracleParameter pInsCaducidad = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                        OracleParameter pInsCaducidadRespuesta = cmd.Parameters.Add("OutParamv", OracleDbType.Varchar2, ParameterDirection.Output);
                        pInsCaducidadRespuesta.Size = 300;

                        // Execute the command
                        cmd.ExecuteNonQuery();

                        if (!string.IsNullOrEmpty(pInsCaducidad.Value.ToString()))
                        {
                           MessageBox.Show("Se asignaron lotes y caducidades al folio: " + pFoliocompra, "Producto No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Respuesta = pInsCaducidadRespuesta.Value.ToString();
                            return Decimal.Parse(pInsCaducidad.Value.ToString());
                        }
                        else
                        {
                            Respuesta = pInsCaducidadRespuesta.Value.ToString();
                            return -1;
                        }

                    }
                }
            }
            catch (Exception _x)
            {
                Respuesta = _x.ToString();
                return -999;
            }

        }

        public static Decimal EliminarCaducidades(string pFoliocompra, int lote_documento, string pUsuario_id, out string Respuesta)
        {
            ///<summary>
            ///Guardamos las caducidades Capturadas en el modulo de captura de caducidades
            /// 
            /// </summary>
            try
            {
                List<SIFModelo.Inventarios.SkuCaducidad> Lista = new List<SIFModelo.Inventarios.SkuCaducidad>();

                string sentencia = "PKG_PRODUCTO_NO_CONFORME.SP_ELIMINA_LOTE_CADUCIDAD";

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cnx.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("P_documento", OracleDbType.Varchar2, pFoliocompra, ParameterDirection.Input);
                        cmd.Parameters.Add("P_USUARIO_ID", OracleDbType.Varchar2, pUsuario_id, ParameterDirection.Input);
                        cmd.Parameters.Add("p_lote_documento", OracleDbType.Int16, lote_documento, ParameterDirection.Input);

                        // OUT parameter
                        OracleParameter pInsCaducidad = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                        OracleParameter pInsCaducidadRespuesta = cmd.Parameters.Add("OutParamv", OracleDbType.Varchar2, ParameterDirection.Output);
                        pInsCaducidadRespuesta.Size = 300;

                        // Execute the command
                        cmd.ExecuteNonQuery();

                        if (!string.IsNullOrEmpty(pInsCaducidad.Value.ToString()))
                        {
                           MessageBox.Show("Se eliminaron lotes y caducidades del folio: " + pFoliocompra, "Producto No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Respuesta = pInsCaducidadRespuesta.Value.ToString();
                            return Decimal.Parse(pInsCaducidad.Value.ToString());
                        }
                        else
                        {
                            Respuesta = pInsCaducidadRespuesta.Value.ToString();
                            return -1;
                        }

                    }
                }
            }
            catch (Exception _x)
            {
                Respuesta = _x.ToString();
                return -999;
            }

        }

        public static string VerificarProcesados(string Folio, string lote)
        {
            //List<SIFModelo.BonificacionDet_Caducidad> articulos = new List<SIFModelo.BonificacionDet_Caducidad>();
            //SIFModelo.BonificacionDet_Caducidad det = new SIFModelo.BonificacionDet_Caducidad();
            string sentencia = "PKG_PRODUCTO_NO_CONFORME.SP_VERIFICA_LOT_CAD";
            string RESPUESTA;

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("v_folio", OracleDbType.Varchar2, 15, Folio, ParameterDirection.Input);
                    cmd.Parameters.Add("v_lote", OracleDbType.Varchar2, 15, lote, ParameterDirection.Input);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("resultado", OracleDbType.Varchar2, 250);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        return RESPUESTA = outparam.Value.ToString();

                    }
                    catch (Exception ex)
                    {

                        return ex.ToString();
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                        //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            //return RESPUESTA;
        }

        public static string Cierre(string Folio, int lote, int sucursal, string usuario)
        {
            //List<SIFModelo.BonificacionDet_Caducidad> articulos = new List<SIFModelo.BonificacionDet_Caducidad>();
            //SIFModelo.BonificacionDet_Caducidad det = new SIFModelo.BonificacionDet_Caducidad();
            string sentencia = "PKG_PRODUCTO_NO_CONFORME.SP_PNC_CIERRE";
            string RESPUESTA;

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nofolio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                    cmd.Parameters.Add("nolote", OracleDbType.Int32, lote, ParameterDirection.Input);
                    cmd.Parameters.Add("sucursal", OracleDbType.Int32, sucursal, ParameterDirection.Input);
                    cmd.Parameters.Add("usuario", OracleDbType.Varchar2, usuario, ParameterDirection.Input);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Varchar2, 250);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        return RESPUESTA = outparam.Value.ToString();

                    }
                    catch (Exception ex)
                    {

                        return ex.ToString();
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                        //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            //return RESPUESTA;
        }

        public static string Cancela(string Folio, int lote, int sucursal, string usuario)
        {
            //List<SIFModelo.BonificacionDet_Caducidad> articulos = new List<SIFModelo.BonificacionDet_Caducidad>();
            //SIFModelo.BonificacionDet_Caducidad det = new SIFModelo.BonificacionDet_Caducidad();
            string sentencia = "PKG_PRODUCTO_NO_CONFORME.SP_CANCELA_PNC";
            string RESPUESTA;

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nofolio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                    cmd.Parameters.Add("nolote", OracleDbType.Int32, lote, ParameterDirection.Input);
                    cmd.Parameters.Add("sucursal", OracleDbType.Int32, sucursal, ParameterDirection.Input);
                    cmd.Parameters.Add("usuario", OracleDbType.Varchar2, usuario, ParameterDirection.Input);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Varchar2, 250);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        return RESPUESTA = outparam.Value.ToString();

                    }
                    catch (Exception ex)
                    {

                        return ex.ToString();
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                        //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            //return RESPUESTA;
        }

        public static string CancelaAbiertos(string Folio, int lote, int sucursal, string usuario)
        {
            //List<SIFModelo.BonificacionDet_Caducidad> articulos = new List<SIFModelo.BonificacionDet_Caducidad>();
            //SIFModelo.BonificacionDet_Caducidad det = new SIFModelo.BonificacionDet_Caducidad();
            string sentencia = "PKG_PRODUCTO_NO_CONFORME.SP_CANCELA_ABIERTOS";
            string RESPUESTA;

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nofolio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                    cmd.Parameters.Add("nolote", OracleDbType.Int32, lote, ParameterDirection.Input);
                    cmd.Parameters.Add("sucursal", OracleDbType.Int32, sucursal, ParameterDirection.Input);
                    cmd.Parameters.Add("usuario", OracleDbType.Varchar2, usuario, ParameterDirection.Input);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Varchar2, 250);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        return RESPUESTA = outparam.Value.ToString();

                    }
                    catch (Exception ex)
                    {

                        return ex.ToString();
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                        //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            //return RESPUESTA;
        }

        public static string Edita(string Folio, int lote, int sucursal, string usuario)
        {
            //List<SIFModelo.BonificacionDet_Caducidad> articulos = new List<SIFModelo.BonificacionDet_Caducidad>();
            //SIFModelo.BonificacionDet_Caducidad det = new SIFModelo.BonificacionDet_Caducidad();
            string sentencia = "PKG_PRODUCTO_NO_CONFORME.SP_EDITA_PNC";
            string RESPUESTA;

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nofolio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                    cmd.Parameters.Add("nolote", OracleDbType.Int32, lote, ParameterDirection.Input);
                    cmd.Parameters.Add("sucursal", OracleDbType.Int32, sucursal, ParameterDirection.Input);
                    cmd.Parameters.Add("usuario", OracleDbType.Varchar2, usuario, ParameterDirection.Input);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Varchar2, 250);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        return RESPUESTA = outparam.Value.ToString();

                    }
                    catch (Exception ex)
                    {

                        return ex.ToString();
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                        //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            //return RESPUESTA;
        }





    }
}
