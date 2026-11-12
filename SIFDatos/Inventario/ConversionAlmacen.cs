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
    public class ConversionAlmacen
    {
        public static SIFModelo.Inventarios.InventarioDataSet GetConversion(string Ini, string Fin,String Activo,String Folio, SIFModelo.Sucursal sucursal)
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
                    cmd.CommandText = "PKG_INVENTARIOS.sp_get_Conversion";
                    cmd.BindByName = true;
                    if (Folio == "") Folio = "0";
                    // OUT REF CURSOR bound
                    OracleParameter pPedido = cmd.Parameters.Add("Hdr", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.Parameters.Add("SucId", OracleDbType.Decimal, sucursal.SucursalesID, ParameterDirection.Input);
                    cmd.Parameters.Add("FecIni", OracleDbType.Varchar2, Ini, ParameterDirection.Input);
                    cmd.Parameters.Add("FecFin", OracleDbType.Varchar2, Fin, ParameterDirection.Input);
                    cmd.Parameters.Add("Folio", OracleDbType.Varchar2, Folio, ParameterDirection.Input);

                    
                }
                else
                {  cmd.CommandText = " SELECT Conversion_ID as Folio,  TO_CHAR(Fecha_reg, 'DD/MM/YYYY HH24:MI:SS') Fecha,  " +
                                     " usuario_ID,referencia,activo FROM conversion " +
                                     " WHERE  Conversion_ID like '%" + Folio + "%'";
                            
                 cmd.BindByName = true;
                
                
                }
                OracleDataReader _rdrObj = cmd.ExecuteReader();
                //Grd_Pedido.Rows.Add(_rdrObj.RecordsAffected);



                while (_rdrObj.Read())
                {
                    
                    SIFModelo.Inventarios.InventarioDataSet.CONVERSIONRow rw = DsInventario.CONVERSION.NewCONVERSIONRow();
                    var folio = _rdrObj["Folio"]; //_rdrObj.GetOrdinal("FOLIO");
                    rw.CONVERSION_ID = folio.ToString();
                    rw.FECHA = _rdrObj.GetString(_rdrObj.GetOrdinal("FECHA"));
                    rw.USUARIO_ID = _rdrObj.GetString(_rdrObj.GetOrdinal("USUARIO_ID"));
                    rw.REFERENCIA = _rdrObj.GetString(_rdrObj.GetOrdinal("REFERENCIA"));
                    rw.ESTADO = _rdrObj.GetString(_rdrObj.GetOrdinal("ACTIVO"));
                    if (Activo == "" || Activo == rw.ESTADO)
                    DsInventario.CONVERSION.AddCONVERSIONRow(rw);

                    OracleCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandText = "PKG_INVENTARIOS.sp_get_ConversionDet";
                    cmd1.BindByName = true;

                // OUT REF CURSOR bound
                    OracleParameter pPedido1 = cmd1.Parameters.Add("Hdr", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd1.Parameters.Add("Folio", OracleDbType.Varchar2, folio, ParameterDirection.Input);
                    cmd1.Parameters.Add("SucId", OracleDbType.Int32, sucursal.SucursalesID, ParameterDirection.Input);


                    OracleDataAdapter da = new OracleDataAdapter(cmd1);
                    da.Fill(DsInventario, "CONVERSION_DET");
                
                }


                _rdrObj.Close();
                _rdrObj.Dispose();

                
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "conversion", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
       public static SIFModelo.Inventarios.InventarioDataSet GetConversion(string Folio, SIFModelo.Sucursal Suc)
       {
           return SIFDatos.Inventario.ConversionAlmacen.GetConversion("", "", "", Folio, Suc);
       }
       
        public static void InsConversion(SIFModelo.Sucursal sucursal, String Referencia, String Fecha, String UsuarioID,
                                 String Estado,
                                 String[] ArtId,
                                 String[] Nombre,
                                 int[] Cant,
                                 String[] EquiID,  
                                 String[] EquiDes,
                                 int[] CantE,
                                double[] Costo, double[] CostoE,int[] Sec)
        {
            string ProductName = "Conversion";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_INVENTARIOS.sp_Ins_Conversion";
                cmd.BindByName = true;

                cmd.Parameters.Add("Origen", OracleDbType.Decimal, sucursal.SucursalesID, ParameterDirection.Input);
                cmd.Parameters.Add("eREFERENCIA", OracleDbType.Varchar2, Referencia, ParameterDirection.Input);
                cmd.Parameters.Add("eUSUARIO_ID", OracleDbType.Varchar2, UsuarioID, ParameterDirection.Input);
                cmd.Parameters.Add("eESTADO", OracleDbType.Varchar2, Estado, ParameterDirection.Input);
                

                // Input Array Lote
                OracleParameter InLote = cmd.Parameters.Add("eARTICULO_ID", OracleDbType.Varchar2);
                InLote.Direction = ParameterDirection.Input;
                InLote.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InLote.Value = ArtId;

                // IN Array Articulos
                OracleParameter InNombre = cmd.Parameters.Add("eNOMBRE1", OracleDbType.Varchar2);
                InNombre.Direction = ParameterDirection.Input;
                InNombre.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InNombre.Value = Nombre;


                // IN Array Cantidad
                OracleParameter InCant = cmd.Parameters.Add("eCANTIDAD", OracleDbType.Decimal);
                InCant.Direction = ParameterDirection.Input;
                InCant.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCant.Value = Cant;

                OracleParameter InArticuloe = cmd.Parameters.Add("eARTICULO_IDE", OracleDbType.Varchar2);
                InArticuloe.Direction = ParameterDirection.Input;
                InArticuloe.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InArticuloe.Value = EquiID;


                OracleParameter InNombre1e = cmd.Parameters.Add("eNOMBRE1E", OracleDbType.Varchar2);
                InNombre1e.Direction = ParameterDirection.Input;
                InNombre1e.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InNombre1e.Value = EquiDes;

                // IN Array Precio
                OracleParameter InPrecio = cmd.Parameters.Add("eCANTIDADE", OracleDbType.Double);
                InPrecio.Direction = ParameterDirection.Input;
                InPrecio.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPrecio.Value = CantE;

                // IN Array Precio Venta
                OracleParameter InCosto = cmd.Parameters.Add("eCOSTO", OracleDbType.Double);
                InCosto.Direction = ParameterDirection.Input;
                InCosto.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCosto.Value = Costo;

                OracleParameter InCostoE = cmd.Parameters.Add("eCOSTOe", OracleDbType.Double);
                InCostoE.Direction = ParameterDirection.Input;
                InCostoE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCostoE.Value = CostoE;

                OracleParameter InSec = cmd.Parameters.Add("eSec", OracleDbType.Decimal);
                InSec.Direction = ParameterDirection.Input;
                InSec.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InSec.Value = Sec;

                // OUT parameter
                OracleParameter pPedido =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pPedido.Value.ToString()))
                {
                   MessageBox.Show("Se creo  la conversión con el folio " + pPedido.Value.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al crear la conversion: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        


        public static void UpdConversion(string Folio, String Referencia, String UsuarioID, String Estado,
                                String[] ArtId, String[] Nombre,
                                int[] Cant, String[] ArtidIDe, String[] NombreE,
                                int[] CantE, double[] Costo, double[] CostoE, int[] Sec)
        {

            string ProductName = "Ajustes";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_INVENTARIOS.sp_Upd_Conversion";
                cmd.BindByName = true;

                cmd.Parameters.Add("eFOLIO", OracleDbType.Int16, Folio, ParameterDirection.Input);
                cmd.Parameters.Add("eREFERENCIA", OracleDbType.Varchar2, Referencia, ParameterDirection.Input);
                cmd.Parameters.Add("eUSUARIO_ID", OracleDbType.Varchar2,UsuarioID, ParameterDirection.Input);
                cmd.Parameters.Add("eESTADO", OracleDbType.Varchar2, Estado, ParameterDirection.Input);
              

                // Input Array Sec
                OracleParameter InArtID = cmd.Parameters.Add("eARTICULO_ID", OracleDbType.Varchar2);
                InArtID.Direction = ParameterDirection.Input;
                InArtID.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InArtID.Value = ArtId;

                // IN Array ID's
                OracleParameter InNombre = cmd.Parameters.Add("eNOMBRE1", OracleDbType.Varchar2);
                InNombre.Direction = ParameterDirection.Input;
                InNombre.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InNombre.Value = Nombre;

                // IN Array Articulos
                OracleParameter InCantidad = cmd.Parameters.Add("eCANTIDAD", OracleDbType.Int16);
                InCantidad.Direction = ParameterDirection.Input;
                InCantidad.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad.Value = Cant;

                // IN Array Concepto
                OracleParameter InArtIDe = cmd.Parameters.Add("eARTICULO_IDE", OracleDbType.Varchar2);
                InArtIDe.Direction = ParameterDirection.Input;
                InArtIDe.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InArtIDe.Value = ArtidIDe;

                // IN Array Cantidad
                OracleParameter InNombreE = cmd.Parameters.Add("eNOMBRE1E", OracleDbType.Varchar2);
                InNombreE.Direction = ParameterDirection.Input;
                InNombreE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InNombreE.Value = NombreE;

                // IN Array Precio
                OracleParameter InCantidadE = cmd.Parameters.Add("eCANTIDADE", OracleDbType.Int16);
                InCantidadE.Direction = ParameterDirection.Input;
                InCantidadE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidadE.Value = CantE;

                // IN Array Precio Venta
                OracleParameter InCosto = cmd.Parameters.Add("eCOSTO", OracleDbType.Double);
                InCosto.Direction = ParameterDirection.Input;
                InCosto.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCosto.Value = Costo;

                // IN Array Precio Venta
                OracleParameter InCostoE = cmd.Parameters.Add("eCOSTOe", OracleDbType.Double);
                InCostoE.Direction = ParameterDirection.Input;
                InCostoE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCostoE.Value = CostoE;

                // IN Array Precio Venta
                OracleParameter InSec = cmd.Parameters.Add("eSEC", OracleDbType.Int16);
                InSec.Direction = ParameterDirection.Input;
                InSec.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InSec.Value = Sec;
                // OUT parameter
                OracleParameter pPedido =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pPedido.Value.ToString()))
                {
                    if (Convert.ToDecimal(pPedido.Value.ToString()) > 0)
                       MessageBox.Show("Se actualizo la conversion con el Folio " + pPedido.Value.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al actualizar la conversion: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static void CancelaConversion(string Folio)
        {

            string ProductName = "Ajustes";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update conversion set ESTADO='X' WHERE CONVERSION_ID=" + Folio;
                cmd.BindByName = true;


                // Execute the command
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al actualizar la conversion: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static int AplicaConversion(string Folio,  int Sucursal, string Usuario,
                                    String[] ArtId, String[] Nombre, int[] Cant, String[] ArtIDe,
                                    String[] NombreE, int[] CantE, double[] Costo, double[] CostoE)
        {
            string ProductName = "Conversiones";
            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_INVENTARIOS.sp_Act_Conversion";

                cmd.BindByName = true;

                cmd.Parameters.Add("FOLIO", OracleDbType.Varchar2, Folio, ParameterDirection.Input);
                cmd.Parameters.Add("Sucursal", OracleDbType.Int16, Sucursal, ParameterDirection.Input);
                cmd.Parameters.Add("USUARIO_ID", OracleDbType.Varchar2, Usuario, ParameterDirection.Input);

                // IN Array ID's
                OracleParameter InArtId = cmd.Parameters.Add("ARTICULO_ID", OracleDbType.Varchar2);
                InArtId.Direction = ParameterDirection.Input;
                InArtId.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InArtId.Value = ArtId;

                // IN Array Cantidad
                OracleParameter InNombre = cmd.Parameters.Add("NOMBRE1", OracleDbType.Varchar2);
                InNombre.Direction = ParameterDirection.Input;
                InNombre.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InNombre.Value = Nombre;

                OracleParameter InCantidad = cmd.Parameters.Add("CANTIDAD", OracleDbType.Int16);
                InCantidad.Direction = ParameterDirection.Input;
                InCantidad.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidad.Value = Cant;

                OracleParameter InArtIDE = cmd.Parameters.Add("ARTICULO_IDE", OracleDbType.Varchar2);
                InArtIDE.Direction = ParameterDirection.Input;
                InArtIDE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InArtIDE.Value = ArtIDe;

                OracleParameter InNombreE = cmd.Parameters.Add("NOMBRE1E", OracleDbType.Varchar2);
                InNombreE.Direction = ParameterDirection.Input;
                InNombreE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InNombreE.Value = NombreE;

                OracleParameter InCantidadE = cmd.Parameters.Add("CANTIDADE", OracleDbType.Int16);
                InCantidadE.Direction = ParameterDirection.Input;
                InCantidadE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCantidadE.Value = CantE;


                OracleParameter InCosto = cmd.Parameters.Add("eCOSTO", OracleDbType.Double);
                InCosto.Direction = ParameterDirection.Input;
                InCosto.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCosto.Value = Costo;

                OracleParameter InCostoE = cmd.Parameters.Add("eCOSTOe", OracleDbType.Double);
                InCostoE.Direction = ParameterDirection.Input;
                InCostoE.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCostoE.Value = CostoE;

                OracleParameter InSec = cmd.Parameters.Add("SEC", OracleDbType.Int16);
                InSec.Direction = ParameterDirection.Input;
                InSec.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InSec.Value = CostoE;

                // OUT parameter
                OracleParameter pAjuste =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pAjuste.Value.ToString()))
                {
                   MessageBox.Show("Se Aplico la conversion " + pAjuste.Value.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return Convert.ToInt32(pAjuste.Value.ToString());
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al aplicar la conversión: " + Environment.NewLine + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        

    }
}
