using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using DevComponents.DotNetBar;
using System.IO;

namespace SIFDatos.Subrogacion
{
    public class Articulos
    {
        public static SIFModelo.SubRogacion.Sobrogacion Get(SIFModelo.SubRogacion.Sobrogacion ds ,int ClienteID)
        {
            String sentencia = "SELECT * FROM CAT_ARTICULOS_SUB where CLIENTE_ID = " + ClienteID.ToString(); // + " AND CAT_ARTICULOS_SUB.ACTIVO = 'S'"; //

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    ds.CAT_ARTICULOS_SUB.Constraints.Clear();
                    da.Fill(ds, "CAT_ARTICULOS_SUB");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }
            }
            ds.CAT_ARTICULOS_SUB.FECHA_FINColumn.DefaultValue = DateTime.Now;
            return ds;
        }

        public static List<Tuple<string, DateTime, DateTime, int?>> GetOverlappingArticles(int clienteId, int? institucionId, IEnumerable<string> articuloIds, DateTime newInicio, DateTime newFin)
        {
            var result = new List<Tuple<string, DateTime, DateTime, int?>>();

            if (articuloIds == null) return result;
            var ids = articuloIds.Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => s.Trim()).Distinct().ToList();
            if (ids.Count == 0) return result;

            // Build IN clause safely by escaping single quotes
            //string inClause = string.Join(",", ids.Select(a => "'" + a.Replace("'", "''") + "'"));
            int chunkSize = 800;
            var chunks = ids
                .Select((id, index) => new { id, index })
                .GroupBy(x => x.index / chunkSize)
                .Select(g => g.Select(x => "'" + x.id.Replace("'", "''") + "'"));

            var inClauses = chunks.Select(c => "ARTICULO_ID IN (" + string.Join(",", c) + ")");
            string inCondition = "(" + string.Join(" OR ", inClauses) + ")";

            using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                conn.Open();
                using (OracleCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    // Treat INSTITUCION_ID = 0 or NULL as no-institution to support legacy rows
                    cmd.CommandText = "SELECT ARTICULO_ID, FECHA_INI, FECHA_FIN, INSTITUCION_ID FROM CAT_ARTICULOS_SUB " +
                                      "WHERE CLIENTE_ID = :clienteId AND " + inCondition + " AND ACTIVO = 'S' " +
                                      "AND :pInicio <= FECHA_FIN AND FECHA_INI <= :pFin " +
                                      "AND ( ( :pInst IS NULL AND (INSTITUCION_ID IS NULL OR INSTITUCION_ID = 0) ) OR INSTITUCION_ID = :pInst )";

                    cmd.Parameters.Add(new OracleParameter("clienteId", OracleDbType.Decimal)).Value = clienteId;
                    var pInicio = new OracleParameter("pInicio", OracleDbType.Date);
                    pInicio.Value = newInicio;
                    cmd.Parameters.Add(pInicio);
                    var pFin = new OracleParameter("pFin", OracleDbType.Date);
                    pFin.Value = newFin;
                    cmd.Parameters.Add(pFin);

                    var pInst = new OracleParameter("pInst", OracleDbType.Decimal);
                    if (institucionId.HasValue)
                        pInst.Value = institucionId.Value;
                    else
                        pInst.Value = DBNull.Value;
                    cmd.Parameters.Add(pInst);

                    using (OracleDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string art = rdr.IsDBNull(0) ? string.Empty : rdr.GetString(0);
                            DateTime fi = rdr.IsDBNull(1) ? DateTime.MinValue : rdr.GetDateTime(1);
                            DateTime ff = rdr.IsDBNull(2) ? DateTime.MinValue : rdr.GetDateTime(2);
                            int? inst = null;
                            if (!rdr.IsDBNull(3))
                            {
                                try {
                                    var dec = rdr.GetDecimal(3);
                                    int val = Convert.ToInt32(dec);
                                    if (val != 0) inst = val;
                                    else inst = null;
                                } catch { inst = null; }
                            }
                            result.Add(Tuple.Create(art, fi, ff, inst));
                        }
                    }
                }
                conn.Close();
            }

            return result;
        }

        public static Dictionary<int?, int> GetCountsByClient(int clienteId)
        {
            var result = new Dictionary<int?, int>();
            using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                conn.Open();
                using (OracleCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT INSTITUCION_ID, COUNT(*) CNT FROM CAT_ARTICULOS_SUB WHERE CLIENTE_ID = :clienteId GROUP BY INSTITUCION_ID";
                    cmd.Parameters.Add(new OracleParameter("clienteId", OracleDbType.Decimal)).Value = clienteId;
                    using (OracleDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int? inst = null;
                            if (!rdr.IsDBNull(0))
                                inst = Convert.ToInt32(rdr.GetDecimal(0));
                            int cnt = Convert.ToInt32(rdr.GetDecimal(1));
                            result[inst] = cnt;
                        }
                    }
                }
                conn.Close();
            }
            return result;
        }

        public static SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow Get(String Articulo_ID, int ClienteID)
        {
            String sentencia = "SELECT * FROM CAT_ARTICULOS_SUB where CLIENTE_ID=" + ClienteID.ToString() + " and CODIGOCLI='" + Articulo_ID + "' AND CAT_ARTICULOS_SUB.ACTIVO = 'S'"; //

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                   
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    SIFModelo.SubRogacion.Sobrogacion ds=new SIFModelo.SubRogacion.Sobrogacion();
                    da.Fill(ds, "CAT_ARTICULOS_SUB");
                    if (ds.CAT_ARTICULOS_SUB.Rows.Count > 0)
                    {
                        ds.CAT_ARTICULOS_SUB.FECHA_FINColumn.DefaultValue = DateTime.Now;
                        return ds.CAT_ARTICULOS_SUB.First();
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }
            return null;

        }

        public static SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow GetArticuloSubID(String Articulo_ID, String ArticulosSub_ID, int ClienteID)
        {
            String sentencia = "SELECT * FROM CAT_ARTICULOS_SUB where CLIENTE_ID=" + ClienteID.ToString() + " and ARTICULO_ID='" + Articulo_ID + "' AND CODIGOCLI = '" + ArticulosSub_ID + "' AND CAT_ARTICULOS_SUB.ACTIVO = 'S'"; //

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {

                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    SIFModelo.SubRogacion.Sobrogacion ds = new SIFModelo.SubRogacion.Sobrogacion();
                    da.Fill(ds, "CAT_ARTICULOS_SUB");
                    if (ds.CAT_ARTICULOS_SUB.Rows.Count > 0)
                    {
                        ds.CAT_ARTICULOS_SUB.FECHA_FINColumn.DefaultValue = DateTime.Now;
                        return ds.CAT_ARTICULOS_SUB.First();
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }
            return null;

        }


        public static SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow GetArticuloID(String Articulo_ID, int ClienteID)
        {
            String sentencia = "SELECT * FROM CAT_ARTICULOS_SUB where CLIENTE_ID=" + ClienteID.ToString() + " and ARTICULO_ID='" + Articulo_ID + "' AND CAT_ARTICULOS_SUB.ACTIVO = 'S'"; //

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {

                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    SIFModelo.SubRogacion.Sobrogacion ds = new SIFModelo.SubRogacion.Sobrogacion();
                    da.Fill(ds, "CAT_ARTICULOS_SUB");
                    if (ds.CAT_ARTICULOS_SUB.Rows.Count > 0)
                    {
                        ds.CAT_ARTICULOS_SUB.FECHA_FINColumn.DefaultValue = DateTime.Now;
                        return ds.CAT_ARTICULOS_SUB.First();
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }
            return null;

        }

        public static SIFModelo.SubRogacion.Sobrogacion Update(SIFModelo.SubRogacion.Sobrogacion ds)
        {
            // ds.AcceptChanges();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                
                SIFModelo.SubRogacion.SobrogacionTableAdapters.CAT_ARTICULOS_SUBTableAdapter Tb = new SIFModelo.SubRogacion.SobrogacionTableAdapters.CAT_ARTICULOS_SUBTableAdapter();
                
                Tb.Connection.ConnectionString = cnx.ConnectionString;
                Tb.Update(ds.CAT_ARTICULOS_SUB);
                
            }
            return ds;

        }


        public static string Delete(String ClienteID, string userId, int? institucionId = null)
        {
            //int deleted = 0;
            //using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
            //{
            //    conn.Open();

            //    using (OracleCommand cmd = conn.CreateCommand())
            //    {
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandType = CommandType.Text;
            //if (institucionId.HasValue)
            //{
            //    cmd.CommandText = "DELETE FROM CAT_ARTICULOS_SUB WHERE CLIENTE_ID = :clienteId AND INSTITUCION_ID = :instId";
            //    cmd.Parameters.Add(new OracleParameter("clienteId", OracleDbType.Decimal)).Value = int.Parse(ClienteID);
            //    cmd.Parameters.Add(new OracleParameter("instId", OracleDbType.Decimal)).Value = institucionId.Value;
            //}
            //else
            //{
            //    cmd.CommandText = "DELETE FROM CAT_ARTICULOS_SUB WHERE CLIENTE_ID = :clienteId";
            //    cmd.Parameters.Add(new OracleParameter("clienteId", OracleDbType.Decimal)).Value = int.Parse(ClienteID);
            //}

            //deleted = cmd.ExecuteNonQuery();

            //    }

            //    conn.Close();
            //    conn.Dispose();
            //    //OracleConnection.ClearPool(conn);
            //}

            //return deleted;
            string resultado = "";

            using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                conn.Open();

                using (OracleCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_SUBROGACION.sp_EliminaCatalogoSub";
                    // clienteid
                    cmd.Parameters.Add("clienteid", OracleDbType.Decimal).Value = int.Parse(ClienteID);
                    // institucion
                    cmd.Parameters.Add("p_institucion_id", OracleDbType.Decimal).Value = institucionId.HasValue ? (object)institucionId : "0";
                    // usuario
                    cmd.Parameters.Add("p_userid", OracleDbType.Decimal).Value = decimal.Parse(userId);
                    // equipo
                    cmd.Parameters.Add("p_nombre_equipo", OracleDbType.Varchar2).Value = Environment.MachineName.ToString();
                    // OUTPARAM
                    OracleParameter outParam = new OracleParameter("outparam", OracleDbType.Varchar2, 4000);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    cmd.ExecuteNonQuery();

                    resultado = outParam.Value?.ToString();
                }
                conn.Close();
            }

            return resultado;
        }
        public static SIFModelo.SubRogacion.Sobrogacion insert(SIFModelo.SubRogacion.Sobrogacion ds)
        {

            using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                int ClienteID=0;
                String[] artiId = new string[ds.CAT_ARTICULOS_SUB.Rows.Count];
                String[] nombre1 = new string[ds.CAT_ARTICULOS_SUB.Rows.Count];
                String[] nombre2 = new string[ds.CAT_ARTICULOS_SUB.Rows.Count];
                String[] tipomedcve = new string[ds.CAT_ARTICULOS_SUB.Rows.Count];
                String[] laboratorioid = new string[ds.CAT_ARTICULOS_SUB.Rows.Count];
                String[] proveedorID = new string[ds.CAT_ARTICULOS_SUB.Rows.Count];
                String[] ucompra = new string[ds.CAT_ARTICULOS_SUB.Rows.Count];
                String[] uventa = new string[ds.CAT_ARTICULOS_SUB.Rows.Count];
                String[] panex = new string[ds.CAT_ARTICULOS_SUB.Rows.Count];
                String[] paqt = new string[ds.CAT_ARTICULOS_SUB.Rows.Count];
                String[] codigocli = new string[ds.CAT_ARTICULOS_SUB.Rows.Count]; 
                double[] precio= new double[ds.CAT_ARTICULOS_SUB.Rows.Count]; 
                String[] tipodesc = new string[ds.CAT_ARTICULOS_SUB.Rows.Count];
                String[] fechaini = new string[ds.CAT_ARTICULOS_SUB.Rows.Count];
                String[] fechafin = new string[ds.CAT_ARTICULOS_SUB.Rows.Count];
                String[] tipomedcli = new string[ds.CAT_ARTICULOS_SUB.Rows.Count]; 
                double[] porcostp= new double[ds.CAT_ARTICULOS_SUB.Rows.Count];
                double[] pordesprecio = new double[ds.CAT_ARTICULOS_SUB.Rows.Count]; 
                
                int ind=0;

                foreach (SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow Reg in ds.CAT_ARTICULOS_SUB)
                {
                    //llenamos el store procedure
                     ClienteID = Reg.CLIENTE_ID;
                     artiId[ind]=Reg.ARTICULO_ID;
                     nombre1[ind]=Reg.NOMBRE1;
                     nombre2[ind]=Reg.NOMBRE2;
                     if ((Reg.TIPO_MEDICAMENTO_CVE != null) & (Reg.TIPO_MEDICAMENTO_CVE.Length>0))
                     tipomedcve[ind] = Reg.TIPO_MEDICAMENTO_CVE;
                     else
                     tipomedcve[ind] = "-";

                     laboratorioid[ind]=Reg.LABORATORIO_ID.ToString();
                     proveedorID[ind]=Reg.PROVEEDOR_ID.ToString();
                     ucompra[ind]=Reg.U_COMPRA;
                     uventa[ind]=Reg.U_VENTA;
                     panex[ind]=Reg.ANEXO;
                     paqt[ind]=Reg.PAQUETE;
                     codigocli[ind]=Reg.CODIGOCLI;
                     precio[ind]=Reg.PRECIO;
                     tipodesc[ind]=Reg.TIPO_DESC;
                     fechaini[ind]=Reg.FECHA_INI.ToString("dd/MM/yyyy HH:mm:ss");
                     fechafin[ind] = Reg.FECHA_FIN.ToString("dd/MM/yyyy HH:mm:ss");
                     tipomedcli[ind]=Reg.TIPO_MEDICAMENTO_CVE;
                     porcostp[ind]=Reg.POR_COSTO;
                     pordesprecio[ind]=Reg.POR_DESC_PRECIO;
                     
                     ind++;

                }

                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_SUBROGACION.sp_insCatalogoSub";
                cmd.BindByName = true;

                cmd.Parameters.Add("clienteID", OracleDbType.Int32, ClienteID, ParameterDirection.Input);

                // Input Array Lote
                OracleParameter InArtID = cmd.Parameters.Add("artiId", OracleDbType.Varchar2);
                InArtID.Direction = ParameterDirection.Input;
                InArtID.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InArtID.Value = artiId;

                // Input Array Sec
                OracleParameter InNombre1 = cmd.Parameters.Add("nombre1", OracleDbType.Varchar2);
                InNombre1.Direction = ParameterDirection.Input;
                InNombre1.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InNombre1.Value = nombre1;

                // IN Array ID's
                OracleParameter InNombre2 = cmd.Parameters.Add("nombre2", OracleDbType.Varchar2);
                InNombre2.Direction = ParameterDirection.Input;
                InNombre2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InNombre2.Value = nombre2;

                // IN Array Articulos
                OracleParameter Intipomedcve = cmd.Parameters.Add("tipomedcve", OracleDbType.Varchar2);
                Intipomedcve.Direction = ParameterDirection.Input;
                Intipomedcve.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                Intipomedcve.Value = tipomedcve;

                // IN Array Concepto
                OracleParameter InLaboratorioid = cmd.Parameters.Add("laboratorioid", OracleDbType.Varchar2);
                InLaboratorioid.Direction = ParameterDirection.Input;
                InLaboratorioid.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InLaboratorioid.Value = laboratorioid;

                // IN Array Cantidad
                OracleParameter InProveedorID = cmd.Parameters.Add("proveedorID", OracleDbType.Varchar2);
                InProveedorID.Direction = ParameterDirection.Input;
                InProveedorID.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InProveedorID.Value = proveedorID;

                // IN Array Total Lote
                OracleParameter Inucompra = cmd.Parameters.Add("ucompra", OracleDbType.Varchar2);
                Inucompra.Direction = ParameterDirection.Input;
                Inucompra.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                Inucompra.Value = ucompra;

                // IN Array Precio
                OracleParameter InUventa = cmd.Parameters.Add("uventa", OracleDbType.Varchar2);
                InUventa.Direction = ParameterDirection.Input;
                InUventa.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InUventa.Value = uventa;

                // IN Array Precio Venta
                OracleParameter InPanex = cmd.Parameters.Add("panex", OracleDbType.Varchar2);
                InPanex.Direction = ParameterDirection.Input;
                InPanex.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPanex.Value = panex;

                // IN Array Precio Venta
                OracleParameter InPaqt = cmd.Parameters.Add("paqt", OracleDbType.Varchar2);
                InPaqt.Direction = ParameterDirection.Input;
                InPaqt.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPaqt.Value = paqt;

                // IN Array Precio Venta
                OracleParameter InCodigocli = cmd.Parameters.Add("codigocli", OracleDbType.Varchar2);
                InCodigocli.Direction = ParameterDirection.Input;
                InCodigocli.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCodigocli.Value = codigocli;

                // IN Array Precio Venta
                OracleParameter InPrecio = cmd.Parameters.Add("precio", OracleDbType.Decimal);
                InPrecio.Direction = ParameterDirection.Input;
                InPrecio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecio.Value = precio;


                OracleParameter InTipodesc = cmd.Parameters.Add("tipodesc", OracleDbType.Varchar2);
                InTipodesc.Direction = ParameterDirection.Input;
                InTipodesc.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InTipodesc.Value = tipodesc;

                OracleParameter InFechaini = cmd.Parameters.Add("fechaini", OracleDbType.Varchar2);
                InFechaini.Direction = ParameterDirection.Input;
                InFechaini.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InFechaini.Value = fechaini;

                

                OracleParameter InFechafin = cmd.Parameters.Add("fechafin", OracleDbType.Varchar2);
                InFechafin.Direction = ParameterDirection.Input;
                InFechafin.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InFechafin.Value = fechafin;

                OracleParameter Intipomedcli = cmd.Parameters.Add("tipomedcli", OracleDbType.Varchar2);
                Intipomedcli.Direction = ParameterDirection.Input;
                Intipomedcli.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                Intipomedcli.Value = tipomedcli;

                OracleParameter Intporcostp = cmd.Parameters.Add("porcostp", OracleDbType.Decimal);
                Intporcostp.Direction = ParameterDirection.Input;
                Intporcostp.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                Intporcostp.Value = porcostp;

                OracleParameter Intpordesprecio = cmd.Parameters.Add("pordesprecio", OracleDbType.Decimal);
                Intpordesprecio.Direction = ParameterDirection.Input;
                Intpordesprecio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                Intpordesprecio.Value = pordesprecio;

               

                // Execute the command
                cmd.ExecuteNonQuery();


                conn.Close();
                conn.Dispose();
               //OracleConnection.ClearPool(conn);

            }
            return ds;

        }

        public static SIFModelo.SubRogacion.Sobrogacion Get(SIFModelo.SubRogacion.Sobrogacion ds, int ClienteID, string CodigoCliente)
        {
            String sentencia = "SELECT * FROM CAT_ARTICULOS_SUB where CLIENTE_ID = " + ClienteID.ToString() + " AND CODIGOCLI= '" +CodigoCliente  + "' AND CAT_ARTICULOS_SUB.ACTIVO = 'S'"; //

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    ds.CAT_ARTICULOS_SUB.Constraints.Clear();
                    da.Fill(ds, "CAT_ARTICULOS_SUB");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }
            ds.CAT_ARTICULOS_SUB.FECHA_FINColumn.DefaultValue = DateTime.Now;
            return ds;

        }


        public static SIFModelo.SubRogacion.Sobrogacion Get(SIFModelo.SubRogacion.Sobrogacion ds, string CodigoArticulo, int ClienteID)
        {
            String sentencia = "SELECT * FROM CAT_ARTICULOS_SUB where CLIENTE_ID = " + ClienteID.ToString() + " AND ARTICULO_ID= '" + CodigoArticulo + "' AND CAT_ARTICULOS_SUB.ACTIVO = 'S'"; //

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    ds.CAT_ARTICULOS_SUB.Constraints.Clear();
                    da.Fill(ds, "CAT_ARTICULOS_SUB");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }
            ds.CAT_ARTICULOS_SUB.FECHA_FINColumn.DefaultValue = DateTime.Now;
            return ds;
        }

        public static SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow GetArticuloSubID(string ArticuloSub_ID, int ClienteID)
        {
            String sentencia = "SELECT * FROM CAT_ARTICULOS_SUB where CLIENTE_ID=" + ClienteID.ToString() + " AND ID = '" + ArticuloSub_ID + "'"; //

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {

                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    SIFModelo.SubRogacion.Sobrogacion ds = new SIFModelo.SubRogacion.Sobrogacion();
                    da.Fill(ds, "CAT_ARTICULOS_SUB");
                    if (ds.CAT_ARTICULOS_SUB.Rows.Count > 0)
                    {
                        ds.CAT_ARTICULOS_SUB.FECHA_FINColumn.DefaultValue = DateTime.Now;
                        return ds.CAT_ARTICULOS_SUB.First();
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }
            return null;
        }


        public static String insertaCatalogoSubImp(
            int cliente,
            String[] Clave,
            Decimal[] Precio,
            //string fechaInicio,
            //string fechaFin,
            string name_file,
            string usuario,
            int? institucionId
            )
        {

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_SUBROGACION.sp_insCatalogoSubImp";


                cmd.BindByName = true;

                cmd.Parameters.Add("p_clienteID", OracleDbType.Decimal, cliente, ParameterDirection.Input);

                OracleParameter InArtId = cmd.Parameters.Add("p_Ean ", OracleDbType.Varchar2);
                InArtId.Direction = ParameterDirection.Input;
                InArtId.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InArtId.Value = Clave;
              
                OracleParameter InPrecio = cmd.Parameters.Add("p_Precio ", OracleDbType.Decimal);
                InPrecio.Direction = ParameterDirection.Input;
                InPrecio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecio.Value = Precio;

                
                cmd.Parameters.Add("p_institucion_id", OracleDbType.Int32, institucionId, ParameterDirection.Input);
                //cmd.Parameters.Add("p_fecha_inicio", OracleDbType.Varchar2, fechaInicio, ParameterDirection.Input);
                //cmd.Parameters.Add("p_fecha_fin", OracleDbType.Varchar2, fechaFin, ParameterDirection.Input);

                cmd.Parameters.Add("p_nom_archivo", OracleDbType.Varchar2, name_file.ToString(), ParameterDirection.Input);
                //cmd.Parameters.Add("p_userid", OracleDbType.Int32).Value = usuario;
                cmd.Parameters.Add("p_userid", OracleDbType.Decimal, decimal.Parse(usuario), ParameterDirection.Input);

                cmd.Parameters.Add("p_nombre_equipo", OracleDbType.Varchar2,  Environment.MachineName.ToString(), ParameterDirection.Input);

                OracleParameter outparam = new OracleParameter("outparam",OracleDbType.Varchar2,1000);
                outparam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outparam);

                OracleParameter outparam_valor = new OracleParameter("outparam_valor", OracleDbType.Int32);
                outparam_valor.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outparam_valor);

                OracleParameter p_cursor = new OracleParameter("p_cursor", OracleDbType.RefCursor);
                p_cursor.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(p_cursor);
                               

                // Execute the command
                cmd.ExecuteNonQuery();
                OracleDataReader _rdrObj1 = cmd.ExecuteReader();

                if (!outparam_valor.Value.ToString().IsIntegerPositive())
                {
                    MessageBox.Show(outparam.Value.ToString(), "Error en articulos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (MessageBox.Show("¿Desea guardar los datos?", "Información",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();

                        sfd.Title = "Guardar códigos inválidos";
                        sfd.Filter = "Archivo CSV (*.csv)|*.csv|Archivo de texto (*.txt)|*.txt";
                        sfd.DefaultExt = "csv";
                        sfd.AddExtension = true;
                        sfd.FileName = "codigos_invalidos.csv";

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            string ruta = sfd.FileName;

                            try
                            {                               
                                using (StreamWriter sw = new StreamWriter(ruta,true,Encoding.UTF8))
                                {
                                    // Encabezado del archivo
                                    sw.WriteLine("CODIGOS_INVALIDOS");

                                    // Leer registros del cursor
                                    while (_rdrObj1.Read())
                                    {
                                        if (!_rdrObj1.IsDBNull(0))
                                        {
                                            string codigo = _rdrObj1.GetValue(0).ToString();
                                            sw.WriteLine(codigo);
                                        }
                                    }

                                    // Forzar que todo lo pendiente se escriba
                                    sw.Flush();
                                }

                                // Cerrar el reader DESPUÉS de terminar de escribir
                                _rdrObj1.Close();

                                MessageBox.Show("Archivo guardado correctamente en:\n\n" + ruta,"Éxito",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al guardar el archivo:\n\n" +ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }
                        }
                    }
                }


                if (!string.IsNullOrEmpty(outparam.Value.ToString()))
                {
                    MessageBox.Show("Se Cargo el catalogo", "Catalogo sub", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return outparam.Value.ToString();
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
                }
            }
        }
        public static String sp_insCatalogoSubImp3012(
            int cliente,
            string usuarioid,
            String[] Clave,
            String[] ClaveGob,
            String[] Isss,
            Decimal[] Precio,
            String[] tipo,
            //string fechaInicio,
            //string fechaFin,
            string agregar)
            {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_SUBROGACION.sp_insCatalogoSubImp3012";


                cmd.BindByName = true;

                cmd.Parameters.Add("clienteID", OracleDbType.Decimal, cliente, ParameterDirection.Input);
                cmd.Parameters.Add("Agregar", OracleDbType.Varchar2, agregar, ParameterDirection.Input);

                OracleParameter InArtId = cmd.Parameters.Add("Ean", OracleDbType.Varchar2);
                InArtId.Direction = ParameterDirection.Input;
                InArtId.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InArtId.Value = Clave;

                OracleParameter InPrecio = cmd.Parameters.Add("Precio", OracleDbType.Double);
                InPrecio.Direction = ParameterDirection.Input;
                InPrecio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecio.Value = Precio;

                OracleParameter InClavegob = cmd.Parameters.Add("Clavegob", OracleDbType.Varchar2);
                InClavegob.Direction = ParameterDirection.Input;
                InClavegob.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InClavegob.Value = ClaveGob;

                OracleParameter InIsss = cmd.Parameters.Add("Isss", OracleDbType.Varchar2);
                InIsss.Direction = ParameterDirection.Input;
                InIsss.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InIsss.Value = Isss;

                OracleParameter InTipo = cmd.Parameters.Add("tipo", OracleDbType.Varchar2);
                InTipo.Direction = ParameterDirection.Input;
                InTipo.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InTipo.Value = tipo;

                //cmd.Parameters.Add("p_fecha_inicio",OracleDbType.Varchar2,fechaInicio,ParameterDirection.Input);
                //cmd.Parameters.Add("p_fecha_fin",OracleDbType.Varchar2,fechaFin,ParameterDirection.Input);

                OracleParameter pInsCatalogo =
                    cmd.Parameters.Add("OutParam", OracleDbType.Varchar2, ParameterDirection.Output);
                pInsCatalogo.Size = 1000;
                
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pInsCatalogo.Value.ToString()))
                {
                    MessageBox.Show("Se Cargo el catalogo", "Catalogo sub", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return pInsCatalogo.Value.ToString();
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
                }
            }
        }

        public static List<SIFModelo.SubRogacion.CatalogoConvenio> GetCatalogosMes(int? ClienteID = null)
        {
            List<SIFModelo.SubRogacion.CatalogoConvenio> lista = new List<SIFModelo.SubRogacion.CatalogoConvenio>();

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                // 1. Asignamos el nombre del Stored Procedure
                using (OracleCommand cmd = new OracleCommand("PKG_SUBROGACION.sp_obtienecatalogoSub", cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    // 2. Parámetro IN: p_cliente_id
                    cmd.Parameters.Add("p_cliente_id", OracleDbType.Int32).Value = ClienteID.HasValue
                        ? (object)ClienteID.Value
                        : DBNull.Value;

                    // 3. Parámetro OUT: p_cursor (SYS_REFCURSOR)
                    cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;

                    cnx.Open();

                    // 4. Ejecutamos el reader que consumirá el cursor devuelto
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SIFModelo.SubRogacion.CatalogoConvenio item = new SIFModelo.SubRogacion.CatalogoConvenio();

                            // Mapeo adaptado a las columnas que regresa el Stored Procedure
                            item.ClienteId = reader["CLIENTE_ID"] != DBNull.Value ? Convert.ToInt32(reader["CLIENTE_ID"]) : 0;
                            item.Nombre_cliente = reader["CLIENTE_NOMBRE"]?.ToString() ?? string.Empty;
                            item.Nombre_Institucion = reader["INSTITUCION_NOMBRE"]?.ToString() ?? string.Empty;

                            // El campo MES ahora viene en formato 'MM/YYYY' (ej: "09/2026")
                            item.Mes_texto = reader["MES"]?.ToString() ?? string.Empty;

                            // Si tu modelo requiere un entero para el mes, se extrae del valor 'MM/YYYY'
                            if (!string.IsNullOrEmpty(item.Mes_texto) && item.Mes_texto.Contains("/"))
                            {
                                int.TryParse(item.Mes_texto.Split('/')[0], out int numMes);
                                item.Mes = numMes;
                            }

                            lista.Add(item);
                        }
                    }
                }
            }

            return lista;
        }


    }
}
