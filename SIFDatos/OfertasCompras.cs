using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace SIFDatos
{
    public static class OfertasCompras
    {


        public static SIFModelo.Catalogo.CatalogoDataSet.OFERTAS_COMPRAS_MAYORISTADataTable Buscar(string parametroBusqueda, SIFModelo.Sucursal sucursal, SIFModelo.Cliente proveedor, string propiedadBusqueda)
        {
            SIFModelo.Catalogo.CatalogoDataSet ds = new SIFModelo.Catalogo.CatalogoDataSet();
            SIFModelo.Catalogo.CatalogoDataSetTableAdapters.OFERTAS_COMPRAS_MAYORISTATableAdapter ta = new SIFModelo.Catalogo.CatalogoDataSetTableAdapters.OFERTAS_COMPRAS_MAYORISTATableAdapter();
            ta.Connection.ConnectionString = Helpers.ConnectionString.Connection();
            ta.Fill(ds.OFERTAS_COMPRAS_MAYORISTA);

            return ds.OFERTAS_COMPRAS_MAYORISTA;
        }

        public static bool Modificar(SIFModelo.Catalogo.CatalogoDataSet.OFERTAS_COMPRAS_MAYORISTARow modelo)
        {
            string sentencia = "SP_UPD_OFERTA_COMPRA_MAYORISTA";
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.BindByName = true;
                    DateTime? fechaBaja = null;
                    if(!modelo.IsFECHA_BAJANull())
                    {
                        fechaBaja = modelo.FECHA_BAJA;
                    }
                    //PARAMETROS
                    cmd.Parameters.Add("earticulo_id", modelo.ARTICULO_ID);
                    cmd.Parameters.Add("eproveedor_id", modelo.PROVEEDOR_ID);
                    cmd.Parameters.Add("efecha_alta", modelo.FECHA_ALTA);
                    cmd.Parameters.Add("enombre1", modelo.NOMBRE1);
                    cmd.Parameters.Add("elaboratorio_id", modelo.IsLABORATORIO_IDNull() ? 0 : modelo.LABORATORIO_ID);
                    cmd.Parameters.Add("eprecio_farmacia", modelo.PRECIO_FARMACIA);
                    cmd.Parameters.Add("eprecio_publico", modelo.PRECIO_PUBLICO);
                    cmd.Parameters.Add("etipo_oferta", modelo.TIPO_OFERTA);
                    cmd.Parameters.Add("edescto_ofrecido", modelo.DESCTO_OFRECIDO);
                    cmd.Parameters.Add("edescrip_descto", modelo.DESCRIP_DESCTO);
                    cmd.Parameters.Add("eminimo_piezas", modelo.MINIMO_PIEZAS);
                    cmd.Parameters.Add("ecantidad_acomprar", modelo.CANTIDAD_ACOMPRAR);
                    cmd.Parameters.Add("epiezas_con_cargo", modelo.PIEZAS_CON_CARGO);
                    cmd.Parameters.Add("epiezas_sin_cargo", modelo.PIEZAS_SIN_CARGO);
                    cmd.Parameters.Add("eestado_art_provee", modelo.ESTADO_ART_PROVEE);
                    cmd.Parameters.Add("eestado_art_fleming", modelo.IsESTADO_ART_FLEMINGNull() ? "V" : modelo.ESTADO_ART_FLEMING);
                    cmd.Parameters.Add("edescto_adicional_provee", modelo.DESCTO_ADICIONAL_PROVEE);
                    cmd.Parameters.Add("edescto_especial_provee", modelo.DESCTO_ESPECIAL_PROVEE);
                    cmd.Parameters.Add("efecha_baja", fechaBaja);
                    cmd.Parameters.Add("ecodigo_proveedor", modelo.CODIGO_PROVEEDOR);
                    cmd.Parameters.Add("eescala", modelo.ESCALA);
                  
                    //PARAMETROS DE SALIDA
                    OracleParameter outparam = new OracleParameter("outparam", OracleDbType.Int32);
                    outparam.Direction = System.Data.ParameterDirection.Output;

                    //AGREGAR LOS PARAMETROS
                    cmd.Parameters.Add(outparam);

                    object id = 0;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!outparam.Value.ToString().IsIntegerPositive())
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

        public static SIFModelo.Catalogo.CatalogoDataSet.OFERTAS_COMPRAS_MAYORISTARow OfertaPorArticuloIdProveedor(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row)
        {
            SIFModelo.Catalogo.CatalogoDataSet ds = new SIFModelo.Catalogo.CatalogoDataSet();
            SIFModelo.Catalogo.CatalogoDataSetTableAdapters.OFERTAS_COMPRAS_MAYORISTATableAdapter ta = new SIFModelo.Catalogo.CatalogoDataSetTableAdapters.OFERTAS_COMPRAS_MAYORISTATableAdapter();
            ta.Connection.ConnectionString = Helpers.ConnectionString.Connection();
            ta.FillByArticuloProveedor(ds.OFERTAS_COMPRAS_MAYORISTA,row.ARTICULO_ID, row.PROVEEDOR_ID);

            if (ds.OFERTAS_COMPRAS_MAYORISTA.Count > 0)
            {
                return ds.OFERTAS_COMPRAS_MAYORISTA.FirstOrDefault();
            }
            return null;
        }
    }
}
