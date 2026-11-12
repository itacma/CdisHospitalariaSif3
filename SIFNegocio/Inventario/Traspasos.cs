using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Equin.ApplicationFramework;


namespace SIFNegocio.Inventario
{
    public class Traspasos
    {
        public SIFModelo.Inventarios.InventarioDataSet TraspasosDataSet = new SIFModelo.Inventarios.InventarioDataSet();

        public SIFModelo.Inventarios.InventarioDataSet GetTraspasos(DateTime fechaInicio, DateTime fechaFin,string Activo,string Folio, int Suc, string Tipo, int sucursalDestino = -1, int tipoPetido = -1)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.GetTraspasos(fechaInicio.ToString("dd/MM/yyyy HH:mm:ss"), fechaFin.ToString("dd/MM/yyyy HH:mm:ss"), Activo, Folio, Suc, Tipo,sucursalDestino,tipoPetido);
        }


        public string Cancel_Traspaso(string NoFolio, string NoLote)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.Cancel_Traspaso(NoFolio, NoLote);
        }

        public SIFModelo.Inventarios.InventarioDataSet GetTraspasos(string Folio)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.GetTraspasos( Folio,Helpers.Sesion.Sucursal);
        }

        public DataTable GetTraspasoDet(string Folio, int Lote)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.GetTraspasoDet(Folio, Lote, Helpers.Sesion.Sucursal);
        }
        public DataTable GetTraspasoDetFilas(string Folio, int Lote, string filas)
        {
           // return SIFDatos.Inventario.TraspasoAlmacen.GetTraspasoDet(Folio, Lote, Helpers.Sesion.Sucursal, filas);
            return SIFDatos.Inventario.TraspasoAlmacen.GetTraspasoDetFilas(Folio, Lote, Helpers.Sesion.Sucursal, filas);
        }
        public DataTable GetTraspasoInc(string Folio, int Lote)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.GetTraspasoDet(Folio, Lote, Helpers.Sesion.Sucursal);
        }

        public SIFModelo.Inventarios.InventarioDataSet GetTraspasoDet(string Ini, string Fin)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.GetTraspasoDet(Ini, Fin);
        }

        public int CancelTraspaso(string NoFolio, string NoLote)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.CancelTraspaso(NoFolio, NoLote);
        }
        public int Cancela_Destruccion(string NoFolio, string NoLote)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.CancelaDestruccion(NoFolio, NoLote);
        }
        public int Cancela_Devolucion(string NoFolio)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.CancelaDevolucion(NoFolio);
        }
        public int CancelarMovimiento(string NoFolio, string mov)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.CancelaMovimiento(NoFolio,mov);
        }
        public int Cancela_Ajuste(string NoFolio, string NoLote)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.CancelAjuste(NoFolio, NoLote);
        }

        public int CierraTraspaso(string UsuariosID ,string NoFolio, string NoLote)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.CierraTraspaso(UsuariosID,NoFolio, NoLote, Helpers.Sesion.Sucursal.SucursalID);
        }
        public int CierraTraspaso21(string UsuariosID, string NoFolio, string NoLote)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.CierraTraspasos21(UsuariosID, NoFolio, NoLote, Helpers.Sesion.Sucursal.SucursalID);
        }
        public string ValidaLInterno(string Folio,string lote, int mov)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.VerificarProcesados(Folio,lote, mov);
        }
        public string ValidaSalida3(string Folio, string lote)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.ValidaSalida3(Folio, lote);
        }

        public int CierraTraspasoRec(string UsuariosID, string NoFolio, string NoLote)
        {
            int i= SIFDatos.Inventario.TraspasoAlmacen.CierraTraspasoRec(UsuariosID, NoFolio, NoLote, Helpers.Sesion.Sucursal.SucursalID);
            SIFDatos.Inventario.TraspasoAlmacen.AsginaCaduciadesTraspasoSalida(NoFolio + "-" + NoLote, 3);
            return i;
        }
        public int AplicaIncidencia(string UsuariosID, string NoFolio, string NoLote,int Sucursal)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.AplicaIncidencia(UsuariosID, NoFolio, NoLote, Sucursal);
        }

        public int UpdTraspaso(string Folio, int[] Lote, double Total,
                                int[] Sec, String[] ArtId,
                                String[] Concepto, int[] CantS, int[] CantE, int[] CantR, int[] CantD, double[] PrecioE, double[] PrecioR, 
                                int[] Caja, String[] Pedido, string Usr_Envia, String Usr_Recibe, String[] NoLote, String[] FechaCad)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.UpdTraspaso(Folio, Lote, Total, Sec, ArtId, Concepto, CantS, CantE, CantR, CantD, PrecioE, PrecioR, Caja, Pedido,Usr_Envia, Usr_Recibe, NoLote, FechaCad);
        }

        public String InsertaTraspasoAlmacen(String Usuario,int Origen,int Destino,decimal Total,
                           int[] Lote,int[] Sec,String[] ArtId,String[] Concepto,int[] Cant,int[] CantE, 
                           int[] CantR,decimal[] TotLote,Double[] Precio,int[] Caja,
                           String[] NoLote,String[] FechaCad,int MOTIVO)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.InsertaTraspasoAlmacen(Usuario, Origen, Destino, 
                            Total,Lote, Sec, ArtId,Concepto, CantE, TotLote, Precio,Caja,NoLote,FechaCad,MOTIVO);
        }

        public bool InsertaTraspasoAlmacen(String UsuarioID, SIFModelo.Inventarios.InventarioDataSet.TRASPASORow traspaso, SIFModelo.Inventarios.InventarioDataSet.TRASPASO_DETDataTable detalles, int MOTIVO)
        {
            List<int> lote = new List<int>();
            List<string> ArtId = new List<string>();
            List<string> Concepto = new List<string>();
            List<int> Cant = new List<int>();
            List<decimal> TotLote = new List<decimal>();
            List<int> Sec = new List<int>();
            List<Double> Precio = new List<Double>();
            List<int> Caja = new List<int>();
            List<string> Nolote = new List<string>();
            List<string> FecCad = new List<string>();
            int secuencia = 1;
            foreach (SIFModelo.Inventarios.InventarioDataSet.TRASPASO_DETRow detalle in detalles.Rows)
            {
                lote.Add(System.Convert.ToInt32(detalle.LOTE));
                ArtId.Add(detalle.ARTICULO_ID);
                Concepto.Add(detalle.CONCEPTO);
                Cant.Add(detalle.CANTIDAD_ENVIADA);
                TotLote.Add(detalle.LOTE);
                Precio.Add(Double.Parse(detalle.PRECIO_ENVIA.ToString()));
                Caja.Add(int.Parse(detalle.CAJA.ToString()));
                Nolote.Add(detalle.REFLOTE.ToString());
                FecCad.Add(detalle.CADUCIDAD.ToString());
                Sec.Add(secuencia++);
            }

            SIFDatos.Inventario.TraspasoAlmacen.InsertaTraspasoAlmacen(UsuarioID, traspaso.SUCURSAL_ORIGEN, traspaso.SUCURSAL_DESTINO, traspaso.TOTAL, lote.ToArray(), Sec.ToArray(), ArtId.ToArray(), Concepto.ToArray(), Cant.ToArray(), TotLote.ToArray(), Precio.ToArray(), Caja.ToArray(), Nolote.ToArray(), FecCad.ToArray(),MOTIVO);

            return true;
        }

        public void EnviaTraspasox(string Folio, int[] Lote, int Origen, int Destino,
                                double Total, int[] Sec, String[] ArtId,
                                String[] Concepto, int[] Cant, int[] CantE, double[] PrecioE, int[] Caja, double[] TotLote, String Usuario,String[] NoLote,String[] FecCad)
        {
            SIFDatos.Inventario.TraspasoAlmacen.EnviaTraspasoX(Folio, Lote, Origen, Destino, Total, Sec, ArtId, Concepto, Cant, CantE,PrecioE,Caja, TotLote,Usuario,Helpers.Sesion.Sucursal.SucursalID,NoLote,FecCad);
        }


        public SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETDataTable PedidosPorEOQ(SIFModelo.Sucursal sucursal)
        {
            DataTable dt = SIFDatos.Inventario.PedidosAlmacen.GetPedidoEoQ(sucursal);

            foreach (DataRow row in dt.Rows)
            {
                TraspasosDataSet.PEDIDO_TRASP_DET.ImportRow(row);
            }

            return TraspasosDataSet.PEDIDO_TRASP_DET;

        }
        public SIFModelo.Tipos.parmFac timbraTraspaso(SIFModelo.Tipos.parmFac nP)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.timbraTraspasoD(nP);
        }
        public string existeTimbreT(string folio , string lote) {
            return SIFDatos.Inventario.TraspasoAlmacen.existeTimbreT(folio , lote);

        }
        public List<int> sucursalesParaTimbrar()
        {
            return SIFDatos.Inventario.TraspasoAlmacen.sucursalesParaTimbrar();

        }

        #region ROMA
        // ROMA 20AGO2013
        public int SetSolicitado(string NoFolio, string NoLote, int NoPartida, string Edo)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.SetSolicitado(NoFolio, NoLote, NoPartida, Edo);
        }
        // ROMA 20AGO2013

        // ROMA 25AGO2013
        public string SetTraspasoPedido(string refpedido, string usersurte, string NoFolio, int SucId, string UsrId, int Origen, int Destino, string IdArt, int Cant, string lotep, DateTime caducidad, string solicitado , int idMT)
        {
            solicitado = "S";
            return SIFDatos.Inventario.TraspasoAlmacen.SetTraspasoPedido(refpedido, usersurte, NoFolio, SucId, UsrId, Origen, Destino, IdArt, Cant, lotep, caducidad, solicitado, idMT);
        }

        public DataTable GetTraspasoDet(string Folio)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.GetTraspasoDet(Folio, Helpers.Sesion.Sucursal);
        }

        public DataTable GetTraspasoDetPorID(string Folio, String idarticulo)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.GetTraspasoDetPorID(Folio,idarticulo);
        }

        public DataTable GetTraspasoDetalle(string Folio, int Lote)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.GetTraspasoDet(Folio, Lote);
        }
        // ROMA 25AGO2013

        // ROMA 03SEP2013

        public string EnviaTraspasoSalida(string NoFolio, string NoLote, int Origen, int Destino)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.EnviaTraspasoSalida(NoFolio, NoLote, Origen, Destino);
        }

        public bool ImportaPedidoAlmacen(int UsuarioID, /*SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASPRow traspaso*/ int sdestino, int idMotivo, SIFModelo.Inventarios.InventarioDataSet.PEDIDO_TRASP_DETDataTable pEDIDO_TRASP_DETDataTable)
        {
            return SIFDatos.Inventario.PedidosAlmacen.ImportaPedidoAlmacen(UsuarioID, /*traspaso*/ sdestino, idMotivo, pEDIDO_TRASP_DETDataTable);
        }
        public Int16 ResgistraEmbarque(SIFModelo.BitEmbarque embarque)
        {
            return SIFDatos.Inventario.PedidosAlmacen.ResgistraEmbarque(embarque);
        }

        
        //foliotextBoxX.Text, NoLote.ToString(), Helpers.Sesion.Sucursal.SucursalesID, CodigoTextBoxX.Text, Cant
        public string SetTraspasoPedidoArt(string NoFolio, string NoLote, int SucId, string IdArt, int Cant)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.SetTraspasoPedidoArt(NoFolio, NoLote, SucId, IdArt, Cant);
        }

        // ROMA 03SEP2013

        // ROMA 16SEP2013

        public DataTable GetTipoDevolucion()
        {
            return SIFDatos.Inventario.TraspasoAlmacen.GetTipoDevolucion();
        }

        public int SetDevolucion(string NoFolio, string NoLote, int NoPartida, string Sol, string Edo, int Cant)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.SetDevolucion(NoFolio, NoLote, NoPartida, Sol, Edo, Cant);
        }

        public int UpdTraspaso(string Folio, int[] Lote, double Total,
                                int[] Sec, String[] ArtId,
                                String[] Concepto, int[] CantS, int[] CantE, int[] CantR, int[] CantD, double[] PrecioE, double[] PrecioR,
                                int[] Caja, String[] Pedido, String Usr_Envia, String Usr_Recibe, String[] NoLote, String[] FechaCad, String[] TipDev)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.UpdTraspaso(Folio, Lote, Total, Sec, ArtId, Concepto, CantS, CantE, CantR, CantD, PrecioE, PrecioR, Caja, Pedido, Usr_Envia, Usr_Recibe, NoLote, FechaCad, TipDev);
        }

        public int ExistePedidoArt(string NoFolio, string NoLote, string IdArt, int Cant)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.ExistePedidoArt(NoFolio, NoLote, IdArt, Cant);
        }
        // ROMA 16SEP2013

        // ROMA 26SEO2013
        public int CierraDevolucionTraspaso(string UsuariosID, string NoFolio, string NoLote)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.CierraDevolucionTraspaso(UsuariosID, NoFolio, NoLote, Helpers.Sesion.Sucursal.SucursalID);
        }
        // ROMA 26SEO2013

        public int SetRecibido(string NoFolio, string NoLote, int NoPartida, int CantR, int CantD)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.SetRecibido(NoFolio, NoLote, NoPartida, CantR, CantD);
        }

        public static int ActualizarTraspaso(int sucursalDestino, String NoFolio)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.ActualizarTraspaso(sucursalDestino, NoFolio);
        }

        public int GetTraspasoDetContieneLineas(string Folio, int Lote)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.GetTraspasoDetContieneLineas(Folio, Lote);
        }
        /*JMQ 08-02-2017*/
        public BindingListView<SIFModelo.MotivoPedido> listaTipoPedido;
        public BindingListView<SIFModelo.MotivoPedido> buscarTipoPedido()
        {
            listaTipoPedido = new BindingListView<SIFModelo.MotivoPedido>(SIFDatos.Inventario.TraspasoAlmacen.bdTipoPedido());
            return listaTipoPedido;
        }

        public static string  buscarFolioT( string f) {
            return SIFDatos.Inventario.TraspasoAlmacen.bFoliot(f);
        }
        #endregion ROMA
        public static void CImprimeEtiqueta(string folio, int lote)
        {
            string impresora = SIFNegocio.Configuracion.Configuraciones.Aplicacion.ImpresoraTickets;
            Helpers.Ticket Ticket = new Helpers.Ticket();
            ///SE AGREGA EL CAMBIO TAMBIEN EN EL TICKET DE NADRO

            List<String> list = new List<string>();
            list = SIFDatos.Inventario.TraspasoAlmacen.GetDataEtiqueta(folio, lote);
            if (list.Count > 0)
            {
                foreach (string dato in list) {
                    Ticket.AddSubHeaderLine(dato);
                }
                
            }

         


            //Ticket.AddFooterLine(remision.ImporteLetra);
            //Ticket.AddFooterLine(remision.formadepago);
            //Ticket.AddFooterLine("CLIENTE:" + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);

            /// AVM 29-05-2015
            /// SE OTIENE EL PIE DE LA BASE DE DATOS.            

            Ticket.PrintEtiqueta(impresora);
        }
        public List<SIFModelo.Catalogo.CatDistribuidores> getdistribuidores( string activo)
        {
            return SIFDatos.Inventario.PedidosAlmacen.get_distribuidores(activo);
        }
        public List<SIFModelo.Catalogo.CatUnidadesDistribucion> get_unidadescDitribucion(string activo)
        {
            return SIFDatos.Inventario.PedidosAlmacen.get_unidadescDitribucion(activo);
        }
        public bool actializaTraspasoDistribuidor(string Folio, int Lote, int idD, int idUD) {

            return SIFDatos.Inventario.PedidosAlmacen.actializaTraspasoDistribuidor(Folio,   Lote,   idD,   idUD);
        }

        public  string getNumeroLotesSku1(string psku) {
            return SIFDatos.Inventario.TraspasoAlmacen.getNumeroLotesSku1(psku);
        }

        public string getActivotrasp(string folio,int lote)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.getActivotrasp(folio,lote);
        }

        public DataTable getSucDestrasp(string folio, int lote)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.getSucursalEnviatrasp(folio, lote);
        }
        public int ObtenTpoMovInvIDTraspaso(string folio, string lote)
        {
            return SIFDatos.Inventario.TraspasoAlmacen.ObtenTpoMovInvIDTraspaso(folio, lote);
        }
    }

}
