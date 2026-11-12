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
    public class DestruccionesAlmacen
    {
        public static SIFModelo.Inventarios.InventarioDataSet GetDestrucciones(string Ini, string Fin, String Activo, String Folio)
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
                    cmd.CommandText = "PKG_INVENTARIOS.sp_get_destrucciones";
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
                                      " WHERE aju.Sucursal_id = suc.sucursales_id ) Origen, ( SELECT aju.Sucursal_Id || ' - ' || suc.nombre " +
                                      " FROM cat_sucursales suc  WHERE aju.Sucursal_Id = suc.sucursales_id ) Destino, " +
                                      " Tipo_Mov, Activo, Doc_Referencia   FROM destrucciones aju " +
                                      "  where Folio like '%" + Folio + "%'";

                    cmd.BindByName = true;
                }
                OracleDataReader _rdrObj = cmd.ExecuteReader();
                //Grd_Pedido.Rows.Add(_rdrObj.RecordsAffected);



                while (_rdrObj.Read())
                {

                    SIFModelo.Inventarios.InventarioDataSet.DESTRUCCIONESCRow rw = DsInventario.DESTRUCCIONESC.NewDESTRUCCIONESCRow();// AjustesC.NewAjustesCRow();

                    rw.FOLIO = _rdrObj.GetString(_rdrObj.GetOrdinal("FOLIO"));
                    rw.LOTE = _rdrObj.GetInt16(_rdrObj.GetOrdinal("Lote")).ToString();
                    rw.FECHA = _rdrObj.GetString(_rdrObj.GetOrdinal("Fecha"));
                    rw.ORIGEN = _rdrObj.GetString(_rdrObj.GetOrdinal("Origen"));
                    rw.DESTINO = _rdrObj.GetString(_rdrObj.GetOrdinal("Destino"));
                    rw.DOC_REFERENCIA = _rdrObj.GetString(_rdrObj.GetOrdinal("Doc_Referencia"));
                    rw.TIPO_MOV = _rdrObj.GetString(_rdrObj.GetOrdinal("Tipo_mov"));
                    rw.ACTIVO = _rdrObj.GetString(_rdrObj.GetOrdinal("Activo"));
                    if (Activo == "" || Activo == rw.ACTIVO)
                        DsInventario.DESTRUCCIONESC.AddDESTRUCCIONESCRow(rw);



                    OracleCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandText = "PKG_INVENTARIOS.sp_get_destruccionesdet";
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
                            double pcosto = _rdrObj1.GetDouble(_rdrObj1.GetOrdinal("Costo"));
                            string pconepto = _rdrObj1.GetString(_rdrObj1.GetOrdinal("Concepto"));
                            double pprecio = _rdrObj1.GetDouble(_rdrObj1.GetOrdinal("Precio"));

                            DsInventario.DESTRUCCIONES_DET.AddDESTRUCCIONES_DETRow(pfolio,
                                                                        plote,
                                                                          0,
                                                                          ppartida,
                                                                          particulo,
                                                                          nombre,
                                                                          ppedido,
                                                                         pcosto,
                                                                         pconepto,
                                                                         pprecio
                                                                        );
                           /* DsInventario.AJUSTES_DET.AddAJUSTES_DETRow(pfolio,
                                                                        plote,
                                                                          0,
                                                                          ppartida,
                                                                          particulo,
                                                                          nombre,
                                                                          ppedido,
                                                                         pcosto,
                                                                         pconepto,
                                                                         pprecio
                                                                        );*/

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
               MessageBox.Show(ex.Message, "Destrucciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static SIFModelo.Inventarios.InventarioDataSet GetDestrucciones(String Folio, SIFModelo.Sucursal sucursal)
        {

            return GetDestrucciones("", "", "", Folio);
        }

        public static void InsInvDestruccion(int Origen, int Destino, double Total,
                                string Tipo, string DocRef,
                                int[] Lote, int[] Sec, String[] ArtId,
                                String[] Nombre,
                                String[] Concepto, int[] Cant, double[] TotLote,
                                double[] Precio, double[] PrecioVta, SIFModelo.Usuario usuario)
        {
            string ProductName = "Destrucciones";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_INVENTARIOS.sp_ins_destruccion";
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
                   MessageBox.Show("Se creo la Destruccion con el Folio " + pPedido.Value.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al crear la Destruccion: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        public static void UpdInvDestruccion(string Folio, int Lote, int Origen, int Destino, string Tipo,
                               string DocRef, double Total,
                                int[] Sec, String[] ArtId, String[] Nombre,
                                String[] Concepto, int[] Cant,
                                double[] Precio, double[] PrecioVta)
        {

            string ProductName = "Destrucciones";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_INVENTARIOS.sp_upd_destruccion";
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
                       MessageBox.Show("Se actualizo la Destruccion con el Folio " + pPedido.Value.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al actualizar la Destruccion: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static int AplicaDestruccion(string Folio, int Lote, int Sucursal,
                                    String[] ArtId, int[] Cant, double[] Precio, string Tipo, string Usuario)
        {
            string ProductName = "Destrucciones";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                /*if (Tipo.Contains("E"))
                    cmd.CommandText = "PKG_INVENTARIOS.sp_ajuste_entrada";
                else*/
                    cmd.CommandText = "PKG_INVENTARIOS.sp_Destruccion";

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

                if (Tipo.Contains("E"))
                {
                    // IN Array Precio
                    OracleParameter InPrecio = cmd.Parameters.Add("Precio", OracleDbType.Double);
                    InPrecio.Direction = ParameterDirection.Input;
                    InPrecio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    InPrecio.Value = Precio;
                }
                // OUT parameter
                OracleParameter pAjuste =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pAjuste.Value.ToString()))
                {
                   MessageBox.Show("Se Aplico la Destruccion", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return Convert.ToInt32(pAjuste.Value.ToString());
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al aplicar la Destruccion: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static int AplicaDestruccion22(string Folio, int Lote, int Sucursal, string Tipo, string Usuario)
        {
            string ProductName = "Destrucciones";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                /*if (Tipo.Contains("E"))
                    cmd.CommandText = "PKG_INVENTARIOS.sp_ajuste_entrada";
                else*/
                cmd.CommandText = "PKG_INVENTARIOS.sp_Destruccion22";

                cmd.BindByName = true;

                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int16, Lote, ParameterDirection.Input);
                cmd.Parameters.Add("Sucursal", OracleDbType.Int16, Sucursal, ParameterDirection.Input);
                cmd.Parameters.Add("Usuario", OracleDbType.Varchar2, Usuario, ParameterDirection.Input);

                // OUT parameter
                OracleParameter pAjuste =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pAjuste.Value.ToString()))
                {
                   MessageBox.Show("Se Aplico la Destruccion", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return Convert.ToInt32(pAjuste.Value.ToString());
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al aplicar la Destruccion: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
