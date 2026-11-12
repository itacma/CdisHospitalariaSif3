using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data;
using DevComponents.DotNetBar;

namespace SIFDatos.Subrogacion
{
    public class Subrogacion
    {






        public static void InsVtaLicitacion(int CltId, double Porc, string NomArchivo, string FactInicio,
                                int[] Sec, String[] ArtId, String[] Concepto,
                                String[] UMedida, String[] Presenta, int[] Cant, double[] PrecioClt,
                                double[] ImpClt, String[] Prov, String[] Marca,
                                double[] PorcFarm, double[] PrecioFarm, double[] ImpFarm, Nullable<int>[] ProvFarm)
        {
            using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_SUBROGACION.sp_ins_licitacion";
                cmd.BindByName = true;

                cmd.Parameters.Add("CltId", OracleDbType.Int16, CltId, ParameterDirection.Input);
                cmd.Parameters.Add("Porc", OracleDbType.Double, Porc, ParameterDirection.Input);
                cmd.Parameters.Add("NomArchivo", OracleDbType.Varchar2, NomArchivo, ParameterDirection.Input);
                cmd.Parameters.Add("FactInicio", OracleDbType.Varchar2, FactInicio, ParameterDirection.Input);

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

                // IN Array Unidad de Medida
                OracleParameter InUMedida = cmd.Parameters.Add("UMedida", OracleDbType.Varchar2);
                InUMedida.Direction = ParameterDirection.Input;
                InUMedida.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InUMedida.Value = UMedida;

                // IN Array Presentacion
                OracleParameter InPresenta = cmd.Parameters.Add("Presenta", OracleDbType.Varchar2);
                InPresenta.Direction = ParameterDirection.Input;
                InPresenta.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPresenta.Value = Presenta;

                // IN Array Cantidad
                OracleParameter InCant = cmd.Parameters.Add("Cant", OracleDbType.Decimal);
                InCant.Direction = ParameterDirection.Input;
                InCant.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCant.Value = Cant;

                // IN Array Precio Cliente
                OracleParameter InPreClt = cmd.Parameters.Add("PrecioClt", OracleDbType.Double);
                InPreClt.Direction = ParameterDirection.Input;
                InPreClt.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPreClt.Value = PrecioClt;

                // IN Array Importe Cliente
                OracleParameter InImpClt = cmd.Parameters.Add("ImpClt", OracleDbType.Double);
                InImpClt.Direction = ParameterDirection.Input;
                InImpClt.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InImpClt.Value = ImpClt;

                // IN Array Proveedor
                OracleParameter InProv = cmd.Parameters.Add("Prov", OracleDbType.Varchar2);
                InProv.Direction = ParameterDirection.Input;
                InProv.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InProv.Value = Prov;

                // IN Array Marca
                OracleParameter InMarca = cmd.Parameters.Add("Marca", OracleDbType.Varchar2);
                InMarca.Direction = ParameterDirection.Input;
                InMarca.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InMarca.Value = Marca;

                // IN Array Porcentaje Farmacia
                OracleParameter InPorcFarm = cmd.Parameters.Add("PorcFarm", OracleDbType.Double);
                InPorcFarm.Direction = ParameterDirection.Input;
                InPorcFarm.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPorcFarm.Value = PorcFarm;

                // IN Array Precio Farmacia
                OracleParameter InPreFarm = cmd.Parameters.Add("PrecioFarm", OracleDbType.Double);
                InPreFarm.Direction = ParameterDirection.Input;
                InPreFarm.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPreFarm.Value = PrecioFarm;

                // IN Array Importe Farmacia
                OracleParameter InImpFarm = cmd.Parameters.Add("ImpFarm", OracleDbType.Double);
                InImpFarm.Direction = ParameterDirection.Input;
                InImpFarm.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InImpFarm.Value = ImpFarm;

                // Input Array Supplier
                OracleParameter InSup = cmd.Parameters.Add("ProvFarm", OracleDbType.Decimal);
                InSup.Direction = ParameterDirection.Input;
                InSup.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InSup.Value = ProvFarm;

                // OUT parameter
                OracleParameter pPedido =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pPedido.Value.ToString()))
                {
                   MessageBox.Show("Se creo el pedido venta licitación con el Folio " + pPedido.Value.ToString(), "Licitacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al crear el pedido venta licitación: " + Environment.NewLine + ex.Message, "Licitacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static void UpdVtaLicitacion(string NoFolio, double Porc, string FactInicio,
                                int[] Sec, String[] ArtId, String[] Concepto,
                                String[] UMedida, String[] Presenta, int[] Cant, double[] PrecioClt,
                                double[] ImpClt, String[] Prov, String[] Marca,
                                double[] PorcFarm, double[] PrecioFarm, double[] ImpFarm, Nullable<int>[] ProvFarm)
        {
           using (OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection()))
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_SUBROGACION.sp_upd_licitacion";
                cmd.BindByName = true;

                cmd.Parameters.Add("NoFolio", OracleDbType.Varchar2, NoFolio, ParameterDirection.Input);
                cmd.Parameters.Add("Porc", OracleDbType.Double, Porc, ParameterDirection.Input);
                cmd.Parameters.Add("FactInicio", OracleDbType.Varchar2, FactInicio, ParameterDirection.Input);

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

                // IN Array Unidad de Medida
                OracleParameter InUMedida = cmd.Parameters.Add("UMedida", OracleDbType.Varchar2);
                InUMedida.Direction = ParameterDirection.Input;
                InUMedida.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InUMedida.Value = UMedida;

                // IN Array Presentacion
                OracleParameter InPresenta = cmd.Parameters.Add("Presenta", OracleDbType.Varchar2);
                InPresenta.Direction = ParameterDirection.Input;
                InPresenta.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPresenta.Value = Presenta;

                // IN Array Cantidad
                OracleParameter InCant = cmd.Parameters.Add("Cant", OracleDbType.Decimal);
                InCant.Direction = ParameterDirection.Input;
                InCant.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InCant.Value = Cant;

                // IN Array Precio Cliente
                OracleParameter InPreClt = cmd.Parameters.Add("PrecioClt", OracleDbType.Double);
                InPreClt.Direction = ParameterDirection.Input;
                InPreClt.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPreClt.Value = PrecioClt;

                // IN Array Importe Cliente
                OracleParameter InImpClt = cmd.Parameters.Add("ImpClt", OracleDbType.Double);
                InImpClt.Direction = ParameterDirection.Input;
                InImpClt.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InImpClt.Value = ImpClt;

                // IN Array Proveedor
                OracleParameter InProv = cmd.Parameters.Add("Prov", OracleDbType.Varchar2);
                InProv.Direction = ParameterDirection.Input;
                InProv.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InProv.Value = Prov;

                // IN Array Marca
                OracleParameter InMarca = cmd.Parameters.Add("Marca", OracleDbType.Varchar2);
                InMarca.Direction = ParameterDirection.Input;
                InMarca.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InMarca.Value = Marca;

                // IN Array Porcentaje Farmacia
                OracleParameter InPorcFarm = cmd.Parameters.Add("PorcFarm", OracleDbType.Double);
                InPorcFarm.Direction = ParameterDirection.Input;
                InPorcFarm.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPorcFarm.Value = PorcFarm;

                // IN Array Precio Farmacia
                OracleParameter InPreFarm = cmd.Parameters.Add("PrecioFarm", OracleDbType.Double);
                InPreFarm.Direction = ParameterDirection.Input;
                InPreFarm.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InPreFarm.Value = PrecioFarm;

                // IN Array Importe Farmacia
                OracleParameter InImpFarm = cmd.Parameters.Add("ImpFarm", OracleDbType.Double);
                InImpFarm.Direction = ParameterDirection.Input;
                InImpFarm.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InImpFarm.Value = ImpFarm;

                // Input Array Supplier
                OracleParameter InSup = cmd.Parameters.Add("ProvFarm", OracleDbType.Decimal);
                InSup.Direction = ParameterDirection.Input;
                InSup.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                InSup.Value = ProvFarm;

                // OUT parameter
                OracleParameter pPedido =
                    cmd.Parameters.Add("OutParam", OracleDbType.Decimal, ParameterDirection.Output);

                // Execute the command
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(pPedido.Value.ToString()))
                {
                    if (Convert.ToDecimal(pPedido.Value.ToString()) > 0)
                       MessageBox.Show("Se actualizo el pedido venta licitación con el Folio " + pPedido.Value.ToString(), "Licitacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al crear el pedido venta licitación: " + Environment.NewLine + ex.Message, "Licitacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
