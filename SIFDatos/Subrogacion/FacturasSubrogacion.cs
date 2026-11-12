using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data;
using DevComponents.DotNetBar;
using Oracle.DataAccess.Types;

namespace SIFDatos.Subrogacion
{
    public class Facturas
    {
        public static SIFModelo.SubRogacion.Sobrogacion Get(SIFModelo.SubRogacion.Sobrogacion ds, int ClienteID)
        {
            String sentencia = "SELECT * FROM FACTURA where CLIENTE_ID=" + ClienteID.ToString() + ""; //

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "FACTURA");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }
            return ds;

        }


        public static bool ActualizaRemisiones(String Remisiones, String NoFolio, String UccID)
        {
            #region
            // ROMA REVISAR YA QUE SE ACTUALIZAN LAS REMISIONES CON EL ULTIMO ID DE FACTURA  02SEP2013
            #endregion
            using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                string remisionesRemision = Remisiones.Replace("REMISION_DET.", "REMISION.");
                String Commando = "update remision set FACTURA='S',NUM_FACTURA='" + UccID + "' WHERE NUM_REMISION in (''" + remisionesRemision.Replace("''", "'") + ")";
                cmd.CommandText = Commando;
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                cmd.Connection.Dispose();
               //OracleConnection.ClearPool(conn);
                return true;
            }
            return false;
        }


        public static bool ActualizaDatosFijos(String Separa, String Concepto, String Clave, String TipoPagoID, String NumCta, String cincoMillar, String LoteSerie, String Detalle, String ClienteID)
        {

            using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_SUBROGACION.sp_ins_camposfact";
                cmd.BindByName = true;

                cmd.Parameters.Add("SEPARAR", OracleDbType.Varchar2, Separa, ParameterDirection.Input);
                cmd.Parameters.Add("CONCEPTO", OracleDbType.Varchar2, Concepto, ParameterDirection.Input);
                cmd.Parameters.Add("CLAVE", OracleDbType.Varchar2, Clave, ParameterDirection.Input);
                cmd.Parameters.Add("RESUMEN", OracleDbType.Varchar2, Detalle, ParameterDirection.Input);
                cmd.Parameters.Add("CINCOMILLAR", OracleDbType.Varchar2, cincoMillar, ParameterDirection.Input);
                cmd.Parameters.Add("LOTESERIE", OracleDbType.Varchar2, LoteSerie, ParameterDirection.Input);
                cmd.Parameters.Add("TipoPagoID", OracleDbType.Decimal, TipoPagoID, ParameterDirection.Input);
                cmd.Parameters.Add("NumCta", OracleDbType.Varchar2, NumCta, ParameterDirection.Input);
                cmd.Parameters.Add("CLIENTEID", OracleDbType.Decimal, ClienteID, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                cmd.Connection.Dispose();
               //OracleConnection.ClearPool(conn);
                return true;

            }
            return false;
        }

        public static bool Insert(SIFModelo.SubRogacion.Sobrogacion ds)
        {
            int ClienteID = 0;

            foreach (SIFModelo.SubRogacion.Sobrogacion.FACTURARow Factura in ds.FACTURA)
            {
                ClienteID = Factura.CLIENTE_ID;
                DataRow[] Detalle = ds.FACTURA_DETALLE.Select("NUM_FACTURA='" + Factura.NUM_FACTURA + "'");

                String[] Clave = new String[Detalle.Length];
                String[] Descripcion = new String[Detalle.Length];
                String[] Unidad = new String[Detalle.Length];
                double[] PrecioUni = new double[Detalle.Length];
                int[] Cantidad = new int[Detalle.Length];
                double[] Descuento = new double[Detalle.Length];
                double[] Total = new double[Detalle.Length];
                int[] Ren = new int[Detalle.Length];

                int ind = 0;
                int TotalArt = 0;

                foreach (DataRow Reg in Detalle)
                {
                    //llenamos el store procedure
                    Clave[ind] = Reg["Clave"].ToString();
                    Descripcion[ind] = Reg["Descripcion"].ToString();
                    Unidad[ind] = Reg["Unidad"].ToString();
                    PrecioUni[ind] = double.Parse(Reg["Precio_unitario"].ToString());
                    Cantidad[ind] = int.Parse(Reg["Cantidad"].ToString());
                    Descuento[ind] = double.Parse(Reg["Descuento"].ToString());
                    Total[ind] = double.Parse(Reg["Total"].ToString());
                    Ren[ind] = ind;
                    TotalArt = Cantidad[ind] + TotalArt;
                    ind++;

                }
                using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    conn.Open();

                    // Create an OracleCommand
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_SUBROGACION.sp_ins_Factura";
                    cmd.BindByName = true;

                    cmd.Parameters.Add("CltId", OracleDbType.Int32, ClienteID, ParameterDirection.Input);
                    cmd.Parameters.Add("REFER", OracleDbType.Varchar2, Factura.REFERENCIA == null ? "" : Factura.REFERENCIA, ParameterDirection.Input);
                    cmd.Parameters.Add("IMPORTE_LET", OracleDbType.Varchar2, Factura.IMPORTE_LETRA, ParameterDirection.Input);
                    cmd.Parameters.Add("SUBTOTAL", OracleDbType.Decimal, Factura.SUBTOTAL, ParameterDirection.Input);
                    cmd.Parameters.Add("IMPUESTO_IVA", OracleDbType.Decimal, Factura.IMPUESTO_IVA, ParameterDirection.Input);
                    cmd.Parameters.Add("DESCT", OracleDbType.Decimal, Factura.DESCUENTO, ParameterDirection.Input);
                    cmd.Parameters.Add("TOT", OracleDbType.Decimal, Factura.TOTAL, ParameterDirection.Input);
                    cmd.Parameters.Add("TOTART", OracleDbType.Decimal, Factura.TOTAL_ARTICULOS, ParameterDirection.Input);
                    cmd.Parameters.Add("TIPOPAG", OracleDbType.Decimal, Factura.TIPO_PAGO_ID, ParameterDirection.Input);
                    cmd.Parameters.Add("SALDO", OracleDbType.Decimal, 0, ParameterDirection.Input);
                    cmd.Parameters.Add("ACTIVO", OracleDbType.Varchar2, 'S', ParameterDirection.Input);
                    cmd.Parameters.Add("NUMCTA", OracleDbType.Varchar2, Factura.NUM_CUENTA, ParameterDirection.Input);



                    // Input Array Lote
                    OracleParameter InArtID = cmd.Parameters.Add("CLAVE", OracleDbType.Varchar2);
                    InArtID.Direction = ParameterDirection.Input;
                    InArtID.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    InArtID.Value = Clave;

                    // Input Array Sec
                    OracleParameter InDescrip = cmd.Parameters.Add("DESCRIP", OracleDbType.Varchar2);
                    InDescrip.Direction = ParameterDirection.Input;
                    InDescrip.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    InDescrip.Value = Descripcion;

                    // IN Array ID's
                    OracleParameter InUnidad = cmd.Parameters.Add("UMedida", OracleDbType.Varchar2);
                    InUnidad.Direction = ParameterDirection.Input;
                    InUnidad.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    InUnidad.Value = Unidad;

                    // IN Array Articulos
                    OracleParameter IntPrecio = cmd.Parameters.Add("PRECIO", OracleDbType.Decimal);
                    IntPrecio.Direction = ParameterDirection.Input;
                    IntPrecio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    IntPrecio.Value = PrecioUni;

                    // IN Array Concepto
                    OracleParameter InCant = cmd.Parameters.Add("Cant", OracleDbType.Decimal);
                    InCant.Direction = ParameterDirection.Input;
                    InCant.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    InCant.Value = Cantidad;

                    // IN Array Cantidad
                    OracleParameter InDesc = cmd.Parameters.Add("eDesc", OracleDbType.Double);
                    InDesc.Direction = ParameterDirection.Input;
                    InDesc.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    InDesc.Value = Descuento;

                    // IN Array Precio
                    OracleParameter InTotal = cmd.Parameters.Add("eTotal", OracleDbType.Double);
                    InTotal.Direction = ParameterDirection.Input;
                    InTotal.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    InTotal.Value = Total;

                    OracleParameter InRenglon = cmd.Parameters.Add("Renglon", OracleDbType.Int32);
                    InRenglon.Direction = ParameterDirection.Input;
                    InRenglon.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    InRenglon.Value = Ren;


                    OracleParameter pPedido =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                    // Execute the command
                    cmd.ExecuteNonQuery();

                    if (!string.IsNullOrEmpty(pPedido.Value.ToString()))
                    {
                        DataRow[] Renglones = ds.FACTURA_DETALLE.Select("NUM_FACTURA= '" + Factura.NUM_FACTURA + "'");

                        Factura.REFERENCIA = pPedido.Value.ToString();
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(conn);
                }

            }
            return false;
        }
        public static SIFModelo.SubRogacion.Sobrogacion.CAMPOSCLIENTEFACTRow GetCampos(String ClienteID)
        {
            SIFModelo.SubRogacion.Sobrogacion.CAMPOSCLIENTEFACTDataTable Tabla = new SIFModelo.SubRogacion.Sobrogacion.CAMPOSCLIENTEFACTDataTable();
            SIFModelo.SubRogacion.Sobrogacion.CAMPOSCLIENTEFACTRow registro = null;
            String Sentencia = " Select * from camposclientefact where cliente_ID=" + ClienteID;
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(Sentencia, cnx))
                {
                    cmd.Connection.Open();
                    OracleDataReader _rdrObj = cmd.ExecuteReader();

                    while (_rdrObj.Read())
                    {
                        registro = Tabla.NewCAMPOSCLIENTEFACTRow();
                        registro.CINCOMILLAR = _rdrObj.GetString(_rdrObj.GetOrdinal("CINCOMILLAR"));
                        if (!_rdrObj.IsDBNull(_rdrObj.GetOrdinal("CLAVE")))
                            registro.CLAVE = _rdrObj.GetString(_rdrObj.GetOrdinal("CLAVE"));
                        if (!_rdrObj.IsDBNull(_rdrObj.GetOrdinal("CONCEPTO")))
                            registro.CONCEPTO = _rdrObj.GetString(_rdrObj.GetOrdinal("CONCEPTO"));
                        registro.LOTESERIE = _rdrObj.GetString(_rdrObj.GetOrdinal("LOTESERIE"));
                        registro.RESUMEN = _rdrObj.GetString(_rdrObj.GetOrdinal("RESUMEN"));
                        if (_rdrObj.GetOrdinal("SEPARAR") != 0)
                            registro.SEPARAR = _rdrObj.GetString(_rdrObj.GetOrdinal("SEPARAR"));
                        else
                            registro.SEPARAR = "";
                        registro.CLIENTE_ID = _rdrObj.GetString(_rdrObj.GetOrdinal("CLIENTE_ID"));


                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);


                }
            }
            return registro;

        }

        public static SIFModelo.SubRogacion.Sobrogacion Get(SIFModelo.SubRogacion.Sobrogacion ds, String Separa, String Concepto, String Clave, String LisRemisiones, bool Lote)
        {
            String CamposSep = CamposSepara(Separa);
            String sentencia = " SELECT  ";
            sentencia += (Separa == "" ? "'" + Configuracion.FechaServidor().ToString("ddMMyyyy") + "'" : CamposSep) + " AS NUM_FACTURA,";
            sentencia += " REMISION.CLIENTE_ID,";
            sentencia += " TO_DATE('" + Configuracion.FechaServidor().ToString("dd/MM/yyyy") + "', 'DD/MM/YYYY') AS FECHA,'' AS REFERENCIA,'' AS IMPORTE_LETRA,";
            sentencia += " SUM(REMISION_DET.CANT_REMISION * REMISION_DET.PRECIO - REMISION_DET.IVA) AS SUBTOTAL,";
            sentencia += " SUM(REMISION_DET.IVA) AS IMPUESTO_IVA, MAX(REMISION.DESCUENTO) AS DESCUENTO,";
            sentencia += " SUM(REMISION.TOTAL) AS TOTAL,";//VMJA MAX
            sentencia += " SUM(REMISION_DET.CANT_REMISION) AS TOTAL_ARTICULOS, ";
            sentencia += " CAT_CLIENTE_CONVENIO.TIPO_PAGO AS TIPO_PAGO_ID,0 as SALDO,'S' AS ACTIVO, CAT_CLIENTE_CONVENIO.NUM_CUENTA ";
            sentencia += " FROM REMISION_DET INNER JOIN REMISION ON REMISION_DET.NUM_REMISION = REMISION.NUM_REMISION INNER JOIN ";
            sentencia += " CAT_CLIENTE_CONVENIO ON REMISION.CLIENTE_ID = CAT_CLIENTE_CONVENIO.CLIENTE_CONVENIO_ID INNER JOIN ";
            sentencia += " CAT_ARTICULOS ON REMISION_DET.ARTICULO_ID = CAT_ARTICULOS.ARTICULO_ID";
            sentencia += " WHERE (REMISION_DET.NUM_REMISION IN (" + LisRemisiones + "))  AND REMISION.ACTIVO = 'P' ";
            sentencia += " AND REMISION.ACTIVO = 'P' ";
            sentencia += " GROUP BY REMISION.CLIENTE_ID, CAT_CLIENTE_CONVENIO.TIPO_PAGO, CAT_CLIENTE_CONVENIO.NUM_CUENTA" + (Separa == "" ? "" : "," + CamposSep + "");
            //Clipboard.SetText(sentencia);

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    ds.EnforceConstraints = false;
                    ds.FACTURA.Constraints.Clear();
                    da.Fill(ds, "FACTURA");
                    if (!ds.FACTURA.Columns.Contains("LISTAREMISION"))
                        ds.FACTURA.Columns.Add("LISTAREMISION", Type.GetType("System.String"));
                    foreach (DataRow dr in ds.FACTURA.Rows)
                    {
                        dr["LISTAREMISION"] = LisRemisiones;
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);

                }

                String Claves = CamposSepara(Clave);
                String Conceptos = CamposSepara(Concepto);
                if (Claves == "") Claves = "REMISION_DET.ARTICULO_ID";
                if (Conceptos == "") Conceptos = "REMISION_DET.NOMBRE1 ";
                /*ORIGINAL
                sentencia = "SELECT  " + Claves + " AS CLAVE, " + Conceptos + (Lote ? " || ' LOTE: ' || REMISION_DET.LOTE || ' CAD: ' || REMISION_DET.CADUCIDAD" : "") + " AS DESCRIPCION,";
                sentencia += " CAT_ARTICULOS.U_VENTA AS UNIDAD,";
                sentencia += "  SUM(REMISION_DET.PRECIO) AS PRECIO_UNITARIO,";
                sentencia += "  SUM(REMISION_DET.CANT_REMISION) AS CANTIDAD, 0 AS DESCUENTO, ";
                sentencia += "  SUM(REMISION_DET.CANT_REMISION * REMISION_DET.PRECIO) AS TOTAL,";
                sentencia += (Separa == "" ? "'" + Configuracion.FechaServidor().ToString("ddMMyyyy") + "'" : CamposSep) + " AS NUM_FACTURA, ";
                sentencia += " 0 AS RENGLON, REMISION_DET.IMPUESTO_ID, SUM(REMISION_DET.IVA) AS IMPUESTO ";
                sentencia += " FROM    REMISION_DET INNER JOIN CAT_ARTICULOS ON REMISION_DET.ARTICULO_ID = CAT_ARTICULOS.ARTICULO_ID ";
                sentencia += " WHERE REMISION_DET.NUM_REMISION IN (" + LisRemisiones + ") ";
                sentencia += " GROUP BY ' ', ' ', CAT_ARTICULOS.U_VENTA, REMISION_DET.IMPUESTO_ID" + (Separa == "" ? "" : "," + CamposSep + "");
                sentencia += (Claves == "" ? "" : "," + Claves + "");
                sentencia += (Conceptos == "" ? "" : "," + Conceptos + (Lote ? " || ' LOTE: ' || REMISION_DET.LOTE || ' CAD: ' || REMISION_DET.CADUCIDAD" : "") + "");
                */
                /*MODIFICADO 17/03/2014*/
                sentencia = "SELECT  " + "CAT_ARTICULOS.ARTICULO_ID" + " AS CLAVE, " + Conceptos + (Lote ? " || ' LOTE: ' || REMISION_DET.LOTE || ' CAD: ' || REMISION_DET.CADUCIDAD" : "") + " AS DESCRIPCION,";
                sentencia += " CAT_ARTICULOS.U_VENTA AS UNIDAD,";
                sentencia += "  SUM(REMISION_DET.PRECIO) AS PRECIO_UNITARIO,";
                sentencia += "  SUM(REMISION_DET.CANT_REMISION) AS CANTIDAD, 0 AS DESCUENTO, ";
                sentencia += "  SUM(REMISION_DET.CANT_REMISION * REMISION_DET.PRECIO) AS TOTAL,";
                sentencia += (Separa == "" ? "'" + Configuracion.FechaServidor().ToString("ddMMyyyy") + "'" : CamposSep) + " AS NUM_FACTURA, ";
                sentencia += " 0 AS RENGLON, REMISION_DET.IMPUESTO_ID, SUM(REMISION_DET.IVA) AS IMPUESTO ";
                sentencia += " FROM    REMISION_DET INNER JOIN CAT_ARTICULOS ON REMISION_DET.ARTICULO_ID = CAT_ARTICULOS.ARTICULO_ID ";
                sentencia += " WHERE REMISION_DET.NUM_REMISION IN (" + LisRemisiones + ") ";
                sentencia += " GROUP BY ' ', ' ', CAT_ARTICULOS.U_VENTA, REMISION_DET.IMPUESTO_ID" + (Separa == "" ? "" : "," + CamposSep + "") + ", CAT_ARTICULOS.ARTICULO_ID," + Conceptos + "";
                //sentencia += (Claves == "" ? "" : "," + Claves + "");
                //sentencia += (Conceptos == "" ? "" : "," + Conceptos + (Lote ? " || ' LOTE: ' || REMISION_DET.LOTE || ' CAD: ' || REMISION_DET.CADUCIDAD" : "") + "");
                //Clipboard.SetText(sentencia);
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    OracleDataAdapter da = new OracleDataAdapter(cmd);

                    da.Fill(ds, "FACTURA_DETALLE");
                }

                cnx.Close();
                cnx.Dispose();
               //OracleConnection.ClearPool(cnx);
            }

            return ds;

        }

        public static SIFModelo.SubRogacion.Sobrogacion GetPF(SIFModelo.SubRogacion.Sobrogacion ds, String Separa, String Concepto, String Clave, String LisRemisiones)
        {
            String CamposSep = CamposSepara(Separa);
            String sentencia = " SELECT  ";
            sentencia += (Separa == "" ? "'" + Configuracion.FechaServidor().ToString("ddMMyyyy") + "'" : CamposSep) + " AS NUM_FACTURA, ";
            sentencia += " CAT_ARTICULOS_SUB.CLIENTE_ID, ";
            sentencia += " TO_DATE('" + Configuracion.FechaServidor().ToString("dd/MM/yyyy") + "', 'DD/MM/YYYY') AS FECHA,'' AS REFERENCIA,'' AS IMPORTE_LETRA,";
            sentencia += " SUM(REMISION_DET.CANT_REMISION * REMISION_DET.PRECIO - REMISION_DET.IVA) AS SUBTOTAL, ";
            sentencia += " SUM(REMISION_DET.IVA) AS IMPUESTO_IVA, 0 AS DESCUENTO,";
            //sentencia += " SUM(REMISION_DET.CANT_REMISION * CAT_ARTICULOS_SUB.PRECIO)  AS TOTAL,";
            sentencia += " SUM(REMISION_DET.CANT_REMISION * REMISION_DET.PRECIO)  AS TOTAL,";
            sentencia += " SUM(REMISION_DET.CANT_REMISION) AS TOTAL_ARTICULOS, ";
            sentencia += " CAT_CLIENTE_CONVENIO.TIPO_PAGO AS TIPO_PAGO_ID,0 as SALDO,'S' AS ACTIVO, CAT_CLIENTE_CONVENIO.NUM_CUENTA  FROM  CAT_ARTICULOS_SUB INNER JOIN ";
            sentencia += " REMISION_DET ON CAT_ARTICULOS_SUB.CODIGOCLI = REMISION_DET.CODIGO_CLI INNER JOIN CAT_ARTICULOS ON CAT_ARTICULOS_SUB.ARTICULO_ID = CAT_ARTICULOS.ARTICULO_ID INNER JOIN";
            sentencia += " CAT_CLIENTE_CONVENIO ON CAT_ARTICULOS_SUB.CLIENTE_ID = CAT_CLIENTE_CONVENIO.CLIENTE_CONVENIO_ID ";
            sentencia += " INNER JOIN REMISION_VALE ON REMISION_VALE.NUM_REMISION = REMISION_DET.NUM_REMISION ";
            sentencia += " INNER JOIN REMISION ON REMISION_DET.NUM_REMISION = REMISION.NUM_REMISION ";
            sentencia += " WHERE CAT_ARTICULOS_SUB.ACTIVO = 'S' AND REMISION_DET.NUM_REMISION IN (" + LisRemisiones + ") AND REMISION.ACTIVO = 'P'";
            sentencia += " GROUP BY CAT_ARTICULOS_SUB.CLIENTE_ID, CAT_CLIENTE_CONVENIO.TIPO_PAGO, CAT_CLIENTE_CONVENIO.NUM_CUENTA" + (Separa == "" ? "" : "," + CamposSep + "");
            // sentencia += " ORDER BY REMISION_VALE.FECHA_VALE ";
            Clipboard.SetText(sentencia);
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    ds.FACTURA.Constraints.Clear();
                    da.Fill(ds, "FACTURA");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);

                }

                if (!ds.FACTURA.Columns.Contains("FACTURAR"))
                {
                    ds.FACTURA.Columns.Add("FACTURAR", Type.GetType("System.Boolean"));
                }

                foreach (DataRow dr in ds.FACTURA.Rows)
                {
                    dr["FACTURAR"] = true;
                }

                String Claves = CamposSepara(Clave);
                String Conceptos = CamposSepara(Concepto);
                if (Claves == "") Claves = "REMISION_DET.ARTICULO_ID";
                if (Conceptos == "") Conceptos = "REMISION_DET.NOMBRE1";
                sentencia = "SELECT  " + Claves + " AS CLAVE, " + Conceptos + " AS DESCRIPCION,";
                sentencia += " CAT_ARTICULOS.U_VENTA AS UNIDAD, (REMISION_DET.PRECIO - (REMISION_DET.IVA / REMISION_DET.CANT_REMISION))  AS PRECIO_UNITARIO, SUM (REMISION_DET.CANT_REMISION) AS CANTIDAD, 0 AS DESCUENTO, ";
                sentencia += "SUM( (REMISION_DET.CANT_REMISION * REMISION_DET.PRECIO) - REMISION_DET.IVA ) AS TOTAL,";
                sentencia += (Separa == "" ? "'" + Configuracion.FechaServidor().ToString("ddMMyyyy") + "'" : CamposSep) + " AS NUM_FACTURA, 0 AS RENGLON,REMISION_DET.IMPUESTO_ID, REMISION_DET.IVA AS IMPUESTO ";
                sentencia += " FROM  CAT_ARTICULOS_SUB INNER JOIN REMISION_DET ON CAT_ARTICULOS_SUB.CODIGOCLI = REMISION_DET.CODIGO_CLI INNER JOIN ";
                sentencia += " CAT_ARTICULOS ON CAT_ARTICULOS_SUB.ARTICULO_ID = CAT_ARTICULOS.ARTICULO_ID";
                sentencia += " INNER JOIN REMISION_VALE ON REMISION_VALE.NUM_REMISION = REMISION_DET.NUM_REMISION ";
                sentencia += " WHERE CAT_ARTICULOS_SUB.ACTIVO = 'S' AND REMISION_DET.NUM_REMISION IN (" + LisRemisiones + ") ";
                sentencia += " GROUP BY " + Claves + ", " + Conceptos + ", CAT_ARTICULOS.U_VENTA, REMISION_DET.PRECIO,";
                sentencia += " REMISION_DET.IMPUESTO_ID, REMISION_DET.IVA,CAT_ARTICULOS_SUB.ANEXO " + (Separa == "" ? "" : "," + CamposSep + "");
                sentencia += " ,CAT_ARTICULOS_SUB.CODIGOCLI,  (REMISION_DET.PRECIO - (REMISION_DET.IVA / REMISION_DET.CANT_REMISION)), TO_NUMBER(CAT_ARTICULOS_SUB.CODIGOCLI) ";
                sentencia += " ORDER BY TO_NUMBER(CAT_ARTICULOS_SUB.CODIGOCLI) ";

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    ds.EnforceConstraints = false;
                    ds.FACTURA_DETALLE.Constraints.Clear();
                    da.Fill(ds, "FACTURA_DETALLE");
                }

                cnx.Close();
                cnx.Dispose();
               //OracleConnection.ClearPool(cnx);
            }
            return ds;

        }

        public static SIFModelo.SubRogacion.Sobrogacion GetPF_isstep(SIFModelo.SubRogacion.Sobrogacion ds, String Separa, String Concepto, String Clave, String LisRemisiones, SIFModelo.ClienteSubrogaccion cliente, DateTime FECHAINI, DateTime FECHAFIN)
        {
            String CamposSep = CamposSepara(Separa);
            String sentencia = "";
            sentencia += " SELECT ";
            sentencia += "  anexo || ' ' ||  tipo_vale AS NUM_FACTURA,  ";
            sentencia += " " + cliente.ID + "  AS CLIENTE_ID, ";
            sentencia += " TO_DATE ('" + Configuracion.FechaServidor().ToString("dd/MM/yyyy") + "', 'DD/MM/YYYY') AS FECHA, ";
            sentencia += " '' AS REFERENCIA, ";
            sentencia += " '' AS IMPORTE_LETRA, ";
            sentencia += " SUM(subtotal) as subtotal, ";
            sentencia += " SUM(iva) as impuesto_iva, ";
            sentencia += " 0 as descuento, ";
            sentencia += " SUM(total) as total, ";
            sentencia += " SUM(cantidad) as total_articulos, ";
            sentencia += " " + cliente.TipoPagoID + " AS TIPO_PAGO_ID, ";
            sentencia += " anexo, ";
            sentencia += " tipo_vale, ";
            sentencia += " 0 AS SALDO, ";
            sentencia += " 'S' AS ACTIVO, ";
            sentencia += " '" + cliente.numCta + "' AS NUM_CUENTA ";
            sentencia += " FROM ( SELECT anexo, ";
            sentencia += " tipo_vale, ";
            sentencia += " cod_cliente,  ";
            sentencia += " nom1_farm,  ";
            sentencia += " nom1_cliente, ";
            sentencia += " precio, ";
            sentencia += " SUM (Cantidad) Cantidad,  ";
            sentencia += " SUM (precio * cantidad) SubTotal,  ";
            sentencia += " SUM (iva) IVA,  ";
            sentencia += " SUM ( (precio * cantidad) + iva) Total  ";
            sentencia += " FROM CS_ISSSTEP_CONCENTRADO  ";
            sentencia += " WHERE fecha BETWEEN TO_DATE ('" + FECHAINI.ToString("dd/MM/yyyy 00:00:00") + "', 'DD/MM/YYYY HH24:MI:SS')  ";
            sentencia += " AND TO_DATE ('" + FECHAFIN.ToString("dd/MM/yyyy 23:59:59") + "', 'DD/MM/YYYY HH24:MI:SS')  ";
            sentencia += " AND CLIENTE_ID = " + cliente.ID; // ROMA 02SEP2013
            sentencia += " GROUP BY anexo,  ";
            sentencia += " tipo_vale,  ";
            sentencia += " cod_cliente,  ";
            sentencia += " nom1_farm,  ";
            sentencia += " nom1_cliente,  ";
            sentencia += " precio  ";
            sentencia += " ORDER BY cod_cliente)  ";
            sentencia += " GROUP BY   ";
            sentencia += " anexo, 0, ";
            sentencia += " tipo_vale  ";

            // sentencia += " ORDER BY REMISION_VALE.FECHA_VALE ";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    ds.FACTURA.Constraints.Clear();
                    ds.Tables["FACTURA"].Clear();
                    da.Fill(ds, "FACTURA");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

                if (!ds.FACTURA.Columns.Contains("FACTURAR"))
                {
                    ds.FACTURA.Columns.Add("FACTURAR", Type.GetType("System.Boolean"));
                }

                foreach (DataRow dr in ds.FACTURA.Rows)
                {
                    dr["FACTURAR"] = true;
                }

                //String Claves = CamposSepara(Clave);
                //String Conceptos = CamposSepara(Concepto);

                sentencia = "SELECT ROW_NUMBER() OVER (PARTITION BY anexo, tipo_vale ORDER BY cod_cliente ) renglon,  ";
                sentencia += " cod_cliente as clave, ";
                sentencia += " SUBSTR (nom1_farm, 1, 50) || ' - ' || SUBSTR (nom1_cliente, 1, 147) as descripcion, ";
                sentencia += " 'CAJA' AS unidad, ";
                sentencia += " precio AS precio_unitario, ";
                sentencia += " cantidad, ";
                sentencia += " 0 as descuento, ";
                sentencia += " subtotal, ";
                sentencia += " iva  AS impuesto, ";
                sentencia += " total, ";
                sentencia += " anexo || ' '  || tipo_vale as num_factura, ";
                sentencia += " 1 as  impuesto_id, ";
                sentencia += " anexo, ";
                sentencia += " tipo_vale, ";
                sentencia += " nom1_farm, ";
                sentencia += " nom1_cliente ";
                sentencia += " FROM ( SELECT anexo, ";
                sentencia += " tipo_vale, ";
                sentencia += " cod_cliente, ";
                sentencia += " nom1_farm, ";
                sentencia += " nom1_cliente, ";
                sentencia += " precio, ";
                sentencia += " SUM (Cantidad) Cantidad, ";
                sentencia += " SUM (precio * cantidad) SubTotal, ";
                sentencia += " SUM (iva) IVA, ";
                sentencia += " SUM ( (precio * cantidad) + iva) Total ";
                sentencia += " FROM CS_ISSSTEP_CONCENTRADO ";
                sentencia += " WHERE fecha BETWEEN TO_DATE ('" + FECHAINI.ToString("dd/MM/yyyy 00:00:00") + "', 'DD/MM/YYYY HH24:MI:SS') ";
                sentencia += " AND TO_DATE ('" + FECHAFIN.ToString("dd/MM/yyyy 23:59:59") + "', 'DD/MM/YYYY HH24:MI:SS') ";
                sentencia += " AND cliente_id = " + cliente.ID; // ROMA 02SEP2013
                sentencia += " GROUP BY anexo, ";
                sentencia += " tipo_vale,0, ";
                sentencia += " cod_cliente, ";
                sentencia += " nom1_farm, ";
                sentencia += " nom1_cliente, ";
                sentencia += " precio ";
                sentencia += " ORDER BY cod_cliente) ";

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    ds.EnforceConstraints = false;
                    ds.FACTURA_DETALLE.Constraints.Clear();
                    ds.Tables["FACTURA_DETALLE"].Clear();
                    da.Fill(ds, "FACTURA_DETALLE");
                }

                cnx.Close();
                cnx.Dispose();
               //OracleConnection.ClearPool(cnx);
            }
            return ds;

        }

        public static SIFModelo.SubRogacion.Sobrogacion GetPF_isstep(SIFModelo.SubRogacion.Sobrogacion ds, String Separa, String Concepto, String Clave, String LisRemisiones, SIFModelo.ClienteSubrogaccion cliente, DateTime FECHAINI, DateTime FECHAFIN, int rowini, int rowFin, string Anexo, string TipoVale)
        {
            String CamposSep = CamposSepara(Separa);
            String sentencia = "";
            sentencia = " SELECT ";
            sentencia += "  anexo || ' ' || tipo_vale AS NUM_FACTURA,";
            sentencia += "  " + cliente.ID + " AS CLIENTE_ID,";
            sentencia += "  TO_DATE ('" + Configuracion.FechaServidor().ToString("dd/MM/yyyy") + "', 'DD/MM/YYYY') AS FECHA,";
            sentencia += "  ' ' AS REFERENCIA,";
            sentencia += "  '' AS IMPORTE_LETRA,";
            sentencia += "  SUM (subtotal) AS subtotal,";
            sentencia += "  SUM (impuesto) AS impuesto_iva,";
            sentencia += "  sum(DESCUENTO) AS descuento,";
            sentencia += "  SUM (total) AS total,";
            sentencia += "  SUM (cantidad) AS total_articulos,";
            sentencia += "  " + cliente.TipoPagoID + " AS TIPO_PAGO_ID,";
            sentencia += "  anexo,";
            sentencia += " tipo_vale,";
            sentencia += " 0 AS SALDO,";
            sentencia += " 'S' AS ACTIVO,";
            sentencia += " '' AS NUM_CUENTA";
            sentencia += " FROM (  SELECT ROW_NUMBER ()";
            sentencia += " OVER (PARTITION BY anexo, tipo_vale ORDER BY cod_cliente)";
            sentencia += " rn,                                       ";
            sentencia += " cod_cliente AS clave,";
            sentencia += " SUBSTR (nom1_farm, 1, 50)";
            sentencia += " || ' - '";
            sentencia += " || SUBSTR (nom1_cliente, 1, 147)";
            sentencia += "  AS descripcion,";
            sentencia += " 'CAJA' AS unidad,";
            sentencia += "  precio AS precio_unitario,";
            sentencia += "  SUM (cantidad) cantidad,";
            sentencia += "  sum(DESCUENTO) AS descuento,";
            sentencia += "  SUM (subtotal) subtotal,";
            sentencia += "  SUM (iva)  AS impuesto,";
            sentencia += "  SUM (total) total,";
            sentencia += "  anexo || ' ' || tipo_vale AS num_factura,";
            sentencia += "  CASE WHEN SUM (iva) > 0 THEN 2 ELSE 1 END AS impuesto_id,  ";
            sentencia += "  anexo,";
            sentencia += "  tipo_vale,";
            sentencia += "  nom1_farm,";
            sentencia += "  nom1_cliente ";
            sentencia += "  FROM cs_issstep_concentrado";
            sentencia += "  WHERE fecha BETWEEN TO_DATE ('" + FECHAINI.ToString("dd/MM/yyyy 00:00:00") + "',";
            sentencia += "  'DD/MM/YYYY HH24:MI:SS')";
            sentencia += "  AND TO_DATE ('" + FECHAFIN.ToString("dd/MM/yyyy 23:59:59") + "',";
            sentencia += "  'DD/MM/YYYY HH24:MI:SS')";
            sentencia += "  AND tipo_vale = '" + TipoVale + "'";
            sentencia += "  AND anexo = " + Anexo + " ";
            sentencia += "  AND cliente_id = '" + cliente.ID + "'"; // ROMA 02SEP2013
            sentencia += "  GROUP BY anexo,";
            sentencia += "  DESCUENTO,";
            sentencia += "  tipo_vale,";
            sentencia += "  cod_cliente,";
            sentencia += "  nom1_farm,";
            sentencia += "  nom1_cliente,";
            sentencia += "  precio";
            sentencia += "  ORDER BY cod_cliente)";
         //   sentencia += " WHERE rn BETWEEN " + rowini + " AND " + rowFin + "";///////////////////////////////////////////////////////////////////VMJA
            sentencia += " group by anexo,tipo_vale";

            if (cliente.ID != 90)
            {
                sentencia = " SELECT ";
                sentencia += "  to_char(sysdate,'ddmmrrrr') AS NUM_FACTURA,";
                sentencia += "  " + cliente.ID + " AS CLIENTE_ID,";
                sentencia += "  TO_DATE ('" + Configuracion.FechaServidor().ToString("dd/MM/yyyy") + "', 'DD/MM/YYYY') AS FECHA,";
                sentencia += "  ' ' AS REFERENCIA,";
                sentencia += "  '' AS IMPORTE_LETRA,";
                sentencia += "  SUM (subtotal) AS subtotal,";
                sentencia += "  SUM (impuesto) AS impuesto_iva,";
                sentencia += "  sum(DESCUENTO) AS descuento,";
                sentencia += "  SUM (total) AS total,";
                sentencia += "  SUM (cantidad) AS total_articulos,";
                sentencia += "  " + cliente.TipoPagoID + " AS TIPO_PAGO_ID,";
                sentencia += "  anexo,";
                sentencia += " tipo_vale,";
                sentencia += " 0 AS SALDO,";
                sentencia += " 'S' AS ACTIVO,";
                sentencia += " '' AS NUM_CUENTA";
                sentencia += " FROM (  SELECT ROW_NUMBER ()";
                sentencia += " OVER (PARTITION BY anexo, tipo_vale ORDER BY cod_cliente)";
                sentencia += " rn,                                       ";
                sentencia += " cod_cliente AS clave,";
                sentencia += " SUBSTR (nom1_farm, 1, 50)";
                sentencia += " || ' - '";
                sentencia += " || SUBSTR (nom1_cliente, 1, 147)";
                sentencia += "  AS descripcion,";
                sentencia += " 'CAJA' AS unidad,";
                sentencia += "  precio AS precio_unitario,";
                sentencia += "  SUM (cantidad) cantidad,";
                sentencia += "  sum(DESCUENTO) AS descuento,";
                sentencia += "  SUM (subtotal) subtotal,";
                sentencia += "  SUM (iva)  AS impuesto,";
                sentencia += "  SUM (total) total,";
                sentencia += "  anexo || ' ' || tipo_vale AS num_factura,";
                sentencia += "  CASE WHEN SUM (iva) > 0 THEN 2 ELSE 1 END AS impuesto_id,  ";
                sentencia += "  anexo,";
                sentencia += "  tipo_vale,";
                sentencia += "  nom1_farm,";
                sentencia += "  nom1_cliente ";
                sentencia += "  FROM cs_issstep_concentrado";
                sentencia += "  WHERE fecha BETWEEN TO_DATE ('" + FECHAINI.ToString("dd/MM/yyyy 00:00:00") + "',";
                sentencia += "  'DD/MM/YYYY HH24:MI:SS')";
                sentencia += "  AND TO_DATE ('" + FECHAFIN.ToString("dd/MM/yyyy 23:59:59") + "',";
                sentencia += "  'DD/MM/YYYY HH24:MI:SS')";
                sentencia += "  AND tipo_vale = '" + TipoVale + "'";
                sentencia += "  AND anexo = " + Anexo + " ";
                sentencia += "  AND cliente_id = '" + cliente.ID + "'"; // ROMA 02SEP2013
                sentencia += " AND NUM_REMISION IN (''" + LisRemisiones.Replace("''", "'") + ")"; //LGS 31/03/2014
                sentencia += "  GROUP BY anexo,";
                sentencia += "  DESCUENTO,";
                sentencia += "  tipo_vale,";
                sentencia += "  cod_cliente,";
                sentencia += "  nom1_farm,";
                sentencia += "  nom1_cliente,";
                sentencia += "  precio";
                sentencia += "  ORDER BY cod_cliente)";
               // sentencia += " WHERE rn BETWEEN " + rowini + " AND " + rowFin + "";///////////////////////////////////VMJA
                sentencia += " group by anexo,tipo_vale";
            }

            // sentencia += " ORDER BY REMISION_VALE.FECHA_VALE ";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    ds.FACTURA.Constraints.Clear();
                    ds.Tables["FACTURA"].Clear();
                    da.Fill(ds, "FACTURA");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

                if (!ds.FACTURA.Columns.Contains("FACTURAR"))
                {
                    ds.FACTURA.Columns.Add("FACTURAR", Type.GetType("System.Boolean"));
                }

                foreach (DataRow dr in ds.FACTURA.Rows)
                {
                    dr["FACTURAR"] = true;
                }

                //String Claves = CamposSepara(Clave);
                //String Conceptos = CamposSepara(Concepto);

                sentencia = " SELECT * ";
                sentencia += "  FROM (  SELECT ROW_NUMBER () ";
                sentencia += "  OVER (PARTITION BY anexo, tipo_vale ORDER BY cod_cliente) ";
                sentencia += "  rn, ";
                sentencia += "  cod_cliente AS clave, ";
                sentencia += "  SUBSTR (nom1_farm, 1, 50) ";
                sentencia += "  || ' - ' ";
                sentencia += "  || SUBSTR (nom1_cliente, 1, 147) ";
                sentencia += "  AS descripcion, ";
                sentencia += "  'CAJA' AS unidad, ";
                sentencia += "  precio AS precio_unitario, ";
                sentencia += "  SUM (cantidad) cantidad, ";
                sentencia += "  0 AS descuento, ";
                sentencia += "  SUM (subtotal) subtotal, ";
                sentencia += "  SUM (iva)  AS impuesto, ";
                sentencia += "  SUM (subtotal) total, ";
                sentencia += "  anexo || ' ' || tipo_vale AS num_factura, ";
                sentencia += "  CASE WHEN SUM (iva) > 0 THEN 2 ELSE 1 END AS impuesto_id,   ";
                sentencia += "  anexo, ";
                sentencia += "  tipo_vale, ";
                sentencia += "  nom1_farm, ";
                sentencia += "  nom1_cliente  ";
                sentencia += "  FROM cs_issstep_concentrado ";
                sentencia += "  WHERE fecha BETWEEN TO_DATE ('" + FECHAINI.ToString("dd/MM/yyyy 00:00:00") + "', ";
                sentencia += "  'DD/MM/YYYY HH24:MI:SS') ";
                sentencia += "  AND TO_DATE ('" + FECHAFIN.ToString("dd/MM/yyyy 00:00:00") + "', ";
                sentencia += "  'DD/MM/YYYY HH24:MI:SS') ";
                sentencia += "  AND tipo_vale = '" + TipoVale + "' ";
                sentencia += "  AND anexo = " + Anexo + " ";
                sentencia += "  AND cliente_id = '" + cliente.ID + "'"; // ROMA 02SEP2013
                sentencia += "  GROUP BY anexo, ";
                sentencia += "  tipo_vale, ";
                sentencia += "  cod_cliente, ";
                sentencia += "  nom1_farm, ";
                sentencia += "  nom1_cliente, ";
                sentencia += "  precio ";
                sentencia += "  ORDER BY cod_cliente) ";
              //  sentencia += "  WHERE rn BETWEEN " + rowini + " AND " + rowFin + "  ";/////////////////////////////////////////////////////////VMJA

                if (cliente.ID != 90)
                {
                    String Claves = CamposSepara(Clave);
                    String Conceptos = CamposSepara(Concepto);
                    sentencia = " SELECT * ";
                    sentencia += "  FROM (  SELECT ROW_NUMBER () ";
                    sentencia += "  OVER (PARTITION BY anexo, tipo_vale ORDER BY cod_cliente) ";
                    sentencia += "  rn, ";
                    sentencia += "  cod_cliente AS clave, ";
                    sentencia += "  SUBSTR (nom1_farm, 1, 50) ";
                    //Siguientes 2 lineas comentadas para evitar que se duplique el nombre del producto
                    //sentencia += "  || ' - ' ";
                    //sentencia += "  || SUBSTR (nom1_cliente, 1, 147) ";
                    sentencia += "  AS descripcion, ";
                    sentencia += "  'CAJA' AS unidad, ";
                    sentencia += "  precio AS precio_unitario, ";
                    sentencia += "  SUM (cantidad) cantidad, ";
                    sentencia += "  0 AS descuento, ";
                    sentencia += "  SUM (subtotal) subtotal, ";
                    sentencia += "  SUM (iva)  AS impuesto, ";
                    sentencia += "  SUM (total) total, ";
                    //sentencia += "  anexo || ' ' || tipo_vale AS num_factura, ";
                    sentencia += "  to_char(sysdate,'ddmmrrrr') AS NUM_FACTURA,";
                    sentencia += "  CASE WHEN SUM (iva) > 0 THEN 2 ELSE 1 END AS impuesto_id,   ";
                    sentencia += "  anexo, ";
                    sentencia += "  tipo_vale, ";
                    sentencia += "  nom1_farm, ";
                    sentencia += "  nom1_cliente  ";
                    sentencia += "  FROM cs_issstep_concentrado ";
                    sentencia += "  WHERE fecha BETWEEN TO_DATE ('" + FECHAINI.ToString("dd/MM/yyyy 00:00:00") + "', ";
                    sentencia += "  'DD/MM/YYYY HH24:MI:SS') ";
                    sentencia += "  AND TO_DATE ('" + FECHAFIN.ToString("dd/MM/yyyy 23:59:59") + "', ";
                    sentencia += "  'DD/MM/YYYY HH24:MI:SS') ";
                    sentencia += "  AND tipo_vale = '" + TipoVale + "' ";
                    sentencia += "  AND anexo = " + Anexo + " ";
                    sentencia += "  AND cliente_id = '" + cliente.ID + "'"; // ROMA 02SEP2013
                    sentencia += " AND NUM_REMISION IN (''" + LisRemisiones.Replace("''", "'") + ")"; //LGS 31/03/2014
                    sentencia += "  GROUP BY anexo, ";
                    sentencia += "  tipo_vale, ";
                    sentencia += "  cod_cliente, ";
                    sentencia += "  nom1_farm, ";
                    sentencia += "  nom1_cliente, ";
                    sentencia += "  precio ";
                    sentencia += "  ORDER BY cod_cliente) ";
                   // sentencia += "  WHERE rn BETWEEN " + rowini + " AND " + rowFin + "  ";////////////////////////////////////////////////////////////VMJA
                }


                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    ds.EnforceConstraints = false;
                    ds.FACTURA_DETALLE.Constraints.Clear();
                    ds.Tables["FACTURA_DETALLE"].Clear();
                    da.Fill(ds, "FACTURA_DETALLE");
                }

                cnx.Close();
                cnx.Dispose();
               //OracleConnection.ClearPool(cnx);
            }
            return ds;

        }

        private static string CamposSepara(String Campos)
        {
            String Cadena = "";
            String Texto = "";
            String Texto1 = "";
            if ((Campos.Length > 0) & (Campos.IndexOf("{") > 1))
                Texto = Campos.Substring(0, Campos.IndexOf("{") - 1);

            if ((Campos.Length > 0) & (Campos.IndexOf("{") == -1))
                Texto = Campos;

            switch (Token(Campos))
            {
                case "No Remisión":
                    Cadena = Campos.Substring(Campos.IndexOf("}") + 1);
                    if ((Cadena.Length > 0) & (Cadena.IndexOf("{") > 0))
                        Texto1 = Cadena.Substring(0, Cadena.IndexOf("{"));
                    if (Cadena.IndexOf("{") > -1)
                        return "'" + Texto + " '|| REMISION_DET.NUM_REMISION || '" + Texto1 + "'||" + CamposSepara(Cadena);
                    else
                        return "'" + Texto + " '|| REMISION_DET.NUM_REMISION";
                    break;
                case "Anexo":
                    Cadena = Campos.Substring(Campos.IndexOf("}") + 1);
                    if ((Cadena.Length > 0) & (Cadena.IndexOf("{") > 0))
                        Texto1 = Cadena.Substring(0, Cadena.IndexOf("{"));
                    if (Cadena.IndexOf("{") > -1)
                        return "'" + Texto + " '|| CAT_ARTICULOS_SUB.ANEXO || ' " + Texto1 + " '||" + CamposSepara(Cadena);
                    else
                        return "'" + Texto + " '|| CAT_ARTICULOS_SUB.ANEXO";
                    break;
                case "Codigo Cliente":
                    Cadena = Campos.Substring(Campos.IndexOf("}") + 1);
                    if ((Cadena.Length > 0) & (Cadena.IndexOf("{") > 0))
                        Texto1 = Cadena.Substring(0, Cadena.IndexOf("{"));
                    if (Cadena.IndexOf("{") > -1)
                        return "'" + Texto + " '|| CAT_ARTICULOS_SUB.CODIGOCLI || '" + Texto1 + "'||" + CamposSepara(Cadena);
                    else
                        return "'" + Texto + " '|| CAT_ARTICULOS_SUB.CODIGOCLI ";
                    break;

                case "Nombre Producto Cliente":
                    Cadena = Campos.Substring(Campos.IndexOf("}") + 1);
                    if ((Cadena.Length > 0) & (Cadena.IndexOf("{") > 0))
                        Texto1 = Cadena.Substring(0, Cadena.IndexOf("{") - 1);
                    if (Cadena.IndexOf("{") > -1)
                        return "'" + Texto + " '|| substr(CAT_ARTICULOS_SUB.NOMBRE1 ,0,140)  || '" + Texto1 + "'||" + CamposSepara(Cadena);
                    else
                        return "'" + Texto + " '|| substr(CAT_ARTICULOS_SUB.NOMBRE1 ,0,140) ";
                    break;

                case "Componente Activo Cliente":
                    Cadena = Campos.Substring(Campos.IndexOf("}") + 1);
                    if ((Cadena.Length > 0) & (Cadena.IndexOf("{") > 0))
                        Texto1 = Cadena.Substring(0, Cadena.IndexOf("{"));
                    if (Cadena.IndexOf("{") > -1)
                        return "'" + Texto + " '||  CAT_ARTICULOS_SUB.NOMBRE2 || '" + Texto1 + "'|| " + CamposSepara(Cadena);
                    else
                        return "'" + Texto + " '|| CAT_ARTICULOS_SUB.NOMBRE2 ";
                    break;

                case "Tipo Medicamento Cliente":
                    Cadena = Campos.Substring(Campos.IndexOf("}") + 1);
                    if ((Cadena.Length > 0) & (Cadena.IndexOf("{") > 0))
                        Texto1 = Cadena.Substring(0, Cadena.IndexOf("{"));
                    if (Cadena.IndexOf("{") > -1)
                        return "CAT_ARTICULOS_SUB.TIPO_MEDICAMENTO_CLI || '" + Texto1 + "'|| " + CamposSepara(Cadena);
                    else
                        return "'" + Texto + " '|| CAT_ARTICULOS_SUB.TIPO_MEDICAMENTO_CLI";
                    break;

                case "Codigo Articulo":
                    Cadena = Campos.Substring(Campos.IndexOf("}") + 1);
                    if ((Cadena.Length > 0) & (Cadena.IndexOf("{") > 0))
                        Texto1 = Cadena.Substring(0, Cadena.IndexOf("{"));
                    if (Cadena.IndexOf("{") > -1)
                        return "'" + Texto + " '|| CAT_ARTICULOS.ARTICULO_ID || '" + Texto1 + "'|| " + CamposSepara(Cadena);
                    else
                        return "'" + Texto + " '|| CAT_ARTICULOS.ARTICULO_ID";
                    break;

                case "Nombre Producto":
                    Cadena = Campos.Substring(Campos.IndexOf("}") + 1);
                    if ((Cadena.Length > 0) & (Cadena.IndexOf("{") > 0))
                        Texto1 = Cadena.Substring(0, Cadena.IndexOf("{"));
                    if (Cadena.IndexOf("{") > -1)
                        return "'" + Texto + " '||  substr(CAT_ARTICULOS.NOMBRE1,0,45)  || '" + Texto1 + "'|| " + CamposSepara(Cadena);
                    else
                        return "'" + Texto + " '||  substr(CAT_ARTICULOS.NOMBRE1,0,45) ";
                    break;
                case "Nombre2 SAL":
                    Cadena = Campos.Substring(Campos.IndexOf("}") + 1);
                    if ((Cadena.Length > 0) & (Cadena.IndexOf("{") > 0))
                        Texto1 = Cadena.Substring(0, Cadena.IndexOf("{"));
                    if (Cadena.IndexOf("{") > -1)
                        return "'" + Texto + " '|| '; ' || CAT_ARTICULOS.NOMBRE2 || '" + Texto1 + "'|| " + CamposSepara(Cadena);
                    else
                        return "'" + Texto + " '|| '; ' || CAT_ARTICULOS.NOMBRE2";
                    break;

                case "Componente Activo":
                    Cadena = Campos.Substring(Campos.IndexOf("}") + 1);
                    if ((Cadena.Length > 0) & (Cadena.IndexOf("{") > 0))
                        Texto1 = Cadena.Substring(0, Cadena.IndexOf("{"));

                    if (Cadena.IndexOf("{") > -1)
                        return "'" + Texto + " '|| CAT_ARTICULOS.NOMBRE2 || '" + Texto1 + "'|| " + CamposSepara(Cadena);
                    else
                        return "'" + Texto + " '|| CAT_ARTICULOS.NOMBRE2";
                    break;

                case "Tipo Medicamento":
                    Cadena = Campos.Substring(Campos.IndexOf("}") + 1);
                    if ((Cadena.Length > 0) & (Cadena.IndexOf("{") > 0))
                        Texto1 = Cadena.Substring(0, Cadena.IndexOf("{"));
                    if (Cadena.IndexOf("{") > -1)
                        return "'" + Texto + " '|| CAT_ARTICULOS.TIPO_MEDICAMENTO_CVE || '" + Texto1 + "'|| " + CamposSepara(Cadena);
                    else
                        return "'" + Texto + " '|| CAT_ARTICULOS.TIPO_MEDICAMENTO_CVE";
                    break;

                case "Laboratorio":
                    Cadena = Campos.Substring(Campos.IndexOf("}") + 1);
                    if ((Cadena.Length > 0) & (Cadena.IndexOf("{") > 0))
                        Texto1 = Cadena.Substring(0, Cadena.IndexOf("{"));
                    if (Cadena.IndexOf("{") > -1)
                        return "'" + Texto + " '|| CAT_ARTICULOS.LABORATORIO_ID || '" + Texto1 + "'|| " + CamposSepara(Cadena);
                    else
                        return "'" + Texto + " '|| CAT_ARTICULOS.LABORATORIO_ID";
                    break;

                case "Proveedor":
                    Cadena = Campos.Substring(Campos.IndexOf("}") + 1);
                    if (Cadena.Length > 0)
                        Texto1 = Cadena.Substring(0, Cadena.IndexOf("{"));
                    if (Cadena.IndexOf("{") > -1)
                        return "'" + Texto + " '|| CAT_ARTICULOS.Proveedor || '" + Texto1 + "'|| " + CamposSepara(Cadena);
                    else
                        return "'" + Texto + " '|| CAT_ARTICULOS.Proveedor";
                    break;

                case "Tipo Descuento":
                    Cadena = Campos.Substring(Campos.IndexOf("}") + 1);
                    if ((Cadena.Length > 0) & (Cadena.IndexOf("{") > 0))
                        Texto1 = Cadena.Substring(0, Cadena.IndexOf("{"));
                    if (Cadena.IndexOf("{") > -1)
                        return "'" + Texto + " '|| CAT_ARTICULOS_SUB.TIPO_DESC || '" + Texto1 + "'|| " + CamposSepara(Cadena);
                    else
                        return "'" + Texto + " '|| CAT_ARTICULOS_SUB.TIPO_DESC";
                    break;
                case "Tipo Vale":
                    // Texto = "";
                    Cadena = Campos.Substring(Campos.IndexOf("}") + 1);
                    if ((Cadena.Length > 0) & (Cadena.IndexOf("{") > 0))
                        Texto1 = Cadena.Substring(0, Cadena.IndexOf("{"));
                    if (Cadena.IndexOf("{") > -1)
                        return "'" + Texto + " '|| REMISION_VALE.TIPO_VALE || '" + Texto1 + "'|| " + CamposSepara(Cadena);
                    else
                        return "'" + Texto + " '|| REMISION_VALE.TIPO_VALE";
                    break;

                default:
                    return "'" + Texto + " '";
            }
        }

        private static string Token(String Campos)
        {
            if (Campos.IndexOf("{") > -1)
                return (Campos.Substring(Campos.IndexOf("{") + 1, (Campos.IndexOf("}") - 1) - (Campos.IndexOf("{"))));
            else
                return "";
        }

        public static SIFModelo.SubRogacion.Sobrogacion Update(SIFModelo.SubRogacion.Sobrogacion ds)
        {

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.SubRogacion.SobrogacionTableAdapters.CAT_ARTICULOS_SUBTableAdapter Tb = new SIFModelo.SubRogacion.SobrogacionTableAdapters.CAT_ARTICULOS_SUBTableAdapter();

                Tb.Connection.ConnectionString = cnx.ConnectionString;
                Tb.Update(ds.CAT_ARTICULOS_SUB);

            }
            return ds;

        }

        //  public static int NumeroFacturas(DateTime fechaInicio, DateTime fechaFin, string anexo, string vale)
        //  {

        //      String Sentencia = "SELECT TRUNC (COUNT (*) / 40) " +
        //" + CASE WHEN MOD (COUNT (*), 40) = 0 THEN 0 ELSE 1 END " +
        //"    paginas " +
        //"  FROM (  SELECT anexo, " +
        //         " tipo_vale, " +
        //         " cod_cliente, " +
        //         " nom1_farm, " +
        //         " nom1_cliente, " +
        //         " precio, " +
        //         " SUM (cantidad) cantidad, " +
        //         " SUM (subtotal) subtotal, " +
        //         " SUM (iva) iva, " +
        //         " SUM (total) total, " +
        //         "    SUBSTR (nom1_farm, 1, 50) " +
        //         " || ' - ' " +
        //         " || SUBSTR (nom1_cliente, 1, 147) " +
        //         "    nom_factura " +
        //    "  FROM cs_issstep_concentrado " +
        //    "  WHERE fecha >= TO_DATE ('" + fechaInicio.ToString("dd/MM/yyyy 00:00:00") + "', 'DD/MM/YYYY HH24:MI:SS') " +
        //                  "   AND fecha <= TO_DATE ('" + fechaFin.ToString("dd/MM/yyyy 23:59:59") + "', 'DD/MM/YYYY HH24:MI:SS') " +
        //          " AND tipo_vale = '" + vale + "' " +
        //          " AND anexo = " + anexo + " " +
        //  " GROUP BY anexo, " +
        //         "  tipo_vale, " +
        //         "  cod_cliente, " +
        //         "  nom1_farm, " +
        //         "  nom1_cliente, " +
        //         "  precio " +
        //  " ORDER BY cod_cliente) ";

        //      using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
        //      {
        //          using (OracleCommand cmd = new OracleCommand(Sentencia, cnx))
        //          {
        //              cmd.Connection.Open();
        //              var obj = cmd.ExecuteScalar();

        //              if (obj.ToString().IsInteger())
        //              {
        //                  return System.Convert.ToInt32(obj);
        //              }
        //          }
        //      }
        //      return 0;
        //  }



        public static int NumeroFacturas(DateTime FecIni, DateTime FecFin, string tipoVale, int nAnexo)
        {
            string sentencia = "PKG_ISSSTEP.sp_Get_NoFacturas";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("FecIni", FecIni.ToString("dd/MM/yyyy 00:00:00"));
                    cmd.Parameters.Add("FecFin", FecFin.ToString("dd/MM/yyyy 23:59:59"));
                    cmd.Parameters.Add("tVale", tipoVale);
                    cmd.Parameters.Add("nAnexo", nAnexo);

                    OracleParameter OutParam = new OracleParameter("OutParam", OracleDbType.Decimal);
                    OutParam.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(OutParam);

                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (OutParam.Value.ToString().IsIntegerPositive())
                        {
                            return System.Convert.ToInt32(OutParam.Value.ToString());
                        }
                        else
                        {
                            int facturas = System.Convert.ToInt32(OutParam.Value);
                            return facturas;
                        }


                    }
                    catch
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
        }

        public static DataSet sp_get_Reportes(DateTime FecIni, DateTime FecFin, string tipoVale, int nAnexo, int rIni, int rFin)
        {
            string sentencia = "PKG_ISSSTEP.sp_get_Reportes";

            DataSet ds = new DataSet();
            DataTable dtConcentrado = ds.Tables.Add("cs_issstep_concentrado");
            dtConcentrado.Columns.Add("RN", Type.GetType("System.Int32"));
            dtConcentrado.Columns.Add("anexo", Type.GetType("System.String"));
            dtConcentrado.Columns.Add("tipo_vale", Type.GetType("System.String"));
            dtConcentrado.Columns.Add("cod_cliente", Type.GetType("System.Int32"));
            dtConcentrado.Columns.Add("nom1_farm", Type.GetType("System.String"));
            dtConcentrado.Columns.Add("nom1_cliente", Type.GetType("System.String"));
            dtConcentrado.Columns.Add("precio", Type.GetType("System.Decimal"));
            dtConcentrado.Columns.Add("cantidad", Type.GetType("System.Int32"));
            dtConcentrado.Columns.Add("subtotal", Type.GetType("System.Decimal"));
            dtConcentrado.Columns.Add("iva", Type.GetType("System.Decimal"));
            dtConcentrado.Columns.Add("total", Type.GetType("System.Decimal"));
            dtConcentrado.Columns.Add("nom_factura", Type.GetType("System.String"));

            DataTable dtDesglose = ds.Tables.Add("cs_issstep_desglose");
            dtDesglose.Columns.Add("FECHA", Type.GetType("System.DateTime"));
            dtDesglose.Columns.Add("FECHA_VALE", Type.GetType("System.DateTime"));
            dtDesglose.Columns.Add("ANEXO", Type.GetType("System.String"));
            dtDesglose.Columns.Add("TIPO_VALE", Type.GetType("System.String"));
            dtDesglose.Columns.Add("NUM_VALE", Type.GetType("System.String"));
            dtDesglose.Columns.Add("CLIENTE_ID", Type.GetType("System.Int32"));
            dtDesglose.Columns.Add("COD_CLIENTE", Type.GetType("System.Int32"));
            dtDesglose.Columns.Add("nom1_farm", Type.GetType("System.String"));
            dtDesglose.Columns.Add("nom2_farm", Type.GetType("System.String"));
            dtDesglose.Columns.Add("nom1_cliente", Type.GetType("System.String"));
            dtDesglose.Columns.Add("nom2_cliente", Type.GetType("System.String"));
            dtDesglose.Columns.Add("precio", Type.GetType("System.Decimal"));
            dtDesglose.Columns.Add("cantidad", Type.GetType("System.Int32"));
            dtDesglose.Columns.Add("subtotal", Type.GetType("System.Decimal"));
            dtDesglose.Columns.Add("iva", Type.GetType("System.Decimal"));
            dtDesglose.Columns.Add("total", Type.GetType("System.Decimal"));
            dtDesglose.Columns.Add("RN", Type.GetType("System.Int32"));

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("FecIni", FecIni.ToString("dd/MM/yyyy 00:00:00"));
                    cmd.Parameters.Add("FecFin", FecFin.ToString("dd/MM/yyyy 23:59:59"));
                    cmd.Parameters.Add("tVale", tipoVale);
                    cmd.Parameters.Add("nAnexo", nAnexo);
                    cmd.Parameters.Add("rIni", rIni);
                    cmd.Parameters.Add("rFin", rFin);

                    OracleParameter pConcentrado = new OracleParameter("Concentrado", OracleDbType.RefCursor);
                    pConcentrado.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(pConcentrado);

                    OracleParameter pDesglose = new OracleParameter("Desglose", OracleDbType.RefCursor);
                    pDesglose.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(pDesglose);


                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    OracleDataReader rConcentrado = ((OracleRefCursor)pConcentrado.Value).GetDataReader();
                    OracleDataReader rDesglose = ((OracleRefCursor)pDesglose.Value).GetDataReader();

                    if (rConcentrado.HasRows)
                    {
                        while (rConcentrado.Read())
                        {
                            DataRow row = ds.Tables["cs_issstep_concentrado"].NewRow();
                            row["RN"] = System.Convert.ToInt32(rConcentrado["rn"]);
                            row["anexo"] = System.Convert.ToString(rConcentrado["anexo"]);
                            row["tipo_vale"] = System.Convert.ToString(rConcentrado["tipo_vale"]);
                            row["cod_cliente"] = System.Convert.ToString(rConcentrado["cod_cliente"]);
                            row["nom1_farm"] = System.Convert.ToString(rConcentrado["nom1_farm"]);
                            row["nom1_cliente"] = System.Convert.ToString(rConcentrado["nom1_cliente"]);
                            row["precio"] = System.Convert.ToDecimal(rConcentrado["precio"]);
                            row["cantidad"] = System.Convert.ToInt32(rConcentrado["cantidad"]);
                            row["subtotal"] = System.Convert.ToDecimal(rConcentrado["subtotal"]);
                            row["iva"] = System.Convert.ToDecimal(rConcentrado["iva"]);
                            row["total"] = System.Convert.ToDecimal(rConcentrado["total"]);
                            row["nom_factura"] = System.Convert.ToString(rConcentrado["nom_factura"]);

                            ds.Tables["cs_issstep_concentrado"].Rows.Add(row);

                        }
                    }


                    if (rDesglose.HasRows)
                    {
                        while (rDesglose.Read())
                        {
                            DataRow row = ds.Tables["cs_issstep_desglose"].NewRow();
                            row["FECHA"] = System.Convert.ToDateTime(rDesglose["FECHA"]);
                            row["FECHA_VALE"] = System.Convert.ToDateTime(rDesglose["FECHA_VALE"]);
                            row["ANEXO"] = System.Convert.ToString(rDesglose["ANEXO"]);
                            row["TIPO_VALE"] = System.Convert.ToString(rDesglose["TIPO_VALE"]);
                            row["NUM_VALE"] = System.Convert.ToString(rDesglose["NUM_VALE"]);
                            row["CLIENTE_ID"] = System.Convert.ToInt32(rDesglose["CLIENTE_ID"]);
                            row["COD_CLIENTE"] = System.Convert.ToString(rDesglose["COD_CLIENTE"]);
                            row["NOM1_FARM"] = System.Convert.ToString(rDesglose["NOM1_FARM"]);
                            row["NOM2_FARM"] = System.Convert.ToString(rDesglose["NOM2_FARM"]);
                            row["NOM1_CLIENTE"] = System.Convert.ToString(rDesglose["NOM1_CLIENTE"]);
                            row["NOM2_CLIENTE"] = System.Convert.ToString(rDesglose["NOM2_CLIENTE"]);
                            row["PRECIO"] = System.Convert.ToDecimal(rDesglose["PRECIO"]);
                            row["CANTIDAD"] = System.Convert.ToInt32(rDesglose["CANTIDAD"]);
                            row["SUBTOTAL"] = System.Convert.ToDecimal(rDesglose["SUBTOTAL"]);
                            row["IVA"] = System.Convert.ToDecimal(rDesglose["IVA"]);
                            row["TOTAL"] = System.Convert.ToDecimal(rDesglose["TOTAL"]);
                            // row["RN"] = System.Convert.ToInt32(rDesglose["RN"]);

                            ds.Tables["cs_issstep_desglose"].Rows.Add(row);
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }
            }

            return ds;

        }

        #region ROMA 02SEP2013
        public static int NumeroFacturas(DateTime FecIni, DateTime FecFin, string tipoVale, int nAnexo, string IdCliente)
        {

            using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_ISSSTEP.sp_Get_NoFacturas";
                cmd.BindByName = true;

                cmd.Parameters.Add("FecIni", OracleDbType.Varchar2, FecIni.ToString("dd/MM/yyyy 00:00:00"), ParameterDirection.Input);
                cmd.Parameters.Add("FecFin", OracleDbType.Varchar2, FecFin.ToString("dd/MM/yyyy 23:59:59"), ParameterDirection.Input);
                cmd.Parameters.Add("tVale", OracleDbType.Varchar2, tipoVale, ParameterDirection.Input);
                cmd.Parameters.Add("nAnexo", OracleDbType.Varchar2, nAnexo, ParameterDirection.Input);
                cmd.Parameters.Add("IdCliente", OracleDbType.Varchar2, IdCliente, ParameterDirection.Input);

                OracleParameter OutParam = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                //OracleParameter OutParam = new OracleParameter("OutParam", OracleDbType.Decimal);
                //OutParam.Direction = System.Data.ParameterDirection.Output;
                //cmd.Parameters.Add(OutParam);

                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    if (OutParam.Value.ToString().IsIntegerPositive())
                    {
                        return System.Convert.ToInt32(OutParam.Value.ToString());
                    }
                    else
                    {
                        int facturas = System.Convert.ToInt32(OutParam.Value);
                        return facturas;
                    }


                }
                catch
                {
                    return 0;
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(conn);

                }
            }
        }


        public static DataSet sp_get_Reportes(DateTime FecIni, DateTime FecFin, string IdCliente, string tipoVale, int nAnexo, int rIni, int rFin)
        {
            string sentencia = "PKG_ISSSTEP.sp_get_Reportes";

            DataSet ds = new DataSet();
            DataTable dtConcentrado = ds.Tables.Add("cs_issstep_concentrado");
            dtConcentrado.Columns.Add("RN", Type.GetType("System.Int32"));
            dtConcentrado.Columns.Add("anexo", Type.GetType("System.String"));
            dtConcentrado.Columns.Add("tipo_vale", Type.GetType("System.String"));
            dtConcentrado.Columns.Add("cod_cliente", Type.GetType("System.Int32"));
            dtConcentrado.Columns.Add("nom1_farm", Type.GetType("System.String"));
            dtConcentrado.Columns.Add("nom1_cliente", Type.GetType("System.String"));
            dtConcentrado.Columns.Add("precio", Type.GetType("System.Decimal"));
            dtConcentrado.Columns.Add("cantidad", Type.GetType("System.Int32"));
            dtConcentrado.Columns.Add("subtotal", Type.GetType("System.Decimal"));
            dtConcentrado.Columns.Add("iva", Type.GetType("System.Decimal"));
            dtConcentrado.Columns.Add("total", Type.GetType("System.Decimal"));
            dtConcentrado.Columns.Add("nom_factura", Type.GetType("System.String"));

            DataTable dtDesglose = ds.Tables.Add("cs_issstep_desglose");
            dtDesglose.Columns.Add("FECHA", Type.GetType("System.DateTime"));
            dtDesglose.Columns.Add("FECHA_VALE", Type.GetType("System.DateTime"));
            dtDesglose.Columns.Add("ANEXO", Type.GetType("System.String"));
            dtDesglose.Columns.Add("TIPO_VALE", Type.GetType("System.String"));
            dtDesglose.Columns.Add("NUM_VALE", Type.GetType("System.String"));
            dtDesglose.Columns.Add("CLIENTE_ID", Type.GetType("System.Int32"));
            dtDesglose.Columns.Add("COD_CLIENTE", Type.GetType("System.Int32"));
            dtDesglose.Columns.Add("nom1_farm", Type.GetType("System.String"));
            dtDesglose.Columns.Add("nom2_farm", Type.GetType("System.String"));
            dtDesglose.Columns.Add("nom1_cliente", Type.GetType("System.String"));
            dtDesglose.Columns.Add("nom2_cliente", Type.GetType("System.String"));
            dtDesglose.Columns.Add("precio", Type.GetType("System.Decimal"));
            dtDesglose.Columns.Add("cantidad", Type.GetType("System.Int32"));
            dtDesglose.Columns.Add("subtotal", Type.GetType("System.Decimal"));
            dtDesglose.Columns.Add("iva", Type.GetType("System.Decimal"));
            dtDesglose.Columns.Add("total", Type.GetType("System.Decimal"));
            dtDesglose.Columns.Add("RN", Type.GetType("System.Int32"));

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("FecIni", FecIni.ToString("dd/MM/yyyy 00:00:00"));
                        cmd.Parameters.Add("FecFin", FecFin.ToString("dd/MM/yyyy 23:59:59"));
                        cmd.Parameters.Add("IdCliente", IdCliente);
                        cmd.Parameters.Add("tVale", tipoVale);
                        cmd.Parameters.Add("nAnexo", nAnexo);
                        cmd.Parameters.Add("rIni", rIni);
                        cmd.Parameters.Add("rFin", rFin);

                        OracleParameter pConcentrado = new OracleParameter("Concentrado", OracleDbType.RefCursor);
                        pConcentrado.Direction = System.Data.ParameterDirection.Output;
                        cmd.Parameters.Add(pConcentrado);

                        OracleParameter pDesglose = new OracleParameter("Desglose", OracleDbType.RefCursor);
                        pDesglose.Direction = System.Data.ParameterDirection.Output;
                        cmd.Parameters.Add(pDesglose);


                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        OracleDataReader rConcentrado = ((OracleRefCursor)pConcentrado.Value).GetDataReader();
                        OracleDataReader rDesglose = ((OracleRefCursor)pDesglose.Value).GetDataReader();

                        if (rConcentrado.HasRows)
                        {
                            while (rConcentrado.Read())
                            {
                                DataRow row = ds.Tables["cs_issstep_concentrado"].NewRow();
                                row["RN"] = System.Convert.ToInt32(rConcentrado["rn"]);
                                row["anexo"] = System.Convert.ToString(rConcentrado["anexo"]);
                                row["tipo_vale"] = System.Convert.ToString(rConcentrado["tipo_vale"]);
                                row["cod_cliente"] = System.Convert.ToString(rConcentrado["cod_cliente"]);
                                row["nom1_farm"] = System.Convert.ToString(rConcentrado["nom1_farm"]);
                                row["nom1_cliente"] = System.Convert.ToString(rConcentrado["nom1_cliente"]);
                                row["precio"] = System.Convert.ToDecimal(rConcentrado["precio"]);
                                row["cantidad"] = System.Convert.ToInt32(rConcentrado["cantidad"]);
                                row["subtotal"] = System.Convert.ToDecimal(rConcentrado["subtotal"]);
                                row["iva"] = System.Convert.ToDecimal(rConcentrado["iva"]);
                                row["total"] = System.Convert.ToDecimal(rConcentrado["total"]);
                                row["nom_factura"] = System.Convert.ToString(rConcentrado["nom_factura"]);

                                ds.Tables["cs_issstep_concentrado"].Rows.Add(row);

                            }
                        }


                        if (rDesglose.HasRows)
                        {
                            while (rDesglose.Read())
                            {
                                DataRow row = ds.Tables["cs_issstep_desglose"].NewRow();
                                row["FECHA"] = System.Convert.ToDateTime(rDesglose["FECHA"]);
                                row["FECHA_VALE"] = System.Convert.ToDateTime(rDesglose["FECHA_VALE"]);
                                row["ANEXO"] = System.Convert.ToString(rDesglose["ANEXO"]);
                                row["TIPO_VALE"] = System.Convert.ToString(rDesglose["TIPO_VALE"]);
                                row["NUM_VALE"] = System.Convert.ToString(rDesglose["NUM_VALE"]);
                                row["CLIENTE_ID"] = System.Convert.ToInt32(rDesglose["CLIENTE_ID"]);
                                row["COD_CLIENTE"] = System.Convert.ToString(rDesglose["COD_CLIENTE"]);
                                row["NOM1_FARM"] = System.Convert.ToString(rDesglose["NOM1_FARM"]);
                                row["NOM2_FARM"] = System.Convert.ToString(rDesglose["NOM2_FARM"]);
                                row["NOM1_CLIENTE"] = System.Convert.ToString(rDesglose["NOM1_CLIENTE"]);
                                row["NOM2_CLIENTE"] = System.Convert.ToString(rDesglose["NOM2_CLIENTE"]);
                                row["PRECIO"] = System.Convert.ToDecimal(rDesglose["PRECIO"]);
                                row["CANTIDAD"] = System.Convert.ToInt32(rDesglose["CANTIDAD"]);
                                row["SUBTOTAL"] = System.Convert.ToDecimal(rDesglose["SUBTOTAL"]);
                                row["IVA"] = System.Convert.ToDecimal(rDesglose["IVA"]);
                                row["TOTAL"] = System.Convert.ToDecimal(rDesglose["TOTAL"]);
                                // row["RN"] = System.Convert.ToInt32(rDesglose["RN"]);

                                ds.Tables["cs_issstep_desglose"].Rows.Add(row);
                            }
                        }
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                }
                catch  { }
                finally {
                
                }
            }

            return ds;

        }

        #endregion ROMA 02SEP2013

        public static String insertaDatosParaFactura(
                         //int proveedorId,                 
                         String[] Clavedelproducto,
                         Decimal[] Piezas,
                         String[] Descripcion,
                         Decimal[] Costounitario,
                         Decimal[] Iva,                         
                         Decimal[] Precio_vta_unitario
                        

            )
        {
         
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_SUBROGACION.sp_insDatosParaFacturaSALUD";


                cmd.BindByName = true;

                OracleParameter InClavedelproducto = cmd.Parameters.Add("p_Clavedelproducto", OracleDbType.Varchar2);
                InClavedelproducto.Direction = ParameterDirection.Input;
                InClavedelproducto.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InClavedelproducto.Value = Clavedelproducto;

                OracleParameter InPiezas = cmd.Parameters.Add("p_Piezas", OracleDbType.Decimal);
                InPiezas.Direction = ParameterDirection.Input;
                InPiezas.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPiezas.Value = Piezas;

                OracleParameter InDescripcion = cmd.Parameters.Add("p_Descripcion", OracleDbType.Varchar2);
                InDescripcion.Direction = ParameterDirection.Input;
                InDescripcion.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InDescripcion.Value = Descripcion;

                OracleParameter InCostounitario = cmd.Parameters.Add("p_Costounitario", OracleDbType.Decimal);
                InCostounitario.Direction = ParameterDirection.Input;
                InCostounitario.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCostounitario.Value = Costounitario;

                
                OracleParameter InIva = cmd.Parameters.Add("p_Iva", OracleDbType.Decimal);
                InIva.Direction = ParameterDirection.Input;
                InIva.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InIva.Value = Iva;

                OracleParameter InPrecio_vta_unitario = cmd.Parameters.Add("p_Precio_vta_unitario", OracleDbType.Decimal);
                InPrecio_vta_unitario.Direction = ParameterDirection.Input;
                InPrecio_vta_unitario.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecio_vta_unitario.Value = Precio_vta_unitario;

                // OUT parameter
                OracleParameter pInsRespuesta =
                    cmd.Parameters.Add("OutParam", OracleDbType.Varchar2, ParameterDirection.Output);
                pInsRespuesta.Size = 1000;

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pInsRespuesta.Value.ToString()))
                {
                    return pInsRespuesta.Value.ToString();
                    //  MessageBox.Show("Se Cargo el catalogo", "Catalogo sub", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    return string.Empty;
                }
                
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al aplicar el ajuste: " + Environment.NewLine + ex.Message, "catalogo sub", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        public static String procesaGenCompratrasp_c(
                        int proveedorId,                 
                        string usuario_id

           )
        {

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_SUBROGACION.SP_GENCOMPRA_TRASP_C";
                cmd.BindByName = true;
                cmd.Parameters.Add("v_proveedor_P", OracleDbType.Decimal, proveedorId, ParameterDirection.Input);
                cmd.Parameters.Add("v_usuario_id_P", OracleDbType.Varchar2, usuario_id, ParameterDirection.Input);
                //cmd.Parameters.Add("p_cierratrasp", OracleDbType.Varchar2, cierraTrasp, ParameterDirection.Input);
                // OUT parameter
                OracleParameter pInsRespuesta =
                    cmd.Parameters.Add("v_respuesta_p", OracleDbType.Varchar2, ParameterDirection.Output);
                pInsRespuesta.Size = 1000;

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pInsRespuesta.Value.ToString()))
                {
                    return pInsRespuesta.Value.ToString();
                    //  MessageBox.Show("Se Cargo el catalogo", "Catalogo sub", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return string.Empty;
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al aplicar el ajuste: " + Environment.NewLine + ex.Message, "catalogo sub", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}
