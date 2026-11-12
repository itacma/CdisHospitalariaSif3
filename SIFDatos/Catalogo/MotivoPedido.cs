using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace SIFDatos
{
    public class MotivoPedido
    {

        public static List<SIFModelo.MotivoPedido> Busca()
        {
            string sentencia = "SELECT ID,NOMBRE,MAX_SKUS,CANT_PED_MAX_DIA,PARAMETRO_EOQ,VALOR_EOQ,PARAMETRO_EXIS,VALOR_EXIS,FECHA_ALTA, FECHA_BAJA,ACTIVO FROM CAT_TIPO_PEDIDO";
            List<SIFModelo.MotivoPedido> MotivoPedidoList = new List<SIFModelo.MotivoPedido>();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //PARAMETROS DE SALIDA
                        OracleParameter outparam = new OracleParameter("REFCUR", OracleDbType.RefCursor);
                        outparam.Direction = System.Data.ParameterDirection.Output;

                        //AGREGAR LOS PARAMETROS
                        cmd.Parameters.Add(outparam);

                        //

                        cmd.Connection.Open();

                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.MotivoPedido motivoPedidoModel = new SIFModelo.MotivoPedido();

                                motivoPedidoModel.ID = int.Parse(oreader["ID"].ToString());
                                motivoPedidoModel.NOMBRE = oreader["NOMBRE"].ToString();
                                motivoPedidoModel.MAX_SKUS = int.Parse(oreader["MAX_SKUS"].ToString());
                                motivoPedidoModel.CANTIDAD_PEDIDO_MAX_DIA = int.Parse(oreader["CANT_PED_MAX_DIA"].ToString());
                                motivoPedidoModel.PARAMETRO_EOQ = oreader["PARAMETRO_EOQ"].ToString();
                                motivoPedidoModel.VALOR_EOQ = int.Parse(oreader["VALOR_EOQ"].ToString());
                                motivoPedidoModel.PARAMETRO_EXIS = oreader["PARAMETRO_EXIS"].ToString();
                                motivoPedidoModel.VALOR_EXIS = int.Parse(oreader["VALOR_EXIS"].ToString());
                                motivoPedidoModel.FECHA_ALTA = DateTime.Parse((oreader["FECHA_ALTA"].ToString().Equals("") ? "01/01/01" : oreader["FECHA_ALTA"].ToString()));
                                motivoPedidoModel.FECHA_BAJA = DateTime.Parse((oreader["FECHA_BAJA"].ToString().Equals("") ? "01/01/01" : oreader["FECHA_BAJA"].ToString()));
                                motivoPedidoModel.ACTIVO = char.Parse(oreader["ACTIVO"].ToString());

                                MotivoPedidoList.Add(motivoPedidoModel);
                            }
                        }

                    }
                }
                catch { }
                finally {
                    if (null != cnx)
                    {
                        cnx.Close();
                        cnx.Dispose();
                       //OracleConnection.ClearPool(cnx);
                    }
                }

            }
            return MotivoPedidoList;
        }
    }
}
