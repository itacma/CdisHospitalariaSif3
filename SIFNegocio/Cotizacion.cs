using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIFNegocio.Helpers;

namespace SIFNegocio
{
    public class Cotizacion
    {
        public static List<SIFModelo.Cotizacion> Cotizaciones = new List<SIFModelo.Cotizacion>();
        public List<SIFModelo.CotizacionDetalle> CotizacionDetalles = new List<SIFModelo.CotizacionDetalle>();

        public SIFModelo.Cotizacion CotizacionM = new SIFModelo.Cotizacion();

        public List<SIFModelo.Cotizacion> CotizacionesNoPagadas = new List<SIFModelo.Cotizacion>();

        public List<SIFModelo.CotizacionDetalle> CargaCotizacionDetalles(SIFModelo.Cotizacion Cotizacion)
        {
            if (Cotizacion.Detalles != null && Cotizacion.Detalles.Count > 0)
            {
                return Cotizacion.Detalles;
            }

            this.CotizacionDetalles = SIFDatos.Cotizaciones.CargaDetalles(Cotizacion);
            Cotizacion.Detalles = CotizacionDetalles;
            return Cotizacion.Detalles;
        }

        public SIFModelo.Cotizacion CargaCotizacion(SIFModelo.Cotizacion Cotizacion, SIFModelo.Sucursal sucursal)
        {
            return SIFDatos.Cotizaciones.CargaCotizacion(Cotizacion, sucursal);
        }

        public SIFModelo.Cotizacion CargaCotizacionNum(string Cotizacion, SIFModelo.Sucursal sucursal)
        {
            return SIFDatos.Cotizaciones.CargaCotizacionNum(Cotizacion, sucursal);
        }

        public void AgregaDetalle(SIFModelo.CotizacionDetalle detalle)
        {
            var encontrado = from r in CotizacionDetalles where r.ArticuloID == detalle.ArticuloID select r;

            if (encontrado.Count() > 0)
            {
                SIFModelo.CotizacionDetalle contenido = encontrado.FirstOrDefault<SIFModelo.CotizacionDetalle>();
                contenido.CantidadCotizacion = contenido.CantidadCotizacion+detalle.CantidadCotizacion;
                RecalculaDetalle(contenido, CotizacionM);
            }
            else
            {
                detalle.NumeroPartida = CotizacionDetalles.Count + 1;
                RecalculaDetalle(detalle, CotizacionM);
                CotizacionDetalles.Add(detalle);
            }


        }

        //public bool conBeneficiosPfizer(SIFModelo.WebServices.TarjetaPfizer tarjetaPfizer, List<SIFModelo.CotizacionDetalle> detalles)
        //{
        //    SIFNegocio.WebServices.PFIZER wsPfizer = new WebServices.PFIZER();
        //    bool conBeneficio = false;
        //    foreach (var articulo in wsPfizer.ProcesaVenta(tarjetaPfizer, detalles,))
        //    {
        //        if (articulo.BeneficioProveedor == SIFModelo.Tipos.SiNo.SI)
        //        {
        //            conBeneficio = true;
        //        }
        //    }
        //    return conBeneficio;
        //}

        public bool GuardaCotizacion(SIFModelo.Cotizacion Cotizacion, List<SIFModelo.CotizacionDetalle> CotizacionDetalles)
        {
            //if (SIFDatos.Cotizaciones.InsertaCotizacion(Cotizacion))
            //{
            //    foreach (var detalle in CotizacionDetalles)
            //    {
            //        //detalle.FechaEntrega = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToShortDateString();
            //        //detalle.FolioControlado = "0";
            //        detalle.ImpuestoID = 0;
            //        detalle.IVA = 0;
            //        //detalle.Lote = "0";
            //        detalle.NumeroCotizacion = Cotizacion.NumeroCotizacion;
            //        detalle.PaqueteID = 0;
            //        detalle.SucursalID = Cotizacion.SucursalID;
            //        //detalle.Total = detalle.Precio;
            //        //SIFDatos.Cotizaciones.InsertaCotizacionDetalle(detalle);
            //    }

            return true;
            //}
            //return false;

        }


        //public System.Data.DataSet BuscaCotizacionesNoPagadas(SIFModelo.Sucursal sucursal)
        //{
        //    System.Data.DataSet ds = SIFDatos.Cotizacion.CotizacionesNoPagadas(sucursal);
        //    return ds;
        //}

        public System.Data.DataSet BuscaCotizacionesNoPagadas(SIFModelo.Sucursal sucursal, SIFModelo.Cotizacion Cotizacion, string tipo)
        {
            System.Data.DataSet ds = SIFDatos.Cotizaciones.CotizacionsNoGenerados(sucursal, Cotizacion, tipo);
            return ds;
        }

        public System.Data.DataSet BuscaCotizaciones(SIFModelo.Sucursal sucursal, SIFModelo.Cotizacion Cotizacion, string tipo)
        {
            System.Data.DataSet ds = SIFDatos.Cotizaciones.CotizacionsNoGenerados(sucursal, Cotizacion, tipo);
            return ds;
        }

