using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data;
using DevComponents.DotNetBar;
using System.Text.RegularExpressions;

namespace SIFDatos.Inventario
{
    public static class PedidosAlmacen
    {
        public static SIFModelo.Inventarios.InventarioDataSet GetPedidos(string Ini, string Fin, string Activo, String Folio)
        {

            SIFModelo.Inventarios.InventarioDataSet DsInventario = new SIFModelo.Inventarios.InventarioDataSet();
            Cursor.Current = Cursors.WaitCursor;

            //   int nRow = 1, ind = 0;
            string folio=" ";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_get_pedidos";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pPedido = cmd.Parameters.Add("Hdr", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("FecIni", OracleDbType.Varchar2, Ini, ParameterDirection.Input);
                cmd.Parameters.Add("FecFin", OracleDbType.Varchar2, Fin, ParameterDirection.Input);
                cmd.Parameters.Add("FolPed", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                cmd.Parameters.Add("Estado", OracleDbType.Char, Activo, ParameterDirection.Input);
                //if (Folio == "")
                //{
                //    cmd.Parameters.Add("FolPed", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                //    cmd.Parameters.Add("Estado", OracleDbType.Varchar2, "", ParameterDirection.Input);
                //}
                //else
                //{
                //    cmd.Parameters.Add("FolPed", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                //    cmd.Parameters.Add("Estado", OracleDbType.Varchar2, "", ParameterDirection.Input);
                //    //cmd.CommandText = "SELECT Folio, Lote, TO_CHAR(Fecha_Ped, 'DD/MM/YYYY HH24:MI:SS') Fecha, ( SELECT Sucursal_Genera || ' - ' || suc.nombre  " +
                //    //                  " FROM cat_sucursales suc WHERE ped.Sucursal_Genera = suc.sucursales_id ) Origen, ( SELECT Sucursal_Recibe || ' - ' || suc.nombre " +
                //    //                  " FROM cat_sucursales suc WHERE ped.Sucursal_Recibe = suc.sucursales_id ) Destino, Usuario_Genera, Usuario_Recibe, Activo,folio_traspaso " +
                //    //                  " FROM pedido_trasp ped  where folio like '%" +Folio + "%'";
                //}
                OracleDataReader _rdrObj = cmd.ExecuteReader();
                while (_rdrObj.Read())
                {
                    //if (Activo == _rdrObj.GetString(_rdrObj.GetOrdinal("Activo")) || Activo == "")
                    //{
                    SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASPRow rw = DsInventario.PEDIDO_TRASP.NewPEDIDO_TRASPRow();

                    rw.FOLIO = _rdrObj.GetString(_rdrObj.GetOrdinal("FOLIO"));
                    rw.LOTE = _rdrObj.GetInt32(_rdrObj.GetOrdinal("Lote"));
                    rw.FECHA = DateTime.ParseExact(_rdrObj.GetString(_rdrObj.GetOrdinal("Fecha")), "dd/MM/yyyy HH:mm:ss", null); // DateTime.Parse(_rdrObj.GetString(_rdrObj.GetOrdinal("Fecha")));
                    //rw.TOTAL = _rdrObj.GetInt32(_rdrObj.GetOrdinal("Total"));
                    rw.ORIGEN = _rdrObj.GetString(_rdrObj.GetOrdinal("Origen"));
                    rw.DESTINO = _rdrObj.GetString(_rdrObj.GetOrdinal("Destino"));
                    rw.USUARIO_GENERA = _rdrObj.GetString(_rdrObj.GetOrdinal("Usuario_Genera"));
                    rw.FOLIO_TRASPASO = _rdrObj.GetString(_rdrObj.GetOrdinal("folio_traspaso"));

                    ///AVM 10-04-2015 -- SE AGREGA LA CONSULTA DE LA COLUMNA PARA EDITAR EL MOTIVO EN EL COMBOBOX
                    rw.ID_MOTIVO_PEDIDO = Convert.ToInt32((_rdrObj["ID_MOTIVO_PEDIDO"] == DBNull.Value) ? null : _rdrObj["ID_MOTIVO_PEDIDO"]);

                    rw.EXPR1  = _rdrObj["NOMBRE_MOTIVO"].ToString();
                    rw.REFERENCIA  = _rdrObj["REFERENCIA"].ToString();
                    //if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("Usuario_Recibe")) == false)
                    //    rw.usuar.Value = _rdrObj.GetString(_rdrObj.GetOrdinal("Usuario_Recibe"));

                    rw.ACTIVO = _rdrObj.GetString(_rdrObj.GetOrdinal("Activo"));

                    DsInventario.PEDIDO_TRASP.AddPEDIDO_TRASPRow(rw);

                    OracleCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandText = "PKG_PEDIDO_TRASP.sp_get_peddeta";
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
                            DsInventario.PEDIDO_TRASP_DET1.AddPEDIDO_TRASP_DET1Row(_rdrObj.GetString(_rdrObj.GetOrdinal("Folio")),
                                                                          _rdrObj1.GetInt16(_rdrObj1.GetOrdinal("Lote")),
                                                                          _rdrObj1.GetInt16(_rdrObj1.GetOrdinal("partida")),
                                                                          _rdrObj1.GetString(_rdrObj1.GetOrdinal("Articulo_Id")),
                                                                          _rdrObj1.GetInt32(_rdrObj1.GetOrdinal("Cantidad_Solic")),
                                                                          _rdrObj1.GetString(_rdrObj1.GetOrdinal("Concepto")));
                            folio = _rdrObj.GetString(_rdrObj.GetOrdinal("Folio"));

                        }
                    }
                    _rdrObj1.Close();
                    _rdrObj1.Dispose();
                    //}
                }
                _rdrObj.Close();
                _rdrObj.Dispose();
            }
            catch (Exception ex)
            {
                
               MessageBox.Show(ex.Message +" "+ folio, "Pedidos Almacen ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static SIFModelo.Inventarios.InventarioDataSet GetPedidos(string NoPedido, int NoLote)
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
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_get_pedido";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pPedido = cmd.Parameters.Add("Hdr", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoPedido, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int16, NoLote, ParameterDirection.Input);
                //cmd.CommandText = "SELECT Folio, Lote, TO_CHAR(Fecha_Ped, 'DD/MM/YYYY HH24:MI:SS') Fecha, " +
                //                  " (SELECT Sucursal_Genera || ' - ' || suc.nombre     FROM cat_sucursales suc WHERE ped.Sucursal_Genera = suc.sucursales_id ) Origen, " +
                //                  " ( SELECT  suc.nombre    FROM cat_sucursales suc WHERE ped.Sucursal_Recibe = suc.sucursales_id ) Destino, " +
                //                  " Usuario_Genera, Usuario_Recibe, Activo FROM pedido_trasp ped  WHERE FOLIO='" + NoPedido +"'";
                //cmd.BindByName = true;

                OracleDataReader _rdrObj = cmd.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASPRow rw = DsInventario.PEDIDO_TRASP.NewPEDIDO_TRASPRow();

                    rw.FOLIO = _rdrObj.GetString(_rdrObj.GetOrdinal("FOLIO"));
                    rw.LOTE = _rdrObj.GetInt32(_rdrObj.GetOrdinal("Lote"));
                    rw.FECHA = DateTime.Parse(_rdrObj.GetString(_rdrObj.GetOrdinal("Fecha")));
                    //rw.TOTAL = _rdrObj.GetInt32(_rdrObj.GetOrdinal("Total"));
                    rw.ORIGEN = _rdrObj.GetString(_rdrObj.GetOrdinal("Origen"));
                    rw.DESTINO = _rdrObj.GetString(_rdrObj.GetOrdinal("Destino"));
                    rw.USUARIO_GENERA = _rdrObj.GetString(_rdrObj.GetOrdinal("Usuario_Genera"));
                    //if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("Usuario_Recibe")) == false)
                    //    rw.usuar.Value = _rdrObj.GetString(_rdrObj.GetOrdinal("Usuario_Recibe"));

                    rw.ACTIVO = _rdrObj.GetString(_rdrObj.GetOrdinal("Activo"));
                    
                    ///AVM 10-04-2015 -- SE AGREGA LA CONSULTA DE LA COLUMNA PARA EDITAR EL MOTIVO EN EL COMBOBOX
                    rw.ID_MOTIVO_PEDIDO = Convert.ToInt32((_rdrObj["ID_MOTIVO_PEDIDO"] == DBNull.Value) ? null : _rdrObj["ID_MOTIVO_PEDIDO"]);

                    rw.REFERENCIA = _rdrObj["REFERENCIA"].ToString();

                    DsInventario.PEDIDO_TRASP.AddPEDIDO_TRASPRow(rw);

                    OracleCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandText = "PKG_PEDIDO_TRASP.sp_get_peddeta";
                    cmd1.BindByName = true;

                    // OUT REF CURSOR bound
                    OracleParameter pPedidoDet = cmd1.Parameters.Add("Det", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd1.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoPedido, ParameterDirection.Input);
                    cmd1.Parameters.Add("NoLote", OracleDbType.Int16, NoLote, ParameterDirection.Input);

                    //cmd1.CommandText = "SELECT * FROM PEDIDO_TRASP_DET WHERE FOLIO='" + NoPedido +"'";
                    //cmd1.BindByName = true;


                    OracleDataReader _rdrObj1 = cmd1.ExecuteReader();

                    if (_rdrObj1.HasRows)
                    {
                        while (_rdrObj1.Read())
                        {
                            SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow rowPedidoDet = DsInventario.PEDIDO_TRASP_DET.NewPEDIDO_TRASP_DETRow();

                            rowPedidoDet.ARTICULO_ID = _rdrObj1.GetString(_rdrObj1.GetOrdinal("ARTICULO_ID"));
                            ////rowPedidoDet.TIPO_MEDIC = _rdrObj1.GetString(_rdrObj1.GetOrdinal("TIPO_MEDIC"));
                            rowPedidoDet.CANTIDAD_SOLIC = _rdrObj1.GetInt32(_rdrObj1.GetOrdinal("CANTIDAD_SOLIC"));
                            rowPedidoDet.LOTE = _rdrObj1.GetDecimal(_rdrObj1.GetOrdinal("LOTE"));
                            rowPedidoDet.CONCEPTO = _rdrObj1.GetString(_rdrObj1.GetOrdinal("CONCEPTO"));
                            rowPedidoDet.NOMBRE1 = _rdrObj1.GetString(_rdrObj1.GetOrdinal("CONCEPTO"));
                            rowPedidoDet.PARTIDA = _rdrObj1.GetInt16(_rdrObj1.GetOrdinal("PARTIDA"));
                            rowPedidoDet.FOLIO = NoPedido;
                            DsInventario.PEDIDO_TRASP_DET.AddPEDIDO_TRASP_DETRow(rowPedidoDet);
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
               MessageBox.Show(ex.Message, "Pedidos Almacen", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        public static void ActualizaPedidoAlmacen(String NoFolio, int Origen, int Destino, decimal Total,
                           int[] Lote, int[] Sec, String[] ArtId, // String[] TipMedic,
                           String[] Concepto, int[] Cant, decimal[] TotLote, string Referencia)
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand

                ////for (int i=0; i<Lote.Count(); i++)
                ////{
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_upd_pedidos";
                cmd.BindByName = true;

                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("Total", OracleDbType.Double, Total, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Double, Lote[0], ParameterDirection.Input);
                cmd.Parameters.Add("Referen", OracleDbType.Varchar2, Referencia, ParameterDirection.Input);
                // Input Array Lote

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

                ////// IN Array Tipo Medicamento
                ////OracleParameter InTipMedic = cmd.Parameters.Add("TipMedic", OracleDbType.Varchar2);
                ////InArtId.Direction = ParameterDirection.Input;
                ////InArtId.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                ////InArtId.Value = TipMedic;

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


                // OUT parameter
                OracleParameter pPedido =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                // Execute the command
                cmd.ExecuteNonQuery();
                ////}

               MessageBox.Show("Se Actualizo el pedido ", "Pedido Almacen", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al Actualizar el pedido: " + Environment.NewLine + ex.Message, "Pedido Almacen", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static void InsertaPedidoAlmacen(String Usuario, int Origen, int Destino, decimal Total,
                           int[] Lote, int[] Sec, String[] ArtId,String[] Concepto, int[] Cant, 
                           decimal[] TotLote, int id_motivo_pedido,string Referencia)
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_ins_pedido";
                cmd.BindByName = true;

                cmd.Parameters.Add("UsuarioID", OracleDbType.Varchar2, Usuario, ParameterDirection.Input);
                cmd.Parameters.Add("Origen", OracleDbType.Int16, Origen, ParameterDirection.Input);
                cmd.Parameters.Add("Destino", OracleDbType.Int16, Destino, ParameterDirection.Input);
                cmd.Parameters.Add("Total", OracleDbType.Double, Total, ParameterDirection.Input);
                
                ///AVM 08-04-2015 -- sE AGREGA EL ID DEL MOTIVO DEL PEDIDO
                cmd.Parameters.Add("Motivo", OracleDbType.Int16, id_motivo_pedido, ParameterDirection.Input);
                ///AVM 14-04-2015 -- S E AGREGA la referencia, solo será capturada cuando la sucursal sea "Almacen 50"
                cmd.Parameters.Add("Referen", OracleDbType.Varchar2, Referencia, ParameterDirection.Input);
                
                // Input Array Motivo
                /*
                 * OracleParameter InMotivo = cmd.Parameters.Add("Motivo", OracleDbType.Varchar2);
                InMotivo.Direction = ParameterDirection.Input;
                InMotivo.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InMotivo.Value = motivo;
                */
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

                // OUT parameter
                OracleParameter pPedido =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pPedido.Value.ToString()))
                {
                   MessageBox.Show("Se creo el pedido con el Folio " + pPedido.Value.ToString(), "Pedido Almacen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al crear el pedido: " + Environment.NewLine + ex.Message, "Pedido Almacen", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static int CancelPedido(string NoFolio, string NoLote)
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            String ProductName = "Pedidos Almacen";
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_Cancela";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int16, NoLote, ParameterDirection.Input);

                // Execute the command
                cmd.ExecuteNonQuery();

               MessageBox.Show(pCancela.Value.ToString() + " - El Pedido se Cancelo", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return Convert.ToInt32(pCancela.Value.ToString());
            }
            catch (OracleException Oex)
            {
                switch (Oex.Number)
                {
                    case 1:
                       MessageBox.Show("Error intentando insertar datos duplicados" + Environment.NewLine, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 12545:
                       MessageBox.Show("La base de datos NO esta disponible" + Environment.NewLine, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                       MessageBox.Show("Database error:" + System.Environment.NewLine + Oex.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return Oex.Number * -1;
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static int DuplicaPedido(string NoFolio, string NoLote, string Origen)
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            String ProductName = "Pedidos Almacen";
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_DuplicaPedido";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int16, NoLote, ParameterDirection.Input);
                cmd.Parameters.Add("Origen", OracleDbType.Varchar2, Origen, ParameterDirection.Input);

                // Execute the command
                cmd.ExecuteNonQuery();

               MessageBox.Show("  El Pedido se duplico con el folio:" + pCancela.Value.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return 0;
            }
            catch (OracleException Oex)
            {
                switch (Oex.Number)
                {
                    case 1:
                       MessageBox.Show("Error intentando insertar datos duplicados" + Environment.NewLine, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 12545:
                       MessageBox.Show("La base de datos NO esta disponible" + Environment.NewLine, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                       MessageBox.Show("Database error:" + System.Environment.NewLine + Oex.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return Oex.Number * -1;
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETDataTable GetPedidoEoQ(SIFModelo.Sucursal Sucursal)
        {
            Cursor.Current = Cursors.WaitCursor;

            // int nRow = 1, ind = 0;

            SIFModelo.Inventarios.InventarioDataSet DataSet = new SIFModelo.Inventarios.InventarioDataSet();
            SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASPDataTable dtPedido = DataSet.PEDIDO_TRASP;

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                dtPedido.Clear();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_get_EoQ";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pPedido = cmd.Parameters.Add("EoQ", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("SucId", OracleDbType.Varchar2, Sucursal.SucursalesID.ToString(), ParameterDirection.Input);

                OracleDataReader _rdrObj = cmd.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    //Grd_PedidoDet.Rows.Clear();
                    short i = 0;
                    while (_rdrObj.Read())
                    {
                        // Data Table Pedido

                        SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow rowPedidoDet = DataSet.PEDIDO_TRASP_DET.NewPEDIDO_TRASP_DETRow();

                        rowPedidoDet.ARTICULO_ID = _rdrObj.GetString(_rdrObj.GetOrdinal("ARTICULO"));
                        rowPedidoDet.NOMBRE1 = _rdrObj.GetString(_rdrObj.GetOrdinal("NOMBRE"));
                        rowPedidoDet.SUCURSAL_ID = _rdrObj.GetInt32(_rdrObj.GetOrdinal("SUCURSAL_ID"));
                        rowPedidoDet.CANTIDAD_SOLIC = _rdrObj.GetInt32(_rdrObj.GetOrdinal("EXISTENCIAS"));
                        rowPedidoDet.EOQ = _rdrObj.GetInt32(_rdrObj.GetOrdinal("EOQ"));
                        rowPedidoDet.FOLIO = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("PEDIDO")).ToString();
                        rowPedidoDet.TIPO = _rdrObj.GetString(_rdrObj.GetOrdinal("TIPO"));
                        rowPedidoDet.LOTE = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("LOTE"));
                        rowPedidoDet.PRECIO = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("PEDIDO"));
                        rowPedidoDet.CONCEPTO = _rdrObj.GetString(_rdrObj.GetOrdinal("NOMBRE"));
                        rowPedidoDet.PARTIDA = i;
                        i++;
                        //rowPedidoDet.CANTIDAD_SOLIC = _rdrObj.GetInt32(_rdrObj.GetOrdinal("PRECIO"));
                        // rowPedidoDet.SUCURSAL = _rdrObj.GetInt32(_rdrObj.GetOrdinal("SUCURSAL"));
                        DataSet.PEDIDO_TRASP_DET.AddPEDIDO_TRASP_DETRow(rowPedidoDet);

                        ////Grd_PedidoDet.Rows.Add(nRow);
                        ////Grd_PedidoDet["Col_LotePedDet", ind].Value = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Lote"));
                        ////Grd_PedidoDet["Col_CodigoPedDet", ind].Value = _rdrObj.GetString(_rdrObj.GetOrdinal("Articulo"));
                        ////Grd_PedidoDet["Col_DescPedDet", ind].Value = _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre"));
                        ////Grd_PedidoDet["Col_CantidadPedDet", ind].Value = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido"));
                        ////ind++;
                    }
                    ////SIFUtils.AutoNumberRowsForGridView(Grd_PedidoDet);
                }
                else
                {
                    ////Grd_PedidoDet.Rows.Clear();
                   MessageBox.Show("NO existe información de Pedidos EoQ para la sucursal " + Sucursal.Nombre, "Pedidos Almacen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                _rdrObj.Close();
                _rdrObj.Dispose();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Pedidos Almacen", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            return DataSet.PEDIDO_TRASP_DET;
        }

        public static DataTable PedidoDet(string Folio, int Lote)
        {
            Cursor.Current = Cursors.WaitCursor;

            int nRow = 1, ind = 0;
            DataTable dtPedido = new DataTable();
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            String ProductName = "Pedidos Almacen";
            try
            {
                conn.Open();

                dtPedido.Clear();
                dtPedido.Columns.Add("lote", typeof(int));
                dtPedido.Columns.Add("id", typeof(string));
                dtPedido.Columns.Add("nombre", typeof(string));
                dtPedido.Columns.Add("cantidad", typeof(int));
                dtPedido.Columns.Add("precio", typeof(double));
                dtPedido.Columns.Add("total", typeof(double), "cantidad * precio");
                dtPedido.PrimaryKey = new DataColumn[] { dtPedido.Columns["id"] };

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_get_peddeta";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pPedido = cmd.Parameters.Add("Det", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Decimal, Lote, ParameterDirection.Input);

                OracleDataReader _rdrObj = cmd.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    //Grd_PedidoDet.Rows.Clear();

                    while (_rdrObj.Read())
                    {
                        // Data Table Pedido

                        DataRow RegArt = dtPedido.Rows.Find(_rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")));
                        if (RegArt == null)
                            dtPedido.Rows.Add(_rdrObj.GetDecimal(_rdrObj.GetOrdinal("Lote")),
                                           _rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido")),
                                               _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Precio")));
                        else
                            RegArt["cantidad"] = int.Parse(RegArt["cantidad"].ToString()) + _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido"));



                        ////Grd_PedidoDet.Rows.Add(nRow);
                        ////Grd_PedidoDet["Col_LotePedDet", ind].Value = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("lote"));
                        ////Grd_PedidoDet["Col_CodigoPedDet", ind].Value = _rdrObj.GetString(_rdrObj.GetOrdinal("articulo_id"));
                        ////Grd_PedidoDet["Col_DescPedDet", ind].Value = _rdrObj.GetString(_rdrObj.GetOrdinal("concepto"));
                        ////Grd_PedidoDet["Col_CantidadPedDet", ind].Value = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("cantidad_solic"));

                        ind++;
                    }

                }
                else
                {
                    //Grd_PedidoDet.Rows.Clear();
                   MessageBox.Show("NO existe información de Pedidos...", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                _rdrObj.Close();
                _rdrObj.Dispose();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            return dtPedido;
        }

        public static void ActEstatus(string Folio, int[] Lote)
        {
            OracleConnection connl = new OracleConnection(Helpers.ConnectionString.Connection());
            string ProductName = "Pedidos Almacen";
            try
            {
                // UpDate Local Pedido_Trasp
                connl.Open();
                // Create an OracleCommand
                OracleCommand cmd = connl.CreateCommand();
                cmd.CommandText = "update pedido_trasp set activo='P' where folio=" + Folio;
                cmd.BindByName = true;


                // Execute the command
                cmd.ExecuteNonQuery();

               MessageBox.Show("Se actualizo el pedido ", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                if (null != connl)
                {
                    connl.Close();
                    connl.Dispose();
                   //OracleConnection.ClearPool(connl);
                }
            }
        }


        public static void EnviaPedidoX(string Folio, int[] Lote, int Origen, int Destino,
                                 double Total, int[] Sec, String[] ArtId,
                                 String[] Concepto, int[] Cant, int[] CantE, double[] TotLote)
        {
            OracleConnection connl = new OracleConnection(Helpers.ConnectionString.Connection());
            string ProductName = "Pedidos Almacen";
            try
            {
                // UpDate Local Pedido_Trasp
                connl.Open();
                // Create an OracleCommand
                OracleCommand cmd = connl.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                // Insert Remote Almacen Traspaso
                ////OracleCommand cmdr = connl.CreateCommand();
                ////cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_ins_traspaso";
                cmd.BindByName = true;

                cmd.Parameters.Add("FolioP", OracleDbType.Int64, Folio, ParameterDirection.Input);
                cmd.Parameters.Add("Origen", OracleDbType.Int16, Origen, ParameterDirection.Input);
                cmd.Parameters.Add("Destino", OracleDbType.Int16, Destino, ParameterDirection.Input);
                cmd.Parameters.Add("Total", OracleDbType.Double, Total, ParameterDirection.Input);

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

                OracleParameter InCantE = cmd.Parameters.Add("CantE", OracleDbType.Decimal);
                InCantE.Direction = ParameterDirection.Input;
                InCantE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantE.Value = CantE;

                // IN Array Total Lote
                OracleParameter InTotLote = cmd.Parameters.Add("TotLote", OracleDbType.Double);
                InTotLote.Direction = ParameterDirection.Input;
                InTotLote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InTotLote.Value = TotLote;

                cmd.Parameters.Add("Usuario", OracleDbType.Varchar2, "POR ASIGNAR", ParameterDirection.Input);
                cmd.Parameters.Add("Activo", OracleDbType.Varchar2, "S", ParameterDirection.Input);
                // OUT parameter
                OracleParameter pTraspaso =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pTraspaso.Value.ToString()))
                {
                   MessageBox.Show("Se creo el pedido con el Folio " + pTraspaso.Value.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cmd.Parameters.Clear();
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_upd_edo_pedido";
                cmd.BindByName = true;

                foreach (int i in Lote.Distinct())
                {
                    cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                    cmd.Parameters.Add("NoLote", OracleDbType.Int16, i, ParameterDirection.Input);
                    cmd.Parameters.Add("Edo", OracleDbType.Char, 'P', ParameterDirection.Input);
                    // OUT parameter
                    OracleParameter pPedido =
                        cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                    // Execute the command
                    cmd.ExecuteNonQuery();

                    if (!string.IsNullOrEmpty(pPedido.Value.ToString()))
                    {
                        if (Convert.ToDecimal(pPedido.Value.ToString()) > 0)
                           MessageBox.Show("Se actualizo el pedido con el Folio " + Folio, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    cmd.Parameters.Clear();
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                if (null != connl)
                {
                    connl.Close();
                    connl.Dispose();
                   //OracleConnection.ClearPool(connl);
                }
            }
        }

        // ROMA 14AGO2013
        public static string CreaPedidoEspecial(string Usuario, int Origen, int Destino, string[] ArtId, int[] Cant, int ID_MOTIVO_PEDIDO, string REFERENCIA)
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_ins_pedido_especial";
                cmd.BindByName = true;

                cmd.Parameters.Add("UsrID", OracleDbType.Varchar2, Usuario, ParameterDirection.Input);
                cmd.Parameters.Add("Origen", OracleDbType.Int16, Origen, ParameterDirection.Input);
                cmd.Parameters.Add("Destino", OracleDbType.Int16, Destino, ParameterDirection.Input);
                
                ///AVM SE AGREGA EL MOTIVO DEL PEDIDO Y LA REFERENCIA
                cmd.Parameters.Add("ID_MOTIVO_PED", OracleDbType.Int16, ID_MOTIVO_PEDIDO, ParameterDirection.Input);
                cmd.Parameters.Add("REFEREN", OracleDbType.Varchar2, REFERENCIA, ParameterDirection.Input);
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

                // OUT parameter
                OracleParameter pPedido =
                    cmd.Parameters.Add("Folio", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                //if (!string.IsNullOrEmpty(pPedido.Value.ToString()))
                //{
                //    //MessageBoxEx.Show("Se creo el pedido con el Folio " + pPedido.Value.ToString(), "Pedido Especial Almacen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return pPedido.Value.ToString();
                //}

                return pPedido.Value.ToString();
            }
            catch (Exception ex)
            {
                //MessageBoxEx.Show("Error al crear el pedido: " + Environment.NewLine + ex.Message, "Pedido Almacen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error al crear el pedido: " + Environment.NewLine + ex.Message;
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

        public static int UpdateEdoPedido(string NoFolio, string NoLote)
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            String ProductName = "Pedidos Almacen";
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_upd_edo_pedido";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pPedido = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int16, NoLote, ParameterDirection.Input);
                cmd.Parameters.Add("Edo", OracleDbType.Char, 'P', ParameterDirection.Input);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pPedido.Value.ToString()))
                {
                    if (Convert.ToDecimal(pPedido.Value.ToString()) > 0)
                       MessageBox.Show("Se actualizo el pedido con el Folio " + NoFolio, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //               MessageBox.Show(pCancela.Value.ToString() + " - El Pedido se Cancelo", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return Convert.ToInt32(pPedido.Value.ToString());
            }
            catch (OracleException Oex)
            {
                switch (Oex.Number)
                {
                    case 1:
                       MessageBox.Show("Error intentando insertar datos duplicados" + Environment.NewLine, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 12545:
                       MessageBox.Show("La base de datos NO esta disponible" + Environment.NewLine, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                       MessageBox.Show("Database error:" + System.Environment.NewLine + Oex.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return Oex.Number * -1;
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static string CreaPedidoTraspaso(string NoFolio, string NoLote, int Origen, int Destino)
        {
            string result = string.Empty;
            string pError = "Error";
            Regex objNotErrorPattern = new Regex(@"[^Error]");

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_ins_pedido_traspaso";
                cmd.BindByName = true;

                cmd.Parameters.Add("FolioP", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("LoteP", OracleDbType.Int16, NoLote, ParameterDirection.Input);
                cmd.Parameters.Add("Origen", OracleDbType.Int16, Origen, ParameterDirection.Input);
                cmd.Parameters.Add("Destino", OracleDbType.Int16, Destino, ParameterDirection.Input);

                // OUT parameter
                OracleParameter pPedido =
                    cmd.Parameters.Add("OutParam", OracleDbType.RefCursor, ParameterDirection.Output);

                OracleDataReader _rdrObj = cmd.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        result += _rdrObj.GetValue(0).ToString(); // _rdrObj.GetString(_rdrObj.GetOrdinal("pPedido"));
                    }
                    if (!Regex.IsMatch(result, pError))
                    {
                        UpdateEdoPedido(NoFolio, NoLote);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                return "Error al enviar el pedido: " + Environment.NewLine + ex.Message;
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

        // ROMA 14AGO2013

        public static bool ImportaPedidoAlmacen(int UsuarioID,/*SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASPRow traspaso*/  int sDestino, int idMotivo, SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETDataTable pEDIDO_TRASP_DETDataTable)
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            String ProductName = "Pedidos Almacen";
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_imp_traspasoD";
                cmd.BindByName = true;

                // OUT REF CURSOR bound

                cmd.Parameters.Add("UsuarioID", OracleDbType.Varchar2, UsuarioID.ToString(), ParameterDirection.Input);
                /*cmd.Parameters.Add("Folio", OracleDbType.Varchar2, traspaso.FOLIO, ParameterDirection.Input);*/
                cmd.Parameters.Add("idMotivo", OracleDbType.Int32, idMotivo, ParameterDirection.Input);
               cmd.Parameters.Add("Destino", OracleDbType.Int32, sDestino, ParameterDirection.Input);
                /*
                cmd.Parameters.Add("Total", OracleDbType.Decimal, traspaso.TOTAL, ParameterDirection.Input);
                cmd.Parameters.Add("Lote", OracleDbType.Int32, traspaso.LOTE, ParameterDirection.Input);*/

                List<int> LSec = new List<int>();
                List<string> LArtId = new List<string>();
                //List<string> LConcepto = new List<string>();
                List<decimal> LCant = new List<decimal>();
                //List<decimal> LPrecio = new List<decimal>();
                //List<string> LSuc = new List<string>();

                foreach (var detalle in pEDIDO_TRASP_DETDataTable)
                {
                    LSec.Add(detalle.PARTIDA);
                    LArtId.Add(detalle.ARTICULO_ID);
                   // LConcepto.Add(detalle.CONCEPTO);
                    LCant.Add(detalle.CANTIDAD_SOLIC);
                    //LPrecio.Add(detalle.PRECIO);
                    //LSuc.Add(detalle.SUCURSAL_ID.ToString());
                }

                OracleParameter Sec = cmd.Parameters.Add("Sec", OracleDbType.Decimal);
                Sec.Direction = ParameterDirection.Input;
                Sec.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                Sec.Value = LSec.ToArray();

                OracleParameter ArtId = cmd.Parameters.Add("ArtId", OracleDbType.Varchar2);
                ArtId.Direction = ParameterDirection.Input;
                ArtId.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                ArtId.Value = LArtId.ToArray();

                /*OracleParameter Concepto = cmd.Parameters.Add("Concepto", OracleDbType.Varchar2);
                Concepto.Direction = ParameterDirection.Input;
                Concepto.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                Concepto.Value = LConcepto.ToArray();*/

                OracleParameter Cant = cmd.Parameters.Add("Cant", OracleDbType.Decimal);
                Cant.Direction = ParameterDirection.Input;
                Cant.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                Cant.Value = LCant.ToArray();

                /*OracleParameter Precio = cmd.Parameters.Add("Precio", OracleDbType.Decimal);
                Precio.Direction = ParameterDirection.Input;
                Precio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                Precio.Value = LPrecio.ToArray();*/
                /*
                OracleParameter Sucursal = cmd.Parameters.Add("Sucursal", OracleDbType.Varchar2);
                Sucursal.Direction = ParameterDirection.Input;
                Sucursal.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                Sucursal.Value = LSuc.ToArray();
                */
                OracleParameter OutParam = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                //OracleParameter pPedido = cmd.Parameters.Add("Hdr", OracleDbType.RefCursor, ParameterDirection.Output);

                // Execute the command
                //OracleDataReader _rdrObj = cmd.ExecuteReader();
                cmd.ExecuteNonQuery();
                /*

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {



                        MessageBox.Show("El articulo no existe en el catalogo: " + (_rdrObj.GetString(_rdrObj.GetOrdinal("Articulo_id"))));
                        /*   DsInventario.TRASPASO_DET.AddTRASPASO_DETRow(_rdrObj.GetString(_rdrObj.GetOrdinal("Folio")),
                                                                         _rdrObj1.GetInt16(_rdrObj1.GetOrdinal("Lote")),
                                                                         _rdrObj1.GetInt16(_rdrObj1.GetOrdinal("num_partida")),
                                                                         _rdrObj1.GetString(_rdrObj1.GetOrdinal("Articulo")),
                                                                         _rdrObj1.GetString(_rdrObj1.GetOrdinal("Nombre")),
                                                                         _rdrObj1.GetInt32(_rdrObj1.GetOrdinal("Pedido")),
                                                                         _rdrObj1.GetInt32(_rdrObj1.GetOrdinal("Enviado")),
                                                                         _rdrObj1.GetInt32(_rdrObj1.GetOrdinal("Recibido")),
                                                                         _rdrObj1.GetDouble(_rdrObj1.GetOrdinal("Precio")),
                                                                         _rdrObj1.GetDouble(_rdrObj1.GetOrdinal("PrecioR")),
                                                                         _rdrObj1.GetString(_rdrObj1.GetOrdinal("Procesado")), // "N",  ROMA12AGO2013
                                                                         Convert.ToInt16(_rdrObj1.GetDecimal(9)), //NoCajas,
                          */
                        //Convert.ToInt16(_rdrObj1.GetOrdinal("Caja")), //_rdrObj1.GetInt16(_rdrObj1.GetOrdinal("Caja")),
                        /*                                             _rdrObj1.GetString(_rdrObj1.GetOrdinal("Solicitado")),
                                                                     RefLote,
                                                                     caducidad);
                       

                    }
                }*/
                if (OutParam.Value.ToString().IsFloatPositive())
                {
                    MessageBox.Show("Se creó el traspaso " + OutParam.Value.ToString());
                    return true;
                }

            }
            catch (OracleException Oex)
            {
                switch (Oex.Number)
                {
                    case 1:
                       MessageBox.Show("Error intentando insertar datos duplicados" + Environment.NewLine, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 12545:
                       MessageBox.Show("La base de datos NO esta disponible" + Environment.NewLine, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                       MessageBox.Show("Database error:" + System.Environment.NewLine + Oex.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
            return true;
        }


        public static Int16 ResgistraEmbarque(SIFModelo.BitEmbarque embarque)
        {

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_ins_bit_de_embarque";
                cmd.BindByName = true;

               



                cmd.Parameters.Add("Pfolio_traspaso", OracleDbType.Varchar2, embarque.folio_traspaso, ParameterDirection.Input);
                cmd.Parameters.Add("Plote", OracleDbType.Int16, embarque.lote, ParameterDirection.Input);
                cmd.Parameters.Add("Psuc_origen", OracleDbType.Int16, embarque.suc_origen, ParameterDirection.Input);
                cmd.Parameters.Add("Psuc_destino", OracleDbType.Int16, embarque.suc_destino, ParameterDirection.Input);
                cmd.Parameters.Add("Pusuario_envia", OracleDbType.Int16, embarque.usuario_envia, ParameterDirection.Input);
                cmd.Parameters.Add("Pdistribuidor_id", OracleDbType.Int16, embarque.distribuidor_id, ParameterDirection.Input);
                cmd.Parameters.Add("Pcaja_grande", OracleDbType.Int16, embarque.caja_grande, ParameterDirection.Input);
                cmd.Parameters.Add("Pcaja_chica", OracleDbType.Int16, embarque.caja_chica, ParameterDirection.Input);
                cmd.Parameters.Add("Pbulto", OracleDbType.Int16, embarque.bulto, ParameterDirection.Input);
                cmd.Parameters.Add("Pbolsa", OracleDbType.Int16, embarque.bolsa, ParameterDirection.Input);
                cmd.Parameters.Add("Ptemperatura", OracleDbType.Int16, embarque.temperatura, ParameterDirection.Input);
                cmd.Parameters.Add("Pfactura_controlados", OracleDbType.Int16, embarque.factura_controlados, ParameterDirection.Input);
                cmd.Parameters.Add("Pobservaciones", OracleDbType.Varchar2, embarque.observaciones, ParameterDirection.Input);
                cmd.Parameters.Add("Pactivo", OracleDbType.Varchar2, embarque.activo, ParameterDirection.Input);
                cmd.Parameters.Add("prefrigerados", OracleDbType.Varchar2, embarque.refrigerados, ParameterDirection.Input);
                cmd.Parameters.Add("pIdUnidadDistribucion", OracleDbType.Varchar2, embarque.IdUnidadDistribucion, ParameterDirection.Input);
                

                // OUT parameter
                OracleParameter pPedido =
                    cmd.Parameters.Add("OutParam", OracleDbType.Int16, ParameterDirection.Output);

                OracleDataReader _rdrObj = cmd.ExecuteReader();

                if (pPedido.Value.ToString().IsIntegerPositive())
                {
                    return 1;

                }
                else
                {
                    return 0;
                }

                
            }
            catch (Exception ex)
            {
                return -1;
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


        public static List<SIFModelo.Catalogo.CatDistribuidores> get_distribuidores(string activo)
        {

            List<SIFModelo.Catalogo.CatDistribuidores> rows = new List<SIFModelo.Catalogo.CatDistribuidores>();

            string sentencia = "SELECT    usuarios_id,    nombre_completo,    rfc,    direccion,    colina,    num_licencia,    activo "+
                                " FROM cs_distribuidores WHERE activo LIKE '%"+activo+"' ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {                  
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Catalogo.CatDistribuidores registro = new SIFModelo.Catalogo.CatDistribuidores();

                            registro.Usuarios_id =Int32.Parse(oreader["USUARIOS_ID"].ToString());
                            registro.Nombre_completo = oreader["NOMBRE_COMPLETO"].ToString();
                            registro.Rfc = oreader["RFC"].ToString();
                            registro.Direccion = oreader["DIRECCION"].ToString();
                            registro.Colina = oreader["COLINA"].ToString();
                            registro.Num_licencia = oreader["NUM_LICENCIA"].ToString();
                            registro.Activo = oreader["ACTIVO"].ToString();
                            rows.Add( registro);
                        }
                        return rows;
                    }

                }

            }
            return null;
        }


        public static List<SIFModelo.Catalogo.CatUnidadesDistribucion> get_unidadescDitribucion(string activo)
        {

            List<SIFModelo.Catalogo.CatUnidadesDistribucion> rows = new List<SIFModelo.Catalogo.CatUnidadesDistribucion>();

            string sentencia = "SELECT    ID,PERMISO_SCT,NUMERO_PERMISO_SCT,CONFIGURACION_VEHICULAR,PLACA,MODELO,DESCRIPCION,ASEGURA_RESP_CIVIL,POLIZA_RESP_CIVIL,ACTIVO " +
                                " FROM CAT_UNIDADES_DISTRIBUCION WHERE activo LIKE '%" + activo + "' ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Catalogo.CatUnidadesDistribucion registro = new SIFModelo.Catalogo.CatUnidadesDistribucion();

                            registro.Id = int.Parse(oreader["ID"].ToString());
                            registro.Permiso_sct = oreader["PERMISO_SCT"].ToString();
                            registro.Numero_permiso_sct = oreader["NUMERO_PERMISO_SCT"].ToString();
                            registro.Configuracion_vehicular = oreader["CONFIGURACION_VEHICULAR"].ToString();
                            registro.Placa = oreader["PLACA"].ToString();
                            registro.Modelo = oreader["MODELO"].ToString();
                            registro.Descripcion = oreader["DESCRIPCION"].ToString();
                            registro.Asegura_resp_civil = oreader["ASEGURA_RESP_CIVIL"].ToString();
                            registro.Poliza_resp_civil = oreader["POLIZA_RESP_CIVIL"].ToString();
                            registro.Activo = oreader["ACTIVO"].ToString();
                            rows.Add( registro);
                        }
                        return rows;
                    }

                }

            }
            return null;
        }
        public static bool actializaTraspasoDistribuidor(string Folio, int Lote, int idD, int idUD)
        {


            OracleConnection connl = new OracleConnection(Helpers.ConnectionString.Connection());
            
            try
            {
                
                connl.Open();
                // Create an OracleCommand
                OracleCommand cmd = connl.CreateCommand();
                cmd.CommandText = "update traspaso  set ID_DISTRIBUIDOR="+idD+ ", ID_UNIDAD_DISTRIBUCION="+idUD+" where folio='" + Folio+"'";
                cmd.BindByName = true;


                // Execute the command
                cmd.ExecuteNonQuery();

               MessageBox.Show("Se actualizo el traspaso ","Traspaso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;



            }
            catch (Exception ex)
            {
                
               MessageBox.Show(ex.Message, "Traspaso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (null != connl)
                {
                    connl.Close();
                    connl.Dispose();
                    //OracleConnection.ClearPool(connl);
                }
            }
        }





    }
}
