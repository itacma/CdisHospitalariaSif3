using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIFNegocio
{
    public class Remision
    {
        public bool reimpr = false;
       
        public SIFModelo.Remision remision = new SIFModelo.Remision();

        public static List<SIFModelo.Remision> Remisiones = new List<SIFModelo.Remision>();
        public List<SIFModelo.RemisionDetalle> RemisionDetalles = new List<SIFModelo.RemisionDetalle>();


        public List<SIFModelo.Remision> RemisionesNoPagadas = new List<SIFModelo.Remision>();

        public List<SIFModelo.RemisionDetalle> CargaRemisionDetalles(SIFModelo.Remision remision)
        {
            //if (remision.Detalles != null && remision.Detalles.Count > 0)
            //{
            //    return remision.Detalles;
            //}


            

            this.RemisionDetalles = SIFDatos.Remision.RemisionDetalles(remision);
            remision.Detalles = RemisionDetalles;


            return remision.Detalles;
          }
        public List<SIFModelo.RemisionDetalle> CargaRemisionDetallesF(SIFModelo.Remision remision)
        {
            //if (remision.Detalles != null && remision.Detalles.Count > 0)
            //{
            //    return remision.Detalles;
            //}




            this.RemisionDetalles = SIFDatos.Remision.RemisionDetallesF(remision);
            remision.Detalles = RemisionDetalles;


            return remision.Detalles;
        }
        public void AgregaDetalle(SIFModelo.RemisionDetalle detalle, SIFModelo.Remision remision, bool loteCaducidad = false, SIFModelo.ClienteSubrogaccion ClienteSub = null, bool agregar = true)
        {
            var encontrado = from r in RemisionDetalles where r.ArticuloID == detalle.ArticuloID select r;

            if (ClienteSub != null)
            {
                encontrado = from r in RemisionDetalles where r.ArticuloID == detalle.ArticuloID && r.CODIGO_CLI_ID == detalle.CODIGO_CLI_ID select r;
            }

            if (encontrado.Count() > 0 && !loteCaducidad && detalle.FolioControlado != "SI" && agregar)
            {
                SIFModelo.RemisionDetalle contenido = encontrado.FirstOrDefault<SIFModelo.RemisionDetalle>();
                contenido.CantidadRemision += detalle.CantidadRemision;
                RecalculaDetalle(contenido, remision, ClienteSub);
            }
            else
            {
                detalle.NumeroPartida = RemisionDetalles.Count + 1;
                RemisionDetalles.Add(detalle);
                RecalculaDetalle(detalle, remision, ClienteSub);
            }

        }

        //public bool conBeneficiosPfizer(SIFModelo.WebServices.TarjetaPfizer tarjetaPfizer, List<SIFModelo.RemisionDetalle> detalles)
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

        public bool GuardaRemision(SIFModelo.Remision remision, List<SIFModelo.RemisionDetalle> remisionDetalles, SIFModelo.ClienteSubrogaccion ClienteSub = null)
        {
            if (string.IsNullOrEmpty(remision.Condiciones))
            {
                remision.Condiciones = " ";
            }


            SIFNegocio.Inventario.Inventario inventario = new Inventario.Inventario();
            remision.FechaVenta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            if (SIFDatos.Remision.InsertaRemisionBulk(remision, remisionDetalles))
            {
                foreach (var detalle in remisionDetalles)
                {
                    //detalle.FechaEntrega = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToShortDateString();
                    if (detalle.FolioControlado == null)
                    {
                        detalle.FolioControlado = "0";
                    }
                    //detalle.ImpuestoID = 0;
                    //detalle.IVA = detalle.IVA;
                    if (string.IsNullOrEmpty(detalle.Lote))
                    {
                        detalle.Lote = "0";
                    }
                    detalle.NumeroRemision = remision.NumeroRemision;
                    detalle.PaqueteID = 0;
                    detalle.SucursalID = remision.SucursalID;
                   // detalle.Total = (detalle.Precio * detalle.CantidadRemision) + detalle.IVA;

                    //if (SIFDatos.Remision.InsertaRemisionDetalle(detalle))
                    //{
                    if (ClienteSub == null)
                    {
                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);


                        if (articulo == null)
                        {
                            return false;
                        }

                        inventario.InventarioArticuloAparta(articulo, detalle.CantidadRemision);
                    }
                    else
                    {
                        SIFModelo.Articulo articulo;
                        if (ClienteSub.PRECIO_FIJO == SIFModelo.Tipos.SiNo.SI)
                        {
                            articulo = new SIFNegocio.Articulo().BuscarPorClaveSub(detalle.CODIGO_CLI, detalle.ArticuloID,ClienteSub.ID.ToString());
                            //articulo.ARTICULO_ID = articulo.CODIGO_CLI;
                        }
                        else
                            articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);

                        if (articulo == null)
                        {
                            return false;
                        }

                        inventario.InventarioArticuloAparta(articulo, detalle.CantidadRemision);
                    }
                }
                //}

                return true;
            }
            return false;

        }

        public List<SIFModelo.Remision> BuscaRemisionesNoPagadas(SIFModelo.Sucursal sucursal)
        {
            this.RemisionesNoPagadas = SIFDatos.Remision.RemisionesNoPagadas(sucursal);
            return RemisionesNoPagadas;
        }

        //public System.Data.DataSet BuscaRemisionesNoPagadas(SIFModelo.Sucursal sucursal)
        //{
        //    System.Data.DataSet ds = SIFDatos.Remision.RemisionesNoPagadas(sucursal);
        //    return ds;
        //}

        public System.Data.DataSet BuscaRemisionesNoPagadas(SIFModelo.Sucursal sucursal, SIFModelo.Remision remision)
        {
            System.Data.DataSet ds = SIFDatos.Remision.RemisionesNoPagadas(sucursal, remision);
            return ds;
        }

        public System.Data.DataSet BuscaRemisiones(SIFModelo.Sucursal sucursal, SIFModelo.Remision remision, DateTime fecha1, DateTime fecha2)
        {
            System.Data.DataSet ds = SIFDatos.Remision.Remisiones(sucursal, remision, fecha1, fecha2);
            return ds;
        }

        public System.Data.DataSet BuscaRemisionesFacturadas(SIFModelo.Sucursal sucursal, SIFModelo.Remision remision)
        {
            System.Data.DataSet ds = SIFDatos.Remision.RemisionesFacturadas(sucursal, remision);
            return ds;
        }

        public System.Data.DataSet BuscaRemisionesNoFacturadas(SIFModelo.Sucursal sucursal, DateTime fecha1, DateTime fecha2)
        {
            System.Data.DataSet ds = SIFDatos.Remision.RemisionesNoFacturadas(sucursal, fecha1, fecha2);
            return ds;
        }

        public String[] BuscaRemisionesSiFacturadas(SIFModelo.Sucursal sucursal, DateTime fecha1, DateTime fecha2)
        {
            String[] ds = SIFDatos.Remision.RemisionesSiFacturadas(sucursal, fecha1, fecha2);
            return ds;
        }

        public bool ContieneDetalle(SIFModelo.Articulo articulo)
        {
            var encontrado = from r in RemisionDetalles where r.ArticuloID == articulo.ARTICULO_ID select r;

            if (encontrado.Count() > 0)
            {
                return true;
            }

            return false;
        }

        public bool ContieneDetalleSub(SIFModelo.Articulo articulo, bool conArticuloID = false)
        {
            var encontrado = from r in RemisionDetalles where r.CODIGO_CLI_ID == articulo.CODIGO_CLI_ID select r;
            if (conArticuloID)
            {
                encontrado = from r in RemisionDetalles where r.CODIGO_CLI_ID == articulo.CODIGO_CLI_ID && r.ArticuloID == articulo.ARTICULO_ID select r;
            }

            if (encontrado.Count() > 0)
            {
                return true;
            }

            return false;
        }

        public string FolioRemision(int sucursalId, out int numRemision)
        {
            string prefijoFolio = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yy");

            numRemision = SIFDatos.Remision.NumeroRemision(sucursalId, prefijoFolio);

            string sb = sucursalId.ToString("00") + prefijoFolio + numRemision.ToString().PadLeft(11, '0'); ;
            //string sb =  numRemision.ToString();
            //sb = sb.PadLeft(15,'0');
            return sb;
        }

        public void ModificaCantidad(SIFModelo.Articulo articulo, int cantidad)
        {
            var encontrado = from r in RemisionDetalles where r.ArticuloID == articulo.ARTICULO_ID select r;

            if (encontrado.Count() > 0)
            {
                SIFModelo.RemisionDetalle contenido = encontrado.FirstOrDefault<SIFModelo.RemisionDetalle>();
                contenido.CantidadRemision = cantidad;

                if (contenido.FolioControlado == "SI")
                {

                    //if (remision.FolioControlado == null)
                    //{
                    //    //MessageBox.Show("Aguregue un folio de controlado");
                    //}
                    //else
                    //{

                    //    //REVISAMOS SI ES FOLIO CONTROLADO
                    //    var folioControlado = from c in remision.FolioControlado.Detalles where c.ArticuloID == articulo.ARTICULO_ID select c;

                    if (contenido.OFolioControlado == null)
                    {
                       MessageBox.Show("No ha asignado un folio controlado para el artículo " + contenido.ArticuloID + " [" + contenido.Nombre1 + "]");
                        return;
                    }

                    if (contenido.OFolioControlado.Detalles.Count == 0)
                    {
                       MessageBox.Show("El artículo no esta dado de alta con un folio controlado");
                        return;
                    }

                    SIFModelo.ControladoDetalle controladoDetalle = contenido.OFolioControlado.Detalles.First();

                    contenido.CantidadRemision = controladoDetalle.Cantidad;

                   MessageBox.Show("La cantidad no puede ser modificada en un producto controlado");
                    return;
                }
                //}


                RecalculaDetalle(contenido, remision);
            }

        }

        public void ValidaDetallePedido(SIFModelo.Articulo articulo)
        {
            var encontrado = from r in RemisionDetalles where r.ArticuloID == articulo.ARTICULO_ID select r;

            if (encontrado.Count() > 0)
            {
                SIFModelo.RemisionDetalle contenido = encontrado.FirstOrDefault<SIFModelo.RemisionDetalle>();
                contenido.Validado = true;

                //RecalculaDetalle(contenido);
            }

        }

        public void RecalculaDetalle(SIFModelo.RemisionDetalle detalle, SIFModelo.Remision remision)
        {
             SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
            if (detalle.Precio == 0)
                detalle.Precio = precios.PRECIO_VENTA;
            decimal importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.CantidadRemision * detalle.Precio);


            if (precios != null)
             {
                SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);

                if (impuesto != null)
                {
                    // detalle.Precio = detalle.Precio / (1 + (impuesto.Porcentaje / 100m));
                    //detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                    importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.CantidadRemision * detalle.Precio);
                    //detalle.Precio = detalle.Precio / (1 + (impuesto.Porcentaje / 100m));
                    detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);

                    // checamos si el articulo tiene SD no aplica descuento
                    SIFNegocio.Articulo LogArt = new Articulo();
                    SIFModelo.Articulo Articulo = LogArt.BuscarPorClave(detalle.ArticuloID);
                    decimal descuento = 0;
                    if (!Articulo.TIPO_MEDICAMENTO_CVE.Contains("SD"))
                        descuento = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(importe * (remision.PorcentajeDescuento / 100));

                    detalle.MontoDescuento = descuento;
                    decimal ImpAntesIva = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((importe - descuento) / (1 + (impuesto.Porcentaje / 100m)));
                
                    /*
                    decimal descuento = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(importe * (remision.PorcentajeDescuento / 100));
                    // decimal importeSIva = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((importe - descuento) / (1 + (impuesto.Porcentaje / 100m)));
                    decimal ImpAntesIva = importe / (1 + (impuesto.Porcentaje / 100m));
                    */

                    ImpAntesIva = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(ImpAntesIva);

                    decimal calculaImpuesto = importe - ImpAntesIva;
                    //verificar que ambas operaciones de el mismo resultado.
                   //decimal calculaImpuesto2 = ImpAntesIva * impuesto.Porcentaje / 100m;

                    detalle.IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((importe - descuento) / (1 + (impuesto.Porcentaje / 100m))) * (impuesto.Porcentaje / 100m));
                    descuento = detalle.MontoDescuento;

                    //verificar operaciones extraidas de cotizacion AVM 
                    decimal IVAcot = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(calculaImpuesto);
                    decimal TOTALcot = (detalle.Precio - detalle.MontoDescuento) * detalle.CantidadRemision;

                    detalle.Total = importe;//  - descuento; AVM 23-04-2015 (CANCELA MODIFICACIÓN)
                    //detalle.MontoDescuento = descuento * detalle.CantidadRemision;

                }
                else
                {
                   MessageBox.Show("No se ha especificado el tipo de impuesto para el artículo " + detalle.ArticuloID + " [" + detalle.Nombre1 + "]");
                }
            }

            //SIFModelo.Descuento descuento = 
            

        }
        public void RecalculaDetalle(SIFModelo.RemisionDetalle detalle, SIFModelo.Remision remision, SIFModelo.ClienteSubrogaccion ClienteSub)
        {
            if (ClienteSub == null)
                RecalculaDetalle(detalle, remision);
            else
            {
                decimal precio = new SIFNegocio.Articulo().ArticuloPorClaveSubPrecio(detalle.ArticuloID, ClienteSub.ID.ToString());
                SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecioSub(detalle.CODIGO_CLI);
                precios.PRECIO_VENTA = precio;
                detalle.Precio = precios.PRECIO_VENTA;
                //if (detalle.Precio == 0)
                //    detalle.Precio = precios.PRECIO_VENTA;
                decimal importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.CantidadRemision * detalle.Precio);


                if (precios != null)
                {
                    SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);

                    if (impuesto != null)
                    {
                        // detalle.Precio = detalle.Precio / (1 + (impuesto.Porcentaje / 100m));
                        //detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                        importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.CantidadRemision * detalle.Precio);

                        //detalle.Precio = detalle.Precio / (1 + (impuesto.Porcentaje / 100m));
                        detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                        decimal descuento = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(importe * (remision.PorcentajeDescuento / 100));
                        // decimal importeSIva = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((importe - descuento) / (1 + (impuesto.Porcentaje / 100m)));
                        decimal ImpAntesIva = importe / (1 + (impuesto.Porcentaje / 100m));

                        ImpAntesIva = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(ImpAntesIva);

                        decimal calculaImpuesto = importe - ImpAntesIva;
                        //detalle.IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(calculaImpuesto);
                        detalle.IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((importe - descuento) / (1 + (impuesto.Porcentaje / 100m))) * (impuesto.Porcentaje / 100m));

                        //detalle.Total = (detalle.Precio * detalle.CantidadRemision)// - detalle.MontoDescuento; AVM 23-04-2015 (CANCELA MODIFICACION)
                    }
                    else
                    {
                       MessageBox.Show("No se ha especificado el tipo de impuesto para el artículo " + detalle.ArticuloID + " [" + detalle.Nombre1 + "]");
                    }
                }

                //SIFModelo.Descuento descuento = 
                /// AVM 17-04-2015 SE CALCULA EL TOTAL DE MANERA DIFERENTE
                detalle.Total = importe;
            }
        }
        public bool InsertaFolioRemision(int sucursalId, int numRemision)
        {
            string prefijo = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yy");
            return SIFDatos.Remision.InsertaFolioRemision(sucursalId, prefijo, numRemision);
        }

        public bool Cancela(SIFModelo.Remision remision, int usuarioid, String nombreUsuario, bool pagada = false, bool descontar = true, bool esDevolucion = false)
        {
            remision.Activo = SIFModelo.Tipos.StatusVenta.CANCELADA;
            if (esDevolucion)
            {
                remision.Activo = SIFModelo.Tipos.StatusVenta.DEVUELTA;
            }

            List<SIFModelo.RemisionDetalle> detalles = CargaRemisionDetalles(remision);
            SIFNegocio.ClienteSubrogacion ClienteSubl = new ClienteSubrogacion();
            SIFModelo.ClienteSubrogaccion ClienteSub = ClienteSubl.ClientePorID(remision.ClienteID);
           
            bool actualizado = SIFDatos.Remision.CancelaRemision(remision,usuarioid, nombreUsuario);

            if (!esDevolucion)
            {

                foreach (SIFModelo.RemisionDetalle detalle in detalles)
                {

                    SIFModelo.Articulo articulo = null;
                    //    //if (ClienteSub == null)
                    //    articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
                    //    //else
                    //    //    if (ClienteSub.PRECIO_FIJO == SIFModelo.Tipos.SiNo.SI)
                    //    //    {
                    //    //        articulo = new SIFNegocio.Articulo().BuscarPorClaveSub(detalle.CODIGO_CLI, ClienteSub.ID.ToString());
                    //    //        //articulo.ARTICULO_ID = articulo.CODIGO_CLI;
                    //    //    }
                    //    //    else
                    //articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);


                    //    //if (pagada)
                    //    //{
                    //    //    if (descontar)
                    //    //    {
                    //    //        inventario.InventarioArticuloAumenta(articulo, detalle.CantidadRemision, remision.NumeroRemision, 15, short.Parse(detalle.NumeroPartida.ToString()), remision.VendedorID.ToString());
                    //    //    }
                    //    //}
                    //    //else
                    //    //{
                    //    //    inventario.InventarioArticuloApartaCancela(articulo, detalle.CantidadRemision);
                    //    //}
                    //}


                    if (actualizado)
                    {
                        SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();

                        //    foreach (SIFModelo.RemisionDetalle detalle in detalles)
                        //    {
                        //        //SIFNegocio.ClienteSubrogacion ClienteSubl = new ClienteSubrogacion();
                        //        //SIFModelo.ClienteSubrogaccion ClienteSub =ClienteSubl.ClientePorID(remision.ClienteID);
                        //        SIFModelo.Articulo articulo = null;
                        //        //if (ClienteSub == null)
                        //        articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
                        //        //else
                        //        //    if (ClienteSub.PRECIO_FIJO == SIFModelo.Tipos.SiNo.SI)
                        //        //    {
                        //        //articulo = new SIFNegocio.Articulo().BuscarPorClaveSub(detalle.ArticuloID, ClienteSub.ID.ToString());
                        //        //articulo.ARTICULO_ID = articulo.CODIGO_CLI;
                        //        //}
                        //        //else
                        articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);


                        //if (!esDevolucion)
                        //{
                        //    if (descontar)
                        //    {
                        //        inventario.InventarioArticuloAumenta(articulo, detalle.CantidadRemision, remision.NumeroRemision, 15, short.Parse(detalle.NumeroPartida.ToString()), remision.VendedorID.ToString());
                        //    }
                        //}
                        //        //else
                        //        //{
                        inventario.InventarioArticuloApartaCancela(articulo, detalle.CantidadRemision);
                        //        //}
                    }
                }
            }
            return actualizado;
            //}
            //return false;
            //return SIFDatos.Remision.Cancela(remision);
        }

        public void CancelaPedidosyApartados24HRS(SIFModelo.Sucursal sucursal)
        {
            foreach (SIFModelo.Remision remision in SIFDatos.Remision.RemisionesPendientes24hrs(sucursal))
            {
                SIFDatos.Remision.Cancela(remision);
            }
        }

        public static void ImprimeTicketNADRO(SIFModelo.Remision remision, List<SIFModelo.RemisionDetalle> detalles, SIFModelo.Sucursal sucursal, SIFModelo.Usuario vendedor, SIFModelo.Cliente cliente, SIFModelo.WebServices.TarjetaNadro nadro = null)
        {
            Helpers.Ticket Ticket = new Helpers.Ticket();

            if (nadro != null)
            {
                Ticket.ConDescuentos = true;
            }

            Ticket.AddHeaderLine("FARMACIAS FLEMING");
            Ticket.AddHeaderLine(" ");
            Ticket.AddHeaderLine("OPERADOR DE FARMACIAS A.F.");
            Ticket.AddHeaderLine("DEL CENTRO S. DE R.L. DE C.V.");
            Ticket.AddHeaderLine("R.F.C.: " + SIFNegocio.Configuracion.Configuraciones.Factura.UsuarioFEL);

            Ticket.AddSubHeaderLine(" ");

            Ticket.AddSubHeaderLine(sucursal.Calle + " " + sucursal.NumeroExterior + " " + sucursal.Colonia);
            Ticket.AddSubHeaderLine(sucursal.Ciudad + " " + sucursal.Municipio + " C.P." + sucursal.CodigoPostal);
            Ticket.AddSubHeaderLine("TEL: " + sucursal.Telefono + " FAX:");
            Ticket.AddSubHeaderLine("SUCURSAL: " + sucursal.Nombre);
            Ticket.AddSubHeaderLine("NOTA:" + remision.NumeroRemision);
            Ticket.AddSubHeaderLine("FECHA:" + remision.FechaVenta.ToString("dd/MM/yyyy HH:mm:ss"));
            Ticket.AddSubHeaderLine("ATENDIO:" + vendedor.Nombre + " " + vendedor.Apellidos);

            Ticket.AddSubHeaderLine("RECETA:" + remision.Receta + " FACTURA:" + remision.Factura);

            decimal subTotal = 0;
            foreach (SIFModelo.RemisionDetalle detalle in detalles)
            {
                subTotal += detalle.Precio * detalle.CantidadRemision;

                if (detalle.CantidadRemision == 0)
                {
                    continue;
                }

                if (detalle.PrecioDescontado == 0)
                {
                    detalle.PrecioDescontado = detalle.Precio - (detalle.Precio * (detalle.PorcentajeDescuento) / 100);

                    if (detalle.MontoDescuento > 0)
                    {
                        detalle.PrecioDescontado -= detalle.MontoDescuento;
                    }
                }

                if (detalle.IVA > 0)
                {
                    detalle.Nombre1 = "* " + detalle.Nombre1;
                }
              

                //if (detalle.PiezasPagadas > 0)
                //{
                //    detalle.CantidadRemision = detalle.PiezasPagadas;
                //}
                
                //detalle.Total = detalle.PrecioDescontado * detalle.CantidadRemision;

                decimal totalSinDescuento = detalle.Precio * detalle.CantidadRemision;
                decimal importeDescontado = detalle.PrecioDescontado * detalle.CantidadRemision;
                decimal descuentoGeneral = totalSinDescuento - importeDescontado;

                if (totalSinDescuento < 0)
                {
                    totalSinDescuento = 0;

                }
                if (importeDescontado < 0)
                {
                    importeDescontado = 0;
                }

                if (descuentoGeneral < 0)
                {
                    descuentoGeneral = 0;
                }

                if (nadro == null)
                {
                    if (detalle.PiezasPagadas > 0)
                    {
                        detalle.CantidadRemision = detalle.PiezasPagadas;
                    }
                    Ticket.AddItem(detalle.CantidadRemision.ToString(), detalle.ArticuloID, detalle.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1);
                }
                else
                {
                    string detalleDescuento = "0";
                    if (detalle.PorcentajeDescuento > 0)
                    {
                        detalleDescuento = detalle.PorcentajeDescuento.ToString("0.00") + "%";
                    }
                    else
                    {
                        if (detalle.MontoDescuento > 0)
                        {
                            detalleDescuento = detalle.MontoDescuento.ToString("C2");
                        }
                    }
                    Ticket.AddItem(detalle.CantidadRemision.ToString(), detalle.ArticuloID, detalle.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1, detalleDescuento, detalle.PrecioDescontado.ToString("C2"), descuentoGeneral.ToString("C2"));
                }

                if (!string.IsNullOrEmpty(detalle.Lote) && detalle.Lote != "0")
                {
                    Ticket.AddItem("", "LOTE:" + detalle.Lote, detalle.Caducidad.Value.ToString("dd/MM/yyy"), "CAD", "");
                }

            }

            //Imprimimos el total de piezas que vienen en el ticket
            Ticket.AddItem(remision.TotalArticulosRemision.ToString()," "," ", " "," ", " ", " ", " ");

            Ticket.AddTotal("SUBTOTAL:", subTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            if (nadro != null)
            {
                Ticket.AddTotal("DSCTO. C.S.:", remision.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            }
            else
            {
                Ticket.AddTotal("DESCUENTO:", remision.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            }
            //Ticket.AddTotal("I.V.A.", remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            Ticket.AddTotal("TOTAL", remision.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));

            if (nadro != null)
            {
                Ticket.AddFooterLine("BENEFICIO C.S. CIRCULO DE LA SALUD");
                if (!string.IsNullOrEmpty(nadro.NumeroConfirmacion) && nadro.NumeroConfirmacion != "0")
                {
                    Ticket.AddFooterLine("NO. CONFIRMACION: " + nadro.NumeroConfirmacion);
                }
                Ticket.AddFooterLine("SESION: " + nadro.SesionID);
                Ticket.AddFooterLine("TARJETA: " + nadro.NumeroTarjeta);
            }


            if (remision.Impuesto > 0)
            {
                Ticket.AddFooterLine("I.V.A. INFORMATIVO: " + remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                Ticket.AddFooterLine(" ");
            }

            //LGS 10/02/2014 Para que imprima en el ticket el tipo de descuento aplicado {INSEN,LOGO,...}
            if (remision.Condiciones != "NADRO" && remision.Condiciones != "PFIZER" && remision.Condiciones != "TAE" && remision.Condiciones != " " && remision.Condiciones.Length > 0)
            {
                Ticket.AddFooterLine("Beneficio " + remision.Condiciones + "%");
                Ticket.AddFooterLine(" ");
            }
            Ticket.AddFooterLine("SERVICIO A DOMICILIO SIN COSTO");
            Ticket.AddFooterLine("CORREO ELECTRONICO");


            //Ticket.AddFooterLine(remision.ImporteLetra);
            //Ticket.AddFooterLine(remision.formadepago);
            //Ticket.AddFooterLine("CLIENTE:" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
            Ticket.AddFooterLine(" ");
            Ticket.AddFooterLine("______________________________");
            Ticket.AddFooterLine("100% CONCENTRADOS EN SU SALUD");
            Ticket.AddFooterLine("NO HAY CAMBIOS NI DEVOLUCIONES");

            string impresora = SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets;

            if (!Ticket.PrinterExists(SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets))
            {
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    impresora = pd.PrinterSettings.PrinterName;
                }
                else
                {
                    return;
                }
            }

            Ticket.PrintTicket(impresora);
        }
        public static void RImprimeTicket(SIFModelo.Remision remision, List<SIFModelo.RemisionDetalle> detalles, SIFModelo.Sucursal sucursal, SIFModelo.Usuario vendedor, SIFModelo.Cliente cliente, SIFModelo.WebServices.TarjetaNadro nadro = null)
        {
           try
            {
                Helpers.Ticket Ticket = new Helpers.Ticket();

                if (nadro != null)
                {
                    ImprimeTicketNADRO(remision, detalles, sucursal, vendedor, cliente, nadro);
                    return;
                    Ticket.ConDescuentos = true;
                }

                SIFNegocio.Remision remisionN = new SIFNegocio.Remision();

                remision = remisionN.RemisionPorID(remision.NumeroRemision, remision.SucursalID);
                detalles = remisionN.CargaRemisionDetalles(remision);

                SIFModelo.Valesubrogacion vale = new SIFModelo.Valesubrogacion();
                vale.NoRemision = remision.NumeroRemision;
                SIFNegocio.ValeSubrogacion ValeL = new SIFNegocio.ValeSubrogacion();
                vale = ValeL.ValePorNumRemision(vale);
                //buscarcliente hup
                SIFNegocio.clienteHUP hup = new SIFNegocio.clienteHUP();
                SIFModelo.cliente_Hup hup2 = new SIFModelo.cliente_Hup();
                SIFModelo.hupDReceta recetaticket = new SIFModelo.hupDReceta();
                SIFModelo.hupDReceta recetaticket2 = new SIFModelo.hupDReceta();
                SIFModelo.hupMed medticket = new SIFModelo.hupMed();
                SIFModelo.hupBnf bnfticket = new SIFModelo.hupBnf();
                SIFModelo.hupEmp empticket = new SIFModelo.hupEmp();
                hup2 =  hup.Buscar(remision.ClienteID.ToString());
                
                if (hup2 != null)
                {
                    ///buscar receta
                    //SIFModelo.hupDReceta recetaticket = new SIFModelo.hupDReceta();
                   // recetaticket.Num_remision = remision.NumeroRemision;
                    SIFNegocio.ListDerechohabientes brecetat = new SIFNegocio.ListDerechohabientes();
                    recetaticket = brecetat.BuscarRecet(remision.NumeroRemision);
                    //buscar bnf
                    // SIFModelo.hupBnf bnfticket = new SIFModelo.hupBnf();
                    bnfticket.IDBnf = recetaticket.Id_pac;
                    SIFNegocio.ListDerechohabientes bbnf = new SIFNegocio.ListDerechohabientes();
                    bnfticket = bbnf.BuscarB(bnfticket.IDBnf);
                    //buscar med
                    // SIFModelo.hupMed medticket = new SIFModelo.hupMed();
                    medticket.IDmed = recetaticket.Id_med;
                    SIFNegocio.ListDerechohabientes bmed = new SIFNegocio.ListDerechohabientes();
                    medticket = bmed.BuscarM(medticket.IDmed);
                    //buscsar empleado
                    //SIFModelo.hupEmp empticket = new SIFModelo.hupEmp();
                    empticket.ID = bnfticket.IDEmp;
                    SIFNegocio.ListDerechohabientes bemp = new SIFNegocio.ListDerechohabientes();
                    empticket = bemp.Buscarempleado(bnfticket.IDEmp);
                }
                /*MessageBox.Show(hup.ToString() + "|" + hup2.cliente_id.ToString());
                MessageBox.Show(recetaticket.Num_remision);
                MessageBox.Show(bnfticket.IDBnf.ToString());
                MessageBox.Show(medticket.IDmed.ToString());
                MessageBox.Show(empticket.ID.ToString());
                MessageBox.Show(vendedor.Nombre.ToString());
                MessageBox.Show((empticket.ID.ToString() + " - " + empticket.Nombre.ToString()));
                MessageBox.Show(bnfticket.IDBnf.ToString() + " - " + bnfticket.Nombre.ToString());
                MessageBox.Show(medticket.IDmed.ToString() + " - " + medticket.Nombre.ToString());*/
                Ticket.AddHeaderLine("FARMACIAS FLEMING");
                Ticket.AddHeaderLine(" ");
                Ticket.AddHeaderLine("OPERADOR DE FARMACIAS A.F.");
                Ticket.AddHeaderLine("DEL CENTRO S. DE R.L. DE C.V.");
                //LGS 10/02/2014 Para que se muestre correctamente el RFC en el ticket
                //Ticket.AddHeaderLine("R.F.C.: " + SIFNegocio.Configuracion.Configuraciones.Factura.RFCEmisor);
                Ticket.AddHeaderLine("R.F.C.: " + SIFNegocio.Configuracion.Configuraciones.Factura.UsuarioFEL);
                Ticket.AddSubHeaderLine(" ");

                Ticket.AddSubHeaderLine(sucursal.Calle + " " + sucursal.NumeroExterior + " " + sucursal.Colonia);
                Ticket.AddSubHeaderLine(sucursal.Ciudad + " " + sucursal.Municipio + " C.P." + sucursal.CodigoPostal);
                Ticket.AddSubHeaderLine("TEL: " + sucursal.Telefono + " FAX:");
                Ticket.AddSubHeaderLine("SUCURSAL: " + sucursal.Nombre);
                Ticket.AddSubHeaderLine("NOTA:" + remision.NumeroRemision);
                Ticket.AddSubHeaderLine("FECHA:" + remision.FechaVenta.ToString("dd/MM/yyyy HH:mm:ss"));
                Ticket.AddSubHeaderLine("ATENDIO:" + vendedor.Nombre + " " + vendedor.Apellidos);

                Ticket.AddSubHeaderLine("RECETA:" + remision.Receta + " FACTURA:" + remision.Factura);
                if (remision.TipoCambio == 1)
                    Ticket.AddSubHeaderLine("CREDITO:SI");
                Ticket.AddSubHeaderLine("CLIENTE:" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
                Ticket.AddSubHeaderLine(" ");
                if (hup2 != null)
                {
                    Ticket.AddSubHeaderLine("Empleado: ");
                    Ticket.AddSubHeaderLine(empticket.ID.ToString() + " - " + empticket.Nombre.ToString());
                    Ticket.AddSubHeaderLine("Beneficiario: ");
                    Ticket.AddSubHeaderLine(bnfticket.IDBnf.ToString() + " - " + bnfticket.Nombre.ToString());
                    Ticket.AddSubHeaderLine("Medico: ");
                    Ticket.AddSubHeaderLine(medticket.IDmed.ToString() + " - " + medticket.Nombre.ToString());
                }
                else
                {
                }
                Ticket.AddSubHeaderLine("******** TICKET REIMPRESO ********");

                if (vale != null)
                {
                    Ticket.AddSubHeaderLine("VALE:" + vale.NoVale + " TIPO:" + vale.Tipo);
                }
                decimal subTotal = 0;
                foreach (SIFModelo.RemisionDetalle detalle in detalles)
                {
                    if (detalle.CantidadRemision > 0)
                    {
                        detalle.Total = detalle.PrecioDescontado * detalle.CantidadRemision;
                        subTotal += detalle.Precio * detalle.CantidadRemision;
                        decimal totalSinDescuento = detalle.Precio * detalle.CantidadRemision;
                        decimal importeDescontado = detalle.PrecioDescontado * detalle.CantidadRemision;
                        decimal descuentoGeneral = totalSinDescuento - importeDescontado;

                        if (cliente.ID == 90 || cliente.ID == 92)
                        {
                            // SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow sub = new SIFNegocio.Subrogacion.Articulos().GetArticuloID(detalle.ArticuloID, cliente.ID);
                            SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow sub = new SIFNegocio.Subrogacion.Articulos().GetArticuloSubID(detalle.CODIGO_CLI_ID.ToString(), cliente.ID);
                            SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
                            //SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow sub = new SIFNegocio.Subrogacion.Articulos().GetArticuloSubID(detalle.ArticuloID,detalle.CODIGO_CLI, cliente.ID);
                            if (sub != null)
                            {
                                detalle.Nombre1 = articulo.NOMBRE1 + " - " + sub.NOMBRE1;
                            }
                        }


                        if (totalSinDescuento < 0)
                        {
                            totalSinDescuento = 0;

                        }
                        if (importeDescontado < 0)
                        {
                            importeDescontado = 0;
                        }

                        if (descuentoGeneral < 0)
                        {
                            descuentoGeneral = 0;
                        }

                        if (detalle.IVA > 0)
                        {
                            detalle.Nombre1 = "* " + detalle.Nombre1;
                        }

                        if (nadro == null)
                        {
                            decimal detalleTotal = detalle.Precio * detalle.CantidadRemision;
                            Ticket.AddItem(detalle.CantidadRemision.ToString(), detalle.ArticuloID, detalleTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1);
                        }
                        else
                        {
                            string detalleDescuento = "0";
                            if (detalle.PorcentajeDescuento > 0)
                            {
                                detalleDescuento = detalle.PorcentajeDescuento.ToString("0.00") + "%";
                            }
                            else
                            {
                                if (detalle.MontoDescuento > 0)
                                {
                                    detalleDescuento = detalle.MontoDescuento.ToString("C2");
                                }
                            }
                            Ticket.AddItem(detalle.CantidadRemision.ToString(), detalle.ArticuloID, detalle.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1, detalleDescuento, detalle.PrecioDescontado.ToString("C2"), descuentoGeneral.ToString("C2"));
                        }

                        if (!string.IsNullOrEmpty(detalle.Lote) && detalle.Lote != "0")
                        {
                            Ticket.AddItem("", "LOTE:" + detalle.Lote, detalle.Caducidad.Value.ToString("dd/MM/yyy"), "CAD", "");
                        }
                    }
                }
                //LG 07/02/2014 14:01 Para que muestre el total de productos vendidos
                Ticket.AddItem(remision.TotalArticulosRemision.ToString(), "", "", "", "");

                Ticket.AddTotal("SUBTOTAL:", (subTotal).ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                if (nadro != null)
                {
                    Ticket.AddTotal("DSCTO. C.S.:", remision.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                }
                else
                {
                    if (remision.Descuento > 0)
                    {
                        Ticket.AddTotal("DESCUENTO:", remision.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                    }
                }

                Ticket.AddTotal("TOTAL", remision.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));

                if (remision.Impuesto > 0)
                {
                    Ticket.AddFooterLine("I.V.A. INFORMATIVO: " + remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                    Ticket.AddFooterLine(" ");
                }

                //LGS 10/02/2014 Para que imprima en el ticket el tipo de descuento aplicado {INSEN,LOGO,...}
                if (remision.Condiciones != "NADRO" && remision.Condiciones != "PFIZER" && remision.Condiciones != "TAE" && remision.Condiciones != " " && remision.Condiciones.Length > 0)
                {
                    Ticket.AddFooterLine("Beneficio " + remision.Condiciones + "%");
                    Ticket.AddFooterLine(" ");
                }

                if (nadro != null)
                {
                    Ticket.AddFooterLine("BENEFICIO C.S. CIRCULO DE LA SALUD");
                    if (!string.IsNullOrEmpty(nadro.NumeroConfirmacion) && nadro.NumeroConfirmacion != "0")
                    {
                        Ticket.AddFooterLine("NO. CONFIRMACION: " + nadro.NumeroConfirmacion);
                    }
                    Ticket.AddFooterLine("SESION: " + nadro.SesionID);
                    Ticket.AddFooterLine("TARJETA: " + nadro.NumeroTarjeta);
                }

                Ticket.AddFooterLine("SERVICIO A DOMICILIO SIN COSTO");
                Ticket.AddFooterLine("CORREO ELECTRONICO");


                //Ticket.AddFooterLine(remision.ImporteLetra);
                //Ticket.AddFooterLine(remision.formadepago);
                //Ticket.AddFooterLine("CLIENTE:" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
                if (hup2 != null)
                {
                    Ticket.AddFooterLine(" ");
                    Ticket.AddFooterLine(" ");
                    Ticket.AddFooterLine(" ");
                    Ticket.AddFooterLine(" ");
                    Ticket.AddFooterLine(" ");
                    Ticket.AddFooterLine(" ");
                    Ticket.AddFooterLine(" ");
                    Ticket.AddFooterLine(" ");
                    Ticket.AddFooterLine(" ");
                    Ticket.AddFooterLine("__________________________________");
                    Ticket.AddFooterLine("NOMBRE Y FIRMA DEL DERECHOHABIENTE");
                    Ticket.AddFooterLine(" ");
                    Ticket.AddFooterLine("100% CONCENTRADOS EN SU SALUD");
                    Ticket.AddFooterLine("NO HAY CAMBIOS NI DEVOLUCIONES");
                }
                else
                {
                    Ticket.AddFooterLine(" ");
                    Ticket.AddFooterLine("______________________________");
                    Ticket.AddFooterLine("100% CONCENTRADOS EN SU SALUD");
                    Ticket.AddFooterLine("NO HAY CAMBIOS NI DEVOLUCIONES");
                }

                string impresora = SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets;

                if (!Ticket.PrinterExists(SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets))
                {
                    PrintDialog pd = new PrintDialog();
                    if (pd.ShowDialog() == DialogResult.OK)
                    {
                        impresora = pd.PrinterSettings.PrinterName;
                    }
                    else
                    {
                        return;
                    }
                }


                Ticket.PrintTicket(impresora);
            }
            catch (Exception ex)
                        {
                           MessageBox.Show("Error:" + ex.Message);
                            //return null;
                        }
        }
        public static void ImprimeTicket(SIFModelo.Remision remision, List<SIFModelo.RemisionDetalle> detalles, SIFModelo.Sucursal sucursal, SIFModelo.Usuario vendedor, SIFModelo.Cliente cliente, SIFModelo.WebServices.TarjetaNadro nadro = null)
        {
            Helpers.Ticket Ticket = new Helpers.Ticket();

            if (nadro != null)
            {
                ImprimeTicketNADRO(remision, detalles, sucursal, vendedor, cliente, nadro);
                return;
                Ticket.ConDescuentos = true;
            }

            SIFNegocio.Remision remisionN = new SIFNegocio.Remision();

            remision = remisionN.RemisionPorID(remision.NumeroRemision, remision.SucursalID);
            detalles = remisionN.CargaRemisionDetalles(remision);

            SIFModelo.Valesubrogacion vale = new SIFModelo.Valesubrogacion();
            vale.NoRemision = remision.NumeroRemision;
            SIFNegocio.ValeSubrogacion ValeL = new SIFNegocio.ValeSubrogacion();
            vale = ValeL.ValePorNumRemision(vale);
            //buscarcliente hup
            SIFNegocio.clienteHUP hup = new SIFNegocio.clienteHUP();
            SIFModelo.cliente_Hup hup2 = new SIFModelo.cliente_Hup();
            SIFModelo.hupDReceta recetaticket = new SIFModelo.hupDReceta();
            SIFModelo.hupMed medticket = new SIFModelo.hupMed();
             SIFModelo.hupBnf bnfticket = new SIFModelo.hupBnf();
            SIFModelo.hupEmp empticket = new SIFModelo.hupEmp();
            hup2 = hup.Buscar(remision.ClienteID.ToString());
            if (hup2 != null)
            {
                ///buscar receta
                //SIFModelo.hupDReceta recetaticket = new SIFModelo.hupDReceta();
               // recetaticket.Num_remision = remision.NumeroRemision;
                SIFNegocio.ListDerechohabientes brecetat = new SIFNegocio.ListDerechohabientes();
                recetaticket = brecetat.BuscarRecet(remision.NumeroRemision);
                //buscar bnf
                // SIFModelo.hupBnf bnfticket = new SIFModelo.hupBnf();
                bnfticket.IDBnf = recetaticket.Id_pac;
                SIFNegocio.ListDerechohabientes bbnf = new SIFNegocio.ListDerechohabientes();
                bnfticket = bbnf.BuscarB(bnfticket.IDBnf);
                //buscar med
                // SIFModelo.hupMed medticket = new SIFModelo.hupMed();
                medticket.IDmed = recetaticket.Id_med;
                SIFNegocio.ListDerechohabientes bmed = new SIFNegocio.ListDerechohabientes();
                medticket = bmed.BuscarM(medticket.IDmed);
                //buscsar empleado
                //SIFModelo.hupEmp empticket = new SIFModelo.hupEmp();
                empticket.ID = bnfticket.IDEmp;
                SIFNegocio.ListDerechohabientes bemp = new SIFNegocio.ListDerechohabientes();
                empticket = bemp.Buscarempleado(bnfticket.IDEmp);
            }
            else
            { 
            }

            Ticket.AddHeaderLine("FARMACIAS FLEMING");
            Ticket.AddHeaderLine(" ");
            Ticket.AddHeaderLine("OPERADOR DE FARMACIAS A.F.");
            Ticket.AddHeaderLine("DEL CENTRO S. DE R.L. DE C.V.");
            //LGS 10/02/2014 Para que se muestre correctamente el RFC en el ticket
            //Ticket.AddHeaderLine("R.F.C.: " + SIFNegocio.Configuracion.Configuraciones.Factura.RFCEmisor);
            Ticket.AddHeaderLine("R.F.C.: " + SIFNegocio.Configuracion.Configuraciones.Factura.UsuarioFEL);
            Ticket.AddSubHeaderLine(" ");

            Ticket.AddSubHeaderLine(sucursal.Calle + " " + sucursal.NumeroExterior + " " + sucursal.Colonia);
            Ticket.AddSubHeaderLine(sucursal.Ciudad + " " + sucursal.Municipio + " C.P." + sucursal.CodigoPostal);
            Ticket.AddSubHeaderLine("TEL: " + sucursal.Telefono + " FAX:");
            Ticket.AddSubHeaderLine("SUCURSAL: " + sucursal.Nombre);
            Ticket.AddSubHeaderLine("NOTA:" + remision.NumeroRemision);
            Ticket.AddSubHeaderLine("FECHA:" + remision.FechaVenta.ToString("dd/MM/yyyy HH:mm:ss"));
            Ticket.AddSubHeaderLine("ATENDIO:" + vendedor.Nombre + " " + vendedor.Apellidos);

            Ticket.AddSubHeaderLine("RECETA:" + remision.Receta + " FACTURA:" + remision.Factura);
            if (remision.TipoCambio == 1)
                Ticket.AddSubHeaderLine("CREDITO:SI");
            Ticket.AddSubHeaderLine("CLIENTE:" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
            if (hup2 != null)
            {
                Ticket.AddSubHeaderLine("Empleado: ");
                Ticket.AddSubHeaderLine(empticket.ID.ToString() + " - " + empticket.Nombre.ToString());
                Ticket.AddSubHeaderLine("Beneficiario: ");
                Ticket.AddSubHeaderLine(bnfticket.IDBnf.ToString() + " - " + bnfticket.Nombre.ToString());
                Ticket.AddSubHeaderLine("Medico: ");
                Ticket.AddSubHeaderLine(medticket.IDmed.ToString() + " - " + medticket.Nombre.ToString());
            }
            else
            {
            }
            if (vale != null)
            {
                Ticket.AddSubHeaderLine("VALE:" + vale.NoVale + " TIPO:" + vale.Tipo);
            }
            decimal subTotal = 0;
            foreach (SIFModelo.RemisionDetalle detalle in detalles)
            {
                if (detalle.CantidadRemision > 0)
                {
                    detalle.Total = detalle.PrecioDescontado * detalle.CantidadRemision;
                    subTotal += detalle.Precio * detalle.CantidadRemision;
                    decimal totalSinDescuento = detalle.Precio * detalle.CantidadRemision;
                    decimal importeDescontado = detalle.PrecioDescontado * detalle.CantidadRemision;
                    decimal descuentoGeneral = totalSinDescuento - importeDescontado;

                    if (cliente.ID == 90 || cliente.ID == 92)
                    {
                        // SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow sub = new SIFNegocio.Subrogacion.Articulos().GetArticuloID(detalle.ArticuloID, cliente.ID);
                        SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow sub = new SIFNegocio.Subrogacion.Articulos().GetArticuloSubID(detalle.CODIGO_CLI_ID.ToString(), cliente.ID);
                        SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
                        //SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow sub = new SIFNegocio.Subrogacion.Articulos().GetArticuloSubID(detalle.ArticuloID,detalle.CODIGO_CLI, cliente.ID);
                        if (sub != null)
                        {
                            detalle.Nombre1 = articulo.NOMBRE1 + " - " + sub.NOMBRE1;
                        }
                    }


                    if (totalSinDescuento < 0)
                    {
                        totalSinDescuento = 0;

                    }
                    if (importeDescontado < 0)
                    {
                        importeDescontado = 0;
                    }

                    if (descuentoGeneral < 0)
                    {
                        descuentoGeneral = 0;
                    }

                    if (detalle.IVA > 0)
                    {
                        detalle.Nombre1 = "* " + detalle.Nombre1;
                    }

                    if (nadro == null)
                    {
                        decimal detalleTotal = detalle.Precio * detalle.CantidadRemision;
                        Ticket.AddItem(detalle.CantidadRemision.ToString(), detalle.ArticuloID, detalleTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1);
                    }
                    else
                    {
                        string detalleDescuento = "0";
                        if (detalle.PorcentajeDescuento > 0)
                        {
                            detalleDescuento = detalle.PorcentajeDescuento.ToString("0.00") + "%";
                        }
                        else
                        {
                            if (detalle.MontoDescuento > 0)
                            {
                                detalleDescuento = detalle.MontoDescuento.ToString("C2");
                            }
                        }
                        Ticket.AddItem(detalle.CantidadRemision.ToString(), detalle.ArticuloID, detalle.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1, detalleDescuento, detalle.PrecioDescontado.ToString("C2"), descuentoGeneral.ToString("C2"));
                    }

                    if (!string.IsNullOrEmpty(detalle.Lote) && detalle.Lote != "0")
                    {
                        Ticket.AddItem("", "LOTE:" + detalle.Lote, detalle.Caducidad.Value.ToString("dd/MM/yyy"), "CAD", "");
                    }                  
                }
            }
            //LG 07/02/2014 14:01 Para que muestre el total de productos vendidos
            Ticket.AddItem(remision.TotalArticulosRemision.ToString(), "", "", "", "");

            Ticket.AddTotal("SUBTOTAL:", subTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            if (nadro != null)
            {
                Ticket.AddTotal("DSCTO. C.S.:", remision.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            }
            else
            {
                if (remision.Descuento > 0)
                {
                    Ticket.AddTotal("DESCUENTO:", remision.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                }
            }
            
            Ticket.AddTotal("TOTAL", remision.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));

            if (remision.Impuesto > 0)
            {
                Ticket.AddFooterLine("I.V.A. INFORMATIVO: " + remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                Ticket.AddFooterLine(" ");
            }
            
            //LGS 10/02/2014 Para que imprima en el ticket el tipo de descuento aplicado {INSEN,LOGO,...}
            if (remision.Condiciones != "NADRO" && remision.Condiciones != "PFIZER" && remision.Condiciones != "TAE" && remision.Condiciones != " " && remision.Condiciones.Length > 0)
            {
                Ticket.AddFooterLine("Beneficio " + remision.Condiciones + "%");
                Ticket.AddFooterLine(" ");
            }

            if (nadro != null)
            {
                Ticket.AddFooterLine("BENEFICIO C.S. CIRCULO DE LA SALUD");
                if (!string.IsNullOrEmpty(nadro.NumeroConfirmacion) && nadro.NumeroConfirmacion != "0")
                {
                    Ticket.AddFooterLine("NO. CONFIRMACION: " + nadro.NumeroConfirmacion);
                }
                Ticket.AddFooterLine("SESION: " + nadro.SesionID);
                Ticket.AddFooterLine("TARJETA: " + nadro.NumeroTarjeta);
            }

            Ticket.AddFooterLine("SERVICIO A DOMICILIO SIN COSTO");
            Ticket.AddFooterLine("CORREO ELECTRONICO");


            //Ticket.AddFooterLine(remision.ImporteLetra);
            //Ticket.AddFooterLine(remision.formadepago);
            //Ticket.AddFooterLine("CLIENTE:" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
            if (hup2 != null)
            {
                Ticket.AddFooterLine(" ");
                Ticket.AddFooterLine(" ");
                Ticket.AddFooterLine(" ");
                Ticket.AddFooterLine(" ");
                Ticket.AddFooterLine(" ");
                Ticket.AddFooterLine(" ");
                Ticket.AddFooterLine(" ");
                Ticket.AddFooterLine(" ");
                Ticket.AddFooterLine(" ");
                Ticket.AddFooterLine("__________________________________");
                Ticket.AddFooterLine("NOMBRE Y FIRMA DEL DERECHOHABIENTE");
                Ticket.AddFooterLine(" ");
                Ticket.AddFooterLine("100% CONCENTRADOS EN SU SALUD");
                Ticket.AddFooterLine("NO HAY CAMBIOS NI DEVOLUCIONES");
            }
            else
            {
                Ticket.AddFooterLine(" ");
                Ticket.AddFooterLine("______________________________");
                Ticket.AddFooterLine("100% CONCENTRADOS EN SU SALUD");
                Ticket.AddFooterLine("NO HAY CAMBIOS NI DEVOLUCIONES");
            }
            string impresora = SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets;

            if (!Ticket.PrinterExists(SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets))
            {
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    impresora = pd.PrinterSettings.PrinterName;
                }
                else
                {
                    return;
                }
            }


            Ticket.PrintTicket(impresora);
        }
        public static void RImprimeTicketDevolucion(SIFModelo.Remision remision, SIFModelo.Devolucion devolucion, List<SIFModelo.DevolucionDetalle> detalles, SIFModelo.Sucursal sucursal, SIFModelo.Usuario vendedor, SIFModelo.Cliente cliente)
        {
            Helpers.Ticket Ticket = new Helpers.Ticket();

            Ticket.AddHeaderLine("FARMACIAS FLEMING");
            Ticket.AddHeaderLine(" ");
            Ticket.AddHeaderLine("OPERADOR DE FARMACIAS A.F.");
            Ticket.AddHeaderLine("DEL CENTRO S. DE R.L. DE C.V.");
            Ticket.AddHeaderLine("R.F.C.: " + SIFNegocio.Configuracion.Configuraciones.Factura.UsuarioFEL);

            Ticket.AddSubHeaderLine(sucursal.Calle + " " + sucursal.NumeroExterior + " " + sucursal.Colonia);
            Ticket.AddSubHeaderLine(sucursal.Ciudad + " " + sucursal.Municipio + " C.P." + sucursal.CodigoPostal);
            Ticket.AddSubHeaderLine("TEL:FAX: " + sucursal.Telefono);
            Ticket.AddSubHeaderLine("SUCURSAL: " + sucursal.Nombre);

            Ticket.AddSubHeaderLine(" ");
            Ticket.AddSubHeaderLine("     *** VALE DE DEVOLUCION ***");
            Ticket.AddSubHeaderLine(" ");
            Ticket.AddSubHeaderLine("     ***** VALE REIMPRESO *****");
            Ticket.AddSubHeaderLine(" ");
            Ticket.AddSubHeaderLine("FECHA " + devolucion.FechaDevolucion.ToString("dd/MMM/yyyy  HH:mm:ss").ToUpper());
            Ticket.AddSubHeaderLine("FOLIO: " + devolucion.DevolucionID + " REFERENCIA: " + remision.NumeroRemision);
            Ticket.AddSubHeaderLine("VALIDO HASTA EL DIA " + devolucion.FechaDevolucion.AddDays(7).ToString("dddd dd/MMM/yyyy HH:mm:ss").ToUpper());

            //Ticket.AddSubHeaderLine("RECETA:" + remision.Receta + " FACTURA:" + remision.Factura);

            decimal totalDevolver = 0;
            decimal descuentoTotal = 0;
            decimal subTotal = 0;
            foreach (SIFModelo.DevolucionDetalle detalle in devolucion.Detalles)
            {
                SIFModelo.Descuento descuento = new Descuentos().DescuentoPorID(detalle.Descuento);
                if (descuento == null)
                {
                    descuento = new SIFModelo.Descuento();
                }

                if (detalle.IVA > 0)
                {
                    detalle.Nombre1 = "* " + detalle.Nombre1;
                }

                subTotal += detalle.Precio * detalle.Cantidad;

                //decimal descuentoDetalle = (detalle.Precio * detalle.Cantidad) * (descuento.Porcentaje / 100);
                decimal importe = (detalle.Cantidad * detalle.Precio); //- descuentoDetalle;
                decimal importeSinDescuento = detalle.Cantidad * detalle.Precio;
                descuentoTotal += detalle.Descuento;

                totalDevolver += importe;
                Ticket.AddItem(detalle.Cantidad.ToString(), detalle.ArticuloID, importeSinDescuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1);
            }

            if (devolucion.Descuento > 0 && descuentoTotal == 0)
            {
                descuentoTotal = devolucion.Descuento;
            }

            Ticket.AddTotal("SUBTOTAL:", subTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));

            if (descuentoTotal > 0)
            {
                Ticket.AddTotal("DESCUENTO:", devolucion.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                //totalDevolver -= descuentoTotal;

            }



            Ticket.AddTotal("BUENO POR: ", devolucion.TotalDevolucion.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));

            string totalEscrito = sif_tools.NumberToLetters.NumToLetter((double)devolucion.TotalDevolucion, "double");

            if (devolucion.Impuesto > 0)
            {
                Ticket.AddFooterLine("I.V.A. INFORMATIVO: " + remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                Ticket.AddFooterLine(" ");
            }

            //LGS 10/02/2014 Para que imprima en el ticket el tipo de descuento aplicado {INSEN,LOGO,...}
            if (remision.Condiciones != "NADRO" && remision.Condiciones != "PFIZER" && remision.Condiciones != "TAE" && remision.Condiciones != " " && remision.Condiciones.Length > 0)
            {
                Ticket.AddFooterLine("Beneficio " + remision.Condiciones + "%");
                Ticket.AddFooterLine(" ");
            }
            Ticket.AddFooterLine(totalEscrito);
            //Ticket.AddFooterLine(remision.formadepago);
            //Ticket.AddFooterLine("NOTA:" + remision.NumeroRemision);
            //Ticket.AddFooterLine("FECHA:" + remision.FechaVenta.ToString("dd/MM/yyyy HH:mm:ss"));
            Ticket.AddFooterLine("AUTORIZA:" + vendedor.Nombre + " " + vendedor.Apellidos);
            //Ticket.AddFooterLine("CLIENTE:" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
            //Ticket.AddFooterLine("CONCENTRADOS 100% EN SU SALUD");
            Ticket.AddFooterLine("UUID:" + remision.NumeroFactura);
            string impresora = SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets;

            if (!Ticket.PrinterExists(SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets))
            {
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    impresora = pd.PrinterSettings.PrinterName;
                }
                else
                {
                    return;
                }
            }



            Ticket.PrintTicket(impresora);
        }
        public static void ImprimeTicketDevolucion(SIFModelo.Remision remision, SIFModelo.Devolucion devolucion, List<SIFModelo.DevolucionDetalle> detalles, SIFModelo.Sucursal sucursal, SIFModelo.Usuario vendedor, SIFModelo.Cliente cliente)
        {
            Helpers.Ticket Ticket = new Helpers.Ticket();

            Ticket.AddHeaderLine("FARMACIAS FLEMING");
            Ticket.AddHeaderLine(" ");
            Ticket.AddHeaderLine("OPERADOR DE FARMACIAS A.F.");
            Ticket.AddHeaderLine("DEL CENTRO S. DE R.L. DE C.V.");
            Ticket.AddHeaderLine("R.F.C.: " + SIFNegocio.Configuracion.Configuraciones.Factura.UsuarioFEL);

            Ticket.AddSubHeaderLine(sucursal.Calle + " " + sucursal.NumeroExterior + " " + sucursal.Colonia);
            Ticket.AddSubHeaderLine(sucursal.Ciudad + " " + sucursal.Municipio + " C.P." + sucursal.CodigoPostal);
            Ticket.AddSubHeaderLine("TEL:FAX: " + sucursal.Telefono);
            Ticket.AddSubHeaderLine("SUCURSAL: " + sucursal.Nombre);

            Ticket.AddSubHeaderLine(" ");
            Ticket.AddSubHeaderLine("     *** VALE DE DEVOLUCION ***");
            Ticket.AddSubHeaderLine(" ");
            Ticket.AddSubHeaderLine("FECHA " + devolucion.FechaDevolucion.ToString("dd/MMM/yyyy  HH:mm:ss").ToUpper());
            Ticket.AddSubHeaderLine("FOLIO: " + devolucion.DevolucionID + " REFERENCIA: " + remision.NumeroRemision);
            Ticket.AddSubHeaderLine("VALIDO HASTA EL DIA " + devolucion.FechaDevolucion.AddDays(7).ToString("dddd dd/MMM/yyyy HH:mm:ss").ToUpper());

            //Ticket.AddSubHeaderLine("RECETA:" + remision.Receta + " FACTURA:" + remision.Factura);

            decimal totalDevolver = 0;
            decimal descuentoTotal = 0;
            decimal subTotal = 0;
            foreach (SIFModelo.DevolucionDetalle detalle in devolucion.Detalles)
            {
                SIFModelo.Descuento descuento = new Descuentos().DescuentoPorID(detalle.Descuento);
                if (descuento == null)
                {
                    descuento = new SIFModelo.Descuento();
                }

                if (detalle.IVA > 0)
                {
                    detalle.Nombre1 = "* " + detalle.Nombre1;
                }

                subTotal += detalle.Precio * detalle.Cantidad;

                //decimal descuentoDetalle = (detalle.Precio * detalle.Cantidad) * (descuento.Porcentaje / 100);
                decimal importe = (detalle.Cantidad * detalle.Precio); //- descuentoDetalle;
                decimal importeSinDescuento = detalle.Cantidad * detalle.Precio;
                descuentoTotal += detalle.Descuento;

                totalDevolver += importe;
                Ticket.AddItem(detalle.Cantidad.ToString(), detalle.ArticuloID, importeSinDescuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1);
            }

            if (devolucion.Descuento > 0 && descuentoTotal == 0)
            {
                descuentoTotal = devolucion.Descuento;
            }

            Ticket.AddTotal("SUBTOTAL:", subTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));

            if (descuentoTotal > 0)
            {
                Ticket.AddTotal("DESCUENTO:", devolucion.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                //totalDevolver -= descuentoTotal;

            }



            Ticket.AddTotal("BUENO POR: ", devolucion.TotalDevolucion.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));

            string totalEscrito = sif_tools.NumberToLetters.NumToLetter((double)devolucion.TotalDevolucion, "double");

            if (devolucion.Impuesto > 0)
            {
                    Ticket.AddFooterLine("I.V.A. INFORMATIVO: " + remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                    Ticket.AddFooterLine(" ");
            }

            //LGS 10/02/2014 Para que imprima en el ticket el tipo de descuento aplicado {INSEN,LOGO,...}
            if (remision.Condiciones != "NADRO" && remision.Condiciones != "PFIZER" && remision.Condiciones != "TAE" && remision.Condiciones != " " && remision.Condiciones.Length > 0)
            {
                Ticket.AddFooterLine("Beneficio " + remision.Condiciones + "%");
                Ticket.AddFooterLine(" ");
            }
            Ticket.AddFooterLine(totalEscrito);
            //Ticket.AddFooterLine(remision.formadepago);
            //Ticket.AddFooterLine("NOTA:" + remision.NumeroRemision);
            //Ticket.AddFooterLine("FECHA:" + remision.FechaVenta.ToString("dd/MM/yyyy HH:mm:ss"));
            Ticket.AddFooterLine("AUTORIZA:" + vendedor.Nombre + " " + vendedor.Apellidos);
            //Ticket.AddFooterLine("CLIENTE:" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
            //Ticket.AddFooterLine("CONCENTRADOS 100% EN SU SALUD");
            Ticket.AddFooterLine("UUID:" + remision.NumeroFactura);
            string impresora = SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets;

            if (!Ticket.PrinterExists(SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets))
            {
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    impresora = pd.PrinterSettings.PrinterName;
                }
                else
                {
                    return;
                }
            }



            Ticket.PrintTicket(impresora);
        }

        public static void ImprimeTicketTAE(SIFModelo.Remision remision, List<SIFModelo.RemisionDetalle> detalles, SIFModelo.Sucursal sucursal, SIFModelo.Usuario vendedor, SIFModelo.Cliente cliente, SIFModelo.WebServices.TAE controlTAE, string mensajeRecarga)
        {
            Helpers.Ticket Ticket = new Helpers.Ticket();

            Ticket.AddHeaderLine("FARMACIAS FLEMING");
            Ticket.AddHeaderLine(" ");
            Ticket.AddHeaderLine("OPERADOR DE FARMACIAS A.F.");
            Ticket.AddHeaderLine("DEL CENTRO S. DE R.L. DE C.V.");
            Ticket.AddHeaderLine("R.F.C.: " + SIFNegocio.Configuracion.Configuraciones.Factura.UsuarioFEL);

            Ticket.AddSubHeaderLine(" ");

            Ticket.AddSubHeaderLine(sucursal.Calle + " " + sucursal.NumeroExterior + " " + sucursal.Colonia);
            Ticket.AddSubHeaderLine(sucursal.Ciudad + " " + sucursal.Municipio + " C.P." + sucursal.CodigoPostal);
            Ticket.AddSubHeaderLine("TEL: " + sucursal.Telefono + " FAX:");
            Ticket.AddSubHeaderLine("SUCURSAL: " + sucursal.Nombre);
            Ticket.AddSubHeaderLine("NOTA:" + remision.NumeroRemision);
            Ticket.AddSubHeaderLine("FECHA:" + remision.FechaVenta.ToString("dd/MM/yyyy HH:mm:ss"));
            Ticket.AddSubHeaderLine("ATENDIO:" + vendedor.Nombre + " " + vendedor.Apellidos);

            Ticket.AddSubHeaderLine("");
            Ticket.AddSubHeaderLine("NO. TRANSACCION: " + controlTAE.Remision);
            Ticket.AddSubHeaderLine("NO. AUTORIZACION: " + controlTAE.Referencia);
            Ticket.AddSubHeaderLine("MONTO: " + remision.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            Ticket.AddSubHeaderLine("TELEFONO: " + controlTAE.Telefono);
            Ticket.AddSubHeaderLine("");

            Ticket.AddSubHeaderLine("RECETA:" + remision.Receta + " FACTURA:" + remision.Factura);

            foreach (SIFModelo.RemisionDetalle detalle in detalles)
            {
                if (detalle.IVA > 0)
                {
                    detalle.Nombre1 = "* " + detalle.Nombre1;
                }

                detalle.Total = detalle.Precio * detalle.CantidadRemision;
                Ticket.AddItem(detalle.CantidadRemision.ToString(), detalle.ArticuloID, detalle.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1);
            }



            Ticket.AddTotal("SUBTOTAL", remision.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            Ticket.AddTotal("DESCUENTO", remision.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            //Ticket.AddTotal("I.V.A.", remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            Ticket.AddTotal("TOTAL", remision.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));


            //Ticket.AddFooterLine(" ");
            //Ticket.AddFooterLine("NO. REFERENCIA TAE: " + controlTAE.Referencia);
            Ticket.AddFooterLine(" ");

            string[] lineas = mensajeRecarga.Split('\n');
            foreach (string linea in lineas)
            {
                if (lineas.Count() >= 3)
                {
                    if (linea == lineas[2])
                    {
                        Ticket.AddFooterLine(" " + linea);
                        continue;
                    }
                }
                Ticket.AddFooterLine(linea);
            }

            if (remision.Impuesto > 0)
            {
                Ticket.AddFooterLine("I.V.A. INFORMATIVO: " + remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                Ticket.AddFooterLine(" ");
            }

            //LGS 10/02/2014 Para que imprima en el ticket el tipo de descuento aplicado {INSEN,LOGO,...}
            if (remision.Condiciones != "NADRO" && remision.Condiciones != "PFIZER" && remision.Condiciones != "TAE" && remision.Condiciones != " " && remision.Condiciones.Length > 0)
            {
                Ticket.AddFooterLine("Beneficio " + remision.Condiciones + "%");
                Ticket.AddFooterLine(" ");
            }
            Ticket.AddFooterLine(" ");
            if (controlTAE.Carrier == 1)
            {
                Ticket.AddFooterLine("ESTIMADO CLIENTE EN CASO DE");
                Ticket.AddFooterLine("PRESENTARSE ALGUN PROBLEMA");
                Ticket.AddFooterLine("CON SU TIEMPO AIRE FAVOR DE ");
                Ticket.AddFooterLine("COMUNICARSE A ATENCION A");
                Ticket.AddFooterLine("CLIENTES TELCEL *264 ");
                Ticket.AddFooterLine("DESDE SU TELCEL O ");
                Ticket.AddFooterLine("DESDE EL INTERIOR DE LA ");
                Ticket.AddFooterLine("REPUBLICA AL 01800-710-5687");
            }

            Ticket.AddFooterLine(" ");

            Ticket.AddFooterLine("FECHA-HORA DE LA TRANSACCIÓN: ");
            Ticket.AddFooterLine(controlTAE.Fecha.ToString("dd/MM/yyyy HH:mm:ss"));
            Ticket.AddFooterLine("TIENDA: " + controlTAE.Sucursal);
            Ticket.AddFooterLine("LO ATENDIO: " + vendedor.UsuariosID);
            //Ticket.AddFooterLine("SERVICIO A DOMICILIO SIN COSTO");
            //Ticket.AddFooterLine("CORREO ELECTRONICO");


            //Ticket.AddFooterLine(remision.ImporteLetra);
            //Ticket.AddFooterLine(remision.formadepago);
            //Ticket.AddFooterLine("CLIENTE:" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
            //Ticket.AddFooterLine(" ");
            //Ticket.AddFooterLine("______________________________");
            //Ticket.AddFooterLine("100% CONCENTRADOS EN SU SALUD");
            //Ticket.AddFooterLine("NO HAY CAMBIOS NI DEVOLUCIONES");

            string impresora = SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets;

            if (!Ticket.PrinterExists(SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets))
            {
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    impresora = pd.PrinterSettings.PrinterName;
                }
                else
                {
                    return;
                }
            }

            Ticket.PrintTicket(impresora);
        }

        //public bool ActualizaRemision(SIFModelo.Remision remision)
        //{
        //    if (remision.FechaPago == new DateTime())
        //    {
        //        SIFModelo.Remision rem = new SIFNegocio.Remision().RemisionPorID(remision.NumeroRemision, remision.SucursalID);
        //        if (rem != null)
        //        {
        //            remision.FechaPago = rem.FechaPago;
        //        }
        //    }

        //    return SIFDatos.Remision.ActualizaFechaPagoRemision(remision);
        //}

        public bool ActualizaRemisionFechaPago(SIFModelo.Remision remision)
        {
            if (remision.FechaPago == new DateTime())
            {
                SIFModelo.Remision rem = new SIFNegocio.Remision().RemisionPorID(remision.NumeroRemision, remision.SucursalID);
                if (rem != null)
                {
                    remision.FechaPago = rem.FechaPago;
                }
            }

            return SIFDatos.Remision.ActualizaFechaPagoRemision(remision);
        }

        public bool ActualizaRemisionEsFactura(SIFModelo.Remision remision)
        {
            return SIFDatos.Remision.ActualizaRemisionEsFactura(remision);
        }


        public bool ActualizaRemisionEsFacturaCliente(SIFModelo.Remision remision)
        {
            return SIFDatos.Remision.ActualizaRemisionEsFacturaCliente(remision);
        }
        
        public bool ActualizaRemisionStatus(SIFModelo.Remision remision)
        {
            return SIFDatos.Remision.ActualizaRemisionStatus(remision);
        }

        public bool ActualizaUUIDRemision(SIFModelo.Remision remision)
        {
            return SIFDatos.Remision.ActualizaUUIDRemision(remision);
        }

        public SIFModelo.Remision FacturarRemisionesNoFacturadas(SIFModelo.Sucursal sucursal, DateTime fecha1, DateTime fecha2, bool facturar = true)
        {
            SIFModelo.Remision remision = new SIFModelo.Remision();
            System.Data.DataSet dsRemsiones = SIFDatos.Remision.RemisionesNoFacturadas(sucursal, fecha1, fecha2);
            List<SIFModelo.Remision> remisiones = new List<SIFModelo.Remision>();
            foreach (System.Data.DataRow row in dsRemsiones.Tables["REMISIONES"].Rows)
            {
                SIFModelo.Remision rem = new SIFModelo.Remision();
                rem.SucursalID = int.Parse(row["SUCURSAL_ID"].ToString());
                rem.NumeroRemision = row["NUM_REMISION"].ToString();
                rem.TipoClienteID = int.Parse(row["TIPO_CLIENTE_ID"].ToString());
                rem.TipoClienteID = int.Parse(row["CLIENTE_ID"].ToString());
                rem.FechaVenta = DateTime.Parse(row["FECHA_VTA"].ToString());
                rem.Receta = (SIFModelo.Tipos.SiNo)row["RECETA"].ToString()[0];
                rem.MedicoID = int.Parse(row["ID_MEDICO"].ToString());
                rem.FechaVenta = DateTime.Parse(row["FECHA_PAGO"].ToString());
                rem.VendedorID = int.Parse(row["VENDEDOR_ID"].ToString());
                rem.MonedaID = int.Parse(row["MONEDA_ID"].ToString());
                rem.TipoCambio = int.Parse(row["TIPO_CAMBIO_ID"].ToString());
                rem.Condiciones = row["CONDICIONES"].ToString();
                rem.SubTotal = decimal.Parse(row["SUBTOTAL"].ToString());
                rem.Impuesto = decimal.Parse(row["IMPUESTO_IVA"].ToString());
                rem.Descuento = decimal.Parse(row["DESCUENTO"].ToString());
                rem.Total = decimal.Parse(row["TOTAL"].ToString());
                rem.TotalArticulosRemision = decimal.Parse(row["TOTAL_ARTICULOS_REM"].ToString());
                rem.NumeroFactura = row["NUM_FACTURA"].ToString();
                rem.Activo = (SIFModelo.Tipos.StatusVenta)row["ACTIVO"].ToString()[0];
                rem.ImporteLetra = row["IMPORTE_LETRA"].ToString();
                rem.Factura = (SIFModelo.Tipos.SiNo)row["FACTURA"].ToString()[0];
                rem.Comentarios = row["COMENTARIOS"].ToString();
                rem.NumeroPedido = row["NUM_PEDIDO"].ToString();
                rem.BeneficioProveedor = (SIFModelo.Tipos.SiNo)row["BENEFICIO_PROV"].ToString()[0];

                remisiones.Add(rem);
            }


            List<SIFModelo.RemisionDetalle> remisionDetalles = new List<SIFModelo.RemisionDetalle>();

            SIFNegocio.Remision remisionL = new Remision();
            foreach (var vremision in remisiones)
            {
                remisionDetalles.AddRange(remisionL.CargaRemisionDetalles(vremision).ToList());
            }

            if (remisiones.Count == 0)
            {
               MessageBox.Show("No hay remisiones a facturar");
                return null;
            }

            decimal monto = remisiones.Sum(r => r.Total);

            remision = new SIFModelo.Remision();
            remision.SubTotal = monto;
            remision.Total = monto;
            remision.ImporteLetra = sif_tools.NumberToLetters.NumToLetter((double)remision.Total, "Decimal");
            remision.Factura = SIFModelo.Tipos.SiNo.SI;
            remision.SucursalID = Configuracion.Configuraciones.Aplicacion.SucursalID;
            remision.FechaVenta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            remision.Activo = SIFModelo.Tipos.StatusVenta.PAGADA;
            remision.Condiciones = "-";
            remision.Condiciones = "-";
            remision.NumeroPedido = "0";
            remision.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;

            SIFModelo.Cliente cliente = new SIFModelo.Cliente();
            cliente = new SIFNegocio.Clientes().ClientePorID(0);

            if (cliente == null)
            {
                //CREAR EL CLIENTE GENERICO
                cliente = new SIFModelo.Cliente();
                cliente.Nombre = "PUBLICO EN GENERAL";
            }

            SIFModelo.DireccionCliente dirCliente = new SIFModelo.DireccionCliente();
            dirCliente = new SIFNegocio.Clientes().DireccionCliente(cliente);
            if (dirCliente == null)
            {
                dirCliente = new SIFModelo.DireccionCliente();
                dirCliente.RFC = "XAXX010101000";
                dirCliente.Calle = "13 SUR";
                dirCliente.CodigoPostal = "72410";
                dirCliente.Ciudad = "PUEBLA";
                dirCliente.Municipio = "PUEBLA";
                dirCliente.Telefono = "-";
                dirCliente.Email = "";
                dirCliente.NumeroExterior = "2701";
                dirCliente.NumeroInterior = "-";
                dirCliente.Colonia = "VOLCANES";
            }

            remision.Detalles = new List<SIFModelo.RemisionDetalle>();
            WebServices.FEL wsFel = new WebServices.FEL();

            SIFModelo.Configuracion.Factura app = new SIFModelo.Configuracion.Factura();

            //ACTUALIZAR TODAS LAS REMISIONES

            SIFNegocio.Impuestos impuestosL = new SIFNegocio.Impuestos();
            impuestosL.Buscar("Activo", "S");
            List<SIFModelo.Impuesto> impuestos = (List<SIFModelo.Impuesto>)impuestosL.CatImpuestosList.DataSource;
            Dictionary<SIFModelo.Impuesto, List<SIFModelo.RemisionDetalle>> ListaImpuestos = new Dictionary<SIFModelo.Impuesto, List<SIFModelo.RemisionDetalle>>();

            foreach (var impuesto in impuestos)
            {
                ListaImpuestos.Add(impuesto, new List<SIFModelo.RemisionDetalle>());
            }


            //AGRUPAMOS LOS DETALLES POR TIPO DE IMPUESTO
            foreach (SIFModelo.RemisionDetalle rem in remisionDetalles)
            {
                var vImpuesto = from p in impuestos where p.ID == rem.ImpuestoID select p;
                SIFModelo.Impuesto impuesto = vImpuesto.FirstOrDefault();

                //rem.;
                //rem.NumeroFactura = remision.NumeroFactura;
                //ActualizaRemision(rem);
                if (impuesto == null)
                {
                    continue;
                }
                ListaImpuestos[impuesto].Add(rem);

                // remision.Detalles.Add(rem);
            }

            remision.SubTotal = 0;
            foreach (var lista in ListaImpuestos)
            {
                SIFModelo.RemisionDetalle detalleRemision = new SIFModelo.RemisionDetalle();
                detalleRemision.Nombre1 = "GRAVADOS AL %" + lista.Key.Porcentaje.ToString();
                detalleRemision.CantidadRemision = 1;

                detalleRemision.Precio = lista.Value.Sum(l => l.Total);

                //RESTAMOS EL IVA
                detalleRemision.Precio = detalleRemision.Precio / (1 + (lista.Key.Porcentaje / 100m));

                detalleRemision.Total = detalleRemision.Precio;
                detalleRemision.ArticuloID = "";
                detalleRemision.IVA = lista.Value.Sum(l => l.IVA);
                detalleRemision.ImpuestoID = lista.Key.ID;

                if (detalleRemision.Total == 0)
                {
                    //no hay datos a dar remision
                    continue;
                }
                remision.SubTotal += detalleRemision.Total;
                remision.Detalles.Add(detalleRemision);
            }

            string folio = "";
            SIFModelo.RemisionDetalle detalleFirst = remisionDetalles.First();
            SIFModelo.RemisionDetalle detalleLast = remisionDetalles.Last();

            if (remisionDetalles != null)
            {
                folio = detalleFirst.NumeroRemision;
            }
            if (detalleLast != null)
            {
                folio += "-" + detalleLast.NumeroRemision;
            }

            remision.NumeroRemision = folio;
            bool generada = false;
            if (facturar)
            {
                generada = wsFel.Invocar(Configuracion.Configuraciones.Factura, Configuracion.Configuraciones.Aplicacion, cliente, remision, sucursal, dirCliente, true);


                if (generada)
                {
                    foreach (var r in remisiones)
                    {
                        r.Factura = SIFModelo.Tipos.SiNo.SI;
                        r.NumeroFactura = remision.NumeroFactura;
                        remisionL.ActualizaUUIDRemision(r);
                    }
                   MessageBox.Show("Se ha creado la factura para " + remisiones.Count + " remisiones");
                }
                else
                {
                   MessageBox.Show("Ha ocurrido un error al generar la factura " + remisiones.Count + " remisiones", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return remision;
        }


        public SIFModelo.Remision FacturarRemisionesNoFacturadasTotalRemision(SIFModelo.Sucursal sucursal, DateTime fecha1, DateTime fecha2, bool facturar = true)
        {
            SIFModelo.Remision remision = new SIFModelo.Remision();

            System.Data.DataSet dsRemsiones = SIFDatos.Remision.RemisionesNoFacturadas(sucursal, fecha1, fecha2);
            List<SIFModelo.Remision> remisiones = new List<SIFModelo.Remision>();
            foreach (System.Data.DataRow row in dsRemsiones.Tables["REMISIONES"].Rows)
            {
                SIFModelo.Remision rem = new SIFModelo.Remision();
                rem.SucursalID = int.Parse(row["SUCURSAL_ID"].ToString());
                rem.NumeroRemision = row["NUM_REMISION"].ToString();
                rem.TipoClienteID = int.Parse(row["TIPO_CLIENTE_ID"].ToString());
                rem.TipoClienteID = int.Parse(row["CLIENTE_ID"].ToString());
                rem.FechaVenta = DateTime.Parse(row["FECHA_VTA"].ToString());
                rem.Receta = (SIFModelo.Tipos.SiNo)row["RECETA"].ToString()[0];
                rem.MedicoID = int.Parse(row["ID_MEDICO"].ToString());
                rem.FechaVenta = DateTime.Parse(row["FECHA_PAGO"].ToString());
                rem.VendedorID = int.Parse(row["VENDEDOR_ID"].ToString());
                rem.MonedaID = int.Parse(row["MONEDA_ID"].ToString());
                rem.TipoCambio = int.Parse(row["TIPO_CAMBIO_ID"].ToString());
                rem.Condiciones = row["CONDICIONES"].ToString();
                rem.SubTotal = decimal.Parse(row["SUBTOTAL"].ToString());
                rem.Impuesto = decimal.Parse(row["IMPUESTO_IVA"].ToString());
                rem.Descuento = decimal.Parse(row["DESCUENTO"].ToString());
                rem.Total = decimal.Parse(row["TOTAL"].ToString());
                rem.TotalArticulosRemision = decimal.Parse(row["TOTAL_ARTICULOS_REM"].ToString());
                rem.NumeroFactura = row["NUM_FACTURA"].ToString();
                rem.Activo = (SIFModelo.Tipos.StatusVenta)row["ACTIVO"].ToString()[0];
                rem.ImporteLetra = row["IMPORTE_LETRA"].ToString();
                rem.Factura = (SIFModelo.Tipos.SiNo)row["FACTURA"].ToString()[0];
                rem.Comentarios = row["COMENTARIOS"].ToString();
                rem.NumeroPedido = row["NUM_PEDIDO"].ToString();
                rem.BeneficioProveedor = (SIFModelo.Tipos.SiNo)row["BENEFICIO_PROV"].ToString()[0];

                remisiones.Add(rem);
            }


            List<SIFModelo.RemisionDetalle> remisionDetalles = new List<SIFModelo.RemisionDetalle>();

            SIFNegocio.Remision remisionL = new Remision();
            foreach (var vremision in remisiones)
            {
                remisionDetalles.AddRange(remisionL.CargaRemisionDetalles(vremision).ToList());
            }

            if (remisiones.Count == 0)
            {
               MessageBox.Show("No hay remisiones a facturar");
                return null;
            }

            decimal monto = remisiones.Sum(r => r.Total);

            remision = new SIFModelo.Remision();
            remision.SubTotal = monto;
            remision.Total = monto;
            remision.ImporteLetra = sif_tools.NumberToLetters.NumToLetter((double)remision.Total, "Decimal");
            remision.Factura = SIFModelo.Tipos.SiNo.SI;
            remision.SucursalID = Configuracion.Configuraciones.Aplicacion.SucursalID;
            remision.FechaVenta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            remision.Activo = SIFModelo.Tipos.StatusVenta.PAGADA;
            remision.Condiciones = "-";
            remision.Condiciones = "-";
            remision.NumeroPedido = "0";
            remision.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;

            SIFModelo.Cliente cliente = new SIFModelo.Cliente();
            cliente = new SIFNegocio.Clientes().ClientePorID(0);

            if (cliente == null)
            {
                //CREAR EL CLIENTE GENERICO
                cliente = new SIFModelo.Cliente();
                cliente.Nombre = "PUBLICO EN GENERAL";
            }

            SIFModelo.DireccionCliente dirCliente = new SIFModelo.DireccionCliente();
            dirCliente = new SIFNegocio.Clientes().DireccionCliente(cliente);
            if (dirCliente == null)
            {
                dirCliente = new SIFModelo.DireccionCliente();
                dirCliente.RFC = "XAXX010101000";
                dirCliente.Calle = "13 SUR";
                dirCliente.CodigoPostal = "72410";
                dirCliente.Ciudad = "PUEBLA";
                dirCliente.Municipio = "PUEBLA";
                dirCliente.Telefono = "-";
                dirCliente.Email = "";
                dirCliente.NumeroExterior = "2701";
                dirCliente.NumeroInterior = "-";
                dirCliente.Colonia = "VOLCANES";
            }

            remision.Detalles = new List<SIFModelo.RemisionDetalle>();
            WebServices.FEL wsFel = new WebServices.FEL();

            SIFModelo.Configuracion.Factura app = new SIFModelo.Configuracion.Factura();

            //ACTUALIZAR TODAS LAS REMISIONES

            SIFNegocio.Impuestos impuestosL = new SIFNegocio.Impuestos();
            impuestosL.Buscar("Activo", "S");
            List<SIFModelo.Impuesto> impuestos = (List<SIFModelo.Impuesto>)impuestosL.CatImpuestosList.DataSource;
            Dictionary<SIFModelo.Impuesto, List<SIFModelo.RemisionDetalle>> ListaImpuestos = new Dictionary<SIFModelo.Impuesto, List<SIFModelo.RemisionDetalle>>();

            foreach (var impuesto in impuestos)
            {
                ListaImpuestos.Add(impuesto, new List<SIFModelo.RemisionDetalle>());
            }


            //AGRUPAMOS LOS DETALLES POR TIPO DE IMPUESTO
            foreach (SIFModelo.RemisionDetalle rem in remisionDetalles)
            {
                var vImpuesto = from p in impuestos where p.ID == rem.ImpuestoID select p;
                SIFModelo.Impuesto impuesto = vImpuesto.FirstOrDefault();

                //rem.;
                //rem.NumeroFactura = remision.NumeroFactura;
                //ActualizaRemision(rem);
                if (impuesto == null)
                {
                    continue;
                }
                ListaImpuestos[impuesto].Add(rem);

                // remision.Detalles.Add(rem);
            }

            remision.SubTotal = 0;
            foreach (var lista in ListaImpuestos)
            {
                SIFModelo.RemisionDetalle detalleRemision = new SIFModelo.RemisionDetalle();
                detalleRemision.Nombre1 = "GRAVADOS AL %" + lista.Key.Porcentaje.ToString();
                detalleRemision.CantidadRemision = 1;

                if (lista.Key.Porcentaje > 0)
                {
                    detalleRemision.Precio = remisiones.Where(a => a.Impuesto > 0).Sum(l => l.Total);
                }
                else
                {
                    detalleRemision.Precio = remisiones.Where(a => a.Impuesto == 0).Sum(l => l.Total);
                }

                //RESTAMOS EL IVA
                detalleRemision.Precio = detalleRemision.Precio / (1 + (lista.Key.Porcentaje / 100m));

                detalleRemision.Total = detalleRemision.Precio;
                detalleRemision.ArticuloID = "";
                detalleRemision.IVA = lista.Value.Sum(l => l.IVA);
                detalleRemision.ImpuestoID = lista.Key.ID;

                if (detalleRemision.Total == 0)
                {
                    //no hay datos a dar remision
                    continue;
                }
                remision.SubTotal += detalleRemision.Total;
                remision.Detalles.Add(detalleRemision);
            }

            string folio = "";
            SIFModelo.RemisionDetalle detalleFirst = remisionDetalles.First();
            SIFModelo.RemisionDetalle detalleLast = remisionDetalles.Last();

            if (remisionDetalles != null)
            {
                folio = detalleFirst.NumeroRemision;
            }
            if (detalleLast != null)
            {
                folio += "-" + detalleLast.NumeroRemision;
            }

            remision.NumeroRemision = folio;
            bool generada = false;
            if (facturar)
            {
                generada = wsFel.Invocar(Configuracion.Configuraciones.Factura, Configuracion.Configuraciones.Aplicacion, cliente, remision, sucursal, dirCliente, true);


                if (generada)
                {
                    foreach (var r in remisiones)
                    {
                        r.Factura = SIFModelo.Tipos.SiNo.SI;
                        r.NumeroFactura = remision.NumeroFactura;
                        remisionL.ActualizaUUIDRemision(r);
                    }
                   MessageBox.Show("Se ha creado la factura para " + remisiones.Count + " remisiones");
                }
                else
                {
                   MessageBox.Show("Ha ocurrido un error al generar la factura " + remisiones.Count + " remisiones", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return remision;
        }
        public static void RImprimeTicket(SIFModelo.Remision remision, SIFModelo.WebServices.TarjetaNadro tarjeta = null)
        {
            SIFNegocio.Remision logica = new SIFNegocio.Remision();

            if (remision.Detalles == null)
            {
                remision.Detalles = logica.CargaRemisionDetalles(remision);

                if (remision.Condiciones == "NADRO")
                {
                    //buscar la sesion de NADRO
                    SIFModelo.WebServices.Nadro control = new SIFNegocio.WebServices.NADRO().Control(remision);

                    //SIFModelo.WebServices.TarjetaNadro tarjeta = new SIFModelo.WebServices.TarjetaNadro();
                    tarjeta.NumeroTarjeta = control.NumeroTarjeta;
                    tarjeta.ClienteID = remision.ClienteID;
                    tarjeta.NumeroConfirmacion = control.NumeroConfirmacion;
                    tarjeta.SesionID = control.CotizacionID;

                    List<SIFModelo.WebServices.NadroDetalle> detallesNadro = new SIFNegocio.WebServices.NADRO().ControlDetalles(control);

                    // remision.Detalles = logica.CargaRemisionDetalles(remision);

                    foreach (SIFModelo.RemisionDetalle detalle in remision.Detalles)
                    {
                        var vDetalleN = from n in detallesNadro where n.ArticuloID == detalle.ArticuloID && n.CantPagarNadro == detalle.CantidadRemision select n;

                        if (vDetalleN.Count() > 0)
                        {
                            SIFModelo.WebServices.NadroDetalle detalleNadro = vDetalleN.First();

                            detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                            detalle.MontoDescuento = detalleNadro.MontoDesctoNadro;
                            detalle.PiezasGratis = (int)detalleNadro.CantRegaloNadro;
                            detalle.PorcentajeDescuento = (int)detalleNadro.PorcenDesctoNadro;
                            detalle.MontoDescuento = detalleNadro.MontoDesctoNadro;
                            //detalle.Precio = detalleNadro.Precio;
                            if (detalle.PorcentajeDescuento > 0)
                            {
                                detalle.PrecioDescontado = detalle.Precio - (detalle.Precio * (detalle.PorcentajeDescuento / 100m));
                            }
                            if (detalle.MontoDescuento > 0)
                            {
                                detalle.PrecioDescontado = detalle.Precio- detalle.MontoDescuento;
                                if (detalle.PrecioDescontado < 0)
                                {
                                    detalle.PrecioDescontado = 0;
                                    detalle.MontoDescuento = 0;
                                }
                            }

                            detalle.PrecioProveedor = detalleNadro.PrecioFijo;
                        }
                    }

                    SIFNegocio.Remision.ImprimeTicket(remision, tarjeta);
                    return;
                }
            }
            SIFModelo.Sucursal sucursal = new SIFNegocio.Sucursales().SucursalPorID(remision.SucursalID);
            SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(remision.VendedorID);
            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(remision.ClienteID);
            
            RImprimeTicket(remision, remision.Detalles, sucursal, usuario, cliente, tarjeta);
        }



        public static void ImprimeTicket(SIFModelo.Remision remision, SIFModelo.WebServices.TarjetaNadro tarjeta = null)
        {
            SIFNegocio.Remision logica = new SIFNegocio.Remision();

            if (remision.Detalles == null)
            {
                remision.Detalles = logica.CargaRemisionDetalles(remision);

                if (remision.Condiciones == "NADRO")
                {
                    //buscar la sesion de NADRO
                    SIFModelo.WebServices.Nadro control = new SIFNegocio.WebServices.NADRO().Control(remision);

                    //SIFModelo.WebServices.TarjetaNadro tarjeta = new SIFModelo.WebServices.TarjetaNadro();
                    tarjeta.NumeroTarjeta = control.NumeroTarjeta;
                    tarjeta.ClienteID = remision.ClienteID;
                    tarjeta.NumeroConfirmacion = control.NumeroConfirmacion;
                    tarjeta.SesionID = control.CotizacionID;

                    List<SIFModelo.WebServices.NadroDetalle> detallesNadro = new SIFNegocio.WebServices.NADRO().ControlDetalles(control);

                   // remision.Detalles = logica.CargaRemisionDetalles(remision);

                    foreach (SIFModelo.RemisionDetalle detalle in remision.Detalles)
                    {
                        var vDetalleN = from n in detallesNadro where n.ArticuloID == detalle.ArticuloID && n.CantPagarNadro == detalle.CantidadRemision select n;

                        if (vDetalleN.Count() > 0)
                        {
                            SIFModelo.WebServices.NadroDetalle detalleNadro = vDetalleN.First();

                            detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                            detalle.MontoDescuento = detalleNadro.MontoDesctoNadro;
                            detalle.PiezasGratis = (int)detalleNadro.CantRegaloNadro;
                            detalle.PorcentajeDescuento = (int)detalleNadro.PorcenDesctoNadro;
                            detalle.MontoDescuento = detalleNadro.MontoDesctoNadro;
                            //detalle.Precio = detalleNadro.Precio;
                            if (detalle.PorcentajeDescuento > 0)
                            {
                                detalle.PrecioDescontado = detalle.Precio - (detalle.Precio * (detalle.PorcentajeDescuento / 100m));
                            }
                            if (detalle.MontoDescuento > 0)
                            {
                                detalle.PrecioDescontado = detalle.Precio - detalle.MontoDescuento;
                                if (detalle.PrecioDescontado < 0)
                                {
                                    detalle.PrecioDescontado = 0;
                                    detalle.MontoDescuento = 0;
                                }
                            }

                            detalle.PrecioProveedor = detalleNadro.PrecioFijo;
                        }
                    }

                    SIFNegocio.Remision.ImprimeTicket(remision, tarjeta);
                    return;
                }
            }
            SIFModelo.Sucursal sucursal = new SIFNegocio.Sucursales().SucursalPorID(remision.SucursalID);
            SIFModelo.Usuario usuario = new SIFNegocio.Usuarios().UsuarioPorId(remision.VendedorID);
            SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(remision.ClienteID);
            ImprimeTicket(remision, remision.Detalles, sucursal, usuario, cliente, tarjeta);
        }

        public System.Data.DataSet BuscaRemisionesNoPagadas(SIFModelo.Sucursal sucursal, SIFModelo.Remision remision, DateTime fecha1, DateTime fecha2, String estado)
        {
            System.Data.DataSet ds = SIFDatos.Remision.RemisionesNoPagadas(sucursal, remision, fecha1, fecha2, estado);
            return ds;
        }
        public System.Data.DataSet BuscaRemisionesNoPagadasCredito(SIFModelo.Sucursal sucursal, SIFModelo.Remision remision, DateTime fecha1, DateTime fecha2, String estado)
        {
            System.Data.DataSet ds = SIFDatos.Remision.RemisionesNoPagadasCredito(sucursal, remision, fecha1, fecha2, estado);
            return ds;
        }
        public System.Data.DataSet BuscaRemisionesNoPagadas(SIFModelo.Sucursal sucursal, SIFModelo.Remision remision, DateTime fecha1, DateTime fecha2, String estado, String ClienteID, bool PrecioFijo)
        {
            System.Data.DataSet ds = SIFDatos.Remision.RemisionesNoPagadas(sucursal, remision, fecha1, fecha2, estado, ClienteID, PrecioFijo);
            return ds;
        }

        public bool CancelaDetalle(SIFModelo.RemisionDetalle detalle, int cantidadDevolver, SIFModelo.Usuario usuario, SIFModelo.TipoDevolucion tipoDevolucion)
        {
            SIFModelo.Remision remision = SIFDatos.Remision.RemisionPorId(detalle.NumeroRemision, detalle.SucursalID);

            bool pagada = false;
            if (remision.Activo == SIFModelo.Tipos.StatusVenta.PAGADA)
            {
                pagada = true;
            }
            else
            {
               MessageBox.Show("La remisión no ha sido pagada");
                return false;
            }

            // remision.Activo = SIFModelo.Tipos.StatusVenta.CANCELADA;
            SIFModelo.Sucursal sucursal = new SIFNegocio.Sucursales().SucursalPorID(remision.SucursalID);
            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();

            SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);

            inventario.InventarioArticuloAumenta(articulo, cantidadDevolver, remision.NumeroRemision, 17, short.Parse(detalle.NumeroPartida.ToString()), remision.VendedorID.ToString());

            SIFModelo.Devolucion devolucion = SIFDatos.Remision.DevolucionPorRemision(remision, sucursal);

            string devolucionID = "";
            if (devolucion != null)
            {
                devolucionID = devolucion.DevolucionID;
            }
            else
            {
                devolucion = new SIFModelo.Devolucion();
                devolucion.Activo = SIFModelo.Tipos.ActivoDevolucion.ABIERTA;
                devolucion.AutorizaID = usuario.UsuariosID;
                devolucion.ClienteID = remision.ClienteID;
                devolucion.Comentario = "";
                devolucion.FechaDevolucion = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                devolucion.SucursalID = sucursal.SucursalesID;
                devolucion.TotalDevolucion = cantidadDevolver * detalle.Precio;
                devolucion.UsuarioID = usuario.UsuariosID;
                devolucion.Comentario = tipoDevolucion.Observaciones;
                devolucion.ReferenciaVenta = remision.NumeroRemision;
                int numeroDevolucion = 0;
                devolucion.DevolucionID = NumeroDevolucion(sucursal, out numeroDevolucion);

                return SIFDatos.Remision.InsertaDevolucion(devolucion, sucursal);
            }

            return true;

            //return SIFDatos.Remision.Cancela(remision);


        }

        private string NumeroDevolucion(SIFModelo.Sucursal sucursal, out int numRemision)
        {
            string prefijoFolio = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yy");

            numRemision = SIFDatos.Remision.NumeroCancelacion(sucursal.SucursalesID, prefijoFolio);

            string sb = sucursal.SucursalesID.ToString("00") + prefijoFolio + numRemision.ToString().PadLeft(11, '0'); ;
            //sb = sb.PadLeft(15,'0');
            return sb;
        }

        public int CantidadDevuelta(SIFModelo.RemisionDetalle detalle)
        {
            return SIFDatos.ValesDevolucions.CantidadDevuelta(detalle);
        }


        public SIFModelo.Remision RemisionPorID(string numeroRemision, int sucursal)
        {
            return SIFDatos.Remision.RemisionPorId(numeroRemision, sucursal);
        }

        public static SIFModelo.Cliente18 cliente18(SIFModelo.Remision remision)
        {
           return SIFDatos.Remision.cliente18(remision);
        }
        public static void RImprimeTicketPedido(SIFModelo.Remision remision, List<SIFModelo.RemisionDetalle> detalles, SIFModelo.Sucursal sucursal, SIFModelo.Usuario vendedor, SIFModelo.Cliente cliente, SIFModelo.Pedido pedido)
        {
            Helpers.Ticket Ticket = new Helpers.Ticket();

            Ticket.AddHeaderLine("FARMACIAS FLEMING");
            Ticket.AddHeaderLine(" ");
            Ticket.AddHeaderLine("OPERADOR DE FARMACIAS A.F.");
            Ticket.AddHeaderLine("DEL CENTRO S. DE R.L. DE C.V.");
            Ticket.AddHeaderLine("R.F.C.: " + SIFNegocio.Configuracion.Configuraciones.Factura.UsuarioFEL);

            Ticket.AddSubHeaderLine(" ");

            Ticket.AddSubHeaderLine(sucursal.Calle + " " + sucursal.NumeroExterior + " " + sucursal.Colonia);
            Ticket.AddSubHeaderLine(sucursal.Ciudad + " " + sucursal.Municipio + " C.P." + sucursal.CodigoPostal);
            Ticket.AddSubHeaderLine("TEL: " + sucursal.Telefono + " FAX:");
            Ticket.AddSubHeaderLine("SUCURSAL: " + sucursal.Nombre);
            Ticket.AddSubHeaderLine("NOTA:" + remision.NumeroRemision);
            Ticket.AddSubHeaderLine("FECHA:" + remision.FechaVenta.ToString("dd/MM/yyyy HH:mm:ss"));
            Ticket.AddSubHeaderLine("ATENDIO:" + vendedor.Nombre + " " + vendedor.Apellidos);
            Ticket.AddSubHeaderLine(" ");
            Ticket.AddSubHeaderLine("*** SERVICIO A DOMICILIO SIN COSTO ***");
            Ticket.AddSubHeaderLine("***    TELEFONO. 2295656           ***");

            SIFModelo.DireccionCliente dirCasa = new SIFModelo.DireccionCliente();
            cliente.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
            dirCasa = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);
            Ticket.AddSubHeaderLine(cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
            Ticket.AddSubHeaderLine("TEL: " + dirCasa.Telefono);
            Ticket.AddSubHeaderLine("CElULAR: " + dirCasa.Celular);
            Ticket.AddSubHeaderLine(dirCasa.Calle + " " + dirCasa.NumeroExterior + " " + dirCasa.NumeroInterior + "Col." + dirCasa.Colonia);
            Ticket.AddSubHeaderLine(dirCasa.Municipio + " " + dirCasa.Ciudad + " C.P." + dirCasa.CodigoPostal);
            Ticket.AddSubHeaderLine(dirCasa.EntreCalles);
            Ticket.AddSubHeaderLine(" ");
            Ticket.AddSubHeaderLine("RECETA:" + remision.Receta + " FACTURA:" + remision.Factura);
            Ticket.AddSubHeaderLine(" ");
            Ticket.AddSubHeaderLine("***** TICKET REIMPRESO ******");
            Ticket.AddSubHeaderLine(" ");

            if (!(string.IsNullOrEmpty(pedido.Comentario)) && (pedido.Comentario.Length > 80 & pedido.Comentario.Length < 160))
            {
                Ticket.AddSubHeaderLine(pedido.Comentario.Substring(0, 80));
                Ticket.AddSubHeaderLine(pedido.Comentario.Substring(80));
            }
            else
                if (pedido.Comentario.Length <= 80)
                    Ticket.AddSubHeaderLine(pedido.Comentario);
                else
                {
                    Ticket.AddSubHeaderLine(pedido.Comentario.Substring(0, 80));
                    Ticket.AddSubHeaderLine(pedido.Comentario.Substring(80, 160));
                    Ticket.AddSubHeaderLine(pedido.Comentario.Substring(160));
                }
            Ticket.AddSubHeaderLine(" ");
            decimal cambio = pedido.TotalPago - remision.Total;
            SIFModelo.TipoPago Tipo = SIFDatos.TipoPagos.TipoPagoPorID(pedido.TipoPagoID);
            if (Tipo != null)
                Ticket.AddSubHeaderLine("Forma de pago:" + Tipo.Nombre);
            Ticket.AddSubHeaderLine("cantidad paga:" + pedido.TotalPago.ToString("C2", new System.Globalization.CultureInfo("ES-mx")) + " Cambio:" + cambio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            Ticket.AddSubHeaderLine(" ");
            decimal subTotal = 0;
            foreach (SIFModelo.RemisionDetalle detalle in detalles)
            {
                if (detalle.IVA > 0)
                {
                    detalle.Nombre1 = "* " + detalle.Nombre1;
                }

                subTotal += detalle.CantidadRemision * detalle.Precio;

                detalle.Total = detalle.Precio * detalle.CantidadRemision;
                Ticket.AddItem(detalle.CantidadRemision.ToString(), detalle.ArticuloID, detalle.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1);



                if (!string.IsNullOrEmpty(detalle.Lote) && detalle.Lote != "0")
                {
                    Ticket.AddItem("", "LOTE:" + detalle.Lote, detalle.Caducidad.Value.ToString("dd/MM/yyy"), "CAD", "");
                }
            }

            Ticket.AddTotal("SUBTOTAL", subTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            Ticket.AddTotal("DESCUENTO", remision.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            //Ticket.AddTotal("I.V.A.", remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            Ticket.AddTotal("TOTAL", remision.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));

            if (remision.Impuesto > 0)
            {
                Ticket.AddFooterLine("I.V.A. INFORMATIVO: " + remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                Ticket.AddFooterLine(" ");
            }

            //LGS 10/02/2014 Para que imprima en el ticket el tipo de descuento aplicado {INSEN,LOGO,...}
            if (remision.Condiciones != "NADRO" && remision.Condiciones != "PFIZER" && remision.Condiciones != "TAE" && remision.Condiciones != " " && remision.Condiciones.Length > 0)
            {
                Ticket.AddFooterLine("Beneficio " + remision.Condiciones + "%");
                Ticket.AddFooterLine(" ");
            }
            Ticket.AddFooterLine("CORREO ELECTRONICO");


            //Ticket.AddFooterLine(remision.ImporteLetra);
            //Ticket.AddFooterLine(remision.formadepago);
            //Ticket.AddFooterLine("CLIENTE:" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
            Ticket.AddFooterLine(" ");
            Ticket.AddFooterLine("______________________________");
            Ticket.AddFooterLine("100% CONCENTRADOS EN SU SALUD");
            Ticket.AddFooterLine("NO HAY CAMBIOS NI DEVOLUCIONES");

            string impresora = SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets;

            if (!Ticket.PrinterExists(SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets))
            {
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    impresora = pd.PrinterSettings.PrinterName;
                }
                else
                {
                    return;
                }
            }

            Ticket.PrintTicket(impresora);
        }
        public static void ImprimeTicketPedido(SIFModelo.Remision remision, List<SIFModelo.RemisionDetalle> detalles, SIFModelo.Sucursal sucursal, SIFModelo.Usuario vendedor, SIFModelo.Cliente cliente, SIFModelo.Pedido pedido)
        {
            Helpers.Ticket Ticket = new Helpers.Ticket();

            Ticket.AddHeaderLine("FARMACIAS FLEMING");
            Ticket.AddHeaderLine(" ");
            Ticket.AddHeaderLine("OPERADOR DE FARMACIAS A.F.");
            Ticket.AddHeaderLine("DEL CENTRO S. DE R.L. DE C.V.");
            Ticket.AddHeaderLine("R.F.C.: " + SIFNegocio.Configuracion.Configuraciones.Factura.UsuarioFEL);

            Ticket.AddSubHeaderLine(" ");

            Ticket.AddSubHeaderLine(sucursal.Calle + " " + sucursal.NumeroExterior + " " + sucursal.Colonia);
            Ticket.AddSubHeaderLine(sucursal.Ciudad + " " + sucursal.Municipio + " C.P." + sucursal.CodigoPostal);
            Ticket.AddSubHeaderLine("TEL: " + sucursal.Telefono + " FAX:");
            Ticket.AddSubHeaderLine("SUCURSAL: " + sucursal.Nombre);
            Ticket.AddSubHeaderLine("NOTA:" + remision.NumeroRemision);
            Ticket.AddSubHeaderLine("FECHA:" + remision.FechaVenta.ToString("dd/MM/yyyy HH:mm:ss"));
            Ticket.AddSubHeaderLine("ATENDIO:" + vendedor.Nombre + " " + vendedor.Apellidos);
            Ticket.AddSubHeaderLine(" ");
            Ticket.AddSubHeaderLine("*** SERVICIO A DOMICILIO SIN COSTO ***");
            Ticket.AddSubHeaderLine("***    TELEFONO. 2295656           ***");

            SIFModelo.DireccionCliente dirCasa = new SIFModelo.DireccionCliente();
            cliente.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
            dirCasa = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);
            Ticket.AddSubHeaderLine(cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
            Ticket.AddSubHeaderLine("TEL: " + dirCasa.Telefono);
            Ticket.AddSubHeaderLine("CElULAR: " + dirCasa.Celular);
            Ticket.AddSubHeaderLine(dirCasa.Calle + " " + dirCasa.NumeroExterior + " " + dirCasa.NumeroInterior + "Col." + dirCasa.Colonia);
            Ticket.AddSubHeaderLine(dirCasa.Municipio + " " + dirCasa.Ciudad + " C.P." + dirCasa.CodigoPostal);
            Ticket.AddSubHeaderLine(dirCasa.EntreCalles);
            Ticket.AddSubHeaderLine(" ");
            Ticket.AddSubHeaderLine("RECETA:" + remision.Receta + " FACTURA:" + remision.Factura);

            Ticket.AddSubHeaderLine(" ");

            if (!(string.IsNullOrEmpty(pedido.Comentario)) && (pedido.Comentario.Length > 80 & pedido.Comentario.Length < 160))
            {
                Ticket.AddSubHeaderLine(pedido.Comentario.Substring(0, 80));
                Ticket.AddSubHeaderLine(pedido.Comentario.Substring(80));
            }
            else
                if (pedido.Comentario.Length <= 80)
                    Ticket.AddSubHeaderLine(pedido.Comentario);
                else
                {
                    Ticket.AddSubHeaderLine(pedido.Comentario.Substring(0, 80));
                    Ticket.AddSubHeaderLine(pedido.Comentario.Substring(80, 160));
                    Ticket.AddSubHeaderLine(pedido.Comentario.Substring(160));
                }
            Ticket.AddSubHeaderLine(" ");
            decimal cambio = pedido.TotalPago - remision.Total;
            SIFModelo.TipoPago Tipo = SIFDatos.TipoPagos.TipoPagoPorID(pedido.TipoPagoID);
            if (Tipo != null)
                Ticket.AddSubHeaderLine("Forma de pago:" + Tipo.Nombre);
            Ticket.AddSubHeaderLine("cantidad paga:" + pedido.TotalPago.ToString("C2", new System.Globalization.CultureInfo("ES-mx")) + " Cambio:" + cambio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            Ticket.AddSubHeaderLine(" ");
            decimal subTotal = 0;
            foreach (SIFModelo.RemisionDetalle detalle in detalles)
            {
                if (detalle.IVA > 0)
                {
                    detalle.Nombre1 = "* " + detalle.Nombre1;
                }

                subTotal += detalle.CantidadRemision * detalle.Precio;

                detalle.Total = detalle.Precio * detalle.CantidadRemision;
                Ticket.AddItem(detalle.CantidadRemision.ToString(), detalle.ArticuloID, detalle.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1);



                if (!string.IsNullOrEmpty(detalle.Lote) && detalle.Lote != "0")
                {
                    Ticket.AddItem("", "LOTE:" + detalle.Lote, detalle.Caducidad.Value.ToString("dd/MM/yyy"), "CAD", "");
                }
            }

            Ticket.AddTotal("SUBTOTAL", subTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            Ticket.AddTotal("DESCUENTO", remision.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            //Ticket.AddTotal("I.V.A.", remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            Ticket.AddTotal("TOTAL", remision.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));

            if (remision.Impuesto > 0)
            {
                Ticket.AddFooterLine("I.V.A. INFORMATIVO: " + remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                Ticket.AddFooterLine(" ");
            }

            //LGS 10/02/2014 Para que imprima en el ticket el tipo de descuento aplicado {INSEN,LOGO,...}
            if (remision.Condiciones != "NADRO" && remision.Condiciones != "PFIZER" && remision.Condiciones != "TAE" && remision.Condiciones != " " && remision.Condiciones.Length > 0)
            {
                Ticket.AddFooterLine("Beneficio " + remision.Condiciones + "%");
                Ticket.AddFooterLine(" ");
            }
            Ticket.AddFooterLine("CORREO ELECTRONICO");


            //Ticket.AddFooterLine(remision.ImporteLetra);
            //Ticket.AddFooterLine(remision.formadepago);
            //Ticket.AddFooterLine("CLIENTE:" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
            Ticket.AddFooterLine(" ");
            Ticket.AddFooterLine("______________________________");
            Ticket.AddFooterLine("100% CONCENTRADOS EN SU SALUD");
            Ticket.AddFooterLine("NO HAY CAMBIOS NI DEVOLUCIONES");

            string impresora = SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets;

            if (!Ticket.PrinterExists(SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets))
            {
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    impresora = pd.PrinterSettings.PrinterName;
                }
                else
                {
                    return;
                }
            }

            Ticket.PrintTicket(impresora);
        }

        public static void ImprimeTicketApartadoEPedido(SIFModelo.Apartado remision, List<SIFModelo.ApartadoDetalle> detalles, SIFModelo.Sucursal sucursal, SIFModelo.Usuario vendedor, SIFModelo.Cliente cliente)
        {
            Helpers.Ticket Ticket = new Helpers.Ticket();

            Ticket.AddHeaderLine("FARMACIAS FLEMING");
            Ticket.AddHeaderLine(" ");
            Ticket.AddHeaderLine("OPERADOR DE FARMACIAS A.F.");
            Ticket.AddHeaderLine("DEL CENTRO S. DE R.L. DE C.V.");
            Ticket.AddHeaderLine("R.F.C.: " + SIFNegocio.Configuracion.Configuraciones.Factura.UsuarioFEL);

            Ticket.AddSubHeaderLine(" ");

            Ticket.AddSubHeaderLine(sucursal.Calle + " " + sucursal.NumeroExterior + " " + sucursal.Colonia);
            Ticket.AddSubHeaderLine(sucursal.Ciudad + " " + sucursal.Municipio + " C.P." + sucursal.CodigoPostal);
            Ticket.AddSubHeaderLine("TEL: " + sucursal.Telefono + " FAX:");
            Ticket.AddSubHeaderLine("SUCURSAL: " + sucursal.Nombre);
            Ticket.AddSubHeaderLine("NOTA:" + remision.NumeroApartado);
            Ticket.AddSubHeaderLine("FECHA:" + remision.FechaApartado.ToString("dd/MM/yyyy HH:mm:ss"));
            Ticket.AddSubHeaderLine("ATENDIO:" + vendedor.Nombre + " " + vendedor.Apellidos);
            Ticket.AddSubHeaderLine(" ");
            Ticket.AddSubHeaderLine("*** SERVICIO A DOMICILIO SIN COSTO ***");
            Ticket.AddSubHeaderLine("***    TELEFONO. 2295656           ***");

            SIFModelo.DireccionCliente dirCasa = new SIFModelo.DireccionCliente();
            cliente.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
            dirCasa = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);
            Ticket.AddSubHeaderLine(cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);

            if (dirCasa == null)
            {
                dirCasa = new SIFModelo.DireccionCliente();
                dirCasa.Calle = "";
                dirCasa.Celular = "";
                dirCasa.Ciudad = "";
                dirCasa.ClienteID = cliente.ID;
                dirCasa.CodigoPostal = "";
                dirCasa.Colonia = "";
                dirCasa.Email = "";
                dirCasa.EntreCalles = "";
                dirCasa.Municipio = "";
                dirCasa.NumeroExterior = "";
                dirCasa.NumeroInterior = "";
                dirCasa.RFC = "";
                dirCasa.Telefono = "";
                dirCasa.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
            }

            Ticket.AddSubHeaderLine("TEL: " + dirCasa.Telefono);
            Ticket.AddSubHeaderLine("CElULAR: " + dirCasa.Celular);
            Ticket.AddSubHeaderLine(dirCasa.Calle + " " + dirCasa.NumeroExterior + " " + dirCasa.NumeroInterior + "Col." + dirCasa.Colonia);
            Ticket.AddSubHeaderLine(dirCasa.Municipio + " " + dirCasa.Ciudad + " C.P." + dirCasa.CodigoPostal);
            Ticket.AddSubHeaderLine(dirCasa.EntreCalles);
            Ticket.AddSubHeaderLine(" ");
            Ticket.AddSubHeaderLine("RECETA:" + remision.Receta + " FACTURA:" + remision.Factura);

            Ticket.AddSubHeaderLine(" ");
            if (remision.Comentario.Length > 80 & remision.Comentario.Length < 160)
            {
                Ticket.AddSubHeaderLine(remision.Comentario.Substring(0, 80));
                Ticket.AddSubHeaderLine(remision.Comentario.Substring(80));
            }
            else
                if (remision.Comentario.Length <= 80)
                    Ticket.AddSubHeaderLine(remision.Comentario);
                else
                {
                    Ticket.AddSubHeaderLine(remision.Comentario.Substring(0, 80));
                    Ticket.AddSubHeaderLine(remision.Comentario.Substring(80, 160));
                    Ticket.AddSubHeaderLine(remision.Comentario.Substring(160));
                }

            //Ticket.AddSubHeaderLine(" ");
            //decimal cambio = remision.TotalPago - remision.Total;
            //SIFModelo.TipoPago Tipo = SIFDatos.TipoPagos.TipoPagoPorID(pedido.TipoPagoID);
            //if (Tipo != null)
            //    Ticket.AddSubHeaderLine("Forma de pago:" + Tipo.Nombre);
            //Ticket.AddSubHeaderLine("cantidad paga:" + pedido.TotalPago.ToString("##,##0.00") + " Cambio:" + cambio.ToString("##,##0.00"));
            //Ticket.AddSubHeaderLine(" ");
            foreach (SIFModelo.ApartadoDetalle detalle in detalles)
            {
                if (detalle.IVA > 0)
                {
                    detalle.Nombre1 = "* " + detalle.Nombre1;
                }

                detalle.Total = detalle.Precio * detalle.CantidadApartado;
                Ticket.AddItem(detalle.CantidadApartado.ToString(), detalle.ArticuloID, detalle.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1);
            }

            Ticket.AddTotal("SUBTOTAL", remision.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            Ticket.AddTotal("DESCUENTO", remision.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            //Ticket.AddTotal("I.V.A.", remision.ImpuestoIVA.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            Ticket.AddTotal("TOTAL", (remision.Total).ToString("C2", new System.Globalization.CultureInfo("ES-mx")));

            if (remision.Anticipo > 0)
            {
                Ticket.AddTotal("ANTICIPO", remision.Anticipo.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                Ticket.AddTotal("RESTANTE", (remision.Total - remision.Anticipo).ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            }

            if (remision.ImpuestoIVA > 0)
            {
                Ticket.AddFooterLine("I.V.A. INFORMATIVO: " + remision.ImpuestoIVA.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                Ticket.AddFooterLine(" ");
            }

            Ticket.AddFooterLine("CORREO ELECTRONICO");

            //Ticket.AddFooterLine(remision.ImporteLetra);
            //Ticket.AddFooterLine(remision.formadepago);
            //Ticket.AddFooterLine("CLIENTE:" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
            Ticket.AddFooterLine(" ");
            Ticket.AddFooterLine("______________________________");
            Ticket.AddFooterLine("100% CONCENTRADOS EN SU SALUD");
            Ticket.AddFooterLine("NO HAY CAMBIOS NI DEVOLUCIONES");

            string impresora = SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets;

            if (!Ticket.PrinterExists(SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets))
            {
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    impresora = pd.PrinterSettings.PrinterName;
                }
                else
                {
                    return;
                }
            }

            Ticket.PrintTicket(impresora);
        }

        public static void ImprimeTicketApartadoEPedido(SIFModelo.Apartado remision, List<SIFModelo.RemisionDetalle> detalles, SIFModelo.Sucursal sucursal, SIFModelo.Usuario vendedor, SIFModelo.Cliente cliente)
        {
            Helpers.Ticket Ticket = new Helpers.Ticket();

            Ticket.AddHeaderLine("FARMACIAS FLEMING");
            Ticket.AddHeaderLine(" ");
            Ticket.AddHeaderLine("OPERADOR DE FARMACIAS A.F.");
            Ticket.AddHeaderLine("DEL CENTRO S. DE R.L. DE C.V.");
            Ticket.AddHeaderLine("R.F.C.: " + SIFNegocio.Configuracion.Configuraciones.Factura.UsuarioFEL);

            Ticket.AddSubHeaderLine(" ");

            Ticket.AddSubHeaderLine(sucursal.Calle + " " + sucursal.NumeroExterior + " " + sucursal.Colonia);
            Ticket.AddSubHeaderLine(sucursal.Ciudad + " " + sucursal.Municipio + " C.P." + sucursal.CodigoPostal);
            Ticket.AddSubHeaderLine("TEL: " + sucursal.Telefono + " FAX:");
            Ticket.AddSubHeaderLine("SUCURSAL: " + sucursal.Nombre);
            Ticket.AddSubHeaderLine("NOTA:" + remision.NumeroApartado);
            Ticket.AddSubHeaderLine("FECHA:" + remision.FechaApartado.ToString("dd/MM/yyyy HH:mm:ss"));
            Ticket.AddSubHeaderLine("ATENDIO:" + vendedor.Nombre + " " + vendedor.Apellidos);
            Ticket.AddSubHeaderLine(" ");
            Ticket.AddSubHeaderLine("*** SERVICIO A DOMICILIO SIN COSTO ***");
            Ticket.AddSubHeaderLine("***    TELEFONO. 2295656           ***");

            SIFModelo.DireccionCliente dirCasa = new SIFModelo.DireccionCliente();
            cliente.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
            dirCasa = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);
            Ticket.AddSubHeaderLine(cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);

            if (dirCasa == null)
            {
                dirCasa = new SIFModelo.DireccionCliente();
                dirCasa.Calle = "";
                dirCasa.Celular = "";
                dirCasa.Ciudad = "";
                dirCasa.ClienteID = cliente.ID;
                dirCasa.CodigoPostal = "";
                dirCasa.Colonia = "";
                dirCasa.Email = "";
                dirCasa.EntreCalles = "";
                dirCasa.Municipio = "";
                dirCasa.NumeroExterior = "";
                dirCasa.NumeroInterior = "";
                dirCasa.RFC = "";
                dirCasa.Telefono = "";
                dirCasa.TipoDireccion = SIFModelo.Tipos.TipoDireccion.casa;
            }

            Ticket.AddSubHeaderLine("TEL: " + dirCasa.Telefono);
            Ticket.AddSubHeaderLine("CElULAR: " + dirCasa.Celular);
            Ticket.AddSubHeaderLine(dirCasa.Calle + " " + dirCasa.NumeroExterior + " " + dirCasa.NumeroInterior + "Col." + dirCasa.Colonia);
            Ticket.AddSubHeaderLine(dirCasa.Municipio + " " + dirCasa.Ciudad + " C.P." + dirCasa.CodigoPostal);
            Ticket.AddSubHeaderLine(dirCasa.EntreCalles);
            Ticket.AddSubHeaderLine(" ");
            Ticket.AddSubHeaderLine("REMISION:" + remision.ReferenciaRemisionVenta);
            Ticket.AddSubHeaderLine("RECETA:" + remision.Receta + " FACTURA:" + remision.Factura);

            Ticket.AddSubHeaderLine(" ");
            if (remision.Comentario.Length > 80 & remision.Comentario.Length < 160)
            {
                Ticket.AddSubHeaderLine(remision.Comentario.Substring(0, 80));
                Ticket.AddSubHeaderLine(remision.Comentario.Substring(80));
            }
            else
                if (remision.Comentario.Length <= 80)
                    Ticket.AddSubHeaderLine(remision.Comentario);
                else
                {
                    Ticket.AddSubHeaderLine(remision.Comentario.Substring(0, 80));
                    Ticket.AddSubHeaderLine(remision.Comentario.Substring(80, 160));
                    Ticket.AddSubHeaderLine(remision.Comentario.Substring(160));
                }

            //Ticket.AddSubHeaderLine(" ");
            //decimal cambio = remision.TotalPago - remision.Total;
            //SIFModelo.TipoPago Tipo = SIFDatos.TipoPagos.TipoPagoPorID(pedido.TipoPagoID);
            //if (Tipo != null)
            //    Ticket.AddSubHeaderLine("Forma de pago:" + Tipo.Nombre);
            //Ticket.AddSubHeaderLine("cantidad paga:" + pedido.TotalPago.ToString("##,##0.00") + " Cambio:" + cambio.ToString("##,##0.00"));
            //Ticket.AddSubHeaderLine(" ");

            decimal subTotal = 0;

            foreach (SIFModelo.RemisionDetalle detalle in detalles)
            {
                if (detalle.IVA > 0)
                {
                    detalle.Nombre1 = "* " + detalle.Nombre1;
                }

                subTotal += detalle.CantidadRemision * detalle.Precio;

                detalle.Total = detalle.Precio * detalle.CantidadRemision;
                Ticket.AddItem(detalle.CantidadRemision.ToString(), detalle.ArticuloID, detalle.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1);
            }

            Ticket.AddTotal("SUBTOTAL", subTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            Ticket.AddTotal("DESCUENTO", remision.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            //Ticket.AddTotal("I.V.A.", remision.ImpuestoIVA.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            Ticket.AddTotal("TOTAL", (remision.Total).ToString("C2", new System.Globalization.CultureInfo("ES-mx")));

            if (remision.Anticipo > 0)
            {
                Ticket.AddTotal("ANTICIPO", remision.Anticipo.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                Ticket.AddTotal("RESTANTE", (remision.Total - remision.Anticipo).ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            }

            if (remision.ImpuestoIVA > 0)
            {
                Ticket.AddFooterLine("I.V.A. INFORMATIVO: " + remision.ImpuestoIVA.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                Ticket.AddFooterLine(" ");
            }

      
            Ticket.AddFooterLine("CORREO ELECTRONICO");

            //Ticket.AddFooterLine(remision.ImporteLetra);
            //Ticket.AddFooterLine(remision.formadepago);
            //Ticket.AddFooterLine("CLIENTE:" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
            Ticket.AddFooterLine(" ");
            Ticket.AddFooterLine("______________________________");
            Ticket.AddFooterLine("100% CONCENTRADOS EN SU SALUD");
            Ticket.AddFooterLine("NO HAY CAMBIOS NI DEVOLUCIONES");

            string impresora = SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets;

            if (!Ticket.PrinterExists(SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets))
            {
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    impresora = pd.PrinterSettings.PrinterName;
                }
                else
                {
                    return;
                }
            }

            Ticket.PrintTicket(impresora);
        }
        public bool GuardaRemision(SIFModelo.Remision remision, List<SIFModelo.RemisionDetalle> remisionDetalles, object convertidaDe)
        {

            SIFNegocio.Inventario.Inventario inventario = new Inventario.Inventario();
            foreach (var detalle in remisionDetalles)
            {

                if (detalle.IVA > 0)
                {
                    detalle.Nombre1 = "* " + detalle.Nombre1;
                }

                //detalle.FechaEntrega = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToShortDateString();
                if (detalle.CantidadRemision > 0)
                {
                    detalle.FolioControlado = "0";
                    //detalle.ImpuestoID = 0;
                    //detalle.IVA = detalle.IVA;
                    if (string.IsNullOrEmpty(detalle.Lote))
                    {
                        detalle.Lote = "0";
                    }
                    detalle.NumeroRemision = remision.NumeroRemision;
                    detalle.PaqueteID = 0;
                    detalle.SucursalID = remision.SucursalID;
                    detalle.Total = detalle.Precio + detalle.IVA;
                    //if (SIFDatos.Remision.InsertaRemisionDetalle(detalle))
                    //{
                    //detalle.FolioControlado = "0";
                    ////detalle.ImpuestoID = 0;
                    ////detalle.IVA = detalle.IVA;
                    //detalle.Lote = "0";
                    //detalle.NumeroRemision = remision.NumeroRemision;
                    //detalle.PaqueteID = 0;
                    //detalle.SucursalID = remision.SucursalID;
                    //detalle.Total = detalle.Precio + detalle.IVA;

                    SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
                    if (!((convertidaDe is SIFModelo.Apartado) || (convertidaDe is SIFModelo.Pedido)))
                        inventario.InventarioArticuloAparta(articulo, detalle.CantidadRemision);


                    //if (convertidaDe is SIFModelo.Apartado)
                    //{
                    //    SIFModelo.Apartado Apartado = convertidaDe as SIFModelo.Apartado;
                    //    if (Apartado.Anticipo > 0)
                    //        inventario.InventarioArticuloAparta(articulo, detalle.CantidadRemision);
                    //}

                    //}
                }

            }
            if (SIFDatos.Remision.InsertaRemisionBulk(remision, remisionDetalles))
            {

            }

            return true;

        }

        //public static void ImprimeTicketControlado(SIFModelo.Controlado controlado, List<SIFModelo.RemisionDetalle> detalles, SIFModelo.Medico medico, SIFModelo.Usuario usuarioRecibe)
        //{
        //    SIFModelo.Sucursal sucursal = Helpers.Sesion.Sucursal;

        //    if (usuarioRecibe == null)
        //    {
        //        usuarioRecibe = new SIFModelo.Usuario();
        //        usuarioRecibe.Nombre = " ";
        //        usuarioRecibe.Apellidos = " ";
        //    }

        //    if (medico == null)
        //    {
        //        medico = new SIFModelo.Medico();
        //        medico.Nombre = " ";
        //    }

        //    if (string.IsNullOrEmpty(medico.Nombre))
        //    {
        //        medico.Nombre = " ";
        //    }



        //    if (string.IsNullOrEmpty(usuarioRecibe.Nombre))
        //    {
        //        usuarioRecibe.Nombre = " ";
        //    }

        //    if (string.IsNullOrEmpty(usuarioRecibe.Apellidos))
        //    {
        //        usuarioRecibe.Apellidos = " ";
        //    }

        //    Helpers.Ticket Ticket = new Helpers.Ticket();
        //    Ticket.EsControlado = true;
        //    Ticket.AddHeaderLine("FARMACIAS FLEMING");
        //    Ticket.AddHeaderLine(" ");
        //    Ticket.AddHeaderLine("OPERADOR DE FARMACIAS A.F.");
        //    Ticket.AddHeaderLine("DEL CENTRO S. DE R.L. DE C.V.");
        //    Ticket.AddHeaderLine("R.F.C.: " + SIFNegocio.Configuracion.Configuraciones.Factura.RFCEmisor);

        //    Ticket.AddSubHeaderLine(" ");

        //    Ticket.AddSubHeaderLine(sucursal.Calle + " " + sucursal.NumeroExterior + " " + sucursal.Colonia);
        //    Ticket.AddSubHeaderLine(sucursal.Ciudad + " " + sucursal.Municipio + " C.P." + sucursal.CodigoPostal);
        //    Ticket.AddSubHeaderLine("TEL: " + sucursal.Telefono + " FAX:");
        //    Ticket.AddSubHeaderLine("SUCURSAL: " + sucursal.Nombre);

        //    Ticket.AddSubHeaderLine(" ");
        //    Ticket.AddSubHeaderLine("CONTROLADO:" + controlado.Folio);
        //    Ticket.AddSubHeaderLine("FECHA:" + controlado.FechaEntrega.ToString("dd/MM/yyyy HH:mm:ss"));

        //    Ticket.AddSubHeaderLine("RECIBE:" + usuarioRecibe.Nombre + " " + usuarioRecibe.Apellidos);
        //    Ticket.AddSubHeaderLine(" ");
        //    Ticket.AddSubHeaderLine("MEDICO:" + medico.Nombre);
        //    Ticket.AddSubHeaderLine("RETIENE RECETA:" + controlado.Retiene.ToString());
        //    //decimal subTotal = 0;
        //    foreach (SIFModelo.RemisionDetalle detalle in detalles)
        //    {
        //        //detalle.Total = detalle.PrecioDescontado * detalle.CantidadRemision;
        //        //subTotal += detalle.Precio * detalle.CantidadRemision;
        //        //decimal totalSinDescuento = detalle.Precio * detalle.CantidadRemision;
        //        //decimal importeDescontado = detalle.PrecioDescontado * detalle.CantidadRemision;
        //        //decimal descuentoGeneral = totalSinDescuento - importeDescontado;

        //        //if (totalSinDescuento < 0)
        //        //{
        //        //    totalSinDescuento = 0;

        //        //}
        //        //if (importeDescontado < 0)
        //        //{
        //        //    importeDescontado = 0;
        //        //}

        //        //if (descuentoGeneral < 0)
        //        //{
        //        //    descuentoGeneral = 0;
        //        //}

        //        //if (nadro == null)
        //        //{
        //        //decimal detalleTotal = detalle.Precio * detalle.CantidadRemision;
        //        //Ticket.AddItem(detalle.CantidadRemision.ToString(), detalle.ArticuloID, detalleTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1);
        //        ////}

        //        Ticket.AddItem(detalle.CantidadRemision.ToString(), detalle.ArticuloID, "", "", detalle.Nombre1);

        //        //else
        //        //{
        //        //    string detalleDescuento = "0";
        //        //    if (detalle.PorcentajeDescuento > 0)
        //        //    {
        //        //        detalleDescuento = detalle.PorcentajeDescuento.ToString("0.00") + "%";
        //        //    }
        //        //    else
        //        //    {
        //        //        if (detalle.MontoDescuento > 0)
        //        //        {
        //        //            detalleDescuento = detalle.MontoDescuento.ToString("C2");
        //        //        }
        //        //    }
        //        //    Ticket.AddItem(detalle.CantidadRemision.ToString(), detalle.ArticuloID, detalle.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1, detalleDescuento, detalle.PrecioDescontado.ToString("C2"), descuentoGeneral.ToString("C2"));
        //        //}

        //        //if (!string.IsNullOrEmpty(detalle.Lote) && detalle.Lote != "0")
        //        //{
        //        //    Ticket.AddItem("", "LOTE:" + detalle.Lote, detalle.Caducidad.Value.ToString("dd/MM/yyy"), "CAD", "");
        //        //}

        //    }

        //    //Ticket.AddTotal("SUBTOTAL:", subTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
        //    //Ticket.AddTotal("I.V.A.", controlado.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
        //    //Ticket.AddTotal("TOTAL", controlado.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));


        //    //Ticket.AddFooterLine("SERVICIO A DOMICILIO SIN COSTO");
        //    //Ticket.AddFooterLine("CORREO ELECTRONICO");


        //    //Ticket.AddFooterLine(remision.ImporteLetra);
        //    //Ticket.AddFooterLine(remision.formadepago);
        //    //Ticket.AddFooterLine("CLIENTE:" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
        //    Ticket.AddFooterLine(" ");
        //    Ticket.AddFooterLine("______________________________");
        //    Ticket.AddFooterLine("100% CONCENTRADOS EN SU SALUD");
        //    Ticket.AddFooterLine("NO HAY CAMBIOS NI DEVOLUCIONES");

        //    string impresora = SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets;

        //    if (!Ticket.PrinterExists(SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets))
        //    {
        //        PrintDialog pd = new PrintDialog();
        //        if (pd.ShowDialog() == DialogResult.OK)
        //        {
        //            impresora = pd.PrinterSettings.PrinterName;
        //        }
        //        else
        //        {
        //            return;
        //        }
        //    }

        //    Ticket.PrintTicket(impresora);
        //}


        public static void ImprimeTicketControlado(SIFModelo.Controlado controlado, List<SIFModelo.RemisionDetalle> detalles, SIFModelo.Medico medico, SIFModelo.Usuario usuarioRecibe)
        {
            SIFModelo.Sucursal sucursal = Helpers.Sesion.Sucursal;

            //if (usuarioRecibe == null)
            //{
            //    usuarioRecibe = new SIFModelo.Usuario();
            //    usuarioRecibe.Nombre = " ";
            //    usuarioRecibe.Apellidos = " ";
            //}

            if (medico == null)
            {
                medico = new SIFModelo.Medico();
                medico.Nombre = " ";
            }

            if (string.IsNullOrEmpty(medico.Nombre))
            {
                medico.Nombre = " ";
            }

            controlado.FolioAntibiotico = "";
            if (controlado.Retiene == SIFModelo.Tipos.SiNo.SI)
            {
                bool esAntibiotico = false;

                SIFNegocio.Articulo articuloL = new Articulo();
                foreach (var detalle in detalles)
                {
                    SIFModelo.Articulo articulo = articuloL.BuscarPorClave(detalle.ArticuloID);
                    string[] tipos = articulo.TIPO_MEDICAMENTO_CVE.Split('|');
                    foreach (string tipo in tipos)
                    {
                        if (tipo == "T3")
                        {
                            esAntibiotico = true;
                        }
                    }
                }

                if (esAntibiotico)
                    controlado.FolioAntibiotico = new SIFNegocio.Controlado().FolioAntibiotico(controlado);

            }
            //if (string.IsNullOrEmpty(usuarioRecibe.Nombre))
            //{
            //    usuarioRecibe.Nombre = " ";
            //}

            //if (string.IsNullOrEmpty(usuarioRecibe.Apellidos))
            //{
            //    usuarioRecibe.Apellidos = " ";
            //}

            //RECIBE
            SIFModelo.Usuario usuarioGenera = new SIFNegocio.Usuarios().UsuarioPorId(controlado.UsuarioID);

            //GENERA
            usuarioRecibe = new SIFNegocio.Usuarios().UsuarioPorId(controlado.EntregaID);

            Helpers.Ticket Ticket = new Helpers.Ticket();
            Ticket.EsControlado = true;
            Ticket.AddHeaderLine("FARMACIAS FLEMING");
            //Ticket.AddHeaderLine(" ");
            //Ticket.AddHeaderLine("OPERADOR DE FARMACIAS A.F.");
            //Ticket.AddHeaderLine("DEL CENTRO S. DE R.L. DE C.V.");
            //Ticket.AddHeaderLine("R.F.C.: " + SIFNegocio.Configuracion.Configuraciones.Factura.RFCEmisor);

            //Ticket.AddSubHeaderLine(" ");

            Ticket.AddSubHeaderLine(sucursal.Calle + " " + sucursal.NumeroExterior + " " + sucursal.Colonia);
            Ticket.AddSubHeaderLine(sucursal.Ciudad + " " + sucursal.Municipio + " C.P." + sucursal.CodigoPostal);
            Ticket.AddSubHeaderLine("TEL: " + sucursal.Telefono + " FAX:");
            Ticket.AddSubHeaderLine("SUCURSAL: " + sucursal.Nombre);

            Ticket.AddSubHeaderLine(" ");
            Ticket.AddSubHeaderLine("CONTROLADO:" + controlado.Folio);
            Ticket.AddSubHeaderLine("FECHA:" + controlado.FechaEntrega.ToString("dd/MM/yyyy HH:mm:ss"));
            Ticket.AddSubHeaderLine("GENERA:" + usuarioRecibe.AccesoID);
            Ticket.AddSubHeaderLine("RECIBE:" + usuarioGenera.AccesoID); // + " " + usuarioRecibe.Apellidos);
            //Ticket.AddSubHeaderLine(" ");
            Ticket.AddSubHeaderLine("MEDICO:" + medico.Nombre);
            Ticket.AddSubHeaderLine("RETIENE RECETA:" + controlado.Retiene.ToString() + " " + controlado.FolioAntibiotico);
            //decimal subTotal = 0;
            foreach (SIFModelo.RemisionDetalle detalle in detalles)
            {
                //detalle.Total = detalle.PrecioDescontado * detalle.CantidadRemision;
                //subTotal += detalle.Precio * detalle.CantidadRemision;
                //decimal totalSinDescuento = detalle.Precio * detalle.CantidadRemision;
                //decimal importeDescontado = detalle.PrecioDescontado * detalle.CantidadRemision;
                //decimal descuentoGeneral = totalSinDescuento - importeDescontado;

                //if (totalSinDescuento < 0)
                //{
                //    totalSinDescuento = 0;

                //}
                //if (importeDescontado < 0)
                //{
                //    importeDescontado = 0;
                //}

                //if (descuentoGeneral < 0)
                //{
                //    descuentoGeneral = 0;
                //}

                //if (nadro == null)
                //{
                //decimal detalleTotal = detalle.Precio * detalle.CantidadRemision;
                //Ticket.AddItem(detalle.CantidadRemision.ToString(), detalle.ArticuloID, detalleTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1);
                ////}

                Ticket.AddItem(detalle.CantidadRemision.ToString(), detalle.ArticuloID, "", "", detalle.Nombre1);

                //else
                //{
                //    string detalleDescuento = "0";
                //    if (detalle.PorcentajeDescuento > 0)
                //    {
                //        detalleDescuento = detalle.PorcentajeDescuento.ToString("0.00") + "%";
                //    }
                //    else
                //    {
                //        if (detalle.MontoDescuento > 0)
                //        {
                //            detalleDescuento = detalle.MontoDescuento.ToString("C2");
                //        }
                //    }
                //    Ticket.AddItem(detalle.CantidadRemision.ToString(), detalle.ArticuloID, detalle.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1, detalleDescuento, detalle.PrecioDescontado.ToString("C2"), descuentoGeneral.ToString("C2"));
                //}

                //if (!string.IsNullOrEmpty(detalle.Lote) && detalle.Lote != "0")
                //{
                //    Ticket.AddItem("", "LOTE:" + detalle.Lote, detalle.Caducidad.Value.ToString("dd/MM/yyy"), "CAD", "");
                //}

            }

            //Ticket.AddTotal("SUBTOTAL:", subTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            //Ticket.AddTotal("I.V.A.", controlado.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            //Ticket.AddTotal("TOTAL", controlado.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));


            //Ticket.AddFooterLine("SERVICIO A DOMICILIO SIN COSTO");
            //Ticket.AddFooterLine("CORREO ELECTRONICO");


            //Ticket.AddFooterLine(remision.ImporteLetra);
            //Ticket.AddFooterLine(remision.formadepago);
            //Ticket.AddFooterLine("CLIENTE:" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
            //Ticket.AddFooterLine(" ");
            //Ticket.AddFooterLine("______________________________");
            //Ticket.AddFooterLine("100% CONCENTRADOS EN SU SALUD");
            //Ticket.AddFooterLine("NO HAY CAMBIOS NI DEVOLUCIONES");

            string impresora = SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets;

            if (!Ticket.PrinterExists(SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets))
            {
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    impresora = pd.PrinterSettings.PrinterName;
                }
                else
                {
                    return;
                }
            }

            Ticket.PrintTicket(impresora);
        }

        public static void ImprimeTicket(SIFModelo.Remision remision, List<SIFModelo.RemisionDetalle> detalles, SIFModelo.WebServices.TarjetaPfizer tarjeta)
        {
            Helpers.Ticket Ticket = new Helpers.Ticket();
            SIFModelo.Sucursal sucursal = new SIFNegocio.Sucursales().SucursalPorID(remision.SucursalID);
            SIFModelo.Usuario vendedor = new SIFNegocio.Usuarios().UsuarioPorId(remision.VendedorID);

            Ticket.AddHeaderLine("FARMACIAS FLEMING");
            Ticket.AddHeaderLine(" ");
            Ticket.AddHeaderLine("OPERADOR DE FARMACIAS A.F.");
            Ticket.AddHeaderLine("DEL CENTRO S. DE R.L. DE C.V.");
            Ticket.AddHeaderLine("R.F.C.: " + SIFNegocio.Configuracion.Configuraciones.Factura.UsuarioFEL);

            Ticket.AddSubHeaderLine(" ");

            Ticket.AddSubHeaderLine(sucursal.Calle + " " + sucursal.NumeroExterior + " " + sucursal.Colonia);
            Ticket.AddSubHeaderLine(sucursal.Ciudad + " " + sucursal.Municipio + " C.P." + sucursal.CodigoPostal);
            Ticket.AddSubHeaderLine("TEL: " + sucursal.Telefono + " FAX:");
            Ticket.AddSubHeaderLine("SUCURSAL: " + sucursal.Nombre);
            Ticket.AddSubHeaderLine("NOTA:" + remision.NumeroRemision);
            Ticket.AddSubHeaderLine("FECHA:" + remision.FechaVenta.ToString("dd/MM/yyyy HH:mm:ss"));
            Ticket.AddSubHeaderLine("ATENDIO:" + vendedor.Nombre + " " + vendedor.Apellidos);

            Ticket.AddSubHeaderLine("RECETA:" + remision.Receta + " FACTURA:" + remision.Factura);

            foreach (SIFModelo.RemisionDetalle detalle in detalles)
            {
                detalle.Total = detalle.Precio * detalle.CantidadRemision;
                decimal totalSinDescuento = detalle.Precio * detalle.CantidadRemision;
                decimal importeDescontado = detalle.PrecioDescontado * detalle.CantidadRemision;
                decimal descuentoGeneral = totalSinDescuento - importeDescontado;

                if (detalle.IVA > 0)
                {
                    detalle.Nombre1 = "* " + detalle.Nombre1;
                }

                if (totalSinDescuento < 0)
                {
                    totalSinDescuento = 0;

                }
                if (importeDescontado < 0)
                {
                    importeDescontado = 0;
                }

                if (descuentoGeneral < 0)
                {
                    descuentoGeneral = 0;
                }

                string detalleDescuento = "0";
                if (detalle.PorcentajeDescuento > 0)
                {
                    detalleDescuento = detalle.PorcentajeDescuento.ToString("0.00") + "%";
                }
                else
                {
                    if (detalle.MontoDescuento > 0)
                    {
                        detalleDescuento = detalle.MontoDescuento.ToString("C2");
                    }
                }
                Ticket.AddItem(detalle.CantidadRemision.ToString(), detalle.ArticuloID, detalle.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Precio.ToString("C2", new System.Globalization.CultureInfo("ES-mx")), detalle.Nombre1, detalleDescuento, detalle.PrecioDescontado.ToString("C2"), descuentoGeneral.ToString("C2"));


                if (!string.IsNullOrEmpty(detalle.Lote) && detalle.Lote != "0")
                {
                    Ticket.AddItem("", "LOTE:" + detalle.Lote, detalle.Caducidad.Value.ToString("dd/MM/yyy"), "CAD", "");
                }
               
            }

            Ticket.AddTotal("SUBTOTAL:", remision.SubTotal.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            if (tarjeta != null)
            {
                Ticket.AddTotal("DSCTO. PFIZER:", remision.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            }
            else
            {
                Ticket.AddTotal("DESCUENTO:", remision.Descuento.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            }
            //Ticket.AddTotal("I.V.A.", remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
            Ticket.AddTotal("TOTAL", remision.Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));

            //if (nadro != null)
            //{
            Ticket.AddFooterLine("BENEFICIO PFIZER");
            if (!string.IsNullOrEmpty(tarjeta.NumeroConfirmacion) && tarjeta.NumeroConfirmacion != "0")
            {
                Ticket.AddFooterLine("NO. CONFIRMACION: " + tarjeta.NumeroConfirmacion);
            }
            Ticket.AddFooterLine("SESION: " + tarjeta.SesionID);
            Ticket.AddFooterLine("TARJETA: " + tarjeta.TarjetaID);
            //}

            if (remision.Impuesto > 0)
            {
                Ticket.AddFooterLine("I.V.A. INFORMATIVO: " + remision.Impuesto.ToString("C2", new System.Globalization.CultureInfo("ES-mx")));
                Ticket.AddFooterLine(" ");
            }

            //LGS 10/02/2014 Para que imprima en el ticket el tipo de descuento aplicado {INSEN,LOGO,...}
            if (remision.Condiciones != "NADRO" && remision.Condiciones != "PFIZER" && remision.Condiciones != "TAE" && remision.Condiciones != " " && remision.Condiciones.Length > 0)
            {
                Ticket.AddFooterLine("Beneficio " + remision.Condiciones + "%");
                Ticket.AddFooterLine(" ");
            }
            Ticket.AddFooterLine("SERVICIO A DOMICILIO SIN COSTO");
            Ticket.AddFooterLine("CORREO ELECTRONICO");


            //Ticket.AddFooterLine(remision.ImporteLetra);
            //Ticket.AddFooterLine(remision.formadepago);
            //Ticket.AddFooterLine("CLIENTE:" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
            Ticket.AddFooterLine(" ");
            Ticket.AddFooterLine("______________________________");
            Ticket.AddFooterLine("100% CONCENTRADOS EN SU SALUD");
            Ticket.AddFooterLine("NO HAY CAMBIOS NI DEVOLUCIONES");

            string impresora = SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets;

            if (!Ticket.PrinterExists(SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets))
            {
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    impresora = pd.PrinterSettings.PrinterName;
                }
                else
                {
                    return;
                }
            }

            Ticket.PrintTicket(impresora);
        }

        public bool ActualizaRemisionesFactura(List<SIFModelo.Remision> remisionFacturar, string numFactura)
        {
            return SIFDatos.Remision.ActualizaRemision(remisionFacturar, numFactura);
        }

        public static bool ActualizaStatusPago(SIFModelo.Remision remision, SIFModelo.Pagos pago)
        {
            return SIFDatos.Remision.ActualizaStatusPago(remision, pago);//Actualiza remisión a P
        }

        public SIFModelo.Remision FacturaDeRemision(SIFModelo.Remision remision)
        {
            remision = SIFDatos.Remision.FacturaDeRemision(remision);
            return remision;
        }
        public string obtPdf(string uiid)
        {
            return SIFDatos.Remision.getpdf(uiid);
        }
    }
}
