using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio.OrdenCompra
{
    public class ManejoDescuentos
    {
        public SIFModelo.OrdenCompra.OrdenesCompraDataSet Buscar(string nombre, DateTime fecha1, DateTime fecha2)
        {
            return SIFDatos.OrdenCompra.ManejoDescuentos.Buscar(nombre, fecha1, fecha2);
        }

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow Oferta(string articuloID)
        {
            return SIFDatos.OrdenCompra.ManejoDescuentos.Oferta(articuloID);
        }


        public bool Nuevo(SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow oferta, Boolean tomaArchivo)
        {
            return SIFDatos.OrdenCompra.ManejoDescuentos.Inserta(oferta, tomaArchivo );
        }

        public bool Modificar(SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow oferta)
        {
            return SIFDatos.OrdenCompra.ManejoDescuentos.Actualiza(oferta);
        }

        public bool NuevoDetalle(SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow oferta)
        {
            return SIFDatos.OrdenCompra.ManejoDescuentos.InsertaDetalle(oferta);
        }

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableDataTable Detalles;

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableDataTable CargaDetalles(SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow Lista)
        {
            Detalles = SIFDatos.OrdenCompra.ManejoDescuentos.CargaDetalles(Lista);
            return Detalles;
        }

        public bool ModificarDetalle(SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow row)
        {
            return SIFDatos.OrdenCompra.ManejoDescuentos.ActualizaDetalle(row);
        }

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow DescuentoActivo(SIFModelo.Articulo articulo)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow ofertas = new SIFModelo.OrdenCompra.OrdenesCompraDataSet().LISTA_OFERTAS_VENTA.NewLISTA_OFERTAS_VENTARow();
            ofertas.FECHA_ALTA = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Hour, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Minute, 1);
            ofertas.FECHA_BAJA = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Hour, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Minute, 1);
            return SIFDatos.OrdenCompra.ManejoDescuentos.DescuentoActivo(articulo, ofertas);
        }

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow DescuentoActivo(SIFModelo.Articulo articulo, SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow Lista)
        {
            return SIFDatos.OrdenCompra.ManejoDescuentos.DescuentoActivo(articulo, Lista);
        }

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTA_DETALLEDataTableRow OfertaPorArticuloOfertaID(string articulo, int ofertaID)
        {
            return SIFDatos.OrdenCompra.ManejoDescuentos.OfertaPorArticuloOfertaID(articulo, ofertaID);
        }

        public String insertaOfertasMensuales( String[] Clave,  Decimal[] Descuento)
        {
            return SIFDatos.OrdenCompra.ManejoDescuentos.insertaArchivoImpOfertas(Clave, Descuento);
        }

        
            public String InsertaPromocionesLayout(
                                    string pFileName,
                                    string replacefile,
                                    Int16 pUser,
                                    String[] p_codigo,
                                    Int16[] p_Partda,
                                    Int16[] p_oferta,
                                    Decimal[] p_precio_de_venta,
                                    Int16[] p_cantidad_req,
                                    Int16[] p_cantidad_beneficio,
                                    String[] p_fecha_inicio,
                                    String[] p_fecha_fin,
                                    String[] p_aplica_sucursales,
                                    String[] p_tipo_promocion
                )
        {
            return SIFDatos.OrdenCompra.ManejoDescuentos.InsertaPromocionesLayout(

                                        pFileName,
                                        replacefile,
                                        pUser,
                                        p_codigo,
                                        p_Partda,
                                        p_oferta,
                                        p_precio_de_venta,
                                        p_cantidad_req,
                                        p_cantidad_beneficio,
                                        p_fecha_inicio,
                                        p_fecha_fin,
                                        p_aplica_sucursales,
                                        p_tipo_promocion
                );
        }


        public List<SIFModelo.Ofertas.ListaPromocionesActivas> GetListSkuPromociones() {
            return SIFDatos.OrdenCompra.ManejoDescuentos.GetListSkuPromociones();
                
        }

    }
}
