using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using Oracle.DataAccess.Types;

namespace SIFDatos
{
    public class Remision
    {
        public static bool InsertaRemision(SIFModelo.Remision modelo)
        {
            string sentencia = "sp_ins_remision";
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
                    cmd.Parameters.Add("total", modelo.Total);
                    cmd.Parameters.Add("total_articulos_rem", modelo.TotalArticulosRemision);
                    cmd.Parameters.Add("num_factura", System.Convert.ToChar(modelo.Factura));
                    cmd.Parameters.Add("activo", System.Convert.ToChar('G'));
                    cmd.Parameters.Add("importe_letra", modelo.ImporteLetra);
                    cmd.Parameters.Add("factura", System.Convert.ToChar(modelo.Factura));
                    cmd.Parameters.Add("comentarios", modelo.Comentarios);
                    cmd.Parameters.Add("num_pedido", modelo.NumeroPedido);
                    cmd.Parameters.Add("beneficio_prov", System.Convert.ToChar(modelo.BeneficioProveedor));

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

        public static bool InsertaRemisionBulk(SIFModelo.Remision modelo, List<SIFModelo.RemisionDetalle> detalles)
        {
            foreach (SIFModelo.RemisionDetalle d in detalles)
            {
                d.MontoDescuento = d.MontoDescuento;
            }

            string sentencia = "PKG_VENTAS.sp_ins_remision";
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
                    //VALORES


                    var Vnum_partida = from d in detalles select d.NumeroPartida;
                    var Varticulo_id = from d in detalles select d.ArticuloID;
                    var Vcod_cliente = from d in detalles select d.CODIGO_CLI;
                    var Vnombre1 = from d in detalles select d.Nombre1;
                    var Vnombre2 = from d in detalles select d.Nombre2;
                    var Vfechaent = from d in detalles select d.FechaEntrega;
                    var Vcant_remision = from d in detalles select (d.CantidadRemision/*- d.PiezasGratis*/);
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
                            if (int.Parse(id.ToString()) < 0)
                            {
                                throw new Exception("Ha ocurrido un error al insertar el registro" + id.ToString());
                            }

                            //modelo. = int.Parse(id.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Helpers.Audita.InsertaAudit(modelo.VendedorID.ToString(), "PKG_VENTAS.sp_ins_remision", "sucursal_id-" + modelo.SucursalID + " num_remision- " + modelo.NumeroRemision + " cliente_id-" + modelo.ClienteID, "", ex.Message);
                        throw ex;
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

        public static bool InsertaRemisionDetalle(SIFModelo.RemisionDetalle modelo)
        {
            string refRemision = modelo.RefOferta.ToString();
            if (refRemision == "0")
            {
                refRemision = "";
            }

            string sentencia = "sp_ins_remision_det";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("num_remision", modelo.NumeroRemision);
                    cmd.Parameters.Add("num_partida", modelo.NumeroPartida);
                    cmd.Parameters.Add("articulo_id", modelo.ArticuloID);
                    cmd.Parameters.Add("nombre1", modelo.Nombre1);
                    cmd.Parameters.Add("nombre2", modelo.Nombre2);
                    cmd.Parameters.Add("fechaent", modelo.FechaEntrega);
                    cmd.Parameters.Add("cant_remision", modelo.CantidadRemision);
                    cmd.Parameters.Add("precio", modelo.Precio);
                    cmd.Parameters.Add("iva", modelo.IVA);
                    cmd.Parameters.Add("impuesto_id", modelo.ImpuestoID);
                    cmd.Parameters.Add("descuento_id", modelo.DescuentoID);
                    cmd.Parameters.Add("precio_costo", modelo.PrecioCosto);
                    cmd.Parameters.Add("folio_controlado", modelo.FolioControlado);
                    cmd.Parameters.Add("paquete_id", modelo.PaqueteID);
                    cmd.Parameters.Add("ref_nadro", modelo.ReferenciaNADRO);
                    cmd.Parameters.Add("lote", modelo.Lote);
                    cmd.Parameters.Add("caducidad", modelo.Caducidad);
                    cmd.Parameters.Add("ref_oferta", refRemision);
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
        public static List<SIFModelo.RemisionDetalle> RemisionDetallesF(SIFModelo.Remision remision)
        {
            List<SIFModelo.RemisionDetalle> rows = new List<SIFModelo.RemisionDetalle>();

            string sentencia = "SELECT * FROM remision_det WHERE num_remision = :RemisionId AND sucursal_id = :SucursalID AND cant_remision > 0";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("RemisionId", remision.NumeroRemision);
                    cmd.Parameters.Add("SucursalID", remision.SucursalID);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.RemisionDetalle registro = new SIFModelo.RemisionDetalle();

                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.NumeroRemision = oreader["NUM_REMISION"].ToString();
                            registro.NumeroPartida = int.Parse(oreader["NUM_PARTIDA"].ToString());
                            registro.ArticuloID = oreader["ARTICULO_ID"].ToString();
                            registro.Nombre1 = oreader["NOMBRE1"].ToString();
                            registro.Nombre2 = oreader["NOMBRE2"].ToString();
                            registro.FechaEntrega = oreader["FECHAENT"].ToString();
                            registro.CantidadRemision = int.Parse(oreader["CANT_REMISION"].ToString());
                            registro.Precio = decimal.Parse(oreader["PRECIO"].ToString());
                            registro.IVA = decimal.Parse(oreader["IVA"].ToString());
                            registro.ImpuestoID = int.Parse(oreader["IMPUESTO_ID"].ToString());
                            registro.DescuentoID = int.Parse(oreader["DESCUENTO_ID"].ToString());
                            registro.PrecioCosto = decimal.Parse(oreader["PRECIO_COSTO"].ToString());
                            registro.FolioControlado = (oreader["FOLIO_CONTROLADO"].ToString());
                            registro.PaqueteID = int.Parse(oreader["PAQUETE_ID"].ToString());
                            registro.ReferenciaNADRO = oreader["REF_NADRO"].ToString();
                            registro.Lote = oreader["LOTE"].ToString();
                            if (registro.IVA > 0)
                                registro.Precio = registro.Precio - (registro.IVA / registro.CantidadRemision);

                            string codcli = oreader["CODIGO_CLI"].ToString();
                            //if (!string.IsNullOrEmpty( codcli))
                            //    registro.CODIGO_CLI_ID = int.Parse(codcli);


                            var ref_oferta = oreader["ref_oferta"];
                            if (ref_oferta.ToString().IsInteger())
                            {
                                registro.RefOferta = int.Parse(oreader["ref_oferta"].ToString());
                            }


                            var caducidad = oreader["CADUCIDAD"];

                            if (caducidad.ToString().IsDatetime())
                            {
                                registro.Caducidad = DateTime.Parse(oreader["CADUCIDAD"].ToString());
                            }

                            registro.Total = registro.CantidadRemision * registro.Precio;

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
        public static List<SIFModelo.RemisionDetalle> RemisionDetalles(SIFModelo.Remision remision)
        {
            List<SIFModelo.RemisionDetalle> rows = new List<SIFModelo.RemisionDetalle>();

            string sentencia = "SELECT * FROM remision_det WHERE num_remision = :RemisionId AND sucursal_id = :SucursalID AND cant_remision > 0";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("RemisionId", remision.NumeroRemision);
                    cmd.Parameters.Add("SucursalID", remision.SucursalID);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.RemisionDetalle registro = new SIFModelo.RemisionDetalle();

                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.NumeroRemision = oreader["NUM_REMISION"].ToString();
                            registro.NumeroPartida = int.Parse(oreader["NUM_PARTIDA"].ToString());
                            registro.ArticuloID = oreader["ARTICULO_ID"].ToString();
                            registro.Nombre1 = oreader["NOMBRE1"].ToString();
                            registro.Nombre2 = oreader["NOMBRE2"].ToString();
                            registro.FechaEntrega = oreader["FECHAENT"].ToString();
                            registro.CantidadRemision = int.Parse(oreader["CANT_REMISION"].ToString());
                            registro.Precio = decimal.Parse(oreader["PRECIO"].ToString());
                            registro.IVA = decimal.Parse(oreader["IVA"].ToString());
                            registro.ImpuestoID = int.Parse(oreader["IMPUESTO_ID"].ToString());
                            registro.DescuentoID = int.Parse(oreader["DESCUENTO_ID"].ToString());
                            registro.PrecioCosto = decimal.Parse(oreader["PRECIO_COSTO"].ToString());
                            registro.FolioControlado = (oreader["FOLIO_CONTROLADO"].ToString());
                            registro.PaqueteID = int.Parse(oreader["PAQUETE_ID"].ToString());
                            registro.ReferenciaNADRO = oreader["REF_NADRO"].ToString();
                            registro.Lote = oreader["LOTE"].ToString();
                            //   if (registro.IVA>0)
                            //     registro.Precio = registro.Precio - (registro.IVA / registro.CantidadRemision);

                            string codcli = oreader["CODIGO_CLI"].ToString();
                            //if (!string.IsNullOrEmpty( codcli))
                            //    registro.CODIGO_CLI_ID = int.Parse(codcli);


                            var ref_oferta = oreader["ref_oferta"];
                            if (ref_oferta.ToString().IsInteger())
                            {
                                registro.RefOferta = int.Parse(oreader["ref_oferta"].ToString());
                            }


                            var caducidad = oreader["CADUCIDAD"];

                            if (caducidad.ToString().IsDatetime())
                            {
                                registro.Caducidad = DateTime.Parse(oreader["CADUCIDAD"].ToString());
                            }

                            registro.Total = registro.CantidadRemision * registro.Precio;

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

        public static List<SIFModelo.Remision> RemisionesNoPagadas(SIFModelo.Sucursal sucursal)
        {
            List<SIFModelo.Remision> rows = new List<SIFModelo.Remision>();

            string sentencia = "SELECT * FROM remision WHERE WHERE remision.sucursal_id = :SucursalID AND  total > " +
" (SELECT NVL(SUM(IMPORTE_TOTAL),0) FROM pagos WHERE REMISION_ID = remision.NUM_REMISION AND pagos.sucursal_id = remision.sucursal_id) ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalID", sucursal.SucursalesID);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Remision registro = new SIFModelo.Remision();

                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.NumeroRemision = oreader["NUM_REMISION"].ToString();
                            registro.TipoClienteID = int.Parse(oreader["TIPO_CLIENTE_ID"].ToString());
                            registro.ClienteID = int.Parse(oreader["CLIENTE_ID"].ToString());
                            registro.FechaVenta = DateTime.Parse(oreader["FECHA_VTA"].ToString());
                            registro.Receta = (SIFModelo.Tipos.SiNo)(oreader["RECETA"].ToString()[0]);
                            registro.MedicoID = int.Parse(oreader["ID_MEDICO"].ToString());
                            registro.FechaPago = DateTime.Parse(oreader["FECHA_PAGO"].ToString());
                            registro.VendedorID = int.Parse(oreader["VENDEDOR_ID"].ToString());
                            registro.MonedaID = int.Parse(oreader["MONEDA_ID"].ToString());
                            registro.TipoCambio = int.Parse(oreader["TIPO_CAMBIO_ID"].ToString());
                            registro.Condiciones = (oreader["CONDICIONES"].ToString());
                            registro.SubTotal = decimal.Parse(oreader["SUBTOTAL"].ToString());
                            registro.Impuesto = int.Parse(oreader["IMPUESTO_IVA"].ToString());
                            registro.Descuento = decimal.Parse(oreader["DESCUENTO"].ToString());
                            registro.Total = decimal.Parse(oreader["TOTAL"].ToString());
                            registro.TotalArticulosRemision = decimal.Parse(oreader["TOTAL_ARTICULOS_REM"].ToString());
                            registro.NumeroFactura = (oreader["NUM_FACTURA"].ToString());
                            registro.Activo = (SIFModelo.Tipos.StatusVenta)(oreader["ACTIVO"].ToString()[0]);
                            registro.ImporteLetra = oreader["IMPORTE_LETRA"].ToString();
                            registro.Factura = (SIFModelo.Tipos.SiNo)(oreader["FACTURA"].ToString()[0]);
                            registro.Comentarios = oreader["COMENTARIOS"].ToString();
                            registro.NumeroPedido = oreader["NUM_PEDIDO"].ToString();
                            registro.BeneficioProveedor = (SIFModelo.Tipos.SiNo)oreader["BENEFICIO_PROV"].ToString()[0];


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


        public static DataSet RemisionesNoPagadas(SIFModelo.Sucursal sucursal, SIFModelo.Remision remision)
        {
            DataSet ds = new DataSet("DSRemisiones");
            ds.Tables.Add("Remisiones");
            string sentencia = "SELECT * FROM remision WHERE  sucursal_id = :SucursalId AND activo = 'G' AND NUM_REMISION LIKE :NumeroRemision ORDER BY fecha_vta DESC ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroRemision", "%" + remision.NumeroRemision + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Remisiones");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            ds.Tables.Add("RemisionDetalles");
            string sentenciaDetalles = "select * from remision_det where sucursal_id = :sucursalId AND num_remision in (  SELECT num_remision FROM remision WHERE  sucursal_id = :SucursalesId AND activo = 'G' AND NUM_REMISION LIKE :NumeroRemision) ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                {
                    cmd.Parameters.Add("sucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("SucursalesId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroRemision", "%" + remision.NumeroRemision + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "RemisionDetalles");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            return ds;
        }

        public static DataSet Remisiones(SIFModelo.Sucursal sucursal, SIFModelo.Remision remision, DateTime fecha1, DateTime fecha2)
        {
            DataSet ds = new DataSet("DSRemisiones");
            ds.Tables.Add("Remisiones");
            string sentencia = "SELECT * FROM remision WHERE NUM_REMISION LIKE :NumeroRemision "; //sucursal_id = :SucursalId AND

            sentencia += " AND FECHA_VTA >= TO_DATE('" + fecha1.ToString("yyyy-MM-dd 00:00:00") + "', 'YYYY-MM-DD HH24:MI:SS') AND FECHA_VTA <= TO_DATE('" + fecha2.ToString("yyyy-MM-dd 23:59:59") + "', 'YYYY-MM-DD HH24:MI:SS')";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    // cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroRemision", "%" + remision.NumeroRemision + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Remisiones");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            string folios = "";
            int contador = 0;
            foreach (DataRow rwRemision in ds.Tables["Remisiones"].Rows)
            {
                folios += "'" + rwRemision["NUM_REMISION"].ToString() + "',";
                contador++;
            }

            folios = folios.Trim(',');


            if (string.IsNullOrEmpty(folios))
            {
                folios = "'0'";
                //ds.Tables.Add("RemisionDetalles");
                //return ds;

            }

            if (contador > 1000)
            {
                folios = "'0'";
                DevComponents.DotNetBar.MessageBoxEx.Show("La cantidad de datos es muy grande, los detalles no estarán disponibles para esta consulta", "Detalles", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
            }

            ds.Tables.Add("RemisionDetalles");
            string sentenciaDetalles = "select * from remision_det where  num_remision in (" + folios + ")  "; //sucursal_id = :sucursalId AND

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                {
                    //cmd.Parameters.Add("sucursalId", sucursal.SucursalesID);
                    //cmd.Parameters.Add("sucursalesId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroRemision", "%" + remision.NumeroRemision + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "RemisionDetalles");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            return ds;
        }

        public static int NumeroRemision(int sucursalId, string prefijoFolio)
        {
            object id;
            string sentencia = "SELECT NVL(MAX(FOLIO_NUM),0) + 1 FROM cat_folio_venta WHERE prefijo_folio = :prefijoFolio AND sucursal_id = :sucursalID";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("sucursalID", sucursalId);
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
                    catch (Exception ex)
                    {
                        Helpers.Audita.InsertaAudit("", "SELECT MAX FOLIO VENTA", "sucursalID-" + sucursalId + " prefijoFolio- " + prefijoFolio, "", ex.Message);
                        throw ex;

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

        public static int NumeroCancelacion(int sucursalId, string prefijoFolio)
        {
            object id;
            string sentencia = "SELECT NVL(COUNT(devolucion_id),0) + 1 FROM devolucion WHERE TO_CHAR( fecha_dev,'YY') = :prefijoFolio AND sucursal_id = :sucursalID";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("sucursalID", sucursalId);
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
                    catch (Exception ex)
                    {
                        Helpers.Audita.InsertaAudit("", "SELECT devolucion_id FROM devolucion", "sucursalID-" + sucursalId + " prefijoFolio- " + prefijoFolio, "", ex.Message);
                        throw ex;
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

        public static bool InsertaFolioRemision(int sucursalId, string prefijo, int numRemision)
        {
            string sentencia = "sp_ins_cat_folio_venta";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("sucursal_id", sucursalId);
                    cmd.Parameters.Add("prefijo_folio", prefijo);
                    cmd.Parameters.Add("folio_num", numRemision);

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

                            //modelo. = int.Parse(id.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Helpers.Audita.InsertaAudit("", "sp_ins_cat_folio_venta", "sucursalID-" + sucursalId + " prefijoFolio- " + prefijo + " folio_num-" + numRemision, "", ex.Message);
                        throw ex;
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

        //public static bool Cancela(SIFModelo.Remision modelo)
        //{
        //    string sentencia = "UPDATE remision SET activo = 'C' WHERE sucursal_id = :SucursalID AND num_remision = :RemisionID ";
        //    using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
        //    {
        //        using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
        //        {
        //            //PARAMETROS
        //            cmd.Parameters.Add("SucursalID", modelo.SucursalID);
        //            cmd.Parameters.Add("RemisionID", modelo.NumeroRemision);

        //            try
        //            {
        //                cmd.Connection.Open();
        //                cmd.ExecuteNonQuery();
        //            }
        //            catch (Exception)
        //            {
        //                return false;
        //            }
        //            finally
        //            {
        //                cmd.Connection.Close();
        //            }

        //        }
        //    }

        //    return true;
        //}

        public static bool Cancela(SIFModelo.Remision modelo)
        {
            string sentencia = "SIF_VENTAS_PKG.SP_CANCELA_VTA";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("suc_id", modelo.SucursalID);
                    cmd.Parameters.Add("num_rem", modelo.NumeroRemision);

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Int32);
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
                            if (int.Parse(id.ToString()) < 0)
                            {
                                throw new Exception("Ha ocurrido un error al insetrar el registro" + id.ToString());
                            }

                            //modelo. = int.Parse(id.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Helpers.Audita.InsertaAudit("", "SIF_VENTAS_PKG.SP_CANCELA_VTA", "sucursalID-" + modelo.SucursalID + " num_rem- " + modelo.NumeroRemision, "", ex.Message);
                        throw ex;
                        //throw ex;
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

        public static List<SIFModelo.Remision> PedidosApartadosPendientes24hrs(SIFModelo.Sucursal sucursal)
        {
            List<SIFModelo.Remision> rows = new List<SIFModelo.Remision>();

            string sentencia = "SELECT * FROM remision WHERE sucursal_id = :SucursalId AND fecha_vta < (SYSDATE- 1)  AND activo = 'G' ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //PARAMETROS
                    cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Remision registro = new SIFModelo.Remision();

                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.NumeroRemision = oreader["NUM_REMISION"].ToString();
                            registro.TipoClienteID = int.Parse(oreader["TIPO_CLIENTE_ID"].ToString());
                            registro.ClienteID = int.Parse(oreader["CLIENTE_ID"].ToString());
                            registro.FechaVenta = DateTime.Parse(oreader["FECHA_VTA"].ToString());
                            registro.Receta = (SIFModelo.Tipos.SiNo)(oreader["RECETA"].ToString()[0]);
                            registro.MedicoID = int.Parse(oreader["ID_MEDICO"].ToString());
                            registro.FechaPago = DateTime.Parse(oreader["FECHA_PAGO"].ToString());
                            registro.VendedorID = int.Parse(oreader["VENDEDOR_ID"].ToString());
                            registro.MonedaID = int.Parse(oreader["MONEDA_ID"].ToString());
                            registro.TipoCambio = int.Parse(oreader["TIPO_CAMBIO_ID"].ToString());
                            registro.Condiciones = (oreader["CONDICIONES"].ToString());
                            registro.SubTotal = decimal.Parse(oreader["SUBTOTAL"].ToString());
                            registro.Impuesto = int.Parse(oreader["IMPUESTO_IVA"].ToString());
                            registro.Descuento = decimal.Parse(oreader["DESCUENTO"].ToString());
                            registro.Total = decimal.Parse(oreader["TOTAL"].ToString());
                            registro.TotalArticulosRemision = decimal.Parse(oreader["TOTAL_ARTICULOS_REM"].ToString());
                            registro.NumeroFactura = (oreader["NUM_FACTURA"].ToString());
                            registro.Activo = (SIFModelo.Tipos.StatusVenta)(oreader["ACTIVO"].ToString()[0]);
                            registro.ImporteLetra = oreader["IMPORTE_LETRA"].ToString();
                            registro.Factura = (SIFModelo.Tipos.SiNo)(oreader["FACTURA"].ToString()[0]);
                            registro.Comentarios = oreader["COMENTARIOS"].ToString();
                            registro.NumeroPedido = oreader["NUM_PEDIDO"].ToString();
                            registro.BeneficioProveedor = (SIFModelo.Tipos.SiNo)oreader["BENEFICIO_PROV"].ToString()[0];


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

        public static List<SIFModelo.Remision> RemisionesPendientes24hrs(SIFModelo.Sucursal sucursal)
        {
            // throw new NotImplementedException();
            return new List<SIFModelo.Remision>();
        }

        public static DataSet RemisionesFacturadas(SIFModelo.Sucursal sucursal, SIFModelo.Remision remision)
        {
            DataSet ds = new DataSet("DSRemisiones");
            ds.Tables.Add("Remisiones");
            string sentencia = "SELECT * FROM remision WHERE  sucursal_id = :SucursalId AND NUM_REMISION LIKE :NumeroRemision AND FACTURA = :Facturada";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroRemision", "%" + remision.NumeroRemision + "%");
                    cmd.Parameters.Add("Facturada", System.Convert.ToChar(SIFModelo.Tipos.SiNo.SI));
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Remisiones");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            ds.Tables.Add("RemisionDetalles");
            string sentenciaDetalles = "select * from remision_det where sucursal_id = :sucursalId AND num_remision in ( SELECT NUM_REMISION FROM remision WHERE  sucursal_id = :SucursalesId AND NUM_REMISION LIKE :NumeroRemision)  ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                {
                    cmd.Parameters.Add("sucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("sucursalesId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroRemision", "%" + remision.NumeroRemision + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "RemisionDetalles");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            return ds;
        }


        //public static bool ActualizaRemision(SIFModelo.Remision modelo)
        //{
        //    string sentencia = "SP_UPD_REMISION";
        //    using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
        //    {
        //        using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
        //        {
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            cmd.BindByName = true;

        //            //PARAMETROS
        //            cmd.Parameters.Add("esucursal_id", modelo.SucursalID);
        //            cmd.Parameters.Add("enum_remision", modelo.NumeroRemision);
        //            cmd.Parameters.Add("etipo_cliente_id", modelo.TipoClienteID);
        //            cmd.Parameters.Add("ecliente_id", modelo.ClienteID);
        //            cmd.Parameters.Add("efecha_vta", modelo.FechaVenta);
        //            cmd.Parameters.Add("ereceta", Convert.ToChar(modelo.Receta));
        //            cmd.Parameters.Add("eid_medico", modelo.MedicoID);
        //            cmd.Parameters.Add("efecha_pago", modelo.FechaPago);
        //            cmd.Parameters.Add("evendedor_id", modelo.VendedorID);
        //            cmd.Parameters.Add("emoneda_id", modelo.MonedaID);
        //            cmd.Parameters.Add("etipo_cambio_id", modelo.TipoCambio);
        //            cmd.Parameters.Add("econdiciones", modelo.Condiciones);
        //            cmd.Parameters.Add("esubtotal", modelo.SubTotal);
        //            cmd.Parameters.Add("eimpuesto_iva", modelo.Impuesto);
        //            cmd.Parameters.Add("edescuento", modelo.Descuento);
        //            cmd.Parameters.Add("etotal", modelo.Total);
        //            cmd.Parameters.Add("etotal_articulos_rem", modelo.TotalArticulosRemision);
        //            cmd.Parameters.Add("enum_factura", modelo.NumeroFactura);
        //            cmd.Parameters.Add("eactivo", System.Convert.ToChar(modelo.Activo));
        //            cmd.Parameters.Add("eimporte_letra", modelo.ImporteLetra);
        //            cmd.Parameters.Add("efactura", System.Convert.ToChar(modelo.Factura));
        //            cmd.Parameters.Add("ecomentarios", modelo.Comentarios);
        //            cmd.Parameters.Add("enum_pedido", modelo.NumeroPedido);
        //            cmd.Parameters.Add("ebeneficio_prov", System.Convert.ToChar(modelo.BeneficioProveedor));

        //            //PARAMETROS DE SALIDA
        //            OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Int32);
        //            outparam.Direction = System.Data.ParameterDirection.Output;

        //            //AGREGAR LOS PARAMETROS
        //            cmd.Parameters.Add(outparam);
        //            try
        //            {
        //                cmd.Connection.Open();

        //                var id = cmd.ExecuteScalar();
        //                if (outparam.Value.ToString().IsInteger())
        //                {
        //                    if (int.Parse(outparam.Value.ToString()) < 0)
        //                    {
        //                        throw new Exception("Ha ocurrido un error al insetrar el registro" + id.ToString());
        //                    }

        //                    //modelo. = int.Parse(id.ToString());
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Helpers.Audita.InsertaAudit("", "SP_UPD_REMISION", "sucursalID-" + modelo.SucursalID + " enum_remision- " + modelo.NumeroRemision, "", ex.Message);
        //                //throw ex;

        //                return false;
        //            }
        //            finally
        //            {
        //                cmd.Connection.Close();
        //            }

        //        }
        //    }

        //    return true;
        //}


        public static bool CancelaRemision(SIFModelo.Remision modelo, int usuarioid, String nombreUsuario)
        {

            string sentencia = "UPDATE REMISION SET ACTIVO = :eactivo, COMENTARIOS = :ecomentarios WHERE num_remision = :enum_remision AND SUCURSAL_ID = :esucursal_id  ";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.BindByName = true;

                    char activo = System.Convert.ToChar(modelo.Activo);
                    //PARAMETROS
                    cmd.Parameters.Add("esucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("enum_remision", modelo.NumeroRemision);
                    cmd.Parameters.Add("ecomentarios", usuarioid + " " + nombreUsuario + " " + " " + DateTime.Now + ": " + modelo.Comentarios);
                    cmd.Parameters.Add("eactivo", activo);

                    //PARAMETROS DE SALIDA
                    //OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Int32);
                    //outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    //cmd.Parameters.Add(outparam);
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


            try//L 28/11/2013 Insertamos datos del usuario que realiza la cancelacion
            {
                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {

                    OracleCommand cmd = cnx.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_SEGURIDAD.Ins_bitacora";
                    cmd.BindByName = true;

                    cmd.Parameters.Add("OpcionID", OracleDbType.Int32, 65, ParameterDirection.Input);//65:cancelacion de ticket
                    cmd.Parameters.Add("OperacionID", OracleDbType.Int32, 1, ParameterDirection.Input);//1: Nuevo
                    cmd.Parameters.Add("EComentario", OracleDbType.Varchar2, modelo.NumeroRemision, ParameterDirection.Input);
                    cmd.Parameters.Add("UsuarioID", OracleDbType.Int32, usuarioid, ParameterDirection.Input);




                    cmd.Connection.Open();
                    // Execute the command
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                //cmd.Connection.Close();
            }



            return true;
        }

        public static List<SIFModelo.Remision> RemisionesNoFacturadas(SIFModelo.Sucursal sucursal)
        {
            List<SIFModelo.Remision> rows = new List<SIFModelo.Remision>();

            string sentencia = "SELECT * FROM remision WHERE remision.sucursal_id = :SucursalID AND ACTIVO = 'P' AND factura = 'N' ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalID", sucursal.SucursalesID);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Remision registro = new SIFModelo.Remision();

                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.NumeroRemision = oreader["NUM_REMISION"].ToString();
                            registro.TipoClienteID = int.Parse(oreader["TIPO_CLIENTE_ID"].ToString());
                            registro.ClienteID = int.Parse(oreader["CLIENTE_ID"].ToString());
                            registro.FechaVenta = DateTime.Parse(oreader["FECHA_VTA"].ToString());
                            registro.Receta = (SIFModelo.Tipos.SiNo)(oreader["RECETA"].ToString()[0]);
                            registro.MedicoID = int.Parse(oreader["ID_MEDICO"].ToString());
                            registro.FechaPago = DateTime.Parse(oreader["FECHA_PAGO"].ToString());
                            registro.VendedorID = int.Parse(oreader["VENDEDOR_ID"].ToString());
                            registro.MonedaID = int.Parse(oreader["MONEDA_ID"].ToString());
                            registro.TipoCambio = int.Parse(oreader["TIPO_CAMBIO_ID"].ToString());
                            registro.Condiciones = (oreader["CONDICIONES"].ToString());
                            registro.SubTotal = decimal.Parse(oreader["SUBTOTAL"].ToString());
                            registro.Impuesto = decimal.Parse(oreader["IMPUESTO_IVA"].ToString());
                            registro.Descuento = decimal.Parse(oreader["DESCUENTO"].ToString());
                            registro.Total = decimal.Parse(oreader["TOTAL"].ToString());
                            registro.TotalArticulosRemision = decimal.Parse(oreader["TOTAL_ARTICULOS_REM"].ToString());
                            registro.NumeroFactura = (oreader["NUM_FACTURA"].ToString());
                            registro.Activo = (SIFModelo.Tipos.StatusVenta)(oreader["ACTIVO"].ToString()[0]);
                            registro.ImporteLetra = oreader["IMPORTE_LETRA"].ToString();
                            registro.Factura = (SIFModelo.Tipos.SiNo)(oreader["FACTURA"].ToString()[0]);
                            registro.Comentarios = oreader["COMENTARIOS"].ToString();
                            registro.NumeroPedido = oreader["NUM_PEDIDO"].ToString();
                            registro.BeneficioProveedor = (SIFModelo.Tipos.SiNo)oreader["BENEFICIO_PROV"].ToString()[0];


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

        public static DataSet RemisionesNoPagadas(SIFModelo.Sucursal sucursal, SIFModelo.Remision remision, DateTime fecha1, DateTime fecha2, String estado)
        {
            string numremisiones = "'%'";
            string estadoR = "'%'";
            DataSet ds = new DataSet("DSRemisiones");
            ds.Tables.Add("Remisiones");
            string sentencia = "SELECT remision.* , CAT_USUARIOS.NOMBRE AS VEDNOMBRE, ORI_REMISION(remision.sucursal_id, remision.num_remision) origen FROM remision INNER JOIN CAT_USUARIOS ON CAT_USUARIOS.USUARIOS_ID=REMISION.VENDEDOR_ID WHERE REMISION.NUM_REMISION LIKE :NumeroRemision "; //sucursal_id = :SucursalId AND

            sentencia += " AND FECHA_VTA >= TO_DATE('" + fecha1.ToString("yyyy-MM-dd 00:00:00") + "', 'YYYY-MM-DD HH24:MI:SS') AND FECHA_VTA <= TO_DATE('" + fecha2.ToString("yyyy-MM-dd 23:59:59") + "', 'YYYY-MM-DD HH24:MI:SS') AND REMISION.ACTIVO LIKE :estado";

            sentencia += " ORDER BY FECHA_VTA DESC";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    // cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroRemision", "%" + remision.NumeroRemision + "%");
                    cmd.Parameters.Add("estado", estado);
                    numremisiones = "%" + remision.NumeroRemision + "%";
                    estadoR = estado;
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Remisiones");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            string folios = "";

            foreach (DataRow rwRemision in ds.Tables["Remisiones"].Rows)
            {
                folios += "'" + rwRemision["NUM_REMISION"].ToString() + "'" + ",";
            }

            folios = folios.Trim(',');

            if (string.IsNullOrEmpty(folios))
            {
                folios = "''";
                //ds.Tables.Add("RemisionDetalles");
                //return ds;
            }

            ds.Tables.Add("RemisionDetalles");
            //string sentenciaDetalles = "select * from remision_det where  num_remision in (" + folios + ")  "; //sucursal_id = :sucursalId AND
            string sentenciaDetalles = "select * from remision_det where  num_remision in (  ";
            sentenciaDetalles += "SELECT remision.NUM_REMISION FROM remision INNER JOIN CAT_USUARIOS ON CAT_USUARIOS.USUARIOS_ID=REMISION.VENDEDOR_ID WHERE REMISION.NUM_REMISION LIKE '" + numremisiones + "'"; //sucursal_id = :SucursalId AND

            sentenciaDetalles += " AND FECHA_VTA >= TO_DATE('" + fecha1.ToString("yyyy-MM-dd 00:00:00") + "', 'YYYY-MM-DD HH24:MI:SS') AND FECHA_VTA <= TO_DATE('" + fecha2.ToString("yyyy-MM-dd 23:59:59") + "', 'YYYY-MM-DD HH24:MI:SS') AND REMISION.ACTIVO LIKE '" + estadoR + "')";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                {
                    //cmd.Parameters.Add("sucursalId", sucursal.SucursalesID);
                    //cmd.Parameters.Add("sucursalesId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroRemision", "%" + remision.NumeroRemision + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    try
                    {
                        da.Fill(ds, "RemisionDetalles");
                    }
                    catch (Exception ex)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);

                }

            }

            return ds;
        }

        public static DataSet RemisionesNoPagadasCredito(SIFModelo.Sucursal sucursal, SIFModelo.Remision remision, DateTime fecha1, DateTime fecha2, String estado)
        {
            DataSet ds = new DataSet("DSRemisiones");
            ds.Tables.Add("Remisiones");
            string sentencia = "SELECT * FROM remision WHERE  tipo_cambio_id=1 and NUM_REMISION LIKE :NumeroRemision "; //sucursal_id = :SucursalId AND

            sentencia += " AND FECHA_VTA >= TO_DATE('" + fecha1.ToString("yyyy-MM-dd 00:00:00") + "', 'YYYY-MM-DD HH24:MI:SS') AND FECHA_VTA <= TO_DATE('" + fecha2.ToString("yyyy-MM-dd 23:59:59") + "', 'YYYY-MM-DD HH24:MI:SS') AND ACTIVO LIKE :estado";

            sentencia += " ORDER BY FECHA_VTA DESC";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    // cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroRemision", "%" + remision.NumeroRemision + "%");
                    cmd.Parameters.Add("estado", estado);
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Remisiones");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            string folios = "";

            foreach (DataRow rwRemision in ds.Tables["Remisiones"].Rows)
            {
                folios += "'" + rwRemision["NUM_REMISION"].ToString() + "'" + ",";
            }

            folios = folios.Trim(',');

            if (string.IsNullOrEmpty(folios))
            {
                folios = "''";
                //ds.Tables.Add("RemisionDetalles");
                //return ds;
            }

            ds.Tables.Add("RemisionDetalles");
            string sentenciaDetalles = "select * from remision_det where  num_remision in (" + folios + ")  "; //sucursal_id = :sucursalId AND

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                {
                    //cmd.Parameters.Add("sucursalId", sucursal.SucursalesID);
                    //cmd.Parameters.Add("sucursalesId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroRemision", "%" + remision.NumeroRemision + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    try
                    {
                        da.Fill(ds, "RemisionDetalles");
                    }
                    catch (Exception ex)
                    {
                        //DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);

                }

            }

            return ds;
        }
        public static DataSet RemisionesNoPagadas(SIFModelo.Sucursal sucursal, SIFModelo.Remision remision, DateTime fecha1, DateTime fecha2, String estado, string ClienteID, bool BPrecioFijo)
        {
            DataSet ds = new DataSet("DSRemisiones");
            ds.Tables.Add("Remisiones");
            string sentencia = "SELECT DISTINCT REMISION.*  FROM ";
            if (BPrecioFijo)
            {
                //sentencia += "  REMISION INNER JOIN REMISION_DET ON REMISION.SUCURSAL_ID = REMISION_DET.SUCURSAL_ID AND ";
                //sentencia += "  REMISION.NUM_REMISION = REMISION_DET.NUM_REMISION INNER JOIN CAT_ARTICULOS_SUB ON ";
                //sentencia += "  REMISION_DET.codigo_cli = CAT_ARTICULOS_SUB.codigocli AND REMISION.CLIENTE_ID=CAT_ARTICULOS_SUB.CLIENTE_ID";
                //sentencia += "  INNER JOIN PAGOS  ON REMISION.NUM_REMISION = PAGOS.REMISION_ID ";
                sentencia = " SELECT * FROM CS_ISSTEP_SUM_CLAVES";// CS_CONVENIO_CREDITO ";

                sentencia += " WHERE NUM_REMISION LIKE :NumeroRemision "; //sucursal_id = :SucursalId AND
                if (fecha1 > DateTime.Parse("01/01/2005"))
                    sentencia += " and FECHA >= TO_DATE('" + fecha1.ToString("yyyy-MM-dd 00:00:00") + "', 'YYYY-MM-DD HH24:MI:SS') AND FECHA <= TO_DATE('" + fecha2.ToString("yyyy-MM-dd 23:59:59") + "', 'YYYY-MM-DD HH24:MI:SS') ";

                //sentencia += " AND TO_CHAR(REMISION.FECHA_PAGO, 'YYYY/MM/DD') <> '0001/01/01' ";
                //sentencia += " AND REMISION.ACTIVO = 'P'";
                //sentencia += " AND CLIENTE_ID = " + ClienteID ;

            }
            else
            {
                sentencia += "   REMISION INNER JOIN REMISION_DET ON REMISION.SUCURSAL_ID = REMISION_DET.SUCURSAL_ID AND ";
                sentencia += "   REMISION.NUM_REMISION = REMISION_DET.NUM_REMISION INNER JOIN CAT_ARTICULOS ON REMISION_DET.ARTICULO_ID = CAT_ARTICULOS.ARTICULO_ID";
                sentencia += "  INNER JOIN PAGOS  ON REMISION.NUM_REMISION = PAGOS.REMISION_ID ";

                sentencia += " WHERE REMISION.NUM_REMISION LIKE :NumeroRemision "; //sucursal_id = :SucursalId AND
                if (fecha1 > DateTime.Parse("01/01/2005"))
                    sentencia += " AND PAGOS.FECHA >= TO_DATE('" + fecha1.ToString("yyyy-MM-dd 00:00:00") + "', 'YYYY-MM-DD HH24:MI:SS') AND PAGOS.FECHA <= TO_DATE('" + fecha2.ToString("yyyy-MM-dd 23:59:59") + "', 'YYYY-MM-DD HH24:MI:SS') ";

                //sentencia += " AND TO_CHAR(REMISION.FECHA_PAGO, 'YYYY/MM/DD') <> '0001/01/01' ";
                //sentencia += " AND FACTURA='N' AND NUM_FACTURA='N' ";
                sentencia += " AND REMISION.CLIENTE_ID=" + ClienteID + " AND REMISION.ACTIVO LIKE :estado";


                sentencia += " ORDER BY REMISION.FECHA_VTA DESC";


            }

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    // cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroRemision", "%" + remision.NumeroRemision + "%");
                    if (!BPrecioFijo)
                    {
                        cmd.Parameters.Add("estado", estado);
                    }

                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Remisiones");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            string folios = "";

            foreach (DataRow rwRemision in ds.Tables["Remisiones"].Rows)
            {
                folios += rwRemision["NUM_REMISION"].ToString() + "|"; //"'" + rwRemision["NUM_REMISION"].ToString() + "'" + "|";
            }

            folios = folios.Trim('|');

            if (string.IsNullOrEmpty(folios))
            {
                folios = "''";
                //ds.Tables.Add("RemisionDetalles");
                //return ds;
            }

            ds.Tables.Add("RemisionDetalles");
            //string sentenciaDetalles = "select * from remision_det where REGEXP_LIKE (num_remision, '^"+folios+"$', 'i') "; //sucursal_id = :sucursalId AND
            string sentenciaDetalles = "select * from remision_det where num_remision IN ('1')";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                {
                    //cmd.Parameters.Add("sucursalId", sucursal.SucursalesID);
                    //cmd.Parameters.Add("sucursalesId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroRemision", "%" + remision.NumeroRemision + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                    //da.Fill(ds, "RemisionDetalles");
                }

            }

            return ds;
        }


        public static SIFModelo.Remision RemisionPorId(string numeroRemision, int sucursal)
        {

            List<SIFModelo.Remision> rows = new List<SIFModelo.Remision>();

            string sentencia = "SELECT * FROM remision WHERE remision.sucursal_id = :SucursalID AND  NUM_REMISION = :NumeroRemision ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {

                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Parameters.Add("SucursalID", sucursal);
                        cmd.Parameters.Add("NumeroRemision", numeroRemision);
                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Remision registro = new SIFModelo.Remision();

                                registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                                registro.NumeroRemision = oreader["NUM_REMISION"].ToString();
                                registro.TipoClienteID = int.Parse(oreader["TIPO_CLIENTE_ID"].ToString());
                                registro.ClienteID = int.Parse(oreader["CLIENTE_ID"].ToString());
                                registro.FechaVenta = DateTime.Parse(oreader["FECHA_VTA"].ToString());
                                registro.Receta = (SIFModelo.Tipos.SiNo)(oreader["RECETA"].ToString()[0]);
                                registro.MedicoID = int.Parse(oreader["ID_MEDICO"].ToString());
                                var fecha_pago = oreader["FECHA_PAGO"].ToString();
                                if (fecha_pago != string.Empty)
                                {
                                    registro.FechaPago = DateTime.Parse(oreader["FECHA_PAGO"].ToString());
                                }
                                registro.VendedorID = int.Parse(oreader["VENDEDOR_ID"].ToString());
                                registro.MonedaID = int.Parse(oreader["MONEDA_ID"].ToString());
                                registro.TipoCambio = int.Parse(oreader["TIPO_CAMBIO_ID"].ToString());
                                registro.Condiciones = (oreader["CONDICIONES"].ToString());
                                registro.SubTotal = decimal.Parse(oreader["SUBTOTAL"].ToString());
                                registro.Impuesto = decimal.Parse(oreader["IMPUESTO_IVA"].ToString());
                                registro.Descuento = decimal.Parse(oreader["DESCUENTO"].ToString());
                                registro.Total = decimal.Parse(oreader["TOTAL"].ToString());
                                registro.TotalArticulosRemision = decimal.Parse(oreader["TOTAL_ARTICULOS_REM"].ToString());
                                registro.NumeroFactura = (oreader["NUM_FACTURA"].ToString());
                                registro.Activo = (SIFModelo.Tipos.StatusVenta)(oreader["ACTIVO"].ToString()[0]);
                                registro.ImporteLetra = oreader["IMPORTE_LETRA"].ToString();
                                registro.Factura = (SIFModelo.Tipos.SiNo)(oreader["FACTURA"].ToString()[0]);
                                registro.Comentarios = oreader["COMENTARIOS"].ToString();
                                registro.NumeroPedido = oreader["NUM_PEDIDO"].ToString();
                                registro.BeneficioProveedor = (SIFModelo.Tipos.SiNo)oreader["BENEFICIO_PROV"].ToString()[0];


                                return registro;
                            }
                        }

                    }
                }
                catch { }
                finally {

                    if (null != cnx)
                    {
                        cnx.Close();
                        cnx.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                }

            }
            return null;
        }

        public static bool InsertaDevolucionDetalle(SIFModelo.DevolucionDetalle modelo)
        {
            string sentencia = "SP_INS_DEVOLUCION_DET";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("devolucion_id", modelo.DevolucionID);
                    cmd.Parameters.Add("sucursal_id", modelo.SucursalID);
                    cmd.Parameters.Add("num_partida", modelo.NumeroPartida);
                    cmd.Parameters.Add("articulo_id ", modelo.ArticuloID);
                    cmd.Parameters.Add("nombre1", modelo.Nombre1);
                    cmd.Parameters.Add("nombre2", modelo.Nombre2);
                    cmd.Parameters.Add("cantidad", modelo.Cantidad);
                    cmd.Parameters.Add("precio", modelo.Precio);
                    cmd.Parameters.Add("descuento", modelo.Descuento);
                    cmd.Parameters.Add("iva", modelo.IVA);
                    cmd.Parameters.Add("pcosto", modelo.PrecioCosto);
                    cmd.Parameters.Add("tipo_dev_id", modelo.TipoDevolucionID);

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

        public static bool InsertaDevolucion(SIFModelo.Devolucion modelo, SIFModelo.Sucursal sucursal)
        {
            string sentencia = "SP_INS_DEVOLUCION";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("DEVOLUCION_ID", modelo.DevolucionID);
                    cmd.Parameters.Add("SUCURSAL_ID", modelo.SucursalID);
                    cmd.Parameters.Add("CLIENTE_ID", modelo.ClienteID);
                    cmd.Parameters.Add("FECHA_DEV", modelo.FechaDevolucion);
                    cmd.Parameters.Add("REF_VENTA", modelo.ReferenciaVenta);
                    cmd.Parameters.Add("COMENTARIO", modelo.Comentario);
                    cmd.Parameters.Add("TOTAL_DEV", modelo.TotalDevolucion);
                    cmd.Parameters.Add("ACTIVO", (char)modelo.Activo);
                    cmd.Parameters.Add("USUARIO_ID", modelo.UsuarioID);
                    cmd.Parameters.Add("AUTORIZA_ID", modelo.AutorizaID);

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

        public static SIFModelo.Devolucion DevolucionPorRemision(SIFModelo.Remision remision, SIFModelo.Sucursal sucursal)
        {
            List<SIFModelo.Remision> rows = new List<SIFModelo.Remision>();

            string sentencia = "SELECT * FROM devolucion WHERE REF_VENTA = :ReferenciaVenta AND SUCURSAL_ID = :Sucursal";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("Sucursal", sucursal.SucursalesID);
                    cmd.Parameters.Add("ReferenciaVenta", remision.NumeroRemision);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Devolucion registro = new SIFModelo.Devolucion();

                            registro.DevolucionID = oreader["DEVOLUCION_ID"].ToString();
                            registro.SucursalID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.ClienteID = int.Parse(oreader["CLIENTE_ID"].ToString());
                            registro.FechaDevolucion = DateTime.Parse(oreader["FECHA_DEV"].ToString());
                            registro.ReferenciaVenta = oreader["REF_VENTA"].ToString();
                            registro.Comentario = oreader["COMENTARIO"].ToString();
                            registro.TotalDevolucion = decimal.Parse(oreader["FECHA_PAGO"].ToString());
                            registro.Activo = (SIFModelo.Tipos.ActivoDevolucion)(oreader["VENDEDOR_ID"].ToString()[0]);
                            registro.UsuarioID = int.Parse(oreader["MONEDA_ID"].ToString());
                            registro.AutorizaID = int.Parse(oreader["TIPO_CAMBIO_ID"].ToString());

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


        public static SIFModelo.Cliente18 cliente18(SIFModelo.Remision remision)
        {

            string sentencia = "SELECT * FROM CLIENTE_ESPECIAL WHERE NUM_REMISION = :remision ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("remision", remision.NumeroRemision);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {

                            SIFModelo.Cliente18 registro = new SIFModelo.Cliente18();
                            registro.Num_remision = oreader["NUM_REMISION"].ToString();
                            registro.cliente_id = int.Parse(oreader["CLIENTE_ID"].ToString());
                            registro.nombre_asegurado = oreader["NOMBRE_ASEGURADO"].ToString();
                            registro.no_siniestro = oreader["NO_SINIESTRO"].ToString();
                            registro.no_autorizacion = oreader["NO_AUTORIZACION"].ToString();

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




        //        public static DataSet RemisionesNoFacturadas(SIFModelo.Sucursal sucursal, DateTime fecha1, DateTime fecha2)
        //        {
        //            string fehaInicio = fecha1.ToString("yyyy-MM-dd HH:mm:ss");
        //            string fehaTermino = fecha2.ToString("yyyy-MM-dd HH:mm:ss");

        //            DataSet ds = new DataSet("DSRemisiones");
        //            ds.Tables.Add("Remisiones");
        //            //string sentencia = "SELECT * FROM remision WHERE tipo_cliente_id<>5 and sucursal_id = :SucursalId AND  factura = 'N' AND activo = 'P' AND";
        //            //sentencia += " FECHA_VTA >= TO_DATE('" +fehaInicio+ "','YYYY-MM-DD HH24:MI:SS') AND ";
        //            //sentencia += " FECHA_VTA <= TO_DATE('" +fehaTermino+ "','YYYY-MM-DD HH24:MI:SS') ";

        //            string sentencia = "SELECT " +
        //                "REMISION.SUCURSAL_ID         , " +
        //" REMISION.NUM_REMISION        , " +
        //" REMISION.TIPO_CLIENTE_ID     , " +
        //" REMISION.CLIENTE_ID          , " +
        //" REMISION.FECHA_VTA           , " +
        //" REMISION.RECETA              , " +
        //" REMISION.ID_MEDICO           , " +
        //" REMISION.FECHA_PAGO          , " +
        //" REMISION.VENDEDOR_ID         , " +
        //" REMISION.MONEDA_ID           , " +
        //" REMISION.TIPO_CAMBIO_ID      , " +
        //" REMISION.CONDICIONES         , " +
        //" REMISION.SUBTOTAL            , " +
        //" REMISION.IMPUESTO_IVA        , " +
        //" REMISION.DESCUENTO           , " +
        //" REMISION.TOTAL               , " +
        //" REMISION.TOTAL_ARTICULOS_REM , " +
        //" REMISION.NUM_FACTURA         , " +
        //" REMISION.ACTIVO              , " +
        //" REMISION.IMPORTE_LETRA       , " +
        //" REMISION.FACTURA             , " +
        //" REMISION.COMENTARIOS         , " +
        //" REMISION.NUM_PEDIDO          , " +
        //" REMISION.BENEFICIO_PROV      , " +
        //" PAGOS.IMPORTE_TOTAL       " +


        //" FROM  PAGOS PAGOS " +
        //" JOIN REMISION REMISION " +
        //" ON PAGOS.REMISION_ID = REMISION.NUM_REMISION " +
        //" WHERE  (PAGOS.FECHA>=TO_DATE ('" + fehaInicio + "', 'YYYY-MM-DD HH24:MI:SS') AND PAGOS.FECHA<TO_DATE (' " + fehaTermino + "', 'YYYY-MM-DD HH24:MI:SS'))  AND PAGOS.ACTIVO='S' " +
        //"  AND REMISION.FACTURA = 'N' ";

        ////"            TIPO_CLIENTE.NOMBRE, REMISION.ACTIVO, REMISION.FECHA_VTA, REMISION.NUM_FACTURA, PAGOS.REMISION_ID, PAGOS_DET.IMPORTE, PAGOS.FECHA, PAGOS.CAJERO_ID, PAGOS.ACTIVO " +
        ////" FROM   ((PAGOS PAGOS INNER JOIN REMISION REMISION ON (PAGOS.SUCURSAL_ID=REMISION.SUCURSAL_ID) AND (PAGOS.REMISION_ID=REMISION.NUM_REMISION)) INNER JOIN PAGOS_DET PAGOS_DET ON PAGOS.REMISION_ID=PAGOS_DET.REMISION_ID) LEFT OUTER JOIN TIPO_CLIENTE TIPO_CLIENTE ON REMISION.TIPO_CLIENTE_ID=TIPO_CLIENTE.TIPO_CLIENTE_ID  "+
        ////" WHERE  PAGOS.CAJERO_ID<>'1' AND PAGOS.ACTIVO='S' AND REMISION.ACTIVO='P' AND REMISION.FACTURA='N' AND (PAGOS.FECHA>=TO_DATE ('" + fehaInicio + "', 'YYYY-MM-DD HH24:MI:SS') AND PAGOS.FECHA<TO_DATE ('" + fehaTermino + "', 'YYYY-MM-DD HH24:MI:SS'))  " +
        ////" ORDER BY TIPO_CLIENTE.NOMBRE";

        //            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
        //            {

        //                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
        //                {
        //                    cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
        //                    //
        //                    cmd.Connection.Open();
        //                    OracleDataAdapter da = new OracleDataAdapter(cmd);
        //                    da.Fill(ds, "Remisiones");
        //                }

        //            }

        //            string folioRemisiones = "";
        //            foreach(DataRow rwremision in ds.Tables["Remisiones"].Rows)
        //            {
        //                folioRemisiones += ",'" +rwremision["NUM_REMISION"].ToString() + "'";
        //            }

        //            folioRemisiones = "0";// folioRemisiones.Trim(',');

        //            ds.Tables.Add("RemisionDetalles");

        //            if (string.IsNullOrEmpty(folioRemisiones))
        //            {
        //                folioRemisiones = "''";
        //            }

        //            string sentenciaDetalles = "select * from remision_det where sucursal_id = :sucursalId AND num_remision in ("+folioRemisiones+")  ";

        //            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
        //            {

        //                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
        //                {
        //                    cmd.Parameters.Add("sucursalId", sucursal.SucursalesID);
        //                    //cmd.Parameters.Add("sucursalesId", sucursal.SucursalesID);
        //                    //
        //                    cmd.Connection.Open();
        //                    OracleDataAdapter da = new OracleDataAdapter(cmd);
        //                    try
        //                    {
        //                        da.Fill(ds, "RemisionDetalles");
        //                    }
        //                    catch
        //                    { }
        //                }

        //            }

        //            return ds;

        //        }


        public static DataSet RemisionesNoFacturadas(SIFModelo.Sucursal sucursal, DateTime fecha1, DateTime fecha2)
        {
            string fehaInicio = fecha1.ToString("dd/MM/yyyy");
            string fehaTermino = fecha2.ToString("dd/MM/yyyy");

            DataSet ds = new DataSet("DSRemisiones");
            ds.Tables.Add("Remisiones");
            //string sentencia = "SELECT * FROM remision WHERE tipo_cliente_id<>5 and sucursal_id = :SucursalId AND  factura = 'N' AND activo = 'P' AND";
            //sentencia += " FECHA_VTA >= TO_DATE('" +fehaInicio+ "','YYYY-MM-DD HH24:MI:SS') AND ";
            //sentencia += " FECHA_VTA <= TO_DATE('" +fehaTermino+ "','YYYY-MM-DD HH24:MI:SS') ";
            //sucursal.SucursalID
            string sentencia = "SELECT * FROM cs_notas_geNfact " +
                " WHERE sucursal_id = " + sucursal.SucursalID +//L 05/12/2013 se incluye la variable de sucursal ya que antes tenia por defecto un 3
                " AND TO_DATE(fecha, 'DD/MM/YYYY') BETWEEN TO_DATE('" + fehaInicio + "', 'DD/MM/YYYY') " +
                " AND TO_DATE('" + fehaTermino + "', 'DD/MM/YYYY') " +
                " AND ( ( factura = 'N' AND LENGTH(num_factura) <= 36 ) OR ( factura = 'S' AND LENGTH(num_factura) < 36 ) ) " +
                " AND REGEXP_LIKE( 'MOSTRADOR, TIEMPO AIRE, ENTREGA A DOMICILIO', tipo_cliente, 'i') ";


            //"            TIPO_CLIENTE.NOMBRE, REMISION.ACTIVO, REMISION.FECHA_VTA, REMISION.NUM_FACTURA, PAGOS.REMISION_ID, PAGOS_DET.IMPORTE, PAGOS.FECHA, PAGOS.CAJERO_ID, PAGOS.ACTIVO " +
            //" FROM   ((PAGOS PAGOS INNER JOIN REMISION REMISION ON (PAGOS.SUCURSAL_ID=REMISION.SUCURSAL_ID) AND (PAGOS.REMISION_ID=REMISION.NUM_REMISION)) INNER JOIN PAGOS_DET PAGOS_DET ON PAGOS.REMISION_ID=PAGOS_DET.REMISION_ID) LEFT OUTER JOIN TIPO_CLIENTE TIPO_CLIENTE ON REMISION.TIPO_CLIENTE_ID=TIPO_CLIENTE.TIPO_CLIENTE_ID  "+
            //" WHERE  PAGOS.CAJERO_ID<>'1' AND PAGOS.ACTIVO='S' AND REMISION.ACTIVO='P' AND REMISION.FACTURA='N' AND (PAGOS.FECHA>=TO_DATE ('" + fehaInicio + "', 'YYYY-MM-DD HH24:MI:SS') AND PAGOS.FECHA<TO_DATE ('" + fehaTermino + "', 'YYYY-MM-DD HH24:MI:SS'))  " +
            //" ORDER BY TIPO_CLIENTE.NOMBRE";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Remisiones");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            string folioRemisiones = "";
            foreach (DataRow rwremision in ds.Tables["Remisiones"].Rows)
            {
                folioRemisiones += ",'" + rwremision["NUM_REMISION"].ToString() + "'";
            }

            folioRemisiones = "0";// folioRemisiones.Trim(',');

            ds.Tables.Add("RemisionDetalles");

            if (string.IsNullOrEmpty(folioRemisiones))
            {
                folioRemisiones = "''";
            }

            string sentenciaDetalles = "select * from remision_det where sucursal_id = :sucursalId AND num_remision in (" + folioRemisiones + ")  ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                {
                    cmd.Parameters.Add("sucursalId", sucursal.SucursalesID);
                    //cmd.Parameters.Add("sucursalesId", sucursal.SucursalesID);
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    try
                    {
                        da.Fill(ds, "RemisionDetalles");
                    }
                    catch
                    { }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            return ds;

        }

        public static String[] RemisionesSiFacturadas(SIFModelo.Sucursal sucursal, DateTime fecha1, DateTime fecha2)//L 09/12/2013 para ver totales en pantalla
        {
            string fehaInicio = fecha1.ToString("dd/MM/yyyy");
            string fehaTermino = fecha2.ToString("dd/MM/yyyy");
            string[] res = new String[6];

            string sentencia = "SELECT " +
              "SUM(importe_total) total, " +
              "SUM(impuesto_iva) iva, " +
              "SUM(CASE WHEN LENGTH(num_factura) >= 36 THEN importe_total ELSE 0 END) total_fact, " +
              "SUM(CASE WHEN LENGTH(num_factura) >= 36 THEN impuesto_iva  ELSE 0 END) iva_fact, " +
              "SUM(CASE WHEN LENGTH(num_factura) <  36 THEN importe_total ELSE 0 END) total_sinfact, " +
              "SUM(CASE WHEN LENGTH(num_factura) <  36 THEN impuesto_iva  ELSE 0 END) iva_sinfact " +
            "FROM cs_notas_geNfact " +
                " WHERE sucursal_id = " + sucursal.SucursalID +//L 05/12/2013 se incluye la variable de sucursal ya que antes tenia por defecto un 3
                " AND TO_DATE(fecha, 'DD/MM/YYYY') BETWEEN TO_DATE('" + fehaInicio + "', 'DD/MM/YYYY') " +
                " AND TO_DATE('" + fehaTermino + "', 'DD/MM/YYYY') "/* +
                " AND REGEXP_LIKE( 'MOSTRADOR, TIEMPO AIRE, ENTREGA A DOMICILIO', tipo_cliente, 'i') "*/;

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            res[0] = oreader["total"].ToString();
                            res[1] = oreader["iva"].ToString();
                            res[2] = oreader["total_fact"].ToString();
                            res[3] = oreader["iva_fact"].ToString();
                            res[4] = oreader["total_sinfact"].ToString();
                            res[5] = oreader["iva_sinfact"].ToString();
                        }

                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }
            }
            return res;

        }


        public static bool ActualizaRemision(List<SIFModelo.Remision> remisionFacturar, string numFactura)
        {
            foreach (SIFModelo.Remision remision in remisionFacturar)
            {

                string sentencia = "UPDATE remision SET FACTURA = 'G', NUM_FACTURA = '" + numFactura + "' WHERE num_remision IN (:RemisionID) ";

                //string folioRemisiones = "";
                //foreach (SIFModelo.Remision rwremision in remisionFacturar)
                //{
                //    folioRemisiones += ",'" + rwremision.NumeroRemision.ToString() + "'";
                //}

                //folioRemisiones = folioRemisiones.Trim(',');

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //PARAMETROS
                        //cmd.Parameters.Add("NUM_FACTURA", numFactura);
                        cmd.Parameters.Add("RemisionID", remision.NumeroRemision);

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
            }
            return true;
        }

        public static bool ActualizaStatusPago(SIFModelo.Remision remision, SIFModelo.Pagos pago)
        {

            string sentencia = "UPDATE remision SET ACTIVO = 'P', FECHA_PAGO = TO_DATE('" + pago.Fecha.ToString("yyyy/MM/dd HH:mm:ss") + "','YYYY/MM/DD HH24:MI:SS') WHERE num_remision = :RemisionID ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //PARAMETROS
                    //cmd.Parameters.Add("NUM_FACTURA", numFactura);
                    cmd.Parameters.Add("RemisionID", remision.NumeroRemision);

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

        public static bool ActualizaUUIDRemision(SIFModelo.Remision remision)
        {
            string sentencia = "UPDATE REMISION SET NUM_FACTURA = '" + remision.NumeroFactura + "' WHERE NUM_REMISION = '" + remision.NumeroRemision + "'";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteScalar();
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

        public static bool ActualizaFechaPagoRemision(SIFModelo.Remision remision)
        {
            string sentencia = "UPDATE REMISION SET FECHA_PAGO = TO_DATE('" + remision.FechaPago.ToString("yyyy/MM/dd HH:mm:ss") + "','YYYY/MM/DD HH24:MI:SS') WHERE NUM_REMISION = '" + remision.NumeroRemision + "'";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteScalar();
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


        public static SIFModelo.Remision FacturaDeRemision(SIFModelo.Remision remision)
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            SIFModelo.Catalogo.CatalogoDataSet.CTL_TAEDataTable ta = new SIFModelo.Catalogo.CatalogoDataSet().CTL_TAE;
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_VENTAS.sp_factura_remision";
                cmd.BindByName = true;

                // OUT REF CURSOR bound

                cmd.Parameters.Add("NoRemision", OracleDbType.Varchar2, remision.NumeroRemision, ParameterDirection.Input);
                OracleParameter ptotal = cmd.Parameters.Add("Tot", OracleDbType.RefCursor, ParameterDirection.Output);
                OracleParameter pdetalle = cmd.Parameters.Add("Det", OracleDbType.RefCursor, ParameterDirection.Output);

                cmd.ExecuteNonQuery();
                OracleDataReader totReader = ((OracleRefCursor)ptotal.Value).GetDataReader();
                OracleDataReader detReader = ((OracleRefCursor)pdetalle.Value).GetDataReader();

                if (totReader.HasRows)
                {
                    while (totReader.Read())
                    {
                        remision.SubTotal = System.Convert.ToDecimal(totReader["subtotal"]);
                        remision.Impuesto = System.Convert.ToDecimal(totReader["iva"]);
                        //remision.SubTotalDescuento = System.Convert.ToDecimal(detReader["subtotal_descto"]);
                        remision.Descuento = System.Convert.ToDecimal(totReader["descuento"]);
                        remision.Total = System.Convert.ToDecimal(totReader["total_factura"]);
                    }
                    //SIFUtils.AutoNumberRowsForGridView(GridConciliaTae);
                }
                else
                {
                    return null;
                }

                remision.Detalles = new List<SIFModelo.RemisionDetalle>();
                if (detReader.HasRows)
                {
                    while (detReader.Read())
                    {
                        SIFModelo.RemisionDetalle detalle = new SIFModelo.RemisionDetalle();

                        detalle.NumeroPartida = System.Convert.ToInt32(detReader["partida"]);
                        detalle.ArticuloID = System.Convert.ToString(detReader["articulo"]);
                        detalle.Nombre1 = System.Convert.ToString(detReader["nombre1"]);
                        detalle.CantidadRemision = System.Convert.ToInt32(detReader["cantidad"]);
                        detalle.Precio = System.Convert.ToDecimal(detReader["precio"]);
                        detalle.Total = System.Convert.ToDecimal(detReader["subtotal"]);
                        detalle.NumeroRemision = remision.NumeroRemision;
                        detalle.Unidad = "Pieza";

                        remision.Detalles.Add(detalle);
                    }
                    //SIFUtils.AutoNumberRowsForGridView(GridConciliaTae);
                }
                else
                {
                    return null;
                }

                detReader.Close();
                detReader.Dispose();
            }
            catch (Exception ex)
            {
                return null;
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


            int num_remision = numRemisionFacturada(remision);

            if (num_remision > 0)
            {
                remision.NumeroRemision += "-" + num_remision.ToString();
            }

            return remision;
        }


        private static int numRemisionFacturada(SIFModelo.Remision rem)
        {
            string sentencia = "SELECT COUNT(*)  FROM CTL_FACTURAS " +
" WHERE NUM_REMISION = '" + rem.NumeroRemision + "'" +
" GROUP BY NUM_REMISION ";

            int num = 0;
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    try
                    {
                        cmd.Connection.Open();
                        object res = cmd.ExecuteScalar();

                        if (res == null)
                        {
                            return 0;
                        }
                        if (res.ToString().IsIntegerPositive())
                        {
                            num = System.Convert.ToInt32(res);
                        }
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

                }
            }

            return num;
        }


        public static bool ActualizaRemisionEsFactura(SIFModelo.Remision remision)
        {
            string sentencia = "UPDATE REMISION SET FACTURA = '" + System.Convert.ToChar(remision.Factura) + "' WHERE NUM_REMISION = '" + remision.NumeroRemision + "'";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteScalar();
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

        public static bool ActualizaRemisionEsFacturaCliente(SIFModelo.Remision remision)
        {
            string sentencia = "UPDATE REMISION SET FACTURA = '" + System.Convert.ToChar(remision.Factura) + "' , CLIENTE_ID = " + remision.ClienteID + " WHERE NUM_REMISION = '" + remision.NumeroRemision + "'";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteScalar();
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

        public static bool ActualizaRemisionStatus(SIFModelo.Remision remision)
        {
            string sentencia = "UPDATE REMISION SET ACTIVO = '" + System.Convert.ToChar(remision.Activo) + "' WHERE NUM_REMISION = '" + remision.NumeroRemision + "'";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteScalar();
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



        public static string getpdf(string u)
        {
            string path = @"C:\FEL\Facturas\" + u + ".pdf";
            string respuesta = string.Empty;
            try
            {
                string sentencia = "PKG_FEL.SP_OBTENERPDF";
                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.BindByName = true;
                        cmd.Parameters.Add("V_UUID", u);

                        OracleParameter outparams = new OracleParameter("V_RESPUESTA", OracleDbType.Varchar2);
                        outparams.Direction = System.Data.ParameterDirection.Output;
                        cmd.Parameters.Add(outparams).Size = 1000;

                        OracleParameter outparams_uuid = new OracleParameter("V_PDF", OracleDbType.Blob);
                        outparams_uuid.Direction = System.Data.ParameterDirection.Output;
                        cmd.Parameters.Add(outparams_uuid);
                        object returnValue;
                        object id = 0;

                        /*  try
                              {
                              cmd.Connection.Open();
                              returnValue = cmd.ExecuteScalar();
                              //dP.respuesta = outparams.Value.ToString();
                              //dP.uuid = outparams_uuid.Value.ToString();
                              }
                          catch (Exception ex)
                              {

                              //dP.respuesta = ex.ToString() + "No se pudo reportar la venta con Assist\nInformar al departamento de Sistemas";
                              throw ex;
                            
                              }*/

                        try
                        {
                            cmd.Connection.Close();
                            cmd.Connection.Open();
                            returnValue = cmd.ExecuteScalar();

                            /*byte[] MyData = new byte[0];
                              MyData = (byte[])outparams_uuid.Value;
                              System.IO.MemoryStream stream = new System.IO.MemoryStream(MyData);
                              */
                            object obj = outparams_uuid.Value;
                            byte[] buffer = (byte[])obj.GetType().GetProperty("Value").GetValue(obj, null);//.GetType().GetProperty("V_PDF").GetValue(null);
                            //respuesta = outparams_uuid.Value.ToString();
                            respuesta = outparams.Value.ToString();
                            using (System.IO.FileStream fs = new System.IO.FileStream
                            (path, System.IO.FileMode.Create))
                            {
                                fs.Write(buffer, 0, buffer.Length);
                                //fs.Write(MyData, 0, MyData.Length);
                            }
                        }
                        catch (Exception Exx)
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

                //   return dP;
            }
            catch (Exception E)
            {
                //dP.respuesta = E.ToString();
            }


            return respuesta;


        }

    }
}
