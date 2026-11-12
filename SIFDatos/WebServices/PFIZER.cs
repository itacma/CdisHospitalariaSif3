using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace SIFDatos.WebServices
{
    public class PFIZER
    {
        public static void UpdPfizer(string Ope, string Cotizacion, string Confirmación)
        {
            string BD = "SIF";
            string OraGAC = Helpers.ConnectionString.Connection();
            OracleConnection conn = new OracleConnection(OraGAC);

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PFIZER.SP_UPD_PFIZER";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pCFDI = cmd.Parameters.Add("outparam", OracleDbType.Decimal, ParameterDirection.Output);
                if (Ope == "C")
                    cmd.Parameters.Add("ope", OracleDbType.Char, 'C', ParameterDirection.Input);
                else
                    cmd.Parameters.Add("ope", OracleDbType.Char, 'X', ParameterDirection.Input);
                cmd.Parameters.Add("cotizacion", OracleDbType.Varchar2, Cotizacion, ParameterDirection.Input);
                cmd.Parameters.Add("confirmacion", OracleDbType.Varchar2, Confirmación, ParameterDirection.Input);

                // Execute the command
                cmd.ExecuteNonQuery();

                //if (Ope == "C")
                    //throw new Exception(" - La compra de Cerro");
                //else
                    //throw new Exception(pCFDI.Value.ToString() + " - La compra de Cancelo");

                //tb_ConfirmacionId.Text = Confirmación;
            }
            catch (OracleException Oex)
            {
                switch (Oex.Number)
                {
                    case 1:
                        throw new Exception("Error intentando insertar datos duplicados" + Environment.NewLine);
                        break;
                    case 12545:
                        throw new Exception("La base de datos NO esta disponible" + Environment.NewLine);
                        break;
                    default:
                        throw new Exception("Database error:" + System.Environment.NewLine + Oex.ToString());
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + Environment.NewLine + ex.Message);
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

        public static void InsPfizer(SIFModelo.WebServices.TarjetaPfizer Tarjeta, List<SIFModelo.RemisionDetalle> detalles, SIFModelo.Remision remision, SIFModelo.Configuracion.Pfizer pfizerConfig)
        {
            // Example demonstrates how to use REF CURSORs returned from
            // PL/SQL Stored Procedures or Functions
            // XMLTYPE

            string OraGAC = Helpers.ConnectionString.Connection();
            OracleConnection conn = new OracleConnection(OraGAC);

            Random r = new Random();

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PFIZER.SP_INS_CTL_PFIZER";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pFizer = cmd.Parameters.Add("outparam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("num_remision", OracleDbType.Char, remision.NumeroRemision, ParameterDirection.Input);
                cmd.Parameters.Add("cadena", OracleDbType.Int16, pfizerConfig.Cadena, ParameterDirection.Input);
                cmd.Parameters.Add("sucursal", OracleDbType.Int16, pfizerConfig.Sucursal, ParameterDirection.Input);
                cmd.Parameters.Add("tarjeta", OracleDbType.Decimal, Tarjeta.TarjetaID, ParameterDirection.Input);
                cmd.Parameters.Add("cotizacion", OracleDbType.Varchar2, Tarjeta.SesionID, ParameterDirection.Input);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (Convert.ToDecimal(pFizer.Value.ToString()) == 1)
                {
                    // Graba Detalle
                    cmd.Parameters.Clear();
                    cmd.CommandText = "PKG_PFIZER.SP_INS_ALL_PFIZER";
                    cmd.BindByName = true;
                    // IN ARRAY PARAMETERS
                    OracleParameter pCotiza = cmd.Parameters.Add("Cotizacion", OracleDbType.Varchar2);
                    pCotiza.Direction = ParameterDirection.Input;
                    pCotiza.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter pSku = cmd.Parameters.Add("Sku", OracleDbType.Varchar2);
                    pSku.Direction = ParameterDirection.Input;
                    pSku.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter pCompra = cmd.Parameters.Add("Compras", OracleDbType.Decimal);
                    pCompra.Direction = ParameterDirection.Input;
                    pCompra.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter pBeneficio = cmd.Parameters.Add("Beneficio", OracleDbType.Decimal);
                    pBeneficio.Direction = ParameterDirection.Input;
                    pBeneficio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    OracleParameter pSugerido = cmd.Parameters.Add("Sugerido", OracleDbType.Decimal);
                    pSugerido.Direction = ParameterDirection.Input;
                    pSugerido.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    // Init Arrasy
                    string[] Cotiza = new string[detalles.Count];
                    string[] Sku = new string[detalles.Count];
                    Decimal[] Compra = new Decimal[detalles.Count];
                    Decimal[] Benefi = new Decimal[detalles.Count];
                    Decimal[] Sugeri = new Decimal[detalles.Count];

                    int iPed = 0;

                    foreach (SIFModelo.RemisionDetalle row in detalles)
                    {
                        Cotiza[iPed] = Tarjeta.SesionID;
                        Sku[iPed] = row.ArticuloID;
                        Compra[iPed] = row.CantidadRemision;
                        Benefi[iPed] = row.PiezasGratis;
                        Sugeri[iPed] = row.PiezasAcumuladas;
                        iPed++;
                    }

                    pCotiza.Value = Cotiza;
                    //cmd.Parameters.Add(pCotiza);
                    pSku.Value = Sku;
                    //cmd.Parameters.Add(pSku);
                    pCompra.Value = Compra;
                    //cmd.Parameters.Add(pCompra);
                    pBeneficio.Value = Benefi;
                    //cmd.Parameters.Add(pBeneficio);
                    pSugerido.Value = Sugeri;
                    //cmd.Parameters.Add(pSugerido);

                    cmd.ExecuteNonQuery();

                }
                else
                    throw new Exception("Error: " + pFizer.Value.ToString());

            }
            catch (OracleException Oex)
            {
                switch (Oex.Number)
                {
                    case 1:
                        throw new Exception("Error intentando insertar datos duplicados");
                        break;
                    case 12545:
                        throw new Exception("La base de datos NO esta disponible");
                        break;
                    default:
                        return;
                        throw new Exception("Database error:" + System.Environment.NewLine + Oex.ToString());
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + Environment.NewLine + ex.Message);
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


        public static SIFModelo.WebServices.PfizerControl ControlPfizer(SIFModelo.Remision remision)
        {
            string sentencia = "SELECT * FROM CTL_PFIZER WHERE NO_REMISION = :NumeroRemision";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //Parametros
                    cmd.Parameters.Add("NumeroRemision", remision.NumeroRemision);

                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.WebServices.PfizerControl registro = new SIFModelo.WebServices.PfizerControl();

                            registro.ACTIVO = (SIFModelo.Tipos.SiNo)(oreader["ACTIVO"].ToString()[0]);
                            registro.CADENA_ID = int.Parse(oreader["CADENA_ID"].ToString());
                            registro.SUCURSAL_ID = int.Parse(oreader["SUCURSAL_ID"].ToString());
                            registro.USUARIO_ID = oreader["USUARIO_ID"].ToString();
                            registro.NO_TARJETA = oreader["NO_TARJETA"].ToString();
                            registro.COTIZACION_ID = oreader["COTIZACION_ID"].ToString();
                            registro.FECHA_COMPRA = DateTime.Parse(oreader["FECHA_COMPRA"].ToString());
                            registro.NO_CONFIRMACION = oreader["NO_CONFIRMACION"].ToString();
                            var fechaConfirmacion = oreader["FECHA_CONFIRMACION"];
                            if (fechaConfirmacion.ToString().IsDatetime())
                            {
                                registro.FECHA_CONFIRMACION = DateTime.Parse(oreader["FECHA_CONFIRMACION"].ToString());
                            }

                            return registro;
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);
                }

            }
            return null;
        }
    }
}
