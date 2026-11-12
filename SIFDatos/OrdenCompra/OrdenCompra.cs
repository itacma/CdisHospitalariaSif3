using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using Oracle.DataAccess.Types;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace SIFDatos.OrdenCompra
{
    public static class OrdenCompra
    {

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet GeneraCompraArticulo(SIFModelo.OrdenCompra.OrdenCompraDataSet dsOrdenesCompra, SIFModelo.Sucursal sucursal, string proveedor, decimal porcentaje_eoq, SIFModelo.Usuario usuario, string tipoCompra, string articuloID)
        {
            OracleCommand cmd = null;
            try
            {
                dsOrdenesCompra.ORDEN_COMPRA_DET.Clear();

                //LLENAMOS LOS ARTICULOS QUE NO SON ESPECIALES
                string sentencia = "PKG_COMPRAS.SP_GET_COMPRAS_ARTICULOS";

                if (!string.IsNullOrEmpty(proveedor))
                {
                    sentencia = "PKG_COMPRAS.SP_GET_COMPRAS_ARTICULOS_LAB";
                }

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    cmd = new OracleCommand(sentencia, cnx);
                    if (sentencia == "PKG_COMPRAS.SP_GET_COMPRAS_ARTICULOS_LAB" && porcentaje_eoq > 100)
                    {
                        cmd.Parameters.Add("p_sucursal_id", sucursal.SucursalesID);
                        cmd.Parameters.Add("p_proveedores", proveedor);
                        cmd.Parameters.Add("p_tipo_compra", tipoCompra);
                    }
                    else
                    {

                        cmd.Parameters.Add("p_sucursal_id", sucursal.SucursalesID);
                        cmd.Parameters.Add("p_articulo_id", "");

                        if (!string.IsNullOrEmpty(proveedor))
                        {
                            cmd.Parameters.Add("p_proveedores", proveedor);
                        }

                        cmd.Parameters.Add("p_acceso_id", usuario.UsuariosID);
                        cmd.Parameters.Add("p_tipo_compra", tipoCompra);
                        cmd.Parameters.Add("p_porcentaje_eoq", porcentaje_eoq);

                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter p_no_f1 = cmd.Parameters.Add("HDR", OracleDbType.RefCursor, ParameterDirection.Output);

                    OracleParameter p_tra = null;
                    if (string.IsNullOrEmpty(proveedor))
                    {
                        p_tra = cmd.Parameters.Add("TRA", OracleDbType.RefCursor, ParameterDirection.Output);
                    }


                    //OracleParameter p_f1 = cmd.Parameters.Add("HDR_F1", OracleDbType.RefCursor, ParameterDirection.Output);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    OracleRefCursor rNoF1 = p_no_f1.Value as OracleRefCursor;
                    OracleRefCursor rTra = null;

                    if (string.IsNullOrEmpty(proveedor))
                    {
                        rTra = p_tra.Value as OracleRefCursor;
                    }
                    //OracleRefCursor rF1 = p_f1.Value as OracleRefCursor;

                    OracleDataAdapter oda = new OracleDataAdapter();
                    dsOrdenesCompra.EnforceConstraints = false;
                    DataTable dt = new DataTable();

                    dsOrdenesCompra.ORDEN_COMPRA_DET.NOMBREColumn.DefaultValue = "";
                    dsOrdenesCompra.ORDEN_COMPRA_DET.DESCRIP_OFERTAColumn.DefaultValue = "";
                    dsOrdenesCompra.ORDEN_COMPRA_DET.ULT_PRECIO_COMPRAColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.MEJOR_OFERTA_COSTOColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.CANT_SOLICITADAColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.OFERTA_COMPRA_IDColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.CANT_DEVUELTAColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.CANT_MALESTADOColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.CANT_REPOSICIONColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.OBSERVACION_OC_DETColumn.DefaultValue = "";
                    dsOrdenesCompra.ORDEN_COMPRA_DET.NUM_PARTIDAColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.USUARIO_IDColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.PRECIO_COSTOColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.CANT_FACTURADAColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.CANT_RECIBIDAColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.DESCTO_FACTURAColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.DESCTO_FACTURA_AD1Column.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.DESCTO_RECIBIDOColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.DESCTO_RECIBIDO_AD1Column.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.DESCTO_RECIBIDO_AD2Column.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.EXISTENCIA_GENERALColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.IMPORTEColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.EXISTENCIASColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.PRECIO_FARMACIAColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.LABORATORIO_IDColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.OFERTASColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.PUNTO_DE_REORDENColumn.DefaultValue = 0;
                    dsOrdenesCompra.ORDEN_COMPRA_DET.TIPO_MEDICAMENTO_CVEColumn.DefaultValue = "";
                    dsOrdenesCompra.ORDEN_COMPRA_DET.CODIGO_PROVEEDORColumn.DefaultValue = "";
                    dsOrdenesCompra.ORDEN_COMPRA_DET.NOMBREColumn.DefaultValue = "";
                    dsOrdenesCompra.ORDEN_COMPRA_DET.PRECIO_FARMACIAColumn.DefaultValue = 0;

                    oda.Fill(dsOrdenesCompra.ORDEN_COMPRA_DET, rNoF1);



                    dsOrdenesCompra.ORDEN_COMPRA_DET.NOMBREColumn.Expression = "NOMBRE1";
                     

                    SIFModelo.OrdenCompra.OrdenCompraDataSet dsT = new SIFModelo.OrdenCompra.OrdenCompraDataSet();
                    dsT.ORDEN_COMPRA_DET.Constraints.Clear();
                    dsT.EnforceConstraints = false;

                    dsT.ORDEN_COMPRA_DET.NOMBREColumn.DefaultValue = "";
                    dsT.ORDEN_COMPRA_DET.DESCRIP_OFERTAColumn.DefaultValue = "";
                    dsT.ORDEN_COMPRA_DET.ULT_PRECIO_COMPRAColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.MEJOR_OFERTA_COSTOColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.CANT_SOLICITADAColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.OFERTA_COMPRA_IDColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.CANT_DEVUELTAColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.CANT_MALESTADOColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.CANT_REPOSICIONColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.OBSERVACION_OC_DETColumn.DefaultValue = "";
                    dsT.ORDEN_COMPRA_DET.NUM_PARTIDAColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.USUARIO_IDColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.PRECIO_COSTOColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.CANT_FACTURADAColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.CANT_RECIBIDAColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.DESCTO_FACTURAColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.DESCTO_FACTURA_AD1Column.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.DESCTO_RECIBIDOColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.DESCTO_RECIBIDO_AD1Column.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.DESCTO_RECIBIDO_AD2Column.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.EXISTENCIA_GENERALColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.IMPORTEColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.EXISTENCIASColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.PRECIO_FARMACIAColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.LABORATORIO_IDColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.OFERTASColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.PUNTO_DE_REORDENColumn.DefaultValue = 0;
                    dsT.ORDEN_COMPRA_DET.TIPO_MEDICAMENTO_CVEColumn.DefaultValue = "";
                    dsT.ORDEN_COMPRA_DET.CODIGO_PROVEEDORColumn.DefaultValue = "";
                    dsT.ORDEN_COMPRA_DET.NOMBREColumn.DefaultValue = "";
                    dsT.ORDEN_COMPRA_DET.PRECIO_FARMACIAColumn.DefaultValue = 0;

                    if (string.IsNullOrEmpty(proveedor))
                    {
                        oda.Fill(dsT.ORDEN_COMPRA_DET, rTra);


                        dsT.ORDEN_COMPRA_DET.NOMBREColumn.Expression = "NOMBRE1";
                    }
                    foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow row in dsT.ORDEN_COMPRA_DET.Rows)
                    {
                        row.ES_TRANSFER = "s";
                        row.OBSERVACION_OC_DET = "TRANSFER";
                        row.OC_SEGMENTA = -1;
                        row.PROVEEDOR_ID = 99000;
                        dsOrdenesCompra.ORDEN_COMPRA_DET.ImportRow(row);
                    }

                    //dsOrdenesCompra.ORDEN_COMPRA_DET.COSTO_ULT_COMPRAColumn.DefaultValue = "";

                    //dsOrdenesCompra.ORDEN_COMPRA_DET.OC_SEGMENTAColumn.DefaultValue = "";
                    //dsOrdenesCompra.ORDEN_COMPRA_DET.OC_SEGMENTAColumn.DefaultValue = 0;

                    //oda.Fill(dsOrdenesCompra.ORDEN_COMPRA_DET, rF1);
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);

                return null;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
               
               //OracleConnection.ClearPool(cmd.Connection);

            }
            return dsOrdenesCompra;

        }

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet GeneraDeEOQ(SIFModelo.OrdenCompra.OrdenCompraDataSet dsOrdenesCompra, SIFModelo.Sucursal sucursal, string proveedor, decimal porcentaje_eoq, SIFModelo.Usuario usuario, string tipoCompra, string esGeneral = "N")
        {
            OracleCommand cmd = null;
            proveedor = proveedor.Replace(',', '|');
            try
            {
                dsOrdenesCompra.ORDEN_COMPRA_DET.Clear();

                //LLENAMOS LOS ARTICULOS QUE NO SON ESPECIALES
                string sentencia = "PKG_COMPRAS.SP_GET_ARTICULOS_EOQ";

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    cmd = new OracleCommand(sentencia, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_sucursal_id", sucursal.SucursalesID);
                    cmd.Parameters.Add("p_proveedores", proveedor);
                    // cmd.Parameters.Add("p_usuario_id", usuario.UsuariosID);
                    cmd.Parameters.Add("p_tipo_compra", tipoCompra);
                    cmd.Parameters.Add("p_porcentaje_eoq", porcentaje_eoq);
                    cmd.Parameters.Add("p_es_general", esGeneral);

                    OracleParameter p_no_f1 = cmd.Parameters.Add("HDR", OracleDbType.RefCursor, ParameterDirection.Output);
                    //OracleParameter p_f1 = cmd.Parameters.Add("HDR_F1", OracleDbType.RefCursor, ParameterDirection.Output);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    OracleRefCursor rNoF1 = p_no_f1.Value as OracleRefCursor;
                    //OracleRefCursor rF1 = p_f1.Value as OracleRefCursor;

                    OracleDataAdapter oda = new OracleDataAdapter();
                    dsOrdenesCompra.EnforceConstraints = false;
                    oda.Fill(dsOrdenesCompra.ORDEN_COMPRA_DET, rNoF1);
                    dsOrdenesCompra.ORDEN_COMPRA_DET.OC_SEGMENTAColumn.DefaultValue = 0;
                    //oda.Fill(dsOrdenesCompra.ORDEN_COMPRA_DET, rF1);
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);

                return null;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();                
               //OracleConnection.ClearPool(cmd.Connection);
            }
            return dsOrdenesCompra;

        }


        public static void CambiaProveedorOrden(string ocFolio, SIFModelo.Cliente newProv )
        {
            OracleCommand cmd = null;
            try
            {
                string sentencia = "SP_CHANGE_PROVEEDOR";

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    cmd = new OracleCommand(sentencia, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_folioOC", ocFolio);
                    cmd.Parameters.Add("p_newprov", newProv.ID);
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataAdapter oda = new OracleDataAdapter();

                        System.Windows.Forms.MessageBox.Show("El proveedor se ha cambiado con exito");
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("hubo un error al cambiar el Proveedor: "+ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show("hubo un error al cambiar el Proveedor: " + ex.Message);

                
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
               //OracleConnection.ClearPool(cmd.Connection);
            }
            

        }

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet Ofertas(SIFModelo.OrdenCompra.OrdenCompraDataSet articulos)
        {
            //AGREGAMOS LA OFERTA
            string listaArticulos = "";

            foreach (DataRow datarow in articulos.ORDEN_COMPRA_DET.Rows)
            {
                listaArticulos += "'" + datarow["ARTICULO_ID"].ToString() + "',";
            }

            listaArticulos = listaArticulos.Trim(',');


            if (string.IsNullOrEmpty(listaArticulos))
            {
                listaArticulos = "''";
            }


            string sentenciaOfertas = "SELECT ARTICULO_ID, " +
   " PROVEEDOR_ID, " +
   " FECHA_ALTA, " +
   " NOMBRE1, " +
   " LABORATORIO_ID, " +
   " PRECIO_FARMACIA, " +
   " PRECIO_PUBLICO, " +
   " TIPO_OFERTA, " +
   " DESCTO_OFRECIDO, " +
   " DESCRIP_DESCTO, " +
   " MINIMO_PIEZAS, " +
   " CANTIDAD_ACOMPRAR, " +
   " PIEZAS_CON_CARGO, " +
   " PIEZAS_SIN_CARGO, " +
   " ESTADO_ART_PROVEE, " +
   " ESTADO_ART_FLEMING, " +
   " DESCTO_ADICIONAL_PROVEE, " +
   " DESCTO_ESPECIAL_PROVEE, " +
   " FECHA_BAJA, " +
   " CODIGO_PROVEEDOR, " +
   " ESCALA " +
" FROM  OFERTAS_COMPRAS_MAYORISTA" +
" WHERE ARTICULO_ID IN (" + listaArticulos + ")  " +
" ORDER BY (DESCTO_OFRECIDO + DESCTO_ESPECIAL_PROVEE + ( NVL( (PIEZAS_CON_CARGO / NULLIF(PIEZAS_SIN_CARGO,0) ),0) * 100)) DESC ";
            //" AND proveedor_id = :ProveedorID";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaOfertas, cnx))
                {
                    // cmd.Parameters.Add("ProveedorID", proveedor.ID);
                    //
                    using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                    {
                        td.Fill(articulos.OFERTAS_COMPRAS_MAYORISTA);
                    }
                }
            }

            return articulos;
        }



        public static SIFModelo.OrdenCompra.OrdenCompraDataSet GeneraCabeceraDeEOQ(SIFModelo.OrdenCompra.OrdenCompraDataSet ds, SIFModelo.Sucursal sucursal, string proveedor)
        {
            string sentencia = "SELECT proveedor_id, nombre, ape_paterno, ape_materno " +
                " FROM  inventario i  " +
                " JOIN  cat_articulos t " +
                " ON  t.ARTICULO_ID = i.articulo_id " +
                " JOIN cat_clientes l  " +
                " ON (t.proveedor_id = l.clientes_id)  " +
                " WHERE i.existencias <= i.punto_de_reorden  " +
                " AND PROVEEDOR_ID IN (" + proveedor + ")" +
            " GROUP BY proveedor_id, nombre, ape_paterno, ape_materno  ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    using (OracleDataAdapter adp = new OracleDataAdapter(cmd))
                    {

                        adp.Fill(ds.ORDEN_COMPRA_CABECERA);

                    }

                }

            }
            return ds;
        }

        public static int GeneraFolio(SIFModelo.Sucursal sucursal, string prefijoFolio)
        {
            object id;
            string sentencia = "SELECT FARMACIA.SEC_ORDENES.NEXTVAL FROM DUAL";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                  //  cmd.Parameters.Add("sucursalID", sucursal.SucursalesID);
                   // cmd.Parameters.Add("prefijoFolio", prefijoFolio);
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return int.Parse(id.ToString());
        }


        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASDataTable BuscaCompras(string folio, DateTime fecha1, DateTime fecha2, string status, string folioOC)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet dsOrdenesCompra = new SIFModelo.OrdenCompra.OrdenCompraDataSet();

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.COMPRASTableAdapter ta = new SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.COMPRASTableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;

                ta.FillByFechaActivoOCCompra(dsOrdenesCompra.COMPRAS, fecha1.ToString("dd/MM/yyyy HH:mm:ss"), fecha2.ToString("dd/MM/yyyy HH:mm:ss"), "%" + status + "%", "%" + folio + "%", "%" + folioOC + "%");
            }

            return dsOrdenesCompra.COMPRAS;
        }

        public static SIFModelo.OrdenCompra.OrdenesCompraDataSet BuscaCompras(string folio, DateTime fecha1, DateTime fecha2, string status)
        {
            throw new NotImplementedException();
        }

        public static SIFModelo.OrdenCompra.OrdenesCompraDataSet BuscaOrdenCompra(string folio, DateTime fecha1, DateTime fecha2, string status)
        {
            OracleCommand cmd = null;
            try
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet dsOrdenesCompra = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

                string sentencia = "PKG_COMPRAS.SP_GET_ORDENES_COMPRA";


                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (cmd = new OracleCommand(sentencia, cnx))
                    {
                        //
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_folio", "%" + folio + "%");
                        cmd.Parameters.Add("p_status", "%" + status + "%");
                        cmd.Parameters.Add("p_fecha_ini", fecha1.ToString("yyyy-MM-dd 00:00:00"));
                        cmd.Parameters.Add("p_fecha_fin", fecha2.ToString("yyyy-MM-dd 23:59:59"));
                        OracleParameter p_HDR = cmd.Parameters.Add("HDR", OracleDbType.RefCursor, ParameterDirection.Output);

                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        OracleRefCursor rHDR = p_HDR.Value as OracleRefCursor;

                        using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                        {
                            dsOrdenesCompra.V_ORDEN_COMPRA.Constraints.Clear();
                            td.Fill(dsOrdenesCompra.V_ORDEN_COMPRA, rHDR);
                        }
                    }
                }
                return dsOrdenesCompra;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
               //OracleConnection.ClearPool(cmd.Connection);
            }
        }


        public static SIFModelo.OrdenCompra.OrdenesCompraDataSet BuscaOrdenCompra(string folio, DateTime fecha1, DateTime fecha2, string status, int usuarioID)
        {
            OracleCommand cmd = null;
            try
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet dsOrdenesCompra = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

                string sentencia = "PKG_COMPRAS.SP_GET_ORDENES_COMPRA";

                if (usuarioID != 0)
                {
                    sentencia = "PKG_COMPRAS.SP_GET_ORDENES_COMPRA_USUARIO";
                }

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (cmd = new OracleCommand(sentencia, cnx))
                    {
                        //
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_folio", "%" + folio + "%");
                        cmd.Parameters.Add("p_status", "%" + status + "%");
                        cmd.Parameters.Add("p_fecha_ini", fecha1.ToString("yyyy-MM-dd 00:00:00"));
                        cmd.Parameters.Add("p_fecha_fin", fecha2.ToString("yyyy-MM-dd 23:59:59"));

                        if (usuarioID != 0)
                        {
                            cmd.Parameters.Add("p_usuario_id", usuarioID);
                        }

                        OracleParameter p_HDR = cmd.Parameters.Add("HDR", OracleDbType.RefCursor, ParameterDirection.Output);

                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        OracleRefCursor rHDR = p_HDR.Value as OracleRefCursor;

                        using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                        {
                            dsOrdenesCompra.V_ORDEN_COMPRA.Constraints.Clear();
                            td.Fill(dsOrdenesCompra.V_ORDEN_COMPRA, rHDR);
                        }
                    }
                }
                return dsOrdenesCompra;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
               //OracleConnection.ClearPool(cmd.Connection);
            }
        }

        public static SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETDataTable BuscaOrdenCompra(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OrdenCompra)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet dsOrdenesCompra = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

            string sentencia = "SELECT * FROM orden_compra_det WHERE FOLIO_OC_ID LIKE :OrdenCompraID ORDER BY NOMBRE ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("OrdenCompraID", OrdenCompra.FOLIO_OC_ID);
                    //
                    using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                    {
                        td.Fill(dsOrdenesCompra.ORDEN_COMPRA_DET);
                    }
                }
            }
            return dsOrdenesCompra.ORDEN_COMPRA_DET;
        }

        public static bool Recibe(SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow modelo)
        {
            string sentencia = "sp_upd_orden_compra_det";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("efolio_oc_id", modelo.FOLIO_OC_ID);
                    cmd.Parameters.Add("enum_partida", modelo.NUM_PARTIDA);
                    cmd.Parameters.Add("eusuario_id", modelo.USUARIO_ID);
                    cmd.Parameters.Add("eproveedor_id", modelo.PROVEEDOR_ID);
                    cmd.Parameters.Add("earticulo_id", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("enombre", modelo.NOMBRE);
                    cmd.Parameters.Add("ecant_solicitada", modelo.CANT_SOLICITADA);
                    cmd.Parameters.Add("eoferta_compra_id", modelo.OFERTA_COMPRA_ID);
                    cmd.Parameters.Add("edescrip_oferta", modelo.DESCRIP_OFERTA);
                    cmd.Parameters.Add("eprecio_costo", modelo.PRECIO_COSTO);
                    cmd.Parameters.Add("eult_precio_compra", modelo.ULT_PRECIO_COMPRA);
                    cmd.Parameters.Add("ecant_facturada", modelo.CANT_FACTURADA);
                    cmd.Parameters.Add("ecant_recibida", modelo.CANT_RECIBIDA);
                    cmd.Parameters.Add("ecant_devuelta", modelo.CANT_DEVUELTA);
                    cmd.Parameters.Add("ecant_malestado", modelo.CANT_MALESTADO);
                    cmd.Parameters.Add("ecant_reposicion", modelo.CANT_REPOSICION);
                    cmd.Parameters.Add("eprecio_factura", modelo.PRECIO_FACTURA);
                    cmd.Parameters.Add("edescto_factura", modelo.DESCTO_FACTURA);
                    cmd.Parameters.Add("edescto_factura_ad1", modelo.DESCTO_FACTURA_AD1);
                    cmd.Parameters.Add("edescto_recibido", modelo.DESCTO_RECIBIDO);
                    cmd.Parameters.Add("edescto_recibido_ad1", modelo.DESCTO_RECIBIDO_AD1);
                    cmd.Parameters.Add("edescto_recibido_ad2", modelo.DESCTO_RECIBIDO_AD2);
                    cmd.Parameters.Add("eobservacion_oc_det", " ");//modelo.OBSERVACION_OC_DET);
                    cmd.Parameters.Add("eprecio_farmacia", modelo.PRECIO_FARMACIA);//modelo.OBSERVACION_OC_DET);

                    var CODIGO_PROVEEDOR = modelo.IsCODIGO_PROVEEDORNull();
                    if (CODIGO_PROVEEDOR == true)
                    {
                        modelo.CODIGO_PROVEEDOR = "";
                    }
                    cmd.Parameters.Add("eCODIGO_PROVEEDOR", modelo.CODIGO_PROVEEDOR);
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static bool InsertaOrdenCompra(SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRARow modelo)
        {
            string sentencia = "sp_ins_orden_compra";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("folio_oc_id", modelo.FOLIO_OC_ID);
                    cmd.Parameters.Add("usuario_id", modelo.USUARIO_ID);
                    cmd.Parameters.Add("proveedor_id", modelo.PROVEEDOR_ID);
                    cmd.Parameters.Add("sucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("fecha_alta", modelo.FECHA_ALTA);
                    cmd.Parameters.Add("fecha_recepcion", modelo.FECHA_RECEPCION);
                    cmd.Parameters.Add("fecha_cierre", modelo.FECHA_CIERRE);
                    cmd.Parameters.Add("usuario_id_autoriza", modelo.USUARIO_ID_AUTORIZA);
                    cmd.Parameters.Add("fecha_autoriza", modelo.FECHA_AUTORIZA);
                    cmd.Parameters.Add("estado_oc", modelo.ESTADO_OC);
                    cmd.Parameters.Add("observacion_oc", modelo.OBSERVACION_OC);
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

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            // return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static bool InsertaOrdenCompraDetalle(SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow modelo)
        {
            string sentencia = "sp_ins_orden_compra_det";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("folio_oc_id", modelo.FOLIO_OC_ID);
                    cmd.Parameters.Add("num_partida", modelo.NUM_PARTIDA);
                    cmd.Parameters.Add("usuario_id", modelo.USUARIO_ID);
                    cmd.Parameters.Add("proveedor_id", modelo.PROVEEDOR_ID);
                    cmd.Parameters.Add("articulo_id", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("nombre", modelo.NOMBRE);
                    cmd.Parameters.Add("cant_solicitada", modelo.CANT_SOLICITADA);
                    cmd.Parameters.Add("oferta_compra_id", modelo.OFERTA_COMPRA_ID);
                    cmd.Parameters.Add("descrip_oferta", modelo.DESCRIP_OFERTA);
                    cmd.Parameters.Add("precio_costo", (decimal)modelo.PRECIO_COSTO);
                    cmd.Parameters.Add("ult_precio_compra", (decimal)modelo.ULT_PRECIO_COMPRA);
                    cmd.Parameters.Add("cant_facturada", modelo.CANT_FACTURADA);
                    cmd.Parameters.Add("cant_recibida", modelo.CANT_RECIBIDA);
                    cmd.Parameters.Add("cant_devuelta", modelo.CANT_DEVUELTA);
                    cmd.Parameters.Add("cant_malestado", modelo.CANT_MALESTADO);
                    cmd.Parameters.Add("cant_reposicion", modelo.CANT_REPOSICION);
                    cmd.Parameters.Add("precio_factura", (decimal)modelo.PRECIO_FACTURA);
                    cmd.Parameters.Add("descto_factura", (decimal)modelo.DESCTO_FACTURA);
                    cmd.Parameters.Add("descto_factura_ad1", (decimal)modelo.DESCTO_FACTURA_AD1);
                    cmd.Parameters.Add("descto_recibido", (decimal)modelo.DESCTO_RECIBIDO);
                    cmd.Parameters.Add("descto_recibido_ad1", (decimal)modelo.DESCTO_RECIBIDO_AD1);
                    cmd.Parameters.Add("descto_recibido_ad2", (decimal)modelo.DESCTO_RECIBIDO_AD2);
                    cmd.Parameters.Add("descto_recibido_ad3", (decimal)modelo.DESCTO_RECIBIDO_AD3);
                    cmd.Parameters.Add("descto_recibido_ad4", (decimal)modelo.DESCTO_RECIBIDO_AD4);
                    cmd.Parameters.Add("observacion_oc_det", modelo.OBSERVACION_OC_DET);
                    cmd.Parameters.Add("es_transfer", modelo.ES_TRANSFER);
                    if (modelo.IsPRECIO_FARMACIANull())
                    {
                        modelo.PRECIO_FARMACIA = 0;
                    }
                    cmd.Parameters.Add("precio_farmacia", modelo.PRECIO_FARMACIA);
                    cmd.Parameters.Add("CODIGO_PROVEEDOR", modelo.CODIGO_PROVEEDOR);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    //object objOut;
                    //SIFModelo.OrdenCompra.OrdenesCompraDataSetTableAdapters.ORDEN_COMPRA_DETTableAdapter TA = new SIFModelo.OrdenCompra.OrdenesCompraDataSetTableAdapters.ORDEN_COMPRA_DETTableAdapter();
                    //TA.SP_INS_ORDEN_COMPRA_DET(modelo.FOLIO_OC_ID, modelo.NUM_PARTIDA, modelo.USUARIO_ID, modelo.PROVEEDOR_ID, modelo.ARTICULO_ID, modelo.NOMBRE, modelo.CANT_SOLICITADA, modelo.OFERTA_COMPRA_ID,
                    //    modelo.DESCRIP_OFERTA, (decimal)modelo.PRECIO_COSTO, (decimal)modelo.ULT_PRECIO_COMPRA, modelo.CANT_FACTURADA, modelo.CANT_RECIBIDA, modelo.CANT_DEVUELTA, modelo.CANT_MALESTADO,
                    //    modelo.CANT_REPOSICION, (decimal)modelo.PRECIO_FACTURA, (decimal)modelo.DESCTO_FACTURA, (decimal)modelo.DESCTO_FACTURA_AD1, (decimal)modelo.DESCTO_RECIBIDO, (decimal)modelo.DESCTO_RECIBIDO_AD1, (decimal)modelo.DESCTO_RECIBIDO_AD2, out objOut);





                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            // return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static DataSet BuscaBonificaciones(string Folio, DateTime fecha1, DateTime fecha2)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet dsOrdenesCompra = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

            string sentencia = "SELECT BONIFICACION.FOLIO, BONIFICACION.LOTE, BONIFICACION.SUCURSAL_ID, BONIFICACION.FECHA_REG, BONIFICACION.TOTAL, " +
                        " BONIFICACION.CONCEPTO, BONIFICACION.DOC_REFERENCIA, BONIFICACION.USUARIO_ID, BONIFICACION.ACTIVO,  " +
                        " CAT_USUARIOS.NOMBRE AS CAT_USUARIOS_NOMBRE, CAT_USUARIOS.APELLIDOS,  " +
                        " CAT_SUCURSALES.NOMBRE AS CAT_SUCURSALES_NOMBRE " +
                        " FROM BONIFICACION INNER JOIN " +
                        " CAT_USUARIOS ON BONIFICACION.USUARIO_ID = CAT_USUARIOS.USUARIOS_ID INNER JOIN " +
                        " CAT_SUCURSALES ON BONIFICACION.SUCURSAL_ID = CAT_SUCURSALES.SUCURSALES_ID " +
            " WHERE BONIFICACION.FOLIO LIKE :Folio AND BONIFICACION.FECHA_REG BETWEEN :Fecha1 AND :Fecha2";
          //  sentencia = "select * from cat_articulos";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add(":Folio", "%" + Folio + "%");
                    cmd.Parameters.Add(":Fecha1", fecha1);
                    cmd.Parameters.Add(":Fecha2", fecha2);
                    //
                    using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                    {
                        td.Fill(dsOrdenesCompra.BONIFICACION);
                    }
                }
            }

            string folios = "";
            foreach (var item in dsOrdenesCompra.BONIFICACION)
            {
                folios += item.FOLIO + ",";
            }

            folios = folios.Trim(',');

            if (string.IsNullOrEmpty(folios))
            {
                return dsOrdenesCompra;
            }

            //orden de compra detalle

            string sentenciaDetalle = "SELECT BONIFICACION_DET.FOLIO, BONIFICACION_DET.LOTE, BONIFICACION_DET.SUCURSAL_ID, BONIFICACION_DET.PARTIDA, " +
                        " BONIFICACION_DET.ARTICULO_ID, BONIFICACION_DET.CANTIDAD, BONIFICACION_DET.PRECIO, BONIFICACION_DET.CONCEPTO_DET, " +
                        " BONIFICACION_DET.PRECIO_VTA, CAT_ARTICULOS.NOMBRE1, CAT_ARTICULOS.NOMBRE2 " +
                        " FROM BONIFICACION_DET INNER JOIN " +
                        " CAT_ARTICULOS ON BONIFICACION_DET.ARTICULO_ID = CAT_ARTICULOS.ARTICULO_ID " +
                        " WHERE BONIFICACION_DET.FOLIO IN (" + folios + ")";
           // sentenciaDetalle = "select * from lista_precios";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentenciaDetalle, cnx))
                {
                    using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                    {
                        td.Fill(dsOrdenesCompra.BONIFICACION_DET);
                    }
                }
            }
            return dsOrdenesCompra;

        }

        public static bool InsertaBonificacion(SIFModelo.OrdenCompra.OrdenesCompraDataSet.BONIFICACIONRow modelo)
        {
            string sentencia = "sp_ins_bonificacion";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("folio", modelo.FOLIO);
                    cmd.Parameters.Add("lote", modelo.LOTE);
                    cmd.Parameters.Add("sucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("fecha_reg", modelo.FECHA_REG);
                    cmd.Parameters.Add("total", modelo.TOTAL);
                    cmd.Parameters.Add("concepto", modelo.CONCEPTO);
                    cmd.Parameters.Add("doc_referencia", modelo.DOC_REFERENCIA);
                    cmd.Parameters.Add("usuario_id", modelo.USUARIO_ID);
                    cmd.Parameters.Add("activo", modelo.ACTIVO);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            // return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static bool InsertaBonificacionDetalle(SIFModelo.OrdenCompra.OrdenesCompraDataSet.BONIFICACION_DETRow modelo)
        {
            string sentencia = "sp_ins_bonificacion_det";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("folio", modelo.FOLIO);
                    cmd.Parameters.Add("lote", modelo.LOTE);
                    cmd.Parameters.Add("sucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("partida", modelo.PARTIDA);
                    cmd.Parameters.Add("articulo_id", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("cantidad", modelo.CANTIDAD);
                    cmd.Parameters.Add("precio", modelo.PRECIO);
                    cmd.Parameters.Add("concepto_det", modelo.CONCEPTO_DET);
                    cmd.Parameters.Add("precio_vta", modelo.PRECIO_VTA);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            // return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static int GeneraFolioBonificacion(int sucursal, string prefijoFolio)
        {
            object id;
            string sentencia = "SELECT NVL(COUNT(*),0) + 1 FROM BONIFICACION  WHERE TO_CHAR(FECHA_REG,'YY') = :prefijoFolio AND sucursal_id = :sucursalID";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("sucursalID", sucursal);
                    cmd.Parameters.Add("prefijoFolio", prefijoFolio);
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return int.Parse(id.ToString());
        }

        public static List<string> Ofertas(string articulo, string sucursal)
        {
            List<string> rows = new List<string>();

            string sentencia = "sp_get_ofertas_compras";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //PARAMETROS DE SALIDA
                    cmd.Parameters.Add("earticulo_id", articulo);
                    cmd.Parameters.Add("esucursal_id", sucursal);


                    //TIPO DE COMANDO
                    cmd.CommandType = CommandType.StoredProcedure;
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("REFCUR", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    OracleDataAdapter ad = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            string oferta = oreader[0].ToString();
                            rows.Add(oferta);
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);

                }

            }
            return rows;
        }

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow OrdenCompraPorFolio(string OrdenCompraFolio)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet dsOrdenCompra = new SIFModelo.OrdenCompra.OrdenCompraDataSet();

            //orden de compra detalle

            string sentencia = "SELECT * FROM orden_compra " +
                        " WHERE FOLIO_OC_ID = '" + OrdenCompraFolio + "'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                    {
                        td.Fill(dsOrdenCompra.ORDEN_COMPRA);
                    }
                }
            }
            if (dsOrdenCompra.ORDEN_COMPRA.Rows.Count == 0)
            {
                return null;
            }
            return dsOrdenCompra.ORDEN_COMPRA[0];
        }

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet OrdenCompraDetallesPorFolio(SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow ordenCompra)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet dsOrdenCompra = new SIFModelo.OrdenCompra.OrdenCompraDataSet();

            //orden de compra detalle
            try
            {
                string sentencia = "PKG_COMPRAS.SP_GET_ORDENES_COMPRA_DETALLES";

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_folio", ordenCompra.FOLIO_OC_ID);
                        cmd.Parameters.Add("p_sucursal_id", ordenCompra.SUCURSAL_ID);
                        OracleParameter p_HDR = cmd.Parameters.Add("HDR", OracleDbType.RefCursor, ParameterDirection.Output);

                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        OracleRefCursor rHDR = p_HDR.Value as OracleRefCursor;


                        using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                        {
                            dsOrdenCompra.EnforceConstraints = false;
                            td.Fill(dsOrdenCompra.ORDEN_COMPRA_DET, rHDR);

                            dsOrdenCompra.ORDEN_COMPRA_DET.PRECIO_FACTURAColumn.DefaultValue = 0;

                            if (!dsOrdenCompra.ORDEN_COMPRA_DET.Columns.Contains("NOMBRE1"))
                            {
                                dsOrdenCompra.ORDEN_COMPRA_DET.Columns.Add("NOMBRE1");

                            }

                            dsOrdenCompra.ORDEN_COMPRA_DET.Columns["NOMBRE1"].Expression = "NOMBRE";
                        }
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
                return null;
            }
            //if (dsOrdenCompra.ORDEN_COMPRA_DET.Rows.Count == 0)
            //{
            //    return null;
            //}
            return dsOrdenCompra;
        }

        public static bool ActualizaOrdenCompra(SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRARow modelo)
        {
            string sentencia = "sp_upd_orden_compra";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;


                    DateTime? fechaRecepcion = null;

                    if (!modelo.IsFECHA_RECEPCIONNull() && modelo.FECHA_RECEPCION != new DateTime())
                    {
                        fechaRecepcion = modelo.FECHA_RECEPCION;
                    }

                    //PARAMETROS
                    cmd.Parameters.Add("efolio_oc_id", modelo.FOLIO_OC_ID);
                    cmd.Parameters.Add("eusuario_id", modelo.USUARIO_ID);
                    cmd.Parameters.Add("eproveedor_id", modelo.PROVEEDOR_ID);
                    cmd.Parameters.Add("esucursal_id", modelo.SUCURSAL_ID);
                    cmd.Parameters.Add("efecha_alta", modelo.FECHA_ALTA);
                    cmd.Parameters.Add("efecha_recepcion", fechaRecepcion);
                    cmd.Parameters.Add("efecha_cierre", modelo.FECHA_CIERRE);
                    cmd.Parameters.Add("eusuario_id_autoriza", modelo.USUARIO_ID_AUTORIZA);
                    cmd.Parameters.Add("efecha_autoriza", modelo.FECHA_AUTORIZA);
                    cmd.Parameters.Add("eestado_oc", modelo.ESTADO_OC);
                    cmd.Parameters.Add("eobservacion_oc", modelo.OBSERVACION_OC);
                    cmd.Parameters.Add("efolio_oc_anterior", modelo.FOLIO_OC_ANTERIOR);
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow OrdenCompraDetallePorFolio(SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow modelo)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet dsOrdenCompra = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

            //orden de compra detalle

            string sentencia = "SELECT * FROM orden_compra_det " +
                        " WHERE FOLIO_OC_ID = '" + modelo.FOLIO_OC_ID + "'" +
                        " AND ARTICULO_ID = '" + modelo.ARTICULO_ID + "'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                    {
                        td.Fill(dsOrdenCompra.ORDEN_COMPRA_DET);
                    }
                }
            }
            if (dsOrdenCompra.ORDEN_COMPRA_DET.Rows.Count == 0)
            {
                return null;
            }
            return dsOrdenCompra.ORDEN_COMPRA_DET[0];
        }

        public static bool ActualizaOrdenCompraDetalle(SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow modelo)
        {
            string sentencia = "sp_upd_orden_compra_det";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("efolio_oc_id", modelo.FOLIO_OC_ID);
                    cmd.Parameters.Add("enum_partida", modelo.NUM_PARTIDA);
                    cmd.Parameters.Add("eusuario_id", modelo.USUARIO_ID);
                    cmd.Parameters.Add("eproveedor_id", modelo.PROVEEDOR_ID);
                    cmd.Parameters.Add("earticulo_id", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("enombre", modelo.NOMBRE);
                    cmd.Parameters.Add("ecant_solicitada", modelo.CANT_SOLICITADA);
                    cmd.Parameters.Add("eoferta_compra_id", modelo.OFERTA_COMPRA_ID);
                    cmd.Parameters.Add("edescrip_oferta", modelo.DESCRIP_OFERTA);
                    cmd.Parameters.Add("eprecio_costo", (decimal)modelo.PRECIO_COSTO);
                    cmd.Parameters.Add("eult_precio_compra", (decimal)modelo.ULT_PRECIO_COMPRA);
                    cmd.Parameters.Add("ecant_facturada", modelo.CANT_FACTURADA);
                    cmd.Parameters.Add("ecant_recibida", modelo.CANT_RECIBIDA);
                    cmd.Parameters.Add("ecant_devuelta", modelo.CANT_DEVUELTA);
                    cmd.Parameters.Add("ecant_malestado", modelo.CANT_MALESTADO);
                    cmd.Parameters.Add("ecant_reposicion", modelo.CANT_REPOSICION);
                    cmd.Parameters.Add("eprecio_factura", (decimal)modelo.PRECIO_FACTURA);
                    cmd.Parameters.Add("edescto_factura", (decimal)modelo.DESCTO_FACTURA);
                    cmd.Parameters.Add("edescto_factura_ad1", (decimal)modelo.DESCTO_FACTURA_AD1);
                    cmd.Parameters.Add("edescto_recibido", (decimal)modelo.DESCTO_RECIBIDO);
                    cmd.Parameters.Add("edescto_recibido_ad1", (decimal)modelo.DESCTO_RECIBIDO_AD1);
                    cmd.Parameters.Add("edescto_recibido_ad2", (decimal)modelo.DESCTO_RECIBIDO_AD2);
                    cmd.Parameters.Add("eobservacion_oc_det", modelo.OBSERVACION_OC_DET);
                    cmd.Parameters.Add("eprecio_farmacia", modelo.PRECIO_FARMACIA);
                    cmd.Parameters.Add("ecodigo_proveedor", modelo.CODIGO_PROVEEDOR);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    //object objOut;
                    //SIFModelo.OrdenCompra.OrdenesCompraDataSetTableAdapters.ORDEN_COMPRA_DETTableAdapter TA = new SIFModelo.OrdenCompra.OrdenesCompraDataSetTableAdapters.ORDEN_COMPRA_DETTableAdapter();
                    //TA.SP_INS_ORDEN_COMPRA_DET(modelo.FOLIO_OC_ID, modelo.NUM_PARTIDA, modelo.USUARIO_ID, modelo.PROVEEDOR_ID, modelo.ARTICULO_ID, modelo.NOMBRE, modelo.CANT_SOLICITADA, modelo.OFERTA_COMPRA_ID,
                    //    modelo.DESCRIP_OFERTA, (decimal)modelo.PRECIO_COSTO, (decimal)modelo.ULT_PRECIO_COMPRA, modelo.CANT_FACTURADA, modelo.CANT_RECIBIDA, modelo.CANT_DEVUELTA, modelo.CANT_MALESTADO,
                    //    modelo.CANT_REPOSICION, (decimal)modelo.PRECIO_FACTURA, (decimal)modelo.DESCTO_FACTURA, (decimal)modelo.DESCTO_FACTURA_AD1, (decimal)modelo.DESCTO_RECIBIDO, (decimal)modelo.DESCTO_RECIBIDO_AD1, (decimal)modelo.DESCTO_RECIBIDO_AD2, out objOut);


                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
                        {
                            // return false;
                        }
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.OFERTAS_COMPRAS_MAYORISTARow OfertaPorId(int ofertaId)
        {

            SIFModelo.OrdenCompra.OrdenCompraDataSet ordenCompraDS = new SIFModelo.OrdenCompra.OrdenCompraDataSet();

            string sentenciaOfertas = "SELECT ARTICULO_ID, " +
   " PROVEEDOR_ID, " +
   " FECHA_ALTA, " +
   " NOMBRE1, " +
   " LABORATORIO_ID, " +
   " PRECIO_FARMACIA, " +
   " PRECIO_PUBLICO, " +
   " TIPO_OFERTA, " +
   " DESCTO_OFRECIDO, " +
   " DESCRIP_DESCTO, " +
   " MINIMO_PIEZAS, " +
   " CANTIDAD_ACOMPRAR, " +
   " PIEZAS_CON_CARGO, " +
   " PIEZAS_SIN_CARGO, " +
   " ESTADO_ART_PROVEE, " +
   " ESTADO_ART_FLEMING, " +
   " DESCTO_ADICIONAL_PROVEE, " +
   " DESCTO_ESPECIAL_PROVEE, " +
   " FECHA_BAJA, " +
   " CODIGO_PROVEEDOR, " +
   " ESCALA " +
" FROM  OFERTAS_COMPRAS_MAYORISTA" +
" WHERE ARTICULO_ID = '" + ofertaId + "'  ";
            //" AND proveedor_id = :ProveedorID";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaOfertas, cnx))
                {
                    // cmd.Parameters.Add("ProveedorID", proveedor.ID);
                    //
                    using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                    {
                        td.Fill(ordenCompraDS.OFERTAS_COMPRAS_MAYORISTA);
                    }
                }
            }

            if (ordenCompraDS.OFERTAS_COMPRAS_MAYORISTA.Rows.Count > 0)
            {
                return ordenCompraDS.OFERTAS_COMPRAS_MAYORISTA.Rows[0] as SIFModelo.OrdenCompra.OrdenCompraDataSet.OFERTAS_COMPRAS_MAYORISTARow;
            }
            else
            {
                return null;
            }
        }

        public static global::SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow FacturaPorNumeroFactura(string NumeroFactura)
        {

            SIFModelo.OrdenCompra.OrdenesCompraDataSet ordenCompraDS = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

            string sentenciaOfertas = "SELECT *" +
" FROM FACTURA_PROVEEDOR" +
" WHERE NUM_FACTURA = '" + NumeroFactura + "'  ";
            //" AND proveedor_id = :ProveedorID";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaOfertas, cnx))
                {
                    // cmd.Parameters.Add("ProveedorID", proveedor.ID);
                    //
                    using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                    {
                        td.Fill(ordenCompraDS.FACTURA_PROVEEDOR);
                    }
                }
            }

            if (ordenCompraDS.FACTURA_PROVEEDOR.Rows.Count > 0)
            {
                return ordenCompraDS.FACTURA_PROVEEDOR.Rows[0] as SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow;
            }
            else
            {
                return null;
            }
        }

        public static global::SIFModelo.OrdenCompra.OrdenesCompraDataSet FacturasPorNumeroFactura(string NumeroFactura)
        {

            SIFModelo.OrdenCompra.OrdenesCompraDataSet ordenCompraDS = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

            string sentenciaOfertas = "SELECT NUM_FACTURA, " +
                                      " PROVEEDOR_ID," +
                                      " FOLIO_FACTURA_SAT, " +
                                      " FECHA_FACTURA, " +
                                      " FECHA_CARGA, " +
                                      " TOTAL_IMPORTE_FACTURA, " +
                                      " TOTAL_DESCTO, " +
                                      " TOTAL_IVA, " +
                                      " TOTAL_FACTURADO, " +
                                      " TOTAL_NETO_FACTURA, " +
                                      " TOTAL_DESCTO_SIVA, " +
                                      " TOTAL_DESCTO_CIVA, " +
                                      " TOTAL_IVA_DESCTO, " +
                                      " TOTAL_DESCTO_DESCTOS, " +
                                      " FOLIO_OC, " +
                                      " ESTADO " +
                " FROM FACTURA_PROVEEDOR" +
" WHERE NUM_FACTURA LIKE '" + NumeroFactura + "'  ";
            //" AND proveedor_id = :ProveedorID";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaOfertas, cnx))
                {
                    // cmd.Parameters.Add("ProveedorID", proveedor.ID);
                    //
                    using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                    {
                        td.Fill(ordenCompraDS.FACTURA_PROVEEDOR);
                    }
                }
            }

            if (ordenCompraDS.FACTURA_PROVEEDOR.Rows.Count > 0)
            {
                return ordenCompraDS;
            }
            else
            {
                return null;
            }
        }

        public static SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETDataTable FacturaDetallesPorNumeroFactura(SIFModelo.OrdenCompra.OrdenesCompraDataSet.COMPRASDataTable compras)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet dataset = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

            foreach (SIFModelo.OrdenCompra.OrdenesCompraDataSet.COMPRASRow item in compras)
            {

                string sentenciaOfertas = "SELECT * FROM FACTURA_PROVEEDOR_DET" +
" WHERE FACTURA_ID = '" + item.FACTURA + "'  ";
                //" AND proveedor_id = :ProveedorID";

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {

                    using (OracleCommand cmd = new OracleCommand(sentenciaOfertas, cnx))
                    {
                        // cmd.Parameters.Add("ProveedorID", proveedor.ID);
                        //
                        using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                        {
                            td.Fill(dataset.FACTURA_PROVEEDOR_DET);
                        }
                    }
                }

            }


            return dataset.FACTURA_PROVEEDOR_DET;
        }

        public static bool EliminaDetalle(SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow modelo)
        {
            string sentencia = "sp_del_orden_compra_det";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("efolio_oc_id", modelo.FOLIO_OC_ID);
                    cmd.Parameters.Add("enum_partida", modelo.NUM_PARTIDA);
                    cmd.Parameters.Add("earticulo_id", modelo.ARTICULO_ID);
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static decimal PrecioFarmacia(string articuloId, int proveedorId, int sucursalId)
        {
            object id = 0;
            string sentencia = "SELECT func_get_precio_farmacia('" + articuloId + "', " + proveedorId + ", " + sucursalId + ") FROM DUAL";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    try
                    {
                        cmd.Connection.Open();
                        id = cmd.ExecuteScalar();

                        if (!id.ToString().IsFloatPositive())
                        {
                            return 0;
                        }
                    }
                    catch (Exception)
                    {

                        return 0;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return decimal.Parse(id.ToString());
        }

        //public static SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORDataTable FacturasConcidentes(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow ordenCompra, SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETDataTable detalles)
        //{
        //    string listaArticulos = "";

        //    foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow datarow in detalles.Rows)
        //    {
        //         listaArticulos += "'" + datarow.ARTICULO_ID + "'|";
        //    }

        //    listaArticulos = listaArticulos.Trim('|');


        //    if (string.IsNullOrEmpty(listaArticulos))
        //    {
        //        listaArticulos = "''";
        //    }

        //    string Sentencia = "PKG_COMPRAS.SP_GET_FACTURAS_COINCIDENTES";

        //    SIFModelo.OrdenCompra.OrdenesCompraDataSet dataset = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

        //    try
        //    {
        //        using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
        //        {

        //            using (OracleCommand cmd = new OracleCommand(Sentencia, cnx))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.Add("p_proveedor_id", ordenCompra.PROVEEDOR_ID);
        //                cmd.Parameters.Add("p_lista_articulos", listaArticulos);
        //                //
        //                OracleParameter p_HDR = cmd.Parameters.Add("HDR", OracleDbType.RefCursor, ParameterDirection.Output);

        //                cmd.Connection.Open();
        //                cmd.ExecuteNonQuery();

        //                OracleRefCursor rHDR = p_HDR.Value as OracleRefCursor;


        //                using (OracleDataAdapter td = new OracleDataAdapter(cmd))
        //                {

        //                    td.Fill(dataset.FACTURA_PROVEEDOR, rHDR);

        //                    cmd.Connection.Close();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //       MessageBox.Show(ex.Message);
        //        return null;
        //    }

        //    foreach (SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow row in dataset.FACTURA_PROVEEDOR.Rows)
        //    {
        //        if (decimal.Parse(row["DETALLES"].ToString()) > 0)
        //        {
        //            decimal coincidencias = decimal.Parse(row["ARTICULOS"].ToString()) / decimal.Parse(row["DETALLES"].ToString());
        //           // coincidencias = coincidencias;
        //            row["COINCIDENCIAS"] = coincidencias;
        //        }
        //    }

        //    return dataset.FACTURA_PROVEEDOR;
        //}


        public static SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORDataTable FacturasConcidentes(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow ordenCompra, SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETDataTable detalles, DateTime fecha1, DateTime fecha2)
        {
            string listaArticulos = "";

            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow datarow in detalles.Rows)
            {
                listaArticulos += "'" + datarow.ARTICULO_ID + "',";
            }

            listaArticulos = listaArticulos.Trim(',');


            if (string.IsNullOrEmpty(listaArticulos))
            {
                listaArticulos = "''";
            }

            string Sentencia = "SELECT FACTURA_PROVEEDOR.*, " +
            " (SELECT COUNT(articulo_id)   " +
            " FROM factura_proveedor_det " +
            " WHERE " +
            " num_factura = factura_proveedor.num_factura " +
            " AND " +
            " ARTICULO_ID IN(" + listaArticulos + ")) ARTICULOS , " +
                //   " ( SELECT COUNT(articulo_id) FROM factura_proveedor_det  WHERE  num_factura = factura_proveedor.num_factura ) DETALLES , " +
            " " + detalles.Rows.Count + " DETALLES," +
            " 0.00 COINCIDENCIAS  " +
            " FROM  " +
            " FACTURA_PROVEEDOR  " +
            " WHERE FACTURA_PROVEEDOR.PROVEEDOR_ID = " + ordenCompra.PROVEEDOR_ID + " " +
            " AND FACTURA_PROVEEDOR.FECHA_FACTURA >= TO_DATE('" + fecha1.ToString("dd/MM/yyyy 00:00:00") + "', 'DD/MM/YYYY HH24:MI:SS') AND FACTURA_PROVEEDOR.FECHA_FACTURA <= TO_DATE('" + fecha2.ToString("dd/MM/yyyy 23:59:59") + "', 'DD/MM/YYYY HH24:MI:SS')" +
                // " AND ESTADO = 'A' " +
            " ORDER BY ARTICULOS DESC, " +
            " FECHA_FACTURA DESC ";

            SIFModelo.OrdenCompra.OrdenesCompraDataSet dataset = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(Sentencia, cnx))
                {
                    // cmd.Parameters.Add("ProveedorID", proveedor.ID);
                    //
                    using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                    {
                        try
                        {
                            dataset.FACTURA_PROVEEDOR.Clear();
                            td.Fill(dataset.FACTURA_PROVEEDOR);
                        }
                        catch
                        {
                            cmd.Connection.Close();
                        }

                    }
                }
            }

            foreach (SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow row in dataset.FACTURA_PROVEEDOR.Rows)
            {
                if (decimal.Parse(row["ARTICULOS"].ToString()) > 0)
                {
                    decimal coincidencias = decimal.Parse(row["ARTICULOS"].ToString()) / (decimal)detalles.Rows.Count;
                    // coincidencias = coincidencias;
                    row["COINCIDENCIAS"] = coincidencias;
                }
            }

            return dataset.FACTURA_PROVEEDOR;
        }

        public static SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow FacturaConcidente(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow ordenCompra, SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETDataTable detalles)
        {
            string listaArticulos = "";

            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow datarow in detalles.Rows)
            {
                listaArticulos += "'" + datarow.ARTICULO_ID + "',";
            }

            listaArticulos = listaArticulos.Trim(',');


            if (string.IsNullOrEmpty(listaArticulos))
            {
                listaArticulos = "''";
            }

            string Sentencia = "SELECT FACTURA_PROVEEDOR.*, " +
            " (SELECT COUNT(articulo_id)   " +
            " FROM factura_proveedor_det " +
            " WHERE " +
            " num_factura = factura_proveedor.num_factura " +
            " AND " +
            " ARTICULO_ID IN(" + listaArticulos + ")) ARTICULOS , " +
            " ( SELECT COUNT(articulo_id) FROM factura_proveedor_det  WHERE  num_factura = factura_proveedor.num_factura ) DETALLES , " +
            " 0.00 COINCIDENCIAS  " +
            " FROM  " +
            " FACTURA_PROVEEDOR  " +
            " WHERE FACTURA_PROVEEDOR.PROVEEDOR_ID = " + ordenCompra.PROVEEDOR_ID + " " +
            " AND ESTADO = 'A' " +
            " ORDER BY ARTICULOS DESC, " +
            " FECHA_FACTURA DESC ";

            SIFModelo.OrdenCompra.OrdenesCompraDataSet dataset = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(Sentencia, cnx))
                {
                    // cmd.Parameters.Add("ProveedorID", proveedor.ID);
                    //
                    using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                    {
                        try
                        {
                            td.Fill(dataset.FACTURA_PROVEEDOR);

                            if (dataset.FACTURA_PROVEEDOR.Count > 0)
                            {
                                return dataset.FACTURA_PROVEEDOR[0];
                            }

                        }
                        catch
                        {
                            cmd.Connection.Close();
                        }

                    }
                }
            }

            //foreach (SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow row in dataset.FACTURA_PROVEEDOR.Rows)
            //{
            //    if (decimal.Parse(row["DETALLES"].ToString()) > 0)
            //    {
            //        decimal coincidencias = decimal.Parse(row["ARTICULOS"].ToString()) / decimal.Parse(row["DETALLES"].ToString());
            //        coincidencias = coincidencias;
            //        row["COINCIDENCIAS"] = coincidencias;
            //    }
            //}

            //return dataset.FACTURA_PROVEEDOR;
            return null;
        }

        public static SIFModelo.OrdenCompra.OrdenesCompraDataSet FacturaDetallesPorNumeroFactura(SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow factura)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet dataset = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

            string sentenciaOfertas = "SELECT * FROM FACTURA_PROVEEDOR_DET" +