        public System.Data.DataSet BuscaCotizaciones(SIFModelo.Sucursal sucursal, SIFModelo.Cotizacion Cotizacion, string tipo, DateTime fecha1, DateTime fecha2)
        {
            System.Data.DataSet ds = SIFDatos.Cotizaciones.CotizacionsNoGenerados(sucursal, Cotizacion, tipo, fecha1, fecha2);
            return ds;
        }

        public bool ContieneDetalle(SIFModelo.Articulo articulo)
        {
            var encontrado = from r in CotizacionDetalles where r.ArticuloID == articulo.ARTICULO_ID select r;

            if (encontrado.Count() > 0)
            {
                return true;
            }

            return false;
        }

        public void ModificaCantidad(SIFModelo.Articulo articulo, int cantidad)
        {
            var encontrado = from r in CotizacionDetalles where r.ArticuloID == articulo.ARTICULO_ID select r;

            if (encontrado.Count() > 0)
            {
                SIFModelo.CotizacionDetalle contenido = encontrado.FirstOrDefault<SIFModelo.CotizacionDetalle>();
                contenido.CantidadCotizacion = cantidad;

                RecalculaDetalle(contenido, CotizacionM);
            }

        }

        public void ValidaDetallePedido(SIFModelo.Articulo articulo)
        {
            var encontrado = from r in CotizacionDetalles where r.ArticuloID == articulo.ARTICULO_ID select r;

            if (encontrado.Count() > 0)
            {
                SIFModelo.CotizacionDetalle contenido = encontrado.FirstOrDefault<SIFModelo.CotizacionDetalle>();
                contenido.Validado = true;

                //RecalculaDetalle(contenido);
            }

        }
        public void RecalculaDetalle(List<SIFModelo.CotizacionDetalle> detalles, SIFModelo.Cotizacion cotizacion)
        {
            cotizacion.Descuento = 0;
            foreach (SIFModelo.CotizacionDetalle Det in detalles)
            {
                RecalculaDetalle(Det, cotizacion);
            }
        }

        public void RecalculaDetalle(SIFModelo.CotizacionDetalle detalle, SIFModelo.Cotizacion cotizacion)
        {
            SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
            if (precios == null)
            {
                return;
            }

            decimal importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.CantidadCotizacion * detalle.Precio);

            detalle.ImpuestoID = precios.IMP_VENTA;
            SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);
            if (impuesto != null)
            {
               /* decimal descuento = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(importe * (cotizacion.PorcentajeDescuento / 100));

                decimal calculaImpuesto = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((importe - descuento) * (impuesto.Porcentaje / 100m));
                detalle.IVA = calculaImpuesto;
                cotizacion.Descuento = descuento + cotizacion.Descuento;


                detalle.IVA = calculaImpuesto;*/

                importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.CantidadCotizacion * detalle.Precio);
                detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                
                /// AVM 16-04-2015 FORMA EN LA QUE SE CALCULA EL DESCUENTO
                /// checamos si el articulo tiene SD no aplica descuento
                SIFNegocio.Articulo LogArt = new Articulo();
                SIFModelo.Articulo Articulo = LogArt.BuscarPorClave(detalle.ArticuloID);
                decimal descuento =0;
                if (!Articulo.TIPO_MEDICAMENTO_CVE.Contains("SD"))
                descuento  = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(importe * (cotizacion.PorcentajeDescuento / 100));
                ///

                //detalle.Precio = detalle.Precio / (1 + (impuesto.Porcentaje / 100m));
                //decimal ImpAntesIva = importe / (1 + (impuesto.Porcentaje / 100m));
                detalle.Descto = descuento;
                decimal ImpAntesIva = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((importe - descuento) / (1 + (impuesto.Porcentaje / 100m)));
                

                ImpAntesIva = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(ImpAntesIva);

                /// CAMBIO AVM IGUALADO CON VENTA 
                decimal calculaImpuesto = ImpAntesIva * impuesto.Porcentaje / 100m;
                //decimal calculaImpuesto = importe - ImpAntesIva;
                //importe = importe - descuento;

                detalle.IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(calculaImpuesto);
                
