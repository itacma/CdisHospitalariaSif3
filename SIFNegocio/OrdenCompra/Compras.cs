using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio.OrdenCompra
{
    public class Compras
    {
        public static string FolioCompra(SIFModelo.Sucursal sucursal)
        {
            string prefijoFolio = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yy");
            string prefijoMes = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("MM");
            int numCompra = SIFDatos.OrdenCompra.Compra.GeneraFolio(sucursal, prefijoFolio);
            string sb = sucursal.SucursalID.ToString("00") + prefijoFolio + prefijoMes +"1"+ numCompra.ToString().PadLeft(8, '0');
            return sb;
        }

        public static bool Guardar(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow rowCompras, SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable detalles)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow compra = CompraPorId(rowCompras);
            if (compra == null)
            {
                if (rowCompras.IsFACTURANull() || string.IsNullOrEmpty(rowCompras.FACTURA.ToString()))
                {
                    rowCompras.FACTURA = "-";
                }
                if (rowCompras.IsFOLIO_FACTURA_SATNull())
                {
                    rowCompras.FOLIO_FACTURA_SAT = "-";
                }

                rowCompras.FOLIO_COMPRA = SIFNegocio.OrdenCompra.Compras.FolioCompra(Helpers.Sesion.Sucursal);

                bool agregado = SIFDatos.OrdenCompra.Compra.Inserta(rowCompras);

                foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow detalle in detalles)
                {
                    if (detalle.IsLOTENull())
                    {
                        detalle.LOTE = " ";
                    }

                     
                    //if(detalle.
                    //SIFDatos.OrdenCompra.Compra.InsertaDetalle(rowCompras, detalle);
                }

                detalles.AcceptChanges();
                SIFDatos.OrdenCompra.Compra.InsertaDetalles(rowCompras, detalles);
                
                return agregado;
            }
            else
            {
                if (rowCompras.IsFOLIO_FACTURA_SATNull())
                {
                    rowCompras.FOLIO_FACTURA_SAT = "-";
                }

                foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow detalle in detalles)
                {
                    if (detalle.IsLOTENull())
                    {
                        detalle.LOTE = " ";
                    }

                    if (detalle.RowState == System.Data.DataRowState.Added)
                    {
                        SIFDatos.OrdenCompra.Compra.InsertaDetalle(rowCompras, detalle);
                        continue;
                    }

                    SIFDatos.OrdenCompra.Compra.ActualizaDetalle(rowCompras, detalle);
                }

                return SIFDatos.OrdenCompra.Compra.Actualiza(rowCompras);
            }

            return false;
        }

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASDataTable OrdenesCompraPorOCId(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OrdenCompra)
        {
            return SIFDatos.OrdenCompra.Compra.OrdenesCompraPorOCId(OrdenCompra);
        }

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow OrdenCompraPorOCId(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OrdenCompra)
        {
            return SIFDatos.OrdenCompra.Compra.OrdenesCompraPorOCId(OrdenCompra).FirstOrDefault();
        }

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow CompraPorId(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow compra)
        {
            return SIFDatos.OrdenCompra.Compra.CompraPorId(compra);
        }

        public static void GuardaDetalle(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row)
        {
            SIFDatos.OrdenCompra.Compra.InsertaCompraDetalle(row);
        }

        public SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable CompraDetalles { get; set; }

        public SIFModelo.Catalogo.CatalogoDataSet.OFERTAS_COMPRAS_MAYORISTARow OfertaPorArticuloProveedor(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row)
        {
            return SIFDatos.OfertasCompras.OfertaPorArticuloIdProveedor(row);
        }

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable OrdenCompraDetallesPorCompraId(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow compra)
        {
            return SIFDatos.OrdenCompra.Compra.BuscaCompraDetalle(compra);
        }
        public static List<SIFModelo.OrdenCompra.DevProveedor> DetallesDevPorCompraId(string folio_compra)
        {
            return SIFDatos.OrdenCompra.Compra.devDetallesCompra(folio_compra);
        }

        public static List<SIFModelo.OrdenCompra.RepoProveedor> DetallesRepPorCompraId(string folio_compra)
        {
            return SIFDatos.OrdenCompra.Compra.RepDetallesCompra(folio_compra);
        }
        public static System.Data.DataSet BuscaBonificacion(string folio_compra, DateTime fecha1, DateTime fecha2)
        {
            return SIFDatos.OrdenCompra.Compra.BuscaBonificacion(folio_compra, fecha1, fecha2);
        }
        public static System.Data.DataSet BuscaDevProveedor(string folio_compra, DateTime fecha1, DateTime fecha2)
        {
            return SIFDatos.OrdenCompra.Compra.BuscaDevProveedor(folio_compra, fecha1, fecha2);
        }

        public static System.Data.DataSet BuscaRepProveedor(string folio_compra, DateTime fecha1, DateTime fecha2)
        {
            return SIFDatos.OrdenCompra.Compra.BuscaRepProveedor(folio_compra, fecha1, fecha2);
        }
        public static bool ActualziarRecepcionPrecios(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow compra)
        {
            return SIFDatos.OrdenCompra.Compra.ActualziarRecepcionPrecios(compra.FOLIO_COMPRA);
        }
        public static bool ActualziarRecepcionPreciosFolioCompra(String FolioCompra)
        {
            return SIFDatos.OrdenCompra.Compra.ActualziarRecepcionPrecios(FolioCompra);
        }

        public static string spCierraCaducidades(String FolioCompra)
        {
            return SIFDatos.OrdenCompra.Compra.spCierraCaducidades(FolioCompra);
        }
        
        public static string spLiberaOrdenCompra(String FolioCompra)
        {
            return SIFDatos.OrdenCompra.Compra.spLiberaOrdenCompra(FolioCompra);
        }
        public static string spCreaTraspasos(String FolioCompra,string idsuc)
        {
            return SIFDatos.OrdenCompra.Compra.spCreaTraspasosVirtuales(FolioCompra, idsuc);
        }


        public static string CodigoProveedorSABA(SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocdRow)
        {
            return SIFDatos.OrdenCompra.Compra.CodigoProveedorSABA(ocdRow);
        }

        public static string CodigoProveedorNADRO(SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocdRow)
        {
            return SIFDatos.OrdenCompra.Compra.CodigoProveedorNADRO(ocdRow);
        }

        public static string CodigoProveedorDROG(SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocdRow)
        {
            return SIFDatos.OrdenCompra.Compra.CodigoProveedorDROG(ocdRow);
        }
        
        public static SIFModelo.Catalogo.ArticuloMayorista ArticuloProveedorDROG(SIFModelo.Articulo articulo)
        {
            return SIFDatos.OrdenCompra.Compra.CatalogoProveedorDROG(articulo);
        }
        
        public static SIFModelo.Catalogo.ArticuloMayorista ArticuloProveedorSABA(SIFModelo.Articulo articulo)
        {
            return SIFDatos.OrdenCompra.Compra.CatalogoProveedorSABA(articulo);
        }

        public static SIFModelo.Catalogo.ArticuloMayorista ArticuloProveedorNadro(SIFModelo.Articulo articulo)
        {
            return SIFDatos.OrdenCompra.Compra.CatalogoProveedorNadro(articulo);
        }

        public static void ActualizaCodigo(string ArticuloID, string Nombre, string Clave)
        {
            SIFDatos.OrdenCompra.Compra.ActualizaCodigo(ArticuloID, Nombre, Clave);
        }

        public static void ActualizaDetalles(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow compra, SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable cOMPRAS_DETDataTable)
        {
            //SIFDatos.OrdenCompra.Compra.ActualizaDetalles(compra, cOMPRAS_DETDataTable);

            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow row in cOMPRAS_DETDataTable)
            {
                if (double.IsInfinity(row.COSTO_NETO_UNIT_REC))
                {
                    row.COSTO_NETO_UNIT_REC = 0;
                }
                SIFDatos.OrdenCompra.Compra.ActualizaDetalle(compra, row);
            }
        }

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_LOTERow CompraLotePorId(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow Compra)
        {
            return SIFDatos.OrdenCompra.Compra.CompraLotePorId(Compra);
        }

        public static bool GuardarCompraLote(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_LOTERow compraLote, SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTEDataTable detalles)
        {
            bool insertado = SIFDatos.OrdenCompra.Compra.GuardaLoteCaducidad(compraLote, detalles);
            SIFDatos.OrdenCompra.Compra.GuardaLoteCaducidadDetalles(compraLote, detalles);
            return insertado;
        }

        public static SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DET_LOTEDataTable OrdenCompraDetallesLotePorCompraId(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_LOTERow compraLote)
        {
            return SIFDatos.OrdenCompra.Compra.CompraDetalleLotePorId(compraLote);
        }

        public BindingListView<SIFModelo.OrdenCompra.ModoPago> ObtenerModosdePago()
        {
            BindingListView<SIFModelo.OrdenCompra.ModoPago> ListaModos;
            ListaModos = new BindingListView<SIFModelo.OrdenCompra.ModoPago>(SIFDatos.OrdenCompra.Compra.ObtieneDatosPago());
            if (ListaModos.DataSource == null)
            {
                ListaModos = new BindingListView<SIFModelo.OrdenCompra.ModoPago>(new List<SIFModelo.OrdenCompra.ModoPago>());
                return ListaModos;
            }

            /*foreach (var item in ListaModos)
            {
                SIFModelo.Usuario usuario = new SIFModelo.Usuario() { UsuariosID = ((ObjectView<SIFModelo.Sucursal>)item).Object.ResponsableID };

                usuario = SIFDatos.Usuarios.UsuarioPorId(usuario);
                if (usuario == null)
                {
                    continue;
                }
                ((ObjectView<SIFModelo.Sucursal>)item).Object.ResponsableNombre = usuario.Nombre;
            }*/

            return ListaModos;
        }

        public static string UpdOCModoPago(string oc, string mp)
        {
            return SIFDatos.OrdenCompra.Compra.UpdOCModoPago(oc,mp);
        }

        public static void CompararPrecioUAMPH(List<SIFModelo.OrdenCompra.ArticuloPrecio> articulos, int usuarioId, string FOLIO_COMPRA)
        {
            SIFDatos.OrdenCompra.Compra.CompararPrecioUAMPH( articulos, usuarioId, FOLIO_COMPRA);
        }

        public static string InsertarAuditoria(string userId, string fecha, string num_orden, string Total_piezas, string Ruta_archivo)
        {
            return SIFDatos.OrdenCompra.Compra.InsertarAuditoria( userId,  fecha,  num_orden,  Total_piezas, Ruta_archivo);
        }

        public static void ActualizarComprasDetMasivo(
        List<string> articulos,
        List<decimal> cantidades,
        List<decimal> precios,
        string FOLIO_COMPRA,
        string numFactura)
        {
            SIFDatos.OrdenCompra.Compra.ActualizarComprasDetMasivo(articulos, cantidades, precios, FOLIO_COMPRA, numFactura);
        }

        public static string ValidarComprasDet(string numCompra, List<string> articulos)
        {
            try
            {
                return SIFDatos.OrdenCompra.Compra.ValidarComprasDet(numCompra, articulos);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la validación: " + ex.Message, ex);
            }
        }

        public static bool ExisteOrden(string numOrden)
        {
            return SIFDatos.OrdenCompra.Compra.ExisteOrdenEnAuditoria(numOrden);
        }


    }

}
