using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;


namespace SIFDatos.Seguridad
{
    public class Privilegios
    {
        public static SIFModelo.Seguridad.Seguridad Get( SIFModelo.Seguridad.Seguridad ds, String UsuarioID)
        {
            String sentencia = "SELECT MODULO,MODULO_ID FROM MODULOS ORDER BY MODULO_ID "; //
        
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "MODULOS");

                    cmd.CommandText = "SELECT        MODULOS.MODULO, OPCIONES.OPCION,OPCIONES.OPCION_ID" +
                                      " FROM OPCIONES INNER JOIN MODULOS ON OPCIONES.MODULO_ID = MODULOS.MODULO_ID";

                    da.SelectCommand = cmd; //
                    da.Fill(ds, "OPCIONES");

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_SEGURIDAD.SP_GET_PERMISOS";
                    cmd.BindByName = true;

                    // OUT REF CURSOR bound
                    OracleParameter pPedido = cmd.Parameters.Add("REFCUR", OracleDbType.RefCursor, ParameterDirection.Output);

                    cmd.Parameters.Add("USUARIO", OracleDbType.Varchar2, UsuarioID, ParameterDirection.Input);

                    da.SelectCommand = cmd;
                    da.Fill(ds, "SEGURIDAD");
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);


                }


            }
            return ds;
           
        }

        public static Boolean Verifica(MetroTileItem Cts, String UsuarioID)
        {
            if (Cts.Tag == "" || Cts.Tag == null) return Cts.Enabled;
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                OracleCommand cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_SEGURIDAD.sp_AccesoModulo";
                cmd.BindByName = true;
                
                cmd.Parameters.Add("UsuarioID", OracleDbType.Varchar2, UsuarioID, ParameterDirection.Input);
                cmd.Parameters.Add("eModulo", OracleDbType.Int32, int.Parse(Cts.Tag.ToString()), ParameterDirection.Input);
                OracleParameter pPedido = cmd.Parameters.Add("Hdr", OracleDbType.RefCursor, ParameterDirection.Output);

                cmd.Connection.Open();
                // Execute the command
                cmd.ExecuteNonQuery();
                OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                if (oreader.HasRows)
                    return true;
                else
                    return false;
                cmd.Connection.Close();
                cmd.Dispose();
               //OracleConnection.ClearPool(cmd.Connection);

            }
            return false;
        }

        public static Boolean VerificaOpc(MetroTileItem Cts, String UsuarioID,int Modulo)
        {
            if (Cts.Tag == "" || Cts.Tag == null) return Cts.Enabled;
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                OracleCommand cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_SEGURIDAD.sp_AccesoOpcion";
                cmd.BindByName = true;

                cmd.Parameters.Add("UsuarioID", OracleDbType.Varchar2, UsuarioID, ParameterDirection.Input);
                cmd.Parameters.Add("eModulo", OracleDbType.Int32, Modulo, ParameterDirection.Input);
                cmd.Parameters.Add("eOpcion", OracleDbType.Int32, int.Parse(Cts.Tag.ToString()), ParameterDirection.Input);
                OracleParameter pPedido = cmd.Parameters.Add("Hdr", OracleDbType.RefCursor, ParameterDirection.Output);

                cmd.Connection.Open();
                // Execute the command
                cmd.ExecuteNonQuery();
                OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                if (oreader.HasRows)
                    return true;
                else
                    return false;
                cmd.Connection.Close();
                cmd.Dispose();
               //OracleConnection.ClearPool(cmd.Connection);

            }
            return false;
        }

        public static Boolean VerificaOperacion( String UsuarioID, int Opcion,int Operacion)
        {
            
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                OracleCommand cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_SEGURIDAD.sp_AccesoOperacion";
                cmd.BindByName = true;

                cmd.Parameters.Add("UsuarioID", OracleDbType.Varchar2, UsuarioID, ParameterDirection.Input);
                cmd.Parameters.Add("eOpcion", OracleDbType.Int32, Opcion, ParameterDirection.Input);
                cmd.Parameters.Add("eOperacion", OracleDbType.Int32, Operacion, ParameterDirection.Input);
                OracleParameter pPedido = cmd.Parameters.Add("Hdr", OracleDbType.RefCursor, ParameterDirection.Output);

                cmd.Connection.Open();
                // Execute the command
                cmd.ExecuteNonQuery();
                OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                if (oreader.HasRows)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);
                    return true;
                }
                else
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);
                    return false;
                }
            }
            return false;
        }
        public static SIFModelo.Seguridad.Seguridad Update(SIFModelo.Seguridad.Seguridad ds,String UsuarioID)
        {
             //
            try
            {
                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    DataRow[] rows = ds.SEGURIDAD.Select("activo=1");
                    int[] opciones =new int[rows.Length];
                    int i = 0;

                    foreach (DataRow row in rows)
                    {
                        if (Boolean.Parse(row["ACTIVO"].ToString()))
                        {
                            opciones[i] = int.Parse(row["ID"].ToString());
                            i++;
                        }

                    }
                    
                    OracleCommand cmd = cnx.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_SEGURIDAD.sp_upd_permisos";
                    cmd.BindByName = true;

                    cmd.Parameters.Add("UsuarioID", OracleDbType.Int32, int.Parse(UsuarioID), ParameterDirection.Input);

                    // Input Array Opcion
                    OracleParameter InOpc = cmd.Parameters.Add("OpcionID", OracleDbType.Int32);
                    InOpc.Direction = ParameterDirection.Input;
                    InOpc.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    InOpc.Value = opciones;
                    OracleParameter pPedido =
                    cmd.Parameters.Add("OutParam", OracleDbType.Int32, ParameterDirection.Output);
                    cmd.Connection.Open();
                    // Execute the command
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al act permisos: " + Environment.NewLine + ex.Message, "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
            }

            return ds;
           

        }


        public static int  VerificaAccesoIngreso(string pacceso_id , string ppass, out string pmensajeOut)
        {
            int _intReturn = -1;
            pmensajeOut = "";
            try
            {
                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    OracleCommand cmd = cnx.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_SEGURIDAD.sp_ValidaAcceso";
                    cmd.BindByName = true;

                    cmd.Parameters.Add("paccesoid", OracleDbType.Varchar2, pacceso_id, ParameterDirection.Input);
                    cmd.Parameters.Add("ppassword", OracleDbType.Varchar2, ppass, ParameterDirection.Input);

                    OracleParameter outparam = cmd.Parameters.Add("outparam", OracleDbType.Int32, ParameterDirection.Output);
                    OracleParameter outparamS = cmd.Parameters.Add("outparams", OracleDbType.Varchar2, ParameterDirection.Output);
                    outparamS.Size = 1000;


                    cmd.Connection.Open();
                    // Execute the command
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    _intReturn = int.Parse(outparam.Value.ToString());
                    pmensajeOut = outparamS.Value.ToString();



                    cmd.Connection.Close();
                    cmd.Dispose();
                    //OracleConnection.ClearPool(cmd.Connection);

                }
            }
            catch (Exception _x) {
                pmensajeOut = _x.ToString();
                _intReturn = -1;

            }
            return _intReturn;
        }


    }
}