                /// CAMBIO AVM IGUALADO CON VENTA 
                // detalle.Total = (detalle.Precio - detalle.Descto) * detalle.CantidadCotizacion;
                 detalle.Total = (detalle.Precio * detalle.CantidadCotizacion) - detalle.Descto;
                
            }

            //detalle.Total = importe;
        }


        public bool Cancela(SIFModelo.Cotizacion Cotizacion)
        {
            //if (Cotizacion.Condiciones == "PFIZER")
            //{
            //    SIFNegocio.WebServices.PFIZER pfizer = new SIFNegocio.WebServices.PFIZER();
            //    SIFModelo.WebServices.PfizerControl pc = pfizer.Control(Cotizacion);
            //    pfizer.Cancela(pc.COTIZACION_ID, pc.NO_TARJETA);
            //}

            return SIFDatos.Cotizaciones.Cancela(Cotizacion);
        }

        public void CancelaPedidosyApartados24HRS(SIFModelo.Sucursal sucursal)
        {
            foreach (SIFModelo.Cotizacion Cotizacion in SIFDatos.Cotizaciones.CotizacionesPendientes24hrs(sucursal))
            {
                SIFDatos.Cotizaciones.Cancela(Cotizacion);
            }
        }

        public List<SIFModelo.CotizacionDetalle> CargaDetalles(SIFModelo.Cotizacion cotizacion)
        {
            return SIFDatos.Cotizaciones.CargaDetalles(cotizacion);
        }

        public List<SIFModelo.CotizacionDetalle> CargaDetallesF(SIFModelo.Cotizacion cotizacion)
        {
            return SIFDatos.Cotizaciones.CargaDetallesF(cotizacion);
        }
        public bool ActualizaCotizacion(SIFModelo.Cotizacion cotizacion)
        {
            return SIFDatos.Cotizaciones.ActualizaCotizacion(cotizacion);
        }

        public bool Inserta(SIFModelo.Cotizacion cotizacion)
        {
            return SIFDatos.Cotizaciones.Inserta(cotizacion);
        }

        public bool Elimina(SIFModelo.Cotizacion cotizacion)
        {
            return SIFDatos.Cotizaciones.Elimina(cotizacion);
        }

        public int GuardaDatos(SIFNegocio.Cotizacion LogicaCotiza)
        {

            if (LogicaCotiza.CotizacionDetalles.Count == 0)
            {
                return 1;
            }


            //if (LogicaCotiza.CotizacionM.ClienteID == 0 || LogicaCotiza.CotizacionM.ClienteID == 1 || LogicaCotiza.CotizacionM.ClienteID == 0)
            //{
            //    return 2;

            //}


            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(LogicaCotiza.CotizacionM.ClienteID);
               
            //cotizacion.Total = logica.Total;
            if (string.IsNullOrEmpty(LogicaCotiza.CotizacionM.NumeroCredencial))
            {
                LogicaCotiza.CotizacionM.NumeroCredencial = "0";
            }
            

            int numeroPartida = 1;
            LogicaCotiza.CotizacionM.FechaCotizacion = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            LogicaCotiza.CotizacionM.Receta = SIFModelo.Tipos.SiNo.NO;
            if (LogicaCotiza.CotizacionM.Factura != SIFModelo.Tipos.SiNo.SI)
                LogicaCotiza.CotizacionM.Factura = SIFModelo.Tipos.SiNo.NO;

            //if (!LogicaCotiza.Inserta(LogicaCotiza.CotizacionM))
            //{
            //    return 3;
            //}
            foreach (SIFModelo.CotizacionDetalle detalle in LogicaCotiza.CotizacionDetalles)
            {
                detalle.DescuentoID = LogicaCotiza.CotizacionM.TipoCambioID;
                detalle.NumeroPartida = numeroPartida;
                detalle.NumeroCotizacion = LogicaCotiza.CotizacionM.NumeroCotizacion;
                detalle.SucursalID = LogicaCotiza.CotizacionM.SucursalID;
                //LogicaCotiza.InsertaDetalle(detalle);

                numeroPartida++;
            }


            if (!LogicaCotiza.InsertaBulk(LogicaCotiza.CotizacionM, LogicaCotiza.CotizacionDetalles))
            {
                return 3;
            }

            return 0;

        }

        private bool InsertaBulk(SIFModelo.Cotizacion cotizacion, List<SIFModelo.CotizacionDetalle> detalles)
        {
            return SIFDatos.Cotizaciones.InsertaBulk(cotizacion, detalles);
        }

        public bool InsertaDetalle(SIFModelo.CotizacionDetalle cotizacionDetalle)
        {
            return SIFDatos.Cotizaciones.InsertaDetalle(cotizacionDetalle);
        }

        public string NumeroCotizacion(int sucursalID)
        {
            string prefijoFolio = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yy");

            int numCotizacion = SIFDatos.Cotizaciones.NumeroCotizacion(sucursalID, prefijoFolio);

            string sb = sucursalID.ToString("00") + prefijoFolio + numCotizacion.ToString().PadLeft(11, '0');
            //sb = sb.PadLeft(15,'0');
            return sb;
        }

        public void CotizacionVentaInserta(SIFModelo.Cotizacion cotizacion, SIFModelo.Remision numRemision)
        {
            SIFDatos.Cotizaciones.CotizacionVentaInserta(cotizacion, numRemision);
        }

        public string CreaCotizacionDeremision(string _remision, string movimiento, string cnx)
        {
            return SIFDatos.Cotizaciones.CreaCotizacionDeremision(_remision, movimiento, cnx);
        }
    }
}
