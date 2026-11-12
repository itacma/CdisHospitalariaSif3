using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
namespace SIFNegocio
{
    public class Pedidos
    {
        public SIFModelo.Pedido Pedido = new SIFModelo.Pedido();
        public List<SIFModelo.Articulo> articulosFaltantes = new List<SIFModelo.Articulo>();

        public static List<SIFModelo.Pedido> Pedidoes = new List<SIFModelo.Pedido>();
        public List<SIFModelo.PedidoDetalle> PedidoDetalles = new List<SIFModelo.PedidoDetalle>();
        public static float campanaD=0F;
        public void AgregaDetalle(ref SIFModelo.PedidoDetalle detalle, SIFModelo.Articulo articulo, ref SIFNegocio.Pedidos LogPedido)
        {
            string ArticuloID = detalle.ArticuloID;
            var encontrado = from r in PedidoDetalles where r.ArticuloID == ArticuloID select r;
            // verificamos existencias y que el articulo no sea un articulo controlad
            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
            int existencias = 0;


           
            if (encontrado.Count() > 0)
            {
                SIFModelo.PedidoDetalle contenido = encontrado.FirstOrDefault<SIFModelo.PedidoDetalle>();
                if (inventario.InventarioArticulo(articulo, contenido.CantidadPedido + detalle.CantidadPedido, out existencias))
                {
                    contenido.CantidadPedido = contenido.CantidadPedido + detalle.CantidadPedido;
                    contenido.Total = contenido.Precio * contenido.CantidadPedido;
                }
                else
                {

                    if (MessageBoxEx.Show("¿Agregar a la lista de artículos faltantes el artículo " + articulo.ARTICULO_ID + " [" + articulo.NOMBRE1 + "] ?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        articulo.TIPO_MONEDA = contenido.CantidadPedido - existencias;
                        LogPedido.articulosFaltantes.Add(articulo);
                    }

                    detalle.CantidadPedido = contenido.CantidadPedido;
                    contenido.CantidadPedido = contenido.CantidadPedido;
                }
            }
            else
            {
                if (inventario.InventarioArticulo(articulo, detalle.CantidadPedido, out existencias))
                {
                    detalle.NumeroPartida = PedidoDetalles.Count + 1;
                    PedidoDetalles.Add(detalle);
                }
                else
                {
                    if (MessageBoxEx.Show("¿Agregar a la lista de artículos faltantes el artículo " + articulo.ARTICULO_ID + " [" + articulo.NOMBRE1 + "] ?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        articulo.TIPO_MONEDA = detalle.CantidadPedido - existencias;
                        LogPedido.articulosFaltantes.Add(articulo);
                        
                    }
                }
            }
            RecalculaDetalle(detalle);
        }
        public bool ContieneDetalles(SIFModelo.Articulo Articulo)
        {
            var encontrado = from r in PedidoDetalles where r.ArticuloID == Articulo.ARTICULO_ID select r;
            if (encontrado.Count() > 0)
                return true;
            else
                return false;
        }

        private void RecalculaDetalle(SIFModelo.PedidoDetalle detalle)
        {
            decimal importe = detalle.CantidadPedido * detalle.Precio;
            detalle.Total = importe;
        }

        public System.Data.DataSet BuscaPedidosNoGenerados(SIFModelo.Sucursal sucursal, SIFModelo.Pedido Pedido, Boolean todos)
        {
            System.Data.DataSet ds = SIFDatos.Pedidos.PedidosNoGenerados(sucursal, Pedido, todos);
            return ds;
        }

        public System.Data.DataSet BuscaPedidosNoGenerados(SIFModelo.Sucursal sucursal, SIFModelo.Pedido Pedido, Boolean todos, DateTime fecha1, DateTime fecha2)
        {
            System.Data.DataSet ds = SIFDatos.Pedidos.PedidosNoGenerados(sucursal, Pedido, todos, fecha1, fecha2);
            return ds;
        }

        public void ModificaCantidad(SIFModelo.Articulo articulo, int cantidad)
        {
            var encontrado = from r in PedidoDetalles where r.ArticuloID == articulo.ARTICULO_ID select r;

            if (encontrado.Count() > 0)
            {
                SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
                int existencias = 0;

                SIFModelo.PedidoDetalle contenido = encontrado.FirstOrDefault<SIFModelo.PedidoDetalle>();
                if (inventario.InventarioArticulo(articulo, cantidad, out existencias))
                {
                    contenido.CantidadPedido = cantidad;
                    RecalculaDetalle(contenido);
                }
                else
                {
                    contenido.CantidadPedido = existencias;
                    RecalculaDetalle(contenido);
                }
            }

        }
        public bool ContieneDetalle(SIFModelo.Articulo articulo)
        {
            var encontrado = from r in PedidoDetalles where r.ArticuloID == articulo.ARTICULO_ID select r;

            if (encontrado.Count() > 0)
            {
                return true;
            }

            return false;
        }
        public void RecalculaDetalle(List<SIFModelo.PedidoDetalle> detalle, SIFModelo.Pedido Pedido)
        {
            Pedido.Descuento = 0;
            foreach (SIFModelo.PedidoDetalle Det in detalle)
                RecalculaDetalle(Det, Pedido);
        }

        public void RecalculaDetalle(SIFModelo.PedidoDetalle detalle, SIFModelo.Pedido Pedido)
        {
            SIFModelo.ClienteSubrogaccion ClienteSub;
            SIFNegocio.ClienteSubrogacion ClienteSubN = new SIFNegocio.ClienteSubrogacion();
            ClienteSub = ClienteSubN.ClientePorID(Pedido.ClienteID);
            if (ClienteSub == null)
            {
               /* SIFModelo.ClienteConvenio ClienteC;
                SIFNegocio.ClienteConvenios ClienteCon = new SIFNegocio.ClienteConvenios();
                ClienteC = ClienteCon.ClientePorID(Pedido.ClienteID);
                if (ClienteC != null  )
                    Pedido.PorcentajeDescuento = ClienteC.PorDesc;*/


                decimal importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.CantidadPedido * detalle.Precio);
                //decimal importe = (detalle.CantidadPedido * detalle.Precio);
                detalle.Total = importe;
                SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
                decimal descuento = 0;
                decimal precioantesdesc = 0;
                if (precios != null)
                {
                    
                    precioantesdesc = precios.PRECIO_VENTA;
                    // SIFModelo.Remision remision = new SIFModelo.Remision();
                    //List<SIFModelo.Remision> Remisiones = new List<SIFModelo.Remision>();
                    //List<SIFModelo.RemisionDetalle> RemisionDetalles = new List<SIFModelo.RemisionDetalle>();
                    // SIFNegocio.Remision logica = new SIFNegocio.Remision(); 
                    // const string PROVEEDOR_NADRO = "NADRO";

                    SIFNegocio.OrdenCompra.ManejoDescuentos descuentosL = new SIFNegocio.OrdenCompra.ManejoDescuentos();
                    //buscar ofertas
                    SIFModelo.Articulo articulo = new SIFModelo.Articulo();
                    articulo.ARTICULO_ID = detalle.ArticuloID;
                    var listaOfertaVenta = descuentosL.DescuentoActivo(articulo);




                    //   if (listaOfertaVenta)
                    //  {


                    if (listaOfertaVenta != null)
                    {
                        decimal d = System.Convert.ToInt32(listaOfertaVenta.DESCUENTO);
                        //SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
                        //detalle.PrecioCosto = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_COSTO);
                        if (listaOfertaVenta.APLICADO_A == "P")
                            // {
                            detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_VENTA_MAX);
                        //detalle.PrecioDescontado = precios.PRECIO_VENTA_MAX - (precios.PRECIO_VENTA_MAX * ((decimal)listaOfertaVenta.DESCUENTO / 100m));
                        //Pedido.PorcentajeDescuento = System.Convert.ToInt32(listaOfertaVenta.DESCUENTO);
                        //detalle.RefOferta = listaOfertaVenta.LISTA_OFERTAS_ID;
                        // Pedido.Comentario = Pedido.Comentario + " Oferta Id: " + listaOfertaVenta.LISTA_OFERTAS_ID + " Monto Descuento " + listaOfertaVenta.DESCUENTO + "%";
                        //importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.CantidadPedido * detalle.Precio);
                        campanaD = listaOfertaVenta.DESCUENTO;
                        // importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.CantidadPedido * detalle.Precio);
                        // detalle.MontoDescuento = detalle.Precio - detalle.PrecioDescontado;
                        descuento = precioantesdesc * (d / 100);
                        //}
                        //

                        if (listaOfertaVenta.APLICADO_A == "F")
                        {
                            detalle.Precio = precios.PRECIO_VENTA - (precios.PRECIO_VENTA * ((decimal)listaOfertaVenta.DESCUENTO / 100m));
                            // Pedido.PorcentajeDescuento = (decimal)listaOfertaVenta.DESCUENTO;
                            // detalle.MontoDescuento = (precios.PRECIO_VENTA * ((decimal)listaOfertaVenta.DESCUENTO / 100m));

                            detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
                            //detalle.Precio = precios.PRECIO_VENTA;
                            //detalle.RefOferta = listaOfertaVenta.LISTA_OFERTAS_ID;
                            // Pedido.Comentario = Pedido.Comentario + " Oferta Id: " + listaOfertaVenta.LISTA_OFERTAS_ID + " Monto Descuento " + listaOfertaVenta.DESCUENTO + "%";
                            //importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.CantidadPedido * detalle.Precio);
                            //  importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.CantidadPedido * detalle.Precio);
                            //  SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(
                            descuento = precioantesdesc * (d / 100);//POR
                            detalle.Precio = precioantesdesc;
                            campanaD = listaOfertaVenta.DESCUENTO;
                        }
                        // }

                    }
                    else { campanaD = 0F; }


                    SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);
                    importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.CantidadPedido * detalle.Precio);//IMPORTE DE LA PARTIDA

                    //detalle.Precio = detalle.Precio / (1 + (impuesto.Porcentaje / 100m));
                    detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio); //PRECIO UNITARIO DE LA PARTIDA
                    SIFNegocio.Articulo LogArt = new Articulo();
                    SIFModelo.Articulo Articulo = LogArt.BuscarPorClave(detalle.ArticuloID);

