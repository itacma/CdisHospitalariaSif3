using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace SIFDatos
{
   public static class Compradores
    {
       public static SIFModelo.Catalogo.CatalogoDataSet.COMPRADORDataTable CargaCompradores()
       {
           SIFModelo.Catalogo.CatalogoDataSet dataSet = new SIFModelo.Catalogo.CatalogoDataSet();
           SIFModelo.Catalogo.CatalogoDataSetTableAdapters.COMPRADORTableAdapter ta = new SIFModelo.Catalogo.CatalogoDataSetTableAdapters.COMPRADORTableAdapter();
           ta.Connection.ConnectionString = Helpers.ConnectionString.Connection();
           ta.Fill(dataSet.COMPRADOR);
           return dataSet.COMPRADOR;
       }


       public static SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow CargaCompradoresPorId(SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow modelo)
       {
           SIFModelo.Catalogo.CatalogoDataSet dataSet = new SIFModelo.Catalogo.CatalogoDataSet();
           SIFModelo.Catalogo.CatalogoDataSetTableAdapters.COMPRADORTableAdapter ta = new SIFModelo.Catalogo.CatalogoDataSetTableAdapters.COMPRADORTableAdapter();
           ta.Connection.ConnectionString = Helpers.ConnectionString.Connection();
           ta.FillByUSUARIO_ID(dataSet.COMPRADOR, modelo.USUARIO_ID);
           if(dataSet.COMPRADOR.Count > 0)
           return dataSet.COMPRADOR.FirstOrDefault();

           return null;
       }

       public static bool ActualizaCompradores(SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow modelo)
       {
           string sentencia = "SP_UPD_CAT_COMPRADORES";
           using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
           {
               using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
               {
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cmd.BindByName = true;

                   //PARAMETROS
                   cmd.Parameters.Add("eusuario_id", modelo.USUARIO_ID);
                   cmd.Parameters.Add("elista_sucursal_id", modelo.LISTA_SUCURSAL_ID);
                   cmd.Parameters.Add("etipo", modelo.TIPO);
                   cmd.Parameters.Add("elista_proveedor_id", modelo.LISTA_PROVEEDOR_ID);
                   cmd.Parameters.Add("efecha_alta", modelo.FECHA_ALTA);
                   cmd.Parameters.Add("eactivo", modelo.ACTIVO);
                   //PARAMETROS DE SALIDA
                   OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Decimal);
                   outparam.Direction = System.Data.ParameterDirection.Output;

                   //AGREGAR LOS PARAMETROS
                   cmd.Parameters.Add(outparam);

                   try
                   {
                       cmd.Connection.Open();
                       cmd.ExecuteScalar();

                       if (outparam.Value.ToString().IsIntegerPositive())
                       {
                           if (int.Parse(outparam.Value.ToString()) > 0)
                           {
                               return true;
                           }

                       }
                       else
                       {
                           return false;
                       }
                   }
                   catch (Exception)
                   {

                       return false;
                   }
                   finally
                   {
                       cmd.Connection.Close();
                        
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

               }
           }

           return true;
       }

       public static bool InsertaCompradores(SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow modelo)
       {
           string sentencia = "SP_INS_CAT_COMPRADORES";
           using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
           {
               using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
               {
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   cmd.BindByName = true;

                   //PARAMETROS
                   cmd.Parameters.Add("usuario_id", modelo.USUARIO_ID);
                   cmd.Parameters.Add("lista_sucursal_id", modelo.LISTA_SUCURSAL_ID);
                   cmd.Parameters.Add("tipo", modelo.TIPO);
                   cmd.Parameters.Add("lista_proveedor_id", modelo.LISTA_PROVEEDOR_ID);
                   cmd.Parameters.Add("fecha_alta", modelo.FECHA_ALTA);
                   
                   //PARAMETROS DE SALIDA
                   OracleParameter outparam = new OracleParameter("outparam", OracleDbType.RefCursor);
                   outparam.Direction = System.Data.ParameterDirection.Output;

                   //AGREGAR LOS PARAMETROS
                   cmd.Parameters.Add(outparam);

                   try
                   {
                       cmd.Connection.Open();
                       cmd.ExecuteScalar();

                       if (outparam.Value.ToString().IsIntegerPositive())
                       {
                           if (int.Parse(outparam.Value.ToString()) > 0)
                           {
                               return true;
                           }

                       }
                       else
                       {
                           return false;
                       }
                   }
                   catch (Exception)
                   {

                       return false;
                   }
                   finally
                   {
                       cmd.Connection.Close();
                        
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

               }
           }

           return true;
       }

       /*************Itc Cambio Para La Asignacion del proveedor*/
       public static List<SIFModelo.AsignacionCompradores> BuscaCompradoresA(string cmp)
       {
           List<SIFModelo.AsignacionCompradores> rows = new List<SIFModelo.AsignacionCompradores>();
           string sentencia = "SELECT DISTINCT " + cmp + " FROM CS_COMPRADORES_A  ORDER BY " + cmp + " DESC";
           /*OracleParameter outparam = new OracleParameter("msg", OracleDbType.RefCursor);
           outparam.Direction = System.Data.ParameterDirection.Output;           */

           using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
           {
               using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
               {
                   cmd.Connection.Open();
                   cmd.ExecuteNonQuery();
                   OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                   SIFModelo.AsignacionCompradores registro = new SIFModelo.AsignacionCompradores();
                   if (oreader.HasRows)
                   {

                       registro.comprador_c = ("USUARIO");
                       rows.Add(registro);
                       while (oreader.Read())
                       {
                           registro = new SIFModelo.AsignacionCompradores();
                           registro.comprador_c = oreader[cmp].ToString();
                           rows.Add(registro);
                       }
                   }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }
           }
           return rows;
       }
       public static List<SIFModelo.AsignacionCompradores> BuscaCompradoresA(string cmp,string u, string ui,string txt)
       {
           string sentencia;
           List<SIFModelo.AsignacionCompradores> rows = new List<SIFModelo.AsignacionCompradores>();
           
               if (ui.Equals("="))
               {
                   sentencia = "SELECT DISTINCT " + cmp + " FROM CS_COMPRADORES_A where  usuario_id" + ui + "'" + u + "'";
               }
               else
               {

                   sentencia = "SELECT DISTINCT " + cmp + " FROM CS_COMPRADORES_A WHERE proveedor_id NOT IN" +
                   "(SELECT DISTINCT proveedor_id FROM cat_compradores_v2 WHERE USUARIO_ID=" + u + ")";
                   if (txt != string.Empty)
                   {
                       sentencia += " AND  NOMBRE_PROV_C LIKE '%" + txt + "%'";
                   }

               }
         
           
           using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
           {
               using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
               {
                   cmd.Connection.Open();
                   cmd.ExecuteNonQuery();
                   OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                   SIFModelo.AsignacionCompradores registro = new SIFModelo.AsignacionCompradores();
                   if (oreader.HasRows)
                   {


                       rows.Add(registro);
                       while (oreader.Read())
                       {
                           registro = new SIFModelo.AsignacionCompradores();
                           registro.nombreProvC = oreader[cmp].ToString();
                           rows.Add(registro);
                       }
                   }
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }
           }
           return rows;
       }

       public static Boolean bucaExistente(string usr,string prov){
           Boolean existe=false; 
           string campos = " COUNT (USUARIO_ID) USUARIO_ID ";
           string sentencia = "SELECT  " + campos
                               + " from  CS_COMPRADORES_A  WHERE usuario_id='"+usr+"'  and proveedor_id ='"+prov+"'";
           using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
           {
               using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
               {
                  
                   

                   try
                   {
                       
                       cmd.Connection.Open();
                       
                       cmd.ExecuteNonQuery();
                       OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                       if (oreader.HasRows)
                       {
                           while (oreader.Read())
                           {
                               

                               if (int.Parse(oreader["USUARIO_ID"].ToString()) > 0) {
                                   existe = true;
                               }

                               
                           }
                       }
                    

                    }
                   catch (Exception)
                   {
                       existe = false;
                   }
                   finally
                   {
                       cmd.Connection.Close();
                        
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
               }
           }
           return existe;
       
       }


       /*****----------------------------------------------------*****/

       public static Boolean AsignacionComprador(string cmp, string u, string tm)
       {
           if (tm.Equals("A"))
           {
               string sentenciaA = "sp_pivot_compradores";
               using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
               {
                   using (OracleCommand cmd = new OracleCommand(sentenciaA, cnx))
                   {
                       cmd.CommandType = System.Data.CommandType.StoredProcedure;
                       cmd.BindByName = true;
                       //PARAMETROS DE SALIDA
                       OracleParameter outparam = new OracleParameter("msg", OracleDbType.Int32);
                       outparam.Direction = System.Data.ParameterDirection.Output;

                       //AGREGAR LOS PARAMETROS
                       cmd.Parameters.Add(outparam);

                       try
                       {
                           cmd.Connection.Open();
                           cmd.ExecuteScalar();

                           if (outparam.Value.ToString().IsIntegerPositive())
                           {
                               if (int.Parse(outparam.Value.ToString()) > 0)
                               {
                                   return true;
                               }
                           }
                           else
                           {
                               return false;
                           }
                       }
                       catch (Exception)
                       {
                           return false;
                       }
                       finally
                       {
                           cmd.Connection.Close();
                            
                            cmd.Connection.Dispose();
                           //OracleConnection.ClearPool(cnx);
                        }
                   }
               }
               return true;

           }
           else
           {








               Boolean r=false; 
               string sentencia = "SP_UPD_INS_COMPRADORP";
               using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
               {
                   using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                   {
                       cmd.CommandType = System.Data.CommandType.StoredProcedure;
                       cmd.BindByName = true;

                       //PARAMETROS
                       cmd.Parameters.Add("VCODIGO_P", cmp);
                       cmd.Parameters.Add("VUSAURIO_ID", u);
                       cmd.Parameters.Add("VTIPO_M", tm);

                       //PARAMETROS DE SALIDA
                       OracleParameter outparam = new OracleParameter("msg", OracleDbType.Int64);
                       outparam.Direction = System.Data.ParameterDirection.Output;

                       //AGREGAR LOS PARAMETROS
                       cmd.Parameters.Add(outparam);

                       try
                       {
                           cmd.Connection.Open();
                           cmd.ExecuteScalar();

                           if (outparam.Value.ToString().IsIntegerPositive())
                           {
                               if (int.Parse(outparam.Value.ToString()) > 0)
                               {
                                   r= true;
                               }
                           }
                           else
                           {
                               r= false;
                           }
                       }
                       catch (Exception)
                       {
                           r= false;
                       }
                       finally
                       {
                           cmd.Connection.Close();
                            
                            cmd.Connection.Dispose();
                           //OracleConnection.ClearPool(cnx);
                        }
                   }
               }





               string sentenciaA = "sp_pivot_compradores";
               using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
               {
                   using (OracleCommand cmd = new OracleCommand(sentenciaA, cnx))
                   {
                       cmd.CommandType = System.Data.CommandType.StoredProcedure;
                       cmd.BindByName = true;
                       //PARAMETROS DE SALIDA
                       OracleParameter outparam = new OracleParameter("msg", OracleDbType.Int16);
                       outparam.Direction = System.Data.ParameterDirection.Output;

                       //AGREGAR LOS PARAMETROS
                       cmd.Parameters.Add(outparam);

                       try
                       {
                           cmd.Connection.Open();
                           cmd.ExecuteScalar();

                           if (outparam.Value.ToString().IsIntegerPositive())
                           {
                               if (int.Parse(outparam.Value.ToString()) > 0)
                               {
                                   r= true;
                               }
                           }
                           else
                           {
                               r= false;
                           }
                       }
                       catch (Exception)
                       {
                           r= false;
                       }
                       finally
                       {
                           cmd.Connection.Close();
                            
                            cmd.Connection.Dispose();
                           //OracleConnection.ClearPool(cnx);
                        }
                   }
               }
               return r;
           }
       }
       public static DataTable Carga_grid_Provitc(string activo)
       {

           string campos = " l.clientes_id ,  l.nombre,  NVL(c.nombre, 'POR ASIGNAR') comprador ";
           string sentencia = "SELECT  " + campos 
                               + " from  cat_clientes l,  (SELECT proveedor_id, u.NOMBRE  FROM cat_compradores_v2 cc , cat_usuarios u  WHERE cc.usuario_id=u.USUARIOS_ID  ) c" +
                               "  WHERE l.CLIENTES_ID=c.PROVEEDOR_ID(+) AND           activo = '" + activo + "'";
           DataTable tableClientes = new DataTable();
           using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
           {
               using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
               {
                   cmd.CommandType = System.Data.CommandType.Text;
                   cmd.BindByName = true;

                   try
                   {
                       cmd.Connection.Open();
                       OracleDataReader dr = cmd.ExecuteReader();

                       if (dr.HasRows)
                       {

                           tableClientes.Columns.Add("CLIENTE_ID", typeof(Int32));
                           tableClientes.Columns.Add("NOMBRE", typeof(string));
                           tableClientes.Columns.Add("COMPRADOR", typeof(string));
                           DataRow dataR;
                           object[] rvalues = new object[dr.FieldCount];
                           dataR = tableClientes.NewRow();
                           while (dr.Read())
                           {
                               dr.GetValues(rvalues);
                               tableClientes.Rows.Add(rvalues);
                           }



                           return tableClientes;
                       }
                   }
                   catch (Exception x)
                   {
                       String variavle = "error" + x;
                       throw;


                   }
                   finally
                   {

                       cmd.Connection.Close();
                        
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

               }
           }
           return tableClientes;

       }


       /// <summary>
       /// Carga compradores
       /// </summary>
       /// <param name="activo"></param>
       /// <returns></returns>
       public static DataTable Carga_grid_Compitc(string comprador)
       {

           string campos = " USUARIO_ID,comprador,PROVEEDOR_ID,NOMBRE_PROV ";
           string sentencia = "SELECT  " + campos
                               + " from  CS_COMPRADORES_A "; //WHERE usuario_id='" + comprador + "'";
           DataTable tableClientes = new DataTable();
           using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
           {
               using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
               {
                   cmd.CommandType = System.Data.CommandType.Text;
                   cmd.BindByName = true;

                   try
                   {
                       cmd.Connection.Open();
                       OracleDataReader dr = cmd.ExecuteReader();

                       if (dr.HasRows)
                       {

                           
                           tableClientes.Columns.Add("USUARIO_ID", typeof(string));                           
                           tableClientes.Columns.Add("COMPRADOR", typeof(string));
                           tableClientes.Columns.Add("PROVEEDOR_ID", typeof(string));
                           tableClientes.Columns.Add("NOMBRE_PROV", typeof(string));
                           tableClientes.Columns.Add(new DataColumn("Asociar", typeof(bool)));

                           DataRow dataR;
                           object[] rvalues = new object[dr.FieldCount];
                           dataR = tableClientes.NewRow();
                           while (dr.Read())
                           {
                               dr.GetValues(rvalues);
                               tableClientes.Rows.Add(rvalues);
                           }



                           return tableClientes;
                       }
                   }
                   catch (Exception x)
                   {
                       String variavle = "error" + x;
                       throw;


                   }
                   finally
                   {

                       cmd.Connection.Close();
                        
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }

               }
           }
           return tableClientes;

       }

       public static Boolean cambiaEstadoProv(string cliente_, string estado_){
           string sentenciaA = "sp_cambia_estado_prov";
        Boolean r=false;
               using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
               {
                   using (OracleCommand cmd = new OracleCommand(sentenciaA, cnx))
                   {
                       //AGREGAR LOS PARAMETROS
                       cmd.CommandType = System.Data.CommandType.StoredProcedure;
                       cmd.Parameters.Add("clienteid", cliente_);
                       cmd.Parameters.Add("estado", estado_);
                       cmd.BindByName = true;
                       //PARAMETROS DE SALIDA
                       OracleParameter outparam = new OracleParameter("msg", OracleDbType.Int16);
                       outparam.Direction = System.Data.ParameterDirection.Output;

                       
                       cmd.Parameters.Add(outparam);

                       try
                       {
                           cmd.Connection.Open();
                           cmd.ExecuteScalar();

                           if (outparam.Value.ToString().IsIntegerPositive())
                           {
                               if (int.Parse(outparam.Value.ToString()) > 0)
                               {
                                   r= true;
                               }
                           }
                           else
                           {
                               r= false;
                           }
                       }
                       catch (Exception)
                       {
                           r= false;
                       }
                       finally
                       {
                           cmd.Connection.Close();
                        
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                   }
               }
               return r;
           }

       
       

    }
}
