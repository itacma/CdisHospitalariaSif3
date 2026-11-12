using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace SIFDatos.OrdenCompra
{
    public class ManejoDescuentos
    {

        public static SIFModelo.OrdenCompra.OrdenesCompraDataSet Buscar(string Nombre, DateTime fecha1, DateTime fecha2)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet dsOrdenesCompra = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();
            
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSetTableAdapters.LISTA_OFERTAS_VENTATableAdapter ta = new SIFModelo.OrdenCompra.OrdenesCompraDataSetTableAdapters.LISTA_OFERTAS_VENTATableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;

                ta.FillByFechasNombre(dsOrdenesCompra.LISTA_OFERTAS_VENTA, "%" +  Nombre + "%", fecha1, fecha2);
            }

            return dsOrdenesCompra;
        }

        public static SIFModelo.OrdenCompra.OrdenesCompraDataSet BuscarPorArticuloLista(SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow modelo)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet dsOrdenesCompra = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSetTableAdapters.LISTA_OFERTAS_VENTA_DETALLETableAdapter ta = new SIFModelo.OrdenCompra.OrdenesCompraDataSetTableAdapters.LISTA_OFERTAS_VENTA_DETALLETableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;

                ta.FillByARTICULO_ID(dsOrdenesCompra.LISTA_OFERTAS_VENTA_DETALLEDataTable, modelo.ARTICULO_ID, modelo.LISTA_OFERTAS_ID);
            }

            return dsOrdenesCompra;
        }

        public static bool InsertaDetalle(SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow modelo)
        {
            string sentencia = "SP_INS_LISTA_OFERTAS_VTA_DET";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("lista_ofertas_id", modelo.LISTA_OFERTAS_ID);
                    cmd.Parameters.Add("articulo_id", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("partida", modelo.PARTIDA);
                    cmd.Parameters.Add("cantidad", modelo.CANTIDAD);
                    cmd.Parameters.Add("beneficio_cant", modelo.BENEFICIO_CANT);
                    cmd.Parameters.Add("descuento", modelo.DESCUENTO);
                    cmd.Parameters.Add("activo", modelo.ACTIVO);
                    cmd.Parameters.Add("importe_beneficio", modelo.IMPORTE_BENEFICIO);
                    cmd.Parameters.Add("importe_pacto", modelo.IMPORTE_PACTO);
                    cmd.Parameters.Add("precio_de_compra", modelo.PRECIO_DE_COMPRA);
                    cmd.Parameters.Add("aplicado_a", modelo.APLICADO_A[0]);

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
                            // return false;4
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

        public static bool Inserta(SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow modelo, Boolean tarchivo)
        {
            string sentencia = "sp_ins_lista_ofertas_venta";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("nombre", modelo.NOMBRE);
                    cmd.Parameters.Add("lista_sucursal_id", modelo.LISTA_SUCURSAL_ID);
                    cmd.Parameters.Add("activo", modelo.ACTIVO);
                    cmd.Parameters.Add("fecha_generada", modelo.FECHA_GENERADA);
                    cmd.Parameters.Add("fecha_alta", modelo.FECHA_ALTA);
                    cmd.Parameters.Add("fecha_baja", modelo.FECHA_BAJA);
                    cmd.Parameters.Add("total", modelo.TOTAL);
                    if (tarchivo )
                        cmd.Parameters.Add("cfile", 1);
                    else
                        cmd.Parameters.Add("cfile", 0);


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

        public static bool Actualiza(SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow modelo)
        {
            string sentencia = "sp_upd_lista_ofertas_venta";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("elista_ofertas_id", modelo.LISTA_OFERTAS_ID);
                    cmd.Parameters.Add("enombre", modelo.NOMBRE);
                    cmd.Parameters.Add("elista_sucursal_id", modelo.LISTA_SUCURSAL_ID);
                    cmd.Parameters.Add("eactivo", modelo.ACTIVO);
                    cmd.Parameters.Add("efecha_generada", modelo.FECHA_GENERADA);
                    cmd.Parameters.Add("efecha_alta", modelo.FECHA_ALTA);
                    cmd.Parameters.Add("efecha_baja", modelo.FECHA_BAJA);
                    cmd.Parameters.Add("etotal", modelo.TOTAL);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Int32);
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

        public static SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow Oferta(string articuloID)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet dsOrdenesCompra = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

            string sentencia = "SELECT LISTA_OFERTAS_VENTA.LISTA_OFERTAS_ID, LISTA_OFERTAS_VENTA.ARTICULO_ID, LISTA_OFERTAS_VENTA.LISTA_SUCURSAL_ID, " +
                         " LISTA_OFERTAS_VENTA.CANTIDAD, LISTA_OFERTAS_VENTA.BENEFICIO_CANT, LISTA_OFERTAS_VENTA.DESCUENTO,  LISTA_OFERTAS_VENTA.FECHA_GENERADA,  " +
                         " LISTA_OFERTAS_VENTA.FECHA_ALTA, LISTA_OFERTAS_VENTA.FECHA_BAJA, CAT_ARTICULOS.NOMBRE1, CAT_ARTICULOS.NOMBRE2,  " +
                         " CAT_ARTICULOS.TIPO_MEDICAMENTO_CVE, CAT_ARTICULOS.LISTA_SUCURSAL_VTA,  " +
                         " CAT_CLIENTES.NOMBRE || ' ' | | CAT_CLIENTES.APE_PATERNO || ' ' || CAT_CLIENTES.APE_MATERNO AS PROVEEDOR,  " +
                         " CAT_CLIENTES_1.NOMBRE || ' ' | | CAT_CLIENTES_1.APE_PATERNO || ' ' || CAT_CLIENTES_1.APE_MATERNO AS LABORATORIO, LISTA_OFERTAS_VENTA.ACTIVO, 0 AS UTILIDAD  " +
" FROM LISTA_OFERTAS_VENTA INNER JOIN " +
                         " CAT_ARTICULOS ON LISTA_OFERTAS_VENTA.ARTICULO_ID = CAT_ARTICULOS.ARTICULO_ID INNER JOIN " +
                         " CAT_CLIENTES ON CAT_ARTICULOS.LABORATORIO_ID = CAT_CLIENTES.CLIENTES_ID INNER JOIN " +
                         " CAT_CLIENTES CAT_CLIENTES_1 ON CAT_ARTICULOS.LABORATORIO_ID = CAT_CLIENTES_1.CLIENTES_ID ";

            sentencia += " WHERE LISTA_OFERTAS_VENTA.ARTICULO_ID = '" + articuloID + "' " +
                " AND LISTA_OFERTAS_VENTA.ACTIVO = 'A'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    using (OracleDataAdapter td = new OracleDataAdapter(cmd))
                    {
                        td.Fill(dsOrdenesCompra.LISTA_OFERTAS_VENTA);
                    }
                }
            }

            if (dsOrdenesCompra.LISTA_OFERTAS_VENTA.Rows.Count > 0)
            {
                return dsOrdenesCompra.LISTA_OFERTAS_VENTA.Rows[0] as SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow;
            }

            return null;
        }




        public static SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableDataTable CargaDetalles(SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow Lista)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet dsOrdenesCompra = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSetTableAdapters.LISTA_OFERTAS_VENTA_DETALLETableAdapter ta = new SIFModelo.OrdenCompra.OrdenesCompraDataSetTableAdapters.LISTA_OFERTAS_VENTA_DETALLETableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;

                ta.FillByLISTA_OFERTA_ID(dsOrdenesCompra.LISTA_OFERTAS_VENTA_DETALLEDataTable, Lista.LISTA_OFERTAS_ID);
            }

            return dsOrdenesCompra.LISTA_OFERTAS_VENTA_DETALLEDataTable;
        }

        public static bool ActualizaDetalle(SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow modelo)
        {
            string sentencia = "SP_UPD_LISTA_OFERTAS_VTA_DET";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("elista_ofertas_id", modelo.LISTA_OFERTAS_ID);
                    cmd.Parameters.Add("earticulo_id", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("epartida", modelo.PARTIDA);
                    cmd.Parameters.Add("ecantidad", modelo.CANTIDAD);
                    cmd.Parameters.Add("ebeneficio_cant", modelo.BENEFICIO_CANT);
                    cmd.Parameters.Add("edescuento", modelo.DESCUENTO);
                    cmd.Parameters.Add("eactivo", modelo.ACTIVO);
                    cmd.Parameters.Add("eimporte_beneficio", modelo.IMPORTE_BENEFICIO);
                    cmd.Parameters.Add("eimporte_pacto", modelo.IMPORTE_PACTO);
                    cmd.Parameters.Add("eprecio_de_compra", modelo.PRECIO_DE_COMPRA);
                    cmd.Parameters.Add("eaplicado_a", modelo.APLICADO_A[0]);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Int32);
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

        public static SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow DescuentoActivo(SIFModelo.Articulo articulo, SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow Lista)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet dsOrdenesCompra = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSetTableAdapters.LISTA_OFERTAS_VENTA_DETALLETableAdapter ta = new SIFModelo.OrdenCompra.OrdenesCompraDataSetTableAdapters.LISTA_OFERTAS_VENTA_DETALLETableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;

                string f1 = Lista.FECHA_ALTA.ToString("yyyy-MM-dd HH:mm:01");
                string f2 = Lista.FECHA_BAJA.ToString("yyyy-MM-dd HH:mm:ss");
                ta.FillByOfertaActiva(dsOrdenesCompra.LISTA_OFERTAS_VENTA_DETALLEDataTable, articulo.ARTICULO_ID, f1, f2);
            }

            if (dsOrdenesCompra.LISTA_OFERTAS_VENTA_DETALLEDataTable.Count > 0)
            {
                return dsOrdenesCompra.LISTA_OFERTAS_VENTA_DETALLEDataTable.First();
            }

            return null;
        }

        public static SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow OfertaPorArticuloOfertaID(string articulo, int ofertaID)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet dsOrdenesCompra = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSetTableAdapters.LISTA_OFERTAS_VENTA_DETALLETableAdapter ta = new SIFModelo.OrdenCompra.OrdenesCompraDataSetTableAdapters.LISTA_OFERTAS_VENTA_DETALLETableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;

                ta.FillByArticuloOfertaID(dsOrdenesCompra.LISTA_OFERTAS_VENTA_DETALLEDataTable, articulo, ofertaID);
            }

            if (dsOrdenesCompra.LISTA_OFERTAS_VENTA_DETALLEDataTable.Count > 0)
            {
                return dsOrdenesCompra.LISTA_OFERTAS_VENTA_DETALLEDataTable.First();
            }

            return null;
        }


        public static String insertaArchivoImpOfertas( String[] Clave, Decimal[] Descuento)
        {
            //string ProductName = "Catalogo";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_VENTAS.sp_ImpFilePromocionesMes";


                cmd.BindByName = true;

                    //        cmd.Parameters.Add("clienteID", OracleDbType.Decimal, cliente, ParameterDirection.Input);
                        //      cmd.Parameters.Add("Agregar", OracleDbType.Varchar2, agregar, ParameterDirection.Input);


                OracleParameter InArtId = cmd.Parameters.Add("Ean", OracleDbType.Varchar2);
                InArtId.Direction = ParameterDirection.Input;
                InArtId.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InArtId.Value = Clave;

                // IN Array isss
                OracleParameter InDecimal = cmd.Parameters.Add("Descuento", OracleDbType.Decimal);
                InDecimal.Direction = ParameterDirection.Input;
                InDecimal.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InDecimal.Value = Descuento;

                // OUT parameter
                OracleParameter pInsCatalogo =
                    cmd.Parameters.Add("OutParam", OracleDbType.Varchar2, ParameterDirection.Output);
                pInsCatalogo.Size = 1000;

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pInsCatalogo.Value.ToString()))
                {
                    //MessageBox.Show("Se Cargo el catalogo", "Catalogo sub", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return pInsCatalogo.Value.ToString();
                }
                return pInsCatalogo.Value.ToString();
            }
            catch (Exception ex)            {
                
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



        #region 
        public static string InsertaPromocionesLayout  (
            string pFileName ,
            string  replacefile ,
            Int16 pUser,
            String[] p_codigo,
            Int16[] p_Partda,
            Int16[] p_oferta,
            Decimal[] p_precio_de_venta,
            Int16[] p_cantidad_req,
            Int16[] p_cantidad_beneficio,
            String[] p_fecha_inicio,
            String[] p_fecha_fin,
            String[] p_aplica_sucursales,
            String[] p_tipo_promocion



            )
        {

            try
            {
                string sentencia = "PKG_PROMOCIONES_MARKETING.sp_ins_layout";
                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.BindByName = true;

                        //PARAMETROS
                        cmd.Parameters.Add("p_file_name", pFileName);                        
                        cmd.Parameters.Add("p_replace_file", replacefile);
                        cmd.Parameters.Add("p_user_import", pUser);

                        //parametros del array para detalle
                        // IN ARRAY PARAMETERS

                        OracleParameter particulo_id = cmd.Parameters.Add("p_articulo_id", OracleDbType.Varchar2);
                        particulo_id.Direction = ParameterDirection.Input;
                        particulo_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        particulo_id.Value = p_codigo;

                        OracleParameter pnum_partida = cmd.Parameters.Add("p_partida", OracleDbType.Decimal);
                        pnum_partida.Direction = ParameterDirection.Input;
                        pnum_partida.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        pnum_partida.Value = p_Partda;

                        OracleParameter poferta = cmd.Parameters.Add("p_oferta", OracleDbType.Decimal);
                        poferta.Direction = ParameterDirection.Input;
                        poferta.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        poferta.Value = p_oferta;

                        OracleParameter pprecio_de_venta = cmd.Parameters.Add("p_precio_de_venta", OracleDbType.Decimal);
                        pprecio_de_venta.Direction = ParameterDirection.Input;
                        pprecio_de_venta.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        pprecio_de_venta.Value = p_precio_de_venta;

                        OracleParameter pcantidad_req = cmd.Parameters.Add("p_cantidad_req", OracleDbType.Decimal);
                        pcantidad_req.Direction = ParameterDirection.Input;
                        pcantidad_req.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        pcantidad_req.Value = p_cantidad_req;

                        OracleParameter pcantidad_beneficio = cmd.Parameters.Add("p_cantidad_beneficio", OracleDbType.Decimal);
                        pcantidad_beneficio.Direction = ParameterDirection.Input;
                        pcantidad_beneficio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        pcantidad_beneficio.Value = p_cantidad_beneficio;

                        OracleParameter pfecha_inicio = cmd.Parameters.Add("p_fecha_inicio", OracleDbType.Varchar2);
                        pfecha_inicio.Direction = ParameterDirection.Input;
                        pfecha_inicio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        pfecha_inicio.Value = p_fecha_inicio;


                        OracleParameter pfecha_fin = cmd.Parameters.Add("p_fecha_fin", OracleDbType.Varchar2);
                        pfecha_fin.Direction = ParameterDirection.Input;
                        pfecha_fin.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        pfecha_fin.Value = p_fecha_fin;

                        OracleParameter paplica_sucursales = cmd.Parameters.Add("p_aplica_sucursales", OracleDbType.Varchar2);
                        paplica_sucursales.Direction = ParameterDirection.Input;
                        paplica_sucursales.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        paplica_sucursales.Value = p_aplica_sucursales;

                        OracleParameter ptipo_promocion = cmd.Parameters.Add("p_tipo_promocion", OracleDbType.Varchar2);
                        ptipo_promocion.Direction = ParameterDirection.Input;
                        ptipo_promocion.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                        ptipo_promocion.Value = p_tipo_promocion;

                        //VALORES


                        //PARAMETROS DE SALIDA
                        OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Varchar2);
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
                        catch (Exception ex)
                        {
                            //Helpers.Audita.InsertaAudit(modelo.VendedorID.ToString(), "PKG_VENTAS.sp_ins_remision", "sucursal_id-" + modelo.SucursalID + " num_remision- " + modelo.NumeroRemision + " cliente_id-" + modelo.ClienteID, "", ex.Message);
                            //throw ex;
                            return ex.ToString();
                        }
                        finally
                        {
                            cmd.Connection.Close();
                        }

                    }
                }


            }
            catch (Exception E)
            {
                return E.ToString();
            }
            
        }
        public static string  InsertaPromociones(SIFModelo.Ofertas.listaOfertasVenta l, SIFModelo.Ofertas.listaOfertasVentaDet ld)
        {/*
            try
            {
                string sentencia = "PKG_PROMOCIONES_MARKETING.SP_UPD_INS_PROMOCION";
                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.BindByName = true;

                        //PARAMETROS
                       cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                        cmd.Parameters.Add("num_remision", modelo.NumeroRemision);
                        cmd.Parameters.Add("tipo_cliente_id", modelo.TipoClienteID);
                        cmd.Parameters.Add("cliente_id", modelo.ClienteID);
                        cmd.Parameters.Add("fecha_vta", modelo.FechaVenta);
                        cmd.Parameters.Add("receta", Convert.ToChar(modelo.Receta));
                        cmd.Parameters.Add("id_medico", modelo.MedicoID);
                        cmd.Parameters.Add("fecha_pago", null);
                        cmd.Parameters.Add("vendedor_id", modelo.VendedorID);
                        cmd.Parameters.Add("moneda_id", modelo.MonedaID);
                        cmd.Parameters.Add("tipo_cambio_id", modelo.TipoCambio);
                        cmd.Parameters.Add("condiciones", modelo.Condiciones);
                        cmd.Parameters.Add("subtotal", modelo.SubTotal);
                        cmd.Parameters.Add("impuesto_iva", modelo.Impuesto);
                        cmd.Parameters.Add("descuento", modelo.Descuento);
                        //cmd.Parameters.Add("importe_descuento", modelo.SubTotal);
                        cmd.Parameters.Add("total", modelo.Total);
                        cmd.Parameters.Add("total_articulos_rem", modelo.TotalArticulosRemision);
                        cmd.Parameters.Add("num_factura", System.Convert.ToChar(modelo.Factura));
                        cmd.Parameters.Add("activo", System.Convert.ToChar('G'));
                        cmd.Parameters.Add("importe_letra", modelo.ImporteLetra);
                        cmd.Parameters.Add("factura", System.Convert.ToChar(modelo.Factura));
                        cmd.Parameters.Add("comentarios", modelo.Comentarios);
                        cmd.Parameters.Add("num_pedido", modelo.NumeroPedido);
                        cmd.Parameters.Add("beneficio_prov", System.Convert.ToChar(modelo.BeneficioProveedor));
                        cmd.Parameters.Add("vcomision", modelo.Comision);
                        cmd.Parameters.Add("vTarjetaID", modelo.TarjetaID);
                        cmd.Parameters.Add("vDependenciaDescuentoID", modelo.CAT_DEPENDENCIA_DESCUENTO_ID);
                        cmd.Parameters.Add("p_homologado", Convert.ToChar(modelo.homologado));
              

                        
                        //parametros del array para detalle
                        // IN ARRAY PARAMETERS
                        OracleParameter pnum_partida = cmd.Parameters.Add("num_partida", OracleDbType.Decimal);
                        pnum_partida.Direction = ParameterDirection.Input;
                        pnum_partida.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter particulo_id = cmd.Parameters.Add("articulo_id", OracleDbType.Varchar2);
                        particulo_id.Direction = ParameterDirection.Input;
                        particulo_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter pcod_cliente = cmd.Parameters.Add("cod_cliente", OracleDbType.Varchar2);
                        pcod_cliente.Direction = ParameterDirection.Input;
                        pcod_cliente.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter pnombre1 = cmd.Parameters.Add("nombre1", OracleDbType.Varchar2);
                        pnombre1.Direction = ParameterDirection.Input;
                        pnombre1.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter pnombre2 = cmd.Parameters.Add("nombre2", OracleDbType.Varchar2);
                        pnombre2.Direction = ParameterDirection.Input;
                        pnombre2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter pfechaent = cmd.Parameters.Add("fechaent", OracleDbType.Varchar2);
                        pfechaent.Direction = ParameterDirection.Input;
                        pfechaent.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter pcant_remision = cmd.Parameters.Add("cant_remision", OracleDbType.Decimal);
                        pcant_remision.Direction = ParameterDirection.Input;
                        pcant_remision.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        //OracleParameter ppiezas_gratis = cmd.Parameters.Add("piezas_gratis", OracleDbType.Decimal);
                        //ppiezas_gratis.Direction = ParameterDirection.Input;
                        //ppiezas_gratis.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter pprecio = cmd.Parameters.Add("precio", OracleDbType.Decimal);
                        pprecio.Direction = ParameterDirection.Input;
                        pprecio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter piva = cmd.Parameters.Add("iva", OracleDbType.Decimal);
                        piva.Direction = ParameterDirection.Input;
                        piva.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter pimpuesto_id = cmd.Parameters.Add("impuesto_id", OracleDbType.Decimal);
                        pimpuesto_id.Direction = ParameterDirection.Input;
                        pimpuesto_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter pdescuento_id = cmd.Parameters.Add("descuento_id", OracleDbType.Decimal);
                        pdescuento_id.Direction = ParameterDirection.Input;
                        pdescuento_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter pimporte_descuento = cmd.Parameters.Add("importe_descuento", OracleDbType.Decimal);
                        pimporte_descuento.Direction = ParameterDirection.Input;
                        pimporte_descuento.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter pprecio_costo = cmd.Parameters.Add("precio_costo", OracleDbType.Decimal);
                        pprecio_costo.Direction = ParameterDirection.Input;
                        pprecio_costo.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter pfolio_controlado = cmd.Parameters.Add("folio_controlado", OracleDbType.Varchar2);
                        pfolio_controlado.Direction = ParameterDirection.Input;
                        pfolio_controlado.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter ppaquete_id = cmd.Parameters.Add("paquete_id", OracleDbType.Decimal);
                        ppaquete_id.Direction = ParameterDirection.Input;
                        ppaquete_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter pref_nadro = cmd.Parameters.Add("ref_nadro", OracleDbType.Varchar2);
                        pref_nadro.Direction = ParameterDirection.Input;
                        pref_nadro.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter plote = cmd.Parameters.Add("lote", OracleDbType.Varchar2);
                        plote.Direction = ParameterDirection.Input;
                        plote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter pCaducidad = cmd.Parameters.Add("Caducidad", OracleDbType.Varchar2);
                        pCaducidad.Direction = ParameterDirection.Input;
                        pCaducidad.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        OracleParameter pref_oferta = cmd.Parameters.Add("ref_oferta", OracleDbType.Decimal);
                        pref_oferta.Direction = ParameterDirection.Input;
                        pref_oferta.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        //
                        OracleParameter pmedico_id = cmd.Parameters.Add("medico_id", OracleDbType.Decimal);
                        pmedico_id.Direction = ParameterDirection.Input;
                        pmedico_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                        //JMQC / 10-09-2018 lo integro para que se guarde el precio original dela vista cs_lista_precios
                        OracleParameter pprecioOrg = cmd.Parameters.Add("pprecio_org_venta", OracleDbType.Decimal);
                        pprecioOrg.Direction = ParameterDirection.Input;
                        pprecioOrg.CollectionType = OracleCollectionType.PLSQLAssociativeArray;


                        //VALORES
                        

                        var Vnum_partida = from d in detalles select d.NumeroPartida;
                        var Varticulo_id = from d in detalles select d.ArticuloID;
                        var Vcod_cliente = from d in detalles select d.CODIGO_CLI;
                        var Vnombre1 = from d in detalles select d.Nombre1;
                        var Vnombre2 = from d in detalles select d.Nombre2;
                        var Vfechaent = from d in detalles select d.FechaEntrega;
                        var Vcant_remision = from d in detalles select (d.CantidadRemision);
                        //var Vpiezas_gratis = from d in detalles select d.PiezasGratis;
                        var Vprecio = from d in detalles select d.Precio;
                        var Viva = from d in detalles select d.IVA;
                        var Vimpuesto = from d in detalles select d.ImpuestoID;
                        var Vdescuento_id = from d in detalles select d.DescuentoID;
                        var Vimporte_descuento = from d in detalles select d.MontoDescuento;
                        var Vprecio_costo = from d in detalles select d.PrecioCosto;
                        var Vfolio_controlado = from d in detalles select d.FolioControlado;
                        var Vpaquete_id = from d in detalles select d.PaqueteID;
                        var Vref_nadro = from d in detalles select d.ReferenciaNADRO;
                        var Vlote = from d in detalles select d.Lote;
                        var Vcaducidad = from d in detalles select d.Caducidad;
                        var Vref_oferta = from d in detalles select d.RefOferta;
                        var Vmedico_id = from d in detalles select d.medico_id;
                        var VprecioVentaOrg = from d in detalles select d.PrecioVentaOrg;

                        pnum_partida.Value = Vnum_partida.ToArray();
                        particulo_id.Value = Varticulo_id.ToArray();
                        pcod_cliente.Value = Vcod_cliente.ToArray();
                        pnombre1.Value = Vnombre1.ToArray();
                        pnombre2.Value = Vnombre2.ToArray();
                        pfechaent.Value = Vfechaent.ToArray();
                        pcant_remision.Value = Vcant_remision.ToArray();
                        //ppiezas_gratis.Value = Vcant_remision.ToArray();
                        pprecio.Value = Vprecio.ToArray();
                        piva.Value = Viva.ToArray();
                        pimpuesto_id.Value = Vimpuesto.ToArray();
                        pdescuento_id.Value = Vdescuento_id.ToArray();
                        pimporte_descuento.Value = Vimporte_descuento.ToArray();
                        pprecio_costo.Value = Vprecio_costo.ToArray();
                        pfolio_controlado.Value = Vfolio_controlado.ToArray();
                        ppaquete_id.Value = Vpaquete_id.ToArray();
                        pref_nadro.Value = Vref_nadro.ToArray();
                        plote.Value = Vlote.ToArray();

                        String[] Scaducidad = new String[Vcaducidad.ToArray().Length];
                        for (int i = 0; i < Vcaducidad.ToArray().Length; i++)
                        {
                            if (Vcaducidad.ToArray()[i] != null)
                                Scaducidad[i] = Vcaducidad.ToArray()[i].Value.ToString("dd/MM/yyyy");
                            else
                                Scaducidad[i] = "";
                        }
                        pCaducidad.Value = Scaducidad;

                        pref_oferta.Value = Vref_oferta.ToArray();
                        pmedico_id.Value = Vmedico_id.ToArray();
                        pprecioOrg.Value = VprecioVentaOrg.ToArray();
                        //PARAMETROS DE SALIDA
                        OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                        outparam.Direction = System.Data.ParameterDirection.Output;

                        //AGREGAR LOS PARAMETROS
                        cmd.Parameters.Add(outparam);
                        try
                        {
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            var id = outparam.Value;
                            if (id.ToString().IsInteger())
                            {
                                Helpers.Audita.InsertaAudit(modelo.VendedorID.ToString(), "VERSION EQUIPO", "sucursal_id-" + modelo.SucursalID + " num_remision- " + modelo.NumeroRemision + " cliente_id-" + modelo.ClienteID, "", _fecVersionLocal.ToString("yyyyMMddHHmmss"));
                                if (int.Parse(id.ToString()) < 0)
                                {
                                    throw new Exception("Ha ocurrido un error al insertar el registro" + id.ToString());
                                    return false;
                                }

                                return true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Helpers.Audita.InsertaAudit(modelo.VendedorID.ToString(), "PKG_VENTAS.sp_ins_remision", "sucursal_id-" + modelo.SucursalID + " num_remision- " + modelo.NumeroRemision + " cliente_id-" + modelo.ClienteID, "", ex.Message);
                            //throw ex;
                            return false;
                        }
                        finally
                        {
                            cmd.Connection.Close();
                        }

                    }
                }

                return true;
            }
            catch (Exception E)
            { return false; }*/
            return "";
        }

        /// <summary>
        /// Metodo para obtener datos de las promociones del mes para notificar en el modulo de asignacion de precios
        /// JMQC
        /// 21/05/2026
        /// 
        /// </summary>
        
        
        public static List<SIFModelo.Ofertas.ListaPromocionesActivas> GetListSkuPromociones()
        {
            string sentencia = "SELECT ARTICULO_ID,	NOMBRE1 FROM cs_l_skus_vig_modCmp ";

            List<SIFModelo.Ofertas.ListaPromocionesActivas> ls = new List<SIFModelo.Ofertas.ListaPromocionesActivas>();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //parametros
                        
                        //
                        cmd.Connection.Open();
                        //precio = cmd.ExecuteScalar();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Ofertas.ListaPromocionesActivas of = new SIFModelo.Ofertas.ListaPromocionesActivas();
                                of.ArticuloID = oreader["ARTICULO_ID"].ToString();
                                of.Nombre1 = oreader["NOMBRE1"].ToString();
                                ls.Add( of  );
                            }
                        }
                        return ls;

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
            return ls; 
        }


        #endregion
    }
}
