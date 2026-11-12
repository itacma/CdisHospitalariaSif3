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
    public class Bitacora
    {
        public static SIFModelo.Seguridad.Seguridad Get(String Fecini, String FecFin, SIFModelo.Seguridad.Seguridad ds, String UsuarioID)
        {
            
        
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand("", cnx))
                {
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_SEGURIDAD.Get_bitacoraModulo";
                    cmd.BindByName = true;
                    OracleParameter pPedido = cmd.Parameters.Add("Hdr", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.Parameters.Add("Fecini", OracleDbType.Varchar2, Fecini, ParameterDirection.Input);
                    cmd.Parameters.Add("FecFin", OracleDbType.Varchar2, FecFin, ParameterDirection.Input);
                    cmd.Parameters.Add("UsuarioID", OracleDbType.Varchar2, UsuarioID, ParameterDirection.Input);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "MODULOS");


                    cmd.CommandText = "PKG_SEGURIDAD.Get_bitacoraOpcion";
                    cmd.BindByName = true;
                    da.SelectCommand = cmd; //
                    da.Fill(ds, "OPCIONES");

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_SEGURIDAD.Get_bitacora";
                    cmd.BindByName = true;

                    // OUT REF CURSOR bound

                    da.SelectCommand = cmd;
                    da.Fill(ds, "BITACORA");
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);


                }


            }
            return ds;
           
        }

        
        public static void Insert(String Comentario,int Opcion_id,int Operacion_ID,String UsuarioId)
        {
             //
            try
            {
                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {
                    
                    OracleCommand cmd = cnx.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PKG_SEGURIDAD.Ins_bitacora";
                    cmd.BindByName = true;

                    cmd.Parameters.Add("OpcionID", OracleDbType.Int32, Opcion_id, ParameterDirection.Input);
                    cmd.Parameters.Add("OperacionID", OracleDbType.Int32, Operacion_ID, ParameterDirection.Input);
                    cmd.Parameters.Add("EComentario", OracleDbType.Varchar2, Comentario, ParameterDirection.Input);
                    cmd.Parameters.Add("UsuarioID", OracleDbType.Int32, int.Parse(UsuarioId), ParameterDirection.Input);

                    
                    
                    
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
               MessageBox.Show("Error al insertar bitacora: " + Environment.NewLine + ex.Message, "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
            }


        }      

    }
}