                    // el descuento lo esta calculando esta mal lo tiene k calcular sin descuento
                    if (!Articulo.TIPO_MEDICAMENTO_CVE.Contains("SD"))//SI EL PRODUCTO ES SUJETO A DESCUENTO
                    {
                        //Pedido.

                      //  descuento += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_VENTA) * ((Pedido.PorcentajeDescuento / 100)*detalle.CantidadPedido);// SI EL PRODUCTO ES SUJETO A DESCUENTO, LO APLICAMOS
                        descuento += SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((precios.PRECIO_VENTA ) * (Pedido.PorcentajeDescuento / 100)) );// SI EL PRODUCTO ES SUJETO A DESCUENTO, LO APLICAMOS
                        //MessageBox.Show(descuento.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Este producto no aplica descuento: " + Articulo.ARTICULO_ID.ToString() + " " + Articulo.NOMBRE1);
                    }

                    //if (Pedido.Descuento == 0)//L 16/12/2013 PARA NO DUPLICAR DESCUENTOS

                    if (impuesto != null)
                    {
                        

                        importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((precios.PRECIO_VENTA - descuento)*detalle.CantidadPedido);
                        decimal ImpAntesIva = importe / (1 + (impuesto.Porcentaje / 100m));

                        ImpAntesIva = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(ImpAntesIva);

                        decimal calculaImpuesto = importe - ImpAntesIva;
                        detalle.IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(((importe / (1 + (impuesto.Porcentaje / 100m))) * (impuesto.Porcentaje / 100m)) );
                        detalle.MontoDescuento = descuento * detalle.CantidadPedido;
                    }
                }

                //SIFModelo.Descuento descuento = 
                //Pedido.Descuento = Pedido.Descuento + descuento;
                //detalle.Total = importe;
            }
            else
            {
            }
        }

        public bool Cancela(SIFModelo.Pedido Pedido)
        {
            return SIFDatos.Pedidos.Cancela(Pedido);
        }



        public List<SIFModelo.PedidoDetalle> CargaDetalles(SIFModelo.Pedido pedido)
        {
            this.PedidoDetalles = SIFDatos.Pedidos.CargaDetalles(pedido);
            return PedidoDetalles;
        }

        public bool ActualizaPedido(SIFModelo.Pedido pedido)
        {
            return SIFDatos.Pedidos.ActualizaPedido(pedido);
        }

        public bool Inserta(SIFModelo.Pedido Pedido)
        {
            return SIFDatos.Pedidos.Inserta(Pedido);
        }

        public bool Inserta(SIFModelo.Pedido Pedido, List<SIFModelo.PedidoDetalle> Detalles)
        {
            if (string.IsNullOrEmpty(Pedido.NumeroCredencial))
                Pedido.NumeroCredencial = " ";
            return SIFDatos.Pedidos.Inserta(Pedido, Detalles);
        }

        public SIFModelo.Pedido ObtenPedidoVenta(String NoVentaPedido)
        {
            return SIFDatos.Pedidos.ObtenPedido(NoVentaPedido);
        }


        public bool InsertaDetalle(SIFModelo.PedidoDetalle PedidoDetalle)
        {
            return SIFDatos.Pedidos.InsertaDetalle(PedidoDetalle);
        }

        public int GuardaDatos(SIFNegocio.Pedidos LogicaPedido)
        {

            if (LogicaPedido.PedidoDetalles.Count == 0)
            {
                return 1;

            }


            if (LogicaPedido.Pedido.ClienteID == 0 || LogicaPedido.Pedido.ClienteID == 1 || LogicaPedido.Pedido.ClienteID == 0)
            {
                return 2;

            }

            int numeroPartida = 1;
            LogicaPedido.Pedido.FechaPedido = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            if (LogicaPedido.Pedido.Receta != SIFModelo.Tipos.SiNo.SI)
                LogicaPedido.Pedido.Receta = SIFModelo.Tipos.SiNo.NO;

            LogicaPedido.Pedido.Activo = SIFModelo.Tipos.SiNo.SI;

            if (LogicaPedido.Pedido.Factura != SIFModelo.Tipos.SiNo.SI)
                LogicaPedido.Pedido.Factura = SIFModelo.Tipos.SiNo.NO;

            //if (!LogicaPedido.Inserta(LogicaPedido.Pedido))
            //{
            //    return 3;
            //}

            SIFNegocio.Inventario.Inventario inventario = new Inventario.Inventario();

            foreach (SIFModelo.PedidoDetalle detalle in LogicaPedido.PedidoDetalles)
            {
                detalle.NumeroPartida = numeroPartida;
                detalle.NumeroPedido = LogicaPedido.Pedido.NumeroPedido;
                detalle.SucursalID = LogicaPedido.Pedido.SucursalID;
                //LogicaPedido.InsertaDetalle(detalle);
                SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
                if (LogicaPedido.Pedido.SucursalID == Helpers.Sesion.Sucursal.SucursalID)
                {
                    inventario.InventarioArticuloAparta(articulo, detalle.CantidadPedido);
                }
                
                numeroPartida++;
            }

            if (!LogicaPedido.Inserta(LogicaPedido.Pedido, LogicaPedido.PedidoDetalles))
            {
                return 3;
            }

            return 0;

        }


        public string NumeroPedido(SIFModelo.Sucursal sucursal)
        {
            string sb;
            if (sucursal.SucursalID == Helpers.Sesion.Sucursal.SucursalID)
            {
                string prefijoFolio = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yy");

                int numPedido = SIFDatos.Pedidos.NumeroPedido(sucursal.SucursalID, prefijoFolio);

                 sb = sucursal.SucursalID.ToString("00") + prefijoFolio + numPedido.ToString().PadLeft(11, '0');
            } 
            else
            {
            string prefijoFolio = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yyyy");

            int numPedido = SIFDatos.Pedidos.NumeroPedido(sucursal.SucursalID, prefijoFolio);

             sb = sucursal.SucursalID.ToString("00") + prefijoFolio + numPedido.ToString().PadLeft(11, '0');
            //sb = sb.PadLeft(15,'0');
            }
            return sb;
        }
        public string NumeroPedido(int sucursalID)
        {
            string sb;
            if (sucursalID == Helpers.Sesion.Sucursal.SucursalID)
            {
                string prefijoFolio = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yy");

                int numPedido = SIFDatos.Pedidos.NumeroPedido(sucursalID, prefijoFolio);

                 sb = sucursalID.ToString("00") + prefijoFolio + numPedido.ToString().PadLeft(11, '0');
            }
            else
            {
                string prefijoFolio = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yyyy");

                int numPedido = SIFDatos.Pedidos.NumeroPedidoF(sucursalID, prefijoFolio);

                sb = sucursalID.ToString("00") + prefijoFolio + numPedido.ToString().PadLeft(9, '0');
            }
            //sb = sb.PadLeft(15,'0');
            return sb;
        }

        public SIFModelo.Cliente cliente { get; set; }

        public static bool RecalculaDetalle()
        {
            throw new NotImplementedException();
        }

        // <summary>
        /// AVM 10-04-2015
        /// consulta a datos los pedidos por la fecha actual
        /// </summary>
        /// <param name="toDay"></param> la fecha actual
        /// <returns></returns>
        public static Boolean PedidosLimiteHoy(String toDay, SIFModelo.MotivoPedido MotivoPedido)
        {
            return SIFDatos.Pedidos.PedidosLimiteHoy(toDay, MotivoPedido);
        }
    }
}
