using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using DevComponents.DotNetBar;
using System.ComponentModel;
using System.Windows.Forms;

namespace SIFDatos
    {
    public class caducidades
        {


        #region Control de caducidades Version 1.1 -1.2
        public static int insCaducidades(string referencia, string articuloId,
                              int[] partida, String[] lote,
                              String[] caducidades, int[] Cant,  string tipo, string usuario
                              )
            {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());            
            try
                {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_CADUCIDADES.sp_ins_caducidades"; 
                cmd.BindByName = true;

                cmd.Parameters.Add("Referencia", OracleDbType.Varchar2, referencia, ParameterDirection.Input);
                cmd.Parameters.Add("ArtId", OracleDbType.Varchar2, articuloId, ParameterDirection.Input);
                cmd.Parameters.Add("tipo_mov_inv", OracleDbType.Varchar2, tipo, ParameterDirection.Input);
                cmd.Parameters.Add("Usuario", OracleDbType.Varchar2,usuario, ParameterDirection.Input);


                OracleParameter InPartida = cmd.Parameters.Add("Partida", OracleDbType.Decimal);
                InPartida.Direction = ParameterDirection.Input;
                InPartida.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPartida.Value = partida;               
                
               
                OracleParameter InLote = cmd.Parameters.Add("Lote", OracleDbType.Varchar2);
                InLote.Direction = ParameterDirection.Input;
                InLote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InLote.Value = lote;

                OracleParameter InCaducidad = cmd.Parameters.Add("Caducidad", OracleDbType.Varchar2);
                InCaducidad.Direction = ParameterDirection.Input;
                InCaducidad.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCaducidad.Value = caducidades;

                OracleParameter InCant = cmd.Parameters.Add("Cant", OracleDbType.Decimal);
                InCant.Direction = ParameterDirection.Input;
                InCant.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCant.Value = Cant;
                
                


  
                // OUT parameter
                OracleParameter pTraspaso =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pTraspaso.Value.ToString()))
                    {
                    return int.Parse(pTraspaso.Value.ToString());
                    }
                else 
                    {
                    return -1;
                    }

                }
            catch (Exception ex)
                {
                
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
            return 0;
            }

        public static int delCaducidades(string articulo, string refe
                        )
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_CADUCIDADES.sp_del_caducidades";
                cmd.BindByName = true;

                cmd.Parameters.Add("Referencia", OracleDbType.Varchar2, refe, ParameterDirection.Input);
                cmd.Parameters.Add("ArtId", OracleDbType.Varchar2, articulo, ParameterDirection.Input);

                // OUT parameter
                OracleParameter pTraspaso =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pTraspaso.Value.ToString()))
                {
                    return int.Parse(pTraspaso.Value.ToString());
                }
                else
                {
                    return -1;
                }

            }
            catch (Exception ex)
            {

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
            return 0;
        }


        public static DataTable sp_Get_Art_cad_porFolio(string referencia , string articulo)
            {
            DataTable taCaducidad = new DataTable("taCaducidades");
            taCaducidad.Columns.Add("lote", typeof(string));
            taCaducidad.Columns.Add("caducidad", typeof(DateTime));
            taCaducidad.Columns.Add("cantidad", typeof(int)) ;
            taCaducidad.Columns.Add("referencia",typeof(String));
            taCaducidad.Columns.Add("tipo_mov_inv" ,typeof(string));

            string sentencia = "PKG_CADUCIDADES.sp_Get_Art_Cad_PorFolio";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                    cmd.CommandType = CommandType.StoredProcedure;

                    OracleParameter reff = new OracleParameter("referencia", OracleDbType.Varchar2);
                    reff.Value = referencia;
                    cmd.Parameters.Add(reff);

                    OracleParameter Art = new OracleParameter("articulo", OracleDbType.Varchar2);
                    Art.Value = articulo;
                    cmd.Parameters.Add(Art);

                    OracleParameter Articulos = new OracleParameter("caducidades", OracleDbType.RefCursor);
                    Articulos.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(Articulos);

                    //
                    cmd.Connection.Open();
                    cmd.ExecuteReader();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                        {
                        while (oreader.Read())
                            {
                            DataRow row = taCaducidad.NewRow();
                            row["lote"] = oreader["No_Lote"];                          
                            DateTime dt = DateTime.ParseExact(oreader["Caducidad"].ToString(), "dd/MM/yyyy",
                                 System.Globalization.CultureInfo.InvariantCulture);
                            dt.ToString("dd/MM/yyyy");
                            row["caducidad"] = dt;
                            row["cantidad"] = oreader["Cantidad"];
                            row["referencia"] = oreader["Folio"];
                            row["tipo_mov_inv"] = oreader["tipo_mov_inv"];
                            taCaducidad.Rows.Add(row);
                            }
                        }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }
                
            }

            return taCaducidad;
            }

        public static DataTable sp_GetDataRequisiciones(string nfolioOc)
            {
            DataTable tableCaducidades = new DataTable("CaducidadesTa");

            //Folio_Oc_Id
            tableCaducidades.Columns.Add("FOLIO_OC_ID", typeof(String));
            tableCaducidades.Columns.Add("FOLIO_COMPRA", typeof(String));
            tableCaducidades.Columns.Add("ARTICULO_ID", typeof(String));
            tableCaducidades.Columns.Add("NOMBRE", typeof(String));
            tableCaducidades.Columns.Add("CANT_RECIBIDA", typeof(Int32));
            tableCaducidades.Columns.Add("CANT_LOTE", typeof(Int32));
            tableCaducidades.Columns.Add("NO_LOTE", typeof(String));
            tableCaducidades.Columns.Add("CADUCIDAD", typeof(DateTime));
            /*tableCaducidades.Columns.Add("NUM_LOTE");
            tableCaducidades.Columns.Add("CADUCIDAD");*/


            string sentencia = "Pkg_Caducidades.sp_get_caducidades";
            //string sentencia = "Pkg_Caducidades_v2.sp_get_caducidades";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {

                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter folioOc = new OracleParameter("ncaducidadOc", OracleDbType.Varchar2);
                    folioOc.Value = nfolioOc;
                    cmd.Parameters.Add(folioOc);

                    OracleParameter requiciciones = new OracleParameter("ncoc", OracleDbType.RefCursor);
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
                                DataRow row = tableCaducidades.NewRow();
                                row["FOLIO_OC_ID"] = oreader["FOLIO_OC_ID"];
                                row["FOLIO_COMPRA"] = oreader["FOLIO_COMPRA"];
                                row["ARTICULO_ID"] = oreader["ARTICULO_ID"];
                                row["NOMBRE"] = oreader["NOMBRE"];
                                row["CANT_RECIBIDA"] = oreader["CANT_RECIBIDA"];
                                row["CANT_LOTE"] = oreader["CANT_LOTE"];
                                row["NO_LOTE"] = oreader["NO_LOTE"];
                                string s = oreader["NO_LOTE"].ToString();
                                if (!string.IsNullOrEmpty(s))
                                    if (s != "....")
                                        row["CADUCIDAD"] = oreader["CADUCIDAD"];
                                tableCaducidades.Rows.Add(row);
                            }
                        }
                    }
                    catch (Exception e)
                    {

                    }
                    finally {

                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                    }
                }

            return tableCaducidades;
            }

        public static int insCaducidades_bulk(string referencia , string tipoMov, string usuario, List<SIFModelo.modeloCaducidades> listCaducidades)
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_CADUCIDADES.sp_ins_caducidades";
                cmd.BindByName = true;
                cmd.Parameters.Add("Referencia", OracleDbType.Varchar2, referencia, ParameterDirection.Input);
                cmd.Parameters.Add("Tipo_Mov_Inv", OracleDbType.Varchar2, tipoMov, ParameterDirection.Input);
                cmd.Parameters.Add("Usuario", OracleDbType.Varchar2,usuario, ParameterDirection.Input);


                List<string> L_articulo_id = new List<string>();                
                List<Int32> L_cant_lote = new List<Int32>();
                List<string> L_lote= new List<string>();
                List<string> L_caducidad = new List<string>();


                foreach (SIFModelo.modeloCaducidades detalle in listCaducidades)
                {
                    L_articulo_id.Add(detalle.ARTICULO_ID);
                    L_cant_lote.Add(detalle.cantLote);
                    L_lote.Add(detalle.lote);
                    L_caducidad.Add(detalle.caducidad);
                }
                OracleParameter pArticulo_id = cmd.Parameters.Add("p_Articulo_id", OracleDbType.Varchar2);
                pArticulo_id.Direction = ParameterDirection.Input;
                pArticulo_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                pArticulo_id.Value = L_articulo_id.ToArray();

                OracleParameter pcant_lote = cmd.Parameters.Add("p_cant_lote", OracleDbType.Decimal);
                pcant_lote.Direction = ParameterDirection.Input;
                pcant_lote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                pcant_lote.Value = L_cant_lote.ToArray();

                OracleParameter plote = cmd.Parameters.Add("p_lote", OracleDbType.Varchar2);
                plote.Direction = ParameterDirection.Input;
                plote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                plote.Value = L_lote.ToArray();

                OracleParameter pcaducidad = cmd.Parameters.Add("p_caducidad", OracleDbType.Varchar2);
                pcaducidad.Direction = ParameterDirection.Input;
                pcaducidad.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                pcaducidad.Value = L_caducidad.ToArray();



                // OUT parameter
                OracleParameter pTraspaso =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pTraspaso.Value.ToString()))
                {
                    return int.Parse(pTraspaso.Value.ToString());
                }
                else
                {
                    return -1;
                }

            }
            catch (Exception ex)
            {

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
            return 0;
        }




        public static DataTable sp_GetDataCaducidadesMovimiento(string documento,  int id_movimiento )
        {
            DataTable tableCaducidades = new DataTable("CaducidadesTa");

            //Folio_Oc_Id
            tableCaducidades.Columns.Add("FOLIO_OC_ID", typeof(String));
            tableCaducidades.Columns.Add("FOLIO_COMPRA", typeof(String));
            tableCaducidades.Columns.Add("ARTICULO_ID", typeof(String));
            tableCaducidades.Columns.Add("NOMBRE", typeof(String));
            tableCaducidades.Columns.Add("CANTIDAD", typeof(Int32));
            tableCaducidades.Columns.Add("CANT_LOTE", typeof(Int32));
            tableCaducidades.Columns.Add("NO_LOTE", typeof(String));
            tableCaducidades.Columns.Add("CADUCIDAD", typeof(String));
            tableCaducidades.Columns.Add("DIV", typeof(String));

            /*tableCaducidades.Columns.Add("NUM_LOTE");
            tableCaducidades.Columns.Add("CADUCIDAD");*/


            string sentencia = "Pkg_Caducidades_v2.sp_get_caducidades";
            //string sentencia = "Pkg_Caducidades_v2.sp_get_caducidades";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter Pe_documento = new OracleParameter("pe_documento", OracleDbType.Varchar2);
                    Pe_documento.Value = documento;
                    cmd.Parameters.Add(Pe_documento);


                    OracleParameter Pe_movimiento_id = new OracleParameter("pe_id_movimiento", OracleDbType.Int16);
                    Pe_movimiento_id.Value = id_movimiento;
                    cmd.Parameters.Add(Pe_movimiento_id);

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
                                DataRow row = tableCaducidades.NewRow();
                                row["FOLIO_OC_ID"] = oreader["FOLIO_OC_ID"];
                                row["FOLIO_COMPRA"] = oreader["FOLIO_COMPRA"];
                                row["ARTICULO_ID"] = oreader["ARTICULO_ID"];
                                row["NOMBRE"] = oreader["NOMBRE"];
                                row["CANTIDAD"] = oreader["CANTIDAD"];
                                row["CANT_LOTE"] = oreader["CANT_LOTE"];
                                row["NO_LOTE"] = oreader["NO_LOTE"];
                                row["CADUCIDAD"] = oreader["CADUCIDAD"];
                                row["DIV"] = oreader["DIV"];
                                tableCaducidades.Rows.Add(row);
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


        public static int upd_ctl_cad_bulk(string referencia, string tipoMov, string usuario, List<SIFModelo.Inventarios.SkuCaducidad> listCaducidades)
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Pkg_Caducidades_v2.Sp_UPD_CTL_Cad";
                cmd.BindByName = true;
                cmd.Parameters.Add("PE_Referencia", OracleDbType.Varchar2, referencia, ParameterDirection.Input);
                cmd.Parameters.Add("PE_Tipo_Mov_Inv", OracleDbType.Varchar2, tipoMov, ParameterDirection.Input);
                cmd.Parameters.Add("PE_Usuario", OracleDbType.Varchar2, usuario, ParameterDirection.Input);


                List<Int32> L_partida = new List<Int32>();
                List<string> L_articulo_id = new List<string>();
                List<Int32> L_cant_lote = new List<Int32>();
                List<string> L_lote = new List<string>();
                List<string> L_caducidad = new List<string>();


                foreach (SIFModelo.Inventarios.SkuCaducidad detalle in listCaducidades)
                {
                    L_partida.Add(detalle.partida);
                    L_articulo_id.Add(detalle.articuloId);
                    L_cant_lote.Add(detalle.cant_lote);
                    L_lote.Add(detalle.no_lote);
                    L_caducidad.Add(detalle.caducidad.ToString("dd/MM/yyyy"));
                }
                OracleParameter pPartida = cmd.Parameters.Add("p_partida", OracleDbType.Decimal);
                pPartida.Direction = ParameterDirection.Input;
                pPartida.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                pPartida.Value = L_partida.ToArray();


                OracleParameter pArticulo_id = cmd.Parameters.Add("p_Articulo_id", OracleDbType.Varchar2);
                pArticulo_id.Direction = ParameterDirection.Input;
                pArticulo_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                pArticulo_id.Value = L_articulo_id.ToArray();

                OracleParameter pcant_lote = cmd.Parameters.Add("p_cant_lote", OracleDbType.Decimal);
                pcant_lote.Direction = ParameterDirection.Input;
                pcant_lote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                pcant_lote.Value = L_cant_lote.ToArray();

                OracleParameter plote = cmd.Parameters.Add("p_lote", OracleDbType.Varchar2);
                plote.Direction = ParameterDirection.Input;
                plote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                plote.Value = L_lote.ToArray();

                OracleParameter pcaducidad = cmd.Parameters.Add("p_caducidad", OracleDbType.Varchar2);
                pcaducidad.Direction = ParameterDirection.Input;
                pcaducidad.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                pcaducidad.Value = L_caducidad.ToArray();



                // OUT parameter
                OracleParameter pTraspaso =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pTraspaso.Value.ToString()))
                {
                    return int.Parse(pTraspaso.Value.ToString());
                }
                else
                {
                    return -1;
                }

            }
            catch (Exception ex)
            {

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
            return 0;
        }

        #endregion


        #region Control de Caducidades  Version 1.3


        public static DataTable sp_GetDataRcc(string documento)
        {
            ///<summary>
            ///Obtiene las caducidades de la recepcion de Ordenes de compra 
            /// 
            /// </summary>
            

             DataTable tableCaducidades = new DataTable("CaducidadesSku");
            tableCaducidades.Columns.Add("FOLIO_COMPRA", typeof(String));
            tableCaducidades.Columns.Add("ARTICULO_ID", typeof(String));
            tableCaducidades.Columns.Add("NOMBRE", typeof(String));
            tableCaducidades.Columns.Add("CANTIDAD", typeof(Int32));            
            tableCaducidades.Columns.Add("NO_LOTE", typeof(String));
            tableCaducidades.Columns.Add("CADUCIDAD", typeof(String));

                
          
            List<SIFModelo.Inventarios.SkuCaducidad> Lista = new List<SIFModelo.Inventarios.SkuCaducidad>();

            string sentencia = "Pkg_Caducidades_v3.sp_get_caducidades_rcc";
            
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter Pe_documento = new OracleParameter("pe_documento", OracleDbType.Varchar2);
                    Pe_documento.Value = documento;
                    cmd.Parameters.Add(Pe_documento);


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
                                //DataRow row = tableCaducidades.NewRow();
                                DataRow sku = tableCaducidades.NewRow();
                                //row["FOLIO_OC_ID"] = oreader["FOLIO_OC_ID"];
                                sku["FOLIO_COMPRA"] = oreader["FOLIO_COMPRA"].ToString();
                                sku["ARTICULO_ID"]= oreader["ARTICULO_ID"].ToString();
                                sku["NOMBRE"]= oreader["NOMBRE"].ToString();
                                sku["CANTIDAD"]= int.Parse( oreader["CANTIDAD"].ToString());
                                sku["NO_LOTE"]= oreader["LOTE"].ToString();
                                DateTime dateValue;
                                if (oreader["CADUCIDAD"].ToString().Length == 4)
                                    sku["CADUCIDAD"] = oreader["CADUCIDAD"].ToString();
                                else if (oreader["CADUCIDAD"].ToString().Length==0)
                                { 
                                    sku["CADUCIDAD"] = oreader["CADUCIDAD"].ToString();


                                }
                                else 
                                {
                                   MessageBox.Show("Error no se puede encontrar caducidad para el articulo" +
                                        Environment.NewLine + "Para el articulo " + oreader["ARTICULO_ID"].ToString(), "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

                                }



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

        public static DataTable sp_GetDataRc(string documento)
        {
            ///<summary>
            ///Obtiene las caducidades capturadas de la recepcion de Ordenes de compra 
            /// 
            /// </summary>

            DataTable tableCaducidades = new DataTable("CaducidadesSku");
            tableCaducidades.Columns.Add("FOLIO_COMPRA", typeof(String));
            tableCaducidades.Columns.Add("ARTICULO_ID", typeof(String));
            tableCaducidades.Columns.Add("NOMBRE", typeof(String));
            tableCaducidades.Columns.Add("CANTIDAD", typeof(Int32));
            tableCaducidades.Columns.Add("NO_LOTE", typeof(String));
            tableCaducidades.Columns.Add("CADUCIDAD", typeof(String));



            List<SIFModelo.Inventarios.SkuCaducidad> Lista = new List<SIFModelo.Inventarios.SkuCaducidad>();

            string sentencia = "Pkg_Caducidades_v3.sp_get_caducidades_rc";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter Pe_documento = new OracleParameter("pe_documento", OracleDbType.Varchar2);
                    Pe_documento.Value = documento;
                    cmd.Parameters.Add(Pe_documento);


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
                                sku["FOLIO_COMPRA"] = oreader["FOLIO_COMPRA"].ToString();
                                sku["ARTICULO_ID"] = oreader["ARTICULO_ID"].ToString();
                                sku["NOMBRE"] = oreader["NOMBRE"].ToString();
                                sku["CANTIDAD"] = int.Parse(oreader["CANTIDAD"].ToString());
                                sku["NO_LOTE"] = oreader["LOTE"].ToString();
                             



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

        public static Decimal sp_GuardadCaducidadesCapturadas(string pFoliocompra , string pUsuario_id,

        List<Int32> L_partida       ,
        List<string> L_articulo_id  ,
        List<string> L_Lote_Interno ,
        List<Int32> L_cant_lote     ,
        List<string> L_lote         ,
        List<string> L_loteProdcesado ,
        List<string> L_caducidad    
            
            , out string Respuesta )
        {
            ///<summary>
            ///Guardamos las caducidades Capturadas en el modulo de captura de caducidades
            /// 
            /// </summary>


            
            try
            {


                List<SIFModelo.Inventarios.SkuCaducidad> Lista = new List<SIFModelo.Inventarios.SkuCaducidad>();

                string sentencia = "Pkg_Caducidades_v3.SP_INS_LC_RCC";

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cnx.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("PE_Referencia", OracleDbType.Varchar2, pFoliocompra, ParameterDirection.Input);
                        cmd.Parameters.Add("PE_Referencia", OracleDbType.Varchar2, pUsuario_id, ParameterDirection.Input);
                       /* List<Int32> L_partida = new List<Int32>();
                        List<string> L_articulo_id = new List<string>();
                        List<string> L_Lote_Interno = new List<string>();
                        List<Int32> L_cant_lote = new List<Int32>();
                        List<string> L_lote = new List<string>();
                        List<string> L_loteProdcesado = new List<string>();
                        List<string> L_caducidad = new List<string>();

                        int partida = 0;
                        foreach (DataRow drDetalle in CaducidadesCapturadas.Rows)
                        {
                            if (!String.IsNullOrEmpty(drDetalle["NO_LOTE"].ToString()) && !String.IsNullOrEmpty(drDetalle["CADUCIDAD"].ToString()))
                            {
                                partida++;
                                L_partida.Add(partida);
                                L_articulo_id.Add(drDetalle["ARTICULO_ID"].ToString());
                                L_Lote_Interno.Add(pFoliocompra+"-"+partida.ToString().PadLeft(6,'0'));
                                L_lote.Add(drDetalle["NO_LOTE"].ToString());
                                L_caducidad.Add(drDetalle["CADUCIDAD"].ToString());
                                L_loteProdcesado.Add("N");
                                L_cant_lote.Add(int.Parse(drDetalle["CANTIDAD"].ToString()));
                            }

                        }

                        if (L_partida.Count <= 0) {
                            
                            Respuesta = "Sin registros para guardar!";
                            return -99;
                        }
                        */

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
                        pInsCaducidadRespuesta.Size=300;

                        // Execute the command
                        cmd.ExecuteNonQuery();

                        if (!string.IsNullOrEmpty(pInsCaducidad.Value.ToString()))
                        {
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
            } catch (Exception _x) 
            {

                Respuesta = _x.ToString();
                return -999;

            }

        }



        public static DataTable sp_GetDataCaducidadesMovimientoV3(string documento, int id_movimiento)
        {
            ///<summary>
            ///Obtiene las caducidades de la recepcion de Ordenes de compra 
            /// 
            /// </summary>


            DataTable tableCaducidades = new DataTable("CaducidadesSku");
            tableCaducidades.Columns.Add("DOCUMENTO", typeof(String));
            tableCaducidades.Columns.Add("ARTICULO_ID", typeof(String));
            tableCaducidades.Columns.Add("NOMBRE", typeof(String));
            tableCaducidades.Columns.Add("CANTIDAD", typeof(Int32));
            tableCaducidades.Columns.Add("NO_LOTE", typeof(String));
            tableCaducidades.Columns.Add("CADUCIDAD", typeof(DateTime));
            tableCaducidades.Columns.Add("LOTE_INTERNO", typeof(String));



            List<SIFModelo.Inventarios.SkuCaducidad> Lista = new List<SIFModelo.Inventarios.SkuCaducidad>();

            string sentencia = "Pkg_Caducidades_v3.sp_get_caducidades_movimiento";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter Pe_documento = new OracleParameter("pe_documento", OracleDbType.Varchar2);
                    Pe_documento.Value = documento;
                    cmd.Parameters.Add(Pe_documento);

                   

                    OracleParameter Pe_id_movimiento = new OracleParameter("pe_id_movimineto", OracleDbType.Int16);
                    Pe_id_movimiento.Value = id_movimiento;
                    cmd.Parameters.Add(Pe_id_movimiento);

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
                                    sku["CADUCIDAD"] =Convert.ToDateTime( oreader["CADUCIDAD"].ToString());                             
                                else
                                {

                                    sku["CADUCIDAD"] = Convert.ToDateTime("01/01/2001");

                                   MessageBox.Show("Error no se puede encontrar caducidad para el articulo" +
                                        Environment.NewLine + "Para el articulo " + oreader["ARTICULO_ID"].ToString(), "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

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


            public static DataTable sp_GetDataCaduSeleccionRecepcionCompra(string documento, int  lote_documento, int id_movimiento )
        {
            ///<summary>
            ///Obtiene las caducidades capturadas de la recepcion de Ordenes de compra 
            /// 
            /// </summary>

            DataTable tableCaducidades = new DataTable("CaducidadesSku");
            tableCaducidades.Columns.Add("DOCUMENTO", typeof(String));
            tableCaducidades.Columns.Add("ARTICULO_ID", typeof(String));
            tableCaducidades.Columns.Add("NOMBRE", typeof(String));
            tableCaducidades.Columns.Add("CANTIDAD", typeof(Int32));
            tableCaducidades.Columns.Add("NO_LOTE", typeof(String));
            tableCaducidades.Columns.Add("CADUCIDAD", typeof(DateTime));
            tableCaducidades.Columns.Add("LOTE_INTERNO", typeof(String));



            List<SIFModelo.Inventarios.SkuCaducidad> Lista = new List<SIFModelo.Inventarios.SkuCaducidad>();

            string sentencia = "Pkg_Caducidades_v3.sp_get_cadu_seleccion_rc";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter Pe_documento = new OracleParameter("pe_documento", OracleDbType.Varchar2);
                    Pe_documento.Value = documento;
                    cmd.Parameters.Add(Pe_documento);


                    OracleParameter Pe_lote_documento = new OracleParameter("Pe_lote_documento", OracleDbType.Int16);
                    Pe_lote_documento.Value = lote_documento;
                    cmd.Parameters.Add(Pe_lote_documento);

                    OracleParameter Pe_id_movimiento = new OracleParameter("Pe_id_movimiento", OracleDbType.Int16);
                    Pe_id_movimiento.Value = id_movimiento;
                    cmd.Parameters.Add(Pe_id_movimiento);



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
                                sku["CANTIDAD"] = int.Parse(oreader["CANTIDAD"].ToString());
                                sku["NO_LOTE"] = oreader["LOTE"].ToString();
                                if (oreader["CADUCIDAD"].ToString().IsDatetime())
                                    sku["CADUCIDAD"] = Convert.ToDateTime(oreader["CADUCIDAD"].ToString());
                                else
                                {

                                    sku["CADUCIDAD"] = Convert.ToDateTime("01/01/2001");

                                   MessageBox.Show("Error no se puede encontrar caducidad para el articulo" +
                                        Environment.NewLine + "Para el articulo " + oreader["ARTICULO_ID"].ToString(), "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

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


        public static Decimal sp_GuardadCaducidadesSelectMovimiento(string pFoliocompra, int lote_documento, string pUsuario_id,
            int id_movimiento,

 List<Int32> L_partida,
 List<string> L_articulo_id,
 List<string> L_Lote_Interno,
 List<Int32> L_cant_lote,
 List<string> L_lote,
 List<string> L_loteProdcesado,
 List<string> L_caducidad

     , out string Respuesta)
        {
            ///<summary>
            ///Guardamos las caducidades Capturadas en el modulo de captura de caducidades
            /// 
            /// </summary>



            try
            {


                List<SIFModelo.Inventarios.SkuCaducidad> Lista = new List<SIFModelo.Inventarios.SkuCaducidad>();

                string sentencia = "Pkg_Caducidades_v3.sp_ins_cadu_entrada_mov";

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cnx.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("P_documento", OracleDbType.Varchar2, pFoliocompra, ParameterDirection.Input);
                        cmd.Parameters.Add("P_USUARIO_ID", OracleDbType.Varchar2, pUsuario_id, ParameterDirection.Input);
                        cmd.Parameters.Add("p_lote_documento", OracleDbType.Int16, lote_documento, ParameterDirection.Input);
                        cmd.Parameters.Add("p_id_movimineto", OracleDbType.Int16, id_movimiento, ParameterDirection.Input);



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

        public static DataTable getLotesYCaducidadM(string folio, string tipo_mov,string lote)
        {
            //PIT 17/01/2022
            DataTable tableCaducidades = new DataTable("LotesCaducidades");
           
            tableCaducidades.Columns.Add("CODIGO", typeof(String));
            tableCaducidades.Columns.Add("DESCRIPCION", typeof(String));
            tableCaducidades.Columns.Add("CANTIDAD", typeof(Int32));
            tableCaducidades.Columns.Add("LOTE", typeof(String));
            tableCaducidades.Columns.Add("CADUCIDAD", typeof(DateTime));
            tableCaducidades.Columns.Add("CADUCIDAD_MOD", typeof(String));
            tableCaducidades.Columns.Add("LOTE_INTERNO", typeof(String));

            //List<SIFModelo.Inventarios.SkuCaducidad> lista = new List<SIFModelo.Inventarios.SkuCaducidad>();

            string sentencia = "sp_get_lotes_caducidades_mod";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter var_folio = new OracleParameter("var_folio", OracleDbType.Varchar2);
                    var_folio.Value = folio;
                    cmd.Parameters.Add(var_folio);

                    
                    OracleParameter var_tipo_mov = new OracleParameter("var_tipo_mov", OracleDbType.Varchar2);
                    var_tipo_mov.Value = tipo_mov;
                    cmd.Parameters.Add(var_tipo_mov);

                    OracleParameter var_lote = new OracleParameter("var_lote", OracleDbType.Varchar2);
                    var_lote.Value = lote;
                    cmd.Parameters.Add(var_lote);

                    OracleParameter salida = new OracleParameter("outcursor", OracleDbType.RefCursor);
                    salida.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(salida);
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
                                sku["CODIGO"] = oreader["CODIGO"].ToString();
                                sku["DESCRIPCION"] = oreader["DESCRIPCION"].ToString();
                                sku["CANTIDAD"] = int.Parse(oreader["CANTIDAD"].ToString());
                                sku["LOTE"] = oreader["LOTE"].ToString();
                                sku["CADUCIDAD"] = oreader["CADUCIDAD"].ToString();
                                sku["CADUCIDAD_MOD"] = oreader["CADUCIDAD_MOD"].ToString();
                                sku["LOTE_INTERNO"] = oreader["INTERNO"].ToString();

                                if (oreader["CADUCIDAD"].ToString().IsDatetime())
                                    sku["CADUCIDAD"] = Convert.ToDateTime(oreader["CADUCIDAD"].ToString());
                          
                                else
                                {

                                    sku["CADUCIDAD"] = Convert.ToDateTime("01/01/2001");
                                   MessageBox.Show("Error no se puede encontrar caducidad para el articulo" +
                                        Environment.NewLine + "Para el articulo " + oreader["ARTICULO_ID"].ToString(), "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

                                }

                                                         
                              

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

        public static DataTable getLotesYCaducidad_Salida(string folio, string tipo_mov, string lote)
        {
            //PIT 17/01/2022
            DataTable tableCaducidades = new DataTable("LotesCaducidades");

            tableCaducidades.Columns.Add("CODIGO", typeof(String));
            tableCaducidades.Columns.Add("DESCRIPCION", typeof(String));
            tableCaducidades.Columns.Add("CANTIDAD", typeof(Int32));
            tableCaducidades.Columns.Add("LOTE", typeof(String));
            tableCaducidades.Columns.Add("CADUCIDAD", typeof(DateTime));
            tableCaducidades.Columns.Add("CADUCIDAD_MOD", typeof(String));
            tableCaducidades.Columns.Add("LOTE_INTERNO", typeof(String));

            //List<SIFModelo.Inventarios.SkuCaducidad> lista = new List<SIFModelo.Inventarios.SkuCaducidad>();

            string sentencia = "SP_GET_LOTES_CAD_SALIDA";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter var_folio = new OracleParameter("var_folio", OracleDbType.Varchar2);
                    var_folio.Value = folio;
                    cmd.Parameters.Add(var_folio);


                    OracleParameter var_tipo_mov = new OracleParameter("var_tipo_mov", OracleDbType.Varchar2);
                    var_tipo_mov.Value = tipo_mov;
                    cmd.Parameters.Add(var_tipo_mov);

                    OracleParameter var_lote = new OracleParameter("var_lote", OracleDbType.Varchar2);
                    var_lote.Value = lote;
                    cmd.Parameters.Add(var_lote);

                    OracleParameter salida = new OracleParameter("outcursor", OracleDbType.RefCursor);
                    salida.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(salida);
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
                                sku["CODIGO"] = oreader["CODIGO"].ToString();
                                sku["DESCRIPCION"] = oreader["DESCRIPCION"].ToString();
                                sku["CANTIDAD"] = int.Parse(oreader["CANTIDAD"].ToString());
                                sku["LOTE"] = oreader["LOTE"].ToString();
                                sku["CADUCIDAD"] = oreader["CADUCIDAD"].ToString();
                                sku["CADUCIDAD_MOD"] = oreader["CADUCIDAD_MOD"].ToString();
                                sku["LOTE_INTERNO"] = oreader["INTERNO"].ToString();

                                if (oreader["CADUCIDAD"].ToString().IsDatetime())
                                    sku["CADUCIDAD"] = Convert.ToDateTime(oreader["CADUCIDAD"].ToString());

                                else
                                {

                                    sku["CADUCIDAD"] = Convert.ToDateTime("01/01/2001");
                                   MessageBox.Show("Error no se puede encontrar caducidad para el articulo" +
                                        Environment.NewLine + "Para el articulo " + oreader["ARTICULO_ID"].ToString(), "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

                                }




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

        public static Decimal spActualizaLotesCaducidades(string a_usuario,
                                                          string a_movimiento, 
                                                          string a_articuloid,
                                                          char a_columna,
                                                          string a_old,
                                                          string a_new,
                                                          string a_loteInt)
        {
            ///<summary>
            ///Actualiza en la tabla recepcion_compradet_caducidad e inserta en historial_cambios_lyc
            /// 
            /// </summary>

            try
            {
                //List<SIFModelo.Inventarios.SkuCaducidad> Lista = new List<SIFModelo.Inventarios.SkuCaducidad>();

                string sentencia = "SP_UPD_LOT_CADUCIDADES";
                string Respuesta = "";

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cnx.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        /*
                        cmd.CommandType = CommandType.StoredProcedure;
                        OracleParameter var_folio = new OracleParameter("var_folio", OracleDbType.Varchar2);
                        var_folio.Value = folio;
                        cmd.Parameters.Add(var_folio);
                        */

                        cmd.Parameters.Add("e_usuario", OracleDbType.Varchar2, a_usuario, ParameterDirection.Input);
                        cmd.Parameters.Add("e_movimiento", OracleDbType.Varchar2, a_movimiento, ParameterDirection.Input);
                        cmd.Parameters.Add("e_articuloid", OracleDbType.Varchar2, a_articuloid, ParameterDirection.Input);
                        cmd.Parameters.Add("e_column", OracleDbType.Char, a_columna, ParameterDirection.Input);
                        cmd.Parameters.Add("e_old", OracleDbType.Varchar2, a_old, ParameterDirection.Input);
                        cmd.Parameters.Add("e_new", OracleDbType.Varchar2, a_new, ParameterDirection.Input);
                        cmd.Parameters.Add("e_lot_int", OracleDbType.Varchar2, a_loteInt, ParameterDirection.Input);

                        // OUT parameter
                        OracleParameter salida = cmd.Parameters.Add("outparam", OracleDbType.Decimal, ParameterDirection.Output);
                        

                        // Execute the command
                        cmd.ExecuteNonQuery();

                        if (!string.IsNullOrEmpty(salida.Value.ToString()))
                        {
                            //Respuesta = salida.Value.ToString();
                            return Decimal.Parse(salida.Value.ToString());
                        }
                        else
                        {
                            Respuesta = salida.Value.ToString();
                            return -1;
                        }

                    }
                }
            }
            catch (Exception _x)
            {

                string Respuesta2 = _x.ToString();
                return -999;

            }

        }

        public static Decimal validaCambioLoteCaducidad(string lote_interno)
        {

            string num_partidas="";
            string lote_int = lote_interno;
            string sentencia = "select count(*) valor from inv_kardex where ult_lote_interno= :lote_int and TIPO_MOV_INV_ID IN ( 2 , 3 , 6 , 8 )";
            

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("lote_int", lote_int);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        num_partidas = oreader.GetValue(0).ToString();
                        
                            return Convert.ToDecimal(num_partidas);
                        
                    }
                    cmd.Connection.Close();
                    cmd.Dispose();
                    //OracleConnection.ClearPool(cmd.Connection);

                }



            }
            return -1;
        
    

            }

        public static DataTable sp_GetDataLotesYcaducidadesSku(string documento, int periodo)
        {
            ///<summary>
            ///Obtiene las caducidades de la recepcion de Ordenes de compra 
            /// 
            /// </summary>


            DataTable tableCaducidades = new DataTable("CaducidadesSku");
            
            tableCaducidades.Columns.Add("ARTICULO_ID", typeof(String));
            tableCaducidades.Columns.Add("NUM_PARTIDA", typeof(Int32));
            tableCaducidades.Columns.Add("CANTIDAD", typeof(Int32));
            tableCaducidades.Columns.Add("NO_LOTE", typeof(String));
            tableCaducidades.Columns.Add("CADUCIDAD", typeof(String));



            List<SIFModelo.Inventarios.SkuCaducidad> Lista = new List<SIFModelo.Inventarios.SkuCaducidad>();

            string sentencia = "PKG_INVENTARIOS.sp_get_articulos_sku_caduciad";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter Pe_documento = new OracleParameter("pe_articulo_id", OracleDbType.Varchar2);
                    Pe_documento.Value = documento;
                    cmd.Parameters.Add(Pe_documento);

                    OracleParameter Pe_Periodo = new OracleParameter("pe_Periodo", OracleDbType.Varchar2);
                    Pe_Periodo.Value = periodo;
                    cmd.Parameters.Add(Pe_Periodo);



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
                                //DataRow row = tableCaducidades.NewRow();
                                DataRow sku = tableCaducidades.NewRow();
                                //row["FOLIO_OC_ID"] = oreader["FOLIO_OC_ID"];

                                sku["ARTICULO_ID"] = oreader["ARTICULO_ID"].ToString();
                                sku["NUM_PARTIDA"] = int.Parse(oreader["NUM_PARTIDA"].ToString());
                                sku["CANTIDAD"] = int.Parse(oreader["CANTIDAD"].ToString());
                                sku["NO_LOTE"] = oreader["LOTE"].ToString();
                                DateTime dateValue;
                                if (oreader["CADUCIDAD"].ToString().Length == 4)
                                    sku["CADUCIDAD"] = oreader["CADUCIDAD"].ToString();
                                else if (oreader["CADUCIDAD"].ToString().Length == 0)
                                {
                                    sku["CADUCIDAD"] = oreader["CADUCIDAD"].ToString();


                                }
                                else
                                {
                                   MessageBox.Show("Error no se puede encontrar caducidad para el articulo" +
                                        Environment.NewLine + "Para el articulo " + oreader["ARTICULO_ID"].ToString(), "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

                                }



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



        public static Decimal 
            sp_SaveCaduCapturadasSku(
                        string pUsuario_id,
                        int periodo ,
                        List<Int32> L_partida,
                        List<string> L_articulo_id,   
                        List<Int32> L_cant_lote,
                        List<string> L_lote,   
                        List<string> L_caducidad)
        {
            ///<summary>
            ///Guardamos las caducidades Capturadas en el modulo de captura de caducidades
            /// 
            /// </summary>



            try
            {


                List<SIFModelo.Inventarios.SkuCaducidad> Lista = new List<SIFModelo.Inventarios.SkuCaducidad>();

                string sentencia = "PKG_INVENTARIOS.sp_ins_articulos_sku_caducidad";

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cnx.Open();
                        cmd.CommandType = CommandType.StoredProcedure;



                        


                        OracleParameter pArticulo_id = cmd.Parameters.Add("P_ARTICULO_ID", OracleDbType.Varchar2);
                        pArticulo_id.Direction = ParameterDirection.Input;
                        pArticulo_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        pArticulo_id.Value = L_articulo_id.ToArray();

                        OracleParameter pPartida = cmd.Parameters.Add("P_NUM_PARTIDA", OracleDbType.Decimal);
                        pPartida.Direction = ParameterDirection.Input;
                        pPartida.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        pPartida.Value = L_partida.ToArray();


                        OracleParameter pcant_lote = cmd.Parameters.Add("P_CANTIDAD", OracleDbType.Decimal);
                        pcant_lote.Direction = ParameterDirection.Input;
                        pcant_lote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        pcant_lote.Value = L_cant_lote.ToArray();



                        OracleParameter plote = cmd.Parameters.Add("P_LOTE", OracleDbType.Varchar2);
                        plote.Direction = ParameterDirection.Input;
                        plote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        plote.Value = L_lote.ToArray();



                        OracleParameter pcaducidad = cmd.Parameters.Add("P_CADUCIDAD", OracleDbType.Varchar2);
                        pcaducidad.Direction = ParameterDirection.Input;
                        pcaducidad.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        pcaducidad.Value = L_caducidad.ToArray();

                        cmd.Parameters.Add("P_USUARIO_ID", OracleDbType.Varchar2, pUsuario_id, ParameterDirection.Input);
                        cmd.Parameters.Add("P_PERIODO", OracleDbType.Int32, periodo, ParameterDirection.Input);
                        // OUT parameter
                        OracleParameter pInsCaducidad = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                        // Execute the command
                        cmd.ExecuteNonQuery();

                        if (!string.IsNullOrEmpty(pInsCaducidad.Value.ToString()))
                        {
                           
                            return Decimal.Parse(pInsCaducidad.Value.ToString());
                        }
                        else
                        {
                            
                            return -1;
                        }

                    }
                }
            }
            catch (Exception _x)
            {
                return -999;
            }

        }


        #endregion
    }
}
