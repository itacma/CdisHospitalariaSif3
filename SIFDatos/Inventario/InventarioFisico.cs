using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace SIFDatos.Inventario
{
    public class InventarioFisico
    {


        public static DataTable GetPeriodos()
        {
            DataTable taPeridos = new DataTable("Periodos");
            taPeridos.Columns.Add("periodo");
            string sentencia = "PKG_INVENTARIOS.sp_Get_Periodos_InvFis";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    OracleParameter outparam = new OracleParameter("Per", OracleDbType.RefCursor);
                    outparam.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outparam);


                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            DataRow row = taPeridos.NewRow();
                            string periodo = "";
                            periodo = oreader["periodo"].ToString();
                            row["periodo"] = periodo;
                            taPeridos.Rows.Add(row);
                        }
                    }

                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }
            }

            return taPeridos;
        }

        public static DataTable GetFila(int periodo)
        {
            DataTable taFila = new DataTable("Anaquel");
            taFila.Columns.Add("anaquel");
            taFila.Columns.Add("fila");
            string sentencia = "PKG_INVENTARIOS.sp_Get_FilAna_InvFis";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    OracleParameter per = new OracleParameter("Per", OracleDbType.Int32);
                    per.Value = periodo;
                    cmd.Parameters.Add(per);

                    OracleParameter Fila = new OracleParameter("Fila", OracleDbType.RefCursor);
                    Fila.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(Fila);

                    OracleParameter Anaquel = new OracleParameter("Anaquel", OracleDbType.RefCursor);
                    Anaquel.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(Anaquel);


                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            DataRow row = taFila.NewRow();
                            string fila = "";
                            fila = oreader["fila"].ToString();
                            row["fila"] = fila;
                            taFila.Rows.Add(row);
                        }
                    }

                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }
            }

            return taFila;
        }

        public static DataTable GetAnaquel(int periodo)
        {
            DataTable taFila = new DataTable("Anaquel");
            taFila.Columns.Add("anaquel");
            taFila.Columns.Add("fila");
            string sentencia = "PKG_INVENTARIOS.sp_Get_FilAna_InvFis";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    OracleParameter per = new OracleParameter("Per", OracleDbType.Int32);
                    per.Value = periodo;
                    cmd.Parameters.Add(per);

                    OracleParameter Fila = new OracleParameter("Fila", OracleDbType.RefCursor);
                    Fila.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(Fila);

                    OracleParameter Anaquel = new OracleParameter("Anaquel", OracleDbType.RefCursor);
                    Anaquel.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(Anaquel);


                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            DataRow row = taFila.NewRow();
                            string fila = "";
                            fila = oreader["fila"].ToString();
                            row["fila"] = fila;
                            taFila.Rows.Add(row);
                        }
                    }

                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }
            }

            return taFila;
        }



        public static DataTable sp_Get_Articulos_InvFis(int periodo, int fila, int anaquel)
        {
            DataTable taPeridos = new DataTable("Articulos");
            taPeridos.Columns.Add("articulo_id");
            taPeridos.Columns.Add("Descripcion");
            taPeridos.Columns.Add("Nombre2");
            taPeridos.Columns.Add("Fila");
            taPeridos.Columns.Add("Anaquel");
            taPeridos.Columns.Add("Nivel");
            taPeridos.Columns.Add("Existencia");
            taPeridos.Columns.Add("Conteo1");
            taPeridos.Columns.Add("Dif1");
            taPeridos.Columns.Add("Conteo2");
            taPeridos.Columns.Add("Dif2");
            taPeridos.Columns.Add("Costo_Prom");
            taPeridos.Columns.Add("Modificada");

            string sentencia = "PKG_INVENTARIOS.sp_Get_Articulos_InvFis";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    OracleParameter per = new OracleParameter("Per", OracleDbType.Int32);
                    per.Value = periodo;
                    cmd.Parameters.Add(per);

                    OracleParameter Fila = new OracleParameter("pFila", OracleDbType.Int32);
                    Fila.Value = fila;
                    cmd.Parameters.Add(Fila);

                    OracleParameter Anaquel = new OracleParameter("pAnaquel", OracleDbType.Int32);
                    Anaquel.Value = anaquel;
                    cmd.Parameters.Add(Anaquel);

                    OracleParameter Articulos = new OracleParameter("Articulos", OracleDbType.RefCursor);
                    Articulos.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(Articulos);

                    //
                    cmd.Connection.Open();
                    cmd.ExecuteReader();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            DataRow row = taPeridos.NewRow();
                            row["articulo_id"] = oreader["articulo_id"];
                            row["Descripcion"] = oreader["Descripcion"];
                            row["Nombre2"] = oreader["Nombre2"];
                            row["Fila"] = oreader["Fila"];
                            row["Anaquel"] = oreader["Anaquel"];
                            row["Nivel"] = oreader["Nivel"];
                            row["Existencia"] = oreader["Existencia"];
                            row["Conteo1"] = oreader["Conteo1"];

                            decimal dif = System.Convert.ToDecimal(oreader["Dif1"]);
                            dif = dif * -1;
                            row["Dif1"] = dif;

                            row["Conteo2"] = oreader["Conteo2"];
                            row["Dif2"] = oreader["Dif2"];

                            //#if DEBUG
                            //                            row["Conteo1"] = row["Existencia"];
                            //#endif

                            row["Costo_Prom"] = oreader["Costo_Prom"];
                            row["Modificada"] = 0;
                            taPeridos.Rows.Add(row);
                        }
                    }

                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }
            }

            return taPeridos;
        }


        public static DataTable sp_Get_Articulos_InvFis(int periodo, int fila, string filas, int j)//Obtener solo diferencias
        {
            DataTable taPeridos = new DataTable("Articulos");
            taPeridos.Columns.Add("articulo_id");
            taPeridos.Columns.Add("Descripcion");
            taPeridos.Columns.Add("Nombre2");
            taPeridos.Columns.Add("Fila");
            taPeridos.Columns.Add("Anaquel");
            taPeridos.Columns.Add("Nivel");
            taPeridos.Columns.Add("Existencia");
            taPeridos.Columns.Add("Conteo1");
            taPeridos.Columns.Add("Dif1");
            taPeridos.Columns.Add("Conteo2");
            taPeridos.Columns.Add("Dif2");
            taPeridos.Columns.Add("Costo_Prom");
            taPeridos.Columns.Add("Modificada");

            string sentencia = "PKG_INVENTARIOS.sp_Get_Articulos_InvFisDif";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    OracleParameter per = new OracleParameter("Per", OracleDbType.Int32);
                    per.Value = periodo;
                    cmd.Parameters.Add(per);

                    OracleParameter Fila = new OracleParameter("PFila", OracleDbType.Int32);
                    Fila.Value = fila;
                    cmd.Parameters.Add(Fila);

                    OracleParameter pe_filas = new OracleParameter("pe_filas", OracleDbType.Varchar2);
                    pe_filas.Value = filas;
                    cmd.Parameters.Add(pe_filas);

                    OracleParameter pe_f = new OracleParameter("pe_f", OracleDbType.Int32);
                    pe_f.Value = j;
                    cmd.Parameters.Add(pe_f);

                    OracleParameter Articulos = new OracleParameter("Articulos", OracleDbType.RefCursor);
                    Articulos.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(Articulos);

                    //
                    cmd.Connection.Open();
                    cmd.ExecuteReader();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            DataRow row = taPeridos.NewRow();
                            row["articulo_id"] = oreader["articulo_id"];
                            row["Descripcion"] = oreader["Descripcion"];
                            row["Nombre2"] = oreader["Nombre2"];
                            row["Fila"] = oreader["Fila"];
                            row["Anaquel"] = oreader["Anaquel"];
                            row["Nivel"] = oreader["Nivel"];
                            row["Existencia"] = oreader["Existencia"];
                            row["Conteo1"] = oreader["Conteo1"];

                            decimal dif = System.Convert.ToDecimal(oreader["Dif1"]);
                            dif = dif * -1;
                            row["Dif1"] = dif;

                            row["Conteo2"] = oreader["Conteo2"];
                            row["Dif2"] = oreader["Dif2"];

                            //#if DEBUG
                            //                            row["Conteo1"] = row["Existencia"];
                            //#endif

                            row["Costo_Prom"] = oreader["Costo_Prom"];
                            row["Modificada"] = 0;
                            taPeridos.Rows.Add(row);
                        }
                    }

                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }
            }

            return taPeridos;
        }


        public static bool CreaInvFisico()
        {
            //taArticulos.Columns.Add("anaquel");
            string sentencia = "PKG_INVENTARIOS.sp_Set_Crea_InvFis";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    OracleParameter OutParam = new OracleParameter("OutParam", OracleDbType.Decimal);
                    OutParam.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(OutParam);

                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch
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


        public static bool Actualiza(DataTable dtArticulos, int periodo, SIFModelo.Sucursal sucursal)
        {
            string sentencia = "PKG_INVENTARIOS.sp_upd_inv_fisico";


            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("Per", periodo);
                    cmd.Parameters.Add("Sucursal", sucursal.SucursalesID);

                    List<string> ArtId = new List<string>();
                    List<decimal> Conteo1 = new List<decimal>();
                    List<decimal> Conteo2 = new List<decimal>();
                    List<decimal> CostoProm = new List<decimal>();

                    foreach (DataRow row in dtArticulos.Rows)
                    {
                        ArtId.Add(row["articulo_id"].ToString());
                        Conteo1.Add(System.Convert.ToDecimal(row["Conteo1"]));
                        Conteo2.Add(System.Convert.ToDecimal(row["Conteo2"]));
                        //Conteo2.Add(System.Convert.ToDecimal(row["Conteo2"]));
                        CostoProm.Add(System.Convert.ToDecimal(row["Costo_Prom"]));
                    }

                    Oracle.DataAccess.Client.OracleParameter pArtId = new OracleParameter("ArtId", OracleDbType.Varchar2);
                    pArtId.Direction = ParameterDirection.Input;
                    pArtId.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pArtId.Value = ArtId.ToArray();
                    cmd.Parameters.Add(pArtId);

                    Oracle.DataAccess.Client.OracleParameter pConteo1 = new OracleParameter("Conteo1", OracleDbType.Decimal);
                    pConteo1.Direction = ParameterDirection.Input;
                    pConteo1.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pConteo1.Value = Conteo1.ToArray();
                    cmd.Parameters.Add(pConteo1);

                    Oracle.DataAccess.Client.OracleParameter pConteo2 = new OracleParameter("Conteo2", OracleDbType.Decimal);
                    pConteo2.Direction = ParameterDirection.Input;
                    pConteo2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pConteo2.Value = Conteo2.ToArray();
                    cmd.Parameters.Add(pConteo2);


                    Oracle.DataAccess.Client.OracleParameter pCostoProm = new OracleParameter("CostoProm", OracleDbType.Decimal);
                    pCostoProm.Direction = ParameterDirection.Input;
                    pCostoProm.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pCostoProm.Value = CostoProm.ToArray();
                    cmd.Parameters.Add(pCostoProm);


                    OracleParameter OutParam = new OracleParameter("OutParam", OracleDbType.Decimal);
                    OutParam.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(OutParam);

                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        return false;
                    }
                    finally
                    {

                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                    return true;
                }
            }
        }

        public static string AjusteInventarioFisico(int periodo, SIFModelo.Sucursal sucursal)
        {
            string sentencia = "PKG_INVENTARIOS.sp_ajustes_inv_fisico";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("Per", OracleDbType.Decimal, periodo, ParameterDirection.Input);
                    cmd.Parameters.Add("Sucursal", OracleDbType.Int16, sucursal.SucursalesID, ParameterDirection.Input);

                    OracleParameter OutParam = new OracleParameter("OutParam", OracleDbType.Decimal);
                    OutParam.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(OutParam);

                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        return "Error al generar los archivos";
                    }
                    finally
                    {

                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                    return "Se generó el ajuste con los folios: " + OutParam.Value.ToString();
                }
            }
        }

        public static bool CreaInvFisico(DataRow row, string perido, int sucursal)
        {
            string sentencia = "PKG_INVENTARIOS.sp_Ins_Inv_Fisico";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("pPeriodo", OracleDbType.Decimal, perido, ParameterDirection.Input);
                    cmd.Parameters.Add("pSucursal", OracleDbType.Int16, sucursal, ParameterDirection.Input);
                    cmd.Parameters.Add("pArtId", OracleDbType.Varchar2, row["articulo_id"], ParameterDirection.Input);
                    cmd.Parameters.Add("pNom1", OracleDbType.Varchar2, row["Descripcion"], ParameterDirection.Input);
                    cmd.Parameters.Add("pNom2", OracleDbType.Varchar2, row["Nombre2"], ParameterDirection.Input);
                    cmd.Parameters.Add("pFila", OracleDbType.Decimal, row["Fila"], ParameterDirection.Input);
                    cmd.Parameters.Add("pAnaquel", OracleDbType.Decimal, row["Anaquel"], ParameterDirection.Input);
                    cmd.Parameters.Add("pNivel", OracleDbType.Varchar2, row["Nivel"], ParameterDirection.Input);
                    cmd.Parameters.Add("pCant", OracleDbType.Decimal, row["Conteo1"], ParameterDirection.Input);

                    OracleParameter OutParam = new OracleParameter("OutParam", OracleDbType.Decimal);
                    OutParam.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(OutParam);

                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        return false;
                    }
                    finally
                    {

                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                    return true;
                }
            }
        }

        public static SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow sp_Get_Articulos_InvFis(string periodo, string fila, string anaquel, SIFModelo.Articulo articulo)
        {
            throw new NotImplementedException();
        }
    }
}
