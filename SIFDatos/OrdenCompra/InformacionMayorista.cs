using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace SIFDatos.OrdenCompra
{
    public static class InformacionMayorista
    {
        public static SIFModelo.OrdenCompra.InfromacionMayorista InformacionMayoristaPorArticulo(SIFModelo.Articulo articulo)
        {
            SIFModelo.OrdenCompra.InfromacionMayorista informacion = null;
            //string sentencia = "SELECT ARTICULO_ID,PROVEEDOR_ID,COMPRA_CON_MAYORISTA,TIPO1,TIPO2,TIPO3,TIPO7,TIPO_MEDICAMENTO,CODIGO_NADRO,CODIGO_SABA,CODIGO_DROGUEROS,DESCUENTO_NADRO,DESCUENTO_SABA,DESCUENTO_DROGUEROS,EDO_COMPRA_NADRO,EDO_COMPRA_SABA,EDO_COMPRA_DROGUEROS,CANTIDAD_COMPRAR,PEDIR,STATUS,DESCTO_ADICIONAL_NADRO,DESCTO_ADICIONAL_SABA,DESCTO_ADICIONAL_DROGUEROS,CANTIDAD_MINIMA_COMPRA,FECHA_ACTUALIZACION,PERIODO_COMPRA,PERIODO_COMPRA_FIN,TIPO4,COMPRADOR_ID,BLOQUEADO,PORC_IEPS,PORC_IVA,DESCTO_ADICIONAL_MARZAM,DESCUENTO_MARZAM,EDO_COMPRA_MARZAM,CODIGO_MARZAM,NVL(TIPO6,99) TIPO6 FROM CAT_ARTICULOS_MAYORISTA WHERE articulo_id = :codigo_ean";
            string sentencia = "SELECT ARTICULO_ID,PROVEEDOR_ID,COMPRA_CON_MAYORISTA,TIPO1,TIPO2,TIPO3,TIPO_MEDICAMENTO,CODIGO_NADRO,CODIGO_SABA,CODIGO_DROGUEROS,DESCUENTO_NADRO,DESCUENTO_SABA,DESCUENTO_DROGUEROS,EDO_COMPRA_NADRO,EDO_COMPRA_SABA,EDO_COMPRA_DROGUEROS,CANTIDAD_COMPRAR,PEDIR,STATUS,DESCTO_ADICIONAL_NADRO,DESCTO_ADICIONAL_SABA,DESCTO_ADICIONAL_DROGUEROS,CANTIDAD_MINIMA_COMPRA,FECHA_ACTUALIZACION,PERIODO_COMPRA,PERIODO_COMPRA_FIN,TIPO4,COMPRADOR_ID,BLOQUEADO,PORC_IEPS,PORC_IVA,DESCTO_ADICIONAL_MARZAM,DESCUENTO_MARZAM,EDO_COMPRA_MARZAM,CODIGO_MARZAM,NVL(TIPO6,99) TIPO6," +
                " TIPO7, COLOR_RGB, ALERTA_CMP FROM CAT_ARTICULOS_MAYORISTA WHERE articulo_id = :codigo_ean";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.Parameters.Add("sucursalID", sucursal.SucursalesID);
                    cmd.Parameters.Add("codigo_ean", articulo.ARTICULO_ID);
                    //cmd.Parameters.Add("proveedorid", articulo.PROVEEDOR_ID);
                    cmd.BindByName = true;

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                informacion = new SIFModelo.OrdenCompra.InfromacionMayorista();
                                informacion.ARTICULO_ID = oreader["ARTICULO_ID"].ToString();
                                informacion.PROVEEDOR_ID = System.Convert.ToInt32(oreader["PROVEEDOR_ID"]);
                                informacion.COMPRA_CON_MAYORISTA = (SIFModelo.Tipos.ComprarConMayorista)oreader["COMPRA_CON_MAYORISTA"].ToString()[0];
                                informacion.TIPO1 = System.Convert.ToInt32(oreader["TIPO1"]);
                                informacion.TIPO2 = System.Convert.ToInt32(oreader["TIPO2"]);
                                informacion.TIPO3 = System.Convert.ToInt32(oreader["TIPO3"]);
                                informacion.TIPO4 = System.Convert.ToInt32(oreader["TIPO4"]);
                                informacion.TIPO_MEDICAMENTO = oreader["TIPO_MEDICAMENTO"].ToString();
                                informacion.CODIGO_NADRO = oreader["CODIGO_NADRO"].ToString();
                                informacion.CODIGO_SABA = oreader["CODIGO_SABA"].ToString();
                                informacion.CODIGO_DROGUEROS = oreader["CODIGO_DROGUEROS"].ToString();
                                informacion.CODIGO_MARZAM = oreader["CODIGO_MARZAM"].ToString();
                                informacion.DESCUENTO_NADRO = System.Convert.ToDecimal(oreader["DESCUENTO_NADRO"]);
                                informacion.DESCUENTO_SABA = System.Convert.ToDecimal(oreader["DESCUENTO_SABA"]);

                                // oreader["PORCENTAJE_IESPS"]
                                informacion.PORCENTAJE_IESPS = float.Parse(oreader["PORC_IEPS"].ToString());
                                double dmar = System.Convert.ToDouble(oreader["DESCUENTO_MARZAM"]);
                                if (!double.IsInfinity(dmar))
                                {
                                    informacion.DESCUENTO_MARZAM = System.Convert.ToDecimal(oreader["DESCUENTO_MARZAM"]);
                                }
                                else
                                {
                                    informacion.DESCUENTO_MARZAM = 0;
                                }

                                if (string.IsNullOrEmpty(oreader["BLOQUEADO"].ToString()))
                                {
                                    informacion.Bloqueado = SIFModelo.Tipos.SiNo.NO;
                                }
                                else
                                {
                                    informacion.Bloqueado = (SIFModelo.Tipos.SiNo)oreader["BLOQUEADO"].ToString()[0];
                                }

                                informacion.DESCUENTO_DROGUEROS = System.Convert.ToDecimal(oreader["DESCUENTO_DROGUEROS"]);

                                if (!string.IsNullOrEmpty(oreader["EDO_COMPRA_NADRO"].ToString()))
                                {
                                    informacion.EDO_COMPRA_NADRO = (SIFModelo.Tipos.TipoStatusMayorista)oreader["EDO_COMPRA_NADRO"].ToString()[0];
                                }
                                else
                                {
                                    informacion.EDO_COMPRA_NADRO = SIFModelo.Tipos.TipoStatusMayorista.COMPRA;
                                }

                                var edo = oreader["EDO_COMPRA_SABA"].ToString();
                                if (!string.IsNullOrEmpty(oreader["EDO_COMPRA_SABA"].ToString()))
                                {
                                    informacion.EDO_COMPRA_SABA = (SIFModelo.Tipos.TipoStatusMayorista)oreader["EDO_COMPRA_SABA"].ToString()[0];
                                }
                                else
                                {
                                    informacion.EDO_COMPRA_SABA = SIFModelo.Tipos.TipoStatusMayorista.COMPRA;
                                }

                                if (!string.IsNullOrEmpty(oreader["EDO_COMPRA_DROGUEROS"].ToString()))
                                {
                                    informacion.EDO_COMPRA_DROGUEROS = (SIFModelo.Tipos.TipoStatusMayorista)oreader["EDO_COMPRA_DROGUEROS"].ToString()[0];
                                }
                                else
                                {
                                    informacion.EDO_COMPRA_DROGUEROS = SIFModelo.Tipos.TipoStatusMayorista.COMPRA;
                                }

                                if (!string.IsNullOrEmpty(oreader["EDO_COMPRA_MARZAM"].ToString()))
                                {
                                    informacion.EDO_COMPRA_MARZAM = (SIFModelo.Tipos.TipoStatusMayorista)oreader["EDO_COMPRA_MARZAM"].ToString()[0];
                                }
                                else
                                {
                                    informacion.EDO_COMPRA_MARZAM = SIFModelo.Tipos.TipoStatusMayorista.COMPRA;
                                }

                                informacion.CANTIDAD_COMPRAR = System.Convert.ToInt32(oreader["CANTIDAD_COMPRAR"]);
                                informacion.PEDIR = (SIFModelo.Tipos.SiNo)oreader["PEDIR"].ToString()[0];
                                informacion.STATUS = oreader["STATUS"].ToString();
                                informacion.DESCTO_ADICIONAL_NADRO = System.Convert.ToDecimal(oreader["DESCTO_ADICIONAL_NADRO"]);
                                informacion.DESCTO_ADICIONAL_SABA = System.Convert.ToDecimal(oreader["DESCTO_ADICIONAL_SABA"]);
                                informacion.DESCTO_ADICIONAL_DROGUEROS = System.Convert.ToDecimal(oreader["DESCTO_ADICIONAL_DROGUEROS"]);
                                informacion.DESCTO_ADICIONAL_MARZAM = System.Convert.ToDecimal(oreader["DESCTO_ADICIONAL_MARZAM"]);
                                informacion.CANTIDAD_MINIMA_COMPRA = System.Convert.ToInt32(oreader["CANTIDAD_MINIMA_COMPRA"]);

                                var fechaActualizacion = oreader["FECHA_ACTUALIZACION"];
                                if (fechaActualizacion.ToString().IsDatetime())
                                    informacion.FECHA_ACTUALIZACION = System.Convert.ToDateTime(oreader["FECHA_ACTUALIZACION"]);

                                var periodoCompra = oreader["PERIODO_COMPRA"];
                                if (periodoCompra.ToString().IsDatetime())
                                    informacion.PERIODO_COMPRA_INICIO = System.Convert.ToDateTime(oreader["PERIODO_COMPRA"]);

                                var periodoCompraFin = oreader["PERIODO_COMPRA_FIN"];
                                if (periodoCompraFin.ToString().IsDatetime())
                                    informacion.PERIODO_COMPRA_FIN = System.Convert.ToDateTime(oreader["PERIODO_COMPRA_FIN"]);


                                informacion.CANTIDAD_COMPRAR = System.Convert.ToInt32(oreader["CANTIDAD_COMPRAR"]);
                                informacion.tipo6 = System.Convert.ToInt16(oreader["TIPO6"]);

                                if (string.IsNullOrEmpty(oreader["TIPO7"].ToString()))
                                    informacion.tipo7 = 99; // Generico por defecto
                                else
                                    informacion.tipo7 = System.Convert.ToInt16(oreader["TIPO7"]);

                                informacion.colorRGB = oreader["COLOR_RGB"].ToString();// SE REQUIERE PARA REPORTE DE ANTIMICROBIANOS 
                                informacion.alertaAlComprar = System.Convert.ToInt16(oreader["ALERTA_CMP"].ToString());

                                
                            }
                        }
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

                }
            }
            return informacion;
        }


        public static bool GuardarInformacionMayorista(SIFModelo.OrdenCompra.InfromacionMayorista modelo)
        {
            string sentencia = "PKG_INF_MAYORISTA.SP_GUARDA_INF_MAYORISTA";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("P_ARTICULO_ID", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("P_PROVEEDOR_ID", modelo.PROVEEDOR_ID);
                    cmd.Parameters.Add("P_COMPRA_CON_MAYORISTA", System.Convert.ToChar(modelo.COMPRA_CON_MAYORISTA));
                    cmd.Parameters.Add("P_TIPO1", modelo.TIPO1);
                    cmd.Parameters.Add("P_TIPO2", modelo.TIPO2);
                    cmd.Parameters.Add("P_TIPO3", modelo.TIPO3);
                    cmd.Parameters.Add("P_TIPO4", modelo.TIPO4);
                    cmd.Parameters.Add("P_TIPO_MEDICAMENTO", modelo.TIPO_MEDICAMENTO);
                    cmd.Parameters.Add("P_CODIGO_NADRO", modelo.CODIGO_NADRO);
                    cmd.Parameters.Add("P_CODIGO_SABA", modelo.CODIGO_SABA);
                    cmd.Parameters.Add("P_CODIGO_DROGUEROS", modelo.CODIGO_DROGUEROS);
                    cmd.Parameters.Add("P_CODIGO_MARZAM", modelo.CODIGO_MARZAM);
                    cmd.Parameters.Add("P_DESCUENTO_NADRO", modelo.DESCUENTO_NADRO);
                    cmd.Parameters.Add("P_DESCUENTO_SABA", modelo.DESCUENTO_SABA);
                    cmd.Parameters.Add("P_DESCUENTO_MARZAM", modelo.DESCUENTO_MARZAM);
                    cmd.Parameters.Add("P_DESCUENTO_DROGUEROS", modelo.DESCUENTO_DROGUEROS);
                    cmd.Parameters.Add("P_EDO_COMPRA_NADRO", System.Convert.ToChar(modelo.EDO_COMPRA_NADRO));
                    cmd.Parameters.Add("P_EDO_COMPRA_SABA", System.Convert.ToChar(modelo.EDO_COMPRA_SABA));
                    cmd.Parameters.Add("P_EDO_COMPRA_DROGUEROS", System.Convert.ToChar(modelo.EDO_COMPRA_DROGUEROS));
                    cmd.Parameters.Add("P_EDO_COMPRA_MARZAM", System.Convert.ToChar(modelo.EDO_COMPRA_MARZAM));
                    cmd.Parameters.Add("P_CANTIDAD_COMPRAR", modelo.CANTIDAD_COMPRAR);
                    cmd.Parameters.Add("P_PEDIR", System.Convert.ToChar(modelo.PEDIR));
                    cmd.Parameters.Add("P_STATUS", modelo.STATUS);
                    cmd.Parameters.Add("P_DESCTO_ADICIONAL_NADRO", modelo.DESCTO_ADICIONAL_NADRO);
                    cmd.Parameters.Add("P_DESCTO_ADICIONAL_SABA", modelo.DESCTO_ADICIONAL_SABA);
                    cmd.Parameters.Add("P_DESCTO_ADICIONAL_DROGUEROS", modelo.DESCTO_ADICIONAL_DROGUEROS);
                    cmd.Parameters.Add("P_DESCTO_ADICIONAL_MARZAM", modelo.DESCTO_ADICIONAL_MARZAM);
                    cmd.Parameters.Add("P_CANTIDAD_MINIMA_COMPRA", modelo.CANTIDAD_MINIMA_COMPRA);
                    cmd.Parameters.Add("P_FECHA_ACTUALIZACION", modelo.FECHA_ACTUALIZACION);
                    cmd.Parameters.Add("P_PERIODO_COMPRA", modelo.PERIODO_COMPRA_INICIO);
                    cmd.Parameters.Add("P_PERIODO_COMPRA_FIN", modelo.PERIODO_COMPRA_FIN);
                    cmd.Parameters.Add("P_BLOQUEADO", (char)modelo.Bloqueado);
                    cmd.Parameters.Add("P_PORCENTAJE_IESPS", modelo.PORCENTAJE_IESPS);
                    cmd.Parameters.Add("P_PORCENTAJE_IVA", modelo.PORCENTAJE_IVA);
                    cmd.Parameters.Add("P_TIPO6", modelo.tipo6);
                    cmd.Parameters.Add("P_TIPO7", modelo.tipo7);
                    cmd.Parameters.Add("P_COLORRGB", modelo.colorRGB);
                    cmd.Parameters.Add("P_ALERTACMP", modelo.alertaAlComprar);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("result", OracleDbType.Decimal);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteScalar();
                        var id = outparam.Value;

                        if (id.ToString().IsInteger())
                        {
                            if (int.Parse(id.ToString()) < 0)
                            {
                                throw new Exception("Ha ocurrido un error al insetrar el registro" + id.ToString());
                            }

                            modelo.ID = int.Parse(id.ToString());
                        }
                    }
                    catch (Exception E)
                    {
                        Console.WriteLine("ERROR => " + E);
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


        public static string TipoMedicamentoMayorista(SIFModelo.OrdenCompra.InfromacionMayorista mayorista)
        {

            SIFModelo.OrdenCompra.InfromacionMayorista informacion = null;
            string sentencia = "select nvl(TIPO_MEDICAMENTO_COMPRAS.NOMBRE ,'') from cat_articulos_mayorista " +
"inner join tipo_medicamento_compras " +
"on TIPO_MEDICAMENTO_COMPRAS.TIPO_MEDICAMENTO_COMPRAS_ID = CAT_ARTICULOS_MAYORISTA.TIPO3 " +
" where CAT_ARTICULOS_MAYORISTA.ARTICULO_ID = :codigo_ean";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.Parameters.Add("sucursalID", sucursal.SucursalesID);
                    cmd.Parameters.Add("codigo_ean", mayorista.ARTICULO_ID);
                    //cmd.Parameters.Add("proveedorid", articulo.PROVEEDOR_ID);
                    cmd.BindByName = true;

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                return oreader[0].ToString();
                            }
                        }
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

                }
            }
            return "";
        }

        public static bool actualizaEstadoMayorsita(SIFModelo.OrdenCompra.InfromacionMayorista mayorista, bool? esLinea)
        {
            string condicion = "";

            if (esLinea == null)
            {
                condicion = " WHERE ARTICULO_ID = '" + mayorista.ARTICULO_ID + "'";
            }

            if (esLinea == false)
            {
                condicion = " WHERE PROVEEDOR_ID = " + mayorista.PROVEEDOR_ID;
            }

            if (esLinea == true)
            {
                condicion = "";
            }

            string sentencia = "UPDATE cat_articulos_mayorista SET EDO_COMPRA_NADRO = '" + System.Convert.ToChar(mayorista.EDO_COMPRA_NADRO) + "'," +
 " EDO_COMPRA_SABA = '" + System.Convert.ToChar(mayorista.EDO_COMPRA_SABA) + "', " +
 " EDO_COMPRA_DROGUEROS = '" + System.Convert.ToChar(mayorista.EDO_COMPRA_DROGUEROS) + "', " +
 " EDO_COMPRA_MARZAM = '" + System.Convert.ToChar(mayorista.EDO_COMPRA_MARZAM) + "'";
            sentencia += condicion;

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
       
        
        public static string
            Costo_neto_almDrogas( string art ) {
                string x = "9999999.99";

            string  sentencia =  "SELECT ";
     sentencia+="CALCULA_PRECIO_ALMDRO(t.precio_base_farmacia,t.descuento_comer,t.descuento_add1 ,o.DESCTO_OFRECIDO) PRECIO_NETO ";
     sentencia+="FROM TEMP_MEART_DROG t , ";
     sentencia +="(select * from  OFERTAS_COMPRAS_MAYORISTA q where q.proveedor_id   ='99393') o ";
     sentencia+="WHERE t.codigo_articulo=o.CODIGO_PROVEEDOR(+) ";     
     sentencia += "AND t.codigo_articulo  ='"+art+"'";


            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                  //x= System.Convert.ToDecimal(oreader["PRECIO_NETO"]);
                                 x = oreader["PRECIO_NETO"].ToString(); 
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return x;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return x;
        }

        public static string
           precios_compra_prov(string art)
        {
            string x = "0.0";

            string  sentencia = "SELECT NADRO,  ADROG,  MARZAM,  SABA";
            sentencia += " FROM MS_PRECIO_COMPRA_PRO";
                    sentencia+=" WHERE articulo_id ='"+art+"'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                x = oreader["NADRO"].ToString()+"|";
                                x += oreader["ADROG"].ToString() + "|";
                                x += oreader["MARZAM"].ToString() + "|";
                                x += oreader["SABA"].ToString() + "|";
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return x;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }
            return x;
        }


        public static string GuardarInfCliMayorista(SIFModelo.OrdenCompra.InfromacionMayorista modelo)           //JOMAQC 26/09/2018
        {
            string sentencia = "PKG_INF_MAYORISTA.SP_GUARDA_INF_MAYORISTA_CLI";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("P_Articulo_Id", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("P_Pedir", System.Convert.ToChar(modelo.PEDIR));
                    cmd.Parameters.Add("P_Edo_Compra", System.Convert.ToChar(modelo.EDO_COMPRA));
                    cmd.Parameters.Add("P_Cantidad_Min_Comprar", "0");
                    cmd.Parameters.Add("P_Proveedor_Id", modelo.PROVEEDOR_ID);
                    cmd.Parameters.Add("P_Fecha_Inicio", modelo.PERIODO_COMPRA_INICIO.Value.ToString("dd/MM/yyyy"));
                    cmd.Parameters.Add("P_Fecha_Fin", modelo.PERIODO_COMPRA_FIN.Value.ToString("dd/MM/yyyy"));
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outm", OracleDbType.Varchar2);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    outparam.Size = 1000;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteScalar();
                        var id = outparam.Value;

                       return id.ToString();
                        /*if (id.ToString().IsInteger())
                        {
                            if (int.Parse(id.ToString()) < 0)
                            {
                                throw new Exception("Ha ocurrido un error al insetrar el registro" + id.ToString());
                            }

                            modelo.ID = int.Parse(id.ToString());
                        }*/
                    }
                    catch (Exception EX)
                    {
                        return EX.ToString();
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);
                    }

                }
            }            
        }


        public static bool actualizaCompradorArticuloMay(String pe_articulo, string pe_accesoId)
        {
            
            string
           sentencia = "UPDATE cat_articulos_mayorista SET COMPRADOR_ID = '" + pe_accesoId.Trim() + "' where articulo_id='"+pe_articulo+"'";
 
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

        /*

        public static string GuardarInfCliMayorista(SIFModelo.OrdenCompra.InfromacionMayorista modelo)           //JOMAQC 26/09/2018
        {
            string sentencia = "PKG_INF_MAYORISTA.SP_GUARDA_INF_MAYORISTA_CLI";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("P_Articulo_Id", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("P_Pedir", System.Convert.ToChar(modelo.PEDIR));
                    cmd.Parameters.Add("P_Edo_Compra", System.Convert.ToChar(modelo.EDO_COMPRA));
                    cmd.Parameters.Add("P_Cantidad_Min_Comprar", "0");
                    cmd.Parameters.Add("P_Proveedor_Id", modelo.PROVEEDOR_ID);
                    cmd.Parameters.Add("P_Fecha_Inicio", modelo.PERIODO_COMPRA_INICIO.Value.ToString("dd/MM/yyyy"));
                    cmd.Parameters.Add("P_Fecha_Fin", modelo.PERIODO_COMPRA_FIN.Value.ToString("dd/MM/yyyy"));
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outm", OracleDbType.Varchar2);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    outparam.Size = 1000;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteScalar();
                        var id = outparam.Value;

                       return id.ToString();
                       
                    }
                    catch (Exception EX)
                    {
                        return EX.ToString();
                    }
                    finally
                    {
                        cmd.Connection.Close();
                    }

                }
            }            
        }
    */


    }
}
