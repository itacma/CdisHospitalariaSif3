using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SIFNegocio.Inventario
{
    public class PedidosAlmacen
    {
        public SIFModelo.Inventarios.InventarioDataSet PedidosDataSet = new SIFModelo.Inventarios.InventarioDataSet();

        public SIFModelo.Inventarios.InventarioDataSet PedidosTraspasos(DateTime fechaInicio, DateTime fechaFin, String Activo, String Folio)
        {
            return SIFDatos.Inventario.PedidosAlmacen.GetPedidos(fechaInicio.ToString("dd/MM/yyyy HH:mm:ss"), fechaFin.ToString("dd/MM/yyyy HH:mm:ss"), Activo, Folio);
        }
        public SIFModelo.Inventarios.InventarioDataSet GetPedidosTraspaso(String NoFolio, int NoLote) //ROMA 15AGO2013
        {
            return SIFDatos.Inventario.PedidosAlmacen.GetPedidos(NoFolio, NoLote);
        }

        public void ActEstatus(string Folio, int[] Lote)
        {
            SIFDatos.Inventario.PedidosAlmacen.ActEstatus(Folio, Lote);
        }

        public void Enviapedidox(string Folio, int[] Lote, int Origen, int Destino,
                                 double Total, int[] Sec, String[] ArtId,
                                 String[] Concepto, int[] Cant, int[] CantE, double[] TotLote)
        {
            SIFDatos.Inventario.PedidosAlmacen.EnviaPedidoX(Folio, Lote, Origen, Destino, Total, Sec, ArtId, Concepto, Cant, CantE, TotLote);
        }

        public int CancelPedido(string NoFolio, string NoLote)
        {
             return SIFDatos.Inventario.PedidosAlmacen.CancelPedido(NoFolio, NoLote);
        }
        
        public int DuplicaPedido(string NoFolio, string NoLote)
        {
            return SIFDatos.Inventario.PedidosAlmacen.DuplicaPedido(NoFolio, NoLote,Helpers.Sesion.Sucursal.SucursalID.ToString());
        }

        public DataTable PedidoDetalle(string Folio, int Lote) 
        {
            return SIFDatos.Inventario.PedidosAlmacen.PedidoDet(Folio, Lote);
        }

        public short SigPart(SIFModelo.Inventarios.InventarioDataSet Pedido, int Lote)
        {var encontrado =from r in Pedido.PEDIDO_TRASP_DET where r.LOTE==Lote select r;
            int partida=encontrado.Count() + 1;

        return (short.Parse(partida.ToString()));
        }

        public void AgregaDetalle(SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow detalle,SIFModelo.Inventarios.InventarioDataSet Pedido)
        {
            var encontrado = from r in Pedido.PEDIDO_TRASP_DET where r.ARTICULO_ID == detalle.ARTICULO_ID select r;

            if (encontrado.Count() > 0)
            {
                SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow contenido = encontrado.FirstOrDefault<SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow>();
                //contenido.CANTIDAD_SOLIC = contenido.CANTIDAD_SOLIC + detalle.CANTIDAD_SOLIC;
                detalle.PARTIDA = contenido.PARTIDA;
                detalle.CANTIDAD_SOLIC = contenido.CANTIDAD_SOLIC + detalle.CANTIDAD_SOLIC; // ROMA 05OCT2013
                Pedido.PEDIDO_TRASP_DET.RemovePEDIDO_TRASP_DETRow(contenido);
                Pedido.PEDIDO_TRASP_DET.AddPEDIDO_TRASP_DETRow(detalle);
                //RecalculaDetalle(contenido, CotizacionM);
            }
            else
            {
                //detalle.NumeroPartida = pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET.Count + 1;
                //RecalculaDetalle(detalle, CotizacionM);
                Pedido.PEDIDO_TRASP_DET.AddPEDIDO_TRASP_DETRow(detalle);
            }
        }
        public void AgregaDetalleCantidad(SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow detalle, SIFModelo.Inventarios.InventarioDataSet Pedido)
        {
            var encontrado = from r in Pedido.PEDIDO_TRASP_DET where r.ARTICULO_ID == detalle.ARTICULO_ID select r;

            if (encontrado.Count() > 0)
            {
                SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow contenido = encontrado.FirstOrDefault<SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow>();
                //contenido.CANTIDAD_SOLIC = contenido.CANTIDAD_SOLIC + detalle.CANTIDAD_SOLIC;
                detalle.PARTIDA = contenido.PARTIDA;
                detalle.CANTIDAD_SOLIC = contenido.CANTIDAD_SOLIC; // ROMA 05OCT2013
                Pedido.PEDIDO_TRASP_DET.RemovePEDIDO_TRASP_DETRow(contenido);
                Pedido.PEDIDO_TRASP_DET.AddPEDIDO_TRASP_DETRow(detalle);
                //RecalculaDetalle(contenido, CotizacionM);
            }
            else
            {
                //detalle.NumeroPartida = pedidoAlmacenL.PedidosDataSet.PEDIDO_TRASP_DET.Count + 1;
                //RecalculaDetalle(detalle, CotizacionM);
                Pedido.PEDIDO_TRASP_DET.AddPEDIDO_TRASP_DETRow(detalle);
            }
        }
        public bool InsertaPedidoAlmacen(String Usuario,SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASPRow pedido, SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETDataTable detalles)
        {
            List<int> lote = new List<int>();
            List<string> ArtId = new List<string>();
            List<string> Concepto = new List<string>();
            List<int> Cant = new List<int>();
            List<decimal> TotLote = new List<decimal>();
            List<int> Sec = new List<int>();

            int secuencia = 1;
            var encontrado = from r in detalles where r.LOTE== 1 select r;

            foreach (SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow detalle in encontrado)
            {
                lote.Add(System.Convert.ToInt32( detalle.LOTE));
                ArtId.Add(detalle.ARTICULO_ID);
                Concepto.Add(detalle.CONCEPTO);
                Cant.Add(detalle.CANTIDAD_SOLIC);
                TotLote.Add(detalle.LOTE);
                Sec.Add(detalle.PARTIDA);
            }

            var encontrado1 = from r in detalles where r.LOTE == 2 select r;
            foreach (SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow detalle in encontrado1)
            {
                lote.Add(System.Convert.ToInt32(detalle.LOTE));
                ArtId.Add(detalle.ARTICULO_ID);
                Concepto.Add(detalle.CONCEPTO);
                Cant.Add(detalle.CANTIDAD_SOLIC);
                TotLote.Add(detalle.LOTE);
                Sec.Add(detalle.PARTIDA);

            }

            SIFDatos.Inventario.PedidosAlmacen.InsertaPedidoAlmacen(Usuario,pedido.SUCURSAL_GENERA, pedido.SUCURSAL_RECIBE, pedido.TOTAL, lote.ToArray(), Sec.ToArray(), ArtId.ToArray(), Concepto.ToArray(), Cant.ToArray(), TotLote.ToArray(),pedido.ID_MOTIVO_PEDIDO,pedido.REFERENCIA);

            return true;
        }


        public bool ActualizaPedidoAlmacen(SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASPRow pedido, SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETDataTable detalles)
        {
            List<int> lote = new List<int>();
            List<string> ArtId = new List<string>();
            List<string> TipMedic = new List<string>();
            List<string> Concepto = new List<string>();
            List<int> Cant = new List<int>();
            List<decimal> TotLote = new List<decimal>();
            List<int> Sec = new List<int>();

            int secuencia = 1;
            ////var encontrado = from r in detalles where r.LOTE == 1 select r;
            var encontrado = from r in detalles where r.LOTE == pedido.LOTE select r;

            foreach (SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow detalle in encontrado)
            {
                lote.Add(System.Convert.ToInt32(detalle.LOTE));
                ArtId.Add(detalle.ARTICULO_ID);
                ////if ( !detalle.IsTIPO_MEDICNull() )
                ////    TipMedic.Add(detalle.TIPO_MEDIC);
                //////if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("Usuario_Recibe")) == false)
                //////    rw.usuar.Value = _rdrObj.GetString(_rdrObj.GetOrdinal("Usuario_Recibe"));

                Concepto.Add(detalle.CONCEPTO);
                Cant.Add(detalle.CANTIDAD_SOLIC);
                TotLote.Add(detalle.LOTE);
                Sec.Add(detalle.PARTIDA);
            }
            SIFDatos.Inventario.PedidosAlmacen.ActualizaPedidoAlmacen(pedido.FOLIO, pedido.SUCURSAL_GENERA, pedido.SUCURSAL_RECIBE, pedido.TOTAL, lote.ToArray(), Sec.ToArray(), ArtId.ToArray(), Concepto.ToArray(), Cant.ToArray(), TotLote.ToArray(),pedido.REFERENCIA);
            lote.Clear();
            ArtId.Clear();
            Concepto.Clear();
            Cant.Clear();
            TotLote.Clear();
            Sec.Clear();
            /// ROMA BORRAR //
            //var encontrado1 = from r in detalles where r.LOTE == 2 select r;
            //foreach (SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETRow detalle in encontrado1)
            //{
            //    lote.Add(System.Convert.ToInt32(detalle.LOTE));
            //    ArtId.Add(detalle.ARTICULO_ID);
            //    Concepto.Add(detalle.CONCEPTO);
            //    Cant.Add(detalle.CANTIDAD_SOLIC);
            //    TotLote.Add(detalle.LOTE);
            //    Sec.Add(detalle.PARTIDA);
            //}

            //SIFDatos.Inventario.PedidosAlmacen.ActualizaPedidoAlmacen(pedido.FOLIO,
            //    pedido.SUCURSAL_GENERA, 
            //    pedido.SUCURSAL_RECIBE, 
            //    pedido.TOTAL, 
            //    lote.ToArray(), 
            //    Sec.ToArray(), 
            //    ArtId.ToArray(), 
            //    ////TipMedic.ToArray(), 
            //    Concepto.ToArray(), 
            //    Cant.ToArray(), 
            //    TotLote.ToArray() );

            return true;
        }

        public SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETDataTable PedidosPorEOQ(SIFModelo.Sucursal sucursal)
        {
            DataTable dt = SIFDatos.Inventario.PedidosAlmacen.GetPedidoEoQ(sucursal);

            foreach (DataRow row in dt.Rows)
            {
                PedidosDataSet.PEDIDO_TRASP_DET.ImportRow(row);
            }

            return PedidosDataSet.PEDIDO_TRASP_DET;

        }

        // ROMA 14AGO2013
        public string CreaPedidoEspecial(string Usuario, int Origen, int Destino,
                                 string[] ArtId, int[] Cant,int ID_MOTIVO_PEDIDO,string REFERENCIA)
        {
            return SIFDatos.Inventario.PedidosAlmacen.CreaPedidoEspecial(Usuario, Origen, Destino, ArtId, Cant,ID_MOTIVO_PEDIDO, REFERENCIA);
        }

        public int UpdateEdoPedido(string NoFolio, string NoLote)
        {
            return SIFDatos.Inventario.PedidosAlmacen.UpdateEdoPedido(NoFolio, NoLote);
        }

        public string CreaPedidoTraspaso(string NoFolio, string NoLote, int Origen, int Destino)
        {
            return SIFDatos.Inventario.PedidosAlmacen.CreaPedidoTraspaso(NoFolio, NoLote, Origen, Destino);
        }


        // ROMA 14AGO2013

    }
}
