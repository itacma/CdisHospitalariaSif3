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
    public class AjustesAlmacen
    {
        public static SIFModelo.Inventarios.InventarioDataSet GetAjustes(string Ini, string Fin, String Activo, String Folio)
        {

            SIFModelo.Inventarios.InventarioDataSet DsInventario = new SIFModelo.Inventarios.InventarioDataSet();


            Cursor.Current = Cursors.WaitCursor;

            //   int nRow = 1, ind = 0;

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand

                OracleCommand cmd = conn.CreateCommand();
                if (Folio == "")
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_INVENTARIOS.sp_get_ajustes";
                    cmd.BindByName = true;

                    // OUT REF CURSOR bound
                    OracleParameter pPedido = cmd.Parameters.Add("Hdr", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.Parameters.Add("FecIni", OracleDbType.Varchar2, Ini, ParameterDirection.Input);
                    cmd.Parameters.Add("FecFin", OracleDbType.Varchar2, Fin, ParameterDirection.Input);
                }
                else
                {
                    cmd.CommandText = "SELECT Folio, Lote, TO_CHAR(Fecha_Reg, 'DD/MM/YYYY HH24:MI:SS') Fecha, " +
                                      " ( SELECT aju.Sucursal_Id || ' - ' || suc.nombre FROM cat_sucursales suc " +
                                      " WHERE aju.Sucursal_id = suc.sucursales_id ) Origen, ( SELECT aju.Sucursal_Ref || ' - ' || suc.nombre " +
                                      " FROM cat_sucursales suc  WHERE aju.Sucursal_Ref = suc.sucursales_id ) Destino, " +
                                      " Tipo_Mov, Activo, Doc_Referencia   FROM ajustes aju " +
                                      "  where Folio like '%" + Folio + "%'";

                    cmd.BindByName = true;
                }
                OracleDataReader _rdrObj = cmd.ExecuteReader();
                //Grd_Pedido.Rows.Add(_rdrObj.RecordsAffected);



                while (_rdrObj.Read())
                {

                    SIFModelo.Inventarios.InventarioDataSet.AjustesCRow rw = DsInventario.AjustesC.NewAjustesCRow();
                    rw.FOLIO = _rdrObj.GetString(_rdrObj.GetOrdinal("FOLIO"));
                    rw.LOTE = _rdrObj.GetInt16(_rdrObj.GetOrdinal("Lote")).ToString();
                    rw.FECHA = _rdrObj.GetString(_rdrObj.GetOrdinal("Fecha"));
                    rw.ORIGEN = _rdrObj.GetString(_rdrObj.GetOrdinal("Origen"));
                    rw.DESTINO = _rdrObj.GetString(_rdrObj.GetOrdinal("Destino"));
                    rw.DOC_REFERENCIA = _rdrObj.GetString(_rdrObj.GetOrdinal("Doc_Referencia"));
                    rw.TIPO_MOV = _rdrObj.GetString(_rdrObj.GetOrdinal("Tipo_mov"));
                    rw.ACTIVO = _rdrObj.GetString(_rdrObj.GetOrdinal("Activo"));
                    if (Activo == "" || Activo == rw.ACTIVO)
                        DsInventario.AjustesC.AddAjustesCRow(rw);



                    OracleCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandText = "PKG_INVENTARIOS.sp_get_ajustesdet";
                    cmd1.BindByName = true;

                    // OUT REF CURSOR bound
                    OracleParameter pPedido1 = cmd1.Parameters.Add("Det", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd1.Parameters.Add("NoFolio", OracleDbType.Varchar2, _rdrObj.GetString(_rdrObj.GetOrdinal("FOLIO")), ParameterDirection.Input);
                    cmd1.Parameters.Add("NoLote", OracleDbType.Decimal, _rdrObj.GetInt16(_rdrObj.GetOrdinal("Lote")), ParameterDirection.Input);

                    OracleDataReader _rdrObj1 = cmd1.ExecuteReader();

                    if (_rdrObj1.HasRows)
                    {

                        while (_rdrObj1.Read())
                        {
                            string pfolio = _rdrObj.GetString(_rdrObj.GetOrdinal("Folio"));
                            Int16 plote = _rdrObj1.GetInt16(_rdrObj1.GetOrdinal("Lote"));
                            Int16 ppartida = Convert.ToInt16(_rdrObj1.GetOrdinal("partida"));
                            string particulo = _rdrObj1.GetString(_rdrObj1.GetOrdinal("Articulo"));
                            string nombre = _rdrObj1.GetString(_rdrObj1.GetOrdinal("Nombre"));
                            Int32 ppedido = _rdrObj1.GetInt32(_rdrObj1.GetOrdinal("Pedido"));
                            decimal pcosto = _rdrObj1.GetDecimal(_rdrObj1.GetOrdinal("Costo"));
                            string pcostos = _rdrObj1.GetOrdinal("Costo").ToString();
                            decimal pcosto2 = _rdrObj1.GetDecimal(_rdrObj1.GetOrdinal("ass"));
                            string pcostos2 = _rdrObj1.GetOrdinal("ass").ToString();
                            string pconepto = _rdrObj1.GetString(_rdrObj1.GetOrdinal("Concepto"));
                            double pprecio = _rdrObj1.GetOrdinal("Precio");

                            double preiocs = Convert.ToDouble((_rdrObj1.GetOrdinal("ass")));

                            DsInventario.AJUSTES_DET.AddAJUSTES_DETRow(pfolio,
                                                                        plote,
                                                                          0,
                                                                          particulo,
                                                                          nombre,
                                                                          ppedido,
                                                                         pcosto2,
                                                                         pconepto,
                                                                          ppartida,
                                                                         pprecio
                                                                        );

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
               MessageBox.Show(ex.Message, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            return DsInventario;

        }

        public static SIFModelo.Inventarios.InventarioDataSet GetAjustes(String Folio, SIFModelo.Sucursal sucursal)
        {

            return GetAjustes("", "", "", Folio);
        }

        public static void InsInvAjuste(int Origen, int Destino, double Total,
                                string Tipo, string DocRef,
                                int[] Lote, int[] Sec, String[] ArtId,
                                String[] Nombre,
                                String[] Concepto, int[] Cant, double[] TotLote,
                                double[] Precio, double[] PrecioVta, SIFModelo.Usuario usuario)
        {
            string ProductName = "Ajustes";

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_INVENTARIOS.sp_ins_ajuste";
                cmd.BindByName = true;

                cmd.Parameters.Add("Origen", OracleDbType.Int16, Origen, ParameterDirection.Input);
                cmd.Parameters.Add("Destino", OracleDbType.Int16, Destino, ParameterDirection.Input);
                cmd.Parameters.Add("Total", OracleDbType.Double, Total, ParameterDirection.Input);
                cmd.Parameters.Add("Tipo", OracleDbType.Varchar2, Tipo, ParameterDirection.Input);
                cmd.Parameters.Add("DocRef", OracleDbType.Varchar2, DocRef, ParameterDirection.Input);

                // Input Array Lote
                OracleParameter InLote = cmd.Parameters.Add("Lote", OracleDbType.Decimal);
                InLote.Direction = ParameterDirection.Input;
                InLote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InLote.Value = Lote;

                // Input Array Sec
                OracleParameter InSec = cmd.Parameters.Add("Sec", OracleDbType.Decimal);
                InSec.Direction = ParameterDirection.Input;
                InSec.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InSec.Value = Sec;

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

                // IN Array Concepto
                OracleParameter InConcep = cmd.Parameters.Add("Concepto", OracleDbType.Varchar2);
                InConcep.Direction = ParameterDirection.Input;
                InConcep.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InConcep.Value = Concepto;

                // IN Array Cantidad
                OracleParameter InCant = cmd.Parameters.Add("Cant", OracleDbType.Decimal);
                InCant.Direction = ParameterDirection.Input;
                InCant.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCant.Value = Cant;

                // IN Array Total Lote
                OracleParameter InTotLote = cmd.Parameters.Add("TotLote", OracleDbType.Double);
                InTotLote.Direction = ParameterDirection.Input;
                InTotLote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InTotLote.Value = TotLote;

                // IN Array Precio
                OracleParameter InPrecio = cmd.Parameters.Add("Precio", OracleDbType.Double);
                InPrecio.Direction = ParameterDirection.Input;
                InPrecio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecio.Value = Precio;

                // IN Array Precio Venta
                OracleParameter InPrecioVta = cmd.Parameters.Add("PrecioVta", OracleDbType.Double);
                InPrecioVta.Direction = ParameterDirection.Input;
                InPrecioVta.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecioVta.Value = PrecioVta;

                // OUT parameter
                OracleParameter pPedido =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                cmd.Parameters.Add("usuario", OracleDbType.Varchar2, usuario.UsuariosID, ParameterDirection.Input);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pPedido.Value.ToString()))
                {
                   MessageBox.Show("Se creo el ajuste con el Folio " + pPedido.Value.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al crear el ajuste: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        public static void UpdInvAjuste(string Folio, int Lote, int Origen, int Destino, string Tipo,
                               string DocRef, double Total,
                                int[] Sec, String[] ArtId, String[] Nombre,
                                String[] Concepto, int[] Cant,
                                double[] Precio, double[] PrecioVta)
        {

            string ProductName = "Ajustes";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_INVENTARIOS.sp_upd_ajuste";
                cmd.BindByName = true;

                cmd.Parameters.Add("Origen", OracleDbType.Int16, Origen, ParameterDirection.Input);
                cmd.Parameters.Add("Destino", OracleDbType.Int16, Destino, ParameterDirection.Input);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int16, Lote, ParameterDirection.Input);
                cmd.Parameters.Add("Total", OracleDbType.Double, Total, ParameterDirection.Input);
                cmd.Parameters.Add("Tipo", OracleDbType.Varchar2, Tipo, ParameterDirection.Input);
                cmd.Parameters.Add("DocRef", OracleDbType.Varchar2, DocRef, ParameterDirection.Input);

                // Input Array Sec
                OracleParameter InSec = cmd.Parameters.Add("Sec", OracleDbType.Decimal);
                InSec.Direction = ParameterDirection.Input;
                InSec.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InSec.Value = Sec;

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

                // IN Array Concepto
                OracleParameter InConcep = cmd.Parameters.Add("Concepto", OracleDbType.Varchar2);
                InConcep.Direction = ParameterDirection.Input;
                InConcep.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InConcep.Value = Concepto;

                // IN Array Cantidad
                OracleParameter InCant = cmd.Parameters.Add("Cant", OracleDbType.Decimal);
                InCant.Direction = ParameterDirection.Input;
                InCant.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCant.Value = Cant;

                // IN Array Precio
                OracleParameter InPrecio = cmd.Parameters.Add("Precio", OracleDbType.Double);
                InPrecio.Direction = ParameterDirection.Input;
                InPrecio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecio.Value = Precio;

                // IN Array Precio Venta
                OracleParameter InPrecioVta = cmd.Parameters.Add("PrecioVta", OracleDbType.Double);
                InPrecioVta.Direction = ParameterDirection.Input;
                InPrecioVta.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecioVta.Value = PrecioVta;


                // OUT parameter
                OracleParameter pPedido =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pPedido.Value.ToString()))
                {
                    if (Convert.ToDecimal(pPedido.Value.ToString()) > 0)
                       MessageBox.Show("Se actualizo el Ajuste con el Folio " + pPedido.Value.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al actualizar el Ajuste: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public static int AplicaRepProveedor(SIFModelo.ReposisionProveedor devPRov, List<SIFModelo.ReposisionProveedorDetalle> devPRovDEt)
        {
            string ProductName = "Reposicion de Proveedor";

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                String[] articuloid = new String[devPRovDEt.Count()];
                Decimal[] cantidad = new Decimal[devPRovDEt.Count()];
                Decimal[] precio_venta = new Decimal[devPRovDEt.Count()];
                Decimal[] costo_rec = new Decimal[devPRovDEt.Count()];
                Decimal[] iva = new Decimal[devPRovDEt.Count()];
                String[] comentario = new String[devPRovDEt.Count()];
                int i = 0;
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_INVENTARIOS.sp_ins_rep_proveedor";
                cmd.BindByName = true;

                cmd.Parameters.Add("ComenGral", OracleDbType.Varchar2, devPRov.Comentario, ParameterDirection.Input);
                cmd.Parameters.Add("Proveedorid", OracleDbType.Varchar2, devPRov.ProveedorID, ParameterDirection.Input);
                cmd.Parameters.Add("RDM", OracleDbType.Varchar2, devPRov.RDM, ParameterDirection.Input);
                cmd.Parameters.Add("Usuarioid", OracleDbType.Varchar2, devPRov.UsuarioID, ParameterDirection.Input);
                cmd.Parameters.Add("Total", OracleDbType.Varchar2, devPRov.Total, ParameterDirection.Input);

                foreach (SIFModelo.ReposisionProveedorDetalle det in devPRovDEt)
                {
                    articuloid[i] = det.ArticuloID;
                    cantidad[i] = det.Cantidad;
                    precio_venta[i] = det.Precio;
                    costo_rec[i] = det.Costo;
                    comentario[i] = det.Comentario;
                    iva[i] = det.IVA;
                    i++;
                }
                // IN Array ID's
                OracleParameter InArtId = cmd.Parameters.Add("ArtId", OracleDbType.Varchar2);
                InArtId.Direction = ParameterDirection.Input;
                InArtId.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InArtId.Value = articuloid;

                // IN Array Articulos
                OracleParameter Incomen = cmd.Parameters.Add("ComenDet", OracleDbType.Varchar2);
                Incomen.Direction = ParameterDirection.Input;
                Incomen.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                Incomen.Value = comentario;


                // IN Array Cantidad
                OracleParameter InCantDev = cmd.Parameters.Add("CantDev", OracleDbType.Decimal);
                InCantDev.Direction = ParameterDirection.Input;
                InCantDev.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantDev.Value = cantidad;

                OracleParameter Iniva = cmd.Parameters.Add("Iva", OracleDbType.Decimal);
                Iniva.Direction = ParameterDirection.Input;
                Iniva.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                Iniva.Value = iva;


                OracleParameter InPrecioCs = cmd.Parameters.Add("PrecioCosto", OracleDbType.Double);
                InPrecioCs.Direction = ParameterDirection.Input;
                InPrecioCs.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecioCs.Value = costo_rec;

                // IN Array Precio Venta
                OracleParameter InPrecioVta = cmd.Parameters.Add("PrecioVta", OracleDbType.Double);
                InPrecioVta.Direction = ParameterDirection.Input;
                InPrecioVta.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecioVta.Value = precio_venta;

                // OUT parameter
                OracleParameter pPedido =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // cmd.Parameters.Add("usuario", OracleDbType.Varchar2, usuario.UsuariosID, ParameterDirection.Input);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pPedido.Value.ToString()))
                {
                   MessageBox.Show("Se creo la Reposicion de proveedor con el Folio " + pPedido.Value.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 1;
                }
                return 1;

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al crear la Reposicion de proveedor: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
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
        public static int AplicaDevProveedor(SIFModelo.DevolucionProveedor devPRov, List<SIFModelo.DevolucionProveedorDetalle> devPRovDEt)
        {
            string ProductName = "Devolucion a Proveedor";

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                String[] articuloid = new String[devPRovDEt.Count()];
                Decimal[] cantidad = new Decimal[devPRovDEt.Count()];
                Decimal[] precio_venta = new Decimal[devPRovDEt.Count()];
                Decimal[] costo_rec = new Decimal[devPRovDEt.Count()];
                Decimal[] iva = new Decimal[devPRovDEt.Count()];
                String[] comentario = new String[devPRovDEt.Count()];
                int i = 0;
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_INVENTARIOS.sp_ins_dev_proveedor";
                cmd.BindByName = true;

                cmd.Parameters.Add("ComenGral", OracleDbType.Varchar2, devPRov.Comentario, ParameterDirection.Input);
                cmd.Parameters.Add("Proveedorid", OracleDbType.Varchar2, devPRov.ProveedorID, ParameterDirection.Input);
                cmd.Parameters.Add("RDM", OracleDbType.Varchar2, devPRov.RDM, ParameterDirection.Input);
                cmd.Parameters.Add("Usuarioid", OracleDbType.Varchar2, devPRov.UsuarioID, ParameterDirection.Input);
                cmd.Parameters.Add("Total", OracleDbType.Varchar2, devPRov.Total, ParameterDirection.Input);

                foreach (SIFModelo.DevolucionProveedorDetalle det in devPRovDEt)
                {
                    articuloid[i] = det.ArticuloID;
                    cantidad[i] = det.Cantidad;
                    precio_venta[i] = det.Precio;
                    costo_rec[i] = det.Costo;
                    comentario[i] = det.Comentario;
                    iva[i] = det.IVA;
                    i++;
                }
                // IN Array ID's
                OracleParameter InArtId = cmd.Parameters.Add("ArtId", OracleDbType.Varchar2);
                InArtId.Direction = ParameterDirection.Input;
                InArtId.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InArtId.Value = articuloid;

                // IN Array Articulos
                OracleParameter Incomen = cmd.Parameters.Add("ComenDet", OracleDbType.Varchar2);
                Incomen.Direction = ParameterDirection.Input;
                Incomen.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                Incomen.Value = comentario;


                // IN Array Cantidad
                OracleParameter InCantDev = cmd.Parameters.Add("CantDev", OracleDbType.Decimal);
                InCantDev.Direction = ParameterDirection.Input;
                InCantDev.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantDev.Value = cantidad;

                OracleParameter Iniva = cmd.Parameters.Add("Iva", OracleDbType.Decimal);
                Iniva.Direction = ParameterDirection.Input;
                Iniva.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                Iniva.Value = iva;


                OracleParameter InPrecioCs = cmd.Parameters.Add("PrecioCosto", OracleDbType.Double);
                InPrecioCs.Direction = ParameterDirection.Input;
                InPrecioCs.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecioCs.Value = costo_rec;

                // IN Array Precio Venta
                OracleParameter InPrecioVta = cmd.Parameters.Add("PrecioVta", OracleDbType.Double);
                InPrecioVta.Direction = ParameterDirection.Input;
                InPrecioVta.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecioVta.Value = precio_venta;

                // OUT parameter
                OracleParameter pPedido =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // cmd.Parameters.Add("usuario", OracleDbType.Varchar2, usuario.UsuariosID, ParameterDirection.Input);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pPedido.Value.ToString()))
                {
                   MessageBox.Show("Se creo la devolucion a proveedor con el Folio " + pPedido.Value.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 1;
                }
                return 1;

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al crear la devolucion a proveedor: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
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

        public static int AplicaAjuste(string Folio, int Lote, int Sucursal,
                                    String[] ArtId, int[] Cant, double[] Precio, string Tipo, string Usuario)
        {
            string ProductName = "Ajustes";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                if (Tipo.Contains("E"))
                    cmd.CommandText = "PKG_INVENTARIOS.sp_ajuste_entrada";
                else
                    cmd.CommandText = "PKG_INVENTARIOS.sp_ajuste_salida";

                cmd.BindByName = true;

                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int16, Lote, ParameterDirection.Input);
                cmd.Parameters.Add("Sucursal", OracleDbType.Int16, Sucursal, ParameterDirection.Input);
                cmd.Parameters.Add("Usuario", OracleDbType.Varchar2, Usuario, ParameterDirection.Input);
               

                // IN Array ID's
                OracleParameter InArtId = cmd.Parameters.Add("ArtId", OracleDbType.Varchar2);
                InArtId.Direction = ParameterDirection.Input;
                InArtId.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InArtId.Value = ArtId;

                // IN Array Cantidad
                OracleParameter InCant = cmd.Parameters.Add("Cant", OracleDbType.Decimal);
                InCant.Direction = ParameterDirection.Input;
                InCant.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCant.Value = Cant;

                /* if (Tipo.Contains("E"))
                 {*/
                // IN Array Precio
                OracleParameter InPrecio = cmd.Parameters.Add("Precio", OracleDbType.Double);
                InPrecio.Direction = ParameterDirection.Input;
                InPrecio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecio.Value = Precio;
                //  }
                // OUT parameter
                OracleParameter pAjuste =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pAjuste.Value.ToString()))
                {
                   MessageBox.Show("Se Aplico el ajuste", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return Convert.ToInt32(pAjuste.Value.ToString());
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al aplicar el ajuste: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
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


        public static int AplicaAjusteAjustes(string Folio, int Lote, int Sucursal,
                                    String[] ArtId, int[] Cant, double[] Precio, string Tipo, string Usuario, String[] Lotes_internos)
        {
            string ProductName = "Ajustes";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                if (Tipo.Contains("E"))
                    cmd.CommandText = "PKG_INVENTARIOS.sp_Ajuste_Entrada_Ajustes";
                else
                    cmd.CommandText = "PKG_INVENTARIOS.sp_ajuste_salida_ajustes";

                cmd.BindByName = true;

                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int16, Lote, ParameterDirection.Input);
                cmd.Parameters.Add("Sucursal", OracleDbType.Int16, Sucursal, ParameterDirection.Input);
                cmd.Parameters.Add("Usuario", OracleDbType.Varchar2, Usuario, ParameterDirection.Input);

                // IN Array ID's
                OracleParameter InArtId = cmd.Parameters.Add("ArtId", OracleDbType.Varchar2);
                InArtId.Direction = ParameterDirection.Input;
                InArtId.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InArtId.Value = ArtId;

                // IN Array Cantidad
                OracleParameter InCant = cmd.Parameters.Add("Cant", OracleDbType.Decimal);
                InCant.Direction = ParameterDirection.Input;
                InCant.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCant.Value = Cant;

                /* if (Tipo.Contains("E"))
                 {*/
                // IN Array Precio
                OracleParameter InPrecio = cmd.Parameters.Add("Precio", OracleDbType.Double);
                InPrecio.Direction = ParameterDirection.Input;
                InPrecio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecio.Value = Precio;
                //  }
                //Lote interno
                OracleParameter InLInterno = cmd.Parameters.Add("LInterno", OracleDbType.Varchar2);
                InLInterno.Direction = ParameterDirection.Input;
                InLInterno.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InLInterno.Value = Lotes_internos;
                // OUT parameter
                OracleParameter pAjuste =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pAjuste.Value.ToString()))
                {
                   MessageBox.Show("Se Aplico el ajuste", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return Convert.ToInt32(pAjuste.Value.ToString());
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al aplicar el ajuste: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
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




        //public static SIFModelo.Inventarios.InventarioDataSet.AJUSTESRow AjustePorFolio(string AjusteID)
        //{
        //    string sentencia = "SELECT Folio, Lote, TO_CHAR(Fecha_Reg, 'DD/MM/YYYY HH24:MI:SS') Fecha, " +
        //      " ( SELECT aju.Sucursal_Id || ' - ' || suc.nombre " +
        //      "     FROM cat_sucursales suc " +
        //      "    WHERE aju.Sucursal_id = suc.sucursales_id ) Origen, " +
        //      " ( SELECT aju.Sucursal_Ref || ' - ' || suc.nombre " +
        //      "     FROM cat_sucursales suc " +
        //      "    WHERE aju.Sucursal_Ref = suc.sucursales_id ) Destino, " +
        //      " Tipo_Mov, Activo, Doc_Referencia " +
        //      " FROM ajustes aju ";
        //    sentencia += " WHERE Folio = '" + AjusteID + "'";

        //    SIFModelo.Inventarios.InventarioDataSet DsInventario = new SIFModelo.Inventarios.InventarioDataSet();


        //    Cursor.Current = Cursors.WaitCursor;

        //    //   int nRow = 1, ind = 0;

        //    OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

        //    try
        //    {
        //        conn.Open();

        //        // Create an OracleCommand

        //        OracleCommand cmd = conn.CreateCommand();
        //        if (Folio == "")
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandText = "PKG_INVENTARIOS.sp_get_ajustes";
        //            cmd.BindByName = true;

        //            // OUT REF CURSOR bound
        //            OracleParameter pPedido = cmd.Parameters.Add("Hdr", OracleDbType.RefCursor, ParameterDirection.Output);
        //            cmd.Parameters.Add("FecIni", OracleDbType.Varchar2, Ini, ParameterDirection.Input);
        //            cmd.Parameters.Add("FecFin", OracleDbType.Varchar2, Fin, ParameterDirection.Input);
        //        }
        //        else
        //        {
        //            cmd.CommandText = "SELECT Folio, Lote, TO_CHAR(Fecha_Reg, 'DD/MM/YYYY HH24:MI:SS') Fecha, " +
        //                              " ( SELECT aju.Sucursal_Id || ' - ' || suc.nombre FROM cat_sucursales suc " +
        //                              " WHERE aju.Sucursal_id = suc.sucursales_id ) Origen, ( SELECT aju.Sucursal_Ref || ' - ' || suc.nombre " +
        //                              " FROM cat_sucursales suc  WHERE aju.Sucursal_Ref = suc.sucursales_id ) Destino, " +
        //                              " Tipo_Mov, Activo, Doc_Referencia   FROM ajustes aju " +
        //                              "  where Folio like '%" + Folio + "%'";

        //            cmd.BindByName = true;
        //        }
        //        OracleDataReader _rdrObj = cmd.ExecuteReader();
        //        //Grd_Pedido.Rows.Add(_rdrObj.RecordsAffected);



        //        while (_rdrObj.Read())
        //        {

        //            SIFModelo.Inventarios.InventarioDataSet.AjustesCRow rw = DsInventario.AjustesC.NewAjustesCRow();
        //            rw.FOLIO = _rdrObj.GetString(_rdrObj.GetOrdinal("FOLIO"));
        //            rw.LOTE = _rdrObj.GetInt16(_rdrObj.GetOrdinal("Lote")).ToString();
        //            rw.FECHA = _rdrObj.GetString(_rdrObj.GetOrdinal("Fecha"));
        //            rw.ORIGEN = _rdrObj.GetString(_rdrObj.GetOrdinal("Origen"));
        //            rw.DESTINO = _rdrObj.GetString(_rdrObj.GetOrdinal("Destino"));
        //            rw.DOC_REFERENCIA = _rdrObj.GetString(_rdrObj.GetOrdinal("Doc_Referencia"));
        //            rw.TIPO_MOV = _rdrObj.GetString(_rdrObj.GetOrdinal("Tipo_mov"));
        //            rw.ACTIVO = _rdrObj.GetString(_rdrObj.GetOrdinal("Activo"));
        //            if (Activo == "" || Activo == rw.ACTIVO)
        //                DsInventario.AjustesC.AddAjustesCRow(rw);



        //            OracleCommand cmd1 = conn.CreateCommand();
        //            cmd1.CommandType = CommandType.StoredProcedure;
        //            cmd1.CommandText = "PKG_INVENTARIOS.sp_get_ajustesdet";
        //            cmd1.BindByName = true;

        //            // OUT REF CURSOR bound
        //            OracleParameter pPedido1 = cmd1.Parameters.Add("Det", OracleDbType.RefCursor, ParameterDirection.Output);
        //            cmd1.Parameters.Add("NoFolio", OracleDbType.Varchar2, _rdrObj.GetString(_rdrObj.GetOrdinal("FOLIO")), ParameterDirection.Input);
        //            cmd1.Parameters.Add("NoLote", OracleDbType.Decimal, _rdrObj.GetInt16(_rdrObj.GetOrdinal("Lote")), ParameterDirection.Input);

        //            OracleDataReader _rdrObj1 = cmd1.ExecuteReader();

        //            if (_rdrObj1.HasRows)
        //            {

        //                while (_rdrObj1.Read())
        //                {
        //                    string pfolio = _rdrObj.GetString(_rdrObj.GetOrdinal("Folio"));
        //                    Int16 plote = _rdrObj1.GetInt16(_rdrObj1.GetOrdinal("Lote"));
        //                    Int16 ppartida = Convert.ToInt16(_rdrObj1.GetOrdinal("partida"));
        //                    string particulo = _rdrObj1.GetString(_rdrObj1.GetOrdinal("Articulo"));
        //                    string nombre = _rdrObj1.GetString(_rdrObj1.GetOrdinal("Nombre"));
        //                    Int32 ppedido = _rdrObj1.GetInt32(_rdrObj1.GetOrdinal("Pedido"));
        //                    double pcosto = _rdrObj1.GetDouble(_rdrObj1.GetOrdinal("Costo"));
        //                    string pconepto = _rdrObj1.GetString(_rdrObj1.GetOrdinal("Concepto"));
        //                    double pprecio = _rdrObj1.GetDouble(_rdrObj1.GetOrdinal("Precio"));

        //                    DsInventario.AJUSTES_DET.AddAJUSTES_DETRow(pfolio,
        //                                                                plote,
        //                                                                  0,
        //                                                                  ppartida,
        //                                                                  particulo,
        //                                                                  nombre,
        //                                                                  ppedido,
        //                                                                 pcosto,
        //                                                                 pconepto,
        //                                                                 pprecio
        //                                                                );

        //                }
        //            }
        //            _rdrObj1.Close();
        //            _rdrObj1.Dispose();

        //        }


        //        _rdrObj.Close();
        //        _rdrObj.Dispose();


        //    }
        //    catch (Exception ex)
        //    {
        //       MessageBox.Show(ex.Message, "Ajustes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    finally
        //    {
        //        if (null != conn)
        //        {
        //            conn.Close();
        //            conn.Dispose();
        //        }
        //        Cursor.Current = Cursors.Default;

        //    }

        //    return DsInventario;


        //    return null;
        //}

        public static DataTable getAjusteHUP_V2(string referencia)
        {
            //PIT 02/03/2022
            DataTable dt = new DataTable("LotesCaducidades");

            dt.Columns.Add("FOLIO", typeof(string));
            dt.Columns.Add("REFERENCIA", typeof(string));
            dt.Columns.Add("ARTICULO_ID", typeof(string));
            dt.Columns.Add("CLAVE2", typeof(string));
            dt.Columns.Add("DESC_1", typeof(string));
            dt.Columns.Add("CANTIDAD", typeof(int));
            dt.Columns.Add("PRECIO", typeof(Decimal));

            string sentencia = "SP_GET_AJUSTE_HOSP";
            string V = "Data Source =(DESCRIPTION =  (ADDRESS_LIST =    (ADDRESS = (PROTOCOL = TCP) (HOST = 172.19.24.7) (PORT = 1521))   )    (CONNECT_DATA =      (SID = HOSP2013)    )  );User Id=FARMACIA;Password=HOSP.2013;";


            using (OracleConnection cnx =new OracleConnection(V))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter var_folio = new OracleParameter("var_folio", OracleDbType.Varchar2);
                    var_folio.Value = referencia;
                    cmd.Parameters.Add(var_folio);

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

                                DataRow registro = dt.NewRow();
                                registro["FOLIO"] = oreader["FOLIO"].ToString();
                                registro["REFERENCIA"] = oreader["REFERENCIA"].ToString();
                                registro["ARTICULO_ID"] = oreader["ARTICULO_ID"].ToString();
                                registro["CLAVE2"] = oreader["CLAVE2"].ToString();
                                registro["DESC_1"] = oreader["DESC_1"].ToString();
                                registro["CANTIDAD"] = Convert.ToInt32(oreader["CANTIDAD"].ToString());
                                registro["PRECIO"] = Convert.ToDecimal(oreader["PRECIO"].ToString());
                                dt.Rows.Add(registro);
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

            return dt;       
        }

        public static void getFoliosOC(string referencia, out string fo, out string fc, out string ft)
        {          
            try
            {
                string sentencia = "SP_GET_FOLIOS_OC";
                string V = "Data Source =(DESCRIPTION =  (ADDRESS_LIST =    (ADDRESS = (PROTOCOL = TCP) (HOST = 172.19.24.188) (PORT = 8087))   )    (CONNECT_DATA =      (SID = F1S3)    )  );User Id=FARMACIA;Password=FAFL01;";

                using (OracleConnection cnx = new OracleConnection(V))
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("referencia", OracleDbType.Varchar2, referencia, ParameterDirection.Input);
                        OracleParameter folio_o = cmd.Parameters.Add("folio_o", OracleDbType.Varchar2, ParameterDirection.Output);
                        OracleParameter folio_c = cmd.Parameters.Add("folio_c", OracleDbType.Varchar2, ParameterDirection.Output);
                        OracleParameter folio_t = cmd.Parameters.Add("folio_t", OracleDbType.Varchar2, ParameterDirection.Output);
                        folio_o.Size = 50;
                        folio_c.Size = 50;
                        folio_t.Size = 50;

                        cmd.ExecuteReader();

                        fo = folio_o.Value.ToString();
                        fc = folio_c.Value.ToString();
                        ft = folio_t.Value.ToString();

                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                    }
                }
            }
            catch (Exception e)
            {
                fo = "";
                fc = "";
                ft = "";
                Console.WriteLine("ERROR => " + e);
            }
            finally
            {
                
            }                   
            
        }


        public static bool validaArticulo(string codigo)
        {
            string art = codigo;
            bool existe = false;
            string sentencia = "select articulo_id from cat_articulos where articulo_id='"+ art +"' ";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.BindByName = true;

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            existe = true;
                        }
                        return existe;
                    }
                    catch (Exception)
                    {
                        return existe;
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

        public static string VerificarProcesados(string Folio, string lote,int mov)
        {
            //List<SIFModelo.BonificacionDet_Caducidad> articulos = new List<SIFModelo.BonificacionDet_Caducidad>();
            //SIFModelo.BonificacionDet_Caducidad det = new SIFModelo.BonificacionDet_Caducidad();
            string sentencia = "SP_VERIFICA_LOT_CAD";
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
                    cmd.Parameters.Add("v_mov", OracleDbType.Int32, 3, Convert.ToInt32(mov), ParameterDirection.Input);

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

        public static string CierreAjustes2021(string Folio, int lote,int sucursal,string usuario)
        {
            //List<SIFModelo.BonificacionDet_Caducidad> articulos = new List<SIFModelo.BonificacionDet_Caducidad>();
            //SIFModelo.BonificacionDet_Caducidad det = new SIFModelo.BonificacionDet_Caducidad();
            string sentencia = "PKG_CIERRE_CADUCIDADES21.sp_ajustes_2021";
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
                    cmd.Parameters.Add("sucursal", OracleDbType.Int32, sucursal , ParameterDirection.Input);
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

        public static string ObtieneLoteInterno(string folio, string sku,int cantidad)
        {
            List<SIFModelo.ReposisionProveedorDetalle> articulos = new List<SIFModelo.ReposisionProveedorDetalle>();
            SIFModelo.ReposisionProveedorDetalle det = new SIFModelo.ReposisionProveedorDetalle();
            string LOTE_INTERNO_ = "";
            string sentencia = "SELECT  LOTE_INTERNO FROM AJUSTESDET_CADUCIDAD  where FOLIO ='" + folio + "' AND ARTICULO_ID='"+sku+"' and cantidad="+cantidad+"";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.BindByName = true;

                    try
                    {
                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {

                                LOTE_INTERNO_ = oreader["LOTE_INTERNO"].ToString();
                                
                            }
                        }
                        return LOTE_INTERNO_;
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
        }

        public static string CreaAjusteOrdenCompraMandato(string Folio, int pProveedorId, string usuario)
        {
            //List<SIFModelo.BonificacionDet_Caducidad> articulos = new List<SIFModelo.BonificacionDet_Caducidad>();
            //SIFModelo.BonificacionDet_Caducidad det = new SIFModelo.BonificacionDet_Caducidad();
            string sentencia = "SP_CREATE_OC_HUP_MANDATO";
            string RESPUESTA;
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("p_folio_ajuste", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                    cmd.Parameters.Add("p_proveedor_id", OracleDbType.Varchar2, pProveedorId.ToString(), ParameterDirection.Input);
                    cmd.Parameters.Add("p_usuario_id", OracleDbType.Varchar2, usuario, ParameterDirection.Input);
                    

                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("p_out_respuesta", OracleDbType.Varchar2, 250);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    outparam.Size = 1200;

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


                //return RESPUESTA;
