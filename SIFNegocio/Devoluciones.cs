using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio
{
    public class Devoluciones
    {
        public bool AgregaDevolucion(SIFModelo.Devolucion devolucion, List<SIFModelo.DevolucionDetalle> list, SIFModelo.WebServices.FelControl fc, SIFModelo.Usuario cajero)
        {
            if (string.IsNullOrEmpty(devolucion.Comentario))
            {
                devolucion.Comentario = "-";
            }
            devolucion.Detalles = list;
            if (SIFDatos.ValesDevolucions.InsertaDevolucionVTA(devolucion, fc))
            {
                decimal ultMovInv = 17;
                SIFDatos.Inventario.Inventario.ActualizaExistencia(Helpers.Sesion.Sucursal, list, cajero, devolucion, ultMovInv);

                //foreach (SIFModelo.DevolucionDetalle detalle in list)
                //{
                //    //SIFDatos.ValesDevolucions.InsertaDetalle(detalle);
                //    SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
                //    new SIFNegocio.Inventario.Inventario().InventarioArticuloAumenta(articulo, (int)detalle.Cantidad,devolucion.DevolucionID,17,short.Parse(detalle.NumeroPartida.ToString()),devolucion.UsuarioID.ToString());
                //}
            }
            else
            {
                return false;
            }

            return true;
        }

        public string NumeroDevolucion(SIFModelo.Sucursal sucursal)
        {
            string prefijoFolio = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yy");
            int numDevolucion = SIFDatos.ValesDevolucions.NumeroDevolucion(sucursal, prefijoFolio);

            string sb = sucursal.SucursalID.ToString("00") + prefijoFolio + numDevolucion.ToString().PadLeft(6, '0'); ;
            //sb = sb.PadLeft(15,'0');
            return sb;
        }

        public SIFModelo.Devolucion DevolucionPorNumero(string numeroVale, SIFModelo.Sucursal sucursal)
        {
            return SIFDatos.ValesDevolucions.BuscaPorNumeroDevolucion(numeroVale, sucursal);
        }

        public SIFModelo.Devolucion DevolucionPorRemision(string numRemision, SIFModelo.Sucursal sucursal)
        {
            return SIFDatos.ValesDevolucions.BuscaPorRemision(numRemision, sucursal);
        }

        public List<SIFModelo.DevolucionDetalle> DevolucionDetalle(string numeroVale, SIFModelo.Sucursal sucursal)
        {
            return SIFDatos.ValesDevolucions.BuscaDetalles(numeroVale, sucursal);
        }

        public  SIFModelo.Devolucion ReestructuraDevolucion(SIFModelo.Devolucion dev)
        {
            SIFModelo.Sucursal sucursal = new SIFNegocio.Sucursales().SucursalPorID(dev.SucursalID);
            dev.Detalles = DevolucionDetalle(dev.DevolucionID, sucursal);
        List<SIFModelo.DevolucionDetalle> detalles = DevolucionDetalle(dev.DevolucionID, sucursal);
            //NOTA CREDITO REMISION
            SIFModelo.Devolucion devolucion = dev;
            SIFNegocio.ClienteSubrogacion ClienteSubN = new SIFNegocio.ClienteSubrogacion();
            SIFModelo.ClienteSubrogaccion ClienteSub = ClienteSubN.ClientePorID(devolucion.ClienteID);
            SIFNegocio.ClienteConvenios clienteN = new SIFNegocio.ClienteConvenios();
            SIFModelo.ClienteConvenio ConvenioCliente = clienteN.ClientePorID(devolucion.ClienteID);


            devolucion.Descuento = 0;
            devolucion.SubTotal = 0;
            devolucion.TotalDevolucion = 0;
            devolucion.Detalles.Clear();
            foreach (var detalleRemision in detalles)
            {
                detalleRemision.Total = detalleRemision.Precio * detalleRemision.Cantidad;                

                devolucion.Descuento += detalleRemision.Descuento;

                //detalleRemision.IVA = 
                devolucion.Impuesto += detalleRemision.IVA;

                //detalleRemision.Precio = detalleRemision.Precio - detalleRemision.IVA;
                devolucion.SubTotal += detalleRemision.Total;

                devolucion.TotalDevolucion += detalleRemision.Total - detalleRemision.Descuento;

                devolucion.Detalles.Add(detalleRemision);
            }
            
            return devolucion;
        }

    }
}
