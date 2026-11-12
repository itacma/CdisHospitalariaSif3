using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data;
using DevComponents.DotNetBar;
using System.ComponentModel;


namespace SIFDatos.Inventario
{
    public class TraspasoAlmacen
    {
        public static SIFModelo.Inventarios.InventarioDataSet GetTraspasos(string Ini, string Fin, String Activo, String Folio, 
                                                                           int Suc, string Tipo, int sucursalDestino, int tipoPetido)
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
                if (Activo == "SE") //ESCANEADOS ABIERTOS
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_PEDIDO_TRASP.sp_get_traspasos_escaneados";
                    cmd.BindByName = true;

                    // OUT REF CURSOR bound
                    OracleParameter pPedido = cmd.Parameters.Add("Hdr", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.Parameters.Add("FecIni", OracleDbType.Varchar2, Ini, ParameterDirection.Input);
                    cmd.Parameters.Add("FecFin", OracleDbType.Varchar2, Fin, ParameterDirection.Input);
                    cmd.Parameters.Add("Tipo", OracleDbType.Varchar2, Tipo, ParameterDirection.Input);
                    cmd.Parameters.Add("ActivoT", OracleDbType.Varchar2, Activo, ParameterDirection.Input);
                    cmd.Parameters.Add("Suc", OracleDbType.Varchar2, Suc, ParameterDirection.Input);
                    if (sucursalDestino == -1 || sucursalDestino == 0)
                        cmd.Parameters.Add("IdSucDes", OracleDbType.Varchar2, "-1", ParameterDirection.Input);
                    else
                        cmd.Parameters.Add("IdSucDes", OracleDbType.Varchar2, sucursalDestino, ParameterDirection.Input);
                    if (tipoPetido == -1 || tipoPetido == 0)
                        cmd.Parameters.Add("IdTipoPetido", OracleDbType.Varchar2, "-1", ParameterDirection.Input);
                    else
                        cmd.Parameters.Add("IdTipoPetido", OracleDbType.Varchar2, tipoPetido, ParameterDirection.Input);
                }
                else
                if (Activo == "I")
                {
                    if (Folio == "")
                    {
                        cmd.CommandText = "SELECT Folio, Lote, TO_CHAR(Fecha_env, 'DD/MM/YYYY HH24:MI:SS') Fecha, " +
                                              " ( SELECT Sucursal_Origen || ' - ' || suc.nombre FROM cat_sucursales suc " +
                                              " WHERE ped.Sucursal_Origen = suc.sucursales_id ) Origen,  ( SELECT Sucursal_Destino || ' - ' || suc.nombre " +
                                              " FROM cat_sucursales suc  WHERE ped.Sucursal_Destino = suc.sucursales_id ) Destino, Usuario_Envia, Usuario_Recibe, Activo,REFERENCIA, NVL(ID_MOTIVO_TRANS,0) AS ID_MOTIVO_TRANS" +
                                              " FROM traspaso ped  where Folio in (Select Folio from traspaso_insidencia)";
                        cmd.BindByName = true;
                    }
                    else
                    {
                        cmd.CommandText = "SELECT Folio, Lote, TO_CHAR(Fecha_env, 'DD/MM/YYYY HH24:MI:SS') Fecha, " +
                                          " ( SELECT Sucursal_Origen || ' - ' || suc.nombre FROM cat_sucursales suc " +
                                          " WHERE ped.Sucursal_Origen = suc.sucursales_id ) Origen,  ( SELECT Sucursal_Destino || ' - ' || suc.nombre " +
                                          " FROM cat_sucursales suc  WHERE ped.Sucursal_Destino = suc.sucursales_id ) Destino, Usuario_Envia, Usuario_Recibe, Activo,REFERENCIA, NVL(ID_MOTIVO_TRANS,0) AS ID_MOTIVO_TRANS" +
                                          " FROM traspaso ped  where Folio in (Select Folio from traspaso_insidencia) and Folio like '%" + Folio + "%'";
                        cmd.BindByName = true;
                    }
                }
                else
                {
                    if (Folio == "")
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PKG_PEDIDO_TRASP.sp_get_traspasos";
                        cmd.BindByName = true;

                        // OUT REF CURSOR bound
                        OracleParameter pPedido = cmd.Parameters.Add("Hdr", OracleDbType.RefCursor, ParameterDirection.Output);
                        cmd.Parameters.Add("FecIni", OracleDbType.Varchar2, Ini, ParameterDirection.Input);
                        cmd.Parameters.Add("FecFin", OracleDbType.Varchar2, Fin, ParameterDirection.Input);
                        cmd.Parameters.Add("Tipo", OracleDbType.Varchar2, Tipo, ParameterDirection.Input);
                        cmd.Parameters.Add("ActivoT", OracleDbType.Varchar2, Activo, ParameterDirection.Input);
                        cmd.Parameters.Add("Suc", OracleDbType.Varchar2, Suc, ParameterDirection.Input);
                        if (sucursalDestino == -1 || sucursalDestino == 0)
                            cmd.Parameters.Add("IdSucDes", OracleDbType.Varchar2, "-1", ParameterDirection.Input);
                        else
                            cmd.Parameters.Add("IdSucDes", OracleDbType.Varchar2, sucursalDestino, ParameterDirection.Input);
                        if (tipoPetido == -1 || tipoPetido == 0)
                            cmd.Parameters.Add("IdTipoPetido", OracleDbType.Varchar2, "-1", ParameterDirection.Input);
                        else
                            cmd.Parameters.Add("IdTipoPetido", OracleDbType.Varchar2, tipoPetido, ParameterDirection.Input);
                    }
                    else
                    {
                        cmd.CommandText = "SELECT Folio, Lote, TO_CHAR(Fecha_env, 'DD/MM/YYYY HH24:MI:SS') Fecha, " +
                                                " ( SELECT Sucursal_Origen || ' - ' || suc.nombre FROM cat_sucursales suc " +
                                                  " WHERE ped.Sucursal_Origen = suc.sucursales_id ) Origen,  ( SELECT Sucursal_Destino || ' - ' || suc.nombre " +
                                                  " FROM cat_sucursales suc  WHERE ped.Sucursal_Destino = suc.sucursales_id ) Destino, Usuario_Envia, Usuario_Recibe, ped.Activo,REFERENCIA, " +
                                                " TO_CHAR (FECHA_REC, 'DD/MM/YYYY HH24:MI:SS') Fec_Recibe, " +
                                                " TOTAL,NVL(ID_MOTIVO_TRANS,0) AS ID_MOTIVO_TRANS, tp.NOMBRE MOTIVO_PEDIDO, " +
                                                " ( SELECT COUNT(det.articulo_id) " +
                                                   "FROM traspaso_det det " +
                                                   "WHERE det.folio = ped.FOLIO AND det.lote = ped.LOTE ) num_lineas, " + 
                                                " ( SELECT COUNT(det.articulo_id) " + 
                                                   "FROM traspaso_det det " +
                                                   "WHERE det.folio = ped.FOLIO AND det.lote = ped.LOTE AND det.CANTIDAD_ENVIADA > 0 ) TOTAL_ESCANEADOS " +
                                          "FROM traspaso ped  LEFT OUTER JOIN " +
                                                "CAT_TIPO_PEDIDO tp ON NVL(ped.ID_MOTIVO_TRANS,0) = tp.ID " +
                                          "WHERE Folio like '%" + Folio  +"%' or Referencia like '%"+Folio+"%'";
                        cmd.BindByName = true;
                    }
                }
                OracleDataReader _rdrObj = cmd.ExecuteReader();

