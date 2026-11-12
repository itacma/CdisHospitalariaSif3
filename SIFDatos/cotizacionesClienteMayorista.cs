using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIFDatos
{
    public class cotizacionesClienteMayorista
    {

        public static DataSet getCotizaciones(SIFModelo.Sucursal sucursal, SIFModelo.Cotizacion Cotizacion, String Tipo)
        {
            DataSet ds = new DataSet("DSCotizaciones");
            ds.Tables.Add("Cotizaciones");
            string sentencia = "select NUM_COTIZACION AS FOLIO, fecha_COTIZACION as FECHA, (SELECT NOMBRE FROM CAT_USUARIOS WHERE CAT_USUARIOS.USUARIOS_ID=VENDEDOR_ID) AS ASESOR, (SELECT  NOMBRE || ' ' || APE_PATERNO || ' ' || APE_MATERNO FROM CAT_CLIENTES WHERE CAT_CLIENTES.CLIENTES_ID=COTIZACION.CLIENTE_ID) AS NOMBRE, (Select COLONIA FROM DIR_CLIENTES WHERE DIR_CLIENTES.CLIENTES_ID=COTIZACION.CLIENTE_ID AND TIPO_DIR='CA') AS COLONIA, " +
                               " COMENTARIO,FACTURA,RECETA,TOT_ART_COTIZACION AS NO_TOTAL_ARTICULOS,TOTAL " +
                               ",ACTIVO as status, * FROM COTIZACION WHERE  ACTIVO='S' AND sucursal_id = :SucursalId AND  TIPO_COTIZACION='" + Tipo + "' AND NUM_Cotizacion LIKE :NumeroCotizacion  ORDER BY NUM_COTIZACION DESC "; //AND REF_REMISION_VTA IS NULL

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroCotizacion", "%" + Cotizacion.NumeroCotizacion + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "Cotizaciones");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);
                }

            }

            ds.Tables.Add("CotizacionDetalles");
            string sentenciaDetalles = " select num_COTIZACION as folio, articulo_id as codigo,nombre1,cant_COTIZACION as NoPiezas,(select ubicacion from inventario where inventario.articulo_id=COTIZACION_DET.articulo_id and inventario.sucursal_id=COTIZACION_DET.sucursal_id) as ubicacion, " +
                                       " (select tipo_medicamento_cve from cat_articulos where cat_articulos.articulo_id=COTIZACION_DET.articulo_id) as Tipo,precio*cant_COTIZACION as Total " +
                                       " , * FROM cotizacion_det WHERE sucursal_id = :SucursalId AND NUM_COTIZACION in (SELECT NUM_COTIZACION FROM Cotizacion WHERE  sucursal_id = :SucursalesId AND NUM_COTIZACION LIKE :NumeroCotizacion )ORDER BY cotizacion_det.NUM_PARTIDA  ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentenciaDetalles, cnx))
                {
                    cmd.Parameters.Add("SucursalId", sucursal.SucursalesID);
                    cmd.Parameters.Add("SucursalesId", sucursal.SucursalesID);
                    cmd.Parameters.Add("NumeroCotizacion", "%" + Cotizacion.NumeroCotizacion + "%");
                    //
                    cmd.Connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds, "CotizacionDetalles");
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                   //OracleConnection.ClearPool(cnx);

                }

            }

            return ds;
        }

        public static DataTable buscarArticuloDt(string cadena)
        {
            DataTable tabledev = new DataTable("articulos");
            tabledev.Columns.Add("ARTICULO_ID",typeof(String));
            tabledev.Columns.Add("NOMBRE1", typeof(String));
            tabledev.Columns.Add("EXISTENCIAS", typeof(Int32));
            tabledev.Columns.Add("APARTADO_VTAS", typeof(Int32));
            tabledev.Columns.Add("PRECIO_VENTA", typeof(Decimal));
            tabledev.Columns.Add("PRECIO_COSTO", typeof(Decimal));
            tabledev.Columns.Add("NOMBRE2", typeof(String));

            string sentencia = "PKG_CCM.sp_get_Buscar_Articulo";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cadena = "%" + cadena + "%";
                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter cadenaO = new OracleParameter("CADENA", OracleDbType.Varchar2);
                    cadenaO.Value = cadena;
                    cmd.Parameters.Add(cadenaO);
                    

                    OracleParameter requiciciones = new OracleParameter("REQUI", OracleDbType.RefCursor);
                    requiciciones.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(requiciciones);
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteReader();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                DataRow row = tabledev.NewRow();
                                row["ARTICULO_ID"] = oreader["ARTICULO_ID"];
                                row["NOMBRE1"] = oreader["NOMBRE1"];
                                row["EXISTENCIAS"] = oreader["EXISTENCIAS"];
                                row["APARTADO_VTAS"] = oreader["APARTADO_VTAS"];
                                row["PRECIO_VENTA"] = oreader["PRECIO_VENTA"];
                                row["PRECIO_COSTO"] = oreader["PRECIO_COSTO"];
                                row["NOMBRE2"] = oreader["NOMBRE2"];
                                tabledev.Rows.Add(row);
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error:\n" + e.ToString() + "\n" + "En: PKG_VENTAS_TCA.sp_get_articulos_vale");
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
            }

            return tabledev;

        }



    

    }
}
