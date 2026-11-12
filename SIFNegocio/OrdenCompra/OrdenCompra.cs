using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using System.IO;
namespace SIFNegocio.OrdenCompra
{
    public class OrdenCompra
    {
        private const int GruposDe = 150;

        public List<SIFModelo.OrdenCompra.OfertaCompra> detalles = new List<SIFModelo.OrdenCompra.OfertaCompra>();
        public List<SIFModelo.OrdenCompra.OrdenCompraDataSet> OrdenesCompra = new List<SIFModelo.OrdenCompra.OrdenCompraDataSet>();

        public SIFModelo.OrdenCompra.OrdenCompraDataSet dsOrdenesCompra = new SIFModelo.OrdenCompra.OrdenCompraDataSet();
        public SIFModelo.OrdenCompra.OrdenesCompraDataSet dsOrdenesCompraDT = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();

        const string CAROS = "CAROS";
        const string CONTROLADOS = "CONTROLADOS";
        const string ANTIBIOTICOS = "ANTIBIOTICOS";
        const string LACTEOS = "LACTEOS";
        const string TRANSFER = "TRANSFER";
        const string GENERICO = "GENERICO";

        //public System.Data.DataSet GeneraDeEOQ(SIFModelo.Sucursal sucursal, SIFModelo.Cliente proveedor, SIFModelo.Usuario usuario)
        //{
        //    string listaProveedores = new SIFNegocio.Usuarios().ListaProveedores(usuario);

        //    if (string.IsNullOrEmpty(listaProveedores))
        //    {
        //       MessageBox.Show("El usuario no tiene una lista de proveedores asignada");
        //        return dsOrdenesCompra;
        //    }

        //    foliosGenerados.Clear();

        //    SIFDatos.OrdenCompra.OrdenCompra.GeneraDeEOQ(dsOrdenesCompra, sucursal, listaProveedores);

        //    SIFDatos.OrdenCompra.OrdenCompra.Ofertas(dsOrdenesCompra);

        //    SIFDatos.OrdenCompra.OrdenCompra.GeneraCabeceraDeEOQ(dsOrdenesCompra, sucursal, listaProveedores);

        //    //DataTable folios = new DataTable("Folios");
        //    //folios.Columns.Add("FOLIO_OC_ID", System.Type.GetType("System.String"));
        //    //folios.Columns.Add("PROVEEDOR_ID", System.Type.GetType("System.Int32"));
        //    //folios.Columns.Add("USUARIO_ID", System.Type.GetType("System.String"));
        //    //folios.Columns.Add("SUCURSAL_ID", System.Type.GetType("System.Int32"));
        //    //folios.Columns.Add("FECHA_ALTA", System.Type.GetType("System.DateTime"));
        //    //folios.Columns.Add("FECHA_RECEPCION", System.Type.GetType("System.DateTime"));
        //    //folios.Columns.Add("FECHA_CIERRE", System.Type.GetType("System.DateTime"));
        //    //folios.Columns.Add("USUARIO_ID_AUTORIZA", System.Type.GetType("System.String"));
        //    //folios.Columns.Add("FECHA_AUTORIZA", System.Type.GetType("System.DateTime"));
        //    //folios.Columns.Add("ESTADO_OC", System.Type.GetType("System.String"));

        //    //ds.Tables.Add(folios);

        //    DataView vistaDetalles = new DataView(dsOrdenesCompra.ORDEN_COMPRA);

        //    string proveedorId;
        //    foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_CABECERARow headerRow in dsOrdenesCompra.ORDEN_COMPRA_CABECERA.Rows)
        //    {
        //        proveedorId = headerRow["PROVEEDOR_ID"].ToString();
        //        vistaDetalles.RowFilter = "PROVEEDOR_ID = " + proveedorId;

        //        int contador = 1;
        //        string folio = "";
        //        foreach (DataRowView row in vistaDetalles)
        //        {
        //            if (contador == 1)
        //            {
        //                //GENERAMOS EL NUMERO DE FOLIO
        //                folio = GeneraFolio(sucursal, proveedorId);
        //                SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow rowFolio = dsOrdenesCompra.ORDEN_COMPRA.NewORDEN_COMPRARow();
        //                rowFolio.FOLIO_OC_ID = folio;
        //                rowFolio.PROVEEDOR_ID = int.Parse(headerRow["PROVEEDOR_ID"].ToString());
        //                rowFolio.USUARIO_ID = usuario.UsuariosID.ToString();
        //                rowFolio.SUCURSAL_ID = (short)sucursal.SucursalesID;
        //                rowFolio.FECHA_ALTA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
        //                rowFolio.ESTADO_OC = SIFModelo.EstadosOrdenCompra.ABIERTA.Clave;

        //                //headerRow["FOLIO"] = folio;
        //                dsOrdenesCompra.ORDEN_COMPRA.Rows.Add(rowFolio);
        //            }

        //            row.Row["FOLIO_OC_ID"] = folio;
        //            row.Row["NUM_PARTIDA"] = contador;
        //            row.Row["USUARIO_ID"] = usuario.UsuariosID;

        //            contador++;

        //            if (contador == 28)
        //            {
        //                contador = 1;
        //            }

        //        }

        //    }

        //    //vistaDetalles.RowFilter = "FOLIO_OC_ID = NULL";

        //    //ds.Relations.Clear();
        //    //ds.Relations.Add("1", ds.Tables["OrdenCompraCabecera"].Columns["PROVEEDOR_ID"],
        //    //                            ds.Tables["Folios"].Columns["PROVEEDOR_ID"], false);

        //    //ds.Relations.Add("2", ds.Tables["Folios"].Columns["FOLIO_OC_ID"],
        //    //                            ds.Tables["OrdenCompra"].Columns["FOLIO_OC_ID"], false);

        //    //ds.Relations.Add("3", ds.Tables["OrdenCompra"].Columns["ARTICULO_ID"],
        //    //                            ds.Tables["Ofertas"].Columns["ARTICULO_ID"], false);

        //    return dsOrdenesCompra;

        //}