                while (_rdrObj.Read())
                {                    
                    SIFModelo.Inventarios.InventarioDataSet.TRASPASORow rw = DsInventario.TRASPASO.NewTRASPASORow();
                    rw.FOLIO = _rdrObj.GetString(_rdrObj.GetOrdinal("FOLIO"));
                    rw.LOTE = _rdrObj.GetInt16(_rdrObj.GetOrdinal("Lote"));
                    rw.FECHA = _rdrObj.GetString(_rdrObj.GetOrdinal("Fecha"));
                    rw.ORIGEN = _rdrObj.GetString(_rdrObj.GetOrdinal("Origen"));
                    rw.DESTINO = _rdrObj.GetString(_rdrObj.GetOrdinal("Destino"));
                    rw.USUARIO_ENVIA = _rdrObj.GetString(_rdrObj.GetOrdinal("Usuario_Envia"));
                    if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("REFERENCIA")) == false )
                        rw.REFERENCIA = _rdrObj.GetString(_rdrObj.GetOrdinal("REFERENCIA"));
                    rw.SUCURSAL_DESTINO = short.Parse(_rdrObj.GetString(_rdrObj.GetOrdinal("Destino")).Split('-')[0]);
                    rw.SUCURSAL_ORIGEN = short.Parse(_rdrObj.GetString(_rdrObj.GetOrdinal("Origen")).Split('-')[0]);
                    if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("Usuario_Recibe")) == false)
                    {
                        rw.USUARIO_RECIBE = _rdrObj.GetString(_rdrObj.GetOrdinal("Usuario_Recibe"));
                        // Grd_Pedido["Col_Envia", ind].Value = _rdrObj.GetString(_rdrObj.GetOrdinal("Usuario_Recibe"));
                    }
                    rw.ACTIVO = _rdrObj.GetString(_rdrObj.GetOrdinal("Activo"));
                    // ROMA 12AGO2013
                    /// rw.TOTAL = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Total"));  //AVM se cambia el total por el numero de lineas que vienen en el traspaso.
                    decimal x = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("num_lineas"));
                    rw.TOTAL_LINEAS = int.Parse(x.ToString());
                    if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("Fec_Recibe")) == false)
                        rw.FECHA_REC = DateTime.ParseExact(_rdrObj.GetString(_rdrObj.GetOrdinal("Fec_Recibe")), "dd/MM/yyyy HH:mm:ss", null); // Convert.ToDateTime(_rdrObj.GetString(_rdrObj.GetOrdinal("Fec_Recibe")));
                    // END ROMA 12AGO2013

                    rw.ID_MOTIVO_TRANS = int.Parse(_rdrObj["ID_MOTIVO_TRANS"].ToString());
                    rw.MOTIVO_PEDIDO = _rdrObj["MOTIVO_PEDIDO"].ToString();
                    rw.TOTAL_ESCANEADOS = int.Parse(_rdrObj["TOTAL_ESCANEADOS"].ToString());

                    if ((Activo == "") || (Activo=="I") || (Activo == "SE"))
                        DsInventario.TRASPASO.AddTRASPASORow(rw);
                    else
                    {
                        if (Activo == rw.ACTIVO )
                            DsInventario.TRASPASO.AddTRASPASORow(rw);
                    }
                    if (Tipo == "E")
                    {

                        OracleCommand cmd1 = conn.CreateCommand();
                        cmd1.CommandType = CommandType.StoredProcedure;

                        if (Activo == "I")
                            cmd1.CommandText = "PKG_PEDIDO_TRASP.sp_get_tradeti";
                        else
                            cmd1.CommandText = "PKG_PEDIDO_TRASP.sp_get_tradeta";

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
                                String caducidad = "";
                                String RefLote = "";
                                ////short NoCajas = -1;
                                try
                                {
                                    if (_rdrObj1.IsDBNull(_rdrObj1.GetOrdinal("CADUCIDAD")) == false)
                                        caducidad = _rdrObj1.GetString(_rdrObj1.GetOrdinal("CADUCIDAD"));
                                    if (_rdrObj1.IsDBNull(_rdrObj1.GetOrdinal("REFLOTE")) == false)
                                        RefLote = _rdrObj1.GetString(_rdrObj1.GetOrdinal("REFLOTE"));
                                }
                                catch
                                { }

                                ////Type Caja = _rdrObj1.GetFieldType(9);

                                ////string tipCaja = Caja.FullName;

                                ////if (_rdrObj1.IsDBNull(_rdrObj1.GetOrdinal("caja")) == false)
                                ////    NoCajas = Convert.ToInt16(_rdrObj1.GetDecimal(9)); // Convert.ToInt16(_rdrObj1.GetOrdinal("caja"));
                                ////else
                                ////    NoCajas = 0;


                                if (Activo != "R" || (Activo == "R" & _rdrObj1.GetInt32(_rdrObj1.GetOrdinal("Recibido")) > 0))
                                    DsInventario.TRASPASO_DET.AddTRASPASO_DETRow(_rdrObj.GetString(_rdrObj.GetOrdinal("Folio")),
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
                                        //Convert.ToInt16(_rdrObj1.GetOrdinal("Caja")), //_rdrObj1.GetInt16(_rdrObj1.GetOrdinal("Caja")),
                                                                                  _rdrObj1.GetString(_rdrObj1.GetOrdinal("Solicitado")),
                                                                                  RefLote,
                                                                                  caducidad);

                            }
                        }
                        _rdrObj1.Close();
                        _rdrObj1.Dispose();
                    }
                    else
                    if(Suc!=1  )
                    {
                OracleCommand cmd1 = conn.CreateCommand();
                cmd1.CommandType = CommandType.StoredProcedure;

                if (Activo=="I")
                    cmd1.CommandText = "PKG_PEDIDO_TRASP.sp_get_tradeti";
                else
                    cmd1.CommandText = "PKG_PEDIDO_TRASP.sp_get_tradeta";

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
                        String caducidad = "";
                        String RefLote = "";
                        ////short NoCajas = -1;
                        try
                        {
                            if (_rdrObj1.IsDBNull(_rdrObj1.GetOrdinal("CADUCIDAD")) == false)
                                caducidad = _rdrObj1.GetString(_rdrObj1.GetOrdinal("CADUCIDAD"));
                            if (_rdrObj1.IsDBNull(_rdrObj1.GetOrdinal("REFLOTE")) == false)
                                RefLote = _rdrObj1.GetString(_rdrObj1.GetOrdinal("REFLOTE"));
                        }
                        catch
                        { }

                        ////Type Caja = _rdrObj1.GetFieldType(9);

                        ////string tipCaja = Caja.FullName;

                        ////if (_rdrObj1.IsDBNull(_rdrObj1.GetOrdinal("caja")) == false)
                        ////    NoCajas = Convert.ToInt16(_rdrObj1.GetDecimal(9)); // Convert.ToInt16(_rdrObj1.GetOrdinal("caja"));
                        ////else
                        ////    NoCajas = 0;


                        if (Activo != "R" || (Activo=="R" & _rdrObj1.GetInt32(_rdrObj1.GetOrdinal("Recibido")) > 0 ))
                        DsInventario.TRASPASO_DET.AddTRASPASO_DETRow( _rdrObj.GetString(_rdrObj.GetOrdinal("Folio")),
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
                                                                      //Convert.ToInt16(_rdrObj1.GetOrdinal("Caja")), //_rdrObj1.GetInt16(_rdrObj1.GetOrdinal("Caja")),
                                                                      _rdrObj1.GetString(_rdrObj1.GetOrdinal("Solicitado")),
                                                                      RefLote,
                                                                      caducidad);
                        
                    }
                }
                _rdrObj1.Close();
                _rdrObj1.Dispose();
                }
                }

                _rdrObj.Close();
                _rdrObj.Dispose();
                
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Traspasos Almacen", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static SIFModelo.Inventarios.InventarioDataSet GetTraspasos( String Folio, SIFModelo.Sucursal sucursal)
        {

            SIFModelo.Inventarios.InventarioDataSet DsInventario = new SIFModelo.Inventarios.InventarioDataSet();

            Cursor.Current = Cursors.WaitCursor;

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                
                    cmd.CommandText = " SELECT Folio, Lote, TO_CHAR(Fecha_env, 'DD/MM/YYYY HH24:MI:SS') Fecha, " +
                                      " ( SELECT Sucursal_Origen || ' - ' || suc.nombre FROM cat_sucursales suc " +
                                      " WHERE ped.Sucursal_Origen = suc.sucursales_id ) Origen,  ( SELECT Sucursal_Destino || ' - ' || suc.nombre " +
                                      " FROM cat_sucursales suc  WHERE ped.Sucursal_Destino = suc.sucursales_id ) Destino, Usuario_Envia, Usuario_Recibe, Activo " +
                                      " FROM traspaso ped  where Folio ='" + Folio + "'";
                    cmd.BindByName = true;
                
                OracleDataReader _rdrObj = cmd.ExecuteReader();
                //Grd_Pedido.Rows.Add(_rdrObj.RecordsAffected);

                while (_rdrObj.Read())
                {

                    SIFModelo.Inventarios.InventarioDataSet.TRASPASORow rw = DsInventario.TRASPASO.NewTRASPASORow();
                    rw.FOLIO = _rdrObj.GetString(_rdrObj.GetOrdinal("FOLIO"));
                    rw.LOTE = _rdrObj.GetInt16(_rdrObj.GetOrdinal("Lote"));
                    rw.FECHA = _rdrObj.GetString(_rdrObj.GetOrdinal("Fecha"));

                    rw.ORIGEN = _rdrObj.GetString(_rdrObj.GetOrdinal("Origen"));
                    rw.DESTINO = _rdrObj.GetString(_rdrObj.GetOrdinal("Destino"));
                    rw.USUARIO_ENVIA = _rdrObj.GetString(_rdrObj.GetOrdinal("Usuario_Envia"));
                    rw.SUCURSAL_DESTINO = short.Parse(_rdrObj.GetString(_rdrObj.GetOrdinal("Destino")).Split('-')[0]);
                    rw.SUCURSAL_ORIGEN = short.Parse(_rdrObj.GetString(_rdrObj.GetOrdinal("Origen")).Split('-')[0]);
                    if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("Usuario_Recibe")) == false)
                    {
                        rw.USUARIO_RECIBE = _rdrObj.GetString(_rdrObj.GetOrdinal("Usuario_Recibe"));
                        // Grd_Pedido["Col_Envia", ind].Value = _rdrObj.GetString(_rdrObj.GetOrdinal("Usuario_Recibe"));
                    }
                    rw.ACTIVO = _rdrObj.GetString(_rdrObj.GetOrdinal("Activo"));

                    
                    DsInventario.TRASPASO.AddTRASPASORow(rw);

                    OracleCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandText = "PKG_PEDIDO_TRASP.sp_get_tradeta";
                    cmd1.BindByName = true;

                    // OUT REF CURSOR bound
                    OracleParameter pPedido1 = cmd1.Parameters.Add("Det", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd1.Parameters.Add("NoFolio", OracleDbType.Varchar2, _rdrObj.GetString(_rdrObj.GetOrdinal("FOLIO")), ParameterDirection.Input);
                    cmd1.Parameters.Add("NoLote", OracleDbType.Decimal, _rdrObj.GetInt16(_rdrObj.GetOrdinal("Lote")), ParameterDirection.Input);

                    OracleDataReader _rdrObj1 = cmd1.ExecuteReader();

                    if (_rdrObj1.HasRows)
                    {
                        //Grd_PedidoDet.Rows.Clear();

                        while (_rdrObj1.Read())

                         {  String caducidad=""; 
                            String RefLote="";
                            if (_rdrObj1.IsDBNull(_rdrObj.GetOrdinal("CADUCIDAD")) == false)
                              caducidad=_rdrObj1.GetString(_rdrObj1.GetOrdinal("CADUCIDAD"));
                            if (_rdrObj1.IsDBNull(_rdrObj1.GetOrdinal("REFLOTE")) == false)
                                RefLote = _rdrObj1.GetString(_rdrObj1.GetOrdinal("REFLOTE"));
                            
                                DsInventario.TRASPASO_DET.AddTRASPASO_DETRow(_rdrObj.GetString(_rdrObj.GetOrdinal("Folio")),
                                                                              _rdrObj1.GetInt16(_rdrObj1.GetOrdinal("Lote")),
                                                                              _rdrObj1.GetInt16(_rdrObj1.GetOrdinal("num_partida")),
                                                                              _rdrObj1.GetString(_rdrObj1.GetOrdinal("Articulo")),
                                                                              _rdrObj1.GetString(_rdrObj1.GetOrdinal("Nombre")),
                                                                              _rdrObj1.GetInt32(_rdrObj1.GetOrdinal("Pedido")),
                                                                              _rdrObj1.GetInt32(_rdrObj1.GetOrdinal("Enviado")),
                                                                              _rdrObj1.GetInt32(_rdrObj1.GetOrdinal("Recibido")),
                                                                              _rdrObj1.GetDouble(_rdrObj1.GetOrdinal("Precio")),
                                                                              _rdrObj1.GetDouble(_rdrObj1.GetOrdinal("PrecioR")),
                                                                              "N",
                                                                              _rdrObj1.GetInt16(_rdrObj1.GetOrdinal("Caja")),
                                                                              _rdrObj1.GetString(_rdrObj1.GetOrdinal("Solicitado")),
                                                                              RefLote,caducidad
                                                                              );


                                SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow invt = SIFDatos.Inventario.Inventario.ArticuloInventario(_rdrObj1.GetString(_rdrObj1.GetOrdinal("Articulo")), sucursal);
                                if (invt.EXISTENCIAS > 0)
                                    DsInventario.INVENTARIO.AddINVENTARIORow(invt);

                        }
                    }
                    _rdrObj1.Close();
                    _rdrObj1.Dispose();
                    //obtenemos el inventario de ese articulo
                    
                }




                _rdrObj.Close();
                _rdrObj.Dispose();


            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Traspasos Almacen", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static int UpdTraspaso(string Folio, int[] Lote, double Total,
                                int[] Sec, String[] ArtId,
                                String[] Concepto, int[] CantS, int[] CantE, int[] CantR, int[] CantD, double[] PrecioE, double[] PrecioR, int[] Caja, String[] Pedido, string Usr_Envia, 
                                String Usr_Recibe, String[] NoLote, String[] FechaCad)
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            String ProductName = "Traspasos Almacen";
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_upd_traspaso"; // sp_upd_traspaso
                cmd.BindByName = true;

                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);

                OracleParameter InLote = cmd.Parameters.Add("Lote", OracleDbType.Decimal);
                InLote.Direction = ParameterDirection.Input;
                InLote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InLote.Value = Lote;

                cmd.Parameters.Add("TotalT", OracleDbType.Double, Total, ParameterDirection.Input);

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

                // IN Array Cantidad Solicitada
                OracleParameter InCantS = cmd.Parameters.Add("CantS", OracleDbType.Decimal);
                InCantS.Direction = ParameterDirection.Input;
                InCantS.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantS.Value = CantS;

                // IN Array Cantidad Enviada
                OracleParameter InCantE = cmd.Parameters.Add("CantE", OracleDbType.Decimal);
                InCantE.Direction = ParameterDirection.Input;
                InCantE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantE.Value = CantE;

                OracleParameter InCantR = cmd.Parameters.Add("CantR", OracleDbType.Decimal);
                InCantR.Direction = ParameterDirection.Input;
                InCantR.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantR.Value = CantR;

                OracleParameter InCantD = cmd.Parameters.Add("CantD", OracleDbType.Decimal);
                InCantD.Direction = ParameterDirection.Input;
                InCantD.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantD.Value = CantD;

                // IN Array Precio Envio
                OracleParameter InPrecioE = cmd.Parameters.Add("PrecioE", OracleDbType.Decimal);
                InPrecioE.Direction = ParameterDirection.Input;
                InPrecioE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecioE.Value = PrecioE;

                OracleParameter InPrecioR = cmd.Parameters.Add("PrecioR", OracleDbType.Decimal);
                InPrecioR.Direction = ParameterDirection.Input;
                InPrecioR.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecioR.Value = PrecioR;
                // IN Array Caja
                OracleParameter InCaja = cmd.Parameters.Add("Caja", OracleDbType.Decimal);
                InCaja.Direction = ParameterDirection.Input;
                InCaja.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCaja.Value = Caja;

                // IN Array Articulo en Pedido
                OracleParameter InPedido = cmd.Parameters.Add("Pedido", OracleDbType.Varchar2);
                InPedido.Direction = ParameterDirection.Input;
                InPedido.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPedido.Value = Pedido;

                //OracleParameter InNolote = cmd.Parameters.Add("eRefLote", OracleDbType.Varchar2);
                //InNolote.Direction = ParameterDirection.Input;
                //InNolote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                //InNolote.Value = NoLote;

                //OracleParameter InFechaCad = cmd.Parameters.Add("eCaducidad", OracleDbType.Varchar2);
                //InFechaCad.Direction = ParameterDirection.Input;
                //InFechaCad.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                //InFechaCad.Value = FechaCad;

                cmd.Parameters.Add("Usr_Envia", OracleDbType.Varchar2, Usr_Envia, ParameterDirection.Input);
                cmd.Parameters.Add("Usr_Recibe", OracleDbType.Varchar2, Usr_Recibe, ParameterDirection.Input);

                // OUT parameter
                OracleParameter pTraspaso =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pTraspaso.Value.ToString()))
                {
                    //if (Convert.ToDecimal(pTraspaso.Value.ToString()) > 0)
                    //   MessageBox.Show("Se actualizo el traspaso con el Folio " + pTraspaso.Value.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al actualizar el traspaso: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            return 0;
        }

        public static void EnviaTraspasoX(string Folio, int[] Lote, int Origen, int Destino,
                                 double Total, int[] Sec, String[] ArtId,
                                 String[] Concepto, int[] Cant, int[] CantE, double[] PrecioE, int[] Caja, double[] TotLote, string Usuario,int SucursalID, String[] NoLote,
                                 String[] FecCad)
        {
            OracleConnection connl = new OracleConnection(Helpers.ConnectionString.Connection());
            string ProductName = "Traspasos Almacen";
            try
            {
                // UpDate Local Pedido_Trasp
                connl.Open();
                // Create an OracleCommand
                OracleCommand cmd = connl.CreateCommand();
                
                // Insert Remote Almacen Traspaso
                ////OracleCommand cmdr = connl.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_ins_traspasoR";
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

                // IN Array Cantidad
                OracleParameter InCantE = cmd.Parameters.Add("CantE", OracleDbType.Decimal);
                InCantE.Direction = ParameterDirection.Input;
                InCantE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantE.Value = CantE;

                OracleParameter InTotLote = cmd.Parameters.Add("TotLote", OracleDbType.Double);
                InTotLote.Direction = ParameterDirection.Input;
                InTotLote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InTotLote.Value = TotLote;

                OracleParameter InPrecioE = cmd.Parameters.Add("PrecioE", OracleDbType.Decimal);
                InPrecioE.Direction = ParameterDirection.Input;
                InPrecioE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecioE.Value = PrecioE;

                OracleParameter InCaja = cmd.Parameters.Add("Caja", OracleDbType.Decimal);
                InCaja.Direction = ParameterDirection.Input;
                InCaja.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCaja.Value = Caja;

                //OracleParameter InNoLote = cmd.Parameters.Add("RefLote", OracleDbType.Varchar2);
                //InNoLote.Direction = ParameterDirection.Input;
                //InNoLote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                //InNoLote.Value = NoLote;

                //OracleParameter InFecCad = cmd.Parameters.Add("Caducidad", OracleDbType.Varchar2);
                //InFecCad.Direction = ParameterDirection.Input;
                //InFecCad.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                //InFecCad.Value = FecCad;
                // IN Array Total Lote
                

                cmd.Parameters.Add("SucID", OracleDbType.Int16, SucursalID, ParameterDirection.Input);
                cmd.Parameters.Add("Usuario", OracleDbType.Varchar2,Usuario, ParameterDirection.Input);
                cmd.Parameters.Add("Activo", OracleDbType.Varchar2, "R", ParameterDirection.Input);
                // OUT parameter
                OracleParameter pTraspaso =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                ////cmd.ExecuteNonQuery();
                
                cmd.Parameters.Clear();
                ////if (int.Parse(pTraspaso.Value.ToString()) < 0)
                ////{
                ////   MessageBox.Show("Se tienen productos que su existencia se hara negativa favor de verificar el pedido ", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ////    return;
                ////}
                ////else
                ////if (!string.IsNullOrEmpty(pTraspaso.Value.ToString()))
                ////{
                ////   MessageBox.Show("Se creo el traspaso con el Folio " + pTraspaso.Value.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ////}
              
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_Cierra_Traspaso";
                cmd.BindByName = true;

                foreach (int i in Lote.Distinct())
                {
                    cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                    cmd.Parameters.Add("NoLote", OracleDbType.Int32, 1, ParameterDirection.Input);
                    cmd.Parameters.Add("NoSuc", OracleDbType.Int32, SucursalID, ParameterDirection.Input);
                    cmd.Parameters.Add("UsrId", OracleDbType.Int32, Usuario, ParameterDirection.Input);

                    //cmd.Parameters.Add("Edo", OracleDbType.Char, 'P', ParameterDirection.Input);
                    // OUT parameter
                    OracleParameter pPedido =
                        cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                    // Execute the command
                    cmd.ExecuteNonQuery();

                    if (!string.IsNullOrEmpty(pPedido.Value.ToString()))
                    {
                        if (Convert.ToDecimal(pPedido.Value.ToString()) > 0)
                           MessageBox.Show("Se actualizo el traspaso con el Folio " + Folio, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        public static String InsertaTraspasoAlmacen(String Usuario,int Origen, int Destino, decimal Total,
                           int[] Lote, int[] Sec, String[] ArtId,
                           String[] Concepto, int[] Cant, decimal[] TotLote, Double[] Precio, int[] Caja, String[] NoLote, 
                           String[] FechaCad,int MOTIVO)
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            String FolioTras="";
            try
            {
                conn.Open();
                Int64 Folio=0;
                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_ins_traspaso_loc";
                cmd.BindByName = true;
                cmd.Parameters.Add("UsuarioID", OracleDbType.Varchar2, Usuario, ParameterDirection.Input);
                cmd.Parameters.Add("Folio", OracleDbType.Int64, Folio, ParameterDirection.Input);
                cmd.Parameters.Add("Origen", OracleDbType.Int32, Origen, ParameterDirection.Input);
                cmd.Parameters.Add("Destino", OracleDbType.Int32, Destino, ParameterDirection.Input);
                cmd.Parameters.Add("Total", OracleDbType.Double, Total, ParameterDirection.Input);
                cmd.Parameters.Add("ID_MOTIVO", OracleDbType.Int32, MOTIVO, ParameterDirection.Input);
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

                OracleParameter InPrecio = cmd.Parameters.Add("Precio", OracleDbType.Decimal);
                InPrecio.Direction = ParameterDirection.Input;
                InPrecio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecio.Value = Precio;

                OracleParameter InCaja = cmd.Parameters.Add("Caja", OracleDbType.Int16);
                InCaja.Direction = ParameterDirection.Input;
                InCaja.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCaja.Value = Caja;

                // IN Array Total Lote
                OracleParameter InTotLote = cmd.Parameters.Add("TotLote", OracleDbType.Decimal);
                InTotLote.Direction = ParameterDirection.Input;
                InTotLote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InTotLote.Value = TotLote;


                //OracleParameter InNoLote = cmd.Parameters.Add("RefLote", OracleDbType.Varchar2);
                //InNoLote.Direction = ParameterDirection.Input;
                //InNoLote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                //InNoLote.Value = NoLote;

                //OracleParameter InFechaCad = cmd.Parameters.Add("Caducidad", OracleDbType.Varchar2);
                //InFechaCad.Direction = ParameterDirection.Input;
                //InFechaCad.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                //InFechaCad.Value = FechaCad;

                // OUT parameter
                OracleParameter pPedido =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pPedido.Value.ToString()))
                {
                    FolioTras = pPedido.Value.ToString();
                    
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al crear el traspaso: " + Environment.NewLine + ex.Message, "Pedido Almacen", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            return FolioTras;
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
                    //Grd_PedidoDet.Rows.Clear();
                {
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


        public static void EnviaPedidoX(string Folio, int[] Lote, int Origen, int Destino,
                                 double Total, int[] Sec, String[] ArtId,
                                 String[] Concepto, int[] Cant, double[] TotLote, int[] Caja)
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

                // Insert Remote Almacen Traspaso
                ////OracleCommand cmdr = connl.CreateCommand();
                ////cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_ins_traspaso_loc";
                cmd.BindByName = true;

                cmd.Parameters.Add("Folio", OracleDbType.Int64, Folio, ParameterDirection.Input);
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

                // IN Array Total Lote
                OracleParameter InTotLote = cmd.Parameters.Add("TotLote", OracleDbType.Double);
                InTotLote.Direction = ParameterDirection.Input;
                InTotLote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InTotLote.Value = TotLote;

                OracleParameter InCaja = cmd.Parameters.Add("Caja", OracleDbType.Int16);
                InCaja.Direction = ParameterDirection.Input;
                InCaja.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCaja.Value = Caja;

                // OUT parameter
                OracleParameter pTraspaso =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pTraspaso.Value.ToString()))
                {
                   MessageBox.Show("Se creo el pedido con el Folio " + pTraspaso.Value.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static SIFModelo.Inventarios.InventarioDataSet GetTraspasoDet(string Ini, string Fin)
        {

            String sentencia = "SELECT * FROM TRASPASO_DET "; //
            SIFModelo.Inventarios.InventarioDataSet ds = new SIFModelo.Inventarios.InventarioDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "TRASPASO_DET");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }
            return ds;
        }
        public static DataTable GetTraspasoDetFilas(string Folio, int Lote, SIFModelo.Sucursal Sucursal, string filas)
        {
            int Partidas = 1;
            Cursor.Current = Cursors.WaitCursor;
            String ProductName = "Traspasos";
            DataTable dtTraspaso = new DataTable();
            dtTraspaso.Columns.Add("lote", typeof(int));
            DataColumn workCol = dtTraspaso.Columns.Add("Partida", typeof(int));
            workCol.AllowDBNull = false;
            workCol.Unique = true;
            workCol.AutoIncrement = true;
            workCol.AutoIncrementSeed = 1;
            workCol.AutoIncrementStep = 1;

            dtTraspaso.Columns.Add("id", typeof(string));
            dtTraspaso.Columns.Add("nombre", typeof(string));
            dtTraspaso.Columns.Add("Nolote", typeof(string));
            dtTraspaso.Columns.Add("FechaCad", typeof(string));
            dtTraspaso.Columns.Add("pedido", typeof(int));
            dtTraspaso.Columns.Add("enviado", typeof(int));
            dtTraspaso.Columns.Add("Recibido", typeof(int));
            dtTraspaso.Columns.Add("Devuelta", typeof(int)); // ROMA 11SEP2013
            dtTraspaso.Columns.Add("Existencia", typeof(int)); // typeof(double));
            dtTraspaso.Columns.Add("Costo", typeof(double));
            dtTraspaso.Columns.Add("caja", typeof(int));
            dtTraspaso.Columns.Add("solicita", typeof(string));
            ////dtTraspaso.Columns.Add("solicita", typeof(bool)); // ROMA 17AGO2013
            dtTraspaso.Columns.Add("total", typeof(double), "enviado * Costo");
            dtTraspaso.Columns.Add("incidencia", typeof(decimal));
            dtTraspaso.Columns.Add("Ubicacion", typeof(string));
            dtTraspaso.PrimaryKey = new DataColumn[] { dtTraspaso.Columns["id"] };

            int nRow = 1, ind = 0;

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                dtTraspaso.Clear();
                OracleCommand cmd = conn.CreateCommand();
                // Create an OracleCommand
                if (Sucursal.SucursalID != 1)
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_PEDIDO_TRASP.sp_get_tradeta";
                }
                else
                {/*
                    cmd.CommandText = "SELECT det.lote," +
                   "det.num_partida," +
                   "det.articulo_id articulo," +
                   "det.concepto nombre," +
                   "det.cantidad_solicitada Pedido," +
                   "det.cantidad_enviada Enviado," +
                   "det.cantidad_recibida Recibido," +
                   "det.incidencia," +
                   "det.precio_envia Precio," +
                   "det.precio_recibe PrecioR," +
           "        det.caja Caja," +
            "       det.Solicitado," +
             "      det.Lote_Procesado Procesado," +
              "     det.cantidad_devuelta Devuelta," +
               "    inv.existencias," +
                "   NVL(dev.nombre, 'NO APLICA') devolucion, 0 incidencia, inv.UBICACION " +
              "FROM traspaso_det det, INVENTARIO inv," +
               "         cat_tipo_devolucion dev ,cs_Ubicaciones u " +
             "WHERE     det.folio like'%" + Folio + "%'" +
              "     AND det.lote  like'%" + Lote + "%'" +
               "    AND det.articulo_id = inv.articulo_id and inv.articulo_id=u.articulo_id ";
                    */
                    cmd.CommandText = "SELECT   det.lote,  det.num_partida,  det.articulo,  det.nombre,  det.Pedido,  det.Enviado,  det.Recibido,  det.incidencia,  det.Precio,  det.PrecioR,  det.caja Caja,  det.Solicitado,  det.Procesado,  det.Devuelta,  DET.existencias,  NVL(DET.nombre, 'NO APLICA') devolucion,  0 incidencia2," +
  " DET.UBICACION FROM CS_TRASPASO_FILA_DETALLE DET";
                    cmd.CommandText += " WHERE det.folio ='" + Folio + "'" +
                "     AND det.lote  ='" + Lote + "'";
                    if(!filas.Equals(""))
                        cmd.CommandText += " and DET.fila in ("+filas+") ";

                    cmd.CommandText += "  ORDER BY det.NOMBRE";
                }
                /* "   SELECT det.lote,"+
                 "  det.num_partida,"+
                 "  det.articulo_id articulo,"+
                 "  det.concepto nombre,"+
                 "  det.cantidad_solicitada Pedido,"+
                 "  det.cantidad_enviada Enviado,"+
                "   det.cantidad_recibida Recibido,"+
                "   det.precio_envia Precio,"+
                "   det.precio_recibe PrecioR,"+
                "   det.caja Caja,"+
                "   det.Solicitado,"+
                "   det.Lote_Procesado Procesado,"+
                "   inv.existencias"+
                "   FROM traspaso_det det, INVENTARIO inv "+
                "   WHERE     det.folio like'%" + Folio  +"%'"+
                "  AND det.lote like '%" + Lote  +"%'"+
                "  AND det.articulo_id = inv.articulo_id" +
                "  ORDER BY det.num_partida";*/
                //  string xx = cmd.CommandText;

                cmd.BindByName = true;
                // OUT REF CURSOR bound/*
                /* OracleParameter pPedido = cmd.Parameters.Add("Det", OracleDbType.RefCursor, ParameterDirection.Output);
                 cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                 cmd.Parameters.Add("NoLote", OracleDbType.Decimal, Lote, ParameterDirection.Input);*/

                OracleDataReader _rdrObj = cmd.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    //Grd_PedidoDet.Rows.Clear();

                    while (_rdrObj.Read())
                    {
                        // Data Table Traspaso

                        DataRow RegArt = dtTraspaso.Rows.Find(_rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")));
                        if (RegArt == null)
                        { //buscamos la existencia del articulo
                            String caducidad = "";
                            String RefLote = "";
                            try
                            {
                                if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("CADUCIDAD")) == false)
                                    caducidad = _rdrObj.GetString(_rdrObj.GetOrdinal("CADUCIDAD"));
                                if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("REFLOTE")) == false)
                                    RefLote = _rdrObj.GetString(_rdrObj.GetOrdinal("REFLOTE"));
                            }
                            catch { }

                            ////SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow Invt = SIFDatos.Inventario.Inventario.ArticuloInventario(_rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")), Sucursal);
                            ////if (Invt==null)
                            ////    dtTraspaso.Rows.Add(_rdrObj.GetDecimal(_rdrObj.GetOrdinal("Lote")),Partidas,
                            ////                  _rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")),
                            ////                  _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")),
                            ////                  RefLote,
                            ////                  caducidad,
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido")),
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado")),
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Recibido")),
                            ////                  0,
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Precio")),
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja")),
                            ////                  _rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")));

                            ////else
                            ////dtTraspaso.Rows.Add(_rdrObj.GetDecimal(_rdrObj.GetOrdinal("Lote")),Partidas,
                            ////                  _rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")),
                            ////                  _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")),
                            ////                  RefLote,
                            ////                  caducidad,
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido")),
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado")),
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Recibido")),
                            ////                  Invt.EXISTENCIAS,
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Precio")),
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja")),
                            ////                  _rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")));
                            ////Partidas++;
                            /// ROMA 13AGO2013
                            /// 
                            if (_rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")).ToString().Contains("S"))
                            {
                                dtTraspaso.Rows.Add(_rdrObj.GetDecimal(_rdrObj.GetOrdinal("Lote")),
                                              _rdrObj.GetInt32(_rdrObj.GetOrdinal("num_partida")),///Partidas,
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")),
                                              RefLote,
                                              caducidad,
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Recibido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Devuelta")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Existencias")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Precio")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja")),
                                    //                                              true,
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("incidencia")),0,
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("UBICACION")));
                            }
                            else
                            {
                                dtTraspaso.Rows.Add(_rdrObj.GetDecimal(_rdrObj.GetOrdinal("Lote")),
                                              _rdrObj.GetInt32(_rdrObj.GetOrdinal("num_partida")),///Partidas,
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")),
                                              RefLote,
                                              caducidad,
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Recibido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Devuelta")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Existencias")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Precio")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja")),
                                    //                                              false,
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("incidencia")),0,
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("UBICACION"))); ;
                            }
                            Partidas++;
                            //dtTraspaso.Columns.Add("lote", typeof(int));
                            //DataColumn workCol = dtTraspaso.Columns.Add("Partida", typeof(int));
                            //dtTraspaso.Columns.Add("id", typeof(string));
                            //dtTraspaso.Columns.Add("nombre", typeof(string));
                            //dtTraspaso.Columns.Add("Nolote", typeof(string));
                            //dtTraspaso.Columns.Add("FechaCad", typeof(string));
                            //dtTraspaso.Columns.Add("pedido", typeof(int));
                            //dtTraspaso.Columns.Add("enviado", typeof(int));
                            //dtTraspaso.Columns.Add("Recibido", typeof(int));
                            //dtTraspaso.Columns.Add("Devuelta", typeof(int)); // ROMA 11SEP2013
                            //dtTraspaso.Columns.Add("Existencia", typeof(int)); // typeof(double));
                            //dtTraspaso.Columns.Add("Costo", typeof(double));
                            //dtTraspaso.Columns.Add("caja", typeof(int));
                            //dtTraspaso.Columns.Add("solicita", typeof(string));

                        }
                        else
                        {
                            RegArt["enviado"] = int.Parse(RegArt["enviado"].ToString()) + _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado"));
                            RegArt["caja"] = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja"));
                        }

                        ind++;
                    }
                }
                else
                {
                    //Grd_PedidoDet.Rows.Clear();
                   MessageBox.Show("NO existe información de Traspasos...", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            return dtTraspaso;
        }
        public static DataTable GetTraspasoDet(string Folio, int Lote, SIFModelo.Sucursal Sucursal)
        {
            int Partidas = 1;
            Cursor.Current = Cursors.WaitCursor;
            String ProductName = "Traspasos";
            DataTable dtTraspaso = new DataTable();
            dtTraspaso.Columns.Add("lote", typeof(int));
            DataColumn workCol = dtTraspaso.Columns.Add("Partida", typeof(int));
            workCol.AllowDBNull = false;
            workCol.Unique = true;
            workCol.AutoIncrement = true;
            workCol.AutoIncrementSeed = 1;
            workCol.AutoIncrementStep = 1;

            dtTraspaso.Columns.Add("id", typeof(string));
            dtTraspaso.Columns.Add("nombre", typeof(string));
            dtTraspaso.Columns.Add("Nolote", typeof(string));
            dtTraspaso.Columns.Add("FechaCad", typeof(string));
            dtTraspaso.Columns.Add("pedido", typeof(int));
            dtTraspaso.Columns.Add("enviado", typeof(int));
            dtTraspaso.Columns.Add("Recibido", typeof(int));
            dtTraspaso.Columns.Add("Devuelta", typeof(int)); // ROMA 11SEP2013
            dtTraspaso.Columns.Add("Existencia", typeof(int)); // typeof(double));
            dtTraspaso.Columns.Add("Costo", typeof(double));
            dtTraspaso.Columns.Add("caja", typeof(int));
            dtTraspaso.Columns.Add("solicita", typeof(string));
            ////dtTraspaso.Columns.Add("solicita", typeof(bool)); // ROMA 17AGO2013
            dtTraspaso.Columns.Add("total", typeof(double),"enviado * Costo");
            dtTraspaso.PrimaryKey = new DataColumn[] { dtTraspaso.Columns["id"] };

            int nRow = 1, ind = 0;

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                dtTraspaso.Clear();
                OracleCommand cmd = conn.CreateCommand();
                // Create an OracleCommand
                if (Sucursal.SucursalID != 1)
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_PEDIDO_TRASP.sp_get_tradeta";
                }
                else
                {
                    cmd.CommandText = "SELECT det.lote," +
                   "det.num_partida," +
                   "det.articulo_id articulo," +
                   "det.concepto nombre," +
                   "det.cantidad_solicitada Pedido," +
                   "det.cantidad_enviada Enviado," +
                   "det.cantidad_recibida Recibido," +
                   "det.incidencia," +
                   "det.precio_envia Precio," +
                   "det.precio_recibe PrecioR," +
           "        det.caja Caja," +
            "       det.Solicitado," +
             "      det.Lote_Procesado Procesado," +
              "     det.cantidad_devuelta Devuelta," +
               "    inv.existencias," +
                "   NVL(dev.nombre, 'NO APLICA') devolucion " +
              "FROM traspaso_det det, INVENTARIO inv," +
               "         cat_tipo_devolucion dev " +
             /*"WHERE     det.folio like'%" + Folio + "%'" +
              "     AND det.lote  like'%" + Lote + "%'" +*/
             "WHERE     det.folio ='" + Folio + "'" +
              "     AND det.lote  ='" + Lote + "'" +
             
               "    AND det.articulo_id = inv.articulo_id" +
                "   AND det.tipo_devolucion = dev.tipo_devolucion_id(+) and inv.existencias>0" +
           "ORDER BY det.CONCEPTO";
                }
            /* "   SELECT det.lote,"+
             "  det.num_partida,"+
             "  det.articulo_id articulo,"+
             "  det.concepto nombre,"+
             "  det.cantidad_solicitada Pedido,"+
             "  det.cantidad_enviada Enviado,"+
            "   det.cantidad_recibida Recibido,"+
            "   det.precio_envia Precio,"+
            "   det.precio_recibe PrecioR,"+
            "   det.caja Caja,"+
            "   det.Solicitado,"+
            "   det.Lote_Procesado Procesado,"+
            "   inv.existencias"+
            "   FROM traspaso_det det, INVENTARIO inv "+
            "   WHERE     det.folio like'%" + Folio  +"%'"+
            "  AND det.lote like '%" + Lote  +"%'"+
            "  AND det.articulo_id = inv.articulo_id" +
            "  ORDER BY det.num_partida";*/
              //  string xx = cmd.CommandText;
                
                    cmd.BindByName = true;
                // OUT REF CURSOR bound/*
               /* OracleParameter pPedido = cmd.Parameters.Add("Det", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Decimal, Lote, ParameterDirection.Input);*/

                OracleDataReader _rdrObj = cmd.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    //Grd_PedidoDet.Rows.Clear();

                    while (_rdrObj.Read())
                    {
                        // Data Table Traspaso

                        DataRow RegArt = dtTraspaso.Rows.Find(_rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")));
                        if (RegArt == null)
                        { //buscamos la existencia del articulo
                            String caducidad = "";
                            String RefLote = "";
                            try
                            {
                                if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("CADUCIDAD")) == false)
                                    caducidad = _rdrObj.GetString(_rdrObj.GetOrdinal("CADUCIDAD"));
                                if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("REFLOTE")) == false)
                                    RefLote = _rdrObj.GetString(_rdrObj.GetOrdinal("REFLOTE"));
                            }
                            catch { }

                            ////SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow Invt = SIFDatos.Inventario.Inventario.ArticuloInventario(_rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")), Sucursal);
                            ////if (Invt==null)
                            ////    dtTraspaso.Rows.Add(_rdrObj.GetDecimal(_rdrObj.GetOrdinal("Lote")),Partidas,
                            ////                  _rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")),
                            ////                  _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")),
                            ////                  RefLote,
                            ////                  caducidad,
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido")),
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado")),
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Recibido")),
                            ////                  0,
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Precio")),
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja")),
                            ////                  _rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")));
                                
                            ////else
                            ////dtTraspaso.Rows.Add(_rdrObj.GetDecimal(_rdrObj.GetOrdinal("Lote")),Partidas,
                            ////                  _rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")),
                            ////                  _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")),
                            ////                  RefLote,
                            ////                  caducidad,
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido")),
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado")),
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Recibido")),
                            ////                  Invt.EXISTENCIAS,
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Precio")),
                            ////                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja")),
                            ////                  _rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")));
                            ////Partidas++;
                            /// ROMA 13AGO2013
                            /// 
                            if (_rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")).ToString().Contains("S"))
                            {
                                dtTraspaso.Rows.Add(_rdrObj.GetDecimal(_rdrObj.GetOrdinal("Lote")), Partidas,
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")),
                                              RefLote,
                                              caducidad,
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Recibido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Devuelta")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Existencias")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Precio")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja")),
//                                              true,
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")));
                            }
                            else
                            {
                                dtTraspaso.Rows.Add(_rdrObj.GetDecimal(_rdrObj.GetOrdinal("Lote")), Partidas,
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")),
                                              RefLote,
                                              caducidad,
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Recibido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Devuelta")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Existencias")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Precio")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja")),
//                                              false,
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")));
                            }
                            Partidas++;
                            //dtTraspaso.Columns.Add("lote", typeof(int));
                            //DataColumn workCol = dtTraspaso.Columns.Add("Partida", typeof(int));
                            //dtTraspaso.Columns.Add("id", typeof(string));
                            //dtTraspaso.Columns.Add("nombre", typeof(string));
                            //dtTraspaso.Columns.Add("Nolote", typeof(string));
                            //dtTraspaso.Columns.Add("FechaCad", typeof(string));
                            //dtTraspaso.Columns.Add("pedido", typeof(int));
                            //dtTraspaso.Columns.Add("enviado", typeof(int));
                            //dtTraspaso.Columns.Add("Recibido", typeof(int));
                            //dtTraspaso.Columns.Add("Devuelta", typeof(int)); // ROMA 11SEP2013
                            //dtTraspaso.Columns.Add("Existencia", typeof(int)); // typeof(double));
                            //dtTraspaso.Columns.Add("Costo", typeof(double));
                            //dtTraspaso.Columns.Add("caja", typeof(int));
                            //dtTraspaso.Columns.Add("solicita", typeof(string));

                        }
                        else
                        {
                            RegArt["enviado"] = int.Parse(RegArt["enviado"].ToString()) + _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado"));
                            RegArt["caja"] = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja"));
                        }

                        ind++;
                    }
                }
                else
                {
                    //Grd_PedidoDet.Rows.Clear();
                   MessageBox.Show("NO existe información de Traspasos...", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            return dtTraspaso;
        }

        public static DataTable GetTraspasoInc(string Folio, int Lote, SIFModelo.Sucursal Sucursal)
        {
            int Partidas = 1;
            Cursor.Current = Cursors.WaitCursor;
            String ProductName = "Traspasos";
            DataTable dtTraspaso = new DataTable();
            dtTraspaso.Columns.Add("lote", typeof(int));
            DataColumn workCol = dtTraspaso.Columns.Add("Partida", typeof(int));
            workCol.AllowDBNull = false;
            workCol.Unique = true;
            workCol.AutoIncrement = true;
            workCol.AutoIncrementSeed = 1;
            workCol.AutoIncrementStep = 1;

            dtTraspaso.Columns.Add("id", typeof(string));
            dtTraspaso.Columns.Add("nombre", typeof(string));
            dtTraspaso.Columns.Add("pedido", typeof(int));
            dtTraspaso.Columns.Add("enviado", typeof(int));
            dtTraspaso.Columns.Add("Recibido", typeof(int));
            dtTraspaso.Columns.Add("Existencia", typeof(double));
            dtTraspaso.Columns.Add("Costo", typeof(double));
            dtTraspaso.Columns.Add("caja", typeof(int));
            dtTraspaso.Columns.Add("solicita", typeof(string));
            dtTraspaso.Columns.Add("total", typeof(double), "enviado * Costo");
            dtTraspaso.PrimaryKey = new DataColumn[] { dtTraspaso.Columns["id"] };


            int nRow = 1, ind = 0;

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                dtTraspaso.Clear();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_get_tradeti";
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
                        // Data Table Traspaso

                        DataRow RegArt = dtTraspaso.Rows.Find(_rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")));
                        if (RegArt == null)
                        { //buscamos la existencia del articulo

                            SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow Invt = SIFDatos.Inventario.Inventario.ArticuloInventario(_rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")), Sucursal);
                            if (Invt == null)
                                dtTraspaso.Rows.Add(_rdrObj.GetDecimal(_rdrObj.GetOrdinal("Lote")), Partidas,
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Recibido")),
                                              0,
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Precio")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")));

                            else
                                dtTraspaso.Rows.Add(_rdrObj.GetDecimal(_rdrObj.GetOrdinal("Lote")), Partidas,
                                                  _rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")),
                                                  _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")),
                                                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido")),
                                                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado")),
                                                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Recibido")),
                                                  Invt.EXISTENCIAS,
                                                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Precio")),
                                                  _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja")),
                                                  _rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")));
                            Partidas++;
                        }
                        else
                        {
                            RegArt["enviado"] = int.Parse(RegArt["enviado"].ToString()) + _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado"));
                            RegArt["caja"] = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja"));
                        }

                        ind++;
                    }
                }
                else
                {
                    //Grd_PedidoDet.Rows.Clear();
                   MessageBox.Show("NO existe información de Traspasos...", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            return dtTraspaso;
        }
        public static int CancelaDestruccion(string NoFolio, string NoLote)
        {
            String ProductName = "Destruccion";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_Cancela_Destruccion";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int16, NoLote, ParameterDirection.Input);

                // Execute the command
                cmd.ExecuteNonQuery();

               MessageBox.Show(pCancela.Value.ToString() + " - La Destrucción se Cancelo", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        public static int CancelaDevolucion(string NoFolio)
        {
            String ProductName = "Devolucion";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_Cancela_Devolucion";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
               

                // Execute the command
                cmd.ExecuteNonQuery();

               MessageBox.Show(pCancela.Value.ToString() + " - La Devolucion se Cancelo", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        public static int CancelaMovimiento(string NoFolio,string mov)
        {
            String ProductName = "";
            if (mov == "9")
            {
                ProductName = "Bonificacion";
            }
            if (mov == "20")
            {
                ProductName = "Reposicion a proveedor";
            }
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_Cancela_Movimiento";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("tipo_mov", OracleDbType.Varchar2, mov, ParameterDirection.Input);


                // Execute the command
                cmd.ExecuteNonQuery();

               MessageBox.Show(pCancela.Value.ToString() + " - El movimiento se Cancelo", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

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



        public static int CancelTraspaso(string NoFolio, string NoLote)
        {
            String ProductName = "Traspasos";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_CancelaTraspaso";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int16, NoLote, ParameterDirection.Input);

                // Execute the command
                cmd.ExecuteNonQuery();

               MessageBox.Show(pCancela.Value.ToString() + " - El Traspaso se Cancelo", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

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
        public static int CancelAjuste(string NoFolio, string NoLote)
        {
            String ProductName = "Ajuste";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_CancelaAjuste";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int16, NoLote, ParameterDirection.Input);

                // Execute the command
                cmd.ExecuteNonQuery();

               MessageBox.Show(pCancela.Value.ToString() + " - El Ajuste se Cancelo", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        public static string Cancel_Traspaso(string NoFolio, string NoLote)
        {
            String ProductName = "Traspasos";
            String Result = string.Empty;
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_Cancela_Traspaso";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pResult = cmd.Parameters.Add("Result", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int16, NoLote, ParameterDirection.Input);

                // Execute the command
                OracleDataReader _rdrObj = cmd.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        Result = _rdrObj.GetString(_rdrObj.GetOrdinal("msg"));
                    }
                }
                else
                {
                    Result = "NO existe información de Traspasos...";
                }
                _rdrObj.Close();
                _rdrObj.Dispose();

                return Result;
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
                return Oex.Number.ToString();
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ex.Message;
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

        public static int CierraTraspasoRec(string UsuariosID, string NoFolio, string NoLote, int NoSuc)//cierratraspaso
        {
            String ProductName = "Traspasos";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
           // int Recibido = 0;
            conn.Open();
            try
            {

                OracleCommand cmd1 = conn.CreateCommand();

                cmd1.CommandText = "   select " +
                        "TD.FOLIO," +
                        "TD.LOTE," +
                        "TD.NUM_PARTIDA," +
                        "TD.ARTICULO_ID," +
                        "TD.CONCEPTO," +
                        "TD.CANTIDAD_SOLICITADA," +
                        "TD.CANTIDAD_ENVIADA," +
                        "TD.CANTIDAD_RECIBIDA Recibido," +
                        "TD.LOTE_PROCESADO," +
                        "TD.INCIDENCIA," +
                        "TD.CANTIDAD_DEVUELTA," +
                        "TD.TIPO_DEVOLUCION " +
                        "from traspaso t, " +
                        "traspaso_det td " +
                        "where " +
                        "t.folio =td.folio " +
                        "AND T.LOTE=TD.LOTE and td.Folio ='" + NoFolio + "' and td.lote= '" + NoLote + "'";
                cmd1.BindByName = true;

                OracleDataReader _rdrObj1 = cmd1.ExecuteReader();

               /* if (_rdrObj1.HasRows)
                {


                    while (_rdrObj1.Read())
                    {
                        //if (_rdrObj1.GetInt32(_rdrObj1.GetOrdinal("Recibido")) == 0);
                           // Recibido = 1;
                    }

                }*/


                _rdrObj1.Close();
                _rdrObj1.Dispose();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Traspasos Almacen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                //if (Recibido == 0)
               // {
                    // Create an OracleCommand
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_PEDIDO_TRASP.sp_Cierra_Traspaso";
                    cmd.BindByName = true;

                    // OUT REF CURSOR bound
                    OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                    cmd.Parameters.Add("UsrId", OracleDbType.Varchar2, UsuariosID, ParameterDirection.Input);
                    cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                    cmd.Parameters.Add("NoLote", OracleDbType.Int32, NoLote, ParameterDirection.Input);
                    cmd.Parameters.Add("NoSuc", OracleDbType.Int32, NoSuc, ParameterDirection.Input);

                    // Execute the command
                    cmd.ExecuteNonQuery();

                   MessageBox.Show(pCancela.Value.ToString() + " - El Traspaso se Cerro ", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return Convert.ToInt32(pCancela.Value.ToString());

                //}
                //else 
                
               
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
        public static int CierraTraspaso(string UsuariosID, string NoFolio, string NoLote, int NoSuc)//cierratraspaso
        {                        
            String ProductName = "Traspasos";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            int Recibido=0;
            conn.Open();
            try
            {
                
                OracleCommand cmd1 = conn.CreateCommand();
                
                cmd1.CommandText = "   select " +
                        "TD.FOLIO," +
                        "TD.LOTE," +
                        "TD.NUM_PARTIDA," +
                        "TD.ARTICULO_ID," +
                        "TD.CONCEPTO," +
                        "TD.CANTIDAD_SOLICITADA," +
                        "TD.CANTIDAD_ENVIADA," +
                        "TD.CANTIDAD_RECIBIDA Recibido," +
                        "TD.LOTE_PROCESADO," +
                        "TD.INCIDENCIA," +
                        "TD.CANTIDAD_DEVUELTA," +
                        "TD.TIPO_DEVOLUCION " +
                        "from traspaso t, " +
                        "traspaso_det td " +
                        "where " +
                        "t.folio =td.folio " +
                        "AND T.LOTE=TD.LOTE and td.Folio ='" + NoFolio + "' and td.lote= '" + NoLote + "'";
                cmd1.BindByName = true;

               OracleDataReader _rdrObj1 = cmd1.ExecuteReader();

                if (_rdrObj1.HasRows)
                {
                    

                    while (_rdrObj1.Read())
                    {
                       if (_rdrObj1.GetInt32(_rdrObj1.GetOrdinal("Recibido")) == 0)
                        Recibido=1;
                    }
                    
                }
              
                 
                _rdrObj1.Close();
                _rdrObj1.Dispose();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Traspasos Almacen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                if (Recibido == 0)
                {
                    // Create an OracleCommand
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_PEDIDO_TRASP.sp_Cierra_Traspaso";
                    cmd.BindByName = true;

                    // OUT REF CURSOR bound
                    OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                    cmd.Parameters.Add("UsrId", OracleDbType.Varchar2, UsuariosID, ParameterDirection.Input);
                    cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                    cmd.Parameters.Add("NoLote", OracleDbType.Int32, NoLote, ParameterDirection.Input);
                    cmd.Parameters.Add("NoSuc", OracleDbType.Int32, NoSuc, ParameterDirection.Input);

                    // Execute the command
                    cmd.ExecuteNonQuery();

                   MessageBox.Show(pCancela.Value.ToString() + " - El Traspaso se Cerro ", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return Convert.ToInt32(pCancela.Value.ToString());
                
                }
                else if ( Recibido == 1 &&MessageBox.Show("                        ATENCION!!!! \n El Traspaso tiene prodcutos recibidos en CERO,\n                  ¿Desea continuar?",
                                  ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK )
                {


                    // Create an OracleCommand
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_PEDIDO_TRASP.sp_Cierra_Traspaso";
                    cmd.BindByName = true;

                    // OUT REF CURSOR bound
                    OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                    cmd.Parameters.Add("UsrId", OracleDbType.Varchar2, UsuariosID, ParameterDirection.Input);
                    cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                    cmd.Parameters.Add("NoLote", OracleDbType.Int32, NoLote, ParameterDirection.Input);
                    cmd.Parameters.Add("NoSuc", OracleDbType.Int32, NoSuc, ParameterDirection.Input);

                    // Execute the command
                    cmd.ExecuteNonQuery();

                   MessageBox.Show(pCancela.Value.ToString() + " - El Traspaso se Cerro ", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return Convert.ToInt32(pCancela.Value.ToString());
                }
                else
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


        public static int CierraTraspasos21(string UsuariosID, string NoFolio, string NoLote, int NoSuc)//cierratraspaso
        {
            String ProductName = "Traspasos";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            int Recibido = 0;
            string sucursal_origen = "";
            int Enviada = 0;
            conn.Open();
            try
            {

                OracleCommand cmd1 = conn.CreateCommand();

                cmd1.CommandText = " select " +
                                "T.SUCURSAL_ORIGEN Origen,"+
                                "TD.FOLIO," +
                                "TD.LOTE," +
                                "TD.NUM_PARTIDA," +
                                "TD.ARTICULO_ID," +
                                "TD.CONCEPTO," +
                                "TD.CANTIDAD_SOLICITADA," +
                                "TD.CANTIDAD_ENVIADA Enviada," +
                                "TD.CANTIDAD_RECIBIDA Recibido," +
                                "TD.LOTE_PROCESADO," +
                                "TD.INCIDENCIA," +
                                "TD.CANTIDAD_DEVUELTA," +
                                "TD.TIPO_DEVOLUCION,tdc.lote_interno " +
                                "from traspaso t, " +
                                "traspaso_det td,traspasodet_caducidad tdc" +
                                " where t.folio =td.folio " +
                                "AND T.LOTE=TD.LOTE and td.Folio =tdc.FOLIO " +
                                "AND TD.ARTICULO_ID=tdc.ARTICULO_ID " +
                                "AND td.Folio ='" + NoFolio + "' and td.lote= '" + NoLote + "'";
                cmd1.BindByName = true;

                OracleDataReader _rdrObj1 = cmd1.ExecuteReader();

                if (_rdrObj1.HasRows)
                {


                    while (_rdrObj1.Read())
                    {
                        if (_rdrObj1.GetInt32(_rdrObj1.GetOrdinal("Recibido")) >= 1)
                            Recibido = 1;
                        if (_rdrObj1.GetInt32(_rdrObj1.GetOrdinal("Origen")) == 1)
                            sucursal_origen = "S";
                        else sucursal_origen = "E";
                        if (_rdrObj1.GetInt32(_rdrObj1.GetOrdinal("Enviada")) >= 1)
                            Enviada = 1;
                    }

                }


                _rdrObj1.Close();
                _rdrObj1.Dispose();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Traspasos Almacen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                if (sucursal_origen == "S" && Enviada >= 1 || sucursal_origen == "E" && Recibido >= 1)
                {


                    //if (Recibido == 0)
                    //{
                    // Create an OracleCommand
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_CIERRE_CADUCIDADES21.sp_Cierre_Traspaso21";
                    cmd.BindByName = true;

                    // OUT REF CURSOR bound
                    cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                    cmd.Parameters.Add("NoLote", OracleDbType.Int32, NoLote, ParameterDirection.Input);
                    cmd.Parameters.Add("NoSuc", OracleDbType.Int32, NoSuc, ParameterDirection.Input);
                    cmd.Parameters.Add("UsrId", OracleDbType.Varchar2, UsuariosID, ParameterDirection.Input);
                    OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                    // Execute the command
                    cmd.ExecuteNonQuery();

                   MessageBox.Show(pCancela.Value.ToString() + " - El Traspaso se Cerro ", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return Convert.ToInt32(pCancela.Value.ToString());

                }
                else
                if (sucursal_origen == "S")
                {
                    MessageBox.Show("ATENCION!!!! \n El Traspaso tiene prodcutos con cantidad enviada en CERO,\n                  ¡Favor de validar!");//, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    return 0;

                }
                else if (sucursal_origen == "E")
                {
                    MessageBox.Show("ATENCION!!!! \n El Traspaso tiene prodcutos con cantidad enviada en CERO,\n                  ¡Favor de validar!");// MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }
                /*else if (Recibido == 1 &&MessageBox.Show("                        ATENCION!!!! \n El Traspaso tiene prodcutos recibidos en CERO,\n                  ¿Desea continuar?",
                                  ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {


                    // Create an OracleCommand
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_CIERRE_CADUCIDADES21.sp_cierre_traspaso21";
                    cmd.BindByName = true;

                    // OUT REF CURSOR bound
                    
                    
                    cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                    cmd.Parameters.Add("NoLote", OracleDbType.Int32, NoLote, ParameterDirection.Input);
                    cmd.Parameters.Add("NoSuc", OracleDbType.Int32, NoSuc, ParameterDirection.Input);
                    cmd.Parameters.Add("UsrId", OracleDbType.Varchar2, UsuariosID, ParameterDirection.Input);
                    OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                    // Execute the command
                    cmd.ExecuteNonQuery();

                   MessageBox.Show(pCancela.Value.ToString() + " - El Traspaso se Cerro ", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return Convert.ToInt32(pCancela.Value.ToString());
                }*/
                else
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



        public static int AplicaIncidencia(string UsuariosID, string NoFolio, string NoLote, int NoSuc)
        {
            String ProductName = "Traspasos";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_AplicaIncidencia";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("UsuarioID", OracleDbType.Varchar2, UsuariosID, ParameterDirection.Input);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int16, NoLote, ParameterDirection.Input);
                cmd.Parameters.Add("NoSuc", OracleDbType.Int16, NoSuc, ParameterDirection.Input);

                // Execute the command
                cmd.ExecuteNonQuery();

               MessageBox.Show(pCancela.Value.ToString() + " - la incidencia se aplico ", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return Convert.ToInt32(1);
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

        public static int ActualizarTraspaso(int sucursalDestino, String NoFolio)
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE TRASPASO SET SUCURSAL_DESTINO = :SucDestino WHERE FOLIO = :NOFOLIO";

                cmd.Parameters.Add("SucDestino", OracleDbType.Int32, sucursalDestino, ParameterDirection.Input);
                cmd.Parameters.Add("NOFOLIO", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);

                // Execute the command
                cmd.ExecuteNonQuery();

                return Convert.ToInt32(1);
            }
            catch (OracleException Oex)
            {
                switch (Oex.Number)
                {
                    case 1:
                       MessageBox.Show("Error intentando insertar datos duplicados" + Environment.NewLine, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 12545:
                       MessageBox.Show("La base de datos NO esta disponible" + Environment.NewLine, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                       MessageBox.Show("Database error:" + System.Environment.NewLine + Oex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return Oex.Number * -1;
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error: " + Environment.NewLine + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static SIFModelo.Tipos.parmFac timbraTraspasoD(SIFModelo.Tipos.parmFac dP)
        {
            try
            {
                string sentencia = "PKG_FEL.SP_TIMBRAR_TRASPASO";
                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.BindByName = true;
                        cmd.Parameters.Add("V_FOLIO_T", dP.folioTraspaso);
                        cmd.Parameters.Add("v_usuario_id", dP.usuarioId);
                        cmd.Parameters.Add("V_LOTE_T", dP.loteTraspaso);
                        cmd.Parameters.Add("v_uso_cfdi", dP.usoCfdi);
                        cmd.Parameters.Add("v_lugar_expedicion", dP.lExp);

                        OracleParameter outparams = new OracleParameter("v_respuesta", OracleDbType.Varchar2);
                        outparams.Direction = System.Data.ParameterDirection.Output;
                        cmd.Parameters.Add(outparams).Size = 1000;

                        OracleParameter outparams_uuid = new OracleParameter("V_UUID", OracleDbType.Varchar2);
                        outparams_uuid.Direction = System.Data.ParameterDirection.Output;
                        cmd.Parameters.Add(outparams_uuid).Size = 1000;
                        object returnValue;
                        object id = 0;



                        try
                        {
                            cmd.Connection.Open();
                            returnValue = cmd.ExecuteScalar();
                            dP.respuesta = outparams.Value.ToString();
                            dP.uuid = outparams_uuid.Value.ToString();
                        }
                        catch (Exception ex)
                        {

                            dP.respuesta = ex.ToString() + "No se pudo reportar la venta con Assist\nInformar al departamento de Sistemas";
                            throw ex;
                            return dP;
                        }
                        finally
                        {

                            cmd.Connection.Close();
                            cmd.Connection.Dispose();
                           //OracleConnection.ClearPool(cnx);
                        }

                    }
                }

                return dP;
            }
            catch (Exception E)
            {
                dP.respuesta = E.ToString();
            }
            return dP;
        }

        public static string existeTimbreT(string folio, string lote)
        {
            try
            {
                string sentencia = "SELECT     folio_fel ,     uuid  FROM     traspaso_facturas WHERE     referencia = '" + folio + "'    AND lote ='" + lote + "'";
                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                        if (oreader.HasRows)
                        {
                            return oreader["FOLIO_FEL"].ToString() + "|" + oreader["UUID"].ToString();
                        }
                        else
                        {

                        }

                    }
                    if (null != cnx)
                    {
                        cnx.Close();
                        cnx.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());
                return "Exception";
            };
            return "0|0";
        }
        public static List<int> sucursalesParaTimbrar()
        {
            List<int> sucV = new List<int>();
            
                
                string sentencia = "SELECT SUCURSALES_ID FROM CS_SUCURSAL_EMITE_FACTURA";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                sucV.Add(int.Parse((oreader["SUCURSALES_ID"].ToString())));
                            }
                            return sucV;
                        }
                        else
                        {

                        }

                    }

                }

                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return sucV;
                }
                finally {
                    if (null != cnx)
                    {
                        cnx.Close();
                        cnx.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                }
            }
            return sucV;
        }

        public static int ObtenTpoMovInvIDTraspaso(string folio, string lote)
        {


            string sentencia = "SELECT CASE WHEN sucursal_ORIGEN = ( SELECT sucursalid FROM configuracion ) THEN 3 ELSE 12 END tipo_mov_inv_id" +
                " FROM traspaso t WHERE  folio = :v_folio AND lote = :v_lote";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("v_folio", folio);
                    cmd.Parameters.Add("v_lote", lote);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            int tipoId; //Almacena 1 si el parametro esta activo o 0 si está inactivo

                            tipoId = int.Parse(oreader["TIPO_MOV_INV_ID"].ToString());

                            return tipoId;
                        }
                    }

                }

            }
            return -1;
        }

        #region ROMA
        // ROMA 20AGO2013

        public static int SetSolicitado(string NoFolio, string NoLote, int NoPartida, string Edo)
        {
            String ProductName = "Traspasos";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_upd_edo_solicitado";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int16, NoLote, ParameterDirection.Input);
                cmd.Parameters.Add("NoPartida", OracleDbType.Int16, NoPartida, ParameterDirection.Input);
                cmd.Parameters.Add("Edo", OracleDbType.Char, Edo, ParameterDirection.Input);

                // Execute the command
                cmd.ExecuteNonQuery();

                //MessageBox.Show(pCancela.Value.ToString() + " - El Traspaso se Cancelo", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

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
        // ROMA 20AGO2013

        // ROMA 25AGO2013
        public static string SetTraspasoPedido(string refpedido, string userSurte, string NoFolio, int SucId, string UsrId, int Origen, int Destino, string IdArt, int Cant, string lotep, DateTime caducidad, string Solicitado, int idM)
        {
            String ProductName = "Traspasos";
            String Result = string.Empty;
            Solicitado = "S";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_traspaso_pedido";
                cmd.BindByName = true;
                if (lotep == "")
                    lotep = "0";
                // OUT REF CURSOR bound
                OracleParameter pResult = cmd.Parameters.Add("Result", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("NFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("SucId", OracleDbType.Int16, SucId, ParameterDirection.Input);
                cmd.Parameters.Add("NLote", OracleDbType.Int16, Convert.ToInt16(lotep), ParameterDirection.Input);
                cmd.Parameters.Add("refPedido", OracleDbType.Varchar2, refpedido, ParameterDirection.Input);
                cmd.Parameters.Add("UsrID", OracleDbType.Varchar2, UsrId, ParameterDirection.Input);
                cmd.Parameters.Add("Origen", OracleDbType.Int16, Origen, ParameterDirection.Input);
                cmd.Parameters.Add("Destino", OracleDbType.Int16, Destino, ParameterDirection.Input);
                cmd.Parameters.Add("IdArticulo", OracleDbType.Varchar2, IdArt, ParameterDirection.Input);
                cmd.Parameters.Add("Cant", OracleDbType.Int16, Cant, ParameterDirection.Input);
                cmd.Parameters.Add("pSolicitado", OracleDbType.Varchar2, Solicitado, ParameterDirection.Input);
                cmd.Parameters.Add("UsrSurtido", OracleDbType.Varchar2, userSurte, ParameterDirection.Input);
                cmd.Parameters.Add("idMotivo", OracleDbType.Int16, Convert.ToInt16(idM), ParameterDirection.Input);

                // Execute the command
                OracleDataReader _rdrObj = cmd.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        Result = _rdrObj.GetString(_rdrObj.GetOrdinal("msg"));
                    }
                }
                else
                {
                    Result = "NO existe información de Traspasos...";
                }
                _rdrObj.Close();
                _rdrObj.Dispose();

                return Result;
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
                return Oex.Number.ToString();
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ex.Message;
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

        public static DataTable GetTraspasoDet(string Folio, SIFModelo.Sucursal Sucursal)
        {
            int Partidas = 1;
            Cursor.Current = Cursors.WaitCursor;
            String ProductName = "Traspasos";
            DataTable dtTraspaso = new DataTable();
            dtTraspaso.Columns.Add("lote", typeof(int));
            DataColumn workCol = dtTraspaso.Columns.Add("Partida", typeof(int));
            workCol.AllowDBNull = false;
            workCol.Unique = true;
            workCol.AutoIncrement = true;
            workCol.AutoIncrementSeed = 1;
            workCol.AutoIncrementStep = 1;

            dtTraspaso.Columns.Add("id", typeof(string));
            dtTraspaso.Columns.Add("nombre", typeof(string));
            dtTraspaso.Columns.Add("Nolote", typeof(string));
            dtTraspaso.Columns.Add("FechaCad", typeof(string));
            dtTraspaso.Columns.Add("pedido", typeof(int));
            dtTraspaso.Columns.Add("enviado", typeof(int));
            dtTraspaso.Columns.Add("Recibido", typeof(int));
            dtTraspaso.Columns.Add("Existencia", typeof(int));
            dtTraspaso.Columns.Add("Costo", typeof(double));
            dtTraspaso.Columns.Add("caja", typeof(int));
            dtTraspaso.Columns.Add("solicita", typeof(string));
            dtTraspaso.Columns.Add("total", typeof(double), "enviado * Costo");
            dtTraspaso.PrimaryKey = new DataColumn[] { dtTraspaso.Columns["id"] };

            int nRow = 1, ind = 0;

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                dtTraspaso.Clear();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_get_tradeta";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pPedido = cmd.Parameters.Add("Det", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);

                OracleDataReader _rdrObj = cmd.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        // Data Table Traspaso
                        DataRow RegArt = dtTraspaso.Rows.Find(_rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")));
                        if (RegArt == null)
                        { //buscamos la existencia del articulo
                            String caducidad = "";
                            String RefLote = "";
                            try
                            {
                                if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("CADUCIDAD")) == false)
                                    caducidad = _rdrObj.GetString(_rdrObj.GetOrdinal("CADUCIDAD"));
                                if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("REFLOTE")) == false)
                                    RefLote = _rdrObj.GetString(_rdrObj.GetOrdinal("REFLOTE"));
                            }
                            catch { }
                            /// 
                            if (_rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")).ToString().Contains("S"))
                            {
                                dtTraspaso.Rows.Add(_rdrObj.GetDecimal(_rdrObj.GetOrdinal("Lote")), Partidas,
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")),
                                              RefLote,
                                              caducidad,
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Recibido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Existencias")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Precio")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")));
                            }
                            else
                            {
                                dtTraspaso.Rows.Add(_rdrObj.GetDecimal(_rdrObj.GetOrdinal("Lote")), Partidas,
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")),
                                              RefLote,
                                              caducidad,
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Recibido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Existencias")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Precio")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")));
                            }
                            Partidas++;
                        }
                        else
                        {
                            RegArt["enviado"] = int.Parse(RegArt["enviado"].ToString()) + _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado"));
                            RegArt["caja"] = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja"));
                        }

                        ind++;
                    }
                }
                else
                {
                    //Grd_PedidoDet.Rows.Clear();
                   MessageBox.Show("NO existe información de Traspasos...", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            return dtTraspaso;
        }

        /*****************************************************************************************/
        public static DataTable GetTraspasoDetPorID(string Folio, String idarticulo)
        {
            int Partidas = 1;
            Cursor.Current = Cursors.WaitCursor;
            String ProductName = "Traspasos";
            DataTable dtTraspaso = new DataTable();
            dtTraspaso.Columns.Add("lote", typeof(int));
            DataColumn workCol = dtTraspaso.Columns.Add("Partida", typeof(int));
            workCol.AllowDBNull = false;
            workCol.Unique = true;
            workCol.AutoIncrement = true;
            workCol.AutoIncrementSeed = 1;
            workCol.AutoIncrementStep = 1;

            dtTraspaso.Columns.Add("id", typeof(string));
            dtTraspaso.Columns.Add("nombre", typeof(string));
            dtTraspaso.Columns.Add("Nolote", typeof(string));
            dtTraspaso.Columns.Add("FechaCad", typeof(string));
            dtTraspaso.Columns.Add("pedido", typeof(int));
            dtTraspaso.Columns.Add("enviado", typeof(int));
            dtTraspaso.Columns.Add("Recibido", typeof(int));
            dtTraspaso.Columns.Add("Existencia", typeof(int));
            dtTraspaso.Columns.Add("Costo", typeof(double));
            dtTraspaso.Columns.Add("caja", typeof(int));
            dtTraspaso.Columns.Add("solicita", typeof(string));
            dtTraspaso.Columns.Add("total", typeof(double), "enviado * Costo");
            dtTraspaso.PrimaryKey = new DataColumn[] { dtTraspaso.Columns["id"] };

            int nRow = 1, ind = 0;

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                dtTraspaso.Clear();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = " SELECT d.lote, d.num_partida, d.articulo_id articulo, d.concepto nombre, d.cantidad_solicitada Pedido, d.cantidad_enviada Enviado, " +
                                  " d.cantidad_recibida Recibido,d.precio_envia Precio,d.precio_recibe PrecioR,d.caja Caja, inv.EXISTENCIAS Existencias" +
                                  " FROM traspaso t, traspaso_det d, INVENTARIO inv " +
                                  " WHERE  t.folio = '" + Folio + "' AND t.folio = d.folio " +
                                       "AND t.lote = d.lote AND d.articulo_id = '" + idarticulo + "' AND d.ARTICULO_ID = inv.ARTICULO_ID";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pPedido = cmd.Parameters.Add("Det", OracleDbType.RefCursor, ParameterDirection.Output);
                OracleDataReader _rdrObj = cmd.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        // Data Table Traspaso
                        DataRow RegArt = dtTraspaso.Rows.Find(_rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")));
                        if (RegArt == null)
                        { //buscamos la existencia del articulo
                            String caducidad = "";
                            String RefLote = "";
                            try
                            {
                                if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("CADUCIDAD")) == false)
                                    caducidad = _rdrObj.GetString(_rdrObj.GetOrdinal("CADUCIDAD"));
                                if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("REFLOTE")) == false)
                                    RefLote = _rdrObj.GetString(_rdrObj.GetOrdinal("REFLOTE"));
                            }
                            catch { }

                            dtTraspaso.Rows.Add(_rdrObj.GetDecimal(_rdrObj.GetOrdinal("Lote")),
                                              _rdrObj.GetInt32(_rdrObj.GetOrdinal("num_partida")),///Partidas,
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")),
                                              RefLote,
                                              caducidad,
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Recibido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Existencias")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Precio")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja")));
                            
                            
                        }
                        else
                        {
                            RegArt["enviado"] = int.Parse(RegArt["enviado"].ToString()) + _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado"));
                            RegArt["caja"] = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja"));
                        }

                        ind++;
                    }
                }
                else
                {
                    //Grd_PedidoDet.Rows.Clear();
                   MessageBox.Show("NO existe información de Traspasos...", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            return dtTraspaso;
        }
        /*****************************************************************************************/

        public static DataTable GetTraspasoDet(string Folio, int Lote)
        {
            int Partidas = 1;
            Cursor.Current = Cursors.WaitCursor;
            String ProductName = "Traspasos";
            DataTable dtTraspaso = new DataTable();
            dtTraspaso.Columns.Add("lote", typeof(int));
            DataColumn workCol = dtTraspaso.Columns.Add("Partida", typeof(int));
            workCol.AllowDBNull = false;
            workCol.Unique = true;
            workCol.AutoIncrement = true;
            workCol.AutoIncrementSeed = 1;
            workCol.AutoIncrementStep = 1;

            dtTraspaso.Columns.Add("id", typeof(string));
            dtTraspaso.Columns.Add("nombre", typeof(string));
            dtTraspaso.Columns.Add("Nolote", typeof(string));
            dtTraspaso.Columns.Add("FechaCad", typeof(string));
            dtTraspaso.Columns.Add("pedido", typeof(int));
            dtTraspaso.Columns.Add("enviado", typeof(int));
            dtTraspaso.Columns.Add("Recibido", typeof(int));
            dtTraspaso.Columns.Add("Incidencia", typeof(int));
            dtTraspaso.Columns.Add("Existencia", typeof(int));
            dtTraspaso.Columns.Add("Costo", typeof(double));
            dtTraspaso.Columns.Add("caja", typeof(int));
            dtTraspaso.Columns.Add("solicita", typeof(string));
            dtTraspaso.Columns.Add("devuelta", typeof(int));
            dtTraspaso.Columns.Add("devolucion", typeof(string)); // typeof(int));
            dtTraspaso.Columns.Add("Procesado", typeof(string));//L 21/11/2013
            dtTraspaso.Columns.Add("total", typeof(double), "enviado * Costo");
            dtTraspaso.Columns.Add("escdev", typeof(double), "Recibido - devuelta");            
            dtTraspaso.PrimaryKey = new DataColumn[] { dtTraspaso.Columns["id"] };

            int nRow = 1, ind = 0;

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                dtTraspaso.Clear();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_get_tradeta";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pPedido = cmd.Parameters.Add("Det", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Decimal, Lote, ParameterDirection.Input);

                OracleDataReader _rdrObj = cmd.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        // Data Table Traspaso
                        DataRow RegArt = dtTraspaso.Rows.Find(_rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")));
                        if (RegArt == null)
                        { //buscamos la existencia del articulo
                            String caducidad = "";
                            String RefLote = "";
                            try
                            {
                                if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("CADUCIDAD")) == false)
                                    caducidad = _rdrObj.GetString(_rdrObj.GetOrdinal("CADUCIDAD"));
                                if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("REFLOTE")) == false)
                                    RefLote = _rdrObj.GetString(_rdrObj.GetOrdinal("REFLOTE"));
                            }
                            catch { }
                            /// 
                            if (_rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")).ToString().Contains("S"))
                            {
                                dtTraspaso.Rows.Add(_rdrObj.GetDecimal(_rdrObj.GetOrdinal("Lote")), Partidas,
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")),
                                              RefLote,
                                              caducidad,
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Recibido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Incidencia")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Existencias")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Precio")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Devuelta")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("devolucion")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Procesado")));
                            }
                            else
                            {
                                dtTraspaso.Rows.Add(_rdrObj.GetDecimal(_rdrObj.GetOrdinal("Lote")), Partidas,
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Articulo")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")),
                                              RefLote,
                                              caducidad,
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Pedido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Recibido")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Incidencia")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Existencias")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Precio")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Solicitado")),
                                              _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Devuelta")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("devolucion")),
                                              _rdrObj.GetString(_rdrObj.GetOrdinal("Procesado")));
                            }
                            Partidas++;
                        }
                        else
                        {
                            RegArt["enviado"] = int.Parse(RegArt["enviado"].ToString()) + _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Enviado"));
                            RegArt["caja"] = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("Caja"));
                        }

                        ind++;
                    }
                }
                else
                {
                    //Grd_PedidoDet.Rows.Clear();
                   MessageBox.Show("NO existe información de Traspasos...", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            return dtTraspaso;

        }

        // ROMA 25AGO2013

        // ROMA 03SEP2013

        public static string EnviaTraspasoSalida(string NoFolio, string NoLote, int Origen, int Destino)
        {
            string result = string.Empty;
            //string pError = "Error";
            //Regex objNotErrorPattern = new Regex(@"[^Error]");

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_ins_traspaso_salida";
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
                        result += _rdrObj.GetValue(0).ToString();
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

        public static string SetTraspasoPedidoArt(string NoFolio, string NoLote, int SucId, string IdArt, int Cant)
        {
            String ProductName = "Traspasos";
            String Result = string.Empty;
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_delart_traspaso_pedido";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pResult = cmd.Parameters.Add("Result", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("NFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("NLote", OracleDbType.Int16, NoLote, ParameterDirection.Input);
                cmd.Parameters.Add("SucId", OracleDbType.Int16, SucId, ParameterDirection.Input);
                cmd.Parameters.Add("IdArticulo", OracleDbType.Varchar2, IdArt, ParameterDirection.Input);
                cmd.Parameters.Add("Cant", OracleDbType.Int16, Cant, ParameterDirection.Input);

                // Execute the command
                OracleDataReader _rdrObj = cmd.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        Result = _rdrObj.GetString(_rdrObj.GetOrdinal("msg"));
                    }
                }
                else
                {
                    Result = "NO existe información de Traspasos...";
                }
                _rdrObj.Close();
                _rdrObj.Dispose();

                return Result;
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
                return Oex.Number.ToString();
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ex.Message;
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

        // ROMA 03SEP2013

        // ROMA 16SEP2013
        public static DataTable GetTipoDevolucion()
        {
            Cursor.Current = Cursors.WaitCursor;
            String ProductName = "Traspasos";
            DataTable dtTipoDev = new DataTable();
            dtTipoDev.Columns.Add("TipDev", typeof(string)); // typeof(int));
            dtTipoDev.Columns.Add("Devolucion", typeof(string));
            //dtTipoDev.PrimaryKey = new DataColumn[] { dtTipoDev.Columns["TipDev"] };

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                dtTipoDev.Clear();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_get_tipodev";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pPedido = cmd.Parameters.Add("Det", OracleDbType.RefCursor, ParameterDirection.Output);
                OracleDataReader _rdrObj = cmd.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        dtTipoDev.Rows.Add(_rdrObj.GetDecimal(_rdrObj.GetOrdinal("TipDev")).ToString(),
                                      _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")));
                        //dtTipoDev.Rows.Add(_rdrObj.GetString(_rdrObj.GetOrdinal("Nombre")) 
                        //    + " - " 
                        //    + _rdrObj.GetDecimal(_rdrObj.GetOrdinal("TipDev")));
                    }
                }
                else
                {
                   MessageBox.Show("NO existe información de Tipos de devolución...", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            return dtTipoDev;

        }

        public static int SetDevolucion(string NoFolio, string NoLote, int NoPartida, string Sol, string Edo, int Cant)
        {
            String ProductName = "Traspasos";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_upd_edo_devolucion";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int16, NoLote, ParameterDirection.Input);
                cmd.Parameters.Add("NoPartida", OracleDbType.Int16, NoPartida, ParameterDirection.Input);
                cmd.Parameters.Add("Sol", OracleDbType.Varchar2, Sol, ParameterDirection.Input);
                cmd.Parameters.Add("Edo", OracleDbType.Varchar2, Edo, ParameterDirection.Input);
                cmd.Parameters.Add("Cant", OracleDbType.Int16, Cant, ParameterDirection.Input);

                // Execute the command
                cmd.ExecuteNonQuery();

                //MessageBox.Show(pCancela.Value.ToString() + " - El Traspaso se Cancelo", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        public static int UpdTraspaso(string Folio, int[] Lote, double Total,
                                int[] Sec, String[] ArtId,
                                String[] Concepto, int[] CantS, int[] CantE, int[] CantR, int[] CantD, double[] PrecioE, double[] PrecioR, int[] Caja, String[] Pedido, String Usr_Envia,
                                String Usr_Recibe, String[] NoLote, String[] FechaCad, String[] TipDev)
        {
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            String ProductName = "Traspasos Almacen";
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_upd_traspaso"; // sp_upd_traspaso
                cmd.BindByName = true;

                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);

                OracleParameter InLote = cmd.Parameters.Add("Lote", OracleDbType.Decimal);
                InLote.Direction = ParameterDirection.Input;
                InLote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InLote.Value = Lote;

                cmd.Parameters.Add("TotalT", OracleDbType.Double, Total, ParameterDirection.Input);

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

                // IN Array Cantidad Solicitada
                OracleParameter InCantS = cmd.Parameters.Add("CantS", OracleDbType.Decimal);
                InCantS.Direction = ParameterDirection.Input;
                InCantS.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantS.Value = CantS;

                // IN Array Cantidad Enviada
                OracleParameter InCantE = cmd.Parameters.Add("CantE", OracleDbType.Decimal);
                InCantE.Direction = ParameterDirection.Input;
                InCantE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantE.Value = CantE;

                OracleParameter InCantR = cmd.Parameters.Add("CantR", OracleDbType.Decimal);
                InCantR.Direction = ParameterDirection.Input;
                InCantR.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantR.Value = CantR;

                OracleParameter InCantD = cmd.Parameters.Add("CantD", OracleDbType.Decimal);
                InCantD.Direction = ParameterDirection.Input;
                InCantD.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantD.Value = CantD;

                // IN Array Precio Envio
                OracleParameter InPrecioE = cmd.Parameters.Add("PrecioE", OracleDbType.Decimal);
                InPrecioE.Direction = ParameterDirection.Input;
                InPrecioE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecioE.Value = PrecioE;

                OracleParameter InPrecioR = cmd.Parameters.Add("PrecioR", OracleDbType.Decimal);
                InPrecioR.Direction = ParameterDirection.Input;
                InPrecioR.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecioR.Value = PrecioR;
                // IN Array Caja
                OracleParameter InCaja = cmd.Parameters.Add("Caja", OracleDbType.Decimal);
                InCaja.Direction = ParameterDirection.Input;
                InCaja.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCaja.Value = Caja;

                // IN Array Articulo en Pedido
                OracleParameter InPedido = cmd.Parameters.Add("Pedido", OracleDbType.Varchar2);
                InPedido.Direction = ParameterDirection.Input;
                InPedido.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPedido.Value = Pedido;

                // IN Array Tipo Devolucion
                OracleParameter InTipDev = cmd.Parameters.Add("TipDev", OracleDbType.Varchar2);
                InTipDev.Direction = ParameterDirection.Input;
                InTipDev.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InTipDev.Value = TipDev;

                //OracleParameter InNolote = cmd.Parameters.Add("eRefLote", OracleDbType.Varchar2);
                //InNolote.Direction = ParameterDirection.Input;
                //InNolote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                //InNolote.Value = NoLote;

                //OracleParameter InFechaCad = cmd.Parameters.Add("eCaducidad", OracleDbType.Varchar2);
                //InFechaCad.Direction = ParameterDirection.Input;
                //InFechaCad.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                //InFechaCad.Value = FechaCad;

                cmd.Parameters.Add("Usr_Envia", OracleDbType.Varchar2, Usr_Envia, ParameterDirection.Input);
                cmd.Parameters.Add("Usr_Recibe", OracleDbType.Varchar2, Usr_Recibe, ParameterDirection.Input);

                // OUT parameter
                OracleParameter pTraspaso =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pTraspaso.Value.ToString()))
                {
                    //if (Convert.ToDecimal(pTraspaso.Value.ToString()) > 0)
                    //   MessageBox.Show("Se actualizo el traspaso con el Folio " + pTraspaso.Value.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al actualizar el traspaso: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            return 0;
        }

        public static int ExistePedidoArt(string NoFolio, string NoLote, string IdArt, int Cant)
        {
            String ProductName = "Traspasos";
            String Result = string.Empty;
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_existe_articulo_pedido";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pExiste = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int16, NoLote, ParameterDirection.Input);
                cmd.Parameters.Add("IdArticulo", OracleDbType.Varchar2, IdArt, ParameterDirection.Input);
                cmd.Parameters.Add("Cant", OracleDbType.Int16, Cant, ParameterDirection.Input);
                // Execute the command
                cmd.ExecuteNonQuery();

                return Convert.ToInt32(pExiste.Value.ToString());

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // ROMA 16SEP2013

        // ROMA 26SEP2013
        public static int CierraDevolucionTraspaso(string UsuariosID, string NoFolio, string NoLote, int NoSuc)
        {
            String ProductName = "Traspasos";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_Cierra_DevTraspaso";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("UsrId", OracleDbType.Varchar2, UsuariosID, ParameterDirection.Input);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int32, NoLote, ParameterDirection.Input);
                cmd.Parameters.Add("NoSuc", OracleDbType.Int32, NoSuc, ParameterDirection.Input);

                // Execute the command
                cmd.ExecuteNonQuery();

               MessageBox.Show(pCancela.Value.ToString() + " - La devolución del Traspaso se Cerro ", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        // ROMA 26SEP2013

        public static int SetRecibido(string NoFolio, string NoLote, int NoPartida, int CantR, int CantD)
        {
            String ProductName = "Traspasos";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PEDIDO_TRASP.sp_upd_cant_recibido";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("NoLote", OracleDbType.Int16, NoLote, ParameterDirection.Input);
                cmd.Parameters.Add("NoPartida", OracleDbType.Int16, NoPartida, ParameterDirection.Input);
                cmd.Parameters.Add("CantR", OracleDbType.Int16, CantR, ParameterDirection.Input);
                cmd.Parameters.Add("CantD", OracleDbType.Int16, CantD, ParameterDirection.Input);

                // Execute the command
                cmd.ExecuteNonQuery();

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

        public static int GetTraspasoDetContieneLineas(string Folio, int Lote)
        {
            String query = "SELECT COUNT(DET.ARTICULO_ID) FROM TRASPASO_DET DET WHERE DET.FOLIO = :FOLIO AND DET.LOTE= :LOTE";
            using (OracleConnection CNX =  new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand CMD =  new OracleCommand(query,CNX))
                {
                    CMD.Parameters.Add("FOLIO", Folio);
                    CMD.Parameters.Add("LOTE", Lote);

                    CMD.Connection.Open();
                    var  COUNT = CMD.ExecuteScalar();
                    CMD.Connection.Close();
                    CMD.Connection.Dispose();
                   //OracleConnection.ClearPool(CNX);
                    return int.Parse(COUNT.ToString());
                }
                
            }
        }

        /*JMQ 08-02-2017*/
        public static List<SIFModelo.MotivoPedido> bdTipoPedido()
        {
            List<SIFModelo.MotivoPedido> rows = new List<SIFModelo.MotivoPedido>();
            string campos = " ID,    NOMBRE,   MAX_SKUS,      PARAMETRO_EOQ,    VALOR_EOQ,    PARAMETRO_EXIS  ";
            string sentencia = "select " + campos + " FROM cat_tipo_pedido  where activo_TRASP ='S'  ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                    SIFModelo.MotivoPedido registro = new SIFModelo.MotivoPedido();
                    if (oreader.HasRows)
                    {
                        registro.ID = 0;
                        registro.NOMBRE = "SELECCIONE...";
                        registro.MAX_SKUS = 0;                        
                        registro.PARAMETRO_EOQ = "~";
                        registro.VALOR_EOQ = 0;
                        registro.PARAMETRO_EXIS = "~";
                        rows.Add(registro);                      
                        while (oreader.Read())
                        {
                            registro = new SIFModelo.MotivoPedido();
                          registro.ID =Convert.ToInt32( oreader["ID"]);
                          registro.NOMBRE = oreader["NOMBRE"].ToString();
                          
                           registro.MAX_SKUS=Convert.ToInt32( oreader["MAX_SKUS"]);
                           //registro.CANT_PED_MAX_DIA=Convert.ToInt32( oreader["CANT_PED_MAX_DIA"]);
                           registro.PARAMETRO_EOQ=oreader["PARAMETRO_EOQ"].ToString();
                           registro.VALOR_EOQ=Convert.ToInt32( oreader["VALOR_EOQ"]);
                           registro.PARAMETRO_EXIS=oreader["PARAMETRO_EXIS"].ToString();
                           //registro.VALOR_EXIS¨=Convert.ToInt32( oreader["VALOR_EXIS"]);
                           //registro.ACTIVO=oreader["ACTIVO"].ToString();                           
                          rows.Add(registro);
                        }                    
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                    cnx.Dispose();
                }
            }
            return rows;
        }

        public static string bFoliot( string f)
        {
            
            string campos = " Distinct ID_MOTIVO_TRANS ";
            string sentencia = "select " + campos + " FROM  traspaso where folio = '"+f+"'";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                        SIFModelo.MotivoPedido registro = new SIFModelo.MotivoPedido();
                        if (oreader.HasRows)
                        {
                            return oreader["ID_MOTIVO_TRANS"].ToString();
                        }
                        else
                        {

                        }

                    }
                    
                }
                finally {
                    if (null != cnx)
                    {
                        cnx.Close();
                        cnx.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                }
            }
            
            return "";
        }


        public static List<string> GetDataEtiqueta(string v_folio, int v_lote)
        {
            List<String> _list = new List<String>();

            String query = 
                     " select 'FOLIO    : '|| folio LETRERO from traspaso  where folio ='" + v_folio + "' and lote=" + v_lote + " UNION ALL";
            query += " select 'LOTE     : '|| LOTE from traspaso  where folio ='" + v_folio + "' and lote=" + v_lote + " UNION ALL";
            query += " select 'FECHA_ENV: '|| to_char (FECHA_ENV,'DD/MM/RRRR HH24:MI:SS') from traspaso  where folio ='" + v_folio + "' and lote=" + v_lote + " UNION ALL";
            query += " select 'ACTIVO   : '|| ACTIVO from traspaso  where folio ='" + v_folio + "' and lote=" + v_lote + " UNION ALL";
            query += " select 'PZAS ENV : '|| SUM(CANTIDAD_ENVIADA) from traspaso_DET  where folio ='" + v_folio + "' and lote=" + v_lote + " UNION ALL";
            query += " select 'SUCURSAL : '|| (SELECT NOMBRE FROM CAT_SUCURSALES WHERE SUCURSALES_ID =T.SUCURSAL_DESTINO) from traspaso T where folio ='" + v_folio + "' and lote=" + v_lote + " ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(query, cnx))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Connection.Open();
                    OracleDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            string s  = dr["LETRERO"].ToString();
                            
                            _list.Add(s);
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);

                }
            }
            return _list;
        }


        public static int AsginaCaduciadesTraspasoSalida(string  documento , int tipo_mov_inv_id)//cierratraspaso
        {
            
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
           // int Recibido = 0;
            conn.Open();
           
            try
            {
                //if (Recibido == 0)
                // {
                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                OracleParameter pCancela = cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);
                
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Pkg_Caducidades_V2.cierra_trasp_caducidades";
                    cmd.BindByName = true;

                    // OUT REF CURSOR bound
                    
                    cmd.Parameters.Add("pe_documento", OracleDbType.Varchar2, documento, ParameterDirection.Input);
                    cmd.Parameters.Add("pe_id_movimiento", OracleDbType.Int32, tipo_mov_inv_id, ParameterDirection.Input);
                    // Execute the command
                    cmd.ExecuteNonQuery();

                   

                    return Convert.ToInt32(pCancela.Value.ToString());

                //}
                //else 
                
               
            }
            catch (OracleException Oex)
            {
               
                return Oex.Number * -1;
            }
            catch (Exception ex)
            {
                
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
        public static string ValidaSalida3(string Folio, string lote)
        {
            //List<SIFModelo.BonificacionDet_Caducidad> articulos = new List<SIFModelo.BonificacionDet_Caducidad>();
            //SIFModelo.BonificacionDet_Caducidad det = new SIFModelo.BonificacionDet_Caducidad();
            string sentencia = "sp_asingcad_td_lote_caducidad";
            string RESPUESTA;
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;

                    //PARAMETROS
                    cmd.Parameters.Add("v_folio", OracleDbType.Varchar2, 15, Folio, ParameterDirection.Input);
                    cmd.Parameters.Add("v_lote", OracleDbType.Int32, 15, int.Parse(lote), ParameterDirection.Input);
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("v_resp", OracleDbType.Int32);
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
        public static  string  getNumeroLotesSku1( string  psku)
        {


            string respuesta = string.Empty;
            string sentencia = "select F_CTN_LOTES_I ('"+ psku + "')  lotes from dual";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                respuesta=oreader["LOTES"].ToString();
                            }
                            return respuesta;
                        }
                    }
                }

                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return "eroorrrrrrrrrrrrrrrrrrrrrrrrrrrr"+e.ToString();
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
            return respuesta;
        }

        public static string getActivotrasp(string folio,int lote)
        {


            string respuesta = string.Empty;
            string sentencia = "select * from traspaso where folio='"+folio+"' and lote="+lote+"";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                respuesta = oreader["activo"].ToString();
                            }
                            return respuesta;
                        }
                    }
                }

                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return "eror al obtener el activo del traspaso" + e.ToString();
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
            return respuesta;
        }

        public static DataTable getSucursalEnviatrasp(string folio, int lote)
        {
            DataTable dt = new DataTable("traspaso");
            
            dt.Columns.Add("Sucursal_origen",typeof(int));
            dt.Columns.Add("Sucursal_destino",typeof(int));

            int respuesta = 0;
            string sentencia = "select * from traspaso where folio='" + folio + "' and lote=" + lote + "";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                        if (oreader.HasRows)
                        {
                            DataRow row=dt.NewRow();
                            while (oreader.Read())
                            {
                                row["sucursal_origen"] = int.Parse(oreader["sucursal_origen"].ToString());
                                row["sucursal_destino"] = int.Parse(oreader["sucursal_destino"].ToString());
                                dt.Rows.Add(row);
                            }
                            return dt;
                        }
                    }
                }

                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return dt;
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
            return dt;
        }


        //  public void  SaveError(string CodigoError)
        //  {

        //      try
        //      {

        //          string maquina = System.Environment.MachineName;

        //          string sentencia = "INSERT INTO FARMACIA.SIF3_BITACORA_ERROR ( " +
        //" USUARIO, PROCESO, REFERENCIA, MENSAJE, FECHA,ARTICULO,CANTIDAD) " +    "VALUES (  '304 ','ASIGNA CADUCIDAD',"  + "', '" +     parametros + "',



        //          using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
        //          {
        //              using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
        //              {
        //                  cmd.Connection.Open();
        //                  cmd.ExecuteNonQuery();
        //                  cmd.Connection.Close();


        //                  cmd.Connection.Dispose();
        //                  //OracleConnection.ClearPool(cnx);
        //              }

        //          }
        //      }
        //      catch (Exception EX)
        //      {

        //      }


        //  }

        #endregion ROMA
    }
}