" WHERE NUM_FACTURA = '" + factura.NUM_FACTURA + "'  ";
            //" AND proveedor_id = :ProveedorID";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaOfertas, cnx))
                {
                    // cmd.Parameters.Add("ProveedorID", proveedor.ID);
                    //
                    using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                    {
                        td.Fill(dataset.FACTURA_PROVEEDOR_DET);
                    }
                }
            }

            /* if (factura.PROVEEDOR_ID == 99064)
             {
                 foreach (SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETRow row in dataset.FACTURA_PROVEEDOR_DET.Rows)
                 {
                     if (row.IVA > 0)
                     { 
                    
                     }
                 }
             }
             */
            return dataset;

        }

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.CTL_ARCHIVOS_PROVEEDORDataTable ArchivosProveedores(SIFModelo.OrdenCompra.OrdenCompraDataSet ds)
        {
            //SIFModelo.OrdenCompra.OrdenCompraDataSet ds = new SIFModelo.OrdenCompra.OrdenCompraDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.CTL_ARCHIVOS_PROVEEDORTableAdapter ta = new SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.CTL_ARCHIVOS_PROVEEDORTableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;
                //ds.CTL_ARCHIVOS_PROVEEDOR.Constraints.Clear();
                ta.FillByUltimoArchivo(ds.CTL_ARCHIVOS_PROVEEDOR);
            }

            return ds.CTL_ARCHIVOS_PROVEEDOR;
        }

        public static bool ExportaOfertasSABA(SIFModelo.OrdenCompra.OrdenCompraDataSet.CTL_ARCHIVOS_PROVEEDORRow archivo)
        {
            string sentencia = "SP_EXP_OFERTAS_SABA";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("v_proveedor_id", archivo.PROVEEDOR_ID);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static bool ExportaOfertasEspecialesSABA(SIFModelo.OrdenCompra.OrdenCompraDataSet.CTL_ARCHIVOS_PROVEEDORRow archivo)
        {
            string sentencia = "SP_EXP_OFTAESP_SABA";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("v_proveedor_id", archivo.PROVEEDOR_ID);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }
        public static bool ExportaOfertasDROGUEROS(SIFModelo.OrdenCompra.OrdenCompraDataSet.CTL_ARCHIVOS_PROVEEDORRow row)
        {
            string sentencia = "SP_EXP_OFERTAS_DROGUEROS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("v_proveedor_id", row.PROVEEDOR_ID);

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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static bool ExportaOfertasMARZAM(SIFModelo.OrdenCompra.OrdenCompraDataSet.CTL_ARCHIVOS_PROVEEDORRow row)
        {
            string sentencia = "SP_EXP_OFERTAS_MARZAM";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("v_proveedor_id", row.PROVEEDOR_ID);
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static int GeneraFolioCompra(SIFModelo.Sucursal sucursal, string prefijoFolio)
        {
            object id;
            string sentencia = "SELECT NVL(COUNT(*),0) + 1 FROM COMPRAS  WHERE TO_CHAR(FECHA,'YY') = :prefijoFolio"; // AND PROVEEDOR_ID = :sucursalID";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.Parameters.Add("sucursalID", sucursal.SucursalesID);
                    cmd.Parameters.Add("prefijoFolio", prefijoFolio);
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return int.Parse(id.ToString());
        }

        public static SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETDataTable FacturaDetallesPorNumeroFactura(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASDataTable compras)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet dataset = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow item in compras)
            {

                string sentenciaOfertas = "SELECT * FROM FACTURA_PROVEEDOR_DET" +
" WHERE FACTURA_ID = '" + item.FACTURA + "'  ";
                //" AND proveedor_id = :ProveedorID";

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {

                    using (OracleCommand cmd = new OracleCommand(sentenciaOfertas, cnx))
                    {
                        // cmd.Parameters.Add("ProveedorID", proveedor.ID);
                        //
                        using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                        {
                            td.Fill(dataset.FACTURA_PROVEEDOR_DET);
                        }
                    }
                }

            }


            return dataset.FACTURA_PROVEEDOR_DET;

        }

        public static bool ExportaFacturasSABA(SIFModelo.OrdenCompra.OrdenCompraDataSet.CTL_ARCHIVOS_PROVEEDORRow row)
        {
            string sentencia = "SP_EXP_FACTURAS_SABA";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("v_proveedor_id", row.PROVEEDOR_ID);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static bool ExportaFacturasMARZAM(SIFModelo.OrdenCompra.OrdenCompraDataSet.CTL_ARCHIVOS_PROVEEDORRow row)
        {
            string sentencia = "PKG_MARZAM.SP_INS_FACTURAS"; //"SP_EXP_FACTURAS_MARZAM";
            int exportadas = 0;
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("p_prov_id", row.PROVEEDOR_ID);
                    OracleParameter p_no_f1 = cmd.Parameters.Add("OutParam", OracleDbType.Int32, ParameterDirection.Output);

                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        if (p_no_f1.Value.ToString().IsInteger())
                        {
                            exportadas = System.Convert.ToInt32(p_no_f1.Value.ToString());
                            if (exportadas == 0)
                            {
                                return false;
                            }
                        }

                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }
                }
            }

            UPD_FACT_IMP(row, exportadas);
            return true;
        }

        public static bool UPD_FACT_IMP(SIFModelo.OrdenCompra.OrdenCompraDataSet.CTL_ARCHIVOS_PROVEEDORRow row, int facturas_importadas)
        {
            string sentencia = "PKG_MARZAM.SP_UPD_FACT_IMP"; //"SP_EXP_FACTURAS_MARZAM";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {

                    cmd.Parameters.Add("p_PROVEEDOR_ID", row.PROVEEDOR_ID);
                    cmd.Parameters.Add("p_NOM_ARCHIVO", row.NOM_ARCHIVO);
                    cmd.Parameters.Add("p_Msg", "FACTURAS IMPORTADAS " + facturas_importadas);
                    OracleParameter p_no_f1 = cmd.Parameters.Add("outparam", OracleDbType.Int32, ParameterDirection.Output);

                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        if (p_no_f1.Value.ToString().IsInteger())
                        {
                            if (System.Convert.ToInt32(p_no_f1.Value.ToString()) == 0)
                            {
                                return false;
                            }
                        }

                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }
        public static bool ExportaFacturasDROGUEROS(SIFModelo.OrdenCompra.OrdenCompraDataSet.CTL_ARCHIVOS_PROVEEDORRow row)
        {
            string sentencia = "SP_EXP_FACTURAS_DROGUEROS";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //  cmd.Parameters.Add("v_proveedor_id", row.PROVEEDOR_ID);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }



        public static bool AsociaFactura(SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow factura)
        {
            string sentencia = "UPDATE FACTURA_PROVEEDOR SET FOLIO_OC = '" + factura.FOLIO_OC + "', ESTADO = 'C' WHERE NUM_FACTURA = '" + factura.NUM_FACTURA + "' AND PROVEEDOR_ID = " + factura.PROVEEDOR_ID + " ";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow FacturaPorNumeroFactura(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OrdenCompra)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet ordenCompraDS = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

            string sentenciaOfertas = "SELECT *" +
" FROM FACTURA_PROVEEDOR" +
" WHERE FOLIO_OC = '" + OrdenCompra.FOLIO_OC_ID + "'  ";
            //" AND proveedor_id = :ProveedorID";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaOfertas, cnx))
                {
                    // cmd.Parameters.Add("ProveedorID", proveedor.ID);
                    //
                    using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                    {
                        td.Fill(ordenCompraDS.FACTURA_PROVEEDOR);
                    }
                }
            }

            if (ordenCompraDS.FACTURA_PROVEEDOR.Rows.Count > 0)
            {
                return ordenCompraDS.FACTURA_PROVEEDOR.Rows[0] as SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow;
            }
            else
            {
                return null;
            }
        }

        public static object ArchivosFacturasProveedores(SIFModelo.OrdenCompra.OrdenCompraDataSet ds)
        {
            //SIFModelo.OrdenCompra.OrdenCompraDataSet ds = new SIFModelo.OrdenCompra.OrdenCompraDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.CTL_ARCHIVOS_PROVEEDORTableAdapter ta = new SIFModelo.OrdenCompra.OrdenCompraDataSetTableAdapters.CTL_ARCHIVOS_PROVEEDORTableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;

                ta.FillByUltimoArchivoFacturas(ds.CTL_ARCHIVOS_PROVEEDOR);
            }

            return ds.CTL_ARCHIVOS_PROVEEDOR;
        }


        public static decimal PrecioFarmaciaSaba(SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocdRow)
        {
            string tabla = "EXT_CAT_";

            switch (ocdRow.PROVEEDOR_ID)
            {
                case 12:
                    tabla += "SABA";
                    break;
            }

            string sentenciaOfertas = "SELECT *" +
" FROM " + tabla +
" WHERE codigo_ean = '" + ocdRow.ARTICULO_ID
 + "'  ";

            DataTable dt = new DataTable(tabla);
            //" AND proveedor_id = :ProveedorID";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaOfertas, cnx))
                {
                    // cmd.Parameters.Add("ProveedorID", proveedor.ID);
                    //
                    using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                    {
                        td.Fill(dt);
                    }
                }
            }

            if (dt.Rows.Count > 0)
            {
                var precioFarmacia = dt.Rows[0]["precio_farmacia"];
                if (precioFarmacia.ToString().IsFloat())
                {
                    decimal precio = (decimal.Parse(precioFarmacia.ToString()) / 100);
                    return precio;
                }
            }

            return 0;

        }

        public static bool ExportaOfertasNADRO(SIFModelo.OrdenCompra.OrdenCompraDataSet.CTL_ARCHIVOS_PROVEEDORRow archivo)
        {
            string sentencia = "SP_EXP_OFERTAS_NADRO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("v_proveedor_id", archivo.PROVEEDOR_ID);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static bool ExportaOfertasEspecialNADRO(SIFModelo.OrdenCompra.OrdenCompraDataSet.CTL_ARCHIVOS_PROVEEDORRow archivo)
        {
            string sentencia = "SP_EXP_OFTAESP_NADRO";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("v_proveedor_id", archivo.PROVEEDOR_ID);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static bool ActivaArchivoOFertas(SIFModelo.OrdenCompra.OrdenCompraDataSet.CTL_ARCHIVOS_PROVEEDORRow row)
        {
            string sentencia = "UPDATE CTL_ARCHIVOS_PROVEEDOR SET activo = 'S', FECHA_CARGA = SYSDATE WHERE nom_archivo = '" + row.NOM_ARCHIVO + "' AND PROVEEDOR_ID = " + row.PROVEEDOR_ID + " ";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static SIFModelo.OrdenCompra.OfertaCompra OfertaEspecial(string articuloID, string sucursal)
        {
            SIFModelo.OrdenCompra.OfertaCompra oferta = new SIFModelo.OrdenCompra.OfertaCompra();

            string sentenciaOfertas = "SELECT * FROM  ext_oftaesp_saba " +
" WHERE CODIGO_ARTICULO = '" + articuloID + "' AND fec_ini_vigencia <= sysdate " +
" AND NVL(fec_fin_vigencia, TO_DATE('9999-01-01 00:00:00','YYYY-MM-DD HH24:MI:SS'))  >= sysdate ";
            //" AND proveedor_id = :ProveedorID";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentenciaOfertas, cnx))
                {
                    cnx.Open();
                    OracleDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        oferta.ArticuloID = rd["CODIGO_ARTICULO"].ToString();
                        oferta.DescuentoOfrecido = System.Convert.ToDecimal(rd["oferta"]);
                        oferta.Nombre1 = rd["DESCRIPCION"].ToString();
                        oferta.DescripcionDescuento = "OFERTA ESPECIAL";
                        return oferta;
                    }
                    cnx.Close();
                    cnx.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }
            }

            return null;
        }

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow GeneraCompraArticulo(SIFModelo.OrdenCompra.OrdenCompraDataSet dsArticuloCompra, SIFModelo.Sucursal sucursal, SIFModelo.Usuario usuario, string ArticuloID)
        {
            OracleCommand cmd = null;
            try
            {
                dsArticuloCompra.ORDEN_COMPRA_DET.Clear();

                //LLENAMOS LOS ARTICULOS QUE NO SON ESPECIALES
                string sentencia = "PKG_COMPRAS.SP_GET_COMPRAS_ARTICULOS_ART";

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    cmd = new OracleCommand(sentencia, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_sucursal_id", sucursal.SucursalesID);
                    cmd.Parameters.Add("p_articulo_id", ArticuloID);
                    //cmd.Parameters.Add("p_tipo_compra", "");


                    OracleParameter p_no_f1 = cmd.Parameters.Add("HDR", OracleDbType.RefCursor, ParameterDirection.Output);
                    //OracleParameter p_f1 = cmd.Parameters.Add("HDR_F1", OracleDbType.RefCursor, ParameterDirection.Output);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    OracleRefCursor rNoF1 = p_no_f1.Value as OracleRefCursor;
                    //OracleRefCursor rF1 = p_f1.Value as OracleRefCursor;

                    OracleDataAdapter oda = new OracleDataAdapter();
                    dsArticuloCompra.EnforceConstraints = false;
                    DataTable dt = new DataTable();

                    dsArticuloCompra.ORDEN_COMPRA_DET.NOMBREColumn.DefaultValue = "";
                    dsArticuloCompra.ORDEN_COMPRA_DET.DESCRIP_OFERTAColumn.DefaultValue = "";
                    dsArticuloCompra.ORDEN_COMPRA_DET.ULT_PRECIO_COMPRAColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.MEJOR_OFERTA_COSTOColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.CANT_SOLICITADAColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.OFERTA_COMPRA_IDColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.CANT_DEVUELTAColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.CANT_MALESTADOColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.CANT_REPOSICIONColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.OBSERVACION_OC_DETColumn.DefaultValue = "";
                    dsArticuloCompra.ORDEN_COMPRA_DET.NUM_PARTIDAColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.USUARIO_IDColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.PRECIO_COSTOColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.CANT_FACTURADAColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.CANT_RECIBIDAColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.DESCTO_FACTURAColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.DESCTO_FACTURA_AD1Column.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.DESCTO_RECIBIDOColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.DESCTO_RECIBIDO_AD1Column.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.DESCTO_RECIBIDO_AD2Column.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.EXISTENCIA_GENERALColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.IMPORTEColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.EXISTENCIASColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.PRECIO_FARMACIAColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.LABORATORIO_IDColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.OFERTASColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.PUNTO_DE_REORDENColumn.DefaultValue = 0;
                    dsArticuloCompra.ORDEN_COMPRA_DET.TIPO_MEDICAMENTO_CVEColumn.DefaultValue = "";
                    dsArticuloCompra.ORDEN_COMPRA_DET.CODIGO_PROVEEDORColumn.DefaultValue = "";
                    dsArticuloCompra.ORDEN_COMPRA_DET.NOMBREColumn.DefaultValue = "";
                    dsArticuloCompra.ORDEN_COMPRA_DET.PRECIO_FARMACIAColumn.DefaultValue = 0;

                    oda.Fill(dsArticuloCompra.ORDEN_COMPRA_DET, rNoF1);

                    dsArticuloCompra.ORDEN_COMPRA_DET.NOMBREColumn.Expression = "NOMBRE1";

                    // dsOrdenesCompra.ORDEN_COMPRA_DET.COSTO_ULT_COMPRAColumn.DefaultValue = "";

                    //dsOrdenesCompra.ORDEN_COMPRA_DET.OC_SEGMENTAColumn.DefaultValue = "";
                    //dsOrdenesCompra.ORDEN_COMPRA_DET.OC_SEGMENTAColumn.DefaultValue = 0;

                    //oda.Fill(dsOrdenesCompra.ORDEN_COMPRA_DET, rF1);
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);

                return null;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
               //OracleConnection.ClearPool(cmd.Connection);
            }

            if (dsArticuloCompra.ORDEN_COMPRA_DET.Count > 0)
            {
                return dsArticuloCompra.ORDEN_COMPRA_DET[0];
            }

            return null;

        }

        public static DataTable OfertasProveedor(String oferta, SIFModelo.Sucursal sucursal)
        {
            OracleCommand cmd = null;
            DataTable dt = new DataTable();

            try
            {
                //LLENAMOS LOS ARTICULOS QUE NO SON ESPECIALES
                string sentencia = "PKG_COMPRAS.SP_GET_OFERTAS_PROVEEDOR";

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    cmd = new OracleCommand(sentencia, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_sucursal_id", sucursal.SucursalesID);
                    cmd.Parameters.Add("p_articulo", "%" + oferta.ToUpper() + "%");
                    //cmd.Parameters.Add("p_tipo_compra", "");


                    OracleParameter p_no_f1 = cmd.Parameters.Add("HDR", OracleDbType.RefCursor, ParameterDirection.Output);
                    //OracleParameter p_f1 = cmd.Parameters.Add("HDR_F1", OracleDbType.RefCursor, ParameterDirection.Output);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    OracleRefCursor rNoF1 = p_no_f1.Value as OracleRefCursor;
                    //OracleRefCursor rF1 = p_f1.Value as OracleRefCursor;

                    OracleDataAdapter oda = new OracleDataAdapter();

                    oda.Fill(dt, rNoF1);
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);

                return null;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
               //OracleConnection.ClearPool(cmd.Connection);
            }

            return dt;
        }

        public static bool AsociaFacturaAutomatica()
        {
            OracleCommand cmd = null;
            DataTable dt = new DataTable();

            try
            {
                //LLENAMOS LOS ARTICULOS QUE NO SON ESPECIALES
                string sentencia = "PKG_COMPRAS.SP_APLICA_FACTURAS_PROV";

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    cmd = new OracleCommand(sentencia, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter p_no_f1 = cmd.Parameters.Add("OutParam", OracleDbType.Int32, ParameterDirection.Output);
                    //OracleParameter p_f1 = cmd.Parameters.Add("HDR_F1", OracleDbType.RefCursor, ParameterDirection.Output);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    return true;

                    //OracleRefCursor rNoF1 = p_no_f1.Value as OracleRefCursor;
                    ////OracleRefCursor rF1 = p_f1.Value as OracleRefCursor;

                    //OracleDataAdapter oda = new OracleDataAdapter();

                    //oda.Fill(dt, rNoF1);
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);

                return false;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
               //OracleConnection.ClearPool(cmd.Connection);
            }

            return true;
        }

        public static bool AsociaFactura(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OrdenCompra, SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow factura, string opcion = "A")
        {
            string sentencia = "PKG_COMPRAS.SP_APLICA_FACTURAS_PROV";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("No_Cliente", factura.CLIENTE);
                    cmd.Parameters.Add("No_Factura", factura.NUM_FACTURA);
                    cmd.Parameters.Add("Folio_OC", OrdenCompra.FOLIO_OC_ID);
                    cmd.Parameters.Add("Opc", opcion);

                    OracleParameter p_no_f1 = cmd.Parameters.Add("OutParam", OracleDbType.Int32, ParameterDirection.Output);

                    cmd.CommandType = CommandType.StoredProcedure;
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
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return true;
        }

        public static string ExportaCatalogoMayorista(int proveedorID)
        {
            string sentencia = "PKG_SABA.sp_exp_cat_articulos";

            if (proveedorID == 99035)
            {
                sentencia = "PKG_DROGUEROS.sp_exp_cat_articulos";
            }

            if (proveedorID == 99169)
            {
                sentencia = "PKG_MARZAM.sp_exp_cat_articulos";
            }

            if (proveedorID == 99064)
            {
                sentencia = "PKG_NADRO.sp_exp_cat_articulos";
            }

            string str = "";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    OracleParameter p_catalogo = cmd.Parameters.Add("Catalogo", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OracleDataAdapter oda = new OracleDataAdapter();
                    DataSet ds = new DataSet();
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleRefCursor rNoF1 = p_catalogo.Value as OracleRefCursor;

                        oda.Fill(ds, rNoF1);
                    }
                    catch (Exception)
                    {
                        return "";
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }


                    if (ds.Tables[0].Columns.Count > 0)
                    {
                        foreach (DataColumn c in ds.Tables[0].Columns)
                        {
                            str += c.ColumnName + ",";
                        }

                        str = str.Trim(new char[] { ',' });
                        str += '\n';

                        int cols = ds.Tables[0].Columns.Count - 1;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            for (int cont = 0; cont < cols; cont++)
                            {
                                str += row[cont].ToString() + ",";
                            }
                            str = str.Trim(new char[] { ',' });
                            str += '\n';
                        }
                    }
                }
            }
            return str;
        }
        public static DataTable IncidenciasCompras(DateTime fecha1, string proveedor)
        {
            string sentencia = "SELECT * " +
                        " FROM FARMACIA.reporte_incidencias_compras";
            sentencia += " WHERE FECHA = TO_DATE('" + fecha1.ToString("dd/MM/yyyy HH:mm:ss") + "', 'DD/MM/YYYY HH24:MI:SS') order by folio_compra, articulo_id";// AND TO_DATE(FECHA,'DD/MM/YYYY') <= TO_DATE('" + fecha2.ToString("dd/MM/yyyy HH:mm:ss") + "','DD/MM/YYYY HH24:MI:SS')";

            if (!string.IsNullOrEmpty(proveedor))
            {
                sentencia += " AND compra_con_mayorista = '" + proveedor + "'";
            }


            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {

                    OracleDataAdapter oda = new OracleDataAdapter();
                    oda.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        oda.Fill(ds, "REPORTE");
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }


                    if (ds.Tables[0].Columns.Count > 0)
                    {
                        //foreach (DataColumn c in ds.Tables[0].Columns)
                        //{
                        //    str += c.ColumnName + ",";
                        //}

                        //str = str.Trim(new char[] { ',' });
                        //str += '\n';

                        //int cols = ds.Tables[0].Columns.Count - 1;
                        //foreach (DataRow row in ds.Tables[0].Rows)
                        //{
                        //    for (int cont = 0; cont < cols; cont++)
                        //    {
                        //        str += row[cont].ToString() + ",";
                        //    }
                        //    str = str.Trim(new char[] { ',' });
                        //    str += '\n';
                        //}
                        return ds.Tables[0];
                    }
                }
            }
            return null;
        }
        public static DataTable facturasRecepcion(DateTime fecha1, DateTime fecha2, string proveedor)
        {
            string sentencia = "SELECT * " +
                        " FROM FARMACIA.CS_FACTURAS_RECEPCION";
            sentencia += " WHERE TO_DATE(FECHA,'DD/MM/YYYY') >= TO_DATE('" + fecha1.ToString("dd/MM/yyyy HH:mm:ss") + "', 'DD/MM/YYYY HH24:MI:SS') AND TO_DATE(FECHA,'DD/MM/YYYY') <= TO_DATE('" + fecha2.ToString("dd/MM/yyyy HH:mm:ss") + "','DD/MM/YYYY HH24:MI:SS')";

            if (! string.IsNullOrEmpty(proveedor))
            {
                sentencia += " AND proveedor = '" + proveedor + "'";
            }


            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                   
                    OracleDataAdapter oda = new OracleDataAdapter();
                    oda.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        oda.Fill(ds,"REPORTE");
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }


                    if (ds.Tables[0].Columns.Count > 0)
                    {
                        //foreach (DataColumn c in ds.Tables[0].Columns)
                        //{
                        //    str += c.ColumnName + ",";
                        //}

                        //str = str.Trim(new char[] { ',' });
                        //str += '\n';

                        //int cols = ds.Tables[0].Columns.Count - 1;
                        //foreach (DataRow row in ds.Tables[0].Rows)
                        //{
                        //    for (int cont = 0; cont < cols; cont++)
                        //    {
                        //        str += row[cont].ToString() + ",";
                        //    }
                        //    str = str.Trim(new char[] { ',' });
                        //    str += '\n';
                        //}
                        return ds.Tables[0];
                    }
                }
            }
            return null;
        }

        public static bool Insertar_ctl_oc(string folio_oc, string usuario, string equipo, string estado_old, string estado_new)
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_CAMBIAR_ESTADO_OC.SP_INSERTAR_DATOS_OC";
                cmd.BindByName = true;

                cmd.Parameters.Add("folio_oc", OracleDbType.Varchar2, folio_oc, ParameterDirection.Input);
                cmd.Parameters.Add("usuario", OracleDbType.Varchar2, usuario, ParameterDirection.Input);
                cmd.Parameters.Add("equipo", OracleDbType.Varchar2, equipo, ParameterDirection.Input);
                cmd.Parameters.Add("estado_old", OracleDbType.Varchar2, estado_old, ParameterDirection.Input);
                cmd.Parameters.Add("estado_new", OracleDbType.Varchar2, estado_new, ParameterDirection.Input);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR => " + e);
                return false;
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return true;
        }

        public static bool Actualizar_oc(string folio_oc, string estado)
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_CAMBIAR_ESTADO_OC.SP_ACTUALIZAR_OC";
                cmd.BindByName = true;

                cmd.Parameters.Add("folio_oc", OracleDbType.Varchar2, folio_oc, ParameterDirection.Input);
                cmd.Parameters.Add("estado", OracleDbType.Varchar2, estado, ParameterDirection.Input);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR => " + e);
                return false;
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return true;
        }

        public static void Verificar_ctl_oc(string folio_oc, out string mensaje, out int cantidad, out string estado_old)
        {           
            cantidad = 0;
            int contador = 0;
            mensaje = String.Empty;
            estado_old = String.Empty;            
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_CAMBIAR_ESTADO_OC.SP_VERIFICAR_OC";
                cmd.BindByName = true;

                OracleParameter datos = cmd.Parameters.Add("datos", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("folio_oc", OracleDbType.Varchar2, folio_oc, ParameterDirection.Input);
                OracleDataReader reader = cmd.ExecuteReader();
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cantidad = reader.GetInt32(reader.GetOrdinal("CANTIDAD"));
                        estado_old = reader.GetString(reader.GetOrdinal("ESTADO_OC_OLD")).ToString();
                        contador += 1;
                    }
                }
                else
                    mensaje = "No existe en base de datos";

                if (contador == 1)
                    mensaje = "1";

                if (contador > 1)
                    mensaje = "Existe más de una línea";

                reader.Close();
                reader.Dispose();
              
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR => " + e);
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }


        }


    }
}
