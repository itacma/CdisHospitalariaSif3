using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace SIFDatos
{
    public class Controlado
    {
        public static SIFModelo.Controlado ControladoPorfolio(SIFModelo.Controlado controlado)
        {
            string sentencia = "SELECT * FROM controlado WHERE folio = :Folio ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("Folio", controlado.Folio);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Controlado registro = new SIFModelo.Controlado();

                            registro.SucursalId = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.Folio = oreader["FOLIO"].ToString();
                            registro.MedicoID = int.Parse(oreader["MEDICO_ID"].ToString());
                            var fechaEntrega = oreader["FECHA_ENTREGA"];
                            if (fechaEntrega.ToString().IsDatetime())
                            {
                                registro.FechaEntrega = DateTime.Parse(fechaEntrega.ToString());
                            }
                            registro.UsuarioID = int.Parse(oreader["USUARIO_ID"].ToString());
                            registro.RemisionID = oreader["REMISION_ID"].ToString();

                            registro.Activo = (SIFModelo.Tipos.TipoActivoControlado)(oreader["ACTIVO"].ToString()[0]);
                            registro.Receta = (SIFModelo.Tipos.SiNo)(oreader["RECETA"].ToString()[0]);
                            registro.Retiene = (SIFModelo.Tipos.SiNo)(oreader["RETENCION_RECETA"].ToString()[0]);
                            registro.EntregaID = int.Parse(oreader["ENTREGA_ID"].ToString());
                            return registro;
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);

                }

            }
            return null;
        }

        public static List<SIFModelo.ControladoDetalle> DetallesControlado(SIFModelo.Controlado controlado)
        {
            List<SIFModelo.ControladoDetalle> rows = new List<SIFModelo.ControladoDetalle>();

            string sentencia = "SELECT * FROM controlado_det WHERE SUCURSAL_ID = :SucursalID AND  FOLIO = :Folio";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalID", controlado.SucursalId);
                    cmd.Parameters.Add("Folio", controlado.Folio);

                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.ControladoDetalle registro = new SIFModelo.ControladoDetalle();

                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.Folio = oreader["FOLIO"].ToString();
                            registro.NumeroPartida = int.Parse(oreader["NUM_PARTIDA"].ToString());
                            registro.ArticuloID = oreader["ARTICULO_ID"].ToString();
                            registro.Nombre1 = oreader["NOMBRE1"].ToString();
                            registro.Nombre2 = oreader["NOMBRE2"].ToString();
                            registro.Cantidad = int.Parse(oreader["CANTIDAD"].ToString());
                            registro.Precio = decimal.Parse(oreader["PRECIO"].ToString());
                            registro.IVA = decimal.Parse(oreader["IVA"].ToString());
                            registro.ImpuestoID = int.Parse(oreader["IMPUESTO_ID"].ToString());
                            registro.DescuentoID = int.Parse(oreader["DESCUENTO_ID"].ToString());
                            registro.Precio = decimal.Parse(oreader["PRECIO"].ToString());
                            registro.PrecioCosto = decimal.Parse(oreader["PRECIO_COSTO"].ToString());
                            registro.Activo = ((SIFModelo.Tipos.TipoActivoControlado)oreader["ACTIVO"].ToString()[0]);
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

        public static bool ActualizaControlado(SIFModelo.Controlado modelo)
        {
            string sentencia = "sp_upd_controlado";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("esucursal_id", modelo.SucursalId);
                    cmd.Parameters.Add("efolio", modelo.Folio);
                    cmd.Parameters.Add("emedico_id", modelo.MedicoID);
                    cmd.Parameters.Add("efecha_entrega", modelo.FechaEntrega);
                    cmd.Parameters.Add("eusuario_id", modelo.UsuarioID);
                    cmd.Parameters.Add("eremision_id", modelo.RemisionID);
                    cmd.Parameters.Add("eactivo", System.Convert.ToChar(modelo.Activo));
                    cmd.Parameters.Add("ereceta", System.Convert.ToChar(modelo.Receta));
                    cmd.Parameters.Add("eretienereceta", System.Convert.ToChar(modelo.Retiene));
                    cmd.Parameters.Add("eentrega_id", modelo.EntregaID);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Int32);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        id = cmd.ExecuteNonQuery();
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

        public static int FolioControlado(SIFModelo.Sucursal sucursal, string prefijo)
        {
            object id;
            //string sentencia = "SELECT NVL(COUNT(folio),0) + 1 FROM CONTROLADO WHERE TO_CHAR(fecha_entrega,'YY') = :prefijoFolio AND sucursal_id = :sucursalID";

            string sentencia = "SELECT SEC_CONTROLADOS.NEXTVAL FROM DUAL";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.Parameters.Add("sucursalID", sucursal.SucursalesID);
                    //cmd.Parameters.Add("prefijoFolio", prefijo);
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

        public static string FolioAntibiotico(SIFModelo.Controlado controlado)
        {
            object id;
            string sentencia = "SELECT rn FROM CS_REP_ANTIBIOTICOS WHERE FOLIO = :Folio AND sucursal_id = :SucursalID";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalID", controlado.SucursalId);
                    cmd.Parameters.Add("Folio", controlado.Folio);
                    cmd.BindByName = true;
                    cmd.CommandTimeout = 30;

                    try
                    {
                        cmd.Connection.Open();
                        id = cmd.ExecuteScalar();
                        if (string.IsNullOrEmpty(id.ToString()))
                        {
                            return null;
                        }
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                }
            }
            return id.ToString();
        }

        public static bool InsertaControlado(SIFModelo.Controlado modelo)
        {
            string sentencia = "sp_ins_controlado";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalId);
                    cmd.Parameters.Add("folio", modelo.Folio);
                    cmd.Parameters.Add("medico_id", modelo.MedicoID);
                    cmd.Parameters.Add("fecha_entrega", modelo.FechaEntrega);
                    cmd.Parameters.Add("usuario_id", modelo.UsuarioID);
                    cmd.Parameters.Add("remision_id", modelo.RemisionID);
                    cmd.Parameters.Add("receta", System.Convert.ToChar(modelo.Receta));
                    cmd.Parameters.Add("retencion", System.Convert.ToChar(modelo.Receta));
                    cmd.Parameters.Add("entrega_id", modelo.EntregaID);

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

        public static bool InsertaDetalleControlado(SIFModelo.ControladoDetalle modelo)
        {
            string sentencia = "sp_ins_controlado_det";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("folio", modelo.Folio);
                    cmd.Parameters.Add("num_partida", modelo.NumeroPartida);
                    cmd.Parameters.Add("articulo_id", modelo.ArticuloID);
                    cmd.Parameters.Add("nombre1", modelo.Nombre1);
                    cmd.Parameters.Add("nombre2", modelo.Nombre2);
                    cmd.Parameters.Add("cantidad", modelo.Cantidad);
                    cmd.Parameters.Add("precio", modelo.Precio);
                    cmd.Parameters.Add("iva", modelo.IVA);
                    cmd.Parameters.Add("impuesto_id", modelo.ImpuestoID);
                    cmd.Parameters.Add("descuento_id", modelo.DescuentoID);
                    cmd.Parameters.Add("precio_costo", modelo.PrecioCosto);
                    cmd.Parameters.Add("activo", (char)modelo.Activo);

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

        //public static DataSet BuscaControlados(SIFModelo.Sucursal sucursal, SIFModelo.Controlado controlado)
        //{
        //    DataSet ds = new DataSet("DSControlado");
        //    ds.Tables.Add("Controlado");
        //    string sentencia = "SELECT * FROM CONTROLADO WHERE  sucursal_id = :SucursalId AND FOLIO LIKE :Folio ";

        //    using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
        //    {

        //        using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
        //        {
        //            cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
        //            cmd.Parameters.Add("Folio", "%" + controlado.Folio + "%");
        //            //
        //            cmd.Connection.Open();
        //            OracleDataAdapter da = new OracleDataAdapter(cmd);
        //            da.Fill(ds, "Controlado");
        //        }

        //    }

        //    ds.Tables.Add("ControladoDetalles");
        //    string sentenciaDetalles = "select * from CONTROLADO_DET where sucursal_id = :sucursalId AND FOLIO in ( SELECT folio FROM CONTROLADO WHERE  sucursal_id = :SucursalId AND FOLIO LIKE :Folio )  ";

        //    using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
        //    {

        //        using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
        //        {
        //            cmd.Parameters.Add("sucursalId", sucursal.SucursalesID);
        //            cmd.Parameters.Add("sucursalesId", sucursal.SucursalesID);
        //            cmd.Parameters.Add("Folio", "%" + controlado.Folio + "%");
        //            //
        //            cmd.Connection.Open();
        //            OracleDataAdapter da = new OracleDataAdapter(cmd);
        //            da.Fill(ds, "ControladoDetalles");
        //        }

        //    }

        //    return ds;
        //}


        public static SIFModelo.Ventas.ControladoDataSet BuscaControlados(SIFModelo.Sucursal sucursal, SIFModelo.Controlado controlado)
        {
            SIFModelo.Ventas.ControladoDataSet ds = new SIFModelo.Ventas.ControladoDataSet();

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.Ventas.ControladoDataSetTableAdapters.CONTROLADOSTableAdapter ta = new SIFModelo.Ventas.ControladoDataSetTableAdapters.CONTROLADOSTableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;

                ta.FillByFOLIO(ds.CONTROLADOS, "%" + controlado.Folio + "%");
            }

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.Ventas.ControladoDataSetTableAdapters.CONTROLADO_DETTableAdapter ta = new SIFModelo.Ventas.ControladoDataSetTableAdapters.CONTROLADO_DETTableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;
                ds.EnforceConstraints = false;
                ta.FillByFOLIO_SUCURSAL(ds.CONTROLADO_DET, "%" + controlado.Folio + "%", sucursal.SucursalesID.ToString());
            }

            return ds;
        }


        public static bool InsertaControladoBulk(SIFModelo.Controlado controlado, List<SIFModelo.RemisionDetalle> detalles)
        {
            string sentencia = "PKG_VENTAS.sp_ins_controlado";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    if(string.IsNullOrEmpty(controlado.RemisionID))
                    {
                    controlado.RemisionID = "0";
                    }

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;
                    char receta = (char)controlado.Receta;
                    char retiene = (char)controlado.Retiene;

                    
                    cmd.Parameters.Add("psucursal_id",OracleDbType.Decimal,controlado.SucursalId,ParameterDirection.Input);

                    cmd.Parameters.Add("pfolio", OracleDbType.Varchar2, controlado.Folio,ParameterDirection.Input);

                    cmd.Parameters.Add("pmedico_id", OracleDbType.Decimal,controlado.MedicoID, ParameterDirection.Input);

                    cmd.Parameters.Add("pusuario_id", OracleDbType.Varchar2, controlado.UsuarioID.ToString(), ParameterDirection.Input);
 
                    cmd.Parameters.Add("premision_id", OracleDbType.Varchar2, controlado.RemisionID, ParameterDirection.Input);

                    cmd.Parameters.Add("preceta", OracleDbType.Char, receta.ToString(), ParameterDirection.Input);

                    cmd.Parameters.Add("pretencion", OracleDbType.Char, retiene.ToString(), ParameterDirection.Input);

                    cmd.Parameters.Add("pentrega_id", OracleDbType.Varchar2, controlado.EntregaID.ToString(), ParameterDirection.Input);


                    //VALORES

                    List<decimal> lnum_partida = new List<decimal>();
                    List<string> larticulo_id = new List<string>();
                    List<string> lnombre1 = new List<string>();
                    List<string> lnombre2 = new List<string>();
                    List<decimal> lcant_remision = new List<decimal>();
                    List<decimal> lprecio = new List<decimal>();
                    List<decimal> liva = new List<decimal>();
                    List<decimal> limpuesto_id = new List<decimal>();
                    List<decimal> ldescuento_id = new List<decimal>();
                    List<decimal> lprecio_costo = new List<decimal>();
                    List<string> lactivo = new List<string>();

                    int numPartida = 1;
                    foreach (var detalle in detalles)
                    {
                        lnum_partida.Add(numPartida);
                        numPartida++;

                        larticulo_id.Add(detalle.ArticuloID);
                        lnombre1.Add(detalle.Nombre1);
                        lnombre2.Add(detalle.Nombre2);
                        lcant_remision.Add(detalle.CantidadRemision);
                        lprecio.Add(detalle.Precio);
                        liva.Add(detalle.IVA);
                        limpuesto_id.Add(detalle.ImpuestoID);
                        ldescuento_id.Add(detalle.DescuentoID);
                        lprecio_costo.Add(detalle.PrecioCosto);
                        lactivo.Add(((char)SIFModelo.Tipos.SiNo.SI).ToString());
                    }

                    // IN ARRAY PARAMETERS
                    OracleParameter pnum_partida = cmd.Parameters.Add("pnum_partida", OracleDbType.Decimal);
                    pnum_partida.Direction = ParameterDirection.Input;
                    pnum_partida.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pnum_partida.Value = lnum_partida.ToArray();

                    OracleParameter particulo_id = cmd.Parameters.Add("particulo_id", OracleDbType.Varchar2);
                    particulo_id.Direction = ParameterDirection.Input;
                    particulo_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    particulo_id.Value = larticulo_id.ToArray();

                    OracleParameter pnombre1 = cmd.Parameters.Add("pnombre1", OracleDbType.Varchar2);
                    pnombre1.Direction = ParameterDirection.Input;
                    pnombre1.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pnombre1.Value = lnombre1.ToArray();

                    OracleParameter pnombre2 = cmd.Parameters.Add("pnombre2", OracleDbType.Varchar2);
                    pnombre2.Direction = ParameterDirection.Input;
                    pnombre2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pnombre2.Value = lnombre2.ToArray();

                    OracleParameter pcant_remision = cmd.Parameters.Add("pcant_remision", OracleDbType.Decimal);
                    pcant_remision.Direction = ParameterDirection.Input;
                    pcant_remision.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pcant_remision.Value = lcant_remision.ToArray();

                    OracleParameter pprecio = cmd.Parameters.Add("pprecio", OracleDbType.Decimal);
                    pprecio.Direction = ParameterDirection.Input;
                    pprecio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pprecio.Value = lprecio.ToArray();

                    OracleParameter piva = cmd.Parameters.Add("piva", OracleDbType.Decimal);
                    piva.Direction = ParameterDirection.Input;
                    piva.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    piva.Value = liva.ToArray();

                    OracleParameter pimpuesto_id = cmd.Parameters.Add("pimpuesto_id", OracleDbType.Decimal);
                    pimpuesto_id.Direction = ParameterDirection.Input;
                    pimpuesto_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pimpuesto_id.Value = limpuesto_id.ToArray();

                    OracleParameter pdescuento_id = cmd.Parameters.Add("pdescuento_id", OracleDbType.Decimal);
                    pdescuento_id.Direction = ParameterDirection.Input;
                    pdescuento_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pdescuento_id.Value = ldescuento_id.ToArray();

                    OracleParameter pprecio_costo = cmd.Parameters.Add("pprecio_costo", OracleDbType.Decimal);
                    pprecio_costo.Direction = ParameterDirection.Input;
                    pprecio_costo.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pprecio_costo.Value = lprecio_costo.ToArray();

                    OracleParameter pactivo = cmd.Parameters.Add("pactivo", OracleDbType.Varchar2);
                    pactivo.Direction = ParameterDirection.Input;
                    pactivo.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pactivo.Value = lactivo.ToArray();

                    //TERMINA ARRAY

                    OracleParameter outparam = new OracleParameter("OutParam", OracleDbType.Int32);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outparam);


                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        var id = outparam.Value;
                        if (id.ToString().IsInteger())
                        {
                            if (int.Parse(id.ToString()) < 0)
                            {
                                throw new Exception("Ha ocurrido un error al insertar el registro" + id.ToString());
                            }

                            //modelo. = int.Parse(id.ToString());
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