        public SIFModelo.OrdenCompra.OrdenCompraDataSet GeneraDeEOQ(SIFModelo.Sucursal sucursal, SIFModelo.Usuario usuario, decimal porcentaje_eoq, string tipoCompra, string LineaID = null, int? ProveedorID = null, string ArticuloID = "%")
        {
            string listaProveedores = LineaID;

            //if (!esGeneral)
            //{
            //    if (LineaID != null)
            //    {
            //        //if (!listaProveedores.Contains(LineaID))
            //        //{
            //        //   MessageBox.Show("El usuario no tiene el proveedor seleccionado");
            //        //    return dsOrdenesCompra;
            //        //}
            //        //else
            //        //{
            //        listaProveedores = LineaID;
            //        //}
            //    }
            //else
            //{
            //    listaProveedores = new SIFNegocio.Usuarios().ListaLineas(usuario);
            //}

            //if (string.IsNullOrEmpty(listaProveedores))
            //{
            //   MessageBox.Show("El usuario no tiene una lista de proveedores asignada");
            //    return dsOrdenesCompra;
            //}
            //}



            //if (esGeneral)
            //{
            if (usuario.TipoUsuario != SIFModelo.Tipos.TipoUsuario.ADMINISTRATIVO && string.IsNullOrEmpty( listaProveedores))
            {
                List<SIFModelo.Cliente> proveedores = new List<SIFModelo.Cliente>();
                if (tipoCompra == "M")
                {
                    proveedores = new SIFNegocio.Clientes().BuscarProveedoresMayoristasVendedor("", "", usuario);
                }
                //  else
                //{
                //  proveedores = new SIFNegocio.Clientes().BuscarProveedoresDirectos("", "");
                //}


                listaProveedores = "";
                foreach (SIFModelo.Cliente c in proveedores)
                {
                    listaProveedores += c.ID + "|";
                }
                listaProveedores = listaProveedores.Trim('|');
            }

            //}
            //   SIFDatos.OrdenCompra.OrdenCompra.GeneraDeEOQ(dsOrdenesCompra, sucursal, listaProveedores, porcentaje_eoq, usuario, tipoCompra, false ? "S" : "N");

            //if (ArticuloID == "")
            //{
            //    ArticuloID = "";
            //}

            SIFDatos.OrdenCompra.OrdenCompra.GeneraCompraArticulo(dsOrdenesCompra, sucursal, listaProveedores, porcentaje_eoq, usuario, tipoCompra, ArticuloID);
            //cargamos los productos asociados a un proveedor
            SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
            List<SIFModelo.Articulo> articulosAsignadosProv = articuloL.BuscarFcMList("", "");


            dsOrdenesCompra.Relations.Clear();
            List<SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow> eliminadas = new List<SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow>();
            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow detalle in dsOrdenesCompra.ORDEN_COMPRA_DET.Rows)
            {

                List<string> ofertas = new List<string>();

                //if (detalle.ARTICULO_ID == "7501287670854")
                //{
                //    //continue;
                //}

                //if (ProveedorID != null)
                //{
                //    if (ProveedorID == 99012)
                //    { 
                //    //REVISAR SI EXISTE DESCUENTO ESPECIAL
                //      SIFModelo.OrdenCompra.OfertaCompra of = ofertaEspecialSaba(detalle.ARTICULO_ID, sucursal.SucursalesID.ToString());
                //      if (of != null)
                //      {
                //          ofertas.Add(of.DescuentoOfrecido.ToString());
                //      }
                //    }
                //}


                //NIVEL 4 POR ROTACION
                SIFModelo.Articulo articulo = new SIFModelo.Articulo();
                articulo = new SIFModelo.Articulo();
                articulo.ARTICULO_ID = detalle.ARTICULO_ID;
                SIFModelo.OrdenCompra.InfromacionMayorista mayorista = new SIFNegocio.OrdenCompra.InformacionMayorista().InformacionMayoristaPorArticulo(articulo);
                //Definir el proveedor en base a su status
                if (tipoCompra == "M")
                {
                    if (mayorista != null)
                    {
                        //switch (detalle.PROVEEDOR_ID)
                        //{
                        // case 99012:
                        Boolean dnadro=false ;
                        Boolean dmarzam = false;
                        Boolean ddrogueros = false;

                        double pdnadro =0.0;
                        double pdmarzam =0.0;
                        double pddrogueros =0.0;
                        int proveedoresActivos=0;


                        /*se seleccionan los que estan definidos a un proveedor
                         */
                        /*   foreach (SIFModelo.Articulo art in articulosAsignadosProv) {
                               if (art.ARTICULO_ID == detalle.ARTICULO_ID) {
                                   detalle.PROVEEDOR_ID = Convert.ToInt32(art.PROVEEDOR_ID);

                                   MessageBox.Show(art.ARTICULO_ID);
                                   continue;
                               }
                           }*/

                        if (detalle.PROVEEDOR_ID.ToString().Contains("6699")) {
                            detalle.PROVEEDOR_ID = Convert.ToInt32(detalle.PROVEEDOR_ID.ToString().Substring(2));
                            if (detalle.ES_TRANSFER == "s")
                            {
                                detalle.PROVEEDOR_ID = 99000;
                                continue;
                            }
                            continue;
                        }



                        //if (mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR /*&&ddrogueros==true*/)
                        //{
                            double dd = comvertirStrinD(SIFDatos.OrdenCompra.InformacionMayorista.Costo_neto_almDrogas(detalle.ARTICULO_ID));
                            string preciosP  = SIFDatos.OrdenCompra.InformacionMayorista.precios_compra_prov(detalle.ARTICULO_ID);
                            if (preciosP != "0.0") /*si  preciosP  es igua a "0.0" es por que  ocurrio un error al tratar de obtener los datos*/
                        {
                                pdnadro = comvertirStrinD((preciosP.Split('|')[0].ToString()));
                                pddrogueros = comvertirStrinD((preciosP.Split('|')[1].ToString()));
                                pdmarzam = comvertirStrinD((preciosP.Split('|')[2].ToString()));
                                

                                if (pddrogueros != 9999999)
                                {
                                    if (pddrogueros < dd && (dd != 9999999.99 ))
                                    {
                                        pddrogueros = dd;
                                    }

                                }
                                else {
                                    pddrogueros = dd;
                                }
                                
                            }
                            //verificamos que estado tiene el articulo con sus proveedores mayoristas
                            ddrogueros = this.estadoArtMayorista(mayorista.EDO_COMPRA_DROGUEROS);
                            dnadro = this.estadoArtMayorista(mayorista.EDO_COMPRA_NADRO);
                            dmarzam = this.estadoArtMayorista(mayorista.EDO_COMPRA_MARZAM);

                        /*
                        if (mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR )
                        {                        
                         proveedoresActivos=proveedoresActivos+1;
                            ddrogueros=true;
                        }
                         if (mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR)
                        {
                            dnadro=true;
                        }  
                         if (mayorista.EDO_COMPRA_MARZAM != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_MARZAM != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_MARZAM != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_MARZAM != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_MARZAM != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR)
                        {
                         dmarzam=true;
                        }
                        */
                        /*******************            Comentado por que marzam no entra                       ******************** 
                         * else if (mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR)
                        {
                         

                        }*/
                        if (preciosP != "0.0")
                         {
                             if ((ddrogueros == true && dnadro == true && dmarzam == true) || (ddrogueros == false && dnadro == false && dmarzam == false))
                             {
                                 if ((pddrogueros <= pdnadro) && (pddrogueros <= pdmarzam))
                                 {
                                     detalle.PROVEEDOR_ID = 99393;
                                 }
                                 else if ((pdnadro < pddrogueros) && (pdnadro <= pdmarzam))
                                 {
                                     detalle.PROVEEDOR_ID = 99064;
                                 }
                                 else if ((pdmarzam < pddrogueros) && (pdmarzam < pdnadro))
                                 {
                                     detalle.PROVEEDOR_ID = 99169;
                                 }
                                 else
                                 {
                                     detalle.PROVEEDOR_ID = 99064;
                                 }
                             }
                             else if (ddrogueros == true && dnadro == true && dmarzam == false)
                             {
                                 if (pddrogueros <= pdnadro)
                                 {
                                     detalle.PROVEEDOR_ID = 99393;
                                 }
                                 else
                                 {
                                     detalle.PROVEEDOR_ID = 99064;
                                 }
                             }
                             else if (ddrogueros == false && dnadro == true && dmarzam == true)
                             {
                                 if (pdnadro <= pdmarzam)
                                 {
                                     detalle.PROVEEDOR_ID = 99064;
                                 }
                                 else
                                 {
                                     detalle.PROVEEDOR_ID = 99169;
                                 }
                             }
                             else if (ddrogueros == true && dnadro == false && dmarzam == true)
                             {
                                 if (pddrogueros <= pdmarzam)
                                 {
                                     detalle.PROVEEDOR_ID = 99393;
                                 }
                                 else
                                 {
                                     detalle.PROVEEDOR_ID = 99169;
                                 }
                             }
                             else if (ddrogueros == false && dnadro == true && dmarzam == false)
                             {
                                 detalle.PROVEEDOR_ID = 99393;
                                 detalle.PROVEEDOR_ID = 99064;
                             }
                             else if (ddrogueros == false && dnadro == false && dmarzam == true)
                             {
                                 detalle.PROVEEDOR_ID = 99169;
                             }
                             else if (ddrogueros == true && dnadro == false && dmarzam == false)
                             {
                                 detalle.PROVEEDOR_ID = 99393;
                             }
                             else
                             {
                                 detalle.PROVEEDOR_ID = 99012;
                             }
                         }
                         else {
                             
                             detalle.PROVEEDOR_ID = 99064;
                         }
                        


                        


                        
                        
                        
                        
                            
                        
                        //}
                        
                        //SIFDatos.OrdenCompra.InformacionMayorista.Costo_neto_almDrogas();
                        /****************************************************COMENTARIO MIO*******************************************************************************************************
                        if (mayorista.DESCUENTO_NADRO >= mayorista.DESCUENTO_MARZAM && mayorista.DESCUENTO_NADRO >= mayorista.DESCUENTO_DROGUEROS ) {
                            dnadro = true;
                        }
                        else if (mayorista.DESCUENTO_MARZAM > mayorista.DESCUENTO_NADRO && mayorista.DESCUENTO_MARZAM > mayorista.DESCUENTO_DROGUEROS)
                        {
                            dmarzam = true;
                        }
                        else {
                            ddrogueros = true;
                        }*/


                       /************************************************************* COMENTANDO CODIGO*************************************************
                        * if (mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR)
                        {
                            detalle.PROVEEDOR_ID = 99012;

                        }

                        else if (mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR && mayorista.DESCUENTO_NADRO>=mayorista.DESCUENTO_MARZAM)
                        {
                            detalle.PROVEEDOR_ID = 99064;                            
                        }
                        else if (mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR)
                        {
                            detalle.PROVEEDOR_ID = 99035;                            
                        }
                        else if (mayorista.EDO_COMPRA_MARZAM != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO && mayorista.EDO_COMPRA_MARZAM != SIFModelo.Tipos.TipoStatusMayorista.FALTANTE && mayorista.EDO_COMPRA_MARZAM != SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA && mayorista.EDO_COMPRA_MARZAM != SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO && mayorista.EDO_COMPRA_MARZAM != SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR && mayorista.DESCUENTO_MARZAM > mayorista.DESCUENTO_NADRO)
                        {
                            detalle.PROVEEDOR_ID = 99169;                            
                        }*/
                        
                       







                        if (detalle.PROVEEDOR_ID != 99012 && detalle.PROVEEDOR_ID != 99064 && /*detalle.PROVEEDOR_ID != 99035*/detalle.PROVEEDOR_ID != 99393 && detalle.PROVEEDOR_ID != 99169)
                        {
                            detalle.PROVEEDOR_ID = 99064;
                        }
                    }
                    else
                    {
                        if (tipoCompra == "M")
                        {
                            detalle.PROVEEDOR_ID = 99064;
                        }
                    }
                }

                //NIVEL 3 POR OFERTA

                ofertas.Clear();
                ofertas.AddRange(Ofertas(detalle.ARTICULO_ID, sucursal.SucursalesID.ToString(), ProveedorID));
                detalle.OFERTAS = ofertas.Count;


                if (ProveedorID != null)
                {
                    detalle.PROVEEDOR_ID = ProveedorID.Value;
                }

                if (detalle.IsPRECIO_FACTURANull())
                {
                    detalle.PRECIO_FACTURA = 0;
                }
               /* if (detalle.OFERTAS >= 1 && tipoCompra == "M")
                {
                    SIFModelo.OrdenCompra.OfertasCompra ocM = new SIFModelo.OrdenCompra.OfertasCompra();

                    string[] data = ofertas[0].Split(new char[] { '|' });

                    if (data.Length <= 1)
                    {
                        continue;
                    }
                    ocM.ProveedorID = int.Parse(data[0]);
                    
                    ocM.Nombre = data[1];
                    ocM.DescuentoOfrecido = decimal.Parse(data[2]);
                    ocM.DescuentoEspecialProveedor = decimal.Parse(data[3]);
                    ocM.PiezasConCargo = int.Parse(data[4]);
                    ocM.PiezasSinCargo = int.Parse(data[5]);
                    
                    ocM.PrecioCosto = decimal.Parse(data[7]);
                    ocM.TipoOferta = data[9].Trim();

                    if (detalle.IsPRECIO_FARMACIANull())
                    {
                        detalle.PRECIO_FARMACIA = ocM.PrecioCosto;
                    }

                    ocM.PrecioCosto = detalle.PRECIO_FARMACIA;

                    decimal descuentoOfrecido =(ocM.PrecioCosto * (ocM.DescuentoOfrecido / 100m))/100;
                    decimal descuentoAdicional = (descuentoOfrecido * (ocM.DescuentoEspecialProveedor / 100m))/100;
                    ocM.PrecioCosto = ocM.PrecioCosto - descuentoOfrecido - descuentoAdicional;


                    detalle.PRECIO_COSTO = ocM.PrecioCosto;
                    detalle.PROVEEDOR_ID = ocM.ProveedorID;
                    detalle.IMPORTE = detalle.PRECIO_COSTO * detalle.CANT_SOLICITADA;
                    detalle.DESCRIP_OFERTA = ocM.DescuentoOfrecido.ToString();
                    detalle.MEJOR_OFERTA_COSTO = ocM.PrecioCosto;
                    detalle.DESCTO_RECIBIDO = ocM.DescuentoOfrecido;

                }
                else // debe ser igual a                          7501188802866
                {*/
                    if (!detalle.IsPRECIO_FARMACIANull())
                    {
                        detalle.PRECIO_COSTO = detalle.PRECIO_FARMACIA;
                        detalle.IMPORTE = detalle.PRECIO_COSTO * detalle.CANT_SOLICITADA;

                        detalle.MEJOR_OFERTA_COSTO = detalle.PRECIO_COSTO;
                    }
               // }


                //NIVEL 2 NO COMPRAR

                if (tipoCompra == "M")
                {
                    if (mayorista != null)
                    {
                        if (mayorista.EDO_COMPRA_SABA == SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR && mayorista.EDO_COMPRA_NADRO == SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR && mayorista.EDO_COMPRA_DROGUEROS == SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR && mayorista.EDO_COMPRA_MARZAM == SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR)
                        {
                            eliminadas.Add(detalle);
                            //dsOrdenesCompra.ORDEN_COMPRA_DET.RemoveORDEN_COMPRA_DETRow(detalle);
                            continue;
                            //QUITAR DE LA LISTA
                        }
                    }
                }


                //NIVEL 1 TRANSFER
                if (tipoCompra == "M")
                {
                    if (detalle.ES_TRANSFER == "s")
                    {
                        detalle.PROVEEDOR_ID = 99000;
                        if (detalle.PROVEEDOR_ID != 99000)
                        {
                            if (ofertas.Count > 0)
                            {
                                DataTable dtOftas = new SIFNegocio.OrdenCompra.OrdenCompra().OfertasProveedor(detalle.ARTICULO_ID);

                                foreach (DataRow rw in dtOftas.Rows)
                                {
                                    if (int.Parse(rw["proveedor_id"].ToString()) == detalle.PROVEEDOR_ID)
                                    {
                                        detalle.PRECIO_COSTO = System.Convert.ToDecimal(rw["precio_costo"]);
                                        //detalle.PROVEEDOR_ID = ocM.ProveedorID;
                                        detalle.IMPORTE = detalle.PRECIO_COSTO * detalle.CANT_SOLICITADA;
                                        detalle.DESCRIP_OFERTA = rw["descto_ofrecido"].ToString();
                                        detalle.MEJOR_OFERTA_COSTO = detalle.PRECIO_COSTO;
                                        detalle.DESCTO_RECIBIDO = System.Convert.ToDecimal(rw["descto_ofrecido"]);
                                    }
                                }
                            }
                        }
                    }
                }


                //if (detalle.PUNTO_DE_REORDEN > 0)
                //{
                //    detalle.PORCENTAJE_EOQ = (detalle.EXISTENCIA_GENERAL / detalle.PUNTO_DE_REORDEN) * 100;
                //}


                //   break;
                // case 99064:
                //else if (mayorista.EDO_COMPRA_NADRO == SIFModelo.Tipos.TipoStatusMayorista.AGOTADO)
                //{
                //    if (mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO)
                //    {
                //        detalle.PROVEEDOR_ID = 99012;
                //        break;
                //    }
                //    if (mayorista.EDO_COMPRA_DROGUEROS != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO)
                //    {
                //        detalle.PROVEEDOR_ID = 99035;
                //        break;
                //    }
                //}
                //        break;
                //   case 99035:
                //if (mayorista.EDO_COMPRA_DROGUEROS == SIFModelo.Tipos.TipoStatusMayorista.AGOTADO)
                //{
                //    if (mayorista.EDO_COMPRA_SABA != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO)
                //    {
                //        detalle.PROVEEDOR_ID = 99012;
                //        break;
                //    }
                //    if (mayorista.EDO_COMPRA_NADRO != SIFModelo.Tipos.TipoStatusMayorista.AGOTADO)
                //    {
                //        detalle.PROVEEDOR_ID = 99064;
                //        break;
                //    }
                //}
                //break;
                //}
                //}


                //Revisamos si existe TRANSFER //YA SE VALIDA EN EL PROCEDIMIENTO
                //if (mayorista != null)
                //{
                //    if (mayorista.PROVEEDOR_ID != 0 && mayorista.PERIODO_COMPRA_INICIO != null && mayorista.PERIODO_COMPRA_FIN != null)
                //    {
                //        if (mayorista.PERIODO_COMPRA_INICIO.Value <= DateTime.Now && mayorista.PERIODO_COMPRA_FIN >= DateTime.Now)
                //            detalle.PROVEEDOR_ID = mayorista.PROVEEDOR_ID;
                //        //detalle.OBSERVACION_OC_DET = "TRANSFER";

                //        if (mayorista.Bloqueado == SIFModelo.Tipos.SiNo.SI)
                //        {
                //            detalle.Bloqueado = true;
                //        }
                //        else {
                //            detalle.OC_SEGMENTA = -1;
                //        }
                //    }


                //VALIDAR POR TRANSFER
                //if (mayorista.EDO_COMPRA_DROGUEROS == SIFModelo.Tipos.TipoStatusMayorista.TRANSFER || mayorista.EDO_COMPRA_NADRO == SIFModelo.Tipos.TipoStatusMayorista.TRANSFER || mayorista.EDO_COMPRA_SABA == SIFModelo.Tipos.TipoStatusMayorista.TRANSFER)
                //{
                //    // detalle.OBSERVACION_OC_DET = "TRANSFER";
                //    detalle.OC_SEGMENTA = -1;
                //}
                //}

                if (detalle.IsDESCTO_RECIBIDO_AD1Null())
                {
                    detalle.DESCTO_RECIBIDO_AD1 = 0;
                }

                if (detalle.DESCTO_RECIBIDO_AD1 == 0)
                {

                    //AGREGAR EL DESCUENTO FINANCIERO DEL CATALOGO

                    if (mayorista != null)
                    {
                        switch (detalle.PROVEEDOR_ID)
                        {
                            case 99012:
                                detalle.DESCTO_RECIBIDO_AD1 = mayorista.DESCTO_ADICIONAL_SABA;
                                break;
                            case 99064:
                                detalle.DESCTO_RECIBIDO_AD1 = mayorista.DESCTO_ADICIONAL_NADRO;
                                break;
                            /*case 99035:
                                detalle.DESCTO_RECIBIDO_AD1 = mayorista.DESCTO_ADICIONAL_DROGUEROS;
                                break;*/
                            case 99393:
                                detalle.DESCTO_RECIBIDO_AD1 = mayorista.DESCTO_ADICIONAL_DROGUEROS;
                                break;
                            case 99169:
                                detalle.DESCTO_RECIBIDO_AD1 = mayorista.DESCTO_ADICIONAL_MARZAM;
                                break;
                        }
                    }
                }

                //REVISAR SI EXISTE OFERTA ESPECIAL
                if (detalle.PROVEEDOR_ID == 99012)
                {
                    //REVISAR OFERTA ESPECIAL SABA
                    //SIFModelo.OrdenCompra.OfertaCompra oferta = OfertaEspecial(detalle);

                    //if (oferta != null)
                    //{
                    //    detalle.PROVEEDOR_ID = 99012;
                    //  //  detalle.MEJOR_OFERTA_COSTO
                    //}
                }

                if (detalle.ES_TRANSFER == "s")
                {
                    detalle.PROVEEDOR_ID = 99000;
                    continue;
                }
            }

