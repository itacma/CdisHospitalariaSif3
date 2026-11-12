using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIFNegocio
{
    public class Apartado
    {
        public static List<SIFModelo.Apartado> Apartados = new List<SIFModelo.Apartado>();
        public List<SIFModelo.ApartadoDetalle> ApartadoDetalles = new List<SIFModelo.ApartadoDetalle>();

        public SIFModelo.Apartado ApartadoM = new SIFModelo.Apartado();

        public List<SIFModelo.Apartado> ApartadosNoPagados = new List<SIFModelo.Apartado>();

        public List<SIFModelo.ApartadoDetalle> CargaApartadosDetalles(SIFModelo.Apartado Apartado)
        {
            if (Apartado.Detalles != null && Apartado.Detalles.Count > 0)
            {
                return Apartado.Detalles;
            }

            this.ApartadoDetalles = SIFDatos.Apartado.CargaDetalles(Apartado);
            Apartado.Detalles = ApartadoDetalles;
            return Apartado.Detalles;
        }
        public bool ActualizaApartado(SIFModelo.Apartado apartado)
        {
            return SIFDatos.Apartado.ActualizaApartado(apartado);
        }

        public Boolean AgregaDetalle(SIFModelo.ApartadoDetalle detalle, SIFModelo.Articulo articulo,Boolean BExi)
        {

            Boolean Ext = false;
            string ArticuloID = detalle.ArticuloID;
            var encontrado = from r in ApartadoDetalles where r.ArticuloID == ArticuloID select r;
            // verificamos existencias y que el articulo no sea un articulo controlad
            SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();
            int existencias = 0;



            if (encontrado.Count() > 0)
            {
                SIFModelo.ApartadoDetalle contenido = encontrado.FirstOrDefault<SIFModelo.ApartadoDetalle>();
                if (BExi) //verificamos existencia
                {
                    if (inventario.InventarioArticulo(articulo, contenido.CantidadApartado + detalle.CantidadApartado, out existencias))
                    {
                        contenido.CantidadApartado = contenido.CantidadApartado+detalle.CantidadApartado;
                        contenido.Total = contenido.Precio * contenido.CantidadApartado;
                        Ext = false;
                    }
                    else
                    {
                        contenido.CantidadApartado = detalle.CantidadApartado;
                        Ext = true;
                    }


                }
                else
                {
                    if (inventario.InventarioArticulo(articulo, contenido.CantidadApartado + detalle.CantidadApartado, out existencias))
                    {
                        contenido.CantidadApartado = detalle.CantidadApartado;
                        Ext = false;
                    }
                    else
                    {
                        contenido.CantidadApartado = detalle.CantidadApartado;
                        Ext = true;
                    }

                }
            }
            else
            {
                if (BExi)
                {

                    if (inventario.InventarioArticulo(articulo, detalle.CantidadApartado, out existencias))
                    {
                       MessageBox.Show("El articulo no puede ser ingresado ya que hay uno sin existencia");
                        Ext = true;
                    }
                    else
                    {
                        detalle.NumeroPartida = ApartadoDetalles.Count + 1;
                        ApartadoDetalles.Add(detalle);
                        Ext = true;
                    }

                }
                else
                {
                    if (inventario.InventarioArticulo(articulo, detalle.CantidadApartado, out existencias))
                    {
                        detalle.NumeroPartida = ApartadoDetalles.Count + 1;
                        ApartadoDetalles.Add(detalle);
                        Ext = false;
                    }
                    else
                    {
                        if (ApartadoDetalles.Count <= 0)
                        {
                            detalle.NumeroPartida = ApartadoDetalles.Count + 1;
                            ApartadoDetalles.Add(detalle);
                            Ext = true;
                        }
                        else
                        {
                           MessageBox.Show("El articulo no puede ser ingresado ya que hay uno con existencia");
                            Ext = false;
                        }
                    }
                }
            }
            RecalculaDetalle(detalle, ApartadoM);
            return Ext;
        }

       
        public bool GuardaApartado(SIFModelo.Apartado Apartado, List<SIFModelo.ApartadoDetalle> ApartadoDetalles)
        {
            //if (SIFDatos.Apartado.InsertaApartado(Apartado))
            //{
            //    foreach (var detalle in ApartadoDetalles)
            //    {
            //        //detalle.FechaEntrega = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToShortDateString();
            //        //detalle.FolioControlado = "0";
            //        detalle.ImpuestoID = 0;
            //        detalle.IVA = 0;
            //        //detalle.Lote = "0";
            //        detalle.NumeroApartado = Apartado.NumeroApartado;
            //        detalle.PaqueteID = 0;
            //        detalle.SucursalID = Apartado.SucursalID;
            //        //detalle.Total = detalle.Precio;
            //        //SIFDatos.Apartado.InsertaApartadoDetalle(detalle);
            //    }

                return true;
            //}
            //return false;

        }


        //public System.Data.DataSet BuscaApartadoNoPagadas(SIFModelo.Sucursal sucursal)
        //{
        //    System.Data.DataSet ds = SIFDatos.Apartado.ApartadoNoPagadas(sucursal);
        //    return ds;
        //}

        public System.Data.DataSet BuscaApartadoNoPagadas(SIFModelo.Sucursal sucursal, SIFModelo.Apartado Apartado,Boolean todos)
        {
            System.Data.DataSet ds = SIFDatos.Apartado.ApartadosNoGenerados(sucursal, Apartado,todos);
            return ds;
        }

        public System.Data.DataSet BuscaApartado(SIFModelo.Sucursal sucursal, SIFModelo.Apartado Apartado, Boolean todos)
        {
            System.Data.DataSet ds = SIFDatos.Apartado.ApartadosNoGenerados(sucursal, Apartado,todos);
            return ds;
        }
        
        public System.Data.DataSet BuscaApartado(SIFModelo.Sucursal sucursal, SIFModelo.Apartado Apartado, Boolean todos, DateTime fecha1, DateTime fecha2)
        {
            System.Data.DataSet ds = SIFDatos.Apartado.ApartadosNoGenerados(sucursal, Apartado,todos,fecha1, fecha2);
            return ds;
        }

        public bool ContieneDetalle(SIFModelo.Articulo articulo)
        {
            var encontrado = from r in ApartadoDetalles where r.ArticuloID == articulo.ARTICULO_ID select r;

            if (encontrado.Count() > 0)
            {
                return true;
            }

            return false;
        }

        public void ModificaCantidad(SIFModelo.Articulo articulo, int cantidad)
        {
            var encontrado = from r in ApartadoDetalles where r.ArticuloID == articulo.ARTICULO_ID select r;

            if (encontrado.Count() > 0)
            {
                SIFModelo.ApartadoDetalle contenido = encontrado.FirstOrDefault<SIFModelo.ApartadoDetalle>();
                contenido.CantidadApartado = cantidad;

                RecalculaDetalle(contenido);
            }

        }

        public void ValidaDetallePedido(SIFModelo.Articulo articulo)
        {
            var encontrado = from r in ApartadoDetalles where r.ArticuloID == articulo.ARTICULO_ID select r;

            if (encontrado.Count() > 0)
            {
                SIFModelo.ApartadoDetalle contenido = encontrado.FirstOrDefault<SIFModelo.ApartadoDetalle>();
                contenido.Validado = true;

                //RecalculaDetalle(contenido);
            }

        }

        private void RecalculaDetalle(SIFModelo.ApartadoDetalle detalle)
        {
            SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
            if (precios == null)
            {
                return;
            }
            decimal importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.CantidadApartado * detalle.Precio);

            detalle.ImpuestoID = precios.IMP_VENTA;
            SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);
            if (impuesto != null)
            {


                decimal calculaImpuesto = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Total * (impuesto.Porcentaje / 100m));

                detalle.IVA = calculaImpuesto;
            }

            detalle.Total = importe;
        }

        public void RecalculaDetalle(List<SIFModelo.ApartadoDetalle> detalle, SIFModelo.Apartado Apartado)
        {
            ApartadoM.Descuento = 0;
            foreach (SIFModelo.ApartadoDetalle Det in detalle)
                RecalculaDetalle(Det, Apartado);
        }

        public void RecalculaDetalle(SIFModelo.ApartadoDetalle detalle, SIFModelo.Apartado Apartado)
        {
            decimal importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.CantidadApartado * detalle.Precio);
            detalle.Total = importe;
            SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
            importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.CantidadApartado * detalle.Precio);

            //detalle.Precio = detalle.Precio / (1 + (impuesto.Porcentaje / 100m));
            detalle.Precio = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(detalle.Precio);
            SIFNegocio.Articulo LogArt = new Articulo();
            SIFModelo.Articulo Articulo = LogArt.BuscarPorClave(detalle.ArticuloID);
            decimal descuento = 0;
            if (!Articulo.TIPO_MEDICAMENTO_CVE.Contains("SD"))
                descuento = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(importe * (Apartado.PorcentajeDescuento / 100));
            Apartado.Descuento = Apartado.Descuento + descuento;
            if (precios != null)
            {
                SIFModelo.Impuesto impuesto = new SIFNegocio.Impuestos().ImpuestoPorID(precios.IMP_VENTA);

                if (impuesto != null)
                {
                    
                    importe = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((importe - descuento));
                    decimal ImpAntesIva = importe / (1 + (impuesto.Porcentaje / 100m));

                    ImpAntesIva = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(ImpAntesIva);

                    decimal calculaImpuesto = importe - ImpAntesIva;
                    detalle.IVA = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(calculaImpuesto);

                }
            }
            //SIFModelo.Descuento descuento = 

            detalle.Total = importe;

        }


        public bool Cancela(SIFModelo.Apartado Apartado)
        {
            //if (Apartado.Condiciones == "PFIZER")
            //{
            //    SIFNegocio.WebServices.PFIZER pfizer = new SIFNegocio.WebServices.PFIZER();
            //    SIFModelo.WebServices.PfizerControl pc = pfizer.Control(Apartado);
            //    pfizer.Cancela(pc.Apartado_ID, pc.NO_TARJETA);
            //}
            
            return SIFDatos.Apartado.Cancela(Apartado);
        }

        public void CancelaPedidosyApartados24HRS(SIFModelo.Sucursal sucursal)
        {
            foreach (SIFModelo.Apartado Apartado in SIFDatos.Apartado.ApartadoPendientes24hrs(sucursal))
            {
                SIFDatos.Apartado.Cancela(Apartado);
            }
        }

        public List<SIFModelo.ApartadoDetalle> CargaDetalles(SIFModelo.Apartado Apartado)
        {
            return SIFDatos.Apartado.CargaDetalles(Apartado);
        }

        

        public bool Inserta(SIFModelo.Apartado Apartado)
        {
            return SIFDatos.Apartado.Inserta(Apartado);
        }

        public bool InsertaBulk(SIFModelo.Apartado Apartado, List<SIFModelo.ApartadoDetalle> detalles)
        {
            return SIFDatos.Apartado.InsertaBulk(Apartado, detalles);
        }

        public bool InsertaDetalle(SIFModelo.ApartadoDetalle ApartadoDetalle)
        {
            return SIFDatos.Apartado.InsertaDetalle(ApartadoDetalle);
        }

        public int GuardaDatos(SIFNegocio.Apartado LogicaApartado)
        {

            if (LogicaApartado.ApartadoDetalles.Count == 0)
            {
                return 1;

            }


            if (LogicaApartado.ApartadoM.ClienteID == 0 || LogicaApartado.ApartadoM.ClienteID == 1 || LogicaApartado.ApartadoM.ClienteID == 0)
            {
                return 2;

            }


            //SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(LogicaApartado.ApartadoM.ClienteID);
            //if (cliente.Convenio == SIFModelo.Tipos.SiNo.SI)
            //{
            //    LogicaApartado.ApartadoM.TipoCotizacion = SIFModelo.Tipos.TipoCotizacion.CONVENIO;
            //}
            //else
            //{
            //    LogicaApartado.ApartadoM.TipoCotizacion = SIFModelo.Tipos.TipoCotizacion.VENTA;
            //}


            //cotizacion.Total = logica.Total;
            if (string.IsNullOrEmpty(LogicaApartado.ApartadoM.NumeroCredencial))
            {
                LogicaApartado.ApartadoM.NumeroCredencial = "0";
            }



            int numeroPartida = 1;
            LogicaApartado.ApartadoM.FechaApartado = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            if (LogicaApartado.ApartadoM.Receta !=SIFModelo.Tipos.SiNo.SI)
            LogicaApartado.ApartadoM.Receta = SIFModelo.Tipos.SiNo.NO;
            if (LogicaApartado.ApartadoM.Factura != SIFModelo.Tipos.SiNo.SI)
            LogicaApartado.ApartadoM.Factura = SIFModelo.Tipos.SiNo.NO;
            
            LogicaApartado.ApartadoM.Activo = SIFModelo.Tipos.SiNo.SI;
            //if (!LogicaApartado.Inserta(LogicaApartado.ApartadoM))
            //{
            //    return 3;
            //}
            SIFNegocio.Inventario.Inventario inventario = new Inventario.Inventario();
            foreach (SIFModelo.ApartadoDetalle detalle in LogicaApartado.ApartadoDetalles)
            {
                detalle.NumeroPartida = numeroPartida;
                detalle.NumeroApartado = LogicaApartado.ApartadoM.NumeroApartado;
                detalle.SucursalID = LogicaApartado.ApartadoM.SucursalID;
                //LogicaApartado.InsertaDetalle(detalle);
                SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
                if (LogicaApartado.ApartadoM.Anticipo==0 )
                inventario.InventarioArticuloAparta(articulo, detalle.CantidadApartado);
                numeroPartida++;
            }

            if (!LogicaApartado.InsertaBulk(LogicaApartado.ApartadoM, LogicaApartado.ApartadoDetalles))
            {
                return 3;
            }


            return 0;

        }


        public string NumeroApartado(int sucursalID)
        {
            string prefijoFolio = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yy");

            int numApartado = SIFDatos.Apartado.NumeroApartado(sucursalID, prefijoFolio);

            string sb = sucursalID.ToString("00") + prefijoFolio + numApartado.ToString().PadLeft(11, '0');
            //sb = sb.PadLeft(15,'0');
            return sb;
        }
    }
}
