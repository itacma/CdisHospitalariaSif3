using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using System.Globalization;

namespace SIFNegocio.WebServices
{
    public class NADRO
    {


        public void ProcesaVenta(SIFModelo.Remision remision, List<SIFModelo.RemisionDetalle> detalles, SIFModelo.Configuracion.Nadro configuracion, SIFModelo.WebServices.TarjetaNadro tarjeta)
        {
            List<SIFModelo.WebServices.NadroDetalle> beneficiosNadro = new List<SIFModelo.WebServices.NadroDetalle>();

            if (detalles.Count == 0)
            {
               MessageBox.Show("Debe proporcionar la información de al menos un articulo", "Circulo Salud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(configuracion.Usuario) ||
                string.IsNullOrWhiteSpace(configuracion.Contrasena) ||
                string.IsNullOrWhiteSpace(configuracion.Cadena) ||
                string.IsNullOrWhiteSpace(configuracion.Sucursal.ToString()))
            {
               MessageBox.Show("Error en la configuración del servicio" + Environment.NewLine +
                                  "Configuure el servicio antes de usuarlo", "Circulo Salud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            int NumArt = detalles.Count;
            int iPed = 0;

            // Mensajes de Error
            string MsgErr = string.Empty;
            string MsgFol = string.Empty;

            // Ticket
            string Cotizacion = string.Empty;

            // Instance Service
            WS_NADRO.WSCirculodelaSaludSoapClient ServicioNadro = new WS_NADRO.WSCirculodelaSaludSoapClient();
            // Instance Respuesta
            WS_NADRO.ResponseBonusList[] Respuesta = new WS_NADRO.ResponseBonusList[NumArt];

            // Instance Compra Product
            WS_NADRO.BonusProductList[] Products = new WS_NADRO.BonusProductList[NumArt];

            foreach (var row in detalles)
            {
                Products[iPed] = new WS_NADRO.BonusProductList();
                Products[iPed].Sku = row.ArticuloID;
                Products[iPed].Piezas = row.CantidadRemision;
                Respuesta[iPed] = new WS_NADRO.ResponseBonusList();
                iPed += 1;
            }

            try
            {
//#if !DEBUG
//                Respuesta[0].EfectivoxPunto = 0;
//                Respuesta[0].HuboError = false;
//                Respuesta[0].MensajeError = "";
//                Respuesta[0].MontoDescuento = 0;
//                Respuesta[0].PiezasAcumuladas = 0;
//                Respuesta[0].PiezasGratis = 0;
//                Respuesta[0].PiezasPendientes = 1;
//                Respuesta[0].PiezasPorComprar = 1;
//                Respuesta[0].PorcentajeDescuento = 4;
//                Respuesta[0].PorcentajePuntos = 0;
//                Respuesta[0].PrecioFijo = 0;
//                Respuesta[0].Sku = "7501059235304";
//                Respuesta[0].TipoPrecioDescuento = 0;
//#elseD

                Respuesta = ServicioNadro.GetBonusProductList(tarjeta.SesionID, tarjeta.NumeroTarjeta, Products);

//#endif
                /*iPed = 0;
                Products = new WS_NADRO.BonusProductList[(int)Respuesta.Count()];
                int NOSEKES = (int)Respuesta.Count();
                foreach (var row in Respuesta)
                {
                    Products[iPed] = new WS_NADRO.BonusProductList();
                    Products[iPed].Sku = Respuesta[iPed].Sku;
                    detalles[iPed].ArticuloID = Respuesta[iPed].Sku;
                    Products[iPed].Piezas = 0;// detalles[iPed].CantidadRemision;
                    
                    Respuesta[iPed] = new WS_NADRO.ResponseBonusList();
                    iPed += 1;
                }*/
                
                 
             //   int resp=0;
                // Recorre la lista
                foreach (var respuesta in Respuesta)
                {
                    
                    var detalleAsignado = from d in detalles where d.ArticuloID == respuesta.Sku select d;

                    SIFModelo.RemisionDetalle detalle = detalleAsignado.FirstOrDefault();
                   
                    //SIFModelo.WebServices.NadroControl control = new SIFModelo.WebServices.NadroControl();
                    // BUSCA EL ARTICULO
                    string sku=respuesta.Sku;
                    bool encontrado = false;
                    foreach (var row in detalles)
                    {
                        if (sku == row.ArticuloID)
                            encontrado = true;
                    }
                    
                  //  resp =resp+1;
                  //  if (resp > detalles.Count)
                    //if (respuesta.Sku != detalle.ArticuloID || String.IsNullOrEmpty(detalle.ArticuloID))
                    if (encontrado == false)
                    {
                        SIFModelo.Articulo articulo = new SIFModelo.Articulo();
                        SIFNegocio.Articulo articuloL = new SIFNegocio.Articulo();
                        detalle = new SIFModelo.RemisionDetalle();
                        articulo = articuloL.BuscarPorClave(respuesta.Sku);
                        if (articulo == null)
                        {
                           MessageBox.Show("El artículo no existe en el catalogo");
                            return;
                        }
                        detalle.ArticuloID = respuesta.Sku;
                        SIFNegocio.Inventario.Inventario inventario = new SIFNegocio.Inventario.Inventario();


                        int existencias = 0;
                        if (!inventario.InventarioArticulo(articulo, (int)respuesta.PiezasGratis, out existencias))
                        {
                            if (MessageBoxEx.Show("¿Agregar a la lista de artículos faltantes el artículo " + articulo.ARTICULO_ID + " [" + articulo.NOMBRE1 + "] ?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                articulo.TIPO_MONEDA = int.Parse(respuesta.PiezasGratis.ToString()) - existencias;
                                // agregaArticuloFaltante(articulo);
                                // beneficiosConsultado = false;
                                //reportarFaltantes();

                            }



                        }
                        SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ArticuloID);
                        if (precios == null)
                        {
                           MessageBox.Show("No hay un precio activo para este producto");
                        }
                        else
                        {
                            SIFModelo.Articulo articulop = new SIFNegocio.Articulo().BuscarPorClave(detalle.ArticuloID);
                            /*if (!articulop.TIPO_MEDICAMENTO_CVE.ToString().Contains("SD"))//L 23/12/2013 PARA EVITAR QUE SE APLIQUE PORCENTAJE SOBRE COSTO A SD
                                //L 20/11/2013 : *(1+precios.PORCENTAJE_IMP/100)
                                detalle.Precio = precios.PRECIO_VENTA;
                            else*/
                            detalle.Precio = 0;
                            detalle.Total = detalle.CantidadRemision * detalle.Precio;

                        }

                        detalle.ArticuloID = articulo.ARTICULO_ID;
                        detalle.CODIGO_CLI = articulo.CODIGO_CLI;
                        detalle.CODIGO_CLI_ID = articulo.CODIGO_CLI_ID;
                        // cantidadTextBoxX.Text = "1";
                        // detalle.CantidadRemision = 0;
                        //detalle.FechaEntrega = 
                        //detalle.ImpuestoID = 
                        //detalle.IVA = precio
                        detalle.CantidadRemision = (int)respuesta.PiezasGratis;
                        detalle.Nombre1 = articulo.NOMBRE1;
                        detalle.Nombre2 = articulo.NOMBRE2;
                        detalle.NumeroPartida = detalles.Count;
                        detalle.PiezasPagadas = 0;// (int)respuesta.PiezasPorComprar;
                        detalle.PiezasGratis = (int)respuesta.PiezasGratis;
                        detalle.PiezasAcumuladas = (int)respuesta.PiezasAcumuladas;
                        detalle.PrecioProveedor = respuesta.PrecioFijo;
                        detalle.TipoPrecioDescuento = respuesta.TipoPrecioDescuento;
                        detalle.MontoDescuento = respuesta.MontoDescuento;
                        detalle.PorcentajeDescuento = (decimal)respuesta.PorcentajeDescuento;
                        detalle.PiezasPendientes = (int)respuesta.PiezasPendientes;
                        //detalle.Nombre1 = "REGALO CS " + detalle.Nombre1;
                        if (respuesta.HuboError)
                        {
                            detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
                            detalle.Mensaje = respuesta.MensajeError;
                        }
                        else
                        {
                            detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                            detalle.Mensaje = string.Empty;
                        }
                        detalles.Add(detalle);



                    }
                    else
                    {

                        detalle.PiezasPagadas = (int)respuesta.PiezasPorComprar;
                        detalle.PiezasGratis = (int)respuesta.PiezasGratis;
                        detalle.PiezasAcumuladas = (int)respuesta.PiezasAcumuladas;
                        detalle.PrecioProveedor = respuesta.PrecioFijo;
                        detalle.TipoPrecioDescuento = respuesta.TipoPrecioDescuento;
                        detalle.MontoDescuento = respuesta.MontoDescuento;
                        detalle.PorcentajeDescuento = (decimal)respuesta.PorcentajeDescuento;
                        detalle.PiezasPendientes = (int)respuesta.PiezasPendientes;
                        if (respuesta.HuboError)
                        {
                            detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.NO;
                            detalle.Mensaje = respuesta.MensajeError;
                        }
                        else
                        {
                            detalle.BeneficioProveedor = SIFModelo.Tipos.SiNo.SI;
                            detalle.Mensaje = string.Empty;
                        }
                    }

                    //beneficiosNadro.Add(control);
                }

                //return beneficiosNadro;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            finally
            {
                ServicioNadro.Close();
                Cursor.Current = Cursors.Default;
            }
            //return null;
        }

        public bool InsertaControl(SIFModelo.WebServices.Nadro nadro, List<SIFModelo.WebServices.NadroDetalle> detalles)
        {
            //INSERTAMOS EN LA BD
            //SIFModelo.WebServices.Nadro nadroM = new SIFModelo.WebServices.Nadro();
            //nadroM.Activo = SIFModelo.Tipos.SiNo.SI;
            ////nadroM.CadenaID = int.Parse(configuracion.Cadena);
            //nadroM.CedulaProfesionalMedico = "";
            //nadroM.CotizacionID = tarjeta.SesionID;
            //nadroM.FechaCompra = nadro.FechaCompra;
            //nadroM.FechaConfirmacion = new DateTime();
            //nadroM.NumeroConfirmacion = "0";
            //nadroM.NumeroRemision = nadro.NumeroRemision;
            //nadroM.NumeroTarjeta = tarjeta.NumeroTarjeta;
            //nadroM.SucursalID = nadro.SucursalID;
            //nadroM.UsuarioID = 1;

            if (SIFDatos.WebServices.NADRO.Inserta(nadro))
            {
                foreach (SIFModelo.WebServices.NadroDetalle detalle in detalles)
                {
                    //SIFModelo.WebServices.NadroDetalle nDet = new SIFModelo.WebServices.NadroDetalle();

                    //nDet.ArticuloID = detalle.ArticuloID;
                    //nDet.CantAcumNadro = detalle.CantAcumNadro;
                    //nDet.CantPagarNadro = detalle.CantPagarNadro;
                    //nDet.CantRegaloNadro = detalle.CantRegaloNadro;
                    //nDet.CotizacionID = nadroM.CotizacionID.ToString();
                    //nDet.IVA = (int)detalle.IVA;
                    //nDet.MontoDesctoNadro = detalle.MontoDescuento;
                    //nDet.NumeroRemision = remision.NumeroRemision;
                    //nDet.Partida = detalle.NumeroPartida;
                    //nDet.PorcenDesctoNadro = (double)detalle.PorcentajeDescuento;
                    //nDet.PrecDesctoNadro = detalle.TipoPrecioDescuento;
                    //nDet.Precio = detalle.Precio;
                    //nDet.PrecioFijo = detalle.Precio;
                    //nDet.PrecioMaximo = detalle.PrecioProveedor;
                    //nDet.REFERENCIA = "-";


                    SIFDatos.WebServices.NADRO.InsertaDetalle(detalle);
                }
            }

            return true;
        }

        public string Cerrar(SIFModelo.Remision remision, List<SIFModelo.WebServices.NadroDetalle> detalles, SIFModelo.WebServices.TarjetaNadro tarjeta)
        {

            string RespuestaWs = "";

            if (detalles.Count == 0)
            {
               MessageBox.Show("Debe proporcionar la información de al menos un articulo", "Circulo Salud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return RespuestaWs;
            }

            Cursor.Current = Cursors.WaitCursor;

            int NumArt = 0; // GridVtaNadro.Rows.Count;
            int iPed = 0;

            // valida Si existe información para cerrar la venta
            foreach (SIFModelo.WebServices.NadroDetalle row in detalles)
            {
                //if (!string.IsNullOrEmpty(row.Cells["SkuMsg"].Value.ToString()))
                //    NumArt++;
                // if (row.SkuVta == true)
                NumArt += 1;
            }

            if (NumArt < detalles.Count)
            {
                //MessageBoxEx.Show("NO existe información de venta en los articulos seleccionados", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
               MessageBox.Show("Existe al menos un articulo con error", "Circulo Salud", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return RespuestaWs;
            }

            // Instance Service 
            WS_NADRO.WSCirculodelaSaludSoapClient ServicioNadro = new WS_NADRO.WSCirculodelaSaludSoapClient();
            // Instance Respuesta
            WS_NADRO.ResponseSales Respuesta = new WS_NADRO.ResponseSales();

            // Instance Compra Cierre
            WS_NADRO.Pedido Pedido = new WS_NADRO.Pedido();
            WS_NADRO.PedidoArticulos[] Articulos = new WS_NADRO.PedidoArticulos[NumArt];

            Pedido.NoTarjeta = tarjeta.NumeroTarjeta;
            Pedido.CedulaProfesionalMedico = string.Empty;
            Pedido.Usuario = Configuracion.Configuraciones.Nadro.Usuario;
            Pedido.Total = remision.Total;
            Pedido.NoTicket = remision.NumeroRemision;


            foreach (SIFModelo.WebServices.NadroDetalle row in detalles)
            {
                SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(row.ArticuloID);
                row.PrecioMaximo = precios.PRECIO_VENTA_MAX;


                Articulos[iPed] = new WS_NADRO.PedidoArticulos();
                Articulos[iPed].Sku = row.ArticuloID; //row.SkuId.ToString();
                Articulos[iPed].Precio = row.PrecioMaximo;//("1.20"); // Precio Máximo Público
                Articulos[iPed].PrecioPOS = row.Precio;//("1.00"); // Precio Mostrador
                //Articulos[iPed].PrecioPOS
                Articulos[iPed].PrecioFijo = row.PrecioFijo; //("PrecioFijo"); // Precio Fijo WEB Service
                Articulos[iPed].PorcentajeDescuento = (decimal)row.PorcenDesctoNadro;// Porcentaje Descto. WEB Service
                Articulos[iPed].MontoDescuento = row.MontoDesctoNadro; // Monto Descto. WEB Service
                Articulos[iPed].PiezasPagadas = row.CantPagarNadro;// Piezas Pagadas WEB Service
                Articulos[iPed].PiezasGratis = row.CantRegaloNadro;// Piezas CantRegaloNadro WEB Service
                Articulos[iPed].IVA = 0;  //row.IVA;
                Articulos[iPed].PorcentajeIVA = 0; //(double)row.PorcentajeIVA;
                iPed += 1;
            }
            try
            {
                Respuesta = ServicioNadro.Create_Sales(tarjeta.SesionID, Pedido, Articulos);

                if (Respuesta.HuboError)
                {

                   MessageBox.Show(Respuesta.MensajeError, "Circulo Salud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
                else // Grabar en la BD
                {
                   MessageBox.Show("La compra se realizo con folio: " + Respuesta.Pedido, "Circulo Salud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RespuestaWs = Respuesta.Pedido;
                    //tb_NadroNoPedido.Text = Respuesta.Pedido;
                    //tb_NadroSku.Focus();
                    return RespuestaWs;
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            finally
            {
                ServicioNadro.Close();
                Cursor.Current = Cursors.Default;
            }
            return RespuestaWs;
        }

        public Boolean ActivaTarjeta(SIFModelo.Configuracion.Nadro configuracion, SIFModelo.WebServices.TarjetaNadro tarjeta, SIFModelo.Cliente paciente, SIFModelo.DireccionCliente direccion, DateTime fechan, string sex, string nombreusu)
        {
            if (string.IsNullOrEmpty(configuracion.Cadena) ||
                 string.IsNullOrEmpty(configuracion.Usuario) ||
                 string.IsNullOrEmpty(configuracion.Contrasena) ||
                 string.IsNullOrEmpty(configuracion.Sucursal.ToString()))
            {
               MessageBox.Show("Error en la configuración del servicio" + Environment.NewLine +
                                  "Configure el servicio antes de usuarlo", "Circulo Salud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {

                Cursor.Current = Cursors.WaitCursor;

                string Respuesta = GetLogin(configuracion);

                if (!string.IsNullOrEmpty(Respuesta))
                {
                    if (ActiveCard(Respuesta, nombreusu, tarjeta.NumeroTarjeta, paciente.Nombre,
                                    paciente.ApellidoPaterno, paciente.ApellidoMaterno,
                                    direccion.Telefono, direccion.Email, sex,fechan,direccion.CodigoPostal))
                    {
                       MessageBox.Show("La Tarjeta: " + tarjeta.NumeroTarjeta + Environment.NewLine +
                      "Se Activo!", "Circulo Salud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

                Cursor.Current = Cursors.Default;
            }
            return true;
        }

        public string GetLogin(SIFModelo.Configuracion.Nadro configuracion)
        {


            string Sesion = string.Empty;

            try
            {
                // Instance Service
                WS_NADRO.WSCirculodelaSaludSoapClient ServicioNadro = new WS_NADRO.WSCirculodelaSaludSoapClient();
                WS_NADRO.ResponseLogin Respuesta = new WS_NADRO.ResponseLogin();
//#if !DEBUG
//                Respuesta.HuboError = false;
//                Respuesta.MensajeError = "";
//                Respuesta.Sesion = "14551251561-A-"+ new Random(9999).Next(9999);
//                return Respuesta.Sesion;
//#else

                // Instance Login
                Respuesta = ServicioNadro.Login(configuracion.Usuario, configuracion.Contrasena, configuracion.Cadena, configuracion.Sucursal.ToString());
//#endif
                if (Respuesta.HuboError)
                {
                   MessageBox.Show("Error: " + Environment.NewLine + Respuesta.MensajeError,
                        "Circulo Salud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Sesion = Respuesta.Sesion;
                }

                ServicioNadro.Close();

                return Sesion;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message,
                    "Circulo Salud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return string.Empty;
            }
        }

        public bool TestConnection(SIFModelo.Configuracion.Nadro configuracion)
        {
            try
            {
                // Instance Service
                WS_NADRO.WSCirculodelaSaludSoapClient ServicioNadro = new WS_NADRO.WSCirculodelaSaludSoapClient();
                WS_NADRO.ResponseLogin Respuesta = new WS_NADRO.ResponseLogin();

                // Instance Login
                return ServicioNadro.TestConnect();

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message,
                    "Circulo Salud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public string GetInfoCard(string Sesion, string NoTarjeta)
        {
            string Nombre = string.Empty;

            try
            {
                // Instance Service
                WS_NADRO.WSCirculodelaSaludSoapClient ServicioNadro = new WS_NADRO.WSCirculodelaSaludSoapClient();
                WS_NADRO.Tarjeta Respuesta = new WS_NADRO.Tarjeta();

//#if !DEBUG
//                Respuesta.cliente = new WS_NADRO.Cliente() { Nombre = "RENE", ApellidoPaterno = "LUNA", ApellidoMaterno = "LEON" };
//                Respuesta.fecha_activacion = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
//                Respuesta.fecha_asignacion = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
//                Respuesta.fecha_registro = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
//                Respuesta.fecha_vigencia = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
//                Respuesta.folio = NoTarjeta;
//                Respuesta.folio_codigo = "";
//                Respuesta.HuboError = false;
//                Respuesta.id = 10112;
//                Respuesta.id_usuario = "";
//                Respuesta.MensajeError = "";
//                return Nombre = Respuesta.cliente.Nombre + " " +
//                             Respuesta.cliente.ApellidoPaterno + " " +
//                             Respuesta.cliente.ApellidoMaterno;

//#else
                // Instance Login
                Respuesta = ServicioNadro.GetInfoCard(Sesion, NoTarjeta);
//#endif


                if (Respuesta.HuboError)
                {
                   MessageBox.Show("Error: " + Environment.NewLine + Respuesta.MensajeError,
                        "Circulo Salud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Nombre = Respuesta.cliente.Nombre + " " +
                             Respuesta.cliente.ApellidoPaterno + " " +
                             Respuesta.cliente.ApellidoMaterno;
                }

                ServicioNadro.Close();

                return Nombre;

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message,
                    "Circulo Salud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return string.Empty;
            }

        }

        private bool ActiveCard(string Sesion, string usuario, string Tarjeta, string Nombre, string ApePat, string ApeMat, string NoTel, string eMail, string sex, DateTime fechan, string cp )
        {
            bool OK = false;
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                // Instance Service
                WS_NADRO.WSCirculodelaSaludSoapClient ServicioNadro = new WS_NADRO.WSCirculodelaSaludSoapClient();
                WS_NADRO.ResponseActivateCard Respuesta = new WS_NADRO.ResponseActivateCard();
                string dateTime = fechan.ToString();
                string createddate = Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd");
                DateTime dt = DateTime.ParseExact(createddate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime loadedDate = DateTime.Parse(createddate);

                Respuesta = ServicioNadro.ActivateCardUser(Sesion, usuario, Tarjeta, Nombre, ApePat, ApeMat, NoTel, eMail, sex, dt, cp);
                

                if (Respuesta.HuboError)
                {
                   MessageBox.Show("Error: " + Environment.NewLine + Respuesta.MensajeError,
                        "CirculoSalud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                OK = Respuesta.Activada;
                // Close Service
                ServicioNadro.Close();

                return OK;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message,
                    "Circulo Salud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return OK;
            }

        }

        public List<SIFModelo.WebServices.NadroDetalle> ControlDetalles(SIFModelo.WebServices.Nadro remision)
        {
            return SIFDatos.WebServices.NADRO.ControlDetalles(remision);
        }

        public SIFModelo.WebServices.Nadro Control(SIFModelo.Remision remision)
        {
            return SIFDatos.WebServices.NADRO.Control(remision);
        }

        public bool Actualizar(SIFModelo.WebServices.Nadro nadroG)
        {
            return SIFDatos.WebServices.NADRO.Actualiza(nadroG);
        }
    }
}