            foreach (var elimina in eliminadas)
            {
                if (elimina.ES_TRANSFER == "s")
                {
                    elimina.PROVEEDOR_ID = 99000;
                    continue;
                }

                dsOrdenesCompra.ORDEN_COMPRA_DET.RemoveORDEN_COMPRA_DETRow(elimina);
            }

            dsOrdenesCompra.ORDEN_COMPRA_DET.AcceptChanges();

            return dsOrdenesCompra;
        }

        private static double comvertirStrinD(string n) {
            double numero=9999999;
            NumberFormatInfo providerC = new NumberFormatInfo();
            NumberFormatInfo providerP = new NumberFormatInfo();
            providerC.NumberDecimalSeparator = ",";
            providerP.NumberDecimalSeparator = ".";
            int index = n.IndexOf(",");
            if (index >= 0)
            {
                numero = Convert.ToDouble(n, providerC);
            }
            index = n.IndexOf(".");
            if (index >= 0)
            {
                numero = Convert.ToDouble(n, providerP);
            }



            return numero;
        }

        public SIFModelo.OrdenCompra.OfertaCompra ofertaEspecialSaba(string articuloID, string sucursal)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.OfertaEspecial(articuloID, sucursal);
        }

        private List<string> foliosGenerados = new List<string>();
        public string GeneraFolio(SIFModelo.Sucursal sucursal, string proveedorId)
        {
            string prefijoFolio = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yy");
            string prefijoMes = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("MM");
            int folio = SIFDatos.OrdenCompra.OrdenCompra.GeneraFolio(sucursal, prefijoFolio);
            folio += foliosGenerados.Count;

            string sb = sucursal.SucursalesID.ToString("00") + prefijoFolio + prefijoMes +"1"+ folio.ToString().PadLeft(8, '0'); ;
            foliosGenerados.Add(sb);
            return sb;

        }

        public void CambiarProveedorOrden(string ordenCompra, SIFModelo.Cliente prov)
        {
            SIFDatos.OrdenCompra.OrdenCompra.CambiaProveedorOrden(ordenCompra, prov);
        }

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet BuscaOrdenCompra(string folio, DateTime fecha1, DateTime fecha2, string status, int usuario)
        {

            SIFModelo.Usuario musuario = new Usuarios().UsuarioPorId(usuario);
            if (musuario.TipoUsuario == SIFModelo.Tipos.TipoUsuario.VENDENDOR || musuario.TipoUsuario == SIFModelo.Tipos.TipoUsuario.ADMINISTRATIVO)
            {
                usuario = 0;
            }

            if (musuario.TipoUsuario == SIFModelo.Tipos.TipoUsuario.ALMACENISTA || musuario.TipoUsuario == SIFModelo.Tipos.TipoUsuario.SUPERVISOR)
            {
                usuario = 0;
                status = "L ";
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet DS = SIFDatos.OrdenCompra.OrdenCompra.BuscaOrdenCompra(folio, fecha1, fecha2, status, usuario);

            foreach (SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow row in DS.V_ORDEN_COMPRA.Rows)
            {
                if (row.FECHA_AUTORIZA == new DateTime())
                    row.SetFECHA_AUTORIZANull();
                if (row.FECHA_CIERRE == new DateTime())
                    row.SetFECHA_CIERRENull();
                if (row.IsFECHA_RECEPCIONNull() || row.FECHA_RECEPCION == new DateTime())
                    row.SetFECHA_RECEPCIONNull();
            }

            return DS;
        }

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet BuscaOrdenCompra(string folio, DateTime fecha1, DateTime fecha2, string status)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet DS = SIFDatos.OrdenCompra.OrdenCompra.BuscaOrdenCompra(folio, fecha1, fecha2, status);

            foreach (SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow row in DS.V_ORDEN_COMPRA.Rows)
            {
                if (row.FECHA_AUTORIZA == new DateTime())
                    row.SetFECHA_AUTORIZANull();
                if (row.FECHA_CIERRE == new DateTime())
                    row.SetFECHA_CIERRENull();
                if (!row.IsFECHA_RECEPCIONNull() && row.FECHA_RECEPCION == new DateTime())
                    row.SetFECHA_RECEPCIONNull();
            }

            return DS;
        }

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETDataTable OrdenCompraDetalles;
        public SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETDataTable BuscaOrdenCompraDetalle(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OrdenCompra)
        {
            OrdenCompraDetalles = SIFDatos.OrdenCompra.OrdenCompra.BuscaOrdenCompra(OrdenCompra);
            return OrdenCompraDetalles;
        }

        //public bool Recibe(SIFModelo.OrdenCompra.OrdenesCompraDataSet.COMPRAS_DETDataTable tabla)
        //{
        //    //if (row.IsPRECIO_FARMACIANull())
        //    //{
        //    //    row.PRECIO_FARMACIA = 0;
        //    //}
        //    return SIFDatos.OrdenCompra.OrdenCompra.GuardaDetalles(tabla);
        //}

        public bool GuardaOrdenCompra(SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRARow oc)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.InsertaOrdenCompra(oc);
        }

        public bool ActualizaOrdenCompra(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oc)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRARow ocRow = new SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRADataTable().NewORDEN_COMPRARow();
            ocRow.FOLIO_OC_ID = oc.FOLIO_OC_ID;
            ocRow.USUARIO_ID = oc.USUARIO_ID;
            ocRow.PROVEEDOR_ID = oc.PROVEEDOR_ID;
            ocRow.SUCURSAL_ID = oc.SUCURSAL_ID;
            ocRow.FECHA_ALTA = oc.FECHA_ALTA;
            if (oc.IsFECHA_RECEPCIONNull())
            {
                // ocRow.FECHA_RECEPCION = new DateTime();
            }
            else
            {
                ocRow.FECHA_RECEPCION = oc.FECHA_RECEPCION;
            }

            if (oc.IsFECHA_CIERRENull())
            {
                oc.FECHA_CIERRE = new DateTime();
            }

            ocRow.FECHA_CIERRE = oc.FECHA_CIERRE;

            if (!oc.IsUSUARIO_ID_AUTORIZANull())
            {
                ocRow.USUARIO_ID_AUTORIZA = oc.USUARIO_ID_AUTORIZA;
            }
            else
            {
                ocRow.USUARIO_ID_AUTORIZA = "0";
            }

            if (oc.IsFECHA_AUTORIZANull())
            {
                oc.FECHA_AUTORIZA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            }

            ocRow.FECHA_AUTORIZA = oc.FECHA_AUTORIZA;
            ocRow.ESTADO_OC = oc.ESTADO_OC;
            // ocRow.FECHA_RECEPCION = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

            if (oc.IsOBSERVACION_OCNull())
            {
                oc.OBSERVACION_OC = " ";
            }
            ocRow.OBSERVACION_OC = oc.OBSERVACION_OC;

            if (oc.IsFOLIO_OC_ANTERIORNull())
            {
                oc.FOLIO_OC_ANTERIOR = " ";
            }
            ocRow.FOLIO_OC_ANTERIOR = oc.FOLIO_OC_ANTERIOR;

            return SIFDatos.OrdenCompra.OrdenCompra.ActualizaOrdenCompra(ocRow);
        }


     

        public bool GuardaOrdenCompraDetalle(SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocd)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow det = new SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETDataTable().NewORDEN_COMPRA_DETRow();
            det.ARTICULO_ID = ocd.ARTICULO_ID;
            det.CANT_DEVUELTA = ocd.CANT_DEVUELTA;
            det.CANT_FACTURADA = ocd.CANT_FACTURADA;
            det.CANT_MALESTADO = ocd.CANT_MALESTADO;
            det.CANT_RECIBIDA = ocd.CANT_RECIBIDA;
            det.CANT_REPOSICION = ocd.CANT_REPOSICION;
            det.CANT_SOLICITADA = ocd.CANT_SOLICITADA;
            if (string.IsNullOrEmpty(ocd.DESCRIP_OFERTA))
            {
                ocd.DESCRIP_OFERTA = "-";
            }
            det.DESCRIP_OFERTA = ocd.DESCRIP_OFERTA;
            det.DESCTO_FACTURA = ocd.CANT_FACTURADA;
            det.DESCTO_FACTURA_AD1 = ocd.DESCTO_FACTURA_AD1;
            det.DESCTO_RECIBIDO = ocd.DESCTO_RECIBIDO;
            det.DESCTO_RECIBIDO_AD1 = ocd.DESCTO_RECIBIDO_AD1;
            det.DESCTO_RECIBIDO_AD2 = ocd.DESCTO_RECIBIDO_AD2;
            det.EXISTENCIAS = ocd.EXISTENCIAS;
            det.FOLIO_OC_ID = ocd.FOLIO_OC_ID;
            det.IMPORTE = ocd.IMPORTE;
            det.LABORATORIO_ID = ocd.LABORATORIO_ID;
            det.NOMBRE = ocd.NOMBRE;
            det.NUM_PARTIDA = ocd.NUM_PARTIDA;
            det.OFERTA_COMPRA_ID = ocd.OFERTA_COMPRA_ID;
            det.PRECIO_COSTO = ocd.PRECIO_COSTO;
            det.PRECIO_FACTURA = ocd.PRECIO_FACTURA;
            det.PROVEEDOR_ID = ocd.PROVEEDOR_ID;
            det.PUNTO_DE_REORDEN = ocd.PUNTO_DE_REORDEN;
            det.TIPO_MEDICAMENTO_CVE = ocd.TIPO_MEDICAMENTO_CVE;
            det.ULT_PRECIO_COMPRA = ocd.ULT_PRECIO_COMPRA;
            det.USUARIO_ID = ocd.USUARIO_ID;

            return this.GuardaOrdenCompraDetalle(det);
        }

        public bool GuardaOrdenCompraDetalle(SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow ocd)
        {
            if (ocd.IsDESCTO_RECIBIDO_AD3Null())
            {
                ocd.DESCTO_RECIBIDO_AD3 = 0;
            }
            if (ocd.IsDESCTO_RECIBIDO_AD4Null())
            {
                ocd.DESCTO_RECIBIDO_AD4 = 0;
            }

            if (ocd.IsOBSERVACION_OC_DETNull())
            {
                ocd.OBSERVACION_OC_DET = "";
            }

            return SIFDatos.OrdenCompra.OrdenCompra.InsertaOrdenCompraDetalle(ocd);
        }

        #region Bonificaciones

        public DataSet Bonificaciones(string Folio, DateTime fecha1, DateTime fecha2)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.BuscaBonificaciones(Folio, fecha1, fecha2);
        }

        #endregion

        public bool InsertaBonificacion(SIFModelo.OrdenCompra.OrdenesCompraDataSet.BONIFICACIONRow bonificacion, SIFModelo.OrdenCompra.OrdenesCompraDataSet.BONIFICACION_DETDataTable detalles)
        {
            bool insertado = SIFDatos.OrdenCompra.OrdenCompra.InsertaBonificacion(bonificacion);
            if (insertado)
            {
                foreach (var detalle in detalles)
                {
                    detalle.LOTE = bonificacion.LOTE;
                    detalle.FOLIO = bonificacion.FOLIO;
                    detalle.SUCURSAL_ID = bonificacion.SUCURSAL_ID;
                    detalle.CONCEPTO_DET = bonificacion.CONCEPTO;

                    SIFDatos.OrdenCompra.OrdenCompra.InsertaBonificacionDetalle(detalle);
                }
            }
            return insertado;
        }

        public string FolioBonificacion(int sucursal)
        {
            string prefijoFolio = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yy");
            int folio = SIFDatos.OrdenCompra.OrdenCompra.GeneraFolioBonificacion(sucursal, prefijoFolio);
            folio += foliosGenerados.Count;


            string sb = sucursal.ToString("00") + prefijoFolio + folio.ToString().PadLeft(11, '0'); ;
            foliosGenerados.Add(sb);
            return sb;
        }

        public SIFModelo.OrdenCompra.OrdenCompraDataSet Ofertas(DataTable ordenCompra)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet DSoc = new SIFModelo.OrdenCompra.OrdenCompraDataSet();
            foreach (DataRow row in ordenCompra.Rows)
            {
                SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow detRow = DSoc.ORDEN_COMPRA_DET.NewORDEN_COMPRA_DETRow();
                detRow.ARTICULO_ID = row["ARTICULO_ID"].ToString();
            }

            return SIFDatos.OrdenCompra.OrdenCompra.Ofertas(DSoc);
        }

        public List<string> Ofertas(string articulo, string sucursal, int? proveedor = null)
        {
            List<string> ofertasEncontradas = new List<string>();
            //  ofertasEncontradas.Add("NINGUNO");

            ofertasEncontradas.AddRange(SIFDatos.OrdenCompra.OrdenCompra.Ofertas(articulo, sucursal));

            //if (proveedor != null && proveedor.Value == 99012)
            //{
            //    SIFModelo.OrdenCompra.OfertaCompra ofEsp = ofertaEspecialSaba(articulo, sucursal);

            //    if (ofEsp != null)
            //    {
            //        string ofeEspecial = 99012 + "|" + ofEsp.Nombre1 + " (ESPECIAL)|" + ofEsp.DescuentoOfrecido.ToString("0.00") + "|" + "0.00" + "|" + "1" + "|" + "0" + "|" + "0.00" + "|" + "0.00";
            //        ofertasEncontradas.Add(ofeEspecial);
            //    }
            //    //ocM.ProveedorID = int.Parse(data[0]);
            //    //ocM.Nombre = data[1];
            //    //ocM.DescuentoOfrecido = decimal.Parse(data[2]);
            //    //ocM.DescuentoEspecialProveedor = decimal.Parse(data[3]);
            //    //ocM.PiezasConCargo = int.Parse(data[4]);
            //    //ocM.PiezasSinCargo = int.Parse(data[5]);
            //    //ocM.PrecioCosto = decimal.Parse(data[6]);
            //    //ocM.PrecioCosto = decimal.Parse(data[7]);


            //}

            return ofertasEncontradas;
        }

        public String GuardaOrdenCompra(SIFModelo.Sucursal sucursal, SIFModelo.Usuario usuario, SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow OrdenCompra, SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETDataTable oRDEN_COMPRA_DETDataTable, bool EsUnir = false, bool esUnaSola = false)
        {
            string foliosGenerados = "";
            //GENERAMOS LA ORDEN DE COMPRA

            //AGREGAMOS LOS DETALLES POR FOLIO

            // DataView vistaDetalles = new DataView(oRDEN_COMPRA_DETDataTable);

            List<int> proveedoresS = new List<int>();
            List<bool> bloqueados = new List<bool>();

            bloqueados.Add(true);
            bloqueados.Add(false);

            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow row in oRDEN_COMPRA_DETDataTable)
            {

                if (row.IsUSUARIO_IDNull())
                {
                    row.USUARIO_ID = 0;
                }

                if (row.RowState == DataRowState.Deleted)
                {
                    continue;
                }

                //if (row.Bloqueado != true)
                //{
                //    row.Bloqueado = false;
                //}

                if (!proveedoresS.Contains(row.PROVEEDOR_ID))
                {
                    proveedoresS.Add(row.PROVEEDOR_ID);
                }
            }

            int proveedorId;

            //if (esUnaSola)
            //{
            //    filtrosOC = new List<string> { "" };
            //}

            foreach (int headerRow in proveedoresS)
            {
                proveedorId = int.Parse(headerRow.ToString());
                //  var vistaDetalles.RowFilter = "PROVEEDOR_ID = " + proveedorId;
                object VvistaDetalles = null;

                List<int> vsegmentos = new List<int>();
                foreach (var row in oRDEN_COMPRA_DETDataTable)
                {
                    if (esUnaSola)
                    {
                        row.OC_SEGMENTA = 0;
                        //     continue;
                    }

                    if (row.IsOC_SEGMENTANull())
                    {
                        row.OC_SEGMENTA = 0;
                    }
                    vsegmentos.Add(row.OC_SEGMENTA);
                }

                List<int> segmentos = vsegmentos.Distinct().ToList();

                List<int> compradores = new List<int>();




                var compradorDistinto = from d in oRDEN_COMPRA_DETDataTable where d.PROVEEDOR_ID == proveedorId select d.USUARIO_ID;

                compradores = compradorDistinto.Distinct().ToList();

                foreach (int comprador in compradores)
                {
                    foreach (bool bloqueado in bloqueados)
                    {
                        foreach (int concepto in segmentos)
                        {
                            // if (concepto == -1)
                            // {
                            //    continue;
                            // }
                            //if (esUnaSola)
                            //{
                            VvistaDetalles = from d in oRDEN_COMPRA_DETDataTable where d.PROVEEDOR_ID == proveedorId && d.OC_SEGMENTA == concepto && d.USUARIO_ID == comprador && d.Bloqueado == bloqueado select d;
                            //}
                            //else
                            //{

                            //    if (concepto == TRANSFER)
                            //    {
                            //        VvistaDetalles = from d in oRDEN_COMPRA_DETDataTable where d.OBSERVACION_OC_DET.Contains(TRANSFER) && d.PROVEEDOR_ID == proveedorId select d;
                            //    }
                            //    if (concepto == CAROS)
                            //    {
                            //        //vistaDetalles.RowFilter = "PROVEEDOR_ID = " + proveedorId + " AND OBSERVACION_OC_DET NOT LIKE '%" + TRANSFER + "%' AND TIPO_MEDICAMENTO_CVE LIKE '%U2%' ";  //AND NOT (OBSERVACION_OC_DET LIKE '%" + TRANSFER + "%') ";
                            //        VvistaDetalles = from d in oRDEN_COMPRA_DETDataTable where !d.OBSERVACION_OC_DET.Contains(TRANSFER) && d.TIPO_MEDICAMENTO_CVE.Contains("U2") && d.PROVEEDOR_ID == proveedorId select d;
                            //    }
                            //    if (concepto == CONTROLADOS)
                            //    {
                            //        //vistaDetalles.RowFilter = "PROVEEDOR_ID = " + proveedorId + " AND OBSERVACION_OC_DET NOT LIKE '%" + TRANSFER + "%' AND TIPO_MEDICAMENTO_CVE LIKE '%U3%' AND TIPO_MEDICAMENTO_CVE NOT LIKE '%U2%'";  // AND OBSERVACION_OC_DET NOT LIKE '%" + TRANSFER + "%' ";
                            //        VvistaDetalles = from d in oRDEN_COMPRA_DETDataTable where !d.OBSERVACION_OC_DET.Contains(TRANSFER) && d.TIPO_MEDICAMENTO_CVE.Contains("U3") && !d.TIPO_MEDICAMENTO_CVE.Contains("U2") && d.PROVEEDOR_ID == proveedorId select d;
                            //    }
                            //    if (concepto == ANTIBIOTICOS)
                            //    {
                            //        //vistaDetalles.RowFilter = "PROVEEDOR_ID = " + proveedorId + " AND OBSERVACION_OC_DET NOT LIKE '%" + TRANSFER + "%' AND TIPO_MEDICAMENTO_CVE LIKE '%T3%' AND TIPO_MEDICAMENTO_CVE NOT LIKE '%U3%' AND TIPO_MEDICAMENTO_CVE NOT LIKE '%U2%' "; 
                            //        VvistaDetalles = from d in oRDEN_COMPRA_DETDataTable where !d.OBSERVACION_OC_DET.Contains(TRANSFER) && d.TIPO_MEDICAMENTO_CVE.Contains("T3") && !d.TIPO_MEDICAMENTO_CVE.Contains("U3") && !d.TIPO_MEDICAMENTO_CVE.Contains("U2") && d.PROVEEDOR_ID == proveedorId select d;
                            //    }
                            //    if (concepto == LACTEOS)
                            //    {
                            //        //vistaDetalles.RowFilter = "PROVEEDOR_ID = " + proveedorId + " AND OBSERVACION_OC_DET NOT LIKE '%" + TRANSFER + "%' AND TIPO_MEDICAMENTO_CVE LIKE '%U10%' AND TIPO_MEDICAMENTO_CVE NOT LIKE '%T3%' AND TIPO_MEDICAMENTO_CVE NOT LIKE '%U3%' AND TIPO_MEDICAMENTO_CVE NOT LIKE '%U2%' "; 
                            //        VvistaDetalles = from d in oRDEN_COMPRA_DETDataTable where !d.OBSERVACION_OC_DET.Contains(TRANSFER) && d.TIPO_MEDICAMENTO_CVE.Contains("U10") && !d.TIPO_MEDICAMENTO_CVE.Contains("T3") && !d.TIPO_MEDICAMENTO_CVE.Contains("U3") && !d.TIPO_MEDICAMENTO_CVE.Contains("U2") && d.PROVEEDOR_ID == proveedorId select d;
                            //    }

                            //    if (concepto == GENERICO)
                            //    {
                            //        //vistaDetalles.RowFilter = "PROVEEDOR_ID = " + proveedorId + " AND OBSERVACION_OC_DET NOT LIKE '%" + TRANSFER + "%'  AND TIPO_MEDICAMENTO_CVE NOT LIKE '%U10%' AND TIPO_MEDICAMENTO_CVE NOT LIKE '%T3%' AND TIPO_MEDICAMENTO_CVE NOT LIKE '%U3%' AND TIPO_MEDICAMENTO_CVE NOT LIKE '%U2%' "; 
                            //        VvistaDetalles = from d in oRDEN_COMPRA_DETDataTable where !d.OBSERVACION_OC_DET.Contains(TRANSFER) && !d.TIPO_MEDICAMENTO_CVE.Contains("U10") && !d.TIPO_MEDICAMENTO_CVE.Contains("T3") && !d.TIPO_MEDICAMENTO_CVE.Contains("U3") && !d.TIPO_MEDICAMENTO_CVE.Contains("U2") && d.PROVEEDOR_ID == proveedorId select d;
                            //    }

                            //}

                            int contador = 1;
                            string folio = "";
                            //bool controlados = false;
                            //var compradores = new SIFNegocio.Compradores().CargaCompradores();

                            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow row in VvistaDetalles as System.Data.EnumerableRowCollection<SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow>)
                            {

                                if (contador == GruposDe)
                                {
                                    if (!esUnaSola)
                                    {
                                        contador = 1;
                                    }
                                }

                                //if (!EsUnir)
                                //{
                                //    if (row.TIPO_MEDICAMENTO_CVE.Contains("F1"))
                                //    {
                                //        if (!controlados)
                                //        {
                                //            //contador = 1;
                                //            //controlados = true;
                                //        }
                                //    }
                                //}

                                if (contador == 1)
                                {
                                    //GENERAMOS EL NUMERO DE FOLIO
                                    folio = GeneraFolio(sucursal, headerRow.ToString());
                                    foliosGenerados += "\n" + folio + ",";
                                    SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRARow rowFolio = dsOrdenesCompraDT.ORDEN_COMPRA.NewORDEN_COMPRARow();
                                    rowFolio.FOLIO_OC_ID = folio;
                                    rowFolio.PROVEEDOR_ID = headerRow;
                                    rowFolio.USUARIO_ID = comprador.ToString();

                                    //foreach (var comprador in compradores)
                                    //{
                                    //    if (comprador.IsLISTA_PROVEEDOR_IDNull())
                                    //    {
                                    //        comprador.LISTA_PROVEEDOR_ID = "";
                                    //    }

                                    //    string lineasComprador = new Usuarios().ListaLineas(comprador);

                                    //    if (lineasComprador.Contains(rowFolio.PROVEEDOR_ID.ToString()))
                                    //    {
                                    //        rowFolio.USUARIO_ID = comprador.USUARIO_ID;
                                    //        break;
                                    //    }

                                    //    rowFolio.USUARIO_ID = "0"; //POR ASIGNAR
                                    //}

                                    rowFolio.SUCURSAL_ID = (short)sucursal.SucursalesID;
                                    rowFolio.FECHA_ALTA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                                    rowFolio.ESTADO_OC = SIFModelo.EstadosOrdenCompra.ABIERTA.Clave;
                                    rowFolio.FECHA_AUTORIZA = new DateTime();
                                    //headerRow["FOLIO"] = folio;
                                    // dsOrdenesCompra.ORDEN_COMPRA.Rows.Add(rowFolio);
                                    rowFolio.FECHA_RECEPCION = new DateTime();
                                    rowFolio.FECHA_CIERRE = new DateTime();
                                    rowFolio.USUARIO_ID_AUTORIZA = "";
                                    if (OrdenCompra.IsOBSERVACION_OCNull())
                                    {
                                        OrdenCompra.OBSERVACION_OC = " ";
                                    }
                                    rowFolio.OBSERVACION_OC = OrdenCompra.OBSERVACION_OC;
                                    //if (OrdenCompraPoFolio(rowFolio.FOLIO_OC_ID) == null)
                                    //{
                                    this.GuardaOrdenCompra(rowFolio);
                                    this.foliosGenerados.Remove(rowFolio.FOLIO_OC_ID);
                                    //}
                                    //else
                                    //{
                                    //this.ActualizaOrdenCompra(rowFolio);
                                    //}
                                }

                                row.FOLIO_OC_ID = folio;
                                row.NUM_PARTIDA = contador;
                                row.USUARIO_ID = usuario.UsuariosID;


                                SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow det = this.dsOrdenesCompraDT.ORDEN_COMPRA_DET.NewORDEN_COMPRA_DETRow();
                                SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow deto = row as SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow;

                                // det.EXISTENCIAS = deto.EXISTENCIAS;

                                det.IMPORTE = deto.IMPORTE;
                                det.LABORATORIO_ID = deto.LABORATORIO_ID;

                                det.PRECIO_COSTO = deto.PRECIO_COSTO;

                                if (deto.IsPRECIO_FACTURANull())
                                {

                                    deto.PRECIO_FACTURA = 0;
                                }
                                det.PRECIO_FACTURA = deto.PRECIO_FACTURA;


                                // det.PUNTO_DE_REORDEN = deto.PUNTO_DE_REORDEN;
                                det.TIPO_MEDICAMENTO_CVE = deto.TIPO_MEDICAMENTO_CVE;




                                if (deto.IsNOMBRENull())
                                {
                                    SIFModelo.Articulo art = new SIFNegocio.Articulo().BuscarPorClave(deto.ARTICULO_ID);
                                    deto.NOMBRE = art.NOMBRE1;
                                }

                                //NECESARIOS
                                det.FOLIO_OC_ID = folio;
                                det.NUM_PARTIDA = contador;
                                det.USUARIO_ID = deto.USUARIO_ID;
                                det.PROVEEDOR_ID = deto.PROVEEDOR_ID;
                                det.ARTICULO_ID = deto.ARTICULO_ID;
                                det.NOMBRE = deto.NOMBRE;
                                det.CANT_SOLICITADA = deto.CANT_SOLICITADA;

                                if (deto.IsOFERTA_COMPRA_IDNull())
                                {
                                    det.OFERTA_COMPRA_ID = 0;
                                }
                                else
                                {
                                    det.OFERTA_COMPRA_ID = deto.OFERTA_COMPRA_ID;
                                }

                                if (det.IsDESCRIP_OFERTANull())  //if (deto.IsDESCRIP_OFERTANull())
                                {
                                    det.DESCRIP_OFERTA = "-";
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(deto.DESCRIP_OFERTA))
                                    {
                                        det.DESCRIP_OFERTA = "-";
                                    }
                                    else
                                    {
                                        det.DESCRIP_OFERTA = deto.DESCRIP_OFERTA;
                                    }
                                }
                                if (string.IsNullOrEmpty(deto.DESCRIP_OFERTA))
                                {
                                    det.DESCRIP_OFERTA = "-";
                                }
                                else
                                {
                                    det.DESCRIP_OFERTA = deto.DESCRIP_OFERTA;
                                }
                                det.PRECIO_COSTO = deto.PRECIO_COSTO;
                                det.ULT_PRECIO_COMPRA = deto.ULT_PRECIO_COMPRA;
                                det.CANT_FACTURADA = deto.CANT_FACTURADA;
                                det.CANT_RECIBIDA = deto.CANT_RECIBIDA;
                                det.CANT_DEVUELTA = deto.CANT_DEVUELTA;
                                det.CANT_MALESTADO = deto.CANT_MALESTADO;
                                det.CANT_REPOSICION = deto.CANT_REPOSICION;
                                det.PRECIO_FACTURA = deto.PRECIO_FACTURA;
                                det.DESCTO_FACTURA = deto.DESCTO_FACTURA;
                                det.DESCTO_FACTURA_AD1 = deto.DESCTO_FACTURA_AD1;
                                det.DESCTO_RECIBIDO = deto.DESCTO_RECIBIDO;
                                det.DESCTO_RECIBIDO_AD1 = deto.DESCTO_RECIBIDO_AD1;
                                det.DESCTO_RECIBIDO_AD2 = deto.DESCTO_RECIBIDO_AD2;
                                det.PRECIO_FARMACIA = deto.IsPRECIO_FARMACIANull() ? 0 : deto.PRECIO_FARMACIA;
                                det.ES_TRANSFER = deto.ES_TRANSFER;
                                var esNull = det.IsCODIGO_PROVEEDORNull();
                                if (esNull == true)
                                {
                                    det.CODIGO_PROVEEDOR = deto.CODIGO_PROVEEDOR;
                                }
                                else
                                {
                                    det.CODIGO_PROVEEDOR = "";
                                }
                                //if (deto.IsOBSERVACION_OC_DETNull())
                                //{
                                //    deto.OBSERVACION_OC_DET = " ";
                                //}
                                //det.OBSERVACION_OC_DET = deto.OBSERVACION_OC_DET;
                                //if (this.OrdenCompraDetallePoFolio(det) == null)
                                //{
                                this.GuardaOrdenCompraDetalle(det);
                                //}
                                //else
                                //{
                                //this.ActualizaOrdenCompraDetalle(det);
                                //}
                                contador++;
                                if (contador > GruposDe)
                                {
                                    if (deto.PROVEEDOR_ID == 99000)
                                    {
                                        continue;
                                    }

                                }

                                if (!EsUnir)
                                {
                                    if (contador == 9999)
                                    {
                                        contador = 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foliosGenerados = foliosGenerados.Trim(',');

            return foliosGenerados;
        }

        public String GuardaOrdenCompraAjuste(SIFModelo.Sucursal sucursal, SIFModelo.Usuario usuario, SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow OrdenCompra, SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETDataTable oRDEN_COMPRA_DETDataTable, bool EsUnir = false, bool esUnaSola = false)
        {
            string foliosGenerados = "";
            //GENERAMOS LA ORDEN DE COMPRA

            //AGREGAMOS LOS DETALLES POR FOLIO

            // DataView vistaDetalles = new DataView(oRDEN_COMPRA_DETDataTable);

            List<int> proveedoresS = new List<int>();
            List<bool> bloqueados = new List<bool>();

            bloqueados.Add(true);
            bloqueados.Add(false);

            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow row in oRDEN_COMPRA_DETDataTable)
            {

                if (row.IsUSUARIO_IDNull())
                {
                    row.USUARIO_ID = 0;
                }

                if (row.RowState == DataRowState.Deleted)
                {
                    continue;
                }

                //if (row.Bloqueado != true)
                //{
                //    row.Bloqueado = false;
                //}

                if (!proveedoresS.Contains(row.PROVEEDOR_ID))
                {
                    proveedoresS.Add(row.PROVEEDOR_ID);
                }
            }

            int proveedorId;

            //if (esUnaSola)
            //{
            //    filtrosOC = new List<string> { "" };
            //}

            foreach (int headerRow in proveedoresS)
            {
                proveedorId = int.Parse(headerRow.ToString());
                
                object VvistaDetalles = null;

                List<int> vsegmentos = new List<int>();
                foreach (var row in oRDEN_COMPRA_DETDataTable)
                {
                    if (esUnaSola)
                    {
                        row.OC_SEGMENTA = 0;
                        //     continue;
                    }

                    if (row.IsOC_SEGMENTANull())
                    {
                        row.OC_SEGMENTA = 0;
                    }
                    vsegmentos.Add(row.OC_SEGMENTA);
                }

                List<int> segmentos = vsegmentos.Distinct().ToList();

                List<int> compradores = new List<int>();




                var compradorDistinto = from d in oRDEN_COMPRA_DETDataTable where d.PROVEEDOR_ID == proveedorId select d.USUARIO_ID;

                compradores = compradorDistinto.Distinct().ToList();

                foreach (int comprador in compradores)
                {
                    foreach (bool bloqueado in bloqueados)
                    {
                        foreach (int concepto in segmentos)
                        {
                            
                            VvistaDetalles = from d in oRDEN_COMPRA_DETDataTable where d.PROVEEDOR_ID == proveedorId && d.OC_SEGMENTA == concepto && d.USUARIO_ID == comprador && d.Bloqueado == bloqueado select d;
                            
                            int contador = 1;
                            string folio = "";
                            

                            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow row in VvistaDetalles as System.Data.EnumerableRowCollection<SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow>)
                            {

                                if (contador == GruposDe)
                                {
                                    if (!esUnaSola)
                                    {
                                        contador = 1;
                                    }
                                }

                                
                                if (contador == 1)
                                {
                                    //GENERAMOS EL NUMERO DE FOLIO
                                    folio = GeneraFolio(sucursal, headerRow.ToString());
                                    foliosGenerados += "\n" + folio + ",";
                                    SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRARow rowFolio = dsOrdenesCompraDT.ORDEN_COMPRA.NewORDEN_COMPRARow();
                                    rowFolio.FOLIO_OC_ID = folio;
                                    rowFolio.PROVEEDOR_ID = headerRow;
                                    rowFolio.USUARIO_ID = comprador.ToString();

                                    
                                    rowFolio.SUCURSAL_ID = (short)sucursal.SucursalesID;
                                    rowFolio.FECHA_ALTA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                                    //rowFolio.ESTADO_OC = SIFModelo.EstadosOrdenCompra.CERRADA.Clave;//se modifica para validar que este cerrada
                                    rowFolio.ESTADO_OC = "A";// SIFModelo.EstadosOrdenCompra.ABIERTA.Clave;//se modifica para validar que este cerrada
                                    rowFolio.FECHA_AUTORIZA = new DateTime();
                                    
                                    rowFolio.FECHA_RECEPCION = new DateTime();
                                    rowFolio.FECHA_CIERRE = new DateTime();
                                    rowFolio.USUARIO_ID_AUTORIZA = "";
                                    if (OrdenCompra.IsOBSERVACION_OCNull())
                                    {
                                        OrdenCompra.OBSERVACION_OC = " ";
                                    }
                                    rowFolio.OBSERVACION_OC = OrdenCompra.OBSERVACION_OC;
                                    
                                    this.GuardaOrdenCompra(rowFolio);
                                    this.foliosGenerados.Remove(rowFolio.FOLIO_OC_ID);
                                    
                                }

                                row.FOLIO_OC_ID = folio;
                                row.NUM_PARTIDA = contador;
                                row.USUARIO_ID = usuario.UsuariosID;


                                SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow det = this.dsOrdenesCompraDT.ORDEN_COMPRA_DET.NewORDEN_COMPRA_DETRow();
                                SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow deto = row as SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow;

                                

                                det.IMPORTE = deto.IMPORTE;
                                det.LABORATORIO_ID = deto.LABORATORIO_ID;

                                det.PRECIO_COSTO = deto.PRECIO_COSTO;

                                if (deto.IsPRECIO_FACTURANull())
                                {

                                    deto.PRECIO_FACTURA = 0;
                                }
                                det.PRECIO_FACTURA = deto.PRECIO_FACTURA;
                              
                                det.TIPO_MEDICAMENTO_CVE = deto.TIPO_MEDICAMENTO_CVE;


                                if (deto.IsNOMBRENull())
                                {
                                    SIFModelo.Articulo art = new SIFNegocio.Articulo().BuscarPorClave(deto.ARTICULO_ID);
                                    deto.NOMBRE = art.NOMBRE1;
                                }

                                //NECESARIOS
                                det.FOLIO_OC_ID = folio;
                                det.NUM_PARTIDA = contador;
                                det.USUARIO_ID = deto.USUARIO_ID;
                                det.PROVEEDOR_ID = deto.PROVEEDOR_ID;
                                det.ARTICULO_ID = deto.ARTICULO_ID;
                                det.NOMBRE = deto.NOMBRE;
                                det.CANT_SOLICITADA = deto.CANT_SOLICITADA;

                                if (deto.IsOFERTA_COMPRA_IDNull())
                                {
                                    det.OFERTA_COMPRA_ID = 0;
                                }
                                else
                                {
                                    det.OFERTA_COMPRA_ID = deto.OFERTA_COMPRA_ID;
                                }

                                if (det.IsDESCRIP_OFERTANull())  //if (deto.IsDESCRIP_OFERTANull())
                                {
                                    det.DESCRIP_OFERTA = "-";
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(deto.DESCRIP_OFERTA))
                                    {
                                        det.DESCRIP_OFERTA = "-";
                                    }
                                    else
                                    {
                                        det.DESCRIP_OFERTA = deto.DESCRIP_OFERTA;
                                    }
                                }
                                if (string.IsNullOrEmpty(deto.DESCRIP_OFERTA))
                                {
                                    det.DESCRIP_OFERTA = "-";
                                }
                                else
                                {
                                    det.DESCRIP_OFERTA = deto.DESCRIP_OFERTA;
                                }
                                det.PRECIO_COSTO = deto.PRECIO_COSTO;
                                det.ULT_PRECIO_COMPRA = deto.ULT_PRECIO_COMPRA;
                                det.CANT_FACTURADA = deto.CANT_FACTURADA;
                                det.CANT_RECIBIDA = deto.CANT_RECIBIDA;
                                det.CANT_DEVUELTA = deto.CANT_DEVUELTA;
                                det.CANT_MALESTADO = deto.CANT_MALESTADO;
                                det.CANT_REPOSICION = deto.CANT_REPOSICION;
                                det.PRECIO_FACTURA = deto.PRECIO_FACTURA;
                                det.DESCTO_FACTURA = deto.DESCTO_FACTURA;
                                det.DESCTO_FACTURA_AD1 = deto.DESCTO_FACTURA_AD1;
                                det.DESCTO_RECIBIDO = deto.DESCTO_RECIBIDO;
                                det.DESCTO_RECIBIDO_AD1 = deto.DESCTO_RECIBIDO_AD1;
                                det.DESCTO_RECIBIDO_AD2 = deto.DESCTO_RECIBIDO_AD2;
                                det.PRECIO_FARMACIA = deto.IsPRECIO_FARMACIANull() ? 0 : deto.PRECIO_FARMACIA;
                                det.ES_TRANSFER = deto.ES_TRANSFER;
                                var esNull = det.IsCODIGO_PROVEEDORNull();
                                if (esNull == true)
                                {
                                    det.CODIGO_PROVEEDOR = deto.CODIGO_PROVEEDOR;
                                }
                                else
                                {
                                    det.CODIGO_PROVEEDOR = "";
                                }
                                
                                this.GuardaOrdenCompraDetalle(det);
                                
                                contador++;
                                if (contador > GruposDe)
                                {
                                    if (deto.PROVEEDOR_ID == 99000)
                                    {
                                        continue;
                                    }

                                }

                                if (!EsUnir)
                                {
                                    if (contador == 9999)
                                    {
                                        contador = 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foliosGenerados = foliosGenerados.Trim(',');

            return foliosGenerados;
        }

        public SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow OrdenCompraPoFolio(string OrdenCompraFolio)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.OrdenCompraPorFolio(OrdenCompraFolio);
        }

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow OrdenCompraDetallePoFolio(SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow OrdenCompraDetalle)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.OrdenCompraDetallePorFolio(OrdenCompraDetalle);
        }
        public SIFModelo.OrdenCompra.OrdenCompraDataSet OrdenCompraDetallesPorFolio(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow ordenCompra)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow ordenCompraR = new SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRADataTable().NewORDEN_COMPRARow();
            ordenCompraR.FOLIO_OC_ID = ordenCompra.FOLIO_OC_ID;
            ordenCompraR.SUCURSAL_ID = ordenCompra.SUCURSAL_ID;
            return this.OrdenCompraDetallesPorFolio(ordenCompraR);
        }
        public SIFModelo.OrdenCompra.OrdenCompraDataSet OrdenCompraDetallesPorFolio(SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow ordenCompra)
        {
            this.dsOrdenesCompra = SIFDatos.OrdenCompra.OrdenCompra.OrdenCompraDetallesPorFolio(ordenCompra);
            //LLENAMOS LOS DATOS FALTANTES

            //SIFNegocio.OrdenCompra.OrdenCompra ocl = new OrdenCompra();
            foreach (SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocrow in dsOrdenesCompra.ORDEN_COMPRA_DET.Rows)
            {
                SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(ocrow.ARTICULO_ID);
                if (articulo == null)
                {
                    if (ocrow.IsPRECIO_FARMACIANull())
                    {
                        ocrow.PRECIO_FARMACIA = 0;
                    }
                    ocrow.PRECIO_COSTO = ocrow.PRECIO_FARMACIA;
                    ocrow.CODIGO_PROVEEDOR = "";
                    ocrow.EXISTENCIA_GENERAL = 0;
                    ocrow.EXISTENCIAS = 0;
                    ocrow.LABORATORIO_ID = 0;
                    ocrow.MEJOR_OFERTA_COSTO = ocrow.PRECIO_FARMACIA;
                    ocrow.OBSERVACION_OC_DET = "";
                    ocrow.OC_SEGMENTA = 0;
                    ocrow.PUNTO_DE_REORDEN = 0;
                    ocrow.OFERTAS = 0;
                    ocrow.ULT_PRECIO_COMPRA = 0;
                    continue;
                }
                SIFNegocio.Inventario.Inventario InventarioL = new SIFNegocio.Inventario.Inventario();

                var inventario = InventarioL.InventarioArticulo(articulo);
                if (inventario == null)
                {
                    inventario = new SIFModelo.Inventarios.InventarioDataSet.INVENTARIODataTable().NewINVENTARIORow();
                }
                ocrow.TIPO_MEDICAMENTO_CVE = articulo.TIPO_MEDICAMENTO_CVE;
                //    ocrow.LABORATORIO_ID = articulo.LABORATORIO_ID;
                ocrow.EXISTENCIAS = inventario.IsEXISTENCIASNull() ? 0 : inventario.EXISTENCIAS;
                ocrow.PUNTO_DE_REORDEN = inventario.IsPUNTO_DE_REORDENNull() ? 0 : inventario.PUNTO_DE_REORDEN;
                //    //ocrow.PRECIO_COSTO = (decimal)inventario.COSTO_PROM;

                if (ocrow.IsPRECIO_FARMACIANull())
                {
                    SIFNegocio.OrdenCompra.OrdenCompra ocl = new OrdenCompra();
                    ocrow.PRECIO_FARMACIA = ocl.PrecioFarmacia(articulo.ARTICULO_ID, articulo.PROVEEDOR_ID, Helpers.Sesion.Sucursal);
                }
                //    ocrow.PRECIO_COSTO = 
                ocrow.PRECIO_FARMACIA = ocrow.PRECIO_FARMACIA;
                ocrow.EXISTENCIA_GENERAL = inventario.IsEXISTENCIA_GENERALNull() ? 0 : inventario.EXISTENCIA_GENERAL;

                List<string> LOfertas = Ofertas(articulo.ARTICULO_ID, ordenCompra.SUCURSAL_ID.ToString());
                ocrow.OFERTAS = LOfertas.Count;
                //    ocrow.IMPORTE = ocrow.PRECIO_COSTO * ocrow.CANT_SOLICITADA;

                //    if (ocrow.OFERTAS >= 1)
                //    {
                //        SIFModelo.OrdenCompra.OfertasCompra ocM = new SIFModelo.OrdenCompra.OfertasCompra();

                //        string[] data = LOfertas[1].Split(new char[] { '|' });

                //        if (data.Length <= 1)
                //        {
                //            //continue;
                //        }
                //        else
                //        {
                //            ocM.ProveedorID = int.Parse(data[0]);
                //            ocM.Nombre = data[1];
                //            ocM.DescuentoOfrecido = decimal.Parse(data[2]);
                //            ocM.DescuentoEspecialProveedor = decimal.Parse(data[3]);
                //            ocM.PiezasConCargo = int.Parse(data[4]);
                //            ocM.PiezasSinCargo = int.Parse(data[5]);

                //            // ocM.PrecioCosto = decimal.Parse(data[6]);
                //            ocM.PrecioCosto = decimal.Parse(data[7]);
                //            if (ocrow.IsPRECIO_FARMACIANull())
                //            {
                //                ocrow.PRECIO_FARMACIA = ocM.PrecioCosto;
                //            }

                //            ocM.PrecioCosto = ocrow.PRECIO_FARMACIA;

                //            decimal descuentoOfrecido = (ocM.PrecioCosto * (ocM.DescuentoOfrecido / 100m));
                //            decimal descuentoAdicional = (descuentoOfrecido * (ocM.DescuentoEspecialProveedor / 100m));
                //            ocM.PrecioCosto = ocM.PrecioCosto - descuentoOfrecido - descuentoAdicional;

                //            ocrow.PRECIO_COSTO = ocM.PrecioCosto;
                //            ocrow.PROVEEDOR_ID = ocM.ProveedorID;
                //            ocrow.IMPORTE = ocrow.PRECIO_COSTO * ocrow.CANT_SOLICITADA;

                //            ocrow.MEJOR_OFERTA_COSTO = ocM.PrecioCosto;
                //        }
                //    }
                //    else // debe ser igual a                          7501188802866
                //    {
                //        if (ocrow.IsPRECIO_FARMACIANull())
                //        {
                //            ocrow.PRECIO_FARMACIA = ocrow.PRECIO_COSTO;
                //        }
                //        ocrow.PRECIO_COSTO = ocrow.PRECIO_FARMACIA;
                //        ocrow.IMPORTE = ocrow.PRECIO_COSTO * ocrow.CANT_SOLICITADA;

                //        ocrow.MEJOR_OFERTA_COSTO = ocrow.PRECIO_COSTO;

                //    }

            }


            return this.dsOrdenesCompra;

        }

        public bool ActualizaOrdenCompra(SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRARow oc)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.ActualizaOrdenCompra(oc);
        }

        public bool ActualizaOrdenCompraDetalle(SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocd)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow det = new SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETDataTable().NewORDEN_COMPRA_DETRow();
            det.ARTICULO_ID = ocd.ARTICULO_ID;
            det.CANT_DEVUELTA = ocd.CANT_DEVUELTA;
            det.CANT_FACTURADA = ocd.CANT_FACTURADA;
            det.CANT_MALESTADO = ocd.CANT_MALESTADO;
            det.CANT_RECIBIDA = ocd.CANT_RECIBIDA;
            det.CANT_REPOSICION = ocd.CANT_REPOSICION;
            det.CANT_SOLICITADA = ocd.CANT_SOLICITADA;
            det.DESCRIP_OFERTA = ocd.DESCRIP_OFERTA;
            det.DESCTO_FACTURA = ocd.CANT_FACTURADA;
            det.DESCTO_FACTURA_AD1 = ocd.DESCTO_FACTURA_AD1;
            det.DESCTO_RECIBIDO = ocd.DESCTO_RECIBIDO;
            det.DESCTO_RECIBIDO_AD1 = ocd.DESCTO_RECIBIDO_AD1;
            det.DESCTO_RECIBIDO_AD2 = ocd.DESCTO_RECIBIDO_AD2;
            det.EXISTENCIAS = ocd.EXISTENCIAS;
            det.FOLIO_OC_ID = ocd.FOLIO_OC_ID;
            det.IMPORTE = ocd.IMPORTE;
            det.LABORATORIO_ID = ocd.LABORATORIO_ID;
            if (ocd.IsNOMBRENull())
            {
                ocd.NOMBRE = "";
            }
            det.NOMBRE = ocd.NOMBRE;
            det.NUM_PARTIDA = ocd.NUM_PARTIDA;
            det.OFERTA_COMPRA_ID = ocd.OFERTA_COMPRA_ID;
            det.PRECIO_COSTO = ocd.PRECIO_COSTO;
            det.PRECIO_FACTURA = ocd.PRECIO_FACTURA;
            det.PROVEEDOR_ID = ocd.PROVEEDOR_ID;
            det.PUNTO_DE_REORDEN = ocd.PUNTO_DE_REORDEN;
            det.TIPO_MEDICAMENTO_CVE = ocd.TIPO_MEDICAMENTO_CVE;
            det.ULT_PRECIO_COMPRA = ocd.ULT_PRECIO_COMPRA;
            det.USUARIO_ID = ocd.USUARIO_ID;
            det.PRECIO_FARMACIA = ocd.PRECIO_FARMACIA;
            if (ocd.IsOBSERVACION_OC_DETNull())
            {
                ocd.OBSERVACION_OC_DET = " ";
            }
            det.OBSERVACION_OC_DET = ocd.OBSERVACION_OC_DET;
            return this.ActualizaOrdenCompraDetalle(det);
        }

        public bool ActualizaOrdenCompraDetalle(SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow ocd)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.ActualizaOrdenCompraDetalle(ocd);
        }

        public SIFModelo.OrdenCompra.OrdenCompraDataSet.OFERTAS_COMPRAS_MAYORISTARow OfertaPorId(int ofertaId)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.OfertaPorId(ofertaId);
        }

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow FacturaPorNumero(string NumeroFactura)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.FacturaPorNumeroFactura(NumeroFactura);
        }

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet FacturasPorNumero(string NumeroFactura)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.FacturasPorNumeroFactura(NumeroFactura);
        }

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETDataTable DetallesFacturaProveedor(SIFModelo.OrdenCompra.OrdenesCompraDataSet.COMPRASDataTable compras)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.FacturaDetallesPorNumeroFactura(compras);
        }

        public bool EliminaDetalle(SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocd)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow det = new SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETDataTable().NewORDEN_COMPRA_DETRow();
            det.ARTICULO_ID = ocd.ARTICULO_ID;
            det.CANT_DEVUELTA = ocd.CANT_DEVUELTA;
            det.CANT_FACTURADA = ocd.CANT_FACTURADA;
            det.CANT_MALESTADO = ocd.CANT_MALESTADO;
            det.CANT_RECIBIDA = ocd.CANT_RECIBIDA;
            det.CANT_REPOSICION = ocd.CANT_REPOSICION;
            det.CANT_SOLICITADA = ocd.CANT_SOLICITADA;
            det.DESCRIP_OFERTA = ocd.DESCRIP_OFERTA;
            det.DESCTO_FACTURA = ocd.CANT_FACTURADA;
            det.DESCTO_FACTURA_AD1 = ocd.DESCTO_FACTURA_AD1;
            det.DESCTO_RECIBIDO = ocd.DESCTO_RECIBIDO;
            det.DESCTO_RECIBIDO_AD1 = ocd.DESCTO_RECIBIDO_AD1;
            det.DESCTO_RECIBIDO_AD2 = ocd.DESCTO_RECIBIDO_AD2;
            det.EXISTENCIAS = ocd.EXISTENCIAS;
            det.FOLIO_OC_ID = ocd.FOLIO_OC_ID;
            det.IMPORTE = ocd.IMPORTE;
            det.LABORATORIO_ID = ocd.LABORATORIO_ID;
            det.NOMBRE = ocd.NOMBRE;
            det.NUM_PARTIDA = ocd.NUM_PARTIDA;
            det.OFERTA_COMPRA_ID = ocd.OFERTA_COMPRA_ID;
            det.PRECIO_COSTO = ocd.PRECIO_COSTO;
            det.PRECIO_FACTURA = ocd.PRECIO_FACTURA;
            det.PROVEEDOR_ID = ocd.PROVEEDOR_ID;
            det.PUNTO_DE_REORDEN = ocd.PUNTO_DE_REORDEN;
            det.TIPO_MEDICAMENTO_CVE = ocd.TIPO_MEDICAMENTO_CVE;
            det.ULT_PRECIO_COMPRA = ocd.ULT_PRECIO_COMPRA;
            det.USUARIO_ID = ocd.USUARIO_ID;

            return EliminaDetalle(det);
        }

        public bool EliminaDetalle(SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRA_DETRow detalle)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.EliminaDetalle(detalle);
        }

        public decimal PrecioFarmacia(string articuloId, int proveedorId, SIFModelo.Sucursal sucursal)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.PrecioFarmacia(articuloId, proveedorId, sucursal.SucursalesID);
        }

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORDataTable FacturasCoincidente(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow v_ORDEN_COMPRARow, DateTime fecha1, DateTime fecha2)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet ds = OrdenCompraDetallesPorFolio(v_ORDEN_COMPRARow);

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORDataTable facturasProveedor = SIFDatos.OrdenCompra.OrdenCompra.FacturasConcidentes(v_ORDEN_COMPRARow, ds.ORDEN_COMPRA_DET, fecha1, fecha2);
            return facturasProveedor;
        }

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow FacturaCoincidente(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow v_ORDEN_COMPRARow)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet ds = OrdenCompraDetallesPorFolio(v_ORDEN_COMPRARow);

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow facturaProveedor = SIFDatos.OrdenCompra.OrdenCompra.FacturaConcidente(v_ORDEN_COMPRARow, ds.ORDEN_COMPRA_DET);
            return facturaProveedor;
        }

        public bool FacturaCoincidenteAutomatica()
        {
            SIFDatos.OrdenCompra.OrdenCompra.AsociaFacturaAutomatica();

            //SIFModelo.OrdenCompra.OrdenCompraDataSet ds = OrdenCompraDetallesPorFolio(v_ORDEN_COMPRARow);

            //SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow facturaProveedor = SIFDatos.OrdenCompra.OrdenCompra.FacturaConcidente(v_ORDEN_COMPRARow, ds.ORDEN_COMPRA_DET);
            //return facturaProveedor;
            return true;
        }
        public bool ActualizaOrdenCompra(SIFModelo.OrdenCompra.OrdenesCompraDataSet.COMPRASRow compra)
        {
            return SIFDatos.OrdenCompra.Compra.Actualiza(compra);
        }

        public bool ActualizaOrdenCompra(SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRARow oc)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRARow ocRow = new SIFModelo.OrdenCompra.OrdenesCompraDataSet.ORDEN_COMPRADataTable().NewORDEN_COMPRARow();
            ocRow.FOLIO_OC_ID = oc.FOLIO_OC_ID;
            ocRow.USUARIO_ID = oc.USUARIO_ID.ToString();
            ocRow.PROVEEDOR_ID = oc.PROVEEDOR_ID;
            ocRow.SUCURSAL_ID = oc.SUCURSAL_ID;
            ocRow.FECHA_ALTA = oc.FECHA_ALTA;
            if (oc.IsFECHA_RECEPCIONNull())
            {
                ocRow.FECHA_RECEPCION = new DateTime();
            }
            else
            {
                ocRow.FECHA_RECEPCION = oc.FECHA_RECEPCION;
            }

            if (oc.IsFECHA_CIERRENull())
            {
                oc.FECHA_CIERRE = new DateTime();
            }

            ocRow.FECHA_CIERRE = oc.FECHA_CIERRE;

            if (!oc.IsUSUARIO_ID_AUTORIZANull())
            {
                ocRow.USUARIO_ID_AUTORIZA = oc.USUARIO_ID_AUTORIZA;
            }
            else
            {
                ocRow.USUARIO_ID_AUTORIZA = "0";
            }

            if (oc.IsFECHA_AUTORIZANull())
            {
                oc.FECHA_AUTORIZA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            }

            ocRow.FECHA_AUTORIZA = oc.FECHA_AUTORIZA;
            ocRow.ESTADO_OC = oc.ESTADO_OC;
            //  ocRow.FECHA_RECEPCION = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            if (oc.IsOBSERVACION_OCNull())
            {
                oc.OBSERVACION_OC = " ";
            }
            ocRow.OBSERVACION_OC = oc.OBSERVACION_OC;

            if (oc.IsFOLIO_OC_ANTERIORNull())
            {
                oc.FOLIO_OC_ANTERIOR = " ";
            }
            ocRow.FOLIO_OC_ANTERIOR = oc.FOLIO_OC_ANTERIOR;

            return SIFDatos.OrdenCompra.OrdenCompra.ActualizaOrdenCompra(ocRow);
        }

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet DetallesFacturaProveedor(SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow factura)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.FacturaDetallesPorNumeroFactura(factura);
        }

        public bool InsertaCompra(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow compra)
        {
            return SIFDatos.OrdenCompra.Compra.Inserta(compra);
        }

        public string GeneraFolioCompra(SIFModelo.Sucursal sucursal, string proveedorID)
        {
            string prefijoFolio = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yy");
            string prefijoMes = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("MM");
            int folio = SIFDatos.OrdenCompra.OrdenCompra.GeneraFolioCompra(sucursal, prefijoFolio);

            string sb = sucursal.SucursalesID.ToString("00") + prefijoFolio + prefijoMes + folio.ToString().PadLeft(9, '0'); ;
            foliosGenerados.Add(sb);
            return sb;

        }

        public bool InsertaCompraDetalle(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow ocdet)
        {
            return SIFDatos.OrdenCompra.Compra.InsertaCompraDetalle(ocdet);
        }

        public SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASDataTable BuscaCompras(string folio, string folioOC, DateTime dateTime, DateTime dateTime_2, string statusOc)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.BuscaCompras(folio, dateTime, dateTime_2, statusOc, folioOC);
        }

        public SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETDataTable BuscaCompraDetalle(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASRow OrdenCompra)
        {
            return SIFDatos.OrdenCompra.Compra.BuscaCompraDetalle(OrdenCompra);
        }

        public SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASDataTable BuscaCompraPorOCID(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OrdenCompra)
        {
            return SIFDatos.OrdenCompra.Compra.BuscaCompraPorOCID(OrdenCompra);
        }

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDOR_DETDataTable DetallesFacturaProveedor(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRASDataTable compras)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.FacturaDetallesPorNumeroFactura(compras);
        }

        public bool AsociaFactura(SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow factura)
        {
            //VALIDAR QUE NO EXISTA OTRA FACTURA CON ESE NUMERO DE OC

            return SIFDatos.OrdenCompra.OrdenCompra.AsociaFactura(factura);
        }

        public SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow FacturaPorNumero(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow OrdenCompra)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.FacturaPorNumeroFactura(OrdenCompra);
        }

        public object PrecioFarmaciaSaba(SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow ocdRow)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.PrecioFarmaciaSaba(ocdRow);
        }

        public List<string> ListaRecepcionistas()
        {
            return SIFDatos.OrdenCompra.Compra.ListaRecepcionistas();
        }

        public bool ActualizaCodigo(SIFModelo.OrdenCompra.OrdenCompraDataSet.COMPRAS_DETRow detalle, string clave)
        {
            return SIFDatos.OrdenCompra.Compra.ActualizaCodigo(detalle, clave);
        }

        public SIFModelo.OrdenCompra.OrdenCompraDataSet.ORDEN_COMPRA_DETRow GeneraDeEOQArticulo(SIFModelo.Sucursal sucursal, SIFModelo.Usuario usuario, string ArticuloID)
        {
            SIFModelo.OrdenCompra.OrdenCompraDataSet dsArticuloCompra = new SIFModelo.OrdenCompra.OrdenCompraDataSet();
            return SIFDatos.OrdenCompra.OrdenCompra.GeneraCompraArticulo(dsArticuloCompra, sucursal, usuario, ArticuloID);
        }

        public DataTable OfertasProveedor(String articulo)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.OfertasProveedor(articulo, Helpers.Sesion.Sucursal);
        }

        public bool AsociaFactura(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC, SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow factura, string opcion = "A")
        {
            return SIFDatos.OrdenCompra.OrdenCompra.AsociaFactura(oC, factura, opcion);
        }

        public void ExportaCatalogoMayoristas(int proveedor_id)
        {
            if (proveedor_id == 0)
            {
               MessageBox.Show("Debe seleccionar un proveedor");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV|*.csv";
            sfd.FileName = "CATM-" + proveedor_id.ToString() + DateTime.Now.ToString("ddmmyyyHHmmss");

            DialogResult res = sfd.ShowDialog();

            if (res != DialogResult.OK)
            {
                return;
            }

            string contenido = "";

            contenido = SIFDatos.OrdenCompra.OrdenCompra.ExportaCatalogoMayorista(proveedor_id);

            using (StreamWriter sw = new StreamWriter(sfd.FileName))
            {
                sw.Write(contenido);
            }
        }

        public DataTable facturasRecepcion(DateTime fecha1, DateTime fecha2, string proveedorID)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.facturasRecepcion(fecha1, fecha2, proveedorID);
        }
        public DataTable incidenciasComrpas(DateTime fecha1,  string proveedorID)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.IncidenciasCompras (fecha1,  proveedorID);
        }

        private bool estadoArtMayorista(SIFModelo.Tipos.TipoStatusMayorista estado_mayorista)
        {   
            switch (estado_mayorista)               ///JOMAQC               27/09/2018
            {
                case SIFModelo.Tipos.TipoStatusMayorista.AGOTADO:
                    return false;                    
                case SIFModelo.Tipos.TipoStatusMayorista.FALTANTE:
                    return false;
                case SIFModelo.Tipos.TipoStatusMayorista.SIN_EXISTENCIA:
                    return false;
                case SIFModelo.Tipos.TipoStatusMayorista.DESCONTINUADO:
                    return false;
                case SIFModelo.Tipos.TipoStatusMayorista.NO_COMPRAR:
                    return false;                    
                default:
                    return true;
            }
        }




        private Int32 encuentraPrecioMin(Decimal[,] p) {
            Decimal pmin = 0M;
            Decimal p1 = 0M;

            for (int i = 0;i< p.Length ; i++) {
                if (i == 0)
                    p1 = p[i, 0];
                else {
                    if (i == 1)
                    {
                        if (p1 < p[i, 0])
                            pmin = p1;
                        else
                            pmin = p[i, 0];
                    }
                    else
                    {
                        if (pmin > p[i, 0])
                            pmin = p[i, 0];
                    }

                }

            }

            return 0;
        }
        
        public bool Insertar_ctl_oc(string folio_oc, string usuario, string equipo, string estado_old, string estado_new)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.Insertar_ctl_oc(folio_oc, usuario, equipo, estado_old, estado_new);
        }

        public bool Actualizar_oc(string folio_oc, string estado)
        {
            return SIFDatos.OrdenCompra.OrdenCompra.Actualizar_oc(folio_oc, estado);
        }

        public void Verificar_ctl_oc(string folio_oc, out string mensaje, out int cantidad, out string estado_old)
        {
            SIFDatos.OrdenCompra.OrdenCompra.Verificar_ctl_oc(folio_oc, out mensaje, out cantidad, out estado_old);
        }


    }
}


